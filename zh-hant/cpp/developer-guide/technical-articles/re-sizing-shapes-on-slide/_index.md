---
title: 在 C++ 中調整簡報投影片的形狀大小
type: docs
weight: 130
url: /zh-hant/cpp/resizing-shapes-on-slide/
aliases:
  - /cpp/re-sizing-shapes-on-slide/
  - /zh-hant/cpp/re-sizing-shapes-on-slide/
keywords:
- 調整形狀大小
- 變更形狀尺寸
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 輕鬆調整 PowerPoint 與 OpenDocument 投影片上的形狀大小——自動化投影片版面調整，提升生產力。"
---
## **概觀**

當您變更簡報的投影片大小時，可能還需要調整形狀的大小並重新定位，以符合新的尺寸。本文說明如何手動縮放形狀以及如何在投影片、母片和版面配置上處理表格。

## **調整形狀大小**

為了保留每個形狀的相對位置與大小，將其水平座標與寬度乘以新投影片寬度與原始寬度的比例。再以相應的高度比例乘以其垂直座標與高度。

第一個範例載入一個投影片中不含表格的簡報，將投影片大小變更為 A4，並儲存結果。它使用 [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) 搭配 [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/cpp/aspose.slides/slidesizescaletype/)，讓隨後的迴圈負責縮放。比例值沒有單位；形狀的位置與尺寸以點為單位測量。不同的寬度與高度比例會導致形狀變形，且變更形狀尺寸不會同時縮放其字型大小。

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Calculate independent horizontal and vertical scale factors.
auto originalSize = presentation->get_SlideSize()->get_Size();
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
auto targetSize = presentation->get_SlideSize()->get_Size();
auto widthRatio = targetSize.get_Width() / originalSize.get_Width();
auto heightRatio = targetSize.get_Height() / originalSize.get_Height();

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        shape->set_Width(shape->get_Width() * widthRatio);
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
        shape->set_Y(shape->get_Y() * heightRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
表格需要另行處理：縮放其欄寬與列高，而不是直接設定表格的整體寬度與高度。如果儲存格內容需要更多空間，列高可能會保持大於要求的大小。
{{% /alert %}}

第二個範例支援表格，並在儲存調整大小的簡報之前，處理母片、版面配置以及各個投影片上的形狀。它的輔助函式透過縮放每個 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/)，調整 [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) 與 [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/)。之後僅縮放表格的位置，並不另行縮放其整體尺寸。

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideCollection.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 計算水平與垂直的獨立縮放係數。
auto originalSize = presentation->get_SlideSize()->get_Size();
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
auto targetSize = presentation->get_SlideSize()->get_Size();
auto widthRatio = targetSize.get_Width() / originalSize.get_Width();
auto heightRatio = targetSize.get_Height() / originalSize.get_Height();

auto resizeShapes = [](SharedPtr<IShapeCollection> shapes, float widthRatio, float heightRatio)
{
    for (auto&& shape : shapes)
    {
        if (ObjectExt::Is<ITable>(shape))
        {
            auto table = ExplicitCast<ITable>(shape);
            // 表格尺寸由欄寬和列高控制。
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }

            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
        }
        else
        {
            shape->set_Width(shape->get_Width() * widthRatio);
            shape->set_Height(shape->get_Height() * heightRatio);
        }

        shape->set_X(shape->get_X() * widthRatio);
        shape->set_Y(shape->get_Y() * heightRatio);
    }
};

// 調整在母片、版面配置以及個別投影片上定義的形狀大小。
for (auto&& master : presentation->get_Masters())
{
    resizeShapes(master->get_Shapes(), widthRatio, heightRatio);

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        resizeShapes(layoutSlide->get_Shapes(), widthRatio, heightRatio);
    }
}

for (auto&& slide : presentation->get_Slides())
{
    resizeShapes(slide->get_Shapes(), widthRatio, heightRatio);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **常見問題**

**為何在調整投影片大小後形狀會變形或被裁切？**  
如果在變更投影片大小時未對形狀進行縮放，形狀會保留原始位置與尺寸，可能會超出投影片範圍。以不同的比例同時縮放寬度和高度也會導致形狀變形。

**提供的程式碼能適用於所有形狀類型嗎？**  
第一個範例直接變更形狀的邊界，僅適用於沒有表格的投影片。第二個範例則另行處理表格。請檢查最終的版面配置，特別是文字與表格，因為這些範例不會縮放字型大小，且表格內容可能限制列高。

**在調整投影片大小時，該如何縮放表格？**  
如第二個範例所示，先以寬度比例縮放欄寬，再以高度比例縮放最小列高，最後縮放表格的位置。

**此縮放方式能適用於母片與版面投影片嗎？**  
會的。第二個範例會遍歷 [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/)，以及每個母片的 [IMasterSlide::get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/get_layoutslides/)，並對它們的形狀套用相同的縮放邏輯。

**我可以在調整大小的同時變更投影片的方向（直向/橫向）嗎？**  
可以。請在變更投影片大小之後、讀取目標尺寸之前設定 [SlideSize::set_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/set_orientation/)，如此縮放係數會依最終的方向計算。

**我能設定的投影片大小有上限嗎？**  
您可以使用 [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) 來指定自訂的投影片尺寸。支援的尺寸亦取決於簡報的檔案格式以及開啟檔案的應用程式。

**如何防止具有固定長寬比的形狀被變形？**  
在寬度與高度上使用相同的縮放係數。若要讓原始版面配置符合新投影片尺寸，可同時使用寬度與高度比例中較小的那一個來縮放尺寸與位置。此方式能保持比例，但可能會在某一邊留下未使用的空間。