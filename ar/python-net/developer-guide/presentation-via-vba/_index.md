---
title: إدارة مشاريع VBA في العروض التقديمية باستخدام بايثون
linktitle: العرض التقديمي عبر VBA
type: docs
weight: 250
url: /ar/python-net/presentation-via-vba/
keywords:
- macro
- VBA
- VBA macro
- add macro
- remove macro
- extract macro
- add VBA
- remove VBA
- extract VBA
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "اكتشف كيفية إنشاء وتعديل عروض PowerPoint وOpenDocument عبر VBA باستخدام Aspose.Slides for Python via .NET لتبسيط سير عملك."
---

## **نظرة عامة**

تستعرض هذه المقالة القدرات الأساسية لـ Aspose.Slides for Python via .NET للعمل مع الماكرو في عروض PowerPoint. توفر المكتبة أدوات مريحة لإضافة وإزالة واستخراج الماكرو، مما يتيح لك أتمتة إنشاء وتعديل العروض التقديمية.

مع Aspose.Slides، يمكنك:

- تسريع تطوير العروض التقديمية — أتمتة المهام الروتينية تقلل الوقت اللازم لإعداد المواد.
- ضمان المرونة — قدرة إدارة الماكرو تتيح لك تخصيص العروض وفقًا للمهام والسيناريوهات المحددة.
- دمج البيانات — التكامل السهل مع مصادر بيانات خارجية يساعد على إبقاء محتوى الشرائح محدثًا.
- تبسيط الصيانة — إدارة الماكرو المركزية تسهل تطبيق التغييرات وتحديث العروض.

تستمر المقالة في تقديم أمثلة عملية حول كيفية استخدام Aspose.Slides للعمل بفعالية مع الماكرو في PowerPoint.

يوفر نطاق الاسم [aspose.slides.vba](https://reference.aspose.com/slides/python-net/aspose.slides.vba/) فئات للعمل مع الماكرو وكود VBA.

{{% alert title="ملاحظة" color="warning" %}}

عند تحويل عرض تقديمي يحتوي على ماكرو إلى تنسيق آخر (PDF، HTML، إلخ)، يتجاهل Aspose.Slides الماكرو — لا يتم نقلها إلى ملف الإخراج.

عند إضافة ماكرو إلى عرض تقديمي أو إعادة حفظ عرض يحتوي على ماكرو، يكتب Aspose.Slides بايتات الماكرو كما هي.

Aspose.Slides **لا** ينفذ الماكرو أبداً في العرض التقديمي.

{{% /alert %}}

## **إضافة ماكرو VBA**

يوفر Aspose.Slides الفئة [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) لإنشاء مشاريع VBA (ومراجع المشروع) وتحرير الوحدات الحالية.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. استخدم مُنشيء [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/#constructors) لإضافة مشروع VBA جديد.
3. أضف وحدة إلى مشروع VBA.
4. عيّن كود المصدر للوحدة.
5. أضف مرجعًا إلى `<stdole>`.
6. أضف مرجعًا إلى **Microsoft Office**.
7. اربط المراجع بمشروع VBA.
8. احفظ العرض التقديمي.

الكود التالي بلغة بايثون يوضح كيفية إضافة ماكرو VBA من الصفر إلى عرض تقديمي:

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

باستخدام خاصية [vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/) في فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)، يمكنك إزالة ماكرو VBA.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وحمّل العرض التقديمي الذي يحتوي على الماكرو.
2. وصول إلى وحدة الماكرو وإزالتها.
3. احفظ العرض التقديمي المعدل.

الكود التالي بلغة بايثون يوضح كيفية إزالة ماكرو VBA:

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

باستخدام خاصية `modules` في فئة [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/)، يمكنك الوصول إلى جميع وحدات مشروع VBA. يمكن استخدام فئة [VbaModule](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbamodule/) لاستخراج خصائص الوحدة مثل الاسم والكود.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وحمّل العرض التقديمي الذي يحتوي على الماكرو.
2. تحقق مما إذا كان العرض يحتوي على مشروع VBA.
3. تكرار عبر جميع الوحدات في مشروع VBA لعرض الماكرو.

الكود التالي بلغة بايثون يوضح كيفية استخراج ماكرو VBA من عرض تقديمي:

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

باستخدام خاصية [VbaProject.is_password_protected](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/is_password_protected/)، يمكنك تحديد ما إذا كانت خصائص المشروع محمية بكلمة مرور.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وحمّل عرضًا يحتوي على ماكرو.
2. تحقق مما إذا كان العرض يحتوي على [مشروع VBA](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/).
3. تحقق مما إذا كان مشروع VBA محميًا بكلمة مرور لعرض خصائصه.

```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Check whether the presentation contains a VBA project.
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```

## **الأسئلة المتكررة**

**ماذا يحدث للماكرو إذا حفظت العرض التقديمي كـ PPTX؟**

سيتم إزالة الماكرو لأن تنسيق PPTX لا يدعم VBA. للحفاظ على الماكرو، اختر PPTM أو PPSM أو POTM.

**هل يمكن لـ Aspose.Slides تشغيل الماكرو داخل العرض التقديمي، على سبيل المثال لتحديث البيانات؟**

لا. المكتبة لا تنفذ كود VBA مطلقًا؛ التنفيذ ممكن فقط داخل PowerPoint مع إعدادات الأمان المناسبة.

**هل الدعم متاح للتحكم في ActiveX المرتبط بكود VBA؟**

نعم، يمكنك الوصول إلى [عناصر التحكم ActiveX](/slides/ar/python-net/activex/) الموجودة، تعديل خصائصها، وإزالتها. هذا مفيد عندما تتفاعل الماكرو مع ActiveX.