---
title: PPTとPPTX
type: docs
weight: 10
url: /ja/net/ppt-vs-pptx/
keywords: "PPTとPPTX, PPTまたはPPTX, PowerPointプレゼンテーション, フォーマット, C#, Csharp, .NET"
description: "PowerPointプレゼンテーションフォーマットについて。PPTとPPTX。C#または.NETでの違い"
---

## **PPTとは？**
[**PPT**](https://docs.fileformat.com/presentation/ppt/)は、バイナリファイルフォーマットであり、特別なツールなしではその内容を表示することはできません。最初のPowerPoint 97-2003バージョンはPPTファイルフォーマットで動作しましたが、その拡張性は限られています。

## **PPTXとは？**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/)は、Office Open XML (ISO 29500:2008-2016, ECMA-376)標準に基づく新しいプレゼンテーションファイルフォーマットです。PPTXは、XMLとメディアファイルのアーカイブされたセットです。PPTXフォーマットは簡単に拡張可能です。たとえば、新しいグラフタイプやシェイプタイプのサポートを追加することが容易であり、すべての新しいPowerPointバージョンでPPTXフォーマットを変更する必要がありません。PPTXフォーマットはPowerPoint 2007から使用されています。

## **PPTとPPTX**
PPTXはより広範な機能を提供しますが、PPTは依然として非常に人気があります。PPTからPPTXへの変換、およびその逆の必要性は高い需要があります。

しかし、古いPPTと新しいPPTXフォーマット間の変換は、他のMicrosoft Officeフォーマットの中で最も複雑な課題です。PPTフォーマットの仕様はオープンですが、それを扱うのは困難です。PowerPointは、PPTファイル内に特別な部分（MetroBlob）を作成して、PPTフォーマットではサポートされず、古いPowerPointバージョンでは表示できないPPTXからの情報を保存できます。この情報は、PPTファイルが現代のPowerPointバージョンでロードされるか、PPTXフォーマットに変換されるときに復元されます。

Aspose.Slidesは、すべてのプレゼンテーションフォーマットを操作するための共通インターフェースを提供します。これにより、PPTからPPTX、PPTXからPPTへの変換が非常に簡単に行えます。Aspose.SlidesはPPTからPPTXへの変換を完全にサポートしており、一部の制限付きでPPTXからPPTへの変換もサポートしています。可能な限りPPTXフォーマットを使用することをお勧めします。

{{% alert color="primary" %}} 

オンラインでPPTからPPTXおよびPPTXからPPTへの変換品質をチェックしてください。[**Aspose.Slides変換アプリ**](https://products.aspose.app/slides/conversion/)。

{{% /alert %}} 

```c#
// PPTXファイルを表すPresentationオブジェクトをインスタンス化します
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// PPTXプレゼンテーションをPPTXフォーマットで保存します
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```

{{% alert color="primary" %}} 
プレゼンテーションをPPTからPPTXに変換する方法についてもっと読むには[**こちら**.](/slides/ja/net/convert-ppt-to-pptx/)
{{% /alert %}} 