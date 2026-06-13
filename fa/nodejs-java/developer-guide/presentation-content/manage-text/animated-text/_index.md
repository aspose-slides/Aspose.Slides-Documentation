---
title: انیمیشن متن PowerPoint در JavaScript
linktitle: متن انیمیشن‌شده
type: docs
weight: 60
url: /fa/nodejs-java/animated-text/
keywords:
- متن انیمیشن‌شده
- انیمیشن متن
- پاراگراف انیمیشن‌شده
- انیمیشن پاراگراف
- اثر انیمیشن
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "متن انیمیشن‌دار پویا را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Node.js ایجاد کنید، همراه با مثال‌های کد به‌صورت آسان و بهینه."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه با متن‌های متحرک در Aspose.Slides کار کنید؛ با اعمال افکت‌های انیمیشن بر پاراگراف‌های منفرد و دریافت افکت‌های قبلاً اختصاص یافته به پاراگراف‌ها در یک فریم متن. تمرکز بر روش‌های API برای افزودن انیمیشن در سطح پاراگراف و بررسی افکت‌های انیمیشن موجود در یک ارائه است.

## **افزودن افکت‌های انیمیشن به پاراگراف‌ها**

ما متد [**addEffect()**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Sequence#addEffect-aspose.slides.IParagraph-int-int-int-) را به کلاس‌های [**Sequence**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Sequence) و [**Sequence**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Sequence) اضافه کرده‌ایم. این متد به شما امکان می‌دهد افکت انیمیشن را به یک پاراگراف واحد اضافه کنید. کد نمونه زیر نشان می‌دهد چگونه یک افکت انیمیشن را به یک پاراگراف اضافه کنید:

```javascript
var presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // پاراگراف را برای افزودن افکت انتخاب کنید
    var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    // افکت انیمیشن Fly را به پاراگراف انتخاب‌شده اضافه کنید
    var effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(paragraph, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    presentation.save("AnimationEffectinParagraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **دریافت افکت‌های انیمیشن در پاراگراف‌ها**

ممکن است بخواهید افکت‌های انیمیشن اضافه شده به یک پاراگراف را پیدا کنید—به عنوان مثال، در یک سناریو می‌خواهید افکت‌های انیمیشن یک پاراگراف را به پاراگراف یا شکل دیگری اعمال کنید.

Aspose.Slides برای Node.js از طریق Java به شما اجازه می‌دهد تمام افکت‌های انیمیشنی را که بر پاراگراف‌های موجود در یک فریم متن (شکل) اعمال شده‌اند، دریافت کنید. کد نمونه زیر نشان می‌دهد چگونه افکت‌های انیمیشن یک پاراگراف را دریافت کنید:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    for (let i = 0; i < autoShape.getTextFrame().getParagraphs().getCount(); i++) {
        let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i);
        var effects = sequence.getEffectsByParagraph(paragraph);
        if (effects.length > 0) {
            console.log("Paragraph \"" + paragraph.getText() + "\" has " + effects[0].getType() + " effect.");
        }
    }
} finally {
    pres.dispose();
}
```

## **پرسش‌های متداول**

**انیمیشن‌های متنی با انتقال اسلایدها چه تفاوتی دارند و آیا می‌توان آنها را ترکیب کرد؟**

انیمیشن‌های متنی رفتار یک شیء را بر زمان در یک اسلاید کنترل می‌کنند، در حالی که [انتقال‌ها](/slides/fa/nodejs-java/slide-transition/) نحوه تغییر اسلایدها را کنترل می‌کنند. این دو مستقل هستند و می‌توانند همزمان استفاده شوند؛ ترتیب پخش توسط زمان‌بندی انیمیشن و تنظیمات انتقال تعیین می‌شود.

**آیا انیمیشن‌های متنی هنگام صادرات به PDF یا تصاویر حفظ می‌شوند؟**

خیر. PDF و تصاویر رستر استاتیک هستند، بنابراین تنها یک حالت ثابت از اسلاید بدون حرکت مشاهده می‌کنید. برای حفظ حرکت از [ویدیو](/slides/fa/nodejs-java/convert-powerpoint-to-video/) یا صادرات به [HTML](/slides/fa/nodejs-java/export-to-html5/) استفاده کنید.

**آیا انیمیشن‌های متنی در چینش‌ها و اسلاید مستر کار می‌کنند؟**

افکت‌های اعمال‌شده به اشیای چینش/مستر به اسلایدها ارث می‌برند، اما زمان‌بندی و تعامل آنها با انیمیشن‌های سطح اسلاید به توالی نهایی در اسلید وابسته است.