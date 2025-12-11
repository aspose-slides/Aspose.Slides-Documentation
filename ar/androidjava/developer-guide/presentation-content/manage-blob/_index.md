---
title: إدارة كائنات BLOB في العروض التقديمية على Android لاستخدام فعال للذاكرة
linktitle: إدارة BLOB
type: docs
weight: 10
url: /ar/androidjava/manage-blob/
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
- Android
- Java
- Aspose.Slides
description: إدارة بيانات BLOB في Aspose.Slides لـ Android عبر Java لتسهيل عمليات ملفات PowerPoint و OpenDocument من أجل معالجة العروض التقديمية بكفاءة.
---

## **حول BLOB**

**BLOB** (**Binary Large Object**) عادةً ما يكون عنصرًا كبيرًا (صورة، عرض تقديمي، مستند أو وسائط) يتم حفظه بصيغ ثنائية.

يسمح Aspose.Slides for Android عبر Java لك باستخدام BLOBs للكائنات بطريقة تقلل من استهلاك الذاكرة عندما تكون الملفات كبيرة.

{{% alert title="Info" color="info" %}}
لتجاوز بعض القيود عند التعامل مع التدفقات، قد تقوم Aspose.Slides بنسخ محتوى التدفق. سيؤدي تحميل عرض تقديمي كبير عبر التدفق إلى نسخ محتوى العرض وتسبب بطء التحميل. لذلك، عندما تنوي تحميل عرض تقديمي كبير، نوصي بشدة باستخدام مسار ملف العرض وليس التدفق.
{{% /alert %}}

## **استخدام BLOB لتقليل استهلاك الذاكرة**

### **إضافة ملف كبير عبر BLOB إلى عرض تقديمي**

يسمح [Aspose.Slides](/slides/ar/androidjava/) for Java لك بإضافة ملفات كبيرة (في هذه الحالة، ملف فيديو كبير) من خلال عملية تتضمن BLOBs لتقليل استهلاك الذاكرة.

هذا المثال في Java يوضح كيفية إضافة ملف فيديو كبير عبر عملية BLOB إلى عرض تقديمي:
```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// إنشاء عرض تقديمي جديد سيتم إضافة الفيديو إليه
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // لنضيف الفيديو إلى العرض التقديمي - اخترنا سلوك KeepLocked لأننا لا
        // لا نعتزم الوصول إلى ملف "veryLargeVideo.avi"
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // حفظ العرض التقديمي. أثناء إخراج عرض تقديمي كبير، يظل استهلاك الذاكرة
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


### **تصدير ملف كبير عبر BLOB من عرض تقديمي**

يسمح Aspose.Slides for Android عبر Java لك بتصدير ملفات كبيرة (في هذه الحالة، ملف صوت أو فيديو) من خلال عملية تتضمن BLOBs من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج ملف وسائط كبير من عرض تقديمي ولكن لا تريد تحميل الملف إلى ذاكرة الكمبيوتر. من خلال تصدير الملف عبر عملية BLOB، يمكنك الحفاظ على انخفاض استهلاك الذاكرة.

هذا الكود في Java يوضح العملية الموصوفة:
```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// يقفل ملف المصدر ولا يقوم بتحميله إلى الذاكرة
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// إنشاء كائن Presentation، قفل ملف "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // لنحفظ كل فيديو إلى ملف. لمنع استهلاك عالي للذاكرة، نحتاج إلى مخزن مؤقت سيتم استخدامه
    // لنقل البيانات من تدفق فيديو العرض إلى تدفق لملف فيديو تم إنشاؤه حديثًا.
    byte[] buffer = new byte[8 * 1024];

    // يتنقل عبر مقاطع الفيديو
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // يفتح تدفق فيديو العرض. يرجى ملاحظة أننا تجنبنا عمدًا الوصول إلى الخصائص
        // مثل video.BinaryData - لأن هذه الخاصية تُعيد مصفوفة بايت تحتوي على فيديو كامل، مما يؤدي إلى
        // تحميل البايتات إلى الذاكرة. نحن نستخدم video.GetStream، الذي سيُعيد Stream - ولا يتطلب
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
        // ستبقى استهلاك الذاكرة منخفضًا بغض النظر عن حجم الفيديو أو العرض التقديمي.
    }
    // إذا لزم الأمر، يمكنك تطبيق نفس الخطوات على ملفات الصوت. 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```


### **إضافة صورة كـ BLOB في عرض تقديمي**

باستخدام الطرق المتوفرة في واجهة [**IImageCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) والصف [**ImageCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ImageCollection)، يمكنك إضافة صورة كبيرة كتيار لتعاملها كـ BLOB.

هذا الكود في Java يوضح كيفية إضافة صورة كبيرة عبر عملية BLOB:
```java
String pathToLargeImage = "large_image.jpg";

// ينشئ عرضًا تقديميًا جديدًا سيتم إضافة الصورة إليه.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// لنضيف الصورة إلى العرض التقديمي - اخترنا سلوك KeepLocked لأننا
		// لا ننوي الوصول إلى الملف "largeImage.png".
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// يحفظ العرض التقديمي. أثناء إخراج عرض تقديمي كبير، يظل استهلاك الذاكرة
		// منخفضًا طوال دورة حياة كائن pres
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

عادةً، لتحميل عرض تقديمي كبير، تحتاج الحواسيب إلى كمية كبيرة من الذاكرة المؤقتة. يتم تحميل كل محتوى العرض إلى الذاكرة ويتوقف استخدام الملف (الذي تم تحميل العرض منه) عن العمل.

تخيل عرض PowerPoint كبير (large.pptx) يحتوي على ملف فيديو حجمه 1.5 جيجابايت. الطريقة القياسية لتحميل العرض موضحة في هذا الكود Java:
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

من خلال عملية تتضمن BLOB، يمكنك تحميل عرض تقديمي كبير مع استخدام قليل من الذاكرة. يصف هذا الكود Java التنفيذ حيث تُستخدم عملية BLOB لتحميل ملف عرض تقديمي كبير (large.pptx):
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

عند استخدام عملية BLOB، ينشئ جهازك ملفات مؤقتة في المجلد الافتراضي للملفات المؤقتة. إذا أردت حفظ الملفات المؤقتة في مجلد مختلف، يمكنك تغيير إعدادات التخزين باستخدام `TempFilesRootPath`:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```


{{% alert title="Info" color="info" %}}
عند استخدام `TempFilesRootPath`، لا يقوم Aspose.Slides بإنشاء مجلد لتخزين الملفات المؤقتة تلقائيًا. عليك إنشاء المجلد يدويًا.
{{% /alert %}}

## **الأسئلة المتكررة**

**ما هي البيانات في عرض Aspose.Slides التي يتم معالجتها كـ BLOB وتتحكم فيها خيارات BLOB؟**

الكائنات الثنائية الكبيرة مثل الصور والصوت والفيديو تُعامل كـ BLOB. كما يتم معالجة ملف العرض بالكامل كـ BLOB عند تحميله أو حفظه. تُحكم هذه الكائنات بسياسات BLOB التي تسمح لك بإدارة استخدام الذاكرة وتحويل البيانات إلى ملفات مؤقتة عند الحاجة.

**أين يمكنني تكوين قواعد معالجة BLOB أثناء تحميل العرض التقديمي؟**

استخدم [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) مع [BlobManagementOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blobmanagementoptions/). هناك يمكنك تحديد حد الذاكرة للـ BLOB، السماح أو عدم السماح بالملفات المؤقتة، اختيار مسار المجلد الجذري للملفات المؤقتة، وتحديد سلوك قفل المصدر.

**هل تؤثر إعدادات BLOB على الأداء، وكيف يمكنني موازنة السرعة مقابل الذاكرة؟**

نعم. إبقاء BLOB في الذاكرة يسرّع الأداء لكنه يزيد استهلاك RAM؛ خفض حد الذاكرة يرسل المزيد إلى الملفات المؤقتة، مما يقلل RAM لكنه يضيف عمليات I/O إضافية. استخدم الطريقة [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) لتحقيق التوازن المناسب لحجم عملك والبيئة التي تعمل فيها.

**هل تساعد خيارات BLOB عند فتح عروض تقديمية ضخمة للغاية (مثل الجيجابايت)؟**

نعم. تم تصميم [BlobManagementOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blobmanagementoptions/) لهذه السيناريوهات: تمكين الملفات المؤقتة واستخدام قفل المصدر يمكن أن يقلل بشكل كبير من أعلى استهلاك للذاكرة RAM ويجعل المعالجة أكثر استقرارًا للعروض الكبيرة جدًا.

**هل يمكنني استخدام سياسات BLOB عند التحميل من التدفقات بدلاً من ملفات القرص؟**

نعم. تنطبق القواعد نفسها على التدفقات: يمكن للعرض امتلاك قفل لتدفق الإدخال (حسب وضع القفل المختار)، وتُستخدم الملفات المؤقتة عندما يُسمح بذلك، مما يحافظ على استهلاك الذاكرة بصورة متوقعة أثناء المعالجة.