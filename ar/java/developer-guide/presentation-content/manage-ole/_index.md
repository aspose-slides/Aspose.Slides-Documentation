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
- ملف مرتبط
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
description: "تحسين إدارة كائنات OLE في ملفات PowerPoint و OpenDocument باستخدام Aspose.Slides للـ Java. تضمين وتحديث وتصدير محتوى OLE بسلاسة."
---
## **المقدمة**

{{% alert color="info" %}} 

OLE (Object Linking & Embedding) هي تقنية من مايكروسوفت تسمح بنقل البيانات والكائنات التي تم إنشاؤها في تطبيق واحد إلى تطبيق آخر عبر الربط أو التضمين. 

{{% /alert %}} 

تخيل وجود مخطط تم إنشاؤه في MS Excel. يتم وضع المخطط داخل شريحة PowerPoint. يعتبر هذا المخطط في Excel كائن OLE. 

- قد يظهر كائن OLE كأيقونة. في هذه الحالة، عندما تنقر مزدوجًا على الأيقونة، يفتح المخطط في التطبيق المرتبط به (Excel)، أو يُطلب منك اختيار تطبيق لفتح أو تحرير الكائن. 
- قد يعرض كائن OLE محتوياته الفعلية، مثل محتويات المخطط. في هذه الحالة، يتم تنشيط المخطط في PowerPoint، يتم تحميل واجهة المخطط، وتتمكن من تعديل بيانات المخطط داخل PowerPoint.

[Aspose.Slides للـ Java](https://products.aspose.com/slides/ar/java/) يتيح لك إدراج كائنات OLE في الشرائح كإطارات كائن OLE ([OleObjectFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/OleObjectFrame)).

## **إضافة إطارات كائن OLE إلى الشرائح**

بافتراض أنك قد أنشأت مخططًا بالفعل في Microsoft Excel وتريد تضمينه في شريحة كإطار كائن OLE باستخدام Aspose.Slides للـ Java، يمكنك فعل ذلك بهذه الطريقة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation) .
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. قراءة ملف Excel كمصفوفة بايت.
1. إضافة الـ[OleObjectFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/OleObjectFrame) إلى الشريحة مع تضمين مصفوفة البايت والمعلومات الأخرى الخاصة بكائن OLE.
1. كتابة العرض المعدل كملف PPTX.

في المثال أدناه، أضفنا مخططًا من ملف Excel إلى شريحة كإطار كائن OLE باستخدام Aspose.Slides للـ Java.  
**ملاحظة** أن مُنشئ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/OleEmbeddedDataInfo) يأخذ امتداد الكائن القابل للتضمين كمعامل ثانٍ. يتيح هذا الامتداد لـ PowerPoint تفسير نوع الملف بشكل صحيح واختيار التطبيق المناسب لفتح كائن OLE هذا.

``` java 
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **إضافة إطارات OLE مرتبطة**

Aspose.Slides للـ Java يتيح لك إضافة [OleObjectFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/OleObjectFrame) دون تضمين البيانات وإنما فقط عبر ارتباط إلى الملف.

يوضح هذا الكود Java كيفية إضافة [OleObjectFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/OleObjectFrame) بملف Excel مرتبط إلى شريحة:

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

1. تحميل عرض يحتوي على كائن OLE المضمّن بإنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation) .
2. الحصول على مرجع الشريحة باستخدام فهرسها.
3. الوصول إلى شكل [OleObjectFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/OleObjectFrame). في مثالنا، استخدمنا ملف PPTX السابق الذي يحتوي على شكل واحد فقط في الشريحة الأولى. ثم *cast* ذلك الكائن إلى [IOleObjectFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IOleObjectFrame). كان هذا هو إطار OLE المطلوب الوصول إليه.
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك تنفيذ أي عملية عليه.

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن مخطط Excel مضمّن في شريحة) وبيانات ملفه.

``` java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // احصل على بيانات الملف المضمّن.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // احصل على امتداد الملف المضمّن.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **الوصول إلى خصائص إطار OLE المرتبط**

Aspose.Slides يتيح لك الوصول إلى خصائص إطار كائن OLE المرتبط.

يوضح هذا الكود Java كيفية التحقق مما إذا كان كائن OLE مرتبطًا ثم الحصول على مسار الملف المرتبط:

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}} 

في هذا القسم، يستخدم المثال البرمجي أدناه [Aspose.Cells للـ Java](/cells/java/).

{{% /alert %}}

إذا كان كائن OLE مضمّنًا بالفعل في شريحة، يمكنك بسهولة الوصول إلى ذلك الكائن وتعديل بياناته بهذه الطريقة:

1. تحميل عرض يحتوي على كائن OLE المضمّن بإنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation) .
2. الحصول على مرجع الشريحة من خلال فهرسها. 
3. الوصول إلى شكل إطار كائن OLE. في مثالنا، استخدمنا ملف PPTX السابق الذي يحتوي على شكل واحد في الشريحة الأولى. ثم *cast* ذلك الكائن إلى [IOleObjectFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IOleObjectFrame). كان هذا هو إطار OLE المطلوب الوصول إليه.
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك تنفيذ أي عملية عليه.
5. إنشاء كائن `Workbook` والوصول إلى بيانات OLE.
6. الوصول إلى الـ`Worksheet` المطلوب وتعديل البيانات.
7. حفظ الـ`Workbook` المحدث في تدفق.
8. تغيير بيانات كائن OLE من التدفق.

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن مخطط Excel مضمّن في شريحة) وتعديل بيانات ملفه لتحديث بيانات المخطط.

``` java 
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

    // تعديل بيانات المصّنف.
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

بالإضافة إلى مخططات Excel، يتيح لك Aspose.Slides للـ Java تضمين أنواع أخرى من الملفات في الشرائح. على سبيل المثال، يمكنك إدراج ملفات HTML وPDF وZIP ككائنات. عند نقر المستخدم مزدوجًا على الكائن المُدرج، يفتح تلقائيًا في البرنامج المناسب، أو يُطلب منه اختيار برنامج مناسب لفتحه.

يوضح هذا الكود Java كيفية تضمين HTML وZIP في شريحة:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

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

## **تحديد أنواع الملفات للكائنات المدمجة**

عند العمل مع العروض، قد تحتاج إلى استبدال كائنات OLE القديمة بأخرى جديدة أو استبدال كائن OLE غير مدعوم بآخر مدعوم. يتيح لك Aspose.Slides للـ Java تحديد نوع الملف لكائن مدمج، مما يسمح لك بتحديث بيانات إطار OLE أو امتداده.

يوضح هذا الكود Java كيفية تعيين نوع الملف لكائن OLE مدمج إلى `zip`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// غيّر نوع الملف إلى ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **تعيين صور الأيقونات والعناوين للكائنات المدمجة**

بعد دمج كائن OLE، تُضاف معاينة مكوّنة من صورة أيقونة تلقائيًا. هذه المعاينة هي ما يراه المستخدمون قبل الوصول إلى كائن OLE أو فتحه. إذا رغبت في استخدام صورة ونص معينين كعناصر في المعاينة، يمكنك تعيين صورة الأيقونة والعنوان باستخدام Aspose.Slides للـ Java.

يوضح هذا الكود Java كيفية تعيين صورة الأيقونة والعنوان لكائن مدمج:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// إضافة صورة إلى موارد العرض.
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// تعيين عنوان وصورة معاينة OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **منع تغيير حجم وإعادة تموضع إطار كائن OLE**

بعد إضافة كائن OLE مرتبط إلى شريحة عرض، قد ترى عند فتح العرض في PowerPoint رسالة تطلب تحديث الروابط. قد يؤدي النقر على زر "Update Links" إلى تغيير حجم وموقع إطار كائن OLE لأن PowerPoint يقوم بتحديث البيانات من كائن OLE المرتبط وبيان معاينة الكائن. لمنع PowerPoint من مطالبة تحديث بيانات الكائن، اضبط طريقة `setUpdateAutomatic` لواجهة [IOleObjectFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ioleobjectframe/) على `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **استخراج الملفات المدمجة**

Aspose.Slides للـ Java يتيح لك استخراج الملفات المدمجة في الشرائح ككائنات OLE بهذه الطريقة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation) التي تحتوي على كائنات OLE التي تريد استخراجها.
2. التجول عبر جميع الأشكال في العرض والوصول إلى أشكال [OLEObjectFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/oleobjectframe).
3. الوصول إلى بيانات الملفات المدمجة من إطارات OLEObjectFrame وكتابتها إلى القرص.

يوضح هذا الكود Java كيفية استخراج الملفات المدمجة في شريحة ككائنات OLE:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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

### هل سيتم عرض محتوى OLE عند تصدير الشرائح إلى PDF/صور؟

ما هو مرئي على الشريحة هو ما يتم تصييره—الأيقونة/الصورة البديلة (المعاينة). لا يتم تنفيذ محتوى OLE "الحي" أثناء عملية التصيير. إذا لزم الأمر، عيّن صورة معاينة خاصة بك لضمان المظهر المتوقع في ملف PDF المُصدّر.

### كيف يمكنني قفل كائن OLE على شريحة بحيث لا يتمكن المستخدمون من تحريكه/تحريره في PowerPoint؟

قفل الشكل: Aspose.Slides يوفر [قفل على مستوى الشكل](/slides/ar/java/applying-protection-to-presentation/). هذا ليس تشفيرًا، لكنه يمنع فعليًا التعديلات والحركات غير المقصودة.

### لماذا "يقفز" كائن Excel المرتبط أو يتغير حجمه عند فتح العرض؟

قد يقوم PowerPoint بإنعاش معاينة كائن OLE المرتبط. للحصول على مظهر ثابت، اتبع ممارسات [الحل العملي لتغيير حجم ورقة العمل](/slides/ar/java/working-solution-for-worksheet-resizing/)—إما ملاءمة الإطار للنطاق، أو تحجيم النطاق إلى إطار ثابت وتعيين صورة بديلة مناسبة.

### هل سيتم الحفاظ على المسارات النسبية لكائنات OLE المرتبطة في تنسيق PPTX؟

في PPTX، لا تتوفر معلومات "المسار النسبي"—فقط المسار الكامل. تُوجد المسارات النسبية في تنسيق PPT القديم. لضمان القابلية للنقل، يفضَّل استخدام مسارات مطلقة موثوقة/عناوين URI قابلة للوصول أو الاعتماد على التضمين.