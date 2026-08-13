---
title: 調整投影片上的圖形大小
type: docs
weight: 100
url: /zh-hant/cpp/re-sizing-shapes-on-slide/
keywords:
- 調整圖形大小
- 變更圖形尺寸
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 輕鬆調整 PowerPoint 與 OpenDocument 投影片上的圖形大小——自動化投影片版面配置的調整，提高工作效率。"
---
## **概觀**

Aspose.Slides for C++ 的客戶最常提出的問題之一是如何調整圖形大小，以免在投影片尺寸變更時資料被截斷。這篇簡短的技術文章說明了如何做到這一點。

## **調整圖形大小**

為防止投影片尺寸變更時圖形錯位，請更新每個圖形的位置與尺寸，使其符合新的投影片版面配置。

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

// 載入簡報檔案。
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// 取得原始投影片尺寸。
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// 在不縮放現有圖形的情況下變更投影片尺寸。
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// 取得新的投影片尺寸。
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// Resize and reposition shapes on every slide.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // 縮放圖形大小。
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // 縮放圖形位置。
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" %}} 
如果投影片中包含表格，上述程式碼將無法正確運作。在此情況下，必須調整表格中每個儲存格的大小。 
{{% /alert %}} 

在您的端使用以下程式碼以調整包含表格的投影片大小。對於表格而言，設定寬度或高度是特殊情況：必須調整各列高度與欄寬以變更表格的整體尺寸。

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
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 取得原始投影片尺寸。
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// 在不縮放現有圖形的情況下變更投影片尺寸。
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
// 設定投影片方向為直向

// 取得新的投影片尺寸。
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // 縮放圖形大小。
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // 縮放圖形位置。
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // 縮放圖形大小。
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // 縮放圖形位置。
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // 縮放圖形大小。
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // 縮放圖形位置。
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);

        if (ObjectExt::Is<ITable>(shape))
        {
            SharedPtr<ITable> table = ExplicitCast<ITable>(shape);
            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **常見問題**

### 為何在調整投影片大小後圖形會變形或被截斷？

在調整投影片大小時，圖形會保留原始位置和尺寸，除非明確更改比例。這可能導致內容被裁剪或圖形錯位。

### 提供的程式碼是否適用於所有圖形類型？

基本範例適用於大多數圖形類型（文字方塊、影像、圖表等）。然而，對於表格，必須分別處理列與欄，因為表格的高度與寬度是由各儲存格的尺寸決定的。

### 在調整投影片大小時，該如何調整表格？

必須遍歷表格的所有列與欄，並按比例調整其高度與寬度，如第二個程式碼範例所示。

### 此調整方式是否適用於母片與版面投影片？

是的，但您也應該遍歷[母片](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_masters/)和[版面投影片](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_layoutslides/)並對其圖形套用相同的縮放邏輯，以確保整個簡報的一致性。

### 我能在調整大小的同時改變投影片的方向（直向/橫向）嗎？

可以。您可以使用[presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidesize/set_orientation/)來變更方向。請確保相應設定縮放邏輯以保留版面配置。

### 我能設定的投影片尺寸有上限嗎？

Aspose.Slides 支援自訂尺寸，但過大的尺寸可能會影響效能或與某些 PowerPoint 版本的相容性。

### 如何防止固定長寬比的圖形變形？

您可以在縮放前檢查圖形的 `get_AspectRatioLocked` 方法。若已鎖定，請按比例調整寬度或高度，而非分別縮放它們。