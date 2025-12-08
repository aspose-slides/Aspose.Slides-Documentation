---
title: 将 PowerPoint 转换为动画 GIF
type: docs
weight: 65
url: /zh/net/convert-powerpoint-to-animated-gif/
keywords: "转换 PowerPoint, PPT, PPTX, 动画 GIF, PPT 转动画 GIF, PPTX 转动画 GIF C#, Csharp, .NET, 默认设置, 自定义设置"
description: "将 PowerPoint 演示文稿转换为动画 GIF：在 C# 或 .NET 中将 PPT 转为 GIF、PPTX 转为 GIF"
---

## **将演示文稿转换为使用默认设置的动画 GIF**

下面的 C# 示例代码展示了如何使用标准设置将演示文稿转换为动画 GIF：
``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```


动画 GIF 将使用默认参数创建。

{{%  alert  title="TIP"  color="primary"  %}} 
如果您希望自定义 GIF 的参数，可以使用 [GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions) 类。请参阅下面的示例代码。 
{{% /alert %}} 

## **将演示文稿转换为使用自定义设置的动画 GIF**

下面的示例代码展示了如何在 C# 中使用自定义设置将演示文稿转换为动画 GIF：
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
您可能想了解 Aspose 开发的免费 [文本转 GIF](https://products.aspose.app/slides/text-to-gif) 转换器。 
{{% /alert %}}

## **常见问题**

**如果演示文稿使用的字体未在系统上安装怎么办？**

安装缺失的字体或[配置回退字体](/slides/zh/net/powerpoint-fonts/)。Aspose.Slides 会进行替换，但外观可能会有所不同。出于品牌需求，请始终确保所需字体已明确可用。

**我可以在 GIF 帧上叠加水印吗？**

可以。请在导出前将[添加半透明对象/徽标](/slides/zh/net/watermark/) 到母版幻灯片或各个幻灯片——水印将出现在每一帧上。