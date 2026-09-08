---
title: Python via Java でのプレゼンテーションからの高度なテキスト抽出
linktitle: テキスト抽出
type: docs
weight: 90
url: /ja/python-java/extract-text-from-presentation/
keywords:
- テキスト抽出
- スライドからテキスト抽出
- プレゼンテーションからテキスト抽出
- PowerPoint からテキスト抽出
- OpenDocument からテキスト抽出
- PPT からテキスト抽出
- PPTX からテキスト抽出
- ODP からテキスト抽出
- テキスト取得
- スライドからテキスト取得
- プレゼンテーションからテキスト取得
- PowerPoint からテキスト取得
- OpenDocument からテキスト取得
- PPT からテキスト取得
- PPTX からテキスト取得
- ODP からテキスト取得
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint および OpenDocument のプレゼンテーションからテキストを迅速に抽出します。シンプルなステップバイステップのガイドに従えば、時間を節約できます。"
---
## **概要**

プレゼンテーションからテキストを抽出することは、スライドコンテンツを扱う開発者にとって一般的でありながら重要な作業です。Microsoft PowerPoint の PPT または PPTX 形式、あるいは OpenDocument プレゼンテーション（ODP）を取り扱う場合でも、テキストデータへのアクセスと取得は、分析、Automation、インデックス作成、コンテンツ移行などの目的で重要になることがあります。

本稿では、Aspose.Slides for Python via Java を使用して、PPT、PPTX、ODP などのさまざまなプレゼンテーション形式からテキストを効率的に抽出するための包括的な手順を紹介します。プレゼンテーション要素を体系的に走査し、必要なテキストコンテンツを正確に取得する方法を学びます。

## **スライドからテキストを抽出する**

Aspose.Slides for Python via Java は [SlideUtil](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideutil/) クラスを提供します。このクラスは、プレゼンテーションまたはスライドからすべてのテキストを抽出するための複数のオーバーロードされた静的メソッドを公開しています。プレゼンテーション内のスライドからテキストを抽出するには、[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideutil/#getAllTextBoxes) メソッドを使用します。このメソッドは [BaseSlide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslide/) 型のオブジェクトをパラメーターとして受け取ります。実行すると、メソッドはスライド全体を走査してテキストを検出し、[TextFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/) 型のオブジェクト配列を返し、テキストの書式情報を保持します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

slide_index = 0

presentation = Presentation("demo.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    text_frames = SlideUtil.getAllTextBoxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **プレゼンテーションからテキストを抽出する**

プレゼンテーション全体のテキストを走査するには、[SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideutil/#getAllTextFrames) 静的メソッドを使用します。このメソッドは次の 2 つのパラメーターを受け取ります。

1. 最初に、テキスト抽出元となる PowerPoint または OpenDocument のプレゼンテーションを表す [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) オブジェクト。
2. 次に、プレゼンテーションのテキスト走査時にマスタースライドを含めるかどうかを示す `bool` 値。

メソッドは [TextFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/) 型のオブジェクト配列を返し、テキスト書式情報を含みます。以下のコードは、プレゼンテーション（マスタースライドを含む）からテキストと書式情報を走査します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

presentation = Presentation("demo.pptx")
try:
    include_master_slides = True
    text_frames = SlideUtil.getAllTextFrames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **カテゴリ別かつ高速なテキスト抽出**

[PresentationFactory](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationfactory/) クラスも、プレゼンテーションからすべてのテキストを抽出するメソッドを提供します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationFactory, TextExtractionArrangingMode
from java.io import FileInputStream

mode = TextExtractionArrangingMode.Unarranged
load_options = LoadOptions()

# ファイルからテキストを抽出します。
file_text = PresentationFactory.getInstance().getPresentationText("presentation.pptx", mode)

# ストリームからテキストを抽出します。
stream = FileInputStream("presentation.pptx")
try:
    stream_text = PresentationFactory.getInstance().getPresentationText(stream, mode)
finally:
    stream.close()

# ロードオプションを使用してストリームからテキストを抽出します。
stream_with_options = FileInputStream("presentation.pptx")
try:
    stream_text_with_options = PresentationFactory.getInstance().getPresentationText(stream_with_options, mode, load_options)
finally:
    stream_with_options.close()
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textextractionarrangingmode/) 列挙体の引数は、テキスト抽出結果の整理モードを示し、次の値に設定できます。

- [Unarranged](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textextractionarrangingmode/#Unarranged) - スライド上の位置を考慮せずに取得した生テキスト。
- [Arranged](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textextractionarrangingmode/#Arranged) - スライド上の順序と同じ順序でテキストが配置されます。

速度が重要な場合は、整理されていないモード（Unarranged）を使用できます。こちらの方が整理モード（Arranged）よりも高速です。

[PresentationText](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationtext/) はプレゼンテーションから抽出された生テキストを表します。その [getSlidesText](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationtext/#getSlidesText) メソッドは `SlideText` 型オブジェクトの配列を返します。各オブジェクトは対応するスライド上のテキストを表します。`SlideText` 型のオブジェクトには次のメソッドがあります。

- `getText` - スライドのシェイプ内のテキスト。
- `getMasterText` - 当該スライドに関連付けられたマスタースライドのシェイプ内のテキスト。
- `getLayoutText` - 当該スライドに関連付けられたレイアウトスライドのシェイプ内のテキスト。
- `getNotesText` - 当該スライドに関連付けられたノートスライドのシェイプ内のテキスト。
- `getCommentsText` - 当該スライドに関連付けられたコメント内のテキスト。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, TextExtractionArrangingMode

presentation_path = "presentation.ppt"
arranging_mode = TextExtractionArrangingMode.Unarranged
presentation_text = PresentationFactory.getInstance().getPresentationText(presentation_path, arranging_mode)
first_slide_text = presentation_text.getSlidesText()[0]

print(first_slide_text.getText())
print(first_slide_text.getLayoutText())
print(first_slide_text.getMasterText())
print(first_slide_text.getNotesText())
print(first_slide_text.getCommentsText())
```

## **FAQ**

**Aspose.Slides はテキスト抽出時に大規模プレゼンテーションをどれくらい高速に処理できますか？**

Aspose.Slides は高性能に最適化されており、[大規模プレゼンテーション](/slides/ja/python-java/open-presentation/) でも処理できるため、リアルタイムまたはバルク処理シナリオに適しています。

**Aspose.Slides はプレゼンテーション内の表やグラフからテキストを抽出できますか？**

はい。Aspose.Slides は表やチャート関連オブジェクトを含む多数のスライド要素からテキストを抽出できるため、一般的なプレゼンテーション構造内のテキストコンテンツにアクセスして分析できます。

**プレゼンテーションからテキストを抽出するために特別な Aspose.Slides ライセンスが必要ですか？**

無料試用版でもテキスト抽出は可能ですが、[特定の制限](/slides/ja/python-java/licensing/) があり、処理できるスライド数が制限されます。制限なく利用し、より大きなプレゼンテーションを扱う場合は、フルライセンスの購入が推奨されます。