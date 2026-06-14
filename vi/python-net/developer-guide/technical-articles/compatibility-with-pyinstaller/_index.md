---
title: Tương thích với PyInstaller và cx_Freeze
linktitle: Tương thích với PyInstaller
type: docs
weight: 122
url: /vi/python-net/compatibility-with-pyinstaller/
keywords:
- tương thích
- PyInstaller
- cx_Freeze
- Python
- Aspose.Slides
description: "Đóng gói Aspose.Slides cho Python qua .NET bằng PyInstaller. Tham khảo hướng dẫn này để đóng gói, cấu hình và khắc phục sự cố cho ứng dụng của bạn thành một tệp thực thi độc lập."
---
## **Giới thiệu**

Aspose.Slides for Python via .NET extensions là các phần mở rộng chuẩn của Python C, vì vậy chúng có thể được “đóng băng” thành các phụ thuộc của chương trình bằng các công cụ như PyInstaller và cx_Freeze (hoặc tương tự). Điều này cho phép bạn tạo các tệp thực thi từ các script Python của mình. Các công cụ như vậy được gọi là “freezers” vì chúng đóng gói mã nguồn và các phụ thuộc của bạn vào một tệp duy nhất có thể chạy trên các máy khác mà không cần cài đặt Python hay các thư viện bổ sung. Cách tiếp cận này đơn giản hoá việc phân phối các ứng dụng Python của bạn.

Đóng băng một Aspose.Slides for Python via .NET extension thành phụ thuộc được minh họa bên dưới bằng một chương trình đơn giản sử dụng Aspose.Slides.

## **PyInstaller**

Thông thường, không có yêu cầu đặc biệt nào khi đóng gói một chương trình phụ thuộc vào Aspose.Slides for Python via .NET extension. Khi một chương trình nhập (import) phần mở rộng theo cách mà PyInstaller có thể phát hiện, phần mở rộng sẽ được đóng gói cùng chương trình. Vì Aspose.Slides for Python via .NET bao gồm các hook cho PyInstaller, các phụ thuộc của nó sẽ được tự động phát hiện và sao chép vào bundle.

slide_app.py:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50.0, 150.0, 300.0, 0.0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

```bash
$ pyinstaller slide_app.py
```

Tuy nhiên, PyInstaller đôi khi có thể bỏ sót các import ẩn — các mô-đun được nhập một cách động hoặc gián tiếp bởi mã của bạn. Để bao gồm một import ẩn, hãy sử dụng các tùy chọn của PyInstaller. Các phụ thuộc của phần mở rộng được chỉ định trong các hook của PyInstaller đi kèm với Aspose.Slides for Python via .NET.

slide_app.spec:
```
a = Analysis(
    ['slide_app.py'],
    ...
    hiddenimports=['aspose.slides']
)
```

```bash
$ pyinstaller slide_app.spec
```

## **cx_Freeze**

Để đóng băng một chương trình với cx_Freeze, cấu hình nó để bao gồm gói gốc của Aspose.Slides for Python via .NET extension mà bạn đang sử dụng. Điều này đảm bảo phần mở rộng và tất cả các mô-đun phụ thuộc được sao chép vào bản dựng cùng với ứng dụng của bạn.

### **Using the cxfreeze Script**

```bash
$ cxfreeze slide_app.py --packages=aspose
```

### **Using the Setup Script**

setup.py:
```
executables = [Executable('slide_app.py')]

options = {
    'build_exe': {
        'packages': ['aspose'],
    }
}

setup(...
    options=options,
    executables=executables)
```

```bash
$ python setup.py build_exe
```

## **FAQ**

**Tôi có cần cài đặt Microsoft PowerPoint hoặc .NET trên máy của người dùng không?**

Không, không cần PowerPoint. Aspose.Slides là một engine độc lập; gói Python cung cấp mọi thứ cần thiết dưới dạng một extension cho CPython. Người dùng không cần cài đặt .NET riêng biệt.

**Làm thế nào để gắn đúng giấy phép (license) vào ứng dụng đã đóng băng?**

Bạn có thể lưu file XML giấy phép bên cạnh tệp thực thi hoặc nhúng nó như một tài nguyên và tải từ một đường dẫn có thể truy cập trước khi gọi API đầu tiên. Quan trọng: không thay đổi nội dung XML (ngay cả các dấu xuống dòng).

**Nếu phông chữ hiển thị khác nhau sau khi build so với khi phát triển thì nên làm gì?**

Đảm bảo các phông chữ bạn sử dụng có sẵn trong môi trường mục tiêu (được đóng gói hoặc cài đặt trên hệ thống) và đường dẫn của chúng được giải quyết đúng lúc chạy; hành vi phông chữ đặc biệt nhạy cảm trên Linux.