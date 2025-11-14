---
title: العرض عبر VBA
type: docs
weight: 250
url: /ar/python-net/presentation-via-vba/
keywords: "ماكرو، ماكروز، VBA، ماكرو VBA، إضافة ماكرو، إزالة ماكرو، إضافة VBA، إزالة VBA، استخراج ماكرو، استخراج VBA، ماكرو باوربوينت، عرض باوربوينت، بايثون، Aspose.Slides لـ Python عبر .NET"
description: "إضافة وإزالة واستخراج ماكرو VBA في عروض باوربوينت باستخدام بايثون"
---

تحتوي مساحة أسماء [Aspose.Slides.Vba](https://reference.aspose.com/slides/python-net/aspose.slides.vba/) على فصول وواجهات للعمل مع الماكروز وكود VBA.

{{% alert title="ملاحظة" color="warning" %}} 

عند تحويل عرض يحتوي على ماكروز إلى تنسيق ملف مختلف (PDF، HTML، إلخ)، تتجاهل Aspose.Slides جميع الماكروز (لا يتم نقل الماكروز إلى الملف الناتج).

عند إضافة ماكروز إلى عرض أو إعادة حفظ عرض يحتوي على ماكروز، تكتب Aspose.Slides ببساطة البايتات الخاصة بالماكروز.

Aspose.Slides **لا** تقوم بتشغيل الماكروز في العرض.

{{% /alert %}}

## **إضافة ماكروز VBA**

توفر Aspose.Slides فصل [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) للسماح لك بإنشاء مشاريع VBA (ومراجع المشاريع) وتحرير الوحدات الحالية. يمكنك استخدام واجهة [IVbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/) لإدارة VBA المدمجة في العرض.

1. أنشئ مثيلاً لفصل [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. استخدم المنشئ [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/#constructors) لإضافة مشروع VBA جديد.
1. أضف وحدة إلى VbaProject.
1. قم بتعيين كود المصدر للوحدة.
1. أضف مراجع إلى <stdole>.
1. أضف مراجع إلى **Microsoft Office**.
1. اربط المراجع بمشروع VBA.
1. احفظ العرض.

يوضح لك هذا الكود باللغة بايثون كيفية إضافة ماكرو VBA من الصفر إلى عرض:

```python
import aspose.slides as slides

# ينشئ مثيلاً لفصل العرض
with slides.Presentation() as presentation:
    # ينشئ مشروع VBA جديد
    presentation.vba_project = slides.vba.VbaProject()

    # يضيف وحدة فارغة إلى مشروع VBA
    module = presentation.vba_project.modules.add_empty_module("Module")
  
    # يعين كود المصدر للوحدة
    module.source_code = "Sub Test(oShape As Shape) MsgBox ""Test"" End Sub"

    # ينشئ مرجعًا إلى <stdole>
    stdoleReference = slides.vba.VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # ينشئ مرجعًا إلى Office
    officeReference =slides.vba.VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # يضيف مراجع إلى مشروع VBA
    presentation.vba_project.references.add(stdoleReference)
    presentation.vba_project.references.add(officeReference)

            
    # يحفظ العرض
    presentation.save("AddVBAMacros_out.pptm", slides.export.SaveFormat.PPTM)
```

{{% alert color="primary" %}} 

قد ترغب في الاطلاع على **Aspose** [مزيل الماكروز](https://products.aspose.app/slides/remove-macros)، وهو تطبيق ويب مجاني يستخدم لإزالة الماكروز من مستندات باوربوينت وإكسل وورد.

{{% /alert %}} 

## **إزالة ماكروز VBA**

باستخدام خاصية [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/#properties) داخل فصل [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ، يمكنك إزالة ماكرو VBA.

1. أنشئ مثيلاً لفصل [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وقم بتحميل العرض الذي يحتوي على الماكرو.
1. الوصول إلى وحدة الماكرو وإزالتها.
1. احفظ العرض المعدل.

يوضح لك هذا الكود باللغة بايثون كيفية إزالة ماكرو VBA:

```python
import aspose.slides as slides

# يحمل العرض الذي يحتوي على الماكرو
with slides.Presentation(path + "VBA.pptm") as presentation:
    # يصل إلى وحدة Vba ويزيلها  
    presentation.vba_project.modules.remove(presentation.vba_project.modules[0])

    # يحفظ العرض
    presentation.save("RemovedVBAMacros_out.pptm", slides.export.SaveFormat.PPTM)
```

## **استخراج ماكروز VBA**

1. أنشئ مثيلاً لفصل [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وقم بتحميل العرض الذي يحتوي على الماكرو.
2. تحقق مما إذا كان العرض يحتوي على مشروع VBA.
3. قم بالمرور على جميع الوحدات المحتواة في مشروع VBA لعرض الماكروز.

يوضح لك هذا الكود باللغة بايثون كيفية استخراج ماكروز VBA من عرض يحتوي على ماكروز:

```python
import aspose.slides as slides

with slides.Presentation(path + "VBA.pptm") as pres:
    if pres.vba_project is not None: # يتحقق مما إذا كان العرض يحتوي على مشروع VBA
        for module in pres.vba_project.modules:
            print(module.name)
            print(module.source_code)
```