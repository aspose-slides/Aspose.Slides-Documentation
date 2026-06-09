---
title: Metin Kutusu
type: docs
weight: 40
url: /tr/nodejs-java/examples/elements/text-box/
keywords:
- kod örneği
- metin kutusu
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js içinde metin kutularıyla çalışın: PPT, PPTX ve ODP sunumları için JavaScript kullanarak metni ekleyin, biçimlendirin, hizalayın, kaydırın, otomatik sığdırın ve stillendirin."
---
Aspose.Slides'ta bir **metin kutusu**, bir `AutoShape` ile temsil edilir. Neredeyse her şekil metin içerebilir, ancak tipik bir metin kutusunun dolgu ya da kenarlığı yoktur ve yalnızca metni gösterir.

Bu kılavuz, metin kutularını programlı olarak ekleme, erişme ve kaldırma yöntemlerini açıklar.

## **Metin Kutusu Ekle**

Bir metin kutusu, dolgu ve kenarlığı olmayan ve biçimlendirilmiş metin içeren bir `AutoShape`dır. İşte nasıl oluşturulur:

```js
function addTextBox() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Bir dikdörtgen şekil oluştur (varsayılan olarak kenarlıklı ve dolu, metin yok).
        let textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 75, 150, 100);

        // Dolgu ve kenarlığı kaldırarak tipik bir metin kutusu gibi görünmesini sağla.
        let boxFillType = java.newByte(aspose.slides.FillType.NoFill);
        textBox.getFillFormat().setFillType(boxFillType);
        textBox.getLineFormat().getFillFormat().setFillType(boxFillType);

        // Metin biçimlendirmesini ayarla.
        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        let textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        let textFillType = java.newByte(aspose.slides.FillType.Solid);
        let textFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        textFormat.getFillFormat().setFillType(textFillType);
        textFormat.getFillFormat().getSolidFillColor().setColor(textFillColor);

        // Gerçek metin içeriğini ata.
        textBox.getTextFrame().setText("Some text...");

        presentation.save("text_box.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note:** Boş olmayan bir `TextFrame` içeren herhangi bir `AutoShape`, metin kutusu olarak işlev görebilir.

## **Metin Kutusuna Erişme**

Slayttan ilk metin kutusunu alın.

```js
function accessTextBox() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstTextBox = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Yalnızca AutoShape'ler düzenlenebilir metin içerebilir.
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                firstTextBox = shape;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **İçeriğe Göre Metin Kutularını Kaldır**

Bu örnek, belirli bir anahtar kelime içeren ilk slayttaki tüm metin kutularını bulur ve siler:

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

> 💡 **Tip:** İterasyon sırasında koleksiyonu değiştirmemek için şekil koleksiyonunun bir kopyasını oluşturun; bu, koleksiyon değiştirme hatalarını önler.