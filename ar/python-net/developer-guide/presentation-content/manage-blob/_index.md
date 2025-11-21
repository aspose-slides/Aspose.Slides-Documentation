---
title: إدارة كائنات BLOB في العروض التقديمية باستخدام Python لاستخدام ذكي للذاكرة
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
description: "إدارة بيانات BLOB في Aspose.Slides لـ Python عبر .NET لتبسيط عمليات ملفات PowerPoint و OpenDocument لأداء فعال في معالجة العروض التقديمية."
---

## **حول BLOB**

**BLOB** (**Binary Large Object**) عادةً ما يكون عنصرًا كبيرًا (صورة، عرض تقديمي، وثيقة، أو وسائط) محفوظًا بصيغ ثنائية.

Aspose.Slides for Python via .NET يتيح لك استخدام BLOB للأشياء بطريقة تقلل استهلاك الذاكرة عندما تكون الملفات الكبيرة متورطة.

## **استخدام BLOB لتقليل استهلاك الذاكرة**

### **إضافة ملف كبير عبر BLOB إلى عرض تقديمي**

[Aspose.Slides](/slides/ar/python-net/) for .NET يتيح لك إضافة ملفات كبيرة (في هذه الحالة ملف فيديو كبير) عبر عملية تشمل BLOB لتقليل استهلاك الذاكرة.

هذا المثال في Python يوضح كيفية إضافة ملف فيديو كبير عبر عملية BLOB إلى عرض تقديمي:
```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# إنشاء عرض تقديمي جديد سيتم إضافة الفيديو إليه
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # لنقم بإضافة الفيديو إلى العرض التقديمي - اخترنا سلوك KeepLocked لأنه
        # ليس لدينا نية للوصول إلى ملف "veryLargeVideo.avi".
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # يحفظ العرض التقديمي. بينما يتم إنشاء عرض تقديمي كبير، يبقى استهلاك الذاكرة
        # منخفضًا طوال دورة حياة كائن pres 
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```


### **تصدير ملف كبير عبر BLOB من العرض التقديمي**
Aspose.Slides for Python via .NET يتيح لك تصدير ملفات كبيرة (في هذه الحالة ملف صوتي أو فيديو) عبر عملية تشمل BLOB من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج ملف وسائط كبير من عرض تقديمي دون تحميله إلى ذاكرة جهاز الكمبيوتر. من خلال تصدير الملف عبر عملية BLOB، تحافظ على انخفاض استهلاك الذاكرة.

هذا الكود في Python يوضح العملية المذكورة:
```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# لنحفظ كل فيديو في ملف. لتجنب استهلاك الذاكرة العالي، نحتاج إلى مخزن وسيتم استخدامه
	# لنقل البيانات من تدفق الفيديو في العرض إلى تدفق لملف فيديو تم إنشاؤه حديثًا.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# يتكرر عبر الفيديوهات
    index = 0
    # إذا لزم الأمر، يمكنك تطبيق نفس الخطوات على ملفات الصوت. 
    for video in pres.videos:
		# يفتح تدفق فيديو العرض. يرجى ملاحظة أننا تعمدنا تجنب الوصول إلى الخصائص
		# مثل video.BinaryData - لأن هذه الخاصية تُرجع مصفوفة بايت تحتوي على فيديو كامل، مما
		# يؤدي إلى تحميل البايتات إلى الذاكرة. نستخدم video.GetStream، الذي سيُرجع Stream - ولا
		#  يتطلب منا تحميل الفيديو كاملًا إلى الذاكرة.
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
باستخدام الأساليب من واجهة [**IImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) و[**ImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) يمكنك إضافة صورة كبيرة كتيار لتُعامل كـ BLOB.

هذا الكود في Python يوضح كيفية إضافة صورة كبيرة عبر عملية BLOB:
```py
import aspose.slides as slides

# إنشاء عرض تقديمي جديد ستتم إضافة الصورة إليه.
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```


## **الذاكرة والعروض التقديمية الكبيرة**

عادةً، لتحميل عرض تقديمي كبير، تحتاج الحواسيب إلى الكثير من الذاكرة المؤقتة. يتم تحميل كل محتوى العرض إلى الذاكرة ويتوقف استخدام الملف الذي تم تحميل العرض منه.

تخيل عرض PowerPoint كبير (large.pptx) يحتوي على ملف فيديو بحجم 1.5 جيجابايت. الطريقة التقليدية لتحميل العرض موضحة في هذا الكود Python:
```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```


لكن هذه الطريقة تستهلك حوالي 1.6 جيجابايت من الذاكرة المؤقتة.

### **تحميل عرض تقديمي كبير كـ BLOB**

من خلال عملية تشمل BLOB، يمكنك تحميل عرض تقديمي كبير مع استخدام ذاكرة قليلة. يوضح هذا الكود Python كيفية تنفيذ ذلك باستخدام عملية BLOB لتحميل ملف عرض تقديمي كبير (large.pptx):
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

عند استخدام عملية BLOB، ينشئ حاسوبك ملفات مؤقتة في المجلد الافتراضي للملفات المؤقتة. إذا أردت حفظ الملفات المؤقتة في مجلد مختلف، يمكنك تغيير إعدادات التخزين باستخدام `temp_files_root_path`:
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

## **الأسئلة المتكررة**

**ما البيانات في عرض Aspose.Slides التي تُعامل كـ BLOB وتتحكم فيها خيارات BLOB؟**

الكائنات الثنائية الكبيرة مثل الصور، الصوت، والفيديو تُعامل كـ BLOB. ملف العرض بالكامل أيضًا يتضمن معالجة BLOB عند تحميله أو حفظه. تُحكم هذه الكائنات بسياسات BLOB التي تتيح لك إدارة استهلاك الذاكرة وتحويل البيانات إلى ملفات مؤقتة عند الحاجة.

**أين يمكنني تكوين قواعد معالجة BLOB أثناء تحميل العرض؟**

استخدم [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) مع [BlobManagementOptions](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/). هناك يمكنك ضبط الحد الأقصى للذاكرة لكائنات BLOB، السماح أو عدم السماح بالملفات المؤقتة، اختيار المسار الجذري للملفات المؤقتة، وتحديد سلوك قفل المصدر.

**هل تؤثر إعدادات BLOB على الأداء، وكيف يمكن موازنة السرعة مقابل الذاكرة؟**

نعم. إبقاء BLOB في الذاكرة يزيد السرعة لكن يستهلك RAM أكثر؛ خفض الحد الأقصى للذاكرة ينقل المزيد إلى الملفات المؤقتة، مما يقلل استهلاك RAM على حساب عمليات إدخال/إخراج إضافية. اضبط العتبة [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) لتحقيق التوازن المناسب لعملك وبيئتك.

**هل تساعد خيارات BLOB عند فتح عروض تقديمية ضخمة جدًا (مثلاً جيجابايت)؟**

نعم. تم تصميم [BlobManagementOptions](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/) لهذه السيناريوهات: تمكين الملفات المؤقتة واستخدام قفل المصدر يمكن أن يقلل بشكل كبير من أقصى استهلاك للذاكرة RAM ويثبت عملية المعالجة لعروض كبيرة جدًا.

**هل يمكنني استخدام سياسات BLOB عند التحميل من التدفقات بدلاً من ملفات القرص؟**

نعم. القواعد نفسها تنطبق على التدفقات: يمكن لعنصر العرض امتلاك القفل وإغلاق تدفق الإدخال (حسب وضع القفل المختار)، وتُستخدم الملفات المؤقتة عندما يُسمح بذلك، مما يحافظ على توقع استهلاك الذاكرة أثناء المعالجة.