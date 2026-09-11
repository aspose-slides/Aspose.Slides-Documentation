---
title: Quản lý Đồ họa SmartArt trong Bản trình bày bằng Python
linktitle: Đồ họa SmartArt
type: docs
weight: 20
url: /vi/python-java/manage-smartart-shape/
keywords:
- đối tượng SmartArt
- đồ họa SmartArt
- kiểu SmartArt
- màu SmartArt
- tạo SmartArt
- thêm SmartArt
- chỉnh sửa SmartArt
- thay đổi SmartArt
- truy cập SmartArt
- kiểu bố cục SmartArt
- PowerPoint
- bản trình bày
- Python
- Aspose.Slides
description: "Tự động tạo, chỉnh sửa và tạo kiểu SmartArt trong PowerPoint bằng Python sử dụng Aspose.Slides, với các ví dụ mã ngắn gọn và hướng dẫn tối ưu hiệu suất."
---
## **Tổng quan**

Aspose.Slides cho phép bạn tạo và quản lý đồ họa SmartArt trong các bản trình bày PowerPoint một cách lập trình. Bài viết này giải thích cách thêm một hình SmartArt vào một slide, truy cập các hình SmartArt hiện có, tìm SmartArt theo một kiểu bố cục cụ thể và cập nhật giao diện trực quan của nó bằng cách thay đổi kiểu SmartArt hoặc kiểu màu. Các ví dụ cho thấy cách làm việc với các hình SmartArt thông qua bộ sưu tập hình dạng của slide trong bản trình bày, kiểm tra xem một hình có phải là SmartArt hay không và sau đó sửa đổi hoặc kiểm tra các thuộc tính của nó.

## **Tạo một hình SmartArt**
Aspose.Slides for Python via Java cung cấp API để tạo các hình SmartArt. Để tạo một hình SmartArt trong một slide, vui lòng làm theo các bước dưới đây:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) .
2. Lấy một slide theo chỉ mục của nó.
3. [Thêm một hình SmartArt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/#addSmartArt) bằng cách chỉ định một [SmartArtLayoutType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartartlayouttype/) .
4. Lưu bản trình bày đã chỉnh sửa dưới dạng tệp PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    # Lấy slide đầu tiên.
    slide = presentation.getSlides().get_Item(0)

    # Thêm một hình SmartArt.
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList)

    # Lưu bản trình bày.
    presentation.save("SimpleSmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Hình: Hình SmartArt được thêm vào slide**|

## **Truy cập một hình SmartArt trên Slide**
Ví dụ sau đây truy cập các hình SmartArt trên một slide của bản trình bày. Nó lặp qua từng hình trên slide và kiểm tra xem hình đó có phải là một thể hiện của [SmartArt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartart/) hay không.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # Duyệt qua mọi hình trên slide đầu tiên.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            print("Shape Name: " + str(smart_art.getName()))
finally:
    presentation.dispose()
```

## **Truy cập một hình SmartArt với Kiểu Bố Cục Cụ Thể**
Ví dụ sau đây truy cập một hình [SmartArt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartart/) với một kiểu bố cục cụ thể, được trả về bởi [SmartArt.getLayout](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartart/#getLayout) .

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và tải bản trình bày chứa hình SmartArt.
2. Lấy slide đầu tiên theo chỉ mục của nó.
3. Lặp qua từng hình trên slide đầu tiên.
4. Kiểm tra xem hình có phải là một thể hiện của [SmartArt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartart/) hay không.
5. Kiểm tra xem hình SmartArt có kiểu bố cục đã chỉ định không và thực hiện thao tác cần thiết.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # Duyệt qua mọi hình trên slide đầu tiên.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Kiểm tra bố cục SmartArt.
            if smart_art.getLayout() == SmartArtLayoutType.BasicBlockList:
                print("Perform the required operation here.")
finally:
    presentation.dispose()
```

## **Thay đổi Kiểu Dáng Hình SmartArt**
Ví dụ này cho thấy cách thay đổi kiểu nhanh của một hình SmartArt.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và tải bản trình bày chứa hình SmartArt.
2. Lấy slide đầu tiên theo chỉ mục của nó.
3. Lặp qua từng hình trên slide đầu tiên.
4. Kiểm tra xem hình có phải là một thể hiện của [SmartArt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartart/) hay không.
5. Tìm hình SmartArt với kiểu đã chỉ định.
6. Đặt kiểu mới cho hình SmartArt.
7. Lưu bản trình bày.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtQuickStyleType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Duyệt qua mọi hình trên slide đầu tiên.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Kiểm tra và thay đổi kiểu SmartArt.
            if smart_art.getQuickStyle() == SmartArtQuickStyleType.SimpleFill:
                smart_art.setQuickStyle(SmartArtQuickStyleType.Cartoon)

    presentation.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Hình: Hình SmartArt với kiểu đã thay đổi**|

## **Thay đổi Kiểu Màu của Hình SmartArt**
Ví dụ này truy cập một hình SmartArt với một kiểu màu cụ thể và thay đổi kiểu đó.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và tải bản trình bày chứa hình SmartArt.
2. Lấy slide đầu tiên theo chỉ mục của nó.
3. Lặp qua từng hình trên slide đầu tiên.
4. Kiểm tra xem hình có phải là một thể hiện của [SmartArt](https://reference.aspose.com/slides/vi/python-java/aspose.slides/smartart/) hay không.
5. Tìm hình SmartArt với kiểu màu đã chỉ định.
6. Đặt kiểu màu mới cho hình SmartArt.
7. Lưu bản trình bày.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtColorType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Duyệt qua mọi hình trên slide đầu tiên.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Kiểm tra và thay đổi kiểu SmartArt.
            if smart_art.getColorStyle() == SmartArtColorType.ColoredFillAccent1:
                smart_art.setColorStyle(SmartArtColorType.ColorfulAccentColors)

    presentation.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Hình: Hình SmartArt với kiểu màu đã thay đổi**|

## **FAQ**

**Có thể hoạt ảnh SmartArt như một đối tượng duy nhất không?**

Có. SmartArt là một hình dạng, vì vậy bạn có thể áp dụng [hoạt ảnh tiêu chuẩn](/slides/vi/python-java/powerpoint-animation/) thông qua API hoạt ảnh (đầu vào, thoát, nhấn mạnh, đường di chuyển) giống như với các hình khác.

**Làm thế nào tôi có thể tìm một SmartArt cụ thể trên slide nếu không biết ID nội bộ của nó?**

Đặt và sử dụng [alternative text](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#setAlternativeText) và tìm kiếm hình theo giá trị đó—đây là cách được khuyến nghị để xác định vị trí hình mục tiêu.

**Tôi có thể nhóm SmartArt với các hình khác không?**

Có. Bạn có thể nhóm SmartArt với các hình khác (hình ảnh, bảng, v.v.) và sau đó [thao tác nhóm](/slides/vi/python-java/group/) .

**Làm sao tôi lấy hình ảnh của một SmartArt cụ thể (ví dụ, để xem trước hoặc báo cáo)?**

Xuất một hình thu nhỏ/hình ảnh của hình; thư viện có thể [kết xuất các hình riêng lẻ](/slides/vi/python-java/create-shape-thumbnails/) thành các tệp raster (PNG/JPG/TIFF).

**Giao diện SmartArt có được bảo toàn khi chuyển đổi toàn bộ bản trình bày sang PDF không?**

Có. Động cơ kết xuất hướng tới độ trung thực cao cho [PDF export](/slides/vi/python-java/convert-powerpoint-to-pdf/), với nhiều tùy chọn về chất lượng và khả năng tương thích.