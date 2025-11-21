---
title: 在 .NET 中将 PowerPoint 演示文稿转换为动画 GIF
linktitle: PowerPoint 转 GIF
type: docs
weight: 65
url: /zh/net/convert-powerpoint-to-animated-gif/
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
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 轻松将 PowerPoint 演示文稿（PPT、PPTX）转换为动画 GIF。快速、高质量的结果。"
---

## **使用默认设置将演示文稿转换为动画 GIF**

以下 C# 示例代码演示了如何使用标准设置将演示文稿转换为动画 GIF：
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```


动画 GIF 将使用默认参数创建。 

{{%  alert  title="TIP"  color="primary"  %}} 
如果您想自定义 GIF 的参数，可以使用 [GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions) 类。请参阅下面的示例代码。 
{{% /alert %}} 

## **使用自定义设置将演示文稿转换为动画 GIF**

以下 C# 示例代码演示了如何使用自定义设置将演示文稿转换为动画 GIF：
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // 生成的 GIF 的尺寸
        DefaultDelay = 2000, // 每张幻灯片显示的时长，直到切换到下一张
        TransitionFps = 35 // 提高 FPS 以获得更好的过渡动画质量
    });
}
```


{{% alert title="Info" color="info" %}}
您可能想了解 Aspose 开发的免费 [Text to GIF](https://products.aspose.app/slides/text-to-gif) 转换器。 
{{% /alert %}}

## **常见问题**

**如果演示文稿中使用的字体未安装在系统上怎么办？**

请安装缺失的字体或 [配置回退字体](/slides/zh/net/powerpoint-fonts/)。Aspose.Slides 会进行替换，但外观可能有所不同。为保证品牌一致性，请始终确保所需字体已明确可用。

**我可以在 GIF 帧上覆盖水印吗？**

可以。请在导出前将 [半透明对象/徽标](/slides/zh/net/watermark/) 添加到母版幻灯片或各个幻灯片中——水印会出现在每一帧上。