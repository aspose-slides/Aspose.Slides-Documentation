---
title: إزالة الشرائح من العروض التقديمية باستخدام C++
linktitle: إزالة شريحة
type: docs
weight: 30
url: /ar/cpp/remove-slide-from-presentation/
keywords:
- إزالة شريحة
- حذف شريحة
- إزالة شريحة غير مستخدمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "إزالة الشرائح بسهولة من عروض PowerPoint و OpenDocument باستخدام Aspose.Slides للغة C++. احصل على أمثلة شفرة واضحة وعزّز سير عملك."
---

إذا أصبحت الشريحة (أو محتواها) غير ضرورية، يمكنك حذفها. توفر Aspose.Slides الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) التي تضم [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/)، وهي مستودع لجميع الشرائح في عرض تقديمي. باستخدام مؤشرات (مرجع أو فهرس) لكائن [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) يمكنك تحديد الشريحة التي تريد إزالتها. 

## **إزالة شريحة باستخدام المرجع**

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. الحصول على مرجع للشريحة التي تريد إزالتها عبر معرّفها أو فهرسها.
1. إزالة الشريحة المشار إليها من العرض التقديمي.
1. حفظ العرض التقديمي المُعدَّل. 

يُظهر لك هذا الكود C++ كيفية إزالة شريحة عبر مرجعها: 
```c++
	// المسار إلى دليل المستندات
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByReference.pptx";

	// ينشئ كائن Presentation يمثل ملف عرض تقديمي
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// الوصول إلى شريحة عبر فهرستها في مجموعة الشرائح
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// يزيل شريحة عبر مرجعها
	pres->get_Slides()->Remove(slide);

	// يحفظ العرض التقديمي المعدَّل
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **إزالة شريحة باستخدام الفهرس**

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. إزالة الشريحة من العرض التقديمي عبر موضع فهرسها.
1. حفظ العرض التقديمي المُعدَّل. 

يُظهر لك هذا الكود C++ كيفية إزالة شريحة عبر فهرسها: 
```c++
	// المسار إلى دليل المستندات
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByID.pptx";

	// ينشئ كائن Presentation يمثل ملف عرض تقديمي
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// يزيل شريحة عبر فهرس الشريحة
	pres->get_Slides()->RemoveAt(0);

	// يحفظ العرض التقديمي المعدل
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```



## **إزالة شرائح التخطيط غير المستخدمة**

توفر Aspose.Slides الطريقة [RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (من الفئة [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)) لتتيح لك حذف شرائح التخطيط غير المطلوبة وغير المستخدمة. يُظهر لك هذا الكود C++ كيفية إزالة شريحة تخطيط من عرض PowerPoint:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


## **إزالة شرائح الماستر غير المستخدمة**

توفر Aspose.Slides الطريقة [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) (من الفئة [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)) لتتيح لك حذف شرائح الماستر غير المطلوبة وغير المستخدمة. يُظهر لك هذا الكود C++ كيفية إزالة شريحة ماستر من عرض PowerPoint:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


## **الأسئلة الشائعة**

**ماذا يحدث لأرقام فهارس الشرائح بعد حذف شريحة؟**

بعد الحذف، تقوم [المجموعة](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/) بإعادة الفهرسة: كل شريحة تالية تتحرك إلى اليسار بموقع واحد، لذا تصبح أرقام الفهارس السابقة غير صالحة. إذا احتجت إلى مرجع ثابت، استخدم المعرف الدائم لكل شريحة بدلاً من فهرستها.

**هل معرّف الشريحة يختلف عن فهرستها، وهل يتغير عندما تُحذف الشرائح المجاورة؟**

نعم. الفهرس هو موقع الشريحة في العرض وسيتم تغييره عندما تُضاف أو تُحذف شرائح. معرّف الشريحة هو معرف دائم ولا يتغير عندما تُحذف شرائح أخرى.

**كيف يؤثر حذف شريحة على أقسام الشرائح؟**

إذا كانت الشريحة تنتمي إلى قسم، سيحتوي ذلك القسم على شريحة أقل ببساطة. يبقى هيكل القسم كما هو؛ إذا أصبح القسم فارغًا، يمكنك [إزالة أو إعادة تنظيم الأقسام](/slides/ar/cpp/slide-section/) حسب الحاجة.

**ماذا يحدث للملاحظات والتعليقات المرفقة بالشريحة عند حذفها؟**

[الملاحظات](/slides/ar/cpp/presentation-notes/) و[التعليقات](/slides/ar/cpp/presentation-comments/) مرتبطة بهذه الشريحة المحددة وتُحذف معها. لا يتأثر المحتوى على الشرائح الأخرى.

**كيف يختلف حذف الشرائح عن تنظيف التخطيطات/القوالب غير المستخدمة؟**

الحذف يزيل شرائح عادية محددة من العرض. تنظيف التخطيطات/القوالب غير المستخدمة يزيل شرائح التخطيط أو القالب التي لا يشير إليها أي شيء، مما يقلل حجم الملف دون تغيير محتوى الشرائح المتبقية. هاتان العمليتان تكملان بعضهما: عادةً ما تُحذف الشرائح أولاً، ثم يتم التنظيف.