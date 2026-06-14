---
title: 在 PHP 中向簡報新增投影片
linktitle: 新增投影片
type: docs
weight: 10
url: /zh-hant/php-java/add-slide-to-presentation/
keywords:
- 新增投影片
- 建立投影片
- 空白投影片
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java，輕鬆將投影片新增至您的 PowerPoint 與 OpenDocument 簡報 —— 在數秒內完成無縫且高效的投影片插入。"
---
## **概觀**

Aspose.Slides 允許您以程式方式向 PowerPoint 簡報新增投影片。簡報包含母片/版面投影片與一般投影片，且一般投影片以零基索引排列。每張投影片都有唯一的 ID，且不支援沒有投影片的簡報檔案。

本文說明如何建立 `Presentation` 物件、取得其投影片集合、加入空白投影片、對新加入的投影片進行操作，並儲存更新後的簡報。內容亦涵蓋在特定位置插入投影片、使用版面配置以及了解新建立的簡報中預設的空白投影片等相關議題。

## **將投影片新增至簡報**

在討論如何將投影片新增至簡報檔案之前，先說明投影片的一些基本概念。每個 PowerPoint 簡報檔案包含 **母片 / 版面** 投影片以及其他 **一般** 投影片。這表示簡報檔案至少包含一張或多張投影片。必須了解 Aspose.Slides for PHP via Java 不支援沒有投影片的簡報檔案。每張投影片都有唯一的 Id，且所有一般投影片依照零基索引的順序排列。

Aspose.Slides for PHP via Java 允許開發人員在簡報中加入空白投影片。若要在簡報中加入空白投影片，請依照下列步驟執行：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 類別的執行個體。
- 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 物件所公開的 [getSlides](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation#getSlides--) 方法，取得 [SlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/) 物件（內容投影片物件的集合）。
- 透過呼叫由 [SlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/) 物件公開的 [**addEmptySlide**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/#addEmptySlide) 方法，將空白投影片加入內容投影片集合的末端。
- 對新加入的空白投影片執行一些操作。
- 最後，使用 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation) 物件寫入簡報檔案。

```php
  # 實例化代表簡報檔案的 Presentation 類別
  $pres = new Presentation();
  try {
    # 實例化 SlideCollection 類別
    $slds = $pres->getSlides();
    for($i = 0; $i < java_values($pres->getLayoutSlides()->size()) ; $i++) {
      # 將空白投影片新增至 Slides 集合
      $slds->addEmptySlide($pres->getLayoutSlides()->get_Item($i));
    }
    # 對新加入的投影片執行一些操作
    # 將 PPTX 檔案儲存至磁碟
    $pres->save("EmptySlide.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **常見問題**

**我可以在特定位置插入新投影片，而不是僅在結尾插入嗎？**

可以。函式庫支援投影片集合的 [insert](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/insertclone/) 操作，您可以在所需的索引加入投影片，而不必只在末端加入。

**基於版面新增投影片時，主題/樣式會被保留嗎？**

會。版面會繼承其母片的格式設定，而新投影片則會繼承所選版面及其相關母片的格式。

**在新增投影片之前，新建立的「空白」簡報中預設有哪些投影片？**

新建立的簡報已預先包含一張索引為零的空白投影片。計算插入索引時必須考慮到這一點。

**如果母片有許多版面選項，我該如何為新投影片選擇「正確」的版面？**

一般而言，請選擇與需求結構相符的 [LayoutSlide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/layoutslide/)（例如 [Title and Content、Two Content 等](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidelayouttype/)）。如果缺少此類版面，您可以 [將其新增至母片](/slides/zh-hant/php-java/slide-layout/) 後再使用。