---
title: اعمال اثرهای شکل در ارائه‌ها با استفاده از C++
linktitle: اثر شکل
type: docs
weight: 30
url: /fa/cpp/shape-effect/
keywords:
- اثر شکل
- اثر سایه
- اثر بازتاب
- اثر تابش
- اثر لبه‌های نرم
- قالب اثر
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "فایل‌های PPT و PPTX خود را با استفاده از اثرهای پیشرفته شکل در Aspose.Slides برای C++ تبدیل کنید — اسلایدهای چشم‌نواز و حرفه‌ای را در ثانیه‌ها ایجاد کنید."
---
## **مقدمه**

در حالی که اثرها در PowerPoint می‌توانند برای برجسته‌کردن یک شکل استفاده شوند، آنها با [پرکردن](/slides/fa/cpp/shape-formatting/#gradient-fill) یا خطوط مرزی متفاوت هستند. با استفاده از اثرهای PowerPoint، می‌توانید بازتاب‌های قانع‌کننده‌ای روی یک شکل ایجاد کنید، تابش شکل را گسترش دهید، و غیره.

![اثر شکل](shape-effect.png)

PowerPoint شش اثر فراهم می‌کند که می‌توان به اشکال اعمال کرد. می‌توانید یک یا چند اثر را به یک شکل اعمال کنید.

برخی ترکیب‌های اثر بهتر از سایرین به نظر می‌رسند. به همین دلیل، PowerPoint گزینه‌هایی تحت **Preset** دارد. گزینه‌های Preset عملاً ترکیبی از دو یا چند اثر هستند که شناخته شده‌اند که به‌هم‌راهی خوب باشند. به این ترتیب، با انتخاب یک پیش‌تنظیم، نیازی به صرف زمان برای آزمایش یا ترکیب اثرهای مختلف برای یافتن ترکیب مناسب نخواهید داشت.

Aspose.Slides ویژگی‌ها و روش‌هایی تحت کلاس [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/) فراهم می‌کند که به شما اجازه می‌دهد همان اثرها را بر روی اشکال در ارائه‌های PowerPoint اعمال کنید.

## **اعمال اثر سایه**

Aspose.Slides برای C++ از سایه‌های خارجی و داخلی برای اشکال پشتیبانی می‌کند. می‌توانید رنگ، جهت، فاصله و شعاع تاری آن‌ها را برای مطابقت با طراحی ارائه خود سفارشی کنید.

### **اعمال سایه خارجی**

از یک سایه خارجی استفاده کنید تا کارت یا پنلی در مقابل پس‌زمینه اسلاید برجسته شود. سایه خارج از لبه‌های شکل گسترش می‌یابد و تصور می‌کند که شکل بالای اسلاید قرار دارد. رنگ، جهت، فاصله و شعاع تاری آن را برای مطابقت با نورپردازی و استایل قالب خود تنظیم کنید.

این کد C++ نشان می‌دهد چگونه می‌توان [اثر سایه خارجی](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) را به یک مستطیل اعمال کرد:

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

### **اعمال سایه داخلی**

هنگام بازتولید استایل بصری یک قالب، از یک سایه داخلی استفاده کنید تا کارت یا پنلی ظاهر فشرده داشته باشد. یک سایه خارجی خارج از شکل گسترش می‌یابد و باعث می‌شود شکل بالا آمده به نظر برسد، در حالی که یک سایه داخلی لبه‌های داخلی آن را سایه می‌کند.

[EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/) را فراخوانی کنید، سپس [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/) را پیکربندی کنید. مقادیر بزرگ‌تر شعاع تاری لبه‌های نرم‌تری تولید می‌کند.

این مثال C++ یک کارت آبی روشن با سایه داخلی خاکستری تیره ایجاد می‌کند و آن را به صورت فایل PPTX ذخیره می‌نماید:

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

برای حذف سایه داخلی، [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) را بر روی فرمت اثر شکل فراخوانی کنید.

## **اعمال اثر بازتاب**

برای اعمال یک اثر بازتاب در Aspose.Slides برای C++، می‌توانید بازتابی شبیه آینه را به اشکال اضافه کنید و پارامترهایی همچون فاصله، شفافیت و اندازه را تنظیم کنید. این اثر ظاهر ظاهری ارائه‌های شما را با دادن ظاهری صیقلی و پیشرفته به اشکال بهبود می‌بخشد. پیاده‌سازی آن با کد ساده آسان است و باعث می‌شود بتوانید به‌سرعت این اثر را بر روی عناصر متعدد برای یک طراحی سازگار اعمال کنید.

این کد C++ نشان می‌دهد چگونه می‌توان [اثر بازتاب](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/) را به یک شکل اعمال کرد:

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

![اثر بازتاب](reflection_effect.png)

## **اعمال اثر تابش**

برای اعمال یک اثر تابش به یک شکل در Aspose.Slides برای C++، می‌توانید هاله‌ای نرم و درخشان در اطراف اشکال اضافه کنید و ویژگی‌هایی مانند رنگ و اندازه را تنظیم کنید. این اثر به برجسته‌کردن اشکال کمک می‌کند و عنصر بصری جذاب و چشم‌نواز به ارائه شما می‌افزاید. پیاده‌سازی آن با حداقل کد آسان است و ظاهر کلی اسلایدهای شما را بهبود می‌بخشد.

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

## **اعمال اثر لبه‌های نرم**

برای اعمال یک اثر لبه‌های نرم در Aspose.Slides برای C++، می‌توانید انتقالی صاف و مبهم در اطراف لبه‌های یک شکل ایجاد کنید. این اثر ظاهر ظریف‌تر و صیقلی‌تری می‌بخشد که برای طرح‌هایی که به ظاهر ملایم و نرم نیاز دارند، ایده‌آل است. می‌توانید به‌راحتی پارامترهایی مانند شعاع را تنظیم کنید تا اثر دلخواه را بر روی اشکال مختلف در ارائه خود به‌دست آورید.

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

## **اعمال اثر تاری**

از تاری شکل برای نرم‌کردن پر و خط مرزی یک شکل استفاده کنید در حالی که شکل همچنان قابل ویرایش باقی می‌ماند. بر روی فرمت اثر شکل، [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) را فراخوانی کنید. شعاع بر حسب نقاط (1/72 اینچ) اندازه‌گیری می‌شود: از مقدار غیرمنفی استفاده کنید؛ مقادیر بزرگ‌تر تاری قوی‌تری تولید می‌کنند. شعاع صفر ظاهر را بدون تغییر می‌گذارد.

تنظیم [Grow](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/get_grow/) دامنه مرئی اثر را کنترل می‌کند. با `false`، تاری به حدود رنگ‌آمیزی اولیه، شامل خط مرزی، محدود می‌شود. با `true`، تاری می‌تواند فراتر از این حدود گسترش یابد. هیچ‌یک از این تنظیمات موقعیت یا ابعاد شکل را تغییر نمی‌دهند.

مقایسه زیر از پر، خط مرزی و ابعاد شکل در تمام حالات استفاده می‌کند. ردیف بالا `grow = false` را دارد؛ ردیف پایین `grow = true` را دارد.

![مستطیل اصلی در مقایسه با شعاع‌های تاری 5 و 15 نقطه، با Grow غیرفعال و فعال](shape_blur_comparison.png)

این مثال C++ یک مستطیل نارنجی با خط مرزی آبی تیره ایجاد می‌کند، تاری 5 نقطه‌ای اعمال می‌کند و سپس با فراخوانی دوباره [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) به تاری 15 نقطه‌ای به‌روزرسانی می‌کند. هر دو حالت تاری را ذخیره می‌کند، سپس [DisableBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disableblureffect/) را فراخوانی کرده و شکل را بدون تاری ذخیره می‌کند.

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

تاری شکل هم پر و هم خط مرزی را تحت تأثیر قرار می‌دهد. یک اثر لبه‌های نرم لبه‌های شکل را محو می‌کند، در حالی که تاری سایه فقط سایه را نرم می‌کند. اثرهای تبدیل تصویر بر محتوای تصویر عمل می‌کنند؛ این مثال تاری را مستقیماً بر فرمت اثر شکل بدون تبدیل به تصویر اعمال می‌کند.

## **سوالات متداول**

**آیا می‌توانم چندین اثر را بر روی یک شکل اعمال کنم؟**

بله، می‌توانید اثرهای مختلفی مانند سایه، بازتاب و تابش را بر روی یک شکل ترکیب کنید تا ظاهر پویا‌تری ایجاد کنید.

**کدام اشکال می‌توانم به آنها اثر اعمال کنم؟**

می‌توانید اثرها را به انواع مختلفی از اشکال شامل اشکال خودکار، نمودارها، جدول‌ها، تصاویر، اشیای SmartArt، اشیای OLE و موارد دیگر اعمال کنید.

**آیا می‌توانم اثرها را بر روی اشکال گروهی اعمال کنم؟**

بله، می‌توانید اثرها را بر روی اشکال گروهی اعمال کنید. اثر بر تمام گروه اعمال خواهد شد.