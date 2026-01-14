---
title: Pythonで外部リンク画像付きHTMLへのプレゼンテーションエクスポート
linktitle: 外部リンク画像付きHTMLへのプレゼンテーションエクスポート
type: docs
weight: 100
url: /ja/python-net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPointのエクスポート
- OpenDocumentのエクスポート
- プレゼンテーションのエクスポート
- スライドのエクスポート
- PPTのエクスポート
- PPTXのエクスポート
- ODPのエクスポート
- PowerPointからHTMLへ
- OpenDocumentからHTMLへ
- プレゼンテーションからHTMLへ
- スライドからHTMLへ
- PPTからHTMLへ
- PPTXからHTMLへ
- ODPからHTMLへ
- リンクされた画像
- 外部リンク画像
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NETで、PowerPointおよびOpenDocument形式のプレゼンテーションを外部リンク画像付きHTMLにエクスポートする方法を学びます。"
---

{{% alert color="primary" %}} 

プレゼンテーションからHTMLへのエクスポートプロセスでは、次のことを指定できます：

1. 結果のHTMLファイルに埋め込むリソースを指定します。
1. HTMLファイルから参照される外部に保存されるリソースを指定します。

{{% /alert %}} 

## **背景**

デフォルトでは、HTML エクスポートはすべてのリソースを Base64 エンコーディングを使用して HTML に直接埋め込みます。これにより、閲覧や配布に便利な単一の自己完結型 HTML ファイルが生成されます。ただし、このアプローチには欠点があります：

* 結果のファイルは Base64 のオーバーヘッドにより、元のリソースよりもかなり大きくなります。
* 埋め込まれた画像やその他のアセットは、更新や置換が困難です。

## **代替アプローチ**

[ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) を使用した代替アプローチは、これらの制限を回避します。

`LinkController` クラスは以下のように [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) を実装し、[HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/__init__/#ilinkembedcontroller) コンストラクタに渡されます。このクラスは、HTML エクスポート時にリソースの埋め込みまたはリンク方法を制御する 3 つのメソッドを公開します：

[get_object_storing_location(id, entity_data, semantic_name, content_type, recommended_extension)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/get_object_storing_location/#int-bytes-str-str-str): エクスポーターがリソースに遭遇し、保存先を決定する必要がある際に呼び出されます。最も重要なパラメータは `id`（このエクスポート実行のリソース固有の識別子）と `content_type`（リソースの MIME タイプ）です。リソースをリンクするには [LinkEmbedDecision.LINK](https://reference.aspose.com/slides/python-net/aspose.slides.export/linkembeddecision/) を、埋め込むには [LinkEmbedDecision.EMBED](https://reference.aspose.com/slides/python-net/aspose.slides.export/linkembeddecision/) を返します。

[get_url(id, referrer)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/get_url/#int-int): `id` で識別されたリソースのために、生成された HTML に表示される URL を返します（必要に応じてリファラーオブジェクトを考慮します）。

[save_external(id, entity_data)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/save_external/#int-bytes): リンク用に選択されたリソースを外部に書き出す必要があるときに呼び出されます。識別子と内容が（バイト配列として）提供されるため、好きな方法でリソースを永続化できます。

Python の `LinkController` による [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) の実装は以下の通りです。
```py
# [TODO[not_supported_yet]: .NET インターフェイスの Python 実装]
```


`LinkController` クラスを実装した後、[HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/htmloptions/) クラスと組み合わせて、プレゼンテーションを外部リンクされた画像付きの HTML にエクスポートできます。以下に示すように：
```py
# [TODO[not_supported_yet]: .NET インターフェイスの Python 実装]
```


`SlideImageFormat.SVG` を `slide_image_format` プロパティに割り当てたので、生成された HTML ファイルにはプレゼンテーションの内容をレンダリングするための SVG データが含まれます。

コンテンツタイプ: プレゼンテーションにラスタービットマップが含まれる場合、クラスコードは `image/jpeg` と `image/png` の両方のコンテンツタイプを処理できるように準備する必要があります。エクスポートされたビットマップ画像の内容は、プレゼンテーションに保存されているものと一致しない場合があります。Aspose.Slides の内部アルゴリズムはサイズ最適化を行い、JPEG または PNG コーデックのいずれか（ファイルサイズが小さい方）を使用します。アルファチャンネル（透過）を含む画像は常に PNG としてエンコードされます。