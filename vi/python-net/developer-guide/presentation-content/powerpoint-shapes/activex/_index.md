---
title: Quản lý các điều khiển ActiveX trong bản trình chiếu bằng Python
linktitle: ActiveX
type: docs
weight: 80
url: /vi/python-net/activex/
keywords:
- ActiveX
- điều khiển ActiveX
- quản lý ActiveX
- thêm ActiveX
- sửa đổi ActiveX
- trình phát media
- PowerPoint
- bản trình chiếu
- Python
- Aspose.Slides
description: "Chỉnh sửa hộp văn bản và nút ActiveX, cập nhật bản xem trước của điều khiển, và tái sử dụng điều khiển Windows Media Player trong các bản trình chiếu PowerPoint với Aspose.Slides cho Python qua .NET."
---
## **Giới thiệu**

Các điều khiển ActiveX cung cấp cho một slide PowerPoint các yếu tố tương tác như hộp văn bản, nút lệnh và trình phát phương tiện. Aspose.Slides for Python qua .NET cho phép truy cập các điều khiển của slide thông qua [Slide.controls](https://reference.aspose.com/slides/python-net/aspose.slides/slide/controls/). Sử dụng bộ sưu tập này để chỉnh sửa một điều khiển, di chuyển nó trên slide, hoặc xóa nó.

## **Liệt kê các điều khiển ActiveX và các thuộc tính đã lưu**

Để kiểm tra một mẫu không quen thuộc, mở nó để đọc và duyệt qua các điều khiển trên mỗi slide. Ví dụ báo cáo số slide, tên điều khiển, [class_id](https://reference.aspose.com/slides/python-net/aspose.slides/control/class_id/), và mỗi cặp khóa-giá trị trong [properties](https://reference.aspose.com/slides/python-net/aspose.slides/control/#properties). Nó đọc bản trình chiếu mà không kích hoạt các điều khiển, gọi sự kiện hoặc macro, thay đổi giá trị, hoặc lưu tệp.

```python
import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        for control in slide.controls:
            print(f"Slide {slide_number} | {control.name} | {control.class_id}")
            properties = control.properties
            if properties is None:
                print("  Properties unavailable")
                continue

            if properties.count == 0:
                print("  []")
            for entry in properties:
                print(f"  {entry.key} = {entry.value}")
```

Kết quả được chọn từ `ActiveX.pptm` hiển thị một hộp văn bản và một nút lệnh.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Một bộ sưu tập thuộc tính rỗng hiển thị dưới dạng `[]`. Đối với các điều khiển sử dụng lưu trữ nhị phân, `properties` có thể trả về `None`, được hiển thị là `Properties unavailable`. Nếu bạn chỉ cần tên, hãy sử dụng [names_of_properties](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/names_of_properties/) sau khi kiểm tra `None`. Báo cáo liệt kê các thuộc tính có sẵn từ bản trình chiếu. Một điều khiển có thể hỗ trợ các thuộc tính bổ sung tại thời gian chạy.

## **Sửa đổi các điều khiển ActiveX**

Ví dụ yêu cầu một bản trình chiếu bật macro có một hộp văn bản tên `TextBox1` và một nút lệnh tên `CommandButton1` trên slide đầu tiên. Nó sử dụng [control properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) để thay đổi giá trị hộp văn bản và tiêu đề nút. Mỗi điều khiển cũng có một bản xem trước tĩnh mà PowerPoint có thể hiển thị trước khi kích hoạt. Cung cấp một tệp PNG cho mỗi điều khiển để hiển thị văn bản và ngoại hình đã cập nhật. Ví dụ gán các hình ảnh này thông qua [Control.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/control/substitute_picture_format/).

Ví dụ di chuyển mọi điều khiển trên slide đầu tiên xuống 100 điểm bằng cách thay đổi [frame](https://reference.aspose.com/slides/python-net/aspose.slides/control/frame/). Nó lưu bản trình chiếu đã chỉnh sửa ở định dạng PPTM, sau đó sử dụng [ControlCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/controlcollection/clear/) để lưu một bản sao thứ hai với tất cả các điều khiển ActiveX đã được xóa khỏi slide đó.

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    controls = presentation.slides[0].controls
    text_box = next((control for control in controls if control.name == "TextBox1"), None)
    button = next((control for control in controls if control.name == "CommandButton1"), None)
    text_box_preview = Path("text-box-preview.png")
    button_preview = Path("button-preview.png")

    if text_box is None or button is None or text_box.properties is None or button.properties is None:
        print("The first slide must contain both named controls with editable properties.")
    elif not text_box_preview.is_file() or not button_preview.is_file():
        print("Supply both preview images before updating the controls.")
    else:
        text_box.properties.remove("Value")
        text_box.properties.add("Value", "Changed text")
        button.properties.remove("Caption")
        button.properties.add("Caption", "Show message")

        for control, preview in [(text_box, text_box_preview), (button, button_preview)]:
            image_data = preview.read_bytes()
            control.substitute_picture_format.picture.image = presentation.images.add_image(image_data)

        for control in controls:
            frame = control.frame
            control.frame = slides.ShapeFrame(frame.x, frame.y + 100, frame.width, frame.height, frame.flip_h, frame.flip_v, frame.rotation)

        presentation.save("edited-controls.pptm", slides.export.SaveFormat.PPTM)
        controls.clear()
        presentation.save("removed-controls.pptm", slides.export.SaveFormat.PPTM)
```

## **Thêm một điều khiển Media Player ActiveX**

Để tái sử dụng một điều khiển Windows Media Player đã được cấu hình, bắt đầu với một mẫu mà slide đầu tiên chứa một trình phát có tên `WindowsMediaPlayer1`. [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) sao chép toàn bộ slide vào một bản trình chiếu mới. Ví dụ đặt `URL` của trình phát trong [properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) và lưu slide đã sao chép làm slide duy nhất trong kết quả. Video vẫn ở ngoài, vì vậy chọn một đường dẫn mà trình phát có thể truy cập trong quá trình phát.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as template, slides.Presentation() as presentation:
    slide = presentation.slides.add_clone(template.slides[0])
    player = next((control for control in slide.controls if control.name == "WindowsMediaPlayer1"), None)

    if player is None or player.properties is None:
        print("The template slide must contain a named media player with editable properties.")
    else:
        player.properties.remove("URL")
        player.properties.add("URL", "Wildlife.mp4")
        presentation.slides.remove_at(0)
        presentation.save("linked-video.pptx", slides.export.SaveFormat.PPTX)
```

## **Câu hỏi thường gặp**

**Aspose.Slides có thể giữ nguyên các điều khiển ActiveX mà không chạy chúng không?**  
Có. Aspose.Slides có thể đọc và lưu các điều khiển, bao gồm thuộc tính và vị trí của chúng, mà không kích hoạt chúng.

**Các điều khiển ActiveX khác biệt như thế nào so với đối tượng OLE?**  
Các điều khiển ActiveX cho phép người dùng tương tác với một slide, ví dụ bằng cách nhập văn bản hoặc nhấn nút. Một [OLE object](/slides/vi/python-net/manage-ole/) cho phép slide chứa hoặc liên kết tới nội dung được quản lý bởi một ứng dụng khác, chẳng hạn như một bảng tính Excel.

**Các sự kiện ActiveX vẫn sẽ kích hoạt macro VBA sau khi tôi lưu bản trình chiếu bằng Aspose.Slides không?**  
Lưu bản trình chiếu ở định dạng bật macro như PPTM để giữ lại dự án VBA của nó. PowerPoint cho Windows có thể chạy các trình xử lý sự kiện hiện có khi cài đặt bảo mật cho phép cả điều khiển ActiveX và macro.