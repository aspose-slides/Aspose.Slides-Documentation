---
title: 检索并更新 C++ 中的演示文稿视图属性
linktitle: 视图属性
type: docs
weight: 80
url: /zh/cpp/presentation-view-properties/
keywords: 
- 视图属性
- 普通视图
- 大纲内容
- 大纲图标
- 捕捉垂直拆分条
- 单视图
- 栏状态
- 尺寸大小
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

普通视图由三个内容区域组成：幻灯片本身、侧边内容区域和底部内容区域。有关不同内容区域定位的属性。这些信息允许应用程序将其视图状态保存到文件中，以便重新打开时视图保持与上次保存时相同的状态。

已添加方法[IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_normalviewproperties/)以提供对演示文稿普通视图属性的访问。

已添加[INormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/)接口及其后代，以及[SplitterBarStateType](https://reference.aspose.com/slides/cpp/aspose.slides/splitterbarstatetype/)枚举。

{{% /alert %}} 

## **关于 INormalViewProperties**

表示普通视图属性。

属性**ShowOutlineIcons**指定在普通视图模式的任何内容区域显示大纲内容时，应用程序是否应显示图标。

属性**SnapVerticalSplitter**指定当侧边区域足够小时，垂直拆分条是否应捕捉到最小化状态。

属性**PreferSingleView**指定用户是否更倾向于在整个窗口中仅显示单个内容区域，而不是具有三个内容区域的标准普通视图。如果启用，应用程序可能会选择在整个窗口中显示其中一个内容区域。

属性**VerticalBarState**和**HorizontalBarState**指定水平或垂直拆分条应显示的状态。水平拆分条将幻灯片与幻灯片下方的内容区域分隔，垂直拆分条将幻灯片与侧边内容区域分隔。可能的值有：**SplitterBarStateType.Minimized**、**SplitterBarStateType.Maximized**和**SplitterBarStateType.Restored**。

属性**RestoredLeft**和**RestoredTop**指定在**VerticalBarState**和**HorizontalBarState**分别应用**SplitterBarStateType.Restored**值时，普通视图的顶部或侧边幻灯片区域的大小。

## **关于恢复 INormalViewProperties**

指定普通视图中幻灯片区域的大小（作为RestoredTop的子对象时为宽度，作为RestoredLeft的子对象时为高度），当该区域处于可变的恢复大小（既非最小化也非最大化）时。

属性**DimensionSize**指定幻灯片区域的大小（作为restoredTop的子对象时为宽度，作为restoredLeft的子对象时为高度）。

属性**AutoAdjust**指定在调整包含视图的窗口大小时，侧边内容区域的大小是否应补偿新的尺寸。

下面的示例展示了如何访问演示文稿的**ViewProperties.NormalViewProperties**属性。
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

Aspose.Slides for C++ 现在支持为演示文稿设置默认缩放值，以便在打开演示文稿时已设置缩放。这可以通过设置演示文稿的[ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/)来实现。幻灯片视图属性以及[get_NotesViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_notesviewproperties/)都可以以编程方式设置。在本主题中，我们将通过示例演示如何在 Aspose.Slides 中设置演示文稿的视图属性。

为了设置视图属性，请按以下步骤操作：

1. 创建一个[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)类的实例
1. 设置演示文稿的视图[Properties](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/)
1. 将演示文稿写入为 PPTX 文件

在以下示例中，我们已为幻灯片视图以及备注视图设置了缩放值。
``` cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// 设置演示文稿的视图属性
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // 幻灯片视图的缩放值（百分比）
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // 备注视图的缩放值（百分比）

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```


## **常见问题**

**我可以为演示文稿的不同章节设置不同的视图设置吗？**

[视图设置](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/)在演示文稿级别定义（[普通视图](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[幻灯片视图](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/get_slideviewproperties/))，而非按章节定义，因此在打开文档时整个文档使用同一组参数。

**我可以为不同的用户预定义不同的视图状态吗？**

不能。设置存储在文件中并且是共享的。查看器应用程序可以尊重用户偏好，但文件本身只包含一组视图属性。

**我可以准备一个带有预定义视图属性的模板，以便新演示文稿以相同方式打开吗？**

可以。因为[视图属性](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/)存储在演示文稿级别，您可以将它们嵌入模板，并从该模板创建新文档，以获得相同的初始视图配置。