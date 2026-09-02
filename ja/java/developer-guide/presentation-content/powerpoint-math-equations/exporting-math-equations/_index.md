---
title: Java でプレゼンテーションから数式をエクスポート
linktitle: 数式をエクスポート
type: docs
weight: 30
url: /ja/java/exporting-math-equations/
keywords:
- 数式のエクスポート
- LaTeX への数式エクスポート
- PowerPoint から LaTeX へ
- MathML
- LaTeX
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint プレゼンテーションから数式を直接 LaTeX または MathML にエクスポートします。"
---
## **はじめに**

Aspose.Slides を使用すると、プレゼンテーションから数式をエクスポートできます。たとえば、特定のプレゼンテーションのスライドに含まれる数式を抽出し、別のプログラムやプラットフォームで使用する必要がある場合があります。

{{% alert color="primary" %}} 
数式を LaTeX または MathML に直接エクスポートできます。MathML はウェブや多数のアプリケーションで使用される数学コンテンツの一般的な標準です。
{{% /alert %}}

## **数式を LaTeX にエクスポートする**

Aspose.Slides は PowerPoint の数式を直接 LaTeX に変換できます。中間の MathML ファイルや外部コンバータは不要です。数式はテキストフレーム内に[IMathPortion](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imathportion/)として格納されます。[IMathPortion.getMathParagraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imathportion/#getMathParagraph--) を使用して[IMathParagraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imathparagraph/)を取得し、次に[IMathParagraph.toLatex](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imathparagraph/#toLatex--) を呼び出します。このメソッドは文字列を返し、保存、表示、別のアプリケーションへの送信、またはさらに処理することができます。

以下の例は、すべてのスライドのすべてのテキストフレームを調べ、すべての数式部分を検出し、各数式を個別の`.tex`ファイルに書き出します。

```java
Presentation presentation = new Presentation("equations.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slideIndex + 1;
        int equationNumber = 1;
        ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

        for (ITextFrame textFrame : textFrames) {
            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    if (!(portion instanceof IMathPortion))
                        continue;

                    IMathPortion mathPortion = (IMathPortion) portion;
                    IMathParagraph mathParagraph = mathPortion.getMathParagraph();
                    String latexFileName = "slide_" + slideNumber + "_equation_" + equationNumber + ".tex";

                    String latexText = mathParagraph.toLatex();
                    Path latexPath = Paths.get(latexFileName);
                    byte[] latexBytes = latexText.getBytes(StandardCharsets.UTF_8);
                    Files.write(latexPath, latexBytes);
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) はスライド上で見つかったすべてのテキストフレームを返します。[IMathPortion](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imathportion/) の型チェックにより、通常のテキストや画像とは異なる本物の編集可能な数式が分離されます。

LaTeX エンジンや文書テンプレートはすべて同じコマンド、パッケージ、Unicode 文字をサポートしているわけではありません。返された文字列をアプリケーションで使用する LaTeX エンジンでテストしてください。シンボルや Office Math 要素に適切な表現が環境にない場合は、返された文字列内でプロジェクト固有のコマンドに置き換えるか、数式をスキップし、問題を記録してレビューしてください。

## **数式を MathML として保存する**

人間は LaTeX のような一部の数式フォーマットのコードは簡単に書けますが、MathML のコードは書くのが難しいです。MathML はアプリで自動生成されることを前提としているためです。プログラムは XML 形式のコードであるため、MathML を簡単に読み取り・解析でき、多くの分野で出力および印刷フォーマットとして一般的に使用されています。

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

## **FAQ**

**MathML にエクスポートされるのは段落全体ですか、それとも個々の数式ブロックですか？**

MathML へは、全体の数式段落([MathParagraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/mathparagraph/))または個別のブロック([MathBlock](https://reference.aspose.com/slides/ja/java/com.aspose.slides/mathblock/))のいずれかをエクスポートできます。両方のタイプが MathML に書き出すメソッドを提供しています。

**スライド上のオブジェクトが通常のテキストや画像ではなく数式であることをどのように判断できますか？**

数式は[MathPortion](https://reference.aspose.com/slides/ja/java/com.aspose.slides/mathportion/)に存在し、[MathParagraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/mathparagraph/)を持ちます。[MathParagraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/mathparagraph/) を持たない画像や通常のテキスト部分はエクスポート可能な数式ではありません。

**プレゼンテーション内の MathML はどこから来るのですか？PowerPoint 固有ですか、それとも標準ですか？**

エクスポートは標準の MathML (XML) を対象としています。Aspose は Presentation MathML（標準のプレゼンテーションサブセット）を使用しており、これは多くのアプリケーションやウェブで広く利用されています。

**テーブル、SmartArt、グループなど内部の数式のエクスポートはサポートされていますか？**

はい、これらのオブジェクトが[MathParagraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/mathparagraph/) を含むテキスト部分（すなわち本物の PowerPoint 数式）を持っていればエクスポートされます。画像として埋め込まれた数式は対象外です。

**MathML へのエクスポートは元のプレゼンテーションを変更しますか？**

いいえ。MathML の書き出しは数式内容のシリアライズであり、プレゼンテーションファイルを変更することはありません。