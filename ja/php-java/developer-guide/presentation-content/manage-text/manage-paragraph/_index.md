---
title: PHPでPowerPointのテキスト段落を管理
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
- HTML のインポート
- テキストから HTML へ
- 段落から HTML へ
- 段落から画像へ
- テキストから画像へ
- 段落のエクスポート
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、段落、ポーション、箇条書き、番号付きリスト、インデント、HTML コンテンツ、段落画像の作成と書式設定方法を学びます。"
---
## **概要**

Aspose.Slides for PHP via Java は、テキストをテキストフレーム、段落、ポーションの階層で表します:

* *[TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/)* は、シェイプ内のテキスト コンテナを表し、その段落コレクションへのアクセスを提供します。
* *[Paragraph](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/)* は、テキストフレーム内の 1 つの段落を表し、ポーションと段落レベルの書式設定へのアクセスを提供します。
* *[Portion](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portion/)* は、段落内のテキスト ランを表します。各ポーションは独自のテキストと文字レベルの書式設定を持つことができます。

したがって、段落は複数のポーションを使用することで、フォント、色、サイズ、その他の書式が異なるテキストを含めることができます。

## **段落の作成と書式設定**

### **複数のポーションを持つ段落の作成**

次の手順は、3 つの段落を持ち、各段落に 3 つのポーションを含むテキストフレームを作成します:

1. *[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/)* クラスのインスタンスを作成します。
2. インデックスを使用して対象のスライドにアクセスします。
3. スライドに長方形の *[AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/)* を追加します。
4. シェイプの *[TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/)* にアクセスします。
5. デフォルトの段落を使用し、テキストフレームにさらに 2 つの *[Paragraph](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/)* オブジェクトを追加します。
6. 各段落に 3 つのポーションを含めるために十分な数の *[Portion](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portion/)* オブジェクトを追加します。デフォルトの段落にはすでに空のポーションが 1 つ含まれています。
7. 各ポーションのテキストを設定します。
8. *[Portion::getPortionFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portion/#getPortionFormat--)* を使用して文字レベルの書式設定を適用します。
9. 変更されたプレゼンテーションを保存します。

この PHP の例は手順を実装しています:

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

箇条書きと番号付けは、関連項目を見やすくします。Aspose.Slides では、リスト設定は *[BulletFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bulletformat/)* を介して定義されます。

1. *[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/)* クラスのインスタンスを作成します。
2. インデックスを使用して対象のスライドにアクセスします。
3. 選択したスライドに *[AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/)* を追加します。
4. シェイプの *[TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/)* にアクセスします。
5. テキストフレームからデフォルトの段落を削除します。
6. シンボル箇条書き用に *[Paragraph](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/)* を作成します。
7. *[BulletFormat::setType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bulletformat/#setType-int-)* を *[BulletType::Symbol](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bullettype/)* に設定し、箇条書き文字を指定します。
8. 段落テキスト、インデント、箇条書きの色、箇条書きの高さを設定します。
9. 段落をテキストフレームに追加します。
10. 2 番目の段落を作成し、*[BulletFormat::setType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bulletformat/#setType-int-)* を *[BulletType::Numbered](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bullettype/)* に設定します。
11. 番号付き箇条書きのスタイルを構成し、段落をテキストフレームに追加します。
12. プレゼンテーションを保存します。

この PHP の例はシンボル箇条書きと番号付き箇条書きを作成します:

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

画像箇条書きでは、シンボルや番号の代わりにカスタム画像を使用できます。

1. *[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/)* クラスのインスタンスを作成します。
2. インデックスを使用して対象のスライドにアクセスします。
3. *[AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/)* を追加し、その *[TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/)* にアクセスします。
4. テキストフレームからデフォルトの段落を削除します。
5. 箇条書き画像を読み込み、*([PPImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/ppimage/))* としてプレゼンテーションの画像コレクションに追加します。
6. *[Paragraph](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/)* を作成し、テキストを設定します。
7. *[BulletFormat::setType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bulletformat/#setType-int-)* を *[BulletType::Picture](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bullettype/)* に設定します。
8. *[BulletFormat::getPicture](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bulletformat/#getPicture--)* で画像を割り当て、箇条書きの高さを設定します。
9. 段落をテキストフレームに追加します。
10. 変更されたプレゼンテーションを保存します。

この PHP の例は画像箇条書きを作成します:

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

*[ParagraphFormat::setDepth](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setDepth-short-)* を設定して、段落をリストの異なるレベルに配置します。最上位レベルの深さは `0` です。

1. *[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/)* を作成し、スライドにアクセスします。
2. *[AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/)* を追加し、テキストフレームからデフォルトの段落をクリアします。
3. 4 つの段落を作成し、箇条書きシンボルを構成します。
4. 各段落の *[ParagraphFormat::setDepth](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setDepth-short-)* 値をそれぞれ `0`、`1`、`2`、`3` に設定します。
5. 段落をテキストフレームに追加し、プレゼンテーションを保存します。

この PHP の例は 4 段階の箇条書きリストを作成します:

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

*[BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-)* を使用して、番号付き段落の最初に表示される番号を設定します。

1. *[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/)* を作成し、スライドに *[AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/)* を追加します。
2. シェイプのテキストフレームからデフォルトの段落をクリアします。
3. 3 つの番号付き段落を作成します。
4. 各段落に対して *[BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/ja/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-)* をそれぞれ `2`、`3`、`7` に設定します。
5. 段落をテキストフレームに追加し、プレゼンテーションを保存します。

この PHP の例は各段落にカスタム開始番号を割り当てます:

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

### **先頭行インデントの設定**

*[ParagraphFormat::setIndent](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setIndent-float-)* を使用して段落の先頭行インデントを制御します。このメソッドは段落の左余白に対して最初の行だけを移動させます。正の値は先頭行を右にシフトし、残りの行は段落本文に揃ったままです。

全体の段落を移動したい場合は *[ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-)* を使用し、先頭行のみを移動したい場合は *[ParagraphFormat::setIndent](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setIndent-float-)* を使用します。

以下の例は複数の段落を作成し、異なる *[ParagraphFormat::setIndent](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setIndent-float-)* 値を適用して、先頭行インデントが段落レイアウトに与える影響を示しています。

1. *[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/)* のインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに長方形の *[AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/)* を追加します。
4. シェイプの *[TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/)* にアクセスし、デフォルトの段落を削除します。
5. 複数の段落を作成し、各段落に異なる *[ParagraphFormat::setIndent](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setIndent-float-)* 値を設定します。
6. 段落をテキストフレームに追加します。
7. 変更されたプレゼンテーションを保存します。

この PHP のコードは段落インデントの設定方法を示します:

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

結果:

![The first-line indent of the paragraphs](first_line_indent.png)

### **ハンギングインデントの設定**

ハンギングインデントは、最初の行が残りの行より左に開始する段落レイアウトです。Aspose.Slides では *[ParagraphFormat::setIndent](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setIndent-float-)* に負の値を渡すことで、この効果を実現します。

実際には、*[ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-)* が段落本文の左位置を定義し、*[ParagraphFormat::setIndent](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setIndent-float-)* がその余白に対する最初の行の位置を定義します。ハンギングインデントを作成するには、`setMarginLeft` に正の値、`setIndent` に負の値を渡します。

この書式設定は、文献リスト、参照、用語集エントリ、行が段落本文の下に揃う必要があるその他の段落で役立ちます。

1. *[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/)* のインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに長方形の *[AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/)* を追加します。
4. シェイプの *[TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/)* にアクセスし、デフォルトの段落を削除します。
5. 各段落に対して *[ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-)* に正の値を設定します。
6. *[ParagraphFormat::setIndent](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setIndent-float-)* に負の値を渡してハンギングインデント効果を作成します。
7. 段落をテキストフレームに追加します。
8. 変更されたプレゼンテーションを保存します。

この PHP のコードは段落にハンギングインデントを設定する方法を示します:

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

結果:

![The hanging indent of the paragraphs](hanging_indent.png)

### **段落末端の実行プロパティの設定**

*[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-)* は段落末尾マークの書式を制御します。以下の PHP の例は、2 番目の段落末尾マークにフォントサイズとラテンフォントを割り当てます:

1. *[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/)* をロードし、スライドにアクセスします。
2. *[AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/)* を追加し、デフォルトの段落をクリアします。
3. 2 つの段落を作成し、テキスト ポーションを追加します。
4. 2 番目の段落末尾マーク用に *[PortionFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portionformat/)* を作成します。
5. *[BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/#setFontHeight-float-)* と *[BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-)* を設定します。
6. *[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-)* で書式を割り当て、プレゼンテーションを保存します。

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

## **レンダリングされた行数の取得**

*[Paragraph::getLinesCount](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/#getLinesCount--)* を使用して、テキストレイアウト後に段落が占める行数（自動折り返しを含む）を取得します。これは、プレゼンテーションテンプレートでテキスト長とレイアウトをチェックする際に便利です。

段落は *[TextFrame::getParagraphs](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/#getParagraphs--)* の項目の 1 つで、複数のレンダリング行を占めることがあります。段落内の明示的な改行は新しい行を強制しますが、別の段落は作成しません。自動折り返しは利用可能な幅に基づいて行を生成し、テキストに明示的な改行文字は挿入しません。そのため、段落数や改行文字数をカウントしても実際のレンダリング行数は得られません。

以下の例はテキスト シェイプを作成し、行数を取得し、シェイプを狭めてからテキストを短い文字列に置き換えます。折り返しが有効で自動調整が無効のため、シェイプ幅が折り返しを制御し、テキストやシェイプの自動縮小は行われません。シェイプの寸法はポイント単位です。最後に、別の段落を追加し、テキストフレーム全体の行数を合計します。

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

このテキストと寸法では、シェイプを狭めると行数が増加し、短い文字列に置き換えると行数が減少します。正確なカウントはフォントの可用性と代替、フォントサイズ、余白、インデント、折り返し、そして自動調整設定により変わります。テンプレートをチェックする際は、ターゲット環境で使用するフォントとレイアウト設定を使用してください。

行数だけではテキストがコンテナをはみ出すかどうかは判断できません。利用可能な高さ、行の高さ、段落と行間、そして自動調整の動作も重要です。折り返しが無効の場合、1 行だけでも幅を超えることがあります。

## **段落コンテンツのインポートとエクスポート**

### **HTML テキストを段落にインポート**

*[ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-)* を使用して、HTML マークアップをテキストフレーム内の段落とポーションに変換します。

1. *[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/)* クラスのインスタンスを作成します。
2. スライドに *[AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/)* を追加します。
3. シェイプの *[TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/)* にアクセスし、デフォルトの段落をクリアします。
4. ソース HTML ファイルを読み込みます。
5. HTML 文字列を *[ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-)* に渡します。
6. 変更されたプレゼンテーションを保存します。

この PHP の例は HTML をテキストフレームにインポートします:

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

*[ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-)* を使用して、選択した段落範囲を HTML としてエクスポートします。

1. *[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/)* のインスタンスを作成し、目的のプレゼンテーションをロードします。
2. スライドにアクセスし、テキストを含む *[AutoShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/autoshape/)* を検索します。
3. シェイプの *[TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/)* にアクセスします。
4. 開始段落インデックスとエクスポートする段落数を指定して *[ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-)* を呼び出します。
5. 返された HTML 文字列をファイルに書き込みます。

この PHP の例は最初のテキストシェイプからすべての段落をエクスポートします:

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

*[Paragraph::getImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/#getImage--)* は個々の段落を直接レンダリングし、*[IImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/iimage/)* を返します。結果は *[IImage::save](https://reference.aspose.com/slides/ja/php-java/aspose.slides/iimage/#save-java.lang.String-int-)* でファイルまたはストリームに保存できます。親シェイプ全体をレンダリングしたり、ビットマップを手動でトリミングする必要はありません。

段落が親コレクションに存在しない、レンダリング境界が有効でない、またはレンダリングできない場合、*[Paragraph::getImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/#getImage--)* は `null` を返すことがあります。保存する前に結果を確認し、使用後は返された画像を破棄してください。

#### **デフォルトスケールで段落をレンダリング**

例として、`sample.pptx` というプレゼンテーション ファイルに 1 つのスライドがあり、最初のシェイプが 3 段落を含むテキスト ボックスであるとします。

![The text box with three paragraphs](paragraph_to_image_input.png)

以下の PHP の例は、2 番目の段落を通常のテキストシェイプでデフォルトスケールでレンダリングし、PNG 形式で返された画像を保存します。`finally` ブロックは画像が正しく破棄されることを保証します。

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

結果:

![The paragraph image](paragraph_to_image_output.png)

#### **テーブル セル内の段落をスケーリングしてレンダリング**

`$scaleX` と `$scaleY` パラメータを受け取る *[Paragraph::getImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/#getImage-float-float-)* のオーバーロードを使用して、水平および垂直のスケール係数を設定します。以下の PHP の例はテーブルを作成し、最初のセル内の段落をデフォルト幅と高さの 2 倍でレンダリングし、PNG 画像として保存します。

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

係数 `1` はその軸をデフォルトのピクセルサイズのままにします。たとえば、両方の係数を `2` にすると、幅と高さが約 2 倍になり、ピクセル数は 4 倍になります。大きな係数はズームや高解像度出力でテキストをより鮮明にしますが、メモリ使用量とファイル サイズも増加します。`1` 未満の係数は詳細が少ない小さな画像を生成します。段落のアスペクト比を保つには同じ係数を使用し、水平と垂直で異なる係数を使用すると出力が個別に伸びます。

シェイプ全体を *[Shape::getImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/#getImage--)* でレンダリングするのは、シェイプの塗りつぶし、枠線、その他の視覚的コンテキストを含める必要がある場合に依然有用です。段落のみの画像が必要な場合は *[Paragraph::getImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/#getImage--)* を使用してください。

## **FAQ**

**テキストフレーム内で改行を完全に無効にできますか？**

はい。*[TextFrameFormat::setWrapText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframeformat/#setWrapText-byte-)* を設定してラップを無効にすると、行はテキストフレームの端で改行しません。

**特定の段落のスライド上での正確な境界を取得するにはどうすればよいですか？**

*[Paragraph::getRect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraph/#getRect--)* を使用して段落のバウンディング矩形を取得します。*[Portion::getRect](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portion/#getRect--)* は個々のポーションの境界を提供します。

**段落の配置（左揃え、右揃え、中央揃え、両端揃え）はどこで制御されますか？**

*[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/ja/php-java/aspose.slides/paragraphformat/#setAlignment-int-)* は段落レベルの設定であり、個々のポーションの書式設定に関係なく段落全体に適用されます。

**段落の一部に校正言語を設定できますか？**

はい。個々のポーションに対して *[BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)* を設定すれば、1 つの段落内に複数の言語のテキストを含めることができます。