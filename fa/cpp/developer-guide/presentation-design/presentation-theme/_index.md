---
title: مدیریت تم‌های ارائه در C++
linktitle: تم ارائه
type: docs
weight: 10
url: /fa/cpp/presentation-theme/
keywords:
- تم پاورپوینت
- تم ارائه
- تم اسلاید
- تنظیم تم
- تغییر تم
- مدیریت تم
- رنگ تم
- پالت اضافی
- قلم تم
- سبک تم
- اثر تم
- پاورپوینت
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "تم‌های ارائه اصلی در Aspose.Slides برای C++ را برای ایجاد، سفارشی‌سازی و تبدیل فایل‌های پاورپوینت با برندسازی یکسان مدیریت کنید."
---
## **مقدمه**

یک تم ارائه ویژگی‌های عناصر طراحی را تعریف می‌کند. وقتی یک تم ارائه را انتخاب می‌کنید، در واقع مجموعه‌ای خاص از عناصر بصری و ویژگی‌های آن‌ها را برمی‌گزینید.

در پاورپوینت، یک تم شامل رنگ‌ها، [قلم‌ها](/slides/fa/cpp/powerpoint-fonts/)، [سبک‌های پس‌زمینه](/slides/fa/cpp/presentation-background/) و افکت‌ها است.

![theme-constituents](theme-constituents.png)

## **تغییر رنگ تم**

یک تم پاورپوینت از مجموعه خاصی از رنگ‌ها برای عناصر مختلف یک اسلاید استفاده می‌کند. اگر از رنگ‌ها راضی نیستید، می‌توانید با اعمال رنگ‌های جدید برای تم، آن‌ها را تغییر دهید. برای انتخاب رنگ جدید تم، Aspose.Slides مقادیر را تحت شمارشگر [SchemeColor](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28) ارائه می‌دهد.

این کد C++ نشان می‌دهد چگونه رنگ تاکید را برای یک تم تغییر دهید:

```c++
auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

می‌توانید مقدار مؤثر رنگ حاصل را به این روش تعیین کنید:

```c++
auto fillEffective = shape->get_FillFormat()->GetEffective();
    
Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (رنگ [A=255, R=128, G=100, B=162])
```

برای نشان دادن بیشتر عملیات تغییر رنگ، عنصر دیگری ایجاد می‌کنیم و رنگ تاکید (از عملیات اولیه) را به آن اختصاص می‌دهیم. سپس رنگ را در تم تغییر می‌دهیم:

```c++
auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);
    
otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```

رنگ جدید به‌صورت خودکار بر روی هر دو عنصر اعمال می‌شود.

### **تنظیم رنگ تم از یک پالت اضافی**

وقتی تبدیل‌های روشنایی را بر روی رنگ اصلی تم (1) اعمال می‌کنید، رنگ‌هایی از پالت اضافی (2) شکل می‌گیرند. سپس می‌توانید این رنگ‌های تم را تنظیم و دریافت کنید.

![additional-palette-colors](additional-palette-colors.png)

**1**- رنگ‌های اصلی تم

**2**- رنگ‌های پالت اضافی.

این کد C++ عملیاتی را نشان می‌دهد که در آن رنگ‌های پالت اضافی از رنگ اصلی تم به‌دست می‌آیند و سپس در اشکال استفاده می‌شوند:

```c++
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

// Accent 4
// اکسنت 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// Accent 4, Lighter 80%
 // اکسنت 4، روشن‌تر 80%
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// Accent 4, Lighter 60%
 // اکسنت 4، روشن‌تر 60%
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// Accent 4, Lighter 40%
 // اکسنت 4، روشن‌تر 40%
auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();

fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

// Accent 4, Darker 25%
 // اکسنت 4، تیره‌تر 25%
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// Accent 4, Darker 50%
 // اکسنت 4، تیره‌تر 50%
auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();

fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```

### **نقشه‌برداری `SchemeColor` به رنگ‌های `IColorScheme`**

هنگامی که با [SchemeColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides.schemecolor/) کار می‌کنید، ممکن است متوجه شوید که شامل مقادیر رنگ تم زیر است:

`Background1`, `Background2`, `Text1`, and `Text2`.

اما `Presentation::get_MasterTheme()::get_ColorScheme()`، [IColorScheme](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/icolorscheme/) را برمی‌گرداند که رنگ‌های مطابق را به شکل زیر نمایش می‌دهد:

`Dark1`, `Dark2`, `Light1`, and `Light2`.

این اختلاف فقط در نام‌گذاری است. این مقادیر به همان اسلات‌های رنگ تم اشاره دارند و نقشه‌برداری ثابت است:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هیچ تبدیل دینامیکی بین `Text`/`Background` و `Dark`/`Light` وجود ندارد. آن‌ها صرفاً اسامی دیگر برای همان رنگ‌های تم هستند.

این تفاوت نام‌گذاری از اصطلاحات Microsoft Office برمی‌آید. نسخه‌های قدیمی Office از `Dark 1`, `Light 1`, `Dark 2`, `Light 2` استفاده می‌کردند، در حالی که نسخه‌های جدید UI همان اسلات‌ها را به صورت `Text 1`, `Background 1`, `Text 2`, `Background 2` نشان می‌دهند.

## **تغییر قلم تم**

برای انتخاب قلم‌ها برای تم‌ها و مقاصد دیگر، Aspose.Slides از این شناسه‌های ویژه (مشابه آنچه در پاورپوینت استفاده می‌شود) بهره می‌گیرد:

* **+mn-lt** - قلم متن اصلی لاتین (قلم لاتین جزئی)
* **+mj-lt** - قلم عنوان لاتین (قلم لاتین اصلی)
* **+mn-ea** - قلم متن اصلی شرق آسیا (قلم شرق آسیا جزئی)
* **+mj-ea** - قلم متن اصلی شرق آسیا (قلم شرق آسیا اصلی)

این کد C++ نشان می‌دهد چگونه قلم لاتین را به یک عنصر تم اختصاص دهید:

```c++
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Theme text format");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

این کد C++ نشان می‌دهد چگونه قلم تم ارائه را تغییر دهید:

```c++
pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

قلم در تمام جعبه‌های متن به‌روز خواهد شد.

{{% alert color="primary" title="TIP" %}} 
ممکن است بخواهید [قلم‌های پاورپوینت](/slides/fa/cpp/powerpoint-fonts/) را ببینید.
{{% /alert %}}

## **تغییر سبک پس‌زمینه تم**

به‌صورت پیش‌فرض، برنامه پاورپوینت 12 پس‌زمینه از پیش تعریف‌شده ارائه می‌دهد اما تنها 3 مورد از این 12 پس‌زمینه در یک ارائه typical ذخیره می‌شود.

![todo:image_alt_text](presentation-design_8.png)

به‌عنوان مثال، پس از ذخیره یک ارائه در برنامه پاورپوینت، می‌توانید این کد C++ را اجرا کنید تا تعداد پس‌زمینه‌های از پیش تعریف‌شده در ارائه را بیابید:

```c++
auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Number of background fill styles for theme is {0}", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 
با استفاده از ویژگی [BackgroundFillStyles](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) از کلاس [FormatScheme](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.theme.i_format_scheme/) می‌توانید سبک پس‌زمینه را در یک تم پاورپوینت اضافه یا دسترسی پیدا کنید.
{{% /alert %}}

این کد C++ نشان می‌دهد چگونه پس‌زمینه برای یک ارائه تنظیم شود:

```c++
pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**راهنمای ایندکس**: 0 برای بدون پرکنش استفاده می‌شود. ایندکس از 1 شروع می‌شود.

{{% alert color="primary" title="TIP" %}} 
ممکن است بخواهید [پس‌زمینه پاورپوینت](/slides/fa/cpp/presentation-background/) را ببینید.
{{% /alert %}}

## **تغییر اثر تم**

یک تم پاورپوینت معمولاً 3 مقدار برای هر آرایه سبک دارد. این آرایه‌ها به 3 اثر ترکیب می‌شوند: ملایم، متوسط و شدید. به‌عنوان مثال، این نتیجه است وقتی اثرها بر روی یک شکل خاص اعمال می‌شوند:

![todo:image_alt_text](presentation-design_10.png)

با استفاده از 3 ویژگی ([FillStyles](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563), [LineStyles](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd), [EffectStyles](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)) از کلاس [FormatScheme](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.theme.i_format_scheme/) می‌توانید عناصر در یک تم را تغییر دهید (چنانکه انعطاف‌پذیری بیشتری نسبت به گزینه‌های پاورپوینت دارد).

این کد C++ نشان می‌دهد چگونه یک اثر تم را با تغییر بخش‌های عناصر تغییر دهید:

```c++
auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
        
pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```

تغییرات حاصل در رنگ پرکنش، نوع پرکنش، اثر سایه و غیره:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**آیا می‌توانم یک تم را بر روی یک اسلاید اعمال کنم بدون اینکه مستر را تغییر دهم؟**

بله. Aspose.Slides از بازنویسی تم در سطح اسلاید پشتیبانی می‌کند، بنابراین می‌توانید تم محلی را فقط به آن اسلاید اعمال کنید در حالی که تم مستر دست‌نخورده می‌ماند (از طریق [SlideThemeManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides.theme/slidethememanager/)).

**ایمن‌ترین روش برای انتقال تم از یک ارائه به ارائه دیگر چیست؟**

[کلون اسلایدها](/slides/fa/cpp/clone-slides/) همراه با مستر آن‌ها را به ارائه مقصد منتقل کنید. این کار مستر، طرح‌بندی‌ها و تم مرتبط را حفظ می‌کند تا ظاهر یکسان بماند.

**چگونه می‌توانم مقادیر «مؤثر» را پس از تمام ارث‌بری و بازنویسی‌ها ببینم؟**

از نماهای «مؤثر» API (مانند [/slides/fa/cpp/shape-effective-properties/](/slides/fa/cpp/shape-effective-properties/)) برای تم/رنگ/قلم/اثر استفاده کنید. این‌ها ویژگی‌های نهایی حل‌نشده پس از اعمال مستر و هر بازنویسی محلی را برمی‌گردانند.