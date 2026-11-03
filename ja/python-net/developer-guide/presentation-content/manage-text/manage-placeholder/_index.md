---
title: Pythonでプレゼンテーションのプレースホルダーを管理する
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
description: "Aspose.Slides for Python via .NET を使用して、テキスト、画像、チャート、コンテンツのプレースホルダーを検査および編集し、プレースホルダーの継承を理解する方法を学びます。"
---
## **概要**

プレースホルダーは、プレゼンテーションテンプレート内で特定の種類のコンテンツの位置を確保するシェイプです。一般的な例として、タイトル、本文、画像、チャート、汎用コンテンツプレースホルダーがあります。通常のシェイプとは異なり、プレースホルダーはレイアウトスライドまたはマスタースライドから位置、サイズ、書式設定、その他の設定を継承できます。

Aspose.Slides はプレースホルダー情報を [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) プロパティで公開します。このプロパティは通常のシェイプの場合は `None` を返し、[Placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/) オブジェクトを返します。[Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) を使用して、プレースホルダーが保持することを意図したコンテンツの種類を判断します。

プレースホルダーのタイプが分かった後もシェイプクラスは重要です。

- 空のテキスト、画像、チャート、またはコンテンツプレースホルダーは一般的に [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) で表されます。
- 内容が入った画像プレースホルダーは [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) で表されます。
- 内容が入ったチャートプレースホルダーは [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) で表されます。
- コンテンツプレースホルダーは複数の種類のコンテンツを保持できます。[Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) と実行時のシェイプクラスの両方を確認し、すべてのプレースホルダーが [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) であると仮定しないでください。

{{% alert color="warning" title="Warning" %}}
[Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) はプレースホルダーの役割を示しますが、シェイプの実行時クラスを保証するものではありません。テキスト、画像、チャート、テーブル、メディア固有のメンバーにアクセスする前に必ず型チェックを行ってください。
{{% /alert %}}

## **プレースホルダー継承を理解する**

プレースホルダーは階層を形成します。

1. マスタースライドは再利用可能なスタイルを定義し、場合によってはマスターレベルのプレースホルダーも定義します。
2. レイアウトスライドは 1 つ以上の通常スライドで使用される配置を定義し、マスターから継承できます。
3. 通常スライドはそのスライド用のプレースホルダーを保持し、レイアウトから継承できます。

[Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/) を呼び出すと、この階層で 1 レベル上に移動します。スライドプレースホルダーは通常、レイアウトプレースホルダーを返し、レイアウトプレースホルダーはマスタープレースホルダーを返すことがあります。シェイプにベースプレースホルダーがない場合、メソッドは `None` を返します。

以下の例は最初のスライド上のプレースホルダーを列挙し、ベースプレースホルダーを報告します：

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

通常スライド上でプレースホルダーを編集すると、そのスライド用のローカルオーバーライドが作成または変更されます。関連するレイアウトやマスターを編集すると、その設定を継承しているすべてのスライドに影響を与える可能性があります。ローカルの通常シェイプはベースプレースホルダーを持たず、同じ座標にあるだけで継承が開始されることはありません。

## **プレースホルダーのステータスを削除する**

テンプレートを調整する際は、[Shape.remove_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/remove_placeholder/) を使用して既存のオブジェクトを通常のシェイプとして保持できます。その [placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) プロパティは `None` になりますが、シェイプはスライドのコレクションに残ります。対照的に、[ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) はそのコレクションからシェイプを削除します。

次の例は、少なくとも 1 枚のスライドと最初のスライドに非空のテキストプレースホルダーがある `template.pptx` を前提としています。レイアウトまたはマスターから継承された書式設定を持つプレースホルダーを使用して、関係を削除したときの効果を確認してください。例は同じシェイプが残っていることをチェックし、今や通常シェイプになったものに対してメソッドを再度呼び出し、結果を保存します。

{{% alert color="warning" title="Warning" %}}
プレースホルダーのステータスを削除しても、継承された外観設定が自動的に保持されるわけではありません。以下の例は意図的にそれらの設定を変更せずに残しています。そのため出力が異なる場合があります。位置とサイズが完全に継承されているシェイプは、呼び出し後に座標と寸法が 0 になることがあり、コレクションに残っていても見えなくなることがあります。
{{% /alert %}}

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    found = False

    for index in range(len(slide.shapes)):
        shape = slide.shapes[index]
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue
        if shape.text_frame is None or not shape.text_frame.text:
            continue

        shape_count = len(slide.shapes)
        shape.remove_placeholder()

        print(f"Placeholder removed: {shape.placeholder is None}")
        print(f"Same shape retained: {slide.shapes[index] == shape}")
        print(f"Shape count unchanged: {len(slide.shapes) == shape_count}")

        # 通常のシェイプに対してメソッドを呼び出しても効果はありません。
        shape.remove_placeholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("No nonempty text placeholder was found on the first slide.")
```

一致するプレースホルダーに対しては、3 つのチェックすべてが `True` を出力します。テキストは残りますが、プレースホルダーの関係が削除されると、継承された位置、サイズ、回転、フォント、段落配置、テキストフレームの余白、垂直アンカリング、塗り、線の設定が変わる可能性があります。たとえば、継承されたタイトル書式設定が通常のテキスト書式設定にフォールバックすることがあります。レイアウトの詳細については [Slide Layout](/slides/ja/python-net/slide-layout/) を参照してください。

意図した外観を保持するには、呼び出し前に解決された位置、サイズ、回転を取得し、必要な有効書式値を別々の変数にコピーします。これらの値は [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/)、[ParagraphFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/get_effective/)、[TextFrameFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/get_effective/)、[FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/)、[LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/) を通じて取得します。関係が削除された後にテキスト書式値が変わる可能性があるため、有効書式オブジェクトだけに依存しないでください。取得した値を通常シェイプに明示的に適用し、フォントファミリ、サイズ、スタイル、色、段落設定、テキストフレーム設定、塗り、ラインなどテンプレートで使用している書式をすべて復元します。

継承されたシェイプジオメトリも [GeometryShape.shape_type](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/shape_type/) で明示的に割り当てる必要があります。矩形テキストプレースホルダーの場合は [ShapeType.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/) を割り当てることを意味します。塗りと線だけを復元しても、見える矩形が復元されないことがあります。追加エフェクトやより複雑な書式設定を持つテンプレートでは、これらの設定も同様に処理する必要があります。

## **プレースホルダー内のテキストを変更する**

タイトル、センタリングタイトル、サブタイトル、本文、テキストプレースホルダーは通常テキストをサポートします。[AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) であるかを確認してから、その [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) プロパティを使用してください。

この例は最初のスライドの最初のタイトルプレースホルダーを更新し、結果を保存します：

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

このパターンは画像、チャート、テーブル、メディアプレースホルダーを [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) オブジェクトとして扱うことを防ぎます。また、脆弱なシェイプインデックスに依存せず、目的別にプレースホルダーを識別します。

## **レイアウトにプロンプトテキストを設定する**

プロンプトテキストは、*Click to add title* のように空のプレースホルダーに表示されるデザイン時の指示です。通常スライドのシェイプコレクションを介して取得しようとせず、レイアウトプレースホルダーにカスタムプロンプトテキストを設定してください。[Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) でレイアウトにアクセスし、[LayoutSlide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) を反復処理します。

以下の例は、最初のスライドで使用されているレイアウトのタイトルとサブタイトルのプロンプトを変更します：

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

プロンプトテキストは通常のスライドコンテンツではありません。PowerPoint などの編集アプリケーションで空のプレースホルダーに対して表示される指示です。ユーザーまたはプログラムが実際のコンテンツを入力すると、プロンプトは表示されなくなります。プロンプトを変更しても、そのレイアウトを使用しているスライド上の既存テキストは置き換えられません。

## **画像プレースホルダーを更新する**

処理すべきケースは 2 つあります。

- 画像プレースホルダーがすでに内容を持ち、[PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) で表されている場合は、[PictureFillFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture/) と [Picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/) を使用して画像を置き換えます。
- まだ空のプレースホルダーである場合は、[ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) でプレースホルダーの座標に画像フレームを追加し、空のプレースホルダーを削除します。

次の例は両方のケースをサポートし、プレゼンテーションを保存します：

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

空のプレースホルダー用に作成された置換は新しいプレースホルダーではなくローカルの画像フレームです。これは [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) が読み取り専用であるためです。予約位置は保持されますが、プレースホルダー固有の動作は継承されなくなります。プレースホルダーとの関係を保持することが重要な場合は、まず PowerPoint でプレースホルダーを用意してから、Aspose.Slides で生成された [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) を更新してください。

画像の透明度、クロッピング、その他画像固有のエフェクトについては [Manage Picture Frames](/slides/ja/python-net/picture-frame/) を参照してください。これらの操作はプレースホルダーのメタデータではなく、画像フレームまたは画像塗りに属します。

## **チャートおよびコンテンツプレースホルダーの操作**

内容が入ったチャートプレースホルダーは [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) で表されます。この例はプレースホルダータイプと実行時クラスの両方でチャートを検索し、タイトルを変更してファイルを保存します：

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

汎用コンテンツプレースホルダーは通常 [PlaceholderType.OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/) を持ちます。PowerPoint では、チャート、テーブル、図、画像、メディアなど複数のコンテンツタイプの起動点として機能します。内容が入力された後は、実際のシェイプクラスを調べて何が含まれているかを判別してください。特化したレイアウトは [PlaceholderType.CHART](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/)、[PlaceholderType.TABLE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/)、[PlaceholderType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/)、[PlaceholderType.MEDIA](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/)、[PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/) を公開することもあります。

Aspose.Slides は、[Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) を変更するだけで空の [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) プレースホルダーを [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) に変換しません。タイプは読み取り専用です。空のチャートやコンテンツ領域をプログラムで埋めるには、プレースホルダーの座標に必要なオブジェクトを追加し、空のプレースホルダーを削除します。以下の例はチャートでこれを実行します：

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

追加されたチャートは通常のローカルチャートです。プレースホルダー領域を占有しますが、レイアウトプレースホルダーから継承はしません。カテゴリやシリーズ、ブックデータを置き換える必要がある場合は、専用の [chart management articles](/slides/ja/python-net/powerpoint-charts/) を利用してください。

## **完全な例: テキストまたは画像コンテンツを更新する**

以下のエンドツーエンド例はテンプレートを開き、最初のスライドでタイトルまたは画像プレースホルダーを検索し、プレースホルダーとシェイプのタイプを確認し、適切なコンテンツを更新して出力を保存します。例はシェイプインデックスを仮定したり、すべてのプレースホルダーを同じシェイプクラスとして扱うことを意図的に回避しています：

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

ベースプレースホルダーは、レイアウトまたはマスター上にある対応するシェイプで、別のプレースホルダーがそこから継承します。[Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/) を使用して取得できます。通常のローカルシェイプはプレースホルダー階層の一部でないため `None` を返します。

**レイアウトプレースホルダーを編集してすべてのスライドタイトルを変更できますか？**

レイアウトを通じて継承された書式設定やプロンプトテキストは変更できますが、実際のタイトルコンテンツは通常のスライドに保存されています。プレゼンテーション全体のタイトルテキストを置き換えるには、各スライドを反復し、タイトルプレースホルダーを更新する必要があります。

**日付、スライド番号、ヘッダー、フッタープレースホルダーはどう管理しますか？**

対象となるスライド、レイアウト、マスター、ノート、ハンドアウトのスコープでヘッダーおよびフッターマネージャーを使用します。完全な例については [Manage Presentation Header and Footer](/slides/ja/python-net/presentation-header-and-footer/) を参照してください。