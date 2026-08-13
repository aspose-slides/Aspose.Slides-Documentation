---
title: ایجاد افکت‌های سه‌بعدی در ارائه‌ها با استفاده از C++
linktitle: ارائه سه‌بعدی
type: docs
weight: 232
url: /fa/cpp/3d-presentation/
keywords:
- PowerPoint سه‌بعدی
- ارائهٔ سه‌بعدی
- چرخش سه‌بعدی
- عمق سه‌بعدی
- برآمدگی سه‌بعدی
- گرادیان سه‌بعدی
- متن سه‌بعدی
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "اعمال و رندر افکت‌های سه‌بعاد برای اشکال و متن PowerPoint در C++ با Aspose.Slides. پیکربندی دوربین، نورپردازی، ماده، برآمدگی، پرکننده‌ها و متن سه‌بعدی."
---
## **بررسی کلی**

Aspose.Slides for C++ می‌تواند قالب‌بندی سه‌بعدی شبیه به PowerPoint را برای اشکال و متن ایجاد، ویرایش، حفظ و رندر کند. این مقاله به اثرات سه‌بعدی مانند چرخش، برآمدگی، لبه‌گذاری، نورپردازی، مواد، پرکننده‌های گرادیان یا تصویری و متن سه‌بعدی می‌پردازد.

{{% alert color="info" %}}
این مقاله درباره اثرات قالب‌بندی سه‌بعدی بر روی اشکال و متن‌های PowerPoint است. در مورد درج یا ویرایش فایل‌های مدل سه‌بعدی مستقل نیست. هنگام صادرات اسلاید به تصویر، PDF یا HTML، Aspose.Slides این اثرات سه‌بعدی را به خروجی دو‑بعدی رندر می‌کند.
{{% /alert %}}

## **مفاهیم قالب‌بندی سه‌بعدی**

از متد [get_ThreeDFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_threedformat/) رابط‌ [IShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/) برای اعمال قالب‌بندی سه‌بعدی به یک شکل استفاده کنید. این متد یک شیء [IThreeDFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/) بر می‌گرداند که صحنهٔ سه‌بعدی آن شکل را کنترل می‌کند.

برای متن، از متد [get_ThreeDFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframeformat/get_threedformat/) رابط‌ [ITextFrameFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframeformat/) استفاده کنید. این کار قالب‌بندی سه‌بعدی را بر روی قاب متن اعمال می‌کند نه بر بدنهٔ شکل.

متدهای مهم عبارتند از:

| متد | چه چیزی را کنترل می‌کند | چه زمانی استفاده شود |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/get_camera/) | نقطه دید، نوع دوربین پیش‌فرض، چرخش، زوم و پرسپکتیو. | چرخاندن شی در فضای سه‌بعدی یا مطابقت با یک پیش‌تنظیم چرخش سه‌بعدی PowerPoint. |
| [get_LightRig](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/get_lightrig/) | پیش‌تنظیم نور، جهت و چرخش نور. | تغییر ظاهر نقاط نورانی و سایه‌ها بر روی سطح سه‌بعدی. |
| [set_Material](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/set_material/) | ماده سطح، مانند صاف، مات، پلاستیک یا متال. | به همان هندسه ظاهری صاف‌تر، نرم‌تر، براق یا متالیک بدهید. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | فاصله‌ای که شکل از سطح جلویی به عقب گسترش می‌یابد. | یک شکل صاف را به یک شیء سه‌بعدی واضحاً ضخیم تبدیل کنید. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | رنگ سمت‌های برآمده. | عمق را قابل دیدن کنید یا رنگ سمت‌ها را با پرکننده جلویی هماهنگ کنید. |
| [set_Depth](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/set_depth/) | عمق سه‌بعدی اضافی که توسط قالب‌بندی سه‌بعدی PowerPoint استفاده می‌شود. | عمق را برای اشکال یا متن دقیقاً تنظیم کنید، به‌ویژه همراه با تنظیمات لبه و ماده. |
| [get_BevelTop](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/get_beveltop/) and [get_BevelBottom](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | لبه‌های برجسته یا گرد شده بر روی سطوح جلویی و پشتی. | به‌جای یک سطح صاف و تیز، یک لبه نرم یا قالب‌دار اضافه کنید. |
| [get_ContourColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/get_contourcolor/) and [set_ContourWidth](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/set_contourwidth/) | خط مرزی اطراف شیء سه‌بعدی. | مرز شی را در خروجی رندر شده برجسته کنید. |

## **ایجاد یک شکل سه‌بعدی**

یک شکل معمولاً به چهار نوع تنظیم نیاز دارد تا به‌صورت قابل‌قبول سه‌بعدی به نظر برسد:

- تنظیمات دوربین، زیرا نمای پیش‌فرض جلویی ممکن است برآمدگی را پنهان کند.
- تنظیمات نور، زیرا نورپردازی باعث قابل‌خواندن شدن سطح‌ها و سمت‌ها می‌شود.
- تنظیمات ماده، زیرا سطح بر نحوه رندر نور تأثیر می‌گذارد.
- تنظیمات برآمدگی یا عمق، زیرا یک شکل صاف به ضخامت نیاز دارد.

مثال زیر یک مستطیل می‌سازد، متن را به سطح جلویی اضافه می‌کند، قالب‌بندی سه‌بعدی را اعمال می‌نماید، ارائه را به صورت PPTX ذخیره می‌کند و اسلاید را به تصویر PNG رندر می‌کند.

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

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

تصویر رندر شده اسلاید، مستطیل را به‌عنوان یک بلوک سه‌بعدی ضخیم نشان می‌دهد:

![مستطیل سه‌بعدی آبی رندر شده با متن سفید سه‌بعدی بر روی سطح جلویی](img_01_01.png)

## **چرخاندن یک شکل با دوربین**

در PowerPoint، چرخش سه‌بعدی از طریق پنجرهٔ چرخش سه‌بعدی تنظیم می‌شود. مقادیر چرخش X، Y و Z مطابق با چرخشی هستند که از طریق API دوربین تنظیم می‌کنید.

![پنجره چرخش سه‌بعدی PowerPoint با مقادیر چرخش X، Y و Z برجسته شده](img_02_01.png)

در Aspose.Slides، دوربین و چرخش را از طریق [IThreeDFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/) تنظیم کنید:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
```

از دوربین زمانی استفاده کنید که بخواهید نحوهٔ مشاهدهٔ شی توسط بیننده را تغییر دهید. این کار هندسهٔ دو‑بعدی شکل روی اسلاید را تغییر نمی‌دهد؛ تنها نقطهٔ دید سه‌بعدی استفاده‌شده توسط PowerPoint و Aspose.Slides هنگام رندر را تغییر می‌دهد.

## **اضافه کردن برآمدگی و عمق**

برآمدگی باعث می‌شود شکل به‌وسیلهٔ گسترش به پشت سطح جلویی ضخیم به‌نظر برسد. در PowerPoint، کنترل عمق این ضخامت قابل مشاهده را تنظیم می‌کند و کنترل رنگ، رنگ سمت‌های برآمده را تعیین می‌کند.

![کنترل‌های عمق PowerPoint مطابق با ویژگی‌های رنگ برآمدگی و ارتفاع برآمدگی](img_02_02.png)

برای ضخامت، [set_ExtrusionHeight](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/set_extrusionheight/) و برای رنگ سمت‌ها، [get_ExtrusionColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) را تنظیم کنید:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = System::Drawing::Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

از [set_Depth](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ithreedformat/set_depth/) زمانی استفاده کنید که نیاز به کار مستقیم با مقدار عمق PowerPoint داشته باشید یا عمق را همراه با لبه، ماده و اثرات متن ترکیب کنید. در بسیاری از سناریوهای شکل، `set_ExtrusionHeight` تنظیم واضح‌تری است زیرا مستقیماً برآمدگی قابل مشاهده را بیان می‌کند.

## **استفاده از پرکننده‌های گرادیان یا تصویری با اثرات سه‌بعدی**

قالب‌بندی سه‌بعدی مستقل از پرکنندهٔ شکل است. می‌توانید رنگ ثابت، گرادیان، الگو یا پرکنندهٔ تصویری را به سطح جلویی اعمال کنید و همچنان از همان تنظیمات دوربین، نور، ماده و برآمدگی استفاده کنید.

مثال زیر پرکنندهٔ گرادیان را به شکل اعمال می‌کند و رنگ برآمدگی سمت‌ها را تیره‌تر می‌کند:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

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

خروجی رندر شده گرادیان را بر روی سطح جلویی حفظ می‌کند و برآمدگی را به‌صورت جداگانه رندر می‌نماید:

![مستطیل سه‌بعدی رندر شده با پرکننده گرادیان آبی به نارنجی و برآمدگی نارنجی](img_02_03.png)

برای استفاده از پرکنندهٔ تصویری، تصویر را به ارائه اضافه کنید و به پرکنندهٔ شکل اختصاص دهید:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

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

تصویر بر روی سطح جلویی رندر می‌شود، در حالی که برآمدگی به‌عنوان سطح جانبی سه‌بعدی رندر می‌گردد:

![مستطیل سه‌بعدی رندر شده با پرکننده تصویری بر روی سطح جلویی و برآمدگی نارنجی](img_02_04.png)

## **اعمال قالب‌بندی سه‌بعدی به متن**

قالب‌بندی سه‌بعدی شکل بر بدنهٔ شکل تأثیر می‌گذارد. قالب‌بندی سه‌بعدی متن بر قاب متن تأثیر می‌گذارد. این برای اثرات شبیه WordArt مفید است که حروف خود نیاز به برآمدگی، ماده، نورپردازی و تنظیمات دوربین دارند.

مثال زیر متنی با پرکنندهٔ الگو می‌سازد، تبدیل WordArt را اعمال می‌کند و تنظیمات سه‌بعدی را بر روی [ITextFrameFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframeformat/) پیکربندی می‌کند:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

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

متن به‌صورت حروف منحنی و برآمدهٔ سه‌بعدی رندر می‌شود:

![متن سه‌بعدی رندر شده با تبدیل WordArt منحنی، پرکننده الگوی نارنجی و برآمدگی تیره](img_02_05.png)

## **رفتار خروجی و رندر شدن**

Aspose.Slides هنگام ذخیره به قالب‌های PowerPoint مانند PPTX قالب‌بندی سه‌بعدی را حفظ می‌کند. هنگام رندر یا خروجی به قالب‌های ثابت‑صفحه، صحنهٔ سه‌بعدی به‌صورت رستر یا به‌صورت دو‑بعدی در خروجی رسم می‌شود. این موضوع هنگام رندر اسلایدها به [PNG](/slides/fa/cpp/convert-powerpoint-to-png/)، خروجی به [PDF](/slides/fa/cpp/convert-powerpoint-to-pdf/)، خروجی به [HTML](/slides/fa/cpp/convert-powerpoint-to-html/)، یا تولید فریم برای [تبدیل ویدئو](/slides/fa/cpp/convert-powerpoint-to-video/) صادق است.

به نکات زیر توجه کنید:

- تصاویر و PDFهای خروجی تعاملی نیستند. پس از خروجی‌گیری، شیء توسط بیننده قابل چرخش نیست.
- ظاهر نهایی به ترکیب دوربین، لامپ نور، ماده، برآمدگی، پرکننده و مقیاس اسلاید بستگی دارد.
- اگر نیاز به بررسی مقادیر قالب‌بندی ارث‌بری یا مبتنی بر تم دارید، [ویژگی‌های مؤثر شکل](/slides/fa/cpp/shape-effective-properties/) را بخوانید.
- برخی قالب‌های خروجی نمی‌توانند قالب‌بندی سه‌بعدی قابل ویرایش PowerPoint را ذخیره کنند. در این قالب‌ها، نتیجه بصری رندر می‌شود نه اینکه به‌عنوان تنظیمات سه‌بعدی قابل ویرایش حفظ شود.

## **سوالات متداول**

### آیا Aspose.Slides می‌تواند ارائه‌های سه‌بعدی تعاملی ایجاد کند؟

Aspose.Slides اثرات سه‌بعدی PowerPoint را برای اشکال و متن ایجاد و رندر می‌کند. این ابزار تصاویر، PDFها یا صفحات HTML خروجی‌شده را به صحنه‌های سه‌بعدی تعاملی که بیننده می‌تواند چرخاند، تبدیل نمی‌کند. در قالب PPTX، قالب‌بندی سه‌بعدی در PowerPoint به‌عنوان قابل ویرایش باقی می‌ماند، مشروط بر این که قالب از آن پشتیبانی کند.

### تفاوت بین یک مدل سه‌بعدی و یک اثر سه‌بعدی چیست؟

یک مدل سه‌بعدی شیء جداگانه‌ای است که در ارائه وارد می‌شود. یک اثر سه‌بعدی قالب‌بندی‌ای است که بر یک شکل یا متن عادی PowerPoint اعمال می‌شود، مانند چرخش، برآمدگی، لبه‌گذاری، نورپردازی و ماده. این مقاله به اثرات سه‌بعدی می‌پردازد.

### چه تنظیماتی برای یک شکل سه‌بعدی قابل مشاهده لازم است؟

حداقل باید یک چرخش دوربین و یا برآمدگی یا عمق را تنظیم کنید. در عمل، تنظیم لامپ نور و ماده نیز توصیه می‌شود تا سطح‌های رندر شده هلایت و سایه‌های واضحی داشته باشند.

### آیا می‌توانم اثرات سه‌بعدی را هم به اشکال و هم به متن اعمال کنم؟

بله. برای بدنهٔ شکل از [IShape](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/) و برای متن از [ITextFrameFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/itextframeformat/) استفاده کنید.

### آیا اثرات سه‌بعدی هنگام خروجی به تصاویر، PDF، HTML یا فریم‌های ویدئویی ظاهر می‌شوند؟

بله. Aspose.Slides اثرات سه‌بعدی را هنگام تولید تصاویر اسلاید، خروجی PDF، خروجی HTML و فریم‌های استفاده شده برای تبدیل ویدئو رندر می‌کند. خروجی حاوی ظاهر رندر شده است، نه یک شیء سه‌بعدی قابل ویرایش.

### آیا می‌توانم مقادیر نهایی سه‌بعدی را پس از اعمال ارث‌بری و تنظیمات تم بخوانم؟

بله. از APIهای قالب‌بندی مؤثر توصیف‌شده در [ویژگی‌های مؤثر شکل](/slides/fa/cpp/shape-effective-properties/) برای خواندن مقادیر نهایی دوربین، لامپ نور، لبه و سایر مقادیر سه‌بعدی استفاده کنید.