---
title: ODP を PPTX に変換
type: docs
weight: 10
url: /ja/nodejs-java/convert-odp-to-pptx/
---

## **ODP を PPTX/PPT プレゼンテーションに変換**
Aspose.Slides for Node.js via Java は、プレゼンテーション ファイルを表す [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスを提供します。[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスは、オブジェクト生成時に [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#Presentation-java.lang.String-) コンストラクタを使用して ODP にもアクセスできるようになりました。以下の例は、ODP プレゼンテーションを PPTX プレゼンテーションに変換する方法を示しています。
```javascript
// ODP ファイルを開く
var pres = new aspose.slides.Presentation("AccessOpenDoc.odp");
// ODP プレゼンテーションを PPTX 形式で保存
pres.save("AccessOpenDoc_out.pptx", aspose.slides.SaveFormat.Pptx);
```


## **ライブ例**
Aspose.Slides API を使用して構築された [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) Web アプリにアクセスできます。このアプリは、Aspose.Slides API で ODP から PPTX への変換を実装する方法を示しています。

## **よくある質問**

**ODP を PPTX に変換するために Microsoft PowerPoint または LibreOffice をインストールする必要がありますか？**

いいえ。Aspose.Slides は単体で動作し、ODP/PPTX の読み書きにサードパーティ製アプリケーションは不要です。

**変換時にマスタースライド、レイアウト、テーマは保持されますか？**

はい。ライブラリは完全なプレゼンテーション オブジェクト モデルを使用しており、マスタースライドやレイアウトなどの構造を保持するため、変換後もデザインが正しく保たれます。

**パスワードで保護された ODP ファイルを変換できますか？**

はい。Aspose.Slides は保護の検出、パスワードを提供して [protected presentations](/slides/ja/nodejs-java/password-protected-presentation/)（ODP を含む）の開封と操作をサポートし、暗号化やドキュメント プロパティへのアクセス設定も可能です。

**Aspose.Slides はクラウドや REST ベースの変換サービスに適していますか？**

はい。ローカル ライブラリを自分のバックエンドで使用するか、[Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/)（REST API）を使用するか、どちらのオプションでも ODP → PPTX 変換をサポートします。