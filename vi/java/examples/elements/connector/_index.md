---
title: Kết nối
type: docs
weight: 190
url: /vi/java/examples/elements/connector/
keywords:
- ví dụ mã
- Kết nối
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Tìm hiểu cách thêm, định tuyến và tạo kiểu kết nối giữa các hình dạng bằng Aspose.Slides for Java, với các ví dụ Java cho các bài thuyết trình PPT, PPTX và ODP."
---
Bài viết này trình bày cách kết nối các hình dạng bằng kết nối và thay đổi mục tiêu của chúng bằng cách sử dụng **Aspose.Slides for Java**.

## **Thêm kết nối**

Chèn một hình dạng kết nối giữa hai điểm trên slide.

```java
static void addConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
    } finally {
        presentation.dispose();
    }
}
```

## **Truy cập kết nối**

Lấy hình dạng kết nối đầu tiên được thêm vào slide.

```java
static void accessConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        // Truy cập kết nối đầu tiên trên slide.
        IConnector connector = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IConnector) {
                connector = (IConnector) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa kết nối**

Xóa một kết nối khỏi slide.

```java
static void removeConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        slide.getShapes().remove(connector);
    } finally {
        presentation.dispose();
    }
}
```

## **Kết nối lại các hình dạng**

Gắn một kết nối vào hai hình dạng bằng cách chỉ định mục tiêu bắt đầu và kết thúc.

```java
static void reconnectShapes() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
        IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 50, 50);
        IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        connector.setStartShapeConnectedTo(shape1);
        connector.setEndShapeConnectedTo(shape2);
    } finally {
        presentation.dispose();
    }
}
```