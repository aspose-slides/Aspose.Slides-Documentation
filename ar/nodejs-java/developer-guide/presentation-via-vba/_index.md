---
title: العرض التقديمي عبر VBA
type: docs
weight: 250
url: /ar/nodejs-java/presentation-via-vba/
keywords: "ماكرو, ماكروهات, VBA, ماكرو VBA, إضافة ماكرو, إزالة ماكرو, إضافة VBA, إزالة VBA, استخراج ماكرو, استخراج VBA, ماكرو PowerPoint, عرض PowerPoint, جافا, Aspose.Slides لـ Node.js عبر Java"
description: "إضافة وإزالة واستخراج ماكرو VBA في عروض PowerPoint التقديمية باستخدام JavaScript"
---

{{% alert title="ملاحظة" color="warning" %}} 

عند تحويل عرض تقديمي يحتوي على ماكرو إلى تنسيق ملف مختلف (PDF، HTML، إلخ)، يتجاهل Aspose.Slides جميع الماكروهات (لا يتم نقل الماكروهات إلى الملف الناتج).

عند إضافة ماكرو إلى عرض تقديمي أو إعادة حفظ عرض تقديمي يحتوي على ماكرو، يقوم Aspose.Slides ببساطة بكتابة البايتات الخاصة بالماكرو.

Aspose.Slides **لا** يشغّل أبداً الماكروهات الموجودة في عرض تقديمي.

{{% /alert %}}

## **إضافة ماكرو VBA**

يوفر Aspose.Slides الفئة [VbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/vbaproject/) للسماح بإنشاء مشاريع VBA (والمراجع الخاصة بالمشروع) وتحرير الوحدات الموجودة. يمكنك استخدام الفئة [VbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/vbaproject/) لإدارة VBA المدمج في عرض تقديمي.

1. أنشئ نسخة من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. استخدم مُنشئ [VbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/vbaproject/#VbaProject--) لإضافة مشروع VBA جديد.
1. أضف وحدة إلى الـ VbaProject.
1. عيّن شفرة المصدر للوحدة.
1. أضف مراجع إلى <stdole>.
1. أضف مراجع إلى **Microsoft Office**.
1. اربط المراجع بمشروع VBA.
1. احفظ العرض التقديمي.

هذا المثال بلغة JavaScript يوضح كيفية إضافة ماكرو VBA من الصفر إلى عرض تقديمي:
```javascript
// ينشئ نسخة من فئة العرض التقديمي
let pres = new aspose.slides.Presentation();
try {
    // ينشئ مشروع VBA جديد
    pres.setVbaProject(new aspose.slides.VbaProject());
    // يضيف وحدة فارغة إلى مشروع VBA
    let module = pres.getVbaProject().getModules().addEmptyModule("Module");
    // يضبط شفرة المصدر للوحدة
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    // ينشئ مرجعًا إلى <stdole>
    let stdoleReference = new aspose.slides.VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    // ينشئ مرجعًا إلى Office
    let officeReference = new aspose.slides.VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    // يضيف مراجع إلى مشروع VBA
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
    // يحفظ العرض التقديمي
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 

قد ترغب في تجربة **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros)، وهو تطبيق ويب مجاني يُستخدم لإزالة الماكروهات من مستندات PowerPoint وExcel وWord. 

{{% /alert %}} 

## **إزالة ماكرو VBA**

باستخدام الخاصية [VbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getVbaProject--) ضمن الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation)، يمكنك إزالة ماكرو VBA.

1. أنشئ نسخة من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) وحمّل العرض التقديمي الذي يحتوي على الماكرو.
1. الوصول إلى وحدة الماكرو وإزالتها.
1. احفظ العرض التقديمي المعدل.

هذا المثال بلغة JavaScript يوضح كيفية إزالة ماكرو VBA:
```javascript
// يحمل العرض التقديمي الذي يحتوي على الماكرو
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // يصل إلى وحدة Vba ويزيلها
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    // يحفظ العرض التقديمي
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **استخراج ماكرو VBA**

1. أنشئ نسخة من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) وحمّل العرض التقديمي الذي يحتوي على الماكرو.
2. تحقق مما إذا كان العرض التقديمي يحتوي على مشروع VBA.
3. تكرار جميع الوحدات الموجودة في مشروع VBA لعرض الماكروهات.

هذا المثال بلغة JavaScript يوضح كيفية استخراج ماكرو VBA من عرض تقديمي يحتوي على ماكروهات:
```javascript
// يحمل العرض التقديمي الذي يحتوي على الماكرو
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // يفحص ما إذا كان العرض التقديمي يحتوي على مشروع VBA
    if (pres.getVbaProject() != null) {
        for (let i = 0; i < pres.getVbaProject().getModules().size(); i++) {
            let module = pres.getVbaProject().getModules().get_Item(i);
            console.log(module.getName());
            console.log(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **التحقق مما إذا كان مشروع VBA محميًا بكلمة مرور**

باستخدام طريقة [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/nodejs-java/aspose.slides/vbaproject/#isPasswordProtected)، يمكنك تحديد ما إذا كانت خصائص المشروع محمية بكلمة مرور.

1. أنشئ نسخة من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) وحمّل عرضًا تقديميًا يحتوي على ماكرو.
2. تحقق مما إذا كان العرض التقديمي يحتوي على [VBA project](https://reference.aspose.com/slides/nodejs-java/aspose.slides/vbaproject/).
3. تحقق مما إذا كان مشروع VBA محميًا بكلمة مرور لعرض خصائصه.
```js
let presentation = new aspose.slides.Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // تحقق مما إذا كان العرض التقديمي يحتوي على مشروع VBA.
        if (presentation.getVbaProject().isPasswordProtected()) {
            console.log("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```


## **التعليمات المتكررة**

**ماذا يحدث للماكروهات إذا حفظت العرض التقديمي كملف PPTX؟**

يتم إزالة الماكروهات لأن صيغة PPTX لا تدعم VBA. للحفاظ على الماكروهات، اختر PPTM أو PPSM أو POTM.

**هل يمكن لـ Aspose.Slides تشغيل الماكروهات داخل عرض تقديمي، مثلاً لتحديث البيانات؟**

لا. لا تقوم المكتبة أبدًا بتنفيذ شفرة VBA؛ التنفيذ ممكن فقط داخل PowerPoint مع إعدادات الأمان المناسبة.

**هل يدعم العمل مع عناصر التحكم ActiveX المرتبطة بشفرة VBA؟**

نعم، يمكنك الوصول إلى عناصر التحكم ActiveX الموجودة، تعديل خصائصها، وإزالتها. هذا مفيد عندما تتفاعل الماكروهات مع عناصر تحكم ActiveX.