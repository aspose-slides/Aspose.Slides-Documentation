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
// Loads the presentation
auto presentation = System::MakeObject<Presentation>(u"Print.ppt");

// Calls the print method with no parameters
presentation->Print();
```

## **Print to Specific Printer**

This operation is used to print all the slides in a PowerPoint presentation through a specific printer.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) class and pass the presentation you want to print.
2. Call the Print method and pass the printer name as a string.

This C++ code shows you how to print a PowerPoint presentation using a specific printer:

```c++
try
{
    // Loads the presentation
    auto presentation = System::MakeObject<Presentation>(u"Print.ppt");

    // Calls the print method with the printer name
    presentation->Print(u"Please set your printer name here");
}
catch (System::Exception& ex)
{
    System::Console::WriteLine(ex->get_Message() + u"\nPlease set printer name as string parameter to the Presentation Print method");
}
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
auto pres = System::MakeObject<Presentation>();

auto printerSettings = System::MakeObject<System::Drawing::Printing::PrinterSettings>();
printerSettings->set_Copies(static_cast<int16_t>(2));
printerSettings->get_DefaultPageSettings()->set_Landscape(true);
printerSettings->get_DefaultPageSettings()->get_Margins()->set_Left(10);

// ...etc
pres->Print(printerSettings);
```
