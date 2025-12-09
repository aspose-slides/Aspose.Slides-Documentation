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
- PPTX の解析
- PPT の解析
- ODP の解析
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: ".NET を使用して PowerPoint および OpenDocument プレゼンテーションのスライド、構造、メタデータを調査し、より迅速な洞察と賢いコンテンツ監査を実現します。"
---

Aspose.Slides for .NET を使用すると、プレゼンテーションを検査してプロパティを確認し、その動作を理解できます。

{{% alert title="Info" color="info" %}} 
The [PresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo) と [DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/) クラスに、ここで使用される操作に必要なプロパティとメソッドが含まれています。
{{% /alert %}} 

## **Check a Presentation Format**
プレゼンテーションを操作する前に、現在の形式（PPT、PPTX、ODP など）を確認したい場合があります。

プレゼンテーションを読み込まずに形式を確認できます。以下の C# コードをご覧ください:
```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```


## **Get Presentation Properties**
以下の C# コードは、プレゼンテーションのプロパティ（プレゼンテーションに関する情報）を取得する方法を示しています。
```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// ..
```


[DocumentProperties のプロパティ](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/#properties) を確認したい場合があります。

## **Update Presentation Properties**
Aspose.Slides は、プレゼンテーションのプロパティを変更できる [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) メソッドを提供します。

以下に示すように、ドキュメントプロパティを持つ PowerPoint プレゼンテーションがあるとしましょう。

![PowerPoint プレゼンテーションの元のドキュメント プロパティ](input_properties.png)

このコード例は、いくつかのプレゼンテーション プロパティを編集する方法を示しています:
```c#
string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```


ドキュメント プロパティを変更した結果は以下のとおりです。

![PowerPoint プレゼンテーションの変更後のドキュメント プロパティ](output_properties.png)

## **Useful Links**
プレゼンテーションとそのセキュリティ属性に関する詳細情報は、以下のリンクが役立ちます。

- [プレゼンテーションが暗号化されているかの確認](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [プレゼンテーションが書き込み保護（読み取り専用）かどうかの確認](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [読み込む前にプレゼンテーションがパスワード保護されているかの確認](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [プレゼンテーションを保護するために使用されたパスワードの確認](https://docs.aspose.com/slides/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**How can I check whether fonts are embedded and which ones they are?**  
プレゼンテーション レベルで [埋め込みフォント情報](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/) を探し、[実際にコンテンツで使用されているフォント](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) のセットと比較して、レンダリングに重要なフォントを特定します。

**How can I quickly tell if the file has hidden slides and how many?**  
[スライドコレクション](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) を反復処理し、各スライドの [表示フラグ](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/) を確認します。

**Can I detect whether custom slide size and orientation are used, and whether they differ from the defaults?**  
はい。現在の [スライドサイズ](https://reference.aspose.com/slides/net/aspose.slides/presentation/slidesize/) と向きを標準のプリセットと比較します。これにより、印刷やエクスポート時の動作を予測できます。

**Is there a quick way to see if charts reference external data sources?**  
はい。すべての [チャート](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/) を走査し、[データ ソース](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) を確認して、データが内部かリンクベースか、壊れたリンクがあるかを確認します。

**How can I assess 'heavy' slides that may slow rendering or PDF export?**  
各スライドのオブジェクト数を集計し、大きな画像、透明性、影、アニメーション、マルチメディアなどをチェックし、概算の複雑度スコアを付けてパフォーマンスのボトルネックを特定します。