---
title: إدارة Blob
type: docs
weight: 10
url: /ar/python-net/manage-blob/
keywords: "إضافة Blob، تصدير Blob، إضافة صورة كـ Blob، عرض PowerPoint، بايثون، Aspose.Slides للبايثون عبر .NET"
description: "إضافة Blob إلى عرض PowerPoint في بايثون. تصدير Blob. إضافة صورة كـ Blob"
---

### **حول BLOB**

**BLOB** (**كائن ثنائي كبير**) عادة ما يكون عنصر كبير (صورة، عرض، مستند، أو وسائط) محفوظ بتنسيقات ثنائية.

تتيح لك Aspose.Slides للبايثون عبر .NET استخدام BLOBs للأشياء بطريقة تقلل من استهلاك الذاكرة عند التعامل مع ملفات كبيرة.

# **استخدام BLOB لتقليل استهلاك الذاكرة**

### **إضافة ملف كبير عبر BLOB إلى عرض**

تتيح لك [Aspose.Slides](/slides/ar/python-net/) لـ .NET إضافة ملفات كبيرة (في هذه الحالة، ملف فيديو كبير) من خلال عملية تشمل BLOBs لتقليل استهلاك الذاكرة.

بينما توضح لك هذه السطور البرمجية في بايثون كيفية إضافة ملف فيديو كبير عبر عملية BLOB إلى عرض:

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# ينشئ عرضًا جديدًا سيتم إضافة الفيديو إليه
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # لنضف الفيديو إلى العرض - اخترنا سلوك KeepLocked لأننا لا نعتزم
        # الوصول إلى ملف "veryLargeVideo.avi".
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # يحفظ العرض. بينما يتم إخراج عرض كبير، يبقى استهلاك الذاكرة
        # منخفضًا خلال دورة حياة كائن pres 
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```


### **تصدير ملف كبير عبر BLOB من العرض**
تتيح لك Aspose.Slides للبايثون عبر .NET تصدير الملفات الكبيرة (في هذه الحالة، ملف صوت أو فيديو) من خلال عملية تشمل BLOBs من العروض. على سبيل المثال، قد تحتاج إلى استخراج ملف وسائط كبير من عرض ولكن لا ترغب في تحميل الملف إلى ذاكرة جهاز الكمبيوتر الخاص بك. من خلال تصدير الملف عبر عملية BLOB، يمكنك الحفاظ على استهلاك الذاكرة منخفضًا.

هذا الكود في بايثون يوضح العملية الموصوفة:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# لنحفظ كل فيديو في ملف. لمنع ارتفاع استهلاك الذاكرة، نحتاج إلى مخزن بيانات سيتم استخدامه
	# لنقل البيانات من دفق فيديو العرض إلى دفق لملف فيديو تم إنشاؤه حديثًا.
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# يتكرر في الفيديوهات
    index = 0
    # إذا لزم الأمر، يمكنك تطبيق نفس الخطوات لملفات الصوت. 
    for video in pres.videos:
		# يفتح دفق فيديو العرض. يرجى ملاحظة أننا تجنبنا عن عمد الوصول إلى خصائص
		# مثل video.BinaryData - لأن هذه الخصائص تعيد مصفوفة بايت تحتوي على فيديو كامل، مما يؤدي بعد ذلك
		# إلى تحميل بايت إلى الذاكرة. نحن نستخدم video.GetStream، الذي سيعيد Stream - ولا يتطلب
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

### **إضافة صورة كـ BLOB في العرض**
مع الطرق من واجهة [**IImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) وفئة [**ImageCollection** ](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) ، يمكنك إضافة صورة كبيرة كتيار ليتم اعتبارها كـ BLOB.

يوضح لك هذا الكود في بايثون كيفية إضافة صورة كبيرة عبر عملية BLOB:

```py
import aspose.slides as slides

# ينشئ عرضًا جديدًا سيتم إضافة الصورة إليه.
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```

## **الذاكرة والعروض الكبيرة**

عادةً، لتحميل عرض كبير، تتطلب أجهزة الكمبيوتر الكثير من الذاكرة المؤقتة. يتم تحميل كل محتوى العرض في الذاكرة ويتوقف استخدام الملف (الذي تم تحميل العرض منه) عن العمل.

اعتبر عرض PowerPoint كبير (large.pptx) يحتوي على ملف فيديو بحجم 1.5 غيغابايت. الطريقة القياسية لتحميل العرض موصوفة في كود بايثون هذا:

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

لكن هذه الطريقة تستهلك حوالي 1.6 غيغابايت من الذاكرة المؤقتة.

### **تحميل عرض كبير كـ BLOB**

من خلال العملية التي تشمل BLOB، يمكنك تحميل عرض كبير مع استخدام ذاكرة قليلة. يصف كود بايثون هذا التنفيذ الذي يتم فيه استخدام عملية BLOB لتحميل ملف عرض كبير (large.pptx):

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

#### **تغيير المجلد للملفات المؤقتة**

عند استخدام عملية BLOB، يقوم جهاز الكمبيوتر الخاص بك بإنشاء ملفات مؤقتة في المجلد الافتراضي للملفات المؤقتة. إذا كنت ترغب في الاحتفاظ بالملفات المؤقتة في مجلد مختلف، يمكنك تغيير إعدادات التخزين باستخدام `temp_files_root_path`:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="معلومات" color="info" %}}

عند استخدام `temp_files_root_path`، لا يقوم Aspose.Slides بإنشاء مجلد تلقائيًا لتخزين الملفات المؤقتة. يجب عليك إنشاء المجلد يدويًا.

{{% /alert %}}