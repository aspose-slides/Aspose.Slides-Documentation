---
title: Chuyển đổi tài liệu OpenOffice
type: docs
weight: 30
url: /vi/net/conversion-of-openoffice-document/
---
Aspose.Slides for .NET cung cấp lớp **Presentation** đại diện cho một tệp trình chiếu. Lớp **Presentation** hiện có thể truy cập **ODP** thông qua hàm khởi tạo Presentation khi đối tượng được tạo.

Dưới đây là ví dụ chuyển đổi từ ODP sang PPT/PPTX.
## **Ví dụ**
```

 //Khởi tạo một đối tượng Presentation đại diện cho một tệp trình chiếu

using(PresentationEx pres = new PresentationEx("OpenOfficePresentation.odp"))

{

   //Lưu bản trình chiếu PPTX thành định dạng PPTX

   pres.Save("ConvertedFromOdp",Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 

Dưới đây là ví dụ chuyển đổi từ PPT/PPTX sang ODP.
## **Ví dụ**
``` 

 //Khởi tạo một đối tượng Presentation đại diện cho một tệp trình chiếu

using (PresentationEx pres = new PresentationEx("ConversionFromPresentation.pptx"))

{

   //Lưu bản trình chiếu PPTX thành định dạng PPTX

   pres.Save("ConvertedToOdp", Aspose.Slides.Export.SaveFormat.Odp);

}

``` 
## **Tải ví dụ đang chạy**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Conversion%20from%20ODP%20to%20PPTX)
## **Tải mã mẫu**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)