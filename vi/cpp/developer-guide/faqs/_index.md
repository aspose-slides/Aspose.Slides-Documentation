---
title: Câu hỏi thường gặp
type: docs
weight: 340
url: /vi/cpp/faqs/
keywords:
- Câu hỏi thường gặp
- định dạng bản trình chiếu
- lỗi tràn bộ nhớ
- kích thước slide
- trích xuất văn bản
- lấy văn bản
- kích thước đoạn văn
- định dạng bảng
- phông chữ
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Nhận câu trả lời cho các câu hỏi thường gặp về Aspose.Slides cho C++, bao gồm hỗ trợ PowerPoint và OpenDocument, hướng dẫn cài đặt, cấp phép, khắc phục sự cố."
---
## **Tổng quan**

Câu hỏi thường gặp này cung cấp câu trả lời cho các câu hỏi phổ biến về Aspose.Slides. Nó bao gồm các định dạng tệp được hỗ trợ, xử lý ngoại lệ khi làm việc với các bản trình chiếu lớn, thay đổi kích thước slide, xem trước slide, lấy văn bản từ bản trình chiếu, định dạng viền bảng, đặt hình ảnh và giải quyết các vấn đề liên quan đến phông chữ khi chuyển đổi bản trình chiếu sang PDF hoặc hình ảnh.

## **Định dạng tệp được hỗ trợ**

**Q:** Aspose.Slides cho C++ hỗ trợ những định dạng tệp nào?

**A:** Aspose.Slides cho C++ hỗ trợ các định dạng tệp được mô tả trong [Supported File Formats](/slides/vi/cpp/supported-file-formats/).

## **Ngoại lệ**

**Q:** Tôi nhận được ngoại lệ out of memory khi tải một tệp PPT lớn có hình ảnh. Có giới hạn nào về kích thước tệp trong Aspose.Slides không?

**A:** Không có công thức cụ thể nào để tính kích thước bản trình chiếu mà Aspose.Slides hỗ trợ. Cần có đủ không gian để chứa toàn bộ cấu trúc bản trình chiếu và các hình ảnh trong bộ nhớ. Thông thường, hình ảnh trong bộ nhớ chiếm nhiều không gian hơn so với trên ổ cứng, đặc biệt khi hình ảnh có các hiệu ứng bổ sung.

Nhìn chung, Aspose.Slides cho C++ có thể dễ dàng xử lý các tệp bản trình chiếu khoảng 300 MB trên máy chủ có 4 GB RAM.

## **Làm việc với các slide**

**Q:** Tôi có thể thay đổi kích thước của các slide trong một bản trình chiếu không?

**A:** Bạn có thể sử dụng phương thức `get_SlideSize` được mở ra bởi lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) để xác định kích thước của các slide trong một bản trình chiếu.

**Q:** Có cách nào để định nghĩa các slide có kích thước khác nhau trong một bản trình chiếu không?

**A:** Vì kích thước slide được định nghĩa ở mức độ bản trình chiếu trong tài liệu Microsoft PowerPoint, nên không có cách nào để thực hiện điều này.

**Q:** Aspose.Slides cho C++ có hỗ trợ xem trước một slide trước khi lưu không?

**A:** Bạn có thể render các slide của bản trình chiếu thành hình ảnh và sử dụng các hình ảnh này để xem trước các slide.

## **Làm việc với văn bản**

**Q:** Có thể lấy tất cả văn bản từ một bản trình chiếu không?

**A:** Aspose.Slides cho C++ cung cấp lớp [SlideUtil](https://reference.aspose.com/slides/vi/cpp/aspose.slides.util/slideutil/) trong không gian tên `Aspose::Slides::Util` để cung cấp các phương pháp khác nhau nhằm lấy toàn bộ văn bản từ các bản trình chiếu.

**Q:** Tại sao kích thước đoạn văn khác nhau trên hệ điều hành Windows và Linux?

**A:** Việc tính toán kích thước đoạn văn dựa trên kích thước văn bản đại diện cho đoạn văn đó. Kích thước văn bản được tính dựa trên các số liệu của phông chữ được chỉ định trong bản trình chiếu PowerPoint. Nếu phông chữ được chỉ định không tồn tại, nó sẽ được thay thế bằng phông chữ gần nhất, nhưng phông chữ này có các số liệu khác với phông chữ gốc. Do đó, việc tính toán kích thước đoạn văn trên các hệ thống khác nhau sẽ cho ra kết quả khác nhau tùy thuộc vào tập hợp phông chữ đã cài đặt. Để đạt được kết quả giống nhau trên các hệ điều hành khác nhau, bạn cần cài đặt cùng một bộ phông chữ trên các hệ thống hoặc tải chúng tại thời gian chạy dưới dạng [external fonts](/slides/vi/cpp/custom-font/).

## **Định dạng và hình ảnh**

**Q:** Làm thế nào để đặt màu cho viền bảng?

**A:** Bạn có thể thay đổi màu của tất cả các viền bảng hoặc chỉ viền quanh toàn bộ bảng. Để thay đổi tất cả các viền, vui lòng sử dụng phương thức `get_CellFormat` từ giao diện [ICell](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icell/). Đối với viền của toàn bảng, bạn nên duyệt các ô và thay đổi màu của các viền bên ngoài.

**Q:** Aspose.Slides cho C++ đo lường như thế nào khi đặt hình ảnh?

**A:** Tọa độ và kích thước của tất cả các hình dạng trên slide được đo bằng điểm (72 dpi).

## **Làm việc với phông chữ**

**Q:** Khi chuyển đổi PPT sang PDF hoặc hình ảnh, tại sao phông chữ lại khác nhau trong tài liệu đầu ra?

**A:** Vấn đề này có thể cho thấy các phông chữ được sử dụng trong bản trình chiếu đang thiếu trên hệ điều hành nơi mã được thực thi. Bạn nên cài đặt các phông chữ trên hệ điều hành hoặc tải chúng như phông chữ bên ngoài bằng cách sử dụng lớp [FontsLoader](https://reference.aspose.com/slides/vi/cpp/aspose.slides/fontsloader/) như minh họa dưới đây:
```cpp
auto folders = MakeObject<Array<String>>(1, "path_to_a_folder_with_fonts");
FontsLoader::LoadExternalFonts(folders);
```