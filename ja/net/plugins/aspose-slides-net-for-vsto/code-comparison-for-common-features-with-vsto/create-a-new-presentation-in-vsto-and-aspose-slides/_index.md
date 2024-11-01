---
title: VSTOおよびAspose.Slidesで新しいプレゼンテーションを作成する
type: docs
weight: 80
url: /ja/net/create-a-new-presentation-in-vsto-and-aspose-slides/
---

以下に、VSTOおよびAspose.Slides for .NETを使用して同じ目標を達成する方法を示す2つのコード例を示します。
## **VSTO**
``` csharp

 private void CreatePresentation()

{

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//タイトルスライドのレイアウトを取得

PowerPoint.CustomLayout layout = pres.SlideMaster.

	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//タイトルスライドを追加

PowerPoint.Slide slide=pres.Slides.AddSlide(1, layout);

//タイトルテキストを設定

slide.Shapes.Title.TextFrame.TextRange.Text = "スライドタイトル";

//サブタイトルテキストを設定

slide.Shapes[2].TextFrame.TextRange.Text = "スライドタイトルサブヘッディング";

//出力をディスクに保存

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp

 private static void CreatePresentation()

{

	//プレゼンテーションを作成

	Presentation pres = new Presentation();

	//タイトルスライドを追加

	Slide slide = pres.AddTitleSlide();

	//タイトルテキストを設定

	((TextHolder)slide.Placeholders[0]).Text = "スライドタイトル";

	//サブタイトルテキストを設定

	((TextHolder)slide.Placeholders[1]).Text = "スライドタイトルサブヘッディング";

	//出力をディスクに保存

	pres.Write("outAsposeSlides.ppt");

}

``` 
## **サンプルコードのダウンロード**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772949)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.a.New.Presentation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Create%20a%20New%20Presentation%20\(Aspose.Slides\).zip)