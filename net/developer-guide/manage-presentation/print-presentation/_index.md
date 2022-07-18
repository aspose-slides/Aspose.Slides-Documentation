---
title: Print Presentation
type: docs
weight: 50
url: /net/print-presentation/
keywords: "Print PowerPoint, PPT, PPTX, Print Presentation, C#, Csharp, .NET, Printer, Print Options"
description: "Print PowerPoint Presentation in C# or .NET"
---
## Overview
Aspose.Slides for .NET provides four overloads methods for the printing of the presentations. These methods are flexible enough to print the presentation to the default printer or to any of the available printers with customized settings. You only need to select the appropriate print method according to the requirement.
## **Print to Default Printer**
Printing of the presentation to the default printer is quite simple in Aspose.Slides for .NET. Perform the following steps in order to print the presentation to default printer:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class to load a presentation that is to be printed
1. Call the [Print method](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/print/methods/1) with no parameters as exposed by the Presentation object

In the example given below, we have call the Print method with no parameters.

```c#
// Load the presentation
Presentation presentation = new Presentation("Print.ppt");

// Call the print method to print whole presentation to the default printer
presentation.Print();
```



## **Print to Specific Printer**
Printing of the presentation to the specific printer requires the name of the printer as a parameter to the [**Print**](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/print/methods/1) method of the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). Perform the following steps in order to print the presentation to the desired printer:

1. Create an instance of [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class to load a presentation that is to be printed.
1. Call the [Print method](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/print/methods/1) of the Presentation class with the printer name as a string parameter to the Print method.

In the example given below, we have called the Print method with the printer name as a string parameter to the Print method.

```c#
try
{
    // Load the presentation
    Presentation presentation = new Presentation("Print.ppt");

    // Call the print method to print whole presentation to the desired printer
    presentation.Print("Please set your printer name here");

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message + "\nPlease set printer name as string parameter to the Presentation Print method");
}
```



## **Set Print Options Dynamically**
Aspose.Slides provides support for setting the print presentation dynamically with options involving setting Margin, Print copies and also provide an option to preview print setting dialog. To setup printer settings use an instance of [**System.Drawing.Printing.PrinterSettings**](https://reference.aspose.com/slides/net/aspose.slides.presentation/print/methods/1) class. Perform the following steps in order to print the presentation, set print option like Margin, Print copies and also you can set print option dynamically.

1. Create an instance of [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) class to load a presentation that is to be printed
1. Instantiate printer setting object to represent print settings.
1. Set number of copies to be printed.
1. Set orientation of page.
1. Set margin for a page.
1. Print preview and print setting dialog.

In the example given below, we have called the Print method with no parameters.

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

