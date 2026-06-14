---
title: 在 Android 上從 PDF 或 HTML 匯入簡報
linktitle: 匯入簡報
type: docs
weight: 60
url: /zh-hant/androidjava/import-presentation/
keywords:
- 匯入簡報
- 匯入投影片
- 匯入 PDF
- 匯入 HTML
- PDF 轉簡報
- PDF 轉 PPT
- PDF 轉 PPTX
- PDF 轉 ODP
- HTML 轉簡報
- HTML 轉 PPT
- HTML 轉 PPTX
- HTML 轉 ODP
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android，在 Java 中將 PDF 與 HTML 文件匯入為 PowerPoint 與 OpenDocument 簡報，實現無縫且高效能的投影片處理。"
---
## **簡介**

使用 [**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/zh-hant/androidjava/)，您可以從其他格式的檔案匯入簡報。Aspose.Slides 提供了 [SlideCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slidecollection/) 類別，允許您從 PDF、HTML 文件等匯入簡報。

## **從 PDF 匯入 PowerPoint**

在此情況下，您可以將 PDF 轉換為 PowerPoint 簡報。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;"/>

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/) 類別的實例。
2. 呼叫 [addFromPdf()](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) 方法，並傳入 PDF 檔案。
3. 使用 [save()](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) 方法，以 PowerPoint 格式儲存檔案。

以下 Java 程式碼示範 PDF 轉 PowerPoint 的操作：

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
您可能想查看 **Aspose free** [PDF 轉 PowerPoint](https://products.aspose.app/slides/zh-hant/import/pdf-to-powerpoint) 網頁應用程式，因為它提供了此處描述流程的即時實作。 
{{% /alert %}} 

## **從 HTML 匯入 PowerPoint**

在此情況下，您可以將 HTML 文件轉換為 PowerPoint 簡報。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/) 類別的實例。
2. 呼叫 [addFromHtml()](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) 方法，並傳入 HTML 檔案。
3. 使用 [save()](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) 方法，以 PowerPoint 格式儲存檔案。

以下 Java 程式碼示範 HTML 轉 PowerPoint 的操作： 

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

## **常見問題**

**在匯入 PDF 時，表格會被保留嗎？是否可以改進表格偵測？**

匯入過程中可以偵測到表格；[PdfImportOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pdfimportoptions/) 包含一個 [setDetectTables](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) 方法，可啟用表格識別。其效能取決於 PDF 的結構。