---
title: 使用 C++ 在簡報中管理 SmartArt 圖形
linktitle: SmartArt 圖形
type: docs
weight: 20
url: /zh-hant/cpp/manage-smartart-shape/
keywords:
- SmartArt 物件
- SmartArt 圖形
- SmartArt 樣式
- SmartArt 顏色
- 建立 SmartArt
- 新增 SmartArt
- 編輯 SmartArt
- 變更 SmartArt
- 存取 SmartArt
- SmartArt 版面配置類型
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中自動化 PowerPoint SmartArt 的建立、編輯與樣式設定，提供簡潔的程式碼範例與以效能為導向的指導。"
---
## **概述**

Aspose.Slides 允許您以程式方式在 PowerPoint 簡報中建立與管理 SmartArt 圖形。本文說明如何將 SmartArt 形狀新增至投影片、存取現有的 SmartArt 形狀、依特定版面配置類型尋找 SmartArt，並透過變更 SmartArt 樣式或顏色樣式來更新其視覺外觀。

這些範例展示了如何透過簡報投影片的形狀集合操作 SmartArt 形狀、檢查形狀是否為 SmartArt，然後修改或檢查其屬性。

## **建立 SmartArt 形狀**
Aspose.Slides for C++ 現在可方便地從頭在投影片中新增自訂 SmartArt 形狀。Aspose.Slides for C++ 提供了最簡易的 API 以最簡單的方式建立 SmartArt 形狀。若要在投影片中建立 SmartArt 形狀，請遵循以下步驟：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
- 使用索引取得投影片的參考。
- 透過設定 LayoutType 新增 SmartArt 形狀。
- 將修改後的簡報寫入 PPTX 檔案。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSmartArtShape-CreateSmartArtShape.cpp" >}}

## **存取投影片上的 SmartArt 形狀**
以下程式碼用於存取簡報投影片中加入的 SmartArt 形狀。範例程式會遍歷投影片內的每個形狀，檢查其是否為 SmartArt 形狀。如果是 SmartArt，則將其型別轉換為 SmartArt 實例。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtShape-AccessSmartArtShape.cpp" >}}

## **依特定版面配置類型存取 SmartArt 形狀**
以下範例程式說明如何依特定 LayoutType 存取 SmartArt 形狀。請注意，SmartArt 的 LayoutType 為唯讀，僅在新增 SmartArt 形狀時設定。

- 建立 `Presentation` 類別的實例並載入含有 SmartArt 形狀的簡報。
- 使用索引取得第一張投影片的參考。
- 遍歷第一張投影片內的每個形狀。
- 若形狀為 SmartArt 類型，則將選取的形狀型別轉換為 SmartArt。
- 檢查具有特定 LayoutType 的 SmartArt 形狀，並依需求執行後續操作。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtParticularLayout-AccessSmartArtParticularLayout.cpp" >}}

## **變更 SmartArt 形狀樣式**
以下範例程式說明如何依特定 LayoutType 存取 SmartArt 形狀並變更其樣式。

- 建立 `Presentation` 類別的實例並載入含有 SmartArt 形狀的簡報。
- 使用索引取得第一張投影片的參考。
- 遍歷第一張投影片內的每個形狀。
- 若形狀為 SmartArt 類型，則將選取的形狀型別轉換為 SmartArt。
- 找到具有特定 Style 的 SmartArt 形狀。
- 為 SmartArt 形狀設定新的 Style。
- 儲存簡報。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangSmartArtShapeStyle-ChangSmartArtShapeStyle.cpp" >}}

## **變更 SmartArt 形狀顏色樣式**
在此範例中，我們將學習如何變更任意 SmartArt 形狀的顏色樣式。以下程式碼會存取具有特定顏色樣式的 SmartArt 形狀並變更其樣式。

- 建立 `Presentation` 類別的實例並載入含有 SmartArt 形狀的簡報。
- 使用索引取得第一張投影片的參考。
- 遍歷第一張投影片內的每個形狀。
- 若形狀為 SmartArt 類型，則將選取的形狀型別轉換為 SmartArt。
- 找到具有特定 Color Style 的 SmartArt 形狀。
- 為 SmartArt 形狀設定新的 Color Style。
- 儲存簡報。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtShapeColorStyle-ChangeSmartArtShapeColorStyle.cpp" >}}

## **常見問題**

**我可以將 SmartArt 以單一物件進行動畫化嗎？**

可以。SmartArt 本身就是形狀，您可以使用動畫 API（進入、退出、強調、移動路徑）套用[標準動畫](/slides/zh-hant/cpp/powerpoint-animation/)，就像其他形狀一樣。

**如果不知道 SmartArt 的內部 ID，該如何在投影片上找尋特定的 SmartArt？**

設定並使用替代文字（AltText），再以該值搜尋形狀——這是定位目標形狀的推薦方法。

**我可以將 SmartArt 與其他形狀群組嗎？**

可以。您可以將 SmartArt 與其他形狀（圖片、表格等）群組，然後[操作群組](/slides/zh-hant/cpp/group/)。

**如何取得特定 SmartArt 的圖像（例如作為預覽或報告使用）？**

匯出該形狀的縮圖/影像；此函式庫可以[將個別形狀渲染](/slides/zh-hant/cpp/create-shape-thumbnails/)為光柵檔案（PNG/JPG/TIFF）。

**將整份簡報轉換為 PDF 時，SmartArt 的外觀會被保留嗎？**

會。渲染引擎針對[PDF 匯出](/slides/zh-hant/cpp/convert-powerpoint-to-pdf/)提供高保真度，並提供多種品質與相容性選項。