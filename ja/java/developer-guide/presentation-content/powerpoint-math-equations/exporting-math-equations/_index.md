---
title: Java でプレゼンテーションから数式をエクスポート
linktitle: 数式のエクスポート
type: docs
weight: 30
url: /ja/java/exporting-math-equations/
keywords:
- 数式をエクスポート
- LaTeX へ数式をエクスポート
- PowerPoint から LaTeX へ
- MathML
- LaTeX
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Java 用 Aspose.Slides で PowerPoint プレゼンテーションから数式を直接 LaTeX または MathML にエクスポートします。"
---
## **はじめに**

Aspose.Slides はプレゼンテーションから数式をエクスポートできます。たとえば、特定のプレゼンテーションのスライド上の数式を抽出し、別のプログラムやプラットフォームで使用する必要がある場合があります。

{{% alert color="info" %}}
数式は LaTeX または MathML に直接エクスポートできます。MathML は Web や多くのアプリケーションで使用される、数学コンテンツの一般的な標準です。
{{% /alert %}}

## **LaTeX への数式エクスポート**

Aspose.Slides は PowerPoint の数式を直接 LaTeX に変換できます。中間の MathML ファイルや外部コンバータは不要です。数式はテキスト フレーム内に [IMathPortion](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imathportion/) として格納されます。[IMathPortion.getMathParagraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imathportion/#getMathParagraph--) を使用して [IMathParagraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imathparagraph/) を取得し、続いて [IMathParagraph.toLatex](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imathparagraph/#toLatex--) を呼び出します。このメソッドは文字列を返し、保存、表示、別のアプリケーションへの送信、またはさらに処理できます。

次の例はすべてのスライド上のすべてのテキスト フレームを調べ、すべての数式部分を見つけ、各数式を個別の `.tex` ファイルに書き込みます：

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

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) はスライド上で検出されたすべてのテキスト フレームを返します。[IMathPortion](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imathportion/) の型チェックにより、通常のテキストや画像とは異なる編集可能な本物の数式を分離できます。

LaTeX エンジンとドキュメント テンプレートはすべて同じコマンド、パッケージ、Unicode 文字をサポートしているわけではありません。アプリケーションで使用する LaTeX エンジンで返された文字列をテストしてください。シンボルや Office Math 要素に適切な表現が環境にない場合は、返された文字列内でプロジェクト固有のコマンドに置き換えるか、数式をスキップして問題を記録し、後でレビューしてください。

## **MathML として数式を保存**

人間は LaTeX のような一部の数式形式のコードを書きやすいですが、MathML のコードは自動生成を前提としているため、手書きは困難です。MathML のコードは XML 形式なので、プログラムは容易に読み取り・解析でき、さまざまな分野で出力や印刷形式として広く利用されています。

このサンプル コードは、プレゼンテーションから数式を MathML にエクスポートする方法を示しています：

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

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

**MathML にエクスポートされるのは、段落全体ですか、それとも個々の数式ブロックですか？**

MathML には、全体の数式段落 ([MathParagraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/mathparagraph/)) または個別のブロック ([MathBlock](https://reference.aspose.com/slides/ja/java/com.aspose.slides/mathblock/)) のいずれかをエクスポートできます。両方の型に MathML への書き出しメソッドがあります。

**スライド上のオブジェクトが通常のテキストや画像ではなく数式であることをどうやって判断できますか？**

数式は [MathPortion](https://reference.aspose.com/slides/ja/java/com.aspose.slides/mathportion/) に存在し、[MathParagraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/mathparagraph/) を持ちます。画像や通常のテキスト部分で [MathParagraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/mathparagraph/) を持たないものは、エクスポート可能な数式ではありません。

**プレゼンテーション内の MathML はどこから来るのですか？ PowerPoint 固有ですか、それとも標準ですか？**

エクスポートは標準の MathML (XML) を対象としています。Aspose は Presentation MathML、すなわち標準のプレゼンテーションサブセットを使用しており、これは多くのアプリケーションや Web で広く利用されています。

**テーブル、SmartArt、グループなど内部の数式のエクスポートはサポートされていますか？**

はい。これらのオブジェクトに [MathParagraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/mathparagraph/) を含むテキスト部分（すなわち本物の PowerPoint 数式）が含まれていればエクスポートされます。画像として埋め込まれた数式は対象外です。

**MathML へのエクスポートは元のプレゼンテーションを変更しますか？**

いいえ。MathML の書き出しは数式の内容をシリアライズするだけで、プレゼンテーション ファイル自体は変更されません。