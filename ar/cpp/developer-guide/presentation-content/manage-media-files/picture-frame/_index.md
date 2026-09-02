---
title: "إدارة إطارات الصور في العروض التقديمية باستخدام C++"
linktitle: "إطار صورة"
type: docs
weight: 10
url: /ar/cpp/picture-frame/
keywords:
  - "إطار صورة"
  - "إضافة إطار صورة"
  - "إنشاء إطار صورة"
  - "صورة مضمَّنة"
  - "صورة مرتبطة"
  - "استخراج صورة"
  - "صورة نقطية"
  - "صورة SVG"
  - "قص صورة"
  - "حذف المناطق المقصوصة"
  - "ضغط صورة"
  - "StretchOffset"
  - "تنسيق إطار الصورة"
  - "مقياس نسبي"
  - "تأثير صورة"
  - "نسبة الأبعاد"
  - "PowerPoint"
  - "OpenDocument"
  - "عرض تقديمي"
  - "C++"
  - "Aspose.Slides"
description: "إنشاء وتنسيق وربط وقص واستخراج وضغط إطارات الصور في العروض التقديمية باستخدام Aspose.Slides للغة C++."
---
## **نظرة عامة**

إطار الصورة هو شكل شريحة يعرض صورة. في Aspose.Slides، مورد الصورة وال形形 الذي يعرضها كائنات منفصلة: فإنّ الـ[Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) يملك موارد الصور المضمَّنة عبر [مجموعة الصور](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_images/)، بينما يتحكم الـ[IPictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipictureframe/) في موضع الصورة، حجمها، تنسيق الخط، الدوران، القص، تأثيرات الصورة، وإعدادات الإطار الأخرى.

هذا الفصل مفيد عندما تُظهر الصورة نفسها أكثر من مرة. أضف الصورة إلى العرض مرة واحدة، احتفظ بالـ[IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/) المعاد، واستخدم مورد الصورة هذا عند إنشاء إطارات الصور.

يمكن لإطارات الصور أن تحتوي على صور نقطية مثل PNG أو JPEG وصور SVG المتجهية. يمكنها أيضًا الإشارة إلى صور مرتبطة بدلاً من تخزين بايتات الصورة داخل العرض. الاختيار يؤثر على القابلية للنقل، حجم الملف، الاستخراج، وسلوك التصدير، لذا من المفيد تحديد كيفية تخزين الصورة قبل تطبيق التنسيق أو التحسين.

## **إضافة وتنسيق صورة مضمَّنة**

لصورة مضمَّنة، أضف بيانات الصورة إلى العرض وأنشئ إطار صورة باستخدام [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/shapecollection/addpictureframe/). تصبح الصورة جزءًا من حزمة العرض، وبالتالي يبقى العرض ذاتيًا عند نقله إلى جهاز كمبيوتر آخر.

المثال التالي يضيف صورة JPEG، ينشئ إطارًا بأبعاد الصورة الأصلية، ويطبق تنسيق الخط والدوران:

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

يتحكم إطار الصورة في الهندسة المعروضة؛ تغيير حجم الإطار لا يغيّر أبعاد البكسل الأصلية المخزَّنة في مورد الصورة المضمَّنة. يصبح هذا التمييز مهمًا عند قص أو ضغط الصورة لاحقًا.

## **استخدام المقياس النسبي**

الـ[IPictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipictureframe/) يوفّر مقياس عرض وارتفاع نسبي للإطار. القيمة `1.0` تمثل 100٪ من حجم الصورة الأصلي. المقياس النسبي مفيد عندما يحتاج سير العمل إلى الحفاظ على علاقة بحجم الصورة المصدر بدلاً من حساب الأبعاد النهائية يدويًا.

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

تغيّر المقياس النسبي إعدادات مقياس الإطار؛ لا يقوم بإعادة أخذ عينات أو ضغط الصورة المضمَّنة.

## **الصور المضمَّنة والمرتبطة**

الصورة المضمَّنة تخزن بيانات الصورة داخل العرض وبالتالي هي الخيار الأكثر أمانًا للنقل والعرض المتوقع. الصورة المرتبطة تخزن مسارًا خارجيًا عبر رابط الـ[ISlidesPicture](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidespicture/) بدلاً من تضمين بيانات الصورة بنفس الطريقة.

يمكن للصور المرتبطة تقليل كمية بيانات الصورة المخزَّنة في PPTX، لكنها تُدخل تبعية خارجية. يجب أن يبقى الملف المرتبط متاحًا للتطبيق الذي يفتح أو يُظهر العرض. إذا تغير المسار أو تم نقل الملف أو كان المورد غير متوفر، قد لا يُعرض الإطار المرتبط كما هو متوقع. بالنسبة للعرض الذي يجب إرساله بالبريد الإلكتروني أو أرشفته أو عرضه في بيئات معزولة، تكون الصور المضمَّنة عادة أكثر موثوقية.

### **إضافة صورة مرتبطة**

المثال التالي ينشئ إطار صورة ويشير إليه إلى ملف صورة محلي. يتعامل فقط مع ربط الصور؛ ربط الفيديو هو سير عمل وسائط منفصل ولا يُدمج عمدًا في هذا المثال.

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

استخدم الروابط عندما يكون إدارة الملفات الخارجية مقصودة. لا تستخدمها مجرد بديل للضغط: PPTX صغير به تبعيات صورة مكسورة عادةً ما يكون أقل فائدة من عرض أكبر ذاتيًا.

## **استخراج الصور من إطارات الصور**

قبل استخراج صورة من عرض موجود، تحقق أن الشكل هو فعلاً [IPictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipictureframe/) وأنه يحتوي على صورة مضمَّنة. إطارات الصور المرتبطة قد لا تحتوي على بايتات صورة يمكن استخراجها بنفس الطريقة.

### **استخراج صورة نقطية**

واجهة برمجة التطبيقات الحديثة للصور تستخدم [IImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimage/) مباشرة. المثال التالي يعثر على أول صورة نقطية مضمَّنة على شريحة ويحفظها كـ PNG:

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

الحفظ عبر [IImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimage/) يحوّل الصورة المستخرجة إلى صيغة الإخراج المطلوبة. إذا كنت تحتاج إلى البايتات المشفرة المخزَّنة في العرض بدلاً من ملف نقطي محوَّل، استخدم البيانات الثنائية لمورد الصورة بدلاً من ذلك.

### **استخراج صورة SVG**

بالنسبة لصورة SVG، يُظهر [IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/) كائنًا من نوع [ISvgImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isvgimage/). يتيح لك ذلك استرجاع بيانات SVG مباشرة بدلاً من تحويل الصورة إلى نقطية أولًا.

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

الإبقاء على محتوى SVG كـ SVG يحافظ على المصدر المتجه داخل العرض. تصدير النقطية مثل PNG أو JPEG يلزم تحويل ذلك المحتوى المتجه إلى بكسلات. تصدير الشريحة كـ PDF أو SVG هو أيضًا عملية عرض، لذا لا ينبغي اعتبار الرسومات المصدَّرة نسخة مطابقة بايتًا لملف SVG المضمَّن الأصلي؛ استخدم بيانات الـ[ISvgImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isvgimage/) المضمَّنة عندما تكون الموارد المتجهة الأصلية مطلوبة.

## **قص صورة**

القص يغيّر أي جزء من الصورة يظهر داخل الإطار. قيم القص على [IPictureFillFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipicturefillformat/) هي نسب مئوية لأبعاد الصورة المصدر. القص لا يحذف البكسلات المخفية من الصورة المضمَّنة في البداية؛ إنه يغيّر فقط المنطقة المرئية.

المثال التالي يجد إطار صورة بأمان ويطبّق قيم القص:

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

نظرًا لأن بيانات الصورة المخفية لا تزال موجودة، يمكن تغيير القص لاحقًا دون فقدان البكسلات الأصلية. إذا كان حجم الملف أهم من القدرة على التراجع، يمكن إزالة المناطق المقصوصة فعليًا كما هو موضح في القسم التالي.

## **إزالة بيانات الصورة المقصوصة**

[IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) يزيل بيانات الصورة خارج مستطيل القص الحالي ويُعيد مورد الصورة الناتج. يمكن لهذا أن يقلل حجم الملف، لكنه تحسين تدميري: بعد حفظ العرض، لا تكون البكسلات المُزالة متاحة لعملية إلغاء القص لاحقًا.

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

قد تضيف الطريقة مورد صورة جديد إلى العرض. إذا كانت الصورة الأصلية تُستخدم أيضًا من قبل إطارات صور أخرى، فإن هذه الإطارات لا تزال تحتاج إلى المورد الحالي، لذا حذف المناطق المقصوصة لا يقلل بالضرورة من العدد الإجمالي للصور. قص محتوى WMF أو EMF بهذه الطريقة يُحوِّل النتيجة المقصوصة إلى PNG.

## **ضغط الصور النقطية**

[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipicturefillformat/compressimage/) يقلل دقة الصورة النقطية نسبة إلى الحجم الذي تُعرض به الصورة. يمكنه أيضًا إزالة المناطق المقصوصة في نفس العملية. تُعيد الطريقة `true` عندما يتم تغيير حجم الصورة أو قصها و`false` عندما لا يكون هناك تغيير ضروري.

استخدم قيمة مسبقة التعريف من [PicturesCompression](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/picturescompression/) عندما تكون دقة هدف قياسية كافية:

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

يمكن تمرير قيمة DPI موجبة مخصصة بدلًا من قيمة التعداد عندما يكون الهدف محددًا.

الضغط مخصَّص للصور النقطية. محتوى SVG والملفات المتجهة لا يُقلَّص عبر هذا workflow للضغط النقطي. وتذكر أيضًا أن الدقة المنخفضة والمناطق المقصوصة المحذوفة لا يمكن استعادتها من العرض المُحسَّن. اختر دقة الهدف بناءً على أكبر حجم ستُعرض فيه الصورة فعليًا أو تُصدَّر إليه بدلاً من تطبيق أدنى DPI عالميًا.

## **إدارة تأثيرات تحويل الصورة**

للحصول على سير عمل كامل يغطي السطوع، التباين، تحويلات الألوان، الضبابية، تأثيرات ألفا، السلاسل المرتبة، الفحص، الإزالة، والتحقق المتبادل، راجع [Image Transform Effects](/slides/ar/cpp/image-transform-effects/).

## **قفل هندسة إطار الصورة**

إعدادات الـ[IPictureFrameLock](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipictureframelock/) تتحكم في عمليات التحرير التي تُعطَّل لإطار الصورة. على سبيل المثال، [قفل نسبة الأبعاد](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipictureframelock/set_aspectratiolocked/) يحافظ على نسب الشكل أثناء تغيير حجمه.

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

القفل ينطبق على شكل إطار الصورة. لا يجبر الصورة المصدر على إعادة أخذ عينات أو تغيير دائم لنسبة الأبعاد نفسها.

## **ضبط قيم StretchOffset**

عند وضع ملء الصورة على نمط الامتداد، تحدد قيم الـstretch‑offset على [IPictureFillFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipicturefillformat/) مستطيل الملء نسبةً إلى إطارات الصورة. النسب المئوية الإيجابية تُنشئ تقليصًا من الحافة، بينما النسب السلبية تُنشئ امتدادًا.

هذا مختلف عن القص. قيم القص تحدد أي جزء من الصورة المصدر يُظهر، بينما تُغيّر قيم الامتداد المستطيل الذي يُمتد فيه ملء الصورة المرئي.

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

استخدم قيم الامتداد لتحديد موضع الملء. استخدم خصائص القص عندما يكون الهدف إخفاء حواف الصورة المصدر.

## **الاعتبارات المتعلقة بالتخزين، حجم الملف، والتصدير**

التوازنات الرئيسية تكون أسهل في الإدارة عندما يُعامل تخزين الصورة وتنسيق إطار الصورة بشكل منفصل:

- **الصور المضمَّنة** تجعل العرض ذاتيًا وهي الأكثر موثوقية للمشاركة والعرض على الخوادم، لكن الصور النقطية الكبيرة تزيد حجم PPTX واستخدام الذاكرة.
- **الصور المرتبطة** يمكن أن تحافظ على صغر الحزمة، لكن العرض يعتمد على توافر الملفات الخارجية في المسارات أو المواقع المخزَّنة.
- **القص** في البداية غير تدميري. البكسلات المخفية تظل مضمَّنة حتى تُحذف المناطق المقصوصة صراحةً أو تُزال أثناء الضغط.
- **الضغط** قد يقلل حجم الملف بشكل كبير للصور النقطية الضخمة، لكنه يفضح الدقة المصدر. يُفضَّل تطبيقه بعد معرفة الحجم النهائي على الشريحة.
- **صور SVG** يجب أن تبقى كـ SVG عندما يكون الحفاظ على المتجه مهمًا. استخرج الـSVG المضمَّن مباشرة عندما تحتاج المورد المتجه نفسه. تصدير الشرائح إلى نمط نقطي دائمًا ما يحوّل الشريحة إلى بكسلات.
- **الصور المتكررة** ينبغي إعادة استخدام مورد [IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/) الموجود عندما يكون ذلك ممكنًا بدلاً من تحميل الملف نفسه مرارًا في سير عمل العرض.

للعروض الكبيرة، يكون تحسين الصور عادةً أكثر فاعلية عند تطبيقه بشكل انتقائي: حافظ على الشعارات والمخططات كمتجهات، اضغط الصور الفوتوغرافية وفقًا لحجم عرضها الفعلي، احذف البكسلات المقصوصة فقط عندما لا تكون التعديلات المستقبلية مطلوبة، وتجنب الروابط الخارجية إلا إذا كان إدارة التبعيات جزءًا من تصميم النشر.

## **الأسئلة الشائعة**

**ما الفرق بين إطار الصورة ومورد الصورة؟**

الـ[IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/) يمثل مورد صورة مرتبط بالعرض. الـ[IPictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipictureframe/) هو شكل على شريحة يعرض صورة ويخزن هندسة الإطار وتنسيقه مثل الحجم، الدوران، قيم القص، التأثيرات، والقفل.

**هل يجب أن أضمّن الصور أم أربطها؟**

ضمّن الصور عندما يحتاج العرض إلى أن يكون قابلًا للنقل أو مؤرشفًا أو يُعرض دون الوصول إلى موارد خارجية. اربط الصور فقط عندما يكون الاحتفاظ بملفات الصورة خارج PPTX مقصودًا ويمكن الحفاظ على المواقع الخارجية بشكل موثوق.

**هل يقلل القص من حجم ملف PPTX؟**

ليس بمفرده. إعدادات القص العادية تُخفي أجزاء من الصورة المصدر لكن تحتفظ بالبكسلات الأساسية. استخدم [IPictureFillFormat::DeletePictureCroppedAreas](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) أو ضغط الصورة مع حذف المناطق المقصوصة عندما يمكن حذف تلك البكسلات نهائيًا.

**هل يمكن استعادة جودة الصورة بعد الضغط؟**

لا. الضغط قد يقلل دقة الصورة المخزَّنة، وإزالة المناطق المقصوصة تحذف بيانات الصورة. احتفظ بالصورة المصدر الأصلية خارج العرض إذا كان قد يُطلب تحرير عالي الدقة لاحقًا.

**كيف يجب التعامل مع صور SVG؟**

احتفظ بمحتوى SVG كـ SVG عندما تكون وفاء المتجه مهمة. يمكن استخراج الـ[ISvgImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isvgimage/) المضمَّن مباشرة. عرض شريحة إلى صيغة نقطية مثل PNG أو JPEG يحوِّل SVG إلى بكسلات كجزء من صورة الشريحة.

**كيف أتجنب عمليات التحويل غير الآمنة عند قراءة الشرائح الموجودة؟**

تحقق من نوع الشكل قبل استخدام أعضاء خاصة بإطار الصورة. اختبر الشكل باستخدام [IPictureFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipictureframe/) قبل تنفيذ عملية التحويل في وقت التشغيل، وعين نتيجة التحويل إلى متغيّر محلي قبل الوصول إلى الأعضاء الخاصة بإطار الصورة.