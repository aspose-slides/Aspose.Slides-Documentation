---
title: Different File Formats and Conversions
type: docs
weight: 50
url: /cpp/different-file-formats-and-conversions/
---

## **Microsoft PowerPoint (PPT)**
### **About PPT**
[PPT](https://en.wikipedia.org/wiki/Microsoft_PowerPoint) is the presentation document file format that can be created, read, manipulated and written by different versions of Microsoft PowerPoint. This is the binary format for presentation documents developed by Microsoft.
### **PPT in Aspose.Slides for C++**
Aspose.Slides for C++ can read PPT files created by the software listed below.

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003

Similarly, PPT files created by Aspose.Slides for C++ can be read by the above set of software.
### **Comprehensive Support for PPT**
Aspose.Slides for C++ provides support for almost all the features related with PPT document file format. It not only covers the basic / advanced features provided by different Microsoft PowerPoint versions for PPT document manipulations, but also some features that are not even supported by Microsoft PowerPoint. The main advantage of using the Aspose.Slides for C++ API library is the ease of use for handling such features.

In addition to the basic tasks related to creating, reading and writing PPT document files, there are several features that are provided by Aspose.Slides for C++ like:

- Import other MS Office file formats as OLE Objects in PPT documents.
- Export PPT documents to PDF, TIFF, XPS formats.
- Export slides in the PPT documents to SVG formats.
- Render slide to any image format supported by C++ Framework.
- Set size of slides in the PPT document.
- Manage animations on shapes.
- Manage slide shows.
- Format text on slides.
- Scan text from the PPT documents.
- Handle tables on slides.
- Automatic copying of masters using cloning feature.

A PPT file generated by Aspose.Slides for C++ and opened in Microsoft PowerPoint
## **PresentationML (PPTX, XML)**
### **About PresentationML**
PresentationML is a name for a family of XML-based formats for presentation documents. Office OpenXML (OOXML) is the XML-based format introduced in Microsoft Office 2007 applications. Office OpenXML is a container format for several specialized XML-based markup languages. PresentationML is the markup language used by Microsoft Office PowerPoint 2007 to store its documents.
### **PresentationML in Aspose.Slides for C++**
OOXML PresentationML documents come as PPTX files which are zipped XML packages following the [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) specifications. Aspose.Slides for C++ extensively supports creating, reading, manipulating and writing PresentationML documents. In addition, Aspose.Slides for C++ is capable of exporting PresentationML documents to different widely used document formats like PDF, TIFF and XPS. This is possible because Aspose.Slides for C++ was designed with the aim to comprehensively handle presentation documents and PresentationML basically holds the internal presentation of documents as zipped XML package.

A PPTX document generated by Aspose.Slides for C++ and opened in Microsoft PowerPoint

Viewing PPTX document generated by Aspose.Slides for C++ in Zip Application
### **PresentationML is Open, Why Use Aspose.Slides for C++**
Since PresentationML is XML based, it is quite possible to build applications for processing and generating of PresentationML documents by using XML classes without relying on the third party class libraries such as Aspose.Slides for C++. However, there are several advantages of using Aspose.Slides for C++ over XML classes while working with PresentationML documents.

The OOXML specification is too long to several thousands of pages. It means, in order to properly handle the PresentationML documents, you will have to spend a lot of time and effort to understand the format of such documents. On the other hand, while using Aspose.Slides for C++, you simply have to use the relevant classes and their respective methods / properties for performing operations which seem quite complex if performed via XML classes.

The following are some of the features which are even unavailable when dealing with PresentationML documents through XML classes:

- Export PPT documents to PDF, TIFF, XPS formats
- Export slides in the PPT documents to SVG formats
- Render slide to any image format supported by C++ Framework
- Automatic copying of masters from source presentations using cloning feature
- Applying protection on shapes

Let us take an example of a PresentationML document having single slide with one text box containing “Hello World” text. In order to read the text through XML classes, you will have to write a program that can parse this simple text from the following fragment:

``` cpp

 <?xml version="1.0" encoding="UTF-8" standalone="yes"?>

<p:sld xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main" xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships" xmlns:p="http://schemas.openxmlformats.org/presentationml/2006/main">

  <p:cSld>

    <p:spTree>

      <p:nvGrpSpPr>

        <p:cNvPr id="1" name=""/>

        <p:cNvGrpSpPr/>

        <p:nvPr/>

      </p:nvGrpSpPr>

      <p:grpSpPr>

        <a:xfrm>

          <a:off x="0" y="0"/>

          <a:ext cx="0" cy="0"/>

          <a:chOff x="0" y="0"/>

          <a:chExt cx="0" cy="0"/>

        </a:xfrm></p:grpSpPr><p:sp>

          <p:nvSpPr><p:cNvPr id="4" name="TextBox 3"/>

          <p:cNvSpPr txBox="1"/>

            <p:nvPr/>

          </p:nvSpPr>

          <p:spPr>

            <a:xfrm>

              <a:off x="2819400" y="2590800"/>

              <a:ext cx="1297086" cy="369332"/>

            </a:xfrm>

            <a:prstGeom prst="rect">

              <a:avLst/>

            </a:prstGeom>

            <a:noFill/>

          </p:spPr>

          <p:txBody>

            <a:bodyPr wrap="none" rtlCol="0">

              <a:spAutoFit/>

            </a:bodyPr>

            <a:lstStyle/>

            <a:p>

              <a:r>

                <a:rPr lang="en-US"/>

                <a:t>Hello World

                </a:t>

              </a:r>

              <a:endParaRPr lang="en-US"/>

            </a:p>

          </p:txBody>

        </p:sp>

    </p:spTree>

  </p:cSld>

  <p:clrMapOvr>

    <a:masterClrMapping/>

  </p:clrMapOvr>

</p:sld>

```
## **PPT to PPTX conversion**
### **About Conversion**
Aspose.Slides now also support converting PPT to PPTX.
### **Features Supported in Conversion**
Aspose.Slides for C++ provides partial support for converting PPT document file format presentations to PPTX file format presentations. As the support for the mentioned presentation conversion feature has justbeen introduced in Aspose.Slides for C++, so at the moment it has got the limited capability and works only for the simple form of presentations. The main advantage that Aspose.Slides for C++ API library provides for converting PPT presentation to PPTX format presentation is the ease of using API in achieving the desired goal. Please proceed to this[link]() to code snippets section for further details.The following section clearly illustrates which of features are supported and unsupported while converting PPT format presentations to PPTX format presentations.
### **Supported Features**
Following features are supported during conversion:

- Conversion of structure of masters, layouts and slides
- Conversion of structure of masters, layouts and slides
- Conversion of Charts
- Group shapes
- Conversion of Auto-shapes including Rectangles and Ellipses. However, it is possible that Auto-shapes may have wrong adjustments values
- Shapes with custom geometry. Sometimes may not be converted
- Textures and Pictures fill style for Auto-shapes. Sometimes may not be converted
- Conversion of Placeholders
- Conversion of text in text frames and text holders. However, bullets, alignment and tabulations are not fully implemented
### **Unsupported Features**
Following features are not supported during conversion:

- Slide with notes as reading Notes is not implemented in PPTX. In case PPT has it then it can't be saved as PPTX yet* Conversion of Lines and Polylines
- Line and fill formats
- Gradient fill styles
- OLE frames, Tables, Video and Audio frames etc
- Animation and other slideshow properties are skipped
  New or missing features will be added subsequently in the upcoming releases of Aspose.Slides for C++.

Source PPT Presentation

Converted PPTX presentation
## **Portable Document Format (PDF)**
### **About PDF**
The [Portable Document Format](https://en.wikipedia.org/wiki/PDF) is a file format that was created by Adobe System for exchange of documents between different organizations. The purpose of this format was to make it possible that contents of the documents may be represented in such a way that their visual appearance is not dependent of the platform on which it is being viewed.
### **PDF in Aspose.Slides for C++**
Any presentation document that can be loaded into Aspose.Slides for C++ can be converted to PDF document which may conform to [PDF 1.5](https://en.wikipedia.org/wiki/PDF/A) or [PDF /A-1b](https://en.wikipedia.org/wiki/PDF/A) depending upon your choice. Aspose.Slides for C++ exports the presentation documents to PDF in such a way that most of the time, the exported PDF document look almost similar to the original presentation document. The Aspose solution supports the following features of the presentation documents while converting to PDF documents:

- Images, Text Boxes and other Shapes
- Text and Formatting
- Paragraphs and Formatting
- Hyperlinks
- Headers and Footers
- Bullets
- Tables

You can export the presentation documents to PDF documents directly using Aspose.Slides for C++ component only. That is, you do not need any other third party or Aspose.Pdf component for this purpose. Further, you can customize the presentation to PDF export with different options as explained in [this topic](/slides/cpp/converting-presentation-to-pdf/).

A Presentation Document Converted to PDF Document through Aspose.Slides for C++
## **XML Parser Specification (XPS)**
### **About XPS**
The [XML Parser Specification](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification) is a page description language and a fixed-document format originally developed by Microsoft. Like PDF, XPS is a fixed-layout document format designed to preserve document fidelity and provide device-independent document appearance.
### **XPS in Aspose.Slides for C++**
Any presentation document that can be loaded by Aspose.Slides for C++ can be converted to XPS format. Aspose.Slides for C++ uses the high-fidelity page layout and rendering engine to produce output in fixed-layout XPS document format. It is worth-mentioning that Aspose.Slides for C++ directly generates XPS without depending upon the Windows Presentation Foundation (WPF) classes that are packaged with C++ Framework 3.5 hence allowing Aspose.Slides for C++ to produce XPS documents on machines running C++ Framework versions earlier than version 3.5. You can learn about exporting the presentation documents to XPS documents through Aspose.Slides for C++ in [this topic](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/).

A Presentation Document Converted to XPS Document through Aspose.Slides for C++

