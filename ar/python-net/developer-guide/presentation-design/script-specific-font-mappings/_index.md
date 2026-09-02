---
title: إدارة خطوط السمة المحددة حسب النص البرمجي في بايثون
linktitle: خطوط السمة المحددة حسب النص البرمجي
type: docs
weight: 15
url: /ar/python-net/script-specific-font-mappings/
keywords:
- خط محدد حسب النص البرمجي
- تعيين خطوط السمة
- عرض متعدد اللغات
- نظام كتابة
- خط سيريلكي
- خط عربي
- خط ياباني
- خط جورجي
- خط الثانا
- PowerPoint
- عرض
- بايثون
- Aspose.Slides
description: "تفحص وتضيف وتستبدل وتزيل تعيينات الخطوط المحددة حسب النص البرمجي في سمات PowerPoint باستخدام Aspose.Slides للبايثون عبر .NET."
---
## **نظرة عامة**

يمكن لسمة العرض اختيار عائلات خطوط مختلفة لأنظمة كتابة مختلفة. يتيح ذلك للنص متعدد اللغات الذي لا يزال يستخدم خطوط السمة أن يتبع مخطط خطوط منسّق واحد مع استخدام خطوط ملائمة للسيريلية والعربية واليابانية والجورجية والظـآنـا وغيرها من النصوص.

تحتوي سمة العرض على [FontScheme](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/fontscheme/) التي تشمل مجموعة خطوط رئيسية، تُستخدم عادةً للعناوين، ومجموعة خطوط فرعية، تُستخدم عادةً للنص الأساسي. بالإضافة إلى خصائص الخطوط اللاتينية والآسيوية الشرقية، تكشف كلتا المجموعتين عن تعيينات من علامات نظام الكتابة إلى أسماء عائلات الخطوط عبر فئة [Fonts](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fonts/).

توضح هذه المقالة كيفية فحص وتعديل تلك التعيينات في سمة القالب الرئيسي للعرض والتحقق من بقاء التغييرات بعد دورة حفظ وإعادة تحميل.

## **فهم علامات النصوص البرمجية**

تستخدم طرق خطوط النصوص البرمجية تسعات فرعية من أربعة أحرف وفقاً لـ BCP 47 لتحديد أنظمة الكتابة. القيم الشائعة تشمل:

| علامة النص | نظام الكتابة |
|---|---|
| `Cyrl` | السيريلية |
| `Arab` | العربية |
| `Hans` | الصينية المبسطة |
| `Jpan` | اليابانية |
| `Geor` | الجورجية |
| `Thaa` | الظـآنـا |

تنتمي هذه التعيينات إلى مخطط خطوط السمة، لا إلى أجزاء النص الفردية. قد يحدد العرض تعيينات مختلفة للمجموعتين الرئيسيتين والفرعيتين، وقد يترك تعيينات لبعض النصوص البرمجية غير معرفة.

## **الوصول إلى تعيينات خطوط النصوص البرمجية وفحصها**

استخدم [Presentation.master_theme](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/master_theme/) للوصول إلى سمة العرض على مستوى الملف. تعيد الخاصيتان [FontScheme.major](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/fontscheme/major/) و[FontScheme.minor](https://reference.aspose.com/slides/ar/python-net/aspose.slides.theme/fontscheme/minor/) مجموعتي [Fonts](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fonts/) المت对应تين.

استدعِ [Fonts.get_script_font_map](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fonts/get_script_font_map/) لاسترداد جميع التعيينات من مجموعة معينة. للبحث عن نظام كتابة واحد، استدعِ [Fonts.get_script_font](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fonts/get_script_font/) مع علامة النص البرمجي الخاصة به. تُعيد `get_script_font` القيمة `None` عندما لا تُعرّف تلك المجموعة التعيين المطلوب.

## **تعديل التعيينات والتحقق من الاستمرارية**

استخدم [Fonts.set_script_font](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fonts/set_script_font/) لإنشاء تعيين أو استبدال عائلة الخط الحالية. استخدم [Fonts.remove_script_font](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fonts/remove_script_font/) لإزالة تعيين.

يُظهر المثال التالي خطوة بخطوة كيفية قراءة جميع التعيينات الرئيسة والفرعية الحالية، والبحث عن الخط الياباني الرئيس، وتغيير الخط السيريلية الرئيس، وإزالة تعيين الظـآنـا الفرعي، ثم حفظ العرض وإعادة فتحه للتحقق من كلا التغيّرين. لجعل خطوة الإزالة مستقلة عن السمة الأولية، ينشئ المثال تعيينًا للظـآنـا فقط عندما لا يكون مُعرّفاً مسبقاً.

```python
import aspose.slides as slides


def print_script_font_map(label, fonts):
    print(label)
    for mapping in fonts.get_script_font_map():
        print(f"  {mapping.key}: {mapping.value}")


with slides.Presentation() as presentation:
    font_scheme = presentation.master_theme.font_scheme
    major_fonts = font_scheme.major
    minor_fonts = font_scheme.minor

    print_script_font_map("Existing major mappings:", major_fonts)
    print_script_font_map("Existing minor mappings:", minor_fonts)

    japanese_font = major_fonts.get_script_font("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.set_script_font("Cyrl", "Arial")

    if minor_fonts.get_script_font("Thaa") is None:
        minor_fonts.set_script_font("Thaa", "Arial")

    minor_fonts.remove_script_font("Thaa")
    presentation.save("script-font-mappings.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("script-font-mappings.pptx") as saved_presentation:
    saved_major_fonts = saved_presentation.master_theme.font_scheme.major
    saved_minor_fonts = saved_presentation.master_theme.font_scheme.minor
    saved_cyrillic_font = saved_major_fonts.get_script_font("Cyrl")
    saved_thaana_font = saved_minor_fonts.get_script_font("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
```

تستخدم عملية التحقق سلوك `None` نفسه كما في البحث العادي: بعد حفظ عملية الإزالة، تُعيد `get_script_font("Thaa")` القيمة `None` للمجموعة الفرعية.

## **تمييز تعيينات السمة عن إعدادات الخطوط الأخرى**

تشارك تعيينات سمة النص البرمجي في اختيار الخط، لكنها تحل مشكلة مختلفة عن تنسيق النص المباشر، والاستبدال، والاحتياطي:

| الآلية | الغرض | تأثير تغيير تعيين السمة |
|---|---|---|
| تعيين سمة الخط البرمجي المحدد بنص | يختار خط سمة رئيسي أو فرعي لنظام كتابة معين. | يمكن للنص الذي لا يزال يستخدم خط السمة المقابل أن يُحل إلى العائلة الجديدة المعينة. |
| الخط المعين صراحةً لجزء نص | يثبت عائلة الخط المطلوبة على ذلك الجزء بدلاً من الاعتماد على السمة. | قد يبقى الجزء دون تغيير لأن تنسيقه المباشر يتجاوز اختيار السمة. |
| استبدال الخط | يستبدل الخط المطلوب عندما يكون غير متوفر أو عندما تنطبق قاعدة استبدال. | يحدث بعد طلب الخط؛ لا يُعيد تعريف تعيين السمة للنص البرمجي. |
| الاحتياطي الخطّي | يوفّر رموزاً غير موجودة في الخط المختار، غالباً لنطاقات يونيكود محددة. | يملأ الفجوات في الرموز؛ لا يُغيّر تعيين السمة المخزن. |

لمزيد من المعلومات حول الآليتين الأخيرتين، راجع [Font Substitution](/slides/ar/python-net/font-substitution/) و[Fallback Fonts](/slides/ar/python-net/fallback-font/).

تغيّر تعيين داخل [Presentation.master_theme](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/master_theme/) يؤثر فقط على المحتوى الذي لا يزال تنسيقه الفعّال يعتمد على تلك السمة. قد يرث النص تعيين سمة من القالب الرئيسي، أو تخطيط، أو شريحة، أو يستخدم خطًا معينًا صراحةً. افحص تلك المستويات عندما لا يتبع النتيجة الظاهرة تعيين السمة على مستوى العرض.

## **إتاحة الخطوط المعينة والتحقق من النتيجة**

يخزن تعيين النص البرمجي اسم عائلة الخط؛ ولا يقوم بتثبيت أو تحميل ملف الخط المقابل. لضمان العرض والتصدير المتسقين، يجب تثبيت كل خط معين في البيئة أو تزويده إلى Aspose.Slides عبر مصدر مخصص مثل [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontsloader/load_external_fonts/) أو [LoadOptions.document_level_font_sources](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/document_level_font_sources/). راجع [Custom Fonts](/slides/ar/python-net/custom-font/) لمعرفة خيارات التحميل المتاحة.

التحقق من حفظ التعيين يؤكد فقط أن تعريف السمة تم حفظه. لا يثبت أن الخط متاح، أو يحتوي على جميع الرموز المطلوبة، أو ينتج التخطيط المقصود. احرص على تصيير نص ممثل لكل نظام كتابة مطلوب إلى صورة أو PDF وفحص الناتج. يكتشف ذلك الخطوط المفقودة، أو نقص تغطية الرموز، أو سلوك الاحتياطي، أو تغيّر التخطيط قبل توزيع العرض. راجع [Convert PowerPoint Presentations](/slides/ar/python-net/convert-powerpoint/) لأمثلة التصيير والتصدير.

## **الأسئلة الشائعة**

**ماذا تُعيد `get_script_font` عندما لا يكون النص البرمجي معينًا؟**

[Fonts.get_script_font](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fonts/get_script_font/) تُعيد `None` عندما لا يكون تعيين النص البرمجي المطلوب مُعرّفًا في تلك المجموعة الرئيسية أو الفرعية.

**هل يضيف `set_script_font` تعيينًا ثانيًا عندما يكون النص موجودًا بالفعل؟**

لا. [Fonts.set_script_font](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fonts/set_script_font/) تُنشئ التعيين عندما يكون مفقودًا وتستبدل عائلة الخط المعينة عندما تكون علامة النص البرمجي موجودة مسبقًا.

**لماذا لم يُغيّر تعديل سمة النص البرمجي بعض النصوص؟**

قد يكون النص لديه خط معين صراحةً، أو يرث سمة مختلفة عبر تجاوز، أو يتأثر بالاستبدال أو الاحتياطي أثناء التصيير. يتحكم تعيين النص البرمجي على مستوى العرض فقط في النص الذي لا يزال تنسيقه الفعّال يشير إلى مجموعة خطوط السمة تلك.

**هل يكفي حفظ وإعادة فتح العرض للتحقق من مخرجات متعددة اللغات؟**

لا. إعادة الفتح تتحقق فقط من بقاء بيانات السمة. يجب أيضًا تصيير نص ممثل من كل نظام كتابة مطلوب للتأكد من توفر الخطوط المعينة واحتوائها على الرموز اللازمة.