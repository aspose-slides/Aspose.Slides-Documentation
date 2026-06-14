---
title: Tạo Slide dưới dạng hình ảnh SVG
type: docs
weight: 70
url: /vi/net/create-slide-as-svg-image/
---
Để tạo hình ảnh SVG từ bất kỳ slide nào mong muốn với Aspose.Slides.Pptx for .NET, vui lòng thực hiện các bước sau:

- Tạo một thể hiện của lớp Presentation.
- Lấy tham chiếu của slide mong muốn bằng cách sử dụng ID hoặc chỉ mục của nó.
- Lấy hình ảnh SVG trong một memory stream.
- Lưu memory stream vào tệp.
## **Ví dụ**

```

 //Tạo một đối tượng lớp Presentation đại diện cho tệp bản trình bày

using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))

{

   //Truy cập slide thứ hai

   ISlide sld = pres.Slides[1];

   //Tạo một đối tượng memory stream

   MemoryStream SvgStream = new MemoryStream();

   //Tạo hình ảnh SVG của slide và lưu vào memory stream

   sld.WriteAsSvg(SvgStream);

   SvgStream.Position = 0;

   //Lưu memory stream vào tệp

   using (Stream fileStream = System.IO.File.OpenWrite("PresentatoinTemplate.svg"))

   {

     byte[] buffer = new byte[8 * 1024];

     int len;

     while ((len = SvgStream.Read(buffer, 0, buffer.Length)) > 0)

     {

       fileStream.Write(buffer, 0, len);

     }

}

SvgStream.Close();

``` 
## **Tải ví dụ đang chạy**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Creating%20Slide%20SVG%20Image)
## **Tải mã mẫu**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Để biết thêm chi tiết, hãy truy cập [Kết xuất các slide trình chiếu dưới dạng hình ảnh SVG trong .NET](/slides/vi/net/render-a-slide-as-an-svg-image/).
{{% /alert %}}