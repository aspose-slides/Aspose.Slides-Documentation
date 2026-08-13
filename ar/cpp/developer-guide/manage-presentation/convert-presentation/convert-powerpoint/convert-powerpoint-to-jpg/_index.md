---
title: تحويل PPT و PPTX إلى JPG في C++
linktitle: PowerPoint إلى JPG
type: docs
weight: 60
url: /ar/cpp/convert-powerpoint-to-jpg/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى JPG
- العرض التقديمي إلى JPG
- الشريحة إلى JPG
- PPT إلى JPG
- PPTX إلى JPG
- حفظ PowerPoint كـ JPG
- حفظ العرض التقديمي كـ JPG
- حفظ الشريحة كـ JPG
- حفظ PPT كـ JPG
- حفظ PPTX كـ JPG
- تصدير PPT إلى JPG
- تصدير PPTX إلى JPG
- C++
- Aspose.Slides
description: "تحويل شرائح PowerPoint (PPT, PPTX) إلى صور JPG عالية الجودة في C++ باستخدام Aspose.Slides عبر أمثلة شفرة سريعة وموثوقة."
---
## **المقدمة**

يساعد تحويل عروض PowerPoint وOpenDocument إلى صور JPG في مشاركة الشرائح، تحسين الأداء، وتضمين المحتوى في المواقع أو التطبيقات. يتيح Aspose.Slides for C++ تحويل ملفات PPTX وPPT وODP إلى صور JPEG عالية الجودة. يشرح هذا الدليل طرق التحويل المختلفة.

مع هذه الميزات، من السهل تنفيذ عارض عروض خاص بك وإنشاء صورة مصغرة لكل شريحة. قد يكون ذلك مفيدًا إذا أردت حماية شرائح العرض من النسخ أو عرض العرض في وضع القراءة فقط. يسمح Aspose.Slides بتحويل العرض بالكامل أو شريحة معينة إلى تنسيقات الصور.

## **تحويل شرائح العرض إلى صور JPG**

فيما يلي الخطوات لتحويل ملف PPT أو PPTX أو ODP إلى JPG:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) .
1. الحصول على كائن الشريحة من النوع [ISlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islide/) من مجموعة شرائح العرض.
1. إنشاء صورة للشريحة باستخدام الطريقة [ISlide.GetImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islide/getimage/) .
1. استدعاء الطريقة [IImage.Save](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimage/save/) على كائن الصورة. مرر اسم ملف الإخراج وتنسيق الصورة كمعاملات.

{{% alert color="info" %}} 
**ملاحظة:** يختلف التحويل من PPT أو PPTX أو ODP إلى JPG عن التحويل إلى تنسيقات أخرى في Aspose.Slides for C++ API. بالنسبة للتنسيقات الأخرى، عادةً ما تستخدم الطريقة [IPresentation.Save](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/save/). ومع ذلك، بالنسبة للتحويل إلى JPG، تحتاج إلى استخدام الطريقة [IImage.Save](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimage/save/) .
{{% /alert %}} 

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/enumerator_adapter.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // إنشاء صورة شريحة بالمقياس المحدد.
    auto image = slide->GetImage(scaleX, scaleY);

    // حفظ الصورة إلى القرص بتنسيق JPEG.
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **تحويل الشرائح إلى JPG بأبعاد مخصصة**

لتغيير أبعاد صور JPG الناتجة، يمكنك ضبط حجم الصورة بتمريره إلى الطريقة [ISlide.GetImage(Size)](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method) . يتيح لك ذلك إنشاء صور بعرض وارتفاع محددين، مما يضمن أن يكون الناتج وفق متطلبات الدقة ونسبة الأبعاد. هذه المرونة مفيدة بشكل خاص عند إنشاء صور لتطبيقات الويب أو التقارير أو الوثائق، حيث تُطلب أبعاد دقيقة للصور.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

System::Drawing::Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // إنشاء صورة شريحة بالحجم المحدد.
    auto image = slide->GetImage(imageSize);

    // حفظ الصورة إلى القرص بتنسيق JPEG.
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **عرض التعليقات عند حفظ الشرائح كصور**

يوفر Aspose.Slides for C++ ميزة تسمح لك بعرض التعليقات على شرائح العرض عند تحويلها إلى صور JPG. هذه الوظيفة مفيدة بشكل خاص للحفاظ على الملاحظات أو التعليقات أو المناقشات التي يضيفها المتعاونون في عروض PowerPoint. من خلال تمكين هذا الخيار، تضمن ظهور التعليقات في الصور المولدة، مما يسهل مراجعة ومشاركة الملاحظات دون الحاجة لفتح ملف العرض الأصلي.

لنفترض أن لدينا ملف عرض باسم "sample.pptx" يحتوي على شريحة بها تعليقات:

![الشريحة مع التعليقات](slide_with_comments.png)

الشيفرة C++ التالية تحوِّل الشريحة إلى صورة JPG مع الحفاظ على التعليقات:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // تعيين الخيارات لتعليقات الشريحة.
    auto options = MakeObject<RenderingOptions>();
    options->set_SlidesLayoutOptions(commentOptions);

    // تحويل الشريحة الأولى إلى صورة.
    auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

    image->Save(u"Slide_1.jpg", ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

النتيجة:

![صورة JPG مع التعليقات](image_with_comments.png)

## **انظر أيضًا**

راجع خيارات أخرى لتحويل PPT أو PPTX أو ODP إلى صور، مثل:

- [تحويل PowerPoint إلى GIF](/slides/ar/cpp/convert-powerpoint-to-animated-gif/)
- [تحويل PowerPoint إلى PNG](/slides/ar/cpp/convert-powerpoint-to-png/)
- [تحويل PowerPoint إلى TIFF](/slides/ar/cpp/convert-powerpoint-to-tiff/)
- [تحويل PowerPoint إلى SVG](/slides/ar/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 
لمعرفة كيفية قيام Aspose.Slides بتحويل PowerPoint إلى صور JPG، جرّب هذه المحولات المجانية عبر الإنترنت: PowerPoint [PPTX إلى JPG](https://products.aspose.app/slides/ar/conversion/pptx-to-jpg) و [PPT إلى JPG](https://products.aspose.app/slides/ar/conversion/ppt-to-jpg) .
{{% /alert %}}

![محول PPTX إلى JPG عبر الإنترنت مجاني](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}

توفر Aspose تطبيق تجميع مجاني على الويب [FREE Collage web app](https://products.aspose.app/slides/ar/collage). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج [JPG إلى JPG](https://products.aspose.app/slides/ar/collage/jpg) أو PNG إلى PNG، وإنشاء [شبكات صور](https://products.aspose.app/slides/ar/collage/photo-grid)، وما إلى ذلك.

باستخدام نفس المبادئ الموضحة في هذه المقالة، يمكنك تحويل الصور من تنسيق إلى آخر. لمزيد من المعلومات، راجع هذه الصفحات: تحويل [صورة إلى JPG](https://products.aspose.com/slides/ar/cpp/conversion/image-to-jpg/); تحويل [JPG إلى صورة](https://products.aspose.com/slides/ar/cpp/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/ar/cpp/conversion/jpg-to-png/); تحويل [PNG إلى JPG](https://products.aspose.com/slides/ar/cpp/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/ar/cpp/conversion/png-to-svg/); تحويل [SVG إلى PNG](https://products.aspose.com/slides/ar/cpp/conversion/svg-to-png/).
{{% /alert %}}

## **الأسئلة الشائعة**

### هل تدعم هذه الطريقة التحويل الجماعي؟

نعم، يتيح Aspose.Slides التحويل الجماعي لعدة شرائح إلى JPG في عملية واحدة.

### هل يدعم التحويل عناصر SmartArt والرسوم البيانية والكائنات المعقدة الأخرى؟

نعم، يقوم Aspose.Slides بتصيير كل المحتوى، بما في ذلك SmartArt والرسوم البيانية والجداول والأشكال والمزيد. قد تختلف دقة التصيير قليلًا مقارنةً بـ PowerPoint، خاصةً عند استخدام خطوط مخصصة أو مفقودة.

### هل هناك أي قيود على عدد الشرائح التي يمكن معالجتها؟

لا يفرض Aspose.Slides أي حدود صارمة على عدد الشرائح التي يمكنك معالجتها. ومع ذلك، قد تواجه خطأ نفاد الذاكرة عند العمل مع عروض تقديمية كبيرة أو صور عالية الدقة.