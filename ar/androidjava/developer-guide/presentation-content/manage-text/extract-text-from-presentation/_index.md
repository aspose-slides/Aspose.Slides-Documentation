---
title: استخراج النص المتقدم من العروض التقديمية على Android
linktitle: استخراج النص
type: docs
weight: 90
url: /ar/androidjava/extract-text-from-presentation/
keywords:
- استخراج النص
- استخراج النص من الشريحة
- استخراج النص من العرض التقديمي
- استخراج النص من PowerPoint
- استخراج النص من OpenDocument
- استخراج النص من PPT
- استخراج النص من PPTX
- استخراج النص من ODP
- استرجاع النص
- استرجاع النص من الشريحة
- استرجاع النص من العرض التقديمي
- استرجاع النص من PowerPoint
- استرجاع النص من OpenDocument
- استرجاع النص من PPT
- استرجاع النص من PPTX
- استرجاع النص من ODP
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "استخراج النص بسرعة من عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لنظام Android عبر Java. اتبع دليلنا البسيط خطوة بخطوة لتوفير الوقت."
---
## **نظرة عامة**

استخراج النص من العروض التقديمية هو مهمة شائعة ولكنها أساسية للمطورين الذين يتعاملون مع محتوى الشرائح. سواءً كنت تتعامل مع ملفات Microsoft PowerPoint بصيغة PPT أو PPTX، أو عروض OpenDocument (ODP)، فإن الوصول إلى البيانات النصية واسترجاعها يمكن أن يكون حيويًا للتحليل، والأتمتة، والفهرسة، أو أغراض ترحيل المحتوى.

توفر هذه المقالة دليلًا شاملاً حول كيفية استخراج النص بفعالية من تنسيقات العروض المختلفة، بما في ذلك PPT وPPTX وODP، باستخدام Aspose.Slides for Android via Java. ستتعلم كيفية التنقل عبر عناصر العرض بشكل منهجي لاسترجاع المحتوى النصي الذي تحتاجه بدقة.

## **استخراج النص من شريحة**

توفر Aspose.Slides for Android via Java الفئة [SlideUtil](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slideutil/). تُظهر هذه الفئة عدة أساليب ثابتة محملة للقيام باستخراج جميع النصوص من عرض تقديمي أو شريحة. لاستخراج النص من شريحة في عرض تقديمي، استخدم الأسلوب [getAllTextBoxes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) . يقبل هذا الأسلوب كائنًا من النوع [IBaseSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseslide/) كمعامل. عند التنفيذ، يقوم الأسلوب بمسح الشريحة بأكملها بحثًا عن النص ويعيد مصفوفة من الكائنات من النوع [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/)، مع الحفاظ على أي تنسيقات نصية.

المقتطف البرمجي التالي يستخرج كل النص من الشريحة الأولى في العرض التقديمي:

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

لمسح النص من العرض التقديمي بالكامل، استخدم الأسلوب الثابت [getAllTextFrames](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) المعروض بواسطة الفئة [SlideUtil](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slideutil/). يقبل هذا الأسلوب معاملين:

1. أولاً، كائن من النوع [IPresentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/) يمثل عرض PowerPoint أو OpenDocument الذي سيُستخرج منه النص.
2. ثانياً، قيمة `boolean` تُحدِّد ما إذا كان يجب تضمين الشرائح الرئيسة عند مسح النص من العرض التقديمي.

يعيد الأسلوب مصفوفة من الكائنات من النوع [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/)، متضمنةً معلومات تنسيق النص. يُظهر الكود أدناه كيفية مسح النص وتفاصيل التنسيق من عرض تقديمي، بما في ذلك الشرائح الرئيسة.

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

توفر الفئة [PresentationFactory](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentationfactory/) أيضًا أساليب لاستخراج كل النص من العروض التقديمية:

```text
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

يُشير معامل enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/textextractionarrangingmode/) إلى وضع تنظيم نتيجة استخراج النص ويمكن ضبطه إلى القيم التالية:
- `Unarranged` - النص الخام دون مراعاة موقعه على الشريحة.
- `Arranged` - يُرتب النص بنفس ترتيب ظهوره على الشريحة.

يمكن استخدام وضع **Unarranged** عندما تكون السرعة أمرًا حاسمًا؛ فهو أسرع من وضع **Arranged**.

يمثّل [IPresentationText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentationtext/) النص الخام المستخرج من العرض التقديمي. تُعيد الطريقة `getSlidesText` مصفوفة من الكائنات من النوع [ISlideText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidetext/). كل كائن يمثل النص على الشريحة المقابلة. يحتوي كائن النوع [ISlideText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidetext/) على الطرق التالية:

- `getText` - النص داخل أشكال الشريحة.
- `getMasterText` - النص داخل أشكال الشريحة الرئيسة المرتبطة بهذه الشريحة.
- `getLayoutText` - النص داخل أشكال شريحة التخطيط المرتبطة بهذه الشريحة.
- `getNotesText` - النص داخل أشكال شريحة الملاحظات المرتبطة بهذه الشريحة.
- `getCommentsText` - النص داخل التعليقات المرتبطة بهذه الشريحة.

```java
String presentationPath = "presentation.pptx";
int arrangingMode = TextExtractionArrangingMode.Unarranged;
IPresentationText presentationText = PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
ISlideText firstSlideText = presentationText.getSlidesText()[0];

System.out.println(firstSlideText.getText());
System.out.println(firstSlideText.getLayoutText());
System.out.println(firstSlideText.getMasterText());
System.out.println(firstSlideText.getNotesText());
System.out.println(firstSlideText.getCommentsText());
```

## **الأسئلة الشائعة**

**ما مدى سرعة معالجة Aspose.Slides للعروض الكبيرة أثناء استخراج النص؟**

تم تحسين Aspose.Slides للأداء العالي ويمكنه معالجة حتى [العروض الكبيرة](/slides/ar/androidjava/open-presentation/)، مما يجعله مناسبًا لسيناريوهات المعالجة في الوقت الحقيقي أو على نطاق واسع.

**هل يمكن لـ Aspose.Slides استخراج النص من الجداول والرسوم البيانية داخل العروض؟**

نعم. يمكن لـ Aspose.Slides استخراج النص من العديد من عناصر الشريحة، بما في ذلك الجداول والكائنات المرتبطة بالرسوم البيانية، مما يتيح لك الوصول إلى المحتوى النصي وتحليله في هياكل العرض الشائعة.

**هل أحتاج إلى ترخيص خاص من Aspose.Slides لاستخراج النص من العروض؟**

يمكنك استخراج النص باستخدام نسخة التجربة المجانية من Aspose.Slides، رغم أنها ستخضع لـ [قيود معينة](/slides/ar/androidjava/licensing/)، مثل معالجة عدد محدود من الشرائح