---
title: Convert PowerPoint to XPS
type: docs
weight: 70
url: /nodejs-java/convert-powerpoint-to-xps/
keywords: "PPT, PPTX to XPS"
description: "Convert PowerPoint PPT(X) to XPS in JavaScript"
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

|<p>**nput PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Output XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft eventually implemented support for printing operations in PDF through the Print to PDF feature in Windows 10. Previously, users were expected to print documents through the XPS format. 

## XPS Conversion with Aspose.Slides

In [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/), you can use the [**save**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) method exposed by the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class to convert the entire presentation into an XPS document.

When converting a presentation to XPS, you have to save the presentation using either of these settings:

- Default settings (without [**XPSOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions))
- Custom settings (with [**XPSOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xpsoptions))

### **Converting Presentations to XPS Using Default Settings**

This sample code in JavaScript shows you how to convert a presentation to an XPS document using standard settings:

```javascript
// Instantiate a Presentation object that represents a presentation file
var pres = new aspose.slides.Presentation("Convert_XPS.pptx");
try {
    // Saving the presentation to XPS document
    pres.save("XPS_Output_Without_XPSOption.xps", aspose.slides.SaveFormat.Xps);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **Converting Presentations to XPS Using Custom Settings**
This sample code shows you how to convert a presentation to an XPS document using custom settings in JavaScript:

```javascript
// Instantiate a Presentation object that represents a presentation file
var pres = new aspose.slides.Presentation("Convert_XPS_Options.pptx");
try {
    // Instantiate the TiffOptions class
    var options = new aspose.slides.XpsOptions();
    // Save MetaFiles as PNG
    options.setSaveMetafilesAsPng(true);
    // Save the presentation to XPS document
    pres.save("XPS_Output_With_Options.xps", aspose.slides.SaveFormat.Xps, options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
