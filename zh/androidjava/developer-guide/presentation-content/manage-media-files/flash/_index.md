---
title: 在 Android 上提取演示文稿中的 Flash 对象
linktitle: Flash
type: docs
weight: 10
url: /zh/androidjava/flash/
keywords:
- 提取 Flash
- Flash 对象
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android 在 Java 中从 PowerPoint 和 OpenDocument 幻灯片中提取 Flash 对象，完整代码示例和最佳实践。"
---

## **Extract Flash Objects from Presentations**

Aspose.Slides for Android via Java 提供了从演示文稿中提取 Flash 对象的功能。您可以按名称访问 Flash 控件并将其从演示文稿中提取出来，同时存储 SWF 对象数据。
```java
// 实例化表示 PPTX 的 Presentation 类
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


## **FAQ**

**What presentation formats are supported when extracting Flash content?**

[Aspose.Slides supports](/slides/zh/androidjava/supported-file-formats/) 主要的 PowerPoint 格式，如 PPT 和 PPTX，因为它可以加载这些容器并访问其中的控件，包括与 Flash 相关的 ActiveX 元素。

**Can I convert a presentation with Flash to HTML5 and preserve Flash interactivity?**

否。Aspose.Slides 不会执行 SWF 内容或转换其交互性。虽然支持导出到 [HTML](/slides/zh/androidjava/convert-powerpoint-to-html/)/[HTML5](/slides/zh/androidjava/export-to-html5/)，但由于浏览器已停止支持，Flash 在现代浏览器中无法播放。建议在导出之前将 Flash 替换为视频或 HTML5 动画等替代方案。

**From a security perspective, does Aspose.Slides execute SWF files while reading a presentation?**

否。Aspose.Slides 将 Flash 视为嵌入文件中的二进制数据，在处理过程中不会执行 SWF 内容。

**How should I handle presentations that include Flash along with other embedded files via OLE?**

Aspose.Slides 支持[extracting embedded OLE objects](/slides/zh/androidjava/manage-ole/)，因此您可以一次性处理所有相关的嵌入内容，统一处理 Flash 控件和其他 OLE 嵌入的文档。