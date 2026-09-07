---
title: Python via Java で PowerPoint プレゼンテーションを HTML に変換する
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
description: "Python via Java で PowerPoint プレゼンテーションを HTML に変換します。Aspose.Slides を使用して PPT および PPTX ファイル、選択したスライド、ノート、フォント、画像、SVG、メディアをエクスポートします。"
---
## **概要**

Aspose.Slides for Python via Java は、Microsoft PowerPoint を使用せずに PowerPoint プレゼンテーションを HTML として保存できます。基本的な変換は、[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) をロードし、[save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) を呼び出し、[SaveFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/) を指定するだけです。エクスポートされたレイアウト、フォント、画像、ノート、コメント、SVG 出力、またはリンクされたリソースを制御する必要がある場合は、[HtmlOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/) を使用します。

このガイドは実用的な HTML エクスポートシナリオに焦点を当てています:

- プレゼンテーション全体または選択したスライドをエクスポートする。
- 固定レイアウト、レスポンシブ、または SVG ベースの HTML を生成する。
- スピーカーノートとコメントを含める。
- 画像品質と切り取られた画像データを制御する。
- フォントを埋め込むか、フォントファイルを別々に保存する。
- 外部リソースとメディアファイルの書き込み方法と参照方法を選択する。

デフォルトでは、HTML エクスポートはほとんどのリソースが埋め込まれた自己完結型の HTML ドキュメントを生成します。1 つのファイルで共有できて便利ですが、出力サイズが増加する可能性があります。Web 発行の場合は、外部リソースの使用、画像 DPI の低減、ターゲット環境で確実に利用できないフォントのみを埋め込むことを検討してください。

## **プレゼンテーションを HTML に変換する**

プレゼンテーションを HTML にエクスポートするには、[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) でロードし、[SaveFormat.Html](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/#Html) で保存します。

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

各例はカレント作業ディレクトリから `presentation.pptx` をロードします。実行する前に Aspose.Slides for Python via Java と互換性のある Java ランタイムをインストールしてください。JVM は Python プロセスごとに 1 回起動されます。

この例は 1 つの HTML ファイルを書き込みます。プレゼンテーション オブジェクトは `finally` ブロックで破棄され、エクスポート後にファイルハンドルとレンダリング リソースが解放されます。

## **HTML エクスポートの設定**

[HtmlOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/) は HTML エクスポートの主要な設定クラスです。一般的な設定は次のとおりです:

- [setSlidesLayoutOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions): ノート、コメント、配布資料、その他のレイアウト情報を追加します。
- [setHtmlFormatter](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/#setHtmlFormatter): HTML ドキュメント構造を変更するか、フォーマッタをコントローラに委譲します。
- [setSlideImageFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/#setSlideImageFormat): スライドの表現方法を変更します。例: SVG。
- [setPicturesCompression](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/#setPicturesCompression): 画像 DPI と出力サイズを制御します。
- [setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/#setDeletePicturesCroppedAreas): 切り取られた画像データを保持または削除します。
- [setSvgResponsiveLayout](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout): エクスポートされた SVG コンテンツをコンテナに合わせて自動調整します。
- [setShowHiddenSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/#setShowHiddenSlides): 必要に応じて非表示スライドを含めます。

以下のセクションでは、最も一般的なオプションを個別に示すので、ワークフローに必要なものだけを組み合わせて使用できます。

## **選択したスライドを HTML に変換する**

スライド番号を受け取る [Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) のオーバーロードは 1 ベースの位置を使用します。以下のループは各スライドを個別の HTML ファイルに保存します。

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

ウェブサイトやアプリケーションでスライドごとに 1 ページの HTML が必要な場合にこのパターンを使用します。すべてのスライドが同じレイアウトである場合は、1 つの [HtmlOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/) インスタンスを作成し、各 [Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) 呼び出しに渡します。

## **レスポンシブ HTML の作成**

[ResponsiveHtmlController](https://reference.aspose.com/slides/ja/python-java/aspose.slides/responsivehtmlcontroller/) は [HtmlFormatter](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmlformatter/) を通じてレスポンシブ HTML 出力を提供します。エクスポートされたページをブラウザー幅により適応させたい場合に使用してください。

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

SVG ベースのレスポンシブ レイアウトの場合は、`True` を指定して [HtmlOptions.setSvgResponsiveLayout](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout) を呼び出します。スライド内容をスケーラブルな SVG マークアップとしてエクスポートする場合に有用です。

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

## **スピーカーノートとコメントの含め方**

[HtmlOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions) を介して [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notescommentslayoutingoptions/) を使用し、スピーカーノートまたはコメントを含めます。ノートとコメントはデフォルトで非表示です。位置を指定しない限り表示されません。

元のプレゼンテーションにスピーカーノートが含まれているとします:

![PowerPoint のスピーカーノート付きスライド](slide_with_notes.png)

次のコードはスライドの下にスピーカーノートを付けてスライド内容をエクスポートします。

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

エクスポートされた HTML にはノート領域が含まれます:

![スライドとスピーカーノートを含む HTML 出力](HTML_with_notes.png)

コメントをエクスポートするには、[NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) を呼び出します。例: [CommentsPositions.Right](https://reference.aspose.com/slides/ja/python-java/aspose.slides/commentspositions/#Right) または [CommentsPositions.Bottom](https://reference.aspose.com/slides/ja/python-java/aspose.slides/commentspositions/#Bottom)。コメントだけが必要な場合は [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/ja/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) を省略します。ノートとコメントの両方が必要な場合は、両方のメソッドを呼び出してください。

## **画像品質と切り取り領域の制御**

HTML エクスポートはスライド画像を圧縮して出力サイズを削減できます。より高い画像品質が必要な場合は、[PicturesCompression](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picturescompression/) から取得した値を [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/#setPicturesCompression) に渡してください。

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

デフォルトでは、画像の切り取られた領域はエクスポート出力から削除されることがあります。ユーザーが隠れた画像部分を復元または検査できる必要がある場合にのみ切り取りデータを保持してください。保持すると HTML サイズが増加する可能性があります。

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

## **CSS の追加**

シンプルなスタイリングの場合は、CSS 文字列を [HtmlFormatter.createDocumentFormatter](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmlformatter/#createDocumentFormatter) に渡します。これにより、Aspose.Slides がスライド コンテンツのレンダリングを続行する一方で、周囲の HTML ドキュメントが変更されます。

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

カスタム ドキュメント ヘッダー、リンクされた CSS ファイル、またはスライドやシェイプの周囲にカスタム マークアップが必要な場合は、JPype インターフェース プロキシを介したカスタム フォーマッティング コントローラを使用し、[HtmlFormatter.createCustomFormatter](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmlformatter/#createCustomFormatter) とともに [HtmlFormatter](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmlformatter/) に渡します。

## **フォントの埋め込み**

対象環境にプレゼンテーションのフォントがインストールされていない可能性がある場合は、[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/ja/python-java/aspose.slides/embedallfontshtmlcontroller/) を使用してフォントを HTML に埋め込みます。埋め込みは視覚的忠実度を向上させますが、出力サイズが大きくなります。

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

フォントは、対象のブラウザーやシステムがすでに提供していると確信できる場合にのみ除外してください。ブランドフォントやあまり一般的でないフォントについては、埋め込みが通常は安全です。

## **リソースを外部に保存する**

自己完結型 HTML は持ち運びが簡単ですが、埋め込まれた Base64 リソースによりファイルが大きくなることがあります。アプリケーションで外部画像ファイルが必要な場合は、JPype インターフェース プロキシを介したリソース リンキング コントローラを実装し、[HtmlOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/) コンストラクタに渡してください。

リソースを外部化する際は、意図的に 2 つのパスを選択します:

- ファイルシステムの出力パス。アプリケーションが生成した画像、フォント、音声、またはビデオを書き込む場所。
- URL パス。HTML ドキュメントからブラウザーがそれらのファイルを読み込むために使用するパス。

## **メディアファイルのエクスポート**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/ja/python-java/aspose.slides/videoplayerhtmlcontroller/) はビデオおよびオーディオ ファイルをエクスポートし、ブラウザーで再生できる HTML を生成します。コンストラクタの引数は次のとおりです:

- `path`: 生成されたメディア ファイルが書き込まれるディレクトリ。
- `fileName`: 生成される HTML ファイル名。
- `baseUri`: HTML 内のメディア ファイルへのリンクに使用される絶対 URI プレフィックス。

次の例は `presentation.pptx` に埋め込まれたメディアをエクスポートします。生成された HTML はメディア ファイルをファイル名のみで参照し、HTML ドキュメントからの相対パスになるため、`path` は HTML ファイルも受け取るディレクトリである必要があります。`baseUri` は絶対 URI でなければなりません。ローカル プレビューの場合は出力ディレクトリから `file:///` URI を作成し、デプロイされたアプリケーションの場合は公開ディレクトリの絶対 URL を使用します。

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

エクスポート ジョブごとに一意の出力ディレクトリを使用してください。特にサーバー アプリケーションでは、共有出力パスが異なる変換からのファイル上書きの原因となります。

## **パフォーマンスとリソース管理**

HTML 変換はレンダリング操作であるため、処理時間とメモリ使用量はスライド数、画像解像度、フォント、エフェクト、チャート、埋め込みメディアに依存します。[HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/#setPicturesCompression) に渡す画像 DPI の高い値、埋め込みフォント、SVG 出力、および保持された切り取り画像領域は忠実度を向上させますが、通常は出力サイズを増加させます。

バッチ変換の場合:

- すべての [Presentation] インスタンスを速やかに破棄する。
- ジョブごとに別々の出力ディレクトリを使用する。
- 必要な忠実度がない限り、共通フォントの埋め込みは避ける。
- HTML がプレビューやサムネイル用の場合は画像 DPI を下げる。
- デプロイパスが最終決定になるまで、元のプレゼンテーション、生成された HTML、および外部リソースを一緒に保持する。

## **FAQ**

**HTML 出力でハイパーリンクは保持されますか？**

はい。プレゼンテーションのハイパーリンクは HTML にエクスポートされ、対象 URL が有効な場合はクリック可能なままです。

**プレゼンテーションを並列で HTML に変換できますか？**

はい、ただし 1 つの [Presentation] インスタンスをスレッド間で共有しないでください。別々のプレゼンテーション インスタンス、別々のストリーム、別々の出力ディレクトリで異なるファイルを処理します。詳細は [multithreading guidance](/slides/ja/python-java/multithreading/) を参照してください。

**プレゼンテーション オブジェクトはスレッド セーフですか？**

いいえ。単一の [Presentation] インスタンスは 1 つのスレッドでロード、変更、保存、破棄する必要があります。並列作業が必要な場合は、スレッドまたはプロセスごとに独立したインスタンスを作成してください。

**生成された HTML ファイルが大きいのはなぜですか？**

デフォルトのエクスポートはリソースを直接 HTML に埋め込むことができます。埋め込みフォント、高 DPI 画像、メディア、SVG コンテンツ、保持された切り取り画像領域もサイズを増大させます。外部リソースを使用し、共通フォントの埋め込みを除外し、出力サイズを小さくしたい場合は [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/#setPicturesCompression) に低い DPI 値を渡してください。

**HTML のフォントサイズの値が PowerPoint の値と異なるのはなぜですか？**

エクスポートされたページは SVG 座標系とスケーリング変換を使用することがあります。生の CSS または SVG のフォントサイズ値だけでは最終的に表示されるサイズを正確に表せません。意図したズーム レベルでレンダリングされたスライドを比較し、テキストが異なる場合はフォントの可用性を確認してください。

**メディア エクスポート用の baseUri はどのように選択すべきですか？**

`baseUri` はブラウザーの視点から選択し、絶対 URI として渡してください。ローカル プレビューの場合は `output_directory.as_uri() + "/"` で導出できます。デプロイ時は公開ディレクトリの絶対 URL を使用します。ファイルシステムの `path` とブラウザーの `baseUri` は同じ文字列である必要はありませんが、同じ場所を指し示す必要があり、その場所は生成された HTML ファイルを格納するディレクトリでなければなりません。メディア リンクはそのディレクトリを基準に相対的に書き込まれます。

**非表示スライドを含めることはできますか？**

はい。非表示スライドをエクスポートする必要がある場合は、`True` を指定して [HtmlOptions.setShowHiddenSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/htmloptions/#setShowHiddenSlides) を呼び出してください。