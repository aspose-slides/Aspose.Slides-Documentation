---
title: إدارة OLE
type: docs
weight: 40
url: /androidjava/manage-ole/
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
- أندرويد
- جافا
- Aspose.Slides لـ Android عبر Java
description: إضافة كائنات OLE إلى عروض PowerPoint التقديمية في جافا
---

{{% alert color="primary" %}} 

OLE (ربط الكائنات وتضمينها) هي تقنية من مايكروسوفت تتيح وضع البيانات والكائنات الم created in one application to be placed in another application through linking or embedding. 

{{% /alert %}} 

افترض وجود مخطط تم إنشاؤه في MS Excel. ثم يتم وضع المخطط داخل شريحة PowerPoint. يُعتبر هذا المخطط من Excel كائن OLE.

- قد يظهر كائن OLE كأيقونة. في هذه الحالة، عند النقر المزدوج على الأيقونة، سيتم فتح المخطط في التطبيق المرتبط به (Excel)، أو يُطلب منك اختيار تطبيق لفتح أو تحرير الكائن.
- قد يعرض كائن OLE محتويات فعلية - على سبيل المثال، محتويات مخطط. في هذه الحالة، يتم تنشيط المخطط في PowerPoint وتحميل واجهة المخطط، ويمكنك تعديل بيانات المخطط داخل تطبيق PowerPoint.

[Aspose.Slides لـ Android عبر Java](https://products.aspose.com/slides/androidjava/) يسمح لك بإدراج كائنات OLE في الشرائح كأطر كائن OLE ([OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)).

## **إضافة أطر كائن OLE إلى الشرائح**
افترض أنك قد أنشأت مخططًا بالفعل في Microsoft Excel وتريد تضمين هذا المخطط في شريحة كإطار كائن OLE باستخدام Aspose.Slides لـ Android عبر Java، يمكنك القيام بذلك بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. احصل على مرجع الشريحة باستخدام فهرسها.
1. افتح ملف Excel الذي يحتوي على كائن المخطط واحفظه في `MemoryStream`.
1. أضف [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) إلى الشريحة مع مصفوفة البايتات ومعلومات أخرى حول كائن OLE.
1. اكتب العرض المعدل كملف PPTX.

في المثال أدناه، أضفنا مخططًا من ملف Excel إلى شريحة كإطار كائن OLE باستخدام Aspose.Slides لـ Android عبر Java.
**ملاحظة** أن المُنشئ [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IOleEmbeddedDataInfo) يأخذ امتداد كائن قابل للتضمين كمعامل ثانٍ. يتيح هذا الامتداد لـ PowerPoint فهم نوع الملف بشكل صحيح واختيار التطبيق المناسب لفتح هذا الكائن OLE.

``` java 
// إنشاء كائن من فئة Presentation الذي يمثل ملف PPTX
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // تحميل ملف Excel إلى التدفق
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

    // إنشاء كائن بيانات للتضمين
    IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(mstream.toByteArray(), "xlsx");
    mstream.close();

    // إضافة شكل إطار كائن Ole
    IOleObjectFrame oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0,
            (float) pres.getSlideSize().getSize().getWidth(),
            (float) pres.getSlideSize().getSize().getHeight(),
            dataInfo);

    // كتابة ملف PPTX إلى القرص
    pres.save("OleEmbed_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **الوصول إلى أطر كائن OLE**
إذا كان كائن OLE موجودًا بالفعل في شريحة، يمكنك العثور على هذا الكائن أو الوصول إليه بسهولة بهذه الطريقة:

1. أنشئ مثيلًا من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. احصل على مرجع الشريحة باستخدام فهرسها.
1. الوصول إلى شكل إطار كائن OLE.

   في مثالنا، استخدمنا ملف PPTX الذي تم إنشاؤه سابقًا، والذي يحتوي على شكل واحد فقط على الشريحة الأولى. ثم قمنا *بالإشارة* إلى ذلك الكائن كـ [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame). كان هذا هو إطار كائن OLE المطلوب الوصول إليه.
1. بمجرد الوصول إلى إطار كائن OLE، يمكنك إجراء أي عملية عليه.

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن مخطط Excel المضمن في شريحة) - ثم يتم كتابة بيانات ملفه إلى ملف Excel.

``` java 
// تحميل ال PPTX إلى كائن Presentation
Presentation pres = new Presentation("AccessingOLEObjectFrame.pptx");
try {
    // الوصول إلى الشريحة الأولى
    ISlide sld = pres.getSlides().get_Item(0);

    // تحويل الشكل إلى OleObjectFrame
    OleObjectFrame oleObjectFrame = (OleObjectFrame) sld.getShapes().get_Item(0);

    // قراءة كائن OLE وكتابته إلى القرص
    if (oleObjectFrame != null) {
        // الحصول على بيانات الملف المضمنة
        byte[] data = oleObjectFrame.getEmbeddedData().getEmbeddedFileData();

        // الحصول على امتداد الملف المضمن
        String fileExtention = oleObjectFrame.getEmbeddedData().getEmbeddedFileExtension();

        // إنشاء مسار لحفظ الملف المستخرج
        String extractedPath = "excelFromOLE_out" + fileExtention;

        // حفظ البيانات المستخرجة
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

إذا كان كائن OLE موجودًا بالفعل في شريحة، يمكنك الوصول إلى هذا الكائن وتعديل بياناته بسهولة بهذه الطريقة:

1. افتح العرض التقديمي المطلوب الذي يحتوي على كائن OLE المضمن عن طريق إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. احصل على مرجع الشريحة من خلال فهرسها. 
1. الوصول إلى شكل إطار كائن OLE.

   في مثالنا، استخدمنا ملف PPTX الذي تم إنشاؤه سابقًا والذي يحتوي على شكل واحد فقط في الشريحة الأولى. ثم قمنا *بالإشارة* إلى ذلك الكائن كـ [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame). كان هذا هو إطار كائن OLE المطلوب الوصول إليه.
1. بمجرد الوصول إلى إطار كائن OLE، يمكنك إجراء أي عملية عليه.
1. إنشاء كائن Workbook والوصول إلى بيانات OLE.
1. الوصول إلى ورقة العمل المطلوبة وتعديل البيانات.
1. حفظ Workbook المحدث في التدفقات.
1. تغيير بيانات كائن OLE من بيانات التدفق.

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن مخطط Excel المضمن في شريحة) - ثم يتم تعديل بيانات ملفه لتغيير بيانات المخطط:

``` java 
Presentation pres = new Presentation("ChangeOLEObjectData.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
	
    OleObjectFrame ole = null;

    // البحث بين جميع الأشكال عن إطار Ole
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
            // قراءة بيانات الكائن في Workbook
            Workbook Wb = new Workbook(msln);

            ByteArrayOutputStream msout = new ByteArrayOutputStream();
            try {
                // تعديل بيانات Workbook
                Wb.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
                Wb.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
                Wb.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
                Wb.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

                OoxmlSaveOptions so1 = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
                Wb.save(msout, so1);

                // تغيير بيانات كائن إطار Ole
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

بخلاف مخططات Excel، يتيح لك Aspose.Slides لـ Android عبر Java تضمين أنواع أخرى من الملفات في الشرائح. على سبيل المثال، يمكنك إدراج ملفات HTML و PDF و ZIP ككائنات في الشريحة. عندما ينقر المستخدم مرتين على الكائن المضاف، يتم إطلاق الكائن تلقائيًا في البرنامج المناسب، أو يُوجه المستخدم لاختيار البرنامج المناسب لفتح الكائن.

يظهر لك هذا الكود البرمجي في جافا كيفية تضمين HTML و ZIP في شريحة:

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

عند العمل على العروض التقديمية، قد تحتاج إلى استبدال كائنات OLE القديمة بأخرى جديدة. أو قد تحتاج إلى استبدال كائن OLE غير المدعوم بآخر مدعوم.

يتيح لك Aspose.Slides لـ Android عبر Java تعيين نوع الملف للكائن المضمن. بهذه الطريقة، يمكنك تغيير بيانات إطار OLE أو امتداده.

يظهر لك هذا الجزء من جافا كيفية تعيين نوع الملف لكائن OLE المضمن:

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

## تعيين صور أيقونات وعناوين للكائنات المضمنة

بعد تضمين كائن OLE، يتم إضافة معاينة تتكون من صورة أيقونة وعنوان تلقائيًا. المعاينة هي ما يراه المستخدمون قبل الوصول إلى كائن OLE أو فتحه. 

إذا كنت ترغب في استخدام صورة معينة ونص كعناصر في المعاينة، يمكنك تعيين صورة الأيقونة والعنوان باستخدام Aspose.Slides لـ Android عبر Java.

يظهر لك هذا الكود البرمجي في جافا كيفية تعيين صورة الأيقونة والعنوان لكائن مضمن: 

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

## **منع تغيير حجم إطار كائن OLE وإعادة وضعه**

بعد إضافة كائن OLE مرتبط إلى شريحة العرض التقديمي، عند فتح العرض التقديمي في PowerPoint، قد ترى رسالة تطلب منك تحديث الروابط. قد يؤدي النقر على زر "تحديث الروابط" إلى تغيير حجم وإعادة وضع إطار كائن OLE لأن PowerPoint يحدث البيانات من كائن OLE المرتبط ويجدد صورة المعاينة للكائن. لمنع PowerPoint من المطالبة بتحديث بيانات الكائن، قم بتعيين طريقة `setUpdateAutomatic` من واجهة [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) إلى `false`:

```java
oleObjectFrame.setUpdateAutomatic(false);
```

## استخراج الملفات المضمنة

يتيح لك Aspose.Slides لـ Android عبر Java استخراج الملفات المضمنة في الشرائح ككائنات OLE بهذه الطريقة:

1. أنشئ مثيلًا من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) التي تحتوي على كائن OLE الذي تنوي استخراجه.
2. كرر عبر جميع الأشكال في العرض التقديمي والوصول إلى شكل [OLEObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleobjectframe).
3. الوصول إلى بيانات الملف المضمن من إطار كائن OLE واكتبها على القرص. 

يوضح لك هذا الكود البرمجي في جافا كيفية استخراج ملف مضمن في شريحة ككائن OLE:

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