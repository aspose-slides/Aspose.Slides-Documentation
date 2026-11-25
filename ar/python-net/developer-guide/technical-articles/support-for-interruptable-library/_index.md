---
title: إيقاف عمليات العرض التقديمي طويلة الأمد في بايثون
linktitle: إيقاف عمليات العرض التقديمي
type: docs
weight: 150
url: /ar/python-net/support-for-interruptable-library/
keywords:
- عمليات قابلة للمقاطعة
- رمز مقاطعة
- إلغاء تصدير PDF
- PowerPoint
- Python
- Aspose.Slides
description: "تعلم كيفية إلغاء تحويل عرض تقديمي في بايثون وإرجاع قائمة الشرائح التي انتهى تصديرها قبل الإلغاء."
---
## **نظرة عامة**

تدعم Aspose.Slides للغة Python عبر .NET الإلغاء التعاوني أثناء العمليات الطويلة مثل تحميل العروض، حفظها، وتصيير العروض التقديمية. عند تصدير الشرائح بشكل منفصل، يمكنك أيضًا فحص الإلغاء بين الشرائح وإرجاع أرقام الشرائح التي انتهى تصديرها.

## **إلغاء تحويل العرض التقديمي**

إنشاء [InterruptionTokenSource](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/)، عيّن [token](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/token/) إلى [LoadOptions.interruption_token](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/interruption_token/)، ومرّر الخيارات إلى [Presentation constructor](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/__init__/). يطبق الرمز المميز على العرض التقديمي طوال عمره. لطلب الإلغاء من تطبيقك، استدعِ [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/interrupt/).

المثال يحول `sample.pptx` إلى `sample.pdf`. تستدعي [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) الدالة `source.interrupt` بعد 20 ثانية. بدء المؤقت قبل فتح الملف يجعل مهلة الوقت تنطبق على كل من التحميل والحفظ. يمكن لتطبيق يحتوي على زر إلغاء استدعاء الطريقة نفسها من معالج الحدث الخاص به.

```python
from threading import Timer

import aspose.slides as slides

source = slides.InterruptionTokenSource()
options = slides.LoadOptions()
options.interruption_token = source.token
timer = Timer(20, source.interrupt)

timer.start()
try:
    with slides.Presentation("sample.pptx", options) as presentation:
        options.interruption_token.throw_if_interruption_requested()
        presentation.save("sample.pdf", slides.export.SaveFormat.PDF)
finally:
    timer.cancel()
    timer.join()
```

يتخطى الفحص الصريح بعد التحميل عملية التصدير إذا كانت المهلة قد انتهت بالفعل. إذا لاحظ التحميل أو الحفظ طلب الإلغاء، فإن استثناء الإلغاء يصل إلى المستدعي. قد يكتمل الحفظ أيضًا قبل ملاحظة الطلب، وفي هذه الحالة يكون ملف PDF مكتملًا.

## **التوقف قبل معالجة الشريحة التالية**

تحقق من [InterruptionToken.is_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/is_interruption_requested/) قبل كل عملية تصدير. تقبل [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) قائمة بأرقام الشرائح بدءًا من 1. أضف رقمًا إلى القائمة المكتملة فقط بعد حفظ ملف PDF الخاص به بنجاح.

استخدم ملفًا يُدعى `sample.pptx` يحتوي على شريحتين على الأقل. لجعل النتيجة قابلة للتكرار، يطلب المثال الإلغاء فور انتهاء الشريحة 1. في تطبيق، يمكن أن يأتي الطلب من خيط آخر أثناء حفظ شريحة.

```python
import aspose.slides as slides


def export_slides(path, source):
    completed = []
    token = source.token
    options = slides.LoadOptions()
    options.interruption_token = token

    with slides.Presentation(path, options) as presentation:
        for number in range(1, len(presentation.slides) + 1):
            if token.is_interruption_requested:
                break

            print(f"Starting slide {number}")
            try:
                presentation.save(f"slide-{number}.pdf", [number], slides.export.SaveFormat.PDF)
            except slides.AsposeSlidesException as error:
                if token.is_interruption_requested and "System.OperationCanceledException" in str(error):
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()

    return completed


source = slides.InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

يقوم المثال بكتابة `slide-1.pdf` ويطبع `Starting slide 1` يتبعها `Completed: [1]`. ترى التكرار التالي الطلب قبل بدء الشريحة 2. إذا قاطع الإلغاء عملية الحفظ، يُعيد معالج الاستثناء الأرقام المسجلة في التكرارات السابقة. تصل أخطاء التصدير الأخرى إلى المستدعي.

إذا كان على المستدعي معالجة الإلغاء كاستثناء، استبدل الفحص وعبارة `break` في أعلى الحلقة بـ [token.throw_if_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/throw_if_interruption_requested/). احذف أيضًا الكتلة `try`/`except` حول عملية الحفظ. باستخدام نفس المدخلات، تُحفظ الشريحة 1 وتثير التكرارة الثانية استثناء إلغاء قبل بدء الشريحة 2.

## **التعليمات المتكررة**

**متى يصبح طلب الإلغاء ساريًا؟**

تقوم العملية القابلة للمقاطعة بفحص الرمز المميز الخاص بها بشكل دوري. تتوقف عندما تلاحظ الطلب. العملية التي انتهت بالفعل تحتفظ بنتيجتها.

**ما الفرق بين المصدر والرمز المميز؟**

يتيح المصدر لتطبيقك طلب الإلغاء. يتيح الرمز المميز لكل من العرض التقديمي وكودك الخاص فحص هذا الطلب.

**هل يمكن لعدة عمليات مشاركة مصدر واحد؟**

نعم. استدعاء `interrupt` يطلب إلغاءً لكل عملية تستخدم رمزًا مميزًا من ذلك المصدر. قدم لكل عملية مصدرها الخاص إذا كنت بحاجة إلى إلغائه بشكل مستقل.