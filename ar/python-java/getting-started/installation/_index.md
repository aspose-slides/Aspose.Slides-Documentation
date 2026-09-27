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
- ويندوز
- ماك أو إس
- لينكس
description: "قم بتثبيت Aspose.Slides للـ Python عبر Java على نظام ويندوز أو لينكس أو ماك أو إس، وقم بإعداد Java و JPype، وتحقق من الإعداد باستخدام مثال عملي."
---
Aspose.Slides للـ Python عبر Java يعمل على Windows وLinux وmacOS. يستخدم JPype للوصول إلى مكتبة Java من Python. لا يلزم وجود Microsoft PowerPoint.

## **المتطلبات المسبقة**

قبل تثبيت حزم Python، قم بتثبيت Python وJDK يتوافقان مع [System Requirements](/slides/ar/python-java/system-requirements/). تُدرج تلك الصفحة الإصدارات المتوافقة، متطلبات المعمارية، وأي تبعيات مطلوبة لبناء JPype من المصدر.

قم بتعيين `JAVA_HOME` إلى دليل تثبيت JDK، وليس إلى دليل `bin` الفرعي، وأضف دليل `bin` الخاص بـ JDK إلى `PATH`. افتح طرفية جديدة بعد تعديل متغيرات البيئة.

## **التثبيت من PyPI**

شغّل الأوامر التالية في طرفية، لا في موجه Python التفاعلي. أنشئ دليل مشروع وبيئة افتراضية لتبقى الحزم معزولة عن المشاريع الأخرى.

### **ويندوز**

مع وجود مفسّر Python المختار متاحًا كـ `python` في `PATH`، شغّل الأوامر التالية في موجه الأوامر:

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux و macOS**

مع وجود نسخة Python المختارة متاحة كـ `python3`، شغّل الأوامر التالية في Bash أو zsh:

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

على Debian أو Ubuntu، إذا فشل إنشاء البيئة بسبب عدم وجود `ensurepip`، ثبّت حزمة `python3-venv` باستخدام `sudo apt-get install python3-venv`، ثم أعد تنفيذ أمر إنشاء البيئة. قد تحتاج نسخة Python المثبتة منفصلًا إلى حزمة `venv` المطابقة لإصدارها.

### **تثبيت الحزم**

مع تفعيل البيئة الافتراضية، ثبّت JPype وAspose.Slides:

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

استخدام `python -m pip` يضمن تثبيت الحزم للمفسّر الذي يُستَخدم لتشغيل تطبيقك.

لتحديث تثبيت Aspose.Slides موجود، شغّل `python -m pip install --upgrade aspose-slides-java` في نفس البيئة.

## **التثبيت من أرشيف ZIP**

يمكنك أيضًا استخدام المكتبة من [Aspose.Slides downloads page](https://releases.aspose.com/slides/ar/python-java/):

1. ثبت Python وJava كما هو موضح في [المتطلبات المسبقة](#prerequisites).
2. أنشئ وفعل بيئة افتراضية باستخدام التعليمات السابقة.
3. ثبّت JPype عبر `python -m pip install JPype1`.
4. حمّل واستخرج أرشيف ZIP الخاص بـ Aspose.Slides للـ Python عبر Java.
5. حدّد دليل الحزمة المستخرجة `asposeslides`. احتفظ بمحتوياته، بما في ذلك دليل `lib` وملف JAR، معًا.
6. ضع `example.py` من القسم التالي بجوار دليل `asposeslides` بحيث يستطيع Python استيراد الحزمة. الأرشيف يحتوي بالفعل على `example.py` الخاص به بجوار `asposeslides`؛ استبدله بالملف أدناه.

## **التحقق من التثبيت**

احفظ الشيفرة التالية كملف `example.py`. تنشئ عرضًا تقديميًا يحتوي على صندوق نص وتُحفظ كـ `out.pptx` في الدليل العامل الحالي.

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

مع تفعيل البيئة الافتراضية، شغّل المثال من الدليل الذي يحتوي على `example.py`:

```sh
python example.py
```

استيراد `asposeslides` يسجل مكتبة Java المدمجة قبل بدء تشغيل JVM. استورد `asposeslides.api` بعد بدء JVM، وحرّر موارد العرض قبل إغلاقه.

{{% alert color="info" title="Note" %}}
بدون ترخيص، يتضمن الناتج علامة مائية تجريبية. راجع [Evaluate Aspose.Slides](/slides/ar/python-java/evaluate-aspose-slides/) لتعرف قيود التقييم ومعلومات الترخيص المؤقت.
{{% /alert %}}

## **الأسئلة المتكررة**

**لماذا يُظهر Python أن JVM لا يمكن العثور عليه أو تحميله؟**  
تحقق من أن `JAVA_HOME` يشير إلى JDK متوافق مع نسخة Python وJPype المثبتة، كما هو موضح في [System Requirements](/slides/ar/python-java/system-requirements/). راجع [JPype installation troubleshooting guide](https://jpype.readthedocs.io/en/latest/install.html) للمزيد من الفحوصات.

**لماذا يُظهر Python أن `asposeslides` مفقود بعد التثبيت؟**  
ربما تم تثبيت الحزمة لِمُفسّر Python مختلف. فعّل البيئة الافتراضية المستخدمة للتثبيت وشغّل `python -m pip show aspose-slides-java`. بالنسبة لتثبيت ZIP، تأكد من وجود دليل `asposeslides` بجانب سكريبتك أو أنّه متاح على مسار بحث الوحدات الخاص بـ Python.

**هل يمكنني تشغيل المثال بشكل متكرر في دفتر ملاحظات؟**  
المثال مُصمم لعملية Python مستقلة. قبل تكييفه للتنفيذ المتكرر في دفتر ملاحظات، راجع [Limitations and API Differences](/slides/ar/python-java/limitations-and-api-differences/#import-the-library) لمعرفة دورة حياة JVM وإرشادات الدفاتر.

**لماذا يفشل pip مع الخطأ `CERTIFICATE_VERIFY_FAILED`؟**  
إذا كانت شبكتك تستخدم وكيل فحص HTTPS، يجب على pip الوثوق بسلطة الشهادات الخاصة بالوكيل. اضبط حزمة الشهادات الموثوقة باستخدام خيار `--cert` في pip أو المتغيّر البيئي `PIP_CERT`، وفقًا لـ [pip HTTPS certificate instructions](https://pip.pypa.io/en/stable/topics/https-certificates/). يعتمد الإعداد المطلوب على شبكتك وإصدار pip.