---
title: إنشاء عروض تقديمية في Python عبر Java
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
description: "إنشاء عروض تقديمية في Python عبر Java باستخدام Aspose.Slides—إنشاء ملفات PPT و PPTX و ODP، والاستفادة من دعم OpenDocument، وحفظها برمجياً للحصول على نتائج موثوقة."
---
## **نظرة عامة**

توضح هذه المقالة كيفية إنشاء عرض تقديمي باستخدام Aspose.Slides for Python via Java، وإضافة شكل بنص إلى الشريحة الأولى، وحفظ النتيجة كملف PPTX. يتناول قسم الأسئلة الشائعة صيغ الإخراج، القوالب، حجم الشرائح، استخدام الذاكرة، الخيوط، الترخيص، التوقيعات الرقمية، ودعم VBA.

## **إنشاء عرض تقديمي**

إنشاء ملف PowerPoint من الصفر في Aspose.Slides for Python via Java سهل مثل إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/). يقوم المُنشئ تلقائيًا بتوفير مجموعة فارغة تحتوي على شريحة واحدة، مما يتيح لك لوحة رسم فورية للأشكال والنصوص والمخططات أو أي محتوى آخر يحتاجه تطبيقك. بمجرد تعديل تلك الشريحة — أو إضافة شريحة جديدة — يمكنك حفظ النتيجة بصيغة PPTX أو PPT القديمة أو حتى صيغ OpenDocument. يوضح المثال المختصر أدناه سير العمل هذا من خلال إضافة شكل بسيط إلى الشريحة الأولى.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
2. الحصول على الشريحة الأولى بواسطة الفهرس الخاص بها.
3. إضافة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) من النوع [ShapeType.Cloud](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapetype/#Cloud) باستخدام [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addAutoShape).
4. ضبط نص الشكل باستخدام [TextFrame.setText](https://reference.aspose.com/slides/ar/python-java/aspose.slides/textframe/#setText).
5. حفظ العرض التقديمي باستخدام [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) مع [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/#Pptx).

يتطلب المثال التالي وجود Aspose.Slides for Python via Java وبيئة تشغيل Java متوافقة. يبدأ تشغيل JVM إذا لم يكن قيد التشغيل، ويضيف شكل سحابة إلى الشريحة الأولى، ثم يحفظ العرض التقديمي:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# إنشاء عرض تقديمي به شريحة فارغة واحدة.
presentation = Presentation()
try:
    # احصل على الشريحة الأولى.
    slide = presentation.getSlides().get_Item(0)

    # أضف شكلاً على شكل سحابة واضبط نصه.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # احفظ العرض التقديمي كملف PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

النتيجة:

![العرض التقديمي الجديد](new_presentation.png)

## **الأسئلة الشائعة**

**ما الصيغ التي يمكنني حفظ عرض تقديمي جديد فيها؟**

يمكنك الحفظ إلى [PPTX, PPT, and ODP](/slides/ar/python-java/save-presentation/)، والتصدير إلى [PDF](/slides/ar/python-java/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/python-java/convert-powerpoint-to-xps/)، [HTML](/slides/ar/python-java/convert-powerpoint-to-html/)، [SVG](/slides/ar/python-java/render-slide-as-svg/)، و[images](/slides/ar/python-java/convert-powerpoint-to-png/)، من بين خيارات أخرى.

**هل يمكنني البدء من قالب (POTX/POTM) وحفظه كـ PPTX عادي؟**

نعم. حمّل القالب واحفظه بالصيغ المطلوبة؛ صيغ POTX/POTM/PPTM وغيرها [مدعومة](/slides/ar/python-java/supported-file-formats/).

**كيف يمكنني التحكم في حجم الشريحة/نسبة الأبعاد عند إنشاء عرض تقديمي؟**

حدد [حجم الشريحة](/slides/ar/python-java/slide-size/) (بما في ذلك القوالب مثل 4:3 و16:9 أو الأبعاد المخصصة) واختر طريقة تكبير المحتوى.

**بأي وحدات تُقاس الأحجام والإحداثيات؟**

بالنقاط: البوصة الواحدة تساوي 72 وحدة.

**كيف أتعامل مع عروض تقديمية ضخمة (مع العديد من ملفات الوسائط) لتقليل استهلاك الذاكرة؟**

استخدم [استراتيجيات إدارة BLOB](/slides/ar/python-java/manage-blob/)، قلل التخزين في الذاكرة عبر الاستفادة من الملفات المؤقتة، وفضل سير العمل القائم على الملفات على التدفقات الداخلية فقط.

**هل يمكنني إنشاء/حفظ عروض تقديمية بشكل متوازي؟**

لا يمكنك العمل على نفس نسخة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) من [عدة خيوط](/slides/ar/python-java/multithreading/). شغّل نسخًا منفصلة ومعزولة لكل خيط أو عملية.

**كيف أزيل العلامة المائية للنسخة التجريبية والقيود؟**

[تطبيق رخصة](/slides/ar/python-java/licensing/) مرة واحدة لكل عملية. يجب أن يبقى ملف XML الخاص بالرخصة دون تعديل، ويُفضل مزامنة إعداد الرخصة إذا كان هناك عدة خيوط.

**هل يمكنني توقيع ملف PPTX رقمياً؟**

نعم. [التوقيعات الرقمية](/slides/ar/python-java/digital-signature-in-powerpoint/) (الإضافة والتحقق) مدعومة للعرض التقديمي.

**هل تدعم العروض التقديمية الماكرو (VBA)؟**

نعم. يمكنك [إنشاء/تحرير مشاريع VBA](/slides/ar/python-java/presentation-via-vba/) وحفظ ملفات تمكين الماكرو مثل PPTM/PPSM.