---
title: Print Presentation
type: docs
weight: 50
url: /java/print-presentation/
keywords: "Print PowerPoint, PPT, PPTX, Print Presentation, Java, Printer, PrinterJob, PrintService"
description: "Print PowerPoint Presentation in Java"
---

This article describes how to print a presentation using Aspose.Slides for Java API. 


## **Print to Default Printer**

This operation allows you to print all slides in a PowerPoint presentation using the default printer installed on your system.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), passing the path or file name of the presentation you wish to print.
1. Call the `print` method.

This Java code snippet demonstrates how to print a PowerPoint presentation using the default printer. Make sure to replace **"presentation.pptx"** with the path or file name of your presentation.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    pres.print();
} finally {
    if (pres != null) pres.dispose();
}
```


## **Print to Specific Printer**

This operation allows you to print all slides in a PowerPoint presentation using a specific printer of your choice.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class and specifying the presentation file.
1. Call the `print` method with the printer name.

This Java code snippet demonstrates how to print a PowerPoint presentation using a specific printer. Replace **"Please set your printer name here"** with the name of the printer you intend to use for printing the presentation.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    pres.print("Please set your printer name here");
} finally {
    if (pres != null) pres.dispose();
}
```


## **Set Print Options Dynamically**

This operation allows you to customize the printing process, including options such as orientation, page range, and slide notes layout.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) class, specifying the presentation file.
1. Create an instance of the `PrintRequestAttributeSet` and specify printing attributes such as orientation and page range.
1. Create an instance of the `RenderingOptions` and specify slide notes layout options.
1. Call `print` method.

This Java code snippet shows how to print a PowerPoint presentation with customized print options. Ensure to replace **"MyPrinter"** with the name of your specific printer and **"PresentationPrinterJob"** with the desired job name, and configure the `PrintRequestAttributeSet` and `RenderingOptions` according to your printing requirements.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    PrintRequestAttributeSet attributes = new HashPrintRequestAttributeSet();
    attributes.add(OrientationRequested.PORTRAIT);
    attributes.add(new PageRanges(1, 2));

    RenderingOptions options = new RenderingOptions();
    INotesCommentsLayoutingOptions slidesLayoutOptions = new NotesCommentsLayoutingOptions();
    slidesLayoutOptions.setNotesPosition(NotesPositions.BottomFull);
    options.setSlidesLayoutOptions(slidesLayoutOptions);

    pres.print(attributes, options, "MyPrinter", "PresentationPrinterJob");
} finally {
    if (pres != null) pres.dispose();
}
```
