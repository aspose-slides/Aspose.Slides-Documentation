---
title: VSTO と Aspose.Slides for .NET を使用した新しいプレゼンテーションの作成
linktitle: 新しいプレゼンテーションの作成
type: docs
weight: 10
url: /ja/net/create-a-new-presentation/
keywords:
- プレゼンテーションの作成
- 新しいプレゼンテーション
- 移行
- VSTO
- Office automation
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Microsoft Office の自動化から Aspose.Slides for .NET へ移行し、C# でクリーンで信頼性の高いコードで新しい PowerPoint (PPT, PPTX) プレゼンテーションを作成します。"
---
{{% alert color="info" %}} 

VSTO は、開発者が Microsoft Office 内で実行できるアプリケーションを構築できるように開発されました。VSTO は COM ベースですが、.NET オブジェクトでラップされているため .NET アプリケーションで使用できます。VSTO には .NET フレームワークのサポートと Microsoft Office の CLR ベースのランタイムが必要です。Microsoft Office アドインの作成には使用できますが、サーバーサイド コンポーネントとして使用することはほぼ不可能です。また、展開に関する深刻な問題もあります。

Aspose.Slides for .NET は、VSTO と同様に Microsoft PowerPoint プレゼンテーションを操作できるコンポーネントですが、いくつかの利点があります：

- Aspose.Slides はマネージドコードのみで構成されており、Microsoft Office のランタイムをインストールする必要がありません。
- クライアント側コンポーネントとしても、サーバー側コンポーネントとしても使用できます。
- Aspose.Slides は単一の DLL に収められているため、展開が簡単です。

{{% /alert %}} 
## **プレゼンテーションの作成**
以下に、VSTO と Aspose.Slides for .NET を使用して同じ目的を達成する方法を示す 2 つのコード例を示します。最初の例は[VSTO](/slides/ja/net/create-a-new-presentation/)です；[2 番目の例](/slides/ja/net/create-a-new-presentation/) は Aspose.Slides を使用しています。
### **VSTO の例**
**VSTO の出力** 

![todo:image_alt_text](create-a-new-presentation_1.png)



```c#
//注: PowerPoint は上記のように定義された名前空間です
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//プレゼンテーションを作成
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//タイトル スライドのレイアウトを取得
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//タイトル スライドを追加.
PowerPoint.Slide slide = pres.Slides.AddSlide(1, layout);

//タイトル テキストを設定
slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//サブタイトル テキストを設定
slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//出力をディスクに書き込む
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Aspose.Slides for .NET の例**
**Aspose.Slides の出力** 

![todo:image_alt_text](create-a-new-presentation_2.png)



```c#
using Aspose.Slides;
using Aspose.Slides.Export;

//Create a presentation
Presentation pres = new Presentation();

//Add the title slide
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//Set the title text
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Slide Title Heading";

//Set the sub title text
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Slide Title Sub-Heading";

//Write output to disk
pres.Save("outAsposeSlides.pptx", SaveFormat.Ppt);
```