---
title: إدارة إطارات الصور في العروض التقديمية باستخدام C++
linktitle: إطار الصورة
type: docs
weight: 10
url: /ar/cpp/picture-frame/
keywords:
- إطار الصورة
- إضافة إطار صورة
- إنشاء إطار صورة
- صورة مدمجة
- صورة مرتبطة
- استخراج صورة
- صورة نقطية
- صورة SVG
- قص صورة
- حذف المناطق المقتصة
- ضغط صورة
- StretchOffset
- تنسيق إطار الصورة
- مقياس نسبي
- تأثير الصورة
- نسبة الأبعاد
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "إنشاء وتنسيق وربط واقتصاص وضغط إطارات الصور في العروض التقديمية باستخدام Aspose.Slides لـ C++."
---
## **نظرة عامة**

إطار الصورة هو شكل شريحة يعرض صورة. في Aspose.Slides، مورد الصورة والشكل الذي يعرضها كائنان منفصلان: الـ[Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) يمتلك موارد الصور المضمنة عبر [مجموعة الصور](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_images/) الخاصة به، بينما يتحكم الـ[IPictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipictureframe/) في موقع الصورة، حجمها، تنسيق الخط، الدوران، الاقتصاص، تأثيرات الصورة، وإعدادات الإطار الأخرى.

هذه الفصلية مفيدة عندما تُظهر الصورة نفسها أكثر من مرة. أضف الصورة إلى العرض مرة واحدة، احتفظ بـ[IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/) المرجعية، واستخدم هذا المورد عند إنشاء إطارات الصور.

يمكن لإطارات الصور احتواء صور نقطية مثل PNG أو JPEG وصور SVG المتجهة. يمكنها أيضاً الإشارة إلى صور مرتبطة بدلاً من تخزين بايتات الصورة داخل العرض. يؤثر الاختيار على قابلية النقل، حجم الملف، الاستخراج، وسلوك التصدير، لذا من المفيد تحديد كيفية تخزين الصورة قبل تطبيق التنسيق أو التحسين.

## **إضافة وتنسيق صورة مدمجة**

لصورة مدمجة، أضف بيانات الصورة إلى العرض وأنشئ إطار صورة باستخدام [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/shapecollection/addpictureframe/). تصبح الصورة جزءاً من حزمة العرض، وبالتالي يظل العرض مستقلاً عندما يُنقل إلى حاسوب آخر.

المثال التالي يضيف صورة JPEG، ينشئ إطاراً بأبعاد الصورة الأصلية، ويطبق تنسيق الخط والدوران:

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
pictureFrame->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
pictureFrame->get_LineFormat()->set_Width(3.0);
pictureFrame->set_Rotation(15.0f);

presentation->Save(u"picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

يتحكم إطار الصورة في الهندسة المعروضة؛ تغيير حجم الإطار لا يغير أبعاد البكسل الأصلية المخزنة في مورد الصورة المدمجة. يصبح هذا الفارق مهماً عند الاقتصاص أو ضغط الصورة لاحقاً.

## **استخدام المقياس النسبي**

الـ[IPictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipictureframe/) يتيح تعديل مقياس العرض والارتفاع النسبي للإطار. القيمة `1.0` تمثل 100٪ من حجم الصورة الأصلي. المقياس النسبي مفيد عندما يحتاج سير العمل إلى الحفاظ على علاقة بحجم الصورة المصدر بدلاً من حساب الأبعاد النهائية يدويًا.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, image);
pictureFrame->set_RelativeScaleWidth(1.35f);
pictureFrame->set_RelativeScaleHeight(0.8f);

presentation->Save(u"relative-scale.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

المقياس النسبي يغيّر إعدادات مقياس الإطار؛ لا يُعيد أخذ عينات أو ضغط الصورة المدمجة.

## **الصور المدمجة والمرتبطة**

الصورة المدمجة تخزن بيانات الصورة داخل العرض وبالتالي هي الخيار الأكثر أماناً للنقل والعرض المتنبئ. الصورة المرتبطة تخزن مسار موقع خارجي عبر رابط الـ[ISlidesPicture](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidespicture/) بدلاً من تضمين بيانات الصورة بنفس الطريقة.

يمكن للصور المرتبطة تقليل كمية بيانات الصورة المخزنة في PPTX، لكنها تُدخل اعتماداً خارجياً. يجب أن يظل الملف المرتبط متاحاً للتطبيق الذي يفتح أو يعرض العرض. إذا تغير المسار أو نُقل الملف أو أصبح المورد غير متاح، قد لا تُعرض الصورة المرتبطة كما هو متوقع. بالنسبة للعرض الذي يجب إرساله بالبريد الإلكتروني أو أرشفته أو عرضه في بيئات معزولة، تكون الصور المدمجة عادة أكثر موثوقية.

### **إضافة صورة مرتبطة**

المثال التالي يخلق إطار صورة ويشيره إلى ملف صورة محلي. يتعامل فقط مع ربط الصور؛ ربط الفيديو هو سير عمل وسائط منفصل ولا يُدمج عمدًا في هذا المثال.

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, nullptr);
auto linkPath = Path::GetFullPath(u"linked-image.jpg");
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(linkPath);

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

استخدم الروابط عندما يكون إدارة الملفات الخارجية مقصودة. لا تستخدمها فقط كبديل للضغط: PPTX صغير يحتوي على تبعيات صور مكسورة غالباً ما يكون أقل فائدة من عرض أكبر مكتمل ذاتياً.

## **استخراج الصور من إطارات الصور**

قبل استخراج صورة من عرض موجود، تأكد أن الشكل هو فعلاً [IPictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipictureframe/) وأنه يحتوي على صورة مدمجة. إطارات الصور المرتبطة قد لا تحتوي على بايتات صورة يمكن استخراجها بنفس الطريقة.

### **استخراج صورة نقطية**

واجهة برمجة التطبيقات الحديثة للصور تستخدم [IImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimage/) مباشرة. المثال التالي يجد أول صورة نقطية مدمجة على شريحة ويحفظها كـ PNG:

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr || embeddedImage->get_SvgImage() != nullptr)
    {
        continue;
    }

    auto rasterImage = embeddedImage->get_Image();
    rasterImage->Save(u"extracted-image.png", ImageFormat::Png);
    break;
}

presentation->Dispose();
```

الحفظ عبر [IImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimage/) يُحوِّل الصورة المستخرجة إلى تنسيق الإخراج المطلوب. إذا كنت بحاجة إلى البايتات المشفرة المخزنة في العرض بدلاً من ملف نقطي محوَّل، استخدم بيانات المورد الثنائي للصورة بدلاً من ذلك.

### **استخراج صورة SVG**

بالنسبة لصورة SVG، الـ[IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/) يوفّر كائنًا من نوع [ISvgImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isvgimage/). يتيح لك ذلك استرداد بيانات SVG مباشرة بدلاً من تحويل الصورة أولاً.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IPictureFrame>(shape))
    {
        continue;
    }

    auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
    auto embeddedImage = pictureFrame->get_PictureFormat()->get_Picture()->get_Image();
    if (embeddedImage == nullptr)
    {
        continue;
    }

    auto svgImage = embeddedImage->get_SvgImage();
    if (svgImage == nullptr)
    {
        continue;
    }

    File::WriteAllBytes(u"extracted-image.svg", svgImage->get_SvgData());
    break;
}

presentation->Dispose();
```

الحفاظ على محتوى SVG كـ SVG يحافظ على المصدر المتجه داخل العرض. تصدير النقطية مثل PNG أو JPEG يلزم بالضرورة تحويل هذا المحتوى المتجه إلى بكسلات. تصدير الشريحة إلى PDF أو SVG هو أيضاً عملية عرض، لذا لا ينبغي التعامل مع الرسومات المصدَّرة كنسخة بايت‑ل‑بايت من SVG المدمج الأصلي؛ استخدم بيانات الـ[ISvgImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isvgimage/) المدمجة عندما تكون الموارد المتجهة الأصلية مطلوبة.

## **اقتصاص الصورة**

يغيّر الاقتصاص الجزء المرئي من الصورة داخل الإطار. قيم الاقتصاص على [IPictureFillFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipicturefillformat/) هي نسب مئوية لأبعاد صورة المصدر. لا يحذف الاقتصاص البكسلات المخفية من الصورة المدمجة في البداية؛ إنه يغيّر فقط المنطقة المرئية.

المثال التالي يجد إطار صورة بأمان ويطبق قيم الاقتصاص:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
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
    pictureFrame->get_PictureFormat()->set_CropLeft(23.6f);
    pictureFrame->get_PictureFormat()->set_CropRight(21.5f);
    pictureFrame->get_PictureFormat()->set_CropTop(3.0f);
    pictureFrame->get_PictureFormat()->set_CropBottom(31.0f);
    presentation->Save(u"cropped-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

نظرًا لأن بيانات الصورة المخفية لا تزال موجودة، يمكن تعديل الاقتصاص لاحقًا دون فقد البكسلات الأصلية. إذا كان حجم الملف أهم من القابلية للعكس، يمكن إزالة المناطق المقتصة فعليًا كما هو موضح في القسم التالي.

## **إزالة بيانات الصورة المقتصة**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) يزيل بيانات الصورة خارج مستطيل الاقتصاص الحالي ويعيد المورد الصوري الناتج. يمكن لهذا أن يقلل حجم الملف، لكنه تحسين مدمر: بعد حفظ العرض، لا تكون البكسلات المحذوفة متاحة لعملية إلغاء الاقتصاص لاحقًا.

```cpp
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"cropped-image.pptx");
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
    auto croppedImage = pictureFrame->get_PictureFormat()->DeletePictureCroppedAreas();
    if (croppedImage != nullptr)
    {
        presentation->Save(u"cropped-data-removed.pptx", SaveFormat::Pptx);
    }
}

presentation->Dispose();
```

قد تضيف الطريقة مورد صورة جديد إلى العرض. إذا كانت الصورة الأصلية تُستخدم أيضًا بواسطة إطارات صور أخرى، فإن تلك الإطارات لا تزال تحتاج إلى موردها الحالي، لذا حذف المناطق المقتصة لا يقلل بالضرورة من إجمالي عدد الصور. اقتصاص محتوى WMF أو EMF بهذه الطريقة يحوِّل النتيجة المقتصة إلى PNG.

## **ضغط الصور النقطية**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipicturefillformat/compressimage/) يقلل دقة الصورة النقطية نسبة إلى الحجم الذي تُعرض به الصورة. يمكنه أيضًا إزالة المناطق المقتصة في نفس العملية. تُعيد الطريقة `true` عندما يتم تغيير حجم الصورة أو اقتصاصها و`false` عندما لا تكون هناك ضرورة للتغيير.

استخدم قيمة مسبقة التعريف من [PicturesCompression](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/picturescompression/) عندما تكون دقة الهدف القياسية كافية:

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/PicturesCompression.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
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
    auto compressed = pictureFrame->get_PictureFormat()->CompressImage(true, PicturesCompression::Dpi150);
    Console::WriteLine(compressed ? String(u"The image was compressed.") : String(u"No compression was necessary."));
    presentation->Save(u"compressed-image.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

يمكن تمرير قيمة DPI موجبة مخصصة بدلاً من قيمة التعداد عندما يكون هدف محدد مطلوبًا.

الضغط مخصص للصور النقطية. محتوى SVG والملفات الوصفية لا يُقلَّل بهذا workflow للضغط النقطي. تذكّر أيضًا أن الدقة المنخفضة والمناطق المقتصة المحذوفة لا يمكن استعادتها من العرض المحسّن. اختر هدف الدقة بناءً على أكبر حجم تُعرض فيه الصورة فعليًا أو تُصدره بدلاً من تطبيق أقل DPI عالميًا.

## **فحص تأثيرات الصورة**

تُخزن تأثيرات الصورة على الصورة المستخدمة في الإطار. يمكن لمجموعة تحويلات الصورة أن تحتوي على تأثيرات مثل تعديل ألفا ثابت للشفافية واللمعان للسطوع والتباين. المثال أدناه يقرأ بأمان كلا النوعين من التأثيرات من أول إطار صورة على شريحة:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
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

auto presentation = MakeObject<Presentation>(u"sample.pptx");
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

    for (auto&& effect : imageTransform)
    {
        if (ObjectExt::Is<IAlphaModulateFixed>(effect))
        {
            auto alphaModulateFixed = ExplicitCast<IAlphaModulateFixed>(effect);
            auto transparency = 100.0f - alphaModulateFixed->get_Amount();
            Console::WriteLine(String(u"Transparency: ") + transparency);
        }

        if (ObjectExt::Is<ILuminance>(effect))
        {
            auto luminanceEffect = ExplicitCast<ILuminance>(effect);
            auto luminance = luminanceEffect->GetEffective();
            Console::WriteLine(String(u"Brightness: ") + luminance->get_Brightness());
            Console::WriteLine(String(u"Contrast: ") + luminance->get_Contrast());
        }
    }
}

presentation->Dispose();
```

تُغيّر هذه التأثيرات طريقة عرض الصورة في الإطار؛ لا تعيد كتابة بايتات الصورة المدمجة الأصلية.

## **قفل هندسة إطار الصورة**

إعدادات [IPictureFrameLock](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipictureframelock/) تتحكم في عمليات التحرير التي تُعطَّل لإطار الصورة. على سبيل المثال، [قفل نسبة الأبعاد](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) يحافظ على نسب الشكل أثناء تغيير حجمه.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPictureFrameLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.jpg");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50, 100, image->get_Width(), image->get_Height(), image);
pictureFrame->get_PictureFrameLock()->set_AspectRatioLocked(true);

presentation->Save(u"locked-picture-frame.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

القفل يطبق على شكل إطار الصورة. لا يجبر صورة المصدر على أن تُعاد أخذ عيناتها أو تُغيّر بشكل دائم لتتناسب مع نفس نسبة الأبعاد.

## **ضبط قيم StretchOffset**

عند وضع ملء الصورة على وضع التمدد، تحدد قيم الـ stretch‑offset على [IPictureFillFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipicturefillformat/) مستطيل الملء نسبة إلى صندوق إطار الصورة. النسب المئوية الموجبة تُنشئ تقليلاً من الحافة، بينما النسب المئوية السالبة تُنشئ امتداداً.

هذا مختلف عن الاقتصاص. قيم الاقتصاص تُحدِّد أي جزء من صورة المصدر يُظهر، بينما تغيّر قيم الـ stretch‑offset المستطيل الذي يُمدَد فيه ملء الصورة المرئي.

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto sourceImage = Images::FromFile(u"photo.png");
auto image = presentation->get_Images()->AddImage(sourceImage);

auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, image);
pictureFrame->get_PictureFormat()->set_PictureFillMode(PictureFillMode::Stretch);
pictureFrame->get_PictureFormat()->set_StretchOffsetLeft(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetRight(12.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetTop(8.0f);
pictureFrame->get_PictureFormat()->set_StretchOffsetBottom(8.0f);

presentation->Save(u"stretch-offsets.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

استخدم الـ stretch‑offset لتحديد موضع الملء. استخدم خصائص الاقتصاص عندما يكون الهدف إخفاء حواف صورة المصدر.

## **الاعتبارات المتعلقة بالتخزين، حجم الملف، والتصدير**

تكون المقايضات الرئيسية أسهل في الإدارة عندما يُعامل تخزين الصورة وتنسيق إطار الصورة بشكل منفصل:

- **الصور المدمجة** تجعل العرض مكتملًا ذاتيًا وتُعد الأكثر موثوقية للمشاركة والعرض من جانب الخادم، لكن الصور النقطية الكبيرة تزيد من حجم PPTX واستخدام الذاكرة.
- **الصور المرتبطة** يمكن أن تُصغّر الحزمة، لكن العرض يعتمد على توفر الملفات الخارجية في المسارات أو المواقع المخزنة.
- **الاقتصاص** غير مدمر في البداية. تبقى البكسلات المخفية مدمجة حتى يتم حذف المناطق المقتصة صراحة أو إزالتها أثناء الضغط.
- **الضغط** يمكن أن يقلل حجم الملف بشكل كبير للصور النقطية الضخمة، لكنه يضحّي بدقة المصدر. يجب تطبيقه بعد معرفة الحجم المقصود على الشريحة.
- **صور SVG** ينبغي أن تبقى كـ SVG عندما يكون الحفاظ على المتجه مهمًا. استخرج الـ SVG المدمج مباشرة عندما تحتاج إلى المورد المتجهي نفسه. تصدير الشرائح إلى تنسيقات نقطية دائمًا يحوِّل الشريحة المرسومة إلى بكسلات.
- **الصور المتكررة** ينبغي إعادة استخدام مورد [IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/) الموجود عندما يكون ذلك ممكنًا بدلاً من تحميل نفس الملف مرارًا في سير عمل العرض.

للعروض الكبيرة، يكون تحسين الصور أكثر فاعلية عندما يُجرى انتقائيًا: احتفظ بالشعارات والمخططات ك conteúdo متجهي، اضغط الصور الفوتوغرافية وفقًا لحجم عرضها الفعلي، أزل البكسلات المقتصة فقط عندما لا يُطلب تحرير لاحق، وتجنب الروابط الخارجية إلا إذا كان إدارة التبعيات جزءًا من تصميم النشر.

## **الأسئلة المتكررة**

**ما الفرق بين إطار الصورة ومورد الصورة؟**

الـ[IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/) يمثل مورد صورة مرتبط بالعرض. الـ[IPictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipictureframe/) هو شكل على الشريحة يعرض صورة ويخزن هندسة الإطار وتنسيقه مثل الحجم، الدوران، قيم الاقتصاص، التأثيرات، والقيود.

**هل يجب أن أدمج الصور أم أربطها؟**

ادمج الصور عندما يجب أن يكون العرض قابلًا للنقل، مؤرشفًا، أو معروضًا دون الحاجة إلى موارد خارجية. اربط الصور فقط عندما يكون إبقاء ملفات الصور خارج PPTX مقصودًا ويمكن الحفاظ على المواقع الخارجية بشكل موثوق.

**هل يقلل الاقتصاص حجم ملف PPTX؟**

ليس بمفرده. إعدادات الاقتصاص العادية تخفي أجزاء من صورة المصدر لكن تحتفظ بالبكسلات الأساسية. استخدم [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) أو ضغط الصورة مع حذف المناطق المقتصة عندما يمكن حذف تلك البكسلات نهائيًا.

**هل يمكن استعادة جودة الصورة بعد الضغط؟**

لا. الضغط قد يقلل من دقة الصورة المخزنة، وإزالة المناطق المقتصة تحذف بيانات الصورة. احتفظ بالصورة الأصلية خارج العرض إذا كان قد يلزم تحرير عالي الدقة لاحقًا.

**كيف يجب التعامل مع صور SVG؟**

احتفظ بمحتوى SVG كـ SVG عندما تكون وفاء المتجه مهمة. يمكن استخراج الـ[ISvgImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isvgimage/) المدمج مباشرة. عرض الشريحة إلى تنسيق نقطي مثل PNG أو JPEG يحوِّل الـ SVG كجزء من صورة الشريحة.

**كيف يمكن تجنب عمليات التحويل غير الآمنة عند قراءة الشرائح الحالية؟**

تحقق من نوع الشكل قبل استخدام أعضاء خاصة بإطار الصورة. اختبر الشكل باستخدام [IPictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipictureframe/) قبل تطبيق تحويل في وقت التشغيل، وعيّن نتيجة التحويل إلى متغيّر محلي قبل الوصول إلى الأعضاء الخاصة بإطار الصورة.