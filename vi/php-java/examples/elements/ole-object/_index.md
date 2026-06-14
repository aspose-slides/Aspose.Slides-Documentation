---
title: Đối tượng OLE
type: docs
weight: 210
url: /vi/php-java/examples/elements/ole-object/
keywords:
- đối tượng OLE
- thêm đối tượng OLE
- truy cập đối tượng OLE
- xóa đối tượng OLE
- cập nhật đối tượng OLE
- ví dụ mã
- PowerPoint
- OpenDocument
- bản trình bày
- PHP
- Aspose.Slides
description: "Làm việc với các đối tượng OLE trong PHP bằng Aspose.Slides: chèn hoặc cập nhật tệp nhúng, đặt biểu tượng hoặc liên kết, trích xuất nội dung, kiểm soát hành vi cho PPT, PPTX và ODP."
---
Trình bày cách nhúng một tệp dưới dạng đối tượng OLE và cập nhật dữ liệu của nó bằng cách sử dụng **Aspose.Slides for PHP via Java**.

## **Thêm một Đối tượng OLE**
Nhúng tệp PDF vào bản trình bày.

```php
function addOleObject() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $pdfData = new OleEmbeddedDataInfo(file_get_contents("doc.pdf"), "pdf");
        $oleFrame = $slide->getShapes()->addOleObjectFrame(20, 20, 50, 50, $pdfData);

        $presentation->save("ole_object.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Truy cập Đối tượng OLE**
Lấy khung đối tượng OLE đầu tiên trên một slide.

```php
function accessOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Truy cập khung OLE đầu tiên trên slide.
        $firstOleFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
                $firstOleFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Xóa Đối tượng OLE**
Xóa một đối tượng OLE đã nhúng khỏi slide.

```php
function removeOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Giả sử hình dạng đầu tiên trên slide là khung OLE.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($oleFrame);

        $presentation->save("ole_object_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Cập nhật Dữ liệu Đối tượng OLE**
Thay thế dữ liệu đã nhúng trong một đối tượng OLE hiện có.

```php
function updateOleObjectData() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Giả sử hình dạng đầu tiên trên slide là khung OLE.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $newData = new OleEmbeddedDataInfo(file_get_contents("picture.png"), "png");
        $oleFrame->setEmbeddedData($newData);

        $presentation->save("ole_object_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```