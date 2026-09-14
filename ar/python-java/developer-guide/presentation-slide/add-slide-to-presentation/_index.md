---
title: إضافة شرائح إلى العروض التقديمية في بايثون
linktitle: إضافة شريحة
type: docs
weight: 10
url: /ar/python-java/add-slide-to-presentation/
keywords:
- إضافة شريحة
- إنشاء شريحة
- شريحة فارغة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "أضف الشرائح بسهولة إلى عروض PowerPoint وOpenDocument الخاصة بك باستخدام Aspose.Slides لـ Python عبر Java—إدراج شرائح سلس وفعال في ثوانٍ."
---
## **نظرة عامة**

تتيح لك Aspose.Slides إضافة شرائح إلى عروض PowerPoint تقديميًا. يحتوي العرض التقديمي على شرائح ماستر/تخطيط وشرائح عادية، وتُرتب الشرائح العادية حسب فهرس يبدأ من الصفر. لكل شريحة معرف فريد، ولا يتم دعم ملفات العروض التي لا تحتوي على شرائح.

توضح هذه المقالة كيفية إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) ، والوصول إلى مجموعة الشرائح الخاصة به، وإضافة شريحة فارغة، والعمل مع الشريحة التي تم إضافتها حديثًا، وحفظ العرض المحدث. كما تغطي نقاطًا ذات صلة مثل إدراج الشرائح في موضع معين، واستخدام القوالب، وفهم الشريحة الفارغة الموجودة في عرض تم إنشاؤه حديثًا.

## **إضافة شريحة إلى عرض تقديمي**

قبل مناقشة كيفية إضافة شرائح إلى ملفات العرض التقديمي، دعونا نستعرض بعض الحقائق حول الشرائح. يحتوي كل ملف عرض PowerPoint على شرائح **ماستر/تخطيط** وشرائح **عادية**. يحتوي ملف العرض التقديمي على شريحة واحدة على الأقل. ملفات العروض التي لا تحتوي على شرائح غير مدعومة من قبل Aspose.Slides for Python عبر Java. لكل شريحة معرف فريد، وتُرتب جميع الشرائح العادية وفقًا لترتيب يُحدد بفهرس يبدأ من الصفر.

Aspose.Slides for Python عبر Java يتيح للمطورين إضافة شرائح فارغة إلى عروضهم. لإضافة شريحة فارغة إلى عرض تقديمي، اتبع الخطوات التالية:

- إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
- الحصول على مرجع لكائن [SlideCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/) باستخدام الطريقة [getSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getSlides) التي يوفرها كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
- إضافة شريحة فارغة إلى نهاية مجموعة الشرائح في العرض التقديمي عن طريق استدعاء الطريقة [addEmptySlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#addEmptySlide) التي يوفرها كائن [SlideCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/).
- قم ببعض الأعمال مع الشريحة الفارغة التي تم إضافتها حديثًا.
- أخيرًا، احفظ ملف العرض باستخدام كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# إنشاء كائن من فئة Presentation التي تمثل ملف العرض التقديمي.
presentation = Presentation()
try:
    # الحصول على مجموعة الشرائح.
    slides = presentation.getSlides()

    for i in range(presentation.getLayoutSlides().size()):
        # إضافة شريحة فارغة إلى مجموعة الشرائح.
        slides.addEmptySlide(presentation.getLayoutSlides().get_Item(i))

    # قم ببعض الأعمال على الشريحة التي تم إضافتها حديثًا.

    # حفظ ملف PPTX إلى القرص.
    presentation.save("EmptySlide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**هل يمكنني إدراج شريحة جديدة في موضع محدد، وليس فقط في النهاية؟**

نعم. المكتبة تدعم مجموعات الشرائح وعمليات [insert](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#insertEmptySlide)/[clone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidecollection/#insertClone)، لذا يمكنك إضافة شريحة عند الفهرس المطلوب بدلاً من إضافتها فقط في النهاية.

**هل يتم الحفاظ على السمات/الأنماط عند إضافة شريحة بناءً على قالب؟**

نعم. القالب يرث التنسيق من الماستر الخاص به، والشريحة الجديدة ترث من القالب المختار والماستر المرتبط به.

**أي شريحة تكون موجودة في عرض "فارغ" جديد قبل إضافة الشرائح؟**

العرض الذي تم إنشاؤه حديثًا يحتوي بالفعل على شريحة فارغة واحدة ذات فهرس صفر. من المهم أخذ ذلك في الاعتبار عند حساب مؤشرات الإدراج.

**كيف أختار القالب "الملائم" لشريحة جديدة إذا كان للماستر العديد من الخيارات؟**

عمومًا، اختر كائن [LayoutSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutslide/) الذي يتطابق مع الهيكل المطلوب ([Title and Content, Two Content, إلخ](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidelayouttype/)). إذا كان هذا القالب غير موجود، يمكنك [add it to the master](/slides/ar/python-java/slide-layout/) ثم استخدامه.