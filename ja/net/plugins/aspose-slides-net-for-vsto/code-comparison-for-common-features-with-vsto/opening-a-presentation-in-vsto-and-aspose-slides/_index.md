---
title: VSTO と Aspose.Slides でプレゼンテーションを開く
type: docs
weight: 120
url: /ja/net/opening-a-presentation-in-vsto-and-aspose-slides/
---

## **VSTO**
以下はプレゼンテーションを開くためのコードスニペットです:

``` csharp

  string FileName = "Open Presentation.pptx";

 Application.Presentations.Open(FileName);


``` 
## **Aspose.Slides**
Aspose.Slides for .NET は、既存のプレゼンテーションを開くために使用される **Presentation** クラスを提供します。いくつかのオーバーロードされたコンストラクターがあり、既存のプレゼンテーションに基づいてオブジェクトを作成するために **Presentation** クラスの適切なコンストラクターのうちの 1 つを使用できます。以下の例では、プレゼンテーションファイル（開くファイル）の名前を Presentation クラスのコンストラクターに渡しています。ファイルが開かれた後、プレゼンテーションに含まれるスライドの総数を取得し、画面に表示します。

``` csharp

  string FileName = "Open Presentation.pptx";

 Presentation MyPresentation = new Presentation(FileName);

``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Opening%20a%20Presentation)