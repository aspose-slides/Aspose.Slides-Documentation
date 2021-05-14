---
title: Convert PowerPoint PPT(X) to XPS
type: docs
weight: 70
url: /java/convert-powerpoint-ppt-and-pptx-to-xps/
keywords: "PPT, PPTX to XPS"
description: "Convert PowerPoint PPT(X) to XPS in Java"
---

## **About PowerPoint to XPS Conversion**
Convert PowerPoint presentations to [XPS](https://wiki.fileformat.com/page-description-language/xps) format if you need to minimize the costs on their storing and transmitting. XPS is an electronic document format based on XML, which can help to represent any document and information in a structured and hierarchical way. After converting your presentations to XPS format, you can operate them in a unified way together with other document formats converted to XPS. Create, share, print and save converted to XPS digital documents. XPS is an alternative to PDF format, when you need various document formats and files to be opened on different devices or operational systems without destroying the file layouts. XPS is also called a page layout file format, highlighting the key feature of this format - to save the layout of the document.

{{% alert color="primary" %}} 

To see how Aspose.Slides API converts PPT/PPTX to XPS, you may try [**Aspose.Slides Converter** ](https://products.aspose.app/slides/conversion)online free app.

{{% /alert %}} 

In [**Aspose.Slides**](https://products.aspose.com/slides/java) the [**Save**](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) method exposed by [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) class can be used to convert the whole presentation into XPS document. There are two ways to convert PPT(X) to XPS, with: default settings and custom settings. To convert PPT(X) to XPS with custom settings, an instance of [**XPSOptions**](https://apireference.aspose.com/slides/java/com.aspose.slides/XpsOptions) is passed to [Save](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) method.

## **Convert PPT(X) to XPS without XpsOptions**
The following example shows how to convert a presentation into XPS document without using options provided by [XpsOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/xpsoptions) class.

```java
// Instantiate a Presentation object that represents a presentation file
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // Saving the presentation to XPS document
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convert PPT(X) to XPS with XpsOptions**
The following example shows how to convert a presentation into XPS document using options provided by [XpsOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/xpsoptions) class.

```java
// Instantiate a Presentation object that represents a presentation file
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // Instantiate the TiffOptions class
    XpsOptions opts = new XpsOptions();

    // Save MetaFiles as PNG
    opts.setSaveMetafilesAsPng(true);

    // Save the presentation to XPS document
    pres.save("XPS_With_Options.xps", SaveFormat.Xps, opts);
} finally {
    if (pres != null) pres.dispose();
}
```