---
title: إدارة BLOBs في العروض التقديمية باستخدام Python لاستخدام الذاكرة بكفاءة
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
description: "إدارة بيانات BLOB في Aspose.Slides لبايثون عبر .NET لتبسيط عمليات ملفات PowerPoint و OpenDocument من أجل معالجة عروض تقديمية بكفاءة."
---
## **نظرة عامة**

Aspose.Slides توفر معالجة معتمدة على BLOB للبيانات الثنائية الكبيرة في العروض التقديمية لتقليل استهلاك الذاكرة عند التعامل مع الصور الكبيرة، والصوت، والفيديو، وملفات العرض التقديمي.

توضح هذه المقالة كيفية استخدام المعالجة المعتمدة على BLOB لإضافة وسائط كبيرة إلى عرض تقديمي، وتصدير وسائط كبيرة من عرض تقديمي، وتحميل عروض تقديمية كبيرة بشكل أكثر كفاءة. كما تشرح كيفية استخدام الملفات المؤقتة أثناء المعالجة وكيفية تغيير المجلد المستخدم لتخزينها.

## **حول BLOB**

**BLOB** (**Binary Large Object**) هو عادةً عنصر كبير (صورة، عرض تقديمي، مستند، أو وسائط) محفوظ بصيغة ثنائية.

Aspose.Slides for Python via .NET يتيح لك استخدام BLOBs للكائنات بطريقة تقلل من استهلاك الذاكرة عندما تكون الملفات الكبيرة متورطة.

## **استخدام BLOB لتقليل استهلاك الذاكرة**

### **إضافة ملف كبير عبر BLOB إلى عرض تقديمي**

[Aspose.Slides](/slides/ar/python-net/) for .NET يسمح لك بإضافة ملفات كبيرة (في هذه الحالة، ملف فيديو كبير) من خلال عملية تشمل BLOBs لتقليل استهلاك الذاكرة.

هذا المثال بلغة Python يوضح كيفية إضافة ملف فيديو كبير عبر عملية BLOB إلى عرض تقديمي:

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# ينشئ عرض تقديمي جديد سيتم إضافة الفيديو إليه
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # لنضيف الفيديو إلى العرض التقديمي - اخترنا سلوك KeepLocked لأننا
        # لا ننوي الوصول إلى ملف "veryLargeVideo.avi".
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # يحفظ العرض التقديمي. بينما يتم إخراج عرض تقديمي كبير، يبقى استهلاك الذاكرة
        # منخفضًا طوال دورة حياة كائن pres 
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```

### **تصدير ملف كبير عبر BLOB من عرض تقديمي**
Aspose.Slides for Python via .NET يتيح لك تصدير ملفات كبيرة (في هذه الحالة، ملف صوت أو فيديو) من خلال عملية تشمل BLOBs من العروض التقديمية. على سبيل المثال، قد تحتاج لاستخراج ملف وسائط كبير من عرض تقديمي دون تحميله إلى ذاكرة جهازك. عبر تصدير الملف عبر عملية BLOB، تحافظ على انخفاض استهلاك الذاكرة.

هذا الكود بلغة Python يوضح العملية الموصوفة:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# لنقُم بحفظ كل فيديو في ملف. لتجنب استهلاك الذاكرة العالي، نحتاج إلى مخزن سيتم استخدامه
	# لنقل البيانات من تدفق فيديو العرض التقديمي إلى تدفق لملف فيديو تم إنشاؤه حديثًا.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# يتنقل عبر مقاطع الفيديو
    index = 0
    # إذا لزم الأمر، يمكنك تطبيق الخطوات نفسها على ملفات الصوت. 
    for video in pres.videos:
		# يفتح تدفق فيديو العرض التقديمي. يرجى ملاحظة أننا تجنبنا عمدًا الوصول إلى الخصائص
		# مثل video.BinaryData - لأن هذه الخاصية تُرجع مصفوفة بايت تحتوي على فيديو كامل، مما
		# يتسبب في تحميل البايتات إلى الذاكرة. نستخدم video.GetStream، التي تُعيد Stream - ولا
		#  تتطلب منا تحميل الفيديو بالكامل إلى الذاكرة.
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

### **إضافة صورة كـ BLOB في عرض تقديمي**
باستخدام الأساليب من فئة [**ImageCollection**](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imagecollection/)، يمكنك إضافة صورة كبيرة كتيار لتُعامل كـ BLOB.

هذا الكود بلغة Python يوضح كيفية إضافة صورة كبيرة عبر عملية BLOB:

```py
import aspose.slides as slides

# ينشئ عرضًا تقديميًا جديدًا سيتم إضافة الصورة إليه.
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```

## **الذاكرة والعروض التقديمية الكبيرة**

عادةً، لتحميل عرض تقديمي كبير، تحتاج أجهزة الكمبيوتر إلى الكثير من الذاكرة المؤقتة. يتم تحميل جميع محتويات العرض إلى الذاكرة ويتوقف استخدام الملف الأصلي الذي تم تحميل العرض منه.

اعتبر عرض PowerPoint كبير (large.pptx) يحتوي على ملف فيديو بحجم 1.5 جيجابايت. الطريقة القياسية لتحميل العرض موضحة في هذا الكود Python:

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

لكن هذه الطريقة تستهلك حوالي 1.6 جيجابايت من الذاكرة المؤقتة.

### **تحميل عرض تقديمي كبير كـ BLOB**

من خلال العملية التي تشمل BLOB، يمكنك تحميل عرض تقديمي كبير مع استخدام القليل من الذاكرة. يصف هذا الكود Python التنفيذ حيث تُستخدم عملية BLOB لتحميل ملف عرض تقديمي كبير (large.pptx):

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

عند استخدام عملية BLOB، ينشئ جهازك ملفات مؤقتة في المجلد الافتراضي للملفات المؤقتة. إذا رغبت في حفظ الملفات المؤقتة في مجلد مختلف، يمكنك تغيير إعدادات التخزين باستخدام `temp_files_root_path`:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="Info" color="info" %}}
عند استخدام `temp_files_root_path`، لا تقوم Aspose.Slides بإنشاء مجلد لتخزين الملفات المؤقتة تلقائيًا. عليك إنشاء المجلد يدويًا.
{{% /alert %}}

### **تخلص من كائنات Presentation لتحرير الذاكرة**

عند معالجة عروض تقديمية كبيرة، تأكد من أن كائن [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) يتم التخلص منه بشكل صحيح حتى تُحرر الذاكرة التي كان يشغلها. الطريقة المفضلة هي استخدام مدير السياق (`with slides.Presentation(...) as presentation:`) كما هو موضح في الأمثلة أعلاه؛ فهو يغلق العرض تلقائيًا ويحرّر الموارد غير المدارية عند خروج الكتلة.

إذا أنشأت عرضًا تقديميًا دون كتلة `with`، استدعِ `presentation.dispose()` صراحةً بعد الانتهاء من استخدامه، وأزل أي مراجع متبقية حتى يتمكن جامع القمامة في Python من استعادة الذاكرة.

```py
import aspose.slides as slides

presentation = slides.Presentation("large.pptx")

# ...معالجة العرض التقديمي...
presentation.save("large.pdf", slides.export.SaveFormat.PDF)

# تحرير الموارد صراحةً.
presentation.dispose()
```

## **الأسئلة الشائعة**

**ما هي البيانات في عرض Aspose.Slides التي تُعامل كـ BLOB وتُتحكم بها خيارات BLOB؟**

الكائنات الثنائية الكبيرة مثل الصور، والصوت، والفيديو تُعامل كـ BLOB. الملف الكامل للعرض التقديمي أيضًا يتضمن معالجة BLOB عند تحميله أو حفظه. تُحكم هذه الكائنات بواسطة سياسات BLOB التي تسمح لك بإدارة استخدام الذاكرة وتحويل البيانات إلى ملفات مؤقتة عند الحاجة.

**أين يمكنني تكوين قواعد معالجة BLOB أثناء تحميل العرض التقديمي؟**

استخدم [LoadOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/) مع [BlobManagementOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides/blobmanagementoptions/). هناك يمكنك ضبط حد الذاكرة المتاح لـ BLOB، السماح أو منع إنشاء ملفات مؤقتة، اختيار المسار الجذري للملفات المؤقتة، وتحديد سلوك قفل المصدر.

**هل تؤثر إعدادات BLOB على الأداء، وكيف أوازن بين السرعة والذاكرة؟**

نعم. إبقاء BLOB في الذاكرة يعظم السرعة لكنه يزيد استهلاك RAM؛ خفض حد الذاكرة يحمّل المزيد إلى الملفات المؤقتة، مما يقلل الـ RAM على حساب زيادة عمليات الإدخال/الإخراج. اضبط حد [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/ar/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) لتحقيق التوازن المناسب لحمولتك والبيئة التي تعمل فيها.

**هل تساعد خيارات BLOB عند فتح عروض تقديمية ضخمة للغاية (مثل الغيغابايت)؟**

نعم. تم تصميم [BlobManagementOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides/blobmanagementoptions/) لهذه السيناريوهات: تمكين الملفات المؤقتة واستخدام قفل المصدر يمكن أن يقلل بشكل كبير من الذروة في استهلاك RAM ويستقر عملية المعالجة لعروض تقديمية ضخمة جدًا.

**هل يمكنني استخدام سياسات BLOB عند التحميل من التدفقات بدلاً من ملفات القرص؟**

نعم. تنطبق القواعد نفسها على التدفقات: يمكن للعرض التقديمي امتلاك القفل على تدفق الإدخال (اعتمادًا على وضع القفل المختار)، وتُستخدم الملفات المؤقتة عند السماح بذلك، مما يحافظ على استهلاك الذاكرة بشكل متوقع أثناء المعالجة.