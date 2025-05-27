---
title: PPT と PPTX の違いを理解する
linktitle: PPT と PPTX
type: docs
weight: 10
url: /ja/python-net/ppt-vs-pptx/
keywords:
- PPT と PPTX の違い
- PPTX と PPT の違い
- PowerPoint 形式
- プレゼンテーション形式
- PPT を PPTX に変換
- レガシー形式
- 最新標準
- .NET
- C#
- Aspose.Slides
description: "PPT と PPTX 形式の主な違いを探り、C# と .NET 環境での利用方法を学びます。"
---


## **PPTとは？**
[**PPT**](https://docs.fileformat.com/presentation/ppt/)はバイナリファイルフォーマットであり、特別なツールなしにはその内容を表示することはできません。最初のPowerPoint 97-2003バージョンはPPTファイルフォーマットで動作していましたが、その拡張性は制限されています。
## **PPTXとは？**
[**PPTX**](https://docs.fileformat.com/presentation/pptx/)は、新しいプレゼンテーションファイルフォーマットで、Office Open XML（ISO 29500:2008-2016、ECMA-376）標準に基づいています。PPTXはXMLおよびメディアファイルのアーカイブセットです。PPTXフォーマットは簡単に拡張可能です。例えば、新しいチャートタイプや形状タイプをサポートすることが容易であり、すべての新しいPowerPointバージョンでPPTXフォーマットを変更する必要はありません。PPTXフォーマットはPowerPoint 2007から使用されています。

## **PPTとPPTX**
PPTXははるかに広い機能を提供しますが、PPTは依然として非常に人気があります。PPTからPPTXへの変換とその逆の必要性は非常に高いです。

しかし、古いPPTと新しいPPTXフォーマット間の変換は、他のMicrosoft Officeフォーマットの中で最も複雑な課題です。PPTフォーマットの仕様はオープンですが、扱うのは難しいです。PowerPointは、PPTフォーマットではサポートされておらず、古いPowerPointバージョンでは表示できない情報を保存するために、PPTファイル内に特別な部分（MetroBlob）を作成することができます。この情報は、PPTファイルが新しいPowerPointバージョンでロードされるか、PPTXフォーマットに変換されると復元されることができます。

Aspose.Slidesは、すべてのプレゼンテーションフォーマットを扱うための共通インターフェースを提供します。これにより、PPTからPPTXへ、PPTXからPPTへ非常に簡単に変換できます。Aspose.SlidesはPPTからPPTXへの変換を完全にサポートしており、またPPTXからPPTへの変換もいくつかの制限付きでサポートしています。可能な限りPPTXフォーマットを使用することをお勧めします。

{{% alert color="primary" %}} 

オンラインでPPTからPPTXおよびPPTXからPPTへの変換の品質を確認するには、[**Aspose.Slides Conversion app**](https://products.aspose.app/slides/conversion/)をチェックしてください。

{{% /alert %}} 

```py
import aspose.slides as slides

# PPTXファイルを表すPresentationオブジェクトをインスタンス化します
pres = slides.Presentation("PPTtoPPTX.ppt")

# PPTXプレゼンテーションをPPTXフォーマットに保存します
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 
プレゼンテーションPPTをPPTXに変換する方法について、さらに読むには [**こちら**](/slides/ja/python-net/convert-ppt-to-pptx/)をクリックしてください。
{{% /alert %}} 