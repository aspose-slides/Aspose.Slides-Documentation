---
title: Nhóm Hình
type: docs
weight: 170
url: /vi/java/examples/elements/group-shape/
keywords:
- ví dụ mã
- nhóm hình
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Quản lý các hình dạng nhóm trong Aspose.Slides for Java: tạo, lồng, căn chỉnh, sắp xếp lại và tạo kiểu các hình dạng nhóm với các ví dụ Java trong các bản thuyết trình PPT, PPTX và ODP."
---
Ví dụ về việc tạo nhóm các hình dạng, truy cập chúng, tách nhóm và xóa bằng **Aspose.Slides for Java**.

## **Add a Group Shape**
Tạo một nhóm chứa hai hình dạng cơ bản.

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

## **Access a Group Shape**
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

## **Remove a Group Shape**
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

## **Ungroup Shapes**
Di chuyển các hình dạng ra khỏi bộ chứa nhóm.

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