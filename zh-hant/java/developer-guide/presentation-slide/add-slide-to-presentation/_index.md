---
title: 在 Java 中向簡報新增投影片
linktitle: 新增投影片
type: docs
weight: 10
url: /zh-hant/java/add-slide-to-presentation/
keywords:
- 新增投影片
- 建立投影片
- 空白投影片
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java，輕鬆將投影片新增至您的 PowerPoint 與 OpenDocument 簡報——在數秒內完成無縫且高效的投影片插入。"
---
## **概觀**

Aspose.Slides 允許您以程式方式向 PowerPoint 簡報新增投影片。簡報包含母片/版面投影片與普通投影片，普通投影片依零基索引排列。每張投影片都有唯一的 ID，且不支援沒有投影片的簡報檔案。

本文說明如何建立 `Presentation` 物件、存取其投影片集合、加入空白投影片、處理新加入的投影片，以及儲存更新後的簡報。亦涵蓋插入投影片至特定位置、使用版面配置，以及了解新建立的簡報中已存在的空白投影片等相關議題。

## **將投影片加入簡報**

在討論將投影片加入簡報檔案之前，先說明投影片的一些事實。每個 PowerPoint 簡報檔案皆包含 **Master / Layout** 投影片以及其他 **Normal** 投影片。這表示簡報檔案至少包含一張或多張投影片。必須了解 Aspose.Slides for Java 不支援沒有投影片的簡報檔案。每張投影片都有唯一的 Id，且所有 Normal 投影片依零基索引的順序排列。

Aspose.Slides for Java 允許開發人員在簡報中加入空白投影片。若要在簡報中加入空白投影片，請依照以下步驟進行：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 類別的實例。
- 透過設定對 [Slides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation#getSlides--)（內容投影片物件集合）屬性的參考，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlideCollection) 類別。
- 呼叫 [**addEmptySlide**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) 方法，將空白投影片加入內容投影片集合的末端，此方法由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISlideCollection) 物件提供。
- 對新加入的空白投影片執行相關工作。
- 最後，使用 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 物件寫入簡報檔案。

```java
// 實例化代表簡報檔案的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 實例化 SlideCollection 類別
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // 將空白投影片新增至 Slides 集合
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // 對新加入的投影片執行一些操作

    // 將 PPTX 檔案儲存至磁碟
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **FAQ**

**我可以在特定位置插入新投影片，而不是只在末端嗎？**

是的。函式庫支援投影片集合以及 [insert](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) 操作，您可以在所需的索引位置加入投影片，而不僅限於末端。

**基於版面加入投影片時，主題/樣式會被保留嗎？**

會的。版面會繼承其母片的格式，而新投影片則會從所選版面及其相關的母片繼承格式。

**在新增投影片之前，新的「空白」簡報中存在哪張投影片？**

新建立的簡報已自動包含一張索引為零的空白投影片。計算插入索引時需考慮此點。

**如果母片有多個選項，該如何為新投影片選擇「正確」的版面？**

通常選擇與所需結構相符的 [LayoutSlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/layoutslide/)（例如 [Title and Content、Two Content 等](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slidelayouttype/)）。若缺少此類版面，您可以先[將其新增至母片](/slides/zh-hant/java/slide-layout/)，再加以使用。