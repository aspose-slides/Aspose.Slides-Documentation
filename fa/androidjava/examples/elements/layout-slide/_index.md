---
title: اسلاید طرح‌بندی
type: docs
weight: 20
url: /fa/androidjava/examples/elements/layout-slide/
keywords:
- مثال کد
- اسلاید طرح‌بندی
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "اسلایدهای طرح‌بندی اصلی در Aspose.Slides برای Android: انتخاب، اعمال و سفارشی‌سازی طرح‌بندی‌های اسلاید، جای‌گیرها و مسترها با مثال‌های Java برای ارائه‌های PPT، PPTX و ODP."
---
این مقاله نشان می‌دهد که چگونه می‌توانید با **Layout Slides** در Aspose.Slides برای Android از طریق Java کار کنید. یک اسلاید طرح‌بندی طراحی و قالب‌بندی‌ای را که توسط اسلایدهای معمولی ارث برده می‌شود، تعریف می‌کند. می‌توانید اسلایدهای طرح‌بندی را اضافه، دسترسی، کپی و حذف کنید و همچنین اسلایدهای استفاده‌نشده را پاک کنید تا حجم ارائه کاهش یابد.

## **افزودن اسلاید طرح‌بندی**

می‌توانید یک اسلاید طرح‌بندی سفارشی ایجاد کنید تا قالب‌بندی قابل استفاده مجدد را تعریف کنید. به عنوان مثال، ممکن است یک جعبه متن اضافه کنید که در تمام اسلایدهای استفاده‌کننده از این طرح ظاهر شود.

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // یک اسلاید طرح‌بندی با نوع طرح‌بندی خالی و نام سفارشی ایجاد کنید.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // یک جعبه متن به اسلاید طرح‌بندی اضافه کنید.
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // دو اسلاید با استفاده از این طرح اضافه کنید؛ هر دو متن را از طرح به ارث می‌برند.
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **توجه ۱:** اسلایدهای طرح‌بندی به‌عنوان قالب برای اسلایدهای جداگانه عمل می‌کنند. می‌توانید عناصر مشترک را یک‌بار تعریف کنید و در اسلایدهای متعدد باز استفاده کنید.

> 💡 **توجه ۲:** وقتی شکل‌ها یا متن را به یک اسلاید طرح‌بندی اضافه می‌کنید، تمام اسلایدهای مبتنی بر آن طرح به‌صورت خودکار این محتوا مشترک را نمایش می‌دهند.  
> تصویر زیر دو اسلاید را نشان می‌دهد که هر کدام یک جعبه متن را از همان اسلاید طرح‌بندی به ارث می‌برند.

![اسلایدهای وارث محتوای طرح](layout-slide-result.png)

## **دسترسی به اسلاید طرح‌بندی**

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // دسترسی به یک اسلاید طرح‌بندی بر اساس اندیس.
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // دسترسی به یک اسلاید طرح‌بندی بر اساس نوع.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    } finally {
        presentation.dispose();
    }
}
```

## **حذف اسلاید طرح‌بندی**

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // یک اسلاید طرح‌بندی را بر اساس نوع دریافت کنید و حذف کنید.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **حذف اسلایدهای طرح‌بندی استفاده‌نشده**

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // به‌طور خودکار تمام اسلایدهای طرح‌بندی که توسط هیچ اسلایدی ارجاع نشده‌اند را حذف می‌کند.
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **کلون اسلاید طرح‌بندی**

می‌توانید یک اسلاید طرح‌بندی را با استفاده از متد `addClone` تکثیر کنید.

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // یک اسلاید طرح‌بندی موجود را بر اساس نوع دریافت کنید.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // اسلاید طرح‌بندی را به انتهای مجموعه اسلایدهای طرح‌بندی کلون کنید.
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **خلاصه:** اسلایدهای طرح‌بندی ابزارهای قدرتمندی برای مدیریت قالب‌بندی یکسان در سراسر اسلایدها هستند. Aspose.Slides کنترل کامل بر ایجاد، مدیریت و بهینه‌سازی اسلایدهای طرح‌بندی را فراهم می‌کند.