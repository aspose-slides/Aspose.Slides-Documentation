---
title: VSTOとAspose.Slidesでプレゼンテーションを開く
type: docs
weight: 120
url: /ja/net/opening-a-presentation-in-vsto-and-aspose-slides/
---

## **VSTO**
プレゼンテーションを開くためのコードスニペットは以下の通りです：

``` csharp

  string FileName = "Open Presentation.pptx";

 Application.Presentations.Open(FileName);


``` 
## **Aspose.Slides**
Aspose.Slides for .NETは、既存のプレゼンテーションを開くために使用される**Presentation**クラスを提供します。このクラスにはいくつかのオーバーロードされたコンストラクタがあり、既存のプレゼンテーションに基づいて**Presentation**クラスの適切なコンストラクタの1つを使用してそのオブジェクトを作成することができます。以下に示す例では、プレゼンテーションファイル（開くべき）の名前をPresentationクラスのコンストラクタに渡しています。ファイルが開かれると、プレゼンテーションに存在するスライドの総数を取得し、画面に印刷します。

``` csharp

  string FileName = "Open Presentation.pptx";

 Presentation MyPresentation = new Presentation(FileName);

``` 
## **ダウンロード実行コード**
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **サンプルコードのダウンロード**
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Opening a Presentation/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Opening%20a%20Presentation)