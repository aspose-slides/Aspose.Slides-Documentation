---
title: بيضاوي
type: docs
weight: 30
url: /python-net/ellipse/
keywords: "بيضاوي، شكل PowerPoint، عرض PowerPoint، بايثون، Aspose.Slides لـ Python عبر .NET"
description: "إنشاء بيضاوي في عرض PowerPoint باستخدام بايثون"
---


## **إنشاء بيضاوي**
في هذا الموضوع، سوف نقدم للمطورين كيفية إضافة أشكال بيضاوية إلى شرائحهم باستخدام Aspose.Slides لـ Python عبر .NET. تقدم Aspose.Slides لـ Python عبر .NET مجموعة أسهل من واجهات برمجة التطبيقات لرسم أنواع مختلفة من الأشكال في بضع أسطر من التعليمات البرمجية فقط. لإضافة بيضاوي بسيط إلى شريحة محددة من العرض، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)class
1. الحصول على مرجع لشريحة باستخدام الفهرس الخاص بها
1. إضافة AutoShape من نوع بيضاوي باستخدام طريقة AddAutoShape المعروضة بواسطة كائن IShapes
1. كتابة العرض المعدل كملف PPTX

في المثال المعطى أدناه، قمنا بإضافة بيضاوي إلى الشريحة الأولى.

```py
import aspose.slides as slides

# Instantiate Prseetation class that represents the PPTX
with slides.Presentation() as pres:
    # Get the first slide
    sld = pres.slides[0]

    # Add autoshape of ellipse type
    sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    #Write the PPTX file to disk
    pres.save("EllipseShp1_out.pptx", slides.export.SaveFormat.PPTX)
```



## **إنشاء بيضاوي منسق**
لإضافة بيضاوي منسق بشكل أفضل إلى شريحة، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)class.
1. الحصول على مرجع لشريحة باستخدام الفهرس الخاص بها.
1. إضافة AutoShape من نوع بيضاوي باستخدام طريقة AddAutoShape المعروضة بواسطة كائن IShapes.
1. تعيين نوع التعبئة للبيضاوي إلى صلب.
1. تعيين لون البيضاوي باستخدام خاصية SolidFillColor.Color المعروضة بواسطة كائن FillFormat المرتبط بكائن IShape.
1. تعيين لون خطوط البيضاوي.
1. تعيين عرض خطوط البيضاوي.
1. كتابة العرض المعدل كملف PPTX.

في المثال المعطى أدناه، قمنا بإضافة بيضاوي منسق إلى الشريحة الأولى من العرض.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate Prseetation class that represents the PPTX
with slides.Presentation() as pres:
    # Get the first slide
    sld = pres.slides[0]

    # Add autoshape of ellipse type
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # Apply some formatting to ellipse shape
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Apply some formatting to the line of Ellipse
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #Write the PPTX file to disk
    pres.save("EllipseShp2_out.pptx", slides.export.SaveFormat.PPTX)
```