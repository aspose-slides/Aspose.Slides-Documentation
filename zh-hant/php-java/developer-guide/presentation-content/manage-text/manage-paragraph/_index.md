---
title: 在 PHP 中管理 PowerPoint 文字段落
linktitle: 管理段落
type: docs
weight: 40
url: /zh-hant/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
  - /php-java/portion/
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
- 段落轉圖像
- 文字轉圖像
- 匯出段落
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 建立與格式化段落、文字段、項目符號、編號清單、縮排、HTML 內容以及段落圖像。"
---
## **概觀**

Aspose.Slides for PHP via Java 將文字表示為文字框、段落與文字段的階層結構：

* `[TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)` 代表形狀中的文字容器，並提供對其段落集合的存取。
* `[Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/)` 代表文字框中的單一段落，並提供對其文字段與段落層級格式設定的存取。
* `[Portion](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/)` 代表段落內的文字執行。每個文字段可以擁有自己的文字內容與字元層級格式設定。

因此，一個段落可以透過多個文字段來包含不同字型、顏色、大小與其他格式設定的文字。

## **建立及格式化段落**

### **建立帶多個文字段的段落**

以下步驟會建立一個文字框，內含三個段落，每個段落各有三個文字段：

1. 建立 `[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/)` 類別的實例。
2. 依照索引取得目標投影片。
3. 在投影片上新增一個矩形 `[AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)`。
4. 取得圖形的 `[TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)`。
5. 使用預設段落，並再向文字框中加入兩個 `[Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/)` 物件。
6. 為每個段落加入足夠的 `[Portion](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/)` 物件，使其包含三個文字段。預設段落已包含一個空的文字段。
7. 設定每個文字段的文字內容。
8. 透過 `[Portion::getPortionFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/#getPortionFormat--)` 套用字元層級格式設定。
9. 儲存已修改的簡報。

此 PHP 範例實作上述步驟：

```php
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    $textFrame = $shape->getTextFrame();

    $firstParagraph = $textFrame->getParagraphs()->get_Item(0);
    $firstParagraph->getPortions()->add(new Portion());
    $firstParagraph->getPortions()->add(new Portion());

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($thirdParagraph);

    $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portion->setText("Portion " . ($paragraphIndex + 1) . "." . ($portionIndex + 1));

            if ($portionIndex == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($portionIndex == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }

    $presentation->save("paragraphs_with_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **建立項目符號與編號清單**

### **建立項目符號或編號清單**

項目符號與編號可讓相關項目更易於掃描。於 Aspose.Slides 中，清單設定是透過 `[BulletFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bulletformat/)` 定義。

1. 建立 `[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/)` 類別的實例。
2. 依照索引取得目標投影片。
3. 在選取的投影片上新增一個 `[AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)`。
4. 取得圖形的 `[TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)`。
5. 從文字框中移除預設段落。
6. 為符號項目符號建立一個 `[Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/)`。
7. 將 `[BulletFormat::setType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bulletformat/#setType-int-)` 設為 `[BulletType::Symbol](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bullettype/)`，並指定項目符號字元。
8. 設定段落文字、縮排、項目符號顏色與項目符號高度。
9. 將段落加入文字框。
10. 再建立第二個段落，將 `[BulletFormat::setType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bulletformat/#setType-int-)` 設為 `[BulletType::Numbered](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bullettype/)`。
11. 設定編號項目符號樣式，並將段落加入文字框。
12. 儲存簡報。

此 PHP 範例會建立符號項目符號與編號項目符號：

```php
use aspose\slides\BulletType;
use aspose\slides\ColorType;
use aspose\slides\NullableBool;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $symbolParagraph = new Paragraph();
    $symbolParagraph->setText("Welcome to Aspose.Slides");
    $symbolParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $symbolParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $symbolParagraph->getParagraphFormat()->setIndent(25);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $symbolParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $symbolParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($symbolParagraph);

    $numberedParagraph = new Paragraph();
    $numberedParagraph->setText("This is a numbered item");
    $numberedParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $numberedParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
    $numberedParagraph->getParagraphFormat()->setIndent(25);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $numberedParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $numberedParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($numberedParagraph);

    $presentation->save("bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **使用圖片項目符號**

圖片項目符號允許使用自訂圖片取代符號或編號。

1. 建立 `[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/)` 類別的實例。
2. 依照索引取得目標投影片。
3. 新增一個 `[AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)` 並取得其 `[TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)`。
4. 從文字框中移除預設段落。
5. 載入項目符號圖片，並以 `[PPImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ppimage/)` 形式加入簡報的圖像集合。
6. 建立一個 `[Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/)`，並設定其文字。
7. 將 `[BulletFormat::setType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bulletformat/#setType-int-)` 設為 `[BulletType::Picture](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bullettype/)`。
8. 透過 `[BulletFormat::getPicture](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bulletformat/#getPicture--)` 指派圖片，並設定項目符號高度。
9. 將段落加入文字框。
10. 儲存已修改的簡報。

此 PHP 範例會建立圖片項目符號：

```php
use aspose\slides\BulletType;
use aspose\slides\Images;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $bulletImage = Images::fromFile("bullets.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($bulletImage);
    } finally {
        $bulletImage->dispose();
    }

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($presentationImage);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($paragraph);

    $presentation->save("picture_bullet.pptx", SaveFormat::Pptx);
    $presentation->save("picture_bullet.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```

### **建立多層次清單**

將 `[ParagraphFormat::setDepth](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setDepth-short-)` 設為不同值，即可將段落放在清單的不同層級。最上層的深度為 `0`。

1. 建立一個 `[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/)`，並取得投影片。
2. 新增一個 `[AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)`，並清除其文字框中的預設段落。
3. 建立四個段落，並配置它們的項目符號符號。
4. 將它們的 `[ParagraphFormat::setDepth](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setDepth-short-)` 分別設定為 `0`、`1`、`2`、`3`。
5. 將段落加入文字框，並儲存簡報。

此 PHP 範例會建立四層級的項目符號清單：

```php
use aspose\slides\BulletType;
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Content");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $firstParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setDepth(0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Second level");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $secondParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setDepth(1);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Third level");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $thirdParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->getParagraphFormat()->setDepth(2);

    $fourthParagraph = new Paragraph();
    $fourthParagraph->setText("Fourth level");
    $fourthParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $fourthParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $fourthParagraph->getParagraphFormat()->setDepth(3);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);
    $textFrame->getParagraphs()->add($fourthParagraph);

    $presentation->save("multilevel_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **以自訂值開始編號項目**

使用 `[BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-)` 來設定編號段落的起始數字。

1. 建立一個 `[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/)`，並在投影片上新增一個 `[AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)`。
2. 從圖形的文字框中清除預設段落。
3. 建立三個編號段落。
4. 分別將 `[BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-)` 設為 `2`、`3`、`7`。
5. 將段落加入文字框，並儲存簡報。

此 PHP 範例會為每個段落指定自訂的起始編號：

```php
use aspose\slides\BulletType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Start at 2");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $firstParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $textFrame->getParagraphs()->add($firstParagraph);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Start at 3");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $secondParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Start at 7");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $thirdParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("custom_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **控制段落版面配置與結束屬性**

### **設定首行縮排**

使用 `[ParagraphFormat::setIndent](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setIndent-float-)` 來控制段落的首行縮排。此方法僅移動首行相對於段落左邊距的位置。正值會將首行向右移動，而其餘行仍保持與段落本體對齊。

若需要移動整個段落，請使用 `[ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-)`。若只需要移動首行，則使用 `[ParagraphFormat::setIndent](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setIndent-float-)`。

以下範例會建立多個段落，並套用不同的 `[ParagraphFormat::setIndent](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setIndent-float-)` 值，以示範首行縮排對段落版面的影響。

1. 建立 `[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/)` 類別的實例。
2. 取得目標投影片。
3. 在投影片上新增一個矩形 `[AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)`。
4. 取得圖形的 `[TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)`，並移除預設段落。
5. 建立數個段落，為它們設定不同的 `[ParagraphFormat::setIndent](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setIndent-float-)` 值。
6. 將段落加入文字框。
7. 儲存已修改的簡報。

此 PHP 程式碼示範如何設定段落縮排：

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
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

### **設定懸掛縮排**

懸掛縮排是一種段落版面配置，第一行位於其餘行的左側。在 Aspose.Slides 中，可透過 `[ParagraphFormat::setIndent](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setIndent-float-)` 並傳入負值，使第一行相對於段落本體向左移動。

實務上，`[ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-)` 定義段落本體的左側位置，而 `[ParagraphFormat::setIndent](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setIndent-float-)` 定義第一行相對於該左側的位移。要建立懸掛縮排，請對 `setMarginLeft` 使用正值，對 `setIndent` 使用負值。

此格式常用於書目、參考文獻、詞彙表條目等，需要讓換行後的文字與段落本體左邊對齊，而非與首行第一個字元對齊的情況。

1. 建立 `[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/)` 類別的實例。
2. 取得目標投影片。
3. 在投影片上新增一個矩形 `[AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)`。
4. 取得圖形的 `[TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)`，並移除預設段落。
5. 為每個段落傳入正值至 `[ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-)`。
6. 傳入負值至 `[ParagraphFormat::setIndent](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setIndent-float-)` 以產生懸掛縮排效果。
7. 將段落加入文字框。
8. 儲存已修改的簡報。

此 PHP 程式碼示範如何為段落設定懸掛縮排：

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
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

### **設定段落結束標記屬性**

`[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-)` 控制段落結束標記的格式設定。以下 PHP 範例為第二段落的結束標記指定字型大小與 Latin 字型：

1. 載入 `[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/)`，並取得投影片。
2. 新增 `[AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)`，並清除其預設段落。
3. 建立兩個段落，並為它們加入文字段。
4. 為第二段落的結束標記建立 `[PortionFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portionformat/)`。
5. 設定 `[BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setFontHeight-float-)` 與 `[BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-)`。
6. 以 `[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-)` 套用格式，並儲存簡報。

```php
use aspose\slides\FontData;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->getPortions()->add(new Portion("Sample text"));

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion("Sample text 2"));

    $endParagraphFormat = new PortionFormat();
    $endParagraphFormat->setFontHeight(48);
    $endParagraphFormat->setLatinFont(new FontData("Times New Roman"));
    $secondParagraph->setEndParagraphPortionFormat($endParagraphFormat);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("end_paragraph_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **計算已渲染的行數**

使用 `[Paragraph::getLinesCount](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/#getLinesCount--)` 取得段落在文字排版後所佔的行數（包括自動換行）。此功能在檢查投影片範本中文本長度與版面配置時相當有用。

段落是 `[TextFrame::getParagraphs](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/#getParagraphs--)` 中的一個項目，可能佔用多行已渲染的文字。段落內的顯式換行會產生新行，但不會產生新段落。自動換行則根據可用寬度產生行，而不會在文字中插入顯式換行字元。因此，僅計算段落或換行字元無法得到實際的已渲染行數。

以下範例會建立文字圖形、計算其行數、縮窄圖形，然後以較短的字串取代文字。範例啟用換行且停用自動調整大小，以讓圖形寬度控制換行，而不會自動縮小文字或調整圖形尺寸。圖形尺寸單位為點。最後，範例會再加入一個段落，並將整個文字框的行數加總。

```php
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    echo "Original width: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $shape->setWidth(150);
    echo "Narrower shape: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $paragraph->setText("Short text.");
    echo "Shorter text: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Another paragraph.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
    $textFrame->getParagraphs()->add($secondParagraph);

    $totalLineCount = 0;
    for ($i = 0; $i < java_values($textFrame->getParagraphs()->getCount()); $i++) {
        $currentParagraph = $textFrame->getParagraphs()->get_Item($i);
        $totalLineCount += java_values($currentParagraph->getLinesCount());
    }
    echo "Total lines in the text frame: " . $totalLineCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

使用此文字與這些尺寸時，縮窄圖形會增加行數，取代為短字串則會減少行數。實際行數會因字型可用性與替代、字型大小、邊距、縮排、換行與自動調整設定等因素而異；請在檢查範本時使用目標環境的字型與版面設定。

僅憑行數無法判斷文字是否超出容器。可用高度、行高、段落與行間距，以及自動調整行為同樣重要；即使只有單行，若未啟用換行，也可能超出可用寬度。

## **匯入與匯出段落內容**

### **將 HTML 文字匯入段落**

使用 `[ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-)` 可將 HTML 標記轉換為文字框內的段落與文字段。

1. 建立 `[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/)` 類別的實例。
2. 取得投影片，並新增一個 `[AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)`。
3. 取得圖形的 `[TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)`，並清除預設段落。
4. 讀取來源 HTML 檔案。
5. 將 HTML 字串傳入 `[ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-)`。
6. 儲存已修改的簡報。

此 PHP 範例會將 HTML 匯入文字框：

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeWidth = java_values($presentation->getSlideSize()->getSize()->getWidth()) - 20;
    $shapeHeight = java_values($presentation->getSlideSize()->getSize()->getHeight()) - 20;
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $shapeWidth, $shapeHeight);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->getParagraphs()->clear();

    $html = file_get_contents("file.html");
    if ($html !== false) {
        $shape->getTextFrame()->getParagraphs()->addFromHtml($html);
        $presentation->save("html_text.pptx", SaveFormat::Pptx);
    } else {
        echo "The HTML file could not be read.";
    }
} finally {
    $presentation->dispose();
}
```

### **將段落文字匯出為 HTML**

使用 `[ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-)` 可將選取的段落範圍匯出為 HTML。

1. 建立 `[Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/)` 類別的實例，並載入目標簡報。
2. 取得投影片，並找到包含文字的 `[AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)`。
3. 取得圖形的 `[TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)`。
4. 呼叫 `[ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-)`，傳入起始段落索引與欲匯出的段落數量。
5. 將回傳的 HTML 字串寫入檔案。

此 PHP 範例會匯出第一個文字圖形的所有段落：

```php
use aspose\slides\Presentation;

$presentation = new Presentation("ExportingHTMLText.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame)) {
            $paragraphs = $textFrame->getParagraphs();
            $html = $paragraphs->exportToHtml(0, $paragraphs->getCount(), null);
            if (file_put_contents("paragraphs.html", $html) === false) {
                echo "The HTML file could not be written.";
            }
        } else {
            echo "The first shape does not contain a text frame.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

### **將段落渲染為圖像**

`[Paragraph::getImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/#getImage--)` 可直接渲染單一段落，並回傳一個 `[IImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/iimage/)`。使用 `[IImage::save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/iimage/#save-java.lang.String-int-)` 將結果儲存為檔案或串流。您不需要渲染整個圖形或手動裁切位圖。

如果段落無法在其父集合中找到、沒有有效的渲染邊界，或無法渲染，`[Paragraph::getImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/#getImage--)` 會傳回 `null`。在儲存之前請先檢查結果，並在使用完畢後釋放圖像。

#### **以預設比例渲染段落**

假設我們有一個名為 `sample.pptx` 的簡報檔案，內含一張投影片，第一個圖形是一個包含三個段落的文字方塊。

![包含三個段落的文字方塊](paragraph_to_image_input.png)

以下 PHP 範例會在預設比例下渲染第二個段落，並以 PNG 格式儲存回傳的圖像。`finally` 區塊確保圖像會正確釋放。

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame) && java_values($textFrame->getParagraphs()->getCount()) > 1) {
            $paragraph = $textFrame->getParagraphs()->get_Item(1);
            $paragraphImage = $paragraph->getImage();

            if (!java_is_null($paragraphImage)) {
                try {
                    $paragraphImage->save("paragraph.png", ImageFormat::Png);
                } finally {
                    $paragraphImage->dispose();
                }
            } else {
                echo "The paragraph could not be rendered.";
            }
        } else {
            echo "The expected paragraph was not found.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

結果：

![段落圖像](paragraph_to_image_output.png)

#### **在表格儲存格中以比例渲染段落**

使用接受 `$scaleX` 與 `$scaleY` 參數的 `[Paragraph::getImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/#getImage-float-float-)` 版本，以設定水平與垂直的縮放係數。以下 PHP 範例會建立一個表格，並在第一個儲存格中以兩倍寬高渲染段落，最後以 PNG 圖像儲存結果。

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->addTable(50, 50, array(300), array(80));
    $paragraph = $table->get_Item(0, 0)->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->setText("Text in a table cell");

    $paragraphImage = $paragraph->getImage($scaleX, $scaleY);
    if (!java_is_null($paragraphImage)) {
        try {
            $paragraphImage->save("table_paragraph.png", ImageFormat::Png);
        } finally {
            $paragraphImage->dispose();
        }
    } else {
        echo "The paragraph could not be rendered.";
    }
} finally {
    $presentation->dispose();
}
```

縮放係數 `1` 代表該軸保持預設像素大小。例如，兩個係數皆為 `2` 時，圖像的寬度與高度約為預設的兩倍，像素數量約為四倍。較大的係數通常可為縮放或高解析度輸出提供較銳利的文字，但也會增加記憶體使用與檔案大小。係數低於 `1` 會產生較小且細節較少的圖像。使用相同係數可保留段落的長寬比；不同的水平與垂直係數則會分別拉伸輸出。

在需要包含圖形填充、邊框或其他視覺上下文時，使用 `[Shape::getImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/#getImage--)` 渲染整個圖形仍然有其價值。若只需段落圖像，請使用 `[Paragraph::getImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/#getImage--)`。

## **常見問題集**

**我可以完全關閉文字框內的自動換行嗎？**

可以。將 `[TextFrameFormat::setWrapText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/#setWrapText-byte-)` 設為關閉，即可停用換行，使行不會在文字框邊緣斷行。

**如何取得特定段落在投影片上的精確邊界？**

使用 `[Paragraph::getRect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/#getRect--)` 取得段落的外框矩形。`[Portion::getRect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/#getRect--)` 則提供單一文字段的邊界。

**段落對齊方式（左、右、置中或兩端對齊）在哪裡控制？**

`[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setAlignment-int-)` 為段落層級設定，會套用於整個段落，與個別文字段的格式無關。

**我可以為段落的部分文字設定校對語言嗎？**

可以。使用 `[BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)` 為個別文字段設定，即可在同一段落中混合多種語言。