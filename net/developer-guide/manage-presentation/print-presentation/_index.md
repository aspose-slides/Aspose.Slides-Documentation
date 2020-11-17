---
title: Print Presentation
type: docs
weight: 50
url: /net/print-presentation/
---
## Overview
Aspose.Slides for .NET provides four overloads methods for the printing of the presentations. These methods are flexible enough to print the presentation to the default printer or to any of the available printers with customized settings. You only need to select the appropriate print method according to the requirement.
## **Print to Default Printer**
Printing of the presentation to the default printer is quite simple in Aspose.Slides for .NET. Perform the following steps in order to print the presentation to default printer:

1. Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class to load a presentation that is to be printed
1. Call the [Print method](https://apireference.aspose.com/net/slides/aspose.slides.ipresentation/print/methods/1) with no parameters as exposed by the Presentation object

In the example given below, we have call the Print method with no parameters.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Rendering-Printing-DefaultPrinterPrinting-DefaultPrinterPrinting.cs" >}}

## **Print to Specific Printer**
Printing of the presentation to the specific printer requires the name of the printer as a parameter to the [**Print**](https://apireference.aspose.com/net/slides/aspose.slides.ipresentation/print/methods/1) method of the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation). Perform the following steps in order to print the presentation to the desired printer:

1. Create an instance of [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class to load a presentation that is to be printed.
1. Call the [Print method](https://apireference.aspose.com/net/slides/aspose.slides.ipresentation/print/methods/1) of the Presentation class with the printer name as a string parameter to the Print method.

In the example given below, we have called the Print method with the printer name as a string parameter to the Print method.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Rendering-Printing-SpecificPrinterPrinting-SpecificPrinterPrinting.cs" >}}

## **Set Print Options Dynamically**
Aspose.Slides provides support for setting the print presentation dynamically with options involving setting Margin, Print copies and also provide an option to preview print setting dialog. To setup printer settings use an instance of [**System.Drawing.Printing.PrinterSettings**](https://apireference.aspose.com/cpp/slides/class/system.drawing.printing.printer_settings/) class. Perform the following steps in order to print the presentation, set print option like Margin, Print copies and also you can set print option dynamically.

1. Create an instance of [**Presentation**](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class to load a presentation that is to be printed
1. Instantiate printer setting object to represent print settings.
1. Set number of copies to be printed.
1. Set orientation of page.
1. Set margin for a page.
1. Print preview and print setting dialog.

In the example given below, we have called the Print method with no parameters.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Rendering-Printing-PrintPreview-PrintPreview.cs" >}}
