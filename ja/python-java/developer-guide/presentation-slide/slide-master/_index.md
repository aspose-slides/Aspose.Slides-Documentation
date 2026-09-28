---
title: Python via Java でプレゼンテーションのスライドマスターを管理する
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
description: "Aspose.Slides for Python via Java でスライドマスターを管理します。PowerPoint と OpenDocument のプレゼンテーションでマスタースライドを取得、編集、クローン、比較、削除できます。"
---
## **概要**

**スライドマスター** は、複数のスライドに共通するデザイン設定を定義します。共通の図形、ロゴ、背景、テキストスタイル、テーマ設定、フッター設定などを含めることができます。PowerPoint では、スライドマスターを編集することで、各スライドで同じ書式設定を繰り返すことなくプレゼンテーションの一貫性を保つのが一般的な方法です。

Aspose.Slides for Python via Java は同じモデルをサポートしています。プレゼンテーションは 1 つまたは複数のマスタースライドを含むことができ、各マスタースライドは複数のレイアウトスライドを含みます。通常のスライドはマスタースライドを直接参照することはなく、代わりにレイアウトスライドを使用し、そのレイアウトスライドはマスタースライドに属しています。

階層は:

1. **スライドマスター** - 共有デザインとテーマを定義します。  
2. **レイアウトスライド** - プレースホルダーとレイアウトレベルの書式設定の特定の配置を定義します。  
3. **通常スライド** - 実際のプレゼンテーションコンテンツを含み、1 つのレイアウトスライドを使用します。

![マスタースライド、レイアウトスライド、通常スライドの階層構造](slide-master_2.jpg)

Aspose.Slides では、スライドマスターは [MasterSlide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslide/) クラスで表されます。プレゼンテーション内のすべてのマスタースライドは [Presentation.getMasters](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getMasters) コレクションを通じて取得でき、これは [MasterSlideCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslidecollection/) で表されます。

{{% alert color="info" title="Inheritance" %}}
同じプロパティが複数のレベルで定義されている場合、より具体的なレベルが優先されます。たとえば、マスタースライドとレイアウトスライドの両方で背景が設定されている場合、そのレイアウトに基づくスライドはレイアウトの背景を使用します。レイアウトスライドの詳細については、[Apply or Change Slide Layouts](/slides/ja/python-java/slide-layout/) を参照してください。
{{% /alert %}}

## **スライドマスターへのアクセス**

PowerPoint では、**表示** > **スライドマスター** からスライドマスター表示を開くことができます。

![PowerPoint の表示タブにあるスライドマスター コマンド](slide-master_3.jpg)

Aspose.Slides では、[Presentation.getMasters](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getMasters) コレクションを使用してマスタースライドにアクセスします：

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

通常のスライドが使用しているマスタースライドは、そのレイアウトを介して取得することもできます：

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

マスタースライドはスライドに似たオブジェクトです。それは [BaseSlide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslide/) を継承しているため、通常スライドやレイアウトスライドと同じスライドプロパティの多くを利用できます。マスター固有のメンバーは [MasterSlide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslide/) API ページに一覧されています。

一般的に使用されるマスタースライドのメンバーは以下です：

| メンバー | 目的 |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslide/#getBackground) | マスターレベルのスライド背景を設定します。 |
| [getShapes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslide/#getShapes) | マスター上に配置された図形（ロゴ、画像フレーム、共有テキストなど）を格納します。 |
| [getLayoutSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslide/#getLayoutSlides) | マスターに属するレイアウトスライドを格納します。 |
| [getThemeManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslide/#getThemeManager) | マスターのテーマ API へのアクセスを提供します。 |
| [getHeaderFooterManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | マスターとその子レイアウトのヘッダー、フッター、日付、スライド番号を制御します。 |
| [getDependingSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslide/#getDependingSlides) | レイアウトを介してマスターに依存している通常スライドを返します。 |

## **スライドマスターに画像を追加する**

マスタースライドに画像を追加すると、そのマスターのレイアウトを使用するスライドに画像が表示されます。ロゴ、透かし、装飾バンド、その他繰り返し使用されるビジュアル要素に便利です。

以下の例は、最初のマスタースライドにロゴを追加します：

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

## **マスターグラフィックの表示制御**

継承されたマスターグラフィック（ロゴや装飾形状など）をマスターから削除せずに非表示にするには、[BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslide/#setShowMasterShapes) を使用します。非表示にしたいスライドでは [Slide.setShowMasterShapes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#setShowMasterShapes) に `False` を渡し、表示させたいスライドでは `True` のままにします。

以下の自己完結型サンプルは、マスターに青い装飾バンドを作成し、同じ空白レイアウトを使用する 2 枚のスライドを作成します。バンドは最初のスライドで表示され、2 番目のスライドで非表示になります。入力プレゼンテーションや画像は必要ありません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    layout_slide.setShowMasterShapes(True)

    slide_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    band = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slide_height)
    band_color = Color(70, 130, 180)
    band.getFillFormat().setFillType(FillType.Solid)
    band.getFillFormat().getSolidFillColor().setColor(band_color)
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    visible_slide = presentation.getSlides().get_Item(0)
    visible_slide.setLayoutSlide(layout_slide)
    visible_slide.getShapes().clear()

    hidden_slide = presentation.getSlides().addEmptySlide(layout_slide)

    visible_slide.setShowMasterShapes(True)
    hidden_slide.setShowMasterShapes(False)

    presentation.save("master-graphics.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

この例は新しいプレゼンテーションに付属する **Blank** レイアウトを使用し、最初のスライドのプレースホルダーを削除します。

### **設定のスコープを選択する**

通常スライドは [Slide.getLayoutSlide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#getLayoutSlide) と [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutslide/#getMasterSlide) を通じてマスターを使用します。個々のスライドにプロパティを設定すると、そのスライドにのみ影響します。[LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutslide/#setShowMasterShapes) に `False` を渡すと、その共有レイアウトを使用するすべてのスライドでマスターグラフィックが非表示になります（各スライドの設定が `True` であっても）。1 つのスライドだけでグラフィックを非表示にしたい場合は、スライドのプロパティを変更し、共有レイアウトはそのままにします。

この設定はマスタースライド自体の可視性制御としてはサポートされていません。マスター上で [getShowMasterShapes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslide/#getShowMasterShapes) は常に `False` を返し、[setShowMasterShapes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslide/#setShowMasterShapes) に `True` を渡すと例外がスローされます。代わりに通常スライドまたはレイアウトに適用してください。

### **グラフィックと背景を区別する**

| 操作 | 効果 |
| --- | --- |
| マスターグラフィックを非表示にする | 継承されたマスターシェイプを削除したりスライド自身のシェイプを変更したりせずに表示/非表示を制御します。 |
| スライドの背景塗りつぶしを変更する | 背景の色、グラデーション、画像を変更します。マスターグラフィックは別個のシェイプであり、その背景上に表示されたままにできます。[Presentation Background](/slides/ja/python-java/presentation-background/) を参照してください。 |
| マスターからシェイプを削除する | 共有ソースシェイプを削除し、そのマスターを使用するすべてのスライドから利用できなくなります。 |

## **プレースホルダーの操作**

プレースホルダーは通常、レイアウトスライド上で定義されます。マスタースライドは、レイアウトが継承する共有スタイルとテーマを提供し、各レイアウトは使用可能なプレースホルダーとその配置を決定します。

PowerPoint では、スライドマスター表示でプレースホルダーコマンドが利用できます。

![PowerPoint スライドマスター表示でのプレースホルダー挿入コマンド](slide-master_5.png)

Aspose.Slides で新しいプレースホルダーを追加するには、マスターに属するレイアウトスライドを操作します：

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

マスタースライドに既に存在するプレースホルダーシェイプの書式設定も可能です。以下の例では、タイトルプレースホルダーを検索し、線形グラデーション塗りつぶしを適用します：

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

![通常スライドが継承するフォーマット済みタイトルプレースホルダー](slide-master_8.png)

プレースホルダーやテキスト書式設定の詳細オプションについては、[Set Prompt Text in Placeholder](/slides/ja/python-java/manage-placeholder/) と [Text Formatting](/slides/ja/python-java/text-formatting/) を参照してください。

## **スライドマスターの背景を変更する**

マスターの背景は、上書きしないレイアウトやスライドに継承されます。以下の例は、最初のマスタースライドに単色背景色を設定します：

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

[MasterSlideCollection.addClone](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslidecollection/#addClone) を使用して、マスタースライドを別のプレゼンテーションにコピーします。コピーされたマスターは、宛先プレゼンテーションのレイアウトやスライドで使用できます。

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

通常スライドとそのマスターを一緒にクローンする必要がある場合は、[Clone Slides](/slides/ja/python-java/clone-slides/) を参照してください。

## **複数のスライドマスターを追加する**

プレゼンテーションは複数のマスタースライドを含めることができます。異なるセクションで異なるブランディング、ページ構成、テーマ設定が必要な場合に便利です。

![マスタースライドの挿入と管理のための PowerPoint コマンド](slide-master_9.jpg)

以下の例は、デフォルトのマスターをクローンし、クローンに別の背景を設定し、そのクローンマスターの下にレイアウトを作成し、そのレイアウトに基づく新しいスライドを追加します：

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

マスタースライドは、[BaseSlide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslide/) から継承された [equals](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslide/#equals) メソッドで比較できます。比較では、図形、テキスト、書式設定、アニメーション、その他のスライド設定など、構造と静的コンテンツがチェックされます。スライド ID などの固有識別子や、現在の日付などの動的プレースホルダー値は比較対象になりません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpame.startJVM()

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

詳細については、[Compare Presentation Slides](/slides/ja/python-java/compare-slides/) を参照してください。

## **スライドマスター表示をデフォルトビューに設定する**

[ViewProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/) の [setLastView](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/#setLastView) メソッドを使用して、PowerPoint が最初に開くビューを制御します。以下の例は、プレゼンテーションをスライドマスター表示で開きます：

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

ビュー設定の詳細は、[Save Presentation](/slides/ja/python-java/save-presentation/) を参照してください。

## **未使用のマスタースライドを削除する**

プレゼンテーションには、もはや通常スライドで使用されていないマスタースライドが含まれていることがあります。未使用のマスターを削除すると、ファイルサイズが削減され、テンプレートの保守が簡素化されます。

[removeUnused](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslidecollection/#removeUnused) を使用して、[Presentation.getMasters](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getMasters) コレクションから未使用のマスターを削除します：

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

低コードの [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/compress/#removeUnusedMasterSlides) メソッドを使用することもできます：

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

スライドマスターは、テーマ、背景、共通の図形、テキストスタイルなどの共有デザイン設定を定義します。レイアウトスライドはマスタースライドに属し、プレースホルダーの特定の配置を定義します。通常のスライドはレイアウトスライドを使用するため、レイアウトとマスターの両方から継承されます。

**1 つのプレゼンテーションに複数のスライドマスターを含めることができますか？**

はい。プレゼンテーションは複数のスライドマスターを含めることができます。異なるセクションで異なるビジュアル体系やブランディングが必要な場合に、複数のマスターを使用してください。

**プレースホルダーはマスタースライドに追加すべきですか、レイアウトスライドに追加すべきですか？**

ほとんどの場合、プレースホルダーはレイアウトスライドに追加します。共有のビジュアル要素や書式設定はマスタースライドに配置し、コンテンツ用のプレースホルダーは通常スライドが使用するレイアウトに置きます。

**使用中のマスタースライドを削除できますか？**

いいえ。依存しているスライドがあるマスタースライドは直接安全に削除できません。まずそれらのスライドを別のマスターのレイアウトに移動するか、使用されていないマスターのみを削除するクリーンアップ手法を使用してください。