---
title: 导入演示文稿
type: docs
weight: 60
url: /zh/nodejs-java/import-presentation/
keywords: "导入 PowerPoint, PDF 转演示文稿, PDF 转 PPTX, PDF 转 PPT, Java, Aspose.Slides for Node.js via Java"
description: "从 PDF 导入 PowerPoint 演示文稿。将 PDF 转换为 PowerPoint"
---

使用[**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/)，您可以从其他格式的文件导入演示文稿。Aspose.Slides 提供了 [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) 类，以允许您从 PDF、HTML 文档等导入演示文稿。

## **从 PDF 导入 PowerPoint**

在这种情况下，您可以将 PDF 转换为 PowerPoint 演示文稿。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/) 类的实例。
2. 调用 [addFromPdf()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) 方法并传入 PDF 文件。
3. 使用 [save()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) 方法将文件保存为 PowerPoint 格式。

此 JavaScript 代码演示了 PDF 转 PowerPoint 的操作：
```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert  title="Tip" color="primary" %}} 
您可能想查看 **Aspose 免费** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) 网络应用，因为它是此处描述过程的实时实现。 
{{% /alert %}} 

## **从 HTML 导入 PowerPoint**

在这种情况下，您可以将 HTML 文档转换为 PowerPoint 演示文稿。

1. 创建 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/) 类的实例。
2. 调用 [addFromHtml()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) 方法并传入 HTML 文件。
3. 使用 [save()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) 方法将文件保存为 PowerPoint 格式。

此 JavaScript 代码演示了 HTML 转 PowerPoint 的操作：
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var htmlStream = java.newInstanceSync("java.io.FileInputStream", "page.html");
    try {
        presentation.getSlides().addFromHtml(htmlStream);
    } finally {
        if (htmlStream != null) {
            htmlStream.close();
        }
    }
    presentation.save("MyPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {
    console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **常见问题**

**在导入 PDF 时表格会被保留吗？是否可以改进其检测？**

在导入过程中可以检测到表格；[PdfImportOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfimportoptions/) 包含一个 [setDetectTables](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfimportoptions/#setDetectTables) 方法，可启用表格识别。其有效性取决于 PDF 的结构。

{{% alert title="Note" color="warning" %}} 
您还可以使用 Aspose.Slides 将 HTML 转换为其他常用文件格式：

* [HTML 转图片](https://products.aspose.com/slides/nodejs-java/conversion/html-to-image/)
* [HTML 转 JPG](https://products.aspose.com/slides/nodejs-java/conversion/html-to-jpg/)
* [HTML 转 XML](https://products.aspose.com/slides/nodejs-java/conversion/html-to-xml/)
* [HTML 转 TIFF](https://products.aspose.com/slides/nodejs-java/conversion/html-to-tiff/)

{{% /alert %}}