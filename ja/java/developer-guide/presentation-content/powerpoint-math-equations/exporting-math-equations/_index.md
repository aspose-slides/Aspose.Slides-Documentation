---
title: Javaでプレゼンテーションから数式をエクスポート
linktitle: 式をエクスポート
type: docs
weight: 30
url: /ja/java/exporting-math-equations/
keywords:
- 数式のエクスポート
- MathML
- LaTeX
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint から MathML への数式エクスポートをシームレスに実現し、書式を保持し、互換性を向上させます。"
---

## プレゼンテーションから数式をエクスポートする

Aspose.Slides for Java は、プレゼンテーションから数式をエクスポートする機能を提供します。たとえば、特定のプレゼンテーションのスライド上の数式を抽出し、別のプログラムやプラットフォームで使用する必要がある場合があります。 

{{% alert color="primary" %}} 

数式を MathML にエクスポートできます。MathML は、ウェブや多くのアプリケーションで使用される、数学的な式や類似コンテンツのための一般的なフォーマットまたは標準です。 

{{% /alert %}}

人間は LaTeX のような一部の式フォーマットのコードを書きやすいですが、MathML のコードはアプリが自動生成することを前提としているため、書くのが難しいです。MathML のコードは XML 形式であるため、プログラムは容易に読み取り・解析できます。そのため、MathML は多くの分野で出力や印刷フォーマットとして一般的に使用されています。 

このサンプルコードは、プレゼンテーションから数式を MathML にエクスポートする方法を示しています:
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


## **FAQ**

**MathML にエクスポートされるのは正確には段落ですか、個々の数式ブロックですか？**

MathML へは、全体の数式段落（[MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/)）または個々のブロック（[MathBlock](https://reference.aspose.com/slides/java/com.aspose.slides/mathblock/)）のいずれかをエクスポートできます。両方のタイプには MathML に書き出すためのメソッドが用意されています。

**スライド上のオブジェクトが通常のテキストや画像ではなく数式であるかどうかは、どのように判別できますか？**

数式は [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) に存在し、[MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/) を持っています。[MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/) を持たない画像や通常のテキスト部分はエクスポート可能な数式ではありません。

**プレゼンテーション内の MathML はどこから来るのですか—PowerPoint 固有のものですか、それとも標準ですか？**

エクスポートは標準の MathML（XML）を対象としています。Aspose は Presentation MathML、すなわち標準のプレゼンテーションサブセットを使用しており、これはアプリケーションやウェブ全体で広く利用されています。

**テーブル、SmartArt、グループなど内部の数式のエクスポートはサポートされていますか？**

はい、これらのオブジェクトに [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/) を含むテキスト部分（つまり実際の PowerPoint の数式）がある場合はエクスポートされます。数式が画像として埋め込まれている場合はエクスポートされません。

**MathML へのエクスポートは元のプレゼンテーションを変更しますか？**

いいえ。MathML の書き込みは数式の内容をシリアライズするだけであり、プレゼンテーションファイルを変更することはありません。