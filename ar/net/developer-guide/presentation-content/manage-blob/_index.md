---
title: إدارة كائنات BLOB للعرض التقديمي في .NET لاستخدام فعال للذاكرة
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
description: "إدارة بيانات BLOB في Aspose.Slides لـ .NET لتبسيط عمليات ملفات PowerPoint و OpenDocument لتحقيق معالجة فعالة للعرض التقديمي."
---

## **حول BLOB**

**BLOB** (**Binary Large Object**) هو عادةً عنصر كبير (صورة، عرض تقديمي، مستند أو وسائط) يُحفظ بصيغ ثنائية.

يسمح Aspose.Slides for .NET باستخدام BLOBs للكائنات بطريقة تُقلل من استهلاك الذاكرة عند التعامل مع ملفات كبيرة.

## **استخدام BLOB لتقليل استهلاك الذاكرة**

### **إضافة ملف كبير عبر BLOB إلى عرض تقديمي**

[Aspose.Slides](/slides/ar/net/) for .NET يتيح لك إضافة ملفات كبيرة (في هذه الحالة، ملف فيديو كبير) عبر عملية تشمل BLOBs لتقليل استهلاك الذاكرة.

هذا المثال في C# يوضح كيفية إضافة ملف فيديو كبير عبر عملية BLOB إلى عرض تقديمي:
```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// ينشئ عرض تقديمي جديد سيتم إضافة الفيديو إليه
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // لنضيف الفيديو إلى العرض التقديمي - اخترنا سلوك KeepLocked لأننا
        // لا نعتزم الوصول إلى ملف "veryLargeVideo.avi".
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // يحفظ العرض التقديمي. أثناء إخراج عرض تقديمي كبير،
        // يبقى منخفضًا طوال دورة حياة كائن pres 
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```


### **تصدير ملف كبير عبر BLOB من العرض التقديمي**
Aspose.Slides for .NET يتيح لك تصدير ملفات كبيرة (مثل ملف صوت أو فيديو) عبر عملية تشمل BLOBs من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج ملف وسائط كبير من عرض تقديمي ولكن لا ترغب في تحميل الملف إلى ذاكرة جهازك. من خلال تصدير الملف عبر عملية BLOB، يمكنك الحفاظ على انخفاض استهلاك الذاكرة.

هذا الكود في C# يوضح العملية المذكورة:
```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// قفل ملف المصدر ولا يتم تحميله إلى الذاكرة
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
}

// ينشئ كائن Presentation ويقفل ملف "hugePresentationWithAudiosAndVideos.pptx".
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// لنحفظ كل فيديو إلى ملف. لمنع استهلاك عالي للذاكرة، نحتاج إلى مخزن مؤقت سيُستخدم
	// لنقل البيانات من تدفق فيديو العرض إلى تدفق لملف فيديو تم إنشاؤه حديثًا.
	byte[] buffer = new byte[8 * 1024];

	// Iterates through the videos
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// يفتح تدفق فيديو العرض. يرجى ملاحظة أننا تجنبنا عمداً الوصول إلى الخصائص
		// مثل video.BinaryData - لأن هذه الخاصية تُعيد مصفوفة بايت تحتوي على الفيديو بالكامل، مما
		// يتسبب في تحميل البايتات إلى الذاكرة. نستخدم video.GetStream الذي سيعيد Stream - ولا
		//  يتطلب منا تحميل الفيديو بالكامل إلى الذاكرة.
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

		// ستظل استهلاك الذاكرة منخفضًا بغض النظر عن حجم الفيديو أو العرض التقديمي،
	}

	// إذا لزم الأمر، يمكنك تطبيق الخطوات نفسها على ملفات الصوت. 
}
```


### **إضافة صورة كـ BLOB إلى عرض تقديمي**
باستخدام طرق الواجهة [**IImageCollection**](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) والصف [**ImageCollection**](https://reference.aspose.com/slides/net/aspose.slides/imagecollection)، يمكنك إضافة صورة كبيرة كتيار لتُعامل كـ BLOB.

هذا الكود في C# يوضح كيفية إضافة صورة كبيرة عبر عملية BLOB:
```c#
string pathToLargeImage = "large_image.jpg";

// ينشئ عرض تقديمي جديد ستتم إضافة الصورة إليه.
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// لنضيف الصورة إلى العرض التقديمي - اخترنا سلوك KeepLocked لأننا
		// لا نعتزم الوصول إلى ملف "largeImage.png".
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// يحفظ العرض التقديمي. أثناء إخراج عرض تقديمي كبير، استهلاك الذاكرة 
		// يبقى منخفضًا طوال دورة حياة كائن pres
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```


## **الذاكرة والعروض التقديمية الكبيرة**

عادةً، لتحميل عرض تقديمي كبير، تحتاج الأجهزة إلى كمية كبيرة من الذاكرة المؤقتة. يتم تحميل كل محتوى العرض في الذاكرة ويتوقف استخدام الملف الأصلي الذي تم تحميل العرض منه.

خذ في الاعتبار عرض PowerPoint كبير (large.pptx) يحتوي على ملف فيديو بحجم 1.5 GB. الطريقة التقليدية لتحميل العرض موضحة في هذا الكود C#:
```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```


لكن هذه الطريقة تستهلك حوالي 1.6 GB من الذاكرة المؤقتة.

### **تحميل عرض تقديمي كبير كـ BLOB**

من خلال عملية تشمل BLOB، يمكنك تحميل عرض تقديمي كبير مع استهلاك قليل للذاكرة. يصف هذا الكود C# تنفيذ العملية حيث يُستخدم BLOB لتحميل ملف عرض تقديمي كبير (large.pptx):
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

عند استخدام عملية BLOB، ينشئ جهازك ملفات مؤقتة في المجلد الافتراضي للملفات المؤقتة. إذا رغبت في حفظ الملفات المؤقتة في مجلد مختلف، يمكنك تغيير إعدادات التخزين باستخدام `TempFilesRootPath`:
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
عند استخدام `TempFilesRootPath`، لا يقوم Aspose.Slides بإنشاء مجلد تلقائيًا لتخزين الملفات المؤقتة. يجب عليك إنشاء المجلد يدويًا.
{{% /alert %}}

## **التعليمات المتكررة**

**ما البيانات في عرض Aspose.Slides التي تُعامل كـ BLOB وتُتحكم فيها خيارات BLOB؟**

الكائنات الثنائية الكبيرة مثل الصور، الصوت، والفيديو تُعامل كـ BLOB. كذلك، ملف العرض الكامل يتضمن معالجة BLOB عند تحميله أو حفظه. تُحكم هذه الكائنات بسياسات BLOB التي تسمح لك بإدارة استهلاك الذاكرة وتحويل البيانات إلى ملفات مؤقتة حسب الحاجة.

**أين يمكنني تكوين قواعد معالجة BLOB أثناء تحميل العرض التقديمي؟**

استخدم [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) مع [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/). هناك يمكنك تحديد الحد الأقصى للذاكرة للـ BLOB، السماح بالملفات المؤقتة أو عدمها، اختيار مسار المجلد الجذر للملفات المؤقتة، وتحديد سلوك قفل المصدر.

**هل تؤثر إعدادات BLOB على الأداء، وكيف يمكن موازنة السرعة مقابل الذاكرة؟**

نعم. إبقاء BLOB في الذاكرة يزيد من السرعة لكنه يرفع استهلاك RAM؛ تقليل الحد المسموح للذاكرة يوجه المزيد من العمل إلى الملفات المؤقتة، ما يقلل RAM لكنه يزيد من عمليات الإدخال/الإخراج. اضبط عتبة [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/) لتحقيق التوازن المناسب لحِمل عملك وبيئتك.

**هل تساعد خيارات BLOB عند فتح عروض تقديمية هائلة الحجم (مثلاً بالغيغابايت)؟**

نعم. تم تصميم [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/) لهذه السيناريوهات: تمكين الملفات المؤقتة واستخدام قفل المصدر يمكن أن يقلل بشكل كبير من ذروة استهلاك RAM ويُثبِّت عملية المعالجة للعروض الكبيرة جدًا.

**هل يمكنني استخدام سياسات BLOB عند التحميل من التيارات بدلاً من ملفات القرص؟**

نعم. تنطبق القواعد نفسها على التيارات: يمكن للعرض أن يمتلك القفل ويقفل تدفق الإدخال (حسب وضع القفل المختار)، وتُستخدم الملفات المؤقتة عندما يُسمح بها، ما يحافظ على استهلاك ذاكرة متوقع أثناء المعالجة.