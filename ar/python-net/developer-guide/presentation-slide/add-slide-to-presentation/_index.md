---
title: إضافة شريحة إلى العرض التقديمي
type: docs
weight: 10
url: /python-net/add-slide-to-presentation/
keywords: "إضافة شريحة إلى العرض التقديمي، بايثون، Aspose.Slides"
description: "إضافة شريحة إلى العرض التقديمي باستخدام بايثون"
---

## **إضافة شريحة إلى العرض التقديمي**
قبل الحديث عن إضافة الشرائح إلى ملفات العرض التقديمي، دعنا نناقش بعض الحقائق حول الشرائح. يحتوي كل ملف عرض تقديمي PowerPoint على شريحة رئيسية / تخطيط وبعض الشرائح العادية الأخرى. وهذا يعني أن ملف العرض التقديمي يحتوي على شريحة واحدة أو أكثر على الأقل. من المهم معرفة أن ملفات العرض التقديمي بدون شرائح غير مدعومة من قبل Aspose.Slides لبايثون عبر .NET. تحتوي كل شريحة على معرف فريد وجميع الشرائح العادية مرتبة وفقًا لترتيب محدد بواسطة الفهرس المعتمد على الصفر. يسمح Aspose.Slides لبايثون عبر .NET للمطورين بإضافة شرائح فارغة إلى عرضهم التقديمي. لإضافة شريحة فارغة في العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- إنشاء نسخة من فئة [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) عن طريق ضبط مرجع إلى خاصية Slides (مجموعة من كائنات شريحة المحتوى) المعروضة بواسطة كائن Presentation.
- إضافة شريحة فارغة إلى العرض التقديمي في نهاية مجموعة شرائح المحتوى عن طريق استدعاء طريقة AddEmptySlide المعروضة بواسطة كائن ISlideCollection.
- القيام ببعض العمل مع الشريحة الفارغة المضافة حديثًا.
- أخيرًا، كتابة ملف العرض التقديمي باستخدام كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).

```py
import aspose.slides as slides

# إنشاء نسخة من فئة Presentation التي تمثل ملف العرض التقديمي
with slides.Presentation() as pres:
    # إنشاء نسخة من فئة SlideCollection
    slds = pres.slides

    for i in range(len(pres.layout_slides)):
        # إضافة شريحة فارغة إلى مجموعة الشرائح
        slds.add_empty_slide(pres.layout_slides[i])
        
    # القيام ببعض العمل على الشريحة المضافة حديثًا

    # حفظ ملف PPTX على القرص
    pres.save("EmptySlide.pptx", slides.export.SaveFormat.PPTX)
```