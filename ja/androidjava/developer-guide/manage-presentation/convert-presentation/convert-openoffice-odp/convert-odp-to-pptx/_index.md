---
title: AndroidでODPをPPTXに変換
linktitle: ODPからPPTXへ
type: docs
weight: 10
url: /ja/androidjava/convert-odp-to-pptx/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して ODP を PPTX に変換します。クリーンな Java コード例、バッチのヒント、高品質な結果を提供し、PowerPoint は不要です。"
---

## **ODP を PPTX/PPT プレゼンテーションに変換**

Aspose.Slides for Android via Java は、プレゼンテーション ファイルを表す [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスを提供します。[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスは、オブジェクトがインスタンス化される際に、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#Presentation-java.lang.String-) コンストラクタを通じて ODP にもアクセスできるようになりました。以下の例は、ODP プレゼンテーションを PPTX プレゼンテーションに変換する方法を示しています。
```java
// ODP ファイルを開く
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// ODP プレゼンテーションを PPTX 形式で保存
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **ライブサンプル**

以下の [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) Web アプリにアクセスできます。このアプリは **Aspose.Slides API** を使用して構築されており、ODP から PPTX への変換を Aspose.Slides API で実装する方法を示しています。

## **よくある質問**

**ODP を PPTX に変換するために Microsoft PowerPoint や LibreOffice をインストールする必要がありますか？**

いいえ。Aspose.Slides は単独で動作し、ODP/PPTX の読み書きにサードパーティ アプリケーションは必要ありません。

**変換中にマスター スライド、レイアウト、テーマは保持されますか？**

はい。ライブラリは完全なプレゼンテーション オブジェクト モデルを使用しており、マスター スライドやレイアウトを含む構造を保持するため、変換後もデザインが正しく保たれます。

**パスワードで保護された ODP ファイルを変換できますか？**

はい。Aspose.Slides は保護の検出に対応しており、パスワードを提供することで [protected presentations](/slides/ja/androidjava/password-protected-presentation/)（ODP を含む）を開いて操作でき、さらに暗号化の設定やドキュメント プロパティへのアクセスも可能です。

**Aspose.Slides はクラウドまたは REST ベースの変換サービスに適していますか？**

はい。ローカル ライブラリを独自のバックエンドで使用することも、[Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/)（REST API）を利用することもできます。どちらのオプションも ODP → PPTX 変換をサポートしています。