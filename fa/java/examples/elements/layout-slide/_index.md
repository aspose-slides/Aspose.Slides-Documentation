---
title: اسلاید طرح
type: docs
weight: 20
url: /fa/java/examples/elements/layout-slide/
keywords:
  - مثال کد
  - اسلاید طرح
  - PowerPoint
  - OpenDocument
  - ارائه
  - Java
  - Aspose.Slides
description: "اسلایدهای طرح اصلی در Aspose.Slides برای Java: انتخاب، اعمال و سفارشی‌سازی طرح‌های اسلاید، مکان‌دارها و الگوهای اصلی با مثال‌های Java برای ارائه‌های PPT، PPTX و ODP."
---
این مقاله نشان می‌دهد چگونه با **Layout Slides** در Aspose.Slides for Java کار کنید. یک اسلاید طرح، طراحی و قالب‌بندی را که توسط اسلایدهای معمولی به ارث برده می‌شود، تعریف می‌کند. می‌توانید اسلایدهای طرح را اضافه، دسترسی، تکثیر و حذف کنید و همچنین اسلایدهای استفاده نشده را پاک‌سازی کنید تا اندازه ارائه کاهش یابد.

## **افزودن اسلاید طرح**

می‌توانید یک اسلاید طرح سفارشی ایجاد کنید تا قالب‌بندی قابل استفاده مجدد را تعریف کند. به عنوان مثال، ممکن است یک جعبه متن اضافه کنید که در تمام اسلایدهای استفاده‌کننده از این طرح ظاهر شود.

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // یک اسلاید طرح با نوع طرح خالی و نام سفارشی ایجاد کنید.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // یک جعبه متن به اسلاید طرح اضافه کنید.
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // دو اسلاید با استفاده از این طرح اضافه کنید؛ هر دو متن را از طرح به ارث خواهند برد.
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **نکته 1:** اسلایدهای طرح به عنوان قالب برای اسلایدهای تک‌تک عمل می‌کنند. می‌توانید عناصر مشترک را یکبار تعریف کنید و در اسلایدهای متعدد باز استفاده کنید.

> 💡 **نکته 2:** هنگامی که اشکال یا متن را به یک اسلاید طرح اضافه می‌کنید، تمام اسلایدهای مبتنی بر آن طرح به‌صورت خودکار این محتویات مشترک را نمایش می‌دهند.  
> تصویر زیر دو اسلاید را نشان می‌دهد که هر کدام یک جعبه متن را از همان اسلاید طرح به ارث می‌برند.

![اسلایدها محتویات طرح را به ارث می‌برند](layout-slide-result.png)

## **دسترسی به اسلاید طرح**

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // دسترسی به یک اسلاید طرح بر اساس شاخص.
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // دسترسی به یک اسلاید طرح بر اساس نوع.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    } finally {
        presentation.dispose();
    }
}
```

## **حذف اسلاید طرح**

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // دریافت یک اسلاید طرح بر اساس نوع و حذف آن.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **حذف اسلایدهای طرح استفاده نشده**

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // به صورت خودکار تمام اسلایدهای طرح که توسط هیچ اسلایدی ارجاع نشده‌اند را حذف می‌کند.
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **تکثیر اسلاید طرح**

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // دریافت یک اسلاید طرح موجود بر اساس نوع.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // کلون کردن اسلاید طرح به انتهای مجموعه اسلایدهای طرح.
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **خلاصه:** اسلایدهای طرح ابزارهای قدرتمندی برای مدیریت قالب‌بندی یکسان در سراسر اسلایدها هستند. Aspose.Slides کنترل کامل بر ایجاد، مدیریت و بهینه‌سازی اسلایدهای طرح را فراهم می‌کند.