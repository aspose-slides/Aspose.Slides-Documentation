---
title: Python でプレゼンテーションから数式をエクスポート
linktitle: 数式をエクスポート
type: docs
weight: 30
url: /ja/python-java/exporting-math-equations/
keywords:
- 数式をエクスポート
- 数式を LaTeX にエクスポート
- PowerPoint から LaTeX へ
- MathML
- LaTeX
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Java を介した Python 用 Aspose.Slides で、PowerPoint プレゼンテーションから数式を直接 LaTeX または MathML にエクスポートします。"
---
## **はじめに**

Aspose.Slides はプレゼンテーションから数式をエクスポートできます。たとえば、特定のプレゼンテーションのスライドから数式を抽出し、別のプログラムやプラットフォームで使用する必要がある場合があります。

{{% alert color="info" title="Note" %}} 
数式は LaTeX または MathML に直接エクスポートできます。MathML は Web や多くのアプリケーションで使用されている数式コンテンツの一般的な標準です。
{{% /alert %}}

## **LaTeX への数式エクスポート**

Aspose.Slides は PowerPoint の数式を直接 LaTeX に変換できます。中間の MathML ファイルや外部コンバータは不要です。数式はテキスト フレーム内に [MathPortion](https://reference.aspose.com/slides/ja/python-java/aspose.slides/mathportion/) として格納されています。[MathPortion.getMathParagraph](https://reference.aspose.com/slides/ja/python-java/aspose.slides/mathportion/#getMathParagraph) を使用して [MathParagraph](https://reference.aspose.com/slides/ja/python-java/aspose.slides/mathparagraph/) を取得し、続いて [MathParagraph.toLatex](https://reference.aspose.com/slides/ja/python-java/aspose.slides/mathparagraph/#toLatex) を呼び出します。このメソッドは文字列を返し、保存、表示、別のアプリケーションへの送信、またはさらに処理できます。

次のサンプルは、すべてのスライドのすべてのテキスト フレームを調べ、すべての MathPortion を検出し、各数式を個別の `.tex` ファイルに書き出します：

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathPortion, Presentation, SlideUtil

presentation = Presentation("equations.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide_index + 1
        equation_number = 1
        text_frames = SlideUtil.getAllTextBoxes(slide)

        for text_frame in text_frames:
            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    if not isinstance(portion, MathPortion):
                        continue

                    math_paragraph = portion.getMathParagraph()
                    latex_file_name = f"slide_{slide_number}_equation_{equation_number}.tex"
                    latex_text = math_paragraph.toLatex()
                    latex_path = Path(latex_file_name)
                    latex_path.write_text(str(latex_text), encoding="utf-8")
                    equation_number += 1
finally:
    presentation.dispose()
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideutil/#getAllTextBoxes) はスライド上で見つかったすべてのテキスト フレームを返します。[MathPortion](https://reference.aspose.com/slides/ja/python-java/aspose.slides/mathportion/) の型チェックにより、通常のテキストや画像と区別して、実際に編集可能な数式を分離します。

LaTeX エンジンやドキュメント テンプレートはすべて同じコマンド、パッケージ、Unicode 文字をサポートしているわけではありません。返された文字列を、アプリケーションで使用している LaTeX エンジンでテストしてください。その環境でシンボルや Office Math 要素に適切な表現がない場合は、返された文字列内でプロジェクト固有のコマンドに置き換えるか、数式をスキップして問題を記録し、後でレビューできるようにしてください。

## **MathML として数式を保存**

LaTeX などの一部の数式フォーマット用のコードは比較的簡単に書くことができますが、MathML は手動で書くのが難しいです。なぜなら、アプリケーションが自動的に生成することを前提に設計されているからです。MathML は XML ベースであるため、プログラムが簡単に読み取り・解析でき、さまざまな分野で出力および印刷フォーマットとして広く利用されています。

このサンプル コードは、プレゼンテーションから数式を MathML にエクスポートする方法を示しています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText, Presentation
from java.io import FileOutputStream

presentation = Presentation()
try:
    math_shape = presentation.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50)
    math_portion = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    math_paragraph = math_portion.getMathParagraph()

    a_squared = MathematicalText("a").setSuperscript("2")
    b_squared = MathematicalText("b").setSuperscript("2")
    c_squared = MathematicalText("c").setSuperscript("2")
    equation = a_squared.join("+").join(b_squared).join("=").join(c_squared)
    math_paragraph.add(equation)

    stream = FileOutputStream("mathml.xml")
    try:
        math_paragraph.writeAsMathMl(stream)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

## **よくある質問**

**MathML にエクスポートされるのは、段落全体ですか、それとも個々の数式ブロックですか？**

MathML へは、全体の数式段落（[MathParagraph](https://reference.aspose.com/slides/ja/python-java/aspose.slides/mathparagraph/)）または個別のブロック（[MathBlock](https://reference.aspose.com/slides/ja/python-java/aspose.slides/mathblock/)）のいずれかをエクスポートできます。両方のタイプには MathML に書き出すためのメソッドが用意されています。

**スライド上のオブジェクトが通常のテキストや画像ではなく数式であることをどうやって判別できますか？**

数式は [MathPortion](https://reference.aspose.com/slides/ja/python-java/aspose.slides/mathportion/) に格納されており、[MathParagraph](https://reference.aspose.com/slides/ja/python-java/aspose.slides/mathparagraph/) を持っています。[MathParagraph](https://reference.aspose.com/slides/ja/python-java/aspose.slides/mathparagraph/) を持たない画像や通常のテキスト部分はエクスポート可能な数式ではありません。

**プレゼンテーション内の MathML はどこから来るのですか—PowerPoint 固有ですか、それとも標準ですか？**

エクスポートは標準の MathML（XML）を対象としています。Aspose は Presentation MathML（標準のプレゼンテーション用サブセット）を使用しており、これはアプリケーションや Web 全体で広く使用されています。

**表、SmartArt、グループなど内部の数式のエクスポートはサポートされていますか？**

はい、これらのオブジェクトが [MathParagraph](https://reference.aspose.com/slides/ja/python-java/aspose.slides/mathparagraph/) を含むテキスト部分（すなわち実際の PowerPoint 数式）を持っていればエクスポートされます。数式が画像として埋め込まれている場合はエクスポートされません。

**MathML へのエクスポートは元のプレゼンテーションを変更しますか？**

いいえ。MathML の書き出しは数式の内容をシリアライズするだけで、プレゼンテーション ファイルは変更されません。