---
title: "إدارة كائنات BLOB في العروض التقديمية على Android لاستخدام فعال للذاكرة"
linktitle: "إدارة BLOB"
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
description: "إدارة بيانات BLOB في Aspose.Slides لنظام Android عبر Java لتبسيط عمليات ملفات PowerPoint و OpenDocument من أجل معالجة عروض تقديمية فعّالة."
---

## **حول BLOB**

**BLOB** (**Binary Large Object**، كائن ثنائي كبير) هو عادةً عنصر كبير (صورة، عرض تقديمي، مستند أو وسائط) يتم حفظه بصيغ ثنائية.

Aspose.Slides for Android via Java يتيح لك استخدام BLOBs للكائنات بطريقة تقلل من استهلاك الذاكرة عندما تكون الملفات كبيرة.

{{% alert title="Info" color="info" %}}
لتجاوز بعض القيود عند التفاعل مع التيارات، قد تقوم Aspose.Slides بنسخ محتوى التيار. تحميل عرض تقديمي كبير عبر التيار سيؤدي إلى نسخ محتويات العرض وبالتالي بطء في التحميل. لذلك، عندما تريد تحميل عرض تقديمي كبير، نوصي بشدة باستخدام مسار ملف العرض وليس التيار.
{{% /alert %}}

## **استخدام BLOB لتقليل استهلاك الذاكرة**

### **إضافة ملف كبير عبر BLOB إلى عرض تقديمي**

[Aspose.Slides](/slides/ar/androidjava/) for Java يتيح لك إضافة ملفات كبيرة (في هذه الحالة، ملف فيديو كبير) عبر عملية تتضمن BLOBs لتقليل استهلاك الذاكرة.

هذا المثال بلغة Java يوضح كيفية إضافة ملف فيديو كبير عبر عملية BLOB إلى عرض تقديمي:
```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// إنشاء عرض تقديمي جديد ستتم إضافة الفيديو إليه
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // لنضيف الفيديو إلى العرض التقديمي - اخترنا السلوك KeepLocked لأننا
        // لا نعتزم الوصول إلى ملف "veryLargeVideo.avi" الملف.
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
Aspose.Slides for Android via Java يتيح لك تصدير ملفات كبيرة (مثل ملف صوت أو فيديو) عبر عملية تتضمن BLOBs من العروض. على سبيل المثال، قد تحتاج إلى استخراج ملف وسائط كبير من عرض تقديمي دون تحميله إلى ذاكرة جهازك. عن طريق تصديره عبر عملية BLOB، تحافظ على استهلاك منخفض للذاكرة.

هذا الكود بلغة Java يوضح العملية الموصوفة:
```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// يقفل ملف المصدر ولا يقوم بتحميله إلى الذاكرة
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// إنشاء كائن العرض التقديمي، وقفل ملف "hugePresentationWithAudiosAndVideos.pptx" الملف.
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // لنقوم بحفظ كل فيديو إلى ملف. لتفادي استهلاك عالي للذاكرة، نحتاج إلى مخزن وسيط سيتم استخدامه
    // لنقل البيانات من تدفق فيديو العرض التقديمي إلى تدفق لملف فيديو تم إنشاؤه حديثًا.
    byte[] buffer = new byte[8 * 1024];

    // التكرار عبر مقاطع الفيديو
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // يفتح تدفق فيديو العرض التقديمي. يرجى ملاحظة أننا تجنبنا عن قصد الوصول إلى الخصائص
        // مثل video.BinaryData - لأن هذه الخاصية تُعيد مصفوفة بايت تحتوي على الفيديو بالكامل، مما
        // يسبب تحميل البايتات إلى الذاكرة. نحن نستخدم video.GetStream، الذي سيعيد Stream - ولا يقوم
        // بإجبارنا على تحميل كامل الفيديو إلى الذاكرة.
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


### **إضافة صورة كـ BLOB في عرض تقديمي**
باستخدام أساليب من واجهة [**IImageCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) وفئة [**ImageCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ImageCollection)، يمكنك إضافة صورة كبيرة كتيار لتعاملها كـ BLOB.

هذا الكود بلغة Java يوضح كيفية إضافة صورة كبيرة عبر عملية BLOB:
```java
String pathToLargeImage = "large_image.jpg";

// ينشئ عرض تقديمي جديد سيتم إضافة الصورة إليه.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// لنضيف الصورة إلى العرض التقديمي - نختار سلوك KeepLocked لأنه
		// لا نعتزم الوصول إلى ملف "largeImage.png".
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// يحفظ العرض التقديمي. أثناء خروج عرض تقديمي كبير، استهلاك الذاكرة
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


## **الذاكرة والعروض الكبيرة**

عادةً، لتحميل عرض تقديمي كبير، تحتاج الحواسيب إلى كمية كبيرة من الذاكرة المؤقتة. يتم تحميل جميع محتويات العرض إلى الذاكرة ويتوقف استخدام الملف الأصلي.

تخيل عرض PowerPoint كبير (large.pptx) يحتوي على ملف فيديو حجمه 1.5 GB. الطريقة القياسية لتحميل العرض موضحة في هذا الكود بلغة Java:
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

من خلال عملية تشمل BLOB، يمكنك تحميل عرض تقديمي كبير مع استخدام قليل من الذاكرة. يوضح الكود التالي بلغة Java تطبيق عملية BLOB لتحميل ملف عرض تقديمي كبير (large.pptx):
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

عند استخدام عملية BLOB، ينشئ الكمبيوتر ملفات مؤقتة في المجلد الافتراضي للملفات المؤقتة. إذا رغبت في حفظ الملفات المؤقتة في مجلد مختلف، يمكنك تعديل إعدادات التخزين باستخدام `TempFilesRootPath`:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```


{{% alert title="Info" color="info" %}}
عند استخدام `TempFilesRootPath`، لا تقوم Aspose.Slides بإنشاء مجلد تلقائيًا لتخزين الملفات المؤقتة. عليك إنشاء المجلد يدويًا.
{{% /alert %}}

## **الأسئلة الشائعة**

**ما البيانات في عرض Aspose.Slides التي تُعامل كـ BLOB وتُتحكم بها خيارات BLOB؟**  
الكائنات الثنائية الكبيرة مثل الصور، الصوت والفيديو تُعامل كـ BLOB. كذلك ملف العرض بالكامل يتضمن معالجة BLOB عند تحميله أو حفظه. تُحكم هذه الكائنات بسياسات BLOB التي تسمح لك بإدارة استهلاك الذاكرة واستخدام الملفات المؤقتة عند الحاجة.

**أين يمكنني تكوين قواعد معالجة BLOB أثناء تحميل العرض؟**  
استخدم [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) مع [BlobManagementOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blobmanagementoptions/). هناك يمكنك ضبط الحد الأقصى للذاكرة المستخدمة للـ BLOB، السماح أو منع إنشاء ملفات مؤقتة، اختيار مسار الجذر للملفات المؤقتة، وتحديد سلوك قفل المصدر.

**هل تؤثر إعدادات BLOB على الأداء، وكيف أوازن بين السرعة والذاكرة؟**  
نعم. إبقاء BLOB في الذاكرة يزيد السرعة لكنه يستهلك المزيد من RAM؛ تقليل الحد يسمح بنقل مزيد من العمل إلى الملفات المؤقتة، مما يقلل الRAM لكن يضيف عبء I/O. استخدم طريقة [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) لتحقيق التوازن المناسب لبيئتك وحجم العمل.

**هل تساعد خيارات BLOB عند فتح عروض تقديمية ضخمة جدًا (مثلاً جيجابايت)?**  
نعم. تم تصميم [BlobManagementOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blobmanagementoptions/) لهذه السيناريوهات: تفعيل الملفات المؤقتة واستخدام قفل المصدر يمكن أن يقلل بشكل كبير من الذروة في استهلاك RAM ويستقر عملية المعالجة للعروض الضخمة.

**هل يمكنني استخدام سياسات BLOB عند التحميل من التيارات بدلًا من ملفات القرص؟**  
نعم. تُطبق القواعد نفسها على التيارات: يمكن للكائن العرض أن يمتلك التيار ويفعه (حسب وضع القفل المختار)، وتُستخدم الملفات المؤقتة إذا سمحت السياسات، مما يحافظ على سلوك استهلاك الذاكرة متوقعًا أثناء المعالجة.