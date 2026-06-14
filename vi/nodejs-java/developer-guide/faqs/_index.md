---
title: Câu hỏi thường gặp
type: docs
weight: 340
url: /vi/nodejs-java/faqs/
keywords:
- Câu hỏi thường gặp
- định dạng bài thuyết trình
- lỗi hết bộ nhớ
- kích thước slide
- trích xuất văn bản
- lấy văn bản
- kích thước đoạn văn
- định dạng bảng
- phông chữ
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Nhận câu trả lời cho các câu hỏi thường gặp về Aspose.Slides cho Node.js qua Java, bao gồm hỗ trợ PowerPoint và OpenDocument, hướng dẫn cài đặt, cấp phép, khắc phục sự cố."
---
## **Tổng quan**

Bài Hỏi Đáp này cung cấp câu trả lời cho các câu hỏi thường gặp về Aspose.Slides. Nó bao phủ các định dạng tệp được hỗ trợ, cách xử lý ngoại lệ khi làm việc với các bản trình chiếu lớn, thay đổi kích thước slide, xem trước slide, trích xuất văn bản từ bản trình chiếu, định dạng viền bảng, chèn hình ảnh và giải quyết các vấn đề liên quan đến phông chữ khi chuyển đổi bản trình chiếu sang PDF hoặc hình ảnh.

## **Định dạng tệp được hỗ trợ**

**Q: Định dạng tệp nào mà Aspose.Slides for Node.js via Java hỗ trợ?**

**A**: Aspose.Slides for Node.js via Java hỗ trợ các định dạng tệp được mô tả trong [Supported File Formats](/slides/vi/nodejs-java/supported-file-formats/).

## **Ngoại lệ**

**Q: Tôi gặp lỗi hết bộ nhớ khi tải một tệp PPT lớn có hình ảnh. Có giới hạn nào về kích thước tệp trong Aspose.Slides không?**

**A**: Không có công thức cụ thể nào để tính kích thước bản trình chiếu mà Aspose.Slides hỗ trợ. Cần đủ không gian để chứa toàn bộ cấu trúc bản trình chiếu và hình ảnh trong bộ nhớ. Thông thường, hình ảnh trong bộ nhớ chiếm nhiều không gian hơn so với ổ đĩa cứng, đặc biệt khi hình ảnh có các hiệu ứng bổ sung.

Nói chung, Aspose.Slides for Node.js via Java có thể xử lý dễ dàng các tệp bản trình chiếu có dung lượng khoảng 300 MB trên máy chủ có 4 GB RAM.

## **Làm việc với các slide**

**Q: Tôi có thể thay đổi kích thước của các slide trong một bản trình chiếu không?**

**A**: Bạn có thể sử dụng phương thức `getSlideSize` được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) để xác định kích thước của các slide trong một bản trình chiếu.

**Q: Có cách nào để xác định các slide có kích thước khác nhau trong một bản trình chiếu không?**

**A**: Vì kích thước của các slide được xác định ở mức bản trình chiếu trong tài liệu Microsoft PowerPoint, nên không có cách nào để thực hiện điều này.

**Q: Aspose.Slides cho Node.js via Java có hỗ trợ xem trước một slide trước khi lưu không?**

**A**: Bạn có thể render các slide của bản trình chiếu thành hình ảnh và sử dụng những hình ảnh này để xem trước các slide.

## **Làm việc với văn bản**

**Q: Có thể truy xuất toàn bộ văn bản từ một bản trình chiếu không?**

**A**: Aspose.Slides cho Node.js via Java cung cấp lớp [SlideUtil](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideutil/) với các phương thức khác nhau để truy xuất toàn bộ văn bản từ các bản trình chiếu.

**Q: Tại sao kích thước đoạn văn khác nhau trên hệ điều hành Windows và Linux?**

**A**: Việc tính toán kích thước đoạn văn dựa trên việc tính toán kích thước văn bản đại diện cho đoạn văn đó. Kích thước văn bản được tính dựa trên các chỉ số của phông chữ được chỉ định trong bản trình chiếu PowerPoint. Nếu phông chữ được chỉ định không có sẵn, nó sẽ được thay thế bằng phông chữ tương tự nhất, nhưng phông chữ này có các chỉ số khác với phông chữ gốc. Do đó, việc tính toán kích thước đoạn văn trên các hệ thống khác nhau sẽ cho ra kết quả khác nhau tùy thuộc vào tập hợp các phông chữ được cài đặt. Để đạt được kết quả giống nhau trên các hệ điều hành khác nhau, bạn cần cài đặt cùng một bộ phông chữ trên các hệ thống hoặc tải chúng trong thời gian chạy như [external fonts](/slides/vi/nodejs-java/custom-font/).

## **Định dạng và hình ảnh**

**Q: Làm thế nào để đặt màu cho viền bảng?**

**A**: Bạn có thể thay đổi màu của tất cả các viền bảng hoặc chỉ viền bao quanh toàn bộ bảng. Để thay đổi tất cả các viền, vui lòng sử dụng phương thức `getCellFormat` từ lớp [Cell](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/cell/). Đối với viền của toàn bộ bảng, bạn nên duyệt các ô và thay đổi màu của các viền ngoài.

**Q: Aspose.Slides cho Node.js via Java sử dụng đơn vị đo nào để đặt hình ảnh?**

**A**: Các tọa độ và kích thước của tất cả các hình dạng trên slide được đo bằng điểm (72 dpi).

## **Làm việc với phông chữ**

**Q: Khi chuyển đổi PPT sang PDF hoặc hình ảnh, tại sao phông chữ trong tài liệu đầu ra lại khác?**

**A**: Vấn đề này có thể cho thấy các phông chữ được sử dụng trong bản trình chiếu thiếu trên hệ điều hành mà mã được thực thi. Bạn nên cài đặt các phông chữ trên hệ điều hành hoặc tải chúng như các phông chữ bên ngoài bằng cách sử dụng lớp [FontsLoader](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/fontsloader/) như dưới đây:
```javascript
var folders = java.newArray("java.lang.String", ["path_to_a_folder_with_fonts"]));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", folders);
```