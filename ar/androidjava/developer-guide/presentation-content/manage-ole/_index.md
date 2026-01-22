---
title: إدارة OLE في العروض التقديمية على Android
linktitle: إدارة OLE
type: docs
weight: 40
url: /ar/androidjava/manage-ole/
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
- Android
- Java
- Aspose.Slides
description: "تحسين إدارة كائنات OLE في ملفات PowerPoint وOpenDocument باستخدام Aspose.Slides لنظام Android عبر Java. قم بتضمين وتحديث وتصدير محتوى OLE بسلاسة."
---

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) هي تقنية من مايكروسوفت تسمح بنقل البيانات والكائنات التي تم إنشاؤها في تطبيق إلى تطبيق آخر عبر الربط أو الإدراج. 

{{% /alert %}} 

تخيل المخطط الذي تم إنشاؤه في MS Excel. ثم يُدرج هذا المخطط داخل شريحة PowerPoint. يُعتبر هذا المخطط في Excel ككائن OLE. 

- قد يظهر كائن OLE كأيقونة. في هذه الحالة، عند النقر المزدوج على الأيقونة، يفتح المخطط في التطبيق المرتبط به (Excel)، أو يُطلب منك اختيار تطبيق لفتح أو تحرير الكائن. 
- قد يعرض كائن OLE محتوياته الفعلية، مثل محتوى المخطط. في هذه الحالة، يُفعَّل المخطط في PowerPoint، تُحمَّل واجهة المخطط، وتتمكن من تعديل بيانات المخطط داخل PowerPoint.

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/) يتيح لك إدراج كائنات OLE في الشرائح كإطارات كائن OLE ([OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)).

## **إضافة إطارات كائن OLE إلى الشرائح**

على افتراض أنك قد أنشأت مخططًا في Microsoft Excel وتريد إدراجه في شريحة كإطار كائن OLE باستخدام Aspose.Slides for Android via Java، يمكنك القيام بذلك بهذه الطريقة:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. الحصول على مرجع الشريحة عبر فهرسها.
1. قراءة ملف Excel كمصفوفة بايت.
1. إضافة [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) إلى الشريحة مع مصفوفة البايت ومعلومات أخرى عن كائن OLE.
1. كتابة العرض المعدل كملف PPTX.

في المثال أدناه، أضفنا مخططًا من ملف Excel إلى شريحة كإطار كائن OLE باستخدام Aspose.Slides for Android via Java.  
**ملاحظة** أن مُنشئ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleEmbeddedDataInfo) يأخذ امتداد الكائن القابل للإدراج كمعامل ثانٍ. يتيح هذا الامتداد لـ PowerPoint تفسير نوع الملف بشكل صحيح واختيار التطبيق المناسب لفتح كائن OLE هذا.
```java 
Presentation presentation = new Presentation();
SizeF slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// إعداد البيانات لكائن OLE.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// إضافة إطار كائن OLE إلى الشريحة.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


### **إضافة إطارات كائن OLE مرتبطة**

Aspose.Slides for Android via Java يتيح لك إضافة [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) دون إدراج البيانات ولكن فقط مع رابط إلى الملف.

يظهر الكود الجاڤا التالي كيفية إضافة [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) بملف Excel مرتبط إلى شريحة:
```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// إضافة إطار كائن OLE مع ملف Excel مرتبط.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **الوصول إلى إطارات كائن OLE**

إذا كان كائن OLE مضمّنًا بالفعل في شريحة، يمكنك العثور عليه أو الوصول إليه بهذه الطريقة:

1. تحميل عرض يحتوي على كائن OLE المضمّن بإنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة باستخدام فهرسها.
3. الوصول إلى شكل [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame).  
   في مثالنا، استخدمنا PPTX المُنشأ مسبقًا الذي يحتوي على شكل واحد فقط في الشريحة الأولى. ثم *قمنا بتحويل* ذلك الكائن إلى [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/). كان هذا هو إطار كائن OLE المطلوب الوصول إليه.
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك تنفيذ أي عملية عليه.

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن مخطط Excel مضمّن في شريحة) وبيانات ملفه.
```java 
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


### **الوصول إلى خصائص إطار كائن OLE المرتبط**

Aspose.Slides يتيح لك الوصول إلى خصائص إطار كائن OLE المرتبط.

يعرض الكود الجاڤا التالي كيفية فحص ما إذا كان كائن OLE مرتبطًا ثم الحصول على مسار الملف المرتبط:
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

في هذا القسم، يستخدم المثال البرمجي أدناه [Aspose.Cells for Android via Java](/cells/androidjava/).

{{% /alert %}}

إذا كان كائن OLE مضمّنًا بالفعل في شريحة، يمكنك بسهولة الوصول إلى ذلك الكائن وتعديل بياناته بهذه الطريقة:

1. تحميل عرض يحتوي على كائن OLE المضمّن بإنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرسها. 
3. الوصول إلى شكل إطار كائن OLE.  
   في مثالنا، استخدمنا PPTX المُنشأ مسبقًا الذي يحتوي على شكل واحد في الشريحة الأولى. ثم *قمنا بتحويل* ذلك الكائن إلى [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/). كان هذا هو إطار كائن OLE المطلوب الوصول إليه.
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك تنفيذ أي عملية عليه.
5. إنشاء كائن `Workbook` والوصول إلى بيانات OLE.
6. الوصول إلى `Worksheet` المطلوبة وتعديل البيانات.
7. حفظ الـ `Workbook` المحدث في Stream.
8. تغيير بيانات كائن OLE من الـ Stream.

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن مخطط Excel مضمّن في شريحة) وتعديل بيانات ملفه لتحديث بيانات المخطط.
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

بجانب مخططات Excel، Aspose.Slides for Android via Java يسمح لك بإدراج أنواع أخرى من الملفات في الشرائح. على سبيل المثال، يمكنك إدراج ملفات HTML، PDF، وZIP ككائنات. عند النقر المزدوج على الكائن المُدرج، يفتح تلقائيًا في البرنامج المناسب، أو يُطلب من المستخدم اختيار برنامج ملائم لفتحه.

يعرض الكود الجاڤا التالي كيفية إدراج HTML وZIP في شريحة:
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


## **تعيين أنواع الملفات للكائنات المضمّنة**

عند العمل على العروض، قد تحتاج إلى استبدال كائنات OLE القديمة بأخرى جديدة أو استبدال كائن OLE غير مدعوم بآخر مدعوم. Aspose.Slides for Android via Java يتيح لك تعيين نوع الملف لكائن مضمّن، مما يسمح لك بتحديث بيانات إطار OLE أو امتداده.

يعرض الكود الجاڤا التالي كيفية تعيين نوع الملف لكائن OLE مضمّن إلى `zip`:
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


## **تعيين صور الأيقونة والعناوين للكائنات المضمّنة**

بعد إدراج كائن OLE، يتم إضافة معاينة تتكون من صورة الأيقونة تلقائيًا. هذه المعاينة هي ما يراه المستخدمون قبل الوصول إلى كائن OLE أو فتحه. إذا رغبت في استخدام صورة ونص محددين كعناصر في المعاينة، يمكنك تعيين صورة الأيقونة والعنوان باستخدام Aspose.Slides for Android via Java.

يعرض الكود الجاڤا التالي كيفية تعيين صورة الأيقونة والعنوان لكائن مضمّن:
```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// إضافة صورة إلى موارد العرض.
File file = new File("image.png");
byte imageData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(imageData);
IPPImage oleImage = presentation.getImages().addImage(imageData);

// تعيين عنوان وصورة لمعاينة OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```


## **منع تغيير حجم وإعادة تموضع إطار كائن OLE**

بعد إضافة كائن OLE مرتبط إلى شريحة عرض، قد تظهر لك رسالة في PowerPoint تطلب تحديث الروابط عند فتح العرض. النقر على زر "Update Links" قد يغيّر حجم وموقع إطار كائن OLE لأن PowerPoint يُحدث البيانات من كائن OLE المرتبط ويُعيد رسم المعاينة. لمنع PowerPoint من طلب تحديث بيانات الكائن، عيّن طريقة `setUpdateAutomatic` للواجهة [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) إلى `false`:
```java
oleFrame.setUpdateAutomatic(false);
```


## **استخراج الملفات المضمّنة**

Aspose.Slides for Android via Java يتيح لك استخراج الملفات المضمّنة في الشرائح ككائنات OLE بهذه الطريقة:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) الذي يحتوي على كائنات OLE التي تريد استخراجها.
2. المرور على جميع الأشكال في العرض والوصول إلى أشكال [OLEObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleobjectframe).
3. الوصول إلى بيانات الملفات المضمّنة من إطارات OLE وكتابتها إلى القرص.

يعرض الكود الجاڤا التالي كيفية استخراج الملفات المضمّنة في شريحة ككائنات OLE:
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

ما يُظهر على الشريحة هو ما يُصدَّر—الأيقونة/صورة البديل (المعاينة). المحتوى "الحي" لـ OLE لا يتم تنفيذه أثناء التصدير. إذا لزم الأمر، عيّن صورة المعاينة الخاصة بك لضمان الظهور المتوقع في ملف PDF المصدَّر.

**كيف يمكنني قفل كائن OLE على شريحة بحيث لا يستطيع المستخدمون تحريكه/تحريره في PowerPoint؟**

قفل الشكل: Aspose.Slides يوفر أقفالًا على مستوى الشكل. هذا ليس تشفيرًا، لكنه يمنع التعديلات غير المقصودة والحركة.

**لماذا "يقفز" كائن Excel المرتبط أو يتغيّر حجمه عند فتح العرض؟**

قد يقوم PowerPoint بتحديث معاينة OLE المرتبط. للحصول على مظهر ثابت، اتبع ممارسات [Working Solution for Worksheet Resizing](/slides/ar/androidjava/working-solution-for-worksheet-resizing/)—إما ضبط الإطار ليتناسب مع النطاق، أو تحجيم النطاق إلى إطار ثابت وتعيين صورة بديلة مناسبة.

**هل سيتم الحفاظ على المسارات النسبية لكائنات OLE المرتبطة في صيغة PPTX؟**

في PPTX، لا تتوفر معلومات "المسار النسبي"—فقط المسار الكامل. المسارات النسبية موجودة في صيغة PPT القديمة. للمرونة، يُفضّل استخدام مسارات مطلقة موثوقة/URIs يمكن الوصول إليها أو الإدراج.