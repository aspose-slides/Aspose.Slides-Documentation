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
description: "تصدير عروض PowerPoint و OpenDocument إلى HTML5 متجاوب باستخدام Aspose.Slides للغة C++. الحفاظ على التنسيق والرسوم المتحركة والتفاعل."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل عروض PowerPoint إلى HTML5 باستخدام Aspose.Slides للغة C++. تغطي العملية التصدير الأساسي والتحكم في رسومات التحريك والانتقالات بين الشرائح، وتنسيق التعليقات. كما تقارن ناتج HTML5 مع ناتج SVG المستند إلى تصدير HTML القياسي.

## **تصدير PowerPoint إلى HTML5**

يحمّل المثال التالي عرضاً تقديميًا من الدليل العامل ويحفظه بتنسيق HTML5. يستخدم الإعدادات الافتراضية للتصدير؛ يوضح المثال التالي كيفية التحكم في تشغيل الرسوم المتحركة بشكل صريح. استبدل مسار الإدخال بالمسار إلى عرضك التقديمي.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html5);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
بالإضافة إلى مستند HTML، يكتب التصدير ملفات CSS وJavaScript داعمة لتنسيق الشرائح، الرسوم المتحركة، المؤثرات، والتنقل. احفظ هذه الملفات مع مستند HTML عند نقل أو نشر النتيجة. كما يقوم الصفحة المُولّدة بتحميل jQuery وAnime.js من CDNs عامة؛ دونهما لا تعمل تنقلات الشرائح والرسوم المتحركة.
{{% /alert %}}

لتصدير دون تشغيل رسومات التحريك أو الانتقالات، مرّر `false` إلى [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) و[set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) في [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/). هذه الإعدادات مستقلة، لذا يمكنك تمكين أحدهما مع تعطيل الآخر. المثال يُصدّر العرض مع تعطيل كلا النوعين من الرسوم المتحركة في الصفحة المُولّدة.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(false);
html5Options->set_AnimateTransitions(false);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **تصدير PowerPoint إلى HTML**

يستخدم تصدير HTML القياسي نهج رسم مختلف: محتوى الشريحة يُمثَّل بـ SVG داخل صفحة HTML. يوضح المثال التالي تحويل عرض تقديمي إلى مستند HTML باستخدام هذا النهج.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html);
presentation->Dispose();
```

الترميز المبسط أدناه يوضح بنية الصفحة المُولّدة. عنصر SVG يحتوي على محتوى الشريحة المرسوم؛ النص النائب يمثل هذا المحتوى وليس ناتج التصدير الحرفي.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
تصدير SVG لا يكشف عن أشكال PowerPoint كعناصر HTML منفصلة. استخدم تصدير HTML5 عندما تحتاج إلى خيارات الرسوم المتحركة لل shapes وانتقالات الشرائح الموضحة في هذه المقالة.
{{% /alert %}}

## **تصدير PowerPoint إلى عرض شرائح HTML5**

يُنتج تصدير HTML5 صفحة لعرض وتنقل شرائح العرض في المتصفح. يمرّر هذا المثال `true` إلى كل من [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) و[set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) بحيث يمكن لعرض الشرائح المُصدَّر تشغيل المؤثرات من العرض الأصلي.

استخدم عرضًا تقديميًا يحتوي مسبقًا على رسومات تحريك وأنتقالات لتلاحظ تأثير هذه الإعدادات. تمكينها لا يضيف مؤثرات جديدة إلى الشرائح التي لا تحتوي على أي منها. بعد التصدير، افتح مستند HTML5 المُولَّد في متصفح مع ملفات الدعم متاحة.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **تحويل عرض تقديمي إلى مستند HTML5 مع التعليقات**

يمكنك تضمين التعليقات الموجودة على الشرائح في ناتج HTML5 بحيث يرى القارئ الملاحظات بجانب محتوى الشريحة. يتوقع المثال في هذا القسم أن يحتوي العرض الأصلي على تعليقات، كما هو موضح أدناه. يصدر تلك التعليقات؛ ولا ينشئ تعليقات جديدة.

![تعليقان على شريحة العرض التقديمي](two_comments_pptx.png)

مرّر كائن [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) إلى طريقة [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) في [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/). استدعِ [set_CommentsPosition](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/set_commentsposition/) مع `CommentsPositions::Right` من تعداد [CommentsPositions](https://reference.aspose.com/slides/cpp/aspose.slides.export/commentspositions/) لتضع التعليقات إلى يمين كل شريحة.

المثال التالي يصدر العرض إلى HTML5 مع تنسيق التعليقات هذا. العرض الذي لا يحتوي على تعليقات لن يظهر أي نص تعليق.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/CommentsPositions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutOptions);

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

الصورة أدناه توضح مستند HTML5 المُصدَّر مع عرض التعليقات بجانب الشريحة.

![التعليقات في مستند HTML5 الناتج](two_comments_html5.png)

## **استبعاد روابط JavaScript أثناء التصدير**

افترض أن الملف `hyperlinks.pptx` يحتوي نصًا مرتبطًا بوجهة `javascript:alert('Hello')` ورابطًا عاديًا `https://example.com/`. لاستبعاد رابط JavaScript أثناء التصدير، استدعِ [SaveOptions::set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) مع `true`. القيمة الافتراضية هي `false`، لذا لا تُفلتر هذه الروابط إلا إذا فعّلت الخيار.

المثال التالي يحمّل العرض من الدليل العامل ويصدّره باستخدام [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/):

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SkipJavaScriptLinks(true);

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");
presentation->Save(u"filtered-html5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

الملف المُصدَّر يحذف رابط JavaScript مع الإبقاء على نصه والرابط HTTPS العادي. يبقى العرض الأصلي دون تغيير.

هذا الخيار يفلتر روابط JavaScript؛ لا يزيل جميع النصوص البرمجية أو المحتوى النشط الآخر، ولا يضمن التوافق مع CSP. على سبيل المثال، لا يزال ناتج HTML5 يتضمن نصوصًا من أجل تنقل الشرائح والرسوم المتحركة.

## **الأسئلة الشائعة**

**هل يمكنني التحكم فيما إذا كانت رسومات التحريك والانتقالات ستُشغل في HTML5؟**

نعم، يوفّر تصدير HTML5 خيارات منفصلة لتمكين أو تعطيل [shape animations](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) و[slide transitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/).

**هل التعليقات مدعومة، وأين يمكن وضعها بالنسبة إلى الشريحة؟**

نعم، يمكن تضمين التعليقات الموجودة في ناتج HTML5 وتحديد موقعها (على سبيل المثال إلى يمين الشريحة) عبر [layout settings](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) للملاحظات والتعليقات.

**هل يمكنني تخطي الروابط التي تستدعي JavaScript لأسباب أمنية أو تتعلق بـ CSP؟**

نعم، تسمح طريقة [set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) بتخطي الروابط التي تحتوي على استدعاءات JavaScript أثناء الحفظ. القيمة الافتراضية هي `false`. راجع [استبعاد روابط JavaScript أثناء التصدير](/slides/ar/cpp/export-to-html5/#exclude-javascript-hyperlinks-during-export) للحصول على مثال لتصدير HTML5 ونطاق الفلتر. هذا الإعداد لا يزيل JavaScript المستخدم من قبل عارض HTML5 للتنقل والرسوم المتحركة.