---
title: プレゼンテーションの確認
type: docs
weight: 30
url: /net/examine-presentation/
keywords:
- PowerPoint
- プレゼンテーション
- プレゼンテーションフォーマット
- プレゼンテーションプロパティ
- ドキュメントプロパティ
- プロパティを取得
- プロパティを読み取る
- プロパティを変更
- プロパティを修正
- PPTX
- PPT
- C#
- Csharp
- .NET
description: "C# または .NET で PowerPoint プレゼンテーションのプロパティを読み取り、修正します"
---

Aspose.Slides for .NET を使用すると、プレゼンテーションを検査してそのプロパティを確認し、動作を理解することができます。

{{% alert title="情報" color="info" %}} 

[PresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo) および [DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/) クラスには、ここでの操作に使用されるプロパティとメソッドが含まれています。

{{% /alert %}} 

## **プレゼンテーションフォーマットの確認**

プレゼンテーションに取り組む前に、現在プレゼンテーションがどのフォーマット (PPT、PPTX、ODP など) であるかを確認したい場合があります。

プレゼンテーションを読み込まずに、そのフォーマットを確認できます。以下の C# コードを参照してください。

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **プレゼンテーションプロパティの取得**

この C# コードは、プレゼンテーションのプロパティ (プレゼンテーションに関する情報) を取得する方法を示しています。

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// .. 
```

[DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/#properties) クラスの下のプロパティを確認したいかもしれません。

## **プレゼンテーションプロパティの更新**

Aspose.Slides では、プレゼンテーションプロパティを変更することを可能にする [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) メソッドが提供されています。

例として、以下に示すドキュメントプロパティを持つ PowerPoint プレゼンテーションがあるとします。

![PowerPoint プレゼンテーションの元のドキュメントプロパティ](input_properties.png)

このコード例は、いくつかのプレゼンテーションプロパティを編集する方法を示しています。

```c#
string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "私のタイトル";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

ドキュメントプロパティを変更した結果は以下に示されています。

![PowerPoint プレゼンテーションの変更されたドキュメントプロパティ](output_properties.png)

## **便利なリンク**

プレゼンテーションとそのセキュリティ属性に関する詳細情報を取得するには、次のリンクが役立つかもしれません。

- [プレゼンテーションが暗号化されているかどうかの確認](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [プレゼンテーションが書き込み保護されているかどうかの確認 (読み取り専用)](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [プレゼンテーションを読み込む前にパスワード保護されているかどうかの確認](https://docs.aspose.com/slides/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [プレゼンテーションを保護するために使用されたパスワードの確認](https://docs.aspose.com/slides/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation)