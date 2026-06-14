---
title: 在 PHP 中克隆簡報幻燈片
linktitle: 克隆幻燈片
type: docs
weight: 35
url: /zh-hant/php-java/clone-slides/
keywords:
- 克隆幻燈片
- 複製幻燈片
- 保存幻燈片
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP 快速複製 PowerPoint 幻燈片。遵循我們清晰的程式碼範例，即可在幾秒鐘內自動建立 PPT，省去手動操作。"
---
## **簡介**

克隆是製作某物精確副本或複製的過程。Aspose.Slides for PHP via Java 也使得可以複製或克隆任何幻燈片，然後將該克隆的幻燈片插入當前或任何其他已開啟的簡報。幻燈片克隆的過程會建立一個新幻燈片，開發人員可以修改此幻燈片而不會更改原始幻燈片。克隆幻燈片有多種可能方式：

- 在同一簡報的結尾處克隆。
- 在同一簡報的其他位置克隆。
- 在另一簡報的結尾處克隆。
- 在另一簡報的其他位置克隆。
- 在另一簡報的特定位置克隆。

在 Aspose.Slides for PHP via Java 中，由[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation)物件公開的（[Slide](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Slide)物件集合）提供了[addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection/#addClone)與[insertClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection/#insertClone)方法，以執行上述各種幻燈片克隆。

## **在簡報結尾處克隆幻燈片**
如果您想克隆一張幻燈片並在同一簡報檔案的現有幻燈片結尾處使用，請依照以下步驟使用[addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection/#addClone)方法：

1. 建立[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation)類別的實例。  
2. 透過參考由[Presentation]物件公開的幻燈片集合，取得[SlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation/#getSlides)物件。  
3. 呼叫由[SlideCollection]物件公開的[addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection/#addClone)方法，並將要克隆的幻燈片作為參數傳遞給[addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection/#addClone)方法。  
4. 寫入已修改的簡報檔案。

在下方的示例中，我們將一張位於簡報第一個位置（索引為 0）的幻燈片克隆到簡報的結尾。

```php
  # 實例化代表簡報檔案的 Presentation 類別
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # 將所需的幻燈片克隆到同一簡報中幻燈片集合的末尾
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # 將已修改的簡報寫入磁碟
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **在同一簡報的其他位置克隆幻燈片**
如果您想克隆一張幻燈片並在同一簡報檔案的不同位置使用，請使用[insertClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection/#insertClone)方法：

1. 建立[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation)類別的實例。  
2. 透過參考由[Presentation]物件公開的[**Slides**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation/#getSlides)集合，取得[SlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection)物件。  
3. 呼叫由[SlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation/#getSlides)物件公開的[insertClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection/#insertClone)方法，並將要克隆的幻燈片與新位置的索引一起作為參數傳遞給[insertClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection/#insertClone)方法。  
4. 將已修改的簡報寫入為 PPTX 檔案。

在下方的示例中，我們將一張位於簡報零索引（位置 1）的幻燈片克隆到索引 1（位置 2）。

```php
  # 實例化代表簡報檔案的 Presentation 類別
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # 將所需的幻燈片克隆到同一簡報中幻燈片集合的末尾
    $slds = $pres->getSlides();
    # 將所需的幻燈片克隆到同一簡報中指定的索引位置
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # 將已修改的簡報寫入磁碟
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **在另一簡報的結尾處克隆幻燈片**
如果您需要從一個簡報克隆幻燈片並在另一簡報檔案的現有幻燈片結尾處使用：

1. 建立包含要克隆之幻燈片來源簡報的[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation)類別實例。  
2. 建立包含目的簡報（要加入幻燈片）的[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation)類別實例。  
3. 透過參考目的簡報的[Presentation]物件所公開的[**Slides**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation/#getSlides)集合，取得[SlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection)物件。  
4. 呼叫[addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection/#addClone)方法，並將來源簡報的幻燈片作為參數傳遞給[addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection/#addClone)方法。  
5. 寫入已修改的目的簡報檔案。

在下方的示例中，我們將來源簡報第一個索引的幻燈片克隆到目的簡報的結尾。

```php
  # 實例化 Presentation 類別以載入來源簡報檔案
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # 實例化 Presentation 類別用於目的 PPTX（要克隆幻燈片的地方）
    $destPres = new Presentation();
    try {
      # 將所需的幻燈片從來源簡報克隆到目的簡報中幻燈片集合的末尾
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # 將目的簡報寫入磁碟
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **在另一簡報的其他位置克隆幻燈片**
如果您需要從一個簡報克隆幻燈片並在另一簡報檔案的特定位置使用：

1. 建立包含要克隆之幻燈片來源簡報的[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation)類別實例。  
2. 建立包含要加入幻燈片之目的簡報的[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation)類別實例。  
3. 透過參考目的簡報的[Presentation]物件所公開的Slides集合，取得[SlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation/#getSlides)類別。  
4. 呼叫[insertClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection/#insertClone)方法，並將來源簡報的幻燈片與目標位置一併作為參數傳遞給[insertClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection/#insertClone)方法。  
5. 寫入已修改的目的簡報檔案。

在下方的示例中，我們將來源簡報零索引的幻燈片克隆到目的簡報的索引 1（位置 2）。

```php
  # 實例化 Presentation 類別以載入來源簡報檔案
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # 實例化 Presentation 類別用於目的 PPTX（要克隆幻燈片的地方）
    $destPres = new Presentation();
    try {
      # 將所需的幻燈片從來源簡報克隆到目的簡報中幻燈片集合的末尾
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # 將目的簡報寫入磁碟
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **在另一簡報的特定位置克隆幻燈片**
如果您需要從一個簡報克隆含有母片的幻燈片並在另一簡報中使用，必須先將來源簡報中所需的母片克隆到目的簡報。接著使用該母片來克隆含有母片的幻燈片。[**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slidecollection/addclone/) 需要目的簡報的母片，而非來源簡報的母片。為了克隆含母片的幻燈片，請遵循以下步驟：

1. 建立包含要克隆之幻燈片來源簡報的[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation)類別實例。  
2. 建立包含目的簡報的[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation)類別實例。  
3. 取得要克隆的幻燈片及其母片。  
4. 透過參考目的簡報的[Presentation]物件所公開的Masters集合，實例化[MasterSlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/MasterSlideCollection)類別。  
5. 呼叫由[MasterSlideCollection]物件公開的[addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection/#addClone)方法，並將來源 PPTX 的母片作為參數傳遞給[addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection/#addClone)方法。  
6. 透過參考目的簡報的[Presentation]物件所公開的Slides集合，實例化[SlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation/#getSlides)類別。  
7. 呼叫由[SlideCollection]物件公開的[addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection/#addClone)方法，並將來源簡報的幻燈片與母片作為參數傳遞給[addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection/#addClone)方法。  
8. 寫入已修改的目的簡報檔案。

在下方的示例中，我們將一張含母片（位於來源簡報零索引）的幻燈片，使用來源幻燈片的母片克隆到目的簡報的結尾。

```php
  # 實例化 Presentation 類別以載入來源簡報檔案
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # 實例化 Presentation 類別用於目的簡報（要克隆幻燈片的地方）
    $destPres = new Presentation();
    try {
      # 從來源簡報的幻燈片集合中實例化 ISlide 並搭配
      # 母片
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # 將所需的母片從來源簡報克隆至目的簡報的母片集合中
      # 目的簡報
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # 將所需的母片從來源簡報克隆至目的簡報的母片集合中
      # 目的簡報
      $iSlide = $masters->addClone($SourceMaster);
      # 將來源簡報中帶有目標母片的所需幻燈片克隆至目的簡報的幻燈片集合末尾
      # 目的簡報的幻燈片集合
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # 將目的簡報寫入磁碟
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **在指定章節的結尾處克隆幻燈片**
如果您想克隆幻燈片並在同一簡報檔案的不同章節使用，請使用由[SlideCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection)類別公開的[addClone](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/SlideCollection/#addClone)方法。Aspose.Slides for PHP via Java 使得可以從第一章節克隆幻燈片，然後將該克隆的幻燈片插入同一簡報的第二章節。

以下程式碼片段示範如何克隆幻燈片並將克隆的幻燈片插入指定章節。

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # 將目的簡報寫入磁碟
    $presentation->save($dataDir . "CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **常見問題**

**演講者備註與審閱者註解會被克隆嗎？**

是的。備註頁面與審閱註解會包含在克隆中。如果不需要它們，請在插入後[將其移除](/slides/zh-hant/php-java/presentation-notes/)。

**圖表及其資料來源如何處理？**

圖表物件、格式設定與嵌入的資料會被複製。如果圖表連結至外部來源（例如 OLE 嵌入的活頁簿），該連結會以[OLE 物件](/slides/zh-hant/php-java/manage-ole/)的形式保留。檔案搬移後，請確認資料是否可用並檢查重新整理行為。

**我可以控制克隆的插入位置與章節嗎？**

可以。您可以在特定的幻燈片索引插入克隆，並將其放入選擇的[章節](/slides/zh-hant/php-java/slide-section/)。如果目標章節不存在，請先建立該章節，然後再將幻燈片移入。