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
- 確保適合
- 最大化
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
descriptions: "了解如何使用 C++ 和 Aspose.Slides 迅速調整 PPT、PPTX 與 ODP 檔案的投影片大小，優化簡報以符合任何螢幕且不失真。"
---
## **簡介**

Aspose.Slides 提供了完整的工具，以調整 PowerPoint 簡報中的投影片大小與長寬比，這對於列印與螢幕顯示都至關重要。 

常見的投影片大小與比例：

- **標準 (4:3 長寬比)**：適用於較舊的螢幕和裝置。  
- **寬螢幕 (16:9 長寬比)**：建議用於現代投影機與顯示器。  

請確保整個簡報保持一致，單一的投影片大小與長寬比會套用至所有投影片。為取得最佳效果，建議在建立簡報之初即設定投影片尺寸，以避免後續的麻煩。

{{% alert color="primary" %}} 
預設情況下，使用 Aspose.Slides 建立的簡報會使用標準的 4:3 長寬比。  
{{% /alert %}}

## **變更簡報中的投影片大小**

此範例程式碼示範如何在 C++ 中使用 Aspose.Slides 變更簡報的投影片大小：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres-4x3-aspect-ratio.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::OnScreen16x9, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-4x3-aspect-ratio.pptx", SaveFormat::Pptx);
```

## **在簡報中指定自訂投影片大小**

如果您發現常見的投影片大小（4:3 與 16:9）不符合需求，您可以選擇使用特定或獨特的投影片尺寸。例如，若您打算在自訂的頁面配置上列印完整大小的投影片，或是希望在特定螢幕類型上顯示簡報，使用自訂尺寸設定將能帶來幫助。 

此範例程式碼示範如何在 C++ 中使用 Aspose.Slides for C++ 為簡報指定自訂投影片大小：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
// A4 紙張尺寸
pres->get_SlideSize()->SetSize(780.0f, 540.0f, SlideSizeScaleType::DoNotScale);
pres->Save(u"pres-a4-slide-size.pptx", SaveFormat::Pptx);
```

## **調整尺寸後的投影片內容處理**

在變更簡報的投影片大小後，投影片的內容（例如影像或物件）可能會變形。預設情況下，物件會自動調整大小以符合新的投影片尺寸。然而，在變更簡報投影片大小時，您可以指定一個設定，以決定 Aspose.Slides 如何處理投影片上的內容。

根據您的目的與需求，您可以使用以下任一設定：

- `DoNotScale`  
  如果您不希望投影片上的物件被重新調整大小，請使用此設定。  

- `EnsureFit`  
  如果您想縮小投影片尺寸，且需要 Aspose.Slides 將投影片物件縮小以確保它們全部適合投影片（以避免遺失內容），請使用此設定。  

- `Maximize`  
  如果您想放大投影片尺寸，且需要 Aspose.Slides 將投影片物件放大，使其與新的投影片尺寸成比例，請使用此設定。  

此範例程式碼示範如何在變更簡報投影片大小時使用 `Maximize` 設定：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->get_SlideSize()->SetSize(SlideSizeType::Ledger, SlideSizeScaleType::Maximize);
```

## **常見問題**

**我可以使用英寸以外的單位（例如點或毫米）設定自訂投影片大小嗎？**

可以。Aspose.Slides 內部使用點（points）作為單位，1 點等於 1/72 英寸。您可以將任何單位（例如毫米或公分）轉換為點，然後使用轉換後的數值來設定投影片的寬度與高度。

**非常大的自訂投影片尺寸會影響渲染時的效能與記憶體使用量嗎？**

會。較大的投影片尺寸（以點為單位）搭配較高的渲染比例會導致記憶體消耗增加以及處理時間延長。建議選擇實用的投影片尺寸，僅在需要時調整渲染比例以達到所需的輸出品質。

**我能定義一個非標準的投影片尺寸，然後合併來自不同尺寸簡報的投影片嗎？**

在投影片尺寸不同的情況下，您無法[合併簡報](/slides/zh-hant/cpp/merge-presentation/)。必須先調整其中一個簡報的尺寸以匹配另一個。變更投影片尺寸時，您可以透過[SlideSizeScaleType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/slidesizescaletype/)選項選擇如何處理現有內容。尺寸對齊後，您即可在保留格式的前提下合併投影片。

**我可以為單一圖形或投影片的特定區域產生縮圖，且這些縮圖會遵守新的投影片尺寸嗎？**

可以。Aspose.Slides 可以為[整張投影片](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/slide/getimage/)以及[選取的圖形](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/getimage/)產生縮圖。產生的影像會反映目前的投影片大小與長寬比，確保構圖與幾何形狀的一致性。