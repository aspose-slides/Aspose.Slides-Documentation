---
title: 그룹 도형
type: docs
weight: 170
url: /ko/java/examples/elements/group-shape/
keywords:
- 코드 예제
- 그룹 도형
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java에서 그룹화된 도형을 관리합니다: Java 예제를 사용해 PPT, PPTX 및 ODP 프레젠테이션에서 그룹 도형을 만들고, 중첩하고, 정렬하고, 순서를 바꾸고, 스타일을 적용합니다."
---
**Aspose.Slides for Java** 를 사용하여 도형 그룹을 만들고, 접근하고, 그룹을 해제하고, 제거하는 예제입니다.

## **그룹 도형 추가**

두 개의 기본 도형을 포함하는 그룹을 만듭니다.

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

## **그룹 도형 접근**

슬라이드에서 첫 번째 그룹 도형을 가져옵니다.

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

## **그룹 도형 제거**

슬라이드에서 그룹 도형을 삭제합니다.

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

## **그룹 해제**

그룹 컨테이너에서 도형을 꺼냅니다.

```java
static void ungroupShapes() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        IAutoShape rect = group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        // 그룹에서 도형을 이동합니다.
        slide.getShapes().addClone(rect);
        group.getShapes().remove(rect);
    } finally {
        presentation.dispose();
    }
}
```