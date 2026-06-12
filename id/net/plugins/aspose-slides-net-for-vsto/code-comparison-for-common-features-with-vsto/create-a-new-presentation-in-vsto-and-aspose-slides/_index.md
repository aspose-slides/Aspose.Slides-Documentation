---
title: Buat Presentasi Baru di VSTO dan Aspose.Slides
type: docs
weight: 80
url: /id/net/create-a-new-presentation-in-vsto-and-aspose-slides/
---
Berikut dua contoh kode yang menunjukkan bagaimana VSTO dan Aspose.Slides untuk .NET dapat digunakan untuk mencapai tujuan yang sama.
## **VSTO**
``` csharp

 private void CreatePresentation()
{
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//Dapatkan tata letak slide judul
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];
//Tambahkan slide judul.
PowerPoint.Slide slide=pres.Slides.AddSlide(1, layout);
//Setel teks judul
slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";
//Setel teks sub judul
slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";
//Tuliskan output ke disk
pres.SaveAs("outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
}
``` 
## **Aspose.Slides**
``` csharp

 private static void CreatePresentation()
{
	//Buat presentasi
	Presentation pres = new Presentation();
	//Tambahkan slide judul
	Slide slide = pres.AddTitleSlide();
	//Setel teks judul
	((TextHolder)slide.Placeholders[0]).Text = "Slide Title Heading";
	//Setel teks sub judul
	((TextHolder)slide.Placeholders[1]).Text = "Slide Title Sub-Heading";
	//Tuliskan output ke disk
	pres.Write("outAsposeSlides.ppt");
}
``` 
## **Unduh Kode Contoh**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.a.New.Presentation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation/)