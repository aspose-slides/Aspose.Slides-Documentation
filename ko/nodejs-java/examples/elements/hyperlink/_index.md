---
title: 하이퍼링크
type: docs
weight: 130
url: /ko/nodejs-java/examples/elements/hyperlink/
keywords:
- 코드 예제
- 하이퍼링크
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js에서 하이퍼링크를 추가하고 관리합니다: 텍스트, 도형 및 이미지에 링크를 걸고, PPT, PPTX 및 ODP에 대한 대상 및 동작을 설정하는 예제입니다."
---
This article demonstrates adding, accessing, removing, and updating hyperlinks on shapes using **Aspose.Slides for Node.js via Java**.

## **Add a Hyperlink**

Create a rectangle shape with a hyperlink pointing to an external website.

```js
function addHyperlink() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        let hyperlink = new aspose.slides.Hyperlink("https://www.aspose.com");
        textPortion.getPortionFormat().setHyperlinkClick(hyperlink);

        presentation.save("hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Access a Hyperlink**

Read hyperlink from a shape's text portion.

```js
function accessHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 첫 번째 도형에 하이퍼링크가 포함된 텍스트가 있다고 가정합니다.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        let hyperlink = textPortion.getPortionFormat().getHyperlinkClick();
    } finally {
        presentation.dispose();
    }
}
```

## **Remove a Hyperlink**

Clear the hyperlink from a shape's text.

```js
function removeHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 첫 번째 도형에 하이퍼링크가 포함된 텍스트가 있다고 가정합니다.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        textPortion.getPortionFormat().setHyperlinkClick(null);

        presentation.save("hyperlink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Update a Hyperlink**

Change the target of an existing hyperlink. Use `HyperlinkManager` to modify text that already contains a hyperlink, which mimics how PowerPoint updates hyperlinks safely.

```js
function updateHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 첫 번째 도형에 하이퍼링크가 포함된 텍스트가 있다고 가정합니다.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        // 기존 텍스트 내부의 하이퍼링크를 변경하려면 다음을 사용해야 합니다.
        // 속성을 직접 설정하는 대신 HyperlinkManager를 사용해야 합니다.
        // 이는 PowerPoint가 하이퍼링크를 안전하게 업데이트하는 방식을 모방합니다.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");

        presentation.save("hyperlink_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```