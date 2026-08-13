---
title: 将 PowerPoint 演示文稿转换为 C++ 中的动画 GIF
linktitle: PowerPoint 转 GIF
type: docs
weight: 65
url: /zh/cpp/convert-powerpoint-to-animated-gif/
keywords:
- 动画 GIF
- 转换 PowerPoint
- 转换演示文稿
- 转换幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 GIF
- 演示文稿转 GIF
- 幻灯片转 GIF
- PPT 转 GIF
- PPTX 转 GIF
- 将 PPT 保存为 GIF
- 将 PPTX 保存为 GIF
- 将 PPT 导出为 GIF
- 将 PPTX 导出为 GIF
- 默认设置
- 自定义设置
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 轻松将 PowerPoint 演示文稿（PPT、PPTX）转换为动画 GIF。快速且高质量的结果。"
---
## **概述**

Aspose.Slides 只需几行代码，即可将 PowerPoint 演示文稿转换为动画 GIF 文件。此功能在需要以轻量、广泛支持的动画格式分享幻灯片内容时非常有用，可将其嵌入网页、聊天工具或文档中。本文说明了如何使用默认设置将演示文稿导出为 GIF，以及如何通过 [GifOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/gifoptions/) 配置帧大小、幻灯片延迟和过渡帧率等选项来自定义输出。

## **使用默认设置将演示文稿转换为动画 GIF**

以下 C++ 示例代码演示了如何使用标准设置将演示文稿转换为动画 GIF：

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

动画 GIF 将使用默认参数创建。

{{%  alert  title="TIP"  color="info"  %}} 
如果您希望自定义 GIF 的参数，可以使用 [GifOptions](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.export.gif_options) 类。请参阅下面的示例代码。 
{{% /alert %}} 

## **使用自定义设置将演示文稿转换为动画 GIF**

以下 C++ 示例代码展示了如何使用自定义设置将演示文稿转换为动画 GIF：

``` cpp
#include <DOM/Presentation.h>
#include <Export/GifOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto gifOptions = System::MakeObject<GifOptions>();
// 生成的 GIF 的大小
gifOptions->set_FrameSize(System::Drawing::Size(960, 720));
// 每张幻灯片显示的时长，直到切换到下一张
gifOptions->set_DefaultDelay(2000);
// 提高 FPS 以获得更好的过渡动画质量
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}
您可能想了解由 Aspose 开发的免费 [Text to GIF](https://products.aspose.app/slides/zh/text-to-gif) 转换器。 
{{% /alert %}}

## **常见问题**

### 如果演示文稿中使用的字体未在系统中安装怎么办？

请安装缺失的字体或[配置后备字体](/slides/zh/cpp/powerpoint-fonts/)。Aspose.Slides 会进行替换，但外观可能会有所不同。为了品牌一致性，请始终确保所需的字体已明确可用。

### 我可以在 GIF 帧上叠加水印吗？

可以。在导出前将半透明对象/徽标[添加到母版幻灯片或单独幻灯片](/slides/zh/cpp/watermark/)，水印将出现在每一帧上。