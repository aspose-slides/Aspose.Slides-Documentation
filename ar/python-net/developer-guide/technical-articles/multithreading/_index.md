---
title: التعددية في Aspose.Slides للبايثون
linktitle: التعددية
type: docs
weight: 200
url: /ar/python-net/multithreading/
keywords:
- التعددية
- عدة خيوط
- عمل متوازي
- تحويل الشرائح
- شرائح إلى صور
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "التعددية في Aspose.Slides للبايثون عبر .NET تعزز معالجة PowerPoint وOpenDocument. اكتشف أفضل الممارسات لتدفقات عمل العروض التقديمية الفعّالة."
---

## **مقدمة**

بينما العمل المتوازي مع العروض التقديمية ممكن (إلى جانب التحليل/التحميل/الاستنساخ) وتسير الأمور بشكل جيد في معظم الأوقات، هناك احتمال صغير للحصول على نتائج غير صحيحة عند استخدام المكتبة في عدة خيوط.

نحن نوصي بشدة بعدم استخدام نسخة واحدة من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) في بيئة متعددة الخيوط لأن ذلك قد يؤدي إلى أخطاء أو فشل غير متوقع يصعب اكتشافه.

ليس من الآمن تحميل أو حفظ أو/أو استنساخ نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) في عدة خيوط. هذه العمليات غير مدعومة. إذا كنت بحاجة إلى تنفيذ مثل هذه المهام، عليك موازنة العمليات باستخدام عدة عمليات أحادية الخيط—وعلى كل عملية أن تستخدم نسخة العرض الخاصة بها.

## **تحويل شرائح العرض إلى صور بشكل متوازي**

لنفترض أننا نريد تحويل جميع الشرائح من عرض PowerPoint إلى صور PNG بشكل متوازي. نظرًا لأنه غير آمن استخدام نسخة واحدة من `Presentation` في عدة خيوط، نقسم شرائح العرض إلى عروض تقديمية منفصلة ونحول الشرائح إلى صور بشكل متوازي، باستخدام كل عرض في خيط منفصل. يوضح المثال البرمجي التالي كيفية القيام بذلك.

```py
input_file_path = "sample.pptx"
output_file_path_template = "slide_{0}.png"
image_scale = 2

presentation = Presentation(input_file_path)

slide_count = len(presentation.slides)
slide_size = presentation.slide_size.size

conversion_tasks = []


def convert_slide(slide_index):
    # Extract slide i into a separate presentation.
    with Presentation() as slide_presentation:
        slide_presentation.slide_size.set_size(slide_size.width, slide_size.height, SlideSizeScaleType.DO_NOT_SCALE)
        slide_presentation.slides.remove_at(0)
        slide_presentation.slides.add_clone(presentation.slides[slide_index])

        slide_number = slide_index + 1
        slide = slide_presentation.slides[0]

        # Convert the slide to an image.
        with slide.get_image(image_scale, image_scale) as image:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.PNG)


with ThreadPoolExecutor() as thread_executor:
    for index in range(slide_count):
        conversion_tasks.append(thread_executor.submit(convert_slide, index))

# Wait for all tasks to complete.
for task in conversion_tasks:
    task.result()

del presentation
```

## **الأسئلة الشائعة**

**هل أحتاج إلى استدعاء إعداد الترخيص في كل خيط؟**

لا. يكفي القيام بذلك مرة واحدة لكل عملية/مجال تطبيق قبل أن تبدأ الخيوط. إذا كان من الممكن استدعاء [إعداد الترخيص](/slides/ar/python-net/licensing/) بشكل متزامن (على سبيل المثال، أثناء التهيئة الكسولة)، يجب مزامنة هذا الاستدعاء لأن طريقة إعداد الترخيص نفسها ليست آمنة للخيوط.

**هل يمكنني تمرير كائنات `Presentation` أو `Slide` بين الخيوط؟**

ليس من المستحسن تمرير كائنات العرض "الحية" بين الخيوط: استخدم نسخًا مستقلة لكل خيط أو أنشئ عروضًا تقديمية/حاويات شرائح منفصلة مسبقًا لكل خيط. يتماشى هذا النهج مع التوصية العامة بعدم مشاركة نسخة عرض واحدة عبر الخيوط.

**هل من الآمن موازنة تصدير إلى صيغ مختلفة (PDF، HTML، صور) بشرط أن يكون لكل خيط نسخة `Presentation` خاصة به؟**

نعم. مع النسخ المستقلة ومسارات الإخراج المنفصلة، عادةً ما تُنجز هذه المهام بشكل متوازي صحيح؛ تجنّب مشاركة كائنات العرض أو تدفقات الإدخال/الإخراج.

**ماذا أفعل بإعدادات الخطوط العامة (المجلدات، الاستبدالات) في بيئة متعددة الخيوط؟**

قم بتهيئة جميع إعدادات الخطوط العامة قبل بدء الخيوط ولا تغيّرها خلال العمل المتوازي. هذا يمنع التعارضات عند الوصول إلى موارد الخطوط المشتركة.