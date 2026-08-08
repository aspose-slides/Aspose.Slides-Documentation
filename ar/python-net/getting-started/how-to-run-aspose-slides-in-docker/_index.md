---
title: كيفية تشغيل Aspose.Slides في Docker
linktitle: Aspose.Slides في Docker
type: docs
weight: 150
url: /ar/python-net/how-to-run-aspose-slides-in-docker/
keywords:
- Aspose.Slides في Docker
- حاوية Docker
- Dockerfile
- لينكس
- libgdiplus
- ICU
- OpenSSL
- خطوط
- PowerPoint
- OpenDocument
- عرض تقديمي
- بايثون
- Aspose.Slides
description: "تشغيل Aspose.Slides for Python via .NET في Docker: Dockerfile يعمل، المكتبات الأصلية التي تحتاجها الحزمة، إعداد الخطوط، والترخيص داخل الحاوية."
---
## **نظرة عامة**

Aspose.Slides for Python via .NET يعمل داخل حاويات لينكس، لكن الحزمة هي غلاف Python حول بيئة تشغيل .NET Core 3.1 مدمجة. هذه البيئة تحتاج إلى ثلاث مكتبات أصلية لا تُدرج في صور Python الخفيفة، وهي حساسة لإصداراتها. يقدّم هذا المقال Dockerfile يعمل، يوضح سبب وجود كل تبعية، ويظهر طريقة إضافة الخطوط والترخيص.

## **Dockerfile يعمل**

```dockerfile
FROM python:3.11-slim-bullseye

RUN apt-get update && apt-get install -y --no-install-recommends \
        libgdiplus \
        libicu67 \
        libfontconfig1 \
        fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*

RUN pip install --no-cache-dir aspose.slides

WORKDIR /app
COPY app.py .
CMD ["python", "app.py"]
```

`app.py`:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    shape.text_frame.text = "Created inside a Docker container"
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)
```

بناء وتشغيل:

```bash
docker build -t aspose-slides-python .
docker run --rm aspose-slides-python
```

## **لماذا صورة الأساس هي Debian 11**

العجلة `aspose.slides` تحزم بيئة تشغيل **.NET Core 3.1**، وهذه البيئة أقدم من إصدارات المكتبات الموجودة في إصدارات Debian الحالية. على Debian 12 و13 تُبنى الحاوية بنجاح ثم تفشل عند أول نداء لـ `Presentation()`:

```
Process terminated. Couldn't find a valid ICU package installed on the system.
```

الرسالة مضللة — ICU *موجود* في تلك الصور، لكنه إصدار 72 أو 76، و .NET Core 3.1 يتعرف فقط على الإصدارات القديمة. بالإضافة إلى ذلك، Debian 12 يوزع OpenSSL 3، مما يسبب فشلًا ثانيًا:

```
No usable version of libssl was found
```

الصورة `python:3.11-slim-bullseye` هي Debian 11، وتوفر كلا الإصدارين اللذين تتوقعهما بيئة التشغيل المدمجة:

| Package | Version on Debian 11 | Why it is needed |
|---|---|---|
| `libgdiplus` | 6.0.4 | تنفيذ GDI+ المستخدم في رسم الأشكال والنصوص والصور |
| `libicu67` | 67.1 | بيانات التعريب. الإصدارات الأحدث غير معروفة لـ .NET Core 3.1 |
| `libssl1.1` | 1.1.1w | التشفير. مثبت مسبقًا في Debian 11؛ غير موجود في Debian 12+ |
| `libfontconfig1` | — | اكتشاف الخطوط |

`libssl1.1` موجود بالفعل في صورة الأساس، لذا لا يحتاج إلى الإدراج في `apt-get install`.

إذا اضطررت لاستخدام صورة أساسية أحدث، اضبط المتغيّر `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1` لتجاوز متطلب ICU. هذا يعطل التنسيق المتعلق بالثقافات ولا **يحَل** مشكلة OpenSSL، لذا يظل Debian 11 الخيار الأسهل.

## **الخطوط**

الصور الخفيفة لا تحتوي على أي خطوط. بدون وجود خط واحد على الأقل، يتم عرض النص كصناديق فارغة في مخرجات PDF والصورة وHTML. الحزمة `fonts-dejavu-core` تمثل نقطة بداية عامة صغيرة.

للتطابق مع المظهر المقصود للعرض، انسخ الخطوط التي يستخدمها إلى الصورة ووجّه Aspose.Slides إلى موقعها:

```dockerfile
COPY fonts/ /usr/share/fonts/truetype/custom/
RUN fc-cache -f
```

```py
import aspose.slides as slides

slides.FontsLoader.load_external_fonts(["/usr/share/fonts/truetype/custom/"])
```

## **الترخيص داخل حاوية**

لا تُدمج ملف الترخيص داخل الصورة — أي شخص يسحب الصورة يحصل على الترخيص. قم بتحميله عند التشغيل بدلًا من ذلك:

```bash
docker run --rm -v /path/on/host:/license aspose-slides-python
```

```py
import aspose.slides as slides

license = slides.License()
license.set_license("/license/Aspose.Slides.Python.NET.lic")
```

بدون ترخيص تعمل المكتبة في وضع التقييم، مما يضيف علامة مائية ويحد من عدد الشرائح التي يمكن معالجتها. راجع [الترخيص](/slides/ar/python-net/licensing/) للحصول على التفاصيل.

## **الذاكرة**

إنشاء PDF أو الصور يستهلك ذاكرة أكثر من مجرد قراءة ملف. الحاويات ذات حدود ذاكرة ضيقة قد يتم إنهاؤها بواسطة OOM killer أثناء التحويل، وعادةً ما يظهر ذلك كاختفاء العملية دون أثر تتبع في Python. إذا حدث ذلك، ارفع حد الذاكرة للحاوية قبل فحص الشيفرة.