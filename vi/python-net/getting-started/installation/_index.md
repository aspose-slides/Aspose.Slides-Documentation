---
title: Cài đặt
type: docs
weight: 70
url: /vi/python-net/installation/
keywords:
- tải xuống Aspose.Slides
- cài đặt Aspose.Slides
- sử dụng Aspose.Slides
- cài đặt Aspose.Slides
- Windows
- macOS
- Python
description: "Tìm hiểu cách cài đặt nhanh Aspose.Slides for Python via .NET. Hướng dẫn từng bước, yêu cầu hệ thống và mẫu mã — bắt đầu làm việc với các bản trình chiếu PowerPoint ngay hôm nay!"
---
## **Tổng quan**

Gói Aspose.Slides for Python via .NET đi kèm với tất cả các thư viện .NET thiết yếu đã được đóng gói, do đó không cần cài đặt .NET riêng. Điều này đơn giản hoá quá trình thiết lập và cho phép các nhà phát triển bắt đầu làm việc với các bản trình chiếu ngay lập tức. Tuy nhiên, cần lưu ý rằng tùy thuộc vào hệ điều hành hoặc môi trường của bạn, bạn vẫn có thể cần cài đặt một số phụ thuộc đặc thù cho nền tảng mà .NET yêu cầu. Ngoài ra, một số yêu cầu hệ thống nhất định phải được đáp ứng để đảm bảo tính tương thích đầy đủ và hoạt động đúng của gói.

## **Windows**

**Yêu cầu hệ thống**

Kiểm tra và xác nhận rằng các thông số kỹ thuật của máy bạn đáp ứng hoặc vượt quá [các yêu cầu hệ thống](/slides/vi/python-net/system-requirements/).

### **Cài đặt Aspose.Slides**

`pip` là cách dễ nhất để tải xuống và cài đặt [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) trên Windows.

Để cài đặt Aspose.Slides, chạy lệnh sau:

```sh
pip install aspose-slides
```

**Sử dụng Aspose.Slides**

Kiểm tra việc cài đặt Aspose.Slides của bạn bằng cách chạy đoạn mã sau để tạo một bản trình chiếu PowerPoint:

```python
# Nhập mô-đun Aspose.Slides for Python via .NET.
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation đại diện cho tệp bản trình chiếu.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **macOS**

**Yêu cầu hệ thống**

Kiểm tra và xác nhận rằng các thông số kỹ thuật của máy bạn đáp ứng hoặc vượt quá [các yêu cầu hệ thống](/slides/vi/python-net/system-requirements/).

### **Yêu cầu trước**

**Python với Thư viện Chia sẻ**

Có một số cách để cài đặt Python trên macOS, nhưng chúng tôi mạnh mẽ đề xuất sử dụng [pyenv tool](https://github.com/pyenv/pyenv#homebrew-in-macos).

Sau khi cài đặt và cấu hình **pyenv**, cài đặt Python với các thư viện chia sẻ bằng cách chạy các lệnh sau trong ứng dụng Terminal:

1. Cài đặt Python:

```sh
env PYTHON_CONFIGURE_OPTS="--enable-shared" pyenv install --verbose 3.9.13
```

2. Đặt làm phiên bản Python toàn cục:

```sh
pyenv global 3.9.13
```

3. Đặt làm phiên bản Python cho shell hiện tại:

```sh
pyenv shell 3.9.13
```

4. Tạo liên kết tượng trưng cho thư viện libpython trong thư mục thư viện hệ thống:

```sh
ln -s /Users/<username>/.pyenv/versions/3.9.13/lib/libpython3.9.dylib /usr/local/lib/libpython3.9.dylib
```

Lưu ý: Cần Python 3.5 trở lên. Phiên bản 3.9.13 được sử dụng ở đây chỉ là một ví dụ.

**Cài đặt Thư viện libgdiplus**

Thư viện **libgdiplus** là một triển khai Windows GDI+ cho macOS và Linux mà .NET dựa vào để cung cấp chức năng đồ họa trên các nền tảng này.  
Để cài đặt thư viện này trên macOS, chạy lệnh sau:

```sh
brew install mono-libgdiplus
```

### **Cài đặt Aspose.Slides**

`pip` là cách dễ nhất để tải xuống và cài đặt [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) trên macOS.

Để cài đặt Aspose.Slides, chạy lệnh sau:

```sh
pip install aspose-slides
```

**Sử dụng Aspose.Slides**

Kiểm tra việc cài đặt Aspose.Slides của bạn bằng cách chạy đoạn mã sau để tạo một bản trình chiếu PowerPoint:

```python
# Nhập mô-đun Aspose.Slides for Python qua .NET.
import aspose.slides as slides

# Tạo một thể hiện của lớp Presentation đại diện cho tệp bản trình chiếu.
with slides.Presentation() as presentation:    
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Tôi có thể cài đặt Aspose.Slides trong môi trường ảo không?**

Có, bạn có thể cài đặt nó trong bất kỳ môi trường ảo Python nào bằng `pip`. Chỉ cần đảm bảo môi trường có quyền truy cập vào các phụ thuộc gốc cần thiết tùy theo hệ điều hành của bạn.

**Tôi có thể sử dụng Aspose.Slides trong các container Docker không?**

Có, nhưng bạn cần chắc chắn rằng hình ảnh Docker của bạn bao gồm các thư viện gốc cần thiết (**libgdiplus**, các gói phông chữ, v.v.) và phiên bản Python phù hợp.

**Có phiên bản miễn phí hoặc giới hạn dùng thử không?**

Có, theo mặc định Aspose.Slides chạy ở chế độ đánh giá, sẽ hiển thị watermark và có thể có các hạn chế khác. Để bỏ các giới hạn, bạn cần áp dụng một [giấy phép](/slides/vi/python-net/licensing/) hợp lệ.