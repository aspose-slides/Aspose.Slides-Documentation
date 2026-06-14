---
title: "Câu hỏi thường gặp"
type: docs
weight: 340
url: /vi/php-java/faqs/
keywords:
- "Câu hỏi thường gặp"
- "định dạng bản trình chiếu"
- "lỗi tràn bộ nhớ"
- "kích thước slide"
- "trích xuất văn bản"
- "lấy văn bản"
- "kích thước đoạn văn"
- "định dạng bảng"
- "phông chữ"
- "PowerPoint"
- "OpenDocument"
- "bản trình chiếu"
- "PHP"
- "Aspose.Slides"
description: "Nhận câu trả lời cho các câu hỏi thường gặp về Aspose.Slides cho PHP qua Java, bao gồm hỗ trợ PowerPoint và OpenDocument, hướng dẫn cài đặt, giấy phép và khắc phục sự cố."
---
## **Tổng quan**

FAQ này cung cấp câu trả lời cho các câu hỏi thường gặp về Aspose.Slides. Nó bao gồm các định dạng tệp được hỗ trợ, xử lý ngoại lệ khi làm việc với các bản trình chiếu lớn, thay đổi kích thước slide, xem trước slide, truy xuất văn bản từ bản trình chiếu, định dạng viền bảng, chèn hình ảnh và giải quyết các vấn đề liên quan đến phông chữ khi chuyển đổi bản trình chiếu sang PDF hoặc hình ảnh.

## **Định dạng tệp được hỗ trợ**

**Q:** Aspose.Slides for PHP via Java hỗ trợ những định dạng tệp nào?

**A:** Aspose.Slides for PHP via Java hỗ trợ các định dạng tệp được mô tả trong [Định dạng tệp được hỗ trợ](/slides/vi/php-java/supported-file-formats/).

## **Ngoại lệ**

**Q:** Tôi gặp lỗi tràn bộ nhớ khi tải một tệp PPT lớn có chứa hình ảnh. Aspose.Slides có giới hạn nào về kích thước tệp không?

**A:** Không có công thức cụ thể nào để tính kích thước bản trình chiếu mà Aspose.Slides hỗ trợ. Cần có đủ không gian để chứa toàn bộ cấu trúc bản trình chiếu và các hình ảnh trong bộ nhớ. Thông thường, hình ảnh trong bộ nhớ chiếm nhiều không gian hơn so với trên đĩa cứng, đặc biệt khi hình ảnh có các hiệu ứng bổ sung.

Nhìn chung, Aspose.Slides for PHP via Java có thể dễ dàng xử lý các tệp bản trình chiếu có dung lượng khoảng 300 MB trên máy chủ với 4 GB RAM.

## **Làm việc với Slide**

**Q:** Tôi có thể thay đổi kích thước của các slide trong một bản trình chiếu không?

**A:** Bạn có thể sử dụng phương thức `getSlideSize` được cung cấp bởi lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) để xác định kích thước của các slide trong một bản trình chiếu.

**Q:** Có cách nào để định nghĩa các slide có kích thước khác nhau trong một bản trình chiếu không?

**A:** Vì kích thước của các slide được xác định ở mức bản trình chiếu trong tài liệu Microsoft PowerPoint, nên không có cách nào thực hiện điều này.

**Q:** Aspose.Slides for PHP via Java có hỗ trợ xem trước một slide trước khi lưu không?

**A:** Bạn có thể render các slide của bản trình chiếu thành hình ảnh và sử dụng các hình ảnh này để xem trước các slide.

## **Làm việc với Văn bản**

**Q:** Có thể truy xuất toàn bộ văn bản từ một bản trình chiếu không?

**A:** Aspose.Slides for PHP via Java cung cấp lớp [SlideUtil](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideutil/) với các phương thức đa dạng để truy xuất toàn bộ văn bản từ các bản trình chiếu.

**Q:** Tại sao kích thước đoạn văn lại khác nhau trên hệ điều hành Windows và Linux?

**A:** Việc tính kích thước đoạn văn dựa trên việc tính kích thước văn bản đại diện cho đoạn đã cho. Kích thước văn bản được tính dựa trên các chỉ số của phông chữ được chỉ định trong bản trình chiếu PowerPoint. Nếu phông chữ được chỉ định không có, nó sẽ được thay thế bằng phông chữ tương tự nhất, nhưng phông chữ này có các chỉ số khác với phông chữ gốc. Do đó, việc tính kích thước đoạn văn trên các hệ thống khác nhau sẽ cho ra kết quả khác nhau tùy thuộc vào bộ phông chữ đã cài đặt. Để đạt được kết quả nhất quán trên các hệ điều hành khác nhau, bạn cần cài đặt cùng một bộ phông chữ trên các hệ thống hoặc tải chúng tại thời gian chạy như [phông chữ bên ngoài](/slides/vi/php-java/custom-font/).

## **Định dạng và Hình ảnh**

**Q:** Làm sao tôi có thể đặt màu cho viền bảng?

**A:** Bạn có thể thay đổi màu của tất cả các viền bảng hoặc chỉ viền quanh toàn bộ bảng. Để thay đổi tất cả các viền, vui lòng sử dụng phương thức `getCellFormat` từ lớp [Cell](https://reference.aspose.com/slides/vi/php-java/aspose.slides/cell/). Đối với viền của toàn bộ bảng, bạn nên duyệt qua các ô và thay đổi màu của các viền ngoài.

**Q:** Aspose.Slides for PHP via Java sử dụng đơn vị đo nào khi đặt hình ảnh?

**A:** Các tọa độ và kích thước của tất cả các hình dạng trên slide được đo bằng điểm (72 dpi).

## **Làm việc với Phông chữ**

**Q:** Khi chuyển đổi PPT sang PDF hoặc hình ảnh, tại sao phông chữ trong tài liệu đầu ra lại khác nhau?

**A:** Vấn đề này có thể cho thấy các phông chữ được sử dụng trong bản trình chiếu thiếu trên hệ điều hành mà mã được chạy. Bạn nên cài đặt các phông chữ trên hệ điều hành hoặc tải chúng như các phông chữ bên ngoài bằng cách sử dụng lớp [FontsLoader](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsloader/) như dưới đây:
```php
$folders = ["path_to_a_folder_with_fonts"];
FontsLoader::loadExternalFonts($folders);
```