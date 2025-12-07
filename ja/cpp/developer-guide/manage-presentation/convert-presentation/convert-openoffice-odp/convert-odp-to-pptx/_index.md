---
title: C++ で ODP を PPTX に変換
linktitle: ODP から PPTX
type: docs
weight: 10
url: /ja/cpp/convert-odp-to-pptx/
keywords:
- OpenDocument を変換
- プレゼンテーションを変換
- スライドを変換
- ODP を変換
- OpenDocument から PPTX
- ODP から PPTX
- ODP を PPTX として保存
- ODP を PPTX にエクスポート
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "C++ 用 Aspose.Slides で ODP を PPTX に変換します。クリーンなコード例、バッチ処理のヒント、高品質な結果を実現し、PowerPoint は不要です。"
---

## **ODP から PPTX への変換**

Aspose.Slides for .NET はプレゼンテーション ファイルを表す [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスを提供します。クラスはオブジェクト生成時に Presentation コンストラクタを通じて ODP にもアクセスできるようになりました。以下の例は ODP プレゼンテーションを PPTX プレゼンテーションに変換する方法を示しています。
``` cpp
// ドキュメント ディレクトリへのパス。
String dataDir = GetDataPath();

// ODP ファイルを開く
auto pres = System::MakeObject<Presentation>(dataDir + u"AccessOpenDoc.odp");

// ODP プレゼンテーションを PPTX 形式で保存
pres->Save(dataDir + u"AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```


## **ライブ例**

[**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) ウェブ アプリにアクセスできます。このアプリは **Aspose.Slides API** で構築されており、ODP から PPTX への変換が Aspose.Slides API でどのように実装できるかを示しています。

## **FAQ**

**ODP を PPTX に変換するために Microsoft PowerPoint または LibreOffice をインストールする必要がありますか？**

いいえ。Aspose.Slides は単体で動作し、ODP/PPTX の読み書きにサードパーティ アプリケーションは不要です。

**変換時にマスタースライド、レイアウト、テーマは保持されますか？**

はい。ライブラリは完全なプレゼンテーション オブジェクト モデルを使用し、マスタースライドやレイアウトを含む構造を保持するため、変換後もデザインが正しく保たれます。

**パスワードで保護された ODP ファイルを変換できますか？**

はい。Aspose.Slides は保護の検出、パスワードを提供しての [protected presentations](/slides/ja/cpp/password-protected-presentation/)（ODP を含む）の開封・操作、暗号化設定やドキュメント プロパティへのアクセスをサポートします。

**Aspose.Slides はクラウドや REST ベースの変換サービスに適していますか？**

はい。ローカル ライブラリを独自のバックエンドで使用することも、[Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/)（REST API）を使用することもでき、どちらのオプションでも ODP → PPTX 変換をサポートします。