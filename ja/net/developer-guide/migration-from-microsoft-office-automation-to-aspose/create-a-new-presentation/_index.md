---
title: VSTO と Aspose.Slides for .NET を使用した新しいプレゼンテーションの作成
linktitle: 新しいプレゼンテーションの作成
type: docs
weight: 10
url: /ja/net/create-a-new-presentation/
keywords:
- プレゼンテーション作成
- 新しいプレゼンテーション
- 移行
- VSTO
- Office オートメーション
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Microsoft Office のオートメーションから Aspose.Slides for .NET に移行し、C# でクリーンで信頼性の高いコードを使用して新しい PowerPoint (PPT, PPTX) プレゼンテーションを作成します。"
---

{{% alert color="primary" %}} 

VSTO は、開発者が Microsoft Office 内で実行できるアプリケーションを構築できるように開発されました。VSTO は COM ベースですが、.NET オブジェクトでラップされているため、.NET アプリケーションで使用できます。VSTO は .NET Framework のサポートと Microsoft Office の CLR ベースランタイムが必要です。Microsoft Office のアドインを作成するために使用できるものの、サーバー側コンポーネントとして使用することは事実上不可能です。また、展開に重大な問題があります。

- Aspose.Slides はマネージドコードのみで構成されており、Microsoft Office のランタイムをインストールする必要がありません。
- クライアント側コンポーネントとしても、サーバー側コンポーネントとしても使用できます。
- Aspose.Slides は単一の DLL に収められているため、デプロイが簡単です。

{{% /alert %}} 
## **プレゼンテーションの作成**
以下に、VSTO と Aspose.Slides for .NET を使用して同じ目的を達成する方法を示す 2 つのコード例を示します。最初の例は [VSTO](/slides/ja/net/create-a-new-presentation/); [2番目の例](/slides/ja/net/create-a-new-presentation/) は Aspose.Slides を使用しています。
### **VSTO の例**
**VSTO の出力** 

![todo:image_alt_text](create-a-new-presentation_1.png)
```c#
//PowerPoint は上記のように定義された名前空間です
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//プレゼンテーションを作成
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Get the title slide layout
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Add a title slide.
PowerPoint.Slide slide = pres.Slides.AddSlide(1, layout);

//Set the title text
slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//Set the sub title text
slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//Write the output to disk
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```



### **Aspose.Slides for .NET の例**
**Aspose.Slides の出力** 

![todo:image_alt_text](create-a-new-presentation_2.png)
```c#
//プレゼンテーションを作成
Presentation pres = new Presentation();

//タイトルスライドを追加
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//タイトルテキストを設定
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Slide Title Heading";

//サブタイトルテキストを設定
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Slide Title Sub-Heading";

//出力をディスクに保存
pres.Save("c:\\data\\outAsposeSlides.pptx", SaveFormat.Ppt);
```
