---
title: Thêm Khung Hình với Hoạt Ảnh Sử Dụng VSTO và Aspose.Slides cho .NET
linktitle: Khung Hình với Hoạt Ảnh
type: docs
weight: 60
url: /vi/net/adding-picture-frame-with-animation/
keywords:
- khung hình
- thêm hình ảnh
- thêm ảnh
- hình ảnh có hoạt ảnh
- ảnh có hoạt ảnh
- di chuyển
- VSTO
- tự động hóa Office
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Di chuyển từ tự động hóa Microsoft Office sang Aspose.Slides cho .NET và tạo hoạt ảnh cho khung hình trong các slide PowerPoint (PPT, PPTX) bằng mã C# sạch sẽ."
---
{{% alert color="primary" %}} 

Khung hình được áp dụng cho các hình dạng hoặc hình ảnh trong Microsoft PowerPoint để bao quanh hình ảnh trong một bài thuyết trình. Bài viết này hướng dẫn cách tạo một khung hình và áp dụng hoạt ảnh lên nó một cách lập trình bằng cách sử dụng trước tiên [VSTO 2008](/slides/vi/net/adding-picture-frame-with-animation/) rồi sau đó [Aspose.Slides for .NET](/slides/vi/net/adding-picture-frame-with-animation/). Đầu tiên, chúng tôi sẽ cho bạn thấy cách áp dụng khung và hoạt ảnh bằng VSTO 2008. Sau đó, chúng tôi sẽ chỉ cho bạn cách thực hiện các bước tương tự bằng Aspose.Slides for .NET.

{{% /alert %}} 
## **Thêm Khung Hình với Hoạt Ảnh**
Các mẫu mã dưới đây tạo một bài thuyết trình với một slide, thêm một hình ảnh có khung hình và áp dụng hoạt ảnh cho nó.
### **Ví dụ VSTO 2008**
Sử dụng VSTO 2008, thực hiện các bước sau:

1. Tạo một bài thuyết trình.
1. Thêm một slide trống.
1. Thêm một hình dạng hình ảnh vào slide.
1. Áp dụng hoạt ảnh cho hình ảnh.
1. Ghi bài thuyết trình ra đĩa.

**Bài thuyết trình đầu ra, được tạo bằng VSTO** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)



```c#
//Tạo bài thuyết trình rỗng
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Thêm slide trống
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Thêm khung hình
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Áp dụng hoạt ảnh cho khung hình
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Lưu bài thuyết trình
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Ví dụ Aspose.Slides for .NET**
Sử dụng Aspose.Slides for .NET, thực hiện các bước sau:

1. Tạo một bài thuyết trình.
1. Truy cập slide đầu tiên.
1. Thêm một hình ảnh vào bộ sưu tập hình ảnh.
1. Thêm một hình dạng hình ảnh vào slide.
1. Áp dụng hoạt ảnh cho hình ảnh.
1. Ghi bài thuyết trình ra đĩa.

**Bài thuyết trình đầu ra, được tạo bằng Aspose.Slides** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)



```c#
// Tạo một bài thuyết trình rỗng
using (Presentation pres = new Presentation())
{
    // Truy cập slide đầu tiên
    ISlide slide = pres.Slides[0];

    // Thêm hình ảnh vào bộ sưu tập hình ảnh của bài thuyết trình
    IImage image = Images.FromFile("aspose.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Thêm khung hình với chiều cao và chiều rộng khớp với chiều cao và chiều rộng của hình ảnh
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Lấy chuỗi hoạt ảnh chính của slide
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Thêm hiệu ứng bay từ trái cho khung hình
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Lưu bài thuyết trình
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```