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
description: "اكتشف الشرائح والبنية والبيانات الوصفية في عروض PowerPoint وOpenDocument باستخدام بايثون للحصول على رؤى أسرع وتدقيق محتوى أكثر ذكاءً."
---

Aspose.Slides for Python عبر .NET يتيح لك فحص عرض تقديمي لمعرفة خصائصه وفهم سلوكه.

{{% alert title="Info" color="info" %}} 

الفئات [PresentationInfo](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/) و [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) تحتوي على الخصائص والأساليب المستخدمة في العمليات هنا.

{{% /alert %}} 

## **التحقق من تنسيق العرض التقديمي**

قبل العمل على عرض تقديمي، قد ترغب في معرفة أي تنسيق (PPT، PPTX، ODP، وغيرها) يكون عليه العرض في الوقت الحالي.

يمكنك التحقق من تنسيق العرض دون تحميله. انظر هذا الكود بلغة بايثون:

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

هذا الكود بلغة بايثون يوضح لك كيف تحصل على خصائص العرض (معلومات حول العرض):

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

قد تريد الاطلاع على [الخصائص ضمن فئة DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/#properties).

## **تحديث خصائص العرض التقديمي**

Aspose.Slides يوفر طريقة [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) التي تسمح لك بإجراء تغييرات على خصائص العرض.

لنفترض أن لدينا عرض PowerPoint يحتوي على خصائص المستند الموضحة أدناه.

![الخصائص الأصلية للمستند في عرض PowerPoint](input_properties.png)

هذا المثال يوضح لك كيفية تعديل بعض خصائص العرض:

```py
file_name = "sample.pptx"

info = PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

نتائج تغيير خصائص المستند موضحة أدناه.

![الخصائص المعدلة للمستند في عرض PowerPoint](output_properties.png)

## **روابط مفيدة**

للحصول على مزيد من المعلومات حول العرض وسماته الأمنية، قد تجد هذه الروابط مفيدة:

- [التحقق مما إذا كان العرض مشفرًا](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [التحقق مما إذا كان العرض محميًا ضد الكتابة (للقراءة فقط)](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [التحقق مما إذا كان العرض محميًا بكلمة مرور قبل تحميله](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [تأكيد كلمة المرور المستخدمة لحماية العرض](https://docs.aspose.com/slides/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **الأسئلة الشائعة**

**كيف يمكنني التحقق مما إذا كانت الخطوط مضمّنة وأيها؟**

ابحث عن معلومات [الخطوط المضمّنة](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) على مستوى العرض، ثم قارن هذه الإدخالات مع مجموعة [الخطوط المستخدمة فعليًا عبر المحتوى](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_fonts/) لتحديد الخطوط الضرورية للعرض.

**كيف يمكنني بسرعة معرفة ما إذا كان الملف يحتوي على شرائح مخفية وعددها؟**

تجول عبر [مجموعة الشرائح](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) وتفحص علامة [الرؤية](https://reference.aspose.com/slides/python-net/aspose.slides/slide/hidden/) لكل شريحة.

**هل يمكنني الكشف عما إذا كان تم استخدام حجم شريحة مخصص واتجاهه، وما إذا كانا يختلفان عن القيم الافتراضية؟**

نعم. قارن حجم [الشريحة الحالي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slide_size/) والاتجاه بالإعدادات المبدئية؛ يساعد ذلك على توقع السلوك أثناء الطباعة والتصدير.

**هل توجد طريقة سريعة لرؤية ما إذا كانت المخططات تشير إلى مصادر بيانات خارجية؟**

نعم. استعرض جميع [المخططات](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/)، وتفحص [مصدر البيانات](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) لكل منها، وحدد ما إذا كان البيانات داخلية أم مرتبطة برابط، بما في ذلك الروابط المعطلة.

**كيف يمكنني تقييم "الشرائح الثقيلة" التي قد تبطئ العرض أو تصدير PDF؟**

لكل شريحة، احصِ عدد الكائنات وابحث عن صور كبيرة، شفافية، ظلال، حركات، ووسائط متعددة؛ أعطِها درجة تعقيد تقريبية لتحديد نقاط الأداء المحتملة.