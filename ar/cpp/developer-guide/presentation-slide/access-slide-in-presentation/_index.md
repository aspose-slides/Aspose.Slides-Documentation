---
title: الوصول إلى شرائح العرض التقديمي في C++
linktitle: الوصول إلى الشريحة
type: docs
weight: 20
url: /ar/cpp/access-slide-in-presentation/
keywords:
- الوصول إلى الشريحة
- فهرس الشريحة
- معرف الشريحة
- موضع الشريحة
- تغيير الموضع
- خصائص الشريحة
- رقم الشريحة
- PowerPoint
- OpenDocument
- العرض التقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية الوصول إلى الشرائح وإدارتها في عروض PowerPoint و OpenDocument باستخدام Aspose.Slides للغة C++. عزز الإنتاجية من خلال أمثلة الشيفرة."
---

Aspose.Slides يتيح لك الوصول إلى الشرائح بطريقتين: حسب الفهرس وحسب المعرف.

## **الوصول إلى شريحة حسب الفهرس**

جميع الشرائح في العرض التقديمي تُرتّب رقميًا بناءً على موضع الشريحة بدءًا من 0. يمكن الوصول إلى الشريحة الأولى عبر الفهرس 0؛ والشريحة الثانية عبر الفهرس 1؛ وهكذا.

الفئة Presentation، التي تمثّل ملف العرض التقديمي، تعرض جميع الشرائح كـ [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) (مجموعة من كائنات [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) ). يُظهر لك هذا الكود C++ كيفية الوصول إلى شريحة عبر فهرسها:
```c++
	// مسار دليل المستندات.
	const String templatePath = u"../templates/AddSlides.pptx";

	// ينشئ فئة Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// الحصول على مرجع الشريحة عبر الفهرس الخاص بها
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
```


## **الوصول إلى شريحة حسب المعرف**

كل شريحة في العرض التقديمي لها معرف فريد مرتبط بها. يمكنك استخدام طريقة [GetSlideById()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/getslidebyid/) (المُعرَضة من قبل فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)) لاستهداف ذلك المعرف. يُظهر لك هذا الكود C++ كيفية تحديد معرف شريحة صالح والوصول إلى تلك الشريحة عبر طريقة [GetSlideById()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/getslidebyid/):
```c++
	// مسار دليل المستندات.
	const String templatePath = u"../templates/AddSlides.pptx";

	// ينشئ فئة Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// يحصل على معرف الشريحة
	int id = pres->get_Slides()->idx_get(0)->get_SlideId();

	// يصل إلى الشريحة عبر معرفها
	SharedPtr<IBaseSlide> slide = pres->GetSlideById(id);
```


## **تغيير موضع الشريحة**

Aspose.Slides يتيح لك تغيير موضع الشريحة. على سبيل المثال، يمكنك تحديد أن الشريحة الأولى تصبح الشريحة الثانية.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. الحصول على مرجع الشريحة (التي تريد تغيير موضعها) عبر فهرسها
1. تعيين موضع جديد للشريحة عبر خاصية [set_SlideNumber()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/set_slidenumber/).
1. حفظ العرض التقديمي المعدل.

هذا الكود C++ يوضح عملية نقل الشريحة الموجودة في الموضع 1 إلى الموضع 2:
```c++
	// مسار دليل المستندات.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/ChangeSlidePosition.pptx";

	// ينشئ فئة Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// يحصل على الشريحة التي سيتم تغيير موضعها
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// يعيّن الموضع الجديد للشريحة
	slide->set_SlideNumber(2);

	// يحفظ العرض التقديمي المعدل
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


أصبحت الشريحة الأولى هي الثانية؛ وأصبحت الشريحة الثانية هي الأولى. عند تغيير موضع شريحة، يتم تعديل المواقع الأخرى تلقائيًا.

## **تعيين رقم الشريحة**

باستخدام خاصية [set_FirstSlideNumber()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/set_firstslidenumber/) (المُعرَضة من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/))، يمكنك تحديد رقم جديد لأول شريحة في العرض التقديمي. تُعيد هذه العملية حساب أرقام الشرائح الأخرى.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. الحصول على رقم الشريحة.
1. تعيين رقم الشريحة.
1. حفظ العرض التقديمي المعدل.

هذا الكود C++ يوضح عملية تعيين رقم الشريحة الأولى إلى 10:
```c++
	// مسار دليل المستندات.
	const String outPath = u"../out/SetSlideNumber_out.pptx";
	const String templatePath = u"../templates/AccessSlides.pptx";

	//ينشئ فئة Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// الحصول على رقم الشريحة
	int firstSlideNumber = pres->get_FirstSlideNumber();

	// تعيين رقم الشريحة
	pres->set_FirstSlideNumber(2);
	
	// حفظ العرض التقديمي المعدل
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


إذا كنت تفضّل تخطي الشريحة الأولى، يمكنك بدء الترقيم من الشريحة الثانية (وإخفاء الترقيم عن الشريحة الأولى) بهذه الطريقة:
```c++
auto presentation = System::MakeObject<Presentation>();

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

auto slides = presentation->get_Slides();
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);

// Sets the number for the first presentation slide
presentation->set_FirstSlideNumber(0);

// Shows slide numbers for all slides
presentation->get_HeaderFooterManager()->SetAllSlideNumbersVisibility(true);

// Hides the slide number for the first slide
slides->idx_get(0)->get_HeaderFooterManager()->SetSlideNumberVisibility(false);

// Saves the modified presentation
presentation->Save(u"output.pptx", SaveFormat::Pptx);
```


## **الأسئلة الشائعة**

**هل رقم الشريحة الذي يراه المستخدم يطابق فهرس المجموعة القائم على الصفر؟**

يمكن أن يبدأ الرقم الظاهر على الشريحة من قيمة عشوائية (مثل 10) ولا يلزم أن يطابق الفهرس؛ يتم التحكم في العلاقة عبر إعداد [first slide number](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/set_firstslidenumber/) للعرض التقديمي.

**هل تؤثر الشرائح المخفية على الفهرسة؟**

نعم. الشريحة المخفية تظل في المجموعة وتُحْسَب في الفهرسة؛ "مخفي" يشير إلى العرض فقط، وليس إلى موضعها في المجموعة.

**هل يتغير فهرس الشريحة عندما تُضاف أو تُحذف شرائح أخرى؟**

نعم. الفهارس تُعَدّ دائمًا وفقًا للترتيب الحالي للشرائح وتُعاد حسابها عند عمليات الإدراج أو الحذف أو النقل.