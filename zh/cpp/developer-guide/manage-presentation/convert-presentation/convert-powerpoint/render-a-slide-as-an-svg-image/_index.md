---
title: 将幻灯片呈现为SVG图像
type: docs
weight: 50
url: /cpp/render-a-slide-as-an-svg-image/
---

SVG（可扩展矢量图形的缩写）是一种标准的图形类型或格式，用于呈现二维图像。SVG将图像作为XML中的矢量存储，并附带定义其行为或外观的详细信息。

SVG是少数几种在这些方面满足非常高标准的图像格式之一：可伸缩性、互动性、性能、可访问性、可编程性等。由于这些原因，它在网页开发中得到了广泛使用。

当你需要以下功能时，可以考虑使用SVG文件：

- **以*非常大格式*打印演示文稿。** SVG图像可以缩放到任何分辨率或级别。你可以根据需要多次调整SVG图像的大小而不牺牲质量。
- **在*不同媒介或平台*中使用幻灯片中的图表和图形。** 大多数阅读器都能解释SVG文件。
- **使用*尽可能小的图像*。** 与其他格式（特别是基于位图（JPEG或PNG）的格式）中高分辨率的等价物相比，SVG文件通常更小。

Aspose.Slides for C++允许你将演示文稿中的幻灯片导出为SVG图像。按照以下步骤生成SVG图像：

1. 创建Presentation类的实例。
2. 遍历演示文稿中的所有幻灯片。
3. 通过FileStream将每个幻灯片写入其自己的SVG文件。

{{% alert color="primary" %}} 

你可能想要尝试我们的[免费网络应用程序](https://products.aspose.app/slides/conversion/ppt-to-svg)，我们在其中实现了Aspose.Slides for C++的PPT到SVG转换功能。

{{% /alert %}} 

以下是使用Aspose.Slides将PPT转换为SVG的C++示例代码：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
        
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto fileName = String::Format(u"slide-{0}.svg", index);
    auto fileStream = System::MakeObject<FileStream>(fileName, FileMode::Create, FileAccess::Write);

    auto slide = pres->get_Slides()->idx_get(index);
    slide->WriteAsSvg(fileStream);
}
```