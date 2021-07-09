---
title: Convert PowerPoint PPT and PPTX to Microsoft XPS Document
type: docs
weight: 70
url: /cpp/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/
keywords: "PPT, PPTX to XPS"
description: "Convert PowerPoint PPT, PPTX to XPS document with Aspose.Slides API."
---



## **About PowerPoint to XPS Conversion**
Convert PowerPoint presentations to [XPS ](https://wiki.fileformat.com/page-description-language/xps)format if you need to minimize the costs on their storing and transmitting. XPS is an electronic document format based on XML, which can help to represent any document and information in a structured and hierarchical way. After converting your presentations to XPS format, you can operate them in a unified way together with other document formats converted to XPS. Create, share, print and save converted to XPS digital documents. XPS is an alternative to PDF format, when you need various document formats and files to be opened on different devices or operational systems without destroying the file layouts. XPS is also called a page layout file format, highlighting the key feature of this format - to save the layout of the document.



{{% alert color="primary" %}} 

To see how Aspose.Slides API converts PPT/PPTX to XPS, you may try [**Aspose.Slides Converter** ](https://products.aspose.app/slides/conversion)online free app.

{{% /alert %}} 

In [**Aspose.Slides for C++**](https://products.aspose.com/slides/cpp) the [**Save**](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) method exposed by [Presentation](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation) class can be used to convert the whole presentation into XPS document. There are two ways to convert PPT(X) to XPS, with: default settings and custom settings. To convert PPT(X) to XPS with custom settings, an instance of [**XPSOptions**](https://apireference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options) is passed to [Save](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) method.



|<p>**Input PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Output XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |


## **Convert PowerPoint to XPS without XpsOptions**
The following example shows how to convert a presentation into XPS document without using options provided by [XPSOptions](https://apireference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options).

``` cpp
// The path to the documents directory.
String dataDir = GetDataPath();

// Instantiate a Presentation object that represents a presentation file
auto pres = MakeObject<Presentation>(dataDir + u"Convert_XPS.pptx");

// Saving the presentation to XPS document
pres->Save(dataDir + u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```


## **Convert PowerPoint to XPS with XpsOptions**
The following example shows how to convert a presentation into XPS document using options provided by [XPSOptions](https://apireference.aspose.com/slides/cpp/class/aspose.slides.export.xps_options).

``` cpp
// The path to the documents directory.
String dataDir = GetDataPath();

// Instantiate a Presentation object that represents a presentation file
auto pres = MakeObject<Presentation>(dataDir + u"Convert_XPS_Options.pptx");

// Instantiate the TiffOptions class
auto opts = MakeObject<XpsOptions>();

// Save MetaFiles as PNG
opts->set_SaveMetafilesAsPng(true);

// Save the presentation to XPS document
pres->Save(dataDir + u"XPS_With_Options_out.xps", SaveFormat::Xps, opts);
```
