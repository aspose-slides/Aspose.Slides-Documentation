---
title: Hộp Văn Bản
type: docs
weight: 40
url: /vi/java/examples/elements/text-box/
keywords:
- ví dụ mã
- hộp văn bản
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Làm việc với các hộp văn bản trong Aspose.Slides cho Java: thêm, định dạng, căn chỉnh, xuống dòng, tự động vừa, và tạo kiểu văn bản bằng Java cho các bản trình bày PPT, PPTX và ODP."
---
Trong Aspose.Slides, một **text box** được biểu diễn bằng một `AutoShape`. Hầu như bất kỳ hình dạng nào cũng có thể chứa văn bản, nhưng một text box điển hình không có nền hay viền và chỉ hiển thị văn bản.

Hướng dẫn này giải thích cách thêm, truy cập và xóa các text box một cách lập trình.

## **Thêm một Text Box**

Một text box chỉ đơn giản là một `AutoShape` không có nền hay viền và chứa một số văn bản được định dạng. Đây là cách tạo một text box:

```java
public static void addTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Tạo một hình chữ nhật (mặc định được tô đầy với viền và không có văn bản).
        IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100);

        // Xóa nền và viền để nó trông giống như một hộp văn bản điển hình.
        textBox.getFillFormat().setFillType(FillType.NoFill);
        textBox.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        // Đặt định dạng văn bản.
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        IPortionFormat textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        textFormat.getFillFormat().setFillType(FillType.Solid);
        textFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        // Gán nội dung văn bản thực tế.
        textBox.getTextFrame().setText("Some text...");
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Lưu ý:** Bất kỳ `AutoShape` nào chứa một `TextFrame` không rỗng đều có thể hoạt động như một text box.

## **Truy cập Text Box theo Nội dung**

Để tìm tất cả các text box chứa một từ khóa cụ thể (ví dụ: "Slide"), hãy lặp qua các shape và kiểm tra văn bản của chúng:

```java
public static void accessTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        for (IShape shape : slide.getShapes()) {
            // Chỉ các AutoShape mới có thể chứa văn bản có thể chỉnh sửa.
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    // Thực hiện một thao tác nào đó với hộp văn bản phù hợp.
                }
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa Text Box theo Nội dung**

Ví dụ này tìm và xóa tất cả các text box trên slide đầu tiên chứa một từ khóa cụ thể:

```java
public static void removeTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        List<IShape> shapesToRemove = new ArrayList<IShape>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    shapesToRemove.add(shape);
                }
            }
        }

        for (IShape shape : shapesToRemove) {
            slide.getShapes().remove(shape);
        }
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Mẹo:** Luôn tạo một bản sao của bộ sưu tập shape trước khi sửa đổi nó trong quá trình lặp để tránh lỗi sửa đổi bộ sưu tập.