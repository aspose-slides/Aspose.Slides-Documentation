---
title: تحويل العروض التقديمية إلى HTML5 في C++
linktitle: العرض إلى HTML5
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
description: "تصدير عروض PowerPoint و OpenDocument إلى HTML5 متجاوب باستخدام Aspose.Slides للـ C++. الحفاظ على التنسيق والرسوم المتحركة والتفاعل."
---

{{% alert title="معلومات" color="info" %}}

في [Aspose.Slides 21.9](/slides/ar/cpp/aspose-slides-for-cpp-21-9-release-notes/)، قمنا بتنفيذ دعم لتصدير HTML5.

{{% /alert %}} 

تسمح لك عملية التصدير إلى HTML5 هنا بتحويل PowerPoint إلى HTML. بهذه الطريقة، باستخدام قوالبك الخاصة، يمكنك تطبيق خيارات مرنة جدًا تحدد عملية التصدير والـHTML وCSS وJavaScript وخصائص الرسوم المتحركة الناتجة. 

## **تصدير PowerPoint إلى HTML5**

يعرض هذا الكود C++ كيفية تصدير عرض تقديمي إلى HTML5.
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```


{{% alert color="primary" %}} 

في هذه الحالة ستحصل على HTML نظيف. 

{{% /alert %}}

قد ترغب في تحديد إعدادات رسوم تحريك الأشكال وانتقالات الشرائح بهذه الطريقة:
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```


## **تصدير PowerPoint إلى HTML**

يعرض هذا الكود C++ عملية تحويل PowerPoint إلى HTML القياسية:
```cpp
using namespace Aspense::Slides;
using namespace Aspense::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```


في هذه الحالة يتم عرض محتوى العرض التقديمي عبر SVG بالشكل التالي:
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

**Aspose.Slides** يسمح لك بتحويل عرض تقديمي PowerPoint إلى مستند HTML5 يتم فيه عرض الشرائح في وضع عرض الشرائح. في هذه الحالة، عند فتح ملف HTML5 الناتج في متصفح، ستظهر العرض التقديمي في وضع عرض الشرائح على صفحة الويب. 

يعرض هذا الكود C++ عملية تصدير PowerPoint إلى عرض شرائح HTML5:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```


## **تحويل عرض تقديمي إلى مستند HTML5 مع التعليقات**

التعليقات في PowerPoint هي أداة تسمح للمستخدمين بترك ملاحظات أو ملاحظات على شرائح العرض التقديمي. وهي مفيدة بشكل خاص في المشاريع التعاونية، حيث يمكن لعدة أشخاص إضافة اقتراحاتهم أو ملاحظاتهم إلى عناصر شريحة معينة دون تعديل المحتوى الرئيسي. كل تعليق يظهر اسم المؤلف، مما يسهل تتبع من ترك الملاحظة.

لنفترض أن لدينا عرض PowerPoint التالي المحفوظ في الملف "sample.pptx".

![Two comments on the presentation slide](two_comments_pptx.png)

عند تحويل عرض PowerPoint إلى مستند HTML5، يمكنك بسهولة تحديد ما إذا كنت تريد تضمين التعليقات من العرض في المستند الناتج. للقيام بذلك، تحتاج إلى تحديد معلمات عرض التعليقات في طريقة `get_NotesCommentsLayouting` من فصل [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) .

المثال التالي من الشيفرة يحول عرضًا تقديميًا إلى مستند HTML5 مع عرض التعليقات إلى يمين الشرائح.
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```


المستند "output.html" معروض في الصورة أدناه.

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

**هل يمكنني التحكم فيما إذا كانت رسوم تحريك الكائنات وانتقالات الشرائح ستعمل في HTML5؟**

نعم، يوفر HTML5 خيارات منفصلة لتمكين أو تعطيل [رسوم تحريك الأشكال](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) و[انتقالات الشرائح](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/).

**هل يتم دعم إخراج التعليقات، وأين يمكن وضعها نسبةً إلى الشريحة؟**

نعم، يمكن إضافة التعليقات في HTML5 وتحديد موقعها (مثلاً إلى يمين الشريحة) من خلال إعدادات تخطيط الملاحظات والتعليقات.

**هل يمكنني تخطي الروابط التي تستدعي جافا سكريبت لأسباب أمنية أو سياسات CSP؟**

نعم، هناك [إعداد](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) يسمح لك بتخطي الروابط التي تستدعي جافا سكريبت أثناء الحفظ. يساعد ذلك في الامتثال لسياست الأمن الصارمة.