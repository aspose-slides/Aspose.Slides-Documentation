---
title: 在 Android 上從簡報中移除投影片
linktitle: 移除投影片
type: docs
weight: 30
url: /zh-hant/androidjava/remove-slide-from-presentation/
keywords:
- 移除投影片
- 刪除投影片
- 移除未使用的投影片
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 輕鬆從 PowerPoint 與 OpenDocument 簡報中移除投影片。取得清晰的 Java 程式碼範例，提升工作流程。"
---
## **簡介**

如果投影片（或其內容）變得多餘，您可以將其刪除。Aspose.Slides 提供了 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別，該類別封裝了 [ISlideCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islidecollection/)，是保存簡報中所有投影片的儲存庫。使用已知的 [ISlide](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/islide/) 物件的指標（參照或索引），您可以指定要移除的投影片。

## **透過參照移除投影片**

1. 建立 [Presentation] 類別的實例。
1. 透過其 ID 或索引取得要移除的投影片參照。
1. 從簡報中移除參照的投影片。
1. 儲存已修改的簡報。

以下 Java 程式碼示範如何透過參照移除投影片：

```java
// 實例化一個代表簡報檔案的 Presentation 物件
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

## **透過索引移除投影片**

1. 建立 [Presentation] 類別的實例。
1. 透過索引位置從簡報中移除投影片。
1. 儲存已修改的簡報。

以下 Java 程式碼示範如何透過索引移除投影片：

```java
// 實例化一個代表簡報檔案的 Presentation 物件
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

## **移除未使用的版面配置投影片**

Aspose.Slides 提供了 [removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) 方法（位於 [Compress](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compress/) 類別），讓您刪除不需要且未使用的版面配置投影片。以下 Java 程式碼示範如何從 PowerPoint 簡報中移除版面配置投影片：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **移除未使用的母片投影片**

Aspose.Slides 提供了 [removeUnusedMasterSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) 方法（位於 [Compress](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/compress/) 類別），讓您刪除不需要且未使用的母片投影片。以下 Java 程式碼示範如何從 PowerPoint 簡報中移除母片投影片：

```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```

## **常見問題**

**刪除投影片後，投影片索引會發生什麼變化？**

刪除後，[collection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slidecollection/) 會重新索引：每個後續投影片向左移動一個位置，先前的索引號碼變得不再正確。若您需要穩定的參照，請使用每張投影片的永久 ID 而非其索引。

**投影片的 ID 是否與索引不同，且在刪除相鄰投影片時會變動嗎？**

是的。索引是投影片的位置，會在投影片新增或刪除時變動。投影片 ID 為永久識別碼，其他投影片被刪除時不會變更。

**刪除投影片會如何影響投影片分節？**

如果該投影片屬於某個分節，該分節僅會少一張投影片。分節結構仍然保留；若分節變成空的，您可以[移除或重新組織分節](/slides/zh-hant/androidjava/slide-section/)。

**刪除投影片時，附加在該投影片上的備註與評論會發生什麼情況？**

[Notes](/slides/zh-hant/androidjava/presentation-notes/) 與 [comments](/slides/zh-hant/androidjava/presentation-comments/) 皆與該投影片綁定，會隨著投影片一起被移除。其他投影片的內容不受影響。

**刪除投影片與清理未使用的版面配置/母片有何不同？**

刪除會將特定的普通投影片從簡報中移除。清理未使用的版面配置或母片則會刪除未被任何投影片引用的版面配置或母片，減少檔案大小而不改變剩餘投影片的內容。這兩項操作是互補的：通常先刪除，再清理。