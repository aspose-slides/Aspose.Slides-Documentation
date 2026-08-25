---
title: Python でプレゼンテーション スライド マスターを管理する
linktitle: スライド マスター
type: docs
weight: 80
url: /ja/python-net/slide-master/
keywords:
- スライド マスター
- マスタースライド
- PPT マスタースライド
- 複数のマスタースライド
- マスタースライドの比較
- 背景
- プレースホルダー
- マスタースライドのクローン
- マスタースライドのコピー
- マスタースライドの複製
- 未使用のマスタースライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET でスライド マスターを管理します。PowerPoint および OpenDocument プレゼンテーションでマスタースライドにアクセス、編集、クローン、比較、削除が可能です。"
---
## **概要**

**スライド マスター**は、スライド群に対する共有デザイン設定を定義します。共通の図形、ロゴ、背景、テキスト スタイル、テーマ設定、フッター設定などを含めることができます。PowerPoint では、スライド マスターを編集することで、各スライドで同じ書式設定を繰り返すことなくプレゼンテーションの一貫性を保つのが一般的です。

Aspose.Slides for Python via .NET は同じモデルをサポートしています。プレゼンテーションは 1 つまたは複数のマスタースライドを含めることができ、各マスタースライドは複数のレイアウトスライドを保持できます。通常のスライドは直接マスタースライドを参照しません。代わりに、通常のスライドはレイアウトスライドを使用し、そのレイアウトスライドがマスタースライドに属します。

階層構造は次のとおりです。

1. **スライド マスター** – 共有デザインとテーマを定義します。  
1. **レイアウト スライド** – プレースホルダーの配置とレイアウトレベルの書式設定を定義します。  
1. **通常スライド** – 実際のプレゼンテーション コンテンツを保持し、1 つのレイアウト スライドを使用します。

![スライド マスター、レイアウト スライド、通常スライドの階層構造](slide-master_2.jpg)

Aspose.Slides では、スライド マスターは [MasterSlide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masterslide/) クラスで表されます。プレゼンテーション内のすべてのマスタースライドは `Presentation.masters` コレクションから取得できます。

{{% alert color="info" title="Inheritance" %}}
複数のレベルで同じプロパティが定義されている場合、より具体的なレベルが優先されます。たとえば、マスタースライドとレイアウト スライドの両方で背景が定義されている場合、そのレイアウトに基づくスライドはレイアウトの背景を使用します。レイアウト スライドの詳細については、[スライド レイアウトの適用または変更](/slides/ja/python-net/slide-layout/) を参照してください。
{{% /alert %}}

## **スライド マスターへのアクセス**

PowerPoint では、**表示** > **スライド マスター** からスライド マスター ビューを開くことができます。

![PowerPoint の表示タブにあるスライド マスター コマンド](slide-master_3.jpg)

Aspose.Slides では、`masters` コレクションを使用してマスタースライドにアクセスします。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

通常スライドのレイアウトを介して、そのスライドが使用しているマスタースライドを取得することもできます。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **スライド マスターに含まれるもの**

マスタースライドはスライドに類似したオブジェクトです。[BaseSlide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/baseslide/) クラスから共通のスライド 動作を継承しているため、通常スライドやレイアウト スライドと同様の多数のスライド プロパティを利用できます。マスター固有のメンバーは [MasterSlide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masterslide/) API ページに一覧があります。

一般的に使用されるマスタースライド メンバーは次のとおりです。

| メンバー | 用途 |
| --- | --- |
| `background` | マスター レベルのスライド背景を設定します。 |
| `shapes` | ロゴ、画像フレーム、共有テキストなど、マスター上に配置された図形を格納します。 |
| `layout_slides` | マスターに属するレイアウト スライドを格納します。 |
| `theme_manager` | マスター テーマ API へのアクセスを提供します。 |
| `header_footer_manager` | マスターとその子レイアウトのヘッダー、フッター、日付、スライド番号を制御します。 |
| `get_depending_slides` | レイアウトを介してマスターに依存している通常スライドを返します。 |

## **スライド マスターに画像を追加する**

マスタースライドに画像を追加すると、そのマスターのレイアウトを使用するすべてのスライドに画像が表示されます。ロゴや透かし、装飾帯など、繰り返し使用する視覚要素に便利です。

次の例は、最初のマスタースライドにロゴを追加します。

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

画像フレームの詳細については、[画像フレーム](/slides/ja/python-net/picture-frame/) を参照してください。

## **プレースホルダーの操作**

プレースホルダーは通常、レイアウト スライド上で定義されます。マスタースライドはそれらのレイアウトが継承する共有スタイルとテーマを提供し、各レイアウトが利用可能なプレースホルダーとその配置を決定します。

PowerPoint では、プレースホルダー コマンドはスライド マスター ビューで利用できます。

![PowerPoint のスライド マスター ビューにあるプレースホルダー挿入コマンド](slide-master_5.png)

Aspose.Slides で新しいプレースホルダーを追加するには、マスターに属するレイアウト スライドを操作します。

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

既存のプレースホルダー形状の書式設定も可能です。次の例はタイトル プレースホルダーを検索し、線形グラデーション塗りを適用します。

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

![通常スライドが継承した書式設定済みタイトル プレースホルダー](slide-master_8.png)

プレースホルダーおよびテキストの書式設定オプションの詳細は、[プレースホルダー内のプロンプト テキストの設定](/slides/ja/python-net/manage-placeholder/) と [テキストの書式設定](/slides/ja/python-net/text-formatting/) を参照してください。

## **スライド マスターの背景を変更する**

マスターの背景は、レイアウトやスライドが上書きしない限り継承されます。次の例は、最初のマスタースライドに単色の背景色を設定します。

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

関連トピックは、[プレゼンテーション 背景](/slides/ja/python-net/presentation-background/) と [プレゼンテーション テーマ](/slides/ja/python-net/presentation-theme/) を参照してください。

## **スライド マスターを別のプレゼンテーションにクローンする**

[MasterSlideCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masterslidecollection/) の `add_clone` メソッドを使用して、マスタースライドを別のプレゼンテーションにコピーできます。コピーされたマスターは、宛先プレゼンテーションのレイアウトやスライドで使用できます。

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

マスターとともに通常スライドもクローンする必要がある場合は、[スライドのクローン](/slides/ja/python-net/clone-slides/) を参照してください。

## **複数のスライド マスターを追加する**

プレゼンテーションは複数のマスタースライドを含めることができます。セクションごとに異なるブランディング、ページ構成、テーマ設定が必要な場合に便利です。

![マスタースライドの挿入と管理のための PowerPoint コマンド](slide-master_9.jpg)

次の例は、デフォルトマスターをクローンし、クローンに別の背景を設定し、そのクローンマスターの下に空のレイアウトを取得し、最後にそのレイアウトに基づく新しいスライドを追加します。

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

## **スライド マスターの比較**

マスタースライドは、[BaseSlide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/baseslide/) クラスから継承した `equals` メソッドで比較できます。比較は構造と静的コンテンツ（図形、テキスト、書式設定、アニメーション、その他のスライド設定）を対象とし、スライド ID などの一意識別子や現在の日付といった動的プレースホルダー値は比較しません。

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

詳細は、[プレゼンテーション スライドの比較](/slides/ja/python-net/compare-slides/) を参照してください。

## **スライド マスター ビューをデフォルトビューに設定する**

プレゼンテーションの [ViewProperties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/viewproperties/) の `last_view` プロパティを使用して、PowerPoint が最初に開くビューを制御できます。次の例は、プレゼンテーションをスライド マスター ビューで開きます。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

その他のビュー設定については、[プレゼンテーションの保存](/slides/ja/python-net/save-presentation/) を参照してください。

## **未使用のスライド マスターを削除する**

プレゼンテーションには、もはや通常スライドで使用されていないマスタースライドが含まれることがあります。未使用のマスターを削除すると、ファイルサイズの削減やテンプレート保守の簡素化につながります。

`masters` コレクションの `remove_unused` を使用して未使用マスターを削除します。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

また、[Compress](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/compress/) クラスの低コードメソッド `remove_unused_master_slides` も利用できます。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

### スライド マスターとレイアウト スライドの違いは何ですか？

スライド マスターはテーマ、背景、共通図形、テキスト スタイルなどの共有デザイン設定を定義します。レイアウト スライドはマスタースライドに属し、プレースホルダーの具体的な配置を定義します。通常スライドはレイアウト スライドを使用するため、レイアウトとマスターの両方から継承します。

### 1 つのプレゼンテーションに複数のスライド マスターを含めることはできますか？

はい。プレゼンテーションは複数のスライド マスターを含めることができます。セクションごとに異なるビジュアル システムやブランディングが必要な場合に、複数のマスターを使用してください。

### プレースホルダーはマスタースライドに追加すべきですか、レイアウト スライドに追加すべきですか？

ほとんどの場合、レイアウト スライドにプレースホルダーを追加します。共有のビジュアル要素や共通書式はマスタースライドに配置し、コンテンツ用のプレースホルダーは通常スライドが使用するレイアウトに配置します。

### まだ使用されているマスタースライドを削除できますか？

いいえ。依存スライドがあるマスタースライドは直接削除できません。まずそれらのスライドを別のマスターのレイアウトに移動するか、未使用マスターのみを削除するクリーンアップ手順を使用してください。