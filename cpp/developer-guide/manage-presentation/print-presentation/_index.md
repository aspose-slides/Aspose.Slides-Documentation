---
title: Print Presentation
type: docs
weight: 50
url: /cpp/print-presentation/
keywords: "Print PowerPoint, PPT, PPTX, Print Presentation, C++, CPP, Printer, Print Options"
description: "Print PowerPoint Presentation in C++"
---
Aspose.Slides for C++ provides 4 overloaded `Print` methods that allow you to print presentations. The overloaded methods take different arguments, so you will always find a method that suits your printing needs.

## **Print to Default Printer**

This simple print operation is used to print all the slides in a PowerPoint presentation through a system's default printer.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) class and pass the presentation you want to print.
2. Call the `Print` method (with no parameters). 

This C++ code shows you how to print a PowerPoint presentation:

```c++

```

## **Print to Specific Printer**

This operation is used to print all the slides in a PowerPoint presentation through a specific printer.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) class and pass the presentation you want to print.
2. Call the Print method and pass the printer name as a string.

This C++ code shows you how to print a PowerPoint presentation using a specific printer:

```c++

```

## **Set Print Options Dynamically**

Using properties from the `PrinterSettings` class, you can apply parameters that define the printing operation. You can specify how many copies should be printed, whether slides should be printed in landscape or portrait, your preferred margins, etc.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) class and pass the presentation you want to print.
2. Instantiate the `PrinterSettings` class.
3. Specify your preferred parameters for the printing operation:
   * the number of copies
   * page orientation
   * margin figures, etc.
4. Call the `Print` method.

This C++ code shows you how to print a PowerPoint presentation with certain print options: 

```c++

```
