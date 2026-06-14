---
title: 在 C++ 中克隆簡報投影片
linktitle: 克隆投影片
type: docs
weight: 40
url: /zh-hant/cpp/clone-slides/
keywords:
- 克隆投影片
- 複製投影片
- 保存投影片
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "快速使用 Aspose.Slides for C++ 複製 PowerPoint 投影片。遵循我們清晰的程式碼範例，即可在數秒內自動建立 PPT，消除手動操作。"
---
## **簡介**

克隆是製作精確副本或複製品的過程。Aspose.Slides for C++ 也可以複製或克隆任何投影片，然後將該克隆投影片插入當前或任何其他已開啟的簡報中。投影片克隆的過程會產生一個新投影片，開發人員可在不更改原始投影片的情況下對其進行修改。克隆投影片有以下幾種可能方式：

- 在簡報結尾處克隆。
- 在簡報內的其他位置克隆。
- 在另一個簡報結尾處克隆。
- 在另一個簡報的其他位置克隆。
- 在另一個簡報的特定位置克隆。

在 Aspose.Slides for C++ 中，（由 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 物件公開的 [ISlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/) 物件集合）提供了 [AddClone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/addclone/) 和 [InsertClone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/insertclone/) 方法，以執行上述各類投影片克隆。

## **在簡報結尾處克隆投影片**
如果您想克隆投影片，並在同一簡報檔案的現有投影片結尾處使用它，請依照下列步驟使用 [AddClone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/addclone/) 方法：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
2. 透過參考由 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 物件公開的 Slides 集合，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/) 類別。
3. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/) 物件公開的 [AddClone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/addclone/) 方法，並將要克隆的投影片作為參數傳遞給該方法。
4. 寫入已修改的簡報檔案。

在下方範例中，我們將簡報中第一個位置（索引為 0）的投影片克隆至簡報的結尾。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **在簡報內的其他位置克隆投影片**
如果您想克隆投影片，並在同一簡報檔案的不同位置使用它，請使用 [InsertClone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/insertclone/) 方法：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
2. 透過參考由 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 物件公開的 **Slides** 集合，實例化該類別。
3. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/) 物件公開的 [InsertClone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/insertclone/) 方法，將要克隆的投影片以及新位置的索引作為參數傳遞給該方法。
4. 將修改後的簡報寫入為 PPTX 檔案。

在下方範例中，我們將簡報中索引為 0（位置 1）的投影片克隆至索引 1（位置 2）。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **在另一個簡報的結尾處克隆投影片**
如果您需要從一個簡報克隆投影片，並將其插入另一個簡報檔案的結尾處：

1. 建立包含來源簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別實例。
2. 建立包含目標簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別實例。
3. 透過參考目標簡報的 Presentation 物件公開的 **Slides** 集合，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/) 類別。
4. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/) 物件公開的 [AddClone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/addclone/) 方法，將來源簡報的投影片作為參數傳遞給該方法。
5. 寫入已修改的目標簡報檔案。

在下方範例中，我們將來源簡報第一個索引的投影片克隆至目標簡報的結尾處。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **在另一個簡報的其他位置克隆投影片**
如果您需要從一個簡報克隆投影片，並在另一個簡報檔案的特定位置使用它：

1. 建立包含來源簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別實例。
2. 建立包含目標簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別實例。
3. 透過參考目標簡報的 Presentation 物件公開的 Slides 集合，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/) 類別。
4. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/) 物件公開的 [InsertClone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/insertclone/) 方法，將來源簡報的投影片以及期望的位置作為參數傳遞給該方法。
5. 寫入已修改的目標簡報檔案。

在下方範例中，我們將來源簡報索引為 0 的投影片克隆至目標簡報索引 1（位置 2）。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **在另一個簡報的特定位置克隆投影片**
如果您需要從一個簡報克隆包含母片的投影片，並在另一個簡報中使用，必須先將來源簡報的目標母片克隆至目標簡報，然後使用該母片來克隆投影片。**AddClone(ISlide, IMasterSlide)** 期望的母片來自目標簡報，而非來源簡報。要克隆帶母片的投影片，請依照下列步驟操作：

1. 建立包含來源簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別實例。
2. 建立包含目標簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別實例。
3. 取得要克隆的投影片及其母片。
4. 透過參考目標簡報的 Presentation 物件公開的 Masters 集合，實例化 [IMasterSlideCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterslidecollection/) 類別。
5. 呼叫由 [IMasterSlideCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterslidecollection/) 物件公開的 [AddClone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/addclone/) 方法，將來源 PPTX 的母片作為參數傳遞給該方法。
6. 透過參考目標簡報的 Presentation 物件公開的 Slides 集合，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/) 類別。
7. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/) 物件公開的 [AddClone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/addclone/) 方法，將來源簡報的投影片與目標母片作為參數傳遞給該方法。
8. 寫入已修改的目標簡報檔案。

在下方範例中，我們將來源簡報索引為 0 的帶母片投影片克隆至目標簡報的結尾，使用來源投影片的母片。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **在指定章節的結尾處克隆投影片**
如果您想克隆投影片，並在同一簡報檔案的不同章節中使用它，請使用由 [**ISlideCollection**](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/) 介面公開的 [**AddClone()**](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/addclone/) 方法。Aspose.Slides for C++ 允許您從第一章節克隆投影片，然後將該克隆投影片插入同一簡報的第二章節。

以下程式碼片段示範如何克隆投影片並將克隆的投影片插入指定章節。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **常見問題集**

**會一起克隆講者備註和審閱者評論嗎？**

會。備註頁面與審閱評論會包含在克隆中。如不需要，插入後可[移除它們](/slides/zh-hant/cpp/presentation-notes/)。

**圖表及其資料來源如何處理？**

圖表物件、格式與內嵌資料皆會被複製。如果圖表連結至外部來源（例如 OLE 嵌入的活頁簿），該連結會保留為[OLE 物件](/slides/zh-hant/cpp/manage-ole/)。在檔案間移動後，請確認資料可用性並重新整理行為。

**我能控制克隆的插入位置和章節嗎？**

可以。您可以在特定投影片索引插入克隆，並將其放入選定的[章節](/slides/zh-hant/cpp/slide-section/)。如果目標章節不存在，請先建立章節，再將投影片移入其中。