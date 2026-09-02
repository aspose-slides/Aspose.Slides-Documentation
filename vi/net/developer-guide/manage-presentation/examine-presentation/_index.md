---
title: Truy xuất và Cập nhật Thông tin Bản trình chiếu trong .NET
linktitle: Thông tin Bản trình chiếu
type: docs
weight: 30
url: /vi/net/examine-presentation/
keywords:
- định dạng bản trình chiếu
- thuộc tính bản trình chiếu
- thuộc tính tài liệu
- lấy thuộc tính
- đọc thuộc tính
- thay đổi thuộc tính
- sửa đổi thuộc tính
- cập nhật thuộc tính
- kiểm tra PPTX
- kiểm tra PPT
- kiểm tra ODP
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Khám phá các slide, cấu trúc và siêu dữ liệu trong các bản trình chiếu PowerPoint và OpenDocument bằng .NET để có cái nhìn nhanh hơn và kiểm toán nội dung thông minh hơn."
---
## **Tổng quan**

Bài viết này trình bày cách kiểm tra thông tin bản trình chiếu trong Aspose.Slides. Nó giải thích cách xác định định dạng hiện tại của bản trình chiếu mà không phải tải toàn bộ tệp, đọc các thuộc tính tài liệu của nó và cập nhật các thuộc tính đó khi cần.

Các ví dụ dựa trên các API [PresentationInfo](https://reference.aspose.com/slides/vi/net/aspose.slides/presentationinfo/) và [DocumentProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/documentproperties/) và minh họa các thao tác điển hình để làm việc với siêu dữ liệu bản trình chiếu.

## **Kiểm tra Định dạng Bản trình chiếu**

Trước khi làm việc với một bản trình chiếu, bạn có thể muốn biết định dạng hiện tại của bản trình chiếu (PPT, PPTX, ODP và các định dạng khác) là gì.

Bạn có thể kiểm tra định dạng của bản trình chiếu mà không tải nó. Xem đoạn mã C# sau:

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **Lấy Thuộc tính Bản trình chiếu**

Đoạn mã C# này cho bạn thấy cách lấy các thuộc tính của bản trình chiếu (thông tin về bản trình chiếu):

```c#
using Aspose.Slides;

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// ..
```

Bạn có thể muốn xem các [thuộc tính trong lớp DocumentProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/documentproperties/#properties).

## **Cập nhật Thuộc tính Bản trình chiếu**

Aspose.Slides cung cấp phương thức [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) cho phép bạn thay đổi các thuộc tính của bản trình chiếu.

Giả sử chúng ta có một bản trình chiếu PowerPoint với các thuộc tính tài liệu như dưới đây.

![Các thuộc tính tài liệu gốc của bản trình chiếu PowerPoint](input_properties.png)

Ví dụ mã này cho bạn thấy cách chỉnh sửa một số thuộc tính của bản trình chiếu:

```c#
using Aspose.Slides;

string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

Kết quả của việc thay đổi các thuộc tính tài liệu được hiển thị dưới đây.

![Các thuộc tính tài liệu đã thay đổi của bản trình chiếu PowerPoint](output_properties.png)

## **Liên kết Hữu ích**

Để nhận thêm thông tin về một bản trình chiếu và các thuộc tính bảo mật của nó, bạn có thể thấy các liên kết sau hữu ích:

- [Bảo mật Bản trình chiếu bằng Mật khẩu](/slides/vi/net/password-protected-presentation/)
- [Bảo vệ Bản trình chiếu khi Ghi](/slides/vi/net/write-protected-presentation/)

## **Câu hỏi Thường gặp**

**Làm sao tôi có thể kiểm tra xem phông chữ có được nhúng hay không và đó là những phông chữ nào?**

Tìm thông tin [thông tin phông chữ được nhúng](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsmanager/getembeddedfonts/) ở cấp độ bản trình chiếu, sau đó so sánh các mục này với tập hợp [phông chữ thực tế được sử dụng trong nội dung](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsmanager/getfonts/) để xác định phông chữ nào là quan trọng cho việc hiển thị.

**Làm sao tôi có thể nhanh chóng xác định xem tệp có slide ẩn và có bao nhiêu không?**

Duyệt qua [bộ sưu tập slide](https://reference.aspose.com/slides/vi/net/aspose.slides/slidecollection/) và kiểm tra [cờ hiển thị](https://reference.aspose.com/slides/vi/net/aspose.slides/slide/hidden/) của mỗi slide.

**Tôi có thể phát hiện liệu kích thước slide tùy chỉnh và hướng của nó có được sử dụng không, và chúng có khác so với mặc định không?**

Có. So sánh [kích thước slide](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/slidesize/) và hướng hiện tại với các cấu hình mặc định; điều này giúp dự đoán cách hoạt động khi in và xuất.

**Có cách nhanh để xem các biểu đồ có tham chiếu tới nguồn dữ liệu bên ngoài không?**

Có. Duyệt qua tất cả các [biểu đồ](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/chart/), kiểm tra [nguồn dữ liệu](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/chartdata/datasourcetype/) của chúng, và ghi chú liệu dữ liệu là nội bộ hay dựa trên liên kết, bao gồm cả các liên kết bị hỏng.

**Làm sao tôi có thể đánh giá các slide 'nặng' có thể làm chậm quá trình render hoặc xuất PDF?**

Đối với mỗi slide, đếm số lượng đối tượng và tìm các hình ảnh lớn, độ trong suốt, bóng đổ, hoạt ảnh và đa phương tiện; gán một điểm phức tạp ước lượng để đánh dấu các điểm nóng tiềm năng về hiệu năng.