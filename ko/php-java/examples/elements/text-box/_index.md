---
title: 텍스트 상자
type: docs
weight: 40
url: /ko/php-java/examples/elements/text-box/
keywords:
- 텍스트 상자
- 텍스트 상자 추가
- 텍스트 상자 접근
- 텍스트 상자 제거
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "PHP와 Aspose.Slides를 사용하여 텍스트 상자를 만들고 형식 지정합니다: 글꼴, 정렬, 자동 줄 바꿈, 자동 맞춤 및 링크를 설정하여 PowerPoint와 OpenDocument용 슬라이드를 다듬습니다."
---
Aspose.Slides에서 **텍스트 상자**는 `AutoShape`으로 표시됩니다. 거의 모든 모양이 텍스트를 포함할 수 있지만, 일반적인 텍스트 상자는 채우기와 테두리가 없으며 텍스트만 표시합니다.

이 가이드에서는 텍스트 상자를 프로그래밍 방식으로 추가, 접근 및 제거하는 방법을 설명합니다.

## **텍스트 상자 추가**

텍스트 상자는 채우기와 테두리가 없고 서식이 지정된 텍스트가 포함된 `AutoShape`에 불과합니다. 아래는 이를 만드는 방법입니다:

```php
function addTextBox() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 사각형 모양을 생성합니다 (기본값은 테두리와 채우기가 있으며 텍스트는 없습니다).
        $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

        // 채우기와 테두리를 제거하여 일반 텍스트 상자처럼 보이게 합니다.
        $textBox->getFillFormat()->setFillType(FillType::NoFill);
        $textBox->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        // 텍스트 서식을 설정합니다.
        $paragraph = $textBox->getTextFrame()->getParagraphs()->get_Item(0);
        $portionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $portionFormat->getFillFormat()->setFillType(FillType::Solid);
        $portionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        // 실제 텍스트 내용을 할당합니다.
        $textBox->getTextFrame()->setText("Some text...");

        $presentation->save("text_box.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Note:** 비어 있지 않은 `TextFrame`을 포함하는 모든 `AutoShape`는 텍스트 상자로 사용할 수 있습니다.

## **내용으로 텍스트 상자 접근**

특정 키워드(예: "Slide")를 포함하는 모든 텍스트 상자를 찾으려면, 모양을 반복하면서 텍스트를 확인하십시오:

```php
function accessTextBox() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 슬라이드의 첫 번째 텍스트 상자에 접근합니다.
        $firstTextBox = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $firstTextBox = $shape;
                if (strpos($firstTextBox->getTextFrame()->getText(), "Slide") !== false) {
                    // 일치하는 텍스트 상자에 대해 작업을 수행합니다.
                }
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **내용으로 텍스트 상자 제거**

이 예제는 특정 키워드를 포함하는 첫 번째 슬라이드의 모든 텍스트 상자를 찾아 삭제합니다:

```php
function removeTextBoxes() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shapesToRemove = [];

        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $autoShape = $shape;
                if (strpos($autoShape->getTextFrame()->getText(), "Slide") !== false) {
                    $shapesToRemove[] = $shape;
                }
            }
        }

        foreach ($shapesToRemove as $shape) {
            $slide->getShapes()->remove($shape);
        }

        $presentation->save("text_boxes_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tip:** 반복 중에 컬렉션 수정 오류를 방지하려면, 수정하기 전에 항상 Shape 컬렉션의 복사본을 만들어야 합니다.