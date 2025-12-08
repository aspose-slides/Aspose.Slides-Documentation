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
description: "استكشف الشرائح والبنية والبيانات الوصفية في عروض PowerPoint و OpenDocument باستخدام بايثون للحصول على رؤى أسرع وتدقيق محتوى أكثر ذكاءً."
---

تتيح لك Aspose.Slides for Python عبر .NET فحص عرض تقديمي لمعرفة خصائصه وفهم سلوكه. 

{{% alert title="Info" color="info" %}} 

تحتوي الفئتان [PresentationInfo](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/) و[DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) على الخصائص والطرق المستخدمة في العمليات هنا.

{{% /alert %}} 

## **التحقق من تنسيق العرض التقديمي**

قبل العمل على عرض تقديمي، قد ترغب في معرفة ما هو التنسيق (PPT، PPTX، ODP، وغيرها) الذي يكون فيه العرض حاليًا.

يمكنك التحقق من تنسيق العرض التقديمي دون تحميله. شاهد هذا الكود Python:
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

يعرض لك هذا الكود Python كيفية الحصول على خصائص العرض التقديمي (معلومات حول العرض):
```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```


قد ترغب في الاطلاع على [الخصائص تحت فئة DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/#properties) الفئة.

## **تحديث خصائص العرض التقديمي**

توفر Aspose.Slides الطريقة [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) التي تسمح لك بإجراء تغييرات على خصائص العرض التقديمي.

لنفترض أن لدينا عرض PowerPoint مع خصائص المستند الموضحة أدناه.

![خصائص المستند الأصلية لعرض PowerPoint](input_properties.png)

يعرض لك مثال الكود هذا كيفية تعديل بعض خصائص العرض:
```py
file_name = "sample.pptx"

info = PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```


تظهر نتائج تغيير خصائص المستند أدناه.

![خصائص المستند المعدلة لعرض PowerPoint](output_properties.png)

## **روابط مفيدة**

للحصول على مزيد من المعلومات حول عرض تقديمي وسماته الأمنية، قد تجد الروابط التالية مفيدة:

- [التحقق مما إذا كان العرض التقديمي مشفرًا](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [التحقق مما إذا كان العرض التقديمي محميًا من الكتابة (للقراءة فقط)](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [التحقق مما إذا كان العرض التقديمي محميًا بكلمة مرور قبل تحميله](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [تأكيد كلمة المرور المستخدمة لحماية العرض التقديمي](https://docs.aspose.com/slides/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **الأسئلة المتكررة**

**كيف يمكنني التحقق مما إذا كان الخطوط مدمجة وأي منها؟**

ابحث عن [معلومات الخطوط المدمجة](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) على مستوى العرض، ثم قارن تلك الإدخالات مع مجموعة [الخطوط المستخدمة فعليًا عبر المحتوى](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_fonts/) لتحديد أي الخطوط ضرورية للعرض.

**كيف يمكنني بسرعة معرفة ما إذا كان الملف يحتوي على شرائح مخفية وعددها؟**

تجول في [مجموعة الشرائح](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) وتفقد علامة [الرؤية للشرائح](https://reference.aspose.com/slides/python-net/aspose.slides/slide/hidden/).

**هل يمكنني اكتشاف ما إذا تم استخدام حجم واتجاه شريحة مخصصين، وما إذا كانا يختلفان عن الإعدادات الافتراضية؟**

نعم. قارن [حجم الشريحة](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slide_size/) الحالي والاتجاه مع الإعدادات المسبقة القياسية؛ يساعد ذلك في توقع السلوك عند الطباعة والتصدير.

**هل هناك طريقة سريعة لمعرفة ما إذا كانت المخططات تشير إلى مصادر بيانات خارجية؟**

نعم. استعرض جميع [المخططات](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/)، تحقق من [مصدر البيانات](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) الخاص بها، ولاحظ ما إذا كانت البيانات داخلية أو مستندة إلى روابط، بما في ذلك أي روابط مكسورة.

**كيف يمكنني تقييم الشرائح "الثقيلة" التي قد تبطئ عملية العرض أو تصدير PDF؟**

لكل شريحة، احسب عدد الكائنات وابحث عن صور كبيرة، شفافية، ظلال، حركات، ووسائط متعددة؛ ثم أعطِ درجة تعقيد تقريبية لتحديد النقاط التي قد تؤثر على الأداء.