---
title: "Java에서 PDF 또는 HTML로 프레젠테이션 가져오기"
linktitle: "프레젠테이션 가져오기"
type: docs
weight: 60
url: /ko/java/import-presentation/
keywords:
- "프레젠테이션 가져오기"
- "슬라이드 가져오기"
- "PDF 가져오기"
- "HTML 가져오기"
- "PDF를 프레젠테이션으로"
- "PDF를 PPT로"
- "PDF를 PPTX로"
- "PDF를 ODP로"
- "HTML을 프레젠테이션으로"
- "HTML을 PPT로"
- "HTML을 PPTX로"
- "HTML을 ODP로"
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Java에서 PDF 및 HTML 문서를 PowerPoint 및 OpenDocument 프레젠테이션으로 손쉽게 가져와 원활하고 고성능 슬라이드 처리를 제공합니다."
---
## **소개**

Aspose.Slides를 사용하면 다른 형식의 파일에서 프레젠테이션을 가져올 수 있습니다. Aspose.Slides는 PDF 및 HTML 문서에서 프레젠테이션을 가져올 수 있는 [SlideCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/slidecollection/) 클래스를 제공합니다.

## **PDF에서 PowerPoint 가져오기**

이 경우 PDF를 PowerPoint 프레젠테이션으로 변환할 수 있습니다.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Presentation 클래스의 인스턴스를 생성합니다. 
2. [addFromPdf()](https://reference.aspose.com/slides/ko/java/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) 메서드를 호출하고 PDF 파일을 전달합니다. 
3. [save()](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation#save-java.lang.String-int-) 메서드를 사용하여 파일을 PowerPoint 형식으로 저장합니다.

다음 Java 코드는 PDF를 PowerPoint로 변환하는 작업을 보여줍니다:

```java
Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert  title="Tip" color="primary" %}} 
여기에서 설명한 프로세스를 실시간으로 구현한 **Aspose 무료** [PDF to PowerPoint](https://products.aspose.app/slides/ko/import/pdf-to-powerpoint) 웹 앱을 확인해 보세요. 
{{% /alert %}} 

## **HTML에서 PowerPoint 가져오기**

이 경우 HTML 문서를 PowerPoint 프레젠테이션으로 변환할 수 있습니다.

1. Presentation 클래스의 인스턴스를 생성합니다. 
2. [addFromHtml()](https://reference.aspose.com/slides/ko/java/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) 메서드를 호출하고 HTML 파일을 전달합니다. 
3. [save()](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation#save-java.lang.String-int-) 메서드를 사용하여 파일을 PowerPoint 형식으로 저장합니다.

다음 Java 코드는 HTML을 PowerPoint로 변환하는 작업을 보여줍니다: 

```java
Presentation presentation = new Presentation();
try {
    FileInputStream htmlStream = new FileInputStream("page.html");
    try {
        presentation.getSlides().addFromHtml(htmlStream);
    } finally {
        if (htmlStream != null) htmlStream.close();
    }

    presentation.save("MyPresentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**PDF를 가져올 때 표가 보존되며, 표 감지를 개선할 수 있나요?**

표는 가져오기 중에 감지될 수 있으며, [PdfImportOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/pdfimportoptions/)에는 표 인식을 활성화하는 [setDetectTables](https://reference.aspose.com/slides/ko/java/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) 메서드가 포함되어 있습니다. 효과는 PDF 구조에 따라 달라집니다.

{{% alert title="Note" color="warning" %}} 

Aspose.Slides를 사용하여 HTML을 다른 인기 파일 형식으로 변환할 수도 있습니다: 

* [HTML을 이미지로](https://products.aspose.com/slides/ko/java/conversion/html-to-image/)
* [HTML을 JPG로](https://products.aspose.com/slides/ko/java/conversion/html-to-jpg/)
* [HTML을 XML로](https://products.aspose.com/slides/ko/java/conversion/html-to-xml/)
* [HTML을 TIFF로](https://products.aspose.com/slides/ko/java/conversion/html-to-tiff/)

{{% /alert %}}