---
title: العمل المتوازي في Aspose.Slides للبايثون
linktitle: العمل المتوازي
type: docs
weight: 200
url: /ar/python-net/multithreading/
keywords:
- العمل المتوازي
- خيوط متعددة
- عمل متوازي
- تحويل الشرائح
- الشرائح إلى صور
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "يعزز Aspose.Slides للبايثون عبر .NET باستخدام العمل المتوازي معالجة PowerPoint و OpenDocument. اكتشف أفضل الممارسات لتدفقات عمل العرض التقديمي الفعالة."
---

## **مقدمة**

في حين أن العمل المتوازي مع العروض التقديمية ممكن (إلى جانب التحليل/التحميل/الاستنساخ) وكل شيء يسير على ما يرام (في معظم الأوقات)، هناك احتمال ضئيل أن تحصل على نتائج غير صحيحة عند استخدام المكتبة في عدة خيوط.

نوصي بشدة **عدم** استخدام نسخة واحدة من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) في بيئة متعددة الخيوط لأنه قد يؤدي إلى أخطاء أو فشل غير متوقع يصعب اكتشافه.

ليس **آمنًا** تحميل، حفظ، أو استنساخ نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) في عدة خيوط. مثل هذه العمليات **غير** مدعومة. إذا كنت بحاجة إلى تنفيذ هذه المهام، عليك تنفيذها بشكل متوازي باستخدام عدة عمليات أحادية الخيط—ويجب على كل عملية من هذه العمليات استخدام نسخة خاصة بها من العرض التقديمي.

## **تحويل شرائح Presentation إلى صور بشكل متوازي**

لنفترض أننا نريد تحويل جميع الشرائح من عرض PowerPoint إلى صور PNG بشكل متوازي. نظرًا لأن استخدام نسخة واحدة من `Presentation` في عدة خيوط غير آمن، نقسم شرائح العرض إلى عروض تقديمية منفصلة ونحول الشرائح إلى صور بشكل متوازي، باستخدام كل عرض في خيط منفصل. يوضح مثال الشيفرة التالي كيفية القيام بذلك.
```py
input_file_path = "sample.pptx"
output_file_path_template = "slide_{0}.png"
image_scale = 2

presentation = Presentation(input_file_path)

slide_count = len(presentation.slides)
slide_size = presentation.slide_size.size

conversion_tasks = []


def convert_slide(slide_index):
    # استخراج الشريحة i إلى عرض تقديمي منفصل.
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


## **الأسئلة الشائعة**

**هل أحتاج إلى استدعاء إعداد الترخيص في كل خيط؟**

لا. يكفي القيام بذلك مرة واحدة لكل عملية/مجال تطبيق قبل بدء الخيوط. إذا كان قد يتم استدعاء [إعداد الترخيص](/slides/ar/python-net/licensing/) بشكل متزامن (على سبيل المثال، أثناء التهيئة البطيئة)، قم بمزامنة هذا الاستدعاء لأن طريقة إعداد الترخيص نفسها غير آمنة في الخيوط.

**هل يمكنني تمرير كائنات `Presentation` أو `Slide` بين الخيوط؟**

تمرير كائنات العرض "الحية" بين الخيوط غير موصى به: استخدم نسخ مستقلة لكل خيط أو أنشئ عروض/حاويات شرائح منفصلة لكل خيط مسبقًا. يتبع هذا النهج التوصية العامة بعدم مشاركة نسخة عرض واحدة عبر الخيوط.

**هل من الآمن تنفيذ تصدير متوازي إلى صيغ مختلفة (PDF، HTML، صور) بشرط أن يكون لكل خيط نسخة `Presentation` خاصة به؟**

نعم. باستخدام نسخ مستقلة ومسارات إخراج منفصلة، عادةً ما تتوازى هذه المهام بشكل صحيح؛ تجنب أي كائنات عرض مشتركة وتدفقات I/O مشتركة.

**ماذا عليّ أن أفعل بإعدادات الخطوط العامة (المجلدات، الاستبدالات) في بيئة متعددة الخيوط؟**

قم بتهيئة جميع إعدادات الخطوط العامة قبل بدء الخيوط ولا تغيرها أثناء العمل المتوازي. هذا يلغي حالات السباق عند الوصول إلى موارد الخطوط المشتركة.