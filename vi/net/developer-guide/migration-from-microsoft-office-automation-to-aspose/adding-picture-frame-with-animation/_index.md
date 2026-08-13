---
title: Thêm Khung Hình với Hoạt Ảnh Sử Dụng VSTO và Aspose.Slides cho .NET
linktitle: Khung Hình với Hoạt Ảnh
type: docs
weight: 60
url: /vi/net/adding-picture-frame-with-animation/
keywords:
- khung hình
- thêm ảnh
- thêm hình
- ảnh có hoạt ảnh
- hình có hoạt ảnh
- di chuyển
- VSTO
- tự động hoá Office
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Di chuyển từ tự động hoá Microsoft Office sang Aspose.Slides cho .NET và tạo hoạt ảnh cho khung hình trong các slide PowerPoint (PPT, PPTX) bằng mã C# sạch."
---
{{% alert color="info" %}} 

Khung hình được áp dụng cho các hình dạng hoặc hình ảnh trong Microsoft PowerPoint để bao quanh hình ảnh trong một bài thuyết trình. Bài viết này trình bày cách tạo khung hình và áp dụng hoạt ảnh cho nó một cách lập trình, trước tiên bằng [VSTO 2008](/slides/vi/net/adding-picture-frame-with-animation/) và sau đó bằng [Aspose.Slides for .NET](/slides/vi/net/adding-picture-frame-with-animation/). Đầu tiên, chúng tôi sẽ chỉ cho bạn cách áp dụng khung và hoạt ảnh bằng VSTO 2008. Sau đó, chúng tôi sẽ chỉ cách thực hiện các bước tương tự bằng Aspose.Slides for .NET.

{{% /alert %}} 
## **Thêm Khung Hình với Hoạt Ảnh**
Các mẫu mã dưới đây tạo một bản trình bày với một slide, thêm một hình ảnh với khung hình và áp dụng hoạt ảnh cho nó.
### **Ví dụ VSTO 2008**
Sử dụng VSTO 2008, thực hiện các bước sau:

1. Tạo một bản trình bày.
1. Thêm một slide trống.
1. Thêm một hình dạng ảnh vào slide.
1. Áp dụng hoạt ảnh cho ảnh.
1. Ghi bản trình bày ra đĩa.

**Bản trình bày đầu ra, được tạo bằng VSTO** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)



```c#
 //Tạo bản trình bày trống
 PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
 
 //Thêm slide trống
 PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);
 
 //Thêm khung hình
 PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
 Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
 Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);
 
 //Áp dụng hoạt ảnh cho khung hình
 PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;
 
 //Lưu bản trình bày
 pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
 Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Ví dụ Aspose.Slides for .NET**
Sử dụng Aspose.Slides for .NET, thực hiện các bước sau:

1. Tạo một bản trình bày.
1. Truy cập slide đầu tiên.
1. Thêm một hình ảnh vào bộ sưu tập hình ảnh.
1. Thêm một hình dạng ảnh vào slide.
1. Áp dụng hoạt ảnh cho ảnh.
1. Ghi bản trình bày ra đĩa.

**Bản trình bày đầu ra, được tạo bằng Aspose.Slides** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)



```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Tạo một bản trình bày trống
using (Presentation pres = new Presentation())
{
    // Truy cập slide đầu tiên
    ISlide slide = pres.Slides[0];

    // Thêm một hình ảnh vào bộ sưu tập hình ảnh của bản trình bày
    IImage image = Images.FromFile("aspose.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Thêm khung hình ảnh có chiều cao và chiều rộng bằng với chiều cao và chiều rộng của hình ảnh
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Lấy chuỗi hoạt ảnh chính của slide
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Thêm hiệu ứng hoạt ảnh Bay từ Trái vào khung hình ảnh
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Lưu bản trình bày
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```