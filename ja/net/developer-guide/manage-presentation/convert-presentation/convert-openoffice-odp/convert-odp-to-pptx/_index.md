---
title: C#でODPをPPTXに変換
linktitle: ODPをPPTXに変換
type: docs
weight: 10
url: /ja/net/convert-odp-to-pptx/
keywords: "OpenOfficeプレゼンテーションの変換、ODP、ODPからPPTX、C#、Csharp、.NET"
description: "C#または.NETでOpenOffice ODPをPowerPointプレゼンテーションPPTXに変換"
---

## **概要**

この記事では以下のトピックについて説明します。

- [C# ODP を PPTX に変換](#csharp-odp-to-pptx)
- [C# ODP を PowerPoint に変換](#csharp-odp-to-powerpoint)

## **ODP から PPTX への変換**

Aspose.Slides for .NET は、プレゼンテーション ファイルを表す Presentation クラスを提供します。[**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスは、オブジェクトがインスタンス化されたときに Presentation コンストラクタを介して ODP にもアクセスできるようになりました。以下の例は、ODP プレゼンテーションを PPTX プレゼンテーションに変換する方法を示しています。

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>手順: C# で ODP を PPTX に変換</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>手順: C# で ODP を PowerPoint に変換</strong></a>
```c#
// ODP ファイルを開く
Presentation pres = new Presentation("AccessOpenDoc.odp");

// ODP プレゼンテーションを PPTX 形式で保存
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```


## **ライブ例**

[**Aspose.Slides 変換**](https://products.aspose.app/slides/conversion/) Web アプリで、**Aspose.Slides API** を使用して構築されています。このアプリは、Aspose.Slides API を使用した ODP から PPTX への変換実装方法を示しています。

## **よくある質問**

**ODP を PPTX に変換するために Microsoft PowerPoint や LibreOffice をインストールする必要がありますか？**

いいえ。Aspose.Slides は単体で動作し、ODP/PPTX の読み書きにサードパーティ アプリケーションを必要としません。

**変換中にマスタースライド、レイアウト、テーマは保持されますか？**

はい。このライブラリは完全なプレゼンテーション オブジェクト モデルを使用し、マスタースライドやレイアウトを含む構造を保持するため、変換後もデザインが正しく保たれます。

**パスワードで保護された ODP ファイルを変換できますか？**

はい。Aspose.Slides は保護の検出に対応しており、パスワードを提供すれば [protected presentations](/slides/ja/net/password-protected-presentation/)（ODP を含む）を開いて操作でき、暗号化やドキュメント プロパティへのアクセスも設定できます。

**Aspose.Slides はクラウドや REST ベースの変換サービスに適していますか？**

はい。ローカルのライブラリを自分のバックエンドで使用するか、[Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/)（REST API）を利用できます。いずれのオプションも ODP → PPTX 変換をサポートしています。