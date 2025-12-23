---
title: 在 PHP 中将 PowerPoint 演示文稿转换为动画 GIF
linktitle: PowerPoint 转 GIF
type: docs
weight: 65
url: /zh/php-java/convert-powerpoint-to-animated-gif/
keywords:
- 动画 GIF
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 GIF
- 演示文稿 转 GIF
- 幻灯片 转 GIF
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
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP（通过 Java）轻松将 PowerPoint 演示文稿（PPT、PPTX）转换为动画 GIF。快速且高质量的结果。"
---

## **使用默认设置将演示文稿转换为动画 GIF**

此示例代码展示了如何使用标准设置将演示文稿转换为动画 GIF：
```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.gif", SaveFormat::Gif);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


动画 GIF 将使用默认参数创建。

{{%  alert  title="TIP"  color="primary"  %}} 
如果您想自定义 GIF 参数，可以使用 [GifOptions](https://reference.aspose.com/slides/php-java/aspose.slides/GifOptions) 类。请参阅下面的示例代码。
{{% /alert %}} 

## **使用自定义设置将演示文稿转换为动画 GIF**
此示例代码展示了如何使用自定义设置将演示文稿转换为动画 GIF：
```php
  $pres = new Presentation("pres.pptx");
  try {
    $gifOptions = new GifOptions();
    $gifOptions->setFrameSize(new Java("java.awt.Dimension", 960, 720));// 生成的 GIF 大小

    $gifOptions->setDefaultDelay(2000);// 每张幻灯片显示的时长，直到切换到下一张

    $gifOptions->setTransitionFps(35);// 提高 FPS 以获得更好的过渡动画质量

    $pres->save("pres.gif", SaveFormat::Gif, $gifOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="Info" color="info" %}}
您可能想了解由 Aspose 开发的免费 [Text to GIF](https://products.aspose.app/slides/text-to-gif) 转换器。
{{% /alert %}}

## **FAQ**

**如果演示文稿中使用的字体未在系统上安装怎么办？**

请安装缺失的字体或[配置回退字体](/slides/zh/php-java/powerpoint-fonts/)。Aspose.Slides 会进行替换，但外观可能有所不同。对于品牌标识，请始终确保所需字体已明确可用。

**我可以在 GIF 帧上叠加水印吗？**

可以。请在导出前将[半透明对象/徽标](/slides/zh/php-java/watermark/)添加到母版幻灯片或各个幻灯片 — 水印将出现在每一帧上。