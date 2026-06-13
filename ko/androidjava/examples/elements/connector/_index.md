---
title: 커넥터
type: docs
weight: 190
url: /ko/androidjava/examples/elements/connector/
keywords:
- 코드 예제
- 커넥터
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android를 사용하여 도형 간 커넥터를 추가, 라우팅 및 스타일링하는 방법을 배웁니다. PPT, PPTX 및 ODP 프레젠테이션에 대한 Java 예제가 포함됩니다."
---
이 문서에서는 **Aspose.Slides for Android via Java**를 사용하여 도형을 커넥터로 연결하고 해당 대상을 변경하는 방법을 보여줍니다.

## **커넥터 추가**

슬라이드의 두 지점 사이에 커넥터 도형을 삽입합니다.

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

## **커넥터 접근**

슬라이드에 추가된 첫 번째 커넥터 도형을 가져옵니다.

```java
static void accessConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        // 슬라이드의 첫 번째 커넥터에 접근합니다.
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

## **커넥터 제거**

슬라이드에서 커넥터를 삭제합니다.

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

## **도형 재연결**

시작 및 끝 대상을 할당하여 커넥터를 두 도형에 연결합니다.

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