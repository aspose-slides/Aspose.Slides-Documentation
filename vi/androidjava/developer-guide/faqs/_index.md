---
title: Câu hỏi thường gặp
type: docs
weight: 340
url: /vi/androidjava/faqs/
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
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Nhận câu trả lời cho các câu hỏi thường gặp về Aspose.Slides cho Android qua Java, bao gồm hỗ trợ PowerPoint và OpenDocument, hướng dẫn cài đặt, giấy phép, khắc phục sự cố."
---
## **Tổng quan**

Câu hỏi thường gặp này cung cấp câu trả lời cho các câu hỏi phổ biến về Aspose.Slides. Nó bao gồm các định dạng tệp được hỗ trợ, xử lý ngoại lệ khi làm việc với bài thuyết trình lớn, thay đổi kích thước slide, xem trước slide, trích xuất văn bản từ bài thuyết trình, định dạng viền bảng, chèn hình ảnh và giải quyết các vấn đề liên quan đến phông chữ khi chuyển đổi bài thuyết trình sang PDF hoặc hình ảnh.

## **Định dạng tệp được hỗ trợ**

**Q: Aspose.Slides for Android via Java hỗ trợ những định dạng tệp nào?**

**A**: Aspose.Slides for Android via Java hỗ trợ các định dạng tệp được mô tả trong [Định dạng tệp được hỗ trợ](/slides/vi/androidjava/supported-file-formats/).

## **Ngoại lệ**

**Q: Tôi gặp lỗi out of memory khi tải tệp PPT lớn có hình ảnh. Có giới hạn nào về kích thước tệp trong Aspose.Slides không?**

**A**: Không có công thức cụ thể nào để tính kích thước bài thuyết trình mà Aspose.Slides hỗ trợ. Cần có đủ không gian để chứa toàn bộ cấu trúc bài thuyết trình và hình ảnh trong bộ nhớ. Thông thường, hình ảnh trong bộ nhớ chiếm nhiều không gian hơn so với ổ cứng, đặc biệt khi hình ảnh có hiệu ứng bổ sung.

Nhìn chung, Aspose.Slides for Android via Java có thể xử lý dễ dàng các tệp bài thuyết trình khoảng 300 MB trên server có 4 GB RAM.

## **Làm việc với slide**

**Q: Tôi có thể thay đổi kích thước slide trong một bài thuyết trình không?**

**A**: Bạn có thể sử dụng phương thức `getSlideSize` được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) để xác định kích thước của các slide trong một bài thuyết trình.

**Q: Có cách nào định nghĩa các slide có kích thước khác nhau trong một bài thuyết trình không?**

**A**: Vì kích thước slide được định nghĩa ở mức bài thuyết trình trong tài liệu Microsoft PowerPoint, nên không thể thực hiện điều này.

**Q: Aspose.Slides for Android via Java có hỗ trợ xem trước slide trước khi lưu không?**

**A**: Bạn có thể render các slide của bài thuyết trình thành hình ảnh và sử dụng các hình ảnh này để xem trước slide.

## **Làm việc với văn bản**

**Q: Có thể truy xuất toàn bộ văn bản từ một bài thuyết trình không?**

**A**: Aspose.Slides for Android via Java cung cấp lớp [SlideUtil](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slideutil/) với nhiều phương pháp để truy xuất toàn bộ văn bản từ các bài thuyết trình.

**Q: Tại sao kích thước đoạn văn bản khác nhau trên PC và Android?**

**A**: Việc tính toán kích thước đoạn văn dựa trên kích thước văn bản biểu thị đoạn đó. Kích thước văn bản được tính dựa trên số liệu của phông chữ được chỉ định trong PowerPoint. Nếu phông chữ được chỉ định thiếu, nó sẽ được thay thế bằng phông chữ tương đồng nhất, nhưng phông chữ này có số liệu khác với phông chữ gốc. Do đó, việc tính toán kích thước đoạn văn trên các hệ thống khác nhau sẽ cho ra kết quả khác nhau tùy thuộc vào bộ phông chữ đã cài đặt. Để đạt kết quả giống nhau trên các hệ điều hành khác nhau, bạn cần cài đặt cùng một bộ phông chữ trên các hệ thống hoặc tải chúng lên thời gian chạy dưới dạng [phông chữ bên ngoài](/slides/vi/androidjava/custom-font/).

## **Định dạng và hình ảnh**

**Q: Làm thế nào để đặt màu cho viền của bảng?**

**A**: Bạn có thể thay đổi màu của tất cả các viền bảng hoặc chỉ viền quanh toàn bộ bảng. Để thay đổi tất cả các viền, hãy sử dụng phương thức `getCellFormat` từ giao diện [ICell](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icell/). Đối với viền của toàn bảng, bạn nên duyệt các ô và thay đổi màu của các viền bên ngoài.

**Q: Aspose.Slides for Android via Java đo lường như thế nào khi đặt hình ảnh?**

**A**: Tọa độ và kích thước của tất cả các hình dạng trên slide được đo bằng điểm (72 dpi).

## **Làm việc với phông chữ**

**Q: Khi chuyển đổi PPT sang PDF hoặc hình ảnh, tại sao phông chữ lại khác nhau trong tài liệu đầu ra?**

**A**: Vấn đề này có thể cho thấy các phông chữ được sử dụng trong bài thuyết trình thiếu trên hệ điều hành nơi mã được thực thi. Bạn nên cài đặt các phông chữ trên hệ điều hành hoặc tải chúng lên dưới dạng phông chữ bên ngoài bằng cách sử dụng lớp [FontsLoader](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontsloader/) như dưới đây:
```java
String[] folders = new String[] { "path_to_a_folder_with_fonts" };
FontsLoader.loadExternalFonts(folders);
```