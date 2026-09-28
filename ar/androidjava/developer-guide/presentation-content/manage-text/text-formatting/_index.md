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
- تباعد السطر
- خاصية الملاءمة التلقائية
- تثبيت إطار النص
- تبويب النص
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- العرض التقديمي
- Android
- Java
- Aspose.Slides
description: "تنسيق وتنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لنظام Android عبر Java. تخصيص الخطوط، الألوان، المحاذاة، والمزيد."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for Android عبر Java. وتغطي ألوان الخلفية، الشفافية، تباعد الأحرف، خصائص الخط، الدوران، تباعد الفقرات، سلوك الملاءمة التلقائية، تثبيت النص، محطات الجدولة، وإعدادات اللغة.

ما لم يذكر خلاف ذلك، تستخدم الأمثلة [sample.pptx](sample.pptx). الشكل الأول في الشريحة الأولى هو مربع نص، والفقرة الأولى فيه تحتوي على النص المعروض أدناه. كل من فهارس الشرائح والأشكال تبدأ من الصفر. الأمثلة التي تحدد أجزاء ذات خط عريض تستخدم التنسيق الفعّال، بما في ذلك تنسيق العريض الموروث:

![نص عينة](sample_text.png)

للعثور على نص حرفي أو مطابقة تعبير منتظم وتظليلها، راجع [البحث واستبدال النص](/slides/ar/androidjava/search-and-replace-text/).

## **تعيين لون خلفية النص**

استخدم [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.iparagraphformat/#getDefaultPortionFormat--) لتعيين لون التحديد الافتراضي لفقرة، أو استخدم [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.ibaseportionformat/#getHighlightColor--) لأجزاء النص الفردية.

المثال التالي يضع تظليل رمادي فاتح كافتراضي للفقرة الأولى. ألوان التظليل الصريحة على الأجزاء الفردية لها أولوية أعلى من هذا الافتراضي:

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

يوضح مثال الشيفرة أدناه كيفية تعيين لون الخلفية **لأجزاء النص ذات الخط العريض**:

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

استخدم [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.iparagraphformat/#setAlignment-int-) لتعيين محاذاة الفقرة داخل إطار نص. يمكن أن تكون القيمة متمركزة، محاذاة لليسار، محاذاة لليمين، مبررة، وهكذا.

المثال التالي يوضح كيفية محاذاة الفقرة إلى **المركز**:

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

![الفقرة المحاذاة](aligned_paragraph.png)

## **تعيين الشفافية للنص**

يتم التحكم في شفافية النص عبر مكوّن ألفا للون المعيّن إلى [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.ibaseportionformat/#getFillFormat--). في الأمثلة أدناه، `alpha = 50` هو قيمة قناة ألفا ARGB على مقياس 0–255، وليس نسبة شفافية.

المثال التالي يوضح كيفية تطبيق الشفافية على **الفقرة بأكملها**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // تعيين لون تعبئة النص إلى لون شفاف.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![الفقرة الشفافة](transparent_paragraph.png)

المثال التالي يوضح كيفية تطبيق الشفافية على **أجزاء النص ذات الخط العريض**:

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
            // تعيين شفافية جزء النص.
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

## **تعيين تباعد الأحرف للنص**

استخدم [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.ibaseportionformat/#setSpacing-float-) لتوسيع أو تضييق التباعد بين الأحرف في مربع نص. تُضيف الأمثلة 3 نقاط من التباعد؛ القيم السالبة تضيق النص.

الكود التالي يوضح كيفية توسيع تباعد الأحرف في **الفقرة بأكملها**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ملاحظة: استخدم القيم السالبة لضغط تباعد الأحرف.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // توسيع تباعد الأحرف.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![تباعد الأحرف في الفقرة](character_spacing_in_paragraph.png)

الكود التالي يوضح كيفية توسيع تباعد الأحرف في **أجزاء النص ذات الخط العريض**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // ملاحظة: استخدم القيم السالبة لضغط تباعد الأحرف.
            portion.getPortionFormat().setSpacing(3); // توسيع تباعد الأحرف.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![تباعد الأحرف في أجزاء النص](character_spacing_in_text_portions.png)

### **تعطيل التدرج للأحرف للخطوط المحددة**

في بعض الحالات، قد يبدو النص المُنشأ بواسطة Aspose.Slides أكثر ضيقًا قليلاً من النص نفسه المعروض في PowerPoint. يمكن أن يحدث ذلك لأن PowerPoint قد يتجاهل بيانات التدرج للأحرف لبعض الخطوط، حتى عندما يحتوي الخط على معلومات تدرج صالحة ويتم تمكين التدرج في إعدادات PowerPoint.

لجعل الناتج المُنشأ أقرب إلى ما في PowerPoint في مثل هذه الحالات، يمكنك تعطيل التدرج للأحرف لأجزاء النص التي تستخدم الخط المتأثر. اضبط [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.ibaseportionformat/#setKerningMinimalSize-float-) على قيمة أكبر من حجم الخط الفعلي. يتطلب هذا المثال وجود "presentation.pptx" مع مربع نص كشكل أول في الشريحة الأولى. يتحقق من أسماء الخطوط الفعّالة، بما في ذلك الخطوط الموروثة، ويضبط عتبة 100 نقطة للأجزاء التي تستخدم Roboto. هذا يعطل التدرج للأجزاء المطابقة ذات حجم الخط أقل من 100 نقطة:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormatEffectiveData portionFormat = portion.getPortionFormat().getEffective();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **إدارة خصائص خط النص**

يمكن تعيين خصائص الخط على مستوى الفقرة عبر [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.iparagraphformat/#getDefaultPortionFormat--) أو على الأجزاء الفردية عبر [IPortionFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.iportionformat/).

المثال التالي يضبط الخط الافتراضي للفقرة الأولى إلى Times New Roman بحجم 12 نقطة مع تنسيق عريض ومائل وتسطير منقط. التنسيق الصريح على الأجزاء الفردية له أولوية أعلى من هذه القيم الافتراضية:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // تعيين خصائص الخط للفقرة.
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

المثال التالي يطبق Times New Roman بحجم 13 نقطة، وتنسيق مائل، وتسطير منقط على الأجزاء التي يكون تنسيقها الفعّال عريضًا:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // تعيين خصائص الخط لجزء النص.
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

## **تعيين دوران النص**

استخدم [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.itextframeformat/#setTextVerticalType-byte-) لتعيين اتجاه نص مُحدد مسبقًا داخل الشكل.

المثال التالي يضبط اتجاه النص في الشكل إلى [TextVerticalType.Vertical270](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.textverticaltype/)، والذي يدور النص **90 درجة عكس عقارب الساعة**:

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

## **تعيين دوران مخصص لإطارات النص**

استخدم [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.itextframeformat/#setRotationAngle-float-) لتعيين زاوية دوران مخصصة لـ [ITextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.itextframe/).

الكود التالي يدور إطار النص بمقدار 3 درجات مع اتجاه عقارب الساعة داخل الشكل:

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

## **تعيين تباعد الأسطر للفقرات**

توفر Aspose.Slides [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.iparagraphformat/#setSpaceAfter-float-)، [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.iparagraphformat/#setSpaceBefore-float-)، و[IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.iparagraphformat/#setSpaceWithin-float-) للتحكم في تباعد الفقرات. تُستخدم هذه الخصائص كما يلي:

* استخدم قيمة موجبة لتحديد تباعد السطر كنسبة مئوية من ارتفاع السطر.
* استخدم قيمة سالبة لتحديد تباعد السطر بالنقاط.

المثال التالي يضبط التباعد داخل الفقرة الأولى إلى 200٪ من ارتفاع السطر (تباعد مزدوج):

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

![تباعد الأسطر داخل الفقرة](line_spacing.png)

## **التحكم في كسر السطر**

قواعد كسر سطر الفقرة مفيدة في كتل نص ضيقة وعروض تقديمية تمزج بين النص اللاتيني والآسيوي الشرقي. الطرق التالية تنتمي إلى [IParagraphFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.iparagraphformat/)، لذا تنطبق على الفقرة بأكملها:

- [setLatinLineBreak](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.iparagraphformat/#setLatinLineBreak-byte-) يتحكم في قواعد كسر السطر للخط اللاتيني. في النص المختلط، يمكن أن يغيّر ذلك موضع النص الآسيوي الشرقي وعلامات الترقيم المجاورة.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.iparagraphformat/#setEastAsianLineBreak-byte-) يتحكم في قواعد كسر السطر للغات الآسيوية الشرقية، بما في ذلك القيود على الأحرف في بداية ونهاية السطر.

هذه القواعد لا تحل محل [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.itextframeformat/#setWrapText-byte-)، الذي يُفعّل الالتفاف التلقائي داخل إطار النص. إنها تؤثر على تخطيط النص عندما يحدث الالتفاف؛ لا تُدرج أحرف كسر السطر. كسر سطر صريح يفرض سطرًا جديدًا داخل الفقرة بغض النظر عن العرض المتاح.

المثال التالي المُستقل يُنشئ كتلة نص ضيقة تحتوي على نص صيني ولاتيني. يضبط كلا الخيارين لكسر السطر صراحةً ويحفظ الملف باسم "line_breaking.pptx". لتجربة أي قاعدة، غيّر القيمة المقابلة مع إبقاء الإعدادات الأخرى ثابتة. يستخدم المثال Arial بحجم 24 نقطة وSimSun مع عرض إطار 160 نقطة وهوامش أفقية صفرية. يتم استدعاء [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.itextframeformat/#setAutofitType-byte-) مع [TextAutofitType.None](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.textautofittype/) ليبقى حجم النص وأبعاد الإطار ثابتين.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    FontData eastAsianFont = new FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setLatinLineBreak(NullableBool.False);
    format.setEastAsianLineBreak(NullableBool.True);

    presentation.save("line_breaking.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **التحكم في علامات الترقيم المتدلية**

يسمح [IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.iparagraphformat/#setHangingPunctuation-byte-) بتمديد علامات الترقيم المؤهلة إلى ما وراء الحافة اليمنى لسطر النص بدلاً من أن تشغل السطر التالي. ينطبق ذلك على الفقرة بأكملها ويختلف عن المسافة المتدلية.

المثال التالي المُستقل يُفعّل علامات الترقيم المتدلية في إطار نص عرضه 100 نقطة ويحفظ الملف باسم "hanging_punctuation.pptx". مع Arial بحجم 24 نقطة وهوامش أفقية صفرية، يبقى النقطة الأخيرة بعد كلمة "sentence" وتتمدّ إلى ما وراء الحافة اليمنى للنص. اضبط الخاصية إلى [NullableBool.False](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.nullablebool/) للمقارنة: بهذه الإعدادات، تشغل النقطة سطرًا منفصلًا. تم تمكين الالتفاف وتعطيل الملاءمة التلقائية للحفاظ على العرض المتاح ثابتًا.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setHangingPunctuation(NullableBool.True);

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ليس كل علامة ترقيم يمكن أن تتدلى. النتيجة المرئية تعتمد على توفر الخط وتخطيط النص: تغيير الخط أو العرض المتاح أو الهوامش أو إعدادات الملاءمة قد يُزيل الاختلاف المرئي.

## **تعيين نوع الملاءمة التلقائية لإطارات النص**

يحدد [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.itextframeformat/#setAutofitType-byte-) سلوك النص عندما يتجاوز حدود حاويته. استخدمه للتحكم فيما إذا كان النص سيصغر، سيتجاوز، أو سيعيد تحجيم الشكل تلقائيًا. المثال التالي يضبط الشكل لإعادة التحجيم ليتناسب مع النص ويحفظ الناتج باسم "autofit_type.pptx".

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

لحساب عدد الأسطر بعد الالتفاف التلقائي ورؤية كيف يغيّر حجم النص أو عرض الشكل النتيجة، راجع [Count Rendered Lines](/slides/ar/androidjava/manage-paragraph/). عدد الأسطر بمفرده لا يدل على ما إذا كان النص يفيض عن حاويته.

## **تعيين تثبيت إطارات النص**

يُعرّف [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.itextframeformat/#setAnchoringType-byte-) كيفية تموضع النص عموديًا داخل الشكل، مثلًا في الأعلى، الوسط، أو الأسفل. المثال التالي يثبت النص في أسفل الشكل الأول ويحفظ النتيجة باسم "text_anchor.pptx".

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

## **تعيين تبويب النص**

استخدم [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.iparagraphformat/#setDefaultTabSize-float-) و[IParagraphFormat.getTabs](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.iparagraphformat/#getTabs--) لتكوين نقاط الجدولة في فقرة. المثال التالي يضبط الفاصل الافتراضي للتاب إلى 100 نقطة ويضيف تبويبًا محاذيًا لليمين عند 30 نقطة. هذه الإعدادات تؤثر على النص الذي يحتوي على أحرف تاب.

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

![تبويبات الفقرة](paragraph_tabs.png)

## **تعيين لغة التدقيق**

توفر Aspose.Slides [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.ibaseportionformat/#setLanguageId-java.lang.String-)، والتي تسمح لك بتعيين لغة التدقيق لجزء نص. تحدد لغة التدقيق اللغة المستخدمة لتدقيق الإملاء والقواعد في PowerPoint.

المثال التالي يتطلب وجود "presentation.pptx" مع مربع نص كشكل أول في الشريحة الأولى وعلى الأقل فقرة واحدة. يستبدل محتويات الفقرة الأولى بـ "1。"، يعيّن SimSun كخط لها، ويُعيّن لغة التدقيق الصينية المبسطة (`zh-CN`). يحفظ النتيجة باسم "proofing_language.pptx":

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

## **تعيين اللغة الافتراضية**

استخدم [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.loadoptions/#setDefaultTextLanguage-java.lang.String-) لتعريف اللغة الافتراضية للنص الذي يُنشأ أثناء تحميل أو إنشاء عرض تقديمي. المثال التالي يُنشئ عرضًا تقديميًا باللغة الإنجليزية الأمريكية كلغة نص افتراضية، يضيف مربع نص، ويطبع `en-US` للجزء النصي الأول.

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

    // فحص لغة الجزء الأول.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **تعيين نمط النص الافتراضي**

لتطبيق تنسيق نص افتراضي على مستوى العرض التقديمي، استخدم [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.ipresentation/#getDefaultTextStyle--).

المثال التالي يضبط خطًا عريضًا بحجم 14 نقطة كافتراضي للفقرات ذات المستوى الأعلى في عرض تقديمي جديد ويحفظه باسم "default_text_style.pptx". يمكن للنص أن يرث هذه القيم الافتراضية ما لم يُستبدل بتنسيق أكثر تحديدًا.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // احصل على تنسيق الفقرة المستوى الأعلى.
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

## **استخراج النص مع تأثير الحروف الكبيرة كلها**

في PowerPoint، يجعل تطبيق تأثير الخط **All Caps** النص يظهر بأحرف كبيرة على الشريحة حتى لو كُتب أصلاً بأحرف صغيرة. عند استرجاع مثل هذا الجزء النصي باستخدام Aspose.Slides، تُعيد المكتبة النص كما تم إدخاله بالضبط. لمطابقة النص المعروض، تحقق من [TextCapType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.textcaptype/) وحوّل السلسلة المسترجعة إلى أحرف كبيرة عندما تكون القيمة `All`.

يتطلب هذا المثال وجود "sample2.pptx" مع مربع نص كشكل أول في الشريحة الأولى. يحتوي الجزء الأول من الفقرة الأولى على "Hello, Aspose!" مع تطبيق تأثير All Caps، كما هو موضح أدناه.

![تأثير الحروف الكبيرة كلها](all_caps_effect.png)

الكود التالي يوضح كيفية استخراج النص مع تطبيق تأثير **All Caps**:

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

**كيف يمكنني تعديل النص في جدول على شريحة؟**

لتعديل النص في جدول على شريحة، استخدم [ITable](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.itable/). قم بالتكرار عبر الخلايا وحدث كل خلية عبر [ICell.getTextFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.icell/#getTextFrame--) وتنسيق الفقرة عبر [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.iparagraph/#getParagraphFormat--).

**كيف يمكنني تطبيق لون تدرج على النص في شريحة PowerPoint؟**

لتطبيق لون تدرج على النص، استخدم [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.ibaseportionformat/#getFillFormat--). اضبط [IFillFormat.setFillType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.ifillformat/#setFillType-byte-) إلى [FillType.Gradient](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides.filltype/) وقم بتكوين نقاط التدرج، الاتجاه، والشفافية.