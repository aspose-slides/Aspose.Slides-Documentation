---
title: إدارة OLE
type: docs
weight: 40
url: /ar/java/manage-ole/
keywords:
- إضافة OLE
- تضمين OLE
- إضافة كائن
- تضمين كائن
- تضمين ملف
- كائن مرتبط
- ربط الكائنات وتضمينها
- كائن OLE
- PowerPoint 
- عرض تقديمي
- Java
- Aspose.Slides لـ Java
description: إضافة كائنات OLE إلى عروض PowerPoint التقديمية في Java
---

{{% alert color="primary" %}} 

OLE  (ربط الكائنات وتضمينها) هي تقنية من Microsoft تسمح بإنشاء البيانات والكائنات في تطبيق واحد لتوضع في تطبيق آخر من خلال الربط أو التضمين. 

{{% /alert %}} 

افترض وجود مخطط تم إنشاؤه في MS Excel. يتم وضع المخطط بعد ذلك داخل شريحة PowerPoint. يُعتبر هذا المخطط في Excel كائن OLE. 

- قد يظهر كائن OLE كأيقونة. في هذه الحالة، عند النقر المزدوج على الأيقونة، يتم فتح المخطط في تطبيقه المرتبط (Excel)، أو يُطلب منك اختيار تطبيق لفتح الكائن أو تحريره. 
- قد تعرض كائن OLE المحتويات الفعلية—على سبيل المثال، محتويات مخطط. في هذه الحالة، يتم تنشيط المخطط في PowerPoint، ويتم تحميل واجهة المخطط، ويمكنك تعديل بيانات المخطط داخل تطبيق PowerPoint.

[Aspose.Slides لـ Java](https://products.aspose.com/slides/java/) يسمح لك بإدراج كائنات OLE في الشرائح كإطارات كائن OLE ([OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)).

## **إضافة إطارات كائن OLE إلى الشرائح**
افترض أنك قد أنشأت بالفعل مخططًا في Microsoft Excel وترغب في تضمين ذلك المخطط في شريحة كإطار كائن OLE باستخدام Aspose.Slides لـ Java، يمكنك القيام بذلك بهذه الطريقة:

1. أنشئ مثيلًا من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. احصل على مرجع الشريحة باستخدام فهرسها.
1. افتح ملف Excel الذي يحتوي على كائن مخطط Excel واحفظه في `MemoryStream`.
1. أضف [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) إلى الشريحة التي تحتوي على مصفوفة من البايتات ومعلومات أخرى حول كائن OLE.
1. اكتب العرض التقديمي المعدل كملف PPTX.

في المثال أدناه، أضفنا مخططًا من ملف Excel إلى شريحة كإطار كائن OLE باستخدام Aspose.Slides لـ Java.  
**ملاحظة** أن مُنشئ [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/IOleEmbeddedDataInfo) يأخذ امتداد كائن قابل للتضمين كمعامل ثانٍ. يسمح هذا الامتداد لبرنامج PowerPoint بتفسير نوع الملف بشكل صحيح واختيار التطبيق المناسب لفتح هذا الكائن OLE.

``` java 
// ينشئ مثيلًا من فئة Prseetation التي تمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // يصل إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // يحمل ملف Excel إلى الدفق
    FileInputStream fs = new FileInputStream("book1.xlsx");
    ByteArrayOutputStream mstream = new ByteArrayOutputStream();
    byte[] buf = new byte[4096];
    while (true)
    {
        int bytesRead = fs.read(buf, 0, buf.length);
        if (bytesRead <= 0)
            break;
        mstream.write(buf, 0, bytesRead);
    }
    fs.close();

    // ينشئ كائن بيانات للتضمين
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(mstream.toByteArray(), "xlsx");
    mstream.close();

    // يضيف شكل إطار كائن Ole 
    IOleObjectFrame oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0,
            (float) pres.getSlideSize().getSize().getWidth(),
            (float) pres.getSlideSize().getSize().getHeight(),
            dataInfo);

    //يكتب ملف PPTX إلى القرص
    pres.save("OleEmbed_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **الوصول إلى إطارات كائن OLE**
إذا كان هناك كائن OLE مضمن بالفعل في شريحة، يمكنك العثور على هذا الكائن أو الوصول إليه بسهولة بهذه الطريقة:

1. أنشئ مثيلًا من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. احصل على مرجع الشريحة باستخدام فهرسها.
1. الوصول إلى شكل إطار كائن OLE.

   في مثالنا، استخدمنا PPTX الذي تم إنشاؤه سابقًا، الذي يحتوي على شكل واحد فقط في الشريحة الأولى. ثم قمنا *بإسقاط* ذلك الكائن كـ [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame). كان هذا هو إطار كائن OLE المراد الوصول إليه.
1. بمجرد الوصول إلى إطار كائن OLE، يمكنك تنفيذ أي عملية عليه.

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن مخطط Excel مضمن في شريحة)—ثم يتم كتابة بيانات ملفه إلى ملف Excel.

``` java 
// يحمل ملف PPTX إلى كائن Presentation
Presentation pres = new Presentation("AccessingOLEObjectFrame.pptx");
try {
    // يصل إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // ينقل شكل OleObjectFrame 
    OleObjectFrame oleObjectFrame = (OleObjectFrame) sld.getShapes().get_Item(0);

    // يقرأ كائن OLE ويكتبه إلى القرص
    if (oleObjectFrame != null) {
        // يحصل على بيانات الملف المضمن
        byte[] data = oleObjectFrame.getEmbeddedData().getEmbeddedFileData();

        // يحصل على امتداد الملف المضمن
        String fileExtention = oleObjectFrame.getEmbeddedData().getEmbeddedFileExtension();

        // ينشئ مسارًا لحفظ الملف المستخرج
        String extractedPath = "excelFromOLE_out" + fileExtention;

        // يحفظ البيانات المستخرجة
        FileOutputStream fstr = new FileOutputStream(extractedPath);
        try {
            fstr.write(data, 0, data.length);
        } finally {
            fstr.close();
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **تغيير بيانات كائن OLE**

إذا كان هناك كائن OLE مضمن بالفعل في شريحة، يمكنك بسهولة الوصول إلى ذلك الكائن وتعديل بياناته بهذه الطريقة:

1. افتح العرض التقديمي المطلوب الذي يحتوي على كائن OLE المضمن بإنشاء مثيل من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class.
1. احصل على مرجع الشريحة من خلال فهرسها. 
1. الوصول إلى شكل إطار كائن OLE.

   في مثالنا، استخدمنا PPTX الذي تم إنشاؤه سابقًا والذي يحتوي على شكل واحد فقط في الشريحة الأولى. ثم قمنا *بإسقاط* ذلك الكائن كـ [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame). كان هذا هو إطار كائن OLE المراد الوصول إليه.
1. بمجرد الوصول إلى إطار كائن OLE، يمكنك تنفيذ أي عملية عليه.
1. أنشئ كائن Workbook والوصول إلى بيانات OLE.
1. الوصول إلى ورقة العمل المطلوبة وتعديل البيانات.
1. احفظ Workbook المحدث في تدفقات.
1. غير بيانات كائن OLE من بيانات التدفق.

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن مخطط Excel مضمن في شريحة)—ثم يتم تعديل بيانات ملفه لتغيير بيانات المخطط:

``` java 
Presentation pres = new Presentation("ChangeOLEObjectData.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
	
    OleObjectFrame ole = null;

    // يتجول عبر جميع الأشكال لإطار Ole
    for (IShape shape : slide.getShapes()) 
    {
        if (shape instanceof OleObjectFrame) 
        {
            ole = (OleObjectFrame) shape;
        }
    }

    if (ole != null) {
        ByteArrayInputStream msln = new ByteArrayInputStream(ole.getEmbeddedData().getEmbeddedFileData());
        try {
            // يقرأ بيانات الكائن في Workbook
            Workbook Wb = new Workbook(msln);

            ByteArrayOutputStream msout = new ByteArrayOutputStream();
            try {
                // يعدل بيانات workbook
                Wb.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
                Wb.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
                Wb.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
                Wb.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

                OoxmlSaveOptions so1 = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
                Wb.save(msout, so1);

                // يغير بيانات كائن إطار Ole
                IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(msout.toByteArray(), ole.getEmbeddedData().getEmbeddedFileExtension());
                ole.setEmbeddedData(newData);
            } finally {
                if (msout != null) msout.close();
            }
        } finally {
            if (msln != null) msln.close();
        }
    }

    pres.save("OleEdit_out.pptx", SaveFormat.Pptx);
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## تضمين أنواع ملفات أخرى في الشرائح

بجانب مخططات Excel، يسمح Aspose.Slides لـ Java بتضمين أنواع ملفات أخرى في الشرائح. على سبيل المثال، يمكنك إدراج ملفات HTML و PDF و ZIP ككائنات في الشريحة. عندما ينقر المستخدم مرتين على الكائن المدخل، يتم إطلاق الكائن تلقائيًا في البرنامج المعني، أو يتوجه المستخدم لاختيار برنامج مناسب لفتح الكائن. 

يوضح لك هذا الكود Java كيفية تضمين HTML و ZIP في شريحة:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    byte[] htmlBytes = Files.readAllBytes(Paths.get("embedOle.html"));
    IOleEmbeddedDataInfo dataInfoHtml = new OleEmbeddedDataInfo(htmlBytes, "html");
    IOleObjectFrame oleFrameHtml = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, dataInfoHtml);
    oleFrameHtml.setObjectIcon(true);

    byte[] zipBytes = Files.readAllBytes(Paths.get("embedOle.zip"));
    IOleEmbeddedDataInfo dataInfoZip = new OleEmbeddedDataInfo(zipBytes, "zip");
    IOleObjectFrame oleFrameZip = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, dataInfoZip);
    oleFrameZip.setObjectIcon(true);

    pres.save("embeddedOle.pptx", SaveFormat.Pptx);
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## تعيين أنواع الملفات للكائنات المضمنة

عند العمل على العروض التقديمية، قد تحتاج إلى استبدال كائنات OLE القديمة بأخرى جديدة. أو قد تحتاج إلى استبدال كائن OLE غير المدعوم بواحد مدعوم. 

يسمح Aspose.Slides لـ Java بتعيين نوع الملف لكائن مضمن. بهذه الطريقة، يمكنك تغيير بيانات إطار OLE أو الامتداد الخاص به. 

يوضح لك هذا الكود Java كيفية تعيين نوع الملف لكائن OLE مضمن:

```java
Presentation pres = new Presentation("embeddedOle.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IOleObjectFrame oleObjectFrame = (IOleObjectFrame)slide.getShapes().get_Item(0);
    System.out.println("الامتداد الحالي للبيانات المضمنة هو: " + oleObjectFrame.getEmbeddedData().getEmbeddedFileExtension());

    oleObjectFrame.setEmbeddedData(new OleEmbeddedDataInfo(Files.readAllBytes(Paths.get("embedOle.zip")), "zip"));

    pres.save("embeddedChanged.pptx", SaveFormat.Pptx);
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## تعيين صور الأيقونة والعناوين للكائنات المضمنة

بعد أن تقوم بتضمين كائن OLE، تتم إضافة معاينة تتكون من صورة أيقونة وعنوان تلقائيًا. المعاينة هي ما يراه المستخدمون قبل الوصول إلى كائن OLE أو فتحه. 

إذا كنت ترغب في استخدام صورة ونص معينين كعناصر في المعاينة، يمكنك تعيين صورة الأيقونة والعنوان باستخدام Aspose.Slides لـ Java. 

يوضح لك هذا الكود Java كيفية تعيين صورة الأيقونة والعنوان لكائن مضمن: 

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IOleObjectFrame oleObjectFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

        IPPImage oleImage;
        IImage image = Images.fromFile("image.png");
        try {
             oleImage = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    oleObjectFrame.setSubstitutePictureTitle("عنواني");
    oleObjectFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleObjectFrame.setObjectIcon(false);

    pres.save("embeddedOle-newImage.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **منع تغيير حجم وإعادة وضع إطار كائن OLE**

بعد إضافة كائن OLE مرتبط إلى شريحة عرض تقديمي، عند فتح العرض التقديمي في PowerPoint، قد ترى رسالة تطلب منك تحديث الروابط. قد يؤدي النقر على زر "تحديث الروابط" إلى تغيير حجم وإعادة وضع إطار كائن OLE لأن PowerPoint يحدث البيانات من الكائن OLE المرتبط ويجدد المعاينة. لمنع PowerPoint من المطالبة بتحديث بيانات الكائن، قم بتعيين طريقة `setUpdateAutomatic` الخاصة بواجهة [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/) إلى `false`:

```java
oleObjectFrame.setUpdateAutomatic(false);
```

## استخراج الملفات المضمنة

يسمح Aspose.Slides لـ Java باستخراج الملفات المضمنة في الشرائح ككائنات OLE بهذه الطريقة:

1. أنشئ مثيلًا من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) يحتوي على كائن OLE الذي تنوي استخراجه.
2. اجعل حلقة عبر جميع الأشكال في العرض التقديمي والوصول إلى شكل [OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe).
3. الوصول إلى بيانات الملف المضمن من إطار كائن OLE وكتابته إلى القرص. 

يوضح لك هذا الكود Java كيفية استخراج ملف مضمن في شريحة ككائن OLE:

```java
Presentation pres = new Presentation("embeddedOle.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    for (int index = 0; index < slide.getShapes().size(); index++)
    {
        IShape shape = slide.getShapes().get_Item(index);
        IOleObjectFrame oleFrame = (IOleObjectFrame)shape;

        if (oleFrame != null) 
		{
            byte[] data = oleFrame.getEmbeddedData().getEmbeddedFileData();
            String extension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

            // حفظ البيانات المستخرجة
            FileOutputStream fstr = new FileOutputStream("oleFrame" + index + extension);
            try {
                fstr.write(data, 0, data.length);
            } finally {
                fstr.close();
            }
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```