---
title: Quản lý các điều khiển ActiveX trong bản trình chiếu bằng Python
linktitle: ActiveX
type: docs
weight: 80
url: /vi/python-java/activex/
keywords:
- ActiveX
- điều khiển ActiveX
- quản lý ActiveX
- thêm ActiveX
- chỉnh sửa ActiveX
- trình phát media
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Chỉnh sửa các hộp văn bản và nút ActiveX, cập nhật bản xem trước của điều khiển, và tái sử dụng điều khiển Windows Media Player trong các bản trình chiếu PowerPoint với Aspose.Slides cho Python qua Java."
---
## **Giới thiệu**

Các điều khiển ActiveX cung cấp cho một slide PowerPoint các yếu tố tương tác như hộp văn bản, nút lệnh và trình phát phương tiện. Aspose.Slides for Python qua Java cung cấp các điều khiển của một slide thông qua [BaseSlide.getControls](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getControls). Sử dụng bộ sưu tập này để chỉnh sửa một điều khiển, di chuyển nó trên slide hoặc xóa nó.

## **Liệt kê các Điều khiển ActiveX và Thuộc tính Được Lưu Trữ**

Để kiểm tra một mẫu không quen thuộc, mở nó để đọc và lặp lại các điều khiển trên mỗi slide. Ví dụ báo cáo số slide, tên điều khiển, [getClassId](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getClassId), và mỗi cặp khóa-giá trị trong [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties). Nó đọc bản trình chiếu mà không kích hoạt các điều khiển, gọi sự kiện hay macro, thay đổi giá trị, hoặc lưu tệp.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("ActiveX.pptm")
try:
    for slide_number, slide in enumerate(presentation.getSlides(), start=1):
        for control in slide.getControls():
            print(f"Slide {slide_number} | {control.getName()} | {control.getClassId()}")
            properties = control.getProperties()
            if properties is None:
                print("  Properties unavailable")
            elif properties.getCount() == 0:
                print("  []")
            else:
                for name in properties.getNamesOfProperties():
                    print(f"  {name} = {properties.get_Item(name)}")
finally:
    presentation.dispose()
```

Kết quả đã chọn từ `ActiveX.pptm` hiển thị một hộp văn bản và một nút lệnh.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Một bộ sưu tập thuộc tính rỗng hiển thị dưới dạng `[]`. Đối với các điều khiển sử dụng lưu trữ nhị phân, [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties) có thể trả về `None`, được hiển thị là `Properties unavailable`. Nếu bạn chỉ cần tên, hãy sử dụng [getNamesOfProperties](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) sau khi kiểm tra bộ sưu tập có sẵn. Báo cáo liệt kê các thuộc tính có sẵn trong bản trình chiếu. Một điều khiển có thể hỗ trợ các thuộc tính bổ sung tại thời gian chạy.

## **Chỉnh sửa các Điều khiển ActiveX**

Ví dụ này yêu cầu một bản trình chiếu cho phép macro có một hộp văn bản tên `TextBox1` và một nút lệnh tên `CommandButton1` trên slide đầu tiên. Nó sử dụng [control properties collection](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) để thay đổi giá trị hộp văn bản và chú thích nút. Mỗi điều khiển cũng có một bản xem trước tĩnh mà PowerPoint có thể hiển thị trước khi kích hoạt. Cung cấp một tệp PNG cho mỗi điều khiển hiển thị văn bản và giao diện đã cập nhật. Ví dụ gán các hình ảnh này thông qua [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getSubstitutePictureFormat).

Ví dụ di chuyển mọi điều khiển trên slide đầu tiên xuống dưới 100 điểm bằng cách đặt khung của chúng bằng [Control.setFrame](https://reference.aspose.com/slides/python-java/aspose.slides/control/#setFrame). Nó lưu bản trình chiếu đã chỉnh sửa ở định dạng PPTM, sau đó sử dụng [ControlCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/controlcollection/#clear) để lưu một bản sao thứ hai với tất cả các điều khiển ActiveX đã bị xóa khỏi slide đó.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame

presentation = Presentation("ActiveX.pptm")
try:
    controls = presentation.getSlides().get_Item(0).getControls()
    by_name = {str(control.getName()): control for control in controls}
    text_box = by_name.get("TextBox1")
    button = by_name.get("CommandButton1")
    if text_box is None or button is None or text_box.getProperties() is None or button.getProperties() is None:
        print("The first slide must contain both named controls with editable properties.")
    else:
        text_box_bytes = Path("text-box-preview.png").read_bytes()
        button_bytes = Path("button-preview.png").read_bytes()
        text_box_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(text_box_bytes))
        button_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(button_bytes))
        text_box.getProperties().set_Item("Value", "Changed text")
        button.getProperties().set_Item("Caption", "Show message")
        text_box.getSubstitutePictureFormat().getPicture().setImage(text_box_preview)
        button.getSubstitutePictureFormat().getPicture().setImage(button_preview)

        for control in controls:
            frame = control.getFrame()
            moved = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(moved)
        presentation.save("edited-controls.pptm", SaveFormat.Pptm)

        controls.clear()
        presentation.save("removed-controls.pptm", SaveFormat.Pptm)
except OSError as error:
    print(f"Could not read a control preview: {error}")
finally:
    presentation.dispose()
```

## **Thêm một Điều khiển Trình phát Media ActiveX**

Để tái sử dụng một điều khiển Windows Media Player đã cấu hình, bắt đầu với một mẫu mà slide đầu tiên chứa một trình phát tên `WindowsMediaPlayer1`. [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) sao chép toàn bộ slide vào một bản trình chiếu mới. Ví dụ đặt `URL` của trình phát trong [properties collection](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) và lưu slide đã sao chép làm slide duy nhất trong đầu ra. Video vẫn ở dạng bên ngoài, vì vậy hãy chọn một đường dẫn mà trình phát có thể truy cập trong quá trình phát.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

template = Presentation("template.pptx")
try:
    presentation = Presentation()
    try:
        slides = presentation.getSlides()
        slide = slides.addClone(template.getSlides().get_Item(0))
        player = next((control for control in slide.getControls() if control.getName() == "WindowsMediaPlayer1"), None)
        if player is None or player.getProperties() is None:
            print("The template slide must contain a named media player with editable properties.")
        else:
            player.getProperties().set_Item("URL", "Wildlife.mp4")
            slides.removeAt(0)
            presentation.save("linked-video.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    template.dispose()
```

## **FAQ**

**Aspose.Slides có thể giữ nguyên các điều khiển ActiveX mà không chạy chúng không?**

Có. Aspose.Slides có thể đọc và lưu các điều khiển, bao gồm thuộc tính và vị trí của chúng, mà không kích hoạt chúng.

**Các điều khiển ActiveX khác gì so với đối tượng OLE?**

Các điều khiển ActiveX cho phép người dùng tương tác với slide, ví dụ nhập văn bản hoặc nhấn nút. Một [OLE object](/slides/vi/python-java/manage-ole/) cho phép slide chứa hoặc liên kết tới nội dung được quản lý bởi một ứng dụng khác, chẳng hạn như một bảng tính Excel.

**Các sự kiện ActiveX sẽ vẫn kích hoạt macro VBA sau khi tôi lưu bản trình chiếu bằng Aspose.Slides không?**

Lưu bản trình chiếu ở định dạng hỗ trợ macro như PPTM để giữ lại dự án VBA. PowerPoint cho Windows có thể chạy các trình xử lý sự kiện hiện có khi cài đặt bảo mật cho phép cả điều khiển ActiveX và macro.