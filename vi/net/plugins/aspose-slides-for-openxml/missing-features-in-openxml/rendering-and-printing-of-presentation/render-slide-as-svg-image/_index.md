---
title: Render Slide Thành Ảnh SVG
type: docs
weight: 50
url: /vi/net/render-slide-as-svg-image/
---
SVG—viết tắt của Scalable Vector Graphics—là một loại hoặc định dạng đồ họa chuẩn được dùng để hiển thị hình ảnh hai chiều. SVG lưu trữ hình ảnh dưới dạng vector trong XML kèm theo các chi tiết xác định cách chúng hoạt động hoặc hiển thị. 

SVG là một trong số ít các định dạng hình ảnh đáp ứng các tiêu chuẩn rất cao về: khả năng mở rộng, tính tương tác, hiệu năng, khả năng truy cập, khả năng lập trình, và những yếu tố khác. Vì những lý do này, nó thường được sử dụng trong phát triển web. 

Bạn có thể muốn sử dụng các tệp SVG trong các trường hợp sau:

- khi bạn dự định in bản trình bày ở kích thước rất lớn. Hình ảnh SVG có thể mở rộng tới bất kỳ độ phân giải hay mức độ nào. Bạn có thể thay đổi kích thước hình ảnh SVG bao nhiêu lần cũng được mà không làm giảm chất lượng.
- khi bạn muốn sử dụng các biểu đồ và đồ thị từ slide trên các phương tiện hoặc nền tảng khác nhau. Hầu hết các trình đọc có thể diễn giải các tệp SVG. 
- khi bạn cần sử dụng kích thước hình ảnh nhỏ nhất có thể. Các tệp SVG thường nhỏ hơn so với các bản có độ phân giải cao cùng loại trong các định dạng khác, đặc biệt là các định dạng dựa trên bitmap (JPEG hoặc PNG).

Aspose.Slides cho .NET cho phép bạn xuất các slide trong bản trình bày của mình dưới dạng hình ảnh **SVG**. Để tạo hình ảnh SVG từ bất kỳ slide nào, thực hiện các bước sau:

- Tạo một thể hiện của lớp Presentation.
- Duyệt qua tất cả các slide trong bản trình bày.
- Ghi mỗi slide vào tệp SVG riêng của nó bằng FileStream.

{{% alert color="primary" %}} 
Bạn có thể muốn thử [ứng dụng web miễn phí](https://products.aspose.app/slides/vi/conversion/ppt-to-svg) trong đó chúng tôi đã triển khai chức năng chuyển đổi PPT sang SVG từ Aspose.Slides cho .NET.
{{% /alert %}} 

Mẫu mã dưới đây bằng C# cho bạn thấy cách chuyển đổi PPT sang SVG bằng Aspose.Slides:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (FileStream fileStream = new FileStream($"slide-{index}.svg", FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsSvg(fileStream);   
        }
    }
}
```