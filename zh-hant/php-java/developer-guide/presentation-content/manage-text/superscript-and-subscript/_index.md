---
title: 使用 PHP 管理簡報中的上標與下標
linktitle: 上標與下標
type: docs
weight: 80
url: /zh-hant/php-java/superscript-and-subscript/
keywords:
- 上標
- 下標
- 新增上標
- 新增下標
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "在 Aspose.Slides for PHP（透過 Java）中掌握上標與下標，並以專業的文字格式提升簡報的最大影響力。"
---
## **概述**

Aspose.Slides 提供將上標和下標文字整合到您的 PowerPoint (PPT、PPTX) 以及 OpenDocument (ODP) 簡報中的功能。無論您需要突出顯示化學式、數學方程式，或以腳註註解內容，這些專門的格式選項都有助於維持清晰與精確。在本文中，您將學習如何無縫套用上標和下標樣式，確保每張投影片都呈現專業效果。

## **管理上標與下標文字**

您可以在任何段落區塊中加入上標和下標文字。若要在 Aspose.Slides 文字框中加入上標或下標文字，必須使用 [**setEscapement**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setEscapement) 方法，該方法屬於 [PortionFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/PortionFormat) 類別。

此屬性可取得或設定上標或下標文字（值範圍從 -100%（下標）到 100%（上標））。例如：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。
- 使用 Index 取得投影片的參考。
- 在投影片上加入型別為 [Rectangle](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ShapeType#Rectangle) 的 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
- 存取與 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/) 相關聯的 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)。
- 清除現有的 Paragraphs
- 建立一個用於保存上標文字的新段落物件，並將其加入 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/) 的 [IParagraphs collection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#getParagraphs)。
- 建立新的 Portion 物件
- 將該 Portion 的 Escapement 屬性設定為 0 到 100 之間，以加入上標。（0 表示無上標）
- 為 [Portion](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Portion) 設定文字，然後將其加入段落的 Portion 集合中。
- 建立一個用於保存下標文字的新段落物件，並將其加入 ITextFrame 的 IParagraphs 集合中。
- 建立新的 Portion 物件
- 將該 Portion 的 Escapement 屬性設定為 0 到 -100 之間，以加入下標。（0 表示無下標）
- 為 [Portion](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Portion) 設定文字，然後將其加入段落的 Portion 集合中。
- 將簡報儲存為 PPTX 檔案。

以下示範上述步驟的實作方式。

```php
  # 實例化代表 PPTX 的 Presentation 類別
  $pres = new Presentation();
  try {
    # 取得投影片
    $slide = $pres->getSlides()->get_Item(0);
    # 建立文字方塊
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();
    # 建立用於上標文字的段落
    $superPar = new Paragraph();
    # 建立一般文字的 Portion
    $portion1 = new Portion();
    $portion1->setText("SlideTitle");
    $superPar->getPortions()->add($portion1);
    # 建立上標文字的 Portion
    $superPortion = new Portion();
    $superPortion->getPortionFormat()->setEscapement(30);
    $superPortion->setText("TM");
    $superPar->getPortions()->add($superPortion);
    # 建立用於下標文字的段落
    $paragraph2 = new Paragraph();
    # 建立一般文字的 Portion
    $portion2 = new Portion();
    $portion2->setText("a");
    $paragraph2->getPortions()->add($portion2);
    # 建立下標文字的 Portion
    $subPortion = new Portion();
    $subPortion->getPortionFormat()->setEscapement(-25);
    $subPortion->setText("i");
    $paragraph2->getPortions()->add($subPortion);
    # 將段落加入文字方塊
    $textFrame->getParagraphs()->add($superPar);
    $textFrame->getParagraphs()->add($paragraph2);
    $pres->save("formatText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**在匯出為 PDF 或其他格式時，上標與下標會保留嗎？**

是的，Aspose.Slides 在將簡報匯出為 PDF、PPT/PPTX、影像以及其他支援的格式時，會正確保留上標與下標的格式。此專門的格式在所有輸出檔案中皆保持完整。

**上標與下標能與其他格式樣式（例如粗體或斜體）結合使用嗎？**

是的，Aspose.Slides 允許在單一 Portion 中混合多種文字樣式。您可以啟用粗體、斜體、底線，並透過設定 [PortionFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portionformat/) 中的相應屬性，同時套用上標或下標。

**上標與下標的格式能在表格、圖表或 SmartArt 內的文字使用嗎？**

是的，Aspose.Slides 支援在大多數物件內的格式設定，包括表格與圖表元素。若要在 SmartArt 中使用，需存取相應的元素（例如 [SmartArtNode](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/smartartnode/)）及其文字容器，然後以類似方式設定 [PortionFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portionformat/) 的屬性。