---
title: Why Not Open XML SDK
type: docs
weight: 120
url: /java/why-not-open-xml-sdk/
---

{{% alert color="primary" %}} 

We sometimes hear this question:

**Why should we use Aspose products rather than the free Open XML SDK?**

This question is easy to answer: **features and functionality**.

{{% /alert %}} 
## **What is Open XML SDK?**
According to the [MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK is defined as: 

The Open XML SDK 2.0 simplifies the task of manipulating Open XML packages and the underlying Open XML schema elements within a package. The Open XML SDK 2.0 encapsulates many common tasks that developers perform on Open 

XML packages, so that you can perform complex operations with just a few lines of code.

OOXML documents are essentially zipped XML files and Open XML SDK is a collection of classes that allows you to work with the content of OOXML documents in a strongly-typed way. That is instead of unzipping a file to 

extract XML, loading that XML into a DOM tree and working with XML elements and attributes directly, Open XML SDK provides classes to do that.
## **What is Aspose.Slides?**
Aspose.Slides is a class library that allows your application to perform the following presentation processing tasks:

- Programming with a **Presentation** object model.
- High Quality conversions among all popular supported PowerPoint presentation formats, including conversion to PDF, XPS and TIFF.
- Ability to gnereate slide thumbnails in well known formats like, PNG, JPEG and BMP along with slide export to SVG.
- Ability to build presentations from scratch or by combining from one or multiple documents.
- Support for adding animations, Ole Frames, Tables, creating and managing charts.
- Availability of extensive control for Managing the text formatting on TextFrames, Paragraphs and Portions levels.

For more details about the features supported, please visit [Aspose.Slides Features](/slides/java/product-overview/).
## **Compare Open XML SDK and Aspose.Slides**
{{% alert color="primary" %}} 

The following table compares Open XML SDK and Aspose.Slides features.

{{% /alert %}} 

|**Feature or Feature Category**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Supported Presentations formats|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversion from PPT to PPTX |No|Yes|
|<p>High-level programming with a Presentation Document Object Model (DOM):</p><p>- Find and replace text.</p><p>- Assemble slides in presentations.</p>|No|Yes|
|Detailed programming with a document object model, access to individual elements and formatting such as TextHolders, TextFrames, Paragraphs and Portions.|Yes|Yes|
|Low-level direct and full access to the underlying XML elements and attributes such as relationship identifiers, list identifiers of an OOXML document.|Yes|No|
|<p>Rendering:</p><p>- Render presentations to PDF, PDF Notes, XPS, TIFF images.</p><p>- Render slide thumbnails to PNG, JPEG, BMP, SVG and TIFF.</p><p>- Specify image resolution, quality, compression and other options. </p>|No|Yes |
|Supported platforms|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|
## **Conclusion**
{{% alert color="primary" %}} 

Open XML SDK and Aspose.Slides do not compete head to head because they address quite different needs and audiences. Open XML SDK is a class library to provide a strong-typed way to work with OOXML documents. Aspose.Slides is a very useful presentations processing library that provides great support for nearly all Microsoft PowerPoint file formats.

If all you need to do is a fairly basic programming operation on a PPTX document, then Open XML SDK might be a suitable choice. With Open XML SDK you will be fairly comfortable doing simple tasks like generating a simple PPTX document or removing comments, headers/footers, extracting images or others. Some tasks can be achieved with Open XML SDK, but cannot be achieved with Aspose.Slides. For example, if you need to directly access the XML elements and attributes of an OOXML document, then you should use Open XML SDK. However, if you need to perform complex operations on documents, such as some of the following tasks, then using Aspose.Slides is your best option:

- Support older PowerPoint formats in addition to PPTX.
- Copy or clone shapes with in slides in a way that combines objects, styles and other formatting in an appropriate manner.
- Replace formatted or unformatted text.
- Applying Animations and use of connectors with shapes used.
- Convert a document to PDF, TIFF or XPS so it appears exactly like Microsoft PowerPoint would have converted it.
- Develop a .NET or Java application in both desktop and web based environments.

{{% /alert %}}
