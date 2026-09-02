---
title: Hiển thị slide dưới dạng hình ảnh SVG
type: docs
weight: 50
url: /vi/net/render-slide-as-svg-image/
---
SVG — viết tắt của Scalable Vector Graphics — là một định dạng đồ họa tiêu chuẩn được sử dụng để hiển thị hình ảnh hai chiều. SVG lưu trữ hình ảnh dưới dạng vector trong XML với các chi tiết định nghĩa hành vi hoặc giao diện của chúng. 

SVG là một trong số ít các định dạng hình ảnh đáp ứng tiêu chuẩn rất cao về: khả năng mở rộng, tương tác, hiệu suất, khả năng tiếp cận, lập trình và các khía cạnh khác. Vì những lý do này, nó thường được dùng trong phát triển web. 

Bạn có thể muốn sử dụng tệp SVG trong các trường hợp sau:

- khi bạn dự định in bài thuyết trình với kích thước rất lớn. Hình ảnh SVG có thể mở rộng tới bất kỳ độ phân giải hoặc mức nào. Bạn có thể thay đổi kích thước hình ảnh SVG bao nhiêu lần cũng được mà không làm giảm chất lượng. 
- khi bạn muốn sử dụng biểu đồ và đồ thị từ các slide trên các phương tiện hoặc nền tảng khác nhau. Hầu hết các trình đọc có thể hiển thị tệp SVG. 
- khi bạn cần sử dụng kích thước hình ảnh nhỏ nhất có thể. Tệp SVG thường nhỏ hơn so với các bản có độ phân giải cao cùng loại ở các định dạng khác, đặc biệt là các định dạng dựa trên bitmap (JPEG hoặc PNG). 

Aspose.Slides for .NET cho phép bạn xuất các slide trong bài thuyết trình dưới dạng **SVG**. Để tạo hình ảnh SVG từ bất kỳ slide nào, thực hiện các bước sau:

- Tạo một thể hiện của lớp Presentation. 
- Duyệt qua tất cả các slide trong bài thuyết trình. 
- Ghi mỗi slide ra một tệp SVG riêng thông qua FileStream. 

{{% alert color="info" %}} 

Bạn có thể thử [ứng dụng web miễn phí](https://products.aspose.app/slides/vi/conversion/ppt-to-svg) mà chúng tôi đã triển khai chức năng chuyển đổi PPT sang SVG từ Aspose.Slides for .NET. 

{{% /alert %}} 

Mã mẫu này bằng C# cho bạn thấy cách chuyển đổi PPT sang SVG bằng Aspose.Slides: 

``` csharp
using Aspose.Slides;

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