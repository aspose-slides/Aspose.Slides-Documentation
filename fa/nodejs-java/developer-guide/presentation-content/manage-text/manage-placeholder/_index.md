---
title: مدیریت Placeholderهای ارائه در JavaScript
linktitle: مدیریت Placeholderها
type: docs
weight: 10
url: /fa/nodejs-java/manage-placeholder/
keywords:
- جای‌گیر
- جای‌گیر متن
- جای‌گیر تصویر
- جای‌گیر نمودار
- متن راهنما
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "به‌راحتی placeholderها را در Aspose.Slides برای Node.js via Java مدیریت کنید: متن را جایگزین کنید، راهنماها را سفارشی کنید و شفافیت تصویر را در PowerPoint و OpenDocument تنظیم کنید."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد که به‌صورت برنامه‌نویسی‌ای placeholderهای ارائه را مدیریت کنید. این مقاله توضیح می‌دهد چگونه placeholderها را در اسلایدها پیدا کنید و متن آن‌ها را تغییر دهید، متن راهنمای سفارشی برای قالب‌های placeholder تنظیم کنید، و شفافیت تصویر استفاده‌شده به‌عنوان پس‌زمینه placeholder را تنظیم کنید. همچنین شامل یک بخش پرسش‌های متداول کوتاه است که تفاوت بین placeholderهای پایه و اشکال محلی را روشن می‌کند، نحوه اعمال تغییرات placeholder از طریق قالب‌ها یا مسترها را شرح می‌دهد، و به مدیریت placeholderهای سرصفحه و پاورقی اشاره می‌کند.

## **تغییر متن در Placeholder**

با استفاده از [Aspose.Slides for Node.js via Java](/slides/fa/nodejs-java/)، می‌توانید placeholderها را در اسلایدهای ارائه پیدا کرده و اصلاح کنید. Aspose.Slides به شما امکان می‌دهد تغییراتی در متن یک placeholder اعمال کنید.

**پیش‌نیاز**: شما به ارائه‌ای نیاز دارید که حاوی یک placeholder باشد. می‌توانید چنین ارائه‌ای را در برنامه استاندارد Microsoft PowerPoint ایجاد کنید.

این‌گونه می‌توانید از Aspose.Slides برای جایگزینی متن در placeholder آن ارائه استفاده کنید:

1. یک شی از کلاس [`Presentation`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید و ارائه را به‌عنوان آرگومان منتقل کنید.
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.
3. از طریق اشکال حلقه بزنید تا placeholder را پیدا کنید.
4. شکل placeholder را به نوع [`AutoShape`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/AutoShape) تبدیل کنید و با استفاده از [`TextFrame`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/TextFrame) مرتبط با [`AutoShape`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/AutoShape) متن را تغییر دهید.
5. ارائه تغییر یافته را ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه متن در یک placeholder را تغییر دهید:

```javascript
// یک شی از کلاس Presentation ایجاد می‌کند
var pres = new aspose.slides.Presentation("ReplacingText.pptx");
try {
    // به اولین اسلاید دسترسی پیدا می‌کند
    var sld = pres.getSlides().get_Item(0);
    // از میان اشکال تکرار می‌کند تا placeholder را پیدا کند
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (shp.getPlaceholder() != null) {
            // متن هر placeholder را تغییر می‌دهد
            shp.getTextFrame().setText("This is Placeholder");
        }
    }
    // ارائه را روی دیسک ذخیره می‌کند
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تنظیم متن راهنما در Placeholder**

قالب‌های استاندارد و پیش‌ساخته شامل متن‌های راهنمای placeholder مانند ***Click to add a title*** یا ***Click to add a subtitle*** هستند. با استفاده از Aspose.Slides می‌توانید متن‌های راهنمای مورد نظر خود را در قالب‌های placeholder وارد کنید.

این کد JavaScript نشان می‌دهد چگونه متن راهنما را در یک placeholder تنظیم کنید:

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // در اسلاید تکرار می‌کند
    for (let i = 0; i < slide.getSlide().getShapes().size(); i++) {
        let shape = slide.getSlide().getShapes().get_Item(i);
        if ((shape.getPlaceholder() != null) && (java.instanceOf(shape, "com.aspose.slides.AutoShape"))) {
            var text = "";
            // PowerPoint متن "Click to add title" را نمایش می‌دهد
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.CenteredTitle) {
                text = "Add Title";
            } else // زیرنویس را اضافه می‌کند
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.Subtitle) {
                text = "Add Subtitle";
            }
            shape.getTextFrame().setText(text);
            console.log("Placeholder with text: " + text);
        }
    }
    pres.save("Placeholders_PromptText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تنظیم شفافیت تصویر Placeholder**

Aspose.Slides به شما امکان می‌دهد شفافیت تصویر پس‌زمینه در یک placeholder متن را تنظیم کنید. با تنظیم شفافیت تصویر در چنین قاب‌هایی، می‌توانید متن یا تصویر را برجسته کنید (بسته به رنگ‌های متن و تصویر).

این کد JavaScript نشان می‌دهد چگونه شفافیت پس‌زمینه تصویر (درون یک شکل) را تنظیم کنید:

```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (var i = 0; i < operationCollection.size(); i++) {
    if (java.instanceOf(operationCollection.get_Item(i), "com.aspose.slides.AlphaModulateFixed")) {
        var alphaModulate = operationCollection.get_Item(i);
        var currentValue = 100 - alphaModulate.getAmount();
        console.log("Current transparency value: " + currentValue);
        var alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}
presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
```

## **پرسش‌های متداول**

**placeholder پایه چیست و چه تفاوتی با یک شکل محلی در اسلاید دارد؟**

placeholder پایه، شکل اصلی در یک layout یا master است که شکل اسلاید از آن ارث می‌برد—نوع، موقعیت و برخی قالب‌بندی‌ها از آن گرفته می‌شود. شکل محلی مستقل است؛ اگر placeholder پایه‌ای وجود نداشته باشد، ارث‌بری اعمال نمی‌شود.

**چگونه می‌توان تمام عناوین یا زیرنویس‌ها را در یک ارائه بدون عبور از هر اسلاید به‌روزرسانی کرد؟**

placeholder مربوطه را در layout یا master ویرایش کنید. اسلایدهایی که بر پایه آن layoutها/آن master ساخته شده‌اند، به‌طور خودکار تغییر را دریافت خواهند کرد.

**چگونه می‌توان placeholderهای استاندارد سرصفحه/پاورقی—تاریخ و زمان، شماره اسلاید و متن پاورقی—را کنترل کرد؟**

از مدیران HeaderFooter در محدوده مناسب (اسلایدهای عادی، layoutها، master، یادداشت‌ها/پخش‌های توزیعی) استفاده کنید تا آن placeholderها را روشن یا خاموش کنید و محتوای آن‌ها را تنظیم کنید.