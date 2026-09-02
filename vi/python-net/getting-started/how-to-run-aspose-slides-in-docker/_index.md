---
title: Cách chạy Aspose.Slides trong Docker
linktitle: Aspose.Slides trong Docker
type: docs
weight: 150
url: /vi/python-net/how-to-run-aspose-slides-in-docker/
keywords:
- Aspose.Slides trong Docker
- Container Docker
- Dockerfile
- Linux
- libgdiplus
- ICU
- OpenSSL
- phông chữ
- PowerPoint
- OpenDocument
- bài thuyết trình
- Python
- Aspose.Slides
description: "Chạy Aspose.Slides for Python via .NET trong Docker: một Dockerfile hoạt động, các thư viện gốc cần thiết, cấu hình phông chữ và cấp phép trong container."
---
## **Tổng quan**

Aspose.Slides for Python via .NET chạy trong các container Linux, nhưng gói này là một lớp bao bọc Python
xung quanh môi trường .NET Core 3.1 được đóng gói sẵn. Môi trường đó cần ba thư viện gốc mà các
image Python nhẹ không cung cấp, và nó yêu cầu các phiên bản cụ thể. Bài viết này cung cấp một Dockerfile
hoạt động, giải thích lý do mỗi phụ thuộc tồn tại, và chỉ cách thêm phông chữ cũng như giấy phép.

## **Dockerfile hoạt động**

```dockerfile
FROM python:3.11-slim-bullseye

RUN apt-get update && apt-get install -y --no-install-recommends \
        libgdiplus \
        libicu67 \
        libfontconfig1 \
        fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*

RUN pip install --no-cache-dir aspose.slides

WORKDIR /app
COPY app.py .
CMD ["python", "app.py"]
```

`app.py`:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    shape.text_frame.text = "Created inside a Docker container"
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)
```

Build and run:

```bash
docker build -t aspose-slides-python .
docker run --rm aspose-slides-python
```

## **Tại sao ảnh nền là Debian 11**

Bánh xe `aspose.slides` bao gồm một môi trường **.NET Core 3.1**, và môi trường này trước thời điểm các
phiên bản thư viện được cung cấp trong các bản phát hành Debian hiện tại. Trên Debian 12 và 13 container
xây dựng thành công nhưng sau đó thất bại ở lời gọi `Presentation()` đầu tiên:

```
Process terminated. Couldn't find a valid ICU package installed on the system.
```

Thông báo gây nhầm lẫn — ICU *đã* được cài trên các image đó, nhưng là ICU 72 hoặc 76, trong khi .NET
Core 3.1 chỉ nhận ra các phiên bản chính cũ hơn. Debian 12 còn cung cấp OpenSSL 3, tạo ra lỗi thứ hai:

```
No usable version of libssl was found
```

`python:3.11-slim-bullseye` là Debian 11, cung cấp cả hai phiên bản mà môi trường đóng gói yêu cầu:

| Gói | Phiên bản trên Debian 11 | Lý do cần |
|---|---|---|
| `libgdiplus` | 6.0.4 | Cài đặt GDI+ dùng để vẽ hình dạng, văn bản và hình ảnh |
| `libicu67` | 67.1 | Dữ liệu quốc tế hoá. Các phiên bản chính mới hơn không được .NET Core 3.1 nhận diện |
| `libssl1.1` | 1.1.1w | Mã hoá. Được cài sẵn trên Debian 11; không có trên Debian 12+ |
| `libfontconfig1` | — | Phát hiện phông chữ |

`libssl1.1` đã có trong ảnh nền, vì vậy không cần liệt kê trong `apt-get install`.

Nếu bạn phải dùng một ảnh nền mới hơn, đặt `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1` để bỏ qua yêu cầu ICU.
Điều này vô hiệu hoá định dạng dựa trên văn hoá và **không** giải quyết vấn đề OpenSSL, vì vậy Debian 11
vẫn là lựa chọn đơn giản hơn.

## **Phông chữ**

Các image nhẹ không chứa bất kỳ phông chữ nào. Nếu không có ít nhất một phông chữ được cài, văn bản sẽ
hiển thị dưới dạng các hộp trống trong PDF, hình ảnh và HTML. `fonts-dejavu-core` là một điểm khởi đầu
nhỏ gọn, đa năng.

Để khớp với giao diện mong muốn của một bản trình chiếu, sao chép các phông chữ mà nó sử dụng vào image
và chỉ định chúng cho Aspose.Slides:

```dockerfile
COPY fonts/ /usr/share/fonts/truetype/custom/
RUN fc-cache -f
```

```py
import aspose.slides as slides

slides.FontsLoader.load_external_fonts(["/usr/share/fonts/truetype/custom/"])
```

## **Cấp phép trong container**

Không nên đưa tập tin giấy phép vào image — bất kỳ ai kéo image sẽ có được giấy phép. Hãy gắn nó
vào khi chạy:

```bash
docker run --rm -v /path/on/host:/license aspose-slides-python
```

```py
import aspose.slides as slides

license = slides.License()
license.set_license("/license/Aspose.Slides.Python.NET.lic")
```

Nếu không có giấy phép, thư viện sẽ chạy ở chế độ đánh giá, thêm watermark và giới hạn số slide
được xử lý. Xem [Cấp phép](/slides/vi/python-net/licensing/) để biết chi tiết.

## **Bộ nhớ**

Việc render ra PDF hoặc hình ảnh tiêu tốn nhiều bộ nhớ hơn việc chỉ đọc tệp. Các container với giới hạn
bộ nhớ chặt chẽ có thể bị trình dọn dẹp OOM giết dở giữa quá trình chuyển đổi, thường biểu hiện là
tiến trình biến mất mà không có traceback của Python. Nếu xảy ra, hãy tăng giới hạn bộ nhớ của container
trước khi kiểm tra mã nguồn.