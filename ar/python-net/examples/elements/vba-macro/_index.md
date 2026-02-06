---
title: ماكرو VBA
type: docs
weight: 150
url: /ar/python-net/examples/elements/vba-macro/
keywords:
- ماكرو VBA
- إضافة ماكرو VBA
- الوصول إلى ماكرو VBA
- إزالة ماكرو VBA
- أمثلة على الشيفرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "العمل مع ماكروات VBA في Python باستخدام Aspose.Slides: إضافة أو تحرير المشاريع والوحدات، توقيع أو إزالة الماكروات، وحفظ العروض التقديمية بصيغ PPT و PPTX و ODP."
---
يوضح كيفية إضافة، الوصول، وإزالة ماكرو VBA باستخدام **Aspose.Slides for Python via .NET**.

## **إضافة ماكرو VBA**

إنشاء عرض تقديمي يحتوي على مشروع VBA ووحدة ماكرو بسيطة.

```py
def add_vba_macro():
    with slides.Presentation() as presentation:
        # تهيئة مشروع VBA.
        presentation.vba_project = slides.vba.VbaProject()

        # إضافة وحدة فارغة باسم "Module".
        module = presentation.vba_project.modules.add_empty_module("Module")
        module.source_code = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub"

        presentation.save("vba_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **الوصول إلى ماكرو VBA**

استرجاع الوحدة الأولى من مشروع VBA.

```py
def access_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:
        first_module = presentation.vba_project.modules[0]
```

## **إزالة ماكرو VBA**

حذف وحدة من مشروع VBA.

```py
def remove_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:

        # بافتراض أن العرض التقديمي يحتوي على مشروع VBA وعلى الأقل وحدة واحدة.
        module = presentation.vba_project.modules[0]

        # إزالة الوحدة من المشروع.
        presentation.vba_project.modules.remove(module)

        presentation.save("vba_macro_removed.pptx", slides.export.SaveFormat.PPTX)
```