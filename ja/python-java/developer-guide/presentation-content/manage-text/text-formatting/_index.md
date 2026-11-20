---
title: Python via Java でプレゼンテーションテキストをフォーマットする
linktitle: テキストの書式設定
type: docs
weight: 50
url: /ja/python-java/text-formatting/
keywords:
- 段落の配置
- テキストスタイル
- テキストの背景
- テキストの透明度
- 文字間隔
- フォントプロパティ
- フォントファミリー
- テキストの回転
- 回転角度
- テキストフレーム
- 行間
- オートフィットプロパティ
- テキストフレームのアンカー
- テキストタブ設定
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

この記事では、Aspose.Slides for Python via Java を使用して PowerPoint および OpenDocument のプレゼンテーションでテキストを書式設定する方法を示します。背景色、透明度、文字間隔、フォントプロパティ、回転、段落間隔、オートフィット動作、テキストのアンカリング、タブストップ、言語設定をカバーします。

特に記載がない限り、例では [sample.pptx](sample.pptx) を使用します。最初のスライドの最初の図形はテキスト ボックスで、最初の段落には以下のテキストが含まれます。スライドと図形のインデックスはゼロベースです。太字部分を選択する例は、継承された太字書式を含む有効な書式設定を使用します。

![サンプルテキスト](sample_text.png)

リテラルテキストや正規表現の一致箇所を検索してハイライトする方法については、[テキストの検索と置換](/slides/ja/python-java/search-and-replace-text/) を参照してください。

## **テキストの背景色を設定する**

段落のデフォルトハイライト色を設定するには [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) を使用し、個々のテキスト部分のハイライト色を設定するには [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getHighlightColor) を使用します。

以下の例は、最初の段落のデフォルトとして薄い灰色のハイライトを設定します。個々の部分で明示的にハイライト色を指定すると、デフォルトよりも優先されます。

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

    # 段落全体のハイライト色を設定します。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![灰色の段落](gray_paragraph.png)

次のコード例は、**太字フォント** を使用した **テキスト部分** の背景色を設定する方法を示します。

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

![灰色のテキスト部分](gray_text_portions.png)

## **テキスト段落を揃える**

テキストフレーム内の段落揃えを設定するには [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) を使用します。値は中央揃え、左揃え、右揃え、両端揃えなどがあります。

以下のコード例は、段落を **中央** に揃える方法を示します。

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

![揃えられた段落](aligned_paragraph.png)

## **行内のフォントを揃える**

異なるフォントサイズのテキスト部分を同一行内で垂直揃えするには [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setFontAlignment) を使用します。この設定は段落全体に適用され、各行内の揃えを制御します。

以下の自己完結型例は、1 枚のスライドに 4 つのラベル付きテキスト ボックスを作成します。各段落は同じテキストを 18、36、54 ポイントで表示し、フォント揃えをそれぞれ変更します。Arial を使用し、オートフィットと折り返しを無効にし、テキストフレームは単一行が収まるサイズに保ちます。

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

![ベースライン、上部、中央、下部のフォント揃えの比較](font_alignment.png)

フォント揃えはフォントメトリックに基づくため、個々の文字の可視端が正確に一致するとは限りません。例では大文字と下付き文字を含め、ベースラインと下部揃えの違いを示しています。フォントの可用性と置換、使用文字、フォントサイズの違いが結果に影響します。フレームサイズ、余白、行間、折り返し、オートフィットもレイアウトに影響するため、モード比較時は同じフォントとレイアウト設定を使用してください。

この設定は、水平段落揃えを制御する [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) およびテキストブロックを図形内で垂直に配置する [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) とは異なります。上付・下付の書式設定は、[BasePortionFormat.setEscapement](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setEscapement) を使用して個々の部分をベースラインからシフトさせるもので、段落行のフォント揃えを設定するものではありません。

## **テキストの透明度を設定する**

テキストの透明度は、[BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat) に割り当てた色のアルファ成分で制御します。以下の例では `alpha = 50` は 0〜255 のスケールの ARGB アルファ値であり、透明度パーセンテージではありません。

次のコード例は、**段落全体** に透明度を適用する方法を示します。

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

![透明な段落](transparent_paragraph.png)

次のコード例は、**太字フォント** を使用したテキスト部分に透明度を適用する方法を示します。

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

![透明なテキスト部分](transparent_text_portions.png)

## **テキストの文字間隔を設定する**

テキスト ボックス内の文字間隔を拡大または縮小するには [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpacing) を使用します。例では 3 ポイントの間隔を追加します。負の値を指定するとテキストが凝縮されます。

以下の Python コードは、**段落全体** の文字間隔を拡大する方法を示します。

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

    # 注: 文字間隔を縮めるには負の値を使用します。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # 文字間隔を拡張します。

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![段落内の文字間隔](character_spacing_in_paragraph.png)

次のコード例は、**太字フォント** を使用したテキスト部分の文字間隔を拡大する方法を示します。

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
            # 注: 文字間隔を縮めるには負の値を使用します。
            portion.getPortionFormat().setSpacing(3) # 文字間隔を拡張します。

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![テキスト部分の文字間隔](character_spacing_in_text_portions.png)

### **特定フォントのカーニングを無効にする**

場合によっては、Aspose.Slides が生成するテキストが PowerPoint の表示よりやや詰まって見えることがあります。これは、PowerPoint が特定フォントのカーニングデータを無視するためです。

このような場合に PowerPoint の表示に近づけるには、該当フォントを使用するテキスト部分のカーニングを無効にできます。実際のフォントサイズより大きい値を [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) に設定します。以下の例は、最初のスライドの最初の図形がテキスト ボックスである「presentation.pptx」を前提とし、継承フォントを含む有効フォント名をチェックし、Roboto を使用する部分に対して 100 ポイントの閾値を設定します。これにより、100 ポイント未満の Roboto 部分のカーニングが無効になります。

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

閾値未満の該当テキストについては、カーニングが無効となり、PowerPoint 固有の動作で影響を受けるフォントの表示を Aspose.Slides のレンダリングと合わせるのに役立ちます。

## **テキストフォントプロパティを管理する**

フォントプロパティは、[ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) を使用して段落レベルで設定するか、[PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) を使用して個々の部分で設定できます。

以下の例は、最初の段落のデフォルトフォントを 12 ポイントの Times New Roman に設定し、太字、斜体、点線下線を適用します。個別の部分で明示的に設定した書式は、これらのデフォルトよりも優先されます。

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

![段落のフォントプロパティ](font_properties_for_paragraph.png)

次の例は、効果的な書式が太字である部分に対して 13 ポイントの Times New Roman、斜体、点線下線を適用します。

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

![テキスト部分のフォントプロパティ](font_properties_for_text_portions.png)

## **テキスト高さの正規化を制御する**

テンプレートのタイポグラフィを再現したり文字高さの違いを調査したりする際は、[BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setNormaliseHeight) を使用します。PowerPoint では、正規化を有効にすると個々の文字が垂直方向に伸縮し、テキスト部分内で均一な可視高さになりますが、フォント間で同じ高さになることは保証されません。

[NullableBool.True_ or False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) を設定して正規化を明示的に有効または無効にします。`NullableBool.NotDefined` はローカル設定を未設定のままにし、段落の [getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) から継承されます。`False` とは意味が異なります。正規化の有効状態は、[PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) で取得し、`getNormaliseHeight` を確認してください。

以下の自己完結型例は **Arial** がインストールされていることが前提です。54 ポイントの大文字・小文字・下付き文字・アクセント文字を含む 2 つのテキスト ブロックを作成します。両方の段落は既定で正規化を有効にしています。上部の部分は明示的に無効にし、下部は継承します。フレームサイズ、余白、段落間隔は同一で、折り返しとオートフィットは無効にして比較を一定に保ちます。例は `False: False` と `NotDefined: True` を出力し、"text_height_normalization.pptx" を保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    settings = [NullableBool.False_, NullableBool.NotDefined]
    setting_names = ["False", "NotDefined"]

    for i, setting in enumerate(settings):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.setText("Hxgjpq ÅÉ 0123")
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setMarginTop(0)
        text_frame.getTextFrameFormat().setMarginLeft(0)

        paragraph = text_frame.getParagraphs().get_Item(0)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().setSpaceBefore(0)
        paragraph.getParagraphFormat().setSpaceAfter(0)
        paragraph.getParagraphFormat().setSpaceWithin(100)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(NullableBool.True_)

        portion = paragraph.getPortions().get_Item(0)
        font = FontData("Arial")
        portion.getPortionFormat().setLatinFont(font)
        portion.getPortionFormat().setFontHeight(54)
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
        portion.getPortionFormat().setNormaliseHeight(setting)

        print(f"{setting_names[i]}: {bool(portion.getPortionFormat().getEffective().getNormaliseHeight())}")

    presentation.save("text_height_normalization.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

以下の比較は保存されたプレゼンテーションからエクスポートしたものです。上段は正規化が無効 (`False`) で、下段は有効 (`NotDefined` → `True`) が継承されています。Arial をインストールした状態で実行してください。

![Arial 54 ポイントのテキスト（上段は正規化無効、下段は継承で有効）](text_height_normalization.png)

正規化は割り当てられた [getFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFontHeight) の値を変更せずに文字高さを変えます。段落の [setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) は行間を制御し、テキストフレームの [setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) はテキストまたはコンテナのサイズ調整方法を制御します。これらの設定は別々の目的を持ち、レイアウトに個別に影響します。段落書式と継承の詳細は、[段落の管理](/slides/ja/python-java/manage-paragraph/) を参照してください。

## **取り消し線の適用と削除**

テキスト部分に [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setStrikethroughType) を設定すると、元のテキストを削除せずに訂正やキャンセル、以前の価格を表示できます。1 本線または 2 本線の取り消し線はそれぞれ [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/) を使用します。

取り消し線を削除するには [TextStrikethroughType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#None) を指定します。これにより、周囲の書式が取り消し線を指定していても効果が明示的に無効化されます。一方、[TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#NotDefined) はローカル設定を未定義のままにし、段落などから継承させます。取り消し線が削除されることを保証するものではありません。結果の書式は、継承値を含めて [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) で取得してください。

以下の自己完結型例は、3 つの価格比較を作成します。各段落はラベル、以前の価格、現在の価格の部分に分かれており、以前の価格のみに取り消し線が適用されます。最初の行は取り消し線を適用した後に削除し、他の行は単一本線と二本線の取り消し線を保持します。この設定を変更すると、テキストとそのほかの書式（太字の以前の価格など）を保持したまま表示が変わります。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextStrikethroughType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 620, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = Paragraph()
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().setSpaceAfter(20)

        portion_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
        portion_format.setFontHeight(28)
        font = FontData("Arial")
        portion_format.setLatinFont(font)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        label_portion = Portion(label)
        paragraph.getPortions().add(label_portion)

        previous_price = Portion("$100")
        previous_price.getPortionFormat().setFontBold(NullableBool.True_)
        paragraph.getPortions().add(previous_price)
        current_price = Portion(" → $80")
        paragraph.getPortions().add(current_price)

        shape.getTextFrame().getParagraphs().add(paragraph)

    paragraphs = shape.getTextFrame().getParagraphs()

    # 取り消し線を適用し、次に最初の以前の価格から明示的に削除します。
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None_)

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double)

    presentation.save("strikethrough.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果（上から順に）：取り消し線なし、単一本線、二本線。

![取り消し線がない、単一本線、二本線の以前の価格](strikethrough.png)

## **テキストの回転を設定する**

テキストの向きを事前定義されたものに設定するには、[TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) を使用します。

以下のコード例は、テキストの向きを [TextVerticalType.Vertical270](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/) に設定し、テキストを **反時計回りに 90 度** 回転させます。

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

## **テキストフレームのカスタム回転を設定する**

[TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) を使用して、[TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) のカスタム回転角度を設定できます。

以下のコード例は、図形内のテキストフレームを時計回りに 3 度回転させます。

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

## **段落の行間を設定する**

Aspose.Slides は、[ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter)、[ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore)、[ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) を提供し、段落間隔を制御します。これらのプロパティは次のように使用します。

* 正の値は行の高さのパーセンテージとして行間を指定します。
* 負の値はポイント単位で行間を指定します。

以下の例は、最初の段落の行間を行高さの 200%（二重行間）に設定します。

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

![段落内の行間](line_spacing.png)

## **改行の制御**

段落の改行規則は、狭いテキストブロックやラテン文字と東アジア文字が混在するプレゼンテーションで有用です。これらのメソッドは [ParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/) に属し、段落全体に適用されます。

* [setLatinLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) はラテン文字の改行規則を制御します。混在テキストの場合、隣接する東アジア文字や句読点の折り返し位置にも影響します。
* [setEastAsianLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) は東アジア文字の改行規則を制御し、行頭や行末の文字制限を含みます。

これらの規則は [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText)（テキストフレーム内の自動折り返し）に置き換えるものではなく、折り返しが発生したときのレイアウトに影響します。改行文字を挿入するわけではありません。明示的な改行は、利用可能幅に関係なく段落内で新しい行を強制します。

以下の自己完結型例は、中文とラテン文字を含む狭いテキストブロックを作成し、両方の改行オプションを明示的に設定して "line_breaking.pptx" に保存します。任意の規則を試すには、もう一方の設定を固定したまま対応する値を変更してください。例では 24 ポイントの Arial と SimSun、幅 160 ポイント、水平余白 0 のフレームを使用します。[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) は [TextAutofitType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textautofittype/) に設定し、テキストサイズとフレームサイズを固定します。

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

## **ぶら下げ句読点を制御する**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setHangingPunctuation) を使用すると、対象となる句読点がテキスト行の右端を超えて伸び、次の行を占有しないようにできます。段落全体に適用され、ぶら下げインデントとは異なります。

以下の自己完結型例は、幅 100 ポイントのテキストフレームでぶら下げ句読点を有効にし、"hanging_punctuation.pptx" に保存します。24 ポイントの Arial と水平余白 0 の設定で、最終的な句点が "sentence" の後に残り、右端を超えて表示されます。比較のためにプロパティを [NullableBool.False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) に設定すると、句点が別行に移動します。折り返しは有効、オートフィットは無効にして幅を固定しています。

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

すべての句読点がぶら下げ可能というわけではありません。上記の [フォントとレイアウト条件](#control-line-breaking) も比較に影響します。フォント、利用可能幅、余白、オートフィット設定を変更すると、視覚的な違いが消えることがあります。

## **テキストフレームのオートフィットタイプを設定する**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) は、テキストがコンテナの境界を超えたときの動作を決定します。テキストが縮小するか、はみ出すか、図形が自動的にサイズ変更されるかを制御します。以下の例は、テキストに合わせて図形をリサイズするよう設定し、結果を "autofit_type.pptx" に保存します。

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

自動折り返し後の行数やテキスト・図形幅の変化を確認するには、[レンダリングされた行数のカウント](/slides/ja/python-java/manage-paragraph/) を参照してください。行数だけではテキストがコンテナからはみ出しているかどうかは判断できません。

## **テキストフレームのアンカーを設定する**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) は、テキストを図形内で垂直に配置する方法（上部、中央、下部など）を定義します。以下の例は、最初の図形のテキストを下部にアンカーし、結果を "text_anchor.pptx" に保存します。

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

## **テキストのタブ設定を行う**

段落のタブストップを設定するには、[ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) と [ParagraphFormat.getTabs](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getTabs) を使用します。以下の例は、デフォルトタブ幅を 100 ポイントに設定し、30 ポイント位置に左揃えタブストップを追加します。これらの設定はタブ文字を含むテキストに影響します。

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

## **校正言語を設定する**

[BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId) を使用すると、テキスト部分の校正言語を設定できます。校正言語は PowerPoint のスペルチェックや文法チェックで使用される言語を決定します。

以下の例は、最初のスライドの最初の図形がテキスト ボックスである "presentation.pptx" を前提とし、少なくとも 1 つの段落があることが必要です。最初の段落の内容を "1。" に置き換え、フォントを SimSun に設定し、簡体字中国語の校正言語 (`zh-CN`) を割り当てます。結果は "proofing_language.pptx" に保存されます。

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

    # 校正言語の Id を設定します。
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **言語メタデータのコピー**

テンプレートから多言語テキストをコピーする際は、[BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getLanguageId) と [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getAlternativeLanguageId) の両方を保持してください。以下の自己完結型例は、ソース部分に米英語を言語、フランス語を代替言語として設定し、テキストと識別子を新しいプレゼンテーションの部分にコピーします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

source = Portion("Hello! Bonjour!")
source.getPortionFormat().setLanguageId("en-US")
source.getPortionFormat().setAlternativeLanguageId("fr-FR")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    destination = Portion()
    destination.setText(source.getText())
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId())
    # ソースに代替言語がない場合、None は宛先の値をクリアします。
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId())
    paragraph.getPortions().add(destination)

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

代替言語なしのソースを試す場合は、`"fr-FR"` の割り当てを省略してください。その場合代替識別子は `None` となり、コピー文は既存の代替言語があってもデフォルト値を導入せずにその欠如を保持します。

これらの識別子は言語メタデータとして保存されますが、PowerPoint がどの辞書をスペルチェックや文法チェックに使用するかは決定しません。

## **デフォルト言語を設定する**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) を使用すると、プレゼンテーションの読み込みまたは作成時に作成されるテキストのデフォルト言語を定義できます。以下の例は、デフォルトテキスト言語を米英語に設定したプレゼンテーションを作成し、テキスト ボックスを追加して最初のテキスト部分の言語を `en-US` と出力します。

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

    # テキスト付きの矩形シェイプを追加します。
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # 最初の部分の言語を確認します。
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **デフォルトテキストスタイルを設定する**

プレゼンテーション レベルでデフォルトのテキスト書式を適用するには、[Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDefaultTextStyle) を使用します。

以下の例は、新しいプレゼンテーションの最上位段落のデフォルトとして 14 ポイントの太字フォントを設定し、"default_text_style.pptx" に保存します。テキストは、より具体的な書式が上書きしない限り、これらのデフォルトを継承できます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # 上位レベルの段落書式を取得します。
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **オールキャップス効果でテキストを抽出する**

PowerPoint では、**All Caps** フォント効果を適用すると、スライド上では大文字で表示されますが、実際に入力された文字列はそのままです。Aspose.Slides でそのテキスト部分を取得すると、元の入力通りの文字列が返されます。表示されたテキストと一致させるには、[TextCapType](https://reference.aspose.com/slides/python-java/aspose.slides/textcaptype/) を確認し、値が `All` の場合は文字列を大文字に変換してください。

この例は、最初のスライドの最初の図形がテキスト ボックスである "sample2.pptx" を前提とし、最初の段落の最初の部分に **All Caps** 効果が適用された "Hello, Aspose!" が含まれています（下図参照）。

![All Caps 効果](all_caps_effect.png)

次のコード例は、**All Caps** 効果が適用されたテキストを抽出する方法を示します。

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

**スライド上のテーブル内のテキストを変更するにはどうすればよいですか？**

テーブル内のテキストを変更するには、[Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) を使用します。セルを反復処理し、各セルを [Cell.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) で取得し、段落書式を [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat) で更新してください。

**PowerPoint スライドのテキストにグラデーションカラーを適用するにはどうすればよいですか？**

テキストにグラデーションカラーを適用するには、[BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat) を使用します。[FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) を [FillType.Gradient](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) に設定し、グラデーション ストップ、方向、透明度を構成してください。