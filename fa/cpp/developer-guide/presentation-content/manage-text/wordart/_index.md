---
title: ایجاد و اعمال افکت‌های WordArt در C++
linktitle: WordArt
type: docs
weight: 110
url: /fa/cpp/wordart/
keywords:
- WordArt
- ایجاد WordArt
- قالب WordArt
- افکت WordArt
- افکت سایه
- افکت انعکاس
- افکت درخشندگی
- تبدیل WordArt
- افکت 3بعدی
- افکت سایه خارجی
- افکت سایه داخلی
- C++
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی افکت‌های WordArt در Aspose.Slides برای C++. این راهنمای گام‌به‌گام به توسعه‌دهندگان کمک می‌کند تا ارائه‌ها را با متن حرفه‌ای در C++ بهبود بخشند."
---
## **مرور کلی**

افکت‌های WordArt به شما امکان می‌دهند متن را با پرکردن، خطوط دور، سایه‌ها، انعکاس‌ها، درخشش، تغییر شکل و قالب‌بندی سه‌بعدی استایل دهید. این مقاله توضیح می‌دهد چگونه این افکت‌ها را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای C++ ایجاد و سفارشی کنید، بدون نیاز به نصب Microsoft Office.

## **ایجاد یک قالب WordArt ساده و اعمال آن روی متن**

مثال‌های زیر یک سبک WordArt ساده را با تنظیم متن، قلم، پرکردن الگو و خطوط دور ایجاد می‌کنند.

هر مثال یک ارائه جدید ایجاد می‌کند و یک مستطیل را به اسلاید اول آن اضافه می‌کند؛ نیازی به فایل ورودی نیست. مثال اول متن را به «Aspose.Slides» تنظیم می‌کند. موقعیت و ابعاد شکل بر حسب پوینت اندازه‌گیری می‌شود:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```

قلم را به Arial Black با اندازه 36 پوینت تنظیم کنید تا قالب‌بندی بیشتر مشهود باشد:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

یک الگوی [SmallGrid](https://reference.aspose.com/slides/fa/cpp/aspose.slides/patternstyle/) با پیش‌زمینه نارنجی تیره و پس‌زمینه سفید اعمال کنید، سپس یک خط دور مشکی با عرض 1 پوینت به متن اضافه کنید:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IPatternFormat.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);

auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Pattern);
fillFormat->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_DarkOrange());
fillFormat->get_PatternFormat()->get_BackColor()->set_Color(Color::get_White());
fillFormat->get_PatternFormat()->set_PatternStyle(PatternStyle::SmallGrid);

portion->get_PortionFormat()->get_LineFormat()->set_Width(1);
auto lineFillFormat = portion->get_PortionFormat()->get_LineFormat()->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
```

متن حاصل:

![قالب ساده WordArt](WordArt_template.png)

## **اعمال افکت‌های دیگر WordArt**

مثال‌های زیر نشان می‌دهند چگونه سایه‌ها، انعکاس‌ها، درخشش، تغییر شکل و افکت‌های سه‌بعدی را به متن اعمال کنید.

### **اعمال افکت‌های سایه خارجی**

سایه خارجی عمق می‌گیرد با قرار دادن سایه‌ای پشت متن. می‌توانید رنگ، جهت، فاصله، شعاع تاری، مقیاس و کج شدن آن را سفارشی کنید.

این مثال [EnableOuterShadowEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ieffectformat/enableoutershadoweffect/) را فراخوانی می‌کند و سایه‌ای سیاه با شعاع تاری 4 پوینت، جهت 230 درجه و فاصله 30 پوینت تنظیم می‌گیرد. مقادیر مقیاس 100 اندازه سایه را حفظ می‌کند، در حالی که کج شدن افقی آن را 20 درجه می‌چرخاند. تبدیل آلفا شفافیت را به 32 ٪ تنظیم می‌کند:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/ColorTransformOperation.h>
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();

auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_Black());
outerShadowEffect->set_ScaleHorizontal(100);
outerShadowEffect->set_ScaleVertical(100);
outerShadowEffect->set_BlurRadius(4);
outerShadowEffect->set_Direction(230.0f);
outerShadowEffect->set_Distance(30);
outerShadowEffect->set_SkewHorizontal(20);
outerShadowEffect->set_SkewVertical(0);
outerShadowEffect->get_ShadowColor()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.32f);
```

متن حاصل:

![افکت سایه خارجی](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- وقتی سایه‌های خارجی و پیش‌تنظیم شده همزمان استفاده شوند، تنها سایه خارجی اعمال می‌شود.
- اگر سایه‌های خارجی و داخلی همزمان استفاده شوند، اثر نهایی بسته به نسخه PowerPoint متفاوت است. به‌عنوان مثال، در PowerPoint 2013، اثر دو برابر می‌شود، در حالی که در PowerPoint 2007، فقط سایه خارجی اعمال می‌شود.
{{% /alert %}}

### **اعمال افکت‌های انعکاس**

انعکاس یک نسخهٔ آینه‌ای از متن ایجاد می‌کند. می‌توانید موقعیت، مقیاس، تاری و شفافیت آن را برای کنترل ظاهر تنظیم کنید.

این مثال [EnableReflectionEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ieffectformat/enablereflectioneffect/) را فراخوانی می‌کند و انعکاس را به صورت عمودی با مقیاس ‑100 ٪ می‌چرخاند. از شعاع تاری 0.5 پوینت و فاصله 4.72 پوینت استفاده می‌کند. شفافیت از 60 ٪ به 0.9 ٪ بین موقعیت‌های 0 ٪ و 60 ٪ طول انعکاس کاهش می‌یابد:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/Effects/IReflection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableReflectionEffect();

auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_BlurRadius(0.5);
reflectionEffect->set_Distance(4.72);
reflectionEffect->set_StartPosAlpha(0.f);
reflectionEffect->set_EndPosAlpha(60.f);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_ScaleHorizontal(100);
reflectionEffect->set_ScaleVertical(-100);
reflectionEffect->set_StartReflectionOpacity(60.f);
reflectionEffect->set_EndReflectionOpacity(0.9f);
reflectionEffect->set_RectangleAlign(RectangleAlignment::BottomLeft);
```

متن حاصل:

![افکت انعکاس](reflection_effect.png)

### **اعمال افکت‌های درخشش**

درخشش یک خط دور رنگی نرم اطراف متن اضافه می‌کند. می‌توانید رنگ، شفافیت و شعاع آن را برای کنترل اثر تنظیم کنید.

این مثال [EnableGlowEffect](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ieffectformat/enablegloweffect/) را فراخوانی می‌کند و درخششی قرمز با شفافیت 54 ٪ و شعاع 7 پوینت اعمال می‌کند:

```cpp
#include <drawing/color.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/ColorTransformOperation.h>
#include <DOM/Effects/IGlow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_Color(Color::get_Red());
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```

متن حاصل:

![افکت درخشش](glow_effect.png)

### **اعمال تغییر شکل‌های WordArt**

تغییر شکل‌های WordArt متن را خم، کشیده یا خمیده می‌کند.

[ITextFrameFormat::set_Transform](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframeformat/set_transform/) را به [ArchUpPour](https://reference.aspose.com/slides/fa/cpp/aspose.slides/textshapetype/) تنظیم کنید تا کل قاب متن به سمت بالا منحنی شود:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);

auto textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"Aspose.Slides");
textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

متن حاصل:

![تغییر شکل WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides برای C++ مجموعه‌ای از [انواع تبدیل پیش‌تعریف‌شده](https://reference.aspose.com/slides/fa/cpp/aspose.slides/textshapetype/) را فراهم می‌کند.
{{% /alert %}}

### **اعمال افکت‌های سه‌بعدی به اشکال و متن**

می‌توانید افکت‌های سه‌بعدی را به یک شکل یا متن آن اعمال کنید. برجستگی‌ها، برآمدگی، نورپردازی و تنظیمات دوربین ظاهر نهایی را کنترل می‌کنند.

مثال زیر از [IThreeDFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/) استفاده می‌کند تا برجستگی‌های دایره‌ای، برآمدگی نارنجی و کنتور قرمز تیره به مستطیل اضافه کند. ابعاد برجستگی، ارتفاع برآمدگی، عرض کنتور و عمق بر حسب پوینت اندازه‌گیری می‌شوند. یک ماده پلاستیکی، نورپردازی متعادل که 40 درجه حول محور Z چرخیده و دوربین پرسپکتیو ظاهر آن را تعریف می‌کنند:

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
autoShape->get_TextFrame()->set_Text(u"Aspose.Slides");

auto threeDFormat = autoShape->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(10.5);
threeDFormat->get_BevelBottom()->set_Width(10.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(12.5);
threeDFormat->get_BevelTop()->set_Width(11);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

شکل حاصل:

![افکت سه‌بعدی شکل](shape_3D_effect.png)

این مثال قالب‌بندی سه‌بعدی مشابهی را به متن از طریق [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframeformat/get_threedformat/) اعمال می‌کند. برجستگی‌های کوچکتر لبه‌های حروف را شکل می‌دهند، در حالی که برآمدگی و نورپردازی به متن عمق می‌بخشند:

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);

auto textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"Aspose.Slides");

auto threeDFormat = textFrame->get_TextFrameFormat()->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(3.5);
threeDFormat->get_BevelBottom()->set_Width(3.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(4);
threeDFormat->get_BevelTop()->set_Width(4);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

متن حاصل:

![افکت سه‌بعدی متن](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
اعمال افکت‌های سه‌بعدی بر متن یا شکل‌های آن—و تعامل بین این افکت‌ها—بر اساس قوانین خاصی انجام می‌شود. صحنه‌ای را در نظر بگیرید که هم متن و هم شکلی که شامل آن است در آن حضور دارند. یک افکت سه‌بعدی شامل نمایش سه‌بعدی شیء و صحنه‌ای است که در آن قرار گرفته است.

- اگر صحنه‌ای برای هر دو شکل و متن تنظیم شود، صحنهٔ شکل اولویت دارد و صحنهٔ متن نادیده گرفته می‌شود.
- اگر شکل صحنهٔ خود را نداشته باشد اما نمای سه‌بعدی داشته باشد، صحنهٔ متن استفاده می‌شود.
- اگر شکل هیچ افکت سه‌بعدی نداشته باشد، به‌عنوان صاف در نظر گرفته می‌شود و افکت سه‌بعدی فقط بر متن اعمال می‌شود.

این رفتارها به متدهای [IThreeDFormat::get_LightRig](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/get_lightrig/) و [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/get_camera/) مربوط می‌شوند.
{{% /alert %}}

برای حفظ مسطح و قابل خواندن بودن متن در حالی که قالب‌بندی سه‌بعدی شکل آن حفظ می‌شود، به [Keep Text Flat on a 3D Shape](/slides/fa/cpp/3d-presentation/) مراجعه کنید تا مقایسهٔ هر دو تنظیم و مثال کامل C++ را ببینید.

## **پرسش‌های متداول**

**آیا می‌توانم افکت‌های WordArt را با فونت‌ها یا اسکریپت‌های مختلف (مثلاً عربی، چینی) استفاده کنم؟**

بله، Aspose.Slides برای C++ از یونیکد پشتیبانی می‌کند و با تمام فونت‌ها و اسکریپت‌های اصلی کار می‌کند. افکت‌های WordArt مانند سایه، پرکردن و خطوط دور صرف‌نظر از زبان قابل اعمال هستند، اگرچه در دسترس بودن فونت و رندر ممکن است به فونت‌های سیستم وابسته باشد.

**آیا می‌توانم افکت‌های WordArt را به عناصر مستر اسلاید اعمال کنم؟**

بله، می‌توانید افکت‌های WordArt را به شکل‌های موجود در اسلایدهای مستر، از جمله نگهدارنده‌های عنوان، پاورقی‌ها یا متن پس‌زمینه اعمال کنید. تغییرات انجام‌شده در طرح مستر در تمام اسلایدهای مرتبط بازتاب خواهد یافت.

**آیا افکت‌های WordArt باعث افزایش حجم فایل ارائه می‌شوند؟**

به‌طور کمی. افکت‌هایی مانند سایه، درخشش و پرکردن گرادیان ممکن است به‌دلیل افزودن متاداده‌های قالب‌بندی حجم فایل را کمی افزایش دهند، اما معمولاً این تفاوت ناچیز است.

**آیا می‌توانم پیش‌نمایش نتایج افکت‌های WordArt را بدون ذخیرهٔ ارائه دریافت کنم؟**

بله، می‌توانید اسلایدهای شامل WordArt را به تصویر (مثلاً PNG یا JPEG) با استفاده از [ISlide::GetImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/getimage/) رندر کنید، یا شکل‌های جداگانه را با [IShape::GetImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/getimage/) رندر کنید. این امکان پیش‌نمایش نتایج را در حافظه یا روی صفحه نمایش قبل از ذخیره یا خروجی گرفتن از کل ارائه فراهم می‌کند.