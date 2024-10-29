---
title: PPTとPPTX
type: docs
weight: 10
url: /ja/java/ppt-vs-pptx/
keywords: "PPTとPPTX"
description: "Aspose.SlidesにおけるPPTとPPTXの違いについて読んでみましょう。"
---


## **PPTとは何ですか？**
[**PPT**](https://docs.fileformat.com/presentation/ppt/)はバイナリファイルフォーマットです。つまり、特別なツールがなければその内容を見ることはできません。最初のPowerPoint 97-2003バージョンはPPTファイルフォーマットを使用していましたが、その拡張性は限られています。
## **PPTXとは何ですか？**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/)は、Office Open XML（ISO 29500:2008-2016、ECMA-376）標準に基づく新しいプレゼンテーションファイルフォーマットです。PPTXはXMLおよびメディアファイルのアーカイブセットです。PPTXフォーマットは容易に拡張可能です。たとえば、PPTXフォーマットを変更することなく、新しいチャートタイプまたは形状タイプのサポートを追加することが簡単です。PPTXフォーマットはPowerPoint 2007から使用されています。
## **PPTとPPTXの違い**
PPTXははるかに広範な機能を提供しますが、PPTは依然として非常に人気があります。PPTからPPTX、またその逆に変換する必要性は非常に高いです。

しかし、古いPPTと新しいPPTXフォーマット間の変換は、他のMicrosoft Officeフォーマットの中でも最も複雑な課題です。PPTフォーマットの仕様はオープンですが、扱うのは難しいです。PowerPointは、PPTファイル内に情報を格納するために特別な部分（MetroBlob）を作成できます。この情報は、PPT形式でサポートされておらず、古いPowerPointバージョンでは表示できません。この情報は、現代のPowerPointバージョンでPPTファイルが読み込まれるか、PPTXフォーマットに変換されるときに復元されることがあります。

Aspose.Slidesは、すべてのプレゼンテーションフォーマットで作業するための共通インターフェースを提供します。PPTからPPTX、PPTXからPPTへの非常に簡単な方法での変換を可能にします。Aspose.SlidesはPPTからPPTXへの変換を完全にサポートしており、またいくつかの制限付きでPPTXからPPTへの変換もサポートしています。可能な限りPPTXフォーマットの使用を推奨します。

{{% alert color="primary" %}} 

オンラインでPPTからPPTX、PPTXからPPTの変換の質を確認してください。[**Aspose.Slides Conversion app**](https://products.aspose.app/slides/conversion/)。

{{% /alert %}} 

```java
// PPTファイルを表すPresentationオブジェクトをインスタンス化する
Presentation pres = new Presentation("PPTtoPPTX.ppt");
try {
// PPTプレゼンテーションをPPTXフォーマットに保存する
    pres.save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
プレゼンテーションのPPTからPPTXへの変換方法についてさらに読む [**こちら**](/slides/ja/java/convert-ppt-to-pptx/)。
{{% /alert %}} 