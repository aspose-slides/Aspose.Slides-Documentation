---
title: إنشاء عرض تقديمي
type: docs
weight: 10
url: /ar/python-net/create-presentation/
keywords: "إنشاء PowerPoint، PPTX، PPT، إنشاء عرض تقديمي، تهيئة عرض تقديمي، بايثون، .NET"
description: "فتح عرض PowerPoint في بايثون"
---

## **إنشاء عرض PowerPoint**
لإضافة خط بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من فئة Presentation.
1. الحصول على مرجع شريحة باستخدام الفهرس الخاص بها.
1. إضافة AutoShape من نوع `LINE` باستخدام طريقة `add_auto_shape` المعروضة بواسطة كائن `shapes`.
1. كتابة العرض التقديمي المعدل كملف PPTX.

في المثال الموضح أدناه، أضفنا خطًا إلى الشريحة الأولى من العرض التقديمي.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)
    presentation.save("NewPresentation_out.pptx", slides.export.SaveFormat.PPTX)
```