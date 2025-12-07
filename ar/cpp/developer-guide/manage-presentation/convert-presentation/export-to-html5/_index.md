---
title: "تحويل العروض التقديمية إلى HTML5 في C++"
linktitle: "العرض التقديمي إلى HTML5"
type: docs
weight: 40
url: /ar/cpp/export-to-html5/
keywords:
- "PowerPoint إلى HTML5"
- "OpenDocument إلى HTML5"
- "العرض التقديمي إلى HTML5"
- "الشريحة إلى HTML5"
- "PPT إلى HTML5"
- "PPTX إلى HTML5"
- "ODP إلى HTML5"
- "حفظ PPT كـ HTML5"
- "حفظ PPTX كـ HTML5"
- "حفظ ODP كـ HTML5"
- "تصدير PPT إلى HTML5"
- "تصدير PPTX إلى HTML5"
- "تصدير ODP إلى HTML5"
- "C++"
- "Aspose.Slides"
description: "تصدير عروض PowerPoint وOpenDocument إلى HTML5 سريع الاستجابة باستخدام Aspose.Slides لـ C++. الحفاظ على التنسيق والرسوم المتحركة والتفاعلية."
---

{{% alert title="معلومة" color="info" %}}

في [Aspose.Slides 21.9](/slides/ar/cpp/aspose-slides-for-cpp-21-9-release-notes/)، قمنا بتنفيذ دعم تصدير HTML5.

{{% /alert %}} 

تتيح لك عملية التصدير إلى HTML5 هنا تحويل PowerPoint إلى HTML. بهذه الطريقة، باستخدام القوالب الخاصة بك، يمكنك تطبيق خيارات مرنة جدًا تحدد عملية التصدير والنتيجة من HTML وCSS وJavaScript وسمات الرسوم المتحركة. 

## **تصدير PowerPoint إلى HTML5**

يعرض هذا الكود C++ كيفية تصدير عرض تقديمي إلى HTML5.
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```


{{% alert color="primary" %}} 

في هذه الحالة، ستحصل على HTML نظيف. 

{{% /alert %}}

قد ترغب في تحديد إعدادات لرسوم المتحرك للأشكال وانتقالات الشرائح بهذه الطريقة:
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

عند استخدام هذه الطريقة لتصدير PowerPoint إلى HTML، بسبب عرض SVG، لن تتمكن من تطبيق الأنماط أو تحريك العناصر المحددة. 

{{% /alert %}}

## **تصدير PowerPoint إلى عرض شرائح HTML5**

**Aspose.Slides** يتيح لك تحويل عرض PowerPoint إلى مستند HTML5 تُعرض فيه الشرائح في وضع عرض الشرائح. في هذه الحالة، عند فتح ملف HTML5 الناتج في المتصفح، سترى العرض التقديمي في وضع عرض الشرائح على صفحة الويب. 

يعرض هذا الكود C++ عملية تصدير PowerPoint إلى عرض شرائح HTML5:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```


## **تحويل عرض تقديمي إلى مستند HTML5 مع التعليقات**

التعليقات في PowerPoint هي أداة تسمح للمستخدمين بترك ملاحظات أو ملاحظات على شرائح العرض التقديمي. هي مفيدة خاصة في المشاريع التعاونية، حيث يمكن لعدة أشخاص إضافة اقتراحاتهم أو ملاحظاتهم إلى عناصر معينة في الشريحة دون تعديل المحتوى الرئيسي. كل تعليق يظهر اسم المؤلف، مما يسهل تتبع من ترك الملاحظة.

لنفترض أن لدينا عرض PowerPoint التالي محفوظًا في ملف "sample.pptx".

![تعليقان على شريحة العرض](two_comments_pptx.png)

عند تحويل عرض PowerPoint إلى مستند HTML5، يمكنك بسهولة تحديد ما إذا كنت تريد تضمين التعليقات من العرض في المستند الناتج. للقيام بذلك، تحتاج إلى تحديد معاملات عرض التعليقات في طريقة `get_NotesCommentsLayouting` من فئة [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/).

يوضح المثال التالي كودًا يحول عرض تقديمي إلى مستند HTML5 مع عرض التعليقات على يمين الشرائح.
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```


يُظهر المستند "output.html" في الصورة أدناه.

![التعليقات في مستند HTML5 الناتج](two_comments_html5.png)

## **الأسئلة الشائعة**

**هل يمكنني التحكم فيما إذا كانت رسوم المتحرك للكائنات وانتقالات الشرائح ستعمل في HTML5؟**

نعم، يوفر HTML5 خيارات منفصلة لتمكين أو تعطيل [shape animations](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) و[slide transitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/).

**هل يتم دعم إخراج التعليقات، وأين يمكن وضعها بالنسبة للشرائح؟**

نعم، يمكن إضافة التعليقات في HTML5 وتحديد موضعها (على سبيل المثال، إلى يمين الشريحة) عبر إعدادات التخطيط للملاحظات والتعليقات.

**هل يمكنني تخطي الروابط التي تستدعي JavaScript لأسباب أمان أو سياسات CSP؟**

نعم، هناك [setting](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) يسمح لك بتخطي الروابط التي تستدعي JavaScript أثناء الحفظ. يساعد ذلك في الامتثال للسياسات الأمنية الصارمة.