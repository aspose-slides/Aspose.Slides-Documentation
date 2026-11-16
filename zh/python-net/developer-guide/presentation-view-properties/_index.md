---
title: 在 Python 中检索和更新演示文稿视图属性
linktitle: 视图属性
type: docs
weight: 80
url: /zh/python-net/presentation-view-properties/
keywords:
- 视图属性
- 普通视图
- 大纲内容
- 大纲图标
- 捕捉垂直分割条
- 单视图
- 栏状态
- 尺寸大小
- 自动调整
- 默认缩放
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 来配置 PowerPoint 演示文稿中的普通视图布局、幻灯片和备注的缩放、网格间距以及批注可见性。"
---
## **介绍**

在 PowerPoint 的普通视图中，幻灯片位于用于缩略图或大纲的侧窗格和下面的备注窗格之间。Aspose.Slides for Python via .NET 通过 [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) 公开演示文稿保存的编辑首选项。这些包括窗格布局、缩放级别、网格间距和批注可见性。

## **关于 NormalViewProperties**

使用 [normal_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/) 访问 [NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/) 对象。[show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) 控制大纲中幻灯片标题旁是否显示图标。[snap_vertical_splitter](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/snap_vertical_splitter/) 使侧窗格在用户收窄时自动抓住并最小化。[prefer_single_view](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/prefer_single_view/) 表示在全窗口中显示单个窗格的偏好。

[vertical_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/vertical_bar_state/) 控制侧窗格与幻灯片之间的分割条。[horizontal_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/horizontal_bar_state/) 控制备注窗格上方的分割条。这两者都接受 [SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) 的值 `MINIMIZED`、`MAXIMIZED` 或 `RESTORED`。

<!-- visual-explanation:presentation-view-properties:start -->
[![概念编辑器将侧面板、幻灯片区域和底部区域分开，并带有标记的垂直和水平分割条。](visual-presentation-view-properties-40ae1765a743.svg)](visual-presentation-view-properties-40ae1765a743.svg)

*在普通视图中，垂直分割条控制侧窗格的宽度。水平分割条控制备注窗格上方的空间。*
<!-- visual-explanation:presentation-view-properties:end -->

## **关于恢复 NormalViewProperties**

当分割条被恢复时，[restored_left](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_left/) 提供侧窗格保存的大小，[restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) 提供上部幻灯片区域保存的大小。这两个属性都公开 [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/)。其 [dimension_size](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/dimension_size/) 属性接受 0 到 100 的百分比，而 [auto_adjust](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/auto_adjust/) 控制在窗口调整大小时编辑器是否自动调整尺寸。

此示例更新现有演示文稿。它恢复水平分割条，将 [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) 设置为 80% 并启用自动调整，并将垂直分割条最大化。它还为大纲视图启用 [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/)。

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    normal_view = presentation.view_properties.normal_view_properties
    normal_view.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    normal_view.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED
    normal_view.restored_top.auto_adjust = True
    normal_view.restored_top.dimension_size = 80
    normal_view.show_outline_icons = True

    presentation.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **设置默认缩放值**

[slide_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/) 和 [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/notes_view_properties/) 为编辑器存储独立的缩放设置。这些设置不会影响幻灯片尺寸、幻灯片放映播放或图像导出分辨率。

此示例打开一个现有演示文稿，并启用 [variable_scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/variable_scale/) 以将幻灯片适配编辑窗口。对于备注页，它禁用自动缩放，并将 [scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/scale/) 设置为固定的 80% 缩放。

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    view_properties.slide_view_properties.variable_scale = True
    view_properties.notes_view_properties.variable_scale = False
    view_properties.notes_view_properties.scale = 80

    presentation.save("zoom.pptx", slides.export.SaveFormat.PPTX)
```

## **设置网格间距**

[grid_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/grid_spacing/) 设置整个演示文稿中编辑网格线之间的距离。它接受以点为单位的正值，1英寸等于 72 点。此示例打印现有演示文稿的当前间距，并通过将间隔设为 18 点来保存四分之一英寸的网格。

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current grid spacing: {view_properties.grid_spacing} points")

    view_properties.grid_spacing = 18.0

    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

网格以固定间隔重复。[绘图指南](/slides/zh/python-net/drawing-guides/) 标记单独的水平或垂直位置。两者都是编辑辅助，仅在能够显示它们的编辑器中出现。幻灯片放映以及导出为 PDF、图像或 SVG 时会省略它们。

## **打开演示文稿时显示或隐藏批注**

[show_comments](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/show_comments/) 存储兼容编辑器在打开演示文稿时使用的首选项。针对带有批注的现有演示文稿，此示例打印当前设置并保存一个隐藏批注的副本。它还将 [last_view](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/last_view/) 设置为 [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/)，使副本以幻灯片视图打开。

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current comment visibility: {view_properties.show_comments}")

    view_properties.show_comments = slides.NullableBool.FALSE
    view_properties.last_view = slides.ViewType.SLIDE_VIEW
    
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

隐藏批注会保留其文本、作者、位置、回复和状态。要更改批注本身，请参阅 [演示文稿批注](/slides/zh/python-net/presentation-comments/)。导出设置控制批注是否出现在 PDF、HTML、图像、备注或讲义中。

## **常见问题**

**为什么重新打开演示文稿时网格会隐藏？**  
演示文稿存储了网格间隔。要查看网格，请在编辑器中启用网格可见性。

**清除绘图指南会改变网格间距吗？**  
不会。添加、移动或清除指南都不会改变网格间隔。

**演示文稿的不同章节可以拥有不同的视图设置吗？**  
不能。[Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) 适用于整个演示文稿。

**我可以为不同用户保存不同的视图设置吗？**  
文件只为所有人存储一套视图属性。编辑器还可能使用用户的本地首选项。

**我可以在模板中保存视图设置吗？**  
可以。基于该模板创建的演示文稿会继承其已保存的视图设置。