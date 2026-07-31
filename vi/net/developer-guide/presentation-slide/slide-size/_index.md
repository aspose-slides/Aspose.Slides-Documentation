---
title: Thay đổi kích thước slide của bản trình chiếu trong .NET
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

Kích thước slide phổ biến và tỷ lệ:

- **Standard (4:3 Aspect Ratio)**: Lý tưởng cho các màn hình và thiết bị cũ.
- **Widescreen (16:9 Aspect Ratio)**: Được khuyến nghị cho các máy chiếu và màn hình hiện đại.

Đảm bảo tính nhất quán trong suốt bản trình chiếu vì một kích thước slide và tỷ lệ khung hình duy nhất được áp dụng cho tất cả các slide. Để có kết quả tốt nhất, hãy đặt kích thước slide ngay từ đầu quá trình tạo bản trình chiếu để tránh các vấn đề phát sinh.

{{% alert color="primary" %}} 
Mặc định, các bản trình chiếu được tạo bằng Aspose.Slides sử dụng tỷ lệ chuẩn 4:3.
{{% /alert %}}

## **Cách thay đổi kích thước slide trong một bản trình chiếu**

Ví dụ này minh họa cách thay đổi kích thước slide của bản trình chiếu bằng Aspose.Slides trong C#:

```csharp
using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Xác định kích thước slide tùy chỉnh**

Điều chỉnh kích thước slide cho nhu cầu cụ thể của bạn, chẳng hạn cho bố cục giấy đặc biệt hoặc thông số màn hình, có thể mang lại lợi ích. Dưới đây là cách đặt kích thước slide tùy chỉnh bằng Aspose.Slides cho .NET:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // Kích thước giấy A4
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **Xử lý nội dung slide sau khi thay đổi kích thước**

Sau khi thay đổi kích thước, nội dung slide có thể bị méo. Bạn có thể kiểm soát cách Aspose.Slides xử lý việc thay đổi này:

- **`DoNotScale`**: Giữ các đối tượng ở kích thước gốc để tránh việc phóng to/thu nhỏ.
- **`EnsureFit`**: Thu phóng các đối tượng để vừa với slide nhỏ hơn, ngăn ngừa mất nội dung.
- **`Maximize`**: Phóng lớn các đối tượng để phù hợp với slide lớn hơn, giữ tính nhất quán thẩm mỹ.

Ví dụ về việc sử dụng cài đặt `Maximize` để điều chỉnh kích thước slide:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **Câu hỏi thường gặp**

**Có thể đặt kích thước slide tùy chỉnh bằng các đơn vị khác ngoài inch (ví dụ, điểm hoặc milimet) không?**

Có. Aspose.Slides sử dụng đơn vị điểm (point) nội bộ, trong đó 1 point bằng 1/72 inch. Bạn có thể chuyển đổi bất kỳ đơn vị nào (như milimet hoặc centimet) sang điểm và sử dụng giá trị đã chuyển đổi để xác định chiều rộng và chiều cao của slide.

**Will a very large custom slide size affect performance and memory usage during rendering?**

Có. Kích thước slide lớn hơn (tính bằng point) kết hợp với tỷ lệ render cao sẽ dẫn đến việc tiêu thụ bộ nhớ tăng và thời gian xử lý lâu hơn. Hãy hướng tới một kích thước slide thực tế và chỉ điều chỉnh tỷ lệ render khi cần thiết để đạt chất lượng đầu ra mong muốn.

**Tôi có thể định nghĩa một kích thước slide không chuẩn rồi sau đó kết hợp các slide từ các bản trình chiếu có kích thước khác nhau không?**

Bạn không thể [merge presentations](/slides/vi/net/merge-presentation/) khi chúng có kích thước slide khác nhau — trước tiên, hãy thay đổi kích thước một bản trình chiếu để khớp với bản còn lại. Khi thay đổi kích thước slide, bạn có thể chọn cách xử lý nội dung hiện có qua tùy chọn [SlideSizeScaleType](https://reference.aspose.com/slides/vi/net/aspose.slides/slidesizescaletype/). Sau khi đồng nhất kích thước, bạn có thể hợp nhất các slide mà vẫn giữ định dạng.

**Tôi có thể tạo hình thu nhỏ cho các hình riêng lẻ hoặc các khu vực cụ thể của một slide không, và chúng sẽ tuân theo kích thước slide mới không?**

Có. Aspose.Slides có thể tạo hình thu nhỏ cho [entire slides](https://reference.aspose.com/slides/vi/net/aspose.slides/slide/getimage/) cũng như cho [selected shapes](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/getimage/). Các hình ảnh tạo ra phản ánh kích thước slide hiện tại và tỷ lệ khung hình, đảm bảo khung hình và hình học nhất quán.