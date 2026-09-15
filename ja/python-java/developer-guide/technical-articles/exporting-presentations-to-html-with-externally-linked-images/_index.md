---
title: 外部リンクされた画像でプレゼンテーションを HTML にエクスポート
type: docs
weight: 100
url: /ja/python-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPointをエクスポート
- OpenDocumentをエクスポート
- プレゼンテーションをエクスポート
- スライドをエクスポート
- PPTをエクスポート
- PPTXをエクスポート
- ODPをエクスポート
- PowerPointからHTMLへ
- OpenDocumentからHTMLへ
- プレゼンテーションからHTMLへ
- スライドからHTMLへ
- PPTからHTMLへ
- PPTXからHTMLへ
- ODPからHTMLへ
- リンクされた画像
- 外部リンクされた画像
- リンクされたリソース
- 外部リソース
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して Python で PowerPoint および OpenDocument のプレゼンテーションを HTML にエクスポートし、画像やその他のリソースを外部リンクされたファイルとして保存します。"
---
## **概要**

デフォルトでは、Aspose.Slides はプレゼンテーションを自己完結型の HTML ファイルとしてエクスポートします。画像やその他のリソースは通常 Base64 データとして HTML に直接埋め込まれます。単一のポータブルファイルが必要なときには便利ですが、ウェブサイトや CMS、サーバー側の変換パイプラインに最適な形式とは限りません。

外部リンクリソースを使用する場面：

- HTML ドキュメントのサイズを削減する。
- 画像、フォント、音声、またはビデオをブラウザーや CDN に個別にキャッシュする。
- エクスポート後に生成されたリソースを検査、置換、圧縮、またはポストプロセスする。
- 出力構造をウェブアプリケーションが期待する形に近づける。

一般的な HTML 変換ワークフローについては、[PowerPoint プレゼンテーションを HTML に変換](/slides/ja/python-java/convert-powerpoint-to-html/) を参照してください。本記事はエクスポート時のリソースリンク部分に焦点を当てています。

## **リンクリソース エクスポートの仕組み**

`ILinkEmbedController` は、リソースごとにエクスポーターがデータを HTML に埋め込むか、外部に保存してリンクを書き込むかをアプリケーションが決定できるようにします。

このインターフェイスには 3 つのメソッドがあります。

- `ILinkEmbedController.getObjectStoringLocation` は、リソースをリンクするか埋め込むかを決定します。
- `ILinkEmbedController.getUrl` は、生成された HTML または別のリンクリソースに記述される URL を返します。
- `ILinkEmbedController.saveExternal` は、リンクされたリソースデータをディスクまたは別の保存先に書き込みます。

ファイルシステム上のパスとブラウザー URL は別々に扱われます。たとえば、以下のサンプルはリソースファイルをディスクの `html-output/assets` に書き込み、HTML には `assets/resource-1.svg` のような相対 URL が含まれます。ブラウザーはリンクを含むファイルを基準に URL を解決します。したがって、`presentation.html` から SVG ファイルへのリンクは `assets/resource-1.svg` を使用し、その SVG ファイルから同じ `assets` フォルダー内の画像へのリンクは `resource-4.jpg` を使用します。

## **リンクリソース付き HTML のエクスポート**

以下の Python サンプルは出力ディレクトリを作成し、HTML ファイルをそのディレクトリに保存し、リンクリソースを `assets` サブディレクトリに格納します。コントローラーは、Aspose.Slides が安全なファイル拡張子を提供または推測できる場合に、一般的な画像、フォント、音声、ビデオ、CSS リソースをリンクします。認識されないリソースは埋め込まれたままです。

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, LinkEmbedDecision, Presentation, SVGOptions, SaveFormat, SlideImageFormat


class ExternalResourceController:
    EXTENSIONS_BY_CONTENT_TYPE = {
        "image/jpeg": ".jpg",
        "image/png": ".png",
        "image/gif": ".gif",
        "image/bmp": ".bmp",
        "image/svg+xml": ".svg",
        "image/tiff": ".tiff",
        "image/x-emf": ".emf",
        "image/x-wmf": ".wmf",
        "font/woff": ".woff",
        "font/woff2": ".woff2",
        "font/ttf": ".ttf",
        "application/font-woff": ".woff",
        "application/vnd.ms-fontobject": ".eot",
        "application/x-font-ttf": ".ttf",
        "text/css": ".css",
        "audio/mpeg": ".mp3",
        "audio/mp4": ".m4a",
        "audio/wav": ".wav",
        "video/mp4": ".mp4",
        "video/webm": ".webm",
    }

    def __init__(self, asset_directory, asset_url_prefix):
        self.asset_directory = asset_directory
        normalized_prefix = asset_url_prefix.replace("\\", "/") if asset_url_prefix else ""
        self.asset_url_prefix = normalized_prefix.rstrip("/") + "/" if normalized_prefix else ""
        self.file_names_by_resource_id = {}

    def getObjectStoringLocation(self, resource_id, entity_data, semantic_name, content_type, recommended_extension):
        extension = self.resolve_extension(content_type, recommended_extension)
        if extension is None:
            return LinkEmbedDecision.Embed

        self.file_names_by_resource_id[resource_id] = f"resource-{resource_id}{extension}"
        return LinkEmbedDecision.Link

    def getUrl(self, resource_id, referrer):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            return None
        if referrer in self.file_names_by_resource_id:
            return file_name
        return self.asset_url_prefix + file_name

    def saveExternal(self, resource_id, entity_data):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            print(f"Resource {resource_id} was not registered for external storage.")
            return
        if entity_data is None or len(entity_data) == 0:
            print(f"Resource {resource_id} contains no data and cannot be saved.")
            return

        try:
            self.asset_directory.mkdir(parents=True, exist_ok=True)
            file_path = self.asset_directory / file_name
            resource_data = bytes(entity_data)
            file_path.write_bytes(resource_data)
        except OSError as error:
            print(f"Failed to save external resource {resource_id}: {error}")

    @classmethod
    def resolve_extension(cls, content_type, recommended_extension):
        content_type = str(content_type) if content_type is not None else ""
        mapped_extension = cls.EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if mapped_extension is not None:
            return mapped_extension
        if not content_type.lower().startswith(("image/", "font/", "audio/", "video/")):
            return None
        if recommended_extension is None:
            return None
        extension_characters = str(recommended_extension).strip().lstrip(".")
        if not extension_characters or not extension_characters.isalnum():
            return None
        return "." + extension_characters.lower()


input_file_path = Path("presentation.pptx")
output_directory = Path("html-output")
asset_directory_name = "assets"
asset_directory = output_directory / asset_directory_name

output_directory.mkdir(parents=True, exist_ok=True)
asset_directory.mkdir(parents=True, exist_ok=True)

asset_url_prefix = asset_directory_name + "/"
controller = ExternalResourceController(asset_directory, asset_url_prefix)
controller_proxy = jpype.JProxy("com.aspose.slides.ILinkEmbedController", inst=controller)
svg_options = SVGOptions(controller_proxy)
slide_image_format = SlideImageFormat.svg(svg_options)

html_options = HtmlOptions(controller_proxy)
html_formatter = HtmlFormatter.createDocumentFormatter("", False)
html_options.setHtmlFormatter(html_formatter)
html_options.setSlideImageFormat(slide_image_format)

presentation = Presentation(str(input_file_path))
try:
    html_file_path = output_directory / "presentation.html"
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

エクスポート後、出力フォルダーは次の構造になります。

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

正確なファイルはプレゼンテーションの内容やエクスポートオプションに依存します。たとえば、ラスタ画像は一般的に JPEG または PNG としてエクスポートされます。Aspose.Slides は、サイズや適合性が向上する場合に、元プレゼンテーションで使用されていたものとは異なる画像コーデックを選択することがあります。透過性を持つ画像は PNG としてエクスポートされます。

## **デプロイ時の URL の選択**

サンプルは相対 URL プレフィックス `assets/` を使用しています。`presentation.html` を `html-output/presentation.html` から開くと、ブラウザーは `html-output/assets/resource-1.svg` を読み込みます。

あるリンクリソースが別のリンクリソースを参照する場合、サンプルは `ILinkEmbedController.getUrl` の `referrer` パラメーターを使用し、ファイル名だけを返します。たとえば、`resource-1.svg` と `resource-4.jpg` が両方とも `assets` フォルダーにある場合、SVG ファイルは `resource-4.jpg` を参照すべきであり、`assets/resource-4.jpg` ではありません。

ファイルが別の場所にデプロイされる場合は、異なる URL プレフィックスを使用してください。

- `assets/` を使用します（アセットディレクトリが HTML ファイルの隣にある場合）。
- `../assets/` を使用します（アセットディレクトリが HTML ファイルの 1 つ上の階層にある場合）。
- `https://cdn.example.com/presentations/job-123/assets/` を使用します（ファイルが CDN や静的ファイルサーバーにアップロードされる場合）。

`ILinkEmbedController.getUrl` が返す URL は、`ILinkEmbedController.saveExternal` が書き込むファイルの最終デプロイ位置と一致しなければなりません。サーバーアプリケーションでは、各変換ジョブごとに一意の出力ディレクトリまたはオブジェクトストレージプレフィックスを使用して、別のエクスポートによるファイル上書きを防止してください。

## **埋め込みにすべき場合**

埋め込み Base64 HTML は、メール添付やオフラインプレビュー、アセットフォルダーなしで移動されるドキュメントなど、出力が単一ファイルである必要がある場合に依然有用です。HTML がウェブアプリケーションで提供されたり、CMS に保存されたり、ビルドパイプラインで最適化されたり、ブラウザーが HTML とは別にキャッシュしたりする場合は、リンクリソースの方が適しています。

## **FAQ**

**画像だけを外部化し、他のリソースは埋め込んだままにできますか？**

はい。`ILinkEmbedController.getObjectStoringLocation` では、別ファイルとして保存したいコンテンツタイプに対してのみ [LinkEmbedDecision.Link](https://reference.aspose.com/slides/ja/python-java/aspose.slides/linkembeddecision/#Link) を返し、その他はすべて [LinkEmbedDecision.Embed](https://reference.aspose.com/slides/ja/python-java/aspose.slides/linkembeddecision/#Embed) を返します。

**エクスポートされた画像の拡張子が元のプレゼンテーションと異なるのはなぜですか？**

Aspose.Slides は、HTML エクスポート時にサイズやブラウザー互換性を向上させるため、ラスタ画像を再エンコードすることがあります。例えば、元のファイルの画像はレンダリング結果に応じて JPEG または PNG として書き出されます。

**HTML ファイルを移動した後でも相対 URL は機能しますか？**

相対 URL は、同じ相対フォルダー構造が維持されている場合にのみ機能します。HTML が `assets/resource-1.png` を参照している場合、`assets` フォルダーは HTML ファイルの隣に残す必要があります。別の URL プレフィックスを生成しない限りです。

**サーバーアプリケーションは同じ出力フォルダーを再利用すべきですか？**

いいえ。各変換ジョブごとに一意の出力ディレクトリまたはストレージプレフィックスを使用してください。これによりファイル名の衝突を防ぎ、別のエクスポートが生成したリソースを上書きすることを防止できます。