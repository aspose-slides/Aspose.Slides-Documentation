---
title: Python via Java で PowerPoint プレゼンテーションを HTML に変換
linktitle: PowerPoint を HTML に変換
type: docs
weight: 30
url: /ja/python-java/convert-powerpoint-to-html/
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
- Java
- Aspose.Slides
description: "Python via Java で PowerPoint プレゼンテーションを HTML に変換します。Aspose.Slides を使用して PPT および PPTX ファイル、選択スライド、ノート、フォント、画像、SVG、メディアをエクスポートします。"
---
## **概要**

Aspose.Slides for Python via Java は Microsoft PowerPoint を使用せずに PowerPoint プレゼンテーションを HTML として保存できます。基本的な変換は [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) の読み込みと [save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) 呼び出し、そして [SaveFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/) の指定だけです。エクスポートするレイアウト、フォント、画像、ノート、コメント、SVG 出力、リンクされたリソースを制御したい場合は [HtmlOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/) を使用します。

このガイドは実用的な HTML エクスポートシナリオに焦点を当てます：

- プレゼンテーション全体または選択したスライドをエクスポート
- 固定レイアウト、レスポンシブ、または SVG ベースの HTML を生成
- 発言者ノートとコメントを含める
- 画像品質と切り抜き画像データを制御
- フォントを埋め込むかフォントファイルを別保存
- 外部リソースやメディアファイルの書き出し方法を選択

既定では、HTML エクスポートはほとんどのリソースを埋め込んだ自己完結型 HTML ドキュメントを生成します。単一ファイルでの共有に便利ですが、出力サイズが大きくなる可能性があります。Web 公開の場合は外部リソースの使用、画像 DPI の低減、ターゲット環境で確実に利用できないフォントのみ埋め込むことを検討してください。

## **プレゼンテーションを HTML に変換する**

プレゼンテーションを HTML にエクスポートするには、[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) で読み込み、[SaveFormat.Html](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/#Html) で保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

各例は現在の作業ディレクトリから `presentation.pptx` を読み込みます。実行前に Aspose.Slides for Python via Java と互換性のある Java ランタイムをインストールしてください。JVM は Python プロセスごとに一度だけ起動されます。

この例は 1 つの HTML ファイルを書き出します。`finally` ブロックでプレゼンテーション オブジェクトを破棄し、エクスポート後にファイル ハンドルとレンダリング リソースを解放します。

## **HTML エクスポートの構成**

[HtmlOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/) は HTML エクスポートの主要な構成クラスです。一般的な設定は次のとおりです：

- [setSlidesLayoutOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions)：ノート、コメント、配布資料、その他のレイアウト情報を追加
- [setHtmlFormatter](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/#setHtmlFormatter)：HTML ドキュメント構造を変更するか、フォーマッタをコントローラに委譲
- [setSlideImageFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/#setSlideImageFormat)：スライドの表現方法を変更、例として SVG
- [setPicturesCompression](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/#setPicturesCompression)：画像 DPI と出力サイズを制御
- [setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/#setDeletePicturesCroppedAreas)：切り抜き画像データを保持または削除
- [setSvgResponsiveLayout](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout)：エクスポートされた SVG コンテンツをコンテナに合わせて自動調整
- [setShowHiddenSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/#setShowHiddenSlides)：必要に応じて非表示スライドを含める

以下のセクションでは、最も一般的なオプションを個別に示すので、ワークフローに必要なものだけを組み合わせて使用できます。

## **選択したスライドを HTML に変換する**

スライド番号を受け取る [Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) のオーバーロードは 1 基準のスライド位置を使用します。以下のループは各スライドを別々の HTML ファイルとして保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = jpype.JArray(jpype.JInt)([slide_number])
        html_file_name = f"slide-{slide_number}.html"
        presentation.save(html_file_name, slide_numbers, SaveFormat.Html)
finally:
    presentation.dispose()
```

ウェブサイトやアプリケーションでスライドごとに 1 ページの HTML が必要な場合にこのパターンを使用してください。すべてのスライドが同じレイアウトである場合は、1 つの [HtmlOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/) インスタンスを作成し、各 [Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) 呼び出しに渡します。

## **レスポンシブ HTML を作成する**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ja/python-java/aspose.slides/responsivehtmlcontroller/) は [HtmlFormatter](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmlformatter/) を介してレスポンシブ HTML 出力を提供します。エクスポートされたページをブラウザ幅に合わせて適応させたい場合に使用してください。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, ResponsiveHtmlController, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    controller = ResponsiveHtmlController()
    formatter = HtmlFormatter.createCustomFormatter(controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

SVG ベースのレスポンシブ レイアウトの場合は、`True` を渡して [HtmlOptions.setSvgResponsiveLayout](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout) を呼び出します。スライド内容がスケーラブルな SVG マークアップとしてエクスポートされる場合に有用です。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setSvgResponsiveLayout(True)

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **発言者ノートとコメントを含める**

[HtmlOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions) を介して [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notescommentslayoutingoptions/) を使用し、発言者ノートまたはコメントを含めます。ノートとコメントはデフォルトで非表示です。位置を指定しない限り表示されません。

ソース プレゼンテーションに発言者ノートが含まれていると仮定します：

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

以下のコードはスライド内容をスライド下部に発言者ノートを付加してエクスポートします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    html_options = HtmlOptions()
    html_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation-with-notes.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

エクスポートされた HTML にはノート領域が含まれます：

![HTML output with the slide and speaker notes](HTML_with_notes.png)

コメントをエクスポートするには、[NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) を呼び出し、例えば [CommentsPositions.Right](https://reference.aspose.com/slides/ja/python-java/aspose.slides/commentspositions/#Right) または [CommentsPositions.Bottom](https://reference.aspose.com/slides/ja/python-java/aspose.slides/commentspositions/#Bottom) を指定します。ノートだけが不要でコメントだけが必要な場合は、[NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) を省略してください。ノートとコメントの両方が必要な場合は、両方のメソッドを呼び出します。

## **画像品質と切り抜き領域を制御する**

HTML エクスポートはスライド画像を圧縮して出力サイズを削減できます。[HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/#setPicturesCompression) に [PicturesCompression](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picturescompression/) から値を渡すことで、画像品質を高く保つことができます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, PicturesCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setPicturesCompression(PicturesCompression.Dpi150)

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

既定では、画像の切り抜き領域はエクスポート出力から削除されることがあります。ユーザーが隠れた画像部分を復元または検査できる必要がある場合のみ、切り抜きデータを保持してください。保持すると HTML サイズが増加します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setDeletePicturesCroppedAreas(False)

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **CSS を追加する**

簡易的なスタイリングには、[HtmlFormatter.createDocumentFormatter](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmlformatter/#createDocumentFormatter) に CSS 文字列を渡します。これによりスライド コンテンツのレンダリングはそのままに、周囲の HTML ドキュメントが変更されます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = HtmlFormatter.createDocumentFormatter(css_rules, True)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-styled.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

カスタム ドキュメント ヘッダー、リンクされた CSS ファイル、またはスライドやシェイプ周辺のカスタム マークアップが必要な場合は、JPype インターフェイス プロキシを介したカスタム フォーマッタ コントローラを使用し、[HtmlFormatter.createCustomFormatter](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmlformatter/#createCustomFormatter) で [HtmlFormatter](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmlformatter/) に渡します。

## **フォントを埋め込む**

ターゲット環境にプレゼンテーションのフォントがインストールされていない可能性がある場合は、[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ja/python-java/aspose.slides/embedallfontshtmlcontroller/) を使用して HTML にフォントを埋め込みます。埋め込みは視覚的忠実度を向上させますが、出力サイズが増加します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedAllFontsHtmlController, HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    font_names_to_exclude = jpype.JArray(jpype.JString)(["Arial"])
    font_controller = EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = HtmlFormatter.createCustomFormatter(font_controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

フォントを除外するのは、対象のブラウザやシステムがすでにフォントを提供していると確信できる場合に限ります。ブランド フォントや一般的でないフォントは、通常埋め込みが安全です。

## **リソースを外部に保存する**

自己完結型 HTML は持ち運びが容易ですが、Base64 埋め込みリソースによりファイルが大きくなることがあります。アプリケーションで外部画像ファイルが必要な場合は、JPype インターフェイス プロキシを介したリソース リンキング コントローラを実装し、[HtmlOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/) コンストラクタに渡します。

リソースを外部化する際は、次の 2 つのパスを意図的に選択してください：

- ファイル システム出力パス：アプリケーションが生成した画像、フォント、音声、動画を書き込む場所
- URL パス：ブラウザが HTML ドキュメントからこれらのファイルを読み込む際に使用するパス

## **メディア ファイルをエクスポートする**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoplayerhtmlcontroller/) は動画および音声ファイルをエクスポートし、ブラウザで再生できる HTML を生成します。そのコンストラクタは次の引数を取ります：

- `path`：生成されたメディア ファイルを書き込むディレクトリ
- `fileName`：生成中の HTML ファイル名
- `baseUri`：HTML 内のメディア ファイルへのリンクで使用される絶対 URI プレフィックス

以下の例は `presentation.pptx` に埋め込まれたメディアをエクスポートします。生成された HTML はメディア ファイル名のみで参照し、HTML ドキュメントからの相対パスになるため、`path` は HTML ファイルも同じディレクトリに書き込む必要があります。`baseUri` は絶対 URI である必要があります。ローカル プレビューの場合は出力ディレクトリから `file:///` URI を作成し、デプロイされたアプリケーションの場合は公開ディレクトリの絶対 URL を使用してください。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SVGOptions, SaveFormat, SlideImageFormat, VideoPlayerHtmlController

from pathlib import Path

output_directory = Path("html-output").resolve()
output_directory.mkdir(parents=True, exist_ok=True)
html_file_name = "presentation.html"
media_base_uri = output_directory.as_uri() + "/"

presentation = Presentation("presentation.pptx")
try:
    controller = VideoPlayerHtmlController(str(output_directory), html_file_name, media_base_uri)
    formatter = HtmlFormatter.createCustomFormatter(controller)
    svg_options = SVGOptions(controller)
    slide_image_format = SlideImageFormat.svg(svg_options)

    html_options = HtmlOptions(controller)
    html_options.setHtmlFormatter(formatter)
    html_options.setSlideImageFormat(slide_image_format)

    html_file_path = output_directory / html_file_name
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

サーバー アプリケーションなどでは、エクスポート ジョブごとに一意の出力ディレクトリを使用してください。共有出力パスを使用すると、異なる変換からのファイルが上書きされる恐れがあります。

## **パフォーマンスとリソース管理**

HTML 変換はレンダリング操作であるため、処理時間とメモリ使用量はスライド数、画像解像度、フォント、エフェクト、チャート、埋め込みメディアに依存します。[HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/#setPicturesCompression) に渡す高 DPI 値、埋め込みフォント、SVG 出力、保持した切り抜き画像領域は忠実度を向上させますが、通常は出力サイズを増大させます。

バッチ変換の際は：

- 各 [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) インスタンスを速やかに破棄する
- ジョブごとに別々の出力ディレクトリを使用する
- 必要な忠実度がなければ共通フォントの埋め込みを避ける
- プレビューやサムネイル用の HTML であれば画像 DPI を下げる
- デプロイ パスが確定するまで、元のプレゼンテーション、生成された HTML、および外部リソースを一緒に保持する

## **FAQ**

**HTML 出力でハイパーリンクは保持されますか？**

はい。プレゼンテーションのハイパーリンクは HTML にエクスポートされ、対象 URL が有効な場合はクリック可能です。

**プレゼンテーションを並列で HTML に変換できますか？**

はい、ただし 1 つの [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) インスタンスをスレッド間で共有しないでください。別々のプレゼンテーション インスタンス、別々のストリーム、別々の出力ディレクトリで異なるファイルを処理します。詳細は [multithreading guidance](/slides/ja/python-java/multithreading/) を参照してください。

**プレゼンテーション オブジェクトはスレッド セーフですか？**

いいえ。単一の [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) インスタンスは 1 つのスレッド上で読み込み、変更、保存、破棄する必要があります。並列作業では、スレッドまたはプロセスごとに独立したインスタンスを作成してください。

**生成された HTML ファイルが大きいのはなぜですか？**

既定のエクスポートはリソースを直接 HTML に埋め込みます。埋め込みフォント、高 DPI 画像、メディア、SVG コンテンツ、保持した切り抜き画像領域がサイズ増加の要因です。外部リソースを使用し、共通フォントの埋め込みを除外し、[HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/#setPicturesCompression) に低い DPI 値を渡すことで、出力サイズを小さくできます。

**HTML のフォントサイズが PowerPoint の値と異なるのはなぜですか？**

エクスポートされたページは SVG 座標系やスケーリング変換を使用することがあります。単なる CSS や SVG のフォントサイズ値だけでは最終的に表示されるサイズを正確に示せません。意図したズームレベルでスライドを比較し、テキストが異なる場合はフォントの可用性も確認してください。

**メディア エクスポートの baseUri はどのように選択すべきですか？**

ブラウザ側から見たパスを基準にし、絶対 URI として `baseUri` を渡します。ローカル プレビューの場合は `output_directory.as_uri() + "/"` のように生成できます。デプロイ時は公開ディレクトリの絶対 URL を使用してください。ファイル システムの `path` とブラウザの `baseUri` は文字列が同一である必要はありませんが、同じ場所を指す必要があり、その場所は生成された HTML ファイルが存在するディレクトリである必要があります。

**非表示スライドを含められますか？**

はい。非表示スライドをエクスポートする必要がある場合は、[HtmlOptions.setShowHiddenSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/#setShowHiddenSlides) に `True` を渡してください。