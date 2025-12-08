---
title: قارن الشرائح
type: docs
weight: 50
url: /ar/net/compare-slides/
keywords: "قارن شرائح PowerPoint, قارن شريحتين, عرض تقديمي, C#, Csharp, .NET, Aspose.Slides"
description: "قارن شرائح عرض PowerPoint التقديمية في C# أو .NET"
---

## **قارن شريحتين**
تم إضافة طريقة Equals إلى واجهة [IBaseSlide](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide) وفئة [BaseSlide](https://reference.aspose.com/slides/net/aspose.slides/baseslide) class. تُعيد true للشرائح/التخطيطات والشرائح/الرئيسية التي تكون متطابقة في هيكلها والمحتوى الثابت.

تكون الشريحتان متساويتان إذا كانت جميع الأشكال والأنماط والنصوص والرسوم المتحركة وإعدادات أخرى ... لا تأخذ المقارنة في الاعتبار قيم المعرف الفريد، مثل SlideId، والمحتوى الديناميكي، مثل قيمة التاريخ الحالية في Date Placeholder.
```c#
using (Presentation presentation1 = new Presentation("AccessSlides.pptx"))
using (Presentation presentation2 = new Presentation("HelloWorld.pptx"))
{
    for (int i = 0; i < presentation1.Masters.Count; i++)
    {
        for (int j = 0; j < presentation2.Masters.Count; j++)
        {
            if (presentation1.Masters[i].Equals(presentation2.Masters[j]))
                Console.WriteLine(string.Format("SomePresentation1 MasterSlide#{0} is equal to SomePresentation2 MasterSlide#{1}", i, j));
        }
    }
}
```


## **الأسئلة المتكررة**

**هل يؤثر كون الشريحة مخفية على مقارنة الشرائح نفسها؟**

[حالة مخفية](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/) هي خاصية على مستوى العرض/التشغيل، ليست محتوى بصري. تُحدد مساواة شريحتين محددتين بهيكلهما والمحتوى الثابت؛ مجرد أن تكون شريحة مخفية لا يجعل الشرائح مختلفة.

**هل تُؤخذ الروابط التشعبية ومعلماتها في الاعتبار؟**

نعم. الروابط هي جزء من المحتوى الثابت للشريحة. إذا كان URL أو إجراء الرابط التشعبي مختلفًا، يُعامل عادةً كاختلاف في المحتوى الثابت.

**إذا كان المخطط يشير إلى ملف Excel خارجي، فهل تُؤخذ محتويات ذلك الملف في الاعتبار؟**

لا. يتم إجراء المقارنة بناءً على الشرائح نفسها. عادةً لا تُقرأ مصادر البيانات الخارجية أثناء المقارنة؛ يتم اعتبار ما هو موجود في هيكل الشريحة وحالتها الثابتة فقط.