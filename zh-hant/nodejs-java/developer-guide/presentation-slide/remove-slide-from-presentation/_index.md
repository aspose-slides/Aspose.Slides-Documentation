---
title: 在 JavaScript 中從簡報移除投影片
linktitle: 移除投影片
type: docs
weight: 30
url: /zh-hant/nodejs-java/remove-slide-from-presentation/
keywords:
- 移除投影片
- 刪除投影片
- 移除未使用的投影片
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "輕鬆使用 Aspose.Slides for Node.js 從 PowerPoint 與 OpenDocument 簡報中移除投影片。取得清晰的程式碼範例，提升工作流程。"
---
## **簡介**

如果投影片（或其內容）變得多餘，您可以將其刪除。Aspose.Slides 提供了 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別，該類別封裝了 [SlideCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidecollection/)，用於儲存簡報中的所有投影片。使用已知的 [Slide](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slide/) 物件的指標（參考或 Index），即可指定要移除的投影片。

## **依參考移除投影片**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。  
1. 透過其 ID 或 Index 取得要移除的投影片參考。  
1. 從簡報中移除該參考的投影片。  
1. 儲存已修改的簡報。  

以下 JavaScript 程式碼示範如何透過參考移除投影片：

```javascript
// 實例化一個代表簡報檔案的 Presentation 物件
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // 透過投影片集合中的索引存取投影片
    var slide = pres.getSlides().get_Item(0);
    // 透過參考移除投影片
    pres.getSlides().remove(slide);
    // 儲存已修改的簡報
    pres.save("modified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **依索引移除投影片**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別的實例。  
1. 透過其索引位置從簡報中移除投影片。  
1. 儲存已修改的簡報。  

以下 JavaScript 程式碼示範如何透過索引移除投影片：

```javascript
// 實例化一個代表簡報檔案的 Presentation 物件
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // 透過投影片索引移除投影片
    pres.getSlides().removeAt(0);
    // 儲存已修改的簡報
    pres.save("modified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **移除未使用的版面配置投影片**

Aspose.Slides 提供了 [removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides-aspose.slides.Presentation-) 方法（屬於 [Compress](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/compress/) 類別），讓您刪除不需要且未使用的版面配置投影片。以下 JavaScript 程式碼示範如何從 PowerPoint 簡報中移除版面配置投影片：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **移除未使用的母片投影片**

Aspose.Slides 提供了 [removeUnusedMasterSlides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides-aspose.slides.Presentation-) 方法（屬於 [Compress](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/compress/) 類別），讓您刪除不需要且未使用的母片投影片。以下 JavaScript 程式碼示範如何從 PowerPoint 簡報中移除母片投影片：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**刪除投影片後，投影片索引會發生什麼變化？**

刪除後，[collection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slidecollection/) 會重新編號：之後的每一張投影片向左移動一個位置，先前的索引號碼因此失效。如果需要穩定的參考，請使用每張投影片的永久 ID，而非其索引。

**投影片的 ID 與索引不同嗎？在相鄰投影片被刪除時會改變嗎？**

是的。索引是投影片在簡報中的位置，當新增或刪除投影片時會改變。投影片 ID 是永久的識別碼，即使其他投影片被刪除也不會變更。

**刪除投影片會如何影響投影片分段？**

如果該投影片屬於某個分段，該分段只會少一張投影片。分段結構仍然保留；若分段變為空白，您可以[移除或重新組織分段](/slides/zh-hant/nodejs-java/slide-section/)（依需求）。

**刪除投影片時，附加在該投影片上的備註與評論會發生什麼情況？**

[Notes](/slides/zh-hant/nodejs-java/presentation-notes/) 與 [comments](/slides/zh-hant/nodejs-java/presentation-comments/) 會與該投影片一起被移除。其他投影片的內容不受影響。

**刪除投影片與清理未使用的版面配置/母片有何不同？**

刪除會從簡報中移除特定的普通投影片。清理未使用的版面配置/母片會移除沒有任何參照的版面配置或母片投影片，減少檔案大小且不會改變剩餘投影片的內容。這兩個動作是互補的：通常先刪除投影片，然後再進行清理。