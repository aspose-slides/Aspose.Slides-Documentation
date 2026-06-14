---
title: Giới hạn và khác biệt API
type: docs
weight: 100
url: /vi/python-java/limitations-and-api-differences/
keywords: "node, powerpoint, hạn chế, api, khác biệt"
description: "Các hạn chế và khác biệt API của Aspose.Slides cho Python qua Java."
---
## **Lỗi/Nhược điểm đã biết**
Các lớp Java ở ngoài một gói (trong `default`) không thể được nhập.
Do thiếu hỗ trợ JVM, bạn không thể tắt JVM rồi khởi động lại. Bạn cũng không thể khởi động hơn một bản sao của JVM.
Kết hợp Python 64 bit với Java 32 bit và ngược lại sẽ gây lỗi khi nhập mô-đun jpype.

## **Khác biệt API công cộng**
Danh sách sau (kèm các đoạn mã mẫu) cho thấy một số khác biệt giữa Aspose.Slides cho Java và Aspose.Slides cho Python qua các API Java.

### **Nhập thư viện (So sánh gói)**

**Aspose.Slides for Java**

```java
import com.aspose.slides.*;
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

jpype.shutdownJVM()
```

### **Tạo một Presentation mới**

**Aspose.Slides for Java**

```java
Presentation pres = new Presentation();
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation

pres = Presentation();

jpype.shutdownJVM()
```

### **Phát luồng Tập tin và Hằng số**

**Aspose.Slides for Java**

```java
InputStream inputstream = new FileInputStream("Pres1.pptx");
Presentation pres = new Presentation(inputstream);
pres.save("result.pptx", SaveFormat.Pptx);
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

input = open("presentation.pptx", mode="rb")
data = input.read()
pres = Presentation.createPresentationFromBytes(data)
pres.save("result.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```

### **Các hạn chế khác của Aspose.Slides cho Python qua API Java so với Aspose.Slides cho Java API**

Để biết thêm thông tin về các hạn chế khác, vui lòng tham khảo tài liệu jpype: 
- https://jpype.readthedocs.io/en/latest/