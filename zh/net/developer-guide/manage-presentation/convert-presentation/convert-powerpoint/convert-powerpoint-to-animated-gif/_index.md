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
- 保存 PPT 为 GIF
- 保存 PPTX 为 GIF
- 导出 PPT 为 GIF
- 导出 PPTX 为 GIF
- 默认设置
- 自定义设置
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 轻松将 PowerPoint 演示文稿（PPT、PPTX）转换为动画 GIF。快速且高质量的结果。"
---

## **使用默认设置将演示文稿转换为动画 GIF**

This sample code in C# shows you how to convert a presentation to animated GIF using standard settings:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```


The animated GIF will be created with default parameters. 

{{%  alert  title="TIP"  color="primary"  %}} 

If you prefer to customize the parameters for the GIF, you can use the [GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions) class. See the sample code below. 

{{% /alert %}} 

## **使用自定义设置将演示文稿转换为动画 GIF**

This sample code shows you how to convert a presentation to animated GIF using custom settings in C#:
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // 生成的 GIF 大小  
        DefaultDelay = 2000, // 每张幻灯片显示的时长，直到切换到下一张
        TransitionFps = 35 // 提高 FPS 以获得更好的过渡动画质量
    });
}
```


{{% alert title="Info" color="info" %}}

You may want to check out a FREE [文本转GIF](https://products.aspose.app/slides/text-to-gif) converter developed by Aspose. 

{{% /alert %}}

## **常见问题**

**如果演示文稿使用的字体未安装在系统上怎么办？**

Install the missing fonts or [配置回退字体](/slides/zh/net/powerpoint-fonts/). Aspose.Slides will substitute, but the appearance may differ. For branding, always ensure the required typefaces are explicitly available.

**我能在 GIF 帧上叠加水印吗？**

Yes. [添加半透明对象/徽标](/slides/zh/net/watermark/) to the master slide or to individual slides before export — the watermark will appear on every frame.