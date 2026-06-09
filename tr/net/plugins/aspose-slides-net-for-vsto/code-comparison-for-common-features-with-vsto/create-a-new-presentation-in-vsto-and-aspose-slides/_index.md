---
title: VSTO ve Aspose.Slides ile Yeni Bir Sunum Oluşturma
type: docs
weight: 80
url: /tr/net/create-a-new-presentation-in-vsto-and-aspose-slides/
---
Aşağıda, VSTO ve Aspose.Slides for .NET'in aynı hedefe ulaşmak için nasıl kullanılabileceğini gösteren iki kod örneği bulunmaktadır.
## **VSTO**
``` csharp

 private void CreatePresentation()

{

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Başlık slaytı düzenini al

PowerPoint.CustomLayout layout = pres.SlideMaster.

	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Başlık slaytı ekle.

PowerPoint.Slide slide=pres.Slides.AddSlide(1, layout);

//Başlık metnini ayarla

slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//Alt başlık metnini ayarla

slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//Çıktıyı diske yaz

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp

 private static void CreatePresentation()

{

	//Bir sunum oluştur

	Presentation pres = new Presentation();

	//Başlık slaytını ekle

	Slide slide = pres.AddTitleSlide();

	//Başlık metnini ayarla

	((TextHolder)slide.Placeholders[0]).Text = "Slide Title Heading";

	//Alt başlık metnini ayarla

	((TextHolder)slide.Placeholders[1]).Text = "Slide Title Sub-Heading";

	//Çıktıyı diske yaz

	pres.Write("outAsposeSlides.ppt");

}
``` 
## **Örnek Kodu İndir**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.a.New.Presentation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation/)