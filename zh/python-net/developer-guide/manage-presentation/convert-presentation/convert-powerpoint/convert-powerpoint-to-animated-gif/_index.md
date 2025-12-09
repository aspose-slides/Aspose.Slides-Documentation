---
title: 在 Python 中将演示文稿转换为动画 GIF
linktitle: 演示文稿转 GIF
type: docs
weight: 65
url: /zh/python-net/convert-powerpoint-to-animated-gif/
keywords:
- 动画 GIF
- 转换 PowerPoint
- 转换 OpenDocument
- 转换演示文稿
- 转换幻灯片
- 转换 PPT
- 转换 PPTX
- 转换 ODP
- PowerPoint 转 GIF
- OpenDocument 转 GIF
- 演示文稿转 GIF
- 幻灯片转 GIF
- PPT 转 GIF
- PPTX 转 GIF
- ODP 转 GIF
- 默认设置
- 自定义设置
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python 轻松将 PowerPoint 演示文稿（PPT、PPTX）和 OpenDocument 文件（ODP）转换为动画 GIF。快速且高质量的结果。"
---

## **使用默认设置将演示文稿转换为动画 GIF**

此 Python 示例代码展示了如何使用标准设置将演示文稿转换为动画 GIF：
```py
import aspose.slides as slides

pres = slides.Presentation(path + "pres.pptx")
pres.save("pres.gif", slides.export.SaveFormat.GIF)
```


动画 GIF 将使用默认参数创建。 

{{%  alert  title="TIP"  color="primary"  %}} 
如果您想自定义 GIF 的参数，可以使用 [GifOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/gifoptions/) 类。请参阅下面的示例代码。 
{{% /alert %}} 

## **使用自定义设置将演示文稿转换为动画 GIF**

此示例代码展示了如何在 Python 中使用自定义设置将演示文稿转换为动画 GIF：
```py
import aspose.slides as slides
import aspose.pydrawing as drawing

pres = slides.Presentation(path + "pres.pptx")

options = slides.export.GifOptions()
options.frame_size = drawing.Size(960, 720) # 生成的 GIF 的尺寸  
options.default_delay = 2000 # 每张幻灯片显示的时长，直到切换到下一张
options.transition_fps = 35  # 提高 FPS 以获得更好的过渡动画质量

pres.save("pres.gif", slides.export.SaveFormat.GIF, options)
```


{{% alert title="Info" color="info" %}}
您可能想了解由 Aspose 开发的免费 [Text to GIF](https://products.aspose.app/slides/text-to-gif) 转换器。 
{{% /alert %}}

## **常见问题**

**如果演示文稿中使用的字体未在系统上安装怎么办？**

安装缺失的字体或[配置回退字体](/slides/zh/python-net/powerpoint-fonts/)。Aspose.Slides 会进行替代，但外观可能会有所不同。出于品牌考虑，请始终确保所需字体明确可用。

**我可以在 GIF 帧上覆盖水印吗？**

可以。[在导出前向母版幻灯片或单个幻灯片添加半透明对象/徽标](/slides/zh/python-net/watermark/) — 水印会出现在每一帧中。