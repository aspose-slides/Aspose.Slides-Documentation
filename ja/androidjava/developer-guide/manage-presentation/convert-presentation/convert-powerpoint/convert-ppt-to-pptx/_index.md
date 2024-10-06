---
title: JavaでPPTをPPTXに変換
linktitle: PPTをPPTXに変換
type: docs
weight: 20
url: /ja/androidjava/convert-ppt-to-pptx/
keywords: "Java PPTをPPTXに変換, PowerPoint PPTをJavaでPPTXに変換"
description: "JavaでPowerPoint PPTをPPTXに変換します。"
---

## **概説**

この記事では、PPT形式のPowerPointプレゼンテーションをJavaを使用してPPTX形式に変換する方法と、オンラインのPPTからPPTXへの変換アプリを使用する方法について説明します。以下のトピックが含まれます。

- JavaでPPTをPPTXに変換

## **JavaでPPTをPPTXに変換**

PPTをPPTXに変換するJavaサンプルコードについては、以下のセクション[Convert PPT to PPTX](#convert-ppt-to-pptx)をご覧ください。これはPPTファイルを読み込み、PPTX形式で保存するだけです。異なる保存形式を指定することで、PPTファイルをPDF、XPS、ODP、HTMLなどの他の多くの形式に保存することもできます。これらのリソースで説明されています。

- [JavaでPPTをPDFに変換](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-pdf/)
- [JavaでPPTをXPSに変換](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-xps/)
- [JavaでPPTをHTMLに変換](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-html/)
- [JavaでPPTをODPに変換](https://docs.aspose.com/slides/androidjava/save-presentation/)
- [JavaでPPTを画像に変換](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-png/)

## **PPTからPPTXへの変換について**
古いPPT形式をPPTXに変換するにはAspose.Slides APIをご利用ください。数千のPPTプレゼンテーションをPPTX形式に変換する必要がある場合、プログラム的に行うのが最良の解決策です。Aspose.Slides APIを使用すると、数行のコードでそれを実現できます。このAPIは、PPTプレゼンテーションをPPTXに変換するための完全な互換性をサポートしており、次のことが可能です。

- マスター、レイアウト、スライドの複雑な構造を変換します。
- チャートを含むプレゼンテーションを変換します。
- グループシェイプ、自動シェイプ（長方形や楕円形など）、カスタムジオメトリを持つシェイプを含むプレゼンテーションを変換します。
- 自動シェイプのテクスチャと画像の塗りつぶしスタイルを持つプレゼンテーションを変換します。
- プレースホルダー、テキストフレーム、およびテキストホルダーを含むプレゼンテーションを変換します。

{{% alert color="primary" %}} 

[**Aspose.Slides PPTからPPTXへの変換**](https://products.aspose.app/slides/conversion/ppt-to-pptx)アプリをご覧ください：

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

このアプリは[**Aspose.Slides API**](https://products.aspose.com/slides/androidjava/)に基づいて構築されており、基本的なPPTからPPTXへの変換機能のライブ例を確認できます。Aspose.Slides Conversionはウェブアプリで、PPT形式のプレゼンテーションファイルをドロップしてPPTX形式に変換したものをダウンロードできます。

他のライブ[**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/)の例をご覧ください。
{{% /alert %}} 

## **PPTをPPTXに変換**
Java経由のAspose.Slides for Androidは、開発者が[PPT](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)クラスのインスタンスを使用してPPTにアクセスし、それを対応する[PPTX](https://docs.fileformat.com/presentation/pptx/)形式に変換できるようにします。現在、[PPT](https://docs.fileformat.com/presentation/ppt/)をPPTXに部分的に変換することをサポートしています。PPTからPPTXへの変換でサポートされている機能とサポートされていない機能の詳細については、このドキュメントの[リンク](/slides/ja/androidjava/ppt-to-pptx-conversion/)をご覧ください。

Java経由のAspose.Slides for Androidは、**PPTX**プレゼンテーションファイルを表す[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)クラスを提供します。Presentationクラスは、オブジェクトがインスタンス化されるときに**PPT**にアクセスすることもできます。以下の例は、PPTプレゼンテーションをPPTXプレゼンテーションに変換する方法を示しています。

```java
// PPTXファイルを表すPresentationオブジェクトをインスタンス化
Presentation pres = new Presentation("Aspose.ppt");
try {
// PPTX形式でPPTXプレゼンテーションを保存
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**図 : ソースPPTプレゼンテーション**|

上記のコードスニペットは、変換後に次のPPTXプレゼンテーションを生成しました。

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**図: 変換後の生成されたPPTXプレゼンテーション**|