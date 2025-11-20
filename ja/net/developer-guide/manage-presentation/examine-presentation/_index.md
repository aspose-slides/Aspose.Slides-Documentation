---
title: プレゼンテーションの検査
type: docs
weight: 30
url: /ja/net/examine-presentation/
keywords:
- PowerPoint
- プレゼンテーション
- プレゼンテーション形式
- プレゼンテーション プロパティ
- ドキュメント プロパティ
- プロパティの取得
- プロパティの読み取り
- プロパティの変更
- プロパティの修正
- PPTX
- PPT
- C#
- Csharp
- .NET
description: "C# または .NET で PowerPoint プレゼンテーションのプロパティを読み取りおよび変更"
---

Aspose.Slides for .NET は、プレゼンテーションを調べてそのプロパティを確認し、動作を理解することができます。

{{% alert title="Info" color="info" %}}
[PresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo) と [DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/) クラスには、ここで使用する操作に必要なプロパティとメソッドが含まれています。
{{% /alert %}}

## **プレゼンテーション形式の確認**

プレゼンテーションを操作する前に、現在のプレゼンテーションがどの形式（PPT、PPTX、ODP など）であるかを確認したい場合があります。

プレゼンテーションを読み込まずに形式を確認できます。以下の C# コードをご覧ください。
```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```


## **プレゼンテーションのプロパティ取得**

この C# コードは、プレゼンテーションのプロパティ（プレゼンテーションに関する情報）を取得する方法を示しています。
```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// .. 
```


DocumentProperties クラスの [DocumentProperties のプロパティ](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/#properties) を確認したい場合があります。

## **プレゼンテーションのプロパティ更新**

Aspose.Slides は、プレゼンテーションのプロパティを変更できる [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) メソッドを提供します。

以下に示すように、ドキュメントプロパティが設定された PowerPoint プレゼンテーションがあるとします。

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


ドキュメントプロパティを変更した結果は、以下に示されています。

![PowerPoint プレゼンテーションの変更後ドキュメントプロパティ](output_properties.png)

## **便利なリンク**

プレゼンテーションとそのセキュリティ属性に関する詳細情報を取得するには、以下のリンクが役立つでしょう。

- [プレゼンテーションが暗号化されているかの確認](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [プレゼンテーションが書き込み保護（読み取り専用）されているかの確認](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [読み込み前にプレゼンテーションがパスワード保護されているかの確認](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [プレゼンテーションを保護するために使用されたパスワードの確認](https://docs.aspose.com/slides/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation)

## **よくある質問**

**フォントが埋め込まれているか、どのフォントが埋め込まれているかを確認するには？**

プレゼンテーションレベルで [埋め込みフォント情報](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/) を探し、[コンテンツ全体で実際に使用されているフォント](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) と比較して、レンダリングに重要なフォントを特定します。

**ファイルに非表示スライドがあるか、またその数をすぐに確認するには？**

[スライドコレクション](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) を反復処理し、各スライドの [可視性フラグ](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/) を確認します。

**カスタムスライドサイズと向きが使用されているか、デフォルトと異なるかを検出できますか？**

はい。現在の [スライドサイズ](https://reference.aspose.com/slides/net/aspose.slides/presentation/slidesize/) と向きを標準のプリセットと比較します。これにより、印刷やエクスポート時の動作を予測できます。

**チャートが外部データソースを参照しているかすぐに確認する方法はありますか？**

はい。すべての [チャート](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/) を走査し、各 [データソース](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) を確認して、データが内部かリンクベースか、破損したリンクがあるかどうかを把握します。

**レンダリングや PDF エクスポートを遅くする可能性のある「重い」スライドを評価するには？**

各スライドについてオブジェクト数を集計し、大きな画像、透過、影、アニメーション、マルチメディアなどをチェックします。概算の複雑度スコアを付けて、パフォーマンス上のボトルネックとなり得るスライドを特定します。