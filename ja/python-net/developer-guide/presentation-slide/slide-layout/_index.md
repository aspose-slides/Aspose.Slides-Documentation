---
title: Pythonでスライドレイアウトを適用または変更する
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
- フッターの表示
- タイトルスライド
- タイトルとコンテンツ
- セクションヘッダー
- 2つのコンテンツ
- 比較
- タイトルのみ
- 空白レイアウト
- キャプション付きコンテンツ
- キャプション付き画像
- タイトルと縦書きテキスト
- 縦書きタイトルとテキスト
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET でスライドレイアウトを適用、作成、変更し、プレースホルダーを追加、未使用レイアウトを削除、フッターの表示を制御します。"
---
## **概要**

スライドレイアウトは、タイトル、テキスト、画像、チャート、表などのプレースホルダーの位置と書式を定義します。レイアウトを適用することで、スライドに一貫した構造が与えられ、各スライドが独自のコンテンツを保持できるようになります。

最も一般的なレイアウトは次のとおりです：

- **タイトルスライド**: タイトルとサブタイトルのプレースホルダーが含まれます。
- **タイトルとコンテンツ**: タイトルのプレースホルダーと汎用コンテンツのプレースホルダーが含まれます。
- **空白**: コンテンツプレースホルダーがなく、すべての図形を手動で配置する場合に便利です。

## **レイアウト継承の理解**

プレゼンテーションには、次の3つの関連レベルがあります：

1. [マスタースライド](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masterslide/) はテーマ、共有書式、背景、および共通オブジェクトを定義します。
2. [レイアウトスライド](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutslide/) はマスターに属し、特定のプレースホルダー配置を定義します。
3. [標準スライド](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/) は1つのレイアウトを使用し、そのスライドに入力されたコンテンツを保存します。

標準スライドはレイアウトからテーマと書式を継承し、レイアウトはマスターから継承します。標準スライド上で直接設定した値は、そのレベルで継承された値を上書きします。標準スライドが作成されると、プレースホルダー形状は選択されたレイアウトから生成され、プレースホルダーに入力されたコンテンツは標準スライドに属します。

レイアウトからスライドを作成する前に、必要なプレースホルダーをレイアウトに追加してください。後からレイアウトに別のプレースホルダーを追加しても、既存の標準スライドに自動的に対応するプレースホルダー形状が追加されることはありません。

この関係には2つの重要な結果があります：

- レイアウト上で継承された書式や既存プレースホルダーのジオメトリを変更すると、それに依存するすべてのスライドが更新される可能性があります。既に使用中のレイアウトを編集する前に、依存スライドを確認し、生成されるプレゼンテーションを検証してください。
- スライドが使用中のレイアウトは削除できません。まず依存スライドを別のレイアウトに再割り当てするか、未使用のレイアウトのみを削除してください。

この階層の最上位についての詳細は、[スライドマスター](/slides/ja/python-net/slide-master/) を参照してください。

1つのスライドまたは共有レイアウトで継承されたロゴや装飾的なマスター形状を非表示にするには、[マスターグラフィックの表示制御](/slides/ja/python-net/slide-master/) を参照してください。この例は同じマスターを使用した2つのスライドを比較しています。

## **スライドレイアウトの選択と適用**

プレゼンテーションが標準的な PowerPoint レイアウト定義に従っている場合は、レイアウトタイプを使用します。レイアウト名はユーザーが編集可能でローカライズ可能なため、テンプレートのソースを管理していない限り、名前ベースの選択は信頼性が低くなります。

次の例は、最初のマスター上で **タイトルとコンテンツ** を探します。そのレイアウトが利用できない場合は、意図的に **空白** にフォールバックします。2番目の null チェックは、プレゼンテーションにカスタムレイアウトしか含まれない場合に必要です。選択されたレイアウトは、[Slide.layout_slide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/layout_slide/) プロパティを介して最初の標準スライドに適用されます。

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

スライドのレイアウトを変更しても、スライドに直接追加された通常の図形は削除されません。ただし、プレースホルダーの位置、継承された書式、および既存プレースホルダーと新しいレイアウト間の対応関係が変わる可能性があるため、レイアウトが大幅に異なる場合は出力を確認してください。

## **レイアウトスライドの追加**

選択と作成は別々の操作です。前の例は既存のレイアウトを選択していますが、作成はしていません。レイアウトを作成するには、対象マスターのレイアウトコレクション上で [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masterlayoutslidecollection/add/) メソッドを呼び出します。

次の例は常に `Report Title and Content` という名前の新しい **タイトルとコンテンツ** レイアウトを追加し、そこから標準スライドを追加します。レイアウト名はコレクション内で一意である必要があります。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

テンプレートが実際に別の再利用可能な構造を必要とする場合にのみレイアウトを追加してください。適切なレイアウトが既に存在する場合は、重複を作成せずに選択して再利用してください。

## **レイアウトスライドへのプレースホルダーの追加**

[LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutslide/placeholder_manager/) プロパティは、レイアウトにプレースホルダー形状を追加するための [LayoutPlaceholderManager](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutplaceholdermanager/) を提供します。

| PowerPoint プレースホルダー | `LayoutPlaceholderManager` メソッド |
| -------------------------- | ----------------------------------- |
| ![コンテンツ](content.png) | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![コンテンツ (縦)](contentV.png) | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![テキスト](text.png) | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![テキスト (縦)](textV.png) | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![画像](picture.png) | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![チャート](chart.png) | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![表](table.png) | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png) | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![メディア](media.png) | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![オンライン画像](onlineImage.png) | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

次の例は **空白** レイアウトが存在することを確認し、4つのプレースホルダーを追加してから、変更されたレイアウトを使用する標準スライドを作成します。順序は意図的で、プレースホルダーは標準スライドが作成される前に追加されるため、Aspose.Slides はそのスライド上に対応するプレースホルダー形状を生成できます。

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

結果：

![レイアウトスライド上のプレースホルダー](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
継承された書式や既存レイアウトプレースホルダーのジオメトリを変更すると、依存スライドに影響を与える可能性があります。新しく追加されたレイアウトプレースホルダーは既存の標準スライドに自動的に反映されません。レイアウトの変更はプレゼンテーションのコピーでテストし、すべての依存スライドを確認してください。
{{% /alert %}}

## **未使用レイアウトスライドの削除**

[Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) メソッドを使用して、標準スライドが参照していないレイアウトを削除します。このメソッドは、依然として使用中のレイアウトはそのまま残します。

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

特定のレイアウトを削除するには、まずその [has_depending_slides](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutslide/has_depending_slides/) プロパティまたは [get_depending_slides](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutslide/get_depending_slides/) メソッドを使用します。[LayoutSlide.remove](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutslide/remove/) を呼び出す前に、依存スライドを再割り当てしてください。使用中のレイアウトを削除しようとすると、[PptxEditException](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pptxeditexception/) がスローされます。

## **レイアウトスライドでのフッター表示の制御**

レイアウトには独自のフッター、スライド番号、日付時刻プレースホルダーがあります。これらのプレースホルダーを1つのレイアウトだけで制御するには、[LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutslide/header_footer_manager/) プロパティを使用します。たとえば、コンテンツレイアウトはフッターを表示し、タイトルレイアウトは表示しないようにする場合に便利です。

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

マスター階層全体で一貫したフッター設定を適用するには、[MasterSlide.header_footer_manager](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masterslide/header_footer_manager/) プロパティを使用します。[MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ja/python-net/aspose.slides/masterslideheaderfootermanager/) の伝搬メソッドはマスターとその依存レイアウトスライドおよび標準スライドに対して動作し、単一の標準スライドだけを対象にすることはありません。

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

## **FAQ**

**マスタースライドとレイアウトスライドの違いは何ですか？**

マスタースライドはプレゼンテーションのテーマと共有書式を定義します。レイアウトスライドはマスターに属し、再利用可能なプレースホルダー配置を1つ定義します。標準スライドはこれらのレイアウトを使用し、スライド固有のコンテンツを保存します。

**レイアウトスライドを別のプレゼンテーションにコピーできますか？**

はい。目的のコレクションに [add_clone](https://reference.aspose.com/slides/ja/python-net/aspose.slides/globallayoutslidecollection/add_clone/) メソッドでコピーを追加します。プレゼンテーション間でコピーする際は、フォント、テーマ、画像、その他のリソースがソースレイアウトで使用されていることも確認してください。

**既に使用中のレイアウトを変更するとどうなりますか？**

依存スライドはレイアウトの変更を継承しますが、ローカルで書式やオブジェクトを上書きしていない限り、プレースホルダーのジオメトリや継承されたスタイルが多数のスライドで同時に変化します。編集前に [get_depending_slides](https://reference.aspose.com/slides/ja/python-net/aspose.slides/layoutslide/get_depending_slides/) を使用して影響を受けるスライドを特定してください。

**使用中のレイアウトを削除しようとするとどうなりますか？**

Aspose.Slides は [PptxEditException](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pptxeditexception/) をスローします。まず依存スライドを再割り当てるか、[remove_unused_layout_slides](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) を使用して未参照のレイアウトだけを削除してください。