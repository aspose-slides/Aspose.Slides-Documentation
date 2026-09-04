---
title: التثبيت
type: docs
weight: 70
url: /ar/python-java/installation/
keywords:
- تحميل Aspose.Slides
- تثبيت Aspose.Slides
- تثبيت Aspose.Slides
- Python
- Java
- JPype
- Windows
- macOS
- Linux
description: "تثبيت Aspose.Slides لـ Python عبر Java على Windows أو Linux أو macOS، إعداد Java و JPype، والتحقق من التثبيت باستخدام مثال عملي."
---
Aspose.Slides for Python عبر Java يعمل على Windows و Linux و macOS. يستخدم JPype للوصول إلى مكتبة Java من Python. لا يلزم وجود Microsoft PowerPoint.

## **المتطلبات المسبقة**

قبل تثبيت حزم Python، قم بتثبيت Python و JDK يلبيان [متطلبات النظام](/slides/ar/python-java/system-requirements/). تسرد تلك الصفحة الإصدارات المتوافقة ومتطلبات المعمارية وأي تبعيات مطلوبة لبناء JPype من المصدر.

عيّن `JAVA_HOME` إلى دليل تثبيت JDK، وليس إلى دليل الفرعي `bin` الخاص به، وأضف دليل `bin` للـ JDK إلى المتغيّر `PATH`. افتح نافذة طرفية جديدة بعد تغيير متغيّرات البيئة.

## **التثبيت من PyPI**

قم بتنفيذ الأوامر التالية في نافذة طرفية، وليس في موجه Python التفاعلي. أنشئ دليل مشروع وبيئة افتراضية لعزل الحزم عن المشاريع الأخرى.

### **ويندوز**

مع مفسّر Python المختار المتاح كـ `python` في `PATH`، نفّذ الأوامر التالية في موجه الأوامر:

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **لينكس و macOS**

مع إصدار Python المختار المتاح كـ `python3`، نفّذ الأوامر التالية في Bash أو zsh:

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

على Debian أو Ubuntu، إذا فشل إنشاء البيئة بسبب عدم توفير `ensurepip`، قم بتثبيت حزمة `python3-venv` باستخدام `sudo apt-get install python3-venv`، ثم كرّر أمر إنشاء البيئة. قد تحتاج نسخة Python المثبتة بشكل منفصل إلى حزمة `venv` المتوافقة مع إصدارها.

### **تثبيت الحزم**

مع تفعيل البيئة الافتراضية، ثبّـت JPype و Aspose.Slides:

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

استخدام `python -m pip` يضمن تثبيت الحزم لمفسّر Python المستخدم لتشغيل تطبيقك.

لتحديث تثبيت Aspose.Slides الحالي، نفّذ `python -m pip install --upgrade aspose-slides-java` في نفس البيئة.

## **التثبيت من أرشيف ZIP**

يمكنك أيضًا استخدام المكتبة من صفحة [تنزيلات Aspose.Slides](https://releases.aspose.com/slides/ar/python-java/):

1. ثبت Python و Java كما هو موضح في [المتطلبات المسبقة](#prerequisites).
2. أنشئ وفعل بيئة افتراضية باستخدام التعليمات أعلاه.
3. ثبّت JPype باستخدام `python -m pip install JPype1`.
4. حمّل واستخرج أرشيف ZIP الخاص بـ Aspose.Slides for Python عبر Java.
5. اعثر على دليل الحزمة المستخرجة `asposeslides`. احتفظ بمحتوياته، بما في ذلك دليل `lib` وملف JAR، معًا.
6. ضع `example.py` من القسم التالي بجوار دليل `asposeslides` حتى يتمكن Python من استيراد الحزمة.

## **تحقق من التثبيت**

احفظ الشيفرة التالية كملف `example.py`. تُنشئ عرضًا تقديميًا يحتوي على مربع نص وتُحفظ كـ `out.pptx` في الدليل الحالي.

```python
import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Presentation, SaveFormat, ShapeType

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 500, 80)
        shape.getTextFrame().setText("Aspose.Slides is ready!")
        presentation.save("out.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    jpype.shutdownJVM()
```

مع تفعيل البيئة الافتراضية، نفّذ المثال من الدليل الذي يحتوي على `example.py`:

```sh
python example.py
```

يُسجِّل استيراد `asposeslides` مكتبة Java المضمنة قبل بدء تشغيل JVM. استورد `asposeslides.api` بعد بدء تشغيل JVM، وأطلِق موارد العرض قبل إغلاقه.

{{% alert color="info" title="ملاحظة" %}}
بدون ترخيص، يتضمن الناتج علامة مائية توضيحية. راجع [تقييم Aspose.Slides](/slides/ar/python-java/evaluate-aspose-slides/) لمعرفة حدود التقييم ومعلومات الترخيص المؤقت.
{{% /alert %}}

## **الأسئلة الشائعة**

**لماذا يُظهر Python أن JVM لا يمكن العثور عليها أو تحميلها؟**

تحقق من أن `JAVA_HOME` يشير إلى JDK متوافق مع تثبيت Python و JPype لديك، كما هو موضح في [متطلبات النظام](/slides/ar/python-java/system-requirements/). راجع [دليل استكشاف أخطاء تثبيت JPype](https://jpype.readthedocs.io/en/latest/install.html) للمزيد من الفحوصات.

**لماذا يُظهر Python أن `asposeslides` مفقود بعد التثبيت؟**

قد تم تثبيت الحزمة لمفسّر Python مختلف. فعّل البيئة الافتراضية المستخدمة في التثبيت ونفّذ `python -m pip show aspose-slides-java`. بالنسبة لتثبيت ZIP، تأكد من وجود دليل `asposeslides` بجوار السكريبت الخاص بك أو أن يكون متاحًا على مسار بحث وحدات Python.

**هل يمكنني تشغيل المثال بشكل متكرر في دفتر ملاحظات؟**

المثال مخصص لعملية Python مستقلة. قبل تعديلها لتشغيلها المتكرر في دفتر ملاحظات، راجع [القيود واختلافات API](/slides/ar/python-java/limitations-and-api-differences/#import-the-library) لمعرفة دورة حياة JVM وإرشادات الدفتر.

** لماذا يفشل pip مع `CERTIFICATE_VERIFY_FAILED`؟**

إذا كان شبكتك تستخدم وكيل فحص HTTPS، يجب على pip الوثوق بسلطة الشهادة الخاصة به. قم بتهيئة حزمة الشهادات الموثوقة باستخدام خيار `--cert` في pip أو متغيّر البيئة `PIP_CERT`، وفقًا لـ [تعليمات شهادة HTTPS الخاصة بـ pip](https://pip.pypa.io/en/stable/topics/https-certificates/). تعتمد التهيئة المطلوبة على شبكتك وإصدار pip.