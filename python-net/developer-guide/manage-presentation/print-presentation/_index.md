---
title: Print Presentation
type: docs
weight: 50
url: /python-net/print-presentation/
keywords: "Print PowerPoint, PPT, PPTX, Print Presentation, Python, Printer, Print Options"
description: "Print PowerPoint Presentation in Python"
---
Aspose.Slides for Python provides 4 overloaded `Print` methods that allow you to print presentations. The overloaded methods take different arguments, so you will always find a method that suits your printing needs.

## **Print to Default Printer**

This simple print operation is used to print all the slides in a PowerPoint presentation through a system's default printer.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and pass the presentation you want to print.
2. Call the `Print` method (with no parameters). 

This Python code shows you how to print a PowerPoint presentation:

```python
import aspose.slides as slides

# Load the presentation
presentation = slides.Presentation("Print.ppt")

# Call the print method to print whole presentation to the default printer
presentation.print()
```

## **Print to Specific Printer**

This operation is used to print all the slides in a PowerPoint presentation through a specific printer.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and pass the presentation you want to print.
2. Call the `Print` method and pass the printer name as a string.

This Python code shows you how to print a PowerPoint presentation using a specific printer:

```python
import aspose.slides as slides

try:
    # Load the presentation
    with slides.Presentation("pres.pptx") as pres:
        # Call the print method to print whole presentation to the desired printer
        pres.print("Please set your printer name here")
except:
    print("Please set printer name as string parameter to the Presentation Print method")
```

## **Set Print Options Dynamically**

Using properties from the `PrinterSettings` class, you can apply parameters that define the printing operation. You can specify how many copies should be printed, whether slides should be printed in landscape or portrait, your preferred margins, etc.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class and pass the presentation you want to print.
2. Instantiate the `PrinterSettings` class.
3. Specify your preferred parameters for the printing operation:
   * the number of copies
   * page orientation
   * margin figures, etc.
4. Call the `Print` method.

This Python code shows you how to print a PowerPoint presentation with certain print options: 

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("pres.pptx") as pres:
    printerSettings = drawing.printing.PrinterSettings()
    printerSettings.copies = 2
    printerSettings.default_page_settings.landscape = True
    printerSettings.default_page_settings.margins.left = 10
    pres.print(printerSettings)
```

