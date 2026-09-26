---
title: إنشاء عروض تقديمية في .NET
linktitle: إنشاء عرض تقديمي
type: docs
weight: 10
url: /ar/net/create-presentation/
keywords:
- إنشاء عرض تقديمي
- عرض تقديمي جديد
- إنشاء PPT
- PPT جديد
- إنشاء PPTX
- PPTX جديد
- إنشاء ODP
- ODP جديد
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إنشاء عروض تقديمية في .NET باستخدام Aspose.Slides—إنتاج ملفات PPT و PPTX و ODP، الاستفادة من دعم OpenDocument، وحفظها برمجياً للحصول على نتائج موثوقة."
---
## **نظرة عامة**

هذه المقالة توضح كيفية إنشاء عرض تقديمي في Aspose.Slides، إضافة صندوق نص إلى الشريحة الأولى، وحفظ النتيجة كملف. كما توضح كيفية إنشاء عرض تقديمي فارغ وحفظه، وكيفية فتح عرض تقديمي موجود بتنسيق مدعوم وحفظه بتنسيق آخر. يتضمن قسم الأسئلة الشائعة في النهاية إجابات على أسئلة شائعة حول الصيغ، القوالب، حجم الشرائح، الوحدات، استهلاك الذاكرة، التعددية، الترخيص، التوقيعات الرقمية، ودعم VBA.

قبل البدء، أضف Aspose.Slides إلى مشروعك من NuGet. راجع [Installation](/slides/ar/net/installation/) للحصول على الحزمة للاستخدام على Windows وLinux وmacOS.

## **إنشاء عرض PowerPoint**

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) . يحتوي العرض الجديد بالفعل على شريحة فارغة واحدة.
2. احصل على تلك الشريحة من مجموعة [Slides](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/slides/ar/) بواسم الفهرس 0.
3. أضف مستطيلًا باستخدام الطريقة [AddAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/addautoshape/) ثم اضبط [text](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/text/).
4. احفظ العرض كملف PPTX باستخدام الطريقة [Save](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/save/) .

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

زاوية المستطيل العلوية اليسرى تقع على بُعد 50 نقطة من الحافة اليسرى و50 نقطة من الحافة العليا للشريحة، وعرض المستطيل 400 نقطة وارتفاعه 100 نقطة. يحتوي الملف المحفوظ على شريحة واحدة تضم ذلك المستطيل ونصه. بدون ترخيص، يضيف Aspose.Slides علامة مائية للتقييم إلى كل شريحة يتم حفظها؛ راجع [Licensing](/slides/ar/net/licensing/).

## **إنشاء وحفظ عرض تقديمي**

<a name="csharp-create-save-presentation"></a>

لإنشاء عرض تقديمي فارغ وحفظه، أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) واحفظه بأي تنسيق من تعداد [SaveFormat](https://reference.aspose.com/slides/ar/net/aspose.slides.export/saveformat/) . النتيجة هي عرض تقديمي يحتوي على شريحة فارغة واحدة.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **فتح وحفظ عرض تقديمي**

<a name="csharp-open-save-presentation"></a>

لتحويل عرض تقديمي من تنسيق إلى آخر، افتحه بتمرير مساره إلى مُنشئ [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/presentation/) ، ثم احفظه بالتنسيق الهدف. يكتشف Aspose.Slides تنسيق الإدخال، مثل PPT أو PPTX أو ODP، من الملف نفسه.

المثال أدناه يتوقع وجود عرض OpenDocument باسم *Sample.odp* في دليل العمل ويحفظه كـ PPTX.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.odp");
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **الأسئلة الشائعة**

### ما الصيغ التي يمكنني حفظ عرض تقديمي جديد إليها؟

يمكنك الحفظ إلى [PPTX, PPT, and ODP](/slides/ar/net/save-presentation/)، وتصدير إلى [PDF](/slides/ar/net/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/net/convert-powerpoint-to-xps/), [HTML](/slides/ar/net/convert-powerpoint-to-html/), [SVG](/slides/ar/net/render-a-slide-as-an-svg-image/), و[images](/slides/ar/net/convert-powerpoint-to-png/)، وغيرها.

### هل يمكنني البدء من قالب (POTX/POTM) وحفظه كـ PPTX عادي؟

نعم. حمّل القالب واحفظه بالتنسيق المطلوب؛ صيغ POTX/POTM/PPTM والصيغ المشابهة [مدعومة](/slides/ar/net/supported-file-formats/).

### كيف يمكنني التحكم في حجم الشريحة/نسبة العرض إلى الارتفاع عند إنشاء عرض تقديمي؟

حدد [slide size](/slides/ar/net/slide-size/) (بما في ذلك القوالب مثل 4:3 و16:9 أو الأبعاد المخصصة) واختر طريقة تحجيم المحتوى.

### بأي وحدات تُقاس الأحجام والإحداثيات؟

بالنقاط: 1 بوصة تساوي 72 وحدة.

### كيف أتعامل مع عروض تقديمية كبيرة جدًا (مع العديد من ملفات الوسائط) لتقليل استهلاك الذاكرة؟

استخدم [BLOB management strategies](/slides/ar/net/manage-blob/)، قِم بتقليل التخزين في الذاكرة عن طريق الاستفادة من الملفات المؤقتة، وفضّل سير عمل يعتمد على الملفات بدلاً من التدفقات داخل الذاكرة فقط.

### هل يمكنني إنشاء/حفظ عروض تقديمية بالتوازي؟

لا يمكنك العمل على نفس كائن [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) من [multiple threads](/slides/ar/net/multithreading/). شغّل مثيلات منفصلة ومعزولة لكل خيط أو عملية.

### كيف أقوم بإزالة علامة التجربة المائية والقيود؟

[Apply a license](/slides/ar/net/licensing/) مرة واحدة لكل عملية. يجب أن يبقى ملف ترخيص XML دون تعديل، ويجب مزامنة إعداد الترخيص إذا كانت هناك خيوط متعددة.

### هل يمكنني توقيع PPTX الذي أنشئه رقميًا؟

نعم. [Digital signatures](/slides/ar/net/digital-signature-in-powerpoint/) (الإضافة والتحقق) مدعومة للعرض التقديمي.

### هل تدعم العروض التي تم إنشاؤها الماكرو (VBA)؟

نعم. يمكنك [create/edit VBA projects](/slides/ar/net/presentation-via-vba/) وحفظ ملفات تمكين الماكرو مثل PPTM/PPSM.