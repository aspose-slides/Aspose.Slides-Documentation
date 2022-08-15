---
title: Print Presentation
type: docs
weight: 50
url: /net/print-presentation/
keywords: "Print PowerPoint, PPT, PPTX, Print Presentation, C#, Csharp, .NET, Printer, Print Options"
description: "Print PowerPoint Presentation in C# or .NET"
---
Aspose.Slides for .NET provides 4 overloaded [Print](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/print) methods that allow you to print presentations. The overloaded methods take different arguments, so you will always find a method that suits your printing needs.

## **Print to Default Printer**

This simple print operation is used to print all the slides in a PowerPoint presentation through a system's default printer.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class and pass the presentation you want to print.
2. Call the [Print](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/print/#ipresentationprint-method-1-of-4) method (with no parameters). 

This C# code shows you how to print a PowerPoint presentation:

```c#
// Loads the presentation
Presentation presentation = new Presentation("Print.ppt");

// Calls the print method with no parameters
presentation.Print();
```

## **Print to Specific Printer**

This operation is used to print all the slides in a PowerPoint presentation through a specific printer.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class and pass the presentation you want to print.
2. Call the Print method and pass the printer name as a string.

This C# code shows you how to print a PowerPoint presentation using a specific printer:

```c#
try
{
    // Loads the presentation
    Presentation presentation = new Presentation("Print.ppt");

    // Calls the print method with the printer name 
    presentation.Print("Please set your printer name here");

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message + "\nPlease set printer name as string parameter to the Presentation Print method");
}
```

## **Set Print Options Dynamically**

Using properties from the [PrinterSettings](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings?view=dotnet-plat-ext-6.0) class, you can apply parameters that define the printing operation. You can specify how many copies should be printed, whether slides should be printed in landscape or portrait, your preferred margins, etc.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class and pass the presentation you want to print.
2. Instantiate the [PrinterSettings](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings?view=dotnet-plat-ext-6.0) class.
3. Specify your preferred parameters for the printing operation:
   * the number of copies
   * page orientation
   * margin figures, etc.
4. Call the `Print` method.

This C# code shows you how to print a PowerPoint presentation with certain print options: 

```c#
using (Presentation pres = new Presentation())
{
	PrinterSettings printerSettings = new PrinterSettings();
	printerSettings.Copies = 2;
	printerSettings.DefaultPageSettings.Landscape = true;
	printerSettings.DefaultPageSettings.Margins.Left = 10;
	   //...etc
	pres.Print(printerSettings);
}
```
