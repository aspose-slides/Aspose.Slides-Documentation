---
title: Hộp Văn Bản
type: docs
weight: 40
url: /vi/nodejs-java/examples/elements/text-box/
keywords:
- ví dụ mã
- hộp văn bản
- PowerPoint
- OpenDocument
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Làm việc với hộp văn bản trong Aspose.Slides cho Node.js: thêm, định dạng, căn chỉnh, ngắt dòng, tự động điều chỉnh kích thước và tạo kiểu cho văn bản bằng JavaScript cho các bản trình chiếu PPT, PPTX và ODP."
---
Trong Aspose.Slides, một **text box** được biểu thị bằng một `AutoShape`. Hầu hết mọi hình dạng đều có thể chứa văn bản, nhưng một text box điển hình không có màu nền hay đường viền và chỉ hiển thị văn bản.

Hướng dẫn này giải thích cách thêm, truy cập và xóa các text box bằng cách lập trình.

## **Thêm một Text Box**

Một text box chỉ đơn giản là một `AutoShape` không có màu nền hay đường viền và chứa một số văn bản được định dạng. Dưới đây là cách tạo một text box:

```js
function addTextBox() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Tạo một hình chữ nhật (mặc định được tô màu và có viền, không có văn bản).
        let textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 75, 150, 100);

        // Xóa màu nền và viền để làm cho nó trông giống như một hộp văn bản tiêu chuẩn.
        let boxFillType = java.newByte(aspose.slides.FillType.NoFill);
        textBox.getFillFormat().setFillType(boxFillType);
        textBox.getLineFormat().getFillFormat().setFillType(boxFillType);

        // Đặt định dạng văn bản.
        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        let textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        let textFillType = java.newByte(aspose.slides.FillType.Solid);
        let textFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        textFormat.getFillFormat().setFillType(textFillType);
        textFormat.getFillFormat().getSolidFillColor().setColor(textFillColor);

        // Gán nội dung văn bản thực tế.
        textBox.getTextFrame().setText("Some text...");

        presentation.save("text_box.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Lưu ý:** Bất kỳ `AutoShape` nào chứa một `TextFrame` không rỗng đều có thể hoạt động như một text box.

## **Truy cập một Text Box**

Lấy text box đầu tiên trên slide.

```js
function accessTextBox() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstTextBox = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Chỉ các AutoShape mới có thể chứa văn bản có thể chỉnh sửa.
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                firstTextBox = shape;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa các Text Box theo Nội dung**

Ví dụ này tìm và xóa tất cả các text box trên slide đầu tiên có chứa một từ khóa cụ thể:

```js
function removeTextBoxes() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shapesToRemove = [];
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                let autoShape = shape;
                if (autoShape.getTextFrame().getText().includes("Slide")) {
                    shapesToRemove.push(shape);
                }
            }
        }

        for (let i = 0; i < shapesToRemove.length; i++) {
            slide.getShapes().remove(shapesToRemove[i]);
        }

        presentation.save("text_boxes_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Mẹo:** Luôn tạo một bản sao của bộ sưu tập hình dạng trước khi sửa đổi chúng trong quá trình lặp để tránh lỗi khi thay đổi bộ sưu tập.