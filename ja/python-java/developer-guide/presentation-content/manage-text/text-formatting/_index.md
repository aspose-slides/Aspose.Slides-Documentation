---
title: Python via Java でプレゼンテーションのテキストをフォーマットする
linktitle: テキスト書式設定
type: docs
weight: 50
url: /ja/python-java/text-formatting/
keywords:
- 段落の整列
- テキストスタイル
- テキスト背景
- テキストの透明度
- 文字間隔
- フォントプロパティ
- フォント ファミリー
- テキスト回転
- 回転角度
- テキスト フレーム
- 行間隔
- オートフィット プロパティ
- テキストフレーム アンカー
- テキストタブ
- デフォルト言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint および OpenDocument のプレゼンテーション内のテキストをフォーマットおよびスタイル設定します。フォント、色、配置などをカスタマイズできます。"
---
## **概要**

この記事では、Aspose.Slides for Python via Java を使用して PowerPoint および OpenDocument プレゼンテーションのテキストを書式設定する方法を示します。背景色、透明度、文字間隔、フォントプロパティ、回転、段落間隔、オートフィット動作、テキストのアンカリング、タブストップ、言語設定について説明します。

特に記載がない限り、例では [sample.pptx](sample.pptx) を使用します。最初のスライドの最初のシェイプはテキスト ボックスで、最初の段落に以下のテキストが含まれています。スライドとシェイプのインデックスは 0 から始まります。太字の部分を選択する例は、継承された太字書式を含む有効な書式設定を使用します：

![サンプルテキスト](sample_text.png)

文字列や正規表現の一致箇所を検索してハイライトする方法については、[テキストの検索と置換](/slides/ja/python-java/search-and-replace-text/) を参照してください。

## **テキストの背景色の設定**

段落のデフォルトハイライト色を設定するには [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) を使用し、個別のテキスト部分のハイライト色を設定するには [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getHighlightColor) を使用します。

以下の例は、最初の段落のデフォルトハイライトを薄いグレーに設定します。個別部分の明示的なハイライト色はこのデフォルトより優先されます：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # 全段落のハイライト色を設定します。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![グレイ段落](gray_paragraph.png)

次のコード例は **太字フォントのテキスト部分** の背景色を設定する方法を示します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # テキスト部分のハイライト色を設定します。
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![グレイテキスト部分](gray_text_portions.png)

## **テキスト段落の配置**

テキスト フレーム内の段落配置を設定するには [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) を使用します。値は中央揃え、左揃え、右揃え、両端揃えなどがあります。

以下のコード例は段落を **中央** に配置する方法を示します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # 段落の配置を中央に設定します。
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![配置された段落](aligned_paragraph.png)

## **行内フォントの配置**

異なるフォント サイズのテキスト部分を行内で垂直に揃えるには [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setFontAlignment) を使用します。この設定は段落全体に適用され、各行内の配置を制御します。

以下の自己完結型例は、1 つのスライド上に 4 つのラベル付きテキスト ボックスを作成します。各段落は同じテキストを 18、36、54 ポイントで表示し、フォント配置が異なります。Arial を使用し、オートフィットと折り返しを無効にし、テキスト フレームは 1 行分の幅だけ確保しています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontAlignment, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    alignments = [FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom]
    alignment_names = ["Baseline", "Top", "Center", "Bottom"]
    font_sizes = [18.0, 36.0, 54.0]
    font = FontData("Arial")

    for i, alignment in enumerate(alignments):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)

        label = text_frame.getParagraphs().get_Item(0)
        label.setText(alignment_names[i])
        label.getParagraphFormat().setAlignment(TextAlignment.Left)
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14)
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)

        paragraph = Paragraph()
        paragraph.getParagraphFormat().setFontAlignment(alignment)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        for font_size in font_sizes:
            portion = Portion("Ag ")
            portion.getPortionFormat().setFontHeight(font_size)
            paragraph.getPortions().add(portion)

        text_frame.getParagraphs().add(paragraph)

    presentation.save("font_alignment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![ベースライン、トップ、センター、ボトムのフォント配置比較](font_alignment.png)

フォント配置はフォント メトリクスに基づくため、個々の文字の見た目の端が必ずしも完全に一致するわけではありません。例では大文字とディセンダーの両方を使用してベースラインとボトム配置の違いを示しています。フォントの利用可能性や置換、使用文字、フォント サイズの違いが結果に影響します。フレームのサイズ、余白、行間、折り返し、オートフィットもレイアウトに影響するため、モードを比較する際は同じフォントとレイアウト設定を使用してください。

この設定は水平段落配置を制御する [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) や、シェイプ内でテキスト ブロックを垂直に配置する [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) とは異なります。 [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setEscapement) による上付き・下付き書式は、段落行のフォント配置を設定するのではなく、ベースラインに対して個別部分をシフトします。

## **テキストの透明度の設定**

テキストの透明度は [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat) に割り当てられた色のアルファ成分で制御します。以下の例では `alpha = 50` は 0〜255 のスケールでの ARGB アルファ値であり、透明率ではありません。

以下のコード例は **段落全体** に透明度を適用する方法を示します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # テキストの塗りつぶし色を透明色に設定します。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![透明段落](transparent_paragraph.png)

次のコード例は **太字フォントのテキスト部分** に透明度を適用する方法を示します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # テキスト部分の透明度を設定します。
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![透明テキスト部分](transparent_text_portions.png)

## **テキストの文字間隔の設定**

テキスト ボックス内の文字間隔を広げたり縮めたりするには [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpacing) を使用します。以下の例では 3 ポイントの間隔を追加しています。負の値を指定すると文字が詰まります。

以下の Python コードは **段落全体** の文字間隔を拡張する方法を示します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # 注: 文字間隔を圧縮するには負の値を使用します。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # 文字間隔を拡張します。

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![段落内の文字間隔](character_spacing_in_paragraph.png)

次のコード例は **太字フォントのテキスト部分** の文字間隔を拡張する方法を示します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # 注: 文字間隔を圧縮するには負の値を使用します。
            portion.getPortionFormat().setSpacing(3) # 文字間隔を拡張します。

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![テキスト部分の文字間隔](character_spacing_in_text_portions.png)

### **特定フォントのカーニングを無効にする**

場合によっては、Aspose.Slides がレンダリングしたテキストが PowerPoint の表示よりやや詰まって見えることがあります。これは PowerPoint が特定フォントのカーニング情報を無視するためです（フォントに有効なカーニング情報が含まれていても、PowerPoint の設定でカーニングが有効でも同様です）。

このようなケースで PowerPoint に近い出力にするには、影響を受けたフォントを使用するテキスト部分のカーニングを無効にします。 [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) に実際のフォント サイズより大きい値を設定してください。この例では、最初のスライドの最初のシェイプがテキスト ボックスである "presentation.pptx" を使用します。継承フォントを含む有効フォント名をチェックし、Roboto を使用する部分に対して 100 ポイントの閾値を設定します。これにより、フォント サイズが 100 ポイント未満の該当部分のカーニングが無効になります：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    target_font = "Roboto"

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            portion_format = portion.getPortionFormat().getEffective()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion.getPortionFormat().setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

閾値未満の該当テキストに対して、この設定はカーニングを防止し、PowerPoint 固有の動作で影響を受けるフォントの視覚的出力を Aspose.Slides のレンダリングと合わせるのに役立ちます。

## **テキスト フォント プロパティの管理**

フォント プロパティは、[ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) を使用して段落レベルで設定するか、[PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) を使用して個別部分で設定できます。

以下の例は、最初の段落のデフォルトフォントを 12 ポイントの Times New Roman に設定し、太字、斜体、点線下線を書式設定します。個別部分の明示的な書式はこれらのデフォルトより優先されます：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # 段落のフォントプロパティを設定します。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
    font = FontData("Times New Roman")
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![段落のフォント プロパティ](font_properties_for_paragraph.png)

次の例は、実際の書式が太字である部分に対して 13 ポイントの Times New Roman、斜体、点線下線を適用します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # テキスト部分のフォントプロパティを設定します。
            portion.getPortionFormat().setFontHeight(13)
            portion.getPortionFormat().setFontItalic(NullableBool.True_)
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
            font = FontData("Times New Roman")
            portion.getPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![テキスト部分のフォント プロパティ](font_properties_for_text_portions.png)

## **テキストの回転の設定**

テキストの向きをシェイプ内で事前定義されたものに設定するには [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) を使用します。

以下のコード例は、シェイプ内のテキスト向きを [TextVerticalType.Vertical270](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/) に設定し、テキストを **反時計回りに 90 度** 回転させます：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextVerticalType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![テキストの回転](text_rotation.png)

## **テキスト フレームのカスタム回転の設定**

[TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) を使用して、[TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) のカスタム回転角度を設定できます。

以下のコード例は、シェイプ内のテキスト フレームを時計回りに 3 度回転させます：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setRotationAngle(3)

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![カスタムテキスト回転](custom_text_rotation.png)

## **段落の行間隔の設定**

Aspose.Slides は [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter)、[ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) および [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) を提供し、段落間隔を制御します。使用例は以下の通りです。

* 正の値は行高さの割合として行間隔を指定します。
* 負の値はポイント単位で行間隔を指定します。

以下の例は、最初の段落の行間を行高さの 200%（二倍）に設定します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setSpaceWithin(200)

    presentation.save("line_spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![段落内の行間隔](line_spacing.png)

## **改行の制御**

段落の改行規則は、狭いテキストブロックやラテン文字と東アジア文字が混在するプレゼンテーションで有用です。以下のメソッドはすべて [ParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/) に属し、段落全体に適用されます。

- [setLatinLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) はラテン文字の改行規則を制御します。混合テキストの場合、変更すると隣接する東アジア文字や句読点の折り返し位置も変わることがあります。
- [setEastAsianLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) は東アジア文字の改行規則を制御し、行頭・行末の文字制限などを含みます。

これらの規則は、テキスト フレーム内で自動折り返しを有効にする [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText) に置き換えるものではありません。折り返しが発生した際のレイアウトに影響し、改行文字を挿入するわけではありません。明示的な改行は、幅に関係なく段落内に新しい行を強制します。

以下の自己完結型例は、中国語とラテン文字を含む狭いテキストブロックを作成し、両方の改行オプションを明示的に設定して "line_breaking.pptx" として保存します。ルールを試す際は、もう一方の設定はそのままにして該当値だけを変更してください。例では 24 ポイント Arial と SimSun を使用し、フレーム幅 160 ポイント、水平余白 0、[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) を [TextAutofitType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textautofittype/) に設定してテキスト サイズとフレーム寸法を固定しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("中文排版测试，PowerPoint 中文演示。")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    east_asian_font = FontData("SimSun")
    paragraph_format.getDefaultPortionFormat().setEastAsianFont(east_asian_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setLatinLineBreak(NullableBool.False_)
    paragraph_format.setEastAsianLineBreak(NullableBool.True_)

    presentation.save("line_breaking.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ハンギング句読点の制御**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setHangingPunctuation) を使用すると、対象となる句読点がテキスト行の右端を超えて伸び、次の行に占有されないようにできます。段落全体に適用され、ハンギング インデントとは異なります。

以下の自己完結型例は、幅 100 ポイントのテキスト フレームでハンギング句読点を有効にし、"hanging_punctuation.pptx" として保存します。24 ポイント Arial と水平余白 0 の設定で、最後のピリオドは "sentence" の後に残り、右端を超えて表示されます。比較のためにプロパティを [NullableBool.False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) に設定すると、ピリオドが別行に配置されます。折り返しは有効で、オートフィットは無効にして幅を固定しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("Simple text, next sentence.")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setHangingPunctuation(NullableBool.True_)

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

すべての句読点がハンギングできるわけではありません。上記の [フォントおよびレイアウト条件](#control-line-breaking) も比較に影響します。フォント、利用可能幅、余白、オートフィット設定を変更すると、見た目の違いが消えることがあります。

## **テキスト フレームのオートフィット タイプの設定**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) は、テキストがコンテナの境界を超えたときの動作を決定します。テキストを縮小するか、はみ出すか、シェイプを自動でリサイズするかを制御できます。以下の例はシェイプをテキストに合わせてリサイズし、結果を "autofit_type.pptx" として保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAutofitType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape)

    presentation.save("autofit_type.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

自動折り返し後の行数を確認し、テキストまたはシェイプ幅の変化が結果に与える影響を確認するには、[レンダリングされた行数のカウント](/slides/ja/python-java/manage-paragraph/) を参照してください。行数だけではテキストがコンテナをはみ出しているかどうかは判断できません。

## **テキスト フレームのアンカーの設定**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) は、シェイプ内でテキストを垂直に配置する方法（上部、中央、下部など）を定義します。以下の例はテキストを最初のシェイプの下部にアンカーし、結果を "text_anchor.pptx" として保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAnchorType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom)

    presentation.save("text_anchor.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **テキスト タブの設定**

[ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) と [ParagraphFormat.getTabs](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getTabs) を使用して、段落内のタブストップを構成します。以下の例はデフォルトタブ間隔を 100 ポイントに設定し、30 ポイント位置に左揃えタブストップを追加します。これらの設定はタブ文字を含むテキストに影響します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TabAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setDefaultTabSize(100)
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left)

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![段落のタブ](paragraph_tabs.png)

## **校正言語の設定**

Aspose.Slides は [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId) を提供し、テキスト部分の校正言語を設定できます。校正言語は PowerPoint のスペルチェックや文法チェックに使用される言語を決定します。

以下の例は、最初のスライドの最初のシェイプがテキスト ボックスである "presentation.pptx" を使用し、最初の段落の内容を "1。" に置き換え、フォントを SimSun に設定し、校正言語を簡体字中国語 (`zh-CN`) に設定します。結果は "proofing_language.pptx" として保存されます：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Portion, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    font = FontData("SimSun")

    text_portion = Portion()
    text_portion.getPortionFormat().setComplexScriptFont(font)
    text_portion.getPortionFormat().setEastAsianFont(font)
    text_portion.getPortionFormat().setLatinFont(font)

    # 校正言語の ID を設定します。
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **デフォルト言語の設定**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) を使用して、プレゼンテーションの読み込みまたは作成時に作成されるテキストのデフォルト言語を定義できます。以下の例はデフォルトテキスト言語を米国英語に設定したプレゼンテーションを作成し、テキスト ボックスを追加して最初のテキスト部分の言語を `en-US` と出力します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    # 矩形シェイプをテキスト付きで追加します。
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # 最初の部分の言語を確認します。
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **デフォルト テキスト スタイルの設定**

プレゼンテーション レベルでデフォルトのテキスト書式設定を適用するには、[Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDefaultTextStyle) を使用します。

以下の例は、新規プレゼンテーションのトップレベル段落のデフォルトとして 14 ポイントの太字フォントを設定し、"default_text_style.pptx" として保存します。テキストはこれらのデフォルトを継承しますが、より具体的な書式設定が上書きします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # トップレベルの段落書式を取得します。
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **All Caps 効果でテキストを抽出する**

PowerPoint では **All Caps** フォント効果を適用すると、スライド上では大文字で表示されますが、実際に入力された文字列は小文字のままです。Aspose.Slides でそのテキスト部分を取得すると、元の入力通りの文字列が返されます。表示通りに取得するには、[TextCapType](https://reference.aspose.com/slides/python-java/aspose.slides/textcaptype/) を確認し、値が `All` の場合は返された文字列を大文字に変換します。

この例は、最初のスライドの最初のシェイプがテキスト ボックスである "sample2.pptx" を使用します。最初の段落の最初の部分に All Caps 効果が適用された "Hello, Aspose!" が含まれています（以下画像参照）。

![All Caps 効果](all_caps_effect.png)

以下のコード例は **All Caps** 効果が適用されたテキストを抽出する方法を示します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TextCapType

presentation = Presentation("sample2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    auto_shape = slide.getShapes().get_Item(0)
    text_portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)

    print("Original text: " + str(text_portion.getText()))

    text_format = text_portion.getPortionFormat().getEffective()
    if text_format.getTextCapType() == TextCapType.All:
        text = str(text_portion.getText()).upper()
        print("All-Caps effect: " + text)
finally:
    presentation.dispose()
```

出力:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**スライド上のテーブルのテキストを変更するにはどうすればよいですか？**

テーブルのテキストを変更するには、[Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) を使用します。セルを走査し、各セルを [Cell.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) で取得し、段落書式を [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat) で更新します。

**PowerPoint スライドのテキストにグラデーションカラーを適用するにはどうすればよいですか？**

グラデーションカラーを適用するには、[BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat) を使用します。[FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) を [FillType.Gradient](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) に設定し、グラデーション ストップ、方向、透明度を構成します。