---
title: إدارة تأثيرات تحويل الصورة في العروض التقديمية باستخدام C++
linktitle: تأثيرات تحويل الصورة
type: docs
weight: 11
url: /ar/cpp/image-transform-effects/
keywords:
- تحويل الصورة
- تأثير الصورة
- سطوع
- تباين
- تدرج الرمادي
- ثنائي اللون
- صبغة
- HSL
- استبدال اللون
- ضبابية
- شفافية
- تأثير ألفا
- سلسلة تأثير
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تطبيق، ربط، فحص، إزالة، والتحقق من تأثيرات تحويل الصورة لإطارات الصور باستخدام Aspose.Slides للغة C++."
---
## **نظرة عامة**

Aspose.Slides يمثل تعديلات الصورة كمجموعة مرتبة من عمليات تحويل الصورة. بالنسبة لإطار الصورة، ابدأ بإطار [ISlidesPicture](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidespicture/) وادخل إلى [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidespicture/get_imagetransform/). المجموعة المعادة [IImageTransformOperationCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/iimagetransformoperationcollection/) تسمح لك بإضافة، تعداد، فحص، إزالة، ومسح التأثيرات دون إعادة كتابة بايتات الصورة الأصلية.

هذا المقال يوضح سير عمل كامل للسطوع والتباين، تحويلات الألوان، الضبابية، الشفافية، سلاسل التأثير المرتبة، القيم الفعّالة، الإزالة، والتحقق من جولة PPTX.

## **فهم ملكية التأثير وإعادة استخدام الصورة**

مصدر الصورة والصورة التي تعرضها كائنان مختلفان:

- [IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/) يخزّن أو يشير إلى بيانات الصورة المصدر المملوكة للعرض التقديمي.
- [ISlidesPicture](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidespicture/) ينتمي إلى تعبئة صورة ويشير إلى مصدر صورة أثناء تخزين مجموعة تحويل الصورة.
- [IPictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipictureframe/) هو شكل الشريحة الذي يمتلك تعبئة الصورة ذات الصلة، الهندسة، إعدادات القص، وتنسيقات المستوى الإطاري الأخرى.

لذلك، عمليات تحويل الصورة لا تعدّل البايتات في [IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/). عندما يتم تمرير نفس `IPPImage` إلى [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/addpictureframe/) أكثر من مرة، كل إطار صورة جديد يحصل على `ISlidesPicture` الخاص به ومجموعة التحويل الخاصة به. تطبيق تدرج الرمادي على إطار واحد لا يجعل الأطر الأخرى رمادية، حتى وإن أعادت جميعها استخدام نفس مصدر الصورة المضمن.

نفس نموذج `ISlidesPicture::get_ImageTransform` يُستعمل أيضاً من قبل تعبئات صور أخرى، مثل شكل أو خلفية شريحة. الأمثلة أدناه تركز على إطارات الصور.

## **استخدام نطاقات ومعايير صحيحة للمعاملات والوحدات**

الطرق المعروضة تستخدم النطاقات الدلالية والوحدات التالية. احتفظ بالقيم ضمن هذه النطاقات حتى لو لم يرفض إصدار مكتبة معين القيم الخارجة فوراً؛ قد يقوم تنسيق العرض المستهدف بتطبيع أو حذف أو رفض البيانات غير الصالحة أثناء الحفظ أو عند فتح الملف في PowerPoint.

| العملية | المعاملات | النطاق والوحدة الصالحة |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` إلى `100` بالمائة؛ `0` يترك المكوّن دون تغيير. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | لا شيء | لا معاملات رقمية. لا يتغيّر ألفا. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | لونان للبكسلات الداكنة والفاتحة. قيم القنوات RGB وألفا في `System::Drawing::Color` من `0` إلى `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | `hue` من `0` شامل إلى `360` غير شامل بالدرجات؛ `amount` من `-100` إلى `100` بالمائة. |
| [AddHSLEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | `hue` من `0` شامل إلى `360` غير شامل بالدرجات؛ التشبع والإضاءة من `-100` إلى `100` بالمائة. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | اللون البديل يستخدم قيم القناة من `0` إلى `255`. قيم ألفا الحالية لا تتغيّر. |
| [AddBlurEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | نصف القطر غير سالب ويقاس بالنقاط؛ `grow` يتحكم ما إذا كان المحتوى الضبابي قد يمتد خارج الحدود الأصلية. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | نسبة مئوية غير سلبية. استخدم `0` إلى `100` لتقليل الشفافية المعتادة: `0` شفّاف بالكامل و`100` يحافظ على ألفا الحالي. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` إلى `100` بالمائة شفافية. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` إلى `100` بالمائة حد ألفا. القيم الأقل تصبح شفافة؛ القيم عند الحد أو أعلى تصبح غير شفافة. |

لضبط تعديل ألفا ثابت، الشفافية والعتامة متكاملتان. على سبيل المثال، 35% شفافية تعادل مقدار تعديل ألفا 65%.

## **تطبيق السطوع والتباين**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) يرجّع عملية [IBrightnessContrast](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/ibrightnesscontrast/). تُزود الإعدادات العددية عند إنشاء العملية. طريقة `IBrightnessContrast::GetEffective` تُعيد قيماً محسوبة للقراءة فقط يمكن فحصها أو تسجيلها.

المثال التالي يزيد السطوع بنسبة 15% والتباين بنسبة 20%، ثم يعرض معاينة دون تعديل الصورة المضمّنة:

```cpp
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto brightnessContrast = imageTransform->AddBrightnessContrastEffect(15.0f, 20.0f);

auto effectiveValues = brightnessContrast->GetEffective();
Console::WriteLine(u"Brightness: {0}%", effectiveValues->get_Brightness());
Console::WriteLine(u"Contrast: {0}%", effectiveValues->get_Contrast());

auto preview = slide->GetImage();
preview->Save(u"brightness-contrast-preview.png", ImageFormat::Png);

presentation->Dispose();
```

[BrightnessContrast](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/brightnesscontrast/) هو امتداد تأثير صورة Office 2010 وهو أقل قابلية للنقل مقارنة بتأثير السطوع القياسي في DrawingML. عندما يجب أن يبقى السطوع والتباين قابلين للتحرير بعد جولة PPTX، استخدم [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) وتحقق من النتيجة بعد إعادة فتح الملف. يشرح قسم قيود التنسيق هذا الاختلاف بمزيد من التفصيل.

## **تطبيق تحويلات الألوان**

يمكن تطبيق تأثيرات اللون بشكل مستقل على إطارات صور مختلفة تُعيد استخدام مورد صورة واحد. المثال التالي ينشئ خمس إطارات ويطبق تدرج الرمادي، ثنائي اللون، صبغة، ضبط HSL، واستبدال اللون.

[IDuotone](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/iduotone/) يحتوي على معاملين لونيين قابليين للتحرير بشكل مستقل: `get_Color1` يطابق البكسلات الداكنة، بينما `get_Color2` يطابق البكسلات الفاتحة. هذا يجعله مثالاً مفيداً لتأثير إعداداته أكثر تعقيداً من قيمة عددية واحدة.

```cpp
#include <DOM/Effects/IColorReplace.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto grayFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 180.0f, 120.0f, image);
grayFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddGrayScaleEffect();

auto duotoneFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 220.0f, 20.0f, 180.0f, 120.0f, image);
auto duotone = duotoneFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddDuotoneEffect();
duotone->get_Color1()->set_Color(Color::get_Navy());
duotone->get_Color2()->set_Color(Color::get_Gold());

auto tintFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 420.0f, 20.0f, 180.0f, 120.0f, image);
tintFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddTintEffect(210.0f, 35.0f);

auto hslFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 120.0f, 170.0f, 180.0f, 120.0f, image);
hslFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddHSLEffect(30.0f, 20.0f, -10.0f);

auto replacementFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 320.0f, 170.0f, 180.0f, 120.0f, image);
auto colorReplacement = replacementFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddColorReplaceEffect();
colorReplacement->get_Color()->set_Color(Color::get_CornflowerBlue());

presentation->Save(u"color-transformations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) يستبدل لون كل بكسل بلون ثابت واحد مع الحفاظ على ألفا. إنه مختلف عن [AddColorChangeEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/)، الذي يطابق لون مصدر بلون هدف ويظهر صيغتي اللون للمصدر والهدف.

## **إضافة تأثيرات الضبابية والشفافية وألفا**

[AddBlurEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) يؤثر على جميع قنوات اللون، بما في ذلك ألفا. اضبط `grow` إلى `true` عندما قد يمتد الحافة الضبابية خارج حدود الصورة الأصلية.

لشفافية موحدة، استخدم [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). فهو يضاعف كل قيمة ألفا موجودة، لذا تبقى البكسلات شبه الشفافة نسبياً مختلفة. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) يعيّن قيمة ألفا واحدة لكل البكسلات. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) يحول ألفا إلى مستويين بناءً على حد.

```cpp
#include <DOM/Effects/IAlphaBiLevel.h>
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto blurredFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 140.0f, image);
auto blur = blurredFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBlurEffect(4.5, true);
blur->set_Radius(5.0);

auto transparentFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 20.0f, 200.0f, 140.0f, image);
auto alphaModulate = transparentFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(65.0f);
alphaModulate->set_Amount(60.0f);

auto uniformAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 180.0f, 200.0f, 140.0f, image);
uniformAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaReplaceEffect(55.0f);

auto binaryAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 180.0f, 200.0f, 140.0f, image);
auto binaryAlphaTransform = binaryAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto alphaBiLevel = binaryAlphaTransform->AddAlphaBiLevelEffect(50.0f);
alphaBiLevel->set_Threshold(45.0f);
binaryAlphaTransform->AddAlphaInverseEffect();

presentation->Save(u"blur-and-alpha-effects.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

عمليات ألفا بدون معاملات أخرى تشمل [AddAlphaCeilingEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/)، الذي يجعل كل ألفا غير صفرية غير شفافة تماماً؛ [AddAlphaFloorEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/)، الذي يجعل كل ألفا أقل من 100% شفافة بالكامل؛ و[AddAlphaInverseEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/)، الذي يغيّر ألفا إلى `100% - alpha`.

## **بناء سلسلة تأثير مرتبة**

كل طريقة `Add...Effect` تُضيف عملية جديدة إلى نهاية المجموعة. يستخدم المرسّخ المجموعة كخط أنابيب مرتب: ناتج العملية 0 يصبح مدخل العملية 1، وهكذا. نتيجةً لذلك، يمكن للعمليات نفسها بترتيب مختلف أن تُنتج صورة مختلفة.

على سبيل المثال، تدرج الرمادي يليه صبغة يزيل أولاً المعلومات اللونية ثم يُعيد تلوين نتيجة الإضاءة. صبغة يليه تدرج الرمادي يزيل الصبغة مرة أخرى. بالمثل، استبدال ألفا يمكنه أن يتجاوز قيم ألفا التي حسبتها عمليات سابقة، بينما تعديل ألفا يحافظ على الفروقات النسبية بينها.

المثال التالي يبني سلسلة من أربع عمليات، يحفظها كملف PPTX، يعيد فتح العرض، يتحقق من نوعية العمليات وترتيبها، ويُظهر النتيجة المفتوحة مجدداً:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IGrayScale.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ITint.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
imageTransform->AddGrayScaleEffect();
imageTransform->AddTintEffect(220.0f, 25.0f);
imageTransform->AddBlurEffect(2.5, false);
imageTransform->AddAlphaModulateFixedEffect(80.0f);

presentation->Save(u"image-transform-chain.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopenedPresentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto reopenedShape = reopenedPresentation->get_Slide(0)->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(reopenedShape))
{
    auto reopenedFrame = ExplicitCast<IPictureFrame>(reopenedShape);
    auto reopenedTransform = reopenedFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto orderIsPreserved = reopenedTransform->get_Count() == 4 && 
            ObjectExt::Is<IGrayScale>(reopenedTransform->idx_get(0)) && 
            ObjectExt::Is<ITint>(reopenedTransform->idx_get(1)) && 
            ObjectExt::Is<IBlur>(reopenedTransform->idx_get(2)) && 
            ObjectExt::Is<IAlphaModulateFixed>(reopenedTransform->idx_get(3));
    Console::WriteLine(orderIsPreserved ? u"The effect chain was preserved." : u"The effect chain changed during the round trip.");

    auto renderedSlide = reopenedPresentation->get_Slide(0)->GetImage();
    renderedSlide->Save(u"reopened-effect-chain.png", ImageFormat::Png);
}
else
{
    Console::WriteLine(u"The reopened shape is not a picture frame.");
}

reopenedPresentation->Dispose();
```

المجموعة لا تفرض مصفوفة توافق تقيد عمليات اللون، ألفا، والضبابية إلى سلاسل منفصلة. يمكن دمجها، لكن بعض التركيبات قد لا تكون مفيدة. استبدال اللون الثابت يزيل تنوع RGB الناتج عن تأثيرات لونية سابقة؛ تدرج الرمادي بعد ثنائي اللون يزيل اللونين المختارين؛ عمليات سقف ألفا، أرضية ألفا، الاستبدال أو الثنائي المستوى قد تطيح بتفاصيل ألفا التي أنشئتها عمليات سابقة. ابنِ السلسلة وفق تسلسل معالجة البكسل المطلوب بدلاً من اعتبار عناصرها كأعلام تنسيق غير مرتبة.

## **فحص القيم القابلة للتحرير والفعّالة**

عملية قابلة للتحرير هي الكائن المخزن في `ISlidesPicture::get_ImageTransform`. بناءً على التأثير، قد يُظهر أعضاء قابلة للكتابة مباشرة. على سبيل المثال، [IBlur](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/iblur/) يُظهر `set_Radius` و`set_Grow`، [IAlphaModulateFixed](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/ialphamodulatefixed/) يُظهر `set_Amount`، و[IAlphaBiLevel](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/ialphabilevel/) يُظهر `set_Threshold`. تأثيرات اللون مثل [IDuotone](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/iduotone/) تُظهر كائنات [IColorFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icolorformat/) قابلة للتعديل.

بعض واجهات العمليات، بما في ذلك [IBrightnessContrast](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/ibrightnesscontrast/)، [IHSL](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/ihsl/)، [ITint](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/itint/)، و[IAlphaReplace](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/ialphareplace/)، لا تُظهر المتغيرات الإنشائية كخصائص قابلة للكتابة. لتغيير هذه الإعدادات، احذف العملية وأضف بديلة في الموضع المطلوب.

البيانات الفعّالة التي تُرجعها `GetEffective()` محسوبة للقراءة فقط. هي مفيدة لحل ألوان تعتمد على السمة وقراءة القيم المُطَبَّقة التي يستخدمها المرسّخ، لكنها ليست سطح تحرير آخر. المثال التالي يعدد السلسلة ويفحص القيم الفعّالة لعدة عمليات شائعة:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IAlphaModulateFixedEffectiveData.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IBlurEffectiveData.h>
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IDuotoneEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();

    for (auto&& operation : imageTransform)
    {
        if (ObjectExt::Is<IBrightnessContrast>(operation))
        {
            auto brightnessContrast = ExplicitCast<IBrightnessContrast>(operation);
            auto data = brightnessContrast->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<ILuminance>(operation))
        {
            auto luminance = ExplicitCast<ILuminance>(operation);
            auto data = luminance->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<IDuotone>(operation))
        {
            auto duotone = ExplicitCast<IDuotone>(operation);
            auto data = duotone->GetEffective();
            Console::WriteLine(u"Dark color: {0}; light color: {1}", data->get_Color1(), data->get_Color2());
        }
        else if (ObjectExt::Is<IBlur>(operation))
        {
            auto blur = ExplicitCast<IBlur>(operation);
            auto data = blur->GetEffective();
            Console::WriteLine(u"Blur radius: {0} pt", data->get_Radius());
        }
        else if (ObjectExt::Is<IAlphaModulateFixed>(operation))
        {
            auto alphaModulate = ExplicitCast<IAlphaModulateFixed>(operation);
            auto data = alphaModulate->GetEffective();
            Console::WriteLine(u"Alpha amount: {0}%", data->get_Amount());
        }
    }
}

presentation->Dispose();
```

التأثيرات بدون معاملات مثل تدرج الرمادي، سقف ألفا، وعكس ألفا لا يزال لها كائن بيانات فعّالية، لكن لا توجد إعدادات عددية للطباعة. وجودها وموقعها في المجموعة هو ما يهم.

## **إزالة أو مسح تحويلات الصورة**

استخدم [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) لإزالة عملية واحدة بحسب الفهرس. بما أن الفهارس تتShift بعد الإزالة، ابحث عن الهدف أولاً وأزله بعد التعداد. استخدم `Clear()` لإزالة السلسلة بالكامل.

```cpp
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto blurIndex = -1;

    for (auto index = 0; index < imageTransform->get_Count(); ++index)
    {
        if (ObjectExt::Is<IBlur>(imageTransform->idx_get(index)))
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform->RemoveAt(blurIndex);
        Console::WriteLine(u"The blur operation was removed.");
    }

    imageTransform->Clear();
    Console::WriteLine(u"Remaining operations: {0}", imageTransform->get_Count());
    presentation->Save(u"image-transforms-cleared.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

إزالة أو مسح التحويلات يغيّر تنسيق الصورة فقط. ولا يحذف، يعيد ضغط، أو يغيّر مصدر [IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/) المُعاد استخدامه.

## **مراعاة تنسيقات العرض المستهدف وأهداف التصدير**

تنبثق تحويلات الصورة من DrawingML، لذا يُفضَّل تنسيق PPTX القابل للتحرير لسلاسل التأثير. حتى مع PPTX، لا كل عملية لديها قابلية نقل متساوية:

- عمليات DrawingML القياسية مثل السطوع، تدرج الرمادي، ثنائي اللون، الصبغة، HSL، الضبابية، والعمليات الشائعة لألفا لديها أفضل فرصة للبقاء بعد جولة PPTX. أعد فتح الملف المُولَّد وتفحص المجموعة عندما تكون الحفاظ على التعديلات مطلباً.
- [BrightnessContrast](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/brightnesscontrast/) هو امتداد Office 2010 وليس عملية السطوع القياسية في DrawingML. يمكن استخدامه للتصوير في الذاكرة، لكنه غير مضمون أن يبقى كـ[IBrightnessContrast](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/ibrightnesscontrast/) قابل للتحرير بعد حفظ وإعادة فتح PPTX. فضلاً عن ذلك استخدم [AddLuminanceEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) لتعديلات سطوع وتباين مستدامة.
- تنسيق PPT الثنائي يأتي قبل نموذج تأثير DrawingML الكامل. قد يحذف حفظ إلى PPT عمليات غير مدعومة، يقلل السلسلة إلى مجموعة فرعية مدعومة، أو يقرب المظهر. لا تستخدم PPT كتنسيق تحقق لسلسلة تحريرية معقّدة.
- التصيير إلى PNG أو JPEG أو TIFF أو PDF أو SVG أو HTML أو أي مخرج بصري آخر يطبق السلسلة المدعومة على المظهر المُصوَّر. تلك المخرجات لا تحتوي على `IImageTransformOperationCollection` قابلة للتحرير؛ صيغ الرستر تسطّح النتيجة إلى بكسلات، والصادرات المستندية أو المتجهة تخزن تمثيلها الخاص للرسوم.
- التأثيرات لا تجعل الصورة المرتبطة ذاتية الإحتواء. لا يزال تصوير صورة مرتبطة يعتمد على توفر المورد المرتبط عند تحميل العرض.

مستهلكو العروض المختلفون قد يصورون حالات الحافة بصورة مختلفة، خاصةً عندما تُدمج عدة عمليات ألفا أو تكميم ألوان. للخروج الحاسم، اختبر كل من جولة التحرير النهائية وتنسيق التصدير النهائي بنفس نسخة Aspose.Slides المستخدمة في الإنتاج.

## **الأسئلة المتكررة**

**هل تعدّ تأثيرات تحويل الصورة بيانات الصورة المضمّنة؟**

لا. العمليات تتبع `ISlidesPicture` المستخدمة في تعبئة الصورة. تبقى بايتات `IPPImage` الأساسية دون تغيير.

**هل تشارك إطارا صورة يعيدان استعمال نفس الصورة تأثيراتهما؟**

لا. إعادة استخدام `IPPImage` يجنّب تكرار بيانات الصورة، لكن كل إطار صورة عادةً ما يكون له `ISlidesPicture` منفصل ومجموعة تحويل صورة منفصلة.

**هل يمكن دمج تأثيرات اللون والضبابية وألفا؟**

نعم. المجموعة تقبلهم في سلسلة مرتبة واحدة. ضع في اعتبارك ما تفعله كل عملية على ناتج السابقة لأن عمليات الاستبدال والحد قد تتخلص من تفاصيل اللون أو ألفا السابقة.

**لماذا القيم الفعّالة للقراءة فقط؟**

البيانات الفعّالة تمثل القيم المحسوبة المستخدمة في التصيير، بما فيها الألوان المحلولة. حرّر العملية المخزنة في مجموعة التحويل حيثما توجد أعضاء قابلة للكتابة؛ وإلا احذفها وأضف بديلة بمعاملات إنشاء جديدة.

**أي تنسيق ينبغي أن أستخدمه للحفاظ على سلسلة التحويل؟**

استخدم PPTX وتحقق من الملف بإعادة فتحه. لا يمكن لتنسيق PPT القديم تمثيل نموذج تأثير DrawingML الكامل، وتنسيقات التصدير المرئية تحافظ على المظهر فقط وليس على عمليات التحويل القابلة للتحرير.