---
title: Quản lý các điều khiển ActiveX trong bài thuyết trình bằng Java
linktitle: ActiveX
type: docs
weight: 80
url: /vi/java/activex/
keywords:
- ActiveX
- điều khiển ActiveX
- quản lý ActiveX
- thêm ActiveX
- sửa đổi ActiveX
- trình phát media
- PowerPoint
- bài thuyết trình
- Java
- Aspose.Slides
description: "Tìm hiểu cách Aspose.Slides for Java tận dụng ActiveX để tự động hoá và cải thiện các bài thuyết trình PowerPoint, cung cấp cho nhà phát triển khả năng kiểm soát mạnh mẽ trên các slide."
---
## **Giới thiệu**

Các điều khiển ActiveX được sử dụng trong các bài thuyết trình. Aspose.Slides for Java cho phép bạn thêm và quản lý các điều khiển ActiveX, nhưng chúng khó quản lý hơn một chút so với các hình dạng bình thường trong bài thuyết trình. Chúng tôi đã triển khai hỗ trợ thêm điều khiển Media Player Active trong Aspose.Slides. Lưu ý rằng các điều khiển ActiveX không phải là hình dạng; chúng không phải là một phần của bản trình bày's [IShapeCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/). Chúng thuộc về [IControlCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icontrolcollection/) riêng biệt. Trong chủ đề này, chúng tôi sẽ hướng dẫn bạn cách làm việc với chúng. 

## **Thêm điều khiển Media Player ActiveX vào một slide**
Để thêm một điều khiển Media Player ActiveX, làm theo các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation) và tạo một bản trình bày trống.
2. Truy cập slide mục tiêu trong [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation).
3. Thêm điều khiển Media Player ActiveX bằng phương thức [addControl](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) được cung cấp bởi [IControlCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icontrolcollection/).
4. Truy cập điều khiển Media Player ActiveX và đặt đường dẫn video bằng cách sử dụng các thuộc tính của nó.
5. Lưu bản trình bày dưới dạng tệp PPTX.

Mã mẫu này, dựa trên các bước trên, cho thấy cách thêm điều khiển Media Player ActiveX vào một slide:

```java
// Tạo một thể hiện bản trình bày trống
Presentation pres = new Presentation();
try {
    // Thêm điều khiển Media Player ActiveX
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Truy cập điều khiển Media Player ActiveX và đặt đường dẫn video
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Lưu bản trình bày
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Sửa đổi một điều khiển ActiveX**
{{% alert color="primary" %}} 

Aspose.Slides for Java 7.1.0 và các phiên bản mới hơn được trang bị các thành phần để quản lý các điều khiển ActiveX. Bạn có thể truy cập điều khiển ActiveX đã được thêm vào bản trình bày và sửa đổi hoặc xóa nó thông qua các thuộc tính của nó.

{{% /alert %}} 

Để quản lý một điều khiển ActiveX đơn giản như hộp văn bản và nút lệnh đơn giản trên một slide, làm như sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation) và tải bản trình bày có chứa các điều khiển ActiveX.
2. Lấy tham chiếu slide bằng chỉ số của nó.
3. Truy cập các điều khiển ActiveX trong slide bằng cách truy cập [IControlCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icontrolcollection/).
4. Truy cập điều khiển ActiveX TextBox1 bằng đối tượng [IControl](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icontrol/).
5. Thay đổi các thuộc tính của điều khiển ActiveX TextBox1 bao gồm văn bản, phông chữ, kích thước phông và vị trí khung.
6. Truy cập điều khiển thứ hai có tên CommandButton1.
7. Thay đổi nhãn nút, phông chữ và vị trí.
8. Di chuyển vị trí của khung các điều khiển ActiveX.
9. Ghi bản trình bày đã sửa đổi vào tệp PPTX.

Mã mẫu này, dựa trên các bước trên, cho thấy cách quản lý một điều khiển ActiveX đơn giản: 

```java
// Truy cập bản trình bày có các điều khiển ActiveX
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // Truy cập slide đầu tiên trong bản trình bày
    ISlide slide = pres.getSlides().get_Item(0);

    // đổi văn bản TextBox
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // Thay đổi hình ảnh thay thế. PowerPoint sẽ thay thế hình ảnh này khi kích hoạt ActiveX,
        // vì vậy đôi khi có thể để nguyên hình ảnh.
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);

        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.window);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlDkShadow);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

        graphics.dispose();

        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        ImageIO.write(image, "PNG", baos);

        control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
    }

    // Thay đổi chú thích nút
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Thay đổi thay thế
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);
        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.control);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        FontMetrics metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, (image.getWidth() - metrics.stringWidth(newCaption)) / 2, 20);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlDkShadow);
                graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
                graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

                graphics.dispose();

                ByteArrayOutputStream baos = new ByteArrayOutputStream();
                ImageIO.write(image, "PNG", baos);

                control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
            }

            // di chuyển xuống 100 điểm
            for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
                IShapeFrame frame = ctl.getFrame();
                ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                        frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
            }
            pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

            // xóa các điều khiển
            pres.getSlides().get_Item(0).getControls().clear();
            pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
        } catch(IOException e) {
        } finally {
            if (pres != null) pres.dispose();
        }
```

## **Câu hỏi thường gặp**

**Aspose.Slides có giữ lại các điều khiển ActiveX khi đọc và lưu lại nếu chúng không thể thực thi trong môi trường Java không?**

Có. Aspose.Slides xem chúng như một phần của bản trình bày và có thể đọc/điều chỉnh các thuộc tính và khung của chúng; không cần thực thi các điều khiển để giữ lại chúng.

**Các điều khiển ActiveX khác gì so với các đối tượng OLE trong bản trình bày?**

Các điều khiển ActiveX là các điều khiển tương tác được quản lý (nút, hộp văn bản, trình phát media), trong khi [OLE](/slides/vi/java/manage-ole/) đề cập đến các đối tượng ứng dụng được nhúng (ví dụ, một bảng tính Excel). Chúng được lưu trữ và xử lý khác nhau và có các mô hình thuộc tính riêng.

**Các sự kiện ActiveX và macro VBA có hoạt động nếu tệp đã được Aspose.Slides chỉnh sửa không?**

Aspose.Slides giữ nguyên markup và siêu dữ liệu hiện có; tuy nhiên, các sự kiện và macro chỉ chạy trong PowerPoint trên Windows khi bảo mật cho phép. Thư viện không thực thi VBA.