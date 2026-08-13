---
title: إدارة مشروعات VBA في العروض التقديمية باستخدام Java
linktitle: العرض التقديمي عبر VBA
type: docs
weight: 250
url: /ar/java/presentation-via-vba/
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
- Java
- Aspose.Slides
description: "اكتشف كيفية إنشاء ومعالجة عروض PowerPoint وOpenDocument عبر VBA باستخدام Aspose.Slides for Java لتبسيط سير العمل الخاص بك."
---
## **المقدمة**

توفر Aspose.Slides فئات وواجهات للعمل مع الماكروات وشفرة VBA.

{{% alert title="Note" color="warning" %}} 

عند تحويل عرض تقديمي يحتوي على ماكروات إلى تنسيق ملف مختلف (PDF، HTML، إلخ)، تتجاهل Aspose.Slides جميع الماكروات (لا يتم نقل الماكروات إلى الملف الناتج).

عند إضافة ماكروات إلى عرض تقديمي أو إعادة حفظ عرض تقديمي يحتوي على ماكروات، تقوم Aspose.Slides ببساطة بكتابة البايتات الخاصة بالماكروات.

Aspose.Slides **أبدًا** لا تقوم بتشغيل الماكروات في عرض تقديمي.

{{% /alert %}}

## **إضافة ماكروات VBA**

توفر Aspose.Slides الفئة [VbaProject](https://reference.aspose.com/slides/ar/java/com.aspose.slides/vbaproject/) للسماح لك بإنشاء مشروعات VBA (ومراجع المشروعات) وتعديل الوحدات الموجودة. يمكنك استخدام الواجهة [IVbaProject](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ivbaproject/) لإدارة VBA المضمّن في عرض تقديمي.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation).
2. استخدام المُنشئ [VbaProject](https://reference.aspose.com/slides/ar/java/com.aspose.slides/vbaproject/#VbaProject--) لإضافة مشروع VBA جديد.
3. إضافة وحدة إلى VbaProject.
4. تعيين شفرة المصدر للوحدة.
5. إضافة مراجع إلى <stdole>.
6. إضافة مراجع إلى **Microsoft Office**.
7. ربط المراجع بمشروع VBA.
8. حفظ العرض التقديمي.

يعرض لك هذا الكود Java كيفية إضافة ماكرو VBA من الصفر إلى عرض تقديمي:

```java
import com.aspose.slides.*;

// إنشاء نسخة من فئة العرض التقديمي
Presentation pres = new Presentation();
try {
    // إنشاء مشروع VBA جديد
    pres.setVbaProject(new VbaProject());
    
    // إضافة وحدة فارغة إلى مشروع VBA
    IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");
    
    // تعيين شفرة المصدر للوحدة
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

قد ترغب في تجربة **Aspose** [Macro Remover](https://products.aspose.app/slides/ar/remove-macros)، وهو تطبيق ويب مجاني يستخدم لإزالة الماكروات من مستندات PowerPoint وExcel وWord. 

{{% /alert %}} 

## **إزالة ماكروات VBA**

باستخدام الخاصية [VbaProject](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getVbaProject--) ضمن الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation)، يمكنك إزالة ماكرو VBA.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation) وتحميل العرض التقديمي الذي يحتوي على الماكرو.
2. الوصول إلى وحدة الماكرو وإزالتها.
3. حفظ العرض التقديمي المعدل.

يعرض لك هذا الكود Java كيفية إزالة ماكرو VBA:

```java
import com.aspose.slides.*;

// يقوم بتحميل العرض التقديمي الذي يحتوي على الماكرو
Presentation pres = new Presentation("VBA.pptm");
try {
    // يقوم بالوصول إلى وحدة Vba وإزالتها
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    
    // يحفظ العرض التقديمي
    pres.save("test.pptm", SaveFormat.Pptm);
} finally {
    if (pres != null) pres.dispose();
}
```

## **استخراج ماكروات VBA**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation) وتحميل العرض التقديمي الذي يحتوي على الماكرو.
2. التحقق مما إذا كان العرض التقديمي يحتوي على مشروع VBA.
3. التكرار عبر جميع الوحدات الموجودة في مشروع VBA لعرض الماكروات.

يعرض لك هذا الكود Java كيفية استخراج ماكروات VBA من عرض تقديمي يحتوي على ماكروات:

```java
import com.aspose.slides.*;

// يحمل العرض التقديمي الذي يحتوي على الماكرو
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

باستخدام الطريقة [IVbaProject.isPasswordProtected](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ivbaproject/#isPasswordProtected--)، يمكنك تحديد ما إذا كانت خصائص المشروع محمية بكلمة مرور.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) وتحميل عرض تقديمي يحتوي على ماكرو.
2. التحقق مما إذا كان العرض التقديمي يحتوي على [مشروع VBA](https://reference.aspose.com/slides/ar/java/com.aspose.slides/vbaproject/).
3. التحقق مما إذا كان مشروع VBA محميًا بكلمة مرور لعرض خصائصه.

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

### ماذا يحدث للماكروات إذا حفظت العرض التقديمي كملف PPTX؟

ستتم إزالة الماكروات لأن صيغة PPTX لا تدعم VBA. للحفاظ على الماكروات، اختر PPTM أو PPSM أو POTM.

### هل يمكن لـ Aspose.Slides تشغيل الماكروات داخل عرض تقديمي، على سبيل المثال لتحديث البيانات؟

لا. المكتبة لا تقوم أبدًا بتنفيذ شفرة VBA؛ التنفيذ ممكن فقط داخل PowerPoint مع إعدادات الأمان المناسبة.

### هل دعم العمل مع عناصر تحكم ActiveX المرتبطة بشفرة VBA؟

نعم، يمكنك الوصول إلى عناصر تحكم ActiveX الموجودة [ActiveX controls](/slides/ar/java/activex/)، تعديل خصائصها، وإزالتها. هذا مفيد عندما تتفاعل الماكروات مع ActiveX.