---
title: مستطيل
type: docs
weight: 80
url: /ar/python-net/rectangle/
keywords: "إنشاء مستطيل، شكل PowerPoint، عرض PowerPoint، بايثون، Aspose.Slides لـ بايثون عبر .NET"
description: "إنشاء مستطيل في عرض PowerPoint باستخدام بايثون"
---


## **إنشاء مستطيل بسيط**
مثل المواضيع السابقة، هذا الموضوع يتعلق أيضًا بإضافة شكل وهذه المرة الشكل الذي سنتحدث عنه هو المستطيل. في هذا الموضوع، وصفنا كيف يمكن للمطورين إضافة مستطيلات بسيطة أو منسقة إلى شرائحهم باستخدام Aspose.Slides لـ بايثون عبر .NET. لإضافة مستطيل بسيط إلى شريحة مختارة من العرض، يرجى اتباع الخطوات أدناه:

1. قم بإنشاء مثيل من [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)class.
1. احصل على مرجع شريحة باستخدام الفهرس الخاص بها.
1. أضف IAutoShape من نوع المستطيل باستخدام طريقة AddAutoShape المتاحة بواسطة كائن IShapes.
1. اكتب العرض المعدل كملف PPTX.

في المثال المعطى أدناه، قمنا بإضافة مستطيل بسيط إلى الشريحة الأولى من العرض.

```py
import aspose.slides as slides

# Instantiate Prseetation class that represents the PPTX
with slides.Presentation() as pres:
    # Get the first slide
    sld = pres.slides[0]

    # Add autoshape of rectangle type
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    #Write the PPTX file to disk
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```


## **إنشاء مستطيل منسق**
لإضافة مستطيل منسق إلى شريحة، يرجى اتباع الخطوات أدناه:

1. قم بإنشاء مثيل من [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)class.
1. احصل على مرجع شريحة باستخدام الفهرس الخاص بها.
1. أضف IAutoShape من نوع المستطيل باستخدام طريقة AddAutoShape المتاحة بواسطة كائن IShapes.
1. قم بتعيين نوع التعبئة للمستطيل إلى صلب.
1. قم بتعيين لون المستطيل باستخدام خاصية SolidFillColor.Color المتاحة بواسطة كائن FillFormat المرتبط بكائن IShape.
1. قم بتعيين لون خطوط المستطيل.
1. قم بتعيين عرض خطوط المستطيل.
1. اكتب العرض المعدل كملف PPTX.
   يتم تنفيذ الخطوات أعلاه في المثال المعطى أدناه.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate Prseetation class that represents the PPTX
with slides.Presentation() as pres:
    # Get the first slide
    sld = pres.slides[0]

    # Add autoshape of rectangle type
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Apply some formatting to rectangle shape
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Apply some formatting to the line of rectangle
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #Write the PPTX file to disk
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```