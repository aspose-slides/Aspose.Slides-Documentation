---
title: SmartArt
type: docs
weight: 140
url: /tr/nodejs-java/examples/elements/smart-art/
keywords:
- kod örneği
- SmartArt
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js'te SmartArt ile çalışın: PowerPoint ve OpenDocument sunumları için JavaScript kullanarak diyagramları oluşturun, düzenleyin, dönüştürün ve stil ekleyin."
---
Bu makale, **Aspose.Slides for Node.js via Java** kullanarak SmartArt grafiklerini eklemeyi, bunlara erişmeyi, kaldırmayı ve düzenleri değiştirmeyi göstermektedir.

## **Add SmartArt**
Yerleşik düzenlerden birini kullanarak bir SmartArt grafiği ekleyin.

```js
function addSmartArt() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, aspose.slides.SmartArtLayoutType.BasicProcess);

        presentation.save("smartart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Access SmartArt**
Bir slayttaki ilk SmartArt nesnesini alın.

```js
function accessSmartArt() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstSmartArt = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
                firstSmartArt = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Remove SmartArt**
Slayttan bir SmartArt şekli silin.

```js
function removeSmartArt() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // İlk şeklin SmartArt olduğunu varsayarak.
        let smartArt = slide.getShapes().get_Item(0);

        slide.getShapes().remove(smartArt);

        presentation.save("smartart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Change SmartArt Layout**
Mevcut bir SmartArt grafiğinin düzen türünü güncelleyin.

```js
function changeSmartArtLayout() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // İlk şeklin SmartArt olduğunu varsayarak.
        let smartArt = slide.getShapes().get_Item(0);

        smartArt.setLayout(aspose.slides.SmartArtLayoutType.VerticalPictureList);

        presentation.save("smartart_layout_changed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```