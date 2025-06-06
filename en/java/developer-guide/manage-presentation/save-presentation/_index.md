---
title: Save Presentation
type: docs
weight: 80
url: /java/save-presentation/
---

## **Overview**
{{% alert color="primary" %}} 

[Opening Presentation](/slides/java/open-presentation/) described how to use the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class to open a presentation. This article explains how to create and save presentations.

{{% /alert %}} 

The [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class holds a presentation's content. Whether creating a presentation from scratch or modifying an existing one, when finished, you want to save the presentation. With Aspose.Slides for Java, it can be saved as a **file** or **stream**. This article explains how to save a presentation in different ways:

## **Save Presentation to File**
Save a presentation to file by calling the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) method. Simply pass the file name and [**SaveFormat**](https://reference.aspose.com/slides/java/com.aspose.slides/SaveFormat) to the [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) method.

The examples that follow show how to save a presentation with Aspose.Slides for Java.

```java
// Instantiate a Presentation object that represents a PPT file
Presentation pres = new Presentation();
try {
    // ...do some work here...
    
    // Save your presentation to a file
    pres.save("demoPass.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```

## **Save Presentation to Stream**
It is possible to save a presentation to a stream by passing an output stream to the [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.io.OutputStream-int-) method. There are many types of streams to which a presentation can be saved. In the below example we have created a new Presentation file, add text in shape and Save the presentation to the stream.

```java
// Instantiate a Presentation object that represents a PPT file
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 200, 200);

    // Add text to shape
    shape.getTextFrame().setText("This demo shows how to Create PowerPoint file and save it to Stream.");

    OutputStream os = new FileOutputStream("Save_As_Stream_out.pptx");

    pres.save(os, com.aspose.slides.SaveFormat.Pptx);

    os.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Save Presentation with Predefined View Type**
Aspose.Slides for Java provides a facility to set the view type for the generated presentation when it is opened in PowerPoint through the [ViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties) class. The [**setLastView**](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#setLastView-int-) property is used to set the view type by using the [**ViewType**](https://reference.aspose.com/slides/java/com.aspose.slides/ViewType) enumerator.

```java
// Opening the presentation file
Presentation pres = new Presentation();
try {
    // Setting view type
    pres.getViewProperties().setLastView((byte) ViewType.SlideMasterView);
    
    // Saving presentation
    pres.save("newDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Saving Presentations to Strict Office Open XML Format**
Aspose.Slides allows you to save the presentation in Strict Office Open XML format. For that purpose, it provides the [**PptxOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/pptxoptions) class where you can set the Conformance property while saving the presentation file. If you set its value as [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/java/com.aspose.slides/Conformance#Iso29500_2008_Strict), then the output presentation file will be saved in Strict Open XML format.

The following sample code creates a presentation and saves it in the Strict Office Open XML format. While calling the [**Save**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) method for the presentation, the [**PptxOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/pptxoptions) object is passed into it with the Conformance property set as [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/java/com.aspose.slides/Conformance#Iso29500_2008_Strict).

```java
// Instantiate a Presentation object that represents a PPT file
Presentation pres = new Presentation();
try {
    // Get the first slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Add an autoshape of type line
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    //Set Strict Office Open XML Format save options
    PptxOptions options = new PptxOptions();
    options.setConformance(Conformance.Iso29500_2008_Strict);
    
    // Save your presentation to a file
    pres.save("demoPass.pptx", SaveFormat.Pptx, options);
} finally {
    if (pres != null) pres.dispose();
}

```

## **Saving Presentations to Office Open XML format in Zip64 mode**

An Office Open XML file is a ZIP-archive that has a 4 GB (2^32 bytes) limit on uncompressed size of a file, compressed size of a file, and total size of the archive, as well as a limit of 65,535 (2^16-1) files in the archive. ZIP64 format extensions increase the limits to 2^64.

The new [**IPptxOptions.Zip64Mode**](https://reference.aspose.com/slides/java/com.aspose.slides/zip64mode/) property allows you to choose when to use ZIP64 format extensions for the saved Office Open XML file.

This property provides the following modes:

- [Zip64Mode.IfNecessary](https://reference.aspose.com/slides/java/com.aspose.slides/zip64mode/#IfNecessary) means that ZIP64 format extensions will only be used if the presentation falls outside the above limitations. This is the default mode.
- [Zip64Mode.Never](https://reference.aspose.com/slides/java/com.aspose.slides/zip64mode/#Never) means that ZIP64 format extensions will not be used. 
- [Zip64Mode.Always](https://reference.aspose.com/slides/java/com.aspose.slides/zip64mode/#Always) means that ZIP64 format extensions will always be used.

The following code demonstrates how to save the presentation to PPTX format with ZIP64 format extensions:

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    PptxOptions pptxOptions = new PptxOptions();
    pptxOptions.setZip64Mode(Zip64Mode.Always);
    
    pres.save("Sample-zip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}

Saving in the Zip64Mode.Never mode will throw a [PptxException](https://reference.aspose.com/slides/java/com.aspose.slides/pptxexception/) if the presentation cannot be saved in ZIP32 format.

{{% /alert %}}

## **Save a Presentation without Refreshing the Thumbnail**

The [**IPptxOptions.setRefreshThumbnail**](https://reference.aspose.com/slides/java/com.aspose.slides/ipptxoptions/#setRefreshThumbnail-boolean-) method allows you to control the generation of the thumbnail when saving a presentation in PPTX format:

- When the value **true** is passed, the presentation thumbnail will be refreshed while saving. This is the *default* value.
- When the value **false** is passed, the current thumbnail will be saved as is. If the presentation doesn't have a thumbnail, no thumbnail will be generated.

In the code below, we saved the presentation to PPTX format without refreshing its thumbnail:

```java
Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions pptxOptions = new PptxOptions();
    pptxOptions.setRefreshThumbnail(false);

    presentation.save("Sample_with_old_thumbnail.pptx", SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

This option allows you to save time when saving a presentation in PPTX format.

{{% /alert %}}

## **Save Progress Updates in Percentage**
New [**IProgressCallback**](https://reference.aspose.com/slides/java/com.aspose.slides/IProgressCallback) interface has been added to [**ISaveOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/ISaveOptions) interface and [**SaveOptions** ](https://reference.aspose.com/slides/java/com.aspose.slides/SaveOptions)abstract class. [**IProgressCallback**](https://reference.aspose.com/slides/java/com.aspose.slides/IProgressCallback) interface represents a callback object for saving progress updates in percentage.  

The following code snippets below show how to use [IProgressCallback](https://reference.aspose.com/slides/java/com.aspose.slides/IProgressCallback) interface:

```java
// Opening the presentation file
Presentation pres = new Presentation("ConvertToPDF.pptx");
try {
    ISaveOptions saveOptions = new PdfOptions();
    saveOptions.setProgressCallback((IProgressCallback) new ExportProgressHandler());
    pres.save("ConvertToPDF.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    pres.dispose();
}
```
```java
class ExportProgressHandler implements IProgressCallback 
{
    public void reporting(double progressValue) 
	{
        // Use progress percentage value here
        int progress = Double.valueOf(progressValue).intValue();
        System.out.println(progress + "% file converted");
    }
}
```

{{% alert title="Info" color="info" %}}

Using its own API, Aspose developed a [free PowerPoint Splitter app](https://products.aspose.app/slides/splitter) that allows users to split their presentations into multiple files. Essentially, the app saves selected slides from a given presentation as new PowerPoint (PPTX or PPT) files. 

{{% /alert %}}