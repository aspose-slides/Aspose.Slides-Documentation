---
title: تنسيق نص العرض التقديمي على Android
linktitle: تنسيق النص
type: docs
weight: 50
url: /ar/androidjava/text-formatting/
keywords:
- محاذاة الفقرة
- نمط النص
- خلفية النص
- شفافية النص
- تباعد الأحرف
- خصائص الخط
- عائلة الخط
- دوران النص
- زاوية الدوران
- إطار النص
- تباعد الأسطر
- خاصية الضبط التلقائي
- تثبيت إطار النص
- تبويب النص
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تنسيق وتنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لأندرويد عبر جافا. قم بتخصيص الخطوط والألوان والمحاذاة وأكثر."
---
## **نظرة عامة**

توضح هذه المقالة طريقة تنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for Android عبر Java. تشمل الألوان الخلفية، الشفافية، تباعد الأحرف، خصائص الخط، التدوير، تباعد الفقرات، سلوك الضبط التلقائي، تثبيت النص، نقاط التبويب، وإعدادات اللغة.

في الأمثلة أدناه، سنستخدم ملفًا باسم **"sample.pptx"** يحتوي على مربع نص واحد في الشريحة الأولى بالنص التالي:

![نص مثال](sample_text.png)

للعثور على نص حرفي أو مطابقة تعبيرات نمطية وتظليلها، راجع [بحث واستبدال النص](/slides/ar/androidjava/search-and-replace-text/).

## **ضبط لون خلفية النص**

استخدم [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) لتعيين لون التظليل الافتراضي لفقرة، أو استخدم [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) لأجزاء النص الفردية.

يوضح مثال الشيفرة التالي كيفية ضبط لون الخلفية **للفقرة بأكملها**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // تعيين لون التظليل للفقرة بأكملها.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![الفقرة الرمادية](gray_paragraph.png)

يوضح مثال الشيفرة أدناه كيفية ضبط لون الخلفية **لأجزاء النص ذات الخط العريض**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // تعيين لون التظليل لجزء النص.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LTGRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![أجزاء النص الرمادية](gray_text_portions.png)

## **محاذاة فقرات النص**

استخدم [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) لضبط محاذاة الفقرة داخل إطار النص. يمكن أن تكون القيمة مركزية، محاذاة لليسار، محاذاة لليمين، مبررة، إلخ.

يوضح مثال الشيفرة التالي كيفية محاذاة الفقرة إلى **الوسط**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // تعيين محاذاة الفقرة إلى الوسط.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![الفقرة المحاذاة للوسط](aligned_paragraph.png)

## **ضبط شفافية النص**

تُتحكم شفافية النص من خلال المكوّن ألفا للون المعين إلى [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--). في الأمثلة أدناه، `alpha = 50` هو قيمة قناة ألفا ARGB على مقياس 0–255، وليس نسبة شفافية.

يوضح مثال الشيفرة التالي كيفية تطبيق الشفافية على **الفقرة بأكملها**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ضبط لون تعبئة النص إلى لون شفاف.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![الفقرة الشفافة](transparent_paragraph.png)

يوضح مثال الشيفرة التالي كيفية تطبيق الشفافية على **أجزاء النص ذات الخط العريض**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // ضبط شفافية جزء النص.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![أجزاء النص الشفافة](transparent_text_portions.png)

## **ضبط تباعد الأحرف للنص**

استخدم [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) لتوسيع أو تضييق التباعد بين الأحرف في مربع النص.

يوضح الشيفرة الجافا التالية كيفية توسيع تباعد الأحرف في **الفقرة بأكملها**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ملاحظة: استخدم القيم السالبة لتقليل تباعد الأحرف.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // زيادة تباعد الأحرف.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![تباعد الأحرف في الفقرة](character_spacing_in_paragraph.png)

يوضح مثال الشيفرة التالي كيفية توسيع تباعد الأحرف في **أجزاء النص ذات الخط العريض**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // ملاحظة: استخدم القيم السالبة لتقليل تباعد الأحرف.
            portion.getPortionFormat().setSpacing(3); // زيادة تباعد الأحرف.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![تباعد الأحرف في أجزاء النص](character_spacing_in_text_portions.png)

### **تعطيل الـ Kerning لخطوط محددة**

في بعض الحالات قد يبدو النص المرسوم بواسطة Aspose.Slides أكثر ضيقًا قليلاً من النص نفسه في PowerPoint. يمكن أن يحدث ذلك لأن PowerPoint قد يتجاهل بيانات الـ kerning لبعض الخطوط، حتى وإن كان الخط يحتوي على معلومات kerning صالحة وتم تفعيلها في إعدادات PowerPoint.

لجعل المخرجات المرسومة أقرب إلى ما يقدمه PowerPoint في هذه الحالات، يمكنك تعطيل الـ kerning لأجزاء النص التي تستخدم الخط المتأثر. اضبط [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) إلى قيمة أكبر بكثير من حجم الخط الفعلي:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormat portionFormat = portion.getPortionFormat();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portionFormat.setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

هذا الإعداد يمنع تطبيق الـ kerning على أجزاء النص المطابقة ويمكن أن يساعد في محاذاة عرض Aspose.Slides مع مخرجات PowerPoint البصرية للخطوط المتأثرة بهذا السلوك الخاص بـ PowerPoint.

## **إدارة خصائص خط النص**

يمكن ضبط خصائص الخط على مستوى الفقرة عبر [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) أو على الأجزاء الفردية عبر [IPortionFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iportionformat/).

يُظهر الكود التالي ضبط الخط ونمط النص للفقرة بأكملها: يطبق حجم الخط، الغامق، المائل، الخط السفلي المنقط، وخط Times New Roman على جميع الأجزاء في الفقرة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ضبط خصائص الخط للفقرة.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![خصائص الخط للفقرة](font_properties_for_paragraph.png)

يوضح مثال الشيفرة التالي تطبيق خصائص مشابهة على **أجزاء النص ذات الخط العريض**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // ضبط خصائص الخط لجزء النص.
            portion.getPortionFormat().setFontHeight(13);
            portion.getPortionFormat().setFontItalic(NullableBool.True);
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
            portion.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![خصائص الخط لأجزاء النص](font_properties_for_text_portions.png)

## **ضبط دوران النص**

استخدم [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) لتعيين اتجاه نص مسبق التعريف داخل الشكل.

يحدد مثال الشيفرة التالي اتجاه النص داخل الشكل إلى [TextVerticalType.Vertical270](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/textverticaltype/)، مما يدور النص **90 درجة عكس اتجاه عقارب الساعة**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![دوران النص](text_rotation.png)

## **ضبط دوران مخصص لإطارات النص**

استخدم [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) لتعيين زاوية دوران مخصصة لـ [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/).

يدور مثال الشيفرة أدناه إطار النص بزاوية 3 درجات مع اتجاه عقارب الساعة داخل الشكل:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![دوران النص المخصص](custom_text_rotation.png)

## **ضبط تباعد الأسطر في الفقرات**

توفر Aspose.Slides الخصائص [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-)، [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-)، و[IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) للتحكم في تباعد الفقرة. تُستخدم هذه الخصائص كما يلي:

* استخدم قيمة موجبة لتحديد تباعد السطر كنسبة مئوية من ارتفاع السطر.
* استخدم قيمة سالبة لتحديد تباعد السطر بالنقاط.

يوضح مثال الشيفرة التالي كيفية تحديد تباعد السطر داخل الفقرة:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![تباعد السطر داخل الفقرة](line_spacing.png)

## **ضبط نوع الضبط التلقائي لإطارات النص**

يحدد [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) كيفية تصرف النص عندما يتجاوز حدود الحاوية. استخدمه للتحكم فيما إذا كان النص سيصغر، يتدفق، أو يعيد تحجيم الشكل تلقائيًا.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ضبط تثبيت إطارات النص**

يُعرّف [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) طريقة تموضع النص عموديًا داخل الشكل، مثلًا في الأعلى أو الوسط أو الأسفل.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ضبط تبويب النص**

استخدم [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) و[IParagraphFormat.getTabs](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) لتكوين نقاط التبويب في الفقرة.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left);

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![نقاط تبويب الفقرة](paragraph_tabs.png)

## **ضبط لغة التدقيق**

توفر Aspose.Slides الخاصية [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) التي تسمح لك بتعيين لغة التدقيق لجزء النص. تحدد لغة التدقيق اللغة المستخدمة في فحص الإملاء والقواعد في PowerPoint.

يوضح مثال الشيفرة التالي كيفية ضبط لغة التدقيق لجزء النص:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // تعيين معرف لغة التدقيق.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ضبط اللغة الافتراضية**

استخدم [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) لتحديد اللغة الافتراضية للنص الذي يُنشأ أثناء تحميل أو إنشاء عرض تقديمي.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // إضافة شكل مستطيل جديد مع نص.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // التحقق من لغة الجزء الأول.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **ضبط نمط النص الافتراضي**

لتطبيق تنسيق نص افتراضي على مستوى العرض التقديمي، استخدم [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

يوضح مثال الشيفرة التالي ضبط خط عريض افتراضي بحجم 14 نقطة لجميع النصوص عبر الشرائح في عرض تقديمي جديد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // احصل على تنسيق الفقرة في المستوى العلوي.
    IParagraphFormat paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(NullableBool.True);
    }

    presentation.save("default_text_style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **استخراج النص مع تأثير الأحرف الكبيرة بالكامل**

في PowerPoint، يُظهر تطبيق تأثير **All Caps** أن النص يظهر بأحرف كبيرة على الشريحة حتى لو كان مكتوبًا أصلاً بأحرف صغيرة. عند استرجاع مثل هذا الجزء باستخدام Aspose.Slides، تُعيد المكتبة النص كما تم إدخاله. لمطابقة النص المعروض، حوّل السلسلة المسترجعة إلى أحرف كبيرة عندما تكون القيمة [TextCapType.All](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/textcaptype/).

لنفترض أن لدينا مربع النص التالي في الشريحة الأولى من ملف **sample2.pptx**.

![تأثير الأحرف الكبيرة بالكامل](all_caps_effect.png)

يوضح مثال الشيفرة التالي كيفية استخراج النص مع تطبيق تأثير **All Caps**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IPortion textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    System.out.println("Original text: " + textPortion.getText());

    IPortionFormatEffectiveData textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == TextCapType.All) {
        String text = textPortion.getText().toUpperCase();
        System.out.println("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```

الإخراج:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **الأسئلة المتكررة**

**كيف يمكن تعديل نص في جدول على شريحة؟**

لتعديل النص في جدول على شريحة، استخدم [ITable](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itable/). قم بالتكرار عبر الخلايا وحدث كل خلية عبر [ICell.getTextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/icell/#getTextFrame--) وتنسيق الفقرات عبر [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--).

**كيف يمكن تطبيق لون تدرج على النص في شريحة PowerPoint؟**

لتطبيق لون تدرج على النص، استخدم [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--). اضبط [IFillFormat.setFillType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) إلى [FillType.Gradient](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/filltype/) ثم قم بتكوين نقاط التدرج، الاتجاه، والشفافية.