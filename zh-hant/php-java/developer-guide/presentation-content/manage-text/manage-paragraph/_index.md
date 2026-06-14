---
title: 在 PHP 中管理 PowerPoint 文字段落
linktitle: 管理段落
type: docs
weight: 40
url: /zh-hant/php-java/manage-paragraph/
keywords:
- 新增文字
- 新增段落
- 管理文字
- 管理段落
- 管理項目符號
- 段落縮排
- 懸掛縮排
- 段落項目符號
- 編號清單
- 項目符號清單
- 段落屬性
- 匯入 HTML
- 文字轉 HTML
- 段落轉 HTML
- 段落轉影像
- 文字轉影像
- 匯出段落
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 精通段落格式設定 — 優化 PPT、PPTX 及 ODP 簡報中的對齊、間距與樣式。"
---
## **簡介**

Aspose.Slides 提供您處理 PowerPoint 文字、段落和文字段所需的所有類別。

* Aspose.Slides 提供 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/) 類別，讓您新增代表段落的物件。`TextFame` 物件可以包含一個或多個段落（每個段落透過換行字元建立）。
* Aspose.Slides 提供 [Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/) 類別，讓您新增代表文字段的物件。`Paragraph` 物件可以包含一個或多個文字段（文字段物件的集合）。
* Aspose.Slides 提供 [Portion](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/) 類別，讓您新增代表文字及其格式屬性的物件。

`Paragraph` 物件能透過其底層的 `Portion` 物件處理具有不同格式屬性的文字。

## **新增多段落且每段落包含多個文字段**

以下步驟示範如何新增一個包含 3 個段落且每個段落皆包含 3 個文字段的文字框：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 透過索引取得相關投影片的參照。
3. 在投影片中新增一個矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
4. 取得與 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/) 相關聯的 ITextFrame。
5. 建立兩個 [Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/) 物件，並將它們加入 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/) 的段落集合中。
6. 為每個新 `Paragraph` 建立三個 [Portion](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/) 物件（預設段落建立兩個 Portion 物件），並將每個 `Portion` 物件加入各自的 `Paragraph` 的文字段集合中。
7. 為每個文字段設定文字。
8. 使用 `Portion` 物件提供的格式屬性，對每個文字段套用您偏好的格式設定。
9. 儲存已修改的簡報。

```php
# 實例化代表 PPTX 檔案的 Presentation 類別
$pres = new Presentation();
try {
    # 存取第一張投影片
    $slide = $pres->getSlides()->get_Item(0);
    # 新增一個矩形類型的 AutoShape
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # 存取 AutoShape 的 TextFrame
    $tf = $ashp->getTextFrame();
    # 建立具有不同文字格式的段落與文字段
    $para0 = $tf->getParagraphs()->get_Item(0);
    $port01 = new Portion();
    $port02 = new Portion();
    $para0->getPortions()->add($port01);
    $para0->getPortions()->add($port02);
    $para1 = new Paragraph();
    $tf->getParagraphs()->add($para1);
    $port10 = new Portion();
    $port11 = new Portion();
    $port12 = new Portion();
    $para1->getPortions()->add($port10);
    $para1->getPortions()->add($port11);
    $para1->getPortions()->add($port12);
    $para2 = new Paragraph();
    $tf->getParagraphs()->add($para2);
    $port20 = new Portion();
    $port21 = new Portion();
    $port22 = new Portion();
    $para2->getPortions()->add($port20);
    $para2->getPortions()->add($port21);
    $para2->getPortions()->add($port22);
    for($i = 0; $i < 3; $i++) {
        for($j = 0; $j < 3; $j++) {
            $portion = $tf->getParagraphs()->get_Item($i)->getPortions()->get_Item($j);
            $portion->setText("Portion0" . $j);
            if ($j == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($j == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }
    # 將 PPTX 寫入磁碟
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **管理段落項目符號**

項目符號清單可協助您快速、有效率地組織與呈現資訊。使用項目符號的段落更易於閱讀與理解。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 透過索引取得相關投影片的參照。
3. 在選取的投影片中加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
4. 取得自動圖形的 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)。
5. 移除 `TextFrame` 中的預設段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/) 類別建立第一個段落實例。
7. 將段落的項目符號 `Type` 設為 `Symbol`，並設定項目符號字元。
8. 設定段落的 `Text`。
9. 設定段落的項目符號 `Indent`。
10. 為項目符號設定顏色。
11. 設定項目符號的高度。
12. 將新段落加入 `TextFrame` 的段落集合中。
13. 新增第二個段落，並重複步驟 7 至 13 的流程。
14. 儲存簡報。

```php
# 實例化代表 PPTX 檔案的 Presentation 類別
$pres = new Presentation();
try {
    # 存取第一張投影片
    $slide = $pres->getSlides()->get_Item(0);
    # 新增並存取 AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 存取 AutoShape 的文字框
    $txtFrm = $aShp->getTextFrame();
    # 移除預設段落
    $txtFrm->getParagraphs()->removeAt(0);
    # 建立段落
    $para = new Paragraph();
    # 設定段落的項目符號樣式與符號
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # 設定段落文字
    $para->setText("Welcome to Aspose.Slides");
    # 設定項目符號縮排
    $para->getParagraphFormat()->setIndent(25);
    # 設定項目符號顏色
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// 設定 IsBulletHardColor 為 true 以使用自訂項目符號顏色

    # 設定項目符號高度
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # 將段落加入文字框
    $txtFrm->getParagraphs()->add($para);
    # 建立第二段落
    $para2 = new Paragraph();
    # 設定段落的項目符號類型與樣式
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # 新增段落文字
    $para2->setText("This is numbered bullet");
    # 設定項目符號縮排
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// 設定 IsBulletHardColor 為 true 以使用自訂項目符號顏色

    # 設定項目符號高度
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # 將段落加入文字框
    $txtFrm->getParagraphs()->add($para2);
    # 儲存已修改的簡報
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **管理圖片項目符號**

項目符號清單可協助您快速、有效率地組織與呈現資訊。圖片項目符號的段落易於閱讀與理解。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 透過索引取得相關投影片的參照。
3. 在投影片中加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
4. 取得自動圖形的 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)。
5. 移除 `TextFrame` 中的預設段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/) 類別建立第一個段落實例。
7. 在 [PPImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ppimage/) 中載入影像。
8. 將項目符號類型設定為 [Picture](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bullettype/#Picture)，並設定影像。
9. 設定段落的 `Text`。
10. 設定段落的項目符號 `Indent`。
11. 為項目符號設定顏色。
12. 設定項目符號的高度。
13. 將新段落加入 `TextFrame` 的段落集合中。
14. 新增第二個段落，並依照前述步驟重複操作。
15. 儲存已修改的簡報。

```php
# 實例化代表 PPTX 檔案的 Presentation 類別
$presentation = new Presentation();
try {
    # 存取第一張投影片
    $slide = $presentation->getSlides()->get_Item(0);
    # 實例化項目符號用的影像
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }
    # 新增並存取 Autoshape
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 存取 autoshape 的文字框
    $textFrame = $autoShape->getTextFrame();
    # 移除預設段落
    $textFrame->getParagraphs()->removeAt(0);
    # 建立新段落
    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    # 設定段落的項目符號樣式與影像
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # 設定項目符號高度
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # 將段落加入文字框
    $textFrame->getParagraphs()->add($paragraph);
    # 將簡報寫入為 PPTX 檔案
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # 將簡報寫入為 PPT 檔案
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
} catch (JavaException $e) {
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **管理多層級項目符號**

項目符號清單可協助您快速、有效率地組織與呈現資訊。多層級項目符號易於閱讀與理解。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 透過索引取得相關投影片的參照。
3. 在新投影片中加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
4. 取得自動圖形的 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)。
5. 移除 `TextFrame` 中的預設段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/) 類別建立第一個段落實例，並將深度設為 0。
7. 使用 `Paragraph` 類別建立第二個段落實例，並將深度設為 1。
8. 使用 `Paragraph` 類別建立第三個段落實例，並將深度設為 2。
9. 使用 `Paragraph` 類別建立第四個段落實例，並將深度設為 3。
10. 將新段落加入 `TextFrame` 的段落集合中。
11. 儲存已修改的簡報。

```php
# 實例化代表 PPTX 檔案的 Presentation 類別
$pres = new Presentation();
try {
    # 存取第一張投影片
    $slide = $pres->getSlides()->get_Item(0);
    # 新增並存取 Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 存取所建立 Autoshape 的文字框
    $text = $aShp->addTextFrame("");
    # 清除預設段落
    $text->getParagraphs()->clear();
    # 新增第一個段落
    $para1 = new Paragraph();
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 設定項目符號層級
    $para1->getParagraphFormat()->setDepth(0);
    # 新增第二個段落
    $para2 = new Paragraph();
    $para2->setText("Second Level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 設定項目符號層級
    $para2->getParagraphFormat()->setDepth(1);
    # 新增第三個段落
    $para3 = new Paragraph();
    $para3->setText("Third Level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 設定項目符號層級
    $para3->getParagraphFormat()->setDepth(2);
    # 新增第四個段落
    $para4 = new Paragraph();
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 設定項目符號層級
    $para4->getParagraphFormat()->setDepth(3);
    # 將段落加入集合
    $text->getParagraphs()->add($para1);
    $text->getParagraphs()->add($para2);
    $text->getParagraphs()->add($para3);
    $text->getParagraphs()->add($para4);
    # 將簡報寫入為 PPTX 檔案
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **管理自訂編號清單的段落**

[BulletFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bulletformat/) 類別提供 [setNumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) 方法及其他功能，讓您管理具有自訂編號或格式的段落。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 取得包含該段落的投影片。
3. 在投影片中加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
4. 取得自動圖形的 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)。
5. 移除 `TextFrame` 中的預設段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/) 類別建立第一個段落實例，並將 [NumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) 設為 2。
7. 使用 `Paragraph` 類別建立第二個段落實例，並將 `NumberedBulletStartWith` 設為 3。
8. 使用 `Paragraph` 類別建立第三個段落實例，並將 `NumberedBulletStartWith` 設為 7。
9. 將新段落加入 `TextFrame` 的段落集合中。
10. 儲存已修改的簡報。

```php
$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 存取所建立 autoshape 的文字框
    $textFrame = $shape->getTextFrame();
    # 移除預設的現有段落
    $textFrame->getParagraphs()->removeAt(0);
    # 第一個清單
    $paragraph1 = new Paragraph();
    $paragraph1->setText("bullet 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("bullet 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph2);
    $paragraph5 = new Paragraph();
    $paragraph5->setText("bullet 7");
    $paragraph5->getParagraphFormat()->setDepth(4);
    $paragraph5->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $paragraph5->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph5);
    $presentation->save("SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **設定段落首行縮排**

使用 [ParagraphFormat::setIndent](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/setindent/) 方法可控制段落的首行縮排。此方法僅移動第一行相對於段落左邊緣的距離。正值會將首行向右移動，而其餘行則保持與段落本體對齊。

當需要移動整段時，使用 [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/setmarginleft/)；若僅需移動首行，使用 [ParagraphFormat::setIndent](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/setindent/)。

以下範例建立多個段落，並套用不同的縮排值，以示範首行縮排如何影響段落排版。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 取得目標投影片。
3. 在投影片中加入一個矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
4. 在形狀中新增空的 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)，並移除預設段落。
5. 建立多個段落，並為它們設定不同的 [Indent](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/setindent/) 值。
6. 將段落加入文字框。
7. 儲存已修改的簡報。

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    $thirdParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $thirdParagraph->getParagraphFormat()->setIndent(40.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("paragraph_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![段落的首行縮排](first_line_indent.png)

## **設定段落懸掛縮排**

懸掛縮排是一種段落排版方式，第一行相對於後續行向左開始。在 Aspose.Slides 中，您可使用 [ParagraphFormat::setIndent](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/setindent/) 方法產生此效果。將縮排設為負值，即可使第一行相對於段落本體向左移動。

實務上，[ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/setmarginleft/) 定義段落本體的左側位置，而 [ParagraphFormat::setIndent](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/setindent/) 定義第一行相對於該邊距的位置。要建立懸掛縮排，請將 `MarginLeft` 設為正值，`Indent` 設為負值。

此格式在參考文獻、引用、詞彙表條目以及其他需要將換行行對齊於段落本體而非首行第一個字元的段落中十分有用。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 取得目標投影片。
3. 在投影片中加入一個矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
4. 在形狀中新增空的 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)，並移除預設段落。
5. 建立段落，並為每個段落設定正值的 [MarginLeft](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/setmarginleft/)。
6. 設定負值的 [Indent](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/setindent/)，以產生懸掛縮排效果。
7. 將段落加入文字框。
8. 儲存已修改的簡報。

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    $secondParagraph->getParagraphFormat()->setMarginLeft(60.0);
    $secondParagraph->getParagraphFormat()->setIndent(-30.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("hanging_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

結果：

![段落的懸掛縮排](hanging_indent.png)

## **管理段落結尾執行屬性**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 透過其位置取得包含該段落的投影片參照。
3. 在投影片中加入一個矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
4. 在矩形中加入一個包含兩個段落的 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)。
5. 為段落設定字型高度與字型類型。
6. 設定段落的 End 屬性。
7. 將已修改的簡報寫入為 PPTX 檔案。

```php
$pres = new Presentation();
try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("Sample text"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("Sample text 2"));
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(48);
    $portionFormat::setLatinFont(new FontData("Times New Roman"));
    $para2->setEndParagraphPortionFormat($portionFormat);
    $shape->getTextFrame()->getParagraphs()->add($para1);
    $shape->getTextFrame()->getParagraphs()->add($para2);
    $pres->save($resourcesOutputPath . "pres.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **將 HTML 文字匯入段落**

Aspose.Slides 提供加強的支援，可將 HTML 文字匯入段落。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 透過索引取得相關投影片的參照。
3. 在投影片中加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
4. 加入並取得 `AutoShape` 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)。
5. 移除 `TextFrame` 中的預設段落。
6. 使用 TextReader 讀取來源 HTML 檔案。
7. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/) 類別建立第一個段落實例。
8. 將從 TextReader 讀取的 HTML 檔內容加入 TextFrame 的 [ParagraphCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphcollection/) 中。
9. 儲存已修改的簡報。

```php
# 建立空的簡報實例
$pres = new Presentation();
try {
    # 存取簡報的預設第一張投影片
    $slide = $pres->getSlides()->get_Item(0);
    # 新增 AutoShape 以容納 HTML 內容
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # 為形狀新增文字框
    $ashape->addTextFrame("");
    # 清除已新增文字框中的所有段落
    $ashape->getTextFrame()->getParagraphs()->clear();
    # 使用 StreamReader 載入 HTML 檔案
    $tr = new StreamReader("file.html");
    # 將 HTML StreamReader 的文字加入文字框
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # 儲存簡報
    $pres->save("output_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **將段落文字匯出為 HTML**

Aspose.Slides 提供加強的支援，可將文字（位於段落中）匯出為 HTML。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例，並載入所需的簡報。
2. 透過索引取得相關投影片的參照。
3. 取得包含欲匯出為 HTML 文字的形狀。
4. 取得該形狀的 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)。
5. 建立 `StreamWriter` 實例，並新增新的 HTML 檔案。
6. 提供起始索引給 StreamWriter，並匯出您選擇的段落。

```php
# 載入簡報檔案
$pres = new Presentation("ExportingHTMLText.pptx");
try {
    # 存取簡報的預設第一張投影片
    $slide = $pres->getSlides()->get_Item(0);
    # 所需索引
    $index = 0;
    # 存取已新增的形狀
    $ashape = $slide->getShapes()->get_Item($index);
    # 建立輸出 HTML 檔案
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # 以 HTML 形式擷取第一段落
    # 透過提供段落起始索引與要複製的段落總數，將段落資料寫入 HTML
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
} catch (JavaException $e) {
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **將段落儲存為影像**

在本節中，我們將探討兩個範例，示範如何將由 [Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/) 類別表示的文字段落儲存為影像。兩個範例皆包括使用 [Shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/) 類別的 `getImage` 方法取得包含段落的形狀影像、計算段落在形狀中的邊界，並將其匯出為點陣圖影像。這些方法允許您從 PowerPoint 簡報中擷取特定文字部份，並另存為獨立影像，對於各種後續使用情境相當有用。

假設我們有一個名為 sample.pptx 的簡報檔，包含一張投影片，第一個形狀是一個包含三個段落的文字方塊。

![包含三個段落的文字方塊](paragraph_to_image_input.png)

**範例 1**

在此範例中，我們將第二段落取得為影像。為此，我們先從簡報的第一張投影片中擷取形狀的影像，接著計算該形狀文字框中第二段落的邊界。然後將段落重新繪製到新的點陣圖影像上，並以 PNG 格式儲存。此方法在您需要將特定段落儲存為獨立影像，同時保留文字的精確尺寸與格式時特別有用。

```php
$imageIO = new Java("javax.imageio.ImageIO");

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // 將形狀在記憶體中儲存為位圖。
    $shapeImage = $firstShape->getImage();
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // 從記憶體建立形狀位圖。
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // 計算第二段落的邊界。
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();

    // 計算輸出影像的座標與尺寸（最小尺寸為 1x1 像素）。
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // 裁切形狀位圖以僅取得段落位圖。
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

![段落影像](paragraph_to_image_output.png)

**範例 2**

在此範例中，我們在先前的方法上加入縮放比例以產生段落影像。形狀從簡報中擷取，且以 `2` 的縮放比例儲存為影像。這可在匯出段落時提供更高解析度的輸出。接著會在考慮縮放比例的情況下計算段落邊界。當需要更高細節的影像時，例如用於高品質印刷品，此縮放功能特別有用。

```php
$imageIO = new Java("javax.imageio.ImageIO");

$imageScaleX = 2;
$imageScaleY = $imageScaleX;

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // 將形狀以縮放後的方式在記憶體中儲存為位圖。
    $shapeImage = $firstShape->getImage(ShapeThumbnailBounds::Shape, $imageScaleX, $imageScaleY);
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // 從記憶體建立形狀位圖。
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // 計算第二段落的邊界。
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();
    $paragraphRectangle->setRect(
            java_values($paragraphRectangle->getX()) * $imageScaleX,
            java_values($paragraphRectangle->getY()) * $imageScaleY,
            java_values($paragraphRectangle->getWidth()) * $imageScaleX,
            java_values($paragraphRectangle->getHeight()) * $imageScaleY
    );

    // 計算輸出影像的座標與尺寸（最小尺寸為 1x1 像素）。
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // 裁切形狀位圖以僅取得段落位圖。
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **FAQ**

**我可以完全停用文字框內的自動換行嗎？**

是的。使用文字框的換行設定（[setWrapText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/setwraptext/)）將換行關閉，則行不會在框的邊緣斷行。

**如何取得特定段落在投影片上的精確邊界？**

您可以取得段落（甚至單一文字段）的邊界矩形，以了解其在投影片上的精確位置與尺寸。

**段落對齊（左/右/置中/兩端對齊）是在哪裡控制的？**

[Alignment](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/setalignment/) 是在 [ParagraphFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/) 中的段落層級設定；它會套用於整個段落，而不受個別文字段格式的影響。

**我可以只為段落的一部分（例如單個字詞）設定拼寫檢查語言嗎？**

可以。語言是在文字段層級設定的（[PortionFormat::setLanguageId](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setLanguageId)），因此同一段落中可以同時存在多種語言。