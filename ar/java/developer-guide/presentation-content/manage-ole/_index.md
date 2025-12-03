---
title: إدارة OLE في العروض التقديمية باستخدام Java
linktitle: إدارة OLE
type: docs
weight: 40
url: /ar/java/manage-ole/
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
- ملف مربوط
- تغيير OLE
- أيقونة OLE
- عنوان OLE
- استخراج OLE
- استخراج كائن
- استخراج ملف
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تحسين إدارة كائنات OLE في ملفات PowerPoint وOpenDocument باستخدام Aspose.Slides للغة Java. تضمين، تحديث، وتصدير محتوى OLE بسلاسة."
---

{{% alert color="primary" %}} 

OLE (ربط الكائنات وتضمينها) هي تقنية من مايكروسوفت تسمح بنقل البيانات والكائنات التي تم إنشاؤها في تطبيق واحد إلى تطبيق آخر عبر الربط أو التضمين. 

{{% /alert %}} 

تخيل رسمًا بيانيًا تم إنشاؤه في برنامج MS Excel. ثم يتم وضع الرسم داخل شريحة PowerPoint. يُعتبر هذا الرسم البياني من Excel كائن OLE. 

- قد يظهر كائن OLE كأيقونة. في هذه الحالة، عندما تنقر مزدوجًا على الأيقونة، يُفتح الرسم في التطبيق المرتبط به (Excel)، أو يُطلب منك اختيار تطبيق لفتح الكائن أو تحريره. 
- قد يعرض كائن OLE محتواه الفعلي، مثل محتوى رسم بياني. في هذه الحالة، يتم تفعيل الرسم في PowerPoint، يُحمَّل واجهة الرسم، وتتمكن من تعديل بيانات الرسم داخل PowerPoint.

[Aspose.Slides for Java](https://products.aspose.com/slides/java/) يسمح لك بإدراج OLE Objects في الشرائح كإطارات كائن OLE ([OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)).

## **إضافة إطارات كائن OLE إلى الشرائح**

بافتراض أنك قد أنشأت رسمًا بيانيًا بالفعل في Microsoft Excel وتريد تضمينه في شريحة كإطار كائن OLE باستخدام Aspose.Slides for Java، يمكنك القيام بذلك بهذه الطريقة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). 
1. الحصول على مرجع الشريحة عبر فهرسها. 
1. قراءة ملف Excel كمصفوفة بايت. 
1. إضافة [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) إلى الشريحة متضمنًا مصفوفة البايت ومعلومات أخرى حول كائن OLE. 
1. حفظ العرض التقديمي المعدل كملف PPTX. 

في المثال أدناه، أضفنا رسمًا من ملف Excel إلى شريحة كإطار كائن OLE باستخدام Aspose.Slides for Java. **ملاحظة** أن مُنشيء [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/OleEmbeddedDataInfo) يأخذ امتداد كائن قابل للتضمين كمعامل ثانٍ. يتيح هذا الامتداد لبرنامج PowerPoint تفسير نوع الملف بشكل صحيح واختيار التطبيق المناسب لفتح كائن OLE هذا.
``` java 
Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// تحضير البيانات لكائن OLE.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// إضافة إطار كائن OLE إلى الشريحة.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


### **إضافة إطارات OLE المرتبطة**

يسمح لك Aspose.Slides for Java بإضافة [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) دون تضمين البيانات وإنما فقط عبر ارتباط إلى الملف.

يعرض لك هذا الكود Java كيفية إضافة [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) مع ملف Excel مرتبط إلى شريحة:
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// إضافة إطار كائن OLE مع ملف Excel مرتبط.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **الوصول إلى إطارات OLE**

إذا كان كائن OLE مضمّنًا بالفعل في شريحة، يمكنك بسهولة العثور عليه أو الوصول إليه بهذه الطريقة:

1. تحميل عرض تقديمي يحتوي على كائن OLE مضمّن بإنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). 
2. الحصول على مرجع الشريحة باستخدام فهرستها. 
3. الوصول إلى شكل [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame). 
   في مثالنا، استخدمنا ملف PPTX الذي تم إنشاؤه مسبقًا والذي يحتوي على شكل واحد فقط في الشريحة الأولى. ثم قمنا *بتحويل* هذا الكائن إلى [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame). كان هذا هو إطار كائن OLE المطلوب الوصول إليه. 
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك إجراء أي عملية عليه. 

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن رسم بياني من Excel مضمّن في شريحة) وبيانات ملفه.
``` java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // الحصول على بيانات الملف المضمّن.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // الحصول على امتداد الملف المضمّن.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```


### **الوصول إلى خصائص إطار OLE المرتبط**

يسمح لك Aspose.Slides بالوصول إلى خصائص إطار OLE المرتبط.

يعرض لك هذا الكود Java كيفية التحقق مما إذا كان كائن OLE مرتبطًا ثم الحصول على مسار الملف المرتبط:
```java
Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // التحقق مما إذا كان كائن OLE مرتبطًا.
    if (oleFrame.isObjectLink()) {
        // طباعة المسار الكامل للملف المرتبط.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // طباعة المسار النسبي للملف المرتبط إذا كان موجودًا.
        // يمكن فقط لعروض PPT أن تحتوي على المسار النسبي.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```


## **تغيير بيانات كائن OLE**

{{% alert color="primary" %}} 

في هذا القسم، يستخدم المثال البرمجي أدناه [Aspose.Cells for Java](/cells/java/).

{{% /alert %}}

إذا كان كائن OLE مضمّنًا بالفعل في شريحة، يمكنك بسهولة الوصول إلى هذا الكائن وتعديل بياناته بهذه الطريقة:

1. تحميل عرض تقديمي يحتوي على كائن OLE مضمّن بإنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation). 
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. الوصول إلى شكل إطار كائن OLE. 
   في مثالنا، استخدمنا ملف PPTX الذي تم إنشاؤه مسبقًا والذي يحتوي على شكل واحد في الشريحة الأولى. ثم قمنا *بتحويل* هذا الكائن إلى [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame). كان هذا هو إطار كائن OLE المطلوب الوصول إليه. 
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك إجراء أي عملية عليه. 
5. إنشاء كائن `Workbook` والوصول إلى بيانات OLE. 
6. الوصول إلى `Worksheet` المطلوبة وتعديل البيانات. 
7. حفظ `Workbook` المحدث في تدفق. 
8. تغيير بيانات كائن OLE من التدفق. 

في المثال أدناه، تم الوصول إلى إطار كائن OLE (كائن رسم بياني من Excel مضمّن في شريحة)، وتم تعديل بيانات ملفه لتحديث بيانات الرسم.
``` java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // قراءة بيانات كائن OLE ككائن Workbook.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // تعديل بيانات الـ workbook.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // تغيير بيانات إطار كائن OLE.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **تضمين أنواع ملفات أخرى في الشرائح**

بالإضافة إلى مخططات Excel، يسمح لك Aspose.Slides for Java بتضمين أنواع أخرى من الملفات في الشرائح. على سبيل المثال، يمكنك إدراج ملفات HTML وPDF وZIP ككائنات. عندما ينقر المستخدم مزدوجًا على الكائن المُدرج، يفتح تلقائيًا في البرنامج المناسب، أو يُطلب من المستخدم اختيار برنامج مناسب لفتحه.

يعرض لك هذا الكود Java كيفية تضمين HTML وZIP في شريحة:
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

byte[] htmlData = Files.readAllBytes(Paths.get("sample.html"));
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

byte[] zipData = Files.readAllBytes(Paths.get("sample.zip"));
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **تحديد نوع الملف للكائنات المضمَّنة**

عند العمل على العروض التقديمية، قد تحتاج إلى استبدال كائنات OLE القديمة بأخرى جديدة أو استبدال كائن OLE غير مدعوم بآخر مدعوم. يسمح لك Aspose.Slides for Java بتحديد نوع الملف للكائن المضمّن، مما يتيح لك تحديث بيانات إطار OLE أو امتداده.

يعرض لك هذا الكود Java كيفية تعيين نوع الملف لكائن OLE مضمّن إلى `zip`:
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Change the file type to ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **تعيين صور الأيقونات والعناوين للكائنات المضمَّنة**

بعد تضمين كائن OLE، يتم إضافة معاينة تتكون من صورة أيقونة تلقائيًا. هذه المعاينة هي ما يراه المستخدمون قبل الوصول إلى كائن OLE أو فتحه. إذا أردت استخدام صورة ونص محددين كعناصر في المعاينة، يمكنك تعيين صورة الأيقونة والعنوان باستخدام Aspose.Slides for Java.

يعرض لك هذا الكود Java كيفية تعيين صورة الأيقونة والعنوان لكائن مضمّن:
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// إضافة صورة إلى موارد العرض التقديمي.
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **منع إعادة تحجيم وإعادة وضع إطار كائن OLE**

بعد إضافة كائن OLE مرتبط إلى شريحة عرض تقديمي، عند فتح العرض في PowerPoint قد تظهر لك رسالة تطلب تحديث الروابط. النقر على زر "Update Links" قد يغيّر حجم وموضع إطار كائن OLE لأن PowerPoint يُحدّث البيانات من كائن OLE المرتبط ويُعيد تحميل معاينة الكائن. لمنع PowerPoint من طلب تحديث بيانات الكائن، اضبط طريقة `setUpdateAutomatic` للواجهة [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/) على `false`:
```java
oleFrame.setUpdateAutomatic(false);
```


## **استخراج الملفات المضمَّنة**

يسمح لك Aspose.Slides for Java باستخراج الملفات المضمنة في الشرائح ككائنات OLE بهذه الطريقة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) التي تحتوي على كائنات OLE التي ترغب في استخراجها. 
2. التكرار عبر جميع الأشكال في العرض والوصول إلى أشكال [OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe). 
3. الوصول إلى بيانات الملفات المضمنة من إطارات OLE وكتابتها إلى القرص. 

يعرض لك هذا الكود Java كيفية استخراج الملفات المضمنة في شريحة ككائنات OLE:
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        Path filePath = Paths.get("OLE_object_" + index + fileExtension);
        Files.write(filePath, fileData);
    }
}

presentation.dispose();
```


## **الأسئلة الشائعة**

**هل سيتم عرض محتوى OLE عند تصدير الشرائح إلى PDF/صور؟**

ما هو مرئي على الشريحة يتم عرضه—الأيقونة/الصورة البديلة (المعاينة). لا يتم تنفيذ محتوى OLE "الحي" أثناء العرض. إذا لزم الأمر، اضبط صورة المعاينة الخاصة بك لضمان المظهر المتوقع في ملف PDF المصدر.

**كيف يمكنني قفل كائن OLE على شريحة بحيث لا يتمكن المستخدمون من تحريكه/تحريره في PowerPoint؟**

قفل الشكل: يوفر Aspose.Slides [قفل على مستوى الشكل](/slides/ar/java/applying-protection-to-presentation/). هذا ليس تشفيرًا، لكنه يمنع فعليًا التعديلات والحركات غير المقصودة.

**لماذا يقفز كائن Excel المرتبط أو يتغير حجمه عندما أفتح العرض؟**

قد يقوم PowerPoint بتحديث معاينة OLE المرتبط. للحصول على مظهر ثابت، اتبع ممارسات [حلّ العمل لتغيير حجم ورقة العمل](/slides/ar/java/working-solution-for-worksheet-resizing/)—إما أن تضبط الإطار ليتناسب مع النطاق، أو تقم بتوسيع النطاق إلى إطار ثابت وتعيين صورة بديلة مناسبة.

**هل سيتم حفظ المسارات النسبية لكائنات OLE المرتبطة في تنسيق PPTX؟**

في PPTX، لا تتوفر معلومات "المسار النسبي"—فقط المسار الكامل. المسارات النسبية توجد في تنسيق PPT القديم. لتحقيق قابلية النقل، يفضَّل استخدام مسارات مطلقة موثوقة/عناوين URI قابلة للوصول أو التضمين.