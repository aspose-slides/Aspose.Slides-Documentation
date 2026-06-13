---
title: समूह आकृति
type: docs
weight: 170
url: /hi/nodejs-java/examples/elements/group-shape/
keywords:
- कोड उदाहरण
- समूह आकृति
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js में समूहित आकृतियों को प्रबंधित करें: PPT, PPTX और ODP प्रस्तुतियों में उदाहरणों के साथ समूह आकृतियों को बनाएं, नेस्ट करें, संरेखित करें, पुनः क्रमित करें और शैली लागू करें।"
---
**Aspose.Slides for Node.js via Java** का उपयोग करके आकृतियों के समूह बनाने, उन्हें एक्सेस करने, अनग्रुप करने और हटाने के उदाहरण।

## **समूह आकृति जोड़ें**

दो मूल आकृतियों को शामिल करने वाला समूह बनाएं।

```js
function addGroupShape() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let group = slide.getShapes().addGroupShape();
        group.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 50, 50);
        group.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 60, 0, 50, 50);

        presentation.save("group_shape.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **समूह आकृति तक पहुंचें**

स्लाइड से पहली समूह आकृति प्राप्त करें।

```js
function accessGroupShape() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstGroup = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                firstGroup = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **समूह आकृति हटाएँ**

स्लाइड से समूह आकृति को हटाएँ।

```js
function removeGroupShape() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // मान लेते हैं कि पहला आकार एक समूह आकार है।
        slide.getShapes().removeAt(0);

        presentation.save("group_shape_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **आकृतियों को अनग्रुप करें**

आकृतियों को समूह कंटेनर से बाहर ले जाएँ।

```js
function ungroupShapes() {
    let presentation = new aspose.slides.Presentation("group_shape.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // मान लेते हैं कि पहला आकार एक समूह आकार है।
        let group = slide.getShapes().get_Item(0);

        for (let i = 0; i < group.getShapes().size(); i++) {
            let shape = group.getShapes().get_Item(i);
            // समूह से प्रत्येक आकार को स्लाइड पर क्लोन करें।
            slide.getShapes().addClone(shape);
        }

        slide.getShapes().remove(group);

        presentation.save("group_shape_ungrouped.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```