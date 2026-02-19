---
title: مربع النص
type: docs
weight: 40
url: /ar/androidjava/examples/elements/text-box/
keywords:
- مثال على الكود
- مربع نص
- PowerPoint
- OpenDocument
- عرض تقديمي
- أندرويد
- Java
- Aspose.Slides
description: "العمل مع مربعات النص في Aspose.Slides لأندرويد: إضافة، تنسيق، محاذاة، تغليف، ضبط تلقائي، وتنسيق النص باستخدام Java لعروض PPT و PPTX و ODP."
---
في Aspose.Slides، يُمثَّل **مربع النص** بـ `AutoShape`. يمكن لأي شكل تقريبًا أن يحتوي على نص، ولكن مربع النص النموذجي لا يحتوي على تعبئة أو حد ويعرض النص فقط.

يوضح هذا الدليل كيفية إضافة، والوصول إلى، وإزالة مربعات النص برمجيًا.

## **إضافة مربع نص**

مربع النص هو ببساطة `AutoShape` دون تعبئة أو حد وبعض النص المنسق. إليك طريقة إنشاء واحد:

```java
public static void addTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // إنشاء شكل مستطيل (الافتراضي يكون مملوءًا بحد ولا يحتوي على نص).
        IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100);

        // إزالة التعبئة والحد لجعله يبدو كمربع نص نموذجي.
        textBox.getFillFormat().setFillType(FillType.NoFill);
        textBox.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        // تعيين تنسيق النص.
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        IPortionFormat textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        textFormat.getFillFormat().setFillType(FillType.Solid);
        textFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        // تعيين محتوى النص الفعلي.
        textBox.getTextFrame().setText("Some text...");
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **ملاحظة:** أي `AutoShape` يحتوي على `TextFrame` غير فارغ يمكنه أن يعمل كمربع نص.

## **الوصول إلى مربعات النص حسب المحتوى**

للعثور على جميع مربعات النص التي تحتوي على كلمة مفتاحية محددة (مثال: "Slide")، قم بالتكرار عبر الأشكال وتحقق من نصها:

```java
public static void accessTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        for (IShape shape : slide.getShapes()) {
            // يمكن فقط للأشكال AutoShape أن تحتوي على نص قابل للتحرير.
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    // افعل شيئًا مع مربع النص المتطابق.
                }
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **إزالة مربعات النص حسب المحتوى**

هذا المثال يعثر على جميع مربعات النص في الشريحة الأولى التي تحتوي على كلمة مفتاحية محددة ويحذفها:

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

> 💡 **نصيحة:** احرص دائمًا على إنشاء نسخة من مجموعة الأشكال قبل تعديلها أثناء التكرار لتجنب أخطاء تعديل المجموعة.