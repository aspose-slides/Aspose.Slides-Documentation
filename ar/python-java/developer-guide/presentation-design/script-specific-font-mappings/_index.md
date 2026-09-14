---
title: إدارة خطوط المظهر الخاصة بالسكريبت في Python عبر Java
linktitle: خطوط المظهر الخاصة بالسكريبت
type: docs
weight: 15
url: /ar/python-java/script-specific-font-mappings/
keywords:
- خط سكريبت خاص
- تعيين خط المظهر
- عرض متعدد اللغات
- نظام كتابة
- خط سيريلية
- خط عربي
- خط ياباني
- خط جورجي
- خط ثانا
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "فحص، إضافة، استبدال وإزالة تحويلات خطوط خاصة بالسكريبت في سمات PowerPoint باستخدام Aspose.Slides لPython عبر Java."
---
## **نظرة عامة**

يمكن لمظهر العرض اختيار عائلات خطوط مختلفة لأنظمة كتابة مختلفة. يتيح ذلك للنص متعدد اللغات الذي لا يزال يستخدم خطوط المظهر اتباع مخطط خطوط منسق واحد مع استخدام خطوط مناسبة لسيريلية، العربية، اليابانية، الجورجية، الثانا، وغيرها من الأنظمة.

يحتوي المظهر الـ[FontScheme](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontscheme/) على مجموعة خطوط رئيسية، تُستخدم عادةً للعناوين، ومجموعة خطوط فرعية، تُستخدم عادةً للنص الرئيسي. بالإضافة إلى إعدادات الخطوط اللاتينية والآسيوية الشرقية، تُظهر كلتا المجموعتين تحويلات من وسوم نظام الكتابة إلى أسماء عائلات الخطوط عبر فئة الـ[Fonts](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fonts/).

توضح هذه المقالة كيفية فحص وتعديل تلك التحويلات في المظهر الرئيسي للعرض والتحقق من بقاء التغييرات بعد دورة الحفظ وإعادة التحميل.

## **فهم وسوم النص**

تستخدم طرق خطوط النص وسوم فرعية من أربعة أحرف وفقًا لمعيار BCP 47 لتحديد أنظمة الكتابة. تشمل القيم الشائعة ما يلي:

| وسمة النص | نظام الكتابة |
|---|---|
| `Cyrl` | السيريلية |
| `Arab` | العربية |
| `Hans` | الصينية المبسطة |
| `Jpan` | اليابانية |
| `Geor` | الجورجية |
| `Thaa` | الثانا |

تنتمي هذه التحويلات إلى مخطط خطوط المظهر، لا إلى أجزاء النص الفردية. قد يحدد العرض تحويلات مختلفة للمجموعتين الرئيسيتين والفرعيتين، وقد يحذف تحويلات لبعض النصوص.

## **الوصول إلى فحص تحويلات خطوط النص**

استخدم [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getMasterTheme) للوصول إلى المظهر على مستوى العرض. تُرجع طُرُق [FontScheme.getMajor](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontscheme/#getMajor) و[FontScheme.getMinor](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontscheme/#getMinor) مجموعة الـ[Fonts] الاثنين.

استدعِ [Fonts.getScriptFontMap](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fonts/#getScriptFontMap) لاسترداد جميع التحويلات من مجموعة. للبحث عن نظام كتابة واحد، استدعِ [Fonts.getScriptFont](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fonts/#getScriptFont) باستخدام وسمة النص الخاص به. تُعيد getScriptFont القيمة None عندما لا تعرف تلك المجموعة التحويل المطلوب.

## **تعديل التحويلات والتحقق من الاستمرارية**

استخدم [Fonts.setScriptFont](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fonts/#setScriptFont) لإنشاء تحويل أو استبدال عائلة الخط الحالية. استخدم [Fonts.removeScriptFont](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fonts/#removeScriptFont) لإزالة تحويل.

المثال المتكامل التالي يقرأ جميع التحويلات الرئيسية والفرعية الحالية، يبحث عن الخط الياباني الرئيسي، يغيّر الخط السيريلي الرئيسي، يزيل تحويل الثانا الفرعي، يحفظ العرض، ويعيد فتحه للتحقق من كلا التغييرين. لجعل خطوة الإزالة مستقلة عن المظهر الأولي، ينشئ المثال تحويل الثانا فقط إذا لم يكن معرفًا مسبقًا.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    font_scheme = presentation.getMasterTheme().getFontScheme()
    major_fonts = font_scheme.getMajor()
    minor_fonts = font_scheme.getMinor()

    print("Existing major mappings:")
    major_mappings = major_fonts.getScriptFontMap().iterator()
    while major_mappings.hasNext():
        mapping = major_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    print("Existing minor mappings:")
    minor_mappings = minor_fonts.getScriptFontMap().iterator()
    while minor_mappings.hasNext():
        mapping = minor_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    japanese_font = major_fonts.getScriptFont("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.setScriptFont("Cyrl", "Arial")

    if minor_fonts.getScriptFont("Thaa") is None:
        minor_fonts.setScriptFont("Thaa", "Arial")

    minor_fonts.removeScriptFont("Thaa")
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("script-font-mappings.pptx")
try:
    saved_major_fonts = saved_presentation.getMasterTheme().getFontScheme().getMajor()
    saved_minor_fonts = saved_presentation.getMasterTheme().getFontScheme().getMinor()
    saved_cyrillic_font = saved_major_fonts.getScriptFont("Cyrl")
    saved_thaana_font = saved_minor_fonts.getScriptFont("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
finally:
    saved_presentation.dispose()
```

يستخدم التحقق نفس سلوك `None` كبحث عادي: بعد حفظ الإزالة، تُعيد `getScriptFont("Thaa")` القيمة `None` للمجموعة الفرعية.

## **تمييز تحويلات المظهر عن إعدادات الخط الأخرى**

تشارك تحويلات المظهر الخاصة بالسكريبت في اختيار الخط، لكنها تحل مشكلة مختلفة عن تنسيق النص المباشر، والاستبدال، والاحتياط:

| آلية | الغرض | تأثير تغيير تحويل المظهر |
|---|---|---|
| تحويل خط المظهر الخاص بالسكريبت | يختار خطًا رئيسيًا أو فرعيًا للمظهر لنظام كتابة. | النص الذي لا يزال يستخدم خط المظهر المقابل يمكنه أن يتحول إلى العائلة الجديدة. |
| خط مخصص صراحةً لجزء من النص | يثبت عائلة الخط المطلوبة لهذا الجزء بدلًا من الاعتماد على المظهر. | قد يظل الجزء دون تغيير لأن تنسيقه المباشر يتجاوز اختيار المظهر. |
| استبدال الخط | يستبدل الخط المطلوب عندما لا يكون متاحًا أو عندما تنطبق قاعدة استبدال. | يعمل بعد طلب الخط؛ لا يعيد تعريف تحويل سكريبت المظهر. |
| الخط الاحتياطي | يوفر رموزًا لا يحتويها الخط المحدد، غالبًا لنطاقات يونيكود معينة. | يملأ الفجوات في الرموز؛ لا يغيّر تحويل المظهر المخزن. |

لمزيد من المعلومات حول الآليتين الأخيرتين، راجع [Font Substitution](/slides/ar/python-java/font-substitution/) و[Fallback Fonts](/slides/ar/python-java/fallback-font/).

تغيير تحويل في [Presentation.getMasterTheme](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getMasterTheme) يؤثر فقط على المحتوى الذي لا يزال تنسيقه الفعلي يعتمد على ذلك المظهر. يمكن للنص بدلاً من ذلك أن يرث تجاوز المظهر من رئيس، أو تخطيط، أو شريحة، أو يستخدم خطًا مخصصًا صراحةً. افحص هذه المستويات عندما لا يتبع النتيجة المرئية تحويل المظهر على مستوى العرض.

## **جعل الخطوط المحوّلة متاحة والتحقق من النتيجة**

يخزن تحويل السكريبت اسم عائلة الخط؛ ولا يقوم بتثبيت أو تحميل ملف الخط المقابل. للحصول على عرض وتصدير متسقين، يجب تثبيت كل خط محوّل في البيئة أو توفيره إلى Aspose.Slides عبر مصدر مخصص مثل [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsloader/#loadExternalFonts) أو [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources). راجع [Custom Fonts](/slides/ar/python-java/custom-font/) للخيارات المتاحة للتحميل.

التأكد من حفظ التحويل يؤكد فقط أن تعريف المظهر تم الحفاظ عليه. ولا يثبت أن الخط متاح أو يحتوي على جميع الرموز المطلوبة أو ينتج التخطيط المتوقع. قم بعرض نص تمثيلي لكل نظام كتابة مطلوب إلى صورة أو PDF وافحص النتيجة. يساعد ذلك في اكتشاف الخطوط المفقودة، أو نقص التغطية الرمزية، أو سلوك الاحتياطي، وتغييرات التخطيط قبل توزيع العرض. راجع [Convert PowerPoint Presentations](/slides/ar/python-java/convert-powerpoint/) لأمثلة العرض والتصدير.

## **الأسئلة المتكررة**

**ماذا تُعيد `getScriptFont` عندما لا يكون هناك تحويل للسكريبت؟**

[Fonts.getScriptFont](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fonts/#getScriptFont) تُعيد `None` عندما لا يكون تحويل السكريبت المطلوب معرفًا في تلك المجموعة الرئيسية أو الفرعية.

**هل يضيف `setScriptFont` تحويلًا ثانيًا عندما يكون السكريبت موجودًا بالفعل؟**

لا. [Fonts.setScriptFont](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fonts/#setScriptFont) تُنشئ التحويل عندما يكون مفقودًا وتستبدل عائلة الخط المحوّلة عندما تكون وسمة السكريبت نفسها موجودة بالفعل.

**لماذا لم يُغيّر تغيير تحويل المظهر بعض النصوص؟**

قد يكون للنص خط مخصص صراحةً، أو يرث مظهرًا مختلفًا عبر تجاوز، أو يتأثر بالاستبدال أو الاحتياطي أثناء العرض. يتحكم تحويل السكريبت على مستوى العرض فقط في النصوص التي لا يزال تنسيقها الفعلي يشير إلى مجموعة خطوط المظهر تلك.

**هل يكفي حفظ وإعادة الفتح للتحقق من مخرجات متعددة اللغات؟**

لا. إعادة الفتح تتحقق من بقاء بيانات المظهر. كما يجب عرض نص تمثيلي من كل نظام كتابة مطلوب لتأكيد أن الخطوط المحوّلة متاحة وتحتوي على الرموز اللازمة.