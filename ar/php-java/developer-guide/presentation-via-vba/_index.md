---
title: "إدارة مشاريع VBA في العروض التقديمية باستخدام PHP"
linktitle: "العرض التقديمي عبر VBA"
type: docs
weight: 250
url: /ar/php-java/presentation-via-vba/
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
- PHP
- Aspose.Slides
description: "اكتشف كيفية إنشاء ومعالجة عروض PowerPoint وOpenDocument عبر VBA باستخدام Aspose.Slides للـ PHP عبر Java لتبسيط سير عملك."
---

{{% alert title="ملاحظة" color="warning" %}} 

عند تحويل عرض تقديمي يحتوي على ماكرو إلى تنسيق ملف مختلف (PDF، HTML، إلخ)، يتجاهل Aspose.Slides جميع الماكروهات (لا يتم نقل الماكروهات إلى الملف الناتج).

عند إضافة ماكرو إلى عرض تقديمي أو إعادة حفظ عرض يحتوي على ماكرو، يقوم Aspose.Slides ببساطة بكتابة البايتات الخاصة بالماكرو.

Aspose.Slides **لا** يقوم أبداً بتشغيل الماكروهات الموجودة في العرض التقديمي.

{{% /alert %}}

## **إضافة ماكرو VBA**

يوفر Aspose.Slides الفئة [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/) للسماح لك بإنشاء مشاريع VBA (ومراجع المشروع) وتعديل الوحدات الموجودة. يمكنك استخدام فئة `VbaProject` لإدارة VBA المدمج في عرض تقديمي.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. استخدم مُنشئ [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/#VbaProject) لإضافة مشروع VBA جديد.
1. أضف وحدة إلى الـ VbaProject.
1. عيّن شفرة المصدر للوحدة.
1. أضف مراجع إلى <stdole>.
1. أضف مراجع إلى **Microsoft Office**.
1. اربط المراجع بمشروع VBA.
1. احفظ العرض التقديمي.

هذا الكود PHP يوضح لك كيفية إضافة ماكرو VBA من الصفر إلى عرض تقديمي:
```php
  # ينشئ كائنًا من فئة العرض التقديمي
  $pres = new Presentation();
  try {
    # ينشئ مشروع VBA جديد
    $pres->setVbaProject(new VbaProject());
    # يضيف وحدة فارغة إلى مشروع VBA
    $module = $pres->getVbaProject()->getModules()->addEmptyModule("Module");
    # يضبط شفرة المصدر للوحدة
    $module->setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    # ينشئ إشارة إلى <stdole>
    $stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    # ينشئ إشارة إلى Office
    $officeReference = new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    # يضيف مراجع إلى مشروع VBA
    $pres->getVbaProject()->getReferences()->add($stdoleReference);
    $pres->getVbaProject()->getReferences()->add($officeReference);
    # يحفظ العرض التقديمي
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" %}} 

قد ترغب في تجربة **Aspose** [مزيل الماكرو](https://products.aspose.app/slides/remove-macros)، وهو تطبيق ويب مجاني يُستخدم لإزالة الماكروهات من مستندات PowerPoint وExcel وWord.

{{% /alert %}} 

## **إزالة ماكرو VBA**

باستخدام خاصية [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getVbaProject) ضمن الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)، يمكنك إزالة ماكرو VBA.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) وتحميل العرض الذي يحتوي على الماكرو.
1. الوصول إلى وحدة الماكرو وإزالتها.
1. حفظ العرض المعدل.

هذا الكود PHP يوضح لك طريقة إزالة ماكرو VBA:
```php
  # يقوم بتحميل العرض التقديمي الذي يحتوي على الماكرو
  $pres = new Presentation("VBA.pptm");
  try {
    # يصل إلى وحدة Vba ويحذفها
    $pres->getVbaProject()->getModules()->remove($pres->getVbaProject()->getModules()->get_Item(0));
    # يحفظ العرض التقديمي
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **استخراج ماكرو VBA**

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) وتحميل العرض الذي يحتوي على الماكرو.
2. التحقق مما إذا كان العرض يحتوي على مشروع VBA.
3. التجول عبر جميع الوحدات الموجودة في مشروع VBA لعرض الماكروهات.

هذا الكود PHP يوضح لك كيفية استخراج ماكرو VBA من عرض تقديمي يحتوي على ماكروهات:
```php
  # يقوم بتحميل العرض التقديمي الذي يحتوي على الماكرو
  $pres = new Presentation("VBA.pptm");
  try {
    # يتحقق مما إذا كان العرض التقديمي يحتوي على مشروع VBA
    if (!java_is_null($pres->getVbaProject())) {
      foreach($pres->getVbaProject()->getModules() as $module) {
        echo($module->getName());
        echo($module->getSourceCode());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **التحقق مما إذا كان مشروع VBA محميًا بكلمة مرور**

باستخدام الطريقة [VbaProject::isPasswordProtected](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/#isPasswordProtected)، يمكنك معرفة ما إذا كانت خصائص المشروع محمية بكلمة مرور.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) وتحميل عرض يحتوي على ماكرو.
2. التحقق مما إذا كان العرض يحتوي على [مشروع VBA](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/).
3. التحقق مما إذا كان مشروع VBA محميًا بكلمة مرور لعرض خصائصه.
```php
$presentation = new Presentation("VBA.pptm");
try {
    if ($presentation->getVbaProject() != null) { // تحقق مما إذا كان العرض التقديمي يحتوي على مشروع VBA.
        if ($presentation->getVbaProject()->isPasswordProtected()) {
            printf("The VBA Project '%s' is protected by password to view project properties.", 
                    $presentation->getVbaProject()->getName());
        }
    }
} finally {
    $presentation->dispose();
}
```


## **الأسئلة المتكررة**

**ماذا يحدث للماكروهات إذا حفظت العرض التقديمي كملف PPTX؟**

سيتم إزالة الماكروهات لأن تنسيق PPTX لا يدعم VBA. للحفاظ على الماكروهات، اختر PPTM أو PPSM أو POTM.

**هل يمكن لـ Aspose.Slides تشغيل الماكروهات داخل العرض التقديمي، على سبيل المثال لتحديث البيانات؟**

لا. المكتبة لا تقوم أبداً بتنفيذ كود VBA؛ التنفيذ ممكن فقط داخل PowerPoint مع إعدادات الأمان المناسبة.

**هل يدعم العمل مع عناصر تحكم ActiveX المرتبطة بكود VBA؟**

نعم، يمكنك الوصول إلى [عناصر تحكم ActiveX](/slides/ar/php-java/activex/) الموجودة، تعديل خصائصها، وإزالتها. هذا مفيد عندما تتفاعل الماكروهات مع ActiveX.