---
title: Python でプレゼンテーションから数式をエクスポート
linktitle: 数式をエクスポート
type: docs
weight: 30
url: /ja/python-net/exporting-math-equations/
keywords:
- 数式のエクスポート
- LaTeX への数式エクスポート
- PowerPoint から LaTeX へ
- MathML
- LaTeX
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint プレゼンテーションから数式を LaTeX または MathML に直接エクスポートします。"
---
## **はじめに**

Aspose.Slides for Python via .NET を使用すると、プレゼンテーションから数式をエクスポートできます。たとえば、特定のスライドから数式を抽出し、別のプログラムやプラットフォームで再利用する必要がある場合があります。

{{% alert color="primary" %}}
数式は LaTeX または MathML に直接エクスポートできます。MathML はウェブや多くのアプリケーションで使用されている、数学コンテンツ用の一般的な標準です。
{{% /alert %}}

## **数式を LaTeX にエクスポートする**

Aspose.Slides は PowerPoint の数式を直接 LaTeX に変換できます。中間の MathML ファイルや外部コンバータは不要です。数式はテキストフレーム内に [MathPortion](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/mathportion/) として格納されています。[MathPortion.math_paragraph](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) を使用して [MathParagraph](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/mathparagraph/) を取得し、続いて [MathParagraph.to_latex](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) を呼び出します。このメソッドは文字列を返し、保存・表示・他のアプリケーションへの送信、またはさらに処理することができます。

以下の例は、すべてのスライド上のすべてのテキストフレームを調べ、すべての MathPortion を見つけ、各数式を別々の `.tex` ファイルに書き出します。

```py
import aspose.slides as slides

with slides.Presentation("equations.pptx") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        equation_number = 1
        text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

        for text_frame in text_frames:
            for paragraph in text_frame.paragraphs:
                for portion in paragraph.portions:
                    if not isinstance(portion, slides.mathtext.MathPortion):
                        continue

                    math_paragraph = portion.math_paragraph
                    latex_path = f"slide_{slide_number}_equation_{equation_number}.tex"

                    latex_text = math_paragraph.to_latex()
                    with open(latex_path, "w", encoding="utf-8") as latex_file:
                        latex_file.write(latex_text)
                    equation_number += 1
```

[SlideUtil.get_all_text_boxes](https://reference.aspose.com/slides/ja/python-net/aspose.slides.util/slideutil/get_all_text_boxes/) はスライド上で見つかったすべてのテキストフレームを返します。[MathPortion](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/mathportion/) の型チェックにより、通常のテキストや画像と区別して実際に編集可能な数式を分離します。

LaTeX エンジンやドキュメントテンプレートはすべて同じコマンド、パッケージ、Unicode 文字をサポートしているわけではありません。返された文字列を、アプリケーションで使用している LaTeX エンジンでテストしてください。シンボルや Office Math 要素に適切な表現がない場合は、返された文字列内でプロジェクト固有のコマンドに置き換えるか、数式をスキップし、問題を記録してレビューしてください。

## **数式を MathML として保存する**

人間が LaTeX を簡単に記述できる一方で、MathML は通常アプリケーションによって自動的に生成されます。MathML は XML ベースであるため、プログラムは信頼性高く読み取り・解析でき、多くの分野で出力および印刷フォーマットとして広く使用されています。

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

**MathML にエクスポートされるのは、段落全体ですか、それとも個々の数式ブロックですか？**

MathML には、全体の数式段落 ([MathParagraph](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/mathparagraph/)) または個々のブロック ([MathBlock](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/mathblock/)) のいずれかをエクスポートできます。どちらのタイプも MathML に書き出すためのメソッドを提供しています。

**スライド上のオブジェクトが通常のテキストや画像ではなく数式であることは、どのように判断できますか？**

数式は [MathPortion](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/mathportion/) に存在し、[MathParagraph](https://reference.aspose.com/slides/ja/python-net/aspose.slides.mathtext/mathparagraph/) を持っています。[MathParagraph] を持たない画像や通常のテキスト部分はエクスポート可能な数式ではありません。

**プレゼンテーション内の MathML はどこから来るのですか—PowerPoint 固有ですか、標準ですか？**

エクスポートは標準の MathML (XML) を対象としています。Aspose は Presentation MathML、すなわち標準のプレゼンテーションサブセットを使用しており、アプリケーションやウェブ全体で広く利用されています。

**テーブル、SmartArt、グループなど内部の数式のエクスポートはサポートされていますか？**

はい、これらのオブジェクトが [MathParagraph] を含むテキスト部分（つまり実際の PowerPoint 数式）を持つ場合はエクスポートされます。数式が画像として埋め込まれている場合はエクスポートされません。

**MathML へのエクスポートは元のプレゼンテーションを変更しますか？**

いいえ。MathML の書き出しは数式の内容をシリアライズするだけで、プレゼンテーション ファイルを変更することはありません。