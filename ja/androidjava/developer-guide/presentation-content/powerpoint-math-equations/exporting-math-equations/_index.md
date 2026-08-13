---
title: Android のプレゼンテーションから数式をエクスポート
linktitle: 数式をエクスポート
type: docs
weight: 30
url: /ja/androidjava/exporting-math-equations/
keywords:
- 数式をエクスポート
- LaTeX への数式エクスポート
- PowerPoint から LaTeX へ
- MathML
- LaTeX
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "PowerPoint のプレゼンテーションから数式を直接 LaTeX または MathML にエクスポートする、Android 用 Java の Aspose.Slides を使用します。"
---
## **概要**

Aspose.Slides for Android via Java を使用すると、プレゼンテーションから数式をエクスポートできます。たとえば、特定のプレゼンテーション内のスライドにある数式を抽出し、別のプログラムやプラットフォームで使用する必要がある場合があります。

{{% alert color="info" %}} 
数式は LaTeX または MathML に直接エクスポートできます。MathML はウェブや多くのアプリケーションで使用される数式コンテンツの一般的な標準です。
{{% /alert %}}

## **数式を LaTeX にエクスポートする**

Aspose.Slides は PowerPoint の数式を直接 LaTeX に変換できます。中間の MathML ファイルや外部コンバータは必要ありません。数式はテキストフレーム内に [IMathPortion](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imathportion/) として格納されます。[IMathPortion.getMathParagraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) を使用して [IMathParagraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imathparagraph/) を取得し、続いて [IMathParagraph.toLatex](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imathparagraph/#toLatex--) を呼び出します。このメソッドは文字列を返すので、保存、表示、他のアプリケーションへの送信、またはさらに処理できます。

次の例は、すべてのスライドのすべてのテキストフレームを調べ、すべての数式部分を検出し、各数式を別々の `.tex` ファイルに書き込みます。

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;
import java.nio.charset.StandardCharsets;

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

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) はスライド上で見つかったすべてのテキストフレームを返します。[IMathPortion](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imathportion/) の型チェックにより、通常のテキストや画像と区別して、実際に編集可能な数式を分離します。

LaTeX エンジンやドキュメントテンプレートはすべて同じコマンド、パッケージ、Unicode 文字をサポートしているわけではありません。返された文字列は、使用している LaTeX エンジンでテストしてください。シンボルや Office Math の要素がその環境で適切に表現できない場合は、返された文字列中でプロジェクト固有のコマンドに置き換えるか、数式をスキップして問題を記録し、後で見直してください。

## **MathML として数式を保存する**

LaTeX のような一部の数式フォーマットのコードは人間が比較的簡単に記述できますが、MathML のコードは手書きが難しいです。MathML はアプリによって自動生成されることを想定しているためです。MathML は XML 形式なので、プログラムは簡単に読み取り・解析できます。そのため、多くの分野で出力や印刷フォーマットとして広く使用されています。

このサンプルコードは、プレゼンテーションから数式を MathML にエクスポートする方法を示しています。

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

**MathML にエクスポートされるのは、段落全体ですか、個々の数式ブロックですか？**  
MathML には、全体の数式段落 ([MathParagraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/mathparagraph/)) または個々のブロック ([MathBlock](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/mathblock/)) のいずれかをエクスポートできます。両方のタイプには MathML に書き出すメソッドが用意されています。

**スライド上のオブジェクトが通常のテキストや画像ではなく数式であるかどうかは、どのように判断できますか？**  
数式は [MathPortion](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/mathportion/) 内にあり、[MathParagraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/mathparagraph/) を持ちます。[MathParagraph] を持たない画像や通常のテキスト部分はエクスポート可能な数式ではありません。

**プレゼンテーション内の MathML はどこから来るのでしょうか—PowerPoint 固有のものですか、標準ですか？**  
エクスポートは標準の MathML (XML) を対象としています。Aspose は Presentation MathML（標準のプレゼンテーションサブセット）を使用しており、これはアプリケーションやウェブ全体で広く利用されています。

**テーブル、SmartArt、グループなど内の数式のエクスポートはサポートされていますか？**  
はい、これらのオブジェクトに [MathParagraph] を持つテキスト部分（つまり実際の PowerPoint の数式）が含まれていればエクスポートされます。数式が画像として埋め込まれている場合はエクスポートされません。

**MathML へのエクスポートは元のプレゼンテーションを変更しますか？**  
いいえ。MathML の書き出しは数式内容のシリアライズであり、プレゼンテーション ファイルを変更することはありません。