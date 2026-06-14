---
title: "Quản lý các điều khiển ActiveX trong bản thuyết trình trên Android"
linktitle: "ActiveX"
type: docs
weight: 80
url: /vi/androidjava/activex/
keywords:
- ActiveX
- điều khiển ActiveX
- quản lý ActiveX
- thêm ActiveX
- sửa đổi ActiveX
- trình phát đa phương tiện
- PowerPoint
- bản thuyết trình
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách Aspose.Slides cho Android qua Java sử dụng ActiveX để tự động hóa và nâng cao các bản thuyết trình PowerPoint, cung cấp cho các nhà phát triển khả năng kiểm soát mạnh mẽ đối với các slide."
---
## **Giới thiệu**

Các điều khiển ActiveX được sử dụng trong các bản thuyết trình. Aspose.Slides cho Android qua Java cho phép bạn thêm và quản lý các điều khiển ActiveX, nhưng chúng hơi phức tạp hơn so với các hình dạng thông thường trong bản thuyết trình. Chúng tôi đã triển khai hỗ trợ thêm điều khiển Media Player Active trong Aspose.Slides. Lưu ý rằng các điều khiển ActiveX không phải là hình dạng; chúng không phải là một phần của [IShapeCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapecollection/). Thay vào đó, chúng là một phần của [IControlCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icontrolcollection/) riêng. Trong chủ đề này, chúng tôi sẽ chỉ cho bạn cách làm việc với chúng.

## **Thêm điều khiển Media Player ActiveX vào một slide**
Để thêm một điều khiển Media Player ActiveX, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation) và tạo một bản thuyết trình trống.
1. Truy cập slide mục tiêu trong [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation).
1. Thêm điều khiển Media Player ActiveX bằng phương thức [addControl](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) được cung cấp bởi [IControlCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icontrolcollection/).
1. Truy cập điều khiển Media Player ActiveX và đặt đường dẫn video bằng cách sử dụng các thuộc tính của nó.
1. Lưu bản thuyết trình dưới dạng tệp PPTX.

Mã mẫu này, dựa trên các bước trên, cho thấy cách thêm điều khiển Media Player ActiveX vào một slide:

```java
// Tạo thể hiện bản thuyết trình trống
Presentation pres = new Presentation();
try {
    // Thêm điều khiển Media Player ActiveX
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Truy cập điều khiển Media Player ActiveX và thiết lập đường dẫn video
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Lưu bản thuyết trình
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Sửa đổi một điều khiển ActiveX**
{{% alert color="primary" %}} 

Aspose.Slides cho Android qua Java 7.1.0 và các phiên bản mới hơn được trang bị các thành phần để quản lý các điều khiển ActiveX. Bạn có thể truy cập vào các điều khiển ActiveX đã được thêm trong bản thuyết trình và sửa đổi hoặc xóa chúng thông qua các thuộc tính.

{{% /alert %}} 

Để quản lý một điều khiển ActiveX đơn giản như hộp văn bản và nút lệnh đơn giản trên một slide, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation) và tải bản thuyết trình có chứa các điều khiển ActiveX.
1. Lấy tham chiếu slide bằng chỉ số của nó.
1. Truy cập các điều khiển ActiveX trong slide bằng cách truy cập [IControlCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icontrolcollection/).
1. Truy cập điều khiển ActiveX TextBox1 bằng đối tượng [IControl](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icontrol/).
1. Thay đổi các thuộc tính của điều khiển ActiveX TextBox1 bao gồm văn bản, phông chữ, chiều cao phông chữ và vị trí khung.
1. Truy cập điều khiển thứ hai có tên CommandButton1.
1. Thay đổi chú thích nút, phông chữ và vị trí.
1. Di chuyển vị trí của các khung điều khiển ActiveX.
1. Ghi bản thuyết trình đã sửa đổi ra tệp PPTX.

Mã mẫu này, dựa trên các bước trên, cho thấy cách quản lý một điều khiển ActiveX đơn giản: 

```java
// Truy cập bản thuyết trình có các điều khiển ActiveX
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // Truy cập slide đầu tiên trong bản thuyết trình
    ISlide slide = pres.getSlides().get_Item(0);

    // đổi văn bản TextBox
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // Thay đổi hình ảnh thay thế. PowerPoint sẽ thay thế hình này trong quá trình kích hoạt ActiveX,
        // do đó đôi khi có thể để hình ảnh không thay đổi.
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
        // Thay đổi hình ảnh thay thế
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

## **FAQ**

**Aspose.Slides có giữ lại các điều khiển ActiveX khi đọc và lưu lại nếu chúng không thể thực thi trong môi trường Java không?**

Có. Aspose.Slides coi chúng là một phần của bản thuyết trình và có thể đọc/điều chỉnh các thuộc tính và khung của chúng; không cần thực thi các điều khiển để giữ lại chúng.

**Các điều khiển ActiveX khác biệt như thế nào so với các đối tượng OLE trong bản thuyết trình?**

Các điều khiển ActiveX là các điều khiển tương tác được quản lý (nút, hộp văn bản, trình phát phương tiện), trong khi [OLE](/slides/vi/androidjava/manage-ole/) đề cập đến các đối tượng ứng dụng được nhúng (ví dụ, một bảng tính Excel). Chúng được lưu trữ và xử lý theo cách khác nhau và có mô hình thuộc tính riêng.

**Các sự kiện ActiveX và macro VBA có hoạt động nếu tệp đã được Aspose.Slides sửa đổi không?**

Aspose.Slides giữ lại các markup và metadata hiện có; tuy nhiên, các sự kiện và macro chỉ chạy bên trong PowerPoint trên Windows khi bảo mật cho phép. Thư viện không thực thi VBA.