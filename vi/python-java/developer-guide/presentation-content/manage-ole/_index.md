---
title: Quản lý OLE trong Bản trình chiếu bằng Python
linktitle: Quản lý OLE
type: docs
weight: 40
url: /vi/python-java/manage-ole/
keywords:
- đối tượng OLE
- Liên kết & Nhúng đối tượng
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
description: "Tối ưu hóa việc quản lý đối tượng OLE trong PowerPoint và các tệp OpenDocument với Aspose.Slides cho Python qua Java. Nhúng, cập nhật và xuất nội dung OLE một cách liền mạch."
---
## **Giới thiệu**

{{% alert color="info" title="Note" %}}
OLE (Object Linking & Embedding) là công nghệ của Microsoft cho phép dữ liệu và đối tượng được tạo trong một ứng dụng được đặt vào ứng dụng khác thông qua liên kết hoặc nhúng.
{{% /alert %}}

Xem xét một biểu đồ được tạo trong MS Excel. Biểu đồ này sau đó được đặt vào một slide PowerPoint. Biểu đồ Excel đó được coi là một đối tượng OLE.

- Một đối tượng OLE có thể xuất hiện dưới dạng biểu tượng. Trong trường hợp này, khi bạn nhấp đúp vào biểu tượng, biểu đồ sẽ được mở trong ứng dụng liên quan (Excel), hoặc bạn sẽ được yêu cầu chọn một ứng dụng để mở hoặc chỉnh sửa đối tượng.
- Một đối tượng OLE có thể hiển thị nội dung thực tế của nó, chẳng hạn như nội dung của một biểu đồ. Trong trường hợp này, biểu đồ được kích hoạt trong PowerPoint, giao diện biểu đồ tải lên và bạn có thể chỉnh sửa dữ liệu của biểu đồ ngay trong PowerPoint.

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/vi/python-java/) cho phép bạn chèn các đối tượng OLE vào các slide dưới dạng khung đối tượng OLE ([OleObjectFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/oleobjectframe/)).

## **Thêm Khung Đối Tượng OLE Vào Slide**

Giả sử bạn đã tạo một biểu đồ trong Microsoft Excel và muốn nhúng nó vào một slide dưới dạng khung đối tượng OLE bằng Aspose.Slides for Python via Java, bạn có thể thực hiện như sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. Lấy tham chiếu tới một slide theo chỉ mục của nó.
3. Đọc tệp Excel dưới dạng mảng byte.
4. Thêm [OleObjectFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/oleobjectframe/) vào slide chứa mảng byte và các thông tin khác về đối tượng OLE.
5. Ghi bản trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Trong ví dụ bên dưới, chúng tôi đã thêm một biểu đồ từ tệp Excel vào một slide dưới dạng khung đối tượng OLE bằng Aspose.Slides for Python via Java. **Note** rằng constructor của [OleEmbeddedDataInfo](https://reference.aspose.com/slides/vi/python-java/aspose.slides/oleembeddeddatainfo/) nhận một phần mở rộng đối tượng có thể nhúng làm tham số thứ hai. Phần mở rộng này cho phép PowerPoint hiểu đúng loại tệp và chọn đúng ứng dụng để mở đối tượng OLE này.

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

Aspose.Slides for Python via Java cho phép bạn thêm một [OleObjectFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/oleobjectframe/) với liên kết tới tệp thay vì dữ liệu nhúng.

Mã Python này cho bạn thấy cách thêm một [OleObjectFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/oleobjectframe/) với tệp Excel được liên kết vào một slide:

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

## **Truy Cập Khung Đối Tượng OLE**

Nếu một đối tượng OLE đã được nhúng trong một slide, bạn có thể dễ dàng tìm hoặc truy cập nó theo cách này:

1. Tải một bản trình chiếu có đối tượng OLE được nhúng bằng cách tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. Lấy tham chiếu tới slide theo chỉ mục của nó.
3. Truy cập hình dạng [OleObjectFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/oleobjectframe/). Trong ví dụ của chúng tôi, chúng tôi đã sử dụng PPTX đã tạo trước đó mà chỉ có một hình dạng trên slide đầu tiên. Sau đó chúng tôi kiểm tra rằng đối tượng là một [OleObjectFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/oleobjectframe/). Đây là khung đối tượng OLE mong muốn để truy cập.
4. Khi đã truy cập khung đối tượng OLE, bạn có thể thực hiện bất kỳ thao tác nào trên nó.

Trong ví dụ bên dưới, một khung đối tượng OLE (đối tượng biểu đồ Excel được nhúng trong một slide) và dữ liệu tệp của nó được truy cập.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # Lấy dữ liệu tệp được nhúng.
        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

        # Lấy phần mở rộng của tệp được nhúng.
        file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

        # ...
finally:
    presentation.dispose()
```

### **Truy Cập Thuộc Tính Khung Đối Tượng OLE Liên Kết**

Aspose.Slides cho phép bạn truy cập các thuộc tính của khung đối tượng OLE được liên kết.

Mã Python này cho bạn thấy cách kiểm tra xem một đối tượng OLE có được liên kết hay không và sau đó lấy đường dẫn tới tệp được liên kết:

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
            # In ra đường dẫn đầy đủ tới tệp được liên kết.
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # In ra đường dẫn tương đối tới tệp được liên kết nếu có.
            # Chỉ các bản trình chiếu PPT mới có thể chứa đường dẫn tương đối.
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **Thay Đổi Dữ Liệu Đối Tượng OLE**

{{% alert color="info" title="Note" %}}
Trong phần này, ví dụ mã bên dưới sử dụng [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/).
{{% /alert %}}

Nếu một đối tượng OLE đã được nhúng trong một slide, bạn có thể dễ dàng truy cập đối tượng đó và sửa đổi dữ liệu của nó theo cách này:

1. Tải một bản trình chiếu có đối tượng OLE được nhúng bằng cách tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. Lấy tham chiếu tới slide theo chỉ mục của nó.
3. Truy cập hình dạng khung đối tượng OLE. Trong ví dụ của chúng tôi, chúng tôi đã sử dụng PPTX đã tạo trước đó mà có một hình dạng trên slide đầu tiên. Sau đó chúng tôi kiểm tra rằng đối tượng là một [OleObjectFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/oleobjectframe/). Đây là khung đối tượng OLE mong muốn để truy cập.
4. Khi đã truy cập khung đối tượng OLE, bạn có thể thực hiện bất kỳ thao tác nào trên nó.
5. Tạo một đối tượng [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) và truy cập dữ liệu OLE.
6. Truy cập [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) mong muốn và sửa đổi dữ liệu.
7. Lưu [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) đã cập nhật vào một luồng.
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

## **Nhúng Các Kiểu Tệp Khác Vào Slide**

Ngoài các biểu đồ Excel, Aspose.Slides for Python via Java cho phép bạn nhúng các loại tệp khác vào slide. Ví dụ, bạn có thể chèn tệp HTML, PDF và ZIP dưới dạng đối tượng. Khi người dùng nhấp đúp vào đối tượng đã chèn, nó sẽ tự động mở trong chương trình liên quan, hoặc người dùng sẽ được yêu cầu chọn một chương trình thích hợp để mở nó.

Mã Python này cho bạn thấy cách nhúng HTML và ZIP vào một slide:

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

## **Đặt Kiểu Tệp Cho Các Đối Tượng Được Nhúng**

Khi làm việc với bản trình chiếu, bạn có thể cần thay thế các đối tượng OLE cũ bằng các đối tượng mới hoặc thay thế một đối tượng OLE không được hỗ trợ bằng một đối tượng được hỗ trợ. Aspose.Slides for Python via Java cho phép bạn đặt kiểu tệp cho một đối tượng được nhúng, giúp bạn cập nhật dữ liệu khung OLE hoặc phần mở rộng của nó.

Mã Python này cho bạn thấy cách đặt kiểu tệp cho một đối tượng OLE được nhúng thành `zip`:

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

    # Thay đổi kiểu tệp thành ZIP.
    data_info = OleEmbeddedDataInfo(file_data, "zip")
    ole_frame.setEmbeddedData(data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Đặt Hình Ảnh Icon và Tiêu Đề Cho Các Đối Tượng Được Nhúng**

Sau khi một đối tượng OLE được nhúng, một bản xem trước gồm hình ảnh biểu tượng sẽ được tự động thêm. Bản xem trước này là những gì người dùng thấy trước khi truy cập hoặc mở đối tượng OLE. Nếu bạn muốn sử dụng một hình ảnh và văn bản cụ thể làm phần tử trong bản xem trước, bạn có thể đặt hình ảnh biểu tượng và tiêu đề bằng Aspose.Slides for Python via Java.

Mã Python này cho bạn thấy cách đặt hình ảnh biểu tượng và tiêu đề cho một đối tượng được nhúng:

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

    # Thêm một hình ảnh vào tài nguyên của bản trình chiếu.
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

## **Ngăn Không Cho Khung Đối Tượng OLE Bị Thay Đổi Kích Thước và Vị Trí**

Sau khi bạn thêm một đối tượng OLE được liên kết vào một slide bản trình chiếu, khi mở bản trình chiếu trong PowerPoint, bạn có thể thấy một thông báo yêu cầu cập nhật liên kết. Nhấp vào nút "Update Links" có thể làm thay đổi kích thước và vị trí của khung đối tượng OLE vì PowerPoint cập nhật dữ liệu từ đối tượng OLE được liên kết và làm mới bản xem trước của đối tượng. Để ngăn PowerPoint hiển thị thông báo cập nhật dữ liệu của đối tượng, đặt phương thức [setUpdateAutomatic](https://reference.aspose.com/slides/vi/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) của lớp [OleObjectFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/oleobjectframe/) thành `False`:

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

Aspose.Slides for Python via Java cho phép bạn trích xuất các tệp được nhúng trong slide dưới dạng đối tượng OLE theo cách này:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) chứa các đối tượng OLE bạn muốn trích xuất.
2. Duyệt qua tất cả các hình dạng trong bản trình chiếu và truy cập các hình dạng [OleObjectFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/oleobjectframe/) .
3. Truy cập dữ liệu của các tệp được nhúng từ khung đối tượng OLE và ghi chúng ra đĩa.

Mã Python này cho bạn thấy cách trích xuất các tệp được nhúng trong một slide dưới dạng đối tượng OLE:

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

**Nội dung OLE có được kết xuất khi xuất slide sang PDF/hình ảnh không?**

Những gì hiển thị trên slide sẽ được kết xuất — biểu tượng/hình ảnh thay thế (bản xem trước). Nội dung OLE "sống" không được thực thi trong quá trình kết xuất. Nếu cần, hãy đặt hình ảnh xem trước riêng của bạn để đảm bảo hiển thị như mong muốn trong PDF đã xuất.

**Làm sao tôi có thể khóa một đối tượng OLE trên slide để người dùng không thể di chuyển/chỉnh sửa nó trong PowerPoint?**

Khóa hình dạng: Aspose.Slides cung cấp [shape-level locks](/slides/vi/python-java/applying-protection-to-presentation/). Đây không phải là mã hoá, nhưng nó thực sự ngăn ngừa việc chỉnh sửa hoặc di chuyển vô ý.

**Tại sao một đối tượng Excel được liên kết "nhảy" hoặc thay đổi kích thước khi tôi mở bản trình chiếu?**

PowerPoint có thể làm mới bản xem trước của OLE được liên kết. Để có giao diện ổn định, hãy tuân theo các thực hành của [Working Solution for Worksheet Resizing](/slides/vi/python-java/working-solution-for-worksheet-resizing/) — hoặc vừa khung với phạm vi, hoặc co dãn phạm vi vào một khung cố định và đặt hình ảnh thay thế phù hợp.

**Liệu các đường dẫn tương đối cho các đối tượng OLE được liên kết có được giữ trong định dạng PPTX không?**

Trong PPTX, thông tin "đường dẫn tương đối" không có sẵn — chỉ có đường dẫn đầy đủ. Đường dẫn tương đối chỉ xuất hiện trong định dạng PPT cũ hơn. Để di động, nên sử dụng đường dẫn tuyệt đối đáng tin cậy/URI có thể truy cập hoặc nhúng.