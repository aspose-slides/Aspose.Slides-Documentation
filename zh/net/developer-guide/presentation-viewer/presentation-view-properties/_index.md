---
title: 演示视图属性
type: docs
url: /net/presentation-view-properties/
keywords: "PowerPoint查看器, 查看器属性, PowerPoint演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "C#或.NET中的PowerPoint演示文稿查看器属性"
---

{{% alert color="primary" %}} 

正常视图由三个内容区域组成：幻灯片本身、侧边内容区域和底部内容区域。与不同内容区域的定位相关的属性。这些信息允许应用程序将其视图状态保存到文件中，以便在重新打开时，视图与最近保存演示文稿时的状态相同。

属性 [**IViewProperties.NormalViewProperties**](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/properties/normalviewproperties) 已添加，以提供对演示文稿正常视图属性的访问。

[**INormalViewProperties**](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties)、[**INormalViewRestoredProperties**](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties) 接口及其子类、[**SplitterBarStateType**](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype) 枚举已添加。

{{% /alert %}} 



## **关于 INormalViewProperties** #

表示正常视图属性。

属性 **ShowOutlineIcons** 指定应用程序是否应在正常视图模式的任何内容区域中显示轮廓内容的图标。

属性 **SnapVerticalSplitter** 指定垂直分隔符在侧边区域足够小时是否应吸附到最小状态。

属性 **PreferSingleView** 指定用户是否更喜欢查看全窗口的单一内容区域，而不是带有三个内容区域的标准正常视图。如果启用，应用程序可以选择在整个窗口中显示其中一个内容区域。

属性 **VerticalBarState** 和 **HorizontalBarState** 指定水平或垂直分隔条应显示的状态。水平分隔条将幻灯片与幻灯片下方的内容区域分开，垂直分隔条将幻灯片与侧边内容区域分开。可能的值为：**SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** 和 **SplitterBarStateType.Restored.**

属性 **RestoredLeft** 和 **RestoredTop** 指定正常视图的顶部或侧边幻灯片区域的大小，当 **SplitterBarStateType.Restored** 值应用于 **VerticalBarState** 和 **HorizontalBarState** 时相应地。

## **关于 INormalViewRestoredProperties** #

指定正常视图的幻灯片区域的大小（当是 RestoredTop 的子级时的宽度，当是 RestoredLeft 的子级时的高度），当区域的恢复大小为可变时（既不最小化也不最大化）。

属性 **DimensionSize** 指定幻灯片区域的大小（当是 restoredTop 的子级时的宽度，当是 restoredLeft 的子级时的高度）。

属性 **AutoAdjust** 指定在调整包含视图的窗口大小时，侧边内容区域的大小是否应补偿新大小。

以下示例展示了如何访问演示文稿的 **ViewProperties.NormalViewProperties** 属性。

```c#
//实例化表示演示文稿文件的演示文稿对象
using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```




## **设置默认缩放值**
Aspose.Slides for .NET 现在支持为演示文稿设置默认缩放值，以便在打开演示文稿时，缩放已设置完毕。这可以通过设置演示文稿的 [**ViewProperties**](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) 来完成。幻灯片视图属性以及 [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/properties/notesviewproperties) 可以通过编程设置。在本主题中，我们将通过示例来看如何设置 Aspose.Slides 中演示文稿的视图属性。

为设置视图属性，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例
2. 设置演示文稿的视图 [Properties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties)
3. 将演示文稿写入 PPTX 文件

在以下示例中，我们为幻灯片视图和备注视图设置了缩放值。

```c#
// 实例化一个表示演示文稿文件的 Presentation 对象
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // 设置演示文稿的视图属性

    presentation.ViewProperties.SlideViewProperties.Scale = 100; // 幻灯片视图的缩放值（百分比）
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // 备注视图的缩放值（百分比） 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```



## **设置视图属性**
为设置视图属性，请按照以下步骤操作：

1. 创建 Presentation 类的实例。
2. 设置演示文稿的视图属性。
3. 将演示文稿写入 PPTX 文件。

在以下示例中，我们为幻灯片视图和备注视图设置了缩放值。

```c#
// 实例化一个表示演示文稿文件的 Presentation 对象
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // 设置演示文稿的视图属性

    presentation.ViewProperties.SlideViewProperties.Scale = 100; // 幻灯片视图的缩放值（百分比）
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // 备注视图的缩放值（百分比） 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```