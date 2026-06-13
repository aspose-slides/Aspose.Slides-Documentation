---
title: Android에서 프레젠테이션의 문단 경계 가져오기
linktitle: 문단
type: docs
weight: 60
url: /ko/androidjava/paragraph/
keywords:
- 문단 경계
- 텍스트 부분 경계
- 문단 좌표
- 부분 좌표
- 문단 크기
- 텍스트 부분 크기
- 텍스트 프레임
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android를 Java로 사용하여 문단 및 텍스트 부분 경계를 검색하고 PowerPoint 프레젠테이션에서 텍스트 위치를 최적화하는 방법을 배웁니다."
---
## **Overview**

이 문서에서는 Aspose.Slides에서 문단 및 텍스트 부분의 경계, 크기 및 좌표를 가져오는 방법을 설명합니다. `getRect()` 를 사용하여 `TextFrame` 에서 문단의 사각형을 검색하는 방법, 테이블 셀 텍스트 프레임 내부에서 문단 및 부분의 좌표를 가져오는 방법을 보여주며, 측정 단위, 텍스트 줄 바꿈이 경계에 미치는 영향, 픽셀 변환, 실제 문단 서식 값과 같은 중요한 세부 사항을 강조합니다.

## **Get Paragraph and Portion Coordinates in a TextFrame**
Using Aspose.Slides for Android via Java, developers can now get the rectangular coordinates for Paragraph inside paragraphs collection of TextFrame. It also allows you to get [the coordinates of portion](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IPortion#getCoordinates--) inside portion collection of a paragraph. In this topic, we are going to demonstrate with the help of an example that how to get the rectangular coordinates for paragraph along with position of portion inside a paragraph.

``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```

## **Get Rectangular Coordinates of a Paragraph**
Using [**getRect()**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IParagraph#getRect--) method developers can get paragraph bounds rectangle.

```java
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrame textFrame = shape.getTextFrame();
    Rectangle2D.Float rect = textFrame.getParagraphs().get_Item(0).getRect();
    System.out.println("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Get the Size of a Paragraph and Portion Inside a Table Cell TextFrame**

To get the [Portion](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Portion) or [Paragraph](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Paragraph) size and coordinates in a table cell text frame, you can use the [IPortion.getRect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IPortion#getRect--) and [IParagraph.getRect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IParagraph#getRect--) methods.

This sample code demonstrates the described operation:

```java
Presentation pres = new Presentation("source.pptx");
try {
    Table tbl = (Table)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ICell cell = tbl.getRows().get_Item(1).get_Item(1);

    double x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    double y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();

    for (IParagraph para : cell.getTextFrame().getParagraphs())
    {
        if (para.getText().equals(""))
            continue;

        Rectangle2D.Float rect = para.getRect();
        IAutoShape shape =
                pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                        (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);

        for (IPortion portion : para.getPortions())
        {
            if (portion.getText().contains("0"))
            {
                rect = portion.getRect();
                shape =
                        pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                                (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

                shape.getFillFormat().setFillType(FillType.NoFill);
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**문단 및 텍스트 부분의 좌표는 어떤 단위로 반환되나요?**

포인트 단위이며, 1인치 = 72포인트입니다. 이는 슬라이드의 모든 좌표와 크기에 적용됩니다.

**단어 줄 바꿈이 문단의 경계에 영향을 미치나요?**

예. [wrapping](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-) 이 [TextFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/textframe/) 에서 활성화되면 텍스트가 영역 너비에 맞게 줄 바꿈되어 문단의 실제 경계가 변경됩니다.

**문단 좌표를 내보낸 이미지의 픽셀에 신뢰성 있게 매핑할 수 있나요?**

예. 포인트를 픽셀로 변환하려면 다음 식을 사용합니다: pixels = points × (DPI / 72). 결과는 렌더링/내보내기에 선택한 DPI에 따라 달라집니다.

**스타일 상속을 고려한 “effective”(실제) 문단 서식 매개변수를 어떻게 얻을 수 있나요?**

다음 [effective paragraph formatting data structure](/slides/ko/androidjava/shape-effective-properties/) 를 사용하십시오; 들여쓰기, 간격, 줄 바꿈, RTL 등과 같은 최종 통합 값을 반환합니다.