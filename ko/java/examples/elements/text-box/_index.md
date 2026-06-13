---
title: 텍스트 상자
type: docs
weight: 40
url: /ko/java/examples/elements/text-box/
keywords:
- 코드 예제
- 텍스트 상자
- 파워포인트
- 오픈문서
- 프레젠테이션
- 자바
- Aspose.Slides
description: "Aspose.Slides for Java에서 텍스트 상자를 사용합니다: Java를 사용하여 PPT, PPTX 및 ODP 프레젠테이션의 텍스트를 추가, 서식 지정, 정렬, 줄 바꿈, 자동 맞춤 및 스타일링합니다."
---
Aspose.Slides에서 **텍스트 상자**는 `AutoShape`으로 표시됩니다. 거의 모든 도형이 텍스트를 포함할 수 있지만, 일반적인 텍스트 상자는 채우기나 테두리가 없으며 텍스트만 표시합니다.

이 가이드는 텍스트 상자를 프로그래밍 방식으로 추가, 접근 및 제거하는 방법을 설명합니다.

## **텍스트 상자 추가**

텍스트 상자는 채우기와 테두리가 없고 서식이 지정된 텍스트가 포함된 `AutoShape`에 불과합니다. 다음은 이를 만드는 방법입니다:

```java
public static void addTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 사각형 도형을 생성합니다 (기본적으로 테두리와 채우기가 있으며 텍스트는 없습니다).
        IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100);

        // 채우기와 테두리를 제거하여 일반 텍스트 상자처럼 보이게 합니다.
        textBox.getFillFormat().setFillType(FillType.NoFill);
        textBox.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        // 텍스트 서식을 설정합니다.
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        IPortionFormat textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        textFormat.getFillFormat().setFillType(FillType.Solid);
        textFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        // 실제 텍스트 내용을 할당합니다.
        textBox.getTextFrame().setText("Some text...");
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **참고:** 비어 있지 않은 `TextFrame`을 포함하는 모든 `AutoShape`은 텍스트 상자로 사용할 수 있습니다.

## **내용으로 텍스트 상자 접근**

특정 키워드(예: "Slide")가 포함된 모든 텍스트 상자를 찾으려면 도형을 반복하면서 텍스트를 확인합니다:

```java
public static void accessTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        for (IShape shape : slide.getShapes()) {
            // 편집 가능한 텍스트를 포함할 수 있는 것은 AutoShape뿐입니다.
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    // 일치하는 텍스트 상자에 대해 작업을 수행합니다.
                }
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **내용으로 텍스트 상자 제거**

이 예제는 첫 슬라이드에서 특정 키워드가 포함된 모든 텍스트 상자를 찾아 삭제합니다:

```java
public static void removeTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        List<IShape> shapesToRemove = new ArrayList<IShape>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    shapesToRemove.add(shape);
                }
            }
        }

        for (IShape shape : shapesToRemove) {
            slide.getShapes().remove(shape);
        }
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **팁:** 반복 중에 컬렉션을 수정할 때 컬렉션 수정 오류를 방지하기 위해 항상 도형 컬렉션의 복사본을 만든 후 수정하세요.