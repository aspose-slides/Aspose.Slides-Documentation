---
title: "اعمال افکت‌های شکل در ارائه‌ها با استفاده از C++"
linktitle: "افکت شکل"
type: docs
weight: 30
url: /fa/cpp/shape-effect/
keywords:
- "اثر شکل"
- "اثر سایه"
- "اثر انعکاس"
- "اثر تابش"
- "اثر لبه‌های نرم"
- "قالب اثر"
- "PowerPoint"
- "ارائه"
- "C++"
- "Aspose.Slides"
description: "فایل‌های PPT و PPTX خود را با استفاده از افکت‌های پیشرفته شکل در Aspose.Slides برای C++ تبدیل کنید — اسلایدهای چشم‌نواز و حرفه‌ای را در ثانیه‌ها ایجاد کنید."
---
## **مقدمه**

در حالی که افکت‌ها در PowerPoint می‌توانند برای برجسته کردن یک شکل استفاده شوند، آن‌ها با [پرکننده‌ها](/slides/fa/cpp/shape-formatting/#gradient-fill) یا خطوط پیرامون متفاوت هستند. با استفاده از افکت‌های PowerPoint می‌توانید انعکاس‌های قانع‌کننده بر روی یک شکل ایجاد کنید، نوردهی شکل را گسترش دهید و غیره.

![اثر شکل](shape-effect.png)

PowerPoint شش افکت فراهم می‌کند که می‌توان به اشکال اعمال کرد. می‌توانید یک یا چند افکت بر یک شکل اعمال کنید.

برخی ترکیب‌های افکت بهتر از دیگران به نظر می‌رسند. به همین دلیل، PowerPoint گزینه‌هایی تحت **Preset** دارد. گزینه‌های Preset در واقع ترکیبی از دو یا چند افکت هستند که به خوبی با هم ترکیب می‌شوند. به این ترتیب، با انتخاب یک پیش‌تنظیم، نیازی به صرف زمان برای آزمایش یا ترکیب افکت‌های مختلف برای پیدا کردن ترکیب مناسب نخواهید داشت.

Aspose.Slides ویژگی‌ها و متدهایی تحت کلاس [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/) ارائه می‌دهد که به شما امکان می‌دهد همان افکت‌ها را بر اشکال در ارائه‌های PowerPoint اعمال کنید.

## **اعمال افکت سایه**

Aspose.Slides برای C++ از سایه‌های بیرونی و داخلی برای اشکال پشتیبانی می‌کند. می‌توانید رنگ، جهت، فاصله و شعاع تاری آن‌ها را مطابق با طراحی ارائه خود تنظیم کنید.

### **اعمال سایه بیرونی**

از سایه بیرونی برای برجسته کردن یک کارت یا پنل در مقابل پس‌زمینه اسلاید استفاده کنید. سایه خارج از لبه‌های شکل امتداد می‌یابد و این impression را می‌دهد که شکل از اسلاید برآمده است. رنگ، جهت، فاصله و شعاع تاری آن را مطابق با نورپردازی و سبک قالب خود تنظیم کنید.

این کد C++ نشان می‌دهد چگونه می‌توان [اثر سایه بیرونی](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) را بر روی یک مستطیل اعمال کرد:

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

![اثر سایه](shadow_effect.png)

#### **کنترل جهت سایه هنگام چرخش یک شکل**

به‌طور پیش‌فرض، یک سایه بیرونی همراه با شکل خود می‌چرخد. برای اینکه اشکالی با چرخش‌های مختلف به‌نظر برسند که نور از همان جهت می‌آید، متد [set_RotateShadowWithShape](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ioutershadow/set_rotateshadowwithshape/) را با مقدار `false` صدا بزنید و از [set_Direction](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ioutershadow/set_direction/) برای دادن همان زاویه به سایه‌ها استفاده کنید.

مثال دو فلش با سایه‌های خاکستری که به سمت راست (۰°) جابه‌جا شده‌اند، ایجاد می‌کند. سپس اسلاید را کپی می‌کند و هر دو فلش را ۹۰ درجه ساعت‌گرد می‌چرخاند.

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto before = presentation->get_Slide(0);

auto left = before->get_Shapes()->AddAutoShape(ShapeType::RightArrow, 55, 130, 110, 60);
left->get_FillFormat()->set_FillType(FillType::Solid);
left->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());
left->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

left->get_EffectFormat()->EnableOuterShadowEffect();
auto shadow = left->get_EffectFormat()->get_OuterShadowEffect();
shadow->get_ShadowColor()->set_Color(Color::get_Gray());
shadow->set_Direction(0);
shadow->set_Distance(42);
shadow->set_BlurRadius(0);
shadow->set_RotateShadowWithShape(true);

auto right = before->get_Shapes()->AddClone(left);
right->set_X(395);
right->get_EffectFormat()->get_OuterShadowEffect()->set_RotateShadowWithShape(false);

auto after = presentation->get_Slides()->AddClone(before);
for (auto i = 0; i < after->get_Shapes()->get_Count(); ++i)
{
    after->get_Shape(i)->set_Rotation(90);
}

presentation->Save(u"arrow_shadows.pptx", SaveFormat::Pptx);
```

در اسلاید دوم، فلش چپ سایه خود را به سمت پایین می‌اندازد، در حالی که فلش راست همچنان سایه خود را به سمت راست می‌اندازد. جهت پیکربندی شده برای هر دو سایه ۰° باقی می‌ماند.

![رندر PowerPoint قبل و بعد از چرخش ۹۰°. هر دو سایه ابتدا در سمت راست بودند. پس از چرخش، سایه زیر فلش چپ جابه‌جا شد و در سمت راست فلش راست ماند.](arrow-shadow-rotation.png)

### **اعمال سایه داخلی**

هنگام بازآفرینی سبک بصری یک قالب، از سایه داخلی برای ایجاد ظاهر فرو رفتگی در کارت یا پنل استفاده کنید. یک سایه بیرونی خارج از شکل امتداد می‌یابد و آن را برجسته نشان می‌دهد، در حالی که یک سایه داخلی داخل حاشیه‌های شکل را رنگ می‌کند.

متد [EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/) را صدا بزنید، سپس [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/) را پیکربندی کنید. مقادیر بزرگ‌تر شعاع تاری لبه‌های نرم‌تری تولید می‌کند.

این مثال C++ یک کارت آبی روشن با سایه داخلی خاکستری تیره ایجاد می‌کند و آن را به‌صورت فایل PPTX ذخیره می‌نماید:

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

![مستطیل آبی روشن با سایه داخلی](inner_shadow_effect.png)

برای حذف سایه داخلی، متد [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) را بر فرمت افکت شکل صدا بزنید.

### **اعمال، تغییر و حذف سایه پیش‌تنظیم شده**

متد [EnablePresetShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/enablepresetshadoweffect/) را صدا بزنید و از [set_Preset](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ipresetshadow/set_preset/) برای انتخاب یک [PresetShadowType](https://reference.aspose.com/slides/cpp/aspose.slides/presetshadowtype/) استفاده کنید. برای تغییر سبک، پیش‌تنظیم را بر همان شکل تغییر دهید. متد [DisablePresetShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disablepresetshadoweffect/) سایه را حذف می‌کند در حالی که پرکننده و خط پیرامون حفظ می‌شوند.

این مثال یک کپی از مستطیل را در هر مرحله نگه می‌دارد. هر دو سایه ۱۰ پوینت جابه‌جا شده‌اند. جهت ۲۲۵° سایه اول را بالای چپ مستطیل قرار می‌دهد و ۴۵° سایه دوم را پایین راست.

```cpp
#include <DOM/Effects/IPresetShadow.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/PresetShadowType.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/enum.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(800, 120, SlideSizeScaleType::DoNotScale);
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 15, 30, 170, 60);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());
auto outline = shape->get_LineFormat()->get_FillFormat();
outline->set_FillType(FillType::Solid);
outline->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
auto textFrame = shape->get_TextFrame();
textFrame->set_Text(u"No shadow");
textFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(14);
shapes->AddClone(shape);

shape->set_X(shape->get_X() + 200);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnablePresetShadowEffect();
auto shadow = effectFormat->get_PresetShadowEffect();
shadow->set_Preset(PresetShadowType::TopLeftDropShadow);
shadow->set_Distance(10);
shadow->set_Direction(225);
textFrame->set_Text(System::Enum<PresetShadowType>::GetName(shadow->get_Preset()));
shapes->AddClone(shape);

shape->set_X(shape->get_X() + 200);
shadow->set_Preset(PresetShadowType::BottomRightDropShadow);
shadow->set_Direction(45);
textFrame->set_Text(System::Enum<PresetShadowType>::GetName(shadow->get_Preset()));
shapes->AddClone(shape);

shape->set_X(shape->get_X() + 200);
effectFormat->DisablePresetShadowEffect();
textFrame->set_Text(u"No shadow");

presentation->Save(u"preset_shadows.pptx", SaveFormat::Pptx);
```

| اصلی | پیش‌تنظیم اول | پیش‌تنظیم دوم | پس از حذف |
| :---: | :---: | :---: | :---: |
| ![بدون سایه](preset_shadow_original.png) | ![سایه‌افت بالا-چپ](preset_shadow_top_left.png) | ![سایه‌افت پایین-راست](preset_shadow_bottom_right.png) | ![بدون سایه پس از حذف](preset_shadow_removed.png) |

## **اعمال افکت انعکاس**

برای اعمال افکت انعکاس در Aspose.Slides برای C++ می‌توانید انعکاس آینه‌ای به اشکال اضافه کنید و پارامترهایی مانند فاصله، شفافیت و اندازه را تنظیم کنید. این افکت ظاهر ارائه شما را با دادن ظاهری صیقلی و پیشرفته به اشکال ارتقا می‌دهد. پیاده‌سازی آن با کد ساده است و امکان اعمال سریع در چندین عنصر برای طراحی یکدست را می‌دهد.

این کد C++ نشان می‌دهد چگونه می‌توان [اثر انعکاس](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/) را به یک شکل اعمال کرد:

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

![اثر انعکاس](reflection_effect.png)

## **اعمال افکت تابش**

برای اعمال افکت تابش به یک شکل در Aspose.Slides برای C++ می‌توانید هاله‌ای نرم و درخشان اطراف اشکال اضافه کنید و ویژگی‌هایی مانند رنگ و اندازه را تنظیم کنید. این افکت به برجسته شدن اشکال کمک می‌کند و عنصر بصری جذاب و چشم‌نوازی به ارائه شما می‌افزاید. پیاده‌سازی آن با کد حداقل امکان‌پذیر است و ظاهر کلی اسلایدها را بهبود می‌بخشد.

این کد C++ نشان می‌دهد چگونه می‌توان [اثر تابش](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/) را به یک شکل اعمال کرد:

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

![اثر تابش](glow_effect.png)

## **اعمال افکت لبه‌های نرم**

برای اعمال افکت لبه‌های نرم در Aspose.Slides برای C++ می‌توانید انتقالی صاف و مات در اطراف لبه‌های یک شکل ایجاد کنید. این افکت ظاهر ملایم‌تر و دقیق‌تری می‌دهد که برای طرح‌هایی که نیاز به ظاهر نرم‌تری دارند ایده‌آل است. می‌توانید به راحتی پارامترهایی مانند شعاع را تنظیم کنید تا افکت مورد نظر را بر روی اشکال مختلف در ارائه خود اعمال کنید.

این کد C++ نشان می‌دهد چگونه می‌توان [لبه‌های نرم](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/) را به یک شکل اعمال کرد:

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

![اثر لبه‌های نرم](soft_edges_effect.png)

## **اعمال افکت تاری**

از تاری شکل برای نرم‌کردن پرکننده و خط پیرامون شکل استفاده کنید در حالی که شکل قابل ویرایش می‌ماند. متد [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) را بر فرمت افکت شکل صدا بزنید. شعاع به پوینت (۱/۷۲ اینچ) اندازه‌گیری می‌شود: مقدار غیرمنفی استفاده کنید؛ مقادیر بزرگ‌تر تاریک شدگی قوی‌تری تولید می‌کند. شعاع صفر ظاهر را بدون تغییر می‌گذارد.

تنظیم [Grow](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/get_grow/) محدوده قابل مشاهده افکت را کنترل می‌کند. با `false`، تاری به مرزهای رنگ‌آمیزی اصلی، شامل خط پیرامون، محدود می‌شود. با `true`، تاری می‌تواند فراتر از این مرزها گسترش یابد. هیچ‌یک از این تنظیمات موقعیت یا ابعاد شکل را تغییر نمی‌دهد.

مقایسه زیر از همان پرکننده، خط پیرامون و ابعاد شکل در تمام حالات استفاده می‌کند. ردیف بالا `grow = false`؛ ردیف پایین `grow = true`.

![مستطیل اصلی مقایسه شده با شعاع‌های تاری ۵ و ۱۵ پوینت، با Grow غیرفعال و فعال](shape_blur_comparison.png)

این مثال C++ یک مستطیل نارنجی با خط پیرامون آبی تیره ایجاد می‌کند، تاری ۵ پوینتی اعمال می‌کند و سپس با صدا زدن دوباره [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) به ۱۵ پوینت بروزرسانی می‌کند. هر دو وضعیت تاری را ذخیره می‌کند، سپس [DisableBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disableblureffect/) را صدا می‌زند و شکل بدون تاری ذخیره می‌شود.

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

تاری شکل هم پرکننده و هم خط پیرامون را تحت تأثیر قرار می‌دهد. افکت لبه‌های نرم لبه‌های شکل را محو می‌کند، در حالی که تاری سایه فقط سایه را نرم می‌کند. افکت‌های تبدیل تصویر بر محتوای تصویر اعمال می‌شوند؛ این مثال تاری را مستقیماً بر فرمت افکت شکل اعمال می‌کند بدون تبدیل شکل به تصویر.

## **پرسش‌های متداول**

**آیا می‌توانم چندین افکت را بر یک شکل اعمال کنم؟**

بله، می‌توانید افکت‌های مختلفی مانند سایه، انعکاس و تابش را بر یک شکل ترکیب کنید تا ظاهر دینامیک‌تری داشته باشد.

**به چه اشکالی می‌توانم افکت اعمال کنم؟**

می‌توانید افکت‌ها را به انواع اشکال از جمله اشکال خودکار، نمودارها، جدول‌ها، تصاویر، اشیای SmartArt، اشیای OLE و سایر موارد اعمال کنید.

**آیا می‌توانم افکت‌ها را به اشکال گروهی اعمال کنم؟**

بله، می‌توانید افکت‌ها را به اشکال گروهی اعمال کنید. افکت بر کل گروه اعمال خواهد شد.