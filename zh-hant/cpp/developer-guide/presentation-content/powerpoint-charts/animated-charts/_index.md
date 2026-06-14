---
title: 使用 C++ 為 PowerPoint 圖表加入動畫
linktitle: 動畫圖表
type: docs
weight: 80
url: /zh-hant/cpp/animated-charts/
keywords:
- 圖表
- 動畫圖表
- 圖表動畫
- 圖表系列
- 圖表類別
- 系列元素
- 類別元素
- 新增效果
- 效果類型
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中建立令人驚豔的動畫圖表。透過 PPT 與 PPTX 檔案中的動態視覺效果提升簡報——立即開始。"
---
## **簡介**

Aspose.Slides 支援為圖表元素加入動畫。**Series**、**Categories**、**Series Elements**、**Categories Elements** 可使用[ISequence::AddEffect](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/isequence/addeffect/)方法以及兩個列舉[EffectChartMajorGroupingType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/effectchartmajorgroupingtype/)和[EffectChartMinorGroupingType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/effectchartminorgroupingtype/)進行動畫設定。

## **圖表系列動畫**

如果您想為圖表系列加入動畫，請依照以下步驟編寫程式碼：

1. 載入簡報。
1. 取得圖表物件的參考。
1. 為系列加入動畫。
1. 將簡報檔寫入磁碟。

以下範例示範了圖表系列的動畫。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}

## **系列元素動畫**

如果您想為系列元素加入動畫，請依照以下步驟編寫程式碼：

1. 載入簡報。
1. 取得圖表物件的參考。
1. 為系列元素加入動畫。
1. 將簡報檔寫入磁碟。

以下範例示範了系列元素的動畫。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeriesElements-AnimatingSeriesElements.cpp" >}}

## **圖表類別動畫**

如果您想為圖表類別加入動畫，請依照以下步驟編寫程式碼：

1. 載入簡報。
1. 取得圖表物件的參考。
1. 為類別加入動畫。
1. 將簡報檔寫入磁碟。

以下範例示範了圖表類別的動畫。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingSeries-AnimatingSeries.cpp" >}}

## **類別元素動畫**

如果您想為類別元素加入動畫，請依照以下步驟編寫程式碼：

1. 載入簡報。
1. 取得圖表物件的參考。
1. 為類別元素加入動畫。
1. 將簡報檔寫入磁碟。

以下範例示範了類別元素的動畫。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AnimatingCategoriesElements-AnimatingCategoriesElements.cpp" >}}

## **常見問題**

**圖表是否支援與一般圖形相同的不同效果類型（例如，進入、強調、退出）？**

是的。圖表被視為形狀，因此支援標準的動畫效果類型，包括進入、強調與退出，且可透過投影片的時間軸與動畫序列完整控制。

**我可以將圖表動畫與投影片轉場結合使用嗎？**

是的。[Transitions](/slides/zh-hant/cpp/slide-transition/) 會套用於投影片本身，而動畫效果則套用於投影片上的物件。您可以在同一簡報中同時使用兩者，並分別加以控制。

**儲存為 PPTX 時會保留圖表動畫嗎？**

是的。當您[儲存為 PPTX](/slides/zh-hant/cpp/save-presentation/)時，所有動畫效果及其順序都會被保留，因為它們是簡報本機動畫模型的一部份。

**我可以從簡報中讀取現有的圖表動畫並進行修改嗎？**

是的。[API](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.animation/) 可存取投影片的時間軸、序列與效果，讓您檢視現有的圖表動畫並進行調整，而不必從頭重新建立。

**我可以使用 Aspose.Slides 產生包含圖表動畫的影片嗎？**

是的。您可以[將簡報匯出為影片](/slides/zh-hant/cpp/convert-powerpoint-to-video/)，同時保留動畫，並設定時間與其他匯出設定，使最終影片呈現動畫播放效果。