
// ------------------------------------------------------------
// Author:  Keenan Barber
// Date:    2/1/2019
// Description: 
//      Functions made to handle the calculation 
//      of integral approcimations. 
// ------------------------------------------------------------

using System;
class IntegralApproximation {
    public delegate double Function(double input); // Callback to be used as a parameter
    
    static void Main() {
        
        // Variable used to hold result of calculations below
        double result = 0.0;
      
        Console.WriteLine("Approximate the definite integral of f(x) = sin(x^2) from 0 to 1.5, where n = 4.");
      
        // ------------------------------------------------------------
        // [EXAMPLE 1] Midpoint Rule: of Sin(x^2) from 0 to 1.5, where n = 4
        result = IntegralApprox_Midpoint(0.0, 1.5, 4, (double x) => {
            return Math.Sin(x*x);
        });
        Console.WriteLine("1. Midpoint Approx. = " + result);
        // ------------------------------------------------------------
        
        // ------------------------------------------------------------
        // [EXAMPLE 2] Midpoint Rule: of Sin(x^2) from 0 to 1.5, where n = 4
        result = IntegralApprox_Trapezoidal(0.0, 1.5, 4, (double x) => {
            return Math.Sin(x*x);
        });
        Console.WriteLine("2. Trapezoidal Approx. = " + result);
        // ------------------------------------------------------------
        
        // ------------------------------------------------------------
        // [EXAMPLE 3] Simpson's Rule: of Sin(x^2) from 0 to 1.5, where n = 4
        result = IntegralApprox_Simpson(0.0, 1.5, 4, (double x) => {
            return Math.Sin(x*x);
        });
        Console.WriteLine("3. Simpson's Approx. = " + result);
        // ------------------------------------------------------------
        
    }
    
    
    // -----------------------------------------------------
    // Integral approximation using the midpoint rule       \
    // ------------------------------------------------------
    static double IntegralApprox_Midpoint(double min, double max, int sections, Function func) {
        if (sections <= 0 || func == null) { return 0.0; } // --- End if invalid data
        double approx = 0.0;
        double barWidth = ((max - min) / sections); // ---------- Width of each bar of approximation
        double offsetToMidpoint = (barWidth / 2); // ------------ Offset to get 'midpoints' for bars

        for (int i = 0; i < sections; i++) {
            double xVal = (i * barWidth) + offsetToMidpoint;
            double yVal = func(xVal);
            approx += yVal;
        }
        approx *= barWidth;
        return approx;
    }
    
    // -----------------------------------------------------
    // Integral approximation using the trapezoidal rule    \
    // ------------------------------------------------------
    static double IntegralApprox_Trapezoidal(double min, double max, int sections, Function func) {
        if (sections <= 0 || func == null) { return 0.0; } // --- End if invalid data
        double approx = 0.0;
        double barWidth = ((max - min) / sections); // --- Width of each bar of approximation

        for (int i = 1; i <= sections; i++) {
            double x = (i * barWidth) + min;
            double prevX = ((i-1) * barWidth) + min;
            approx += (1.0 / 2.0) * (func(prevX) + func(x));
        }
        approx *= barWidth;
        
        return approx;
    }
    
    // -----------------------------------------------------
    // Integral approximation using the Simpson's rule      \
    // ------------------------------------------------------
    static double IntegralApprox_Simpson(double min, double max, int sections, Function func) {
        if (sections <= 0 || func == null) { return 0.0; } // --- End if invalid data
        sections = (sections % 2 == 1) ? sections + 1 : sections; // --- Make sure sections are even
        
        double approx = 0.0;
        double barWidth = ((max - min) / sections); // --- Width of each bar of approximation

        for (int i = 2; i <= sections; i+=2) {
            double x_2 = ((i-2) * barWidth) + min; // ---- x_(i-2)
            double x_1 = ((i-1) * barWidth) + min; // ---- x_(i-1) 
            double x_0 = (i * barWidth) + min; // -------- x_i
            approx += (1.0 / 3.0) * (func(x_2) + (4*func(x_1)) + func(x_0));
        }
        approx *= barWidth;
        
        return approx;
    }
}