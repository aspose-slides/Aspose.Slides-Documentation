---
title: Chuyển đổi Bản trình chiếu sang Tiff với Ghi chú
type: docs
weight: 50
url: /vi/net/convert-presentation-to-tiff-with-notes/
---
TIFF là một trong số các định dạng hình ảnh được sử dụng rộng rãi mà Aspose.Slides for .NET hỗ trợ để chuyển đổi một bản trình chiếu có ghi chú thành hình ảnh. Bạn cũng có thể tạo các hình thu nhỏ của slide trong chế độ xem Notes Slide. Dưới đây là hai đoạn mã cho thấy cách tạo các hình ảnh TIFF của một bản trình chiếu trong chế độ xem Notes Slide.

Phương thức [Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/methods/save) được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) có thể được dùng để chuyển đổi toàn bộ bản trình chiếu trong chế độ xem Notes Slide sang TIFF. Bạn cũng có thể tạo hình thu nhỏ của slide trong chế độ Notes Slide cho các slide riêng lẻ.
## **Ví dụ**

``` 

  //Khởi tạo một đối tượng Presentation đại diện cho một tệp bản trình chiếu

 Presentation pres = new Presentation("Conversion.pptx");

 //Lưu bản trình chiếu dưới dạng TIFF có ghi chú

 pres.Save("ConvertedwithNotes.tiff", SaveFormat.TiffNotes);

``` 
## **Tải ví dụ đang chạy**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Tiff%20conversion%20with%20note)
## **Tải mã mẫu**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Để biết thêm chi tiết, hãy truy cập [Convert PowerPoint Presentations to TIFF with Notes in .NET](/slides/vi/net/convert-powerpoint-to-tiff-with-notes/).
{{% /alert %}}