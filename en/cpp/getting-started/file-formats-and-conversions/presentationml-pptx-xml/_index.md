---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /cpp/presentationml-pptx-xml/
---

## **About PresentationML**
PresentationML is a name for a family of XML-based formats for presentation documents. Office OpenXML (OOXML) is the XML-based format introduced in Microsoft Office 2007 applications. Office OpenXML is a container format for several specialized XML-based markup languages. PresentationML is the markup language used by Microsoft Office PowerPoint 2007 to store its documents. 
## **PresentationML in Aspose.Slides for C++**
OOXML PresentationML documents come as PPTX files which are zipped XML packages following the [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) specifications. Aspose.Slides for C++ extensively supports creating, reading, manipulating and writing PresentationML documents. In addition, Aspose.Slides for C++ is capable of exporting PresentationML documents to different widely used document formats like PDF, TIFF and XPS. This is possible because Aspose.Slides for C++ was designed with the aim to comprehensively handle presentation documents and PresentationML basically holds the internal presentation of documents as zipped XML package. 

## **PresentationML is Open, Why Use Aspose.Slides for C++**
Since PresentationML is XML based, it is quite possible to build applications for processing and generating of PresentationML documents by using XML classes without relying on the third party class libraries such as Aspose.Slides for C++. However, there are several advantages of using Aspose.Slides for C++ over XML classes while working with PresentationML documents. 

The OOXML specification is too long to several thousands of pages. It means, in order to properly handle the PresentationML documents, you will have to spend a lot of time and effort to understand the format of such documents. On the other hand, while using Aspose.Slides for C++, you simply have to use the relevant classes and their respective methods / properties for performing operations which seem quite complex if performed via XML classes. 

The following are some of the features which are even unavailable when dealing with PresentationML documents through XML classes: 

- Export PPT documents to PDF, TIFF, XPS formats
- Export slides in the PPT documents to SVG formats
- Render slide to any image format supported by C++ Framework
- Automatic copying of masters from source presentations using cloning feature
- Applying protection on shapes

Let us take an example of a PresentationML document having single slide with one text box containing “Hello World” text. In order to read the text through XML classes, you will have to write a program that can parse this simple text from the following fragment: 
## **Example**


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


