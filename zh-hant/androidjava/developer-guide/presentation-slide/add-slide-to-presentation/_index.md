---
title: 在 Android 上向簡報加入投影片
linktitle: 加入投影片
type: docs
weight: 10
url: /zh-hant/androidjava/add-slide-to-presentation/
keywords:
- 新增投影片
- 建立投影片
- 空白投影片
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "輕鬆使用 Aspose.Slides for Android via Java，將投影片加入您的 PowerPoint 和 OpenDocument 簡報——在數秒內完成無縫且高效的投影片插入。"
---
## **概觀**

Aspose.Slides 允許您以程式方式向 PowerPoint 簡報加入投影片。簡報包含母片/版面投影片與一般投影片，且一般投影片依零基索引排列。每張投影片都有唯一的 ID，且不支援沒有投影片的簡報檔案。

本文章說明如何建立 `Presentation` 物件、存取其投影片集合、加入空白投影片、處理新加入的投影片，並儲存已更新的簡報。亦涵蓋插入投影片至特定位置、使用版面配置，以及了解新建立的簡報中已存在的空白投影片等相關要點。

## **將投影片新增至簡報**

在討論如何將投影片新增至簡報檔案之前，先說明一些關於投影片的事實。每個 PowerPoint 簡報檔案包含 **Master / Layout** 投影片與其他 **Normal** 投影片。這表示簡報檔案至少包含一張以上的投影片。重要的是，Aspose.Slides for Android via Java 不支援沒有投影片的簡報檔案。每張投影片都有唯一的 Id，且所有 Normal 投影片依零基索引順序排列。

Aspose.Slides for Android via Java 允許開發者在簡報中加入空白投影片。若要在簡報中加入空白投影片，請依照以下步驟操作：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 類別的實例。
- 透過設定對 [Slides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation#getSlides--)（內容投影片物件集合）屬性的參考，實例化 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection) 類別。
- 呼叫由 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISlideCollection) 物件公開的 **addEmptySlide** 方法，將空白投影片加入內容投影片集合的末端。
- 對新加入的空白投影片執行一些操作。
- 最後，使用 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 物件寫入簡報檔案。

```java
// 實例化表示簡報檔案的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 實例化 SlideCollection 類別
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // 將空白投影片加入 Slides 集合
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // 對新加入的投影片執行一些操作

    // 將 PPTX 檔案儲存至磁碟
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **常見問題**

**我可以在特定位置插入新投影片，而不僅僅是在末尾嗎？**

是的。函式庫支援投影片集合以及 [insert](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) 操作，因此您可以在所需的索引處加入投影片，而不僅限於末端。

**基於版面配置加入投影片時，主題/樣式會保留嗎？**

會的。版面配置會繼承其母片的格式，而新投影片會繼承所選版面配置及其相關母片的設定。

**在新增投影片之前，新「空白」簡報中會包含哪一張投影片？**

新建立的簡報已預先包含一張索引為零的空白投影片。計算插入索引時必須考慮到這一點。

**如果母片有許多選項，該如何為新投影片選擇「正確」的版面配置？**

一般而言，請選取符合所需結構的 [LayoutSlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/layoutslide/)（例如 [Title and Content、Two Content 等](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slidelayouttype/)）。若缺少符合需求的版面配置，您可以先 [將其新增至母片](/slides/zh-hant/androidjava/slide-layout/)，再加以使用。