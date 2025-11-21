---
title: 将 PowerPoint 转换为 SWF Flash
type: docs
weight: 80
url: /zh/nodejs-java/convert-powerpoint-to-swf-flash/
keywords: "PPT, PPTX 转换为 SWF"
description: "在 JavaScript 中将 PowerPoint PPT、PPTX 转换为 SWF"
---

## **将 PPT(X) 转换为 SWF**
The [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) method exposed by [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) class can be used to convert the whole presentation into **SWF** document. The following example shows how to convert a presentation into **SWF** document by using options provided by [**SWFOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SwfOptions) class. You can also include comments in generated SWF using [**SWFOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SwfOptions) class and [**NotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NotesCommentsLayoutingOptions) class.
```javascript
var pres = new aspose.slides.Presentation("Sample.pptx");
try {
    var swfOptions = new aspose.slides.SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // 保存演示文稿
    pres.save("Sample.swf", aspose.slides.SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **常见问题**

**我可以在 SWF 中包含隐藏的幻灯片吗？**

是的。使用 [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/setshowhiddenslides/) 方法在 [SwfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/) 中。默认情况下，隐藏的幻灯片不会被导出。

**我如何控制压缩以及最终的 SWF 大小？**

使用 [setCompressed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/setcompressed/) 方法和 [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/setjpegquality/) 来平衡文件大小和图像保真度。

**“setViewerIncluded”的作用是什么，何时应使用它？**

[setViewerIncluded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/setviewerincluded/) 添加嵌入式播放器 UI（导航控件、面板、搜索）。如果您计划使用自己的播放器或需要没有 UI 的裸 SWF 框架，请使用它。

**如果导出机器缺少源字体会怎样？**

Aspose.Slides 将使用您通过 [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) 在 [SwfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/swfoptions/) 中指定的字体进行替换，以避免意外的回退。