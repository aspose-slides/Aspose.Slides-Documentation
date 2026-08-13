---
title: Thay đổi kích thước slide của bản trình chiếu trong .NET
linktitle: Kích thước slide
type: docs
weight: 70
url: /vi/net/slide-size/
keywords:
- kích thước slide
- tỷ lệ khung hình
- tiêu chuẩn
- màn hình rộng
- 4:3
- 16:9
- đặt kích thước slide
- thay đổi kích thước slide
- kích thước slide tùy chỉnh
- kích thước slide đặc biệt
- kích thước slide độc đáo
- slide kích thước đầy đủ
- loại màn hình
- không thu phóng
- đảm bảo vừa
- tối đa hoá
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách nhanh chóng thay đổi kích thước slide trong các tệp PPT, PPTX và ODP bằng .NET và Aspose.Slides, tối ưu hóa bản trình chiếu cho mọi loại màn hình mà không làm giảm chất lượng."
---
## **Giới thiệu**

Aspose.Slides for .NET cung cấp các công cụ toàn diện để điều chỉnh kích thước slide và tỷ lệ khung hình trong các bản trình chiếu PowerPoint, rất quan trọng cho cả việc in ấn và hiển thị trên màn hình. 

Các kích thước slide và tỷ lệ phổ biến:

- **Standard (4:3 Aspect Ratio)**: Phù hợp với các màn hình và thiết bị cũ.
- **Widescreen (16:9 Aspect Ratio)**: Được khuyên dùng cho máy chiếu và màn hình hiện đại.

Đảm bảo tính nhất quán trong toàn bộ bản trình chiếu vì một kích thước slide và tỷ lệ khung hình duy nhất sẽ áp dụng cho tất cả các slide. Để đạt kết quả tối ưu, hãy đặt kích thước slide ngay từ đầu quá trình tạo bản trình chiếu để tránh các vấn đề phát sinh.

{{% alert color="info" %}} 
Mặc định, các bản trình chiếu được tạo bằng Aspose.Slides sử dụng tỷ lệ 4:3 tiêu chuẩn.
{{% /alert %}}

## **Cách thay đổi kích thước slide trong bản trình chiếu**

Ví dụ này minh họa cách thay đổi kích thước slide của một bản trình chiếu bằng Aspose.Slides trong C#:

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

Việc điều chỉnh kích thước slide cho phù hợp với nhu cầu cụ thể của bạn, chẳng hạn cho các bố cục giấy đặc biệt hoặc yêu cầu màn hình, có thể mang lại lợi ích. Dưới đây là cách đặt kích thước slide tùy chỉnh với Aspose.Slides for .NET:

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

- **`DoNotScale`**: Giữ các đối tượng ở kích thước gốc để tránh phóng to/thu nhỏ.
- **`EnsureFit`**: Thu nhỏ các đối tượng để vừa với slide nhỏ hơn, ngăn ngừa mất nội dung.
- **`Maximize`**: Phóng to các đối tượng để phù hợp với slide lớn hơn, đảm bảo tính thẩm mỹ.

Ví dụ về việc sử dụng thiết lập `Maximize` để điều chỉnh kích thước slide:

```csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **Câu hỏi thường gặp**

### Tôi có thể đặt kích thước slide tùy chỉnh bằng đơn vị khác ngoài inch (ví dụ, point hoặc milimét) không?

Có. Aspose.Slides sử dụng đơn vị point nội bộ, trong đó 1 point bằng 1/72 inch. Bạn có thể chuyển đổi bất kỳ đơn vị nào (như milimét hoặc centimet) sang point và sử dụng các giá trị đã chuyển để xác định chiều rộng và chiều cao slide.

### Kích thước slide tùy chỉnh rất lớn sẽ ảnh hưởng đến hiệu suất và bộ nhớ khi render không?

Có. Kích thước slide lớn hơn (tính bằng point) kết hợp với tỷ lệ render cao sẽ làm tăng mức tiêu thụ bộ nhớ và thời gian xử lý. Hãy chọn một kích thước slide thực tế và chỉ điều chỉnh tỷ lệ render khi cần thiết để đạt chất lượng đầu ra mong muốn.

### Tôi có thể định một kích thước slide không tiêu chuẩn rồi sau đó hợp nhất các slide từ các bản trình chiếu có kích thước khác nhau không?

Bạn không thể [merge presentations](/slides/vi/net/merge-presentation/) khi chúng có kích thước slide khác nhau — trước hết, hãy thay đổi kích thước một bản trình chiếu sao cho khớp với bản còn lại. Khi thay đổi kích thước slide, bạn có thể chọn cách xử lý nội dung hiện có qua tùy chọn [SlideSizeScaleType](https://reference.aspose.com/slides/vi/net/aspose.slides/slidesizescaletype/). Sau khi đồng bộ kích thước, bạn có thể hợp nhất các slide mà vẫn giữ định dạng.

### Tôi có thể tạo thumbnail cho các hình dạng riêng lẻ hoặc khu vực cụ thể của một slide, và chúng có tuân theo kích thước slide mới không?

Có. Aspose.Slides có thể tạo thumbnail cho [entire slides](https://reference.aspose.com/slides/vi/net/aspose.slides/slide/getimage/) cũng như cho [selected shapes](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/getimage/). Các hình ảnh tạo ra sẽ phản ánh kích thước slide và tỷ lệ khung hình hiện tại, đảm bảo khung hình và hình học nhất quán.