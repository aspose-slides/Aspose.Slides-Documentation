---
title: استرجاع وتحديث معلومات العرض التقديمي في بايثون عبر جافا
linktitle: معلومات العرض التقديمي
type: docs
weight: 30
url: /ar/python-java/examine-presentation/
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
- Java
- Aspose.Slides
description: "استكشف الشرائح والبنية والبيانات الوصفية في عروض PowerPoint وOpenDocument باستخدام بايثون عبر جافا للحصول على رؤى أسرع ومراجعات محتوى أذكى."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides تحديد تنسيق العرض التقديمي وقراءة بياناته الوصفية دون إنشاء نموذج كائن عرض تقديمي كامل. هذا مفيد عندما تحتاج إلى تصنيف الملفات، بناء جرد، أو فحص الخصائص قبل اتخاذ القرار بتحميل ومعالجة محتوى العرض التقديمي.

تتطلب الأمثلة Aspose.Slides لـ Python عبر Java وبيئة تشغيل Java متوافقة. يبدأ كل مثال تشغيل JVM إذا لم يكن قيد التشغيل بالفعل. قدم ملفات عروض تقديمية موجودة في المسارات المستخدمة في الأمثلة.

توضح هذه المقالة فحصًا خفيفًا من خلال [PresentationFactory](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationfactory/) و[PresentationInfo](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationinfo/)، بالإضافة إلى تحديثات موجهة عبر [DocumentProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/documentproperties/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadFormat, PresentationFactory

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_name)
    load_format = presentation_info.getLoadFormat()
    format_name = f"Other ({load_format})"

    if load_format == LoadFormat.Pptx:
        format_name = "PPTX"
    elif load_format == LoadFormat.Ppt:
        format_name = "PPT"
    elif load_format == LoadFormat.Odp:
        format_name = "ODP"

    print(f"{file_name}: {format_name}")
```
## **التحقق من تنسيق العرض التقديمي**

استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationfactory/#getPresentationInfo) لفحص ملف دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) . طريقة [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationinfo/#getLoadFormat) تُبلِغ عن التنسيق المكتشف، مثل PPTX أو PPT أو ODP.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadFormat, PresentationFactory

file_path = "sample.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)
document_properties = presentation_info.readDocumentProperties()

load_format = presentation_info.getLoadFormat()
format_name = f"Other ({load_format})"

if load_format == LoadFormat.Pptx:
    format_name = "PPTX"
elif load_format == LoadFormat.Ppt:
    format_name = "PPT"
elif load_format == LoadFormat.Odp:
    format_name = "ODP"

print(f"File: {Path(file_path).name}")
print(f"Format: {format_name}")
print(f"Title: {document_properties.getTitle()}")
print(f"Author: {document_properties.getAuthor()}")
print("Statistics:")
print(f"  Slides: {document_properties.getSlides()}")
print(f"  Hidden slides: {document_properties.getHiddenSlides()}")
print(f"  Slides with notes: {document_properties.getNotes()}")
print(f"  Paragraphs: {document_properties.getParagraphs()}")
print(f"  Words: {document_properties.getWords()}")
print(f"  Multimedia clips: {document_properties.getMultimediaClips()}")

heading_pairs = document_properties.getHeadingPairs()
titles_of_parts = document_properties.getTitlesOfParts()
heading_pairs = heading_pairs if heading_pairs is not None else []
titles_of_parts = titles_of_parts if titles_of_parts is not None else []
part_index = 0

if len(heading_pairs) == 0 or len(titles_of_parts) == 0:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.getName()} ({heading_pair.getCount()})")

        for part_offset in range(heading_pair.getCount()):
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
## **إنشاء جرد عرض تقديمي خفيف الوزن**

عند معالجة العديد من ملفات العرض التقديمي، قد تحتاج إلى جرد مدمج للتحقق أو الفهرسة أو نظام إدارة مستندات. في هذا السيناريو، استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationfactory/#getPresentationInfo) للحصول على كائن [PresentationInfo](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationinfo/)، ثم استدعِ [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationinfo/#readDocumentProperties) لقراءة بيانات المستند الوصفية. لا ينشئ هذا النهج كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) ولا يتطلب استعراض نموذج كائن العرض بالكامل.

الخصائص الموسعة التي تُعرضها [DocumentProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/documentproperties/) توفر القيم التالية للجرد:

| الطريقة | قيمة الجرد |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/documentproperties/#getSlides) | الإجمالي الكلي للشرائح. |
| [getHiddenSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/documentproperties/#getHiddenSlides) | عدد الشرائح المخفية. |
| [getNotes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/documentproperties/#getNotes) | عدد الشرائح التي تحتوي على ملاحظات. |
| [getParagraphs](https://reference.aspose.com/slides/ar/python-java/aspose.slides/documentproperties/#getParagraphs) | الإجمالي الكلي للفقرات، إذا كانت متوفرة. |
| [getWords](https://reference.aspose.com/slides/ar/python-java/aspose.slides/documentproperties/#getWords) | الإجمالي الكلي للكلمات. |
| [getMultimediaClips](https://reference.aspose.com/slides/ar/python-java/aspose.slides/documentproperties/#getMultimediaClips) | الإجمالي الكلي لمقاطع الصوت والفيديو. |

المثال التالي يقرأ هذه القيم دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) ويطبع جردًا مدمجًا. كما يجمع بين [getHeadingPairs](https://reference.aspose.com/slides/ar/python-java/aspose.slides/documentproperties/#getHeadingPairs) و[getTitlesOfParts](https://reference.aspose.com/slides/ar/python-java/aspose.slides/documentproperties/#getTitlesOfParts) لعرض مجموعات المحتوى مثل الخطوط والسمات وعناوين الشرائح.

كل [HeadingPair](https://reference.aspose.com/slides/ar/python-java/aspose.slides/headingpair/) يوفر اسم مجموعة وعدد العناصر في تلك المجموعة. تُعيد [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/ar/python-java/aspose.slides/documentproperties/#getTitlesOfParts) مصفوفة مسطحة مرتبة، لذا استهلك عدد العناوين المتتالية المحدد بواسطة كل زوج عنوان.

### **البيانات الوصفية المخزنة وقيود الصيغة**

القيم التي تُرجعها [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationinfo/#readDocumentProperties) تعكس البيانات الوصفية المتاحة في المستند الأصلي. لا يقوم Aspose.Slides بتحميل واستعراض نموذج كائن العرض لإعادة حساب هذه القيم لهذا الاستدعاء. تمثّل الخصائص المفقودة بقيم افتراضية، وقد تكون القيم المخزنة قديمة إذا لم يقم التطبيق الذي حفظ الملف آخرًا بتحديث خصائص المستند.

- **PPTX:** يوفر التنسيق خصائص مستند موسعة لعدد الشرائح، الملاحظات، الشرائح المخفية، الفقرات، الكلمات، ومقاطع الوسائط المتعددة، بالإضافة إلى أزواج العناوين وعناوين الأجزاء. تعتمد التوافرية على الخصائص التي كتبها مُنتج المستند.
- **PPT:** يمكن للنسق الثنائي تخزين خصائص ملخص المستند المقابلة. إذا كانت خاصية غير موجودة أو لم يُحدّثها مُنتج المستند، تُعيد Aspose.Slides قيمتها المخزنة أو الافتراضية بدلاً من حسابها من الشرائح.
- **ODP:** توفر بيانات OpenDocument إحصائيات عامة للمستند مثل عدد الصفحات والفقرات والكلمات، لكن هذه القيم لا تتطابق مع كل خاصية موسعة خاصة بـ PowerPoint. قد تكون بيانات الشرائح المخفية، ملاحظات الشرائح، الوسائط المتعددة، أزواج العناوين، وعناوين الأجزاء غير متاحة، وقد تُرجع خصائص الجرد قيمًا افتراضية. لا تُعامل القيمة الصفرية أو المصفوفة الفارغة كدليل قاطع على غياب المحتوى المقابل.

استخدم نهج البيانات الوصفية الخفيفة للجرد والتحققات الأولية. حمّل العرض التقديمي وتفقد نموذج كائنه الحي عندما يجب أن يعكس النتيجة تغييرات الذاكرة أو عندما تحتاج إلى التحقق من المحتوى الفعلي للعرض.

## **تحديث خصائص العرض التقديمي**

يمكن أيضًا تغيير الخصائص التي تُرجعها [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationinfo/#readDocumentProperties) دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) . طبّق التغييرات باستخدام [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationinfo/#updateDocumentProperties)، ثم اكتب العرض المرتبط باستخدام [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationinfo/#writeBindedPresentation).

الصورة التالية تُظهر خصائص المستند الأصلية لعرض PowerPoint.

![خصائص المستند الأصلية لعرض PowerPoint](input_properties.png)

المثال التالي يغيّر العنوان ووقت الحفظ الأخير ويكتب النتيجة إلى ملف جديد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory
from java.io import FileOutputStream
from java.util import Date

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(source_file)
document_properties = presentation_info.readDocumentProperties()

document_properties.setTitle("Quarterly sales report")
last_saved_time = Date()
document_properties.setLastSavedTime(last_saved_time)

presentation_info.updateDocumentProperties(document_properties)
output_stream = FileOutputStream(output_file)
try:
    presentation_info.writeBindedPresentation(output_stream)
finally:
    output_stream.close()
```

الصورة التالية تُظهر خصائص المستند المحدثة لعرض PowerPoint.

![خصائص المستند المحدثة لعرض PowerPoint](output_properties.png)

## **روابط مفيدة**

للتحقق من الأمان وإعدادات الحماية ذات الصلة، راجع المقالات التالية:

- [حماية عروض تقديمية بكلمة مرور](/slides/ar/python-java/password-protected-presentation/)
- [حماية عروض تقديمية من الكتابة](/slides/ar/python-java/write-protected-presentation/)

## **الأسئلة الشائعة**

**كيف يمكنني التحقق مما إذا كانت الخطوط مدمجة وأيها؟**

حمّل العرض التقديمي واستخدم [Presentation.getFontsManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getFontsManager). استدعِ [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) للحصول على الخطوط المدمجة و[FontsManager.getFonts](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fontsmanager/#getFonts) للحصول على الخطوط المستخدمة في العرض. قارن النتيجتين لتحديد الخطوط المطلوبة للعرض لكنها غير مدمجة.

**كيف يمكنني بسرعة معرفة ما إذا كان الملف يحتوي على شرائح مخفية وعددها؟**

عند كون البيانات الوصفية المخزنة كافية، اقرأ [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/documentproperties/#getHiddenSlides) عبر [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationfactory/#getPresentationInfo) و[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentationinfo/#readDocumentProperties). هذا مناسب لجرد خفيف. إذا تم تعديل العرض في الذاكرة، قد تكون البيانات الوصفية المخزنة مفقودة أو قديمة، أو إذا كنت بحاجة إلى التحقق من القيم الحية، استعرض [Presentation.getSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getSlides) وتفقد طريقة [Slide.getHidden](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#getHidden) لكل شريحة بدلاً من ذلك.

**هل يمكنني اكتشاف ما إذا كان يتم استخدام حجم واتجاه شريحة مخصصين، وما إذا كانا يختلفان عن الإعدادات الافتراضية؟**

نعم. حمّل العرض التقديمي واستدعِ [Presentation.getSlideSize](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getSlideSize). استخدم [SlideSize.getType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidesize/#getType)، [SlideSize.getSize](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidesize/#getSize) و[SlideSize.getOrientation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidesize/#getOrientation) لمقارنة الإعدادات الحالية مع الإعدادات المسبقة والأبعاد المتوقعة.

**هل هناك طريقة سريعة لمعرفة ما إذا كانت المخططات تشير إلى مصادر بيانات خارجية؟**

نعم. حدد كل [Chart](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chart/) واستدعِ [ChartData.getDataSourceType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#getDataSourceType). لمصنف خارجي، استدعِ [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). يُظهر نوع مصدر البيانات والمسار إشارة إلى مرجع خارجي، لكن التحقق من توفر الهدف يتطلب فحصًا منفصلاً للموارد.

**كيف يمكنني تقييم الشرائح 'الثقيلة' التي قد تبطئ عملية العرض أو تصدير PDF؟**

لا توجد خاصية تعقيد واحدة. استعرض [Presentation.getSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getSlides) ومجموعات [BaseSlide.getShapes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslide/#getShapes) لكل شريحة. استخدم عدد الأشكال ووجود صور كبيرة أو تأثيرات أو رسومات متحركة أو وسائط متعددة كإشارات تصفية، وقم بقياس عرض تمثيلي أو تصدير قبل اعتبار الشريحة عنق زجاجة مؤكد للأداء.