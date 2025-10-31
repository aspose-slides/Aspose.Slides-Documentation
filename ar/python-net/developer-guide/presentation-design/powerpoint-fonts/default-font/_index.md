---
title: تخصيص الخطوط الافتراضية في العروض التقديمية باستخدام Python
linktitle: الخط الافتراضي
type: docs
weight: 30
url: /ar/python-net/default-font/
keywords:
- الخط الافتراضي
- الخط العادي
- الخط الطبيعي
- الخط الآسيوي
- تصدير PDF
- تصدير XPS
- تصدير الصور
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعيين الخطوط الافتراضية في Aspose.Slides للغة Python لضمان التحويل السليم لعروض PowerPoint (PPT، PPTX) وOpenDocument (ODP) إلى PDF وXPS والصور."
---

## **استخدام الخطوط الافتراضية لتصوير العرض التقديمي**
تتيح لك Aspose.Slides تعيين الخط الافتراضي لتصوير العرض إلى PDF أو XPS أو الصور المصغرة. تُظهر هذه المقالة كيفية تعريف **DefaultRegularFont** و**DefaultAsianFont** لاستخدامهما كخطوط افتراضية. يرجى اتباع الخطوات أدناه لتحميل الخطوط من دلائل خارجية باستخدام Aspose.Slides للغة Python عبر واجهة برمجة تطبيقات .NET:

1. إنشاء كائن من **LoadOptions**.
2. تعيين **DefaultRegularFont** إلى الخط المطلوب. في المثال التالي، استخدمت خط **Wingdings**.
3. تعيين **DefaultAsianFont** إلى الخط المطلوب. استخدمت خط **Wingdings** في العينة التالية.
4. تحميل العرض باستخدام **Presentation** وتحديد خيارات التحميل.
5. الآن، توليد الصورة المصغرة للشريحة، وملف PDF، وملف XPS للتحقق من النتائج.

التنفيذ الوارد أدناه:

```py
import aspose.slides as slides

# استخدم خيارات التحميل لتحديد الخطوط الافتراضية العادية والآسيوية# استخدم خيارات التحميل لتحديد الخطوط الافتراضية العادية والآسيوية
loadOptions = slides.LoadOptions(slides.LoadFormat.AUTO)
loadOptions.default_regular_font = "Wingdings"
loadOptions.default_asian_font = "Wingdings"

# تحميل العرض
with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as pptx:
    # توليد صورة مصغرة للشريحة
    with pptx.slides[0].get_image(1, 1) as img:
        img.save("output_out.png", slides.ImageFormat.PNG)

    # توليد PDF
    pptx.save("output_out.pdf", slides.export.SaveFormat.PDF)

    # توليد XPS
    pptx.save("output_out.xps", slides.export.SaveFormat.XPS)
```

## **الأسئلة المتداولة**

**ما الذي تؤثر عليه بالضبط المتغيرات `default_regular_font` و`default_asian_font` — هل هي مجرد تصدير أم تشمل الصور المصغرة، PDF، XPS، HTML وSVG أيضًا؟**

إنها تشارك في خط أنابيب التصوير لجميع المخرجات المدعومة. يشمل ذلك الصور المصغرة للشرائح،[PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/)،[XPS](/slides/ar/python-net/convert-powerpoint-to-xps/)،[صور نقطية](/slides/ar/python-net/convert-powerpoint-to-png/)،[HTML](/slides/ar/python-net/convert-powerpoint-to-html/)، و[SVG](/slides/ar/python-net/render-a-slide-as-an-svg-image/)، لأن Aspose.Slides يستخدم نفس منطق التخطيط وحل الحروف عبر هذه الأهداف.

**هل تُطبق الخطوط الافتراضية عند قراءة وحفظ ملف PPTX دون أي تصوير؟**

لا. تكون الخطوط الافتراضية ذات أثر عندما يلزم قياس النص ورسمه. عملية حفظ عرض تقديمي مفتوح ببساطة لا تغيّر سلاسل الخط المخزنة أو بنية الملف. تُستَخدم الخطوط الافتراضية أثناء العمليات التي تُصوِّر أو تُعيد تدفق النص.

**إذا أضفت مجلدات خطوط خاصة أو وفّرت خطوطًا من الذاكرة، هل ستؤخذ في الاعتبار عند اختيار الخطوط الافتراضية؟**

نعم. [مصادر الخطوط المخصصة](/slides/ar/python-net/custom-font/) توسّع كتالوج العائلات والحروف المتاحة التي يمكن للمحرك استخدامها. الخطوط الافتراضية وأي [قواعد احتياطية](/slides/ar/python-net/fallback-font/) ستُطبّق أولاً على تلك المصادر، مما يوفّر تغطية أكثر موثوقية على الخوادم وفي الحاويات.

**هل ستؤثر الخطوط الافتراضية على قياسات النص (التحريك، التقدم) وبالتالي على فواصل الأسطر واللف؟**

نعم. تغيير الخط يغيّر قياسات الحروف وقد يغيّر فواصل الأسطر واللف وترقيم الصفحات أثناء التصوير. لتحقيق استقرار التخطيط، يُنصَح بـ[تضمين الخطوط الأصلية](/slides/ar/python-net/embedded-font/) أو اختيار عائلات افتراضية واحتياطية متوافقة من حيث القياسات.

**هل هناك فائدة من تعيين الخطوط الافتراضية إذا كانت جميع الخطوط المستخدمة في العرض مضمَّنة؟**

غالبًا لا تكون ضرورية، لأن [الخطوط المضمَّنة](/slides/ar/python-net/embedded-font/) تضمن المظهر المتسق بالفعل. لا تزال الخطوط الافتراضية مفيدة كشبكة أمان للأحرف التي لا تغطيها المجموعة المضمَّنة أو عندما يخلط الملف بين نص مضمَّن وغير مضمَّن.