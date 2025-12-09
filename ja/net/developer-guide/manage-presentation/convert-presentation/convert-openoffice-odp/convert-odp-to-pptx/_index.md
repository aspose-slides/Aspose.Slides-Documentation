---
title: ".NET で ODP を PPTX に変換"
linktitle: "ODP を PPTX に変換"
type: docs
weight: 10
url: /ja/net/convert-odp-to-pptx/
keywords:
- "OpenDocument を変換"
- "プレゼンテーションを変換"
- "スライドを変換"
- "ODP を変換"
- "OpenDocument を PPTX に変換"
- "ODP を PPTX に変換"
- "ODP を PPTX として保存"
- "ODP を PPTX にエクスポート"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET を使用して ODP を PPTX に変換します。クリーンな C# コード例、バッチのヒント、高品質な結果を実現—PowerPoint は不要です。"
---

## **概要**

- [C# ODPをPPTXに変換](#csharp-odp-to-pptx)
- [C# ODPをPowerPointに変換](#csharp-odp-to-powerpoint)

## **ODPからPPTXへの変換**

Aspose.Slides for .NET は、プレゼンテーション ファイルを表す Presentation クラスを提供します。 [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスは、オブジェクトがインスタンス化される際に Presentation コンストラクタを介して ODP にもアクセスできるようになりました。以下の例は、ODP プレゼンテーションを PPTX プレゼンテーションに変換する方法を示しています。

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>手順: C#でODPをPPTXに変換</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>手順: C#でODPをPowerPointに変換</strong></a>
```c#
// ODP ファイルを開く
Presentation pres = new Presentation("AccessOpenDoc.odp");

// ODP プレゼンテーションを PPTX 形式で保存
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```


## **ライブ例**

Aspose.Slides API を使用して構築された [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) Web アプリにアクセスできます。このアプリは、Aspose.Slides API を使用して ODP から PPTX への変換を実装する方法を示しています。

## **よくある質問**

**ODP を PPTX に変換するために Microsoft PowerPoint や LibreOffice をインストールする必要がありますか？**

いいえ。Aspose.Slides は単体で動作し、ODP/PPTX の読み書きにサードパーティ アプリケーションを必要としません。

**変換中にマスタースライド、レイアウト、テーマは保持されますか？**

はい。このライブラリは完全なプレゼンテーション オブジェクト モデルを使用し、マスタースライドやレイアウトを含む構造を保持するため、変換後もデザインが正しく保たれます。

**パスワードで保護された ODP ファイルを変換できますか？**

はい。Aspose.Slides は保護の検出をサポートしており、パスワードを指定すれば [protected presentations](/slides/ja/net/password-protected-presentation/)（ODP を含む）を開いて操作できます。また、暗号化の設定やドキュメント プロパティへのアクセスも可能です。

**Aspose.Slides はクラウドや REST ベースの変換サービスに適していますか？**

はい。ローカル ライブラリを自分のバックエンドで使用することも、[Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/)（REST API）を使用することもできます。どちらのオプションでも ODP → PPTX 変換をサポートしています。