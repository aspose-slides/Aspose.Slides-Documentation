---
title: Quản lý OLE trong Bản trình chiếu sử dụng Python
linktitle: Quản lý OLE
type: docs
weight: 40
url: /vi/python-java/manage-ole/
keywords:
- Đối tượng OLE
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
- Java
- Aspose.Slides
description: "Tối ưu hóa quản lý đối tượng OLE trong PowerPoint và tệp OpenDocument với Aspose.Slides for Python via Java. Nhúng, cập nhật và xuất nội dung OLE một cách liền mạch."
---
## **Giới thiệu**

{{% alert color="info" title="Lưu ý" %}}

OLE (Object Linking & Embedding) là công nghệ của Microsoft cho phép dữ liệu và đối tượng được tạo ra trong một ứng dụng được đặt vào ứng dụng khác thông qua liên kết hoặc nhúng.

{{% /alert %}}

Xem xét một biểu đồ được tạo trong MS Excel. Biểu đồ sau đó được đặt vào một slide PowerPoint. Biểu đồ Excel đó được coi là một đối tượng OLE.

- Một đối tượng OLE có thể hiển thị dưới dạng biểu tượng. Trong trường hợp này, khi bạn nhấp đúp vào biểu tượng, biểu đồ sẽ được mở trong ứng dụng liên kết (Excel), hoặc bạn sẽ được yêu cầu chọn một ứng dụng để mở hoặc chỉnh sửa đối tượng.
- Một đối tượng OLE có thể hiển thị nội dung thực tế của nó, chẳng hạn như nội dung của một biểu đồ. Trong trường hợp này, biểu đồ được kích hoạt trong PowerPoint, giao diện biểu đồ tải lên, và bạn có thể chỉnh sửa dữ liệu của biểu đồ ngay trong PowerPoint.

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/vi/python-java/) cho phép bạn chèn OLE Objects vào slide dưới dạng khung đối tượng OLE ([OleObjectFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/oleobjectframe/)).

## **Thêm Khung Đối Tượng OLE vào Slide**

Giả sử bạn đã tạo một biểu đồ trong Microsoft Excel và muốn nhúng nó vào một slide dưới dạng khung đối tượng OLE bằng Aspose.Slides for Python via Java, bạn có thể thực hiện như sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
1. Lấy tham chiếu của một slide thông qua chỉ số của nó.
1. Đọc tệp Excel dưới dạng mảng byte.
1. Thêm [OleObjectFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/oleobjectframe/) vào slide kèm theo mảng byte và các thông tin khác về đối tượng OLE.
1. Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Trong ví dụ bên dưới, chúng tôi đã thêm một biểu đồ từ tệp Excel vào một slide dưới dạng khung đối tượng OLE bằng cách sử dụng Aspose.Slides for Python via Java.  
**Lưu ý** rằng constructor của [OleEmbeddedDataInfo](https://reference.aspose.com/slides/vi/python-java/aspose.slides/oleembeddeddatainfo/) nhận một phần mở rộng đối tượng có thể nhúng làm tham số thứ hai. Phần mở rộng này cho phép PowerPoint giải thích đúng loại tệp và chọn ứng dụng phù hợp để mở đối tượng OLE này.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)

    # Chuẩn bị dữ liệu cho đối tượng OLE.
    file_data = Path("book.xlsx").read_bytes()
    file_data = jpype.JArray(jpype.JByte)(file_data)
    data_info = OleEmbeddedDataInfo(file_data, "xlsx")

    # Thêm khung đối tượng OLE vào slide.
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Thêm Khung Đối Tượng OLE Liên Kết**

Aspose.Slides for Python via Java cho phép bạn thêm một [OleObjectFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/oleobjectframe/) mà không nhúng dữ liệu mà chỉ với một liên kết tới tệp.

Đoạn mã Python này cho bạn thấy cách thêm một [OleObjectFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/oleobjectframe/) với tệp Excel được liên kết vào một slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Thêm khung đối tượng OLE với tệp Excel được liên kết.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Truy cập Khung Đối Tượng OLE**

Nếu một đối tượng OLE đã được nhúng trong một slide, bạn có thể dễ dàng tìm hoặc truy cập nó theo cách này:

1. Tải một bản trình chiếu có đối tượng OLE đã nhúng bằng cách tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. Lấy tham chiếu của slide bằng cách sử dụng chỉ số của nó.
3. Truy cập hình dạng OleObjectFrame. Trong ví dụ của chúng tôi, chúng tôi đã sử dụng PPTX đã tạo trước đó có chỉ một hình dạng trên slide đầu tiên. Sau đó chúng tôi kiểm tra rằng đối tượng là một OleObjectFrame. Đây là khung đối tượng OLE mong muốn để truy cập.
4. Khi đã truy cập khung đối tượng OLE, bạn có thể thực hiện bất kỳ thao tác nào trên nó.

Trong ví dụ bên dưới, một khung đối tượng OLE (đối tượng biểu đồ Excel được nhúng trong một slide) và dữ liệu tệp của nó được truy cập.

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # Lấy dữ liệu tệp đã nhúng.
        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

        # Lấy phần mở rộng của tệp đã nhúng.
        file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

        # ...
finally:
    presentation.dispose()
```

### **Truy cập Thuộc tính Khung Đối Tượng OLE Liên Kết**

Aspose.Slides cho phép bạn truy cập các thuộc tính của khung đối tượng OLE đã liên kết.

Đoạn mã Python này cho bạn thấy cách kiểm tra xem một đối tượng OLE có được liên kết không và sau đó lấy đường dẫn tới tệp đã liên kết:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.ppt")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # Kiểm tra xem đối tượng OLE có được liên kết hay không.
        if ole_frame.isObjectLink():
            # In ra đường dẫn đầy đủ tới tệp đã liên kết.
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # In ra đường dẫn tương đối tới tệp đã liên kết nếu có.
            # Chỉ các bản trình chiếu PPT mới có thể chứa đường dẫn tương đối.
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **Thay đổi Dữ liệu Đối tượng OLE**

{{% alert color="info" title="Lưu ý" %}}

Trong phần này, ví dụ mã dưới đây sử dụng [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/).

{{% /alert %}}

Nếu một đối tượng OLE đã được nhúng trong một slide, bạn có thể dễ dàng truy cập đối tượng đó và sửa đổi dữ liệu của nó theo cách này:

1. Tải một bản trình chiếu có đối tượng OLE đã nhúng bằng cách tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. Lấy tham chiếu của slide thông qua chỉ số của nó.
3. Truy cập hình dạng khung đối tượng OLE. Trong ví dụ của chúng tôi, chúng tôi đã sử dụng PPTX đã tạo trước đó có một hình dạng trên slide đầu tiên. Sau đó chúng tôi kiểm tra rằng đối tượng là một OleObjectFrame. Đây là khung đối tượng OLE mong muốn để truy cập.
4. Khi đã truy cập khung đối tượng OLE, bạn có thể thực hiện bất kỳ thao tác nào trên nó.
5. Tạo một đối tượng [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) và truy cập dữ liệu OLE.
6. Truy cập Worksheet mong muốn và sửa đổi dữ liệu.
7. Lưu Workbook đã cập nhật vào một luồng.
8. Thay đổi dữ liệu đối tượng OLE từ luồng.

Trong ví dụ bên dưới, một khung đối tượng OLE (đối tượng biểu đồ Excel được nhúng trong một slide) được truy cập và dữ liệu tệp của nó được sửa đổi để cập nhật dữ liệu biểu đồ.

```python
import jpype
import asposeslides
import asposecells

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, OleObjectFrame, Presentation, SaveFormat
from asposecells.api import Workbook, OoxmlSaveOptions
from asposecells.api import SaveFormat as CellsSaveFormat
from java.io import ByteArrayInputStream, ByteArrayOutputStream

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
        ole_stream = ByteArrayInputStream(file_data)

        # Đọc dữ liệu đối tượng OLE dưới dạng đối tượng Workbook.
        workbook = Workbook(ole_stream)

        new_ole_stream = ByteArrayOutputStream()

        # Sửa đổi dữ liệu workbook.
        cells = workbook.getWorksheets().get(0).getCells()
        cells.get(0, 4).putValue("E")
        cells.get(1, 4).putValue(jpype.JInt(12))
        cells.get(2, 4).putValue(jpype.JInt(14))
        cells.get(3, 4).putValue(jpype.JInt(15))

        file_options = OoxmlSaveOptions(CellsSaveFormat.XLSX)
        workbook.save(new_ole_stream, file_options)

        # Thay đổi dữ liệu đối tượng khung OLE.
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nhúng Các Loại Tệp Khác vào Slide**

Ngoài biểu đồ Excel, Aspose.Slides for Python via Java cho phép bạn nhúng các loại tệp khác vào slide. Ví dụ, bạn có thể chèn tệp HTML, PDF và ZIP dưới dạng đối tượng. Khi người dùng nhấp đúp vào đối tượng đã chèn, nó sẽ tự động mở trong chương trình liên quan, hoặc người dùng sẽ được yêu cầu chọn chương trình phù hợp để mở.

Đoạn mã Python này cho bạn thấy cách nhúng HTML và ZIP vào một slide:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    html_data = Path("sample.html").read_bytes()
    html_data = jpype.JArray(jpype.JByte)(html_data)
    html_data_info = OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, html_data_info)
    html_ole_frame.setObjectIcon(True)

    zip_data = Path("sample.zip").read_bytes()
    zip_data = jpype.JArray(jpype.JByte)(zip_data)
    zip_data_info = OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt Loại Tệp cho Đối Tượng Được Nhúng**

Khi làm việc với các bản trình chiếu, bạn có thể cần thay thế các đối tượng OLE cũ bằng các đối tượng mới hoặc thay thế một đối tượng OLE không được hỗ trợ bằng một đối tượng được hỗ trợ. Aspose.Slides for Python via Java cho phép bạn đặt loại tệp cho một đối tượng được nhúng, giúp bạn cập nhật dữ liệu khung OLE hoặc phần mở rộng của nó.

Đoạn mã Python này cho bạn thấy cách đặt loại tệp cho một đối tượng OLE được nhúng thành `zip`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()
    file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

    print("Current embedded file extension is: " + str(file_extension))

    # Thay đổi loại tệp thành ZIP.
    data_info = OleEmbeddedDataInfo(file_data, "zip")
    ole_frame.setEmbeddedData(data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt Hình Ảnh Icon và Tiêu Đề cho Đối Tượng Được Nhúng**

Sau khi nhúng một đối tượng OLE, một bản xem trước gồm hình ảnh icon sẽ được tự động thêm. Bản xem trước này là những gì người dùng thấy trước khi truy cập hoặc mở đối tượng OLE. Nếu bạn muốn sử dụng một hình ảnh và văn bản cụ thể làm phần tử trong bản xem trước, bạn có thể đặt hình ảnh icon và tiêu đề bằng Aspose.Slides for Python via Java.

Đoạn mã Python này cho bạn thấy cách đặt hình ảnh icon và tiêu đề cho một đối tượng được nhúng:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # Thêm hình ảnh vào tài nguyên bản trình chiếu.
    image_data = Path("image.png").read_bytes()
    image_data = jpype.JArray(jpype.JByte)(image_data)
    ole_image = presentation.getImages().addImage(image_data)

    # Đặt tiêu đề và hình ảnh cho bản xem trước OLE.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ngăn Không cho Khung Đối Tượng OLE bị Thay Đổi Kích Thước và Vị Trí**

Sau khi bạn thêm một đối tượng OLE được liên kết vào slide, khi mở bản trình chiếu trong PowerPoint, bạn có thể thấy thông báo yêu cầu cập nhật liên kết. Nhấn nút "Update Links" có thể làm thay đổi kích thước và vị trí của khung đối tượng OLE vì PowerPoint cập nhật dữ liệu từ đối tượng OLE đã liên kết và làm mới bản xem trước. Để ngăn PowerPoint hiển thị yêu cầu cập nhật dữ liệu của đối tượng, đặt phương thức [setUpdateAutomatic](https://reference.aspose.com/slides/vi/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) của lớp [OleObjectFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/oleobjectframe/) thành `False`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    ole_frame.setUpdateAutomatic(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Trích Xuất Các Tệp Được Nhúng**

Aspose.Slides for Python via Java cho phép bạn trích xuất các tệp được nhúng trong slide dưới dạng đối tượng OLE theo cách sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) chứa các đối tượng OLE bạn muốn trích xuất.
2. Duyệt qua tất cả các shape trong bản trình chiếu và truy cập các shape [OleObjectFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/oleobjectframe/).
3. Truy cập dữ liệu của các tệp được nhúng từ khung đối tượng OLE và ghi nó ra đĩa.

Đoạn mã Python này cho bạn thấy cách trích xuất các tệp được nhúng trong một slide dưới dạng đối tượng OLE:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)

        if isinstance(shape, OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
            file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

            file_path = Path(f"OLE_object_{index}.{str(file_extension).lstrip('.')}")
            file_path.write_bytes(bytes(file_data))
finally:
    presentation.dispose()
```

## **FAQ**

**Nội dung OLE có được hiển thị khi xuất slide ra PDF/hình ảnh không?**

Những gì hiển thị trên slide sẽ được xuất – biểu tượng/hình ảnh thay thế (bản xem trước). Nội dung OLE “sống” không được thực thi trong quá trình render. Nếu cần, hãy đặt hình ảnh xem trước riêng để đảm bảo hiển thị mong muốn trong PDF đã xuất.

**Làm thế nào để khóa một đối tượng OLE trên slide để người dùng không thể di chuyển/chỉnh sửa nó trong PowerPoint?**

Khóa shape: Aspose.Slides cung cấp [shape-level locks](/slides/vi/python-java/applying-protection-to-presentation/). Đây không phải là mã hoá, nhưng thực tế ngăn các chỉnh sửa và di chuyển vô tình.

**Tại sao một đối tượng Excel được liên kết lại “nhảy” hoặc thay đổi kích thước khi tôi mở bản trình chiếu?**

PowerPoint có thể làm mới bản xem trước của OLE đã liên kết. Để duy trì giao diện ổn định, hãy thực hiện theo các thực hành trong [Working Solution for Worksheet Resizing](/slides/vi/python-java/working-solution-for-worksheet-resizing/) – hoặc vừa vừa khung với phạm vi, hoặc co giãn phạm vi vào khung cố định và đặt hình ảnh thay thế phù hợp.

**Đường dẫn tương đối cho các đối tượng OLE được liên kết có được giữ lại trong định dạng PPTX không?**

Trong PPTX, thông tin “đường dẫn tương đối” không có sẵn – chỉ có đường dẫn đầy đủ. Đường dẫn tương đối chỉ tồn tại trong định dạng PPT cũ. Để di động, nên sử dụng đường dẫn tuyệt đối đáng tin cậy/URI có thể truy cập hoặc nhúng.