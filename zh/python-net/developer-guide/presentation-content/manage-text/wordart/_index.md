---
title: WordArt
type: docs
weight: 110
url: /zh/python-net/wordart/
keywords: "WordArt, Word Art, 创建 WordArt, WordArt 模板, WordArt 效果, 阴影效果, 显示效果, 发光效果, WordArt 转换, 3D 效果, 外阴影效果, 内阴影效果, Python, Aspose.Slides for Python via .NET"
description: "在 Python 或 Aspose.Slides for Python via .NET 中添加、操作和管理 PowerPoint 演示文稿中的 WordArt 和效果"
---

## **关于 WordArt？**
WordArt 或 Word Art 是一个功能，可以让你对文本应用效果，使其更突出。例如，使用 WordArt，你可以给文本描边或填充颜色（或渐变），为其添加 3D 效果，等等。你还可以倾斜、弯曲和拉伸文本的形状。

{{% alert color="primary" %}} 

WordArt 允许你将文本视为图形对象。WordArt 包含针对文本的效果或特殊修改，使其更具吸引力或更显眼。

{{% /alert %}} 

**Microsoft PowerPoint 中的 WordArt**

要在 Microsoft PowerPoint 中使用 WordArt，你必须选择一个预定义的 WordArt 模板。WordArt 模板是一组应用于文本或其形状的效果。

**Aspose.Slides 中的 WordArt**

在 Aspose.Slides for Python via .NET 20.10 中，我们实现了对 WordArt 的支持，并在后续的 Aspose.Slides for Python via .NET 版本中对该功能进行了改进。

使用 Aspose.Slides for Python via .NET，你可以轻松地在 Python 中创建自己的 WordArt 模板（一个效果或效果组合），并将其应用于文本。

## 创建简单的 WordArt 模板并应用于文本

**使用 Aspose.Slides** 

首先，我们使用以下 Python 代码创建简单的文本：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    textFrame = autoShape.text_frame

    portion = textFrame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"

    pres.save("wordart-1.pptx", slides.export.SaveFormat.PPTX)
```
现在，我们通过以下代码将文本的字体高度设置为更大的值，以使效果更加显著：

```py 
    fontData = slides.FontData("Arial Black")
    portion.portion_format.latin_font = fontData
    portion.portion_format.font_height = 36
```

**使用 Microsoft PowerPoint**

在 Microsoft PowerPoint 中转到 WordArt 效果菜单：

![todo:image_alt_text](image-20200930113926-1.png)

在右侧菜单中，你可以选择一个预定义的 WordArt 效果。在左侧菜单中，你可以指定新 WordArt 的设置。

这是一些可用的参数或选项：

![todo:image_alt_text](image-20200930114015-3.png)

**使用 Aspose.Slides**

在这里，我们将 SmallGrid 图案颜色应用于文本，并使用以下代码添加一个 1 宽的黑色文本边框：

```py 
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID
                
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

得到的文本：

![todo:image_alt_text](image-20200930114108-4.png)

## 应用其他 WordArt 效果

**使用 Microsoft PowerPoint**

从程序界面，你可以将这些效果应用于文本、文本块、形状或类似元素：

![todo:image_alt_text](image-20200930114129-5.png)

例如，可以将阴影、反射和发光效果应用于文本；可以将 3D 格式和 3D 旋转效果应用于文本块；可以将软边缘属性应用于形状对象（即使没有设置任何 3D 格式属性，它仍然会有影响）。

### 应用阴影效果

在这里，我们打算只设置与文本相关的属性。我们使用以下 Python 代码对文本应用阴影效果：

```py 
    portion.portion_format.effect_format.enable_outer_shadow_effect()
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.black
    portion.portion_format.effect_format.outer_shadow_effect.scale_horizontal = 100
    portion.portion_format.effect_format.outer_shadow_effect.scale_vertical = 65
    portion.portion_format.effect_format.outer_shadow_effect.blur_radius = 4.73
    portion.portion_format.effect_format.outer_shadow_effect.direction = 230
    portion.portion_format.effect_format.outer_shadow_effect.distance = 2
    portion.portion_format.effect_format.outer_shadow_effect.skew_horizontal = 30
    portion.portion_format.effect_format.outer_shadow_effect.skew_vertical = 0
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.32)
```

Aspose.Slides API 支持三种类型的阴影：外阴影、内阴影和预设阴影。

使用预设阴影，你可以为文本应用阴影（使用预设值）。

**使用 Microsoft PowerPoint**

在 PowerPoint 中，你可以使用一种类型的阴影。以下是一个示例：

![todo:image_alt_text](image-20200930114225-6.png)

**使用 Aspose.Slides**

Aspose.Slides 实际上允许你同时应用两种类型的阴影：内阴影和预设阴影。

**注意：**

- 当同时使用外阴影和预设阴影时，只有外阴影效果会被应用。
- 如果外阴影和内阴影同时使用，生成或应用的效果取决于 PowerPoint 版本。例如，在 PowerPoint 2013 中，效果加倍。但在 PowerPoint 2007 中，应用的是外阴影效果。

### 将显示应用于文本

我们通过以下 Python 代码样例为文本添加显示效果：

```py 
    portion.portion_format.effect_format.enable_reflection_effect()
    portion.portion_format.effect_format.reflection_effect.blur_radius = 0.5 
    portion.portion_format.effect_format.reflection_effect.distance = 4.72 
    portion.portion_format.effect_format.reflection_effect.start_pos_alpha = 0 
    portion.portion_format.effect_format.reflection_effect.end_pos_alpha = 60
    portion.portion_format.effect_format.reflection_effect.direction = 90 
    portion.portion_format.effect_format.reflection_effect.scale_horizontal = 100 
    portion.portion_format.effect_format.reflection_effect.scale_vertical = -100
    portion.portion_format.effect_format.reflection_effect.start_reflection_opacity = 60
    portion.portion_format.effect_format.reflection_effect.end_reflection_opacity = 0.9
    portion.portion_format.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM_LEFT  
```

### 将发光效果应用于文本

我们使用以下代码为文本应用发光效果，使其闪亮或突出：

```py 
    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.r = 255
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

操作的结果：

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

您可以更改阴影、显示和发光的参数。效果属性分别在文本的每个部分上进行设置。

{{% /alert %}} 

### 在 WordArt 中使用转换

我们通过以下代码使用转换属性（固有于整个文本块）：
```py 
textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

结果：

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Microsoft PowerPoint 和 Aspose.Slides for Python via .NET 提供了一定数量的预定义转换类型。

{{% /alert %}} 

**使用 PowerPoint**

要访问预定义的转换类型，请通过：**格式** -> **文本效果** -> **转换**

**使用 Aspose.Slides**

要选择转换类型，请使用 TextShapeType 枚举。

### 将 3D 效果应用于文本和形状

我们使用以下示例代码为文本形状设置 3D 效果：

```py 
    autoShape.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_bottom.height = 10.5
    autoShape.three_d_format.bevel_bottom.width = 10.5

    autoShape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_top.height = 12.5
    autoShape.three_d_format.bevel_top.width = 11

    autoShape.three_d_format.extrusion_color.color = draw.Color.orange
    autoShape.three_d_format.extrusion_height = 6

    autoShape.three_d_format.contour_color.color = draw.Color.dark_red
    autoShape.three_d_format.contour_width = 1.5

    autoShape.three_d_format.depth = 3

    autoShape.three_d_format.material = slides.MaterialPresetType.PLASTIC

    autoShape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    autoShape.three_d_format.light_rig.set_rotation(0, 0, 40)

    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

得到的文本及其形状：

![todo:image_alt_text](image-20200930114816-9.png)

我们使用以下 Python 代码为文本应用 3D 效果：

```py 
    textFrame.text_frame_format.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_bottom.height = 3.5
    textFrame.text_frame_format.three_d_format.bevel_bottom.width = 3.5

    textFrame.text_frame_format.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_top.height = 4
    textFrame.text_frame_format.three_d_format.bevel_top.width = 4

    textFrame.text_frame_format.three_d_format.extrusion_color.color = draw.Color.orange
    textFrame.text_frame_format.three_d_format.extrusion_height= 6

    textFrame.text_frame_format.three_d_format.contour_color.color = draw.Color.dark_red
    textFrame.text_frame_format.three_d_format.contour_width = 1.5

    textFrame.text_frame_format.three_d_format.depth= 3

    textFrame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC

    textFrame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    textFrame.text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    textFrame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    textFrame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

操作的结果：

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

将 3D 效果应用于文本或其形状以及效果之间的交互是基于某些规则。

考虑一个包含文本的形状的场景。3D 效果包含 3D 物体表示和放置物体的场景。

- 当两者都设置场景时，形状的场景具有更高的优先级——文本的场景会被忽略。
- 当形状缺少自己的场景但有 3D 表示时，将使用文本的场景。
- 否则——当形状最初没有 3D 效果时——形状是平面的，3D 效果仅应用于文本。

这些描述与 [ThreeDFormat.LightRig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) 和 [ThreeDFormat.Camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) 属性相关。

{{% /alert %}} 

## **将外阴影效果应用于文本**
Aspose.Slides for Python via .NET 提供了 [**IOuterShadow**](https://reference.aspose.com/slides/python-net/aspose.slides.effects/ioutershadow/) 和 [**IInnerShadow**](https://reference.aspose.com/slides/python-net/aspose.slides.effects/iinnershadow/) 类，允许你对由 TextFrame 承载的文本应用阴影效果。按照这些步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 使用其索引获取幻灯片的引用。
3. 向幻灯片添加一个矩形类型的 AutoShape。
4. 访问与 AutoShape 关联的 TextFrame。
5. 将 AutoShape 的 FillType 设置为 NoFill。
6. 实例化 OuterShadow 类。
7. 设置阴影的 BlurRadius。
8. 设置阴影的 Direction。
9. 设置阴影的 Distance。
10. 设置 RectangleAlign 为 TopLeft。
11. 将阴影的 PresetColor 设置为 Black。
12. 将演示文稿写入 PPTX 文件。

下面是实现上述步骤的 Python 示例代码，演示了如何将外阴影效果应用于文本：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    # 获取幻灯片的引用
    sld = pres.slides[0]

    # 添加一个矩形类型的 AutoShape
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # 向矩形添加 TextFrame
    ashp.add_text_frame("Aspose TextBox")

    # 禁用形状填充，以便获取文本的阴影
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # 添加外阴影并设置所有必要参数
    ashp.effect_format.enable_outer_shadow_effect()
    shadow = ashp.effect_format.outer_shadow_effect
    shadow.blur_radius = 4.0
    shadow.direction = 45
    shadow.distance = 3
    shadow.rectangle_align = slides.RectangleAlignment.TOP_LEFT
    shadow.shadow_color.preset_color = slides.PresetColor.BLACK

    # 将演示文稿写入磁盘
    pres.save("pres_out.pptx", slides.export.SaveFormat.PPTX)
```


## **将内阴影效果应用于形状**
按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 获取幻灯片的引用。
3. 添加一个矩形类型的 AutoShape。
4. 启用 InnerShadowEffect。
5. 设置所有必要的参数。
6. 将 ColorType 设置为 Scheme。
7. 设置 Scheme Color。
8. 将演示文稿写入 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。

以下是基于上述步骤的示例代码，演示了如何在 Python 中为两个形状之间添加连接器：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    # 获取幻灯片的引用
    slide = presentation.slides[0]

    # 添加一个矩形类型的 AutoShape
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 400, 300)
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # 向矩形添加 TextFrame
    ashp.add_text_frame("Aspose TextBox")
    port = ashp.text_frame.paragraphs[0].portions[0]
    pf = port.portion_format
    pf.font_height = 50

    # 启用 inner_shadow_effect    
    ef = pf.effect_format
    ef.enable_inner_shadow_effect()

    # 设置所有必要参数
    ef.inner_shadow_effect.blur_radius = 8.0
    ef.inner_shadow_effect.direction = 90.0
    ef.inner_shadow_effect.distance = 6.0
    ef.inner_shadow_effect.shadow_color.b = 189

    # 设置 ColorType 为 Scheme
    ef.inner_shadow_effect.shadow_color.color_type = slides.ColorType.SCHEME

    # 设置 Scheme Color
    ef.inner_shadow_effect.shadow_color.scheme_color = slides.SchemeColor.ACCENT1

    # 保存演示文稿
    presentation.save("WordArt_out.pptx", slides.export.SaveFormat.PPTX)
```