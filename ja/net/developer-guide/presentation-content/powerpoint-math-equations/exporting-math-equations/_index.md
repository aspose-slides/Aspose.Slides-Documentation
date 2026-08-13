---
title: .NET でプレゼンテーションから数式をエクスポート
linktitle: 数式のエクスポート
type: docs
weight: 30
url: /ja/net/exporting-math-equations/
keywords:
- 数式のエクスポート
- 数式を LaTeX にエクスポート
- PowerPoint から LaTeX へ
- MathML
- LaTeX
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint プレゼンテーションから数式を LaTeX または MathML に直接エクスポートします。"
---
## **はじめに**

Aspose.Slides for .NET は、プレゼンテーションから数式をエクスポートできるようにします。たとえば、特定のプレゼンテーションのスライド上の数式を抽出し、別のプログラムやプラットフォームで使用する必要がある場合があります。

{{% alert color="info" %}} 
数式を直接 LaTeX または MathML にエクスポートできます。MathML は、Web や多くのアプリケーションで使用される数式コンテンツの一般的な標準です。
{{% /alert %}}

## **LaTeX への数式エクスポート**

Aspose.Slides は、PowerPoint の数式を直接 LaTeX に変換できます。中間の MathML ファイルや外部コンバータは不要です。数式はテキストフレーム内に [MathPortion](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/mathportion/) として保存されます。[MathPortion.MathParagraph](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/mathportion/mathparagraph/) を使用して [IMathParagraph](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/imathparagraph/) を取得し、次に [IMathParagraph.ToLatex](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/imathparagraph/tolatex/) を呼び出します。このメソッドは文字列を返し、保存、表示、別のアプリケーションへの送信、またはさらに処理することができます。

次のサンプルは、すべてのスライドのすべてのテキストフレームを調べ、すべての数式部分を検出し、各数式を別々の `.tex` ファイルに書き込みます：

```csharp
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Util;

using var presentation = new Presentation("equations.pptx");

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    var slideNumber = slideIndex + 1;
    var equationNumber = 1;
    var textFrames = SlideUtil.GetAllTextBoxes(slide);

    foreach (var textFrame in textFrames)
    {
        foreach (var paragraph in textFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is not MathPortion mathPortion)
                    continue;

                IMathParagraph mathParagraph = mathPortion.MathParagraph;
                var latexPath = $"slide_{slideNumber}_equation_{equationNumber}.tex";

                var latexText = mathParagraph.ToLatex();
                File.WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}
```

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/ja/net/aspose.slides.util/slideutil/getalltextboxes/) はスライド上に見つかったすべてのテキストフレームを返します。[MathPortion](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/mathportion/) の型チェックにより、実際に編集可能な数式と通常のテキストや画像が区別されます。

LaTeX エンジンやドキュメントテンプレートはすべて同じコマンド、パッケージ、Unicode 文字をサポートしているわけではありません。返された文字列を、アプリケーションで使用している LaTeX エンジンでテストしてください。その環境でシンボルや Office Math 要素に適切な表現がない場合は、返された文字列内でプロジェクト固有のコマンドに置き換えるか、数式をスキップして問題を記録し、後でレビューできるようにしてください。

## **MathML として数式を保存**

人間は LaTeX のような一部の数式フォーマットのコードは簡単に書けますが、MathML のコードは書くのが難しいです。なぜなら、MathML はアプリケーションによって自動的に生成されることを前提としているからです。MathML のコードは XML 形式なので、プログラムは簡単に読み取りや解析ができ、多くの分野で出力や印刷フォーマットとして一般的に使用されています。

このサンプルコードは、プレゼンテーションから数式を MathML にエクスポートする方法を示します。

```c#
using Aspose.Slides;
using Aspose.Slides.MathText;

using (Presentation pres = new Presentation())
        {
            var autoShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
            var mathParagraph = ((MathPortion)autoShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            mathParagraph.Add(new MathematicalText("a").SetSuperscript("2").Join("+").Join(new MathematicalText("b").SetSuperscript("2")).Join("=").Join(new MathematicalText("c").SetSuperscript("2")));

       using (Stream stream = new FileStream("mathml.xml", FileMode.Create))
                mathParagraph.WriteAsMathMl(stream);
        }
```

## **よくある質問**

**MathML にエクスポートされるのは正確には何ですか—段落全体ですか、それとも個々の数式ブロックですか？**

MathML には、全体の数式段落 ([MathParagraph](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/mathparagraph/)) または個々のブロック ([MathBlock](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/mathblock/)) のいずれかをエクスポートできます。両方のタイプは MathML に書き出すメソッドを提供しています。

**スライド上のオブジェクトが通常のテキストや画像ではなく数式であることをどう判断できますか？**

数式は [MathPortion](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/mathportion/) に格納され、[MathParagraph](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/mathparagraph/) を持っています。[MathParagraph] を持たない画像や通常のテキスト部分は、エクスポート可能な数式ではありません。

**プレゼンテーション内の MathML はどこから来るのですか—PowerPoint 固有ですか、それとも標準ですか？**

エクスポートは標準の MathML (XML) を対象としています。Aspose は Presentation MathML を使用します。これは標準のプレゼンテーションサブセットで、アプリケーションやウェブ全体で広く使用されています。

**表、SmartArt、グループなど内部の数式のエクスポートはサポートされていますか？**

はい。これらのオブジェクトに [MathParagraph](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/mathparagraph/) を含むテキスト部分（すなわち実際の PowerPoint 数式）が含まれていればエクスポートされます。数式が画像として埋め込まれている場合はエクスポートされません。

**MathML へのエクスポートは元のプレゼンテーションを変更しますか？**

いいえ。MathML の書き出しは数式の内容をシリアライズするだけで、プレゼンテーション ファイルを変更することはありません。