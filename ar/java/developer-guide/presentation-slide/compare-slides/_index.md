---
title: مقارنة الشرائح
type: docs
weight: 50
url: /java/compare-slides/
---

## **مقارنة شريحتين**
تمت إضافة طريقة Equals إلى واجهة [IBaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide) وفئة [BaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/BaseSlide). وهي تعيد القيمة true للشرائح/التخطيط والشرائح/الشرائح الرئيسية التي تتطابق في هيكلها ومحتواها الثابت.

تكون الشريحتان متساويتين إذا كانت جميع الأشكال، الأنماط، النصوص، الرسوم المتحركة والإعدادات الأخرى متساوية. لا تأخذ المقارنة في الاعتبار قيم المعرفات الفريدة، مثل SlideId والمحتوى الديناميكي، مثل قيمة التاريخ الحالي في عنصر التاريخ.

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
                    System.out.println(String.format("SomePresentation1 MasterSlide#%d متساوي مع SomePresentation2 MasterSlide#%d", i, j));
            }
        }
    } finally {
        presentation2.dispose();
    }
} finally {
    presentation1.dispose();
}
```