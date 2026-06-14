---
title: Hình ảnh
type: docs
weight: 50
url: /vi/php-java/examples/elements/picture/
keywords:
- hình ảnh
- khung ảnh
- thêm hình ảnh
- truy cập hình ảnh
- ví dụ mã
- PowerPoint
- OpenDocument
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Làm việc với hình ảnh trong PHP bằng Aspose.Slides: chèn, thay thế, cắt, nén, điều chỉnh độ trong suốt và hiệu ứng, tô đầy các hình dạng, và xuất ra định dạng PPT, PPTX và ODP."
---
Hiển thị cách chèn và truy cập hình ảnh bằng **Aspose.Slides for PHP via Java**. Các ví dụ dưới đây đặt một hình ảnh vào slide và sau đó lấy lại nó.

## **Thêm hình ảnh**

Đoạn mã này chèn một hình ảnh dưới dạng khung hình vào slide đầu tiên.

```php
function addPicture() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $image = $presentation->getImages()->addImage(
            new Java("java.io.FileInputStream", new Java("java.io.File", "image.jpg")));

        // Thêm hình ảnh vào tài nguyên của bản trình chiếu.
        $ppImage = $presentation->getImages()->addImage($image);

        // Chèn khung hình ảnh hiển thị hình trên slide đầu tiên.
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle, 50, 50, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);

        $presentation->save("picture.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Truy cập hình ảnh**

Ví dụ này đảm bảo một slide chứa khung hình và sau đó truy cập vào khung đầu tiên mà nó tìm thấy.

```php
function accessPicture() {
    $presentation = new Presentation("picture.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Truy cập PictureFrame đầu tiên trên slide.
        $firstPictureFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $firstPictureFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```