---
title: إدارة BLOBs للعرض التقديمي في Java لاستخدام الذاكرة بكفاءة
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
description: "إدارة بيانات BLOB في Aspose.Slides for Java لتبسيط عمليات ملفات PowerPoint و OpenDocument لمعالجة العروض التقديمية بكفاءة."
---

## **حول BLOB**

**BLOB** (**Binary Large Object**) عادةً ما يكون عنصرًا كبيرًا (صورة أو عرض تقديمي أو مستند أو وسائط) يتم حفظه بصيغ ثنائية. 

Aspose.Slides for Java يسمح لك باستخدام BLOBs للكائنات بطريقة تقلل استهلاك الذاكرة عندما تكون الملفات الكبيرة متضمنة. 

{{% alert title="Info" color="info" %}}
لتجاوز بعض القيود عند التفاعل مع التدفقات، قد يقوم Aspose.Slides بنسخ محتوى التدفق. تحميل عرض تقديمي كبير عبر تدفقه سيؤدي إلى نسخ محتويات العرض التقديمي ويتسبب في بطء التحميل. لذلك، عندما تنوي تحميل عرض تقديمي كبير، نوصيك بشدة باستخدام مسار ملف العرض التقديمي وليس تدفقه.
{{% /alert %}}

## **استخدام BLOB لتقليل استهلاك الذاكرة**

### **إضافة ملف كبير عبر BLOB إلى عرض تقديمي**

[Aspose.Slides](/slides/ar/java/) for Java يسمح لك بإضافة ملفات كبيرة (في هذه الحالة ملف فيديو كبير) عبر عملية تتضمن BLOBs لتقليل استهلاك الذاكرة.

هذا المثال في Java يوضح لك كيفية إضافة ملف فيديو كبير عبر عملية BLOB إلى عرض تقديمي:
```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// إنشاء عرض تقديمي جديد سيتم إضافة الفيديو إليه
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // دعنا نضيف الفيديو إلى العرض التقديمي - اخترنا سلوك KeepLocked لأننا
        // لا نعتزم الوصول إلى الملف "veryLargeVideo.avi".
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // يحفظ العرض التقديمي. أثناء إخراج عرض تقديمي كبير، يظل استهلاك الذاكرة
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
Aspose.Slides for Java يسمح لك بتصدير ملفات كبيرة (مثل ملف صوت أو فيديو) عبر عملية تتضمن BLOBs من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج ملف وسائط كبير من عرض تقديمي ولكن لا تريد تحميل الملف إلى ذاكرة الحاسوب. عبر تصدير الملف عبر عملية BLOB، يمكنك الحفاظ على استهلاك الذاكرة منخفضًا.

يعرض هذا الكود في Java العملية الموصوفة:
```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// قفل ملف المصدر وعدم تحميله إلى الذاكرة
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// إنشاء كائن Presentation، قفل ملف "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // دعنا نقوم بحفظ كل فيديو إلى ملف. لتجنب استهلاك عالي للذاكرة، نحتاج إلى مخزن وسيستخدم
    // لنقل البيانات من تدفق الفيديو في العرض التقديمي إلى تدفق لملف فيديو تم إنشاؤه حديثًا.
    byte[] buffer = new byte[8 * 1024];

    // Iterates through the videos
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // يفتح تدفق فيديو العرض التقديمي. يرجى ملاحظة أننا تجنبنا عمدًا الوصول إلى الخصائص
        // مثل video.BinaryData - لأن هذه الخاصية تُرجع مصفوفة بايت تحتوي على فيديو كامل، مما يؤدي إلى
        // تحميل البايتات إلى الذاكرة. نستخدم video.GetStream، التي تُرجع Stream - ولا تقوم بـ
        //  تتطلب منا تحميل الفيديو بالكامل إلى الذاكرة.
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
        // سيظل استهلاك الذاكرة منخفضًا بغض النظر عن حجم الفيديو أو العرض التقديمي.
    }
    // إذا لزم الأمر، يمكنك تطبيق الخطوات نفسها على ملفات الصوت. 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```


### **إضافة صورة كـ BLOB إلى عرض تقديمي**
باستخدام الأساليب من واجهة [**IImageCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) والصف [**ImageCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/ImageCollection) يمكنك إضافة صورة كبيرة كتيار لمعالجتها كـ BLOB. 

هذا الكود في Java يوضح لك كيفية إضافة صورة كبيرة عبر عملية BLOB:
```java
String pathToLargeImage = "large_image.jpg";

// ينشئ عرضًا تقديميًا جديدًا ستُضاف إليه الصورة.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// لنضيف الصورة إلى العرض التقديمي - نختار سلوك KeepLocked لأننا
		// لا ننوي الوصول إلى ملف "largeImage.png".
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// يحفظ العرض التقديمي. أثناء إخراج عرض تقديمي كبير، استهلاك الذاكرة
		// يظل منخفضًا طوال دورة حياة كائن pres.
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

عادةً، لتحميل عرض تقديمي كبير، تحتاج الحواسيب إلى الكثير من الذاكرة المؤقتة. يتم تحميل كل محتوى العرض التقديمي في الذاكرة ويتوقف استخدام الملف (الذي تم تحميل العرض التقديمي منه).

تخيل عرض تقديمي PowerPoint كبير (large.pptx) يحتوي على ملف فيديو حجمه 1.5 غيغابايت. الطريقة القياسية لتحميل العرض التقديمي موصوفة في هذا الكود Java:
```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```


ولكن هذه الطريقة تستهلك حوالي 1.6 غيغابايت من الذاكرة المؤقتة. 

### **تحميل عرض تقديمي كبير كـ BLOB**

من خلال العملية التي تتضمن BLOB، يمكنك تحميل عرض تقديمي كبير مع استهلاك قليل للذاكرة. يصف هذا الكود Java تنفيذًا حيث يُستخدم عملية BLOB لتحميل ملف عرض تقديمي كبير (large.pptx):
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

عند استخدام عملية BLOB، يقوم الحاسوب بإنشاء ملفات مؤقتة في المجلد الافتراضي للملفات المؤقتة. إذا رغبت في حفظ الملفات المؤقتة في مجلد مختلف، يمكنك تعديل إعدادات التخزين باستخدام `TempFilesRootPath`:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```


{{% alert title="Info" color="info" %}}
عند استخدام `TempFilesRootPath`، لا يقوم Aspose.Slides بإنشاء مجلد تلقائيًا لتخزين الملفات المؤقتة. عليك إنشاء المجلد يدويًا. 
{{% /alert %}}

## **الأسئلة المتداولة**

**ما هي البيانات في عرض Aspose.Slides التي تُعامل كـ BLOB وتُتحكم بها خيارات BLOB؟**

الكائنات الثنائية الكبيرة مثل الصور، الصوت، والفيديو تُعامل كـ BLOB. كما يتضمن ملف العرض التقديمي بالكامل معالجة BLOB عند تحميله أو حفظه. تُحكم هذه الكائنات بسياسات BLOB التي تسمح لك بإدارة استهلاك الذاكرة وتحويل البيانات إلى ملفات مؤقتة عند الحاجة.

**أين أقوم بإعداد قواعد معالجة BLOB أثناء تحميل العرض التقديمي؟**

استخدم [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) مع [BlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/). هناك يمكنك تحديد الحد الأقصى للذاكرة المستخدمة لـ BLOB، السماح أو عدم السماح بالملفات المؤقتة، اختيار مسار الجذر للملفات المؤقتة، وتحديد سلوك قفل المصدر.

**هل تؤثر إعدادات BLOB على الأداء، وكيف أوازن بين السرعة والذاكرة؟**

نعم. إبقاء BLOB في الذاكرة يزيد من السرعة لكنه يرفع استهلاك RAM؛ خفض الحد المسموح للذاكرة يوجه المزيد من العمل إلى الملفات المؤقتة، مما يقلل RAM لكن يزيد من عمليات الإدخال/الإخراج. استخدم الطريقة [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) لتحقيق التوازن المناسب لحِملك وبيئتك.

**هل تساعد خيارات BLOB عند فتح عروض تقديمية ضخمة جدًا (مثلاً بغيغابايت)؟**

نعم. تم تصميم [BlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/) لهذه السيناريوهات: تمكين الملفات المؤقتة واستخدام قفل المصدر يمكن أن يقلل بشكل كبير من استهلاك RAM القصوى ويثبّث عملية المعالجة لعروض تقديمية ضخمة جدًا.

**هل يمكنني استخدام سياسات BLOB عند التحميل من التدفقات بدلاً من ملفات القرص؟**

نعم. نفس القواعد تنطبق على التدفقات: يمكن لكائن العرض التقديمي امتلاك القفل على تدفق الإدخال (حسب وضع القفل المختار)، وتُستخدم الملفات المؤقتة عندما يُسمح بها، مما يحافظ على استهلاك الذاكرة متوقعًا أثناء المعالجة.