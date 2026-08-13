---
title: 导入 PDF 或 HTML 演示文稿到 Android
linktitle: 导入演示文稿
type: docs
weight: 60
url: /zh/androidjava/import-presentation/
keywords:
- 导入演示文稿
- 导入幻灯片
- 导入 PDF
- 导入 HTML
- PDF 转 演示文稿
- PDF 转 PPT
- PDF 转 PPTX
- PDF 转 ODP
- HTML 转 演示文稿
- HTML 转 PPT
- HTML 转 PPTX
- HTML 转 ODP
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "在 Java 中使用 Aspose.Slides for Android，将 PDF 和 HTML 文档导入到 PowerPoint 和 OpenDocument 演示文稿，实现无缝高性能的幻灯片处理。"
---
## **简介**

使用[**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/zh/androidjava/)，您可以从其他格式的文件导入演示文稿。Aspose.Slides 提供了[SlideCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/slidecollection/)类，以便您从 PDF、HTML 文档等导入演示文稿。

## **从 PDF 导入 PowerPoint**

在本例中，您将 PDF 转换为 PowerPoint 演示文稿。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/) 类的实例。
2. 调用 [addFromPdf()](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) 方法并传入 PDF 文件。
3. 使用 [save()](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) 方法将文件保存为 PowerPoint 格式。

下面的 Java 代码演示了 PDF 转 PowerPoint 的操作：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert  title="Tip" color="info" %}} 

您可以尝试 Aspose 免费的 [PDF to PowerPoint](https://products.aspose.app/slides/zh/import/pdf-to-powerpoint) 网络应用，它实现了本文所述的过程。 

{{% /alert %}} 

## **从 HTML 导入 PowerPoint**

在本例中，您将 HTML 文档转换为 PowerPoint 演示文稿。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/) 类的实例。
2. 调用 [addFromHtml()](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) 方法并传入包含 HTML 文档的流。
3. 使用 [save()](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) 方法将文件保存为 PowerPoint 格式。

下面的 Java 代码演示了 HTML 转 PowerPoint 的操作： 

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.IOException;

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

## **常见问题**

### 在导入 PDF 时表格是否会被保留，能否改进其检测？

在导入过程中可以检测表格；[PdfImportOptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/pdfimportoptions/) 包含 [setDetectTables](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) 方法，可启用表格识别。其效果取决于 PDF 的结构。