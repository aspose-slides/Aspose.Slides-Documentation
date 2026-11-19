---
title: Pythonでプレゼンテーションハイパーリンクを管理
linktitle: ハイパーリンクの管理
type: docs
weight: 20
url: /ja/python-net/manage-hyperlinks/
keywords:
- URL を追加
- ハイパーリンクを追加
- ハイパーリンクを作成
- ハイパーリンクを書式設定
- ハイパーリンクを削除
- ハイパーリンクを更新
- テキストハイパーリンク
- スライドハイパーリンク
- 図形ハイパーリンク
- 画像ハイパーリンク
- ビデオハイパーリンク
- 可変ハイパーリンク
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用し、Python のサンプルで PowerPoint および OpenDocument プレゼンテーションのハイパーリンクを追加、書式設定、更新、削除します。"
---
## **はじめに**

ハイパーリンクは、プレゼンテーションのコンテンツを Web サイトまたはプレゼンテーション内の場所に接続します。PowerPoint では、ハイパーリンクは通常 2 つの目的で使用されます：

* テキスト、図形、またはメディアフレームから Web サイトを開く。
* 別のスライドへ移動する（例: 目次から）。

Aspose.Slides for Python via .NET を使用すると、これらのリンクを追加し、外観やサウンドを制御し、プロパティを更新し、削除できます。以下の例では、個々の要素上のハイパーリンクの操作方法と、プレゼンテーション、スライド、テキストフレームレベルでハイパーリンクにアクセスする方法を示します。

{{% alert color="info" title="Note" %}}
プレゼンテーションは、[無料のオンライン Aspose PowerPoint エディター](https://products.aspose.app/slides/editor)でも編集できます。
{{% /alert %}}

## **URL ハイパーリンクの追加**

テキスト、図形、またはメディアフレームに Web サイトの URL を割り当てることができます。ハイパーリンクを割り当てた要素がクリック可能領域を決定します。テキストの一部に割り当てた場合は選択されたテキストがリンクとなり、図形やフレームに割り当てた場合はスライドオブジェクト全体がリンクとなります。

相対ハイパーリンクを含むプレゼンテーションについては、[ハイパーリンクベースの管理](/slides/ja/python-net/presentation-properties/#manage-the-hyperlink-base)をご覧ください。

### **テキストへの URL ハイパーリンクの追加**

テキストを Web サイトにリンクするには、下記のようにテキスト部分の [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/hyperlink_click/) プロパティに [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) を割り当てます。テキストのその部分だけがクリック可能になります。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    text_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    text_shape.add_text_frame("Aspose: File Format APIs")
    portion_format = text_shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    portion_format.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    portion_format.font_height = 32
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

### **図形およびメディアフレームへの URL ハイパーリンクの追加**

矩形の [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/shape/hyperlink_click/) プロパティに URL を割り当てると、全領域がクリック可能になります。[tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) は、矩形上にマウスを合わせたときに目的地のヒントを読者に提供します。同じプロパティは画像、音声、ビデオフレームにも適用されます。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **ハイパーリンクを使用した目次の作成**

内部ハイパーリンクを使用すると、読者は目次から特定のスライドへジャンプできます。次の例では、[set_internal_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/) を使用して、最初のスライドの「Page 2」テキストを 2 番目のスライドにリンクしています。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    table_of_contents = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    table_of_contents.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.text_frame.paragraphs.clear()
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "
    link_portion = slides.Portion()
    link_portion.text = "Page 2"
    link_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)
    paragraph.portions.add(link_portion)
    table_of_contents.text_frame.paragraphs.add(paragraph)
    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **ハイパーリンクの書式設定**

リンクされたテキストの色を変更したり、読者がリンクを有効化したときにサウンドを再生または停止したり、ホバー時に表示されるツールチップを設定したりできます。

### **色**

[Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) の [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) プロパティは、ハイパーリンクがプレゼンテーションのハイパーリンク色を使用するかテキスト部分の書式設定を使用するかを決定します。カスタムテキスト色を適用するには、[HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkcolorsource/) を選択し、部分の塗りつぶし色を設定します。この機能は PowerPoint 2019 で導入されました。古いバージョンではこの設定は適用されません。

この例では、最初のリンクの [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) を設定するとテキストが赤く表示されます。2 番目のリンクはプレゼンテーションのハイパーリンク色のままです。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    colored_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 450, 50, False)
    colored_shape.add_text_frame("This hyperlink uses a custom color.")
    colored_portion_format = colored_shape.text_frame.paragraphs[0].portions[0].portion_format
    colored_portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    colored_portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    colored_portion_format.fill_format.fill_type = slides.FillType.SOLID
    colored_portion_format.fill_format.solid_fill_color.color = draw.Color.red
    default_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    default_shape.add_text_frame("This hyperlink uses the default color.")
    default_shape.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    presentation.save("presentation-out-hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

### **サウンド**

ハイパーリンクは、有効化時にサウンドを再生したり、既に再生中のサウンドを停止したりできます。以下のプロパティを使用してこれらの動作を設定します：

[Hyperlink.sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) はハイパーリンクに関連付けられたオーディオを指定します。  
[Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/) はハイパーリンクを有効化したときに前のサウンドを停止するかどうかを制御します。

#### **ハイパーリンクサウンドの追加**

最初のスライドのボタンは、[sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) を使用して、読者がクリックして進むときに WAV ファイルからオーディオを再生します。2 番目のスライドでは、別のボタンが [stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/) を使用して再生を停止し、読者をそのスライドに留めます。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("sampleaudio.wav", "rb") as audio_file:
        audio_data = audio_file.read()
    hyperlink_sound = presentation.audios.add_audio(audio_data)
    first_slide = presentation.slides[0]
    play_button = first_slide.shapes.add_auto_shape(slides.ShapeType.SOUND_BUTTON, 100, 100, 100, 50)
    play_button.hyperlink_click = slides.Hyperlink.next_slide
    if not play_button.hyperlink_click.stop_sound_on_click and play_button.hyperlink_click.sound is None:
        play_button.hyperlink_click.sound = hyperlink_sound

    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    stop_button = second_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 100, 50)
    stop_button.hyperlink_click = slides.Hyperlink.no_action
    stop_button.hyperlink_click.stop_sound_on_click = True
    presentation.save("hyperlink-sound.pptx", slides.export.SaveFormat.PPTX)
```

#### **ハイパーリンクサウンドの抽出**

以下の例では、上記で作成したプレゼンテーションを開き、最初の図形のハイパーリンクオーディオを [sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) と [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/) を介してメモリに読み取ります。

```python
import aspose.slides as slides

with slides.Presentation("hyperlink-sound.pptx") as presentation:
    if len(presentation.slides) > 0 and len(presentation.slides[0].shapes) > 0:
        hyperlink = presentation.slides[0].shapes[0].hyperlink_click
        sound = hyperlink.sound if hyperlink is not None else None
        if sound is not None:
            audio_data = sound.binary_data
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
```

### **ツールチップとインタラクション設定**

テキストまたは図形にハイパーリンクを割り当てた後、以下の [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) プロパティを更新できます：

[tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) は、ビューアがリンクのヒントとして表示できるテキストを設定します。  
[target_frame](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_frame/) は、該当する場合に親 HTML フレームセット内のターゲットフレームを指定します。  
[history](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/history/) は、リンクを有効化したときにその目的地を閲覧済みハイパーリンクのリストに追加するかどうかを制御します。  
[highlight_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/highlight_click/) は、クリック時にハイパーリンクをハイライト表示するかどうかを制御します。

## **プレゼンテーションからハイパーリンクを削除**

[get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) を使用して、テキスト部分のリンクを含むハイパーリンクコンテナを収集し、変更前に取得します。以下の例では、最初のスライドから両方の有効化タイプを削除します。1 つのタイプだけを削除する場合は、[remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) または [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/) のみを呼び出します。クリックアクションを削除しても、マウスオーバーの対応は削除されません。

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    if len(presentation.slides) > 0:
        containers = list(presentation.slides[0].hyperlink_queries.get_any_hyperlinks())
        for container in containers:
            container.hyperlink_manager.remove_hyperlink_click()
            container.hyperlink_manager.remove_hyperlink_mouse_over()
        presentation.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The presentation has no slides to process.")
```

無条件に削除する場合は、[remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) が選択したスコープ内の両方の有効化タイプを 1 回の呼び出しで削除します。選択的なクリーンアップやマスター、レイアウト、ノートのカバレッジについては、[Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) を参照してください。

### **SmartArt テキスト置換前のハイパーリンククリア**

既存の SmartArt ノードの段落を置換する際、テキスト部分をクリアすると古いハイパーリンクが残る可能性があります。[SmartArtNode.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/text_frame/) を使用して段落を取得します。部分をクリアする前に、その段落を表示するノード形状のテキストフレーム上で [hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/) を介して [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) を呼び出します。これにより、そのフレーム内のすべてのハイパーリンクが削除され、他の段落にあるリンクも含まれます。

`SmartArtHyperlink.pptx` では、最初のスライドの 3 番目の図形が SmartArt グラフィックです。この例では、4 番目のノードの最初の段落を置換します。このプレゼンテーションでは、ノードの最初の図形がその段落を表示しています。

両方の部分を追加した後、例では [get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) を使用して有効な書式設定を読み取ります。有効な [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/iportionformateffectivedata/hyperlink_click/) プロパティは、最初の部分に新しいハイパーリンクを返し、2 番目の部分には `None` を返します。

```python
import aspose.slides as slides

with slides.Presentation("SmartArtHyperlink.pptx") as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes[2]
    node = smart_art.all_nodes[3]
    paragraph = node.text_frame.paragraphs[0]

    node.shapes[0].text_frame.hyperlink_queries.remove_all_hyperlinks()
    paragraph.portions.clear()

    link = slides.Portion("New reference")
    link.portion_format.hyperlink_click = slides.Hyperlink("https://example.com/new")
    paragraph.portions.add(link)
    text = slides.Portion(" (updated)")
    paragraph.portions.add(text)

    print(link.portion_format.get_effective().hyperlink_click.external_url)  # https://example.com/new
    print(text.portion_format.get_effective().hyperlink_click)  # None
```

## **完全なハイパーリンクインベントリの作成**

プレゼンテーションを配布する前に、インタラクティブなアクションと Web リンクのインベントリを作成します。[get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) は URL 文字列のフラットリストではなく、[IHyperlinkContainer](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/) オブジェクトを返します。各コンテナの [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) と [hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) の両方を検査します。これらは独立しており、同じコンテナが両方のアクションを持つことがあるため、完全なレポートではコンテナごとに最大 2 行が必要です。

形状レベルのハイパーリンクだけをスキャンすると、テキスト部分に付随するリンクが見逃される可能性があります。代わりに適切なスコープをクエリし、返されたコンテナを保持して、後でアクションを更新または削除できるようにします。

### **プレゼンテーション、スライド、テキストフレームのスコープをクエリ**

[HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) クラスは、[Presentation.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/hyperlink_queries/)、[BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/hyperlink_queries/)、および [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/) から利用できます。各スコープは同じクエリをサポートします：

[get_hyperlink_clicks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) はクリックアクションを持つコンテナを返します。  
[get_hyperlink_mouse_overs](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) はマウスオーバーアクションを持つコンテナを返します。  
[get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) はいずれか、または両方のアクションを持つコンテナを返します。

この例では、図形とそのテキストにクリックとマウスオーバーのアクションを割り当て、別のボタンにマクロアクションを割り当てます。[get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) が返すコンテナを各有効化タイプの数と比較します。テキストフレームのクエリはテキスト内のリンクのみをカウントします。囲む図形自身のアクションはスライドとプレゼンテーションのクエリに表示されます。

```python
import aspose.slides as slides


def print_counts(scope, queries):
    click_containers = queries.get_hyperlink_clicks()
    mouse_over_containers = queries.get_hyperlink_mouse_overs()
    all_containers = queries.get_any_hyperlinks()
    print(f"{scope}: click={len(click_containers)}, mouse-over={len(mouse_over_containers)}, any={len(all_containers)}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    destination = presentation.slides.add_empty_slide(slide.layout_slide)
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Click the text to go to slide 2"
    shape.hyperlink_manager.set_external_hyperlink_click("https://example.com/")
    shape.hyperlink_click.tooltip = "Public website"
    shape.hyperlink_manager.set_external_hyperlink_mouse_over("file:///C:/private/report.xlsx")

    portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_manager.set_internal_hyperlink_click(destination)
    portion_format.hyperlink_manager.set_external_hyperlink_mouse_over("https://example.com/help")
    macro_button = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 120, 200, 60)
    macro_button.hyperlink_manager.set_macro_hyperlink_click("ReviewPresentation")

    print_counts("Presentation", presentation.hyperlink_queries)
    print_counts("Slide 1", slide.hyperlink_queries)
    print_counts("Text frame", shape.text_frame.hyperlink_queries)
    presentation.save("hyperlink-audit-input.pptx", slides.export.SaveFormat.PPTX)
```

この例では、プレゼンテーションとスライドのクエリはそれぞれ、クリックコンテナが 3 件、マウスオーバーコンテナが 2 件、いずれかのアクションを持つコンテナが 3 件と報告します。テキストフレームのクエリは各カテゴリで 1 件のコンテナを報告します。

### **アクションと目的地の分類**

[Hyperlink.action_type](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/action_type/) を使用して、目的地を解釈する前にアクションを解釈します。[HyperlinkActionType](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkactiontype/) の値は Web ナビゲーション以上のものをカバーします：

| 値 | 監査時の意味 |
| --- | --- |
| `HYPERLINK` | 外部ハイパーリンク; URL とそのスキームを検査します。 |
| `JUMP_SPECIFIC_SLIDE` | 特定のスライドへの内部ナビゲーション。 |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | スライドショー内で解決される組み込みのスライドショーナビゲーション。 |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | 現在のショーを終了するか、カスタムショーを開始します。 |
| `START_MACRO` | マクロを実行します。 |
| `START_PROGRAM` | プログラムを起動します。 |
| `OPEN_FILE`, `OPEN_PRESENTATION` | ファイルまたは別のプレゼンテーションを開きます; Web URL とは別に確認します。 |
| `START_STOP_MEDIA` | メディアの再生を開始または停止します。 |
| `NO_ACTION`, `UNKNOWN` | ナビゲーションアクションがない、または未確認のアクションでレビューが必要です。 |

外部の目的地は [external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) から、特定の内部目的地は [target_slide](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_slide/) から取得します。内部アクションや組み込みコマンドは外部 URL を持たない場合があります。空の URL はコンテナにアクションがないことを意味しません。[external_url_original](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url_original/) が正規化された URL と異なる場合は保持し、利用可能な場合は [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) を含めます。

### **ハイパーリンクのレポート、サニタイズ、検証**

この例では、前の例のプレゼンテーションを開き、アクションごとに 1 つの JSON レコードを書き出します。[get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) を使用して、通常のスライド、マスター、レイアウト、ノート上のコンテナを収集します（ノートとハンドアウトマスターが存在する場合も含む）。重複処理を避けるために各スコープを一度だけクエリし、以下のポリシーを適用し、保存したプレゼンテーションを再度開いてクリックとマウスオーバーの両方のアクションをチェックします。

レポートは、1 から始まるスライドインデックスと、利用可能な場合は [slide_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/slide_id/) を記録します。コレクターは、各返されたコンテナとともに所有スライドとスコープを保持します。マスター、レイアウト、ノートには通常のスライドインデックスがなく、スコープで識別されます。形状コンテナとテキスト部分の書式コンテナは別々にラベル付けされ、他のコンテナタイプはランタイム型名を保持します。各コンテナにはレポート内ローカル ID が付与され、2 つのアクションを関連付けられます。

この意図的に制限的なアプリケーションポリシーは、絶対的な HTTPS URL と有効な内部スライドターゲットのみを許可します。マクロ、プログラム、ファイルアクション、その他のスライドショーアクション、未確認のアクション、その他の URL スキームは拒否されます。これらの拒否はポリシー上の決定であり、Aspose.Slides の安全性判定ではありません。HTTPS だけでは信頼を確立できないため、ホストの許可リストやその他のチェックをアプリケーションに追加してください。元の URL と正規化された外部 URL の両方がチェックされます。例ではリンクをたどったりアクションを実行したりせずにメタデータを監査します。

対策として、コンテナの [hyperlink_manager](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) は [set_external_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/)、[remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/)、[remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/) をサポートします。ここでは、禁止された外部クリックリンクは固定の HTTPS ランディングページに置き換えられ、他の禁止されたクリックと禁止されたマウスオーバーアクションは個別に削除されます。すべてのポリシー違反を削除するには `replace_external_clicks` を `False` に設定します。展開前にアプリケーション所有の置換ページを選択してください。

レポートのエクスポートフラグは保守的な PDF レビュー ポリシーを使用します：マウスオーバーアクションや外部リンクや特定スライドジャンプ以外のものは潜在的にサポートされていないとフラグ付けします。これはレビューのヒントであり、機能テストやフラグが付いていないリンクがエクスポートで残る保証ではありません。サポートされている [PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/) と [HTML](/slides/ja/python-net/convert-powerpoint-to-html/) エクスポートは、アクション、エクスポートオプション、ビューアに依存してハイパーリンクを保持する場合があります。ラスタ画像 [images](/slides/ja/python-net/convert-powerpoint-to-png/) と [video](/slides/ja/python-net/convert-powerpoint-to-video/) はインタラクティブハイパーリンクを保持できませんので、これらの出力を監査する際はすべてのアクションにフラグを付けてください。

```python
import json
import sys
from urllib.parse import urlsplit
import aspose.slides as slides


def is_https(value):
    if not value or any(character.isspace() for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.action_type == slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE:
        return "Missing target slide" if link.target_slide is None else None
    if link.action_type != slides.HyperlinkActionType.HYPERLINK:
        return "Action is not allowed"
    if not is_https(link.external_url):
        return "Normalized URL is not absolute HTTPS"
    original = link.external_url_original
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def slide_index(presentation, slide):
    if slide is not None:
        for index, candidate in enumerate(presentation.slides, start=1):
            if candidate.slide_id == slide.slide_id:
                return index
    return None


def collect_containers(presentation):
    # 各スライドのスコープを一度だけクエリし、各コンテナに所有者を保持します。
    scopes = [("Slide", slide) for slide in presentation.slides]
    scopes.extend(("Master", master) for master in presentation.masters)
    scopes.extend(("Layout", layout) for layout in presentation.layout_slides)
    scopes.extend(("Notes", slide.notes_slide_manager.notes_slide) for slide in presentation.slides)
    scopes.append(("Notes master", presentation.master_notes_slide_manager.master_notes_slide))
    scopes.append(("Handout master", presentation.master_handout_slide_manager.master_handout_slide))
    found = []
    for scope, owner in scopes:
        if owner is not None:
            containers = list(owner.hyperlink_queries.get_any_hyperlinks())
            found.extend((container, scope, owner) for container in containers)
    return found


def add_row(rows, presentation, link, activation, container, container_id, scope, owner):
    if link is None:
        return
    target_slide = link.target_slide
    violation = policy_violation(link)
    if isinstance(container, slides.Shape):
        owner_type = "Shape"
    elif isinstance(container, slides.PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = type(container).__name__
    ordinary_action = link.action_type in (slides.HyperlinkActionType.HYPERLINK, slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE)
    original_url = link.external_url_original if link.external_url_original != link.external_url else None
    rows.append({
        "container_id": container_id,
        "slide_index": slide_index(presentation, owner) if scope == "Slide" else None,
        "slide_id": owner.slide_id,
        "scope": scope,
        "owner_type": owner_type,
        "activation": activation,
        "action_type": link.action_type.name,
        "external_url": link.external_url,
        "target_slide_index": slide_index(presentation, target_slide),
        "target_slide_id": target_slide.slide_id if target_slide is not None else None,
        "tooltip": link.tooltip,
        "original_external_url": original_url,
        "potentially_unsafe": violation is not None,
        "policy_violation": violation,
        "target_export": "PDF",
        "potentially_unsupported_by_export": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"

with slides.Presentation("hyperlink-audit-input.pptx") as presentation:
    containers = collect_containers(presentation)
    rows = []
    for container_id, (container, scope, owner) in enumerate(containers, start=1):
        add_row(rows, presentation, container.hyperlink_click, "click", container, container_id, scope, owner)
        add_row(rows, presentation, container.hyperlink_mouse_over, "mouse-over", container, container_id, scope, owner)

    with open("hyperlink-audit.json", "w", encoding="utf-8") as report_file:
        json.dump(rows, report_file, indent=2)

    for container, scope, owner in containers:
        click = container.hyperlink_click
        if policy_violation(click) is not None:
            if replace_external_clicks and click.action_type == slides.HyperlinkActionType.HYPERLINK:
                container.hyperlink_manager.set_external_hyperlink_click(replacement_url)
            else:
                container.hyperlink_manager.remove_hyperlink_click()
        if policy_violation(container.hyperlink_mouse_over) is not None:
            container.hyperlink_manager.remove_hyperlink_mouse_over()

    presentation.save("hyperlink-sanitized.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlink-sanitized.pptx") as reopened:
    remaining_containers = collect_containers(reopened)
    violations = 0
    for container, scope, owner in remaining_containers:
        if policy_violation(container.hyperlink_click) is not None:
            violations += 1
        if policy_violation(container.hyperlink_mouse_over) is not None:
            violations += 1
    print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
    if violations != 0:
        print("Verification failed: do not distribute the saved presentation.")
        sys.exit(1)
```

上記で作成した入力に対して、レポートには 5 行のアクションが含まれます。ファイルのマウスオーバーリンクとマクロクリックは削除され、HTTPS リンクと内部スライドナビゲーションは残ります。検証では禁止されたアクションは 0 件と出力されます。禁止された外部クリック URL を含む入力でも置換分岐が実行されます。許可されたクリックと禁止されたマウスオーバーを持つコンテナはクリックアクションを保持します。

この選択的クリーンアップは、ポリシーに関係なく選択されたスコープ全体の両方の有効化タイプを削除する [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) とは異なります。ここでの検証はハイパーリンクアクションのみをチェックし、埋め込まれた VBA プロジェクト、OLE オブジェクト、その他のアクティブコンテンツは削除せず、エクスポートされた PDF や HTML ファイルの検証も行いません。

## **FAQ**

**セクションまたはその最初のスライドにリンクするにはどうすればよいですか？**

PowerPoint のセクションはスライドをグループ化しますが、内部ハイパーリンクは個々のスライドを対象にします。セクションへのナビゲーションを作成するには、そのセクションの最初のスライドにリンクしてください。

**マスタースライド要素にハイパーリンクを付けてすべてのスライドで機能させることはできますか？**

はい。マスタースライドおよびレイアウト要素はハイパーリンクをサポートします。これらの要素上のリンクは、対応するマスターまたはレイアウトを使用するスライドのスライドショー中に利用可能です。

**PDF、HTML、画像、ビデオへのエクスポート時にハイパーリンクは保持されますか？**

サポートされている PDF と HTML のエクスポートはハイパーリンクを保持する可能性がありますが、ラスタ画像とビデオは保持できません。エクスポート時の考慮事項は [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) を参照してください。