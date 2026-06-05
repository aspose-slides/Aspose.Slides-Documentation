---
title: استخراج النص المتقدم من العروض التقديمية على Android
linktitle: استخراج النص
type: docs
weight: 90
url: /ar/androidjava/extract-text-from-presentation/
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
- Android
- Java
- Aspose.Slides
description: "استخراج النص بسرعة من عروض PowerPoint و OpenDocument باستخدام Aspose.Slides for Android عبر Java. اتبع دليلنا البسيط خطوة بخطوة لتوفير الوقت."
---
## **نظرة عامة**

استخراج النص من العروض التقديمية هو مهمة شائعة ولكنها أساسية للمطورين الذين يتعاملون مع محتوى الشرائح. سواء كنت تعمل مع ملفات Microsoft PowerPoint بصيغة PPT أو PPTX، أو عروض OpenDocument (ODP)، فإن الوصول إلى البيانات النصية واسترجاعها يمكن أن يكون حاسمًا للتحليل، الأتمتة، الفهرسة، أو أغراض ترحيل المحتوى.

توفر هذه المقالة دليلًا شاملًا حول كيفية استخراج النص بفعالية من صيغ عرض تقديمية مختلفة، بما في ذلك PPT وPPTX وODP، باستخدام Aspose.Slides for Android via Java. ستتعلم كيفية التكرار عبر عناصر العرض لاستخراج محتوى النص الذي تحتاجه بدقة.

## **استخراج النص من شريحة**

توفر Aspose.Slides for Android via Java الفئة [SlideUtil](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slideutil/). هذه الفئة تُظهر عدة طرق ثابتة مُحمَّلة لاستخراج كل النص من عرض تقديمي أو شريحة. لاستخراج النص من شريحة في عرض تقديمي، استخدم طريقة [getAllTextBoxes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) . هذه الطريقة تقبل كائنًا من النوع [IBaseSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseslide/) كمعامل. عند التنفيذ، تقوم الطريقة بمسح جميع محتويات الشريحة للبحث عن النص وتُعيد مصفوفة من الكائنات من النوع [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/)، مع الحفاظ على أي تنسيق للنص.

المقتطع البرمجي التالي يستخرج كل النص من الشريحة الأولى للعرض التقديمي:

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

لمسح النص من كامل العرض التقديمي، استخدم الطريقة الساكنة [getAllTextFrames](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) التي تُظهرها الفئة [SlideUtil](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/slideutil/). تقبل الطريقة معاملين:

1. أولاً، كائن [IPresentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/) يمثل عرض PowerPoint أو OpenDocument سيُستخرج منه النص.
1. ثانياً، قيمة `boolean` تُحدِّد ما إذا كان يجب تضمين الشرائح الرئيسة أثناء مسح النص من العرض.

تُعيد الطريقة مصفوفة من الكائنات من النوع [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/)، بما في ذلك معلومات تنسيق النص. يُظهر الكود أدناه مسح النص وتفاصيل التنسيق من عرض تقديمي، بما في ذلك الشرائح الرئيسة.

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

## **استخراج نص مصنف وسريع**

توفر الفئة [PresentationFactory](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentationfactory/) أيضًا طرقًا لاستخراج كل النص من العروض التقديمية:

```text
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

معامل تعداد [TextExtractionArrangingMode](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/textextractionarrangingmode/) يحدد وضعية تنظيم نتيجة استخراج النص ويمكن ضبطه على القيم التالية:
- `Un