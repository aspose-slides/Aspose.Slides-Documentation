---
title: 数学方程式のエクスポート
type: docs
weight: 30
url: /ja/net/exporting-math-equations/
keywords: "数学方程式のエクスポート, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint 数学方程式をエクスポート"
---

Aspose.Slides for .NET を使用すると、プレゼンテーションから数学方程式をエクスポートできます。たとえば、特定のプレゼンテーションのスライドにある数学方程式を抽出し、別のプログラムやプラットフォームで使用する必要があるかもしれません。

{{% alert color="primary" %}} 

方程式を MathML にエクスポートできます。MathML は、Web や多くのアプリケーションで見られる数学方程式や類似のコンテンツのための一般的なフォーマットまたは標準です。

{{% /alert %}}

人間は LaTeX のような方程式フォーマットのコードを書くのは容易ですが、MathML のコードを書くことには苦労します。なぜなら、後者はアプリによって自動的に生成されることを意図しているからです。プログラムは XML 形式であるため、MathML を簡単に読み取って解析します。そのため、MathML は多くの分野で出力および印刷フォーマットとして一般的に使用されています。

このサンプルコードは、プレゼンテーションから MathML に数学方程式をエクスポートする方法を示しています：

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