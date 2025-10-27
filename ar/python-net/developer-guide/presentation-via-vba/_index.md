---
title: إدارة مشاريع VBA في العروض التقديمية باستخدام Python
linktitle: العرض التقديمي عبر VBA
type: docs
weight: 250
url: /ar/python-net/developer-guide/presentation-via-vba/
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
description: "اكتشف كيفية إنشاء وتعديل عروض PowerPoint وOpenDocument عبر VBA باستخدام Aspose.Slides for Python عبر .NET لتبسيط سير العمل الخاص بك."
---

## **نظرة عامة**

يتناول هذا المقال القدرات الرئيسية لـ Aspose.Slides for Python عبر .NET للعمل مع الماكرو في عروض PowerPoint. توفر المكتبة أدوات مريحة لإضافة وإزالة واستخراج الماكرو، مما يتيح لك أتمتة إنشاء وتعديل العروض التقديمية.

مع Aspose.Slides، يمكنك:

- تسريع تطوير العروض التقديمية—تقلص أتمتة المهام الروتينية الوقت المطلوب لإعداد المواد.
- ضمان المرونة—إمكانية إدارة الماكرو تسمح لك بتخصيص العروض التقديمية وفقًا لمهام وسيناريوهات محددة.
- دمج البيانات—التكامل البسيط مع مصادر البيانات الخارجية يساعد في إبقاء محتوى الشرائح محدثًا.
- تبسيط الصيانة—إدارة الماكرو المركزية تجعل تطبيق التغييرات وتحديث العروض أسهل.

يتابع المقال بتقديم أمثلة عملية حول كيفية استخدام Aspose.Slides للعمل بفعالية مع الماكرو في PowerPoint.

يوفر نطاق الاسم [aspose.slides.vba](https://reference.aspose.com/slides/python-net/aspose.slides.vba/) فئات للعمل مع الماكرو وكود VBA.

{{% alert title="ملاحظة" color="warning" %}}

عند تحويل عرض تقديمي يحتوي على ماكرو إلى تنسيق آخر (PDF، HTML، إلخ)، تتجاهل Aspose.Slides الماكرو—فلا يتم نقله إلى ملف الإخراج.

عند إضافة ماكرو إلى عرض تقديمي أو حفظ عرض تقديمي يحتوي على ماكرو مرة أخرى، تقوم Aspose.Slides بكتابة بايتات الماكرو كما هي.

Aspose.Slides **لا** تنفذ أبداً ماكرو في عرض تقديمي.

{{% /alert %}}

## **إضافة ماكرو VBA**

توفر Aspose.Slides الفئة [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) لإنشاء مشاريع VBA (ومراجع المشروع) وتعديل الوحدات الموجودة.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. استخدام الباني [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/#constructors) لإضافة مشروع VBA جديد.
1. إضافة وحدة إلى مشروع VBA.
1. ضبط شفرة source code الخاصة بالوحدة.
1. إضافة مرجع إلى `<stdole>`.
1. إضافة مرجع إلى **Microsoft Office**.
1. ربط المراجع بمشروع VBA.
1. حفظ العرض التقديمي.

يعرض الكود التالي بلغة Python كيفية إضافة ماكرو VBA من الصفر إلى عرض تقديمي:

```python
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:

    # Create a new VBA project.
    presentation.vba_project = slides.vba.VbaProject()

    # Add an empty module to the VBA project.
    module = presentation.vba_project.modules.add_empty_module("Module")

    # Set the module source code.
    module.source_code = """
        Sub Test(oShape As Shape)
            MsgBox "Hello, world!"
        End Sub
    """

    # Create a reference to <stdole>.
    stdole_reference = slides.vba.VbaReferenceOleTypeLib("stdole",
        "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # Create a reference to Microsoft Office.
    office_reference = slides.vba.VbaReferenceOleTypeLib("Office",
        "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Add the references to the VBA project.
    presentation.vba_project.references.add(stdole_reference)
    presentation.vba_project.references.add(office_reference)

    # Save the presentation.
    presentation.save("macros.pptm", slides.export.SaveFormat.PPTM)
```

{{% alert color="primary" %}}

قد ترغب في تجربة **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros)، وهو تطبيق ويب مجاني لإزالة الماكرو من مستندات PowerPoint وExcel وWord.

{{% /alert %}}

## **إزالة ماكرو VBA**

باستخدام خاصية [vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/) للفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) يمكنك إزالة ماكرو VBA.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وتحميل العرض التقديمي الذي يحتوي على الماكرو.
1. الوصول إلى وحدة الماكرو وإزالتها.
1. حفظ العرض التقديمي المعدل.

يعرض الكود التالي بلغة Python كيفية إزالة ماكرو VBA:

```python
import aspose.slides as slides

# Load the presentation that contains the macro.
with slides.Presentation("VBA.pptm") as presentation:
    
    # Access the VBA module.
    vba_module = presentation.vba_project.modules[0]

    # Remove the VBA module.
    presentation.vba_project.modules.remove(vba_module)

    # Save the presentation.
    presentation.save("removed_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **استخراج ماكرو VBA**

باستخدام خاصية `modules` في الفئة [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) يمكنك الوصول إلى جميع الوحدات في مشروع VBA. يمكن استخدام الفئة [VbaModule](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbamodule/) لاستخراج خصائص الوحدة مثل الاسم والشفرة.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وتحميل العرض التقديمي الذي يحتوي على الماكرو.
1. التحقق مما إذا كان العرض التقديمي يحتوي على مشروع VBA.
1. التنقل عبر جميع الوحدات في مشروع VBA لعرض ماكروهات.

يعرض الكود التالي بلغة Python كيفية استخراج ماكرو VBA من عرض تقديمي:

```python
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Check whether the presentation contains a VBA project.
    if presentation.vba_project is not None:
        for module in presentation.vba_project.modules:
            print(module.name)
            print(module.source_code)
```

## **التحقق مما إذا كان مشروع VBA محميًا بكلمة مرور**

باستخدام خاصية [VbaProject.is_password_protected](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/is_password_protected/) يمكنك تحديد ما إذا كانت خصائص المشروع محمية بكلمة مرور.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وتحميل عرض تقديمي يحتوي على ماكرو.
1. التحقق مما إذا كان العرض التقديمي يحتوي على [مشروع VBA](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/).
1. التحقق مما إذا كان مشروع VBA محميًا بكلمة مرور لعرض خصائصه.

```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Check whether the presentation contains a VBA project.
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```

## **الأسئلة الشائعة**

**ماذا يحدث للماكرو إذا حفظت العرض التقديمي كـ PPTX؟**

سيتم إزالة الماكرو لأن تنسيق PPTX لا يدعم VBA. للحفاظ على الماكرو، اختر PPTM أو PPSM أو POTM.

**هل يمكن لـ Aspose.Slides تشغيل الماكرو داخل عرض تقديمي لتحديث البيانات مثلاً؟**

لا. المكتبة لا تنفذ أبداً كود VBA؛ التنفيذ ممكن فقط داخل PowerPoint مع إعدادات الأمان المناسبة.

**هل يدعم العمل مع عناصر التحكم ActiveX المرتبطة بكود VBA؟**

نعم، يمكنك الوصول إلى [عناصر التحكم ActiveX](/slides/ar/python-net/activex/) الموجودة، تعديل خصائصها، وإزالتها. وهذا مفيد عندما تتفاعل الماكرو مع ActiveX.