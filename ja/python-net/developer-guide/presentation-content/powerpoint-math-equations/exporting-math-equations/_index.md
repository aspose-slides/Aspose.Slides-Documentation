---
title: Python 用プレゼンテーションから数式をエクスポート
linktitle: 数式エクスポート
type: docs
weight: 30
url: /ja/python-net/developer-guide/presentation-content/powerpoint-math-equations/exporting-math-equations/
keywords:
- 数式エクスポート
- MathML
- LaTeX
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint から MathML への数式エクスポートをシームレスに実現し、書式を保持し、互換性を向上させます。"
---

## **はじめに**

Aspose.Slides for Python via .NET を使用すると、プレゼンテーションから数式をエクスポートできます。たとえば、特定のスライドから数式を抽出し、別のプログラムやプラットフォームで再利用する必要がある場合があります。

{{% alert color="primary" %}}

数式を MathML にエクスポートできます。MathML は Web 上や多くのアプリケーションで数式コンテンツを表現するために広く使用されている標準です。

{{% /alert %}}

## **数式を MathML として保存**

人間は LaTeX を簡単に記述できますが、MathML は通常アプリケーションによって自動生成されます。MathML は XML ベースであるため、プログラムは確実に読み取り・解析でき、さまざまな分野で出力や印刷フォーマットとして一般的に使用されています。

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

**MathML にエクスポートされるのは、段落全体ですか、それとも個々の数式ブロックですか？**

MathML へは、全体の数式段落 ([MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/)) または個別のブロック ([MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)) のいずれかをエクスポートできます。両方のタイプに MathML へ書き出すメソッドが用意されています。

**スライド上のオブジェクトが通常のテキストや画像ではなく数式であることは、どう判断できますか？**

数式は [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) に存在し、[MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) を持ちます。画像や通常のテキスト部分で、[MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) を持たないものはエクスポート可能な数式ではありません。

**プレゼンテーション内の MathML はどこから来るのですか—PowerPoint 固有ですか、それとも標準ですか？**

エクスポートは標準の MathML（XML）を対象としています。Aspose は Presentation MathML（標準のプレゼンテーションサブセット）を使用しており、これは多くのアプリケーションや Web で広く利用されています。

**テーブル、SmartArt、グループなど内の数式のエクスポートはサポートされていますか？**

はい、これらのオブジェクトに [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) を含むテキスト部分（すなわち実際の PowerPoint 数式）が含まれていればエクスポートされます。数式が画像として埋め込まれている場合は対象外です。

**MathML へのエクスポートは元のプレゼンテーションを変更しますか？**

いいえ。MathML の書き出しは数式の内容をシリアライズするだけであり、プレゼンテーションファイル自体は変更されません。