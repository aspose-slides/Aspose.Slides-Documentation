---
title: تخطيط الشريحة
type: docs
weight: 60
url: /ar/cpp/slide-layout/
keyword: "تعيين حجم الشريحة، تعيين خيارات الشريحة، تحديد حجم الشريحة، رؤية التذييل، تذييل فرعي، تغيير حجم المحتوى، حجم الصفحة، C++، CPP، Aspose.Slides"
description: "تعيين حجم الشريحة وخياراتها في C++"
---

يحتوي تخطيط الشريحة على صناديق النماذج ومعلومات التنسيق لكافة المحتوى الذي يظهر على الشريحة. يحدد التخطيط أماكن نماذج المحتوى المتاحة ومكان وضعها.

تسمح تخطيطات الشرائح لك بإنشاء وتصميم العروض التقديمية بسرعة (سواء كانت بسيطة أو معقدة). وهذه بعض من أكثر تخطيطات الشرائح شيوعًا المستخدمة في العروض التقديمية في PowerPoint:

* **تخطيط شريحة العنوان**. يتكون هذا التخطيط من نموذجين نصيين. نموذج واحد هو للعناوين والنموذج الآخر للعنوان الفرعي.
* **تخطيط العنوان والمحتوى**. يحتوي هذا التخطيط على نموذج صغير نسبيًا في الأعلى للعنوان ونموذج أكبر للمحتوى الأساسي (رسم بياني، فقرات، قائمة نقطية، قائمة مرقمة، صور، إلخ).
* **تخطيط فارغ**. يفتقر هذا التخطيط إلى النماذج، مما يسمح لك بإنشاء عناصر من الصفر.

نظرًا لأن الشريحة الرئيسية هي الشريحة الهرمية العليا التي تخزن المعلومات حول تخطيطات الشرائح، يمكنك استخدام الشريحة الرئيسية للوصول إلى تخطيطات الشرائح وإجراء تغييرات عليها. يمكن الوصول إلى شريحة التخطيط حسب النوع أو الاسم. وبالمثل، تحتوي كل شريحة على معرف فريد يمكن استخدامه للوصول إليها.

بدلاً من ذلك، يمكنك إجراء تغييرات مباشرة على تخطيط شريحة معين في عرض تقديمي.

* لتمكينك من العمل مع تخطيطات الشرائح (بما في ذلك تلك الموجودة في الشرائح الرئيسية)، توفر Aspose.Slides خصائص مثل [get_LayoutSlides()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_layoutslides/) و[get_Masters()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) تحت فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
* لأداء المهام ذات الصلة، توفر Aspose.Slides [MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/)، [MasterLayoutSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/masterlayoutslidecollection/)، [SlideSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/)، [BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/cpp/aspose.slides/baseslideheaderfootermanager/)، والعديد من الأنواع الأخرى.

{{% alert title="معلومات" color="info" %}}

لمزيد من المعلومات حول العمل مع الشرائح الرئيسية بشكل خاص، انظر إلى مقال [Slide Master](https://docs.aspose.com/slides/cpp/slide-master/).

{{% /alert %}}

## **إضافة تخطيط شريحة إلى العرض التقديمي**

1. أنشئ مثيل لفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. الوصول إلى مجموعة [MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/imasterlayoutslidecollection/).
1. قم بمراجعة تخطيطات الشرائح الموجودة لتأكيد أن تخطيط الشريحة المطلوب موجود بالفعل في مجموعة تخطيطات الشرائح. خلاف ذلك، أضف تخطيط الشريحة الذي تريده.
1. أضف شريحة فارغة بناءً على تخطيط الشريحة الجديد.
1. احفظ العرض التقديمي.

يوضح لك هذا الكود C++ كيفية إضافة تخطيط شريحة إلى عرض تقديمي في PowerPoint:

```c++
	// المسار إلى مجلد المستندات.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/AddLayoutSlides.pptx";

	// ينشئ مثيل من فئة Presentation التي تمثل ملف العرض التقديمي
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// يستعرض أنواع تخطيطات الشرائح
	SharedPtr<IMasterLayoutSlideCollection> layoutSlides = pres->get_Masters()->idx_get(0)->get_LayoutSlides();

	SharedPtr<ILayoutSlide> layoutSlide;
	if (layoutSlides->GetByType(SlideLayoutType::TitleAndObject) != NULL)
	{
		layoutSlide = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);
	}
	else if (layoutSlides->GetByType(SlideLayoutType::Title) != NULL)
	{
		layoutSlide = layoutSlides->GetByType(SlideLayoutType::Title);
	}

	if (layoutSlide == NULL)
	{
		// الحالة التي لا تحتوي فيها العرض التقديمي على بعض أنواع التخطيطات.
		// يحتوي ملف العرض التقديمي فقط على أنواع تخطيطات فارغة ومخصصة.
		// لكن الشرائح التخطيطية لأنواع مخصصة لها أسماء شرائح مختلفة،
		// مثل "Title"، "Title and Content"، إلخ. ومن الممكن استخدام هذه
		// الأسماء لاختيار تخطيط الشريحة.
		// يمكنك أيضًا استخدام مجموعة من أنواع أشكال النماذج. على سبيل المثال،
		// ينبغي أن تحتوي شريحة العنوان على نوع نموذج العنوان فقط، إلخ.

		for (int i = 0; i<layoutSlides->get_Count(); i++)
		{
			SharedPtr<ILayoutSlide> titleAndObjectLayoutSlide = layoutSlides->idx_get(i);

			if (titleAndObjectLayoutSlide->get_Name().Equals(u"Title and Object"))
			{
				layoutSlide = titleAndObjectLayoutSlide;
				break;
			}
		}

		if (layoutSlide == NULL)
		{
			for (int i = 0; i < layoutSlides->get_Count(); i++)
			{
				SharedPtr<ILayoutSlide> titleLayoutSlide = layoutSlides->idx_get(i);

				if (titleLayoutSlide->get_Name().Equals(u"Title"))
				{
					layoutSlide = titleLayoutSlide;
					break;
				}
			}

			if (layoutSlide == NULL)
			{
				layoutSlide = layoutSlides->GetByType(SlideLayoutType::Blank);
				if (layoutSlide == NULL)
				{
					layoutSlide = layoutSlides->Add(SlideLayoutType::TitleAndObject, u"Title and Object");
				}
			}
		}
	}

	// يضيف شريحة فارغة مع تخطيط الشريحة المضاف  
	pres->get_Slides()->InsertEmptySlide(0, layoutSlide);

	// يحفظ العرض التقديمي على القرص
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **إزالة تخطيط الشريحة غير المستخدم**

توفر Aspose.Slides طريقة [RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) من فئة [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) للسماح لك بحذف تخطيطات الشرائح غير المرغوب فيها وغير المستخدمة. يوضح لك هذا الكود C++ كيفية إزالة تخطيط شريحة من عرض تقديمي في PowerPoint:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);

```

## **تعيين الحجم والنوع لتخطيط الشريحة**

لتمكينك من تعيين الحجم والنوع لتخطيط شريحة محدد، توفر Aspose.Slides خصائص [get_Type()](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/get_type/) و[get_Size()](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/get_size/) (من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)). توضح لك هذه C++ كيفية تنفيذ العملية:

```c++
	// المسار إلى مجلد المستندات.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/CloneToAnotherPresentationWithSetSizeAndType.pptx";
	// ينشئ مثيل من فئة Presentation التي تمثل ملف عرض تقديمي
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	SharedPtr<Presentation> destPres = MakeObject<Presentation>();

	// الوصول إلى الشريحة حسب المعرف من المجموعة
	SharedPtr<ISlideCollection> slideCollection = destPres->get_Slides();
	
	// تعيين حجم الشريحة للعرض التقديمي المولد إلى ذلك الخاص بالمصدر
	destPres->get_SlideSize()->SetSize(pres->get_SlideSize()->get_Type(), Aspose::Slides::SlideSizeScaleType::DoNotScale);

	slideCollection->InsertClone(1, pres->get_Slides()->idx_get(0));

	// يحفظ العرض التقديمي على القرص
	destPres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **تعيين رؤية التذييل داخل الشريحة**

1. أنشئ مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. احصل على مرجع الشريحة من خلال مؤشرها.
1. اجعل نموذج تذييل الشريحة مرئيًا.
1. اجعل نموذج التاريخ والوقت مرئيًا.
1. احفظ العرض التقديمي.

يوضح لك هذا الكود C++ كيفية تعيين رؤية لتذييل الشريحة (وأداء المهام ذات الصلة):

```c++
 // المسار إلى مجلد المستندات.
const String outPath = u"../out/HeaderFooterManager_out.pptx";

SharedPtr<Presentation> presentation = MakeObject<Presentation>();

// ينشئ مثيل من فئة SlideCollection
SharedPtr<ISlideCollection> slds = presentation->get_Slides();

//	SharedPtr<IBaseSlideHeaderFooterManager> headerFooterManager = presentation->get_Slides()->idx_get(0)->get_HeaderFooterManager();
SharedPtr<IMasterSlideHeaderFooterManager> headerFooterManager = presentation->get_Masters()->idx_get(0)->get_HeaderFooterManager();
if (!headerFooterManager->get_IsFooterVisible()) // خاصية IsFooterVisible تستخدم لتحديد أن نموذج تذييل الشريحة مفقود
{
	headerFooterManager->SetFooterVisibility(true); // يتم استخدام طريقة SetFooterVisibility لتعيين نموذج تذييل الشريحة ليكون مرئيًا
}
if (!headerFooterManager->get_IsSlideNumberVisible()) // خاصية IsSlideNumberVisible تستخدم لتحديد أن نموذج رقم الصفحة للشريحة مفقود
{
	headerFooterManager->SetSlideNumberVisibility(true); // يتم استخدام طريقة SetSlideNumberVisibility لتعيين نموذج رقم الصفحة للشريحة ليكون مرئيًا
}
if (!headerFooterManager->get_IsDateTimeVisible()) // خاصية IsDateTimeVisible تستخدم لتحديد أن نموذج التاريخ والوقت للشريحة مفقود
{
	headerFooterManager->SetDateTimeVisibility(true); // يتم استخدام طريقة SetFooterVisibility لتعيين نموذج التاريخ والوقت للشريحة ليكون مرئيًا
}
headerFooterManager->SetFooterText(u"نص التذييل"); // يتم استخدام طريقة SetFooterText لتعيين نص لنموذج تذييل الشريحة
headerFooterManager->SetDateTimeText(u"نص التاريخ والوقت"); // يتم استخدام طريقة SetDateTimeText لتعيين نص لنموذج التاريخ والوقت للشريحة.


// يحفظ العرض التقديمي على القرص
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **تعيين رؤية التذييل الفرعي داخل الشريحة**

1. أنشئ مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. احصل على مرجع للوحة الرئيسية من خلال مؤشرها.
1. اجعل الشريحة الرئيسية وجميع نماذج التذييل الفرعي مرئية.
1. عيّن نصًا للوحة الرئيسية وجميع نماذج التذييل الفرعي.
1. عيّن نصًا للوحة الرئيسية وجميع نماذج التاريخ والوقت الفرعي.
1. احفظ العرض التقديمي.

يوضح لك هذا الكود C++ إجراء العملية:

```c++
// المسار إلى مجلد المستندات.
const String outPath = u"../out/SetChildFooter_out.pptx";

SharedPtr<Presentation> presentation = MakeObject<Presentation>();

// ينشئ مثيل من فئة SlideCollection
SharedPtr<ISlideCollection> slds = presentation->get_Slides();

SharedPtr<IMasterSlideHeaderFooterManager> headerFooterManager = presentation->get_Masters()->idx_get(0)->get_HeaderFooterManager();
headerFooterManager->SetFooterAndChildFootersVisibility(true); // تُستخدم طريقة SetFooterAndChildFootersVisibility لتعيين الشريحة الرئيسية وجميع نماذج التذييل الفرعي لتكون مرئية
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true); // تُستخدم طريقة SetSlideNumberAndChildSlideNumbersVisibility لتعيين الشريحة الرئيسية وجميع نماذج رقم الصفحة الفرعي لتكون مرئية
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true); // تُستخدم طريقة SetDateTimeAndChildDateTimesVisibility لتعيين الشريحة الرئيسية وجميع نماذج التاريخ والوقت الفرعي لتكون مرئية

headerFooterManager->SetFooterAndChildFootersText(u"نص التذييل"); // تُستخدم طريقة SetFooterAndChildFootersText لتعيين النصوص للشريحة الرئيسية وجميع نماذج التذييل
headerFooterManager->SetDateTimeAndChildDateTimesText(u"نص التاريخ والوقت"); // تُستخدم طريقة SetDateTimeAndChildDateTimesText لتعيين النص لنماذج التاريخ والوقت الفرعي لجميع الشرائح

presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **تعيين حجم الشريحة بالنسبة لتغيير حجم المحتوى**

1. أنشئ مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) وقم بتحميل العرض التقديمي الذي يحتوي على الشريحة التي ترغب في تعيين حجمها.
1. أنشئ مثيلًا آخر من عائلة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) لإنشاء عرض تقديمي جديد.
1. احصل على مرجع الشريحة (من العرض التقديمي الأول) من خلال مؤشرها.
1. اجعل نموذج تذييل الشريحة مرئيًا.
1. اجعل نموذج التاريخ والوقت مرئيًا.
1. احفظ العرض التقديمي.

يوضح لك هذا الكود C++ كيفية تنفيذ العملية:

```c++
// المسار إلى مجلد المستندات.
const String templatePath = u"../templates/AccessSlides.pptx";
const String outPath = u"../out/SetSlideSizeScale_out.pptx";

SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);
SharedPtr<Presentation> auxPresentation = MakeObject<Presentation>();

// ينشئ مثيل من فئة SlideCollection
SharedPtr<ISlide> slide = presentation->get_Slides()->idx_get(0);

// تعيين حجم الشريحة للعروض التقديمية الناتجة إلى حجم المصدر
auxPresentation->get_SlideSize()->SetSize(540, 720, SlideSizeScaleType::EnsureFit); // تُستخدم طريقة SetSize لتعيين حجم الشريحة مع تغيير المحتوى لضمان التناسب
auxPresentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::Maximize); // تُستخدم طريقة SetSize لتعيين حجم الشريحة إلى الحجم الأقصى للمحتوى

auxPresentation->get_Slides()->InsertClone(0, slide);
auxPresentation->get_Slides()->RemoveAt(0);

// يحفظ العرض التقديمي
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **تعيين حجم الصفحة عند إنشاء PDF**

بعض العروض التقديمية (مثل الملصقات) غالبًا ما يتم تحويلها إلى مستندات PDF. إذا كنت تبحث عن تحويل PowerPoint إلى PDF للوصول إلى أفضل خيارات الطباعة والوصول، فأنت بحاجة إلى تعيين شرائحك إلى احجام تناسب مستندات PDF (A4، على سبيل المثال).

توفر Aspose.Slides فئة [SlideSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/) للسماح لك بتحديد الإعدادات المفضلة لديك للشرائح. يوضح لك هذا الكود C++ كيفية استخدام خاصية [get_Type()](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/get_type/) (من فئة `SlideSize`) لتعيين حجم ورق محدد للشرائح في عرض تقديمي:

```c++
// المسار إلى مجلد المستندات.
	const String outPath = u"../out/SetPDFPageSize_out.pptx";

	// ينشئ مثيلًا من كائن Presentation الذي يمثل ملف العرض التقديمي 
	SharedPtr<Presentation>pres = MakeObject<Presentation>();

	// تعيين خاصية SlideSize.Type
	pres->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::EnsureFit);

	// تعيين خصائص مختلفة لخيارات PDF
	Aspose::Slides::Export::PdfOptions opts = Aspose::Slides::Export::PdfOptions();
	opts.set_SufficientResolution (600);

	// حفظ العرض التقديمي
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pdf, &opts);
```