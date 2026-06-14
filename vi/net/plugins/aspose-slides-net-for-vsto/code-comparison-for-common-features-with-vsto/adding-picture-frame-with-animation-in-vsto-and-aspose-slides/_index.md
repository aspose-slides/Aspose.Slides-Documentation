---
title: Thêm Khung Hình với Hoạt ảnh trong VSTO và Aspose.Slides
type: docs
weight: 20
url: /vi/net/adding-picture-frame-with-animation-in-vsto-and-aspose-slides/
---
Các mẫu mã dưới đây tạo một bản trình chiếu với một trang chiếu, thêm một hình ảnh với khung hình và áp dụng hoạt ảnh cho nó.
## **VSTO**
Sử dụng VSTO, thực hiện các bước sau:

1. Tạo một bản trình chiếu.
1. Thêm một trang chiếu trống.
1. Thêm một hình dạng ảnh vào trang chiếu.
1. Áp dụng hoạt ảnh cho ảnh.
1. Ghi bản trình chiếu ra đĩa.

``` csharp

 //Tạo bản trình chiếu trống

PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Thêm một slide trống

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Thêm khung hình ảnh

PowerPoint.Shape PicFrame = sld.Shapes.AddPicture("pic.jpeg",

Microsoft.Office.Core.MsoTriState.msoTriStateMixed,

Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Áp dụng hoạt ảnh cho khung hình ảnh

PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Lưu bản trình chiếu

pres.SaveAs("VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **Aspose.Slides**
Sử dụng Aspose.Slides cho .NET, thực hiện các bước sau:

1. Tạo một bản trình chiếu.
1. Truy cập trang chiếu đầu tiên.
1. Thêm một hình ảnh vào bộ sưu tập hình ảnh.
1. Thêm một hình dạng ảnh vào trang chiếu.
1. Áp dụng hoạt ảnh cho ảnh.
1. Ghi bản trình chiếu ra đĩa.

``` csharp

 //Tạo bản trình chiếu trống
Presentation pres = new Presentation();

//Truy cập slide đầu tiên
Slide slide = pres.GetSlideByPosition(1);

//Thêm đối tượng hình ảnh vào bộ sưu tập hình ảnh của bản trình chiếu
Picture pic = new Picture(pres, "pic.jpeg");

//Sau khi đối tượng hình ảnh được thêm, hình ảnh được gán một Id hình ảnh duy nhất
int picId = pres.Pictures.Add(pic);

//Thêm khung hình ảnh
Shape PicFrame = slide.Shapes.AddPictureFrame(picId, 1450, 1100, 2500, 2200);

//Áp dụng hoạt ảnh cho khung hình ảnh
PicFrame.AnimationSettings.EntryEffect = ShapeEntryEffect.BoxIn;

//Lưu bản trình chiếu
pres.Write("AsposeAnim.ppt");

``` 
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Picture.Frame.with.Animation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation/)