---
title: 在 C++ 中检索并更新演示文稿视图属性
linktitle: 视图属性
type: docs
weight: 80
url: /zh/cpp/presentation-view-properties/
keywords:
- 视图属性
- 普通视图
- 大纲内容
- 大纲图标
- 捕捉垂直分隔条
- 单视图
- 分割条状态
- 维度大小
- 自动调整
- 默认缩放
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "了解 Aspose.Slides for C++ 的视图属性，以自定义 PPT、PPTX 和 ODP 幻灯片格式——调整布局、缩放级别和显示设置。"
---

{{% alert color="primary" %}} 

普通视图由三个内容区域组成：幻灯片本身、侧边内容区域和底部内容区域。与不同内容区域定位相关的属性。这些信息使应用程序能够将视图状态保存到文件中，从而在重新打开时视图保持为上次保存时的状态。

已添加方法[IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_view_properties#aa8add44edf3e3ac578e0bf8f32617b06)以提供对演示文稿普通视图属性的访问。

已添加[INormalViewProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_normal_view_properties)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_normal_view_restored_properties)接口及其子类，以及[SplitterBarStateType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#ac12b36e68eb35cfd6ae026915e071950)枚举。

{{% /alert %}} 

## **关于 INormalViewProperties**

表示普通视图属性。

属性 **ShowOutlineIcons** 指定应用程序在普通视图模式的任意内容区域显示大纲内容时是否应显示图标。

属性 **SnapVerticalSplitter** 指定当侧边区域足够小时时，垂直分割条是否应捕捉至最小化状态。

属性 **PreferSingleView** 指定用户是否更倾向于在全窗口内仅显示单一内容区域，而不是标准的包含三个内容区域的普通视图。如果启用，应用程序可能会选择在整个窗口中显示其中一个内容区域。

属性 **VerticalBarState** 和 **HorizontalBarState** 指定水平或垂直分割条应显示的状态。水平分割条将幻灯片与幻灯片下方的内容区域分隔，垂直分割条将幻灯片与侧边内容区域分隔。可能的取值为：**SplitterBarStateType.Minimized、SplitterBarStateType.Maximized** 和 **SplitterBarStateType.Restored**。

属性 **RestoredLeft** 和 **RestoredTop** 在 **VerticalBarState** 和 **HorizontalBarState** 均使用 **SplitterBarStateType.Restored** 值时，指定普通视图中顶部或侧边幻灯片区域的尺寸。

## **关于恢复 INormalViewProperties**

指定普通视图中幻灯片区域的尺寸（当为 RestoredTop 的子项时为宽度，作为 RestoredLeft 的子项时为高度），当该区域处于可变的恢复大小（既非最小化也非最大化）时。

属性 **DimensionSize** 指定幻灯片区域的大小（当为 restoredTop 的子项时为宽度，作为 restoredLeft 的子项时为高度）。

属性 **AutoAdjust** 指定在应用程序中调整包含视图的窗口大小时，侧边内容区域的尺寸是否应随之补偿新的大小。

下面给出了一个示例，展示如何访问演示文稿的 **ViewProperties.NormalViewProperties** 属性。
``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// 恢复演示文稿的视图属性
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```


## **设置默认缩放值**

Aspose.Slides for C++ 现在支持为演示文稿设置默认缩放值，使得打开演示文稿时缩放已预设。可以通过设置演示文稿的 [ViewProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties) 来实现。幻灯片视图属性以及 [get_NotesViewProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties#a86ad6559c9c0768d8210fdb86c86cf98) 都可以以编程方式设置。在本主题中，我们将通过示例演示如何在 Aspose.Slides 中设置演示文稿的视图属性。

要设置视图属性，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例
1. 设置演示文稿的视图 [Properties](https://reference.aspose.com/slides/cpp/class/aspose.slides.view_properties)
1. 将演示文稿写入为 PPTX 文件

在下面的示例中，我们已经为幻灯片视图和备注视图设置了缩放值。
``` cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// 设置演示文稿的视图属性
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // 幻灯片视图的缩放值（百分比）
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // 备注视图的缩放值（百分比） 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```


## **常见问题**

**我可以为演示文稿的不同章节设置不同的视图设置吗？**

[View settings](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) 在演示文稿层级定义（[Normal View](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_slideviewproperties/)），而不是针对各章节。因此打开文档时，整篇文档使用同一套参数。

**我可以为不同用户预定义不同的视图状态吗？**

不能。设置存储在文件中并共享。查看器应用程序可能会尊重用户偏好，但文件本身仅包含一套视图属性。

**我可以准备一个预定义视图属性的模板，使新演示文稿以相同方式打开吗？**

可以。因为 [view properties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) 存储在演示文稿层级，您可以将其嵌入模板中，从而创建的新文档拥有相同的初始视图配置。