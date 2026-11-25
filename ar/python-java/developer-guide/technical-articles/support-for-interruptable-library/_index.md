---
title: إيقاف عمليات العرض التقديمي طويلة الأمد في بايثون
linktitle: إيقاف عمليات العرض التقديمي
type: docs
weight: 120
url: /ar/python-java/support-for-interruptable-library/
keywords:
- عمليات قابلة للإيقاف
- رمز الإيقاف
- رمز الإلغاء
- مهمة طويلة الأمد
- إيقاف مهمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تعلم كيفية إلغاء عمليات العرض التقديمي طويلة الأمد في Aspose.Slides للبايثون عبر جافا وإرجاع نتيجة جزئية عند تصدير الشرائح في حلقة."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for Python عبر Java إيقاف العمليات التي تستغرق وقتًا طويلاً مثل تحميل العروض التقديمية وحفظها وعرضها. يمكن لتطبيقك استخدام رمز الإيقاف نفسه لإيقاف حلقة قبل أن تبدأ بمعالجة الشريحة التالية.

## **إيقاف عملية عرض تقديمي**

أنشئ [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)، واحصل على رمزه باستخدام [getToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#getToken)، ثم مرّر الرمز إلى [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken). مرّر خيارات التحميل إلى [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/). لطلب الإلغاء، استدعِ [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) على المصدر. تتوقف العملية القابلة للإيقاف عندما تلاحظ الطلب. استخدم `jpype.JClass` لالتقاط استثناء جافا `com.aspose.slides.exceptions.OperationCanceledException` في بايثون.

المثال يحوّل `sample.pptx` إلى `sample.ppt` في خيط خلفي. ينتظر الخيط المستدعي حتى 10 ثوانٍ لإنهاء التحويل. إذا كان التحويل لا يزال قيد التشغيل، يطلب الإلغاء وينتظر انتهاء العامل.

```python
from concurrent.futures import ThreadPoolExecutor, TimeoutError

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def convert_presentation(source):
    options = LoadOptions()
    options.setInterruptionToken(source.getToken())
    try:
        presentation = Presentation("sample.pptx", options)
        try:
            presentation.save("sample.ppt", SaveFormat.Ppt)
        finally:
            presentation.dispose()
    except OperationCanceledException:
        print("Conversion canceled")


source = InterruptionTokenSource()
with ThreadPoolExecutor(max_workers=1) as executor:
    conversion = executor.submit(convert_presentation, source)
    try:
        conversion.result(timeout=10)
    except TimeoutError:
        source.interrupt()
        conversion.result()
```

## **ربط مهلة بايثون بـ Aspose.Slides**

لتعيين حد زمني لعملية عرض تقديمي، استخدم [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) لاستدعاء [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) عندما تنتهي المهلة. يسمح المثال بـ 20 ثانية لتحميل `sample.pptx` وتصديره إلى `sample.pdf`. إذا انتهى التصدير مبكرًا، يلغي التطبيق الطلب المجدول.

```python
from threading import Timer

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")

source = InterruptionTokenSource()
options = LoadOptions()
options.setInterruptionToken(source.getToken())

timer = Timer(20, source.interrupt)
timer.start()
try:
    presentation = Presentation("sample.pptx", options)
    try:
        presentation.save("sample.pdf", SaveFormat.Pdf)
    finally:
        presentation.dispose()
except OperationCanceledException:
    print("Presentation processing was canceled")
finally:
    timer.cancel()
    timer.join()
```

## **التوقف قبل معالجة الشريحة التالية**

استخدم نفس [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) للعرض التقديمي والحلقة التي تصدّر شرائحه. افحص [isInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#isInterruptionRequested) قبل كل عملية تصدير. إذا كان المستدعي يمكنه استخدام نتيجة جزئية، أرجع أرقام الشرائح التي تم تصديرها بنجاح.

استخدم عرضًا تقديميًا اسمه `sample.pptx` يحتوي على شريحتين على الأقل. التحميل الزائد لـ [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) الذي يأخذ مصفوفة جافا `int[]` يستخدم أرقام الشرائح بدءًا من 1. استخدم `jpype.JArray(jpype.JInt)` لإنشاء تلك المصفوفة في بايثون. المثال يحفظ كل شريحة في ملف PDF منفصل ويطلب الإلغاء فور تسجيل أول تصدير ناجح.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def export_slides(path, source):
    completed = []
    token = source.getToken()
    options = LoadOptions()
    options.setInterruptionToken(token)
    presentation = Presentation(path, options)
    try:
        for number in range(1, presentation.getSlides().size() + 1):
            if token.isInterruptionRequested():
                break

            print(f"Starting slide {number}")
            slide_numbers = jpype.JArray(jpype.JInt)([number])
            try:
                presentation.save(f"slide-{number}.pdf", slide_numbers, SaveFormat.Pdf)
            except OperationCanceledException:
                if token.isInterruptionRequested():
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()
        return completed
    finally:
        presentation.dispose()


source = InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

يقوم المثال بكتابة `slide-1.pdf` ويطبع `Starting slide 1` ثم `Completed: [1]`. تلاحظ الحلقة الطلب قبل بدء الشريحة 2. إذا وصل الإلغاء أثناء الحفظ، تخرج الحلقة قبل تسجيل تلك الشريحة كمنجزة.

إذا كان المستدعي يحتاج إلى معالجة الإلغاء، استبدل الفحص و`break` في بداية الحلقة بـ `token.throwIfInterruptionRequested()`. احذف الـ `try`/`except` حول الحفظ حتى يصل الإلغاء أثناء التصدير إلى المستدعي. باستخدام نفس المدخلات، يطبع المثال فقط `Starting slide 1` ويكتب `slide-1.pdf`. عند بدء التكرار الثاني، يرفع [throwIfInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) استثناء `com.aspose.slides.exceptions.OperationCanceledException` قبل بدء التصدير التالي. ينتقل الاستثناء إلى المستدعي قبل أن تتمكن الدالة من إرجاع القائمة.

## **الأسئلة المتكررة**

**متى يجب أن أطلب الإلغاء؟**

اطلب الإلغاء عندما تتجاوز العملية حدك الزمني أو عندما لا يحتاج تطبيقك إلى النتيجة بعد الآن.

**ما الفرق بين [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) و[InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)?**

المصدر يسمح لتطبيقك بطلب الإلغاء. الرمز يسمح لـ Aspose.Slides وتطبيقك بالتحقق من هذا الطلب.

**هل يمكنني إلغاء عملية من مؤقت بايثون؟**

نعم. جدولة استدعاء [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) على المصدر المرتبط بالعرض التقديمي.

**ما العمليات التي يمكنني إيقافها؟**

يمكنك إيقاف التحميل والحفظ والعرض. مرّر الرمز إلى [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) عبر [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken). يمكن للعرض التقديمي بعد ذلك ملاحظة الإلغاء خلال العمليات اللاحقة مثل الحفظ إلى PDF.

**هل تتوقف العملية فورًا؟**

الإلغاء تعاوني. تتحقق العملية من الرمز بشكل دوري وتتوقف عندما تلاحظ الطلب.

**ماذا يحدث إذا استدعيت [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) بعد انتهاء عملية؟**

تحافظ العملية المكتملة على نتيجتها.

**هل يمكن لعدة عمليات مشاركة [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)?**

نعم. استدعاء [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) يطلب الإلغاء لكل عملية تستخدم رمزًا من ذلك المصدر. استخدم مصدرًا منفصلًا لكل عملية تريد إلغائها بشكل مستقل.