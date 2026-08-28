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
- テーマ効果
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python (via .NET) でマスタープレゼンテーションテーマを管理し、PowerPoint ファイルを一貫したブランドで作成、カスタマイズ、変換します。"
---
## **はじめに**

プレゼンテーションのテーマは、色、フォント、背景スタイル、塗りつぶし、線、および効果の調整されたセットを定義します。テーマ対応オブジェクトは、すべての視覚プロパティを固定値として保持するのではなく、これらの共有定義を参照するため、テーマを変更すると多数のオブジェクトが一度に更新されます。

Aspose.Slidesでは、プレゼンテーションレベルのテーマは[Presentation.master_theme](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/master_theme/)プロパティから取得できます。プレゼンテーションは、下位レベルでもテーマのオーバーライドを保持できます。マスターは[MasterThemeManager.override_theme](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/masterthememanager/override_theme/)でプレゼンテーションテーマをオーバーライドでき、レイアウトは[BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/)で継承されたテーマをオーバーライドでき、個々のスライドも同様に行えます。実際には、スライドの有効テーマは次の継承チェーンで解決されます: プレゼンテーションテーマ、マスターオーバーライド、レイアウトオーバーライド、スライドオーバーライド。

![テーマ要素: 色、フォント、背景スタイル、効果](theme-constituents.png)

以下のセクションでは、最も一般的なテーマ操作フローを示します。テーマの検査、色とフォントの変更、テーマのコピーまたは適用、背景および効果スタイルの更新、継承とオーバーライドが解決された後の有効値の取得です。

## **テーマの検査**

[MasterTheme](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/mastertheme/)オブジェクトは、テーマの[color_scheme](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/mastertheme/color_scheme/)、[font_scheme](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/mastertheme/font_scheme/)、および[format_scheme](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/mastertheme/format_scheme/)プロパティを公開します。これらのコレクションを変更前に検査することは、プレゼンテーションが外部ソースから来た場合に特に有用です。スタイルエントリの数や内容はファイルごとに異なる可能性があります。

以下の例は、メインテーマのプロパティを読み取り、テーマに格納されている背景、塗りつぶし、線、効果スタイルの数を報告します。

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

ファイルが複数のマスターを使用している場合、すべてのスライドが同じ有効テーマを持つとは限りません。スライドに関連付けられたマスターを検査し、レイアウトやスライドのオーバーライドが存在する可能性がある場合は、後述の有効テーマフローを使用してください。

## **テーマの色を変更する**

テーマ対応の塗りつぶし、線、テキストは[SchemeColor](https://reference.aspose.com/slides/ja/python-net/aspose.slides/schemecolor/)列挙体の論理色を参照できます。テーマの[ColorScheme](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/colorscheme/)で対応するエントリを変更すると、そのテーマカラーを参照しているすべてのオブジェクトが新しい値に解決されます。直接RGB色を使用しているオブジェクトは、テーマカラーの更新の影響を受けません。

以下のエンドツーエンド例は、`ACCENT4` を使用するシェイプを作成し、テーマの `accent4` 色を赤に変更し、プレゼンテーションを保存して再度開き、有効な塗りつぶし色を出力します。

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

矩形が `ACCENT4` にリンクされたままであるため、テーマが変更されると表示色は赤になります。シェイプ上でスキームカラーを直接の色に置き換えると、以降の `accent4` の変更はその塗りつぶしに影響しなくなります。

### **追加パレットから色を使用する**

PowerPoint はテーマカラーに対して色変換を適用し、明るいバリエーションと暗いバリエーションを生成します。Aspose.Slides はこれらの変換を[ColorTransformOperation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/colortransformoperation/)列挙体で公開しています。

![追加パレットから生成されたメインテーマカラーと明暗色](additional-palette-colors.png)

**1** - メインテーマカラー。

**2** - メインテーマカラーから生成された明るい・暗いバリエーション。

以下の例は、`ACCENT4` を基にした 6 つの矩形を作成し、そのうち 5 つに輝度変換を適用して結果を保存します。

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

これらのバリエーションはテーマカラーを基にしています。後で `accent4` が変更されると、変換された色は新しい `accent4` 値から再計算されます。

### **`SchemeColor` の値を `ColorScheme` のスロットにマッピングする**

[SchemeColor](https://reference.aspose.com/slides/ja/python-net/aspose.slides/schemecolor/)列挙体は `TEXT1`、`BACKGROUND1`、`TEXT2`、`BACKGROUND2` を使用し、[ColorScheme](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/colorscheme/)は同じテーマスロットを `dark1`、`light1`、`dark2`、`light2` として公開します。マッピングは固定です。

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

これらは同一スロットの別名であり、動的に変換される値ではありません。

## **テーマフォントを変更する**

テーマフォントスキームには、見出し用のメジャーフォントセットと本文用のマイナーフォントセットが含まれます。[FontScheme.major](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/fontscheme/major/) および [FontScheme.minor](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/fontscheme/minor/) プロパティでそれらのセットにアクセスできます。

PowerPoint 互換のテーマフォント識別子はテキスト書式設定で使用できます。

* `+mn-lt` - 本文フォント ラテン (Minor Latin Font)
* `+mj-lt` - 見出しフォント ラテン (Major Latin Font)
* `+mn-ea` - 本文フォント 東アジア (Minor East Asian Font)
* `+mj-ea` - 見出しフォント 東アジア (Major East Asian Font)

以下の例は、メジャーラテンテーマフォントを使用した見出しと、マイナラテンテーマフォントを使用した本文行を作成し、テーマフォントを変更して結果を保存します。

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

見出しはメジャーフォントに従い、本文テキストはマイナーフォントに従います。テーマ識別子ではなく明示的なフォント名が指定されているテキストは、テーマフォントスキームが変更されても自動的に切り替わりません。

メジャーおよびマイナーフォントコレクションには、キリル文字、アラビア文字、日本語、ジョージア文字、ターナ文字など、個々の書字システム向けのフォントマッピングも含められます。これらのマッピングを検査、追加、置換、削除するには、[Script-Specific Theme Fonts](/slides/ja/python-net/script-specific-font-mappings/) を参照してください。

{{% alert color="info" title="Tip" %}}
プレゼンテーションのフォントに関する詳細は、[PowerPoint Fonts](/slides/ja/python-net/powerpoint-fonts/)をご参照ください。
{{% /alert %}}

## **テーマのコピーまたは適用**

以下のワークフローは、さまざまなテーマ関連の課題を解決します。

### **外部テーマをマスター依存スライドに適用する**

PowerPoint テーマファイル（`.thmx`）があり、特定のマスターに依存するすべてのスライドのスタイルを変更したい場合は、[IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/ja/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) を使用します。まず、[Presentation.masters](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/masters/) コレクション（[MasterSlideCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masterslidecollection/) を実装）からマスターを選択し、テーマファイルのパスをメソッドに渡します。

メソッドは以下の操作を行います。

1. 選択したマスターを基に新しいマスタースライドを作成します。
1. 外部テーマを新しいマスターに適用します。
1. 以前に選択したマスターに依存していたすべてのスライドに新しいマスターを割り当てます。
1. 新しく作成された[IMasterSlide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/imasterslide/) を返します。

以下の例は、最初のマスターに依存するスライドに外部テーマを適用し、プレゼンテーションを保存します。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]
    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")

    print(f"Created master: {themed_master.name}")
    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

無効、破損、またはサポートされていないテーマは[PptxException](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pptxexception/) またはそのフォーマット系サブクラスをスローする可能性があります。ユーザーが提供したパスを検証し、ファイルシステムアクセスの失敗を処理し、テーマが正常に適用されたことを確認してからプレゼンテーションを保存してください。

選択したマスターに依存していたスライドのみが再割り当てされます。他のマスターに関連付けられたスライドは既存のマスターとテーマを保持します。テーマ対応の色、フォント、塗りつぶし、線、背景、効果は外部テーマに対して解決されます。直接割り当てられた色、フォント、塗りつぶし、その他の明示的な書式設定は変更されないまま残ることがあります。レイアウトレベルおよびスライドレベルのオーバーライドは、新しいマスターから継承された値よりも優先されることがあります。

テーマが実行環境に存在しないフォントを参照している可能性があります。安定したレンダリングとエクスポートのために、必要なフォントをインストールするか、[カスタムフォント ソース](/slides/ja/python-net/custom-font/) を通じて提供するか、[フォント置換](/slides/ja/python-net/font-substitution/) を構成してください。

この操作はマスター レベルの直接ワークフローです。メソッドは `.thmx` ファイルへのパスを受け取り、スライドレベルまたはレイアウトレベルのテーマオーバーライドを手動で作成する必要はありません。

### **マルチマスタープレゼンテーションで異なる外部テーマを適用する**

対象マスターが事前に分からない場合は、[Slide.layout_slide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/layout_slide/) および [LayoutSlide.master_slide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutslide/master_slide/) を使用して代表的なスライドから取得します。テーマを適用する前に元のマスター参照を保存してください。呼び出しごとにプレゼンテーションに新しいマスターが作成されます。

以下の例は、2 つのセクションのスライドからマスターを取得し、各グループに異なる外部テーマを適用します。

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

最初の呼び出しは `first_group_master` に依存するスライドのみを対象とし、2 回目の呼び出しは `second_group_master` に依存するスライドのみを対象とします。他のマスターに属するスライドは再スタイリングされません。

### **スライド移動時に元テーマを保持する**

スライドを別のプレゼンテーションに移動し、元のデザインを保持したい場合は、[MasterSlideCollection.add_clone](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masterslidecollection/add_clone/) でソースマスターをターゲットプレゼンテーションにクローンし、続いて [SlideCollection.add_clone](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidecollection/add_clone/) でスライドとクローンしたマスターをクローンします。これにより、マスターとそのレイアウト、関連テーマが一緒にコピーされます。

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

このワークフローは、ソーススライドが宛先でも同じ外観を保つ必要がある場合に推奨されます。無関係な宛先マスターにコンテンツだけをクローンすると、テーマ駆動のカラー、フォント、背景、効果が変わる可能性があります。

### **既存スライドにテーマ値を適用する**

対象スライドを現在のマスターとレイアウトのままにしたい場合は、ソーステーマからスライドレベルのオーバーライドを初期化します。[OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/)、[OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/)、および[OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) メソッドが 3 つの主要テーマコンポーネントをオーバーライドにコピーします。

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

この操作により、他のスライドが継承しているテーマは変更せずに、そのスライドだけのテーマが変更されます。ローカルオーバーライドを削除して継承値に戻すには、[OverrideTheme.clear](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/overridetheme/clear/) を呼び出してください。

### **レイアウトにテーマオーバーライドを適用する**

レイアウトレベルのオーバーライドは、そのレイアウトを使用するスライドすべてに適用されます（ただし、個別スライドに独自のオーバーライドがある場合は除く）。同じ初期化メソッドはレイアウトの[LayoutSlideThemeManager](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/layoutslidethememanager/) を介して使用できます。

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

多数のレイアウトとスライドが同一の基本デザインを共有する必要がある場合はマスターまたはプレゼンテーションレベルのテーマを使用し、特定のレイアウトファミリが異なるスタイリングを必要とする場合はレイアウトオーバーライドを、真の例外のみを対象にする場合はスライドオーバーライドを使用してください。過度のスライドレベルオーバーライドは、後続のグローバルテーマ変更を予測しにくくします。

## **テーマの背景スタイルを更新する**

テーマの背景塗りつぶしは[FormatScheme.background_fill_styles](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/formatscheme/background_fill_styles/)に格納されます。PowerPoint の UI は、このコレクションに実際に保存されている塗りつぶし定義の数以上の背景オプションを提示できることがあります。これは、テーマ塗りつぶしをテーマカラーや他のスタイル参照と組み合わせて表示できるためです。

![プレゼンテーションテーマの背景スタイル ギャラリー](presentation-design_8.png)

背景スタイルを使用する前に、格納されたコレクションと現在の[Background.style_index](https://reference.aspose.com/slides/ja/python-net/aspose.slides/background/style_index/) を検査してください。`style_index` はテーマ塗りつぶしなしを示す `0` を使用し、正の値はテーマ背景スタイル参照を表します。これは Python コレクションのインデックスとは異なり、`[0]` が最初の項目を意味します。すべてのプレゼンテーションが同じ数の背景塗りつぶしスタイルを持つとは限らないことに注意してください。

以下の例は、利用可能な背景塗りつぶし数を報告し、最初のマスターにテーマ背景参照を割り当て、プレゼンテーションを保存します。

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

表示結果は、マスターが参照するテーマエントリと、レイアウトまたはスライドレベルでの背景オーバーライドの有無に依存します。スライドが独自の背景を使用している場合、マスター背景だけを変更してもそのスライドの表示は変わりません。継承が適用された後の最終背景を知りたい場合は、[Background.get_effective](https://reference.aspose.com/slides/ja/python-net/aspose.slides/background/get_effective/) を使用してください。

{{% alert color="warning" title="Warning" %}}
`style_index` をゼロベースのコレクションインデックスとして扱わないでください。また、あるファイルで使用したスタイル番号をハードコーディングして別のファイルでも同じ外観になると想定しないでください。テーマスタイル定義はプレゼンテーション固有です。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
直接的な背景書式設定と背景継承については、[Presentation Background](/slides/ja/python-net/presentation-background/) を参照してください。
{{% /alert %}}

## **テーマ効果を更新する**

テーマのフォーマットスキームは、別々の[FormatScheme.fill_styles](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/formatscheme/fill_styles/)、[FormatScheme.line_styles](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/formatscheme/line_styles/)、および[FormatScheme.effect_styles](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/formatscheme/effect_styles/)コレクションを含みます。一般的な Office テーマは、視覚的に微妙、適度、強いの 3 つの主要スタイルエントリを持つことが多いですが、コード側では固定数を想定せず、各コレクションを検査してください。

![同一シェイプに適用された微妙、適度、強いテーマ効果](presentation-design_10.png)

Python でこれらのコレクションにアクセスする場合、インデックスはゼロベースです: `[0]` が最初の保存スタイル、`[2]` が3番目です。シェイプのスタイル参照インデックスは別概念で、[IShapeStyle](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ishapestyle/) で公開されます。テーマスタイルを変更すると、そのテーマスタイルを参照しているシェイプに影響しますが、直接書式設定されたシェイプは変更されないままです。

以下の例は、必要なスタイルエントリが存在することを確認し、最初の線スタイルを変更し、3 番目の塗りつぶしスタイルを変更し、3 番目の効果スタイルに外側シャドウを有効にして結果を保存します。

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

これらのスロットを参照するシェイプに対しては、最初のテーマ線スタイルが赤に、3 番目のテーマ塗りつぶしスタイルが濃い森林緑に、3 番目の効果スタイルに距離 10 ポイントの外側シャドウが追加されます。最終的な視覚結果は、各シェイプがどのスロットを参照しているか、そして直接書式設定がテーマを上書きしているかに依存します。

![線、塗りつぶし、シャドウ設定変更後のテーマ効果スタイル](presentation-design_11.png)

## **有効な単色塗りつぶしがテーマカラーを使用しているか判断する**

塗りつぶしはオブジェクトに直接保存される場合や、段落、レイアウト、マスター、テーマスタイル、または他の書式レベルから継承される場合があります。階層を不変の[IFillFormatEffectiveData](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ifillformateffectivedata/)に解決するには、[FillFormat.get_effective](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fillformat/get_effective/) を呼び出します。まず[IFillFormatEffectiveData.fill_type](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ifillformateffectivedata/fill_type/) を確認し、`FillType.SOLID` の場合にのみ単色塗りつぶしプロパティを読み取ります。

単色塗りつぶしの場合、[IFillFormatEffectiveData.solid_fill_color](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) は継承、テーマ検索、色変換が適用された後の最終 RGB 値を返します。[IFillFormatEffectiveData.solid_fill_scheme_color](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ifillformateffectivedata/solid_fill_scheme_color/) は対応する論理[SchemeColor](https://reference.aspose.com/slides/ja/python-net/aspose.slides/schemecolor/) スロット（例: `TEXT1`、`ACCENT6`）を返します。`SchemeColor.NOT_DEFINED` は、有効単色塗りつぶしがスキームカラーに基づいていないことを意味します。テーマカラーまたは直接 RGB 色のいずれかで塗りつぶしが行われているワークフローでは、この値が直接 RGB 塗りつぶしを識別します。

ローカルの[IColorFormat.scheme_color](https://reference.aspose.com/slides/ja/python-net/aspose.slides/icolorformat/scheme_color/) 値だけで塗りつぶしを分類しないでください。たとえば、テキストの一部はローカルでスキームカラーが未定義（`NOT_DEFINED`）でも、実際の塗りつぶしはテーマカラーを継承して `TEXT1` や `ACCENT6` に解決されることがあります。逆に、`solid_fill_scheme_color` は有効色を生成した論理テーマスロットを示しますが、そのスロットがオブジェクト、段落、レイアウト、マスター、または他の書式階層のどこから来たかは示しません。

以下の例はプレゼンテーションを読み込み、シェイプ塗りつぶしとテキスト部分塗りつぶしの両方を監査し、最終 RGB 値と関連スキームカラーを出力し、テーマカラー変更に追従しない単色塗りつぶしをフラグします。

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

`NOT_DEFINED` ブランチは、テーマカラー スロットの変更に応答しない単色塗りつぶしの監査リストを提供します。新しいブランド パレットに合わせる必要があるプレゼンテーションでは、これらのオブジェクトを確認してください。報告された RGB 値は現在の外観を示し、スキーム値はその外観がテーマに接続されているかどうかを説明します。

有効フォーマットオブジェクトはスナップショットです。プレゼンテーションテーマ、テーマオーバーライド、または任意の継承書式を変更した後、`get_effective` を再度呼び出し、新しい `IFillFormatEffectiveData` オブジェクトを取得してから色を比較または報告してください。

## **有効なテーマ値を読み取る**

生のテーマオブジェクトは特定レベルで定義されているものを示します。有効値は、継承とローカルオーバーライドが解決された後、スライドやシェイプが実際に使用しているものを示します。スライドの場合は[BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) を呼び出します。背景の場合は[Background.get_effective](https://reference.aspose.com/slides/ja/python-net/aspose.slides/background/get_effective/)、塗りつぶしの場合は[FillFormat.get_effective](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fillformat/get_effective/) を使用します。

以下の例は、スライドから有効テーマ、背景、および最初のシェイプ塗りつぶしを読み取ります。

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

有効データはレンダリング診断、検証、比較に使用します。[Presentation.master_theme](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/master_theme/) だけを検査すると、マスター、レイアウト、スライド、またはシェイプのオーバーライドで最終外観が変わるケースを見逃す可能性があります。

## **FAQ**

**外部テーマを適用するとプレゼンテーション全体のスライドに影響しますか？**

いいえ。[IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/ja/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) は選択したマスターに依存するスライドだけを再割り当てします。他のマスターを使用しているスライドは既存のテーマを保持します。

**マスターを変更せずに単一のスライドにテーマを適用できますか？**

はい。スライドの[SlideThemeManager](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/slidethememanager/) を使用してオーバーライドテーマを初期化します。この変更はそのスライドにローカルに留まり、他のスライドは既存のテーマを継承し続けます。

**テーマを別のプレゼンテーションに安全に持ち込む方法は何ですか？**

スライドを移動して元の外観を保持する場合は、[MasterSlideCollection.add_clone](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masterslidecollection/add_clone/) でソースマスターを宛先にクローンし、[SlideCollection.add_clone](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidecollection/add_clone/) でそのマスターと共にスライドをクローンします。これにより、マスター、レイアウト、テーマが一緒に保持されます。

**継承とオーバーライドの後の有効値はどうやって確認できますか？**

スライドまたはレイアウトテーマには[BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/ja/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) を、背景や塗りつぶしなどのフォーマットオブジェクトにはそれぞれ[Background.get_effective](https://reference.aspose.com/slides/ja/python-net/aspose.slides/background/get_effective/) と[FillFormat.get_effective](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fillformat/get_effective/) を使用してください。これらの API は継承とオーバーライドが適用された後の解決された値を返します。