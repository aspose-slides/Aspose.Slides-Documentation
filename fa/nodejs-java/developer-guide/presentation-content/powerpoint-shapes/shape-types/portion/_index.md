---
title: مدیریت بخش‌های متنی در ارائه‌ها با استفاده از جاوااسکریپت
linktitle: بخش متن
type: docs
weight: 70
url: /fa/nodejs-java/portion/
keywords:
- بخش متنی
- قسمت متن
- مختصات متن
- موقعیت متن
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یاد بگیرید چگونه بخش‌های متنی را در ارائه‌های PowerPoint با استفاده از جاوااسکریپت و Aspose.Slides برای Node.js از طریق Java مدیریت کنید و عملکرد و سفارشی‌سازی را بهبود بخشید."
---
## **بررسی کلی**

یک بخش متن نمایانگر یک قطعه خاص از متن داخل یک پاراگراف است و به شما امکان می‌دهد که به طور مستقل با آن قطعه نسبت به محتوای اطراف کار کنید. در Aspose.Slides، بخش‌ها می‌توانند زمانی استفاده شوند که نیاز به بازیابی موقعیت یک قطعه متن داشته باشید، قالب‌بندی را فقط بر روی بخشی از پاراگراف اعمال کنید، یا رفتار متن را در سطح دقیق‌تری کنترل کنید.

این مقاله نشان می‌دهد چگونه با استفاده از متد `getCoordinates()` مختصات ابتدای یک بخش را به دست آورید. همچنین سناریوهای متداول مرتبط با بخش‌ها را برجسته می‌کند، مانند افزودن یک هایپرلینک به یک قطعه متن واحد، درک چگونگی حل قالب‌بندی از طریق بخش، پاراگراف، فریم متن و ارث‌بری تم، و مدیریت مواردی که یک فونت مشخص در دسترس نیست. علاوه بر این، ذکر می‌کند که پر کردن متن، رنگ و شفافیت می‌توانند برای هر بخش به طور جداگانه در یک پاراگراف تنظیم شوند.

## **دریافت مختصات موقعیت بخش**
متد [**getCoordinates()**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Portion#getCoordinates--) به کلاس [Portion](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/) اضافه شده است که امکان بازیابی مختصات ابتدای بخش را فراهم می‌کند.

```javascript
// نمونه‌سازی کلاس Prseetation که نمایانگر فایل PPTX است
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // بازآرایی زمینه ارائه
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const paragraph = textFrame.getParagraphs().get_Item(i);
        for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
            const portion = paragraph.getPortions().get_Item(j);
            var point = portion.getCoordinates();
            console.log("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سؤالات متداول**

**Can I apply a hyperlink to only part of the text within a single paragraph?**

بله، می‌توانید [یک هایپرلینک اختصاص دهید](/slides/fa/nodejs-java/manage-hyperlinks/) به یک بخش جداگانه؛ فقط آن قطعه قابل کلیک خواهد بود، نه کل پاراگراف.

**How does style inheritance work: what does a Portion override, and what is taken from Paragraph/TextFrame?**

خواص سطح Portion در اولویت بالاتری قرار دارند. اگر یک خاصیت در [Portion](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/) تنظیم نشده باشد، موتور آن را از [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) می‌گیرد؛ اگر آنجا نیز تنظیم نشده باشد، از [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) یا سبک [theme](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/theme/) دریافت می‌شود.

**What happens if the font specified for a Portion is missing on the target machine/server?**

[قواعد جایگزینی فونت](/slides/fa/nodejs-java/font-selection-sequence/) اعمال می‌شود. متن ممکن است بازآرایی شود: معیارها، تقسیم‌کلمات و عرض می‌توانند تغییر کنند که برای موقعیت‌یابی دقیق اهمیت دارد.

**Can I set a Portion-specific text fill transparency or gradient independent of the rest of the paragraph?**

بله، رنگ متن، پر کردن و شفافیت در سطح [Portion](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/) می‌تواند متفاوت از قطعات همسایه باشد.