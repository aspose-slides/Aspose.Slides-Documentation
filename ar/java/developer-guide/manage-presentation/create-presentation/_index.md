---
title: إنشاء عرض تقديمي باستخدام Java
linktitle: إنشاء عرض تقديمي
type: docs
weight: 10
url: /ar/java/create-presentation/
keywords: إنشاء ppt java, إنشاء عرض تقديمي ppt, إنشاء pptx java
description: تعلم كيفية إنشاء عروض PowerPoint تقديمية مثل PPT و PPTX باستخدام Java من الصفر.
---

## **إنشاء عرض تقديمي باستخدام PowerPoint**
لإضافة خط عادي بسيط إلى شريحة محددة في العرض التقديمي، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة Presentation.
1. الحصول على مرجع لشريحة باستخدام الفهرس الخاص بها.
1. إضافة شكل تلقائي من نوع الخط باستخدام طريقة addAutoShape المعروضة بواسطة كائن Shapes.
1. كتابة العرض التقديمي المعدل كملف PPTX.

في المثال الموضح أدناه، قمنا بإضافة خط إلى الشريحة الأولى من العرض التقديمي.

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