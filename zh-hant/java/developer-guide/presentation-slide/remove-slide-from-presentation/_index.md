---
title: 在 Java 中從簡報中移除投影片
linktitle: 移除投影片
type: docs
weight: 30
url: /zh-hant/java/remove-slide-from-presentation/
keywords:
- 移除投影片
- 刪除投影片
- 移除未使用的投影片
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java，輕鬆從 PowerPoint 與 OpenDocument 簡報中移除投影片。獲取清晰的程式碼範例並提升工作流程。"
---
## **Introduction**

如果投影片（或其內容）變得多餘，您可以將其刪除。Aspose.Slides 提供了 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別，封裝了 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islidecollection/)，它是演示文稿中所有投影片的儲存庫。使用已知的 [ISlide](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/islide/) 物件的指標（參照或索引），您可以指定要移除的投影片。

## **Remove a Slide by Reference**

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。  
1. 透過投影片的 ID 或索引取得要移除的投影片參照。  
1. 從演示文稿中移除該參照的投影片。  
1. 儲存已修改的演示文稿。  

以下 Java 程式碼示範如何透過參照移除投影片：

```java
// 建立一個代表簡報檔案的 Presentation 物件
Presentation pres = new Presentation("demo.pptx");
try {
    // 透過投影片集合中的索引存取投影片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 透過參照移除投影片
    pres.getSlides().remove(slide);
    
    // 儲存已修改的簡報
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Remove a Slide by Index**

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 類別的實例。  
1. 透過索引位置從演示文稿中移除投影片。  
1. 儲存已修改的演示文稿。  

以下 Java 程式碼示範如何透過索引移除投影片：

```java
// 建立一個代表簡報檔案的 Presentation 物件
Presentation pres = new Presentation("demo.pptx");
try {
    // 透過投影片索引移除投影片
    pres.getSlides().removeAt(0);
    
    // 儲存已修改的簡報
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Remove Unused Layout Slides**

Aspose.Slides 提供了 [removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) 方法（來自 [Compress](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compress/) 類別），讓您刪除不需要且未使用的版面配置投影片。以下 Java 程式碼示範如何從 PowerPoint 演示文稿中移除版面配置投影片：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Remove Unused Master Slides**

Aspose.Slides 提供了 [removeUnusedMasterSlides](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) 方法（來自 [Compress](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/compress/) 類別），讓您刪除不需要且未使用的母版投影片。以下 Java 程式碼示範如何從 PowerPoint 演示文稿中移除母版投影片：

```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```

## **FAQ**

**刪除投影片後，投影片索引會發生什麼變化？**

刪除後，[collection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slidecollection/) 會重新編排索引：每個後續投影片向左移動一個位置，因此先前的索引號碼將不再正確。若需要穩定的參照，請使用每張投影片的持久 ID，而非其索引。

**投影片的 ID 與索引不同嗎？當相鄰投影片被刪除時，ID 會改變嗎？**

是的。索引是投影片在文件中的位置，當新增或刪除投影片時會變動。投影片 ID 為持久識別碼，其他投影片被刪除時不會改變。

**刪除投影片會如何影響投影片分節？**

如果該投影片屬於某個分節，該分節的投影片數量會減少一張。分節結構仍然保留；若分節變成空的，您可以依需求 [移除或重新組織分節](/slides/zh-hant/java/slide-section/)。

**刪除投影片時，附屬的備註與評論會發生什麼情況？**

[Notes](/slides/zh-hant/java/presentation-notes/) 與 [comments](/slides/zh-hant/java/presentation-comments/) 皆與該投影片綁定，會隨之一併移除。其他投影片的內容不受影響。

**刪除投影片與清理未使用的版面配置/母版有何不同？**

刪除是從投影片集合中移除特定的普通投影片。清理未使用的版面配置/母版則是移除沒有任何參照的版面配置或母版投影片，可減少檔案大小且不會改變剩餘投影片的內容。這兩者是互補的：通常先刪除，再進行清理。