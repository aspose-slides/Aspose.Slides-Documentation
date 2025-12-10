---
title: تحويل العروض التقديمية إلى HTML5 في C++
linktitle: العرض التقديمي إلى HTML5
type: docs
weight: 40
url: /ar/cpp/export-to-html5/
keywords:
- PowerPoint إلى HTML5
- OpenDocument إلى HTML5
- العرض التقديمي إلى HTML5
- الشريحة إلى HTML5
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
description: "تصدير عروض PowerPoint و OpenDocument إلى HTML5 مستجيب باستخدام Aspose.Slides للـ C++. الحفاظ على التنسيق، والرسوم المتحركة، والتفاعلية."
---

{{% alert title="Info" color="info" %}}

في [Aspose.Slides 21.9](/slides/ar/cpp/aspose-slides-for-cpp-21-9-release-notes/)، قمنا بتنفيذ دعم تصدير HTML5.

{{% /alert %}} 

تسمح لك عملية التصدير إلى HTML5 هنا بتحويل PowerPoint إلى HTML. بهذه الطريقة، باستخدام القوالب الخاصة بك، يمكنك تطبيق خيارات مرنة جداً تحدد عملية التصدير وملف HTML وCSS وJavaScript وخصائص الرسوم المتحركة الناتجة. 

## **Export PowerPoint to HTML5**

هذا المثال بلغة C++ يوضح طريقة تصدير عرض تقديمي إلى HTML5.
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```


{{% alert color="primary" %}} 

في هذه الحالة ستحصل على HTML نظيف. 

{{% /alert %}}

يمكنك تحديد إعدادات للرسوم المتحركة للأشكال وانتقالات الشرائح بهذه الطريقة:
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```


## **Export PowerPoint to HTML**

هذا المثال بلغة C++ يوضح عملية التحويل القياسية من PowerPoint إلى HTML:
```cpp
using namespace Aspise::Slides;
using namespace Aspise::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```


في هذه الحالة يتم عرض محتوى العرض التقديمي عبر SVG على الشكل التالي:
```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```


{{% alert title="Note" color="warning" %}} 

عند استخدام هذه الطريقة لتصدير PowerPoint إلى HTML، بسبب عرض SVG، لن تكون قادرًا على تطبيق الأنماط أو تحريك عناصر معينة. 

{{% /alert %}}

## **Export PowerPoint to HTML5 Slide View**

**Aspose.Slides** يتيح لك تحويل عرض تقديمي PowerPoint إلى مستند HTML5 تُعرض فيه الشرائح في وضع عرض الشرائح. في هذه الحالة، عند فتح ملف HTML5 الناتج في المتصفح، ستظهر العرض التقديمي في وضع عرض الشرائح على صفحة الويب. 

هذا المثال بلغة C++ يوضح عملية تصدير PowerPoint إلى وضع عرض الشرائح HTML5:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```


## **Convert a Presentation to an HTML5 Document with Comments**

التعليقات في PowerPoint أداة تسمح للمستخدمين بترك ملاحظات أو ملاحظات على شرائح العرض. وهي مفيدة بشكل خاص في المشاريع التعاونية، حيث يمكن لعدة أشخاص إضافة اقتراحاتهم أو ملاحظاتهم إلى عناصر معينة في الشريحة دون تعديل المحتوى الرئيسي. كل تعليق يُظهر اسم المؤلف، مما يسهل تتبع من ترك الملاحظة.

لنفترض أن لدينا عرض تقديمي PowerPoint محفوظ في الملف **"sample.pptx"**.

![Two comments on the presentation slide](two_comments_pptx.png)

عند تحويل عرض تقديمي PowerPoint إلى مستند HTML5، يمكنك بسهولة تحديد ما إذا كنت تريد تضمين التعليقات التي في العرض في المستند الناتج. للقيام بذلك، يجب تحديد معلمات عرض التعليقات في طريقة `get_NotesCommentsLayouting` من فئة [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/). 

يوضح المثال التالي كيفية تحويل عرض تقديمي إلى مستند HTML5 مع عرض التعليقات إلى يمين الشرائح.
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```


المستند **"output.html"** موضح في الصورة أدناه.

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

**هل يمكنني التحكم في تشغيل رسومات الكائنات وانتقالات الشرائح في HTML5؟**

نعم، يوفر HTML5 خيارات منفصلة لتمكين أو تعطيل [shape animations](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) و[slide transitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/).

**هل يدعم إخراج التعليقات، وأين يمكن وضعها بالنسبة للشرائح؟**

نعم، يمكن إضافة التعليقات في HTML5 وتحديد موقعها (مثلاً إلى يمين الشريحة) من خلال إعدادات التخطيط للملاحظات والتعليقات.

**هل يمكنني تخطي الروابط التي تستدعي JavaScript لأسباب أمنية أو سياسات CSP؟**

نعم، هناك [setting](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) يسمح لك بتخطي الروابط التي تستدعي JavaScript أثناء الحفظ. يساعد ذلك في الامتثال لسياسات الأمان الصارمة.