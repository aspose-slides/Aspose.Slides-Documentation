---
title: إزالة شريحة من العرض التقديمي
type: docs
weight: 30
url: /cpp/remove-slide-from-presentation/
keywords: "إزالة شريحة، حذف شريحة، PowerPoint، عرض تقديمي، C++، Aspose.Slides"
description: "إزالة شريحة من PowerPoint بواسطة المرجع أو الفهرس في C++"

---

إذا أصبحت شريحة (أو محتوياتها) غير ضرورية، يمكنك حذفها. يوفر Aspose.Slides فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) التي تحتوي على [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/)، وهي مستودع لجميع الشرائح في العرض التقديمي. باستخدام المؤشرات (المرجع أو الفهرس) لكائن [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) المعروف، يمكنك تحديد الشريحة التي ترغب في إزالتها.

## **إزالة شريحة بواسطة المرجع**

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. احصل على مرجع الشريحة التي تريد إزالتها من خلال معرفها أو فهرسها.
1. قم بإزالة الشريحة المرجعية من العرض التقديمي.
1. احفظ العرض التقديمي المعدل.

يوضح هذا الكود في C++ كيفية إزالة شريحة من خلال مرجعها:

```c++
	// المسار إلى دليل المستندات
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByReference.pptx";

	// ينشئ كائن Presentation يمثل ملف عرض تقديمي
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// يصل إلى شريحة من خلال فهرسها في مجموعة الشرائح
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// يزيل شريحة من خلال مرجعها
	pres->get_Slides()->Remove(slide);

	// يحفظ العرض التقديمي المعدل
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **إزالة شريحة بواسطة الفهرس**

1. أنشئ مثيلاً لفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. قم بإزالة الشريحة من العرض التقديمي من خلال موضع فهرسها.
1. احفظ العرض التقديمي المعدل.

يوضح هذا الكود في C++ كيفية إزالة شريحة من خلال فهرسها:

```c++
	// المسار إلى دليل المستندات
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByID.pptx";

	// ينشئ كائن Presentation يمثل ملف عرض تقديمي
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// يزيل شريحة من خلال فهرسها
	pres->get_Slides()->RemoveAt(0);

	// يحفظ العرض التقديمي المعدل
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **إزالة شريحة تخطيط غير مستخدمة**

يوفر Aspose.Slides طريقة [RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (من فئة [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)) للسماح لك بحذف الشرائح التخطيطية غير المرغوب فيها وغير المستخدمة. يظهر هذا الكود في C++ كيفية إزالة شريحة تخطيط من عرض تقديمي في PowerPoint:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **إزالة شريحة رئيسية غير مستخدمة**

يوفر Aspose.Slides طريقة [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) (من فئة [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)) للسماح لك بحذف الشرائح الرئيسية غير المرغوب فيها وغير المستخدمة. يظهر هذا الكود في C++ كيفية إزالة شريحة رئيسية من عرض تقديمي في PowerPoint:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```