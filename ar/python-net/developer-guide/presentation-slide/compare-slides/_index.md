---
title: مقارنة شرائح العرض في بايثون
linktitle: مقارنة الشرائح
type: docs
weight: 50
url: /ar/python-net/compare-slides/
keywords:
- مقارنة الشرائح
- مقارنة الشرائح
- PowerPoint
- OpenDocument
- عرض
- Python
- Aspose.Slides
description: "قارن عروض PowerPoint و OpenDocument برمجيًا باستخدام Aspose.Slides لبايثون عبر .NET. حدد اختلافات الشرائح في الكود بسرعة."
---

## **قارن شريحتين**
تمت إضافة طريقة Equals إلى الواجهة [IBaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/) والفئة [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/). تعيد true للشرائح/التخطيطات والشرائح/الرئيسية التي تكون مطابقة في هيكلها والمحتوى الثابت.

تكون الشريحتان متساويتين إذا كانت جميع الأشكال والأنماط والنصوص والرسوم المتحركة والإعدادات الأخرى ... . لا تأخذ المقارنة في الاعتبار قيم المعرفات الفريدة، مثل SlideId، والمحتوى الديناميكي، مثل قيمة التاريخ الحالية في عنصر نائب التاريخ.
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

[Hidden status](https://reference.aspose.com/slides/python-net/aspose.slides/slide/hidden/) هي خاصية على مستوى العرض/التشغيل، وليست محتوى بصري. يتم تحديد مساواة شريحتين محددتين بواسطة هيكلهما والمحتوى الثابت؛ مجرد كون الشريحة مخفية لا يجعل الشرائح مختلفة.

**هل تُؤخذ الروابط الفائقة ومعلماتها في الاعتبار؟**

نعم. الروابط هي جزء من المحتوى الثابت للشريحة. إذا اختلف URL أو إجراء الرابط الفائق، يُعامل ذلك عادةً كفرق في المحتوى الثابت.

**إذا كان المخطط يشير إلى ملف Excel خارجي، هل سيتم أخذ محتويات ذلك الملف في الاعتبار؟**

لا. يتم إجراء المقارنة بناءً على الشرائح نفسها. عادةً لا يتم قراءة مصادر البيانات الخارجية أثناء المقارنة؛ يُؤخذ فقط ما هو موجود في هيكل الشريحة وحالتها الثابتة في الاعتبار.