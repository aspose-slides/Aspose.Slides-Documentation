---
title: 在 Android 上从演示文稿中提取 Flash 对象
linktitle: Flash
type: docs
weight: 10
url: /zh/androidjava/flash/
keywords:
- 提取 flash
- flash 对象
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android 在 Java 中从 PowerPoint 和 OpenDocument 幻灯片中提取 Flash 对象，包括完整代码示例和最佳实践。"
---

## **从演示文稿中提取 Flash 对象**

Aspose.Slides for Android via Java provides a facility for extracting flash objects from a presentation. You can access the flash control by name and extract it from the presentation and including store SWF object data.
```java
// 实例化代表 PPTX 的 Presentation 类
Presentation pres = new Presentation();
try {
    IControlCollection controls = pres.getSlides().get_Item(0).getControls();
    Control flashControl = null;
    for (IControl control : controls)
    {
        if (control.getName() == "ShockwaveFlash1")
        {
            flashControl = (Control)control;
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **常见问题**

**在提取 Flash 内容时支持哪些演示文稿格式？**

[Aspose.Slides 支持](/slides/zh/androidjava/supported-file-formats/) 主要的 PowerPoint 格式，例如 PPT 和 PPTX，因为它可以加载这些容器并访问其中的控件，包括与 Flash 相关的 ActiveX 元素。

**我能将包含 Flash 的演示文稿转换为 HTML5 并保留 Flash 交互性吗？**

否。Aspose.Slides 不执行 SWF 内容，也不转换其交互性。虽然支持导出到 [HTML](/slides/zh/androidjava/convert-powerpoint-to-html/)/[HTML5](/slides/zh/androidjava/export-to-html5/)，但由于浏览器已停止支持，Flash 在现代浏览器中无法播放。建议的做法是在导出之前将 Flash 替换为视频或 HTML5 动画等替代方案。

**从安全性角度来看，Aspose.Slides 在读取演示文稿时会执行 SWF 文件吗？**

否。Aspose.Slides 将 Flash 视为嵌入文件中的二进制数据，在处理过程中不会执行 SWF 内容。

**对于包含 Flash 以及其他通过 OLE 嵌入的文件的演示文稿，我该如何处理？**

Aspose.Slides 支持[提取嵌入的 OLE 对象](/slides/zh/androidjava/manage-ole/)，因此您可以一次性处理所有相关的嵌入内容，统一处理 Flash 控件和其他 OLE 嵌入的文档。