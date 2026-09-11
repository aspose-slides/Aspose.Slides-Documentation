---
title: تخصيص خطوط PowerPoint في Python عبر Java
linktitle: خط مخصص
type: docs
weight: 20
url: /ar/python-java/custom-font/
keywords:
- خط
- خط مخصص
- خط خارجي
- تحميل الخط
- إدارة الخطوط
- مجلد الخطوط
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تخصيص الخطوط في شرائح PowerPoint باستخدام Aspose.Slides للـ Python عبر Java للحفاظ على وضوح وعرض تقديمي متسق عبر أي جهاز."
---
## **نظرة عامة**

Aspose.Slides يسمح لك باستخدام خطوط مخصصة في العروض التقديمية دون تثبيتها على نظام التشغيل. يمكنك تحميل الخطوط من مجلدات مخصصة، أو توفير الخطوط لعرض محدد عبر مصادر خطوط على مستوى المستند، أو تحميل خطوط خارجية مباشرة من بيانات ثنائية.

يتم استخدام الخطوط التي تم تحميلها عندما يُعرض العرض التقديمي أو يُصدَّر، على سبيل المثال إلى PDF أو صور أو صيغ أخرى مدعومة. يساعد ذلك في الحفاظ على مخرجات العرض التقديمي متسقة عبر بيئات مختلفة. توضح المقالة أيضًا كيفية فحص مجلدات الخطوط التي يستخدمها Aspose.Slides وكيفية مسح ذاكرة التخزين المؤقت للخطوط بعد العمل مع الخطوط الخارجية.

تسجيل الخطوط المخصصة للتصيير مختلف عن تضمين الخطوط في ملف PPTX. إذا كان يجب تخزين الخط داخل العرض نفسه، استخدم ميزات تضمين الخطوط بشكل صريح.

يمكن للسمات في العرض التقديمي الإشارة إلى عائلات خطوط مختلفة لأنظمة كتابة فردية. هذه الخرائط تخزن أسماء الخطوط لكنها لا تثبت أو تحمل ملفات الخطوط. راجع [خطوط السمة حسب النص](/slides/ar/python-java/script-specific-font-mappings/) لإدارة الخرائط، واستخدم خيارات التحميل أدناه لجعل الخطوط المشار إليها متاحة لتصيير متسق.

{{% alert color="info" title="ملاحظة" %}}
Aspose.Slides يسمح لك بتحميل هذه الخطوط باستخدام طريقة [loadExternalFonts](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsloader/#loadExternalFonts):

* خطوط TrueType (.ttf) ومجموعة خطوط TrueType (.ttc). انظر [TrueType](https://en.wikipedia.org/wiki/TrueType).

* خطوط OpenType (.otf). انظر [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **تحميل الخطوط المخصصة**

Aspose.Slides يسمح لك بتحميل الخطوط المستخدمة في عرض تقديمي دون تثبيتها على النظام. هذا يؤثر على مخرجات التصدير—مثل PDF أو صور أو صيغ أخرى مدعومة—بحيث تبدو المستندات الناتجة متسقة عبر البيئات. يتم تحميل الخطوط من دلائل مخصصة.

1. حدد مجلدًا أو أكثر يحتوي على ملفات الخطوط.  
2. استدعِ الطريقة الثابتة [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsloader/#loadExternalFonts) لتحميل الخطوط من هذه المجلدات.  
3. حمّل وعرّف/صدّر العرض التقديمي.  
4. استدعِ [FontsLoader.clearCache](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsloader/#clearCache) لمسح ذاكرة التخزين المؤقت للخطوط.

المثال البرمجي التالي يوضح عملية تحميل الخطوط:

```python
from jpype import JArray, JString
from asposeslides.api import FontsLoader, Presentation, SaveFormat

# تعريف المجلدات التي تحتوي على ملفات خطوط مخصصة.
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])

# تحميل الخطوط المخصصة من المجلدات المحددة.
FontsLoader.loadExternalFonts(font_folders)

presentation = None
try:
    presentation = Presentation("sample.pptx")

    # عرض/تصدير العرض التقديمي باستخدام الخطوط التي تم تحميلها.
    presentation.save("output.pdf", SaveFormat.Pdf)
finally:
    if presentation is not None:
        presentation.dispose()

    # مسح ذاكرة التخزين المؤقت للخطوط بعد الانتهاء من العمل.
    FontsLoader.clearCache()
```

{{% alert color="info" title="ملاحظة" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsloader/#loadExternalFonts) يضيف مجلدات إضافية إلى مسارات البحث عن الخطوط، لكنه لا يغير ترتيب تهيئة الخطوط.  
يتم تهيئة الخطوط بهذا الترتيب:

1. مسار الخط الافتراضي لنظام التشغيل.  
1. المسارات التي تم تحميلها عبر [FontsLoader](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsloader/).
{{%/alert %}}

## **الحصول على مجلدات الخطوط المخصصة**
Aspose.Slides يقدم الطريقة [getFontFolders](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsloader/#getFontFolders) لتسمح لك بالعثور على مجلدات الخطوط. تُعيد هذه الطريقة المجلدات التي تمت إضافتها عبر طريقة [loadExternalFonts](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsloader/#loadExternalFonts) ومجلدات الخطوط النظامية.

هذا الكود بلغة Python يوضح كيفية استخدام [getFontFolders](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsloader/#getFontFolders):

```python
from asposeslides.api import FontsLoader

# الحصول على المجلدات التي أضيفت عبر loadExternalFonts ومجلدات الخطوط النظامية.
font_folders = FontsLoader.getFontFolders()
```

## **تحديد الخطوط المخصصة المستخدمة مع عرض تقديمي**
Aspose.Slides يقدم الطريقة [getDocumentLevelFontSources](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) لتسمح لك بتحديد الخطوط الخارجية التي ستُستخدم مع العرض التقديمي.

هذا الكود بلغة Python يوضح كيفية استخدام الطريقة [getDocumentLevelFontSources](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources):

```python
from pathlib import Path
from jpype import JArray, JByte, JString
from asposeslides.api import LoadOptions, Presentation

memory_font_primary = Path("customfonts/CustomFont1.ttf").read_bytes()
memory_font_secondary = Path("customfonts/CustomFont2.ttf").read_bytes()

load_options = LoadOptions()
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])
memory_fonts = JArray(JByte, 2)([memory_font_primary, memory_font_secondary])
load_options.getDocumentLevelFontSources().setFontFolders(font_folders)
load_options.getDocumentLevelFontSources().setMemoryFonts(memory_fonts)

presentation = Presentation("MyPresentation.pptx", load_options)
try:
    # العمل على العرض التقديمي.
    # CustomFont1، CustomFont2، والخطوط من assets/fonts و global/fonts
    # ومجلداتهم الفرعية متاحة للعرض التقديمي.
    pass
finally:
    presentation.dispose()
```

## **إدارة الخطوط خارجيًا**

Aspose.Slides يقدم الطريقة [loadExternalFont](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsloader/#loadExternalFont) لتسمح لك بتحميل خطوط خارجية من بيانات ثنائية.

هذا الكود بلغة Python يوضح عملية تحميل الخطوط من مصفوفة بايت:

```python
from pathlib import Path
from jpype import JArray, JByte
from asposeslides.api import FontsLoader, Presentation

font_data = Path("ARIALN.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNBI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))

try:
    presentation = Presentation()
    try:
        # يتم تحميل الخطوط الخارجية خلال عمر العرض التقديمي.
        pass
    finally:
        presentation.dispose()
finally:
    FontsLoader.clearCache()
```

## **الأسئلة المتكررة**

**هل تؤثر الخطوط المخصصة على التصدير إلى جميع الصيغ (PDF، PNG، SVG، HTML)؟**  
نعم. تُستخدم الخطوط المتصلة من قبل المُعالج عبر جميع صيغ التصدير.

**هل يتم تضمين الخطوط المخصصة تلقائيًا في ملف PPTX الناتج؟**  
لا. تسجيل الخط للتصيير ليس هو نفسه تضمينه في ملف PPTX. إذا كنت بحاجة إلى حمل الخط داخل ملف العرض، يجب استخدام [ميزات التضمين](/slides/ar/python-java/embedded-font/).

**هل يمكن التحكم بسلوك التراجع عندما تفتقر الخطوط المخصصة إلى بعض الرموز؟**  
نعم. اضبط [استبدال الخط](/slides/ar/python-java/font-substitution/)، [قواعد الاستبدال](/slides/ar/python-java/font-replacement/)، و[مجموعات التراجع](/slides/ar/python-java/fallback-font/) لتحديد الخط الذي سيُستخدم عندما يكون الرمز المطلوب مفقودًا.

**هل يمكنني استخدام الخطوط في حاويات Linux/Docker دون تثبيتها على مستوى النظام؟**  
نعم. يمكنك الإشارة إلى مجلدات الخطوط الخاصة بك أو تحميل الخطوط من مصفوفات بايت. هذا يزيل أي اعتماد على دلائل الخطوط النظامية داخل صورة الحاوية.

**ماذا عن الترخيص—هل يمكنني تضمين أي خط مخصص دون قيود؟**  
أنت مسؤول عن الامتثال لترخيص الخط. تختلف الشروط؛ بعض التراخيص تمنع التضمين أو الاستخدام التجاري. راجع دائمًا اتفاقية ترخيص المستخدم النهائي للخط قبل توزيع المخرجات.