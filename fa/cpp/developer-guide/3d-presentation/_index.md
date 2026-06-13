---
title: ایجاد افکت‌های سه‌بعدی در ارائه‌ها با استفاده از C++
linktitle: ارائه سه‌بعدی
type: docs
weight: 232
url: /fa/cpp/3d-presentation/
keywords:
- PowerPoint سه‌بعدی
- ارائه سه‌بعدی
- چرخش سه‌بعدی
- عمق سه‌بعدی
- استخراج سه‌بعدی
- گرادیان سه‌بعدی
- متن سه‌بعدی
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "اعمال و رندر افکت‌های سه‌بعدی برای اشکال و متن PowerPoint در C++ با Aspose.Slides. پیکربندی دوربین، نورپردازی، مواد، استخراج، پرکردن‌ها و متن سه‌بعدی."
---
## **نمای کلی**

Aspose.Slides برای C++ می‌تواند قالب‌بندی سه‌بعدی شبیه به PowerPoint را برای اشکال و متن ایجاد، ویرایش، حفظ و رندر کند. این مقاله به اثرات سه‌بعدی نظیر چرخش، استخراج، لبه‌دار شدن، نورپردازی، مواد، پرکردن گرادیان یا تصویر و متن سه‌بعدی می‌پردازد.

{{% alert color="primary" %}}

این مقاله دربارهٔ اثرات قالب‌بندی سه‌بعدی روی اشکال و متن PowerPoint است. دربارهٔ درج یا ویرایش فایل‌های مدل سه‌بعدی مستقل نیست. هنگام استخراج اسلاید به تصویر، PDF یا HTML، Aspose.Slides این اثرات سه‌بعدی را به خروجی دو‌بعدی استخراج‌شده رندر می‌کند.

{{% /alert %}}

## **مفاهیم قالب‌بندی سه‌بعدی**

از متد [get_ThreeDFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_threedformat/) رابط [IShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/) برای اعمال قالب‌بندی سه‌بعدی به یک شکل استفاده کنید. این متد یک شیء از نوع [IThreeDFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/) را برمی‌گرداند که صحنهٔ سه‌بعدی آن شکل را کنترل می‌کند.

برای متن، از متد [get_ThreeDFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframeformat/get_threedformat/) رابط [ITextFrameFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframeformat/) استفاده کنید. این متد قالب‌بندی سه‌بعدی را به قاب متن اعمال می‌کند نه به بدنهٔ شکل.

متدهای مهم عبارتند از:

| متد | چه چیزی را کنترل می‌کند | زمان استفاده |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/get_camera/) | نقطه‌نظر، نوع دوربین پیش‌تنظیم، چرخش، زوم و پرسپکتیو. | چرخاندن شیء در فضای سه‌بعدی یا تطبیق با پیش‌تنظیم چرخش سه‌بعدی PowerPoint. |
| [get_LightRig](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/get_lightrig/) | پیش‌تنظیم نور، جهت و چرخش نور. | تغییر نحوهٔ ظاهر شدن نقاط نورانی و سایه‌ها روی سطح سه‌بعدی. |
| [set_Material](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/set_material/) | مواد سطح، مانند صاف، مات، پلاستیک یا فلز. | جعل ظاهر همان هندسه به صورت صاف‌تر، نرم‌تر، براق یا فلزی. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | فاصلهٔ گسترش شکل به سمت عقب از سطح جلویی. | تبدیل یک شکل صاف به شیء سه‌بعدی مشهود. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | رنگ سمت‌های استخراج‌شده. | نمایش عمق یا هماهنگ‌سازی رنگ سمت‌ها با پرکردن جلویی. |
| [set_Depth](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/set_depth/) | عمق سه‌بعدی اضافی استفاده‌شده توسط قالب‌بندی سه‌بعدی PowerPoint. | تنظیم دقیق عمق برای اشکال یا متن، به‌ویژه همراه با تنظیمات لبه و مواد. |
| [get_BevelTop](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/get_beveltop/) و [get_BevelBottom](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | لبه‌های برجسته یا گرد شده روی سطوح جلویی و پشتی. | افزودن لبهٔ نرم یا قالب‌ریزی شده به جای سطح صاف و تیز. |
| [get_ContourColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/get_contourcolor/) و [set_ContourWidth](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/set_contourwidth/) | حاشیهٔ اطراف شیء سه‌بعدی. | برجسته‌سازی مرز شیء در خروجی رندر شده. |

## **ایجاد یک شکل سه‌بعدی**

یک شکل معمولاً قبل از اینکه به طور قابل‌قبول سه‌بعدی به‌نظر برسد، به چهار نوع تنظیم نیاز دارد:

- تنظیمات دوربین، زیرا نمای پیش‌فرض جلو ممکن است استخراج را پنهان کند.
- تنظیمات نور، زیرا نورپردازی باعث قابل‌خواندن شدن سطوح و سمت‌ها می‌شود.
- تنظیمات مواد، زیرا سطح بر نحوهٔ رندر شدن نور تأثیر می‌گذارد.
- تنظیمات استخراج یا عمق، زیرا یک شکل صاف به ضخامت نیاز دارد.

مثال زیر یک مستطیل ایجاد می‌کند، متن را به سطح جلویی آن اضافه می‌کند، قالب‌بندی سه‌بعدی را اعمال می‌نماید، ارائه را به صورت PPTX ذخیره می‌کند و اسلاید را به تصویر PNG رندر می‌کند.

```cpp
const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto frontColor = System::Drawing::Color::get_CornflowerBlue();
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(frontColor);

auto extrusionColor = System::Drawing::Color::get_Blue();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"shape_3d.png");
thumbnail->Dispose();

presentation->Save(u"shape_3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

تصویر رندر شدهٔ اسلاید، مستطیل را به صورت یک بلوک سه‌بعدی ضخیم نشان می‌دهد:

![مستطیل سه‌بعدی آبی رندر شده با متن سه‌بعدی سفید روی سطح جلویی](img_01_01.png)

## **چرخاندن یک شکل با دوربین**

در PowerPoint، چرخش سه‌بعدی از پنل 3‑D Rotation پیکربندی می‌شود. مقادیر چرخش X، Y و Z معادل چرخشی هستند که از طریق API دوربین تنظیم می‌کنید.

![پنل چرخش 3‑D PowerPoint با مقادیر چرخش X، Y و Z برجسته‌شده](img_02_01.png)

در Aspose.Slides، نوع دوربین و چرخش را از طریق [IThreeDFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/) تنظیم کنید:

```cpp
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
```

از دوربین وقتی نیاز دارید دیدن‌گر شیء را تغییر دهید استفاده کنید. این کار هندسهٔ دو‌بعدی شکل را در اسلاید تغییر نمی‌دهد؛ فقط نقطهٔ نظر سه‌بعدی استفاده‌شده توسط PowerPoint و Aspose.Slides هنگام رندر را تغییر می‌دهد.

## **افزودن استخراج و عمق**

استخراج باعث می‌شود شکل با گسترش به پشت سطح جلویی ضخیم به‌نظر برسد. در PowerPoint، کنترل عمق این ضخامت قابل مشاهده را تنظیم می‌کند و کنترل رنگ رنگ سمت‌ها را تعیین می‌گردد.

![کنترل‌های عمق PowerPoint که به ویژگی‌های رنگ استخراج و ارتفاع استخراج نگاشت شده‌اند](img_02_02.png)

برای ضخامت [set_ExtrusionHeight](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/set_extrusionheight/) و برای رنگ سمت‌ها [get_ExtrusionColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) تنظیم کنید:

```cpp
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = System::Drawing::Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

وقتی نیاز به کار با مقدار عمق PowerPoint به‌صورت مستقیم یا ترکیب عمق با لبه، مواد و اثرات متن دارید، از [set_Depth](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/set_depth/) استفاده کنید. در بسیاری از سناریوهای شکل، `set_ExtrusionHeight` تنظیم واضح‌تری است زیرا مستقیماً ضخامت قابل مشاهدهٔ استخراج را بیان می‌کند.

## **استفاده از پرکردن گرادیان یا تصویر با اثرات سه‌بعدی**

قالب‌بندی سه‌بعدی مستقل از پرکردن شکل است. می‌توانید یک رنگ ثابت، گرادیان، الگو یا پرکردن تصویر را بر سطح جلویی اعمال کنید و همچنان از همان تنظیمات دوربین، نور، مواد و استخراج استفاده کنید.

این مثال یک پرکردن گرادیان به شکل اعمال می‌کند و برای سمت‌ها رنگ استخراج تیره‌تری تنظیم می‌نماید:

```cpp
const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto firstGradientColor = System::Drawing::Color::get_Blue();
auto secondGradientColor = System::Drawing::Color::get_Orange();
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, firstGradientColor);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, secondGradientColor);

auto extrusionColor = System::Drawing::Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"gradient_3d.png");
thumbnail->Dispose();

presentation->Dispose();
```

خروجی رندر شده گرادیان را روی سطح جلویی حفظ می‌کند و استخراج را به طور جداگانه رندر می‌کند:

![مستطیل سه‌بعدی رندر شده با پرکردن گرادیان آبی‑به‑نارنجی و استخراج نارنجی](img_02_03.png)

برای استفاده از پرکردن تصویر، تصویر را به ارائه اضافه کنید و به پرکردن شکل اختصاص دهید:

```cpp
auto imageData = System::IO::File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

auto extrusionColor = System::Drawing::Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

تصویر روی سطح جلویی رندر می‌شود، در حالی که استخراج به‌صورت سطح جانبی سه‌بعدی رندر می‌شود:

![مستطیل سه‌بعدی رندر شده با پرکردن عکس روی سطح جلویی و استخراج نارنجی](img_02_04.png)

## **اعمال قالب‌بندی سه‌بعدی به متن**

قالب‌بندی سه‌بعدی شکل بر بدن شکل تأثیر می‌گذارد. قالب‌بندی سه‌بعدی متن بر قاب متن تأثیر می‌گذارد. این برای اثرات شبیه WordArt مفید است، جایی که حروف نیاز به استخراج، مواد، نورپردازی و تنظیمات دوربین دارند.

مثال زیر متنی با پرکردن الگو ایجاد می‌کند، یک تبدیل WordArt اعمال می‌کند و تنظیمات سه‌بعدی را بر [ITextFrameFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframeformat/) پیکربندی می‌کند:

```cpp
const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);

auto foregroundColor = System::Drawing::Color::get_DarkOrange();
auto backgroundColor = System::Drawing::Color::get_White();
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(foregroundColor);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(backgroundColor);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::LargeGrid);

shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(128.0f);

auto textFrameFormat = shape->get_TextFrame()->get_TextFrameFormat();
textFrameFormat->set_Transform(TextShapeType::ArchUp);
textFrameFormat->get_ThreeDFormat()->set_ExtrusionHeight(3.5);
textFrameFormat->get_ThreeDFormat()->set_Depth(3.0);
textFrameFormat->get_ThreeDFormat()->set_Material(MaterialPresetType::Plastic);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);
textFrameFormat->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"text_3d.png");
thumbnail->Dispose();

presentation->Save(u"text_3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

متن به صورت حروف منحنی و استخراج‌شدهٔ سه‌بعدی رندر می‌شود:

![متن سه‌بعدی رندر شده با تبدیل WordArt قوسی، پرکردن الگوی نارنجی و استخراج تیره](img_02_05.png)

## **رفتار استخراج و رندرینگ**

Aspose.Slides قالب‌بندی سه‌بعدی را هنگام ذخیره در فرمت‌های PowerPoint مانند PPTX حفظ می‌کند. هنگام رندر یا استخراج به فرمت‌های ثابت‑چیدمان، صحنهٔ سه‌بعدی به‌صورت تصویر رستر یا به‌صورت نتیجهٔ دو‌بعدی در خروجی کشیده می‌شود. این مورد برای رندر اسلایدها به [PNG](/slides/fa/cpp/convert-powerpoint-to-png/)، استخراج به [PDF](/slides/fa/cpp/convert-powerpoint-to-pdf/)، استخراج به [HTML](/slides/fa/cpp/convert-powerpoint-to-html/)، یا تولید فریم‌ها برای [تبدیل ویدیو](/slides/fa/cpp/convert-powerpoint-to-video/) صادق است.

نکات مهم:

- تصاویر و PDFهای استخراج‌شده تعاملی نیستند. شیء پس از استخراج توسط بیننده قابل چرخش نیست.
- ظاهر نهایی به ترکیب دوربین، نور، مواد، استخراج، پرکردن و مقیاس اسلاید وابسته است.
- اگر نیاز به بررسی مقادیر قالب‌بندی ارث‌بری یا مبتنی بر تم دارید، [خواص مؤثر شکل](/slides/fa/cpp/shape-effective-properties/) را بخوانید.
- برخی فرمت‌های خروجی نمی‌توانند قالب‌بندی سه‌بعدی قابل ویرایش PowerPoint را ذخیره کنند. در آن فرمت‌ها، نتیجهٔ بصری رندر می‌شود نه به‌عنوان تنظیمات سه‌بعدی قابل ویرایش.

## **سوالات متداول**

**آیا Aspose.Slides می‌تواند ارائه‌های سه‌بعدی تعاملی ایجاد کند؟**

Aspose.Slides اثرات سه‌بعدی PowerPoint را برای اشکال و متن ایجاد و رندر می‌کند. این ابزار تصاویر، PDF یا صفحات HTML استخراج‌شده را به صحنه‌های سه‌بعدی تعاملی تبدیل نمی‌کند که کاربر بتواند آنها را بچرخاند. در فایل PPTX، قالب‌بندی سه‌بعدی در PowerPoint قابل ویرایش می‌ماند، به شرطی که فرمت آن را پشتیبانی کند.

**تفاوت بین مدل سه‌بعدی و اثر سه‌بعدی چیست؟**

یک مدل سه‌بعدی یک شیء سه‌بعدی مستقل است که به ارائه اضافه می‌شود. یک اثر سه‌بعدی قالب‌بندی‌ای است که بر یک شکل یا متن معمولی PowerPoint اعمال می‌شود، مانند چرخش، استخراج، لبه، نورپردازی و مواد. این مقاله به اثرات سه‌بعدی می‌پردازد.

**کدام تنظیمات برای داشتن یک شکل سه‌بعدی قابل مشاهده ضروری هستند؟**

حداقل باید یک چرخش دوربین و یا استخراج یا عمق تنظیم کنید. در عمل، تنظیم یک نور و مواد نیز ضروری است تا سطوح رندر شده روشنایی و سایه‌های واضحی داشته باشند.

**آیا می‌توانم اثرات سه‌بعدی را هم روی اشکال و هم روی متن اعمال کنم؟**

بله. برای بدنهٔ شکل از [IShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/) و برای متن از [ITextFrameFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframeformat/) استفاده کنید.

**آیا اثرات سه‌بعدی هنگام استخراج به تصویر، PDF، HTML یا فریم‌های ویدیو نمایش داده می‌شوند؟**

بله. Aspose.Slides اثرات سه‌بعدی را هنگام تولید تصاویر اسلاید، خروجی PDF، خروجی HTML و فریم‌های استفاده‌شده برای تبدیل ویدیو رندر می‌کند. خروجی استخراج‌شده شامل ظاهر رندر شده است، نه یک شیء سه‌بعدی قابل ویرایش.

**آیا می‌توانم مقادیر نهایی سه‌بعدی را پس از اعمال ارث‌بری و تنظیمات تم بخوانم؟**

بله. از API‌های قالب‌بندی مؤثر توصیف‌شده در [Shape Effective Properties](/slides/fa/cpp/shape-effective-properties/) برای خواندن دوربین نهایی، نور، لبه و مقادیر مرتبط سه‌بعدی استفاده کنید.