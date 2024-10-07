---
title: قفل العروض التقديمية
type: docs
weight: 110
url: /net/presentation-locking/
---

## **قفل العروض التقديمية**
استخدام شائع لـ **Aspose.Slides** هو إنشاء وتحديث وحفظ عروض Microsoft PowerPoint 2007 (PPTX) كجزء من سير عمل مؤتمت. يحصل مستخدمو التطبيق الذي يستخدم Aspose.Slides بهذه الطريقة على الوصول إلى العروض التقديمية الناتجة. حماية هذه العروض من التحرير هي قضية شائعة. من المهم أن تحافظ العروض التقديمية المولدة تلقائيًا على التنسيق والمحتوى الأصليين.

هذا يشرح كيفية بناء العروض التقديمية والشرائح وكيف يمكن لـ Aspose.Slides لـ .NET تطبيق الحماية على عرض تقديمي، ثم إزالتها. هذه الميزة فريدة من نوعها لـ Aspose.Slides، وفي وقت كتابة هذا المقال، غير متاحة في Microsoft PowerPoint. إنها تعطي المطورين وسيلة للتحكم في كيفية استخدام العروض التقديمية التي تنشئها تطبيقاتهم.
## **تركيب الشريحة**
تتكون شريحة PPTX من عدد من المكونات مثل الأشكال التلقائية، الجداول، كائنات OLE، الأشكال المجمعة، إطارات الصور، إطارات الفيديو، الموصلات والعناصر المختلفة الأخرى المتاحة لبناء عرض تقديمي.

في Aspose.Slides لـ .NET، يتم تحويل كل عنصر على الشريحة إلى كائن Shape. بعبارة أخرى، كل عنصر على الشريحة هو إما كائن Shape أو كائن مشتق من كائن Shape.

هيكل PPTX معقد، لذا على عكس PPT، حيث يمكن استخدام قفل عام لجميع أنواع الأشكال، هناك أنواع مختلفة من الأقفال لأنواع الأشكال المختلفة. فئة BaseShapeLock هي الفئة العامة لقفل PPTX. الأنواع التالية من الأقفال مدعومة في Aspose.Slides لـ .NET لـ PPTX.

- AutoShapeLock يقفل الأشكال التلقائية.
- ConnectorLock يقفل الأشكال الموصلين.
- GraphicalObjectLock يقفل الكائنات الرسومية.
- GroupshapeLock يقفل الأشكال المجمعة.
- PictureFrameLock يقفل إطارات الصور.

أي إجراء يتم تنفيذه على جميع كائنات Shape في كائن Presentation يتم تطبيقه على العرض التقديمي بالكامل.
## **تطبيق وإزالة الحماية**
تطبيق الحماية يضمن عدم إمكانية تحرير العرض التقديمي. إنها تقنية مفيدة لحماية محتوى العرض التقديمي.

**تطبيق الحماية على أشكال PPTX**

تقدم Aspose.Slides لـ .NET فئة Shape للتعامل مع شكل على الشريحة.

كما ذكر سابقًا، تحتوي كل فئة شكل على فئة قفل شكل مرتبطة بها للحماية. يركز هذا المقال على الأقفال NoSelect وNoMove وNoResize. تضمن هذه الأقفال أن الأشكال لا يمكن تحديدها (من خلال نقرات الماوس أو طرق التحديد الأخرى)، ولا يمكن نقلها أو تغيير حجمها.

عينة الكود التي تتبع تطبق الحماية على جميع أنواع الأشكال في عرض تقديمي.

``` csharp

 //إنشاء كائن Presentation يمثل ملف PPTX

PresentationEx pTemplate = new PresentationEx("Applying Protection.pptx"); //إنشاء كائن Presentation يمثل ملف PPTX


//كائن ISlide للوصول إلى الشرائح في العرض التقديمي

SlideEx slide = pTemplate.Slides[0];

//كائن IShape للاحتفاظ بالأشكال المؤقتة

ShapeEx shape;

//التنقل عبر جميع الشرائح في العرض التقديمي

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//التنقل عبر جميع الأشكال في الشرائح

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//إذا كان الشكل هو شكل تلقائي

		if (shape is AutoShapeEx)

		{

			//تحويل إلى شكل تلقائي والحصول على قفل الشكل التلقائي

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//تطبيق أقفال الأشكال

			AutoShapeLock.PositionLocked = true;

			AutoShapeLock.SelectLocked = true;

			AutoShapeLock.SizeLocked = true;

		}

		//إذا كان الشكل هو شكل مجموعة

		else if (shape is GroupShapeEx)

		{

			//تحويل إلى شكل مجموعة والحصول على قفل شكل المجموعة

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//تطبيق أقفال الأشكال

			groupShapeLock.GroupingLocked = true;

			groupShapeLock.PositionLocked = true;

			groupShapeLock.SelectLocked = true;

			groupShapeLock.SizeLocked = true;

		}

		//إذا كان الشكل موصلًا

		else if (shape is ConnectorEx)

		{

			//تحويل إلى شكل موصل والحصول على قفل شكل الموصل

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//تطبيق أقفال الأشكال

			ConnLock.PositionMove = true;

			ConnLock.SelectLocked = true;

			ConnLock.SizeLocked = true;

		}

		//إذا كان الشكل هو إطار صورة

		else if (shape is PictureFrameEx)

		{

			//تحويل إلى شكل إطار صورة والحصول على قفل شكل إطار الصورة

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//تطبيق أقفال الأشكال

			PicLock.PositionLocked = true;

			PicLock.SelectLocked = true;

			PicLock.SizeLocked = true;

		}

	}

}

//حفظ ملف العرض التقديمي

pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 

**إزالة الحماية**

يمكن إزالة الحماية التي تم تطبيقها باستخدام Aspose.Slides لـ .NET فقط باستخدام Aspose.Slides لـ .NET. لفتح شكل، قم بتعيين قيمة القفل المطبق على false. عينة الكود التي تتبع توضح كيفية فتح الأشكال في عرض تقديمي مقفل.

``` csharp

 //فتح العرض التقديمي المطلوب

PresentationEx pTemplate = new PresentationEx("ProtectedSample.pptx");

//كائن ISlide للوصول إلى الشرائح في العرض التقديمي

SlideEx slide = pTemplate.Slides[0];

//كائن IShape للاحتفاظ بالأشكال المؤقتة

ShapeEx shape;

//التنقل عبر جميع الشرائح في العرض التقديمي

for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)

{

	slide = pTemplate.Slides[slideCount];

	//التنقل عبر جميع الأشكال في الشرائح

	for (int count = 0; count < slide.Shapes.Count; count++)

	{

		shape = slide.Shapes[count];

		//إذا كان الشكل هو شكل تلقائي

		if (shape is AutoShapeEx)

		{

			//تحويل إلى شكل تلقائي والحصول على قفل شكل تلقائي

			AutoShapeEx Ashp = shape as AutoShapeEx;

			AutoShapeLockEx AutoShapeLock = Ashp.ShapeLock;

			//تطبيق أقفال الأشكال

			AutoShapeLock.PositionLocked = false;

			AutoShapeLock.SelectLocked = false;

			AutoShapeLock.SizeLocked = false;

		}

		//إذا كان الشكل هو شكل مجموعة

		else if (shape is GroupShapeEx)

		{

			//تحويل إلى شكل مجموعة والحصول على قفل شكل المجموعة

			GroupShapeEx Group = shape as GroupShapeEx;

			GroupShapeLockEx groupShapeLock = Group.ShapeLock;

			//تطبيق أقفال الأشكال

			groupShapeLock.GroupingLocked = false;

			groupShapeLock.PositionLocked = false;

			groupShapeLock.SelectLocked = false;

			groupShapeLock.SizeLocked = false;

		}

		//إذا كان الشكل هو شكل موصل

		else if (shape is ConnectorEx)

		{

			//تحويل إلى شكل موصل والحصول على قفل شكل الموصل

			ConnectorEx Conn = shape as ConnectorEx;

			ConnectorLockEx ConnLock = Conn.ShapeLock;

			//تطبيق أقفال الأشكال

			ConnLock.PositionMove = false;

			ConnLock.SelectLocked = false;

			ConnLock.SizeLocked = false;

		}

		//إذا كان الشكل هو إطار صورة

		else if (shape is PictureFrameEx)

		{

			//تحويل إلى شكل إطار صورة والحصول على قفل شكل إطار الصورة

			PictureFrameEx Pic = shape as PictureFrameEx;

			PictureFrameLockEx PicLock = Pic.ShapeLock;

			//تطبيق أقفال الأشكال

			PicLock.PositionLocked = false;

			PicLock.SelectLocked = false;

			PicLock.SizeLocked = false;

		}

	}

}

//حفظ ملف العرض التقديمي

pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **تنزيل عينة الكود**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/812535)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Presentation%20Locking%20%28Aspose.Slides%29.zip)