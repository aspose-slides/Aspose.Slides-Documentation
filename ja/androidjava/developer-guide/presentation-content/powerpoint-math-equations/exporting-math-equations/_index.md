---
title: Android のプレゼンテーションから数式をエクスポート
linktitle: 数式をエクスポート
type: docs
weight: 30
url: /ja/androidjava/exporting-math-equations/
keywords:
- 数式をエクスポート
- LaTeX へ数式をエクスポート
- PowerPoint から LaTeX へ
- MathML
- LaTeX
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint プレゼンテーションから数式を直接 LaTeX または MathML にエクスポートします。"
---
## **はじめに**

Aspose.Slides for Android via Java を使用すると、プレゼンテーションから数式をエクスポートできます。たとえば、特定のプレゼンテーション内のスライド上の数式を抽出し、別のプログラムやプラットフォームで使用する必要がある場合があります。

{{% alert color="primary" %}} 
数式は LaTeX または MathML に直接エクスポートできます。MathML は、ウェブや多くのアプリケーションで使用される数式コンテンツの一般的な標準です。
{{% /alert %}}

## **数式を LaTeX にエクスポート**

Aspose.Slides は、PowerPoint の数式を直接 LaTeX に変換できます。中間の MathML ファイルや外部コンバータは必要ありません。数式はテキストフレーム内に [IMathPortion](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imathportion/) として格納されます。[IMathPortion.getMathParagraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) を使用して [IMathParagraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imathparagraph/) を取得し、次に [IMathParagraph.toLatex](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imathparagraph/#toLatex--) を呼び出します。このメソッドは、保存、表示、別のアプリケーションへの送信、またはさらに処理できる文字列を返します。

次のサンプルは、すべてのスライドのすべてのテキストフレームを調べ、すべての数式部分を検出し、各数式を個別の `.tex` ファイルに書き出します:

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
                    File latexFile = new File(latexFileName);
                    byte[] latexBytes = latexText.getBytes(StandardCharsets.UTF_8);
                    FileOutputStream outputStream = new FileOutputStream(latexFile);
                    try {
                        outputStream.write(latexBytes);
                    } finally {
                        outputStream.close();
                    }
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) は、スライド上で見つかったすべてのテキストフレームを返します。[IMathPortion](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imathportion/) の型チェックにより、通常のテキストや画像と区別して、実際に編集可能な数式を分離します。

LaTeX エンジンやドキュメントテンプレートは、すべて同じコマンド、パッケージ、Unicode 文字をサポートしているわけではありません。返された文字列を、アプリケーションで使用している LaTeX エンジンでテストしてください。シンボルや Office Math 要素がその環境で適切に表現できない場合は、返された文字列内でプロジェクト固有のコマンドに置き換えるか、数式をスキップし、その問題を記録してレビューしてください。

## **MathML として数式を保存**

人間は LaTeX のような一部の数式フォーマットのコードは簡単に書くことができますが、MathML のコードを書くのは難しいです。MathML はアプリによって自動生成されることを想定しているためです。MathML はコードが XML 形式であるため、プログラムは簡単に読み取り・解析できます。そのため、MathML は多くの分野で出力や印刷フォーマットとして一般的に使用されています。

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

## **よくある質問**

**MathML にエクスポートされる対象は正確に何ですか—段落全体ですか、個々の数式ブロックですか？**  
MathML へは、全体の数式段落（[MathParagraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/mathparagraph/)）または個別のブロック（[MathBlock](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/mathblock/)）のいずれかをエクスポートできます。両方のタイプには MathML に書き出すためのメソッドが用意されています。

**スライド上のオブジェクトが通常のテキストや画像ではなく数式であるかどうかは、どのように判断できますか？**  
数式は [MathPortion](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/mathportion/) に存在し、[MathParagraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/mathparagraph/) を持ちます。[MathParagraph] を持たない画像や通常のテキスト部分は、エクスポート可能な数式ではありません。

**プレゼンテーション内の MathML はどこから来るのですか—PowerPoint 固有ですか、標準ですか？**  
エクスポートは標準の MathML (XML) を対象としています。Aspose は Presentation MathML を使用します。これは標準のプレゼンテーションサブセットで、アプリケーションやウェブ全体で広く使用されています。

**テーブル、SmartArt、グループなど内部の数式のエクスポートはサポートされていますか？**  
はい。これらのオブジェクトに [MathParagraph] を含むテキスト部分（すなわち実際の PowerPoint 数式）がある場合はエクスポートされます。数式が画像として埋め込まれている場合はエクスポートされません。

**MathML へのエクスポートは元のプレゼンテーションを変更しますか？**  
いいえ。MathML の書き出しは数式の内容をシリアライズするだけで、プレゼンテーション ファイルを変更することはありません。