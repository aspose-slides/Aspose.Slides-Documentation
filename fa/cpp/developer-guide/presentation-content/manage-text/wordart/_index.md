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
- افکت نمایش
- افکت تاب
- تبدیل WordArt
- افکت سه‌بعدی
- افکت سایه خارجی
- افکت سایه داخلی
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی افکت‌های WordArt در Aspose.Slides برای C++. این راهنمای گام‌به‌گام به توسعه‌دهندگان کمک می‌کند تا ارائه‌ها را با متن حرفه‌ای در C++ بهبود بخشند."
---
## **نمای کلی**

افکت‌های WordArt به شما امکان می‌دهند متن‌های بصری جذاب و استیلیزه را به ارائه‌های PowerPoint خود اضافه کنید. با Aspose.Slides، توسعه‌دهندگان می‌توانند به‌طور برنامه‌نویسی WordArt را همانند Microsoft PowerPoint ایجاد، سفارشی‌سازی و مدیریت کنند—بدون نیاز به نصب Office. این مقاله نمای کلی کار با WordArt را ارائه می‌دهد، از جمله نحوه اعمال تبدیل‌های متنی، سبک‌های پرکننده، خطوط حاشیه، سایه‌ها و سایر گزینه‌های قالب‌بندی برای ایجاد محتوای ارائه‌ای ابرازگرتر و جذاب‌تر. WordArt به شما اجازه می‌دهد متن را به عنوان یک شیء گرافیکی در نظر بگیرید. این شامل افکت‌ها یا تغییرات ویژه‌ای است که بر متن اعمال می‌شود تا جذاب‌تر یا قابل توجه‌تر شود.

## **ایجاد یک الگوی ساده WordArt و اعمال آن بر متن**

**استفاده از Aspose.Slides** 

در ابتدا، با استفاده از این کد C++ یک متن ساده ایجاد می‌کنیم: 

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```

حال، با استفاده از این کد ارتفاع فونت متن را به مقدار بزرگتری تنظیم می‌کنیم تا افکت واضح‌تر باشد: 

``` cpp 
auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

**استفاده از Microsoft PowerPoint**

به منوی افکت‌های WordArt در Microsoft PowerPoint مراجعه کنید: 

![todo:image_alt_text](image-20200930113926-1.png)

از منوی سمت راست می‌توانید یک افکت WordArt پیش‌تعریف‌شده را انتخاب کنید. از منوی سمت چپ می‌توانید تنظیمات یک WordArt جدید را مشخص کنید. 

در ادامه برخی از پارامترها یا گزینه‌های در دسترس آمده است: 

![todo:image_alt_text](image-20200930114015-3.png)

**استفاده از Aspose.Slides** 

در اینجا، با استفاده از این کد رنگ الگوی SmallGrid را بر متن اعمال می‌کنیم و یک حاشیه متن سیاه به‌عرض ۱ اضافه می‌کنیم: 

``` cpp 
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

## **اعمال افکت‌های دیگر WordArt**

**استفاده از Microsoft PowerPoint** 

از رابط برنامه می‌توانید این افکت‌ها را بر متن، بلوک متن، شکل یا عنصر مشابهی اعمال کنید: 

![todo:image_alt_text](image-20200930114129-5.png)

به‌عنوان مثال، افکت‌های سایه، انعکاس و تاب می‌توانند بر متن اعمال شوند؛ افکت‌های قالب‌بندی ۳ بعدی و چرخش ۳ بعدی می‌توانند بر بلوک متن اعمال شوند؛ ویژگی لبه‌های نرم می‌تواند بر یک شیء Shape اعمال شود (هنوز زمانی که هیچ ویژگی قالب‌بندی ۳ بعدی تنظیم نشده باشد، اثر دارد). 

### **اعمال افکت‌های سایه بر متن** 

در اینجا، قصد داریم فقط ویژگی‌های مربوط به متن را تنظیم کنیم. با استفاده از این کد C++ افکت سایه را بر متن اعمال می‌کنیم: 

``` cpp 
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

با PresetShadow می‌توانید برای متن سایه‌ای (با استفاده از مقادیر پیش‌تنظیم) اعمال کنید. 

**استفاده از Microsoft PowerPoint** 

در PowerPoint می‌توانید از یک نوع سایه استفاده کنید. در اینجا یک مثال آورده شده است: 

![todo:image_alt_text](image-20200930114225-6.png)

**استفاده از Aspose.Slides** 

در واقع Aspose.Slides به شما اجازه می‌دهد دو نوع سایه را به‌طور همزمان اعمال کنید: InnerShadow و PresetShadow. 

**Notes:** 

- زمانی که OuterShadow و PresetShadow همزمان استفاده شوند، فقط افکت OuterShadow اعمال می‌شود. 
- اگر OuterShadow و InnerShadow همزمان استفاده شوند، افکت نهایی یا اعمال‌شده بستگی به نسخه PowerPoint دارد. به‌عنوان مثال، در PowerPoint 2013 اثر دو برابر می‌شود؛ اما در PowerPoint 2007، افکت OuterShadow اعمال می‌شود. 

### **اعمال افکت‌های انعکاس** 

با استفاده از این نمونه کد C++ یک انعکاس به متن اضافه می‌کنیم: 

``` cpp 
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

### **اعمال افکت‌های تاب** 

با استفاده از این کد، افکت تاب را بر متن اعمال می‌کنیم تا درخشان یا برجسته شود: 

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_R(255);
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```

نتیجه عملیات: 

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

شما می‌توانید پارامترهای سایه، نمایش و تاب را تغییر دهید. ویژگی‌های افکت‌ها برای هر بخش از متن به‌صورت جداگانه تنظیم می‌شوند. 

{{% /alert %}} 

### **استفاده از تبدیلات در WordArt** 

ما از متد set_Transform (که بر کل بلوک متن اعمال می‌شود) با این کد استفاده می‌کنیم: 

``` cpp 
textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

نتیجه: 

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

هر دو Microsoft PowerPoint و Aspose.Slides برای C++ تعداد محدودی از انواع تبدیلات پیش‌تعریف‌شده را ارائه می‌دهند. 

{{% /alert %}} 

**استفاده از PowerPoint** 

برای دسترسی به انواع تبدیلات پیش‌تعریف‌شده، به مسیر زیر بروید: **Format** -> **TextEffect** -> **Transform** 

**استفاده از Aspose.Slides** 

برای انتخاب نوع تبدیل، از enum TextShapeType استفاده کنید. 

### **اعمال افکت‌های ۳ بعدی بر متن و اشکال** 

ما با استفاده از این کد نمونه یک افکت ۳ بعدی به شکل متن اعمال می‌کنیم: 

``` cpp 
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

متن حاصل و شکل آن: 

![todo:image_alt_text](image-20200930114816-9.png)

ما با این کد C++ افکت ۳ بعدی را بر متن اعمال می‌کنیم: 

``` cpp 
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

{{% alert color="primary" %}} 

اعمال افکت‌های ۳ بعدی بر متون یا اشکال آن‌ها و تعامل بین افکت‌ها بر پایه قوانینی خاص انجام می‌شود. 

یک صحنه برای متن و شکلی که متن را در خود دارد در نظر بگیرید. افکت ۳ بعدی شامل نمایش شیء ۳ بعدی و صحنه‌ای است که شیء در آن قرار گرفته است. 

- زمانی که صحنه برای هر دو شکل و متن تنظیم شده باشد، صحنه شکل اولویت بالاتری دارد—صحنه متن نادیده گرفته می‌شود. 
- اگر شکل صحنه خاص خود را نداشته باشد اما نمای ۳ بعدی داشته باشد، صحنه متن استفاده می‌شود. 
- در غیر این صورت—وقتی شکل در اصل افکت ۳ بعدی ندارد—شکل صاف است و افکت ۳ بعدی فقط بر متن اعمال می‌شود. 

این توصیفات مربوط به متدهای ThreeDFormat.getLightRig() و ThreeDFormat.getCamera() می‌باشند. 

{{% /alert %}} 

## **اعمال افکت‌های سایه خارجی بر اشکال** 
Aspose.Slides for C++ کلاس‌های [**IOuterShadow**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.effects.i_outer_shadow) و [**IInnerShadow**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.effects.i_inner_shadow) را فراهم می‌کند که به شما امکان می‌دهند افکت‌های سایه را بر متنی که توسط TextFrame حمل می‌شود اعمال کنید. این مراحل را دنبال کنید: 

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید. 
2. با استفاده از ایندکس، مرجع یک اسلاید را به دست آورید. 
3. یک AutoShape از نوع Rectangle را به اسلاید اضافه کنید. 
4. به TextFrame مرتبط با AutoShape دسترسی پیدا کنید. 
5. FillType AutoShape را به NoFill تنظیم کنید. 
6. یک نمونه از کلاس OuterShadow ایجاد کنید 
7. BlurRadius سایه را تنظیم کنید. 
8. Direction سایه را تنظیم کنید. 
9. Distance سایه را تنظیم کنید. 
10. RectanglelAlign را به TopLeft تنظیم کنید. 
11. PresetColor سایه را به Black تنظیم کنید. 
12. ارائه را به صورت فایل PPTX ذخیره کنید. 

این کد نمونه در C++—اجرای مراحل بالا—نحوه اعمال افکت سایه خارجی بر متن را نشان می‌دهد: 

``` cpp
auto pres = System::MakeObject<Presentation>();
// دریافت مرجع اسلاید
auto sld = pres->get_Slides()->idx_get(0);

// افزودن AutoShape از نوع Rectangle
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// افزودن TextFrame به Rectangle
ashp->AddTextFrame(u"Aspose TextBox");

// غیرفعال کردن پر کردن شکل در صورتی که بخواهیم سایه متن را دریافت کنیم
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// افزودن سایه خارجی و تنظیم تمام پارامترهای لازم
ashp->get_EffectFormat()->EnableOuterShadowEffect();
auto shadow = ashp->get_EffectFormat()->get_OuterShadowEffect();
shadow->set_BlurRadius(4.0);
shadow->set_Direction(45.0f);
shadow->set_Distance(3);
shadow->set_RectangleAlign(RectangleAlignment::TopLeft);
shadow->get_ShadowColor()->set_PresetColor(PresetColor::Black);

// نوشتن ارائه در دیسک
pres->Save(u"pres_out.pptx", SaveFormat::Pptx);
```

## **اعمال افکت‌های سایه داخلی بر اشکال** 
این مراحل را دنبال کنید: 

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید. 
2. مرجع اسلاید را دریافت کنید. 
3. یک AutoShape از نوع Rectangle اضافه کنید. 
4. InnerShadowEffect را فعال کنید. 
5. تمام پارامترهای لازم را تنظیم کنید. 
6. ColorType را به Scheme تنظیم کنید. 
7. Scheme Color را تنظیم کنید. 
8. ارائه را به صورت فایل [PPTX](https://docs.fileformat.com/presentation/pptx/) ذخیره کنید. 

این کد نمونه (بر پایه مراحل بالا) نشان می‌دهد چگونه یک اتصالگر بین دو شکل در C++ اضافه کنید: 

``` cpp
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

// تنظیم تمام پارامترهای لازم
auto shadow = ef->get_InnerShadowEffect();
shadow->set_BlurRadius(8.0);
shadow->set_Direction(90.0F);
shadow->set_Distance(6.0);
shadow->get_ShadowColor()->set_B(189);

// تنظیم ColorType به عنوان Scheme
shadow->get_ShadowColor()->set_ColorType(ColorType::Scheme);

// تنظیم رنگ Scheme
shadow->get_ShadowColor()->set_SchemeColor(SchemeColor::Accent1);

// ذخیره ارائه
presentation->Save(u"WordArt_out.pptx", SaveFormat::Pptx);
```

## **FAQ** 

**آیا می‌توانم افکت‌های WordArt را با فونت‌ها یا اسکریپت‌های مختلف (مانند عربی، چینی) استفاده کنم؟**  

بله، Aspose.Slides از یونیکد پشتیبانی می‌کند و با تمام فونت‌ها و اسکریپت‌های عمده کار می‌کند. افکت‌های WordArt مانند سایه، پرکننده و خط‌مرز می‌توانند بدون توجه به زبان اعمال شوند، اگرچه در دسترس بودن فونت و رندرینگ ممکن است به فونت‌های سیستم بستگی داشته باشد.  

**آیا می‌توانم افکت‌های WordArt را بر عناصر اسلاید مستر اعمال کنم؟**  

بله، می‌توانید افکت‌های WordArt را بر اشکال موجود در اسلایدهای مستر، از جمله نگهدارنده‌های عنوان، فوترها یا متن پس‌زمینه اعمال کنید. تغییرات اعمال‌شده بر طرح مستر در تمام اسلایدهای مرتبط بازتاب می‌یابد.  

**آیا افکت‌های WordArt بر حجم فایل ارائه تأثیر می‌گذارند؟**  

به‌طور جزئی. افکت‌های WordArt مانند سایه‌ها، تاب‌ها و پرکننده‌های گرادیان ممکن است به دلیل اضافه شدن متادیتای قالب‌بندی حجم فایل را کمی افزایش دهند، اما این تفاوت معمولاً ناچیز است.  

**آیا می‌توانم نتیجه افکت‌های WordArt را بدون ذخیره ارائه پیش‌نمایش کنم؟**  

بله، می‌توانید اسلایدهای حاوی WordArt را به تصاویر (مانند PNG، JPEG) رندر کنید با استفاده از متد `GetImage` از رابط‌های [IShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/) یا [ISlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/) . این امکان پیش‌نمایش نتیجه در حافظه یا روی صفحه نمایش قبل از ذخیره یا خروجی گرفتن از ارائه کامل را فراهم می‌کند.