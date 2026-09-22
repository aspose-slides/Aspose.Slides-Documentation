---
title: 检索和更新 C++ 演示文稿视图属性
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
- 条状态
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
## **介绍**

普通视图由三个内容区域组成：幻灯片本身、侧边内容区域和底部内容区域。 与不同内容区域定位相关的属性。 这些信息使应用程序能够将视图状态保存到文件中，以便在重新打开时，视图保持与上次保存演示文稿时相同的状态。

已添加方法[IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iviewproperties/get_normalviewproperties/)以提供对演示文稿普通视图属性的访问。

已添加[INormalViewProperties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/inormalviewproperties/)、[INormalViewRestoredProperties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/inormalviewrestoredproperties/)接口及其派生类、[SplitterBarStateType](https://reference.aspose.com/slides/zh/cpp/aspose.slides/splitterbarstatetype/)枚举。

## **关于 INormalViewProperties**

表示普通视图属性。

属性**ShowOutlineIcons**指定当在普通视图模式的任意内容区域显示大纲内容时，应用程序是否应显示图标。

属性**SnapVerticalSplitter**指定当侧边区域足够小时时，垂直分割条是否应捕捉到最小化状态。

属性**PreferSingleView**指定用户是否更倾向于在整个窗口中查看单个内容区域，而不是具有三个内容区域的标准普通视图。如果启用，应用程序可能会选择在整个窗口中显示其中一个内容区域。

属性**VerticalBarState**和**HorizontalBarState**指定水平或垂直分割条应显示的状态。水平分割条将幻灯片与其下方的内容区域分开，垂直分割条将幻灯片与侧边内容区域分开。可能的取值有：**SplitterBarStateType.Minimized、SplitterBarStateType.Maximized**和**SplitterBarStateType.Restored**。

属性**RestoredLeft**和**RestoredTop**在**VerticalBarState**和**HorizontalBarState**均为**SplitterBarStateType.Restored**时，指定普通视图中顶部或侧边幻灯片区域的大小。

## **关于还原 INormalViewProperties**

指定普通视图中幻灯片区域的大小（当为 RestoredTop 的子项时为宽度，作为 RestoredLeft 的子项时为高度），当该区域处于可变的恢复大小（既非最小化也非最大化）时。

属性**DimensionSize**指定幻灯片区域的大小（作为 restoredTop 的子项时为宽度，作为 restoredLeft 的子项时为高度）。

属性**AutoAdjust**指定在调整包含视图的窗口大小时，侧边内容区域的大小是否应自动补偿新的尺寸。

下面的示例演示了如何访问演示文稿的**ViewProperties.NormalViewProperties**属性。

``` cpp
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

Aspose.Slides for C++ 现在支持为演示文稿设置默认缩放值，以便打开演示文稿时已设置缩放。可以通过设置演示文稿的[ViewProperties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/viewproperties/)来实现。幻灯片视图属性以及[get_NotesViewProperties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/viewproperties/get_notesviewproperties/)也可以通过编程方式设置。在本主题中，我们将通过示例演示如何在 Aspose.Slides 中设置演示文稿的视图属性。

为了设置视图属性，请按以下步骤操作：

1. 创建一个[Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/)类的实例
1. 设置演示文稿的视图[Properties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/viewproperties/)
1. 将演示文稿写入为 PPTX 文件

在下面的示例中，我们已为幻灯片视图和备注视图设置了缩放值。

``` cpp
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

使用[Presentation::get_ViewProperties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_viewproperties/)访问全演示文稿的视图设置。[IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iviewproperties/get_gridspacing/)和[IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iviewproperties/set_gridspacing/)方法用于读取或修改底层编辑网格的间隔。此设置适用于整个演示文稿，而非单个幻灯片。网格间距以点为单位指定，72 点等于一英寸。请使用正值，遵循 API 文档的要求。

下面的示例打开现有的 `demo.pptx`，输出其当前网格间距，设置四分之一英寸的间隔，并保存结果。

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

网格不同于[绘图指南](/slides/zh/cpp/drawing-guides/)。网格间距控制固定的间隔，而绘图指南是单独定位的水平或垂直对齐线。添加、移动或清除绘图指南不会改变网格间距。

网格和绘图指南均为编辑辅助工具。它们不会作为幻灯片内容渲染到 PDF、图像、SVG 或幻灯片放映中。即使存储了网格间距，也不能保证编辑器会显示网格：其可见性还取决于查看器或编辑器的偏好设置。

## **常见问题**

**为什么重新打开演示文稿后网格不可见？**

文件会存储网格间距，但是否显示网格由编辑器决定。请检查编辑器的网格可见性设置。

**清除绘图指南会改变网格间距吗？**

不会。绘图指南和网格间距是独立的设置。清除指南不会改变已存储的网格间隔。

**我能为演示文稿的不同章节设置不同的视图设置吗？**

视图设置在演示文稿层面定义（普通视图/幻灯片视图），而非按章节划分，因此打开时整个文档使用同一套参数。

**我能为不同用户预定义不同的视图状态吗？**

不能。设置存储在文件中且是共享的。查看器应用程序可能会遵循用户偏好，但文件本身仅包含一套视图属性。

**我能准备一个预设视图属性的模板，使新演示文稿以相同方式打开吗？**

可以。由于视图属性存储在演示文稿层面，你可以将它们嵌入模板中，以此创建新文档，使其拥有相同的初始视图配置。