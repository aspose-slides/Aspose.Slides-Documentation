---
title: Quản lý các điều khiển ActiveX trong bản trình bày bằng Python
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
- bản trình bày
- Python
- Aspose.Slides
description: "Tìm hiểu cách Aspose.Slides for Python qua Java sử dụng ActiveX để tự động hóa và cải thiện các bản trình bày PowerPoint, cung cấp cho các nhà phát triển khả năng kiểm soát mạnh mẽ đối với các slide."
---
## **Giới thiệu**

Các điều khiển ActiveX được sử dụng trong bản trình bày. Aspose.Slides for Python via Java cho phép bạn thêm và quản lý các điều khiển ActiveX, nhưng chúng phức tạp hơn một chút so với các hình dạng thông thường trong bản trình bày. Aspose.Slides hỗ trợ thêm các điều khiển Media Player ActiveX. Lưu ý rằng các điều khiển ActiveX không phải là hình dạng; chúng không thuộc [ShapeCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/shapecollection/). Thay vào đó chúng thuộc [ControlCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/controlcollection/) riêng. Trong chủ đề này, chúng tôi sẽ hướng dẫn cách làm việc với chúng.

## **Thêm điều khiển Media Player ActiveX vào một Slide**

Để thêm một điều khiển Media Player ActiveX, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và tạo một bản trình bày trống.
1. Truy cập slide mục tiêu trong [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/).
1. Thêm điều khiển Media Player ActiveX bằng phương thức [addControl](https://reference.aspose.com/slides/vi/python-java/aspose.slides/controlcollection/#addControl) được cung cấp bởi [ControlCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/controlcollection/).
1. Truy cập điều khiển Media Player ActiveX và đặt đường dẫn video bằng cách sử dụng các thuộc tính của nó.
1. Lưu bản trình bày dưới dạng tệp PPTX.

Mã mẫu, dựa trên các bước trên, cho thấy cách thêm một điều khiển Media Player ActiveX vào slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

# Tạo một bản trình bày trống.
presentation = Presentation()
try:
    # Thêm điều khiển Media Player ActiveX.
    slide = presentation.getSlides().get_Item(0)
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400)

    # Đặt đường dẫn video.
    control.getProperties().set_Item("URL", "Wildlife.wmv")

    # Lưu bản trình bày.
    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Chỉnh sửa một điều khiển ActiveX**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java cung cấp các thành phần để quản lý các điều khiển ActiveX. Bạn có thể truy cập điều khiển ActiveX đã được thêm vào bản trình bày và chỉnh sửa hoặc xóa nó thông qua các thuộc tính của nó.
{{% /alert %}}

Để quản lý một điều khiển ActiveX đơn giản như hộp văn bản và nút lệnh đơn giản trên slide, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/python-java/aspose.slides/presentation/) và tải bản trình bày có các điều khiển ActiveX.
1. Lấy tham chiếu slide theo chỉ mục của nó.
1. Truy cập các điều khiển ActiveX trong slide bằng cách truy cập [ControlCollection](https://reference.aspose.com/slides/vi/python-java/aspose.slides/controlcollection/).
1. Truy cập điều khiển ActiveX TextBox1 bằng đối tượng [Control](https://reference.aspose.com/slides/vi/python-java/aspose.slides/control/).
1. Thay đổi các thuộc tính của điều khiển ActiveX TextBox1 bao gồm văn bản, phông chữ, chiều cao phông và vị trí khung.
1. Truy cập điều khiển ActiveX thứ hai có tên CommandButton1.
1. Thay đổi chú thích nút, phông chữ và vị trí.
1. Di chuyển vị trí khung của các điều khiển ActiveX.
1. Ghi bản trình bày đã chỉnh sửa ra tệp PPTM.

Mã mẫu, dựa trên các bước trên, cho thấy cách quản lý một điều khiển ActiveX đơn giản:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame
from java.awt import Font, SystemColor
from java.awt.image import BufferedImage
from java.io import ByteArrayOutputStream
from javax.imageio import ImageIO

# Tải bản trình bày có các điều khiển ActiveX.
presentation = Presentation("ActiveX.pptm")
try:
        if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getControls().size() >= 2:
                # Truy cập slide đầu tiên.
                slide = presentation.getSlides().get_Item(0)

                # Thay đổi văn bản của hộp văn bản.
                control = slide.getControls().get_Item(0)

                if str(control.getName()).lower() == "textbox1" and control.getProperties() is not None:
                        new_text = "Changed text"
                        control.getProperties().set_Item("Value", new_text)

                        # Thay đổi hình ảnh thay thế. PowerPoint sẽ thay thế nó trong quá trình kích hoạt ActiveX,
                        # do đó đôi khi có thể để nguyên.
                        image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)

                        graphics = image.getGraphics()
                        graphics.setColor(SystemColor.window)
                        graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

                        font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
                        graphics.setColor(SystemColor.windowText)
                        graphics.setFont(font)
                        graphics.drawString(new_text, 10, 20)

                        graphics.setColor(SystemColor.controlShadow)
                        graphics.drawLine(0, image.getHeight() - 1, 0, 0)
                        graphics.drawLine(0, 0, image.getWidth() - 1, 0)

                        graphics.setColor(SystemColor.controlDkShadow)
                        graphics.drawLine(1, image.getHeight() - 2, 1, 1)
                        graphics.drawLine(1, 1, image.getWidth() - 2, 1)

                        graphics.setColor(SystemColor.controlHighlight)
                        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
                        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

                        graphics.setColor(SystemColor.controlLtHighlight)
                        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
                        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

                        graphics.dispose()

                        image_stream = ByteArrayOutputStream()
                        ImageIO.write(image, "PNG", image_stream)

                        image_bytes = image_stream.toByteArray()
                        substitute_image = presentation.getImages().addImage(image_bytes)
                        control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

                # Thay đổi chú thích nút.
                control = presentation.getSlides().get_Item(0).getControls().get_Item(1)

                if str(control.getName()).lower() == "commandbutton1" and control.getProperties() is not None:
                        new_caption = "Show MessageBox"
                        control.getProperties().set_Item("Caption", new_caption)
                        # Thay đổi hình ảnh thay thế.
                        image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)
                        graphics = image.getGraphics()
                        graphics.setColor(SystemColor.control)
                        graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

                        font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
                        graphics.setColor(SystemColor.windowText)
                        graphics.setFont(font)
                        metrics = graphics.getFontMetrics(font)
                        graphics.drawString(new_caption, (image.getWidth() - metrics.stringWidth(new_caption)) // 2, 20)

                        graphics.setColor(SystemColor.controlLtHighlight)
                        graphics.drawLine(0, image.getHeight() - 1, 0, 0)
                        graphics.drawLine(0, 0, image.getWidth() - 1, 0)

                        graphics.setColor(SystemColor.controlHighlight)
                        graphics.drawLine(1, image.getHeight() - 2, 1, 1)
                        graphics.drawLine(1, 1, image.getWidth() - 2, 1)

                        graphics.setColor(SystemColor.controlShadow)
                        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
                        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

                        graphics.setColor(SystemColor.controlDkShadow)
                        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
                        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

                        graphics.dispose()

                        image_stream = ByteArrayOutputStream()
                        ImageIO.write(image, "PNG", image_stream)

                        image_bytes = image_stream.toByteArray()
                        substitute_image = presentation.getImages().addImage(image_bytes)
                        control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

                # Di chuyển các điều khiển xuống dưới 100 điểm.
                for control in slide.getControls():
                        frame = control.getFrame()
                        new_frame = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
                        control.setFrame(new_frame)
                presentation.save("withActiveX-edited_python.pptm", SaveFormat.Pptm)

                # Xóa các điều khiển.
                presentation.getSlides().get_Item(0).getControls().clear()
                presentation.save("withActiveX-cleared_python.pptm", SaveFormat.Pptm)
        else:
                print("The first slide must contain the TextBox1 and CommandButton1 ActiveX controls.")
finally:
        presentation.dispose()
```

## **Câu hỏi thường gặp**

**Aspose.Slides có giữ lại các điều khiển ActiveX khi đọc và lưu lại nếu chúng không thể thực thi trong môi trường Python không?**

Có. Aspose.Slides coi chúng là một phần của bản trình bày và có thể đọc/điều chỉnh các thuộc tính và khung của chúng; không cần thực thi các điều khiển để giữ chúng.

**Các điều khiển ActiveX khác gì so với đối tượng OLE trong bản trình bày?**

ActiveX là các điều khiển tương tác được quản lý (nút, hộp văn bản, trình phát media), trong khi [OLE](/slides/vi/python-java/manage-ole/) đề cập đến các đối tượng ứng dụng được nhúng (ví dụ, một bảng tính Excel). Chúng được lưu trữ và xử lý khác nhau và có mô hình thuộc tính khác nhau.

**Các sự kiện ActiveX và macro VBA có hoạt động nếu tệp đã được Aspose.Slides chỉnh sửa không?**

Aspose.Slides giữ nguyên markup và siêu dữ liệu hiện có; tuy nhiên, các sự kiện và macro chỉ chạy trong PowerPoint trên Windows khi bảo mật cho phép. Thư viện không thực thi VBA.