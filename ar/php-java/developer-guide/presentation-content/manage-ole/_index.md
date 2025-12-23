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
- تعديل OLE
- أيقونة OLE
- عنوان OLE
- استخراج OLE
- استخراج كائن
- استخراج ملف
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تحسين إدارة كائنات OLE في ملفات PowerPoint و OpenDocument باستخدام Aspose.Slides لـ PHP عبر Java. تضمين، تحديث، وتصدير محتوى OLE بسلاسة."
---

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) هي تقنية من Microsoft تسمح بنقل البيانات والكائنات التي تم إنشاؤها في تطبيق ما إلى تطبيق آخر عبر الارتباط أو الإدراج. 

{{% /alert %}} 

تخيل وجود مخطط تم إنشاؤه في MS Excel. ثم يتم وضع هذا المخطط داخل شريحة PowerPoint. يُعتبر هذا المخطط في Excel ككائن OLE. 

- قد يظهر كائن OLE كأيقونة. في هذه الحالة، عند النقر المزدوج على الأيقونة، يُفتح المخطط في التطبيق المرتبط (Excel)، أو يُطلب منك اختيار تطبيق لفتح أو تعديل الكائن. 
- قد يعرض كائن OLE محتوياته الفعلية، مثل محتوى المخطط. في هذه الحالة يتم تفعيل المخطط في PowerPoint، تُحمَّل واجهة المخطط، ويمكنك تعديل بيانات المخطط داخل PowerPoint.

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/php-java/) يتيح لك إدراج كائنات OLE في الشرائح كإطارات كائن OLE ([OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)).

## **إضافة إطارات كائن OLE إلى الشرائح**

نفترض أنك قد أنشأت مخططًا في Microsoft Excel وتريد إدراجه في شريحة كإطار كائن OLE باستخدام Aspose.Slides for PHP via Java، يمكنك فعل ذلك بهذه الطريقة:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة عبر فهرستها.
3. قراءة ملف Excel كمصفوفة بايت.
4. إضافة [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) إلى الشريحة مع مصفوفة البايت ومعلومات أخرى عن كائن OLE.
5. كتابة العرض المعدل كملف PPTX.

في المثال أدناه، أضفنا مخططًا من ملف Excel إلى شريحة كإطار كائن OLE باستخدام Aspose.Slides for PHP via Java.
**ملاحظة** أن منشئ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) يأخذ امتداد الكائن القابل للإدراج كمعامل ثانٍ. يتيح هذا الامتداد لـ PowerPoint تفسير نوع الملف بشكل صحيح واختيار التطبيق المناسب لفتح كائن OLE هذا.
```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// إعداد البيانات لكائن OLE.
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// إضافة إطار كائن OLE إلى الشريحة.
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


### **إضافة إطارات كائن OLE مرتبطة**

Aspose.Slides for PHP via Java يتيح لك إضافة [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) بدون إدراج البيانات، بل مع رابط إلى الملف فقط.

يظهر هذا الشيفرة PHP كيفية إضافة [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) مع ملف Excel مرتبط إلى شريحة:
```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// إضافة إطار كائن OLE مع ملف Excel مرتبط.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **الوصول إلى إطارات كائن OLE**

إذا كان كائن OLE مضمّنًا بالفعل في شريحة، يمكنك العثور عليه أو الوصول إليه بهذه الطريقة:

1. تحميل عرض تقديمي يحتوي على كائن OLE المضمن بإنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة باستخدام فهرستها.
3. الوصول إلى شكل [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). في مثالنا، استخدمنا ملف PPTX تم إنشاؤه مسبقًا والذي يحتوي على شكل واحد فقط في الشريحة الأولى.
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك تنفيذ أي عملية عليه.

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن مخطط Excel مضمّن في شريحة) وبيانات ملفه.
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // احصل على بيانات الملف المضمن.
    $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

    // احصل على امتداد الملف المضمن.
    $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

    // ...
}
```


### **الوصول إلى خصائص إطار كائن OLE المرتبط**

Aspose.Slides يتيح لك الوصول إلى خصائص إطار كائن OLE المرتبط.

تظهر هذه الشيفرة PHP كيفية التحقق مما إذا كان كائن OLE مرتبطًا ثم الحصول على مسار الملف المرتبط:
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

{{% alert color="primary" %}} 

في هذا القسم، يستخدم مثال الشيفرة أدناه [Aspose.Cells for PHP via Java](/cells/php-java/).

{{% /alert %}}

إذا كان كائن OLE مضمّنًا بالفعل في شريحة، يمكنك بسهولة الوصول إلى هذا الكائن وتعديل بياناته بهذه الطريقة:

1. تحميل عرض تقديمي يحتوي على كائن OLE المضمن بإنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. الوصول إلى شكل [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) . في مثالنا، استخدمنا ملف PPTX الذي تم إنشاؤه مسبقًا ويحتوي على شكل واحد في الشريحة الأولى.
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك تنفيذ أي عملية عليه.
5. إنشاء كائن `Workbook` والوصول إلى بيانات OLE.
6. الوصول إلى `Worksheet` المطلوبة وتعديل البيانات.
7. حفظ `Workbook` المحدث في تدفق.
8. تغيير بيانات كائن OLE من التدفق.

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن مخطط Excel مضمّن في شريحة) وتعديل بيانات ملفه لتحديث بيانات المخطط.
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new ByteArrayInputStream($oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // قراءة بيانات كائن OLE ككائن Workbook.
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // تعديل بيانات Workbook.
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

إلى جانب مخططات Excel، Aspose.Slides for PHP via Java يتيح لك إدراج أنواع أخرى من الملفات في الشرائح. على سبيل المثال، يمكنك إدراج ملفات HTML وPDF وZIP ككائنات. عندما ينقر المستخدم مزدوجًا على الكائن المدرج، يفتح تلقائيًا في البرنامج المناسب، أو يُطلب من المستخدم اختيار برنامج مناسب لفتحه.

تظهر هذه الشيفرة PHP كيفية إدراج HTML وZIP في شريحة:
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


## **تعيين نوع الملف للكائنات المضمنة**

أثناء العمل على العروض التقديمية، قد تحتاج إلى استبدال كائنات OLE القديمة بأخرى جديدة أو استبدال كائن OLE غير مدعوم بآخر مدعوم. Aspose.Slides for PHP via Java يتيح لك تعيين نوع الملف لكائن مضمّن، مما يتيح لك تحديث بيانات إطار OLE أو امتداده.

تظهر هذه الشيفرة PHP كيفية تعيين نوع الملف لكائن OLE مضمّن إلى `zip`:
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// تغيير نوع الملف إلى ZIP.
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **تعيين صور أيقونات وعناوين للكائنات المضمنة**

بعد إدراج كائن OLE، يتم إضافة معاينة تتألف من صورة أيقونة تلقائيًا. هذه المعاينة هي ما يراه المستخدمون قبل الوصول إلى كائن OLE أو فتحه. إذا رغبت في استخدام صورة ونص محدد كعناصر في المعاينة، يمكنك تعيين صورة الأيقونة والعنوان باستخدام Aspose.Slides for PHP via Java.

تظهر هذه الشيفرة PHP كيفية تعيين صورة الأيقونة والعنوان لكائن مضمّن:
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// إضافة صورة إلى موارد العرض التقديمي.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// تعيين عنوان وصورة لمعاينة OLE.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **منع تغيير حجم وإعادة وضع إطار كائن OLE**

بعد إضافة كائن OLE مرتبط إلى شريحة عرض تقديمي، قد ترى عند فتح العرض في PowerPoint رسالة تطلب تحديث الروابط. قد يؤدي النقر على زر "Update Links" إلى تغيير حجم وموضع إطار كائن OLE لأن PowerPoint يحدث البيانات من كائن OLE المرتبط ويُعيد تحديث معاينة الكائن. لمنع PowerPoint من طلب تحديث بيانات الكائن، عيّن طريقة `setUpdateAutomatic` من فئة [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) إلى `false`:
```php
$oleFrame->setUpdateAutomatic(false);
```


## **استخراج الملفات المضمنة**

Aspose.Slides for PHP via Java يتيح لك استخراج الملفات المضمنة في الشرائح ككائنات OLE بهذه الطريقة:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) يحتوي على كائنات OLE التي تريد استخراجها.
2. التنقل عبر جميع الأشكال في العرض والوصول إلى أشكال [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) .
3. الوصول إلى بيانات الملفات المضمنة من إطارات OLE وكتابتها إلى القرص.

تظهر هذه الشيفرة PHP كيفية استخراج الملفات المضمنة في شريحة ككائنات OLE:
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

ما هو ظاهر في الشريحة هو ما يُعرض—الأيقونة/صورة البديل (المعاينة). لا يتم تنفيذ محتوى OLE "الحي" أثناء العرض. إذا لزم الأمر، عيّن صورة معاينة خاصة لضمان المظهر المتوقع في PDF المُصدّر.

**كيف يمكنني قفل كائن OLE على شريحة بحيث لا يتمكن المستخدمون من تحريكه/تعديله في PowerPoint؟**

قفل الشكل: Aspose.Slides يوفر [قفل على مستوى الشكل](/slides/ar/php-java/applying-protection-to-presentation/). هذا ليس تشفيرًا، لكنه يمنع التعديلات والتحركات العرضية.

**لماذا "يقفز" كائن Excel المرتبط أو يتغير حجمه عند فتح العرض؟**

قد يقوم PowerPoint بتحديث معاينة OLE المرتبط. للحصول على مظهر ثابت، اتبع ممارسات [حل العمل لتغيير حجم الورقة](/slides/ar/php-java/working-solution-for-worksheet-resizing/)—إما ضبط الإطار على النطاق، أو تحجيم النطاق إلى إطار ثابت وتعيين صورة بديلة مناسبة.

**هل سيتم حفظ المسارات النسبية لكائنات OLE المرتبطة في صيغة PPTX؟**

في PPTX، لا تتوفر معلومات "المسار النسبي"—فقط المسار الكامل. تُوجد المسارات النسبية في صيغة PPT القديمة. لضمان قابلية النقل، يُفضَّل استخدام مسارات مطلقة موثوقة/عناوين URI قابلة للوصول أو الإدراج.