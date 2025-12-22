---
title: إدارة مشاريع VBA في العروض التقديمية على Android
linktitle: عرض تقديمي عبر VBA
type: docs
weight: 250
url: /ar/androidjava/presentation-via-vba/
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
- Android
- Java
- Aspose.Slides
description: "اكتشف كيف يمكنك إنشاء ومعالجة عروض PowerPoint وOpenDocument عبر VBA باستخدام Aspose.Slides لنظام Android عبر Java لتبسيط سير عملك."
---

{{% alert title="Note" color="warning" %}} 

عند تحويل عرض تقديمي يحتوي على ماكرو إلى تنسيق ملف مختلف (PDF، HTML، إلخ)، يتجاهل Aspose.Slides جميع الماكروهات (لا تُنقل الماكروهات إلى الملف الناتج).

عند إضافة ماكروهات إلى عرض تقديمي أو إعادة حفظ عرض تقديمي يحتوي على ماكروهات، يقوم Aspose.Slides ببساطة بكتابة البايتات الخاصة بالماكروهات.

Aspose.Slides **أبدًا** لا ينفذ الماكروهات في العرض التقديمي.

{{% /alert %}}

## **إضافة ماكروهات VBA**

توفر Aspose.Slides الفئة [VbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/vbaproject/) لتسمح لك بإنشاء مشاريع VBA (ومراجع المشروع) وتعديل الوحدات الحالية. يمكنك استخدام الواجهة [IVbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivbaproject/) لإدارة VBA المدمج في عرض تقديمي.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) class.
1. استخدم مُنشئ [VbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/vbaproject/#VbaProject--) لإضافة مشروع VBA جديد.
1. إضافة وحدة إلى VbaProject.
1. تعيين شفرة المصدر للوحدة.
1. إضافة مراجع إلى <stdole>.
1. إضافة مراجع إلى **Microsoft Office**.
1. ربط المراجع بمشروع VBA.
1. حفظ العرض التقديمي.

يعرض هذا الكود Java كيفية إضافة ماكرو VBA من الصفر إلى عرض تقديمي:
```java
// ينشئ كائنًا من فئة العرض التقديمي
Presentation pres = new Presentation();
try {
    // ينشئ مشروع VBA جديد
    pres.setVbaProject(new VbaProject());
    
    // يضيف وحدة فارغة إلى مشروع VBA
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // يضبط شفرة المصدر للوحدة
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // ينشئ إشارة إلى <stdole>
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // ينشئ إشارة إلى Office
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // يضيف مراجع إلى مشروع VBA
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // يحفظ العرض التقديمي
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 

قد ترغب في تجربة **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros)، وهو تطبيق ويب مجاني يُستخدم لإزالة الماكروهات من مستندات PowerPoint وExcel وWord.

{{% /alert %}} 

## **إزالة ماكروهات VBA**

باستخدام خاصية [VbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getVbaProject--) ضمن الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) class، يمكنك إزالة ماكرو VBA.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) وتحميل العرض التقديمي الذي يحتوي على الماكرو.
1. الوصول إلى وحدة الماكرو وإزالتها.
1. حفظ العرض التقديمي المعدل.

يعرض هذا الكود Java كيفية إزالة ماكرو VBA:
```java
// يحمل العرض التقديمي الذي يحتوي على الماكرو
Presentation pres = new Presentation("VBA.pptm");
try {
    // يصل إلى وحدة Vba ويزيلها 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // يحفظ العرض التقديمي
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```


## **استخراج ماكروهات VBA**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) وتحميل العرض التقديمي الذي يحتوي على الماكرو.
2. التحقق مما إذا كان العرض التقديمي يحتوي على مشروع VBA.
3. التجول عبر جميع الوحدات الموجودة في مشروع VBA لعرض الماكروهات.

يعرض هذا الكود Java كيفية استخراج ماكروهات VBA من عرض تقديمي يحتوي على ماكروهات:
```java
// تحميل العرض التقديمي الذي يحتوي على الماكرو
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // يتحقق مما إذا كان العرض التقديمي يحتوي على مشروع VBA
    {
        for (IVbaModule module : pres.getVbaProject().getModules())
        {
            System.out.println(module.getName());
            System.out.println(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **التحقق مما إذا كان مشروع VBA محميًا بكلمة مرور**

باستخدام طريقة [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivbaproject/#isPasswordProtected--) يمكنك تحديد ما إذا كانت خصائص المشروع محمية بكلمة مرور.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) وتحميل عرض تقديمي يحتوي على ماكرو.
2. التحقق مما إذا كان العرض التقديمي يحتوي على [VBA project](https://reference.aspose.com/slides/androidjava/com.aspose.slides/vbaproject/).
3. التحقق مما إذا كان مشروع VBA محميًا بكلمة مرور لعرض خصائصه.
```java
Presentation presentation = new Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // تحقق مما إذا كان العرض التقديمي يحتوي على مشروع VBA.
        if (presentation.getVbaProject().isPasswordProtected()) {
            System.out.printf("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```


## **الأسئلة الشائعة**

**ماذا يحدث للماكروهات إذا حفظت العرض التقديمي كملف PPTX؟**

سيتم إزالة الماكروهات لأن PPTX لا يدعم VBA. للاحتفاظ بالماكروهات، اختر PPTM أو PPSM أو POTM.

**هل يمكن لـ Aspose.Slides تشغيل الماكروهات داخل عرض تقديمي، مثلاً لتحديث البيانات؟**

لا. المكتبة لا تنفذ شفرة VBA أبدًا؛ التنفيذ ممكن فقط داخل PowerPoint مع إعدادات الأمان المناسبة.

**هل يتم دعم العمل مع عناصر تحكم ActiveX المرتبطة بشفرة VBA؟**

نعم، يمكنك الوصول إلى عناصر تحكم ActiveX الموجودة [ActiveX controls](/slides/ar/androidjava/activex/)، تعديل خصائصها، وإزالتها. هذا مفيد عندما تتفاعل الماكروهات مع ActiveX.