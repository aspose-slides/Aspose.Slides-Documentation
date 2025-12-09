---
title: .NET で ODP を PPTX に変換
linktitle: ODP を PPTX に変換
type: docs
weight: 10
url: /ja/net/convert-odp-to-pptx/
keywords:
- OpenDocument を変換
- ODP を変換
- OpenDocument から PPTX へ
- ODP から PPTX へ
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して ODP を PPTX に変換します。クリーンな C# コード例、バッチのヒント、高品質な結果を提供し、PowerPoint は不要です。"
---

## **概要**

この記事では次のトピックについて説明します。

- [C# ODP を PPTX に変換](#csharp-odp-to-pptx)
- [C# ODP を PowerPoint に変換](#csharp-odp-to-powerpoint)

## **ODP から PPTX への変換**

Aspose.Slides for .NET はプレゼンテーション ファイルを表す Presentation クラスを提供します。[**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスは、オブジェクトをインスタンス化する際の Presentation コンストラクタを通じて ODP にもアクセスできるようになりました。以下の例は、ODP プレゼンテーションを PPTX プレゼンテーションに変換する方法を示します。

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>Steps: Convert ODP to PPTX in C#</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>Steps: Convert ODP to PowerPoint in C#</strong></a>
```c#
// ODP ファイルを開く
Presentation pres = new Presentation("AccessOpenDoc.odp");

// ODP プレゼンテーションを PPTX 形式で保存
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```


## **ライブ例**

Aspose.Slides API を使用して構築された [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) Web アプリにアクセスできます。このアプリは、Aspose.Slides API を使用して ODP から PPTX への変換を実装する方法を示しています。

## **FAQ**

**ODP を PPTX に変換するために Microsoft PowerPoint または LibreOffice をインストールする必要がありますか？**

いいえ。Aspose.Slides は単体で動作し、ODP/PPTX の読み書きにサードパーティのアプリケーションは不要です。

**変換中にマスタースライド、レイアウト、テーマは保持されますか？**

はい。ライブラリは完全なプレゼンテーション オブジェクト モデルを使用し、マスタースライドやレイアウトを含む構造を保持するため、変換後もデザインが正しく保たれます。

**パスワードで保護された ODP ファイルを変換できますか？**

はい。Aspose.Slides は保護の検出、パスワードを提供することで [protected presentations](/slides/ja/net/password-protected-presentation/)（ODP を含む）を開いて操作できるほか、暗号化やドキュメント プロパティへのアクセスの設定もサポートします。

**Aspose.Slides はクラウドや REST ベースの変換サービスに適していますか？**

はい。ローカル ライブラリを自分のバックエンドで使用することも、[Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/)（REST API）を使用することも可能で、いずれのオプションも ODP → PPTX 変換をサポートします。