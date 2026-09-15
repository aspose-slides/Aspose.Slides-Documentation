---
title: دعم مكتبة قابلة للمقاطعة
type: docs
weight: 120
url: /ar/python-java/support-for-interruptable-library/
keywords:
- مكتبة قابلة للمقاطعة
- رمز المقاطعة
- رمز الإلغاء
- مهمة طويلة الأمد
- مقاطعة المهمة
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "اجعل المهام الطويلة قابلة للإلغاء باستخدام Aspose.Slides لـ Python عبر Java. قم بمقاطعة العرض والتحويلات لـ PowerPoint و OpenDocument بأمان، مع أمثلة."
---
## **نظرة عامة**

توفر Aspose.Slides آلية معالجة قابلة للمقاطعة للمهام الطويلة الأمد الخاصة بالعروض التقديمية، مثل فك التسلسل، التسلسل، وعرض الرسومات. تستند هذه الآلية إلى الفئتين [InterruptionToken](https://reference.aspose.com/slides/ar/python-java/aspose.slides/interruptiontoken/) و [InterruptionTokenSource](https://reference.aspose.com/slides/ar/python-java/aspose.slides/interruptiontokensource/).

يمكن تعيين [InterruptionToken](https://reference.aspose.com/slides/ar/python-java/aspose.slides/interruptiontoken/) إلى [LoadOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/) وتمريره إلى مُنشىء [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/). عندما يتم استدعاء [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/interruptiontokensource/#interrupt)، يتم مقاطعة المهمة الطويلة المرتبطة.

## **مكتبة قابلة للمقاطعة**

توفر Aspose.Slides لـ Python عبر Java الفئتين [InterruptionToken](https://reference.aspose.com/slides/ar/python-java/aspose.slides/interruptiontoken/) و [InterruptionTokenSource](https://reference.aspose.com/slides/ar/python-java/aspose.slides/interruptiontokensource/). تتيح لكما مقاطعة المهام الطويلة مثل فك التسلسل، التسلسل، والعرض.

- [InterruptionTokenSource](https://reference.aspose.com/slides/ar/python-java/aspose.slides/interruptiontokensource/) هو المصدر للرموز (token) التي يتم تمريرها إلى [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#setInterruptionToken).
- عند استدعاء [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#setInterruptionToken) وتمرير مثيل [LoadOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/) إلى مُنشىء [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/)، يؤدي استدعاء [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/interruptiontokensource/#interrupt) إلى مقاطعة أي عملية طويلة الأمد مرتبطة بذلك [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).

```python
from concurrent.futures import ThreadPoolExecutor
import time

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat


token_source = InterruptionTokenSource()


def convert_presentation():
    load_options = LoadOptions()
    load_options.setInterruptionToken(token_source.getToken())

    presentation = Presentation("sample.pptx", load_options)
    try:
        presentation.save("sample.ppt", SaveFormat.Ppt)
    finally:
        presentation.dispose()


with ThreadPoolExecutor(max_workers=1) as executor:
    conversion_task = executor.submit(convert_presentation)  # تشغيل الإجراء في خيط منفصل.
    time.sleep(10)  # انتهت المهلة.
    token_source.interrupt()  # إيقاف التحويل.
    conversion_task.result()
```

## **الأسئلة الشائعة**

**ما هو هدف مكتبة مقاطعة Aspose.Slides؟**

توفر آلية لمقاطعة العمليات الطويلة — مثل تحميل العروض، حفظها، أو عرضها — قبل إكمالها. يكون ذلك مفيدًا عندما يجب تحديد وقت المعالجة أو عندما لا تكون المهمة مطلوبة بعد.

**ما الفرق بين [InterruptionToken](https://reference.aspose.com/slides/ar/python-java/aspose.slides/interruptiontoken/) و [InterruptionTokenSource](https://reference.aspose.com/slides/ar/python-java/aspose.slides/interruptiontokensource/)?**

- [InterruptionToken](https://reference.aspose.com/slides/ar/python-java/aspose.slides/interruptiontoken/) يتم تمريره إلى API الخاص بـ Aspose.Slides ويتم فحصه أثناء العمليات الطويلة.
- [InterruptionTokenSource](https://reference.aspose.com/slides/ar/python-java/aspose.slides/interruptiontokensource/) يُستخدم في التعليمات البرمجية الخاصة بك لإنشاء الرموز وتفعيل المقاطعة عن طريق استدعاء [interrupt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/interruptiontokensource/#interrupt).

**ما هي المهام التي يمكن مقاطعتها؟**

يمكن مقاطعة أي مهمة من Aspose.Slides تقبل [InterruptionToken](https://reference.aspose.com/slides/ar/python-java/aspose.slides/interruptiontoken/) — مثل تحميل عرض تقديمي باستخدام [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) أو حفظه باستخدام [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) —.

**هل تحدث المقاطعة فورًا؟**

لا. المقاطعة تعاونية: تقوم العملية بفحص الرمز بشكل دوري وتتوقف بمجرد اكتشاف أنه تم استدعاء [interrupt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/interruptiontokensource/#interrupt).

**ماذا يحدث إذا استدعيت [interrupt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/interruptiontokensource/#interrupt) بعد إكمال المهمة بالفعل؟**

لا شيء — لا يؤثر الاستدعاء إذا كانت المهمة المعنية قد انتهت بالفعل.

**هل يمكنني إعادة استخدام نفس [InterruptionTokenSource](https://reference.aspose.com/slides/ar/python-java/aspose.slides/interruptiontokensource/) لعدة مهام؟**

نعم — ولكن بعد استدعاء [interrupt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/interruptiontokensource/#interrupt) على ذلك المصدر، ستُقطع جميع المهام التي تستخدم رموزه. استخدم مصادر رموز منفصلة لإدارة المهام بشكل مستقل.