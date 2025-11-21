---
title: 在 Python 中创建和应用 WordArt 效果
linktitle: WordArt
type: docs
weight: 110
url: /zh/python-net/wordart/
keywords:
- WordArt
- 创建 WordArt
- WordArt 模板
- WordArt 效果
- 阴影效果
- 显示效果
- 发光效果
- WordArt 变形
- 3D 效果
- 外阴影效果
- 内阴影效果
- Python
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Python via .NET 中创建和自定义 WordArt 效果。此步骤指南帮助开发者在 Python 中使用时尚、专业的文本增强演示文稿。"
---

## **关于 WordArt?**
WordArt（或 Word Art）是一项功能，允许您对文本应用效果，使其突出。使用 WordArt，例如，您可以对文本进行描边或填充颜色（或渐变），添加 3D 效果等。您还可以对文本的形状进行倾斜、弯曲和拉伸。 

{{% alert color="primary" %}} 

WordArt 允许您像对待图形对象一样处理文本。WordArt 包含对文本进行的效果或特殊修改，使其更具吸引力或更显眼。 

{{% /alert %}} 

**WordArt 在 Microsoft PowerPoint 中**

要在 Microsoft PowerPoint 中使用 WordArt，必须选择预定义的 WordArt 模板之一。WordArt 模板是一组将应用于文本或其形状的效果。 

**WordArt 在 Aspose.Slides 中**

在 Aspose.Slides for Python via .NET 20.10 中，我们实现了对 WordArt 的支持，并在后续的 Aspose.Slides for Python via .NET 版本中对该功能进行了改进。 

使用 Aspose.Slides for Python via .NET，您可以在 Python 中轻松创建自己的 WordArt 模板（单个效果或组合效果），并将其应用于文本。 

## 创建简单的 WordArt 模板并将其应用于文本

**使用 Aspose.Slides** 

首先，我们使用以下 Python 代码创建一个简单的文本： 
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

现在，我们通过以下代码将文本的字体高度设置为更大的值，以使效果更明显： 
```py 
    fontData = slides.FontData("Arial Black")
    portion.portion_format.latin_font = fontData
    portion.portion_format.font_height = 36
```


**使用 Microsoft PowerPoint**

在 Microsoft PowerPoint 中打开 WordArt 效果菜单： 

![todo:image_alt_text](image-20200930113926-1.png)

在右侧菜单中，您可以选择预定义的 WordArt 效果；在左侧菜单中，您可以为新 WordArt 指定设置。 

以下是部分可用的参数或选项： 

![todo:image_alt_text](image-20200930114015-3.png)

**使用 Aspose.Slides** 

这里，我们使用以下代码将 SmallGrid 图案颜色应用于文本，并添加宽度为 1 的黑色文本边框： 
```py 
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID
                
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```


生成的文本： 

![todo:image_alt_text](image-20200930114108-4.png)

## 应用其他 WordArt 效果

**使用 Microsoft PowerPoint** 

在程序界面中，您可以将这些效果应用于文本、文本块、形状或类似元素： 

![todo:image_alt_text](image-20200930114129-5.png)

例如，可以对文本应用阴影、反射和发光效果；对文本块应用 3D 格式和 3D 旋转效果；对形状对象应用柔边属性（即使未设置 3D 格式属性，它仍然有效）。 

### 应用阴影效果

这里，我们仅针对文本设置相关属性。我们使用以下 Python 代码对文本应用阴影效果： 
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


Aspose.Slides API 支持三种阴影类型：OuterShadow、InnerShadow 和 PresetShadow。 

使用 PresetShadow，您可以为文本应用预设值的阴影。 

**使用 Microsoft PowerPoint** 

在 PowerPoint 中，您只能使用一种阴影类型。示例： 

![todo:image_alt_text](image-20200930114225-6.png)

**使用 Aspose.Slides** 

Aspose.Slides 实际上允许一次同时应用两种阴影：InnerShadow 和 PresetShadow。 

**注意：** 

- 当同时使用 OuterShadow 和 PresetShadow 时，仅会应用 OuterShadow 效果。 
- 如果同时使用 OuterShadow 和 InnerShadow，最终或实际应用的效果取决于 PowerPoint 版本。例如，在 PowerPoint 2013 中，效果会叠加两次；而在 PowerPoint 2007 中，仅会应用 OuterShadow 效果。 

### 应用显示效果到文本

我们使用以下 Python 示例为文本添加显示效果： 
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


### 应用发光效果到文本

我们使用以下代码为文本应用发光效果，使其更亮或更突出： 
```py 
    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.r = 255
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```


操作结果： 

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

您可以更改阴影、显示和发光的参数。效果属性会单独设置到文本的每个部分。 

{{% /alert %}} 

### 在 WordArt 中使用变形

我们通过以下代码使用 Transform 属性（适用于整个文本块）： 
```py 
textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```


结果： 

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Microsoft PowerPoint 和 Aspose.Slides for Python via .NET 都提供一定数量的预定义变形类型。 

{{% /alert %}} 

**使用 PowerPoint** 

要访问预定义的变形类型，请依次点击：**Format** -> **TextEffect** -> **Transform** 

**使用 Aspose.Slides** 

要选择变形类型，请使用 TextShapeType 枚举。 

### 为文本和形状应用 3D 效果

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


生成的文本及其形状： 

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


操作结果： 

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

将 3D 效果应用于文本或其形状以及效果之间的交互遵循特定规则。 

考虑文本及其所在形状的场景。3D 效果包含 3D 对象的表示以及对象所放置的场景。 

- 当图形和文本均设置了场景时，图形场景具有更高优先级，文本场景将被忽略。 
- 当图形没有自己的场景但具有 3D 表示时，使用文本场景。 
- 否则——即当形状本身没有 3D 效果时，形状保持平面，仅对文本应用 3D 效果。 

这些描述与 [ThreeDFormat.LightRig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) 和 [ThreeDFormat.Camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) 属性相关。 

{{% /alert %}} 

## **对文本应用外阴影效果**
Aspose.Slides for Python via .NET 提供 [**IOuterShadow**](https://reference.aspose.com/slides/python-net/aspose.slides.effects/ioutershadow/) 和 [**IInnerShadow**](https://reference.aspose.com/slides/python-net/aspose.slides.effects/iinnershadow/) 类，允许您对 TextFrame 中的文本应用阴影效果。请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 使用索引获取幻灯片的引用。  
3. 向幻灯片添加 Rectangle 类型的 AutoShape。  
4. 访问与 AutoShape 关联的 TextFrame。  
5. 将 AutoShape 的 FillType 设置为 NoFill。  
6. 实例化 OuterShadow 类  
7. 设置阴影的 BlurRadius。  
8. 设置阴影的 Direction  
9. 设置阴影的 Distance。  
10. 将 RectanglelAlign 设置为 TopLeft。  
11. 将阴影的 PresetColor 设置为 Black。  
12. 将演示文稿保存为 PPTX 文件。  

下面的 Python 示例代码实现了上述步骤，展示了如何对文本应用外阴影效果： 
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    # 获取幻灯片的引用
    sld = pres.slides[0]

    # 添加矩形类型的 AutoShape
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # 为矩形添加 TextFrame
    ashp.add_text_frame("Aspose TextBox")

    # 禁用形状填充，以便获取文本的阴影
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # 添加外部阴影并设置所有必要参数
    ashp.effect_format.enable_outer_shadow_effect()
    shadow = ashp.effect_format.outer_shadow_effect
    shadow.blur_radius = 4.0
    shadow.direction = 45
    shadow.distance = 3
    shadow.rectangle_align = slides.RectangleAlignment.TOP_LEFT
    shadow.shadow_color.preset_color = slides.PresetColor.BLACK

    #写入演示文稿到磁盘
    pres.save("pres_out.pptx", slides.export.SaveFormat.PPTX)
```


## **对形状应用内阴影效果**
请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 获取幻灯片的引用。  
3. 添加 Rectangle 类型的 AutoShape。  
4. 启用 InnerShadowEffect。  
5. 设置所有必要的参数。  
6. 将 ColorType 设置为 Scheme。  
7. 设置 Scheme Color。  
8. 将演示文稿保存为 [PPTX](https://docs.fileformat.com/presentation/pptx/) 文件。  

以下示例代码（基于上述步骤）展示了如何在 Python 中为两个形状添加连接线： 
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    # 获取幻灯片的引用
    slide = presentation.slides[0]

    # 添加矩形类型的 AutoShape
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 400, 300)
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # 为矩形添加 TextFrame
    ashp.add_text_frame("Aspose TextBox")
    port = ashp.text_frame.paragraphs[0].portions[0]
    pf = port.portion_format
    pf.font_height = 50

    # 启用 inner_shadow_effect    
    ef = pf.effect_format
    ef.enable_inner_shadow_effect()

    # 设置所有必要的参数
    ef.inner_shadow_effect.blur_radius = 8.0
    ef.inner_shadow_effect.direction = 90.0
    ef.inner_shadow_effect.distance = 6.0
    ef.inner_shadow_effect.shadow_color.b = 189

    # 将 ColorType 设置为 Scheme
    ef.inner_shadow_effect.shadow_color.color_type = slides.ColorType.SCHEME

    # 设置方案颜色
    ef.inner_shadow_effect.shadow_color.scheme_color = slides.SchemeColor.ACCENT1

    # 保存演示文稿
    presentation.save("WordArt_out.pptx", slides.export.SaveFormat.PPTX)
```


## **常见问题**

**我可以在不同字体或文字系统（例如阿拉伯语、中文）中使用 WordArt 效果吗？**  
是的，Aspose.Slides 支持 Unicode，兼容所有主流字体和文字系统。无论语言如何，都可以对文字应用 WordArt 效果，例如阴影、填充和描边，不过字体的可用性和渲染效果可能取决于系统已安装的字体。  

**我可以将 WordArt 效果应用于母版幻灯片元素吗？**  
是的，您可以将 WordArt 效果应用于母版幻灯片上的形状，包括标题占位符、页脚或背景文字。对母版布局所做的更改会同步到所有使用该母版的幻灯片。  

**WordArt 效果会影响演示文稿的文件大小吗？**  
会有一点影响。阴影、发光和渐变填充等 WordArt 效果会因额外的格式化元数据略微增大文件体积，但差异通常可以忽略不计。  

**我可以在不保存演示文稿的情况下预览 WordArt 效果的结果吗？**  
是的，您可以使用 [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) 或 [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) 类的 `get_image` 方法，将包含 WordArt 的幻灯片渲染为图像（例如 PNG、JPEG）。这样即可在内存中或屏幕上预览效果，而无需保存或导出完整的演示文稿。