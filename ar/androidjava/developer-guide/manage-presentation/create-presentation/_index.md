---
title: إنشاء عرض تقديمي باستخدام جافا
linktitle: إنشاء عرض تقديمي
type: docs
weight: 10
url: /androidjava/create-presentation/
keywords: إنشاء ppt جافا, إنشاء عرض تقديمي ppt, إنشاء pptx جافا
description: تعلم كيفية إنشاء عروض PowerPoint، مثل PPT و PPTX باستخدام جافا من الصفر.
---

## **إنشاء عرض تقديمي**
لإضافة خط بسيط إلى شريحة محددة من العرض التقديمي، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من فئة Presentation.
1. الحصول على مرجع لشريحة باستخدام فهرسها.
1. إضافة شكل تلقائي من نوع خط باستخدام طريقة addAutoShape المعروضة بواسطة كائن Shapes.
1. كتابة العرض التقديمي المعدل كملف PPTX.

في المثال المعطى أدناه، أضفنا خطًا إلى الشريحة الأولى من العرض التقديمي.

```java
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation();
try {
    // الحصول على الشريحة الأولى
    ISlide slide = pres.getSlides().get_Item(0);

    // إضافة شكل تلقائي من نوع خط
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```