---
title: Hộp Văn Bản
type: docs
weight: 40
url: /vi/php-java/examples/elements/text-box/
keywords:
- hộp văn bản
- thêm hộp văn bản
- truy cập hộp văn bản
- xóa hộp văn bản
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tạo và định dạng hộp văn bản trong PHP với Aspose.Slides: thiết lập phông chữ, căn chỉnh, ngắt dòng, tự động điều chỉnh, và liên kết để tinh chỉnh các slide cho PowerPoint và OpenDocument."
---
Trong Aspose.Slides, một **text box** được đại diện bởi một `AutoShape`. Hầu hết mọi hình dạng đều có thể chứa văn bản, nhưng một text box điển hình không có nền hay viền và chỉ hiển thị văn bản.

Hướng dẫn này giải thích cách thêm, truy cập và xóa text box bằng chương trình.

## **Thêm Text Box**

Một text box chỉ đơn giản là một `AutoShape` không có nền hay viền và chứa một số văn bản đã định dạng. Dưới đây là cách tạo một text box:

```php
function addTextBox() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Tạo một hình chữ nhật (mặc định được tô đầy và có viền nhưng không có văn bản).
        $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

        // Xóa tô đầy và viền để nó trông giống như một hộp văn bản điển hình.
        $textBox->getFillFormat()->setFillType(FillType::NoFill);
        $textBox->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        // Đặt định dạng văn bản.
        $paragraph = $textBox->getTextFrame()->getParagraphs()->get_Item(0);
        $portionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $portionFormat->getFillFormat()->setFillType(FillType::Solid);
        $portionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        // Gán nội dung văn bản thực tế.
        $textBox->getTextFrame()->setText("Some text...");

        $presentation->save("text_box.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Lưu ý:** Bất kỳ `AutoShape` nào chứa `TextFrame` không rỗng đều có thể hoạt động như một text box.

## **Truy cập Text Box theo Nội dung**

Để tìm tất cả các text box chứa một từ khóa cụ thể (ví dụ: "Slide"), duyệt qua các shape và kiểm tra văn bản của chúng:

```php
function accessTextBox() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Truy cập hộp văn bản đầu tiên trên slide.
        $firstTextBox = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $firstTextBox = $shape;
                if (strpos($firstTextBox->getTextFrame()->getText(), "Slide") !== false) {
                    // Thực hiện một thao tác nào đó với hộp văn bản khớp.
                }
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Xóa Text Box theo Nội dung**

Ví dụ này tìm và xóa tất cả các text box trên slide đầu tiên chứa một từ khóa cụ thể:

```php
function removeTextBoxes() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shapesToRemove = [];

        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $autoShape = $shape;
                if (strpos($autoShape->getTextFrame()->getText(), "Slide") !== false) {
                    $shapesToRemove[] = $shape;
                }
            }
        }

        foreach ($shapesToRemove as $shape) {
            $slide->getShapes()->remove($shape);
        }

        $presentation->save("text_boxes_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Mẹo:** Luôn tạo một bản sao của bộ sưu tập shape trước khi chỉnh sửa nó trong quá trình lặp để tránh lỗi sửa đổi bộ sưu tập.