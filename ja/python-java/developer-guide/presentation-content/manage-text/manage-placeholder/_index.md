---
title: Pythonでプレゼンテーションのプレースホルダーを管理する
linktitle: プレースホルダーを管理する
type: docs
weight: 10
url: /ja/python-java/manage-placeholder/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、テキスト、画像、チャート、コンテンツのプレースホルダーを検査・編集し、プレースホルダーの継承を理解する方法を学びます。"
---
## **概要**

プレースホルダーは、プレゼンテーションテンプレート内で特定の種類のコンテンツの位置を確保するシェイプです。一般的な例として、タイトル、本文、画像、チャート、汎用コンテンツのプレースホルダーがあります。通常のシェイプとは異なり、プレースホルダーはレイアウトスライドまたはマスタースライドから位置、サイズ、書式設定、その他の設定を継承できます。

Aspose.Slides は、[Shape.getPlaceholder](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getPlaceholder) メソッドを通じてプレースホルダー情報を提供します。このメソッドは通常のシェイプの場合は `None`、それ以外の場合は [Placeholder](https://reference.aspose.com/slides/ja/python-java/aspose.slides/placeholder/) オブジェクトを返します。[Placeholder.getType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/placeholder/#getType) を使用して、プレースホルダーが何を保持することを意図しているかを判断してください。

プレースホルダータイプを把握した後でも、シェイプタイプは重要です：

- 空のテキスト、画像、チャート、またはコンテンツのプレースホルダーは通常、[AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) で表されます。
- 画像が設定されたプレースホルダーは [PictureFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pictureframe/) で表されます。
- チャートが設定されたプレースホルダーは [Chart](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/) で表されます。
- コンテンツプレースホルダーは複数の種類のコンテンツを含むことができます。すべてのプレースホルダーが [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) であると想定せず、[Placeholder.getType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/placeholder/#getType) と実行時のシェイプタイプの両方を確認してください。

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/placeholder/#getType) はプレースホルダーの役割を示しますが、シェイプの実行時タイプを保証するものではありません。テキスト、画像、チャート、テーブル、またはメディア固有のメンバーにアクセスする前に、必ずタイプチェックを行ってください。
{{% /alert %}}

## **プレースホルダーの継承を理解する**

プレースホルダーは階層を形成します：

1. マスタースライドは再利用可能なスタイルを定義し、場合によってはマスターレベルのプレースホルダーも定義します。
2. レイアウトスライドは1枚以上の通常スライドで使用される配置を定義し、マスターから継承することができます。
3. 通常スライドはそのスライド用のプレースホルダーを保持し、レイアウトから継承することができます。

[Shape.getBasePlaceholder](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getBasePlaceholder) を呼び出すと、この階層で1レベル上のプレースホルダーに移動できます。スライドのプレースホルダーは通常、レイアウトのプレースホルダーを返し、レイアウトのプレースホルダーはマスターのプレースホルダーを返すことがあります。シェイプにベースプレースホルダーがない場合、このメソッドは `None` を返します。

以下の例は最初のスライド上のプレースホルダーを列挙し、そのベースプレースホルダーを報告します：

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

通常スライド上でプレースホルダーを編集すると、そのスライド用のローカルオーバーライドが作成または変更されます。関連するレイアウトやマスターを編集すると、その設定を継承しているすべてのスライドに影響を与える可能性があります。ローカルの通常シェイプはベースプレースホルダーを持たず、同じ座標にあるだけで継承が開始されるわけではありません。

## **プレースホルダー内のテキストを変更する**

タイトル、センタリングされたタイトル、サブタイトル、本文、およびテキストプレースホルダーは通常テキストをサポートします。これらのシェイプが [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) であるかを確認し、[getTextFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/#getTextFrame) メソッドを使用してください。

この例は最初のスライド上の最初のタイトルプレースホルダーを更新し、結果を保存します：

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

このパターンは、画像、チャート、テーブル、またはメディアのプレースホルダーを [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) として扱うことを防ぎます。また、壊れやすいシェイプインデックスに依存するのではなく、目的に応じてプレースホルダーを識別します。

## **レイアウト上でプロンプトテキストを設定する**

プロンプトテキストは、空のプレースホルダーに表示されるデザイン時の指示で、例えば *Click to add title* のようなものです。通常スライドのシェイプコレクションから取得しようとせず、レイアウトプレースホルダーにカスタムプロンプトテキストを設定してください。[Slide.getLayoutSlide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#getLayoutSlide) でレイアウトにアクセスし、[BaseSlide.getShapes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslide/#getShapes) が返すコレクションをイテレートします。

以下の例は最初のスライドで使用されているレイアウトのタイトルとサブタイトルのプロンプトを変更します：

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

プロンプトテキストは通常のスライドコンテンツではありません。PowerPoint などの編集アプリケーションで空のプレースホルダーに表示されることを意図しています。ユーザーやプログラムが実際のコンテンツを提供すると、プロンプトは表示されなくなります。また、プロンプトを変更しても、レイアウトを使用しているスライド上の既存テキストは置き換わりません。

## **画像プレースホルダーを更新する**

扱うケースは2つあります：

- 画像プレースホルダーが既に設定されており、[PictureFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pictureframe/) で表されている場合は、[PictureFillFormat.getPicture](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picturefillformat/#getPicture) と [Picture.setImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picture/#setImage) を使用して画像を置き換えます。
- まだ空のプレースホルダーである場合は、[ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addPictureFrame) を使用してプレースホルダーの座標に画像フレームを追加し、空のプレースホルダーを削除します。

次の例は両方のケースをサポートし、プレゼンテーションを保存します：

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

空のプレースホルダーに対して作成された置換は新しいプレースホルダーではなくローカルの画像フレームです。これは [Shape.getPlaceholder](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getPlaceholder) にセッターがないためです。予約された位置は保持されますが、プレースホルダー固有の動作は継承されなくなります。プレースホルダーの関係を保持することが重要な場合は、まず PowerPoint でプレースホルダーを用意して設定し、その後 Aspose.Slides で生成された [PictureFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pictureframe/) を更新してください。

画像の透過、クロッピング、その他画像固有の効果については、[Manage Picture Frames](/slides/ja/python-java/picture-frame/) を参照してください。これらの操作はプレースホルダーのメタデータではなく、画像フレームまたは画像塗りつぶしに関するものです。

## **チャートおよびコンテンツプレースホルダーの操作**

設定されたチャートプレースホルダーは [Chart](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/) で表されます。この例はプレースホルダータイプと実行時タイプの両方で該当チャートを見つけ、タイトルを変更し、ファイルを保存します：

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

汎用コンテンツプレースホルダーは通常、[PlaceholderType.Object](https://reference.aspose.com/slides/ja/python-java/aspose.slides/placeholdertype/#Object) を持ちます。PowerPoint では、チャート、テーブル、ダイアグラム、画像、メディアなど、複数のコンテンツタイプの起動点として機能します。プレースホルダーが設定された後は、実際のシェイプタイプを調べて何が含まれているかを確認してください。特化したレイアウトでは、[PlaceholderType.Chart](https://reference.aspose.com/slides/ja/python-java/aspose.slides/placeholdertype/#Chart)、[PlaceholderType.Table](https://reference.aspose.com/slides/ja/python-java/aspose.slides/placeholdertype/#Table)、[PlaceholderType.Picture](https://reference.aspose.com/slides/ja/python-java/aspose.slides/placeholdertype/#Picture)、[PlaceholderType.Media](https://reference.aspose.com/slides/ja/python-java/aspose.slides/placeholdertype/#Media)、[PlaceholderType.Diagram](https://reference.aspose.com/slides/ja/python-java/aspose.slides/placeholdertype/#Diagram) を公開することもあります。

Aspose.Slides は、[Placeholder.getType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/placeholder/#getType) を変更しただけで空の [AutoShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/autoshape/) プレースホルダーを [Chart](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/) に変換することはできません。タイプは API では変更できません。空のチャートやコンテンツ領域にプログラムでデータを入れるには、プレースホルダーの座標に必要なオブジェクトを追加し、空のプレースホルダーを削除します。次の例はチャートに対してそれを行います。

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

追加されたチャートは普通のローカルチャートです。プレースホルダーの領域を占有しますが、レイアウトプレースホルダーから継承はしません。カテゴリ、系列、またはブックデータを置き換える必要がある場合は、専用の [chart management articles](/slides/ja/python-java/powerpoint-charts/) を使用してください。

## **完全な例: テキストまたは画像コンテンツの更新**

以下のエンドツーエンドの例では、テンプレートを開き、最初のスライドでタイトルまたは画像プレースホルダーを検索し、プレースホルダーとシェイプのタイプを確認して、適切なコンテンツを更新し、出力を保存します。この例は、シェイプインデックスを想定したり、すべてのプレースホルダーを同じタイプとして扱うことを避けるよう意図的に設計されています。

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

## **よくある質問**

**ベースプレースホルダーとは何ですか？**

ベースプレースホルダーは、別のプレースホルダーが継承するレイアウトまたはマスター上の対応するシェイプです。[Shape.getBasePlaceholder](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getBasePlaceholder) を使用して取得できます。通常のローカルシェイプはプレースホルダー階層の一部ではないため、`None` を返します。

**レイアウトプレースホルダーを編集してすべてのスライドタイトルを変更できますか？**

レイアウトを通じて継承された書式設定やプロンプトテキストは変更できますが、既存のタイトルコンテンツは通常のスライドに保存されています。プレゼンテーション全体のタイトルテキストを置き換えるには、スライドを繰り返し処理し、各タイトルプレースホルダーを更新してください。

**日付、スライド番号、ヘッダー、フッターペースホルダーはどのように管理しますか？**

対象となるスライド、レイアウト、マスター、ノート、ハンドアウトのスコープでヘッダーおよびフッターマネージャーを使用してください。完全な例については、[Manage Presentation Header and Footer](/slides/ja/python-java/presentation-header-and-footer/) を参照してください。