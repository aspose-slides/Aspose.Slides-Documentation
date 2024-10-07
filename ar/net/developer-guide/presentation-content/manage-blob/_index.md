---
title: إدارة البلوبيات
type: docs
weight: 10
url: /net/manage-blob/
keywords: "إضافة بلوبي، تصدير بلوبي، إضافة صورة كبلوبي، عرض تقديمي لبرنامج PowerPoint، C#، Csharp، Aspose.Slides لـ .NET"
description: "إضافة بلوبي إلى عرض PowerPoint التقديمي في C# أو .NET. تصدير بلوبي. إضافة صورة كبلوبي"
---

## **حول BLOB**

**BLOB** (**كائن ثنائي كبير**) هو عادة عنصر كبير (صورة، عرض تقديمي، مستند، أو وسائط) محفوظ بصيغ ثنائية.

يتيح لك Aspose.Slides لـ .NET استخدام الـ BLOBs للأشياء بطريقة تقلل من استهلاك الذاكرة عند التعامل مع ملفات كبيرة.

## **استخدام BLOB لتقليل استهلاك الذاكرة**

### **إضافة ملف كبير من خلال BLOB إلى عرض تقديمي**

يتيح لك [Aspose.Slides](/slides/net/) لـ .NET إضافة ملفات كبيرة (في هذه الحالة، ملف فيديو كبير) من خلال عملية تتضمن BLOBs لتقليل استهلاك الذاكرة.

يوضح هذا الكود C# كيفية إضافة ملف فيديو كبير من خلال عملية BLOB إلى عرض تقديمي:

```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// ينشئ عرض تقديمي جديد سيتم إضافة الفيديو إليه
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // لنضيف الفيديو إلى العرض - اخترنا سلوك KeepLocked لأننا لا 
        // نعتزم الوصول إلى ملف "veryLargeVideo.avi".
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // يحفظ العرض التقديمي. بينما يتم إخراج عرض تقديمي كبير، يظل استهلاك الذاكرة
        // منخفضاً طوال دورة حياة كائن pres 
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```


### **تصدير ملف كبير من خلال BLOB من عرض تقديمي**
يتيح لك Aspose.Slides لـ .NET تصدير ملفات كبيرة (في هذه الحالة، ملف صوت أو فيديو) من خلال عملية تتضمن BLOBs من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج ملف وسائط كبير من عرض تقديمي لكن لا تريد تحميل الملف في ذاكرة الكمبيوتر. من خلال تصدير الملف عبر عملية BLOB، يمكنك الحفاظ على استهلاك الذاكرة منخفضًا.

يوضح هذا الكود C# العملية الموصوفة:

```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// يقفل الملف المصدر ولا يحمل في الذاكرة
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// ينشئ مثيل للعرض المدرج، يقفل ملف "hugePresentationWithAudiosAndVideos.pptx".
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// دعونا نحفظ كل فيديو في ملف. لمنع استهلاك الذاكرة العالية، نحتاج إلى مخزن سيتم استخدامه
	// لنقل البيانات من دفق فيديو العرض إلى دفق لملف فيديو جديد تم إنشاؤه.
	byte[] buffer = new byte[8 * 1024];

	// يتكرر عبر الفيديوهات
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// يفتح دفق فيديو العرض. يرجى ملاحظة أننا تجنبنا عمدًا الوصول إلى الخصائص
		// مثل video.BinaryData - لأن هذه الخاصية تعيد مصفوفة بايت تحتوي على فيديو كامل، مما يتسبب بعد ذلك
		// في تحميل البايتات في الذاكرة. نحن نستخدم video.GetStream، التي ستعيد Stream - ولا تتطلب منا
		// تحميل الفيديو بالكامل في الذاكرة.
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

		// سيظل استهلاك الذاكرة منخفضاً بغض النظر عن حجم الفيديو أو العرض،
	}

	// إذا لزم الأمر، يمكنك تطبيق نفس الخطوات لملفات الصوت.
}
```

### **إضافة صورة كـ BLOB في العرض التقديمي**
مع الطرق من واجهة [**IImageCollection**](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) و [**ImageCollection**](https://reference.aspose.com/slides/net/aspose.slides/imagecollection)، يمكنك إضافة صورة كبيرة كتيار ليتم التعامل معها كـ BLOB.

يوضح هذا الكود C# كيفية إضافة صورة كبيرة عبر عملية BLOB:

```c#
string pathToLargeImage = "large_image.jpg";

// ينشئ عرض تقديمي جديد سيتم إضافة الصورة إليه.
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// لنضيف الصورة إلى العرض - اخترنا سلوك KeepLocked لأننا لا
		// نعتزم الوصول إلى ملف "largeImage.png".
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// يحفظ العرض التقديمي. بينما يتم إخراج عرض تقديمي كبير، يظل استهلاك الذاكرة 
		// منخفضًا طوال دورة حياة كائن pres
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```

## **الذاكرة والعروض التقديمية الكبيرة**

عادةً، لتحميل عرض تقديمي كبير، تتطلب أجهزة الكمبيوتر ذاكرة مؤقتة كبيرة. يتم تحميل محتوى العرض بأكمله في الذاكرة ويتوقف استخدام الملف (الذي تم تحميل العرض منه).

افترض عرض تقديمي كبير لبرنامج PowerPoint (large.pptx) يحتوي على ملف فيديو بحجم 1.5 جيجابايت. الطريقة القياسية لتحميل العرض الواردة في هذا الكود C#:

```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

لكن هذه الطريقة تستهلك حوالي 1.6 جيجابايت من الذاكرة المؤقتة.

### **تحميل عرض تقديمي كبير كـ BLOB**

من خلال العملية التي تتضمن BLOB، يمكنك تحميل عرض تقديمي كبير مع استخدام ذاكرة قليلة. يصف هذا الكود C# تنفيذ العملية التي يتم من خلالها استخدام عملية BLOB لتحميل ملف عرض تقديمي كبير (large.pptx):

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

عند استخدام عملية BLOB، يقوم جهاز الكمبيوتر الخاص بك بإنشاء ملفات مؤقتة في المجلد الافتراضي للملفات المؤقتة. إذا كنت ترغب في الاحتفاظ بالملفات المؤقتة في مجلد مختلف، يمكنك تغيير الإعدادات للتخزين باستخدام `TempFilesRootPath`:

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

عند استخدام `TempFilesRootPath`، لا يقوم Aspose.Slides بإنشاء مجلد تلقائيًا لتخزين الملفات المؤقتة. عليك إنشاء المجلد يدويًا.

{{% /alert %}}