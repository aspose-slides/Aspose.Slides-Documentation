---
title: إدارة BLOBs في العروض التقديمية باستخدام Python لاستخدام الذاكرة بفعالية
linktitle: إدارة BLOB
type: docs
weight: 10
url: /ar/python-net/manage-blob/
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
- Python
- Aspose.Slides
description: "إدارة بيانات BLOB في Aspose.Slides لـ Python عبر .NET لتبسيط عمليات ملفات PowerPoint و OpenDocument من أجل معالجة عروض تقديمية فعّالة."
---

## **حول BLOB**

**BLOB** (**Binary Large Object**) هو عادةً عنصر كبير (صورة، عرض تقديمي، مستند، أو وسائط) يتم حفظه بصيغ ثنائية.  

Aspose.Slides for Python via .NET يتيح لك استخدام BLOBs للكائنات بطريقة تقلل استهلاك الذاكرة عندما تكون الملفات كبيرة.

## **استخدام BLOB لتقليل استهلاك الذاكرة**

### **إضافة ملف كبير عبر BLOB إلى عرض تقديمي**

[Aspose.Slides](/slides/ar/python-net/) لـ .NET يتيح لك إضافة ملفات كبيرة (في هذه الحالة ملف فيديو كبير) عبر عملية تتضمن BLOB لتقليل استهلاك الذاكرة.

هذا المثال في Python يوضح كيفية إضافة ملف فيديو كبير عبر عملية BLOB إلى عرض تقديمي:

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# ينشئ عرض تقديمي جديد سيتم إضافة الفيديو إليه
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # دعنا نضيف الفيديو إلى العرض التقديمي - اخترنا سلوك KeepLocked لأننا لا نعتزم
        # الوصول إلى ملف "veryLargeVideo.avi".
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # يحفظ العرض التقديمي. أثناء إخراج عرض تقديمي كبير، يظل استهلاك الذاكرة منخفضًا من خلال دورة حياة كائن pres
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```

### **تصدير ملف كبير عبر BLOB من العرض التقديمي**
Aspose.Slides for Python via .NET يتيح لك تصدير ملفات كبيرة (مثل ملف صوت أو فيديو) عبر عملية تتضمن BLOB من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج ملف وسائط كبير من عرض تقديمي ولكنك لا تريد تحميل الملف إلى ذاكرة جهازك. عبر تصدير الملف عبر عملية BLOB، تحافظ على استهلاك الذاكرة منخفضًا.

الكود التالي في Python يوضح العملية الموصوفة:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
    # احفظ كل فيديو في ملف. لتفادي استهلاك الذاكرة العالي، نحتاج إلى مخزن مؤقت سيُستخدم
    # لنقل البيانات من تدفق فيديو العرض التقديمي إلى تدفق لملف فيديو تم إنشاؤه حديثًا.
    # byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

    # يتجول عبر مقاطع الفيديو
    index = 0
    # إذا لزم الأمر، يمكنك تطبيق نفس الخطوات على ملفات الصوت.
    for video in pres.videos:
        # يفتح تدفق فيديو العرض التقديمي. يرجى ملاحظة أننا تجنبنا عمدًا الوصول إلى الخصائص
        # مثل video.BinaryData - لأن هذه الخاصية تُعيد مصفوفة بايت تحتوي على الفيديو بالكامل، مما
        # يؤدي إلى تحميل البايتات إلى الذاكرة. نستخدم video.GetStream، الذي سيعيد Stream - ولا
        # يتطلب تحميل الفيديو بالكامل إلى الذاكرة.
        with video.get_stream() as presVideoStream:
            with open("video{index}.avi".format(index = index), "wb") as outputFileStream:
                buffer = presVideoStream.read(8 * 1024)
                bytesRead = len(buffer)
                while bytesRead > 0:
                    outputFileStream.write(buffer)
                    buffer = presVideoStream.read(8 * 1024)
                    bytesRead = len(buffer)

        index += 1
```

### **إضافة صورة كـ BLOB في العرض التقديمي**
باستخدام طرق من الواجهة [**IImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) والفئة [**ImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/)، يمكنك إضافة صورة كبيرة كـ تدفق لتُعامل كـ BLOB.

الكود التالي في Python يوضح كيفية إضافة صورة كبيرة عبر عملية BLOB:

```py
import aspose.slides as slides

# ينشئ عرض تقديمي جديد سيتم إضافة الصورة إليه.
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```

## **الذاكرة والعروض الكبيرة**

عادةً، لتحميل عرض تقديمي كبير، تحتاج الأجهزة إلى الكثير من الذاكرة المؤقتة. يتم تحميل كل محتوى العرض إلى الذاكرة ويتوقف استخدام الملف الأصلي الذي تم تحميل العرض منه.

اعتبر عرض PowerPoint كبير (large.pptx) يحتوي على ملف فيديو بحجم 1.5 غيغابايت. الطريقة التقليدية لتحميل العرض موضح في هذا الكود Python:

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
    pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

لكن هذه الطريقة تستهلك حوالي 1.6 غيغابايت من الذاكرة المؤقتة.

### **تحميل عرض تقديمي كبير كـ BLOB**

من خلال عملية تتضمن BLOB، يمكنك تحميل عرض تقديمي كبير باستخدام ذاكرة قليلة. يصف الكود Python التالي تنفيذًا يستخدم عملية BLOB لتحميل ملف عرض تقديمي كبير (large.pptx):

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
    pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

### **تغيير المجلد لملفات المؤقتة**

عند استخدام عملية BLOB، ينشئ جهازك ملفات مؤقتة في المجلد الافتراضي للملفات المؤقتة. إذا رغبت في حفظ الملفات المؤقتة في مجلد مختلف، يمكنك تعديل إعدادات التخزين باستخدام `temp_files_root_path`:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="معلومات" color="info" %}}

عند استخدام `temp_files_root_path`، لا يقوم Aspose.Slides بإنشاء مجلد تلقائيًا لتخزين الملفات المؤقتة. تحتاج إلى إنشاء المجلد يدويًا.

{{% /alert %}}

## **الأسئلة المتكررة**

**ما البيانات في عرض Aspose.Slides تُعامل كـ BLOB وتُتحكم بها خيارات BLOB؟**  
الكائنات الثنائية الكبيرة مثل الصور، الصوت، والفيديو تُعامل كـ BLOB. كما أن ملف العرض الكامل يتضمن معالجة BLOB عند تحميله أو حفظه. هذه الكائنات تخضع لسياسات BLOB التي تسمح لك بإدارة استهلاك الذاكرة وتحويل البيانات إلى ملفات مؤقتة عند الحاجة.

**أين يمكنني تكوين قواعد معالجة BLOB أثناء تحميل العرض التقديمي؟**  
استخدم [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) مع [BlobManagementOptions](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/). هناك يمكنك تحديد الحد الأقصى للذاكرة لـ BLOB، السماح أو عدم السماح بالملفات المؤقتة، اختيار مسار الجذر للملفات المؤقتة، وتحديد سلوك قفل المصدر.

**هل تؤثر إعدادات BLOB على الأداء، وكيف أوازن بين السرعة والذاكرة؟**  
نعم. إبقاء BLOB في الذاكرة يزيد السرعة ولكنه يرفع استهلاك RAM؛ تخفيض الحد الأقصى للذاكرة ينقل المزيد إلى الملفات المؤقتة، مما يقلل الذاكرة على حساب عمليات I/O إضافية. اضبط العتبة [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) للحصول على التوازن المناسب لبيئتك وحمولة العمل.

**هل تساعد خيارات BLOB عند فتح عروض تقديمية ضخمة جدًا (مثلاً بالججابت)?**  
نعم. تُصمم [BlobManagementOptions](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/) لهذه السيناريوهات: تمكين الملفات المؤقتة واستخدام قفل المصدر يمكن أن يقلل بشكل ملحوظ من استهلاك الذاكرة القمة ويثبت عملية المعالجة للعروض الضخمة.

**هل يمكنني استخدام سياسات BLOB عند التحميل من تدفقات بدلاً من ملفات القرص؟**  
نعم. تُطبق القواعد نفسها على التدفقات: يمكن لكائن العرض تملك قفل تدفق الإدخال (حسب وضع القفل المختار)، وتستخدم الملفات المؤقتة عندما يُسمح بذلك، مما يحافظ على استهلاك الذاكرة بصورة متنبأ بها أثناء المعالجة.