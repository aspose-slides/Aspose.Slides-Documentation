---
title: تحديد الخطوط الافتراضية للعرض التقديمي في Python عبر Java
linktitle: الخط الافتراضي
type: docs
weight: 30
url: /ar/python-java/default-font/
keywords:
- خط افتراضي
- خط عادي
- خط طبيعي
- خط آسيوي
- تصدير PDF
- تصدير XPS
- تصدير صور
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تعيين الخطوط الافتراضية في Aspose.Slides لPython عبر Java لضمان تحويل PowerPoint (PPT, PPTX) وOpenDocument (ODP) بشكل صحيح إلى PDF وXPS والرسومات."
---
## **نظرة عامة**

تتيح لك Aspose.Slides تحديد الخطوط الافتراضية التي تُستخدم عند عرض تقديمي. هذا مفيد عند إنشاء صور مصغرة للشرائح أو تصدير عرض تقديمي إلى صيغ مثل PDF و XPS. يتم تكوين الخطوط الافتراضية عبر [LoadOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/) قبل تحميل العرض التقديمي.

طريقة [setDefaultRegularFont](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) تحدد الخط الافتراضي للنص العادي، بينما تحدد [setDefaultAsianFont](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) الخط الافتراضي للنص الآسيوي. بعد تعيين هذه الخيارات، يمكن تحميل العرض التقديمي وعرضه باستخدام الخطوط المحددة.

## **استخدام الخطوط الافتراضية لتقديم عرض تقديمي**

تسمح لك Aspose.Slides بتعيين الخطوط الافتراضية لعرض تقديمي إلى PDF أو XPS أو الصور المصغرة. يوضح هذا القسم كيفية تعريف الخطوط الافتراضية للنص العادي والنص الآسيوي باستخدام Aspose.Slides للغة Python عبر Java:

1. إنشاء مثال من [LoadOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/).
2. استخدم [setDefaultRegularFont](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) لتحديد الخط المطلوب. المثال التالي يستخدم Wingdings.
3. استخدم [setDefaultAsianFont](https://reference.aspose.com/slides/ar/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) لتحديد الخط المطلوب. المثال التالي أيضًا يستخدم Wingdings.
4. حمّل العرض التقديمي باستخدام [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) مع خيارات التحميل.
5. أنشئ الصورة المصغرة للشرائح، PDF، و XPS للتحقق من النتائج.

المثال التالي يطبق هذه الخطوات:

```python
from asposeslides.api import ImageFormat, LoadFormat, LoadOptions, Presentation, SaveFormat

# استخدم خيارات التحميل لتحديد الخطوط الافتراضية العادية والآسيوية.
load_options = LoadOptions(LoadFormat.Auto)
load_options.setDefaultRegularFont("Wingdings")
load_options.setDefaultAsianFont("Wingdings")

# تحميل العرض التقديمي.
presentation = Presentation("DefaultFonts.pptx", load_options)
try:
    # إنشاء صورة مصغرة للشريحة.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # حفظ الصورة إلى القرص.
        slide_image.save("output.png", ImageFormat.Png)
    finally:
        slide_image.dispose()

    # إنشاء ملف PDF.
    presentation.save("output_out.pdf", SaveFormat.Pdf)

    # إنشاء مستند XPS.
    presentation.save("output_out.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

## **الأسئلة الشائعة**

**ما الذي تؤثر عليه الخطوط الافتراضية العادية والآسيوية بالضبط—هل هي فقط على التصدير، أم أيضًا على الصور المصغرة، PDF، XPS، HTML، و SVG؟**

إنها تشارك في خط الأنابيب للعرض لجميع المخرجات المدعومة. وهذا يشمل صور مصغرة للشرائح، [PDF](/slides/ar/python-java/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/python-java/convert-powerpoint-to-xps/)، [الصور النقطية](/slides/ar/python-java/convert-powerpoint-to-png/)، [HTML](/slides/ar/python-java/convert-powerpoint-to-html/)، و [SVG](/slides/ar/python-java/render-a-slide-as-an-svg-image/)، لأن Aspose.Slides يستخدم نفس منطق التخطيط وحل الرموز عبر هذه الأهداف.

**هل تُطبق الخطوط الافتراضية عند مجرد قراءة وحفظ ملف PPTX دون أي عرض؟**

لا. الخطوط الافتراضية تكون ذات أهمية عندما يجب قياس النص ورسمه. حفظ المفتوح المباشر للعرض لا يغيّر تشغيلات الخط المخزنة أو بنية الملف. الخطوط الافتراضية تُستَخدم أثناء العمليات التي تعرض أو تعيد تنسيق النص.

**إذا أضفت مجلدات خطوط خاصة بي أو زودت الخطوط من الذاكرة، هل ستُؤخذ في الاعتبار عند اختيار الخطوط الافتراضية؟**

نعم. [مصادر الخطوط المخصصة](/slides/ar/python-java/custom-font/) توسّع كتالوج العائلات والرموز المتاحة التي يمكن للمحرك استخدامها. الخطوط الافتراضية وأي [قواعد احتياطيّة](/slides/ar/python-java/fallback-font/) ستحلّ مقابل تلك المصادر أولاً، مما يوفّر تغطية أكثر موثوقية على الخوادم وفي الحاويات.

**هل ستؤثر الخطوط الافتراضية على مقاييس النص (التقارب، التقدم) وبالتالي على فواصل الأسطر واللف؟**

نعم. تغيير الخط يغيّر مقاييس الرموز ويمكن أن يغيّر فواصل الأسطر، اللف، والصفحات أثناء العرض. لتحقيق استقرار التخطيط، [قم بتضمين الخطوط الأصلية](/slides/ar/python-java/embedded-font/) أو اختر عائلات افتراضية واحتياطية متوافقة من الناحية المترية.

**هل هناك فائدة من تعيين الخطوط الافتراضية إذا كانت جميع الخطوط المستخدمة في العرض مضمّنة؟**

غالبًا ليس ضروريًا، لأن [الخطوط المضمّنة](/slides/ar/python-java/embedded-font/) تضمن بالفعل مظهرًا متسقًا. لا تزال الخطوط الافتراضية مفيدة كشبكة أمان للأحرف غير المغطاة في المجموعة المضمّنة أو عندما يخلط الملف بين نص مضمّن وغير مضمّن.