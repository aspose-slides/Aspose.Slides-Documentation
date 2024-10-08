---
title: 将PowerPoint转换为动画GIF
type: docs
weight: 65
url: /php-java/convert-powerpoint-to-animated-gif/
keywords: "将PowerPoint转换为动画GIF, PPT到GIF, PPTX到GIF"
description: "将PowerPoint转换为动画GIF：PPT到GIF，PPTX到GIF，使用Aspose.Slides API。"
---

## 使用默认设置将演示文稿转换为动画GIF ##

以下示例代码演示如何使用标准设置将演示文稿转换为动画GIF：

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

将使用默认参数创建动画GIF。 

{{%  alert  title="提示"  color="primary"  %}} 

如果您希望自定义GIF的参数，可以使用 [GifOptions](https://reference.aspose.com/slides/php-java/aspose.slides/GifOptions) 类。请参见下面的示例代码。

{{% /alert %}} 

## 使用自定义设置将演示文稿转换为动画GIF ##

以下示例代码演示如何使用自定义设置将演示文稿转换为动画GIF：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $gifOptions = new GifOptions();
    $gifOptions->setFrameSize(new Java("java.awt.Dimension", 960, 720));// 结果GIF的大小

    $gifOptions->setDefaultDelay(2000);// 每张幻灯片显示的时间，直到切换到下一张

    $gifOptions->setTransitionFps(35);// 增加FPS以提高过渡动画质量

    $pres->save("pres.gif", SaveFormat::Gif, $gifOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="信息" color="info" %}}

您可能想查看Aspose开发的免费 [文本到GIF](https://products.aspose.app/slides/text-to-gif) 转换器。

{{% /alert %}}