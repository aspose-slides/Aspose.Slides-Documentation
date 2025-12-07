---
title: C++ で ODP を PPTX に変換
linktitle: ODP から PPTX へ
type: docs
weight: 10
url: /ja/cpp/convert-odp-to-pptx/
keywords:
- OpenDocument を変換
- プレゼンテーションを変換
- スライドを変換
- ODP を変換
- OpenDocument から PPTX へ
- ODP から PPTX へ
- ODP を PPTX として保存
- ODP を PPTX にエクスポート
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "C++ 用 Aspose.Slides で ODP を PPTX に変換します。クリーンなコード例、バッチ処理のヒント、高品質な結果を提供し、PowerPoint は不要です。"
---

## **ODP to PPTX 変換**

Aspose.Slides for .NET はプレゼンテーションファイルを表す Presentation クラスを提供します。[**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスは、オブジェクトがインスタンス化される際に Presentation コンストラクタを介して ODP にもアクセスできるようになりました。以下の例は、ODP プレゼンテーションを PPTX プレゼンテーションに変換する方法を示しています。
``` cpp
// ドキュメント ディレクトリへのパス。
String dataDir = GetDataPath();

// ODP ファイルを開く
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// ODP プレゼンテーションを PPTX 形式で保存
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```


## **ライブ例**

[Aspose.Slides 変換](https://products.aspose.app/slides/conversion/) Web アプリで、**Aspose.Slides API** を使用して構築されています。このアプリは、Aspose.Slides API を使用して ODP から PPTX への変換を実装する方法を示しています。

## **よくある質問**

**ODP を PPTX に変換するために Microsoft PowerPoint や LibreOffice をインストールする必要がありますか？**

いいえ。Aspose.Slides は単体で動作し、ODP/PPTX の読み取りや書き込みにサードパーティ製アプリケーションは必要ありません。

**変換中にマスタースライド、レイアウト、テーマは保持されますか？**

はい。ライブラリは完全なプレゼンテーションオブジェクトモデルを使用し、マスタースライドやレイアウトを含む構造を保持するため、変換後もデザインが正しく保たれます。

**パスワードで保護された ODP ファイルを変換できますか？**

はい。Aspose.Slides は保護の検出に対応しており、パスワードを提供すれば [protected presentations](/slides/ja/cpp/password-protected-presentation/)（ODP を含む）を開いて操作でき、暗号化やドキュメントプロパティへのアクセスも設定できます。

**Aspose.Slides はクラウドまたは REST ベースの変換サービスに適していますか？**

はい。ローカルライブラリを独自のバックエンドで使用することも、[Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/)（REST API）を使用することもできます。どちらのオプションも ODP → PPTX 変換をサポートしています。