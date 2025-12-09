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
- Office の自動化
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Microsoft Office の自動化から Aspose.Slides for .NET に移行し、C# でクリーンで信頼性の高いコードを使用して新しい PowerPoint（PPT、PPTX）プレゼンテーションを作成します。"
---

{{% alert color="primary" %}} 

VSTO は、開発者が Microsoft Office 内で実行できるアプリケーションを構築できるように開発されました。VSTO は COM ベースですが、.NET オブジェクトでラップされているため、.NET アプリケーションで使用できます。VSTO は .NET フレームワークのサポートと Microsoft Office の CLR ベースランタイムが必要です。Microsoft Office アドインの作成には使用できますが、サーバー側コンポーネントとして使用することはほぼ不可能です。また、配備に重大な問題があります。

Aspose.Slides for .NET は、VSTO と同様に Microsoft PowerPoint プレゼンテーションを操作できるコンポーネントですが、いくつかの利点があります：

- Aspose.Slides はマネージドコードのみで構成されており、Microsoft Office ランタイムのインストールは不要です。
- クライアント側コンポーネントとしても、サーバー側コンポーネントとしても使用できます。
- Aspose.Slides は単一の DLL に含まれているため、デプロイが簡単です。

{{% /alert %}} 
## **プレゼンテーションの作成**
以下は、VSTO と Aspose.Slides for .NET を使用して同じ目的を達成する方法を示す 2 つのコード例です。最初の例は [VSTO](/slides/ja/net/create-a-new-presentation/); [2 番目の例](/slides/ja/net/create-a-new-presentation/) は Aspose.Slides を使用しています。
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

//タイトル スライドを追加
PowerPoint.Slide slide = pres.Slides.AddSlide(1, layout);

//タイトルテキストを設定
slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//サブタイトルテキストを設定
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
//プレゼンテーションを作成
Presentation pres = new Presentation();

//タイトル スライドを追加
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//タイトルテキストを設定
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Slide Title Heading";

//サブタイトルテキストを設定
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Slide Title Sub-Heading";

//出力をディスクに書き込む
pres.Save("c:\\data\\outAsposeSlides.pptx", SaveFormat.Ppt);
```
