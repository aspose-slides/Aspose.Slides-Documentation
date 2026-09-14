---
title: Python via Java でプレゼンテーションのスライドマスターを管理
linktitle: スライドマスター
type: docs
weight: 70
url: /ja/python-java/slide-master/
keywords:
- スライドマスター
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
- Java
- Aspose.Slides
description: "Python via Java 用 Aspose.Slides でスライドマスターを管理します：PowerPoint および OpenDocument のプレゼンテーションにおいて、マスタースライドの取得、編集、クローン、比較、削除を行うことができます。"
---
## **概要**

**スライドマスター**は、スライドのグループに対して共有デザイン設定を定義します。共通の図形、ロゴ、背景、テキストスタイル、テーマ設定、フッター設定などを含めることができます。PowerPoint では、スライドマスターを編集することで、各スライドに同じ書式設定を繰り返すことなくプレゼンテーションの一貫性を保つのが一般的な方法です。

Aspose.Slides for Python via Java でも同じモデルがサポートされています。プレゼンテーションは 1 つ以上のマスタースライドを含むことができ、各マスタースライドは複数のレイアウトスライドを持ちます。通常のスライドは直接マスタースライドを参照しません。代わりに、通常のスライドはレイアウトスライドを使用し、そのレイアウトスライドがマスタースライドに属しています。

階層は次のとおりです。

1. **スライドマスター** – 共有デザインとテーマを定義します。  
1. **レイアウトスライド** – プレースホルダーやレイアウトレベルの書式設定の具体的な配置を定義します。  
1. **通常スライド** – 実際のプレゼンテーションコンテンツを保持し、1 つのレイアウトスライドを使用します。

![マスタースライド、レイアウトスライド、通常スライドの階層構造](slide-master_2.jpg)

Aspose.Slides では、スライドマスターは [MasterSlide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslide/) クラスで表されます。プレゼンテーション内のすべてのマスタースライドは、[Presentation.getMasters](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getMasters) コレクションを介して取得でき、これは [MasterSlideCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslidecollection/) として表されます。

{{% alert color="info" title="Inheritance" %}}
同じプロパティが複数のレベルで定義されている場合、より具体的なレベルが優先されます。たとえば、マスタースライドとレイアウトスライドの両方で背景が定義されている場合、そのレイアウトに基づくスライドはレイアウトの背景を使用します。レイアウトスライドの詳細については、[Apply or Change Slide Layouts](/slides/ja/python-java/slide-layout/) を参照してください。
{{% /alert %}}

## **スライドマスターへのアクセス**

PowerPoint では、**表示** > **スライドマスター** からスライドマスタービューを開くことができます。

![PowerPoint の「表示」タブにあるスライドマスター コマンド](slide-master_3.jpg)

Aspose.Slides では、[Presentation.getMasters](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getMasters) コレクションを使用してマスタースライドにアクセスします:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    master_slide_count = presentation.getMasters().size()
    first_master_layout_slide_count = first_master_slide.getLayoutSlides().size()

    print(f"Master slides: {master_slide_count}")
    print(f"Layouts in the first master: {first_master_layout_slide_count}")
finally:
    presentation.dispose()
```

通常スライドからそのレイアウトを介して使用されているマスタースライドを取得することもできます:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    layout_slide = slide.getLayoutSlide()
    master_slide = layout_slide.getMasterSlide()
    master_slide_name = master_slide.getName()

    print(master_slide_name)
finally:
    presentation.dispose()
```

## **スライドマスターに含まれるもの**

マスタースライドはスライドに似たオブジェクトです。[BaseSlide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslide/) から継承しているため、通常スライドやレイアウトスライドで使用される多くの同じスライドプロパティが利用できます。マスタ固有のメンバーは [MasterSlide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslide/) API ページに一覧化されています。

主なマスタースライドメンバーは次のとおりです:

| メンバー | 用途 |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslide/#getBackground) | マスターレベルのスライド背景を設定します。 |
| [getShapes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslide/#getShapes) | ロゴ、画像フレーム、共有テキストなど、マスター上に配置された図形を格納します。 |
| [getLayoutSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslide/#getLayoutSlides) | マスターに属するレイアウトスライドを格納します。 |
| [getThemeManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslide/#getThemeManager) | マスターのテーマ API へのアクセスを提供します。 |
| [getHeaderFooterManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | マスターとその子レイアウトのヘッダー、フッター、日付、スライド番号を制御します。 |
| [getDependingSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslide/#getDependingSlides) | レイアウトを通じてマスターに依存している通常スライドを返します。 |

## **スライドマスターに画像を追加する**

マスタースライドに画像を追加すると、そのマスターのレイアウトを使用するスライドすべてに表示されます。ロゴ、透かし、装飾バンド、その他繰り返し使用するビジュアル要素に便利です。

次の例は、最初のマスタースライドにロゴを追加します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    logo = Images.fromFile("logo.png")
    try:
        logo_image = presentation.getImages().addImage(logo)
        master_slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 80, 80, logo_image)
    finally:
        logo.dispose()

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

画像フレームの詳細については、[Picture Frame](/slides/ja/python-java/picture-frame/) を参照してください。

## **プレースホルダーの操作**

プレースホルダーは通常レイアウトスライド上で定義されます。マスタースライドはそれらのレイアウトが継承する共有スタイルとテーマを提供し、各レイアウトは利用可能なプレースホルダーと配置位置を決定します。

PowerPoint では、プレースホルダーコマンドはスライドマスタービューで利用できます。

![PowerPoint スライドマスタービューの「プレースホルダーの挿入」コマンド](slide-master_5.png)

Aspose.Slides で新しいプレースホルダーを追加するには、マスターに属するレイアウトスライドを操作します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    blank_layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout_slide is None:
        blank_layout_slide = master_slide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank")

    blank_layout_slide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80)

    presentation.getSlides().addEmptySlide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

既存のプレースホルダー形状の書式設定も可能です。次の例はタイトルプレースホルダーを検索し、線形グラデーション塗りつぶしを適用します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, GradientShape, PlaceholderType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    title_placeholder = None

    for shape in master_slide.getShapes():
        if isinstance(shape, AutoShape):
            if shape.getPlaceholder() is not None and shape.getPlaceholder().getType() == PlaceholderType.Title:
                title_placeholder = shape
                break

    if title_placeholder is not None:
        red_gradient_color = Color(255, 0, 0)
        purple_gradient_color = Color(128, 0, 128)

        title_placeholder.getFillFormat().setFillType(FillType.Gradient)
        title_placeholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(0.0), red_gradient_color)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(1.0), purple_gradient_color)

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![通常スライドが継承した書式設定済みタイトルプレースホルダー](slide-master_8.png)

プレースホルダーとテキストの書式設定オプションの詳細は、[Set Prompt Text in Placeholder](/slides/ja/python-java/manage-placeholder/) と [Text Formatting](/slides/ja/python-java/text-formatting/) を参照してください。

## **スライドマスターの背景を変更する**

マスターレベルの背景は、レイアウトやスライドが上書きしない限り継承されます。次の例は、最初のマスタースライドに単色背景色を設定します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    master_background_color = Color.GREEN

    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(master_background_color)

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

関連トピックは、[Presentation Background](/slides/ja/python-java/presentation-background/) と [Presentation Theme](/slides/ja/python-java/presentation-theme/) を参照してください。

## **スライドマスターを別のプレゼンテーションにクローンする**

[MasterSlideCollection.addClone](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslidecollection/#addClone) を使用して、マスタースライドを別のプレゼンテーションにコピーできます。コピーされたマスターは、宛先プレゼンテーションのレイアウトやスライドで使用できます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source_presentation = Presentation("source.pptx")
destination_presentation = Presentation("destination.pptx")
try:
    source_master_slide = source_presentation.getMasters().get_Item(0)
    cloned_master_slide = destination_presentation.getMasters().addClone(source_master_slide)

    destination_presentation.save("destination-with-master.pptx", SaveFormat.Pptx)
finally:
    source_presentation.dispose()
    destination_presentation.dispose()
```

通常スライドとそのマスターをまとめてクローンする必要がある場合は、[Clone Slides](/slides/ja/python-java/clone-slides/) を参照してください。

## **複数のスライドマスターを追加する**

プレゼンテーションは複数のマスタースライドを含めることができます。セクションごとに異なるブランド、ページ構成、テーマ設定が必要な場合に便利です。

![マスタースライドの挿入と管理に関する PowerPoint コマンド](slide-master_9.jpg)

次の例は、デフォルトマスターをクローンし、クローンに別の背景を設定し、そのクローン下にレイアウトを作成し、最後にそのレイアウトに基づく新しいスライドを追加します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    section_master_slide = presentation.getMasters().addClone(default_master_slide)
    section_master_background_color = Color.LIGHT_GRAY

    section_master_slide.getBackground().setType(BackgroundType.OwnBackground)
    section_master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    section_master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(section_master_background_color)

    source_blank_layout = default_master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    if source_blank_layout is None:
        source_blank_layout = default_master_slide.getLayoutSlides().get_Item(0)

    section_blank_layout = section_master_slide.getLayoutSlides().addClone(source_blank_layout)

    presentation.getSlides().addEmptySlide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **スライドマスターの比較**

マスタースライドは、[BaseSlide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslide/) から継承された [equals](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslide/#equals) メソッドで比較できます。比較は構造と静的コンテンツ（図形、テキスト、書式設定、アニメーション、その他のスライド設定）を対象とし、スライド ID のような一意の識別子や現在の日付といった動的プレースホルダー値は比較しません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

first_presentation = Presentation("first.pptx")
second_presentation = Presentation("second.pptx")
try:
    first_presentation_master_count = first_presentation.getMasters().size()
    second_presentation_master_count = second_presentation.getMasters().size()

    for first_master_index in range(first_presentation_master_count):
        for second_master_index in range(second_presentation_master_count):
            first_master_slide = first_presentation.getMasters().get_Item(first_master_index)
            second_master_slide = second_presentation.getMasters().get_Item(second_master_index)
            are_master_slides_equal = first_master_slide.equals(second_master_slide)

            if are_master_slides_equal:
                print(f"first.pptx master #{first_master_index} equals second.pptx master #{second_master_index}")
finally:
    first_presentation.dispose()
    second_presentation.dispose()
```

詳細は、[Compare Presentation Slides](/slides/ja/python-java/compare-slides/) をご覧ください。

## **スライドマスタービューをデフォルトビューに設定する**

[ViewProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/) の [setLastView](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/#setLastView) メソッドを使用して、PowerPoint が最初に開くビューを制御できます。次の例は、プレゼンテーションをスライドマスタービューで開きます:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation("presentation.pptx")
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

その他のビュー設定については、[Save Presentation](/slides/ja/python-java/save-presentation/) を参照してください。

## **未使用のマスタースライドを削除する**

プレゼンテーションには、もはや通常スライドで使用されていないマスタースライドが含まれていることがあります。未使用のマスターを削除すると、ファイルサイズの削減とテンプレート管理の簡素化が期待できます。

[Presentation.getMasters](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getMasters) コレクションから未使用マスターを削除するには、[removeUnused](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslidecollection/#removeUnused) を使用します:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getMasters().removeUnused(True)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

低コードの [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/compress/#removeUnusedMasterSlides) メソッドでも同様に削除できます:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    Compress.removeUnusedMasterSlides(presentation)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**スライドマスターとレイアウトスライドの違いは何ですか？**

スライドマスターはテーマ、背景、共通図形、テキストスタイルなどの共有デザイン設定を定義します。レイアウトスライドはマスタースライドに属し、プレースホルダーの具体的な配置を定義します。通常スライドはレイアウトスライドを使用するため、レイアウトとマスターの両方から継承します。

**1 つのプレゼンテーションに複数のスライドマスターを含めることはできますか？**

はい。プレゼンテーションは複数のスライドマスターを含めることができます。セクションごとに異なるビジュアルシステムやブランディングが必要な場合に、複数のマスターを使用してください。

**プレースホルダーはマスタースライドに追加すべきですか、レイアウトスライドに追加すべきですか？**

ほとんどの場合、プレースホルダーはレイアウトスライドに追加します。共有のビジュアル要素や共通書式はマスタースライドに配置し、コンテンツ用のプレースホルダーは通常スライドが使用するレイアウトに配置してください。

**使用中のマスタースライドを削除できますか？**

できません。依存スライドがあるマスタースライドは直接削除できません。まずそれらのスライドを別のマスターのレイアウトに移動するか、未使用マスターのみを削除するクリーンアップ手法を使用してください。