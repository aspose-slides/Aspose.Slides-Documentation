---
title: المعالجة المتعدّدة الخيوط في Aspose.Slides لـ Python
linktitle: المعالجة المتعدّدة الخيوط
type: docs
weight: 200
url: /ar/python-net/multithreading/
keywords:
- المعالجة المتعدّدة الخيوط
- خيوط متعددة
- العمل المتوازي
- تحويل الشرائح
- الشرائح إلى صور
- باوربوينت
- OpenDocument
- العرض التقديمي
- Python
- Aspose.Slides
description: "تعزّز المعالجة المتعدّدة الخيوط في Aspose.Slides لـ Python معالجة ملفات PowerPoint و OpenDocument. اكتشف أفضل الممارسات لسير عمل العروض التقديمية بكفاءة."
---

## **مقدمة**

بينما العمل المتوازي مع العروض التقديمية ممكن (بجانب التحليل/التحميل/النسخ) وكل شيء يسير بشكل جيد (معظم الأوقات)، هناك فرصة صغيرة قد تحصل فيها على نتائج غير صحيحة عند استخدام المكتبة في خيوط متعددة.

نوصي بشدة بعدم استخدام مثيل واحد من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) في بيئة متعددة الخيوط لأنه قد يؤدي إلى أخطاء أو فشل غير متوقع يصعب اكتشافه.

ليس من الآمن تحميل أو حفظ أو/و نسخ مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) في خيوط متعددة. مثل هذه العمليات **غير** مدعومة. إذا كنت بحاجة إلى أداء مهام من هذا القبيل، يجب عليك القيام بعمليات متوازية باستخدام عدة عمليات ذات خيط واحد - ويجب على كل من هذه العمليات استخدام مثيل خاص بها من العروض التقديمية.

## **تحويل شرائح العرض التقديمي إلى صور بشكل متوازي**

لنفرض أننا نريد تحويل جميع الشرائح من عرض تقديمي PowerPoint إلى صور PNG بشكل متوازي. نظرًا لأنه ليس من الآمن استخدام مثيل واحد من `Presentation` في خيوط متعددة، نقوم بتقسيم شرائح العرض التقديمي إلى عروض تقديمية منفصلة ونحول الشرائح إلى صور بشكل متوازي، باستخدام كل عرض تقديمي في خيط منفصل. يوضح مثال الكود التالي كيفية القيام بذلك.

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

# انتظر حتى تكتمل جميع المهام.
for task in conversion_tasks:
    task.result()

del presentation
```