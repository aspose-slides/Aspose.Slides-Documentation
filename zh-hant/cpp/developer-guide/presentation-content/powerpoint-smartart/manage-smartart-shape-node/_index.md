---
title: 使用 C++ 管理簡報中的 SmartArt 形狀節點
linktitle: SmartArt 形狀節點
type: docs
weight: 30
url: /zh-hant/cpp/manage-smartart-shape-node/
keywords:
- SmartArt 節點
- 子節點
- 新增節點
- 節點位置
- 存取節點
- 移除節點
- 自訂位置
- 助理節點
- 填充格式
- 呈現節點
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: 使用 Aspose.Slides for C++ 在 PPT 與 PPTX 中管理 SmartArt 形狀節點。取得清晰的程式碼範例與技巧，簡化您的簡報製作。
---
## **概觀**

PowerPoint 簡報中的 SmartArt 圖形透過包含文字的節點來組織，並定義圖表的結構。Aspose.Slides 允許您以程式方式操作這些 SmartArt 節點：新增節點與子節點、在特定位置插入子節點、存取現有節點，並讀取其文字、層級與位置。

本文說明如何管理 SmartArt 形狀節點。內容包括移除節點、依索引或位置操作子節點、將助理節點轉為普通節點、調整 SmartArt 節點形狀的位置、大小與旋轉、設定節點填充格式，以及為 SmartArt 子節點產生縮圖。

## **新增 SmartArt 節點**
Aspose.Slides for C++ 提供了最簡易的 API 以最輕鬆的方式管理 SmartArt 形狀。以下範例程式碼說明如何在 SmartArt 形狀中新增節點與子節點。

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別實例，並載入包含 SmartArt 形狀的簡報。
- 使用索引取得第一張投影片的參考。
- 遍歷第一張投影片內的每個形狀。
- 判斷形狀是否為 SmartArt 類型，若是則將選取的形狀型別轉換為 SmartArt。
- 在 SmartArt 的 NodeCollection 中新增節點，並在 TextFrame 中設定文字。
- 接著在剛新增的 SmartArt 節點中加入子節點，並在 TextFrame 中設定文字。
- 儲存簡報。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodes-AddNodes.cpp" >}}

## **在特定位置新增 SmartArt 節點**
以下範例說明如何在 SmartArt 形狀的相對節點中於特定位置新增子節點。

- 建立 `Presentation` 類別實例。
- 使用索引取得第一張投影片的參考。
- 在取得的投影片中新增 StackedList 類型的 SmartArt 形狀。
- 取得新增 SmartArt 形狀的第一個節點。
- 在該節點的第 2 個位置加入子節點，並設定其文字。
- 儲存簡報。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodesSpecificPosition-AddNodesSpecificPosition.cpp" >}}

## **存取 SmartArt 節點**
以下範例說明如何存取 SmartArt 形狀內的節點。請注意，SmartArt 的 LayoutType 為唯讀，僅在新增 SmartArt 形狀時設定，無法更改。

- 建立 `Presentation` 類別實例，並載入包含 SmartArt 形狀的簡報。
- 使用索引取得第一張投影片的參考。
- 遍歷第一張投影片內的每個形狀。
- 判斷形狀是否為 SmartArt 類型，若是則將選取的形狀型別轉換為 SmartArt。
- 遍歷 SmartArt 形狀內的所有節點。
- 存取並顯示如節點位置、層級與文字等資訊。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArt-AccessSmartArt.cpp" >}}

## **存取 SmartArt 子節點**
以下範例說明如何存取屬於 SmartArt 形狀各節點的子節點。

- 建立 PresentationEx 類別實例，並載入包含 SmartArt 形狀的簡報。
- 使用索引取得第一張投影片的參考。
- 遍歷第一張投影片內的每個形狀。
- 判斷形狀是否為 SmartArt 類型，若是則將選取的形狀型別轉換為 SmartArtEx。
- 遍歷 SmartArt 形狀內的所有節點。
- 對每個選取的 SmartArt 節點，遍歷該節點內的所有子節點。
- 存取並顯示子節點的位置、層級與文字等資訊。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodes-AccessChildNodes.cpp" >}}

## **在特定位置存取 SmartArt 子節點**
本範例示範如何在特定位置存取屬於 SmartArt 各節點的子節點。

- 建立 `Presentation` 類別實例。
- 使用索引取得第一張投影片的參考。
- 新增 StackedList 類型的 SmartArt 形狀。
- 取得新增的 SmartArt 形狀。
- 取得該 SmartArt 形狀索引為 0 的節點。
- 使用 GetNodeByPosition() 方法在該節點上取得位置 1 的子節點。
- 存取並顯示子節點的位置、層級與文字等資訊。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodeSpecificPosition-AccessChildNodeSpecificPosition.cpp" >}}

## **移除 SmartArt 節點**
本範例說明如何移除 SmartArt 形狀內的節點。

- 建立 `Presentation` 類別實例，並載入包含 SmartArt 形狀的簡報。
- 使用索引取得第一張投影片的參考。
- 遍歷第一張投影片內的每個形狀。
- 判斷形狀是否為 SmartArt 類型，若是則將選取的形狀型別轉換為 SmartArt。
- 檢查 SmartArt 是否有超過 0 個節點。
- 選取要刪除的 SmartArt 節點。
- 使用 RemoveNode() 方法移除所選節點，然後儲存簡報。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNode-RemoveNode.cpp" >}}

## **在特定位置移除 SmartArt 節點**
本範例說明如何在特定位置移除 SmartArt 形狀內的節點。

- 建立 `Presentation` 類別實例，並載入包含 SmartArt 形狀的簡報。
- 使用索引取得第一張投影片的參考。
- 遍歷第一張投影片內的每個形狀。
- 判斷形狀是否為 SmartArt 類型，若是則將選取的形狀型別轉換為 SmartArt。
- 選取索引為 0 的 SmartArt 形狀節點。
- 檢查所選 SmartArt 節點是否有超過 2 個子節點。
- 使用 RemoveNodeByPosition() 方法移除位置 1 的節點。
- 儲存簡報。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNodeSpecificPosition-RemoveNodeSpecificPosition.cpp" >}}

## **為 SmartArt 子節點設定自訂位置**
現在 Aspose.Slides 支援設定 SmartArtShape 的 X 與 Y 屬性。以下程式碼片段示範如何設定自訂的 SmartArtShape 位置、大小與旋轉，請注意新增節點會重新計算所有節點的位子與大小。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomChildNodesInSmartArt-CustomChildNodesInSmartArt.cpp" >}}

## **檢查助理節點**
以下範例說明如何在 SmartArt 節點集合中辨識助理節點並將其變更。

- 建立 PresentationEx 類別實例，並載入包含 SmartArt 形狀的簡報。
- 使用索引取得第二張投影片的參考。
- 遍歷第一張投影片內的每個形狀。
- 判斷形狀是否為 SmartArt 類型，若是則將選取的形狀型別轉換為 SmartArtEx。
- 遍歷 SmartArt 形狀內的所有節點，檢查是否為助理節點。
- 將助理節點的狀態變更為普通節點。
- 儲存簡報。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AssistantNode-AssistantNode.cpp" >}}

## **設定節點的填充格式**
Aspose.Slides for C++ 允許您新增自訂的 SmartArt 形狀並設定其填充格式。本文說明如何建立與存取 SmartArt 形狀，並使用 Aspose.Slides for C++ 設定其填充格式。

請依照下列步驟操作：

- 建立 `Presentation` 類別實例。
- 使用索引取得投影片的參考。
- 依 LayoutType 加入 SmartArt 形狀。
- 為 SmartArt 形狀的節點設定 FillFormat。
- 將修改後的簡報寫出為 PPTX 檔案。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FillFormatSmartArtShapeNode-FillFormatSmartArtShapeNode.cpp" >}}

## **產生 SmartArt 子節點的縮圖**
開發人員可依下列步驟產生 SmartArt 子節點的縮圖：

1. 建立代表 PPTX 檔案的 `Presentation` 類別實例。
1. 新增 SmartArt。
1. 使用索引取得節點參考。
1. 取得縮圖影像。
1. 以任意圖片格式儲存縮圖。

以下範例示範產生 SmartArt 子節點的縮圖

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
auto node = smartArt->get_Node(1);

auto image = node->get_Shape(0)->GetImage();
image->Save(u"SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **常見問題集**

**SmartArt 是否支援動畫？**

是。SmartArt 會被視為一般形狀，您可以[套用標準動畫](/slides/zh-hant/cpp/shape-animation/)(進入、退場、強調、移動路徑)並調整時間。必要時亦可對 SmartArt 節點內的形狀進行動畫設定。

**如果不知道內部 ID，如何可靠地在投影片上定位特定 SmartArt？**

可透過[替代文字](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/set_alternativetext/)設定唯一的 AltText，之後以程式方式搜尋該文字即可，而不必依賴內部識別碼。

**將簡報轉為 PDF 時，SmartArt 的外觀會被保留嗎？**

會。Aspose.Slides 在[PDF 匯出](/slides/zh-hant/cpp/convert-powerpoint-to-pdf/)過程中以高視覺忠實度渲染 SmartArt，保留版面、顏色與效果。

**我可以擷取整個 SmartArt 的圖像以供預覽或報告使用嗎？**

可以。您可將 SmartArt 形狀渲染為[點陣格式](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/getimage/)或[SVG](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/writeassvg/)，以取得縮圖、報告或網頁使用的向量或點陣圖像。