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
description: "تحسين إدارة كائنات OLE في ملفات PowerPoint وOpenDocument باستخدام Aspose.Slides للـ PHP عبر Java. قم بتضمين وتحديث وتصدير محتوى OLE بسلاسة."
---

{{% alert color="primary" %}} 
OLE (Object Linking & Embedding) هي تقنية من مايكروسوفت تسمح للبيانات والكائنات التي تم إنشاؤها في تطبيق واحد أن تُوضع في تطبيق آخر عبر الربط أو الإدراج. 
{{% /alert %}} 

ضع في الاعتبار مخططًا تم إنشاؤه في MS Excel. ثم يُوضع المخطط داخل شريحة PowerPoint. يُعتبر ذلك المخطط في Excel كائن OLE. 

- قد يظهر كائن OLE كأيقونة. في هذه الحالة، عندما تنقر مزدوجًا على الأيقونة، يتم فتح المخطط في التطبيق المرتبط به (Excel)، أو يُطلب منك اختيار تطبيق لفتح أو تحرير الكائن. 
- قد يعرض كائن OLE محتوياته الفعلية، مثل محتويات مخطط. في هذه الحالة، يتم تنشيط المخطط في PowerPoint، يتم تحميل واجهة المخطط، وتتمكن من تعديل بيانات المخطط داخل PowerPoint. 

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/php-java/) يسمح لك بإدراج OLE Objects في الشرائح كإطارات كائن OLE ([OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)).

## **إضافة إطارات كائن OLE إلى الشرائح**

بافتراض أنك قد أنشأت مخططًا بالفعل في Microsoft Excel وتريد تضمينه في شريحة كإطار كائن OLE باستخدام Aspose.Slides for PHP via Java، يمكنك القيام بذلك بهذه الطريقة:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). 
2. الحصول على مرجع الشريحة عبر فهرسها. 
3. قراءة ملف Excel كمصفوفة بايت. 
4. إضافة [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) إلى الشريحة التي تحتوي على مصفوفة البايت ومعلومات أخرى حول كائن OLE. 
5. كتابة العرض التقديمي المعدل كملف PPTX. 

في المثال أدناه، أضفنا مخططًا من ملف Excel إلى شريحة كإطار كائن OLE باستخدام Aspose.Slides for PHP via Java.  
**ملاحظة** أن منشئ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) يأخذ امتداد كائن قابل للتضمين كمعامل ثانٍ. هذا الامتداد يسمح لـ PowerPoint بتفسير نوع الملف بشكل صحيح واختيار التطبيق المناسب لفتح هذا الكائن OLE.  
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


### **إضافة إطارات OLE المرتبطة**

Aspose.Slides for PHP via Java يسمح لك بإضافة [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) دون تضمين البيانات ولكن فقط مع ارتباط إلى الملف.  

هذا الكود PHP يوضح لك كيفية إضافة [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) بملف Excel مرتبط إلى شريحة:  
```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// Add an OLE object frame with a linked Excel file.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **الوصول إلى إطارات OLE**

إذا كان كائن OLE مضمّنًا بالفعل في شريحة، يمكنك العثور عليه أو الوصول إليه بسهولة بهذه الطريقة:

1. تحميل عرض تقديمي يحتوي على كائن OLE مضمّن بإنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). 
2. الحصول على مرجع الشريحة باستخدام فهرسها. 
3. الوصول إلى شكل [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). في مثالنا، استخدمنا ملف PPTX الذي تم إنشاؤه مسبقًا والذي يحتوي على شكل واحد فقط في الشريحة الأولى. 
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك تنفيذ أي عملية عليه.  

في المثال أدناه، تم الوصول إلى إطار كائن OLE (كائن مخطط Excel مضمّن في شريحة) وبيانات ملفه.  
```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // احصل على بيانات الملف المضمّن.
    $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

    // احصل على امتداد الملف المضمّن.
    $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

    // ...
}
```


### **الوصول إلى خصائص إطار OLE المرتبط**

Aspose.Slides يتيح لك الوصول إلى خصائص إطار OLE المرتبط.  

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

في هذا القسم، يستخدم المثال البرمجي أدناه [Aspose.Cells for PHP via Java](/cells/php-java/). 

{{% /alert %}} 

إذا كان كائن OLE مضمّنًا بالفعل في شريحة، يمكنك بسهولة الوصول إلى ذلك الكائن وتعديل بياناته بهذه الطريقة:

1. تحميل عرض تقديمي يحتوي على كائن OLE مضمّن بإنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). 
2. الحصول على مرجع الشريحة عبر فهرسها. 
3. الوصول إلى شكل [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). في مثالنا، استخدمنا ملف PPTX الذي تم إنشاؤه مسبقًا والذي يحتوي على شكل واحد في الشريحة الأولى. 
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك تنفيذ أي عملية عليه. 
5. إنشاء كائن `Workbook` والوصول إلى بيانات OLE. 
6. الوصول إلى الـ `Worksheet` المطلوب وتعديل البيانات. 
7. حفظ الـ `Workbook` المحدث في تدفق. 
8. تغيير بيانات كائن OLE من التدفق. 

في المثال أدناه، تم الوصول إلى إطار كائن OLE (كائن مخطط Excel مضمّن في شريحة) وتعديل بيانات ملفه لتحديث بيانات المخطط.  
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


## **تضمين أنواع ملفات أخرى في الشرائح**

إلى جانب مخططات Excel، Aspose.Slides for PHP via Java يتيح لك تضمين أنواع أخرى من الملفات في الشرائح. على سبيل المثال، يمكنك إدراج ملفات HTML وPDF وZIP ككائنات. عندما ينقر المستخدم مزدوجًا على الكائن المُدرج، يفتح تلقائيًا في البرنامج المناسب، أو يُطلب من المستخدم اختيار برنامج مناسب لفتح الملف.  

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


## **تعيين أنواع الملفات للكائنات المضمّنة**

عند العمل على عروض تقديمية، قد تحتاج إلى استبدال كائنات OLE القديمة بأخرى جديدة أو استبدال كائن OLE غير مدعوم بآخر مدعوم. Aspose.Slides for PHP via Java يتيح لك تعيين نوع الملف لكائن مضمّن، مما يمكنك من تحديث بيانات إطار OLE أو امتداده.  

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// Change the file type to ZIP.
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **تعيين صور الأيقونة والعناوين للكائنات المضمّنة**

بعد تضمين كائن OLE، يتم إضافة معاينة تتكون من صورة أيقونة تلقائيًا. هذه المعاينة هي ما يراه المستخدمون قبل الوصول إلى الكائن أو فتحه. إذا رغبت في استخدام صورة ونص محددين كعناصر في المعاينة، يمكنك تعيين صورة الأيقونة والعنوان باستخدام Aspose.Slides for PHP via Java.  

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// إضافة صورة إلى موارد العرض التقديمي.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// تعيين عنوان والصورة لمعاينة OLE.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


## **منع تغيير حجم إطار كائن OLE وموقعه**

بعد إضافة كائن OLE مرتبط إلى شريحة عرض تقديمي، عند فتح العرض في PowerPoint قد تظهر لك رسالة تطلب تحديث الروابط. قد يؤدي النقر على زر "Update Links" إلى تغيير حجم وموقع إطار كائن OLE لأن PowerPoint يحدث البيانات من الكائن المرتبط ويعيد رسم المعاينة. لمنع PowerPoint من طلب تحديث بيانات الكائن، اضبط طريقة `setUpdateAutomatic` في فئة [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) على `false`:  
```php
$oleFrame->setUpdateAutomatic(false);
```


## **استخراج الملفات المضمّنة**

Aspose.Slides for PHP via Java يسمح لك باستخراج الملفات المضمّنة في الشرائح ككائنات OLE بهذه الطريقة:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) التي تحتوي على كائنات OLE التي تنوي استخراجها. 
2. المرور على جميع الأشكال في العرض والوصول إلى أشكال [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). 
3. الوصول إلى بيانات الملفات المضمّنة من إطارات كائن OLE وكتابتها إلى القرص.  

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


## **الأسئلة المتكررة**

**هل سيتم عرض محتوى OLE عند تصدير الشرائح إلى PDF/صور؟**

ما يظهر على الشريحة هو ما يُعرض — أي الأيقونة/الصورة البديلة (المعاينة). محتوى OLE "الحي" لا يُنفذ أثناء عملية العرض. إذا لزم الأمر، قم بتعيين صورة معاينة خاصة لضمان المظهر المتوقع في الـ PDF المُصدّر.  

**كيف يمكنني قفل كائن OLE على شريحة بحيث لا يتمكن المستخدمون من تحريكه/تحريره في PowerPoint؟**

قفل الشكل: Aspose.Slides يوفر أقفالًا على مستوى الشكل. هذا ليس تشفيرًا، لكنه يمنع الفوضى غير المقصودة والتحريك.  

**هل ستُحافظ صيغة PPTX على المسارات النسبية لكائنات OLE المرتبطة؟**

في PPTX لا تتوافر معلومات "المسار النسبي" — فقط المسار الكامل. المسارات النسبية موجودة في صيغة PPT القديمة. لتحقيق قابلية النقل، يُفضَّل الاعتماد على مسارات مطلقة موثوقة أو عناوين URI قابلة للوصول أو تضمين الملفات.