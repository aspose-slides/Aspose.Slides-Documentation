---
title: إنشاء عروض تقديمية في بايثون عبر جافا
linktitle: إنشاء عرض تقديمي
type: docs
weight: 10
url: /ar/python-java/create-presentation/
keywords:
- إنشاء عرض تقديمي
- عرض تقديمي جديد
- إنشاء PPT
- PPT جديد
- إنشاء PPTX
- PPTX جديد
- إنشاء ODP
- ODP جديد
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إنشاء عروض تقديمية في بايثون عبر جافا باستخدام Aspose.Slides—إنشاء ملفات PPT و PPTX و ODP، والاستفادة من دعم OpenDocument، وحفظها برمجيًا للحصول على نتائج موثوقة."
---
## **نظرة عامة**

تُظهر هذه المقالة كيفية إنشاء عرض تقديمي باستخدام Aspose.Slides for Python via Java، وإضافة شكل يحتوي على نص إلى الشريحة الأولى، وحفظ النتيجة كملف PPTX. تغطي الأسئلة المتكررة صيغ الإخراج، القوالب، حجم الشريحة، استخدام الذاكرة، الخيوط، الترخيص، التوقيعات الرقمية، ودعم VBA.

## **إنشاء عرض تقديمي**

إنشاء ملف PowerPoint من الصفر في Aspose.Slides for Python via Java سهل بقدر إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) . يُوفر المُنشئ تلقائيًا مجموعة فارغة بشريحة واحدة، مما يمنحك لوحة رسم فورية للأشكال والنصوص والرسوم البيانية أو أي محتوى آخر يحتاجه تطبيقك. بمجرد تعديل تلك الشريحة أو إضافة شريحات جديدة، يمكنك حفظ النتيجة كملف PPTX أو PPT قديم أو حتى صيغ OpenDocument. يوضح المثال القصير أدناه سير العمل هذا بإضافة شكل بسيط إلى الشريحة الأولى.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
1. الحصول على الشريحة الأولى حسب الفهرس الخاص بها.
1. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) من النوع [ShapeType.Cloud](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapetype/#Cloud) باستخدام [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addAutoShape).
1. تعيين نص الشكل باستخدام [TextFrame.setText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/#setText).
1. حفظ العرض باستخدام [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) مع [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/#Pptx).

المثال التالي يتطلب Aspose.Slides for Python via Java وبيئة تشغيل Java متوافقة. يبدأ JVM إذا لم يكن قيد التشغيل، يضيف شكل سحابة إلى الشريحة الأولى، ويحفظ العرض:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# إنشاء عرض تقديمي بشريحة فارغة واحدة.
presentation = Presentation()
try:
    # الحصول على الشريحة الأولى.
    slide = presentation.getSlides().get_Item(0)

    # إضافة شكل سحابة وتعيين نصه.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # حفظ العرض التقديمي كملف PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![العرض الجديد](new_presentation.png)

## **الأسئلة المتكررة**

**ما الصيغ التي يمكنني حفظ عرض تقديمي جديد فيها؟**

يمكنك الحفظ إلى [PPTX, PPT, و ODP](/slides/ar/python-java/save-presentation/)، وتصدير إلى [PDF](/slides/ar/python-java/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/python-java/convert-powerpoint-to-xps/)، [HTML](/slides/ar/python-java/convert-powerpoint-to-html/)، [SVG](/slides/ar/python-java/render-slide-as-svg/)، و[الصور](/slides/ar/python-java/convert-powerpoint-to-png/)، من بين أخرى.

**هل يمكنني البدء من قالب (POTX/POTM) وحفظه كملف PPTX عادي؟**

نعم. حمّل القالب واحفظه بالصيغة المطلوبة؛ الصيغ POTX/POTM/PPTM وما شابهها [مدعومة](/slides/ar/python-java/supported-file-formats/).

**كيف يمكنني التحكم في حجم الشريحة/نسبة العرض إلى الارتفاع عند إنشاء عرض تقديمي؟**

قم بتعيين [حجم الشريحة](/slides/ar/python-java/slide-size/) (بما في ذلك القوالب مثل 4:3 و 16:9 أو الأبعاد المخصصة) واختر كيفية مقياس المحتوى.

**بأي وحدات تُقاس الأحجام والإحداثيات؟**

بالنقاط: 1 بوصة تعادل 72 وحدة.

**كيف يمكنني التعامل مع عروض تقديمية كبيرة جدًا (مع العديد من ملفات الوسائط) لتقليل استهلاك الذاكرة؟**

استخدم [استراتيجيات إدارة BLOB](/slides/ar/python-java/manage-blob/)، قَصّ التخزين في الذاكرة عن طريق الاستفادة من الملفات المؤقتة، وفضّل سير عمل قائم على الملفات بدلاً من التدفقات التي تُحفظ بالكامل في الذاكرة.

**هل يمكنني إنشاء/حفظ العروض التقديمية بشكل متوازي؟**

لا يمكنك العمل على نفس المثيل من [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) من خلال [عدة خيوط](/slides/ar/python-java/multithreading/). شغّل مثيلات منفصلة ومعزولة لكل خيط أو عملية.

**كيف يمكنني إزالة العلامة المائية التجريبية والقيود؟**

[قم بتطبيق رخصة](/slides/ar/python-java/licensing/) مرة واحدة لكل عملية. يجب أن يبقى ملف XML الخاص بالرخصة غير معدل، ويجب مزامنة إعداد الرخصة إذا تم استعمال عدة خيوط.

**هل يمكنني توقيع ملف PPTX الذي أنشئه رقمياً؟**

نعم. [التوقيعات الرقمية](/slides/ar/python-java/digital-signature-in-powerpoint/) (الإضافة والتحقق) مدعومة للعروض التقديمية.

**هل الماكرو (VBA) مدعوم في العروض التقديمية التي تم إنشاؤها؟**

نعم. يمكنك [إنشاء/تحرير مشاريع VBA](/slides/ar/python-java/presentation-via-vba/) وحفظ ملفات تمكين الماكرو مثل PPTM/PPSM.