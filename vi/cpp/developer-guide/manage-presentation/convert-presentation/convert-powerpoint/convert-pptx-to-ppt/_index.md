---
title: Chuyển đổi PPTX sang PPT bằng C++
linktitle: PPTX sang PPT
type: docs
weight: 21
url: /vi/cpp/convert-pptx-to-ppt/
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
- C++
- Aspose.Slides
description: "Dễ dàng chuyển đổi PPTX sang PPT với Aspose.Slides cho C++ — đảm bảo tương thích mượt mà với các định dạng PowerPoint đồng thời giữ nguyên bố cục và chất lượng của bài thuyết trình."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi PowerPoint Presentation ở định dạng PPTX sang định dạng PPT bằng C++. Các chủ đề sau được đề cập.

- Chuyển đổi PPTX sang PPT bằng C++

## **Chuyển đổi PPTX sang PPT bằng C++**

Đối với mã mẫu C++ để chuyển đổi PPTX sang PPT, vui lòng xem mục bên dưới, tức là [Chuyển đổi PPTX sang PPT](#convert-pptx-to-ppt). Nó chỉ tải tệp PPTX và lưu dưới định dạng PPT. Bằng cách chỉ định các định dạng lưu khác nhau, bạn cũng có thể lưu tệp PPTX thành nhiều định dạng khác như PDF, XPS, ODP, HTML, v.v. như đã thảo luận trong các bài viết này. 

- [Chuyển đổi PPTX sang PDF bằng C++](/slides/vi/cpp/convert-powerpoint-to-pdf/)
- [Chuyển đổi PPTX sang XPS bằng C++](/slides/vi/cpp/convert-powerpoint-to-xps/)
- [Chuyển đổi PPTX sang HTML bằng C++](/slides/vi/cpp/convert-powerpoint-to-html/)
- [Chuyển đổi PPTX sang ODP bằng C++](/slides/vi/cpp/save-presentation/)
- [Chuyển đổi PPTX sang PNG bằng C++](/slides/vi/cpp/convert-powerpoint-to-png/)

## **Chuyển đổi PPTX sang PPT**
Để chuyển đổi PPTX sang PPT, chỉ cần truyền tên tệp và định dạng lưu vào phương thức **Save** của lớp [**Presentation**](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation/) . Mẫu mã C++ phía dưới chuyển đổi một Presentation từ PPTX sang PPT bằng các tùy chọn mặc định.

```cpp
// Tải PPTX.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// Lưu dưới định dạng PPT.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```

## **Câu hỏi thường gặp**

**Tất cả hiệu ứng và tính năng của PPTX có được giữ lại khi lưu sang định dạng PPT (97–2003) cũ không?**

Không phải luôn luôn. Định dạng PPT thiếu một số khả năng mới hơn (ví dụ, một số hiệu ứng, đối tượng và hành vi), vì vậy các tính năng có thể bị đơn giản hoá hoặc raster hoá trong quá trình chuyển đổi.

**Tôi có thể chuyển đổi chỉ các slide đã chọn sang PPT thay vì toàn bộ bài thuyết trình không?**

Việc lưu trực tiếp chỉ áp dụng cho toàn bộ bài thuyết trình. Để chuyển đổi các slide cụ thể, tạo một bài thuyết trình mới chỉ chứa các slide đó và lưu nó dưới dạng PPT; hoặc sử dụng dịch vụ/API hỗ trợ các tham số chuyển đổi theo slide.

**Các bài thuyết trình có bảo vệ bằng mật khẩu có được hỗ trợ không?**

Có. Bạn có thể phát hiện xem tệp có được bảo vệ hay không, mở nó bằng mật khẩu, và cũng có thể [cấu hình cài đặt bảo vệ/mã hoá](/slides/vi/cpp/password-protected-presentation/) cho PPT đã lưu.