---
title: مقارنة شرائح العرض التقديمي على Android
linktitle: مقارنة الشرائح
type: docs
weight: 50
url: /ar/androidjava/compare-slides/
keywords:
- مقارنة الشرائح
- مقارنة الشريحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "قارن عروض PowerPoint وOpenDocument برمجيًا باستخدام Aspose.Slides لـ Android. حدد اختلافات الشرائح في كود Java بسرعة."
---

## **قارن شريحتين**
تمت إضافة طريقة Equals إلى واجهة [IBaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide) وفئة [BaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BaseSlide). تُعيد القيمة true للشريحة/التخطيط والشريحة/الرئيسية التي تكون متطابقة في بنيتها والمحتوى الثابت.

تكون الشريحتان متساويتين إذا كان جميع الأشكال والأنماط والنصوص والرسوم المتحركة والإعدادات الأخرى، إلخ، متساوية. لا تأخذ المقارنة في الاعتبار قيم المعرفات الفريدة، مثل SlideId، والمحتوى الديناميكي، مثل قيمة التاريخ الحالية في Date Placeholder.
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

[Hidden status](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slide/#getHidden--) هي خاصية مستوى العرض/التشغيل في العرض التقديمي، ليست محتوى مرئي. يتم تحديد مساواة شريحتين محددتين من خلال بنيتهما والمحتوى الثابت؛ مجرد كون الشريحة مخفية لا يجعل الشرائح مختلفة.

**هل تُؤخذ الروابط التشعبية ومعلماتها في الحسبان؟**

نعم. الروابط هي جزء من المحتوى الثابت للشريحة. إذا كان عنوان URL أو فعل الرابط التشعبي مختلفًا، فغالبًا ما يُعامل ذلك كاختلاف في المحتوى الثابت.

**إذا كان المخطط يشير إلى ملف Excel خارجي، هل يُؤخذ محتوى ذلك الملف في الاعتبار؟**

لا. تُجرى المقارنة بناءً على الشرائح نفسها. عادةً لا يتم قراءة مصادر البيانات الخارجية في وقت المقارنة؛ يتم اعتبار ما هو موجود فقط في بنية الشريحة وحالتها الثابتة.