---
title: مربع نص
type: docs
weight: 40
url: /ar/java/examples/elements/text-box/
keywords:
- مثال على الكود
- مربع نص
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "العمل مع مربعات النص في Aspose.Slides for Java: إضافة، تنسيق، محاذاة، التفاف، ضبط تلقائي، وتنسيق النص باستخدام Java لعروض PPT، PPTX، و ODP."
---
في Aspose.Slides، يتم تمثيل **مربع النص** بواسطة `AutoShape`. يمكن لأي شكل تقريبًا أن يحتوي على نص، لكن مربع النص النموذجي لا يحتوي على تعبئة أو حد ويعرض النص فقط.

يشرح هذا الدليل كيفية إضافة مربعات النص والوصول إليها وإزالتها برمجيًا.

## **إضافة مربع نص**

مربع النص هو ببساطة `AutoShape` لا يحتوي على تعبئة أو حد وبه بعض النص المنسق. إليك كيفية إنشاء واحد:

```java
public static void addTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // إنشاء شكل مستطيل (الإعداد الافتراضي يكون مملوءًا بحد ولا يحتوي على نص).
        IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100);

        // إزالة التعبئة والحد لجعله يبدو كصندوق نص نموذجي.
        textBox.getFillFormat().setFillType(FillType.NoFill);
        textBox.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        // تعيين تنسيق النص.
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        IPortionFormat textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        textFormat.getFillFormat().setFillType(FillType.Solid);
        textFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        // إرفاق محتوى النص الفعلي.
        textBox.getTextFrame().setText("Some text...");
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **ملاحظة:** أي `AutoShape` يحتوي على `TextFrame` غير فارغ يمكن أن يعمل كمربع نص.

## **الوصول إلى مربعات النص حسب المحتوى**

للعثور على جميع مربعات النص التي تحتوي على كلمة مفتاح محددة (مثال: "Slide")، قم بالتكرار عبر الأشكال وتحقق من نصها:

```java
public static void accessTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        for (IShape shape : slide.getShapes()) {
            // فقط AutoShapes يمكن أن تحتوي على نص قابل للتحرير.
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    // قم بعمل ما مع مربع النص المتطابق.
                }
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **إزالة مربعات النص حسب المحتوى**

يجد هذا المثال ويحذف جميع مربعات النص في الشريحة الأولى التي تحتوي على كلمة مفتاح محددة:

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

> 💡 **نصيحة:** دائمًا قم بإنشاء نسخة من مجموعة الأشكال قبل تعديلها أثناء التكرار لتجنب أخطاء تعديل المجموعة.