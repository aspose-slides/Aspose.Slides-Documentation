---
title: قارن الشرائح
type: docs
weight: 50
url: /ar/net/compare-slides/
keywords: "قارن شرائح PowerPoint، قارن شريحتين، عرض تقديمي، C#، Csharp، .NET، Aspose.Slides"
description: "قارن شرائح عرض PowerPoint باستخدام C# أو .NET"
---

## **مقارنة شريحتين**
تمت إضافة طريقة Equals إلى واجهة [IBaseSlide](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide) وفئة [BaseSlide](https://reference.aspose.com/slides/net/aspose.slides/baseslide). تعيد القيمة true للشرائح/التخطيطات والشرائح/الرئيسية المتطابقة من حيث الهيكل والمحتوى الثابت.

تكون شريحتان متساويتين إذا كانت جميع الأشكال والأساليب والنصوص والرسوم المتحركة والإعدادات الأخرى، إلخ. لا تأخذ المقارنة في الاعتبار قيم المعرف الفريد، مثل SlideId والمحتوى الديناميكي، مثل قيمة التاريخ الحالي في عنصر نائبة التاريخ.

```c#
using (Presentation presentation1 = new Presentation("AccessSlides.pptx"))
using (Presentation presentation2 = new Presentation("HelloWorld.pptx"))
{
    for (int i = 0; i < presentation1.Masters.Count; i++)
    {
        for (int j = 0; j < presentation2.Masters.Count; j++)
        {
            if (presentation1.Masters[i].Equals(presentation2.Masters[j]))
                Console.WriteLine(string.Format("شريحة رئيسية SomePresentation1#{0} تساوي شريحة رئيسية SomePresentation2#{1}", i, j));
        }
    }
}
```