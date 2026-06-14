---
title: Tạo một Bài thuyết trình Mới trong VSTO và Aspose.Slides
type: docs
weight: 80
url: /vi/net/create-a-new-presentation-in-vsto-and-aspose-slides/
---
Dưới đây là hai ví dụ mã minh họa cách VSTO và Aspose.Slides cho .NET có thể được sử dụng để đạt được cùng một mục tiêu.
## **VSTO**
``` csharp

 private void CreatePresentation()

{

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Lấy bố cục slide tiêu đề

PowerPoint.CustomLayout layout = pres.SlideMaster.

	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Thêm một slide tiêu đề.

PowerPoint.Slide slide=pres.Slides.AddSlide(1, layout);

//Đặt văn bản tiêu đề

slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//Đặt văn bản phụ đề

slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//Ghi kết quả ra đĩa

pres.SaveAs("outVSTO.ppt",

	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	Microsoft.Office.Core.MsoTriState.msoFalse);

}

``` 
## **Aspose.Slides**
``` csharp

 private static void CreatePresentation()

{

	//Tạo một bản trình chiếu

	Presentation pres = new Presentation();

	//Thêm slide tiêu đề

	Slide slide = pres.AddTitleSlide();

	//Đặt văn bản tiêu đề

	((TextHolder)slide.Placeholders[0]).Text = "Slide Title Heading";

	//Đặt văn bản phụ đề

	((TextHolder)slide.Placeholders[1]).Text = "Slide Title Sub-Heading";

	//Ghi dữ liệu ra đĩa

	pres.Write("outAsposeSlides.ppt");

}

``` 
## **Tải Mã Mẫu**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Create.a.New.Presentation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Create%20a%20New%20Presentation/)