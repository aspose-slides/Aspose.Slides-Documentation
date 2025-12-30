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
description: "إدراج الخطوط المخصصة في شرائح PowerPoint باستخدام Aspose.Slides للبايثون عبر .NET للحفاظ على عروضك التقديمية حادة ومتسقة عبر أي جهاز."
---

## **نظرة عامة**

Aspose.Slides for Python يتيح لك توفير خطوط مخصصة في وقت التشغيل بحيث يتم عرض العروض التقديمية بشكل صحيح حتى عندما لا تكون الخطوط المطلوبة مثبتة على نظام المضيف. أثناء التصدير إلى PDF أو صور، يمكنك تزويد مجلدات الخطوط أو بيانات الخط داخل الذاكرة للحفاظ على تخطيط النص، مقاييس الحروف، والطباعة. هذا يجعل عرض الخادم جانب الخادم متوقعًا عبر بيئات مختلفة، يزيل الاعتماد على خطوط نظام التشغيل، ويمنع التحويلات غير المرغوب فيها أو إعادة التدفق. تُظهر المقالة كيفية تسجيل مصادر الخطوط.

Aspose.Slides يتيح لك تحميل الخطوط التالية باستخدام طريقتي `load_external_font` و `load_external_fonts` من فئة [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) :

- خطوط TrueType (.ttf) ومجموعة TrueType (.ttc). انظر [TrueType](https://en.wikipedia.org/wiki/TrueType).
- خطوط OpenType (.otf). انظر [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **تحميل الخطوط المخصصة**

Aspose.Slides يسمح لك بتحميل الخطوط المستخدمة في عرض تقديمي دون تثبيتها على النظام. هذا يؤثر على مخرجات التصدير — مثل PDF، الصور، وغيرها من الصيغ المدعومة — بحيث تبدو المستندات الناتجة متسقة عبر البيئات. يتم تحميل الخطوط من أدلة مخصصة.

1. حدد أحد المجلدات أو أكثر التي تحتوي على ملفات الخط.  
2. استدعِ الطريقة الثابتة [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/load_external_fonts/) لتحميل الخطوط من تلك المجلدات.  
3. حمّل وعرض/صدر العرض التقديمي.  
4. استدعِ [FontsLoader.clear_cache](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/clear_cache/) لمسح ذاكرة التخزين المؤقت للخطوط.

```py
import aspose.slides as slides

# حدد المجلدات التي تحتوي على ملفات الخطوط المخصصة.
font_folders = [ external_font_folder1, external_font_folder2 ]

# تحميل الخطوط المخصصة من المجلدات المحددة.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # عرض/تصدير العرض التقديمي (مثل PDF، صور، أو صيغ أخرى) باستخدام الخطوط المحمّلة.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# مسح ذاكرة التخزين المؤقت للخطوط بعد الانتهاء من العمل.
slides.FontsLoader.clear_cache()
```


{{% alert color="info" title="Note" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/load_external_fonts/) يضيف مجلدات إضافية إلى مسارات البحث عن الخطوط، لكنه لا يغير ترتيب تهيئة الخطوط. يتم تهيئة الخطوط بهذا الترتيب:

1. مسار الخط الافتراضي لنظام التشغيل.  
1. المسارات التي تم تحميلها عبر [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/).  
{{%/alert %}}

## **الحصول على مجلد الخطوط المخصصة**

Aspose.Slides يوفر طريقة `get_font_folders` لاسترجاع مجلدات الخطوط. تُرجع كلًا من المجلدات التي تمت إضافتها عبر `load_external_fonts` ومجلدات خطوط النظام.

```python
import aspose.slides as slides

# هذا الاستدعاء يُعيد المجلدات التي تم فحصها لملفات الخطوط.
# تشمل هذه المجلدات المجلدات التي أضيفت عبر طريقة load_external_fonts ومجلدات خطوط النظام.
font_folders = slides.FontsLoader.get_font_folders()
```


## **تحديد الخطوط المخصصة لعرض تقديمي**

Aspose.Slides يوفر الخاصية `document_level_font_sources`، والتي تتيح لك تحديد الخطوط الخارجية لاستخدامها مع عرض تقديمي.

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
    # تتوفر الخطوط CustomFont1 و CustomFont2 والخطوط من مجلدي assets\fonts و global\fonts (وتحت مجلداتهما) للعرض التقديمي.
    # ...
    print(len(presentation.slides))
```


## **تحميل الخطوط الخارجية من بيانات ثنائية**

Aspose.Slides يوفر طريقة `load_external_font` لتحميل الخطوط الخارجية من بيانات ثنائية.

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
        # الخطوط الخارجية متاحة طوال فترة حياة كائن العرض التقديمي هذا.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```


## **أسئلة شائعة**

**هل تؤثر الخطوط المخصصة على التصدير إلى جميع الصيغ (PDF, PNG, SVG, HTML)?**

نعم. تُستخدم الخطوط المتصلة بواسطة المُعالج عبر جميع صيغ التصدير.

**هل يتم تضمين الخطوط المخصصة تلقائيًا في ملف PPTX الناتج؟**

لا. تسجيل الخط للتص rendering لا يعني تضمينه في PPTX. إذا كنت بحاجة إلى تضمين الخط داخل ملف العرض، يجب عليك استخدام ميزات [embedding features](/slides/ar/python-net/embedded-font/).

**هل يمكنني التحكم في سلوك التراجع عندما يفتقر الخط المخصص إلى بعض الحروف؟**

نعم. قم بتكوين [font substitution](/slides/ar/python-net/font-substitution/)، [replacement rules](/slides/ar/python-net/font-replacement/)، و [fallback sets](/slides/ar/python-net/fallback-font/) لتحديد الخط المستخدم بالضبط عندما تكون الحرف المطلوب مفقودة.

**هل يمكنني استخدام الخطوط في حاويات Linux/Docker دون تثبيتها على مستوى النظام؟**

نعم. أشر إلى مجلدات الخط الخاصة بك أو حمّل الخطوط من مصفوفات البايت. هذا يزيل أي اعتماد على مجلدات خطوط النظام في صورة الحاوية.

**ماذا عن الترخيص — هل يمكنني تضمين أي خط مخصص دون قيود؟**

أنت مسؤول عن الامتثال لترخيص الخط. تختلف الشروط؛ بعض التراخيص تحظر التضمين أو الاستخدام التجاري. راجع دائمًا اتفاقية ترخيص المستخدم النهائي للخط قبل توزيع المخرجات.