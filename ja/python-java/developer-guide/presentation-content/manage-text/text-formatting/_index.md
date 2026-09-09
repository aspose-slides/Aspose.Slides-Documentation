---
title: Python via Java でプレゼンテーションテキストをフォーマット
linktitle: テキストフォーマット
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
- フォントファミリー
- テキスト回転
- 回転角度
- テキストフレーム
- 行間
- オートフィットプロパティ
- テキストフレームアンカー
- テキストタブ設定
- デフォルト言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットおよびスタイル設定します。フォント、色、配置などをカスタマイズできます。"
---
## **概要**

この記事では、Aspose.Slides for Python via Java を使用して PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットする方法を示します。背景色、透明度、文字間隔、フォントプロパティ、回転、段落間隔、オートフィットの動作、テキストのアンカリング、タブストップ、言語設定について説明します。

以下の例では、最初のスライドに単一のテキストボックスが含まれ、次のテキストが入っている「sample.pptx」ファイルを使用します。

![サンプルテキスト](sample_text.png)

リテラルテキストまたは正規表現の一致箇所を検索してハイライトする方法については、[テキストの検索と置換](/slides/ja/python-java/search-and-replace-text/) を参照してください。

## **テキストの背景色の設定**

段落のデフォルトハイライト色を設定するには[ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat)を使用し、個々のテキスト部分には[PortionFormat.getHighlightColor](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portionformat/)を使用します。

次のコード例は**段落全体**の背景色を設定する方法を示します。

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

結果：

![灰色の段落](gray_paragraph.png)

次のコード例は**太字フォントのテキスト部分**の背景色を設定する方法を示します。

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

結果：

![灰色のテキスト部分](gray_text_portions.png)

## **テキスト段落の配置**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setAlignment) を使用して、テキストフレーム内の段落配置を設定します。値は中央、左揃え、右揃え、両端揃えなどがあります。

次のコード例は段落を**中央**に配置する方法を示します。

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

    #     段落の配置を中央に設定します。
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![配置された段落](aligned_paragraph.png)

## **テキストの透明度の設定**

テキストの透明度は、[PortionFormat.getFillFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portionformat/) に割り当てられた色のアルファ成分で制御されます。以下の例で `alpha = 50` は 0〜255 のスケールの ARGB アルファチャンネル値であり、透明度のパーセンテージではありません。

次のコード例は**段落全体**に透明度を適用する方法を示します。

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

結果：

![透明な段落](transparent_paragraph.png)

次のコード例は**太字フォントのテキスト部分**に透明度を適用する方法を示します。

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

結果：

![透明なテキスト部分](transparent_text_portions.png)

## **テキストの文字間隔の設定**

[PortionFormat.setSpacing](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portionformat/) を使用して、テキストボックス内の文字間隔を拡大または縮小します。

次の Python コードは**段落全体**の文字間隔を拡大する方法を示します。

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

    # 注：文字間隔を縮めるには負の値を使用します。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # 文字間隔を拡張します。

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![段落内の文字間隔](character_spacing_in_paragraph.png)

次のコード例は**太字フォントのテキスト部分**の文字間隔を拡大する方法を示します。

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
            # 注：文字間隔を縮めるには負の値を使用します。
            portion.getPortionFormat().setSpacing(3) # 文字間隔を拡張します。

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果：

![テキスト部分の文字間隔](character_spacing_in_text_portions.png)

### **特定フォントのカーニングを無効にする**

場合によっては、Aspose.Slides がレンダリングしたテキストが PowerPoint で表示されるテキストよりも若干詰まって見えることがあります。これは、PowerPoint が特定のフォントに対してカーニング データを無視するためです（フォントに有効なカーニング情報が含まれていても、PowerPoint の設定でカーニングが有効になっていても）。

このようなケースで PowerPoint に近い出力にするには、影響を受けるフォントを使用するテキスト部分のカーニングを無効にします。[PortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portionformat/) を実際のフォントサイズよりはるかに大きい値に設定してください。

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
            portion_format = portion.getPortionFormat()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion_format.setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

この設定により該当するテキスト部分にカーニングが適用されず、PowerPoint 固有の動作で影響を受けるフォントの視覚的出力を Aspose.Slides のレンダリングと合わせやすくなります。

## **テキストフォントプロパティの管理**

フォントプロパティは、[ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) を使用して段落レベルで設定するか、[PortionFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portionformat/) を使用して個々の部分で設定できます。

次のコードは段落全体のフォントとテキストスタイルを設定します。フォントサイズ、太字、斜体、点線下線、そして Times New Roman フォントを段落内のすべての部分に適用します。

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    #    段落のフォントプロパティを設定します。
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

結果：

![段落のフォントプロパティ](font_properties_for_paragraph.png)

次のコード例は**太字フォントのテキスト部分**に同様のプロパティを適用します。

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

結果：

![テキスト部分のフォントプロパティ](font_properties_for_text_portions.png)

## **テキストの回転の設定**

[TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/#setTextVerticalType) を使用して、シェイプ内のテキストの事前定義された向きを設定します。

次のコード例はシェイプ内のテキスト向きを `Vertical270` に設定し、テキストを**時計回りに90度**回転させます。

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

結果：

![テキストの回転](text_rotation.png)

## **テキストフレームのカスタム回転の設定**

[TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/#setRotationAngle) を使用して、[TextFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframe/) のカスタム回転角度を設定します。

次のコード例はシェイプ内でテキストフレームを時計回りに 3 度回転させます。

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

結果：

![カスタムテキスト回転](custom_text_rotation.png)

## **段落の行間の設定**

Aspose.Slides は [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setSpaceAfter)、[ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setSpaceBefore) および [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setSpaceWithin) を提供し、段落間隔を制御します。これらのプロパティは次のように使用します。

* 正の値を使用すると、行間を行の高さのパーセンテージで指定できます。
* 負の値を使用すると、行間をポイントで指定できます。

次のコード例は段落内の行間を指定する方法を示します。

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

結果：

![段落内の行間](line_spacing.png)

## **テキストフレームのオートフィットタイプの設定**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/#setAutofitType) は、テキストがコンテナの境界を超えたときの動作を決定します。テキストが縮小するか、はみ出すか、シェイプが自動的にサイズ変更されるかを制御します。

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

## **テキストフレームのアンカーの設定**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textframeformat/#setAnchoringType) は、シェイプ内でテキストが垂直方向に配置される位置（上部、中央、下部など）を定義します。

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

[ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) と [ParagraphFormat.getTabs](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraphformat/#getTabs) を使用して、段落内のタブストップを構成します。

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

結果：

![段落のタブ](paragraph_tabs.png)

## **校正言語の設定**

Aspose.Slides は [PortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portionformat/) を提供し、テキスト部分の校正言語を設定できます。校正言語は PowerPoint のスペルチェックと文法チェックに使用される言語を決定します。

次のコード例はテキスト部分の校正言語を設定する方法を示します。

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

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) を使用して、プレゼンテーションの読み込みまたは作成時に作成されるテキストのデフォルト言語を定義します。

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

    # 最初のテキスト部分の言語を確認します。
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **デフォルトテキストスタイルの設定**

プレゼンテーションレベルでデフォルトのテキスト書式設定を適用するには、[Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getDefaultTextStyle) を使用します。

次のコード例は新しいプレゼンテーションのすべてのスライドで、サイズ 14 pt の太字フォントをデフォルトとして設定する方法を示します。

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

## **All-Caps 効果を持つテキストの抽出**

PowerPoint では、**All Caps** フォント効果を適用すると、スライド上のテキストが大文字で表示されますが、元のテキストは小文字のままです。Aspose.Slides でそのテキスト部分を取得すると、ライブラリは入力されたままの文字列を返します。表示されているテキストと一致させるには、[TextCapType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/textcaptype/) を確認し、値が `All` の場合は返された文字列を大文字に変換してください。

次のようなテキストボックスが sample2.pptx の最初のスライドにあるとします。

![All Caps 効果](all_caps_effect.png)

次のコード例は **All Caps** 効果が適用されたテキストを抽出する方法を示します。

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

出力：

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**スライド上のテーブル内のテキストを変更するにはどうすればよいですか？**

テーブル内のテキストを変更するには、[Table](https://reference.aspose.com/slides/ja/python-java/aspose.slides/table/) を使用します。セルを反復処理し、各セルを[Cell.getTextFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/cell/#getTextFrame)で取得し、[Paragraph.getParagraphFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraph/#getParagraphFormat) を使用して段落書式を更新します。

**PowerPoint スライドのテキストにグラデーションカラーを適用するにはどうすればよいですか？**

グラデーションカラーを適用するには、[PortionFormat.getFillFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portionformat/) を使用します。[FillFormat.setFillType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fillformat/#setFillType) を [FillType.Gradient](https://reference.aspose.com/slides/ja/python-java/aspose.slides/filltype/#Gradient) に設定し、グラデーション ストップ、方向、透明度を構成します。