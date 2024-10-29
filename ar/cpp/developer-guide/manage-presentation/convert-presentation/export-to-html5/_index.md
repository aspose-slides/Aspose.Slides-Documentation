---
title: تصدير إلى HTML5
type: docs
weight: 40
url: /ar/cpp/export-to-html5/
keywords:
- PowerPoint إلى HTML
- شرائح إلى HTML
- HTML5
- تصدير HTML
- تصدير العرض التقديمي
- تحويل العرض التقديمي
- تحويل الشرائح
- C++
- Aspose.Slides لـ C++
description: "تصدير PowerPoint إلى HTML5 في C++" 
---

{{% alert title="معلومات" color="info" %}}

في [Aspose.Slides 21.9](/slides/ar/cpp/aspose-slides-for-cpp-21-9-release-notes/)، قمنا بتنفيذ الدعم لتصدير HTML5.

{{% /alert %}} 

تتيح لك عملية التصدير إلى HTML5 هنا تحويل PowerPoint إلى HTML. بهذه الطريقة، باستخدام القوالب الخاصة بك، يمكنك تطبيق خيارات مرنة للغاية تحدد عملية التصدير وHTML وCSS وJavaScript وخصائص الرسوم المتحركة الناتجة.

## **تصدير PowerPoint إلى HTML5**

يوضح هذا الرمز بلغة C++ كيفية تصدير عرض تقديمي إلى HTML5.

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="primary" %}} 

في هذه الحالة، ستحصل على HTML نظيف.

{{% /alert %}}

قد ترغب في تحديد إعدادات لتحريكات الأشكال وانتقالات الشرائح بهذه الطريقة:

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

يظهر هذا الرمز بلغة C++ عملية تصدير PowerPoint إلى HTML القياسية:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```

في هذه الحالة، يتم عرض محتوى العرض التقديمي من خلال SVG على شكل:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> محتوى الشريحة هنا </g>
     </svg>
</div>
</body>
```

{{% alert title="ملاحظة" color="warning" %}} 

عند استخدام هذه الطريقة لتصدير PowerPoint إلى HTML، بسبب عرض SVG، لن تكون قادرًا على تطبيق أنماط أو تحريك عناصر معينة.

{{% /alert %}}

## **تصدير PowerPoint إلى عرض HTML5 الشريحة**

**Aspose.Slides** يمكنك من تحويل عرض تقديمي PowerPoint إلى مستند HTML5 حيث يتم عرض الشرائح في وضع عرض الشرائح. في هذه الحالة، عندما تفتح ملف HTML5 الناتج في متصفح، ستشاهد العرض التقديمي في وضع عرض الشرائح على صفحة الويب.

يوضح هذا الرمز بلغة C++ عملية تصدير PowerPoint إلى عرض HTML5 الشريحة:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## تحويل عرض تقديمي إلى مستند HTML5 مع التعليقات

التعليقات في PowerPoint هي أداة تسمح للمستخدمين بترك ملاحظات أو تعليقات على الشرائح. إنها مفيدة بشكل خاص في المشاريع التعاونية، حيث يمكن لعدة أشخاص إضافة اقتراحاتهم أو ملاحظاتهم على عناصر الشريحة المحددة دون تغيير المحتوى الرئيسي. تظهر كل تعليق اسم المؤلف، مما يسهل تتبع من ترك الملاحظة.

لنفرض أن لدينا العرض التقديمي التالي محفوظًا في ملف "sample.pptx".

![تعليقان على شريحة العرض](two_comments_pptx.png)

عند تحويل عرض تقديمي PowerPoint إلى مستند HTML5، يمكنك بسهولة تحديد ما إذا كنت ترغب في تضمين التعليقات من العرض التقديمي في المستند الناتج. للقيام بذلك، تحتاج إلى تحديد معلمات العرض للتعليقات في طريقة `get_NotesCommentsLayouting` من فئة [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) .

يوضح المثال التالي كيفية تحويل عرض تقديمي إلى مستند HTML5 مع عرض التعليقات إلى يمين الشرائح.
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

يظهر مستند "output.html" في الصورة أدناه.

![التعليقات في مستند HTML5 الناتج](two_comments_html5.png)