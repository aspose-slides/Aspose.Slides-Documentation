---
title: プレゼンテーションからPythonで数式をエクスポート
linktitle: 数式のエクスポート
type: docs
weight: 30
url: /ja/python-net/exporting-math-equations/
keywords:
- 数式のエクスポート
- MathML
- LaTeX
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint から MathML へ数式をシームレスにエクスポートし、書式を保持し互換性を向上させます。"
---

## **はじめに**

Aspose.Slides for Python via .NET を使用すると、プレゼンテーションから数式をエクスポートできます。たとえば、特定のスライドから数式を抽出し、別のプログラムやプラットフォームで再利用したい場合があります。

{{% alert color="primary" %}}
数式を MathML にエクスポートできます。MathML は、ウェブや多くのアプリケーションで数式コンテンツを表現するために広く使用されている標準です。
{{% /alert %}}

## **MathML として数式を保存**

人間は LaTeX を簡単に書くことができますが、MathML は通常、アプリケーションによって自動的に生成されます。MathML は XML ベースであるため、プログラムは信頼性高く読み取り・解析でき、多くの分野で出力および印刷フォーマットとして一般的に使用されています。

以下のサンプルコードは、プレゼンテーションから数式を MathML にエクスポートする方法を示しています。

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_math_shape(0, 0, 500, 50)
    math_paragraph = auto_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    math_paragraph.add(
        math.MathematicalText("a").
            set_superscript("2").
            join("+").
            join(math.MathematicalText("b").set_superscript("2")).
            join("=").
            join(math.MathematicalText("c").set_superscript("2")))

    with open("mathml.xml", "wb") as file_stream:
        math_paragraph.write_as_math_ml(file_stream)
```

## **FAQ**

**MathML にエクスポートされるのは段落全体ですか、それとも個々の数式ブロックですか？**

MathML には、[MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) 全体または個々のブロック ([MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)) のどちらでもエクスポートできます。両方のタイプに MathML への書き出しメソッドがあります。

**スライド上のオブジェクトが数式か、通常のテキストや画像かをどう判別できますか？**

数式は [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) に存在し、[MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) を持っています。画像や通常のテキスト部分で、[MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) を持たないものはエクスポート対象の数式ではありません。

**プレゼンテーション内の MathML はどこから来るものですか？PowerPoint 固有ですか、それとも標準ですか？**

エクスポートは標準の MathML (XML) を対象としています。Aspose は Presentation MathML、すなわち標準のプレゼンテーションサブセットを使用しており、さまざまなアプリケーションやウェブで広く利用されています。

**テーブル、SmartArt、グループなど内部の数式のエクスポートはサポートされていますか？**

はい。これらのオブジェクトに [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) を含むテキスト部分（実際の PowerPoint 数式）が含まれていればエクスポートされます。数式が画像として埋め込まれている場合はエクスポート対象外です。

**MathML へのエクスポートは元のプレゼンテーションを変更しますか？**

変更しません。MathML の書き出しは数式の内容をシリアライズするだけで、プレゼンテーション ファイル自体は変更されません。