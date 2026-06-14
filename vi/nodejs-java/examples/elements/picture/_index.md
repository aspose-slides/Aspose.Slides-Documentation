---
title: Hình ảnh
type: docs
weight: 50
url: /vi/nodejs-java/examples/elements/picture/
keywords:
- ví dụ mã
- hình ảnh
- PowerPoint
- OpenDocument
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Làm việc với hình ảnh trong Aspose.Slides cho Node.js: chèn, cắt, nén, thay đổi màu và xuất ảnh với các ví dụ cho các bản trình bày PPT, PPTX và ODP."
---
Bài viết này trình bày cách chèn và truy cập ảnh bằng **Aspose.Slides for Node.js via Java**. Các ví dụ dưới đây đọc một hình ảnh từ tệp, đặt nó lên một slide và sau đó lấy lại.

## **Thêm ảnh**

Mã này đọc một hình ảnh từ tệp và chèn nó dưới dạng khung ảnh trên slide đầu tiên.

```js
function addPicture() {
    const FileInputStream = java.import("java.io.FileInputStream");

    let presentation = new aspose.slides.Presentation();

    try {
        let slide = presentation.getSlides().get_Item(0);

        let imageStream = new FileInputStream("image.jpg");
        let image = presentation.getImages().addImage(imageStream);

        // Chèn khung ảnh hiển thị hình trên slide đầu tiên.
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 50, 50, image.getWidth(), image.getHeight(), image);

        presentation.save("picture.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Truy cập ảnh**

Ví dụ này đảm bảo một slide chứa khung ảnh và sau đó truy cập vào khung đầu tiên được tìm thấy.

```js
function accessPicture() {
    let presentation = new aspose.slides.Presentation("picture.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let pictureFrame = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                pictureFrame = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```