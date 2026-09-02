---
title: Lưu Bài Thuyết Trình bằng Python
linktitle: Lưu Bài Thuyết Trình
type: docs
weight: 80
url: /vi/python-net/save-presentation/
keywords:
- lưu PowerPoint
- lưu OpenDocument
- lưu bài thuyết trình
- lưu slide
- lưu PPT
- lưu PPTX
- lưu ODP
- bài thuyết trình thành tệp
- bài thuyết trình thành stream
- kiểu xem được định nghĩa trước
- định dạng Strict Office Open XML
- chế độ Zip64
- làm mới hình thu nhỏ
- tiến trình lưu
- Python
- Aspose.Slides
description: "Khám phá cách lưu các bài thuyết trình trong Python bằng Aspose.Slides—xuất sang PowerPoint hoặc OpenDocument trong khi giữ nguyên bố cục, phông chữ và hiệu ứng."
---
## **Tổng quan**

[Open a Presentation in Python](/slides/vi/python-net/open-presentation/) mô tả cách sử dụng lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) để mở một bài thuyết trình. Bài viết này giải thích cách tạo và lưu các bài thuyết trình. Lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) chứa nội dung của một bài thuyết trình. Cho dù bạn đang tạo một bài thuyết trình từ đầu hay chỉnh sửa một bài hiện có, bạn sẽ muốn lưu nó khi đã hoàn thành. Với Aspose.Slides for Python, bạn có thể lưu dưới dạng **file** hoặc **stream**. Bài viết này giải thích các cách khác nhau để lưu một bài thuyết trình.

## **Lưu Bài Thuyết Trình vào Tệp**

Lưu một bài thuyết trình vào tệp bằng cách gọi phương thức `save` của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/). Truyền tên tệp và định dạng lưu vào phương thức. Ví dụ sau đây cho thấy cách lưu một bài thuyết trình bằng Aspose.Slides for Python.

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
with slides.Presentation() as presentation:
    
    # Thực hiện một số công việc ở đây...

    # Lưu bài thuyết trình vào tệp.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Lưu Bài Thuyết Trình vào Stream**

Bạn có thể lưu một bài thuyết trình vào stream bằng cách truyền một stream đầu ra vào phương thức `save` của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/). Một bài thuyết trình có thể được ghi vào nhiều loại stream. Trong ví dụ dưới đây, chúng tôi tạo một bài thuyết trình mới và lưu nó vào một file stream.

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # Lưu bài thuyết trình vào stream.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **Lưu Bài Thuyết Trình với Kiểu Xem Được Định Nghĩa Trước**

Aspose.Slides for Python cho phép bạn đặt chế độ xem ban đầu mà PowerPoint sử dụng khi mở bài thuyết trình được tạo thông qua lớp [ViewProperties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/viewproperties/). Đặt thuộc tính `last_view` thành một giá trị trong enumeration [ViewType](https://reference.aspose.com/slides/vi/python-net/aspose.slides/viewtype/).

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **Lưu Bài Thuyết Trình ở Định Dạng Strict Office Open XML**

Aspose.Slides cho phép bạn lưu một bài thuyết trình ở định dạng Strict Office Open XML. Sử dụng lớp [PptxOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/pptxoptions/) và đặt thuộc tính conformance khi lưu. Nếu bạn đặt `Conformance.ISO_29500_2008_STRICT`, tệp đầu ra sẽ được lưu ở định dạng Strict Office Open XML.

Ví dụ dưới đây tạo một bài thuyết trình và lưu nó ở định dạng Strict Office Open XML.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
with slides.Presentation() as presentation:
    # Lưu bài thuyết trình ở định dạng Strict Office Open XML.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Lưu Bài Thuyết Trình ở Định Dạng Office Open XML ở Chế Độ Zip64**

Tệp Office Open XML là một archive ZIP đặt giới hạn 4 GB (2^32 byte) cho kích thước chưa nén của bất kỳ tệp nào, kích thước đã nén của bất kỳ tệp nào và tổng kích thước của archive, đồng thời giới hạn số tệp trong archive là 65.535 (2^16‑1) tệp. Các phần mở rộng định dạng ZIP64 nâng cao các giới hạn này lên 2^64.

Thuộc tính [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) cho phép bạn chọn khi nào sử dụng các phần mở rộng định dạng ZIP64 khi lưu tệp Office Open XML.

Thuộc tính này cung cấp các chế độ sau:

- `IF_NECESSARY` chỉ sử dụng các phần mở rộng ZIP64 nếu bài thuyết trình vượt quá các giới hạn trên. Đây là chế độ mặc định.
- `NEVER` không bao giờ sử dụng các phần mở rộng ZIP64.
- `ALWAYS` luôn luôn sử dụng các phần mở rộng ZIP64.

Mã sau đây minh họa cách lưu một bài thuyết trình dưới dạng tệp PPTX với các phần mở rộng ZIP64 được bật:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="NOTE" color="warning" %}}
Khi bạn lưu với `Zip64Mode.NEVER`, một [PptxException](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pptxexception/) sẽ được ném nếu bài thuyết trình không thể được lưu ở định dạng ZIP32.
{{% /alert %}}

## **Lưu Bài Thuyết Trình ở Định Dạng Office Open XML với Các Mức Nén**

Khi làm việc với các bài thuyết trình lớn, bạn có thể điều chỉnh mức nén để cân bằng kích thước tệp và thời gian xử lý. Tùy thuộc vào yêu cầu, bạn có thể ưu tiên xử lý nhanh hơn hoặc tệp đầu ra nhỏ hơn.

Aspose.Slides cung cấp thuộc tính [PptxOptions.compression_level](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/pptxoptions/compression_level/), cho phép bạn chỉ định mức nén được sử dụng khi lưu một bài thuyết trình ở định dạng Office Open XML.

Các mức nén sau đây khả dụng:

- [**NONE**](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/compressionlevel/): Không áp dụng nén. Các tệp được lưu nguyên trạng.
- [**LEVEL1**](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/compressionlevel/): Nén nhanh nhất với tỷ lệ nén thấp nhất.
- [**LEVEL2**](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/compressionlevel/): Nén nhanh hơn với tỷ lệ nén hơi tốt hơn so với **LEVEL1**.
- [**LEVEL3**](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/compressionlevel/): Cung cấp nén tốt hơn **LEVEL2** với tác động vừa phải đến thời gian xử lý.
- [**LEVEL4**](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/compressionlevel/): Cung cấp nén tốt hơn **LEVEL3**.
- [**LEVEL5**](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/compressionlevel/): Cung cấp nén cải thiện hơn **LEVEL4** với thời gian xử lý thêm.
- [**LEVEL6**](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/compressionlevel/): Nén tiêu chuẩn cung cấp sự cân bằng tốt giữa tốc độ xử lý và kích thước tệp. Đây là *mức nén mặc định*.
- [**LEVEL7**](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/compressionlevel/): Cung cấp nén tốt hơn **LEVEL6** nhưng xử lý chậm hơn.
- [**LEVEL8**](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/compressionlevel/): Cung cấp nén tốt hơn **LEVEL7**.
- [**LEVEL9**](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/compressionlevel/): Nén tối đa. Tạo kích thước tệp nhỏ nhất nhưng tốn thời gian xử lý lâu nhất.

Ví dụ sau đây minh họa cách lưu một bài thuyết trình dưới dạng tệp PPTX *không nén*:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.NONE

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_out.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

Ví dụ này cho thấy cách lưu một bài thuyết trình dưới dạng tệp PPTX với *nén tối đa*:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.LEVEL9

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_level9.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

## **Lưu Bài Thuyết Trình mà Không Làm Mới Hình Thu Nhỏ**

Thuộc tính [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) kiểm soát việc tạo hình thu nhỏ khi lưu một bài thuyết trình thành PPTX:

- Nếu đặt thành `True`, hình thu nhỏ sẽ được làm mới trong quá trình lưu. Đây là mặc định.
- Nếu đặt thành `False`, hình thu nhỏ hiện tại sẽ được giữ nguyên. Nếu bài thuyết trình không có hình thu nhỏ, sẽ không tạo hình thu nhỏ nào.

Trong đoạn mã dưới đây, bài thuyết trình được lưu dưới dạng PPTX mà không làm mới hình thu nhỏ của nó.

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="Info" color="info" %}}
Tùy chọn này giúp giảm thời gian cần thiết để lưu một bài thuyết trình ở định dạng PPTX.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Aspose đã phát triển một [ứng dụng Splitter PowerPoint miễn phí](https://products.aspose.app/slides/vi/splitter) sử dụng API của mình. Ứng dụng cho phép bạn chia một bài thuyết trình thành nhiều tệp bằng cách lưu các slide đã chọn dưới dạng tệp PPTX hoặc PPT mới.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Có hỗ trợ "lưu nhanh" (lưu tăng dần) để chỉ ghi những thay đổi không?**

Không. Khi lưu, mỗi lần tạo ra một tệp đích đầy đủ; tính năng "lưu nhanh" tăng dần không được hỗ trợ.

**Có an toàn đa luồng khi lưu cùng một instance Presentation từ nhiều luồng không?**

Không. Một instance [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) [không an toàn đa luồng](/slides/vi/python-net/multithreading/); hãy lưu từ một luồng duy nhất.

**Điều gì xảy ra với các siêu liên kết và tệp liên kết bên ngoài khi lưu?**

[Hyperlinks](/slides/vi/python-net/manage-hyperlinks/) được giữ nguyên. Các tệp liên kết bên ngoài (ví dụ: video qua đường dẫn tương đối) không được sao chép tự động — hãy đảm bảo các đường dẫn tham chiếu vẫn có thể truy cập.

**Tôi có thể đặt/lưu siêu dữ liệu tài liệu (Tác giả, Tiêu đề, Công ty, Ngày) không?**

Có. Các [thuộc tính tài liệu](/slides/vi/python-net/presentation-properties/) tiêu chuẩn được hỗ trợ và sẽ được ghi vào tệp khi lưu.