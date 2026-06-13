---
title: مدیریت گره‌های شکل SmartArt در ارائه‌ها با JavaScript
linktitle: گره شکل SmartArt
type: docs
weight: 30
url: /fa/nodejs-java/manage-smartart-shape-node/
keywords:
- گره SmartArt
- گره فرزند
- افزودن گره
- موقعیت گره
- دسترسی به گره
- حذف گره
- موقعیت سفارشی
- گره دستیار
- فرمت پر کردن
- رندر گره
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "گره‌های شکل SmartArt را در فایل‌های PPT و PPTX با Aspose.Slides برای Node.js مدیریت کنید. نمونه‌های کد واضح JavaScript و نکات برای بهینه‌سازی ارائه‌های خود دریافت کنید."
---
## **بررسی کلی**

گرافیک‌های SmartArt در ارائه‌های PowerPoint از طریق گره‌هایی که شامل متن هستند و ساختار نمودار را تعریف می‌کنند، سازماندهی می‌شوند. Aspose.Slides به شما امکان کار برنامه‌نویسی با این گره‌های SmartArt را می‌دهد: افزودن گره‌ها و گره‌های فرزند جدید، درج گره‌های فرزند در موقعیت خاص، دسترسی به گره‌های موجود و خواندن متن، سطح و موقعیت آن‌ها.

این مقاله نحوه مدیریت گره‌های شکل‌ SmartArt را توضیح می‌دهد. نشان می‌دهد چگونه گره‌ها را حذف کنید، با گره‌های فرزند بر اساس شاخص یا موقعیت کار کنید، یک گره دستیار را به گره عادی تبدیل کنید، موقعیت، اندازه و چرخش شکل‌های گره SmartArt را تنظیم کنید، فرمت پر کردن گره را تنظیم کنید و تصویر بندانگشتی برای گره فرزند SmartArt تولید کنید.

## **افزودن گره SmartArt در ارائه PowerPoint با استفاده از JavaScript**
Aspose.Slides برای Node.js از طریق Java ساده‌ترین API را برای مدیریت اشکال SmartArt به ساده‌ترین شکل ارائه داده است. کد نمونه زیر به شما کمک می‌کند گره و گره فرزند را در داخل شکل SmartArt اضافه کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
2. مرجع اسلاید اول را با استفاده از شاخص آن به دست آورید.
3. در تمام اشکال داخل اسلاید اول حرکت کنید.
4. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SmartArt) است و در صورت بودن، شکل انتخاب‌شده را به [SmartArt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SmartArt) تبدیل کنید.
5. یک [Node جدید]((https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--)) را در مجموعه **NodeCollection** شکل SmartArt اضافه کنید و متن را در TextFrame تنظیم کنید.
6. حالا یک [گره فرزند]((https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--)) در گره SmartArt تازه اضافه‌شده اضافه کنید و متن را در TextFrame تنظیم کنید.
7. ارائه را ذخیره کنید.

```javascript
// بارگذاری ارائه مورد نظر
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // پیمایش تمام اشکال داخل اسلاید اول
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // بررسی اینکه آیا شکل از نوع SmartArt است
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // تبدیل نوع شکل به SmartArt
            var smart = shape;
            // افزودن یک گره جدید SmartArt
            var TemNode = smart.getAllNodes().addNode();
            // افزودن متن
            TemNode.getTextFrame().setText("Test");
            // افزودن گره فرزند جدید در گره والد. این گره در انتهای مجموعه اضافه خواهد شد
            var newNode = TemNode.getChildNodes().addNode();
            // افزودن متن
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    // ذخیره ارائه
    pres.save("AddSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **افزودن گره SmartArt در موقعیت خاص**
در کد نمونه زیر توضیح داده شده است که چگونه گره‌های فرزند متعلق به گره‌های مربوطه در شکل SmartArt را در موقعیت خاصی اضافه کنید.

1. یک نمونه از کلاس Presentation ایجاد کنید.
2. مرجع اسلاید اول را با استفاده از شاخص آن به دست آورید.
3. یک شکل [SmartArt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SmartArt) از نوع **StackedList** در اسلاید دسترسی‑یافته اضافه کنید.
4. به اولین گره در شکل SmartArt اضافه‌شده دسترسی پیدا کنید.
5. حالا گره **فرزند** برای گره انتخاب‌شده را در موقعیت ۲ اضافه کنید و متن آن را تنظیم کنید.
6. ارائه را ذخیره کنید.

```javascript
// ایجاد یک نمونه ارائه
var pres = new aspose.slides.Presentation();
try {
    // دسترسی به اسلاید ارائه
    var slide = pres.getSlides().get_Item(0);
    // افزودن IShape Smart Art
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // دسترسی به گره SmartArt با شاخص 0
    var node = smart.getAllNodes().get_Item(0);
    // افزودن گره فرزند جدید در موقعیت 2 در گره والد
    var chNode = node.getChildNodes().addNodeByPosition(2);
    // افزودن متن
    chNode.getTextFrame().setText("Sample Text Added");
    // ذخیره ارائه
    pres.save("AddSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **دسترسی به گره SmartArt در ارائه PowerPoint با استفاده از JavaScript**
کد نمونه زیر به شما کمک می‌کند به گره‌های داخل شکل SmartArt دسترسی پیدا کنید. لطفاً توجه داشته باشید که نمی‌توانید LayoutType‌ را تغییر دهید زیرا فقط برای خواندن است و فقط هنگام افزودن شکل SmartArt تنظیم می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
2. مرجع اسلاید اول را با استفاده از شاخص آن به دست آورید.
3. در تمام اشکال داخل اسلاید اول حرکت کنید.
4. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SmartArt) است و در صورت بودن، شکل انتخاب‌شده را به [SmartArt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SmartArt) تبدیل کنید.
5. در تمام [Nodeها](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SmartArt#getAllNodes--) داخل شکل SmartArt حرکت کنید.
6. اطلاعاتی مانند موقعیت گره SmartArt، سطح و متن را دسترسی و نمایش دهید.

```javascript
// ایجاد نمونه کلاس Presentation
var pres = new aspose.slides.Presentation("SmartArtShape.pptx");
try {
    // دریافت اسلاید اول
    var slide = pres.getSlides().get_Item(0);
    // پیمایش همه اشکال داخل اسلاید اول
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // بررسی اینکه آیا شکل از نوع SmartArt است
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // تبدیل نوع شکل به SmartArt
            var smart = shape;
            // پیمایش تمام گره‌ها داخل SmartArt
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                // دسترسی به گره SmartArt با شاخص i
                var node = smart.getAllNodes().get_Item(j);
                // چاپ پارامترهای گره SmartArt
                console.log(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **دسترسی به گره فرزند SmartArt**
کد نمونه زیر به شما کمک می‌کند به گره‌های فرزند متعلق به گره‌های مربوطه در شکل SmartArt دسترسی پیدا کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
2. مرجع اسلاید اول را با استفاده از شاخص آن به دست آورید.
3. در تمام اشکال داخل اسلاید اول حرکت کنید.
4. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SmartArt) است و در صورت بودن، شکل انتخاب‌شده را به [SmartArt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SmartArt) تبدیل کنید.
5. در تمام [Nodeها](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SmartArt#getAllNodes--) داخل شکل SmartArt حرکت کنید.
6. برای هر گره SmartArt انتخاب‌شده، در تمام [گره‌های فرزند](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) داخل گره خاص حرکت کنید.
7. اطلاعاتی مانند موقعیت گره فرزند، سطح و متن را دسترسی و نمایش دهید.

```javascript
// ایجاد نمونه کلاس Presentation
var pres = new aspose.slides.Presentation("AccessChildNodes.pptx");
try {
    // دریافت اسلاید اول
    var slide = pres.getSlides().get_Item(0);
    // پیمایش همه اشکال داخل اسلاید اول
    for (let s = 0; s < slide.getShapes().size(); s++) {
        let shape = slide.getShapes().get_Item(s);
        // بررسی اینکه آیا شکل از نوع SmartArt است
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // تبدیل نوع شکل به SmartArt
            var smart = shape;
            // پیمایش تمام گره‌ها داخل SmartArt
            for (var i = 0; i < smart.getAllNodes().size(); i++) {
                // دسترسی به گره SmartArt با شاخص i
                var node0 = smart.getAllNodes().get_Item(i);
                // پیمایش گره‌های فرزند در گره SmartArt با شاخص i
                for (var j = 0; j < node0.getChildNodes().size(); j++) {
                    // دسترسی به گره فرزند در گره SmartArt
                    var node = node0.getChildNodes().get_Item(j);
                    // چاپ پارامترهای گره فرزند SmartArt
                    console.log("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **دسترسی به گره فرزند SmartArt در موقعیت خاص**
در این مثال، نحوه دسترسی به گره‌های فرزند در موقعیت‌های خاص متعلق به گره‌های مربوطه در شکل SmartArt را می‌آموزیم.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید.
2. مرجع اسلاید اول را با استفاده از شاخص آن به دست آورید.
3. یک شکل SmartArt از نوع **StackedList** اضافه کنید.
4. به شکل SmartArt اضافه‌شده دسترسی پیدا کنید.
5. گره‌ای با شاخص ۰ برای شکل SmartArt دسترسی‑یافته را باز کنید.
6. حالا گره **فرزند** را در موقعیت ۱ برای گره SmartArt دسترسی‑یافته با استفاده از متد **get_Item()** دریافت کنید.
7. اطلاعاتی مانند موقعیت گره فرزند، سطح و متن را دسترسی و نمایش دهید.

```javascript
// ایجاد نمونه ارائه
var pres = new aspose.slides.Presentation();
try {
    // دسترسی به اسلاید اول
    var slide = pres.getSlides().get_Item(0);
    // افزودن شکل SmartArt در اسلاید اول
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // دسترسی به گره SmartArt با شاخص 0
    var node = smart.getAllNodes().get_Item(0);
    // دسترسی به گره فرزند در موقعیت 1 در گره والد
    var position = 1;
    var chNode = node.getChildNodes().get_Item(position);
    // چاپ پارامترهای گره فرزند SmartArt
    console.log("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **حذف گره SmartArt در ارائه PowerPoint با استفاده از JavaScript**
در این مثال، نحوه حذف گره‌های داخل شکل SmartArt را می‌آموزیم.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
2. مرجع اسلاید اول را با استفاده از شاخص آن به دست آورید.
3. در تمام اشکال داخل اسلاید اول حرکت کنید.
4. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SmartArt) است و در صورت بودن، شکل انتخاب‌شده را به [SmartArt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SmartArt) تبدیل کنید.
5. بررسی کنید آیا SmartArt بیش از ۰ گره دارد.
6. گره SmartArt مورد نظر برای حذف را انتخاب کنید.
7. حالا گره انتخاب‌شده را با استفاده از متد [RemoveNode](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-aspose.slides.ISmartArtNode-) حذف کنید.
8. ارائه را ذخیره کنید.

```javascript
// بارگذاری ارائه مورد نظر
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // پیمایش تمام اشکال داخل اسلاید اول
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // بررسی اینکه آیا شکل از نوع SmartArt است
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // تبدیل نوع شکل به SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // دسترسی به گره SmartArt با شاخص 0
                var node = smart.getAllNodes().get_Item(0);
                // حذف گره انتخاب‌شده
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    // ذخیره ارائه
    pres.save("RemoveSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **حذف گره SmartArt در موقعیت خاص**
در این مثال، نحوه حذف گره‌های داخل شکل SmartArt در موقعیت خاصی را می‌آموزیم.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
2. مرجع اسلاید اول را با استفاده از شاخص آن به دست آورید.
3. در تمام اشکال داخل اسلاید اول حرکت کنید.
4. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SmartArt) است و در صورت بودن، شکل انتخاب‌شده را به [SmartArt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SmartArt) تبدیل کنید.
5. گره شکل SmartArt را در شاخص ۰ انتخاب کنید.
6. الآن بررسی کنید آیا گره SmartArt انتخاب‌شده بیش از ۲ گره فرزند دارد.
7. اکنون گره در **موقعیت ۱** را با استفاده از متد [RemoveNode](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-int-) حذف کنید.
8. ارائه را ذخیره کنید.

```javascript
// بارگذاری ارائه مورد نظر
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // پیمایش تمام اشکال داخل اسلاید اول
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // بررسی اینکه آیا شکل از نوع SmartArt است
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // تبدیل نوع شکل به SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // دسترسی به گره SmartArt با شاخص 0
                var node = smart.getAllNodes().get_Item(0);
                if (node.getChildNodes().size() >= 2) {
                    // حذف گره فرزند در موقعیت 1
                    node.getChildNodes().removeNode(1);
                }
            }
        }
    }
    // ذخیره ارائه
    pres.save("RemoveSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تنظیم موقعیت سفارشی برای گره فرزند در SmartArt**
اکنون Aspose.Slides برای Node.js از طریق Java از تنظیم ویژگی‌های X و Y برای [SmartArtShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SmartArtShape) پشتیبانی می‌کند. کد نمونه زیر نشان می‌دهد چگونه موقعیت، اندازه و چرخش سفارشی SmartArtShape را تنظیم کنید؛ همچنین توجه داشته باشید که افزودن گره‌های جدید باعث بازمحاسبه موقعیت‌ها و اندازه‌های تمام گره‌ها می‌شود. با تنظیم موقعیت سفارشی، کاربر می‌تواند گره‌ها را بر حسب نیاز تنظیم کند.

```javascript
// ایجاد نمونه کلاس Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, aspose.slides.SmartArtLayoutType.OrganizationChart);
    // انتقال شکل SmartArt به موقعیت جدید
    var node = smart.getAllNodes().get_Item(1);
    var shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + (shape.getWidth() * 2));
    shape.setY(shape.getY() - (shape.getHeight() * 2));
    // تغییر عرض‌های شکل SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + (shape.getWidth() * 2));
    // تغییر ارتفاع شکل SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + (shape.getHeight() * 2));
    // تغییر چرخش شکل SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);
    pres.save("SmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **بررسی گره دستیار**
{{% alert color="primary" %}} 

در این مقاله ویژگی‌های بیشتر اشکال SmartArt اضافه‌شده به اسلایدهای ارائه به‌صورت برنامه‌نویسی با Aspose.Slides برای Node.js از طریق Java را بررسی می‌کنیم.

{{% /alert %}} 

در بخش‌های مختلف این مقاله از شکل SmartArt زیر برای بررسی استفاده می‌کنیم.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**شکل: شکل SmartArt منبع در اسلاید**|

در کد نمونه زیر نحوه شناسایی **گره‌های دستیار** در مجموعه گره‌های SmartArt و تغییر وضعیت آن‌ها را بررسی می‌کنیم.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
2. مرجع اسلاید دوم را با استفاده از شاخص آن به دست آورید.
3. در تمام اشکال داخل اسلاید اول حرکت کنید.
4. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SmartArt) است و در صورت بودن، شکل انتخاب‌شده را به [SmartArt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SmartArt) تبدیل کنید.
5. در تمام گره‌های داخل شکل SmartArt حرکت کنید و بررسی کنید آیا آن‌ها **گره‌های دستیار** هستند.
6. وضعیت گره دستیار را به گره عادی تغییر دهید.
7. ارائه را ذخیره کنید.

```javascript
// ایجاد یک نمونه ارائه
var pres = new aspose.slides.Presentation("AddNodes.pptx");
try {
    // پیمایش تمام اشکال داخل اسلاید اول
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // بررسی اینکه آیا شکل از نوع SmartArt است
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // تبدیل نوع شکل به SmartArt
            var smart = shape;
            // پیمایش تمام گره‌های شکل SmartArt
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                var node = smart.getAllNodes().get_Item(j);
                // بررسی اینکه آیا گره یک گره دستیار است
                if (node.isAssistant()) {
                    // تنظیم گره دستیار به مقدار false و تبدیل آن به گره عادی
                    node.isAssistant();
                }
            }
        }
    }
    // ذخیره ارائه
    pres.save("ChangeAssitantNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**شکل: گره‌های دستیار در شکل SmartArt داخل اسلاید تغییر یافتند**|

## **تنظیم فرمت پر کردن گره**
Aspose.Slides برای Node.js از طریق Java امکان افزودن اشکال SmartArt سفارشی و تنظیم فرمت پر کردن آن‌ها را فراهم می‌کند. این مقاله توضیح می‌دهد چگونه اشکال SmartArt را ایجاد، دسترسی و فرمت پر کردن آن‌ها را با Aspose.Slides برای Node.js از طریق Java تنظیم کنید.

لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید.
2. با استفاده از شاخص، مرجع یک اسلاید را به دست آورید.
3. با تنظیم **LayoutType**، یک شکل [SmartArt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SmartArt) اضافه کنید.
4. برای گره‌های شکل SmartArt، [FillFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Shape#getFillFormat--) را تنظیم کنید.
5. ارائه اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

```javascript
// ایجاد نمونه ارائه
var pres = new aspose.slides.Presentation();
try {
    // دسترسی به اسلاید
    var slide = pres.getSlides().get_Item(0);
    // افزودن شکل SmartArt و گره‌ها
    var chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, aspose.slides.SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    // تنظیم رنگ پر کردن گره
    for (let i = 0; i < node.getShapes().size(); i++) {
        let item = node.getShapes().get_Item(i);
        item.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        item.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    }
    // ذخیرهٔ ارائه
    pres.save("TestSmart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تولید تصویر بندانگشتی از گره فرزند SmartArt**
توسعه‌دهندگان می‌توانند با دنبال کردن مراحل زیر، تصویر بندانگشتی گره فرزند یک SmartArt تولید کنند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید.
2. یک [SmartArt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) اضافه کنید.
3. مرجع یک گره را با استفاده از شاخص آن به دست آورید.
4. تصویر بندانگشتی را دریافت کنید.
5. تصویر بندانگشتی را در هر قالب تصویری دلخواهی ذخیره کنید.

```javascript
// ایجاد نمونه کلاس Presentation که نمایانگر فایل PPTX است
var pres = new aspose.slides.Presentation();
try {
    // افزودن SmartArt
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicCycle);
    // دریافت مرجع گره با استفاده از شاخص آن
    var node = smart.getNodes().get_Item(1);
    // دریافت تصویر بندانگشتی
    var slideImage = node.getShapes().get_Item(0).getImage();
    // ذخیره تصویر بندانگشتی
    try {
        slideImage.save("SmartArt_ChildNote_Thumbnail.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **پرسش‌های متداول**

**آیا انیمیشن SmartArt پشتیبانی می‌شود؟**

بله. SmartArt به‌عنوان یک شکل معمولی در نظر گرفته می‌شود، بنابراین می‌توانید [انیمیشن‌های استاندارد](/slides/fa/nodejs-java/shape-animation/) (ورودی، خروجی، تأکید، مسیرهای حرکتی) را اعمال و زمان‌بندی را تنظیم کنید. در صورت نیاز می‌توانید اشکال داخل گره‌های SmartArt را نیز انیمیت کنید.

**چگونه می‌توانم SmartArt خاصی را روی اسلاید به‌صورت قابل اعتماد پیدا کنم اگر شناسه داخلی آن ناشناخته باشد؟**

با اختصاص و جستجو بر اساس [متن جایگزین](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/getalternativetext/) می‌توانید SmartArt را بدون وابستگی به شناسه‌های داخلی پیدا کنید.

**آیا ظاهر SmartArt هنگام تبدیل ارائه به PDF حفظ می‌شود؟**

بله. Aspose.Slides هنگام [صدور PDF](/slides/fa/nodejs-java/convert-powerpoint-to-pdf/) SmartArt را با دقت بصری بالا رندر می‌کند و چیدمان، رنگ‌ها و افکت‌ها را حفظ می‌کند.

**آیا می‌توانم تصویر کامل SmartArt را برای پیش‌نمایش یا گزارش استخراج کنم؟**

بله. می‌توانید یک شکل SmartArt را به [فرمت‌های رستر](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/#getImage) یا به [SVG](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/writeassvg/) رندر کنید تا خروجی برداری مقیاس‌پذیر داشته باشید، که برای بندانگشتی، گزارش یا استفاده در وب مناسب است.