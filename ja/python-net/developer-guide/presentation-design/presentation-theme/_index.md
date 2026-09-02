---
title: Python で PowerPoint プレゼンテーション テーマを管理する
linktitle: プレゼンテーションテーマ
type: docs
weight: 10
url: /ja/python-net/presentation-theme/
keywords:
- PowerPoint テーマ
- プレゼンテーション テーマ
- スライド テーマ
- テーマの設定
- テーマの変更
- テーマの管理
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
description: ".NET を介した Python 用 Aspose.Slides でプレゼンテーションテーマをマスターし、PowerPoint ファイルを一貫したブランディングで作成、カスタマイズ、変換します。"
---
## **概要**

プレゼンテーションのテーマは、色、フォント、背景スタイル、塗りつぶし、線、エフェクトの調整されたセットを定義します。テーマ対応オブジェクトは、各ビジュアルプロパティを固定値として保持するのではなく、これらの共有定義を参照するため、テーマの変更により多数のオブジェクトを一度に更新できます。

Aspose.Slides では、プレゼンテーションレベルのテーマは [Presentation.master_theme](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/master_theme/) プロパティで取得できます。プレゼンテーションは下位レベルでもテーマのオーバーライドを保持できます。マスタは [MasterThemeManager.override_theme](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/masterthememanager/override_theme/) によってプレゼンテーションテーマをオーバーライドでき、レイアウトは [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/) によって継承されたテーマをオーバーライドでき、個々のスライドも同様にオーバーライドできます。実際には、スライドの有効テーマは次の継承チェーンで解決されます: プレゼンテーションテーマ、マスタオーバーライド、レイアウトオーバーライド、スライドオーバーライド。

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

以下のセクションでは、最も一般的なテーマ操作フローを示します。テーマの検査、色とフォントの変更、テーマのコピーまたは適用、背景とエフェクトスタイルの更新、そして継承とオーバーライドが解決された後の有効値の取得です。

## **テーマの検査**

[MasterTheme](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/mastertheme/) オブジェクトは、テーマの [color_scheme](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/mastertheme/color_scheme/)、[font_scheme](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/mastertheme/font_scheme/)、および [format_scheme](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/mastertheme/format_scheme/) プロパティを公開します。これらのコレクションを変更前に検査することは、プレゼンテーションが外部ソースから取得された場合に特に有用です。スタイルエントリの数と内容は変わる可能性があります。

次の例は、メインテーマのプロパティを読み取り、テーマに格納されている背景、塗りつぶし、線、エフェクトスタイルの数を報告します。

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

ファイルが複数のマスタを使用している場合、すべてのスライドが同じ有効テーマを持つとは限りません。スライドに関連付けられたマスタを検査し、レイアウトまたはスライドのオーバーライドが存在する可能性がある場合は、記事後半に示す有効テーマフローを使用してください。

## **テーマの色の変更**

テーマ対応の塗りつぶし、線、テキストは、[SchemeColor](https://reference.aspose.com/slides/ja/python-net/aspose.slides/schemecolor/) 列挙体の論理色を参照できます。テーマの [ColorScheme](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/colorscheme/) で対応するエントリを変更すると、そのテーマ色を参照し続けているすべてのオブジェクトが新しい値に解決されます。直接 RGB 色を使用しているオブジェクトは、テーマ色の更新によって変更されません。

次のエンドツーエンドの例は、`ACCENT4` を使用するシェイプを作成し、テーマの `accent4` 色を赤に変更し、プレゼンテーションを保存して再度開き、実際の塗りつぶし色を出力します。

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

矩形は `ACCENT4` にリンクされたままであるため、テーマが変更された後に表示色が赤になります。シェイプ上でスキーム色を直接の色に置き換えると、以降の `accent4` の変更はその塗りつぶしに影響しなくなります。

### **追加パレットからの色の使用**

PowerPoint はテーマ色に対して色変換を適用し、明るいバリエーションや暗いバリエーションを生成します。Aspose.Slides はこれらの変換を [ColorTransformOperation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/colortransformoperation/) 列挙体で公開しています。

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - メインテーマの色。

**2** - メインテーマの色から生成された明るいバリエーションと暗いバリエーション。

次の例は、`ACCENT4` に基づく 6 つの矩形を作成し、そのうち 5 つに輝度変換を適用し、結果を保存します。

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

これらのバリエーションはテーマカラーを基にしています。後で `accent4` が変更されると、変換された色は新しい `accent4` の値から再計算されます。

### **`SchemeColor` の値を `ColorScheme` のスロットにマッピング**

[SchemeColor](https://reference.aspose.com/slides/ja/python-net/aspose.slides/schemecolor/) 列挙体は `TEXT1`、`BACKGROUND1`、`TEXT2`、`BACKGROUND2` を使用し、[ColorScheme](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/colorscheme/) は同じテーマスロットを `dark1`、`light1`、`dark2`、`light2` として公開します。マッピングは固定です。

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

これらは同じテーマスロットの別名であり、動的に相互変換される値ではありません。

## **テーマのフォントの変更**

テーマのフォントスキームは、見出し用のメジャーフォントセットと本文用のマイナーフォントセットを含みます。[FontScheme.major](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/fontscheme/major/) と [FontScheme.minor](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/fontscheme/minor/) プロパティがそれらのセットを公開します。

PowerPoint 互換のテーマフォント識別子はテキスト書式設定で使用できます。

* `+mn-lt` - 本文フォント ラテン (Minor Latin Font)
* `+mj-lt` - 見出しフォント ラテン (Major Latin Font)
* `+mn-ea` - 本文フォント 東アジア (Minor East Asian Font)
* `+mj-ea` - 見出しフォント 東アジア (Major East Asian Font)

次の例は、メジャー ラテンテーマフォントを使用する見出しと、マイナー ラテンテーマフォントを使用する本文行をそれぞれ作成し、テーマフォントを変更して結果を保存します。

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

見出しはメジャーフォントに、本文テキストはマイナーフォントに従います。テーマ識別子ではなく明示的なフォント名が指定されているテキストは、テーマフォントスキームが変更されても自動的に切り替わりません。

{{% alert color="info" title="Tip" %}}
プレゼンテーションのフォントに関する詳細は、[PowerPoint Fonts](/slides/ja/python-net/powerpoint-fonts/) を参照してください。
{{% /alert %}}

## **テーマのコピーまたは適用**

一般的なワークフローは 2 つあり、解決すべき課題が異なります。

### **スライドを移動するときに元のテーマを保持する**

別のプレゼンテーションにスライドを移動し、元のデザインを保持したい場合は、[MasterSlideCollection.add_clone](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masterslidecollection/add_clone/) でソースマスタをターゲットプレゼンテーションにクローンし、その後 [SlideCollection.add_clone](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidecollection/add_clone/) でスライドとクローンマスタをクローンします。これにより、マスタ、レイアウト、および関連するテーマが一緒に持ち運ばれます。

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

これは、対象スライドが目的地でも同一の外観である必要がある場合に推奨されるワークフローです。無関係な宛先マスタにコンテンツだけをクローンすると、テーマ駆動の色、フォント、背景、エフェクトが変わる可能性があります。

### **既存スライドにテーマ値を適用する**

対象スライドが現在のマスタとレイアウトに留まる必要がある場合は、ソーステーマからスライドレベルのオーバーライドを初期化します。[OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/)、[OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/)、および [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) メソッドが 3 つの主要テーマコンポーネントをオーバーライドにコピーします。

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

これにより、他のスライドが継承しているテーマを変更せずに、そのスライドだけのテーマが変更されます。ローカルオーバーライドを削除して継承値に戻すには、[OverrideTheme.clear](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/overridetheme/clear/) を呼び出します。

### **レイアウトにテーマオーバーライドを適用する**

レイアウトレベルのオーバーライドは、そのレイアウトを使用するスライド全体に適用されますが、特定のスライドに独自のオーバーライドがある場合は例外となります。レイアウトの [LayoutSlideThemeManager](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/layoutslidethememanager/) を通じて同じ初期化メソッドが利用できます。

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

多くのレイアウトとスライドが同一のベースデザインを共有すべき場合はマスタまたはプレゼンテーションレベルのテーマを使用し、特定のレイアウトファミリに異なるスタイリングが必要な場合はレイアウトオーバーライドを、真の例外があるときだけスライドオーバーライドを使用してください。過度のスライドレベルオーバーライドは、後の全体テーマ変更を予測しにくくします。

## **テーマの背景スタイルの更新**

テーマの背景塗りつぶしは [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) に格納されています。PowerPoint の UI では、実際にコレクションに保存されている塗りつぶし定義の数以上の背景選択肢を提示できるのは、テーマ塗りつぶしとテーマカラー、その他のスタイル参照を組み合わせられるためです。

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

背景スタイルを使用する前に、保存されたコレクションと現在の [Background.style_index](https://reference.aspose.com/slides/ja/python-net/aspose.slides/background/style_index/) を検査してください。`style_index` が `0` の場合はテーマ塗りつぶしなしを意味し、正の値はテーマ背景スタイルへの参照です。これは Python コレクションのインデックスと異なり、`[0]` が最初の保存項目を意味します。すべてのプレゼンテーションが同じ数の背景塗りつぶしスタイルを持つとは限らないことに注意してください。

次の例は、利用可能な背景塗りつぶし数を報告し、最初のマスタにテーマ背景参照を割り当て、プレゼンテーションを保存します。

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

可視結果は、マスタが参照するテーマエントリと、レイアウトまたはスライドレベルでの背景オーバーライドの有無に依存します。スライドが独自の背景を使用している場合、マスタの背景だけを変更してもそのスライドは変わりません。継承後の最終背景を知りたいときは [Background.get_effective](https://reference.aspose.com/slides/ja/python-net/aspose.slides/background/get_effective/) を使用してください。

{{% alert color="warning" title="Warning" %}}
`style_index` をゼロベースのコレクションインデックスとみなさないでください。また、あるファイルから取得したスタイル番号をハードコーディングして別ファイルで同じ外観になると想定しないでください。テーマスタイル定義はプレゼンテーション固有です。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
直接的な背景書式設定と背景継承については、[Presentation Background](/slides/ja/python-net/presentation-background/) を参照してください。
{{% /alert %}}

## **テーマエフェクトの更新**

テーマのフォーマットスキームは、別々の [FormatScheme.fill_styles](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/formatscheme/fill_styles/)、[FormatScheme.line_styles](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/formatscheme/line_styles/)、および [FormatScheme.effect_styles](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/formatscheme/effect_styles/) コレクションを含みます。典型的な Office テーマは、微妙、適度、強烈なフォーマットに視覚的に対応する 3 つの主要スタイルエントリを含むことが多いですが、コード側では固定数を前提にせず各コレクションを検査すべきです。

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Python でこれらのコレクションにアクセスするときは、インデックスはゼロベースです: `[0]` が最初のスタイル、`[2]` が 3 番目のスタイルです。シェイプのスタイル参照インデックスは別概念で、[IShapeStyle](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ishapestyle/) を通じて公開されます。テーマスタイルを変更すると、そのテーマスタイルを参照するシェイプに影響しますが、直接書式設定されたシェイプは変更されないままです。

次の例は、必要なスタイルエントリが存在することを確認し、最初の線スタイル、3 番目の塗りつぶしスタイルを変更し、3 番目のエフェクトスタイルに外部シャドウ（距離 10 ポイント）を有効にして結果を保存します。

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

これらのスロットを参照するシェイプでは、最初のテーマ線スタイルが赤に、3 番目のテーマ塗りつぶしスタイルが森林緑の実体塗りつぶしに、3 番目のエフェクトスタイルが外部シャドウを持つようになります。最終的な視覚結果は、各シェイプがどのスタイルスロットを参照しているか、そして直接書式がテーマを上書きしているかに依存します。

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **有効なテーマ値の取得**

生のテーマオブジェクトは特定レベルで定義された内容を示します。有効値は、継承とローカルオーバーライドが解決された後にスライドやシェイプが実際に使用しているものを示します。スライドの場合は [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) を呼び出します。背景の場合は [Background.get_effective](https://reference.aspose.com/slides/ja/python-net/aspose.slides/background/get_effective/)、塗りつぶしの場合は [FillFormat.get_effective](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fillformat/get_effective/) を使用します。

次の例は、スライドから有効テーマ、背景、最初のシェイプ塗りつぶしを読み取ります。

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

レンダリング診断、検証、比較には有効データを使用してください。単に [Presentation.master_theme](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/master_theme/) を検査すると、最終的な外観を変えるマスタ、レイアウト、スライド、シェイプのオーバーライドを見逃す可能性があります。

## **FAQ**

**単一スライドに対してマスタを変更せずにテーマを適用できますか？**

はい。スライドの [SlideThemeManager](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/slidethememanager/) を使用し、オーバーライドテーマを初期化します。この変更はそのスライドだけにローカルに残り、他のスライドは既存のテーマを引き続き継承します。

**あるプレゼンテーションから別のプレゼンテーションへテーマを安全に持ち込む最良の方法は何ですか？**

スライドを移動して元の外観を保持する場合、[MasterSlideCollection.add_clone](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masterslidecollection/add_clone/) でソースマスタを宛先にクローンし、[SlideCollection.add_clone](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidecollection/add_clone/) でそのマスタを使用してスライドをクローンします。これによりマスタ、レイアウト、テーマが一緒に保持されます。

**継承とオーバーライドの後の有効値を確認するにはどうすればよいですか？**

スライドまたはレイアウトテーマに対しては [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) を使用し、[Background.get_effective](https://reference.aspose.com/slides/ja/python-net/aspose.slides/background/get_effective/) や [FillFormat.get_effective](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fillformat/get_effective/) などの対応する有効データメソッドをフォーマットオブジェクトに対して使用してください。これらの API は継承とオーバーライドが適用された後の解決済み値を返します。