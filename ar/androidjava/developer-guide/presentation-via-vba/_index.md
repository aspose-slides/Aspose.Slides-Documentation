---
title: العرض عبر VBA
type: docs
weight: 250
url: /ar/androidjava/presentation-via-vba/
keywords: "ماكرو، ماكروز، VBA، ماكرو VBA، إضافة ماكرو، إزالة ماكرو، إضافة VBA، إزالة VBA، استخراج ماكرو، استخراج VBA، ماكرو PowerPoint، عرض PowerPoint، Java، Aspose.Slides for Android via Java"
description: "إضافة وإزالة واستخراج ماكروس VBA في عروض PowerPoint بجافا"
---

{{% alert title="ملاحظة" color="warning" %}} 

عند تحويل عرض يحتوي على ماكروز إلى تنسيق ملف مختلف (PDF، HTML، إلخ)، تتجاهل Aspose.Slides جميع الماكروز (لا تُنقل الماكروز إلى الملف الناتج).

عند إضافة ماكروز إلى عرض أو إعادة حفظ عرض يحتوي على ماكروز، تقوم Aspose.Slides ببساطة بكتابة بيانت الماكروز.

لا تقوم Aspose.Slides **أبدًا** بتشغيل الماكروز في العرض.

{{% /alert %}}

## **إضافة ماكروس VBA**

توفر Aspose.Slides فئة [VbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/vbaproject/) للسماح لك بإنشاء مشاريع VBA (ومراجع المشاريع) وتحرير الوحدات الموجودة. يمكنك استخدام واجهة [IVbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivbaproject/) لإدارة VBA المضمن في عرض.

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. استخدم مُنشئ [VbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/vbaproject/#VbaProject--) لإضافة مشروع VBA جديد.
1. أضف وحدة إلى VbaProject.
1. قم بضبط كود المصدر للوحدة.
1. أضف مراجع إلى <stdole>.
1. أضف مراجع إلى **Microsoft Office**.
1. اربط المراجع بمشروع VBA.
1. احفظ العرض.

يوضح لك هذا الرمز بلغة Java كيفية إضافة ماكرو VBA من الصفر إلى عرض:

```java
// ينشئ مثيلًا من فئة العرض
Presentation pres = new Presentation();
try {
    // ينشئ مشروع VBA جديد
    pres.setVbaProject(new VbaProject());
    
    // يضيف وحدة فارغة إلى مشروع VBA
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // يضبط كود المصدر للوحدة
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // ينشئ مرجعًا إلى <stdole>
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // ينشئ مرجعًا إلى Office
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // يضيف المراجع إلى مشروع VBA
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // يحفظ العرض
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

قد ترغب في التحقق من **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros)، وهو تطبيق ويب مجاني يُستخدم لإزالة الماكروز من مستندات PowerPoint وExcel وWord. 

{{% /alert %}} 

## **إزالة ماكروس VBA**

باستخدام خاصية [VbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getVbaProject--) تحت فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)، يمكنك إزالة ماكرو VBA.

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) وقم بتحميل العرض الذي يحتوي على الماكرو.
1. الوصول إلى وحدة الماكرو وإزالتها.
1. احفظ العرض المعدل.

يوضح لك هذا الرمز بلغة Java كيفية إزالة ماكرو VBA:

```java
// يحمل العرض الذي يحتوي على الماكرو
Presentation pres = new Presentation("VBA.pptm");
try {
    // يصل إلى وحدة Vba ويزيلها 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // يحفظ العرض
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **استخراج ماكروس VBA**

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) وقم بتحميل العرض الذي يحتوي على الماكرو.
2. تحقق مما إذا كان العرض يحتوي على مشروع VBA.
3. قم بتكرار جميع الوحدات الموجودة في مشروع VBA لعرض الماكروز.

يوضح لك هذا الرمز بلغة Java كيفية استخراج ماكروس VBA من عرض يحتوي على ماكروز:

```java
// يحمل العرض الذي يحتوي على الماكرو
Presentation pres = new Presentation("VBA.pptm");
try {
    if (pres.getVbaProject() != null) // يتحقق مما إذا كان العرض يحتوي على مشروع VBA
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