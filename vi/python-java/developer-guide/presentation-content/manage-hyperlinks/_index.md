---
title: Quản lý Siêu Liên Kết Bản Trình Bày trong Python qua Java
linktitle: Quản lý Siêu Liên Kết
type: docs
weight: 20
url: /vi/python-java/manage-hyperlinks/
keywords:
- thêm URL
- thêm siêu liên kết
- tạo siêu liên kết
- định dạng siêu liên kết
- xóa siêu liên kết
- cập nhật siêu liên kết
- siêu liên kết văn bản
- siêu liên kết slide
- siêu liên kết hình dạng
- siêu liên kết hình ảnh
- siêu liên kết video
- siêu liên kết có thể thay đổi
- PowerPoint
- OpenDocument
- bản trình bày
- Python
- Java
- Aspose.Slides
description: "Thêm, định dạng, cập nhật và xóa siêu liên kết trong bản trình bày PowerPoint và OpenDocument bằng Aspose.Slides cho Python qua Java, sử dụng các ví dụ Python."
---
## **Giới thiệu**

Một siêu liên kết kết nối nội dung bản trình bày với một trang web hoặc vị trí trong bản trình bày. Trong PowerPoint, siêu liên kết thường phục vụ hai mục đích:

* Mở một trang web từ văn bản, hình dạng hoặc khung đa phương tiện.
* Điều hướng tới một slide khác, ví dụ, từ mục lục.

Aspose.Slides for Python via Java cho phép bạn thêm các liên kết này, kiểm soát giao diện và âm thanh, cập nhật thuộc tính và xóa chúng. Các ví dụ bên dưới cho thấy cách làm việc với siêu liên kết trên các yếu tố riêng lẻ và cách truy cập siêu liên kết ở mức bản trình bày, slide hoặc khung văn bản.

{{% alert color="info" title="Note" %}}

Bạn cũng có thể chỉnh sửa bản trình bày bằng [trình soạn thảo PowerPoint trực tuyến miễn phí của Aspose](https://products.aspose.app/slides/vi/editor).

{{% /alert %}} 

## **Thêm Siêu Liên Kết URL**

Bạn có thể gán URL của một trang web cho văn bản, hình dạng hoặc khung đa phương tiện. Yếu tố mà bạn gán siêu liên kết sẽ xác định khu vực có thể nhấp: một phần văn bản liên kết tới đoạn văn bản được chọn, trong khi một hình dạng hoặc khung liên kết tới đối tượng slide.

### **Thêm Siêu Liên Kết URL vào Văn Bản**

Để liên kết văn bản với một trang web, truyền một [Hyperlink](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlink/) vào phương thức [setHyperlinkClick](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portionformat/#setHyperlinkClick) của phần văn bản, như shown below. Chỉ phần văn bản đó sẽ trở nên có thể nhấp.

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
    portion_format.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Thêm Siêu Liên Kết URL vào Hình Dạng và Khung Đa Phương Tiện**

Để làm cho một hình dạng hoặc khung có thể nhấp, gọi phương thức [setHyperlinkClick](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#setHyperlinkClick) của nó. Siêu liên kết thuộc về đối tượng chứ không phải một phần văn bản bên trong.

Cách tiếp cận tương tự áp dụng cho khung ảnh, âm thanh và video: gán siêu liên kết cho khung và gọi [setTooltip](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlink/#setTooltip) nếu cần.

Ví dụ sau tạo một hình chữ nhật có thể nhấp:

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
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Sử Dụng Siêu Liên Kết Để Tạo Mục Lục**

Siêu liên kết nội bộ cho phép người đọc nhảy từ mục lục đến một slide cụ thể. Ví dụ dưới đây sử dụng [setInternalHyperlinkClick](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick) để liên kết văn bản “Page 2” trên slide đầu tiên tới slide thứ hai.

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

    table_of_contents = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    table_of_contents.getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    table_of_contents.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Định Dạng Siêu Liên Kết**

### **Màu Sắc**

Phương thức [setColorSource](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlink/#setColorSource) của [Hyperlink](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlink/) quyết định siêu liên kết sử dụng màu siêu liên kết của bản trình bày hay định dạng của phần văn bản. Để áp dụng màu văn bản tùy chỉnh, chọn [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlinkcolorsource/) và đặt màu nền cho phần. Tính năng này được giới thiệu trong PowerPoint 2019; các phiên bản cũ hơn không áp dụng cài đặt này.

Ví dụ sau thêm hai siêu liên kết văn bản vào cùng một slide. Siêu liên kết đầu tiên sử dụng màu nền văn bản đỏ, trong khi siêu liên kết thứ hai giữ màu siêu liên kết mặc định.

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
    colored_link_shape.addTextFrame("This hyperlink uses a custom color.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This hyperlink uses the default color.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Âm Thanh**

Một siêu liên kết có thể phát âm thanh khi được kích hoạt hoặc dừng âm thanh đang phát. Sử dụng các phương thức sau để cấu hình hành vi này:

- [Hyperlink.setSound](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlink/#setSound) xác định âm thanh liên kết với siêu liên kết.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) kiểm soát việc kích hoạt siêu liên kết có dừng âm thanh trước đó hay không.

#### **Thêm Âm Thanh Cho Siêu Liên Kết**

Ví dụ sau tải `sampleaudio.wav` và gán nó vào một nút trên slide đầu tiên. Nhấp vào nút sẽ phát âm thanh và chuyển tới slide tiếp theo. Một hình dạng thứ hai trên cùng slide sẽ dừng âm thanh trước khi nhấp, mà không thực hiện hành động chuyển slide.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    audio_data = Path("sampleaudio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    hyperlink_sound = presentation.getAudios().addAudio(java_audio_data)
    first_slide = presentation.getSlides().get_Item(0)
    play_button = first_slide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50)
    play_button.setHyperlinkClick(Hyperlink.getNextSlide())
    if not play_button.getHyperlinkClick().getStopSoundOnClick() and play_button.getHyperlinkClick().getSound() is None:
        play_button.getHyperlinkClick().setSound(hyperlink_sound)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    stop_button = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50)
    stop_button.setHyperlinkClick(Hyperlink.getNoAction())
    stop_button.getHyperlinkClick().setStopSoundOnClick(True)
    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx)
except OSError as exception:
    print(f"Unable to read the audio file: {exception}")
finally:
    presentation.dispose()
```

#### **Trích Xuất Âm Thanh Từ Siêu Liên Kết**

Ví dụ sau mở bản trình bày đã tạo ở trên và đọc âm thanh siêu liên kết của hình dạng đầu tiên vào bộ nhớ thông qua [getSound](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlink/#getSound) và [getBinaryData](https://reference.aspose.com/slides/vi/python-java/aspose.slides/audio/#getBinaryData).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("hyperlink-sound.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick()
        sound = hyperlink.getSound() if hyperlink is not None else None
        if sound is not None:
            audio_data = bytes(sound.getBinaryData())
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
finally:
    presentation.dispose()
```

### **Cài Đặt Tooltip và Tương Tác**

Bạn có thể gọi các phương thức sau của [Hyperlink](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlink/) sau khi đã gán siêu liên kết cho văn bản hoặc hình dạng:

- [setTooltip](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlink/#setTooltip) đặt văn bản mà người xem có thể hiển thị như gợi ý cho liên kết.
- [setTargetFrame](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlink/#setTargetFrame) chỉ định khung mục tiêu trong một tập khung HTML cha, khi áp dụng.
- [setHistory](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlink/#setHistory) kiểm soát việc kích hoạt liên kết có thêm đích đến vào danh sách siêu liên kết đã xem hay không.
- [setHighlightClick](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlink/#setHighlightClick) kiểm soát việc siêu liên kết được tô sáng khi nhấp.

## **Xóa Siêu Liên Kết Khỏi Bản Trình Bày**

Sử dụng [getAnyHyperlinks](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) để thu thập các container siêu liên kết, bao gồm liên kết phần văn bản, trước khi thay đổi chúng. Ví dụ sau xóa cả hai loại kích hoạt khỏi slide đầu tiên. Để xóa chỉ một loại, chỉ gọi [removeHyperlinkClick](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) hoặc [removeHyperlinkMouseOver](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver); việc xóa hành động nhấp không xóa hành động di chuột.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        containers = list(presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks())
        for container in containers:
            container.getHyperlinkManager().removeHyperlinkClick()
            container.getHyperlinkManager().removeHyperlinkMouseOver()
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
    else:
        print("The presentation has no slides to process.")
finally:
    presentation.dispose()
```

Đối với việc xóa vô điều kiện, [removeAllHyperlinks](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) xóa cả hai loại kích hoạt trong phạm vi đã chọn trong một lời gọi. Đối với việc làm sạch có chọn lọc và bao phủ các master, layout và notes, xem [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Xây Dựng Danh Mục Siêu Liên Kết Đầy Đủ**

Trước khi phân phối một bản trình bày, hãy kiểm kê các hành động tương tác cũng như các liên kết web của nó. [getAnyHyperlinks](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) trả về các container siêu liên kết, ví dụ như các đối tượng [Shape](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/) và [PortionFormat](https://reference.aspose.com/slides/vi/python-java/aspose.slides/portionformat/), chứ không phải danh sách phẳng các chuỗi URL. Kiểm tra cả [getHyperlinkClick](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getHyperlinkClick) và [getHyperlinkMouseOver](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getHyperlinkMouseOver) trên mỗi container. Chúng độc lập: cùng một container có thể hiển thị cả hai hành động, vì vậy một báo cáo đầy đủ có thể cần đến hai hàng cho mỗi container.

Quét chỉ các siêu liên kết cấp hình dạng có thể bỏ lỡ các liên kết gắn vào phần văn bản. Thay vào đó, truy vấn phạm vi thích hợp và giữ lại các container trả về để bạn có thể cập nhật hoặc xóa các hành động của chúng sau này.

### **Truy Vấn Phạm Vi Bản Trình Bày, Slide và Khung Văn Bản**

Lớp [HyperlinkQueries](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlinkqueries/) có sẵn thông qua [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseslide/#getHyperlinkQueries) và [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/vi/python-java/aspose.slides/textframe/#getHyperlinkQueries). Mỗi phạm vi hỗ trợ cùng các truy vấn:

- [getHyperlinkClicks](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) trả về các container có hành động nhấp.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) trả về các container có hành động di chuột.
- [getAnyHyperlinks](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) trả về các container có một hoặc cả hai hành động.

Ví dụ sau tạo `hyperlink-audit-input.pptx` với một liên kết nhấp bên ngoài, một liên kết di chuột tới tệp, điều hướng slide nội bộ, một liên kết di chuột trên văn bản và một hành động macro. Nó không thực thi bất kỳ hành động nào trong số này. Ba truy vấn giống nhau hoạt động ở mọi phạm vi; các số đếm mô tả số container, không phải tổng hành động. Phạm vi khung văn bản loại trừ các liên kết của chính hình dạng bao quanh.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType


def print_counts(scope, queries):
    click_count = queries.getHyperlinkClicks().size()
    mouse_over_count = queries.getHyperlinkMouseOvers().size()
    any_count = queries.getAnyHyperlinks().size()
    print(f"{scope}: click={click_count}, mouse-over={mouse_over_count}, any={any_count}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide())
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60)
    shape.getTextFrame().setText("Click the text to go to slide 2")
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/")
    shape.getHyperlinkClick().setTooltip("Public website")
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx")
    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.getHyperlinkManager().setInternalHyperlinkClick(destination)
    portion_format.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help")
    macro_button = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60)
    macro_button.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation")
    print_counts("Presentation", presentation.getHyperlinkQueries())
    print_counts("Slide 1", slide.getHyperlinkQueries())
    print_counts("Text frame", shape.getTextFrame().getHyperlinkQueries())
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Trong ví dụ này, các truy vấn bản trình bày và slide mỗi đều báo cáo ba container nhấp, hai container di chuột, và ba container có bất kỳ hành động nào. Truy vấn khung văn bản báo cáo một container cho mỗi danh mục.

### **Phân Loại Hành Động và Đích Đến**

Sử dụng [Hyperlink.getActionType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlink/#getActionType) để giải thích một hành động trước khi giải thích đích đến của nó. Các giá trị của [HyperlinkActionType](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlinkactiontype/) bao phủ nhiều hơn việc điều hướng web:

| Giá trị | Ý nghĩa cho cuộc kiểm tra |
| --- | --- |
| `Hyperlink` | Siêu liên kết bên ngoài; kiểm tra URL và scheme của nó. |
| `JumpSpecificSlide` | Điều hướng nội bộ tới một slide cụ thể. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Điều hướng trình chiếu tích hợp, được giải quyết trong ngữ cảnh trình chiếu. |
| `JumpEndShow`, `StartCustomSlideShow` | Kết thúc buổi chiếu hiện tại hoặc bắt đầu buổi chiếu tùy chỉnh. |
| `StartMacro` | Thực thi macro. |
| `StartProgram` | Khởi chạy chương trình. |
| `OpenFile`, `OpenPresentation` | Mở tệp hoặc bản trình bày khác; xem xét riêng biệt với URL web. |
| `StartStopMedia` | Bắt đầu hoặc dừng phát media. |
| `NoAction`, `Unknown` | Không có hành động điều hướng, hoặc hành động không nhận dạng được cần xem xét. |

Đọc đích đến bên ngoài từ [getExternalUrl](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlink/#getExternalUrl) và đích đến nội bộ cụ thể từ [getTargetSlide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlink/#getTargetSlide). Các hành động nội bộ và lệnh tích hợp có thể không có URL bên ngoài; một URL rỗng không có nghĩa là container không có hành động. Giữ nguyên giá trị trả về bởi [getExternalUrlOriginal](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal) khi nó khác URL đã chuẩn hoá, và bao gồm tooltip trả về bởi [getTooltip](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlink/#getTooltip) khi có.

### **Báo Cáo, Làm Sạch và Xác Thực Siêu Liên Kết**

Ví dụ Python sau đọc một bản trình bày hiện có (sử dụng tệp đã tạo ở trên), ghi `hyperlink-audit.json`, áp dụng một chính sách, lưu `hyperlink-sanitized.pptx`, và mở lại để kiểm tra lại cả hai loại kích hoạt. Nó thu thập các container trước khi thay đổi và sử dụng so sánh tham chiếu để tránh xử lý cùng một container hai lần. Các truy vấn bản trình bày bao phủ các slide thường; để có kiểm kê toàn bộ gói, nó cũng truy vấn rõ ràng các master, layout, notes và các master notes & handout khi có.

Báo cáo ghi lại chỉ số slide tính từ 1 và [getSlideId](https://reference.aspose.com/slides/vi/python-java/aspose.slides/baseslide/#getSlideId) nếu có. [getSlide](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getSlide) cung cấp slide sở hữu cho các container được hỗ trợ. Các master, layout và notes không có chỉ số slide thường và được xác định bằng phạm vi của chúng. Các container hình dạng và container định dạng phần văn bản được gắn nhãn riêng; các loại container khác giữ tên kiểu thời gian chạy. Mỗi container nhận một ID báo cáo cục bộ để hai hành động của nó có thể được liên kết. Báo cáo lưu trữ loại hành động dưới dạng các hằng số số nguyên được định nghĩa bởi enum Java.

Chính sách ứng dụng hạn chế này chỉ cho phép các URL HTTPS tuyệt đối và các đích slide nội bộ hợp lệ. Nó từ chối macro, chương trình, hành động tệp, các hành động trình chiếu khác, hành động không xác định và các scheme URL khác. Những việc từ chối này là quyết định chính sách, không phải là quyết định an toàn của Aspose.Slides. HTTPS một mình không tạo nên độ tin cậy: hãy thêm danh sách cho phép host và các kiểm tra khác cho ứng dụng của bạn. Cả URL bên ngoài gốc và đã chuẩn hoá đều được kiểm tra. Ví dụ này kiểm toán metadata mà không theo liên kết hoặc chạy hành động.

Đối với việc khắc phục, [getHyperlinkManager](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shape/#getHyperlinkManager) của container hỗ trợ [setExternalHyperlinkClick](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) và [removeHyperlinkMouseOver](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver). Ở đây, các liên kết nhấp bên ngoài bị cấm được thay thế bằng một trang đích HTTPS cố định; các nhấp bị cấm khác và các hành động di chuột bị cấm được xóa độc lập. Đặt `replace_external_clicks` thành `False` để xóa tất cả các vi phạm chính sách. Chọn một trang thay thế do ứng dụng sở hữu trước khi triển khai.

Cờ xuất của báo cáo sử dụng chính sách xem xét PDF thận trọng: đánh dấu các hành động di chuột và bất kỳ thứ gì khác ngoài liên kết bên ngoài hoặc chuyển slide cụ thể là có khả năng không được hỗ trợ. Đây là gợi ý kiểm tra, không phải là kiểm tra khả năng hay bảo đảm rằng các liên kết không được đánh dấu sẽ tồn tại khi xuất. Các xuất PDF và HTML được hỗ trợ có thể giữ lại siêu liên kết, tùy thuộc vào hành động, tùy chọn xuất và trình xem. Các ảnh raster và video không thể giữ lại siêu liên kết tương tác; hãy đánh dấu mọi hành động khi kiểm toán cho các đầu ra đó.

```python
import json
from pathlib import Path
from urllib.parse import urlsplit

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HyperlinkActionType, PortionFormat, Presentation, SaveFormat, Shape

IdentityHashMap = jpype.JClass("java.util.IdentityHashMap")


def slide_index(presentation, slide):
    for index, candidate in enumerate(presentation.getSlides(), start=1):
        if candidate == slide:
            return index
    return None


def is_https(value):
    if not value:
        return False
    value = str(value)
    if any(character.isspace() or ord(character) < 32 for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.getActionType() == HyperlinkActionType.JumpSpecificSlide:
        return "Missing target slide" if link.getTargetSlide() is None else None
    if link.getActionType() != HyperlinkActionType.Hyperlink:
        return "Action is not allowed"
    if not is_https(link.getExternalUrl()):
        return "Normalized URL is not absolute HTTPS"
    original = link.getExternalUrlOriginal()
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def collect_containers(presentation):
    found = list(presentation.getHyperlinkQueries().getAnyHyperlinks())
    scopes = list(presentation.getMasters()) + list(presentation.getLayoutSlides())
    for slide in presentation.getSlides():
        scopes.append(slide.getNotesSlideManager().getNotesSlide())
    scopes.append(presentation.getMasterNotesSlideManager().getMasterNotesSlide())
    scopes.append(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide())
    for scope in scopes:
        if scope is not None:
            found.extend(scope.getHyperlinkQueries().getAnyHyperlinks())
    seen = IdentityHashMap()
    unique = []
    for container in found:
        if not seen.containsKey(container):
            seen.put(container, True)
            unique.append(container)
    return unique


def text_or_none(value):
    return str(value) if value is not None else None


def add_row(rows, presentation, link, activation, container, container_id):
    if link is None:
        return
    owner_slide = container.getSlide() if hasattr(container, "getSlide") else None
    target_slide = link.getTargetSlide()
    violation = policy_violation(link)
    if isinstance(container, Shape):
        owner_type = "Shape"
    elif isinstance(container, PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = str(container.getClass().getSimpleName())
    ordinary_action = link.getActionType() in (HyperlinkActionType.Hyperlink, HyperlinkActionType.JumpSpecificSlide)
    original = link.getExternalUrlOriginal()
    rows.append({
        "ContainerId": container_id,
        "SlideIndex": slide_index(presentation, owner_slide),
        "SlideId": int(owner_slide.getSlideId()) if owner_slide is not None else None,
        "Scope": str(owner_slide.getClass().getSimpleName()) if owner_slide is not None else None,
        "OwnerType": owner_type,
        "Activation": activation,
        "ActionType": int(link.getActionType()),
        "ExternalUrl": text_or_none(link.getExternalUrl()),
        "TargetSlideIndex": slide_index(presentation, target_slide),
        "TargetSlideId": int(target_slide.getSlideId()) if target_slide is not None else None,
        "Tooltip": text_or_none(link.getTooltip()),
        "OriginalExternalUrl": text_or_none(original) if original != link.getExternalUrl() else None,
        "PotentiallyUnsafe": violation is not None,
        "PolicyViolation": violation,
        "TargetExport": "PDF",
        "PotentiallyUnsupportedByExport": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"
presentation = Presentation("hyperlink-audit-input.pptx")
try:
    containers = collect_containers(presentation)
    rows = []
    for container_id, container in enumerate(containers, start=1):
        add_row(rows, presentation, container.getHyperlinkClick(), "click", container, container_id)
        add_row(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, container_id)
    report = json.dumps(rows, indent=2)
    Path("hyperlink-audit.json").write_text(report, encoding="utf-8")

    for container in containers:
        click = container.getHyperlinkClick()
        if policy_violation(click) is not None:
            if replace_external_clicks and click.getActionType() == HyperlinkActionType.Hyperlink:
                container.getHyperlinkManager().setExternalHyperlinkClick(replacement_url)
            else:
                container.getHyperlinkManager().removeHyperlinkClick()
        if policy_violation(container.getHyperlinkMouseOver()) is not None:
            container.getHyperlinkManager().removeHyperlinkMouseOver()
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx)

    reopened = Presentation("hyperlink-sanitized.pptx")
    try:
        remaining_containers = collect_containers(reopened)
        violations = 0
        for container in remaining_containers:
            if policy_violation(container.getHyperlinkClick()) is not None:
                violations += 1
            if policy_violation(container.getHyperlinkMouseOver()) is not None:
                violations += 1
        print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
        if violations != 0:
            print("Verification failed: do not distribute the saved presentation.")
    finally:
        reopened.dispose()
except OSError as exception:
    print(f"Unable to write the audit report: {exception}")
finally:
    presentation.dispose()
```

Với đầu vào được tạo ở trên, báo cáo chứa năm hàng hành động. Liên kết di chuột tệp và macro nhấp được xóa, trong khi các liên kết HTTPS và điều hướng slide nội bộ vẫn còn. Kiểm tra in ra không có hành động bị cấm. Một đầu vào chứa URL nhấp bên ngoài bị cấm cũng sẽ chạy nhánh thay thế. Một container có nhấp cho phép và di chuột bị cấm sẽ giữ lại hành động nhấp của nó.

Việc làm sạch có chọn lọc này khác với [removeAllHyperlinks](https://reference.aspose.com/slides/vi/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks), lệnh này xóa cả hai loại kích hoạt trong phạm vi đã chọn bất kể chính sách. Kiểm tra ở đây chỉ kiểm tra các hành động siêu liên kết; nó không xóa các dự án VBA nhúng, đối tượng OLE hoặc nội dung hoạt động khác, và không xác thực tệp PDF hoặc HTML đã xuất.

## **Câu Hỏi Thường Gặp**

**Làm thế nào tôi có thể liên kết đến một phần hoặc slide đầu tiên của nó?**

Các phần trong PowerPoint nhóm các slide, nhưng một siêu liên kết nội bộ chỉ nhắm tới một slide riêng lẻ. Để tạo điều hướng tới một phần, hãy liên kết tới slide đầu tiên trong phần đó.

**Tôi có thể gắn siêu liên kết vào các yếu tố slide master để chúng hoạt động trên tất cả các slide không?**

Có. Các yếu tố slide master và layout hỗ trợ siêu liên kết. Các liên kết trên các yếu tố này khả dụng trong chế độ chiếu khi các slide sử dụng master hoặc layout tương ứng.

**Liên kết có được giữ lại khi xuất sang PDF, HTML, ảnh hoặc video không?**

Các xuất PDF và HTML được hỗ trợ có thể giữ lại siêu liên kết; ảnh raster và video không thể. Xem các lưu ý xuất trong [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).