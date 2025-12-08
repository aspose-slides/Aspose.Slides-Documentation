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
- بايثون
- Aspose.Slides
description: "اكتشف كيفية إنشاء ومعالجة عروض PowerPoint وOpenDocument عبر VBA باستخدام Aspose.Slides للغة بايثون عبر .NET لتبسيط سير عملك."
---

## **نظرة عامة**

تناقش هذه المقالة القدرات الأساسية لـ Aspose.Slides للغة بايثون عبر .NET للعمل مع الماكرو في عروض PowerPoint التقديمية. توفر المكتبة أدوات مريحة لإضافة الماكرو وإزالتها واستخراجها، مما يتيح لك أتمتة إنشاء وتعديل العروض التقديمية.

- تسريع تطوير العروض التقديمية — أتمتة المهام الروتينية تقلل الوقت اللازم لإعداد المواد.
- ضمان المرونة — إمكانية إدارة الماكرو تسمح لك بتخصيص العروض وفقًا للمهام والسيناريوهات المحددة.
- دمج البيانات — دمج بسيط مع مصادر البيانات الخارجية يساعد على الحفاظ على محتوى الشرائح محدثًا.
- تبsimplify الصيانة — إدارة الماكرو المركزية تجعل تطبيق التغييرات وتحديث العروض أسهل.

تستمر المقالة في تقديم أمثلة عملية حول كيفية استخدام Aspose.Slides للعمل بفعالية مع الماكرو في PowerPoint.

توفر مساحة الأسماء [aspose.slides.vba](https://reference.aspose.com/slides/python-net/aspose.slides.vba/) فئات للعمل مع الماكرو وكود VBA.

{{% alert title="Note" color="warning" %}}
عند تحويل عرض تقديمي يحتوي على ماكرو إلى تنسيق آخر (PDF، HTML، إلخ)، يتجاهل Aspose.Slides الماكرو — لا يتم نقلها إلى ملف الإخراج.

عند إضافة ماكرو إلى عرض تقديمي أو حفظ عرض تقديمي يحتوي على ماكرو مرة أخرى، يقوم Aspose.Slides بكتابة بايتات الماكرو كما هي.

Aspose.Slides **أبدًا** لا ينفّذ الماكرو في العرض التقديمي.
{{% /alert %}}

## **إضافة ماكرو VBA**

يوفر Aspose.Slides الفئة [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) لإنشاء مشاريع VBA (ومراجع المشروع) وتحرير الوحدات الموجودة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. استخدم مُنشئ [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/#constructors) لإضافة مشروع VBA جديد.
3. أضف وحدة إلى مشروع VBA.
4. حدد شفرة المصدر للوحدة.
5. أضف إشارة إلى `<stdole>`.
6. أضف إشارة إلى **Microsoft Office**.
7. ربط الإشارات بمشروع VBA.
8. احفظ العرض التقديمي.

يعرض الشيفرة Python التالية كيفية إضافة ماكرو VBA من الصفر إلى عرض تقديمي:
```python
import aspose.slides as slides

# إنشاء نسخة من فئة Presentation.
with slides.Presentation() as presentation:

    # إنشاء مشروع VBA جديد.
    presentation.vba_project = slides.vba.VbaProject()

    # إضافة وحدة فارغة إلى مشروع VBA.
    module = presentation.vba_project.modules.add_empty_module("Module")

    # تعيين شفرة المصدر للوحدة.
    module.source_code = """
        Sub Test(oShape As Shape)
            MsgBox "Hello, world!"
        End Sub
    """

    # إنشاء إشارة إلى <stdole>.
    stdole_reference = slides.vba.VbaReferenceOleTypeLib("stdole",
        "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # إنشاء إشارة إلى Microsoft Office.
    office_reference = slides.vba.VbaReferenceOleTypeLib("Office",
        "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # إضافة الإشارات إلى مشروع VBA.
    presentation.vba_project.references.add(stdole_reference)
    presentation.vba_project.references.add(office_reference)

    # حفظ العرض التقديمي.
    presentation.save("macros.pptm", slides.export.SaveFormat.PPTM)
```


{{% alert color="primary" %}}
قد ترغب في تجربة **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros)، تطبيق ويب مجاني لإزالة الماكرو من مستندات PowerPoint وExcel وWord.
{{% /alert %}}

## **إزالة ماكرو VBA**

باستخدام خاصية [vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/) للفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) يمكنك إزالة ماكرو VBA.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وتحميل العرض التقديمي الذي يحتوي على الماكرو.
2. الوصول إلى وحدة الماكرو وإزالتها.
3. احفظ العرض التقديمي المعدل.

```python
import aspose.slides as slides

# تحميل العرض التقديمي الذي يحتوي على الماكرو.
with slides.Presentation("VBA.pptm") as presentation:
    
    # الوصول إلى وحدة VBA.
    vba_module = presentation.vba_project.modules[0]

    # إزالة وحدة VBA.
    presentation.vba_project.modules.remove(vba_module)

    # حفظ العرض التقديمي.
    presentation.save("removed_macro.pptm", slides.export.SaveFormat.PPTM)
```


## **استخراج ماكرو VBA**

باستخدام خاصية `modules` في فئة [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) يمكنك الوصول إلى جميع وحدات مشروع VBA. يمكن استخدام فئة [VbaModule](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbamodule/) لاستخراج خصائص الوحدة مثل الاسم والشفرة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وتحميل العرض التقديمي الذي يحتوي على الماكرو.
2. التحقق مما إذا كان العرض التقديمي يحتوي على مشروع VBA.
3. التمرّ عبر جميع الوحدات في مشروع VBA لعرض الماكرو.

```python
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # تحقق مما إذا كان العرض التقديمي يحتوي على مشروع VBA.
    if presentation.vba_project is not None:
        for module in presentation.vba_project.modules:
            print(module.name)
            print(module.source_code)
```


## **التحقق مما إذا كان مشروع VBA محميًا بكلمة مرور**

باستخدام خاصية [VbaProject.is_password_protected](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/is_password_protected/) يمكنك معرفة ما إذا كانت خصائص المشروع محمية بكلمة مرور.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وتحميل عرض تقديمي يحتوي على ماكرو.
2. التحقق مما إذا كان العرض التقديمي يحتوي على [VBA project](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/).
3. التحقق مما إذا كان مشروع VBA محميًا بكلمة مرور لعرض خصائصه.
```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # تحقق مما إذا كان العرض التقديمي يحتوي على مشروع VBA.
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```


## **الأسئلة المتداولة**

**ماذا يحدث للماكرو إذا حفظت العرض التقديمي بصيغة PPTX؟**

سيتم إزالة الماكرو لأن صيغة PPTX لا تدعم VBA. للحفاظ على الماكرو، اختر PPTM أو PPSM أو POTM.

**هل يمكن لـ Aspose.Slides تشغيل الماكرو داخل عرض تقديمي لتحديث البيانات مثلاً؟**

لا. المكتبة لا تنفّذ كود VBA أبداً؛ التنفيذ ممكن فقط داخل PowerPoint مع إعدادات الأمان المناسبة.

**هل يدعم العمل مع عناصر تحكم ActiveX المرتبطة بكود VBA؟**

نعم، يمكنك الوصول إلى عناصر تحكم [ActiveX controls](/slides/ar/python-net/activex/)، تعديل خصائصها، وإزالتها. هذا مفيد عندما يتفاعل الماكرو مع ActiveX.