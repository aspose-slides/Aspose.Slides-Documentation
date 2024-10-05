---
title: ODPをC#でPPTXに変換
linktitle: ODPをPPTXに変換
type: docs
weight: 10
url: /net/convert-odp-to-pptx/
keywords: "OpenOfficeプレゼンテーションの変換、ODP、ODPをPPTXに、C#、Csharp、.NET"
description: "C#または.NETでOpenOffice ODPをPowerPointプレゼンテーションPPTXに変換"
---

## 概要

この記事では、以下のトピックについて説明します。

- [C# ODPをPPTXに変換](#csharp-odp-to-pptx)
- [C# ODPをPowerPointに変換](#csharp-odp-to-powerpoint)

## C# ODPからPPTXへの変換

Aspose.Slides for .NETは、プレゼンテーションファイルを表すPresentationクラスを提供しています。[**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスは、オブジェクトがインスタンス化されるときにPresentationコンストラクターを通じてODPにもアクセスできるようになりました。以下の例は、ODPプレゼンテーションをPPTXプレゼンテーションに変換する方法を示しています。

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>手順: C#でODPをPPTXに変換</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>手順: C#でODPをPowerPointに変換</strong></a>

```c#
// ODPファイルを開く
Presentation pres = new Presentation("AccessOpenDoc.odp");

// ODPプレゼンテーションをPPTX形式で保存
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```



## **ライブ例**
[**Aspose.Slides変換**](https://products.aspose.app/slides/conversion/)のWebアプリにアクセスできます。このアプリは**Aspose.Slides API**を使用して構築されています。このアプリは、Aspose.Slides APIを使用してODPからPPTXへの変換を実装する方法を示しています。