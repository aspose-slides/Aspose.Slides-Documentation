---
title: PPTとPPTXの違い
type: docs
weight: 10
url: /ja/php-java/ppt-vs-pptx/
keywords: "PPTとPPTX"
description: "Aspose.SlidesにおけるPPTとPPTXの違いについてお読みください。"
---


## **PPTとは何ですか？**
[**PPT**](https://docs.fileformat.com/presentation/ppt/)はバイナリファイル形式であり、特別なツールなしではその内容を見ることはできません。最初のPowerPoint 97-2003バージョンはPPTファイル形式で動作しましたが、その拡張性は制限されています。
## **PPTXとは何ですか？**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/)は、Office Open XML (ISO 29500:2008-2016, ECMA-376) 標準に基づく新しいプレゼンテーションファイル形式です。PPTXはXMLとメディアファイルのアーカイブセットです。PPTX形式は簡単に拡張可能です。例えば、新しいチャートタイプやシェイプタイプのサポートを追加するのは簡単で、新しいPowerPointバージョンごとにPPTX形式を変更する必要がありません。PPTX形式はPowerPoint 2007以降で使用されます。
## **PPTとPPTX**
PPTXははるかに広範な機能を提供しますが、PPTは依然として非常に人気があります。PPTからPPTX、そしてその逆に変換する必要性は高く求められています。

ただし、古いPPTと新しいPPTX形式の変換は、他のMicrosoft Office形式の中で最も複雑な課題です。PPT形式の仕様はオープンですが、扱うのは難しいです。PowerPointは、PPTファイル内にPPTXがサポートされていない情報を保存するための特別な部分（MetroBlob）を作成することができ、古いPowerPointバージョンで表示できません。この情報は、PPTファイルが最新のPowerPointバージョンで読み込まれたり、PPTX形式に変換されると復元されることがあります。

Aspose.Slidesは、すべてのプレゼンテーション形式で作業するための共通インターフェースを提供します。これにより、PPTからPPTX、PPTXからPPTへの変換が非常に簡単に行えます。Aspose.SlidesはPPTからPPTXへの変換を完全にサポートしており、PPTXからPPTへの変換も一部制限付きでサポートしています。可能な限りPPTX形式を使用することを推奨します。

{{% alert color="primary" %}} 

オンラインの[**Aspose.Slides変換アプリ**](https://products.aspose.app/slides/conversion/)でPPTからPPTX、PPTXからPPTの変換品質を確認してください。

{{% /alert %}} 

```php
  # PPTファイルを表すPresentationオブジェクトをインスタンス化
  $pres = new Presentation("PPTtoPPTX.ppt");
  try {
    # PPTプレゼンテーションをPPTX形式で保存
    $pres->save("PPTtoPPTX_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
プレゼンテーションのPPTからPPTXへの変換方法についての詳細をお読みください。[**PPTをPPTXに変換する方法**](/slides/ja/php-java/convert-ppt-to-pptx/)
{{% /alert %}} 
