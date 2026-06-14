---
title: Đầu nối
type: docs
weight: 190
url: /vi/nodejs-java/examples/elements/connector/
keywords:
- ví dụ mã
- Đầu nối
- PowerPoint
- OpenDocument
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách thêm, định hướng và định dạng các đầu nối giữa các hình dạng bằng Aspose.Slides cho Node.js, với các ví dụ JavaScript cho các bản trình bày PPT, PPTX và ODP."
---
Bài viết này trình bày cách kết nối các hình dạng bằng dây nối và thay đổi mục tiêu của chúng bằng **Aspose.Slides for Node.js via Java**.

## **Thêm dây nối**

Chèn một hình dạng dây nối giữa hai điểm trên slide.

```js
function addConnector() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 100, 100);

        presentation.save("connector.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Truy cập dây nối**

Lấy hình dạng dây nối đầu tiên được thêm vào slide.

```js
function accessConnector() {
    let presentation = new aspose.slides.Presentation("connector.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Truy cập vào dây nối đầu tiên trên slide.
        let connector = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                connector = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa dây nối**

Xóa một dây nối khỏi slide.

```js
function removeConnector() {
    let presentation = new aspose.slides.Presentation("connector.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Giả sử hình dạng đầu tiên là một dây nối và xóa nó.
        slide.getShapes().removeAt(0);

        presentation.save("connector_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Kết nối lại các hình dạng**

Gắn một dây nối vào hai hình dạng bằng cách chỉ định mục tiêu bắt đầu và kết thúc.

```js
function reconnectShapes() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 50, 50);
        let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 50, 50);

        let connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 100, 100);

        connector.setStartShapeConnectedTo(shape1);
        connector.setEndShapeConnectedTo(shape2);
    } finally {
        presentation.dispose();
    }
}
```