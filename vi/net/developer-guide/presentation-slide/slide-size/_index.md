---
title: Thay đổi Kích thước Slide trong Bài thuyết trình bằng .NET
linktitle: Kích thước Slide
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
- kích thước slide độc nhất
- slide kích thước đầy đủ
- loại màn hình
- không phóng to
- đảm bảo vừa
- tối đa hoá
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
descriptions: "Tìm hiểu cách nhanh chóng thay đổi kích thước slide trong các tệp PPT, PPTX và ODP bằng .NET và Aspose.Slides, tối ưu hoá bài thuyết trình cho bất kỳ màn hình nào mà không mất chất lượng."
---
## **Giới thiệu**

Aspose.Slides cho .NET cung cấp các công cụ toàn diện để điều chỉnh kích thước slide và tỷ lệ khung hình trong các bài thuyết trình PowerPoint, quan trọng cho cả việc in ấn và hiển thị trên màn hình. 

Các kích thước slide và tỷ lệ phổ biến:

- **Standard (Tỷ lệ 4:3)**: Lý tưởng cho các màn hình và thiết bị cũ.
- **Widescreen (Tỷ lệ 16:9)**: Được đề xuất cho máy chiếu và màn hình hiện đại.

Đảm bảo tính nhất quán trong toàn bộ bài thuyết trình vì một kích thước slide và tỷ lệ khung hình duy nhất sẽ áp dụng cho tất cả các slide. Để đạt kết quả tốt nhất, hãy đặt kích thước slide ngay từ đầu quá trình tạo bài thuyết trình để tránh các vấn đề phát sinh.

{{% alert color="primary" %}} 
Mặc định, các bài thuyết trình được tạo bằng Aspose.Slides sử dụng tỷ lệ 4:3 tiêu chuẩn.
{{% /alert %}}

## **Cách thay đổi kích thước slide trong một bài thuyết trình**

Ví dụ này minh họa cách thay đổi kích thước slide của một bài thuyết trình bằng Aspose.Slides trong C#:

```csharp
using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## **Xác định kích thước slide tùy chỉnh**

Điều chỉnh kích thước slide theo nhu cầu cụ thể của bạn, chẳng hạn cho bố cục giấy độc đáo hoặc thông số màn hình, có thể mang lại lợi ích. Dưới đây là cách thiết lập kích thước slide tùy chỉnh với Aspose.Slides cho .NET:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // Kích thước giấy A4
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## **Xử lý nội dung slide sau khi thay đổi kích thước**

Sau khi thay đổi kích thước, nội dung slide có thể bị biến dạng. Bạn có thể kiểm soát cách Aspose.Slides xử lý việc này:

- **`DoNotScale`**: Giữ các đối tượng ở kích thước gốc để tránh phóng to/thu nhỏ.
- **`EnsureFit`**: Thu phóng các đối tượng để phù hợp với slide nhỏ hơn, tránh mất nội dung.
- **`Maximize`**: Phóng to các đối tượng để phù hợp với slide lớn hơn nhằm duy trì tính thẩm mỹ.

Ví dụ về việc sử dụng thiết lập `Maximize` để điều chỉnh kích thước slide:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```

## **FAQ**

**Tôi có thể đặt kích thước slide tùy chỉnh bằng các đơn vị khác ngoài inch (ví dụ, point hoặc milimet) không?**

Có. Aspose.Slides sử dụng đơn vị point nội bộ, trong đó 1 point bằng 1/72 inch. Bạn có thể chuyển đổi bất kỳ đơn vị nào (như milimet hoặc centimet) sang point và dùng các giá trị đã chuyển để xác định chiều rộng và chiều cao slide.

**Kích thước slide tùy chỉnh rất lớn có ảnh hưởng đến hiệu năng và mức tiêu thụ bộ nhớ khi render không?**

Có. Kích thước slide lớn hơn (theo point) kết hợp với tỷ lệ render cao sẽ làm tăng mức tiêu thụ bộ nhớ và thời gian xử lý. Hãy hướng đến một kích thước slide thực tế và chỉ điều chỉnh tỷ lệ render khi cần thiết để đạt chất lượng đầu ra mong muốn.

**Tôi có thể định nghĩa một kích thước slide không chuẩn và sau đó hợp nhất các slide từ các bài thuyết trình có kích thước khác nhau không?**

Bạn không thể [merge presentations](/slides/vi/net/merge-presentation/) khi chúng có kích thước slide khác nhau — trước tiên, hãy thay đổi kích thước một bài thuyết trình cho khớp với bài kia. Khi thay đổi kích thước slide, bạn có thể chọn cách xử lý nội dung hiện có thông qua tùy chọn [SlideSizeScaleType](https://reference.aspose.com/slides/vi/net/aspose.slides/slidesizescaletype/). Sau khi đồng nhất kích thước, bạn có thể hợp nhất các slide mà vẫn giữ định dạng.

**Tôi có thể tạo thumbnail cho các shape riêng lẻ hoặc các vùng cụ thể của slide không, và chúng có tuân theo kích thước slide mới không?**

Có. Aspose.Slides có thể tạo thumbnail cho [entire slides](https://reference.aspose.com/slides/vi/net/aspose.slides/slide/getimage/) cũng như cho [selected shapes](https://reference.aspose.com/slides/vi/net/aspose.slides/shape/getimage/). Các hình ảnh tạo ra phản ánh kích thước slide và tỷ lệ khung hình hiện tại, đảm bảo khung hình và hình học nhất quán.