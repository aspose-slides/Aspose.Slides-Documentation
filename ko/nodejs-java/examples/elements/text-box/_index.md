---
title: 텍스트 상자
type: docs
weight: 40
url: /ko/nodejs-java/examples/elements/text-box/
keywords:
- 코드 예제
- 텍스트 상자
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js용 Aspose.Slides에서 텍스트 상자를 사용하여 PPT, PPTX 및 ODP 프레젠테이션용 JavaScript를 사용해 텍스트를 추가, 서식 지정, 정렬, 줄 바꿈, 자동 맞춤 및 스타일링합니다."
---
Aspose.Slides에서 **텍스트 상자**는 `AutoShape`으로 표현됩니다. 거의 모든 도형에 텍스트를 포함시킬 수 있지만, 일반적인 텍스트 상자는 채우기와 테두리가 없으며 텍스트만 표시합니다.

이 가이드는 텍스트 상자를 프로그래밍 방식으로 추가, 액세스 및 제거하는 방법을 설명합니다.

## **텍스트 상자 추가**

텍스트 상자는 채우기와 테두리가 없고 서식이 지정된 텍스트가 있는 `AutoShape`일 뿐입니다. 다음은 텍스트 상자를 생성하는 방법입니다:

```js
function addTextBox() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 사각형 도형을 생성합니다 (기본적으로 채우기와 테두리가 있으며 텍스트가 없습니다).
        let textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 75, 150, 100);

        // 채우기와 테두리를 제거하여 일반 텍스트 상자처럼 보이게 합니다.
        let boxFillType = java.newByte(aspose.slides.FillType.NoFill);
        textBox.getFillFormat().setFillType(boxFillType);
        textBox.getLineFormat().getFillFormat().setFillType(boxFillType);

        // 텍스트 서식을 설정합니다.
        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        let textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        let textFillType = java.newByte(aspose.slides.FillType.Solid);
        let textFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        textFormat.getFillFormat().setFillType(textFillType);
        textFormat.getFillFormat().getSolidFillColor().setColor(textFillColor);

        // 실제 텍스트 내용을 할당합니다.
        textBox.getTextFrame().setText("Some text...");

        presentation.save("text_box.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **참고:** 비어 있지 않은 `TextFrame`을 포함하는 모든 `AutoShape`은 텍스트 상자로 사용할 수 있습니다.

## **텍스트 상자 액세스**

슬라이드에서 첫 번째 텍스트 상자를 가져옵니다.

```js
function accessTextBox() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstTextBox = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // 자동 도형만 편집 가능한 텍스트를 포함할 수 있습니다.
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                firstTextBox = shape;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **내용으로 텍스트 상자 제거**

이 예제는 특정 키워드를 포함하는 첫 번째 슬라이드의 모든 텍스트 상자를 찾아 삭제합니다:

```js
function removeTextBoxes() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shapesToRemove = [];
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                let autoShape = shape;
                if (autoShape.getTextFrame().getText().includes("Slide")) {
                    shapesToRemove.push(shape);
                }
            }
        }

        for (let i = 0; i < shapesToRemove.length; i++) {
            slide.getShapes().remove(shapesToRemove[i]);
        }

        presentation.save("text_boxes_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **팁:** 반복 중에 컬렉션을 수정하여 발생하는 오류를 방지하려면 Shape 컬렉션을 수정하기 전에 항상 복사본을 만들어야 합니다.