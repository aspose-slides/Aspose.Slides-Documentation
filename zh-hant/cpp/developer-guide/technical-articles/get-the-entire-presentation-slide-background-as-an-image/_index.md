---
title: 從簡報取得完整投影片背景為影像
linktitle: 完整投影片背景
type: docs
weight: 95
url: /zh-hant/cpp/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- 投影片背景
- 最終背景
- 擷取背景
- 完整背景
- 背景轉為影像
- PPT 背景
- PPTX 背景
- ODP 背景
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 從 PowerPoint 與 OpenDocument 簡報中將完整投影片背景提取為影像，簡化視覺工作流程。"
---
## **概觀**

在 PowerPoint 簡報中，投影片背景可能由多個元素組成，包括投影片背景圖片、簡報主題、色彩方案，以及放置在母片或版面投影片上的物件。

本文說明如何使用 Aspose.Slides 將整張投影片背景擷取為影像。由於沒有單一方法可直接完成此工作，需將選取的投影片複製到暫存簡報，移除投影片形狀，然後將得到的投影片背景轉換為影像。

## **取得整張投影片背景**

Aspose.Slides for C++ 並未提供直接將整個簡報投影片背景擷取為影像的簡易方法，但您可以依照以下步驟執行：
1. 使用 [簡報](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別載入簡報。
1. 從簡報取得投影片尺寸。
1. 選取一張投影片。
1. 建立暫存簡報。
1. 在暫存簡報中設定相同的投影片尺寸。
1. 將選取的投影片複製到暫存簡報。
1. 刪除已複製投影片上的形狀。
1. 將已複製的投影片轉換為影像。

以下程式碼範例示範如何將整張簡報投影片背景擷取為影像。
```cpp
auto slideIndex = 0;
auto imageScale = 1;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slides()->idx_get(slideIndex);

auto tempPresentation = System::MakeObject<Presentation>();

auto slideWidth = slideSize.get_Width();
auto slideHeight = slideSize.get_Height();
tempPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::DoNotScale);

auto clonedSlide = tempPresentation->get_Slides()->AddClone(slide);
clonedSlide->get_Shapes()->Clear();

auto background = clonedSlide->GetImage(imageScale, imageScale);
background->Save(u"output.png", ImageFormat::Png);

tempPresentation->Dispose();
presentation->Dispose();
```

## **常見問題**

**在最終的背景影像中，會保留來自母片的複雜漸層、紋理或圖片填滿嗎？**

會。Aspose.Slides 會呈現投影片、版面或母片上定義的漸層、圖片與紋理填滿。如果您需要將繼承自母片的外觀獨立出來，請在匯出前於目前投影片[設定自己的背景](/slides/zh-hant/cpp/presentation-background/)。

**我可以在儲存之前於最終的背景影像加入浮水印嗎？**

可以。您可以在工作[投影片副本](/slides/zh-hant/cpp/clone-slides/)（置於其他內容之後）上[新增浮水印](/slides/zh-hant/cpp/watermark/)形狀或圖片，然後再匯出。這樣即可產生已內嵌浮水印的背景影像。

**我能否取得特定版面或母片的背景，而不必與現有投影片關聯？**

可以。存取所需的母片或版面，將其套用到具有所需尺寸的[暫存投影片](/slides/zh-hant/cpp/clone-slides/)，然後匯出該投影片，即可取得來自該版面或母片的背景。

**授權限制會影響影像匯出嗎？**

渲染功能在[有效授權](/slides/zh-hant/cpp/licensing/)下可完整使用。於評估模式下，輸出可能會包含浮水印等限制。請在每個程序啟動時先啟用授權，以執行批次匯出。