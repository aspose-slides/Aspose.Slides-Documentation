---
title: Quản lý Liên kết Siêu văn bản trong Bản trình chiếu bằng Python qua Java
linktitle: Quản lý Liên kết
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
- bản trình chiếu
- Python
- Java
- Aspose.Slides
description: "Thêm, định dạng, cập nhật và xóa liên kết trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Python qua Java, sử dụng các ví dụ Python."
---
## **Giới thiệu**

Liên kết siêu văn bản kết nối nội dung bản trình chiếu với một trang web hoặc một vị trí trong bản trình chiếu. Trong PowerPoint, liên kết siêu văn bản thường phục vụ hai mục đích:

* Mở một trang web từ văn bản, hình dạng hoặc khung đa phương tiện.
* Điều hướng tới một slide khác, ví dụ, từ mục lục.

Aspose.Slides for Python via Java cho phép bạn thêm các liên kết này, kiểm soát giao diện và âm thanh của chúng, cập nhật các thuộc tính và xóa chúng. Các ví dụ bên dưới cho thấy cách làm việc với liên kết siêu văn bản trên các yếu tố cá nhân và cách truy cập liên kết ở mức bản trình chiếu, slide hoặc khung văn bản.

{{% alert color="info" title="Note" %}}
You can also edit presentations with the [trình chỉnh sửa PowerPoint trực tuyến miễn phí của Aspose](https://products.aspose.app/slides/editor).
{{% /alert %}}

## **Thêm Liên Kết URL**

Bạn có thể gán URL của một trang web cho văn bản, hình dạng hoặc khung đa phương tiện. Thành phần mà bạn gán liên kết siêu văn bản quyết định khu vực có thể nhấp: một phần văn bản sẽ liên kết tới văn bản đã chọn, trong khi một hình dạng hoặc khung sẽ liên kết tới đối tượng slide.

For presentations containing relative hyperlinks, see [Quản lý Cơ sở Liên kết](/slides/vi/python-java/presentation-properties/#manage-the-hyperlink-base) to read, change, or clear the document-level base.

### **Thêm Liên Kết URL vào Văn Bản**

Để liên kết văn bản tới một trang web, truyền một [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) vào phương thức [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#setHyperlinkClick) của phần văn bản, như được hiển thị dưới đây. Chỉ phần văn bản đó sẽ có thể nhấp.

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

### **Thêm Liên Kết URL vào Hình Dạng và Khung Đa Phương Tiện**

Gọi [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHyperlinkClick) trên hình chữ nhật để làm cho toàn bộ khu vực của nó có thể nhấp. Sử dụng [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip) để hiển thị cho người đọc một gợi ý về đích đến khi họ di chuột qua hình chữ nhật. Cả hai phương thức này cũng áp dụng cho khung ảnh, âm thanh và video.

```python
import jpime
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

## **Sử dụng Liên Kết để Tạo Mục Lục**

Liên kết nội bộ cho phép người đọc chuyển từ mục lục tới một slide cụ thể. Ví dụ sau sử dụng [setInternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick) để liên kết văn bản “Page 2” trên slide đầu tiên tới slide thứ hai.

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

## **Định Dạng Liên Kết**

Bạn có thể thay đổi màu sắc của văn bản có liên kết, phát hoặc dừng âm thanh khi người đọc kích hoạt một liên kết, và đặt tooltip hiển thị khi di chuột.

### **Color**

Phương thức [setColorSource](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setColorSource) của [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) xác định liệu một liên kết có sử dụng màu liên kết của bản trình chiếu hay định dạng của phần văn bản. Để áp dụng màu văn bản tùy chỉnh, chọn [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkcolorsource/) và đặt màu nền cho phần đó. Tính năng này được giới thiệu trong PowerPoint 2019; các phiên bản cũ hơn không áp dụng cài đặt này.

Trong ví dụ này, [setColorSource](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setColorSource) làm cho liên kết đầu tiên sử dụng màu nền đỏ của phần văn bản. Liên kết thứ hai giữ màu liên kết của bản trình chiếu.

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

### **Sound**

Liên kết có thể phát âm thanh khi được kích hoạt hoặc dừng âm thanh đang phát. Sử dụng các phương thức sau để cấu hình các hành vi này:

- [Hyperlink.setSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setSound) chỉ định âm thanh liên quan đến liên kết.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) kiểm soát việc kích hoạt liên kết có dừng âm thanh trước đó hay không.

#### **Thêm Âm Thanh Liên Kết**

Nút trên slide đầu tiên sử dụng [Hyperlink.setSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setSound) để phát âm thanh từ `sampleaudio.wav` khi người đọc nhấp để tiếp tục. Trên slide thứ hai, một nút riêng biệt sử dụng [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) để dừng phát và giữ người đọc trên slide đó.

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

#### **Trích Xuất Âm Thanh Liên Kết**

Ví dụ sau mở bản trình chiếu được tạo ở trên và đọc âm thanh liên kết của hình dạng đầu tiên vào bộ nhớ thông qua [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getSound) và [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData).

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

Bạn có thể gọi các phương thức [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) sau khi đã gán một liên kết cho văn bản hoặc hình dạng:

- [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip) đặt văn bản mà người xem có thể hiển thị như một gợi ý cho liên kết.
- [setTargetFrame](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTargetFrame) chỉ định khung mục tiêu trong một khung HTML cha, khi áp dụng.
- [setHistory](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHistory) kiểm soát việc kích hoạt liên kết có thêm đích đến vào danh sách các liên kết đã xem hay không.
- [setHighlightClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHighlightClick) kiểm soát liệu liên kết có được làm nổi bật khi được nhấp hay không.

## **Xóa Liên Kết khỏi Bản Trình Chiếu**

Sử dụng [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) để thu thập các container liên kết, bao gồm các liên kết phần văn bản, trước khi thay đổi chúng. Ví dụ sau xóa cả hai kiểu kích hoạt khỏi slide đầu tiên. Để chỉ xóa một kiểu, gọi chỉ [removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) hoặc [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver); việc xóa hành động nhấp không xóa hành động rê chuột tương ứng.

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

Đối với việc xóa không có điều kiện, [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) xóa cả hai kiểu kích hoạt trong phạm vi đã chọn trong một lần gọi. Đối với việc dọn dẹp có chọn lọc và bao phủ các master, layout và notes, xem [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

### **Xóa Liên Kết Trước Khi Thay Thế Văn Bản SmartArt**

Khi bạn thay thế một đoạn văn trong một node SmartArt hiện có, việc xóa các phần văn bản có thể để lại một liên kết cũ vẫn hoạt động. Lấy đoạn văn thông qua [SmartArtNode.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#getTextFrame). Trước khi xóa các phần, gọi [getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getHyperlinkQueries) trên khung văn bản của hình dạng node hiển thị đoạn văn, sau đó gọi [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) trên đối tượng trả về. Điều này sẽ xóa mọi liên kết trong khung đó, bao gồm các liên kết trong các đoạn văn khác.

Ví dụ giả định rằng hình dạng thứ ba trên slide đầu tiên của `SmartArtHyperlink.pptx` là một đồ họa SmartArt. Nó thay thế đoạn văn đầu tiên của node thứ tư. Trong bản trình chiếu này, hình dạng đầu tiên của node hiển thị đoạn văn đó.

Sau khi thêm cả hai phần, ví dụ đọc định dạng thực tế của chúng bằng [getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective). Trên định dạng đó, `getHyperlinkClick` trả về liên kết mới cho phần đầu tiên và `None` cho phần thứ hai.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Portion, Presentation

presentation = Presentation("SmartArtHyperlink.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    smart_art = slide.getShapes().get_Item(2)
    node = smart_art.getAllNodes().get_Item(3)
    paragraph = node.getTextFrame().getParagraphs().get_Item(0)

    node.getShapes().get_Item(0).getTextFrame().getHyperlinkQueries().removeAllHyperlinks()
    paragraph.getPortions().clear()

    link = Portion("New reference")
    link.getPortionFormat().setHyperlinkClick(Hyperlink("https://example.com/new"))
    paragraph.getPortions().add(link)
    text = Portion(" (updated)")
    paragraph.getPortions().add(text)

    print(link.getPortionFormat().getEffective().getHyperlinkClick().getExternalUrl())  # https://example.com/new
    print(text.getPortionFormat().getEffective().getHyperlinkClick())  # None
finally:
    presentation.dispose()
```

## **Xây Dựng Danh Mục Liên Kết Hoàn Đảo**

Trước khi phân phối một bản trình chiếu, hãy lập danh mục các hành động tương tác cũng như các liên kết web của nó. [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) trả về các container liên kết, như các đối tượng [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) và [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) , không phải danh sách phẳng các chuỗi URL. Kiểm tra cả [getHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkClick) và [getHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkMouseOver) trên mỗi container. Chúng độc lập: cùng một container có thể hiển thị cả hai hành động, vì vậy một báo cáo đầy đủ có thể cần tới hai hàng cho mỗi container.

Việc chỉ quét các liên kết ở mức hình dạng có thể bỏ sót các liên kết gắn vào các phần văn bản. Thay vào đó, truy vấn phạm vi thích hợp và giữ lại các container trả về để bạn có thể cập nhật hoặc xóa các hành động của chúng sau này.

### **Truy Vấn Các Phạm Vi Bản Trình Chiếu, Slide và Khung Văn Bản**

Lớp [HyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/) có sẵn qua [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getHyperlinkQueries), và [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getHyperlinkQueries). Mỗi phạm vi hỗ trợ các truy vấn giống nhau:

- [getHyperlinkClicks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) trả về các container có hành động nhấp.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) trả về các container có hành động rê chuột.
- [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) trả về các container có một hoặc cả hai hành động.

Ví dụ này gán các hành động nhấp và rê chuột cho một hình dạng và văn bản của nó, và một hành động macro cho một nút riêng biệt. Nó so sánh số lượng container trả về bởi [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) với số lượng cho mỗi kiểu kích hoạt. Một truy vấn khung văn bản chỉ đếm các liên kết trong văn bản. Các hành động riêng của hình dạng bao bọc xuất hiện trong các truy vấn slide và bản trình chiếu.

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

Đối với ví dụ này, các truy vấn bản trình chiếu và slide mỗi đều báo cáo ba container nhấp, hai container rê chuột, và ba container có một trong hai hành động. Truy vấn khung văn bản báo cáo một container trong mỗi danh mục.

### **Phân Loại Hành Động và Đích Đến**

Sử dụng [Hyperlink.getActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getActionType) để giải thích một hành động trước khi giải thích đích đến của nó. Các giá trị [HyperlinkActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkactiontype/) bao phủ hơn chỉ việc điều hướng web:

| Giá trị | Ý nghĩa cho kiểm tra |
| --- | --- |
| `Hyperlink` | Liên kết bên ngoài; kiểm tra URL và giao thức của nó. |
| `JumpSpecificSlide` | Điều hướng nội bộ tới một slide cụ thể. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Điều hướng trình chiếu tích hợp, được giải quyết trong ngữ cảnh trình chiếu. |
| `JumpEndShow`, `StartCustomSlideShow` | Kết thúc buổi trình chiếu hiện tại hoặc bắt đầu một buổi trình chiếu tùy chỉnh. |
| `StartMacro` | Thực thi macro. |
| `StartProgram` | Khởi chạy một chương trình. |
| `OpenFile`, `OpenPresentation` | Mở một tệp hoặc một bản trình chiếu khác; xem xét riêng biệt so với URL web. |
| `StartStopMedia` | Bắt đầu hoặc dừng phát phương tiện. |
| `NoAction`, `Unknown` | Không có hành động điều hướng, hoặc một hành động không xác định cần xem xét. |

Đọc các đích đến bên ngoài từ [getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl), và các đích đến nội bộ cụ thể từ [getTargetSlide](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTargetSlide). Các hành động nội bộ và lệnh tích hợp có thể không có URL bên ngoài; một URL trống không có nghĩa là container không có hành động. Bảo tồn giá trị trả về bởi [getExternalUrlOriginal](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal) khi nó khác với URL đã chuẩn hoá, và bao gồm tooltip trả về bởi [getTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTooltip) khi có.

### **Báo Cáo, Làm Sạch và Xác Minh Liên Kết**

Ví dụ này mở bản trình chiếu từ ví dụ trước và ghi một bản ghi JSON cho mỗi hành động. Nó sử dụng [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) để thu thập các container trên các slide thông thường, master, layout và notes, bao gồm cả master notes và handout khi có. Nó dùng so sánh tham chiếu để đếm mỗi container một lần, áp dụng chính sách mô tả bên dưới, và mở lại bản trình chiếu đã lưu để kiểm tra cả hành động nhấp và rê chuột.

Báo cáo ghi lại chỉ mục slide bắt đầu từ 1 và [getSlideId](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideId) khi có. [getSlide](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getSlide) cung cấp slide sở hữu cho các container được hỗ trợ. Master, layout và notes không có chỉ mục slide thông thường và được xác định bằng phạm vi của chúng. Các container hình dạng và container định dạng phần văn bản được gắn nhãn riêng; các loại container khác giữ nguyên tên kiểu thời gian chạy. Mỗi container nhận một ID cục bộ trong báo cáo để hai hành động của nó có thể được liên kết. Báo cáo lưu trữ các loại hành động dưới dạng các hằng số nguyên được định nghĩa bởi enumeration Java.

Chính sách ứng dụng có kiểm soát này chỉ cho phép các URL HTTPS tuyệt đối và các đích slide nội bộ hợp lệ. Nó loại bỏ macro, chương trình, hành động tệp, các hành động trình chiếu khác, hành động không xác định, và các giao thức URL khác. Những loại bỏ này là quyết định chính sách, không phải phán quyết an toàn của Aspose.Slides. Chỉ có HTTPS không đủ để tạo lòng tin: hãy thêm danh sách cho phép máy chủ và các kiểm tra khác cho ứng dụng của bạn. Cả URL bên ngoài gốc và đã chuẩn hoá đều được kiểm tra. Ví dụ này kiểm toán siêu dữ liệu mà không theo dõi các liên kết hay thực hiện hành động.

Để khắc phục, [getHyperlinkManager](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkManager) của container hỗ trợ [setExternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick), và [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver). Ở đây, các liên kết nhấp bên ngoài bị cấm được thay thế bằng một trang đích HTTPS cố định; các nhấp bị cấm khác và các hành động rê chuột bị cấm được xóa độc lập. Đặt `replace_external_clicks` thành `False` để loại bỏ tất cả vi phạm chính sách. Chọn một trang thay thế thuộc sở hữu ứng dụng trước khi triển khai.

Cờ xuất khẩu của báo cáo sử dụng chính sách xem xét PDF thận trọng: đánh dấu các hành động rê chuột và bất kỳ thứ gì không phải là liên kết bên ngoài hoặc chuyển tới slide cụ thể là có khả năng không được hỗ trợ. Đây là gợi ý xem xét, không phải kiểm tra khả năng hay đảm bảo các liên kết không bị đánh dấu sẽ tồn tại khi xuất. Các xuất khẩu [PDF](/slides/vi/python-java/convert-powerpoint-to-pdf/) và [HTML](/slides/vi/python-java/convert-powerpoint-to-html/) được hỗ trợ có thể giữ lại các liên kết, tùy thuộc vào hành động, tùy chọn xuất và trình xem. Các [hình ảnh](/slides/vi/python-java/convert-powerpoint-to-png/) và [video](/slides/vi/python-java/convert-powerpoint-to-video/) raster không thể giữ lại các liên kết tương tác; đánh dấu mọi hành động khi kiểm toán cho các đầu ra đó.

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

Với đầu vào được tạo ở trên, báo cáo chứa năm hàng hành động. Liên kết rê chuột tệp và nhấp macro bị xóa, trong khi các liên kết HTTPS và điều hướng slide nội bộ vẫn còn. Kiểm tra in ra không có hành động bị cấm. Một đầu vào chứa URL nhấp bên ngoài bị cấm cũng sẽ thực thi nhánh thay thế. Một container có nhấp được cho phép và rê chuột bị cấm sẽ giữ lại hành động nhấp.

Sự dọn dẹp có chọn lọc này khác với [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks), vốn xóa cả hai kiểu kích hoạt trong toàn bộ phạm vi đã chọn bất kể chính sách. Kiểm tra ở đây chỉ kiểm tra các hành động liên kết; nó không xóa các dự án VBA nhúng, đối tượng OLE, hoặc nội dung hoạt động khác, và không xác thực một tệp PDF hoặc HTML đã xuất.

## **FAQ**

**Làm thế nào tôi có thể liên kết tới một phần hoặc slide đầu tiên của nó?**

Các phần trong PowerPoint nhóm các slide lại với nhau, nhưng một liên kết nội bộ hướng tới một slide riêng lẻ. Để tạo điều hướng tới một phần, hãy liên kết tới slide đầu tiên trong phần đó.

**Tôi có thể gắn liên kết vào các yếu tố của master slide để nó hoạt động trên tất cả các slide không?**

Có. Các yếu tố trên master slide và layout hỗ trợ liên kết. Các liên kết trên các yếu tố này sẽ khả dụng trong chế độ trình chiếu trên các slide sử dụng master hoặc layout tương ứng.

**Liên kết có được giữ lại khi xuất ra PDF, HTML, hình ảnh hoặc video không?**

Các xuất khẩu PDF và HTML được hỗ trợ có thể giữ lại các liên kết; hình ảnh raster và video không thể. Xem các lưu ý xuất khẩu trong [Báo Cáo, Làm Sạch và Xác Minh Liên Kết](#report-sanitize-and-verify-hyperlinks).