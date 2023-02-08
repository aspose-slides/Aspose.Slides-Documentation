---
title: Import Presentation - C++ PowerPoint API
linktitle: Import Presentation
type: docs
weight: 60
url: /cpp/import-presentation/
keywords: "Import PowerPoint, PDF to Presentation, PDF to PPTX, PDF to PPT, C++, Aspose.Slides for C++"
description: "Import PowerPoint presentation from PDF. Convert PDF to PowerPoint"
---

Using [**Aspose.Slides for C++**](https://products.aspose.com/slides/cpp/), you can import presentations from files in other formats. Aspose.Slides provides the [SlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection) class to allow you to import presentations from PDF, HTML documents, etc.

## **Import PowerPoint from PDF**

In this case, you get to convert a PDF to a PowerPoint presentation.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Instantiate an object of the presentation class. 
2. Call the [AddFromPdf()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) method and pass the PDF file. 
3. Use the [Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) method to save the file in the PowerPoint format.

This C++ code demonstrates the PDF to PowerPoint operation:

```cpp
auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```

{{% alert  title="Tip" color="primary" %}} 

You may want to check out **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) web app because it is a live implementation of the process described here. 

{{% /alert %}} 

## **Import PowerPoint from HTML**

In this case, you get to convert a HTML document to a PowerPoint presentation.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) class. 
2. Call the [AddFromHtml()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) method and pass the HTML file. 
3. Use the [Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) method to save the file in the PowerPoint format.

This C++ code demonstrates the HTML to PowerPoint operation:

```c++
auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 

You may also use Aspose.Slides to convert HTML to other popular file formats: 

* [HTML to image](https://products.aspose.com/slides/cpp/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/cpp/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/cpp/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/cpp/conversion/html-to-tiff/)

{{% /alert %}}
