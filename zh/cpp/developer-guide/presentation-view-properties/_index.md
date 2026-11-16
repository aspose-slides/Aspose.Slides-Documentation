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
- 捕捉垂直分割条
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
description: "使用 Aspose.Slides for C++ 在 PowerPoint 演示文稿中配置普通视图布局、幻灯片和备注缩放、网格间距以及批注可见性。"
---
## **简介**

在 PowerPoint 的普通视图中，幻灯片位于缩略图或大纲的侧窗格与下方的备注窗格之间。Aspose.Slides for C++ 通过 [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) 公开演示文稿保存的编辑首选项。这些包括窗格布局、缩放级别、网格间距和批注可见性。

## **关于 INormalViewProperties**

使用 [get_NormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) 访问 [INormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/) 接口。[set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) 控制是否在大纲视图中在幻灯片标题旁显示图标。[set_SnapVerticalSplitter](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_snapverticalsplitter/) 使侧窗格在用户收窄时自动捕捉到最小化状态。[set_PreferSingleView](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_prefersingleview/) 表示首选在整个窗口中显示单个窗格。

[set_VerticalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_verticalbarstate/) 控制侧窗格与幻灯片之间的分割条。[set_HorizontalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_horizontalbarstate/) 控制备注窗格上方的分割条。这两者都接受 [SplitterBarStateType](https://reference.aspose.com/slides/cpp/aspose.slides/splitterbarstatetype/) 的值 `Minimized`、`Maximized` 或 `Restored`。

## **关于 恢复 INormalViewProperties**

当分割条被恢复时，[get_RestoredLeft](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredleft/) 提供侧窗格保存的尺寸，而 [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) 提供上部幻灯片区域保存的尺寸。这两者都公开 [INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/)。其 [set_DimensionSize](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_dimensionsize/) 方法接受 0 到 100 的百分比，而 [set_AutoAdjust](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_autoadjust/) 控制编辑器在窗口大小调整时是否自动调整尺寸。

此示例更新现有演示文稿。它恢复水平分割条，将通过 [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) 暴露的上部幻灯片区域大小设置为 80% 并启用自动调整，并将垂直分割条最大化。它还通过 [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) 为大纲视图启用轮廓图标。

```cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto normalView = presentation->get_ViewProperties()->get_NormalViewProperties();
normalView->set_HorizontalBarState(SplitterBarStateType::Restored);
normalView->set_VerticalBarState(SplitterBarStateType::Maximized);
auto restoredTop = normalView->get_RestoredTop();
restoredTop->set_AutoAdjust(true);
restoredTop->set_DimensionSize(80.0f);
normalView->set_ShowOutlineIcons(true);

presentation->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **设置默认缩放值**

[get_SlideViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_slideviewproperties/) 和 [get_NotesViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_notesviewproperties/) 为编辑器存储独立的缩放设置。这些设置不会影响幻灯片尺寸、幻灯片放映播放或图像导出分辨率。

此示例打开现有演示文稿，并使用 [set_VariableScale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_variablescale/) 启用自动缩放以将幻灯片适配编辑窗口。对于备注页，它禁用自动缩放并使用 [set_Scale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_scale/) 将缩放设置为固定的 80%。

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
viewProperties->get_SlideViewProperties()->set_VariableScale(true);
auto notesView = viewProperties->get_NotesViewProperties();
notesView->set_VariableScale(false);
notesView->set_Scale(80);

presentation->Save(u"zoom.pptx", SaveFormat::Pptx);
```

## **设置网格间距**

[set_GridSpacing](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_gridspacing/) 设置整个演示文稿中编辑网格线之间的距离。它接受以点为单位的正值，1 英寸等于 72 点。此示例打印现有演示文稿的当前间距，并通过将间隔设置为 18 点来保存四分之一英寸的网格。

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
auto gridSpacing = viewProperties->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

viewProperties->set_GridSpacing(18.0f);

presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

网格以固定间隔重复。[绘图指南](/slides/zh/cpp/drawing-guides/) 标记单独的水平或垂直位置。两者都是编辑辅助，仅在显示它们的编辑器中出现。幻灯片放映以及导出为 PDF、图像或 SVG 时都会省略它们。

## **打开演示文稿时显示或隐藏批注**

[set_ShowComments](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_showcomments/) 保存兼容编辑器在打开演示文稿时使用的首选项。对于包含批注的现有演示文稿，此示例打印当前设置并保存一个隐藏批注的副本。它还使用 [ViewType::SlideView](https://reference.aspose.com/slides/cpp/aspose.slides/viewtype/) 调用 [set_LastView](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_lastview/)，使副本以幻灯片视图打开。

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <ViewType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"comments.pptx");

auto viewProperties = presentation->get_ViewProperties();
auto showComments = viewProperties->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

viewProperties->set_ShowComments(NullableBool::False);
viewProperties->set_LastView(ViewType::SlideView);

presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

隐藏批注会保留其文本、作者、位置、回复和状态。要更改批注本身，请参阅 [演示文稿批注](/slides/zh/cpp/presentation-comments/)。导出设置决定批注是否出现在 PDF、HTML、图像、备注或讲义中。

## **常见问题**

**为什么重新打开演示文稿时网格被隐藏？**

演示文稿存储了网格间隔。要查看网格，请在编辑器中启用网格可见性。

**清除绘图指南会改变网格间距吗？**

不会。添加、移动或清除指南都不会改变网格间隔。

**演示文稿的不同章节可以有不同的视图设置吗？**

不能。[Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) 适用于整个演示文稿。

**我可以为不同用户保存不同的视图设置吗？**

文件只为所有人存储一套视图属性。编辑器可能还会应用用户的本地首选项。

**我可以在模板中保存视图设置吗？**

可以。使用该模板创建的演示文稿会继承其保存的视图设置。