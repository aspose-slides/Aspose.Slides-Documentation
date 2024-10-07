---
title: حفظ العرض التقديمي
type: docs
weight: 80
url: /python-net/save-presentation/
keywords: "حفظ باوربوينت, PPT, PPTX, حفظ عرض تقديمي, ملف, تدفق, بايثون"
description: "حفظ عرض باوربوينت كملف أو تدفق في بايثون"
---

## **حفظ العرض التقديمي**
كان فتح عرض تقديمي وصفًا لكيفية استخدام [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) لفتح عرض تقديمي. يشرح هذا المقال كيفية إنشاء وحفظ العروض التقديمية.
تحتوي  [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) على محتوى العرض التقديمي. سواء كنت تقوم بإنشاء عرض تقديمي من الصفر أو تعديل عرض موجود، عند الانتهاء، تريد حفظ العرض التقديمي. مع Aspose.Slides لبايثون عبر .NET، يمكن حفظه كـ **ملف** أو **تدفق**. يوضح هذا المقال كيفية حفظ عرض تقديمي بطرق مختلفة:

### **حفظ العرض التقديمي إلى ملفات**
احفظ عرضًا تقديميًا إلى ملفات عن طريق استدعاء [تقديم](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) طريقة [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). فقط قم بتمرير اسم الملف وتنسيق الحفظ إلى طريقة [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). تظهر الأمثلة التالية كيفية حفظ عرض تقديمي باستخدام Aspose.Slides لبايثون عبر .NET باستخدام بايثون.

```py
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف PPT
with slides.Presentation() as presentation:
    
    #...قم ببعض العمل هنا...

    # احفظ عرضك التقديمي في ملف
    presentation.save("Saved_out.pptx", slides.export.SaveFormat.PPTX)
```


### **حفظ العرض التقديمي إلى تدفقات**
من الممكن حفظ عرض تقديمي إلى تدفق عن طريق تمرير تدفق الخرج إلى طريقة حفظ [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). هناك العديد من أنواع التدفقات التي يمكن حفظ العرض التقديمي بها. في المثال أدناه، أنشأنا ملف تقديمي جديد، أضفنا نصًا في شكل واحفظنا العرض التقديمي في التدفق.

```py
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف PPT
with slides.Presentation() as presentation:
    
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 200, 200)

    # احفظ عرضك التقديمي في تدفق
    with open("Save_As_Stream_out.pptx", "bw") as stream:
        presentation.save(stream, slides.export.SaveFormat.PPTX)
```


### **حفظ العروض التقديمية بنوع عرض محدد مسبقًا**
توفر Aspose.Slides لبايثون عبر .NET إمكانية تعيين نوع العرض للعرض التقديمي الناتج عند فتحه في باوربوينت من خلال فئة [view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/). يتم استخدام خاصية [last_view](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) لتعيين نوع العرض باستخدام تعداد [ViewType](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/).

```py
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف PPT
with slides.Presentation() as presentation:
    
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("pres-will-open-SlideMasterView.pptx", slides.export.SaveFormat.PPTX)

```

### **حفظ العروض التقديمية بتنسيق Strict Office Open XML**
تتيح Aspose.Slides لك حفظ العرض التقديمي في تنسيق Strict Office Open XML. لهذا الغرض، توفر فئة **[PptxOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/)** حيث يمكنك تعيين خاصية Conformance عند حفظ ملف العرض التقديمي. إذا قمت بتعيين قيمتها على Conformance.Iso29500_2008_Strict، فسيتم حفظ ملف العرض التقديمي الناتج في تنسيق Strict Office Open XML.

الشفرة المصدرية التالية تنشئ عرضًا تقديميًا وتحفظه في تنسيق Strict Office Open XML. أثناء استدعاء طريقة الحفظ للعرض التقديمي، يتم تمرير كائن **[PptxOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/)** إليها مع تعيين خاصية **[Conformance](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/)** كـ **[Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/python-net/aspose.slides.export/conformance/)**.

```py
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي
with slides.Presentation() as presentation:
    # احصل على الشريحة الأولى
    slide = presentation.slides[0]

    # أضف شكل تلقائي من نوع خط
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    options = slides.export.PptxOptions()
    options.conformance = slides.export.Conformance.ISO29500_2008_STRICT

    # احفظ العرض التقديمي في تنسيق Strict Office Open XML
    presentation.save("NewPresentation_out.pptx", slides.export.SaveFormat.PPTX, options)

```


### **حفظ تحديثات التقدم بالنسبة المئوية**
تمت إضافة واجهة [**IProgressCallback** ](https://reference.aspose.com/slides/python-net/aspose.slides/iprogresscallback/) إلى واجهة [**ISaveOptions** ](https://reference.aspose.com/slides/python-net/aspose.slides.export/isaveoptions/) وفئة [**SaveOptions** ](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/) المجردة. تمثل واجهة **IProgressCallback** كائن رد الاتصال لتحديثات تقدم الحفظ بالنسبة المئوية.

توضح مقتطفات الشيفرة أدناه كيفية استخدام واجهة IProgressCallback:

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

{{% alert title="معلومات" color="info" %}}

باستخدام واجهته البرمجية الخاصة، طورت Aspose تطبيق [PowerPoint Splitter مجاني](https://products.aspose.app/slides/splitter) يسمح للمستخدمين بتقسيم عروضهم التقديمية إلى ملفات متعددة. بشكل أساسي، يقوم التطبيق بحفظ الشرائح المحددة من عرض تقديمي معين كملفات باوربوينت جديدة (PPTX أو PPT). 

{{% /alert %}}