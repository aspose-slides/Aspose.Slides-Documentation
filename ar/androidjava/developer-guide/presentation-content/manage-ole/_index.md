---
title: إدارة OLE في العروض التقديمية على Android
linktitle: إدارة OLE
type: docs
weight: 40
url: /ar/androidjava/manage-ole/
keywords:
- كائن OLE
- ربط الكائنات وتضمينها
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
description: "تحسين إدارة كائنات OLE في ملفات PowerPoint و OpenDocument باستخدام Aspose.Slides for Android via Java. تضمين وتحديث وتصدير محتوى OLE بسلاسة."
---
## **المقدمة**

{{% alert color="info" %}} 
OLE (ربط وتضمين الكائنات) هي تقنية من مايكروسوفت تسمح بنقل البيانات والكائنات التي تم إنشاؤها في تطبيق واحد إلى تطبيق آخر من خلال الربط أو التضمين. 
{{% /alert %}} 

تخيل رسمًا بيانيًا تم إنشاؤه في MS Excel. يتم بعد ذلك وضع الرسم داخل شريحة PowerPoint. يُعتبر هذا الرسم البياني في Excel كائن OLE. 

- قد يظهر كائن OLE كأيقونة. في هذه الحالة، عند النقر المزدوج على الأيقونة، يُفتح الرسم في التطبيق المرتبط به (Excel)، أو يُطلب منك اختيار تطبيق لفتح الكائن أو تحريره. 
- قد يعرض كائن OLE محتوياته الفعلية، مثل محتوى رسم بياني. في هذه الحالة، يتم تنشيط الرسم في PowerPoint، يُحمّل واجهة الرسم، ويمكنك تعديل بيانات الرسم داخل PowerPoint. 

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/ar/androidjava/) يسمح بإدراج كائنات OLE إلى الشرائح كإطارات كائن OLE ([OleObjectFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/OleObjectFrame)).

## **إضافة إطارات كائن OLE إلى الشرائح**

با افتراض أنك قد أنشأت رسمًا بيانيًا بالفعل في Microsoft Excel وتريد تضمينه في شريحة كإطار كائن OLE باستخدام Aspose.Slides for Android via Java، يمكنك القيام بذلك بهذه الطريقة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation).  
2. الحصول على مرجع الشريحة عبر مؤشرها.  
3. قراءة ملف Excel كمصفوفة بايت.  
4. إضافة [OleObjectFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/OleObjectFrame) إلى الشريحة مع تضمين مصفوفة البايت والمعلومات الأخرى حول كائن OLE.  
5. كتابة العرض المعدل كملف PPTX.  

في المثال أدناه، قمنا بإضافة رسم بياني من ملف Excel إلى شريحة كإطار كائن OLE باستخدام Aspose.Slides for Android via Java.  
**ملاحظة** أن مُنشئ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/OleEmbeddedDataInfo) يأخذ امتداد كائن قابل للتضمين كمعامل ثانٍ. يتيح هذا الامتداد لـ PowerPoint تفسير نوع الملف بشكل صحيح واختيار التطبيق المناسب لفتح هذا الكائن OLE.  

```java 
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// تحضير البيانات لكائن OLE.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// إضافة إطار كائن OLE إلى الشريحة.
slide.getShapes().addOleObjectFrame(0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **إضافة إطارات OLE مرتبطة**

يتيح Aspose.Slides for Android via Java إضافة [OleObjectFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/OleObjectFrame) دون تضمين البيانات ولكن فقط باستخدام ارتباط إلى الملف.  

يظهر لك هذا الكود Java كيفية إضافة [OleObjectFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/OleObjectFrame) مع ملف Excel مرتبط إلى شريحة:  

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// إضافة إطار كائن OLE مع ملف Excel مرتبط.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **الوصول إلى إطارات كائن OLE**

إذا كان كائن OLE مضمّنًا بالفعل في شريحة، يمكنك بسهولة العثور عليه أو الوصول إليه بهذه الطريقة:

1. تحميل عرض يحتوي على كائن OLE مضمّن بإنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation).  
2. الحصول على مرجع الشريحة باستخدام مؤشرها.  
3. الوصول إلى الشكل [OleObjectFrame]. في مثالنا، استخدمنا ملف PPTX الذي تم إنشاؤه مسبقًا والذي يحتوي على شكل واحد فقط في الشريحة الأولى. ثم *قمنا بتحويل* ذلك الكائن إلى [IOleObjectFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ioleobjectframe/). كان هذا هو إطار كائن OLE المطلوب الوصول إليه.  
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك إجراء أي عملية عليه.  

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن رسم بياني Excel مضمّن في شريحة) وبيانات ملفه.  

```java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // الحصول على بيانات الملف المضمن.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // الحصول على امتداد الملف المضمن.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **الوصول إلى خصائص إطار OLE المرتبط**

يتيح Aspose.Slides الوصول إلى خصائص إطار كائن OLE المرتبط.  

يعرض لك هذا الكود Java كيفية التحقق مما إذا كان كائن OLE مرتبطًا ثم الحصول على مسار الملف المرتبط:  

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // التحقق مما إذا كان كائن OLE مرتبطًا.
    if (oleFrame.isObjectLink()) {
        // طباعة المسار الكامل للملف المرتبط.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // طباعة المسار النسبي للملف المرتبط إذا وجد.
        // يمكن فقط لعروض PPT أن تحتوي على المسار النسبي.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **تعديل بيانات كائن OLE**

{{% alert color="info" %}} 
في هذا القسم، يستخدم المثال البرمجي أدناه [Aspose.Cells for Android via Java](/cells/androidjava/). 
{{% /alert %}} 

إذا كان كائن OLE مضمّنًا بالفعل في شريحة، يمكنك بسهولة الوصول إلى ذلك الكائن وتعديل بياناته بهذه الطريقة:

1. تحميل عرض يحتوي على كائن OLE مضمّن بإنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation).  
2. الحصول على مرجع الشريحة عبر مؤشرها.  
3. الوصول إلى شكل إطار كائن OLE. في مثالنا، استخدمنا ملف PPTX الذي تم إنشاؤه مسبقًا والذي يحتوي على شكل واحد في الشريحة الأولى. ثم *قمنا بتحويل* ذلك الكائن إلى [IOleObjectFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ioleobjectframe/). كان هذا هو إطار كائن OLE المطلوب الوصول إليه.  
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك إجراء أي عملية عليه.  
5. إنشاء كائن `Workbook` والوصول إلى بيانات OLE.  
6. الوصول إلى `Worksheet` المطلوب وتعديل البيانات.  
7. حفظ `Workbook` المحدث في تدفق.  
8. تغيير بيانات كائن OLE من التدفق.  

في المثال أدناه، تم الوصول إلى إطار كائن OLE (كائن رسم بياني Excel مضمّن في شريحة) وتم تعديل بيانات ملفه لتحديث بيانات الرسم.  

```java 
import com.aspose.slides.*;
import com.aspose.cells.Workbook;
import com.aspose.cells.OoxmlSaveOptions;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // قراءة بيانات كائن OLE ككائن Workbook.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // تعديل بيانات المصنف.
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

## **تضمين أنواع ملفات أخرى في الشرائح**

إلى جانب رسومات Excel، يتيح Aspose.Slides for Android via Java تضمين أنواع أخرى من الملفات في الشرائح. على سبيل المثال، يمكنك إدراج ملفات HTML وPDF وZIP ككائنات. عندما ينقر المستخدم مزدوجًا على الكائن المُدرج، يفتح تلقائيًا في البرنامج المناسب، أو يُطلب من المستخدم اختيار برنامج ملائم لفتحه.  

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

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

## **تحديد أنواع الملفات للكائنات المضمّنة**

عند العمل على العروض التقديمية، قد تحتاج إلى استبدال كائنات OLE القديمة بأخرى جديدة أو استبدال كائن OLE غير مدعوم بآخر مدعوم. يتيح Aspose.Slides for Android via Java تحديد نوع الملف لكائن مضمّن، مما يمكنك من تحديث بيانات إطار OLE أو امتداده.  

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// تغيير نوع الملف إلى ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **تعيين صور الأيقونات والعناوين للكائنات المضمّنة**

بعد تضمين كائن OLE، تُضاف معاينة تتكون من صورة أيقونة تلقائيًا. هذه المعاينة هي ما يراه المستخدمون قبل الوصول إلى أو فتح كائن OLE. إذا رغبت في استخدام صورة ونص محددين كعناصر في المعاينة، يمكنك تعيين صورة الأيقونة والعنوان باستخدام Aspose.Slides for Android via Java.  

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

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

// تحديد عنوان وصورة للمعاينة OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **منع تغيير حجم وإعادة تموضع إطار كائن OLE**

بعد إضافة كائن OLE مرتبط إلى شريحة عرض، عند فتح العرض في PowerPoint قد يظهر لك رسالة تطلب تحديث الروابط. النقر على زر "Update Links" قد يغيّر حجم وموقع إطار كائن OLE لأن PowerPoint يقوم بتحديث البيانات من كائن OLE المرتبط وتحديث معاينة الكائن. لمنع PowerPoint من طلب تحديث بيانات الكائن، اضبط طريقة `setUpdateAutomatic` للواجهة [IOleObjectFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ioleobjectframe/) إلى `false`:  

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    oleFrame.setUpdateAutomatic(false);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **استخراج الملفات المضمّنة**

يتيح Aspose.Slides for Android via Java استخراج الملفات المضمّنة في الشرائح ككائنات OLE بهذه الطريقة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation) التي تحتوي على كائنات OLE التي تنوي استخراجها.  
2. تجوال عبر جميع الأشكال في العرض والوصول إلى أشكال [OLEObjectFrame].  
3. الوصول إلى بيانات الملفات المضمّنة من إطارات OLE وكتابتها إلى القرص.  

يعرض لك هذا الكود Java كيفية استخراج الملفات المضمّنة في شريحة ككائنات OLE:  

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;

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

## **الأسئلة المتكررة**

### هل يتم عرض محتوى OLE عند تصدير الشرائح إلى PDF/صور؟

ما يُظهر على الشريحة هو ما يُرسم—الأيقونة/الصورة البديلة (المعاينة). محتوى OLE "الحي" لا يتم تنفيذه أثناء التصيير. إذا لزم الأمر، قم بتعيين صورة المعاينة الخاصة بك لضمان المظهر المتوقع في ملف PDF المُصدَّر.

### كيف يمكنني قفل كائن OLE على شريحة بحيث لا يتمكن المستخدمون من نقله/تحريره في PowerPoint؟

قفل الشكل: يوفر Aspose.Slides أقفال على مستوى الشكل. هذا ليس تشفيرًا، لكنه يمنع فعليًا التعديلات غير المقصودة والحركة.

### لماذا "يقفز" كائن Excel مرتبط أو يتغيّر حجمه عندما أفتح العرض؟

قد يقوم PowerPoint بتحديث معاينة OLE المرتبط. للحصول على مظهر ثابت، اتبع ممارسات [Working Solution for Worksheet Resizing](/slides/ar/androidjava/working-solution-for-worksheet-resizing/)—إما اضبط الإطار ليتطابق مع النطاق، أو قم بتحجيم النطاق إلى إطار ثابت وضع صورة بديلة مناسبة.

### هل سيتم الحفاظ على المسارات النسبية لكائنات OLE المرتبطة في صيغة PPTX؟

في PPTX، لا تتوفر معلومات "المسار النسبي"—فقط المسار الكامل. المسارات النسبية موجودة في صيغة PPT القديمة. للقدرة على النقل، يفضَّل استخدام مسارات مطلقة موثوقة/عناوين URI قابلة للوصول أو التضمين.