---
title: خلفية العرض
type: docs
weight: 20
url: /cpp/presentation-background/
keywords: "خلفية PowerPoint، تعيين خلفية"
description: "تعيين الخلفية في عرض PowerPoint في CPP"
---

تستخدم الألوان الصلبة، والألوان المتدرجة، والصور غالبًا كصور خلفية للشرائح. يمكنك تعيين الخلفية إما لشريحة **عادية** (شريحة واحدة) أو **شريحة رئيسية** (عدة شرائح دفعة واحدة).

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **تعيين لون صلب كخلفية لشريحة عادية**

تتيح لك Aspose.Slides تعيين لون صلب كخلفية لشريحة معينة في عرض (حتى إذا كان هذا العرض يحتوي على شريحة رئيسية). تؤثر تغيير الخلفية فقط على الشريحة المحددة.

1. أنشئ مثيلًا من صف [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. قم بتعيين قائمة [BackgroundType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a811de442ed9b0c175aa4dce66d0ba246) للشريحة إلى `OwnBackground`.
3. قم بتعيين قائمة [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) لخلفية الشريحة إلى `Solid`.
4. استخدم خاصية [SolidFillColor](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a13c48eebf434d92f4c0058796ea15810) المعروضة بواسطة [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format) لتحديد لون صلب للخلفية.
5. احفظ العرض المعدل.

يعرض هذا الكود بلغة C++ كيفية تعيين لون صلب (أزرق) كخلفية لشريحة عادية:

```c++
// المسار إلى دليل المستندات.

	const String OutPath = L"../out/SetSlideBackgroundNormal_out.pptx";

	// ينشئ مثيلًا من صف Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//  يعين لون الخلفية للشريحة الأولى ISlide إلى الأزرق
	pres->get_Slides()->idx_get(0)->get_Background()->set_Type(BackgroundType::OwnBackground);
	pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
	pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	//يكتب العرض إلى القرص
	pres->Save(OutPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **تعيين لون صلب كخلفية لشريحة رئيسية**

تتيح لك Aspose.Slides تعيين لون صلب كخلفية للشريحة الرئيسية في عرض. تعمل الشريحة الرئيسية كقالب يحتوي على إعدادات التنسيق لجميع الشرائح. لذلك، عند تعيين لون صلب كخلفية للشريحة الرئيسية، ستستخدم هذه الخلفية الجديدة في جميع الشرائح.

1. أنشئ مثيلًا من صف [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. قم بتعيين قائمة [BackgroundType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a811de442ed9b0c175aa4dce66d0ba246) للشريحة الرئيسية (`Masters`) إلى `OwnBackground`.
3. قم بتعيين قائمة [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) لخلفية الشريحة الرئيسية إلى `Solid`.
4. استخدم خاصية [SolidFillColor](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a13c48eebf434d92f4c0058796ea15810) المعروضة بواسطة [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format) لتحديد لون صلب للخلفية.
5. احفظ العرض المعدل.

يعرض هذا الكود بلغة C++ كيفية تعيين لون صلب (أخضر غابوي) كخلفية لشريحة رئيسية في عرض:

```c++
	// المسار إلى دليل المستندات.

	const String OutPath = L"../out/SetSlideBackgroundMaster_out.pptx";

	// ينشئ مثيلًا من صف Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// يعين لون الخلفية للشريحة الرئيسية ISlide إلى الأخضر الغابوي
	pres->get_Masters()->idx_get(0)->get_Background()->set_Type(BackgroundType::OwnBackground);
	pres->get_Masters()->idx_get(0)->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
	pres->get_Masters()->idx_get(0)->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_ForestGreen());

	//يكتب العرض إلى القرص
	pres->Save(OutPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **تعيين لون متدرج كخلفية لشريحة**

اللون المتدرج هو تأثير رسومي يعتمد على تغيير تدريجي في اللون. تجعل الألوان المتدرجة، عند استخدامها كخلفيات للشرائح، العروض تبدو فنية واحترافية. تتيح لك Aspose.Slides تعيين لون متدرج كخلفية للشرائح في العروض.

1. أنشئ مثيلًا من صف [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. قم بتعيين قائمة [BackgroundType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a811de442ed9b0c175aa4dce66d0ba246) للشريحة إلى `OwnBackground`.
3. قم بتعيين قائمة [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) لخلفية الشريحة الرئيسية إلى `Gradient`.
4. استخدم خاصية [GradientFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#aa686ab9c84e7e20e65dfe73458f1a823) المعروضة بواسطة [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format) لتحديد إعداد التدرج المفضل لديك.
5. احفظ العرض المعدل.

يعرض هذا الكود بلغة C++ كيفية تعيين لون متدرج كخلفية لشريحة:

```c++
// ينشئ مثيلًا من صف Presentation
auto pres = System::MakeObject<Presentation>(u"SetBackgroundToGradient.pptx");

// تطبيق تأثير التدرج على الخلفية
pres->get_Slides()->idx_get(0)->get_Background()->set_Type(BackgroundType::OwnBackground);
pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// يكتب العرض إلى القرص
pres->Save(u"ContentBG_Grad_out.pptx", SaveFormat::Pptx);
```

## **تعيين صورة كخلفية لشريحة**

بالإضافة إلى الألوان الصلبة والألوان المتدرجة، تتيح لك Aspose.Slides أيضًا تعيين الصور كخلفية للشرائح في العروض.

1. أنشئ مثيلًا من صف [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. قم بتعيين قائمة [BackgroundType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a811de442ed9b0c175aa4dce66d0ba246) للشريحة إلى `OwnBackground`.
3. قم بتعيين قائمة [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) لخلفية الشريحة الرئيسية إلى `Picture`.
4. قم بتحميل الصورة التي تريد استخدامها كخلفية للشريحة.
5. أضف الصورة إلى مجموعة الصور في العرض.
6. استخدم خاصية [PictureFillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format#a7f2b7e6afce822667cecd3e80336bfae) المعروضة بواسطة [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.fill_format) لتعيين الصورة كخلفية.
7. احفظ العرض المعدل.

يعرض هذا الكود بلغة C++ كيفية تعيين صورة كخلفية لشريحة:

```c++
// المسار إلى دليل المستندات.

const String templatePath = L"../templates/SetImageAsBackground.pptx";
const String imagePath = L"../templates/Tulips.jpg";
const String outPath = L"../out/ContentBG_Img_out.pptx";

// ينشئ مثيلًا من صف Presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// يعين الشروط لصورة الخلفية
pres->get_Slides()->idx_get(0)->get_Background()->set_Type(BackgroundType::OwnBackground);
pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// يحمل الصورة
auto image = Images::FromFile(imagePath);

// يضيف الصورة إلى مجموعة الصور في العرض
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(image);

pres->get_Slides()->idx_get(0)->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// يكتب العرض إلى القرص
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

### **تغيير شفافية صورة الخلفية**

قد ترغب في ضبط شفافية صورة خلفية الشريحة لتبرز محتويات الشريحة. يُظهر لك هذا الكود بلغة C++ كيفية تغيير الشفافية لصورة خلفية الشريحة:

```c++
int32_t transparencyValue = 30;
// على سبيل المثال
// يحصل على مجموعة من عمليات تحويل الصورة
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();
// يجد تأثير الشفافية مع نسبة ثابتة.
System::SharedPtr<AlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (System::ObjectExt::Is<AlphaModulateFixed>(operation))
    {
        transparencyOperation = System::ExplicitCast<AlphaModulateFixed>(operation);
        break;
    }
}
// يعيين قيمة الشفافية الجديدة.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}
```

## **الحصول على قيمة خلفية الشريحة**

تقدم Aspose.Slides واجهة [IBackgroundEffectiveData](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_background_effective_data/) للسماح لك بالحصول على القيم الفعالة لخلفيات الشرائح. تحتوي هذه الواجهة على معلومات حول [FillFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_background_effective_data#a097ba368423bf4a9ab7a6a61870bfc8e) الفعالة و[EffectFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_background_effective_data#a446676281ac4195cb7eb989e4a8110f8) الفعالة.

باستخدام خاصية [Background](https://reference.aspose.com/slides/cpp/class/aspose.slides.base_slide#ac12d4a7683bf6fa20b3eef387219cf16) من صف [BaseSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.base_slide/)، يمكنك الحصول على القيمة الفعالة لخلفية شريحة.

يعرض هذا الكود بلغة C++ كيفية الحصول على قيمة خلفية فعالة لشريحة:

```c++
// ينشئ مثيلًا من صف Presentation
const String templatePath = u"../templates/SamplePresentation.pptx";
	

	auto pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<IBackgroundEffectiveData> effBackground = pres->get_Slides()->idx_get(0)->CreateBackgroundEffective();
	if (effBackground->get_FillFormat()->get_FillType() == Aspose::Slides::FillType::Solid)
	{
		System::Console::WriteLine(System::String(u"لون التعبئة: ") + effBackground->get_FillFormat()->get_SolidFillColor());
	}
	else
	{
		System::Console::WriteLine(System::String(u"نوع التعبئة: ") + System::ObjectExt::ToString(effBackground->get_FillFormat()->get_FillType()));
	}
```