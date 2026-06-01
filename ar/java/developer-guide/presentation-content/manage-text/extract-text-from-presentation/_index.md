---
title: استخراج النص المتقدم من العروض التقديمية في جافا
linktitle: استخراج النص
type: docs
weight: 90
url: /ar/java/extract-text-from-presentation/
keywords:
- استخراج النص
- استخراج النص من شريحة
- استخراج النص من عرض تقديمي
- استخراج النص من PowerPoint
- استخراج النص من OpenDocument
- استخراج النص من PPT
- استخراج النص من PPTX
- استخراج النص من ODP
- استرجاع النص
- استرجاع النص من شريحة
- استرجاع النص من عرض تقديمي
- استرجاع النص من PowerPoint
- استرجاع النص من OpenDocument
- استرجاع النص من PPT
- استرجاع النص من PPTX
- استرجاع النص من ODP
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "استخراج النص بسرعة من عروض PowerPoint و OpenDocument باستخدام Aspose.Slides لجافا. اتبع دليلنا البسيط خطوة بخطوة لتوفير الوقت."
---
## **نظرة عامة**

يعد استخراج النص من العروض التقديمية مهمة شائعة ولكنها أساسية للمطورين الذين يعملون مع محتوى الشرائح. سواء كنت تتعامل مع ملفات Microsoft PowerPoint بصيغة PPT أو PPTX، أو عروض OpenDocument (ODP)، فإن الوصول إلى البيانات النصية واسترجاعها يمكن أن يكون حيويًا للتحليل أو الأتمتة أو الفهرسة أو أغراض ترحيل المحتوى.

توفر هذه المقالة دليلًا شاملاً حول كيفية استخراج النص بفعالية من صيغ العروض المختلفة، بما في ذلك PPT و PPTX و ODP، باستخدام Aspose.Slides for Java. ستتعرّف على كيفية التكرار المنهجي عبر عناصر العرض لاستخراج محتوى النص الذي تحتاجه بدقة.

## **استخراج النص من شريحة**

توفر Aspose.Slides for Java الفئة [SlideUtil](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slideutil/). تكشف هذه الفئة عن عدة أساليب ثابتة محمَّلة لاستخراج كل النص من عرض تقديمي أو شريحة. لاستخراج النص من شريحة في عرض تقديمي، استخدم طريقة [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) . تقبل هذه الطريقة كمعامل كائن من النوع [IBaseSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseslide/). عند تنفيذها، تُفحص الطريقة الشريحة بأكملها للبحث عن النص وتُعيد مصفوفة من الكائنات من النوع [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/)، مع الحفاظ على أي تنسيق للنص.

المقتطف البرمجي التالي يستخرج كل النص من الشريحة الأولى في العرض:

```java
int slideIndex = 0;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(slideIndex);

    ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **استخراج النص من عرض تقديمي**

للمسح النصي عبر العرض التقديمي بأكمله، استخدم الطريقة الثابتة [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) التي تكشفها الفئة [SlideUtil](https://reference.aspose.com/slides/ar/java/com.aspose.slides/slideutil/). تقبل هذه الطريقة معاملين:

1. أولاً، كائن من النوع [IPresentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentation/) يمثل عرض PowerPoint أو OpenDocument الذي سيُستخرج منه النص.
1. ثانياً، قيمة `boolean` تشير إلى ما إذا كان يجب تضمين الشرائح الرئيسية عند مسح النص من العرض.

تُرجع الطريقة مصفوفة من الكائنات من النوع [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/)، متضمنةً معلومات تنسيق النص. يُظهر الكود أدناه عملية مسح النص وتفاصيل التنسيق من عرض تقديمي، بما فيها الشرائح الرئيسية.

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    boolean includeMasterSlides = true;
    ITextFrame[] textFrames = SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **استخراج النص المصنف والسريع**

توفر الفئة [PresentationFactory](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentationfactory/) أيضًا أساليب لاستخراج كل النص من العروض التقديمية:

```java
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

تُحدد الوسيطة enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textextractionarrangingmode/) وضعية تنظيم نتيجة استخراج النص ويمكن ضبطها على القيم التالية:

- `Unarranged` - النص الخام دون اعتبار لموقعه على الشريحة.
- `Arranged` - يتم ترتيب النص بنفس الترتيب الموجود على الشريحة.

يمكن استخدام وضعية `Unarranged` عندما تكون السرعة أمرًا حاسمًا؛ فهي أسرع من وضعية `Arranged`.

تمثل الواجهة [IPresentationText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentationtext/) النص الخام المستخرج من العرض التقديمي. تُعيد الطريقة `getSlidesText` مصفوفة من الكائنات من النوع [ISlideText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidetext/). كل كائن يمثل النص على الشريحة المقابلة. يحتوي كائن النوع [ISlideText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islidetext/) على الطرق التالية:

- `getText` - النص داخل أشكال الشريحة.
- `getMasterText` - النص داخل أشكال الشريحة الرئيسية المرتبطة بهذه الشريحة.
- `getLayoutText` - النص داخل أشكال شريحة التخطيط المرتبطة بهذه الشريحة.
- `getNotesText` - النص داخل أشكال شريحة الملاحظات المرتبطة بهذه الشريحة.
- `getCommentsText` - النص داخل التعليقات المرتبطة بهذه الشريحة.

```java
String presentationPath = "presentation.ppt";
int arrangingMode = TextExtractionArrangingMode.Unarranged;
IPresentationText presentationText = PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
ISlideText firstSlideText = presentationText.getSlidesText()[0];

System.out.println(firstSlideText.getText());
System.out.println(firstSlideText.getLayoutText());
System.out.println(firstSlideText.getMasterText());
System.out.println(firstSlideText.getNotesText());
System.out.println(firstSlideText.getCommentsText());
```

## **الأسئلة المتكررة**

**ما مدى سرعة معالجة Aspose.Slides للعروض الكبيرة أثناء استخراج النص؟**

تم تحسين Aspose.Slides لأداء عالٍ ويمكنه معالجة حتى [العروض الكبيرة](/slides/ar/java/open-presentation/)، مما يجعله مناسبًا لسيناريوهات المعالجة في الوقت الحقيقي أو على نطاق واسع.

**هل يمكن لـ Aspose.Slides استخراج النص من الجداول والمخططات داخل العروض؟**

نعم. يمكن لـ Aspose.Slides استخراج النص من العديد من عناصر الشريحة، بما في ذلك الجداول والكائنات المرتبطة بالمخططات، بحيث يمكنك الوصول إلى المحتوى النصي وتحليه في هياكل العرض الشائعة.

**هل أحتاج إلى ترخيص خاص من Aspose.Slides لاستخراج النص من العروض؟**

يمكنك استخراج النص باستخدام النسخة التجريبية المجانية من Aspose.Slides، رغم أنها تحتوي على [قيود معينة](/slides/ar/java/licensing/)، مثل معالجة عدد محدود من الشرائح فقط. للحصول على استخدام غير مقيد ومعالجة عروض أكبر، يُنصح بشراء ترخيص كامل.