---
title: کادر متن
type: docs
weight: 40
url: /fa/java/examples/elements/text-box/
keywords:
- مثال کد
- کادر متن
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "کار با کادرهای متن در Aspose.Slides برای Java: افزودن، قالب‌بندی، ترازبندی، بسته‌بندی، تنظیم خودکار اندازه و استایل‌دهی به متن با استفاده از Java برای ارائه‌های PPT، PPTX و ODP."
---
در Aspose.Slides، یک **کادر متن** توسط یک `AutoShape` نمایش داده می‌شود. تقریباً هر شکل می‌تواند متن داشته باشد، اما یک کادر متن معمولی هیچ پر کردن یا حاشیه‌ای ندارد و فقط متن را نمایش می‌دهد.

این راهنما نحوه افزودن، دسترسی و حذف کادرهای متن را به‌صورت برنامه‌نویسی توضیح می‌دهد.

## **افزودن یک کادر متن**

یک کادر متن صرفاً یک `AutoShape` بدون پر کردن یا حاشیه و با متنی قالب‌بندی‌شده است. در ادامه نحوه ایجاد آن آورده شده است:

```java
public static void addTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // یک شکل مستطیل ایجاد می‌کند (به‌طور پیش‌فرض پر شده با حاشیه و بدون متن).
        IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100);

        // حذف پر کردن و حاشیه برای شبیه‌سازی یک کادر متن معمولی.
        textBox.getFillFormat().setFillType(FillType.NoFill);
        textBox.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        // تنظیم قالب‌بندی متن.
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        IPortionFormat textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        textFormat.getFillFormat().setFillType(FillType.Solid);
        textFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        // اختصاص محتویات متن واقعی.
        textBox.getTextFrame().setText("Some text...");
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **نکته:** هر `AutoShape` که شامل یک `TextFrame` غیر خالی باشد می‌تواند به‌عنوان یک کادر متن عمل کند.

## **دسترسی به کادرهای متن بر اساس محتوا**

برای یافتن تمام کادرهای متنی که شامل کلیدواژه خاصی (مثلاً "Slide") هستند، به‌صورت تکرار بر روی شکل‌ها قدم بزنید و متن آنها را بررسی کنید:

```java
public static void accessTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        for (IShape shape : slide.getShapes()) {
            // فقط AutoShapeها می‌توانند متن قابل ویرایش داشته باشند.
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    // کاری با کادر متن مطابق انجام دهید.
                }
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **حذف کادرهای متن بر اساس محتوا**

این مثال تمام کادرهای متنی را که در اسلاید اول وجود دارند و شامل کلیدواژه خاصی هستند، پیدا کرده و حذف می‌کند:

```java
public static void removeTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        List<IShape> shapesToRemove = new ArrayList<IShape>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    shapesToRemove.add(shape);
                }
            }
        }

        for (IShape shape : shapesToRemove) {
            slide.getShapes().remove(shape);
        }
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **نکته:** همیشه قبل از تغییر مجموعهٔ شکل‌ها در حین تکرار، یک کپی از آن ایجاد کنید تا از بروز خطاهای تغییر مجموعه جلوگیری کنید.