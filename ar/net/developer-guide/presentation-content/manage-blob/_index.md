---
title: إدارة كائنات BLOB في العروض التقديمية في .NET لاستخدام الذاكرة الفعال
linktitle: إدارة BLOB
type: docs
weight: 10
url: /ar/net/manage-blob/
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
- .NET
- C#
- Aspose.Slides
description: "إدارة بيانات BLOB في Aspose.Slides لـ .NET لتبسيط عمليات ملفات PowerPoint و OpenDocument من أجل معالجة عروض تقديمية فعّالة."
---

## **حول BLOB**

**BLOB** (**Binary Large Object**) عادةً ما يكون عنصرًا كبيرًا (صورة، عرض تقديمي، مستند أو وسائط) يُحفظ بصيغ ثنائية. 

تتيح لك Aspose.Slides for .NET استخدام BLOBs للكائنات بطريقة تقلل من استهلاك الذاكرة عند التعامل مع ملفات كبيرة. 

## **استخدام BLOB لتقليل استهلاك الذاكرة**

### **إضافة ملف كبير عبر BLOB إلى عرض تقديمي**

تتيح لك [Aspose.Slides](/slides/ar/net/) for .NET إضافة ملفات كبيرة (في هذه الحالة، ملف فيديو كبير) عبر عملية تشمل BLOBs لتقليل استهلاك الذاكرة.

يظهر لك هذا المثال بلغة C# كيفية إضافة ملف فيديو كبير عبر عملية BLOB إلى عرض تقديمي:
```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// ينشئ عرضًا تقديميًا جديدًا سيتم إضافة الفيديو إليه
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // لنقم بإضافة الفيديو إلى العرض التقديمي - اخترنا سلوك KeepLocked لأننا نريد
        // لا ننوي الوصول إلى ملف "veryLargeVideo.avi" ملف.
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // يحفظ العرض التقديمي. أثناء إخراج عرض تقديمي كبير، يظل استهلاك الذاكرة
        // منخفضًا طوال دورة حياة كائن pres 
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```


### **تصدير ملف كبير عبر BLOB من العرض التقديمي**
تتيح لك Aspose.Slides for .NET تصدير ملفات كبيرة (في هذه الحالة، ملف صوت أو فيديو) عبر عملية تشمل BLOBs من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج ملف وسائط كبير من عرض تقديمي دون رغبة في تحميله إلى ذاكرة جهاز الكمبيوتر. من خلال تصدير الملف عبر عملية BLOB، يمكنك الحفاظ على استهلاك الذاكرة منخفضًا. 

يُظهر لك هذا الكود بلغة C# العملية الموصوفة:
```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// يقفل ملف المصدر ولا يقوم بتحميله في الذاكرة
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// ينشئ كائن Presentation، ويقفل ملف "hugePresentationWithAudiosAndVideos.pptx"
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// لنقم بحفظ كل فيديو إلى ملف. لتجنب استهلاك كبير للذاكرة، نحتاج إلى مخزن مؤقت سيتم استخدامه
	// لنقل البيانات من تدفق فيديو العرض إلى تدفق لملف فيديو جديد تم إنشاؤه.
	byte[] buffer = new byte[8 * 1024];

	// Iterates through the videos
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// يفتح تدفق فيديو العرض. يرجى ملاحظة أننا تجنبنا عمدًا الوصول إلى الخصائص
		// مثل video.BinaryData - لأن هذه الخاصية تُعيد مصفوفة بايت تحتوي على فيديو كامل، مما يؤدي إلى
		// تحميل البايتات في الذاكرة. نستخدم video.GetStream، التي تُعيد Stream - ولا تقوم بـ
		//  طلب تحميل الفيديو بالكامل في الذاكرة.
		using (Stream presVideoStream = video.GetStream())
		{
			using (FileStream outputFileStream = File.OpenWrite($"video{index}.avi"))
			{
				int bytesRead;
				while ((bytesRead = presVideoStream.Read(buffer, 0, buffer.Length)) > 0)
				{
					outputFileStream.Write(buffer, 0, bytesRead);
				}
			}
		}

		// سيظل استهلاك الذاكرة منخفضًا بغض النظر عن حجم الفيديو أو العرض.
	}

	// إذا لزم الأمر، يمكنك تطبيق الخطوات نفسها على ملفات الصوت.
}
```


### **إضافة صورة كـ BLOB في العرض التقديمي**
باستخدام الأساليب من واجهة [**IImageCollection**](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) و[**ImageCollection**](https://reference.aspose.com/slides/net/aspose.slides/imagecollection)class، يمكنك إضافة صورة كبيرة كدفق لتعاملها كـ BLOB. 

يظهر لك هذا الكود بلغة C# كيفية إضافة صورة كبيرة عبر عملية BLOB:
```c#
string pathToLargeImage = "large_image.jpg";

// ينشئ عرضًا تقديميًا جديدًا سيتم إضافة الصورة إليه.
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// لنقم بإضافة الصورة إلى العرض التقديمي - نختار سلوك KeepLocked لأننا
		// لا نعتزم الوصول إلى ملف "largeImage.png" الملف.
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// يحفظ العرض التقديمي. أثناء إخراج عرض تقديمي كبير، يظل استهلاك الذاكرة 
		// منخفضًا طوال دورة حياة كائن pres
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```


## **الذاكرة والعروض التقديمية الكبيرة**

عادةً، لتحميل عرض تقديمي كبير، تحتاج أجهزة الكمبيوتر إلى الكثير من الذاكرة المؤقتة. يتم تحميل جميع محتويات العرض التقديمي إلى الذاكرة ويتوقف استخدام الملف (الذي تم تحميل العرض منه). 

خذ في الاعتبار عرض تقديمي PowerPoint كبير (large.pptx) يحتوي على ملف فيديو حجمه 1.5 جيجابايت. الطريقة القياسية لتحميل العرض موصوفة في هذا الكود C#:
```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```


لكن هذه الطريقة تستهلك حوالي 1.6 جيجابايت من الذاكرة المؤقتة. 

### **تحميل عرض تقديمي كبير كـ BLOB**
من خلال عملية تشمل BLOB، يمكنك تحميل عرض تقديمي كبير مع استهلاك قليل للذاكرة. يصف هذا الكود C# التنفيذ حيث تُستخدم عملية BLOB لتحميل ملف عرض تقديمي كبير (large.pptx):
```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true
   }
};
 
using (Presentation pres = new Presentation("large.pptx", loadOptions))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```


### **تغيير مجلد الملفات المؤقتة**
عند استخدام عملية BLOB، ينشئ جهاز الكمبيوتر ملفات مؤقتة في المجلد الافتراضي للملفات المؤقتة. إذا أردت حفظ الملفات المؤقتة في مجلد مختلف، يمكنك تغيير إعدادات التخزين باستخدام `TempFilesRootPath`:
```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true,
       TempFilesRootPath = "temp"
   }
};
```


{{% alert title="معلومات" color="info" %}}
عند استخدام `TempFilesRootPath`، لا تقوم Aspose.Slides بإنشاء مجلد لتخزين الملفات المؤقتة تلقائيًا. عليك إنشاء المجلد يدويًا. 
{{% /alert %}}

## **الأسئلة الشائعة**

**ما البيانات في عرض Aspose.Slides التي تُعامل كـ BLOB وتُدار بواسطة خيارات BLOB؟**

تُعامل الكائنات الثنائية الكبيرة مثل الصور، الصوت، والفيديو كـ BLOB. كما يشمل ملف العرض التقديمي بأكمله معالجة BLOB عند تحميله أو حفظه. تُحكم هذه الكائنات بسياسات BLOB التي تسمح لك بإدارة استخدام الذاكرة وتحويلها إلى ملفات مؤقتة عند الحاجة. 

**أين يمكنني تكوين قواعد معالجة BLOB أثناء تحميل العرض التقديمي؟**

استخدم [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) مع [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/). هناك يمكنك تحديد حد الذاكرة المتاحة لـ BLOB، السماح أو عدم السماح بالملفات المؤقتة، اختيار المسار الجذري للملفات المؤقتة، وتحديد سلوك قفل المصدر. 

**هل تؤثر إعدادات BLOB على الأداء، وكيف أوازن بين السرعة والذاكرة؟**

نعم. حفظ BLOB في الذاكرة يعزز السرعة لكنه يزيد من استهلاك RAM؛ تقليل حد الذاكرة ينقل المزيد من العمل إلى الملفات المؤقتة، مما يقلل RAM على حساب إدخال/إخراج إضافي. اضبط عتبة [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/) لتحقيق التوازن المناسب لحِمل العمل والبيئة الخاصة بك. 

**هل تساعد خيارات BLOB عند فتح عروض تقديمية كبيرة جدًا (مثلاً بجيجابايت)؟**

نعم. تم تصميم [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/) لمثل هذه السيناريوهات: تمكين الملفات المؤقتة واستخدام قفل المصدر يمكن أن يقلل بشكل كبير من أقصى استهلاك لل RAM ويستقر المعالجة للعروض الضخمة جدًا. 

**هل يمكنني استخدام سياسات BLOB عند التحميل من تدفقات بدلاً من ملفات القرص؟**

نعم. تنطبق نفس القواعد على التدفقات: يمكن لكائن العرض التقديمي امتلاك وقفل تدفق الإدخال (اعتمادًا على وضع القفل المختار)، وتُستخدم الملفات المؤقتة عندما يُسمح بذلك، مما يبقي استهلاك الذاكرة متوقعًا أثناء المعالجة.