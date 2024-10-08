---
title: العرض عبر VBA
type: docs
weight: 250
url: /ar/php-java/presentation-via-vba/
keywords: "ماكرو، ماكروز، VBA، ماكرو VBA، إضافة ماكرو، إزالة ماكرو، إضافة VBA، إزالة VBA، استخراج ماكرو، استخراج VBA، ماكرو باوربوينت، عرض باوربوينت، جافا، Aspose.Slides لـ PHP عبر جافا"
description: "إضافة وإزالة واستخراج ماكروز VBA في عروض باوربوينت"
---

{{% alert title="ملاحظة" color="warning" %}} 

عند تحويل عرض يتضمن ماكروز إلى تنسيق ملف مختلف (PDF، HTML، إلخ)، تتجاهل Aspose.Slides جميع الماكروز (الماكروز لا تُحمل إلى الملف الناتج).

عند إضافة ماكروز إلى عرض أو إعادة حفظ عرض يحتوي على ماكروز، تكتب Aspose.Slides ببساطة بايتات الماكروز.

Aspose.Slides **لا** تقوم أبداً بتشغيل الماكروز في العرض.

{{% /alert %}}

## **إضافة ماكروز VBA**

تقدم Aspose.Slides الفئة [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/) التي تتيح لك إنشاء مشاريع VBA (ومراجع المشاريع) وتحرير الوحدات الموجودة. يمكنك استخدام الواجهة [IVbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/ivbaproject/) لإدارة VBA المضمن في العرض.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) .
1. استخدم مُنشئ [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/vbaproject/#VbaProject--) لإضافة مشروع VBA جديد.
1. أضف وحدة إلى VbaProject.
1. قم بتعيين شفرة مصدر الوحدة.
1. أضف مراجع إلى <stdole>.
1. أضف مراجع إلى **Microsoft Office**.
1. اربط المراجع بمشروع VBA.
1. احفظ العرض.

يوضح لك هذا الكود PHP كيفية إضافة ماكرو VBA من الصفر إلى عرض:

```php
  # ينشئ مثيلاً من الفئة presentation
  $pres = new Presentation();
  try {
    # ينشئ مشروع VBA جديد
    $pres->setVbaProject(new VbaProject());
    # يضيف وحدة فارغة إلى مشروع VBA
    $module = $pres->getVbaProject()->getModules()->addEmptyModule("Module");
    # يعين شفرة مصدر الوحدة
    $module->setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    # ينشئ مرجعاً إلى <stdole>
    $stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    # ينشئ مرجعاً إلى Office
    $officeReference = new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    # يضيف مراجع إلى مشروع VBA
    $pres->getVbaProject()->getReferences()->add($stdoleReference);
    $pres->getVbaProject()->getReferences()->add($officeReference);
    # يحفظ العرض
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

قد ترغب في الاطلاع على **Aspose** [إزالة الماكروز](https://products.aspose.app/slides/remove-macros)، وهو تطبيق ويب مجاني يستخدم لإزالة الماكروز من عروض باوربوينت، ومستندات إكسل، ووورد. 

{{% /alert %}} 

## **إزالة ماكروز VBA**

باستخدام خاصية [VbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getVbaProject--) تحت الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)، يمكنك إزالة ماكرو VBA.

1. قم بإنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) وفتح العرض الذي يحتوي على الماكرو.
1. الوصول إلى وحدة الماكرو وإزالتها.
1. احفظ العرض المعدل.

يوضح لك هذا الكود PHP كيفية إزالة ماكرو VBA:

```php
  # يحمل العرض الذي يحتوي على الماكرو
  $pres = new Presentation("VBA.pptm");
  try {
    # يصل إلى وحدة Vba ويزيلها
    $pres->getVbaProject()->getModules()->remove($pres->getVbaProject()->getModules()->get_Item(0));
    # يحفظ العرض
    $pres->save("test.pptm", SaveFormat::Pptm);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **استخراج ماكروز VBA**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) وتحميل العرض الذي يحتوي على الماكرو.
2. تحقق مما إذا كان العرض يحتوي على مشروع VBA.
3. قم بالتكرار عبر جميع الوحدات الموجودة في مشروع VBA لعرض الماكروز.

يوضح لك هذا الكود PHP كيفية استخراج ماكروز VBA من عرض يحتوي على ماكروز:

```php
  # يحمل العرض الذي يحتوي على الماكرو
  $pres = new Presentation("VBA.pptm");
  try {
    # يتحقق مما إذا كان العرض يحتوي على مشروع VBA
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