---
title: 在 C++ 中調整簡報投影片上的形狀大小
type: docs
weight: 130
url: /zh-hant/cpp/resizing-shapes-on-slide/
aliases:
  - /zh-hant/cpp/re-sizing-shapes-on-slide/
  /cpp/重新-調整-形狀-投影片/
keywords:
- 調整形狀大小
- 變更形狀尺寸
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++，輕鬆在 PowerPoint 與 OpenDocument 投影片上調整形狀大小——自動化投影片版面調整，提升生產力。"
---
## **概觀**

當您變更簡報的投影片尺寸時，可能還需要調整和重新定位其形狀，以符合新的尺寸。本文說明如何手動縮放形狀，以及如何處理投影片、母片與佈局上的表格。

## **調整形狀大小**

為了保留每個形狀的相對位置與大小，請將其水平座標與寬度乘以新投影片寬度與原始寬度的比率。再將相對的高度比率套用到垂直座標與高度上。

第一個範例載入一個投影片中不含表格的簡報，將投影片尺寸變更為 A4，並儲存結果。它使用 [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) 搭配 [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/cpp/aspose.slides/slidesizescaletype/) 使後續迴圈自行控制縮放。比例是無單位的；形狀的位置與尺寸以點 (point) 為單位測量。不同的寬高比例會使形狀變形，且變更形狀尺寸不會縮放字型大小。

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

{{% alert color="info" title="注意" %}}
表格需要單獨處理：以寬度比例縮放欄寬，以高度比例縮放列高，而不是直接指定表格的整體寬度與高度。如果儲存格內容需要更多空間，列高可能會保持大於要求的大小。
{{% /alert %}}

第二個範例支援表格，並在儲存調整大小的簡報之前，處理母片、佈局以及單一投影片上的形狀。其輔助程式會針對每個 [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) 透過縮放 [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) 與 [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/) 來處理。之後會縮放表格的位置，而不會單獨縮放其整體尺寸。

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

// 計算獨立的水平與垂直縮放係數。
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
            // 表格的尺寸由欄寬和列高控制。
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

// Resize shapes defined on masters and layouts as well as individual slides.
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

**調整投影片大小後，為何形狀會變形或被切掉？**

如果在變更投影片尺寸時未對形狀進行縮放，形狀會保留原始位置與尺寸，可能會超出投影片範圍。使用不同的寬高比例進行縮放也會導致形狀變形。

**提供的程式碼能適用於所有形狀類型嗎？**

第一個範例直接變更形狀的邊界，適用於不含表格的投影片。第二個範例則會單獨處理表格。請檢查最終版面的結果，特別是文字與表格，因為這些範例不會縮放字型大小，而表格內容可能會限制列高。

**在調整投影片大小時，如何調整表格大小？**

依寬度比例縮放欄寬，依高度比例縮放最小列高，然後如第二個範例所示縮放表格的位置。

**此調整方式能套用於母片與版面投影片嗎？**

可以。第二個範例會遍歷 [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) 以及每個母片的 [IMasterSlide::get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/get_layoutslides/)，對其形狀套用相同的調整邏輯。

**是否可以在調整大小的同時變更投影片方向（直向/橫向）？**

可以。請在變更投影片尺寸後、讀取目標尺寸前，設定 [SlideSize::set_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/set_orientation/)，使縮放係數反映最終的方向。

**可設定的投影片尺寸有上限嗎？**

您可以使用 [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) 指定自訂尺寸。支援的尺寸亦取決於簡報檔案格式與開啟檔案的應用程式。

**如何防止具有固定長寬比的形狀變形？**

對寬度與高度使用相同的縮放係數。若要在新投影片尺寸內保留原始版面，請同時使用寬高比率中較小的那一個作為寬度與高度的縮放係數，並以相同係數調整位置。這樣可保持比例，但可能在某一邊留下未使用的空間。