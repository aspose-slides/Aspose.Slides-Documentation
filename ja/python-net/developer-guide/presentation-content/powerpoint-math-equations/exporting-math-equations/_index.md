---
title: Pythonでプレゼンテーションから数式をエクスポートする
linktitle: 数式のエクスポート
type: docs
weight: 30
url: /ja/python-net/exporting-math-equations/
keywords:
- 数式エクスポート
- MathML
- LaTeX
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint から MathML へ数式をシームレスにエクスポートし、書式を保持しながら互換性を高めます。"
---

## **はじめに**

Aspose.Slides for Python via .NET は、プレゼンテーションから数式をエクスポートする機能を提供します。たとえば、特定のスライドから数式を抽出し、別のプログラムやプラットフォームで再利用する必要がある場合があります。

{{% alert color="primary" %}}
MathML は、ウェブや多くのアプリケーションで数式コンテンツを表現するために広く使用されている標準形式です。数式を MathML にエクスポートできます。
{{% /alert %}}

## **MathMLとして数式を保存する**

人間は LaTeX を簡単に記述できますが、MathML は通常、アプリケーションによって自動的に生成されます。MathML は XML ベースであるため、プログラムは信頼性高く読み取り・解析でき、多くの分野で出力および印刷形式として一般的に使用されています。

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

**MathML にエクスポートされるのは段落全体ですか、それとも個別の数式ブロックですか？**

[MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) 全体、または個別のブロックである[MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) のどちらでも MathML にエクスポートできます。両方とも MathML への書き出しメソッドを提供しています。

**スライド上のオブジェクトが通常のテキストや画像ではなく数式であることは、どうやって判断しますか？**

数式は[MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) に存在し、[MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) を持っています。[MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) を持たない画像や通常のテキスト部分はエクスポート対象の数式ではありません。

**プレゼンテーション内の MathML はどこから来るのでしょうか—PowerPoint 固有ですか、標準ですか？**

エクスポートは標準の MathML（XML）を対象としています。Aspose は Presentation MathML（標準のプレゼンテーションサブセット）を使用しており、これは多数のアプリケーションやウェブで広く利用されています。

**テーブル、SmartArt、グループなど内部の数式のエクスポートはサポートされていますか？**

それらのオブジェクトが[MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) を含むテキスト部分を保持していれば（つまり本物の PowerPoint 数式である場合）、エクスポートされます。数式が画像として埋め込まれている場合は対象外です。

**MathML へのエクスポートは元のプレゼンテーションを変更しますか？**

いいえ。MathML の書き出しは数式内容のシリアライズであり、プレゼンテーションファイル自体は変更されません。