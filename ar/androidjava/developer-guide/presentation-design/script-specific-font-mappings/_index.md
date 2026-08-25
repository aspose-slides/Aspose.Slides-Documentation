---
title: إدارة خطوط السمة الخاصة بنظام الكتابة على Android
linktitle: خطوط السمة الخاصة بنظام الكتابة
type: docs
weight: 15
url: /ar/androidjava/script-specific-font-mappings/
keywords:
- خط خاص بنظام الكتابة
- تحويل خط السمة
- عرض متعدد اللغات
- نظام كتابة
- خط سيريلي
- خط عربي
- خط ياباني
- خط جورجي
- خط ثانا
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "فحص، إضافة، استبدال، وإزالة تحويلات خطوط خاصة بنظام الكتابة في سمات PowerPoint باستخدام Aspose.Slides لأندرويد عبر Java."
---
## **نظرة عامة**

يمكن أن يختار سمة العرض خطوطًا مختلفة لأنظمة كتابة مختلفة. يتيح ذلك نصًا متعدد اللغات لا يزال يستخدم خطوط السمة ليُتبع مخططًا موحدًا للخطوط مع استخدام خطوط مناسبة للسيريلية والعربية واليابانية والجورجية والثانا وغيرها من النصوص.

تحتوي السمة على [IFontScheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifontscheme/) التي تضم مجموعة خطوط رئيسية تُستخدم عادةً للعناوين، ومجموعة خطوط فرعية تُستخدم عادةً للنص الأساسي. بالإضافة إلى إعدادات الخطوط اللاتينية والآسيوية الشرقية، تُظهر كلتا المجموعتين تحويلات من علامات نظام الكتابة إلى أسماء عائلات الخطوط عبر واجهة [IFonts](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifonts/).

توضح هذه المقالة كيفية فحص وتعديل تلك التحويلات في سمة العرض الرئيسية والتحقق من بقاء التغييرات بعد حفظ وإعادة تحميل الملف.

## **فهم علامات النص**

تستخدم طرق خط النص علامات نصية من أربعة أحرف وفق معيار BCP 47 لتحديد أنظمة الكتابة. تشمل القيم الشائعة:

| علامة النص | نظام الكتابة |
|---|---|
| `Cyrl` | السيريلية |
| `Arab` | العربية |
| `Hans` | الصينية المبسطة |
| `Jpan` | اليابانية |
| `Geor` | الجورجية |
| `Thaa` | الثانا |

تنتمي هذه التحويلات إلى مخطط خطوط السمة، لا إلى أجزاء النص الفردية. قد تُعرّف العرض تحويلات مختلفة للمجموعتين الرئيسة والفرعية، وقد تُغفل تحويلات لبعض النصوص.

## **الوصول إلى وتحليل تحويلات خطوط النص**

استخدم [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getMasterTheme--) للوصول إلى سمة العرض على مستوى العرض. تُعيد الطريقتان [IFontScheme.getMajor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifontscheme/#getMajor--) و[IFontScheme.getMinor](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifontscheme/#getMinor--) مجموعتي [IFonts](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifonts/) المتعلقتين.

اتصل بـ [IFonts.getScriptFontMap](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fonts/#getScriptFontMap--) لاسترجاع جميع التحويلات من مجموعة معينة. للبحث عن نظام كتابة محدد، استدعِ [IFonts.getScriptFont](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) مع علامته. تُعيد `getScriptFont` القيمة `null` عندما لا تُعرّف تلك المجموعة التحويل المطلوب.

## **تعديل التحويلات والتحقق من الاستمرارية**

استخدم [IFonts.setScriptFont](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) لإنشاء تحويل أو استبدال عائلة الخط الحالية. استخدم [IFonts.removeScriptFont](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) لإزالة تحويل.

تقرأ المثال التالي من الطرف إلى الطرف جميع التحويلات الرئيسية والفرعية الحالية، يبحث عن الخط الياباني الرئيسي، يغيّر الخط السيريلّي الرئيسي، يزيل تحويل الثانا الفرعي، يحفظ العرض، ثم يفتحه مرة أخرى للتحقق من كلا التغيّرين. لجعل خطوة الإزالة مستقلة عن السمة الأصلية، ينشئ المثال تحويل الثانا فقط عندما لا يكون معرفًا مسبقًا.

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

يستخدم التحقق نفس سلوك `null` كما في البحث العادي: بعد حفظ الإزالة، تُعيد `getScriptFont("Thaa")` القيمة `null` للمجموعة الفرعية.

## **تمييز تحويلات السمة عن إعدادات الخطوط الأخرى**

تشارك تحويلات السمة الخاصة بالنص في اختيار الخط، لكنها تحل مشكلة مختلفة عن تنسيق النص المباشر، والاستبدال، والاحتياطي:

| الآلية | الغرض | أثر تغيير تحويل السمة |
|---|---|---|
| تحويل سمة الخط الخاص بالنص | يختار خط سمة رئيسي أو فرعي لنظام كتابة معين. | يمكن للنص الذي لا يزال يستخدم خط السمة المقابل أن يتحوّل إلى العائلة الجديدة المُحددة. |
| الخط المحدد صراحةً لقسم من النص | يثبت عائلة الخط المطلوبة على ذلك الجزء بدلاً من الاعتماد على السمة. | قد يبقى الجزء دون تغيير لأن تنسيقه المباشر يتجاوز اختيار السمة. |
| استبدال الخط | يستبدل الخط المطلوب عندما يكون غير متاح أو عندما تنطبق قاعدة استبدال. | يحدث بعد طلب الخط؛ ولا يُعيد تعريف تحويل السمة الخاص بالنص. |
| الخط الاحتياطي | يزوّد بالرموز التي لا يحتويها الخط المختار، غالبًا لنطاقات يونيكود محددة. | يملأ الفجوات في الرموز؛ ولا يغيّر تحويل السمة المخزن. |

لمزيد من المعلومات حول الآليتين الأخيرتين، راجع [Font Substitution](/slides/ar/androidjava/font-substitution/) و[Fallback Fonts](/slides/ar/androidjava/fallback-font/).

يؤثر تغيير تحويل في [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getMasterTheme--) فقط على المحتوى الذي لا يزال تنسيقه الفعّال يعتمد على تلك السمة. قد يرث النص بدلًا من ذلك تجاوز سمة من ماستَر، تخطيط، أو شريحة، أو يستخدم خطًا مُعيّنًا صراحةً. افحص تلك المستويات عندما لا يتبع النتيجة المرئية تحويل السمة على مستوى العرض.

## **إتاحة الخطوط المُحوّلة والتحقق من النتيجة**

يخزن تحويل النص اسم عائلة الخط؛ لا يقوم بتثبيت أو تحميل ملف الخط المقابل. لضمان عرض وتصدير متسق، يجب تثبيت كل خط مُحوّل في البيئة أو توفيره إلى Aspose.Slides عبر مصدر مخصص مثل [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) أو [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--). راجع [Custom Fonts](/slides/ar/androidjava/custom-font/) للتعرف على خيارات التحميل المتاحة.

يؤكد التحقق من التخزين فقط أن تعريف السمة تم حفظه. لا يثبت أن الخط متاح، أو يحتوي على جميع الرموز المطلوبة، أو ينتج التخطيط المقصود. احرص على تصيير نص تمثيلي لكل نظام كتابة مطلوب إلى صورة أو PDF وافحص الناتج. يكتشف ذلك الخطوط المفقودة، ونقص الرموز، وسلوك الاحتياطي، وتغيّر التخطيط قبل توزيع العرض. راجع [Convert PowerPoint Presentations](/slides/ar/androidjava/convert-powerpoint/) لأمثلة التصيير والتصدير.

## **الأسئلة الشائعة**

**ماذا تعيد الدالة `getScriptFont` عندما لا يكون النص مُحوّلًا؟**

تُعيد [IFonts.getScriptFont](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) القيمة `null` عندما لا يكون تحويل النص المطلوب مُعرّفًا في تلك المجموعة الرئيسة أو الفرعية.

**هل يضيف `setScriptFont` تحويلًا ثانيًا عندما يكون النص موجودًا بالفعل؟**

لا. يُنشئ [IFonts.setScriptFont](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) التحويل عندما يكون مفقودًا ويستبدل عائلة الخط المُحوّلة عندما تكون علامة النص موجودة مسبقًا.

**لماذا لم يُغيّر تعديل تحويل السمة بعض النصوص؟**

قد يكون النص قد عُيّن له خط صراحةً، أو يرث سمة مختلفة عبر تجاوز، أو يتأثر بالاستبدال أو الاحتياطي أثناء التصيير. يتحكم تحويل النص على مستوى العرض فقط في النص الذي لا يزال تنسيقه الفعّال يشير إلى مجموعة خطوط السمة تلك.

**هل حفظ وإعادة فتح العرض يكفي للتحقق من المخرجات متعددة اللغات؟**

لا. إن إعادة الفتح تُثبت بقاء بيانات السمة. يجب أيضًا تصيير نص تمثيلي من كل نظام كتابة مطلوب للتأكد من توفر الخطوط المُحوّلة واحتوائها على الرموز الضرورية.