---
title: اعمال افکت‌های شکل در ارائه‌ها با استفاده از C++
linktitle: افکت شکل
type: docs
weight: 30
url: /fa/cpp/shape-effect/
keywords:
- افکت شکل
- افکت سایه
- افکت انعکاس
- افکت درخشانی
- افکت لبه‌های نرم
- قالب افکت
- پاورپوینت
- ارائه
- C++
- Aspose.Slides
description: "فایل‌های PPT و PPTX خود را با استفاده از افکت‌های پیشرفته شکل با Aspose.Slides برای C++ تبدیل کنید — در چند ثانیه اسلایدهای جذاب و حرفه‌ای ایجاد کنید."
---
## **مقدمه**

در حالی که افکت‌ها در پاورپوینت می‌توانند برای برجسته کردن یک شکل استفاده شوند، آن‌ها با [پرکننده‌ها](/slides/fa/cpp/shape-formatting/#gradient-fill) یا خطوط مرزی متفاوت هستند. با استفاده از افکت‌های پاورپوینت، می‌توانید انعکاس‌های قانع‌کننده‌ای روی یک شکل ایجاد کنید، تابش یک شکل را گسترش دهید و غیره.

![اثر شکل](shape-effect.png)

پاورپوینت شش افکت را فراهم می‌کند که می‌توانند بر روی اشکال اعمال شوند. می‌توانید یک یا چند افکت را بر روی یک شکل اعمال کنید.

برخی ترکیب‌های افکت بهتر از دیگران به نظر می‌رسند. به همین دلیل، پاورپوینت گزینه‌هایی تحت **Preset** دارد. گزینه‌های Preset در اصل ترکیبی از دو یا چند افکت هستند که شناخته شده‌اند که با هم خوب به نظر می‌رسند. به این ترتیب، با انتخاب یک پیش‌تنظیم، نیازی به صرف زمان برای آزمایش یا ترکیب افکت‌های مختلف برای یافتن ترکیب مناسب ندارید.

Aspose.Slides ویژگی‌ها و متدهایی تحت کلاس [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/) ارائه می‌دهد که به شما اجازه می‌دهد همان افکت‌ها را بر روی اشکال در ارائه‌های پاورپوینت اعمال کنید.

## **اعمال افکت سایه**

Aspose.Slides برای C++ از سایه‌های بیرونی و داخلی برای اشکال پشتیبانی می‌کند. می‌توانید رنگ، جهت، فاصله و شعاع تاری آن‌ها را برای مطابقت با طراحی ارائه خود سفارشی کنید.

### **اعمال سایه بیرونی**

از سایه بیرونی برای برجسته کردن یک کارت یا پنل نسبت به پس‌زمینه اسلاید استفاده کنید. سایه فراتر از لبه‌های شکل گسترش می‌یابد و تصور می‌کند که شکل بالاتر از اسلاید قرار دارد. رنگ، جهت، فاصله و شعاع تاری آن را برای مطابقت با نورپردازی و سبک قالب خود تنظیم کنید.

این کد C++ نشان می‌دهد چگونه [افکت سایه بیرونی](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) را بر روی یک مستطیل اعمال کنید:

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

![افکت سایه](shadow_effect.png)

### **اعمال سایه داخلی**

هنگام بازتولید سبک بصری یک قالب، از سایه داخلی برای دادن ظاهر فرو‌رفتگی به یک کارت یا پنل استفاده کنید. سایه بیرونی خارج از شکل گسترش می‌یابد و آن را برجسته می‌کند، در حالی که سایه داخلی لبه‌های داخلی آن را سایه‌زده می‌کند.

متد [EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/) را فراخوانی کنید، سپس [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/) را پیکربندی کنید. مقادیر بزرگ‌تر شعاع تاری، لبه‌های نرم‌تری تولید می‌کند.

این مثال C++ یک کارت آبی روشن با سایه داخلی خاکستری تیره ایجاد می‌کند و آن را به‌عنوان فایل PPTX ذخیره می‌کند:

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

برای حذف سایه داخلی، متد [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) را بر روی فرمت افکت شکل فراخوانی کنید.

### **اعمال، تغییر و حذف سایه پیش‌تنظیم شده**

متد [EnablePresetShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/enablepresetshadoweffect/) را فراخوانی کنید و برای انتخاب یک [PresetShadowType](https://reference.aspose.com/slides/cpp/aspose.slides/presetshadowtype/) از [set_Preset](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ipresetshadow/set_preset/) استفاده کنید. برای تغییر سبک‌ها، پیش‌تنظیم را روی همان شکل تغییر دهید. برای حذف سایه در حالی که پرکننده و خط کانتور حفظ می‌شوند، متد [DisablePresetShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disablepresetshadoweffect/) را فراخوانی کنید.

این مثال یک کپی از مستطیل را در هر مرحله نگه می‌دارد. هر دو سایه ۱۰ نقطه جابجا شده‌اند. جهت ۲۲۵° سایه اول را بالای چپ مستطیل قرار می‌دهد و ۴۵° سایه دوم را پایین راست.

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
| ![بدون سایه](preset_shadow_original.png) | ![سایه افت بالا چپ](preset_shadow_top_left.png) | ![سایه افت پایین راست](preset_shadow_bottom_right.png) | ![بدون سایه پس از حذف](preset_shadow_removed.png) |

## **اعمال افکت انعکاس**

برای اعمال افکت انعکاس در Aspose.Slides برای C++، می‌توانید انعکاس مشابه آینه را به اشکال اضافه کنید و پارامترهایی مانند فاصله، شفافیت و اندازه را تنظیم کنید. این افکت زیبایی ارائه‌های شما را با دادن ظاهر صیقلی و پیشرفته به اشکال ارتقا می‌دهد. پیاده‌سازی آن با کد ساده‌ای آسان است و امکان اعمال سریع در چندین عنصر را برای طراحی یکدست فراهم می‌کند.

این کد C++ نشان می‌دهد چگونه [افکت انعکاس](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/) را بر روی یک شکل اعمال کنید:

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

![افکت انعکاس](reflection_effect.png)

## **اعمال افکت درخشانی**

برای اعمال افکت درخشانی به یک شکل در Aspose.Slides برای C++، می‌توانید هاله‌ای ملایم و نورانی اطراف اشکال اضافه کنید و ویژگی‌هایی مانند رنگ و اندازه را تنظیم کنید. این افکت به برجسته شدن اشکال کمک کرده و عنصری جذاب بصری به ارائه شما می‌افزاید. پیاده‌سازی آن با کد کمینه آسان است و ظاهر کلی اسلایدهای شما را بهبود می‌بخشد.

این کد C++ نشان می‌دهد چگونه [افکت درخشانی](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/) را بر روی یک شکل اعمال کنید:

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

![افکت درخشانی](glow_effect.png)

## **اعمال افکت لبه‌های نرم**

برای اعمال افکت لبه‌های نرم در Aspose.Slides برای C++، می‌توانید یک انتقال صاف و مبهم اطراف لبه‌های یک شکل ایجاد کنید. این افکت ظاهر ظریف‌تری اضافه می‌کند که برای طراحی‌های نیازمند ظاهری ملایم و نرم ایده‌آل است. می‌توانید به راحتی پارامترهایی مانند شعاع را تنظیم کنید تا افکت دلخواه را بر روی اشکال مختلف در ارائه خود به دست آورید.

این کد C++ نشان می‌دهد چگونه [لبه‌های نرم](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/) را بر روی یک شکل اعمال کنید:

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

![افکت لبه‌های نرم](soft_edges_effect.png)

## **اعمال افکت تاری**

از تاری شکل برای نرم کردن پرکننده و خط مرزبندی یک شکل استفاده کنید در حالی که شکل قابل ویرایش باقی می‌ماند. متد [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) را بر روی فرمت افکت شکل فراخوانی کنید. شعاع بر حسب نقطه (1/72 اینچ) است: از مقدار غیرمنفی استفاده کنید؛ مقادیر بزرگ‌تر تاری قوی‌تری ایجاد می‌کند. شعاع صفر ظاهر را تغییر نمی‌دهد.

تنظیم [Grow](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/get_grow/) محدوده قابل مشاهده افکت را کنترل می‌کند. با `false`، تاری به محدوده‌های رنگ‌شده اصلی، شامل خط مرزی، محدود می‌شود. با `true`، تاری می‌تواند فراتر از آن محدوده‌ها گسترش یابد. هیچ‌یک از این تنظیمات موقعیت یا ابعاد شکل را تغییر نمی‌دهند.

مقایسهٔ زیر از همان پرکننده، خط مرزی و ابعاد شکل در تمام مثال‌ها استفاده می‌کند. ردیف بالا از `grow = false` استفاده می‌کند؛ ردیف پایین از `grow = true`.

![مستطیل اصلی مقایسه شده با شعاع‌های تاری ۵ و ۱۵ نقطه، با قابلیت Grow غیرفعال و فعال](shape_blur_comparison.png)

این مثال C++ یک مستطیل نارنجی با خط مرزی آبی تیره ایجاد می‌کند، تاری ۵ نقطه اعمال می‌کند، سپس آن را به تاری ۱۵ نقطه به‌روزرسانی می‌کند با فراخوانی مجدد [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) . سپس هر دو حالت تاری را ذخیره می‌کند، سپس [DisableBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disableblureffect/) را فراخوانی می‌کند و شکل بدون تاری را ذخیره می‌کند.

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

تاری شکل بر روی پرکننده و خط مرزی به‌صورت همزمان تاثیر می‌گذارد. افکت لبه‌های نرم لبه‌های شکل را محو می‌کند، در حالی که تاری سایه تنها سایه را نرم می‌کند. افکت‌های تبدیل تصویر بر محتوای تصویر عمل می‌کنند؛ این مثال تاری را مستقیماً بر روی فرمت افکت شکل بدون تبدیل شکل به تصویر اعمال می‌کند.

## **سوالات متداول**

**آیا می‌توانم چندین افکت را بر روی یک شکل اعمال کنم؟**

بله، می‌توانید افکت‌های مختلفی مانند سایه، انعکاس و درخشانی را بر روی یک شکل ترکیب کنید تا ظاهر پویا‌تری ایجاد کنید.

**به چه اشکالی می‌توانم افکت‌ها را اعمال کنم؟**

می‌توانید افکت‌ها را بر روی انواع اشکال، از جمله اشکال خودکار، نمودارها، جدول‌ها، تصاویر، اشیاء SmartArt، اشیاء OLE و غیره اعمال کنید.

**آیا می‌توانم افکت‌ها را بر روی اشکال گروه‌بندی شده اعمال کنم؟**

بله، می‌توانید افکت‌ها را بر روی اشکال گروه‌بندی شده اعمال کنید. افکت بر روی کل گروه اعمال خواهد شد.