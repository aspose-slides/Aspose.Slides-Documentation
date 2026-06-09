---
title: Köprü
type: docs
weight: 130
url: /tr/nodejs-java/examples/elements/hyperlink/
keywords:
- kod örneği
- köprü
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js'te köprüleri ekleyin ve yönetin: bağlam metni, şekiller ve görseller, PPT, PPTX ve ODP için hedefleri ve eylemleri örneklerle ayarlayın."
---
Bu makale, **Aspose.Slides for Node.js via Java** kullanarak şekillerdeki köprüleri ekleme, erişme, kaldırma ve güncelleme işlemlerini gösterir.

## **Köprüyü Ekle**

Harici bir web sitesine işaret eden bir köprüye sahip bir dikdörtgen şekil oluşturun.

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

## **Köprüyü Eriş**

Şeklin metin bölümünden köprüyü okuyun.

```js
function accessHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // İlk şeklin köprü içeren metni içerdiğini varsayalım.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        let hyperlink = textPortion.getPortionFormat().getHyperlinkClick();
    } finally {
        presentation.dispose();
    }
}
```

## **Köprüyü Kaldır**

Şeklin metnindeki köprüyü temizleyin.

```js
function removeHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // İlk şeklin köprü içeren metni içerdiğini varsayalım.
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

## **Köprüyü Güncelle**

Mevcut bir köprünün hedefini değiştirin. `HyperlinkManager`'ı, zaten bir köprü içeren metni değiştirmek için kullanın; bu, PowerPoint'in köprüleri güvenli bir şekilde güncelleme şeklini taklit eder.

```js
function updateHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // İlk şeklin köprü içeren metni içerdiğini varsayalım.
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        // Mevcut metin içindeki bir köprüyü değiştirmek şu şekilde yapılmalıdır
        // HyperlinkManager kullanılarak, özelliği doğrudan ayarlamaktan ziyade.
        // Bu, PowerPoint'in köprüleri güvenli bir şekilde güncelleme şeklini taklit eder.
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");

        presentation.save("hyperlink_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```