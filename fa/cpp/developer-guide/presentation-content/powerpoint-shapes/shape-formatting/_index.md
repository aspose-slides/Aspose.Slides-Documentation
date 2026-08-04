---
title: قالب‌بندی اشکال PowerPoint در C++
linktitle: قالب‌بندی اشکال
type: docs
weight: 20
url: /fa/cpp/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- اثر اسکچ
- خط شکل اسکچ
- قالب‌بندی سبک اتصال
- پر کردن گرادیان
- پر کردن الگو
- پر کردن تصویر
- پر کردن بافت
- پر کردن رنگ صلب
- شفافیت شکل
- چرخاندن شکل
- اثر برجسته‌سازی 3D
- اثر چرخش 3D
- بازنشانی قالب‌بندی
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه با استفاده از Aspose.Slides اشکال PowerPoint را در C++ قالب‌بندی کنید—استایل‌های پر کردن، خط و اثر را برای فایل‌های PPT، PPTX و ODP با دقت و کنترل کامل تنظیم کنید."
---
## **مقدمه**

در PowerPoint می‌توانید اشکال را به اسلایدها اضافه کنید. چون اشکال از خطوط تشکیل شده‌اند، می‌توانید با تغییر یا اعمال افکت‌ها بر روی خطوط آن‌ها را قالب‌بندی کنید. همچنین می‌توانید با تعیین تنظیماتی که پرکردن داخلی آن‌ها را کنترل می‌کند، اشکال را قالب‌بندی کنید.

![فرمت‌سازی شکل در PowerPoint](format-shape-powerpoint.png)

Aspose.Slides برای C++ رابط‌ها و متدهایی ارائه می‌دهد که به شما امکان می‌دهد اشکال را با همان گزینه‌های موجود در PowerPoint قالب‌بندی کنید.

## **قالب‌بندی خطوط**

با استفاده از Aspose.Slides می‌توانید برای یک شکل سبک خط سفارشی تعیین کنید. مراحل زیر این فرایند را شرح می‌دهند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس، به یک اسلاید ارجاع بگیرید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. [قالب خط](https://reference.aspose.com/slides/fa/cpp/aspose.slides/linestyle/) شکل را تنظیم کنید.
1. عرض خط را تنظیم کنید.
1. [قالب خط چین](https://reference.aspose.com/slides/fa/cpp/aspose.slides/linedashstyle/) خط را تنظیم کنید.
1. رنگ خط برای شکل را تنظیم کنید.
1. ارائه اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

کد زیر نحوه قالب‌بندی یک `AutoShape` مستطیلی را نشان می‌دهد:

```cpp
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
auto presentation = MakeObject<Presentation>();

// دریافت اولین اسلاید.
auto slide = presentation->get_Slide(0);

// افزودن یک شکل خودکار از نوع Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// تنظیم رنگ پر کردن برای شکل مستطیلی.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// اعمال قالب‌بندی بر خطوط مستطیل.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// تنظیم رنگ برای خط مستطیل.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// ذخیره فایل PPTX به دیسک.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![خطوط قالب‌بندی‌شده در ارائه](formatted-lines.png)

## **اعمال اثر Sketch بر خطوط شکل**

یک اثر Sketch باعث می‌شود خط شکل به صورت دست‌نویس به‌نظر برسد. از [IShape::get_LineFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_lineformat/) برای دسترسی به تنظیمات خط، [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilineformat/get_sketchformat/) برای دسترسی به تنظیمات Sketch و [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isketchformat/set_sketchtype/) برای انتخاب مقدار از شمارش‌گر [LineSketchType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/linesketchtype/) استفاده کنید.

کد C++ زیر نشان می‌دهد چگونه اثر [LineSketchType::Curved](https://reference.aspose.com/slides/fa/cpp/aspose.slides/linesketchtype/) را اعمال، مقدار اختصاص داده‌شده را بخوانید و با [LineSketchType::None](https://reference.aspose.com/slides/fa/cpp/aspose.slides/linesketchtype/) اثر را حذف کنید:

```cpp
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
auto sketchFormat = shape->get_LineFormat()->get_SketchFormat();

// Apply a sketch effect.
sketchFormat->set_SketchType(LineSketchType::Curved);

// Read the sketch effect assigned directly to the shape.
auto explicitSketchType = sketchFormat->get_SketchType();
Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);

// Remove the sketch effect.
sketchFormat->set_SketchType(LineSketchType::None);

presentation->Dispose();
```

مقداری که توسط [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isketchformat/get_sketchtype/) بازگردانده می‌شود، تنظیمی است که مستقیماً به شکل اختصاص یافته است. اگر قالب‌بندی خط می‌تواند از یک تم، اسلاید اصلی یا اسلاید طرح‌بندی به ارث برسد، از [ILineFormat::GetEffective](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilineformat/geteffective/) استفاده کنید، به [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/) دسترسی پیدا کنید و [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/) را بخوانید. مقدار مؤثر قالب‌بندی واقعاً پس از رفع ارث‌بری اعمال شده را نشان می‌دهد:

```cpp
auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto lineFormat = shape->get_LineFormat();

auto explicitSketchType = lineFormat->get_SketchFormat()->get_SketchType();
auto effectiveLineFormat = lineFormat->GetEffective();
auto effectiveSketchType = effectiveLineFormat->get_SketchFormat()->get_SketchType();

Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
Console::WriteLine(u"Effective sketch type: {0}", effectiveSketchType);

presentation->Dispose();
```

## **قالب‌بندی سبک‌های اتصال (Join Styles)**

سه گزینه نوع اتصال وجود دارد:

* Round
* Miter
* Bevel

به‌طور پیش‌فرض، هنگامی که PowerPoint دو خط را در یک زاویه (مانند گوشه یک شکل) به هم وصل می‌کند، از تنظیم **Round** استفاده می‌کند. اما اگر شما شکلی با زوایای تیز می‌کشید، ممکن است گزینه **Miter** را ترجیح دهید.

![سبک اتصال در ارائه](join-style-powerpoint.png)

کد C++ زیر نشان می‌دهد چگونه سه مستطیل (همان‌طور که در تصویر بالا نشان داده شده) با استفاده از تنظیمات Join Type‌های Miter، Bevel و Round ایجاد شدند:

```cpp
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
auto presentation = MakeObject<Presentation>();

// دریافت اولین اسلاید.
auto slide = presentation->get_Slide(0);

// افزودن سه شکل خودکار از نوع Rectangle.
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// تنظیم رنگ پر کردن برای هر شکل مستطیلی.
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// تنظیم عرض خط.
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// تنظیم رنگ برای خط هر مستطیل.
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// تنظیم سبک اتصال.
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// افزودن متن به هر مستطیل.
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// ذخیره فایل PPTX به دیسک.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **پر کردن گرادیان (Gradient Fill)**

در PowerPoint، Gradient Fill یک گزینه قالب‌بندی است که به شما امکان می‌دهد ترکیبی پیوسته از رنگ‌ها را بر روی یک شکل اعمال کنید. به‌عنوان مثال، می‌توانید دو یا چند رنگ را به‌طوری که یکی به تدریج به دیگری تبدیل شود، اعمال کنید.

در اینجا نحوه اعمال پر کردن گرادیان به یک شکل با استفاده از Aspose.Slides آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس، به یک اسلاید ارجاع بگیرید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. `FillType` شکل را به `Gradient` تنظیم کنید.
1. دو رنگ مورد نظر خود را با موقعیت‌های تعریف‌شده با استفاده از متدهای `Add` از مجموعه‌گرادیان که توسط رابط [IGradientFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/igradientformat/) ارائه می‌شود، اضافه کنید.
1. ارائه اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

کد C++ زیر نحوه اعمال افکت پر کردن گرادیان به یک بیضی را نشان می‌دهد:

```cpp
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
auto presentation = MakeObject<Presentation>();

// دریافت اولین اسلاید.
auto slide = presentation->get_Slide(0);

// افزودن یک شکل خودکار از نوع Ellipse.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// اعمال قالب‌بندی گرادیان به بیضی.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// تنظیم جهت گرادیان.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// افزودن دو نقطه توقف گرادیان.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// ذخیره فایل PPTX به دیسک.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![بیضی با پر کردن گرادیان](gradient-fill.png)

## **پر کردن الگو (Pattern Fill)**

در PowerPoint، Pattern Fill یک گزینه قالب‌بندی است که به شما امکان می‌دهد یک طرح دو رنگی—مانند نقطه‌ها، نوارها، خط‌های متقاطع یا شطرنجی—را بر روی یک شکل اعمال کنید. می‌توانید رنگ‌های سفارشی برای پیش‌زمینه و پس‌زمینه الگو انتخاب کنید.

Aspose.Slides بیش از ۴۵ سبک الگوی پیش‌تعریف‌شده ارائه می‌دهد که می‌توانید به اشکال اعمال کنید تا ظاهر ارائه‌های خود را تقویت کنید. حتی پس از انتخاب یک الگوی پیش‌تعریف‌شده، هنوز می‌توانید رنگ‌های دقیق موردنظر را مشخص کنید.

در اینجا نحوه اعمال پر کردن الگو به یک شکل با استفاده از Aspose.Slides آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس، به یک اسلاید ارجاع بگیرید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. `FillType` شکل را به `Pattern` تنظیم کنید.
1. یک سبک الگو از گزینه‌های پیش‌تعریف‌شده انتخاب کنید.
1. [Background Color](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipatternformat/get_backcolor/) الگو را تنظیم کنید.
1. [Foreground Color](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipatternformat/get_forecolor/) الگو را تنظیم کنید.
1. ارائه اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

کد C++ زیر نحوه اعمال پر کردن الگو به یک مستطیل را نشان می‌دهد:

```cpp
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
auto presentation = MakeObject<Presentation>();

// دریافت اولین اسلاید.
auto slide = presentation->get_Slide(0);

// افزودن یک شکل خودکار از نوع Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// تنظیم نوع پر کردن به Pattern.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// تنظیم سبک الگو.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// تنظیم رنگ پس‌زمینه و پیش‌زمینه الگو.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// ذخیره فایل PPTX به دیسک.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![مستطیل با پر کردن الگو](pattern-fill.png)

## **پر کردن تصویر (Picture Fill)**

در PowerPoint، Picture Fill یک گزینه قالب‌بندی است که به شما اجازه می‌دهد تصویری را داخل یک شکل قرار دهید—در واقع تصویر را به‌عنوان پس‌زمینه شکل استفاده کنید.

در اینجا نحوه استفاده از Aspose.Slides برای اعمال پر کردن تصویر به یک شکل آورده شده است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس، به یک اسلاید ارجاع بگیرید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. `FillType` شکل را به `Picture` تنظیم کنید.
1. حالت پر کردن تصویر را به `Tile` (یا حالت دیگری که ترجیح می‌دهید) تنظیم کنید.
1. یک شیء [IPPImage](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ippimage/) از تصویری که می‌خواهید استفاده کنید، ایجاد کنید.
1. تصویر را به متد `ISlidesPicture.set_Image` پاس دهید.
1. ارائه اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

فرض کنید فایلی به نام «lotus.png» با تصویر زیر داریم:

![تصویر لوتوس](lotus.png)

کد C++ زیر نحوه پر کردن یک شکل با تصویر را نشان می‌دهد:

```cpp
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
auto presentation = MakeObject<Presentation>();

// دریافت اولین اسلاید.
auto slide = presentation->get_Slide(0);

// افزودن یک شکل خودکار از نوع Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// تنظیم نوع پر کردن به Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// تنظیم حالت پر کردن تصویر.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// بارگذاری یک تصویر و افزودن آن به منابع ارائه.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// تنظیم تصویر.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// ذخیره فایل PPTX به دیسک.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![شکل با پر کردن تصویر](picture-fill.png)

### **Tile Picture As Texture**

اگر می‌خواهید یک تصویر کاشی‌شده را به‌عنوان بافت تنظیم کنید و رفتار کاشی‌گذاری را سفارشی کنید، می‌توانید از متدهای زیر رابط [IPictureFillFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/) و کلاس [PictureFillFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/picturefillformat/) استفاده کنید:

- [set_PictureFillMode](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): حالت پر کردن تصویر را به `Tile` یا `Stretch` تنظیم می‌کند.
- [set_TileAlignment](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): تراز کاشی‌ها درون شکل را مشخص می‌کند.
- [set_TileFlip](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/set_tileflip/): تعیین می‌کند آیا کاشی به‌صورت افقی، عمودی یا هر دو برعکس شود.
- [set_TileOffsetX](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): افست افقی کاشی (به پوینت) را از مبدای شکل تنظیم می‌کند.
- [set_TileOffsetY](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): افست عمودی کاشی (به پوینت) را از مبدای شکل تنظیم می‌کند.
- [set_TileScaleX](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): مقیاس افقی کاشی را به‌صورت درصد تعریف می‌کند.
- [set_TileScaleY](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): مقیاس عمودی کاشی را به‌صورت درصد تعریف می‌کند.

کد نمونه زیر نشان می‌دهد چگونه یک شکل مستطیلی با پر کردن تصویر کاشی‌شده اضافه کنید و گزینه‌های کاشی را پیکربندی کنید:

```cpp
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
auto presentation = MakeObject<Presentation>();

// دریافت اولین اسلاید.
auto firstSlide = presentation->get_Slide(0);

// افزودن یک شکل خودکار مستطیلی.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// تنظیم نوع پر کردن شکل به Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// بارگذاری تصویر و افزودن آن به منابع ارائه.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// اختصاص تصویر به شکل.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// پیکربندی حالت پر کردن تصویر و خواص کاشی‌گذاری.
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// ذخیره فایل PPTX به دیسک.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![گزینه‌های کاشی](tile-options.png)

## **پر کردن رنگ صلب (Solid Color Fill)**

در PowerPoint، Solid Color Fill یک گزینه قالب‌بندی است که یک شکل را با یک رنگ یکدست پر می‌کند. این رنگ پس‌زمینه ساده بدون هیچ‌گونه گرادیان، بافت یا الگوئی اعمال می‌شود.

برای اعمال پر کردن رنگ صلب به یک شکل با استفاده از Aspose.Slides، این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس، به یک اسلاید ارجاع بگیرید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. `FillType` شکل را به `Solid` تنظیم کنید.
1. رنگ پر کردن موردنظر خود را به شکل اختصاص دهید.
1. ارائه اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

کد C++ زیر نحوه اعمال پر کردن رنگ صلب به یک مستطیل در اسلاید PowerPoint را نشان می‌دهد:

```cpp
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
auto presentation = MakeObject<Presentation>();

// دریافت اولین اسلاید.
auto slide = presentation->get_Slide(0);

// افزودن یک شکل خودکار از نوع Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// تنظیم نوع پر کردن به Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// تنظیم رنگ پر کردن.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// ذخیره فایل PPTX به دیسک.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![شکل با پر کردن رنگ صلب](solid-color-fill.png)

## **تنظیم شفافیت (Set Transparency)**

در PowerPoint، زمانی که پر کردن رنگ صلب، گرادیان، تصویر یا بافت را بر روی اشکال اعمال می‌کنید، می‌توانید سطح شفافیتی را تنظیم کنید تا مقدار انتساب داده‌شده به شفافیت (opacity) را کنترل کنید. مقدار شفافیت بالاتر باعث می‌شود شکل بیشتر شفاف شود و پس‌زمینه یا اشیای زیرین به‌صورت جزئی دیده شوند.

Aspose.Slides به شما اجازه می‌دهد سطوح شفافیت را با تنظیم مقدار آلفا (alpha) در رنگ استفاده‌شده برای پر کردن تنظیم کنید. نحوه انجام این کار به‌صورت زیر است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس، به یک اسلاید ارجاع بگیرید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. `FillType` را به `Solid` تنظیم کنید.
1. از `Color` برای تعریف رنگی با شفافیت استفاده کنید (مولفه `alpha` شفافیت را کنترل می‌کند).
1. ارائه را ذخیره کنید.

کد C++ زیر نحوه اعمال رنگ پر کردن شفاف به یک مستطیل را نشان می‌دهد:

```cpp
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
auto presentation = MakeObject<Presentation>();

// دریافت اولین اسلاید.
auto slide = presentation->get_Slide(0);

// افزودن یک شکل خودکار مستطیل صلب.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// افزودن یک شکل خودکار مستطیل شفاف بر روی شکل صلب.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// ذخیره فایل PPTX به دیسک.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![شکل شفاف](shape-transparency.png)

## **چرخاندن اشکال (Rotate Shapes)**

Aspose.Slides به شما امکان می‌دهد اشکال را در ارائه‌های PowerPoint بچرخانید. این می‌تواند هنگام موقعیت‌دهی عناصر بصری با نیازهای خاص چینش یا طراحی مفید باشد.

برای چرخاندن یک شکل روی اسلاید، این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس، به یک اسلاید ارجاع بگیرید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی چرخش شکل را به زاویه دلخواه تنظیم کنید.
1. ارائه را ذخیره کنید.

کد C++ زیر نشان می‌دهد چگونه یک شکل را به‌صورت 5 درجه بچرخانید:

```cpp
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
auto presentation = MakeObject<Presentation>();

// دریافت اولین اسلاید.
auto slide = presentation->get_Slide(0);

// افزودن یک شکل خودکار از نوع Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// چرخاندن شکل به اندازه 5 درجه.
shape->set_Rotation(5);

// ذخیره فایل PPTX به دیسک.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![چرخش شکل](shape-rotation.png)

## **افزودن افکت برجسته‌سازی 3D (Add 3D Bevel Effects)**

Aspose.Slides به شما اجازه می‌دهد افکت‌های برجسته‌سازی 3D را به اشکال اعمال کنید با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/threedformat/).

برای افزودن افکت‌های برجسته‌سازی 3D به یک شکل، این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس، به یک اسلاید ارجاع بگیرید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/threedformat/) شکل را برای تعریف تنظیمات برجسته‌سازی پیکربندی کنید.
1. ارائه را ذخیره کنید.

کد C++ زیر نحوه اعمال افکت‌های برجسته‌سازی 3D به یک شکل را نشان می‌دهد:

```cpp
// یک نمونه از کلاس Presentation ایجاد کنید.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Add a shape to the slide.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// Set the shape's ThreeDFormat properties.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// Save the presentation as a PPTX file.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![افکت برجسته‌سازی 3D](3D-bevel-effect.png)

## **افزودن افکت‌های چرخش 3D (Add 3D Rotation Effects)**

Aspose.Slides به شما اجازه می‌دهد افکت‌های چرخش 3D را به اشکال اعمال کنید با پیکربندی ویژگی‌های [ThreeDFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/threedformat/).

برای اعمال چرخش 3D به یک شکل:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از اندیس، به یک اسلاید ارجاع بگیرید.
1. یک [IAutoShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iautoshape/) به اسلاید اضافه کنید.
1. از [set_CameraType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/icamera/set_cameratype/) و [set_LightType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilightrig/set_lighttype/) برای تعریف چرخش 3D استفاده کنید.
1. ارائه را ذخیره کنید.

کد C++ زیر نحوه اعمال افکت‌های چرخش 3D به یک شکل را نشان می‌دهد:

```cpp
// یک نمونه از کلاس Presentation ایجاد کنید.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// ارائه را به عنوان فایل PPTX ذخیره کنید.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![افکت چرخش 3D](3D-rotation-effect.png)

## **بازنشانی قالب‌بندی (Reset Formatting)**

کد C++ زیر نشان می‌دهد چگونه قالب‌بندی یک اسلاید را بازنشانی کنید و موقعیت، اندازه و قالب‌بندی تمام اشکالی که مکان‌گیرها (placeholders) روی [LayoutSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/layoutslide/) دارند را به تنظیمات پیش‌فرض برگردانید:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // بازنشانی هر شکلی در اسلاید که مکان‌گیر روی طرح‌بندی دارد.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **سوالات متداول (FAQ)**

**آیا قالب‌بندی شکل بر اندازه نهایی فایل ارائه تأثیر می‌گذارد؟**

به‌صورت حداقل. تصاویر و رسانه‌های جاسازی‌شده بیشترین فضا را اشغال می‌کنند، در حالی که پارامترهای شکل مانند رنگ‌ها، افکت‌ها و گرادیان‌ها به‌عنوان متادیتا ذخیره می‌شوند و تقریباً هیچ حجم اضافی اضافه نمی‌کنند.

**چگونه می‌توانم اشکالی را در یک اسلاید شناسایی کنم که قالب‌بندی یکسانی دارند تا بتوانم آن‌ها را گروه‌بندی کنم؟**

ویژگی‌های کلیدی قالب‌بندی هر شکل—پرکردن، خط و تنظیمات افکت—را مقایسه کنید. اگر تمام مقادیر متناظر برابر باشند، سبک آن‌ها را یک‌سان در نظر بگیرید و منطقی آن‌ها را گروه‌بندی کنید؛ این کار مدیریت سبک‌ها را در مرحله‌های بعد ساده‌تر می‌سازد.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی شکل را در فایلی جداگانه ذخیره کنم تا در ارائه‌های دیگر استفاده کنم؟**

بله. اشکال نمونه با سبک‌های دلخواه را در یک اسلاید قالب یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد ارائه جدید، قالب را باز کنید، اشکال سبک‌دار موردنیاز را کلون کنید و قالب‌بندی آن‌ها را در مکان‌های لازم اعمال کنید.