---
title: Quản lý các điều khiển ActiveX trong bản trình chiếu bằng JavaScript
linktitle: ActiveX
type: docs
weight: 80
url: /vi/nodejs-java/activex/
keywords:
- ActiveX
- Điều khiển ActiveX
- Quản lý ActiveX
- Thêm ActiveX
- Chỉnh sửa ActiveX
- Trình phát media
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách Aspose.Slides cho Node.js qua Java sử dụng ActiveX để tự động hoá và nâng cao các bản trình chiếu PowerPoint, mang lại cho nhà phát triển khả năng kiểm soát mạnh mẽ các slide."
---
## **Giới thiệu**

Các điều khiển ActiveX được sử dụng trong các bản trình chiếu. Aspose.Slides cho Node.js thông qua Java cho phép bạn thêm và quản lý các điều khiển ActiveX, nhưng chúng hơi phức tạp hơn so với các hình dạng thông thường trong bản trình chiếu. Chúng tôi đã triển khai hỗ trợ thêm điều khiển Media Player Active trong Aspose.Slides. Lưu ý rằng các điều khiển ActiveX không phải là hình dạng; chúng không thuộc phần [ShapeCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapecollection/). Chúng là một phần của [ControlCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/controlcollection/) riêng biệt. Trong chủ đề này, chúng tôi sẽ chỉ cho bạn cách làm việc với chúng.

## **Thêm điều khiển Media Player ActiveX vào Slide**
Để thêm điều khiển Media Player ActiveX, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation) và khởi tạo một bản trình chiếu trống.  
2. Truy cập slide mục tiêu trong [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation).  
3. Thêm điều khiển Media Player ActiveX bằng cách sử dụng phương thức [addControl](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ControlCollection#addControl-int-float-float-float-float-) được cung cấp bởi [ControlCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/controlcollection/).  
4. Truy cập vào điều khiển Media Player ActiveX và đặt đường dẫn video bằng cách sử dụng các thuộc tính của nó.  
5. Lưu bản trình chiếu dưới dạng tệp PPTX.

Mã mẫu này, dựa trên các bước trên, cho thấy cách thêm điều khiển Media Player ActiveX vào một slide:

```javascript
// Tạo một thể hiện bản trình chiếu trống
var pres = new aspose.slides.Presentation();
try {
    // Thêm điều khiển Media Player ActiveX
    pres.getSlides().get_Item(0).getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 100, 100, 400, 400);
    // Truy cập điều khiển Media Player ActiveX và đặt đường dẫn video
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("java.net.URL", "Wildlife.wmv");
    // Lưu bản trình chiếu
    pres.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Chỉnh sửa điều khiển ActiveX**

Để quản lý một điều khiển ActiveX đơn giản như hộp văn bản và nút lệnh đơn giản trên một slide, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation) và tải bản trình chiếu có chứa các điều khiển ActiveX.  
2. Lấy tham chiếu slide theo chỉ mục của nó.  
3. Truy cập các điều khiển ActiveX trong slide bằng cách truy cập [ControlCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/controlcollection/).  
4. Truy cập điều khiển ActiveX TextBox1 bằng đối tượng [Control](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/control/).  
5. Thay đổi các thuộc tính của điều khiển ActiveX TextBox1 bao gồm văn bản, phông chữ, chiều cao phông và vị trí khung.  
6. Truy cập điều khiển thứ hai có tên CommandButton1.  
7. Thay đổi tiêu đề nút, phông chữ và vị trí.  
8. Di chuyển vị trí của các khung điều khiển ActiveX.  
9. Ghi bản trình chiếu đã chỉnh sửa ra tệp PPTX.

Mã mẫu này, dựa trên các bước trên, cho thấy cách quản lý một điều khiển ActiveX đơn giản:

```javascript
const imageio = java.import("javax.imageio.ImageIO");
// Truy cập bản trình chiếu có các điều khiển ActiveX
var pres = new aspose.slides.Presentation("ActiveX.pptm");
try {
    // Truy cập slide đầu tiên trong bản trình chiếu
    var slide = pres.getSlides().get_Item(0);
    // đổi nội dung TextBox
    var control = slide.getControls().get_Item(0);
    if (control.getName().toUpperCase() === "TextBox1".toUpperCase() && (control.getProperties() != null)) {
        var newText = "Changed text";
        control.getProperties().set_Item("Value", newText);
        // Thay đổi ảnh thay thế. PowerPoint sẽ thay thế ảnh này trong quá trình kích hoạt ActiveX,
        // vì đôi khi việc để ảnh không thay đổi là được.
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "window"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // Thay đổi chú thích nút
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);
    if (control.getName().toUpperCase() === "CommandButton1".toUpperCase() && (control.getProperties() != null)) {
        var newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Thay đổi ảnh thay thế
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "control"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        var metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, java.newFloat((image.getWidth() - metrics.stringWidth(newCaption)) / 2), 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // di chuyển xuống 100 điểm
    for (let i = 0; i < pres.getSlides().get_Item(0).getControls().size(); i++) {
        let ctl = pres.getSlides().get_Item(0).getControls().get_Item(i);
        var frame = ctl.getFrame();
        ctl.setFrame(new aspose.slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), java.newByte(frame.getFlipH()), java.newByte(frame.getFlipV()), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", aspose.slides.SaveFormat.Pptm);
    // xóa bỏ các điều khiển
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", aspose.slides.SaveFormat.Pptm);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Aspose.Slides có giữ lại các điều khiển ActiveX khi đọc và lưu lại nếu chúng không thể thực thi trong môi trường Python không?**

Có. Aspose.Slides coi chúng là một phần của bản trình chiếu và có thể đọc/điều chỉnh các thuộc tính và khung của chúng; không cần thực thi các điều khiển để giữ lại chúng.

**Các điều khiển ActiveX khác gì so với các đối tượng OLE trong bản trình chiếu?**

Các điều khiển ActiveX là các điều khiển tương tác được quản lý (nút, hộp văn bản, trình phát media), trong khi [OLE](/slides/vi/nodejs-java/manage-ole/) đề cập đến các đối tượng ứng dụng được nhúng (ví dụ, một bảng tính Excel). Chúng được lưu trữ và xử lý khác nhau và có mô hình thuộc tính khác nhau.

**Các sự kiện ActiveX và macro VBA có hoạt động nếu tệp đã được Aspose.Slides chỉnh sửa không?**

Aspose.Slides giữ lại các markup và metadata hiện có; tuy nhiên, các sự kiện và macro chỉ chạy trong PowerPoint trên Windows khi bảo mật cho phép. Thư viện không thực thi VBA.