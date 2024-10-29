---
title: حفظ العرض التقديمي
type: docs
weight: 80
url: /ar/php-java/save-presentation/
---

## **نظرة عامة**
{{% alert color="primary" %}} 

[فتح العرض التقديمي](/slides/ar/php-java/open-presentation/) وصف كيفية استخدام فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) لفتح عرض تقديمي. تشرح هذه المقالة كيفية إنشاء وحفظ العروض التقديمية.

{{% /alert %}} 

تحتوي فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) على محتوى العرض التقديمي. سواء كنت تنشئ عرضًا تقديميًا من الصفر أو تعدل عرضًا موجودًا، عندما تنتهي، ستحتاج إلى حفظ العرض التقديمي. مع Aspose.Slides لـ PHP عبر Java، يمكن حفظه كـ **ملف** أو **تدفق**. تشرح هذه المقالة كيفية حفظ عرض تقديمي بطرق مختلفة:

## **حفظ العرض التقديمي في ملف**
احفظ العرض التقديمي في ملف عن طريق استدعاء طريقة [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) للفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation). ببساطة، قم بتمرير اسم الملف و [**SaveFormat**](https://reference.aspose.com/slides/php-java/aspose.slides/SaveFormat) إلى طريقة [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) .

تظهر الأمثلة التالية كيفية حفظ عرض تقديمي باستخدام Aspose.Slides لـ PHP عبر Java.

```php
  # قم بإنشاء كائن Presentation يمثل ملف PPT
  $pres = new Presentation();
  try {
    # ...قم ببعض الأعمال هنا...
    # احفظ العرض التقديمي الخاص بك في ملف
    $pres->save("demoPass.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **حفظ العرض التقديمي في تدفق**
من الممكن حفظ العرض التقديمي في تدفق عن طريق تمرير تدفق إخراج إلى طريقة [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.io.OutputStream-int-) للفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation). هناك العديد من أنواع التدفقات التي يمكن حفظ العرض التقديمي فيها. في المثال أدناه، قمنا بإنشاء ملف عرض تقديمي جديد، وإضافة نص في شكل، وحفظ العرض التقديمي في التدفق.

```php
  # قم بإنشاء كائن Presentation يمثل ملف PPT
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 200, 200);
    # أضف نصًا إلى الشكل
    $shape->getTextFrame()->setText("هذا العرض التوضيحي يوضح كيفية إنشاء ملف PowerPoint وحفظه في تدفق.");
    $os = new Java("java.io.FileOutputStream", "Save_As_Stream_out.pptx");
    $pres->save($os, SaveFormat::Pptx);
    $os->close();
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **حفظ العرض التقديمي مع نوع العرض المحدد مسبقًا**
توفر Aspose.Slides لـ PHP عبر Java تسهيلة لتحديد نوع العرض للعرض التقديمي الذي سيتم إنشاؤه عند فتحه في PowerPoint من خلال فئة [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties). تُستخدم خاصية [**setLastView**](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties#setLastView-int-) لتعيين نوع العرض باستخدام تعداد [**ViewType**](https://reference.aspose.com/slides/php-java/aspose.slides/ViewType).

```php
  # فتح ملف العرض التقديمي
  $pres = new Presentation();
  try {
    # تعيين نوع العرض
    $pres->getViewProperties()->setLastView(ViewType::SlideMasterView);
    # حفظ العرض التقديمي
    $pres->save("newDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **حفظ العروض التقديمية بتنسيق Office Open XML الصارم**
يسمح لك Aspose.Slides بحفظ العرض التقديمي بتنسيق Office Open XML الصارم. لهذا الغرض، يوفر فئة [**PptxOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions) حيث يمكنك تعيين خاصية التوافق أثناء حفظ ملف العرض التقديمي. إذا قمت بتعيين قيمتها إلى [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/php-java/aspose.slides/Conformance#Iso29500_2008_Strict)، فسيتم حفظ ملف العرض التقديمي الناتج بتنسيق Open XML الصارم.

الكود المثال التالي ينشئ عرضًا تقديميًا ويحفظه بتنسيق Office Open XML الصارم. عند استدعاء طريقة [**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) للعرض التقديمي، يتم تمرير كائن [**PptxOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions) إليه مع تعيين خاصية التوافق كـ [**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/php-java/aspose.slides/Conformance#Iso29500_2008_Strict).

```php
  # قم بإنشاء كائن Presentation يمثل ملف PPT
  $pres = new Presentation();
  try {
    # الحصول على الشريحة الأولى
    $slide = $pres->getSlides()->get_Item(0);
    # إضافة شكل تلقائي من النوع خط
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # تعيين خيارات حفظ تنسيق Office Open XML الصارم
    $options = new PptxOptions();
    $options->setConformance(Conformance->Iso29500_2008_Strict);
    # احفظ العرض التقديمي الخاص بك في ملف
    $pres->save("demoPass.pptx", SaveFormat::Pptx, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **حفظ العروض التقديمية بتنسيق Office Open XML في وضع Zip64**
ملف Office Open XML هو أرشيف ZIP له حد 4 جيجابايت (2^32 بايت) على الحجم غير المضغوط لملف، حجم الملف المضغوط، والحجم الكلي للأرشيف، بالإضافة إلى حد 65,535 (2^16-1) ملف في الأرشيف. تزيد ملحقات تنسيق ZIP64 الحدود إلى 2^64.

تسمح خاصية [**IPptxOptions.Zip64Mode**](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/) لك باختيار متى تستخدم ملحقات تنسيق ZIP64 للملف Office Open XML المحفوظ.

توفر هذه الخاصية الأوضاع التالية:

- [Zip64Mode.IfNecessary](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#IfNecessary) تعني أنه سيتم استخدام ملحقات تنسيق ZIP64 فقط إذا كان العرض التقديمي يقع خارج القيود المذكورة أعلاه. هذه هي الوضع الافتراضي.
- [Zip64Mode.Never](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#Never) تعني أنه لن يتم استخدام ملحقات تنسيق ZIP64. 
- [Zip64Mode.Always](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#Always) تعني أنه سيتم دائمًا استخدام ملحقات تنسيق ZIP64.

الشفرة التالية توضح كيفية حفظ العرض التقديمي بتنسيق PPTX مع ملحقات تنسيق ZIP64:

```php
  $pres = new Presentation("Sample.pptx");
  try {
    $pptxOptions = new PptxOptions();
    $pptxOptions->setZip64Mode(Zip64Mode::Always);
    
    $pres->save("Sample-zip64.pptx", SaveFormat::Pptx, $pptxOptions);
  } finally {
    $pres->dispose();
  }
```

{{% alert title="ملاحظة" color="warning" %}}

يمكن أن يؤدي الحفظ في وضع Zip64Mode.Never إلى إثارة [PptxException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxexception/) إذا لم يكن العرض التقديمي يمكن حفظه بتنسيق ZIP32.

{{% /alert %}}

## **تحديثات تقدم الحفظ بالنسبة المئوية**
تمت إضافة واجهة [**IProgressCallback**](https://reference.aspose.com/slides/php-java/aspose.slides/IProgressCallback) إلى واجهة [**ISaveOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/ISaveOptions) و الفئة المجردة [**SaveOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/SaveOptions). تمثل واجهة [**IProgressCallback**](https://reference.aspose.com/slides/php-java/aspose.slides/IProgressCallback) كائن رد نداء لتحديثات تقدم الحفظ بالنسبة المئوية.  

تظهر مقتطفات الشيفرة التالية كيفية استخدام واجهة [IProgressCallback](https://reference.aspose.com/slides/php-java/aspose.slides/IProgressCallback):

```php
  class ExportProgressHandler {
    function reporting($progressValue) {
      # استخدم قيمة التقدم المئوية هنا
      $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
      echo($progress . "% تم تحويل الملف");
    }
  }

  # فتح ملف العرض التقديمي
  $pres = new Presentation("ConvertToPDF.pptx");
  try {
    $saveOptions = new PdfOptions();
    $progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));
    $saveOptions->setProgressCallback($progressHandler);
    $pres->save("ConvertToPDF.pdf", SaveFormat::Pdf, $saveOptions);
  } finally {
    $pres->dispose();
  }
```

{{% alert title="معلومات" color="info" %}}

باستخدام واجهته البرمجية الخاصة، طورت Aspose تطبيق [مقسم PowerPoint مجاني](https://products.aspose.app/slides/splitter) الذي يسمح للمستخدمين بتقسيم عروضهم التقديمية إلى ملفات متعددة. في الأساس، يقوم التطبيق بحفظ الشرائح المختارة من عرض تقديمي معين كملفات PowerPoint جديدة (PPTX أو PPT).

{{% /alert %}}