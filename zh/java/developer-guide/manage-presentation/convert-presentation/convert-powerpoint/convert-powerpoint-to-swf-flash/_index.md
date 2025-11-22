---
title: 在 Java 中将 PowerPoint 演示文稿转换为 SWF Flash
linktitle: PowerPoint 转 SWF
type: docs
weight: 80
url: /zh/java/convert-powerpoint-to-swf-flash/
keywords:
- 转换 PowerPoint
- 转换演示文稿
- 转换幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 SWF
- 演示文稿转 SWF
- 幻灯片转 SWF
- PPT 转 SWF
- PPTX 转 SWF
- PowerPoint 转 Flash
- 演示文稿转 Flash
- 幻灯片转 Flash
- PPT 转 Flash
- PPTX 转 Flash
- 将 PPT 保存为 SWF
- 将 PPTX 保存为 SWF
- 导出 PPT 为 SWF
- 导出 PPTX 为 SWF
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Java 中将 PowerPoint（PPT/PPTX）转换为 SWF Flash。一步步代码示例，快速高质量输出，无需 PowerPoint 自动化。"
---

## **Convert PPT(X) to SWF**
由 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类公开的 [Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 方法可用于将整个演示文稿转换为 **SWF** 文档。以下示例演示如何使用由 [**SWFOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/SwfOptions) 类提供的选项将演示文稿转换为 **SWF** 文档。您还可以使用 [**ISWFOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/ISwfOptions) 类和 [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions) 接口在生成的 SWF 中包含批注。
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
