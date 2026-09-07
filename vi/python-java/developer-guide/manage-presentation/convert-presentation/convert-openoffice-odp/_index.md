---
title: Chuyển đổi bản trình chiếu OpenDocument trong Python
linktitle: Chuyển đổi OpenDocument
type: docs
weight: 10
url: /vi/python-java/convert-openoffice-odp/
keywords:
- chuyển đổi ODP
- ODP sang PDF
- ODP sang HTML
- ODP sang TIFF
- ODP sang PPT
- ODP sang PPTX
- ODP sang XPS
- OpenDocument
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Chuyển đổi các bản trình chiếu OpenDocument (ODP) sang PDF, HTML và các định dạng khác bằng Aspose.Slides cho Python qua Java, mà không cần cài đặt OpenOffice hoặc LibreOffice."
---
## **Giới thiệu**

Aspose.Slides for Python via Java cho phép bạn chuyển đổi các bản trình chiếu OpenDocument (ODP) sang các định dạng như PDF, HTML, TIFF, XPS, PPT và PPTX. Việc chuyển đổi ODP sử dụng cùng API như chuyển đổi PowerPoint: tải tệp nguồn bằng [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và chọn định dạng đầu ra bằng [SaveFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/saveformat/).

## **Chuyển đổi ODP sang PDF**

Theo [hướng dẫn cài đặt](/slides/vi/python-java/installation/) trước khi chạy ví dụ. Đặt một bản trình chiếu ODP có tên `pres.odp` trong thư mục làm việc. Đoạn mã sau sẽ khởi động JVM nếu cần, tải bản trình chiếu và lưu nó dưới dạng `pres.pdf`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.odp")
try:
    presentation.save("pres.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **Bản trình chiếu OpenDocument trong các ứng dụng khác nhau**

Một bản trình chiếu ODP có thể hiển thị khác nhau trong PowerPoint và LibreOffice/OpenOffice Impress vì các ứng dụng này hỗ trợ các tính năng và hành vi render khác nhau. Hãy kiểm tra các bản trình chiếu đã chuyển đổi khi bố cục của chúng phụ thuộc vào định dạng phức tạp.

Sự khác biệt tương thích có thể ảnh hưởng tới:

- Bảng, bao gồm thứ tự xếp chồng của chúng so với các hình dạng khác và hỗ trợ tô hình ảnh.
- Xoay và căn chỉnh văn bản.
- Việc áp dụng hình ảnh, gradient và mẫu vào văn bản.
- Danh sách có số thứ tự và danh sách gạch đầu dòng.

Hình ảnh dưới đây cho thấy một danh sách được tạo trong LibreOffice Impress:

![Ví dụ danh sách ODP trong LibreOffice Impress](odp-list-example.png)

Aspose.Slides lưu danh sách ODP để tương thích với LibreOffice/OpenOffice Impress.

Để biết chi tiết về khả năng tương thích tính năng, xem [hướng dẫn của Microsoft về định dạng OpenDocument Presentation](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **Câu hỏi thường gặp**

**Nếu định dạng của tệp ODP của tôi thay đổi sau khi chuyển đổi thì sao?**

ODP và PowerPoint sử dụng các mô hình trình chiếu khác nhau. Bảng, phông chữ và kiểu tô có thể hiển thị khác nhau. Kiểm tra rằng phông chữ cần thiết có sẵn, xem lại đầu ra và điều chỉnh bố cục hoặc định dạng nếu cần.

**Tôi có cần cài đặt OpenOffice hoặc LibreOffice để chuyển đổi tệp ODP không?**

Không. Aspose.Slides for Python via Java xử lý các bản trình chiếu mà không cần bất kỳ ứng dụng nào. Cần một môi trường Java tương thích và gói Python.

**Tôi có thể tùy chỉnh đầu ra PDF khi chuyển đổi bản trình chiếu ODP không?**

Có. Sử dụng [PdfOptions](https://reference.aspose.com/slides/vi/python-java/aspose.slides/pdfoptions/) để cấu hình các thiết lập xuất PDF, chẳng hạn như chất lượng ảnh và nén.

**Tôi có thể chuyển đổi bản trình chiếu ODP trên máy chủ hoặc trong container không?**

Có. Cài đặt gói Python, môi trường Java tương thích và các phông chữ cần thiết cho các bản trình chiếu của bạn trong môi trường mục tiêu. Không cần ứng dụng văn phòng nào.