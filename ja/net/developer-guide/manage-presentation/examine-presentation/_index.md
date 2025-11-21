---
title: .NET でプレゼンテーション情報を取得および更新
linktitle: プレゼンテーション情報
type: docs
weight: 30
url: /ja/net/examine-presentation/
keywords:
- プレゼンテーション形式
- プレゼンテーションプロパティ
- ドキュメントプロパティ
- プロパティ取得
- プロパティ読み取り
- プロパティ変更
- プロパティ修正
- プロパティ更新
- PPTX の検査
- PPT の検査
- ODP の検査
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "PowerPoint および OpenDocument のプレゼンテーションにおけるスライド、構造、メタデータを .NET で調査し、迅速な洞察とスマートなコンテンツ監査を実現します。"
---

Aspose.Slides for .NET は、プレゼンテーションを調査してプロパティを確認し、その動作を理解することができます。

{{% alert title="Info" color="info" %}} 

[PresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo) および [DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/) クラスに、ここで使用する操作に必要なプロパティとメソッドが含まれています。

{{% /alert %}} 

## **プレゼンテーション形式のチェック**

プレゼンテーションを操作する前に、現在の形式（PPT、PPTX、ODP など）が何かを確認したくなることがあります。

プレゼンテーションを読み込まずに形式を確認できます。以下の C# コードをご覧ください。
```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX形式

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT形式

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP形式
```


## **プレゼンテーションプロパティの取得**

この C# コードは、プレゼンテーションのプロパティ（プレゼンテーションに関する情報）を取得する方法を示しています。
```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// …
```


[DocumentProperties クラスのプロパティ](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/#properties) を確認したい場合があります。

## **プレゼンテーションプロパティの更新**

Aspose.Slides は、プレゼンテーションのプロパティを変更できる [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) メソッドを提供しています。

以下に示すドキュメントプロパティを持つ PowerPoint プレゼンテーションがあるとします。

![PowerPoint プレゼンテーションの元のドキュメントプロパティ](input_properties.png)

このコード例は、いくつかのプレゼンテーションプロパティを編集する方法を示しています。
```c#
string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```


ドキュメントプロパティを変更した結果は以下の通りです。

![PowerPoint プレゼンテーションの変更後ドキュメントプロパティ](output_properties.png)

## **便利なリンク**

プレゼンテーションとそのセキュリティ属性に関する詳細情報を得るには、以下のリンクが役立つ場合があります。

- [プレゼンテーションが暗号化されているかの確認](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [プレゼンテーションが書き込み保護（読み取り専用）されているかの確認](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [ロード前にプレゼンテーションがパスワード保護されているかの確認](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [プレゼンテーション保護に使用されたパスワードの確認](https://docs.aspose.com/slides/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **よくある質問**

**フォントが埋め込まれているか、どのフォントが埋め込まれているかをどう確認できますか？**

プレゼンテーションレベルで [埋め込みフォント情報](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/) を確認し、次に [実際にコンテンツで使用されているフォント](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) と比較して、レンダリングに重要なフォントを特定します。

**ファイルに非表示スライドがあるか、またその数をすばやく確認する方法はありますか？**

[スライドコレクション](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) を反復処理し、各スライドの [可視性フラグ](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/) を確認します。

**カスタムスライドサイズと方向が使用されているか、デフォルトと異なるかを検出できますか？**

はい。現在の [スライドサイズ](https://reference.aspose.com/slides/net/aspose.slides/presentation/slidesize/) と方向を標準のプリセットと比較します。これにより、印刷やエクスポート時の動作を予測できます。

**チャートが外部データソースを参照しているかどうかをすぐに確認する方法はありますか？**

はい。すべての [チャート](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/) を走査し、各チャートの [データソース](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) を確認して、データが内部かリンクベースか、壊れたリンクがあるかを把握します。

**レンダリングや PDF エクスポートを遅くする可能性のある「重い」スライドを評価する方法はありますか？**

各スライドについてオブジェクト数を集計し、大きな画像、透明度、影、アニメーション、マルチメディアなどをチェックします。概算の複雑度スコアを付けて、パフォーマンス上のボトルネックになり得る箇所を示します。