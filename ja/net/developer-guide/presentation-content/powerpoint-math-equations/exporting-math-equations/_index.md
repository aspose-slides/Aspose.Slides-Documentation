---
title: .NET でプレゼンテーションから数式をエクスポート
linktitle: 数式をエクスポート
type: docs
weight: 30
url: /ja/net/exporting-math-equations/
keywords:
- 数式のエクスポート
- 数式を LaTeX にエクスポート
- PowerPoint を LaTeX に変換
- MathML
- LaTeX
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint プレゼンテーションから数式を直接 LaTeX または MathML にエクスポートします。"
---
## **概要**

Aspose.Slides for .NET を使用すると、プレゼンテーションから数式をエクスポートできます。たとえば、特定のプレゼンテーションのスライド上の数式を抽出し、別のプログラムやプラットフォームで使用する必要がある場合があります。

{{% alert color="primary" %}} 
数式を LaTeX または MathML に直接エクスポートできます。MathML はウェブや多くのアプリケーションで使用されている数学コンテンツの一般的な標準です。
{{% /alert %}}

## **数式を LaTeX にエクスポート**

Aspose.Slides は PowerPoint の数式を直接 LaTeX に変換できます。中間の MathML ファイルや外部コンバータは必要ありません。数式はテキスト フレーム内に [MathPortion](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/mathportion/) として保存されます。[MathPortion.MathParagraph](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/mathportion/mathparagraph/) を使用して [IMathParagraph](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/imathparagraph/) を取得し、次に [IMathParagraph.ToLatex](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/imathparagraph/tolatex/) を呼び出します。このメソッドは文字列を返し、保存、表示、別のアプリケーションへの送信、またはさらに処理することができます。

次のサンプルは、すべてのスライドのすべてのテキスト フレームを調べ、すべての数式部分を見つけ出し、各数式を個別の `.tex` ファイルに書き出します：

```csharp
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

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/ja/net/aspose.slides.util/slideutil/getalltextboxes/) はスライド上で見つかったすべてのテキスト フレームを返します。[MathPortion](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/mathportion/) の型チェックにより、通常のテキストや画像と区別して実際に編集可能な数式が分離されます。

LaTeX エンジンや文書テンプレートはすべて同じコマンド、パッケージ、Unicode 文字をサポートしているわけではありません。返された文字列を、アプリケーションで使用している LaTeX エンジンでテストしてください。シンボルや Office Math 要素がその環境で適切に表現できない場合は、返された文字列中でプロジェクト固有のコマンドに置き換えるか、数式をスキップし、問題を記録してレビューしてください。

## **数式を MathML として保存**

LaTeX のような一部の数式フォーマットは人間が簡単にコードを書けますが、MathML のコードは手書きが難しいです。MathML はアプリケーションによって自動生成されることを想定しているからです。MathML は XML 形式のコードであるため、プログラムは容易に読み取り・解析できます。そのため、MathML は多くの分野で出力および印刷フォーマットとして一般的に使用されています。

このサンプルコードは、プレゼンテーションから数式を MathML にエクスポートする方法を示しています：

```c#
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

**MathML にエクスポートされるのは正確には何ですか—段落全体ですか、それとも個別の数式ブロックですか？**

MathML へは、全体の数式段落 ([MathParagraph](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/mathparagraph/)) または個別のブロック ([MathBlock](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/mathblock/)) のいずれかをエクスポートできます。両方のタイプは MathML に書き出すメソッドを提供しています。

**スライド上のオブジェクトが通常のテキストや画像ではなく数式であることをどのように判断できますか？**

数式は [MathPortion](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/mathportion/) に存在し、[MathParagraph](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/mathparagraph/) を持ちます。[MathParagraph] を持たない画像や通常のテキスト部分はエクスポート可能な数式ではありません。

**プレゼンテーション内の MathML はどこから来るのですか—PowerPoint 固有ですか、それとも標準ですか？**

エクスポートは標準的な MathML（XML）を対象としています。Aspose は Presentation MathML、すなわち標準のプレゼンテーションサブセットを使用しており、これはアプリケーションやウェブ全体で広く利用されています。

**表、SmartArt、グループなど内の数式のエクスポートはサポートされていますか？**

はい、これらのオブジェクトに [MathParagraph](https://reference.aspose.com/slides/ja/net/aspose.slides.mathtext/mathparagraph/) を含むテキスト部分（すなわち実際の PowerPoint 数式）がある場合はエクスポートされます。数式が画像として埋め込まれている場合はエクスポートされません。

**MathML へのエクスポートは元のプレゼンテーションを変更しますか？**

いいえ。MathML の書き出しは数式の内容をシリアライズするだけであり、プレゼンテーション ファイルは変更されません。