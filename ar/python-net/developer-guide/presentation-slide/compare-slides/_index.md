---
title: مقارنة شرائح العرض التقديمي في بايثون
linktitle: مقارنة الشرائح
type: docs
weight: 50
url: /ar/python-net/compare-slides/
keywords:
- مقارنة الشرائح
- مقارنة الشرائح
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "قارن عروض PowerPoint وOpenDocument برمجيًا باستخدام Aspose.Slides للغة بايثون عبر .NET. حدد اختلافات الشرائح في الشيفرة بسرعة."
---

## **مقارنة شريحتين**
تمت إضافة طريقة Equals إلى واجهة [IBaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/) والفئة [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/). تُعيد true للشرائح/التخطيطات والشرائح الرئيسية التي تكون متطابقة في هيكلها ومحتواها الثابت.

تكون شريحتان متساويتان إذا كانت جميع الأشكال، والأنماط، والنصوص، والرسوم المتحركة، والإعدادات الأخرى... إلخ متطابقة. لا يأخذ المقارنة في الاعتبار قيم المعرف الفريدة، مثل SlideId، ولا المحتوى الديناميكي، مثل قيمة التاريخ الحالية في عنصر النائب Date Placeholder.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as p1:
    with slides.Presentation(path + "HelloWorld.pptx") as p2:
        for i in range(len(p1.masters)):
            for j in range(len(p2.masters)):
                if p1.masters[i] == p2.masters[j]:
                    print("Presentation1 MasterSlide#{0} is equal to Presentation2 MasterSlide#{1}".format(i,j))
```

## **الأسئلة المتداولة**

**هل يؤثر كون الشريحة مخفية على مقارنة الشرائح نفسها؟**

الخاصية [Hidden status](https://reference.aspose.com/slides/python-net/aspose.slides/slide/hidden/) هي خاصية على مستوى العرض التقديمي/التشغيل، ليست محتوى بصري. يتم تحديد مساواة شريحتين محددتين بناءً على هيكلهما ومحتواهما الثابت؛ وحقيقة أن الشريحة مخفية لا تجعل الشرائح مختلفة.

**هل تُؤخذ الروابط التشعبية ومعلماتها في الاعتبار؟**

نعم. الروابط جزء من المحتوى الثابت للشريحة. إذا اختلف URL أو إجراء الارتباط التشعبي، فغالبًا ما يُعامل ذلك كاختلاف في المحتوى الثابت.

**إذا كان المخطط يشير إلى ملف Excel خارجي، هل تُؤخذ محتويات ذلك الملف في الاعتبار؟**

لا. يتم إجراء المقارنة استنادًا إلى الشرائح نفسها. عادةً لا يتم قراءة مصادر البيانات الخارجية أثناء المقارنة؛ يُؤخذ في الاعتبار فقط ما هو موجود في هيكل الشريحة وحالتها الثابتة.