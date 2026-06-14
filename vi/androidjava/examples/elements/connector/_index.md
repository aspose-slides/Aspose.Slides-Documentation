---
title: Đầu nối
type: docs
weight: 190
url: /vi/androidjava/examples/elements/connector/
keywords:
- ví dụ mã
- Đầu nối
- PowerPoint
- OpenDocument
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách thêm, định tuyến và định dạng các connector giữa các hình dạng bằng cách sử dụng Aspose.Slides cho Android, với các ví dụ Java cho các bản trình bày PPT, PPTX và ODP."
---
Bài viết này trình bày cách kết nối các hình dạng bằng connector và thay đổi mục tiêu của chúng bằng cách sử dụng **Aspose.Slides for Android via Java**.

## **Thêm connector**

Chèn một hình connector giữa hai điểm trên slide.

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

## **Truy cập connector**

Lấy hình connector đầu tiên đã được thêm vào slide.

```java
static void accessConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        // Truy cập connector đầu tiên trên slide.
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

## **Xóa connector**

Xóa một connector khỏi slide.

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

## **Kết nối lại các hình**

Gắn một connector vào hai hình bằng cách chỉ định mục tiêu bắt đầu và kết thúc.

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