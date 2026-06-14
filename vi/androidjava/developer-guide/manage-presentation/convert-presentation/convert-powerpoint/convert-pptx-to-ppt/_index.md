---
title: Chuyển đổi PPTX sang PPT trên Android
linktitle: PPTX sang PPT
type: docs
weight: 21
url: /vi/androidjava/convert-pptx-to-ppt/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- chuyển đổi slide
- chuyển đổi PPTX
- PPTX sang PPT
- lưu PPTX dưới dạng PPT
- xuất PPTX thành PPT
- PowerPoint
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Dễ dàng chuyển đổi PPTX sang PPT với Aspose.Slides cho Android bằng Java—đảm bảo tương thích liền mạch với các định dạng PowerPoint đồng thời giữ nguyên bố cục và chất lượng của bài thuyết trình."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi bản trình bày PowerPoint ở định dạng PPTX sang định dạng PPT bằng Java. Các chủ đề sau được đề cập.

- Chuyển đổi PPTX sang PPT trong Java

## **Chuyển đổi PPTX sang PPT trên Android**

Đối với mã mẫu Java để chuyển đổi PPTX sang PPT, vui lòng xem phần dưới đây, tức là [Chuyển đổi PPTX sang PPT](#convert-pptx-to-ppt). Nó chỉ tải tệp PPTX và lưu dưới định dạng PPT. Bằng cách chỉ định các định dạng lưu khác nhau, bạn cũng có thể lưu tệp PPTX thành nhiều định dạng khác như PDF, XPS, ODP, HTML, v.v. như đã thảo luận trong các bài viết này. 

- [Chuyển đổi PPTX sang PDF trên Android](/slides/vi/androidjava/convert-powerpoint-to-pdf/)
- [Chuyển đổi PPTX sang XPS trên Android](/slides/vi/androidjava/convert-powerpoint-to-xps/)
- [Chuyển đổi PPTX sang HTML trên Android](/slides/vi/androidjava/convert-powerpoint-to-html/)
- [Chuyển đổi PPTX sang ODP trên Android](/slides/vi/androidjava/save-presentation/)
- [Chuyển đổi PPTX sang PNG trên Android](/slides/vi/androidjava/convert-powerpoint-to-png/)

## **Chuyển đổi PPTX sang PPT**
Để chuyển đổi PPTX sang PPT, chỉ cần truyền tên tệp và định dạng lưu vào phương thức **Save** của lớp [**Presentation**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation) class. Mẫu mã Java bên dưới chuyển đổi một Presentation từ PPTX sang PPT sử dụng các tùy chọn mặc định.

```java
// khởi tạo một đối tượng Presentation đại diện cho tệp PPTX
Presentation presentation = new Presentation("template.pptx");

// lưu bài thuyết trình dưới dạng PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```

## **Câu hỏi thường gặp**

**Tất cả các hiệu ứng và tính năng của PPTX có được giữ lại khi lưu sang định dạng PPT (97–2003) cũ không?**

Không phải lúc nào cũng vậy. Định dạng PPT thiếu một số khả năng mới hơn (ví dụ: một số hiệu ứng, đối tượng và hành vi), do đó các tính năng có thể bị đơn giản hoá hoặc raster hoá trong quá trình chuyển đổi.

**Tôi có thể chỉ chuyển đổi các slide đã chọn sang PPT thay vì toàn bộ bản trình bày không?**

Việc lưu trực tiếp nhắm tới toàn bộ bản trình bày. Để chuyển đổi các slide cụ thể, tạo một bản trình bày mới chỉ chứa các slide đó và lưu nó dưới dạng PPT; hoặc sử dụng dịch vụ/API hỗ trợ các tham số chuyển đổi theo slide.

**Các bản trình bày được bảo vệ bằng mật khẩu có được hỗ trợ không?**

Có. Bạn có thể phát hiện xem tệp có được bảo vệ hay không, mở nó bằng mật khẩu, và cũng có thể [cấu hình cài đặt bảo vệ/mã hóa](/slides/vi/androidjava/password-protected-presentation/) cho PPT đã lưu.