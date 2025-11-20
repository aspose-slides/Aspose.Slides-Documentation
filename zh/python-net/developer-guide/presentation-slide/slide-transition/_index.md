---
title: 使用 Python 管理演示文稿中的幻灯片切换
linktitle: 幻灯片切换
type: docs
weight: 90
url: /zh/python-net/slide-transition/
keywords:
- 幻灯片切换
- 添加幻灯片切换
- 应用幻灯片切换
- 高级幻灯片切换
- 形变切换
- 切换类型
- 切换效果
- Python
- Aspose.Slides
description: "了解如何通过 .NET 在 Aspose.Slides for Python 中自定义幻灯片切换，提供针对 PowerPoint 和 OpenDocument 演示文稿的分步指导。"
---

## **概述**

Aspose.Slides for Python 提供对幻灯片切换的完整控制，从选择切换类型到配置计时和触发器，均可用于自动化演示工作流。您可以设置幻灯片在点击时或在指定延迟后前进，并通过黑屏切入或方向进入等效果细化视觉行为。该库还支持 PowerPoint 2019 引入的 Morph 切换，包括按对象、单词或字符进行形变的模式，以在幻灯片之间创建平滑、连贯的运动。

## **添加幻灯片切换**

为了更易理解，以下示例演示如何使用 Aspose.Slides for Python 管理简单的幻灯片切换。开发者可以对幻灯片应用不同的切换效果并自定义其行为。要创建一个简单的幻灯片切换，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 使用 [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) 枚举中的一种效果应用幻灯片切换。  
1. 保存修改后的演示文件。  
```py
import aspose.slides as slides

# 实例化 Presentation 类以加载演示文件。
with slides.Presentation("sample.pptx") as presentation:
    # 将圆形切换应用于第 1 张幻灯片。
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # 将梳状切换应用于第 2 张幻灯片。
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # 将演示文稿保存到磁盘。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **添加高级幻灯片切换**

在本节中，我们对幻灯片应用了一个简单的切换效果。要使该效果更加受控且更具打磨感，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 使用 [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) 枚举中的一种效果应用幻灯片切换。  
1. 将切换配置为点击时前进、在特定时间后前进，或两者兼而有之。  
1. 保存修改后的演示文件。  

如果启用了 **Advance On Click**，则幻灯片仅在用户点击时前进。如果设置了 **Advance After Time** 属性，幻灯片将在指定间隔后自动前进。  
```py
import aspose.slides as slides

# 实例化 Presentation 类以打开演示文稿文件。
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # 将圆形切换应用于第 1 张幻灯片。
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # 启用点击时前进并设置 3 秒自动前进。
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # 将梳状切换应用于第 2 张幻灯片。
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # 启用点击时前进并设置 5 秒自动前进。
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # 将缩放切换应用于第 3 张幻灯片。
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # 启用点击时前进并设置 7 秒自动前进。
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # 将演示文稿保存到磁盘。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Morph 切换**

Aspose.Slides for Python 支持 [Morph transition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/)，该切换可实现从一张幻灯片到下一张幻灯片的平滑移动。本节说明如何使用 Morph 切换。要有效使用它，您需要两张具有至少一个共同对象的幻灯片。最简便的方法是复制一张幻灯片，然后在第二张幻灯片上将对象移动到不同位置。

以下代码片段演示如何克隆包含文本的幻灯片并对第二张幻灯片应用 Morph 切换。  
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # 克隆第一张幻灯片以创建第二张具有相同形状的幻灯片，以实现 Morph 连续性。
    slide1 = presentation.slides.add_clone(slide0)

    # 在第二张幻灯片上选择相同的矩形并更改其位置和尺寸。
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # 在第二张幻灯片上启用 Morph 切换，以平滑动画形状的变化。
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Morph 切换类型**

[TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) 枚举表示不同的 Morph 幻灯片切换类型。

以下代码片段演示如何对幻灯片应用 Morph 切换并更改 morph 类型：  
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **设置切换效果**

Aspose.Slides for Python 允许您设置诸如 **From Black**、**From Left**、**From Right** 等切换效果。要配置切换效果，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
1. 获取对幻灯片的引用。  
1. 设置所需的切换效果。  
1. 将演示保存为 PPTX 文件。  

在下面的示例中，我们设置了多种切换效果。  
```py
import aspose.slides as slides

# 实例化 Presentation 类以打开演示文稿文件。
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # 应用 Cut 切换并启用 From Black。
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # 将演示文稿保存到磁盘。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **常见问答**

**我可以控制幻灯片切换的播放速度吗？**

可以。使用 [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) 设置（如慢/中/快）来设定切换的 [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/)。

**我可以为切换附加音频并让其循环吗？**

可以。您可以为切换嵌入声音，并通过诸如 sound、sound_mode、sound_loop 等设置以及 sound_is_built_in、sound_name 等元数据来控制其行为。

**将相同的切换应用于每张幻灯片的最快方法是什么？**

在每张幻灯片的切换设置中配置所需的切换类型；切换是按幻灯片存储的，因此在所有幻灯片上使用相同的类型即可得到一致的效果。

**我如何检查当前幻灯片上设置了哪个切换？**

检查幻灯片的 [transition settings](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) 并读取其 [transition type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/)；该值会明确指出已应用的效果。