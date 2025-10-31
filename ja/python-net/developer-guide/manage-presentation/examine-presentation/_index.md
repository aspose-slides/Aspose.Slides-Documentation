---
title: Python でプレゼンテーション情報の取得と更新
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
description: "Python を使用して PowerPoint および OpenDocument のプレゼンテーションのスライド、構造、メタデータを調査し、より迅速な洞察と賢いコンテンツ監査を実現します。"
---

Aspose.Slides for Python via .NET を使用すると、プレゼンテーションを調査してプロパティを把握し、その動作を理解できます。

{{% alert title="情報" color="info" %}} 

[PresentationInfo](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/) と [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) クラスには、ここで使用するプロパティとメソッドが含まれています。

{{% /alert %}} 

## **プレゼンテーション形式の確認**

プレゼンテーションを操作する前に、現在の形式（PPT、PPTX、ODP など）を確認したい場合があります。

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

## **プレゼンテーションプロパティの取得**

以下の Python コードは、プレゼンテーションプロパティ（プレゼンテーションに関する情報）を取得する方法を示しています。

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

[DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/#properties) クラスのプロパティをご確認ください。

## **プレゼンテーションプロパティの更新**

Aspose.Slides は、[PresentationInfo.update_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) メソッドを提供しており、プレゼンテーションプロパティを変更できます。

以下のような PowerPoint プレゼンテーションのドキュメントプロパティがあるとします。

![PowerPoint プレゼンテーションの元のドキュメントプロパティ](input_properties.png)

このコード例は、いくつかのプレゼンテーションプロパティを編集する方法を示します。

```py
file_name = "sample.pptx"

info = PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

ドキュメントプロパティを変更した結果は以下の通りです。

![PowerPoint プレゼンテーションの変更後ドキュメントプロパティ](output_properties.png)

## **便利なリンク**

プレゼンテーションおよびそのセキュリティ属性に関する詳細情報を取得するには、以下のリンクが役立ちます：

- [プレゼンテーションが暗号化されているかの確認](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [プレゼンテーションが書き込み保護（読み取り専用）かの確認](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [ロード前にプレゼンテーションがパスワード保護されているかの確認](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [プレゼンテーションを保護するために使用されたパスワードの確認](https://docs.aspose.com/slides/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**フォントが埋め込まれているか、どのフォントが埋め込まれているかをどのように確認できますか？**

プレゼンテーションレベルで[embedded-font 情報] を確認し、コンテンツ全体で実際に使用されているフォントのセットと比較することで、レンダリングに重要なフォントを特定できます。

**ファイルに非表示スライドがあるかどうか、そしてその数をすばやく確認する方法は？**

[スライドコレクション] を反復処理し、各スライドの[visibility フラグ] を確認します。

**カスタムスライドサイズや向きが使用されているか、デフォルトと異なるかを検出できますか？**

はい。現在のスライドサイズと向きを標準のプリセットと比較します。これにより、印刷やエクスポート時の動作を予測できます。

**チャートが外部データソースを参照しているかどうかをすばやく確認する方法はありますか？**

はい。すべての[チャート] を走査し、[データソース] を確認して、データが内部かリンクベースか、壊れたリンクがあるかどうかを把握します。

**レンダリングや PDF エクスポートを遅くする可能性のある「重い」スライドをどのように評価できますか？**

各スライドについてオブジェクト数を集計し、大きな画像、透過、影、アニメーション、マルチメディアなどをチェックします。概算の複雑度スコアを付けて、パフォーマンス上のボトルネックとなりうるスライドを特定します。