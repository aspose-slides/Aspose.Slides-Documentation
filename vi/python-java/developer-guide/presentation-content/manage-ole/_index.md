---
title: Quản lý OLE trong bản trình chiếu bằng Python
linktitle: Quản lý OLE
type: docs
weight: 40
url: /vi/python-java/manage-ole/
keywords:
- Đối tượng OLE
- Liên kết & Nhúng Đối tượng
- Thêm OLE
- Nhúng OLE
- Thêm đối tượng
- Nhúng đối tượng
- Thêm tệp
- Nhúng tệp
- Đối tượng liên kết
- Tệp liên kết
- Thay đổi OLE
- Biểu tượng OLE
- Tiêu đề OLE
- Trích xuất OLE
- Trích xuất đối tượng
- Trích xuất tệp
- PowerPoint
- Bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Tối ưu hóa việc quản lý đối tượng OLE trong PowerPoint và các tệp OpenDocument với Aspose.Slides cho Python qua Java. Nhúng, cập nhật và xuất nội dung OLE một cách liền mạch."
---
## **Giới thiệu**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) là công nghệ của Microsoft cho phép dữ liệu và đối tượng được tạo trong một ứng dụng được đặt vào một ứng dụng khác thông qua việc liên kết hoặc nhúng.

{{% /alert %}}

Xem xét một biểu đồ được tạo trong MS Excel. Biểu đồ này sau đó được đặt vào một slide PowerPoint. Biểu đồ Excel đó được xem là một đối tượng OLE.

- Một đối tượng OLE có thể hiển thị dưới dạng biểu tượng. Trong trường hợp này, khi bạn nhấp đúp vào biểu tượng, biểu đồ sẽ mở trong ứng dụng liên kết (Excel), hoặc bạn sẽ được yêu cầu chọn một ứng dụng để mở hoặc chỉnh sửa đối tượng.
- Một đối tượng OLE có thể hiển thị nội dung thực tế của nó, chẳng hạn như nội dung của một biểu đồ. Trong trường hợp này, biểu đồ được kích hoạt trong PowerPoint, giao diện biểu đồ tải lên và bạn có thể chỉnh sửa dữ liệu của biểu đồ ngay trong PowerPoint.

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/python-java/) cho phép bạn chèn các đối tượng OLE vào các slide dưới dạng khung đối tượng OLE ([OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/)).

## **Thêm Khung Đối Tượng OLE vào Bản Trình Chiếu**

Giả sử bạn đã tạo một biểu đồ trong Microsoft Excel và muốn nhúng nó vào một slide dưới dạng khung đối tượng OLE bằng Aspose.Slides for Python via Java, bạn có thể thực hiện như sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Lấy một tham chiếu đến slide theo chỉ số của nó.
3. Đọc tệp Excel dưới dạng mảng byte.
4. Thêm [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) vào slide kèm theo mảng byte và các thông tin khác về đối tượng OLE.
5. Ghi bản trình chiếu đã sửa đổi thành tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một biểu đồ từ tệp Excel vào slide dưới dạng khung đối tượng OLE bằng Aspose.Slides for Python via Java.
**Lưu ý** rằng constructor của [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/) nhận phần mở rộng đối tượng có thể nhúng làm tham số thứ hai. Phần mở rộng này cho phép PowerPoint hiểu đúng loại tệp và chọn ứng dụng phù hợp để mở đối tượng OLE này.

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

Aspose.Slides for Python via Java cho phép bạn thêm một [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) có liên kết tới tệp thay vì dữ liệu được nhúng.

Đoạn mã Python sau cho bạn thấy cách thêm một [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) với tệp Excel được liên kết vào một slide:

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

Nếu một đối tượng OLE đã được nhúng trong một slide, bạn có thể dễ dàng tìm hoặc truy cập nó theo cách sau:

1. Tải một bản trình chiếu có đối tượng OLE được nhúng bằng cách tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Lấy một tham chiếu đến slide theo chỉ số của nó.
3. Truy cập shape [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/). 
   Trong ví dụ của chúng tôi, chúng tôi sử dụng PPTX đã tạo trước có chỉ một shape trên slide đầu tiên. Sau đó chúng tôi kiểm tra rằng đối tượng là một [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/). Đây là khung OLE mong muốn để truy cập.
4. Khi đã truy cập được khung đối tượng OLE, bạn có thể thực hiện bất kỳ thao tác nào trên nó.

Trong ví dụ dưới đây, một khung đối tượng OLE (đối tượng biểu đồ Excel được nhúng trong slide) và dữ liệu tệp của nó được truy cập.

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

### **Truy cập Thuộc tính Khung Đối Tượng OLE Liên Kết**

Aspose.Slides cho phép bạn truy cập các thuộc tính của khung đối tượng OLE liên kết.

Đoạn mã Python sau cho bạn thấy cách kiểm tra xem một đối tượng OLE có được liên kết hay không và sau đó lấy đường dẫn tới tệp được liên kết:

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

        # Kiểm tra xem đối tượng OLE có được liên kết không.
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

## **Thay đổi Dữ liệu Đối Tượng OLE**

{{% alert color="info" title="Note" %}}

Trong phần này, đoạn mã mẫu bên dưới sử dụng [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/).

{{% /alert %}}

Nếu một đối tượng OLE đã được nhúng trong một slide, bạn có thể dễ dàng truy cập đối tượng đó và sửa đổi dữ liệu của nó theo cách sau:

1. Tải một bản trình chiếu có đối tượng OLE được nhúng bằng cách tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Lấy một tham chiếu đến slide theo chỉ số của nó.
3. Truy cập shape khung đối tượng OLE. 
   Trong ví dụ của chúng tôi, chúng tôi sử dụng PPTX đã tạo trước có một shape trên slide đầu tiên. Sau đó chúng tôi kiểm tra rằng đối tượng là một [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/). Đây là khung OLE mong muốn để truy cập.
4. Khi đã truy cập được khung đối tượng OLE, bạn có thể thực hiện bất kỳ thao tác nào trên nó.
5. Tạo một đối tượng [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) và truy cập dữ liệu OLE.
6. Truy cập [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) mong muốn và sửa đổi dữ liệu.
7. Lưu [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) đã cập nhật vào một luồng.
8. Thay đổi dữ liệu đối tượng OLE từ luồng.

Trong ví dụ dưới đây, một khung đối tượng OLE (đối tượng biểu đồ Excel được nhúng trong slide) được truy cập và dữ liệu tệp của nó được sửa đổi để cập nhật dữ liệu biểu đồ.

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

## **Nhúng Các Loại Tập Tin Khác vào Bản Trình Chiếu**

Ngoài biểu đồ Excel, Aspose.Slides for Python via Java cho phép bạn nhúng các loại tệp khác vào slide. Ví dụ, bạn có thể chèn HTML, PDF và ZIP làm đối tượng. Khi người dùng nhấp đúp vào đối tượng đã chèn, nó sẽ tự động mở trong chương trình liên quan, hoặc người dùng sẽ được yêu cầu chọn một chương trình phù hợp để mở.

Đoạn mã Python sau cho bạn thấy cách nhúng HTML và ZIP vào một slide:

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

## **Đặt Loại Tập Tin cho Đối Tượng Được Nhúng**

Khi làm việc với bản trình chiếu, bạn có thể cần thay thế các đối tượng OLE cũ bằng các đối tượng mới hoặc thay thế một đối tượng OLE không được hỗ trợ bằng một đối tượng được hỗ trợ. Aspose.Slides for Python via Java cho phép bạn đặt loại tệp cho một đối tượng được nhúng, giúp bạn cập nhật dữ liệu khung OLE hoặc phần mở rộng của nó.

Đoạn mã Python sau cho bạn thấy cách đặt loại tệp cho một đối tượng OLE được nhúng thành `zip`:

```python
import jpace
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

## **Đặt Hình Ảnh Biểu Tượng và Tiêu Đề cho Đối Tượng Được Nhúng**

Sau khi một đối tượng OLE được nhúng, một bản xem trước gồm hình ảnh biểu tượng được thêm tự động. Bản xem trước này là những gì người dùng thấy trước khi truy cập hoặc mở đối tượng OLE. Nếu bạn muốn sử dụng một hình ảnh và văn bản cụ thể làm yếu tố trong bản xem trước, bạn có thể đặt hình ảnh biểu tượng và tiêu đề bằng Aspose.Slides for Python via Java.

Đoạn mã Python sau cho bạn thấy cách đặt hình ảnh biểu tượng và tiêu đề cho một đối tượng đã nhúng:

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

    # Thêm hình ảnh vào tài nguyên của bản trình chiếu.
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

Sau khi bạn thêm một đối tượng OLE liên kết vào slide bản trình chiếu, khi mở bản trình chiếu trong PowerPoint, bạn có thể thấy một thông báo yêu cầu cập nhật liên kết. Nhấn nút “Update Links” có thể thay đổi kích thước và vị trí của khung đối tượng OLE vì PowerPoint cập nhật dữ liệu từ đối tượng OLE liên kết và làm mới bản xem trước. Để ngăn PowerPoint hỏi cập nhật dữ liệu của đối tượng, gọi phương thức [setUpdateAutomatic](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) của lớp [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) với `False`:

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

## **Trích xuất Các Tập Tin Đã Nhúng**

Aspose.Slides for Python via Java cho phép bạn trích xuất các tệp được nhúng trong slide dưới dạng đối tượng OLE theo cách sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) chứa các đối tượng OLE bạn muốn trích xuất.
2. Duyệt qua tất cả các shape trong bản trình chiếu và truy cập các shape [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/).
3. Truy cập dữ liệu của các tệp đã nhúng từ các khung đối tượng OLE và ghi chúng ra đĩa.

Đoạn mã Python sau cho bạn thấy cách trích xuất các tệp được nhúng trong một slide dưới dạng đối tượng OLE:

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

**Nội dung OLE có được hiển thị khi xuất slide sang PDF/hình ảnh không?**

Những gì hiện trên slide sẽ được hiển thị — biểu tượng/hình ảnh thay thế (bản xem trước). Nội dung OLE “sống” không được thực thi trong quá trình render. Nếu cần, hãy đặt hình ảnh xem trước của riêng bạn để đảm bảo giao diện mong muốn trong PDF đã xuất.

Để cũng giữ tệp được nhúng dưới dạng tệp đính kèm PDF, gọi [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) với `True`. Tùy chọn này mặc định bị tắt. Xem ví dụ và hướng dẫn kiểm tra tệp đính kèm tại [Preserve Embedded OLE Files as PDF Attachments](/slides/vi/python-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Làm sao tôi có thể khóa một đối tượng OLE trên slide để người dùng không thể di chuyển/chỉnh sửa nó trong PowerPoint?**

Khóa shape: Aspose.Slides cung cấp [shape-level locks](/slides/vi/python-java/applying-protection-to-presentation/). Đây không phải là mã hoá, nhưng nó thực sự ngăn các chỉnh sửa và di chuyển không mong muốn.

**Tại sao một đối tượng Excel liên kết “nhảy” hoặc thay đổi kích thước khi tôi mở bản trình chiếu?**

PowerPoint có thể làm mới bản xem trước của OLE liên kết. Để có giao diện ổn định, hãy tuân theo các thực hành trong [Working Solution for Worksheet Resizing](/slides/vi/python-java/working-solution-for-worksheet-resizing/) — hoặc vừa khung với phạm vi, hoặc co phạm vi vào khung cố định và đặt hình ảnh thay thế phù hợp.

**Các đường dẫn tương đối cho các đối tượng OLE liên kết có được giữ lại trong định dạng PPTX không?**

Trong PPTX, thông tin “đường dẫn tương đối” không có — chỉ có đường dẫn đầy đủ. Đường dẫn tương đối chỉ tồn tại trong định dạng PPT cũ. Để di động, nên sử dụng đường dẫn tuyệt đối đáng tin cậy/URI có thể truy cập hoặc nhúng.