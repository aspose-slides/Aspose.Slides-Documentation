---
title: .NET でプレゼンテーション情報の取得と更新
linktitle: プレゼンテーション情報
type: docs
weight: 30
url: /ja/net/examine-presentation/
keywords:
- プレゼンテーション形式
- プレゼンテーション プロパティ
- ドキュメント プロパティ
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
description: ".NET を使用して PowerPoint および OpenDocument プレゼンテーションのスライド、構造、メタデータを調査し、より迅速なインサイトと賢いコンテンツ監査を実現します。"
---
## **概要**

この記事では、Aspose.Slides でプレゼンテーション情報を検査する方法を示します。プレゼンテーションを完全に読み込まずに現在の形式を判別し、ドキュメントプロパティを取得し、必要に応じてそれらのプロパティを更新する方法を説明します。

例は [PresentationInfo](https://reference.aspose.com/slides/ja/net/aspose.slides/presentationinfo/) と [DocumentProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/documentproperties/) API を基にしており、プレゼンテーション メタデータの操作における典型的な手順を示しています。

## **プレゼンテーションの形式を確認する**

プレゼンテーションを操作する前に、現在の形式（PPT、PPTX、ODP など）を確認したい場合があります。

プレゼンテーションを読み込まずに形式を確認できます。以下の C# コードをご覧ください。

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX形式

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT形式

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP形式
```

## **プレゼンテーションのプロパティを取得する**

この C# コードは、プレゼンテーションのプロパティ（プレゼンテーションに関する情報）を取得する方法を示しています。

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// ..
```

DocumentProperties クラスの下にあるプロパティを確認したい場合があります。

## **プレゼンテーションのプロパティを更新する**

Aspose.Slides は [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) メソッドを提供しており、プレゼンテーションのプロパティを変更できます。

以下に示すようなドキュメントプロパティを持つ PowerPoint プレゼンテーションがあるとします。

![PowerPoint プレゼンテーションの元のドキュメントプロパティ](input_properties.png)

このコード例は、いくつかのプレゼンテーションプロパティを編集する方法を示しています。

```c#
using Aspose.Slides;

string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

ドキュメントプロパティを変更した結果は以下のとおりです。

![PowerPoint プレゼンテーションの変更後ドキュメントプロパティ](output_properties.png)

## **便利なリンク**

プレゼンテーションおよびそのセキュリティ属性に関する詳細情報は、次のリンクが役立ちます。

- [プレゼンテーションのパスワード保護](/slides/ja/net/password-protected-presentation/)
- [プレゼンテーションの書き込み保護](/slides/ja/net/write-protected-presentation/)

## **FAQ**

**フォントが埋め込まれているか、どのフォントが埋め込まれているかを確認するにはどうすればよいですか？**

プレゼンテーションレベルで [embedded-font information](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsmanager/getembeddedfonts/) を確認し、次にコンテンツ全体で実際に使用されているフォントのセットと比較して、レンダリングに重要なフォントを特定します。

**ファイルに非表示スライドがあるかどうか、またその数をすばやく把握するには？**

[slide collection](https://reference.aspose.com/slides/ja/net/aspose.slides/slidecollection/) を反復処理し、各スライドの [visibility flag](https://reference.aspose.com/slides/ja/net/aspose.slides/slide/hidden/) を確認します。

**カスタム スライドサイズと向きが使用されているか、既定値と異なるかを検出できますか？**

はい。現在の [slide size](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/slidesize/) と orientation を標準のプリセットと比較します。これにより、印刷やエクスポート時の動作を予測できます。

**チャートが外部データ ソースを参照しているかどうかをすばやく確認する方法はありますか？**

はい。すべての [charts](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/chart/) を走査し、[data source](https://reference.aspose.com/slides/ja/net/aspose.slides.charts/chartdata/datasourcetype/) を確認して、データが内部かリンクベースか（壊れたリンクがあるかどうか）を把握します。

**レンダリングや PDF エクスポートを遅くする可能性のある「重い」スライドを評価するには？**

各スライドについてオブジェクト数を集計し、大きな画像、透過、影、アニメーション、マルチメディアなどをチェックします。概算の複雑度スコアを付けて、パフォーマンス上のボトルネックになる可能性があるスライドをフラグ付けします。