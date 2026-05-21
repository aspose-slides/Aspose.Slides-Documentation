---
title: إدارة BLOB للعرض التقديمي على Android لاستخدام الذاكرة بكفاءة
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
description: "إدارة بيانات BLOB في Aspose.Slides لنظام Android عبر Java لتبسيط عمليات ملفات PowerPoint وOpenDocument من أجل معالجة عروض تقديمية فعّالة."
---
## **حول BLOB**

**BLOB** (**Binary Large Object**) عادةً ما يكون عنصرًا كبيرًا (صورة، عرض تقديمي، مستند، أو وسائط) يتم حفظه بتنسيقات ثنائية. 

تسمح لك Aspose.Slides for Android عبر Java باستخدام BLOBs للكائنات بطريقة تقلل من استهلاك الذاكرة عندما تكون الملفات كبيرة.

{{% alert title="Info" color="info" %}}
لتجاوز بعض القيود عند التعامل مع التدفقات، قد تقوم Aspose.Slides بنسخ محتوى التدفق. سيؤدي تحميل عرض تقديمي كبير عبر تدفقه إلى نسخ محتويات العرض وتسبب بطءً في التحميل. لذا، عندما تنوي تحميل عرض تقديمي كبير، نوصيك بشدة باستخدام مسار ملف العرض بدلاً من التدفق.
{{% /alert %}}

## **استخدام BLOB لتقليل استهلاك الذاكرة**

### **إضافة ملف كبير عبر BLOB إلى عرض تقديمي**

[Aspose.Slides](/slides/ar/androidjava/) for Java يتيح لك إضافة ملفات كبيرة (في هذه الحالة، ملف فيديو كبير) من خلال عملية تتضمن BLOBs لتقليل استهلاك الذاكرة.

يعرض لك هذا المثال بلغة Java كيفية إضافة ملف فيديو كبير عبر عملية BLOB إلى عرض تقديمي:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// يقوم بإنشاء عرض تقديمي جديد سيتم إضافة الفيديو إليه
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // لنقم بإضافة الفيديو إلى العرض التقديمي - اخترنا سلوك KeepLocked لأننا
        // لا نعتزم الوصول إلى ملف "veryLargeVideo.avi".
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // يحفظ العرض التقديمي. أثناء إخراج عرض تقديمي كبير، يظل استهلاك الذاكرة
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

### **تصدير ملف كبير عبر BLOB من عرض تقديمي**
Aspose.Slides for Android عبر Java يتيح لك تصدير ملفات كبيرة (في هذه الحالة، ملف صوت أو فيديو) من العروض التقديمية عبر عملية تتضمن BLOBs. على سبيل المثال، قد تحتاج إلى استخراج ملف وسائط كبير من عرض تقديمي ولكن لا تريد تحميل الملف إلى ذاكرة جهاز الكمبيوتر الخاص بك. من خلال تصدير الملف عبر عملية BLOB، تتمكن من الحفاظ على استهلاك الذاكرة منخفضًا.

هذا الكود بلغة Java يوضح العملية الموضحة:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// يقفل ملف المصدر ولا يقوم بتحميله إلى الذاكرة
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// إنشاء نسخة من الـ Presentation، وقفل ملف "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // لنقوم بحفظ كل فيديو في ملف. لمنع استهلاك عالي للذاكرة، نحتاج إلى المخزن المؤقت الذي سيُستخدم
    // لنقل البيانات من تدفق فيديو العرض التقديمي إلى تدفق لملف فيديو تم إنشاؤه حديثًا.
    byte[] buffer = new byte[8 * 1024];

    // يتنقل عبر مقاطع الفيديو
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // يفتح تدفق فيديو العرض التقديمي. يرجى ملاحظة أننا تجنبنا عمدًا الوصول إلى الخصائص
        // مثل video.BinaryData - لأن هذه الخاصية تُعيد مصفوفة بايت تحتوي على الفيديو بالكامل، مما
        // يتسبب بتحميل البايتات إلى الذاكرة. نستخدم video.GetStream، التي تُعيد Stream - ولا تقوم
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

### **إضافة صورة كـ BLOB في عرض تقديمي**
باستخدام الأساليب من واجهة [**IImageCollection**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IImageCollection) والفئة [**ImageCollection** ](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ImageCollection)، يمكنك إضافة صورة كبيرة كـ stream لتُعامل كـ BLOB.

هذا الكود بلغة Java يوضح لك كيفية إضافة صورة كبيرة عبر عملية BLOB:

```java
String pathToLargeImage = "large_image.jpg";

// ينشئ عرض تقديمي جديد سيتم إضافة الصورة إليه.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// لنضيف الصورة إلى العرض التقديمي - نختار سلوك KeepLocked لأننا
		// لا نعتزم الوصول إلى ملف "largeImage.png".
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// يحفظ العرض التقديمي. أثناء إخراج عرض تقديمي كبير، يظل استهلاك الذاكرة
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

عادةً، لتحميل عرض تقديمي كبير، تحتاج الحواسيب إلى الكثير من الذاكرة المؤقتة. يتم تحميل جميع محتويات العرض إلى الذاكرة ويتوقف استخدام الملف (الذي تم تحميل العرض منه).

تخيل عرض تقديمي PowerPoint كبير (large.pptx) يحتوي على ملف فيديو بحجم 1.5 جيجابايت. الطريقة القياسية لتحميل العرض موصوفة في هذا الكود بلغة Java:

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
من خلال العملية التي تتضمن BLOB، يمكنك تحميل عرض تقديمي كبير مع استخدام قليل من الذاكرة. يوضح هذا الكود بلغة Java التنفيذ حيث يتم استخدام عملية BLOB لتحميل ملف عرض تقديمي كبير (large.pptx):

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
عند استخدام عملية BLOB، يقوم جهازك بإنشاء ملفات مؤقتة في المجلد الافتراضي للملفات المؤقتة. إذا رغبت في حفظ الملفات المؤقتة في مجلد مختلف، يمكنك تغيير إعدادات التخزين باستخدام `TempFilesRootPath`:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
عند استخدام `TempFilesRootPath`، لا تقوم Aspose.Slides بإنشاء مجلد تلقائيًا لتخزين الملفات المؤقتة. يجب عليك إنشاء المجلد يدويًا. 
{{% /alert %}}

### **التخلص من كائنات العرض لتحرير الذاكرة**
عند معالجة العروض التقديمية الكبيرة، تأكد من أن كائن [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) يتم إتلافه بشكل صحيح حتى يتم تحرير الذاكرة التي كان يشغلها. استدعِ `dispose()` بعد الانتهاء من استخدام العرض لتحرير الموارد غير المدارة.

```java
Presentation presentation = new Presentation("large.pptx");

// ...معالجة العرض التقديمي...
presentation.save("large.pdf", SaveFormat.Pdf);

// تحرير الموارد بشكل صريح.
presentation.dispose();
```

## **الأسئلة الشائعة**

**ما هي البيانات في عرض Aspose.Slides التي تُعامل كـ BLOB وتُتحكم بها خيارات BLOB؟**

تُعامل الكائنات الثنائية الكبيرة مثل الصور، الصوت، والفيديو كـ BLOB. كما يتضمن ملف العرض بالكامل معالجة BLOB عند تحميله أو حفظه. تُحكم هذه الكائنات بواسطة سياسات BLOB التي تتيح لك إدارة استهلاك الذاكرة وتحويل البيانات إلى ملفات مؤقتة عند الحاجة.

**أين يمكنني تكوين قواعد معالجة BLOB أثناء تحميل العرض التقديمي؟**

استخدم [LoadOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/loadoptions/) مع [BlobManagementOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/blobmanagementoptions/). هناك يمكنك تحديد حد الذاكرة الداخلية لـ BLOB، السماح أو منع الملفات المؤقتة، اختيار المسار الجذر للملفات المؤقتة، وتحديد سلوك قفل المصدر.

**هل تؤثر إعدادات BLOB على الأداء، وكيف يمكن موازنة السرعة مقابل الذاكرة؟**

نعم. الحفاظ على BLOB في الذاكرة يزيد من السرعة لكنه يرفع استهلاك RAM؛ خفض حد الذاكرة يوجه المزيد من العمل إلى الملفات المؤقتة، مما يقلل من RAM بتكلفة زيادة عمليات الإدخال/الإخراج. استخدم طريقة [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) لتحقيق التوازن المناسب بين الأداء واحتياجات الذاكرة.

**هل تساعد خيارات BLOB عند فتح عروض تقديمية ضخمة جدًا (مثلاً بالجيجابايت)؟**

نعم. تم تصميم [BlobManagementOptions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/blobmanagementoptions/) لهذه الحالات: تمكين الملفات المؤقتة واستخدام قفل المصدر يمكن أن يقلل بشكل كبير من استهلاك RAM عند الذروة ويُثبت عملية المعالجة للعروض الكبيرة جدًا.

**هل يمكنني استخدام سياسات BLOB عند التحميل من التدفقات بدلاً من ملفات القرص؟**

نعم. تُطبق القواعد نفسها على التدفقات: يمكن لكائن العرض امتلاك وتقييد تدفق الإدخال (حسب وضع القفل المختار)، وتُستخدم الملفات المؤقتة عندما يُسمح بذلك، مما يحافظ على توقع استهلاك الذاكرة أثناء المعالجة.