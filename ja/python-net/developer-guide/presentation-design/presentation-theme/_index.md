---
title: Python で PowerPoint プレゼンテーションテーマを管理する
linktitle: プレゼンテーションテーマ
type: docs
weight: 10
url: /ja/python-net/presentation-theme/
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
- Aspose.Slides
description: "Aspose.Slides for Python (.NET 経由) でマスタープレゼンテーションテーマを管理し、PowerPoint ファイルを一貫したブランドで作成、カスタマイズ、変換します。"
---
## **はじめに**

プレゼンテーションのテーマは、色、フォント、背景スタイル、塗りつぶし、線、エフェクトの調和したセットを定義します。テーマ対応オブジェクトは、各視覚プロパティを固定値として保持するのではなく、これらの共有定義を参照するため、テーマを変更すると多数のオブジェクトが一度に更新されます。

In Aspose.Slides、プレゼンテーションレベルのテーマは [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/) プロパティで利用できます。プレゼンテーションは下位レベルでもテーマのオーバーライドを含めることができます。マスターは [MasterThemeManager.override_theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/masterthememanager/override_theme/) を使用してプレゼンテーションテーマをオーバーライドでき、レイアウトは [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/) を使用して継承されたテーマをオーバーライドでき、個々のスライドも同様にオーバーライドできます。実際には、スライドの有効なテーマは次の継承チェーンを通じて解決されます：プレゼンテーションテーマ、マスターオーバーライド、レイアウトオーバーライド、スライドオーバーライド。

![テーマの構成要素: 色、フォント、背景スタイル、エフェクト](theme-constituents.png)

以下のセクションでは、最も一般的なテーマのワークフローを示します：テーマの検査、色とフォントの変更、テーマのコピーまたは適用、背景およびエフェクトスタイルの更新、そして継承とオーバーライドが解決された後の有効な値の取得。

## **テーマの検査**

[MasterTheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/) オブジェクトはテーマの [color_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/color_scheme/)、[font_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/font_scheme/)、[format_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/format_scheme/) プロパティを公開します。変更前にこれらのコレクションを検査することは、プレゼンテーションが外部ソースから来た場合に特に有用です。スタイルエントリの数と内容が変わり得るためです。

以下の例はメインテーマのプロパティを読み取り、テーマに格納されている背景、塗りつぶし、線、エフェクトスタイルの数を報告します。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    theme = presentation.master_theme

    print(f"Theme name: {theme.name}")
    print(f"Accent 1: {theme.color_scheme.accent1.color}")
    print(f"Major Latin font: {theme.font_scheme.major.latin_font.font_name}")
    print(f"Minor Latin font: {theme.font_scheme.minor.latin_font.font_name}")
    print(f"Background fill styles: {len(theme.format_scheme.background_fill_styles)}")
    print(f"Fill styles: {len(theme.format_scheme.fill_styles)}")
    print(f"Line styles: {len(theme.format_scheme.line_styles)}")
    print(f"Effect styles: {len(theme.format_scheme.effect_styles)}")
```

ファイルが複数のマスターを使用している場合、すべてのスライドが同じ有効テーマを持つと想定しないでください。スライドに関連付けられたマスターを検査し、レイアウトやスライドのオーバーライドが存在する可能性がある場合は、本記事後半で示す effective-theme ワークフローを使用してください。

## **テーマの色の変更**

テーマ対応の塗りつぶし、線、テキストは、[SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) 列挙体の論理色を参照できます。テーマの [ColorScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/colorscheme/) で対応するエントリを変更すると、そのテーマカラーを参照し続けているすべてのオブジェクトは新しい値に解決されます。直接 RGB カラーを使用しているオブジェクトは、テーマカラーの更新によって変更されません。

以下のエンドツーエンドの例は、`ACCENT4` を使用するシェイプを作成し、テーマの `accent4` カラーを赤に変更し、プレゼンテーションを保存して再度開き、最終的な塗りつぶしカラーを出力します。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    presentation.master_theme.color_scheme.accent4.color = draw.Color.red

    presentation.save("theme-color.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("theme-color.pptx") as saved_presentation:
    saved_slide = saved_presentation.slides[0]
    saved_shape = saved_slide.shapes[0]
    effective_fill = saved_shape.fill_format.get_effective()
    print(f"Effective fill color: {effective_fill.solid_fill_color}")
```

矩形は `ACCENT4` にリンクされたままであるため、テーマが変更された後は表示色が赤になります。シェイプ上のスキームカラーを直接のカラーに置き換えると、以降の `accent4` の変更はその塗りつぶしに影響しなくなります。

### **追加パレットから色を使用する**

PowerPoint はテーマカラーに対してカラー変換を適用し、明るいバリエーションと暗いバリエーションを生成します。Aspose.Slides はこれらの変換を [ColorTransformOperation](https://reference.aspose.com/slides/python-net/aspose.slides/colortransformoperation/) 列挙体で公開しています。

![メインテーマカラーと追加パレットから生成された明るい・暗いカラー](additional-palette-colors.png)

**1** - メインテーマカラー  
**2** - メインテーマカラーから生成された明るい・暗いバリエーション

以下の例は、`ACCENT4` を基にした 6 つの矩形を作成し、そのうち 5 つに輝度変換を適用し、結果を保存します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)
    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)
    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)
    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)
    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)

    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)
    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)
    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("theme-color-palette.pptx", slides.export.SaveFormat.PPTX)
```

これらのバリエーションはテーマカラーに基づいたものです。`accent4` が後で変更されると、変換されたカラーは新しい `accent4` 値から再計算されます。

### **`SchemeColor` の値を `ColorScheme` スロットにマップする**

[SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) 列挙体は `TEXT1`、`BACKGROUND1`、`TEXT2`、`BACKGROUND2` を使用し、[ColorScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/colorscheme/) は同じテーマスロットを `dark1`、`light1`、`dark2`、`light2` として公開しています。マッピングは固定です：

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

これらは同じテーマスロットの別名であり、ある形式から別の形式へ動的に変換される値ではありません。

## **テーマフォントの変更**

テーマフォントスキームは、見出し用のメジャーフォントセットと本文用のマイナーフォントセットを含みます。[FontScheme.major](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/major/) と [FontScheme.minor](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/minor/) プロパティでそれらのセットを取得できます。

PowerPoint 互換のテーマフォント識別子はテキスト書式設定で使用できます：

* `+mn-lt` - 本文フォント Latin（マイナー Latin フォント）
* `+mj-lt` - 見出しフォント Latin（メジャー Latin フォント）
* `+mn-ea` - 本文フォント East Asian（マイナー East Asian フォント）
* `+mj-ea` - 見出しフォント East Asian（メジャー East Asian フォント）
* `+mn-cs` - 本文フォント Complex Script（マイナー Complex Script フォント）
* `+mj-cs` - 見出しフォント Complex Script（メジャー Complex Script フォント）

以下の例は、メジャー Latin テーマフォントを使用した見出しと、マイナー Latin テーマフォントを使用した本文行を作成し、テーマフォントを変更して結果を保存します。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 500, 60)
    heading.text_frame.text = "Theme heading"
    heading.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mj-lt")

    body = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 120, 500, 60)
    body.text_frame.text = "Theme body text"
    body.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mn-lt")

    presentation.master_theme.font_scheme.major.latin_font = slides.FontData("Aptos Display")
    presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")

    presentation.save("theme-fonts.pptx", slides.export.SaveFormat.PPTX)
```

見出しはメジャーフォントに従い、本文はマイナーフォントに従います。テーマ識別子の代わりに明示的なフォント名が設定されているテキストは、テーマフォントスキームが変更されても自動的に切り替わりません。

メジャーおよびマイナーフォントコレクションには、キリル文字、アラビア文字、日本語、ジョージア文字、Thaana など、個別の書字システム用のフォントマッピングを含めることもできます。これらのマッピングを検査、追加、置換、削除するには、[Script-Specific Theme Fonts](/slides/ja/python-net/script-specific-font-mappings/) を参照してください。

{{% alert color="info" title="Tip" %}}
プレゼンテーションフォントに関する詳細は、[PowerPoint Fonts](/slides/ja/python-net/powerpoint-fonts/) を参照してください。
{{% /alert %}}

### **テーマフォント参照の解決**

テキストを検査する際、[FontData.font_name](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/font_name/) はフォントファミリー名の代わりに `+mn-lt` などのテーマ参照を含むことがあります。適切な [IThemeEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides.theme/ithemeeffectivedata/) を使用して [FontData.get_font_name](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/get_font_name/) を呼び出すと、その参照を解決できます。`+mj` と `+mn` プレフィックスはメジャーとマイナーフォントセットを選択し、`-lt`、`-ea`、`-cs` サフィックスはそれぞれ Latin、East Asian、Complex Script フォントを選択します。

検査対象のテキストに適用されるテーマを取得するには、そのオブジェクト上で [Slide.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides/slide/create_theme_effective/) を呼び出します。スライド上の通常テキストの場合、`slide.create_theme_effective` を使用すると、コンテキストにそのスライドの継承テーマとローカルオーバーライドが含まれます。レイアウトやマスター自体を検査する場合は、それぞれの有効テーマを使用してください。最初のマスターのテーマがすべてのスライドに適用されると想定しないでください。

以下の例は、マイナー Latin フォントを明示的に参照するテキスト部分を作成します。[OverrideTheme.init_font_scheme_from_inherited](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from_inherited/) を使用してスライドのフォントスキームを初期化し、メジャーとマイナーの Latin ファミリーをそれぞれ `Arial` と `Calibri` に設定することで、入力ファイルなしでも結果を再現可能にしています。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    theme = slide.theme_manager.override_theme
    theme.init_font_scheme_from_inherited()
    theme.font_scheme.major.latin_font = slides.FontData("Arial")
    theme.font_scheme.minor.latin_font = slides.FontData("Calibri")

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Text using the minor theme font"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.latin_font = slides.FontData("+mn-lt")

    font = portion.portion_format.latin_font
    effective_theme = slide.create_theme_effective()
    print(f"{font.font_name} -> {font.get_font_name(effective_theme)}")

    explicit_font = slides.FontData("Verdana")
    print(f"{explicit_font.font_name} -> {explicit_font.get_font_name(effective_theme)}")
```

出力は `+mn-lt -> Calibri` で、続いて `Verdana -> Verdana` となります。保存された参照は変更されず、明示的なファミリー名はそのまま返されます。テキスト部分が `+mj-lt` を使用していれば、このテーマでは `Arial` に解決されます。

テーマ参照を解決すると、テーマで指定されたフォントファミリーが特定されますが、フォントの利用可否のチェックや、置換やグリフフォールバック後に最終的に使用されるフォントファイルの決定は行いません。これらの別ステップについては、[Font Selection Sequence](/slides/ja/python-net/font-selection-sequence/) と [Font Substitution](/slides/ja/python-net/font-substitution/) を参照してください。

## **テーマのコピーまたは適用**

以下のワークフローは、さまざまなテーマ関連の課題を解決します。

### **外部テーマをマスター依存スライドに適用する**

[MasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/apply_external_theme_to_depending_slides/) を使用すると、PowerPoint テーマファイル（`.thmx`）があり、特定のマスターに依存するすべてのスライドのスタイルを変更したい場合に利用できます。[Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) コレクション（[MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/)）からマスターを選択し、テーマファイルのパスをメソッドに渡します。

このメソッドは以下の操作を実行します：

1. 選択したマスターを基に新しいマスタースライドを作成します。
1. 外部テーマを新しいマスターに適用します。
1. 以前に選択したマスターに依存していたすべてのスライドに新しいマスターを割り当てます。
1. 新しく作成した [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) を返します。

以下の例は、最初のマスターに依存するスライドに外部テーマを適用し、プレゼンテーションを保存します。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]

    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")
    print(f"Created master: {themed_master.name}")

    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

無効、破損、またはサポートされていないテーマは、[PptxException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxexception/) またはそのフォーマット関連サブクラスを引き起こす可能性があります。ユーザーから提供されたパスを検証し、ファイルシステムのアクセス失敗を処理し、テーマが正常に適用された後にのみプレゼンテーションを保存してください。

再割り当てされるのは、選択されたマスターに依存していたスライドだけです。他のマスターに関連付けられたスライドは既存のマスターとテーマを保持します。テーマ対応の色、フォント、塗りつぶし、線、背景、エフェクトは外部テーマに対して解決されます。直接割り当てられた色、フォント、塗りつぶし、その他の明示的な書式設定は変更されないままです。レイアウトレベルおよびスライドレベルのオーバーライドは、新しいマスターから継承された値よりも優先されることがあります。

テーマは実行環境に存在しないフォントを参照することがあります。一貫したレンダリングとエクスポートのために、必要なフォントをインストールするか、[custom font sources](/slides/ja/python-net/custom-font/) を通じて提供するか、[font substitution](/slides/ja/python-net/font-substitution/) を構成してください。

これは直接的なマスターレベルのワークフローです：メソッドは `.thmx` ファイルへのパスを受け取り、スライドレベルやレイアウトレベルのテーマオーバーライドを手動で作成する必要はありません。

### **マルチマスター プレゼンテーションで異なる外部テーマを適用する**

対象マスターが事前に分からない場合は、代表的なスライドから [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) と [LayoutSlide.master_slide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/master_slide/) を使用して取得します。テーマを適用する前に元のマスター参照を保存してください。呼び出しごとにプレゼンテーションに別のマスターが作成されます。

以下の例は、2 つのセクションのスライドを使用してそれぞれのマスターを特定し、各グループに異なる外部テーマを適用します。

```python
import aspose.slides as slides

with slides.Presentation("multi-master-presentation.pptx") as presentation:
    if len(presentation.slides) < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.slides[0].layout_slide.master_slide
        second_group_master = presentation.slides[4].layout_slide.master_slide

        if first_group_master.slide_id == second_group_master.slide_id:
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.apply_external_theme_to_depending_slides("blue-theme.thmx")
            second_themed_master = second_group_master.apply_external_theme_to_depending_slides("green-theme.thmx")

            print(f"First themed master: {first_themed_master.name}")
            print(f"Second themed master: {second_themed_master.name}")

            presentation.save("multi-master-with-external-themes.pptx", slides.export.SaveFormat.PPTX)
```

最初の呼び出しは `first_group_master` に依存するスライドのみを対象とし、2 回目の呼び出しは `second_group_master` に依存するスライドのみを対象とします。他のマスターに属するスライドはスタイルが変更されません。

### **スライド移動時に元のテーマを保持する**

スライドを別のプレゼンテーションに移動し、元のデザインを保持したい場合は、[MasterSlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/) でソースマスターをターゲットプレゼンテーションにクローンし、次に [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) とクローンしたマスターでスライドをクローンします。これにより、マスターとそのレイアウト、関連するテーマが一緒にコピーされます。

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        source_slide = source.slides[0]

        source_master = source_slide.layout_slide.master_slide
        cloned_master = target.masters.add_clone(source_master)
        target.slides.add_clone(source_slide, cloned_master, True)

        target.save("theme-preserved.pptx", slides.export.SaveFormat.PPTX)
```

ソーススライドが宛先でも同じ外観である必要がある場合に推奨されるワークフローです。無関係な宛先マスターにコンテンツだけをクローンすると、テーマに依存した色、フォント、背景、エフェクトが変更される可能性があります。

### **既存スライドにテーマ値を適用する**

対象スライドが現在のマスターとレイアウトに留まる必要がある場合、ソーステーマからスライドレベルのオーバーライドを初期化します。[OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/)、[OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/)、[OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) メソッドは、3 つの主要テーマコンポーネントをオーバーライドにコピーします。

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]

        override_theme = target_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)

        target.save("theme-applied-to-slide.pptx", slides.export.SaveFormat.PPTX)
```

これにより、他のスライドが継承するテーマを変更せずに、そのスライドが使用するテーマが変更されます。ローカルオーバーライドを削除して継承値に戻すには、[OverrideTheme.clear](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/clear/) を呼び出します。

### **レイアウトにテーマオーバーライドを適用する**

レイアウトレベルのオーバーライドは、そのレイアウトを使用するスライドに適用されます（ただし、特定のスライドが独自のオーバーライドを持つ場合は除く）。同じ初期化メソッドは、レイアウトの [LayoutSlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/layoutslidethememanager/) を介して使用できます：

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        
        override_theme = target_slide.layout_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)

        target.save("theme-applied-to-layout.pptx", slides.export.SaveFormat.PPTX)
```

多数のレイアウトやスライドが同一の基本デザインを共有すべき場合はマスターまたはプレゼンテーションレベルのテーマを使用し、1 つのレイアウトファミリーが別のスタイリングを必要とする場合はレイアウトオーバーライドを、真の例外の場合のみスライドオーバーライドを使用してください。スライドレベルのオーバーライドが過剰になると、以後のグローバルテーマ変更が予測しにくくなります。

## **テーマ背景スタイルの更新**

テーマの背景塗りつぶしは [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) に格納されています。PowerPoint の UI では、このコレクションに実際に格納されている塗りつぶし定義の数より多くの背景選択肢が提示されます。これは、UI がテーマ塗りつぶしとテーマカラー、その他のスタイル参照を組み合わせることができるためです。

![プレゼンテーションテーマの PowerPoint 背景スタイルギャラリー](presentation-design_8.png)

背景スタイルを使用する前に、格納されたコレクションと現在の [Background.style_index](https://reference.aspose.com/slides/python-net/aspose.slides/background/style_index/) を検査してください。`style_index` はテーマ塗りつぶしがない場合に `0` を使用し、正の値はテーマ背景スタイル参照を表します。これは、Python コレクションを直接インデックスする場合の `[0]` が最初の項目を指すのとは異なります。すべてのプレゼンテーションが同じ数の背景塗りつぶしスタイルを持つと想定しないでください。

以下の例は、利用可能な背景塗りつぶしの数を報告し、最初のマスターにテーマ背景参照を割り当て、プレゼンテーションを保存します。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:

    background_styles = presentation.master_theme.format_scheme.background_fill_styles
    print(f"Background fill styles: {len(background_styles)}")

    if len(background_styles) == 0:
        raise RuntimeError("The presentation theme does not contain background fill styles.")

    master_slide = presentation.masters[0]
    master_slide.background.type = slides.BackgroundType.THEMED
    master_slide.background.style_index = 1

    presentation.save("theme-background.pptx", slides.export.SaveFormat.PPTX)
```

表示結果は、マスターが参照するテーマエントリと、レイアウトまたはスライドレベルでの背景オーバーライドの有無に依存します。スライドが独自の背景を使用している場合、マスターの背景だけを変更してもそのスライドは変わらないことがあります。継承が適用された後の最終的な背景が必要な場合は、[Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/) を使用してください。

{{% alert color="warning" title="Warning" %}}
`style_index` をゼロベースのコレクションインデックスとして扱わないでください。また、あるファイルからスタイル番号をハードコードし、別のファイルでも同じ外観であると想定しないでください。テーマスタイル定義はプレゼンテーション固有です。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
直接的な背景書式設定や背景の継承については、[Presentation Background](/slides/ja/python-net/presentation-background/) を参照してください。
{{% /alert %}}

## **テーマエフェクトの更新**

テーマのフォーマットスキームは、[FormatScheme.fill_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/fill_styles/)、[FormatScheme.line_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/line_styles/)、[FormatScheme.effect_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/effect_styles/) の個別コレクションを含みます。一般的な Office テーマは、微妙、適度、強烈という視覚的なフォーマットに対応する 3 つの主要スタイルエントリを持つことが多いですが、コードでは固定された数を前提にせず、各コレクションを検査すべきです。

![同一シェイプに適用された微妙、適度、強烈なテーマエフェクト](presentation-design_10.png)

Python でこれらのコレクションにアクセスすると、コレクションインデックスはゼロベースです：`[0]` が最初のスタイル、`[2]` が3番目です。シェイプのスタイル参照インデックスは別概念で、[ShapeStyle](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/) を通じて公開されています。テーマスタイルを変更すると、そのテーマスタイルを参照しているシェイプに影響しますが、直接書式設定されたシェイプは変更されないままです。

以下の例は、必要なスタイルエントリが存在することを確認し、最初の線スタイルを変更し、3 番目の塗りスタイルを変更し、3 番目のエフェクトスタイルに外側の影を有効にして、結果を保存します。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Subtle_Moderate_Intense.pptx") as presentation:
    format_scheme = presentation.master_theme.format_scheme
    if len(format_scheme.line_styles) < 1 or len(format_scheme.fill_styles) < 3 or len(format_scheme.effect_styles) < 3:
        raise RuntimeError("The theme does not contain the style entries required by this example.")

    format_scheme.line_styles[0].fill_format.fill_type = slides.FillType.SOLID
    format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    format_scheme.effect_styles[2].effect_format.enable_outer_shadow_effect()
    format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    presentation.save("theme-effects.pptx", slides.export.SaveFormat.PPTX)
```

これらのスロットを参照しているシェイプでは、最初のテーマ線スタイルが赤になり、3 番目のテーマ塗りスタイルが濃い緑（フォレストグリーン）の単色になり、3 番目のエフェクトスタイルに距離 10 ポイントの外側の影が付与されます。正確な視覚結果は、各シェイプがどのスタイルスロットを参照しているか、また直接書式設定がテーマを上書きしているかに依存します。

![線、塗り、影設定変更後のテーマエフェクトスタイル](presentation-design_11.png)

## **シェイプのテーマ塗りと線スタイルの選択**

シェイプは [ShapeStyle.fill_style_index](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/fill_style_index/) と [ShapeStyle.line_style_index](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/line_style_index/) を使用して、塗りと輪郭を独立して選択できます。両プロパティとも、インデックス `1` は対応するテーマコレクションの最初のエントリ（`fill_styles[0]` または `line_styles[0]`）を選択し、インデックス `2` は2 番目のエントリを選択します。

以下の例は、新しいプレゼンテーションのデフォルトテーマで、2 つの塗り（金色と空色）と 2 つの輪郭（6 pt の濃い青、12 pt の濃い赤）を定義します。3 つの段階でスライドを保存し、PowerPoint で結果を比較できるようにします。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    styles = presentation.master_theme.format_scheme

    gold_fill = styles.fill_styles[0]
    gold_fill.fill_type = slides.FillType.SOLID
    gold_fill.solid_fill_color.preset_color = slides.PresetColor.GOLD
    blue_fill = styles.fill_styles[1]
    blue_fill.fill_type = slides.FillType.SOLID
    blue_fill.solid_fill_color.preset_color = slides.PresetColor.SKY_BLUE

    thin_line = styles.line_styles[0]
    thin_line.fill_format.fill_type = slides.FillType.SOLID
    thin_line.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
    thin_line.width = 6
    thick_line = styles.line_styles[1]
    thick_line.fill_format.fill_type = slides.FillType.SOLID
    thick_line.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_RED
    thick_line.width = 12

    shapes = presentation.slides[0].shapes
    left = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 205, 200, 130)
    right = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 420, 205, 200, 130)
    left.shape_style.fill_style_index = 1
    right.shape_style.fill_style_index = 2
    left.shape_style.line_style_index = 1
    right.shape_style.line_style_index = 1
    presentation.save("01-initial.pptx", slides.export.SaveFormat.PPTX)

    right.shape_style.line_style_index = 2
    presentation.save("02-line-changed.pptx", slides.export.SaveFormat.PPTX)

    gold_fill.solid_fill_color.preset_color = slides.PresetColor.SEA_GREEN
    presentation.save("03-theme-changed.pptx", slides.export.SaveFormat.PPTX)
```

| 初期スタイル | 右側の輪郭を変更 | 最初のテーマ塗りを編集 |
|:---:|:---:|:---:|
| ![金色と空色の矩形、薄い濃い青の輪郭が一致](theme-style-initial.png) | ![空色の矩形に太い濃い赤の輪郭が付いた](theme-style-line-changed.png) | ![左側の矩形が緑になり、両方の輪郭は変わっていない](theme-style-fill-changed.png) |

異なる線スタイルを選択すると、右側の矩形の輪郭だけが変更されます。最初のテーマ塗りを編集すると、それを使用しているすべてのシェイプが更新されます。この例では、左側の矩形だけが緑になります。

既存のシェイプでは、ローカルの塗りカラー、線カラー、線幅がテーマスタイルのその部分を上書きできます。スタイルインデックスを変更しても見た目に変化がない場合は、シェイプの [直接書式設定](/slides/ja/python-net/shape-formatting/) を確認してください。

## **有効な単色塗りがテーマカラーを使用しているかの判定**

塗りはオブジェクトに直接保存されるか、段落、レイアウト、マスター、テーマスタイル、または別の書式レベルから継承されることがあります。[FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/) を呼び出すと、その階層が不変の [IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/) に解決されます。まず [IFillFormatEffectiveData.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/fill_type/) を確認してください。`FillType.SOLID` の場合にのみ、単色塗りのプロパティを読み取ります。

単色塗りの場合、[IFillFormatEffectiveData.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) は継承、テーマルックアップ、カラー変換が適用された後の最終的な RGB 値を返します。[IFillFormatEffectiveData.solid_fill_scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/solid_fill_scheme_color/) は対応する論理 [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) スロット（例：`TEXT1` や `ACCENT6`）を返します。`SchemeColor.NOT_DEFINED` の値は、有効な単色塗りがスキームカラーに基づいていないことを意味します。塗りがテーマカラーまたは直接の RGB カラーのいずれかであるワークフローでは、この値は直接の RGB 塗りを識別します。

[ColorFormat.scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/scheme_color/) のローカル値だけで塗りを分類しないでください。たとえば、テキスト部分にローカルで定義されたスキームカラーがない場合、ローカル値は `NOT_DEFINED` ですが、実効塗りはテーマカラーを継承し、`TEXT1` や `ACCENT6` に解決されます。逆に、`solid_fill_scheme_color` は実効カラーを生成した論理テーマスロットを示しますが、そのスロットがオブジェクト、段落、レイアウト、マスター、または書式階層の別レベルから来たかは示しません。

以下の例は、プレゼンテーションをロードし、シェイプの塗りとテキスト部分の塗りの両方を監査し、各最終 RGB 値と関連するスキームカラーを出力し、テーマカラーの変更に追従しない単色塗りをフラグ付けします。

```python
import aspose.slides as slides


def audit_fill(object_name, local_fill):
    effective_fill = local_fill.get_effective()

    if effective_fill.fill_type != slides.FillType.SOLID:
        print(f"{object_name}: fill type = {effective_fill.fill_type}; not a solid fill.")
        return

    rgb = effective_fill.solid_fill_color
    effective_scheme_color = effective_fill.solid_fill_scheme_color
    local_scheme_color = local_fill.solid_fill_color.scheme_color

    print(f"{object_name}: RGB = #{rgb.r:02X}{rgb.g:02X}{rgb.b:02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")

    if effective_scheme_color == slides.SchemeColor.NOT_DEFINED:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


with slides.Presentation("input.pptx") as presentation:
    for slide_index, slide in enumerate(presentation.slides):
        for shape_index, shape in enumerate(slide.shapes):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.fill_format)

            if isinstance(shape, slides.AutoShape):
                for paragraph_index, paragraph in enumerate(shape.text_frame.paragraphs):
                    for portion_index, portion in enumerate(paragraph.portions):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.portion_format.fill_format)
```

`NOT_DEFINED` ブランチは、テーマカラースロットの変更に反応しない単色塗りの監査リストを提供します。プレゼンテーションが新しいブランドパレットに従う必要がある場合は、これらのオブジェクトを確認してください。報告された RGB 値は現在の外観を示し、スキーム値はその外観がテーマに結びついているかどうかを説明します。

有効な書式オブジェクトはスナップショットです。プレゼンテーションテーマ、テーマオーバーライド、または任意の継承書式を変更した後、再度 `get_effective` を呼び出し、新しい `IFillFormatEffectiveData` オブジェクトを取得してから色を比較または報告してください。

## **有効なテーマ値の取得**

生のテーマオブジェクトは特定のレベルで定義されている内容を示します。有効な値は、継承とローカルオーバーライドが解決された後にスライドやシェイプが実際に使用しているものを示します。スライドの場合は [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) を呼び出します。背景の場合は [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/)、塗りの場合は [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/) を使用します。

以下の例は、スライドから有効なテーマ、背景、最初のシェイプ塗りを読み取ります。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    effective_theme = slide.theme_manager.create_theme_effective()
    effective_background = slide.background.get_effective()

    print(f"Effective major Latin font: {effective_theme.font_scheme.major.latin_font.font_name}")
    print(f"Effective minor Latin font: {effective_theme.font_scheme.minor.latin_font.font_name}")
    print(f"Effective background fill type: {effective_background.fill_format.fill_type}")

    if len(slide.shapes) > 0:
        effective_fill = slide.shapes[0].fill_format.get_effective()
        print(f"First shape effective fill type: {effective_fill.fill_type}")
        if effective_fill.fill_type == slides.FillType.SOLID:
            print(f"First shape effective fill color: {effective_fill.solid_fill_color}")
```

有効データは、レンダリング診断、検証、比較に使用してください。[Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/) だけを検査すると、最終的な外観を変更するマスター、レイアウト、スライド、シェイプのオーバーライドを見逃す可能性があります。

## **よくある質問**

**外部テーマを適用すると、プレゼンテーション内のすべてのスライドに影響しますか？**

いいえ。[MasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/apply_external_theme_to_depending_slides/) は、選択したマスターに依存するスライドのみを再割り当てします。他のマスターを使用するスライドは既存のテーマを維持します。

**マスターを変更せずに、単一のスライドにテーマを適用できますか？**

はい。スライドの [SlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/slidethememanager/) を使用し、オーバーライドテーマを初期化します。この変更はそのスライドにローカルに留まり、他のスライドは既存のテーマを継承し続けます。

**あるプレゼンテーションから別のプレゼンテーションへテーマを安全に持ち込む最良の方法は何ですか？**

スライドを移動し、元の外観を保持する場合は、[MasterSlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/) と [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) を使用して、ソースマスターを宛先にクローンし、そのマスターでスライドをクローンします。これにより、マスター、レイアウト、テーマが一緒に保持されます。

**継承とオーバーライドの後の有効な値を確認するにはどうすればよいですか？**

スライドまたはレイアウトのテーマには [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) を使用し、[Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/) や [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/) などのフォーマットオブジェクトには対応する effective-data メソッドを使用してください。これらの API は、継承とオーバーライドが適用された後の解決された値を返します。