---
title: Python via Java でプレゼンテーションテーマを管理
linktitle: プレゼンテーションテーマ
type: docs
weight: 10
url: /ja/python-java/presentation-theme/
keywords:
- PowerPoint テーマ
- プレゼンテーションテーマ
- スライドテーマ
- テーマの設定
- テーマの変更
- テーマの管理
- 外部テーマ
- THMX
- テーマカラー
- 追加パレット
- テーマフォント
- テーマスタイル
- テーマエフェクト
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java でプレゼンテーションのテーマをマスターし、PowerPoint ファイルを一貫したブランディングで作成、カスタマイズ、変換します。"
---
## **はじめに**

プレゼンテーションテーマは、色、フォント、背景スタイル、塗り、線、エフェクトの調整されたセットを定義します。テーマ対応オブジェクトは、各視覚プロパティを固定値として保持するのではなく、これらの共有定義を参照するため、テーマを変更すると多数のオブジェクトが一度に更新されます。

Aspose.Slides では、プレゼンテーションレベルのテーマは[Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getMasterTheme)で取得できます。プレゼンテーションは下位レベルでテーマのオーバーライドを保持することもできます。マスターは[MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterthememanager/#getOverrideTheme)でプレゼンテーションテーマをオーバーライドでき、レイアウトや個々のスライドは[BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseoverridethememanager/#getOverrideTheme)で継承されたテーマをオーバーライドできます。実際には、スライドの有効テーマは次の継承チェーンで解決されます：プレゼンテーションテーマ、マスターオーバーライド、レイアウトオーバーライド、スライドオーバーライド。

![テーマの構成要素：色、フォント、背景スタイル、エフェクト](theme-constituents.png)

以下のセクションでは、最も一般的なテーマ操作を示します。テーマの検査、色とフォントの変更、テーマのコピーまたは適用、背景とエフェクトスタイルの更新、継承とオーバーライドが解決された後の有効値の取得です。

## **テーマの検査**

[MasterTheme](https://reference.aspose.com/slides/ja/python-java/aspose.slides/mastertheme/) オブジェクトは、[MasterTheme.getColorScheme](https://reference.aspose.com/slides/ja/python-java/aspose.slides/mastertheme/#getColorScheme)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/ja/python-java/aspose.slides/mastertheme/#getFontScheme)、[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ja/python-java/aspose.slides/mastertheme/#getFormatScheme) を通じてテーマのカラースキーム、フォントスキーム、フォーマットスキームを公開します。変更前にこれらのコレクションを検査すると、外部ソースから取得したプレゼンテーションの場合に、スタイルエントリの数や内容が異なることがあるため特に有用です。

次の例はメインテーマのプロパティを読み取り、テーマに格納されている背景、塗り、線、エフェクトスタイルの数を報告します。

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

ファイルが複数のマスターを使用している場合、すべてのスライドが同じ有効テーマを持つとは限りません。スライドに関連付けられたマスターを検査し、レイアウトやスライドのオーバーライドが存在する可能性がある場合は、後述の有効テーマワークフローを使用してください。

## **テーマの色の変更**

テーマ対応の塗り、線、テキストは[SchemeColor](https://reference.aspose.com/slides/ja/python-java/aspose.slides/schemecolor/) 列挙体の論理色を参照できます。[ColorScheme](https://reference.aspose.com/slides/ja/python-java/aspose.slides/colorscheme/) の該当エントリを変更すると、そのテーマカラーを参照し続けているすべてのオブジェクトが新しい値に解決されます。直接 RGB 色を使用しているオブジェクトはテーマカラーの更新の影響を受けません。

次のエンドツーエンドの例は、`Accent4` を使用したシェイプを作成し、テーマの `Accent4` を赤に変更し、プレゼンテーションを保存して再度開き、実際の塗りの色を出力します。

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

矩形は `Accent4` にリンクされたままであるため、テーマを変更すると表示色が赤になります。シェイプ上で直接色を置き換えると、以後の `Accent4` の変更はその塗りに影響しなくなります。

### **追加パレットからの色の使用**

PowerPoint はテーマカラーから明るいバリエーションと暗いバリエーションを色変換で導出します。Aspose.Slides はこれらの変換を[ColorTransformOperation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/colortransformoperation/) 列挙体で公開しています。

![メインテーマカラーと追加パレットから生成された明るい色と暗い色](additional-palette-colors.png)

**1** – メインテーマカラー。  
**2** – メインテーマカラーから生成された明るい色と暗い色。

次の例は `Accent4` を基にした 6 つの矩形を作成し、うち 5 つに輝度変換を適用し、結果を保存します。

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

これらのバリエーションはテーマカラーに基づいたままです。`Accent4` が後で変更されると、変換された色は新しい `Accent4` の値から再計算されます。

### **`SchemeColor` 値を `ColorScheme` スロットにマッピングする**

[SchemeColor](https://reference.aspose.com/slides/ja/python-java/aspose.slides/schemecolor/) 列挙体は `Text1`、`Background1`、`Text2`、`Background2` を使用し、[ColorScheme](https://reference.aspose.com/slides/ja/python-java/aspose.slides/colorscheme/) は同じテーマスロットを `Dark1`、`Light1`、`Dark2`、`Light2` として公開します。マッピングは固定です。

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

これらは同一テーマスロットの別名であり、動的に変換される値ではありません。

## **テーマのフォントの変更**

テーマフォントスキームは見出し用のメジャーフォントセットと本文用のマイナーフォントセットを含みます。[FontScheme.getMajor](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontscheme/#getMajor) と [FontScheme.getMinor](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontscheme/#getMinor) メソッドでそれらのセットを取得できます。

PowerPoint 互換のテーマフォント識別子はテキスト書式設定で使用できます。

* `+mn-lt` – 本文フォント ラテン (Minor Latin Font)  
* `+mj-lt` – 見出しフォント ラテン (Major Latin Font)  
* `+mn-ea` – 本文フォント 東アジア (Minor East Asian Font)  
* `+mj-ea` – 見出しフォント 東アジア (Major East Asian Font)

次の例は、メジャーラテンテーマフォントを使用した見出しと、マイナーラテンテーマフォントを使用した本文行を作成し、テーマフォントを変更して結果を保存します。

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

見出しはメジャーフォントに従い、本文はマイナーフォントに従います。テーマ識別子ではなく明示的なフォント名が指定されているテキストは、テーマフォントスキームが変更されても自動的には切り替わりません。

メジャーとマイナーフォントコレクションは、キリル文字、アラビア文字、日本語、ジョージア文字、サーナ文字など個別の書字体系向けフォントマッピングも保持できます。これらのマッピングを検査、追加、置換、削除する場合は、[Script-Specific Theme Fonts](/slides/ja/python-java/script-specific-font-mappings/) を参照してください。

{{% alert color="success" title="ヒント" %}}
プレゼンテーションフォントに関する詳細は、[PowerPoint Fonts](/slides/ja/python-java/powerpoint-fonts/) をご覧ください。
{{% /alert %}}

## **テーマのコピーまたは適用**

以下のワークフローは、さまざまなテーマ関連の問題を解決します。

### **外部テーマをマスター依存スライドに適用する**

PowerPoint テーマファイル (`.thmx`) があり、特定のマスターに依存するすべてのスライドのスタイルを変更したい場合は、[MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) を使用します。[Presentation.getMasters](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getMasters) コレクションからマスターを選択し、[MasterSlideCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslidecollection/) で取得したマスターにテーマファイルのパスを渡します。

メソッドは次の操作を実行します。

1. 選択したマスターを基に新しいマスタースライドを作成します。  
2. 外部テーマを新しいマスターに適用します。  
3. 以前に選択したマスターに依存していたすべてのスライドに新しいマスターを割り当てます。  
4. 新しく作成された [MasterSlide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslide/) を返します。

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

無効、破損、またはサポートされていないテーマは [PptxReadException](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pptxreadexception/) をスローする可能性があります。ユーザーが提供したパスを検証し、ファイルシステムアクセスの失敗を処理し、テーマの適用が成功した後にだけプレゼンテーションを保存してください。

選択したマスターに依存していたスライドのみが再割り当てされます。他のマスターに関連付けられたスライドは既存のマスターとテーマを保持します。テーマ対応の色、フォント、塗り、線、背景、エフェクトは外部テーマに対して解決されますが、直接割り当てられた色やフォントなどの明示的書式は変更されないことがあります。レイアウトレベルおよびスライドレベルのオーバーライドは、新しいマスターから継承された値よりも優先される場合があります。

テーマが実行環境に存在しないフォントを参照することがあります。安定したレンダリングとエクスポートのために、必要なフォントをインストールするか、[カスタムフォント ソース](/slides/ja/python-java/custom-font/) を使用するか、[フォント置換](/slides/ja/python-java/font-substitution/) を構成してください。

この手順はマスターレベルの直接ワークフローです。メソッドは `.thmx` ファイルへのパスを受け取り、スライドレベルやレイアウトレベルのテーマオーバーライドを手動で作成する必要はありません。

### **マルチマスター プレゼンテーションで異なる外部テーマを適用する**

対象マスターが事前に分からない場合、[Slide.getLayoutSlide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#getLayoutSlide) と [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutslide/#getMasterSlide) で代表的なスライドから取得します。テーマを適用する前に元のマスター参照を保存してください。各呼び出しはプレゼンテーションに新しいマスターを作成します。

次の例は、2 つのセクションのスライドからそれぞれのマスターを特定し、各グループに異なる外部テーマを適用します。

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

最初の呼び出しは `first_group_master` に依存するスライドのみを変更し、2 回目は `second_group_master` に依存するスライドのみを変更します。他のマスターに属するスライドは再スタイル化されません。

### **スライド移動時に元テーマを保持する**

スライドを別のプレゼンテーションに移動し、元のデザインを保持したい場合は、[MasterSlideCollection.addClone](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslidecollection/#addClone) でソースマスターをターゲットにクローンし、続いて [SlideCollection.addClone](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#addClone) でスライドとクローンしたマスターをクローンします。これによりマスター、レイアウト、関連テーマが一緒に転送されます。

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

この手順は、ソーススライドが宛先でも同一の外観になることが求められる場合に推奨されます。無関係な宛先マスターにコンテンツだけをクローンすると、テーマ駆動の色、フォント、背景、エフェクトが変わってしまうことがあります。

### **既存スライドにテーマ値を適用する**

対象スライドを現在のマスターとレイアウトのままにしたい場合は、ソーステーマからスライドレベルのオーバーライドを初期化します。[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ja/python-java/aspose.slides/overridetheme/#initColorSchemeFrom)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ja/python-java/aspose.slides/overridetheme/#initFontSchemeFrom)、[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ja/python-java/aspose.slides/overridetheme/#initFormatSchemeFrom) メソッドで 3 つの主要テーマコンポーネントをオーバーライドにコピーします。

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

この操作により、他のスライドが継承するテーマは変わらず、対象スライドだけが新しいテーマで描画されます。ローカルオーバーライドを削除して継承値に戻すには、[OverrideTheme.clear](https://reference.aspose.com/slides/ja/python-java/aspose.slides/overridetheme/#clear) を呼び出します。

### **レイアウトにテーマオーバーライドを適用する**

レイアウトレベルのオーバーライドは、そのレイアウトを使用するスライドすべてに適用されます（ただし個別スライドに独自オーバーライドがある場合は除く）。同じ初期化メソッドは [LayoutSlideThemeManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutslidethememanager/) を通じても使用できます。

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

多数のレイアウトやスライドが同一の基本デザインを共有すべき場合はマスターまたはプレゼンテーションレベルのテーマを使用し、特定のレイアウトファミリだけが異なるスタイルを必要とする場合はレイアウトオーバーライドを、例外的なケースだけはスライドオーバーライドを使用してください。過度のスライドレベルオーバーライドは、後の全体テーマ変更を予測しにくくします。

## **テーマの背景スタイルを更新する**

テーマの背景塗りは [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ja/python-java/aspose.slides/formatscheme/#getBackgroundFillStyles) に格納されています。PowerPoint の UI では、テーマ塗りとテーマカラーや他のスタイル参照を組み合わせて、実際に格納されている塗り定義よりも多くの背景選択肢を提示できます。

![プレゼンテーションテーマの背景スタイル ギャラリー](presentation-design_8.png)

背景スタイルを使用する前に、格納されたコレクションと現在の [Background.getStyleIndex](https://reference.aspose.com/slides/ja/python-java/aspose.slides/background/#getStyleIndex) を検査してください。インデックス `0` はテーマ塗りが無いことを意味し、正の値はテーマ背景スタイル参照です。これはコレクションの直接インデックスと異なり、`get_Item(0)` は最初に格納された項目を指します。すべてのプレゼンテーションが同じ数の背景塗りスタイルを持つとは限りません。

次の例は利用可能な背景塗り数を報告し、最初のマスターにテーマ背景参照を割り当て、プレゼンテーションを保存します。

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

表示結果はマスターが参照するテーマエントリと、レイアウトまたはスライドレベルでの背景オーバーライドの有無に依存します。スライドが独自の背景を使用している場合、マスター背景だけを変更してもそのスライドは変わりません。継承が適用された最終背景を知りたいときは [Background.getEffective](https://reference.aspose.com/slides/ja/python-java/aspose.slides/background/#getEffective) を使用してください。

{{% alert color="warning" title="警告" %}}
スタイルインデックスはゼロベースのコレクションインデックスとして扱わないでください。また、あるファイルでのスタイル番号をハードコーディングして別ファイルで同じ外観になると想定しないでください。テーマスタイル定義はプレゼンテーション固有です。
{{% /alert %}}

{{% alert color="success" title="ヒント" %}}
直接的な背景書式設定と背景継承については、[Presentation Background](/slides/ja/python-java/presentation-background/) を参照してください。
{{% /alert %}}

## **テーマエフェクトの更新**

テーマフォーマットスキームは、[FormatScheme.getFillStyles](https://reference.aspose.com/slides/ja/python-java/aspose.slides/formatscheme/#getFillStyles)、[FormatScheme.getLineStyles](https://reference.aspose.com/slides/ja/python-java/aspose.slides/formatscheme/#getLineStyles)、[FormatScheme.getEffectStyles](https://reference.aspose.com/slides/ja/python-java/aspose.slides/formatscheme/#getEffectStyles) を通じて別々の塗り、線、エフェクトスタイルコレクションを公開します。一般的な Office テーマは、微妙、標準、強いフォーマットに対応する 3 つの主要エントリを持つことが多いですが、コード側では固定数を前提にせず各コレクションを検査してください。

![同一シェイプに適用された微妙、標準、強いテーマエフェクト](presentation-design_10.png)

Python から Java を呼び出す場合、コレクションインデックスはゼロベースです：`get_Item(0)` が最初のスタイル、`get_Item(2)` が 3 番目のスタイルです。シェイプのスタイル参照インデックスは別概念で、[ShapeStyle](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapestyle/) で公開されます。テーマスタイルを変更するとそのテーマスタイルを参照しているシェイプに影響し、直接書式設定されたシェイプは変更されない場合があります。

次の例は必要なスタイルエントリが存在することを確認し、最初の線スタイル、3 番目の塗りスタイルを変更し、3 番目のエフェクトスタイルに外部シャドウを有効化して結果を保存します。

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

これらのスロットを参照しているシェイプでは、最初のテーマ線スタイルが赤に、3 番目のテーマ塗りスタイルが濃い森林緑に、3 番目のエフェクトスタイルに距離 10 ポイントの外部シャドウが追加されます。最終的な見た目は各シェイプがどのスロットを参照しているか、直接書式設定が上書きしているかに依存します。

![線、塗り、シャドウ設定変更後のテーマエフェクトスタイル](presentation-design_11.png)

## **実効ソリッド塗りがテーマカラーを使用しているか判定する**

塗りはオブジェクトに直接格納されるか、段落、レイアウト、マスター、テーマスタイル、または別の書式レベルから継承されます。[FillFormat.getEffective](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fillformat/#getEffective) を呼び出して階層を解決し、変更不可能な実効塗りデータを取得します。まず実効データオブジェクトの `getFillType` を確認し、`FillType.Solid` の場合にのみソリッド塗りプロパティを読みます。

ソリッド塗りの場合、`getSolidFillColor` は継承、テーマ参照、色変換が適用された最終的な RGB 値を返します。`getSolidFillSchemeColor` は対応する論理 [SchemeColor](https://reference.aspose.com/slides/ja/python-java/aspose.slides/schemecolor/) スロット（例：`Text1` や `Accent6`）を返します。`SchemeColor.NotDefined` は実効ソリッド塗りがスキーマカラーに基づいていないことを意味し、直接 RGB 塗りであることを示します。

ローカルの [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/ja/python-java/aspose.slides/colorformat/#getSchemeColor) のみで塗りを分類しないでください。たとえばテキストの一部にローカルでスキーマカラーが未定義（`NotDefined`）でも、実効塗りはテーマカラーを継承して `Text1` や `Accent6` になることがあります。逆に `getSolidFillSchemeColor` は論理テーマスロットを示しますが、そのスロットがどのレベルから来たかは示しません。

次の例はプレゼンテーションを読み込み、シェイプ塗りとテキスト部分塗りの両方を監査し、最終的な RGB 値と関連スキーマカラーを出力し、テーマカラーの変更に追随しないソリッド塗りをフラグします。

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

`NotDefined` の分岐は、テーマカラー スロットの変更に反応しないソリッド塗りの監査リストを提供します。新しいブランド パレットに合わせる必要があるプレゼンテーションでは、これらのオブジェクトを確認してください。報告された RGB 値は現在の外観を示し、スキーマ値はその外観がテーマに接続されているかを説明します。

実効フォーマットオブジェクトはスナップショットです。プレゼンテーションテーマ、テーマオーバーライド、または任意の継承書式を変更した後は、再度 `getEffective` を呼び出し、新しい実効塗りデータオブジェクトを取得してから比較または報告してください。

## **有効なテーマ値の取得**

生のテーマオブジェクトは特定レベルで定義されている内容を示します。有効値は継承とローカルオーバーライドが解決された後、スライドやシェイプが実際に使用しているものを示します。スライドの場合は [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) を呼び出します。背景の場合は [Background.getEffective](https://reference.aspose.com/slides/ja/python-java/aspose.slides/background/#getEffective)、塗りの場合は [FillFormat.getEffective](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fillformat/#getEffective) を使用します。

次の例はスライドから有効テーマ、背景、最初のシェイプ塗りを取得します。

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

レンダリング診断、検証、比較には有効データを使用してください。単に [Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getMasterTheme) を調べるだけでは、マスター、レイアウト、スライド、シェイプのオーバーライドで最終外観が変わっているケースを見落とす可能性があります。

## **FAQ**

**外部テーマを適用するとプレゼンテーション内のすべてのスライドに影響しますか？**

いいえ。[MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) は選択したマスターに依存するスライドのみを再割り当てします。他のマスターを使用しているスライドは既存のテーマを保持します。

**マスターを変更せずに単一スライドにテーマを適用できますか？**

はい。スライドの [SlideThemeManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidethememanager/) を使用し、オーバーライドテーマを初期化します。この変更は対象スライドにローカルに留まり、他のスライドは既存テーマを継承し続けます。

**テーマを別のプレゼンテーションに安全に持ち込む方法は？**

スライドを移動して元の外観を保持する場合は、[MasterSlideCollection.addClone](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslidecollection/#addClone) でソースマスターを宛先にクローンし、続いて [SlideCollection.addClone](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidecollection/#addClone) でそのマスターとともにスライドをクローンします。これによりマスター、レイアウト、テーマが一緒に保持されます。

**継承とオーバーライド後の有効値を確認するには？**

スライドまたはレイアウトテーマには [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) を、フォーマットオブジェクトには対応する有効データメソッド（例：[Background.getEffective](https://reference.aspose.com/slides/ja/python-java/aspose.slides/background/#getEffective) や [FillFormat.getEffective](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fillformat/#getEffective)）を使用してください。これらの API は継承とオーバーライドが適用された後の解決済み値を返します。