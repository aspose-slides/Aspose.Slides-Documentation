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
- تدرج رمادي
- ثنائي النغمة
- صبغ
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

يمثل Aspose.Slides تعديلات الصورة كمجموعة مرتبة من عملیات تحويل الصورة. لإطار صورة، ابدأ بـ [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/) الخاص بالإطار وادخل إلى [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/get_imagetransform/). مجموعة [IImageTransformOperationCollection](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/) التي يتم إرجاعها تتيح لك إلحاق، عد، فحص، حذف، ومسح التأثيرات دون إعادة كتابة بايتات الصورة الأصلية.

يوضح هذا المقال سير عمل كامل للسطوع والتباين، تحويلات الألوان، الضبابية، الشفافية، سلاسل التأثير المرتبة، القيم الفعّالة، الحذف، والتحقق من جولة PPTX.

## **فهم ملكية التأثير وإعادة استخدام الصورة**

مورد الصورة والصورة التي تعرضه كائنات مختلفة:

- يُخزّن أو يُشير [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) إلى بيانات الصورة المصدرية التي تملكها العروض.
- ينتمي [ISlidesPicture](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/) إلى تعبئة الصورة ويشير إلى مورد الصورة أثناء تخزين مجموعة تحويل الصورة.
- يمثل [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) شكل الشريحة الذي يملك تعبئة الصورة ذات الصلة، الهندسة، إعدادات القص, وغيرها من تنسيقات الإطار.

لذا، عمليات تحويل الصورة لا تعدل البايتات في [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/). عندما يتم تمرير نفس `IPPImage` إلى [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/) أكثر من مرة، يحصل كل إطار صورة جديد على `ISlidesPicture` خاص به ومجموعة تحويل خاصة به. تطبيق التدرج الرمادي على إطار واحد لا يجعل الأطر الأخرى رمادية، حتى وإن أعادت جميعها استخدام نفس مورد الصورة المضمّن.

نفس نموذج `ISlidesPicture::get_ImageTransform` يُستعمل أيضاً بواسطة تعبئات صور أخرى، مثل الشكل أو خلفية الشريحة. تركّز الأمثلة أدناه على إطارات الصور.

## **استخدام نطاقات ومعايير صحيحة للمعلمات**

الطرق الموضحة تستخدم النطاقات الدلالية والوحدات التالية. حافظ على القيم داخل هذه النطاقات حتى لو لم ترفض نسخة المكتبة المستخدمة القيم خارج النطاق مباشرة؛ قد يقوم تنسيق العرض المستهدف بتطبيع أو حذف أو رفض البيانات غير الصالحة أثناء الحفظ أو عند فتح PowerPoint للملف.

| العملية | المعاملات | النطاق والوحدة الصالحة |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` إلى `100`، نسبة مئوية؛ `0` يترك المكوّن دون تغيير. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | لا شيء | لا توجد معاملات رقمية. يبقى الألفا دون تغيير. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | لونان للبيكسلات الداكنة والفاتحة. قيم القنوات في `System::Drawing::Color` تتراوح من `0` إلى `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | درجة الصبغ `hue` من `0` شامل إلى `360` غير شامل، بالدرجات؛ `amount` من `-100` إلى `100`، نسبة مئوية. |
| [AddHSLEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | `hue` من `0` شامل إلى `360` غير شامل، بالدرجات؛ التشبع والسطوع من `-100` إلى `100`، نسبة مئوية. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | يستخدم اللون البديل قيم القنوات من `0` إلى `255`. قيم الألفا الحالية تبقى دون تغيير. |
| [AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | نصف القطر غير سالب ويُقاس بالنقاط؛ `grow` يحدِّد ما إذا كان المحتوى الضبابي قد يمتد خارج الحدود الأصلية. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | نسبة مئوية غير سلبية. استخدم `0` إلى `100` لتعديل الشفافية المعتاد: `0` يعني شفافية كاملة و`100` يحافظ على الألفا الحالي. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` إلى `100`، نسبة مئوية للشفافية. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` إلى `100`، نسبة مئوية لحدِّ الألفا. القيم الأدنى تصبح شفافة؛ القيم عند الحد أو فوقه تصبح غير شفافة. |

في تعديل الألفا الثابت، الشفافية والعتامة مكملان لبعضهما. على سبيل المثال، شفافية بنسبة 35% تعادل مقدار تعديل ألفا يساوي 65%.

## **تطبيق السطوع والتباين**

ترجع [IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) عملیات [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/). يتم تزويد الإعدادات العددية عند إنشاء العملية. تُعيد طريقة `IBrightnessContrast::GetEffective` القيم المقروءة‑فقط المحسوبة التي يمكن فحصها أو تسجيلها.

المثال التالي يرفع السطوع بنسبة 15% والتباين بنسبة 20%، ثم يعرض معاينة دون تعديل الصورة المضمّنة:

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

[BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/) هو امتداد لتأثير صورة في Office 2010 وهو أقل قابلية للنقل من تأثير السطوع القياسي في DrawingML. عندما يجب أن يبقى السطوع والتباين قابليين للتحرير بعد جولة PPTX، استخدم [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) وتحقق من النتيجة بعد إعادة فتح الملف. يوضح قسم قيود الصيغة هذا الفرق بمزيد من التفصيل.

## **تطبيق تحويلات الألوان**

يمكن تطبيق تأثيرات اللون بشكل مستقل على إطارات صور مختلفة تعيد استخدام مورد صورة واحد. المثال التالي ينشئ خمس إطارات ويطبق التدرج الرمادي، الثنائي النغمة، الصبغ، تعديل HSL، واستبدال اللون.

[IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/) يحتوي على معاملين للون يمكن تحريرهما بصورة مستقلة: `get_Color1` يطابق البكسلات الداكنة، بينما `get_Color2` يطابق البكسلات الفاتحة. هذا يجعله مثالاً مفيداً لتأثير إعداداته أكثر تعقيداً من قيمة عددية واحدة.

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) يستبدل لون كل بكسل بلون ثابت واحد مع الحفاظ على الألفا. يختلف عن [AddColorChangeEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/)، الذي يطابق لون مصدر إلى آخر ويوفر صيغتي اللون المصدر والهدف.

### **تطبيق عتبة السطوع**

يمكن لعتبة السطوع أن تجعل العلامات الخفيفة على صفحة ممسوحة ضوئياً أسهل للتمييز عن الخلفية. [AddGrayScaleEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) يحافظ على درجات الرمادي الوسيطة. [AddBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/) يطابق السطوع مع الأسود أو الأبيض، بينما [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) يطبق عتبة على العتامة.

يتراوح نطاق عتبة السطوع من 0% إلى 100% شامل. البكسلات تحت العتبة تصبح سوداء. البكسلات عند العتبة أو فوقها تصبح بيضاء. رفع العتبة يجعل المزيد من الدرجات تصبح سوداء لأن المزيد منها يقع تحت الحد.

نزّل [grayscale-swatches.png](grayscale-swatches.png) إلى دليل العمل. كل تسمية تعطي مستوى الرمادي الأصلي على مقياس من 0 إلى 255. يضع المثال الأصلي بجوار نسختين ويحفظ عتبة كل نسخة في العرض.

```cpp
#include <DOM/Effects/IBiLevel.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 150, SlideSizeScaleType::DoNotScale);
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto imageData = File::ReadAllBytes(u"grayscale-swatches.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto addFrame = [&](float x, const String& caption)
{
    auto label = shapes->AddAutoShape(ShapeType::Rectangle, x, 12, 216, 36);
    label->get_TextFrame()->set_Text(caption);
    return shapes->AddPictureFrame(ShapeType::Rectangle, x, 60, 216, 72, image);
};

addFrame(12, u"Original");

auto lowThreshold = addFrame(252, u"Threshold 20%");
lowThreshold->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBiLevelEffect(20.0f);

auto highThreshold = addFrame(492, u"Threshold 60%");
highThreshold->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBiLevelEffect(60.0f);

presentation->Save(u"luminance-threshold.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

افتح العرض الناتج في PowerPoint للمقارنة بين الإطارات الثلاثة. العينة التي تحمل التسمية 96 لها تقريباً 38% سطوع (96 من 255). تتحول إلى أبيض عند عتبة 20% وإلى أسود عند عتبة 60%.

![عينات رمادية أصلية بجانب النتائج بالأبيض‑ والأسود عند عتبة سطوع 20% و60%](luminance-threshold.png)

## **إضافة ضبابية، شفافية، وتأثيرات ألفا**

[AddBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) يؤثر على جميع قنوات اللون، بما في ذلك الألفا. ضع `grow` إلى `true` عندما قد يمتد الحافة الضبابية خارج حدود الصورة الأصلية.

لشفافية موحدة، استخدم [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). يضرب كل قيمة ألفا موجودة، لذا تبقى البكسلات شبه الشفافة نسبياً مختلفة. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) يعيّن قيمة ألفا واحدة لكل البكسلات. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) يحوّل الألفا إلى مستويين بناءً على عتبة.

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

تشمل عمليات ألفا الخالية من المعاملات الأخرى [AddAlphaCeilingEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/)، التي تجعل كل ألفا غير الصفرية معتماً بالكامل؛ [AddAlphaFloorEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/)، التي تجعل كل ألفا أقل من 100% شفافة بالكامل؛ و[AddAlphaInverseEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/)، التي تغير الألفا إلى `100% - alpha`.

## **بناء سلسلة تأثير مرتبة**

كل طريقة `Add...Effect` تُلحق عملية جديدة إلى نهاية المجموعة. يستخدم العارض المجموعة كخط أنابيب مرتّب: مخرجات العملية 0 تصير مدخل العملية 1، وهكذا. وبالتالي، يمكن للعمليات نفسها بترتيب مختلف أن تُنتج صورة مختلفة.

على سبيل المثال، التدرج الرمادي يليه الصبغ يزيل أولاً المعلومات اللونية ثم يعيد تلوين نتيجة السطوع. الصبغ يليه التدرج الرمادي يُعيد حذف الصبغ مرة أخرى. بالمثل، استبدال الألفا يمكن أن يتجاوز قيم الألفا التي حسبتها عمليات سابقة، بينما تعديل الألفا يحافظ على اختلافاتها النسبية.

المثال التالي يبني سلسلة من أربع عمليات، يحفظها كـ PPTX، يعيد فتح العرض، يتحقق من نوعيات العمليات وترتيبها، ثم يُظهر النتيجة المعاد فتحها:

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

المجموعة لا تفرض مصفوفة توافق تقيد عمليات اللون، الألفا، والضبابية إلى سلاسل منفصلة. يمكن جمعها، لكن الجمع ليس دائماً مفيداً. استبدال اللون الثابت يزيل تباين RGB الناتج عن تأثيرات اللون السابقة؛ التدرج الرمادي بعد الثنائي النغمة يزيل اللونين المحددين؛ وعملية عتبة الألفا (السقف، الأرضية، الاستبدال أو الثنائي) قد تتخلص من تفاصيل الألفا التي أُنتجت في وقت سابق. بّن السلسلة وفق التسلسل المطلوب لمعالجة البكسل بدلاً من اعتبار عناصرها كعلامات تنسيق غير مرتبة.

<!-- visual-explanation:image-transform-effects:start -->
[![نفس الصورة تمر عبر التدرج الرمادي ثم الصبغ، ومن ثم الصبغ ثم التدرج الرمادي. الصورتان النهائيتان بتدرج رمادي لهما نغمات مختلفة.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*في هذا العرض التوضيحي لـ Aspose.Slides for .NET 26.11، الصبغ بزاوية 220° وبنسبة 25% لا يغيّر الصورة الرمادية. تطبيق الصبغ نفسه قبل التدرج الرمادي ينتج نغمات مختلفة.*
<!-- visual-explanation:image-transform-effects:end -->

## **فحص القيم القابلة للتحرير والقيم الفعّالة**

العملية القابلة للتحرير هي الكائن المخزن في `ISlidesPicture::get_ImageTransform`. بناءً على التأثير، قد تُظهر أعضاء قابلة للكتابة مباشرة. على سبيل المثال، [IBlur](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/) يُظهر `set_Radius` و `set_Grow`، و[IAlphaModulateFixed](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphamodulatefixed/) يُظهر `set_Amount`، و[IAlphaBiLevel](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphabilevel/) يُظهر `set_Threshold`. تأثيرات اللون مثل [IDuotone](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iduotone/) تُظهر كائنات [IColorFormat](https://reference.aspose.com/slides/cpp/aspose.slides/icolorformat/) قابلة للتعديل.

بعض واجهات العملية، بما فيها [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/)، [IHSL](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ihsl/)، [ITint](https://reference.aspose.com/slides/cpp/aspose.slides.effects/itint/)، و[IAlphaReplace](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ialphareplace/)، لا تكشف عن القيم العددية التي أنشئت بها كخصائص قابلة للكتابة. لتغيير تلك الإعدادات، احذف العملية وأضف عملية بديلة في الموضع المطلوب.

البيانات الفعّالة التي تُرجعها `GetEffective()` محسوبة ولا يمكن تعديلها. هي مفيدة لحل ألوان تعتمد على السمة وقراءة القيم المُعالجة التي يستخدمها العارض، لكنها ليست سطح تحرير آخر. المثال التالي يعدّ السلسلة ويفحص القيم الفعّالة لعدة عمليات شائعة:

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

التأثيرات الخالية من المعاملات مثل التدرج الرمادي، عتبة الألفا السقفي، والعتبة العكسية لا يزال لديها كائن بيانات فعّالة، لكن لا توجد إعدادات عددية للطباعة. وجودها وموقعها في المجموعة هو ما يهم.

## **إزالة أو مسح تحويلات الصورة**

استخدم [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) لإزالة عملية واحدة بحسب الفهرس. لأن الفهارس تتحرك بعد الإزالة، ابحث أولاً عن الهدف ثم احذفه بعد العد. استخدم `Clear()` لإزالة السلسلة بالكامل.

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

إزالة أو مسح التحويلات يغيّر تنسيق الصورة فقط. لا يحذف، ولا يعيد ضغط، ولا يغيّر مورد [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) المُعاد استخدامه.

## **مراعاة صيغ العرض وأهداف التصدير**

تعود تحويلات الصورة إلى DrawingML، لذا يُفضَّل PPTX كصيغة تحرير لسلاسل التأثير. حتى مع PPTX، ليست كل عملية لها قابلية نقل متطابقة:

- عمليات DrawingML القياسية مثل السطوع، التدرج الرمادي، الثنائي النغمة، الصبغ، HSL، الضبابية، والعمليات الألفا الشائعة لديها أفضل فرصة للبقاء بعد جولة PPTX. تأكد دائماً من إعادة فتح الملف المُنشأ وفحص المجموعة عندما يكون الحفاظ مطلوباً.
- [BrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/brightnesscontrast/) امتداد Office 2010 وليس عملية السطوع القياسية في DrawingML. يمكن استخدامها للتصيّر داخل الذاكرة، لكنها ليست مضمونة لتبقى [IBrightnessContrast](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ibrightnesscontrast/) قابلة للتحرير بعد الحفظ وإعادة الفتح. فضلًا عن [AddLuminanceEffect](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) لتعديلات السطوع والتباين المستدامة.
- تنسيق PPT الثنائي يسبق نموذج تأثير DrawingML الكامل. قد يتجاهل حفظ إلى PPT عمليات غير مدعومة، أو يقلل السلسلة إلى مجموعة فرعية مدعومة، أو يقرّب المظهر. لا تستخدم PPT كصيغة تحقق لسلسلة تحرير معقّدة.
- التصيّر إلى PNG، JPEG، TIFF، PDF، SVG، HTML أو أي مخرجات بصرية أخرى يطبق السلسلة المدعومة على الشكل النهائي. هذه المخرجات لا تحتوي على `IImageTransformOperationCollection` قابل للتحرير؛ صيغ الرستر تُسطّح النتيجة إلى بكسلات، وتصدير المستند أو المتجه يخزن تمثيله الخاص بالرندر.
- التأثيرات لا تجعل الصورة المرتبطة مكتفية ذاتياً. لا يزال عرض صورة مرتبطة يعتمد على توفر المورد المرتبط عند تحميل العرض.

قد يعرض مستهلكو العروض المختلفون حالات الحافة بصورة مختلفة، خصوصاً عندما تُجمع عدة عمليات ألفا أو تكميم ألوان. للنتائج الحرجة، اختبر كلًّا من جولة التحرير النهائية وصيغة التصدير النهائية باستخدام نفس نسخة Aspose.Slides المستخدمة في الإنتاج.

## **الأسئلة الشائعة**

**هل تعدّل تأثيرات تحويل الصورة بيانات الصورة المضمّنة؟**

لا. العمليات تنتمي إلى `ISlidesPicture` المستخدم في تعبئة الصورة. تبقى بايتات `IPPImage` الأساسية دون تغيير.

**هل تشارك إطارا صورة يعيدان استخدام نفس الصورة تأثيراتهما؟**

لا. إعادة استخدام `IPPImage` تُجنب تكرار بيانات الصورة، لكن كل إطار صورة عادةً ما يمتلك `ISlidesPicture` ومجموعة تحويل منفصلة.

**هل يمكن دمج تأثيرات اللون، الضبابية، والألفا؟**

نعم. تقبل المجموعة دمجها في سلسلة مرتبة. ضع في اعتبارك ما تفعله كل عملية على ناتج العملية السابقة لأن عمليات الاستبدال والعتبة قد تُزيل تفاصيل اللون أو الألفا السابقة.

**لماذا القيم الفعّالة للقراءة فقط؟**

البيانات الفعّالة تمثل القيم المحسوبة المستخدمة في الرندر، بما فيها الألوان المُحلَّة. عدّل العملية المخزّنة في مجموعة التحويل حيث تتوفر أعضاء قابلة للكتابة؛ وإلا احذفها وأضف بديلة بالمعايير الجديدة.

**أي صيغة يجب أن أستخدمها للحفاظ على سلسلة التحويل؟**

استخدم PPTX وتحقق من الملف بإعادة فتحه. لا يمكن لـ PPT التقليدي تمثيل نموذج تأثير DrawingML الكامل، وتنسيقات التصدير النهائية تُحافظ على المظهر فقط دون عمليات تحويل قابلة للتحرير.