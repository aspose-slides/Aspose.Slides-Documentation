---
title: مقارنة شرائح العرض التقديمي في جافا
linktitle: مقارنة الشرائح
type: docs
weight: 50
url: /ar/java/compare-slides/
keywords:
- مقارنة الشرائح
- مقارنة الشريحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "قارن عروض PowerPoint وOpenDocument برمجيًا باستخدام Aspose.Slides للجافا. حدد اختلافات الشرائح في الشيفرة بسرعة."
---

## **قارن شريحتين**
تمت إضافة طريقة Equals إلى واجهة [IBaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide) والفئة [BaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/BaseSlide). تُعيد true للشرائح/التخطيط والشرائح الرئيسية التي تكون متطابقة من حيث الهيكل والمحتوى الثابت.

تكون الشريحتان متساويتين إذا كانت جميع الأشكال والأنماط والنصوص والرسوم المتحركة والإعدادات الأخرى، إلخ، متساوية. لا تأخذ المقارنة في الاعتبار قيم المعرفات الفريدة، مثل SlideId، والمحتوى الديناميكي، مثل قيمة التاريخ الحالية في العنصر النائب Date Placeholder.
```java
Presentation presentation1 = new Presentation("AccessSlides.pptx");
try {
    Presentation presentation2 = new Presentation("HelloWorld.pptx");
    try {
        for (int i = 0; i < presentation1.getMasters().size(); i++)
        {
            for (int j = 0; j < presentation2.getMasters().size(); j++)
            {
                if (presentation1.getMasters().get_Item(i).equals(presentation2.getMasters().get_Item(j)))
                    System.out.println(String.format("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", i, j));
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```


## **الأسئلة المتكررة**

**هل يؤثر كون الشريحة مخفية على مقارنة الشرائح نفسها؟**

[حالة مخفية](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#getHidden--) هي خاصية على مستوى العرض/التشغيل، ليست محتوى بصري. يتم تحديد مساواة شريحتين محددتين بناءً على هيكلهما ومحتواهما الثابت؛ مجرد كون الشريحة مخفية لا يجعل الشرائح مختلفة.

**هل يتم أخذ الروابط التشعبية ومعلماتها في الاعتبار؟**

نعم. الروابط هي جزء من المحتوى الثابت للشريحة. إذا كان عنوان URL أو إجراء الرابط التشعبي مختلفًا، فإن ذلك يُعامل عادةً كاختلاف في المحتوى الثابت.

**إذا كان الرسم البياني يشير إلى ملف Excel خارجي، هل سيتم أخذ محتويات هذا الملف في الاعتبار؟**

لا. يتم إجراء المقارنة بناءً على الشرائح نفسها. عادةً لا يتم قراءة مصادر البيانات الخارجية في وقت المقارنة؛ فقط ما هو موجود في بنية الشريحة وحالتها الثابتة يُؤخذ في الاعتبار.