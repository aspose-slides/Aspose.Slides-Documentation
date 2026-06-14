---
title: 在 PHP 中高效合併簡報
linktitle: 合併簡報
type: docs
weight: 40
url: /zh-hant/php-java/merge-presentation/
keywords:
- 合併 PowerPoint
- 合併簡報
- 合併投影片
- 合併 PPT
- 合併 PPTX
- 合併 ODP
- 結合 PowerPoint
- 結合簡報
- 結合投影片
- 結合 PPT
- 結合 PPTX
- 結合 ODP
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java，輕鬆合併 PowerPoint (PPT、PPTX) 與 OpenDocument (ODP) 簡報，簡化工作流程。"
---
## **概覽**

Aspose.Slides 允許您透過將一個簡報的投影片克製到另一個簡報中來合併簡報。本文章說明如何合併整份簡報或選取的投影片、在合併過程中使用投影片母片或特定版面配置、處理擁有不同投影片大小的簡報，以及將合併的投影片加入簡報的節 (section)。同時也涵蓋與合併內容相關的實務注意事項，包括講者備註、評論、受密碼保護的來源檔案，以及執行緒使用情形。

{{% alert title="Info" color="info" %}}
大多數簡報程式（PowerPoint 或 OpenOffice）都缺乏允許使用者以此方式合併簡報的功能。

[**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/zh-hant/php-java/)，卻允許您以不同方式合併簡報。您可以完整合併簡報的所有形狀、樣式、文字、格式、評論、動畫等，而無需擔心品質或資料遺失。

**另請參閱**

[複製投影片](/slides/zh-hant/php-java/clone-slides/).
{{% /alert %}}

### **可以合併的項目**

使用 Aspose.Slides，您可以合併

* 整份簡報。所有簡報的投影片會匯入到同一個簡報中
* 特定投影片。選取的投影片會匯入到同一個簡報中
* 相同格式的簡報（例如 PPT 轉 PPT、PPTX 轉 PPTX 等）以及不同格式的簡報（例如 PPT 轉 PPTX、PPTX 轉 ODP 等）之間的相互合併。

{{% alert title="Note" color="warning" %}} 
除了簡報之外，Aspose.Slides 允許您合併其他檔案：

* [Images](https://products.aspose.com/slides/zh-hant/php-java/merger/image-to-image/)，例如 [JPG to JPG](https://products.aspose.com/slides/zh-hant/php-java/merger/jpg-to-jpg/) 或 [PNG to PNG](https://products.aspose.com/slides/zh-hant/php-java/merger/png-to-png/)
* [Documents](https://products.aspose.com/slides/zh-hant/php-java/merger/pdf-to-pdf/)，例如 [PDF to PDF](https://products.aspose.com/slides/zh-hant/php-java/merger/pdf-to-pdf/) 或 [HTML to HTML](https://products.aspose.com/slides/zh-hant/php-java/merger/html-to-html/)
* 以及兩種不同類型的檔案，例如 [image to PDF](https://products.aspose.com/slides/zh-hant/php-java/merger/image-to-pdf/) 或 [JPG to PDF](https://products.aspose.com/slides/zh-hant/php-java/merger/jpg-to-pdf/) 或 [TIFF to PDF](https://products.aspose.com/slides/zh-hant/php-java/merger/tiff-to-pdf/)。
{{% /alert %}}

### **合併選項**

您可以套用選項以決定是否

* 輸出簡報中的每張投影片保留其獨特樣式
* 為所有輸出簡報的投影片使用相同的特定樣式。

要合併簡報，Aspose.Slides 提供了 [addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/addclone/) 方法（來自 [SlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/) 類別）。`addClone` 方法有多種實作，可定義簡報合併過程的參數。每個 Presentation 物件都有一個 [slide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/getslides/) 集合，您可以從欲合併投影片的簡報呼叫 `addClone` 方法。

`addClone` 方法會回傳一個 `Slide` 物件，即來源投影片的克隆。輸出簡報中的投影片僅是來源投影片的副本。因此，您可以對產生的投影片進行變更（例如套用樣式、格式選項或版面配置），而不必擔心會影響來源簡報。

## **合併簡報** 

Aspose.Slides 提供了 [addClone(Slide)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/addclone/) 方法，讓您在保持投影片版面與樣式的情況下（預設參數）合併投影片。

此 PHP 程式碼示範如何合併簡報：

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **使用投影片母片合併簡報**

Aspose.Slides 提供了 [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/addclone/) 方法，讓您在套用投影片母片簡報範本的同時合併投影片。如此一來，若有需要，您即可變更輸出簡報中投影片的樣式。

此程式碼示範上述操作：

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getMasters()->get_Item(0), true);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 
投影片母片的版面會自動決定。當無法判斷適當的版面時，若 `addClone` 方法的 `allowCloneMissingLayout` 布林參數設為 true，則會使用來源投影片的版面。否則，將拋出 [PptxEditException](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/PptxEditException)。
{{% /alert %}}

如果您希望輸出簡報中的投影片使用不同的投影片版面，合併時請改為使用 [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/addclone/) 方法。

## **從簡報中合併特定投影片**

從多個簡報中合併特定投影片對於建立自訂投影片組合非常有用。Aspose.Slides for PHP via Java 讓您僅選取並匯入所需的投影片。API 會保留原始投影片的格式、版面與設計。

以下 PHP 程式碼會建立新簡報、從另外兩個簡報加入標題投影片，並將結果儲存為檔案：

```php
function getTitleSlide(Presentation $presentation) {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        if (java_values($slide->getLayoutSlide()->getLayoutType()) === SlideLayoutType::Title) {
            return $slide;
        }
    }
    return null;
}
```
```php
$presentation = new Presentation();
$presentation1 = new Presentation($folderPath . "presentation1.pptx");
$presentation2 = new Presentation($folderPath . "presentation2.pptx");
try {
    $presentation->getSlides()->removeAt(0);
    
    $slide1 = getTitleSlide($presentation1);

    if ($slide1 != null)
        $presentation->getSlides()->addClone($slide1);

    $slide2 = getTitleSlide($presentation2);

    if ($slide2 != null)
        $presentation->getSlides()->addClone($slide2);

    $presentation->save($folderPath . "combined.pptx", SaveFormat::Pptx);
} finally {
    $presentation2->dispose();
    $presentation1->dispose();
    $presentation->dispose();
}
```

## **使用投影片版面合併簡報**

此 PHP 程式碼示範如何在合併簡報的投影片時套用您偏好的投影片版面，以取得單一輸出簡報：

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres2->getLayoutSlides()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **合併不同投影片尺寸的簡報**

{{% alert title="Note" color="warning" %}} 
無法合併投影片尺寸不同的簡報。 
{{% /alert %}}

若要合併兩個投影片尺寸不同的簡報，必須將其中一個簡報的尺寸調整至與另一個簡報相同。

以下範例程式碼示範上述操作：

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      $pres2->getSlideSize()->setSize($pres1->getSlideSize()->getSize()->getWidth(), $pres1->getSlideSize()->getSize()->getHeight(), SlideSizeScaleType::EnsureFit);
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide);
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

## **將投影片合併至簡報節**

此 PHP 程式碼示範如何將特定投影片合併至簡報的節中：

```php
  $pres1 = new Presentation("pres1.pptx");
  try {
    $pres2 = new Presentation("pres2.pptx");
    try {
      foreach($pres2->getSlides() as $slide) {
        $pres1->getSlides()->addClone($slide, $pres1->getSections()->get_Item(0));
      }
    } finally {
      if (!java_is_null($pres2)) {
        $pres2->dispose();
      }
    }
    $pres1->save("combined.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres1)) {
      $pres1->dispose();
    }
  }
```

該投影片會被加入至該節的末端。

## **另請參閱**

Aspose 提供一個 [FREE Online Collage Maker](https://products.aspose.app/slides/zh-hant/collage)。使用此線上服務，您可以合併 [JPG to JPG](https://products.aspose.app/slides/zh-hant/collage/jpg) 或 PNG 到 PNG 圖片、建立 [photo grids](https://products.aspose.app/slides/zh-hant/collage/photo-grid)，以及其他功能。

請查看 [Aspose FREE Online Merger](https://products.aspose.app/slides/zh-hant/merger)。它可讓您合併相同格式的 PowerPoint 簡報（例如 PPT 轉 PPT、PPTX 轉 PPTX）或不同格式的簡報（例如 PPT 轉 PPTX、PPTX 轉 ODP）。

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/zh-hant/merger)

## **常見問題**

**合併簡報時，投影片數量有任何限制嗎？**

沒有嚴格的限制。Aspose.Slides 能處理大型檔案，但效能取決於檔案大小與系統資源。對於極大的簡報，建議使用 64 位元 JVM 並配置足夠的堆記憶體。

**我可以合併含嵌入式影片或音訊的簡報嗎？**

可以，Aspose.Slides 會保留投影片中嵌入的多媒體內容，但最終的簡報檔案大小可能會大幅增加。

**合併簡報時，字型會被保留嗎？**

會。來源簡報使用的字型會在輸出檔案中保留，前提是該字型已安裝在系統上或已[嵌入](/slides/zh-hant/php-java/embedded-font/)。