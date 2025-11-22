---
title: 数式のエクスポート
type: docs
weight: 30
url: /ja/net/exporting-math-equations/
keywords: "数式のエクスポート, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint の数式をエクスポート"
---

## **導入**

Aspose.Slides for .NET を使用すると、プレゼンテーションから数式をエクスポートできます。たとえば、特定のプレゼンテーションのスライド上の数式を抽出し、別のプログラムやプラットフォームで使用する必要がある場合があります。

{{% alert color="primary" %}} 
数式を MathML にエクスポートできます。MathML は、Web やさまざまなアプリケーションで使用されている、数式や類似コンテンツの一般的なフォーマットまたは標準です。 
{{% /alert %}}

## **MathML として数式を保存**

人間は LaTeX のような一部の数式フォーマットのコードは簡単に書けますが、MathML のコードは書くのが難しいです。MathML はアプリケーションによって自動生成されることを想定しているためです。プログラムは MathML が XML 形式なので簡単に読み取り・解析できるため、多くの分野で出力および印刷フォーマットとして広く使用されています。

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

**MathML にエクスポートされるのは正確には何ですか—段落全体ですか、個々の数式ブロックですか？**

MathML へは、全体の数式段落（[MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/)）または個々のブロック（[MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/)）のいずれかをエクスポートできます。両方のタイプは MathML に書き出すメソッドを提供しています。

**スライド上のオブジェクトが通常のテキストや画像ではなく数式であるかどうかは、どのように判断できますか？**

数式は[MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/)に存在し、[MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/)を持っています。[MathParagraph] を持たない画像や通常のテキスト部分はエクスポート可能な数式ではありません。

**プレゼンテーション内の MathML はどこから来るのですか—PowerPoint 固有のものですか、それとも標準ですか？**

エクスポートは標準の MathML（XML）を対象としています。Aspose は Presentation MathML、すなわち標準のプレゼンテーションサブセットを使用しており、アプリケーションや Web で広く利用されています。

**テーブル、SmartArt、グループなど内の数式のエクスポートはサポートされていますか？**

はい、これらのオブジェクトが[MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/)を含むテキスト部分を持っている場合（すなわち実際の PowerPoint 数式）、エクスポートされます。数式が画像として埋め込まれている場合はエクスポートされません。

**MathML へのエクスポートは元のプレゼンテーションを変更しますか？**

いいえ。MathML の書き出しは数式の内容をシリアライズしたものであり、プレゼンテーションファイルを変更することはありません。