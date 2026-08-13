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
description: "اكتشف كيفية إنشاء ومعالجة عروض PowerPoint وOpenDocument عبر VBA باستخدام Aspose.Slides لنظام Android عبر Java لتبسيط سير العمل الخاص بك."
---
## **المقدمة**

Aspose.Slides توفر فئات وواجهات للعمل مع ماكروهات وكود VBA.

{{% alert title="Note" color="warning" %}} 
عند تحويل عرض تقديمي يحتوي على ماكروهات إلى تنسيق ملف مختلف (PDF، HTML، إلخ)، تتجاهل Aspose.Slides جميع الماكروهات (لا يتم نقل الماكروهات إلى الملف الناتج).

عند إضافة ماكروهات إلى عرض تقديمي أو حفظ عرض تقديمي يحتوي على ماكروهات مرة أخرى، تقوم Aspose.Slides ببساطة بكتابة البايتات الخاصة بالماكروهات.

Aspose.Slides **لا** تقوم **أبدًا** بتشغيل الماكروهات في عرض تقديمي.
{{% /alert %}}

## **إضافة ماكرو VBA**

توفر Aspose.Slides الفئة [VbaProject](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/vbaproject/) لتتيح لك إنشاء مشاريع VBA (ومراجع المشروع) وتعديل الوحدات الموجودة. يمكنك استخدام الواجهة [IVbaProject](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivbaproject/) لإدارة VBA المضمّن في عرض تقديمي.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation).
1. استخدم منشئ [VbaProject](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/vbaproject/#VbaProject--) لإضافة مشروع VBA جديد.
1. أضف وحدة إلى VbaProject.
1. حدد شفرة المصدر للوحدة.
1. أضف مراجع إلى <stdole>.
1. أضف مراجع إلى **Microsoft Office**.
1. ربط المراجع بمشروع VBA.
1. احفظ العرض التقديمي.

يعرض هذا الكود جافا كيفية إضافة ماكرو VBA من البداية إلى عرض تقديمي:

```java
import com.aspose.slides.*;

// إنشاء مثيل من فئة العرض التقديمي
Presentation pres = new Presentation();
try {
    // إنشاء مشروع VBA جديد
    pres.setVbaProject(new VbaProject());
    
    // إضافة وحدة فارغة إلى مشروع VBA
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // تحديد شفرة المصدر للوحدة
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    
    // إنشاء مرجع إلى <stdole>
    VbaReferenceOleTypeLib stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    
    // إنشاء مرجع إلى Office
    VbaReferenceOleTypeLib officeReference = new VbaReferenceOleTypeLib("Office",
            "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    
    // إضافة مراجع إلى مشروع VBA
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
   
    // حفظ العرض التقديمي
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
قد ترغب في الاطلاع على **Aspose** [Macro Remover](https://products.aspose.app/slides/ar/remove-macros)، وهو تطبيق ويب مجاني يُستخدم لإزالة الماكروهات من مستندات PowerPoint وExcel وWord. 
{{% /alert %}} 

## **إزالة ماكرو VBA**

باستخدام الخاصية [VbaProject](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getVbaProject--) ضمن الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation) يمكنك إزالة ماكرو VBA.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation) وتحميل العرض التقديمي الذي يحتوي على الماكرو.
1. الوصول إلى وحدة الماكرو وإزالتها.
1. احفظ العرض التقديمي المعدل.

يعرض هذا الكود جافا كيفية إزالة ماكرو VBA:

```java
import com.aspose.slides.*;

// يقوم بتحميل العرض التقديمي المحتوي على الماكرو
Presentation pres = new Presentation("VBA.pptm");
try {
    // يصل إلى وحدة Vba ويقوم بإزالتها 
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // يحفظ العرض التقديمي
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **استخراج ماكرو VBA**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation) وتحميل العرض التقديمي الذي يحتوي على الماكرو.
2. تحقق مما إذا كان العرض التقديمي يحتوي على مشروع VBA.
3. تكرار جميع الوحدات الموجودة في مشروع VBA لعرض الماكروهات.

يعرض هذا الكود جافا كيفية استخراج ماكرو VBA من عرض تقديمي يحتوي على ماكروهات:

```java
import com.aspose.slides.*;

// يقوم بتحميل العرض التقديمي الذي يحتوي على الماكرو
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

باستخدام الطريقة [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivbaproject/#isPasswordProtected--) يمكنك تحديد ما إذا كانت خصائص المشروع محمية بكلمة مرور.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) وتحميل عرض تقديمي يحتوي على ماكرو.
2. تحقق مما إذا كان العرض التقديمي يحتوي على [VBA project](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/vbaproject/).
3. تحقق مما إذا كان مشروع VBA محميًا بكلمة مرور لعرض خصائصه.

```java
import com.aspose.slides.*;

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

## **الأسئلة المتكررة**

### ماذا يحدث للماكروهات إذا حفظت العرض التقديمي كملف PPTX؟

سيتم إزالة الماكروهات لأن تنسيق PPTX لا يدعم VBA. للاحتفاظ بالماكروهات، اختر PPTM أو PPSM أو POTM.

### هل يمكن لـ Aspose.Slides تشغيل الماكروهات داخل عرض تقديمي لتحديث البيانات، على سبيل المثال؟

لا. المكتبة لا تقوم أبدًا بتنفيذ كود VBA؛ التنفيذ ممكن فقط داخل PowerPoint مع إعدادات الأمان المناسبة.

### هل يُدعم العمل مع عناصر تحكم ActiveX المرتبطة بكود VBA؟

نعم، يمكنك الوصول إلى [ActiveX controls](/slides/ar/androidjava/activex/)، تعديل خصائصها، وإزالتها. هذا مفيد عندما تتفاعل الماكروهات مع ActiveX.