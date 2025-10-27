---
title: إدارة مشاريع VBA في العروض التقديمية باستخدام بايثون
linktitle: العرض التقديمي عبر VBA
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
description: "اكتشف كيفية إنشاء وعرض وتعديل عروض PowerPoint وOpenDocument عبر VBA باستخدام Aspose.Slides لبايثون عبر .NET لتبسيط سير العمل الخاص بك."
---

## **نظرة عامة**

تستعرض هذه المقالة القدرات الأساسية لـ Aspose.Slides لبايثون عبر .NET للعمل مع الماكروهات في عروض PowerPoint. توفر المكتبة أدوات مريحة لإضافة وإزالة واستخراج الماكروهات، مما يتيح لك أتمتة إنشاء وتعديل العروض التقديمية.

مع Aspose.Slides، يمكنك:

- تسريع تطوير العروض — أتمتة المهام الروتينية تقلل الوقت المطلوب لإعداد المواد.
- ضمان المرونة — القدرة على إدارة الماكروهات تتيح لك تخصيص العروض لتتناسب مع مهام وسيناريوهات محددة.
- دمج البيانات — التكامل السهل مع مصادر البيانات الخارجية يساعد على إبقاء محتوى الشرائح محدثًا.
- تبسيط الصيانة — إدارة الماكروهات مركزية تجعل تطبيق التغييرات وتحديث العروض أسهل.

تستمر المقالة في تقديم أمثلة عملية لكيفية استخدام Aspose.Slides للعمل بفعالية مع الماكروهات في PowerPoint.

توفر مساحة الاسم [aspose.slides.vba](https://reference.aspose.com/slides/python-net/aspose.slides.vba/) فئات للعمل مع الماكروهات وكود VBA.

{{% alert title="Note" color="warning" %}}

عند تحويل عرض يحتوي على ماكروهات إلى تنسيق آخر (PDF، HTML، إلخ)، يتجاهل Aspose.Slides الماكروهات — لا يتم نقلها إلى ملف الإخراج.

عند إضافة ماكروهات إلى عرض أو إعادة حفظ عرض يحتوي على ماكروهات، يكتب Aspose.Slides بايتات الماكرو كما هي.

Aspose.Slides **أبدًا** لا ينفذ الماكروهات في العرض.

{{% /alert %}}

## **إضافة ماكروهات VBA**

يوفر Aspose.Slides الفئة [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) لإنشاء مشاريع VBA (ومراجع المشاريع) ولتحرير الوحدات الموجودة.

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. استخدم مُنشئ [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/#constructors) لإضافة مشروع VBA جديد.
1. أضف وحدة إلى مشروع VBA.
1. عيّن شفرة المصدر الخاصة بالوحدة.
1. أضف مرجعًا إلى `<stdole>`.
1. أضف مرجعًا إلى **Microsoft Office**.
1. اربط المراجع بمشروع VBA.
1. احفظ العرض.

الكود التالي بلغة Python يوضح كيفية إضافة ماكرو VBA من الصفر إلى عرض:

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

قد ترغب في تجربة **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros)، وهو تطبيق ويب مجاني لإزالة الماكروهات من مستندات PowerPoint وExcel وWord.

{{% /alert %}}

## **إزالة ماكروهات VBA**

باستخدام الخاصية [vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/) من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)، يمكنك إزالة ماكرو VBA.

1. أنشئ مثالًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وقم بتحميل العرض الذي يحتوي على الماكرو.
1. وصل إلى وحدة الماكرو وأزلها.
1. احفظ العرض المعدل.

الكود التالي بلغة Python يوضح كيفية إزالة ماكرو VBA:

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

## **استخراج ماكروهات VBA**

باستخدام الخاصية `modules` في فئة [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/)، يمكنك الوصول إلى جميع وحدات مشروع VBA. يمكن استخدام فئة [VbaModule](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbamodule/) لاستخراج خصائص الوحدة مثل الاسم والكود.

1. أنشئ مثالًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وقم بتحميل العرض الذي يحتوي على الماكرو.
1. تحقق مما إذا كان العرض يحتوي على مشروع VBA.
1. استعرض جميع الوحدات في مشروع VBA لعرض الماكروهات.

الكود التالي بلغة Python يوضح كيفية استخراج ماكروهات VBA من عرض:

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

باستخدام الخاصية [VbaProject.is_password_protected](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/is_password_protected/)، يمكنك تحديد ما إذا كانت خصائص المشروع محمية بكلمة مرور.

1. أنشئ مثالًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وقم بتحميل عرض يحتوي على ماكرو.
1. تحقق مما إذا كان العرض يحتوي على [VBA project](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/).
1. تحقق مما إذا كان مشروع VBA محميًا بكلمة مرور لعرض خصائصه.

```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Check whether the presentation contains a VBA project.
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```

## **الأسئلة المتكررة**

**ماذا يحدث للماكروهات إذا حفظت العرض بصيغة PPTX؟**

يتم إزالة الماكروهات لأن PPTX لا يدعم VBA. للاحتفاظ بالماكروهات، اختر PPTM أو PPSM أو POTM.

**هل يمكن لـ Aspose.Slides تشغيل الماكروهات داخل العرض لتحديث البيانات مثلاً؟**

لا. المكتبة لا تنفذ كود VBA أبداً؛ التنفيذ ممكن فقط داخل PowerPoint وفق إعدادات الأمان المناسبة.

**هل دعم التحكمات ActiveX المرتبطة بكود VBA متاح؟**

نعم، يمكنك الوصول إلى [ActiveX controls](/slides/ar/python-net/activex/)، تعديل خصائصها وإزالتها. هذا مفيد عندما تتفاعل الماكروهات مع تحكمات ActiveX.