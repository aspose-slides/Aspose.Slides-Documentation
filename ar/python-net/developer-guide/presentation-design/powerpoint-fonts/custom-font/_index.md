---
title: تخصيص خطوط PowerPoint في بايثون
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
description: "تضمين الخطوط المخصصة في شرائح PowerPoint باستخدام Aspose.Slides للبايثون عبر .NET للحفاظ على عروضك التقديمية حادة ومتسقة عبر أي جهاز."
---

## **نظرة عامة**

تمكنك Aspose.Slides for Python من توفير خطوط مخصصة في وقت التشغيل، بحيث يتم عرض العروض التقديمية بشكل صحيح حتى عندما لا تكون الخطوط المطلوبة مثبتة على نظام المضيف. أثناء التصدير إلى PDF أو صور، يمكنك توفير مجلدات الخطوط أو بيانات الخط في الذاكرة للحفاظ على تخطيط النص، مقاييس الحروف، والطباعة. يجعل هذا عملية العرض على الخادم قابلة للتنبؤ عبر بيئات مختلفة، يزيل الاعتماد على خطوط نظام التشغيل، ويمنع التحويلات غير المرغوبة أو إعادة التدفق. تُظهر هذه المقالة كيفية تسجيل مصادر الخطوط.

تمكنك Aspose.Slides من تحميل الخطوط التالية باستخدام طريقتي `load_external_font` و `load_external_fonts` من فئة [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/):
- خطوط TrueType (.ttf) ومجموعة TrueType (.ttc). راجع [TrueType](https://en.wikipedia.org/wiki/TrueType).
- خطوط OpenType (.otf). راجع [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **تحميل الخطوط المخصصة**

تمكنك Aspose.Slides من تحميل الخطوط لعرض العروض التقديمية دون تثبيتها. يتم تحميل الخطوط من دليل مخصص.

1. استدعِ طريقة `load_external_fonts` من فئة [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/).
2. حمّل العرض التقديمي المراد عرضه.
3. امسح الذاكرة المخبأة في فئة [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/).

```python
import aspose.slides as slides

# المجلدات للبحث عن الخطوط.
font_folders = [ "C:\\MyFonts", "D:\\MyAdditionalFonts" ]

# تحميل الخطوط من المجلدات المخصصة.
slides.FontsLoader.load_external_fonts(font_folders)

# إنشاء العرض التقديمي.
with slides.Presentation("Fonts.pptx") as presentation:
    presentation.save("Fonts_out.pdf", slides.export.SaveFormat.PDF)

# مسح ذاكرة التخزين المؤقت للخطوط.
slides.FontsLoader.clear_cache()
```


## **الحصول على مجلد الخطوط المخصصة**

توفر Aspose.Slides طريقة `get_font_folders` لاسترداد مجلدات الخطوط. تُعيد كل من المجلدات التي أضيفت عبر `load_external_fonts` ومجلدات خطوط النظام.

```python
import aspose.slides as slides

# هذه الدالة تُرجع المجلدات التي تم فحصها لملفات الخطوط.
# وتشمل هذه المجلدات المضافة عبر طريقة load_external_fonts ومجلدات خطوط النظام.
font_folders = slides.FontsLoader.get_font_folders()
```


## **تحديد الخطوط المخصصة لعرض تقديمي**

توفر Aspose.Slides الخاصية `document_level_font_sources`، والتي تتيح لك تحديد الخطوط الخارجية لاستخدامها مع عرض تقديمي.

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
    # الخطوط CustomFont1 و CustomFont2 والخطوط من مجلّدي assets\\fonts و global\\fonts (ومجلداتهما الفرعية) متاحة للعرض التقديمي.
    # ...
    print(len(presentation.slides))
```


## **تحميل الخطوط الخارجية من بيانات ثنائية**

توفر Aspose.Slides طريقة `load_external_font` لتحميل الخطوط الخارجية من بيانات ثنائية.

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
        # الخطوط الخارجية متاحة طوال عمر مثيل العرض التقديمي هذا.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```


## **الأسئلة المتكررة**

**هل تؤثر الخطوط المخصصة على التصدير إلى جميع صيغ (PDF, PNG, SVG, HTML)؟**
نعم. يتم استخدام الخطوط المتصلة من قبل المُعالج عبر جميع صيغ التصدير.

**هل يتم تضمين الخطوط المخصصة تلقائيًا في ملف PPTX الناتج؟**
لا. تسجيل الخط للعرض ليس هو نفسه تضمينه في PPTX. إذا كنت بحاجة إلى أن يُحمل الخط داخل ملف العرض التقديمي، يجب عليك استخدام [ميزات التضمين](/slides/ar/python-net/embedded-font/).

**هل يمكنني التحكم في سلوك الاستبدال عندما يفتقر الخط المخصص إلى بعض الحروف؟**
نعم. اضبط [استبدال الخطوط](/slides/ar/python-net/font-substitution/)، [قواعد الاستبدال](/slides/ar/python-net/font-replacement/)، و[مجموعات الاحتياط](/slides/ar/python-net/fallback-font/) لتحديد الخط الذي يُستخدم بالضبط عندما تكون الحرف المطلوب مفقودًا.

**هل يمكنني استخدام الخطوط في حاويات Linux/Docker دون تثبيتها على مستوى النظام؟**
نعم. قم بالإشارة إلى مجلدات الخطوط الخاصة بك أو تحميل الخطوط من مصفوفات البايت. هذا يزيل أي اعتماد على أدلة خطوط النظام في صورة الحاوية.

**ماذا عن الترخيص—هل يمكنني تضمين أي خط مخصص دون قيود؟**
أنت مسؤول عن الامتثال لترخيص الخطوط. تختلف الشروط؛ بعض التراخيص تحظر التضمين أو الاستخدام التجاري. تأكد دائمًا من مراجعة اتفاقية ترخيص المستخدم النهائي للخط قبل توزيع المخرجات.