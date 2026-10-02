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
- خاصية الملاءمة التلقائية
- مرساة إطار النص
- تبويب النص
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- العرض التقديمي
- Java
- Aspose.Slides
description: "تنسيق وتنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة Java. تخصيص الخطوط، الألوان، المحاذاة، وأكثر."
---
## **نظرة عامة**

تُظهر هذه المقالة كيفية تنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة Java. وتغطي ألوان الخلفية، والشفافية، وتباعد الأحرف، وخصائص الخط، والدوران، وتباعد الفقرات، وسلوك الملاءمة التلقائية، وتثبيت النص، وإيقافات الفواصل، وإعدادات اللغة.

ما لم يُذكر خلاف ذلك، تستخدم الأمثلة [sample.pptx](sample.pptx). الشكل الأول في الشريحة الأولى هو مربع نص، والفقرة الأولى فيه تحتوي على النص المعروض أدناه. كلا من مؤشرات الشرائح والأشكال تبدأ من الصفر. الأمثلة التي تختار أجزاءً بالخط العريض تستخدم تنسيقًا فعالًا، بما في ذلك تنسيق العريض الموروث:

![Sample text](sample_text.png)

للعثور على النص الحرفي أو مطابقة التعبيرات النمطية وتظليله، راجع [البحث واستبدال النص](/slides/ar/java/search-and-replace-text/).

## **تعيين لون خلفية النص**

استخدم [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) لتعيين لون التظليل الافتراضي لفقرة، أو استخدم [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) لأجزاء النص الفردية.

المثال التالي يحدد تظليلًا رماديًا فاتحًا كافتراضي للفقرة الأولى. ألوان التظليل الصريحة لأجزاء النص الفردية لها أولوية على هذا الافتراضي:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // تعيين لون التظليل للفقرة بأكملها.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

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
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // تعيين لون التظليل لجزء النص.
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

استخدم [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) لتعيين محاذاة الفقرة داخل إطار النص. يمكن أن تكون القيمة وسطية، أو محاذاة إلى اليسار، أو إلى اليمين، أو مبررة، وما إلى ذلك.

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
![الفقرة المحاذاة](aligned_paragraph.png)

## **محاذاة الخطوط داخل السطر**

استخدم [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) لمحاذاة أجزاء النص ذات أحجام الخط المختلفة عموديًا داخل السطر. ينطبق هذا الإعداد على الفقرة بأكملها ويتحكم في المحاذاة داخل كل سطر منها.

المثال المستقل التالي ينشئ أربعة مربعات نص معنونة على شريحة واحدة. كل فقرة تحتوي على نفس النص بحجم 18، 36، و54 نقطة، مع محاذاة خط مختلفة. يستخدم الخط Arial، ويعطل الملاءمة التلقائية والالتفاف، ويحافظ على إطارات النص كبيرة بما يكفي لسطر واحد.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] alignments = { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
    String[] alignmentNames = { "Baseline", "Top", "Center", "Bottom" };
    float[] fontSizes = { 18f, 36f, 54f };

    for (int i = 0; i < alignments.length; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame textFrame = shape.getTextFrame();
        textFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
        textFrame.getTextFrameFormat().setWrapText(NullableBool.False);

        IParagraph label = textFrame.getParagraphs().get_Item(0);
        label.setText(alignmentNames[i]);
        label.getParagraphFormat().setAlignment(TextAlignment.Left);
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Arial"));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

        Paragraph paragraph = new Paragraph();
        paragraph.getParagraphFormat().setFontAlignment(alignments[i]);
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Arial"));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        for (float fontSize : fontSizes) {
            Portion portion = new Portion("Ag ");
            portion.getPortionFormat().setFontHeight(fontSize);
            paragraph.getPortions().add(portion);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    presentation.save("font_alignment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
النتيجة:
![مقارنة بين محاذاة الخط القاعدية، العلوية، الوسطية، والسفلية مع أحجام خطوط مختلطة](font_alignment.png)

تستخدم محاذاة الخط مقاييس الخط، لذا لا يُلزم أن تتطابق حواف الحروف الفردية بدقة. يتضمن المثال حرفًا كبيرًا وحرفًا منخفضًا لإظهار الفارق بين المحاذاة القاعدية والسفلية. توفر الخطوط والاستبدال، الأحرف المستخدمة، واختلاف أحجام الخط يؤثر على النتيجة. أبعاد الإطار، الهوامش، تباعد الأسطر، الالتفاف، والملاءمة التلقائية تؤثر أيضًا على التخطيط؛ استخدم نفس الخطوط وإعدادات التخطيط عند مقارنة الأنماط.

يختلف هذا الإعداد عن [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-)، الذي يتحكم في محاذاة الفقرة أفقياً، وعن [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-)، الذي يحدد موضع كتلة النص عموديًا داخل الشكل. تنسيق الفوقية والتحتي عبر [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setEscapement-float-) يغير موضع الأجزاء الفردية نسبةً إلى القاعدة بدلاً من ضبط محاذاة الخط لسطور الفقرة.

## **تعيين الشفافية للنص**

يتم التحكم في شفافية النص عبر مكوّن ألفا للون المعيّن إلى [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). في الأمثلة أدناه، `alpha = 50` هو قيمة قناة ألفا بنظام ARGB على مقياس 0–255، وليس نسبة شفافية.

يوضح مثال الشيفرة أدناه كيفية تطبيق الشفافية على **الفقرة بأكملها**:
```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // تعيين لون ملء النص إلى اللون الشفاف.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

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
import java.awt.Color;

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

استخدم [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) لتوسيع أو تقليص المسافة بين الأحرف داخل صندوق نص. تضيف الأمثلة 3 نقاط من المسافة؛ القيم السالبة تقمّص النص.

يعرض الشيفرة Java التالية كيفية توسيع تباعد الأحرف في **الفقرة بأكملها**:
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

يوضح مثال الشيفرة أدناه كيفية توسيع تباعد الأحرف في **أجزاء النص ذات الخط العريض**:
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

### **تعطيل الترابط بين الحروف لخطوط معينة**

في بعض الحالات، قد يبدو النص المصدّر بواسطة Aspose.Slides أكثر تضييقًا قليلاً مقارنةً بنفس النص المعروض في PowerPoint. يحدث ذلك لأن PowerPoint قد يتجاهل بيانات الترابط بين الحروف لبعض الخطوط، حتى عندما يحتوي الخط على معلومات ترابط صالحة ويتم تمكين الترابط في إعدادات PowerPoint.

لجعل المخرجات المصدّرة أقرب إلى PowerPoint في مثل هذه الحالات، يمكنك تعطيل الترابط لأجزاء النص التي تستخدم الخط المتأثر. اضبط [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) إلى قيمة أكبر من حجم الخط الفعلي. يتطلب هذا المثال الملف "presentation.pptx" مع مربع نص كأول شكل في الشريحة الأولى. يتحقق من أسماء الخطوط الفعالة، بما في ذلك الخطوط الموروثة، ويعيّن عتبة 100 نقطة للأجزاء التي تستخدم Roboto. هذا يعطّل الترابط للأجزاء المطابقة ذات حجم الخط أقل من 100 نقطة:
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

بالنسبة للنص المطابق الذي يكون حجم خطه أقل من العتبة، يمنع هذا الإعداد الترابط ويمكن أن يساعد في مواءمة عرض Aspose.Slides مع المخرجات البصرية لـ PowerPoint للخطوط المتأثرة بهذا السلوك الخاص بـ PowerPoint.

## **إدارة خصائص خط النص**

يمكن ضبط خصائص الخط على مستوى الفقرة عبر [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--)، أو على أجزاء فردية عبر [IPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/).

المثال التالي يعيّن الخط الافتراضي للفقرة الأولى إلى Times New Roman بحجم 12 نقطة مع تنسيق عريض، مائل، وتسطير منقط. التنسيق الصريح لأجزاء النص الفردية له أولوية على هذه القيم الافتراضية:
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

المثال التالي يطبق Times New Roman بحجم 13 نقطة، وتنسيق مائل، وتسطير منقط على الأجزاء التي يكون تنسيقها الفعلي عريضًا:
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

استخدم [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) لتحديد اتجاه نص مسبق داخل الشكل.

يقوم مثال الشيفرة التالي بتعيين اتجاه النص في الشكل إلى [TextVerticalType.Vertical270](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/)، والذي يدور النص **90 درجة عكس عقارب الساعة**:
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

استخدم [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) لتحديد زاوية دوران مخصصة لـ [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/).

يقوم مثال الشيفرة أدناه بتدوير إطار النص بمقدار 3 درجات مع اتجاه عقارب الساعة داخل الشكل:
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

Aspose.Slides يقدم [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-)، [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-)، و[IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) للتحكم في تباعد الفقرات. تُستخدم هذه الخصائص على النحو التالي:

* استخدم قيمة موجبة لتحديد تباعد السطر كنسبة مئوية من ارتفاع السطر.
* استخدم قيمة سالبة لتحديد تباعد السطر بالنقاط.

المثال التالي يحدد التباعد داخل الفقرة الأولى إلى 200% من ارتفاع السطر (تباعد مزدوج):
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

## **التحكم في كسر السطر**

قواعد كسر سطر الفقرة مفيدة في كتل نصية ضيقة وعروض تقدم تمزج بين النص اللاتيني والنص الآسيوي الشرقي. الطرق التالية تنتمي إلى [IParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/)، لذا تنطبق على الفقرة بأكملها:

- [setLatinLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) يتحكم في قواعد كسر سطر النص اللاتيني. في النص المختلط، قد يؤدي تغييره إلى تعديل أماكن التفاف النص الآسيوي الشرقي والرموز المجاورة.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) يتحكم في قواعد كسر سطر النص الآسيوي الشرقي، بما في ذلك القيود على الأحرف في بداية ونهاية السطر.

هذه القواعد لا تحل محل [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-)، الذي يُفعّل الالتفاف التلقائي داخل إطار النص. إنها تؤثر على التخطيط عند حدوث الالتفاف؛ لا تُدرج أحرف كسر السطر. كسر السطر الصريح يُجبر على سطر جديد داخل الفقرة بغض النظر عن العرض المتاح.

المثال المستقل التالي ينشئ كتلة نصية ضيقة تحتوي على نص صيني ولاتيني. يحدد كلا خيارين لكسر السطر صراحةً ويحفظ الملف "line_breaking.pptx". لتجربة أي قاعدة، غيّر القيمة المقابلة مع إبقاء الإعدادات الأخرى ثابتة. يستخدم المثال خط Arial وSimSun بحجم 24 نقطة مع عرض إطار 160 نقطة وصفر هوامش أفقية لإطار النص. يتم استدعاء [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) بـ [TextAutofitType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textautofittype/) بحيث يظل حجم النص وأبعاد الإطار ثابتين.
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

## **التحكم في علامات الترقيم المتدلية**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) يسمح للعلامات المسموح بها بالتمدد خارج الحد الأيمن لسطر النص بدلاً من احتلال السطر التالي. ينطبق على الفقرة بأكملها ويختلف عن المسافة المتدلية.

المثال المستقل التالي يفعّل علامات الترقيم المتدلية في إطار نص عرضة 100 نقطة ويحفظ الملف "hanging_punctuation.pptx". مع خط Arial بحجم 24 نقطة وصفر هوامش أفقية لإطار النص، تبقى النقطة النهائية بعد كلمة "sentence" وتتمد خارج حد النص الأيمن. اضبط الخاصية إلى [NullableBool.False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) للمقارنة: مع هذه الإعدادات، تحتل النقطة سطرًا منفصلًا. يتم تمكين الالتفاف وتعطيل الملاءمة التلقائية للحفاظ على عرض ثابت.
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

ليس كل علامة ترقيم يمكن أن تتدلى. [شروط الخط والتخطيط الموضحة أعلاه](#control-line-breaking) تنطبق أيضًا على هذه المقارنة: تغيير الخط أو العرض المتاح أو الهوامش أو إعدادات الملاءمة التلقائية يمكن أن يزيل الفارق المرئي.

## **تعيين نوع الملاءمة التلقائية لإطارات النص**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) يحدد سلوك النص عندما يتجاوز حدود حاويته. استخدمه للتحكم فيما إذا كان النص يتقلص، أو يفيض، أو يعيد تحجيم الشكل تلقائيًا. المثال التالي يضبط الشكل لإعادة التحجيم ليتناسب مع نصه ويحفظ النتيجة في "autofit_type.pptx".
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

لحساب عدد الأسطر بعد الالتفاف التلقائي ومعرفة كيف يغيّر عرض النص أو الشكل النتيجة، راجع [Count Rendered Lines](/slides/ar/java/manage-paragraph/). عدد الأسطر وحده لا يُظهر ما إذا كان النص يفيض عن حاويته.

## **تعيين مرساة إطارات النص**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) يحدد كيفية تموضع النص عموديًا داخل الشكل، مثل أعلى، وسط، أو أسفل. المثال التالي يرسخ النص إلى أسفل الشكل الأول ويحفظ النتيجة في "text_anchor.pptx".
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

استخدم [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) و[IParagraphFormat.getTabs](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getTabs--) لضبط إيقافات التبويب في فقرة. المثال التالي يعيّن الفاصل الافتراضي للتبويب إلى 100 نقطة ويضيف إيقاف تبويب محاذاة إلى اليسار عند 30 نقطة. تؤثر هذه الإعدادات على النص الذي يحتوي على أحرف تبويب.
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
![إيقافات الفقرة](paragraph_tabs.png)

## **تعيين لغة التدقيق**

توفر Aspose.Slides الخاصية [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-)، التي تسمح لك بتعيين لغة التدقيق لجزء نص. تحدد لغة التدقيق اللغة المستخدمة لتدقيق الإملاء والنحو في PowerPoint.

المثال التالي يتطلب ملف "presentation.pptx" مع مربع نص كأول شكل في الشريحة الأولى وعلى الأقل فقرة واحدة. يستبدل محتويات الفقرة الأولى بـ "1。"، ويعيّن SimSun كخط لها، ويحدد لغة التدقيق الصينية المبسطة (`zh-CN`). يحفظ النتيجة في "proofing_language.pptx":
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

استخدم [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) لتحديد اللغة الافتراضية للنص عند تحميل أو إنشاء عرض تقديمي. المثال التالي ينشئ عرضًا تقديميًا مع اللغة الإنجليزية الأمريكية كلغة نص افتراضية، يضيف مربع نص، ويطبع `en-US` لجزء النص الأول.
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

لتطبيق تنسيق النص الافتراضي على مستوى العرض، استخدم [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

المثال التالي يعيّن خطًا عريضًا بحجم 14 نقطة كافتراضي للفقرات العليا في عرض تقديمي جديد ويحفظه في "default_text_style.pptx`. يمكن للنص أن يرث هذه القيم الافتراضية ما لم يتجاوزها تنسيق أكثر تحديدًا.
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // احصل على تنسيق الفقرة من المستوى الأعلى.
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

## **استخراج النص مع تأثير الحروف الكبيرة**

في PowerPoint، تطبيق تأثير **All Caps** يجعل النص يظهر بأحرف كبيرة على الشريحة حتى لو تم كتابته أصلاً بأحرف صغيرة. عند استرجاع مثل هذا الجزء النصي باستخدام Aspose.Slides، تُعيد المكتبة النص كما تم إدخاله. لمطابقة النص المعروض، افحص [TextCapType](https://reference.aspose.com/slides/java/com.aspose.slides/textcaptype/) وحول السلسلة المسترجعة إلى أحرف كبيرة إذا كان القيمة `All`.

هذا المثال يتطلب ملف "sample2.pptx" مع مربع نص كأول شكل في الشريحة الأولى. يحتوي الجزء الأول من الفقرة الأولى على "Hello, Aspose!" مع تطبيق تأثير All Caps، كما هو موضح أدناه.
![تأثير الحروف الكبيرة](all_caps_effect.png)

يوضح مثال الشيفرة أدناه كيفية استخراج النص مع تطبيق تأثير **All Caps**:
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

**كيف يمكنني تعديل النص في جدول على شريحة؟**

لتعديل النص في جدول على شريحة، استخدم [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/). قم بالتكرار عبر الخلايا وحدث كل خلية عبر [ICell.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) وتنسيق الفقرات عبر [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getParagraphFormat--).

**كيف يمكنني تطبيق لون تدرج على النص في شريحة PowerPoint؟**

لتطبيق لون تدرج على النص، استخدم [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). اضبط [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) إلى [FillType.Gradient](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) وقم بإعداد نقاط التدرج، الاتجاه، والشفافية.