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
- 段落轉圖片
- 文字轉圖片
- 匯出段落
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 來建立與格式化段落、文字片段、項目符號、編號清單、縮排、HTML 內容以及段落圖片。"
---
## **概述**

Aspose.Slides for PHP via Java 將文字表示為文字框、段落與文字片段的層級結構：

* [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/) 代表形狀中的文字容器，並提供對其段落集合的訪問。
* [Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/) 代表文字框中的一個段落，並提供對其文字片段與段落層級格式設定的訪問。
* [Portion](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/) 代表段落中的一段文字。每個文字片段可以擁有自己的文字與字元層級格式設定。

因此，段落可以透過使用多個文字片段，包含字型、顏色、大小及其他格式不同的文字。

## **建立與格式化段落**

### **使用多個文字片段建立段落**

以下步驟會建立一個文字框，內含三個段落，每個段落包含三個文字片段：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 透過索引存取相關投影片。
3. 在投影片上加入矩形的 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
4. 取得形狀的 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)。
5. 使用預設段落，並向文字框中再加入兩個 [Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/) 物件。
6. 為每個段落加入足夠的 [Portion](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/) 物件以容納三個文字片段。預設段落已包含一個空的文字片段。
7. 設定每個文字片段的文字內容。
8. 透過 [Portion::getPortionFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/#getPortionFormat--) 套用字元層級的格式設定。
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

項目符號與編號可讓相關項目更易於掃視。在 Aspose.Slides 中，清單設定透過 [BulletFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bulletformat/) 定義。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 透過索引存取相關投影片。
3. 在選取的投影片上加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
4. 取得形狀的 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)。
5. 從文字框中移除預設段落。
6. 為符號項目符號建立一個 [Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/)。
7. 將 [BulletFormat::setType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bulletformat/#setType-int-) 設為 [BulletType::Symbol](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bullettype/)，並指定項目符號字元。
8. 設定段落文字、縮排、項目符號顏色與項目符號高度。
9. 將段落加入文字框。
10. 建立第二個段落，並將 [BulletFormat::setType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bulletformat/#setType-int-) 設為 [BulletType::Numbered](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bullettype/)。
11. 配置編號項目符號樣式，並將段落加入文字框。
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

圖片項目符號允許使用自訂影像取代符號或編號。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 透過索引存取相關投影片。
3. 加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/) 並取得其 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)。
4. 從文字框中移除預設段落。
5. 載入項目符號影像，並以 [PPImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/ppimage/) 加入簡報的影像集合。
6. 建立一個 [Paragraph](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/) 並設定其文字。
7. 將 [BulletFormat::setType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bulletformat/#setType-int-) 設為 [BulletType::Picture](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bullettype/)。
8. 透過 [BulletFormat::getPicture](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bulletformat/#getPicture--) 指派影像，並設定項目符號高度。
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

將 [ParagraphFormat::setDepth](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setDepth-short-) 設為不同值，可將段落放置於清單的不同層級。頂層的深度為 `0`。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 並存取投影片。
2. 加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/) 並清除其文字框中的預設段落。
3. 建立四個段落並設定其項目符號符號。
4. 將它們的 [ParagraphFormat::setDepth](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setDepth-short-) 設為 `0`、`1`、`2`、`3`。
5. 將段落加入文字框並儲存簡報。

此 PHP 範例會建立四層的項目符號清單：

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

### **自訂編號清單項目的起始值**

使用 [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) 可設定編號段落的起始號碼。

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/)，並在投影片上加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
2. 清除形狀文字框中的預設段落。
3. 建立三個編號段落。
4. 將 [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) 分別設為 `2`、`3`、`7`。
5. 將段落加入文字框並儲存簡報。

此 PHP 範例會為每個段落指派自訂的起始編號：

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

## **控制段落版面配置與結尾屬性**

### **設定首行縮排**

使用 [ParagraphFormat::setIndent](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setIndent-float-) 來控制段落的首行縮排。此方法僅移動第一行相對於段落左邊界的距離。正值會將第一行向右移動，而其餘行則保持與段落本體對齊。

當需要整段移動時，請使用 [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-)。僅需移動第一行時，請使用 [ParagraphFormat::setIndent](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setIndent-float-)。

以下範例建立多個段落，並對每個段落套用不同的 [ParagraphFormat::setIndent](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setIndent-float-) 值，以示範首行縮排如何影響段落版面。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 存取目標投影片。
3. 在投影片上加入矩形的 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
4. 取得形狀的 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/) 並移除預設段落。
5. 建立多個段落，並為它們設定不同的 [ParagraphFormat::setIndent](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setIndent-float-) 值。
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

懸掛縮排是指第一行相較於其餘行向左開始的段落版面配置。在 Aspose.Slides 中，可透過 [ParagraphFormat::setIndent](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setIndent-float-) 並傳入負值，將第一行向左移動。

實務上，[ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) 定義段落本體的左側位置，而 [ParagraphFormat::setIndent](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setIndent-float-) 定義第一行相對於該邊界的位置。若要產生懸掛縮排，請對 `setMarginLeft` 傳入正值，對 `setIndent` 傳入負值。

此格式化方式適用於參考文獻、書目、詞彙表條目等，需要讓換行後的文字對齊於段落本體而非第一行第一個字元的情況。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 存取目標投影片。
3. 在投影片上加入矩形的 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
4. 取得形狀的 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/) 並移除預設段落。
5. 為每個段落呼叫正值的 [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-)。
6. 使用負值呼叫 [ParagraphFormat::setIndent](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setIndent-float-)，產生懸掛縮排效果。
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

### **設定段落結尾執行屬性**

[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) 控制段落結尾標記的格式設定。以下 PHP 範例為第二段落的結尾標記指定字型大小與拉丁字型：

1. 載入一個 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 並存取投影片。
2. 加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/) 並清除其預設段落。
3. 建立兩個段落，並向其中加入文字片段。
4. 為第二段落的結尾標記建立一個 [PortionFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portionformat/)。
5. 設定 [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) 與 [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-)。
6. 使用 [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) 套用格式，並儲存簡報。

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

## **匯入與匯出段落內容**

### **將 HTML 文字匯入段落**

使用 [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) 可將 HTML 標記轉換為文字框中的段落與文字片段。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例。
2. 存取投影片並加入 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
3. 取得形狀的 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/) 並清除預設段落。
4. 讀取來源 HTML 檔案。
5. 將 HTML 字串傳入 [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-)。
6. 儲存已修改的簡報。

此 PHP 範例將 HTML 匯入文字框：

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

使用 [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) 可將選取的段落範圍匯出為 HTML。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別的實例並載入目標簡報。
2. 存取投影片，並找出包含文字的 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/autoshape/)。
3. 取得形狀的 [TextFrame](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframe/)。
4. 呼叫 [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) 並提供起始段落索引與要匯出的段落數量。
5. 將回傳的 HTML 字串寫入檔案。

此 PHP 範例會匯出第一個文字形狀中的所有段落：

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

### **將段落渲染為圖片**

[Paragraph::getImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/#getImage--) 可直接渲染單一段落，並回傳一個 [IImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/iimage/)。使用 [IImage::save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/iimage/#save-java.lang.String-int-) 可將結果儲存為檔案或串流。無需渲染整個形狀或手動裁切位圖。

如果段落無法在其父集合中找到、沒有有效的渲染邊界，或無法渲染，[Paragraph::getImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/#getImage--) 會回傳 `null`。在儲存之前請先檢查結果，使用完畢後務必釋放返回的影像。

#### **以預設比例渲染段落**

假設有一個名為 `sample.pptx` 的簡報檔，內含一張投影片，第一個形狀是一個文字方塊，裡面有三個段落。

![包含三個段落的文字方塊](paragraph_to_image_input.png)

以下 PHP 範例會在預設比例下，將第二個段落在一般文字形狀中渲染，並將返回的影像以 PNG 格式儲存。`finally` 區塊確保影像會正確釋放。

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

![段落圖片](paragraph_to_image_output.png)

#### **在表格儲存格中以縮放渲染段落**

使用接受 `$scaleX` 與 `$scaleY` 參數的 [Paragraph::getImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/#getImage-float-float-) 版本，可設定水平與垂直的縮放係數。以下 PHP 範例建立一個表格，並在第一個儲存格中以兩倍的寬度與高度渲染段落，最後將結果儲存為 PNG 影像。

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

縮放係數 `1` 代表該軸保持預設像素大小。例如，兩個係數皆為 `2` 時，產生的影像寬度與高度約為預設的兩倍，像素數量則為四倍。較大的係數通常會在縮放或高解析度輸出時產生較銳利的文字，但也會增加記憶體使用量與檔案大小。小於 `1` 的係數會產生較小且細節較少的影像。使用相同的係數可保留段落的長寬比；若水平與垂直係數不同，則會分別拉伸輸出。

在需要包含形狀填充、邊框或其他視覺上下文的輸出時，仍可使用 [Shape::getImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/#getImage--) 來渲染整個形狀。若只需段落圖像，請使用 [Paragraph::getImage](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/#getImage--)。

## **常見問題**

**我可以完全停用文字框內的換行嗎？**

是的。將 [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/textframeformat/#setWrapText-byte-) 設為停用，即可讓文字不在文字框邊緣斷行。

**如何取得特定段落在投影片上的精確邊界？**

使用 [Paragraph::getRect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraph/#getRect--) 取得段落的外框矩形。 [Portion::getRect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/portion/#getRect--) 則提供單一文字片段的邊界。

**段落對齊（左、右、置中或兩端對齊）是在何處設定的？**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/paragraphformat/#setAlignment-int-) 為段落層級的設定，會套用至整個段落，與單一文字片段的格式無關。

**我能為段落的一部分設定校對語言嗎？**

可以。對個別文字片段使用 [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)，即可讓同一段落包含多種語言的文字。