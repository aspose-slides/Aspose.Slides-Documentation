---
title: 将 PowerPoint 转换为动画 GIF
type: docs
weight: 65
url: /zh/python-net/convert-powerpoint-to-animated-gif/
keywords: "转换 PowerPoint, PPT, PPTX, 动画 GIF, PPT 转动画 GIF, PPTX 转动画 GIF, Python, 默认设置, 自定义设置"
description: "将 PowerPoint 演示文稿转换为动画 GIF：PPT 转 GIF, PPTX 转 GIF 在 Python 中"
---

## 使用默认设置将演示文稿转换为动画 GIF ##

以下 Python 示例代码展示了如何使用标准设置将演示文稿转换为动画 GIF：

```py
import aspose.slides as slides

pres = slides.Presentation(path + "pres.pptx")
pres.save("pres.gif", slides.export.SaveFormat.GIF)
```

将使用默认参数创建动画 GIF。

{{%  alert  title="提示"  color="primary"  %}} 

如果您希望自定义 GIF 的参数，可以使用 [GifOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/gifoptions/) 类。请参阅下面的示例代码。 

{{% /alert %}} 

## 使用自定义设置将演示文稿转换为动画 GIF ##
以下示例代码展示了如何在 Python 中使用自定义设置将演示文稿转换为动画 GIF：

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

pres = slides.Presentation(path + "pres.pptx")

options = slides.export.GifOptions()
options.frame_size = drawing.Size(960, 720) # 结果 GIF 的大小  
options.default_delay = 2000 # 每张幻灯片显示的时间，直到更改为下一张
options.transition_fps = 35  # 增加帧率以提高过渡动画质量

pres.save("pres.gif", slides.export.SaveFormat.GIF, options)
```

{{% alert title="信息" color="info" %}}

您可能想查看 Aspose 开发的免费 [文本转 GIF](https://products.aspose.app/slides/text-to-gif) 转换器。 

{{% /alert %}}