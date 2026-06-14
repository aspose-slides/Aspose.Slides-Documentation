---
title: 在 PHP 中從簡報中移除投影片
linktitle: 移除投影片
type: docs
weight: 30
url: /zh-hant/php-java/remove-slide-from-presentation/
keywords:
- 移除投影片
- 刪除投影片
- 移除未使用的投影片
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java，輕鬆從 PowerPoint 與 OpenDocument 簡報中移除投影片。提供清晰的程式碼範例，提升您的工作流程。"
---
## **簡介**

如果投影片（或其內容）變得多餘，您可以將其刪除。Aspose.Slides 提供了 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別，該類別封裝了 [SlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/)，用於儲存簡報中所有投影片。透過已知的 [Slide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/) 物件的指標（參考或索引），即可指定要移除的投影片。

## **依參考移除投影片**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。  
1. 透過投影片的 ID 或 Index 取得欲移除投影片的參考。  
1. 從簡報中移除已參考的投影片。  
1. 儲存已修改的簡報。  

以下 PHP 程式碼示範如何透過參考移除投影片：

```php
  # 實例化一個代表簡報檔案的 Presentation 物件
  $pres = new Presentation("demo.pptx");
  try {
    # 透過投影片集合中的索引存取投影片
    $slide = $pres->getSlides()->get_Item(0);
    # 透過參考移除投影片
    $pres->getSlides()->remove($slide);
    # 儲存已修改的簡報
    $pres->save("modified.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **依索引移除投影片**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。  
1. 透過索引位置從簡報中移除投影片。  
1. 儲存已修改的簡報。  

以下 PHP 程式碼示範如何透過索引移除投影片：

```php
  # 實例化一個代表簡報檔案的 Presentation 物件
  $pres = new Presentation("demo.pptx");
  try {
    # 透過投影片索引移除投影片
    $pres->getSlides()->removeAt(0);
    # 儲存已修改的簡報
    $pres->save("modified.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **移除未使用的版面配置投影片**

Aspose.Slides 提供了來自 [Compress](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compress/) 類別的 [removeUnusedLayoutSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) 方法，讓您可刪除不需要且未被使用的版面配置投影片。以下 PHP 程式碼示範如何從 PowerPoint 簡報中移除版面配置投影片：

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->removeUnusedLayoutSlides($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **移除未使用的母片投影片**

Aspose.Slides 提供了來自 [Compress](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compress/) 類別的 [removeUnusedMasterSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) 方法，讓您可刪除不需要且未被使用的母片投影片。以下 PHP 程式碼示範如何從 PowerPoint 簡報中移除母片投影片：

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->removeUnusedMasterSlides($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**刪除投影片後，投影片索引會發生什麼變化？**

刪除後，[collection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/) 會重新編號：每個後續的投影片向左移動一個位置，因此先前的索引號碼將不再正確。若需要穩定的參考，請使用每張投影片的永久 ID，而非索引。

**投影片的 ID 與索引不同嗎？在刪除相鄰投影片時會改變嗎？**

是的。索引代表投影片在簡報中的位置，隨著投影片的新增或刪除會變動。投影片 ID 是永久識別碼，其他投影片被刪除時不會改變。

**刪除投影片會如何影響投影片區段？**

如果該投影片屬於某個區段，該區段的投影片數量會減少一張。區段結構仍然保留；若區段變成空的，您可以依需求 [移除或重新組織區段](/slides/zh-hant/php-java/slide-section/)。

**刪除投影片時，附屬於投影片的備註與評論會發生什麼事？**

[Notes](/slides/zh-hant/php-java/presentation-notes/) 與 [comments](/slides/zh-hant/php-java/presentation-comments/) 皆與特定投影片綁定，會隨投影片一起被刪除。其他投影片的內容不受影響。

**刪除投影片與清理未使用的版面/母片有何不同？**

刪除是將特定的普通投影片從簡報中移除。清理未使用的版面或母片則是移除未被任何投影片引用的版面或母片，從而減少檔案大小且不會改變剩餘投影片的內容。這兩種操作是互補的：通常先執行刪除，之後再進行清理。