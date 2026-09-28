---
title: Python（Java 経由）でスライドレイアウトを適用または変更する
linktitle: スライドレイアウト
type: docs
weight: 60
url: /ja/python-java/slide-layout/
keywords:
- スライドレイアウト
- コンテンツレイアウト
- プレースホルダー
- プレゼンテーション デザイン
- スライド デザイン
- 未使用レイアウト
- フッターの表示
- タイトル スライド
- タイトルとコンテンツ
- セクション ヘッダー
- 2 コンテンツ
- 比較
- タイトルのみ
- 空白レイアウト
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
description: "Aspose.Slides for Python via Java でスライドレイアウトを適用、作成、変更し、プレースホルダーを追加、未使用レイアウトを削除、フッターの表示を制御します。"
---
## **概要**

スライドレイアウトは、タイトル、テキスト、画像、チャート、テーブルなどのプレースホルダーの位置と書式を定義します。レイアウトを適用することで、スライドは一貫した構造となりつつ、各スライドが独自のコンテンツを保持できます。

最も一般的なレイアウトは次のとおりです：

- **Title Slide**: タイトルとサブタイトルのプレースホルダーが含まれます。
- **Title and Content**: タイトルのプレースホルダーと汎用コンテンツプレースホルダーが含まれます。
- **Blank**: コンテンツプレースホルダーがなく、すべてのシェイプを手動で配置する場合に便利です。

## **レイアウト継承の理解**

プレゼンテーションには、次の 3 つの関連レベルがあります：

1. [マスタースライド](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslide/) は、テーマ、共有書式、背景、共通オブジェクトを定義します。
2. [レイアウトスライド](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutslide/) はマスタに属し、プレースホルダーの特定の配置を定義します。
3. [標準スライド](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/) は 1 つのレイアウトを使用し、そのスライドに入力されたコンテンツを保存します。

標準スライドはレイアウトからテーマと書式を継承し、レイアウトはマスタから継承します。標準スライドに直接設定された値は、そのレベルで継承された値を上書きします。標準スライドが作成されると、そのプレースホルダーシェイプは選択されたレイアウトから生成され、プレースホルダーに入力されたコンテンツは標準スライドに属します。

レイアウトからスライドを作成する前に必要なプレースホルダーをレイアウトに追加してください。後からレイアウトに別のプレースホルダーを追加しても、既存の標準スライドに自動的に対応するプレースホルダーシェイプは追加されません。

この関係には 2 つの重要な結果があります：

- レイアウト上で継承された書式や既存プレースホルダーのジオメトリを変更すると、それに依存するすべてのスライドが更新されます。既に使用されているレイアウトを編集する前に、依存スライドを確認し、結果のプレゼンテーションをレビューしてください。
- まだスライドで使用されているレイアウトは削除できません。まず依存スライドを別のレイアウトに割り当てるか、未使用のレイアウトのみを削除してください。

この階層の最上位についての詳細は、[スライド マスター](/slides/ja/python-java/slide-master/) を参照してください。

スライドや共有レイアウトで継承されたロゴや装飾的なマスタ形状を非表示にする方法は、[マスタ グラフィックの表示制御](/slides/ja/python-java/slide-master/) を参照してください。この例は同じマスタを使用する 2 つのスライドを比較しています。

## **スライド レイアウトの選択と適用**

プレゼンテーションが標準の PowerPoint レイアウト定義に従う場合は、レイアウトタイプを使用します。レイアウト名はユーザーが編集でき、ローカライズ可能なため、ソーステンプレートを管理していない限り、名前ベースの選択は信頼性が低くなります。

次の例は最初のマスタで **Title and Content** を探します。そのレイアウトが利用できない場合は、意図的に **Blank** にフォールバックします。`None` の 2 回目のチェックは、プレゼンテーションにカスタムレイアウトのみが含まれる可能性があるために必要です。選択したレイアウトは、[Slide.setLayoutSlide](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#setLayoutSlide) メソッドを介して最初の標準スライドに適用されます。

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

スライドのレイアウトを変更しても、スライドに直接追加された通常のシェイプは削除されません。ただし、プレースホルダーの位置、継承された書式、および既存プレースホルダーと新しいレイアウト間の対応が変わる可能性があるため、実質的に異なるレイアウト間を切り替える際は出力を確認してください。

## **レイアウト スライドの追加**

選択と作成は別々の操作です。前の例は既存のレイアウトを選択していますが、作成はしていません。レイアウトを作成するには、対象マスタのレイアウトコレクションで [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterlayoutslidecollection/#add) メソッドを呼び出します。

次の例は常に **Title and Content** レイアウトを `Report Title and Content` という名前で新規追加し、そのレイアウトに基づく標準スライドを追加します。レイアウト名はコレクション内で一意である必要があります。

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

テンプレートが本当に別の再利用可能構造を必要とする場合にのみレイアウトを追加してください。適切なレイアウトが既に存在する場合は、重複作成せずにそれを選択して再利用してください。

## **レイアウト スライドへのプレースホルダーの追加**

[LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutslide/#getPlaceholderManager) メソッドは、レイアウトにプレースホルダーシェイプを追加するための [LayoutPlaceholderManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutplaceholdermanager/) を提供します。

| PowerPoint プレースホルダー              | [LayoutPlaceholderManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutplaceholdermanager/) メソッド |
| ----------------------------------- | ---------------------------------- |
| ![コンテンツ](content.png)             | [addContentPlaceholder](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![コンテンツ（縦）](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![テキスト](text.png)                   | [addTextPlaceholder](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![テキスト（縦）](textV.png)       | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![画像](picture.png)             | [addPicturePlaceholder](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![チャート](chart.png)                 | [addChartPlaceholder](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![テーブル](table.png)                 | [addTablePlaceholder](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)           | [addSmartArtPlaceholder](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![メディア](media.png)                 | [addMediaPlaceholder](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![オンライン画像](onlineImage.png)    | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

次の例は **Blank** レイアウトが存在することを確認し、4 つのプレースホルダーを追加してから、そのレイアウトを使用する標準スライドを作成します。順序は意図的で、プレースホルダーは標準スライドが作成される前に追加されるため、Aspose.Slides がそのスライド上に対応するプレースホルダーシェイプを生成できます。

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

結果：

![レイアウト スライド上のプレースホルダー](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
継承された書式や既存レイアウトプレースホルダーのジオメトリを変更すると、依存スライドに影響を与える可能性があります。新しく追加されたレイアウトプレースホルダーは既存の標準スライドには自動的に反映されません。レイアウトの変更はプレゼンテーションのコピーでテストし、すべての依存スライドを確認してください。
{{% /alert %}}

## **未使用レイアウト スライドの削除**

[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) メソッドを使用して、標準スライドが参照していないレイアウトを削除します。このメソッドは、まだ使用中のレイアウトはそのまま残します。

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

特定のレイアウトを 1 つ削除するには、まずその [hasDependingSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutslide/#hasDependingSlides) または [getDependingSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutslide/#getDependingSlides) メソッドを使用します。削除前に依存スライドを別のレイアウトに再割り当てしてください。使用中のレイアウトを削除しようとすると、[PptxEditException](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pptxeditexception/) がスローされます。

## **レイアウト スライドでフッターの表示制御**

レイアウトには独自のフッター、スライド番号、日付時刻プレースホルダーがあります。これらのプレースホルダーをレイアウト単位で制御するには、[LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) メソッドを使用します。たとえば、コンテンツレイアウトではフッターを表示し、タイトルレイアウトでは非表示にしたい場合に便利です。

次の例はレイアウトを安全に選択し、フッター要素を表示します：

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

## **マスタとその子レイアウトでフッターの表示制御**

マスタ階層全体で一貫したフッター設定を適用するには、[MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslide/#getHeaderFooterManager) メソッドを使用します。[MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/masterslideheaderfootermanager/) の伝搬メソッドはマスタとその依存レイアウトスライドおよび標準スライドに対して動作し、単一の標準スライドだけを対象にすることはできません。

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

**マスタ スライドとレイアウト スライドの違いは何ですか？**

マスタスライドはプレゼンテーションのテーマと共有書式を定義します。レイアウトスライドはマスタに属し、プレースホルダーの再利用可能な配置を定義します。標準スライドはそれらのレイアウトを使用し、スライド固有のコンテンツを保存します。

**レイアウト スライドを別のプレゼンテーションにコピーできますか？**

はい。目的のコレクションに [addClone](https://reference.aspose.com/slides/ja/python-java/aspose.slides/globallayoutslidecollection/#addClone) メソッドでコピーを追加します。コピー先でもフォント、テーマ、画像、その他のリソースが正しく参照されていることを確認してください。

**使用中のレイアウトを変更するとどうなりますか？**

依存スライドはレイアウト変更を継承しますが、ローカルで書式やオブジェクトを上書きしている場合は例外です。プレースホルダーのジオメトリや継承スタイルが多数のスライドで同時に変わる可能性があります。編集前に [getDependingSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/layoutslide/#getDependingSlides) で影響を受けるスライドを特定してください。

**使用中のレイアウトを削除しようとするとどうなりますか？**

Aspose.Slides は [PptxEditException](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pptxeditexception/) をスローします。まず依存スライドを別のレイアウトに再割り当てするか、[removeUnusedLayoutSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) を使用して未参照のレイアウトのみを削除してください。