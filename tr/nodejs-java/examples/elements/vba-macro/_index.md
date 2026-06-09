---
title: VBA Makrosu
type: docs
weight: 150
url: /tr/nodejs-java/examples/elements/vba-macro/
keywords:
- kod örneği
- VBA
- makro
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java ile sunumları otomatikleştirin: PPT, PPTX ve ODP'de VBA makrolarını oluşturun, içe aktarın ve güvenli hale getirin, net JavaScript örnekleri kullanarak."
---
Bu makale, **Aspose.Slides for Node.js via Java** kullanarak VBA makrolarını ekleme, erişme ve kaldırma işlemlerini gösterir.

## **VBA Makrosu Ekle**
VBA projesi ve basit bir makro modülü içeren bir sunum oluşturun.

```js
function addVbaMacro() {
    let presentation = new aspose.slides.Presentation();
    try {
        presentation.setVbaProject(new aspose.slides.VbaProject());

        let module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        presentation.save("vba_macro.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **VBA Makrosuna Erişim**
VBA projesinden ilk modülü alın.

```js
function accessVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // Sunumun en az bir VBA modülü olduğunu varsayarak.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **VBA Makrosunu Kaldır**
VBA projesinden bir modülü silin.

```js
function removeVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // Sunumun en az bir VBA modülü olduğunu varsayarak.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);

        presentation.getVbaProject().getModules().remove(firstModule);

        presentation.save("vba_macro_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```