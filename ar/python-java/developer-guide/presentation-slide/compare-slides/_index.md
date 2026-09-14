---
title: مقارنة شرائح العرض التقديمي في بايثون
linktitle: مقارنة الشرائح
type: docs
weight: 50
url: /ar/python-java/compare-slides/
keywords:
- مقارنة الشرائح
- مقارنة الشرائح
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "قارن عروض PowerPoint و OpenDocument برمجيًا باستخدام Aspose.Slides لبايثون عبر Java. حدد اختلافات الشرائح في الكود بسرعة."
---
## **نظرة عامة**

Aspose.Slides يتيح لك مقارنة الشرائح، شرائح التخطيط، والشرائح القالب باستخدام طريقة [equals](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslide/#equals) المقدمة من الفئة [BaseSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslide/). تُعيد هذه الطريقة `True` عندما تكون الشرائح التي تم مقارنةها متطابقة في هيكلهَا والمحتوى الثابت.

## **مقارنة شريحتين**

طريقة [equals](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslide/#equals) في الفئة [BaseSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslide/) تُعيد `True` للشرائح، شرائح التخطيط، والشرائح القالب التي تكون متطابقة في الهيكلة والمحتوى الثابت.

تكون الشريحتان متساويتين إذا كانت جميع الأشكال، الأنماط، النصوص، الرسوم المتحركة، والإعدادات الأخرى متساوية. لا تأخذ المقارنة في الاعتبار قيم المعرف الفريدة، مثل معرّفات الشرائح، أو المحتوى الديناميكي، مثل التاريخ الحالي في عنصر نائب للتاريخ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

source_presentation = Presentation("AccessSlides.pptx")
try:
    target_presentation = Presentation("HelloWorld.pptx")
    try:
        for i in range(source_presentation.getMasters().size()):
            for j in range(target_presentation.getMasters().size()):
                if source_presentation.getMasters().get_Item(i).equals(target_presentation.getMasters().get_Item(j)):
                    print(f"AccessSlides MasterSlide#{i} is equal to HelloWorld MasterSlide#{j}")
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **الأسئلة المتكررة**

**هل يؤثر إخفاء الشريحة على مقارنة الشرائح نفسها؟**

[Hidden status](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#getHidden) هي خاصية على مستوى العرض/التشغيل، وليست محتوى مرئي. يتم تحديد مساواة شريحتين محددتين بناءً على هيكليهما والمحتوى الثابت؛ مجرد إخفاء الشريحة لا يجعل الشرائح مختلفة.

**هل تُؤخذ الروابط الفائقة ومعاملاتها في الاعتبار؟**

نعم. الروابط هي جزء من المحتوى الثابت للشرائح. إذا كان عنوان URL أو إجراء الارتباط مختلفًا، فغالبًا ما يُعامل ذلك كاختلاف في المحتوى الثابت.

**إذا كان الرسم البياني يشير إلى ملف Excel خارجي، هل يُؤخذ محتوى ذلك الملف في الاعتبار؟**

لا. تُجرى المقارنة بناءً على الشرائح نفسها. عادةً لا يتم قراءة مصادر البيانات الخارجية أثناء عملية المقارنة؛ يُؤخذ في الاعتبار فقط ما هو موجود في هيكلة الشريحة وحالتها الثابتة.