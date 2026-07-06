---
title: Java 프레젠테이션에서 단락 경계 가져오기
linktitle: 단락 경계
type: docs
weight: 43
url: /ko/java/paragraph-bounds/
keywords:
- 단락 경계
- 단락 좌표
- 단락 크기
- 텍스트 프레임
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java에서 단락 경계를 가져와 PowerPoint 프레젠테이션의 텍스트 위치를 최적화하는 방법을 배웁니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 단락의 경계, 크기 및 좌표를 가져오는 방법을 설명합니다. [IParagraph.getRect](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IParagraph#getRect--)을 사용하여 [ITextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframe/)에서 단락 사각형을 검색하는 방법, 표 셀 텍스트 프레임 내의 단락 좌표를 가져오는 방법을 보여주며, 측정 단위, 텍스트 줄 바꿈이 경계에 미치는 영향, 픽셀 변환 및 유효 단락 서식 값과 같은 중요한 세부 사항을 강조합니다.

## **단락의 사각형 좌표 가져오기**

[IParagraph.getRect](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IParagraph#getRect--)을 사용하여 단락의 경계 사각형을 가져옵니다.

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    java.awt.geom.Rectangle2D.Float rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **표 셀 텍스트 프레임 내 단락의 크기 가져오기**

표 셀 텍스트 프레임에서 [IParagraph](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraph/)의 크기와 좌표를 가져오려면 [IParagraph.getRect](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IParagraph#getRect--)을 사용합니다. 반환된 사각형은 표 셀 텍스트 프레임을 기준으로 하므로 슬라이드 수준의 좌표가 필요할 때 표 위치와 셀 오프셋을 추가합니다.

다음 예제는 표 셀 내부의 단락 경계를 가져와 슬라이드에 사각형을 그려 해당 경계를 시각화합니다:

```java
Presentation presentation = new Presentation("source.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);
    ICell cell = table.getRows().get_Item(1).get_Item(1);

    double cellX = table.getX() + cell.getOffsetX();
    double cellY = table.getY() + cell.getOffsetY();

    for (IParagraph paragraph : cell.getTextFrame().getParagraphs())
    {
        if (paragraph.getText().isEmpty())
            continue;

        java.awt.geom.Rectangle2D.Float paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.x + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.y + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width,
                paragraphRectangle.height);

        paragraphBoundsShape.getFillFormat().setFillType(FillType.NoFill);
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**단락 좌표는 어떤 단위로 측정되나요?**  
포인트 단위로 측정되며, 1인치는 72포인트에 해당합니다. 이는 슬라이드의 모든 좌표와 치수에 적용됩니다.

**단어 줄 바꿈이 단락의 경계에 영향을 미치나요?**  
예. [ITextFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframe/)에 대해 [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframeformat/#setWrapText-byte-)가 활성화되어 있으면 텍스트가 영역 너비에 맞게 줄 바꿈되어 단락의 실제 경계가 변경됩니다.

**단락 좌표를 내보낸 이미지의 픽셀에 신뢰성 있게 매핑할 수 있나요?**  
예. 포인트를 픽셀로 변환하려면 다음 공식을 사용합니다: pixels = points × (DPI / 72). 결과는 렌더링 또는 내보내기에 선택한 DPI에 따라 달라집니다.

**스타일 상속을 고려한 "유효한" 단락 서식 매개변수는 어떻게 얻나요?**  
[effective paragraph formatting data structure](/slides/ko/java/shape-effective-properties/)를 사용하십시오; 들여쓰기, 간격, 줄 바꿈, RTL 등에 대한 최종 통합 값을 반환합니다.