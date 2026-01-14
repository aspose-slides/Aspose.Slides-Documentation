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
description: "قارن عروض PowerPoint و OpenDocument برمجيًا باستخدام Aspose.Slides للبايثون عبر .NET. حدد اختلافات الشرائح في الكود بسرعة."
---

## **مقارنة شريحتين**
تمت إضافة طريقة `equals` إلى الفئة [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/) . تعيد true للشرائح/التخطيطات والشرائح/الرئيسية التي تكون متطابقة في هيكلها والمحتوى الثابت لها.

تكون الشريحتان متساويتين إذا كانت جميع الأشكال والأنماط والنصوص والرسوم المتحركة والإعدادات الأخرى متطابقة، إلخ. لا يأخذ المقارنة في الاعتبار قيم المعرفات الفريدة، مثل SlideId، أو المحتوى الديناميكي، مثل قيمة التاريخ الحالية في Date Placeholder.
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
[Hidden status](https://reference.aspose.com/slides/python-net/aspose.slides/slide/hidden/) هي خاصية على مستوى العرض/التشغيل، وليست محتوى مرئي. يتم تحديد مساواة شريحتين محددتين من خلال هيكلهما والمحتوى الثابت لهما؛ مجرد أن تكون الشريحة مخفية لا يجعل الشرائح مختلفة.

**هل يتم أخذ الارتباطات التشعبية ومعلماتها في الاعتبار؟**
نعم. الارتباطات هي جزء من المحتوى الثابت للشريحة. إذا اختلف عنوان URL أو إجراء الارتباط التشعبي، يُعامل ذلك عادةً كاختلاف في المحتوى الثابت.

**إذا كان المخطط يشير إلى ملف Excel خارجي، هل سيتم أخذ محتويات ذلك الملف في الاعتبار؟**
لا. يتم إجراء المقارنة بناءً على الشرائح نفسها. عادةً لا يتم قراءة مصادر البيانات الخارجية في وقت المقارنة؛ يتم اعتبار ما هو موجود فقط في هيكل الشريحة وحالتها الثابتة.