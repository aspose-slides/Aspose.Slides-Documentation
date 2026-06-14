---
title: Chuyển đổi PPTX sang PPT trong JavaScript
linktitle: PPTX sang PPT
type: docs
weight: 21
url: /vi/nodejs-java/convert-pptx-to-ppt/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Dễ dàng chuyển đổi PPTX sang PPT với Aspose.Slides—đảm bảo tương thích liền mạch với các định dạng PowerPoint trong khi giữ nguyên bố cục và chất lượng của bản trình chiếu."
---
## **Tổng quan**

Bài viết này giải thích cách chuyển đổi bản trình chiếu PowerPoint ở định dạng PPTX sang định dạng PPT bằng JavaScript. Các chủ đề sau được đề cập.

- Chuyển đổi PPTX sang PPT trong JavaScript

## **Java Chuyển đổi PPTX sang PPT**

Đối với mã mẫu JavaScript để chuyển đổi PPTX sang PPT, vui lòng xem phần dưới đây tức là [Convert PPTX to PPT](#convert-pptx-to-ppt). Nó chỉ tải tệp PPTX và lưu dưới định dạng PPT. Bằng cách chỉ định các định dạng lưu khác nhau, bạn cũng có thể lưu tệp PPTX thành nhiều định dạng khác như PDF, XPS, ODP, HTML, v.v. như đã thảo luận trong các bài viết này. 

- [Chuyển đổi PPTX sang PDF trong JavaScript](/slides/vi/nodejs-java/convert-powerpoint-to-pdf/)
- [Chuyển đổi PPTX sang XPS trong JavaScript](/slides/vi/nodejs-java/convert-powerpoint-to-xps/)
- [Chuyển đổi PPTX sang HTML trong JavaScript](/slides/vi/nodejs-java/convert-powerpoint-to-html/)
- [Chuyển đổi PPTX sang ODP trong JavaScript](/slides/vi/nodejs-java/save-presentation/)
- [Chuyển đổi PPTX sang PNG trong JavaScript](/slides/vi/nodejs-java/convert-powerpoint-to-png/)

## **Chuyển đổi PPTX sang PPT**

Để chuyển đổi PPTX sang PPT, chỉ cần truyền tên tệp và định dạng lưu vào phương thức **Save** của lớp [**Presentation**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation). Mẫu mã JavaScript bên dưới chuyển đổi một Presentation từ PPTX sang PPT bằng các tùy chọn mặc định.

```javascript
// khởi tạo một đối tượng Presentation đại diện cho tệp PPTX
var presentation = new aspose.slides.Presentation("template.pptx");
// save the presentation as PPT
presentation.save("output.ppt", aspose.slides.SaveFormat.Ppt);
```

## **Câu hỏi thường gặp**

**Tất cả các hiệu ứng và tính năng của PPTX có được giữ lại khi lưu sang định dạng PPT (97–2003) không?**

Không phải lúc nào cũng như vậy. Định dạng PPT thiếu một số khả năng mới hơn (ví dụ: một số hiệu ứng, đối tượng và hành vi), do đó các tính năng có thể bị đơn giản hoá hoặc raster hoá trong quá trình chuyển đổi.

**Tôi có thể chuyển đổi chỉ những slide đã chọn sang PPT thay vì toàn bộ bản trình chiếu không?**

Việc lưu trực tiếp sẽ áp dụng cho toàn bộ bản trình chiếu. Để chuyển đổi các slide cụ thể, hãy tạo một bản trình chiếu mới chỉ chứa những slide đó và lưu nó dưới dạng PPT; hoặc sử dụng dịch vụ/API hỗ trợ các tham số chuyển đổi theo slide.

**Các bản trình chiếu được bảo vệ bằng mật khẩu có được hỗ trợ không?**

Có. Bạn có thể phát hiện xem tệp có được bảo vệ hay không, mở nó bằng mật khẩu, và cũng có thể [cấu hình các cài đặt bảo vệ/mã hoá](/slides/vi/nodejs-java/password-protected-presentation/) cho PPT đã lưu.