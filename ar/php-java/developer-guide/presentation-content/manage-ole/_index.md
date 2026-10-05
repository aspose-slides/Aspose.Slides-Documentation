---
title: إدارة OLE في العروض التقديمية باستخدام PHP
linktitle: إدارة OLE
type: docs
weight: 40
url: /ar/php-java/manage-ole/
keywords:
- كائن OLE
- ربط وتضمين الكائنات
- إضافة OLE
- تضمين OLE
- إضافة كائن
- تضمين كائن
- إضافة ملف
- تضمين ملف
- كائن مرتبط
- ملف مرتبط
- تغيير OLE
- أيقونة OLE
- عنوان OLE
- استخراج OLE
- استخراج كائن
- استخراج ملف
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تحسين إدارة كائنات OLE في ملفات PowerPoint وOpenDocument باستخدام Aspose.Slides for PHP عبر Java. قم بتضمين المحتوى، تحديثه، وتصديره بسلاسة."
---
## **مقدمة**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) هي تقنية من مايكروسوفت تسمح بنقل البيانات والكائنات التي تم إنشاؤها في تطبيق إلى تطبيق آخر عبر الربط أو الإدراج. 

{{% /alert %}} 

تخيّل مخططًا تم إنشاؤه في MS Excel. يتم وضع المخطط داخل شريحة PowerPoint. يُعتبر هذا المخطط في Excel كائن OLE. 

- قد يظهر كائن OLE كأيقونة. في هذه الحالة، عندما تنقر مزدوجًا على الأيقونة، يفتح المخطط في التطبيق المرتبط به (Excel)، أو يُطلب منك اختيار تطبيق لفتح أو تعديل الكائن.
- قد يعرض كائن OLE محتواه الفعلي، مثل محتوى المخطط. في هذه الحالة، يتم تنشيط المخطط في PowerPoint، يُحمَّل واجهة المخطط، وتتمكن من تعديل بيانات المخطط داخل PowerPoint.

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/php-java/) يتيح لك إدراج كائنات OLE في الشرائح كإطارات كائن OLE ([OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)).

## **إضافة إطارات كائن OLE إلى الشرائح**

باستخدام مخطط قمت بإنشائه مسبقًا في Microsoft Excel وتريد إدراجه في شريحة كإطار كائن OLE باستخدام Aspose.Slides for PHP via Java، يمكنك القيام بذلك بالطريقة التالية:

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
1. احصل على مرجع الشريحة من خلال فهرسها.
1. اقرأ ملف Excel كمصفوفة بايت.
1. أضف الـ [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) إلى الشريحة مع مصفوفة البايت ومعلومات أخرى حول كائن OLE.
1. احفظ العرض التقديمي المعدل كملف PPTX.

في المثال أدناه، أضفنا مخططًا من ملف Excel إلى شريحة كإطار كائن OLE باستخدام Aspose.Slides for PHP via Java.
**ملاحظة** أن منشئ الـ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) يأخذ امتدادًا لكائن قابل للإدراج كمعامل ثاني. يتيح هذا الامتداد لبرنامج PowerPoint تفسير نوع الملف بشكل صحيح واختيار التطبيق المناسب لفتح كائن OLE هذا.

```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// Prepare data for the OLE object.
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// Add the OLE object frame to the slide.
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

### **إضافة إطارات كائن OLE مرتبطة**

Aspose.Slides for PHP via Java يتيح لك إضافة [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) دون إدراج البيانات وإنما فقط مع رابط إلى الملف.

هذا الكود PHP يوضح كيفية إضافة [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) مع ملف Excel مرتبط إلى شريحة:

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// إضافة إطار كائن OLE مع ملف Excel مرتبط.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **الوصول إلى إطارات كائن OLE**

إذا كان كائن OLE مضمّنًا بالفعل في شريحة، يمكنك بسهولة العثور عليه أو الوصول إليه بهذه الطريقة:

1. حمّل عرضًا تقديميًا يحتوي على كائن OLE المضمّن بإنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. احصل على مرجع الشريحة باستخدام فهرسها.
3. وصول إلى شكل الـ [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). في مثالنا، استخدمنا ملف PPTX الذي تم إنشاؤه مسبقًا ويحتوي على شكل واحد فقط في الشريحة الأولى.
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك إجراء أي عملية عليه.

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن مخطط Excel مضمّن في شريحة) وبيانات ملفه.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // الحصول على بيانات الملف المضمّن.
    $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

    // الحصول على امتداد الملف المضمّن.
    $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

    // ...
}
```

### **الوصول إلى خصائص إطار كائن OLE المرتبط**

Aspose.Slides يتيح لك الوصول إلى خصائص إطار كائن OLE المرتبط.

هذا الكود PHP يوضح كيفية التحقق ما إذا كان كائن OLE مرتبطًا ثم الحصول على مسار الملف المرتبط:

```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // تحقق مما إذا كان كائن OLE مرتبطًا.
    if (java_values($oleFrame->isObjectLink()) != 0) {
        // اطبع المسار الكامل للملف المرتبط.
        echo "OLE object frame is linked to: " . $oleFrame->getLinkPathLong() . PHP_EOL;

        // اطبع المسار النسبي للملف المرتبط إذا كان موجودًا.
        // يمكن فقط لعروض PPT أن تحتوي على المسار النسبي.
        $relativePath = java_values($oleFrame->getLinkPathRelative());
        if (!is_null($relativePath) && $relativePath !== "") {
            echo "OLE object frame relative path: " . $oleFrame->getLinkPathRelative() . PHP_EOL;
        }
    }
}

$presentation->dispose();
```

## **تغيير بيانات كائن OLE**

{{% alert color="info" title="Note" %}}

في هذا القسم، يستخدم المثال البرمجي أدناه [Aspose.Cells for PHP via Java](https://docs.aspose.com/cells/php-java/).

{{% /alert %}}

إذا كان كائن OLE مضمّنًا بالفعل في شريحة، يمكنك بسهولة الوصول إلى ذلك الكائن وتعديل بياناته بهذه الطريقة:

1. حمّل عرضًا تقديميًا يحتوي على كائن OLE المضمّن بإنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. احصل على مرجع الشريحة من خلال فهرسها. 
3. وصول إلى شكل الـ [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). في مثالنا، استخدمنا ملف PPTX الذي تم إنشاؤه مسبقًا ويحتوي على شكل واحد في الشريحة الأولى.
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك إجراء أي عملية عليه.
5. أنشئ كائن `Workbook` وادخل إلى بيانات OLE.
6. ادخل إلى الـ `Worksheet` المطلوب وقم بتعديل البيانات.
7. احفظ الـ `Workbook` المحدث في تدفق.
8. غيّر بيانات كائن OLE من التدفق.

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن مخطط Excel مضمّن في شريحة) وتعديل بيانات ملفه لتحديث بيانات المخطط.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new Java("java.io.ByteArrayInputStream", $oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // قراءة بيانات كائن OLE ككائن Workbook.
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // تعديل بيانات الـ Workbook.
    $workbook->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
    $workbook->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
    $workbook->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
    $workbook->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);

    $fileOptions = new OoxmlSaveOptions(SaveFormat::XLSX);
    $workbook->save($newOleStream, $fileOptions);

    // تغيير بيانات كائن إطار OLE.
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **إدراج أنواع ملفات أخرى في الشرائح**

بعيدًا عن مخططات Excel، Aspose.Slides for PHP via Java يتيح لك إدراج أنواع أخرى من الملفات في الشرائح. على سبيل المثال، يمكنك إدراج ملفات HTML وPDF وZIP ككائنات. عندما ينقر المستخدم مزدوجًا على الكائن المُدرج، يفتح تلقائيًا في البرنامج المناسب، أو يُطلب من المستخدم اختيار برنامج ملائم لفتح الملف.

هذا الكود PHP يوضح كيفية إدراج HTML وZIP في شريحة:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$htmlData = file_get_contents("sample.html");
$htmlDataInfo = new OleEmbeddedDataInfo($htmlData, "html");
$htmlOleFrame = $slide->getShapes()->addOleObjectFrame(150, 120, 50, 50, $htmlDataInfo);
$htmlOleFrame->setObjectIcon(true);

$zipData = file_get_contents("sample.zip");
$zipDataInfo = new OleEmbeddedDataInfo($zipData, "zip");
$zipOleFrame = $slide->getShapes()->addOleObjectFrame(150, 220, 50, 50, $zipDataInfo);
$zipOleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **تحديد أنواع الملفات للكائنات المضمّنة**

عند العمل على عروض تقديمية، قد تحتاج إلى استبدال كائنات OLE القديمة بأخرى جديدة أو استبدال كائن OLE غير مدعوم بآخر مدعوم. Aspose.Slides for PHP via Java يتيح لك تحديد نوع الملف لكائن مضمّن، مما يسمح لك بتحديث بيانات إطار OLE أو امتداده.

هذا الكود PHP يوضح كيفية تحديد نوع الملف لكائن OLE مضمّن إلى `zip`:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// تغيير نوع الملف إلى ZIP.

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **تعيين صور الأيقونة والعناوين للكائنات المضمّنة**

بعد إدراج كائن OLE، يتم إضافة معاينة تتكون من صورة أيقونة تلقائيًا. هذه المعاينة هي ما يراه المستخدمون قبل الوصول إلى كائن OLE أو فتحه. إذا رغبت في استخدام صورة ونص معينين كعناصر في المعاينة، يمكنك تعيين صورة الأيقونة والعنوان باستخدام Aspose.Slides for PHP via Java.

هذا الكود PHP يوضح كيفية تعيين صورة الأيقونة والعنوان لكائن مضمّن:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// أضف صورة إلى موارد العرض التقديمي.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **منع إعادة تحجيم وإعادة وضع إطار كائن OLE**

بعد إضافة كائن OLE مرتبط إلى شريحة عرض تقديمي، قد تظهر لك رسالة عند فتح العرض في PowerPoint تطلب تحديث الروابط. النقر على زر "Update Links" قد يغيّر حجم وموضع إطار كائن OLE لأن PowerPoint يحدث البيانات من كائن OLE المرتبط ويعيد تحديث معاينة الكائن. لمنع PowerPoint من طلب تحديث بيانات الكائن، استدعِ طريقة [setUpdateAutomatic](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) للفئة [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) مع القيمة `false`:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$oleFrame->setUpdateAutomatic(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **استخراج الملفات المضمّنة**

Aspose.Slides for PHP via Java يتيح لك استخراج الملفات المُضمّنة في الشرائح ككائنات OLE بهذه الطريقة:

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) التي تحتوي على كائنات OLE التي ترغب في استخراجها.
2. تَجَوَّل عبر جميع الأشكال في العرض التقديمي وادخل إلى أشكال الـ [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/).
3. ادخل إلى بيانات الملفات المُضمّنة من أطر OLE واكتبها إلى القرص.

هذا الكود PHP يوضح كيفية استخراج ملفات مضمّنة في شريحة ككائنات OLE:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$shapeCount = java_values($slide->getShapes()->size());
for ($index = 0; $index < $shapeCount; $index++) {
    $shape = $slide->getShapes()->get_Item($index);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
        $oleFrame = $shape;

        $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();
        $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

        $filePath = "OLE_object_" . $index . $fileExtension;
        file_put_contents($filePath, $fileData);
    }
}

$presentation->dispose();
```

## **FAQ**

**هل سيتم عرض محتوى OLE عند تصدير الشرائح إلى PDF/صور؟**

ما هو مرئي على الشريحة هو ما يتم تصييره—الأيقونة/الصورة البديلة (المعاينة). لا يتم تنفيذ محتوى OLE "الحي" أثناء التصيير. إذا لزم الأمر، عيّن صورة معاينة خاصة لضمان المظهر المتوقع في PDF المُصدّر.

للحفاظ أيضًا على الملف المضمّن كمرفق PDF، استدعِ [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setIncludeOleData) مع القيمة `true`. هذا الخيار مُعطَّل افتراضيًا. للحصول على مثال وتعليمات للتحقق من المرفق، راجع [Preserve Embedded OLE Files as PDF Attachments](/slides/ar/php-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**كيف يمكنني قفل كائن OLE على شريحة بحيث لا يتمكن المستخدمون من تحريكه/تحريره في PowerPoint؟**

قفل الشكل: Aspose.Slides يوفر أقفالًا على مستوى الشكل. هذا ليس تشفيرًا، لكنه يمنع التعديلات غير المقصودة والحركة.

**هل سيتم حفظ المسارات النسبية لكائنات OLE المرتبطة في تنسيق PPTX؟**

في PPTX، لا تتوفر معلومات "المسار النسبي"—فقط المسار الكامل. تُوجد المسارات النسبية في الصيغة القديمة PPT. لضمان القابلية للنقل، يُفضَّل استخدام مسارات مطلقة موثوقة/عناوين URI قابلة للوصول أو الإدراج.