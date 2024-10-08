---
title: خط باوربوينت مخصص في بايثون
linktitle: خط مخصص
type: docs
weight: 20
url: /ar/python-net/custom-font/
keywords: "خطوط، خطوط مخصصة، عرض باوربوينت، بايثون، Aspose.Slides لبايثون عبر .NET"
description: "خطوط باوربوينت المخصصة في بايثون"
---

{{% alert color="primary" %}} 

تسمح لك Aspose Slides بتحميل هذه الخطوط باستخدام طريقة `load_external_fonts` من فئة [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) :

* خطوط TrueType (.ttf) ومجموعات TrueType (.ttc). انظر [TrueType](https://en.wikipedia.org/wiki/TrueType).

* خطوط OpenType (.otf). انظر [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **تحميل خطوط مخصصة**

تسمح لك Aspose.Slides بتحميل الخطوط التي يتم عرضها في العروض التقديمية دون الحاجة إلى تثبيت هذه الخطوط. يتم تحميل الخطوط من دليل مخصص. 

1. قم بإنشاء نسخة من فئة [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) واستدعاء طريقة `load_external_fonts`.
2. قم بتحميل العرض التقديمي الذي سيتم عرضه.
3. امسح الذاكرة المؤقتة في فئة [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) .

يوضح هذا الرمز في بايثون عملية تحميل الخط:

```python
import aspose.slides as slides

# مسار دليل المستندات.
dataDir = "C:\\"

# المجلدات للبحث عن الخطوط
folders = [ dataDir ]

# تحميل خطوط الدليل المخصص
slides.FontsLoader.load_external_fonts(folders)

# القيام ببعض الأعمال وأداء عرض الشرائح
with slides.Presentation(path + "DefaultFonts.pptx") as presentation:
    presentation.save("NewFonts_out.pptx", slides.export.SaveFormat.PPTX)

# مسح ذاكرة الخط
slides.FontsLoader.clear_cache()
```

## **الحصول على مجلدات الخطوط المخصصة**
يوفر Aspose.Slides طريقة `get_font_folders()` للسماح لك بإيجاد مجلدات الخطوط. تعيد هذه الطريقة المجلدات التي تمت إضافتها من خلال طريقة `LoadExternalFonts` ومجلدات الخطوط النظامية.

يوضح هذا الرمز في بايثون كيفية استخدام `get_font_folders()`:

```python
#  هذه السطر يخرج المجلدات التي يتم التحقق منها لملفات الخط.
# تلك هي المجلدات التي تمت إضافتها من خلال طريقة load_external_fonts ومجلدات الخطوط النظامية.
fontFolders = slides.FontsLoader.get_font_folders()

```


## **تحديد الخطوط المخصصة المستخدمة مع العرض التقديمي**
يوفر Aspose.Slides خاصية `document_level_font_sources` للسماح لك بتحديد الخطوط الخارجية التي ستستخدم مع العرض التقديمي.

يوضح هذا الرمز في بايثون كيفية استخدام خاصية `document_level_font_sources`:

```python
import aspose.slides as slides

with open(path + "CustomFont1.ttf", "br") as font1:
    memoryFont1 = font1.read()
    with open(path + "CustomFont2.ttf", "br") as font2:
        memoryFont2 = font2.read()

        loadOptions = slides.LoadOptions()
        loadOptions.document_level_font_sources.font_folders =  ["assets\\fonts", "global\\fonts"] 
        loadOptions.document_level_font_sources.memory_fonts = [ memoryFont1, memoryFont2 ]
        with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as presentation:
            # العمل مع العرض التقديمي
            # خط CustomFont1 وCustomFont2 وخطوط من مجلدات assets\fonts وglobal\fonts ومجلداتها الفرعية متاحة للعرض التقديمي
            print(len(presentation.slides))
```

## **إدارة الخطوط خارجيًا**

يوفر Aspose.Slides طريقة `load_external_font`(data) للسماح لك بتحميل الخطوط الخارجية من بيانات ثنائية.

يوضح هذا الرمز في بايثون عملية تحميل خط مصفوفة البايت:

```python
from aspose.slides import FontsLoader, Presentation

def read_all_bytes(path):
    with open(path, "rb") as in_file:
        bytes = in_file.read()
    return bytes

FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with Presentation() as pres:
        # تم تحميل الخط الخارجي خلال فترة العرض التقديمي
        print("processing")
finally:
    FontsLoader.clear_cache()

```