---
title: إدارة الـ Blob
type: docs
weight: 10
url: /ar/java/manage-blob/
description: إدارة الـ Blob في عرض PowerPoint باستخدام Java. استخدم Blob لتقليل استهلاك الذاكرة في عرض PowerPoint باستخدام Java. أضف ملفاً كبيراً من خلال Blob إلى عرض PowerPoint باستخدام Java. قم بتصدير ملف كبير من خلال Blob من عرض PowerPoint باستخدام Java. قم بتحميل عرض PowerPoint كبير كـ Blob باستخدام Java.
---

## **حول BLOB**

**BLOB** (**كائن كبير ثنائي**) هو عادةً عنصر كبير (صورة، عرض تقديمي، مستند، أو وسائط) محفوظ بصيغ ثنائية. 

تتيح لك Aspose.Slides لـ Java استخدام الـ BLOBs للأشياء بطريقة تقلل من استهلاك الذاكرة عند وجود ملفات كبيرة. 

{{% alert title="معلومات" color="info" %}}

لتجاوز بعض القيود عند التفاعل مع تدفقات البيانات، قد تقوم Aspose.Slides بنسخ محتوى التدفق. إن تحميل عرض تقديمي كبير من خلال تدفقه سيؤدي إلى نسخ محتويات العرض التقديمي ويسبب بطء التحميل. لذلك، عندما تنوي تحميل عرض تقديمي كبير، نوصي بشدة باستخدام مسار ملف العرض وليس تدفقه.

{{% /alert %}}

## **استخدم BLOB لتقليل استهلاك الذاكرة**

### **أضف ملفاً كبيراً من خلال BLOB إلى عرض تقديمي**

تتيح لك [Aspose.Slides](/slides/ar/java/) لـ Java إضافة ملفات كبيرة (في هذه الحالة، ملف فيديو كبير) من خلال عملية تتضمن الـ BLOBs لتقليل استهلاك الذاكرة.

يوضح لك هذا الكود في Java كيفية إضافة ملف فيديو كبير من خلال عملية الـ BLOB إلى عرض تقديمي:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// ينشئ عرضًا تقديميًا جديدًا سيتم إضافة الفيديو إليه
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // دعنا نضيف الفيديو إلى العرض التقديمي - لقد اخترنا سلوك KeepLocked لأننا لا نعتزم
        // الوصول إلى ملف "veryLargeVideo.avi".
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // يحفظ العرض التقديمي. بينما يتم إخراج عرض تقديمي كبير، يبقى استهلاك الذاكرة
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
تتيح لك Aspose.Slides لـ Java تصدير ملفات كبيرة (في هذه الحالة، ملف صوت أو فيديو) من خلال عملية تتضمن الـ BLOBs من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج ملف وسائط كبير من عرض تقديمي ولكن لا تريد أن يتم تحميل الملف في ذاكرة جهاز الكمبيوتر الخاص بك. من خلال تصدير الملف عبر عملية الـ BLOB، يمكنك الحفاظ على استهلاك الذاكرة منخفضًا. 

هذا الكود في Java يوضح العملية الموصوفة:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// يغلق ملف المصدر ولا يقوم بتحميله إلى الذاكرة
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// إنشاء مثيل العرض التقديمي، قفل ملف "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // دعنا نحفظ كل فيديو في ملف. لتجنب الاستخدام العالي لذاكرة الوصول العشوائي، نحتاج إلى وسادة ستحقق
    // نقل البيانات من تدفق فيديو العرض التقديمي إلى تدفق لملف الفيديو الجديد الذي تم إنشاؤه.
    byte[] buffer = new byte[8 * 1024];

    // يتصفح خلال مقاطع الفيديو
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // يفتح تدفق فيديو العرض التقديمي. يرجى ملاحظة أننا تجنبنا عن عمد الوصول إلى الخصائص
        // مثل video.BinaryData - لأن هذه الخاصية تعيد مصفوفة بايت تحتوي على فيديو كامل، مما يتسبب في
        // تحميل البايتات في الذاكرة. نحن نستخدم video.GetStream، الذي سيعيد Stream - ولا يتطلب منا
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
        // سيبقى استهلاك الذاكرة منخفضًا بغض النظر عن حجم الفيديو أو العرض التقديمي.
    }
    // إذا لزم الأمر، يمكنك تطبيق نفس الخطوات على ملفات الصوت. 
} catch (IOException e) {
} finally {
    pres.dispose();
}

```

### **أضف صورة كـ BLOB في عرض تقديمي**
مع الطرق من واجهة [**IImageCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) وفئة [**ImageCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/ImageCollection)، يمكنك إضافة صورة كبيرة كتيار لكي يتم التعامل معها كـ BLOB. 

هذا الكود في Java يوضح لك كيفية إضافة صورة كبيرة من خلال عملية الـ BLOB:

```java
String pathToLargeImage = "large_image.jpg";

// ينشئ عرضًا تقديميًا جديدًا سيتم إضافة الصورة إليه.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// دعنا نضيف الصورة إلى العرض التقديمي - اخترنا سلوك KeepLocked لأننا لا نعتزم
		// الوصول إلى ملف "largeImage.png".
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// يحفظ العرض التقديمي. بينما يتم إخراج عرض تقديمي كبير، يبقى استهلاك الذاكرة
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

عادةً، لتحميل عرض تقديمي كبير، تحتاج أجهزة الكمبيوتر إلى الكثير من الذاكرة المؤقتة. يتم تحميل محتويات العرض التقديمي بالكامل في الذاكرة ويتوقف الملف (الذي تم تحميل العرض منه) عن الاستخدام. 

افترض عرض PowerPoint كبير (large.pptx) يحتوي على ملف فيديو حجمه 1.5 غيغابايت. الطريقة القياسية لتحميل العرض التقديمي موصوفة في هذا الكود في Java:

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

لكن هذه الطريقة تستهلك حوالي 1.6 غيغابايت من الذاكرة المؤقتة. 

### **تحميل عرض تقديمي كبير كـ BLOB**

من خلال العملية التي تتضمن الـ BLOB، يمكنك تحميل عرض تقديمي كبير مع استخدام ذاكرة قليلة. هذا الكود في Java يصف التنفيذ حيث يتم استخدام عملية الـ BLOB لتحميل ملف عرض تقديمي كبير (large.pptx):

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

عند استخدام عملية الـ BLOB، يقوم جهاز الكمبيوتر الخاص بك بإنشاء ملفات مؤقتة في المجلد الافتراضي للملفات المؤقتة. إذا كنت ترغب في الاحتفاظ بالملفات المؤقتة في مجلد مختلف، يمكنك تغيير إعدادات التخزين باستخدام `TempFilesRootPath`:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="معلومات" color="info" %}}

عند استخدام `TempFilesRootPath`، لا تقوم Aspose.Slides بإنشاء مجلد تلقائيًا لتخزين الملفات المؤقتة. يجب عليك إنشاء المجلد يدويًا. 

{{% /alert %}}