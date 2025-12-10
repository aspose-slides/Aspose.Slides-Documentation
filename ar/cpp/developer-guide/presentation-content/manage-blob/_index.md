---
title: إدارة BLOBات العرض التقديمي في C++ لاستخدام الذاكرة الفعال
linktitle: إدارة BLOB
type: docs
weight: 10
url: /ar/cpp/manage-blob/
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
- C++
- Aspose.Slides
description: "إدارة بيانات BLOB في Aspose.Slides للغة C++ لتبسيط عمليات ملفات PowerPoint و OpenDocument لتحقيق معالجة عروض تقديمية فعّالة."
---

## **حول BLOB**

**BLOB** (**Binary Large Object**) عادةً ما يكون عنصرًا كبيرًا (صورة، عرض تقديمي، مستند، أو وسائط) يتم حفظه بصيغ ثنائية. 

Aspose.Slides for C++ يتيح لك استخدام BLOBs للكائنات بطريقة تقلل من استهلاك الذاكرة عندما تكون الملفات الكبيرة متضمنة. 

## **استخدام BLOB لتقليل استهلاك الذاكرة**

### **إضافة ملف كبير عبر BLOB إلى عرض تقديمي**

[Aspose.Slides](/slides/ar/cpp/) for C++ يتيح لك إضافة ملفات كبيرة (في هذه الحالة، ملف فيديو كبير) عبر عملية تتضمن BLOBs لتقليل استهلاك الذاكرة.

هذا الكود C++ يوضح لك كيفية إضافة ملف فيديو كبير عبر عملية BLOB إلى عرض تقديمي:
```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// ينشئ عرض تقديمي جديد سيُضاف إليه الفيديو
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// لنضيف الفيديو إلى العرض التقديمي - اخترنا سلوك KeepLocked لأننا
// لا ننوي الوصول إلى ملف "veryLargeVideo.avi" الملف.
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// يحفظ العرض التقديمي. بينما يتم إخراج عرض تقديمي كبير، يظل استهلاك الذاكرة
// منخفضًا طوال دورة حياة كائن pres
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```


### **تصدير ملف كبير عبر BLOB من عرض تقديمي**
Aspose.Slides for C++ يتيح لك تصرف ملفات كبيرة (في هذه الحالة، ملف صوتي أو فيديو) عبر عملية تتضمن BLOBs من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج ملف وسائط كبير من عرض تقديمي لكن لا تريد تحميل الملف إلى ذاكرة جهاز الكمبيوتر الخاص بك. من خلال تصدير الملف عبر عملية BLOB، يمكنك الحفاظ على استهلاك الذاكرة منخفضًا. 

هذا الكود C++ يوضح العملية الموضحة:
```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// يخلق كائنًا للعرض التقديمي ويقفل ملف "hugePresentationWithAudiosAndVideos.pptx".
auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// لنُحفظ كل فيديو في ملف. لمنع استهلاك عالي للذاكرة، نحتاج إلى مخزن سيتم استخدامه
// لنقل البيانات من تدفق الفيديو الخاص بالعرض إلى تدفق لملف فيديو تم إنشاؤه حديثًا.
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// Iterates through the videos
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
	auto video = pres->get_Videos()->idx_get(index);

	// يفتح تدفق فيديو العرض. يرجى ملاحظة أننا تجنبنا عمدًا الوصول إلى الأساليب
	// مثل video->get_BinaryData - لأن هذه الطريقة تُعيد مصفوفة بايت تحتوي على فيديو كامل، وهو ما
	// يسبب تحميل البايتات إلى الذاكرة. نستخدم video->GetStream، التي ستُعيد Stream - ولا
	// تتطلب منا تحميل الفيديو كاملًا إلى الذاكرة.
	
	auto presVideoStream = video->GetStream();

	auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
	int32_t bytesRead;
	while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
	{
		outputFileStream->Write(buffer, 0, bytesRead);
	}
		
	// ستظل استهلاك الذاكرة منخفضًا بغض النظر عن حجم الفيديو أو العرض التقديمي،
}

// إذا لزم الأمر، يمكنك تطبيق الخطوات نفسها على ملفات الصوت.
```


### **إضافة صورة كـ BLOB إلى عرض تقديمي**
باستخدام الأساليب من واجهة [**IImageCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) والفئة [**ImageCollection** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.image_collection) ، يمكنك إضافة صورة كبيرة كتيار لتتم معالجتها كـ BLOB. 

هذا الكود C++ يوضح لك كيفية إضافة صورة كبيرة عبر عملية BLOB:
```cpp
const String pathToLargeImage = u"large_image.jpg";

// ينشئ عرضًا تقديميًا جديدًا ستتم إضافة الصورة إليه.
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// لنضيف الصورة إلى العرض التقديمي - نختار سلوك KeepLocked لأننا
// لا نعتزم الوصول إلى ملف "largeImage.png".
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// يحفظ العرض التقديمي. أثناء إخراج عرض تقديمي كبير، استهلاك الذاكرة 
// يبقى منخفضًا طوال دورة حياة كائن pres
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```


## **الذاكرة والعروض التقديمية الكبيرة**

عادةً، لتحميل عرض تقديمي كبير، تحتاج الحواسيب إلى كمية كبيرة من الذاكرة المؤقتة. يتم تحميل كل محتوى العرض التقديمي إلى الذاكرة ويتوقف استخدام الملف (الذي تم تحميل العرض التقديمي منه). 

اعتبر عرض PowerPoint كبير (large.pptx) يحتوي على ملف فيديو بحجم 1.5 جيجابايت. الطريقة القياسية لتحميل العرض التقديمي موصوفة في هذا الكود C++:
```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```


لكن هذه الطريقة تستهلك حوالي 1.6 جيجابايت من الذاكرة المؤقتة. 

### **تحميل عرض تقديمي كبير كـ BLOB**

من خلال العملية التي تتضمن BLOB، يمكنك تحميل عرض تقديمي كبير مع استخدام قليل من الذاكرة. يصف هذا الكود C++ التنفيذ حيث تُستخدم عملية BLOB لتحميل ملف عرض تقديمي كبير (large.pptx):
```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);

auto pres = System::MakeObject<Presentation>(u"large.pptx", loadOptions);
pres->Save(u"large.pdf", SaveFormat::Pdf);
```


#### **تغيير المجلد للملفات المؤقتة**

عند استخدام عملية BLOB، ينشئ جهاز الكمبيوتر ملفات مؤقتة في المجلد الافتراضي للملفات المؤقتة. إذا كنت ترغب في حفظ الملفات المؤقتة في مجلد مختلف، يمكنك تغيير إعدادات التخزين باستخدام `TempFilesRootPath`:
```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```


{{% alert title="Info" color="info" %}}
عند استخدام `TempFilesRootPath`، لا يقوم Aspose.Slides تلقائيًا بإنشاء مجلد لتخزين الملفات المؤقتة. عليك إنشاء المجلد يدويًا. 
{{% /alert %}}

## **الأسئلة الشائعة**

**ما هي البيانات في عرض Aspose.Slides التي تُعامل كـ BLOB وتتحكم بها خيارات BLOB؟**

تُعامل الكائنات الثنائية الكبيرة مثل الصور والصوت والفيديو كـ BLOB. كما يشمل ملف العرض التقديمي بالكامل معالجة BLOB عند تحميله أو حفظه. تُحكم هذه الكائنات بسياسات BLOB التي تسمح لك بإدارة استهلاك الذاكرة وتفريغ البيانات إلى ملفات مؤقتة عند الحاجة.

**أين يمكنني تكوين قواعد معالجة BLOB أثناء تحميل العرض التقديمي؟**

استخدم [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) مع [BlobManagementOptions](https://reference.aspose.com/slides/cpp/aspose.slides/blobmanagementoptions/). هناك تقوم بتعيين حد الذاكرة في الذاكرة لـ BLOB، السماح أو عدم السماح بالملفات المؤقتة، اختيار مسار الجذر للملفات المؤقتة، وتحديد سلوك قفل المصدر.

**هل تؤثر إعدادات BLOB على الأداء، وكيف أوازن بين السرعة والذاكرة؟**

نعم. إبقاء BLOB في الذاكرة يزيد من السرعة لكنه يرفع استهلاك RAM؛ خفض حد الذاكرة ينقل المزيد من العمل إلى الملفات المؤقتة، مما يقلل RAM لكن يتطلب عمليات I/O إضافية. استخدم طريقة [set_MaxBlobsBytesInMemory](https://reference.aspose.com/slides/cpp/aspose.slides/blobmanagementoptions/set_maxblobsbytesinmemory/) للوصول إلى التوازن المناسب لحمولة عملك وبيئتك.

**هل تساعد خيارات BLOB عند فتح عروض تقديمية ضخمة جدًا (مثل الجيجابايت)؟**

نعم. تم تصميم [BlobManagementOptions](https://reference.aspose.com/slides/cpp/aspose.slides/blobmanagementoptions/) لهذه السيناريوهات: تمكين الملفات المؤقتة واستخدام قفل المصدر يمكن أن يقلل بشكل كبير من ذروة استهلاك RAM ويثبت عملية المعالجة للعروض الضخمة جدًا.

**هل يمكنني استخدام سياسات BLOB عند التحميل من التدفقات بدلاً من ملفات القرص؟**

نعم. تنطبق القواعد نفسها على التدفقات: يمكن لكائن العرض التقديمي امتلاك قفل تدفق الإدخال (حسب وضع القفل المختار)، وتُستخدم الملفات المؤقتة عندما يُسمح بذلك، مما يحافظ على استقرار استهلاك الذاكرة أثناء المعالجة.