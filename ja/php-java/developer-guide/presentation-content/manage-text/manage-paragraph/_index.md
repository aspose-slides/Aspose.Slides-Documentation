---
title: PHPでPowerPointのテキスト段落を管理する
linktitle: 段落の管理
type: docs
weight: 40
url: /ja/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
  - /php-java/portion/
keywords:
- テキストを追加
- 段落を追加
- テキストを管理
- 段落を管理
- 箇条書きを管理
- 段落インデント
- ハンギングインデント
- 段落の箇条書き
- 番号付きリスト
- 箇条書きリスト
- 段落プロパティ
- HTMLをインポート
- テキストをHTMLに変換
- 段落をHTMLに変換
- 段落を画像に変換
- テキストを画像に変換
- 段落をエクスポート
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、段落、ポーション、箇条書き、番号付きリスト、インデント、HTML コンテンツ、段落画像の作成と書式設定方法を学びます。"
---
## **概要**

Aspose.Slides for PHP via Java はテキストをテキストフレーム、段落、ポーションの階層として表現します。

* [TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) はシェイプ内のテキストコンテナを表し、段落コレクションへのアクセスを提供します。
* [Paragraph](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/) はテキストフレーム内の 1 つの段落を表し、ポーションと段落レベルの書式設定へのアクセスを提供します。
* [Portion](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portion/) は段落内のテキストランを表します。各ポーションは独自のテキストと文字レベルの書式設定を持つことができます。

このように段落は複数のポーションを使用することで、フォント、色、サイズ、その他の書式が異なるテキストを含めることができます。

## **段落の作成と書式設定**

### **複数ポーションを持つ段落の作成**

次の手順で 3 つの段落を持ち、各段落に 3 つのポーションを含むテキストフレームを作成します。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスで対象のスライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) を追加します。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) にアクセスします。
5. デフォルトの段落を使用し、テキストフレームにさらに 2 つの [Paragraph](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/) オブジェクトを追加します。
6. 各段落に 3 つのポーションが含まれるように十分な [Portion](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portion/) オブジェクトを追加します。デフォルトの段落にはすでに空のポーションが 1 つ含まれています。
7. 各ポーションのテキストを設定します。
8. [Portion::getPortionFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portion/#getPortionFormat--) を使って文字レベルの書式設定を適用します。
9. 変更したプレゼンテーションを保存します。

この PHP の例が手順を実装しています：

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

## **箇条書きと番号付きリストの作成**

### **箇条書きまたは番号付きリストの作成**

箇条書きと番号付けは関連項目の視認性を高めます。Aspose.Slides ではリスト設定は [BulletFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bulletformat/) で定義します。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスで対象のスライドにアクセスします。
3. 選択したスライドに [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) を追加します。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) にアクセスします。
5. テキストフレームからデフォルトの段落を削除します。
6. 記号箇条書き用の [Paragraph](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/) を作成します。
7. [BulletFormat::setType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bulletformat/#setType-int-) を [BulletType::Symbol](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bullettype/) に設定し、箇条書き文字を指定します。
8. 段落テキスト、インデント、箇条書きの色、箇条書きの高さを設定します。
9. 段落をテキストフレームに追加します。
10. 2 番目の段落を作成し、[BulletFormat::setType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bulletformat/#setType-int-) を [BulletType::Numbered](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bullettype/) に設定します。
11. 番号付き箇条書きのスタイルを構成し、段落をテキストフレームに追加します。
12. プレゼンテーションを保存します。

この PHP の例が記号箇条書きと番号付き箇条書きを作成します：

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

### **画像箇条書きの使用**

画像箇条書きは記号や数字の代わりにカスタム画像を使用できます。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. インデックスで対象のスライドにアクセスします。
3. [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) を追加し、その [TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) にアクセスします。
4. テキストフレームからデフォルトの段落を削除します。
5. 箇条書き画像を読み込み、プレゼンテーションの画像コレクションに [PPImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ppimage/) として追加します。
6. [Paragraph](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/) を作成し、テキストを設定します。
7. [BulletFormat::setType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bulletformat/#setType-int-) を [BulletType::Picture](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bullettype/) に設定します。
8. [BulletFormat::getPicture](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bulletformat/#getPicture--) で画像を割り当て、箇条書きの高さを設定します。
9. 段落をテキストフレームに追加します。
10. 変更したプレゼンテーションを保存します。

この PHP の例が画像箇条書きを作成します：

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

### **多層リストの作成**

[ParagraphFormat::setDepth](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setDepth-short-) を設定して、リストの異なる階層に段落を配置します。最上位レベルの深さは `0` です。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) を作成し、スライドにアクセスします。
2. [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) を追加し、テキストフレームからデフォルトの段落をクリアします。
3. 4 つの段落を作成し、箇条書き記号を設定します。
4. それぞれの [ParagraphFormat::setDepth](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setDepth-short-) 値を `0`、`1`、`2`、`3` に設定します。
5. 段落をテキストフレームに追加し、プレゼンテーションを保存します。

この PHP の例が 4 レベルの箇条書きリストを作成します：

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

### **番号付きリスト項目の開始番号をカスタム値に設定**

[BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) を使用して、番号付き段落の開始番号を指定できます。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) を作成し、[AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) をスライドに追加します。
2. シェイプのテキストフレームからデフォルトの段落をクリアします。
3. 3 つの番号付き段落を作成します。
4. 各段落に対して [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) をそれぞれ `2`、`3`、`7` に設定します。
5. 段落をテキストフレームに追加し、プレゼンテーションを保存します。

この PHP の例が各段落にカスタム開始番号を割り当てます：

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

## **段落のレイアウトと終了プロパティの制御**

### **最初の行インデントを設定**

[ParagraphFormat::setIndent](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setIndent-float-) を使用して段落の最初の行インデントを制御します。このメソッドは段落の左余白に対して最初の行だけを移動させます。正の値は最初の行を右にシフトし、残りの行は段落本文に揃ったままです。

テキスト全体を左に移動させたい場合は [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) を使用し、最初の行だけを移動させたい場合は [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setIndent-float-) を使用します。

以下の例は複数の段落を作成し、異なる [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setIndent-float-) 値を適用して最初の行インデントが段落レイアウトに与える影響を示しています。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) を追加します。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) にアクセスし、デフォルトの段落を削除します。
5. 複数の段落を作成し、各段落に異なる [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setIndent-float-) 値を設定します。
6. 段落をテキストフレームに追加します。
7. 変更したプレゼンテーションを保存します。

この PHP コードは段落インデントの設定方法を示しています：

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

![段落の最初の行インデント](first_line_indent.png)

### **ハンギングインデントを設定**

ハンギングインデントは、最初の行が残りの行より左に開始する段落レイアウトです。Aspose.Slides では [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setIndent-float-) に負の値を渡すことで実現します。

実際には、[ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) が段落本文の左位置を決定し、[ParagraphFormat::setIndent](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setIndent-float-) がその余白に対する最初の行位置を決めます。ハンギングインデントを作成するには、`setMarginLeft` に正の値、`setIndent` に負の値を指定します。

この書式設定は、文献リストや用語集のエントリなど、折り返し行が段落本文の下に揃う必要がある場合に便利です。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) のインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) を追加します。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) にアクセスし、デフォルトの段落を削除します。
5. 各段落に対して、[ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) に正の値を設定します。
6. [ParagraphFormat::setIndent](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setIndent-float-) に負の値を渡してハンギングインデント効果を作り出します。
7. 段落をテキストフレームに追加します。
8. 変更したプレゼンテーションを保存します。

この PHP コードは段落にハンギングインデントを設定する方法を示しています：

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

![段落のハンギングインデント](hanging_indent.png)

### **段落終了記号の書式設定**

[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) は段落終了記号の書式を制御します。以下の PHP の例は、2 番目の段落の終了記号にフォントサイズとラテン文字フォントを割り当てます。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) を読み込み、スライドにアクセスします。
2. [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) を追加し、デフォルトの段落をクリアします。
3. 2 つの段落を作成し、テキストポーションを追加します。
4. 2 番目の段落の終了記号用に [PortionFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portionformat/) を作成します。
5. [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) と [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-) を設定します。
6. [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) で書式を割り当て、プレゼンテーションを保存します。

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

## **段落コンテンツのインポートとエクスポート**

### **HTML テキストを段落にインポート**

[ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) を使用して、HTML マークアップをテキストフレーム内の段落とポーションに変換します。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. スライドに [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) を追加します。
3. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) にアクセスし、デフォルトの段落をクリアします。
4. ソース HTML ファイルを読み取ります。
5. HTML 文字列を [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) に渡します。
6. 変更したプレゼンテーションを保存します。

この PHP の例は HTML をテキストフレームにインポートします：

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

### **段落テキストを HTML にエクスポート**

[ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) を使用して、選択した範囲の段落を HTML としてエクスポートします。

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) のインスタンスを作成し、目的のプレゼンテーションを読み込みます。
2. スライドにアクセスし、テキストを含む [AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/) を見つけます。
3. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) にアクセスします。
4. 開始段落インデックスとエクスポートする段落数を指定して、[ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) を呼び出します。
5. 返された HTML 文字列をファイルに書き込みます。

この PHP の例は最初のテキストシェイプからすべての段落をエクスポートします：

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

### **段落を画像としてレンダリング**

[Paragraph::getImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/#getImage--) は個々の段落を直接レンダリングし、[IImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/iimage/) を返します。結果は [IImage::save](https://reference.aspose.com/slides/ja/php-java/aspose.slides/iimage/#save-java.lang.String-int-) でファイルまたはストリームに保存できます。包含シェイプ全体をレンダリングしたり、ビットマップを手動で切り取る必要はありません。

[Paragraph::getImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/#getImage--) は、段落が親コレクションに存在しない、レンダリング境界が無効、またはレンダリングできない場合に `null` を返すことがあります。保存前に結果を確認し、使用後は画像を破棄してください。

#### **デフォルトスケールで段落をレンダリング**

1 つのスライドと、最初のシェイプが 3 つの段落を含むテキストボックスである `sample.pptx` があるとします。

![3 段落のテキストボックス](paragraph_to_image_input.png)

以下の PHP の例は、通常のテキストシェイプ内の 2 番目の段落をデフォルトスケールでレンダリングし、PNG 形式で画像を保存します。`finally` ブロックで画像を適切に破棄します。

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

![段落画像](paragraph_to_image_output.png)

#### **テーブルセル内の段落をスケーリングしてレンダリング**

`$scaleX` と `$scaleY` パラメータを受け取る [Paragraph::getImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/#getImage-float-float-) のオーバーロードを使用して、横方向と縦方向のスケール係数を設定します。以下の PHP の例はテーブルを作成し、最初のセルの段落をデフォルト幅・高さの 2 倍でレンダリングし、PNG 画像として保存します。

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

スケール係数 `1` はその軸をデフォルトピクセルサイズのままにします。たとえば、両方の係数を `2` にすると、幅と高さが約 2 倍になり、ピクセル数は 4 倍になります。大きな係数はズームや高解像度出力時にテキストをより鮮明にしますが、メモリ使用量とファイルサイズも増加します。`1` 未満の係数は詳細が減った小さな画像を生成します。アスペクト比を保つには係数を同じにし、異なる水平・垂直係数は出力を個別に伸縮させます。

シェイプ全体を画像化するには [Shape::getImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/#getImage--) が有用です。段落だけの画像が必要な場合は [Paragraph::getImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/#getImage--) を使用してください。

## **FAQ**

**テキストフレーム内で改行を完全に無効にできますか？**

はい。[TextFrameFormat::setWrapText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/#setWrapText-byte-) を設定してラッピングを無効にすれば、テキストフレームの端で行が折り返されません。

**特定の段落のスライド上での正確な境界を取得するにはどうすればよいですか？**

[Paragraph::getRect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/#getRect--) を使用して段落のバウンディング矩形を取得できます。[Portion::getRect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portion/#getRect--) は個々のポーションの境界を提供します。

**段落の配置（左揃え、右揃え、中央揃え、両端揃え）はどこで制御しますか？**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setAlignment-int-) は段落レベルの設定であり、個々のポーションの書式設定に関係なく段落全体に適用されます。

**段落の一部に校正言語を設定できますか？**

はい。個々のポーションに対して [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) を設定すれば、1 つの段落内に複数言語のテキストを含めることができます。