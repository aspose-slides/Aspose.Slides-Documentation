---
title: 在 JavaScript 中向簡報新增投影片
linktitle: 新增投影片
type: docs
weight: 10
url: /zh-hant/nodejs-java/add-slide-to-presentation/
keywords:
- 新增投影片
- 建立投影片
- 空白投影片
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java，輕鬆將投影片新增至您的 PowerPoint 與 OpenDocument 簡報 —— 在數秒內即可完成順暢且高效的投影片插入。"
---
## **概觀**

Aspose.Slides 允許您以程式方式向 PowerPoint 簡報加入投影片。簡報包含母片/版面投影片與一般投影片，而一般投影片依零基索引排序。每張投影片都有唯一的 ID，且不支援不含投影片的簡報檔案。

本文說明如何建立 `Presentation` 物件、存取其投影片集合、新增空白投影片、處理剛新增的投影片，以及儲存更新後的簡報。還會涵蓋相關主題，例如在特定位置插入投影片、使用版面，以及了解新建立簡報中已存在的空白投影片。

## **將投影片新增至簡報**

在談論向簡報檔案新增投影片之前，我們先討論一些關於投影片的事實。每個 PowerPoint 簡報檔案都包含 **Master / Layout** 投影片以及其他 **Normal** 投影片。也就是說，簡報檔案至少包含一張以上的投影片。重要的是要知道 Aspose.Slides for Node.js via Java 不支援不含投影片的簡報檔案。每張投影片都有唯一的 Id，且所有 Normal 投影片依零基索引排序。

Aspose.Slides for Node.js via Java 允許開發人員向簡報新增空白投影片。要在簡報中新增空白投影片，請依照下列步驟操作：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 類別的實例。
- 透過設定對 [Slides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation#getSlides--)（內容 Slide 物件集合）屬性的參考，實例化 [SlideCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SlideCollection) 類別，此屬性由 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 物件公開。
- 呼叫 [**addEmptySlide**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SlideCollection#addEmptySlide-aspose.slides.ILayoutSlide-) 方法，將空白投影片新增至內容投影片集合的末端，此方法由 [SlideCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SlideCollection) 物件公開。
- 對新新增的空白投影片執行一些操作。
- 最後，使用 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 物件寫入簡報檔案。

```javascript
// 實例化代表簡報檔案的 Presentation 類別
var pres = new aspose.slides.Presentation();
try {
    // 實例化 SlideCollection 類別
    var slds = pres.getSlides();
    for (var i = 0; i < pres.getLayoutSlides().size(); i++) {
        // 將空白投影片新增至 Slides 集合
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // 對新新增的投影片執行一些操作
    // 將 PPTX 檔案儲存至磁碟
    pres.save("EmptySlide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **常見問題**

**我可以在特定位置插入新投影片，而不是只在末端嗎？**

可以。程式庫支援投影片集合以及 [insert](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidecollection/insertclone/) 操作，您可以在所需的索引位置新增投影片，而不僅限於末端。

**根據版面新增投影片時，主題/樣式會被保留嗎？**

會。版面會繼承其母片的格式，新投影片則會繼承所選版面及其相關母片的格式。

**在新增投影片之前，新「空白」簡報中已存在哪一張投影片？**

新建立的簡報已包含一張索引為零的空白投影片。計算插入索引時需考慮此點。

**如果母片有很多選項，該如何為新投影片選擇「正確」的版面？**

通常選擇與所需結構相符的 [LayoutSlide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/layoutslide/)（例如 [Title and Content、Two Content 等](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidelayouttype/)）。如果缺少此類版面，您可以 [將它新增至母片](/slides/zh-hant/nodejs-java/slide-layout/) 後再使用。