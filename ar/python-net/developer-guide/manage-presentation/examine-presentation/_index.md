---
title: استرجاع وتحديث معلومات العرض التقديمي في بايثون
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
description: "استكشف الشرائح والبنية والبيانات الوصفية في عروض PowerPoint وOpenDocument باستخدام بايثون للحصول على رؤى أسرع وتدقيق محتوى أذكى."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides تحديد تنسيق العرض التقديمي وقراءة بيانات التعريف الخاصة بالمستند دون إنشاء نموذج كائن عرض تقديمي كامل. يكون هذا مفيدًا عندما تحتاج إلى تصنيف الملفات، بناء جرد، أو فحص الخصائص قبل اتخاذ قرار بتحميل ومعالجة محتوى العرض التقديمي.

توضح هذه المقالة الفحص الخفيف الوزن من خلال [PresentationFactory](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationfactory/) و [PresentationInfo](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/)، وكذلك التحديثات المستهدفة عبر [DocumentProperties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/documentproperties/).

## **التحقق من تنسيق العرض التقديمي**

إذا كان لديك بالفعل عرض تقديمي تم تحميله، راجع [Determine the Original Presentation Format](/slides/ar/python-net/detect-presentation-source-format/) للكشف بعد التحميل والقيود المتعلقة بتدفقات PPT و PPS و POT القديمة.

استخدم [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationfactory/get_presentation_info/) لفحص ملف دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/). تُظهر الخاصية [PresentationInfo.load_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/load_format/) التنسيق المكتشف، مثل PPTX أو PPT أو ODP.

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **إنشاء جرد عرض تقديمي خفيف الوزن**

عند معالجة عدد كبير من ملفات العرض التقديمي، قد تحتاج إلى جرد مدمج للتحقق أو الفهرسة أو نظام إدارة مستندات. في هذا السيناريو، استخدم [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationfactory/get_presentation_info/) للحصول على كائن [PresentationInfo](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/)، ثم استدعِ [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/read_document_properties/) لقراءة بيانات تعريف المستند. لا ينشئ هذا النهج كائن [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) ولا يتطلب تجوالًا في نموذج كائن العرض الكامل.

الخصائص الموسعة التي تُظهرها [DocumentProperties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/documentproperties/) توفر القيم التالية للجرد:

| الخاصية | قيمة الجرد |
| --- | --- |
| [slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides/documentproperties/slides/ar/) | العدد الإجمالي للشرائح. |
| [hidden_slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides/documentproperties/hidden_slides/) | عدد الشرائح المخفية. |
| [notes](https://reference.aspose.com/slides/ar/python-net/aspose.slides/documentproperties/notes/) | عدد الشرائح التي تحتوي على ملاحظات. |
| [paragraphs](https://reference.aspose.com/slides/ar/python-net/aspose.slides/documentproperties/paragraphs/) | العدد الإجمالي للفقرات، إن توفرت. |
| [words](https://reference.aspose.com/slides/ar/python-net/aspose.slides/documentproperties/words/) | العدد الإجمالي للكلمات. |
| [multimedia_clips](https://reference.aspose.com/slides/ar/python-net/aspose.slides/documentproperties/multimedia_clips/) | العدد الإجمالي لمقاطع الصوت والفيديو. |

يعرض المثال التالي هذه القيم دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) ويطبع جردًا مدمجًا. كما يجمع بين [heading_pairs](https://reference.aspose.com/slides/ar/python-net/aspose.slides/documentproperties/heading_pairs/) و [titles_of_parts](https://reference.aspose.com/slides/ar/python-net/aspose.slides/documentproperties/titles_of_parts/) لعرض مجموعات محتوى مثل الخطوط، السمات، وعناوين الشرائح.

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

كل [HeadingPair](https://reference.aspose.com/slides/ar/python-net/aspose.slides/headingpair/) يزود باسم مجموعة وعدد العناصر في تلك المجموعة. تعتبر [DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/ar/python-net/aspose.slides/documentproperties/titles_of_parts/) مجموعة مسطحة مرتبة، لذا يتم استهلاك عدد العناوين المتتالية المحدد بواسطة كل زوج عنوان.

### **البيانات الوصفية المخزنة وقيود التنسيق**

تعكس خصائص الجرد التي تُرجعها [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/read_document_properties/) البيانات الوصفية المتوفرة في المستند الأصلي. لا يحمل Aspose.Slides نموذج كائن العرض ويجتازه لإعادة حساب هذه القيم لهذه العملية. تُعرض الخصائص المفقودة بالقيم الافتراضية، وقد تكون القيم المخزنة قديمة إذا لم تُحدّث تطبيق حفظ الملف الأخيرة خصائص المستند.

- **PPTX:** يوفر التنسيق خصائص مستند موسعة لعدد الشرائح، الملاحظات، الشرائح المخفية، الفقرات، الكلمات، والوسائط المتعددة، بالإضافة إلى أزواج العناوين وعناوين الأجزاء. تعتمد التوفرية على الخصائص التي كتبها منتج المستند.
- **PPT:** يمكن للتنسيق الثنائي تخزين خصائص ملخص المستند المقابلة. إذا كانت الخاصية غائبة أو لم يُحدّثها منتج المستند، تُرجع Aspose.Slides قيمتها المخزنة أو الافتراضية بدلًا من حسابها من الشرائح.
- **ODP:** توفر بيانات تعريف OpenDocument إحصاءات مستند عامة، مثل عدد الصفحات، الفقرات، والكلمات، لكن هذه القيم لا تتطابق مع كل خاصية موسعة خاصة بـ PowerPoint. قد تكون بيانات تعريف الشرائح المخفية، ملاحظات الشرائح، الوسائط المتعددة، أزواج العناوين، وعناوين الأجزاء غير متاحة، وقد تُعيد خصائص الجرد قيمًا افتراضية. لا تُعامل القيمة الصفرية أو المجموعة الفارغة كدليل قاطع على غياب المحتوى المقابل.

استخدم نهج البيانات الوصفية الخفيف للجرود والفحوص الأولية. حمل العرض التقديمي وتفقد نموذج كائنه الحي عندما يجب أن يعكس النتيجة التغييرات في الذاكرة أو عندما تحتاج إلى التحقق من المحتوى الفعلي للعرض.

## **تحديث خصائص العرض التقديمي**

يمكن أيضًا تعديل الخصائص التي تُرجعها [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/read_document_properties/) دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) . طبّق التغييرات باستخدام [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/update_document_properties/)، ثم احفظ العرض المرتبط عبر [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/write_binded_presentation/).

الصورة التالية تُظهر خصائص المستند الأصلية.

![Original document properties of the PowerPoint presentation](input_properties.png)

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

الصورة التالية تُظهر خصائص المستند المحدثة.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **روابط مفيدة**

للفحوص الأمنية ذات الصلة وإعدادات الحماية، راجع المقالات التالية:

- [Password-Protect Presentations](/slides/ar/python-net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/ar/python-net/write-protected-presentation/)

## **الأسئلة الشائعة**

**كيف يمكنني التحقق مما إذا كانت الخطوط مدمجة وأيها؟**

حمّل العرض التقديمي واستخدم [Presentation.fonts_manager](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/fonts_manager/). استدعِ [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) للحصول على الخطوط المدمجة و [FontsManager.get_fonts](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontsmanager/get_fonts/) للحصول على الخطوط المستخدمة في العرض. قارن النتيجتين لتحديد الخطوط المطلوبة للعرض ولكنها غير مدمجة.

**كيف يمكنني بسرعة معرفة ما إذا كان الملف يحتوي على شرائح مخفية وعددها؟**

عندما تكون بيانات المستند المخزنة كافية، اقرأ [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides/documentproperties/hidden_slides/) عبر [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationfactory/get_presentation_info/) و [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/read_document_properties/). هذا مناسب لجرد خفيف الوزن. إذا تم تعديل العرض في الذاكرة، قد تكون البيانات المخزنة مفقودة أو قديمة، أو إذا كنت بحاجة للتحقق من القيم الحية، تجول عبر [Presentation.slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/slides/ar/) وتفحّص خاصية [Slide.hidden](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/hidden/) لكل شريحة بدلاً من ذلك.

**هل يمكنني اكتشاف ما إذا كان تم استخدام حجم واتجاه شريحة مخصص، وما إذا كانت تختلف عن القيم الافتراضية؟**

نعم. حمّل العرض التقديمي وقرأ [Presentation.slide_size](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/slide_size/). تفحّص [SlideSize.type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidesize/type/)، [SlideSize.size](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidesize/size/)، و [SlideSize.orientation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidesize/orientation/) للمقارنة بين الإعدادات الحالية والإعدادات المسبقة المتوقعة والأبعاد.

**هل هناك طريقة سريعة لمعرفة ما إذا كانت المخططات تشير إلى مصادر بيانات خارجية؟**

نعم. حدد كل [Chart](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chart/) وتفحّص [ChartData.data_source_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/data_source_type/). للمصنف الخارجي، اقرأ [ChartData.external_workbook_path](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/external_workbook_path/). يحدد نوع مصدر البيانات والمسار إشارة إلى مرجع خارجي، لكن التحقق من توفر الهدف يتطلب فحصًا منفصلًا للموارد.

**كيف يمكنني تقييم "الشرائح الثقيلة" التي قد تبطئ عملية العرض أو تصدير PDF؟**

لا توجد خاصية تعقيد واحدة. تجول عبر [Presentation.slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/slides/ar/) ومجموعات [BaseSlide.shapes](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseslide/shapes/) لكل شريحة. استخدم عدد الأشكال ووجود صور كبيرة، تأثيرات، رسومات متحركة، أو وسائط متعددة كإشارات فحص، وقم بقياس عرض تمثيلي أو تصدير ممثَل قبل اعتبار الشريحة عنق زجاجة أكيد للأداء.