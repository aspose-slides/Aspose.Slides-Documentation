---
title: Đối tượng OLE
type: docs
weight: 210
url: /vi/nodejs-java/examples/elements/ole-object/
keywords:
- ví dụ mã
- đối tượng OLE
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Xử lý các đối tượng OLE trong Aspose.Slides cho Node.js: chèn, liên kết, cập nhật và trích xuất nội dung được nhúng bằng JavaScript trong các bản trình chiếu PPT, PPTX và ODP."
---
Bài viết này minh họa cách nhúng một tệp dưới dạng đối tượng OLE và cập nhật dữ liệu của nó bằng cách sử dụng **Aspose.Slides for Node.js via Java**.

## **Thêm Đối Tượng OLE**

Nhúng tệp PDF vào một bản trình chiếu.

```js
function addOleObject() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let pdfStream = fs.readFileSync("doc.pdf");
        let pdfData = java.newArray("byte", Array.from(pdfStream));
        let dataInfo = new aspose.slides.OleEmbeddedDataInfo(pdfData, "pdf");
        let oleFrame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, dataInfo);

        presentation.save("ole_object.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Truy cập Đối Tượng OLE**

Lấy khung đối tượng OLE đầu tiên trên một slide.

```js
function accessOleObject() {
    let presentation = new aspose.slides.Presentation("ole_object.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstOleFrame = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IOleObjectFrame")) {
                firstOleFrame = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa Đối Tượng OLE**

Xóa một đối tượng OLE đã nhúng khỏi slide.

```js
function removeOleObject() {
    let presentation = new aspose.slides.Presentation("ole_object.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Giả sử hình dạng đầu tiên là khung đối tượng OLE.
        let oleFrame = slide.getShapes().get_Item(0);
        
        slide.getShapes().remove(oleFrame);

        presentation.save("ole_object_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Cập nhật Dữ liệu Đối Tượng OLE**

Thay thế dữ liệu đã nhúng trong một đối tượng OLE hiện có.

```js
function updateOleObject() {
    let presentation = new aspose.slides.Presentation("ole_object.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Giả sử hình dạng đầu tiên là khung đối tượng OLE.
        let oleFrame = slide.getShapes().get_Item(0);

        let dataStream = fs.readFileSync("picture.png");
        let newData = java.newArray("byte", Array.from(dataStream));
        let dataInfo = new aspose.slides.OleEmbeddedDataInfo(newData, "png");
        oleFrame.setEmbeddedData(dataInfo);

        presentation.save("ole_object_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```