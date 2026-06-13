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
- افکت نوردهی
- افکت لبه‌های نرم
- قالب افکت
- پاورپوینت
- ارائه
- C++
- Aspose.Slides
description: "فایل‌های PPT و PPTX خود را با استفاده از افکت‌های پیشرفته شکل با Aspose.Slides برای C++ — اسلایدهای چشم‌نواز و حرفه‌ای را در ثانیه‌ها ایجاد کنید."
---
## **مقدمه**

در حالی که افکت‌ها در پاورپوینت می‌توانند برای برجسته کردن یک شکل استفاده شوند، آن‌ها با [fills](/slides/fa/cpp/shape-formatting/#gradient-fill) یا خطوط بیرونی متفاوت هستند. با استفاده از افکت‌های پاورپوینت، می‌توانید انعکاس‌های قانع‌کننده‌ای روی یک شکل ایجاد کنید، نوردهی یک شکل را گسترش دهید، و غیره.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* پاورپوینت شش افکت ارائه می‌دهد که می‌توانند بر روی اشکال اعمال شوند. می‌توانید یک یا چند افکت را بر یک شکل اعمال کنید. 

* برخی ترکیبات افکت بهتر از سایرین به نظر می‌رسند. به همین دلیل، گزینه‌های پاورپوینت تحت **Preset**. گزینه‌های Preset در واقع ترکیبی شناخته‌شده و زیبا از دو یا چند افکت هستند. به این ترتیب، با انتخاب یک پیش‌تنظیم، نیازی به صرف زمان برای آزمایش یا ترکیب افکت‌های مختلف برای یافتن ترکیب مناسب نخواهید داشت.

Aspose.Slides ویژگی‌ها و متدهایی تحت کلاس [EffectFormat](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.effect_format/) ارائه می‌دهد که به شما امکان می‌دهد همان افکت‌ها را بر روی اشکال در ارائه‌های پاورپوینت اعمال کنید.

## **اعمال افکت سایه**

این کد C++ نشان می‌دهد چگونه افکت سایه خارجی ([OuterShadowEffect](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.effect_format#aea1a48246d3240e29092498f648bc028)) را بر روی یک مستطیل اعمال کنید:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();
auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(System::Drawing::Color::get_DarkGray());
outerShadowEffect->set_Distance(10);
outerShadowEffect->set_Direction(45.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **اعمال افکت انعکاس**

این کد C++ نشان می‌دهد چگونه افکت انعکاس را بر روی یک شکل اعمال کنید:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableReflectionEffect();
auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_RectangleAlign(RectangleAlignment::Bottom);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_Distance(55);
reflectionEffect->set_BlurRadius(4);

pres->Save(u"reflection.pptx", SaveFormat::Pptx);
```

## **اعمال افکت نوردهی**

این کد C++ نشان می‌دهد چگونه افکت نوردهی را بر روی یک شکل اعمال کنید:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableGlowEffect();
auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_Color(System::Drawing::Color::get_Magenta());
glowEffect->set_Radius(15);

pres->Save(u"glow.pptx", SaveFormat::Pptx);
```

## **اعمال افکت لبه‌های نرم**

این کد C++ نشان می‌دهد چگونه لبه‌های نرم را بر روی یک شکل اعمال کنید:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);

auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableSoftEdgeEffect();
auto softEdgeEffect = effectFormat->get_SoftEdgeEffect();
softEdgeEffect->set_Radius(15);

pres->Save(u"softEdges.pptx", SaveFormat::Pptx);
```

## **سوالات متداول**

**آیا می‌توانم چندین افکت را بر روی یک شکل اعمال کنم؟**

بله، می‌توانید افکت‌های مختلفی مانند سایه، انعکاس و نوردهی را بر روی یک شکل ترکیب کنید تا ظاهر پویا‌تری ایجاد کنید.

**به کدام شکل‌ها می‌توانم افکت اعمال کنم؟**

می‌توانید افکت‌ها را بر روی اشکال مختلفی مانند اشکال خودکار، نمودارها، جدول‌ها، تصاویر، اشیای SmartArt، اشیای OLE و موارد دیگر اعمال کنید.

**آیا می‌توانم افکت‌ها را بر روی اشکال گروه‌بندی شده اعمال کنم؟**

بله، می‌توانید افکت‌ها را بر روی اشکال گروه‌بندی شده اعمال کنید. افکت بر کل گروه اعمال خواهد شد.