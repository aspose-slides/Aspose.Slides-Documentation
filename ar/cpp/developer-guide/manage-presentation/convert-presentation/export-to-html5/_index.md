---
title: تحويل العروض التقديمية إلى HTML5 باستخدام C++
linktitle: عرض تقديمي إلى HTML5
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
description: "تصدير عروض PowerPoint و OpenDocument إلى HTML5 متجاوب باستخدام Aspose.Slides for C++. الحفاظ على التنسيق والرسوم المتحركة والتفاعلية."
---

{{% alert title="معلومات" color="info" %}}

في [Aspose.Slides 21.9](/slides/ar/cpp/aspose-slides-for-cpp-21-9-release-notes/)، قمنا بتنفيذ دعم تصدير HTML5.

{{% /alert %}} 

تسمح لك عملية تصدير HTML5 هنا بتحويل PowerPoint إلى HTML. بهذه الطريقة، باستخدام القوالب الخاصة بك، يمكنك تطبيق خيارات مرنة للغاية تُحدِّد عملية التصدير ونتائج HTML وCSS وJavaScript وخصائص الرسوم المتحركة.

## **تصدير PowerPoint إلى HTML5**

يظهر هذا الكود C++ كيفية تصدير عرض تقديمي إلى HTML5.
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```


{{% alert color="primary" %}} 

في هذه الحالة ستحصل على HTML نظيف. 

{{% /alert %}}

قد ترغب في تحديد إعدادات لرسوميات الأشكال وانتقالات الشرائح بهذه الطريقة:
```cpp
using namespace Aspose::Slides;
using namespace Aspolve::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```


## **تصدير PowerPoint إلى HTML**

يُظهر هذا الكود C++ عملية PowerPoint القياسية إلى HTML:
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```


في هذه الحالة يُعرض محتوى العرض عبر SVG بصيغة مماثلة لهذا:
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

عند استخدامك لهذه الطريقة لتصدير PowerPoint إلى HTML، بسبب عرض SVG، لن تكون قادرًا على تطبيق الأنماط أو تحريك عناصر محددة. 

{{% /alert %}}

## **تصدير PowerPoint إلى عرض شرائح HTML5**

**Aspose.Slides** يتيح لك تحويل عرض PowerPoint إلى مستند HTML5 يتم فيه عرض الشرائح في وضع عرض الشرائح. في هذه الحالة، عند فتح ملف HTML5 الناتج في المتصفح، ترى العرض في وضع عرض الشرائح على صفحة الويب.

يعرض هذا الكود C++ عملية تصدير PowerPoint إلى عرض شرائح HTML5:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```


## **تحويل عرض تقديمي إلى مستند HTML5 مع التعليقات**

التعليقات في PowerPoint هي أداة تسمح للمستخدمين بترك ملاحظات أو ملاحظات على شرائح العرض. تكون مفيدة خاصة في المشاريع التعاونية، حيث يمكن لعدة أشخاص إضافة اقتراحاتهم أو ملاحظاتهم إلى عناصر شريحة معينة دون تعديل المحتوى الرئيسي. تُظهر كل تعليق اسم المؤلف، مما يسهل تتبع من ترك الملاحظة.

لنفترض أن لدينا عرض PowerPoint التالي المحفوظ في الملف "sample.pptx".

![تعليقان على شريحة العرض](two_comments_pptx.png)

عند تحويل عرض PowerPoint إلى مستند HTML5، يمكنك بسهولة تحديد ما إذا كنت تريد تضمين التعليقات من العرض في المستند الناتج. للقيام بذلك، تحتاج إلى تحديد معلمات العرض لتعليقات `get_NotesCommentsLayouting` في فئة [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/).

يحول المثال البرمجي التالي عرضًا تقديميًا إلى مستند HTML5 مع عرض التعليقات إلى يمين الشرائح.
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```


يظهر مستند "output.html" في الصورة أدناه.

![التعليقات في وثيقة HTML5 الناتجة](two_comments_html5.png)

## **الأسئلة المتكررة**

**هل يمكنني التحكم فيما إذا كانت رسوميات الكائنات وانتقالات الشرائح ستُشغل في HTML5؟**

نعم، يوفر HTML5 خيارات منفصلة لتمكين أو تعطيل [رسوميات الأشكال](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) و[انتقالات الشرائح](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/).

**هل يدعم إخراج التعليقات، وأين يمكن وضعها بالنسبة للشرائح؟**

نعم، يمكن إضافة التعليقات في HTML5 وتحديد موضعها (على سبيل المثال، إلى يمين الشريحة) عبر إعدادات تخطيط الملاحظات والتعليقات.

**هل يمكنني تخطي الروابط التي تستدعي JavaScript لأسباب أمنية أو سياسات CSP؟**

نعم، هناك [إعداد](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) يتيح لك تخطي الروابط التي تحتوي على استدعاءات JavaScript أثناء الحفظ. يساعد ذلك على الامتثال لسياسات الأمان الصارمة.