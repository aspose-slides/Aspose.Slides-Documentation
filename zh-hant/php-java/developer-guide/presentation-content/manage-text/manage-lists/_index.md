---
title: 使用 PHP 管理簡報中的項目符號與編號清單
linktitle: 管理清單
type: docs
weight: 60
url: /zh-hant/php-java/manage-lists/
keywords:
- 項目符號
- 項目符號清單
- 編號清單
- 符號項目符號
- 圖片項目符號
- 自訂項目符號
- 多層級清單
- 建立項目符號
- 新增項目符號
- 新增清單
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 在 PowerPoint 與 OpenDocument 簡報中建立與格式化項目符號、圖片、多層級與編號清單。"
---
## **概觀**

Aspose.Slides for PHP via Java 讓您在 PowerPoint 與 OpenDocument 簡報中建立並格式化項目符號與編號清單。清單項目是一個段落，其項目符號設定由段落格式控制。

使用 [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/#getParagraphFormat--) 方法存取段落層級的清單設定。主要入口是 [ParagraphFormat.getBullet](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#getBullet--)，它會傳回一個 [BulletFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bulletformat/) 物件。透過此物件，您可以設定項目符號類型、符號、圖片、顏色、大小、編號樣式與起始編號。

本文說明如何：

- 建立自訂符號的項目符號清單
- 建立圖片項目符號
- 透過設定段落深度建立多層級清單
- 建立編號清單
- 檢查並變更既有簡報中的清單格式

## **建立項目符號清單**

若要建立項目符號清單，請將 [Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/) 物件加入 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)，並將 [BulletFormat.setType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bulletformat/#setType-int-) 設為 [BulletType.Symbol](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bullettype/#Symbol)。之後可使用 [BulletFormat.setChar](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bulletformat/#setChar-char-)、[BulletFormat.getColor](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bulletformat/#getColor--) 與 [BulletFormat.setHeight](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bulletformat/#setHeight-float-) 來控制項目符號外觀。

以下 PHP 程式碼示範如何在投影片中建立項目符號清單：

```php
function createParagraph($paragraphText)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $paragraph->getParagraphFormat()->getBullet()->setChar("*");
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $bulletColor = new Java("java.awt.Color", 205, 92, 92);
    $paragraph->getParagraphFormat()->getBullet()->getColor()->setColor($bulletColor);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = createParagraph("The first paragraph");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph");
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("symbol_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

結果：

![符號項目符號](symbol_bullets.png)

## **建立編號清單**

當項目順序很重要時，請使用編號清單。將 [BulletFormat.setType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bulletformat/#setType-int-) 設為 [BulletType.Numbered](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bullettype/#Numbered)。您也可以透過 [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle-int-) 來選擇編號格式，或在清單需從非 1 的值開始時使用 [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-)。

以下 PHP 程式碼示範如何在投影片中建立編號清單：

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 90, 80);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph1->setText("Apple");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph2->setText("Orange");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph3->setText("Banana");
    $textFrame->getParagraphs()->add($paragraph3);

    $presentation->save("numbered_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

結果：

![編號項目符號](numbered_bullets.png)

## **建立圖片項目符號**

Aspose.Slides 允許您以圖像取代一般的項目符號。圖片項目符號最適合使用簡單且在小尺寸下仍易辨識的圖像，例如圖示或小型透明 PNG 檔。

{{% alert color="primary" %}}
理想情況下，若您打算以圖像取代一般項目符號，請選擇具透明背景的簡易圖形。此類圖像非常適合作為自訂項目符號。
  
請記得圖像會被縮小到相當小的尺寸。因此，我們強烈建議選擇在列表中作為項目符號使用時仍保持清晰且視覺有效的圖像。
{{% /alert %}}

要建立圖片項目符號，先將圖像加入 [Presentation.getImages](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#getImages--) 並將回傳的 [PPImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ppimage/) 物件指派給 [BulletFormat.getPicture](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bulletformat/#getPicture--)。在指派圖像之前，先將 [BulletFormat.setType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bulletformat/#setType-int-) 設為 [BulletType.Picture](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bullettype/#Picture)。

假設我們有一個「image.png」：

![用於項目符號的圖片](picture_for_bullets.png)

以下 PHP 程式碼示範如何在投影片中建立圖片項目符號：

```php
function createParagraph($paragraphText, $bulletImage)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($bulletImage);
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $image = Images::fromFile("image.png");
    $bulletImage = $presentation->getImages()->addImage($image);

    $paragraph1 = createParagraph("The first paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("picture_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

結果：

![圖片項目符號](picture_bullets.png)

## **建立多層級清單**

使用 [ParagraphFormat.setDepth](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setDepth-short-) 可將清單項目放在不同層級。層級 0 為最上層，層級 1 為其下的子層，依此類推。

以下 PHP 程式碼示範如何建立多層級項目符號清單：

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 260, 110);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->setDepth(0);
    $paragraph1->setText("My text - Depth 0");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->setDepth(1);
    $paragraph2->setText("My text - Depth 1");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->setDepth(2);
    $paragraph3->setText("My text - Depth 2");
    $textFrame->getParagraphs()->add($paragraph3);

    $paragraph4 = new Paragraph();
    $paragraph4->getParagraphFormat()->setDepth(3);
    $paragraph4->setText("My text - Depth 3");
    $textFrame->getParagraphs()->add($paragraph4);

    $presentation->save("multilevel_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

結果：

![多層級清單](multilevel_list.png)

## **變更既有清單**

若要變更既有簡報中的清單格式，存取目標段落並更新其 [ParagraphFormat.getBullet](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#getBullet--) 設定。建立清單時使用的屬性同樣可用於檢查或修改從 PPT、PPTX 或 ODP 檔載入的清單。

以下 PHP 程式碼將文字框中的第一個段落改為使用編號清單樣式：

```php
$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletRomanUCPeriod);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(1);
    $paragraph->getParagraphFormat()->setMarginLeft(30);
    $paragraph->getParagraphFormat()->setIndent(-20);

    $presentation->save("updated_list.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **常見問題**

**項目符號與編號清單能匯出為 PDF 或影像嗎？**

可以。Aspose.Slides 會在目標格式支援相應文字版面配置與項目符號功能時，保留清單格式。

**我可以編輯既有簡報中的清單嗎？**

可以。載入簡報、存取目標段落、檢查或更新其 [ParagraphFormat.getBullet](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#getBullet--) 設定，然後儲存簡報。

**清單可以包含非拉丁文字嗎？**

可以。清單項目的文字可以包含 Unicode 字元，您可以在多語言簡報中建立清單。請確保簡報使用的字型支援您需要的字元。