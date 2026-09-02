---
title: Pythonでスライドレイアウトを適用または変更
linktitle: スライドレイアウト
type: docs
weight: 60
url: /ja/python-net/slide-layout/
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
- 空白レイアウト
- キャプション付きコンテンツ
- キャプション付き画像
- タイトルと縦テキスト
- 縦タイトルとテキスト
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NETでスライドレイアウトを適用、作成、変更し、プレースホルダーを追加、未使用レイアウトを削除、フッター表示を制御します。"
---
## **概要**

スライドレイアウトは、タイトル、テキスト、画像、チャート、テーブルなどのプレースホルダーの位置と書式を定義します。レイアウトを適用すると、スライドに一貫した構造が与えられ、各スライドが独自のコンテンツを保持できます。

最も一般的なレイアウトは次のとおりです。

- **Title Slide**: タイトルとサブタイトルのプレースホルダーが含まれています。
- **Title and Content**: タイトルのプレースホルダーと汎用コンテンツプレースホルダーが含まれています。
- **Blank**: コンテンツプレースホルダーがなく、すべての図形を手動で配置する場合に便利です。

## **レイアウト継承の理解**

プレゼンテーションには、関連する 3 つのレベルがあります。

1. A [master slide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masterslide/) は、テーマ、共有書式設定、背景、および共通オブジェクトを定義します。
1. A [layout slide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutslide/) はマスターに属し、プレースホルダーの特定の配置を定義します。
1. A [normal slide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/) は 1 つのレイアウトを使用し、そのスライドに入力されたコンテンツを保存します。

ノーマルスライドはレイアウトからテーマと書式設定を継承し、レイアウトはマスターから継承します。ノーマルスライドに直接設定された値は、そのレベルで継承された値を上書きします。ノーマルスライドが作成されると、選択されたレイアウトからプレースホルダー形状が生成され、プレースホルダーに入力されたコンテンツはノーマルスライドに属します。

レイアウトからスライドを作成する前に、必要なプレースホルダーをレイアウトに追加してください。後からレイアウトに別のプレースホルダーを追加しても、既存のノーマルスライドに自動的に対応するプレースホルダー形状は追加されません。

この関係には 2 つの重要な結果があります。

- レイアウト上の継承された書式設定や既存プレースホルダーのジオメトリを変更すると、そこに依存するすべてのスライドが更新されます。すでに使用中のレイアウトを編集する前に、依存スライドを確認し、生成結果のプレゼンテーションをレビューしてください。
- スライドで使用中のレイアウトは削除できません。まず依存スライドを別のレイアウトに再割り当てするか、未使用のレイアウトのみを削除してください。

この階層の最上位に関する詳しい情報は、[Slide Master](/slides/ja/python-net/slide-master/) を参照してください。

## **スライドレイアウトの選択と適用**

プレゼンテーションが標準の PowerPoint レイアウト定義に従う場合は、レイアウトタイプを使用します。レイアウト名はユーザーが編集可能でローカライズできるため、ソーステンプレートを管理していない限り、名前ベースの選択は信頼性が低くなります。

以下の例は、最初のマスターで **Title and Content** を探します。レイアウトが利用できない場合は、意図的に **Blank** にフォールバックします。2 回目の null チェックは、プレゼンテーションにカスタムレイアウトのみが含まれる可能性があるために必要です。選択されたレイアウトは、[Slide.layout_slide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/layout_slide/) プロパティを介して最初のノーマルスライドに適用されます。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slides = presentation.masters[0].layout_slides
    target_layout = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if target_layout is None:
        target_layout = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if target_layout is None:
        raise RuntimeError("The first master does not contain a suitable layout slide.")

    presentation.slides[0].layout_slide = target_layout
    presentation.save("output-with-new-layout.pptx", slides.export.SaveFormat.PPTX)
```

スライドのレイアウトを変更しても、スライドに直接追加された通常の図形は削除されません。ただし、プレースホルダーの位置、継承された書式設定、および既存プレースホルダーと新しいレイアウトとの対応関係が変わる可能性があるため、実質的に異なるレイアウト間を切り替える際は出力を確認してください。

## **レイアウトスライドの追加**

選択と作成は別々の操作です。前の例は既存のレイアウトを選択していますが、作成はしていません。レイアウトを作成するには、対象マスターのレイアウトコレクションで [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masterlayoutslidecollection/add/) メソッドを呼び出します。

以下の例は常に `Report Title and Content` という名前の新しい **Title and Content** レイアウトを追加し、それに基づくノーマルスライドを追加します。レイアウト名はコレクション内で一意である必要があります。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

テンプレートが本当に別の再利用可能な構造を必要とする場合にのみレイアウトを追加してください。適切なレイアウトがすでに存在する場合は、重複作成せずに選択して再利用してください。

## **レイアウトスライドへのプレースホルダーの追加**

[LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutslide/placeholder_manager/) プロパティは、レイアウトにプレースホルダー形状を追加するための [LayoutPlaceholderManager](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutplaceholdermanager/) を提供します。

| PowerPoint プレースホルダー | `LayoutPlaceholderManager` メソッド |
| --------------------------- | ----------------------------------- |
| ![Content](content.png) | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![Content (Vertical)](contentV.png) | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![Text](text.png) | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![Text (Vertical)](textV.png) | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![Picture](picture.png) | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![Chart](chart.png) | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![Table](table.png) | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png) | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![Media](media.png) | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![Online Image](onlineImage.png) | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

以下の例は **Blank** レイアウトが存在することを確認し、4 つのプレースホルダーを追加してから、修正されたレイアウトを使用するノーマルスライドを作成します。順序は意図的で、プレースホルダーはノーマルスライド作成前に追加されるため、Aspose.Slides はそのスライド上に対応するプレースホルダー形状を生成できます。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout is None:
        raise RuntimeError("The presentation does not contain a Blank layout slide.")

    placeholder_manager = blank_layout.placeholder_manager
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    presentation.slides.add_empty_slide(blank_layout)
    presentation.save("output-with-placeholders.pptx", slides.export.SaveFormat.PPTX)
```

結果:

![レイアウトスライド上のプレースホルダー](add_placeholders.png)

{{% alert color="warning" title="警告" %}}
継承された書式設定や既存レイアウトプレースホルダーのジオメトリを変更すると、依存スライドに影響を与える可能性があります。新しく追加されたレイアウトプレースホルダーは既存のノーマルスライドに自動的に補填されません。プレゼンテーションのコピーでレイアウト変更をテストし、すべての依存スライドを確認してください。
{{% /alert %}}

## **未使用レイアウトスライドの削除**

[Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) メソッドを使用して、ノーマルスライドが参照していないレイアウトを削除します。このメソッドは、使用中のレイアウトはそのまま残します。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

特定のレイアウトを削除するには、まずその [has_depending_slides](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutslide/has_depending_slides/) プロパティまたは [get_depending_slides](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutslide/get_depending_slides/) メソッドを使用してください。削除前に依存スライドを別のレイアウトに再割り当てし、[LayoutSlide.remove](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutslide/remove/) を呼び出します。使用中のレイアウトを削除しようとすると、[PptxEditException](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pptxeditexception/) がスローされます。

## **レイアウトスライドでのフッター表示の制御**

レイアウトには独自のフッター、スライド番号、日付時刻プレースホルダーがあります。これらのプレースホルダーを 1 つのレイアウトで制御するには、[LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutslide/header_footer_manager/) プロパティを使用します。たとえば、コンテンツレイアウトはフッターを表示し、タイトルレイアウトは表示しないようにする場合に便利です。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if layout_slide is None:
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if layout_slide is None:
        raise RuntimeError("The presentation does not contain a suitable layout slide.")

    header_footer_manager = layout_slide.header_footer_manager
    header_footer_manager.set_footer_visibility(True)
    header_footer_manager.set_slide_number_visibility(True)
    header_footer_manager.set_date_time_visibility(True)
    header_footer_manager.set_footer_text("Footer text")
    header_footer_manager.set_date_time_text("Date and time text")

    presentation.save("output-with-layout-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **マスターとその子レイアウトでのフッター表示の制御**

マスターヒエラルキー全体で一貫したフッター設定を適用するには、[MasterSlide.header_footer_manager](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masterslide/header_footer_manager/) プロパティを使用します。[MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masterslideheaderfootermanager/) の伝搬メソッドは、マスターとその依存レイアウトスライドおよびノーマルスライドに対して動作し、単一のノーマルスライドだけを対象にすることはありません。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager
    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)
    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output-with-master-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **よくある質問**

**マスタースライドとレイアウトスライドの違いは何ですか？**

マスタースライドはプレゼンテーションのテーマと共有書式設定を定義します。レイアウトスライドはマスターに属し、プレースホルダーの再利用可能な配置を 1 つ定義します。ノーマルスライドはこれらのレイアウトを使用し、スライド固有のコンテンツを保存します。

**レイアウトスライドをあるプレゼンテーションから別のプレゼンテーションへコピーできますか？**

はい。コピーを宛先コレクションに追加するには、[add_clone](https://reference.aspose.com/slides/ja/python-net/aspose.slides/globallayoutslidecollection/add_clone/) メソッドを使用します。プレゼンテーション間でコピーする場合は、フォント、テーマ、画像、その他ソースレイアウトで使用されているリソースも確認してください。

**使用中のレイアウトを変更するとどうなりますか？**

依存スライドはローカルで書式設定やオブジェクトを上書きしていない限り、レイアウトの変更を継承します。そのため、プレースホルダーのジオメトリや継承されたスタイリングが多数のスライドで一度に変わる可能性があります。レイアウトを編集する前に、[get_depending_slides](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutslide/get_depending_slides/) を使用して影響を受けるスライドを特定してください。

**使用中のレイアウトを削除しようとするとどうなりますか？**

Aspose.Slides は [PptxEditException](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pptxeditexception/) をスローします。まず依存スライドを再割り当てるか、[remove_unused_layout_slides](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) を使用して未参照のレイアウトだけを削除してください。