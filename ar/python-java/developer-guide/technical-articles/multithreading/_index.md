---
title: التصنيع المتعدد الخيوط في Aspose.Slides للبايثون عبر جافا
linktitle: التصنيع المتعدد الخيوط
type: docs
weight: 310
url: /ar/python-java/multithreading/
keywords:
- متعدد الخيوط
- عدة خيوط
- عمل متوازي
- تحويل الشرائح
- الشرائح إلى صور
- PowerPoint
- OpenDocument
- عرض
- Python
- Java
- Aspose.Slides
description: "يساعد التنفيذ المتعدد الخيوط في Aspose.Slides للبايثون عبر جافا في تحسين معالجة PowerPoint و OpenDocument. اكتشف أفضل الممارسات لتدفقات عمل العروض الفعّالة."
---
## **المقدمة**

على الرغم من أن العمل المتوازي مع العروض ممكن (باستثناء التحليل والتحميل والاستنساخ) وعادةً ما يعمل بشكل جيد، إلا أن هناك احتمالًا صغيرًا للحصول على نتائج غير صحيحة عند استخدام المكتبة في عدة خيوط.

نوصي بشدة بعدم استخدام نسخة واحدة من [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) في بيئة متعددة الخيوط لأن ذلك قد يؤدي إلى أخطاء أو فشل غير متوقع يصعب اكتشافه.

ليس من الآمن تحميل أو حفظ أو/أو استنساخ نسخة من [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) في عدة خيوط. هذه العمليات غير مدعومة. إذا كنت بحاجة إلى تنفيذ مثل هذه المهام، عليك أن تقوم بتوازي العمليات باستخدام عدة عمليات أحادية الخيط—وعلى كل عملية أن تستخدم نسخة خاصة بها من العرض.

## **تحويل شرائح العرض إلى صور بشكل متوازي**

لنفترض أننا نريد تحويل جميع الشرائح من عرض PowerPoint إلى صور PNG بشكل متوازي. بما أن استخدام نسخة واحدة من [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) في عدة خيوط غير آمن، نقسم شرائح العرض إلى عروض منفصلة ونحول الشرائح إلى صور بشكل متوازي، باستخدام كل عرض في خيط منفصل. يُظهر مثال الشيفرة التالي كيفية القيام بذلك.

```python
from concurrent.futures import ThreadPoolExecutor

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import ImageFormat, Presentation, SlideSizeScaleType


input_file_path = "sample.pptx"
output_file_path_template = "slide_{}.png"
image_scale = 2.0


def convert_slide_to_image(slide_presentation, slide_number):
    try:
        slide = slide_presentation.getSlides().get_Item(0)
        image = slide.getImage(image_scale, image_scale)
        try:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.Png)
        finally:
            image.dispose()
    finally:
        slide_presentation.dispose()


presentation = Presentation(input_file_path)
try:
    slide_count = presentation.getSlides().size()
    slide_size = presentation.getSlideSize().getSize()
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())

    with ThreadPoolExecutor() as executor:
        conversion_tasks = []
        for slide_index in range(slide_count):
            # استخراج الشريحة إلى عرض منفصل.
            slide_presentation = Presentation()
            slide_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)
            slide_presentation.getSlides().removeAt(0)
            slide_presentation.getSlides().addClone(presentation.getSlides().get_Item(slide_index))

            # تحويل الشريحة إلى صورة في مهمة منفصلة.
            slide_number = slide_index + 1
            conversion_task = executor.submit(convert_slide_to_image, slide_presentation, slide_number)
            conversion_tasks.append(conversion_task)

        # انتظار إكمال جميع المهام.
        for conversion_task in conversion_tasks:
            conversion_task.result()
finally:
    presentation.dispose()
```

## **الأسئلة الشائعة**

**هل أحتاج إلى استدعاء إعداد الترخيص في كل خيط؟**

لا. يكفي القيام بذلك مرة واحدة لكل عملية قبل بدء الخيوط. إذا كان من الممكن استدعاء [إعداد الترخيص](/slides/ar/python-java/licensing/) بشكل متزامن (على سبيل المثال أثناء التهيئة المتأخرة)، فقم بمزامنة هذا الاستدعاء لأن طريقة إعداد الترخيص نفسها غير آمنة للاستخدام في خيوط متعددة.

**هل يمكنني تمرير كائنات [Presentation] أو [Slide] بين الخيوط؟**

ليس من المستحسن تمرير كائنات العرض "الحية" بين الخيوط: استخدم نسخًا مستقلة لكل خيط أو أنشئ عروضًا أو حاويات شرائح منفصلة لكل خيط مسبقًا. يتماشى هذا النهج مع التوصية العامة بعدم مشاركة نسخة واحدة من العرض عبر الخيوط.

**هل من الآمن توازي تصدير إلى صيغ مختلفة (PDF، HTML، صور) بشرط أن يكون لكل خيط نسخة خاصة به من [Presentation]؟**

نعم. مع وجود نسخ مستقلة ومسارات إخراج منفصلة، عادةً ما يتم توازي هذه المهام بشكل صحيح؛ تجنب أي كائنات عرض مشتركة أو تدفقات إدخال/إخراج مشتركة.

**ماذا يجب أن أفعل بإعدادات الخطوط العامة (المجلدات، الاستبدالات) في بيئة متعددة الخيوط؟**

قم بتهيئة جميع [إعدادات الخط](/slides/ar/python-java/powerpoint-fonts/) العامة قبل بدء الخيوط ولا تقم بتغييرها أثناء العمل المتوازي. هذا يزيل حالات السباق عند الوصول إلى موارد الخطوط المشتركة.