---
title: قارن الشرائح
type: docs
weight: 50
url: /ar/androidjava/compare-slides/
---

## **مقارنة شريحتين**
تمت إضافة طريقة Equals إلى واجهة [IBaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide) وفئة [BaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BaseSlide). تُرجع القيمة true للشرائح/التخطيطات والشرائح/الشرائح الرئيسية التي تتطابق من حيث الهيكل والمحتوى الثابت.

تكون الشريحتان متساويتين إذا كانت جميع الأشكال، الأنماط، النصوص، الرسوم المتحركة والإعدادات الأخرى، إلخ، متساوية. لا تأخذ المقارنة في الاعتبار قيم المعرف الفريدة، مثل SlideId والمحتوى الديناميكي، مثل القيمة الحالية للتاريخ في مكان التاريخ.

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
                    System.out.println(String.format("SomePresentation1 MasterSlide#%d يساوي SomePresentation2 MasterSlide#%d", i, j));
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```