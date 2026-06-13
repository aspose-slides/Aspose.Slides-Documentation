---
title: اسلاید مستر
type: docs
weight: 30
url: /fa/java/examples/elements/master-slide/
keywords:
- مثال کد
- اسلاید مستر
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "مثال‌های اسلاید مستر Aspose.Slides برای Java را بررسی کنید: ایجاد، ویرایش و سبک‌دهی به مسترها، مکان‌گیرها و تم‌ها در فرمت‌های PPT، PPTX و ODP با کد واضح Java."
---
اسلایدهای مستر سطح بالای سلسله‌مراتب ارث‌برداری اسلاید در PowerPoint را تشکیل می‌دهند. یک **اسلاید مستر** عناصر طراحی مشترکی مانند پس‌زمینه‌ها، لوگوها و قالب‌بندی متن را تعریف می‌کند. **اسلایدهای طرح‌بندی** از اسلایدهای مستر ارث می‌برند و **اسلایدهای عادی** از اسلایدهای طرح‌بندی ارث می‌برند.

این مقاله نشان می‌دهد چگونه اسلایدهای مستر را با استفاده از Aspose.Slides برای Java ایجاد، اصلاح و مدیریت کنیم.

## **افزودن اسلاید مستر**

این مثال نشان می‌دهد چگونه یک اسلاید مستر جدید را با کلون کردن اسلاید پیش‌فرض ایجاد کنیم. سپس بنر نام شرکت را از طریق ارث‌برداری طرح‌بندی به تمام اسلایدها اضافه می‌کند.

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // کلون‌کردن اسلاید مستر پیش‌فرض.
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // افزودن بنر نام شرکت به بالای اسلاید مستر.
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // تخصیص اسلاید مستر جدید به یک اسلاید طرح‌بندی.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // تخصیص اسلاید طرح‌بندی به اولین اسلاید در ارائه.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **یادداشت 1:** اسلایدهای مستر راهی برای اعمال برندینگ ثابت یا عناصر طراحی مشترک در تمام اسلایدها فراهم می‌کنند. هر تغییری که در مستر اعمال شود به‌صورت خودکار بر روی اسلایدهای طرح‌بندی و عادی وابسته منعکس می‌شود.

> 💡 **یادداشت 2:** هر شکل یا قالب‌بندی که به یک اسلاید مستر اضافه شود، توسط اسلایدهای طرح‌بندی ارث‌برداری می‌شود و به نوبه خود توسط تمام اسلایدهای عادی که از آن طرح‌ها استفاده می‌کنند. تصویر زیر نشان می‌دهد چگونه یک جعبه متن که در یک اسلاید مستر اضافه شده است، به‌صورت خودکار بر روی اسلاید نهایی رندر می‌شود.

![مثال ارث‌برداری مستر](master-slide-banner.png)

## **دسترسی به اسلاید مستر**

می‌توانید اسلایدهای مستر را با استفاده از مجموعه مستر ارائه دسترسی پیدا کنید. در اینجا نحوه بازیابی و کار با آن‌ها آورده شده است:

```java
static void accessMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);

        // نوع پس‌زمینه را تغییر دهید.
        firstMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    } finally {
        presentation.dispose();
    }
}
```

## **حذف اسلاید مستر**

اسلایدهای مستر می‌توانند به‌صورت ایندکس یا با ارجاع حذف شوند.

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // حذف یک اسلاید مستر بر اساس ایندکس.
        presentation.getMasters().removeAt(0);

        // حذف یک اسلاید مستر با استفاده از ارجاع.
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **حذف اسلایدهای مستر استفاده نشده**

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