---
title: 在 PHP 中存取簡報投影片
linktitle: 存取投影片
type: docs
weight: 20
url: /zh-hant/php-java/access-slide-in-presentation/
keywords:
- 存取投影片
- 投影片索引
- 投影片 ID
- 投影片位置
- 變更位置
- 投影片屬性
- 投影片編號
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 來存取與管理 PowerPoint 與 OpenDocument 簡報中的投影片。透過程式碼範例提升生產力。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 取得與管理簡報中的投影片。它展示了如何從投影片集合中以零基索引取得投影片，以及如何使用 `getSlideById` 方法依唯一 ID 取得投影片。

您還將學習如何使用 `setSlideNumber` 方法變更投影片的位置，及如何使用 `setFirstSlideNumber` 方法為簡報定義起始投影片編號。範例說明了載入簡報、取得投影片參考、更新投影片順序或編號，並儲存已修改的簡報。

## **依索引存取投影片**

簡報中的所有投影片皆依投影片位置以數字排序，起始值為 0。第一張投影片可透過索引 0 存取；第二張投影片可透過索引 1 存取；以此類推。

`Presentation` 類別（代表簡報檔案）會將所有投影片以 [SlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/)（[Slide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/) 物件的集合）形式公開。以下 PHP 程式碼說明如何透過索引存取投影片：

```php
  # 建立一個代表簡報檔案的 Presentation 物件
  $pres = new Presentation("demo.pptx");
  try {
    # 使用投影片索引存取投影片
    $slide = $pres->getSlides()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```

## **依 ID 存取投影片**

簡報中的每張投影片都有唯一的 ID。您可以使用 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別所提供的 [getSlideById](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getSlideById-long-) 方法以該 ID 為目標。以下 PHP 程式碼說明如何提供有效的投影片 ID，並透過 [getSlideById](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getSlideById-long-) 方法存取該投影片：

```php
  # 建立一個代表簡報檔案的 Presentation 物件
  $pres = new Presentation("demo.pptx");
  try {
    # 取得投影片 ID
    $id = $pres->getSlides()->get_Item(0)->getSlideId();
    # 透過 ID 存取投影片
    $slide = $pres->getSlideById($id);
  } finally {
    $pres->dispose();
  }
```

## **變更投影片位置**

Aspose.Slides 允許您變更投影片的位置。例如，您可以指定第一張投影片變成第二張投影片。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。  
2. 透過索引取得要變更位置的投影片參考  
3. 使用 [setSlideNumber](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slide/#setSlideNumber) 方法設定投影片的新位置。  
4. 儲存已修改的簡報。

以下 PHP 程式碼示範將位置 1 的投影片移動至位置 2 的操作：

```php
  # 建立一個代表簡報檔案的 Presentation 物件
  $pres = new Presentation("Presentation.pptx");
  try {
    # 取得位置將被變更的投影片
    $sld = $pres->getSlides()->get_Item(0);
    # 設定投影片的新位置
    $sld->setSlideNumber(2);
    # 儲存已修改的簡報
    $pres->save("helloworld_Pos.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

第一張投影片變成第二張，第二張投影片變成第一張。變更投影片位置時，其他投影片會自動調整。

## **設定投影片編號**

使用由 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別所提供的 [setFirstSlideNumber](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#setFirstSlideNumber-int-) 方法，您可以為簡報的第一張投影片指定新的編號。此操作會重新計算其他投影片的編號。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。  
2. 取得投影片編號。  
3. 設定投影片編號。  
4. 儲存已修改的簡報。

以下 PHP 程式碼示範將第一張投影片的編號設定為 10 的操作：

```php
  # 建立一個代表簡報檔案的 Presentation 物件
  $pres = new Presentation("HelloWorld.pptx");
  try {
    # 取得投影片編號
    $firstSlideNumber = $pres->getFirstSlideNumber();
    # 設定投影片編號
    $pres->setFirstSlideNumber(10);
    # 儲存已修改的簡報
    $pres->save("Set_Slide_Number_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

如果您希望跳過第一張投影片，也可以讓編號從第二張投影片開始（並對第一張投影片隱藏編號），方式如下：

```php
  $presentation = new Presentation();
  try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    # 設定簡報第一張投影片的編號
    $presentation->setFirstSlideNumber(0);
    # 顯示所有投影片的投影片編號
    $presentation->getHeaderFooterManager()->setAllSlideNumbersVisibility(true);
    # 隱藏第一張投影片的投影片編號
    $presentation->getSlides()->get_Item(0)->getHeaderFooterManager()->setSlideNumberVisibility(false);
    # 儲存已修改的簡報
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **常見問題**

**使用者看到的投影片編號是否與集合的零基索引相同？**

投影片上顯示的編號可以從任意值（例如 10）開始，不必與索引相同；兩者的關係受簡報的 [first slide number](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/setfirstslidenumber/) 設定所控制。

**隱藏的投影片會影響索引嗎？**

會。隱藏的投影片仍保留在集合中，且會在索引計算中被納入；「隱藏」僅指顯示狀態，並不改變其在集合中的位置。

**當新增或移除其他投影片時，投影片的索引會改變嗎？**

會。索引始終反映投影片的當前順序，並在插入、刪除或移動操作後重新計算。