---
title: JavaでPPTをPPTXに変換
linktitle: PPTをPPTXに変換
type: docs
weight: 20
url: /java/convert-ppt-to-pptx/
keywords: "Java PPTをPPTXに変換, JavaでのPowerPoint PPTからPPTX"
description: "JavaでPowerPoint PPTをPPTXに変換します。"
---

## **概要**

この記事では、Javaを使用してPPT形式のPowerPointプレゼンテーションをPPTX形式に変換する方法と、オンラインのPPTからPPTXへの変換アプリについて説明します。以下のトピックが含まれています。

- JavaでPPTをPPTXに変換

## **JavaでPPTをPPTXに変換**

PPTをPPTXに変換するためのJavaサンプルコードについては、以下のセクション、すなわち [PPTをPPTXに変換](#convert-ppt-to-pptx) をご覧ください。これは、PPTファイルを読み込み、PPTX形式で保存するだけです。異なる保存形式を指定することで、PPTファイルをPDF、XPS、ODP、HTMLなど、これらの記事で説明されているように多くの他の形式に保存することもできます。

- [JavaでPPTをPDFに変換](https://docs.aspose.com/slides/java/convert-powerpoint-to-pdf/)
- [JavaでPPTをXPSに変換](https://docs.aspose.com/slides/java/convert-powerpoint-to-xps/)
- [JavaでPPTをHTMLに変換](https://docs.aspose.com/slides/java/convert-powerpoint-to-html/)
- [JavaでPPTをODPに変換](https://docs.aspose.com/slides/java/save-presentation/)
- [JavaでPPTを画像に変換](https://docs.aspose.com/slides/java/convert-powerpoint-to-png/)

## **PPTからPPTXへの変換について**
古いPPT形式をAspose.Slides APIを使用してPPTXに変換します。数千のPPTプレゼンテーションをPPTX形式に変換する必要がある場合、最良の解決策はプログラム的に実行することです。Aspose.Slides APIを使用すると、数行のコードでこれを実現できます。APIは、PPTプレゼンテーションをPPTXに変換するための完全な互換性をサポートしており、以下が可能です。

- マスター、レイアウト、スライドの複雑な構造を変換。
- チャートを使用したプレゼンテーションを変換。
- グループシェイプ、自動シェイプ（長方形や楕円など）、カスタムジオメトリのあるシェイプを使用したプレゼンテーションを変換。
- 自動シェイプ用のテクスチャや画像の塗りつぶしスタイルを持つプレゼンテーションを変換。
- プレースホルダー、テキストフレーム、およびテキストホルダーを含むプレゼンテーションを変換。

{{% alert color="primary" %}} 

[**Aspose.Slides PPTをPPTXに変換**](https://products.aspose.app/slides/conversion/ppt-to-pptx)アプリをチェックしてください：

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

このアプリは、[**Aspose.Slides API**](https://products.aspose.com/slides/java/)に基づいて構築されているため、基本的なPPTからPPTXへの変換機能のライブ例を見ることができます。Aspose.Slides Conversionはウェブアプリであり、PPT形式のプレゼンテーションファイルをドラッグ＆ドロップし、PPTXに変換してダウンロードできます。

他のライブ[**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/)の例を見つけてください。
{{% /alert %}} 

## **PPTをPPTXに変換**
Aspose.Slides for Javaは、開発者が[PPTX](https://docs.fileformat.com/presentation/pptx/)形式の[PPT](https://docs.fileformat.com/presentation/ppt/)をアクセスし、それを対応する形式に変換するための[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)クラスのインスタンスを使用できるようにします。現在、[PPT](https://docs.fileformat.com/presentation/ppt/)からPPTXへの部分的な変換をサポートしています。PPTからPPTXへの変換でサポートされている機能とサポートされていない機能に関する詳細については、このドキュメントの[リンク](/slides/java/ppt-to-pptx-conversion/)に進んでください。

Aspose.Slides for Javaは、**PPTX**プレゼンテーションファイルを表す[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)クラスを提供します。Presentationクラスは、オブジェクトがインスタンス化されると、Presentationを通じて**PPT**にアクセスすることもできます。以下の例は、PPTプレゼンテーションをPPTXプレゼンテーションに変換する方法を示しています。

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
|**図：ソースPPTプレゼンテーション**|

上記のコードスニペットは、変換後に以下のPPTXプレゼンテーションを生成しました。

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**図：変換後に生成されたPPTXプレゼンテーション**|