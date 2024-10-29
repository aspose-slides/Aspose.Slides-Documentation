---
title: 数学方程式のエクスポート
type: docs
weight: 30
url: /ja/python-net/exporting-math-equations/
keywords: "数学方程式のエクスポート, PowerPointプレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "PythonでPowerPointの数学方程式をエクスポート"
---

Aspose.Slides for Python via .NETを使用すると、プレゼンテーションから数学方程式をエクスポートできます。たとえば、特定のプレゼンテーションのスライドにある数学方程式を抽出し、別のプログラムやプラットフォームで使用する必要があるかもしれません。 

{{% alert color="primary" %}} 

方程式をMathMLにエクスポートできます。MathMLは、ウェブや多くのアプリケーションで見られる数学方程式や類似のコンテンツのための一般的なフォーマットまたは標準です。 

{{% /alert %}}

人間はLaTeXのような方程式フォーマットのコードを書くのが容易ですが、MathMLのコードを書くのは難しいです。これは、MathMLがアプリによって自動的に生成されることを意図しているためです。プログラムはMathMLを簡単に読み取って解析できます。なぜなら、そのコードはXMLで書かれているからです。したがって、MathMLは多くの分野で出力と印刷形式として一般的に使用されています。

このサンプルコードは、プレゼンテーションからMathMLに数学方程式をエクスポートする方法を示しています：

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_math_shape(0, 0, 500, 50)
    mathParagraph = autoShape.text_frame.paragraphs[0].portions[0].math_paragraph

    mathParagraph.add(
        math.MathematicalText("a").
            set_superscript("2").
            join("+").
            join(math.MathematicalText("b").set_superscript("2")).
            join("=").
            join(math.MathematicalText("c").set_superscript("2")))

    with open("mathml.xml", "wb") as stream:
        mathParagraph.write_as_math_ml(stream)
```