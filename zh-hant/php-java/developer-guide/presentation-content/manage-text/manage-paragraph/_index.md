---
title: 管理 PHP 中的 PowerPoint 文字段落
linktitle: 管理段落
type: docs
weight: 40
url: /zh-hant/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
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
- 段落轉圖片
- 文字轉圖片
- 匯出段落
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 完成段落格式的完整控制 — 在 PPT、PPTX 與 ODP 簡報中最佳化對齊、間距與樣式。"
---
## **簡介**

Aspose.Slides 提供了處理 PowerPoint 文字、段落與區塊所需的所有類別。

* Aspose.Slides 提供了 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/) 類別，讓您可以新增代表段落的物件。`TextFrame` 物件可以包含一個或多個段落（每個段落透過換行符建立）。
* Aspose.Slides 提供了 [Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/) 類別，讓您可以新增代表區塊的物件。`Paragraph` 物件可以包含一個或多個區塊（區塊物件的集合）。
* Aspose.Slides 提供了 [Portion](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/) 類別，讓您可以新增代表文字與其格式屬性的物件。

`Paragraph` 物件透過底層的 `Portion` 物件，能處理具有不同格式屬性的文字。

## **新增包含多個區塊的多段落**

以下步驟示範如何新增一個包含 3 個段落、且每個段落各有 3 個區塊的文字框：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 透過索引取得目標投影片的參考。
3. 在投影片上加入矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
4. 取得與該 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/) 關聯的 ITextFrame。
5. 建立兩個 [Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/) 物件，並將它們加入 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/) 的段落集合。
6. 為每個新 `Paragraph`（預設段落則為兩個）建立三個 [Portion](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/) 物件，並將每個 `Portion` 加入各自 `Paragraph` 的區塊集合。
7. 為每個區塊設定文字。
8. 使用 `Portion` 物件所提供的格式屬性，套用您偏好的格式設定。
9. 儲存已修改的簡報。

以下 PHP 程式碼實作了上述新增段落與區塊的步驟：

```php
# 實例化一個代表 PPTX 檔案的 Presentation 類別
$pres = new Presentation();
try {
    # 存取第一張投影片
    $slide = $pres->getSlides()->get_Item(0);
    # 新增一個矩形類型的 AutoShape
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # 取得 AutoShape 的 TextFrame
    $tf = $ashp->getTextFrame();
    # 建立具不同文字格式的段落與區塊
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

項目符號清單可讓您快速且有效率地組織與呈現資訊。使用項目符號的段落始終更易閱讀與理解。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 透過索引取得目標投影片的參考。
3. 在選取的投影片上加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
4. 取得該 AutoShape 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)。
5. 移除 `TextFrame` 中的預設段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/) 類別建立第一個段落實例。
7. 將段落的項目符號 `Type` 設為 `Symbol`，並設定項目符號字元。
8. 設定段落的 `Text`。
9. 設定項目符號的 `Indent`。
10. 設定項目符號的顏色。
11. 設定項目符號的高度。
12. 將新段落加入 `TextFrame` 的段落集合。
13. 新增第二個段落，並重複第 7~12 步驟。
14. 儲存簡報。

以下 PHP 程式碼示範如何新增段落項目符號：

```php
# 實例化一個代表 PPTX 檔案的 Presentation 類別
$pres = new Presentation();
try {
    # 取得第一張投影片
    $slide = $pres->getSlides()->get_Item(0);
    # 新增並取得 AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 取得 AutoShape 的文字框
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
    # 建立第二個段落
    $para2 = new Paragraph();
    # 設定段落的項目符號類型與樣式
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # 設定段落文字
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

項目符號清單可讓您快速且有效率地組織與呈現資訊。使用圖片段落可讓內容更易閱讀與理解。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 透過索引取得目標投影片的參考。
3. 在投影片上加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
4. 取得該 AutoShape 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)。
5. 移除 `TextFrame` 中的預設段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/) 類別建立第一個段落實例。
7. 以 [PPImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ppimage/) 載入圖片。
8. 將項目符號類型設為 [Picture](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bullettype/#Picture)，並設定圖片。
9. 設定段落的 `Text`。
10. 設定項目符號的 `Indent`。
11. 設定項目符號的顏色。
12. 設定項目符號的高度。
13. 將新段落加入 `TextFrame` 的段落集合。
14. 新增第二個段落，依照前述步驟重複操作。
15. 儲存已修改的簡報。

以下 PHP 程式碼示範如何新增與管理圖片項目符號：

```php
# 實例化一個代表 PPTX 檔案的 Presentation 類別
$presentation = new Presentation();
try {
    # 取得第一張投影片
    $slide = $presentation->getSlides()->get_Item(0);
    # 實例化用於項目符號的圖片
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }
    # 新增並取得 Autoshape
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 取得 autoshape 文字框
    $textFrame = $autoShape->getTextFrame();
    # 移除預設段落
    $textFrame->getParagraphs()->removeAt(0);
    # 建立新的段落
    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    # 設定段落的項目符號樣式與圖片
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

項目符號清單可讓您快速且有效率地組織與呈現資訊。多層級項目符號更易閱讀與理解。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 透過索引取得目標投影片的參考。
3. 在新投影片上加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
4. 取得該 AutoShape 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)。
5. 移除 `TextFrame` 中的預設段落。
6. 透過 [Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/) 類別建立第一個段落實例，並將深度設定為 0。
7. 透過 `Paragraph` 類別建立第二個段落實例，將深度設定為 1。
8. 透過 `Paragraph` 類別建立第三個段落實例，將深度設定為 2。
9. 透過 `Paragraph` 類別建立第四個段落實例，將深度設定為 3。
10. 將新段落加入 `TextFrame` 的段落集合。
11. 儲存已修改的簡報。

以下 PHP 程式碼示範如何新增與管理多層級項目符號：

```php
# 實例化一個代表 PPTX 檔案的 Presentation 類別
$pres = new Presentation();
try {
    # 取得第一張投影片
    $slide = $pres->getSlides()->get_Item(0);
    # 新增並取得 Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 取得已建立 AutoShape 的文字框
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

[BulletFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bulletformat/) 類別提供了 [setNumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) 等方法，可讓您管理自訂編號或格式的段落。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 取得包含段落的投影片。
3. 在投影片上加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
4. 取得該 AutoShape 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)。
5. 移除 `TextFrame` 中的預設段落。
6. 透過 [Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/) 類別建立第一個段落實例，並將 [NumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) 設為 2。
7. 透過 `Paragraph` 類別建立第二個段落實例，將 `NumberedBulletStartWith` 設為 3。
8. 透過 `Paragraph` 類別建立第三個段落實例，將 `NumberedBulletStartWith` 設為 7。
9. 將新段落加入 `TextFrame` 的段落集合。
10. 儲存已修改的簡報。

以下 PHP 程式碼示範如何新增與管理具有自訂編號或格式的段落：

```php
$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # 取得已建立 AutoShape 的文字框
    $textFrame = $shape->getTextFrame();
    # 移除預設已存在的段落
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

## **為段落設定首行縮排**

使用 [ParagraphFormat::setIndent](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/setindent/) 方法可控制段落的首行縮排。此方法僅移動第一行相對於段落左邊界的距離。正值會將第一行向右移動，而其餘行則保持與段落本體對齊。

當需要整段移動時，請使用 [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/setmarginleft/)；若只需移動第一行，則使用 [ParagraphFormat::setIndent](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/setindent/)。

以下範例建立多個段落，並套用不同的縮排值，以示範首行縮排對段落版面的影響。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 取得目標投影片。
3. 在投影片上加入矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
4. 為圖形加入空的 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)，並移除預設段落。
5. 建立多個段落，並為它們設定不同的 [Indent](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/setindent/) 值。
6. 將段落加入文字框。
7. 儲存已修改的簡報。

以下程式碼示範如何設定段落縮排：

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

## **為段落設定懸掛縮排**

懸掛縮排是一種段落版面配置，第一行位於其餘行的左側。在 Aspose.Slides 中，您可透過 [ParagraphFormat::setIndent](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/setindent/) 方法實現此效果。將縮排設定為負值，即可使第一行相對於段落本體向左移動。

實務上，[ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/setmarginleft/) 定義段落本體的左側位置，而 [ParagraphFormat::setIndent](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/setindent/) 定義第一行相對於該左側的位移。若要產生懸掛縮排，請將 `MarginLeft` 設為正值，`Indent` 設為負值。

此格式在書目、參考文獻、詞彙表等需要換行後對齊於段落本體而非首字的情況下特別有用。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 取得目標投影片。
3. 在投影片上加入矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
4. 為圖形加入空的 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)，並移除預設段落。
5. 為每個段落設定正值的 [MarginLeft](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/setmarginleft/)。
6. 設定負值的 [Indent](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/setindent/)，以產生懸掛縮排效果。
7. 將段落加入文字框。
8. 儲存已修改的簡報。

以下程式碼示範如何為段落設定懸掛縮排：

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

## **管理段落結束屬性**

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
1. 透過位置取得包含段落的投影片參考。
1. 在投影片上加入矩形 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
1. 為矩形加入含兩個段落的 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)。
1. 設定段落的字型高度與字型類型。
1. 設定段落的結束屬性。
1. 將已修改的簡報寫入為 PPTX 檔案。

以下 PHP 程式碼示範如何為段落設定結束屬性：

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

Aspose.Slides 加強了將 HTML 文字匯入段落的支援。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 透過索引取得目標投影片的參考。
3. 在投影片上加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
4. 加入並取得 `AutoShape` 的 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)。
5. 移除 `TextFrame` 中的預設段落。
6. 在 TextReader 中讀取來源 HTML 檔案。
7. 透過 [Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/) 類別建立第一個段落實例。
8. 將讀取的 TextReader 內容加入 TextFrame 的 [ParagraphCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphcollection/)。
9. 儲存已修改的簡報。

以下 PHP 程式碼實作了匯入 HTML 文字至段落的步驟：

```php
# 建立空的簡報實例
$pres = new Presentation();
try {
    # 存取簡報的預設第一張投影片
    $slide = $pres->getSlides()->get_Item(0);
    # 新增 AutoShape 以容納 HTML 內容
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # 為圖形新增文字框
    $ashape->addTextFrame("");
    # 清除已加入文字框中的所有段落
    $ashape->getTextFrame()->getParagraphs()->clear();
    # 使用 StreamReader 載入 HTML 檔案
    $tr = new StreamReader("file.html");
    # 在文字框中加入來自 HTML StreamReader 的文字
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

Aspose.Slides 加強了將段落文字匯出為 HTML 的支援。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例，並載入目標簡報。
2. 透過索引取得目標投影片的參考。
3. 取得將要匯出為 HTML 的文字所在圖形。
4. 取得該圖形的 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)。
5. 建立 `StreamWriter` 實例，並新增 HTML 檔案。
6. 為 StreamWriter 提供起始索引，匯出您偏好的段落。

以下 PHP 程式碼示範如何將 PowerPoint 段落文字匯出為 HTML：

```php
# 載入簡報檔案
$pres = new Presentation("ExportingHTMLText.pptx");
try {
    # 存取簡報的預設第一張投影片
    $slide = $pres->getSlides()->get_Item(0);
    # 目標索引
    $index = 0;
    # 取得已加入的圖形
    $ashape = $slide->getShapes()->get_Item($index);
    # 建立輸出 HTML 檔案
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # 擷取第一段落為 HTML
    # 以提供段落起始索引與要複製的段落總數方式，將段落資料寫入 HTML
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
} catch (JavaException $e) {
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **將段落另存為圖片**

本節將展示兩個範例，說明如何將由 [Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/) 類別表示的文字段落另存為圖片。兩個範例皆包含以下步驟：使用 [Shape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/) 類別的 `getImage` 方法取得包含段落的圖形影像、計算段落在圖形中的邊界，並將其匯出為位圖圖像。這些方法可讓您從 PowerPoint 簡報中擷取特定文字區段，並另存為單獨圖片，適用於各種後續使用情境。

假設我們有一個名為 sample.pptx 的簡報檔，內含一張投影片，第一個圖形是一個包含三個段落的文字方塊。

![包含三個段落的文字方塊](paragraph_to_image_input.png)

**範例 1**

本範例取得第二個段落的影像。為此，我們先從簡報的第一張投影片中取得圖形影像，然後計算第二個段落在圖形文字框中的邊界。接著將段落重新繪製至新的位圖圖像，並以 PNG 格式儲存。此方法特別適合在需要將特定段落另存為獨立圖片，同時保留文字的精確尺寸與格式時使用。

```php
$imageIO = new Java("javax.imageio.ImageIO");

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // 將圖形儲存至記憶體作為位圖。
    $shapeImage = $firstShape->getImage();
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // 從記憶體建立圖形位圖。
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

    // 裁剪圖形位圖以僅取得段落位圖。
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

結果：

![段落影像](paragraph_to_image_output.png)

**範例 2**

在本範例中，我們在先前的方法基礎上加入了縮放比例。從簡報中取得圖形並以 `2` 的縮放比例儲存為影像，從而在匯出段落時得到更高解析度。計算段落邊界時會考慮縮放比例。當需要更高畫質的圖像（例如用於高品質列印材料）時，縮放非常有用。

```php
$imageIO = new Java("javax.imageio.ImageIO");

$imageScaleX = 2;
$imageScaleY = $imageScaleX;

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // 將圖形以縮放比例儲存至記憶體作為位圖。
    $shapeImage = $firstShape->getImage(ShapeThumbnailBounds::Shape, $imageScaleX, $imageScaleY);
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // 從記憶體建立圖形位圖。
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

    // 裁剪圖形位圖以僅取得段落位圖。
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **常見問題集**

**我可以完全停用文字框內的自動換行嗎？**

可以。使用文字框的換行設定（[setWrapText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/setwraptext/)）將換行關閉，即可避免行在框邊緣換行。

**如何取得特定段落在投影片上的精確邊界？**

您可以取得段落（甚至單一區塊）的邊界矩形，以得知其在投影片上的精確位置與尺寸。

**段落的對齊方式（左/右/置中/兩端對齊）在何處控制？**

[Alignment](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/setalignment/) 是在 [ParagraphFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/) 中的段落層級設定；它會套用於整個段落，不受單一區塊格式影響。

**我可以為段落中的單一詞彙設定拼寫檢查語言嗎？**

可以。語言設定在區塊層級（[PortionFormat::setLanguageId](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setLanguageId)），因此同一段落內可同時存在多種語言。