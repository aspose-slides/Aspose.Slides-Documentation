---
title: 在 PHP 中管理簡報超連結
linktitle: 管理超連結
type: docs
weight: 20
url: /zh-hant/php-java/manage-hyperlinks/
keywords:
- 新增 URL
- 新增超連結
- 建立超連結
- 格式化超連結
- 移除超連結
- 更新超連結
- 文字超連結
- 投影片超連結
- 圖形超連結
- 圖片超連結
- 影片超連結
- 可變超連結
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java，輕鬆管理 PowerPoint 與 OpenDocument 簡報中的超連結 — 在數分鐘內提升互動性與工作流程。"
---
## **簡介**

超連結是對某個物件、資料或位置的參照。以下是在 PowerPoint 簡報中常見的超連結：

* 文字、圖形或媒體內的網站連結
* 投影片連結

Aspose.Slides for PHP via Java 讓您能在簡報中執行許多與超連結相關的工作。

{{% alert color="primary" %}} 
您可能想了解 Aspose 簡易的 [免費線上 PowerPoint 編輯器](https://products.aspose.app/slides/zh-hant/editor)。
{{% /alert %}} 

## **新增 URL 超連結**

### **將 URL 超連結新增至文字**

此 PHP 程式碼示範如何將網站超連結新增至文字：

```php
  $presentation = new Presentation();
  try {
    $shape1 = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $shape1->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $portionFormat::setFontHeight(32);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

### **將 URL 超連結新增至圖形或框架**

此範例程式碼示範如何將網站超連結新增至圖形：

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);
    $shape->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $shape->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **將 URL 超連結新增至媒體**

Aspose.Slides 允許您將超連結新增至圖像、音訊與影片檔案。

此範例程式碼示範如何將超連結新增至 **圖片**：

```php
  $pres = new Presentation();
  try {
    # 新增圖片到簡報
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($picture);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # 在投影片 1 上建立圖片框，基於先前新增的圖片
    $pictureFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pictureFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $pictureFrame->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

此範例程式碼示範如何將超連結新增至 **音訊檔案**：

```php
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "audio.mp3"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $audio = $pres->getAudios()->addAudio($bytes);

    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->addAudioFrameEmbedded(10, 10, 100, 100, $audio);
    $audioFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $audioFrame->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

此範例程式碼示範如何將超連結新增至 **影片**：

```php
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "video.avi"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $video = $pres->getVideos()->addVideo($bytes);

    $videoFrame = $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 100, 100, $video);
    $videoFrame->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $videoFrame->getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert  title="Tip"  color="primary"  %}} 
您可能想查看 *[管理 OLE](/slides/zh-hant/php-java/manage-ole/)*。
{{% /alert %}}

## **使用超連結建立目錄**

由於超連結允許您為物件或位置加入參照，您可利用它們建立目錄。

此範例程式碼示範如何使用超連結建立目錄：

```php
  $pres = new Presentation();
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    $secondSlide = $pres->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());
    $contentTable = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
    $contentTable->getFillFormat()->setFillType(FillType::NoFill);
    $contentTable->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $contentTable->getTextFrame()->getParagraphs()->clear();
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $paragraph->setText("Title of slide 2 .......... ");
    $linkPortion = new Portion();
    $linkPortion->setText("Page 2");
    $linkPortion->getPortionFormat()->getHyperlinkManager()->setInternalHyperlinkClick($secondSlide);
    $paragraph->getPortions()->add($linkPortion);
    $contentTable->getTextFrame()->getParagraphs()->add($paragraph);
    $pres->save("link_to_slide.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **格式化超連結**

### **顏色**

使用 [Hyperlink](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/hyperlink/) 類別中的 [setColorSource](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/hyperlink/setcolorsource/) 方法，您可以設定超連結的顏色，亦可取得超連結的顏色資訊。此功能首次於 PowerPoint 2019 引入，因而此屬性的變更不適用於較舊的 PowerPoint 版本。

此範例程式碼示範在同一投影片中加入不同顏色的超連結的操作：

```php
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
    $shape1->addTextFrame("This is a sample of colored hyperlink.");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setColorSource(HyperlinkColorSource->PortionFormat);
    $portionFormat::getFillFormat()->setFillType(FillType::Solid);
    $portionFormat::getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $shape2 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
    $shape2->addTextFrame("This is a sample of usual hyperlink.");
    $shape2->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $pres->save("presentation-out-hyperlink.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **從簡報中移除超連結**

### **從文字中移除超連結**

此 PHP 程式碼示範如何從簡報投影片的文字中移除超連結：

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    foreach($slide->getShapes() as $shape) {
      $autoShape = $shape;
      if (!java_is_null($autoShape)) {
        foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
          foreach($paragraph->getPortions() as $portion) {
            $portion->getPortionFormat()->getHyperlinkManager()->removeHyperlinkClick();
          }
        }
      }
    }
    $pres->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **從圖形或框架中移除超連結**

此 PHP 程式碼示範如何從簡報投影片的圖形中移除超連結：

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    foreach($slide->getShapes() as $shape) {
      $shape->getHyperlinkManager()->removeHyperlinkClick();
    }
    $pres->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **可變超連結**

[Hyperlink](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/hyperlink/) 類別是可變的。使用此類別，您可以變更以下屬性的值：

- [Hyperlink.setTargetFrame(String)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/hyperlink/settargetframe/)
- [Hyperlink.setTooltip(String)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/hyperlink/settooltip/)
- [Hyperlink.setHistory(boolean)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/hyperlink/sethistory/)
- [Hyperlink.setHighlightClick(boolean)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/hyperlink/sethighlightclick/)
- [Hyperlink.setStopSoundOnClick(boolean)](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/hyperlink/setstopsoundonclick/)

此程式片段示範如何在投影片中新增超連結，並在之後編輯其工具提示：

```php
  $pres = new Presentation();
  try {
    $shape1 = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $shape1->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $shape1->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat::setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat::getHyperlinkClick()->setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    $portionFormat::setFontHeight(32);
    $pres->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **IHyperlinkQueries 中支援的屬性**

您可以從定義了超連結的簡報、投影片或文字取得 [HyperlinkQueries](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/hyperlinkqueries/)。

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/gethyperlinkqueries/)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/gethyperlinkqueries/)

[HyperlinkQueries](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/hyperlinkqueries/) 類別支援以下方法與屬性：

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/)

## **常見問題**

**如何在內部導航時不僅僅定位到投影片，而是定位到「區段」或區段的第一張投影片？**

PowerPoint 中的區段是投影片的分組；導航技術上仍是針對特定投影片。若要「導向區段」，通常會連結到該區段的第一張投影片。

**我可以將超連結附加到母版投影片元素，使其在所有投影片上都可使用嗎？**

是的。母版投影片與版面配置元素支援超連結。此類連結會出現在子投影片上，且在簡報播放時可點擊。

**在匯出為 PDF、HTML、圖像或影片時，超連結會被保留嗎？**

在 [PDF](/slides/zh-hant/php-java/convert-powerpoint-to-pdf/) 與 [HTML](/slides/zh-hant/php-java/convert-powerpoint-to-html/) 中，會保留連結。匯出為 [圖像](/slides/zh-hant/php-java/convert-powerpoint-to-png/) 與 [影片](/slides/zh-hant/php-java/convert-powerpoint-to-video/) 時，因為這些格式本身為點陣畫框架/影片，無法保留點擊功能，故不會保留超連結。