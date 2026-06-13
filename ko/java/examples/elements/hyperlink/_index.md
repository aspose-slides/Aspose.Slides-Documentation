---
title: 하이퍼링크
type: docs
weight: 130
url: /ko/java/examples/elements/hyperlink/
keywords:
- 코드 예제
- 하이퍼링크
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java에서 하이퍼링크를 추가 및 관리합니다: 텍스트, 도형 및 이미지에 대한 링크를 설정하고, PPT, PPTX, ODP에 대한 대상 및 동작을 Java 예제와 함께 지정합니다."
---
이 문서에서는 **Aspose.Slides for Java**를 사용하여 도형에 대한 하이퍼링크를 추가, 액세스, 제거 및 업데이트하는 방법을 보여줍니다.

## **하이퍼링크 추가**

외부 웹사이트를 가리키는 하이퍼링크가 포함된 사각형 도형을 만듭니다.

```java
static void addHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));
    } finally {
        presentation.dispose();
    }
}
```

## **하이퍼링크 액세스**

도형의 텍스트 부분에서 하이퍼링크 정보를 읽어옵니다.

```java
static void accessHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        IHyperlink hyperlink = textPortion.getPortionFormat().getHyperlinkClick();
    } finally {
        presentation.dispose();
    }
}
```

## **하이퍼링크 제거**

도형 텍스트에서 하이퍼링크를 제거합니다.

```java
static void removeHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        textPortion.getPortionFormat().setHyperlinkClick(null);
    } finally {
        presentation.dispose();
    }
}
```

## **하이퍼링크 업데이트**

기존 하이퍼링크의 대상 주소를 변경합니다. `HyperlinkManager`를 사용하여 이미 하이퍼링크가 포함된 텍스트를 수정하면 PowerPoint가 하이퍼링크를 안전하게 업데이트하는 방식을 모방할 수 있습니다.

```java
static void updateHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://old.example.com"));

        // 기존 텍스트 내에서 하이퍼링크를 변경하려면 다음을 사용해야 합니다
        // HyperlinkManager를 사용하고 속성을 직접 설정하지 않아야 합니다.
        // 이것은 PowerPoint가 하이퍼링크를 안전하게 업데이트하는 방식을 모방합니다.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");
    } finally {
        presentation.dispose();
    }
}
```