---
title: ایجاد و ویرایش رفتارهای سفارشی انیمیشن در C++
linktitle: انیمیشن سفارشی
type: docs
weight: 151
url: /fa/cpp/custom-animation/
keywords:
- انیمیشن سفارشی
- رفتار انیمیشن
- مسیر حرکتی
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "ایجاد، بررسی و ویرایش رفتارهای سفارشی انیمیشن و مسیرهای حرکتی قابل ویرایش در ارائه‌های PowerPoint با Aspose.Slides برای C++."
---
## **بررسی کلی**

رفتارهای سفارشی انیمیشن به شما امکان کنترل عملیات‌های منفرد داخل یک اثر انیمیشنی را می‌دهند، مانند تغییر رنگ، چرخاندن یک شکل، یا دنبال کردن مسیر حرکتی قابل ویرایش. این راهنما نشان می‌دهد چگونه رفتارها را ایجاد و ترکیب کنید، زمان‌بندی آن‌ها را تنظیم کنید، انیمیشن‌های موجود را بررسی و اصلاح کنید، و اطمینان حاصل کنید که ویژگی‌های آن‌ها پس از ذخیره و باز کردن مجدد یک ارائه حفظ می‌شوند.

برای جلوه‌های از پیش تعریف‌شده و محرک‌های کلیک، به [انیمیشن شکل](/slides/fa/cpp/shape-animation/) مراجعه کنید.

## **درک مدل انیمیشن**

یک انیمیشن به صورت **Timeline → Sequence → Effect → Behaviors** سازماندهی می‌شود:

- اسلاید [get_Timeline](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseslide/get_timeline/) خود را شامل توالی اصلی و توالی‌های تعاملی می‌سازد.
- یک [ISequence](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/isequence/) شامل افکت‌ها است که ممکن است به شکل‌های مختلف هدف‌گذاری شوند.
- یک [IEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ieffect/) شکل هدف، پیش‌تنظیم، زیرنوع و زمان‌بندی افکت را شناسایی می‌کند.
- [IEffect::get_Behaviors](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ieffect/get_behaviors/) حاوی عملیات‌هایی است که اثر را پیاده‌سازی می‌کنند: تغییر رنگ، حرکت، چرخش، تنظیم یک ویژگی و غیره.

## **ایجاد رفتارهای منفرد**

از [ISequence::AddEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/isequence/addeffect/) برای ایجاد یک افکت و دسترسی به مجموعه [get_Behaviors](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ieffect/get_behaviors/) آن استفاده کنید. یک پیش‌تنظیم می‌تواند این مجموعه را به‌صورت خودکار پر کند. هنگام گسترش پیش‌تنظیم، عملیات‌های آن را حفظ کنید یا برای جایگزینی عمدی از [Clear](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ibehaviorcollection/clear/) استفاده کنید.

[IBehaviorFactory](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ibehaviorfactory/) هشت نوع رفتار نشان‌داده‌شده در ادامه را می‌سازد. حرکت در بخش [ساخت مسیر حرکتی](#build-a-motion-path) پوشانده شده است. هر مثال ساخت به‌صورت کد مستقل داخل یک تابع اجرا می‌شود؛ مثال‌های ویرایش بعدی مشخص می‌کنند از کدام فایل خروجی استفاده می‌کنند.

### **چرخش**

از [CreateRotationEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) برای ایجاد یک چرخش استفاده کنید. [get_By](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/irotationeffect/get_by/) زاویهٔ نسبی برحسب درجه را مشخص می‌کند؛ [get_From](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/irotationeffect/get_from/) و [get_To](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/irotationeffect/get_to/) نقاط انتهایی را تعیین می‌کنند.

مثال با یک اثر Spin آغاز می‌شود، عملیات پیش‌تنظیم آن را با یک رفتار چرخش جایگزین می‌کند و به آن عملیات مدت زمان دو ثانیه می‌دهد. زاویهٔ نسبی ۹۰ درجه یک چرخش چهار‌گانه از جهت اولیهٔ شکل را بیان می‌کند، بنابراین نیازی به زاویهٔ شروع صریح نیست.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Spin, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto rotation = factory->CreateRotationEffect();
rotation->set_By(90.0f);
rotation->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(rotation);

presentation->Save(u"rotation.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`rotation.pptx` شامل یک شکل و یک رفتار چرخش است. مجموعه، زمان‌بندی و مثال‌های ویرایش چرخش در زیر از این فایل استفاده می‌کنند.

### **مقیاس**

از [CreateScaleEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) با درصدهای X/Y استفاده کنید: [get_From](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/iscaleeffect/get_from/) و [get_To](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/iscaleeffect/get_to/) اندازهٔ آغاز و پایان را توصیف می‌کنند، در حالی که [get_By](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/iscaleeffect/get_by/) تغییر نسبی را توضیح می‌دهد. در اینجا، ۱۰۰ به معنای اندازهٔ اصلی است.

مثال ابعاد هر دو جهت را از ۱۰۰٪ به ۱۲۵٪ در طول دو ثانیه بزرگ می‌کند. استفاده از درصدهای مساوی افقی و عمودی نسبت‌های شکل را حفظ می‌کند؛ درصدهای متفاوت یک بعد را بیشتر از دیگری می‌کشاند.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IScaleEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::GrowShrink, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto scale = factory->CreateScaleEffect();
scale->set_From(PointF(100, 100));
scale->set_To(PointF(125, 125));
scale->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(scale);

presentation->Save(u"scale.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **رنگ**

از [CreateColorEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) برای تغییر پر از آبی به نارنجی استفاده کنید. [get_From](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/icoloreffect/get_from/) و [get_To](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/icoloreffect/get_to/) رنگ‌ها هستند؛ [get_By](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/icoloreffect/get_by/) جابجایی رنگ است. [IBehavior::get_Properties](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ibehavior/get_properties/) ویژگی‌ ای را که انیمیشن می‌شود شناسایی می‌کند.

پر جامد شکل ابتدا به رنگ آبی تنظیم می‌شود تا با رنگ آغاز انیمیشن مطابقت داشته باشد. انتخاب ویژگی fill-color به رفتار می‌گوید کدام بخش شکل تغییر کند؛ تنها نقاط انتهایی رنگ، آن ویژگی را مشخص نمی‌کنند. افکت ذخیره‌شده توصیفگر انتقال دو ثانیه‌ای به نارنجی است.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IColorEffect.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/FillType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::ChangeFillColor, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto color = factory->CreateColorEffect();
color->get_Properties()->Add(BehaviorProperty::get_FillColor()->get_Value());
color->get_From()->set_Color(Color::get_Blue());
color->get_To()->set_Color(Color::get_Orange());
color->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(color);

presentation->Save(u"color.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **فیلتر**

از [CreateFilterEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) برای انتخاب یک wipe استفاده کنید. [get_Type](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ifiltereffect/get_type/)، [get_Subtype](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ifiltereffect/get_subtype/) و [get_Reveal](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ifiltereffect/get_reveal/) به ترتیب فیلتر، جهت و این که شکل را نشان دهد یا مخفی کند، مشخص می‌کنند.

این مثال یک wipe دو ثانیه‌ای پیکربندی می‌کند که شکل را با جهت right‑subtype نشان می‌دهد. تنظیمات فیلتر متعلق به رفتار داخل افکت هستند، بنابراین پس از حذف عملیات اصلی پیش‌تنظیم، پیکربندی می‌شوند.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/FilterEffectRevealType.h>
#include <DOM/Animation/FilterEffectSubtype.h>
#include <DOM/Animation/FilterEffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IFilterEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Wipe, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto filter = factory->CreateFilterEffect();
filter->set_Type(FilterEffectType::Wipe);
filter->set_Subtype(FilterEffectSubtype::Right);
filter->set_Reveal(FilterEffectRevealType::In);
filter->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(filter);

presentation->Save(u"filter.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **ویژگی**

از [CreatePropertyEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) برای انیمیشن شفافیت استفاده کنید. [get_From](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ipropertyeffect/get_from/)، [get_To](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ipropertyeffect/get_to/) و [get_By](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ipropertyeffect/get_by/) رشته‌هایی هستند که با استفاده از [get_ValueType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ipropertyeffect/get_valuetype/) و [get_CalcMode](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ipropertyeffect/get_calcmode/) تفسیر می‌شوند. به‌جای تنظیم سه مقدار به‌صورت همزمان، بهتر است انتهاها یا جابجایی نسبی را انتخاب کنید.

در اینجا ویژگی انتخاب‌شده شفافیت است و رشته‌های عددی نشان‌دهندۀ تغییری از ۲۵٪ شفافیت به شفافیت کامل. درون‌یابی خطی توصیفگر تغییر تدریجی بین این مقادیر است. هنگام تطبیق این مثال برای ویژگی دیگر، نوع مقدار و مقادیر انتهایی متناسب را انتخاب کنید.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IPropertyEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/Animation/PropertyCalcModeType.h>
#include <DOM/Animation/PropertyValueType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto property = factory->CreatePropertyEffect();
property->get_Properties()->Add(BehaviorProperty::get_StyleOpacity()->get_Value());
property->set_ValueType(PropertyValueType::Number);
property->set_CalcMode(PropertyCalcModeType::Linear);
property->set_From(u"0.25");
property->set_To(u"1");
property->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(property);

presentation->Save(u"property.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **تنظیم**

از [CreateSetEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ibehaviorfactory/createseteffect/) برای اختصاص قابلیت دیده شدن از طریق [get_To](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/iseteffect/get_to/) استفاده کنید. یک رفتار set بین دو نقطهٔ انتهایی درونی‌سازی نمی‌کند.

مثال ویژگی visible را انتخاب می‌کند و رشته `visible` را هنگام اجرا به رفتار تخصیص می‌دهد. در C++ قبل از تخصیص باید رشته را به‌صورت شیء بپوشانید. مستطیل در این ارائهٔ کمینه قبلاً قابل رؤیت است، بنابراین این تخصیص ممکن است به‌تنهایی تغییر بصری واضحی ایجاد نکند. چنین عملی برای ترکیب با افکت بزرگتری مفید است که زمان پنهان یا نمایان شدن شکل را نیز کنترل می‌کند.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISetEffect.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Appear, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto set = factory->CreateSetEffect();
set->get_Properties()->Add(BehaviorProperty::get_StyleVisibility()->get_Value());
auto visibility = ObjectExt::Box<String>(u"visible");
set->set_To(visibility);

effect->get_Behaviors()->Add(set);

presentation->Save(u"set.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **دستورات**

از [CreateCommandEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) استفاده کنید و [get_Type](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/icommandeffect/get_type/)، [get_CommandString](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/icommandeffect/get_commandstring/) و [get_ShapeTarget](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/icommandeffect/get_shapetarget/) را پیکربندی کنید. یک فایل صوتی WAV به نام `sample.wav` را در پوشهٔ کاری قرار دهید. این مثال آن را با [AddAudioFrameEmbedded](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) تعبیه می‌کند و یک دستور play به قاب صوتی پیوست می‌شود.

قاب صوتی هم هدف افکت و هم هدف دستور است. این اتصال درخواست play را به ضبط تعبیه‌شده می‌سازد؛ یک رشتهٔ دستور به تنهایی شیء رسانه‌ای مورد کنترل را مشخص نمی‌کند. افکت برای شروع در یک کلیک هنگام نمایش اسلاید تنظیم می‌شود.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/CommandEffectType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/ICommandEffect.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = IO::File::OpenRead(u"sample.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(100, 100, 40, 40, audioStream);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(audioFrame, EffectType::MediaPlay, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto command = factory->CreateCommandEffect();
command->set_Type(CommandEffectType::Call);
command->set_CommandString(u"play");
command->set_ShapeTarget(audioFrame);

effect->get_Behaviors()->Add(command);

presentation->Save(u"command.pptx", SaveFormat::Pptx);

audioStream->Close();

presentation->Dispose();
```

ذخیره‌سازی دستور را در `command.pptx` ذخیره می‌کند؛ ضبط را پخش نمی‌کند. پخش نیاز به پخش‌کنندهٔ اسلاید‌نمایشی دارد که از این دستور و هدف رسانه‌ای آن پشتیبانی کند.

## **مدیریت مجموعهٔ رفتارها**

[IBehaviorCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ibehaviorcollection/) از [Add](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ibehaviorcollection/add/)، [Insert](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ibehaviorcollection/insert/)، [Remove](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ibehaviorcollection/remove/) و [RemoveAt](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ibehaviorcollection/removeat/) پشتیبانی می‌کند. این مثال `rotation.pptx` را باز می‌کند، مقیاس‌گذاری اضافه می‌کند، قبل از چرخش جابه‌جا می‌نماید و سپس چرخش را حذف می‌کند. حذف و افزودن مجدد همان شیء موقعیت ذخیره‌شدهٔ آن را بدون ایجاد نسخهٔ جدید تغییر می‌دهد.

دنبالهٔ ویرایش‌ها مجموعه را از rotation‑scale به scale‑rotation و سپس به تنها scale تغییر می‌دهد. اندیس‌ها به مجموعهٔ جاری ارجاع می‌دهند، بنابراین حذف از اندیس جدید چرخش پس از بازچینش استفاده می‌کند. شمارش نهایی نشان می‌دهد کدام رفتار ذخیره خواهد شد.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IScaleEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto behaviors = effect->get_Behaviors();

auto factory = MakeObject<BehaviorFactory>();
auto scale = factory->CreateScaleEffect();
scale->set_To(PointF(125, 125));
scale->get_Timing()->set_Duration(2.0f);

behaviors->Add(scale);

behaviors->Remove(scale);
behaviors->Insert(0, scale);
behaviors->RemoveAt(1);

for (auto behavior : behaviors)
    Console::WriteLine(behavior->GetType().get_Name());

presentation->Save(u"collection-edited.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

خروجی `ScaleEffect` است: فقط مقیاس‌گذاری باقی مانده است. ترتیب مجموعه به خودی خود زمان‌بندی رفتارها را پشت سر هم تنظیم نمی‌کند. فقط وقتی همهٔ عملیات را جایگزین می‌کنید از Clear استفاده کنید.

## **پیکربندی زمان‌بندی رفتار**

[IBehavior::get_Timing](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ibehavior/get_timing/)، مستقل از [IEffect::get_Timing](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ieffect/get_timing/)، [ITiming](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itiming/) را باز می‌کند. زمان‌بندی افکت زمان‌بندی افکت محاطی را برنامه‌ریزی می‌کند؛ زمان‌بندی رفتار یک عملیات داخلی آن را توصیف می‌کند.

### **تنظیم مدت زمان، تاخیر، تکرار و شتاب**

`rotation.pptx` را باز کرده و [get_Duration](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itiming/get_duration/) و [get_TriggerDelayTime](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itiming/get_triggerdelaytime/) را بر حسب ثانیه تنظیم کنید، سپس [get_RepeatCount](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itiming/get_repeatcount/) را پیکربندی کنید. [get_Accelerate](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itiming/get_accelerate/) و [get_Decelerate](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itiming/get_decelerate/) بخش‌هایی از مدت زمان هستند؛ مجموع آن‌ها حداکثر ۱ باشد.

فایل ورودی همان فایلی است که در مثال چرخش ساخته شد و اولین رفتار آن یک چرخش شناخته‌شده است. این مثال فقط زمان‌بندی آن رفتار را تغییر می‌دهد؛ زاویهٔ ۹۰ درجه دست نخورده می‌ماند. جداسازی زاویه و زمان‌بندی، تنظیم سرعت را بدون بازسازی انیمیشن آسان‌تر می‌کند.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

auto rotation = ExplicitCast<IRotationEffect>(effect->get_Behaviors()->idx_get(0));
rotation->get_Timing()->set_Duration(2.0f);
rotation->get_Timing()->set_TriggerDelayTime(0.5f);
rotation->get_Timing()->set_RepeatCount(3.0f);
rotation->get_Timing()->set_Accelerate(0.2f);
rotation->get_Timing()->set_Decelerate(0.2f);

presentation->Save(u"timing.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

رفتار دو ثانیه مدت زمان، نیم‌ثانیه تاخیر و شمارش تکرار ۳ دارد. ۲۰٪ اول و آخر مدت زمان برای شتاب و کاهـش استفاده می‌شود.

سیاست‌های تکرار دیگر شامل [get_RepeatDuration](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itiming/get_repeatduration/)، [get_RepeatUntilEndSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itiming/get_repeatuntilendslide/)، و [get_RepeatUntilNextClick](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itiming/get_repeatuntilnextclick/) هستند؛ یک سیاست را انتخاب کنید نه اینکه همه را همزمان فعال کنید. [get_AutoReverse](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/itiming/get_autoreverse/) پس از عبور پیش‌رو انیمیشن را به‌عکس اجرا می‌کند. شتاب و کاهـش برای تغییرات پیوسته اعمال می‌شوند، نه برای مقادیر گسسته یا دستورات.

## **ساخت مسیر حرکتی**

از [CreateMotionEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) برای ایجاد حرکت استفاده کنید. [get_From](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/imotioneffect/get_from/)، [get_To](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/imotioneffect/get_to/) و [get_By](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/imotioneffect/get_by/) مختصات یا جابجایی‌های مبتنی بر درصد را توصیف می‌کنند. برای مسیر قابل ویرایش، یک [MotionPath](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/motionpath/) ایجاد کنید و آن را به [IMotionEffect::get_Path](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/imotioneffect/get_path/) اختصاص دهید. [IMotionPath](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/imotionpath/) دستورات مسیر را ذخیره می‌کند.

[MotionCommandPathType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/motioncommandpathtype/) عملیات را انتخاب می‌کند:

| فرمان | نقاط | معنی |
| --- | --- | --- |
| MoveTo | یک | تعیین موقعیت شروع. |
| LineTo | یک | حرکت در یک قطعهٔ مستقیم به نقطهٔ انتهایی آن. |
| CurveTo | سه | دنبال کردن منحنی مکعبی تعریف‌شده توسط دو نقطهٔ کنترل و یک نقطهٔ انتهایی. |
| CloseLoop | هیچ | بازگشت به موقعیت شروع. |
| End | هیچ | پایان مسیر. |

[MotionPathPointsType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/motionpathpointstype/) ویژگی‌های ویرایش نقطه را توصیف می‌کند، مانند نقطهٔ گوشه یا صاف. این نوع نقطه جایگزین نوع فرمان نمی‌شود. برای مثال منحنی زیر، از نوع نقطهٔ منحنی استفاده کنید و برای قطعات مستقیم از نوع نقطهٔ گوشه.

مختصات مسیر نسبت به ابعاد اسلاید نرمال‌سازی می‌شود: جابه‌جایی X برابر ۰٫۲۵ نشان‌دهندۀ یک‌چهارم عرض اسلاید است، نه ۰٫۲۵ پوینت. Y مثبت به سمت پایین دارد. دستورات مطلق موقعیت‌ها را در سیستم مختصات مسیر مشخص می‌کنند؛ دستورات نسبی جابجایی‌ها را نسبت به موقعیت جاری بیان می‌کنند. این امر مستقل از [get_Origin](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/imotioneffect/get_origin/) است که چهارچوب مرجع مسیر را انتخاب می‌کند و از [get_PathEditMode](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/imotioneffect/get_patheditmode/) که نحوهٔ حرکت مسیر هنگام جابه‌جایی شکل را کنترل می‌کند.

### **ایجاد مسیر مستقیم**

یک رفتار حرکتی با نقطهٔ شروع، یک قطعهٔ مستقیم و یک فرمان پایان ایجاد کنید. [IMotionPath::Add](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/imotionpath/add/) نوع فرمان، نقاط آن، نوع نقطه و پرچم مختصات نسبی را می‌گیرد.

فرمان شروع (0, 0) را تنظیم می‌کند و خط به (0.25, 0) ختم می‌شود، که مسیر را یک‌چهارم عرض اسلاید افقی می‌سازد. فرمان پایان هیچ نقطهٔ مختصاتی ندارد. پس از اختصاص مسیر، افزودن رفتار حرکتی به افکت آن مسیر را به مستطیل متصل می‌کند.

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionOriginType.h>
#include <DOM/Animation/MotionPath.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::PathRight, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto motion = factory->CreateMotionEffect();
motion->set_Origin(MotionOriginType::Layout);
motion->get_Timing()->set_Duration(2.0f);

auto path = MakeObject<MotionPath>();
auto startPoints = MakeArray<PointF>({ PointF(0, 0) });
path->Add(MotionCommandPathType::MoveTo, startPoints, MotionPathPointsType::Auto, false);
auto linePoints = MakeArray<PointF>({ PointF(0.25f, 0) });
path->Add(MotionCommandPathType::LineTo, linePoints, MotionPathPointsType::Corner, false);
auto endPoints = MakeArray<PointF>(0);
path->Add(MotionCommandPathType::End, endPoints, MotionPathPointsType::None, false);

motion->set_Path(path);
effect->get_Behaviors()->Add(motion);

presentation->Save(u"motion.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`motion.pptx` شامل یک رفتار حرکتی با سه فرمان مسیر است. مثال‌های ویرایش فایل زیر از این ساختار شناخته‌شده استفاده می‌کنند.

### **مقایسهٔ مختصات مطلق و نسبی**

این دو شیء مسیر همان مسیر را توصیف می‌کنند. فرمان مطلق در (0.3, 0.1) پایان می‌یابد؛ فرمان نسبی (0.1, 0.1) را به موقعیت جاری (0.2, 0) اضافه می‌کند.

هر دو مسیر از همان موقعیت شروع می‌شوند. برای خط نسبی، جابجایی‌های X و Y را به موقعیت جاری اضافه کنید تا نقطهٔ انتهایی به‌دست آید؛ برای خط مطلق، نقطهٔ انتهایی را مستقیماً بخوانید. تغییر پرچم بدون تبدیل مختصات مسیر متفاوتی را توصیف می‌کند.

```cpp
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPath.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;
using namespace System::Drawing;

auto absolutePath = MakeObject<MotionPath>();
auto startPoints = MakeArray<PointF>({ PointF(0.2f, 0) });
absolutePath->Add(MotionCommandPathType::MoveTo, startPoints, MotionPathPointsType::Auto, false);
auto absoluteEndPoints = MakeArray<PointF>({ PointF(0.3f, 0.1f) });
absolutePath->Add(MotionCommandPathType::LineTo, absoluteEndPoints, MotionPathPointsType::Corner, false);

auto relativePath = MakeObject<MotionPath>();
auto relativeStartPoints = MakeArray<PointF>({ PointF(0.2f, 0) });
relativePath->Add(MotionCommandPathType::MoveTo, relativeStartPoints, MotionPathPointsType::Auto, false);
auto relativeOffsets = MakeArray<PointF>({ PointF(0.1f, 0.1f) });
relativePath->Add(MotionCommandPathType::LineTo, relativeOffsets, MotionPathPointsType::Corner, true);
```

هر یک از این مسیرها را به یک رفتار حرکتی اختصاص دهید تا در ارائه استفاده شود. آرگومان بولی نهایی مختصات نسبی آن فرمان را انتخاب می‌کند.

### **جایگزینی یک خط با منحنی**

`motion.pptx` را باز کنید و فرمان خط آن را با یک منحنی مکعبی جایگزین کنید. ابتدا دو نقطهٔ کنترل را و سپس نقطهٔ انتهایی را فراهم کنید.

موقعیت شروع توسط فرمان قبلی داده می‌شود. دو نقطهٔ اول شکل منحنی را می‌سازند، در حالی که سوم مقصد نهایی است؛ این‌ها سه مقصد پی‌در‑پی نیستند. به‌روزرسانی همزمان نوع فرمان، نوع ویرایش نقطه و آرایهٔ نقاط، بخش را با هندسهٔ جدید سازگار نگه می‌دارد.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
path->idx_get(1)->set_CommandType(MotionCommandPathType::CurveTo);
path->idx_get(1)->set_PointsType(MotionPathPointsType::CurveSmooth);
auto curvePoints = MakeArray<PointF>({ PointF(0.1f, 0), PointF(0.2f, 0.1f), PointF(0.3f, 0.1f) });
path->idx_get(1)->set_Points(curvePoints);

presentation->Save(u"curve.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

مسیر در `curve.pptx` هنوز سه فرمان دارد؛ فرمان میانی اکنون یک منحنی تعریف می‌کند.

## **بررسی و ویرایش مسیر ذخیره‌شده**

هر [IMotionCmdPath](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/imotioncmdpath/) [get_Points](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/imotioncmdpath/get_points/)، [get_CommandType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/imotioncmdpath/get_commandtype/)، [get_PointsType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/imotioncmdpath/get_pointstype/) و [get_IsRelative](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/imotioncmdpath/get_isrelative/) را نمایش می‌دهد. مثال‌های زیر از مسیر سه‑فرمان شناخته‌شده در `motion.pptx` استفاده می‌کنند. برای ورودی دلخواه، اثر مورد نظر را پیدا کنید و قبل از ویرایش بر اساس اندیس، انواع فرمان و تعداد نقاط را بررسی کنید.

### **خواندن فرمان‌ها و مختصات**

مسیر را بدون تغییر بخوانید. فرمان‌های End و CloseLoop نیازی به نقاط ندارند، بنابراین باید آرایهٔ نقاط تهی را قبول کنید.

خروجی هر فرمان را همراه با پرچم مختصات نسبی پیش از فهرست نقاط نشان می‌دهد. این امکان را می‌دهد تا قبل از اصلاح مسیر، نقطهٔ انتهایی را از جابجایی تشخیص دهید. یک منحنی سه نقطه فهرست می‌کند، در حالی که خط مستقیم فقط یک نقطه دارد.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
for (auto segment : path)
{
    Console::WriteLine(u"{0}, relative: {1}", segment->get_CommandType(), segment->get_IsRelative());
    if (segment->get_Points() != nullptr)
        for (auto point : segment->get_Points())
            Console::WriteLine(u"X={0}, Y={1}", point.get_X(), point.get_Y());
}

presentation->Dispose();
```

این فهرست شامل نقطهٔ شروع، یک خط مطلق پایان‌یافته در (0.25, 0) و یک فرمان End است.

### **تغییر نقطهٔ انتهایی**

`motion.pptx` را باز کنید و آرایهٔ نقاط خط را برای جابجایی نقطهٔ انتهایی آن تعویض کنید.

در فایل ورودی، اندیس 0 فرمان شروع و اندیس 1 خط است. جایگزینی نقطهٔ تک خط مقصد را بدون تغییر نوع فرمان، زمان‌بندی یا موقعیت آن در مجموعه تغییر می‌دهد. چون فرمان از مختصات مطلق استفاده می‌کند، جفت جدید موقعیتی مطلق را مشخص می‌کند نه جابجایی افزایشی.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));
auto endpointPoints = MakeArray<PointF>({ PointF(0.4f, 0.1f) });
motion->get_Path()->idx_get(1)->set_Points(endpointPoints);

presentation->Save(u"motion-endpoint.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

خط در `motion-endpoint.pptx` در (0.4, 0.1) پایان می‌یابد؛ فایل اصلی تغییر نیافته باقی می‌ماند.

### **جایگزینی یک بخش**

از [Insert](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/imotionpath/insert/) و [RemoveAt](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/imotionpath/removeat/) برای جایگزینی خط در `motion.pptx` استفاده کنید. درج خط جدید، خط قدیمی را به اندیس 2 منتقل می‌کند.

این نشان می‌دهد که چگونه یک شیء فرمان را جایگزین می‌کنیم نه با ویرایش مختصات موجود آن. پس از درج، مجموعه به‌طور موقت شامل فرمان شروع، خط جدید، خط قبلی و فرمان End می‌شود. حذف اندیس 2 خط قبلی را حذف می‌کند و مسیر جدید باقی می‌ماند.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
auto linePoints = MakeArray<PointF>({ PointF(0.2f, 0.1f) });
path->Insert(1, MotionCommandPathType::LineTo, linePoints, MotionPathPointsType::Corner, false);
path->RemoveAt(2);

presentation->Save(u"motion-edited.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

مسیر ذخیره‌شده هنوز سه فرمان دارد؛ خط جدید در (0.2, 0.1) پایان می‌یابد و فرمان End آخرین است.

## **اصلاح و تأیید یک رفتار موجود**

وقتی اندیس رفتار ناشناخته است، با نوع آن انتخاب کنید. این مثال `rotation.pptx` را باز می‌کند، [IRotationEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/irotationeffect/) مربوطه را پیدا می‌کند، زاویه را تغییر می‌دهد و پس از باز کردن مجدد مقدار ذخیره‑شده را بررسی می‌کند.

بررسی نوع اجازه می‌دهد حلقه رفتارهای غیرچرخشی را عبور دهد. بارگذاری دوم فایل ذخیره‌شده را به یک شیء ارائهٔ جداگانه می‌خواند، بنابراین مقایسه داده‌های پایدار را بررسی می‌کند نه مقادیری که هنوز در حافظه هستند. این مثال همچنان فرض می‌کند افکت شناخته‌شده اولین افکت در توالی اصلی است؛ انتخاب رفتار بر اساس نوع، لزوماً افکت صحیح را در یک ارائهٔ دلخواه پیدا نمی‌کند.

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <cmath>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

for (auto behavior : effect->get_Behaviors())
{
    auto rotation = DynamicCast<IRotationEffect>(behavior);
    if (rotation != nullptr)
        rotation->set_By(180.0f);
}

presentation->Save(u"rotation-edited.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"rotation-edited.pptx");
auto savedEffect = reopened->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

for (auto behavior : savedEffect->get_Behaviors())
{
    auto rotation = DynamicCast<IRotationEffect>(behavior);
    if (rotation != nullptr)
        Console::WriteLine(u"Rotation preserved: {0}", std::abs(rotation->get_By() - 180.0f) < 0.001f);
}

presentation->Dispose();
reopened->Dispose();
```

خروجی `Rotation preserved: True` است. الگوی بررسی نوع را برای سایر رفتارها نیز اعمال کنید. برای بررسی کامل حفظ، شکل هدف، افکت، انواع و ترتیب رفتارها، زمان‌بندی و فرمان‌های مسیر را مقایسه کنید. برای مقادیر شناور از تحمل عددی استفاده کنید. برای یک ارائه با ساختار انیمیشن ناشناخته، به [خواندن انیمیشن‌های شکل](/slides/fa/cpp/shape-animation/#read-shape-animations) برای عبور توالی اصلی و تعاملی مراجعه کنید.

## **ترتیب رفتارها، پیش‌تنظیم‌ها و پخش**

ترتیب در [IBehaviorCollection](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ibehaviorcollection/) همان ترتیب ذخیره‌شدهٔ عملیات‌های یک افکت است. این یک پلی‌لیست نیست که هر رفتار به‌صورت خودکار منتظر رفتار قبلی باشد. زمان‌بندی و افکت محاطی زمان‌بندی را تعیین می‌کنند. رفتارها می‌توانند همپوشانی داشته باشند و عملیات روی یک ویژگی ممکن است از طریق [get_Additive](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ibehavior/get_additive/) و [get_Accumulate](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ibehavior/get_accumulate/) با یکدیگر تعامل داشته باشند. فقط با بازچینش مجموعه زمان‌بندی «حرکت، سپس چرخش» را برنامه‌ریزی نکنید؛ از زمان‌بندی صریح یا افکت‌های جداگانه همان‌طور که در [انیمیشن شکل](/slides/fa/cpp/shape-animation/) توضیح داده شده، استفاده کنید.

[ieffect::get_Type](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ieffect/get_type/) و [ieffect::get_Subtype](https://reference.aspose.com/slides/fa/cpp/aspose.slides.animation/ieffect/get_subtype/) پیش‌تنظیم را توصیف می‌کنند. این توصیف کامل درخت رفتارهای ویرایشی نیست. پیش‌تنظیم و زیرنوع را قبل از سفارشی‌سازی رفتارها انتخاب کنید: تغییر پیش‌تنظیم می‌تواند مجموعه را بازسازی کرده و عملیات سفارشی شما را حذف کند. برای مثال، تغییر یک پیش‌تنظیم Spin سفارشی به Fade می‌تواند رفتار چرخش را با رفتارهای set و filter جایگزین کند. پس از تغییر پیش‌تنظیم یا زیرنوع، مجدداً مجموعه را بررسی کنید. پاک‌سازی رفتارهای پیش‌تنظیم می‌تواند عملیات‌های قابل مشاهده یا مقداردهی اولیه‌ای را که پیش‌تنظیم نیاز دارد حذف کند. مثال‌ها به‌صورت عمدی از اشکال قابل مشاهده استفاده می‌کنند و رفتارها را جایگزین می‌نمایند؛ آن‌ها پیاده‌سازی هر پیش‌تنظیم را بازنویسی نمی‌کنند.

## **سازگاری فرمت‌ها**

حفظ درخت رفتار تضمین‌کنندهٔ پخش یکسان در هر نمایشگر یا رندر خروجی نیست. داده‌های ذخیره‌شده و خروجی رندر شده را جداگانه بررسی کنید.

| فرمت یا خروجی | موارد بررسی |
| --- | --- |
| PPTX | به عنوان فرمت اصلی برای این مثال‌ها استفاده شود. پس از باز کردن مجدد درخت رفتارهای ویرایشی را تأیید کنید، سپس پخش را در نسخهٔ PowerPoint مورد نظر بررسی کنید. |
| PPT | نمایش باینری قدیمی می‌تواند با PPTX متفاوت باشد. یک چرخه ذخیره‑بازکردن و پخش جداگانه تست کنید؛ عدم استنتاج پشتیبانی از هر ترکیب سفارشی فقط از خروجی موفق PPTX کافی نیست. |
| PDF, PNG, JPEG و سایر تصاویر اسلاید ایستا | شامل نمای ایستای اسلاید هستند، نه مسیر رفتارهای قابل پخش یا فریم نهایی انیمیشن. |
| [HTML5](/slides/fa/cpp/export-to-html5/) | می‌تواند انیمیشن‌های پشتیبانی‌شده را هنگام فعال‌سازی انیمیشن شکل در گزینه‌های خروجی پخش کند. ترکیب‌های سفارشی را در مرورگر تست کنید. |
| [Animated GIF](/slides/fa/cpp/convert-powerpoint-to-animated-gif/) | فریم‌های رندرشده را ذخیره می‌کند، نه رفتارهای ویرایش‌پذیر یا تعاملات کلیک‑محور. حرکت واقعی رندرشده را بررسی کنید. |
| [Video](/slides/fa/cpp/convert-powerpoint-to-video/) | فریم‌های انیمیشن را رندر و به‌صورت ویدیو کد می‌کند. پشتیبانی به‌صورت [انیمیشن‌ها و افکت‌های پشتیبانی‌شده](/slides/fa/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) محدود است؛ دستورات و رویدادهای تعاملی تبدیل به یک زمان‌بندی ویرایش‌پذیر نمی‌شوند. |

## **پرسش‌های متداول**

**چرا افکت من قبل از افزودن رفتارهایی دارد؟**

ایجاد یک افکت پیش‌تنظیم می‌تواند عملیات‌های زیرین آن را ایجاد کند. پیش از تصمیم برای گسترش پیش‌تنظیم یا جایگزینی رفتارهای آن، آن‌ها را بررسی کنید.

**آیا انتقال یک رفتار به ابتدا باعث می‌شود ابتدا اجرا شود؟**

لزامی نیست. ترتیب مجموعه جایگزین زمان‌بندی نمی‌شود. تاخیرها، مدت زمان‌ها و تعاملات بین عملیات روی یک ویژگی را بررسی کنید.

**چرا یک فرمان End نقاطی ندارد؟**

این فرمان پایان مسیر را نشان می‌دهد و نیازی به مختصات ندارد. هنگام بررسی مسیر خوانده‌شده از فایل، برای آرایهٔ نقطهٔ تهی بررسی کنید.

**آیا یک دور گرد موفق کافی برای تأیید پخش است؟**

نه. باز کردن مجدد فقط حفظ ویژگی‌های بررسی‌شده را تأیید می‌کند. پخش‌کنندهٔ اسلاید یا خروجی انیمیشن‌دار را جداگانه تست کنید تا رفتار بصری آن را تأیید کنید.