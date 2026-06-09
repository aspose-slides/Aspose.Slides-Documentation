---
title: Tablo
type: docs
weight: 120
url: /tr/nodejs-java/examples/elements/table/
keywords:
- kod örneği
- tablo
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile tablolara çalışın: oluşturun, biçimlendirin, hücreleri birleştirin, stiller uygulayın, veri içe aktarın ve PPT, PPTX ve ODP için örneklerle dışa aktarın."
---
Node.js aracılığıyla Java ile **Aspose.Slides for Node.js via Java** kullanarak tablo ekleme, tabloya erişme, tablo silme ve hücre birleştirme örnekleri.

## **Tablo Ekle**

İki satır ve iki sütundan oluşan basit bir tablo oluşturun.

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

## **Tabloya Eriş**

Slayttan ilk tablo şekli alın.

```js
function accessTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Slayttaki ilk tabloya eriş.
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

## **Tabloyu Kaldır**

Bir slayttan tablo silin.

```js
function removeTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // İlk şeklin bir tablo olduğunu varsayın.
        let table = slide.getShapes().get_Item(0);

        slide.getShapes().remove(table);

        presentation.save("table_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Tablo Hücrelerini Birleştir**

Bir tablonun yan yana hücrelerini tek bir hücreye birleştirin.

```js
function mergeTableCells() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // İlk şeklin bir tablo olduğunu varsayın.
        let table = slide.getShapes().get_Item(0);

        // Hücreleri birleştir.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);

        presentation.save("cells_merged.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```