---
title: .NET のプレゼンテーションから数式をエクスポート
linktitle: 数式のエクスポート
type: docs
weight: 30
url: /ja/net/exporting-math-equations/
keywords:
- 数式のエクスポート
- MathML
- LaTeX
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint から MathML への数式エクスポートをシームレスに実現し、書式を保持し、互換性を向上させます。"
---

## **はじめに**

Aspose.Slides for .NET を使用すると、プレゼンテーションから数式をエクスポートできます。たとえば、特定のプレゼンテーションのスライド上の数式を抽出し、別のプログラムやプラットフォームで使用する必要がある場合があります。

{{% alert color="primary" %}} 
数式を MathML にエクスポートできます。MathML は、ウェブや多くのアプリケーションで見られる数式や類似コンテンツのための一般的なフォーマット／標準です。 
{{% /alert %}}

## **MathML として数式を保存する**

LaTeX のような一部の数式フォーマットのコードは人間が簡単に記述できますが、MathML のコードは手書きが難しいです。MathML はアプリケーションによって自動生成されることを前提としているためです。MathML のコードは XML 形式なので、プログラムは容易に読み取り・解析できます。そのため、MathML は多くの分野で出力や印刷フォーマットとして広く使用されています。

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


## **FAQ**

**MathML にエクスポートされる対象は、段落全体ですか、それとも個々の数式ブロックですか？**

MathML へは、全体の数式段落（[MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/)）または個別のブロック（[MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/)）のいずれかをエクスポートできます。両方のタイプには MathML へ書き出すメソッドが用意されています。

**スライド上のオブジェクトが通常のテキストや画像ではなく数式であるかどうかは、どうやって判断できますか？**

数式は [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) に存在し、[MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) を持っています。[MathParagraph] を持たない画像や通常のテキスト部分は、エクスポート可能な数式ではありません。

**プレゼンテーション内の MathML はどこから来るのですか？PowerPoint 固有のものですか、それとも標準ですか？**

エクスポートは標準の MathML（XML）を対象としています。Aspose は Presentation MathML、すなわち標準のプレゼンテーションサブセットを使用しており、これは多くのアプリケーションやウェブで広く利用されています。

**テーブル、SmartArt、グループなど内の数式のエクスポートはサポートされていますか？**

はい、これらのオブジェクトに [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) を含むテキスト部分（すなわち実際の PowerPoint 数式）がある場合はエクスポートされます。数式が画像として埋め込まれている場合はエクスポートされません。

**MathML へのエクスポートは元のプレゼンテーションを変更しますか？**

いいえ。MathML の書き出しは数式の内容をシリアライズするだけで、プレゼンテーションファイル自体は変更されません。