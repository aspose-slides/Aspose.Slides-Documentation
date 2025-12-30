---
title: إدارة مشاريع VBA في العروض التقديمية باستخدام PHP
linktitle: العرض التقديمي عبر VBA
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
description: "اكتشف كيفية إنشاء ومعالجة عروض PowerPoint و OpenDocument عبر VBA باستخدام Aspose.Slides للـ PHP عبر Java لتبسيط سير عملك."
---

{{% alert title="Note" color="warning" %}} 

عند تحويل عرض تقديمي يحتوي على وحدات ماكرو إلى تنسيق ملف مختلف (PDF، HTML، إلخ)، تتجاهل Aspose.Slides جميع الوحدات الماكرو (لا يتم نقل الوحدات الماكرو إلى الملف الناتج).

عند إضافة وحدات ماكرو إلى عرض تقديمي أو حفظ عرض تقديمي يحتوي على وحدات ماكرو مرة أخرى، تقوم Aspose.Slides ببساطة بكتابة البايتات الخاصة بالوحدات الماكرو.

Aspose.Slides **لا** تشغل أبداً الوحدات الماكرو في العرض التقديمي.

{{% /alert %}}

## **إضافة وحدات ماكرو VBA**

توفر Aspose.Slides الفئة [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/) للسماح لك بإنشاء مشاريع VBA (ومراجع المشروع) وتعديل الوحدات الموجودة. يمكنك استخدام الواجهة [IVbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/ivbaproject/) لإدارة VBA المضمنة في عرض تقديمي.

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
1. استخدام مُنشئ [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/#VbaProject--) لإضافة مشروع VBA جديد.
1. إضافة وحدة إلى VbaProject.
1. تعيين شفرة المصدر للوحدة.
1. إضافة مراجع إلى <stdole>.
1. إضافة مراجع إلى **Microsoft Office**.
1. ربط المراجع بمشروع VBA.
1. حفظ العرض التقديمي.

هذا الكود PHP يوضح كيفية إضافة وحدة ماكرو VBA من الصفر إلى عرض تقديمي:
```php
  # إنشاء مثيل لفئة العرض التقديمي
  $pres = new Presentation();
  try {
    # إنشاء مشروع VBA جديد
    $pres->setVbaProject(new VbaProject());
    # إضافة وحدة فارغة إلى مشروع VBA
    $module = $pres->getVbaProject()->getModules()->addEmptyModule("Module");
    # تعيين شفرة المصدر للوحدة
    $module->setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    # إنشاء إشارة إلى <stdole>
    $stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    # إنشاء إشارة إلى Office
    $officeReference = new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    # إضافة المراجع إلى مشروع VBA
    $pres->getVbaProject()->getReferences()->add($stdoleReference);
    $pres->getVbaProject()->getReferences()->add($officeReference);
    # حفظ العرض التقديمي
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" %}} 

قد ترغب في تجربة **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros)، وهو تطبيق ويب مجاني يُستخدم لإزالة الوحدات الماكرو من مستندات PowerPoint وExcel وWord. 

{{% /alert %}} 

## **إزالة وحدات ماكرو VBA**

باستخدام الخاصية [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getVbaProject--) ضمن فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)، يمكنك إزالة وحدة ماكرو VBA.

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) وتحميل العرض التقديمي الذي يحتوي على الماكرو.
1. الوصول إلى وحدة الماكرو وإزالتها.
1. حفظ العرض التقديمي المعدل.

هذا الكود PHP يوضح كيفية إزالة وحدة ماكرو VBA:
```php
  # تحميل العرض التقديمي الذي يحتوي على الماكرو
  $pres = new Presentation("VBA.pptm");
  try {
    # الوصول إلى وحدة Vba وإزالتها
    $pres->getVbaProject()->getModules()->remove($pres->getVbaProject()->getModules()->get_Item(0));
    # حفظ العرض التقديمي
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **استخلاص وحدات ماكرو VBA**

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) وتحميل العرض التقديمي الذي يحتوي على الماكرو.
2. التحقق مما إذا كان العرض التقديمي يحتوي على مشروع VBA.
3. استعراض جميع الوحدات الموجودة في مشروع VBA لعرض الوحدات الماكرو.

هذا الكود PHP يوضح كيفية استخراج وحدات ماكرو VBA من عرض تقديمي يحتوي على وحدات ماكرو:
```php
  # تحميل العرض التقديمي الذي يحتوي على الماكرو
  $pres = new Presentation("VBA.pptm");
  try {
    # التحقق مما إذا كان العرض التقديمي يحتوي على مشروع VBA
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

باستخدام الطريقة [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/#isPasswordProtected)، يمكنك تحديد ما إذا كانت خصائص المشروع محمية بكلمة مرور.

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) وتحميل عرض تقديمي يحتوي على ماكرو.
2. التحقق مما إذا كان العرض التقديمي يحتوي على [VBA project](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/).
3. التحقق مما إذا كان مشروع VBA محميًا بكلمة مرور لعرض خصائصه.
```php
$presentation = new Presentation("VBA.pptm");
try {
    if ($presentation->getVbaProject() != null) { // التحقق مما إذا كان العرض التقديمي يحتوي على مشروع VBA.
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

**ماذا يحدث للوحدات الماكرو إذا قمت بحفظ العرض التقديمي بصيغة PPTX؟**

يتم إزالة الوحدات الماكرو لأن صيغة PPTX لا تدعم VBA. للاحتفاظ بالماكرو، اختر PPTM أو PPSM أو POTM.

**هل يمكن لـ Aspose.Slides تشغيل الوحدات الماكرو داخل العرض التقديمي لتحديث البيانات مثلاً؟**

لا. لا تقوم المكتبة بتنفيذ شفرة VBA؛ التنفيذ ممكن فقط داخل PowerPoint مع إعدادات الأمان المناسبة.

**هل يدعم العمل مع عناصر تحكم ActiveX المرتبطة بشفرة VBA؟**

نعم، يمكنك الوصول إلى [عناصر تحكم ActiveX](/slides/ar/php-java/activex/) الحالية، تعديل خصائصها، وإزالتها. هذا مفيد عندما تتفاعل الوحدات الماكرو مع ActiveX.