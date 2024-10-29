---
title: 演示视图属性
type: docs
url: /zh/cpp/presentation-view-properties/
---

{{% alert color="primary" %}} 

正常视图由三个内容区域组成：幻灯片本身、一个侧边内容区域和一个底部内容区域。与不同内容区域的位置相关的属性。这些信息允许应用程序将其视图状态保存到文件中，以便在重新打开时，视图处于与上次保存演示文稿时相同的状态。

方法 [**IViewProperties::get_NormalViewProperties()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_view_properties#aa8add44edf3e3ac578e0bf8f32617b06) 已添加以提供对演示文稿正常视图属性的访问。 

[**INormalViewProperties**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_normal_view_properties)、[**INormalViewRestoredProperties**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_normal_view_restored_properties)接口及其后代，[**SplitterBarStateType**](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#ac12b36e68eb35cfd6ae026915e071950)枚举已添加。

{{% /alert %}} 

## **关于 INormalViewProperties** #

表示正常视图属性。

属性 **ShowOutlineIcons** 指定当在正常视图模式的任何内容区域显示大纲内容时，应用程序是否应该显示图标。

属性 **SnapVerticalSplitter** 指定当侧边区域足够小时时，垂直分隔条是否应该吸附到最小化状态。

属性 **PreferSingleView** 指定用户是否更倾向于查看全窗口单一内容区域，而不是标准的正常视图（具有三个内容区域）。如果启用，应用程序可以选择在整个窗口中显示其中一个内容区域。

属性 **VerticalBarState** 和 **HorizontalBarState** 指定水平或垂直分隔条应该显示的状态。水平分隔条将幻灯片与幻灯片下方的内容区域分隔开，垂直分隔条将幻灯片与侧边内容区域分隔开。可能的值包括：**SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** 和 **SplitterBarStateType.Restored.**

属性 **RestoredLeft** 和 **RestoredTop** 指定正常视图的顶部或侧面幻灯片区域的大小，当 **SplitterBarStateType.Restored** 值相应地应用于 **VerticalBarState** 和 **HorizontalBarState** 时。 

## **关于 INormalViewRestoredProperties** #

指定正常视图的幻灯片区域的大小（当一个变量的恢复大小区域（既不是最小化也不是最大化）时的宽度和高度（当是 RestoredTop 的子项时，宽度；当是 RestoredLeft 的子项时，高度）。

属性 **DimensionSize** 指定幻灯片区域的大小（当是 restoredTop 的子项时宽度；当是 restoredLeft 的子项时高度）。

属性 **AutoAdjust** 指定当调整包含视图的窗口的大小时，侧边内容区域的大小是否应补偿新大小。

下面的示例展示了如何访问演示文稿的 **ViewProperties.NormalViewProperties** 属性。

``` cpp
// 实例化一个表示演示文稿文件的 Presentation 对象
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **设置默认缩放值**
Aspose.Slides for C++ 现在支持设置演示文稿的默认缩放值，以便在打开演示文稿时，缩放值已被设置。这可以通过设置演示文稿的 [**ViewProperties**](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties) 来实现。幻灯片视图属性以及 [get_NotesViewProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties#a86ad6559c9c0768d8210fdb86c86cf98) 可以通过编程方式进行设置。在本主题中，我们将通过示例来看如何在 Aspose.Slides 中设置演示文稿的视图属性。

为了设置视图属性，请遵循以下步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
2. 设置演示文稿的视图 [Properties](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties)。
3. 将演示文稿写入 PPTX 文件。

在下面给出的示例中，我们为幻灯片视图和备注视图设置了缩放值。

``` cpp
// 实例化一个表示演示文稿文件的 Presentation 对象
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
// 设置演示文稿的视图属性

presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100);
// 幻灯片视图的缩放值（以百分比表示）
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100);
// 备注视图的缩放值（以百分比表示） 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **设置视图属性**
为了设置视图属性，请遵循以下步骤：

1. 创建一个 Presentation 类的实例。
2. 设置演示文稿的视图属性。
3. 将演示文稿写入 PPTX 文件。

在下面给出的示例中，我们为幻灯片视图和备注视图设置了缩放值。

``` cpp
// 实例化一个表示演示文稿文件的 Presentation 对象
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// 设置演示文稿的视图属性
// 幻灯片视图的缩放值（以百分比表示）
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100);
// 备注视图的缩放值（以百分比表示）
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100);

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```