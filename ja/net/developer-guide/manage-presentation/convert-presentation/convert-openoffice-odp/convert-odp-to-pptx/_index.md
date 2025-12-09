---
title: .NET で ODP を PPTX に変換
linktitle: ODP を PPTX に変換
type: docs
weight: 10
url: /ja/net/convert-odp-to-pptx/
keywords:
- OpenDocument を変換
- ODP を変換
- OpenDocument を PPTX に変換
- ODP を PPTX に変換
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して ODP を PPTX に変換します。クリーンな C# コード例、バッチ処理のヒント、そして高品質な結果を提供し、PowerPoint は不要です。"
---

## **概要**

この記事では次のトピックについて説明します。

- [C# ODPをPPTXに変換](#csharp-odp-to-pptx)
- [C# ODPをPowerPointに変換](#csharp-odp-to-powerpoint)

## **ODPからPPTXへの変換**

Aspose.Slides for .NET は、プレゼンテーション ファイルを表す Presentation クラスを提供します。[**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスは、オブジェクトがインスタンス化されたときに Presentation コンストラクタを通じて ODP にもアクセスできるようになりました。以下の例は、ODP プレゼンテーションを PPTX プレゼンテーションに変換する方法を示しています。

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>手順: C#でODPをPPTXに変換</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>手順: C#でODPをPowerPointに変換</strong></a>
```c#
// ODP ファイルを開く
Presentation pres = new Presentation("AccessOpenDoc.odp");

// ODP プレゼンテーションを PPTX 形式で保存
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```


## **ライブ例**

以下の[**Aspose.Slides 変換**](https://products.aspose.app/slides/conversion/) Web アプリにアクセスできます。このアプリは **Aspose.Slides API** を使用して構築されており、ODP から PPTX への変換を Aspose.Slides API で実装する方法を示しています。

## **よくある質問**

**ODP を PPTX に変換するために Microsoft PowerPoint または LibreOffice をインストールする必要がありますか？**

いいえ。Aspose.Slides はスタンドアロンで動作し、ODP/PPTX の読み書きにサードパーティ アプリケーションを必要としません。

**変換時にマスタースライド、レイアウト、テーマは保持されますか？**

はい。ライブラリは完全なプレゼンテーション オブジェクト モデルを使用し、マスタースライドやレイアウトを含む構造を保持するため、変換後もデザインが正しく保たれます。

**パスワードで保護された ODP ファイルを変換できますか？**

はい。Aspose.Slides は保護の検出をサポートし、パスワードを提供すれば[保護されたプレゼンテーション](/slides/ja/net/password-protected-presentation/)（ODP を含む）を開いて操作でき、暗号化やドキュメント プロパティへのアクセスも構成できます。

**Aspose.Slides はクラウドや REST ベースの変換サービスに適していますか？**

はい。ローカル ライブラリを独自のバックエンドで使用するか、[Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/)（REST API）を使用できます。どちらのオプションも ODP → PPTX 変換をサポートしています。