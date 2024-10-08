---
title: 将 PowerPoint 转换为动画 GIF
type: docs
weight: 65
url: /net/convert-powerpoint-to-animated-gif/
keywords: "转换 PowerPoint, PPT, PPTX, 动画 GIF, PPT 转动画 GIF, PPTX 转动画 GIF C#, Csharp, .NET, 默认设置, 自定义设置 "
description: "将 PowerPoint 演示文稿转换为动画 GIF: PPT 转 GIF, PPTX 转 GIF 在 C# 或 .NET 中"
---

## 使用默认设置将演示文稿转换为动画 GIF ##

以下 C# 示例代码演示如何使用标准设置将演示文稿转换为动画 GIF：

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```

动画 GIF 将使用默认参数创建。

{{%  alert  title="提示"  color="primary"  %}} 

如果您希望自定义 GIF 的参数，可以使用 [GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions) 类。请参见下面的示例代码。

{{% /alert %}} 

## 使用自定义设置将演示文稿转换为动画 GIF ##
以下示例代码演示如何使用自定义设置将演示文稿转换为动画 GIF：

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // 结果 GIF 的大小  
        DefaultDelay = 2000, // 每张幻灯片显示的时间，直到切换到下一张
        TransitionFps = 35 // 增加 FPS 以改善过渡动画质量
    });
}
```

{{% alert title="信息" color="info" %}}

您可能想查看 Aspose 开发的免费 [文本转 GIF](https://products.aspose.app/slides/text-to-gif) 转换器。

{{% /alert %}}