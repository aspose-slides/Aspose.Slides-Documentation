---
title: .NET で ODP を PPTX に変換
linktitle: ODP から PPTX
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
description: ".NET 用 Aspose.Slides で ODP を PPTX に変換します。クリーンな C# コード例、バッチ処理のヒント、高品質な結果を実現—PowerPoint は不要です。"
---

## **概要**

この記事では以下のトピックについて説明します。

- [C# ODP を PPTX に変換](#csharp-odp-to-pptx)
- [C# ODP を PowerPoint に変換](#csharp-odp-to-powerpoint)

## **ODP から PPTX への変換**

Aspose.Slides for .NET はプレゼンテーションファイルを表す Presentation クラスを提供します。[**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスは、オブジェクト生成時の Presentation コンストラクタを介して ODP にもアクセスできるようになりました。以下の例は ODP プレゼンテーションを PPTX プレゼンテーションに変換する方法を示しています。

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>手順: C# で ODP を PPTX に変換</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>手順: C# で ODP を PowerPoint に変換</strong></a>
```c#
// ODP ファイルを開く
Presentation pres = new Presentation("AccessOpenDoc.odp");

// ODP プレゼンテーションを PPTX 形式で保存
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```


## **実例**

以下のリンクから [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) Web アプリにアクセスできます。このアプリは **Aspose.Slides API** で構築されており、ODP から PPTX への変換がどのように実装できるかを示しています。

## **よくある質問**

**ODP を PPTX に変換するために Microsoft PowerPoint や LibreOffice をインストールする必要がありますか？**

いいえ。Aspose.Slides は単体で動作し、ODP/PPTX の読み書きにサードパーティ製アプリケーションは必要ありません。

**変換時にマスタースライド、レイアウト、テーマは保持されますか？**

はい。ライブラリは完全なプレゼンテーション オブジェクト モデルを使用し、マスタースライドやレイアウトを含む構造を保持するため、変換後もデザインは正しく保たれます。

**パスワードで保護された ODP ファイルを変換できますか？**

はい。Aspose.Slides は保護の検出に対応しており、パスワードを提供すれば [protected presentations](/slides/ja/net/password-protected-presentation/)（ODP を含む）を開いて操作でき、暗号化やドキュメントプロパティへのアクセスも設定できます。

**Aspose.Slides はクラウドや REST ベースの変換サービスに適していますか？**

はい。ローカル ライブラリを自分のバックエンドで使用するか、[Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/)（REST API）を利用できます。両方のオプションで ODP → PPTX 変換がサポートされます。