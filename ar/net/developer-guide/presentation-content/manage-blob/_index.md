---
title: إدارة Blob
type: docs
weight: 10
url: /ar/net/manage-blob/
keywords: "إضافة blob, تصدير blob, إضافة صورة كـ blob, عرض PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "إضافة blob إلى عرض PowerPoint في C# أو .NET. تصدير blob. إضافة صورة كـ blob"
---

## **حول BLOB**

**BLOB** (**Binary Large Object**) عادةً ما يكون عنصرًا كبيرًا (صورة، عرض تقديمي، مستند، أو وسائط) محفوظًا بتنسيقات ثنائية.

يتيح لك Aspose.Slides for .NET استخدام كائنات BLOB للكائنات بطريقة تقلل استهلاك الذاكرة عندما تكون الملفات الكبيرة متضمنة.

## **استخدام BLOB لتقليل استهلاك الذاكرة**

### **إضافة ملف كبير عبر BLOB إلى عرض تقديمي**

[Aspose.Slides](/slides/ar/net/) for .NET يتيح لك إضافة ملفات كبيرة (في هذه الحالة، ملف فيديو كبير) عبر عملية تتضمن BLOBs لتقليل استهلاك الذاكرة.

This C# shows you how to add a large video file through the BLOB process to a presentation:
```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

        // ينشئ عرضًا تقديميًا جديدًا سيُضاف إليه الفيديو
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // دعنا نضيف الفيديو إلى العرض التقديمي - اخترنا سلوك KeepLocked لأننا نريد
//ليس لدينا نية للوصول إلى الملف "veryLargeVideo.avi" الملف.
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // يحفظ العرض التقديمي. بينما يتم إخراج عرض تقديمي كبير، يظل استهلاك الذاكرة
//منخفضًا طوال دورة حياة كائن pres 
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```


### **تصدير ملف كبير عبر BLOB من العرض التقديمي**
يتيح لك Aspose.Slides for .NET تصدير ملفات كبيرة (في هذه الحالة، ملف صوت أو فيديو) عبر عملية تتضمن BLOBs من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج ملف وسائط كبير من عرض تقديمي ولكن لا تريد تحميل الملف إلى ذاكرة حاسوبك. من خلال تصدير الملف عبر عملية BLOB، يمكنك الحفاظ على استهلاك الذاكرة منخفضًا.

This code in C# demonstrates the described operation:
```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// يقفل ملف المصدر ولا يتم تحميله إلى الذاكرة
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// ينشئ مثيلًا للعرض التقديمي، ويقفل ملف "hugePresentationWithAudiosAndVideos.pptx".
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// لنقم بحفظ كل فيديو إلى ملف. لتجنب استهلاك عالي للذاكرة، نحتاج إلى مخزن وسيط سيُستخدم
	// لنقل البيانات من تدفق فيديو العرض التقديمي إلى تدفق ملف فيديو تم إنشاؤه حديثًا.
	byte[] buffer = new byte[8 * 1024];

	// يتنقل عبر مقاطع الفيديو
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// يفتح تدفق فيديو العرض التقديمي. يرجى ملاحظة أننا تجنبنا عمدًا الوصول إلى الخصائص
		// مثل video.BinaryData - لأن هذه الخاصية تُرجع مصفوفة بايت تحتوي على فيديو كامل، وهو ما
		// يسبب تحميل البايتات إلى الذاكرة. نستخدم video.GetStream، الذي سيُعيد Stream - ولا يقوم
		//  لا يتطلب تحميل الفيديو بالكامل إلى الذاكرة.
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


### **إضافة صورة كـ BLOB في العرض التقديمي**
باستخدام الأساليب من واجهة [**IImageCollection**](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) والفئة [**ImageCollection**](https://reference.aspose.com/slides/net/aspose.slides/imagecollection) يمكنك إضافة صورة كبيرة كتيار لتتم معالجتها كـ BLOB.

This C# code shows you how to add a large image through the BLOB process:
```c#
string pathToLargeImage = "large_image.jpg";

// ينشئ عرضًا تقديميًا جديدًا سيتم إضافة الصورة إليه.
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
    {
        // دعنا نضيف الصورة إلى العرض التقديمي - نختار سلوك KeepLocked لأننا
        // لا نعتزم الوصول إلى ملف "largeImage.png" الملف.
        IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

        // يحفظ العرض التقديمي. بينما يتم إخراج عرض تقديمي كبير، استهلاك الذاكرة 
        // يبقى منخفضًا طوال دورة حياة كائن pres
        pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
    }
}
```


## **الذاكرة والعروض التقديمية الكبيرة**

عادةً، لتحميل عرض تقديمي كبير، تحتاج الحواسيب إلى الكثير من الذاكرة المؤقتة. يتم تحميل كل محتوى العرض التقديمي إلى الذاكرة ويتوقف استخدام الملف (الذي تم تحميل العرض منه).

Consider a large PowerPoint presentation (large.pptx) that contains a 1.5 GB video file. The standard method for loading the presentation is described in this C# code:
```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```


لكن هذه الطريقة تستهلك حوالي 1.6 جيجا بايت من الذاكرة المؤقتة.

### **تحميل عرض تقديمي كبير كـ BLOB**
Through the process involving a BLOB, you can load up a large presentation while using little memory. This C# code describes the implementation where the BLOB process is used to load up a large presentation file (large.pptx):
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
When the BLOB process is used, your computer creates temporary files in the default folder for temporary files. If you want the temporary files to be kept in a different folder, you can change the settings for storage using `TempFilesRootPath`:
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
عند استخدامك `TempFilesRootPath`، لا يقوم Aspose.Slides بإنشاء مجلد لتخزين الملفات المؤقتة تلقائيًا. عليك إنشاء المجلد يدويًا.
{{% /alert %}}

## **الأسئلة الشائعة**

**ما هي البيانات في عرض Aspose.Slides التي تُعامل كـ BLOB وتتحكم فيها خيارات BLOB؟**
الكائنات الثنائية الكبيرة مثل الصور والصوت والفيديو تُعامل كـ BLOB. كما يتضمن ملف العرض التقديمي بالكامل معالجة BLOB عند تحميله أو حفظه. هذه الكائنات تحكمها سياسات BLOB التي تسمح لك بإدارة استخدام الذاكرة وتحويل البيانات إلى ملفات مؤقتة عند الحاجة.

**أين يمكنني تكوين قواعد معالجة BLOB أثناء تحميل العرض التقديمي؟**
استخدم [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) مع [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/). هناك تقوم بتعيين الحد الأقصى للذاكرة للكائنات BLOB، السماح أو عدم السماح بالملفات المؤقتة، اختيار المسار الجذري للملفات المؤقتة، واختيار سلوك قفل المصدر.

**هل تؤثر إعدادات BLOB على الأداء، وكيف يمكن موازنة السرعة مقابل الذاكرة؟**
نعم. الحفاظ على BLOB في الذاكرة يزيد السرعة ولكنه يزيد استهلاك الذاكرة RAM؛ خفض الحد الأقصى للذاكرة يوجه المزيد من العمل إلى الملفات المؤقتة، مما يقلل الذاكرة على حساب مزيد من عمليات الإدخال/الإخراج. قم بضبط الحد [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/) لتحقيق التوازن المناسب لسيناريو العمل والبيئة الخاصة بك.

**هل تساعد خيارات BLOB عند فتح عروض تقديمية ضخمة جدًا (مثلاً عدة جيجابايت)؟**
نعم. تم تصميم [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/) لمثل هذه السيناريوهات: تمكين الملفات المؤقتة واستخدام قفل المصدر يمكن أن يقلل بشكل كبير من ذروة استهلاك RAM ويستقر عملية المعالجة للعروض الضخمة جدًا.

**هل يمكنني استخدام سياسات BLOB عند التحميل من التدفقات بدلاً من ملفات القرص؟**
نعم. القواعد نفسها تنطبق على التدفقات: يمكن لكائن العرض التقديمي امتلاك وقفل تدفق الإدخال (حسب وضع القفل المختار)، وتُستخدم الملفات المؤقتة عندما يُسمح بذلك، مما يحافظ على استهلاك الذاكرة متوقعًا أثناء المعالجة.