---
title: إدارة كائنات BLOB للعرض التقديمي في JavaScript لاستخدام فعال للذاكرة
linktitle: إدارة BLOB
type: docs
weight: 10
url: /ar/nodejs-java/manage-blob/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "إدارة بيانات BLOB في JavaScript باستخدام Aspose.Slides لـ Node.js لتبسيط عمليات ملفات PowerPoint وOpenDocument لتحقيق معالجة عروض تقديمية فعّالة."
---
## **نظرة عامة**

Aspose.Slides توفر معالجة تعتمد على BLOB للبيانات الثنائية الكبيرة في العروض التقديمية للمساعدة في تقليل استهلاك الذاكرة عند التعامل مع الصور الكبيرة، والملفات الصوتية، والفيديو، وملفات العروض التقديمية.

توضح هذه المقالة كيفية استخدام المعالجة المعتمدة على BLOB لإضافة وسائط كبيرة إلى عرض تقديمي، وتصدير وسائط كبيرة من عرض تقديمي، وتحميل عروض تقديمية كبيرة بشكل أكثر كفاءة. كما تشرح كيفية استخدام الملفات المؤقتة أثناء المعالجة وكيفية تغيير المجلد المستخدم لتخزينها.

## **حول BLOB**

**BLOB** (**كائن ثنائي كبير**) هو عادةً عنصر كبير (صورة، عرض تقديمي، مستند، أو وسائط) يُحفظ بصيغ ثنائية.

تتيح Aspose.Slides for Node.js عبر Java إمكانية استخدام BLOBs للكائنات بطريقة تقلل من استهلاك الذاكرة عند التعامل مع ملفات كبيرة.

{{% alert title="Info" color="info" %}}
لتجاوز بعض القيود عند التفاعل مع التدفقات، قد تقوم Aspose.Slides بنسخ محتوى التدفق. سيؤدي تحميل عرض تقديمي كبير عبر تدفقه إلى نسخ محتويات العرض وتسبب بطئًا في التحميل. لذلك، عندما تنوي تحميل عرض تقديمي كبير، نوصي بشدة باستخدام مسار ملف العرض وليس تدفقه.
{{% /alert %}}

## **استخدام BLOB لتقليل استهلاك الذاكرة**

### **إضافة ملف كبير عبر BLOB إلى عرض تقديمي**

[Aspose.Slides](/slides/ar/nodejs-java/) for Node.js عبر Java يتيح لك إضافة ملفات كبيرة (في هذه الحالة، ملف فيديو كبير) من خلال عملية تشمل BLOBs لتقليل استهلاك الذاكرة.
يعرض لك هذا JavaScript كيفية إضافة ملف فيديو كبير عبر عملية BLOB إلى عرض تقديمي:

```javascript
var pathToVeryLargeVideo = "veryLargeVideo.avi";
// ينشئ عرض تقديمي جديد سيتم إضافة الفيديو إليه
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToVeryLargeVideo);
    try {
        // لنقم بإضافة الفيديو إلى العرض التقديمي - اخترنا سلوك KeepLocked لأننا
        // لا نعتزم الوصول إلى ملف "veryLargeVideo.avi".
        var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);
        // يحفظ العرض التقديمي. بينما يتم إخراج عرض تقديمي كبير، يظل استهلاك الذاكرة
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

تتيح Aspose.Slides for Node.js عبر Java إمكانية تصدير ملفات كبيرة (في هذه الحالة، ملف صوتي أو فيديو) من خلال عملية تشمل BLOBs من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج ملف وسائط كبير من عرض تقديمي دون تحميله إلى ذاكرة جهازك. من خلال تصدير الملف عبر عملية BLOB، يمكنك الحفاظ على استهلاك منخفض للذاكرة.
يُظهر هذا الكود في JavaScript العملية الموضحة:

```javascript
var hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
var loadOptions = new aspose.slides.LoadOptions();
// يقفل ملف المصدر ولا يقوم بتحميله إلى الذاكرة
// إنشاء نسخة من Presentation، وقفل ملف "hugePresentationWithAudiosAndVideos.pptx".
var pres = new aspose.slides.Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // لنقم بحفظ كل فيديو إلى ملف. لتجنب استهلاك عالي للذاكرة، نحتاج إلى مخزن مؤقت سيتم استخدامه
    // لنقل البيانات من تدفق فيديو العرض التقديمي إلى تدفق لملف فيديو تم إنشاؤه حديثًا.
    var buffer = new byte[8 * 1024];
    // Iterates through the videos
    for (var index = 0; index < pres.getVideos().size(); index++) {
        var video = pres.getVideos().get_Item(index);
        // يفتح تدفق فيديو العرض التقديمي. يرجى ملاحظة أننا تجنبنا عن قصد الوصول إلى الخصائص
        // مثل video.BinaryData - لأن هذه الخاصية تُرجع مصفوفة بايت تحتوي على فيديو كامل، مما ينتج عنه
        // تحميل البايتات إلى الذاكرة. نستخدم video.GetStream، التي تُرجع Stream - ولا
        // تتطلب منا تحميل الفيديو بالكامل إلى الذاكرة.
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
        // سيظل استهلاك الذاكرة منخفضًا بغض النظر عن حجم الفيديو أو العرض التقديمي.
    }
    // إذا لزم الأمر، يمكنك تطبيق نفس الخطوات على ملفات الصوت.
} catch (e) {console.log(e);
} finally {
    pres.dispose();
}
```

### **إضافة صورة كـ BLOB في العرض التقديمي**

باستخدام الطرق من فئة [**ImageCollection**](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ImageCollection) وفئة [**ImageCollection** ](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ImageCollection)، يمكنك إضافة صورة كبيرة كدفق ليتم معالجتها كـ BLOB.
يعرض لك هذا الكود في JavaScript كيفية إضافة صورة كبيرة عبر عملية BLOB:

```javascript
var pathToLargeImage = "large_image.jpg";
// ينشئ عرض تقديمي جديد سيتم إضافة الصورة إليه.
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToLargeImage);
    try {
        // لنقم بإضافة الصورة إلى العرض التقديمي - نختار سلوك KeepLocked لأننا
        // لا نعتزم الوصول إلى ملف "largeImage.png" الملف.
        var img = pres.getImages().addImage(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
        // يحفظ العرض التقديمي. بينما يتم إخراج عرض تقديمي كبير، استهلاك الذاكرة
        // يظل منخفضًا طوال دورة حياة كائن pres
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

عادةً، لتحميل عرض تقديمي كبير، تحتاج الحواسيب إلى الكثير من الذاكرة المؤقتة. يتم تحميل كل محتوى العرض إلى الذاكرة ويتوقف استخدام الملف (الذي تم تحميل العرض منه).

تخيل عرض PowerPoint كبير (large.pptx) يحتوي على ملف فيديو بحجم 1.5 جيجابايت. الطريقة القياسية لتحميل العرض موضحة في هذا الكود JavaScript:

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

لكن هذه الطريقة تستهلك نحو 1.6 جيجابايت من الذاكرة المؤقتة.

### **تحميل عرض تقديمي كبير كـ BLOB**

من خلال العملية التي تشمل BLOB، يمكنك تحميل عرض تقديمي كبير مع استخدام القليل من الذاكرة. يصف هذا الكود JavaScript التنفيذ حيث يتم استخدام عملية BLOB لتحميل ملف عرض تقديمي كبير (large.pptx):

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

عند استخدام عملية BLOB، يقوم جهازك بإنشاء ملفات مؤقتة في المجلد الافتراضي للملفات المؤقتة. إذا رغبت في حفظ الملفات المؤقتة في مجلد مختلف، يمكنك تغيير إعدادات التخزين باستخدام `setTempFilesRootPath`:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
عند استخدامك `setTempFilesRootPath`، لا تقوم Aspose.Slides بإنشاء مجلد لتخزين الملفات المؤقتة تلقائيًا. يجب عليك إنشاء المجلد يدويًا.
{{% /alert %}}

### **التخلص من كائنات العرض لتحرير الذاكرة**

عند معالجة عروض تقديمية كبيرة، تأكد من إتلاف مثيل [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) بشكل صحيح حتى يتم تحرير الذاكرة التي كان يشغلها. استدعِ `dispose()` بعد الانتهاء من استخدام العرض لتحرير الموارد غير المدارة.

```js
let presentation = new aspose.slides.Presentation("large.pptx");

// ...process the presentation...
presentation.save("large.pdf", aspose.slides.SaveFormat.Pdf);

// Explicitly release resources.
presentation.dispose();
```

## **الأسئلة المتكررة**

**ما البيانات في عرض Aspose.Slides التي تُعامل كـ BLOB وتُتحكم فيها خيارات BLOB؟**
تُعامل الكائنات الثنائية الكبيرة مثل الصور، والصوت، والفيديو كـ BLOB. كما يُعنى بملف العرض بالكامل بمعالجة BLOB عند تحميله أو حفظه. تُحكم هذه الكائنات بسياسات BLOB التي تسمح لك بإدارة استخدام الذاكرة وتفريغها إلى ملفات مؤقتة عند الحاجة.

**أين أُكوّن قواعد معالجة BLOB أثناء تحميل العرض؟**
استخدم [LoadOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/) مع [BlobManagementOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/blobmanagementoptions/). هناك تقوم بتحديد الحد الأقصى للذاكرة لكائنات BLOB، السماح أو عدم السماح بالملفات المؤقتة، اختيار مسار الجذر للملفات المؤقتة، وتحديد سلوك قفل المصدر.

**هل تؤثر إعدادات BLOB على الأداء، وكيف يمكن موازنة السرعة مقابل الذاكرة؟**
نعم. الاحتفاظ بـ BLOB في الذاكرة يزيد من السرعة لكن يرفع استهلاك الذاكرة الفعلية؛ تقليل الحد الأقصى للذاكرة ينقل المزيد من العمل إلى الملفات المؤقتة، مما يقلل الذاكرة على حساب عمليات إدخال/إخراج إضافية. استخدم طريقة [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) لتحقيق التوازن المناسب لحمولة عملك وبيئتك.

**هل تساعد خيارات BLOB عند فتح عروض تقديمية ضخمة جدًا (مثلاً عدة جيجابايت)؟**
نعم. تم تصميم [BlobManagementOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/blobmanagementoptions/) لهذه السيناريوهات: تمكين الملفات المؤقتة واستخدام قفل المصدر يمكن أن يقلل بشكل كبير من أقصى استخدام للذاكرة ويثبت عملية المعالجة للعروض الضخمة جدًا.

**هل يمكنني استخدام سياسات BLOB عند التحميل من التدفقات بدلاً من ملفات القرص؟**
نعم. تُطبق القواعد نفسها على التدفقات: يمكن لمثيل العرض امتلاك قفل لتدفق الإدخال (حسب وضع القفل المختار)، وتُستخدم الملفات المؤقتة عند السماح بذلك، مما يحافظ على توقع استهلاك الذاكرة أثناء المعالجة.