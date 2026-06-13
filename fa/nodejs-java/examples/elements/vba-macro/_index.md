---
title: ماکرو VBA
type: docs
weight: 150
url: /fa/nodejs-java/examples/elements/vba-macro/
keywords:
- مثال کد
- VBA
- ماکرو
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "ارائه‌ها را با Aspose.Slides برای Node.js از طریق Java خودکار کنید: ماکروهای VBA را در PPT، PPTX و ODP با استفاده از مثال‌های واضح JavaScript ایجاد، وارد و ایمن کنید."
---
این مقاله نشان می‌دهد که چگونه می‌توانید VBA ماکروها را با استفاده از **Aspose.Slides for Node.js via Java** اضافه، دسترسی پیدا کنید و حذف کنید.

## **افزودن یک ماکرو VBA**

یک ارائه با یک پروژه VBA و یک ماژول ماکرو ساده ایجاد کنید.

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

## **دسترسی به یک ماکرو VBA**

ماژول اول را از پروژه VBA بازیابی کنید.

```js
function accessVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // فرض می‌کنیم ارائه حداقل یک ماژول VBA داشته باشد.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **حذف یک ماکرو VBA**

یک ماژول را از پروژه VBA حذف کنید.

```js
function removeVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // فرض می‌کنیم ارائه حداقل یک ماژول VBA داشته باشد.
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);

        presentation.getVbaProject().getModules().remove(firstModule);

        presentation.save("vba_macro_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```