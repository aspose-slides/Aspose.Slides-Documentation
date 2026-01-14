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
description: "إدارة بيانات BLOB في Aspose.Slides لPython عبر .NET لتبسيط عمليات ملفات PowerPoint و OpenDocument لتحسين معالجة العروض التقديمية بفعالية."
---

## **حول BLOB**

**BLOB** (**Binary Large Object**) هو عادةً عنصر كبير (صورة، عرض تقديمي، مستند أو وسائط) يُحفظ بصيغٍ ثنائية.

يتيح لك Aspose.Slides for Python via .NET استخدام BLOBs للكائنات بطريقة تقلل من استهلاك الذاكرة عندما تكون الملفات الكبيرة متورطة.

## **استخدام BLOB لتقليل استهلاك الذاكرة**

### **إضافة ملف كبير عبر BLOB إلى عرض تقديمي**

[Aspose.Slides](/slides/ar/python-net/) for .NET يتيح لك إضافة ملفات كبيرة (في هذه الحالة، ملف فيديو كبير) عبر عملية تتضمن BLOBs لتقليل استهلاك الذاكرة.

هذا النص البرمجي ببايثون يوضح لك كيفية إضافة ملف فيديو كبير عبر عملية BLOB إلى عرض تقديمي:
```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# ينشئ عرض تقديمي جديد سيتم إضافة الفيديو إليه
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # دعنا نضيف الفيديو إلى العرض التقديمي - اخترنا سلوك KeepLocked لأننا
        # لا نعتزم الوصول إلى ملف "veryLargeVideo.avi".
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # يحفظ العرض التقديمي. بينما يتم إنتاج عرض تقديمي كبير، يبقى استهلاك الذاكرة
        # منخفضًا طوال دورة حياة كائن pres 
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```



### **تصدير ملف كبير عبر BLOB من العرض التقديمي**
Aspose.Slides for Python via .NET يتيح لك تصدير ملفات كبيرة (في هذه الحالة، ملف صوت أو فيديو) عبر عملية تتضمن BLOBs من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج ملف وسائط كبير من عرض تقديمي لكن لا تريد تحميل الملف في ذاكرة جهاز الكمبيوتر. عبر تصدير الملف عبر عملية BLOB، يمكنك الحفاظ على استهلاك الذاكرة منخفضًا.

هذا الكود ببايثون يوضح العملية المذكورة:
```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# دعونا نحفظ كل فيديو في ملف. لمنع استهلاك عالي للذاكرة، نحتاج إلى مخزن مؤقت سيُستخدم
	# لنقل البيانات من تدفق فيديو العرض التقديمي إلى تدفق لملف فيديو تم إنشاؤه حديثًا.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# يتكرر عبر الفيديوهات
    index = 0
    # إذا لزم الأمر، يمكنك تطبيق الخطوات نفسها على ملفات الصوت. 
    for video in pres.videos:
		# يفتح تدفق فيديو العرض التقديمي. يرجى ملاحظة أننا تجنبنا عمدًا الوصول إلى الخصائص
		# مثل video.BinaryData - لأن هذه الخاصية تُعيد مصفوفة بايت تحتوي على فيديو كامل، مما يؤدي بعد ذلك
		# إلى تحميل البايتات في الذاكرة. نستخدم video.GetStream، الذي سيُعيد Stream - ولا يتطلب
		#  تحميل الفيديو بالكامل في الذاكرة.
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
باستخدام الأساليب الموجودة في فئة [**ImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/)، يمكنك إضافة صورة كبيرة كتيار لتعامل معها كـ BLOB.

هذا الكود ببايثون يوضح لك كيفية إضافة صورة كبيرة عبر عملية BLOB:
```py
import aspose.slides as slides

# ينشئ عرض تقديمي جديد سيتم إضافة الصورة إليه.
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```


## **الذاكرة والعروض التقديمية الكبيرة**

عادةً، لتحميل عرض تقديمي كبير، تحتاج الحواسيب إلى الكثير من الذاكرة المؤقتة. يتم تحميل كل محتوى العرض إلى الذاكرة ويتوقف استخدام الملف (الذي تم تحميل العرض منه).

تخيل عرض تقديمي PowerPoint كبير (large.pptx) يحتوي على ملف فيديو بحجم 1.5 جيجابايت. الطريقة القياسية لتحميل العرض موضحة في هذا الكود ببايثون:
```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```


لكن هذه الطريقة تستنزف حوالي 1.6 جيجابايت من الذاكرة المؤقتة.

### **تحميل عرض تقديمي كبير كـ BLOB**

من خلال العملية التي تتضمن BLOB، يمكنك تحميل عرض تقديمي كبير مع استهلاك قليل للذاكرة. يصف هذا الكود ببايثون التنفيذ حيث تُستخدم عملية BLOB لتحميل ملف عرض تقديمي كبير (large.pptx):
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

عند استخدام عملية BLOB، يقوم جهازك بإنشاء ملفات مؤقتة في المجلد الافتراضي للملفات المؤقتة. إذا أردت الاحتفاظ بالملفات المؤقتة في مجلد مختلف، يمكنك تغيير إعدادات التخزين باستخدام `temp_files_root_path`:
```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```


{{% alert title="Info" color="info" %}}

عند استخدام `temp_files_root_path`، لا يقوم Aspose.Slides بإنشاء مجلد لتخزين الملفات المؤقتة تلقائيًا. عليك إنشاء المجلد يدويًا.

{{% /alert %}}

## **الأسئلة الشائعة**

**ما هي البيانات في عرض Aspose.Slides التي تُعامل كـ BLOB وتُتحكم فيها خيارات BLOB؟**

الكائنات الثنائية الكبيرة مثل الصور، الصوت والفيديو تُعامل كـ BLOB. ملف العرض بالكامل أيضًا يتضمن معالجة BLOB عندما يتم تحميله أو حفظه. تُحكم هذه الكائنات بسياسات BLOB التي تسمح لك بإدارة استخدام الذاكرة وتحويله إلى ملفات مؤقتة عند الحاجة.

**أين يمكنني تكوين قواعد معالجة BLOB أثناء تحميل العرض التقديمي؟**

استخدم [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) مع [BlobManagementOptions](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/). هناك يمكنك تحديد الحد الأقصى للذاكرة لكائنات BLOB، السماح أو عدم السماح بالملفات المؤقتة، اختيار المسار الجذري للملفات المؤقتة، وتحديد سلوك قفل المصدر.

**هل تؤثر إعدادات BLOB على الأداء، وكيف يمكن موازنة السرعة مقابل الذاكرة؟**

نعم. إبقاء BLOB في الذاكرة يعظم السرعة لكنه يزيد من استهلاك RAM؛ تقليل الحد الأقصى للذاكرة يوجه المزيد من العمل إلى الملفات المؤقتة، مما يقلل من RAM لكن يكلف المزيد من عمليات الإدخال/الإخراج. اضبط عتبة [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) للوصول إلى التوازن المناسب لحمل عملك وبيئتك.

**هل تساعد خيارات BLOB عند فتح عروض تقديمية ضخمة جدًا (مثلاً بالجيجابايت)؟**

نعم. تم تصميم [BlobManagementOptions](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/) لهذه السيناريوهات: تمكين الملفات المؤقتة واستخدام قفل المصدر يمكن أن يقلل بشكل كبير من استهلاك RAM القمة ويُستقر عملية المعالجة لعروض تقديمية ضخمة جدًا.

**هل يمكنني استخدام سياسات BLOB عند التحميل من التدفقات بدلاً من ملفات القرص؟**

نعم. نفس القواعد تنطبق على التدفقات: يمكن لكائن العرض التقديمي امتلاك القفل على تدفق الإدخال (حسب وضع القفل المختار)، وتُستخدم الملفات المؤقتة عندما يُسمح بذلك، مع الحفاظ على استهلاك الذاكرة متوقعًا أثناء المعالجة.