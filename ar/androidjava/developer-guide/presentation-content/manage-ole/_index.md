---
title: إدارة OLE في العروض التقديمية على Android
linktitle: إدارة OLE
type: docs
weight: 40
url: /ar/androidjava/manage-ole/
keywords:
- كائن OLE
- ربط الكائنات وإدماجها
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
- Android
- Java
- Aspose.Slides
description: "تحسين إدارة كائنات OLE في ملفات PowerPoint وOpenDocument باستخدام Aspose.Slides للأندرويد عبر Java. تضمين، تحديث، وتصدير محتوى OLE بسلاسة."
---

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) هي تقنية من مايكروسوفت تسمح بإنشاء البيانات والكائنات في تطبيق واحد ووضعها في تطبيق آخر عبر الربط أو الإدماج. 

{{% /alert %}} 

تخيل وجود مخطط تم إنشاؤه في MS Excel. يتم وضع هذا المخطط داخل شريحة PowerPoint. يُعتبر هذا المخطط من Excel ككائن OLE. 

- قد يظهر كائن OLE كأيقونة. في هذه الحالة، عند النقر المزدوج على الأيقونة، يُفتح المخطط في التطبيق المرتبط به (Excel)، أو يُطلب منك اختيار تطبيق لفتح أو تحرير الكائن. 
- قد يعرض كائن OLE محتوياته الفعلية، مثل محتويات المخطط. في هذه الحالة، يتم تنشيط المخطط في PowerPoint، يتم تحميل واجهة المخطط، وتستطيع تعديل بيانات المخطط داخل PowerPoint. 

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/) يسمح لك بإدراج كائنات OLE في الشرائح كإطارات كائن OLE ([OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)). 

## **إضافة إطارات كائن OLE إلى الشرائح**

افترض أنك قد أنشأت مخططًا في Microsoft Excel وتريد إدراجه في شريحة كإطار كائن OLE باستخدام Aspose.Slides for Android via Java، يمكنك القيام بذلك بهذه الطريقة:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation). 
1. الحصول على مرجع الشريحة عبر فهرستها. 
1. قراءة ملف Excel كمصفوفة بايت. 
1. إضافة [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) إلى الشريحة مع مصفوفة البايت ومعلومات أخرى حول كائن OLE. 
1. كتابة العرض التقديمي المعدل كملف PPTX. 

في المثال أدناه، أضفنا مخططًا من ملف Excel إلى شريحة كإطار كائن OLE باستخدام Aspose.Slides for Android via Java. **ملاحظة** أن منشئ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleEmbeddedDataInfo) يأخذ امتداد كائن قابل للإدماج كمعامل ثانٍ. يتيح هذا الامتداد لـ PowerPoint تفسير نوع الملف بشكل صحيح واختيار التطبيق المناسب لفتح كائن OLE هذا. 
```java 
Presentation presentation = new Presentation();
SizeF slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


### **إضافة إطارات OLE المرتبطة**

Aspose.Slides for Android via Java يسمح لك بإضافة [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) دون إدماج البيانات بل فقط باستخدام رابط إلى الملف. 

يوضح لك هذا الكود Java كيفية إضافة [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) بملف Excel مرتبط إلى شريحة: 
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// إضافة إطار كائن OLE بملف Excel مرتبط.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **الوصول إلى إطارات OLE**

إذا كان كائن OLE مدمجًا بالفعل في شريحة، يمكنك بسهولة العثور عليه أو الوصول إليه بهذه الطريقة:

1. تحميل عرض تقديمي يحتوي على كائن OLE مدمج بإنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation). 
2. الحصول على مرجع الشريحة باستخدام فهرستها. 
3. الوصول إلى شكل [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame). 
في مثالنا، استخدمنا ملف PPTX المنشأ مسبقًا الذي يحتوي على شكل واحد فقط في الشريحة الأولى. ثم *قمنا بتحويل* ذلك الكائن إلى [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/). كان هذا هو إطار كائن OLE المطلوب للوصول إليه. 
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك تنفيذ أي عملية عليه. 

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن مخطط Excel مدمج في شريحة) وبيانات ملفه. 
```java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // احصل على بيانات الملف المدمج.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // احصل على امتداد الملف المدمج.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```


### **الوصول إلى خصائص إطار OLE المرتبط**

Aspose.Slides يتيح لك الوصول إلى خصائص إطار كائن OLE المرتبط. 

يوضح لك هذا الكود Java كيفية التحقق مما إذا كان كائن OLE مرتبطًا ثم الحصول على مسار الملف المرتبط: 
```java
Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // تحقق مما إذا كان كائن OLE مرتبطًا.
    if (oleFrame.isObjectLink()) {
        // اطبع المسار الكامل للملف المرتبط.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // اطبع المسار النسبي للملف المرتبط إذا كان موجودًا.
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

في هذا القسم، يستخدم مثال الكود أدناه [Aspose.Cells for Android via Java](/cells/androidjava/). 

{{% /alert %}}

إذا كان كائن OLE مدمجًا بالفعل في شريحة، يمكنك بسهولة الوصول إلى ذلك الكائن وتعديل بياناته بهذه الطريقة:

1. تحميل عرض تقديمي يحتوي على كائن OLE مدمج بإنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation). 
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. الوصول إلى شكل إطار كائن OLE. 
في مثالنا، استخدمنا ملف PPTX المنشأ مسبقًا الذي يحتوي على شكل واحد في الشريحة الأولى. ثم *قمنا بتحويل* ذلك الكائن إلى [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/). كان هذا هو إطار كائن OLE المطلوب للوصول إليه. 
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك تنفيذ أي عملية عليه. 
5. إنشاء كائن `Workbook` والوصول إلى بيانات OLE. 
6. الوصول إلى `Worksheet` المطلوبة وتعديل البيانات. 
7. حفظ الـ `Workbook` المحدث في تدفق. 
8. تغيير بيانات كائن OLE من التدفق. 

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن مخطط Excel مدمج في شريحة) وتعديل بيانات ملفه لتحديث بيانات المخطط. 
```java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // قراءة بيانات كائن OLE ككائن Workbook.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // تعديل بيانات الـ Workbook.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // تغيير بيانات كائن إطار OLE.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **إدراج أنواع ملفات أخرى في الشرائح**

إلى جانب مخططات Excel، يتيح لك Aspose.Slides for Android via Java إدراج أنواع أخرى من الملفات في الشرائح. على سبيل المثال، يمكنك إدراج ملفات HTML وPDF وZIP ككائنات. عندما يقوم المستخدم بالنقر المزدوج على الكائن المُدرج، يفتح تلقائيًا في البرنامج المناسب، أو يُطلب من المستخدم اختيار برنامج مناسب لفتحه. 

يوضح لك هذا الكود Java كيفية إدراج HTML وZIP في شريحة: 
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

File fileHtml = new File("sample.html");
byte htmlData[] = new byte[(int) fileHtml.length()];
BufferedInputStream bisHtml = new BufferedInputStream(new FileInputStream(fileHtml));
DataInputStream disHtml = new DataInputStream(bisHtml);
disHtml.readFully(htmlData);
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

File fileZip = new File("sample.zip");
byte zipData[] = new byte[(int) fileZip.length()];
BufferedInputStream bisZip = new BufferedInputStream(new FileInputStream(fileZip));
DataInputStream disZip = new DataInputStream(bisZip);
disZip.readFully(zipData);
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **تحديد أنواع الملفات للكائنات المدمجة**

عند العمل على العروض التقديمية، قد تحتاج إلى استبدال كائنات OLE القديمة بأخرى جديدة أو استبدال كائن OLE غير مدعوم بآخر مدعوم. يتيح لك Aspose.Slides for Android via Java تحديد نوع الملف لكائن مدمج، مما يمكنك من تحديث بيانات إطار OLE أو امتداده. 

يوضح لك هذا الكود Java كيفية تعيين نوع الملف لكائن OLE مدمج إلى `zip`: 
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


## **تعيين صور الأيقونات والعناوين للكائنات المدمجة**

بعد دمج كائن OLE، يتم إضافة معاينة تتكون من صورة أيقونة تلقائيًا. هذه المعاينة هي ما يراه المستخدمون قبل الوصول إلى كائن OLE أو فتحه. إذا رغبت في استخدام صورة ونص محددين كعناصر في المعاينة، يمكنك تعيين صورة الأيقونة والعنوان باستخدام Aspose.Slides for Android via Java. 

يوضح لك هذا الكود Java كيفية تعيين صورة الأيقونة والعنوان لكائن مدمج: 
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// إضافة صورة إلى موارد العرض التقديمي.
File file = new File("image.png");
byte imageData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(imageData);
IPPImage oleImage = presentation.getImages().addImage(imageData);

// تعيين عنوان والصورة لمعاينة OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **منع إطار كائن OLE من إعادة التحجيم وإعادة الموضع**

بعد إضافتك لكائن OLE مرتبط إلى شريحة عرض تقديمي، عند فتح العرض في PowerPoint قد تظهر لك رسالة تطلب تحديث الروابط. النقر على زر "Update Links" قد يغير حجم وموقع إطار كائن OLE لأن PowerPoint يحدث البيانات من كائن OLE المرتبط ويعيد تحديث معاينة الكائن. لمنع PowerPoint من طلب تحديث بيانات الكائن، عيّن طريقة `setUpdateAutomatic` في واجهة [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) إلى `false`: 
```java
oleFrame.setUpdateAutomatic(false);
```


## **استخراج الملفات المدمجة**

يتيح لك Aspose.Slides for Android via Java استخراج الملفات المدمجة في الشرائح ككائنات OLE بهذه الطريقة:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) التي تحتوي على كائنات OLE التي تريد استخراجها. 
2. تكرار جميع الأشكال في العرض والوصول إلى أشكال [OLEObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleobjectframe). 
3. الوصول إلى بيانات الملفات المدمجة من إطارات OLE وكتابةها إلى القرص. 

يوضح لك هذا الكود Java كيفية استخراج الملفات المدمجة في شريحة ككائنات OLE: 
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        FileOutputStream fos = new FileOutputStream(new File("OLE_object_" + index + fileExtension));
        fos.write(fileData);
        fos.close();
    }
}

presentation.dispose();
```


## **الأسئلة الشائعة**

**هل سيتم عرض محتوى OLE عند تصدير الشرائح إلى PDF/صور؟**

ما هو مرئي على الشريحة هو ما يتم تصييره—الأيقونة/صورة البديلة (المعاينة). لا يتم تنفيذ محتوى OLE "الحي" أثناء التصيير. إذا لزم الأمر، حدّد صورة معاينة خاصة لضمان المظهر المتوقع في ملف PDF المصدر.

**كيف يمكنني قفل كائن OLE على شريحة بحيث لا يتمكن المستخدمون من تحريكه/تحريره في PowerPoint؟**

قفل الشكل: Aspose.Slides يقدم [قفل على مستوى الشكل](/slides/ar/androidjava/applying-protection-to-presentation/). هذا ليس تشفيرًا، لكنه يمنع فعليًا التعديلات والحركات غير المقصودة.

**لماذا يقفز كائن Excel المرتبط أو يتغير حجمه عند فتح العرض التقديمي؟**

قد يقوم PowerPoint بتحديث معاينة OLE المرتبط. للحصول على مظهر ثابت، اتبع ممارسات [الحل العملي لتغيير حجم ورقة العمل](/slides/ar/androidjava/working-solution-for-worksheet-resizing/) — إما ضبط الإطار على النطاق، أو تعديل النطاق ليناسب إطار ثابت وتعيين صورة بديلة مناسبة.

**هل سيتم الحفاظ على المسارات النسبية لكائنات OLE المرتبطة في تنسيق PPTX؟**

في PPTX، لا تتوفر معلومات "المسار النسبي"—فقط المسار الكامل. تُوجد المسارات النسبية في تنسيق PPT القديم. للقدرة على النقل، يفضَّل استخدام مسارات مطلقة موثوقة/عناوين URI قابلة للوصول أو الإدماج.