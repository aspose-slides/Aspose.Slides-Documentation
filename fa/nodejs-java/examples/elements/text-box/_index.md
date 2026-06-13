---
title: جعبه متن
type: docs
weight: 40
url: /fa/nodejs-java/examples/elements/text-box/
keywords:
- مثال کد
- جعبه متن
- پاورپوینت
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "کار با جعبه‌های متن در Aspose.Slides برای Node.js: افزودن، قالب‌بندی، تراز کردن، پیچاندن، تناسب خودکار و استایل‌دهی به متن با استفاده از JavaScript برای ارائه‌های PPT، PPTX و ODP."
---
در Aspose.Slides، یک **جعبه متن** توسط یک `AutoShape` نمایان می‌شود. تقریباً هر شکل می‌تواند متن داشته باشد، اما یک جعبه متن معمولی پر یا حاشیه‌ای ندارد و فقط متن را نمایش می‌دهد.

این راهنما نحوه افزودن، دسترسی و حذف جعبه‌های متن به صورت برنامه‌نویسی را توضیح می‌دهد.

## **افزودن یک جعبه متن**

یک جعبه متن صرفاً یک `AutoShape` بدون پر یا حاشیه و با متنی قالب‌بندی‌شده است. در ادامه نحوهٔ ایجاد آن آورده شده است:

```js
function addTextBox() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // یک شکل مستطیلی ایجاد می‌کند (به‌صورت پیش‌فرض پر با حاشیه و بدون متن است).
        let textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 75, 150, 100);

        // پر و حاشیه را حذف می‌کند تا شبیه یک جعبه متن معمولی باشد.
        let boxFillType = java.newByte(aspose.slides.FillType.NoFill);
        textBox.getFillFormat().setFillType(boxFillType);
        textBox.getLineFormat().getFillFormat().setFillType(boxFillType);

        // قالب‌بندی متن را تنظیم می‌کند.
        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        let textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        let textFillType = java.newByte(aspose.slides.FillType.Solid);
        let textFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        textFormat.getFillFormat().setFillType(textFillType);
        textFormat.getFillFormat().getSolidFillColor().setColor(textFillColor);

        // محتوای واقعی متن را اختصاص می‌دهد.
        textBox.getTextFrame().setText("Some text...");

        presentation.save("text_box.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **توجه:** هر `AutoShape`ی که دارای یک `TextFrame` غیر خالی باشد می‌تواند به عنوان جعبه متن عمل کند.

## **دسترسی به جعبه متن**

اولین جعبه متن را از اسلاید بازیابی کنید.

```js
function accessTextBox() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstTextBox = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // فقط AutoShapeها می‌توانند متن قابل ویرایش داشته باشند.
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                firstTextBox = shape;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **حذف جعبه‌های متن بر حسب محتوا**

این مثال تمام جعبه‌های متنی را که در اسلاید اول حاوی یک کلمه کلیدی خاص هستند پیدا کرده و حذف می‌کند:

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

> 💡 **نکته:** همیشه قبل از تغییر مجموعهٔ اشکال در هنگام تکرار، یک نسخهٔ کپی از آن ایجاد کنید تا از خطاهای تغییر مجموعه جلوگیری کنید.