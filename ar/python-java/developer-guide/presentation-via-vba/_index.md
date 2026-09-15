---
title: إدارة مشاريع VBA في العروض التقديمية باستخدام Python
linktitle: العرض التقديمي عبر VBA
type: docs
weight: 250
url: /ar/python-java/presentation-via-vba/
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
- Java
- Aspose.Slides
description: "اكتشف كيف يمكنك إنشاء وتعديل عروض PowerPoint وOpenDocument عبر VBA باستخدام Aspose.Slides للغة Python عبر Java لتبسيط سير العمل الخاص بك."
---
## **المقدمة**

Aspose.Slides يوفر فئات وواجهات للعمل مع الماكروهات وكود VBA.

{{% alert title="تحذير" color="warning" %}} 

عند تحويل عرض تقديمي يحتوي على ماكروهات إلى تنسيق ملف مختلف (PDF، HTML، إلخ)، يتجاهل Aspose.Slides جميع الماكروهات (لا يتم نقل الماكروهات إلى الملف الناتج).

عند إضافة ماكروهات إلى عرض تقديمي أو حفظ عرض تقديمي يحتوي على ماكروهات مرة أخرى، يكتب Aspose.Slides ببساطة بايتات الماكروهات.

Aspose.Slides **لا** يشغل الماكروهات أبداً في أي عرض تقديمي.

{{% /alert %}}

## **إضافة ماكروهات VBA**

Aspose.Slides يوفر الفئة [VbaProject](https://reference.aspose.com/slides/ar/python-java/aspose.slides/vbaproject/) للسماح لك بإنشاء مشاريع VBA (والمراجع الخاصة بالمشروع) وتحرير الوحدات الموجودة. يمكنك استخدام الفئة [VbaProject](https://reference.aspose.com/slides/ar/python-java/aspose.slides/vbaproject/) لإدارة VBA المدمج في عرض تقديمي.

1. إنشاء مثيل للفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
1. استخدام مُنشئ [VbaProject](https://reference.aspose.com/slides/ar/python-java/aspose.slides/vbaproject/#vbaproject) لإضافة مشروع VBA جديد.
1. إضافة وحدة إلى مشروع VBA.
1. تعيين شفرة المصدر للوحدة.
1. إضافة مراجع إلى `stdole`.
1. إضافة مراجع إلى **Microsoft Office**.
1. ربط المراجع بمشروع VBA.
1. حفظ العرض التقديمي.

يعرض هذا الكود Python كيفية إضافة ماكرو VBA من الصفر إلى عرض تقديمي:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VbaProject, VbaReferenceOleTypeLib

presentation = Presentation()
try:
    # إنشاء مشروع VBA جديد.
    vba_project = VbaProject()
    presentation.setVbaProject(vba_project)

    # إضافة وحدة فارغة وتعيين شفرة المصدر لها.
    module = vba_project.getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test(oShape As Shape)\n    MsgBox "Test"\nEnd Sub')

    # إنشاء مراجع إلى stdole وMicrosoft Office.
    stdole_reference = VbaReferenceOleTypeLib("stdole", r"*\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\Windows\system32\stdole2.tlb#OLE Automation")
    office_reference = VbaReferenceOleTypeLib("Office", r"*\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\Program Files\Common Files\Microsoft Shared\OFFICE14\MSO.DLL#Microsoft Office 14.0 Object Library")

    # إضافة المراجع إلى مشروع VBA.
    vba_project.getReferences().add(stdole_reference)
    vba_project.getReferences().add(office_reference)

    # حفظ العرض التقديمي.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

{{% alert color="info" title="ملاحظة" %}} 

قد ترغب في إلقاء نظرة على **Aspose** [Macro Remover](https://products.aspose.app/slides/ar/remove-macros)، وهو تطبيق ويب مجاني يُستخدم لإزالة الماكروهات من مستندات PowerPoint وExcel وWord.

{{% /alert %}} 

## **إزالة ماكروهات VBA**

باستخدام طريقة [getVbaProject](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getvbaproject) للفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/)، يمكنك إزالة ماكرو VBA.

1. إنشاء مثيل للفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) وتحميل العرض التقديمي الذي يحتوي على الماكرو.
1. الوصول إلى وحدة الماكرو وإزالتها.
1. حفظ العرض التقديمي المعدل.

يعرض هذا الكود Python كيفية إزالة ماكرو VBA:

```python
import jpade
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# تحميل العرض التقديمي الذي يحتوي على الماكرو.
presentation = Presentation("VBA.pptm")
try:
    # الوصول إلى وحدة VBA وإزالتها.
    vba_project = presentation.getVbaProject()
    if vba_project is not None and len(list(vba_project.getModules())) > 0:
        module = vba_project.getModules().get_Item(0)
        vba_project.getModules().remove(module)

    # حفظ العرض التقديمي.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **استخراج ماكروهات VBA**

1. إنشاء مثيل للفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) وتحميل العرض التقديمي الذي يحتوي على الماكرو.
2. التأكد مما إذا كان العرض التقديمي يحتوي على مشروع VBA.
3. التجول عبر جميع الوحدات الموجودة في مشروع VBA لعرض الماكروهات.

يعرض هذا الكود Python كيفية استخراج ماكروهات VBA من عرض تقديمي يحتوي على ماكروهات:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

from asposeslides.api import Presentation

# تحميل العرض التقديمي الذي يحتوي على الماكرو.
presentation = Presentation("VBA.pptm")
try:
    # التحقق مما إذا كان العرض التقديمي يحتوي على مشروع VBA.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        for module in vba_project.getModules():
            print(module.getName())
            print(module.getSourceCode())
finally:
    presentation.dispose()
```

## **التحقق مما إذا كان مشروع VBA محميًا بكلمة مرور**

باستخدام طريقة [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/ar/python-java/aspose.slides/vbaproject/#ispasswordprotected)، يمكنك تحديد ما إذا كانت خصائص المشروع محمية بكلمة مرور.

1. إنشاء مثيل للفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) وتحميل عرض تقديمي يحتوي على ماكرو.
2. التحقق مما إذا كان العرض التقديمي يحتوي على [VBA project](https://reference.aspose.com/slides/ar/python-java/aspose.slides/vbaproject/).
3. التحقق مما إذا كان مشروع VBA محميًا بكلمة مرور لعرض خصائصه.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("VBA.pptm")
try:
    # التحقق مما إذا كان العرض التقديمي يحتوي على مشروع VBA.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        if vba_project.isPasswordProtected():
            print(f"The VBA project '{vba_project.getName()}' is password-protected for viewing its properties.")
finally:
    presentation.dispose()
```

## **الأسئلة الشائعة**

**ماذا يحدث للماكروهات إذا حفظت العرض التقديمي كملف PPTX؟**

سيتم إزالة الماكروهات لأن PPTX لا يدعم VBA. للحفاظ على الماكروهات، اختر PPTM أو PPSM أو POTM.

**هل يمكن لـ Aspose.Slides تشغيل الماكروهات داخل عرض تقديمي، على سبيل المثال لتحديث البيانات؟**

لا. المكتبة لا تُنفّذ كود VBA أبداً؛ التنفيذ ممكن فقط داخل PowerPoint مع إعدادات الأمان المناسبة.

**هل يدعم العمل مع عناصر تحكم ActiveX المرتبطة بكود VBA؟**

نعم، يمكنك الوصول إلى عناصر تحكم ActiveX الموجودة، تعديل خصائصها، وإزالتها. هذا مفيد عندما تتفاعل الماكروهات مع ActiveX.