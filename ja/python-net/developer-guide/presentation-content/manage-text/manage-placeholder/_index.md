---
title: Python でプレゼンテーションのプレースホルダーを管理する
linktitle: プレースホルダーを管理する
type: docs
weight: 10
url: /ja/python-net/manage-placeholder/
keywords:
- プレースホルダー
- テキストプレースホルダー
- 画像プレースホルダー
- チャートプレースホルダー
- コンテンツプレースホルダー
- プロンプトテキスト
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、テキスト、画像、チャート、コンテンツのプレースホルダーを検査・編集し、プレースホルダーの継承を理解する方法を学びます。"
---
## **概要**

プレースホルダーは、プレゼンテーションテンプレート内で特定の種類のコンテンツの位置を確保する形状です。一般的な例として、タイトル、本文、画像、チャート、汎用コンテンツのプレースホルダーがあります。通常の形状とは異なり、プレースホルダーはレイアウトスライドまたはマスタースライドから位置、サイズ、書式設定、その他の設定を継承できます。

Aspose.Slides は、[Shape.placeholder](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/placeholder/) プロパティを通じてプレースホルダー情報を公開します。このプロパティは通常の形状に対しては `None`、それ以外の場合は [Placeholder](https://reference.aspose.com/slides/ja/python-net/aspose.slides/placeholder/) オブジェクトを返します。プレースホルダーが何を保持することを意図しているかを判断するには、[Placeholder.type](https://reference.aspose.com/slides/ja/python-net/aspose.slides/placeholder/type/) を使用します。

プレースホルダーのタイプを把握した後でも形状クラスは重要です：

- 空のテキスト、画像、チャート、またはコンテンツのプレースホルダーは、一般的に [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) で表されます。
- 内容が入った画像プレースホルダーは、[PictureFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pictureframe/) で表すことができます。
- 内容が入ったチャートプレースホルダーは、[Chart](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chart/) で表すことができます。
- コンテンツプレースホルダーは複数の種類のコンテンツを含むことができます。すべてのプレースホルダーが [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) であると想定せず、[Placeholder.type](https://reference.aspose.com/slides/ja/python-net/aspose.slides/placeholder/type/) と実行時の形状クラスの両方を確認してください。

{{% alert color="warning" title="Warning" %}}
[Placeholder.type](https://reference.aspose.com/slides/ja/python-net/aspose.slides/placeholder/type/) はプレースホルダーの役割を説明しますが、形状の実行時クラスを保証するものではありません。テキスト、画像、チャート、テーブル、またはメディア固有のメンバーにアクセスする前に、必ず型チェックを行ってください。
{{% /alert %}}

## **プレースホルダー継承の理解**

プレースホルダーは階層構造を形成します：

1. マスタースライドは再利用可能なスタイルを定義し、場合によってはマスターレベルのプレースホルダーも定義します。
2. レイアウトスライドは、1 つまたは複数の通常スライドで使用される配置を定義し、マスターから継承できます。
3. 通常スライドはそのスライド用のプレースホルダーを保持し、レイアウトから継承することができます。

[Shape.get_base_placeholder](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/get_base_placeholder/) を呼び出すと、この階層で1レベル上のプレースホルダーに移動します。スライドプレースホルダーは通常、レイアウトプレースホルダーを返し、レイアウトプレースホルダーはマスタープレースホルダーを返すことができます。形状にベースプレースホルダーがない場合、メソッドは `None` を返します。

次の例は、最初のスライド上のプレースホルダーを列挙し、それらのベースプレースホルダーを報告します：

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        type_name = type(shape).__name__
        print(f"Slide placeholder: {placeholder_type}; shape class: {type_name}")

        layout_placeholder = shape.get_base_placeholder()
        if layout_placeholder is not None:
            layout_placeholder_type = layout_placeholder.placeholder.type if layout_placeholder.placeholder is not None else None
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.get_base_placeholder()
            if master_placeholder is not None:
                master_placeholder_type = master_placeholder.placeholder.type if master_placeholder.placeholder is not None else None
                print(f"  Master placeholder: {master_placeholder_type}")
```

通常スライド上のプレースホルダーを編集すると、そのスライド用のローカル上書きが作成または変更されます。関連するレイアウトやマスターを編集すると、その設定を継承しているすべてのスライドに影響を与える可能性があります。ローカルの通常形状はベースプレースホルダーを持たず、同じ座標に配置されているだけで継承を開始することはありません。

## **プレースホルダー内のテキストを変更する**

タイトル、センタリングタイトル、サブタイトル、本文、テキストのプレースホルダーは通常テキストをサポートしています。[text_frame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/text_frame/) プロパティを使用する前に、[AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) であることを確認してください。

この例は、最初のスライド上の最初のタイトルプレースホルダーを更新し、結果を保存します：

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    title_shape = None

    for shape in slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            title_shape = shape
            break

    if title_shape is None:
        raise RuntimeError("The first slide does not contain a title placeholder.")

    title_shape.text_frame.text = "Quarterly Business Review"
    presentation.save("title-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

このパターンは、画像、チャート、テーブル、またはメディアのプレースホルダーを [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) オブジェクトとして扱うことを回避します。また、脆弱な形状インデックスに依存するのではなく、目的でプレースホルダーを識別します。

## **レイアウト上でプロンプトテキストを設定する**

プロンプトテキストは、*タイトルを追加するにはクリック* のように空のプレースホルダーに表示されるデザイン時の指示です。通常スライドの形状コレクションから取得しようとするのではなく、レイアウトのプレースホルダーにカスタムプロンプトテキストを設定してください。レイアウトは [Slide.layout_slide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/layout_slide/) で取得し、[LayoutSlide.shapes](https://reference.aspose.com/slides/ja/python-net/aspose.slides/baseslide/shapes/) を反復処理します。

次の例は、最初のスライドで使用されているレイアウト上のタイトルとサブタイトルのプロンプトを変更します：

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    layout_slide = presentation.slides[0].layout_slide

    for shape in layout_slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            shape.text_frame.text = "Enter a concise slide title"
        elif placeholder_type == slides.PlaceholderType.SUBTITLE:
            shape.text_frame.text = "Enter a subtitle or reporting period"

    presentation.save("custom-placeholder-prompts.pptx", slides.export.SaveFormat.PPTX)
```

プロンプトテキストは通常のスライドコンテンツではありません。PowerPoint 等の編集アプリケーションの空のプレースホルダー向けに意図されています。ユーザーまたはプログラムが実際のコンテンツを提供すると、プロンプトは表示されなくなります。プロンプトを変更しても、レイアウトを使用しているスライド上の既存テキストは置き換えられません。

## **画像プレースホルダーを更新する**

処理すべきケースは2つあります：

- 画像プレースホルダーがすでに内容を持ち、[PictureFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pictureframe/) で表されている場合は、[PictureFillFormat.picture](https://reference.aspose.com/slides/ja/python-net/aspose.slides/picturefillformat/picture/) と [Picture.image](https://reference.aspose.com/slides/ja/python-net/aspose.slides/picture/image/) を使用して画像を置き換えます。
- まだ空のプレースホルダーである場合は、[ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapecollection/add_picture_frame/) でプレースホルダーの座標に画像フレームを追加し、空のプレースホルダーを削除します。

次の例は両方のケースに対応し、プレゼンテーションを保存します：

```python
import aspose.slides as slides

with slides.Presentation("picture-template.pptx") as presentation:
    slide = presentation.slides[0]
    picture_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        raise RuntimeError("The first slide does not contain a picture placeholder.")

    with open("replacement.png", "rb") as image_stream:
        image_bytes = image_stream.read()

    image = presentation.images.add_image(image_bytes)

    if isinstance(picture_placeholder, slides.PictureFrame):
        picture_placeholder.picture_format.picture.image = image
    else:
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, picture_placeholder.x, picture_placeholder.y, picture_placeholder.width, picture_placeholder.height, image)
        slide.shapes.remove(picture_placeholder)

    presentation.save("picture-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

空のプレースホルダー用に作成された置き換えは、新しいプレースホルダーではなくローカルの画像フレームです。これは [Shape.placeholder](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/placeholder/) が読み取り専用であるためです。予約された位置は保持されますが、プレースホルダー固有の動作は継承されなくなります。プレースホルダーとの関係を保持することが重要な場合は、まず PowerPoint でプレースホルダーを準備して内容を設定し、次に Aspose.Slides で生成された [PictureFrame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pictureframe/) を更新してください。

画像の透過、クロップ、その他の画像固有の効果については、[Manage Picture Frames](/slides/ja/python-net/picture-frame/) を参照してください。これらの操作はプレースホルダーのメタデータではなく、画像フレームまたは画像塗りに属します。

## **チャートおよびコンテンツプレースホルダーの操作**

内容が入ったチャートプレースホルダーは、[Chart](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chart/) で表すことができます。この例では、プレースホルダーのタイプと実行時クラスの両方でそのチャートを検索し、タイトルを変更してファイルを保存します：

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-template.pptx") as presentation:
    slide = presentation.slides[0]
    placeholder_chart = None

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.CHART:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        raise RuntimeError("The first slide does not contain a populated chart placeholder.")

    placeholder_chart.has_title = True
    placeholder_chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    presentation.save("chart-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

一般的なコンテンツプレースホルダーは通常、[PlaceholderType.OBJECT](https://reference.aspose.com/slides/ja/python-net/aspose.slides/placeholdertype/) を持ちます。PowerPoint では、チャート、テーブル、図、画像、メディアなど複数のコンテンツタイプの起動装置として機能します。コンテンツが設定された後は、実際の形状クラスを調べて何が含まれているかを確認してください。特化したレイアウトでは、[PlaceholderType.CHART](https://reference.aspose.com/slides/ja/python-net/aspose.slides/placeholdertype/)、[PlaceholderType.TABLE](https://reference.aspose.com/slides/ja/python-net/aspose.slides/placeholdertype/)、[PlaceholderType.PICTURE](https://reference.aspose.com/slides/ja/python-net/aspose.slides/placeholdertype/)、[PlaceholderType.MEDIA](https://reference.aspose.com/slides/ja/python-net/aspose.slides/placeholdertype/)、または [PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/ja/python-net/aspose.slides/placeholdertype/) を公開することもあります。

Aspose.Slides は、[Placeholder.type](https://reference.aspose.com/slides/ja/python-net/aspose.slides/placeholder/type/) を変更しただけで空の [AutoShape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/autoshape/) プレースホルダーを [Chart](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chart/) に変換しません。type は読み取り専用です。空のチャートやコンテンツ領域にプログラムで内容を設定するには、プレースホルダーの座標に必要なオブジェクトを追加し、空のプレースホルダーを削除します。次の例はチャートに対してそれを行います：

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("content-template.pptx") as presentation:
    slide = presentation.slides[0]
    target_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type in (slides.PlaceholderType.CHART, slides.PlaceholderType.OBJECT):
            target_placeholder = shape
            break

    if target_placeholder is None:
        raise RuntimeError("The first slide does not contain a chart or content placeholder.")

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, target_placeholder.x, target_placeholder.y, target_placeholder.width, target_placeholder.height)
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    slide.shapes.remove(target_placeholder)
    presentation.save("content-placeholder-replaced-with-chart.pptx", slides.export.SaveFormat.PPTX)
```

追加されたチャートは通常のローカルチャートです。プレースホルダーの領域を占有しますが、レイアウトプレースホルダーから継承はしません。カテゴリ、シリーズ、またはブックデータを置き換える必要がある場合は、専用の [chart management articles](/slides/ja/python-net/powerpoint-charts/) を使用してください。

## **完全な例: テキストまたは画像コンテンツの更新**

次のエンドツーエンドの例は、テンプレートを開き、最初のスライドでタイトルまたは画像プレースホルダーを検索し、プレースホルダーと形状のタイプを確認して、適切なコンテンツを更新し、出力を保存します。この例は、形状インデックスを想定したり、すべてのプレースホルダーを同じ形状クラスとして扱うことを意図的に回避しています。

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    updated = False

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE) and isinstance(shape, slides.AutoShape):
            shape.text_frame.text = "Quarterly Business Review"
            updated = True
            break

        if placeholder_type == slides.PlaceholderType.PICTURE:
            with open("replacement.png", "rb") as image_stream:
                image_bytes = image_stream.read()

            image = presentation.images.add_image(image_bytes)

            if isinstance(shape, slides.PictureFrame):
                shape.picture_format.picture.image = image
            else:
                slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, image)
                slide.shapes.remove(shape)

            updated = True
            break

    if not updated:
        raise RuntimeError("No supported title or picture placeholder was found on the first slide.")

    presentation.save("placeholder-content-updated.pptx", slides.export.SaveFormat.PPTX)
```

## **よくある質問**

**ベースプレースホルダーとは何ですか？**

ベースプレースホルダーは、別のプレースホルダーが継承するレイアウトまたはマスター上の対応する形状です。取得するには [Shape.get_base_placeholder](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/get_base_placeholder/) を使用します。ローカルの通常形状はプレースホルダー階層の一部ではないため、`None` を返します。

**レイアウトプレースホルダーを編集してすべてのスライドタイトルを変更できますか？**

レイアウトを介して継承された書式やプロンプトテキストは変更できますが、既存のタイトルコンテンツは通常のスライドに保存されています。プレゼンテーション全体の実際のタイトルテキストを置き換えるには、スライドを反復処理し、各タイトルプレースホルダーを更新してください。

**日付、スライド番号、ヘッダー、フッターのプレースホルダーはどのように管理しますか？**

適切なスライド、レイアウト、マスター、ノート、またはハンドアウトのスコープでヘッダーとフッターのマネージャーを使用します。完全な例については、[Manage Presentation Header and Footer](/slides/ja/python-net/presentation-header-and-footer/) を参照してください。