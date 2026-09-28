---
title: Pythonでプレゼンテーション スライド マスタを管理する
linktitle: スライド マスタ
type: docs
weight: 80
url: /ja/python-net/slide-master/
keywords:
- スライドマスタ
- マスタスライド
- PPTマスタスライド
- 複数のマスタスライド
- マスタスライドの比較
- 背景
- プレースホルダー
- マスタスライドのクローン
- マスタスライドのコピー
- マスタスライドの複製
- 未使用のマスタスライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET でスライドマスタを管理します：PowerPoint および OpenDocument プレゼンテーションでマスタスライドにアクセス、編集、クローン、比較、削除を行うことができます。"
---
## **概要**

**スライドマスタ**は、スライドのグループに対して共有デザイン設定を定義します。共通の図形、ロゴ、背景、テキストスタイル、テーマ設定、フッター設定などを含めることができます。PowerPoint では、スライドマスタを編集することで、各スライドで同じ書式設定を繰り返すことなくプレゼンテーションの一貫性を保つのが通常の方法です。

Aspose.Slides for Python via .NET でも同じモデルがサポートされています。プレゼンテーションは 1 つ以上のマスタースライドを含むことができ、各マスタースライドは複数のレイアウトスライドを保持できます。通常のスライドは直接マスタースライドを参照することはなく、レイアウトスライドを使用し、そのレイアウトスライドがマスタースライドに属します。

階層は次のとおりです。

1. **スライドマスタ** – 共有デザインとテーマを定義します。  
1. **レイアウトスライド** – プレースホルダーの配置とレイアウトレベルの書式設定を定義します。  
1. **ノーマルスライド** – 実際のプレゼンテーションコンテンツを含み、1 つのレイアウトスライドを使用します。

![マスタースライド、レイアウトスライド、ノーマルスライドの階層](slide-master_2.jpg)

Aspose.Slides では、スライドマスタは [MasterSlide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masterslide/) クラスで表されます。プレゼンテーション内のすべてのマスタースライドは `Presentation.masters` コレクションから取得できます。

{{% alert color="info" title="Inheritance" %}}
複数のレベルで同じプロパティが定義されている場合、より具体的なレベルが優先されます。たとえば、マスタースライドとレイアウトスライドの両方で背景が定義されている場合、そのレイアウトに基づくスライドはレイアウトの背景を使用します。レイアウトスライドの詳細については、[Apply or Change Slide Layouts](/slides/ja/python-net/slide-layout/) を参照してください。
{{% /alert %}}

## **スライドマスタへのアクセス**

PowerPoint では、**表示** > **スライドマスタ** からスライドマスタビューを開くことができます。

![PowerPoint の表示タブにあるスライドマスタ コマンド](slide-master_3.jpg)

Aspose.Slides では、`masters` コレクションを使用してマスタースライドにアクセスします：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

また、ノーマルスライドのレイアウトを介してそのマスタースライドを取得することもできます：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **スライドマスタに含まれるもの**

マスタースライドはスライドに類似したオブジェクトです。[BaseSlide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/baseslide/) クラスから共通のスライド動作を継承するため、ノーマルスライドやレイアウトスライドと同様の多数のスライドプロパティを提供します。マスタ固有のメンバーは [MasterSlide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masterslide/) API ページに一覧されています。

一般的に使用されるマスタースライドのメンバーは次のとおりです。

| メンバー | 用途 |
| --- | --- |
| `background` | マスターレベルのスライド背景を設定します。 |
| `shapes` | ロゴ、画像枠、共有テキストなど、マスタ上に配置された図形を格納します。 |
| `layout_slides` | マスタに属するレイアウトスライドを格納します。 |
| `theme_manager` | マスター テーマ API へのアクセスを提供します。 |
| `header_footer_manager` | マスタおよびその子レイアウトのヘッダー、フッター、日付、スライド番号を制御します。 |
| `get_depending_slides` | レイアウトを介してマスタに依存しているノーマルスライドを返します。 |

## **スライドマスタに画像を追加する**

マスタースライドに画像を追加すると、そのマスタのレイアウトを使用するすべてのスライドに画像が表示されます。ロゴ、透かし、装飾帯など、繰り返し使用する視覚要素に便利です。

次の例は、最初のマスタースライドにロゴを追加します：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    with open("logo.png", "rb") as logo_stream:
        logo_bytes = logo_stream.read()

    logo_image = presentation.images.add_image(logo_bytes)

    master_slide.shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE,
        20,
        20,
        80,
        80,
        logo_image)

    presentation.save("presentation-with-logo.pptx", slides.export.SaveFormat.PPTX)
```

画像枠の詳細については、[Picture Frame](/slides/ja/python-net/picture-frame/) を参照してください。

## **マスター グラフィックの表示/非表示を制御する**

[BaseSlide.show_master_shapes](https://reference.aspose.com/slides/ja/python-net/aspose.slides/baseslide/show_master_shapes/) を使用すると、マスタから継承されたロゴや装飾形状を削除せずに非表示にできます。該当スライドの [Slide.show_master_shapes](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/show_master_shapes/) を `False` に設定し、表示させたいスライドでは `True` のままにします。

以下の自己完結型サンプルは、マスタ上に青い装飾帯を作成し、同じ空白レイアウトを使用する 2 枚のスライドを生成します。最初のスライドでは帯が表示され、2 枚目では非表示になります。入力プレゼンテーションや画像は不要です。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]
    layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_slide.show_master_shapes = True

    slide_height = presentation.slide_size.size.height
    band = master_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 60, slide_height)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.steel_blue
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    visible_slide = presentation.slides[0]
    visible_slide.layout_slide = layout_slide
    visible_slide.shapes.clear()

    hidden_slide = presentation.slides.add_empty_slide(layout_slide)

    visible_slide.show_master_shapes = True
    hidden_slide.show_master_shapes = False

    presentation.save("master-graphics.pptx", slides.export.SaveFormat.PPTX)
```

この例は新規プレゼンテーションに同梱された **Blank** レイアウトを使用し、初期スライドのプレースホルダーを削除しています。

### **設定のスコープを選択する**

ノーマルスライドは [Slide.layout_slide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/layout_slide/) と [LayoutSlide.master_slide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutslide/master_slide/) を介してマスタを使用します。個々のスライドにプロパティを設定するとそのスライドだけに影響します。[LayoutSlide.show_master_shapes](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutslide/show_master_shapes/) を `False` に設定すると、その共有レイアウトを使用するすべてのスライドでマスター グラフィックが非表示になります（各スライドの設定が `True` でも同様）。1 枚だけ非表示にしたい場合は、スライドのプロパティを変更し、共有レイアウトはそのままにします。

マスタースライド自体では可視性制御はサポートされていません。マスタ上では常に `False` が返され、`True` を代入すると例外がスローされます。通常スライドまたはレイアウトに対して適用してください。

### **背景とグラフィックを区別する**

| 操作 | 効果 |
| --- | --- |
| マスター グラフィックを非表示にする | 継承されたマスター形状を削除せずに可視性だけを制御します。 |
| スライド背景の塗りつぶしを変更する | 背景色、グラデーション、画像を変更します。マスター グラフィックは別の形状として残り、背景上に表示されます。詳細は [Presentation Background](/slides/ja/python-net/presentation-background/) を参照してください。 |
| マスターから形状を削除する | 共有元の形状が削除され、以降そのマスタを使用するスライドからは利用できなくなります。 |

## **プレースホルダーの操作**

プレースホルダーは通常レイアウトスライド上で定義されます。マスタースライドは、そのレイアウトが継承する共有スタイルとテーマを提供し、各レイアウトは利用可能なプレースホルダーと配置場所を決定します。

PowerPoint では、スライドマスタビューでプレースホルダーコマンドが利用可能です。

![PowerPoint スライドマスタビューの「プレースホルダーの挿入」コマンド](slide-master_5.png)

Aspose.Slides で新しいプレースホルダーを追加するには、マスタに属するレイアウトスライドを操作します：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    blank_layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout_slide is None:
        blank_layout_slide = presentation.layout_slides.add(
            master_slide,
            slides.SlideLayoutType.BLANK,
            "Blank")

    blank_layout_slide.placeholder_manager.add_text_placeholder(60, 120, 600, 80)

    presentation.slides.add_empty_slide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", slides.export.SaveFormat.PPTX)
```

既存のプレースホルダー形状をフォーマットすることもできます。次の例はタイトルプレースホルダーを検索し、線形グラデーション塗りつぶしを適用します：

```python
import aspose.pydrawing as draw
import aspose.slides as slides


def find_placeholder(master_slide, placeholder_type):
    for shape in master_slide.shapes:
        if isinstance(shape, slides.AutoShape) and shape.placeholder is not None:
            if shape.placeholder.type == placeholder_type:
                return shape

    return None


with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    title_placeholder = find_placeholder(master_slide, slides.PlaceholderType.TITLE)

    if title_placeholder is not None:
        red_gradient_color = draw.Color.from_argb(255, 0, 0)
        purple_gradient_color = draw.Color.from_argb(128, 0, 128)

        title_placeholder.fill_format.fill_type = slides.FillType.GRADIENT
        title_placeholder.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
        title_placeholder.fill_format.gradient_format.gradient_stops.add(0, red_gradient_color)
        title_placeholder.fill_format.gradient_format.gradient_stops.add(1, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![ノーマルスライドで継承されたフォーマット済みタイトルプレースホルダー](slide-master_8.png)

プレースホルダーとテキストの書式設定の詳細は、[Set Prompt Text in Placeholder](/slides/ja/python-net/manage-placeholder/) と [Text Formatting](/slides/ja/python-net/text-formatting/) を参照してください。

## **スライドマスタの背景を変更する**

マスタ背景はレイアウトや背景を上書きしないスライドに継承されます。次の例は最初のマスタースライドに単色背景色を設定します：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    presentation.save("presentation-master-background.pptx", slides.export.SaveFormat.PPTX)
```

関連トピックは [Presentation Background](/slides/ja/python-net/presentation-background/) と [Presentation Theme](/slides/ja/python-net/presentation-theme/) を参照してください。

## **スライドマスタを別のプレゼンテーションにクローンする**

[MasterSlideCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masterslidecollection/) クラスの `add_clone` メソッドを使用して、マスタースライドを別のプレゼンテーションにコピーできます。コピーされたマスタは、宛先プレゼンテーションのレイアウトやスライドで使用できます。

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

ノーマルスライドとそのマスタをまとめてクローンする必要がある場合は、[Clone Slides](/slides/ja/python-net/clone-slides/) を参照してください。

## **複数のスライドマスタを追加する**

プレゼンテーションは複数のマスタースライドを保持できます。これは、セクションごとに異なるブランディング、ページ構成、テーマ設定が必要な場合に便利です。

![マスタースライドの挿入と管理に関する PowerPoint コマンド](slide-master_9.jpg)

次の例はデフォルトマスタをクローンし、クローンに別の背景を設定し、そのクローンマスタ配下に空白レイアウトを取得し、そのレイアウトに基づく新しいスライドを追加します：

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    default_master_slide = presentation.masters[0]
    section_master_slide = presentation.masters.add_clone(default_master_slide)

    section_master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    section_master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    section_master_slide.background.fill_format.solid_fill_color.color = draw.Color.light_steel_blue

    section_blank_layout = section_master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if section_blank_layout is None:
        section_blank_layout = presentation.layout_slides.add(
            section_master_slide,
            slides.SlideLayoutType.BLANK,
            "Section Blank")

    presentation.slides.add_empty_slide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", slides.export.SaveFormat.PPTX)
```

## **スライドマスタの比較**

マスタースライドは [BaseSlide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/baseslide/) クラスから継承された `equals` メソッドで比較できます。比較は構造と静的コンテンツ（形状、テキスト、書式設定、アニメーション、その他のスライド設定）を対象とし、スライド ID などの固有識別子や動的プレースホルダー値（現在の日付など）は比較対象外です。

```python
import aspose.slides as slides

with slides.Presentation("first.pptx") as first_presentation:
    with slides.Presentation("second.pptx") as second_presentation:
        first_presentation_master_count = len(first_presentation.masters)
        second_presentation_master_count = len(second_presentation.masters)

        for first_master_index in range(first_presentation_master_count):
            for second_master_index in range(second_presentation_master_count):
                first_master_slide = first_presentation.masters[first_master_index]
                second_master_slide = second_presentation.masters[second_master_index]
                are_master_slides_equal = first_master_slide.equals(second_master_slide)

                if are_master_slides_equal:
                    print(
                        "first.pptx master #{} equals second.pptx master #{}".format(
                            first_master_index,
                            second_master_index))
```

詳細は [Compare Presentation Slides](/slides/ja/python-net/compare-slides/) を参照してください。

## **スライドマスタ ビューを既定ビューに設定する**

プレゼンテーションの [ViewProperties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/viewproperties/) の `last_view` プロパティを使用して、PowerPoint が最初に開くビューを制御できます。次の例はスライドマスタビューでプレゼンテーションを開きます：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

その他のビュー設定は [Save Presentation](/slides/ja/python-net/save-presentation/) を参照してください。

## **未使用のスライドマスタを削除する**

プレゼンテーションには、もはやノーマルスライドで使用されていないマスタースライドが含まれることがあります。未使用のマスタを削除すると、ファイルサイズが削減され、テンプレートの保守が簡素化されます。

`masters` コレクションの `remove_unused` を使用して未使用マスタを削除します：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

また、[Compress](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/compress/) クラスの低コードメソッド `remove_unused_master_slides` も利用できます：

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**スライドマスタとレイアウトスライドの違いは何ですか？**

スライドマスタはテーマ、背景、共通図形、テキストスタイルなどの共有デザイン設定を定義します。レイアウトスライドはマスタに属し、プレースホルダーの具体的な配置を定義します。ノーマルスライドはレイアウトスライドを使用するため、レイアウトとマスタの両方から継承します。

**1 つのプレゼンテーションに複数のスライドマスタを含められますか？**

はい。プレゼンテーションは複数のスライドマスタを保持できます。異なるセクションで異なるビジュアル体系やブランディングが必要な場合に複数マスタを使用してください。

**プレースホルダーはマスタスライドに追加すべきですか、レイアウトスライドに追加すべきですか？**

ほとんどの場合、レイアウトスライドにプレースホルダーを追加します。共有のビジュアル要素や共通書式はマスタスライドに配置し、コンテンツ用プレースホルダーはノーマルスライドが使用するレイアウトに配置します。

**使用中のマスタスライドを削除できますか？**

できません。依存スライドがあるマスタスライドは直接削除できません。まずそれらのスライドを別のマスタ配下のレイアウトに移動するか、未使用マスタのみを削除するクリーンアップ手法を使用してください。