---
title: 将 PowerPoint 转换为动画 GIF
type: docs
weight: 65
url: /cpp/convert-powerpoint-to-animated-gif/
keywords: "将 PowerPoint 转换为动画 GIF, "
description: "将 PowerPoint 转换为动画 GIF：PPT 转 GIF，PPTX 转 GIF，使用 Aspose.Slides API。"
---

## 使用默认设置将演示文稿转换为动画 GIF ##

以下 C++ 示例代码演示了如何使用标准设置将演示文稿转换为动画 GIF：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

动画 GIF 将使用默认参数创建。

{{%  alert  title="提示"  color="primary"  %}} 

如果您希望自定义 GIF 的参数，可以使用 [GifOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.gif_options) 类。以下是示例代码。

{{% /alert %}} 

## 使用自定义设置将演示文稿转换为动画 GIF ##
以下示例代码演示了如何使用自定义设置将演示文稿转换为动画 GIF 的 C++ 代码：

``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// 生成 GIF 的大小 
gifOptions->set_FrameSize(Size(960, 720));
// 每张幻灯片显示的时间，直到切换到下一张
gifOptions->set_DefaultDelay(2000);
// 提高帧率以提高过渡动画质量
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="信息" color="info" %}}

您可能想查看 Aspose 开发的免费 [文本转 GIF](https://products.aspose.app/slides/text-to-gif) 转换器。

{{% /alert %}}