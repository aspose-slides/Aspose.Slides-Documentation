---
title: تحويل العروض التقديمية إلى HTML5 في C++
linktitle: العرض التقديمي إلى HTML5
type: docs
weight: 40
url: /ar/cpp/export-to-html5/
keywords:
- PowerPoint إلى HTML5
- OpenDocument إلى HTML5
- عرض تقديمي إلى HTML5
- شريحة إلى HTML5
- PPT إلى HTML5
- PPTX إلى HTML5
- ODP إلى HTML5
- حفظ PPT كـ HTML5
- حفظ PPTX كـ HTML5
- حفظ ODP كـ HTML5
- تصدير PPT إلى HTML5
- تصدير PPTX إلى HTML5
- تصدير ODP إلى HTML5
- C++
- Aspose.Slides
description: "تصدير عروض PowerPoint و OpenDocument إلى HTML5 متجاوب باستخدام Aspose.Slides للغة C++. الحفاظ على التنسيق والرسوم المتحركة والتفاعلية."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عروض PowerPoint إلى HTML5 باستخدام Aspose.Slides. تغطي تصدير HTML5 الأساسي دون امتدادات ويب أو تبعيات إضافية، بالإضافة إلى خيارات التحكم في رسوميات الأشكال وانتقالات الشرائح. كما تُظهر العملية القياسية لتصدير PowerPoint إلى HTML، وتشرح كيفية إنشاء مخرجات HTML5 بوضع عرض الشرائح، وتوضح كيفية تضمين التعليقات في المستند المُصدّر عن طريق تكوين تخطيطها.

## **تصدير PowerPoint إلى HTML5**

هذا الكود C++ يوضح كيفية تصدير عرض تقديمي إلى HTML5.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="info" %}} 
في هذه الحالة، ستحصل على HTML نظيف. 
{{% /alert %}}

قد ترغب في تحديد إعدادات رسوميات الأشكال وانتقالات الشرائح بهذه الطريقة:

```cpp
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **تصدير PowerPoint إلى HTML**

هذا الكود C++ يوضح العملية القياسية لتصدير PowerPoint إلى HTML:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```

في هذه الحالة، يتم عرض محتوى العرض التقديمي عبر SVG على النحو التالي:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="ملاحظة" color="warning" %}} 
عند استخدام هذه الطريقة لتصدير PowerPoint إلى HTML، بسبب عرض SVG، لن تكون قادرًا على تطبيق الأنماط أو تحريك عناصر معينة. 
{{% /alert %}}

## **تصدير PowerPoint إلى عرض شرائح HTML5**

**Aspose.Slides** يتيح لك تحويل عرض تقديمي PowerPoint إلى مستند HTML5 تُعرض فيه الشرائح في وضع عرض الشرائح. في هذه الحالة، عند فتح ملف HTML5 الناتج في المتصفح، ترى العرض التقديمي في وضع عرض الشرائح على صفحة الويب.

هذا الكود C++ يوضح عملية تصدير PowerPoint إلى عرض شرائح HTML5:

```c++
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## **تحويل عرض تقديمي إلى مستند HTML5 مع التعليقات**

التعليقات في PowerPoint هي أداة تتيح للمستخدمين ترك ملاحظات أو ملاحظات على شرائح العرض التقديمي. تكون مفيدة بشكل خاص في المشاريع التعاونية، حيث يمكن لعدة أشخاص إضافة اقتراحاتهم أو ملاحظاتهم إلى عناصر شريحة معينة دون تعديل المحتوى الرئيسي. تُظهر كل تعليق اسم المؤلف، مما يسهل تتبع من ترك الملاحظة.

لنفترض أن لدينا عرض تقديمي PowerPoint محفوظ في الملف "sample.pptx".

![تعليقين على شريحة العرض التقديمي](two_comments_pptx.png)

عند تحويل عرض تقديمي PowerPoint إلى مستند HTML5، يمكنك بسهولة تحديد ما إذا كنت تريد تضمين التعليقات من العرض في المستند الناتج. للقيام بذلك، تحتاج إلى تحديد معلمات عرض التعليقات في الطريقة `get_NotesCommentsLayouting` من فئة [Html5Options](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/html5options/).

الكود التالي يوضح تحويل عرض تقديمي إلى مستند HTML5 مع عرض التعليقات إلى يمين الشرائح.
```cpp
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

المستند "output.html" موضح في الصورة أدناه.

![التعليقات في مستند HTML5 الناتج](two_comments_html5.png)

## **الأسئلة المتكررة**

### هل يمكنني التحكم فيما إذا كانت رسوميات الكائنات وانتقالات الشرائح ستعمل في HTML5؟

نعم، يقدم HTML5 خيارات منفصلة لتمكين أو تعطيل [رسوميات الشكل](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/html5options/set_animateshapes/) و[انتقالات الشرائح](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/html5options/set_animatetransitions/).

### هل يدعم إخراج التعليقات، وأين يمكن وضعها بالنسبة للشرائح؟

نعم، يمكن إضافة التعليقات في HTML5 وتحديد موقعها (مثلاً إلى يمين الشريحة) من خلال إعدادات تخطيط الملاحظات والتعليقات.

### هل يمكنني تخطي الروابط التي تستدعي JavaScript لأسباب أمنية أو سياسات CSP؟

نعم، هناك [إعداد](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) يسمح لك بتخطي الروابط التي تحتوي على استدعاءات JavaScript أثناء الحفظ. يساعد ذلك في الامتثال لسياسات الأمان الصارمة.