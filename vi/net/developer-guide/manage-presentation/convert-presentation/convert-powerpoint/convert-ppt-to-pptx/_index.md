---
title: Chuyển đổi PPT sang PPTX trong .NET
linktitle: PPT sang PPTX
type: docs
weight: 20
url: /vi/net/convert-ppt-to-pptx/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- chuyển đổi slide
- chuyển đổi PPT
- PPT sang PPTX
- lưu PPT dưới dạng PPTX
- xuất PPT sang PPTX
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Chuyển đổi các tệp PPT cổ điển sang PPTX trong .NET với Aspose.Slides. Bao gồm các ví dụ C# cho việc chuyển đổi tệp đơn và hàng loạt, xử lý lỗi và ghi chú về độ trung thực."
---
## **Tổng quan**

PPT là định dạng PowerPoint nhị phân cũ, trong khi PPTX là định dạng Open XML mới hơn. Aspose.Slides cho .NET có thể tải tệp PPT và lưu nó dưới dạng PPTX mà không cần Microsoft PowerPoint. Bài viết này trình bày cách chuyển đổi một tệp hoặc một thư mục các tệp và giải thích những gì cần kiểm tra sau khi chuyển đổi.

## **Chuyển đổi tệp PPT sang PPTX**

Tải tệp nguồn bằng lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) , sau đó gọi [IPresentation.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentation/save/) với [SaveFormat.Pptx](https://reference.aspose.com/slides/vi/net/aspose.slides.export/saveformat/). Câu lệnh `using` sẽ giải phóng đối tượng presentation và giải phóng tài nguyên của nó khi phạm vi kết thúc.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

// Tải bản trình chiếu PPT kế thừa.
using var presentation = new Presentation("presentation.ppt");

// Lưu bản trình chiếu dưới dạng PPTX.
presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

Phần mở rộng tệp không tự động chọn định dạng đầu ra; đối số [SaveFormat.Pptx](https://reference.aspose.com/slides/vi/net/aspose.slides.export/saveformat/) làm điều đó. Giữ các đường dẫn đầu vào và đầu ra khác nhau nếu bạn cần giữ lại tệp PPT gốc.

## **Chuyển đổi nhiều tệp PPT**

Ví dụ sau chuyển đổi mọi tệp `.ppt` trong một thư mục. Mỗi tệp được xử lý độc lập, vì vậy một lần chuyển đổi thất bại sẽ không làm dừng phần còn lại của lô.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var inputDirectory = "input";
var outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory, "*.ppt", SearchOption.TopDirectoryOnly))
{
    var outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pptx";
    var outputPath = Path.Combine(outputDirectory, outputFileName);

    try
    {
        using var presentation = new Presentation(inputPath);
        presentation.Save(outputPath, SaveFormat.Pptx);
        Console.WriteLine($"Converted: {inputPath}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Failed: {inputPath} ({exception.Message})");
    }
}
```

Đối với môi trường sản xuất, ghi lại đầy đủ ngoại lệ, quyết định có cho phép ghi đè tệp đầu ra hiện có hay không, và ghi tên các tệp thất bại vào hàng đợi thử lại hoặc xem xét. Các tệp hỏng, tệp được bảo vệ bằng mật khẩu mà mở mà không có mật khẩu yêu cầu, các đường dẫn không thể truy cập và nội dung không được hỗ trợ đều có thể gây lỗi chuyển đổi. Xem [Password-Protected Presentations](/slides/vi/net/password-protected-presentation/) để tải các tệp được mã hóa.

## **Độ trung thực và các tính năng kế thừa**

Quá trình chuyển đổi thường giữ nguyên các slide, master, layout, văn bản, hình dạng, hình ảnh, bảng và biểu đồ. Tuy nhiên, PPT và PPTX không đại diện cho mọi tính năng theo cùng một cách. Một tính năng kế thừa không có tương đương PPTX, hoặc không được thư viện hỗ trợ, có thể được chuẩn hoá, bỏ qua hoặc hiển thị khác đi.

Kiểm tra tệp đã chuyển đổi khi nó chứa hoạt ảnh, chuyển cảnh, các đối tượng OLE nhúng hoặc liên kết, điều khiển ActiveX, phương tiện nhúng, phông chữ không phổ biến, hoặc macro VBA. Tệp PPTX thuần không phải là định dạng hỗ trợ macro, vì vậy hãy sử dụng quy trình làm việc hỗ trợ macro thích hợp khi VBA cần được giữ lại. Đồng thời xác nhận rằng các phông chữ cần thiết và tài nguyên bên ngoài có sẵn trong môi trường mà bản trình chiếu đã chuyển đổi sẽ được mở hoặc hiển thị.

Đối với các tài liệu quan trọng, hãy mở lại PPTX đã tạo bằng mã và kiểm tra số lượng slide quan trọng và nội dung, sau đó so sánh giao diện và hành vi trình chiếu trong trình xem dự định. Đừng coi cuộc gọi thành công [IPresentation.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentation/save/) như là bằng chứng rằng mọi tính năng kế thừa đều có đại diện PPTX chính xác.

## **Khi nào nên sử dụng PPTX**

Sử dụng PPTX khi bản trình chiếu sẽ được chỉnh sửa trong các phiên bản PowerPoint hiện tại, trao đổi với các hệ thống làm việc với gói Open XML, hoặc lưu trữ dưới định dạng dễ kiểm tra và khôi phục hơn so với PPT nhị phân cũ. Giữ nguyên tệp PPT gốc như bản lưu trữ hoặc bản sao dự phòng cho đến khi bản trình chiếu đã chuyển đổi vượt qua các kiểm tra độ trung thực của bạn.

Nếu bạn cần PDF, HTML, hình ảnh, XPS hoặc loại đầu ra khác, hãy sử dụng hướng dẫn theo định dạng trong [Convert Presentations to Multiple Formats](/slides/vi/net/convert-presentation/) thay vì giả định rằng mọi mục tiêu đều giữ lại các tính năng PowerPoint có thể chỉnh sửa.

## **Trình chuyển đổi trực tuyến**

Đối với tệp thỉnh thoảng hoặc so sánh nhanh, bạn có thể sử dụng [online PPT to PPTX converter](https://products.aspose.app/slides/vi/conversion/ppt-to-pptx). Đối với các chuyển đổi lặp lại, xử lý hàng loạt hoặc xử lý lỗi ở mức ứng dụng, hãy sử dụng .NET API.

## **Bài viết liên quan**

- [PPT vs PPTX](/slides/vi/net/ppt-vs-pptx/)
- [Lưu trình chiếu trong .NET](/slides/vi/net/save-presentation/)
- [Các định dạng tệp được hỗ trợ](/slides/vi/net/supported-file-formats/)
- [Mở trình chiếu trong .NET](/slides/vi/net/open-presentation/)

## **Câu hỏi thường gặp**

**Tôi có thể chuyển đổi PPT sang PPTX mà không cần cài đặt Microsoft PowerPoint không?**

Có. Aspose.Slides cho .NET tải và lưu các tệp trình chiếu mà không cần Microsoft PowerPoint.

**Quá trình chuyển đổi PPT sang PPTX có giữ nguyên toàn bộ nội dung một cách chính xác không?**

Nó giữ lại nội dung trình chiếu phổ biến, nhưng độ trung thực chính xác không được đảm bảo cho mọi tính năng kế thừa hoặc không được hỗ trợ. Hãy kiểm tra tệp đã tạo khi nó chứa macro, đối tượng OLE hoặc ActiveX, phương tiện, hoạt ảnh chuyên dụng hoặc phông chữ không phổ biến.

**Tôi có thể chuyển đổi tệp PPT được bảo vệ bằng mật khẩu không?**

Có, nếu bạn cung cấp đúng mật khẩu khi tải tệp. Thiếu mật khẩu hoặc mật khẩu không đúng sẽ khiến quá trình tải thất bại.

**Tôi có nên xóa tệp PPT sau khi chuyển đổi không?**

Giữ nguyên tệp gốc cho đến khi bạn đã xác minh PPTX trong các trình xem và quy trình làm việc quan trọng đối với bạn. Điều này cung cấp một bản sao dự phòng nếu một tính năng kế thừa được chuyển đổi khác nhau.