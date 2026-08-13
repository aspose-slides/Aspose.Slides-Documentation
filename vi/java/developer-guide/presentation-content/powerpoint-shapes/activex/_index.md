---
title: Quản lý các điều khiển ActiveX trong bản trình chiếu bằng Java
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
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tìm hiểu cách Aspose.Slides for Java sử dụng ActiveX để tự động hóa và nâng cao các bản trình chiếu PowerPoint, cung cấp cho nhà phát triển khả năng kiểm soát mạnh mẽ đối với các slide."
---
## **Giới thiệu**

Điều khiển ActiveX được sử dụng trong các bản trình chiếu. Aspose.Slides for Java cho phép bạn thêm và quản lý các điều khiển ActiveX, nhưng chúng khó quản lý hơn một chút so với các hình dạng thông thường trong bản trình chiếu. Chúng tôi đã triển khai hỗ trợ thêm điều khiển Media Player Active trong Aspose.Slides. Lưu ý rằng các điều khiển ActiveX không phải là hình dạng; chúng không phải là một phần của bản trình chiếu’s[IShapeCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/). Chúng là một phần của[IControlCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icontrolcollection/) riêng biệt. Trong chủ đề này, chúng tôi sẽ cho bạn thấy cách làm việc với chúng. 

## **Thêm điều khiển Media Player ActiveX vào một slide**
Để thêm một điều khiển Media Player ActiveX, thực hiện các bước sau:

1. Tạo một đối tượng của lớp[Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation) và tạo một bản trình chiếu trống.  
2. Truy cập slide mục tiêu trong[Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation).  
3. Thêm điều khiển Media Player ActiveX bằng phương thức[addControl](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) được cung cấp bởi[IControlCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icontrolcollection/).  
4. Truy cập điều khiển Media Player ActiveX và đặt đường dẫn video bằng cách sử dụng các thuộc tính của nó.  
5. Lưu bản trình chiếu dưới dạng tệp PPTX.  

Đoạn mã mẫu dưới đây, dựa trên các bước ở trên, cho thấy cách thêm điều khiển Media Player ActiveX vào một slide:

```java
import com.aspose.slides.*;

// Tạo instance bản trình chiếu trống
Presentation pres = new Presentation();
try {
    // Thêm điều khiển Media Player ActiveX
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Truy cập điều khiển Media Player ActiveX và đặt đường dẫn video
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Lưu bản trình chiếu
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Chỉnh sửa một điều khiển ActiveX**
{{% alert color="info" %}} 

Aspose.Slides for Java 7.1.0 và các phiên bản mới hơn được trang bị các thành phần để quản lý các điều khiển ActiveX. Bạn có thể truy cập các điều khiển ActiveX đã được thêm vào bản trình chiếu của mình và sửa đổi hoặc xóa chúng thông qua các thuộc tính của chúng.

{{% /alert %}} 

Để quản lý một điều khiển ActiveX đơn giản như hộp văn bản và nút lệnh đơn giản trên một slide, thực hiện các bước sau:

1. Tạo một đối tượng của lớp[Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation) và tải bản trình chiếu có các điều khiển ActiveX trong đó.  
2. Lấy tham chiếu slide theo chỉ số của nó.  
3. Truy cập các điều khiển ActiveX trên slide bằng cách truy cập[IControlCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icontrolcollection/).  
4. Truy cập điều khiển ActiveX TextBox1 bằng đối tượng[IControl](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icontrol/).  
5. Thay đổi các thuộc tính của điều khiển ActiveX TextBox1 bao gồm văn bản, phông chữ, độ cao phông chữ và vị trí khung.  
6. Truy cập điều khiển thứ hai có tên CommandButton1.  
7. Thay đổi chú thích nút, phông chữ và vị trí.  
8. Định vị lại các khung của các điều khiển ActiveX.  
9. Ghi bản trình chiếu đã được chỉnh sửa thành tệp PPTX.  

Đoạn mã mẫu dưới đây, dựa trên các bước ở trên, cho thấy cách quản lý một điều khiển ActiveX đơn giản:

```java
import com.aspose.slides.*;
import java.awt.FontMetrics;
import java.awt.SystemColor;
import java.awt.image.BufferedImage;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import javax.imageio.ImageIO;

// Truy cập bản trình chiếu có các điều khiển ActiveX
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // Truy cập slide đầu tiên trong bản trình chiếu
    ISlide slide = pres.getSlides().get_Item(0);

    // đổi nội dung TextBox text
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

## **Câu hỏi thường gặp**

### Aspose.Slides có giữ nguyên các điều khiển ActiveX khi đọc và lưu lại nếu chúng không thể được thực thi trong môi trường chạy Java không?

Có. Aspose.Slides coi chúng là một phần của bản trình chiếu và có thể đọc/điều chỉnh các thuộc tính và khung của chúng; không cần thực thi các điều khiển để giữ nguyên chúng.

### Các điều khiển ActiveX khác gì so với đối tượng OLE trong bản trình chiếu?

Các điều khiển ActiveX là các điều khiển tương tác được quản lý (nút, hộp văn bản, trình phát media), trong khi[OLE](/slides/vi/java/manage-ole/) đề cập đến các đối tượng ứng dụng nhúng (ví dụ, một bảng tính Excel). Chúng được lưu trữ và xử lý khác nhau và có mô hình thuộc tính khác nhau.

### Các sự kiện ActiveX và macro VBA có hoạt động nếu tệp đã được Aspose.Slides chỉnh sửa không?

Aspose.Slides giữ nguyên các markup và siêu dữ liệu hiện có; tuy nhiên, các sự kiện và macro chỉ chạy trong PowerPoint trên Windows khi bảo mật cho phép. Thư viện không thực thi VBA.