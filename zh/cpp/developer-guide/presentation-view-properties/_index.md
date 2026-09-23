---
title: 在 C++ 中检索和更新演示文稿视图属性
linktitle: 视图属性
type: docs
weight: 80
url: /zh/cpp/presentation-view-properties/
keywords:
- 视图属性
- 普通视图
- 大纲内容
- 大纲图标
- 垂直拆分条自动折叠
- 单视图
- 条状态
- 尺寸大小
- 自动调整
- 默认缩放
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "发现 Aspose.Slides for C++ 的视图属性，以自定义 PPT、PPTX 和 ODP 幻灯片格式——调整布局、缩放级别和显示设置。"
---
## **介绍**

普通视图由三个内容区域组成：幻灯片本身、侧边内容区域和底部内容区域。有关不同内容区域定位的属性。这些信息允许应用程序将其视图状态保存到文件中，以便重新打开时视图保持在上次保存演示文稿时的相同状态。

已添加方法 [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) 以提供对演示文稿普通视图属性的访问。

已添加 [INormalViewProperties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/inormalviewproperties/)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/inormalviewrestoredproperties/) 接口及其派生类，以及 [SplitterBarStateType](https://reference.aspose.com/slides/zh/cpp/aspose.slides/splitterbarstatetype/) 枚举。

## **关于 INormalViewProperties**

表示普通视图属性。

属性 **ShowOutlineIcons** 指定在普通视图模式的任何内容区域显示大纲内容时，应用程序是否应显示图标。

属性 **SnapVerticalSplitter** 指定当侧边区域足够小且垂直拆分条应是否自动折叠至最小化状态。

属性 **PreferSingleView** 指定用户是否更倾向于在整个窗口中仅显示单个内容区域，而不是具有三个内容区域的标准普通视图。如果启用，应用程序可能会选择在整个窗口中显示其中一个内容区域。

属性 **VerticalBarState** 和 **HorizontalBarState** 指定水平或垂直拆分条应显示的状态。水平拆分条将幻灯片与幻灯片下方的内容区域分开，垂直拆分条将幻灯片与侧边内容区域分开。可能的值有：**SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** 和 **SplitterBarStateType.Restored**。

属性 **RestoredLeft** 和 **RestoredTop** 指定在 **VerticalBarState** 和 **HorizontalBarState** 分别使用 **SplitterBarStateType.Restored** 值时，普通视图中侧边或顶部幻灯片区域的大小。

## **关于恢复 INormalViewProperties**

指定普通视图中幻灯片区域（当为 RestoredTop 的子项时为宽度，当为 RestoredLeft 的子项时为高度）的大小，当该区域处于可变的恢复大小（既非最小化也非最大化）时。

属性 **DimensionSize** 指定幻灯片区域的大小（当为 restoredTop 的子项时为宽度，当为 restoredLeft 的子项时为高度）。

属性 **AutoAdjust** 指定在调整包含视图的应用程序窗口大小时，侧边内容区域的大小是否应自动补偿新的大小。

下面的示例展示了如何访问演示文稿的 **ViewProperties.NormalViewProperties** 属性。

```cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

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

Aspose.Slides for C++ 现在支持为演示文稿设置默认缩放值，以便在打开演示文稿时已设置缩放。可以通过设置演示文稿的 [ViewProperties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/viewproperties/) 来实现。幻灯片视图属性以及 [get_NotesViewProperties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/viewproperties/get_notesviewproperties/) 都可以通过编程方式设置。在本主题中，我们将通过示例展示如何在 Aspose.Slides 中设置演示文稿的视图属性。

要设置视图属性，请按以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 类的实例
1. 设置演示文稿的视图 [Properties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/viewproperties/)
1. 将演示文稿写入 PPTX 文件

在下面的示例中，我们已为幻灯片视图和备注视图设置了缩放值。

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// 设置演示文稿的视图属性
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // 幻灯片视图的缩放值（百分比）
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // 备注视图的缩放值（百分比）

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **设置网格间距**

使用 [Presentation::get_ViewProperties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_viewproperties/) 访问整个演示文稿的视图设置。方法 [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iviewproperties/get_gridspacing/) 和 [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iviewproperties/set_gridspacing/) 读取或更改底层编辑网格的间隔。此设置适用于整个演示文稿，而不是单个幻灯片。网格间距以点为单位，72 点等于一英寸。请使用正值，如 API 文档所要求。

以下示例打开现有的 `demo.pptx`，打印其当前网格间距，设置四分之一英寸的间隔，并保存结果。

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto gridSpacing = presentation->get_ViewProperties()->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

presentation->get_ViewProperties()->set_GridSpacing(18.0f);
presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

网格不同于 [drawing guides](/slides/zh/cpp/drawing-guides/)。网格间距控制规则的间隔，而绘图参考线是单独定位的水平或垂直对齐线。添加、移动或清除绘图参考线不会更改网格间距。

网格和绘图参考线都是编辑辅助工具。它们不会作为幻灯片内容在 PDF、图像、SVG 或放映中渲染。存储网格间距并不保证编辑器会显示网格：其可见性也取决于查看器或编辑器的偏好设置。

## **打开演示文稿时显示或隐藏批注**

使用 [Presentation::get_ViewProperties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_viewproperties/) 访问整个演示文稿的视图设置。使用 [IViewProperties::get_ShowComments](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iviewproperties/get_showcomments/) 和 [IViewProperties::set_ShowComments](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iviewproperties/set_showcomments/) 存储在打开 PowerPoint 或其他兼容编辑器时是否应显示批注的偏好设置。

此设置仅控制存储的视图偏好。它不会添加、删除、编辑或解决批注。隐藏批注会保留其内容、作者、位置、回复和状态。请参阅 [Presentation Comments](/slides/zh/cpp/presentation-comments/) 了解更改批注本身的操作。

下面的示例需要一个包含批注的现有 `comments.pptx`。它打印当前的可见性设置，请求隐藏批注，并在不删除任何批注的情况下保存新的 PPTX。它还使用 [IViewProperties::set_LastView](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iviewproperties/set_lastview/) 与 [ViewType::SlideView](https://reference.aspose.com/slides/zh/cpp/aspose.slides/viewtype/) 配置初始编辑视图以及批注可见性。

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
auto showComments = presentation->get_ViewProperties()->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

presentation->get_ViewProperties()->set_ShowComments(NullableBool::False);
presentation->get_ViewProperties()->set_LastView(ViewType::SlideView);
presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

此设置不决定批注是否包含在 PDF、HTML、图像、备注或讲义导出中。请分别配置相关导出特定的选项。

## **常见问题**

**为什么重新打开演示文稿后网格不可见？**

文件存储了网格间距，但编辑器控制是否显示网格。检查编辑器的网格可见性设置。

**清除绘图参考线会改变网格间距吗？**

不会。绘图参考线和网格间距是独立的设置。清除参考线不会改变已存储的网格间隔。

**我可以为演示文稿的不同章节设置不同的视图设置吗？**

[视图设置](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_viewproperties/) 在演示文稿级别定义（[Normal View](https://reference.aspose.com/slides/zh/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/zh/cpp/aspose.slides/viewproperties/get_slideviewproperties/)），而不是按章节。因此打开文档时，整个文档使用同一套参数。

**我可以为不同的用户预定义不同的视图状态吗？**

不能。设置存储在文件中并共享。查看器应用程序可能会遵循用户偏好，但文件本身只包含一套视图属性。

**我可以准备一个预定义视图属性的模板，使新演示文稿以相同方式打开吗？**

可以。因为[view properties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_viewproperties/) 存储在演示文稿级别，您可以在模板中嵌入它们，从而使用相同的初始视图配置创建新文档。