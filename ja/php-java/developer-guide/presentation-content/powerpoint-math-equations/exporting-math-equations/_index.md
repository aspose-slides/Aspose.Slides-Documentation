---
title: PHP でプレゼンテーションから数式をエクスポート
linktitle: 数式のエクスポート
type: docs
weight: 30
url: /ja/php-java/exporting-math-equations/
keywords:
- 数式のエクスポート
- LaTeX への数式エクスポート
- PowerPoint から LaTeX へ
- MathML
- LaTeX
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint プレゼンテーションから数式を直接 LaTeX または MathML にエクスポートします。"
---
## **はじめに**

Aspose.Slides for PHP via Java は、プレゼンテーションから数式をエクスポートできます。たとえば、特定のプレゼンテーションのスライド上の数式を抽出し、別のプログラムやプラットフォームで使用する必要がある場合があります。

{{% alert color="primary" %}} 
数式は LaTeX または MathML に直接エクスポートできます。MathML は Web や多くのアプリケーションで使用される、数学コンテンツの一般的な標準です。
{{% /alert %}}

## **数式を LaTeX にエクスポートする**

Aspose.Slides は、PowerPoint の数式を直接 LaTeX に変換できます。中間の MathML ファイルや外部コンバータは不要です。数式はテキストフレーム内に [MathPortion](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathportion/) として格納されています。[MathPortion::getMathParagraph](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathportion/#getMathParagraph) を使用して [MathParagraph](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathparagraph/) を取得し、次に [MathParagraph::toLatex](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathparagraph/#toLatex) を呼び出します。このメソッドは文字列を返し、保存、表示、別のアプリケーションへの送信、またはさらに処理することができます。

次のサンプルは、すべてのスライドのすべてのテキストフレームを調べ、すべての MathPortion を検出し、各数式を個別の `.tex` ファイルに書き込むものです:

```php
$presentation = new Presentation("equations.pptx");
$arrayClass = new JavaClass("java.lang.reflect.Array");
$mathPortionClass = new JavaClass("com.aspose.slides.MathPortion");

try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = $slideIndex + 1;
        $equationNumber = 1;
        $textFrames = SlideUtil::getAllTextBoxes($slide);
        $textFrameCount = java_values($arrayClass->getLength($textFrames));

        for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
            $textFrame = $textFrames[$textFrameIndex];
            $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
            for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                $portionCount = java_values($paragraph->getPortions()->getCount());
                for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    if (!java_instanceof($portion, $mathPortionClass)) {
                        continue;
                    }

                    $mathParagraph = $portion->getMathParagraph();
                    $latexFileName = "slide_" . $slideNumber . "_equation_" . $equationNumber . ".tex";

                    $latexText = java_values($mathParagraph->toLatex());
                    file_put_contents($latexFileName, $latexText);
                    $equationNumber++;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

[SlideUtil::getAllTextBoxes](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideutil/#getAllTextBoxes) はスライド上で見つかったすべてのテキストフレームを返します。[MathPortion](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathportion/) の型チェックにより、通常のテキストや画像と区別して、実際に編集可能な数式を識別できます。

LaTeX エンジンやドキュメントテンプレートはすべて同じコマンド、パッケージ、Unicode 文字をサポートしているわけではありません。返された文字列を、アプリケーションで使用している LaTeX エンジンでテストしてください。シンボルや Office Math 要素がその環境で適切に表現できない場合は、返された文字列中でプロジェクト固有のコマンドに置き換えるか、数式をスキップし、問題として記録してください。

## **数式を MathML として保存する**

人間は LaTeX のような一部の数式フォーマットのコードは容易に書けますが、MathML のコードは書くのが困難です。というのも、MathML はアプリケーションによって自動生成されることを前提としているからです。MathML のコードは XML 形式なので、プログラムは容易に読み取り・解析できます。そのため、MathML は多くの分野で出力や印刷フォーマットとして一般的に使用されています。

このサンプルコードは、プレゼンテーションから数式を MathML にエクスポートする方法を示しています:
```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 500, 50);
    $mathParagraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();
    $mathParagraph->add(new MathematicalText("a")->setSuperscript("2")->join("+")->join(new MathematicalText("b")->setSuperscript("2"))->join("=")->join(new MathematicalText("c")->setSuperscript("2")));
    $stream = new Java("java.io.FileOutputStream", "mathml.xml");
    $mathParagraph->writeAsMathMl($stream);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**MathML にエクスポートされるのは、段落全体ですか、それとも個々の数式ブロックですか？**

MathML へのエクスポートは、全体の数式段落（[MathParagraph](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathparagraph/)）または個々のブロック（[MathBlock](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathblock/)）のいずれかを行うことができます。両方のタイプには MathML に書き出すメソッドが用意されています。

**スライド上のオブジェクトが通常のテキストや画像ではなく数式であることは、どうやって判別できますか？**

数式は [MathPortion](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathportion/) に格納され、[MathParagraph](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathparagraph/) を持ちます。[MathParagraph] を持たない画像や通常のテキスト部分は、エクスポート可能な数式ではありません。

**プレゼンテーション内の MathML はどこから来るのですか—PowerPoint 固有のものですか、それとも標準ですか？**

エクスポートは標準の MathML（XML）を対象とします。Aspose は Presentation MathML、すなわち標準のプレゼンテーションサブセットを使用しており、これは多くのアプリケーションや Web で広く利用されています。

**テーブル、SmartArt、グループなど内部の数式のエクスポートはサポートされていますか？**

はい、これらのオブジェクトが [MathParagraph](https://reference.aspose.com/slides/ja/php-java/aspose.slides/mathparagraph/) を含むテキスト部分（すなわち実際の PowerPoint 数式）を持っていればエクスポートされます。数式が画像として埋め込まれている場合はエクスポートされません。

**MathML へのエクスポートは元のプレゼンテーションを変更しますか？**

いいえ。MathML の書き出しは数式内容のシリアライズであり、プレゼンテーション ファイルを変更することはありません。