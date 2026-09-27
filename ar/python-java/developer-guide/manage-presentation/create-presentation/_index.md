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
description: "إنشاء عروض تقديمية في Python عبر Java باستخدام Aspose.Slides—إنشاء ملفات PPT و PPTX و ODP، الاستفادة من دعم OpenDocument، وحفظها برمجيًا للحصول على نتائج موثوقة."
---
## **نظرة عامة**

توضح هذه المقالة كيفية إنشاء عرض تقديمي باستخدام Aspose.Slides للـ Python عبر Java، وإضافة شكل يحتوي على نص إلى الشريحة الأولى، وحفظ النتيجة كملف PPTX. تغطي الأسئلة الشائعة تنسيقات الإخراج، القوالب، حجم الشرائح، استهلاك الذاكرة، الخيوط، الترخيص، التوقيعات الرقمية، ودعم VBA.

قبل البدء، قم بتثبيت Python وJDK وJPype وAspose.Slides للـ Python عبر Java. راجع [التثبيت](/slides/ar/python-java/installation/) للحصول على الخطوات على Windows وLinux وmacOS.

## **إنشاء عرض تقديمي**

إنشاء ملف PowerPoint من الصفر في Aspose.Slides للـ Python عبر Java سهل مثل إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/). يقوم المُنشئ تلقائيًا بتوفير مجموعة فارغة تحتوي على شريحة واحدة، مما يمنحك لوحة رسم فورية للأشكال والنصوص والمخططات أو أي محتوى آخر تحتاجه تطبيقاتك. بعد تعديل تلك الشريحة—أو إضافة شرائح جديدة—يمكنك حفظ النتيجة كـ PPTX أو PPT التقليدي أو حتى تنسيقات OpenDocument. يوضح نموذج الشيفرة القصير أدناه هذا سير العمل بإضافة شكل بسيط إلى الشريحة الأولى.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
1. الحصول على الشريحة الأولى حسب فهرسها، 0.
1. إضافة [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) من النوع [ShapeType.Cloud](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/#Cloud) باستخدام [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape).
1. تعيين نص الشكل باستخدام [TextFrame.setText](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#setText).
1. حفظ العرض التقديمي باستخدام [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) مع [SaveFormat.Pptx](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/#Pptx).

المثال التالي يبدأ آلة الافتراضية لجافا (JVM) إذا لم تكن قيد التشغيل، ويضيف شكل سحابة بنص إلى الشريحة الأولى، ثم يحفظ العرض التقديمي. احفظه كـ *create_presentation.py*:

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

شغِّل البرنامج النصي في البيئة التي قمت فيها بتثبيت الحزم:

```sh
python create_presentation.py
```

زاوية السحابة العلوية اليسرى تبعد 20 نقطة عن حواف الشريحة اليسرى والعلوية، وتكون السحابة بعرض 200 نقطة وارتفاع 80 نقطة. يحفظ البرنامج النصي *new_presentation.pptx* في دليل العمل الحالي، مع شريحة واحدة تحتوي على السحابة ونصها. تستمر JVM في العمل حتى ينتهي عملية Python؛ راجع [Limitations and API Differences](/slides/ar/python-java/limitations-and-api-differences/#import-the-library). بدون ترخيص، يضيف Aspose.Slides صندوق نص علامة مائية تقييم إلى كل شريحة يتم حفظها؛ راجع [Licensing](/slides/ar/python-java/licensing/).

النتيجة:

![العرض التقديمي الجديد](new_presentation.png)

## **الأسئلة الشائعة**

**ما التنسيقات التي يمكنني حفظ عرض تقديمي جديد إليها؟**

يمكنك الحفظ بصيغة [PPTX, PPT, وODP](/slides/ar/python-java/save-presentation/)، والتصدير إلى [PDF](/slides/ar/python-java/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/python-java/convert-powerpoint-to-xps/)، [HTML](/slides/ar/python-java/convert-powerpoint-to-html/)، [SVG](/slides/ar/python-java/render-a-slide-as-an-svg-image/)، و[الصور](/slides/ar/python-java/convert-powerpoint-to-png/)، من بين أخرى.

**هل يمكنني البدء من قالب (POTX/POTM) وحفظه كملف PPTX عادي؟**

نعم. حمّل القالب واحفظه بالتنسيق المطلوب؛ تُدعم صيغ POTX/POTM/PPTM وما شابهها [في هذا القسم](/slides/ar/python-java/supported-file-formats/).

**كيف أتحكم في حجم الشريحة / نسبة العرض إلى الارتفاع عند إنشاء عرض تقديمي؟**

حدد [حجم الشريحة](/slides/ar/python-java/slide-size/) (بما في ذلك الإعدادات المسبقة مثل 4:3 و16:9 أو الأبعاد المخصصة) واختر طريقة تكبير المحتوى.

**بأي وحدات تُقاس الأحجام والإحداثيات؟**

بالنقاط: البوصة الواحدة تساوي 72 وحدة.

**كيف أتعامل مع عروض تقديمية ضخمة (مع الكثير من ملفات الوسائط) لتقليل استهلاك الذاكرة؟**

استخدم [استراتيجيات إدارة BLOB](/slides/ar/python-java/manage-blob/)، قلل التخزين في الذاكرة باستخدام ملفات مؤقتة، وفضّل سير العمل القائم على الملفات على التيارات الداخلية فقط.

**هل يمكنني إنشاء/حفظ عروض تقديمية بشكل متوازي؟**

لا يمكنك تعديل نفس كائن [Presentation] من [عدة خيوط](/slides/ar/python-java/multithreading/). شغّل نسخًا منفصلة ومعزولة لكل خيط أو عملية.

**كيف أزيل علامة الماء التجريبية والقيود؟**

[طبق ترخيص](/slides/ar/python-java/licensing/) مرة واحدة لكل عملية. يجب أن يبقى ملف الترخيص XML غير معدل، ويجب مزامنة إعداد الترخيص إذا شاركت خيوط متعددة.

**هل يمكنني توقيع PPTX الذي أنشئه رقميًا؟**

نعم. تُدعم [التوقيعات الرقمية](/slides/ar/python-java/digital-signature-in-powerpoint/) (الإضافة والتحقق) للعروض التقديمية.

**هل تدعم العروض التقديمية التي تم إنشاؤها وحدات ماكرو (VBA)؟**

نعم. يمكنك [إنشاء/تعديل مشاريع VBA](/slides/ar/python-java/presentation-via-vba/) وحفظ ملفات تمكين الماكرو مثل PPTM/PPSM.