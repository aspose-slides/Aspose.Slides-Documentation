---
title: Mürekkep
type: docs
weight: 180
url: /tr/nodejs-java/examples/elements/ink/
keywords:
- kod örneği
- mürekkep
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js'de Mürekkep ile çalışın: çizim yapın, içe aktarın ve darbeleri düzenleyin, renk ve genişliği ayarlayın ve örneklerle PPT, PPTX ve ODP'ye dışa aktarın."
---
Bu makale, mevcut mürekkep şekillerine erişme ve bunları **Aspose.Slides for Node.js via Java** kullanarak kaldırma örnekleri sunar.

> ❗ **Not:** Ink şekilleri, özel cihazlardan gelen kullanıcı girişini temsil eder. Aspose.Slides programlı olarak yeni mürekkep darbeleri oluşturamaz, ancak mevcut mürekkebi okuyabilir ve değiştirebilirsiniz.

## **Mürekkebe Erişim**

Bir slaytta ilk mürekkep şekli alın.

```js
function accessInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let inkShape = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IInk")) {
                inkShape = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Mürekkebi Kaldır**

Slayttan bir mürekkep şekli silin.

```js
function removeInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Mürekkep şeklinin slayttaki ilk şekil olduğunu varsayarak.
        slide.getShapes().removeAt(0);

        presentation.save("ink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```