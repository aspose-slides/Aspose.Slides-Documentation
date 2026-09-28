---
title: تنسيق نص العرض التقديمي في Java
linktitle: تنسيق النص
type: docs
weight: 50
url: /ar/java/text-formatting/
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
- العرض التقديمي
- Java
- Aspose.Slides
description: "قم بتنسيق وتنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for Java. خصّص الخطوط والألوان والمحاذاة والمزيد."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for Java. تشمل المواضيع ألوان الخلفية، الشفافية، تباعد الأحرف، خصائص الخط، الدوران، تباعد الفقرات، سلوك Autofit، تثبيت النص، مواضع علامات التبويب، وإعدادات اللغة.

ما لم يُذكر غير ذلك، فإن الأمثلة تستخدم [sample.pptx](sample.pptx). الشكل الأول في الشريحة الأولى هو مربع نص، والفقرة الأولى فيه تحتوي على النص المعروض أدناه. كل من فهارس الشرائح والأشكال تبدأ من الصفر. الأمثلة التي تحدد أجزاء بالخط العريض تستخدم التنسيق الفعّال، بما في ذلك تنسيق العريض الموروث:

![نص العينة](sample_text.png)

للعثور على نص حرفي أو مطابقة تعبير منتظم وتظليلها، راجع [بحث واستبدال النص](/slides/ar/java/search-and-replace-text/).

## **تعيين لون خلفية النص**

استخدم [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) لتعيين لون التظليل الافتراضي لفقرة، أو استخدم [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) لأجزاء النص الفردية.

المثال التالي يعيّن تظليل رمادي فاتح كافتراضي للفقرة الأولى. الألوان الصريحة على الأجزاء الفردية لها أولوية أعلى من هذا الافتراضي:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // تعيين لون التمييز للفقرة بأكملها.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![الفقرة الرمادية](gray_paragraph.png)

يعرض مثال الكود أدناه كيفية تعيين لون الخلفية **لأجزاء النص ذات الخط العريض**:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // تعيين لون التمييز للجزء النصي.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
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

استخدم [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) لتعيين محاذاة الفقرة داخل إطار النص. يمكن أن تكون القيمة مركزة، محاذاة إلى اليسار، محاذاة إلى اليمين، مبررة، وما إلى ذلك.

المثال التالي يوضح كيفية محاذاة الفقرة إلى **الوسط**:

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

![الفقرة المحاذاة إلى الوسط](aligned_paragraph.png)

## **تعيين الشفافية للنص**

تتحكم الشفافية في النص عبر مكوّن ألفا للون المعيّن إلى [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). في الأمثلة أدناه، `alpha = 50` هو قيمة ألفا بنظام ARGB على مقياس 0–255، وليس نسبة شفافية.

المثال التالي يوضح كيفية تطبيق الشفافية على **الفقرة بأكملها**:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // تعيين لون ملء النص إلى لون شفاف.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

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
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // تعيين شفافية الجزء النصي.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));
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

استخدم [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) لتوسيع أو تضييق التباعد بين الأحرف في مربع النص. تضيف الأمثلة 3 نقاط إلى التباعد؛ القيم السالبة تضغط النص.

الكود التالي للـ Java يوضح كيفية توسيع تباعد الأحرف في **الفقرة بأكملها**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ملاحظة: استخدم قيمًا سلبية لضغط تباعد الأحرف.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // توسيع تباعد الأحرف.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![تباعد الأحرف في الفقرة](character_spacing_in_paragraph.png)

المثال التالي يوضح كيفية توسيع تباعد الأحرف في **أجزاء النص ذات الخط العريض**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // ملاحظة: استخدم قيمًا سلبية لضغط تباعد الأحرف.
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

### **تعطيل الترانسفير للخطوط المحددة**

في بعض الحالات، قد يظهر النص المُعالَج بواسطة Aspose.Slides أكثر تلاصقًا قليلًا من النص نفسه في PowerPoint. يحدث هذا لأن PowerPoint قد يتجاهل بيانات الترانسفير لبعض الخطوط حتى وإن كان الخط يحتوي على معلومات ترانسفير صالحة ومفعّلة في إعدادات PowerPoint.

لتقريب الناتج من مظهر PowerPoint في هذه الحالات، يمكنك تعطيل الترانسفير لأجزاء النص التي تستخدم الخط المتأثر. عيّن [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) إلى قيمة أكبر من حجم الخط الفعلي. يتطلب هذا المثال ملف "presentation.pptx" يحتوي على مربع نص كشكل أول في الشريحة الأولى. يتحقق من أسماء الخطوط الفعّالة، بما في ذلك الخطوط الموروثة، ويعيّن عتبة 100 نقطة للأجزاء التي تستخدم Roboto. يؤدي ذلك إلى تعطيل الترانسفير للأجزاء المطابقة التي يكون حجم الخط أقل من 100 نقطة:

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

بالنسبة للنص المطابق تحت العتبة، يمنع هذا الإعداد الترانسفير ويمكن أن يساعد في تقريب عرض Aspose.Slides إلى مظهر PowerPoint للخطوط المتأثرة بهذا السلوك الخاص بـ PowerPoint.

## **إدارة خصائص خط النص**

يمكن تعيين خصائص الخط على مستوى الفقرة عبر [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) أو على الأجزاء الفردية عبر [IPortionFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iportionformat/).

المثال التالي يعيّن الخط الافتراضي للفقرة الأولى إلى Times New Roman بحجم 12 نقطة مع تنسيق عريض، مائل، وتسطير منقط. التنسيق الصريح على الأجزاء الفردية يتفوق على هذه الإعدادات الافتراضية:

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

المثال التالي يطبق Times New Roman بحجم 13 نقطة، تنسيق مائل، وتسطير منقط على الأجزاء التي يكون تنسيقها الفعال عريضًا:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // تعيين خصائص الخط للجزء النصي.
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

استخدم [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) لتعيين توجيه نص مسبق داخل الشكل.

المثال التالي يعيّن توجيه النص في الشكل إلى [TextVerticalType.Vertical270](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textverticaltype/)، مما يدور النص **90 درجة عكس اتجاه عقارب الساعة**:

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

استخدم [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) لتعيين زاوية دوران مخصصة لإطار نصي [ITextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/).

الكود التالي يدور إطار النص بزاوية 3 درجات مع اتجاه عقارب الساعة داخل الشكل:

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

توفر Aspose.Slides الطرق [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-)، [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-)، و[IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) للتحكم في تباعد الفقرات. تُستخدم هذه الخصائص كالتالي:

* استخدم قيمة موجبة لتحديد تباعد الأسطر كنسبة مئوية من ارتفاع السطر.
* استخدم قيمة سالبة لتحديد تباعد الأسطر بوحدة النقاط.

المثال التالي يعيّن التباعد داخل الفقرة الأولى إلى 200 % من ارتفاع السطر (تباعد مزدوج):

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

## **التحكم في فاصل السطر**

قواعد كسر السطر للفقرة مفيدة في كتل نصية ضيقة وعروض تقديمية تمزج بين النص اللاتيني والنص الآسيوي الشرقي. تنتمي الطرق التالية إلى [IParagraphFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/)، لذا فهي تُطبق على الفقرة بأكملها:

- [setLatinLineBreak](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) يتحكم في قواعد كسر السطر للكتابة اللاتينية. في النص المختلط، قد يؤدي تغييره أيضًا إلى تعديل مواضع النص الآسيوي الشرقي وعلامات الترقيم المجاورة.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) يتحكم في قواعد كسر السطر للكتابة الآسيوية الشرقية، بما في ذلك القيود على الأحرف في بداية ونهاية السطر.

هذه القواعد لا تحل محل [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframeformat/#setWrapText-byte-)، الذي يُفعل الالتفاف التلقائي داخل إطار النص. هي تؤثر على التخطيط عندما يحدث الالتفاف؛ لا تُدرج أحرف فاصل سطر. فاصل سطر صريح يُنشئ سطرًا جديدًا داخل الفقرة بغض النظر عن العرض المتاح.

المثال المستقل التالي ينشئ كتلة نصية ضيقة تحتوي على نص صيني ولاتيني. يعيّن كلا خيارَي كسر السطر صراحةً ويحفظ الملف "line_breaking.pptx". لتجربة أي قاعدة، غير القيمة المقابلة مع إبقاء الإعدادات الأخرى ثابتة. يستخدم المثال خط Arial بحجم 24 نقطة وSimSun مع عرض إطار 160 نقطة وهوامش أفقية صفرية داخل إطار النص. تُستدعى [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) مع [TextAutofitType.None](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textautofittype/) للحفاظ على حجم النص وإطار الشكل ثابتين:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **التحكم في علامات الترقيم المعلقة**

يتيح [IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) للعلامات الترقيمية المؤهلة أن تمتد إلى ما وراء الحافة اليمنى لسطر النص بدلاً من الانتقال إلى السطر التالي. يُطبق على الفقرة بأكملها ويختلف عن الهوامش المتدلية.

المثال المستقل التالي يُفعل علامات الترقيم المعلقة في إطار نص بعرض 100 نقطة ويحفظ الملف "hanging_punctuation.pptx". باستخدام خط Arial بحجم 24 نقطة وهوامش أفقية صفرية، يبقى الفاصل النهائي بعد كلمة "sentence" ويمتد إلى ما وراء الحافة اليمنى للنص. عيّن الخاصية إلى [NullableBool.False](https://reference.aspose.com/slides/ar/java/com.aspose.slides/nullablebool/) للمقارنة: في هذه الحالة، يُنشئ الفاصل سطرًا منفصلًا. يُفعل الالتفاف ويُعطّل Autofit للحفاظ على العرض المتاح ثابتًا:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

ليس كل علامة ترقيم يمكن أن تُعلّق. النتيجة الظاهرة تعتمد على توفر الخط وتخطيطه: تغيير الخط أو العرض المتاح أو الهوامش أو إعدادات Autofit قد يزيل الاختلاف الظاهر.

## **تعيين نوع Autofit لإطارات النص**

يحدد [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) كيفية تصرف النص عندما يتجاوز حدود حاويته. استخدمه للتحكم فيما إذا كان النص يُصغر، يتجاوز، أو يُعيد تحجيم الشكل تلقائيًا. المثال التالي يُكوّن الشكل لإعادة تحجيمه ليتناسب مع النص ويحفظ النتيجة في "autofit_type.pptx".

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

لحساب عدد الأسطر بعد الالتفاف التلقائي ورؤية كيف يتغيّر عرض النص أو الشكل، راجع [Count Rendered Lines](/slides/ar/java/manage-paragraph/). عدد الأسطر وحده لا يُظهر ما إذا كان النص يتجاوز حاويته أم لا.

## **تعيين تثبيت إطارات النص**

يُعرّف [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) كيفية وضع النص عموديًا داخل الشكل، مثلًا في الأعلى، الوسط، أو الأسفل. المثال التالي يثبت النص في أسفل الشكل الأول ويحفظ النتيجة في "text_anchor.pptx".

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

استخدم [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) و[IParagraphFormat.getTabs](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraphformat/#getTabs--) لتكوين مواضع علامات التبويب في الفقرة. المثال التالي يعيّن الفاصل الافتراضي للتاب إلى 100 نقطة ويضيف علامة تبويب محاذاة إلى اليسار عند 30 نقطة. تؤثر هذه الإعدادات على النص الذي يحتوي على أحرف تبويب.

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

![علامات تبويب الفقرة](paragraph_tabs.png)

## **تعيين لغة التدقيق**

توفر Aspose.Slides الطريقة [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) التي تسمح لك بتعيين لغة التدقيق لجزء نصي. تحدد لغة التدقيق اللغة المستخدمة لتدقيق الإملاء والقواعد النحوية في PowerPoint.

المثال التالي يتطلب "presentation.pptx" يحتوي على مربع نص كأول شكل في الشريحة الأولى وعلى الأقل فقرة واحدة. يستبدل محتويات الفقرة الأولى بـ "1。" ويعيّن SimSun كخط لها، ويُحدد لغة التدقيق الصينية المبسطة (`zh-CN`). يحفظ النتيجة في "proofing_language.pptx":

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

استخدم [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) لتحديد اللغة الافتراضية للنص المُنشأ أثناء تحميل أو إنشاء عرض تقديمي. المثال التالي يُنشئ عرضًا تقديميًا باللغة الإنجليزية الأمريكية كلغة نص افتراضية، يضيف مربع نص، ويطبع `en-US` للجزء النصي الأول.

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

    // تحقق من لغة الجزء الأول.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **تعيين نمط النص الافتراضي**

لتطبيق تنسيق نص افتراضي على مستوى العرض التقديمي، استخدم [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

المثال التالي يعيّن خطًا عريضًا بحجم 14 نقطة كافتراضي للفقرات من المستوى الأعلى في عرض تقديمي جديد ويحفظه في "default_text_style.pptx". يمكن للنص أن يرث هذه الإعدادات ما لم يتجاوزها تنسيق أكثر تحديدًا.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // الحصول على تنسيق الفقرة في المستوى الأعلى.
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

## **استخراج النص بتأثير الأحرف الكبيرة كلها**

في PowerPoint، يؤدي تطبيق تأثير الخط **All Caps** إلى ظهور النص بأحرف كبيرة على الشريحة حتى وإن تم كتابته أصلاً بأحرف صغيرة. عند استرجاع مثل هذا الجزء النصي باستخدام Aspose.Slides، تُعيد المكتبة النص كما أُدخل. لمطابقة النص المعروض، تحقق من [TextCapType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/textcaptype/) وحوِّل السلسلة المسترجعة إلى أحرف كبيرة عندما تكون القيمة `All`.

يتطلب هذا المثال ملف "sample2.pptx" يحتوي على مربع نص كأول شكل في الشريحة الأولى. يحتوي الجزء الأول من الفقرة الأولى على "Hello, Aspose!" مع تطبيق تأثير All Caps، كما هو موضح أدناه.

![تأثير All Caps](all_caps_effect.png)

المثال التالي يوضح كيفية استخراج النص مع تطبيق تأثير **All Caps**:

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

## **الأسئلة الشائعة**

**كيف يمكن تعديل النص في جدول على شريحة؟**

لتعديل النص في جدول على شريحة، استخدم [ITable](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itable/). استعرض الخلايا وقم بتحديث كل خلية عبر [ICell.getTextFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/icell/#getTextFrame--) وتنسيق الفقرات عبر [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraph/#getParagraphFormat--).

**كيف يمكن تطبيق لون تدرج على النص في شريحة PowerPoint؟**

لتطبيق لون تدرج على النص، استخدم [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). عيّن [IFillFormat.setFillType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifillformat/#setFillType-byte-) إلى [FillType.Gradient](https://reference.aspose.com/slides/ar/java/com.aspose.slides/filltype/) وقم بتكوين نقاط التدرج، الاتجاه، والشفافية.