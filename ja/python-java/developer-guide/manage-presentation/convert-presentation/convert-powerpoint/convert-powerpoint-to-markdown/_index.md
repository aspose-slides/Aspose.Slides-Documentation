---
title: Python（Java経由）でPowerPointプレゼンテーションをMarkdownに変換する
linktitle: PowerPoint を Markdown に変換
type: docs
weight: 140
url: /ja/python-java/convert-powerpoint-to-markdown/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を MD に変換
- プレゼンテーションを MD に変換
- スライドを MD に変換
- PPT を MD に変換
- PPTX を MD に変換
- PowerPoint を Markdown として保存
- プレゼンテーションを Markdown として保存
- スライドを Markdown として保存
- PPT を MD として保存
- PPTX を MD として保存
- PPT を MD にエクスポート
- PPTX を MD にエクスポート
- Markdown の画像エクスポート
- CDN 画像リンク
- PowerPoint
- プレゼンテーション
- Markdown
- Python
- Java
- Aspose.Slides
description: "Python（Java経由）で PPT および PPTX プレゼンテーションを Markdown に変換し、エクスポートされたビットマップ、メタファイル、SVG 画像の保存場所と参照先を制御します。"
---
## **概要**

Aspose.Slides for Python via Java は、PPT および PPTX プレゼンテーションを Markdown に変換でき、ドキュメント作成、静的サイト、コンテンツ移行、バージョン管理ワークフローに利用できます。Markdown のフレーバーを選択したり、スライドコンテンツの描画方法を制御したり、エクスポートされた画像の保存先と Markdown での参照方法を決定したりできます。

既定では、Markdown エクスポートはテキストのみの出力になります。ビジュアル コンテンツをエクスポートするには、[MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/markdownsaveoptions/#setExportType) メソッドで [MarkdownExportType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/markdownexporttype/) 列挙体の `Sequential` または `Visual` 値を指定します。`Sequential` はスライド項目を個別かつ順番通りにレンダリングし、`Visual` はグループ化された項目をまとめて描画し、視覚的な関係を保持します。`TextOnly` 値は画像リソースを出力しないため、そのモードでは画像保存コールバックは呼び出されません。

## **プレゼンテーションを Markdown に変換する**

[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスでソース ファイルを読み込み、次に [Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) メソッドに [SaveFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/) 列挙体の `Md` 値を指定して呼び出します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.md", SaveFormat.Md)
finally:
    presentation.dispose()
```

各例はカレント ディレクトリから `presentation.pptx` を読み込みます。実行前に Aspose.Slides for Python via Java と互換性のある Java ランタイムをインストールしてください。JVM は Python プロセスごとに一度だけ起動します。

## **Markdown フレーバーの選択**

[MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/ja/python-java/aspose.slides/markdownsaveoptions/#setFlavor) メソッドで出力に使用する Markdown 仕様を制御します。[Flavor](https://reference.aspose.com/slides/ja/python-java/aspose.slides/flavor/) 列挙体には CommonMark、GitHub Flavored Markdown、その他のサポートされているバリエーションが含まれます。

次の例はプレゼンテーションを CommonMark としてエクスポートします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Flavor, MarkdownSaveOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setFlavor(Flavor.CommonMark)

    presentation.save("presentation.md", SaveFormat.Md, options)
finally:
    presentation.dispose()
```

## **既定のローカル保存動作で画像をエクスポートする**

[MarkdownSaveOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/markdownsaveoptions/) クラスはローカルに保存する画像を構成するための 2 つのメソッドを提供します。

- [setBasePath](https://reference.aspose.com/slides/ja/python-java/aspose.slides/markdownsaveoptions/#setBasePath) は Markdown ドキュメントとそのリソースの基準ディレクトリを指定します。
- [setImagesSaveFolderName](https://reference.aspose.com/slides/ja/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) は画像サブディレクトリを指定します。既定値は `Images` です。

次の例はビジュアル コンテンツをレンダリングし、画像を `output/assets` に書き込み、Markdown 文書には相対パスで画像参照を作成します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("assets")

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

この動作はカスタム画像保存ハンドラが `False` を返したときのフォールバックとしても機能します。

## **画像保存と Markdown リンクのカスタマイズ**

[MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/ja/python-java/aspose.slides/markdownsaveoptions/) メソッドで、Markdown エクスポート時に生成される非 SVG ビットマップおよびメタファイル リソース用のコールバックを登録できます。`MarkdownImageSavingHandler` コールバックは画像オブジェクト、その [ImageFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imageformat/) 値、および生成された Markdown リンクを 1 要素の `String[]` パラメータとして受け取ります。指定されたフォーマットで画像を保存またはアップロードし、`link[0]` に Markdown 出力に記載すべき参照を設定してください。

SVG 形式で出力されるリソースは別途処理されます。[MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/ja/python-java/aspose.slides/markdownsaveoptions/) メソッドでコールバックを登録します。`MarkdownSvgImageSavingHandler` コールバックは [SvgImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgimage/) オブジェクトと 1 要素の `String[] link` パラメータを受け取ります。SVG には `ImageFormat` 引数がないため、代わりに [SvgImage.getSvgData](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgimage/#getSvgData) メソッドで取得した XML データを書き込むかアップロードしてください。エクスポートモードやビジュアル グルーピングに応じて、ソース プレゼンテーションの SVG がラスタライズされたり他のコンテンツと結合されたりすることがあります。その結果得られた非 SVG リソースは画像保存コールバックに渡されます。すべてのエクスポートされたビジュアル リソースでカスタム処理が必要な場合は、両方のコールバックを登録してください。

ハンドラの戻り値は画像の処理者を決定します。

- ハンドラが画像を保存・アップロード・変換などして有効な `link[0]` を設定した場合は `True` を返します。Aspose.Slides はその値を Markdown 文書に書き込み、既定のローカル保存は行いません。
- `False` を返すと、Aspose.Slides が画像をローカルに保存し、[MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/ja/python-java/aspose.slides/markdownsaveoptions/#setBasePath) と [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/ja/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) の設定に従ってリンクを生成します。

{{% alert color="danger" title="重要" %}}
`True` を返すハンドラは画像の管理責任を負います。`True` を返した後に有効な非空リンクが `link[0]` に設定されていない場合、エクスポートは `InvalidOperationException` で失敗します。
{{% /alert %}}

Python では `jpype.JProxy` を使ってこれらのコールバックを登録し、Java のコールバック インターフェイスの `invoke` メソッドを実装します。`link` 引数は可変の Java 文字列配列です。処理前に `link[0]` を Python の文字列に変換し、置換後の URL を `link[0]` に再代入してください。

### **CDN オリジン ディレクトリに画像を保存し外部 URL を使用する**

次の例は `cdn-origin/presentations/quarterly-report` をマウントまたは同期された CDN オリジン ディレクトリとして扱います。各ハンドラは生成されたファイル名を取得し、カスタム ディレクトリに画像を保存し、生成されたローカル参照を公開 CDN URL に置き換えます。サンプル自体はネットワーク アップロードを行わず、ディレクトリが CDN オリジンとしてマウントされるか、ファイルが CDN に公開された後に URL が有効になります。オブジェクトストレージを利用する場合は、ファイルシステムへの書き込みをストレージ SDK のアップロード操作に置き換え、アップロードが成功した後にのみ `link[0]` を設定してください。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from urllib.parse import quote
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
public_base_url = "https://cdn.example.com/presentations/quarterly-report"
storage_directory = Path("cdn-origin", "presentations", "quarterly-report")
output_directory.mkdir(parents=True, exist_ok=True)
storage_directory.mkdir(parents=True, exist_ok=True)

def get_file_name(generated_link):
    normalized_link = str(generated_link).replace("\\", "/")
    return normalized_link.rsplit("/", 1)[-1]

def save_image(image, image_format, link):
    if image.getWidth() < 128 or image.getHeight() < 128:
        return False

    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    image.save(str(storage_path), image_format)
    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

def save_svg(svg_image, link):
    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    svg_data = svg_image.getSvgData()
    try:
        storage_path.write_bytes(bytes(svg_data))
    except OSError as error:
        print(f"Could not save the SVG image: {error}")
        return False

    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

image_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", dict(invoke=save_image))
svg_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", dict(invoke=save_svg))

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("fallback-images")
    options.setImageSaving(image_handler)
    options.setSvgImageSaving(svg_handler)

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

ビットマップ ハンドラは 128 × 128 ピクセル未満の画像について意図的に `False` を返すため、Aspose.Slides はそれらの画像を `output/fallback-images` にデフォルト動作で保存します。より大きなビットマップ・メタファイルおよび SVG リソースはカスタム コードで処理されます。たとえば、生成されたローカル参照 `fallback-images/image1.png` は `https://cdn.example.com/presentations/quarterly-report/image1.png` に置き換えられます。ハンドラはファイルを書き込む際に OS 固有のパス区切り文字を使用しますが、Markdown に書き込むリンクはスラッシュ（`/`）と URL エスケープされたファイル名を使用してください。相対リンクを作成する際も同様に `/` を使用し、プラットフォーム固有のディレクトリ区切り文字は使用しません。

## **FAQ**

**1️⃣ ハンドラはラスタ画像と SVG 画像の両方を処理できますか？**

いいえ。ビットマップおよびメタファイル リソースには [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/ja/python-java/aspose.slides/markdownsaveoptions/) を、SVG リソースには [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/ja/python-java/aspose.slides/markdownsaveoptions/) を使用してください。前者は画像オブジェクトと [ImageFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imageformat/) を提供し、後者は [SvgImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgimage/) とその SVG データ取得用メソッドを提供します。エクスポート中にラスタライズされた SVG は画像保存コールバックで処理されます。

**2️⃣ 画像保存ハンドラが `False` を返した場合はどうなりますか？**

Aspose.Slides は既定のローカル保存動作を使用します。画像の保存先と生成された参照は [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/ja/python-java/aspose.slides/markdownsaveoptions/#setBasePath) と [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/ja/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) の設定値で制御されます。

**3️⃣ ハンドラは画像をローカルに保存せずに URL だけを提供できますか？**

はい。ハンドラ側で画像をオブジェクトストレージや別サービスにアップロードし、生成された URL を `link[0]` に設定して `True` を返せば、既定のローカル保存は行われません。

**4️⃣ ハンドラから `InvalidOperationException` がスローされるのはなぜですか？**

ハンドラが `True` を返したにもかかわらず有効なリンクが `link[0]` に設定されていない場合に発生します。`True` を返す前に、Markdown に書き込むべき相対パスまたは外部 URL を `link[0]` に代入してください。

**5️⃣ 画像リンクはどのパス区切り文字を使用すべきですか？**

Markdown リンクおよび URL ではスラッシュ（`/`）を使用します。ファイルシステムのパス操作には `pathlib.Path` を利用し、Markdown 用の参照は別途正規化してください。

**6️⃣ ハイパーリンクは Markdown エクスポート時に保持されますか？**

はい。テキストの [ハイパーリンク](/slides/ja/python-java/manage-hyperlinks/) は標準的な Markdown リンクとして保持されます。一方、スライドの [トランジション](/slides/ja/python-java/slide-transition/) や [アニメーション](/slides/ja/python-java/powerpoint-animation/) は変換されません。

**7️⃣ プレゼンテーションを並列に Markdown へ変換できますか？**

複数のプレゼンテーション ファイルを並列に処理できますが、同一の [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) インスタンスをスレッド間で共有しないでください。マルチスレッドのガイドライン (/slides/ja/python-java/multithreading/) に従い、ファイルごとに別々のインスタンスを使用してください。