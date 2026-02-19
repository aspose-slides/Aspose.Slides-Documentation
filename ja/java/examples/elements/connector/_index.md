---
title: コネクタ
type: docs
weight: 190
url: /ja/java/examples/elements/connector/
keywords:
- コード例
- コネクタ
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用してシェイプ間にコネクタを追加、経路指定、スタイル設定する方法を学びます。PPT、PPTX、ODP プレゼンテーションの Java のサンプルが含まれています。"
---
この記事では、**Aspose.Slides for Java** を使用してシェイプをコネクタで接続し、ターゲットを変更する方法を示します。

## **コネクタを追加**

スライド上の2つのポイント間にコネクタシェイプを挿入します。

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

## **コネクタにアクセス**

スライドに追加された最初のコネクタシェイプを取得します。

```java
static void accessConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        // スライド上の最初のコネクタにアクセスします。
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

## **コネクタを削除**

スライドからコネクタを削除します。

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

## **シェイプの再接続**

開始ターゲットと終了ターゲットを割り当てて、コネクタを2つのシェイプに接続します。

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