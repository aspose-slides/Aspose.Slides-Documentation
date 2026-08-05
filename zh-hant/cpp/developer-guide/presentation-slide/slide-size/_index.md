---
title: 在 C++ 中變更簡報投影片大小
linktitle: 投影片大小
type: docs
weight: 70
url: /zh-hant/cpp/slide-size/
keywords:
- 投影片大小
- 長寬比
- 標準
- 寬螢幕
- 4:3
- 16:9
- 設定投影片大小
- 變更投影片大小
- 自訂投影片大小
- 特殊投影片大小
- 獨特投影片大小
- 全尺寸投影片
- 螢幕類型
- 不縮放
- 確保適配
- 最大化
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "了解如何使用 C++ 與 Aspose.Slides 快速調整 PPT、PPTX 與 ODP 檔案的投影片大小，優化簡報以適應任何螢幕，同時不失真。"
---
## **簡介**

Aspose.Slides 提供完整的工具，可調整 PowerPoint 簡報中的投影片大小與長寬比例，對於列印與螢幕顯示皆相當重要。 

常用的投影片大小與比例：

- **標準 (4:3 長寬比例)**：適用於舊版螢幕與裝置。  
- **寬螢幕 (16:9 長寬比例)**：建議用於現代投影機與顯示器。  

確保整個簡報的一致性，因為所有投影片都使用相同的大小與長寬比例。為獲得最佳效果，請在建立簡報的初期就設定投影片尺寸，以免產生問題。

{{% alert color="primary" %}} 
默認情況下，使用 Aspose.Slides 建立的簡報會使用標準的 4:3 長寬比例。
{{% /alert %}}

## **變更簡報中的投影片大小**

此範例程式碼示範如何使用 Aspose.Slides 於 C++ 中變更簡報的投影片大小：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **在簡報中指定自訂投影片大小**

如果您覺得常見的投影片大小（4:3 與 16:9）不符合需求，您可以選擇使用特定或獨特的投影片大小。例如，若您打算在自訂版面配置上列印全尺寸投影片，或是希望在特定螢幕上顯示簡報，使用自訂大小設定將能帶來好處。 

此範例程式碼示範如何在 C++ 中使用 Aspose.Slides 為簡報指定自訂投影片大小：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// A4 紙張尺寸
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **調整大小後處理投影片內容**

變更簡報的投影片大小後，投影片的內容（例如影像或物件）可能會失真。預設情況下，物件會自動調整大小以符合新投影片尺寸。然而，在變更簡報的投影片大小時，您可以指定設定，以決定 Aspose.Slides 如何處理投影片上的內容。 

根據您的需求或目標，您可以使用以下任一設定：

- `DoNotScale`

  如果您 **不** 想讓投影片上的物件被重新調整大小，請使用此設定。

- `EnsureFit`

  如果您想縮小至較小的投影片尺寸，且需要 Aspose.Slides 縮小投影片物件以確保它們全部能容納於投影片中（以避免遺失內容），請使用此設定。 

- `Maximize`

  如果您想放大至較大的投影片尺寸，且需要 Aspose.Slides 放大投影片物件，使其與新投影片大小成比例，請使用此設定。 

此範例程式碼示範在變更簡報投影片大小時，如何使用 `Maximize` 設定：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **常見問題**

**我可以使用除英吋外的單位（例如點或毫米）設定自訂投影片大小嗎？**

可以。Aspose.Slides 內部使用點作為單位，1 點等於 1/72 英吋。您可以將任意單位（例如毫米或公分）轉換為點，然後使用轉換後的數值來定義投影片的寬度與高度。

**非常大的自訂投影片尺寸會影響渲染時的效能與記憶體使用嗎？**

會。較大的投影片尺寸（以點為單位）加上較高的渲染比例會導致記憶體使用量增加以及處理時間變長。請選擇實用的投影片大小，並僅在必要時調整渲染比例以達到所需的輸出品質。

**我可以定義一個非標準的投影片大小，然後合併來自不同尺寸簡報的投影片嗎？**

在簡報擁有不同投影片尺寸時，無法[合併簡報](/slides/zh-hant/cpp/merge-presentation/)。必須先將其中一個簡報的尺寸調整為與另一個相同。變更投影片尺寸時，您可以透過[SlideSizeScaleType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/slidesizescaletype/) 選項決定現有內容的處理方式。對齊尺寸後，即可合併投影片且保留格式。

**我可以為單一形狀或投影片的特定區域產生縮圖，且它們會遵循新的投影片尺寸嗎？**

可以。Aspose.Slides 能為[整張投影片](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/slide/getimage/)以及[選取的形狀](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/getimage/)產生縮圖。產生的圖像會反映當前的投影片尺寸與長寬比例，確保框架與幾何形狀一致。