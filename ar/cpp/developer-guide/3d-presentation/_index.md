---
title: إنشاء تأثيرات ثلاثية الأبعاد في العروض التقديمية باستخدام C++
linktitle: عرض ثلاثي الأبعاد
type: docs
weight: 232
url: /ar/cpp/3d-presentation/
keywords:
- PowerPoint ثلاثي الأبعاد
- عرض ثلاثي الأبعاد
- دوران ثلاثي الأبعاد
- عمق ثلاثي الأبعاد
- بث ثلاثي الأبعاد
- تدرج ثلاثي الأبعاد
- نص ثلاثي الأبعاد
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تطبيق وعرض التأثيرات ثلاثية الأبعاد لأشكال PowerPoint والنص في C++ باستخدام Aspose.Slides. تهيئة الكاميرا، الإضاءة، المادة، البث، التعبئات، والنص ثلاثي الأبعاد."
---
## **نظرة عامة**

Aspose.Slides for C++ يمكنه إنشاء وتعديل وحفظ وعرض تنسيق ثلاثي الأبعاد على نمط PowerPoint للأشكال والنص. تغطي هذه المقالة التأثيرات الثلاثية الأبعاد مثل الدوران، البث، الحواف المائلة، الإضاءة، المادة، التعبئات المتدرجة أو صورة، والنص ثلاثي الأبعاد.

{{% alert color="info" title="Note" %}}
هذه المقالة تتعلق بتأثيرات تنسيق ثلاثي الأبعاد على أشكال PowerPoint والنص. ليست حول إدراج أو تعديل ملفات نماذج ثلاثية الأبعاد مستقلة. عند تصدير شريحة إلى صورة أو PDF أو HTML، تقوم Aspose.Slides بعرض تلك التأثيرات الثلاثية الأبعاد في الناتج ثنائي الأبعاد المُصدَّر.
{{% /alert %}}

## **مفاهيم تنسيق ثلاثي الأبعاد**

استخدم طريقة [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) لتطبيق تنسيق ثلاثي الأبعاد على شكل. تُعيد الطريقة [IThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/)، التي تتحكم في المشهد الثلاثي الأبعاد لهذا الشكل.

للنص، استخدم طريقة [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/) . هذا يطبق تنسيق ثلاثي الأبعاد على إطار النص بدلًا من جسم الشكل.

الطرق الأكثر أهمية هي:

| الطريقة | ما الذي يتحكم به | متى يستخدم |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_camera/) | نقطة العرض، نوع الكاميرا المحدد مسبقًا، الدوران، التكبير، والمنظور. | دوران الكائن في الفضاء ثلاثي الأبعاد أو مطابقة إعداد مسبق للدوران ثلاثي الأبعاد في PowerPoint. |
| [get_LightRig](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_lightrig/) | إعداد مسبق للضوء، الاتجاه، ودوران الضوء. | تغيير كيفية ظهور الإضاءات والظلال على السطح الثلاثي الأبعاد. |
| [set_Material](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_material/) | مادة السطح، مثل مسطح، غير لامع، بلاستيك أو معدن. | اجعل الشكل نفسه يبدو أكثر تسطحًا، نعومة، لامعًا أو معدنيًا. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | مدى بُعد الامتداد الخلفي للشكل عن واجهته الأمامية. | تحويل شكل مسطح إلى جسم ثلاثي الأبعاد سُمكه واضح. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | لون الجوانب الممدودة. | إظهار العمق أو تنسيق لون الجوانب مع تعبئة الواجهة الأمامية. |
| [set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) | عمق ثلاثي أبعاد إضافي يستخدمه تنسيق ثلاثي الأبعاد في PowerPoint. | ضبط العمق بدقة للأشكال أو النص، خاصةً مع إعدادات الحافة والمادة. |
| [get_BevelTop](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_beveltop/) و [get_BevelBottom](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | حواف مرتفعة أو مستديرة على الواجهتين الأمامية والخلفية. | إضافة حافة ناعمة أو مصبوبة بدلاً من وجه مسطح حاد. |
| [get_ContourColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_contourcolor/) و [set_ContourWidth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_contourwidth/) | الحد الخارجي حول الجسم الثلاثي الأبعاد. | تسليط الضوء على حدود الكائن في المخرجات المرسومة. |

## **إنشاء شكل ثلاثي الأبعاد**

- إعدادات الكاميرا، لأن العرض الأمامي الافتراضي قد يخفي البث.  
- إعدادات الإضاءة، لأن الإضاءة تجعل الوجوه والجوانب قابلة للقراءة.  
- إعدادات المادة، لأن السطح يؤثر على كيفية عرض الضوء.  
- إعدادات البث أو العمق، لأن الشكل المسطح يحتاج إلى سماكة.

المثال التالي ينشئ مستطيلًا، يضيف نصًا إلى واجهته الأمامية، ويطبق تنسيق ثلاثي الأبعاد. قيم دوران الكاميرا بالدرجات، وارتفاع البث 100 نقطة. المثال يعرض الشريحة إلى صورة PNG بمقاسين مضاعفين عن الأبعاد الافتراضية ويحفظ العرض التقديمي كملف PPTX.

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

تظهر صورة الشريحة المرسومة المستطيل ككتلة ثلاثية الأبعاد سميكة:

![مستطيل ثلاثي الأبعاد أزرق مُرَسَّم مع نص ثلاثي الأبعاد أبيض على الواجهة الأمامية](img_01_01.png)

## **تدوير شكل باستخدام الكاميرا**

في PowerPoint، يتم تكوين دوران ثلاثي الأبعاد من لوحة "3‑D Rotation". قيم الدوران X و Y و Z تتطابق مع الدوران الذي تحدده عبر واجهة برمجة كاميرا.

![لوحة دوران ثلاثي الأبعاد في PowerPoint مع إبراز قيم الدوران X و Y و Z](img_02_01.png)

في Aspose.Slides، يمكن الوصول إلى الكاميرا عبر [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_camera/). هذا المثال ينشئ مستطيلًا، يختار عرضًا أماميًا ارتوغرافيًا، ويضبط دوراناته X و Y و Z إلى 20 و30 و40 درجة على التوالي. يُكوّن الشكل في الذاكرة دون حفظ ملف:

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

استخدم الكاميرا عندما تحتاج إلى تغيير طريقة رؤية المشاهد للكائن. لا يغيّر ذلك هندسة الشكل ثنائي الأبعاد على الشريحة. بل يغيّر منظور الثلاثي الأبعاد الذي يستخدمه PowerPoint وAspose.Slides عند العرض.

### **نسخ توجيه الكاميرا من شكل قالب**

لمطابقة توجيه كاميرا شكل القالب، اقرأ إعداده المسبق عبر [get_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/get_cameratype/) وطبقه عبر [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/). يفتح المثال `template.pptx` وينسخ توجيه الكاميرا من الشكل الأول على الشريحة الأولى إلى الشكل الثاني. كلا الشكلين يحتويان بالفعل على إضاءة ثلاثية الأبعاد، ولا يحتوي الشكل الثاني على دوران كاميرا صريح.

[GetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/getrotation/) تُعيد الزوايا بالدرجات. الفهرس 0 هو خط العرض، الفهرس 1 هو خط الطول، والفهرس 2 هو اللف. مرّر الزوايا إلى [SetRotation](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/setrotation/) بهذا الترتيب. إذا لم يكن للمصدر دوران صريح، تُعيد `GetRotation` مؤشرًا فارغًا، لذا اترك زوايا الشكل الثاني غير مُحددة. دوران صريح بـ `(0, 0, 0)` يُعيد مصفوفة من ثلاثة أصفار ويجب نسخه.

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

عند إعادة فتح `camera-copy.pptx` في PowerPoint، سيظهر السهم الأيمن بنفس إعداد الكاميرا والدوران كما في المستطيل الأيسر. كلا الشكلين يستخدمان نفس الإضاءة وعمق البث.

![مستطيل ثلاثي الأبعاد أزرق وسهم يميني مع توجيه كاميرا مطابق، يُعرض من الأعلى وإلى اليمين](camera-orientation.png)

## **إضافة بث وعمق**

البث يجعل الشكل يبدو سميكًا بامتداده خلف الواجهة الأمامية. في PowerPoint، يتحكم التحكم في العمق في هذا السمك المرئي، ويتحكم التحكم في اللون في لون الجوانب.

![ضوابط العمق في PowerPoint مترابطة مع خصائص لون البث وارتفاع البث](img_02_02.png)

عيّن [IThreeDFormat::set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) للسمك و[IThreeDFormat::get_ExtrusionColor](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) للون الجوانب. هذا المثال يمنح المستطيل بثًا بارتفاع 100 نقطة ولونًا بنفسجيًا للجوانب ويُدوّر الكاميرا لإظهار السمك. يُكوّن الشكل في الذاكرة دون حفظ ملف:

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

طريقة [IThreeDFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_depth/) تُعيّن عمق الشكل ثلاثي الأبعاد. طريقة [set_ExtrusionHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ithreedformat/set_extrusionheight/) تتحكم في ارتفاع تأثير البث، كما هو موضح في هذا المثال.

## **استخدام تعبئات متدرجة أو صورة مع تأثيرات ثلاثية الأبعاد**

تنسيق الثلاثي الأبعاد مستقل عن تعبئة الشكل. يمكنك تطبيق لون صلب أو متدرج أو نمط أو تعبئة صورة على الواجهة الأمامية مع الاستمرار في استخدام نفس الكاميرا والإضاءة والمادة وإعدادات البث.

هذا المثال يطبق تدرجًا من الأزرق إلى البرتقالي على الواجهة الأمامية ولونًا برتقاليًا داكنًا على البث بارتفاع 150 نقطة. يتوقف التدرج عند 0 و100 لتحديد بداية ونهاية التدرج. قيم دوران الكاميرا بالدرجات. تُعرَض الشريحة إلى صورة PNG بمقاسين مضاعفين عن الأبعاد الافتراضية:

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

![مستطيل ثلاثي الأبعاد مُرَسَّم بتعبئة متدرجة من الأزرق إلى البرتقالي وبث برتقالي](img_02_03.png)

لاستخدام تعبئة صورة بدلاً من ذلك، أضف الصورة إلى العرض التقديمي وعيّنها لتعبئة الشكل. يتطلب هذا المثال وجود ملف موجود باسم "image.jpg" في دليل العمل. يتمدد الصور لتملأ المستطيل، يُطبق بثًا بارتفاع 150 نقطة، ويضبط دوران الكاميرا بالدرجات. يُكوّن الشكل في الذاكرة دون حفظ أو عرض ملف:

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

![مستطيل ثلاثي الأبعاد مُرَسَّم بتعبئة صورة على الواجهة الأمامية وبث برتقالي](img_02_04.png)

## **تطبيق تنسيق ثلاثي الأبعاد على النص**

تنسيق ثلاثي الأبعاد للشكل يؤثر على جسم الشكل. تنسيق ثلاثي الأبعاد للنص يؤثر على إطار النص. هذا مفيد لتأثيرات شبيهة بـ WordArt حيث تحتاج الحروف نفسها إلى بث، مادة، إضاءة، وإعدادات كاميرا.

المثال التالي ينشئ نصًا بنمط شبكة برتقالي وأبيض، يطبق قوسًا تصاعديًا، ويُكوّن إعدادات ثلاثية الأبعاد عبر [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/). ارتفاع البث والعمق بالنقاط، ودوران الضوء بالدرجات. تعبئة الشكل والحد الخارجي مخفيان بحيث لا يظهر سوى النص. يُعرَض المثال إلى صورة PNG بمقاسين مضاعفين عن أبعاد الشريحة الافتراضية ويحفظ العرض التقديمي كملف PPTX:

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

![نص ثلاثي الأبعاد مُرَسَّم بتحويل قوسي شبيه بـ WordArt، تعبئة بنمط برتقالي، وبث داكن](img_02_05.png)

## **إبقاء النص مسطحًا على شكل ثلاثي الأبعاد**

للحفاظ على قابلية قراءة النص مع الحفاظ على مظهر الشكل الثلاثي الأبعاد، استدعِ [ITextFrameFormat::set_KeepTextFlat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_keeptextflat/) عبر [ITextFrame::get_TextFrameFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_textframeformat/). عندما تكون القيمة `true`، يبقى النص خارج المشهد الثلاثي الأبعاد. عندما تكون `false`، يشارك النص في المشهد ويتبع توجيهه الثلاثي الأبعاد.

هذا الإعداد لا يزيل تنسيق الثلاثي الأبعاد للشكل: لا يزال الكاميرا والإضاءة والمادة والبث مُكوّنين عبر [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/). كما أنه مختلف عن الدوران العادي. [IShape::set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_rotation/) يدور الشكل في مستوى الشريحة، بينما [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_rotationangle/) يتحكم في دوران النص داخل صندوقه. إبقاء النص خارج المشهد الثلاثي الأبعاد لا يعيد تعيين أي من هذين الزاويتين.

المثال التالي المستقل يخلق مستطيلًا أزرقًا بالنص ويستنسخه بجانب الأصلي. كلا الشكلين لهما نفس تنسيق الثلاثي الأبعاد؛ الاختلاف الوحيد هو إعداد النص: `false` على اليسار و`true` على اليمين. زوايا الكاميرا بالدرجات، وارتفاع البث 40 نقطة. يحفظ المثال العرض التقديمي كملف PPTX ويعرض شريحة المقارنة إلى PNG بمقاسين مضاعفين عن الأبعاد الافتراضية.

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

![مستطيلان ثلاثيان متجاوران: KeepTextFlat على اليسار false وعلى اليمين true](keep_text_flat.png)

## **سلوك التصدير والعرض**

Aspose.Slides يحافظ على تنسيق الثلاثي الأبعاد عند الحفظ إلى صيغ PowerPoint مثل PPTX. عند العرض أو التصدير إلى صيغ ذات تخطيط ثابت، يتم تحويل المشهد الثلاثي الأبعاد إلى صورة نقطية أو رسمه في الناتج كنتيجة ثنائية الأبعاد. ينطبق ذلك عندما تُعرِض الشرائح إلى [PNG](/slides/ar/cpp/convert-powerpoint-to-png/)، تصدر إلى [PDF](/slides/ar/cpp/convert-powerpoint-to-pdf/)، تصدر إلى [HTML](/slides/ar/cpp/convert-powerpoint-to-html/)، أو تُنشئ إطارات لـ [تحويل الفيديو](/slides/ar/cpp/convert-powerpoint-to-video/).

- الصور وملفات PDF المُصدَّرة ليست تفاعلية. لا يمكن للمشاهد تدوير الكائن بعد التصدير.  
- المظهر النهائي يعتمد على مزيج الكاميرا، نظام الإضاءة، المادة، البث، التعبئة، وتكبير الشريحة.  
- إذا كنت بحاجة إلى فحص قيم التنسيق الموروثة أو القائمة على القالب، اقرأ [خصائص الشكل الفعّالة](/slides/ar/cpp/shape-effective-properties/).  
- بعض صيغ الإخراج لا يمكنها تخزين تنسيق ثلاثي الأبعاد قابل للتحرير في PowerPoint. في تلك الصيغ، يتم عرض النتيجة بصريًا بدلاً من الحفاظ عليها كإعدادات ثلاثية الأبعاد قابلة للتحرير.

## **الأسئلة المتكررة**

**هل يمكن لـ Aspose.Slides إنشاء عروض ثلاثية الأبعاد تفاعلية؟**  
Aspose.Slides ينشئ ويعرض تأثيرات ثلاثية الأبعاد في PowerPoint للأشكال والنص. لا يجعل الصور، ملفات PDF، أو صفحات HTML تفاعلية بحيث يمكن للمشاهد تدوير المشهد. في PPTX، يبقى تنسيق الثلاثي الأبعاد قابلًا للتحرير في PowerPoint حيث تدعم الصيغة ذلك.

**ما الفرق بين نموذج ثلاثي الأبعاد وتأثير ثلاثي الأبعاد؟**  
النموذج الثلاثي الأبعاد هو كائن ثلاثي منفصل يُدرج في العرض. التأثير الثلاثي الأبعاد هو تنسيق يُطبق على شكل PowerPoint عادي أو نص، مثل الدوران، البث، الحافة، الإضاءة، والمادة. هذه المقالة تغطي التأثيرات الثلاثية الأبعاد.

**ما الإعدادات المطلوبة لتظهر شكل ثلاثي الأبعاد؟**  
على الأقل، يجب ضبط دوران الكاميرا وإما البث أو العمق. عمليًا، يُفضَّل أيضًا ضبط نظام الإضاءة والمادة حتى تكون الوجوه المرسومة ذات إضاءات وظلال واضحة.

**هل يمكنني تطبيق تأثيرات ثلاثية الأبعاد على الأشكال والنص معًا؟**  
نعم. استخدم [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_threedformat/) لجسم الشكل و[ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/get_threedformat/) للنص.

**هل ستظهر تأثيرات ثلاثية الأبعاد عند التصدير إلى صور أو PDF أو HTML أو إطارات فيديو؟**  
نعم. Aspose.Slides يعرض تأثيرات ثلاثية الأبعاد عند إنتاج صور الشرائح، مخرجات PDF، مخرجات HTML، وإطارات تُستخدم لتحويل الفيديو. الناتج المُصدَّر يحتوي على المظهر المُرسوم، وليس كائنًا ثلاثيًا قابلًا للتحرير.

**هل يمكنني قراءة القيم الثلاثية النهائية بعد تطبيق الوراثة وإعدادات القالب؟**  
نعم. استخدم واجهات برمجة التطبيقات للتنسيق الفعّال الموضحة في [خصائص الشكل الفعّالة](/slides/ar/cpp/shape-effective-properties/) لقراءة الكاميرا النهائية، نظام الإضاءة، الحافة، والقيم الثلاثية ذات الصلة.