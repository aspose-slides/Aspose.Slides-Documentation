---
title: 在 C++ 中从演示文稿中提取 Flash 对象
linktitle: Flash
type: docs
weight: 10
url: /zh/cpp/flash/
keywords:
- 提取 flash
- flash 对象
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides 在 C++ 中从 PowerPoint 和 OpenDocument 幻灯片中提取 Flash 对象，完整代码示例和最佳实践。"
---

## **从演示文稿中提取 Flash 对象**
Aspose.Slides for C++ 提供了从演示文稿中提取 flash 对象的功能。您可以按名称访问 flash 控件并将其从演示文稿中提取，包括存储 SWF 对象数据。
``` cpp
auto pres = System::MakeObject<Presentation>(u"withFlash.pptm");
auto controls = pres->get_Slides()->idx_get(0)->get_Controls();
System::SharedPtr<Control> flashControl;
for (const auto& control : controls)
{
    if (control->get_Name() == u"ShockwaveFlash1")
    {
        flashControl = System::ExplicitCast<Control>(control);
    }
}
```


## **常见问题**

**在提取 Flash 内容时支持哪些演示文稿格式？**

[Aspose.Slides supports](/slides/zh/cpp/supported-file-formats/) 主要的 PowerPoint 格式，如 PPT 和 PPTX，因为它可以加载这些容器并访问它们的控件，包括与 Flash 相关的 ActiveX 元素。

**我能将包含 Flash 的演示文稿转换为 HTML5 并保留 Flash 交互性吗？**

不。Aspose.Slides 不会执行 SWF 内容或转换其交互性。虽然支持导出到 [HTML](/slides/zh/cpp/convert-powerpoint-to-html/)/[HTML5](/slides/zh/cpp/export-to-html5/)，但由于已停止支持，Flash 在现代浏览器中无法播放。建议的做法是在导出之前将 Flash 替换为视频或 HTML5 动画等替代方案。

**从安全角度来看，Aspose.Slides 在读取演示文稿时会执行 SWF 文件吗？**

不。Aspose.Slides 将 Flash 视为嵌入文件中的二进制数据，在处理过程中不会执行 SWF 内容。

**我应该如何处理包含 Flash 以及通过 OLE 嵌入的其他文件的演示文稿？**

Aspose.Slides 支持 [extracting embedded OLE objects](/slides/zh/cpp/manage-ole/)，因此您可以一次性处理所有相关的嵌入内容，综合处理 Flash 控件和其他 OLE 嵌入的文档。