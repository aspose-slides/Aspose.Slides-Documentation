---
title: Quản lý OLE trong Bản trình chiếu bằng Python
linktitle: Quản lý OLE
type: docs
weight: 40
url: /vi/python-net/manage-ole/
keywords:
- đối tượng OLE
- Liên kết & Nhúng Đối tượng
- thêm OLE
- nhúng OLE
- thêm đối tượng
- nhúng đối tượng
- thêm tệp
- nhúng tệp
- đối tượng liên kết
- tệp liên kết
- thay đổi OLE
- biểu tượng OLE
- tiêu đề OLE
- trích xuất OLE
- trích xuất đối tượng
- trích xuất tệp
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Tối ưu hóa việc quản lý đối tượng OLE trong các tệp PowerPoint và OpenDocument với Aspose.Slides cho Python qua .NET. Nhúng, cập nhật và xuất nội dung OLE một cách liền mạch."
---
## **Giới thiệu**

{{% alert color="info" title="Note" %}}

**OLE (Object Linking & Embedding)** là công nghệ của Microsoft cho phép dữ liệu và đối tượng được tạo trong một ứng dụng được liên kết hoặc nhúng vào ứng dụng khác.

{{% /alert %}}

Ví dụ, một biểu đồ được tạo trong Microsoft Excel và đặt trên một slide PowerPoint là một đối tượng OLE.

- Một đối tượng OLE có thể hiển thị dưới dạng biểu tượng. Nhấp đúp vào biểu tượng sẽ mở đối tượng trong ứng dụng liên kết (ví dụ: Excel) hoặc yêu cầu bạn chọn ứng dụng để mở hoặc chỉnh sửa.
- Một đối tượng OLE có thể hiển thị nội dung của nó (ví dụ, một biểu đồ). Trong trường hợp này, PowerPoint kích hoạt đối tượng được nhúng, tải giao diện biểu đồ và cho phép bạn chỉnh sửa dữ liệu biểu đồ ngay trong PowerPoint.

Aspose.Slides for Python cho phép bạn chèn các đối tượng OLE vào các slide dưới dạng khung đối tượng OLE ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **Thêm Đối Tượng OLE vào Slides**

Nếu bạn đã tạo một biểu đồ trong Microsoft Excel và muốn nhúng nó vào một slide dưới dạng khung đối tượng OLE bằng Aspose.Slides for Python, hãy làm theo các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Lấy tham chiếu tới slide theo chỉ mục của nó.
1. Đọc tệp Excel vào một mảng byte.
1. Thêm một [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) vào slide, cung cấp mảng byte và các chi tiết đối tượng OLE khác.
1. Lưu bản trình chiếu đã chỉnh sửa thành tệp PPTX.

Trong ví dụ dưới đây, một biểu đồ từ tệp Excel được nhúng vào một slide dưới dạng [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).

**Lưu ý:** Constructor của [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) nhận phần mở rộng tệp của đối tượng có thể nhúng làm tham số thứ hai. PowerPoint sử dụng phần mở rộng này để xác định loại tệp và chọn ứng dụng phù hợp để mở đối tượng OLE.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # Chuẩn bị dữ liệu cho đối tượng OLE.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # Thêm khung đối tượng OLE vào slide.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Thêm Đối Tượng OLE Liên Kết**

Aspose.Slides for Python cho phép bạn thêm một [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) liên kết đến một tệp thay vì nhúng dữ liệu của nó.

Ví dụ Python dưới đây cho thấy cách thêm một [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) liên kết tới một tệp Excel trên slide:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Thêm khung đối tượng OLE với tệp Excel được liên kết.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Truy Cập Đối Tượng OLE**

Nếu một đối tượng OLE đã được nhúng trong slide, bạn có thể truy cập nó như sau:

1. Tải bản trình chiếu chứa đối tượng OLE đã nhúng bằng cách tạo một thể hiện của lớp Presentation.
1. Lấy tham chiếu tới slide theo chỉ mục của nó.
1. Truy cập hình dạng OleObjectFrame.
1. Khi đã có khung đối tượng OLE, thực hiện bất kỳ thao tác cần thiết nào trên nó.

Ví dụ dưới đây truy cập khung đối tượng OLE—một biểu đồ Excel đã nhúng—và lấy dữ liệu tệp của nó. Trong ví dụ này, chúng tôi sử dụng một tệp PPTX có một hình dạng duy nhất trên slide đầu tiên.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Lấy dữ liệu tệp được nhúng.
        file_data = ole_frame.embedded_data.embedded_file_data

        # Lấy phần mở rộng của tệp được nhúng.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **Truy Cập Thuộc Tính Đối Tượng OLE Liên Kết**

Aspose.Slides cho phép bạn truy cập các thuộc tính của khung đối tượng OLE liên kết.

Ví dụ Python dưới đây kiểm tra xem một đối tượng OLE có được liên kết không và, nếu có, lấy đường dẫn tới tệp được liên kết:

```py
import aspose.slides as slides

with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Kiểm tra xem đối tượng OLE có được liên kết hay không.
        if ole_frame.is_object_link:
            # In ra đường dẫn đầy đủ tới tệp được liên kết.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # In ra đường dẫn tương đối tới tệp được liên kết, nếu có.
            # Chỉ các bản trình chiếu .ppt mới có thể chứa đường dẫn tương đối.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **Thay Đổi Dữ Liệu Đối Tượng OLE**

{{% alert color="info" title="Note" %}}

Trong phần này, ví dụ mã dưới đây sử dụng [Aspose.Cells for Python via .NET](https://docs.aspose.com/cells/python-net/).

{{% /alert %}}

Nếu một đối tượng OLE đã được nhúng trong slide, bạn có thể truy cập và sửa đổi dữ liệu của nó như sau:

1. Tải bản trình chiếu bằng cách tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Lấy slide mục tiêu theo chỉ mục của nó.
1. Truy cập hình dạng [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).
1. Khi đã có khung đối tượng OLE, thực hiện các thao tác yêu cầu trên nó.
1. Tạo một đối tượng `Workbook` và đọc dữ liệu OLE.
1. Mở `Worksheet` mong muốn và chỉnh sửa dữ liệu.
1. Lưu `Workbook` đã cập nhật vào một luồng.
1. Thay thế dữ liệu của đối tượng OLE bằng luồng đó.

Trong ví dụ dưới đây, một khung đối tượng OLE (một biểu đồ Excel đã nhúng) được truy cập và dữ liệu tệp của nó được sửa đổi để cập nhật biểu đồ. Mẫu này sử dụng một tệp PPTX đã tạo trước có một hình dạng duy nhất trên slide đầu tiên.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        with io.BytesIO(ole_frame.embedded_data.embedded_file_data) as ole_stream:
            # Đọc dữ liệu đối tượng OLE dưới dạng đối tượng Workbook.
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # Sửa đổi dữ liệu workbook.
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # Thay đổi dữ liệu đối tượng khung OLE.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Nhúng Tệp vào Slides**

Ngoài biểu đồ Excel, Aspose.Slides for Python cho phép bạn nhúng các loại tệp khác vào slide. Ví dụ, bạn có thể chèn các tệp HTML, PDF và ZIP dưới dạng đối tượng. Khi người dùng nhấp đúp vào một đối tượng đã chèn, nó sẽ tự động mở trong ứng dụng liên kết, hoặc người dùng sẽ được yêu cầu chọn chương trình phù hợp.

Đoạn mã Python dưới đây cho thấy cách nhúng tệp HTML và ZIP vào một slide:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.html", "rb") as html_stream:
        html_data = html_stream.read()

    html_data_info = slides.dom.ole.OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.shapes.add_ole_object_frame(150, 120, 50, 50, html_data_info)
    html_ole_frame.is_object_icon = True

    with open("sample.zip", "rb") as zip_stream:
        zip_data = zip_stream.read()

    zip_data_info = slides.dom.ole.OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.shapes.add_ole_object_frame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt Loại Tệp cho Đối Tượng Được Nhúng**

Khi làm việc với bản trình chiếu, bạn có thể cần thay thế các đối tượng OLE cũ bằng các đối tượng mới hoặc hoán đổi một đối tượng OLE không được hỗ trợ sang một đối tượng được hỗ trợ. Aspose.Slides for Python cho phép bạn đặt loại tệp của đối tượng được nhúng, cho phép cập nhật dữ liệu khung OLE hoặc phần mở rộng tệp của nó.

Đoạn mã Python dưới đây cho thấy cách đặt loại tệp của đối tượng OLE đã nhúng thành `zip`:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # Thay đổi loại tệp thành ZIP.
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Đặt Hình Ảnh Biểu Tượng và Tiêu Đề cho Đối Tượng Được Nhúng**

Sau khi bạn nhúng một đối tượng OLE, một bản xem trước dựa trên biểu tượng sẽ được thêm tự động. Bản xem trước này là những gì người dùng thấy trước khi truy cập hoặc mở đối tượng OLE. Nếu bạn muốn sử dụng hình ảnh và văn bản cụ thể trong bản xem trước, bạn có thể đặt hình ảnh biểu tượng và tiêu đề bằng Aspose.Slides for Python.

Đoạn mã Python dưới đây cho thấy cách đặt hình ảnh biểu tượng và tiêu đề cho một đối tượng đã nhúng:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Thêm hình ảnh vào tài nguyên bản trình chiếu.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # Đặt tiêu đề và hình ảnh cho bản xem trước OLE.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Ngăn Không Cho Khung Đối Tượng OLE Bị Thay Đổi Kích Thước và Vị Trí**

Sau khi bạn thêm một đối tượng OLE liên kết vào slide, PowerPoint có thể yêu cầu bạn cập nhật liên kết khi mở bản trình chiếu. Việc chọn “Cập nhật Liên kết” có thể làm thay đổi kích thước và vị trí của khung đối tượng OLE vì PowerPoint làm mới bản xem trước với dữ liệu từ đối tượng được liên kết. Để ngăn PowerPoint yêu cầu cập nhật dữ liệu của đối tượng, đặt thuộc tính `update_automatic` của lớp [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) thành `False`:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    ole_frame.update_automatic = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Trích Xuất Tệp Được Nhúng**

Aspose.Slides for Python cho phép bạn trích xuất các tệp được nhúng trong slide dưới dạng đối tượng OLE như sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) chứa các đối tượng OLE bạn muốn trích xuất.
1. Duyệt qua tất cả các hình dạng trong bản trình chiếu và tìm các hình dạng OLEObjectFrame.
1. Lấy dữ liệu tệp đã nhúng từ mỗi [OLEObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) và ghi nó ra đĩa.

Đoạn mã Python dưới đây cho thấy cách trích xuất các tệp được nhúng trong một slide dưới dạng đối tượng OLE:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for index, shape in enumerate(slide.shapes):
        if isinstance(shape, slides.OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.embedded_data.embedded_file_data
            file_extension = ole_frame.embedded_data.embedded_file_extension

            file_path = f"OLE_object_{index}{file_extension}"
            with open(file_path, 'wb') as file_stream:
                file_stream.write(file_data)
```

## **FAQ**

**Nội dung OLE có được hiển thị khi xuất slide sang PDF/hình ảnh không?**

Những gì hiển thị trên slide sẽ được render—biểu tượng/hình ảnh thay thế (xem trước). Nội dung OLE “sống” không được thực thi trong quá trình render. Nếu cần, thiết lập hình ảnh xem trước riêng của bạn để đảm bảo hiển thị như mong muốn trong PDF đã xuất.

Để cũng bảo tồn tệp được nhúng dưới dạng tệp đính kèm PDF, đặt [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) thành `True`. Tùy chọn này mặc định bị tắt. Xem ví dụ và hướng dẫn kiểm tra tệp đính kèm tại [Bảo tồn tệp OLE được nhúng dưới dạng tệp đính kèm PDF](/slides/vi/python-net/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Làm sao tôi có thể khóa một đối tượng OLE trên slide để người dùng không thể di chuyển/chỉnh sửa nó trong PowerPoint?**

Khóa hình dạng: Aspose.Slides cung cấp [khóa ở mức hình dạng](/slides/vi/python-net/applying-protection-to-presentation/). Đây không phải là mã hóa, nhưng thực sự ngăn ngừa các chỉnh sửa và di chuyển vô tình.

**Tại sao một đối tượng Excel được liên kết “nhảy” hoặc thay đổi kích thước khi tôi mở bản trình chiếu?**

PowerPoint có thể làm mới bản xem trước của OLE liên kết. Để có giao diện ổn định, hãy tuân theo các thực tiễn của [Giải pháp làm việc cho việc thay đổi kích thước Worksheet](/slides/vi/python-net/working-solution-for-worksheet-resizing/)—hoặc vừa khung với phạm vi, hoặc tỷ lệ phạm vi vào khung cố định và đặt hình ảnh thay thế thích hợp.

**Đường dẫn tương đối cho các đối tượng OLE liên kết có được giữ lại trong định dạng PPTX không?**

Trong PPTX, thông tin “đường dẫn tương đối” không có sẵn—chỉ có đường dẫn đầy đủ. Đường dẫn tương đối chỉ xuất hiện trong định dạng PPT cũ hơn. Để đảm bảo khả năng di động, nên sử dụng các đường dẫn tuyệt đối đáng tin cậy/URI có thể truy cập hoặc nhúng.