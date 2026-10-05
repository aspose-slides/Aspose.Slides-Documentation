---
title: إدارة OLE في العروض التقديمية باستخدام JavaScript
linktitle: إدارة OLE
type: docs
weight: 40
url: /ar/nodejs-java/manage-ole/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "تحسين إدارة كائنات OLE في ملفات PowerPoint وOpenDocument باستخدام Aspose.Slides لـ Node.js عبر Java. قم بتضمين محتوى OLE وتحديثه وتصديره بسلاسة."
---
## **المقدمة**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) هي تقنية مايكروسوفت تسمح بنقل البيانات والكائنات التي تم إنشاؤها في تطبيق إلى تطبيق آخر عبر الارتباط أو الإدراج. 

{{% /alert %}} 

اعتبر مخططًا تم إنشاؤه في MS Excel. ثم يتم وضع المخطط داخل شريحة PowerPoint. يُعتبر هذا المخطط في Excel ككائن OLE. 

- قد يظهر كائن OLE كأيقونة. في هذه الحالة، عندما تنقر مزدوجًا على الأيقونة، يفتح المخطط في التطبيق المرتبط به (Excel)، أو يُطلب منك اختيار تطبيق لفتح أو تعديل الكائن.
- قد يعرض كائن OLE محتوياته الفعلية، مثل محتوى مخطط. في هذه الحالة، يُفعَّل المخطط في PowerPoint، يتم تحميل واجهة المخطط، ويمكنك تعديل بيانات المخطط داخل PowerPoint.

يتيح لك [Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/nodejs-java/) إدراج كائنات OLE في الشرائح كأطر كائن OLE ([OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)).

## **إضافة أطر كائن OLE إلى الشرائح**

بافتراض أنك قد أنشأت مخططًا في Microsoft Excel وتريد إدراجه في شريحة كإطار كائن OLE باستخدام Aspose.Slides for Node.js via Java، يمكنك القيام بذلك بهذه الطريقة:

1. إنشاء كائن من صف [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
1. الحصول على مرجع الشريحة عبر فهرستها.
1. قراءة ملف Excel كمصفوفة بايت.
1. إضافة الـ[OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) إلى الشريحة مع مصفوفة البايت ومعلومات أخرى حول كائن OLE.
1. كتابة العرض التقديمي المعدل كملف PPTX.

في المثال أدناه، أضفنا مخططًا من ملف Excel إلى شريحة كإطار كائن OLE باستخدام Aspose.Slides for Node.js via Java.  
**ملاحظة** أن المُنشئ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleEmbeddedDataInfo) يأخذ امتداد الكائن القابل للإدراج كمعامل ثانٍ. يسمح هذا الامتداد لـ PowerPoint بتفسير نوع الملف بشكل صحيح واختيار التطبيق المناسب لفتح كائن OLE هذا.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

### **إضافة أطر OLE المرتبطة**

يتيح لك Aspose.Slides for Node.js via Java إضافة [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) دون دمج البيانات ولكن فقط عبر ارتباط إلى الملف.

يظهر هذا الكود JavaScript كيفية إضافة [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) بملف Excel مرتبط إلى شريحة:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// إضافة إطار كائن OLE بملف Excel مرتبط.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **الوصول إلى أطر OLE**

إذا كان كائن OLE مدمجًا بالفعل في شريحة، يمكنك بسهولة العثور عليه أو الوصول إليه بهذه الطريقة:

1. تحميل عرض تقديمي يحتوي على كائن OLE المدمج بإنشاء كائن من صف [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
2. الحصول على مرجع الشريحة باستخدام فهرستها.
3. الوصول إلى شكل [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame). في مثالنا، استخدمنا ملف PPTX الذي تم إنشاؤه مسبقًا ويحتوي على شكل واحد فقط في الشريحة الأولى.
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك إجراء أي عملية عليه.

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن مخطط Excel مدمج في شريحة) وبيانات ملفه.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // الحصول على بيانات الملف المضمّن.
    var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // الحصول على امتداد الملف المضمّن.
    var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **الوصول إلى خصائص إطار OLE المرتبط**

يتيح لك Aspose.Slides الوصول إلى خصائص إطار OLE المرتبط.

يعرض هذا الكود JavaScript كيفية التحقق مما إذا كان كائن OLE مرتبطًا ثم الحصول على مسار الملف المرتبط:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // تحقق مما إذا كان كائن OLE مرتبطًا.
    if (oleFrame.isObjectLink()) {
        // طباعة المسار الكامل للملف المرتبط.
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // طباعة المسار النسبي للملف المرتبط إذا كان موجودًا.
        // يمكن فقط لعروض PPT أن تحتوي على المسار النسبي.
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **تغيير بيانات كائن OLE**

{{% alert color="info" title="Note" %}}

في هذا القسم، يستخدم المثال البرمجي أدناه [Aspose.Cells for Java](https://docs.aspose.com/cells/java/).

{{% /alert %}}

إذا كان كائن OLE مدمجًا بالفعل في شريحة، يمكنك بسهولة الوصول إلى ذلك الكائن وتعديل بياناته بهذه الطريقة:

1. تحميل عرض تقديمي يحتوي على كائن OLE المدمج بإنشاء كائن من صف [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
2. الحصول على مرجع الشريحة عبر فهرستها.
3. الوصول إلى شكل إطار كائن OLE. في مثالنا، استخدمنا ملف PPTX الذي تم إنشاؤه مسبقًا ويحتوي على شكل واحد في الشريحة الأولى.
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك إجراء أي عملية عليه.
5. إنشاء كائن `Workbook` والوصول إلى بيانات OLE.
6. الوصول إلى ورقة `Worksheet` المطلوبة وتعديل البيانات.
7. حفظ الـ `Workbook` المحدث في تدفق.
8. تغيير بيانات كائن OLE من التدفق.

في المثال أدناه، تم الوصول إلى إطار كائن OLE (كائن مخطط Excel مدمج في شريحة) وتم تعديل بيانات ملفه لتحديث بيانات المخطط.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var embeddedData = Array.from(oleFrame.getEmbeddedData().getEmbeddedFileData());
    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", java.newArray("byte", embeddedData));

    // قراءة بيانات كائن OLE ككائن Workbook.
    var workbook = java.newInstanceSync("com.aspose.cells.Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // تعديل بيانات الـ Workbook.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("com.aspose.cells.OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // تغيير بيانات كائن إطار OLE.
    var newFileData = java.newArray("byte", Array.from(newOleStream.toByteArray()));
    var newData = new asposeSlides.OleEmbeddedDataInfo(newFileData, oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **إدراج أنواع ملفات أخرى في الشرائح**

إلى جانب مخططات Excel، يتيح لك Aspose.Slides for Node.js via Java إدراج أنواع أخرى من الملفات في الشرائح. على سبيل المثال، يمكنك إدراج ملفات HTML وPDF وZIP ككائنات. عندما ينقر المستخدم مزدوجًا على الكائن المدرج، يفتح تلقائيًا في البرنامج المناسب، أو يطلب منه اختيار برنامج ملائم لفتحه.

يعرض هذا الكود JavaScript كيفية إدراج HTML وZIP في شريحة:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var htmlBuffer = fs.readFileSync("sample.html");
var htmlData = Array.from(htmlBuffer);
var htmlDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", htmlData), "html");
var htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

var zipBuffer = fs.readFileSync("sample.zip");
var zipData = Array.from(zipBuffer);
var zipDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", zipData), "zip");
var zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **تحديد نوع الملف للكائنات المدخلة**

عند العمل على عروض تقديمية، قد تحتاج إلى استبدال كائنات OLE القديمة بأخرى جديدة أو استبدال كائن OLE غير المدعوم بآخر مدعوم. يتيح لك Aspose.Slides for Node.js via Java تعيين نوع الملف لكائن مدمج، مما يمكنك من تحديث بيانات إطار OLE أو امتداده.

يعرض هذا الكود JavaScript كيفية تعيين نوع الملف لكائن OLE مدمج إلى `zip`:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// تغيير نوع الملف إلى ZIP.
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **تعيين صور الأيقونة والعناوين للكائنات المدخلة**

بعد إدراج كائن OLE، يتم إضافة معاينة تتألف من صورة أيقونة تلقائيًا. هذه المعاينة هي ما يراه المستخدمون قبل الوصول إلى كائن OLE أو فتحه. إذا رغبت في استخدام صورة ونص محددين كعناصر في المعاينة، يمكنك تعيين صورة الأيقونة والعنوان باستخدام Aspose.Slides for Node.js via Java.

يعرض هذا الكود JavaScript كيفية تعيين صورة الأيقونة والعنوان لكائن مدمج:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// إضافة صورة إلى موارد العرض التقديمي.
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **منع تعديل حجم أو موضع إطار OLE**

بعد إضافة كائن OLE مرتبط إلى شريحة عرض تقديمي، عند فتح العرض في PowerPoint قد ترى رسالة تطلب تحديث الروابط. قد يؤدي النقر على زر "Update Links" إلى تغيير حجم وموضع إطار كائن OLE لأن PowerPoint يقوم بتحديث البيانات من كائن OLE المرتبط ويُعيد تحميل معاينة الكائن. لمنع PowerPoint من طلب تحديث بيانات الكائن، استدع طريقة [setUpdateAutomatic](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) للفئة [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/) مع القيمة `false`:

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **استخراج الملفات المدخلة**

يتيح لك Aspose.Slides for Node.js via Java استخراج الملفات المدمجة في الشرائح ككائنات OLE بهذه الطريقة:

1. إنشاء كائن من صف [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) يحتوي على كائنات OLE التي تريد استخراجها.
2. التجول عبر جميع الأشكال في العرض والوصول إلى أشكال [OLEObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe).
3. الوصول إلى بيانات الملفات المدمجة من أطر OLE وكتابتها إلى القرص.

يعرض هذا الكود JavaScript كيفية استخراج الملفات المدمجة في شريحة ككائنات OLE:

```javascript
const asposeSlides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);

for (var index = 0; index < slide.getShapes().size(); index++) {
    var shape = slide.getShapes().get_Item(index);

    if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
        var oleFrame = shape;

        var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        var filePath = "OLE_object_" + index + fileExtension;
        fs.writeFileSync(filePath, Buffer.from(fileData));
    }
}

presentation.dispose();
```

## **الأسئلة الشائعة**

**هل سيتم عرض محتوى OLE عند تصدير الشرائح إلى PDF/صور؟**

ما هو مرئي على الشريحة يُرسم—الأيقونة/صورة الاستبدال (المعاينة). لا يتم تنفيذ محتوى OLE "الحي" أثناء عملية العرض. إذا لزم الأمر، قم بتعيين صورة معاينة خاصة لضمان المظهر المطلوب في ملف PDF المُصدّر.

للحفاظ أيضًا على الملف المدمج كمرفق PDF، استدع [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setIncludeOleData) مع القيمة `true`. هذا الخيار معطل افتراضيًا. للحصول على مثال وإرشادات للتحقق من المرفق، راجع [Preserve Embedded OLE Files as PDF Attachments](/slides/ar/nodejs-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments) (تم ترجمة النص إلى العربية).

**كيف يمكنني قفل كائن OLE على شريحة بحيث لا يتمكن المستخدمون من تحريكه/تعديله في PowerPoint؟**

قفل الشكل: يوفر Aspose.Slides قفلًا على مستوى الشكل. هذا ليس تشفيرًا، لكنه يمنع فعليًا التعديلات غير المقصودة والتحريك.

**هل سيتم الحفاظ على المسارات النسبية لكائنات OLE المرتبطة في تنسيق PPTX؟**

في PPTX، لا تتوفر معلومات "المسار النسبي"—فقط المسار الكامل. تُوجد المسارات النسبية في تنسيق PPT القديم. للانتقال السلس، يُفضل استخدام مسارات مطلقة موثوقة/URI يمكن الوصول إليها أو الاعتماد على الإدراج.