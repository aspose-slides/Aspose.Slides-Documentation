---
title: إدارة كائنات BLOB للعرض التقديمي في Java لاستخدام فعال للذاكرة
linktitle: إدارة BLOB
type: docs
weight: 10
url: /ar/java/manage-blob/
keywords:
- كائن كبير
- عنصر كبير
- ملف كبير
- إضافة BLOB
- تصدير BLOB
- إضافة صورة كـ BLOB
- تقليل الذاكرة
- استهلاك الذاكرة
- عرض تقديمي كبير
- ملف مؤقت
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "إدارة بيانات BLOB في Aspose.Slides لـ Java لتبسيط عمليات ملفات PowerPoint و OpenDocument لتحسين معالجة العروض التقديمية."
---

## **حول BLOB**

**BLOB** (**Binary Large Object**) عادةً ما يكون عنصرًا كبيرًا (صورة، عرض تقديمي، مستند، أو وسائط) يُحفظ بصيغ ثنائية. 

Aspose.Slides for Java يتيح لك استخدام BLOBs للكائنات بطريقة تقلل استهلاك الذاكرة عندما تكون الملفات كبيرة. 

{{% alert title="Info" color="info" %}}
لتجاوز بعض القيود عند التفاعل مع التدفقات، قد يقوم Aspose.Slides بنسخ محتوى التدفق. تحميل عرض تقديمي كبير عبر تدفقه سيؤدي إلى نسخ محتويات العرض وبالتالي بطء التحميل. لذلك، عندما تنوي تحميل عرض تقديمي كبير، نوصي بشدة باستخدام مسار ملف العرض وليس تدفقه.
{{% /alert %}}

## **استخدام BLOB لتقليل استهلاك الذاكرة**

### **إضافة ملف كبير عبر BLOB إلى عرض تقديمي**

[Aspose.Slides](/slides/ar/java/) for Java يتيح لك إضافة ملفات كبيرة (في هذه الحالة ملف فيديو كبير) عبر عملية تتضمن BLOBs لتقليل استهلاك الذاكرة.

هذا المثال في Java يوضح كيفية إضافة ملف فيديو كبير عبر عملية BLOB إلى عرض تقديمي:
```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// ينشئ عرضًا تقديميًا جديدًا سيتم إضافة الفيديو إليه
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // لنضيف الفيديو إلى العرض التقديمي - اخترنا سلوك KeepLocked لأننا لا
        // ننوي الوصول إلى ملف "veryLargeVideo.avi".
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // يحفظ العرض التقديمي. بينما يتم إخراج عرض تقديمي كبير، يبقى استهلاك الذاكرة
        // منخفضًا طوال دورة حياة كائن pres
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


### **تصدير ملف كبير عبر BLOB من العرض التقديمي**

Aspose.Slides for Java يتيح لك تصدير ملفات كبيرة (في هذه الحالة ملف صوت أو فيديو) عبر عملية تتضمن BLOBs من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج ملف وسائط كبير من عرض تقديمي ولكن لا تريد تحميله إلى ذاكرة جهازك. عبر تصدير الملف عبر عملية BLOB، تحافظ على انخفاض استهلاك الذاكرة. 

هذا الكود في Java يوضح العملية الموصوفة:
```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// يقفل ملف المصدر ولا يقوم بتحميله إلى الذاكرة
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// إنشاء مثيل Presentation، وقفل ملف "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // لنحفظ كل فيديو في ملف. لمنع استهلاك عالي للذاكرة، نحتاج إلى مخزن مؤقت سيُستخدم
    // لنقل البيانات من تدفق فيديو العرض إلى تدفق لملف فيديو تم إنشاؤه حديثًا.
    byte[] buffer = new byte[8 * 1024];

    // يتنقل عبر مقاطع الفيديو
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // يفتح تدفق فيديو العرض. يرجى ملاحظة أننا تجنبنا عمدًا الوصول إلى الخصائص
        // مثل video.BinaryData - لأن هذه الخاصية تُعيد مصفوفة بايت تحتوي على فيديو كامل، مما يؤدي إلى
        // تحميل البايتات إلى الذاكرة. نستخدم video.GetStream، الذي سيُعيد Stream - ولا يتطلب
        //  تحميل الفيديو بالكامل إلى الذاكرة.
        InputStream presVideoStream = video.getStream();
        try {
            OutputStream outputFileStream = new FileOutputStream("video" + index + ".avi");
            try {
                int bytesRead;
                while ((bytesRead = presVideoStream.read(buffer, 0, buffer.length)) > 0) {
                    outputFileStream.write(buffer, 0, bytesRead);
                }
            } finally {
                outputFileStream.close();
            }
        } finally {
            presVideoStream.close();
        }
        // سيظل استهلاك الذاكرة منخفضًا بغض النظر عن حجم الفيديو أو العرض.
    }
    // إذا لزم الأمر، يمكنك تطبيق الخطوات نفسها على ملفات الصوت. 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```


### **إضافة صورة كـ BLOB في العرض التقديمي**

باستخدام الطرق من الواجهة [**IImageCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) والفئة [**ImageCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/ImageCollection)، يمكنك إضافة صورة كبيرة كدفق لتُعامل كـ BLOB. 

هذا الكود في Java يوضح كيفية إضافة صورة كبيرة عبر عملية BLOB:
```java
String pathToLargeImage = "large_image.jpg";

// ينشئ عرضًا تقديميًا جديدًا سيتم إضافة الصورة إليه.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// لنضيف الصورة إلى العرض التقديمي - نختار سلوك KeepLocked لأننا
		// لا ننوي الوصول إلى ملف "largeImage.png".
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// يحفظ العرض التقديمي. بينما يتم إخراج عرض تقديمي كبير، استهلاك الذاكرة
		// يبقى منخفضًا طوال دورة حياة كائن pres
		pres.save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	} finally {
		if (fileStream != null) fileStream.close();
	}
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```


## **الذاكرة والعروض التقديمية الكبيرة**

عادةً، لتحميل عرض تقديمي كبير، تحتاج الحواسيب إلى الكثير من الذاكرة المؤقتة. يتم تحميل كل محتوى العرض إلى الذاكرة ويتوقف استخدام الملف (الذي تم تحميل العرض منه). 

اعتبر عرض PowerPoint كبير (large.pptx) يحتوي على ملف فيديو حجمه 1.5 جيجابايت. طريقة التحميل القياسية موضحة في هذا الكود في Java:
```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```


لكن هذه الطريقة تستهلك حوالي 1.6 جيجابايت من الذاكرة المؤقتة. 

### **تحميل عرض تقديمي كبير كـ BLOB**

من خلال عملية تتضمن BLOB، يمكنك تحميل عرض تقديمي كبير مع استخدام قليل من الذاكرة. يصف هذا الكود في Java التنفيذ حيث تُستخدم عملية BLOB لتحميل ملف عرض تقديمي كبير (large.pptx):
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);

Presentation pres = new Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```


### **تغيير المجلد للملفات المؤقتة**

عند استخدام عملية BLOB، يقوم حاسوبك بإنشاء ملفات مؤقتة في المجلد الافتراضي للملفات المؤقتة. إذا رغبت في حفظ الملفات المؤقتة في مجلد مختلف، يمكنك تغيير إعدادات التخزين باستخدام `TempFilesRootPath`:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```


{{% alert title="Info" color="info" %}}
عند استخدام `TempFilesRootPath`، لا يقوم Aspose.Slides بإنشاء مجلد تلقائيًا لتخزين الملفات المؤقتة. يجب عليك إنشاء المجلد يدويًا. 
{{% /alert %}}

## **FAQ**

**ما البيانات في عرض Aspose.Slides التي تُعامل كـ BLOB وتُتحكم فيها خيارات BLOB؟**

الكائنات الثنائية الكبيرة مثل الصور، الصوت، والفيديو تُعامل كـ BLOB. ملف العرض بالكامل أيضًا يتضمن معالجة BLOB عند تحميله أو حفظه. تُحكم هذه الكائنات بسياسات BLOB التي تسمح لك بإدارة استهلاك الذاكرة وتحويل البيانات إلى ملفات مؤقتة عند الحاجة.

**أين أُعد قواعد معالجة BLOB أثناء تحميل العرض؟**

استخدم [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) مع [BlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/). هناك يمكنك تحديد حد الذاكرة لـ BLOB، السماح أو منع الملفات المؤقتة، اختيار المسار الجذري للملفات المؤقتة، وتحديد سلوك قفل المصدر.

**هل تؤثر إعدادات BLOB على الأداء، وكيف أوازن بين السرعة والذاكرة؟**

نعم. إبقاء BLOB في الذاكرة يزيد من السرعة لكنه يرفع استهلاك RAM؛ خفض حد الذاكرة ينقل المزيد إلى الملفات المؤقتة، ما يقلل RAM ولكن يضيف مزيدًا من I/O. استخدم طريقة [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) لتحقيق التوازن المناسب لحجم عملك وبيئتك.

**هل تساعد خيارات BLOB عند فتح عروض تقديمية ضخمة جدًا (مثلاً بالجيجابايت)؟**

نعم. [BlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/) صُممت لمثل هذه السيناريوهات: تمكين الملفات المؤقتة واستخدام قفل المصدر يمكن أن يقلل بشكل كبير من استهلاك RAM القميّ ويستقر عملية المعالجة للعروض الضخمة.

**هل يمكنني استخدام سياسات BLOB عند التحميل من التدفقات بدلاً من ملفات القرص؟**

نعم. القواعد نفسها تنطبق على التدفقات: يمكن لكائن العرض امتلاك وقفل تدفق الإدخال (حسب وضع القفل المختار)، وتُستخدم الملفات المؤقتة عندما يُسمح بذلك، مما يحافظ على استهلاك الذاكرة متوقعًا أثناء المعالجة.