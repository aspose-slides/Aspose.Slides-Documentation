---
title: MathText
type: docs
weight: 160
url: /ko/php-java/examples/elements/math-text/
keywords:
- 수학 텍스트
- 수학 텍스트 추가
- 수학 텍스트 접근
- 수학 텍스트 제거
- 수학 텍스트 서식 지정
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides를 사용하여 PHP에서 수학 텍스트 작업: 방정식, 분수, 근호, 스크립트, 서식 지정 등을 만들고 편집하며 PPT 및 PPTX용 결과를 렌더링합니다."
---
**Aspose.Slides for PHP via Java**를 사용하여 수학 텍스트 도형을 작업하고 방정식을 서식 지정하는 방법을 보여줍니다.

## **수학 텍스트 추가**

분수와 피타고라스 정리를 포함하는 수학 도형을 만듭니다.

```php
function addMathText() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 슬라이드에 수학 도형을 추가합니다.
        $mathShape = $slide->getShapes()->addMathShape(0, 0, 720, 150);

        // 수학 단락에 접근합니다.
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $mathParagraph = $portion->getMathParagraph();

        // 간단한 분수 추가: x / y.
        $fraction = (new MathematicalText("x"))->divide("y");
        $mathParagraph->add(new MathBlock($fraction));

        // 방정식 추가: c² = a² + b².
        $mathBlock = (new MathematicalText("c"))
            - >setSuperscript("2")
            - >join("=")
            - >join((new MathematicalText("a"))->setSuperscript("2"))
            - >join("+")
            - >join((new MathematicalText("b"))->setSuperscript("2"));
        $mathParagraph->add($mathBlock);

        $presentation->save("math_text.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **수학 텍스트 접근**

슬라이드에서 수학 단락을 포함하는 도형을 찾습니다.

```php
function accessMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 수학 단락을 포함하는 첫 번째 도형을 찾습니다.
        $mathShape = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $textFrame = $shape->getTextFrame();
                if ($textFrame !== null) {
                    $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
                    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                        $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                        $portionCount = java_values($paragraph->getPortions()->getCount());
                        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                            $portion = $paragraph->getPortions()->get_Item($portionIndex);
                            if (java_instanceof($portion, new JavaClass("com.aspose.slides.MathPortion"))) {
                                $mathShape = $shape;
                                break 3;
                            }
                        }
                    }
                }
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **수학 텍스트 제거**

슬라이드에서 수학 도형을 삭제합니다.

```php
function removeMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 슬라이드의 첫 번째 도형이 수학 도형이라고 가정합니다.
        $mathShape = $slide->getShapes()->get_Item(0);

        // 슬라이드에서 수학 도형을 제거합니다.
        $slide->getShapes()->remove($mathShape);

        $presentation->save("math_text_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **수학 텍스트 서식 지정**

수학 부분에 대한 글꼴 속성을 설정합니다.

```php
function formatMathText() {
    $presentation = new Presentation("math_text.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 슬라이드의 첫 번째 도형이 수학 도형이라고 가정합니다.
        $mathShape = $slide->getShapes()->get_Item(0);

        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setFontHeight(20);

        $presentation->save("math_text_formatted.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```