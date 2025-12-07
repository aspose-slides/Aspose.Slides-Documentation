---
title: 在 C++ 中将 PowerPoint 演示文稿转换为动画 GIF
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
- 保存 PPT 为 GIF
- 保存 PPTX 为 GIF
- 导出 PPT 为 GIF
- 导出 PPTX 为 GIF
- 默认设置
- 自定义设置
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++，轻松将 PowerPoint 演示文稿（PPT、PPTX）转换为动画 GIF。快速，高质量的结果。"
---

## **使用默认设置将演示文稿转换为动画 GIF**

下面的 C++ 示例代码演示了如何使用标准设置将演示文稿转换为动画 GIF：
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```


动画 GIF 将使用默认参数创建。

{{%  alert  title="提示"  color="primary"  %}} 

如果希望自定义 GIF 的参数，可以使用 [GifOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.gif_options) 类。请参见以下示例代码。

{{% /alert %}} 

## **使用自定义设置将演示文稿转换为动画 GIF**

下面的示例代码演示了如何在 C++ 中使用自定义设置将演示文稿转换为动画 GIF：
``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// 结果 GIF 的尺寸 
gifOptions->set_FrameSize(Size(960, 720));
// 每张幻灯片显示的时长，直至切换到下一张
gifOptions->set_DefaultDelay(2000);
// 提高 FPS 以获得更好的过渡动画质量
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```


{{% alert title="信息" color="info" %}}

您可以尝试 Aspose 开发的免费 [文本转 GIF](https://products.aspose.app/slides/text-to-gif) 转换器。

{{% /alert %}}

## **常见问题**

**如果演示文稿中使用的字体未在系统上安装怎么办？**

请安装缺失的字体或 [配置回退字体](/slides/zh/cpp/powerpoint-fonts/)。Aspose.Slides 将进行替换，但外观可能会有所差异。为确保品牌一致性，请始终确保所需字体已明确可用。

**我可以在 GIF 帧上叠加水印吗？**

可以。在导出之前，将半透明对象/徽标添加到母版幻灯片或各个幻灯片中 [/slides/cpp/watermark/]，水印将在每一帧上显示。