---
title: القسم
type: docs
weight: 90
url: /ar/python-net/examples/elements/section/
keywords:
- قسم
- قسم شريحة
- إضافة قسم
- الوصول إلى قسم
- إزالة قسم
- إعادة تسمية قسم
- أمثلة على الكود
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إدارة أقسام الشرائح في Python باستخدام Aspose.Slides: إنشاء، إعادة تسمية، إعادة ترتيب بسهولة، نقل الشرائح بين الأقسام، والتحكم في الرؤية لـ PPT و PPTX و ODP."
---
أمثلة لإدارة أقسام العروض التقديمية—الإضافة، الوصول، الإزالة، وإعادة التسمية برمجيًا باستخدام **Aspose.Slides for Python via .NET**.

## **إضافة قسم**

إنشاء قسم يبدأ من شريحة محددة.

```py
def add_section():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # إضافة قسم جديد وتحديد الشريحة التي تمثل بداية القسم.
        presentation.sections.add_section("New Section", slide)

        presentation.save("section.pptx", slides.export.SaveFormat.PPTX)
```

## **الوصول إلى قسم**

الحصول على قسم من عرض تقديمي.

```py
def access_section():
    with slides.Presentation("section.pptx") as presentation:

        # الوصول إلى قسم حسب الفهرس.
        section = presentation.sections[0]
```

## **إزالة قسم**

حذف قسم تم إضافته مسبقًا.

```py
def remove_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # إزالة القسم.
        presentation.sections.remove_section(section)

        presentation.save("section_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **إعادة تسمية قسم**

تغيير اسم القسم الموجود.

```py
def rename_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # إعادة تسمية القسم.
        section.name = "New Name"

        presentation.save("section_renamed.pptx", slides.export.SaveFormat.PPTX)
```