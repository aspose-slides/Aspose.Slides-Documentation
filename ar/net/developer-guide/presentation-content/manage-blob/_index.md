---
title: "إدارة كائنات BLOB في العروض التقديمية باستخدام .NET لاستخدام الذاكرة بفعالية"
linktitle: "إدارة BLOB"
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
description: "إدارة بيانات BLOB في Aspose.Slides لـ .NET لتبسيط عمليات ملفات PowerPoint و OpenDocument لتحسين معالجة العروض التقديمية بسرعة وكفاءة."
---
## **نظرة عامة**

توفر Aspose.Slides معالجة تعتمد على BLOB للبيانات الثنائية الكبيرة في العروض التقديمية للمساعدة في تقليل استهلاك الذاكرة عند التعامل مع الصور الكبيرة، والصوت، والفيديو، وملفات العروض.

توضح هذه المقالة كيفية استخدام المعالجة القائمة على BLOB لإضافة وسائط كبيرة إلى عرض تقديمي، وتصدير وسائط كبيرة من عرض تقديمي، وتحميل عروض تقديمية كبيرة بشكل أكثر كفاءة. كما يشرح كيفية استخدام الملفات المؤقتة أثناء المعالجة وكيفية تغيير المجلد المستخدم لتخزينها.

## **حول BLOB**

**BLOB** (**كائن ثنائي كبير**) هو عادةً عنصر كبير (صورة، عرض تقديمي، مستند أو وسائط) يُحفظ بصيغ ثنائية.

يسمح Aspose.Slides for .NET لك باستخدام BLOBs للكائنات بطريقة تقلل استهلاك الذاكرة عند التعامل مع ملفات كبيرة.

## **استخدام BLOB لتقليل استهلاك الذاكرة**

### **إضافة ملف كبير عبر BLOB إلى عرض تقديمي**

[Aspose.Slides](/slides/ar/net/) for .NET يتيح لك إضافة ملفات كبيرة (في هذه الحالة، ملف فيديو كبير) عبر عملية تتضمن BLOBs لتقليل استهلاك الذاكرة.

يظهر لك هذا المثال بلغة C# كيفية إضافة ملف فيديو كبير عبر عملية BLOB إلى عرض تقديمي:

```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// ينشئ عرض تقديمي جديد سيُضاف إليه الفيديو
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // لنضيف الفيديو إلى العرض التقديمي - اخترنا سلوك KeepLocked لأننا
        // لا ننوي الوصول إلى ملف "veryLargeVideo.avi".
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // يحفظ العرض التقديمي. بينما يتم إنتاج عرض تقديمي كبير، يبقى استهلاك الذاكرة
        // منخفضًا طوال دورة حياة كائن pres 
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```

### **تصدير ملف كبير عبر BLOB من عرض تقديمي**

يسمح Aspose.Slides for .NET لك بتصدير ملفات كبيرة (في هذه الحالة، ملف صوت أو فيديو) عبر عملية تتضمن BLOBs من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج ملف وسائط كبير من عرض تقديمي ولكن لا تريد تحميل الملف في ذاكرة جهازك. عبر تصدير الملف عبر عملية BLOB، يمكنك الحفاظ على استهلاك الذاكرة منخفضًا.

يوضح هذا الكود بلغة C# العملية الموصوفة:

```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// يقفل ملف المصدر ولا يحملها إلى الذاكرة
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// ينشئ كائن Presentation، يقفل ملف "hugePresentationWithAudiosAndVideos.pptx".
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// لنحفظ كل فيديو في ملف. لتجنب استهلاك عالي للذاكرة، نحتاج إلى مخزن مؤقت سيُستخدم
	// لنقل البيانات من تدفق فيديو العرض التقديمي إلى تدفق لملف فيديو تم إنشاؤه حديثًا.
	byte[] buffer = new byte[8 * 1024];

	// يتكرر عبر الفيديوهات
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// يفتح تدفق فيديو العرض التقديمي. يرجى ملاحظة أننا تجنبنا عمدًا الوصول إلى الخصائص
		// مثل video.BinaryData - لأن هذه الخاصية تُرجع مصفوفة بايت تحتوي على فيديو كامل، مما يسبب
		// تحميل البايتات إلى الذاكرة. نستخدم video.GetStream التي تُرجع Stream - ولا تقوم
		//  بتطلب منا تحميل الفيديو بالكامل إلى الذاكرة.
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

		// سيظل استهلاك الذاكرة منخفضًا بغض النظر عن حجم الفيديو أو العرض التقديمي،
	}

	// إذا لزم الأمر، يمكنك تطبيق نفس الخطوات على ملفات الصوت. 
}
```

### **إضافة صورة كـ BLOB إلى عرض تقديمي**

باستخدام الأساليب من واجهة [**IImageCollection**](https://reference.aspose.com/slides/ar/net/aspose.slides/iimagecollection) والفئة [**ImageCollection** ](https://reference.aspose.com/slides/ar/net/aspose.slides/imagecollection)class، يمكنك إضافة صورة كبيرة كتيار لتعاملها كـ BLOB.

يظهر لك هذا الكود بلغة C# كيفية إضافة صورة كبيرة عبر عملية BLOB:

```c#
string pathToLargeImage = "large_image.jpg";

// ينشئ عرض تقديمي جديد ستُضاف إليه الصورة.
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// دعنا نضيف الصورة إلى العرض التقديمي - نختار سلوك KeepLocked لأننا
		// لا نعتزم الوصول إلى ملف "largeImage.png" file.
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// يحفظ العرض التقديمي. أثناء إنتاج عرض تقديمي كبير، يظل استهلاك الذاكرة
		// منخفضًا طوال دورة حياة كائن pres
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```

## **الذاكرة والعروض التقديمية الكبيرة**

عادةً، لتحميل عرض تقديمي كبير، تحتاج الحواسيب إلى الكثير من الذاكرة المؤقتة. يتم تحميل جميع محتوى العرض التقديمي إلى الذاكرة ويتوقف استخدام الملف (الذي تم تحميل العرض التقديمي منه).

تخيل عرض تقديمي PowerPoint كبير (large.pptx) يحتوي على ملف فيديو بحجم 1.5 جيجابايت. الطريقة القياسية لتحميل العرض التقديمي موصوفة في هذا الكود بلغة C#:

```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

ولكن هذه الطريقة تستهلك حوالي 1.6 جيجابايت من الذاكرة المؤقتة.

### **تحميل عرض تقديمي كبير كـ BLOB**

من خلال العملية التي تتضمن BLOB، يمكنك تحميل عرض تقديمي كبير باستخدام القليل من الذاكرة. يصف هذا الكود بلغة C# التنفيذ حيث يتم استخدام عملية BLOB لتحميل ملف عرض تقديمي كبير (large.pptx):

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

### **تغيير المجلد للملفات المؤقتة**

عند استخدام عملية BLOB، ينشئ الكمبيوتر ملفات مؤقتة في المجلد الافتراضي للملفات المؤقتة. إذا كنت ترغب في حفظ الملفات المؤقتة في مجلد مختلف، يمكنك تعديل إعدادات التخزين باستخدام `TempFilesRootPath`:

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

{{% alert title="Info" color="info" %}}
عند استخدامك لـ `TempFilesRootPath`، لا يقوم Aspose.Slides بإنشاء مجلد لتخزين الملفات المؤقتة تلقائيًا. يجب عليك إنشاء المجلد يدويًا.
{{% /alert %}}

### **تحرير كائنات العرض التقديمي لإطلاق الذاكرة**

عند معالجة عروض تقديمية كبيرة، تأكد من أن كائن [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) يتم التخلص منه بشكل صحيح لتُفرغ الذاكرة التي كان يشغلها. الطريقة المفضلة هي استخدام جملة `using` أو تصريح كما هو موضح في الأمثلة أعلاه؛ فهي تقوم تلقائيًا بتحرير العرض وتحرير الموارد غير المُدارة عند خروج الكتلة.

إذا قمت بإنشاء عرض تقديمي بدون كتلة `using`، استدعِ `Dispose()` صراحةً بعد الانتهاء من استخدامه.

```cs
Presentation presentation = new Presentation("large.pptx");

// ...معالجة العرض التقديمي...
presentation.Save("large.pdf", SaveFormat.Pdf);

// تحرير الموارد صراحةً.
presentation.Dispose();
```

## **الأسئلة المتكررة**

**ما هي البيانات في عرض Aspose.Slides التي تُعامل كـ BLOB وتُتحكم بها خيارات BLOB؟**

تُعامل الكائنات الثنائية الكبيرة مثل الصور، الصوت والفيديو كـ BLOB. كما يتضمن ملف العرض التقديمي بأكمله معالجة BLOB عند تحميله أو حفظه. هذه الكائنات تخضع لسياسات BLOB التي تتيح لك إدارة استهلاك الذاكرة وتحويلها إلى ملفات مؤقتة عند الحاجة.

**أين يمكنني تكوين قواعد معالجة BLOB أثناء تحميل العرض التقديمي؟**

استخدم [LoadOptions](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/) مع [BlobManagementOptions](https://reference.aspose.com/slides/ar/net/aspose.slides/blobmanagementoptions/). هناك يمكنك تحديد حد الذاكرة داخلية لـ BLOB، السماح بالملفات المؤقتة أو حظرها، اختيار المسار الجذر للملفات المؤقتة، وتحديد سلوك قفل المصدر.

**هل تؤثر إعدادات BLOB على الأداء، وكيف يمكن موازنة السرعة مقابل الذاكرة؟**

نعم. الحفاظ على BLOB في الذاكرة يزيد السرعة لكنه يرفع استهلاك الذاكرة؛ تقليل حد الذاكرة ينقل المزيد من العمل إلى الملفات المؤقتة، مما يقلل الذاكرة بتكلفة زيادة عمليات الإدخال/الإخراج. اضبط عتبة [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/ar/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/) لتحقيق التوازن المناسب لحاجتك والبيئة.

**هل تساعد خيارات BLOB عند فتح عروض تقديمية ضخمة جدًا (مثل الجيجابايت)؟**

نعم. تم تصميم [BlobManagementOptions](https://reference.aspose.com/slides/ar/net/aspose.slides/blobmanagementoptions/) لهذا النوع من السيناريوهات: تمكين الملفات المؤقتة واستخدام قفل المصدر يمكن أن يقلل بشكل كبير من استهلاك الذاكرة القصوى ويثبت عملية المعالجة للعروض الضخمة جدًا.

**هل يمكنني استخدام سياسات BLOB عند التحميل من تدفقات بدلاً من ملفات القرص؟**

نعم. تنطبق نفس القواعد على التدفقات: يمكن لكائن العرض التقديمي امتلاك وقفل تدفق الإدخال (حسب وضع القفل المختار)، وتُستخدم الملفات المؤقتة عند السماح بذلك، مما يحافظ على استهلاك الذاكرة بصورة قابلة للتنبؤ أثناء المعالجة.