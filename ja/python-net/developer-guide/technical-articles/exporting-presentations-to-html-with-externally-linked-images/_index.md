---
title: Pythonで外部リンク画像付きのHTMLにプレゼンテーションをエクスポートする
linktitle: 外部リンク画像付きでHTMLにプレゼンテーションをエクスポート
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
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、外部リンク画像付きでプレゼンテーションをHTMLにエクスポートする方法を学びます。PowerPoint と OpenDocument の形式に対応しています。"
---

{{% alert color="primary" %}} 
プレゼンテーションの HTML エクスポート プロセスでは、次のことを指定できます。

1. どのリソースを結果の HTML ファイルに埋め込むか、  
1. どのリソースを外部に保存し、HTML ファイルから参照するか。  
{{% /alert %}} 

## **背景**

デフォルトでは、HTML エクスポートはすべてのリソースを Base64 エンコードを使用して HTML に直接埋め込みます。これにより、閲覧や配布に便利な単一の自己完結型 HTML ファイルが生成されます。ただし、このアプローチには欠点があります。

* Base64 のオーバーヘッドにより、結果のファイルは元のリソースよりも大幅に大きくなります。  
* 埋め込まれた画像やその他のアセットは更新や置換が難しいです。  

## **代替アプローチ**

[ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) を使用した代替アプローチは、これらの制限を回避します。

以下の `LinkController` クラスは [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) を実装し、[HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/__init__/#ilinkembedcontroller) コンストラクタに渡されます。このクラスは、HTML エクスポート時にリソースを埋め込むかリンクするかを制御する 3 つのメソッドを公開します：

[get_object_storing_location(id, entity_data, semantic_name, content_type, recommended_extension)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/get_object_storing_location/#int-bytes-str-str-str): エクスポーターがリソースに出会い、保存場所を決定しなければならないときに呼び出されます。最も重要なパラメーターは `id`（このエクスポート実行のリソース固有識別子）と `content_type`（リソースの MIME タイプ）です。リソースをリンクする場合は [LinkEmbedDecision.LINK](https://reference.aspose.com/slides/python-net/aspose.slides.export/linkembeddecision/) を、埋め込む場合は [LinkEmbedDecision.EMBED](https://reference.aspose.com/slides/python-net/aspose.slides.export/linkembeddecision/) を返します。

[get_url(id, referrer)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/get_url/#int-int): `id` で識別されるリソースのために、結果の HTML に表示される URL を返します（必要に応じてリファラーオブジェクトを考慮します）。

[save_external(id, entity_data)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/save_external/#int-bytes): リンク用に選択されたリソースを外部に書き込む必要があるときに呼び出されます。識別子と内容（バイト配列）が提供されるため、好きな方法でリソースを永続化できます。

以下に [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) の Python `LinkController` 実装を示します。
```py
# [TODO[not_supported_yet]: .NET インターフェイスの Python 実装]
```


`LinkController` クラスを実装した後、[HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) クラスと組み合わせて、外部リンクされた画像を使用してプレゼンテーションを HTML にエクスポートできます（以下参照）。
```py
# [TODO[not_supported_yet]: python の .NET インターフェイス実装]
```


`slide_image_format` プロパティに `SlideImageFormat.SVG` を割り当てたので、生成される HTML ファイルにはプレゼンテーションの内容を描画するための SVG データが含まれます。

コンテンツタイプ: プレゼンテーションにラスタビットマップが含まれる場合、クラスコードは `image/jpeg` と `image/png` の両方のコンテンツタイプを処理できるように準備する必要があります。エクスポートされたビットマップ画像の内容は、プレゼンテーションに保存されていたものと一致しない場合があります。Aspose.Slides の内部アルゴリズムはサイズ最適化を行い、ファイルサイズが小さくなる方の JPEG または PNG コーデックを使用します。アルファチャンネル（透過）を含む画像は常に PNG としてエンコードされます。