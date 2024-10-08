---
title: إدارة Blob
type: docs
weight: 10
url: /ar/androidjava/manage-blob/
description: إدارة Blob في عرض PowerPoint باستخدام Java. استخدم Blob لتقليل استهلاك الذاكرة في عرض PowerPoint باستخدام Java. أضف ملفًا كبيرًا من خلال Blob إلى عرض PowerPoint باستخدام Java. قم بتصدير ملف كبير من خلال Blob من عرض PowerPoint باستخدام Java. قم بتحميل عرض PowerPoint كبير كـ Blob باستخدام Java.
---

## **حول BLOB**

**BLOB** (**كائن ثنائي كبير**) عادةً ما يكون عنصرًا كبيرًا (صورة، عرض تقديمي، مستند، أو وسائط) محفوظًا في تنسيقات ثنائية.

تسمح لك Aspose.Slides لـ Android عبر Java باستخدام BLOBs للأغراض بطريقة تقلل من استهلاك الذاكرة عند التعامل مع ملفات كبيرة.

{{% alert title="معلومات" color="info" %}}

للتغلب على بعض القيود عند التفاعل مع التدفقات، قد تقوم Aspose.Slides بنسخ محتوى التدفق. سيؤدي تحميل عرض تقديمي كبير من خلال تدفقه إلى نسخ محتويات العرض التقديمي وتسبب في بطء التحميل. لذلك، عندما تنوي تحميل عرض تقديمي كبير، نوصي بشدة باستخدام مسار ملف العرض التقديمي وليس تدفقه.

{{% /alert %}}

## **استخدام BLOB لتقليل استهلاك الذاكرة**

### **إضافة ملف كبير من خلال BLOB إلى عرض تقديمي**

تسمح لك [Aspose.Slides](/slides/ar/androidjava/) لـ Java بإضافة ملفات كبيرة (في هذه الحالة، ملف فيديو كبير) من خلال عملية تتضمن BLOBs لتقليل استهلاك الذاكرة.

يظهر هذا الكود بلغة Java كيفية إضافة ملف فيديو كبير من خلال عملية BLOB إلى عرض تقديمي:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// إنشاء عرض تقديمي جديد سيتم إضافة الفيديو إليه
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // دعنا نضيف الفيديو إلى العرض التقديمي - اخترنا سلوك KeepLocked لأننا لا نعتزم
        // الوصول إلى ملف "veryLargeVideo.avi".
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // حفظ العرض التقديمي. بينما يتم إنتاج عرض تقديمي كبير، يبقى استهلاك الذاكرة
        // منخفضًا خلال دورة حياة كائن pres 
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


### **تصدير ملف كبير من خلال BLOB من عرض تقديمي**
تسمح لك Aspose.Slides لـ Android عبر Java بتصدير ملفات كبيرة (في هذه الحالة، ملف صوتي أو فيديو) من خلال عملية تتضمن BLOBs من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج ملف وسائط كبير من عرض تقديمي ولكن لا ترغب في تحميل الملف في ذاكرة جهاز الكمبيوتر الخاص بك. من خلال تصدير الملف عبر عملية BLOB، يمكنك الحفاظ على استهلاك الذاكرة منخفضًا.

يوضح هذا الكود بلغة Java العملية الموصوفة:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// يقوم بقفل الملف المصدر ولا يحمل إلى الذاكرة
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// إنشاء مثيل لعرض التقديم، قفل ملف "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // دعنا نحفظ كل فيديو إلى ملف. لتجنب استخدام عالٍ للذاكرة، نحتاج إلى مخزن مؤقت سيتم استخدامه
    // لنقل البيانات من تدفق فيديو العرض التقديمي إلى تدفق لملف فيديو تم إنشاؤه حديثًا.
    byte[] buffer = new byte[8 * 1024];

    // يتكرر عبر الفيديوهات
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // فتح تدفق فيديو العرض التقديمي. يرجى ملاحظة أننا تجنبنا عن عمد الوصول إلى الخصائص
        // مثل video.BinaryData - لأن هذه الخاصية تعيد مصفوفة بايت تحتوي على فيديو كامل، مما يؤدي بعد ذلك
        // إلى تحميل البايتات في الذاكرة. نستخدم video.GetStream، الذي سيرجع Stream - ولا يتطلب
        // تحميل الفيديو بالكامل في الذاكرة.
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
        // سيبقى استهلاك الذاكرة منخفضًا بصرف النظر عن حجم الفيديو أو العرض التقديمي.
    }
    // إذا لزم الأمر، يمكنك تطبيق نفس الخطوات لملفات الصوت. 
} catch (IOException e) {
} finally {
    pres.dispose();
}

```

### **إضافة صورة كـ BLOB في عرض تقديمي**
باستخدام طرق من واجهة [**IImageCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) وفئة [**ImageCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ImageCollection)، يمكنك إضافة صورة كبيرة كتيار لتحصل على معاملتها كـ BLOB.

يعرض هذا الكود بلغة Java كيفية إضافة صورة كبيرة عبر عملية BLOB:

```java
String pathToLargeImage = "large_image.jpg";

// إنشاء عرض تقديمي جديد سيتم إضافة الصورة إليه.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// دعنا نضيف الصورة إلى العرض التقديمي - اخترنا سلوك KeepLocked لأننا لا نعتزم
		// الوصول إلى ملف "largeImage.png".
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// حفظ العرض التقديمي. بينما يتم إنتاج عرض تقديمي كبير، يبقى استهلاك الذاكرة
		// منخفضًا خلال دورة حياة كائن pres
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

عادةً، لتحميل عرض تقديمي كبير، تتطلب أجهزة الكمبيوتر الكثير من الذاكرة المؤقتة. يتم تحميل محتويات العرض التقديمي بالكامل في الذاكرة ويتوقف استخدام الملف (الذي تم تحميل العرض التقديمي منه).

اعتبر عرض PowerPoint كبير (large.pptx) يحتوي على ملف فيديو بحجم 1.5 جيجا بايت. يتم وصف الطريقة القياسية لتحميل العرض التقديمي في هذا الكود بلغة Java:

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

لكن هذه الطريقة تستهلك حوالي 1.6 جيجا بايت من الذاكرة المؤقتة.

### **تحميل عرض تقديمي كبير كـ BLOB**

من خلال عملية تشمل BLOB، يمكنك تحميل عرض تقديمي كبير مع استخدام ذاكرة قليلة. يصف كود Java هذا التنفيذ حيث يتم استخدام عملية BLOB لتحميل ملف عرض تقديمي كبير (large.pptx):

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

عند استخدام عملية BLOB، يقوم جهاز الكمبيوتر الخاص بك بإنشاء ملفات مؤقتة في المجلد الافتراضي للملفات المؤقتة. إذا كنت ترغب في أن يتم الاحتفاظ بالملفات المؤقتة في مجلد مختلف، يمكنك تغيير إعدادات التخزين باستخدام `TempFilesRootPath`:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="معلومات" color="info" %}}

عند استخدام `TempFilesRootPath`، لا تقوم Aspose.Slides بإنشاء مجلد تلقائيًا لتخزين الملفات المؤقتة. يجب عليك إنشاء المجلد يدويًا.

{{% /alert %}}