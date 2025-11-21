---
title: إدارة Blob
type: docs
weight: 10
url: /ar/nodejs-java/manage-blob/
description: إدارة Blob في عرض PowerPoint باستخدام JavaScript. استخدم Blob لتقليل استهلاك الذاكرة في عرض PowerPoint باستخدام JavaScript. أضف ملفًا كبيرًا عبر Blob إلى عرض PowerPoint باستخدام JavaScript. صدّر ملفًا كبيرًا عبر Blob من عرض PowerPoint باستخدام JavaScript. حمّل عرض PowerPoint كبير كـ Blob باستخدام JavaScript.
---

## **حول BLOB**

**BLOB** (**كائن ثنائي كبير**) عادةً ما يكون عنصرًا كبيرًا (صورة، عرض تقديمي، مستند أو وسائط) محفوظًا بصيغٍ ثنائية.

Aspose.Slides for Node.js via Java تتيح لك استخدام BLOBs للكائنات بطريقة تقلل استهلاك الذاكرة عندما تتعامل مع ملفات كبيرة.

{{% alert title="Info" color="info" %}}
لتجاوز بعض القيود عند التعامل مع التدفقات، قد تقوم Aspose.Slides بنسخ محتوى التدفق. تحميل عرض تقديمي كبير عبر تدفقه سيؤدي إلى نسخ محتويات العرض وبالتالي بطء التحميل. لذلك، عندما تنوي تحميل عرض تقديمي كبير، نوصي بشدة باستخدام مسار ملف العرض وليس تدفقه.
{{% /alert %}}

## **استخدام BLOB لتقليل استهلاك الذاكرة**

### **إضافة ملف كبير عبر BLOB إلى عرض تقديمي**

[Aspose.Slides](/slides/ar/nodejs-java/) for Node.js via Java تتيح لك إضافة ملفات كبيرة (في هذه الحالة، ملف فيديو كبير) عبر عملية تشمل BLOB لتقليل استهلاك الذاكرة.

هذا المثال في JavaScript يوضح كيفية إضافة ملف فيديو كبير عبر عملية BLOB إلى عرض تقديمي:
```javascript
var pathToVeryLargeVideo = "veryLargeVideo.avi";
// ينشئ عرضًا تقديميًا جديدًا سيتم إضافة الفيديو إليه
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToVeryLargeVideo);
    try {
        // لنضيف الفيديو إلى العرض - اخترنا سلوك KeepLocked لأننا لا
        // نعتزم الوصول إلى ملف "veryLargeVideo.avi".
        var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);
        // يحفظ العرض. بينما يتم إخراج عرض تقديمي كبير، يظل استهلاك الذاكرة
        // منخفضًا طوال دورة حياة كائن pres
        pres.save("presentationWithLargeVideo.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **تصدير ملف كبير عبر BLOB من عرض تقديمي**

Aspose.Slides for Node.js via Java تتيح لك تصدير ملفات كبيرة (مثل ملف صوت أو فيديو) عبر عملية تشمل BLOB من العروض التقديمية. على سبيل المثال، قد تحتاج لاستخراج ملف وسائط كبير من عرض تقديمي دون تحميله إلى ذاكرة جهازك. من خلال تصديره عبر عملية BLOB، يبقى استهلاك الذاكرة منخفضًا.

هذا الكود في JavaScript يوضح العملية المذكورة:
```javascript
var hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
var loadOptions = new aspose.slides.LoadOptions();
// Locks the source file and does NOT load it into memory
// قفل ملف المصدر وعدم تحميله إلى الذاكرة
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
// create the Presentation's instance, lock the "hugePresentationWithAudiosAndVideos.pptx" file.
 // إنشاء نسخة من العرض وتقفل ملف "hugePresentationWithAudiosAndVideos.pptx".
var pres = new aspose.slides.Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Let's save each video to a file. To prevent high memory usage, we need a buffer that will be used
    // لنحفظ كل فيديو في ملف. لمنع استهلاك عالي للذاكرة، نحتاج إلى مخزن سيُستخدم
    // to transfer the data from the presentation's video stream to a stream for a newly created video file.
    // لنقل البيانات من تدفق فيديو العرض إلى تدفق لملف فيديو تم إنشاؤه حديثًا.
    var buffer = new byte[8 * 1024];
    // Iterates through the videos
    // التكرار عبر مقاطع الفيديو
    for (var index = 0; index < pres.getVideos().size(); index++) {
        var video = pres.getVideos().get_Item(index);
        // Opens the presentation video stream. Please, note that we intentionally avoided accessing properties
        // فتح تدفق فيديو العرض. يرجى ملاحظة أننا تجنبنا عن عمد الوصول إلى الخصائص
        // like video.BinaryData - because this property returns a byte array containing a full video, which then
        // مثل video.BinaryData - لأن هذه الخاصية تُعيد مصفوفة بايت تحتوي على الفيديو بالكامل، وهو ما
        // causes bytes to be loaded into memory. We use video.GetStream, which will return Stream - and does NOT
        // يتسبب في تحميل البايتات إلى الذاكرة. نستخدم video.GetStream، الذي سيُعيد Stream - ولا
        // require us to load the whole video into the memory.
        // يتطلب تحميل الفيديو بالكامل إلى الذاكرة.
        var presVideoStream = video.getStream();
        try {
            var outputFileStream = java.newInstanceSync("java.io.FileOutputStream", ("video" + index) + ".avi");
            try {
                var bytesRead;
                while ((bytesRead = presVideoStream.read(buffer, 0, buffer.length)) > 0) {
                    outputFileStream.write(buffer, 0, bytesRead);
                }
            } finally {
                outputFileStream.close();
            }
        } finally {
            presVideoStream.close();
        }
        // Memory consumption will remain low regardless of the size of the video or presentation.
        // ستبقى استهلاك الذاكرة منخفضًا بغض النظر عن حجم الفيديو أو العرض.
    }
    // If necessary, you can apply the same steps for audio files.
    // إذا لزم الأمر، يمكنك تطبيق نفس الخطوات على ملفات الصوت.
} catch (e) {console.log(e);
} finally {
    pres.dispose();
}
```


### **إضافة صورة كـ BLOB في عرض تقديمي**

باستخدام طرق من فئة [**ImageCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection) و[**ImageCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection) يمكنك إضافة صورة كبيرة كتيار لتعاملها كـ BLOB.

هذا الكود في JavaScript يوضح كيفية إضافة صورة كبيرة عبر عملية BLOB:
```javascript
var pathToLargeImage = "large_image.jpg";
// ينشئ عرضًا تقديميًا جديدًا سيتم إضافة الصورة إليه.
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToLargeImage);
    try {
        // لنضيف الصورة إلى العرض - اخترنا سلوك KeepLocked لأننا
        // لا ننوي الوصول إلى الملف "largeImage.png".
        var img = pres.getImages().addImage(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
        // يحفظ العرض. بينما يتم إخراج عرض تقديمي كبير، استهلاك الذاكرة
        // يبقى منخفضًا طوال دورة حياة كائن pres.
        pres.save("presentationWithLargeImage.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الذاكرة والعروض التقديمية الكبيرة**

عادةً، لتحميل عرض تقديمي كبير تحتاج الحواسيب إلى الكثير من الذاكرة المؤقتة. يتم تحميل جميع محتويات العرض إلى الذاكرة ويتوقف استخدام الملف الذي تم تحميل العرض منه.

خذ مثالًا على عرض تقديمي PowerPoint كبير (large.pptx) يحتوي على ملف فيديو حجمه 1.5 GB. الطريقة القياسية لتحميل العرض موضحّة في هذا الكود JavaScript:
```javascript
var pres = new aspose.slides.Presentation("large.pptx");
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


لكن هذه الطريقة تستهلك حوالي 1.6 GB من الذاكرة المؤقتة.

### **تحميل عرض تقديمي كبير كـ BLOB**

من خلال عملية تشمل BLOB، يمكنك تحميل عرض تقديمي كبير باستخدام ذاكرة قليلة. يوضح هذا الكود JavaScript تطبيقًا حيث تُستخدم عملية BLOB لتحميل ملف عرض تقديمي كبير (large.pptx):
```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
var pres = new aspose.slides.Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


### **تغيير المجلد للملفات المؤقتة**

عند استخدام عملية BLOB، يُنشئ جهازك ملفات مؤقتة في المجلد الافتراضي للملفات المؤقتة. إذا رغبت في حفظ الملفات المؤقتة في مجلد مختلف، يمكنك تغيير إعدادات التخزين باستخدام `setTempFilesRootPath`:
```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```


{{% alert title="Info" color="info" %}}
عند استخدام `setTempFilesRootPath`، لا تقوم Aspose.Slides بإنشاء مجلد لتخزين الملفات المؤقتة تلقائيًا. عليك إنشاء المجلد يدويًا.
{{% /alert %}}

## **الأسئلة المتكررة**

**ما البيانات في عرض Aspose.Slides تُعامل كـ BLOB وتتحكم فيها خيارات BLOB؟**

الكائنات الثنائية الكبيرة مثل الصور، الصوت والفيديو تُعامل كـ BLOB. ملف العرض بالكامل أيضًا يشتمل على معالجة BLOB عند تحميله أو حفظه. تُحكم هذه الكائنات بسياسات BLOB التي تسمح لك بإدارة استهلاك الذاكرة والتحويل إلى ملفات مؤقتة عند الحاجة.

**أين يمكنني تكوين قواعد معالجة BLOB أثناء تحميل العرض؟**

استخدم [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/) مع [BlobManagementOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blobmanagementoptions/). هناك يمكنك ضبط الحد الأقصى للذاكرة لـ BLOB، السماح أو منع الملفات المؤقتة، اختيار المسار الجذري للملفات المؤقتة، وتحديد سلوك قفل المصدر.

**هل تؤثر إعدادات BLOB على الأداء، وكيف أوازن بين السرعة والذاكرة؟**

نعم. الاحتفاظ بـ BLOB في الذاكرة يعزز السرعة لكنه يزيد استهلاك RAM؛ خفض الحد الأقصى للذاكرة يحوّل المزيد إلى ملفات مؤقتة، ما يقلل RAM لكن يتطلب I/O إضافي. استخدم الطريقة [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) للوصول إلى التوازن المناسب لحمولة عملك وبيئتك.

**هل تساعد خيارات BLOB عند فتح عروض تقديمية ضخمة جدًا (مثلاً بالغيغابايت)؟**

نعم. تم تصميم [BlobManagementOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blobmanagementoptions/) لهذا النوع من السيناريوهات: تمكين الملفات المؤقتة واستخدام قفل المصدر يمكن أن يقلل بشكل كبير من استهلاك RAM الذروة ويستقر معالجة العروض الضخمة جدًا.

**هل يمكنني استخدام سياسات BLOB عند التحميل من تدفقات بدلاً من ملفات القرص؟**

نعم. تُطبق القواعد نفسها على التدفقات: يمكن لكائن العرض امتلاك وقفل تدفق الإدخال (حسب وضع القفل المختار)، وتُستخدم الملفات المؤقتة عندما يُسمح بذلك، مما يحافظ على استهلاك الذاكرة متوقعًا أثناء المعالجة.