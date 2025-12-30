---
title: PHP でプレゼンテーションから数式をエクスポート
linktitle: 数式をエクスポート
type: docs
weight: 30
url: /ja/php-java/exporting-math-equations/
keywords:
- 数式をエクスポート
- MathML
- LaTeX
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint から MathML への数式エクスポートをシームレスに実現し、書式を保持し互換性を向上させます。"
---

## **プレゼンテーションから数式をエクスポート**

Aspose.Slides for PHP via Java は、プレゼンテーションから数式をエクスポートできます。たとえば、特定のプレゼンテーションのスライド上の数式を抽出し、別のプログラムやプラットフォームで使用する必要がある場合があります。

{{% alert color="primary" %}} 
数式を MathML にエクスポートできます。MathML は、ウェブや多くのアプリケーションで見られる数式や類似コンテンツのための一般的なフォーマットまたは標準です。 
{{% /alert %}}

LaTeX のような一部の数式フォーマットは、人間が容易にコードを書けますが、MathML のコードは書くのが難しいです。後者はアプリによって自動的に生成されることを想定しているためです。MathML はコードが XML 形式であるため、プログラムは容易に読み取り・解析できます。そのため、MathML は多くの分野で出力および印刷フォーマットとして一般的に使用されています。

このサンプルコードは、プレゼンテーションから数式を MathML にエクスポートする方法を示しています：
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


## **よくある質問**

**MathML にエクスポートされるのは、段落全体ですか、それとも個々の数式ブロックですか？**

MathML へは、全体の数式段落（[MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/)）または個々のブロック（[MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/)）のいずれかをエクスポートできます。どちらのタイプも MathML に書き出すためのメソッドを提供しています。

**スライド上のオブジェクトが通常のテキストや画像ではなく数式であるかどうかは、どのように判断できますか？**

数式は [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) に存在し、[MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) を持ちます。[MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) を持たない画像や通常のテキスト部分はエクスポート可能な数式ではありません。

**プレゼンテーション内の MathML はどこから来るのですか？PowerPoint 固有ですか、それとも標準ですか？**

エクスポートは標準の MathML（XML）を対象としています。Aspose は Presentation MathML、つまり標準のプレゼンテーションサブセットを使用しており、これはアプリケーションやウェブ全体で広く利用されています。

**テーブル、SmartArt、グループなど内部の数式のエクスポートはサポートされていますか？**

はい、これらのオブジェクトに [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) を含むテキスト部分（すなわち本物の PowerPoint 数式）がある場合はエクスポートされます。数式が画像として埋め込まれている場合はエクスポートされません。

**MathML へのエクスポートは元のプレゼンテーションを変更しますか？**

いいえ。MathML の書き出しは数式の内容をシリアライズするだけであり、プレゼンテーション ファイルは変更されません。