---
title: Chuyển đổi ODP sang PPTX trong .NET
linktitle: ODP sang PPTX
type: docs
weight: 10
url: /vi/net/convert-odp-to-pptx/
keywords:
- chuyển đổi OpenDocument
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi ODP
- OpenDocument sang PPTX
- ODP sang PPTX
- lưu ODP dưới dạng PPTX
- xuất ODP sang PPTX
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Chuyển đổi ODP sang PPTX với Aspose.Slides cho .NET. Ví dụ mã C# sạch sẽ, mẹo xử lý hàng loạt và kết quả chất lượng cao—không cần PowerPoint."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi bản trình chiếu ODP sang định dạng PPTX bằng Aspose.Slides.

## **Chuyển đổi ODP sang PPTX**

Aspose.Slides cho .NET cung cấp lớp **Presentation** đại diện cho một tệp bản trình chiếu. [**Presentation**](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) lớp này hiện cũng có thể truy cập ODP thông qua trình khởi tạo Presentation khi đối tượng được khởi tạo. Ví dụ sau đây cho thấy cách chuyển đổi một bản trình chiếu ODP sang bản trình chiếu PPTX.

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>Các bước: Chuyển đổi ODP sang PPTX trong C#</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>Các bước: Chuyển đổi ODP sang PowerPoint trong C#</strong></a>

```c#
 // Mở tệp ODP
 Presentation pres = new Presentation("AccessOpenDoc.odp");

// Lưu bản trình chiếu ODP sang định dạng PPTX
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```

## **Ví dụ trực tiếp**

Bạn có thể truy cập ứng dụng web [**Aspose.Slides Conversion**](https://products.aspose.app/slides/vi/conversion/) được xây dựng bằng **Aspose.Slides API.** Ứng dụng này minh họa cách thực hiện chuyển đổi ODP sang PPTX bằng Aspose.Slides API.

## **Câu hỏi thường gặp**

**Tôi có cần cài đặt Microsoft PowerPoint hoặc LibreOffice để chuyển đổi ODP sang PPTX không?**

Không. Aspose.Slides hoạt động độc lập và không yêu cầu các ứng dụng của bên thứ ba để đọc hoặc ghi ODP/PPTX.

**Các slide master, bố cục và chủ đề có được giữ nguyên trong quá trình chuyển đổi không?**

Có. Thư viện sử dụng mô hình đối tượng bản trình chiếu đầy đủ và giữ nguyên cấu trúc, bao gồm các slide master và bố cục, do đó thiết kế vẫn đúng sau khi chuyển đổi.

**Tôi có thể chuyển đổi các tệp ODP được bảo vệ bằng mật khẩu không?**

Có. Aspose.Slides hỗ trợ phát hiện bảo vệ, mở và làm việc với [protected presentations](/slides/vi/net/password-protected-presentation/) (bao gồm ODP) khi bạn cung cấp mật khẩu, cũng như cấu hình mã hóa và truy cập vào các thuộc tính tài liệu.

**Aspose.Slides có phù hợp cho các dịch vụ chuyển đổi dựa trên đám mây hoặc REST không?**

Có. Bạn có thể sử dụng thư viện cục bộ trong backend của mình hoặc [Aspose.Slides Cloud](https://products.aspose.cloud/slides/vi/family/) (REST API); cả hai tùy chọn đều hỗ trợ chuyển đổi ODP → PPTX.