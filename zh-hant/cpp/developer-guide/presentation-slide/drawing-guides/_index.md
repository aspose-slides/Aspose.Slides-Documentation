---
title: 在 C++ 中管理簡報的繪圖參考線
linktitle: 繪圖參考線
type: docs
weight: 85
url: /zh-hant/cpp/drawing-guides/
keywords:
- 繪圖參考線
- 水平參考線
- 垂直參考線
- 對齊參考線
- 投影片檢視
- 母片
- 版面投影片
- 備註母片
- 講義母片
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 簡報中新增、存取及清除水平與垂直繪圖參考線。"
---
## **概述**

繪圖參考線是可調整的水平與垂直線條，可協助使用者在 PowerPoint 編輯簡報時一致地對齊圖形。當應用程式產生的簡報之後需手動微調時，這些參考線特別有用：應用程式可以儲存相同的對齊輔助，作者在新增或移動內容時應遵循這些輔助。

繪圖參考線是編輯輔助工具，而非投影片內容。它們不會出現在投影片放映或渲染輸出中。Aspose.Slides for C++ 透過 [IDrawingGuidesCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/idrawingguidescollection/) 介面公開它們。一條參考線由 [IDrawingGuide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/idrawingguide/) 表示，具備方向、位置與顏色。

位置以點 (points) 為單位，從相關投影片或母片的左上角測量。垂直參考線使用水平座標，通常介於 0 與投影片寬度之間。水平參考線使用垂直座標，通常介於 0 與投影片高度之間。

## **將參考線新增至投影片檢視**

使用 [ICommonSlideViewProperties::get_DrawingGuides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icommonslideviewproperties/get_drawingguides/) 來管理在編輯普通投影片時顯示的參考線。呼叫 [IDrawingGuidesCollection::Add](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/idrawingguidescollection/add/)，傳入 [Orientation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/orientation/) 值以及以點為單位的位置。

以下範例在投影片中心右側新增一條垂直參考線，並在其下方新增一條水平參考線：

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

## **存取繪圖參考線**

使用 [IDrawingGuidesCollection::get_Count](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/idrawingguidescollection/get_count/) 方法以及 [IDrawingGuidesCollection::idx_get](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/idrawingguidescollection/idx_get/) 方法即可存取現有的參考線。[IDrawingGuide::get_Orientation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/idrawingguide/get_orientation/)、[IDrawingGuide::get_Position](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/idrawingguide/get_position/) 與 [IDrawingGuide::get_Color](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/idrawingguide/get_color/) 方法會回傳參考線的目前屬性。對應的設定子方法可更改這些屬性。

以下範例讀取上述建立的簡報中投影片檢視的參考線：

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

## **將參考線新增至母片與版面投影片**

投影片母片及其各版面投影片皆可擁有自己的繪圖參考線集合。母片請使用 [IMasterSlide::get_DrawingGuides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterslide/get_drawingguides/)，版面投影片請使用 [ILayoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ilayoutslide/get_drawingguides/)。

以下範例在第一張母片添加一條垂直參考線，並在第一張版面投影片添加一條水平參考線：

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

## **將參考線新增至備註與講義母片**

備註母片與講義母片也支援繪圖參考線。可使用 [IMasterNotesSlide::get_DrawingGuides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasternotesslide/get_drawingguides/) 與 [IMasterHandoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterhandoutslide/get_drawingguides/) 來存取它們的集合。如果簡報未包含其中任何一種母片，則可呼叫 [IMasterNotesSlideManager::SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) 或 [IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) 來建立預設母片並回傳它。

以下範例在備註母片新增一條水平參考線，並在講義母片新增一條垂直參考線：

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

## **清除繪圖參考線**

呼叫 [IDrawingGuidesCollection::Clear](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/idrawingguidescollection/clear/) 即可移除特定集合中的所有參考線。清除單一集合不會影響其他範圍內儲存的參考線。

以下範例在不建立缺失母片的情況下，清除投影片檢視的參考線以及投影片母片、版面投影片、備註母片與講義母片上的所有參考線：

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

## **常見問題**

**繪圖參考線會出現在投影片放映或匯出的影像中嗎？**

不會。繪圖參考線是用於編輯的對齊輔助，並不會作為簡報內容呈現。

**可以直接將繪圖參考線新增到單一普通投影片嗎？**

普通投影片的編輯參考線儲存在簡報的投影片檢視屬性中。投影片母片、版面投影片、備註母片與講義母片則各自有獨立的參考線集合。

**參考線位置使用何種單位？**

位置以點 (points) 為單位，1 吋等於 72 點。垂直位置從左邊緣測量，水平位置從上邊緣測量。

**清除繪圖參考線會移除圖形或變更投影片內容嗎？**

不會。`Clear` 方法僅移除所選集合中的參考線。圖形與其他投影片內容保持不變。