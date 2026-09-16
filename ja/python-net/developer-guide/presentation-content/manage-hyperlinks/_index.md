---
title: Python でプレゼンテーションのハイパーリンクを管理する
linktitle: ハイパーリンクの管理
type: docs
weight: 20
url: /ja/python-net/manage-hyperlinks/
keywords:
- URL の追加
- ハイパーリンクの追加
- ハイパーリンクの作成
- ハイパーリンクの書式設定
- ハイパーリンクの削除
- ハイパーリンクの更新
- テキストハイパーリンク
- スライドハイパーリンク
- 図形ハイパーリンク
- 画像ハイパーリンク
- 動画ハイパーリンク
- 可変ハイパーリンク
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Python 用 Aspose.Slides for .NET を使用し、Python のサンプルで PowerPoint および OpenDocument プレゼンテーションのハイパーリンクを追加、書式設定、更新、削除します。"
---
## **はじめに**

ハイパーリンクは、プレゼンテーションの内容をウェブサイトやプレゼンテーション内の場所に接続します。PowerPoint では、ハイパーリンクは主に次の 2 つの目的で使用されます。

* テキスト、図形、またはメディア フレームからウェブサイトを開く。
* 目次などから別のスライドへ移動する。

Aspose.Slides for Python via .NET を使用すると、これらのリンクを追加し、外観やサウンドを制御し、プロパティを更新し、削除できます。以下の例は、個々の要素に対するハイパーリンクの操作方法と、プレゼンテーション、スライド、テキスト フレーム レベルでハイパーリンクにアクセスする方法を示しています。

{{% alert color="info" title="Note" %}}
プレゼンテーションは、[無料のオンライン Aspose PowerPoint エディター](https://products.aspose.app/slides/ja/editor)でも編集できます。
{{% /alert %}}

## **URL ハイパーリンクの追加**

テキスト、図形、またはメディア フレームにウェブサイトの URL を割り当てることができます。ハイパーリンクを割り当てる要素に応じてクリック可能領域が決まります。テキスト部分に割り当てた場合は選択したテキストが、図形やフレームに割り当てた場合はスライド オブジェクト全体がクリック可能になります。

### **テキストへの URL ハイパーリンクの追加**

テキストをウェブサイトにリンクするには、テキスト部分の [hyperlink_click](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portionformat/hyperlink_click/) プロパティに [Hyperlink](https://reference.aspose.com/slides/ja/python-net/aspose.slides/hyperlink/) を割り当てます。以下の例のように、対象となるテキスト部分だけがクリック可能になります。

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

### **図形およびメディア フレームへの URL ハイパーリンクの追加**

図形やフレームをクリック可能にするには、その [hyperlink_click](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/hyperlink_click/) プロパティを設定します。ハイパーリンクはテキスト部分ではなく、オブジェクト自体に属します。

画像、音声、動画フレームにも同様に適用できます。必要に応じてリンクの [tooltip](https://reference.aspose.com/slides/ja/python-net/aspose.slides/hyperlink/tooltip/) を設定してください。

以下の例は、長方形をクリック可能にします。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **ハイパーリンクを使用した目次の作成**

内部ハイパーリンクを使用すると、目次から特定のスライドへジャンプできます。次の例では、[set_internal_hyperlink_click](https://reference.aspose.com/slides/ja/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/) を使って、最初のスライドの “Page 2” テキストを 2 番目のスライドにリンクしています。

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

### **色**

[Hyperlink](https://reference.aspose.com/slides/ja/python-net/aspose.slides/hyperlink/) の [color_source](https://reference.aspose.com/slides/ja/python-net/aspose.slides/hyperlink/color_source/) プロパティは、ハイパーリンクがプレゼンテーション全体のハイパーリンク色を使用するか、テキスト部分の書式設定を使用するかを決定します。カスタム テキスト色を適用するには、[HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/ja/python-net/aspose.slides/hyperlinkcolorsource/) を選択し、部分の塗りつぶし色を設定します。この機能は PowerPoint 2019 で導入され、古いバージョンでは適用されません。

以下の例では、同じスライドに 2 つのテキスト ハイパーリンクを追加しています。1 つ目は赤いテキスト塗りつぶし、2 つ目はデフォルトのハイパーリンク色を使用します。

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

ハイパーリンクは、アクティブ化時にサウンドを再生したり、既に再生中のサウンドを停止したりできます。以下のプロパティでこれらの動作を設定します。

- [Hyperlink.sound](https://reference.aspose.com/slides/ja/python-net/aspose.slides/hyperlink/sound/) はハイパーリンクに関連付けられたオーディオを指定します。
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/ja/python-net/aspose.slides/hyperlink/stop_sound_on_click/) は、ハイパーリンクをアクティブ化したときに前のサウンドを停止するかどうかを制御します。

#### **ハイパーリンク サウンドの追加**

以下の例は `sampleaudio.wav` を読み込み、最初のスライドのボタンに関連付けます。ボタンをクリックするとサウンドが再生され、次のスライドへ移動します。同じスライド上の別の図形は、クリック時に前のサウンドを停止し、ナビゲーションは行いません。

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

#### **ハイパーリンク サウンドの抽出**

以下の例は、先ほど作成したプレゼンテーションを開き、最初の図形のハイパーリンク オーディオを [sound](https://reference.aspose.com/slides/ja/python-net/aspose.slides/hyperlink/sound/) と [binary_data](https://reference.aspose.com/slides/ja/python-net/aspose.slides/audio/binary_data/) を介してメモリに読み取ります。

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

テキストまたは図形にハイパーリンクを割り当てた後、次の [Hyperlink](https://reference.aspose.com/slides/ja/python-net/aspose.slides/hyperlink/) プロパティを更新できます。

- [tooltip](https://reference.aspose.com/slides/ja/python-net/aspose.slides/hyperlink/tooltip/) は、リンクのヒントとして表示できるテキストを設定します。
- [target_frame](https://reference.aspose.com/slides/ja/python-net/aspose.slides/hyperlink/target_frame/) は、該当する場合に親 HTML フレームセット内のターゲット フレームを指定します。
- [history](https://reference.aspose.com/slides/ja/python-net/aspose.slides/hyperlink/history/) は、リンクをアクティブ化したときに閲覧履歴に追加するかどうかを制御します。
- [highlight_click](https://reference.aspose.com/slides/ja/python-net/aspose.slides/hyperlink/highlight_click/) は、クリック時にハイパーリンクをハイライト表示するかどうかを制御します。

## **プレゼンテーションからハイパーリンクを削除する**

変更前にテキスト部分リンクを含むハイパーリンク コンテナを収集するには、[get_any_hyperlinks](https://reference.aspose.com/slides/ja/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) を使用します。以下の例は、最初のスライドから両方のアクティベーション タイプ（クリックとマウスオーバー）を削除します。片方だけを削除したい場合は、[remove_hyperlink_click](https://reference.aspose.com/slides/ja/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) または [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/ja/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/) のみを呼び出してください。クリック アクションを削除しても、マウスオーバー対応は残ります。

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

条件なしで削除する場合は、[remove_all_hyperlinks](https://reference.aspose.com/slides/ja/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) が選択したスコープ内の両方のアクティベーション タイプを一度に削除します。マスター、レイアウト、ノートを含む選択的クリーンアップについては、[Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) を参照してください。

## **ハイパーリンク インベントリの作成**

プレゼンテーションを配布する前に、インタラクティブ アクションとウェブ リンクのインベントリを作成します。[get_any_hyperlinks](https://reference.aspose.com/slides/ja/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) は [IHyperlinkContainer](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ihyperlinkcontainer/) オブジェクトを返します。これは URL 文字列のフラットなリストではありません。各コンテナの [hyperlink_click](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) と [hyperlink_mouse_over](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) を調べます。両方のアクションを持つコンテナもあるため、完全なレポートにはコンテナごとに最大 2 行が必要です。

図形レベルのハイパーリンクだけをスキャンすると、テキスト部分に付随したリンクが見落とされる可能性があります。適切なスコープでクエリを実行し、返されたコンテナを保持して後からアクションを更新または削除できるようにしてください。

### **プレゼンテーション、スライド、テキスト フレーム スコープのクエリ**

[HyperlinkQueries](https://reference.aspose.com/slides/ja/python-net/aspose.slides/hyperlinkqueries/) クラスは、[Presentation.hyperlink_queries](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/hyperlink_queries/)、[BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/ja/python-net/aspose.slides/baseslide/hyperlink_queries/)、[TextFrame.hyperlink_queries](https://reference.aspose.com/slides/ja/python-net/aspose.slides/textframe/hyperlink_queries/) から利用できます。各スコープは同じクエリをサポートします。

- [get_hyperlink_clicks](https://reference.aspose.com/slides/ja/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) はクリック アクションを持つコンテナを返します。
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/ja/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) はマウスオーバー アクションを持つコンテナを返します。
- [get_any_hyperlinks](https://reference.aspose.com/slides/ja/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) はいずれか、または両方のアクションを持つコンテナを返します。

以下の例は、外部クリックリンク、ファイルマウスオーバーリンク、内部スライド ナビゲーション、テキストマウスオーバーリンク、マクロ アクションを含む `hyperlink-audit-input.pptx` を作成します。これらのアクションは実行されません。3 つのクエリはすべてのスコープで同様に機能し、カウントはコンテナ数を示します。テキスト フレーム スコープは、囲んでいる図形のリンクは除外します。

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

この例では、プレゼンテーションとスライドのクエリはそれぞれクリック コンテナが 3 件、マウスオーバー コンテナが 2 件、いずれかのアクションを持つコンテナが 3 件報告します。テキスト フレーム クエリは各カテゴリで 1 件ずつ報告します。

### **アクションと宛先の分類**

[Hyperlink.action_type](https://reference.aspose.com/slides/ja/python-net/aspose.slides/hyperlink/action_type/) を使用して、宛先を解釈する前にアクションの種類を判断します。[HyperlinkActionType](https://reference.aspose.com/slides/ja/python-net/aspose.slides/hyperlinkactiontype/) の値はウェブ ナビゲーション以外にも次のような種類があります。

| 値 | 監査時の意味 |
| --- | --- |
| `HYPERLINK` | 外部ハイパーリンク。URL とスキームを確認 |
| `JUMP_SPECIFIC_SLIDE` | 特定スライドへの内部ナビゲーション |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | スライドショー内の組み込みナビゲーション |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | 現在のショーを終了またはカスタムショーを開始 |
| `START_MACRO` | マクロを実行 |
| `START_PROGRAM` | プログラムを起動 |
| `OPEN_FILE`, `OPEN_PRESENTATION` | ファイルまたは別のプレゼンテーションを開く（ウェブ URL とは別に確認） |
| `START_STOP_MEDIA` | メディア再生の開始・停止 |
| `NO_ACTION`, `UNKNOWN` | ナビゲーション アクションがない、または未認識のアクション（要確認） |

外部宛先は [external_url](https://reference.aspose.com/slides/ja/python-net/aspose.slides/hyperlink/external_url/) から、特定の内部宛先は [target_slide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/hyperlink/target_slide/) から取得します。内部アクションや組み込みコマンドには外部 URL が存在しない場合があります。空の URL がコンテナにアクションがないことを意味するわけではありません。正規化された URL と異なる場合は [external_url_original](https://reference.aspose.com/slides/ja/python-net/aspose.slides/hyperlink/external_url_original/) を保持し、利用可能な場合は [tooltip](https://reference.aspose.com/slides/ja/python-net/aspose.slides/hyperlink/tooltip/) も含めます。

### **ハイパーリンクのレポート、サニタイズ、検証**

以下の Python 例は既存のプレゼンテーション（上記で作成したファイル）を読み取り、`hyperlink-audit.json` を書き出し、ポリシーを適用して `hyperlink-sanitized.pptx` を保存し、再度開いて両方のアクティベーション タイプをチェックします。変更前にコンテナを収集し、各スライド スコープを 1 回だけクエリして重複処理を防ぎます。プレゼンテーション クエリは通常スライドを対象とし、パッケージ全体のインベントリが必要な場合は、通常スライド、マスター、レイアウト、ノート、ノート/配布マスターも対象にします。

レポートは 1 ベースのスライド インデックスと利用可能な場合は [slide_id](https://reference.aspose.com/slides/ja/python-net/aspose.slides/baseslide/slide_id/) を記録します。コレクタは所有スライドとスコープを各コンテナに保持します。マスター、レイアウト、ノートは通常スライド インデックスがないため、スコープで識別されます。図形コンテナとテキスト 部分の書式コンテナは別々にラベル付けされ、他のコンテナ型はランタイムの型名を保持します。各コンテナにはレポート内でローカル ID が付与され、2 つのアクションを相関付けできます。

このポリシーは、絶対 HTTPS URL と有効な内部スライド ターゲットのみを許可し、マクロ、プログラム、ファイル アクション、その他のスライドショー アクション、未知のアクション、その他の URL スキームは拒否します。これらの拒否はポリシー上の決定であり、Aspose.Slides の安全性判定ではありません。HTTPS だけでは信頼が確立されないため、ホスト許可リストやその他のチェックを追加してください。元の URL と正規化後の URL の両方がチェック対象です。例はリンクをたどったりアクションを実行したりせず、メタデータのみを監査します。

修正のために、コンテナの [hyperlink_manager](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) は [set_external_hyperlink_click](https://reference.aspose.com/slides/ja/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/)、[remove_hyperlink_click](https://reference.aspose.com/slides/ja/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/)、[remove_hyperlink_mouse_over](https://reference.aspose.com/slides/ja/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/) をサポートします。ここでは、禁止された外部クリックリンクを固定の HTTPS ランディング ページに置き換え、他の禁止クリックと禁止マウスオーバーは個別に削除します。`replace_external_clicks` を `False` に設定すると、すべてのポリシー違反を削除します。導入前にアプリケーション所有の置換ページを用意してください。

レポートのエクスポート フラグは保守的な PDF レビュー ポリシーを使用します：マウスオーバー アクションや外部リンク以外、特定スライド ジャンプ以外のものは「サポートされていない可能性あり」とフラグ付けします。これはレビューのヒントであり、機能テストやフラグが付いていないリンクがエクスポートで保持される保証ではありません。サポートされている [PDF](/slides/ja/python-net/convert-powerpoint-to-pdf/) と [HTML](/slides/ja/python-net/convert-powerpoint-to-html/) エクスポートは、アクション、エクスポート オプション、ビューアに応じてハイパーリンクを保持できる場合があります。ラスター [images](/slides/ja/python-net/convert-powerpoint-to-png/) と [video](/slides/ja/python-net/convert-powerpoint-to-video/) はインタラクティブ ハイパーリンクを保持できないため、これらの出力を監査するときはすべてのアクションにフラグを付けてください。

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
    # 各スライド スコープを一度だけクエリし、各コンテナに所有者を保持します。
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

上記の入力で作成したレポートは 5 行のアクションを含みます。ファイル マウスオーバー リンクとマクロ クリックは削除され、HTTPS リンクと内部スライド ナビゲーションは残ります。検証は禁止アクションが 0 件であることを出力します。禁止された外部クリック URL を含む入力は置換ブランチを実行します。許可されたクリックと禁止されたマウスオーバーを持つコンテナはクリック アクションを保持します。

この選択的クリーンアップは、[remove_all_hyperlinks](https://reference.aspose.com/slides/ja/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) がポリシーに関係なく選択したスコープ全体の両方のアクティベーション タイプを削除するものとは異なります。ここでの検証はハイパーリンク アクションのみをチェックし、埋め込み VBA プロジェクト、OLE オブジェクト、その他のアクティブ コンテンツの削除や、エクスポートされた PDF や HTML ファイルの検証は行いません。

## **FAQ**

**セクションやその最初のスライドへリンクするにはどうすればよいですか？**

PowerPoint のセクションはスライドをグループ化しますが、内部ハイパーリンクは個々のスライドを対象にします。セクションへ移動するには、そのセクションの最初のスライドへリンクしてください。

**マスター スライドの要素にハイパーリンクを付けて、すべてのスライドで機能させることはできますか？**

はい。マスター スライドやレイアウトの要素はハイパーリンクをサポートします。これらの要素に付けたリンクは、対応するマスターまたはレイアウトを使用するスライドのショー時に利用可能です。

**PDF、HTML、画像、ビデオへエクスポートする際にハイパーリンクは保持されますか？**

サポートされている PDF および HTML エクスポートはハイパーリンクを保持できる場合がありますが、ラスタ画像やビデオは保持できません。詳細は [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) のエクスポートに関する考慮事項をご参照ください。