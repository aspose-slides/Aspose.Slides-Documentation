---
title: Thay đổi kích thước slide trong bài thuyết trình bằng .NET
linktitle: Kích thước slide
type: docs
weight: 70
url: /vi/net/slide-size/
keywords:
- kích thước slide
- tỷ lệ khung hình
- chuẩn
- màn hình rộng
- 4:3
- 16:9
- đặt kích thước slide
- thay đổi kích thước slide
- kích thước slide tùy chỉnh
- kích thước slide đặc biệt
- kích thước slide duy nhất
- slide kích thước đầy đủ
- loại màn hình
- không co giãn
- đảm bảo vừa
- tối đa hoá
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách nhanh chóng thay đổi kích thước slide trong các tệp PPT, PPTX và ODP bằng .NET và Aspose.Slides, tối ưu hóa bài thuyết trình cho mọi loại màn hình mà không làm giảm chất lượng."
---
## **Giới thiệu**

Aspose.Slides for .NET cung cấp các công cụ toàn diện để điều chỉnh kích thước slide và tỷ lệ khung hình trong các bài thuyết trình PowerPoint, rất quan trọng cho cả việc in ấn và hiển thị trên màn hình.

Các kích thước slide và tỷ lệ phổ biến:

- **Standard (4:3 Aspect Ratio)**: Phù hợp cho các màn hình và thiết bị cũ.
- **Widescreen (16:9 Aspect Ratio)**: Được khuyến nghị cho máy chiếu và màn hình hiện đại.

Đảm bảo tính nhất quán trong toàn bộ bài thuyết trình vì một kích thước slide và tỷ lệ khung hình duy nhất sẽ áp dụng cho tất cả các slide. Để có kết quả tốt nhất, hãy đặt kích thước slide ngay từ đầu quá trình tạo bài thuyết trình để tránh các vấn đề phức tạp.

{{% alert color="info" %}} 
Mặc định, các bài thuyết trình được tạo bằng Aspose.Slides sử dụng tỷ lệ khung hình chuẩn 4:3.
{{% /alert %}}

Trang ghi chú và bản phát tay có kích thước riêng so với các slide thường. Xem [Notes Page Size](/slides/vi/net/notes-size/) để thay đổi kích thước và hướng của chúng.

## **Cách thay đổi kích thước slide trong bài thuyết trình**

Ví dụ này minh họa cách thay đổi kích thước slide của một bài thuyết trình bằng Aspose.Slides trong C#:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Xác định kích thước slide tùy chỉnh**

Việc tùy chỉnh kích thước slide theo nhu cầu cụ thể, chẳng hạn cho các bố cục giấy đặc biệt hoặc thông số màn hình, có thể rất hữu ích. Dưới đây là cách đặt kích thước slide tùy chỉnh với Aspose.Slides for .NET:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // Kích thước giấy A4
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **Xử lý nội dung slide sau khi thay đổi kích thước**

Sau khi thay đổi kích thước, nội dung slide có thể bị biến dạng. Bạn có thể kiểm soát cách Aspose.Slides quản lý việc thay đổi này:

- **`DoNotScale`**: Giữ các đối tượng ở kích thước gốc để tránh phép co giãn.
- **`EnsureFit`**: Thu nhỏ các đối tượng để vừa với slide nhỏ hơn, ngăn ngừa mất nội dung.
- **`Maximize`**: Phóng to các đối tượng để phù hợp với slide lớn hơn, duy trì tính thẩm mỹ.

Ví dụ sử dụng thiết lập `Maximize` cho việc điều chỉnh kích thước slide:

```csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **Câu hỏi thường gặp**

### Tôi có thể đặt kích thước slide tùy chỉnh bằng đơn vị khác ngoài inch (ví dụ, điểm hoặc milimet) không?

Có. Aspose.Slides sử dụng đơn vị điểm nội bộ, trong đó 1 point bằng 1/72 inch. Bạn có thể chuyển đổi bất kỳ đơn vị nào (như milimet hoặc centimet) sang điểm và sử dụng các giá trị đã chuyển để xác định chiều rộng và chiều cao slide.

### Kích thước slide tùy chỉnh rất lớn có ảnh hưởng đến hiệu suất và mức tiêu thụ bộ nhớ khi render không?

Có. Kích thước slide lớn hơn (tính bằng điểm) kết hợp với tỷ lệ render cao sẽ làm tăng mức tiêu thụ bộ nhớ và thời gian xử lý. Hãy chọn kích thước slide thực tế và chỉ điều chỉnh tỷ lệ render khi cần để đạt được chất lượng đầu ra mong muốn.

### Tôi có thể định nghĩa một kích thước slide phi chuẩn rồi hợp nhất các slide từ các bài thuyết trình có kích thước khác nhau không?

Bạn không thể [merge presentations](/slides/vi/net/merge-presentation/) khi chúng có kích thước slide khác nhau — trước tiên, hãy thay đổi kích thước một bài thuyết trình để khớp với bài còn lại. Khi thay đổi kích thước slide, bạn có thể chọn cách xử lý nội dung hiện có thông qua tùy chọn [SlideSizeScaleType](https://reference.aspose.com/slides/vi/net/aspose.slides/slidesizescaletype/). Sau khi đồng nhất kích thước, bạn có thể hợp nhất các slide mà vẫn giữ nguyên định dạng.

### Tôi có thể tạo hình thu nhỏ cho các hình dạng riêng lẻ hoặc khu vực cụ thể của slide không, và chúng có tuân theo kích thước slide mới không?

Có. Aspose.Slides có thể tạo hình thu nhỏ cho [entire slides](https://reference.aspose.com/slides/vi/net/aspose.slides/slide/getimage/) cũng như cho [selected shapes](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/getimage/). Các hình ảnh tạo ra phản ánh kích thước slide và tỷ lệ khung hình hiện tại, đảm bảo khung hình và hình học nhất quán.