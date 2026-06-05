---
title: Pythonで外部リンク画像付きHTMLにプレゼンテーションをエクスポート
linktitle: 外部リンク画像付きHTMLへのプレゼンテーションエクスポート
type: docs
weight: 100
url: /ja/python-net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPointをエクスポート
- OpenDocumentをエクスポート
- プレゼンテーションをエクスポート
- スライドをエクスポート
- PPTをエクスポート
- PPTXをエクスポート
- ODPをエクスポート
- PowerPointをHTMLに変換
- OpenDocumentをHTMLに変換
- プレゼンテーションをHTMLに変換
- スライドをHTMLに変換
- PPTをHTMLに変換
- PPTXをHTMLに変換
- ODPをHTMLに変換
- リンク画像
- 外部リンク画像
- リンクリソース
- 外部リソース
- Python
- Aspose.Slides
description: "PythonでAspose.Slidesを使用して、PowerPoint および OpenDocument のプレゼンテーションを HTML にエクスポートし、画像を外部リンクファイルとして保存します。"
---
## **概要**

既定では、Aspose.Slides はプレゼンテーションを単一の HTML ファイルにエクスポートします。画像やその他のリソースは、通常 Base64 データとして直接 HTML に書き込まれます。1 つのポータブル ファイルが必要な場合には便利ですが、Web サイトや CMS、サーバー側の変換パイプラインにとって常に最適な形式というわけではありません。

以下のような場合は、外部リンクされた画像を使用します：

- HTML ドキュメントのサイズを減らす。
- ブラウザや CDN で画像を個別にキャッシュする。
- エクスポート後に生成された画像を検査、置換、圧縮、または後処理する。
- 出力構造を Web アプリケーションが期待する形に近づける。

一般的な HTML 変換ワークフローについては、[PowerPoint プレゼンテーションを HTML に変換](/slides/ja/python-net/convert-powerpoint-to-html/) を参照してください。本記事はエクスポート時の画像リンク部分に焦点を当てています。

## **リンクされた画像エクスポートの仕組み**

.NET と Java では、[ILinkEmbedController](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/ilinkembedcontroller/) は、エクスポーターがリソースを埋め込むかリンクするかを決定するために使用するコールバックインターフェイスを表します。.NET 経由の Python では、Python クラスは現在この .NET コールバックインターフェイスを直接実装できないため、実際のワークフローは次のとおりです：

1. [HtmlOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/htmloptions/) を使用してプレゼンテーションを HTML にエクスポートする。
2. [SlideImageFormat](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/slideimageformat/) と [SVGOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/svgoptions/) を使用し、スライドを HTML 内で SVG として表現する。
3. HTML の `data:` URL から Base64 画像データを別ファイルに移動する。
4. 元の `data:` URL を `assets/resource-1.jpg` のような相対リンクに置き換える。

ファイルシステムのパスとブラウザの URL は別々の概念です。例えば、以下のサンプルは画像ファイルをディスク上の `html-output/assets` に書き込み、HTML には `assets/resource-1.jpg` のような相対 URL が含まれます。ブラウザはリンクを含む HTML ファイルを基準にこれらの URL を解決します。

## **リンク画像付き HTML のエクスポート**

以下の Python の例は出力ディレクトリを作成し、HTML ファイルをその中に保存し、抽出した画像を `assets` サブディレクトリに格納し、Base64 画像 URL を相対リンクに書き換えます。この例は Aspose.Slides が安全なファイル拡張子を提供する場合に、一般的な Base64 画像フォーマットを抽出します。認識されないデータ URL は埋め込まれたままです。

```python
import base64
import os
import re

import aspose.slides as slides
import aspose.slides.export as slides_export


EXTENSIONS_BY_CONTENT_TYPE = {
    "image/jpeg": ".jpg",
    "image/png": ".png",
    "image/gif": ".gif",
    "image/bmp": ".bmp",
    "image/svg+xml": ".svg",
    "image/tiff": ".tiff",
    "image/x-emf": ".emf",
    "image/x-wmf": ".wmf",
}

DATA_URI_PATTERN = re.compile(
    r"data:(?P<content_type>[-\w.+]+/[-\w.+]+);base64,(?P<data>[A-Za-z0-9+/=\r\n]+)"
)


def export_presentation_to_html_with_linked_images(
    input_file_path,
    output_directory,
    asset_directory_name="assets",
):
    asset_directory = os.path.join(output_directory, asset_directory_name)

    os.makedirs(output_directory, exist_ok=True)
    os.makedirs(asset_directory, exist_ok=True)

    html_options = slides_export.HtmlOptions()
    html_options.html_formatter = slides_export.HtmlFormatter.create_document_formatter("", False)
    html_options.slide_image_format = slides_export.SlideImageFormat.svg(
        slides_export.SVGOptions()
    )

    html_file_path = os.path.join(output_directory, "presentation.html")

    with slides.Presentation(input_file_path) as presentation:
        presentation.save(html_file_path, slides_export.SaveFormat.HTML, html_options)

    externalize_base64_images(html_file_path, asset_directory, asset_directory_name)


def externalize_base64_images(html_file_path, asset_directory, asset_directory_name):
    with open(html_file_path, "r", encoding="utf-8-sig") as html_file:
        html_content = html_file.read()

    saved_resource_names = {}
    resource_index = 1

    def replace_data_uri(match):
        nonlocal resource_index

        data_uri = match.group(0)
        if data_uri in saved_resource_names:
            return saved_resource_names[data_uri]

        content_type = match.group("content_type").lower()
        extension = EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if extension is None:
            return data_uri

        encoded_data = match.group("data")
        image_data = base64.b64decode(encoded_data)
        if len(image_data) == 0:
            return data_uri

        file_name = f"resource-{resource_index}{extension}"
        resource_index += 1

        file_path = os.path.join(asset_directory, file_name)
        with open(file_path, "wb") as image_file:
            image_file.write(image_data)

        linked_url = f"{asset_directory_name}/{file_name}"
        saved_resource_names[data_uri] = linked_url
        return linked_url

    updated_html_content = DATA_URI_PATTERN.sub(replace_data_uri, html_content)

    with open(html_file_path, "w", encoding="utf-8", newline="\n") as html_file:
        html_file.write(updated_html_content)


input_file_path = "presentation.pptx"
output_directory = "html-output"

export_presentation_to_html_with_linked_images(input_file_path, output_directory)
```

エクスポート後、出力フォルダーは以下の構造になる場合があります：

```text
html-output/
  presentation.html
  assets/
    resource-1.jpg
    resource-2.png
```

正確なファイルはプレゼンテーションの内容とエクスポートオプションに依存します。例えば、ラスタ画像は一般的に JPEG または PNG としてエクスポートされます。Aspose.Slides は、ソースプレゼンテーションで使用されているものとは異なる画像コーデックを選択することがあり、サイズが小さくなるか、より適切なファイルになる場合があります。透過性を含む画像は PNG としてエクスポートされます。

## **デプロイ時の URL の選択**

サンプルは相対 URL プレフィックス `assets/` を使用しています。`presentation.html` を `html-output/presentation.html` から開くと、ブラウザは `html-output/assets/resource-1.jpg` を読み込みます。

ファイルを別の場所にデプロイする場合は、別のアセットディレクトリ名を使用するか、生成されたリンクを書き換えてください：

- `assets/` を使用すると、アセットディレクトリが HTML ファイルと同じ場所にある場合です。
- `../assets/` を使用すると、アセットディレクトリが HTML ファイルの 1 つ上の階層にある場合です。
- `https://cdn.example.com/presentations/job-123/assets/` を使用すると、ファイルが CDN や静的ファイルサーバーにアップロードされる場合です。

サーバーアプリケーションでは、変換ジョブごとに一意の出力ディレクトリまたはオブジェクトストレージのプレフィックスを使用し、別のエクスポートからのファイルが上書きされるのを防ぎます。

## **埋め込みにすべきケース**

埋め込みの Base64 HTML は、出力がメール添付やオフラインプレビュー、サポートするアセットフォルダーなしで移動できるドキュメントなど、単一ファイルである必要がある場合に依然として有用です。リンク画像は、HTML が Web アプリケーションで配信されたり、CMS に保存されたり、ビルドパイプラインで最適化されたり、ブラウザが HTML とは別にキャッシュする場合に適しています。

## **FAQ**

**画像だけを外部化し、他のリソースは埋め込んだままにできますか？**

はい。サンプルは `EXTENSIONS_BY_CONTENT_TYPE` に列挙されているコンテンツタイプの `image/*` Base64 データ URL のみを抽出します。他のデータ URL は埋め込まれたままです。

**エクスポートされた画像の拡張子が元のプレゼンテーションと異なるのはなぜですか？**

Aspose.Slides は、サイズやブラウザ互換性を向上させるために、HTML エクスポート時にラスタ画像を再エンコードすることがあります。例えば、元ファイルの画像がレンダリング結果に応じて JPEG や PNG として書き出されることがあります。

**HTML ファイルを移動した後でも相対 URL は機能しますか？**

相対 URL は、同じ相対フォルダー構造が維持されている場合にのみ機能します。HTML が `assets/resource-1.png` を参照している場合、別の URL プレフィックスを生成しない限り、`assets` フォルダーは HTML ファイルの隣に残っていなければなりません。

**サーバーアプリケーションは同じ出力フォルダーを再利用すべきですか？**

いいえ。変換ジョブごとに一意の出力ディレクトリやストレージプレフィックスを使用してください。これにより、ファイル名の衝突を防ぎ、あるエクスポートが別のエクスポートで生成されたリソースを上書きすることを防止できます。