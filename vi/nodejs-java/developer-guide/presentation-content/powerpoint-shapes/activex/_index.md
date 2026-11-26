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
- Sửa đổi ActiveX
- Trình phát media
- PowerPoint
- Bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Chỉnh sửa hộp văn bản và nút ActiveX, cập nhật hình ảnh xem trước của điều khiển, và tái sử dụng một điều khiển Windows Media Player trong các bản trình chiếu PowerPoint với Aspose.Slides cho Node.js qua Java."
---
## **Giới thiệu**

Các điều khiển ActiveX cung cấp cho một slide PowerPoint các yếu tố tương tác như hộp văn bản, nút lệnh và trình phát đa phương tiện. Aspose.Slides cho Node.js thông qua Java cung cấp các điều khiển của slide thông qua [BaseSlide.getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getControls). Sử dụng bộ sưu tập này để chỉnh sửa một điều khiển, di chuyển nó trên slide hoặc xóa bỏ nó.

## **Liệt kê các điều khiển ActiveX và các thuộc tính đã lưu**

Để kiểm tra một mẫu không quen thuộc, mở nó để đọc và lặp lại qua các điều khiển trên mỗi slide. Ví dụ báo cáo số slide, tên điều khiển, [getClassId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getClassId), và mỗi cặp khóa-giá trị trong [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties). Nó đọc bản trình chiếu mà không kích hoạt các điều khiển, không gọi sự kiện hay macro, không thay đổi giá trị, và không lưu tệp.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ActiveX.pptm");
try {
    const slideList = presentation.getSlides();
    for (let i = 0; i < slideList.size(); i++) {
        const controls = slideList.get_Item(i).getControls();
        for (let j = 0; j < controls.size(); j++) {
            const control = controls.get_Item(j);
            console.log(`Slide ${i + 1} | ${control.getName()} | ${control.getClassId()}`);
            const properties = control.getProperties();
            if (properties == null) {
                console.log("  Properties unavailable");
                continue;
            }
            if (properties.getCount() === 0) {
                console.log("  []");
            }
            const names = properties.getNamesOfProperties().iterator();
            while (names.hasNext()) {
                const name = names.next();
                console.log(`  ${name} = ${properties.get_Item(name)}`);
            }
        }
    }
} finally {
    presentation.dispose();
}
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

Một bộ sưu tập thuộc tính rỗng hiển thị dưới dạng `[]`. Đối với các điều khiển sử dụng lưu trữ nhị phân, [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties) có thể trả về `null`, được hiển thị là `Properties unavailable`. Nếu bạn chỉ cần tên, hãy sử dụng [getNamesOfProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) sau khi kiểm tra null. Báo cáo liệt kê các thuộc tính có sẵn từ bản trình chiếu. Một điều khiển có thể hỗ trợ các thuộc tính bổ sung tại thời gian chạy.

## **Chỉnh sửa các điều khiển ActiveX**

Ví dụ yêu cầu một bản trình chiếu bật macro có một hộp văn bản tên `TextBox1` và một nút lệnh tên `CommandButton1` trên slide đầu tiên. Nó sử dụng [bộ sưu tập thuộc tính điều khiển](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) để thay đổi giá trị hộp văn bản và chú thích nút. Mỗi điều khiển cũng có một bản xem trước tĩnh mà PowerPoint có thể hiển thị trước khi kích hoạt. Cung cấp một tệp PNG cho mỗi điều khiển để hiển thị văn bản và giao diện đã cập nhật. Ví dụ gán các hình ảnh này thông qua [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getSubstitutePictureFormat).

Ví dụ di chuyển mọi điều khiển trên slide đầu tiên xuống dưới 100 điểm bằng cách đặt khung của chúng với [Control.setFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#setFrame). Nó lưu bản trình chiếu đã chỉnh sửa ở định dạng PPTM, sau đó sử dụng [ControlCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/#clear) để lưu bản sao thứ hai với tất cả các điều khiển ActiveX đã được xóa khỏi slide đó.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function addPreview(presentation, path) {
    const image = slides.Images.fromFile(path);
    try {
        return presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
}

function editControls() {
    const presentation = new slides.Presentation("ActiveX.pptm");
    try {
        const controls = presentation.getSlides().get_Item(0).getControls();
        let textBox;
        let button;
        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            if (control.getName() === "TextBox1") {
                textBox = control;
            } else if (control.getName() === "CommandButton1") {
                button = control;
            }
        }
        if (!textBox || !button || textBox.getProperties() == null || button.getProperties() == null) {
            console.log("The first slide must contain both named controls with editable properties.");
            return;
        }

        const textBoxPreview = addPreview(presentation, "text-box-preview.png");
        const buttonPreview = addPreview(presentation, "button-preview.png");
        textBox.getProperties().set_Item("Value", "Changed text");
        button.getProperties().set_Item("Caption", "Show message");
        textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
        button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            const frame = control.getFrame();
            const flipH = java.newByte(frame.getFlipH());
            const flipV = java.newByte(frame.getFlipV());
            const moved = new slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), flipH, flipV, frame.getRotation());
            control.setFrame(moved);
        }
        presentation.save("edited-controls.pptm", slides.SaveFormat.Pptm);

        controls.clear();
        presentation.save("removed-controls.pptm", slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}

editControls();
```

## **Thêm một điều khiển Media Player ActiveX**

Để tái sử dụng một điều khiển Windows Media Player đã cấu hình, bắt đầu với một mẫu mà slide đầu tiên chứa một trình phát tên `WindowsMediaPlayer1`. [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone) sao chép toàn bộ slide vào một bản trình chiếu mới. Ví dụ đặt `URL` của trình phát trong [bộ sưu tập thuộc tính](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) và lưu slide đã sao chép làm slide duy nhất trong đầu ra. Video vẫn ở ngoài, vì vậy hãy chọn một đường dẫn mà trình phát có thể truy cập trong quá trình phát.

```javascript
const slides = require("aspose.slides.via.java");

function addMediaPlayer() {
    const template = new slides.Presentation("template.pptx");
    try {
        const presentation = new slides.Presentation();
        try {
            const templateSlide = template.getSlides().get_Item(0);
            const slide = presentation.getSlides().addClone(templateSlide);
            const controls = slide.getControls();
            let player;
            for (let i = 0; i < controls.size(); i++) {
                const control = controls.get_Item(i);
                if (control.getName() === "WindowsMediaPlayer1") {
                    player = control;
                    break;
                }
            }
            if (!player || player.getProperties() == null) {
                console.log("The template slide must contain a named media player with editable properties.");
                return;
            }
            player.getProperties().set_Item("URL", "Wildlife.mp4");
            
            presentation.getSlides().removeAt(0);
            presentation.save("linked-video.pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        template.dispose();
    }
}

addMediaPlayer();
```

## **Câu hỏi thường gặp**

**Aspose.Slides có thể giữ lại các điều khiển ActiveX mà không chạy chúng không?**

Có. Aspose.Slides có thể đọc và lưu các điều khiển, bao gồm thuộc tính và vị trí của chúng, mà không kích hoạt chúng.

**Các điều khiển ActiveX khác với đối tượng OLE như thế nào?**

Các điều khiển ActiveX cho phép người dùng tương tác với một slide, ví dụ bằng cách nhập văn bản hoặc nhấn nút. Một [đối tượng OLE](/slides/vi/nodejs-java/manage-ole/) cho phép một slide chứa hoặc liên kết tới nội dung được quản lý bởi một ứng dụng khác, chẳng hạn như một bảng tính Excel.

**Các sự kiện ActiveX vẫn sẽ kích hoạt macro VBA sau khi tôi lưu một bản trình chiếu với Aspose.Slides không?**

Lưu bản trình chiếu ở định dạng hỗ trợ macro như PPTM để giữ lại dự án VBA của nó. PowerPoint cho Windows có thể chạy các trình xử lý sự kiện hiện có khi cài đặt bảo mật cho phép cả điều khiển ActiveX và macro.