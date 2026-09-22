---
title: Xác định Định dạng Bản trình chiếu Gốc trong Python
linktitle: Định dạng nguồn
type: docs
weight: 35
url: /vi/python-net/detect-presentation-source-format/
keywords:
- định dạng nguồn
- phát hiện định dạng bản trình chiếu
- PowerPoint
- OpenDocument
- bản trình chiếu
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Đọc định dạng gốc của một bản trình chiếu đã tải trong Python với Aspose.Slides cho Python thông qua .NET, so sánh các API phát hiện, và xử lý tệp, luồng, và các định dạng cổ."
---
## **Tổng quan**

Sau khi tải một bản trình chiếu, đọc thuộc tính chỉ đọc [Presentation.source_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/source_format/) để xác định định dạng gốc của nó. Sử dụng thuộc tính này khi các xử lý tiếp theo phụ thuộc vào định dạng mà phiên bản hiện tại được tải từ.

Định dạng nguồn khác với [SaveFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/saveformat/) được chọn cho tệp đầu ra. Lưu sang định dạng khác không làm thay đổi định dạng nguồn của phiên bản hiện có.

## **Đọc Định Dạng Nguồn Của Tệp**

Ví dụ này yêu cầu một tệp `sample.pptx` đã tồn tại. Nó tải tệp và chọn chính sách xử lý ứng dụng bằng cách sử dụng [Presentation.source_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/source_format/), thay vì dựa vào tên tệp. Thay đổi đường dẫn đầu vào để thử các định dạng khác. Ví dụ in ra chính sách đã chọn; hãy thay thế các thông báo bằng logic ứng dụng của bạn.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    source_format = presentation.source_format
    if source_format in (slides.SourceFormat.PPT, slides.SourceFormat.PPS, slides.SourceFormat.POT):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == slides.SourceFormat.PPTX:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for {source_format.name}.")
```

## **Nhận Diện Các Giá Trị Hỗ Trợ**

Kiểu liệt kê [SourceFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sourceformat/) phân biệt các định dạng bản trình chiếu sau. Các phần mở rộng dưới đây là các phần mở rộng thông thường, không phải là việc tái tạo lại tên tệp gốc.

| Giá trị SourceFormat | Phần mở rộng | Định dạng |
| --- | --- | --- |
| `PPT` | `.ppt` | Bản trình chiếu PowerPoint 97–2003 |
| `PPTX` | `.pptx` | Bản trình chiếu Office Open XML |
| `PPTM` | `.pptm` | Bản trình chiếu Office Open XML có macro |
| `PPS` | `.pps` | Trình chiếu PowerPoint 97–2003 |
| `PPSX` | `.ppsx` | Trình chiếu Office Open XML |
| `PPSM` | `.ppsm` | Trình chiếu Office Open XML có macro |
| `POT` | `.pot` | Mẫu PowerPoint 97–2003 |
| `POTX` | `.potx` | Mẫu Office Open XML |
| `POTM` | `.potm` | Mẫu Office Open XML có macro |
| `ODP` | `.odp` | Bản trình chiếu OpenDocument |
| `OTP` | `.otp` | Mẫu bản trình chiếu OpenDocument |
| `FODP` | `.fodp` | Bản trình chiếu ODF XML phẳng |
| `XML` | `.xml` | Bản trình chiếu PowerPoint XML |

## **Đọc Định Dạng Nguồn Từ Luồng**

Ví dụ này yêu cầu một tệp `sample.pps` đã tồn tại. Đọc các byte của nó vào một luồng bộ nhớ mô phỏng đầu vào nhận được mà không có tên tệp, chẳng hạn như giá trị trong cơ sở dữ liệu hoặc một mảng byte được tải lên. Hàm tạo [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) chỉ nhận luồng.

```python
import io
import aspose.slides as slides

with open("sample.pps", "rb") as input_file:
    data = input_file.read()

with io.BytesIO(data) as stream:
    with slides.Presentation(stream) as presentation:
        print(f"Source format: {presentation.source_format.name}")
```

PPT, PPS và POT sử dụng cùng một định dạng nhị phân cơ bản. Khi tải bằng đường dẫn tệp, phần mở rộng có thể giúp phân biệt giữa trình chiếu hoặc mẫu. Khi không có tên tệp, nội dung PPS và POT cũ có thể được báo là `SourceFormat.PPT`; ví dụ PPS ở trên báo `PPT`.

Nếu ứng dụng của bạn cần giữ sự phân biệt này, hãy lưu lại tên tệp gốc hoặc siêu dữ liệu phụ loại riêng biệt. Phần mở rộng là một gợi ý hữu ích cho các phụ loại cũ này, nhưng không nên là cơ sở duy nhất để xác định nội dung bản trình chiếu bất kỳ.

## **So Sánh Phát Hiện Trước và Sau Khi Tải**

Sử dụng [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationfactory/get_presentation_info/) và [PresentationInfo.load_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationinfo/load_format/) khi bạn cần kiểm tra một tệp trước khi tải toàn bộ mô hình đối tượng bản trình chiếu. Sử dụng [Presentation.source_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/source_format/) khi phiên bản đã tồn tại.

Ví dụ này yêu cầu `sample.pptx` và in ra `PPTX` cho cả hai kiểm tra. Trong môi trường thực tế, chọn API phù hợp với giai đoạn xử lý của bạn; một bản trình chiếu đã được tải không cần kiểm tra lại chỉ để lấy định dạng nguồn.

```python
import aspose.slides as slides

path = "sample.pptx"
information = slides.PresentationFactory.instance.get_presentation_info(path)
print(f"Before loading: {information.load_format.name}")

with slides.Presentation(path) as presentation:
    print(f"After loading: {presentation.source_format.name}")
```

Kết quả có các kiểu liệt kê khác nhau: [LoadFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/loadformat/) và [SourceFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sourceformat/). Đừng so sánh chúng bằng cách ép kiểu giá trị số hoặc cho rằng mỗi định dạng có kết quả phát hiện giống nhau. Trong kiểm tra lưu‑và‑mở lại được mô tả bên dưới, PowerPoint XML được báo là `LoadFormat.UNKNOWN` trước khi tải và `SourceFormat.XML` sau khi tải.

## **Giữ Định Dạng Nguồn và Đầu Ra Riêng Biệt**

Ví dụ này yêu cầu `sample.pptx` và ghi `converted.odp`. Nó in ra `PPTX` cả trước và sau khi lưu phiên bản gốc. Chỉ bản mới được tải từ đầu ra ODP mới báo `ODP`.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print(f"Before saving: {presentation.source_format.name}")

    presentation.save("converted.odp", slides.export.SaveFormat.ODP)
    print(f"After saving: {presentation.source_format.name}")

with slides.Presentation("converted.odp") as reopened:
    print(f"Reopened output: {reopened.source_format.name}")
```

Một bản trình chiếu được tạo mới bằng `slides.Presentation()` báo `SourceFormat.PPTX`. Nó không có tệp đầu vào: đây là giá trị mặc định cho một phiên bản mới tạo, không phải bằng chứng rằng đã tải một tệp PPTX. Theo dõi xem ứng dụng của bạn đã tạo hay đã tải phiên bản riêng biệt nếu sự khác biệt này quan trọng.

## **Ánh Xạ Định Dạng Nguồn Thành Phần Mở Rộng**

Ví dụ sau yêu cầu `sample.pptx`. Nó ánh xạ mỗi giá trị [SourceFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides/sourceformat/) hiện được hỗ trợ sang một phần mở rộng thông thường, mà không phân tích tên tệp đầu vào. Phương án dự phòng tránh việc gán phần mở rộng một cách im lặng cho giá trị không nhận diện được.

```python
import aspose.slides as slides

extensions = {
    slides.SourceFormat.PPT: ".ppt",
    slides.SourceFormat.PPTX: ".pptx",
    slides.SourceFormat.PPTM: ".pptm",
    slides.SourceFormat.PPS: ".pps",
    slides.SourceFormat.PPSX: ".ppsx",
    slides.SourceFormat.PPSM: ".ppsm",
    slides.SourceFormat.POT: ".pot",
    slides.SourceFormat.POTX: ".potx",
    slides.SourceFormat.POTM: ".potm",
    slides.SourceFormat.ODP: ".odp",
    slides.SourceFormat.OTP: ".otp",
    slides.SourceFormat.FODP: ".fodp",
    slides.SourceFormat.XML: ".xml",
}

with slides.Presentation("sample.pptx") as presentation:
    extension = extensions.get(presentation.source_format)
    print(extension if extension is not None else "No extension mapping is available.")
```

Ánh xạ này không chuyển đổi tệp hoặc khôi phục lại phụ loại PPS/POT cũ bị mất khi tải từ luồng. Đối với việc lưu thực tế, hãy chọn một [SaveFormat](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/saveformat/) một cách rõ ràng, hoặc sử dụng quy trình chuyển đổi được mô tả trong [Save Presentations in Their Original Format](/slides/vi/python-net/save-presentation/#save-presentations-in-their-original-format).

## **Xác Thực Định Dạng Bằng Cách Lưu và Mở Lại**

Ví dụ tự chứa này tạo một bản trình chiếu và ghi ba tệp trong thư mục làm việc, ghi đè các tệp cùng tên. Nó mở lại mỗi đầu ra vừa bằng đường dẫn vừa qua một luồng bộ nhớ. Đối với PPTX và ODP, cả hai cách đều báo định dạng đã lưu. Đối với PPS, tải bằng đường dẫn báo `PPS`, trong khi tải cùng các byte mà không có tên tệp báo `PPT`.

```python
import io
import aspose.slides as slides

formats = [slides.export.SaveFormat.PPTX, slides.export.SaveFormat.ODP, slides.export.SaveFormat.PPS]

with slides.Presentation() as presentation:
    for output_format in formats:
        path = f"roundtrip.{output_format.name.lower()}"
        presentation.save(path, output_format)

        with open(path, "rb") as input_file:
            data = input_file.read()

        with slides.Presentation(path) as from_file:
            with io.BytesIO(data) as stream:
                with slides.Presentation(stream) as from_stream:
                    print(f"{output_format.name}: file={from_file.source_format.name}, stream={from_stream.source_format.name}")
```

Kiểm tra tương tự với tất cả các định dạng đã liệt kê ở trên cho các bản trình chiếu được tạo có phần mở rộng tương ứng cho ra các kết quả sau:

| Định dạng đã lưu | SourceFormat từ đường dẫn tệp | SourceFormat từ luồng không tên |
| --- | --- | --- |
| PPT | `PPT` | `PPT` |
| PPTX, PPTM | `PPTX`, `PPTM` tương ứng | Giống như đường dẫn tệp |
| PPS | `PPS` | `PPT` |
| PPSX, PPSM | `PPSX`, `PPSM` tương ứng | Giống như đường dẫn tệp |
| POT | `POT` | `PPT` |
| POTX, POTM | `POTX`, `POTM` tương ứng | Giống như đường dẫn tệp |
| ODP, OTP | `ODP`, `OTP` tương ứng | Giống như đường dẫn tệp |
| FODP | `FODP` | `FODP` |
| PowerPoint XML | `XML` | `XML` |

Trong các kiểm tra này, việc chuẩn hoá duy nhất của định dạng nguồn là PPS/POT thành `PPT` cho các luồng không tên. Bảng mô tả cách xác định định dạng, không phải việc bảo toàn mọi tính năng bản trình chiếu trong quá trình chuyển đổi.

## **Câu Hỏi Thường Gặp**

**Việc lưu sang ODP có thay đổi định dạng nguồn của bản trình chiếu đã được tải từ PPTX không?**

Không. Phiên bản hiện có vẫn báo `PPTX`. Phiên bản được tải từ tệp ODP đã lưu sẽ báo `ODP`.

**Luồng có luôn phân biệt được bản trình chiếu cổ, trình chiếu và mẫu không?**

Không. PPT, PPS và POT chia sẻ cùng một định dạng nhị phân. Giữ lại tên tệp hoặc siêu dữ liệu phụ loại riêng khi cần phân biệt này.

**Nên dùng API nào nếu bản trình chiếu đã được tải?**

Đọc [Presentation.source_format](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/source_format/). Sử dụng [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentationfactory/get_presentation_info/) để kiểm tra trước khi tải.