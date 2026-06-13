---
title: SmartArt
type: docs
weight: 140
url: /fa/java/examples/elements/smart-art/
keywords:
- نمونه کد
- SmartArt
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "کار با SmartArt در Aspose.Slides برای Java: ایجاد، ویرایش، تبدیل و سبک‌دهی به نمودارها با Java برای ارائه‌های PowerPoint و OpenDocument."
---
این مقاله نشان می‌دهد چگونه گرافیک SmartArt را اضافه کنید، به آن دسترسی پیدا کنید، آن را حذف کنید و چیدمان‌ها را با استفاده از **Aspose.Slides for Java** تغییر دهید.

## **اضافه کردن SmartArt**

یک گرافیک SmartArt را با یکی از چیدمان‌های پیشساخته وارد کنید.

```java
static void addSmartArt() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
    } finally {
        presentation.dispose();
    }
}
```

## **دسترسی به SmartArt**

اولین شیء SmartArt موجود در یک اسلاید را بازیابی کنید.

```java
static void accessSmartArt() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

        ISmartArt firstSmartArt = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ISmartArt) {
                firstSmartArt = (ISmartArt) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **حذف SmartArt**

یک شکل SmartArt را از اسلاید حذف کنید.

```java
static void removeSmartArt() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

        slide.getShapes().remove(smartArt);
    } finally {
        presentation.dispose();
    }
}
```

## **تغییر چیدمان SmartArt**

نوع چیدمان یک گرافیک SmartArt موجود را به روزرسانی کنید.

```java
static void changeSmartArtLayout() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);
        smartArt.setLayout(SmartArtLayoutType.VerticalPictureList);
    } finally {
        presentation.dispose();
    }
}
```