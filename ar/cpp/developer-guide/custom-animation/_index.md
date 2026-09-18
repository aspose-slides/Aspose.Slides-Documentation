---
title: إنشاء وتعديل سلوكيات الرسوم المتحركة المخصصة في C++
linktitle: الرسوم المتحركة المخصصة
type: docs
weight: 151
url: /ar/cpp/custom-animation/
keywords:
- رسوم متحركة مخصصة
- سلوك الرسوم المتحركة
- مسار الحركة
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "إنشاء وفحص وتعديل سلوكيات الرسوم المتحركة المخصصة ومسارات الحركة القابلة للتحرير في عروض PowerPoint التقديمية باستخدام Aspose.Slides للغة C++."
---
## **نظرة عامة**

تمنحك سلوكيات الرسوم المتحركة المخصصة القدرة على التحكم في العمليات الفردية داخل تأثير الرسوم المتحركة، مثل تغيير اللون، تدوير الشكل، أو اتباع مسار حركة قابل للتحرير. يوضح هذا الدليل كيفية إنشاء السلوكيات ودمجها، وتكوين توقيتها، وفحص وتعديل الرسوم المتحركة الموجودة، والتحقق من بقاء خصائصها بعد حفظ وإعادة فتح العرض التقديمي.

للتعرف على المؤثرات المعرفة مسبقًا ومفاتيح النقر، راجع [رسوم المتحركة للشكل](/slides/ar/cpp/shape-animation/).

## **فهم نموذج الرسوم المتحركة**

يتم تنظيم الرسوم المتحركة على النحو التالي **Timeline → Sequence → Effect → Behaviors**:

- يحتوي [get_Timeline](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseslide/get_timeline/) على التسلسل الرئيسي والتسلسلات التفاعلية للشفرة.
- يحتوي [ISequence](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/isequence/) على المؤثرات، وقد تستهدف أشكالًا مختلفة.
- يحدد [IEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ieffect/) شكل الهدف، الإعداد المسبق، النوع الفرعي، وتوقيت التأثير.
- يحتوي [IEffect::get_Behaviors](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ieffect/get_behaviors/) على العمليات التي تنفذ التأثير: تغيير اللون، التحريك، التدوير، تعيين خاصية، وما إلى ذلك.

## **إنشاء سلوكيات فردية**

استدعِ [ISequence::AddEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/isequence/addeffect/) لإنشاء تأثير والوصول إلى مجموعة [get_Behaviors](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ieffect/get_behaviors/). يمكن لإعداد مسبق تعبئة هذه المجموعة تلقائيًا. احتفظ بعملياته عند توسيع الإعداد المسبق، أو استخدم [Clear](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ibehaviorcollection/clear/) عند استبداله عمدًا.

[IBehaviorFactory](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ibehaviorfactory/) يُنشئ الأنواع الثمانية للسلوكيات الموضحة أدناه. يُغطي الحركة في [Build a Motion Path](#build-a-motion-path). كل مثال إنشاء هو شفرة مستقلة لتُنفّذ داخل دالة؛ وتحدد أمثلة التحرير اللاحقة ملف الإخراج الذي تُستخدمه.

### **دوران**

استخدم [CreateRotationEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) لإنشاء دوران. يحدّد [get_By](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/irotationeffect/get_by/) زاوية نسبية بالدرجات؛ ويحدّد [get_From](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/irotationeffect/get_from/) و[get_To](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/irotationeffect/get_to/) نقاط النهاية.

يبدأ المثال بتأثير Spin، ويستبدل عملياته المسبقة بسلوك دوران واحد، ويعطي ذلك العملية مدة ثانيتين. زاوية نسبية قدرها 90 درجة تعبر عن ربع دورة من توجّه الشكل الابتدائي، لذا لا يلزم تحديد زاوية ابتدائية صريحة.

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

`rotation.pptx` يحتوي على شكل واحد وسلوك دوران واحد. تُستخدم المجموعة، والتوقيت، وأمثلة تحرير الدوران أدناه هذا الملف.

### **تحجيم**

استخدم [CreateScaleEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) مع نسب X/Y: يصف [get_From](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/iscaleeffect/get_from/) و[get_To](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/iscaleeffect/get_to/) الحجم الابتدائي والنهائي، بينما يصف [get_By](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/iscaleeffect/get_by/) تغييرًا نسبيًا. هنا، 100 يعني الحجم الأصلي.

ينمو المثال كلا البعدين من 100 % إلى 125 % خلال ثانيتين. يضمن استخدام نسب أفقية ورأسية متساوية الحفاظ على نسب الشكل؛ نسب مختلفة ستمتد بُعدًا أكثر من الآخر.

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

### **لون**

استخدم [CreateColorEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) لتغيير التعبئة من الأزرق إلى البرتقالي. [get_From](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/icoloreffect/get_from/) و[get_To](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/icoloreffect/get_to/) هما ألوان؛ و[get_By](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/icoloreffect/get_by/) هو إزاحة لونية. يحدد [IBehavior::get_Properties](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ibehavior/get_properties/) السمة التي تُرسَّم.

تُهيء تعبئة الشكل الصلبة إلى اللون الأزرق، لتطابق لون البداية في الرسوم المتحركة. يحدد اختيار سمة تعبئة اللون السلوك أي جزء من الشكل يُغيّر؛ لا تُحدد نقاط النهاية اللونية السمة بنفسها. يصف التأثير المحفوظ انتقالًا لمدة ثانيتين إلى البرتقالي.

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

### **مرشح**

استخدم [CreateFilterEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) لاختيار مسح. يحدّد [get_Type](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ifiltereffect/get_type/)، و[get_Subtype](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ifiltereffect/get_subtype/)، و[get_Reveal](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ifiltereffect/get_reveal/) الفلتر، الاتجاه، وما إذا كان يُظهر أو يُخفِي الشكل.

يُكوّن هذا المثال مسحًا مدته ثانيتان يُظهر الشكل باستخدام النوع الفرعي للاتجاه إلى اليمين. تنتمي إعدادات الفلتر إلى السلوك داخل التأثير، لذا تُكوّن بعد إزالة عمليات الإعداد المسبق الأصلية.

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

### **خاصية**

استخدم [CreatePropertyEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) لتحريك الشفافية. تُعد [get_From](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ipropertyeffect/get_from/)، و[get_To](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ipropertyeffect/get_to/)، و[get_By](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ipropertyeffect/get_by/) سلاسل تُفسَّر باستخدام [get_ValueType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ipropertyeffect/get_valuetype/) و[get_CalcMode](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ipropertyeffect/get_calcmode/). اختر نقاط النهاية أو إزاحة نسبية بدلاً من تعيين الثلاثة معًا دون تمييز.

في هذا المثال، السمة المختارة هي الشفافية، والسلاسل الرقمية تمثل تغييرًا من شفافية 25 % إلى شفافية كاملة. يصف الاستيفاء الخطي تغيرًا تدريجيًا بين تلك القيم. عند تعديل هذا المثال لسمة أخرى، اختر نوع قيمة وقيم نهائية مناسبة لتلك السمة.

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

### **تعيين**

استخدم [CreateSetEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ibehaviorfactory/createseteffect/) لتعيين الرؤية عبر [get_To](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/iseteffect/get_to/). السلوك “Set” لا يستنتج بين نقاط النهاية.

يختار المثال سمة الرؤية ويُعيّن السلسلة `visible` عند تشغيل السلوك. في ++C، ضع السلسلة داخل كائن قبل تعيينها إلى سلوك التعيين. الشكل المستطيل ظاهر بالفعل في هذا العرض التقديمي البسيط، لذا قد لا يُظهر التعيين تغييرًا مرئيًا واضحًا بنفسه. تُفيد هذه العملية كجزء من تأثير أكبر يتحكم أيضًا بوقت إخفاء أو إظهار الشكل.

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

### **أمر**

استخدم [CreateCommandEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) وقم بتكوين [get_Type](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/icommandeffect/get_type/)، و[get_CommandString](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/icommandeffect/get_commandstring/)، و[get_ShapeTarget](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/icommandeffect/get_shapetarget/). ضع تسجيل صوتي بامتداد WAV باسم `sample.wav` في دليل العمل. يدمج هذا المثال التسجيل باستخدام [AddAudioFrameEmbedded](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) ويربط أمر تشغيل بالإطار الصوتي.

الإطار الصوتي هو كلّ من هدف التأثير وهدف الأمر. يربط هذا طلب التشغيل بالتسجيل المضمّن؛ فالسلسلة الخاصة بالأمر لا تحدد كائن الوسائط الذي يتحكم فيه. يُكوّن التأثير للبدء عند النقر خلال عرض الشرائح.

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

يُحفظ الأمر في `command.pptx`؛ لا يُشغل التسجيل. يتطلّب التشغيل مشغِّل عرض شرائح يدعم الأمر وهدف الوسائط الخاص به.

## **إدارة مجموعة السلوكيات**

[IBehaviorCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ibehaviorcollection/) يدعم [Add](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ibehaviorcollection/add/)، و[Insert](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ibehaviorcollection/insert/)، و[Remove](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ibehaviorcollection/remove/)، و[RemoveAt](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ibehaviorcollection/removeat/). يفتح هذا المثال `rotation.pptx`، يضيف تحجيمًا، ينقله أمام الدوران، ثم يزيل الدوران. يغيّر الإزالة وإعادة الإدراج لنفس الكائن موضعه المخزن دون عمل نسخة.

تغيّر سلسلة التعديلات المجموعة من دورة–تحجيم إلى تحجيم–دورة، ثم إلى تحجيم فقط. تشير الفهارس إلى المجموعة الحالية، لذا يستخدم الإزالة الفهرس الجديد للدوران بعد إعادة الترتيب. تؤكد العدّة النهائية أي سلوك سيُحفظ.

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

الناتج هو `ScaleEffect`: يبقى التحجيم فقط. لا يُحدِّد ترتيب المجموعة بحد ذاته جدولة السلوكيات واحدةً تلو الأخرى. نظِّف المجموعة فقط عند استبدال جميع عملياتها.

## **تكوين توقيت السلوك**

[IBehavior::get_Timing](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ibehavior/get_timing/) يوفّر [ITiming](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/itiming/)، بشكل مستقل عن [IEffect::get_Timing](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ieffect/get_timing/). يحدد توقيت التأثير الجدولة للتأثير المُحيط؛ يصف توقيت السلوك عملية داخله.

### **تعيين المدة، التأخير، التكرار، والتسارع**

افتح `rotation.pptx` واضبط [get_Duration](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/itiming/get_duration/) و[get_TriggerDelayTime](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/itiming/get_triggerdelaytime/) بالثواني، ثم كوّن [get_RepeatCount](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/itiming/get_repeatcount/). [get_Accelerate](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/itiming/get_accelerate/) و[get_Decelerate](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/itiming/get_decelerate/) هما كسور من المدة؛ احفظ مجموعهما لا يتجاوز 1.

الملف الإدخالي هو الملف الذي تم إنشاؤه في مثال الدوران، حيث يُعرف أول سلوك بأنه دوران. يغيّر هذا المثال توقيت ذلك السلوك فقط؛ تبقى زاوية 90 درجة دون تعديل. يُسهِّل الفصل بين الزاوية والتوقيت تعديل السرعة دون إعادة بناء الرسوم المتحركة.

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

يستخدم السلوك مدة ثانيتين، وتأخير نصف ثانية، وعدد تكرارات 3. تُستَخدم الـ20 % الأولى والأخيرة من المدة للتسارع والتباطؤ.

تشمل سياسات التكرار الأخرى [get_RepeatDuration](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/itiming/get_repeatduration/)، و[get_RepeatUntilEndSlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/itiming/get_repeatuntilendslide/)، و[get_RepeatUntilNextClick](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/itiming/get_repeatuntilnextclick/); اختر سياسةً بدلاً من تمكينها جميعًا معًا. يُعيد [get_AutoReverse](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/itiming/get_autoreverse/) تشغيل الرسوم المتحركة بالعكس بعد المرور الأمامي. يطبق التسارع والتباطؤ على التغييرات المستمرة، وليس على التعيينات المتقطعة أو الأوامر.

## **إنشاء مسار حركة**

استخدم [CreateMotionEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) لإنشاء حركة. يصف [get_From](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/imotioneffect/get_from/)، و[get_To](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/imotioneffect/get_to/)، و[get_By](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/imotioneffect/get_by/) إحداثيات أو إزاحات نسبية. لإنشاء مسار قابل للتحرير، أنشئ [MotionPath](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/motionpath/) وعيّنها إلى [IMotionEffect::get_Path](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/imotioneffect/get_path/). يخزن [IMotionPath](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/imotionpath/) أوامر المسار.

[MotionCommandPathType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/motioncommandpathtype/) يحدّد العملية:

| الأمر | النقاط | المعنى |
| --- | --- | --- |
| MoveTo | واحدة | تعيين الموضع الابتدائي. |
| LineTo | واحدة | التحرك على قطعة مستقيمة إلى نقطة النهاية. |
| CurveTo | ثلاث | اتباع منحنى تكعيبي يُحدَّد بنقطتي تحكم ونقطة النهاية. |
| CloseLoop | لا شيء | العودة إلى الموضع الابتدائي. |
| End | لا شيء | إنهاء المسار. |

[MotionPathPointsType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/motionpathpointstype/) يصف خصائص تحرير النقاط، مثل الزوايا أو النقاط الملساء. لا يحلّ محل نوع الأمر. استخدم نوع نقطة المنحنى للمثال المنحني أدناه، واستخدم نوع نقطة الزاوية للقطعات المستقيمة.

إحداثيات المسار مُعَدَّلة إلى أبعاد الشريحة: إزاحة X مقدارها 0.25 تمثل ربع عرض الشريحة، وليس 0.25 نقطة. Y الموجبة تمتد إلى الأسفل. الأوامر المطلقة تحدد المواضع في نظام إحداثيات المسار؛ الأوامر النسبية تحدد إزاحات من الموضع الحالي. هذا منفصل عن [get_Origin](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/imotioneffect/get_origin/)، الذي يختار إطار مرجعي للمسار، و[get_PathEditMode](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/imotioneffect/get_patheditmode/)، الذي يتحكم في طريقة تحرك المسار عندما يتحرك الشكل.

### **إنشاء مسار مستقيم**

أنشئ سلوك حركة بنقطة بداية، قطعة مستقيمة واحدة، وأمر النهاية. يأخذ [IMotionPath::Add](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/imotionpath/add/) نوع الأمر، نقاطه، نوع النقطة، وعلم إحداثيات نسبية.

يحدّد الأمر الابتدائي (0, 0)، وتنتهي الخط إلى (0.25, 0)، مما يضيف إزاحة أفقية قدرها ربع عرض الشريحة. لا يحتوي أمر النهاية على إحداثيات. بمجرد تعيين المسار، يضيف سلوك الحركة إلى التأثير ليصل هذا المسار بالمستطيل.

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

`motion.pptx` يحتوي على سلوك حركة واحد مع ثلاث أوامر مسار. تستخدم أمثلة تحرير الملفات التالية هذا الهيكل المعروف.

### **مقارنة الإحداثيات المطلقة والنسبية**

هذان الكائنان يصفان نفس المسار. ينتهي الأمر المطلق عند (0.3, 0.1)؛ يضيف الأمر النسبي (0.1, 0.1) إلى الموضع الحالي، (0.2, 0).

يبدأ كلا المسارين من نفس الموضع. للخط النسبي، أضف إزاحات X وY إلى الموضع الحالي للحصول على نقطة النهاية؛ بالنسبة للخط المطلق، اقرأ نقطة النهاية مباشرة. سيؤدي تبديل العلم دون تحويل الإحداثيات إلى مسار مختلف.

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

عيّن أي من المسارين إلى سلوك حركة لاستخدامه في عرض تقديمي. يختار الوسيط المنطقي الأخير الإحداثيات النسبية لهذا الأمر.

### **استبدال خط بمنحنى**

افتح `motion.pptx` واستبدل أمر الخط بمنحنى تكعيبي. قدم نقطتي التحكم أولًا، ثم نقطة النهاية.

الموضع الابتدائي يُقدَّم بالأمر السابق. تشكِّل النقطتان الأوليتان المنحنى، بينما النقطة الثالثة هي وجهتها؛ ليست ثلاث وجهات متتابعة. يضمن تحديث نوع الأمر، ونوع تحرير النقاط، ومصفوفة النقاط معًا اتساق القطعة مع هندستها الجديدة.

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

ما يزال المسار في `curve.pptx` يحتوي على ثلاث أوامر؛ الآن يعرّف الأمر الأوسط منحنى.

## **فحص وتحرير مسار محفوظ**

كل [IMotionCmdPath](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/imotioncmdpath/) يوفّر [get_Points](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/imotioncmdpath/get_points/)، و[get_CommandType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/imotioncmdpath/get_commandtype/)، و[get_PointsType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/imotioncmdpath/get_pointstype/)، و[get_IsRelative](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/imotioncmdpath/get_isrelative/). تستخدم الأمثلة التالية المسار المعروف من ثلاث أوامر في `motion.pptx`. للمدخلات العشوائية، حدِّد التأثير المقصود وتحقق من أنواع الأوامر وعدد النقاط قبل التحرير حسب الفهرس.

### **قراءة الأوامر والإحداثيات**

اقرأ المسار دون تغييره. لا تحتاج أوامر النهاية وإغلاق الحلقة إلى نقاط، لذا اسمح بمصفوفة نقاط فارغة.

يعرض الناتج كل أمر مع علم إحداثياته النسبية قبل سرد نقاطه. يتيح لك هذا التمييز بين نقطة النهاية وإزاحة قبل تعديل المسار. سيسرد منحنى ثلاث نقاط، بينما سيسرد الخط المستقيم في هذا الملف نقطة واحدة فقط.

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

القائمة تحتوي على نقطة بداية، وخط مطلق ينتهي عند (0.25, 0)، وأمر النهاية.

### **تغيير نقطة النهاية**

افتح `motion.pptx` واستبدل مصفوفة نقاط الخط لتحريك نقطة النهاية.

في الملف الإدخالي، الفهرس 0 هو الأمر الابتدائي والفهرس 1 هو الخط. يغيّر استبدال نقطة الخط الواحدة وجهتها دون تغيير نوع الأمر أو توقيته أو موضعه في المجموعة. بما أن الأمر يستخدم إحداثيات مطلقة، فإن الزوج الجديد يحدِّد موضعًا وليس إزاحة مضافة.

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

ينتهي الخط في `motion-endpoint.pptx` عند (0.4, 0.1)؛ يبقى الملف الأصلي دون تغيير.

### **استبدال قطعة**

استخدم [Insert](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/imotionpath/insert/) و[RemoveAt](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/imotionpath/removeat/) لاستبدال الخط في `motion.pptx`. يؤدي الإدراج إلى إزاحة الخط القديم إلى الفهرس 2.

يُظهر هذا استبدال كائن أمر بدلاً من تحرير إحداثياته الحالية. بعد الإدراج، تحتوي المجموعة مؤقتًا على الأمر الابتدائي، الخط الجديد، الخط القديم، وأمر النهاية. يزيل الإزالة عند الفهرس 2 الخط القديم، ويترك المسار الجديد في مكانه.

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

ما يزال المسار المحفوظ يحتوي على ثلاث أوامر، حيث ينتهي الخط الجديد عند (0.2, 0.1) وأمر النهاية يكون الأخير.

## **تعديل والتحقق من سلوك موجود**

عندما يكون فهرس السلوك غير معروف، حدده حسب النوع. يفتح هذا المثال `rotation.pptx`، يجد [IRotationEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/irotationeffect/)، يغيّر الزاوية، ويتحقق من القيمة المحفوظة بعد إعادة الفتح.

يتيح فحص النوع تخطي السلوكيات غير الدوارة. يقرأ التحميل الثاني الملف المحفوظ إلى كائن عرض تقديمي منفصل، لذا تتحقق المقارنة من البيانات المستمرة وليس من القيمة التي لا تزال في الذاكرة. لا يزال هذا المثال يفترض أن التأثير المعروف هو الأول في التسلسل الرئيسي؛ لا يضمن اختيار سلوك حسب النوع تحديد التأثير الصحيح في عرض تقديمي عشوائي.

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

الناتج هو `Rotation preserved: True`. طبّق نمط فحص النوع نفسه على سلوكيات أخرى. لإجراء فحص حفظ كامل، قارن الشكل المستهدف، التأثير، أنواع السلوكيات وترتيبها، التوقيت، وأوامر المسار. استخدم تسامحًا عدديًا للقيم العائمة. بالنسبة لعرض تقديمي ذو تخطيط رسوم متحركة غير معروف، راجع [Read Shape Animations](/slides/ar/cpp/shape-animation/#read-shape-animations) لتصفح التسلسلات الرئيسية والتفاعلية.

## **ترتيب السلوكيات، الإعدادات المسبقة، والتشغيل**

الترتيب في [IBehaviorCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ibehaviorcollection/) هو ترتيب التخزين لعمليات التأثير. ليس قائمة تشغيل تُجبر كل سلوك على الانتظار تلقائيًا للسلوك السابق. يحدّد التوقيت والتأثير المُحيط الجدولة. يمكن أن تتراكب السلوكيات، وقد تتفاعل العمليات على نفس الخاصية عبر [get_Additive](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ibehavior/get_additive/) و[get_Accumulate](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ibehavior/get_accumulate/). لا تستخدم إعادة ترتيب المجموعة وحدها لجدولة “تحريك، ثم تدوير”؛ استخدم توقيتًا صريحًا أو مؤثرات منفصلة كما هو موضح في [رسوم المتحركة للشكل](/slides/ar/cpp/shape-animation/).

يصف [get_Type](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ieffect/get_type/) و[get_Subtype](https://reference.aspose.com/slides/ar/cpp/aspose.slides.animation/ieffect/get_subtype/) للتأثير الإعداد المسبق. لا يشكلان وصفًا كاملًا لشجرة سلوكيات مُعدَّلة. اختر الإعداد المسبق والنوع الفرعي قبل تخصيص السلوكيات: قد يُعيد تغيير الإعداد المسبق بناء المجموعة ويتسبب في فقدان عملياتك المخصَّصة. على سبيل المثال، تحويل تأثير Spin مخصص إلى Fade قد يستبدل سلوك الدوران بسلوكيات تعيين ومرشح. افحص المجموعة مرة أخرى بعد تغيير الإعداد المسبق أو النوع الفرعي. قد يؤدي مسح سلوكيات الإعداد المسبق أيضًا إلى إزالة عمليات الرؤية أو التهيئة التي يحتاجها الإعداد المسبق. تستخدم الأمثلة أشكالًا مرئية وتستبدل السلوكيات؛ لا تعيد بناء تنفيذ كل إعداد مسبق.

## **توافق الصيغ**

شجرة سلوكيات محفوظة لا تضمن تشغيلًا متماثلاً في كل عارض أو مُصدِّر. تحقق من البيانات المحفوظة والمخرجات المرسومة بشكل منفصل.

| الصيغة أو المخرجات | ما يجب التحقق منه |
| --- | --- |
| PPTX | استخدمها كالصيغة الأساسية لهذه الأمثلة. أعد فتحها للتحقق من شجرة السلوكيات القابلة للتحرير، ثم اختبر التشغيل في نسخة PowerPoint المقصودة. |
| PPT | قد يختلف التمثيل الثنائي القديم عن PPTX. جرّب دورة حفظ‑إعادة‑فتح منفصلة واختبر التشغيل؛ لا تستنتج دعم كل مجموعة مخصصة من نجاح مخرجات PPTX. |
| PDF, PNG, JPEG, وغيرها من صور الشرائح الثابتة | تحتوي على تمثيل ثابت للشرائح، ولا تشمل خط زمني قابل للتشغيل أو إطارًا نهائيًا مضمونًا للرسوم المتحركة. |
| [HTML5](/slides/ar/cpp/export-to-html5/) | يمكنه تشغيل الرسوم المتحركة المدعومة عندما تُفعَّل رسوم المتحركة للأشكال في خيارات التصدير. اختبر المجموعات المخصَّصة في المتصفح. |
| [Animated GIF](/slides/ar/cpp/convert-powerpoint-to-animated-gif/) | يخزن إطارات مرسومة، لا سلوكيات قابلة للتحرير أو تفاعلات نقر. افحص الحركة المرسومة فعليًا. |
| [Video](/slides/ar/cpp/convert-powerpoint-to-video/) | يرسم إطارات الرسوم المتحركة ويشفّرها كفيديو. يدعم ذلك فقط الرسوم المتحركة والمؤثرات المتوافقة مع المُصدِّر؛ لا تتحول الأوامر والأحداث التفاعلية إلى خط زمني قابل للتحرير. |

## **الأسئلة المتكررة**

**لماذا يحتوي تأثيري على سلوكيات قبل أن أضيف أي شيء؟**

يمكن لإنشاء تأثير معرف مسبقًا إنشاء عملياته الأساسية. افحصها قبل اتخاذ قرار بتوسيع الإعداد المسبق أو استبدال سلوكياته.

**هل نقل سلوك إلى البداية يجعله يُشغل أولًا؟**

ليس بالضرورة. ترتيب المجموعة ليس بديلاً للتوقيت. تحقّق من التأخيرات، والمدة، والتفاعلات بين العمليات على نفس الخاصية.

**لماذا لا يحتوي أمر النهاية على نقاط؟**

يحدّد ذلك نهاية المسار ولا يحتاج إلى إحداثيات. تحقق من مصفوفة نقاط فارغة عند فحص مسار مقروء من ملف.

**هل جولة حفظ وإعادة فتح ناجحة كافية لتأكيد التشغيل؟**

لا. يثبت إعادة الفتح حفظ الخصائص التي فحصتها. اختبر مشغّل عرض الشرائح أو تصدير الرسوم المتحركة منفصلًا لتأكيد سلوكه البصري.