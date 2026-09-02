---
title: تحويل عروض PowerPoint التقديمية إلى XML باستخدام Python
linktitle: PowerPoint إلى XML
type: docs
weight: 145
url: /ar/python-net/convert-powerpoint-to-xml/
keywords:
- تحويل PowerPoint إلى XML
- تحويل العرض التقديمي إلى XML
- PPT إلى XML
- PPTX إلى XML
- ODP إلى XML
- عرض PowerPoint XML
- SaveFormat.XML
- حفظ العرض التقديمي كـ XML
- تصدير العرض التقديمي إلى XML
- تدفق XML
- Python
- Aspose.Slides
description: "تحويل عروض PowerPoint و OpenDocument التقديمية إلى ملفات أو تدفقات PowerPoint XML باستخدام Python مع Aspose.Slides."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for Python via .NET تحويل عروض PowerPoint التقديمية إلى تنسيق PowerPoint XML Presentation. يكون إخراج XML مفيدًا عندما تحتاج إلى تمثيل نصي لفحص هيكل العرض التقديمي، استكشاف مشكلات المستندات المولدة، مقارنة المخرجات في الاختبارات المؤتمتة، أو التكامل مع سير عمل يستهلك XML بدلاً من حزمة عرض تقديمي.

استخدم طريقة [Presentation.save](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/save/) مع القيمة `XML` من تعداد [SaveFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/saveformat/). يمكنك كتابة النتيجة مباشرةً إلى ملف أو إلى تدفق.

{{% alert color="info" title="Note" %}}
`SaveFormat.XML` ينشئ PowerPoint XML Presentation. لا يقوم باستخراج الأجزاء الفردية من Office Open XML المخزنة داخل حزمة PPTX. إذا كنت تحتاج إلى الأجزاء الدقيقة لحزمة PPTX، مثل `ppt/presentation.xml` أو ملفات XML للشرائح الفردية، فافحص حزمة PPTX نفسها.
{{% /alert %}}

## **تحويل عرض تقديمي إلى ملف XML**

حمّل عرضًا تقديميًا مصدرًا باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/)، ثم مرّر مسار الإخراج و `SaveFormat.XML` إلى [Presentation.save](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/save/). يمكن أن يكون المصدر بأي تنسيق عرض مدعوم للتحميل، مثل PPT أو PPTX أو ODP.

المثال التالي يحول عرضًا تقديميًا بصيغة PPTX إلى ملف XML:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.xml", slides.export.SaveFormat.XML)
```

## **كتابة إخراج XML إلى تدفق**

استخدم النسخة المتعددة للدفعات من [Presentation.save](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/save/) عندما يجب أن يبقى XML في الذاكرة أو يتم تمريره إلى مكوّن آخر، مثل خدمة ويب، موفر تخزين، أو أنابيب معالجة XML. المثال التالي يكتب النتيجة إلى تدفق [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) ويعيد تهيئته للقراءة اللاحقة:

```py
from io import BytesIO

import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    xml_stream = BytesIO()
    presentation.save(xml_stream, slides.export.SaveFormat.XML)
    xml_stream.seek(0)

    # مرر xml_stream إلى المكوّن التالي في سير العمل.
```

## **مقارنة XML مع تنسيقات العرض والتصدير**

اختر تنسيق الإخراج بناءً على كيفية استخدام النتيجة:

| التنسيق | الإخراج | الاستخدام النموذجي |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | عرض تقديمي PowerPoint XML | فحص الهيكل، استكشاف المشكلات، مقارنة المخرجات المولدة، والتكامل القائم على XML |
| PPT (`.ppt`) | ملف عرض تقديمي ثنائي قديم | التوافق مع سير عمل PowerPoint الأقدم |
| PPTX (`.pptx`) | حزمة Office Open XML تحتوي على عدة أجزاء | تحرير PowerPoint العادي وتبادل العروض التقديمية |
| PDF أو TIFF | صفحات ذات تخطيط ثابت أو صورة متعددة الصفحات | العرض، الطباعة، والأرشفة |
| PNG أو JPEG أو SVG | تمثيل مرسوم لشرائح فردية | مصغرات، معاينات، وأصول الصور |
| HTML أو HTML5 | إخراج عرض تقديمي موجه للويب | عرض المتصفح والنشر على الويب |

على عكس PPT و PPTX، يُقصد بإخراج XML أساسًا للفحص وسير عمل موجه للبيانات. وعلى عكس PDF و TIFF و HTML وتنسيقات صور الشرائح، يمثل بيانات العرض التقديمي بدلاً من عرض الشرائح كصفحات أو أصول بصرية. تُظهر جدول [تنسيقات الملفات المدعومة](/slides/ar/python-net/supported-file-formats/) أن PowerPoint XML Presentation هو تنسيق للحفظ فقط، لذا لا تستخدمه عندما يتعين على سير العمل تحميل الملف المُصدَّر مرة أخرى إلى Aspose.Slides للتحرير المستمر.

## **الأسئلة الشائعة**

**هل `SaveFormat.XML` هو نفسه حفظ ملف PPTX؟**

لا. PPTX هي حزمة تحتوي على عدة أجزاء من Office Open XML، بينما `SaveFormat.XML` ينشئ ملف PowerPoint XML Presentation.

**هل يمكنني حفظ إخراج XML دون إنشاء ملف على القرص؟**

نعم. مرّر تدفقًا قابلًا للكتابة إلى [Presentation.save](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/save/). على سبيل المثال، استخدم تدفق [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) للمعالجة في الذاكرة.

**هل يمكن لـ Aspose.Slides تحميل ملف XML المُصدَّر مرة أخرى؟**

لا. عرض PowerPoint XML Presentation مدعوم حاليًا للحفظ فقط وليس للتحميل. استخدم PPTX أو تنسيق عرض آخر مدعوم عندما تحتاج إلى تحرير متردد.

**هل تقوم عملية تحويل XML بعرض كل شريحة كصفحة أو صورة؟**

لا. تحويل XML يكتب بيانات عرض هيكلية. استخدم PDF أو TIFF للإخراج الموجه للصفحات، أو PNG أو JPEG أو SVG لصور الشرائح الفردية.