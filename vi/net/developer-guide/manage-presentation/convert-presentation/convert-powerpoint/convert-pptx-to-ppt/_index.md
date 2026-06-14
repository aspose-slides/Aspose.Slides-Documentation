---
title: Chuyển đổi PPTX sang PPT trong .NET
linktitle: PPTX sang PPT
type: docs
weight: 21
url: /vi/net/convert-pptx-to-ppt/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- chuyển đổi slide
- chuyển đổi PPTX
- PPTX sang PPT
- lưu PPTX dưới dạng PPT
- xuất PPTX sang PPT
- PowerPoint
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Dễ dàng chuyển đổi PPTX sang PPT với Aspose.Slides cho .NET—đảm bảo khả năng tương thích liền mạch với các định dạng PowerPoint đồng thời giữ nguyên bố cục và chất lượng của bài thuyết trình."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi PowerPoint Presentation ở định dạng PPTX sang định dạng PPT bằng C#. Các chủ đề sau được đề cập.

- Chuyển đổi PPTX sang PPT trong C#

## **Chuyển đổi PPTX sang PPT trong .NET**

Đối với mã mẫu C# để chuyển đổi PPTX sang PPT, vui lòng xem phần dưới đây tức là [Convert PPTX to PPT](#convert-pptx-to-ppt). Nó chỉ tải tệp PPTX và lưu dưới định dạng PPT. Bằng cách chỉ định các định dạng lưu khác nhau, bạn cũng có thể lưu tệp PPTX sang nhiều định dạng khác như PDF, XPS, ODP, HTML, v.v. như đã thảo luận trong các bài viết này. 

- [Convert PPTX to PDF in .NET](/slides/vi/net/convert-powerpoint-to-pdf/)
- [Convert PPTX to XPS in .NET](/slides/vi/net/convert-powerpoint-to-xps/)
- [Convert PPTX to HTML in .NET](/slides/vi/net/convert-powerpoint-to-html/)
- [Convert PPTX to ODP in .NET](/slides/vi/net/save-presentation/)
- [Convert PPTX to PNG in .NET](/slides/vi/net/convert-powerpoint-to-png/)

## **Chuyển đổi PPTX sang PPT**
Để chuyển đổi PPTX sang PPT, chỉ cần truyền tên tệp và định dạng lưu vào phương thức [**Save**](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/save/) của lớp [**Presentation**](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/). Mẫu mã C# dưới đây chuyển đổi một Presentation từ PPTX sang PPT bằng các tùy chọn mặc định.

```c#
// Tạo một đối tượng Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation("presentation.pptx");

// Lưu bản trình chiếu PPTX sang định dạng PPT
pres.Save("presentation.ppt", SaveFormat.Ppt);
```

## **Câu hỏi thường gặp**

**Tất cả các hiệu ứng và tính năng của PPTX có được giữ lại khi lưu dưới định dạng PPT (97–2003) cũ không?**

Không phải lúc nào cũng vậy. Định dạng PPT thiếu một số khả năng mới hơn (ví dụ: một số hiệu ứng, đối tượng và hành vi), vì vậy các tính năng có thể bị đơn giản hóa hoặc raster hoá trong quá trình chuyển đổi.

**Tôi có thể chuyển đổi chỉ các slide được chọn sang PPT thay vì toàn bộ bài thuyết trình không?**

Việc lưu trực tiếp sẽ áp dụng cho toàn bộ bài thuyết trình. Để chuyển đổi các slide cụ thể, tạo một bài thuyết trình mới chỉ chứa những slide đó và lưu dưới dạng PPT; hoặc sử dụng dịch vụ/API hỗ trợ các tham số chuyển đổi theo slide.

**Các bài thuyết trình được bảo mật bằng mật khẩu có được hỗ trợ không?**

Có. Bạn có thể phát hiện xem tệp có được bảo vệ hay không, mở nó bằng mật khẩu, và cũng có thể [cấu hình các cài đặt bảo vệ/mã hóa](/slides/vi/net/password-protected-presentation/) cho PPT đã lưu.