---
title: Truy xuất và Cập nhật Thông tin Trình chiếu trong .NET
linktitle: Thông tin Trình chiếu
type: docs
weight: 30
url: /vi/net/examine-presentation/
keywords:
- định dạng trình chiếu
- thuộc tính trình chiếu
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
- trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Khám phá các slide, cấu trúc và siêu dữ liệu trong các trình chiếu PowerPoint và OpenDocument bằng .NET để có những hiểu biết nhanh hơn và kiểm tra nội dung thông minh hơn."
---
## **Tổng quan**

Bài viết này hướng dẫn cách kiểm tra thông tin trình chiếu trong Aspose.Slides. Nó giải thích cách xác định định dạng hiện tại của một bản trình chiếu mà không cần tải toàn bộ tệp, đọc các thuộc tính tài liệu của nó và cập nhật các thuộc tính đó khi cần.

Các ví dụ dựa trên các API [PresentationInfo](https://reference.aspose.com/slides/vi/net/aspose.slides/presentationinfo/) và [DocumentProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/documentproperties/) và minh họa các thao tác điển hình khi làm việc với siêu dữ liệu của trình chiếu.

## **Kiểm tra định dạng trình chiếu**

Trước khi làm việc trên một trình chiếu, bạn có thể muốn biết định dạng (PPT, PPTX, ODP và các định dạng khác) hiện tại của trình chiếu là gì.

Bạn có thể kiểm tra định dạng của trình chiếu mà không cần tải trình chiếu. Xem đoạn mã C# dưới đây:

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
Console.WriteLine(info.LoadFormat); // PPTX

IPresentationInfo info2 = PresentationFactory.Instance.GetPresentationInfo("pres.ppt");
Console.WriteLine(info2.LoadFormat); // PPT

IPresentationInfo info3 = PresentationFactory.Instance.GetPresentationInfo("pres.odp");
Console.WriteLine(info3.LoadFormat); // ODP
```

## **Lấy thuộc tính trình chiếu**

Đoạn mã C# này cho bạn cách lấy các thuộc tính của trình chiếu (thông tin về trình chiếu):

```c#
IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo("pres.pptx");
IDocumentProperties props = info.ReadDocumentProperties();
Console.WriteLine(props.CreatedTime);
Console.WriteLine(props.Subject);
Console.WriteLine(props.Title);
// ..
```

Bạn có thể muốn xem [các thuộc tính trong lớp DocumentProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/documentproperties/#properties).

## **Cập nhật thuộc tính trình chiếu**

Aspose.Slides cung cấp phương thức [PresentationInfo.UpdateDocumentProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/presentationinfo/methods/updatedocumentproperties) cho phép bạn thực hiện các thay đổi đối với các thuộc tính của trình chiếu.

Giả sử chúng ta có một bản PowerPoint với các thuộc tính tài liệu được hiển thị bên dưới.

![Thuộc tính tài liệu gốc của bản PowerPoint](input_properties.png)

Ví dụ mã này cho bạn cách chỉnh sửa một số thuộc tính của trình chiếu:

```c#
string fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.Instance.GetPresentationInfo(fileName);

IDocumentProperties properties = info.ReadDocumentProperties();
properties.Title = "My title";
properties.LastSavedTime = DateTime.Now;

info.UpdateDocumentProperties(properties);
info.WriteBindedPresentation(fileName);
```

Kết quả của việc thay đổi các thuộc tính tài liệu được hiển thị bên dưới.

![Thuộc tính tài liệu đã thay đổi của bản PowerPoint](output_properties.png)

## **Liên kết hữu ích**

Để có thêm thông tin về một trình chiếu và các thuộc tính bảo mật của nó, bạn có thể thấy các liên kết sau hữu ích:

- [Kiểm tra xem trình chiếu có được mã hoá không](https://docs.aspose.com/slides/vi/net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Kiểm tra xem trình chiếu có được bảo vệ ghi (chỉ đọc) không](https://docs.aspose.com/slides/vi/net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Kiểm tra xem trình chiếu có được bảo vệ bằng mật khẩu trước khi tải không](https://docs.aspose.com/slides/vi/net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Xác nhận mật khẩu đã dùng để bảo vệ trình chiếu](https://docs.aspose.com/slides/vi/net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **Câu hỏi thường gặp**

**Làm thế nào tôi có thể kiểm tra xem phông chữ có được nhúng hay không và chúng là những phông nào?**

Tìm thông tin [phông chữ được nhúng](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsmanager/getembeddedfonts/) ở cấp trình chiếu, sau đó so sánh các mục này với tập hợp [phông chữ thực tế được sử dụng trong nội dung](https://reference.aspose.com/slides/vi/net/aspose.slides/fontsmanager/getfonts/) để xác định phông chữ nào là quan trọng cho việc render.

**Làm sao tôi có thể nhanh chóng biết tệp có các slide ẩn và có bao nhiêu?**

Duyệt qua [bộ sưu tập slide](https://reference.aspose.com/slides/vi/net/aspose.slides/slidecollection/) và kiểm tra [cờ hiển thị](https://reference.aspose.com/slides/vi/net/aspose.slides/slide/hidden/) của mỗi slide.

**Tôi có thể phát hiện xem có sử dụng kích thước và hướng slide tùy chỉnh hay không, và chúng có khác với mặc định không?**

Có. So sánh [kích thước slide](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/slidesize/) và hướng hiện tại với các cài đặt chuẩn; điều này giúp dự đoán hành vi khi in và xuất.

**Có cách nhanh để kiểm tra xem biểu đồ có tham chiếu nguồn dữ liệu bên ngoài không?**

Có. Duyệt qua tất cả [biểu đồ](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/chart/), kiểm tra [nguồn dữ liệu](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/chartdata/datasourcetype/) của chúng, và ghi lại liệu dữ liệu là nội bộ hay dựa trên liên kết, bao gồm cả các liên kết bị hỏng.

**Làm sao tôi có thể đánh giá các slide 'nặng' có thể làm chậm quá trình render hoặc xuất PDF?**

Đối với mỗi slide, đếm số lượng đối tượng và tìm các hình ảnh lớn, độ trong suốt, bóng, hoạt ảnh và đa phương tiện; gán một mức độ phức tạp tương đối để đánh dấu các điểm nóng về hiệu suất tiềm năng.