---
title: إدارة OLE في العروض التقديمية باستخدام JavaScript
linktitle: إدارة OLE
type: docs
weight: 40
url: /ar/nodejs-java/manage-ole/
keywords:
- كائن OLE
- الربط والتضمين للكائنات
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

{{% alert color="primary" %}} 
OLE (Object Linking & Embedding) هو تقنية من مايكروسوفت تسمح بنقل البيانات والكائنات التي تم إنشاؤها في تطبيق إلى تطبيق آخر عبر الربط أو الإدراج. 
{{% /alert %}} 

اعتبر مخططًا تم إنشاؤه في MS Excel. ثم يتم وضع المخطط داخل شريحة PowerPoint. يُعتبر ذلك المخطط في Excel كائن OLE. 

- قد يظهر كائن OLE كأيقونة. في هذه الحالة، عند النقر المزدوج على الأيقونة، يفتح المخطط في التطبيق المرتبط به (Excel)، أو يُطلب منك اختيار تطبيق لفتح أو تحرير الكائن. 
- قد يعرض كائن OLE محتوياته الفعلية، مثل محتوى المخطط. في هذه الحالة، يُفعَّل المخطط في PowerPoint، يتم تحميل واجهة المخطط، ويمكنك تعديل بيانات المخطط داخل PowerPoint. 

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/nodejs-java/) يتيح لك إدراج كائنات OLE في الشرائح كإطارات كائن OLE ([OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)). 

## **إضافة إطارات كائن OLE إلى الشرائح**

افترض أنك قد أنشأت مخططًا في Microsoft Excel وتريد إدراجه في شريحة كإطار كائن OLE باستخدام Aspose.Slides for Node.js via Java، يمكنك فعل ذلك بهذه الطريقة:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). 
1. الحصول على مرجع الشريحة عبر فهرسها. 
1. قراءة ملف Excel كمصفوفة بايت. 
1. إضافة [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) إلى الشريحة متضمنًا مصفوفة البايت ومعلومات أخرى حول كائن OLE. 
1. كتابة العرض المعدل كملف PPTX. 

في المثال أدناه، أضفنا مخططًا من ملف Excel إلى شريحة كإطار كائن OLE باستخدام Aspose.Slides for Node.js via Java. **ملاحظة** أن مُنشئ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleEmbeddedDataInfo) يأخذ امتداد كائن قابل للإدراج كمعامل ثانٍ. يتيح هذا الامتداد لـ PowerPoint تفسير نوع الملف بشكل صحيح واختيار التطبيق المناسب لفتح كائن OLE هذا. 
```javascript
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


### **إضافة إطارات OLE مرتبطة**

Aspose.Slides for Node.js via Java يتيح لك إضافة [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) دون إدراج بيانات ولكن فقط برابط إلى الملف. 

يعرض هذا الكود JavaScript كيفية إضافة [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) بملف Excel مرتبط إلى شريحة: 
```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// إضافة إطار كائن OLE مع ملف Excel مرتبط.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **الوصول إلى إطارات OLE**

إذا كان كائن OLE مضمّنًا بالفعل في شريحة، يمكنك بسهولة العثور عليه أو الوصول إليه بهذه الطريقة: 

1. تحميل عرض يحتوي على كائن OLE المضمّن بإنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). 
2. الحصول على مرجع الشريحة باستخدام فهرسها. 
3. الوصول إلى شكل [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame). في مثالنا، استخدمنا PPTX الذي تم إنشاؤه مسبقًا والذي يحتوي على شكل واحد فقط في الشريحة الأولى. 
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك تنفيذ أي عملية عليه. 

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن مخطط Excel مضمّن في شريحة) وبيانات ملفه. 
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // احصل على بيانات الملف المضمّن.
    var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // احصل على امتداد الملف المضمّن.
    var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```


### **الوصول إلى خصائص إطار OLE المرتبط**

Aspose.Slides يتيح لك الوصول إلى خصائص إطار كائن OLE المرتبط. 

يعرض هذا الكود JavaScript كيفية التحقق مما إذا كان كائن OLE مرتبطًا ثم الحصول على مسار الملف المرتبط: 
```javascript
var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // تحقق مما إذا كان كائن OLE مرتبطًا.
    if (oleFrame.isObjectLink()) {
        // اطبع المسار الكامل للملف المرتبط.
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // اطبع المسار النسبي للملف المرتبط إذا كان موجودًا.
        // يمكن فقط لعروض PPT أن تحتوي على المسار النسبي.
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```


## **تغيير بيانات كائن OLE**

{{% alert color="primary" %}} 
في هذا القسم، يستخدم مثال الشيفرة أدناه [Aspose.Cells for Java](/cells/java/). 
{{% /alert %}} 

إذا كان كائن OLE مضمّنًا بالفعل في شريحة، يمكنك بسهولة الوصول إلى ذلك الكائن وتعديل بياناته بهذه الطريقة: 

1. تحميل عرض يحتوي على كائن OLE المضمّن بإنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). 
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. الوصول إلى شكل إطار كائن OLE. في مثالنا، استخدمنا PPTX الذي تم إنشاؤه مسبقًا والذي يحتوي على شكل واحد في الشريحة الأولى. 
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك تنفيذ أي عملية عليه. 
5. إنشاء كائن `Workbook` والوصول إلى بيانات OLE. 
6. الوصول إلى ورقة العمل `Worksheet` المطلوبة وتعديل البيانات. 
7. حفظ الـ `Workbook` المحدث في تدفق. 
8. تغيير بيانات كائن OLE من التدفق. 

في المثال أدناه، تم الوصول إلى إطار كائن OLE (كائن مخطط Excel مضمّن في شريحة) وتم تعديل بيانات ملفه لتحديث بيانات المخطط. 
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", oleFrame.getEmbeddedData().getEmbeddedFileData());

    // قراءة بيانات كائن OLE ككائن Workbook.
    var workbook = java.newInstanceSync("Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // تعديل بيانات المصنف.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // تغيير بيانات إطار كائن OLE.
    var newData = new asposeSlides.OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **إدراج أنواع ملفات أخرى في الشرائح**

بالإضافة إلى مخططات Excel، يتيح لك Aspose.Slides for Node.js via Java إدراج أنواع أخرى من الملفات في الشرائح. على سبيل المثال، يمكنك إدراج ملفات HTML وPDF وZIP ككائنات. عندما ينقر المستخدم مرتين على الكائن المدخل، يفتح تلقائيًا في البرنامج المناسب، أو يُطلب من المستخدم اختيار برنامج مناسب لفتحه. 

يعرض هذا الكود JavaScript كيفية إدراج HTML وZIP في شريحة: 
```javascript
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


## **تعيين أنواع الملفات للكائنات المدخلة**

عند العمل على العروض التقديمية، قد تحتاج إلى استبدال كائنات OLE القديمة بأخرى جديدة أو استبدال كائن OLE غير مدعوم بآخر مدعوم. يتيح لك Aspose.Slides for Node.js via Java تعيين نوع الملف لكائن مضمّن، مما يمكنك من تحديث بيانات إطار OLE أو امتداده. 

يعرض هذا الكود JavaScript كيفية تعيين نوع الملف لكائن OLE مضمّن إلى `zip`: 
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// Change the file type to ZIP.
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **تعيين صور الأيقونة والعناوين للكائنات المدخلة**

بعد إدراج كائن OLE، تُضاف معاينة مكوّنة من صورة أيقونة تلقائيًا. هذه المعاينة هي ما يراه المستخدمون قبل الوصول إلى كائن OLE أو فتحه. إذا أردت استخدام صورة ونص محددين كعناصر في المعاينة، يمكنك تعيين صورة الأيقونة والعنوان باستخدام Aspose.Slides for Node.js via Java. 

يعرض هذا الكود JavaScript كيفية تعيين صورة الأيقونة والعنوان لكائن مضمّن: 
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// إضافة صورة إلى موارد العرض التقديمي.
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// تعيين عنوان والصورة لمعاينة OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **منع تعديل حجم وإعادة تموضع إطار OLE**

بعد إضافة كائن OLE مرتبط إلى شريحة عرض، عند فتح العرض في PowerPoint قد تظهر رسالة تطلب تحديث الروابط. النقر على زر "Update Links" قد يغير حجم وموقع إطار كائن OLE لأن PowerPoint يحدّث البيانات من كائن OLE المرتبط ويُعيد إنشاء المعاينة. لمنع PowerPoint من طلب تحديث بيانات الكائن، استخدم طريقة `setUpdateAutomatic` من فئة [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/) مع القيمة `false`: 
```javascript
oleFrame.setUpdateAutomatic(false);
```


## **استخراج الملفات المدخلة**

Aspose.Slides for Node.js via Java يتيح لك استخراج الملفات المدخلة في الشرائح ككائنات OLE بهذه الطريقة: 

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) التي تحتوي على كائنات OLE التي تريد استخراجها. 
2. التمرّ عبر جميع الأشكال في العرض والوصول إلى أشكال [OLEObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe). 
3. الوصول إلى بيانات الملفات المدخلة من إطارات OLE وكتابة هذه البيانات إلى القرص. 

يعرض هذا الكود JavaScript كيفية استخراج الملفات المدخلة في شريحة ككائنات OLE: 
```javascript
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

**هل سيُعرض محتوى OLE عند تصدير الشرائح إلى PDF/صور؟**  
ما هو مرئي على الشريحة هو ما يُعرض—الأيقونة/صورة البديل (المعاينة). محتوى OLE "الحي" لا يُنفّذ أثناء التصدير. إذا لزم الأمر، عيّن صورة معاينة خاصة بك لضمان المظهر المتوقع في ملف PDF المصدر.  

**كيف يمكنني قفل كائن OLE على شريحة بحيث لا يتمكن المستخدمون من تحريكه/تحريره في PowerPoint؟**  
قفل الشكل: Aspose.Slides يقدم أقفالًا على مستوى الشكل. هذا ليس تشفيرًا، لكنه يمنع فعليًا التعديلات والحركات غير المقصودة.  

**هل سيتم الحفاظ على المسارات النسبية لكائنات OLE المرتبطة في تنسيق PPTX؟**  
في PPTX لا تتوفر معلومات "المسار النسبي"—فقط المسار الكامل. المسارات النسبية موجودة في تنسيق PPT الأقدم. للقدرة على النقل، يفضَّل استخدام مسارات مطلقة موثوقة/عناوين URI قابلة للوصول أو الإدراج.  