---
title: 在 PHP 中克隆簡報投影片
linktitle: 克隆投影片
type: docs
weight: 35
url: /zh-hant/php-java/clone-slides/
keywords:
- 克隆投影片
- 複製投影片
- 儲存投影片
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP 迅速複製 PowerPoint 投影片。遵循我們清晰的程式碼範例，在數秒內自動建立 PPT，消除手動操作。"
---
## **簡介**

克隆是製作某物的精確副本或複製品的過程。Aspose.Slides for PHP via Java 也使得可以對任何投影片製作副本或克隆，然後將該克隆的投影片插入目前或任何其他已開啟的簡報。投影片克隆的過程會建立一個新投影片，開發人員可以對其進行修改，而不會更改原始投影片。克隆投影片有多種可能的方式：

- 在簡報內的結尾處克隆。
- 在簡報內的其他位置克隆。
- 在另一個簡報的結尾處克隆。
- 在另一個簡報的其他位置克隆。
- 在另一個簡報的特定位置克隆。

在 Aspose.Slides for PHP via Java 中，由 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 物件公開的 (一個包含 [Slide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Slide) 物件的集合) 提供 [addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection/#addClone) 與 [insertClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection/#insertClone) 方法，以執行上述投影片克隆類型。

## **在簡報的結尾處克隆投影片**
如果您想要克隆投影片，並在同一簡報檔案的現有投影片末尾使用它，請按照下列步驟使用 [addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection/#addClone) 方法：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。
1. 透過參考由 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 物件公開的投影片集合，取得 [SlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation/#getSlides) 物件。
1. 呼叫由 [SlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation/#getSlides) 物件公開的 [addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection/#addClone) 方法，並將要克隆的投影片作為參數傳遞給 [addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection/#addClone) 方法。
1. 寫入修改後的簡報檔案。

在下方的範例中，我們將投影片（位於簡報的第一個位置——索引為 0）克隆到簡報的末尾。

```php
  # 建立代表簡報檔案的 Presentation 類別實例
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # 將目標投影片克隆至同一簡報的投影片集合末端
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # 將修改後的簡報寫入磁碟
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **在簡報內的其他位置克隆投影片**
如果您想要克隆投影片，並在同一簡報檔案的不同位置使用它，請使用 [insertClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection/#insertClone) 方法：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。
1. 透過參考由 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 物件公開的 **Slides** 集合，取得 [SlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection) 物件。
1. 呼叫由 [SlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation/#getSlides) 物件公開的 [insertClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection/#insertClone) 方法，並將要克隆的投影片以及新位置的索引作為參數傳遞給 [insertClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection/#insertClone) 方法。
1. 將修改後的簡報寫入為 PPTX 檔案。

在下方的範例中，我們將投影片（位於簡報的零索引——位置 1——）克隆到索引 1——位置 2——的投影片。

```php
  # 建立代表簡報檔案的 Presentation 類別實例
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # 將目標投影片克隆至同一簡報的投影片集合末端
    $slds = $pres->getSlides();
    # 將目標投影片克隆至同一簡報的指定索引位置
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # 將修改後的簡報寫入磁碟
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **在另一個簡報的結尾處克隆投影片**
如果您需要從一個簡報克隆投影片並在另一個簡報檔案的結尾處使用它：

1. 建立包含來源簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。
1. 建立包含目標簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。
1. 透過參考目標簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 物件公開的 **Slides** 集合，取得 [SlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection) 物件。
1. 呼叫由 [SlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation/#getSlides) 物件公開的 [addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection/#addClone) 方法，並將來源簡報的投影片作為參數傳遞給 [addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection/#addClone) 方法。
1. 寫入修改後的目標簡報檔案。

在下方的範例中，我們將來源簡報的第一個索引的投影片克隆到目標簡報的結尾。

```php
  # 建立 Presentation 類別以載入來源簡報檔案
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # 建立目的地 PPTX 的 Presentation 類別（要克隆投影片的地方）
    $destPres = new Presentation();
    try {
      # 將來源簡報的目標投影片克隆至目的地簡報的投影片集合末端
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # 將目的地簡報寫入磁碟
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **在另一個簡報的其他位置克隆投影片**
如果您需要從一個簡報克隆投影片並在另一個簡報檔案的特定位置使用它：

1. 建立包含來源簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。
1. 建立包含目標簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。
1. 透過參考目標簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 物件公開的 Slides 集合，取得 [SlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation/#getSlides) 類別。
1. 呼叫由 [SlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation/#getSlides) 物件公開的 [insertClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection/#insertClone) 方法，並將來源簡報的投影片以及期望的位置作為參數傳遞給 [insertClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection/#insertClone) 方法。
1. 寫入修改後的目標簡報檔案。

在下方的範例中，我們將來源簡報的零索引的投影片克隆到目標簡報的索引 1（位置 2）。

```php
  # 建立 Presentation 類別以載入來源簡報檔案
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # 建立目的地 PPTX 的 Presentation 類別（投影片將被克隆的地方）
    $destPres = new Presentation();
    try {
      # 將來源簡報的目標投影片克隆至目的地簡報的投影片集合末端
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # 將目的地簡報寫入磁碟
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **在另一個簡報的特定位置克隆投影片**
如果您需要從一個簡報克隆帶有母片的投影片並在另一個簡報中使用，必須先將來源簡報的目標母片克隆到目標簡報，然後再使用該母片進行投影片克隆。[**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/addclone/) 需要目標簡報的母片，而不是來源簡報的母片。請依照以下步驟克隆帶母片的投影片：

1. 建立包含來源簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。
1. 建立包含目標簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。
1. 取得要克隆的投影片及其母片。
1. 透過參考目標簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 物件公開的 Masters 集合，實例化 [MasterSlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/MasterSlideCollection) 類別。
1. 呼叫由 [MasterSlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/MasterSlideCollection) 物件公開的 [addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection/#addClone) 方法，將來源 PPTX 的母片作為參數傳遞給 [addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection/#addClone) 方法。
1. 透過參考目標簡報的 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 物件公開的 Slides 集合，實例化 [SlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation/#getSlides) 類別。
1. 呼叫由 [SlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation/#getSlides) 物件公開的 [addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection/#addClone) 方法，將來源簡報的投影片及其母片作為參數傳遞給 [addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection/#addClone) 方法。
1. 寫入修改後的目標簡報檔案。

在下方的範例中，我們將來源簡報零索引的投影片（帶有母片）克隆到目標簡報的結尾，使用來源投影片的母片。

```php
  # 建立 Presentation 類別以載入來源簡報檔案
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # 建立目的地簡報的 Presentation 類別（投影片將被克隆的地方）
    $destPres = new Presentation();
    try {
      # 從來源簡報的投影片集合中建立 ISlide，並同時取得
      # 母片
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # 將來源簡報的目標母片克隆至目的地簡報的母片集合中
      # 目的地簡報
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # 將來源簡報的目標母片克隆至目的地簡報的母片集合中
      # 目的地簡報
      $iSlide = $masters->addClone($SourceMaster);
      # 將來源簡報的目標投影片搭配目標母片克隆至
      # 目的地簡報的投影片集合末端
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # 將目的地簡報寫入磁碟
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **在指定區段的結尾處克隆投影片**
如果您想要克隆投影片，並在同一簡報檔案的不同區段使用它，請使用由 [SlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection) 類別公開的 [addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection/#addClone) 方法。Aspose.Slides for PHP via Java 使得可以從第一個區段克隆投影片，然後將該克隆投影片插入同一簡報的第二個區段。

以下程式碼片段示範如何克隆投影片並將克隆的投影片插入指定的區段。

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # 將目的地簡報寫入磁碟
    $presentation->save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **確保投影片尺寸相符**

在將投影片克隆到其他簡報時，請確保目標簡報的投影片尺寸與來源簡報相同。若尺寸不同，Aspose.Slides 不會自動重新縮放克隆的形狀——其原始座標與尺寸會被保留，可能導致內容顯示錯位或超出投影片邊界。

您可以在克隆母片與投影片之前，將目標簡報的投影片尺寸設定為與來源相同：

```php
$sourceSize = $sourcePresentation->getSlideSize()->getSize();

$targetPresentation->getSlideSize()->setSize(
    $sourceSize->getWidth(), $sourceSize->getHeight(), SlideSizeScaleType::DoNotScale);
```

在克隆母片與投影片之前執行此操作。

## **常見問題**

**演講者備註和評論者意見會被克隆嗎？**

是。備註頁面和審閱評論會包含在克隆中。如果您不想保留它們，請在插入後 [remove them](/slides/zh-hant/php-java/presentation-notes/) 。

**圖表及其資料來源如何處理？**

圖表物件、格式設定與嵌入的資料會被複製。若圖表連結至外部來源（例如 OLE 嵌入的活頁簿），該連結會以 [OLE object](/slides/zh-hant/php-java/manage-ole/) 形式保留。搬移檔案後，請確認資料可用性並檢查重新整理行為。

**我可以控制克隆的插入位置和區段嗎？**

是。您可以在特定投影片索引插入克隆，並將其放入選擇的 [section](/slides/zh-hant/php-java/slide-section/)。如果目標區段不存在，請先建立，然後再將投影片移入該區段。