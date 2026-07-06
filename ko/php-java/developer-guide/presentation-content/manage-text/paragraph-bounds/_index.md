---
title: PHP에서 프레젠테이션의 단락 경계 가져오기
linktitle: 단락 경계
type: docs
weight: 43
url: /ko/php-java/paragraph-bounds/
keywords:
- 단락 경계
- 단락 좌표
- 단락 크기
- 텍스트 프레임
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Java를 통해 PHP용 Aspose.Slides에서 단락 경계를 검색하여 PowerPoint 프레젠테이션의 텍스트 위치를 최적화하는 방법을 알아보세요."
---
## **개요**

이 문서에서는 Aspose.Slides에서 단락의 경계, 크기 및 좌표를 가져오는 방법을 설명합니다. [Paragraph::getRect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraph/getrect/)를 사용하여 [TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/)에서 단락 사각형을 검색하는 방법, 표 셀 텍스트 프레임 내에서 단락 좌표를 가져오는 방법을 보여 주며, 측정 단위, 텍스트 줄 바꿈이 경계에 미치는 영향, 픽셀 변환 및 실제 단락 서식 값과 같은 중요한 세부 사항을 강조합니다.

## **단락의 사각형 좌표 가져오기**

[Paragraph::getRect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraph/getrect/)를 사용하여 단락의 경계 사각형을 가져옵니다.

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $rectangle = $paragraph->getRect();
} finally {
    $presentation->dispose();
}
```

## **표 셀 TextFrame 내부 단락의 크기 가져오기**

표 셀 텍스트 프레임 내에서 [Paragraph](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraph/)의 크기와 좌표를 가져오려면 [Paragraph::getRect](https://reference.aspose.com/slides/ko/php-java/aspose.slides/paragraph/getrect/)를 사용합니다. 반환된 사각형은 표 셀 텍스트 프레임을 기준으로 하므로 슬라이드 수준 좌표가 필요할 때는 표 위치와 셀 오프셋을 추가합니다.

다음 예제는 표 셀 내부의 단락 경계를 가져오고 슬라이드에 사각형을 그려 해당 경계를 시각화합니다:

```php
$presentation = new Presentation("source.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);
    $cell = $table->getRows()->get_Item(1)->get_Item(1);

    $cellX = java_values($table->getX()) + java_values($cell->getOffsetX());
    $cellY = java_values($table->getY()) + java_values($cell->getOffsetY());

    foreach ($cell->getTextFrame()->getParagraphs() as $paragraph) {
        if ($paragraph->getText() == "") {
            continue;
        }

        $paragraphRectangle = $paragraph->getRect();
        $paragraphRectangleX = java_values($paragraphRectangle->getX()) + $cellX;
        $paragraphRectangleY = java_values($paragraphRectangle->getY()) + $cellY;
        $paragraphRectangleWidth = java_values($paragraphRectangle->getWidth());
        $paragraphRectangleHeight = java_values($paragraphRectangle->getHeight());

        $paragraphBoundsShape = $slide->getShapes()->addAutoShape(
            ShapeType::Rectangle,
            $paragraphRectangleX,
            $paragraphRectangleY,
            $paragraphRectangleWidth,
            $paragraphRectangleHeight
        );

        $paragraphBoundsShape->getFillFormat()->setFillType(FillType::NoFill);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**단락 좌표는 어떤 단위로 측정됩니까?**

포인트 단위로 측정됩니다. 1인치는 72포인트에 해당합니다. 이는 슬라이드의 모든 좌표와 치수에 적용됩니다.

**단어 줄 바꿈이 단락의 경계에 영향을 줍니까?**

예. [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframeformat/setwraptext/)가 [TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/)에 대해 활성화되면 텍스트가 영역 너비에 맞게 줄 바꿈되어 단락의 실제 경계가 변경됩니다.

**단락 좌표를 내보낸 이미지의 픽셀에 신뢰할 수 있게 매핑할 수 있습니까?**

예. 포인트를 픽셀로 변환하려면 다음 수식을 사용합니다: 픽셀 = 포인트 × (DPI / 72). 결과는 렌더링 또는 내보내기에 선택된 DPI에 따라 달라집니다.

**스타일 상속을 고려한 "실제" 단락 서식 매개변수를 어떻게 얻을 수 있습니까?**

[effective paragraph formatting data structure](/slides/ko/php-java/shape-effective-properties/)를 사용하십시오; 들여쓰기, 간격, 줄 바꿈, RTL 및 기타에 대한 최종 통합 값을 반환합니다.