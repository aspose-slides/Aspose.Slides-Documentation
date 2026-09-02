---
title: استرجاع وتحديث معلومات العرض التقديمي باستخدام بايثون
linktitle: معلومات العرض التقديمي
type: docs
weight: 30
url: /ar/python-net/examine-presentation/
keywords:
- تنسيق العرض
- خصائص العرض
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

توضح هذه المقالة كيفية فحص معلومات العرض التقديمي في Aspose.Slides. تشرح كيفية تحديد تنسيق العرض الحالي دون تحميل الملف بالكامل، قراءة خصائص المستند الخاصة به، وتحديث هذه الخصائص عند الحاجة.

تعتمد الأمثلة على واجهات برمجة التطبيقات [PresentationInfo](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/) و[DocumentProperties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/documentproperties/) وتظهر العمليات النموذجية للعمل مع بيانات تعريف العرض التقديمي.

## **التحقق من تنسيق العرض التقديمي**

قبل العمل على عرض تقديمي، قد ترغب في معرفة ما هو التنسيق (PPT، PPTX، ODP، وغيرها) الذي يكون فيه العرض في الوقت الحالي.

يمكنك التحقق من تنسيق العرض التقديمي دون تحميله. انظر هذا الكود بلغة بايثون:

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **الحصول على خصائص العرض التقديمي**

يظهر لك هذا الكود بلغة بايثون كيفية الحصول على خصائص العرض التقديمي (معلومات حول العرض):

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

قد ترغب في مشاهدة [الخصائص ضمن فئة DocumentProperties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/documentproperties/#properties).

## **تحديث خصائص العرض التقديمي**

توفر Aspose.Slides الطريقة [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) التي تسمح لك بإجراء تغييرات على خصائص العرض التقديمي.

لنفترض أن لدينا عرض PowerPoint يحتوي على خصائص المستند الموضحة أدناه.

![خصائص المستند الأصلية لعرض PowerPoint](input_properties.png)

يظهر لك مثال الكود هذا كيفية تعديل بعض خصائص العرض التقديمي:

```py
import aspose.slides as slides
import datetime

file_name = "sample.pptx"

info = slides.PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

تظهر نتائج تغيير خصائص المستند أدناه.

![خصائص المستند المتغيرة لعرض PowerPoint](output_properties.png)

## **روابط مفيدة**

للحصول على مزيد من المعلومات حول العرض التقديمي وسماته الأمنية، قد تجد هذه الروابط مفيدة:

- [تأمين العروض بكلمة مرور](/slides/ar/python-net/password-protected-presentation/)
- [حماية العروض من الكتابة](/slides/ar/python-net/write-protected-presentation/)

## **الأسئلة المتكررة**

**كيف يمكنني التحقق مما إذا كانت الخطوط مضمنة وأيها؟**

ابحث عن [معلومات الخطوط المضمنة](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) على مستوى العرض التقديمي، ثم قارن تلك الإدخالات مع مجموعة [الخطوط المستخدمة فعليًا عبر المحتوى](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fontsmanager/get_fonts/) لتحديد الخطوط الضرورية للعرض.

**كيف يمكنني بسرعة معرفة ما إذا كان الملف يحتوي على شرائح مخفية وعددها؟**

قم بالتكرار عبر [مجموعة الشرائح](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slidecollection/) وتفقد علامة [الظهور](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/hidden/) لكل شريحة.

**هل يمكنني اكتشاف ما إذا كان يتم استخدام حجم واتجاه شريحة مخصص، وما إذا كانا يختلفان عن القيم الافتراضية؟**

نعم. قارن [حجم الشريحة](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/slide_size/) الحالي والاتجاه مع الإعدادات المسبقة القياسية؛ يساعد ذلك في توقع السلوك عند الطباعة والتصدير.

**هل هناك طريقة سريعة لمعرفة ما إذا كانت المخططات تشير إلى مصادر بيانات خارجية؟**

نعم. استعرض جميع [المخططات](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chart/)، وتفقد [مصدر البيانات](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chartdata/data_source_type/) الخاص بها، وحدد ما إذا كان البيانات داخلية أو قائمة على رابط، بما في ذلك الروابط المعطوبة.

**كيف يمكنني تقييم الشرائح "الثقيلة" التي قد تبطئ عملية العرض أو تصدير PDF؟**

لكل شريحة، احسب عدد الكائنات وابحث عن صور كبيرة، شفافية، ظلال، حركات، والوسائط المتعددة؛ ثم عيّن درجة تعقيد تقريبية لتحديد نقاط الاختناق المحتملة في الأداء.