---
title: Câu hỏi thường gặp
type: docs
weight: 340
url: /vi/python-java/faqs/
keywords:
- Câu hỏi thường gặp
- định dạng bản trình chiếu
- lỗi thiếu bộ nhớ
- kích thước slide
- trích xuất văn bản
- kích thước đoạn
- đường viền bảng
- phông chữ
- PowerPoint
- OpenDocument
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Tìm câu trả lời cho các câu hỏi thường gặp về Aspose.Slides cho Python qua Java, bao gồm định dạng tệp, việc sử dụng bộ nhớ, kích thước slide, văn bản, bảng, hình ảnh và phông chữ."
---
## **Tổng quan**

FAQ này bao gồm các định dạng tệp được hỗ trợ, việc sử dụng bộ nhớ với các bản thuyết trình lớn, kích thước và bản xem trước của slide, trích xuất văn bản, đường viền bảng, vị trí ảnh và sự khác biệt về phông chữ khi chuyển đổi bản thuyết trình sang PDF hoặc hình ảnh.

## **Câu hỏi thường gặp**

### **Định dạng tệp được hỗ trợ**

**Các định dạng tệp nào Aspose.Slides for Python qua Java hỗ trợ?**

Xem [Định dạng tệp được hỗ trợ](/slides/vi/python-java/supported-file-formats/) để biết các định dạng trình chiếu, tài liệu và hình ảnh được hỗ trợ cũng như khả năng nhập và xuất của chúng.

### **Ngoại lệ**

**Tại sao tôi nhận được lỗi hết bộ nhớ khi tải một bản thuyết trình lớn có hình ảnh? Có giới hạn kích thước tệp nào không?**

Không có ngưỡng kích thước tệp duy nhất nào có thể dự đoán một bản thuyết trình có vừa trong bộ nhớ hay không. Yêu cầu bộ nhớ phụ thuộc vào cấu trúc bản thuyết trình, hình ảnh đã giải nén, hiệu ứng và các thao tác bạn thực hiện. Hình ảnh có thể chiếm nhiều bộ nhớ hơn đáng kể so với kích thước nén trên đĩa.

Aspose.Slides for Python qua Java sử dụng engine Java qua JPype, vì vậy heap JVM phải có đủ không gian cho việc xử lý. RAM hệ thống khả dụng không phản ánh lượng bộ nhớ mà JVM có thể sử dụng. Giải phóng các bản thuyết trình bằng [Presentation.dispose](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#dispose) khi bạn hoàn tất sử dụng chúng. Đối với cài đặt môi trường, xem [Yêu cầu hệ thống](/slides/vi/python-java/system-requirements/) và [Cài đặt](/slides/vi/python-java/installation/).

### **Làm việc với Slide**

**Tôi có thể thay đổi kích thước của các slide trong bản thuyết trình không?**

Có. Sử dụng [Presentation.getSlideSize](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getslidesize) để truy cập cài đặt kích thước slide của bản thuyết trình, sau đó dùng [SlideSize.setSize](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slidesize/#setsize) để đặt kích thước và chọn cách nội dung hiện có được thu phóng.

**Các slide trong cùng một bản thuyết trình có thể có kích thước khác nhau không?**

Không. Các tài liệu Microsoft PowerPoint xác định kích thước slide ở cấp độ bản thuyết trình, do đó tất cả các slide có cùng kích thước.

**Tôi có thể xem trước một slide trước khi lưu bản thuyết trình không?**

Có. Kết xuất slide thành hình ảnh và hiển thị hình ảnh đó trong ứng dụng của bạn. Bạn không cần phải lưu bản thuyết trình trước.

### **Làm việc với Văn bản**

**Tôi có thể lấy tất cả văn bản từ một bản thuyết trình không?**

Có. Lớp [SlideUtil](https://reference.aspose.com/slides/vi/python-java/aspose.slides/slideutil/) cung cấp các phương thức để lấy văn bản từ bản thuyết trình và các slide riêng lẻ.

**Tại sao kích thước đoạn văn khác nhau trên Windows và Linux?**

Kích thước đoạn phụ thuộc vào các chỉ số của phông chữ được dùng để hiển thị văn bản. Nếu một phông chữ bị thiếu, phông thay thế có thể có độ rộng ký tự và chiều cao dòng khác nhau, dẫn đến việc ngắt dòng và kích thước đoạn thay đổi. Cài đặt cùng một bộ phông trên cả hai hệ thống hoặc tải cùng các tệp phông bằng [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsloader/#loadexternalfonts) trước khi tạo hoặc tải bản thuyết trình.

### **Định dạng và Hình ảnh**

**Làm thế nào để đặt màu cho đường viền bảng?**

Sử dụng [Cell.getCellFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/cell/#getcellformat) để truy cập định dạng đường viền của từng ô và đặt màu nền cho các đường viền tương ứng. Để thay đổi mọi đường viền, xử lý tất cả các ô. Để chỉ thay đổi viền bao quanh bảng, cập nhật chỉ các đường viền hướng ra ngoài của các ô dọc biên của bảng.

**Đơn vị nào được sử dụng để định vị và kích thước hình ảnh?**

Các tọa độ và kích thước của hình dạng được đo bằng điểm. Một inch tương đương 72 điểm; các giá trị này không phải là tọa độ pixel.

### **Làm việc với Phông chữ**

**Tại sao phông chữ thay đổi khi tôi chuyển đổi bản thuyết trình sang PDF hoặc hình ảnh?**

Các phông chữ cần thiết có thể thiếu trên máy thực hiện việc chuyển đổi. Cài đặt các phông chữ gốc hoặc sử dụng [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/vi/python-java/aspose.slides/fontsloader/#loadexternalfonts) để thêm thư mục chứa chúng. Tải phông chữ ngoại vi trước khi tạo hoặc mở bản thuyết trình.

Ví dụ sau đăng ký một thư mục phông chữ. Thay thế đường dẫn bằng một thư mục hiện có chứa các tệp phông chữ của bạn. Nó giả định môi trường được mô tả trong [Cài đặt](/slides/vi/python-java/installation/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontsLoader

font_folders = jpype.JArray(jpype.JString)(["path_to_a_folder_with_fonts"])
FontsLoader.loadExternalFonts(font_folders)
```

Ví dụ để JVM chạy liên tục cho các thao tác bản thuyết trình tiếp theo. Đối với việc sử dụng trong notebook và các giới hạn vòng đời JVM, xem [Hạn chế và Sự khác nhau API](/slides/vi/python-java/limitations-and-api-differences/).