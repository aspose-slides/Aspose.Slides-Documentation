---
title: Quản lý các điều khiển ActiveX trong bản trình bày với Python
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
- bản trình bày
- Python
- Aspose.Slides
description: "Tìm hiểu cách Aspose.Slides for Python via .NET tận dụng ActiveX để tự động hoá và nâng cao các bản trình bày PowerPoint, cung cấp cho các nhà phát triển khả năng kiểm soát mạnh mẽ các slide."
---
## **Giới thiệu**

Các điều khiển ActiveX được sử dụng trong các bản trình bày. Aspose.Slides for Python via .NET cho phép bạn quản lý các điều khiển ActiveX, nhưng việc quản lý chúng hơi phức tạp hơn và khác so với các hình dạng bình thường trong bản trình bày. Từ Aspose.Slides for Python via .NET 6.9.0, thành phần hỗ trợ quản lý các điều khiển ActiveX. Hiện tại, bạn có thể truy cập các điều khiển ActiveX đã được thêm vào bản trình bày và sửa đổi hoặc xóa chúng bằng cách sử dụng các thuộc tính khác nhau. Hãy nhớ, các điều khiển ActiveX không phải là hình dạng và không thuộc IShapeCollection của bản trình bày mà là IControlCollection riêng biệt. Bài viết này trình bày cách làm việc với chúng.

## **Sửa đổi các điều khiển ActiveX**
Để quản lý một điều khiển ActiveX đơn giản như hộp văn bản và nút lệnh đơn giản trên một slide:

1. Tạo một thể hiện của lớp Presentation và tải bản trình bày có các điều khiển ActiveX.
1. Lấy tham chiếu slide bằng chỉ mục của nó.
1. Truy cập các điều khiển ActiveX trong slide bằng cách truy cập IControlCollection.
1. Truy cập điều khiển ActiveX TextBox1 bằng đối tượng ControlEx.
1. Thay đổi các thuộc tính khác nhau của điều khiển ActiveX TextBox1 bao gồm văn bản, phông chữ, độ cao phông và vị trí khung.
1. Truy cập điều khiển truy cập thứ hai có tên CommandButton1.
1. Thay đổi chú thích nút, phông chữ và vị trí.
1. Di chuyển vị trí của các khung điều khiển ActiveX.
1. Ghi bản trình bày đã sửa đổi vào tệp PPTX.

Đoạn mã dưới đây cập nhật các điều khiển ActiveX trên các slide của bản trình bày như được hiển thị bên dưới.

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import io

# Truy cập bản trình bày có các điều khiển ActiveX
with slides.Presentation(path + "ActiveX.pptm") as presentation:
    # Truy cập slide đầu tiên trong bản trình bày
    slide = presentation.slides[0]

    # thay đổi văn bản TextBox
    control = slide.controls[0]

    if control.name == "TextBox1" and control.properties != None:
        newText = "Changed text"
        control.properties.remove("Value")
        control.properties.add("Value", newText)

        # thay đổi hình ảnh thay thế. PowerPoint sẽ thay thế hình ảnh này trong quá trình kích hoạt ActiveX, vì vậy đôi khi có thể để nguyên hình ảnh.

        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            # font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                graphics.draw_string(newText, font, brush, 10, 4)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, [
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [
                        draw.PointF(1, bmp.height - 1), 
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1)])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen,
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)

    # thay đổi chú thích nút
    control = slide.controls[1]

    if control.name == "CommandButton1" and control.properties != None:
        newCaption = "MessageBox"
        control.properties.remove("Caption")
        control.properties.add("Caption", newCaption)

        # thay đổi thay thế
        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.CONTROL)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            #font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                textSize = graphics.measure_string(newCaption, font, 65535)
                graphics.draw_string(newCaption, font, brush, 
                    (bmp.width - textSize.width) / 2, 
                    (bmp.height - textSize.height) / 2)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])
            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)
    
    # Di chuyển khung ActiveX xuống 100 điểm
    for ctl in slide.controls:
        frame = control.frame
        control.frame = slides.ShapeFrame(
            frame.x, 
            frame.y + 100, 
            frame.width, 
            frame.height, 
            frame.flip_h, 
            frame.flip_v, 
            frame.rotation)

    # Lưu bản trình bày với các điều khiển ActiveX đã chỉnh sửa
    presentation.save("withActiveX-edited_out.pptm", slides.export.SaveFormat.PPTM)


    # Bây giờ loại bỏ các điều khiển
    slide.controls.clear()

    # Lưu bản trình bày với các điều khiển ActiveX đã xóa
    presentation.save("withActiveX.cleared_out.pptm", slides.export.SaveFormat.PPTM)
```

## **Thêm điều khiển Media Player ActiveX**
Để thêm điều khiển Media Player ActiveX, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp Presentation và tải bản trình bày mẫu có các điều khiển Media Player ActiveX.
1. Tạo một thể hiện của lớp Presentation đích và tạo một bản trình bày trống.
1. Sao chép slide có điều khiển Media Player ActiveX trong bản trình bày mẫu sang Presentation đích.
1. Truy cập slide đã sao chép trong Presentation đích.
1. Truy cập các điều khiển ActiveX trong slide bằng cách truy cập IControlCollection.
1. Truy cập điều khiển Media Player ActiveX và đặt đường dẫn video bằng cách sử dụng các thuộc tính của nó.
1. Lưu bản trình bày vào tệp PPTX.

```py
import aspose.slides as slides

# Tạo đối tượng lớp Presentation đại diện cho tệp PPTX
with slides.Presentation(path + "template.pptx") as presentation:

    # Tạo một đối tượng bản trình bày trống
    with slides.Presentation() as newPresentation:

        # Xóa slide mặc định
        newPresentation.slides.remove_at(0)

        # Sao chép slide có điều khiển Media Player ActiveX
        newPresentation.slides.insert_clone(0, presentation.slides[0])

        # Truy cập điều khiển Media Player ActiveX và đặt đường dẫn video
        prop = newPresentation.slides[0].controls[0].properties

        prop.remove("URL")
        prop.add("URL", "Wildlife.mp4")

        # Lưu bản trình bày
        newPresentation.save("LinkingVideoActiveXControl_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Aspose.Slides có giữ nguyên các điều khiển ActiveX khi đọc và lưu lại nếu chúng không thể thực thi trong môi trường Python không?**

Có. Aspose.Slides coi chúng là một phần của bản trình bày và có thể đọc/điều chỉnh các thuộc tính và khung của chúng; việc thực thi các điều khiển không cần thiết để giữ chúng.

**Các điều khiển ActiveX khác gì so với các đối tượng OLE trong bản trình bày?**

Các điều khiển ActiveX là các điều khiển tương tác được quản lý (nút, hộp văn bản, trình phát media), trong khi [OLE](/slides/vi/python-net/manage-ole/) đề cập đến các đối tượng ứng dụng nhúng (ví dụ, một bảng tính Excel). Chúng được lưu và xử lý một cách khác nhau và có các mô hình thuộc tính khác nhau.

**Các sự kiện ActiveX và macro VBA có hoạt động nếu tệp đã được Aspose.Slides sửa đổi không?**

Aspose.Slides giữ nguyên markup và metadata hiện có; tuy nhiên, các sự kiện và macro chỉ chạy trong PowerPoint trên Windows khi bảo mật cho phép. Thư viện không thực thi VBA.