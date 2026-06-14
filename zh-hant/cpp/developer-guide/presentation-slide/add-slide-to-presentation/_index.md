---
title: 在 C++ 中將投影片新增至簡報
linktitle: 新增投影片
type: docs
weight: 10
url: /zh-hant/cpp/add-slide-to-presentation/
keywords:
- 新增投影片
- 建立投影片
- 空白投影片
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++，輕鬆將投影片新增至您的 PowerPoint 與 OpenDocument 簡報——在數秒內即完成無縫且高效的投影片插入。"
---
## **概觀**

Aspose.Slides 允許您以程式方式將投影片加入 PowerPoint 簡報。簡報包含母片/版面投影片與一般投影片，一般投影片依零基索引排列。每張投影片都有唯一的 ID，且不支援沒有投影片的簡報檔案。

本文說明如何建立 `Presentation` 物件、存取其投影片集合、加入空白投影片、處理新加入的投影片，並儲存更新後的簡報。也會討論插入投影片至特定位置、使用版面配置，以及新建立的簡報中已存在的空白投影片等相關議題。

## **將投影片新增至簡報**
在討論如何將投影片加入簡報檔案之前，先說明一些關於投影片的事實。每個 PowerPoint 簡報檔案皆包含母片/版面投影片與其他一般投影片。這表示簡報檔案至少包含一張以上的投影片。必須注意，Aspose.Slides for C++ 不支援沒有投影片的簡報檔案。每張投影片都有唯一的 Id，且所有一般投影片依零基索引的順序排列。Aspose.Slides for C++ 讓開發者能夠向簡報加入空白投影片。要在簡報中加入空白投影片，請依照以下步驟：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
- 透過設定對 Presentation 物件所公開的 Slides（內容 Slide 物件集合）屬性的參考，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidecollection/) 類別。
- 呼叫 ISlideCollection 物件所公開的 AddEmptySlide 方法，將空白投影片加入內容投影片集合的末端。
- 對新加入的空白投影片執行一些操作。
- 最後，使用 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 物件寫入簡報檔案。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddSlides-AddSlides.cpp" >}}

## **常見問題集**

**我可以在特定位置插入新投影片，而不只是加入在末端嗎？**

可以。函式庫支援投影片集合的 [insert](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/slidecollection/insertclone/) 操作，因此您可以在所需的索引處加入投影片，而不僅限於末端。

**在根據版面新增投影片時，主題/樣式會被保留嗎？**

會。版面會繼承自其母片，而新投影片則繼承所選版面及其相關母片的格式。

**在新增投影片之前，新「空白」簡報中會有哪張投影片？**

新建立的簡報已預先包含一張索引為零的空白投影片。計算插入索引時必須考慮此點。

**如果母片有許多版面，我該如何為新投影片選擇「正確」的版面？**

通常選擇與所需結構相符的 [LayoutSlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/layoutslide/)（例如 [Title and Content、Two Content 等](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/slidelayouttype/)）。如果缺少此類版面，您可以[將它加入母片](/slides/zh-hant/cpp/slide-layout/)後再使用。