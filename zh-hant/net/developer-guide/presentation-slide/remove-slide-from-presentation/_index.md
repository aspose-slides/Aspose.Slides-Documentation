---
title: 在 .NET 中從簡報中移除投影片
linktitle: 移除投影片
type: docs
weight: 30
url: /zh-hant/net/remove-slide-from-presentation/
keywords:
- 移除投影片
- 刪除投影片
- 移除未使用的投影片
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET，輕鬆從 PowerPoint 與 OpenDocument 簡報中移除投影片。獲取清晰的 C# 程式碼範例，提升您的工作流程。"
---
## **簡介**

如果投影片（或其內容）變得多餘，您可以將其刪除。Aspose.Slides 提供 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別，封裝了 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidecollection)，它是儲存簡報中所有投影片的倉庫。使用已知的 [ISlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide/) 物件的指標（參照或索引），即可指定要移除的投影片。

## **依參照移除投影片**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。
2. 透過投影片的 ID 或索引取得要移除的投影片參照。
3. 從簡報中移除參照的投影片。
4. 儲存已修改的簡報。

```c#
// 實例化一個代表簡報檔案的 Presentation 物件
using (Presentation pres = new Presentation("RemoveSlideUsingReference.pptx"))
{
    // 透過投影片集合中的索引存取投影片
    ISlide slide = pres.Slides[0];

    // 透過參考移除投影片
    pres.Slides.Remove(slide);

    // 儲存已修改的簡報
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **依索引移除投影片**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。
2. 透過索引位置從簡報中移除投影片。
3. 儲存已修改的簡報。

```c#
// 實例化一個代表簡報檔案的 Presentation 物件
using (Presentation pres = new Presentation("RemoveSlideUsingIndex.pptx"))
{

    // 透過投影片索引移除投影片
    pres.Slides.RemoveAt(0);

    // 儲存已修改的簡報
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **移除未使用的版面投影片**

Aspose.Slides 提供 [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) 方法（來自 [Compress](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/compress/) 類別），讓您刪除不需要且未使用的版面投影片。以下 C# 程式碼示範如何從 PowerPoint 簡報中移除版面投影片：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **移除未使用的母片投影片**

Aspose.Slides 提供 [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) 方法（來自 [Compress](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.lowcode/compress/) 類別），讓您刪除不需要且未使用的母片投影片。以下 C# 程式碼示範如何從 PowerPoint 簡報中移除母片投影片：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **常見問題**

**刪除投影片後，投影片索引會發生什麼變化？**

刪除後，[collection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slidecollection/) 會重新索引：每個後續投影片向左移動一個位置，因此先前的索引編號將不再正確。若需要穩定的參照，請使用每張投影片的持久 ID，而非其索引。

**投影片的 ID 是否與索引不同，且在相鄰投影片被刪除時會改變嗎？**

是的。索引代表投影片的位置，會在投影片新增或移除時變動。投影片 ID 為持久識別碼，刪除其他投影片時不會改變。

**刪除投影片會如何影響投影片分節？**

若該投影片屬於某個分節，該分節只會少一張投影片。分節結構保持不變；如果分節變成空的，您可以依需求[刪除或重新組織分節](/slides/zh-hant/net/slide-section/)。

**當投影片被刪除時，附加的註解與評論會發生什麼事？**

[Notes](/slides/zh-hant/net/presentation-notes/) 與 [comments](/slides/zh-hant/net/presentation-comments/) 皆與特定投影片綁定，會隨該投影片一起被移除。其他投影片的內容不受影響。

**刪除投影片與清理未使用的版面/母片有何不同？**

刪除會從簡報中移除特定的普通投影片。清理未使用的版面/母片則會刪除未被任何投影片引用的版面或母片投影片，減少檔案大小且不會改變剩餘投影片的內容。這兩項操作是互補的：通常先刪除，之後再清理。