---
title: "اعمال انیمیشن‌های شکل در ارائه‌ها با استفاده از C++"
linktitle: "انیمیشن شکل"
type: docs
weight: 60
url: /fa/cpp/shape-animation/
keywords:
- "شکل"
- "انیمیشن"
- "اثر"
- "شکل متحرک"
- "متن متحرک"
- "افزودن انیمیشن"
- "دریافت انیمیشن"
- "استخراج انیمیشن"
- "افزودن اثر"
- "دریافت اثر"
- "استخراج اثر"
- "صدای اثر"
- "اعمال انیمیشن"
- "PowerPoint"
- "ارائه"
- "C++"
- "Aspose.Slides"
description: "کشف کنید چگونه انیمیشن‌های شکل را در ارائه‌های PowerPoint با Aspose.Slides برای C++ ایجاد و سفارشی کنید. متمایز شوید!"
---
## **مقدمه**

انیمیشن‌ها افکت‌های بصری هستند که می‌توانند بر روی متن‌ها، تصاویر، شکل‌ها یا [نمودارها](/slides/fa/cpp/animated-charts/) اعمال شوند. آن‌ها به ارائه‌ها یا اجزای آن جان می‌بخشند. 

## **چرا در ارائه‌ها از انیمیشن‌ها استفاده کنیم؟**

با استفاده از انیمیشن‌ها می‌توانید 

* جریان اطلاعات را کنترل کنید
* نکات مهم را برجسته کنید
* علاقه یا مشارکت مخاطبان خود را افزایش دهید
* محتوا را برای خواندن، جذب یا پردازش آسان‌تر کنید
* توجه خوانندگان یا بینندگان خود را به بخش‌های مهم در یک ارائه جلب کنید

PowerPoint گزینه‌ها و ابزارهای بسیاری برای انیمیشن‌ها و اثرات انیمیشن در دسته‌های **entrance**, **exit**, **emphasis**, و **motion paths** ارائه می‌دهد. 

## **انیمیشن‌ها در Aspose.Slides**

* Aspose.Slides کلاس‌ها و نوع‌هایی را که برای کار با انیمیشن‌ها نیاز دارید، تحت فضای نام [Aspose.Slides.Animation](https://reference.aspose.com/slides/fa/cpp/namespace/aspose.slides.animation) فراهم می‌کند،
* Aspose.Slides بیش از **150 اثر انیمیشن** تحت enumeration [EffectType](https://reference.aspose.com/slides/fa/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31) ارائه می‌دهد. این اثرها عملاً همان اثرهای (یا معادل) استفاده شده در PowerPoint هستند.

## **اعمال انیمیشن به TextBox**

Aspose.Slides برای C++ به شما امکان می‌دهد انیمیشن را بر متن داخل یک شکل اعمال کنید. 

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation/) ایجاد کنید.
2. یک ارجاع به اسلاید را از طریق ایندکس آن دریافت کنید.
3. یک `rectangle` [IAutoShape](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_auto_shape) اضافه کنید. 
4. متن را به [IAutoShape.TextFrame](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3) اضافه کنید.
5. دنباله اصلی اثرها را دریافت کنید.
6. یک اثر انیمیشن به [IAutoShape](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_auto_shape) اضافه کنید. 
7. ویژگی [TextAnimation.BuildType](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) را به مقداری از [BuildType Enumeration](https://reference.aspose.com/slides/fa/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7) تنظیم کنید.
8. ارائه را به‌صورت فایل PPTX روی دیسک ذخیره کنید.

این کد C++ نشان می‌دهد چگونه اثر `Fade` را به AutoShape اعمال کنید و انیمیشن متن را به مقدار *By 1st Level Paragraphs* تنظیم کنید:

```c++
// یک شیء از کلاس ارائه ایجاد می‌کند که نمایانگر یک فایل ارائه است.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// یک AutoShape جدید با متن اضافه می‌کند
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// دنباله اصلی اسلاید را دریافت می‌کند.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// اثر انیمیشن Fade را به شکل اضافه می‌کند
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// متن شکل را بر اساس پاراگراف‌های سطح اول انیمیت می‌کند
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// فایل PPTX را روی دیسک ذخیره می‌کند
pres->Save(path + u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="primary"  %}} 

علاوه بر اعمال انیمیشن‌ها بر متن، می‌توانید انیمیشن‌ها را بر یک [Paragraph](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_paragraph) منفرد نیز اعمال کنید. برای جزئیات به [**Animated Text**](/slides/fa/cpp/animated-text/) مراجعه کنید.

{{% /alert %}} 

## **اعمال انیمیشن بر PictureFrame**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation/) ایجاد کنید.
2. یک ارجاع به اسلاید را از طریق ایندکس آن دریافت کنید.
3. یک [PictureFrame](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_picture_frame) روی اسلاید اضافه یا دریافت کنید. 
4. دنباله اصلی اثرها را دریافت کنید.
5. یک اثر انیمیشن به [PictureFrame](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_picture_frame) اضافه کنید.
6. ارائه را به‌صورت فایل PPTX روی دیسک ذخیره کنید.

این کد C++ نشان می‌دهد چگونه اثر `Fly` را به یک picture frame اعمال کنید:

```c++
// یک شیء از کلاس ارائه ایجاد می‌کند که نمایانگر یک فایل ارائه است.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// تصویری را که قرار است در مجموعه تصاویر ارائه اضافه شود بارگذاری می‌کند
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// قاب تصویر را به اسلاید اضافه می‌کند
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// دنباله اصلی اسلاید را دریافت می‌کند.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// اثر انیمیشن Fly از سمت چپ را به قاب تصویر اضافه می‌کند
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// فایل PPTX را روی دیسک ذخیره می‌کند
pres->Save(path + u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **اعمال انیمیشن بر Shape**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation/) ایجاد کنید.
2. یک ارجاع به اسلاید را از طریق ایندکس آن دریافت کنید.
3. یک `rectangle` [IAutoShape](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_auto_shape) اضافه کنید. 
4. یک `Bevel` [IAutoShape](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_auto_shape) اضافه کنید (زمانی که این شیء کلیک شود، انیمیشن اجرا می‌شود).
5. یک دنباله از اثرها بر روی شکل bevel ایجاد کنید.
6. یک `UserPath` سفارشی ایجاد کنید.
7. دستورات برای حرکت به `UserPath` اضافه کنید.
8. ارائه را به‌صورت فایل PPTX روی دیسک ذخیره کنید.

این کد C++ نشان می‌دهد چگونه اثر `PathFootball` (path football) را به یک shape اعمال کنید:

```c++
	// مسیر دایرکتوری سند.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// ارائه را بارگذاری می‌کند
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// به اولین اسلاید دسترسی پیدا می‌کند
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// مجموعه اشکال اسلاید انتخاب‌شده را دسترسی می‌یابد
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// اثر PathFootball را برای شکل موجود از ابتدا ایجاد می‌کند.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// اثر انیمیشن PathFootBall را اضافه می‌کند
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// نوعی دکمه ایجاد می‌کند.
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// دنباله‌ای از اثرها برای این دکمه ایجاد می‌کند.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // مسیر کاربری سفارشی ایجاد می‌کند. شیء ما فقط پس از کلیک دکمه جابه‌جا می‌شود.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// دستورات حرکت را اضافه می‌کند چون مسیر ایجاد شده خالی است.
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
	 
	 // فایل PPTX را روی دیسک ذخیره می‌کند
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **دریافت اثرهای انیمیشن اعمال شده بر یک Shape**

مثال‌های زیر نحوه استفاده از متد `GetEffectsByShape` از اینترفیس [ISequence](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/isequence/) را برای دریافت تمام اثرهای انیمیشن اعمال شده بر یک shape نشان می‌دهند.

**مثال 1: دریافت اثرهای انیمیشن اعمال شده بر یک shape در یک اسلاید معمولی**

پیش از این، نحوه افزودن اثرهای انیمیشن به شکل‌ها در ارائه‌های PowerPoint را یاد گرفته بودید. کد نمونه زیر نشان می‌دهد چگونه اثرهای اعمال شده به اولین shape روی اولین اسلاید معمولی در ارائه `AnimExample_out.pptx` را دریافت کنید.

```c++
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"AnimExample_out.pptx");

SharedPtr<ISlide> firstSlide = presentation->get_Slide(0);

// Gets the main animation sequence of the slide.
SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Gets the first shape on the first slide.
SharedPtr<IShape> shape = firstSlide->get_Shape(0);

// Gets animation effects applied to the shape.
ArrayPtr<SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    Console::WriteLine(u"The shape " + shape->get_Name() + u" has " + shapeEffects->get_Length() + u" animation effects.");
}

presentation->Dispose();
```

**مثال 2: دریافت تمام اثرهای انیمیشن، شامل آن‌هایی که از placeholders به ارث می‌رسند**

اگر یک shape در یک اسلاید معمولی placeholders داشته باشد که در اسلاید layout و/یا master هستند و اثرهای انیمیشن به این placeholders اضافه شده باشد، تمام اثرهای shape در طول نمایش اسلاید پخش می‌شوند، شامل آن‌هایی که از placeholders به ارث می‌رسند.

فرض کنید فایلی PowerPoint به نام `sample.pptx` داریم که دارای یک اسلاید با تنها یک shape فوتر متنی «Made with Aspose.Slides» است و اثر **Random Bars** روی آن اعمال شده است.

![اثر انیمیشن شکل اسلاید](slide-shape-animation.png)

همچنین فرض کنید اثر **Split** روی placeholder فوتر در اسلاید **layout** اعمال شده است.

![اثر انیمیشن شکل Layout](layout-shape-animation.png)

و در نهایت، اثر **Fly In** روی placeholder فوتر در اسلاید **master** اعمال شده است.

![اثر انیمیشن شکل Master](master-shape-animation.png)

کد نمونه زیر نشان می‌دهد چگونه از متد `GetBasePlaceholder` از اینترفیس [IShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides.ishape/) برای دسترسی به placeholderهای shape و دریافت اثرهای انیمیشن اعمال شده به shape فوتر، شامل اثرهای ارث‌برده از placeholders در اسلایدهای layout و master استفاده کنید.

```cpp
void PrintEffects(ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
}
```
```cpp
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"sample.pptx");

SharedPtr<ISlide> slide = presentation->get_Slide(0);

// دریافت اثرهای انیمیشن شکل در اسلاید عادی.
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// دریافت اثرهای انیمیشن جای‌گیر در اسلاید طرح‌بندی.
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// دریافت اثرهای انیمیشن جای‌گیر در اسلاید اصلی.
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
Type: 134, subtype: 45            // تقسیم، عمودی داخل
Type: 126, subtype: 22            // نوارهای تصادفی، افقی
```

## **تغییر ویژگی‌های زمان‌بندی اثر انیمیشن**

Aspose.Slides برای C++ به شما امکان می‌دهد ویژگی‌های Timing یک اثر انیمیشن را تغییر دهید.

این پنل زمان‌بندی انیمیشن در Microsoft PowerPoint است:

![پنل زمان‌بندی انیمیشن در Microsoft PowerPoint](shape-animation.png)

این‌ها تطابق‌های بین زمان‌بندی PowerPoint و ویژگی‌های [Effect.Timing](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) هستند:

- فهرست کشویی **Start** در PowerPoint Timing با ویژگی [Effect.Timing.TriggerType](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3) مطابقت دارد. 
- فهرست کشویی **Duration** در PowerPoint Timing با ویژگی [Effect.Timing.Duration](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340) مطابقت دارد. مدت زمان یک انیمیشن (بر حسب ثانیه) کل زمانی است که برای تکمیل یک چرخه نیاز است. 
- فهرست کشویی **Delay** در PowerPoint Timing با ویژگی [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b) مطابقت دارد. 

این روش تغییر ویژگی‌های زمان‌بندی اثر است:

1. [Apply](#apply-animation-to-shape) یا دریافت اثر انیمیشن.
2. مقادیر جدیدی برای ویژگی‌های [Effect.Timing](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) که نیاز دارید تنظیم کنید. 
3. فایل PPTX اصلاح‌شده را ذخیره کنید.

این کد C++ عملیات را نشان می‌دهد:

```c++
// یک شیء از کلاس ارائه ایجاد می‌کند که نمایانگر یک فایل ارائه است.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// دنباله اصلی اسلاید را دریافت می‌کند.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// اولین اثر دنباله اصلی را دریافت می‌کند.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// نوع TriggerType اثر را به شروع با کلیک تغییر می‌دهد
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// مدت زمان اثر را تغییر می‌دهد
effect->get_Timing()->set_Duration(3.f);

// زمان تأخیر TriggerDelayTime اثر را تغییر می‌دهد
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// فایل PPTX را روی دیسک ذخیره می‌کند
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **صدای اثر انیمیشن**

Aspose.Slides این ویژگی‌ها را برای کار با صداها در اثرهای انیمیشن ارائه می‌دهد: 

- [set_Sound()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/effect/set_sound/) 
- [set_StopPreviousSound()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **افزودن صدای اثر انیمیشن**

این کد C++ نشان می‌دهد چگونه صدای یک اثر انیمیشن اضافه کنید و هنگام شروع اثر بعدی آن را متوقف کنید:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// صدا را به مجموعه صداهای ارائه اضافه می‌کند
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// دنباله اصلی اسلاید را دریافت می‌کند.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// اولین اثر دنباله اصلی را دریافت می‌کند
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// اثر را برای "بدون صدا" بررسی می‌کند
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // صدا را برای اولین اثر اضافه می‌کند
    firstEffect->set_Sound(effectSound);
}

// اولین دنباله تعاملی اسلاید را دریافت می‌کند.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// پرچم "متوقف کردن صدای قبلی" اثر را تنظیم می‌کند
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// فایل PPTX را روی دیسک ذخیره می‌کند
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **استخراج صدای اثر انیمیشن**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
2. ارجاع به اسلاید را از طریق ایندکس آن دریافت کنید. 
3. دنباله اصلی اثرها را دریافت کنید. 
4. [set_Sound()] را که در هر اثر انیمیشن جاسازی شده است استخراج کنید. 

این کد C++ نشان می‌دهد چگونه صدای جاسازی‌شده در یک اثر انیمیشن را استخراج کنید:

```c++
// یک شیء از کلاس ارائه ایجاد می‌کند که نمایانگر یک فایل ارائه است.
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

Aspose.Slides برای C++ به شما امکان می‌دهد ویژگی **After animation** یک اثر انیمیشن را تغییر دهید.

این پنل اثر انیمیشن و منوی گسترش‌یافته در Microsoft PowerPoint است:

![پنل اثر انیمیشن و منوی گسترش‌یافته در Microsoft PowerPoint](shape-after-animation.png)

فهرست کشویی **After animation** در PowerPoint با این ویژگی‌ها مطابقت دارد: 

- ویژگی [set_AfterAnimationType()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) که نوع پس از انیمیشن را توصیف می‌کند :
  * PowerPoint **More Colors** با نوع [AfterAnimationType.Color](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/afteranimationtype/) مطابقت دارد؛
  * PowerPoint **Don't Dim** با نوع [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/afteranimationtype/) (نوع پیش‌فرض پس از انیمیشن) مطابقت دارد؛
  * PowerPoint **Hide After Animation** با نوع [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/afteranimationtype/) مطابقت دارد؛
  * PowerPoint **Hide on Next Mouse Click** با نوع [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/afteranimationtype/) مطابقت دارد؛
- ویژگی [set_AfterAnimationColor()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) که قالب رنگ پس از انیمیشن را تعریف می‌کند. این ویژگی همراه با نوع [AfterAnimationType.Color](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/afteranimationtype/) کار می‌کند. اگر نوع را به مقدار دیگری تغییر دهید، رنگ پس از انیمیشن پاک می‌شود.

این کد C++ نشان می‌دهد چگونه یک اثر پس از انیمیشن را تغییر دهید:

```c++
// یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// اولین اثر دنباله اصلی را دریافت می‌کند
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// نوع پس از انیمیشن را به Color تغییر می‌دهد
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// رنگ کم‌رنگ‌شدن پس از انیمیشن را تنظیم می‌کند
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// فایل PPTX را روی دیسک ذخیره می‌کند
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **انیمیشن متن**

Aspose.Slides این ویژگی‌ها را برای کار با بلوک *Animate text* یک اثر انیمیشن فراهم می‌کند:

- ویژگی [set_AnimateTextType()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) که نوع انیمیشن متن اثر را توصیف می‌کند. متن shape می‌تواند به‌صورت:
  - همه به‌یک‌باره ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/animatetexttype/) )
  - به‌صورت کلمه ([AnimateTextType.ByWord](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/animatetexttype/) )
  - به‌صورت حرف ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/animatetexttype/) )
  انیمیشن شود.
- ویژگی [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) که تاخیر بین بخش‌های متن انیمیشن‌شده (کلمات یا حروف) را تنظیم می‌کند. مقدار مثبت درصدی از مدت اثر را مشخص می‌کند؛ مقدار منفی تاخیر را بر حسب ثانیه تعیین می‌کند.

این روش تغییر ویژگی‌های *Animate text* برای اثر است:

1. [Apply](#apply-animation-to-shape) یا دریافت اثر انیمیشن.
2. ویژگی [set_BuildType()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itextanimation/set_buildtype/) را به مقدار [BuildType.AsOneObject](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/buildtype/) تنظیم کنید تا حالت انیمیشن *By Paragraphs* غیرفعال شود.
3. مقادیر جدیدی برای ویژگی‌های [set_AnimateTextType()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) و [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) تنظیم کنید.
4. فایل PPTX اصلاح‌شده را ذخیره کنید.

این کد C++ عملیات را نشان می‌دهد:

```c++
// یک شیء از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Gets the first effect of the main sequence
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Changes the effect Text animation type to "As One Object"
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// Changes the effect Animate text type to "By word"
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// Sets the delay between words to 20% of effect duration
firstEffect->set_DelayBetweenTextParts(20.0f);

// Writes the PPTX file to disk
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```

## **سوالات متداول**

**چگونه می‌توانم اطمینان حاصل کنم که انیمیشن‌ها هنگام انتشار ارائه در وب حفظ می‌شوند؟**

[Export to HTML5](/slides/fa/cpp/export-to-html5/) را انجام دهید و گزینه‌های مربوط به [shape](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/html5options/set_animateshapes/) و [transition](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/html5options/set_animatetransitions/) را فعال کنید. HTML ساده انیمیشن‌های اسلاید را پخش نمی‌کند، در حالی که HTML5 این کار را می‌کند.

**تغییر ترتیب z-order (ترتیب لایه) اشکال چه تأثیری بر انیمیشن دارد؟**

انیمیشن و ترتیب رسم مستقل هستند: یک اثر زمان‌بندی و نوع ظاهر شدن/ناینسیدن را کنترل می‌کند، در حالی که [z-order](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shape/get_zorderposition/) تعیین می‌کند چه چیزی چه چیزی را می‌پوشاند. نتیجه قابل مشاهده ترکیب این دو است. (این رفتار کلی PowerPoint است؛ مدل اثرها و اشکال Aspose.Slides نیز همان منطق را دنبال می‌کند.)

**آیا در تبدیل انیمیشن‌ها به ویدئو برای برخی اثرها محدودیتی وجود دارد؟**

به‌طور کلی، [انیمیشن‌ها پشتیبانی می‌شوند](/slides/fa/cpp/convert-powerpoint-to-video/)، اما موارد نادر یا اثرهای خاص ممکن است به‌صورت متفاوتی رندر شوند. توصیه می‌شود با اثرهای مورد استفاده و نسخه کتابخانه تست کنید.