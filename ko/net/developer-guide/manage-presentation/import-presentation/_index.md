---
title: PDF 또는 HTML에서 .NET으로 프레젠테이션 가져오기
linktitle: 프레젠테이션 가져오기
type: docs
weight: 60
url: /ko/net/import-presentation/
keywords:
- 프레젠테이션 가져오기
- 슬라이드 가져오기
- PDF 가져오기
- HTML 가져오기
- PDF에서 프레젠테이션으로
- PDF에서 PPT로
- PDF에서 PPTX로
- PDF에서 ODP로
- HTML에서 프레젠테이션으로
- HTML에서 PPT로
- HTML에서 PPTX로
- HTML에서 ODP로
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: ".NET에서 Aspose.Slides를 사용하여 PDF 및 HTML 문서를 PowerPoint 및 OpenDocument 프레젠테이션으로 손쉽게 가져와 원활하고 고성능 슬라이드 처리를 실현합니다."
---
## **소개**

Aspose.Slides를 사용하면 다른 형식 파일에서 프레젠테이션을 가져올 수 있습니다. Aspose.Slides는 PDF 및 HTML 문서에서 프레젠테이션을 가져올 수 있는 [SlideCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/slidecollection/) 클래스를 제공합니다.

## **PDF에서 PowerPoint 가져오기**

이 경우 PDF를 PowerPoint 프레젠테이션으로 변환합니다.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Presentation 클래스의 인스턴스를 생성합니다. 
2. [AddFromPdf](https://reference.aspose.com/slides/ko/net/aspose.slides.slidecollection/addfrompdf/methods/1) 메서드를 호출하고 PDF 파일을 전달합니다. 
3. [Save](https://reference.aspose.com/slides/ko/net/aspose.slides.presentation/save/methods/5) 메서드를 사용하여 파일을 PowerPoint 형식으로 저장합니다.

This C# code demonstrates the PDF to PowerPoint operation:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert  title="TIP" color="info" %}} 

여기서 설명한 프로세스의 실시간 구현이므로 **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/ko/import/pdf-to-powerpoint) 웹 앱을 확인해 볼 수 있습니다. 

{{% /alert %}} 

## **HTML에서 PowerPoint 가져오기**

이 경우 HTML 문서를 PowerPoint 프레젠테이션으로 변환합니다.

1. Presentation 클래스의 인스턴스를 생성합니다. 
2. [AddFromHtml](https://reference.aspose.com/slides/ko/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) 메서드를 호출하고 HTML 파일을 전달합니다. 
3. [Save](https://apireference.aspose.com/slides/ko/net/aspose.slides.presentation/save/methods/5) 메서드를 사용하여 파일을 PowerPoint 문서로 저장합니다.

This C# code demonstrates the HTML to PowerPoint operation: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    using (var htmlStream = File.OpenRead("page.html"))
    {
        presentation.Slides.AddFromHtml(htmlStream);
    }

    presentation.Save("MyPresentation.pptx", SaveFormat.Pptx);
}
```

## **자주 묻는 질문**

### PDF를 가져올 때 테이블이 보존되며, 테이블 감지를 개선할 수 있나요?

테이블은 가져오는 동안 감지될 수 있으며, [PdfImportOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.import/pdfimportoptions/)에는 테이블 인식을 활성화하는 [DetectTables](https://reference.aspose.com/slides/ko/net/aspose.slides.import/pdfimportoptions/detecttables/) 매개변수가 포함되어 있습니다. 효과는 PDF의 구조에 따라 달라집니다.

{{% alert title="Note" color="warning" %}} 

Aspose.Slides를 사용하여 HTML을 다른 인기 파일 형식으로 변환할 수도 있습니다: 

* [HTML을 이미지로 변환](https://products.aspose.com/slides/ko/net/conversion/html-to-image/)
* [HTML을 JPG로 변환](https://products.aspose.com/slides/ko/net/conversion/html-to-jpg/)
* [HTML을 XML로 변환](https://products.aspose.com/slides/ko/net/conversion/html-to-xml/)
* [HTML을 TIFF로 변환](https://products.aspose.com/slides/ko/net/conversion/html-to-tiff/)

{{% /alert %}}