---
title: ایجاد اثرات سه‌بعدی در ارائه‌ها با استفاده از C++
linktitle: ارائه سه‌بعدی
type: docs
weight: 232
url: /fa/cpp/3d-presentation/
keywords:
- PowerPoint سه‌بعدی
- ارائه سه‌بعدی
- چرخش سه‌بعدی
- عمق سه‌بعدی
- برآمدگی سه‌بعدی
- گرادیان سه‌بعدی
- متن سه‌بعدی
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "اعمال و رندر اثرات سه‌بعدی برای اشکال و متن‌های PowerPoint در C++ با Aspose.Slides. تنظیم دوربین، نورپردازی، ماده، برآمدگی، پرکننده‌ها و متن سه‌بعدی."
---
## **مرور کلی**

Aspose.Slides for C++ می‌تواند قالب‌بندی سه‌بعدی شبیه PowerPoint برای شکل‌ها و متن را ایجاد، ویرایش، نگهداری و رندر کند. این مقاله به اثرات سه‌بعدی مانند چرخش، برآمدگی، لبه‌دارها، نورپردازی، ماده، پرکردن گرادیان یا تصویر، و متن سه‌بعدی می‌پردازد.

{{% alert color="info" title="Note" %}}
این مقاله در مورد اثرات قالب‌بندی سه‌بعدی روی شکل‌ها و متن‌های PowerPoint است. این مقاله درباره افزودن یا ویرایش فایل‌های مدل سه‌بعدی جداگانه نیست. هنگام خروجی گرفتن یک اسلاید به تصویر، PDF یا HTML، Aspose.Slides این اثرات سه‌بعدی را به خروجی دو‌بعدی رندر می‌کند.
{{% /alert %}}

## **مفاهیم قالب‌بندی سه‌بعدی**

از روش [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) برای اعمال قالب‌بندی سه‌بعدی به یک شکل استفاده کنید. این روش یک شیء [IThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/) را برمی‌گرداند که صحنهٔ سه‌بعدی آن شکل را کنترل می‌کند.

برای متن، از روش [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/) استفاده کنید. این روش قالب‌بندی سه‌بعدی را به قاب متن اعمال می‌کند نه به بدنهٔ شکل.

متدهای مهم عبارتند از:

| روش | آن چه را کنترل می‌کند | زمان استفاده |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_camera/) | نقطه مشاهده، نوع دوربین پیش‌فرض، چرخش، زوم و پرسپکتیو. | چرخش شیء در فضای سه‌بعدی یا مطابقت با یک پیش‌تنظیم چرخش سه‌بعدی PowerPoint. |
| [get_LightRig](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_lightrig/) | پیش‌تنظیم نور، جهت و چرخش نور. | تغییر نحوهٔ ظاهر شدن روشنایی‌ها و سایه‌ها بر سطح سه‌بعدی. |
| [set_Material](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_material/) | مادی سطح، مانند صاف، مات، پلاستیک یا فلز. | سازماندهی هندسه یکسان به گونه‌ای که صاف‌تر، نرم‌تر، براق یا فلزی به نظر برسد. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | حدی که شکل از سطح جلو به عقب امتداد می‌یابد. | یک شکل صاف را به یک شیء سه‌بعدی به وضوح ضخیم تبدیل کنید. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | رنگ طرف‌های برآمده. | عمق را قابل مشاهده کنید یا رنگ طرف‌ها را با پرشدن جلو هماهنگ کنید. |
| [set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) | عمق سه‌بعدی اضافی که توسط قالب‌بندی سه‌بعدی PowerPoint استفاده می‌شود. | عمق را برای شکل‌ها یا متن به‌دقت تنظیم کنید، به‌ویژه همراه با تنظیمات لبه و ماده. |
| [get_BevelTop](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_beveltop/) and [get_BevelBottom](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | لبه‌های برجسته یا گرد شده بر روی سطوح جلو و پشت. | یک لبهٔ نرم یا قالب‌گیری شده اضافه کنید به‌جای یک سطح صاف و تیز. |
| [get_ContourColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_contourcolor/) and [set_ContourWidth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_contourwidth/) | خط‌محیط دور شیء سه‌بعدی. | مرز شیء را در خروجی رندر شده برجسته کنید. |

## **ایجاد یک شکل سه‌بعدی**

یک شکل معمولاً قبل از اینکه واقعاً سه‌بعدی به‌نظر برسد، به چهار نوع تنظیم نیاز دارد:

- تنظیمات دوربین، زیرا نما پیش‌فرض جلو ممکن است برآمدگی را مخفی کند.
- تنظیمات نور، زیرا نورپردازی باعث خوانا شدن سطح‌ها و طرف‌ها می‌شود.
- تنظیمات ماده، زیرا سطح بر نحوهٔ رندر نور تأثیر می‌گذارد.
- تنظیمات برآمدگی یا عمق، زیرا یک شکل صاف به ضخامت نیاز دارد.

مثال زیر یک مستطیل ایجاد می‌کند، متن را به سطح جلو اضافه می‌کند و قالب‌بندی سه‌بعدی را اعمال می‌کند. مقادیر چرخش دوربین به درجه است و ارتفاع برآمدگی 100 پوینت است. مثال اسلاید را به یک تصویر PNG با دو برابر ابعاد پیش‌فرض رندر می‌کند و ارائه را به‌صورت PPTX ذخیره می‌کند.

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

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto frontColor = Color::get_CornflowerBlue();
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(frontColor);

auto extrusionColor = Color::get_Blue();
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

![مستطیل سه‌بعدی آبی رندر شده با متن سفید سه‌بعدی روی سطح جلو](img_01_01.png)

## **چرخاندن یک شکل با دوربین**

در PowerPoint، چرخش سه‌بعدی از پنل چرخش 3‑D تنظیم می‌شود. مقادیر چرخش X، Y و Z مطابق با چرخشی است که از طریق API دوربین تنظیم می‌کنید.

![پنل چرخش 3‑D PowerPoint با مقادیر چرخش X، Y و Z برجسته شده](img_02_01.png)

در Aspose.Slides، دوربین را از طریق [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_camera/) دسترسی پیدا کنید. این مثال یک مستطیل ایجاد می‌کند، یک نمای اورتوغرافیک جلویی را انتخاب می‌کند و چرخش‌های X، Y و Z آن را به ترتیب 20، 30 و 40 درجه تنظیم می‌کند. شکل را در حافظه پیکربندی می‌کند بدون اینکه فایلی ذخیره شود:

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

presentation->Dispose();
```

از دوربین زمانی استفاده کنید که نیاز به تغییر نحوهٔ مشاهدهٔ شی توسط بیننده داشته باشید. این کار هندسهٔ شکل دو‌بعدی روی اسلاید را تغییر نمی‌دهد. بلکه نقطهٔ دید سه‌بعدی استفاده شده توسط PowerPoint و Aspose.Slides هنگام رندر را تغییر می‌دهد.

### **کپی‌برداری جهت دوربین از یک شکل الگو**

برای تطبیق جهت دوربین یک شکل الگو، پیش‌تنظیم آن را با [get_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/get_cameratype/) بخوانید و با [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) اعمال کنید. مثال `template.pptx` را باز می‌کند و جهت دوربین اولین شکل در اولین اسلاید را به شکل دوم کپی می‌کند. هر دو شکل قبلاً نوردهی سه‌بعدی دارند و شکل دوم چرخش دوربین صریحی ندارد.

متد [GetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/getrotation/) زاویه‌ها را برحسب درجه بر می‌گرداند. اندیس `0` عرض جغرافیایی، اندیس `1` طول جغرافیایی و اندیس `2` دور است. این زاویه‌ها را به ترتیب به [SetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/setrotation/) پاس می‌دهید. اگر منبع چرخش صریحی نداشته باشد، `GetRotation` یک اشاره‌گر نال بر می‌گرداند، بنابراین زاویه‌های شکل دوم را تنظیم نکنید. یک چرخش صریح `(0, 0, 0)` آرایه‌ای از سه صفر بر می‌گرداند و باید کپی شود.

```cpp
#include <DOM/ICamera.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);

auto sourceCamera = slide->get_Shape(0)->get_ThreeDFormat()->get_Camera();
auto destinationCamera = slide->get_Shape(1)->get_ThreeDFormat()->get_Camera();

destinationCamera->set_CameraType(sourceCamera->get_CameraType());
auto angles = sourceCamera->GetRotation();
if (angles != nullptr)
{
    destinationCamera->SetRotation(angles[0], angles[1], angles[2]);
}

presentation->Save(u"camera-copy.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

زمانی که `camera-copy.pptx` را دوباره در PowerPoint باز می‌کنید، پیکان سمت راست همان پیش‌تنظیم دوربین و چرخش را که مستطیل سمت چپ دارد دارد. هر دو شکل از نوردهی و عمق برآمدگی یکسان استفاده می‌کنند.

![یک مستطیل سه‌بعدی آبی و یک پیکان راست با جهت دوربین منطبق، که از بالا و سمت راست مشاهده می‌شوند](camera-orientation.png)

## **افزودن برآمدگی و عمق**

برآمدگی باعث می‌شود شکل ضخیم به نظر برسد با گسترش آن به پشت سطح جلو. در PowerPoint، کنترل عمق این ضخامت قابل مشاهده را تنظیم می‌کند و کنترل رنگ رنگ طرف‌های جانبی را تعیین می‌کند.

![کنترل‌های عمق PowerPoint که به خصوصیات رنگ برآمدگی و ارتفاع برآمدگی نگاشت شده‌اند](img_02_02.png)

برای ضخامت از [IThreeDFormat::set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) و برای رنگ طرف‌ها از [IThreeDFormat::get_ExtrusionColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) استفاده کنید. این مثال به مستطیل برآمدگی 100 پوینتی با طرف‌های بنفش می‌دهد و دوربین را چرخانده تا ضخامت آن را نشان دهد. شکل را در حافظه پیکربندی می‌کند بدون ذخیرهٔ فایل:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/ILightRig.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
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
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

presentation->Dispose();
```

متد [IThreeDFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) عمق یک شکل سه‌بعدی را تنظیم می‌کند. متد [set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) ارتفاع اثر برآمدگی را کنترل می‌کند، همان‌طور که در این مثال نشان داده شده است.

## **استفاده از پرکردن گرادیان یا تصویر با اثرات سه‌بعدی**

قالب‌بندی سه‌بعدی مستقل از پرکردن شکل است. می‌توانید یک رنگ ثابت، گرادیان، الگو یا پرکردن تصویر را روی سطح جلو اعمال کنید و همچنان از همان تنظیمات دوربین، نور، ماده و برآمدگی استفاده کنید.

این مثال یک گرادیان آبی‑به‑نارنجی را بر روی سطح جلو اعمال می‌کند و یک رنگ نارنجی تیره به برآمدگی 150 پوینتی می‌دهد. نقاط توقف گرادیان در 0 و 100 شروع و پایان گرادیان را نشان می‌دهند. مقادیر چرخش دوربین به درجه است. اسلاید به تصویر PNG با دو برابر ابعاد پیش‌فرض رندر می‌شود:

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

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto firstGradientColor = Color::get_Blue();
auto secondGradientColor = Color::get_Orange();
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, firstGradientColor);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, secondGradientColor);

auto extrusionColor = Color::get_DarkOrange();
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

![مستطیل سه‌بعدی رندر شده با پرکردن گرادیان آبی‑به‑نارنجی و برآمدگی نارنجی](img_02_03.png)

برای استفاده از پرکردن تصویر به‌جای آن، تصویر را به ارائه اضافه کنید و به پرکردن شکل اختصاص دهید. این مثال نیاز به فایلی به‌نام "image.jpg" در پوشهٔ کاری دارد. تصویر را برای پر کردن مستطیل کشیده و برآمدگی 150 پوینتی اعمال می‌کند و چرخش دوربین را به درجه تنظیم می‌کند. شکل را در حافظه بدون ذخیره یا رندر فایل پیکربندی می‌کند:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/ILightRig.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
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

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);

auto imageData = File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

auto extrusionColor = Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

presentation->Dispose();
```

![مستطیل سه‌بعدی رندر شده با پرکردن عکس روی سطح جلو و برآمدگی نارنجی](img_02_04.png)

## **اعمال قالب‌بندی سه‌بعدی به متن**

قالب‌بندی سه‌بعدی شکل بر روی بدنهٔ شکل تأثیر می‌گذارد. قالب‌بندی سه‌بعدی متن بر روی قاب متن تأثیر می‌کند. این برای اثراتی شبیه WordArt مفید است که در آن حروف خود نیاز به برآمدگی، ماده، نورپردازی و تنظیمات دوربین دارند.

مثال زیر متنی با الگوی شبکه‌ای نارنجی‑سفید ایجاد می‌کند، یک قوس بالا رفتگی اعمال می‌کند و تنظیمات سه‌بعدی را از طریق [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/) پیکربندی می‌کند. ارتفاع برآمدگی و عمق بر حسب پوینت است و چرخش نور بر حسب درجه است. پرکردن و خطوط شکل مخفی هستند تا فقط متن قابل مشاهده باشد. مثال یک تصویر PNG با دو برابر ابعاد پیش‌فرض اسلاید رندر می‌کند و ارائه را به‌صورت PPTX ذخیره می‌کند:

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

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);

shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);

auto foregroundColor = Color::get_DarkOrange();
auto backgroundColor = Color::get_White();
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

![متن سه‌بعدی رندر شده با تبدیل WordArt قوسی، پرکردن الگوی نارنجی و برآمدگی تیره](img_02_05.png)

## **حفظ متن صاف روی یک شکل سه‌بعدی**

برای حفظ قابل خواندن بودن متن در حالی که ظاهر سه‌بعدی شکل حفظ می‌شود، با فراخوانی [ITextFrameFormat::set_KeepTextFlat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_keeptextflat/) از طریق [ITextFrame::get_TextFrameFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_textframeformat/) این تنظیم را اعمال کنید. وقتی مقدار `true` باشد، متن خارج از صحنهٔ سه‌بعدی می‌ماند. وقتی `false` باشد، متن در صحنه مشارکت می‌کند و جهت سه‌بعدی آن را دنبال می‌کند.

این تنظیم قالب‌بندی سه‌بعدی شکل را حذف نمی‌کند: دوربین، نوردهی، ماده و برآمدگی آن همچنان از طریق [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) پیکربندی می‌شوند. همچنین متفاوت از چرخش معمولی است. [IShape::set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_rotation/) شکل را در صفحه اسلاید می‌چرخاند، در حالی که [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_rotationangle/) چرخش سفارشی متن را داخل جعبهٔ محاط‌کننده‌اش کنترل می‌کند. نگه داشتن متن خارج از صحنهٔ سه‌بعاد هیچ‌یک از این زاویه‌ها را ریست نمی‌کند.

مثال زیر که به‌صورت خودکفا است، یک مستطیل آبی با متن ایجاد می‌کند و آن را در کنار اصل کپی می‌کند. هر دو شکل همان قالب‌بندی سه‌بعدی را دارند؛ فقط تنظیم متن متفاوت است: `false` در سمت چپ و `true` در سمت راست. زاویه‌های دوربین برحسب درجه هستند و ارتفاع برآمدگی 40 پوینت است. مثال ارائه را به‌صورت PPTX ذخیره می‌کند و اسلاید مقایسه را به تصویر PNG با دو برابر ابعاد پیش‌فرض رندر می‌کند.

```cpp
#include <DOM/ITextFrameFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAnchorType.h>
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

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 70.0f, 160.0f, 240.0f, 140.0f);

shape->get_TextFrame()->set_Text(u"Readable text");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);
shape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Center);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_CornflowerBlue());

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(30.0f, 30.0f, 0.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(40.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(Color::get_RoyalBlue());
shape->get_TextFrame()->get_TextFrameFormat()->set_KeepTextFlat(false);

auto clonedShape = slide->get_Shapes()->AddClone(shape, 400.0f, 160.0f);
auto flatTextShape = System::ExplicitCast<IAutoShape>(clonedShape);
flatTextShape->get_TextFrame()->get_TextFrameFormat()->set_KeepTextFlat(true);

presentation->Save(u"keep_text_flat.pptx", SaveFormat::Pptx);
auto image = slide->GetImage(2.0f, 2.0f);
image->Save(u"keep_text_flat.png");
image->Dispose();
presentation->Dispose();
```

در سمت چپ، متن جهت سه‌بعدی را دنبال می‌کند. در سمت راست، متن صاف می‌ماند و خواندن آن آسان‌تر است. هر دو مستطیل همان برآمدگی قابل مشاهده و جهت سه‌بعدی را نگه می‌دارند.

![مستطیل‌های سه‌بعدی کنار هم: KeepTextFlat در سمت چپ false و در سمت راست true است](keep_text_flat.png)

## **رفتار خروجی و رندر**

Aspose.Slides قالب‌بندی سه‌بعدی را هنگام ذخیره به فرمت‌های PowerPoint مانند PPTX حفظ می‌کند. هنگام رندر یا خروجی به فرمت‌های ثابت، صحنهٔ سه‌بعدی به صورت رستر یا به‌صورت خروجی دو‌بعدی رسم می‌شود. این برای زمانی که اسلایدها را به [PNG](/slides/fa/cpp/convert-powerpoint-to-png/)، به [PDF](/slides/fa/cpp/convert-powerpoint-to-pdf/)، به [HTML](/slides/fa/cpp/convert-powerpoint-to-html/) یا فریم‌ها برای [video conversion](/slides/fa/cpp/convert-powerpoint-to-video/) رندر می‌کنید، صدق می‌کند.

- تصاویر و PDFهای خروجی تعاملی نیستند. پس از خروجی گرفتن، شیء نمی‌تواند توسط بیننده چرخانده شود.
- ظاهر نهایی به ترکیب دوربین، نوردهی، ماده، برآمدگی، پرکردن و بزرگ‌نمایی اسلاید بستگی دارد.
- اگر نیاز به بررسی مقادیر قالب‌بندی به‌دست آمده یا مبتنی بر تم دارید، [effective shape properties](/slides/fa/cpp/shape-effective-properties/) را بخوانید.
- برخی از فرمت‌های خروجی نمی‌توانند قالب‌بندی سه‌بعدی قابل ویرایش PowerPoint را ذخیره کنند. در این فرمت‌ها، نتیجه بصری رندر می‌شود نه این‌که به عنوان تنظیمات سه‌بعدی قابل ویرایش حفظ شود.

## **سوالات متداول**

**آیا Aspose.Slides می‌تواند ارائه‌های سه‌بعدی تعاملی ایجاد کند؟**  
Aspose.Slides اثرات سه‌بعدی PowerPoint را برای شکل‌ها و متن ایجاد و رندر می‌کند. این ابزار تصاویر، PDFها یا صفحات HTML خروجی را صحنه‌های سه‌بعدی تعاملی نمی‌کند که بیننده بتواند آن‌ها را چرخاند. در PPTX، قالب‌بندی سه‌بعدی در PowerPoint ویرایش‌پذیر می‌ماند وقتی فرمت از آن پشتیبانی می‌کند.

**تفاوت بین یک مدل سه‌بعدی و یک اثر سه‌بعاد چیست؟**  
یک مدل سه‌بعدی یک شیء سه‌بعدی جداگانه است که به ارائه اضافه می‌شود. یک اثر سه‌بعدی قالب‌بندی است که به یک شکل یا متن عادی PowerPoint اعمال می‌شود، مانند چرخش، برآمدگی، لبه، نوردهی و ماده. این مقاله به اثرات سه‌بعدی می‌پردازد.

**کدام تنظیمات برای یک شکل سه‌بعدی قابل مشاهده لازم هستند؟**  
حداقل، باید یک چرخش دوربین و یا برآمدگی یا عمق تنظیم کنید. در عمل، نوردهی و ماده نیز تنظیم می‌شوند تا سطوح رندر شده روشنایی و سایه‌های واضح داشته باشند.

**آیا می‌توانم اثرات سه‌بعدی را هم بر روی شکل‌ها و هم متن اعمال کنم؟**  
بله. از [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) برای بدنهٔ شکل و از [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/) برای متن استفاده کنید.

**آیا اثرات سه‌بعدی هنگام خروجی به تصاویر، PDF، HTML یا فریم‌های ویدئو ظاهر می‌شوند؟**  
بله. Aspose.Slides اثرات سه‌بعدی را هنگام تولید تصاویر اسلاید، خروجی PDF، خروجی HTML و فریم‌های استفاده‌شده برای تبدیل ویدئویی رندر می‌کند. خروجی خروجی شامل ظاهر رندر شده است، نه یک شیء سه‌بعدی قابل ویرایش.

**آیا می‌توانم مقادیر نهایی سه‌بعدی را پس از اعمال وراثت و تنظیمات تم بخوانم؟**  
بله. از APIهای قالب‌بندی مؤثر توضیح داده‌شده در [Shape Effective Properties](/slides/fa/cpp/shape-effective-properties/) برای خواندن دوربین نهایی، نوردهی، لبه و مقادیر مرتبط سه‌بعدی استفاده کنید.