---
title: 将 PowerPoint 转换为 PDF 备注
type: docs
weight: 50
url: /zh/androidjava/convert-powerpoint-to-pdf-with-notes/
keywords: "在 java 中将 powerpoint 转换为带备注的 pdf"
description: "在 Java 中将 PowerPoint 转换为带备注的 PDF"
---

## **使用自定义幻灯片大小将 PowerPoint 转换为 PDF**
以下示例演示如何将演示文稿转换为带自定义幻灯片大小的 PDF 备注文档。每英寸等于 72。

```java
// 实例化表示演示文稿文件的 Presentation 对象
Presentation presIn = new Presentation("SelectedSlides.pptx");
Presentation presOut = new Presentation();
try {
    ISlide slide = presIn.getSlides().get_Item(0);
    presOut.getSlides().insertClone(0, slide);
    
    // 设置幻灯片类型和大小
    presOut.getSlideSize().setSize(612F, 792F,SlideSizeScaleType.EnsureFit);
        
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);

    presOut.save("PDF-SelectedSlide.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presIn != null) presIn.dispose();
    if (presOut != null) presOut.dispose();
}
```

## **在备注幻灯片视图中将 PowerPoint 转换为 PDF**
由 [**Presentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 类暴露的 [**Save**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) 方法可用于将整个演示文稿在备注幻灯片视图中转换为 PDF。下面的代码片段将示例演示文稿更新为备注幻灯片视图中的 PDF。

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);

    pres.save(resourcesOutputPath+"PDF-Notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

您可能想查看 Aspose [PowerPoint 转 PDF](https://products.aspose.app/slides/conversion/powerpoint-to-pdf) 或 [PPT 转 PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf) 转换器。

{{% /alert %}} 