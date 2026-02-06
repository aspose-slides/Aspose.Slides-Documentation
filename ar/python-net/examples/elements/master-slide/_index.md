---
title: الشريحة الرئيسة
type: docs
weight: 30
url: /ar/python-net/examples/elements/master-slide/
keywords:
- شريحة رئيسة
- إضافة شريحة رئيسة
- الوصول إلى شريحة رئيسة
- إزالة شريحة رئيسة
- شريحة رئيسة غير مستخدمة
- أمثلة على الشيفرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إدارة الشرائح الرئيسة في بايثون باستخدام Aspose.Slides: إنشاء، تعديل، استنساخ، وتنسيق السمات، الخلفيات، العناصر النائبة لتوحيد الشرائح في PowerPoint وOpenDocument."
---
تشكل الشرائح الرئيسة المستوى الأعلى في تسلسل وراثة الشرائح في PowerPoint. **الشريحة الرئيسة** تُعرّف عناصر التصميم المشتركة مثل الخلفيات والشعارات وتنسيق النص. **شرائح التخطيط** ترث من الشرائح الرئيسة، و**الشرائح العادية** ترث من شرائح التخطيط.

توضح هذه المقالة كيفية إنشاء وتعديل وإدارة الشرائح الرئيسة باستخدام Aspose.Slides for Python via .NET.

## **إضافة شريحة رئيسة**

يوضح هذا المثال كيفية إنشاء شريحة رئيسة جديدة عن طريق استنساخ الشريحة الافتراضية.

```py
def add_master_slide():
    with slides.Presentation() as presentation:

        # استنساخ الشريحة الرئيسية الافتراضية.
        default_master_slide = presentation.masters[0]
        new_master = presentation.masters.add_clone(default_master_slide)

        presentation.save("master_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **نصيحة 1:** توفر الشرائح الرئيسة طريقة لتطبيق علامة تجارية ثابتة أو عناصر تصميم مشتركة عبر جميع الشرائح. أي تغييرات تُجرى على الشريحة الرئيسة ستنعكس تلقائيًا على شرائح التخطيط والشرائح العادية التابعة لها.

> 💡 **نصيحة 2:** أي أشكال أو تنسيقات تُضاف إلى شريحة رئيسة تُورّث إلى شرائح التخطيط، وبالتالي إلى جميع الشرائح العادية التي تستخدم تلك التخطيطات.  
> الصورة أدناه توضح كيف يتم عرض مربع نص يُضاف إلى شريحة رئيسة تلقائيًا على الشريحة النهائية.

![Master Inheritance Example](master-slide-banner.png)

## **الوصول إلى شريحة رئيسة**

يمكنك الوصول إلى الشرائح الرئيسة عبر مجموعة `Presentation.masters`. إليك طريقة استرجاعها والعمل معها:

```py
def access_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:
        # الوصول إلى الشريحة الرئيسة الأولى.
        first_master_slide = presentation.masters[0]
```

## **إزالة شريحة رئيسة**

يمكن إزالة الشرائح الرئيسة إما حسب الفهرس أو حسب المرجع.

```py
def remove_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:

        # الإزالة حسب الفهرس.
        presentation.masters.remove_at(0)

        # أو الإزالة بالمرجع.
        first_master_slide = presentation.masters[0]
        presentation.masters.remove(first_master_slide)

        presentation.save("master_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **إزالة الشرائح الرئيسة غير المستخدمة**

تحتوي بعض العروض التقديمية على شرائح رئيسة غير مستخدمة. إزالة هذه الشرائح يمكن أن تساعد في تقليل حجم الملف.

```py
def remove_unused_master_slides():
    with slides.Presentation("master_slide.pptx") as presentation:

        # إزالة جميع الشرائح الرئيسة غير المستخدمة (حتى تلك المعلّمة كـ Preserve).
        presentation.masters.remove_unused(True)

        presentation.save("master_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

> ⚙️ **نصيحة:** استخدم `remove_unused(True)` لتنظيف الشرائح الرئيسة غير المستخدمة وتقليل حجم العرض التقديمي.