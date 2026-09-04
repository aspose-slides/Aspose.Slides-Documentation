---
title: Cài đặt
type: docs
weight: 70
url: /vi/python-java/installation/
keywords:
- tải xuống Aspose.Slides
- cài đặt Aspose.Slides
- cài đặt Aspose.Slides
- Python
- Java
- JPype
- Windows
- macOS
- Linux
description: "Cài đặt Aspose.Slides cho Python qua Java trên Windows, Linux hoặc macOS, cấu hình Java và JPype, và xác minh cài đặt bằng một ví dụ hoạt động."
---
Aspose.Slides cho Python qua Java chạy trên Windows, Linux và macOS. Nó sử dụng JPype để truy cập thư viện Java từ Python. Microsoft PowerPoint không bắt buộc.

## **Prerequisites**

Trước khi cài đặt các gói Python, hãy cài đặt Python và JDK đáp ứng [Yêu cầu Hệ thống](/slides/vi/python-java/system-requirements/). Trang đó liệt kê các phiên bản tương thích, yêu cầu kiến trúc và bất kỳ phụ thuộc nào cần thiết để xây dựng JPype từ nguồn.

Đặt `JAVA_HOME` tới thư mục cài đặt JDK, không phải thư mục con `bin` của nó, và thêm thư mục `bin` của JDK vào `PATH`. Mở một terminal mới sau khi thay đổi biến môi trường.

## **Install from PyPI**

Chạy các lệnh sau trong terminal, không phải tại giao diện tương tác của Python. Tạo một thư mục dự án và môi trường ảo để giữ các gói được cô lập khỏi các dự án khác.

### **Windows**

Với trình thông dịch Python mà bạn chọn có sẵn là `python` trên `PATH`, chạy các lệnh sau trong Command Prompt:

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux and macOS**

Với phiên bản Python mà bạn chọn có sẵn là `python3`, chạy các lệnh sau trong Bash hoặc zsh:

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

Trên Debian hoặc Ubuntu, nếu việc tạo môi trường thất bại vì `ensurepip` không có sẵn, cài đặt gói `python3-venv` bằng `sudo apt-get install python3-venv`, sau đó lặp lại lệnh tạo môi trường. Một phiên bản Python được cài đặt riêng có thể cần gói `venv` tương thích với phiên bản đó.

### **Install the Packages**

Với môi trường ảo đang hoạt động, cài đặt JPype và Aspose.Slides:

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

Sử dụng `python -m pip` đảm bảo rằng các gói được cài đặt cho trình thông dịch được dùng để chạy ứng dụng của bạn.

Để cập nhật cài đặt Aspose.Slides hiện có, chạy `python -m pip install --upgrade aspose-slides-java` trong cùng môi trường.

## **Install from a ZIP Archive**

Bạn cũng có thể sử dụng thư viện từ [trang tải xuống Aspose.Slides](https://releases.aspose.com/slides/vi/python-java/):

1. Cài đặt Python và Java như mô tả trong [Yêu cầu trước](#prerequisites).
2. Tạo và kích hoạt môi trường ảo bằng cách sử dụng các hướng dẫn ở trên.
3. Cài đặt JPype bằng `python -m pip install JPype1`.
4. Tải xuống và giải nén tệp ZIP Aspose.Slides cho Python qua Java.
5. Xác định thư mục gói `asposeslides` đã giải nén. Giữ nguyên nội dung của nó, bao gồm thư mục `lib` và tệp JAR, cùng nhau.
6. Đặt `example.py` từ phần tiếp theo bên cạnh thư mục `asposeslides` để Python có thể nhập gói.

## **Verify the Installation**

Lưu đoạn mã sau dưới dạng `example.py`. Nó tạo một bản trình bày với một hộp văn bản và lưu nó thành `out.pptx` trong thư mục làm việc hiện tại.

```python
import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Presentation, SaveFormat, ShapeType

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 500, 80)
        shape.getTextFrame().setText("Aspose.Slides is ready!")
        presentation.save("out.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    jpype.shutdownJVM()
```

Với môi trường ảo đang hoạt động, chạy ví dụ từ thư mục chứa `example.py`:

```sh
python example.py
```

`asposeslides` import đăng ký thư viện Java được đóng gói trước khi JVM khởi động. Nhập `asposeslides.api` sau khi khởi động JVM, và giải phóng tài nguyên bản trình bày trước khi tắt nó.

{{% alert color="info" title="Ghi chú" %}}

Không có giấy phép, đầu ra sẽ có watermark đánh giá. Xem [Đánh giá Aspose.Slides](/slides/vi/python-java/evaluate-aspose-slides/) để biết các hạn chế khi đánh giá và thông tin về giấy phép tạm thời.

{{% /alert %}}

## **FAQ**

**Tại sao Python báo rằng không tìm thấy hoặc không thể tải JVM?**

Kiểm tra rằng `JAVA_HOME` chỉ tới một JDK tương thích với Python và cài đặt JPype của bạn, như mô tả trong [Yêu cầu Hệ thống](/slides/vi/python-java/system-requirements/). Xem [hướng dẫn khắc phục sự cố cài đặt JPype](https://jpype.readthedocs.io/en/latest/install.html) để có các kiểm tra bổ sung.

**Tại sao Python báo rằng `asposeslides` bị thiếu sau khi cài đặt?**

Gói có thể đã được cài đặt cho một trình thông dịch Python khác. Kích hoạt môi trường ảo đã dùng để cài đặt và chạy `python -m pip show aspose-slides-java`. Đối với cài đặt ZIP, hãy đảm bảo rằng thư mục `asposeslides` nằm cùng với script của bạn hoặc có sẵn trong đường dẫn tìm kiếm mô-đun của Python.

**Tôi có thể chạy ví dụ này nhiều lần trong một notebook không?**

Ví dụ này được thiết kế cho một quá trình Python độc lập. Trước khi điều chỉnh nó để thực thi lặp lại trong notebook, hãy xem [Các hạn chế và khác biệt API](/slides/vi/python-java/limitations-and-api-differences/#import-the-library) để biết vòng đời JVM và hướng dẫn notebook.

**Tại sao pip thất bại với lỗi `CERTIFICATE_VERIFY_FAILED`?**

Nếu mạng của bạn sử dụng proxy kiểm tra HTTPS, pip phải tin cậy tổ chức chứng chỉ của nó. Cấu hình gói CA tin cậy bằng tùy chọn `--cert` của pip hoặc biến môi trường `PIP_CERT`, theo [hướng dẫn chứng chỉ HTTPS của pip](https://pip.pypa.io/en/stable/topics/https-certificates/). Cấu hình cần thiết phụ thuộc vào mạng và phiên bản pip của bạn.