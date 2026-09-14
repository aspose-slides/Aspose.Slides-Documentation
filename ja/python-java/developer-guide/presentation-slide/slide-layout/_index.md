---
title: Python via Java でスライドレイアウトを適用または変更
linktitle: スライドレイアウト
type: docs
weight: 60
url: /ja/python-java/slide-layout/
keywords:
- スライドレイアウト
- コンテンツレイアウト
- プレースホルダー
- プレゼンテーションデザイン
- スライドデザイン
- 未使用レイアウト
- フッター表示
- タイトルスライド
- タイトルとコンテンツ
- セクションヘッダー
- 2 つのコンテンツ
- 比較
- タイトルのみ
- ブランクレイアウト
- キャプション付きコンテンツ
- キャプション付き画像
- タイトルと縦テキスト
- 縦タイトルとテキスト
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java でスライドレイアウトを適用、作成、変更し、プレースホルダーを追加、未使用レイアウトを削除、フッター表示を制御します。"
---
## **概要**

スライドレイアウトは、タイトル、テキスト、画像、チャート、テーブルなどのプレースホルダーの位置と書式を定義します。レイアウトを適用すると、スライド全体に一貫した構造が与えられ、各スライドはそれぞれ固有のコンテンツを持つことができます。

代表的なレイアウトは次のとおりです。

- **タイトルスライド**: タイトルとサブタイトルのプレースホルダーを含みます。
- **タイトルとコンテンツ**: タイトルのプレースホルダーと汎用コンテンツプレースホルダーを含みます。
- **ブランク**: コンテンツプレースホルダーがなく、すべての形状を手動で配置する場合に便利です。

## **レイアウト継承の理解**

プレゼンテーションには以下の 3 つの関連レベルがあります。

1. [マスタースライド](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslide/)はテーマ、共有書式、背景、共通オブジェクトを定義します。
1. [レイアウトスライド](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutslide/)はマスターに属し、プレースホルダーの特定の配置を定義します。
1. [ノーマルスライド](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/)は 1 つのレイアウトを使用し、そのスライド用に入力されたコンテンツを保持します。

ノーマルスライドはレイアウトからテーマと書式を継承し、レイアウトはマスターから継承します。ノーマルスライド上で直接設定した値は、そのレベルで継承された値を上書きします。ノーマルスライドが作成されると、選択されたレイアウトからプレースホルダー形状が生成され、プレースホルダーに入力されたコンテンツはノーマルスライドに属します。

スライドを作成する前にレイアウトに必要なプレースホルダーを追加してください。後からレイアウトに別のプレースホルダーを追加しても、既存のノーマルスライドに自動的に対応するプレースホルダー形状は追加されません。

この関係には重要な結果が 2 つあります。

- レイアウト上の継承された書式や既存プレースホルダーのジオメトリを変更すると、レイアウトに依存するすべてのスライドが更新されます。使用中のレイアウトを編集する前に、依存スライドを確認し、結果のプレゼンテーションをレビューしてください。
- まだスライドで使用されているレイアウトは削除できません。先に依存スライドを別のレイアウトに再割り当てするか、未使用のレイアウトだけを削除してください。

この階層の最上位についての詳細は、[スライドマスター](/slides/ja/python-java/slide-master/) を参照してください。

## **スライドレイアウトの選択と適用**

プレゼンテーションが標準の PowerPoint レイアウト定義に従う場合は、レイアウトタイプを使用します。レイアウト名はユーザーが編集可能でローカライズできるため、ソーステンプレートを管理していない限り、名前ベースの選択は信頼性が低くなります。

次の例は、最初のマスターで **タイトルとコンテンツ** を検索します。そのレイアウトが利用できない場合は、意図的に **ブランク** にフォールバックします。`None` の 2 回目のチェックは、プレゼンテーションにカスタムレイアウトしか含まれていない可能性があるために必要です。選択されたレイアウトは、最初のノーマルスライドに対して [Slide.setLayoutSlide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#setLayoutSlide) メソッドで適用されます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slides = presentation.getMasters().get_Item(0).getLayoutSlides()
    target_layout = layout_slides.getByType(SlideLayoutType.TitleAndObject)

    if target_layout is None:
        target_layout = layout_slides.getByType(SlideLayoutType.Blank)

    if target_layout is None:
        print("The first master does not contain a suitable layout slide.")
    else:
        presentation.getSlides().get_Item(0).setLayoutSlide(target_layout)
        presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

スライドのレイアウトを変更しても、スライドに直接追加された通常の形状は削除されません。ただし、プレースホルダーの位置、継承された書式、既存プレースホルダーと新レイアウト間の対応が変わる可能性があるため、レイアウトが大きく異なる場合は出力を確認してください。

## **レイアウトスライドの追加**

選択と作成は別々の操作です。前の例は既存レイアウトを選択しただけで、作成はしていません。レイアウトを作成するには、対象マスターのレイアウトコレクションで [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterlayoutslidecollection/#add) メソッドを呼び出します。

次の例は常に **タイトルとコンテンツ** レイアウトを `Report Title and Content` という名前で新規作成し、そこからノーマルスライドを追加します。レイアウト名はコレクション内で一意である必要があります。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    report_layout = master_slide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content")
    presentation.getSlides().addEmptySlide(report_layout)

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

テンプレートが本当に別の再利用可能構造を必要とする場合にのみレイアウトを追加してください。適切なレイアウトが既に存在する場合は、重複作成せずに選択して再利用しましょう。

## **レイアウトスライドへのプレースホルダー追加**

[LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutslide/#getPlaceholderManager) メソッドは、レイアウトにプレースホルダー形状を追加するための [LayoutPlaceholderManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutplaceholdermanager/) を提供します。

| PowerPoint プレースホルダー | LayoutPlaceholderManager メソッド |
| --------------------------- | --------------------------------- |
| ![Content](content.png) | [addContentPlaceholder](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png) | [addTextPlaceholder](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png) | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png) | [addPicturePlaceholder](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png) | [addChartPlaceholder](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png) | [addTablePlaceholder](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [addSmartArtPlaceholder](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png) | [addMediaPlaceholder](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png) | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

次の例は **ブランク** レイアウトが存在することを確認し、4 つのプレースホルダーを追加した後、そのレイアウトを使用するノーマルスライドを作成します。順序は意図的で、プレースホルダーはノーマルスライド作成前に追加されるため、Aspose.Slides がそのスライド上に対応するプレースホルダー形状を生成できます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout is None:
        print("The presentation does not contain a Blank layout slide.")
    else:
        placeholder_manager = blank_layout.getPlaceholderManager()
        placeholder_manager.addContentPlaceholder(20, 20, 310, 270)
        placeholder_manager.addVerticalTextPlaceholder(350, 20, 350, 270)
        placeholder_manager.addChartPlaceholder(20, 310, 310, 180)
        placeholder_manager.addTablePlaceholder(350, 310, 350, 180)

        presentation.getSlides().addEmptySlide(blank_layout)
        presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

結果:

![レイアウトスライド上のプレースホルダー](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
継承された書式や既存レイアウトプレースホルダーのジオメトリを変更すると、依存スライドに影響を及ぼす可能性があります。新たに追加されたレイアウトプレースホルダーは既存のノーマルスライドには自動的に反映されません。レイアウトの変更はプレゼンテーションのコピーでテストし、すべての依存スライドを確認してください。
{{% /alert %}}

## **未使用レイアウトスライドの削除**

[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) メソッドを使用すると、ノーマルスライドが参照していないレイアウトを削除できます。このメソッドは、依然として使用中のレイアウトはそのまま残します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

特定のレイアウトを 1 つだけ削除するには、まずその [hasDependingSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutslide/#hasDependingSlides) または [getDependingSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutslide/#getDependingSlides) メソッドで依存スライドを取得し、[LayoutSlide.remove](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutslide/#remove) を呼び出す前に再割り当てしてください。使用中のレイアウトを削除しようとすると、[PptxEditException](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pptxeditexception/) がスローされます。

## **レイアウトスライドでフッター表示を制御する**

レイアウトは独自のフッター、スライド番号、日時プレースホルダーを持ちます。これらのプレースホルダーをレイアウト単位で制御するには、[LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) メソッドを使用します。たとえば、コンテンツレイアウトではフッターを表示し、タイトルレイアウトでは表示しないといったシナリオに便利です。

次の例はレイアウトを安全に選択し、フッター要素を表示可能にします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)

    if layout_slide is None:
        layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if layout_slide is None:
        print("The presentation does not contain a suitable layout slide.")
    else:
        header_footer_manager = layout_slide.getHeaderFooterManager()
        header_footer_manager.setFooterVisibility(True)
        header_footer_manager.setSlideNumberVisibility(True)
        header_footer_manager.setDateTimeVisibility(True)
        header_footer_manager.setFooterText("Footer text")
        header_footer_manager.setDateTimeText("Date and time text")

        presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **マスターと子レイアウト全体でフッター表示を制御する**

マスターヒエラルキー全体で一貫したフッター設定を適用するには、[MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslide/#getHeaderFooterManager) メソッドを使用します。[MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslideheaderfootermanager/) の伝播メソッドは、マスターとその依存レイアウトスライド、ノーマルスライドに対して動作し、単一のノーマルスライドだけを対象にすることはできません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    header_footer_manager = presentation.getMasters().get_Item(0).getHeaderFooterManager()
    header_footer_manager.setFooterAndChildFootersVisibility(True)
    header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)
    header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)
    header_footer_manager.setFooterAndChildFootersText("Footer text")
    header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**マスタースライドとレイアウトスライドの違いは何ですか？**

マスタースライドはプレゼンテーションのテーマと共有書式を定義します。レイアウトスライドはマスターに属し、プレースホルダーの再利用可能な配置を 1 つ定義します。ノーマルスライドはこれらのレイアウトを使用し、スライド固有のコンテンツを保持します。

**レイアウトスライドを別のプレゼンテーションにコピーできますか？**

はい。目的のコレクションに対して [addClone](https://reference.aspose.com/slides/ja/python-java/aspose.slides/globallayoutslidecollection/#addClone) メソッドでコピーを追加します。コピー元レイアウトで使用されているフォント、テーマ、画像、その他リソースも併せて確認してください。

**使用中のレイアウトを変更するとどうなりますか？**

依存スライドはレイアウトの変更を継承します（ローカルで上書きしていない限り）。プレースホルダーのジオメトリや継承されたスタイリングが多くのスライドで一度に変わる可能性があります。編集前に [getDependingSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutslide/#getDependingSlides) で影響を受けるスライドを特定しましょう。

**使用中のレイアウトを削除しようとするとどうなりますか？**

Aspose.Slides は [PptxEditException](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pptxeditexception/) をスローします。まず依存スライドを再割り当てするか、[removeUnusedLayoutSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) を使用して未参照のレイアウトだけを削除してください。