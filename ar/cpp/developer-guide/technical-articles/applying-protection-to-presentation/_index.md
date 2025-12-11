---
title: "منع تعديل العروض التقديمية باستخدام أقفال الأشكال"
linktitle: "منع تعديل العروض التقديمية"
type: docs
weight: 10
url: /ar/cpp/applying-protection-to-presentation/
keywords:
- "منع التعديلات"
- "حماية من التحرير"
- "قفل الشكل"
- "قفل الموضع"
- "قفل الاختيار"
- "قفل الحجم"
- "قفل التجميع"
- PowerPoint
- OpenDocument
- "العرض التقديمي"
- C++
- Aspose.Slides
description: "اكتشف كيف تقوم Aspose.Slides for C++ بقفل أو إلغاء قفل الأشكال في ملفات PPT و PPTX و ODP، مما يضمن أمان العروض التقديمية مع السماح بتحرير مستنير وتسليم أسرع."
---

## **الخلفية**

الاستخدام الشائع لـ Aspose.Slides هو إنشاء وتحديث وحفظ عروض Microsoft PowerPoint (PPTX) كجزء من سير عمل تلقائي. يحصل مستخدمو التطبيقات التي تستخدم Aspose.Slides بهذه الطريقة على إمكانية الوصول إلى العروض التي تم إنشاؤها، لذا فإن حماية هذه العروض من التحرير تشكل قلقًا شائعًا. من المهم أن تحتفظ العروض التي تُنشأ تلقائيًا بتنسيقها الأصلي ومحتواها.

تشرح هذه المقالة كيفية بنية العروض والشرائح وكيف يمكن لـ Aspose.Slides for C++ تطبيق حماية على عرض ثم إزالتها لاحقًا. فهي توفّر للمطورين وسيلة للتحكم في طريقة استخدام العروض التي تولدها تطبيقاتهم.

## **تركيب الشريحة**

تتكوّن شريحة العرض من مكوّنات مثل الأشكال التلقائية، الجداول، كائنات OLE، الأشكال المجمعة، إطارات الصور، إطارات الفيديو، الموصلات، وعناصر أخرى تُستخدم لبناء العرض. في Aspose.Slides for C++، يُمثَّل كل عنصر على الشريحة بكائن ينفّذ الواجهة [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) أو يرث من فئة تقوم بذلك.

بنية PPTX معقّدة، لذا على عكس PPT حيث يمكن استخدام قفل عام لجميع أنواع الأشكال، تتطلّب أنواع الأشكال المختلفة أقفالًا مختلفة. الواجهة [IBaseShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseshapelock/) هي الفئة العامة للقفل في PPTX. الأنواع التالية من الأقفال مدعومة في Aspose.Slides for C++ لـ PPTX:

- [IAutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshapelock/) يقفل الأشكال التلقائية.  
- [IConnectorLock](https://reference.aspose.com/slides/cpp/aspose.slides/iconnectorlock/) يقفل أشكال الموصلات.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/) يقفل الكائنات الرسومية.  
- [IGroupShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/igroupshapelock/) يقفل الأشكال المجمعة.  
- [IPictureFrameLock](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframelock/) يقفل إطارات الصور.   

أي إجراء يُجرى على جميع كائنات الشكل في كائن [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) يُطبق على العرض بالكامل.

## **تطبيق وإزالة الحماية**

يضمن تطبيق الحماية عدم إمكانية تعديل العرض. إنها تقنية مفيدة لحماية محتوى العرض.

### **تطبيق الحماية على أشكال PPTX**

يوفر Aspose.Slides for C++ الواجهة [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) للعمل مع الأشكال على الشريحة.

كما ذُكر سابقًا، لكل فئة شكل فئة قفل شكل مرتبطة للحماية. تركز هذه المقالة على أقفال NoSelect و NoMove و NoResize. تضمن هذه الأقفال عدم إمكانية تحديد الأشكال (من خلال النقرات أو طرق اختيار أخرى) وعدم إمكانية نقلها أو تغيير حجمها.

عينة الشيفرة التالية تطبق الحماية على جميع أنواع الأشكال في عرض.
```cpp
// إنشاء كائن Presentation الذي يمثل ملف PPTX.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// استعراض جميع الشرائح في العرض.
for (auto&& slide : presentation->get_Slides())	{

	// استعراض جميع الأشكال في الشريحة.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// تحويل النوع إلى autoshape والحصول على قفل الشكل.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(true);
			autoShapeLock->set_SelectLocked(true);
			autoShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// تحويل النوع إلى شكل مجموعة والحصول على قفل الشكل.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(true);
			groupShapeLock->set_PositionLocked(true);
			groupShapeLock->set_SelectLocked(true);
			groupShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// تحويل النوع إلى شكل موصل والحصول على قفل الشكل.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(true);
			connectorShapeLock->set_SelectLocked(true);
			connectorShapeLock->set_SizeLocked(true);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// تحويل النوع إلى إطار صورة والحصول على قفل الشكل.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(true);
			pictureFrameLock->set_SelectLocked(true);
			pictureFrameLock->set_SizeLocked(true);
		}
	}
}

// حفظ ملف العرض.
presentation->Save(u"ProtectedSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


### **إزالة الحماية**

لإلغاء قفل شكل، اضبط قيمة القفل المطبق إلى `false`. تعرض عينة الشيفرة التالية كيفية إلغاء قفل الأشكال في عرض مقفل.
```cpp
// إنشاء كائن Presentation الذي يمثل ملف PPTX.
auto presentation = MakeObject<Presentation>(u"ProtectedSample.pptx");

// استعراض جميع الشرائح في العرض.
for (auto&& slide : presentation->get_Slides())	{

	// استعراض جميع الأشكال في الشريحة.
	for (auto&& shape : slide->get_Shapes()) {

		if (ObjectExt::Is<IAutoShape>(shape)) {
			// تحويل النوع إلى autoshape والحصول على قفل الشكل.
			auto autoShape = ExplicitCast<IAutoShape>(shape);
			auto autoShapeLock = ExplicitCast<IAutoShapeLock>(autoShape->get_ShapeLock());

			autoShapeLock->set_PositionLocked(false);
			autoShapeLock->set_SelectLocked(false);
			autoShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IGroupShape>(shape)) {
			// تحويل النوع إلى شكل مجموعة والحصول على قفل الشكل.
			auto groupShape = ExplicitCast<IGroupShape>(shape);
			auto groupShapeLock = ExplicitCast<IGroupShapeLock>(groupShape->get_ShapeLock());

			groupShapeLock->set_GroupingLocked(false);
			groupShapeLock->set_PositionLocked(false);
			groupShapeLock->set_SelectLocked(false);
			groupShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IConnector>(shape)) {
			// تحويل النوع إلى شكل موصل والحصول على قفل الشكل.
			auto connectorShape = ExplicitCast<IConnector>(shape);
			auto connectorShapeLock = ExplicitCast<IConnectorLock>(connectorShape->get_ShapeLock());
			
			connectorShapeLock->set_PositionMove(false);
			connectorShapeLock->set_SelectLocked(false);
			connectorShapeLock->set_SizeLocked(false);
		}
		else if (ObjectExt::Is<IPictureFrame>(shape)) {
			// تحويل النوع إلى إطار صورة والحصول على قفل الشكل.
			auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
			auto pictureFrameLock = ExplicitCast<IPictureFrameLock>(pictureFrame->get_ShapeLock());
		
			pictureFrameLock->set_PositionLocked(false);
			pictureFrameLock->set_SelectLocked(false);
			pictureFrameLock->set_SizeLocked(false);
		}
	}
}

// حفظ ملف العرض.
presentation->Save(u"RemovedProtectionSample.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **الخلاصة**

يقدّم Aspose.Slides عدة خيارات لحماية الأشكال في العرض. يمكنك قفل شكل فردي أو التكرار عبر جميع الأشكال في العرض وقفل كلٍ منها لتأمين الملف بالكامل بفعالية. يمكنك إزالة الحماية عن طريق ضبط قيمة القفل إلى `false`.

## **الأسئلة الشائعة**

**هل يمكنني الجمع بين أقفال الأشكال وحماية كلمة المرور في نفس العرض؟**

نعم. تحدّ القفلات من تحرير الكائنات داخل الملف، بينما [password protection](/slides/ar/cpp/password-protected-presentation/) يتحكم في الوصول إلى فتح الملف و/أو حفظ التغييرات. تكمل هذه الآليات بعضها البعض وتعمل معًا.

**هل يمكنني تقييد التحرير على شرائح معينة دون التأثير على الأخرى؟**

نعم. طبّق القفلات على الأشكال في الشرائح المحددة؛ ستظل الشرائح المتبقية قابلة للتحرير.

**هل تنطبق أقفال الأشكال على الكائنات المجمعة والموصلات؟**

نعم. تتوفر أنواع أقفال مخصصة للمجموعات، والموصلات، والكائنات الرسومية، وأنواع الأشكال الأخرى.