---
title: دریافت مرزهای بخش متن از ارائه‌ها در JavaScript
linktitle: مرزهای بخش
type: docs
weight: 47
url: /fa/nodejs-java/portion-bounds/
keywords:
- مرزهای بخش متن
- بخش متن
- قسمت متن
- مختصات متن
- موقعیت متن
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یاد بگیرید چگونه مرزهای بخش متن را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای Node.js از طریق Java بازیابی کنید."
---
## **بررسی کلی**

یک بخش متن نمایانگر یک تکه خاص از متن داخل یک پاراگراف است و به شما امکان می‌دهد تا به‌صورت مستقل از محتوای اطراف با آن تکه کار کنید. در Aspose.Slides، می‌توانید از بخش‌ها زمانی استفاده کنید که نیاز به دریافت مرزهای یک تکه متن داشته باشید، فقط به‌جزئی از یک پاراگراف قالب‌بندی اعمال کنید، یا رفتار متن را در سطح جزئی‌تری کنترل کنید.

این مقاله نشان می‌دهد چگونه با استفاده از [Portion.getRect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/getrect/) مستطیل محدودکننده یک بخش متن را دریافت کنید. همچنین نحوه دریافت مختصات شروع یک بخش متن را با استفاده از [Portion.getCoordinates](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/getcoordinates/) نشان می‌دهد. علاوه بر این، سناریوهای رایج مرتبط با بخش‌ها را برجسته می‌کند، مانند اعمال یک پیوند به یک تکه متن منفرد، درک نحوه حل‌فضای قالب‌بندی از طریق وراثت بخش، پاراگراف، قاب متن و تم، و مدیریت مواردی که یک فونت مشخص در دسترس نیست.

## **دریافت مرزهای یک بخش متن**

از [Portion.getRect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/getrect/) برای بازیابی مستطیل محدودکننده یک بخش متن استفاده کنید:

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const rectangle = portion.getRect();
            console.log("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **دریافت مختصات یک بخش متن**

از [Portion.getCoordinates](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/getcoordinates/) برای بازیابی مختصات شروع یک بخش متن استفاده کنید:

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const point = portion.getCoordinates();
            console.log("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **پرسش‌های متداول**

**آیا می‌توانم یک پیوند را فقط بر روی بخشی از متن در یک پاراگراف واحد اعمال کنم؟**

بله، می‌توانید با استفاده از [assign a hyperlink](/slides/fa/nodejs-java/manage-hyperlinks/) یک پیوند را به یک بخش جداگانه اختصاص دهید؛ فقط همان تکه قابل کلیک خواهد بود و نه تمام پاراگراف.

**چگونه وراثت سبک کار می‌کند: یک بخش چه چیزی را بازنویسی می‌کند و چه چیزی از پاراگراف یا قاب متن گرفته می‌شود؟**

ویژگی‌های سطح بخش بالاترین اولویت را دارند. اگر ویژگی‌ای در [Portion](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/) تنظیم نشده باشد، Aspose.Slides آن را از [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) می‌گیرد. اگر در آنجا نیز تنظیم نشده باشد، Aspose.Slides از سبک [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) یا [theme](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/theme/) استفاده می‌کند.

**اگر فونتی که برای یک بخش مشخص شده باشد در ماشین یا سرور هدف موجود نباشد چه اتفاقی می‌افتد؟**

[Font substitution rules](/slides/fa/nodejs-java/font-selection-sequence/) اعمال می‌شود. متن ممکن است بازچیدمان شود: معیارها، تقسیم کلمه و عرض می‌توانند تغییر کنند که برای موقعیت‌یابی دقیق مهم است.

**آیا می‌توانم شفافیت پر متن یا گرادیان مخصوص یک بخش را به‌طور مستقل از بقیه پاراگراف تنظیم کنم؟**

بله، رنگ متن، پر و شفافیت در سطح [Portion](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/) می‌تواند متفاوت از تکه‌های همسایه باشد.