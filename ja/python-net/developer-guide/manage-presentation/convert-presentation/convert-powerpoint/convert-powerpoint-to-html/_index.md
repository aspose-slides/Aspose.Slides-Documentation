---
title: Python で PowerPoint プレゼンテーションを HTML に変換
linktitle: PowerPoint を HTML に変換
type: docs
weight: 30
url: /ja/python-net/convert-powerpoint-to-html/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を HTML に変換
- プレゼンテーションを HTML に変換
- スライドを HTML に変換
- PPT を HTML に変換
- PPTX を HTML に変換
- PowerPoint を HTML として保存
- プレゼンテーションを HTML として保存
- スライドを HTML として保存
- PPT を HTML として保存
- PPTX を HTML として保存
- PPT を HTML にエクスポート
- PPTX を HTML にエクスポート
- Python
- Aspose.Slides
description: "Python で PowerPoint プレゼンテーションを HTML に変換します。Aspose.Slides を使用して PPT および PPTX ファイル、選択したスライド、ノート、フォント、画像、SVG、メディアをエクスポートできます。"
---
## **概要**

Aspose.Slides for Python via .NET は、Microsoft PowerPoint を使用せずに PowerPoint プレゼンテーションを HTML として保存できます。基本的な変換は、[Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) をロードし、[SaveFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/saveformat/) を使用して `save` を呼び出すだけです。エクスポートするレイアウト、フォント、画像、ノート、コメント、SVG 出力、またはリンクされたリソースを制御する必要がある場合は、[HtmlOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/htmloptions/) を使用します。

このガイドでは、実用的な HTML エクスポートシナリオに焦点を当てます。

- プレゼンテーション全体または選択したスライドをエクスポートします。
- 固定レイアウト、レスポンシブ、または SVG ベースの HTML を生成します。
- スピーカーノートとコメントを含めます。
- 画像品質と切り抜かれた画像データを制御します。
- フォントを埋め込むか、フォントファイルを別々に保存します。
- 外部リソースとメディアファイルの書き込み方法と参照方法を選択します。

デフォルトでは、HTML エクスポートはほとんどのリソースが埋め込まれた自己完結型 HTML ドキュメントを生成します。1つのファイルで共有できる便利さがありますが、出力サイズが大きくなる可能性があります。Web 公開の場合は、外部リソースの使用、画像 DPI の低減、そしてターゲット環境で確実に利用できないフォントのみを埋め込むことを検討してください。

## **プレゼンテーションをHTMLに変換**

プレゼンテーションを HTML にエクスポートするには、[Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) でロードし、[SaveFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/saveformat/) で保存します。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.html", slides.export.SaveFormat.HTML)
```

この例は 1 つの HTML ファイルを書き込みます。`with` 文はエクスポート後にプレゼンテーション オブジェクトを破棄し、ファイル ハンドルとレンダリング リソースを解放します。

## **HtmlOptions の使用**

[HtmlOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/htmloptions/) は HTML エクスポート用の主要な構成クラスです。一般的な設定は次のとおりです。

- `slides_layout_options`: ノート、コメント、ハンドアウト、またはその他のレイアウト情報を追加します。
- `html_formatter`: HTML ドキュメントの構造を変更したり、フォーマットをコントローラに委譲したりします。
- `slide_image_format`: スライドの表現方法を変更します。例として SVG があります。
- `pictures_compression`: 画像の DPI と出力サイズを制御します。
- `delete_pictures_cropped_areas`: 切り抜き画像データを保持または削除します。
- `svg_responsive_layout`: エクスポートされた SVG コンテンツがコンテナに適応するようにします。
- `show_hidden_slides`: 必要に応じて非表示スライドを含めます。

以下のセクションでは、最も一般的なオプションを個別に示すので、ワークフローに必要なものだけを組み合わせて使用できます。

## **選択したスライドをHTMLに変換**

スライド番号を受け取る `save` のオーバーロードは 1 ベースのスライド位置を使用します。以下のループは各スライドを別々の HTML ファイルに保存します。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide_count = len(presentation.slides)

    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = [slide_number]
        html_file_name = "slide-{}.html".format(slide_number)

        presentation.save(html_file_name, slide_numbers, slides.export.SaveFormat.HTML)
```

ウェブサイトやアプリケーションでスライドごとに 1 つの HTML ページが必要な場合にこのパターンを使用します。各スライドが同じレイアウトである必要がある場合は、1 つの [HtmlOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/htmloptions/) インスタンスを作成し、各 `save` 呼び出しに渡します。

## **レスポンシブHTMLの作成**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/responsivehtmlcontroller/) は [HtmlFormatter](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/htmlformatter/) を通じてレスポンシブ HTML 出力を提供します。エクスポートされたページがブラウザ幅により適応する必要がある場合に使用します。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    controller = slides.export.ResponsiveHtmlController()
    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

SVG ベースのレスポンシブレイアウトの場合は、[HtmlOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/htmloptions/) の `svg_responsive_layout` を設定します。スライド コンテンツが拡張可能な SVG マークアップとしてエクスポートされる場合に便利です。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.svg_responsive_layout = True

    presentation.save("presentation-svg-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

## **スピーカーノートとコメントを含める**

`html_options.slides_layout_options` を介して [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/notescommentslayoutingoptions/) を使用し、スピーカーノートまたはコメントを含めます。ノートとコメントはデフォルトで非表示です。位置を指定しない限り表示されません。

元のプレゼンテーションにスピーカーノートが含まれていると仮定します。

![PowerPoint のスライドにスピーカーノートがある](slide_with_notes.png)

以下のコードはスライドコンテンツをスライドの下にスピーカーノートを付けてエクスポートします。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    layout_options = slides.export.NotesCommentsLayoutingOptions()
    layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    html_options = slides.export.HtmlOptions()
    html_options.slides_layout_options = layout_options

    presentation.save("presentation-with-notes.html", slides.export.SaveFormat.HTML, html_options)
```

エクスポートされた HTML にはノート領域が含まれます。

![スライドとスピーカーノートを含むHTML出力](HTML_with_notes.png)

コメントをエクスポートするには、`comments_position` を設定します。例: `CommentsPositions.RIGHT` または `CommentsPositions.BOTTOM`。コメントだけが必要な場合は `notes_position` を省略してください。ノートとコメントの両方が必要な場合は、両方のプロパティを設定します。

## **画像品質と切り抜き領域の制御**

HTML エクスポートはスライド画像を圧縮して出力サイズを削減できます。高い画像品質が必要な場合は、[PicturesCompression](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/picturescompression/) のいずれかの値を `pictures_compression` に設定します。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.pictures_compression = slides.export.PicturesCompression.DPI150

    presentation.save("presentation-dpi-150.html", slides.export.SaveFormat.HTML, html_options)
```

デフォルトでは、画像の切り抜き領域はエクスポート出力から削除されることがあります。ユーザーが隠れた画像部分を復元または検査できる必要がある場合にのみ切り抜きデータを保持してください。保持すると HTML のサイズが増加します。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.delete_pictures_cropped_areas = False

    presentation.save("presentation-with-cropped-areas.html", slides.export.SaveFormat.HTML, html_options)
```

## **CSSの追加**

シンプルなスタイリングの場合は、CSS 文字列を [HtmlFormatter](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/htmlformatter/) に渡します。これによりスライド コンテンツのレンダリングはそのままに、周囲の HTML ドキュメントが変更されます。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = slides.export.HtmlFormatter.create_document_formatter(css_rules, True)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-styled.html", slides.export.SaveFormat.HTML, html_options)
```

カスタム ドキュメントヘッダー、リンクされた CSS ファイル、またはスライドやシェイプ周辺のカスタム マークアップが必要な場合は、カスタム フォーマット コントローラを作成し、`create_custom_formatter` とともに [HtmlFormatter](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/htmlformatter/) に渡します。

## **フォントの埋め込み**

ターゲット環境にプレゼンテーションのフォントがインストールされていない可能性がある場合は、[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/embedallfontshtmlcontroller/) を使用して HTML にフォントを埋め込みます。埋め込みは視覚的忠実度を向上させますが、出力サイズが増加します。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    font_names_to_exclude = ["Arial"]
    font_controller = slides.export.EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = slides.export.HtmlFormatter.create_custom_formatter(font_controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-embedded-fonts.html", slides.export.SaveFormat.HTML, html_options)
```

フォントを除外するのは、対象のブラウザやシステムがすでにフォントを提供していると確信できる場合に限ります。ブランド フォントや一般的でないフォントは、埋め込みが安全です。

## **フォントファイルを埋め込む代わりにリンク**

HTML ファイルサイズを削減するために、フォント データを別々の WOFF ファイルに書き込み、HTML に `@font-face` ルールを追加できます。これには、エクスポート時にフォント データの書き込み方法をカスタマイズするコントローラが必要です。Python via .NET では、そのコントローラを小さな .NET ヘルパー アセンブリで実装し、Python でロードして、`create_custom_formatter` とともに [HtmlFormatter](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/htmlformatter/) にヘルパー オブジェクトを渡します。

フォントを外部化する際は、意図的に 2 つのパスを選択してください。

- 生成された WOFF ファイルが書き込まれるファイルシステム上の出力ディレクトリ。
- HTML ドキュメントに記載され、ブラウザがフォントファイルを読み込む際に使用する URL パス。

HTML ファイルと生成されたフォント ファイルは、デプロイ パスが最終決定されるまで一緒に保管してください。ファイルが別の場所にデプロイされる場合は、URL プレフィックスをデプロイ先の URL パスに合わせます。

## **リソースを外部保存**

自己完結型 HTML は持ち運びが容易ですが、埋め込まれた Base64 リソースによりファイルが大きくなることがあります。アプリケーションで外部画像、フォント、オーディオ、またはビデオ ファイルが必要な場合は、カスタム リンク/埋め込み コントローラを使用し、[HtmlOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/htmloptions/) コンストラクタに渡します。

リソースを外部化する際は、意図的に 2 つのパスを選択してください。

- アプリケーションが生成した画像、フォント、音声、またはビデオを書き込むファイルシステム上の出力パス。
- HTML ドキュメントからブラウザがそれらのファイルを読み込む際に使用する URL パス。

完全な画像リンクの議論については、[Export Presentations to HTML with Externally Linked Images](/slides/ja/python-net/exporting-presentations-to-html-with-externally-linked-images/) を参照してください。

## **メディアファイルのエクスポート**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/videoplayerhtmlcontroller/) はビデオおよびオーディオ ファイルをエクスポートし、ブラウザで再生できる HTML を生成します。そのコンストラクタは次のパラメータを受け取ります。

- `path`: 生成されたメディアファイルが書き込まれるディレクトリ。
- `file_name`: 生成中の HTML ファイル名。
- `base_uri`: メディア ファイルへの HTML リンクで使用される絶対 URI プレフィックス。

HTML ファイルが `html-output/presentation.html` で、メディア ファイルが `html-output/media` に保存される場合、`path` はディスク上のメディア ディレクトリを指し、`base_uri` はブラウザ側から見た同じディレクトリを指す必要があります。ローカル プレビューの場合は、メディア ディレクトリから `file:///` URI を構築できます。デプロイされたアプリケーションでは、公開メディア ディレクトリの絶対 URL を使用してください。

```python
import os
from pathlib import Path

import aspose.slides as slides

output_directory = os.path.join(os.getcwd(), "html-output")
media_directory = os.path.join(output_directory, "media")
os.makedirs(output_directory, exist_ok=True)
os.makedirs(media_directory, exist_ok=True)

html_file_name = "presentation.html"
media_base_uri = Path(media_directory).as_uri() + "/"

with slides.Presentation() as presentation:
    with open("intro.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(
            video_stream,
            slides.LoadingStreamBehavior.READ_STREAM_AND_RELEASE)

    slide = presentation.slides[0]
    slide.shapes.add_video_frame(20, 20, 480, 270, video)

    controller = slides.export.VideoPlayerHtmlController(
        media_directory,
        html_file_name,
        media_base_uri)

    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)
    svg_options = slides.export.SVGOptions(controller)
    slide_image_format = slides.export.SlideImageFormat.svg(svg_options)

    html_options = slides.export.HtmlOptions(controller)
    html_options.html_formatter = formatter
    html_options.slide_image_format = slide_image_format

    html_file_path = os.path.join(output_directory, html_file_name)
    presentation.save(html_file_path, slides.export.SaveFormat.HTML, html_options)
```

ジョブごとに一意の出力ディレクトリを使用してください。特にサーバー アプリケーションでは、共有出力パスにより異なる変換のファイルが上書きされる恐れがあります。

## **パフォーマンスとリソース管理**

HTML 変換はレンダリング操作であり、処理時間とメモリ使用量はスライド数、画像解像度、フォント、エフェクト、チャート、埋め込みメディアに依存します。`pictures_compression` の DPI 値を高くしたり、フォントを埋め込んだり、SVG 出力や切り抜き画像領域を保持したりすると忠実度は向上しますが、通常は出力サイズが増加します。

バッチ変換の場合:

- [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) インスタンスはすぐに破棄してください。
- ジョブごとに別々の出力ディレクトリを使用してください。
- 信頼性が必要な場合を除き、一般的なフォントの埋め込みは避けてください。
- HTML がプレビューやサムネイル用の場合は画像 DPI を下げてください。
- デプロイパスが確定するまで、元のプレゼンテーション、生成された HTML、外部リソースを一緒に保管してください。

## **FAQ**

**HTML 出力でハイパーリンクは保持されますか？**

はい。プレゼンテーションのハイパーリンクは HTML にエクスポートされ、対象 URL が有効な限りクリック可能です。

**プレゼンテーションを並列で HTML に変換できますか？**

はい。ただし、1 つの [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) インスタンスをスレッド間で共有しないでください。異なるファイルは別々のプレゼンテーション インスタンス、別々のストリーム、別々の出力ディレクトリで処理します。詳細は [multithreading guidance](/slides/ja/python-net/multithreading/) を参照してください。

**Presentation オブジェクトはスレッド セーフですか？**

いいえ。単一の [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) インスタンスは 1 つのスレッド上でロード、変更、保存、破棄する必要があります。並列作業を行う場合は、スレッドまたはプロセスごとに独立したインスタンスを作成してください。

**生成された HTML ファイルが大きいのはなぜですか？**

デフォルトのエクスポートはリソースを直接 HTML に埋め込むためです。埋め込まれたフォント、高 DPI 画像、メディア、SVG コンテンツ、保持された切り抜き画像領域などがサイズを増加させます。外部リソースを使用し、一般的なフォントの埋め込みを除外し、`pictures_compression` を下げることで、最大忠実度よりも小さな出力が重要な場合にサイズを削減できます。

**メディア エクスポートの base_uri はどのように選択すべきですか？**

ブラウザの視点からの URI を選択し、絶対 URI として `base_uri` に渡します。ローカル プレビューの場合は、出力ディレクトリから `Path(media_directory).as_uri() + "/"` のように `file:///` URI を生成できます。デプロイ時は、公開メディア ディレクトリの絶対 URL を使用してください。ファイルシステム上の `path` とブラウザ側の `base_uri` は文字列として同一である必要はありませんが、同じリソース位置を指す必要があります。

**非表示スライドを含めることはできますか？**

はい。非表示スライドをエクスポートする必要がある場合は、[HtmlOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/htmloptions/) の `show_hidden_slides = True` を設定してください。