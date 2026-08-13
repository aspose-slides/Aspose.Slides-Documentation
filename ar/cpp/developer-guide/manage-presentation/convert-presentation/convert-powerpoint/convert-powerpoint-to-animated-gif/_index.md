---
title: تحويل عروض PowerPoint التقديمية إلى GIF متحرك في C++
linktitle: PowerPoint إلى GIF
type: docs
weight: 65
url: /ar/cpp/convert-powerpoint-to-animated-gif/
keywords:
- GIF متحرك
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى GIF
- العرض التقديمي إلى GIF
- الشريحة إلى GIF
- PPT إلى GIF
- PPTX إلى GIF
- حفظ PPT كـ GIF
- حفظ PPTX كـ GIF
- تصدير PPT كـ GIF
- تصدير PPTX كـ GIF
- الإعدادات الافتراضية
- الإعدادات المخصصة
- PowerPoint
- العرض التقديمي
- C++
- Aspose.Slides
description: "قم بتحويل عروض PowerPoint (PPT, PPTX) بسهولة إلى GIF متحرك باستخدام Aspose.Slides للغة C++. نتائج سريعة وعالية الجودة."
---
## **نظرة عامة**

تسمح لك Aspose.Slides بتحويل عروض PowerPoint التقديمية إلى ملفات GIF متحركة باستخدام عدد قليل من أسطر الشيفرة. هذا مفيد عندما تحتاج إلى مشاركة محتوى الشرائح بتنسيق متحرك خفيف الوزن ومدعوم على نطاق واسع يمكن تضمينه في صفحات الويب أو في تطبيقات المراسلة أو في الوثائق. توضح هذه المقالة كيفية تصدير عرض تقديمي إلى GIF باستخدام الإعدادات الافتراضية وكيفية تخصيص النتيجة عن طريق تكوين خيارات مثل حجم الإطار، وتأخير الشريحة، ومعدل إطار الانتقال عبر [GifOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/gifoptions/).

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات الافتراضية**

يعرض لك هذا المثال البرمجي بلغة C++ كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام الإعدادات القياسية:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

سيتم إنشاء GIF المتحرك باستخدام المعلمات الافتراضية.

{{%  alert  title="TIP"  color="info"  %}} 
إذا كنت تفضّل تخصيص معلمات GIF، يمكنك استخدام الفئة [GifOptions](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.export.gif_options). راجع المثال البرمجي أدناه. 
{{% /alert %}} 

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام إعدادات مخصصة**

يعرض لك هذا المثال البرمجي كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام إعدادات مخصصة في C++:

``` cpp
#include <DOM/Presentation.h>
#include <Export/GifOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto gifOptions = System::MakeObject<GifOptions>();
// حجم GIF الناتج
gifOptions->set_FrameSize(System::Drawing::Size(960, 720));
// المدة التي ستُظهر فيها كل شريحة قبل أن تتغيّر إلى التالية
gifOptions->set_DefaultDelay(2000);
// زيادة عدد الإطارات في الثانية لتحسين جودة حركة الانتقال
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}
قد ترغب في الاطلاع على أداة تحويل مجانية [Text to GIF](https://products.aspose.app/slides/ar/text-to-gif) تم تطويرها بواسطة Aspose. 
{{% /alert %}}

## **الأسئلة الشائعة**

### ماذا لو لم تكن الخطوط المستخدمة في العرض التقديمي مثبتة على النظام؟

قم بتثبيت الخطوط المفقودة أو [تكوين الخطوط الاحتياطية](/slides/ar/cpp/powerpoint-fonts/). سيقوم Aspose.Slides بالبديل، لكن قد يختلف المظهر. بالنسبة للهوية البصرية، تأكد دائمًا من توفر الخطوط المطلوبة بشكل صريح.

### هل يمكنني وضع علامة مائية فوق إطارات GIF؟

نعم. يمكنك [إضافة كائن/شعار شبه شفاف](/slides/ar/cpp/watermark/) إلى الشريحة الرئيسية أو إلى الشرائح الفردية قبل التصدير — ستظهر العلامة المائية على كل إطار.