---
title: Python でプレゼンテーション情報を取得し更新する
linktitle: プレゼンテーション情報
type: docs
weight: 30
url: /ja/python-net/examine-presentation/
keywords:
- プレゼンテーション形式
- プレゼンテーション プロパティ
- ドキュメント プロパティ
- プロパティの取得
- プロパティの読み取り
- プロパティの変更
- プロパティの修正
- プロパティの更新
- PPTX の検査
- PPT の検査
- ODP の検査
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Python を使用して PowerPoint および OpenDocument プレゼンテーションのスライド、構造、メタデータを調査し、より迅速な洞察と賢いコンテンツ監査を実現します。"
---

Aspose.Slides for Python via .NET を使用すると、プレゼンテーションを調査してプロパティを確認し、その動作を理解できます。 

{{% alert title="Info" color="info" %}} 
ここで使用される操作に必要なプロパティとメソッドは、[PresentationInfo](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/) と [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) クラスに含まれています。 
{{% /alert %}} 

## **プレゼンテーション形式の確認**

プレゼンテーションを操作する前に、現在の形式（PPT、PPTX、ODP など）を確認したい場合があります。

プレゼンテーションを読み込まずに形式を確認できます。以下の Python コードをご参照ください:
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

この Python コードは、プレゼンテーションのプロパティ（プレゼンテーションに関する情報）を取得する方法を示しています:
```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```


[DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/#properties) クラスの **properties** を確認したくなることがあります。

## **プレゼンテーションプロパティの更新**

Aspose.Slides は、[PresentationInfo.update_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) メソッドを提供しており、プレゼンテーションのプロパティを変更できます。

以下のような PowerPoint プレゼンテーションのドキュメントプロパティがあるとします。

![PowerPoint プレゼンテーションの元のドキュメントプロパティ](input_properties.png)

このコード例は、いくつかのプレゼンテーションプロパティを編集する方法を示しています:
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

![PowerPoint プレゼンテーションの変更後のドキュメントプロパティ](output_properties.png)

## **便利なリンク**

プレゼンテーションやそのセキュリティ属性に関する詳細情報を得るために、次のリンクが役立ちます:

- [プレゼンテーションが暗号化されているかの確認](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [プレゼンテーションが書き込み保護（読み取り専用）されているかの確認](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [読み込む前にプレゼンテーションがパスワード保護されているかの確認](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [プレゼンテーションを保護するために使用されたパスワードの確認](https://docs.aspose.com/slides/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation)

## **FAQ**

**フォントが埋め込まれているか、どのフォントが埋め込まれているかを確認する方法は？**

プレゼンテーションレベルで [embedded-font 情報](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) を探し、[実際にコンテンツで使用されているフォント](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_fonts/) の集合と比較して、レンダリングに必須のフォントを特定します。

**ファイルに非表示スライドが含まれているか、またその数をすばやく確認する方法は？**

[スライドコレクション](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) を反復し、各スライドの [visibility フラグ](https://reference.aspose.com/slides/python-net/aspose.slides/slide/hidden/) をチェックします。

**カスタムスライドサイズや向きが使用されているか、デフォルトと異なるかを検出できるか？**

はい。現在の [スライドサイズ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slide_size/) と向きを標準プリセットと比較し、印刷やエクスポート時の挙動を予測できます。

**チャートが外部データソースを参照しているかをすぐに確認する方法は？**

はい。すべての [チャート](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) を走査し、[データソース](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) を確認して、内部データかリンクベースか、壊れたリンクがあるかを把握します。

**レンダリングや PDF エクスポートを遅くする可能性がある「重い」スライドを評価する方法は？**

各スライドについてオブジェクト数を集計し、大きな画像、透明度、影、アニメーション、マルチメディアなどをチェックして、概算の複雑度スコアを付け、パフォーマンスのボトルネックとなり得るスライドをフラグ付けします。