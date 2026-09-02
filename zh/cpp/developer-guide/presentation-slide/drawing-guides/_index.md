---
title: 在 C++ 中管理演示文稿的绘图参考线
linktitle: 绘图参考线
type: docs
weight: 85
url: /zh/cpp/drawing-guides/
keywords:
- 绘图参考线
- 水平参考线
- 垂直参考线
- 对齐参考线
- 幻灯片视图
- 母版幻灯片
- 布局幻灯片
- 备注母版
- 讲义母版
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 演示文稿中添加、访问和清除水平和垂直绘图参考线。"
---
## **概述**

绘图参考线是可调节的水平和垂直线，可帮助用户在 PowerPoint 中编辑演示文稿时始终保持形状对齐。当应用程序生成的演示文稿随后需要手动细化时，这些参考线尤其有用：应用程序可以保存作者在添加或移动内容时应遵循的相同对齐辅助线。

绘图参考线是编辑辅助，而非幻灯片内容。它们不会出现在幻灯片放映或渲染输出中。Aspose.Slides for C++ 通过[IDrawingGuidesCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/idrawingguidescollection/)接口公开它们。参考线由[IDrawingGuide](https://reference.aspose.com/slides/zh/cpp/aspose.slides/idrawingguide/)表示，具有方向、位置和颜色。

位置以点（points）为单位，从相应幻灯片或母版的左上角测量。垂直参考线使用水平坐标，通常在零到幻灯片宽度之间。水平参考线使用垂直坐标，通常在零到幻灯片高度之间。

## **将参考线添加到幻灯片视图**

使用[ICommonSlideViewProperties::get_DrawingGuides](https://reference.aspose.com/slides/zh/cpp/aspose.slides/icommonslideviewproperties/get_drawingguides/)管理普通幻灯片编辑时显示的参考线。调用[IDrawingGuidesCollection::Add](https://reference.aspose.com/slides/zh/cpp/aspose.slides/idrawingguidescollection/add/)并传入[Orientation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/orientation/)值和点单位的位置。

以下示例在幻灯片中心右侧添加一条垂直参考线，并在其下方添加一条水平参考线：

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/IViewProperties.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto guides = presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides();

guides->Add(Orientation::Vertical, slideSize.get_Width() / 2 + 12.5f);
guides->Add(Orientation::Horizontal, slideSize.get_Height() / 2 + 12.5f);

presentation->Save(u"drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **访问绘图参考线**

[IDrawingGuidesCollection::get_Count](https://reference.aspose.com/slides/zh/cpp/aspose.slides/idrawingguidescollection/get_count/) 方法和 [IDrawingGuidesCollection::idx_get](https://reference.aspose.com/slides/zh/cpp/aspose.slides/idrawingguidescollection/idx_get/) 方法提供对现有参考线的访问。[IDrawingGuide::get_Orientation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/idrawingguide/get_orientation/)、[IDrawingGuide::get_Position](https://reference.aspose.com/slides/zh/cpp/aspose.slides/idrawingguide/get_position/) 和 [IDrawingGuide::get_Color](https://reference.aspose.com/slides/zh/cpp/aspose.slides/idrawingguide/get_color/) 方法返回参考线的当前属性。相应的 setter 方法可以更改这些属性。

以下示例读取上述创建的演示文稿中的幻灯片视图参考线：

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuide.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"drawing-guides.pptx");
auto guides = presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides();

for (int32_t index = 0; index < guides->get_Count(); index++)
{
    auto guide = guides->idx_get(index);
    System::Console::WriteLine(
        System::String::Format(
            u"Guide {0}: orientation = {1}, position = {2}, color = {3}",
            index,
            guide->get_Orientation(),
            guide->get_Position(),
            guide->get_Color()));
}

presentation->Dispose();
```

## **将参考线添加到母版和布局幻灯片**

母版幻灯片及其每个布局幻灯片都可以拥有各自的绘图参考线集合。对母版幻灯片使用[IMasterSlide::get_DrawingGuides](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imasterslide/get_drawingguides/)，对布局幻灯片使用[ILayoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ilayoutslide/get_drawingguides/)。

以下示例在第一张母版幻灯片上添加一条垂直参考线，并在第一张布局幻灯片上添加一条水平参考线：

```cpp
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto masterGuides = presentation->get_Master(0)->get_DrawingGuides();
auto layoutGuides = presentation->get_LayoutSlide(0)->get_DrawingGuides();

masterGuides->Add(Orientation::Vertical, slideSize.get_Width() / 2 - 20.0f);
layoutGuides->Add(Orientation::Horizontal, slideSize.get_Height() / 2 + 20.0f);

presentation->Save(u"master-layout-drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **将参考线添加到备注和讲义母版**

备注母版和讲义母版也支持绘图参考线。使用[IMasterNotesSlide::get_DrawingGuides](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imasternotesslide/get_drawingguides/)和[IMasterHandoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imasterhandoutslide/get_drawingguides/)访问它们的集合。如果演示文稿不包含这些母版，[IMasterNotesSlideManager::SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) 或 [IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/zh/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) 会创建默认母版并返回它。

以下示例在备注母版上添加一条水平参考线，并在讲义母版上添加一条垂直参考线：

```cpp
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/INotesSize.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto notesSize = presentation->get_NotesSize()->get_Size();
auto notesMaster = presentation->get_MasterNotesSlideManager()->SetDefaultMasterNotesSlide();
auto handoutMaster = presentation->get_MasterHandoutSlideManager()->SetDefaultMasterHandoutSlide();

notesMaster->get_DrawingGuides()->Add(Orientation::Horizontal, notesSize.get_Height() / 2 + 50.0f);
handoutMaster->get_DrawingGuides()->Add(Orientation::Vertical, notesSize.get_Width() / 2 - 50.0f);

presentation->Save(u"notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **清除绘图参考线**

调用[IDrawingGuidesCollection::Clear](https://reference.aspose.com/slides/zh/cpp/aspose.slides/idrawingguidescollection/clear/) 可删除特定集合中的所有参考线。清除一个集合不会影响另一个作用域中存储的参考线。

以下示例在不创建缺失母版的情况下，清除幻灯片视图参考线以及所有母版、布局幻灯片、备注母版和讲义母版上的参考线：

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation-with-guides.pptx");

presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides()->Clear();

for (auto&& masterSlide : presentation->get_Masters())
{
    masterSlide->get_DrawingGuides()->Clear();
}

for (auto&& layoutSlide : presentation->get_LayoutSlides())
{
    layoutSlide->get_DrawingGuides()->Clear();
}

auto notesMaster = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (notesMaster != nullptr)
{
    notesMaster->get_DrawingGuides()->Clear();
}

auto handoutMaster = presentation->get_MasterHandoutSlideManager()->get_MasterHandoutSlide();
if (handoutMaster != nullptr)
{
    handoutMaster->get_DrawingGuides()->Clear();
}

presentation->Save(u"presentation-without-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **常见问题**

**绘图参考线会出现在幻灯片放映或导出的图像中吗？**

不会。绘图参考线是编辑对齐的辅助工具，不会作为演示内容进行渲染。

**可以直接将绘图参考线添加到单个普通幻灯片吗？**

普通幻灯片的编辑参考线存储在演示文稿的幻灯片视图属性中。母版、布局幻灯片、备注母版和讲义母版都有各自独立的参考线集合。

**参考线位置使用什么单位？**

位置以点（points）为单位，72 points 等于 1 英寸。垂直位置相对于左边缘测量，水平位置相对于顶边缘测量。

**清除绘图参考线会删除形状或更改幻灯片内容吗？**

不会。`Clear` 方法仅删除所选集合中的参考线，形状和其他幻灯片内容保持不变。