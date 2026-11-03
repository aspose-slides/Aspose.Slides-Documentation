using System;
using System.Linq;
using Aspose.Slides;

internal static partial class Program
{
    static void Case02()
    {
        using var presentation = new Presentation(Seed("control"));
        var slide = presentation.Slides[0];

        // Access the first ActiveX control.
        var control = slide.Controls.FirstOrDefault();
        if (control != null)
        {
            Console.WriteLine($"Control Name: {control.Name}");
            Console.WriteLine($"Value: {control.Properties["Value"]}");
        }

        VerifyCase02(presentation);
    }
}
