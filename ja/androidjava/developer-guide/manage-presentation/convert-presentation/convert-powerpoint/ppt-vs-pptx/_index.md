---
title: PPTとPPTXの違い
type: docs
weight: 10
url: /androidjava/ppt-vs-pptx/
keywords: "PPT vs PPTX"
description: "Aspose.SlidesにおけるPPTとPPTXの違いについてお読みください。"
---


## **PPTとは？**
[**PPT**](https://docs.fileformat.com/presentation/ppt/)はバイナリファイル形式であり、特別なツールなしにはその内容を見ることはできません。初めてのPowerPoint 97-2003バージョンはPPTファイル形式で動作しましたが、その拡張性は限られています。
## **PPTXとは？**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/)は、新しいプレゼンテーションファイル形式で、Office Open XML（ISO 29500:2008-2016、ECMA-376）標準に基づいています。PPTXはXMLとメディアファイルのアーカイブセットです。PPTX形式は簡単に拡張できます。たとえば、新しいチャートタイプや形状タイプのサポートを追加するのが簡単で、すべての新しいPowerPointバージョンでPPTX形式を変更する必要はありません。PPTX形式はPowerPoint 2007から使用されています。
## **PPTとPPTXの違い**
PPTXはより広範な機能を提供していますが、PPTは依然として非常に人気があります。PPTからPPTXへの変換やその逆の必要性は非常に高いです。

しかし、古いPPTと新しいPPTX形式の間の変換は、他のMicrosoft Office形式の中で最も複雑な課題です。PPT形式の仕様は公開されていますが、扱うのは難しいです。PowerPointは、PPTXがPPT形式でサポートされていない情報を保存するために、PPTファイルに特別な部分（MetroBlob）を作成できます。この情報は、PPTファイルが現代のPowerPointバージョンで読み込まれるか、PPTX形式に変換されると復元できます。

Aspose.Slidesは、すべてのプレゼンテーション形式で作業するための共通インターフェースを提供します。PPTからPPTXへ、またPPTXからPPTへ非常に簡単に変換することができます。Aspose.SlidesはPPTからPPTXへの変換を完全にサポートしており、PPTXからPPTへの変換もいくつかの制限があるもののサポートしています。可能な限りPPTX形式を使用することをお勧めします。

{{% alert color="primary" %}} 

オンラインでPPTからPPTX、およびPPTXからPPTの変換の品質を確認してください。[**Aspose.Slides変換アプリ**](https://products.aspose.app/slides/conversion/)。

{{% /alert %}} 

```java
// PPTファイルを表すPresentationオブジェクトをインスタンス化
Presentation pres = new Presentation("PPTtoPPTX.ppt");
try {
// PPTプレゼンテーションをPPTX形式で保存
    pres.save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
プレゼンテーションのPPTからPPTXへの変換方法についてもっと読む[**こちら**](/slides/androidjava/convert-ppt-to-pptx/)。
{{% /alert %}} 