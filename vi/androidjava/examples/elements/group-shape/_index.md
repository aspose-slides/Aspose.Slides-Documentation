---
title: Nhóm Hình
type: docs
weight: 170
url: /vi/androidjava/examples/elements/group-shape/
keywords:
- ví dụ mã
- nhóm hình
- PowerPoint
- OpenDocument
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Quản lý các hình đã nhóm trong Aspose.Slides cho Android: tạo, lồng, căn chỉnh, sắp xếp lại và định dạng các nhóm hình bằng các ví dụ Java trong các bản trình chiếu PPT, PPTX và ODP."
---
Các ví dụ về việc tạo nhóm các hình dạng, truy cập chúng, tách nhóm và xóa bằng **Aspose.Slides for Android via Java**.

## **Thêm một Nhóm Hình**

Tạo một nhóm chứa hai hình cơ bản.

```java
static void addGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
        group.getShapes().addAutoShape(ShapeType.Ellipse, 60, 0, 50, 50);
    } finally {
        presentation.dispose();
    }
}
```

## **Truy cập một Nhóm Hình**

Lấy nhóm hình đầu tiên từ một slide.

```java
static void accessGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        IGroupShape firstGroup = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IGroupShape) {
                firstGroup = (IGroupShape) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Xóa một Nhóm Hình**

Xóa một nhóm hình khỏi slide.

```java
static void removeGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();

        slide.getShapes().remove(group);
    } finally {
        presentation.dispose();
    }
}
```

## **Tách Nhóm Hình**

Di chuyển các hình ra khỏi container nhóm.

```java
static void ungroupShapes() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        IAutoShape rect = group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        // Di chuyển hình ra khỏi nhóm.
        slide.getShapes().addClone(rect);
        group.getShapes().remove(rect);
    } finally {
        presentation.dispose();
    }
}
```