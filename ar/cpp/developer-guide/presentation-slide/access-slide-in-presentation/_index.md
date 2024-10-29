---
title: الوصول إلى الشريحة في العرض التقديمي
type: docs
weight: 20
url: /ar/cpp/access-slide-in-presentation/
keywords: "الوصول إلى عرض PowerPoint, الوصول إلى الشريحة, تحرير خصائص الشريحة, تغيير موضع الشريحة, تعيين رقم الشريحة, الفهرس, المعرف, الموضع C++, CPP, Aspose.Slides"
description: "الوصول إلى شريحة PowerPoint من خلال الفهرس، المعرف، أو الموضع في C++. تحرير خصائص الشريحة"
---

تتيح لك Aspose.Slides الوصول إلى الشرائح بطريقتين: من خلال الفهرس ومن خلال المعرف.

## **الوصول إلى الشريحة بواسطة الفهرس**

جميع الشرائح في العرض التقديمي مرتبة رقميًا بناءً على موضع الشريحة بدءًا من 0. يمكن الوصول إلى الشريحة الأولى من خلال الفهرس 0؛ يتم الوصول إلى الشريحة الثانية من خلال الفهرس 1؛ وهكذا.

تُعرِّض فئة Presentation، التي تمثل ملف العرض التقديمي، جميع الشرائح كمجموعة [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) (مجموعة من كائنات [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/)). يوضح هذا الكود بلغة C++ كيفية الوصول إلى شريحة من خلال فهرسها:

```c++
	// المسار إلى مجلد المستندات.
	const String templatePath = u"../templates/AddSlides.pptx";

	// إنشاء مثيل من فئة Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// الحصول على مرجع الشريحة من خلال فهرسها
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
```

## **الوصول إلى الشريحة بواسطة المعرف**

لكل شريحة في العرض التقديمي معرف فريد مرتبط بها. يمكنك استخدام طريقة [GetSlideById()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/getslidebyid/) (التي تكشفها فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)) لاستهداف ذلك المعرف. يوضح هذا الكود بلغة C++ كيفية تقديم معرف شريحة صحيح والوصول إلى تلك الشريحة من خلال طريقة [GetSlideById()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/getslidebyid/):

```c++
	// المسار إلى مجلد المستندات.
	const String templatePath = u"../templates/AddSlides.pptx";

	// إنشاء مثيل من فئة Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// الحصول على معرف الشريحة
	int id = pres->get_Slides()->idx_get(0)->get_SlideId();

	// الوصول إلى الشريحة من خلال معرفها
	SharedPtr<IBaseSlide> slide = pres->GetSlideById(id);
```

## **تغيير موضع الشريحة**

تتيح لك Aspose.Slides تغيير موضع الشريحة. على سبيل المثال، يمكنك تحديد أن الشريحة الأولى يجب أن تصبح الشريحة الثانية.

1. أنشئ مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. الحصول على مرجع الشريحة (التي تريد تغيير موضعها) من خلال فهرسها.
1. تعيين موضع جديد للشريحة من خلال خاصية [set_SlideNumber()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/set_slidenumber/).
1. حفظ العرض التقديمي المعدل.

يظهر هذا الكود بلغة C++ عملية يتم فيها نقل الشريحة في الموضع 1 إلى الموضع 2:

```c++
	// المسار إلى مجلد المستندات.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/ChangeSlidePosition.pptx";

	// إنشاء مثيل من فئة Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// الحصول على الشريحة التي سيتم تغيير موضعها
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// تعيين الموضع الجديد للشريحة
	slide->set_SlideNumber(2);

	// حفظ العرض التقديمي المعدل
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

أصبحت الشريحة الأولى هي الثانية؛ وأصبحت الشريحة الثانية هي الأولى. عند تغيير موضع الشريحة، يتم ضبط الشرائح الأخرى تلقائيًا.

## **تعيين رقم الشريحة**

باستخدام خاصية [set_FirstSlideNumber()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/set_firstslidenumber/) (التي تكشفها فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/))، يمكنك تحديد رقم جديد لأولى الشريحة في العرض التقديمي. تؤدي هذه العملية إلى حساب أرقام الشرائح الأخرى من جديد.

1. أنشئ مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. الحصول على رقم الشريحة.
1. تعيين رقم الشريحة.
1. حفظ العرض التقديمي المعدل.

يوضح هذا الكود بلغة C++ عملية يتم فيها تعيين رقم الشريحة الأولى إلى 10:

```c++
	// المسار إلى مجلد المستندات.
	const String outPath = u"../out/SetSlideNumber_out.pptx";
	const String templatePath = u"../templates/AccessSlides.pptx";

	// إنشاء مثيل من فئة Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// الحصول على رقم الشريحة
	int firstSlideNumber = pres->get_FirstSlideNumber();

	// تعيين رقم الشريحة
	pres->set_FirstSlideNumber(2);
	
	// حفظ العرض التقديمي المعدل
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

إذا كنت تفضل تخطي الشريحة الأولى، يمكنك بدء ترقيم الشرائح من الشريحة الثانية (وإخفاء الترقيم للشريحة الأولى) بهذه الطريقة:

```c++
auto presentation = System::MakeObject<Presentation>();

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

auto slides = presentation->get_Slides();
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);

// تعيين الرقم لأول شريحة في العرض التقديمي
presentation->set_FirstSlideNumber(0);

// إظهار أرقام الشرائح لجميع الشرائح
presentation->get_HeaderFooterManager()->SetAllSlideNumbersVisibility(true);

// إخفاء رقم الشريحة للشريحة الأولى
slides->idx_get(0)->get_HeaderFooterManager()->SetSlideNumberVisibility(false);

// حفظ العرض التقديمي المعدل
presentation->Save(u"output.pptx", SaveFormat::Pptx);
```