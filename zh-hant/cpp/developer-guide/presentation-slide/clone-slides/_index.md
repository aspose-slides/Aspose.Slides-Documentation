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
description: "使用 Aspose.Slides for C++ 快速複製 PowerPoint 投影片。遵循我們清晰的程式碼範例，讓您在數秒內自動化 PPT 建立，省去手動操作。"
---
## **簡介**

克隆是製作某物的完全相同副本或複製的過程。Aspose.Slides for C++ 也可以對任何投影片進行複製或克隆，然後將該克隆投影片插入當前或其他已開啟的簡報中。投影片克隆的過程會建立一個新投影片，開發人員可以修改它而不會更改原始投影片。克隆投影片有以下幾種可能的方式：

- 在簡報內的結尾處克隆。
- 在簡報內的其他位置克隆。
- 在另一個簡報的結尾處克隆。
- 在另一個簡報的其他位置克隆。
- 在另一個簡報的特定位置克隆。

在 Aspose.Slides for C++ 中，由 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 物件所公開的 (一組 [ISlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islide/) 物件) 提供了 [AddClone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/addclone/) 和 [InsertClone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/insertclone/) 方法，以執行上述類型的投影片克隆。

## **在簡報的結尾克隆投影片**
如果您想要克隆投影片，並在同一簡報檔案的現有投影片之後使用它，請依照下列步驟使用 [AddClone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/addclone/) 方法：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。  
2. 透過參考由 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 物件所公開的 Slides 集合，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/) 類別。  
3. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/) 物件所公開的 [AddClone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/addclone/) 方法，並將要克隆的投影片作為參數傳遞給該方法。  
4. 寫入已修改的簡報檔案。

以下範例示範了我們將投影片（位於簡報的第一個位置 – 零索引）克隆至簡報的結尾。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithinSamePresentationToEnd-CloneWithinSamePresentationToEnd.cpp" >}}

## **在簡報內的其他位置克隆投影片**
如果您想要克隆投影片，並在同一簡報檔案中的不同位置使用它，請使用 [InsertClone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/insertclone/) 方法：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。  
2. 透過參考由 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 物件所公開的 **Slides** 集合，實例化相應的類別。  
3. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/) 物件所公開的 [InsertClone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/insertclone/) 方法，將要克隆的投影片與新位置的索引一起作為參數傳遞給該方法。  
4. 將修改後的簡報寫入為 PPTX 檔案。

以下範例示範了我們將投影片（位於零索引 – 位置 1 – 的投影片）克隆至索引 1 – 位置 2 –。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneWithInSamePresentation-CloneWithInSamePresentation.cpp" >}}

## **在另一個簡報的結尾克隆投影片**
如果您需要從一個簡報中克隆投影片，並將其放入另一個簡報檔案的現有投影片之後：

1. 建立一個包含來源簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別實例。  
2. 建立一個包含目標簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別實例。  
3. 透過參考目標簡報的 **Slides** 集合，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/) 類別。  
4. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/) 物件所公開的 [AddClone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/addclone/) 方法，將來源簡報中的投影片作為參數傳遞給該方法。  
5. 寫入已修改的目標簡報檔案。

以下範例示範了我們將投影片（來源簡報的第一個索引）克隆至目標簡報的結尾。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **在另一個簡報的其他位置克隆投影片**
如果您需要從一個簡報中克隆投影片，並在另一個簡報檔案的特定位置使用它：

1. 建立一個包含來源簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別實例。  
2. 建立一個包含目標簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別實例。  
3. 透過參考目標簡報的 Slides 集合，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/) 類別。  
4. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/) 物件所公開的 [InsertClone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/insertclone/) 方法，將來源簡報的投影片與欲插入的位置一起作為參數傳遞給該方法。  
5. 寫入已修改的目標簡報檔案。

以下範例示範了我們將投影片（來源簡報的零索引）克隆至目標簡報的索引 1（位置 2）。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneAtEndOfAnotherPresentation-CloneAtEndOfAnotherPresentation.cpp" >}}

## **在另一個簡報的特定位置克隆投影片（含母版）**
如果您需要從一個簡報中克隆帶有母版的投影片並在另一個簡報中使用，必須先將來源簡報的目標母版克隆至目標簡報，之後再使用該母版來克隆投影片。**AddClone(ISlide, IMasterSlide)** 需要目標簡報的母版，而非來源簡報的母版。請依照以下步驟克隆帶母版的投影片：

1. 建立一個包含來源簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別實例。  
2. 建立一個包含目標簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別實例。  
3. 取用要克隆的投影片及其母版。  
4. 透過參考目標簡報的 Masters 集合，實例化 [IMasterSlideCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterslidecollection/) 類別。  
5. 呼叫由 [IMasterSlideCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/imasterslidecollection/) 物件所公開的 [AddClone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/addclone/) 方法，將來源 PPTX 的母版作為參數傳遞。  
6. 透過參考目標簡報的 Slides 集合，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/) 類別。  
7. 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/) 物件所公開的 [AddClone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/addclone/) 方法，將來源簡報的投影片與剛剛克隆的母版一起作為參數傳遞。  
8. 寫入已修改的目標簡報檔案。

以下範例示範了我們將帶母版的投影片（來源簡報的零索引）克隆至目標簡報的結尾，使用來源投影片的母版。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneToAnotherPresentationWithMaster-CloneToAnotherPresentationWithMaster.cpp" >}}

## **在指定分段的結尾克隆投影片**
如果您想要克隆投影片，並在同一簡報檔案的不同分段使用它，請使用由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/) 介面所公開的 [AddClone()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/addclone/) 方法。Aspose.Slides for C++ 允許從第一個分段克隆投影片，然後將該克隆投影片插入同一簡報的第二個分段。

以下程式碼片段示範了如何克隆投影片並將克隆的投影片插入指定的分段。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CloneSlideIntoSpecifiedSection-CloneSlideIntoSpecifiedSection.cpp" >}}

## **確保投影片尺寸相符**

在將投影片克隆至另一個簡報時，請確保目標簡報的投影片尺寸與來源簡報相同。若尺寸不同，Aspose.Slides 不會自動重新縮放克隆的形狀——其原始座標與尺寸會被保留，可能導致內容對齊不正確或超出投影片邊界。

您可以在克隆母版與投影片之前，先將目標簡報的投影片尺寸設定為與來源相同：

```cpp
auto sourceSize = sourcePresentation->get_SlideSize()->get_Size();

targetPresentation->get_SlideSize()->SetSize(
    sourceSize.get_Width(), sourceSize.get_Height(), SlideSizeScaleType::DoNotScale);
```

在克隆母版與投影片之前執行此操作。

## **常見問題**

**演講者備註與審閱者評論會被克隆嗎？**

會的。備註頁面與審閱評論會包含在克隆中。若不需要它們，請在插入後 [移除它們](/slides/zh-hant/cpp/presentation-notes/)。

**圖表及其資料來源如何處理？**

圖表物件、格式設定與內嵌資料會被複製。若圖表連結至外部來源（例如 OLE 嵌入的活頁簿），此連結會以 [OLE 物件](/slides/zh-hant/cpp/manage-ole/) 形式保留下來。檔案搬移後，請確認資料可用性並檢查重新整理行為。

**我可以控制克隆的插入位置與分段嗎？**

可以。您可以在特定投影片索引插入克隆，並將其放入選定的 [分段](/slides/zh-hant/cpp/slide-section/)。如果目標分段不存在，請先建立，然後將投影片移入其中。