---
title: Pythonでプレゼンテーションから数式をエクスポート
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
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint から MathML へ数式をシームレスにエクスポートし、書式を保持し、互換性を向上させます。"
---

## **導入**

Aspose.Slides for Python via .NET は、プレゼンテーションから数式をエクスポートする機能を提供します。たとえば、特定のスライドから数式を抽出し、別のプログラムやプラットフォームで再利用する必要がある場合があります。

{{% alert color="primary" %}}
MathML は、Web や多くのアプリケーションで数式コンテンツを表現するために広く使用されている標準です。
{{% /alert %}}

## **数式をMathMLとして保存**

人間は LaTeX を簡単に記述できますが、MathML は通常、アプリケーションによって自動的に生成されます。MathML は XML ベースであるため、プログラムは信頼性の高い読み取りや解析が可能で、多くの分野で出力や印刷フォーマットとして広く使用されています。

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


## **よくある質問**

**MathMLにエクスポートされる対象は何ですか—段落全体ですか、それとも個々の数式ブロックですか？**

MathML へは、全体の数式段落（[MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/)）または個々のブロック（[MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)）のいずれかをエクスポートできます。両方のタイプが MathML に書き出すメソッドを提供しています。

**スライド上のオブジェクトが通常のテキストや画像ではなく数式であるかどうかは、どのように判別できますか？**

数式は[MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/)に存在し、[MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/)を持っています。[MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) を含まない画像や通常のテキスト部分は、エクスポート可能な数式ではありません。

**プレゼンテーション内の MathML はどこから来るものですか—PowerPoint 固有のものですか、それとも標準ですか？**

エクスポートは標準の MathML（XML）を対象としています。Aspose は Presentation MathML、すなわち標準のプレゼンテーションサブセットを使用しており、アプリケーションや Web 全体で広く利用されています。

**テーブル、SmartArt、グループなど内の数式のエクスポートはサポートされていますか？**

はい、これらのオブジェクトが[MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) を含むテキスト部分（すなわち実際の PowerPoint 数式）を持つ場合はエクスポートされます。数式が画像として埋め込まれている場合はエクスポートされません。

**MathML へのエクスポートは元のプレゼンテーションを変更しますか？**

いいえ。MathML の書き出しは数式の内容をシリアライズするだけで、プレゼンテーション ファイルを変更することはありません。