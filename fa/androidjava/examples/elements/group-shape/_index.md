---
title: شکل گروهی
type: docs
weight: 170
url: /fa/androidjava/examples/elements/group-shape/
keywords:
- نمونه کد
- شکل گروهی
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "مدیریت اشکال گروهی در Aspose.Slides برای Android: ایجاد، تو در تو کردن، تراز کردن، مرتب‌سازی و استایل دادن به اشکال گروهی با مثال‌های Java در ارائه‌های PPT، PPTX و ODP."
---
نمونه‌هایی برای ایجاد گروه‌های اشکال، دسترسی به آن‌ها، جداسازی و حذف با استفاده از **Aspose.Slides for Android via Java**.

## **افزودن یک شکل گروهی**

یک گروه شامل دو شکل پایه ایجاد کنید.

```java
static void addGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
        group.getShapes().addAutoShape(ShapeType.Ellipse, 60, 0, 50, 50);
    } finally {
        presentation.dispose();
    }
}
```

## **دسترسی به یک شکل گروهی**

اولین شکل گروهی را از اسلاید بازیابی کنید.

```java
static void accessGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        IGroupShape firstGroup = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IGroupShape) {
                firstGroup = (IGroupShape) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **حذف یک شکل گروهی**

یک شکل گروهی را از اسلاید حذف کنید.

```java
static void removeGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();

        slide.getShapes().remove(group);
    } finally {
        presentation.dispose();
    }
}
```

## **لغو گروه‌بندی اشکال**

اشکال را از داخل یک ظرف گروه خارج کنید.

```java
static void ungroupShapes() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        IAutoShape rect = group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        // جابجایی شکل خارج از گروه.
        slide.getShapes().addClone(rect);
        group.getShapes().remove(rect);
    } finally {
        presentation.dispose();
    }
}
```