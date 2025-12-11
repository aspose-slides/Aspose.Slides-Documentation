---
title: 在 Android 上将 PowerPoint 演示文稿转换为 SWF Flash
linktitle: PowerPoint 转 SWF
type: docs
weight: 80
url: /zh/androidjava/convert-powerpoint-to-swf-flash/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 SWF
- 演示文稿 转 SWF
- 幻灯片 转 SWF
- PPT 转 SWF
- PPTX 转 SWF
- PowerPoint 转 Flash
- 演示文稿 转 Flash
- 幻灯片 转 Flash
- PPT 转 Flash
- PPTX 转 Flash
- 将 PPT 保存为 SWF
- 将 PPTX 保存为 SWF
- 导出 PPT 为 SWF
- 导出 PPTX 为 SWF
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "在 Android 上使用 Aspose.Slides for Java 将 PowerPoint (PPT/PPTX) 转换为 SWF Flash。提供一步一步的代码示例，快速高质量输出，无需 PowerPoint 自动化。"
---

## **转换 PPT(X) 为 SWF**
[Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 方法由 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 类公开，可用于将整个演示文稿转换为 **SWF** 文档。下面的示例展示了如何使用由 [**SWFOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SwfOptions) 类提供的选项将演示文稿转换为 **SWF** 文档。您还可以使用 [**ISWFOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISwfOptions) 类和 [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions) 接口在生成的 SWF 中包含批注。
```java
Presentation pres = new Presentation("Sample.pptx");
try {
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    // 保存演示文稿
    pres.save("Sample.swf", SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```


## **常见问题**
**我可以在 SWF 中包含隐藏的幻灯片吗？**
是的。使用 [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) 方法在 [SwfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/) 中启用隐藏幻灯片。默认情况下，不会导出隐藏幻灯片。

**我如何控制压缩以及最终的 SWF 大小？**
使用 [setCompressed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setCompressed-boolean-) 方法和 [adjust JPEG quality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setJpegQuality-int-) 以在文件大小和图像质量之间取得平衡。

**‘setViewerIncluded’ 是什么用途，何时应该禁用它？**
[setViewerIncluded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) 会添加嵌入式播放器 UI（导航控制、面板、搜索）。如果您计划使用自己的播放器或需要没有 UI 的纯 SWF 框架，请禁用它。

**如果导出机器缺少源字体会怎样？**
Aspose.Slides 将使用您在 [SwfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/swfoptions/) 中通过 [setDefaultRegularFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) 指定的字体进行替换，以避免意外的回退。