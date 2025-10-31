---
title: تعدد الخيوط في Aspose.Slides للغة Python
linktitle: تعدد الخيوط
type: docs
weight: 200
url: /ar/python-net/multithreading/
keywords:
- تعدد الخيوط
- خيوط متعددة
- عمل متوازي
- تحويل الشرائح
- الشرائح إلى صور
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "يُعزز Aspose.Slides للغة Python عبر تعدد الخيوط في .NET معالجة PowerPoint و OpenDocument. اكتشف أفضل الممارسات لتدفقات عمل العروض التقديمية الفعّالة."
---

## **المقدمة**

على الرغم من أن العمل المتوازي مع العروض التقديمية ممكن (باستثناء التحليل/التحميل/الاستنساخ) وتعمل الأمور بشكل جيد في معظم الأحيان، إلا أن هناك احتمالًا صغيرًا للحصول على نتائج غير صحيحة عند استخدام المكتبة في خيوط متعددة.

نوصي بشدة ألا تستخدم مثيلًا واحدًا من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) في بيئة تعدد الخيوط لأن ذلك قد يؤدي إلى أخطاء أو فشل غير متوقع يصعب اكتشافه.

ليس من الآمن تحميل أو حفظ أو/أو استنساخ مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) في خيوط متعددة. هذه العمليات غير مدعومة. إذا كنت بحاجة إلى أداء مثل هذه المهام، يجب عليك تنفيذ العمليات بصورة متوازية باستخدام عدة عمليات أحادية الخيط—ويجب على كل عملية من هذه العمليات استخدام مثيل عرض تقديمي خاص بها.

## **تحويل شرائح العرض التقديمي إلى صور بشكل متوازي**

لنفترض أننا نريد تحويل جميع الشرائح من عرض تقديمي PowerPoint إلى صور PNG بصورة متوازية. نظرًا لعدم أمان استخدام مثيل `Presentation` واحد في خيوط متعددة، نقوم بتقسيم شرائح العرض إلى عروض تقديمية منفصلة ونحوّل الشرائح إلى صور بشكل متوازٍ، باستخدام كل عرض تقديمي في خيط منفصل. المثال البرمجي التالي يوضح كيفية القيام بذلك.

```py
input_file_path = "sample.pptx"
output_file_path_template = "slide_{0}.png"
image_scale = 2

presentation = Presentation(input_file_path)

slide_count = len(presentation.slides)
slide_size = presentation.slide_size.size

conversion_tasks = []


def convert_slide(slide_index):
    # استخراج الشريحة i في عرض تقديمي منفصل.
    with Presentation() as slide_presentation:
        slide_presentation.slide_size.set_size(slide_size.width, slide_size.height, SlideSizeScaleType.DO_NOT_SCALE)
        slide_presentation.slides.remove_at(0)
        slide_presentation.slides.add_clone(presentation.slides[slide_index])

        slide_number = slide_index + 1
        slide = slide_presentation.slides[0]

        # تحويل الشريحة إلى صورة.
        with slide.get_image(image_scale, image_scale) as image:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.PNG)


with ThreadPoolExecutor() as thread_executor:
    for index in range(slide_count):
        conversion_tasks.append(thread_executor.submit(convert_slide, index))

# انتظر إكمال جميع المهام.
for task in conversion_tasks:
    task.result()

del presentation
```

## **الأسئلة المتكررة**

**هل يجب عليّ استدعاء إعداد الترخيص في كل خيط؟**

لا. يكفي القيام بذلك مرة واحدة لكل عملية/نطاق تطبيق قبل بدء الخيوط. إذا كان من الممكن استدعاء [إعداد الترخيص](/slides/ar/python-net/licensing/) بشكل متزامن (على سبيل المثال، أثناء التهيئة الكسولة)، فقم بمزامنة هذا الاستدعاء لأن طريقة إعداد الترخيص نفسها غير آمنة للخلية.

**هل يمكنني تمرير كائنات `Presentation` أو `Slide` بين الخيوط؟**

تمرير كائنات العرض "الحية" بين الخيوط غير موصى به: استخدم مثيلات مستقلة لكل خيط أو أنشئ مسبقًا عروضًا تقديمية/حاويات شرائح منفصلة لكل خيط. هذا النهج يتماشى مع التوصية العامة بعدم مشاركة مثيل عرض تقديمي واحد عبر الخيوط.

**هل من الآمن تشغيل تصدير متوازي إلى صيغ مختلفة (PDF، HTML، صور) بشرط أن يكون لكل خيط مثيل `Presentation` خاص به؟**

نعم. مع مثيلات مستقلة ومسارات إخراج منفصلة، عادةً ما تُنفّذ هذه المهام بشكل متوازي بشكل صحيح؛ تجنّب أي مشاركة لكائنات العرض أو تدفقات I/O المشتركة.

**ماذا عليّ أن أفعل بإعدادات الخطوط العامة (المجلدات، الاستبدالات) في بيئة تعدد الخيوط؟**

قُم بتهيئة جميع إعدادات الخطوط العامة قبل بدء الخيوط ولا تغيرها أثناء العمل المتوازي. هذا يزيل حالات السباق عند الوصول إلى موارد الخطوط المشتركة.