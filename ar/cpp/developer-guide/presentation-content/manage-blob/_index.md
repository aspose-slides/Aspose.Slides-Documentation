---
title: إدارة BLOBs العرض التقديمي في C++ لاستخدام فعال للذاكرة
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
description: "إدارة بيانات BLOB في Aspose.Slides لـ C++ لتبسيط عمليات ملفات PowerPoint و OpenDocument من أجل معالجة عروض تقديمية فعالة."
---
## **نظرة عامة**

Aspose.Slides يوفر معالجات قائمة على BLOB للبيانات الثنائية الكبيرة في العروض التقديمية للمساعدة في تقليل استهلاك الذاكرة عند العمل مع صور كبيرة، صوت، فيديو، وملفات العروض.

هذه المقالة توضح كيفية استخدام المعالجة القائمة على BLOB لإضافة وسائط كبيرة إلى عرض تقديمي، تصدير وسائط كبيرة من عرض تقديمي، وتحميل عروض تقديمية كبيرة بشكل أكثر كفاءة. كما تشرح كيف يمكن استخدام الملفات المؤقتة أثناء المعالجة وكيفية تغيير المجلد المستخدم لتخزينها.

## **حول BLOB**

**BLOB** (**Binary Large Object**) هو عادة عنصر كبير (صورة، عرض تقديمي، مستند أو وسائط) يُحفظ بتنسيقات ثنائية.

Aspose.Slides for C++ يتيح لك استخدام BLOBs للكائنات بطريقة تقلل من استهلاك الذاكرة عندما تكون الملفات الكبيرة متورطة.

## **استخدام BLOB لتقليل استهلاك الذاكرة**

### **إضافة ملف كبير عبر BLOB إلى عرض تقديمي**

[Aspose.Slides](/slides/ar/cpp/) for C++ يتيح لك إضافة ملفات كبيرة (في هذه الحالة، ملف فيديو كبير) عبر عملية تشمل BLOBs لتقليل استهلاك الذاكرة.

هذا الكود C++ يوضح كيفية إضافة ملف فيديو كبير عبر عملية BLOB إلى عرض تقديمي:

```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// ينشئ عرضًا تقديميًا جديدًا سيتم إضافة الفيديو إليه
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// لنقم بإضافة الفيديو إلى العرض التقديمي - اخترنا سلوك KeepLocked لأننا نريد
//عدم الوصول إلى ملف "veryLargeVideo.avi" .
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// يحفظ العرض التقديمي. أثناء إخراج عرض تقديمي كبير، يبقى استهلاك الذاكرة
//منخفضًا طوال دورة حياة كائن pres 
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```

### **تصدير ملف كبير عبر BLOB من عرض تقديمي**

Aspose.Slides for C++ يتيح لك تصدير ملفات كبيرة (في هذه الحالة، ملف صوت أو فيديو) عبر عملية تشمل BLOBs من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج ملف وسائط كبير من عرض تقديمي لكن لا تريد تحميل الملف إلى ذاكرة جهاز الكمبيوتر. عبر تصدير الملف عبر عملية BLOB، تحافظ على استهلاك الذاكرة منخفضًا.

هذا الكود C++ يوضح العملية المذكورة:

```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// ينشئ كائن Presentation ويقفل ملف "hugePresentationWithAudiosAndVideos.pptx".

auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// لنقم بحفظ كل فيديو إلى ملف. لمنع استهلاك عالي للذاكرة، نحتاج إلى مخزن مؤقت سيُستخدم
// لنقل البيانات من تدفق فيديو العرض التقديمي إلى تدفق لملف فيديو تم إنشاؤه حديثًا.
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// يتنقل عبر الفيديوهات
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
	auto video = pres->get_Videos()->idx_get(index);

	// يفتح تدفق فيديو العرض التقديمي. يرجى الملاحظة أننا تجنبنا عمدًا الوصول إلى الأساليب
	// مثل video->get_BinaryData - لأن هذه الطريقة تُعيد مصفوفة بايت تحتوي على فيديو كامل، مما يؤدي بعد ذلك
	// إلى تحميل البايتات في الذاكرة. نستخدم video->GetStream، التي تُعيد Stream - ولا تتطلب
	// تحميل الفيديو بالكامل في الذاكرة.
	
	auto presVideoStream = video->GetStream();

	auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
	int32_t bytesRead;
	while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
	{
		outputFileStream->Write(buffer, 0, bytesRead);
	}
		
	// سيظل استهلاك الذاكرة منخفضًا بغض النظر عن حجم الفيديو أو العرض التقديمي,
}

// إذا لزم الأمر، يمكنك تطبيق الخطوات نفسها على ملفات الصوت.
```

### **إضافة صورة كـ BLOB إلى عرض تقديمي**

باستخدام الأساليب من واجهة [**IImageCollection**](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_image_collection) و[**ImageCollection**](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.image_collection) يمكنك إضافة صورة كبيرة كتيار لتعاملها كـ BLOB.

هذا الكود C++ يوضح كيفية إضافة صورة كبيرة عبر عملية BLOB:

```cpp
const String pathToLargeImage = u"large_image.jpg";

// ينشئ عرضًا تقديميًا جديدًا سيتم إضافة الصورة إليه.
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// لنقم بإضافة الصورة إلى العرض التقديمي - نختار سلوك KeepLocked لأننا نريد
// لا نعتزم الوصول إلى ملف "largeImage.png" الملف.
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// يحفظ العرض التقديمي. أثناء إخراج عرض تقديمي كبير، يبقى استهلاك الذاكرة
// منخفضًا طوال دورة حياة كائن pres
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```

## **الذاكرة والعروض التقديمية الكبيرة**

عادةً، لتحميل عرض تقديمي كبير، تحتاج الحواسيب إلى الكثير من الذاكرة المؤقتة. يتم تحميل كل محتوى العرض إلى الذاكرة ويتوقف استخدام الملف (الذي تم تحميل العرض منه).

تخيل عرض PowerPoint كبير (large.pptx) يحتوي على ملف فيديو بحجم 1.5 جيجابايت. الطريقة القياسية لتحميل العرض موضح في هذا الكود C++:

```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

ولكن هذه الطريقة تستهلك حوالي 1.6 جيجابايت من الذاكرة المؤقتة.

### **تحميل عرض تقديمي كبير كـ BLOB**

من خلال العملية التي تتضمن BLOB، يمكنك تحميل عرض تقديمي كبير مع استخدام قليل من الذاكرة. هذا الكود C++ يصف التنفيذ حيث تُستخدم عملية BLOB لتحميل ملف عرض تقديمي كبير (large.pptx):

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

عند استخدام عملية BLOB، ينشئ حاسوبك ملفات مؤقتة في المجلد الافتراضي للملفات المؤقتة. إذا رغبت في حفظ الملفات المؤقتة في مجلد مختلف، يمكنك تغيير إعدادات التخزين باستخدام `TempFilesRootPath`:

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```

{{% alert title="Info" color="info" %}}
عند استخدام `TempFilesRootPath`، لا تقوم Aspose.Slides بإنشاء مجلد تلقائيًا لتخزين الملفات المؤقتة. يجب عليك إنشاء المجلد يدويًا.
{{% /alert %}}

### **إلغاء كائنات العرض لإطلاق الذاكرة**

عند معالجة عروض تقديمية كبيرة، تأكد من إلغاء كائن [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) بشكل صحيح حتى يتم تحرير الذاكرة التي كان يشغلها. استدعِ `Dispose()` بعد الانتهاء من استخدام العرض لتحرير الموارد غير المُدارة.

```cpp
auto presentation = System::MakeObject<Presentation>(u"large.pptx");

// ...معالجة العرض التقديمي...
presentation->Save(u"large.pdf", SaveFormat::Pdf);

// تحرير الموارد صراحةً.
presentation->Dispose();
```

## **الأسئلة الشائعة**

**ما البيانات في عرض Aspose.Slides التي تُعامل كـ BLOB وتُتحكم بها خيارات BLOB؟**

الكائنات الثنائية الكبيرة مثل الصور، الصوت، والفيديو تُعامل كـ BLOB. ملف العرض الكامل أيضًا يتضمن معالجة BLOB عند تحميله أو حفظه. تُحكم هذه الكائنات بواسطة سياسات BLOB التي تسمح لك بإدارة استهلاك الذاكرة واستخدام الملفات المؤقتة عند الحاجة.

**أين يمكنني تكوين قواعد معالجة BLOB أثناء تحميل العرض؟**

استخدم [LoadOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides/loadoptions/) مع [BlobManagementOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides/blobmanagementoptions/). هناك يمكنك تحديد الحد الأقصى للذاكرة لـ BLOB، السماح أو عدم السماح للملفات المؤقتة، اختيار المسار الجذري للملفات المؤقتة، وتحديد سلوك قفل المصدر.

**هل تؤثر إعدادات BLOB على الأداء، وكيف أوازن بين السرعة والذاكرة؟**

نعم. حفظ BLOB في الذاكرة يزيد السرعة لكنه يرفع استهلاك RAM؛ خفض الحد الأقصى للذاكرة يوجه المزيد من العمل إلى الملفات المؤقتة، مما يقلل RAM على حساب عمليات I/O إضافية. استخدم طريقة [set_MaxBlobsBytesInMemory](https://reference.aspose.com/slides/ar/cpp/aspose.slides/blobmanagementoptions/set_maxblobsbytesinmemory/) لتحقيق التوازن المناسب لحمولة عملك وبيئتك.

**هل تساعد خيارات BLOB عند فتح عروض تقديمية ضخمة (مثلاً جيجابايت)؟**

نعم. تم تصميم [BlobManagementOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides/blobmanagementoptions/) لهذه السيناريوهات: تمكين الملفات المؤقتة واستخدام قفل المصدر يمكن أن يقلل بشكل كبير من استهلاك RAM الأقصى ويستقر المعالجة لعروض ضخمة جدًا.

**هل يمكنني استخدام سياسات BLOB عند التحميل من تدفقات بدلاً من ملفات القرص؟**

نعم. تُطبق القواعد نفسها على التدفقات: يمكن لكائن العرض امتلاك وقفل تدفق الإدخال (حسب وضع القفل المختار)، وتُستخدم الملفات المؤقتة عندما يُسمح بذلك، مما يحافظ على استهلاك الذاكرة متوقعًا أثناء المعالجة.