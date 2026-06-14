---
title: 在簡報投影片上調整形狀大小
type: docs
weight: 100
url: /zh-hant/cpp/re-sizing-shapes-on-slide/
keywords:
- 調整形狀大小
- 變更形狀尺寸
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 輕鬆調整 PowerPoint 與 OpenDocument 投影片上的形狀大小——自動化投影片版面調整並提升工作效率。"
---
## **概覽**

Aspose.Slides for C++ 客戶最常問的問題之一是如何調整形狀大小，使得在投影片尺寸變更時，內容不會被裁剪。本文簡短的技術說明展示了如何做到這一點。

## **調整形狀大小**

為了防止投影片尺寸變更時形狀錯位，請更新每個形狀的位置和尺寸，使其符合新的投影片版面配置。

```cpp
// 載入簡報檔案。
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// 取得原始投影片尺寸。
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// 在不縮放現有形狀的情況下變更投影片尺寸。
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// 取得新的投影片尺寸。
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// 縮放形狀尺寸。
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // 縮放形狀尺寸。
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // 縮放形狀位置。
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="primary" %}} 
如果投影片包含表格，上述程式碼將無法正確工作。在此情況下，必須調整表格中每個儲存格的大小。
{{% /alert %}} 

使用以下程式碼來調整包含表格的投影片。對於表格，設定寬度或高度是一個特例：必須調整各列高度與欄寬，以改變表格的整體大小。

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 取得原始投影片尺寸。
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// 在不縮放現有形狀的情況下變更投影片尺寸。
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// 取得新的投影片尺寸。
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // 縮放形狀尺寸。
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // 縮放形狀位置。
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // 縮放形狀尺寸。
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // 縮放形狀位置。
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // 縮放形狀尺寸。
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // 縮放形狀位置。
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

**為什麼在調整投影片大小後形狀會變形或被裁切？**

在調整投影片時，形狀會保留其原始位置和尺寸，除非明確變更比例。這可能導致內容被裁剪或形狀錯位。

**提供的程式碼適用於所有形狀類型嗎？**

基本範例適用於大多數形狀類型（文字方塊、圖片、圖表等）。然而，對於表格，需要分別處理列與欄，因為表格的高度與寬度由各儲存格的尺寸決定。

**在調整投影片時如何調整表格大小？**

需要遍歷表格的所有列與欄，按比例調整它們的高度與寬度，如第二個程式碼範例所示。

**此調整方式適用於母投影片與版面投影片嗎？**

是的，但也應該遍歷[母投影片](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_masters/)與[版面投影片](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_layoutslides/)，對它們的形狀套用相同的縮放邏輯，以確保整個簡報的一致性。

**我可以在調整大小的同時變更投影片方向（直式/橫式）嗎？**

可以。您可以使用[presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidesize/set_orientation/) 變更方向。請確保相應調整縮放邏輯以維持版面配置。

**我可以設定的投影片大小有上限嗎？**

Aspose.Slides 支援自訂尺寸，但過大的尺寸可能影響效能或與某些 PowerPoint 版本的相容性。

**如何防止具有固定長寬比的形狀被扭曲？**

在縮放之前，可檢查形狀的 `get_AspectRatioLocked` 方法。如果已鎖定，請按比例調整寬度或高度，而非分別縮放。