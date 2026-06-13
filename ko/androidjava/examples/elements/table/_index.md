---
title: 테이블
type: docs
weight: 120
url: /ko/androidjava/examples/elements/table/
keywords:
- 코드 예제
- 테이블
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android에서 테이블 작업: 생성, 서식 지정, 셀 병합, 스타일 적용, 데이터 가져오기 및 PPT, PPTX, ODP용 Java 예제로 내보내기."
---
**Aspose.Slides for Android via Java**를 사용하여 테이블을 추가하고, 액세스하고, 제거하고, 셀을 병합하는 예제.

## **테이블 추가**

두 개의 행과 두 개의 열을 가진 간단한 테이블을 만듭니다.

```java
static void addTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);
    } finally {
        presentation.dispose();
    }
}
```

## **테이블 액세스**

슬라이드에서 첫 번째 테이블 모양을 가져옵니다.

```java
static void accessTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // 슬라이드에서 첫 번째 테이블에 접근합니다.
        ITable firstTable = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ITable) {
                firstTable = (ITable) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **테이블 제거**

슬라이드에서 테이블을 삭제합니다.

```java
static void removeTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        slide.getShapes().remove(table);
    } finally {
        presentation.dispose();
    }
}
```

## **테이블 셀 병합**

테이블의 인접한 셀을 하나의 셀로 병합합니다.

```java
static void mergeTableCells() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // 셀을 병합합니다.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);
    } finally {
        presentation.dispose();
    }
}
```