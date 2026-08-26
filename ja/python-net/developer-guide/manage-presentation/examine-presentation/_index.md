---
title: Pythonでプレゼンテーション情報を取得および更新
linktitle: プレゼンテーション情報
type: docs
weight: 30
url: /ja/python-net/examine-presentation/
keywords:
- プレゼンテーション形式
- プレゼンテーションプロパティ
- ドキュメントプロパティ
- プロパティ取得
- プロパティ読み取り
- プロパティ変更
- プロパティ修正
- プロパティ更新
- PPTXの検査
- PPTの検査
- ODPの検査
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: Python を使用して PowerPoint および OpenDocument のプレゼンテーションのスライド、構造、メタデータを調査し、より迅速な洞察とスマートなコンテンツ監査を実現します。
---
## **概要**

この記事では、Aspose.Slidesでプレゼンテーション情報を検査する方法を示します。プレゼンテーションの完全なファイルを読み込まずに現在の形式を判定し、ドキュメント プロパティを読み取り、必要に応じてそれらのプロパティを更新する方法を説明します。

例は [PresentationInfo](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationinfo/) と [DocumentProperties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/documentproperties/) API をベースにしており、プレゼンテーションのメタデータを扱う典型的な操作を示しています。

## **プレゼンテーション形式の確認**

プレゼンテーションを操作する前に、現在の形式（PPT、PPTX、ODP など）が何であるかを確認したくなることがあります。

プレゼンテーションを読み込まずに形式を確認できます。以下の Python コードをご覧ください。

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **プレゼンテーション プロパティの取得**

この Python コードは、プレゼンテーション プロパティ（プレゼンテーションに関する情報）を取得する方法を示しています。

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

DocumentProperties クラスの [プロパティ](https://reference.aspose.com/slides/ja/python-net/aspose.slides/documentproperties/#properties) を確認したくなるかもしれません。

## **プレゼンテーション プロパティの更新**

Aspose.Slides では、プレゼンテーション プロパティを変更できる [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) メソッドが提供されています。

以下に示すようなドキュメント プロパティを持つ PowerPoint プレゼンテーションがあるとします。

![PowerPoint プレゼンテーションの元のドキュメント プロパティ](input_properties.png)

このコード例は、いくつかのプレゼンテーション プロパティを編集する方法を示しています。

```py
import aspose.slides as slides
import datetime

file_name = "sample.pptx"

info = slides.PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

ドキュメント プロパティを変更した結果は以下の通りです。

![PowerPoint プレゼンテーションの変更後ドキュメント プロパティ](output_properties.png)

## **便利なリンク**

プレゼンテーションおよびそのセキュリティ属性に関する詳細情報を得るには、以下のリンクが役立つでしょう。

- [プレゼンテーションのパスワード保護](/slides/ja/python-net/password-protected-presentation/)
- [プレゼンテーションの書き込み保護](/slides/ja/python-net/write-protected-presentation/)

## **FAQ**

**フォントが埋め込まれているか、どのフォントが埋め込まれているかを確認するにはどうすればよいですか？**

プレゼンテーションレベルで [embedded-font information](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) を探し、次にそれらのエントリを [実際にコンテンツで使用されているフォント](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontsmanager/get_fonts/) のセットと比較して、レンダリングに重要なフォントを特定します。

**ファイルに非表示スライドがあるか、いくつあるかをすばやく確認するにはどうすればよいですか？**

[slide collection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidecollection/) を反復処理し、各スライドの [visibility flag](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/hidden/) を確認します。

**カスタム スライド サイズと向きが使用されているか、既定と異なるかを検出できますか？**

はい。現在の [slide size](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/slide_size/) と向きを標準のプリセットと比較します。これにより、印刷やエクスポート時の動作を予測しやすくなります。

**チャートが外部データ ソースを参照しているかどうかをすばやく確認する方法はありますか？**

はい。すべての [charts](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chart/) を走査し、それらの [data source](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/data_source_type/) を確認して、データが内部かリンクベースか、破損したリンクがあるかどうかを記録します。

**レンダリングや PDF エクスポートを遅くする可能性のある「重い」スライドを評価するにはどうすればよいですか？**

各スライドについてオブジェクト数を集計し、大きな画像、透過、影、アニメーション、マルチメディアなどを調べます。概算の複雑度スコアを付けて、潜在的なパフォーマンス ボトルネックをフラグ付けします。