---
title: تطبيق تأثيرات الشكل في العروض التقديمية باستخدام C++
linktitle: تأثير الشكل
type: docs
weight: 30
url: /ar/cpp/shape-effect/
keywords:
- تأثير الشكل
- تأثير الظل
- تأثير الانعكاس
- تأثير التوهج
- تأثير الحواف الناعمة
- تنسيق التأثير
- PowerPoint
- العرض التقديمي
- C++
- Aspose.Slides
description: "حوّل ملفات PPT و PPTX الخاصة بك باستخدام تأثيرات الشكل المتقدمة عبر Aspose.Slides لـ C++ — أنشئ شرائح جذابة واحترافية خلال ثوانٍ."
---
## **المقدمة**

في حين يمكن استخدام التأثيرات في PowerPoint لجعل الشكل يبرز، فإنها تختلف عن [الملء](/slides/ar/cpp/shape-formatting/#gradient-fill) أو الحدود. باستخدام تأثيرات PowerPoint، يمكنك إنشاء انعكاسات مقنعة على الشكل، أو نشر توهج الشكل، وما إلى ذلك.

![تأثير الشكل](shape-effect.png)

يوفر PowerPoint ستة تأثيرات يمكن تطبيقها على الأشكال. يمكنك تطبيق تأثير واحد أو أكثر على الشكل.

بعض تركيبات التأثيرات تبدو أفضل من غيرها. لهذا السبب، يحتوي PowerPoint على خيارات تحت **Preset**. خيارات Preset هي في الأساس تركيبة من اثنين أو أكثر من التأثيرات المعروفة بأنها تبدو جيدة معًا. بهذه الطريقة، باختيار إعداد مسبق، لن تحتاج إلى إضاعة الوقت في اختبار أو دمج تأثيرات مختلفة للعثور على تركيبة مناسبة.

توفر Aspose.Slides خصائص وأساليب تحت فئة [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/) التي تتيح لك تطبيق نفس التأثيرات على الأشكال في عروض PowerPoint التقديمية.

## **تطبيق تأثير الظل**

يدعم Aspose.Slides لـ C++ الظلال الخارجية والداخلية للأشكال. يمكنك تخصيص لونها، اتجاهها، مسافتها، ونصف قطر الضبابية لتتناسب مع تصميم عرضك.

### **تطبيق ظل خارجي**

استخدم الظل الخارجي لجعل بطاقة أو لوحة تبرز مقابل خلفية الشريحة. يمتد الظل خارج حدود الشكل، مما يخلق انطباعًا بأن الشكل مرتفع فوق الشريحة. قم بتعديل لونه، واتجاهه، ومسافته، ونصف قطر الضبابية ليتناسب مع الإضاءة وتنسيق القالب الخاص بك.

يوضح هذا الكود C++ كيفية تطبيق [تأثير الظل الخارجي](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) على مستطيل:

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();
auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_DarkGray());
outerShadowEffect->set_Distance(10);
outerShadowEffect->set_Direction(45.0f);

presentation->Save(u"shadow_effect.pptx", SaveFormat::Pptx);
```

![تأثير الظل](shadow_effect.png)

### **تطبيق ظل داخلي**

عند إعادة إنتاج النمط البصري للقالب، استخدم ظلًا داخليًا لإعطاء بطاقة أو لوحة مظهرًا غائرًا. الظل الخارجي يمتد خارج الشكل ويجعله يبدو مرتفعًا، بينما الظل الداخلي يظلل داخل حوافه.

استدعِ [EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/)، ثم قم بتكوين [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/). قيم نصف قطر الضبابية الأكبر تنتج حوافًا أنعم.

إن المثال C++ هذا ينشئ بطاقة زرقاء فاتحة ذات ظل داخلي رمادي داكن ويحفظها كملف PPTX:

```cpp
#include <DOM/Effects/IInnerShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/FillType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_LightBlue());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

shape->get_EffectFormat()->EnableInnerShadowEffect();
auto shadow = shape->get_EffectFormat()->get_InnerShadowEffect();
shadow->get_ShadowColor()->set_Color(Color::get_DimGray());
shadow->set_Direction(225);
shadow->set_Distance(7);
shadow->set_BlurRadius(6);

presentation->Save(u"inner_shadow_effect.pptx", SaveFormat::Pptx);
```

![مستطيل أزرق فاتح مع ظل داخلي](inner_shadow_effect.png)

لإزالة الظل الداخلي، استدعِ [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) على تنسيق تأثير الشكل.

## **تطبيق تأثير الانعكاس**

لتطبيق تأثير الانعكاس في Aspose.Slides لـ C++، يمكنك إضافة انعكاس شبيه بالمرآة إلى الأشكال، مع تعديل معلمات مثل المسافة والشفافية والحجم. هذا التأثير يعزز جمالية عروضك من خلال إعطاء الأشكال مظهرًا أكثر صقلًا وتطورًا. من السهل تنفيذه باستخدام كود بسيط، مما يتيح تطبيقًا سريعًا عبر عدة عناصر لتصميم متسق.

يوضح هذا الكود C++ كيفية تطبيق [تأثير الانعكاس](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/) على شكل:

```cpp
#include <DOM/Effects/IReflection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableReflectionEffect();
auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_RectangleAlign(RectangleAlignment::Bottom);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_Distance(40);
reflectionEffect->set_BlurRadius(2);

presentation->Save(u"reflection_effect.pptx", SaveFormat::Pptx);
```

![تأثير الانعكاس](reflection_effect.png)

## **تطبيق تأثير التوهج**

لتطبيق تأثير التوهج على شكل في Aspose.Slides لـ C++، يمكنك إضافة هالة ناعمة ومضيئة حول الأشكال، مع تعديل خصائص مثل اللون والحجم. هذا التأثير يساعد على إبراز الأشكال ويضيف عنصرًا بصريًا جذابًا ولافتًا للانتباه إلى عرضك. من السهل تنفيذه بقليل من الكود، مما يعزز المظهر العام لشرائحك.

يوضح هذا الكود C++ كيفية تطبيق [تأثير التوهج](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/) على شكل:

```cpp
#include <DOM/Effects/IGlow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableGlowEffect();
auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_Color(Color::get_Magenta());
glowEffect->set_Radius(15);

presentation->Save(u"glow_effect.pptx", SaveFormat::Pptx);
```

![تأثير التوهج](glow_effect.png)

## **تطبيق تأثير الحواف الناعمة**

لتطبيق تأثير الحواف الناعمة في Aspose.Slides لـ C++، يمكنك إنشاء انتقال سلس ومضبب حول حواف الشكل. يضيف هذا التأثير مظهرًا أكثر دقة ورقيًا، وهو مثالي للتصاميم التي تحتاج إلى مظهر ناعم وهادئ. يمكنك بسهولة تعديل معلمات مثل نصف القطر لتحقيق التأثير المطلوب عبر أشكال مختلفة في عرضك.

يوضح هذا الكود C++ كيفية تطبيق [الحواف الناعمة](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/) على شكل:

```cpp
#include <DOM/Effects/ISoftEdge.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableSoftEdgeEffect();
auto softEdgeEffect = effectFormat->get_SoftEdgeEffect();
softEdgeEffect->set_Radius(8);

presentation->Save(u"soft_edges_effect.pptx", SaveFormat::Pptx);
```

![تأثير الحواف الناعمة](soft_edges_effect.png)

## **تطبيق تأثير الضبابية**

استخدم ضبابية الشكل لتليين تعبئة الشكل وحدوده مع الحفاظ على إمكانية تحرير الشكل. استدعِ [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) على تنسيق تأثير الشكل. يُقاس نصف القطر بوحدات النقاط (1/72 بوصة): استخدم قيمة غير سالبة، حيث القيم الأكبر تنتج ضبابية أقوى. نصف القطر صفر يترك المظهر كما هو.

تتحكم إعدادات [Grow](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/get_grow/) في الحدود الظاهرة للتأثير. عند `false`، يتم اقتصاص الضبابية إلى الحدود المرسومة الأصلية، بما في ذلك الحدود. عند `true`، يمكن للضبابية أن تمتد خارج تلك الحدود. لا يؤدي أي من الإعدادين إلى تغيير موقع الشكل أو أبعاده.

المقارنة أدناه تستخدم نفس التعبئة والحدود وأبعاد الشكل طوال الوقت. الصف العلوي يستخدم `grow = false`؛ الصف السفلي يستخدم `grow = true`.

![مستطيل أصلي مقارنة مع نصف قطر ضبابية 5 و15 نقطة، مع تعطيل وتمكين Grow](shape_blur_comparison.png)

ينشئ المثال C++ هذا مستطيلًا برتقاليًا بحدود زرقاء داكنة، يطبق ضبابية بقيمة 5 نقاط، ثم يحدّثها إلى ضبابية 15 نقطة عن طريق استدعاء [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) مرة أخرى. يحفظ كلا الحالتين الضبابيتين، ثم يستدعي [DisableBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disableblureffect/) ويحفظ الشكل بدون ضبابية.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/FillType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 80.0f, 160.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
shape->get_LineFormat()->set_Width(8);

shape->get_EffectFormat()->SetBlurEffect(5, false);
presentation->Save(u"shape_blur_5.pptx", SaveFormat::Pptx);

shape->get_EffectFormat()->SetBlurEffect(15, true);
presentation->Save(u"shape_blur_15.pptx", SaveFormat::Pptx);

shape->get_EffectFormat()->DisableBlurEffect();
presentation->Save(u"shape_blur_removed.pptx", SaveFormat::Pptx);
```

تؤثر ضبابية الشكل على التعبئة والحدود معًا. تأثير الحواف الناعمة يخفّف حواف الشكل، بينما ضبابية الظل تُليّن الظل فقط. تؤثر تأثيرات تحويل الصورة على محتوى الصورة؛ هذا المثال يطبق الضبابية مباشرة على تنسيق تأثير الشكل دون تحويل الشكل إلى صورة.

## **الأسئلة الشائعة**

**هل يمكنني تطبيق تأثيرات متعددة على نفس الشكل؟**

نعم، يمكنك دمج تأثيرات مختلفة، مثل الظل والانعكاس والتوهج، على شكل واحد لإنشاء مظهر أكثر ديناميكية.

**ما الأشكال التي يمكنني تطبيق التأثيرات عليها؟**

يمكنك تطبيق التأثيرات على أشكال مختلفة، بما في ذلك الأشكال التلقائية، المخططات، الجداول، الصور، كائنات SmartArt، كائنات OLE، وغيرها.

**هل يمكنني تطبيق التأثيرات على الأشكال المجمعة؟**

نعم، يمكنك تطبيق التأثيرات على الأشكال المجمعة. سيُطبق التأثير على المجموعة بأكملها.