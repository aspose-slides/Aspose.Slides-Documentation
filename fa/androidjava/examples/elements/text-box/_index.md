---
title: جعبه متن
type: docs
weight: 40
url: /fa/androidjava/examples/elements/text-box/
keywords:
- مثال کد
- جعبه متن
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "کار با جعبه‌های متن در Aspose.Slides برای Android: افزودن، قالب‌بندی، تراز، بسته‌بندی، خودتنظیم، و استایل متن با استفاده از Java برای ارائه‌های PPT، PPTX و ODP."
---
در Aspose.Slides، یک **جعبه متن** توسط یک `AutoShape` نمایش داده می‌شود. تقریباً هر شکلی می‌تواند متن داشته باشد، اما یک جعبه متن معمولی پر یا حاشیه‌ای ندارند و تنها متن را نمایش می‌دهند.

این راهنما توضیح می‌دهد که چگونه می‌توان جعبه‌های متن را به‌صورت برنامه‌نویسی اضافه، دسترسی پیدا کرد و حذف کرد.

## **افزودن جعبه متن**

یک جعبه متن صرفاً یک `AutoShape` بدون پر یا حاشیه و با برخی متن‌های قالب‌بندی‌شده است. در اینجا نحوه ایجاد یک جعبه متن آورده شده است:

```java
public static void addTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // یک شکل مستطیل ایجاد می‌کند (به‌صورت پیش‌فرض پر شده با حاشیه و بدون متن).
        IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100);

        // پر و حاشیه را حذف کنید تا شبیه یک جعبه متن معمولی باشد.
        textBox.getFillFormat().setFillType(FillType.NoFill);
        textBox.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        // تنظیم قالب‌بندی متن.
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        IPortionFormat textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        textFormat.getFillFormat().setFillType(FillType.Solid);
        textFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        // متن واقعی را اختصاص می‌دهد.
        textBox.getTextFrame().setText("Some text...");
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **نکته:** هر `AutoShape` که حاوی `TextFrame` غیرخالی باشد می‌تواند به‌عنوان جعبه متن عمل کند.

## **دسترسی به جعبه‌های متن بر اساس محتوا**

برای یافتن تمام جعبه‌های متنی که شامل یک کلمه کلیدی خاص هستند (مثلاً "Slide")، بر روی اشکال تکرار کنید و متن آن‌ها را بررسی کنید:

```java
public static void accessTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        for (IShape shape : slide.getShapes()) {
            // فقط AutoShape ها می‌توانند متن قابل ویرایش داشته باشند.
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    // کاری با جعبه متن مطابق انجام دهید.
                }
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **حذف جعبه‌های متن بر اساس محتوا**

این مثال تمام جعبه‌های متن موجود در اولین اسلاید که شامل یک کلمه کلیدی خاص هستند را پیدا کرده و حذف می‌کند:

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

> 💡 **نکته:** همیشه قبل از تغییر مجموعه شکل‌ها در حین تکرار، یک نسخه کپی از آن بسازید تا از خطاهای تغییر مجموعه جلوگیری کنید.