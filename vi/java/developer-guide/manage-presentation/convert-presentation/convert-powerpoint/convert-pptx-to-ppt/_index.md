---
title: Chuyển đổi PPTX sang PPT trong Java
linktitle: PPTX sang PPT
type: docs
weight: 21
url: /vi/java/convert-pptx-to-ppt/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi PPTX
- PPTX sang PPT
- lưu PPTX dưới dạng PPT
- xuất PPTX sang PPT
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: Dễ dàng chuyển đổi PPTX sang PPT với Aspose.Slides cho Java - đảm bảo tính tương thích liền mạch với định dạng PowerPoint đồng thời giữ nguyên bố cục và chất lượng của bản trình chiếu.
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi bản trình chiếu PowerPoint ở định dạng PPTX sang định dạng PPT bằng Java. Các chủ đề sau được đề cập.

- Chuyển đổi PPTX sang PPT trong Java

## **Chuyển đổi PPTX sang PPT trong Java**

Đối với mã mẫu Java để chuyển đổi PPTX sang PPT, vui lòng xem phần dưới đây, tức là [Convert PPTX to PPT](#convert-pptx-to-ppt). Nó chỉ tải tệp PPTX và lưu dưới định dạng PPT. Bằng cách chỉ định các định dạng lưu khác nhau, bạn cũng có thể lưu tệp PPTX thành nhiều định dạng khác như PDF, XPS, ODP, HTML, v.v. như được thảo luận trong các bài viết này. 

- [Chuyển đổi PPTX sang PDF trong Java](/slides/vi/java/convert-powerpoint-to-pdf/)
- [Chuyển đổi PPTX sang XPS trong Java](/slides/vi/java/convert-powerpoint-to-xps/)
- [Chuyển đổi PPTX sang HTML trong Java](/slides/vi/java/convert-powerpoint-to-html/)
- [Chuyển đổi PPTX sang ODP trong Java](/slides/vi/java/save-presentation/)
- [Chuyển đổi PPTX sang PNG trong Java](/slides/vi/java/convert-powerpoint-to-png/)

## **Chuyển đổi PPTX sang PPT**
Để chuyển đổi PPTX sang PPT, chỉ cần truyền tên tệp và định dạng lưu vào phương thức **Save** của lớp [**Presentation**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation). Mẫu mã Java bên dưới chuyển đổi một Presentation từ PPTX sang PPT bằng các tùy chọn mặc định.

```java
// khởi tạo một đối tượng Presentation đại diện cho tệp PPTX
Presentation presentation = new Presentation("template.pptx");

// lưu bản trình chiếu dưới dạng PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```

## **Câu hỏi thường gặp**

**Tất cả các hiệu ứng và tính năng của PPTX có được giữ lại khi lưu sang định dạng PPT (97–2003) không?**

Không phải luôn luôn. Định dạng PPT thiếu một số khả năng mới hơn (ví dụ: một số hiệu ứng, đối tượng và hành vi), vì vậy các tính năng có thể bị đơn giản hoá hoặc raster hóa trong quá trình chuyển đổi.

**Tôi có thể chuyển đổi chỉ các slide được chọn sang PPT thay vì toàn bộ bản trình chiếu không?**

Phương thức lưu trực tiếp áp dụng cho toàn bộ bản trình chiếu. Để chuyển đổi các slide cụ thể, bạn cần tạo một bản trình chiếu mới chỉ chứa các slide đó và lưu nó dưới dạng PPT; hoặc sử dụng dịch vụ/API cho phép thiết lập tham số chuyển đổi theo từng slide.

**Các bản trình chiếu được bảo mật bằng mật khẩu có được hỗ trợ không?**

Có. Bạn có thể kiểm tra xem tệp có được bảo vệ không, mở nó bằng mật khẩu, và cũng có thể [configure protection/encryption settings](/slides/vi/java/password-protected-presentation/) cho PPT đã lưu.