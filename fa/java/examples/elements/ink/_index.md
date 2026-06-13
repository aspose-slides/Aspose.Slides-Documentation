---
title: جوهر
type: docs
weight: 180
url: /fa/java/examples/elements/ink/
keywords:
- مثال کد
- جوهر
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "کار با جوهر در Aspose.Slides برای Java: رسم، وارد کردن، و ویرایش خطوط، تنظیم رنگ و عرض، و صادرات به PPT، PPTX و ODP با استفاده از مثال‌های Java."
---
این مقاله نمونه‌هایی از دسترسی به شکل‌های جوهری موجود و حذف آن‌ها با استفاده از **Aspose.Slides for Java** ارائه می‌دهد.

> ❗ **توجه:** اشکال جوهر نمایانگر ورودی کاربر از دستگاه‌های تخصصی هستند. Aspose.Slides نمی‌تواند خطوط جوهری جدید را به‌صورت برنامه‌نویسی ایجاد کند، اما می‌توانید جوهر موجود را بخوانید و تغییر دهید.

## **دسترسی به جوهر**
برچسب‌ها را از اولین شکل جوهری روی یک اسلاید بخوانید.

```java
static void accessInk() {
    Presentation presentation = new Presentation("ink.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IShape shape = slide.getShapes().get_Item(0);
        if (shape instanceof IInk) {
            IInk inkShape = (IInk) shape;
            ITagCollection tags = inkShape.getCustomData().getTags();
            if (tags.size() > 0) {
                String tagName = tags.getNameByIndex(0);
                // از tagName به صورت مورد نیاز استفاده کنید.
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **حذف جوهر**
اگر یک شکل جوهری موجود باشد، آن را از اسلاید حذف کنید.

```java
static void removeInk() {
    Presentation presentation = new Presentation("ink.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IInk ink = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IInk) {
                ink = (IInk) shape;
                break;
            }
        }
        if (ink != null) {
            slide.getShapes().remove(ink);
        }
    } finally {
        presentation.dispose();
    }
}
```