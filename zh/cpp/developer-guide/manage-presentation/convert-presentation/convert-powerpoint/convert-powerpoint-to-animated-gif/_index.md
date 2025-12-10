---
title: 使用 C++ 将 PowerPoint 演示文稿转换为动画 GIF
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
- 导出 PPT 为 GIF
- 导出 PPTX 为 GIF
- 默认设置
- 自定义设置
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 轻松将 PowerPoint 演示文稿（PPT、PPTX）转换为动画 GIF。快速且高质量的输出。"
---

## **使用默认设置将演示文稿转换为动画 GIF**

此 C++ 示例代码演示如何使用标准设置将演示文稿转换为动画 GIF：
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```


动画 GIF 将使用默认参数创建。 

{{%  alert  title="TIP"  color="primary"  %}} 

如果您希望自定义 GIF 的参数，可以使用 [GifOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.gif_options) 类。请参阅下面的示例代码。 

{{% /alert %}} 

## **使用自定义设置将演示文稿转换为动画 GIF**

此示例代码演示如何在 C++ 中使用自定义设置将演示文稿转换为动画 GIF：
``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// 生成的 GIF 大小 
gifOptions->set_FrameSize(Size(960, 720));
// 每张幻灯片显示的时长，直到切换到下一张
gifOptions->set_DefaultDelay(2000);
// 增加 FPS 以获得更好的过渡动画质量
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```


{{% alert title="Info" color="info" %}}

您可能想了解 Aspose 开发的免费 [Text to GIF](https://products.aspose.app/slides/text-to-gif) 转换器。 

{{% /alert %}}

## **常见问题**

**如果演示文稿中使用的字体未在系统上安装怎么办？**

安装缺失的字体或 [配置回退字体](/slides/zh/cpp/powerpoint-fonts/)。Aspose.Slides 将进行替换，但外观可能会有所不同。对于品牌标识，请始终确保所需字体显式可用。

**我可以在 GIF 帧上叠加水印吗？**

可以。 在导出前，将 [添加半透明对象/徽标](/slides/zh/cpp/watermark/) 添加到母版幻灯片或单个幻灯片上 — 水印将出现在每一帧上。