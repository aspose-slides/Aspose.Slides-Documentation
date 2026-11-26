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
description: "Chỉnh sửa các hộp văn bản và nút ActiveX, cập nhật bản xem trước của điều khiển, và tái sử dụng điều khiển Windows Media Player trong các bản trình chiếu PowerPoint với Aspose.Slides cho Java."
---
## **Giới thiệu**

Các điều khiển ActiveX cung cấp cho slide PowerPoint các yếu tố tương tác như hộp văn bản, nút lệnh và trình phát media. Aspose.Slides for Java cung cấp các điều khiển của slide thông qua [IBaseSlide.getControls](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getControls--). Sử dụng bộ sưu tập này để chỉnh sửa một điều khiển, di chuyển nó trên slide hoặc xóa nó.

## **Liệt kê các điều khiển ActiveX và các thuộc tính đã lưu của chúng**

Để kiểm tra một mẫu không quen thuộc, mở nó để đọc và lặp qua các điều khiển trên mỗi slide. Ví dụ báo cáo số slide, tên điều khiển, [getClassId](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getClassId--), và mỗi cặp khóa-giá trị trong [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--). Nó đọc bản trình chiếu mà không kích hoạt các điều khiển, không gọi sự kiện hay macro, không thay đổi giá trị, và không lưu tệp.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    for (int i = 0; i < presentation.getSlides().size(); i++) {
        for (IControl control : presentation.getSlides().get_Item(i).getControls()) {
            System.out.printf("Slide %d | %s | %s%n", i + 1, control.getName(), control.getClassId());
            IControlPropertiesCollection properties = control.getProperties();
            if (properties == null) {
                System.out.println("  Properties unavailable");
                continue;
            }
            if (properties.getCount() == 0) {
                System.out.println("  []");
            }
            for (String name : properties.getNamesOfProperties()) {
                System.out.printf("  %s = %s%n", name, properties.get_Item(name));
            }
        }
    }
} finally {
    presentation.dispose();
}
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

Một bộ sưu tập thuộc tính rỗng hiển thị dưới dạng `[]`. Đối với các điều khiển sử dụng lưu trữ nhị phân, [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--) có thể trả về `null`, được hiển thị là `Properties unavailable`. Nếu bạn chỉ cần tên, hãy sử dụng [getNamesOfProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/#getNamesOfProperties--) sau khi kiểm tra null. Báo cáo liệt kê các thuộc tính có sẵn từ bản trình chiếu. Một điều khiển có thể hỗ trợ các thuộc tính bổ sung tại thời gian chạy.

## **Chỉnh sửa các điều khiển ActiveX**

Ví dụ yêu cầu một bản trình chiếu hỗ trợ macro có một hộp văn bản có tên `TextBox1` và một nút lệnh có tên `CommandButton1` trên slide đầu tiên. Nó sử dụng [control properties collection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) để thay đổi giá trị hộp văn bản và nhãn nút. Mỗi điều khiển cũng có một bản xem trước tĩnh mà PowerPoint có thể hiển thị trước khi kích hoạt. Cung cấp một tệp PNG cho mỗi điều khiển để hiển thị văn bản và giao diện đã cập nhật. Ví dụ gán các hình ảnh này thông qua [IControl.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getSubstitutePictureFormat--).

Ví dụ di chuyển mọi điều khiển trên slide đầu tiên xuống 100 điểm bằng cách đặt khung của chúng với [IControl.setFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#setFrame-com.aspose.slides.IShapeFrame-). Nó lưu bản trình chiếu đã chỉnh sửa ở định dạng PPTM, sau đó sử dụng [IControlCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolcollection/#clear--) để lưu một bản sao thứ hai với tất cả các điều khiển ActiveX đã bị xóa khỏi slide đó.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    IControlCollection controls = presentation.getSlides().get_Item(0).getControls();
    IControl textBox = null;
    IControl button = null;
    for (IControl control : controls) {
        if ("TextBox1".equals(control.getName())) {
            textBox = control;
        } else if ("CommandButton1".equals(control.getName())) {
            button = control;
        }
    }
    if (textBox == null || button == null || textBox.getProperties() == null || button.getProperties() == null) {
        System.out.println("The first slide must contain both named controls with editable properties.");
        return;
    }

    Path textBoxPath = Paths.get("text-box-preview.png");
    Path buttonPath = Paths.get("button-preview.png");
    byte[] textBoxBytes = Files.readAllBytes(textBoxPath);
    byte[] buttonBytes = Files.readAllBytes(buttonPath);
    IPPImage textBoxPreview = presentation.getImages().addImage(textBoxBytes);
    IPPImage buttonPreview = presentation.getImages().addImage(buttonBytes);
    textBox.getProperties().set_Item("Value", "Changed text");
    button.getProperties().set_Item("Caption", "Show message");
    textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
    button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

    for (IControl control : controls) {
        IShapeFrame frame = control.getFrame();
        ShapeFrame moved = new ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation());
        control.setFrame(moved);
    }
    presentation.save("edited-controls.pptm", SaveFormat.Pptm);

    controls.clear();
    presentation.save("removed-controls.pptm", SaveFormat.Pptm);
} catch (IOException e) {
    System.out.println("Could not read a control preview: " + e.getMessage());
} finally {
    presentation.dispose();
}
```

## **Thêm điều khiển Media Player ActiveX**

Để tái sử dụng một điều khiển Windows Media Player đã được cấu hình, bắt đầu với một mẫu mà slide đầu tiên chứa một trình phát có tên `WindowsMediaPlayer1`. [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) sao chép toàn bộ slide vào một bản trình chiếu mới. Ví dụ đặt `URL` của trình phát trong [properties collection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) và lưu slide đã sao chép làm slide duy nhất trong kết quả. Video vẫn ở ngoài, vì vậy hãy chọn một đường dẫn mà trình phát có thể truy cập trong quá trình phát.

```java
import com.aspose.slides.*;

Presentation template = new Presentation("template.pptx");
try {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().addClone(template.getSlides().get_Item(0));
        IControl player = null;
        for (IControl control : slide.getControls()) {
            if ("WindowsMediaPlayer1".equals(control.getName())) {
                player = control;
                break;
            }
        }
        if (player == null || player.getProperties() == null) {
            System.out.println("The template slide must contain a named media player with editable properties.");
            return;
        }
        player.getProperties().set_Item("URL", "Wildlife.mp4");
        
        presentation.getSlides().removeAt(0);
        presentation.save("linked-video.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    template.dispose();
}
```

## **Câu hỏi thường gặp**

**Aspose.Slides có thể giữ lại các điều khiển ActiveX mà không chạy chúng không?**

Có. Aspose.Slides có thể đọc và lưu các điều khiển, bao gồm các thuộc tính và vị trí của chúng, mà không kích hoạt chúng.

**Các điều khiển ActiveX khác gì so với đối tượng OLE?**

Các điều khiển ActiveX cho phép người dùng tương tác với slide, ví dụ bằng cách nhập văn bản hoặc nhấn nút. Một [đối tượng OLE](/slides/vi/java/manage-ole/) cho phép slide chứa hoặc liên kết tới nội dung được quản lý bởi một ứng dụng khác, chẳng hạn như một bảng tính Excel.

**Sự kiện ActiveX có vẫn kích hoạt macro VBA sau khi tôi lưu bản trình chiếu bằng Aspose.Slides không?**

Lưu bản trình chiếu ở định dạng hỗ trợ macro như PPTM để giữ lại dự án VBA của nó. PowerPoint cho Windows có thể chạy các trình xử lý sự kiện hiện có khi cài đặt bảo mật cho phép cả điều khiển ActiveX và macro.