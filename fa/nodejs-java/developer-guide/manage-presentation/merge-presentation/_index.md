---
title: ترکیب کارآمد ارائه‌ها در جاوااسکریپت
linktitle: ادغام ارائه‌ها
type: docs
weight: 40
url: /fa/nodejs-java/merge-presentation/
keywords:
- ادغام PowerPoint
- ادغام ارائه‌ها
- ادغام اسلایدها
- ادغام PPT
- ادغام PPTX
- ادغام ODP
- ترکیب PowerPoint
- ترکیب ارائه‌ها
- ترکیب اسلایدها
- ترکیب PPT
- ترکیب PPTX
- ترکیب ODP
- Node.js
- JavaScript
- Aspose.Slides
description: "به‌راحتی ارائه‌های PowerPoint (PPT، PPTX) و OpenDocument (ODP) را در جاوااسکریپت با Aspose.Slides برای Node.js ترکیب کنید و جریان کار خود را بهینه‌سازی کنید."
---
## **بررسی کلی**

Aspose.Slides به شما امکان ترکیب ارائه‌ها را با کپی کردن اسلایدها از یک ارائه به ارائه دیگر می‌دهد. این مقاله توضیح می‌دهد چگونه کل ارائه‌ها یا اسلایدهای انتخابی را ترکیب کنید، هنگام ترکیب از یک اسلاید مستر یا چیدمان خاصی استفاده کنید، ارائه‌هایی با اندازه اسلاید متفاوت را مدیریت کنید، و اسلایدهای ترکیب‌شده را به یک بخش ارائه اضافه کنید. همچنین نکات عملی مرتبط با محتوای ترکیب‌شده شامل یادداشت‌های سخنران، نظرات، فایل‌های منبع با رمز عبور، و استفاده از نخ‌ها را پوشش می‌دهد.

## **ادغام ارائه‌ها**

هنگامی که یک ارائه را به ارائه دیگر ترکیب می‌کنید، در واقع اسلایدهای آن‌ها را در یک ارائه واحد ادغام می‌کنید تا یک فایل به‌دست آورید.

{{% alert title="Info" color="info" %}}

اکثر برنامه‌های ارائه (PowerPoint یا OpenOffice) قابلیت ترکیب ارائه‌ها به این شکل را ندارند.

[**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/fa/nodejs-java/)، با این حال، امکان ترکیب ارائه‌ها را به روش‌های مختلف فراهم می‌کند. شما می‌توانید ارائه‌ها را همراه با تمام اشکال، سبک‌ها، متن‌ها، قالب‌بندی، نظرات، انیمیشن‌ها و غیره ترکیب کنید بدون این‌که نگران از دست رفتن کیفیت یا داده‌ها باشید.

**همچنین ببینید**

[کپی اسلایدها](https://docs.aspose.com/slides/fa/nodejs-java/clone-slides/).

{{% /alert %}}

### **موارد قابل ترکیب**

با Aspose.Slides می‌توانید ترکیب کنید:

* کل ارائه‌ها. تمام اسلایدهای ارائه‌ها در یک ارائه قرار می‌گیرند
* اسلایدهای خاص. اسلایدهای انتخاب‌شده در یک ارائه قرار می‌گیرند
* ارائه‌ها در یک فرمت (PPT به PPT، PPTX به PPTX و غیره) و در فرمت‌های مختلف (PPT به PPTX، PPTX به ODP و غیره) به یکدیگر.

### **گزینه‌های ترکیب**

می‌توانید گزینه‌هایی اعمال کنید که تعیین می‌کنند آیا:

* هر اسلاید در ارائه خروجی یک سبک منحصر به فرد حفظ کند
* یک سبک خاص برای تمام اسلایدهای ارائه خروجی استفاده شود.

برای ترکیب ارائه‌ها، Aspose.Slides روش‌های [addClone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) را از کلاس [SlideCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection) فراهم می‌کند. چندین پیاده‌سازی از متدهای `addClone` وجود دارد که پارامترهای فرآیند ترکیب ارائه را تعریف می‌کند. هر شیء Presentation دارای مجموعه‌ای به نام [Slides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#getSlides--) است، بنابراین می‌توانید متد `addClone` را از ارائه‌ای که می‌خواهید اسلایدها را به آن ترکیب کنید فراخوانی کنید.

متد `addClone` یک شیء `Slide` برمی‌گرداند که نسخه‌ای کلون شده از اسلاید منبع است. اسلایدهای یک ارائه خروجی به سادگی کپی اسلایدهای منبع هستند. بنابراین می‌توانید تغییرات لازم را بر روی اسلایدهای حاصل (مانند اعمال سبک‌ها، گزینه‌های قالب‌بندی یا چیدمان‌ها) بدون نگرانی از تأثیر بر ارائه‌های منبع اعمال کنید.

## **ترکیب ارائه‌ها**

Aspose.Slides متد [**AddClone(ISlide)**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) را فراهم می‌کند که به شما اجازه می‌دهد اسلایدها را ترکیب کنید در حالی که اسلایدها چیدمان و سبک‌های خود را حفظ می‌کنند (پارامترهای پیش‌فرض).

این کد JavaScript نشان می‌دهد چگونه ارائه‌ها را ترکیب کنید:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **ترکیب ارائه‌ها با اسلاید مستر**

Aspose.Slides متد [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) را فراهم می‌کند که به شما اجازه می‌دهد اسلایدها را ترکیب کنید در حالی که قالب ارائه اسلاید مستر را اعمال می‌کنید. به این ترتیب، در صورت نیاز می‌توانید سبک اسلایدهای ارائه خروجی را تغییر دهید.

این کد JavaScript عمل توضیح‌داده‌شده را نشان می‌دهد:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}} 

چیدمان اسلاید برای اسلاید مستر به‌صورت خودکار تعیین می‌شود. هنگامی که چیدمان مناسب نتواند تعیین شود، اگر پارامتر بولی `allowCloneMissingLayout` متد `addClone` روی true تنظیم شده باشد، چیدمان اسلاید منبع استفاده می‌شود. در غیر اینصورت، استثنای [PptxEditException](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PptxEditException) پرتاب خواهد شد.

{{% /alert %}}

اگر می‌خواهید اسلایدهای ارائه خروجی دارای چیدمان اسلاید متفاوتی باشند، به‌جای آن هنگام ترکیب از متد [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) استفاده کنید.

## **ترکیب اسلایدهای خاص از ارائه‌ها**

ترکیب اسلایدهای خاص از چندین ارائه برای ایجاد مجموعه‌های سفارشی اسلاید مفید است. Aspose.Slides for Node.js via Java به شما امکان می‌دهد فقط اسلایدهای مورد نیاز را انتخاب و وارد کنید. API قالب‌بندی، چیدمان و طراحی اسلایدهای اصلی را حفظ می‌کند.

کد JavaScript زیر یک ارائه جدید می‌سازد، اسلایدهای عنوان را از دو ارائه دیگر اضافه می‌کند و نتیجه را در فایلی ذخیره می‌نماید:

```js
function getTitleSlide(presentation) {
  for (let i = 0; i < presentation.getSlides().size(); i++) {
    let slide = presentation.getSlides().get_Item(i);
    if (slide.getLayoutSlide().getLayoutType() == aspose.slides.SlideLayoutType.Title) {
      return slide;
    }
  }
  return null;
}
```
```js
let presentation = new aspose.slides.Presentation();
let presentation1 = new aspose.slides.Presentation("presentation1.pptx");
let presentation2 = new aspose.slides.Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    let slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    let slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```

## **ترکیب ارائه‌ها با چیدمان اسلاید**

این کد JavaScript نشان می‌دهد چگونه اسلایدها را از ارائه‌ها ترکیب کنید در حالی که چیدمان اسلاید دلخواه خود را به آن‌ها اعمال می‌کنید تا یک ارائه خروجی به‌دست آورید:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **ترکیب ارائه‌ها با اندازه اسلایدهای متفاوت**

{{% alert title="Note" color="warning" %}} 

نمی‌توانید ارائه‌هایی با اندازه اسلاید متفاوت را ترکیب کنید.

{{% /alert %}}

برای ترکیب 2 ارائه با اندازه اسلاید متفاوت، باید یکی از ارائه‌ها را تغییر اندازه دهید تا سایز آن با ارائه دیگر مطابقت داشته باشد.

این کد نمونه عمل توضیح‌داده‌شده را نمایش می‌دهد:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize(pres1.getSlideSize().getSize().getWidth(), pres1.getSlideSize().getSize().getHeight(), aspose.slides.SlideSizeScaleType.EnsureFit);
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **ترکیب اسلایدها به بخش ارائه**

این کد JavaScript نشان می‌دهد چگونه یک اسلاید خاص را به یک بخش در ارائه ترکیب کنید:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

اسلاید در انتهای بخش اضافه می‌شود.

## **پرسش‌های متداول**

**آیا یادداشت‌های سخنران در هنگام ترکیب حفظ می‌شوند؟**

بله. هنگام کلون کردن اسلایدها، Aspose.Slides تمام عناصر اسلاید شامل یادداشت‌ها، قالب‌بندی و انیمیشن‌ها را منتقل می‌کند.

**آیا نظرات و نویسندگان آن‌ها منتقل می‌شوند؟**

نظرات به‌عنوان بخشی از محتوای اسلاید کپی می‌شوند. برچسب‌های نویسنده نظرات به‌عنوان اشیاء نظر در ارائه حاصل حفظ می‌شوند.

**اگر ارائه منبع دارای رمز عبور باشد چه می‌شود؟**

باید [با رمز عبور باز شود](/slides/fa/nodejs-java/password-protected-presentation/) از طریق [LoadOptions.setPassword](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/setpassword/); پس از بارگذاری، این اسلایدها می‌توانند به‌صورت امن به فایلی بدون رمز یا حتی به فایلی محافظت‌شده دیگر کلون شوند.

**عملیات ترکیب تا چه حد ایمن نسبت به نخ‌ها است؟**

از استفاده همزمان از همان شیء [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) در [چندین نخ](/slides/fa/nodejs-java/multithreading/) خودداری کنید. قاعده پیشنهادی این است: «یک سند — یک نخ»؛ فایل‌های متفاوت می‌توانند به‌صورت موازی در نخ‌های جداگانه پردازش شوند.

## **موارد مرتبط**

Aspose یک [ابزار آنلاین رایگان ساخت کلاژ](https://products.aspose.app/slides/fa/collage) فراهم می‌کند. با استفاده از این سرویس آنلاین می‌توانید تصاویر [JPG به JPG](https://products.aspose.app/slides/fa/collage/jpg) یا PNG به PNG را ترکیب کنید، [شبکه‌های عکس](https://products.aspose.app/slides/fa/collage/photo-grid) بسازید و موارد دیگر.

به [ادغام‌کننده رایگان آنلاین Aspose](https://products.aspose.app/slides/fa/merger) سر بزنید. این ابزار به شما امکان می‌دهد ارائه‌های PowerPoint را در همان فرمت (مثلاً PPT به PPT، PPTX به PPTX) یا بین فرمت‌های مختلف (مثلاً PPT به PPTX، PPTX به ODP) ترکیب کنید.

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/fa/merger)