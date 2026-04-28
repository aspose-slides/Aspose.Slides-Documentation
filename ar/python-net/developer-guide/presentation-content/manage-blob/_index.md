---
title: إدارة BLOBs في العروض التقديمية باستخدام Python لاستخدام فعال للذاكرة
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
description: "إدارة بيانات BLOB في Aspose.Slides لـ Python عبر .NET لتبسيط عمليات ملفات PowerPoint و OpenDocument لمعالجة عروض تقديمية فعّالة."
---
## **حول BLOB**

**BLOB** (**كائن ثنائي كبير**) عادةً ما يكون عنصرًا كبيرًا (صورة، عرض تقديمي، مستند أو وسائط) يُحفظ بصيغ ثنائية. 

Aspose.Slides for Python via .NET يسمح لك باستخدام BLOBs للكائنات بطريقة تقلل استهلاك الذاكرة عند التعامل مع ملفات كبيرة. 

## **استخدام BLOB لتقليل استهلاك الذاكرة**

### **إضافة ملف كبير عبر BLOB إلى عرض تقديمي**

[Aspose.Slides](/slides/ar/python-net/) for .NET يسمح لك بإضافة ملفات كبيرة (في هذه الحالة، ملف فيديو كبير) عبر عملية تشمل BLOBs لتقليل استهلاك الذاكرة.

هذا المثال بلغة Python يوضح كيفية إضافة ملف فيديو كبير عبر عملية BLOB إلى عرض تقديمي:

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# إنشاء عرض تقديمي جديد سيتم إضافة الفيديو إليه
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # لنضيف الفيديو إلى العرض التقديمي - اخترنا سلوك KeepLocked لأننا
        # لا نعتزم الوصول إلى ملف "veryLargeVideo.avi".
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # يحفظ العرض التقديمي. أثناء إخراج عرض تقديمي كبير، يظل استهلاك الذاكرة
        # منخفضًا طوال دورة حياة كائن pres 
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```


### **تصدير ملف كبير عبر BLOB من العرض التقديمي**
Aspose.Slides for Python via .NET يسمح لك بتصدير ملفات كبيرة (في هذه الحالة، ملف صوت أو فيديو) عبر عملية تشمل BLOBs من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج ملف وسائط كبير من عرض تقديمي لكن لا تريد تحميل الملف إلى ذاكرة جهازك. عبر تصدير الملف عبر عملية BLOB، يمكنك الحفاظ على انخفاض استهلاك الذاكرة. 

هذا الكود بلغة Python يوضح العملية الموصوفة:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# سنحفظ كل فيديو في ملف. لتجنب استهلاك عالي للذاكرة، نحتاج إلى مخزن سيُستخدم
	# لنقل البيانات من تدفق فيديو العرض التقديمي إلى تدفق لملف فيديو تم إنشاؤه حديثًا.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# يتنقل عبر مقاطع الفيديو
    index = 0
    # إذا لزم الأمر، يمكنك تطبيق نفس الخطوات على ملفات الصوت. 
    for video in pres.videos:
		# يفتح تدفق فيديو العرض التقديمي. يرجى ملاحظة أننا تجنبنا عمدًا الوصول إلى الخصائص
		# مثل video.BinaryData - لأن هذه الخاصية تُعيد مصفوفة بايت تحتوي على الفيديو بالكامل، مما يؤدي إلى
		# تحميل البايتات إلى الذاكرة. نستخدم video.GetStream، والتي ستُعيد Stream - ولا
		# تحتاجنا إلى تحميل الفيديو كاملًا إلى الذاكرة.
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
باستخدام الأساليب من فئة [**ImageCollection**](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imagecollection/) يمكنك إضافة صورة كبيرة كتيار لتُعامل كـ BLOB. 

هذا الكود بلغة Python يوضح كيفية إضافة صورة كبيرة عبر عملية BLOB:

```py
import aspose.slides as slides

# ينشئ عرض تقديمي جديد ستتم إضافة الصورة إليه.
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```

## **الذاكرة والعروض التقديمية الكبيرة**

عادةً، لتحميل عرض تقديمي كبير، تحتاج أجهزة الكمبيوتر إلى كمية كبيرة من الذاكرة المؤقتة. يتم تحميل كل محتوى العرض إلى الذاكرة ويتوقف استخدام الملف (الذي تم تحميل العرض منه). 

اعتبر عرض PowerPoint كبير (large.pptx) يحتوي على ملف فيديو حجمه 1.5 GB. الطريقة القياسية لتحميل العرض موضحة في هذا الكود بلغة Python:

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

لكن هذه الطريقة تستهلك حوالي 1.6 GB من الذاكرة المؤقتة. 

### **تحميل عرض تقديمي كبير كـ BLOB**

من خلال العملية التي تشمل BLOB، يمكنك تحميل عرض تقديمي كبير مع استخدام قليلة من الذاكرة. يصف هذا الكود بلغة Python التنفيذ حيث يتم استخدام عملية BLOB لتحميل ملف عرض تقديمي كبير (large.pptx):

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

### **تغيير المجلد للملفات المؤقتة**

عند استخدام عملية BLOB، ينشئ جهازك ملفات مؤقتة في المجلد الافتراضي للملفات المؤقتة. إذا رغبت في حفظ الملفات المؤقتة في مجلد مختلف، يمكنك تعديل إعدادات التخزين باستخدام `temp_files_root_path`:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="Info" color="info" %}}
عند استخدام `temp_files_root_path`، لا يقوم Aspose.Slides بإنشاء مجلد تلقائيًا لتخزين الملفات المؤقتة. عليك إنشاء المجلد يدويًا. 
{{% /alert %}}

### **تحرير كائنات العرض لتفريغ الذاكرة**

عند معالجة عروض تقديمية كبيرة، تأكد من تحرير كائن `Presentation` بشكل صحيح حتى يتم تحرير الذاكرة التي احتلتها. الطريقة الموصى بها هي استخدام مدير السياق (`with slides.Presentation(...) as presentation:`) كما هو موضح في الأمثلة أعلاه؛ فهو يغلق العرض تلقائيًا ويحرر الموارد غير المدارية عند خروج الكتلة.

إذا أنشأت عرضًا تقديميًا دون كتلة `with`، استدعِ `presentation.dispose()` صراحةً بعد الانتهاء من استخدامه، وأزل أي مراجع متبقية حتى يتمكن جامع القمامة في Python من استعادة الذاكرة.

```py
import aspose.slides as slides

presentation = slides.Presentation("large.pptx")
# ...معالجة العرض التقديمي...
presentation.save("large.pdf", slides.export.SaveFormat.PDF)
# تحرير الموارد بشكل صريح.
presentation.dispose()
```

## **الأسئلة الشائعة**

**ما البيانات في عرض Aspose.Slides التي تُعامل كـ BLOB وتُتحكم فيها خيارات BLOB؟**

الكائنات الثنائية الكبيرة مثل الصور، الصوت والفيديو تُعامل كـ BLOB. كذلك ملف العرض الكامل يتضمن معالجة BLOB عند تحميله أو حفظه. تُدار هذه الكائنات بواسطة سياسات BLOB التي تسمح لك بإدارة استهلاك الذاكرة وتحويلها إلى ملفات مؤقتة عند الحاجة.

**أين يمكنني تكوين قواعد معالجة BLOB أثناء تحميل العرض؟**

استخدم [LoadOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/) مع [BlobManagementOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides/blobmanagementoptions/). هناك يمكنك ضبط الحد الأقصى للذاكرة لكائنات BLOB، السماح أو منع الملفات المؤقتة، اختيار مسار الجذر للملفات المؤقتة، وتحديد سلوك قفل المصدر.

**هل تؤثر إعدادات BLOB على الأداء، وكيف أوازن بين السرعة والذاكرة؟**

نعم. الحفاظ على BLOB في الذاكرة يعظم السرعة لكنه يزيد استهلاك RAM؛ خفض الحد الأقصى للذاكرة ينقل المزيد إلى الملفات المؤقتة، مما يقلل الذاكرة مقابل زيادة عمليات الإدخال/الإخراج. اضبط عتبة [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/ar/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) للحصول على التوازن المناسب لحمل عملك وبيئتك.

**هل تساعد خيارات BLOB عند فتح عروض تقديمية ضخمة جدًا (مثلاً عدة جيجابايت)؟**

نعم. تم تصميم [BlobManagementOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides/blobmanagementoptions/) لهذا النوع من السيناريوهات: تفعيل الملفات المؤقتة واستخدام قفل المصدر يمكن أن يقلل بشكل كبير من أقصى استخدام للRAM ويُثبت عملية المعالجة للعروض الضخمة.

**هل يمكنني استخدام سياسات BLOB عند التحميل من التيارات بدلاً من ملفات القرص؟**

نعم. القواعد نفسها تنطبق على التيارات: يمكن لكائن العرض امتلاك القفل للتيار المدخل (حسب وضع القفل المختار)، وتُستخدم الملفات المؤقتة عندما يُسمح بذلك، مما يُحافظ على استهلاك الذاكرة بصورة متوقعة أثناء المعالجة.