---
title: قفل العروض التقديمية
type: docs
weight: 110
url: /ar/net/presentation-locking/
---

## **قفل العروض التقديمية**
استخدام شائع لـ **Aspose.Slides** هو إنشاء وتحديث وحفظ عروض Microsoft PowerPoint 2007 (PPTX) كجزء من سير عمل تلقائي. يحصل مستخدمو التطبيق الذي يستخدم Aspose.Slides بهذه الطريقة على إمكانية الوصول إلى العروض الناتجة. حماية هذه العروض من التعديل هي مصدر قلق شائع. من المهم أن تحتفظ العروض المنشأة تلقائيًا بالتنسيق والمحتوى الأصليين.

تشرح هذه المقالة كيف يتم بناء العروض والشرائح وكيف يمكن لـ Aspose.Slides for .NET تطبيق الحماية عليها، ثم إزالتها من العرض. هذه الميزة فريدة لـ Aspose.Slides وفي وقت كتابة هذه المقالة غير متاحة في Microsoft PowerPoint. إنها توفر للمطورين وسيلة للتحكم في كيفية استخدام العروض التي تنشئها تطبيقاتهم.
## **تركيب الشريحة**
تتكون شريحة PPTX من عدد من المكونات مثل الأشكال التلقائية، الجداول، كائنات OLE، الأشكال المجمعة، إطارات الصور، إطارات الفيديو، الموصلات والعناصر الأخرى المتاحة لبناء عرض تقديمي.

في Aspose.Slides for .NET، يتم تحويل كل عنصر في الشريحة إلى كائن Shape. بمعنى آخر، كل عنصر في الشريحة إما كائن Shape أو كائن مشتق من Shape.

هيكل PPTX معقد، لذا على عكس PPT حيث يمكن استخدام قفل عام لجميع أنواع الأشكال، توجد أنواع مختلفة من الأقفال لأنواع الأشكال المختلفة. فئة BaseShapeLock هي الفئة العامة لقفل PPTX. الأنواع التالية من الأقفال مدعومة في Aspose.Slides for .NET لـ PPTX.

- AutoShapeLock يقفل الأشكال التلقائية.
- ConnectorLock يقفل أشكال الموصل.
- GraphicalObjectLock يقفل الكائنات الرسومية.
- GroupshapeLock يقفل الأشكال المجمعة.
- PictureFrameLock يقفل إطارات الصور.

أي إجراء يُجرى على جميع كائنات Shape في كائن Presentation يُطبق على العرض بالكامل.
## **تطبيق وإزالة الحماية**
تطبيق الحماية يضمن عدم إمكانية تعديل العرض. إنها تقنية مفيدة لحماية محتوى العرض.

**تطبيق الحماية على أشكال PPTX**

توفر Aspose.Slides for .NET الفئة Shape لمعالجة شكل في الشريحة.

كما ذكرنا سابقًا، كل فئة شكل لها فئة قفل شكل مرتبطة للحماية. تركز هذه المقالة على أقفال NoSelect و NoMove و NoResize. تضمن هذه الأقفال عدم إمكانية اختيار الأشكال (من خلال النقر بالفأرة أو طرق اختيار أخرى)، ولا إمكانية تحريكها أو تغيير حجمها.

القطع البرمجية التالية تطبق الحماية على جميع أنواع الأشكال في عرض تقديمي.

``` csharp

 //Instatiate Presentation class that represents a PPTX file

PresentationEx pTemplate = new PresentationEx("Applying Protection.pptx");//Instatiate Presentation class that represents a PPTX file


//ISlide object for accessing the slides in the presentation

SlideEx slide = pTemplate.Slides[0];

//IShape object for holding temporary shapes

ShapeEx shape;

//Traversing through all the slides in the presentation

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//Travesing through all the shapes in the slides

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//if shape is autoshape

		if (shape is AutoShapeEx)

		{

			//Type casting to Auto shape and  getting auto shape lock

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//Applying shapes locks

			AutoShapeLock.PositionLocked = true;

			AutoShapeLock.SelectLocked = true;

			AutoShapeLock.SizeLocked = true;

		}

		//if shape is group shape

		else if (shape is GroupShapeEx)

		{

			//Type casting to group shape and  getting group shape lock

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//Applying shapes locks

			groupShapeLock.GroupingLocked = true;

			groupShapeLock.PositionLocked = true;

			groupShapeLock.SelectLocked = true;

			groupShapeLock.SizeLocked = true;

		}

		//if shape is a connector

		else if (shape is ConnectorEx)

		{

			//Type casting to connector shape and  getting connector shape lock

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//Applying shapes locks

			ConnLock.PositionMove = true;

			ConnLock.SelectLocked = true;

			ConnLock.SizeLocked = true;

		}

		//if shape is picture frame

		else if (shape is PictureFrameEx)

		{

			//Type casting to picture frame shape and  getting picture frame shape lock

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//Applying shapes locks

			PicLock.PositionLocked = true;

			PicLock.SelectLocked = true;

			PicLock.SizeLocked = true;

		}

	}

}

//Saving the presentation file

pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 

**إزالة الحماية**

يمكن إزالة الحماية التي تم تطبيقها باستخدام Aspose.Slides for .NET فقط باستخدام Aspose.Slides for .NET. لإلغاء قفل شكل، اضبط قيمة القفل المطبق إلى false. يظهر المقتطع البرمجي التالي كيفية إلغاء قفل الأشكال في عرض مقفل.

``` csharp

 //Open the desired presentation

PresentationEx pTemplate = new PresentationEx("ProtectedSample.pptx");

//ISlide object for accessing the slides in the presentation

SlideEx slide = pTemplate.Slides[0];

//IShape object for holding temporary shapes

ShapeEx shape;

//Traversing through all the slides in presentation

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//Travesing through all the shapes in the slides

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//if shape is autoshape

		if (shape is AutoShapeEx)

		{

			//Type casting to Auto shape and  getting auto shape lock

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//Applying shapes locks

			AutoShapeLock.PositionLocked = false;

			AutoShapeLock.SelectLocked = false;

			AutoShapeLock.SizeLocked = false;

		}

		//if shape is group shape

		else if (shape is GroupShapeEx)

		{

			//Type casting to group shape and  getting group shape lock

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//Applying shapes locks

			groupShapeLock.GroupingLocked = false;

			groupShapeLock.PositionLocked = false;

			groupShapeLock.SelectLocked = false;

			groupShapeLock.SizeLocked = false;

		}

		//if shape is Connector shape

		else if (shape is ConnectorEx)

		{

			//Type casting to connector shape and  getting connector shape lock

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//Applying shapes locks

			ConnLock.PositionMove = false;

			ConnLock.SelectLocked = false;

			ConnLock.SizeLocked = false;

		}

		//if shape is picture frame

		else if (shape is PictureFrameEx)

		{

			//Type casting to pitcture frame shape and  getting picture frame shape lock

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//Applying shapes locks

			PicLock.PositionLocked = false;

			PicLock.SelectLocked = false;

			PicLock.SizeLocked = false;

		}

	}

}

//Saving the presentation file

pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **تحميل عينة الكود**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/812535)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Presentation%20Locking%20%28Aspose.Slides%29.zip)