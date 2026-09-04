---
title: "Các hạn chế và khác biệt API"
type: docs
weight: 100
url: /vi/python-java/limitations-and-api-differences/
keywords:
- Aspose.Slides for Python via Java
- khác biệt API
- Python
- Java
- JPype
- hạn chế JVM
- PowerPoint
description: "Tìm hiểu về các hạn chế của JVM và sự khác biệt API giữa Aspose.Slides cho Java và Python qua Java, bao gồm việc nhập khẩu, dọn dẹp tài nguyên và xử lý tệp."
---
## **Tổng quan**

Aspose.Slides for Python via Java sử dụng JPype để truy cập thư viện Java từ Python. Các ví dụ dưới đây so sánh việc nhập gói, tạo bản trình chiếu và xử lý tệp trong hai API.

## **Các hạn chế đã biết**

- **Vòng đời JVM:** JPype hỗ trợ một JVM cho mỗi tiến trình Python. Sau khi tắt nó, bạn không thể khởi động lại trong cùng một tiến trình. Hãy khởi động một lần và tái sử dụng cho các thao tác bản trình chiếu tiếp theo.  
- **Tương thích kiến trúc:** Python và Java phải có kiến trúc trùng khớp. Xem [Yêu cầu Hệ thống](/slides/vi/python-java/system-requirements/#python-java-and-jpype-requirements) để biết chi tiết.

Xem [Hướng dẫn người dùng JPype](https://jpype.readthedocs.io/en/latest/userguide.html) để biết chi tiết về các hạn chế này và khả năng tương tác với Java.

## **Sự khác biệt của API công cộng**

So sánh các ví dụ Java và Python dưới đây. Đối với chi tiết thành viên Python qua Java, xem [API Reference](/slides/vi/python-java/api-reference/).

### **Nhập thư viện**

Java nhập các lớp từ `com.aspose.slides`. Trong Python, nhập `asposeslides` trước khi khởi động JVM, sau đó nhập các lớp từ `asposeslides.api` khi JVM đã chạy. Sử dụng [jpype.isJVMStarted](https://jpype.readthedocs.io/en/latest/api.html#jpype.isJVMStarted) để tránh khởi động lại một JVM đang chạy.

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
```

{{% alert color="info" title="Note" %}}
Các ví dụ Python để JVM chạy cho đến khi tiến trình Python kết thúc. Trong notebook, hãy tái sử dụng JVM đang hoạt động giữa các cell. Nếu JVM đã bị tắt, khởi động lại kernel notebook trước khi sử dụng lại các đối tượng Java.
{{% /alert %}}

### **Tạo một bản trình chiếu**

Java sử dụng từ khóa `new`; Python gọi lớp [Presentation] trực tiếp. Giải phóng tài nguyên bản trình chiếu bằng [Presentation.dispose] trong một khối `finally`.

Cả hai ví dụ đều lưu một bản trình chiếu rỗng bằng [Presentation.save] và [SaveFormat.Pptx].

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.save("new-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Đọc tệp và sử dụng hằng số định dạng**

Java có thể tải một bản trình chiếu từ một luồng đầu vào Java. Trong Python, đọc tệp dưới dạng dữ liệu nhị phân và truyền các byte thu được cho [Presentation.createPresentationFromBytes]. Một đối tượng tệp Python không phải là luồng đầu vào Java.

Các ví dụ dưới đây yêu cầu có sẵn `presentation.pptx` trong thư mục làm việc và lưu một bản sao dưới tên `result.pptx`. Cả hai đều đóng tệp đầu vào và giải phóng tài nguyên bản trình chiếu. Ví dụ Python đọc toàn bộ tệp đầu vào vào bộ nhớ.

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileInputStream;
import java.io.InputStream;

try (InputStream inputStream = new FileInputStream("presentation.pptx")) {
    Presentation presentation = new Presentation(inputStream);
    try {
        presentation.save("result.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

with open("presentation.pptx", "rb") as input_file:
    data = input_file.read()

presentation = Presentation.createPresentationFromBytes(data)
try:
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Câu hỏi thường gặp**

**Tôi có cần khởi động lại JVM cho mỗi bản trình chiếu không?**

Không. Giữ JVM chạy và tạo, giải phóng các đối tượng bản trình chiếu khi cần. Việc tắt JVM sẽ ngăn không cho các thao tác Java tiếp theo trong cùng một tiến trình Python.

**Tôi có thể mở một bản trình chiếu trực tiếp từ đường dẫn tệp không?**

Có. Hàm khởi tạo [Presentation] chấp nhận đường dẫn tệp. Sử dụng trợ giúp dựa trên byte khi dữ liệu bản trình chiếu đã có sẵn dưới dạng byte trong Python.

**Tôi có nên thay đổi tên hằng số định dạng khi chuyển các ví dụ Java sang Python không?**

Không. Ví dụ, [SaveFormat.Pptx] sử dụng cùng một cách viết và viết hoa trong cả hai API.