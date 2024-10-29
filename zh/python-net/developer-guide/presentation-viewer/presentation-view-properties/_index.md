---
title: 演示视图属性
type: docs
url: /zh/python-net/presentation-view-properties/
keywords: "PowerPoint 观察者，观察属性，PowerPoint 演示文稿，Python，Aspose.Slides for Python via .NET"
description: "Python 中的 PowerPoint 演示文稿观察者属性"
---

{{% alert color="primary" %}} 

正常视图由三个内容区域组成：幻灯片本身，侧边内容区域和底部内容区域。与不同内容区域的定位相关的属性。这些信息允许应用程序将其视图状态保存到文件中，以便在重新打开时视图与上次保存演示文稿时的状态相同。

属性 [**IViewProperties.NormalViewProperties**](https://reference.aspose.com/slides/python-net/aspose.slides/iviewproperties/) 已添加以提供对演示文稿正常视图属性的访问。

[**INormalViewProperties**](https://reference.aspose.com/slides/python-net/aspose.slides/inormalviewproperties/)、[**INormalViewRestoredProperties**](https://reference.aspose.com/slides/python-net/aspose.slides/inormalviewrestoredproperties/) 接口及其子类，[**SplitterBarStateType**](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) 枚举已被添加。

{{% /alert %}} 



## **关于 INormalViewProperties** 

表示正常视图属性。

属性 **ShowOutlineIcons** 指定应用程序是否应在正常视图模式的任何内容区域中显示大纲内容的图标。

属性 **SnapVerticalSplitter** 指定垂直分隔符在侧边区域足够小的时候是否应固定在最小化状态。

属性 **PreferSingleView** 指定用户是否更喜欢查看全窗口单内容区域，而不是标准的三个内容区域的正常视图。如果启用，应用程序可以选择在整个窗口中显示一个内容区域。

属性 **VerticalBarState** 和 **HorizontalBarState** 指定水平或垂直分隔条应显示的状态。水平分隔条将幻灯片与幻灯片下方的内容区域分开，垂直分隔条将幻灯片与侧边内容区域分开。可能的值是：**SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** 和 **SplitterBarStateType.Restored**。

属性 **RestoredLeft** 和 **RestoredTop** 指定当 **VerticalBarState** 和 **HorizontalBarState** 应用 **SplitterBarStateType.Restored** 值时，正常视图的顶部或侧面幻灯片区域的大小。



## **关于 INormalViewRestoredProperties** 

指定正常视图的幻灯片区域（当为 RestoredTop 的子项时为宽度，当为 RestoredLeft 的子项时为高度）的大小，当区域为变量恢复大小时（既不最小化也不最大化）。

属性 **DimensionSize** 指定幻灯片区域的大小（当为 restoredTop 的子项时为宽度，当为 restoredLeft 的子项时为高度）。

属性 **AutoAdjust** 指定在调整包含视图的窗口大小时，侧边内容区域的大小是否应补偿新的大小。

下面给出的示例展示了如何访问演示文稿的 **ViewProperties.NormalViewProperties** 属性。

```py
import aspose.slides as slides

# 实例化表示演示文稿文件的演示对象
with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```




## **设置默认缩放值**
Aspose.Slides for Python via .NET 现在支持设置演示文稿的默认缩放值，以便在打开演示文稿时，缩放已经设置。这可以通过设置演示文稿的 [**view_properties**](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) 来实现。幻灯片视图属性以及 [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) 可以通过编程设置。在本主题中，我们将通过示例展示如何设置 Aspose.Slides 中的演示文稿视图属性。

为了设置视图属性，请遵循以下步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例
1. 设置演示文稿的视图 [Properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/)
1. 将演示文稿写入 PPTX 文件

下面给出的示例中，我们为幻灯片视图以及注释视图设置了缩放值。

```py
import aspose.slides as slides

# 实例化表示演示文稿文件的演示对象
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # 设置演示文稿的视图属性
    presentation.view_properties.slide_view_properties.scale = 100 # 幻灯片视图的缩放值（以百分比为单位）
    presentation.view_properties.notes_view_properties.scale = 100 # 注释视图的缩放值（以百分比为单位）

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```



## **设置视图属性**
为了设置视图属性，请遵循以下步骤：

1. 创建一个演示文稿类的实例。
1. 设置演示文稿的视图属性。
1. 将演示文稿写入 PPTX 文件。

下面给出的示例中，我们为幻灯片视图以及注释视图设置了缩放值。

```py
import aspose.slides as slides

# 实例化表示演示文稿文件的演示对象
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # 设置演示文稿的视图属性
    presentation.view_properties.slide_view_properties.scale = 100 # 幻灯片视图的缩放值（以百分比为单位）
    presentation.view_properties.notes_view_properties.scale = 100 # 注释视图的缩放值（以百分比为单位）

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```