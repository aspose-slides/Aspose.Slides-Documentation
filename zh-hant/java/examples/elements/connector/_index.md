---
title: 連接線
type: docs
weight: 190
url: /zh-hant/java/examples/elements/connector/
keywords:
- 程式碼範例
- Connector
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "瞭解如何使用 Aspose.Slides for Java 在形狀之間新增、路由與樣式化連接線，並提供 PPT、PPTX 與 ODP 簡報的 Java 範例。"
---
本文示範如何使用 **Aspose.Slides for Java** 連接形狀與連接線，並變更其目標。

## **新增連接線**

在投影片的兩個點之間插入連接線形狀。

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

## **存取連接線**

取得已新增至投影片的第一個連接線形狀。

```java
static void accessConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        // 存取投影片上的第一個連接線。
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

## **移除連接線**

從投影片中刪除連接線。

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

## **重新連接形狀**

透過指定起始與結束目標，將連接線附加至兩個形狀。

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