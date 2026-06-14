---
title: Lưu Bài thuyết trình trong Python
linktitle: Lưu Bài thuyết trình
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
- bài thuyết trình thành luồng
- kiểu hiển thị được định trước
- Định dạng Strict Office Open XML
- chế độ Zip64
- làm mới hình thu nhỏ
- tiến độ lưu
- Python
- Aspose.Slides
description: "Khám phá cách lưu bài thuyết trình trong Python bằng Aspose.Slides—xuất ra PowerPoint hoặc OpenDocument đồng thời giữ nguyên bố cục, phông chữ và hiệu ứng."
---
## **Tổng quan**

[Mở một Bài thuyết trình trong Python](/slides/vi/python-net/open-presentation/) mô tả cách sử dụng lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) để mở một bài thuyết trình. Bài viết này giải thích cách tạo và lưu các bài thuyết trình. Lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) chứa nội dung của một bài thuyết trình. Cho dù bạn đang tạo một bài thuyết trình từ đầu hay chỉnh sửa một bài đã có, bạn sẽ muốn lưu nó khi hoàn thành. Với Aspose.Slides cho Python, bạn có thể lưu vào **tệp** hoặc **luồng**. Bài viết này giải thích các cách khác nhau để lưu một bài thuyết trình.

## **Lưu Bài thuyết trình vào Tệp**

Lưu một bài thuyết trình vào tệp bằng cách gọi phương thức `save` của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/). Truyền tên tệp và định dạng lưu vào phương thức. Ví dụ sau cho thấy cách lưu một bài thuyết trình bằng Aspose.Slides cho Python.

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation đại diện cho tệp bài thuyết trình.
with slides.Presentation() as presentation:
    
    # Thực hiện một số công việc ở đây...

    # Lưu bài thuyết trình vào tệp.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Lưu Bài thuyết trình vào Luồng**

Bạn có thể lưu một bài thuyết trình vào luồng bằng cách truyền luồng đầu ra vào phương thức `save` của lớp [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/). Một bài thuyết trình có thể được ghi vào nhiều loại luồng. Trong ví dụ dưới đây, chúng ta tạo một bài thuyết trình mới, thêm văn bản vào một hình dạng và lưu nó vào luồng.

```py
import aspose.slides as slides

# Khởi tạo lớp Presentation đại diện cho tệp bài thuyết trình.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # Lưu bài thuyết trình vào luồng.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **Lưu Bài thuyết trình với Kiểu hiển thị Được định trước**

Aspose.Slides cho Python cho phép bạn đặt chế độ xem ban đầu mà PowerPoint sử dụng khi mở bài thuyết trình được tạo thông qua lớp [ViewProperties](https://reference.aspose.com/slides/vi/python-net/aspose.slides/viewproperties/). Đặt thuộc tính `last_view` thành một giá trị từ liệt kê [ViewType](https://reference.aspose.com/slides/vi/python-net/aspose.slides/viewtype/).

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **Lưu Bài thuyết trình ở Định dạng Strict Office Open XML**

Aspose.Slides cho phép bạn lưu một bài thuyết trình ở định dạng Strict Office Open XML. Sử dụng lớp [PptxOptions](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/pptxoptions/) và đặt thuộc tính conformance khi lưu. Nếu bạn đặt `Conformance.ISO_29500_2008_STRICT`, tệp đầu ra sẽ được lưu ở định dạng Strict Office Open XML.

Ví dụ dưới tạo một bài thuyết trình và lưu nó ở định dạng Strict Office Open XML.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# Khởi tạo lớp Presentation đại diện cho tệp bài thuyết trình.
with slides.Presentation() as presentation:
    # Lưu bài thuyết trình ở định dạng Strict Office Open XML.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Lưu Bài thuyết trình ở Định dạng Office Open XML trong Chế độ Zip64**

Tệp Office Open XML là một kho lưu ZIP áp dụng giới hạn 4 GB (2^32 byte) cho kích thước chưa nén của bất kỳ tệp nào, kích thước đã nén của bất kỳ tệp nào và tổng kích thước của kho, đồng thời giới hạn số tệp trong kho là 65 535 (2^16‑1). Các phần mở rộng định dạng ZIP64 nâng các giới hạn này lên 2^64.

Thuộc tính [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) cho phép bạn chọn khi nào sử dụng phần mở rộng ZIP64 khi lưu tệp Office Open XML.

Thuộc tính này cung cấp các chế độ sau:

- `IF_NECESSARY` chỉ sử dụng phần mở rộng ZIP64 nếu bài thuyết trình vượt quá các giới hạn trên. Đây là chế độ mặc định.
- `NEVER` không bao giờ sử dụng phần mở rộng ZIP64.
- `ALWAYS` luôn luôn sử dụng phần mở rộng ZIP64.

Mã dưới đây minh họa cách lưu một bài thuyết trình dưới dạng PPTX với phần mở rộng ZIP64 được bật:

```py
pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="NOTE" color="warning" %}}
Khi bạn lưu với `Zip64Mode.NEVER`, một [PptxException](https://reference.aspose.com/slides/vi/python-net/aspose.slides/pptxexception/) sẽ được ném ra nếu bài thuyết trình không thể được lưu ở định dạng ZIP32.
{{% /alert %}}

## **Lưu Bài thuyết trình mà không Làm mới Hình thu nhỏ**

Thuộc tính [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/vi/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) kiểm soát việc tạo hình thu nhỏ khi lưu một bài thuyết trình thành PPTX:

- Nếu được đặt thành `True`, hình thu nhỏ sẽ được làm mới trong quá trình lưu. Đây là mặc định.
- Nếu được đặt thành `False`, hình thu nhỏ hiện tại sẽ được giữ nguyên. Nếu bài thuyết trình không có hình thu nhỏ, sẽ không tạo hình thu nhỏ nào.

Trong đoạn mã dưới, bài thuyết trình được lưu thành PPTX mà không làm mới hình thu nhỏ.

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
Aspose đã phát triển một ứng dụng [PowerPoint Splitter miễn phí](https://products.aspose.app/slides/vi/splitter) sử dụng API của mình. Ứng dụng cho phép bạn tách một bài thuyết trình thành nhiều tệp bằng cách lưu các slide đã chọn dưới dạng tệp PPTX hoặc PPT mới.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Có hỗ trợ “lưu nhanh” (lưu tăng dần) để chỉ ghi các thay đổi không?**

Không. Việc lưu luôn tạo ra tệp đích đầy đủ mỗi lần; “lưu nhanh” tăng dần không được hỗ trợ.

**Việc lưu cùng một thể hiện Presentation từ nhiều luồng có an toàn không?**

Không. Một thể hiện [Presentation](https://reference.aspose.com/slides/vi/python-net/aspose.slides/presentation/) không phải là thread‑safe; hãy lưu nó từ một luồng duy nhất.

**Các siêu liên kết và tệp liên kết bên ngoài sẽ xảy ra gì khi lưu?**

[Hyperlinks](/slides/vi/python-net/manage-hyperlinks/) được giữ nguyên. Các tệp liên kết bên ngoài (ví dụ video qua đường dẫn tương đối) không được sao chép tự động — hãy đảm bảo các đường dẫn tham chiếu vẫn có thể truy cập.

**Tôi có thể đặt/luên siêu dữ liệu tài liệu (Tác giả, Tiêu đề, Công ty, Ngày) không?**

Có. Các thuộc tính tài liệu tiêu chuẩn được hỗ trợ và sẽ được ghi vào tệp khi lưu.