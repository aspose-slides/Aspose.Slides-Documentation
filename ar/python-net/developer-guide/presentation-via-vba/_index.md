---
title: إدارة مشاريع VBA في العروض التقديمية باستخدام Python
linktitle: العرض عبر VBA
type: docs
weight: 250
url: /ar/python-net/presentation-via-vba/
keywords:
- ماكرو
- VBA
- ماكرو VBA
- إضافة ماكرو
- إزالة ماكرو
- استخراج ماكرو
- إضافة VBA
- إزالة VBA
- استخراج VBA
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "اكتشف كيفية إنشاء ومعالجة عروض PowerPoint وOpenDocument عبر VBA باستخدام Aspose.Slides للغة Python عبر .NET لتبسيط سير عملك."
---

## **نظرة عامة**

تستعرض هذه المقالة القدرات الرئيسية لـ Aspose.Slides للغة Python عبر .NET للعمل مع الماكرو في عروض PowerPoint. توفر المكتبة أدوات مريحة لإضافة الماكرو، إزالته، واستخراجه، مما يتيح لك أتمتة إنشاء وتعديل العروض التقديمية.

مع Aspose.Slides، يمكنك:

- تسريع تطوير العروض التقديمية—تقلل أتمتة المهام الروتينية من الوقت اللازم لإعداد المواد.
- ضمان المرونة—تتيح القدرة على إدارة الماكرو تخصيص العروض لمهام وسيناريوهات محددة.
- دمج البيانات—يساعد التكامل البسيط مع مصادر البيانات الخارجية على إبقاء محتوى الشرائح محدثًا.
- تبسيط الصيانة—تسهل الإدارة المركزية للماكرو تطبيق التغييرات وتحديث العروض.

تستعرض المقالة أمثلة عملية لكيفية استخدام Aspose.Slides للعمل بفعالية مع الماكرو في PowerPoint.

توفر مساحة الأسماء [aspose.slides.vba](https://reference.aspose.com/slides/python-net/aspose.slides.vba/) فئات للعمل مع الماكرو وكود VBA.

{{% alert title="ملاحظة" color="warning" %}}

عند تحويل عرض تقديمي يحتوي على ماكرو إلى تنسيق آخر (PDF، HTML، إلخ)، يتجاهل Aspose.Slides الماكرو—فلا يتم نقلها إلى ملف الإخراج.

عند إضافة ماكرو إلى عرض تقديمي أو حفظ عرض يحتوي على ماكرو مرة أخرى، يكتب Aspose.Slides بايتات الماكرو كما هي.

Aspose.Slides **لا** ينفّذ أبدا الماكرو في العرض التقديمي.

{{% /alert %}}

## **إضافة ماكرو VBA**

توفر Aspose.Slides الفئة [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) لإنشاء مشاريع VBA (ومراجع المشروع) وتعديل الوحدات الموجودة.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. استخدام منشئ [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/#constructors) لإضافة مشروع VBA جديد.
3. إضافة وحدة إلى مشروع VBA.
4. تعيين كود المصدر للوحدة.
5. إضافة مرجع إلى `<stdole>`.
6. إضافة مرجع إلى **Microsoft Office**.
7. ربط المراجع بمشروع VBA.
8. حفظ العرض التقديمي.

يوضح الكود التالي بلغة Python كيفية إضافة ماكرو VBA من الصفر إلى عرض تقديمي:

```python
import aspose.slides as slides

# إنشاء نسخة من فئة Presentation.
with slides.Presentation() as presentation:

    # إنشاء مشروع VBA جديد.
    presentation.vba_project = slides.vba.VbaProject()

    # إضافة وحدة فارغة إلى مشروع VBA.
    module = presentation.vba_project.modules.add_empty_module("Module")

    # تعيين كود المصدر للوحدة.
    module.source_code = """
        Sub Test(oShape As Shape)
            MsgBox "Hello, world!"
        End Sub
    """

    # إنشاء مرجع إلى <stdole>.
    stdole_reference = slides.vba.VbaReferenceOleTypeLib("stdole",
        "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # إنشاء مرجع إلى Microsoft Office.
    office_reference = slides.vba.VbaReferenceOleTypeLib("Office",
        "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # إضافة المراجع إلى مشروع VBA.
    presentation.vba_project.references.add(stdole_reference)
    presentation.vba_project.references.add(office_reference)

    # حفظ العرض التقديمي.
    presentation.save("macros.pptm", slides.export.SaveFormat.PPTM)
```

{{% alert color="primary" %}}

قد ترغب في تجربة **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros)، وهو تطبيق ويب مجاني لإزالة الماكرو من مستندات PowerPoint وExcel وWord.

{{% /alert %}}

## **إزالة ماكرو VBA**

باستخدام خاصية [vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/) لفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)، يمكنك إزالة ماكرو VBA.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وتحميل العرض الذي يحتوي على الماكرو.
2. الوصول إلى وحدة الماكرو وإزالتها.
3. حفظ العرض المعدل.

يوضح الكود التالي بلغة Python كيفية إزالة ماكرو VBA:

```python
import aspose.slides as slides

# تحميل العرض الذي يحتوي على الماكرو.
with slides.Presentation("VBA.pptm") as presentation:
    
    # الوصول إلى وحدة VBA.
    vba_module = presentation.vba_project.modules[0]

    # إزالة وحدة VBA.
    presentation.vba_project.modules.remove(vba_module)

    # حفظ العرض التقديمي.
    presentation.save("removed_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **استخراج ماكرو VBA**

باستخدام خاصية `modules` في فئة [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/)، يمكنك الوصول إلى جميع وحدات مشروع VBA. يمكن استخدام فئة [VbaModule](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbamodule/) لاستخراج خصائص الوحدة مثل الاسم والكود.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وتحميل العرض الذي يحتوي على الماكرو.
2. التحقق مما إذا كان العرض يحتوي على مشروع VBA.
3. التجول عبر جميع الوحدات في مشروع VBA لعرض الماكرو.

يوضح الكود التالي بلغة Python كيفية استخراج ماكرو VBA من عرض تقديمي:

```python
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # التحقق مما إذا كان العرض يحتوي على مشروع VBA.
    if presentation.vba_project is not None:
        for module in presentation.vba_project.modules:
            print(module.name)
            print(module.source_code)
```

## **التحقق مما إذا كان مشروع VBA محميًا بكلمة مرور**

باستخدام خاصية [VbaProject.is_password_protected](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/is_password_protected/)، يمكنك تحديد ما إذا كانت خصائص المشروع محمية بكلمة مرور.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وتحميل عرض يحتوي على ماكرو.
2. التحقق مما إذا كان العرض يحتوي على [مشروع VBA](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/).
3. التحقق مما إذا كان مشروع VBA محميًا بكلمة مرور لعرض خصائصه.

```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # التحقق مما إذا كان العرض يحتوي على مشروع VBA.
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```

## **الأسئلة المتكررة**

**ماذا يحدث للماكرو إذا قمت بحفظ العرض كملف PPTX؟**

سيتم إزالة الماكرو لأن PPTX لا يدعم VBA. للحفاظ على الماكرو، اختر PPTM أو PPSM أو POTM.

**هل يمكن لـ Aspose.Slides تشغيل الماكرو داخل العرض لتحديث البيانات مثلاً؟**

لا. المكتبة لا تنفّذ كود VBA أبداً؛ التنفيذ ممكن فقط داخل PowerPoint مع إعدادات الأمان المناسبة.

**هل يتم دعم العمل مع عناصر التحكم ActiveX المرتبطة بكود VBA؟**

نعم، يمكنك الوصول إلى عناصر تحكم ActiveX الموجودة، تعديل خصائصها، وإزالتها. هذا مفيد عندما يتفاعل الماكرو مع ActiveX.