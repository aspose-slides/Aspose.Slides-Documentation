---
title: PythonでODPをPPTXに変換
linktitle: ODPからPPTXへ
type: docs
weight: 10
url: /ja/python-net/convert-odp-to-pptx/
keywords:
- OpenDocument を変換
- ODP を変換
- OpenDocument から PPTX へ
- ODP から PPTX へ
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して ODP を PPTX に変換します。クリーンなコード例、バッチ処理のヒント、高品質な結果を実現—PowerPoint は不要です。"
---

## **ODP を PPTX にエクスポート**

Aspose.Slides for Python via .NET は、プレゼンテーション ファイルを表す Presentation クラスを提供します。 [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスは、オブジェクトをインスタンス化する際に Presentation コンストラクタを通じて ODP にもアクセスできるようになりました。以下の例は、ODP プレゼンテーションを PPTX プレゼンテーションに変換する方法を示しています。
```py
# Aspose.Slides for Python via .NET モジュールをインポート
import aspose.slides as slides

# ODP ファイルを開く
pres = slides.Presentation("AccessOpenDoc.odp")

# ODP プレゼンテーションを PPTX 形式で保存
pres.save("AccessOpenDoc_out.pptx", slides.export.SaveFormat.PPTX)
```


## **ライブ例**

[**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) Web アプリにアクセスできます。このアプリは **Aspose.Slides API** を使用して構築されており、ODP から PPTX への変換が Aspose.Slides API でどのように実装できるかをデモンストレーションします。

## **FAQ**

**ODP を PPTX に変換するために Microsoft PowerPoint や LibreOffice をインストールする必要がありますか？**

いいえ。Aspose.Slides は単体で動作し、ODP/PPTX の読み書きにサードパーティ アプリケーションは不要です。

**変換時にマスタースライド、レイアウト、テーマは保持されますか？**

はい。ライブラリは完全なプレゼンテーション オブジェクト モデルを使用し、マスタースライドやレイアウトを含む構造を保持するため、変換後もデザインが正しく保たれます。

**パスワードで保護された ODP ファイルを変換できますか？**

はい。Aspose.Slides は保護の検出に対応しており、パスワードを提供すれば [protected presentations](/slides/ja/python-net/password-protected-presentation/)（ODP を含む）を開いて操作でき、暗号化やドキュメント プロパティへのアクセスも設定できます。

**Aspose.Slides はクラウドや REST ベースの変換サービスに適していますか？**

はい。ローカル ライブラリを自分のバックエンドで使用することも、[Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/)（REST API）を利用することも可能で、どちらのオプションでも ODP → PPTX の変換をサポートします。