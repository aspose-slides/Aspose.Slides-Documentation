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
description: "تحسين إدارة كائنات OLE في ملفات PowerPoint وOpenDocument باستخدام Aspose.Slides ل Node.js. قم بتضمين المحتوى وتحديثه وتصديره بسلاسة."
---

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) هو تقنية من مايكروسوفت تسمح للبيانات والكائنات التي تم إنشاؤها في تطبيق واحد أن تُوضع في تطبيق آخر عبر الربط أو التضمين. 

{{% /alert %}} 

تخيل مخططًا تم إنشاؤه في MS Excel. يتم وضع المخطط داخل شريحة PowerPoint. يُعْتَبَر هذا المخطط في Excel ككائن OLE. 

- قد يظهر كائن OLE كأيقونة. في هذه الحالة، عند النقر المزدوج على الأيقونة، يتم فتح المخطط في التطبيق المرتبط به (Excel)، أو يُطلب منك اختيار تطبيق لفتح أو تحرير الكائن. 
- قد يعرض كائن OLE محتواه الفعلي، مثل محتوى مخطط. في هذه الحالة، يتم تنشيط المخطط في PowerPoint، يتم تحميل واجهة المخطط، ويمكنك تعديل بيانات المخطط داخل PowerPoint.

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/nodejs-java/) يسمح لك بإدراج كائنات OLE في الشرائح كإطارات كائن OLE ([OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame)).

## **إضافة إطارات كائن OLE إلى الشرائح**

بافتراض أنك قد أنشأت مخططًا بالفعل في Microsoft Excel وتريد تضمينه في شريحة كإطار كائن OLE باستخدام Aspose.Slides for Node.js via Java، يمكنك القيام بذلك بهذه الطريقة:

1. أنشئ كائنًا من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). 
2. احصل على مرجع الشريحة عبر فهرستها. 
3. اقرأ ملف Excel كمصفوفة بايت. 
4. أضف [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) إلى الشريحة مع تضمين مصفوفة البايت ومعلومات أخرى حول كائن OLE. 
5. احفظ العرض المُعدَّل كملف PPTX. 

في المثال أدناه، أضفنا مخططًا من ملف Excel إلى شريحة كإطار كائن OLE باستخدام Aspose.Slides for Node.js via Java.  
**ملحوظة** أن منشئ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleEmbeddedDataInfo) يأخذ امتداد كائن قابل للتضمين كمعامل ثانٍ. يسمح هذا الامتداد لـ PowerPoint بتفسير نوع الملف بشكل صحيح واختيار التطبيق المناسب لفتح كائن OLE هذا.  
```javascript
var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// إعداد البيانات لكائن OLE.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// إضافة إطار كائن OLE إلى الشريحة.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


### **إضافة إطارات كائن OLE المرتبطة**

Aspose.Slides for Node.js via Java يسمح لك بإضافة [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) دون تضمين البيانات ولكن فقط برابط إلى الملف.  

يعرض لك هذا الكود JavaScript كيفية إضافة [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame) مع ملف Excel مرتبط إلى شريحة:  
```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// إضافة إطار كائن OLE مع ملف Excel مرتبط.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **الوصول إلى إطارات كائن OLE**

إذا كان كائن OLE مُضمَّنًا بالفعل في شريحة، يمكنك بسهولة العثور عليه أو الوصول إليه بهذه الطريقة:

1. حمِّل عرضًا يحتوي على كائن OLE مُضمَّن بإنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). 
2. احصل على مرجع الشريحة باستخدام فهرستها. 
3. الوصول إلى شكل [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/OleObjectFrame). في مثالنا، استخدمنا ملف PPTX الذي تم إنشاؤه مسبقًا والذي يحتوي على شكل واحد فقط في الشريحة الأولى. 
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك تنفيذ أي عملية عليه.  

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن مخطط Excel مُضمَّن في شريحة) وبيانات الملف الخاصة به.  
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // احصل على بيانات الملف المضمن.
    var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // احصل على امتداد الملف المضمن.
    var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```


### **الوصول إلى خصائص إطار كائن OLE المرتبط**

يسمح لك Aspose.Slides بالوصول إلى خصائص إطار كائن OLE المرتبط.  

يعرض لك هذا الكود JavaScript كيفية التحقق مما إذا كان كائن OLE مرتبطًا ثم الحصول على مسار الملف المرتبط:  
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
        // يمكن فقط لملفات PPT أن تحتوي على المسار النسبي.
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

إذا كان كائن OLE مُضمَّنًا بالفعل في شريحة، يمكنك بسهولة الوصول إلى ذلك الكائن وتعديل بياناته بهذه الطريقة:

1. حمِّل عرضًا يحتوي على كائن OLE مُضمَّن بإنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). 
2. احصل على مرجع الشريحة عبر فهرستها. 
3. الوصول إلى شكل إطار كائن OLE. في مثالنا، استخدمنا ملف PPTX الذي تم إنشاؤه مسبقًا والذي يحتوي على شكل واحد في الشريحة الأولى. 
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك تنفيذ أي عملية عليه. 
5. أنشئ كائن `Workbook` وابدأ بالوصول إلى بيانات OLE. 
6. الوصول إلى `Worksheet` المطلوبة وتعديل البيانات. 
7. احفظ `Workbook` المحدث في تدفق. 
8. غيّر بيانات كائن OLE من التدفق.  

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن مخطط Excel مُضمَّن في شريحة) وتعديل بيانات ملفه لتحديث بيانات المخطط.  
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

    // تغيير بيانات كائن إطار OLE.
    var newData = new asposeSlides.OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **تضمين أنواع ملفات أخرى في الشرائح**

إلى جانب مخططات Excel، يسمح لك Aspose.Slides for Node.js via Java بتضمين أنواع أخرى من الملفات في الشرائح. على سبيل المثال، يمكنك إدراج ملفات HTML وPDF وZIP ككائنات. عندما ينقر المستخدم مزدوجًا على الكائن المدخل، يفتح تلقائيًا في البرنامج المناسب، أو يُطلب من المستخدم اختيار برنامج مناسب لفتحه.  

يعرض لك هذا الكود JavaScript كيفية تضمين HTML وZIP في شريحة:  
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


## **ضبط أنواع الملفات للكائنات المُضمَّنة**

عند العمل مع العروض التقديمية، قد تحتاج إلى استبدال كائنات OLE القديمة بأخرى جديدة أو استبدال كائن OLE غير مدعوم بآخر مدعوم. يسمح لك Aspose.Slides for Node.js via Java بتعيين نوع الملف لكائن مُضمَّن، مما يتيح لك تحديث بيانات إطار OLE أو امتداده.  

يعرض لك هذا الكود JavaScript كيفية تعيين نوع الملف لكائن OLE مُضمَّن إلى `zip`:  
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


## **تعيين صور الأيقونات والعناوين للكائنات المُضمَّنة**

بعد تضمين كائن OLE، يتم إضافة معاينة تتكون من صورة أيقونة تلقائيًا. هذه المعاينة هي ما يراه المستخدمون قبل الوصول إلى كائن OLE أو فتحه. إذا أردت استخدام صورة ونص محددين كعناصر في المعاينة، يمكنك تعيين صورة الأيقونة والعنوان باستخدام Aspose.Slides for Node.js via Java.  

يعرض لك هذا الكود JavaScript كيفية تعيين صورة الأيقونة والعنوان لكائن مُضمَّن:  
```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// إضافة صورة إلى موارد العرض التقديمي.
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// تعيين عنوان وصورة للمعاينة OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```


## **منع تعديل حجم وإعادة تموضع إطار كائن OLE**

بعد أن تضيف كائن OLE مرتبط إلى شريحة عرض تقديمي، عند فتح العرض في PowerPoint قد تظهر لك رسالة تطلب تحديث الروابط. قد يؤدي النقر على زر "Update Links" إلى تغيير حجم وموضع إطار كائن OLE لأن PowerPoint يقوم بتحديث البيانات من كائن OLE المرتبط ويعيد تحديث معاينة الكائن. لمنع PowerPoint من مطالبتك بتحديث بيانات الكائن، استخدم طريقة `setUpdateAutomatic` من الفئة [OleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/) مع القيمة `false`:  
```javascript
oleFrame.setUpdateAutomatic(false);
```


## **استخراج الملفات المُضمَّنة**

يسمح لك Aspose.Slides for Node.js via Java باستخراج الملفات المُضمَّنة في الشرائح ككائنات OLE بهذه الطريقة:

1. أنشئ نسخة من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) التي تحتوي على كائنات OLE التي ترغب في استخراجها. 
2. تجول عبر جميع الأشكال في العرض وادخل إلى أشكال [OLEObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe). 
3. الوصول إلى بيانات الملفات المُضمَّنة من إطارات OLE وكتابتها إلى القرص.  

يعرض لك هذا الكود JavaScript كيفية استخراج الملفات المُضمَّنة في شريحة ككائنات OLE:  
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


## **الأسئلة المتكررة**

**هل سيتم عرض محتوى OLE عند تصدير الشرائح إلى PDF/صور؟**  
ما هو مرئي على الشريحة يتم عرضه — الأيقونة/صورة الاستبدال (المعاينة). لا يتم تنفيذ محتوى OLE "الحي" أثناء العرض. إذا لزم الأمر، عيّن صورة المعاينة الخاصة بك لضمان المظهر المتوقع في ملف PDF المُصدَّر.

**كيف يمكنني قفل كائن OLE على شريحة بحيث لا يستطيع المستخدمون تحريكه/تحريره في PowerPoint؟**  
قفل الشكل: يوفر Aspose.Slides [قفل على مستوى الشكل](/slides/ar/nodejs-java/applying-protection-to-presentation/). هذا ليس تشفيرًا، لكنه يمنع فعليًا التعديلات والتحركات غير المقصودة.

**هل سيتم الحفاظ على المسارات النسبية لكائنات OLE المرتبطة في تنسيق PPTX؟**  
في PPTX، لا تتوفر معلومات "المسار النسبي" — فقط المسار الكامل. تُوجد المسارات النسبية في تنسيق PPT القديم. للقدرة على النقل، يفضَّل استخدام مسارات مطلقة موثوقة/عناوين URI قابلة للوصول أو التضمين.