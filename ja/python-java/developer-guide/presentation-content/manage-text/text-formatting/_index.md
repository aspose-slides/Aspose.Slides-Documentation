---
title: Python via Java でプレゼンテーションテキストをフォーマット
linktitle: テキスト書式設定
type: docs
weight: 50
url: /ja/python-java/text-formatting/
keywords:
- 段落の配置
- テキストスタイル
- テキスト背景
- テキストの透明度
- 文字間隔
- フォントプロパティ
- フォントファミリ
- テキスト回転
- 回転角度
- テキストフレーム
- 行間
- オートフィットプロパティ
- テキストフレームアンカー
- テキストタブ設定
- 既定言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットおよびスタイル設定します。フォント、色、配置などをカスタマイズできます。"
---
## **概要**

このドキュメントでは、Aspose.Slides for Python via Java を使用して PowerPoint および OpenDocument プレゼンテーションのテキストを書式設定する方法を示します。背景色、透明度、文字間隔、フォント プロパティ、回転、段落間隔、オートフィット動作、テキストのアンカリング、タブストップ、言語設定について解説します。

特に指定がない限り、例は [sample.pptx](sample.pptx) を使用します。最初のスライドの最初のシェイプはテキスト ボックスで、最初の段落に以下のテキストが含まれます。スライドおよびシェイプのインデックスは 0 ベースです。太字部分を選択する例は、継承された太字書式を含む有効な書式設定を使用します:

![サンプルテキスト](sample_text.png)

リテラルテキストや正規表現の一致箇所を検索してハイライトする方法については、[テキストの検索と置換](/slides/ja/python-java/search-and-replace-text/) を参照してください。

## **テキストの背景色を設定する**

段落の既定ハイライト色を設定するには [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) を使用し、個々のテキスト部分のハイライト色を設定するには [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseportionformat/#getHighlightColor) を使用します。

次の例では、最初の段落の既定ハイライト色としてライトグレーを設定します。個別の部分に明示的に設定されたハイライト色はこの既定を上書きします:

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

以下のコード例は **太字フォントのテキスト部分** の背景色を設定する方法を示します:

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

## **テキスト段落の配置**

テキスト フレーム内の段落配置を設定するには [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setAlignment) を使用します。設定できる値には中央揃え、左揃え、右揃え、両端揃えなどがあります。

次のコード例は段落を **中央** に揃える方法を示します:

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

## **テキストの透明度を設定する**

テキストの透明度は [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseportionformat/#getFillFormat) に割り当てられた色のアルファ成分で制御します。以下の例では `alpha = 50` は 0〜255 のスケールでの ARGB アルファ値であり、透明度のパーセンテージではありません。

次のコード例は **段落全体** に透明度を適用する方法を示します:

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

次のコード例は **太字フォントのテキスト部分** に透明度を適用する方法を示します:

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

テキスト ボックス内の文字間隔を拡大または縮小するには [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseportionformat/#setSpacing) を使用します。以下の例では 3 ポイントの間隔を追加しています。負の値を指定すると文字が詰まります。

次の Python コードは **段落全体** の文字間隔を拡大する方法を示します:

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
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # 文字間隔を拡大します。

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![段落内の文字間隔](character_spacing_in_paragraph.png)

次のコード例は **太字フォントのテキスト部分** の文字間隔を拡大する方法を示します:

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
            portion.getPortionFormat().setSpacing(3) # 文字間隔を拡大します。

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![テキスト部分の文字間隔](character_spacing_in_text_portions.png)

### **特定フォントのカーニングを無効にする**

場合によっては、Aspose.Slides が描画するテキストが PowerPoint で表示されるテキストよりも僅かに詰まって見えることがあります。これは PowerPoint が特定フォントのカーニング情報を無視するために起こります。

このような場合、影響を受けたフォントを使用するテキスト部分のカーニングを無効にできます。 [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) を実際のフォントサイズより大きな値に設定します。以下の例は、最初のスライドの最初のシェイプがテキスト ボックスである "presentation.pptx" を使用し、効果的なフォント名を確認して、Roboto が使用されている部分に対して 100 ポイント以下の場合にカーニングを無効にします:

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

この設定により、閾値未満のテキストではカーニングが行われず、PowerPoint の特定の動作によって生じる差異を減らすことができます。

## **テキスト フォント プロパティの管理**

フォント プロパティは、[ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) を使用して段落レベルで設定するか、[PortionFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portionformat/) を使用して個々の部分で設定できます。

次の例は、最初の段落の既定フォントを 12 ポイントの Times New Roman に設定し、太字、斜体、点線下線を適用します。個別の部分で明示的に設定された書式は既定を書き換えます:

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

次の例は、効果的に太字となっている部分に対して 13 ポイントの Times New Roman、斜体、点線下線を適用します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpruntime.startJVM()

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

## **テキストの回転を設定する**

[TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/#setTextVerticalType) を使用して、シェイプ内のテキストの事前定義された向きを設定できます。

次のコード例は、シェイプ内のテキスト向きを [TextVerticalType.Vertical270](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textverticaltype/) に設定し、テキストを **90 度反時計回り** に回転させます:

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

## **テキスト フレームのカスタム回転を設定する**

[TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/#setRotationAngle) を使用して、[TextFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/) のカスタム回転角度を設定できます。

次のコード例は、シェイプ内のテキスト フレームを時計回りに 3 度回転させます:

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

![カスタム テキスト回転](custom_text_rotation.png)

## **段落の行間を設定する**

Aspose.Slides は [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setSpaceAfter)、[ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setSpaceBefore)、[ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setSpaceWithin) を提供し、段落間隔を制御します。これらのプロパティは次のように使用します。

* 正の値は行の高さのパーセンテージとして行間を指定します。  
* 負の値はポイント単位で行間を指定します。

次の例は、最初の段落の行間を行高さの 200%（二重行間）に設定します:

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

段落の改行規則は、狭いテキスト領域やラテン文字と東アジア文字が混在するプレゼンテーションで有用です。以下のメソッドは [ParagraphFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/) に属し、段落全体に適用されます。

- [setLatinLineBreak](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) はラテン文字の改行規則を制御します。混在テキストの場合、これを変更すると隣接する東アジア文字や句読点の改行位置も変わることがあります。  
- [setEastAsianLineBreak](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) は東アジア文字の改行規則を制御し、行頭・行末文字の制限を含みます。

これらの規則は [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/#setWrapText) の自動折り返し機能を置き換えるものではなく、折り返しが発生した際のレイアウトに影響します。明示的な改行文字は、利用可能幅に関係なく段落内に新しい行を強制します。

次の自己完結型サンプルは、中国語とラテン文字を含む狭いテキストブロックを作成し、両方の改行オプションを明示的に設定して "line_breaking.pptx" として保存します。どちらか一方の規則だけを試したい場合は、もう一方の設定を変更せずに保持してください。例では 24 ポイントの Arial と SimSun を使用し、フレーム幅 160 ポイント、水平マージン 0 に設定しています。[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/#setAutofitType) は [TextAutofitType.None_](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textautofittype/) に設定し、テキストサイズとフレームサイズを固定しています。

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

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setHangingPunctuation) を使用すると、対象となる句読点がテキスト行の右端をはみ出すように表示でき、次の行に回り込むことを防ぎます。これは段落全体に適用され、ハンギングインデントとは異なります。

次の自己完結型サンプルは、幅 100 ポイントのテキストフレームでハンギング句読点を有効にし、"hanging_punctuation.pptx" として保存します。24 ポイントの Arial と水平マージン 0 の設定で、最後のピリオドは "sentence" の後に残り、右端をはみ出します。比較のためにプロパティを [NullableBool.False_](https://reference.aspose.com/slides/ja/python-java/aspose.slides/nullablebool/) に設定すると、ピリオドが別行に表示されます。折り返しは有効、オートフィットは無効にして幅を固定しています。

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

すべての句読点がハンギングできるわけではありません。見た目はフォントの可用性やレイアウト条件（フォント、幅、マージン、オートフィット設定）によって変わります。

## **テキスト フレームのオートフィット タイプを設定する**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/#setAutofitType) は、テキストがコンテナの境界を超えたときの動作を決定します。テキストを縮小するか、オーバーフローさせるか、シェイプを自動的にリサイズさせるかを制御できます。次の例はシェイプをテキストに合わせてリサイズするよう構成し、結果を "autofit_type.pptx" に保存します。

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

自動折り返し後の行数をカウントし、テキストまたはシェイプ幅の変化が結果に与える影響を確認するには、[Count Rendered Lines](/slides/ja/python-java/manage-paragraph/) を参照してください。行数だけではテキストがコンテナをはみ出しているかは判断できません。

## **テキスト フレームのアンカーを設定する**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/#setAnchoringType) は、シェイプ内でテキストを垂直方向に配置する方法（上部、中央、下部など）を定義します。次の例はテキストを最初のシェイプの下部に固定し、結果を "text_anchor.pptx" として保存します。

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

## **テキストのタブ設定**

[ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) と [ParagraphFormat.getTabs](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#getTabs) を使用して段落のタブストップを構成できます。次の例はデフォルトタブ幅を 100 ポイントに設定し、30 ポイント位置に左揃えタブストップを追加します。これらの設定はタブ文字を含むテキストに影響します。

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

Aspose.Slides は [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseportionformat/#setLanguageId) を提供し、テキスト部分の校正言語を設定できます。校正言語は PowerPoint のスペルチェックや文法チェックに使用される言語を決定します。

次の例は "presentation.pptx"（最初のスライドの最初のシェイプがテキストボックスで、少なくとも 1 つの段落がある）を使用し、最初の段落の内容を "1。" に置き換え、フォントを SimSun に設定し、校正言語を簡体字中国語 (`zh-CN`) に割り当てます。結果は "proofing_language.pptx" として保存されます。

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

## **既定言語を設定する**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) を使用すると、プレゼンテーションの読み込みまたは作成時に新規テキストに適用される既定言語を定義できます。次の例は既定テキスト言語を米国英語に設定したプレゼンテーションを作成し、テキスト ボックスを追加して最初のテキスト部分の言語コードとして `en-US` を出力します。

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

## **既定テキスト スタイルを設定する**

プレゼンテーション レベルで既定のテキスト書式を適用するには、[Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getDefaultTextStyle) を使用します。

次の例は新規プレゼンテーションの最上位段落に対して 14 ポイントの太字フォントを既定スタイルとして設定し、結果を "default_text_style.pptx" に保存します。テキストはより具体的な書式設定が上書きしない限り、これらの既定を継承します。

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

## **すべて大文字効果でテキストを抽出する**

PowerPoint では **All Caps** フォント効果を適用すると、元の文字が小文字で入力されていてもスライド上では大文字で表示されます。Aspose.Slides でそのテキスト部分を取得すると、入力時のままの文字列が返されます。表示通りに取得するには、[TextCapType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textcaptype/) を確認し、値が `All` の場合は取得した文字列を大文字に変換します。

この例は "sample2.pptx"（最初のスライドの最初のシェイプがテキストボックス）を使用し、最初の段落の最初の部分に All Caps 効果が適用された "Hello, Aspose!" が含まれています。

![All Caps 効果](all_caps_effect.png)

次のコード例は **All Caps** 効果が適用されたテキストを抽出する方法を示します:

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

テーブルのテキストを変更するには、[Table](https://reference.aspose.com/slides/ja/python-java/aspose.slides/table/) を使用します。セルを反復処理し、各セルを [Cell.getTextFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/cell/#getTextFrame) で取得し、段落書式は [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraph/#getParagraphFormat) で更新します。

**PowerPoint スライドのテキストにグラデーション カラーを適用するにはどうすればよいですか？**

テキストにグラデーション カラーを適用するには、[BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseportionformat/#getFillFormat) を使用します。次に、[FillFormat.setFillType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fillformat/#setFillType) を [FillType.Gradient](https://reference.aspose.com/slides/ja/python-java/aspose.slides/filltype/) に設定し、グラデーション ストップ、方向、透明度を構成します。