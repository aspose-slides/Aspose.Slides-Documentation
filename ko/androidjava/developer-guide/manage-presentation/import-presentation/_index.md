---
title: PDF 또는 HTML을 Android에서 프레젠테이션으로 가져오기
linktitle: 프레젠테이션 가져오기
type: docs
weight: 60
url: /ko/androidjava/import-presentation/
keywords:
- 프레젠테이션 가져오기
- 슬라이드 가져오기
- PDF 가져오기
- HTML 가져오기
- PDF를 프레젠테이션으로
- PDF를 PPT로
- PDF를 PPTX로
- PDF를 ODP로
- HTML을 프레젠테이션으로
- HTML을 PPT로
- HTML을 PPTX로
- HTML을 ODP로
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Java와 Aspose.Slides for Android를 사용하여 PDF 및 HTML 문서를 PowerPoint 및 OpenDocument 프레젠테이션으로 원활하고 고성능 슬라이드 처리와 함께 가져옵니다."
---
## **소개**

Using [**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/ko/androidjava/), you can import presentations from files in other formats. Aspose.Slides provides the [SlideCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slidecollection/) class to allow you to import presentations from PDFs, HTML documents, etc.

## **PDF에서 PowerPoint 가져오기**

In this case, you get to convert a PDF to a PowerPoint presentation.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/) class.
2. Call the [addFromPdf()](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) method and pass the PDF file.
3. Use the [save()](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) method to save the file in the PowerPoint format.

This Java code demonstrates the PDF to PowerPoint operation:

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
**Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/ko/import/pdf-to-powerpoint) 웹 앱을 확인해 보세요. 이 앱은 여기서 설명한 프로세스의 실시간 구현입니다. 
{{% /alert %}} 

## **HTML에서 PowerPoint 가져오기**

In this case, you get to convert a HTML document to a PowerPoint presentation.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/) class.
2. Call the [addFromHtml()](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) method and pass the HTML file.
3. Use the [save()](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) method to save the file in the PowerPoint format.

This Java code demonstrates the HTML to PowerPoint operation: 

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

**Are tables preserved when importing a PDF, and can their detection be improved?**

Tables can be detected during import; [PdfImportOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/pdfimportoptions/) includes a [setDetectTables](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) method that enables table recognition. The effectiveness depends on the PDF’s structure.