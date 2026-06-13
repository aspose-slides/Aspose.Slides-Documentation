---
title: तालिका
type: docs
weight: 120
url: /hi/nodejs-java/examples/elements/table/
keywords:
- कोड उदाहरण
- तालिका
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js में तालिकाओं के साथ काम करें: बनाएँ, स्वरूपित करें, कोशिकाओं को मिलाएँ, शैलियों को लागू करें, डेटा आयात करें, और PPT, PPTX, और ODP के उदाहरणों के साथ निर्यात करें।"
---
**Aspose.Slides for Node.js via Java** का उपयोग करके तालिकाएँ जोड़ने, उनका अभिगम करने, उन्हें हटाने और कोशिकाओं को मिलाने के उदाहरण।

## **तालिका जोड़ें**

दो पंक्तियों और दो स्तंभों वाली एक सरल तालिका बनाएं।

```js
function addTable() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let widths = java.newArray("double", [80, 80]);
        let heights = java.newArray("double", [30, 30]);
        let table = slide.getShapes().addTable(50, 50, widths, heights);

        presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **तालिका तक पहुँचें**

स्लाइड से पहली तालिका आकृति प्राप्त करें।

```js
function accessTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // स्लाइड पर पहली तालिका तक पहुँचें।
        let firstTable = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
                firstTable = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **तालिका हटाएँ**

स्लाइड से एक तालिका हटाएँ।

```js
function removeTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // मान लें कि पहला आकार एक तालिका है।
        let table = slide.getShapes().get_Item(0);

        slide.getShapes().remove(table);

        presentation.save("table_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **तालिका कोशिकाओं को मिलाएँ**

एक तालिका की आसन्न कोशिकाओं को एकल कोशिका में मिलाएँ।

```js
function mergeTableCells() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // मान लें कि पहला आकार एक तालिका है।
        let table = slide.getShapes().get_Item(0);

        // कोशिकाओं को मिलाएँ।
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);

        presentation.save("cells_merged.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```