---
title: ایجاد و اعمال اثرات WordArt در C++
linktitle: WordArt
type: docs
weight: 110
url: /fa/cpp/wordart/
keywords:
- WordArt
- ایجاد WordArt
- قالب WordArt
- اثر WordArt
- اثر سایه
- اثر نمایش
- اثر درخشندگی
- تبدیل WordArt
- اثر سه‌بعدی
- اثر سایه خارجی
- اثر سایه داخلی
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی اثرات WordArt در Aspose.Slides برای C++. این راهنمای گام به گام به توسعه‌دهندگان کمک می‌کند تا با متن حرفه‌ای در C++ ارائه‌ها را ارتقا دهند."
---
## **بررسی کلی**

تاثیرات WordArt به شما امکان می‌دهد متن‌های به‌صورت بصری جذاب و استایلیزه را به ارائه‌های PowerPoint خود اضافه کنید. با Aspose.Slides، توسعه‌دهندگان می‌توانند به‌صورت برنامه‌نویسی WordArt را درست مانند Microsoft PowerPoint ایجاد، سفارشی‌سازی و مدیریت کنند—بدون نیاز به نصب Office. این مقاله نگاهی کلی به کار با WordArt دارد، از جمله نحوه اعمال تبدیل‌های متنی، سبک‌های پر، خطوط دور، سایه‌ها و سایر گزینه‌های قالب‌بندی برای جذاب‌تر و بیان‌گرتر کردن محتوای ارائه شما. WordArt به شما اجازه می‌دهد متن را به‌عنوان یک شیء گرافیکی در نظر بگیرید. این شامل اثرات یا تغییرات ویژه‌ای است که بر متن اعمال می‌شوند تا آن را قابل توجه‌تر یا زیباتر کنند.

## **ایجاد یک قالب WordArt ساده و اعمال آن بر متن**

**با استفاده از Aspose.Slides**  

در ابتدا، با این کد C++ یک متن ساده می‌سازیم:

``` cpp 
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```

حال، با این کد ارتفاع فونت متن را به مقدار بزرگتری تنظیم می‌کنیم تا اثر واضح‌تر شود:

``` cpp 
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

**با استفاده از Microsoft PowerPoint**

به منوی اثرات WordArt در Microsoft PowerPoint بروید:

![todo:image_alt_text](image-20200930113926-1.png)

از منوی سمت راست می‌توانید یک اثر WordArt از پیش تعریف شده را انتخاب کنید. از منوی سمت چپ می‌توانید تنظیمات یک WordArt جدید را مشخص کنید.

این‌ها برخی از پارامترها یا گزینه‌های موجود هستند:

![todo:image_alt_text](image-20200930114015-3.png)

**با استفاده از Aspose.Slides**

در اینجا، رنگ الگوی SmallGrid را به متن اعمال می‌کنیم و حاشیه متن سیاه با ضخامت 1 را با این کد اضافه می‌کنیم:

``` cpp 
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
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/IPatternFormat.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Pattern);
fillFormat->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_DarkOrange());
fillFormat->get_PatternFormat()->get_BackColor()->set_Color(Color::get_White());
fillFormat->get_PatternFormat()->set_PatternStyle(PatternStyle::SmallGrid);

auto lineFillFormat = portion->get_PortionFormat()->get_LineFormat()->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
```

متن حاصل:

![todo:image_alt_text](image-20200930114108-4.png)

## **اعمال سایر اثرات WordArt**

**با استفاده از Microsoft PowerPoint**

از رابط برنامه می‌توانید این اثرات را بر متن، بلوک متن، شکل یا عنصر مشابهی اعمال کنید:

![todo:image_alt_text](image-20200930114129-5.png)

به‌عنوان مثال، اثرات سایه، انعکاس و درخشندگی می‌توانند بر یک متن اعمال شوند؛ اثرات قالب‌بندی سه‌بعدی و چرخش سه‌بعدی می‌توانند بر یک بلوک متن اعمال شوند؛ ویژگی لبه‌های نرم می‌تواند بر یک شیء Shape اعمال شود (حتی اگر خاصیت قالب‌بندی سه‌بعدی تنظیم نشده باشد).

### **اعمال اثرات سایه بر متن**

در اینجا، فقط خواص مربوط به یک متن را تنظیم می‌کنیم. با این کد C++ اثر سایه را بر متن اعمال می‌کنیم:

``` cpp 
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
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();

auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_Black());
outerShadowEffect->set_ScaleHorizontal(100);
outerShadowEffect->set_ScaleVertical(65);
outerShadowEffect->set_BlurRadius(4.73);
outerShadowEffect->set_Direction(230.0f);
outerShadowEffect->set_Distance(2);
outerShadowEffect->set_SkewHorizontal(30);
outerShadowEffect->set_SkewVertical(0);
outerShadowEffect->get_ShadowColor()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.32f);
```

API Aspose.Slides از سه نوع سایه پشتیبانی می‌کند: OuterShadow، InnerShadow و PresetShadow.

با PresetShadow می‌توانید یک سایه پیش‌ تنظیم شده را برای متن اعمال کنید.

**با استفاده از Microsoft PowerPoint**

در PowerPoint فقط می‌توانید از یک نوع سایه استفاده کنید. مثال:

![todo:image_alt_text](image-20200930114225-6.png)

**با استفاده از Aspose.Slides**

Aspose.Slides در واقع اجازه می‌دهد همزمان دو نوع سایه را اعمال کنید: InnerShadow و PresetShadow.

**نکات:**

- وقتی OuterShadow و PresetShadow با هم استفاده شوند، فقط اثر OuterShadow اعمال می‌شود.  
- اگر OuterShadow و InnerShadow همزمان استفاده شوند، اثر حاصل بسته به نسخه PowerPoint متفاوت است. برای مثال، در PowerPoint 2013 اثر دوبرابر می‌شود، اما در PowerPoint 2007 فقط اثر OuterShadow اعمال می‌شود.

### **اعمال اثرات انعکاس**

با این نمونه کد C++ یک انعکاس به متن اضافه می‌کنیم:

``` cpp 
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
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

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

### **اعمال اثرات درخشندگی**

با این کد اثر درخشندگی را بر متن اعمال می‌کنیم تا روشن یا برجسته شود:

``` cpp 
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
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_R(255);
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```

نتیجه عملیات:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="info" %}} 

می‌توانید پارامترهای سایه، نمایش و درخشندگی را تغییر دهید. خصوصیات اثرات بر هر بخش از متن به‌صورت جداگانه تنظیم می‌شود. 

{{% /alert %}} 

### **استفاده از تبدیل‌ها در WordArt**

از متد set_Transform (که بر کل بلوک متن اعمال می‌شود) با این کد استفاده می‌کنیم:

``` cpp 
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"Aspose.Slides");

textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

نتیجه:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="info" %}} 

هر دو Microsoft PowerPoint و Aspose.Slides برای C++ تعداد معینی از انواع تبدیل‌های پیش‌ تعریف شده را فراهم می‌کنند. 

{{% /alert %}} 

**با استفاده از PowerPoint**

برای دسترسی به انواع تبدیل‌های پیش‌ تعریف شده، به مسیر زیر بروید: **Format** → **TextEffect** → **Transform**

**با استفاده از Aspose.Slides**

برای انتخاب نوع تبدیل، از enum کلاس TextShapeType استفاده کنید.

### **اعمال اثرات سه‌بعدی بر متن و اشکال**

با این کد نمونه یک اثر سه‌بعدی را بر یک شکل متنی تنظیم می‌کنیم:

``` cpp 
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
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

متن و شکل حاصل:

![todo:image_alt_text](image-20200930114816-9.png)

با این کد C++ یک اثر سه‌بعدی به متن اعمال می‌کنیم:

``` cpp 
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
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

نتیجه عملیات:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="info" %}} 

اعمال اثرات سه‌بعدی بر متن یا شکل‌های آن و تعامل بین اثرات بر اساس قوانین خاصی انجام می‌شود.

یک صحنه برای متن و شکلی که متن را در بر می‌گیرد در نظر بگیرید. اثر سه‌بعدی شامل نمایش شیء سه‌بعدی و صحنه‌ای است که شیء در آن قرار می‌گیرد.

- وقتی صحنه برای هر دو شکل و متن تنظیم شود، صحنه شکل اولویت بالاتری دارد—صحنه متن نادیده گرفته می‌شود.  
- وقتی شکل صحنهٔ خاص خود را نداشته باشد اما نمایهٔ سه‌بعدی داشته باشد، صحنهٔ متن استفاده می‌شود.  
- در غیر این صورت—وقتی شکل در ابتدا هیچ اثر سه‌بعدی نداشته باشد—شکل صاف می‌ماند و اثر سه‌بعدی فقط بر متن اعمال می‌شود.  

این توضیحات به متدهای ThreeDFormat.getLightRig() و ThreeDFormat.getCamera() مرتبط هستند.

{{% /alert %}} 

## **اعمال اثر سایه خارجی بر اشکال**
Aspose.Slides برای C++ کلاس‌های [**IOuterShadow**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.effects.i_outer_shadow) و [**IInnerShadow**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.effects.i_inner_shadow) را فراهم می‌کند که امکان اعمال اثرات سایه بر متنی که در TextFrame قرار دارد را می‌دهند. مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
2. با استفاده از ایندکس، مرجع یک اسلاید را دریافت کنید.  
3. یک AutoShape از نوع Rectangle به اسلاید اضافه کنید.  
4. به TextFrame مربوط به AutoShape دسترسی پیدا کنید.  
5. FillType خودکار شکل را به NoFill تنظیم کنید.  
6. کلاس OuterShadow را نمونه‌سازی کنید.  
7. BlurRadius سایه را تنظیم کنید.  
8. Direction سایه را تنظیم کنید.  
9. Distance سایه را تنظیم کنید.  
10. RectanglelAlign را به TopLeft تنظیم کنید.  
11. PresetColor سایه را به Black تنظیم کنید.  
12. ارائه را به‌صورت فایل PPTX ذخیره کنید.

این کد نمونهٔ C++—که پیاده‌سازی مراحل بالا را نشان می‌دهد—نحوهٔ اعمال اثر سایهٔ خارجی بر متن را نشان می‌دهد:

``` cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/PresetColor.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
// دریافت مرجع اسلاید
auto sld = pres->get_Slides()->idx_get(0);

// افزودن یک AutoShape از نوع Rectangle
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// افزودن TextFrame به Rectangle
ashp->AddTextFrame(u"Aspose TextBox");

// غیرفعال کردن پر شدن شکل در صورتی که می‌خواهیم سایه متن را داشته باشیم
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// افزودن سایه خارجی و تنظیم تمام پارامترهای ضروری
ashp->get_EffectFormat()->EnableOuterShadowEffect();
auto shadow = ashp->get_EffectFormat()->get_OuterShadowEffect();
shadow->set_BlurRadius(4.0);
shadow->set_Direction(45.0f);
shadow->set_Distance(3);
shadow->set_RectangleAlign(RectangleAlignment::TopLeft);
shadow->get_ShadowColor()->set_PresetColor(PresetColor::Black);

// نوشتن ارائه بر روی دیسک
pres->Save(u"pres_out.pptx", SaveFormat::Pptx);
```

## **اعمال اثر سایه داخلی بر اشکال**
مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
2. مرجع اسلاید را به‌دست آورید.  
3. یک AutoShape از نوع Rectangle اضافه کنید.  
4. InnerShadowEffect را فعال کنید.  
5. تمام پارامترهای ضروری را تنظیم کنید.  
6. ColorType را به Scheme تنظیم کنید.  
7. رنگ Scheme را تعیین کنید.  
8. ارائه را به‌صورت فایل [PPTX](https://docs.fileformat.com/presentation/pptx/) ذخیره کنید.

این کد نمونه (بر پایهٔ مراحل بالا) نشان می‌دهد چگونه یک کانکتور بین دو شکل در C++ اضافه کنید:

``` cpp
#include <DOM/ColorType.h>
#include <DOM/Effects/IInnerShadow.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
// دریافت مرجع اسلاید
auto slide = presentation->get_Slides()->idx_get(0);

// افزودن AutoShape از نوع Rectangle
auto ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 400.0f, 300.0f);
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// افزودن TextFrame به Rectangle
ashp->AddTextFrame(u"Aspose TextBox");
auto port = ashp->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
auto pf = port->get_PortionFormat();
pf->set_FontHeight(50.0f);

// فعال‌سازی InnerShadowEffect    
auto ef = pf->get_EffectFormat();
ef->EnableInnerShadowEffect();

// تنظیم تمام پارامترهای ضروری
auto shadow = ef->get_InnerShadowEffect();
shadow->set_BlurRadius(8.0);
shadow->set_Direction(90.0F);
shadow->set_Distance(6.0);
shadow->get_ShadowColor()->set_B(189);

// تنظیم ColorType به Scheme
shadow->get_ShadowColor()->set_ColorType(ColorType::Scheme);

// تنظیم رنگ Scheme
shadow->get_ShadowColor()->set_SchemeColor(SchemeColor::Accent1);

// ذخیره‌سازی ارائه
presentation->Save(u"WordArt_out.pptx", SaveFormat::Pptx);
```

## **سؤالات متداول**

### آیا می‌توانم اثرات WordArt را با فونت‌ها یا اسکریپت‌های مختلف (مانند عربی، چینی) استفاده کنم؟

بله، Aspose.Slides از یونیکود پشتیبانی می‌کند و با تمام فونت‌ها و اسکریپت‌های اصلی کار می‌کند. اثرات WordArt مانند سایه، پر و خط دور می‌توانند صرف‌نظر از زبان اعمال شوند، هرچند در دسترس بودن فونت و رندرینگ ممکن است به فونت‌های سیستم وابسته باشد.

### آیا می‌توانم اثرات WordArt را بر عناصر ماستر اسلاید اعمال کنم؟

بله، می‌توانید اثرات WordArt را بر اشکال در اسلایدهای ماستر، از جمله فریم‌های عنوان، فوترها یا متن پس‌زمینه اعمال کنید. تغییرات اعمال‌شده بر طرح ماستر در تمام اسلایدهای مرتبط منعکس می‌شود.

### آیا اثرات WordArt بر اندازهٔ فایل ارائه تأثیر می‌گذارند؟

به‌طور جزئی. اثراتی نظیر سایه‌ها، درخشندگی‌ها و پرهای گرادیان ممکن است اندازهٔ فایل را به‌دلیل افزودن متادیتای قالب‌بندی کمی افزایش دهند، اما تفاوت معمولاً ناچیز است.

### آیا می‌توانم پیش‌نمایش نتیجهٔ اثرات WordArt را بدون ذخیرهٔ ارائه ببینم؟

بله، می‌توانید اسلایدهای حاوی WordArt را به تصویر (مثلاً PNG یا JPEG) رندر کنید با استفاده از متد `GetImage` از اینترفیس‌های [IShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/) یا [ISlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/). این امکان را می‌دهد تا نتیجه را به‌صورت در‑حافظه یا روی صفحه نمایش پیش‌نمایش کنید قبل از ذخیره یا خروجی گرفتن از ارائه تمام‌عیار.