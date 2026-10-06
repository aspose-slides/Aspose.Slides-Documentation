---
title: 使用 C++ 管理 PowerPoint 簡報中的 SmartArt
linktitle: 管理 SmartArt
type: docs
weight: 10
url: /zh-hant/cpp/manage-smartart/
keywords:
- SmartArt
- SmartArt 文字
- 版面類型
- 隱藏屬性
- 組織圖
- 圖片組織圖
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "學習使用 Aspose.Slides for C++ 建立與編輯 PowerPoint SmartArt，搭配清晰的程式碼範例，加速投影片設計與自動化。"
---
## **概觀**

SmartArt 是由節點、節點形狀和版面配置組成的 PowerPoint 圖表。使用 Aspose.Slides for C++，您可以建立 SmartArt、從其節點讀取文字、變更其版面配置、檢查隱藏節點、配置組織圖版面配置，並建立圖片組織圖。

## **取得 SmartArt 物件的文字**

SmartArt 節點可以包含一個或多個形狀。要從節點形狀讀取文字，請遍歷 [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/get_allnodes/)，然後讀取由 [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartshape/get_textframe/) 回傳的 [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/)。此範例需要一個至少包含一張投影片且在該投影片上第一個形狀為 SmartArt 物件的簡報。它會將每個可用的文字框印到主控台。

```cpp
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtNodeCollection.h>
#include <DOM/SmartArt/ISmartArtShape.h>
#include <DOM/SmartArt/ISmartArtShapeCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

auto smartArt = ExplicitCast<ISmartArt>(slide->get_Shape(0));
for (auto nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
{
    auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);
    for (auto shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto nodeShape = node->get_Shape(shapeIndex);
        if (nodeShape->get_TextFrame() != nullptr)
        {
            Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
        }
    }
}

presentation->Dispose();
```

## **變更 SmartArt 物件的版面類型**

SmartArt 版面決定節點的排列與連接方式。以下範例使用 [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) 的 `BasicBlockList` 值建立 SmartArt 物件，將其變更為 `BasicProcess` 值，並儲存簡報。傳遞給 [IShapeCollection::AddSmartArt](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addsmartart/) 的位置與大小以點為單位。使用 [ISmartArt::set_Layout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/set_layout/) 變更版面。

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);
smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **檢查 SmartArt 節點是否為隱藏**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_ishidden/) 表示該節點在 SmartArt 資料模型中是否被隱藏。即使所選版面不將它們顯示為可見的圖表元素，隱藏節點仍可能存在於結構中。以下範例向使用 [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` 值的 SmartArt 物件新增一個節點，並檢查該新增節點的隱藏狀態。如果節點被隱藏，會印出訊息並儲存圖表。

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/ISmartArtNodeCollection.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);
auto node = smartArt->get_AllNodes()->AddNode();
auto isHidden = node->get_IsHidden();

if (isHidden)
{
    Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **取得或設定組織圖版面配置**

對於使用組織圖版面的 SmartArt 圖表，[ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/get_organizationchartlayout/) 與 [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartartnode/set_organizationchartlayout/) 定義子節點在父節點之下的排列方式。例如，您可以根據所選的 [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/)，將子節點掛在左側、右側或兩側。以下範例建立一個組織圖，並將第一個節點的版面設定為 [OrganizationChartLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging` 值。0 的零基索引選取第一個頂層節點；其子節點使用所選的排列方式。然後儲存已修改的簡報。

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/ISmartArt.h>
#include <DOM/SmartArt/ISmartArtNode.h>
#include <DOM/SmartArt/OrganizationChartLayoutType.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);
auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **建立圖片組織圖**

圖片組織圖是一種為包含影像佔位符的階層圖表設計的 SmartArt 版面。在將 SmartArt 物件新增至投影片時使用 [SmartArtLayoutType](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` 值。此範例儲存含有影像佔位符的圖表；不會為佔位符填入影像。

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SmartArt/SmartArtLayoutType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SmartArt;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **將舊版圖表轉換為形狀群組**

在現代化現有簡報時，您可能需要更新原本在 PowerPoint 97–2003 版建立的組織圖。Aspose.Slides 將這些舊版圖表表示為 [ILegacyDiagram](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/) 物件。使用 [ILegacyDiagram::ConvertToGroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/ilegacydiagram/converttogroupshape/) 將圖表轉換為形狀群組，以便編輯各個視覺元素。詳情請參閱 [LegacyDiagram API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/legacydiagram/)。轉換會在形狀集合中新增一個群組，而不會移除原始圖表。轉換成功後，使用 [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) 移除原圖表，以避免重複內容。於轉換前先將舊版圖表收集到向量中，這樣在加入與移除形狀時不會干擾迭代。以下範例開啟簡報，搜尋每張投影片，將圖表轉換為形狀群組，並將更新後的簡報儲存為 PPTX。

```cpp
#include <DOM/ILegacyDiagram.h>
#include <DOM/IGroupShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"legacy-diagrams.ppt");

for (auto slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    std::vector<SharedPtr<ILegacyDiagram>> legacyDiagrams;

    for (auto shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        if (ObjectExt::Is<ILegacyDiagram>(shape))
        {
            auto legacyDiagram = ExplicitCast<ILegacyDiagram>(shape);
            legacyDiagrams.push_back(legacyDiagram);
        }
    }

    for (auto legacyDiagram : legacyDiagrams)
    {
        auto groupShape = legacyDiagram->ConvertToGroupShape();

        if (groupShape != nullptr)
        {
            slide->get_Shapes()->Remove(legacyDiagram);
        }
    }
}

presentation->Save(u"modernized.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

儲存的簡報以可編輯的形狀群組取代已轉換的舊版圖表，不會留下原始圖表。於 PowerPoint 中開啟 PPTX，即可編輯每個群組內的個別元素，例如文字、填色或位置。

## **常見問題**

**SmartArt 是否支援針對 RTL 語言的鏡射或反向？**

是。[SmartArt::set_IsReversed](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/set_isreversed/) 方法會在所選 SmartArt 版面支援反向時，將圖表方向從左至右切換為右至左，或反之。

**如何在保留格式的情況下，將 SmartArt 複製到同一投影片或其他簡報中？**

您可以使用 [ShapeCollection::AddClone](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addclone/) 以[複製 SmartArt 形狀](/slides/zh-hant/cpp/shape-manipulations/)，或以[複製整張投影片](/slides/zh-hant/cpp/clone-slides/) 來複製包含 SmartArt 的投影片。兩種方法皆會保留大小、位置和格式。

**如何將 SmartArt 渲染為點陣圖以供預覽或網頁匯出？**

[渲染投影片](/slides/zh-hant/cpp/convert-powerpoint-to-png/)或將整個簡報渲染為 PNG 或 JPEG。SmartArt 會作為投影片的一部份被渲染。

**如果投影片上有多個 SmartArt 物件，我該如何找到特定的 SmartArt 物件？**

在 SmartArt 形狀上設定獨特的 [Shape::set_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_alternativetext/) 或 [Shape::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_name/) 值，於 [BaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/get_shapes/) 中搜尋該值，然後確認匹配的形狀為 [ISmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/ismartart/)。