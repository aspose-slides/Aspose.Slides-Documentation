---
title: إدارة Blob
type: docs
weight: 10
url: /ar/cpp/manage-blob/
keywords: "إضافة blob، تصدير blob، إضافة صورة كـ blob، عرض PowerPoint، C++، Aspose.Slides لـ C++"
description: "إضافة blob إلى عرض PowerPoint في C++. تصدير blob. إضافة صورة كـ blob"
---

## **عن BLOB**

**BLOB** (**كائن ثنائي كبير**) هو عادة عنصر كبير (صورة، عرض، وثيقة، أو media) محفوظ في تنسيقات ثنائية.

تسمح لك Aspose.Slides لـ C++ باستخدام BLOBs لكائنات بطريقة تقلل من استهلاك الذاكرة عند التعامل مع ملفات كبيرة.

## **استخدم BLOB لتقليل استهلاك الذاكرة**

### **إضافة ملف كبير عبر BLOB إلى عرض**

تتيح لك [Aspose.Slides](/slides/ar/cpp/) لـ C++ إضافة ملفات كبيرة (في هذه الحالة، ملف فيديو كبير) من خلال عملية تشمل BLOBs لتقليل استهلاك الذاكرة.

يفيد هذا الكود في C++ في كيفية إضافة ملف فيديو كبير عبر عملية BLOB إلى عرض:

```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// ينشئ عرضًا جديدًا ستضاف إليه الفيديو
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// لنقم بإضافة الفيديو إلى العرض - اخترنا سلوك KeepLocked لأننا لا نعتزم الوصول إلى
// الملف "veryLargeVideo.avi".
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// يحفظ العرض. بينما يتم إخراج عرض كبير، يبقى استهلاك الذاكرة منخفضًا طوال دورة حياة كائن pres 
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```

### **تصدير ملف كبير عبر BLOB من العرض**
تتيح لك Aspose.Slides لـ C++ تصدير ملفات كبيرة (في هذه الحالة، ملف صوت أو فيديو) عبر عملية تشمل BLOBs من العروض. على سبيل المثال، قد تحتاج إلى استخراج ملف وسائط كبير من عرض ولكن لا تريد تحميل الملف في ذاكرة جهاز الكمبيوتر الخاص بك. من خلال تصدير الملف عبر عملية BLOB، يمكنك الحفاظ على استهلاك الذاكرة منخفضًا.

يظهر هذا الكود في C++ العملية الموصوفة:

```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// ينشئ экземпляр الخاص بالعروض، ويقوم بقفل ملف "hugePresentationWithAudiosAndVideos.pptx".

auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// لنقم بحفظ كل فيديو في ملف. لمنع استهلاك الذاكرة المرتفع، نحتاج إلى مخزن مؤقت سيتم استخدامه
// لنقل البيانات من مجرى الفيديو الخاص بالعرض إلى مجرى لملف الفيديو الجديد.
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// تتكرر من خلال الفيديوهات
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
	auto video = pres->get_Videos()->idx_get(index);

	// يفتح مجرى الفيديو الخاص بالعرض. يرجى ملاحظة أننا تجنبنا عمدًا الوصول إلى طرق
	// مثل video->get_BinaryData - لأن هذه الطريقة ترجع مصفوفة بايت تحتوي على فيديو كامل، مما يؤدي إلى
	// تحميل بايتات في الذاكرة. نستخدم video->GetStream، والذي سيعيد Stream - ولا يتطلب 
	// تحميل الفيديو بالكامل في الذاكرة.
	
	auto presVideoStream = video->GetStream();

	auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
	int32_t bytesRead;
	while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
	{
		outputFileStream->Write(buffer, 0, bytesRead);
	}
		
	// سيبقى استهلاك الذاكرة منخفضًا بغض النظر عن حجم الفيديو أو العرض،
}

// إذا لزم الأمر، يمكنك تطبيق نفس الخطوات على ملفات الصوت.
```

### **إضافة صورة كـ BLOB في العرض**
مع الطرق من واجهة [**IImageCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) وفئة [**ImageCollection** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.image_collection)، يمكنك إضافة صورة كبيرة كتيار للحصول عليها كـ BLOB.

هذا الكود في C++ يوضح لك كيفية إضافة صورة كبيرة عبر عملية BLOB:

```cpp
const String pathToLargeImage = u"large_image.jpg";

// ينشئ عرضًا جديدًا ستضاف إليه الصورة.
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// لنقم بإضافة الصورة إلى العرض - نحن نختار سلوك KeepLocked لأننا لا نعتزم
// الوصول إلى الملف "largeImage.png".
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// يحفظ العرض. بينما يتم إخراج عرض كبير، يبقى استهلاك الذاكرة 
// منخفضًا طوال دورة حياة كائن pres
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```

## **الذاكرة والعروض الكبيرة**

عادةً، لتحميل عرض كبير، تتطلب أجهزة الكمبيوتر الكثير من الذاكرة المؤقتة. يتم تحميل كل محتوى العرض في الذاكرة ويتوقف استخدام الملف (الذي تم تحميل العرض منه).

اعتبر عرض PowerPoint كبير (large.pptx) يحتوي على ملف فيديو بحجم 1.5 جيجابايت. يتم وصف الطريقة القياسية لتحميل العرض في هذا الكود في C++:

```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

لكن هذه الطريقة تستهلك حوالي 1.6 جيجابايت من الذاكرة المؤقتة.

### **تحميل عرض كبير كـ BLOB**

من خلال العملية التي تشمل BLOB، يمكنك تحميل عرض كبير مع استخدام ذاكرة قليلة. يصف هذا الكود في C++ التنفيذ حيث يتم استخدام عملية BLOB لتحميل ملف عرض كبير (large.pptx):

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

عند استخدام عملية BLOB، يقوم الكمبيوتر الخاص بك بإنشاء ملفات مؤقتة في المجلد الافتراضي للملفات المؤقتة. إذا كنت ترغب في الاحتفاظ بالملفات المؤقتة في مجلد مختلف، يمكنك تغيير إعدادات التخزين باستخدام `TempFilesRootPath`:

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```

{{% alert title="معلومات" color="info" %}}

عند استخدام `TempFilesRootPath`، لا تقوم Aspose.Slides بإنشاء مجلد تلقائيًا لتخزين الملفات المؤقتة. عليك إنشاء المجلد يدويًا. 

{{% /alert %}}