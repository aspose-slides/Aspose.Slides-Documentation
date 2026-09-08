---
title: Quản lý liên kết hypertext trong bản trình bày bằng Python qua Java
linktitle: Quản lý liên kết
type: docs
weight: 20
url: /vi/python-java/manage-hyperlinks/
keywords:
- thêm URL
- thêm liên kết
- tạo liên kết
- định dạng liên kết
- xóa liên kết
- cập nhật liên kết
- liên kết văn bản
- liên kết slide
- liên kết hình dạng
- liên kết hình ảnh
- liên kết video
- liên kết có thể thay đổi
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Quản lý liên kết một cách dễ dàng trong các bản trình bày PowerPoint và OpenDocument với Aspose.Slides cho Python qua Java—tăng cường tính tương tác và quy trình làm việc trong vài phút."
---
## **Giới thiệu**

Liên kết hypertext là một tham chiếu tới một đối tượng hoặc dữ liệu hoặc một vị trí trong một thứ gì đó. Đây là các liên kết hypertext phổ biến trong các bản trình bày PowerPoint:

* Liên kết tới các trang web trong văn bản, hình dạng hoặc phương tiện truyền thông
* Liên kết tới các slide

Aspose.Slides for Python qua Java cho phép bạn thực hiện nhiều tác vụ liên quan đến liên kết hypertext trong các bản trình bày.

{{% alert color="info" title="Note" %}} 

Bạn có thể muốn xem Aspose đơn giản, [trình chỉnh sửa PowerPoint trực tuyến miễn phí.](https://products.aspose.app/slides/vi/editor)

{{% /alert %}} 

## **Thêm Liên Kết URL**

### **Thêm Liên Kết URL vào Văn Bản**

Mã Python này cho bạn thấy cách thêm một liên kết website vào văn bản:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Thêm Liên Kết URL vào Hình Dạng hoặc Khung**

Mã mẫu này trong Python qua Java cho bạn thấy cách thêm một liên kết website vào hình dạng:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50)

    shape.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Thêm Liên Kết URL vào Phương Tiện Truyền Thông**

Aspose.Slides cho phép bạn thêm liên kết hypertext vào hình ảnh, tệp âm thanh và video.

Mã mẫu này cho bạn thấy cách thêm một liên kết vào **hình ảnh**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
        # Thêm ảnh vào bản trình bày
        image = Images.fromFile("image.png")
        try:
            picture = presentation.getImages().addImage(image)
        finally:
            image.dispose()
        # Tạo khung hình trên slide 1 dựa trên ảnh đã thêm trước đó
        picture_frame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

        picture_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
        picture_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

        presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Mã mẫu này cho bạn thấy cách thêm một liên kết vào **tệp âm thanh**:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat

presentation = Presentation()
try:
    audio_data = Path("audio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = presentation.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio)

    audio_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    audio_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Mã mẫu này cho bạn thấy cách thêm một liên kết vào **video**:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.avi").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video)

    video_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    video_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Tip" %}} 

Bạn có thể muốn xem *[Quản lý OLE](/slides/vi/python-java/manage-ole/)*.

{{% /alert %}}

## **Sử Dụng Liên Kết Để Tạo Mục Lục**

Vì các liên kết hypertext cho phép bạn thêm tham chiếu tới các đối tượng hoặc vị trí, bạn có thể sử dụng chúng để tạo mục lục.

Mã mẫu này cho bạn thấy cách tạo mục lục với các liên kết hypertext:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())

    content_table = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    content_table.getFillFormat().setFillType(FillType.NoFill)
    content_table.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    content_table.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    content_table.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Định Dạng Liên Kết**

### **Màu Sắc**

Với thuộc tính [Hyperlink.setColorSource](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlink/#setColorSource) trong lớp [Hyperlink](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlink/), bạn có thể đặt màu cho các liên kết hypertext và cũng có thể lấy thông tin màu từ các liên kết. Tính năng này lần đầu được giới thiệu trong PowerPoint 2019, vì vậy các thay đổi liên quan đến thuộc tính này không áp dụng cho các phiên bản PowerPoint cũ hơn.

Mã mẫu này minh họa một thao tác trong đó các liên kết hypertext với màu khác nhau được thêm vào cùng một slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Hyperlink, HyperlinkColorSource, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    colored_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, False)
    colored_link_shape.addTextFrame("This is a sample of colored hyperlink.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This is a sample of usual hyperlink.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Xóa Liên Kết Khỏi Bản Trình Bày**

### **Xóa Liên Kết Khỏi Văn Bản**

Mã Python này cho bạn thấy cách xóa liên kết khỏi văn bản trong một slide của bản trình bày:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, AutoShape

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None:
                for paragraph in text_frame.getParagraphs():
                    for portion in paragraph.getPortions():
                        portion.getPortionFormat().getHyperlinkManager().removeHyperlinkClick()

    presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Xóa Liên Kết Khỏi Hình Dạng hoặc Khung**

Mã Python này cho bạn thấy cách xóa liên kết khỏi một hình dạng trong slide của bản trình bày:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        shape.getHyperlinkManager().removeHyperlinkClick()
    presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Liên Kết Có Thể Thay Đổi**

Lớp [Hyperlink](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlink/) là có thể thay đổi. Với lớp này, bạn có thể thay đổi giá trị cho các thuộc tính sau:

- [setTargetFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlink/#setTargetFrame)
- [setTooltip](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlink/#setTooltip)
- [setHistory](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlink/#setHistory)
- [setHighlightClick](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlink/#setHighlightClick)
- [setStopSoundOnClick](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlink/#setStopSoundOnClick)

Đoạn mã này cho bạn thấy cách thêm một liên kết vào slide và chỉnh sửa tooltip của nó sau này:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")
    portion_format.setFontHeight(32)

    # Thay đổi tooltip của hyperlink đã được thêm
    portion_format.getHyperlinkClick().setTooltip("Aspose: the File Format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Các Thuộc Tính Được Hỗ Trợ trong HyperlinkQueries**

Bạn có thể truy cập [HyperlinkQueries](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlinkqueries/) từ một bản trình bày, slide hoặc văn bản mà liên kết hypertext được định nghĩa.

- [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getHyperlinkQueries)
- [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/#getHyperlinkQueries)

Lớp [HyperlinkQueries](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlinkqueries/) hỗ trợ các phương thức và thuộc tính sau:

- [getHyperlinkClicks](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks)
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers)
- [getAnyHyperlinks](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks)
- [removeAllHyperlinks](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks)

## **Câu Hỏi Thường Gặp**

**Làm thế nào tôi có thể tạo điều hướng nội bộ không chỉ tới một slide, mà còn tới một "phần" hoặc slide đầu tiên của một phần?**

Các phần trong PowerPoint là nhóm các slide; điều hướng về mặt kỹ thuật nhắm tới một slide cụ thể. Để “đi tới một phần”, bạn thường liên kết tới slide đầu tiên của phần đó.

**Tôi có thể gắn một liên kết hypertext vào các phần tử slide chủ để nó hoạt động trên tất cả các slide không?**

Có. Các phần tử slide chủ và bố cục hỗ trợ liên kết hypertext. Các liên kết này xuất hiện trên các slide con và có thể nhấp được trong khi trình chiếu.

**Liên kết hypertext có được giữ lại khi xuất sang PDF, HTML, hình ảnh hoặc video không?**

Trong [PDF](/slides/vi/python-java/convert-powerpoint-to-pdf/) và [HTML](/slides/vi/python-java/convert-powerpoint-to-html/), có—liên kết thường được giữ lại. Khi xuất sang [hình ảnh](/slides/vi/python-java/convert-powerpoint-to-png/) và [video](/slides/vi/python-java/convert-powerpoint-to-video/), khả năng nhấp không được chuyển vì bản chất của các định dạng đó (khung raster/video không hỗ trợ liên kết hypertext).