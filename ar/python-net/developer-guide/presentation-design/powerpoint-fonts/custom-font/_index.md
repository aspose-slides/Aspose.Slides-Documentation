---
title: تخصيص خطوط PowerPoint في Python
linktitle: خط مخصص
type: docs
weight: 20
url: /ar/python-net/custom-font/
keywords:
- خط
- خط مخصص
- خط خارجي
- تحميل الخط
- إدارة الخطوط
- مجلد الخطوط
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تضمين الخطوط المخصصة في شرائح PowerPoint باستخدام Aspose.Slides للغة Python عبر .NET للحفاظ على عروضك التقديمية واضحة ومتسقة على أي جهاز."
---
## **نظرة عامة**

يتيح لك Aspose.Slides for Python توفير خطوط مخصصة في وقت التشغيل بحيث يتم عرض العروض التقديمية بشكل صحيح حتى في حال عدم تثبيت الخطوط المطلوبة على نظام المضيف. أثناء التصدير إلى PDF أو الصور، يمكنك توفير مجلدات الخطوط أو بيانات الخط في الذاكرة للحفاظ على تخطيط النص، قياسات الحروف، والطباعة. هذا يجعل عملية العرض على الخادم قابلة للتوقع عبر بيئات مختلفة، يزيل تبعيات الخط على مستوى نظام التشغيل، ويمنع حالات الرجوع غير المرغوب فيها أو إعادة تدفق النص. توضح هذه المقالة كيفية تسجيل مصادر الخطوط.

يمكن لسمة العرض الإشارة إلى عائلات خطوط مختلفة لأنظمة الكتابة الفردية. هذه التعيينات تقوم بتخزين أسماء الخطوط ولكن لا تقوم بتثبيت أو تحميل ملفات الخط. راجع [خطوط السمة الخاصة بالنص](/slides/ar/python-net/script-specific-font-mappings/) لإدارة هذه التعيينات، واستخدم خيارات التحميل أدناه لجعل الخطوط المشار إليها متاحة لعرض متسق.

يتيح لك Aspose.Slides تحميل الخطوط التالية باستخدام الطريقتين `load_external_font` و `load_external_fonts` من فئة [FontsLoader](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontsloader/) :

- خطوط TrueType (.ttf) و TrueType Collection (.ttc). راجع [TrueType](https://en.wikipedia.org/wiki/TrueType).
- خطوط OpenType (.otf). راجع [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **تحميل الخطوط المخصصة**

يتيح لك Aspose.Slides تحميل الخطوط المستخدمة في عرض تقديمي دون تثبيتها على النظام. يؤثر ذلك على مخرجات التصدير—مثل PDF، الصور، وغيرها من الصيغ المدعومة—بحيث تبدو المستندات الناتجة متسقة عبر البيئات. يتم تحميل الخطوط من أدلة مخصصة.

1. حدد مجلدًا أو أكثر يحتوي على ملفات الخط.
2. استدعِ الطريقة الساكنة [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontsloader/load_external_fonts/) لتحميل الخطوط من تلك المجلدات.
3. حمّل واعرض/صدّر العرض التقديمي.
1. استدعِ [FontsLoader.clear_cache](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontsloader/clear_cache/) لمسح ذاكرة التخزين المؤقت للخطوط.

المثال البرمجي التالي يوضح عملية تحميل الخطوط:

```py
import aspose.slides as slides

# حدد المجلدات التي تحتوي على ملفات الخطوط المخصصة.
font_folders = ["fonts", "external_fonts"]

# قم بتحميل الخطوط المخصصة من المجلدات المحددة.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # اعرض/صدّر العرض التقديمي (مثلاً إلى PDF أو صور أو صيغ أخرى) باستخدام الخطوط التي تم تحميلها.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# امسح ذاكرة التخزين المؤقت للخطوط بعد الانتهاء من العمل.
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="ملاحظة" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontsloader/load_external_fonts/) يضيف مجلدات إضافية إلى مسارات بحث الخطوط، لكنه لا يغيّر ترتيب تهيئة الخطوط. يتم تهيئة الخطوط بالترتيب التالي:

1. مسار الخطوط الافتراضي لنظام التشغيل.
1. المسارات التي تم تحميلها عبر [FontsLoader](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontsloader/).
{{%/alert %}}

## **الحصول على مجلد الخطوط المخصصة**

يوفر Aspose.Slides الطريقة `get_font_folders` لاسترجاع مجلدات الخطوط. وتعيد كلًا من المجلدات المضافة عبر `load_external_fonts` ومجلدات الخطوط النظامية.

يعرض هذا الكود بايثون كيفية استخدام `get_font_folders`:

```python
import aspose.slides as slides

# هذه العملية تُرجع المجلدات التي تم فحصها بحثًا عن ملفات الخطوط.
# تشمل هذه المجلدات المجلدات التي أضيفت عبر طريقة load_external_fonts ومجلدات الخطوط النظامية.
font_folders = slides.FontsLoader.get_font_folders()
```

## **تحديد الخطوط المخصصة لعرض تقديمي**

يوفر Aspose.Slides الخاصية `document_level_font_sources` التي تسمح لك بتحديد الخطوط الخارجية لاستخدامها مع عرض تقديمي.

يعرض المثال البرمجي التالي بايثون كيفية استخدام `document_level_font_sources`:

```python
import aspose.slides as slides

with open("CustomFont1.ttf", "br") as font1_stream:
    font1_data = font1_stream.read()
    
with open("CustomFont2.ttf", "br") as font2_stream:
    font2_data = font2_stream.read()

load_options = slides.LoadOptions()
load_options.document_level_font_sources.font_folders = ["assets\\fonts", "global\\fonts"] 
load_options.document_level_font_sources.memory_fonts = [font1_data, font2_data]

with slides.Presentation("Fonts.pptx", load_options) as presentation:
    # ...
    # العمل مع العرض التقديمي.
    # CustomFont1, CustomFont2، والخطوط من المجلدات assets\fonts و global\fonts (ومجلداتها الفرعية) متاحة للعرض التقديمي.
    # ...
    print(len(presentation.slides))
```

## **تحميل الخطوط الخارجية من بيانات ثنائية**

يوفر Aspose.Slides الطريقة `load_external_font` لتحميل الخطوط الخارجية من بيانات ثنائية.

يوضح المثال البرمجي التالي بايثون كيفية تحميل خط من مصفوفة بايت:

```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# تحميل الخطوط الخارجية من مصفوفات البايت.
slides.FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with slides.Presentation() as presentation:
        # الخطوط الخارجية متاحة طوال عمر مثيل هذا العرض التقديمي.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```

## **الأسئلة الشائعة**

### هل تؤثر الخطوط المخصصة على التصدير إلى جميع الصيغ (PDF، PNG، SVG، HTML)؟

نعم. يتم استخدام الخطوط المتصلة بواسطة المُعالج عبر جميع صيغ التصدير.

### هل يتم تضمين الخطوط المخصصة تلقائيًا في ملف PPTX الناتج؟

لا. تسجيل خط للاستخدام في العرض ليس هو نفسه تضمينه في ملف PPTX. إذا احتجت إلى وجود الخط داخل ملف العرض التقديمي، يجب عليك استخدام [ميزات التضمين](/slides/ar/python-net/embedded-font/).

### هل يمكنني التحكم في سلوك fallback عندما يفتقر الخط المخصص إلى بعض الحروف؟

نعم. يمكنك تكوين [استبدال الخط](/slides/ar/python-net/font-substitution/)، [قواعد الاستبدال](/slides/ar/python-net/font-replacement/)، و[مجموعة الخطوط الاحتياطية](/slides/ar/python-net/fallback-font/) لتحديد الخط الذي يُستخدم عندما تكون الحرف المطلوب غير موجود.

### هل يمكنني استخدام الخطوط في حاويات Linux/Docker دون تثبيتها على مستوى النظام؟

نعم. يمكنك الإشارة إلى مجلدات الخطوط الخاصة بك أو تحميل الخطوط من مصفوفات البايت. هذا يزيل أي اعتماد على دلائل خطوط النظام في صورة الحاوية.

### ماذا عن الترخيص—هل يمكنني تضمين أي خط مخصص دون قيود؟

أنت المسؤول عن الالتزام بترخيص الخطوط. تختلف الشروط؛ بعض التراخيص تحظر التضمين أو الاستخدام التجاري. يجب دائمًا مراجعة اتفاقية ترخيص المستخدم النهائي (EULA) للخط قبل توزيع المخرجات.