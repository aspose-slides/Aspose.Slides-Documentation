---
title: إدارة BLOBs في العروض التقديمية بجافا لاستخدام فعال للذاكرة
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
description: "إدارة بيانات BLOB في Aspose.Slides لجافا لتبسيط عمليات ملفات PowerPoint وOpenDocument لتحسين معالجة العروض التقديمية."
---
## **نظرة عامة**

توفر Aspose.Slides معالجة تعتمد على BLOB للبيانات الثنائية الكبيرة في العروض التقديمية للمساعدة في تقليل استهلاك الذاكرة عند التعامل مع الصور الكبيرة، والصوت، والفيديو، وملفات العروض التقديمية.

توضح هذه المقالة كيفية استخدام المعالجة القائمة على BLOB لإضافة وسائط كبيرة إلى عرض تقديمي، وتصدير وسائط كبيرة من عرض تقديمي، وتحميل عروض تقديمية كبيرة بصورة أكثر كفاءة. كما تشرح كيف يمكن استخدام الملفات المؤقتة أثناء المعالجة وكيفية تغيير المجلد المستخدم لتخزينها.

## **حول BLOB**

**BLOB** (**Binary Large Object**) هو عادةً عنصر كبير (صورة، عرض تقديمي، مستند أو وسائط) محفوظ بصيغة ثنائية.

يسمح Aspose.Slides for Java باستخدام BLOB للكائنات بطريقة تقلل من استهلاك الذاكرة عندما تكون الملفات كبيرة.

{{% alert title="Info" color="info" %}}
لتجاوز بعض القيود عند التفاعل مع التدفقات، قد تقوم Aspose.Slides بنسخ محتوى التدفق. تحميل عرض تقديمي كبير عبر تدفقه سيؤدي إلى نسخ محتويات العرض وبالتالي يتسبب في بطء التحميل. لذا، عندما تنوي تحميل عرض تقديمي كبير، نوصي بشدة باستخدام مسار ملف العرض بدلاً من تدفقه.
{{% /alert %}}

## **استخدام BLOB لتقليل استهلاك الذاكرة**

### **إضافة ملف كبير عبر BLOB إلى عرض تقديمي**

[Aspose.Slides](/slides/ar/java/) for Java تسمح لك بإضافة ملفات كبيرة (في هذه الحالة ملف فيديو كبير) عبر عملية تعتمد على BLOB لتقليل استهلاك الذاكرة.

هذا المثال في Java يوضح كيفية إضافة ملف فيديو كبير عبر عملية BLOB إلى عرض تقديمي:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// ينشئ عرض تقديمي جديد سيتم إضافة الفيديو إليه
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // لنضيف الفيديو إلى العرض التقديمي - اخترنا سلوك KeepLocked لأننا نريد
        //ليس لدينا نية للوصول إلى ملف "veryLargeVideo.avi" file.
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // يحفظ العرض التقديمي. بينما يتم إخراج عرض تقديمي كبير، يظل استهلاك الذاكرة
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

Aspose.Slides for Java تتيح لك تصدير ملفات كبيرة (مثل ملف صوت أو فيديو) عبر عملية تعتمد على BLOB من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج ملف وسائط كبير من عرض تقديمي دون تحميله إلى ذاكرة جهازك. من خلال تصدير الملف عبر عملية BLOB تبقى استهلاك الذاكرة منخفضًا.

الكود التالي في Java يوضح العملية المذكورة:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// يقفل ملف المصدر ولا يقوم بتحميله إلى الذاكرة
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// إنشاء كائن Presentation، وقفل ملف "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // لننعمل حفظ كل فيديو إلى ملف. لمنع استهلاك عالي للذاكرة، نحتاج إلى مخزن سيتم استخدامه
    // لنقل البيانات من تدفق فيديو العرض التقديمي إلى تدفق لملف فيديو تم إنشاؤه حديثًا.
    byte[] buffer = new byte[8 * 1024];

    // يتنقل عبر مقاطع الفيديو
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // يفتح تدفق فيديو العرض التقديمي. يرجى ملاحظة أننا تجنبنا عمدًا الوصول إلى الخصائص
        // مثل video.BinaryData - لأن هذه الخاصية تُرجع مصفوفة بايت تحتوي على فيديو كامل، مما يؤدي بعد ذلك
        // لتحميل البايتات إلى الذاكرة. نستخدم video.GetStream، التي تُرجع Stream - ولا تقوم
        //  تتطلب منا تحميل الفيديو كاملًا إلى الذاكرة.
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
    // إذا لزم الأمر، يمكنك تطبيق نفس الخطوات على ملفات الصوت. 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **إضافة صورة كـ BLOB إلى عرض تقديمي**

باستخدام الأساليب من واجهة [**IImageCollection**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IImageCollection) وفئة [**ImageCollection**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ImageCollection)، يمكنك إضافة صورة كبيرة كتيار ليتم معالجتها كـ BLOB.

هذا الكود في Java يوضح كيفية إضافة صورة كبيرة عبر عملية BLOB:

```java
String pathToLargeImage = "large_image.jpg";

// ينشئ عرض تقديمي جديد ستتم إضافة الصورة إليه.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// لنضيف الصورة إلى العرض التقديمي - اخترنا سلوك KeepLocked لأننا
		// لا نعتزم الوصول إلى ملف "largeImage.png" file.
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// يحفظ العرض التقديمي. أثناء إخراج عرض تقديمي كبير، استهلاك الذاكرة
		// يظل منخفضًا طوال دورة حياة كائن pres
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

عادةً، لتحميل عرض تقديمي كبير تحتاج الحواسيب إلى الكثير من الذاكرة المؤقتة. يتم تحميل كل محتوى العرض إلى الذاكرة ويتوقف استخدام الملف الأصلي الذي تم تحميل العرض منه.

خذ مثالًا على عرض تقديمي PowerPoint كبير (large.pptx) يحتوي على ملف فيديو بحجم 1.5 GB. الطريقة القياسية لتحميل العرض موضحة في هذا الكود Java:

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

لكن هذه الطريقة تستهلك حوالي 1.6 GB من الذاكرة المؤقتة.

### **تحميل عرض تقديمي كبير كـ BLOB**

من خلال العملية التي تعتمد على BLOB يمكنك تحميل عرض تقديمي كبير مع استهلاك قليل للذاكرة. يصف هذا الكود Java التنفيذ حيث تُستخدم عملية BLOB لتحميل ملف عرض تقديمي كبير (large.pptx):

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

### **تغيير المجلد الخاص بالملفات المؤقتة**

عند استخدام عملية BLOB، يقوم جهازك بإنشاء ملفات مؤقتة في المجلد الافتراضي للملفات المؤقتة. إذا رغبت في حفظ هذه الملفات في مجلد مختلف، يمكنك تعديل إعدادات التخزين باستخدام `TempFilesRootPath`:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
عند استخدام `TempFilesRootPath`، لا تقوم Aspose.Slides بإنشاء المجلد تلقائيًا لتخزين الملفات المؤقتة. عليك إنشاء المجلد يدويًا.
{{% /alert %}}

### **إصدار كائنات العرض لتحرير الذاكرة**

عند معالجة عروض تقديمية كبيرة، تأكد من إتلاف كائن [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) بشكل صحيح لإخلاء الذاكرة التي كان يشغلها. استدعِ `dispose()` بعد الانتهاء من استخدام العرض لتحرير الموارد غير المدارة.

```java
Presentation presentation = new Presentation("large.pptx");

// ...process the presentation...
presentation.save("large.pdf", SaveFormat.Pdf);

// Explicitly release resources.
presentation.dispose();
```

## **الأسئلة المتداولة**

**ما البيانات في عرض Aspose.Slides التي تُعامل كـ BLOB وتخضع لإعدادات BLOB؟**

الكائنات الثنائية الكبيرة مثل الصور، الصوت، والفيديو تُعامل كـ BLOB. كما أن ملف العرض بالكامل يتضمن معالجة BLOB عند تحميله أو حفظه. هذه الكائنات تخضع لسياسات BLOB التي تسمح لك بإدارة استخدام الذاكرة وتحويل البيانات إلى ملفات مؤقتة عند الحاجة.

**أين يمكنني تكوين قواعد معالجة BLOB أثناء تحميل العرض؟**

استخدم [LoadOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/) مع [BlobManagementOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/blobmanagementoptions/). هناك يمكنك ضبط حد الذاكرة داخلية لـ BLOB، السماح أو منع الملفات المؤقتة، اختيار مسار الجذر للملفات المؤقتة، وتحديد سلوك قفل المصدر.

**هل تؤثر إعدادات BLOB على الأداء، وكيف يمكن موازنة السرعة مقابل الذاكرة؟**

نعم. إبقاء BLOB في الذاكرة يزيد السرعة لكنه يرفع استهلاك RAM؛ خفض حد الذاكرة يوجه المزيد من العمل إلى الملفات المؤقتة، مما يقلل RAM لكنه يضيف عبء I/O إضافي. استخدم طريقة [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/ar/java/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) لتحقيق التوازن المناسب لحمل عملك وبيئتك.

**هل تساعد خيارات BLOB عند فتح عروض تقديمية ضخمة جدًا (مثلاً عدة غيغابايت)؟**

نعم. تم تصميم [BlobManagementOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/blobmanagementoptions/) لهذا النوع من السيناريوهات: تمكين الملفات المؤقتة واستخدام قفل المصدر يمكن أن يقلل بشكل كبير من استهلاك الذاكرة القصوى ويستقر عملية المعالجة لعروض ضخمة.

**هل يمكنني استخدام سياسات BLOB عند التحميل من التدفقات بدلاً من ملفات القرص؟**

نعم. تنطبق القواعد نفسها على التدفقات: يمكن لكائن العرض امتلاك القفل وتثبيت تدفق الإدخال (حسب وضع القفل المختار)، وتُستخدم الملفات المؤقتة عند السماح بذلك، مما يحافظ على استهلاك الذاكرة متوقعًا أثناء المعالجة.