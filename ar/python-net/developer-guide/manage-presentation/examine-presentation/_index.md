---
title: استرجاع وتحديث معلومات العرض التقديمي باستخدام بايثون
linktitle: معلومات العرض التقديمي
type: docs
weight: 30
url: /ar/python-net/examine-presentation/
keywords:
- تنسيق العرض التقديمي
- خصائص العرض التقديمي
- خصائص المستند
- الحصول على الخصائص
- قراءة الخصائص
- تغيير الخصائص
- تعديل الخصائص
- تحديث الخصائص
- فحص PPTX
- فحص PPT
- فحص ODP
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "استكشف الشرائح والهيكل والبيانات التعريفية في عروض PowerPoint وOpenDocument باستخدام بايثون للحصول على رؤى أسرع وتدقيق محتوى أذكى."
---
## **نظرة عامة**

Aspose.Slides يمكنه التعرف على تنسيق العرض التقديمي وقراءة بيانات تعريف المستند دون إنشاء نموذج كائن عرض تقديمي كامل. هذا مفيد عندما تحتاج إلى تصنيف الملفات، بناء جرد، أو فحص الخصائص قبل اتخاذ قرار بتحميل ومعالجة محتوى العرض التقديمي.

توضح هذه المقالة فحصًا خفيفًا من خلال [PresentationFactory](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationfactory/) و[PresentationInfo](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/)، وكذلك التحديثات المستهدفة من خلال [DocumentProperties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/documentproperties/).

## **التحقق من تنسيق العرض التقديمي**

استخدم [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationfactory/get_presentation_info/) لفحص ملف دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) . الخاصية [PresentationInfo.load_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/load_format/) تُظهر التنسيق المكتشف، مثل PPTX أو PPT أو ODP.

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **إنشاء جرد عرض تقديمي خفيف الوزن**

عند معالجة العديد من ملفات العرض التقديمي، قد تحتاج إلى جرد مدمج للتحقق، الفهرسة، أو نظام إدارة المستندات. في هذا السيناريو، استخدم [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationfactory/get_presentation_info/) للحصول على كائن [PresentationInfo](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/)، ثم استدعِ [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/read_document_properties/) لقراءة بيانات تعريف المستند. لا يُنشئ هذا الأسلوب كائن [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) ولا يتطلب traversing نموذج كائن العرض الكامل.

الخصائص الموسعة التي توفرها [DocumentProperties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/documentproperties/) تقدم القيم التالية للجرد:

| الخاصية | قيمة الجرد |
| --- | --- |
| [slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides/documentproperties/slides/ar/) | إجمالي عدد الشرائح. |
| [hidden_slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides/documentproperties/hidden_slides/) | عدد الشرائح المخفية. |
| [notes](https://reference.aspose.com/slides/ar/python-net/aspose.slides/documentproperties/notes/) | عدد الشرائح التي تحتوي على ملاحظات. |
| [paragraphs](https://reference.aspose.com/slides/ar/python-net/aspose.slides/documentproperties/paragraphs/) | إجمالي عدد الفقرات، إذا كانت متاحة. |
| [words](https://reference.aspose.com/slides/ar/python-net/aspose.slides/documentproperties/words/) | إجمالي عدد الكلمات. |
| [multimedia_clips](https://reference.aspose.com/slides/ar/python-net/aspose.slides/documentproperties/multimedia_clips/) | إجمالي عدد مقاطع الصوت والفيديو. |

المثال التالي يقرأ هذه القيم دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) ويطبع جردًا مدمجًا. كما يجمع بين [heading_pairs](https://reference.aspose.com/slides/ar/python-net/aspose.slides/documentproperties/heading_pairs/) و[titles_of_parts](https://reference.aspose.com/slides/ar/python-net/aspose.slides/documentproperties/titles_of_parts/) لعرض مجموعات المحتوى مثل الخطوط، السمات، وعناوين الشرائح.

```python
import os
import aspose.slides as slides

file_path = "sample.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)
document_properties = presentation_info.read_document_properties()

print(f"File: {os.path.basename(file_path)}")
print(f"Format: {presentation_info.load_format}")
print(f"Title: {document_properties.title}")
print(f"Author: {document_properties.author}")
print("Statistics:")
print(f"  Slides: {document_properties.slides}")
print(f"  Hidden slides: {document_properties.hidden_slides}")
print(f"  Slides with notes: {document_properties.notes}")
print(f"  Paragraphs: {document_properties.paragraphs}")
print(f"  Words: {document_properties.words}")
print(f"  Multimedia clips: {document_properties.multimedia_clips}")

heading_pairs = document_properties.heading_pairs or []
titles_of_parts = document_properties.titles_of_parts or []
part_index = 0

if not heading_pairs or not titles_of_parts:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.name} ({heading_pair.count})")

        for _ in range(heading_pair.count):
            if part_index >= len(titles_of_parts):
                break

            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1

    if part_index < len(titles_of_parts):
        print("  Other parts:")

        while part_index < len(titles_of_parts):
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1
```

كل [HeadingPair](https://reference.aspose.com/slides/ar/python-net/aspose.slides/headingpair/) تُوفر اسم مجموعة وعدد العناصر في تلك المجموعة. [DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/ar/python-net/aspose.slides/documentproperties/titles_of_parts/) هي مجموعة مسطحة مُرتبة، لذا استهلك عدد العناوين المتتالية المحدد بواسطة كل heading pair.

### **البيانات التعريفية المخزنة وقيود التنسيق**

الخصائص التي تُرجعها [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/read_document_properties/) تعكس البيانات التعريفية المتوفرة في المستند الأصلي. لا يقوم Aspose.Slides بتحميل وتصفح نموذج كائن العرض لإعادة حساب هذه القيم لهذا الاستدعاء. تُظهر الخصائص المفقودة قيمًا افتراضية، وقد تكون القيم المخزنة قديمة إذا لم تقم التطبيق الذي حفظ الملف آخرًا بتحديث خصائص المستند.

- **PPTX:** يوفر التنسيق خصائص مستند موسعة لعدد الشرائح، الملاحظات، الشرائح المخفية، الفقرات، الكلمات، ومقاطع الوسائط المتعددة، بالإضافة إلى heading pairs وعناوين الأجزاء. تعتمد التوفرية على الخصائص التي كتبها منتج المستند.
- **PPT:** يمكن للتنسيق الثنائي تخزين خصائص ملخص المستند المقابلة. إذا كانت الخاصية غير موجودة أو لم يتم تحديثها من قبل منتج المستند، تُعيد Aspose.Slides قيمتها المخزنة أو القيمة الافتراضية بدلاً من حسابها من الشرائح.
- **ODP:** تقدم بيانات تعريف OpenDocument إحصاءات عامة للمستند مثل عدد الصفحات، الفقرات، والكلمات، لكن هذه القيم لا تُطابق كل خاصية موسعة خاصة بـ PowerPoint. قد تكون بيانات التعريف للشرائح المخفية، ملاحظات الشرائح، الوسائط المتعددة، heading‑pair، وعناوين الأجزاء غير متوفرة، وقد تُعيد خصائص الجرد قيمًا افتراضية. لا تُعامل القيمة الصفرية أو المجموعة الفارغة كدليل قاطع على عدم وجود المحتوى المقابل.

استخدم نهج البيانات التعريفية الخفيف للجرد والتحققات الأولية. حمل العرض وتفحص نموذج كائنه الحي عندما يجب أن يعكس النتيجة التغييرات في الذاكرة أو عندما تحتاج إلى التحقق من محتوى العرض الفعلي.

## **تحديث خصائص العرض التقديمي**

يمكن أيضًا تغيير الخصائص التي تُرجعها [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/read_document_properties/) دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) . طبق التغييرات باستخدام [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/update_document_properties/)، ثم اكتب العرض المرتبط باستخدام [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/write_binded_presentation/).

الصورة التالية تُظهر خصائص المستند الأصلية لعرض PowerPoint.

![خصائص المستند الأصلية لعرض PowerPoint](input_properties.png)

المثال التالي يغيّر العنوان ووقت الحفظ الأخير ويكتب النتيجة إلى ملف جديد:

```python
import datetime
import aspose.slides as slides

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(source_file)
document_properties = presentation_info.read_document_properties()

document_properties.title = "Quarterly sales report"
document_properties.last_saved_time = datetime.datetime.now(datetime.timezone.utc)

presentation_info.update_document_properties(document_properties)

with open(output_file, "wb") as output_stream:
    presentation_info.write_binded_presentation(output_stream)
```

الصورة التالية تُظهر خصائص المستند المعدلة لعرض PowerPoint.

![خصائص المستند المعدلة لعرض PowerPoint](output_properties.png)

## **روابط مفيدة**

للفحوصات الأمنية والإعدادات المتعلقة بالحماية، راجع المقالات التالية:

- [حماية العروض التقديمية بكلمة مرور](/slides/ar/python-net/password-protected-presentation/)
- [حماية العروض من الكتابة](/slides/ar/python-net/write-protected-presentation/)

## **الأسئلة المتكررة**

**كيف يمكنني التحقق مما إذا كانت الخطوط مضمنة وما هي؟**

حمّل العرض واستخدم [Presentation.fonts_manager](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/fonts_manager/). استدعِ [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) للحصول على الخطوط المدمجة و[FontsManager.get_fonts](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontsmanager/get_fonts/) للحصول على الخطوط المستخدمة في العرض. قارن النتيجتين لتحديد الخطوط المطلوبة للعرض لكنها غير مدمجة.

**كيف يمكنني بسرعة معرفة ما إذا كان الملف يحتوي على شرائح مخفية وعددها؟**

عند كفاية بيانات تعريف المستند المخزنة، اقرأ [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides/documentproperties/hidden_slides/) عبر [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationfactory/get_presentation_info/) و[PresentationInfo.read_document_properties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/read_document_properties/). هذا مناسب لجرد خفيف. إذا تم تعديل العرض في الذاكرة، قد تكون البيانات المخزنة مفقودة أو قديمة، أو إذا احتجت للتحقق من القيم الحية، استعرض [Presentation.slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/slides/ar/) وتفقد خاصية [Slide.hidden](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/hidden/) لكل شريحة بدلاً من ذلك.

**هل يمكنني اكتشاف ما إذا كان يتم استخدام حجم وتوجه شريحة مخصص، وما إذا كان يختلف عن الإعدادات الافتراضية؟**

نعم. حمّل العرض واقرأ [Presentation.slide_size](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/slide_size/). افحص [SlideSize.type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidesize/type/)، [SlideSize.size](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidesize/size/)، و[SlideSize.orientation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidesize/orientation/) لمقارنة الإعدادات الحالية مع القيم المسبقة المتوقعة والأبعاد.

**هل هناك طريقة سريعة لمعرفة ما إذا كانت المخططات تشير إلى مصادر بيانات خارجية؟**

نعم. حدد كل [Chart](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chart/) وتفحص [ChartData.data_source_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/data_source_type/). للمصنف الخارجي، اقرأ [ChartData.external_workbook_path](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/external_workbook_path/). نوع مصدر البيانات والمسار يحددان مرجعًا خارجيًا، لكن التحقق مما إذا كان الهدف متاحًا يتطلب فحصًا منفصلًا للموارد.

**كيف يمكنني تقييم الشرائح 'الثقيلة' التي قد تبطئ العرض أو تصدير PDF؟**

لا توجد خاصية تعقيد واحدة. استعرض [Presentation.slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/slides/ar/) وكل شريحة و[BaseSlide.shapes](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseslide/shapes/) الخاصة بها. استخدم عدد الأشكال ووجود صور كبيرة، تأثيرات، رسوم متحركة، أو وسائط متعددة كإشارات فحص، وقم بقياس تمثيل تجريبي للعرض أو التصدير قبل اعتبار شريحة كمسبب أداء حقيقي.