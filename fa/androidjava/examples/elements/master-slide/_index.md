---
title: "اسلاید مستر"
type: docs
weight: 30
url: /fa/androidjava/examples/elements/master-slide/
keywords:
- "مثال کد"
- "اسلاید مستر"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "Android"
- "Java"
- "Aspose.Slides"
description: "نمونه‌های اسلاید مستر Aspose.Slides برای Android را بررسی کنید: ایجاد، ویرایش و استایل‌دهی به مسترها، مکان‌گیرها و تم‌ها در قالب‌های PPT، PPTX و ODP با کد واضح Java."
---
اسلایدهای مستر سطح بالای سلسله‌مراتبی وراثت اسلایدها در PowerPoint را تشکیل می‌دهند. یک **master slide** عناصر طراحی عمومی مانند پس‌زمینه‌ها، لوگوها و قالب‌بندی متن را تعریف می‌کند. **Layout slides** از اسلایدهای مستر ارث می‌برند و **normal slides** از اسلایدهای طرح ارث می‌برند.

این مقاله نشان می‌دهد چگونه اسلایدهای مستر را با استفاده از Aspose.Slides برای Android از طریق Java ایجاد، ویرایش و مدیریت کنیم.

## **افزودن اسلاید مستر**

این مثال نشان می‌دهد چگونه با کلون‌کردن اسلاید پیش‌فرض، یک اسلاید مستر جدید ایجاد کنیم. سپس بنر نام شرکت را از طریق ارث‌برداری طرح به تمام اسلایدها اضافه می‌کند.

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // کلون اسلاید مستر پیش‌فرض.
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // افزودن بنر با نام شرکت به بالای اسلاید مستر.
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // اختصاص اسلاید مستر جدید به یک اسلاید طرح.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // اختصاص اسلاید طرح به اولین اسلاید در ارائه.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note 1:** اسلایدهای مستر روشی برای اعمال برندینگ ثابت یا عناصر طراحی مشترک در تمام اسلایدها فراهم می‌کنند. هر تغییری که در مستر اعمال شود، به‌طور خودکار بر روی اسلایدهای طرح و اسلایدهای معمولی وابسته بازتاب می‌یابد.

> 💡 **Note 2:** هر شکل یا قالب‌بندی که به یک اسلاید مستر اضافه شود، توسط اسلایدهای طرح به ارث می‌رسد و به‌نوبه خود به تمام اسلایدهای معمولی که از آن طرح‌ها استفاده می‌کنند نیز منتقل می‌شود.
> تصویر زیر نشان می‌دهد چگونه یک جعبه متن اضافه‌شده به اسلاید مستر به‌طور خودکار بر روی اسلاید نهایی رندر می‌شود.

![مثال وراثت مستر](master-slide-banner.png)

## **دسترسی به اسلاید مستر**

شما می‌توانید با استفاده از مجموعه مستر ارائه به اسلایدهای مستر دسترسی پیدا کنید. در اینجا نحوه بازیابی و کار با آنها آورده شده است:

```java
static void accessMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);

        // تغییر نوع پس‌زمینه.
        firstMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    } finally {
        presentation.dispose();
    }
}
```

## **حذف اسلاید مستر**

اسلایدهای مستر می‌توانند با استفاده از شاخص یا مرجع حذف شوند.

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // حذف یک اسلاید مستر بر اساس شاخص.
        presentation.getMasters().removeAt(0);

        // حذف یک اسلاید مستر بر اساس مرجع.
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **حذف اسلایدهای مستر غیرمستعمل**

برخی ارائه‌ها شامل اسلایدهای مستری هستند که استفاده نمی‌شوند. حذف این اسلایدها می‌تواند به کاهش حجم فایل کمک کند.

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // حذف تمام اسلایدهای مستر استفاده‌نشده (حتی آنهایی که به عنوان Preserve علامت‌گذاری شده‌اند).
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```