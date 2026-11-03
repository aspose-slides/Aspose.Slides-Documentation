---
title: "Python でプレゼンテーション プレースホルダーを管理する"
linktitle: "プレースホルダーを管理"
type: docs
weight: 10
url: /ja/python-java/manage-placeholder/
keywords:
- "プレースホルダー"
- "テキスト プレースホルダー"
- "画像 プレースホルダー"
- "チャート プレースホルダー"
- "コンテンツ プレースホルダー"
- "プロンプト テキスト"
- "PowerPoint"
- "プレゼンテーション"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Python via Java を使用して、テキスト、画像、チャート、コンテンツ プレースホルダーを検査・編集し、プレースホルダー継承を理解する方法を学びます。"
---
## **概要**

プレースホルダーは、プレゼンテーションテンプレート内で特定の種類のコンテンツの位置を確保する形状です。一般的な例として、タイトル、本文、画像、チャート、汎用コンテンツのプレースホルダーがあります。通常の形状とは異なり、プレースホルダーはレイアウト スライドまたはマスタースライドから位置、サイズ、書式設定、その他の設定を継承できます。

Aspose.Slides は、[Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) メソッドを通じてプレースホルダー情報を提供します。このメソッドは、通常の形状の場合は `None` を返し、[Placeholder](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/) オブジェクトを返します。[Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) を使用して、プレースホルダーが何を保持することを意図しているかを判断します。

形状のタイプは、プレースホルダーのタイプを把握した後も重要です:

- 空のテキスト、画像、チャート、またはコンテンツ プレースホルダーは、一般に [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) で表されます。
- 内容が入った画像プレースホルダーは [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) で表されます。
- 内容が入ったチャートプレースホルダーは [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) で表されます。
- コンテンツ プレースホルダーはさまざまな種類のコンテンツを含めることができます。すべてのプレースホルダーが [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) であると仮定せず、[Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) と実行時の形状タイプの両方を確認してください。

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) はプレースホルダーの役割を示しますが、形状の実行時タイプを保証するものではありません。テキスト、画像、チャート、テーブル、またはメディア固有のメンバーにアクセスする前に、必ずタイプチェックを行ってください。
{{% /alert %}}

## **プレースホルダー継承の理解**

プレースホルダーは階層を形成します:

1. マスタースライドは再利用可能なスタイルを定義し、場合によってはマスター レベルのプレースホルダーも定義します。
2. レイアウトスライドは、1 つ以上の通常スライドで使用される配置を定義し、マスターから継承することができます。
3. 通常スライドはそのスライドのプレースホルダーを保持し、レイアウトから継承することができます。

[Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) を呼び出すと、この階層で 1 レベル上のプレースホルダーに移動します。スライドのプレースホルダーは通常レイアウトのプレースホルダーを返し、レイアウトのプレースホルダーはマスターのプレースホルダーを返すことができます。形状にベースプレースホルダーが存在しない場合、メソッドは `None` を返します。

以下の例は、最初のスライド上のプレースホルダーを列挙し、それらのベースプレースホルダーを報告します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        type_name = shape.getClass().getSimpleName()
        print(f"Slide placeholder: {placeholder_type}; shape type: {type_name}")

        layout_placeholder = shape.getBasePlaceholder()
        if layout_placeholder is not None:
            layout_placeholder_info = layout_placeholder.getPlaceholder()
            layout_placeholder_type = None if layout_placeholder_info is None else layout_placeholder_info.getType()
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.getBasePlaceholder()
            if master_placeholder is not None:
                master_placeholder_info = master_placeholder.getPlaceholder()
                master_placeholder_type = None if master_placeholder_info is None else master_placeholder_info.getType()
                print(f"  Master placeholder: {master_placeholder_type}")
finally:
    presentation.dispose()
```

通常スライド上のプレースホルダーを編集すると、そのスライド用のローカル上書きが作成または変更されます。関連するレイアウトやマスターを編集すると、その設定を継承しているすべてのスライドに影響を与える可能性があります。ローカルの普通の形状はベースプレースホルダーを持たず、同じ座標を占めているだけで継承が開始されるわけではありません。

## **プレースホルダーのステータスを削除**

テンプレートを調整する際は、[Shape.removePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#removePlaceholder) を使用して、既存のオブジェクトを普通の形状として保持します。その [getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) メソッドは `None` を返しますが、形状はスライドのコレクションに残ります。対照的に、[ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) はそのコレクションから形状を削除します。

以下の例は、少なくとも 1 枚のスライドと最初のスライドに空でないテキスト プレースホルダーがある `template.pptx` が必要です。レイアウトまたはマスターから継承された書式設定を持つプレースホルダーを使用して、関係を削除したときの効果を確認してください。この例は同じ形状が残っていることをチェックし、普通の形状になった後にメソッドを再度呼び出し、結果を保存します。

{{% alert color="warning" title="Warning" %}}
プレースホルダーのステータスを削除しても、継承された外観設定が自動的に保持されるわけではありません。以下の例では意図的にそれらの設定を変更せずに残しています。そのため、出力が異なる見た目になる可能性があります。位置とサイズが完全に継承されている形状は、呼び出し後に座標と寸法がゼロになり、コレクションに残っていても見えなくなることがあります。
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpave.startJVM()

from asposeslides.api import Presentation, AutoShape, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    found = False

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if not isinstance(shape, AutoShape):
            continue

        text_frame = shape.getTextFrame()
        if shape.getPlaceholder() is None or text_frame is None:
            continue
        text = text_frame.getText()
        if text is None or len(text) == 0:
            continue

        shape_count = slide.getShapes().size()
        shape.removePlaceholder()

        print(f"Placeholder removed: {shape.getPlaceholder() is None}")
        print(f"Same shape retained: {slide.getShapes().get_Item(index) == shape}")
        print(f"Shape count unchanged: {slide.getShapes().size() == shape_count}")

        # 通常の形状に対してこのメソッドを呼び出しても効果はありません。
        shape.removePlaceholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx)
    else:
        print("No nonempty text placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

対応するプレースホルダーが 3 つのチェックすべてで `True` を出力します。テキストは残りますが、位置、サイズ、回転、フォント、段落配置、テキストフレームの余白、垂直位置揃え、塗りつぶし、線の設定など、継承された設定はプレースホルダー関係を削除すると変更される可能性があります。例えば、継承されたタイトル書式は通常のテキスト書式にフォールバックします。レイアウトの詳細については、[Slide Layout](/slides/ja/python-java/slide-layout/) を参照してください。

意図した外観を保持するには、呼び出し前に解決された位置、サイズ、回転を取得し、必要な有効書式の値を別々の変数にコピーします。これらの値は、[PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective)、[ParagraphFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getEffective)、[TextFrameFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getEffective)、[FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective)、および [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective) を介して取得してください。効果的な書式オブジェクトだけを保持することに頼ってはいけません。なぜなら、プレースホルダー関係が削除された後にそれらのテキスト書式値が変わる可能性があるからです。取得した値を普通の形状に明示的に適用し、フォント ファミリ、サイズ、スタイル、色、段落設定、テキストフレーム設定、塗りつぶし、線など、テンプレートで使用されている書式をすべて反映させます。

継承された形状のジオメトリも、[GeometryShape.setShapeType](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setShapeType) を使用して明示的に割り当てる必要がある場合があります。矩形テキスト プレースホルダーの場合、[ShapeType.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/#Rectangle) を割り当てることを意味します。塗りつぶしと線だけを復元しても、見える矩形が復元されないことがあります。追加効果やより複雑な書式設定を持つテンプレートでは、これらの設定も処理する必要があります。

## **プレースホルダー内のテキストを変更**

タイトル、センタリングタイトル、サブタイトル、本文、テキスト プレースホルダーは通常テキストをサポートします。[AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) かどうかを確認し、[getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getTextFrame) メソッドを使用してください。

この例は、最初のスライドの最初のタイトル プレースホルダーを更新し、結果を保存します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    title_shape = None

    for shape in slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            title_shape = shape
            break

    if title_shape is None:
        print("The first slide does not contain a title placeholder.")
    else:
        title_shape.getTextFrame().setText("Quarterly Business Review")
        presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

このパターンは、画像、チャート、テーブル、またはメディア プレースホルダーを [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) として扱うことを防ぎます。また、形状インデックスに依存せず、目的でプレースホルダーを識別します。

## **レイアウト上でプロンプト テキストを設定**

プロンプト テキストは、空のプレースホルダーに表示されるデザイン時の指示で、例: *Click to add title* のようなものです。レイアウト プレースホルダーにカスタム プロンプト テキストを設定し、通常スライドの形状コレクションを経由して取得しようとしないでください。[Slide.getLayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getLayoutSlide) を使用してレイアウトにアクセスし、[BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes) が返すコレクションを反復処理します。

以下の例は、最初のスライドで使用されているレイアウトのタイトルとサブタイトルのプロンプトを変更します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    layout_slide = presentation.getSlides().get_Item(0).getLayoutSlide()

    for shape in layout_slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            shape.getTextFrame().setText("Enter a concise slide title")
        elif placeholder_type == PlaceholderType.Subtitle:
            shape.getTextFrame().setText("Enter a subtitle or reporting period")

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

プロンプト テキストは通常のスライド コンテンツではありません。PowerPoint などの編集アプリケーションで空のプレースホルダーに対して表示されることを意図しています。ユーザーまたはプログラムが実際のコンテンツを提供すると、プロンプトは表示されなくなります。プロンプトを変更しても、レイアウトを使用しているスライド上の既存テキストは置き換えられません。

## **画像プレースホルダーを更新**

以下の 2 ケースを処理します:

- 画像プレースホルダーがすでに埋められており、[PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) で表されている場合は、[PictureFillFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#getPicture) と [Picture.setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage) を使用して画像を置き換えます。
- まだ空のプレースホルダーの場合は、[ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame) を使用してプレースホルダーの座標に画像フレームを追加し、空のプレースホルダーを削除します。

次の例は両方のケースに対応し、プレゼンテーションを保存します:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("picture-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Picture:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        print("The first slide does not contain a picture placeholder.")
    else:
        image_bytes = Path("replacement.png").read_bytes()
        java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
        image = presentation.getImages().addImage(java_image_bytes)

        if isinstance(picture_placeholder, PictureFrame):
            picture_placeholder.getPictureFormat().getPicture().setImage(image)
        else:
            slide.getShapes().addPictureFrame(ShapeType.Rectangle, picture_placeholder.getX(), picture_placeholder.getY(), picture_placeholder.getWidth(), picture_placeholder.getHeight(), image)
            slide.getShapes().remove(picture_placeholder)

        presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

空のプレースホルダー用に作成された置換はローカルの画像フレームであり、新しいプレースホルダーではありません。なぜなら、[Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) はセッターを提供しないからです。予約された位置は保持されますが、プレースホルダー固有の動作は継承されなくなります。プレースホルダー関係を保持することが重要な場合は、まず PowerPoint でプレースホルダーを準備して埋め込み、次に Aspose.Slides で結果の [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) を更新してください。

画像の透明度、クロッピング、その他の画像固有効果については、[Manage Picture Frames](/slides/ja/python-java/picture-frame/) を参照してください。これらの操作は画像フレームまたは画像塗りつぶしに属し、プレースホルダー メタデータには属しません。

## **チャートおよびコンテンツ プレースホルダーの操作**

内容が入ったチャート プレースホルダーは [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) で表されます。この例は、プレースホルダータイプと実行時タイプの両方でそのチャートを見つけ、タイトルを変更し、ファイルを保存します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, PlaceholderType, SaveFormat

presentation = Presentation("chart-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    placeholder_chart = None

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Chart:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        print("The first slide does not contain a populated chart placeholder.")
    else:
        placeholder_chart.setTitle(True)
        placeholder_chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

一般的なコンテンツ プレースホルダーは通常 [PlaceholderType.Object](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Object) を持ちます。PowerPoint では、チャート、テーブル、ダイアグラム、画像、メディアなど、複数のコンテンツ タイプの起動装置として機能します。内容が入った後は、実際の形状タイプを調べて何が含まれているかを判断してください。特化されたレイアウトは、[PlaceholderType.Chart](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Chart)、[PlaceholderType.Table](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Table)、[PlaceholderType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Picture)、[PlaceholderType.Media](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Media)、または [PlaceholderType.Diagram](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Diagram) を公開することがあります。

Aspose.Slides は、[Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) を変更するだけで、空の [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) プレースホルダーを [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) に変換しません。API ではタイプを変更できません。空のチャートまたはコンテンツ領域をプログラムで埋めるには、プレースホルダーの座標に必要なオブジェクトを追加し、空のプレースホルダーを削除します。以下の例はチャートに対してそれを行います:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PlaceholderType, ChartType, SaveFormat

presentation = Presentation("content-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    target_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Chart, PlaceholderType.Object):
            target_placeholder = shape
            break

    if target_placeholder is None:
        print("The first slide does not contain a chart or content placeholder.")
    else:
        chart = slide.getShapes().addChart(ChartType.ClusteredColumn, target_placeholder.getX(), target_placeholder.getY(), target_placeholder.getWidth(), target_placeholder.getHeight())
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        slide.getShapes().remove(target_placeholder)
        presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

追加されたチャートは普通のローカルチャートです。プレースホルダー領域を占有しますが、レイアウト プレースホルダーから継承しません。カテゴリ、系列、またはブックデータを置き換える必要がある場合は、専用の [chart management articles](/slides/ja/python-java/powerpoint-charts/) を使用してください。

## **完全な例：テキストまたは画像コンテンツの更新**

以下のエンドツーエンド例はテンプレートを開き、最初のスライドでタイトルまたは画像プレースホルダーを検索し、プレースホルダーと形状のタイプを確認し、適切なコンテンツを更新して出力を保存します。この例は形状インデックスを仮定したり、すべてのプレースホルダーを同じタイプとみなしたりしないよう意図的に作られています。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    updated = False

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle) and isinstance(shape, AutoShape):
            shape.getTextFrame().setText("Quarterly Business Review")
            updated = True
            break

        if placeholder_type == PlaceholderType.Picture:
            image_bytes = Path("replacement.png").read_bytes()
            java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
            image = presentation.getImages().addImage(java_image_bytes)

            if isinstance(shape, PictureFrame):
                shape.getPictureFormat().getPicture().setImage(image)
            else:
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image)
                slide.getShapes().remove(shape)

            updated = True
            break

    if updated:
        presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx)
    else:
        print("No supported title or picture placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

## **FAQ**

**ベース プレースホルダーとは何ですか？**

ベース プレースホルダーは、レイアウトまたはマスター上の対応する形状で、別のプレースホルダーが継承する元になります。[Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) を使用して取得してください。普通のローカル形状はプレースホルダー階層の一部ではないため `None` を返します。

**レイアウト プレースホルダーを編集してすべてのスライドタイトルを変更できますか？**

レイアウトを介して継承された書式設定やプロンプト テキストは変更できますが、既存のタイトル コンテンツは通常スライドに保存されています。プレゼンテーション全体の実際のタイトル テキストを置き換えるには、スライドを反復処理して各タイトル プレースホルダーを更新してください。

**日付、スライド番号、ヘッダー、フッターのプレースホルダーはどのように管理しますか？**

適切なスライド、レイアウト、マスター、ノート、またはハンドアウトのスコープでヘッダーおよびフッター マネージャーを使用します。完全な例については、[Manage Presentation Header and Footer](/slides/ja/python-java/presentation-header-and-footer/) を参照してください。