---
title: انتقال الشريحة
type: docs
weight: 90
url: /ar/python-net/slide-transition/
keywords: "إضافة انتقال الشريحة، انتقال شريحة PowerPoint، انتقال التحول، انتقال الشريحة المتقدم، تأثيرات الانتقال، بايثون، Aspose.Slides"
description: " إضافة انتقال شريحة PowerPoint وتأثيرات الانتقال في بايثون "
---

## **إضافة انتقال الشريحة**
لتسهيل الفهم، قمنا بتوضيح استخدام Aspose.Slides لبايثون عبر .NET لإدارة انتقالات الشرائح البسيطة. يمكن للمطورين ليس فقط تطبيق تأثيرات انتقال شريحة مختلفة على الشرائح ولكن أيضًا تخصيص سلوك هذه التأثيرات. لإنشاء تأثير انتقال شريحة بسيط، اتبع الخطوات أدناه:

1. أنشئ مثيلاً لـ [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. طبق نوع انتقال الشريحة على الشريحة من أحد تأثيرات الانتقال التي تتوفر عبر Aspose.Slides لبايثون عبر .NET من خلال TransitionType enum.
1. اكتب ملف العرض المعدل.

```py
import aspose.slides as slides

# قم بإنشاء مثيل لفئة Presentation لتحميل ملف العرض المصدر
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # طبق انتقال من نوع دائرة على الشريحة 1
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # طبق انتقال من نوع مشط على الشريحة 2
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # اكتب العرض إلى القرص
    presentation.save("SampleTransition_out.pptx", slides.export.SaveFormat.PPTX)
```


## **إضافة انتقال الشريحة المتقدم**
في القسم أعلاه، قمنا فقط بتطبيق تأثير انتقال بسيط على الشريحة. الآن، لجعل ذلك التأثير البسيط أفضل وأكثر تحكمًا، يرجى اتباع الخطوات أدناه:

1. أنشئ مثيلاً لـ [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. طبق نوع انتقال الشريحة على الشريحة من أحد تأثيرات الانتقال التي تتوفر عبر Aspose.Slides لبايثون عبر .NET.
1. يمكنك أيضًا تعيين الانتقال ليتم متقدمًا عند النقر، بعد فترة زمنية محددة أو كلاهما.
1. إذا تم تمكين الانتقال ليتقدم عند النقر، فإن الانتقال سيتقدم فقط عندما ينقر شخص ما على الفأرة. علاوة على ذلك، إذا تم تعيين خاصية التقدم بعد الوقت، سيتقدم الانتقال تلقائيًا بعد انتهاء الوقت المحدد.
1. اكتب العرض المعدل كملف عرض.

```py
import aspose.slides as slides

# قم بإنشاء مثيل لفئة Presentation التي تمثل ملف عرض
with slides.Presentation(path + "BetterSlideTransitions.pptx") as pres:
    # طبق انتقال من نوع دائرة على الشريحة 1
    pres.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # تعيين وقت الانتقال 3 ثوانٍ
    pres.slides[0].slide_show_transition.advance_on_click = True
    pres.slides[0].slide_show_transition.advance_after_time = 3000

    # طبق انتقال من نوع مشط على الشريحة 2
    pres.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # تعيين وقت الانتقال 5 ثوانٍ
    pres.slides[1].slide_show_transition.advance_on_click = True
    pres.slides[1].slide_show_transition.advance_after_time = 5000

    # طبق انتقال من نوع زوم على الشريحة 3
    pres.slides[2].slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # تعيين وقت الانتقال 7 ثوانٍ
    pres.slides[2].slide_show_transition.advance_on_click = True
    pres.slides[2].slide_show_transition.advance_after_time = 7000

    # اكتب العرض إلى القرص
    pres.save("SampleTransition_out.pptx", slides.export.SaveFormat.PPTX)
```


## **انتقال التحول**
Aspose.Slides لبايثون عبر .NET تدعم الآن [انتقال التحول](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/imorphtransition/). يمثلون انتقال تحول جديد تم تقديمه في PowerPoint 2019. يسمح انتقال التحول لك بتحريك سلس من شريحة إلى أخرى. تصف هذه المقالة مفهوم وكيفية استخدام انتقال التحول. لاستخدام انتقال التحول بشكل فعال، ستحتاج إلى وجود شريحتين تحتويان على كائن واحد على الأقل مشترك. أسهل طريقة هي تكرار الشريحة ثم نقل الكائن في الشريحة الثانية إلى مكان مختلف.

يوضح مقتطف الشيفرة التالية كيفية إضافة استنساخ للشريحة مع بعض النص إلى العرض وتعيين انتقال من [نوع التحول](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/imorphtransition/) إلى الشريحة الثانية.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    autoshape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    autoshape.text_frame.text = "انتقال التحول في عروض PowerPoint"

    presentation.slides.add_clone(presentation.slides[0])

    presentation.slides[1].shapes[0].x += 100
    presentation.slides[1].shapes[0].y += 50
    presentation.slides[1].shapes[0].width -= 200
    presentation.slides[1].shapes[0].height -= 10

    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```


## **أنواع انتقال التحول**
تم إضافة [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) enum. يمثل أنواع مختلفة من انتقال التحول للشرائح.

يتكون TransitionMorphType enum من ثلاثة أعضاء:

- حسب الكائن: سيتم تنفيذ انتقال التحول مع مراعاة الأشكال ككائنات غير قابلة للتجزئة.
- حسب الكلمة: سيتم تنفيذ انتقال التحول مع نقل النص حسب الكلمات عند الإمكان.
- حسب الحرف: سيتم تنفيذ انتقال التحول مع نقل النص حسب الأحرف عند الإمكان.

يوضح مقتطف الشيفرة التالي كيفية تعيين انتقال التحول إلى الشريحة وتغيير نوع التحول:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    presentation.slides[0].slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```


## **تعيين تأثيرات الانتقال**
Aspose.Slides لبايثون عبر .NET تدعم تعيين تأثيرات الانتقال مثل، من الأسود، من اليسار، من اليمين، وما إلى ذلك. من أجل تعيين تأثير الانتقال، يرجى اتباع الخطوات أدناه:

- أنشئ مثيلاً لـ [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)class.
- احصل على مرجع الشريحة.
- تعيين تأثير الانتقال.
- اكتب العرض كملف [PPTX ](https://docs.fileformat.com/presentation/pptx/)file.

في المثال المعطى أدناه، قمنا بتعيين تأثيرات الانتقال.

```py
import aspose.slides as slides

# قم بإنشاء مثيل لفئة Presentation
with slides.Presentation(path + "AccessSlides.pptx") as presentation:

    # تعيين التأثير
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CUT
    presentation.slides[0].slide_show_transition.value.from_black = True

    # اكتب العرض إلى القرص
    presentation.save("SetTransitionEffects_out.pptx", slides.export.SaveFormat.PPTX)
```