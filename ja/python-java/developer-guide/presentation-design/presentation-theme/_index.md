---
title: Python から Java を介してプレゼンテーションテーマを管理
linktitle: プレゼンテーションテーマ
type: docs
weight: 10
url: /ja/python-java/presentation-theme/
keywords:
- PowerPoint テーマ
- プレゼンテーション テーマ
- スライド テーマ
- テーマを設定
- テーマを変更
- テーマの管理
- 外部テーマ
- THMX
- テーマカラー
- 追加パレット
- テーマ フォント
- テーマ スタイル
- テーマ 効果
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Python 用 Aspose.Slides（Java 経由）でプレゼンテーションのマスター テーマを管理し、一貫したブランディングで PowerPoint ファイルを作成、カスタマイズ、変換します。"
---
## **導入**

プレゼンテーションテーマは、色、フォント、背景スタイル、塗りつぶし、線、効果を統合したセットです。テーマ対応オブジェクトは、個々の視覚プロパティを固定値として保持するのではなく、これらの共有定義を参照します。そのため、テーマを変更すると多くのオブジェクトが一度に更新されます。

Aspose.Slides では、プレゼンテーションレベルのテーマは [Presentation.getMasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasterTheme) で取得できます。プレゼンテーションは下位レベルでテーマのオーバーライドを含むこともできます。マスターは [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/python-java/aspose.slides/masterthememanager/#getOverrideTheme) を介してプレゼンテーションテーマをオーバーライドでき、レイアウトや個々のスライドは [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#getOverrideTheme) を介して継承されたテーマをオーバーライドできます。実際には、スライドの有効テーマは次の継承チェーンで解決されます：プレゼンテーションテーマ → マスターオーバーライド → レイアウトオーバーライド → スライドオーバーライド。

![テーマの構成要素: 色、フォント、背景スタイル、効果](theme-constituents.png)

以下のセクションでは、最も一般的なテーマのワークフローを示します。テーマの検査、色とフォントの変更、テーマのコピーまたは適用、背景と効果スタイルの更新、継承とオーバーライドが解決された後の有効値の取得です。

## **テーマの検査**

[MasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/) オブジェクトは、[MasterTheme.getColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getColorScheme)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getFontScheme)、[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getFormatScheme) を通じて、テーマのカラー スキーム、フォント スキーム、フォーマット スキームを公開します。変更前にこれらのコレクションを検査することは、外部ソースからのプレゼンテーションの場合に特に有用です。なぜなら、スタイル エントリの数と内容はファイルによって異なる可能性があるからです。

次の例はメインテーマのプロパティを読み取り、テーマに格納されている背景、塗りつぶし、線、効果スタイルの数をレポートします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    theme = presentation.getMasterTheme()

    print("Theme name:", theme.getName())
    print("Accent 1:", theme.getColorScheme().getAccent1().getColor())
    print("Major Latin font:", theme.getFontScheme().getMajor().getLatinFont().getFontName())
    print("Minor Latin font:", theme.getFontScheme().getMinor().getLatinFont().getFontName())
    print("Background fill styles:", theme.getFormatScheme().getBackgroundFillStyles().size())
    print("Fill styles:", theme.getFormatScheme().getFillStyles().size())
    print("Line styles:", theme.getFormatScheme().getLineStyles().size())
    print("Effect styles:", theme.getFormatScheme().getEffectStyles().size())
finally:
    presentation.dispose()
```

ファイルが複数のマスターを使用している場合、すべてのスライドが同じ有効テーマを持つとは限りません。スライドに関連付けられたマスターを検査し、レイアウトやスライドのオーバーライドが存在する可能性がある場合は、後述の有効テーマ ワークフローを使用してください。

## **テーマの色の変更**

テーマ対応の塗りつぶし、線、テキストは [SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/) 列挙体の論理色を参照できます。[ColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/colorscheme/) の該当エントリを変更すると、そのテーマ色を参照し続けているすべてのオブジェクトが新しい値に解決されます。直接 RGB 色を使用しているオブジェクトはテーマ色の更新の影響を受けません。

次のエンドツーエンド例は、`Accent4` を使用するシェイプを作成し、テーマの `Accent4` 色を赤に変更し、プレゼンテーションを保存して再度開き、実効塗りつぶし色を出力します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, SchemeColor, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)

    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED)

    presentation.save("theme-color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("theme-color.pptx")
try:
    saved_slide = saved_presentation.getSlides().get_Item(0)
    saved_shape = saved_slide.getShapes().get_Item(0)
    effective_fill = saved_shape.getFillFormat().getEffective()
    print("Effective fill color:", effective_fill.getSolidFillColor())
finally:
    saved_presentation.dispose()
```

矩形は `Accent4` にリンクされたままであるため、テーマが変更されると表示色は赤になります。シェイプ上でスキーム色を直接の色に置き換えた場合、後続の `Accent4` の変更はその塗りつぶしに影響しなくなります。

### **追加パレットからの色の使用**

PowerPoint はテーマ色から明るい変種や暗い変種を色変換で導出します。Aspose.Slides はこれらの変換を [ColorTransformOperation](https://reference.aspose.com/slides/python-java/aspose.slides/colortransformoperation/) 列挙体で公開しています。

![メインテーマ色と追加パレットから生成された明るい・暗い色](additional-palette-colors.png)

**1** ‑ メインテーマ色。  
**2** ‑ メインテーマ色から生成された明るい・暗い変種。

次の例は `Accent4` を基にした 6 つの矩形を作成し、そのうち 5 つに輝度変換を適用し、結果を保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    base_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50)
    base_shape.getFillFormat().setFillType(FillType.Solid)
    base_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)

    lightest_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50)
    lightest_shape.getFillFormat().setFillType(FillType.Solid)
    lightest_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    lightest_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2)
    lightest_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8)

    lighter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50)
    lighter_shape.getFillFormat().setFillType(FillType.Solid)
    lighter_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    lighter_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4)
    lighter_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6)

    light_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50)
    light_shape.getFillFormat().setFillType(FillType.Solid)
    light_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    light_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6)
    light_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4)

    dark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50)
    dark_shape.getFillFormat().setFillType(FillType.Solid)
    dark_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    dark_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75)

    darker_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50)
    darker_shape.getFillFormat().setFillType(FillType.Solid)
    darker_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    darker_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5)

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

これらの変種はテーマ色に基づきます。後で `Accent4` が変更されると、変換された色は新しい `Accent4` の値から再計算されます。

### **`SchemeColor` 値を `ColorScheme` スロットにマッピング**

[SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/) 列挙体は `Text1`、`Background1`、`Text2`、`Background2` を使用し、[ColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/colorscheme/) は同じテーマスロットを `Dark1`、`Light1`、`Dark2`、`Light2` として公開します。マッピングは固定です。

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

これらは同じテーマスロットの別名であり、動的に変換される値ではありません。

## **テーマのフォントの変更**

テーマのフォント スキームは、見出し用のメジャー フォント セットと本文用のマイナー フォント セットを含みます。[FontScheme.getMajor](https://reference.aspose.com/slides/python-java/aspose.slides/fontscheme/#getMajor) と [FontScheme.getMinor](https://reference.aspose.com/slides/python-java/aspose.slides/fontscheme/#getMinor) メソッドでこれらのセットを取得できます。

PowerPoint 互換のテーマフォント識別子はテキスト書式設定で使用できます。

* `+mn-lt` ‑ 本文フォント Latin（マイナー Latin フォント）
* `+mj-lt` ‑ 見出しフォント Latin（メジャー Latin フォント）
* `+mn-ea` ‑ 本文フォント East Asian（マイナー East Asian フォント）
* `+mj-ea` ‑ 見出しフォント East Asian（メジャー East Asian フォント）
* `+mn-cs` ‑ 本文フォント Complex Script（マイナー Complex Script フォント）
* `+mj-cs` ‑ 見出しフォント Complex Script（メジャー Complex Script フォント）

次の例は、メジャー Latin テーマフォントを使用した見出しと、マイナー Latin テーマフォントを使用した本文行を作成し、テーマフォントを変更して結果を保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60)
    heading.getTextFrame().setText("Theme heading")
    font_data = FontData("+mj-lt")
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(font_data)

    body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60)
    body.getTextFrame().setText("Theme body text")
    font_data = FontData("+mn-lt")
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(font_data)

    font_data = FontData("Aptos Display")
    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(font_data)
    font_data = FontData("Arial")
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(font_data)
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

見出しはメジャー フォントに従い、本文はマイナー フォントに従います。テーマ識別子ではなく明示的なフォント名が設定されているテキストは、テーマ フォント スキームが変更されても自動的には切り替わりません。

メジャーとマイナーのフォント コレクションには、キリル文字、アラビア文字、日本語、ジョージア文字、ターナ文字など、個々の書字システム向けのフォント マッピングも含めることができます。これらのマッピングを検査、追加、置換、削除するには、[Script-Specific Theme Fonts](/slides/ja/python-java/script-specific-font-mappings/) を参照してください。

{{% alert color="success" title="Tip" %}}
プレゼンテーション フォントの詳細については、[PowerPoint フォント](/slides/ja/python-java/powerpoint-fonts/) をご覧ください。
{{% /alert %}}

### **テーマ フォント参照の解決**

テキストを検査する際、[FontData.getFontName](https://reference.aspose.com/slides/python-java/aspose.slides/fontdata/#getFontName) はフォント ファミリ名の代わりに `+mn-lt` などのテーマ参照を返すことがあります。適切な有効テーマ データを使用して [FontData.getFontName](https://reference.aspose.com/slides/python-java/aspose.slides/fontdata/#getFontName) を呼び出し、その参照を解決してください。`+mj` と `+mn` プレフィックスはメジャー／マイナー フォント セットを選択し、`-lt`、`-ea`、`-cs` サフィックスはそれぞれ Latin、East Asian、Complex Script フォントを選択します。

対象テキストが属するオブジェクトのテーマ マネージャーで [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) を呼び出して有効テーマを取得します。スライド上の普通のテキストの場合、スライドのテーママネージャーを使用すれば、そのスライドが継承したテーマとローカル オーバーライドが含まれます。レイアウトやマスター自体を検査する場合は、それぞれの有効テーマを使用してください。最初のマスターのテーマがすべてのスライドに適用されると想定しないでください。

次の例は、マイナー Latin フォントを明示的に参照するテキスト部分を作成し、[OverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFontSchemeFromInherited) でスライドのフォント スキームを初期化し、メジャーとマイナーの Latin ファミリをそれぞれ `Arial` と `Calibri` に設定して、入力ファイルなしでも再現可能にしています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    theme = slide.getThemeManager().getOverrideTheme()
    theme.initFontSchemeFromInherited()
    major_font = FontData("Arial")
    theme.getFontScheme().getMajor().setLatinFont(major_font)
    minor_font = FontData("Calibri")
    theme.getFontScheme().getMinor().setLatinFont(minor_font)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60)
    shape.getTextFrame().setText("Text using the minor theme font")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    theme_font = FontData("+mn-lt")
    portion.getPortionFormat().setLatinFont(theme_font)

    font = portion.getPortionFormat().getLatinFont()
    effective_theme = slide.getThemeManager().createThemeEffective()
    print(f"{font.getFontName()} -> {font.getFontName(effective_theme)}")

    explicit_font = FontData("Verdana")
    print(f"{explicit_font.getFontName()} -> {explicit_font.getFontName(effective_theme)}")
finally:
    presentation.dispose()
```

出力は `+mn-lt -> Calibri` と続いて `Verdana -> Verdana` になります。保存された参照は変更されず、明示的なファミリ名はそのまま返されます。もし `+mj-lt` を使用していれば、このテーマでは `Arial` に解決されます。

テーマ参照の解決は、テーマが指定したフォント ファミリを特定しますが、フォントの可用性や、レンダリング時の代替・フォールバックによって最終的に使用されるフォント ファイルはチェックしません。これらの別ステップについては、[フォント選択シーケンス](/slides/ja/python-java/font-selection-sequence/) と [フォント置換](/slides/ja/python-java/font-substitution/) を参照してください。

## **テーマのコピーまたは適用**

以下のワークフローは、さまざまなテーマ関連の課題を解決します。

### **外部テーマを特定のマスターに依存するスライドに適用**

PowerPoint テーマ ファイル（`.thmx`）があり、特定のマスターに依存するすべてのスライドのスタイルを変更したい場合は、[MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) を使用します。対象のマスターは [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) コレクション（[MasterSlideCollection](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/)）から取得し、メソッドにテーマ ファイルのパスを渡します。

メソッドは次の操作を実行します。

1. 選択したマスターを基に新しいマスター スライドを作成します。
1. 外部テーマを新しいマスターに適用します。
1. 以前に選択したマスターに依存していたすべてのスライドに新しいマスターを割り当てます。
1. 新しく作成された [MasterSlide](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/) を返します。

次の例は、最初のマスターに依存するスライドに外部テーマを適用し、プレゼンテーションを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    selected_master = presentation.getMasters().get_Item(0)
    themed_master = selected_master.applyExternalThemeToDependingSlides("corporate-theme.thmx")
    print("Created master:", themed_master.getName())

    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

無効、破損、またはサポートされていないテーマは [PptxReadException](https://reference.aspose.com/slides/python-java/aspose.slides/pptxreadexception/) をスローする可能性があります。ユーザーが提供したパスを検証し、ファイル システムへのアクセス失敗を処理し、テーマの適用が成功した後にのみプレゼンテーションを保存してください。

選択したマスターに依存していたスライドだけが再割り当てされます。他のマスターに関連付けられたスライドは既存のマスターとテーマを保持します。テーマ対応の色、フォント、塗りつぶし、線、背景、効果は外部テーマに対して解決されます。直接割り当てられた色やフォント、塗りつぶしなどの明示的な書式設定は変更されないまま残ることがあります。レイアウトレベルやスライドレベルのオーバーライドは、新しいマスターから継承された値よりも優先されることがあります。

テーマは実行環境に存在しないフォントを参照することがあります。安定したレンダリングとエクスポートのために、必要なフォントをインストールするか、[カスタム フォント ソース](/slides/ja/python-java/custom-font/) を通じて提供するか、[フォント置換](/slides/ja/python-java/font-substitution/) を構成してください。

この手順はマスター レベルの直接ワークフローです。メソッドは `.thmx` ファイルへのパスを受け取り、スライドレベルやレイアウトレベルのテーマ オーバーライドを手動で作成する必要はありません。

### **マルチマスター プレゼンテーションで異なる外部テーマを適用**

対象マスターが事前に分からない場合は、[Slide.getLayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getLayoutSlide) と [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/#getMasterSlide) を使用して代表的なスライドから取得します。テーマを適用する前に、元のマスター参照を保存してください。各呼び出しはプレゼンテーションに新しいマスターを追加します。

次の例は、2 つのセクションのスライドからそれぞれのマスターを取得し、各グループに別々の外部テーマを適用します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("multi-master-presentation.pptx")
try:
    if presentation.getSlides().size() < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide()
        second_group_master = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide()

        if first_group_master.getSlideId() == second_group_master.getSlideId():
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.applyExternalThemeToDependingSlides("blue-theme.thmx")
            second_themed_master = second_group_master.applyExternalThemeToDependingSlides("green-theme.thmx")

            print("First themed master:", first_themed_master.getName())
            print("Second themed master:", second_themed_master.getName())

            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

最初の呼び出しは `first_group_master` に依存するスライドだけに影響し、2 番目の呼び出しは `second_group_master` に依存するスライドだけに影響します。他のマスターに属するスライドは再スタイルされません。

### **スライドを移動する際に元のテーマを保持**

スライドを別のプレゼンテーションに移動し、元のデザインを保持したい場合は、[MasterSlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/#addClone) でソース マスターをターゲット プレゼンテーションにクローンし、続いて [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) でスライドとクローンしたマスターをクローンします。これによりマスター、レイアウト、関連テーマが一緒にコピーされます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        source_slide = source.getSlides().get_Item(0)

        source_master = source_slide.getLayoutSlide().getMasterSlide()
        cloned_master = target.getMasters().addClone(source_master)
        target.getSlides().addClone(source_slide, cloned_master, True)

        target.save("theme-preserved.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

この方法は、ソース スライドが宛先でも同じ外観になることが必須な場合に推奨されます。無関係な宛先マスターにコンテンツだけをクローンすると、テーマ駆動の色、フォント、背景、効果が変わってしまうことがあります。

### **既存スライドにテーマ値を適用**

対象スライドが現在のマスターとレイアウトを保持したままでテーマを適用したい場合は、ソーステーマからスライドレベルのオーバーライドを初期化します。[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initColorSchemeFrom)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFontSchemeFrom)、[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFormatSchemeFrom) メソッドで 3 つの主要テーマコンポーネントをオーバーライドにコピーします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        target_slide = target.getSlides().get_Item(0)

        override_theme = target_slide.getThemeManager().getOverrideTheme()
        override_theme.initColorSchemeFrom(source.getMasterTheme().getColorScheme())
        override_theme.initFontSchemeFrom(source.getMasterTheme().getFontScheme())
        override_theme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme())

        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

この操作により、他のスライドが継承しているテーマは変わらず、対象スライドだけが新しいテーマを使用します。ローカル オーバーライドを削除して継承値に戻すには、[OverrideTheme.clear](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#clear) を呼び出してください。

### **レイアウトにテーマ オーバーライドを適用**

レイアウトレベルのオーバーライドは、そのレイアウトを使用しているスライド全体に適用されます（ただし、個々のスライドが独自のオーバーライドを持つ場合は除く）。同じ初期化メソッドは [LayoutSlideThemeManager](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslidethememanager/) を介して使用できます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        target_slide = target.getSlides().get_Item(0)

        target_layout = target_slide.getLayoutSlide()
        override_theme = target_layout.getThemeManager().getOverrideTheme()
        override_theme.initColorSchemeFrom(source.getMasterTheme().getColorScheme())
        override_theme.initFontSchemeFrom(source.getMasterTheme().getFontScheme())
        override_theme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme())

        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

多数のレイアウトやスライドが同一の基本デザインを共有する場合はマスターまたはプレゼンテーションレベルのテーマを使用し、特定のレイアウトファミリだけが異なるスタイルが必要な場合はレイアウト オーバーライドを、例外的なケースだけはスライド オーバーライドを使用してください。過度なスライドレベルのオーバーライドは、後からの全体テーマ変更を予測しにくくします。

<!-- visual-explanation:presentation-theme:start -->
[![マスター テーマが 2 つのレイアウトに供給され、レイアウト オーバーライドがそのスライドに影響し、よりローカルなオーバーライドを持つスライドは除外されます。](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*レイアウト オーバーライドは、そのレイアウトを使用するスライドに適用されますが、スライドが独自のオーバーライドを持つ場合は例外です。テーマベースの値は解決されたスキームに従い、明示的に書式設定されたオブジェクトはローカルの外観を保持できます。オーバーライドは意図したデザイン例外の範囲に留めてください。*
<!-- visual-explanation:presentation-theme:end -->

## **テーマの背景スタイルの更新**

テーマの背景塗りつぶしは [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getBackgroundFillStyles) に格納されています。PowerPoint の UI では、実際にコレクションに格納されている塗りつぶし定義よりも多くの背景選択肢が提示されます。これは UI がテーマ塗りつぶしをテーマ色や他のスタイル参照と組み合わせて表示できるためです。

![プレゼンテーション テーマの背景スタイル ギャラリー](presentation-design_8.png)

背景スタイルを使用する前に、保存されているコレクションと現在の [Background.getStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getStyleIndex) を検査してください。インデックス `0` はテーマ塗りつぶしがないことを意味し、正の値はテーマ背景スタイル参照です。これはコレクションを直接インデックス指定する `get_Item(0)`（最初の項目）とは異なります。すべてのプレゼンテーションが同じ数の背景塗りつぶしスタイルを持つとは限らないことに注意してください。

次の例は利用可能な背景塗りつぶし数を報告し、最初のマスターにテーマ背景参照を割り当て、プレゼンテーションを保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    background_styles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles()
    print("Background fill styles:", background_styles.size())
    if background_styles.size() == 0:
        print("The presentation theme does not contain background fill styles.")
    else:
        master_slide = presentation.getMasters().get_Item(0)
        master_slide.getBackground().setType(BackgroundType.Themed)
        master_slide.getBackground().setStyleIndex(1)

        presentation.save("theme-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

表示結果はマスターが参照するテーマ エントリと、レイアウトまたはスライドレベルでの背景オーバーライドの有無に依存します。スライドが独自の背景を使用している場合、マスターの背景だけを変更してもそのスライドの外観は変わりません。継承後の最終背景を知りたい場合は、[Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective) を使用してください。

{{% alert color="warning" title="Warning" %}}
インデックスはゼロベースのコレクションインデックスとして扱わないでください。また、あるファイルで使用したスタイル番号を別のファイルでハードコーディングして同じ外観になると期待しないでください。テーマ スタイル定義はプレゼンテーション固有です。
{{% /alert %}}

{{% alert color="success" title="Tip" %}}
直接的な背景書式設定や背景継承については、[プレゼンテーション背景](/slides/ja/python-java/presentation-background/) を参照してください。
{{% /alert %}}

## **テーマ効果の更新**

テーマ フォーマット スキームは、[FormatScheme.getFillStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getFillStyles)、[FormatScheme.getLineStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getLineStyles)、[FormatScheme.getEffectStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getEffectStyles) を通じて、個別の塗りつぶし、線、効果スタイル コレクションを公開します。一般的な Office テーマは、視覚的に「控えめ」「中程度」「強調」の 3 つの主要スタイル エントリを含むことが多いですが、コード側では固定数を想定せず、各コレクションを検査してください。

![同じシェイプに適用された控えめ・中程度・強調のテーマ効果](presentation-design_10.png)

Python から Java を呼び出す場合、コレクションインデックスはゼロベースです：`get_Item(0)` が最初の格納スタイル、`get_Item(2)` が3番目。シェイプの style-reference インデックスは別概念で、[ShapeStyle](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/) で公開されます。テーマ スタイルを変更すると、そのテーマ スタイルを参照しているシェイプに影響しますが、直接書式設定されたシェイプは変更されません。

次の例は、必要なスタイル エントリが存在することを確認し、最初の線スタイルを変更し、3 番目の塗りつぶしスタイルを変更し、3 番目の効果スタイルに外側のシャドウ（距離 10pt）を有効化して結果を保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("Subtle_Moderate_Intense.pptx")
try:
    format_scheme = presentation.getMasterTheme().getFormatScheme()
    if format_scheme.getLineStyles().size() < 1 or format_scheme.getFillStyles().size() < 3 or format_scheme.getEffectStyles().size() < 3:
        print("The theme does not contain the style entries required by this example.")
    else:
        format_scheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid)
        format_scheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED)
        format_scheme.getFillStyles().get_Item(2).setFillType(FillType.Solid)
        forest_green = Color(34, 139, 34)
        format_scheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(forest_green)
        effect_format = format_scheme.getEffectStyles().get_Item(2).getEffectFormat()
        effect_format.enableOuterShadowEffect()
        effect_format.getOuterShadowEffect().setDistance(10)

        presentation.save("theme-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

これらのスロットを参照しているシェイプでは、最初のテーマ線スタイルが赤になり、3 番目のテーマ塗りつぶしスタイルが濃い森林緑の実体色になり、3 番目の効果スタイルに外側シャドウが追加されます。最終的な視覚結果は、各シェイプがどのスロットを参照しているか、または直接書式設定がテーマを上書きしているかに依存します。

![線・塗りつぶし・シャドウ設定変更後のテーマ効果スタイル](presentation-design_11.png)

## **シェイプのテーマ塗りつぶしと線スタイルの選択**

シェイプは [ShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/#setFillStyleIndex) と [ShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/#setLineStyleIndex) で塗りつぶしと輪郭を独立して選択できます。どちらのメソッドでも、インデックス `1` が対応コレクションの最初のエントリ（`get_Item(0)`）を、インデックス `2` が2番目（`get_Item(1)`）を選択します。

次の例は、新規プレゼンテーションのデフォルトテーマで、2 つの塗りつぶしスタイル（金色と空色）と 2 つの線スタイル（6pt の濃い青、12pt の濃い赤）を設定し、3 段階でスライドを保存して PowerPoint で結果を比較できるようにします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    styles = presentation.getMasterTheme().getFormatScheme()

    gold_fill = styles.getFillStyles().get_Item(0)
    gold_fill.setFillType(FillType.Solid)
    gold_fill.getSolidFillColor().setColor(Color(255, 215, 0))
    blue_fill = styles.getFillStyles().get_Item(1)
    blue_fill.setFillType(FillType.Solid)
    blue_fill.getSolidFillColor().setColor(Color(135, 206, 235))

    thin_line = styles.getLineStyles().get_Item(0)
    thin_line.getFillFormat().setFillType(FillType.Solid)
    thin_line.getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    thin_line.setWidth(6)
    thick_line = styles.getLineStyles().get_Item(1)
    thick_line.getFillFormat().setFillType(FillType.Solid)
    thick_line.getFillFormat().getSolidFillColor().setColor(Color(139, 0, 0))
    thick_line.setWidth(12)

    shapes = presentation.getSlides().get_Item(0).getShapes()
    left = shapes.addAutoShape(ShapeType.Rectangle, 100, 205, 200, 130)
    right = shapes.addAutoShape(ShapeType.Rectangle, 420, 205, 200, 130)
    left.getShapeStyle().setFillStyleIndex(1)
    right.getShapeStyle().setFillStyleIndex(2)
    left.getShapeStyle().setLineStyleIndex(1)
    right.getShapeStyle().setLineStyleIndex(1)
    presentation.save("01-initial.pptx", SaveFormat.Pptx)

    right.getShapeStyle().setLineStyleIndex(2)
    presentation.save("02-line-changed.pptx", SaveFormat.Pptx)

    gold_fill.getSolidFillColor().setColor(Color(46, 139, 87))
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| 初期スタイル | 右側の輪郭を変更 | 最初のテーマ塗りつぶしを編集 |
|:---:|:---:|:---:|
| ![金色と空色の矩形、薄い濃い青の輪郭が一致](theme-style-initial.png) | ![空色の矩形が太い濃い赤の輪郭に変更](theme-style-line-changed.png) | ![左側の矩形が緑に変わり、両輪郭は変わらず](theme-style-fill-changed.png) |

異なる線スタイルを選択すると右側の矩形の輪郭だけが変わります。最初のテーマ塗りつぶしを編集すると、その塗りつぶしを使用しているすべてのシェイプが更新され、ここでは左側の矩形だけが緑に変わります。

既存のシェイプでは、ローカルの塗りつぶし色、線色、線幅がテーマ スタイルのその部分を上書きできます。スタイル インデックスを変更しても視覚的変化がない場合は、シェイプの [直接書式設定](/slides/ja/python-java/shape-formatting/) を確認してください。

## **実効的な単色塗りつぶしがテーマ色を使用しているかの判定**

塗りつぶしはオブジェクトに直接格納されるか、段落、レイアウト、マスター、テーマ スタイル、または別の書式設定レベルから継承されます。[FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective) を呼び出してこの階層を不変の実効塗りつぶしデータに解決します。まず、実効データオブジェクトの `getFillType` を確認してください。`FillType.Solid` のときだけ、単色塗りつぶしプロパティを読み取ります。

単色塗りつぶしの場合、`getSolidFillColor` は継承、テーマ参照、色変換が適用された後の最終 RGB 値を返します。`getSolidFillSchemeColor` は対応する論理 [SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/) スロット（例：`Text1`、`Accent6`）を返します。`SchemeColor.NotDefined` は実効単色塗りつぶしがスキーム色に基づかないことを意味し、直接 RGB 塗りつぶしであることを示します。

ローカルの [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#getSchemeColor) のみを使用して塗りつぶしを分類しないでください。たとえば、テキスト部分にローカルで定義されたスキーム色がなくても、実効塗りつぶしがテーマ色を継承し `Text1` や `Accent6` に解決されることがあります。逆に、`getSolidFillSchemeColor` は実効色を生成した論理テーマスロットを示しますが、そのスロットがオブジェクト、段落、レイアウト、マスター、または別のレベルから来たかは示しません。

次の例はプレゼンテーションをロードし、シェイプの塗りつぶしとテキスト部分の塗りつぶしを監査し、最終的な RGB 値と対応するスキーム色を出力し、テーマ色の変更に追随しない単色塗りつぶしをフラグ付けします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, Presentation, SchemeColor

def audit_fill(object_name, local_fill):
    effective_fill = local_fill.getEffective()
    if effective_fill.getFillType() != FillType.Solid:
        print(f"{object_name}: fill type = {effective_fill.getFillType()}; not a solid fill.")
        return

    rgb = effective_fill.getSolidFillColor()
    effective_scheme_color = effective_fill.getSolidFillSchemeColor()
    local_scheme_color = local_fill.getSolidFillColor().getSchemeColor()
    print(f"{object_name}: RGB = #{rgb.getRed():02X}{rgb.getGreen():02X}{rgb.getBlue():02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")
    if effective_scheme_color == SchemeColor.NotDefined:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


presentation = Presentation("input.pptx")
try:
    for slide_index, slide in enumerate(presentation.getSlides()):
        for shape_index, shape in enumerate(slide.getShapes()):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.getFillFormat())
            if isinstance(shape, AutoShape):
                for paragraph_index, paragraph in enumerate(shape.getTextFrame().getParagraphs()):
                    for portion_index, portion in enumerate(paragraph.getPortions()):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.getPortionFormat().getFillFormat())
finally:
    presentation.dispose()
```

`NotDefined` ブランチは、テーマ色スロットの変更に反応しない単色塗りつぶしの監査リストを提供します。ブランド パレットが変更されたときにこれらのオブジェクトをレビューしてください。報告された RGB 値は現在の外観を示し、スキーム値はその外観がテーマに接続されているかを説明します。

実効フォーマット オブジェクトはスナップショットです。プレゼンテーションテーマ、テーマ オーバーライド、または任意の継承書式設定を変更した後は、再度 `getEffective` を呼び出し、新しい実効塗りつぶしデータ オブジェクトを取得してから色を比較または報告してください。

## **有効なテーマ値の取得**

生のテーマ オブジェクトは特定レベルで定義されている内容を示しますが、有効値は継承とローカル オーバーライドが解決された後にスライドやシェイプが実際に使用しているものを示します。スライドの場合は [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) を呼び出します。背景の場合は [Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective)、塗りつぶしの場合は [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective) を使用します。

次の例はスライドから有効テーマ、背景、最初のシェイプの塗りつぶしを読み取ります。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    effective_theme = slide.getThemeManager().createThemeEffective()
    effective_background = slide.getBackground().getEffective()
    
    print("Effective major Latin font:", effective_theme.getFontScheme().getMajor().getLatinFont().getFontName())
    print("Effective minor Latin font:", effective_theme.getFontScheme().getMinor().getLatinFont().getFontName())
    print("Effective background fill type:", effective_background.getFillFormat().getFillType())
    if slide.getShapes().size() > 0:
        effective_fill = slide.getShapes().get_Item(0).getFillFormat().getEffective()
        print("First shape effective fill type:", effective_fill.getFillType())
        if effective_fill.getFillType() == FillType.Solid:
            print("First shape effective fill color:", effective_fill.getSolidFillColor())
finally:
    presentation.dispose()
```

レンダリング診断、検証、比較には有効データを使用してください。[Presentation.getMasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasterTheme) だけを検査すると、マスター、レイアウト、スライド、シェイプのオーバーライドで最終外観が変わっているケースを見落とす可能性があります。

## **FAQ**

**外部テーマを適用するとプレゼンテーション内のすべてのスライドに影響しますか？**

いいえ。[MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) は、選択したマスターに依存するスライドのみを再割り当てします。他のマスターを使用しているスライドは既存のテーマを保持します。

**マスターを変更せずに単一スライドにテーマを適用できますか？**

はい。スライドの [SlideThemeManager](https://reference.aspose.com/slides/python-java/aspose.slides/slidethememanager/) を使用し、オーバーライド テーマを初期化します。この変更はそのスライドにローカルに留まり、他のスライドは既存のテーマを継承し続けます。

**テーマを別のプレゼンテーションに安全に持ち込む最良の方法は？**

スライドを移動して元の外観を保持する場合は、[MasterSlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/#addClone) と [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) を使用して、ソース マスターを宛先にクローンし、そのマスターを使ってスライドをクローンします。これによりマスター、レイアウト、テーマが一緒に保持されます。

**継承とオーバーライドの後の有効値はどうやって確認できますか？**

スライドまたはレイアウトのテーマには [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) を使用し、フォーマット オブジェクト（例：[Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective) や [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective)）の対応する有効データ メソッドを使用します。これらの API は継承とオーバーライドが適用された後の解決された値を返します。