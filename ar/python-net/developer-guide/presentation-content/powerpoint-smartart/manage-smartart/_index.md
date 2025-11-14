---
title: إدارة SmartArt
type: docs
weight: 10
url: /ar/python-net/manage-smartart/
keywords: "SmartArt، نص من SmartArt، مخطط نوع المنظمة، مخطط منظمة الصورة، عرض PowerPoint، Python، Aspose.Slides لـ Python عبر .NET"
description: "SmartArt ومخطط نوع المنظمة في عروض PowerPoint بلغة Python"
---

## **احصل على نص من SmartArt**
الآن تم إضافة خاصية TextFrame إلى واجهة ISmartArtShape وفئة SmartArtShape على التوالي. هذه الخاصية تتيح لك الحصول على جميع النصوص من SmartArt إذا لم يكن يحتوي فقط على نصوص العقد. الكود النموذجي التالي سيساعدك في الحصول على النص من عقدة SmartArt.

```py
import aspose.slides as slides

with slides.Presentation(path + "SmartArt.pptx") as pres:
    slide = pres.slides[0]
    smartArt = slide.shapes[0]

    for smartArtNode in smartArt.all_nodes:
        for nodeShape in smartArtNode.shapes:
            if nodeShape.text_frame != None:
                print(nodeShape.text_frame.text)
```



## **تغيير نوع تخطيط SmartArt**
لتغيير نوع تخطيط SmartArt، يرجى اتباع الخطوات التالية:

- أنشئ مثيلًا من فئة `Presentation`.
- الحصول على مرجع لشريحة باستخدام فهرسها.
- أضف SmartArt BasicBlockList.
- تغيير LayoutType إلى BasicProcess.
- احفظ العرض التقديمي كملف PPTX.
  في المثال أدناه، أضفنا موصلًا بين شكلين.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation:
    # إضافة SmartArt BasicProcess 
    smart = presentation.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_BLOCK_LIST)
    # تغيير LayoutType إلى BasicProcess
    smart.layout = art.SmartArtLayoutType.BASIC_PROCESS
    # حفظ العرض التقديمي
    presentation.save("ChangeSmartArtLayout_out.pptx", slides.export.SaveFormat.PPTX)
```



## **تحقق من خاصية Hidden الخاصة بـ SmartArt**
يرجى ملاحظة أن طريقة com.aspose.slides.ISmartArtNode.isHidden() تعيد true إذا كانت هذه العقدة عقدة مخفية في نموذج البيانات. للتحقق من خاصية hidden لأي عقدة من SmartArt، يرجى اتباع الخطوات التالية:

- أنشئ مثيلًا من فئة `Presentation`.
- أضف SmartArt RadialCycle.
- أضف عقدة على SmartArt.
- تحقق من خاصية isHidden.
- احفظ العرض التقديمي كملف PPTX.

في المثال أدناه، أضفنا موصلًا بين شكلين.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation:
    # إضافة SmartArt BasicProcess 
    smart = presentation.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.RADIAL_CYCLE)
    # إضافة عقدة على SmartArt 
    node = smart.all_nodes.add_node()
    # تحقق من خاصية isHidden
    if node.is_hidden:
        print("مخفي")
        # قم ببعض الإجراءات أو الإشعارات
    # حفظ العرض التقديمي
    presentation.save("CheckSmartArtHiddenProperty_out.pptx", slides.export.SaveFormat.PPTX)
```



## **احصل على نوع مخطط المنظمة أو اضبطه**
تسمح طرق com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) بالحصول على نوع مخطط المنظمة المرتبط بالعقدة الحالية أو ضبطه. للحصول على نوع مخطط المنظمة أو ضبطه، يرجى اتباع الخطوات التالية:

- أنشئ مثيلًا من فئة `Presentation`.
- أضف SmartArt على الشريحة.
- احصل على نوع مخطط المنظمة أو اضبطه.
- احفظ العرض التقديمي كملف PPTX.
  في المثال أدناه، أضفنا موصلًا بين شكلين.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation:
    # إضافة SmartArt BasicProcess 
    smart = presentation.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.ORGANIZATION_CHART)
    # احصل على نوع مخطط المنظمة أو اضبطه 
    smart.nodes[0].organization_chart_layout = art.OrganizationChartLayoutType.LEFT_HANGING
    # حفظ العرض التقديمي
    presentation.save("OrganizeChartLayoutType_out.pptx", slides.export.SaveFormat.PPTX)
```




## **إنشاء مخطط منظمة صورة**
توفر Aspose.Slides لـ Python عبر .NET واجهة برمجة تطبيقات بسيطة لإنشاء مخططات منظمة وصور بسهولة. لإنشاء مخطط على شريحة:

1. أنشئ مثيلًا من فئة `Presentation`.
1. احصل على مرجع الشريحة بواسطة فهرسها.
1. أضف مخططًا مع بيانات افتراضية مع النوع المرغوب (ChartType.PictureOrganizationChart).
1. اكتب العرض التقديمي المعدل إلى ملف PPTX.

يستخدم الكود التالي لإنشاء مخطط.

```py
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as pres:
    smartArt = pres.slides[0].shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.PICTURE_ORGANIZATION_CHART)
    pres.save("OrganizationChart.pptx", slides.export.SaveFormat.PPTX)
```