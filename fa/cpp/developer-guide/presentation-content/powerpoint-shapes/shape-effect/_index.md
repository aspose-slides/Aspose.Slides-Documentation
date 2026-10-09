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
- اثر درخشش
- اثر لبه‌های نرم
- قالب اثر
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "فایل‌های PPT و PPTX خود را با استفاده از اثرهای پیشرفته شکل در Aspose.Slides برای C++ تبدیل کنید — اسلایدهای چشم‌گیر و حرفه‌ای را در چند ثانیه ایجاد کنید."
---
## **مقدمه**

در حالی که اثرات در PowerPoint می‌توانند برای برجسته کردن یک شکل استفاده شوند، آن‌ها با [پرکننده‌ها](/slides/fa/cpp/shape-formatting/#gradient-fill) یا خطوط پیرامونی متفاوت هستند. با استفاده از اثرات PowerPoint، می‌توانید بازتاب‌های قانع‌کننده‌ای روی یک شکل ایجاد کنید، نور درخشش شکل را پخش کنید و غیره.

![اثر شکل](shape-effect.png)

PowerPoint شش اثر را ارائه می‌دهد که می‌توان بر روی اشکال اعمال کرد. می‌توانید یک یا چند اثر را بر یک شکل اعمال کنید.

برخی ترکیب‌های اثر بهتر از سایرین به نظر می‌رسند. به همین دلیل، PowerPoint گزینه‌هایی تحت **Preset** دارد. گزینه‌های پیش‌تنظیم (Preset) در واقع ترکیبی شناخته‌شده از دو یا چند اثر هستند که ظاهر خوبی دارند. به این ترتیب، با انتخاب یک پیش‌تنظیم، نیازی به صرف زمان برای آزمون یا ترکیب اثرهای مختلف برای یافتن ترکیب مناسب نیست.

Aspose.Slides ویژگی‌ها و متدهایی را تحت کلاس [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/) فراهم می‌کند که به شما امکان می‌دهد همان اثرها را بر اشکال در ارائه‌های PowerPoint اعمال کنید.

## **اعمال یک اثر سایه**

Aspose.Slides برای C++ از سایه‌های خارجی و داخلی برای اشکال پشتیبانی می‌کند. می‌توانید رنگ، جهت، فاصله و شعاع تاری آن‌ها را مطابق با طراحی ارائه خود سفارشی کنید.

### **اعمال سایه بیرونی**

از یک سایه بیرونی استفاده کنید تا کارت یا پنلی در مقابل پس‌زمینه اسلاید برجسته شود. سایه فراتر از لبه‌های شکل گسترش می‌یابد و این impression را ایجاد می‌کند که شکل بالای اسلاید قرار گرفته است. رنگ، جهت، فاصله و شعاع تاری آن را مطابق با نورپردازی و سبک قالب خود تنظیم کنید.

این کد C++ نشان می‌دهد که چگونه [اثر سایه بیرونی](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) را بر یک مستطیل اعمال کنید:

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

هنگام بازتولید استایل بصری یک قالب، از یک سایه داخلی برای ایجاد ظاهر فرو رفته در کارت یا پنل استفاده کنید. سایه بیرونی خارج از شکل گسترش می‌یابد و آن را بالا می‌آورد، در حالی که سایه داخلی داخل لبه‌های شکل را سایه می‌اندازد.

متد [EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/) را فراخوانی کنید، سپس [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/) را پیکربندی کنید. مقادیر بزرگتر شعاع تاری لبه‌های نرم‌تری تولید می‌کنند.

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

برای حذف سایه داخلی، متد [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) را بر فرمت اثر شکل صدا بزنید.

## **اعمال یک اثر بازتاب**

برای اعمال یک اثر بازتاب در Aspose.Slides برای C++، می‌توانید بازتابی شبیه آینه را به اشکال اضافه کنید و پارامترهایی مانند فاصله، شفافیت و اندازه را تنظیم کنید. این اثر زیبایی ارائه‌های شما را با دادن ظاهری صیقلی و پرمحتوا به اشکال افزوده می‌کند. پیاده‌سازی آن با کد ساده آسان است و امکان اعمال سریع بر روی چندین عنصر برای داشتن طراحی یک‌دست را فراهم می‌کند.

این کد C++ نشان می‌دهد که چگونه [اثر بازتاب](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/) را بر یک شکل اعمال کنید:

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

## **اعلام یک اثر درخشش**

برای اعمال یک اثر درخشش بر یک شکل در Aspose.Slides برای C++، می‌توانید هاله‌ای نرم و درخشان دور اشکال اضافه کنید و ویژگی‌هایی مانند رنگ و اندازه را تنظیم کنید. این اثر به برجسته شدن اشکال کمک کرده و یک عنصر بصری جذاب و چشم‌نواز به ارائه شما می‌افزاید. پیاده‌سازی آن با کد کمینه آسان است و ظاهر کلی اسلایدهای شما را بهبود می‌بخشد.

این کد C++ نشان می‌دهد که چگونه [اثر درخشش](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/) را بر یک شکل اعمال کنید:

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

![اثر درخشش](glow_effect.png)

## **اعمال یک اثر لبه‌های نرم**

برای اعمال یک اثر لبه‌های نرم در Aspose.Slides برای C++، می‌توانید یک انتقال نرم و تاریک اطراف لبه‌های شکل ایجاد کنید. این اثر ظاهری ملایم‌تر و صیقلی‌تر می‌بخشد که برای طرح‌هایی که نیاز به ظاهر لطیف و نرم دارند ایده‌آل است. می‌توانید به راحتی پارامترهایی مانند شعاع را تنظیم کنید تا اثر مورد نظر را بر روی اشکال مختلف در ارائه خود به دست آورید.

این کد C++ نشان می‌دهد که چگونه [لبه‌های نرم](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/) را بر یک شکل اعمال کنید:

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

## **سوالات متداول**

**آیا می‌توانم چندین اثر را بر روی یک شکل اعمال کنم؟**

بله، می‌توانید اثرهای مختلفی مانند سایه، بازتاب و درخشش را بر یک شکل ترکیب کنید تا ظاهر دینامیک‌تری به دست آورید.

**کدام اشکال می‌توانم به آنها اثر اعمال کنم؟**

می‌توانید اثرها را به انواع اشکال، از جمله اشکال خودکار، نمودارها، جدول‌ها، تصاویر، اشیای SmartArt، اشیای OLE و ... اعمال کنید.

**آیا می‌توانم اثرها را به اشکال گروه‌بندی شده اعمال کنم؟**

بله، می‌توانید اثرها را به اشکال گروه‌بندی شده اعمال کنید. اثر به کل گروه اعمال خواهد شد.