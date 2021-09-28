---
title: Convert PowerPoint to XPS 
type: docs
weight: 70
url: /net/convert-powerpoint-to-xps
keywords: "Convert PowerPoint Presentation, PowerPoint to XPS, PPT to XPS, PPTX to XPS, Conversion, C#, Csharp, .NET, Aspose.Slides"
description: "Convert PowerPoint presentation to XPS in C# or .NET."
---

## **About XPS**
Microsoft developed [XPS](https://docs.fileformat.com/page-description-language/xps/) as an alternative to [PDF](https://docs.fileformat.com/pdf/).  It allows you to print content by outputting a file very similar to a PDF. The XPS format is based on XML. The layout or structure of an XPS file remains the same on all operating systems and printers. 

## When to Use Microsoft XPS Format

{{% alert color="primary" %}} 

To see how Aspose.Slides converts PPT or PPTX presentation to the XPS format, you can check out [this free online converter app](https://products.aspose.app/slides/conversion). 

{{% /alert %}} 

If you want to cut down on storage costs, you can convert your Microsoft PowerPoint presentation to the XPS format. This way, you will find it easier to save, share, and print your documents. 

Microsoft continues to implement strong support for XPS in Windows (even in Windows 10), so you may want to consider saving files to this format. If you are dealing with Windows 8.1, Windows 8, Windows 7, and Windows Vista, then XPS might actually be your best option for certain operations. 

- **Windows 8** uses the OXPS (Open XPS) format for XPS files. OXPS is a standardized version of the original XPS format. Windows 8 provides better support for XPS files than it does for PDF files. 
  - **XPS:** Built-in XPS viewer/reader and printing to XPS feature available. 
  - **PDF**: PDF reader available but no printing to PDF feature. 

-  **Windows 7 and Windows Vista** use the original XPS format. These operating systems also provide better support for XPS files than they do for PDFs. 
  - **XPS**: Built-in XPS viewer and printing to XPS feature available. 
  - **PDF**: No PDF reader. No printing to PDF feature. 

|<p>**Input PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Output XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft eventually implemented support for printing operations in PDF through the Print to PDF feature in Windows 10. Previously, users were expected to print documents through the XPS format. 

## XPS Conversion with Aspose.Slides

In [**Aspose.Slides**](https://products.aspose.com/slides/net) for .NET, you can use the [**Save**](https://apireference.aspose.com/net/slides/aspose.slides/presentation/methods/save/index) method exposed by the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class to convert the entire presentation into an XPS document. 

When converting a presentation to XPS, you have to save the presentation using either of these settings:

- Default settings (without [**XPSOptions**](https://apireference.aspose.com/net/slides/aspose.slides.export/xpsoptions))
- Custom settings (with [**XPSOptions**](https://apireference.aspose.com/net/slides/aspose.slides.export/xpsoptions))

### **Converting Presentations to XPS Using Default Settings**

This sample code in C# shows you how to convert a presentation to an XPS document using standard settings:

```c#
// Instantiate a Presentation object that represents a presentation file
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // Saving the presentation to XPS document
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```


### **Converting Presentations to XPS Using Custom Settings**
This sample code shows you how to convert a presentation to an XPS document using custom settings in C#:

```c#
// Instantiate a Presentation object that represents a presentation file
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // Instantiate the TiffOptions class
    XpsOptions options = new XpsOptions();

    // Save MetaFiles as PNG
    options.SaveMetafilesAsPng = true;

    // Save the presentation to XPS document
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```

