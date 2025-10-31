---
title: قارن شرائح العرض التقديمي في بايثون
linktitle: قارن الشرائح
type: docs
weight: 50
url: /ar/python-net/compare-slides/
keywords:
- قارن الشرائح
- مقارنة الشرائح
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "قارن عروض PowerPoint وOpenDocument برمجيًا باستخدام Aspose.Slides for Python عبر .NET. حدد اختلافات الشرائح في الكود بسرعة."
---

## **قارن شريحتين**
تمت إضافة طريقة Equals إلى واجهة [IBaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/) وفئة [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/). تُرجع true للشرائح/التخطيطات والشرائح الرئيسة المتطابقة من حيث الهيكل والمحتوى الثابت.

تكون الشريحتان متساويتين إذا كانت جميع الأشكال، الأنماط، النصوص، الحركات والإعدادات الأخرى متطابقة، إلخ. لا يأخذ المقارنة في الاعتبار قيم المعرفات الفريدة، مثل SlideId، ولا المحتوى الديناميكي، مثل قيمة التاريخ الحالية في العنصر النائب للتاريخ.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as p1:
    with slides.Presentation(path + "HelloWorld.pptx") as p2:
        for i in range(len(p1.masters)):
            for j in range(len(p2.masters)):
                if p1.masters[i] == p2.masters[j]:
                    print("Presentation1 MasterSlide#{0} is equal to Presentation2 MasterSlide#{1}".format(i,j))
```

## **الأسئلة المتكررة**

**هل يؤثر كون الشريحة مخفية على مقارنة الشرائح نفسها؟**

[Hidden status](https://reference.aspose.com/slides/python-net/aspose.slides/slide/hidden/) هي خاصية على مستوى العرض/التشغيل، ليست محتوى بصري. يتم تحديد مساواة شريحتين محددتين بناءً على هيكليهما والمحتوى الثابت؛ مجرد كون الشريحة مخفية لا يجعل الشرائح مختلفة.

**هل يتم أخذ الروابط الفائقة ومعلماتها في الاعتبار؟**

نعم. الروابط جزء من المحتوى الثابت للشريحة. إذا كان عنوان URL أو إجراء الارتباط مختلفًا، يُعامل عادةً كاختلاف في المحتوى الثابت.

**إذا كان المخطط يشير إلى ملف Excel خارجي، هل يتم أخذ محتويات ذلك الملف في الاعتبار؟**

لا. يتم إجراء المقارنة بناءً على الشرائح نفسها. عادةً لا يتم قراءة مصادر البيانات الخارجية في وقت المقارنة؛ فقط ما هو موجود في هيكل الشريحة وحالتها الثابتة يُؤخذ في الاعتبار.