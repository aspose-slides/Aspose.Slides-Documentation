---
title: العرض عبر VBA
type: docs
weight: 250
url: /ar/java/presentation-via-vba/
keywords: "ماكرو، ماكروز، VBA، ماكرو VBA، إضافة ماكرو، إزالة ماكرو، إضافة VBA، إزالة VBA، استخراج ماكرو، استخراج VBA، ماكرو باوربوينت، عرض باوربوينت، جافا، Aspose.Slides for Java"
description: "إضافة وإزالة واستخراج ماكرو VBA في عروض باوربوينت في جافا"
---

{{% alert title="ملاحظة" color="warning" %}} 

عند تحويل عرض يحتوي على ماكروز إلى تنسيق ملف مختلف (PDF، HTML، إلخ)، تتجاهل Aspose.Slides جميع الماكروز (لا يتم نقل الماكروز إلى الملف الناتج).

عند إضافة ماكروز إلى عرض أو إعادة حفظ عرض يحتوي على ماكروز، تقوم Aspose.Slides ببساطة بكتابة البايتات للماكروز.

Aspose.Slides **لا** تنفذ الماكروز في العرض.

{{% /alert %}}

## **إضافة ماكروز VBA**

توفر Aspose.Slides فئة [VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/) للسماح لك بإنشاء مشاريع VBA (ومراجع المشروع) وتحرير الوحدات الموجودة. يمكنك استخدام واجهة [IVbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/ivbaproject/) لإدارة VBA المضمنة في العرض.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
2. استخدم المُنشئ [VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/#VbaProject--) لإضافة مشروع VBA جديد.
3. أضف وحدة إلى VbaProject.
4. حدد كود المصدر للوحدة.
5. أضف مراجع إلى <stdole>.
6. أضف مراجع إلى **Microsoft Office**.
7. اربط المراجع بمشروع VBA.
8. احفظ العرض.

يظهر هذا الرمز بلغة جافا لك كيفية إضافة ماكرو VBA من الصفر إلى عرض:

```java
// ينشئ مثيل من فئة العرض
Presentation pres = new Presentation();
try {
    // ينشئ مشروع VBA جديد
    pres.setVbaProject(new VbaProject());
    
    // يضيف وحدة فارغة إلى مشروع VBA
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // يحدد كود المصدر للوحدة
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

قد ترغب في التحقق من **Aspose** [إزالة الماكروز](https://products.aspose.app/slides/remove-macros)، وهي تطبيق ويب مجاني يُستخدم لإزالة الماكروز من مستندات باوربوينت وإكسل ووورد. 

{{% /alert %}} 

## **إزالة ماكروز VBA**

باستخدام خاصية [VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getVbaProject--) تحت فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)، يمكنك إزالة ماكرو VBA.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) وتحميل العرض الذي يحتوي على الماكرو.
2. الوصول إلى وحدة الماكرو وإزالتها.
3. احفظ العرض المعدل.

يظهر هذا الرمز بلغة جافا لك كيفية إزالة ماكرو VBA:

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

## **استخراج ماكروز VBA**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) وتحميل العرض الذي يحتوي على الماكرو.
2. تحقق مما إذا كان العرض يحتوي على مشروع VBA.
3. قم بتكرار جميع الوحدات الموجودة في مشروع VBA لمشاهدة الماكروز.

يظهر هذا الرمز بلغة جافا لك كيفية استخراج ماكروز VBA من عرض يحتوي على ماكروز:

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