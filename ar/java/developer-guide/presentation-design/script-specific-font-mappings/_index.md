---
title: إدارة خطوط المظهر الخاصة بالنص البرمجي في Java
linktitle: خطوط المظهر الخاصة بالنص البرمجي
type: docs
weight: 15
url: /ar/java/script-specific-font-mappings/
keywords:
- خط خاص بالنص البرمجي
- تعيين خطوط المظهر
- عرض متعدد اللغات
- نظام كتابة
- خط سيريلية
- خط عربي
- خط ياباني
- خط جورجي
- خط ثانا
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "فحص، إضافة، استبدال وإزالة تعيينات خطوط خاصة بالنص البرمجي في سمات PowerPoint باستخدام Aspose.Slides لـ Java."
---
## **نظرة عامة**

يمكن لمظهر العرض اختيار عائلات خطوط مختلفة لأنظمة كتابة مختلفة. يتيح ذلك للنص متعدد اللغات الذي لا يزال يستخدم خطوط المظهر أن يتبع نظام خطوط موحد مع استخدام خطوط مناسبة للسيريلية والعربية واليابانية والجورجية وثانا وغيرها من النصوص.

المظهر يحتوي على [IFontScheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontscheme/) الذي يضم مجموعة خطوط رئيسية، تُستخدم عادةً للعناوين، ومجموعة خطوط فرعية، تُستخدم عادةً للنص الأساسي. بالإضافة إلى إعدادات الخطوط اللاتينية والآسيوية الشرقية، تُظهر كلتا المجموعتين تعيينات من وسوم أنظمة الكتابة إلى أسماء عائلات الخطوط عبر واجهة [IFonts](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifonts/).

تُظهر هذه المقالة كيفية فحص وتعديل تلك التعيينات في مظهر العرض الرئيسي والتحقق من بقاء التغييرات بعد دورة الحفظ وإعادة التحميل.

## **فهم وسوم النص البرمجي**

تستخدم طرق خطوط النص البرمجي وسوم نصية فرعية مكوّنة من أربعة أحرف وفق معيار BCP 47 لتحديد أنظمة الكتابة. القيم الشائعة تشمل:

| وسوم النص البرمجي | نظام الكتابة |
|---|---|
| `Cyrl` | السيريلية |
| `Arab` | العربية |
| `Hans` | الصينية المبسطة |
| `Jpan` | اليابانية |
| `Geor` | الجورجية |
| `Thaa` | ثانا |

تنتمي هذه التعيينات إلى مخطط خطوط المظهر، لا إلى أجزاء النص الفردية. قد يُعرّف العرض تعيينات مختلفة للمجموعتين الرئيسيين والفرعيين، وقد يزيل تعيينات لبعض النصوص البرمجية.

## **الوصول إلى تعيينات خطوط النص البرمجي وفحصها**

استخدم [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getMasterTheme--) للوصول إلى مظهر العرض على مستوى العرض. تُعيد طريقتا [IFontScheme.getMajor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontscheme/#getMajor--) و[IFontScheme.getMinor](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontscheme/#getMinor--) المجموعتين [IFonts](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifonts/).

استدعِ [IFonts.getScriptFontMap](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fonts/#getScriptFontMap--) لاسترجاع جميع التعيينات من مجموعة. للبحث عن نظام كتابة واحد، استدعِ [IFonts.getScriptFont](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) مع وسم النص البرمجي الخاص به. تُعيد `getScriptFont` القيمة `null` عندما لا تُعرّف تلك المجموعة التعيين المطلوب.

## **تعديل التعيينات والتحقق من الاستمرارية**

استخدم [IFonts.setScriptFont](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) لإنشاء تعيين أو استبدال عائلة الخط الحالية. استخدم [IFonts.removeScriptFont](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) لإزالة تعيين.

المثال التالي يقرأ جميع التعيينات الرئيسة والفرعية الحالية، يبحث عن الخط الياباني الرئيسي، يغيّر الخط السيرلي الرئيسي، يزيل تعيين ثانا الفرعي، يحفظ العرض، ثم يعيده للتحقق من كلا التغييرين. لجعل خطوة الإزالة مستقلة عن المظهر الأصلي، ينشئ المثال تعيين ثانا فقط إذا لم يكن مُعرّفًا مسبقًا.

```java
import com.aspose.slides.*;
import com.aspose.slides.Collections.Generic.Dictionary;
import com.aspose.slides.Collections.Generic.KeyValuePair;

Presentation presentation = new Presentation();
try {
    IFontScheme fontScheme = presentation.getMasterTheme().getFontScheme();
    IFonts majorFonts = fontScheme.getMajor();
    IFonts minorFonts = fontScheme.getMinor();

    System.out.println("Existing major mappings:");
    Dictionary.Enumerator<String, String> majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = majorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    System.out.println("Existing minor mappings:");
    Dictionary.Enumerator<String, String> minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = minorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    String japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        System.out.println("No major Japanese font is defined.");
    } else {
        System.out.println("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    IFonts savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    IFonts savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    String savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    String savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if ("Arial".equals(savedCyrillicFont)) {
        System.out.println("The Cyrillic mapping was preserved.");
    } else {
        System.out.println("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        System.out.println("The Thaana mapping removal was preserved.");
    } else {
        System.out.println("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

التحقق يستخدم نفس سلوك `null` كما في الاستعلام العادي: بعد حفظ الإزالة، `getScriptFont("Thaa")` تُعيد `null` للمجموعة الفرعية.

## **تمييز تعيينات المظهر عن إعدادات الخطوط الأخرى**

تشارك تعيينات المظهر الخاصة بالنص البرمجي في اختيار الخط، لكنها تحل مشكلة مختلفة عن التنسيقات النصية المباشرة، والاستبدال، والاحتياطي:

| الآلية | الغرض | تأثير تغيير تعيين المظهر |
|---|---|---|
| تعيين خط المظهر الخاص بالنص البرمجي | يختار خطًا رئيسيًا أو فرعيًا للمظهر لنظام كتابة معين. | يمكن للنص الذي لا يزال يستخدم خط المظهر المقابل أن يتحول إلى العائلة الجديدة المعينة. |
| الخط المعين صراحةً لجزء نص | يثبت عائلة الخط المطلوبة لهذا الجزء بدلًا من الاعتماد على المظهر. | قد يبقى الجزء دون تغيير لأن التنسيق المباشر يتجاوز اختيار المظهر. |
| استبدال الخط | يستبدل الخط المطلوب عندما يكون غير متوفر أو عندما تُطبق قاعدة استبدال. | يعمل بعد طلب الخط؛ لا يعيد تعريف تعيين النص البرمجي في المظهر. |
| احتياطي الخط | يزود بالأحرف التي لا يحتويها الخط المحدد، غالبًا لنطاقات يونيكود معينة. | يملأ النقص في الأحرف؛ لا يغيّر تعيين المظهر المخزن. |

لمزيد من المعلومات حول الآليتين الأخيرتين، راجع [Font Substitution](/slides/ar/java/font-substitution/) و[Fallback Fonts](/slides/ar/java/fallback-font/).

يؤثر تغيير تعيين في [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getMasterTheme--) فقط على المحتوى الذي لا يزال تنسيقه الفعلي يعتمد على ذلك المظهر. قد يرث النص تجاوز مظهر من ماستر أو تخطيط أو شريحة، أو يستخدم خطًا مُعينًا صراحةً. افحص تلك المستويات عندما لا يتبع النتيجة المرئية تعيين المظهر على مستوى العرض.

## **إتاحة الخطوط المعينة والتحقق من النتيجة**

يخزن تعيين النص البرمجي اسم عائلة الخط؛ لا يقوم بتثبيت أو تحميل ملف الخط المقابل. للحصول على عرض وتصدير متسقين، يجب تثبيت كل خط معين في البيئة أو توفيره لـ Aspose.Slides عبر مصدر مخصص مثل [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) أو [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--). راجع [Custom Fonts](/slides/ar/java/custom-font/) للاطلاع على خيارات التحميل المتاحة.

يؤكد التحقق من حفظ التعيين فقط أن تعريف المظهر محفوظ. لا يثبت توفر الخط، أو شمولية الأحرف المطلوبة، أو إنتاج التخطيط المقصود. قم بإنشاء تمثيل نصي لكل نظام كتابة مطلوب إلى صورة أو PDF وافحص النتيجة. سيساعد ذلك في اكتشاف الخطوط المفقودة، أو نقص تغطية الأحرف، أو سلوك الاحتياطي، وتغيّر التخطيط قبل توزيع العرض. راجع [Convert PowerPoint Presentations](/slides/ar/java/convert-powerpoint/) لأمثلة العرض والتصدير.

## **الأسئلة الشائعة**

**ماذا تُعيد `getScriptFont` عندما لا يكون النص البرمجي معينًا؟**

[IFonts.getScriptFont](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) تُعيد `null` عندما لا تكون تعيينات النص البرمجي المطلوبة معرفة في تلك المجموعة الرئيسة أو الفرعية.

**هل يضيف `setScriptFont` تعيينًا ثانيًا عندما يكون النص البرمجي موجودًا بالفعل؟**

لا. [IFonts.setScriptFont](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) ينشئ التعيين إذا كان مفقودًا ويستبدل عائلة الخط المعينة عندما يكون وسم النص البرمجي موجودًا بالفعل.

**لماذا لم يغيّر تغيير تعيين المظهر بعض النصوص؟**

قد يكون للنص خط معين صراحةً، أو يرث مظهرًا مختلفًا عبر تجاوز، أو يتأثر بالاستبدال أو الاحتياطي أثناء العرض. يتحكم تعيين النص البرمجي على مستوى العرض فقط في النص الذي لا يزال تنسيقه الفعلي يشير إلى مجموعة خطوط المظهر تلك.

**هل يكفي الحفظ وإعادة الفتح للتحقق من مخرجات متعددة اللغات؟**

لا. إعادة الفتح تتحقق من بقاء بيانات المظهر. يجب أيضًا عرض نص تمثيلي لكل نظام كتابة مطلوب للتأكد من توفر الخطوط المعينة واحتوائها على الأحرف الضرورية.