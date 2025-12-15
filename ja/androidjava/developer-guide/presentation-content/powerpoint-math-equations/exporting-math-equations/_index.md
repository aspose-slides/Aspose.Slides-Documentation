---
title: Android でプレゼンテーションから数式をエクスポート
linktitle: 数式のエクスポート
type: docs
weight: 30
url: /ja/androidjava/exporting-math-equations/
keywords:
- 数式のエクスポート
- MathML
- LaTeX
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint の数式を MathML にシームレスにエクスポートし、書式を保持し、互換性を向上させます。"
---

## **プレゼンテーションから数式をエクスポート**

Aspose.Slides for Android via Java を使用すると、プレゼンテーションから数式をエクスポートできます。たとえば、特定のプレゼンテーション内のスライドに含まれる数式を抽出し、別のプログラムやプラットフォームで使用する必要がある場合があります。

{{% alert color="primary" %}} 
数式や Web や多くのアプリケーションで見られる類似コンテンツのための一般的なフォーマットまたは標準である MathML にエクスポートできます。 
{{% /alert %}}

LaTeX のような一部の数式フォーマットのコードは人間が簡単に作成できますが、MathML のコードはアプリが自動生成することを前提としているため、作成が難しいです。MathML のコードは XML 形式なので、プログラムは容易に読み取り・解析でき、さまざまな分野で出力や印刷用フォーマットとして広く利用されています。

このサンプルコードは、プレゼンテーションから数式を MathML にエクスポートする方法を示しています。
```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    IMathParagraph mathParagraph = ((MathPortion)autoShape.getTextFrame().getParagraphs().get_Item(0).
            getPortions().get_Item(0)).getMathParagraph();

    mathParagraph.add(new MathematicalText("a").
            setSuperscript("2").
            join("+").
            join(new MathematicalText("b").setSuperscript("2")).
            join("=").
            join(new MathematicalText("c").setSuperscript("2")));

    FileOutputStream stream = new FileOutputStream("mathml.xml");
    mathParagraph.writeAsMathMl(stream);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **よくある質問**

**MathML にエクスポートされるのは、段落全体ですか、個々の数式ブロックですか？**

MathML には、全体の数式段落（[MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/)）または個々のブロック（[MathBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathblock/)）のいずれかをエクスポートできます。両方のタイプに MathML へ書き出すメソッドが用意されています。

**スライド上のオブジェクトが通常のテキストや画像ではなく数式であるかどうかは、どのように判断できますか？**

数式は [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) に存在し、[MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) を持っています。[MathParagraph] を持たない画像や通常のテキスト部分はエクスポート可能な数式ではありません。

**プレゼンテーション内の MathML はどこから来るのですか—PowerPoint 固有のものですか、それとも標準ですか？**

エクスポートは標準の MathML（XML）を対象としています。Aspose は Presentation MathML、すなわち標準のプレゼンテーションサブセットを使用しており、これは多くのアプリケーションやウェブで広く利用されています。

**テーブル、SmartArt、グループなど内部の数式をエクスポートすることはサポートされていますか？**

はい、これらのオブジェクトに [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) を含むテキスト部分（すなわち本物の PowerPoint 数式）がある場合はエクスポートされます。数式が画像として埋め込まれている場合はエクスポートされません。

**MathML へのエクスポートは元のプレゼンテーションを変更しますか？**

いいえ。MathML の書き出しは数式の内容をシリアライズするだけで、プレゼンテーションファイルは変更されません。