---
title: اعمال انیمیشن‌های شکل در ارائه‌ها با C++
linktitle: انیمیشن شکل
type: docs
weight: 60
url: /fa/cpp/shape-animation/
keywords:
- شکل
- انیمیشن
- افکت
- شکل انیمیشن‌شده
- متن انیمیشن‌شده
- اضافه‌کردن انیمیشن
- دریافت انیمیشن
- استخراج انیمیشن
- اضافه‌کردن افکت
- دریافت افکت
- استخراج افکت
- صدا افکت
- اعمال انیمیشن
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "کشف کنید چگونه انیمیشن‌های شکل را در ارائه‌های PowerPoint با Aspose.Slides برای C++ ایجاد و شخصی‌سازی کنید. متمایز شوید!"
---
## **مقدمه**

انیمیشن‌ها افکت‌های بصری هستند که می‌توانند روی متن‌ها، تصاویر، شکل‌ها یا [نمودارها](/slides/fa/cpp/animated-charts/) اعمال شوند. آن‌ها به ارائه‌ها یا اجزای آن جان می‌بخشند. 

## **چرا در ارائه‌ها از انیمیشن‌ها استفاده کنیم؟**

با استفاده از انیمیشن‌ها می‌توانید 

* کنترل جریان اطلاعات
* تأکید بر نکات مهم
* افزایش علاقه یا مشارکت مخاطبان
* آسان‌سازی خواندن یا درک یا پردازش محتوا
* جلب توجه خوانندگان یا بینندگان به بخش‌های مهم در یک ارائه

PowerPoint گزینه‌ها و ابزارهای متعددی برای انیمیشن‌ها و افکت‌های انیمیشن در دسته‌های **ورودی**، **خروجی**، **تاکید** و **مسیرهای حرکتی** فراهم می‌کند. 

## **انیمیشن‌ها در Aspose.Slides**

* Aspose.Slides کلاس‌ها و نوع‌های مورد نیاز برای کار با انیمیشن‌ها را در فضای‌نامی [Aspose.Slides.Animation](https://reference.aspose.com/slides/fa/cpp/namespace/aspose.slides.animation) ارائه می‌دهد،
* Aspose.Slides بیش از **150 افکت انیمیشن** را در شمارش‌گر [EffectType](https://reference.aspose.com/slides/fa/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) فراهم می‌کند. این افکت‌ها اساساً همان افکت‌های استفاده‌شده در PowerPoint هستند (یا معادل آن).

## **اعمال انیمیشن به TextBox**

Aspose.Slides برای C++ به شما امکان می‌دهد انیمیشن را بر روی متن موجود در یک شکل اعمال کنید. 

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation/) ایجاد کنید.
2. مرجع اسلاید را از طریق ایندکس آن دریافت کنید.
3. یک `rectangle` [IAutoShape](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_auto_shape) اضافه کنید. 
4. متن را به [IAutoShape.TextFrame](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3) اضافه کنید.
5. یک توالی اصلی از افکت‌ها دریافت کنید.
6. یک افکت انیمیشن به [IAutoShape](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_auto_shape) اضافه کنید. 
7. خاصیت [TextAnimation.BuildType](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) را به مقدار حاصل از [BuildType Enumeration](https://reference.aspose.com/slides/fa/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7) تنظیم کنید.
8. ارائه را به‌عنوان یک فایل PPTX روی دیسک بنویسید.

این کد C++ نشان می‌دهد چگونه افکت `Fade` را بر AutoShape اعمال کنید و انیمیشن متن را به مقدار *By 1st Level Paragraphs* تنظیم کنید:

```c++
#include <DOM/Animation/BuildType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITextAnimation.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// یک نمونه از کلاس Presentation که یک فایل ارائه را نمایندگی می‌کند، ایجاد می‌نماید.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// یک AutoShape جدید با متن اضافه می‌کند
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// دنباله اصلی اسلاید را دریافت می‌کند.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// افکت انیمیشن Fade را به شکل اضافه می‌کند
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// متن شکل را بر اساس پاراگراف‌های سطح اول انیمیشن می‌کند
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// فایل PPTX را بر روی دیسک ذخیره می‌کند
pres->Save(u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="info"  %}} 

علاوه بر اعمال انیمیشن بر متن، می‌توانید انیمیشن را بر یک [Paragraph](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_paragraph) تک نیز اعمال کنید. به [**Animated Text**](/slides/fa/cpp/animated-text/) مراجعه کنید.

{{% /alert %}} 

## **اعمال انیمیشن به PictureFrame**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation/) ایجاد کنید.
2. مرجع اسلاید را از طریق ایندکس آن دریافت کنید.
3. یک [PictureFrame](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_picture_frame) را بر روی اسلاید اضافه کنید یا دریافت کنید. 
4. دنباله اصلی افکت‌ها را دریافت کنید.
5. یک افکت انیمیشن به [PictureFrame](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_picture_frame) اضافه کنید.
6. فایل PPTX اصلاح‌شده را ذخیره کنید.

این کد C++ نشان می‌دهد چگونه افکت `Fly` را بر یک picture frame اعمال کنید:

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// یک نمونه از کلاس Presentation که یک فایل ارائه را نمایندگی می‌کند، ایجاد می‌نماید.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// تصویری را بارگذاری می‌کند تا به مجموعه تصاویر ارائه اضافه شود
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// یک فریم تصویر به اسلاید اضافه می‌کند
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// دنباله اصلی اسلاید را دریافت می‌کند.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// افکت انیمیشن Fly از سمت چپ را به فریم تصویر اضافه می‌کند
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// فایل PPTX را بر روی دیسک ذخیره می‌کند
pres->Save(u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **اعمال انیمیشن به Shape**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation/) ایجاد کنید.
2. مرجع اسلاید را از طریق ایندکس آن دریافت کنید.
3. یک `rectangle` [IAutoShape](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_auto_shape) اضافه کنید. 
4. یک `Bevel` [IAutoShape](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_auto_shape) اضافه کنید (زمانی که این شیء کلیک شود، انیمیشن اجرا می‌شود).
5. یک توالی از افکت‌ها را روی شکل bevel ایجاد کنید.
6. یک `UserPath` سفارشی ایجاد کنید.
7. دستورات برای حرکت به `UserPath` اضافه کنید.
8. فایل PPTX اصلاح‌شده را ذخیره کنید.

این کد C++ نشان می‌دهد چگونه افکت `PathFootball` (مسیر فوتبال) را بر یک شکل اعمال کنید:

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionEffect.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

	// مسیر به پوشهٔ سندها.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// ارائه را بارگذاری می‌کند
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// اولین اسلاید را دریافت می‌کند
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// مجموعهٔ اشکال اسلاید انتخاب‌شده را دریافت می‌کند
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// افکت PathFootball را برای شکل موجود از ابتدا ایجاد می‌کند.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// افکت انیمیشن PathFootBall را اضافه می‌کند
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// یک «دکمه» ایجاد می‌کند.
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// یک دنبالهٔ افکت برای این دکمه ایجاد می‌کند.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // یک مسیر سفارشی کاربر ایجاد می‌کند. شیٔ ما تنها پس از کلیک بر دکمه جابجا می‌شود.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// دستورات برای حرکت اضافه می‌کند چون مسیر ایجاد شده خالی است.
	 SharedPtr<MotionEffect> motionBhv = ExplicitCast<MotionEffect>(fxUserPath->get_Behaviors()->idx_get(0));

	// SharedPtr<PointF> point = MakeObject<PointF >(0.076, 0.59);
	 const PointF point = PointF (0.076, 0.59);
	 System::ArrayPtr<PointF> pts = System::MakeObject<System::Array<PointF>>(1, point);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts, MotionPathPointsType::Auto, true);
	 
	 //PointF point2[1] = { -0.076, -0.59 };
	const  PointF point2 = PointF(-0.076, -0.59 );

	 System::ArrayPtr<PointF> pts2 = System::MakeObject<System::Array<PointF>>(1, point2);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts2, MotionPathPointsType::Auto, false);
	 
	 motionBhv->get_Path()->Add(MotionCommandPathType::End, nullptr, MotionPathPointsType::Auto, false);
	 
	 // فایل PPTX را بر روی دیسک می‌نویسد
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **دریافت افکت‌های انیمیشن اعمال‌شده بر یک Shape**

مثال‌های زیر نشان می‌دهند چگونه از متد `GetEffectsByShape` در رابط [ISequence](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/isequence/) برای دریافت تمام افکت‌های انیمیشن اعمال‌شده بر یک شکل استفاده کنید.

**مثال ۱: دریافت افکت‌های انیمیشن اعمال‌شده بر یک شکل در اسلاید معمولی**

قبلاً یاد گرفتید چگونه افکت‌های انیمیشن را به شکل‌ها در ارائه‌های PowerPoint اضافه کنید. کد نمونه زیر نشان می‌دهد چگونه افکت‌های اعمال‌شده بر اولین شکل در اولین اسلاید معمولی در ارائه `AnimExample_out.pptx` را دریافت کنید.

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"AnimExample_out.pptx");

SharedPtr<ISlide> firstSlide = presentation->get_Slide(0);

// دنبالهٔ اصلی انیمیشن اسلاید را دریافت می‌کند.
SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// اولین شکل در اولین اسلاید را دریافت می‌کند.
SharedPtr<IShape> shape = firstSlide->get_Shape(0);

// افکت‌های انیمیشن اعمال‌شده بر شکل را دریافت می‌کند.
ArrayPtr<SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    Console::WriteLine(u"The shape " + shape->get_Name() + u" has " + shapeEffects->get_Length() + u" animation effects.");
}

presentation->Dispose();
```

**مثال ۲: دریافت تمام افکت‌های انیمیشن، شامل آنهایی که از placeholders به ارث رسیده‌اند**

اگر یک شکل در اسلاید معمولی placeholdersی داشته باشد که در اسلاید طرح‌بندی و/یا اسلاید مستر قرار دارند و افکت‌های انیمیشن به این placeholders اضافه شده باشند، تمام افکت‌های شکل در حین نمایش اسلاید پخش می‌شوند، شامل آنهایی که از placeholders به ارث رسیده‌اند.

فرض کنید فایلی ارائه PowerPoint به نام `sample.pptx` داریم که یک اسلاید دارد که فقط شامل یک شکل پاورقی با متن "Made with Aspose.Slides" است و افکت **Random Bars** بر آن شکل اعمال شده است.

![Slide shape animation effect](slide-shape-animation.png)

فرض کنید افکت **Split** بر placeholder پاورقی در اسلاید **layout** اعمال شده است.

![Layout shape animation effect](layout-shape-animation.png)

و در نهایت، افکت **Fly In** بر placeholder پاورقی در اسلاید **master** اعمال شده است.

![Master shape animation effect](master-shape-animation.png)

کد نمونه زیر نشان می‌دهد چگونه از متد `GetBasePlaceholder` در رابط [IShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/) برای دسترسی به placeholders شکل و دریافت افکت‌های انیمیشن اعمال‌شده بر شکل پاورقی، شامل آنهایی که از placeholders موجود در اسلایدهای layout و master به ارث رسیده‌اند، استفاده کنید.

```cpp
#include <DOM/Animation/IEffect.h>
#include <system/array.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>
using namespace Aspose::Slides::Animation;
using namespace System;

auto PrintEffects = [](ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
};
```
```cpp
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto PrintEffects = [](ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
};

SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"sample.pptx");

SharedPtr<ISlide> slide = presentation->get_Slide(0);

// دریافت افکت‌های انیمیشن شکل در اسلاید معمولی.
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// دریافت افکت‌های انیمیشن placeholder در اسلاید طرح‌بندی.
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// دریافت افکت‌های انیمیشن placeholder در اسلاید مستر.
SharedPtr<IShape> masterShape = layoutShape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> masterShapeEffects = slide->get_LayoutSlide()->get_MasterSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(masterShape);

presentation->Dispose();

Console::WriteLine(u"Main sequence of shape effects:");
PrintEffects(masterShapeEffects);
PrintEffects(layoutShapeEffects);
PrintEffects(shapeEffects);
```

Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // پرواز، پایین
Type: 134, subtype: 45            // تقسیم، ورود عمودی
Type: 126, subtype: 22            // نوارهای تصادفی، افقی
```

## **تغییر ویژگی‌های زمان‌بندی افکت انیمیشن**

Aspose.Slides برای C++ به شما امکان می‌دهد ویژگی‌های زمان‌بندی یک افکت انیمیشن را تغییر دهید.

این پنل زمان‌بندی انیمیشن در Microsoft PowerPoint است:

![example1_image](shape-animation.png)

این‌ها تطابق‌های بین زمان‌بندی PowerPoint و ویژگی‌های [Effect.Timing](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) هستند:

- فهرست کشویی **Start** در زمان‌بندی PowerPoint با ویژگی [Effect.Timing.TriggerType](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3) مطابقت دارد. 
- زمان‌بندی PowerPoint **Duration** با ویژگی [Effect.Timing.Duration](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340) همخوانی دارد. مدت زمان یک انیمیشن (به ثانیه) کل زمانی است که انیمیشن برای تکمیل یک چرخه لازم دارد. 
- زمان‌بندی PowerPoint **Delay** با ویژگی [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b) مطابقت دارد. 

این‌گونه می‌توانید ویژگی‌های زمان‌بندی Effect را تغییر دهید:

1. [Apply](#apply-animation-to-shape) یا دریافت افکت انیمیشن.
2. مقادیر جدیدی برای ویژگی‌های [Effect.Timing](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) که نیاز دارید تنظیم کنید. 
3. فایل PPTX اصلاح‌شده را ذخیره کنید.

این کد C++ عملیات را نشان می‌دهد:

```c++
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// یک نمونه از کلاس Presentation که یک فایل ارائه را نمایندگی می‌کند، ایجاد می‌نماید.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// دنبالهٔ اصلی اسلاید را دریافت می‌کند.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// اولین افکت دنبالهٔ اصلی را دریافت می‌کند.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// نوع TriggerType افکت را برای آغاز با کلیک تغییر می‌دهد.
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// مدت زمان افکت را تغییر می‌دهد.
effect->get_Timing()->set_Duration(3.f);

// زمان تاخیر TriggerDelayTime افکت را تغییر می‌دهد.
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// فایل PPTX را بر روی دیسک ذخیره می‌کند.
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **صدا در افکت انیمیشن**

Aspose.Slides این ویژگی‌ها را برای کار با صداها در افکت‌های انیمیشن فراهم می‌کند: 

- متد [set_Sound()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/effect/set_sound/) 
- متد [set_StopPreviousSound()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **افزودن صدا به افکت انیمیشن**

این کد C++ نشان می‌دهد چگونه صدا به افکت انیمیشن اضافه کنید و هنگام شروع افکت بعدی آن را متوقف کنید:

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System::IO;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// صدایی به مجموعه صوتی ارائه اضافه می‌کند
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// دنبالهٔ اصلی اسلاید را دریافت می‌کند.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// اولین افکت دنبالهٔ اصلی را دریافت می‌کند
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// بررسی افکت برای "بدون صدا"
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // صدا را برای اولین افکت اضافه می‌کند
    firstEffect->set_Sound(effectSound);
}

// دنباله تعاملی اول اسلاید را دریافت می‌کند.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// پرچم “توقف صدا قبلی” افکت را تنظیم می‌کند
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// فایل PPTX را بر روی دیسک ذخیره می‌کند
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **استخراج صدا از افکت انیمیشن**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. مرجع اسلاید را از طریق ایندکس آن دریافت کنید. 
3. دنباله اصلی افکت‌ها را دریافت کنید. 
4. صداهای جاسازی‌شده در هر افکت انیمیشن را با استفاده از متد [set_Sound()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/effect/set_sound/) استخراج کنید. 

این کد C++ نشان می‌دهد چگونه صدای جاسازی‌شده در یک افکت انیمیشن را استخراج کنید:

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// یک نمونه از کلاس Presentation که یک فایل ارائه را نمایندگی می‌کند، ایجاد می‌نماید.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Gets the main sequence of the slide.
System::SharedPtr<ISequence> sequence = slide->get_Timeline()->get_MainSequence();

for (auto&& effect : sequence)
{
    System::SharedPtr<IAudio> sound = effect->get_Sound();

    if (sound == nullptr)
        continue;

    auto audio = sound->get_BinaryData();
}
```

## **پس از انیمیشن**

Aspose.Slides برای C++ به شما امکان می‌دهد ویژگی After animation یک افکت انیمیشن را تغییر دهید.

این پنل افکت انیمیشن و منوی گسترش‌یافته در Microsoft PowerPoint است:

![example1_image](shape-after-animation.png)

فهرست کشویی **After animation** در PowerPoint با این ویژگی‌ها مطابقت دارد: 

- ویژگی [set_AfterAnimationType()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) که نوع After animation را توصیف می‌کند :
  * گزینه **More Colors** در PowerPoint با نوع [AfterAnimationType.Color](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/afteranimationtype/) مطابقت دارد؛
  * گزینه **Don't Dim** در PowerPoint با نوع [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/afteranimationtype/) مطابقت دارد (نوع پیش‌فرض بعد از انیمیشن)؛
  * گزینه **Hide After Animation** در PowerPoint با نوع [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/afteranimationtype/) مطابقت دارد؛
  * گزینه **Hide on Next Mouse Click** در PowerPoint با نوع [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/afteranimationtype/) مطابقت دارد؛
- ویژگی [set_AfterAnimationColor()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) که قالب رنگ پس از انیمیشن را تعریف می‌کند. این ویژگی همراه با نوع [AfterAnimationType.Color](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/afteranimationtype/) کار می‌کند. اگر نوع را به مقدار دیگری تغییر دهید، رنگ پس از انیمیشن پاک می‌شود.

این کد C++ نشان می‌دهد چگونه یک افکت پس از انیمیشن را تغییر دهید:

```c++
#include <DOM/Animation/AfterAnimationType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IColorFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

// یک نمونه از کلاس Presentation که یک فایل ارائه را نمایندگی می‌کند، ایجاد می‌نماید.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// اولین افکت دنبالهٔ اصلی را دریافت می‌کند.
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// نوع after animation را به Color تغییر می‌دهد.
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// رنگ پس از انیمیشن (dim) را تنظیم می‌کند.
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// فایل PPTX را بر روی دیسک ذخیره می‌کند.
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **انیمیشن متن**

Aspose.Slides این ویژگی‌ها را برای کار با بخش *Animate text* یک افکت انیمیشن فراهم می‌کند: 

- متد [set_AnimateTextType()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) که نوع متن انیمیشن را توصیف می‌کند. متن شکل می‌تواند به اشکال زیر انیمیشن شود:
  - همه به‌یک‌بار ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/animatetexttype/) نوع)؛
  - به‌صورت کلمه به کلمه ([AnimateTextType.ByWord](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/animatetexttype/) نوع)؛
  - به‌صورت حرف به حرف ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/animatetexttype/) نوع)؛
- متد [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) تاخیری بین بخش‌های متنی انیمیشن (کلمات یا حروف) تنظیم می‌کند. مقدار مثبت درصدی از مدت زمان افکت را مشخص می‌کند. مقدار منفی تاخیر را بر حسب ثانیه مشخص می‌کند.

این‌گونه می‌توانید ویژگی‌های Animate text افکت را تغییر دهید:

1. [Apply](#apply-animation-to-shape) یا دریافت افکت انیمیشن.
2. ویژگی [set_BuildType()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itextanimation/set_buildtype/) را به مقدار [BuildType.AsOneObject](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/buildtype/) تنظیم کنید تا حالت انیمیشن *By Paragraphs* غیرفعال شود.
3. مقادیر جدیدی برای ویژگی‌های [set_AnimateTextType()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) و [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) تنظیم کنید.
4. فایل PPTX اصلاح‌شده را ذخیره کنید.

این کد C++ عملیات را نشان می‌دهد:

```c++
#include <DOM/Animation/AnimateTextType.h>
#include <DOM/Animation/BuildType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITextAnimation.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

// یک نمونه از کلاس Presentation که یک فایل ارائه را نمایندگی می‌کند، ایجاد می‌نماید.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// اولین افکت دنبالهٔ اصلی را دریافت می‌کند
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// نوع انیمیشن متن افکت را به "به‌عنوان یک شیء" تغییر می‌دهد
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// نوع Animate text افکت را به "به‌صورت کلمه" تغییر می‌دهد
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// تاخیر بین کلمات را به 20٪ از مدت افکت تنظیم می‌کند
firstEffect->set_DelayBetweenTextParts(20.0f);

// فایل PPTX را بر روی دیسک ذخیره می‌کند
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```

## **سوالات متداول**

### چگونه می‌توانم اطمینان حاصل کنم که انیمیشن‌ها هنگام انتشار ارائه در وب حفظ می‌شوند؟

[Export to HTML5](/slides/fa/cpp/export-to-html5/) و فعال‌سازی [options](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/html5options/) مربوط به انیمیشن‌های [shape](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/html5options/set_animateshapes/) و [transition](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/html5options/set_animatetransitions/) . HTML ساده انیمیشن اسلایدها را پخش نمی‌کند، در حالی که HTML5 این کار را می‌کند.

### تغییر ترتیب z-order (سایه‌برداری لایه) شکل‌ها چگونه بر انیمیشن تأثیر می‌گذارد؟

ترتیب انیمیشن و رسم به‌صورت مستقل هستند: یک افکت زمان‌بندی و نوع ظاهر شدن/ناآیدن را کنترل می‌کند، در حالی که [z-order](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shape/get_zorderposition/) تعیین می‌کند کدام شیء چه چیزی را پوشش می‌دهد. نتیجهٔ قابل مشاهده ترکیبی از این دو است. (این رفتار کلی PowerPoint است؛ مدل افکت‌ها و اشکال Aspose.Slides نیز همین منطق را دنبال می‌کند.)

### آیا محدودیتی در تبدیل انیمیشن‌ها به ویدئو برای برخی افکت‌ها وجود دارد؟

به‌طور کلی، [انیمیشن‌ها پشتیبانی می‌شوند](/slides/fa/cpp/convert-powerpoint-to-video/)، اما در موارد نادر یا برای افکت‌های خاص ممکن است متفاوت رندر شوند. توصیه می‌شود با افکت‌های مورد استفاده و نسخهٔ کتابخانه آزمایش کنید.