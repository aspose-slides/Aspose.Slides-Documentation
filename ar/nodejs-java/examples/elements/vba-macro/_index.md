---
title: ماكرو VBA
type: docs
weight: 150
url: /ar/nodejs-java/examples/elements/vba-macro/
keywords:
- مثال على الكود
- VBA
- ماكرو
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "أتمتة العروض التقديمية باستخدام Aspose.Slides for Node.js عبر Java: إنشاء، استيراد، وتأمين ماكروات VBA في صيغ PPT، PPTX، و ODP باستخدام أمثلة JavaScript واضحة."
---
توضح هذه المقالة كيفية إضافة، الوصول إلى، وإزالة ماكرو VBA باستخدام **Aspose.Slides for Node.js via Java**.

## **إضافة ماكرو VBA**

إنشاء عرض تقديمي يحتوي على مشروع VBA ووحدة ماكرو بسيطة.

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

## **الوصول إلى ماكرو VBA**

استرجاع الوحدة الأولى من مشروع VBA.

```js
function accessVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // افتراض أن العرض التقديمي يحتوي على وحدة VBA واحدة على الأقل.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **إزالة ماكرو VBA**

حذف وحدة من مشروع VBA.

```js
function removeVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // افتراض أن العرض التقديمي يحتوي على وحدة VBA واحدة على الأقل.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);

        presentation.getVbaProject().getModules().remove(firstModule);

        presentation.save("vba_macro_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```