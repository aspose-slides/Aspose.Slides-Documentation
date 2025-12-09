---
title: تخصيص الخطوط الافتراضية في العروض التقديمية باستخدام بايثون
linktitle: الخط الافتراضي
type: docs
weight: 30
url: /ar/python-net/default-font/
keywords:
- الخط الافتراضي
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
- Aspose.Slides
description: "قم بتعيين الخطوط الافتراضية في Aspose.Slides لـ Python لضمان التحويل الصحيح لعروض PowerPoint (PPT، PPTX) و OpenDocument (ODP) إلى PDF و XPS والصور."
---

## **استخدام الخطوط الافتراضية لتصيير العرض التقديمي**
Aspose.Slides يتيح لك ضبط الخط الافتراضي لتصيير العرض إلى PDF أو XPS أو مصغرات. يوضح هذا المقال كيف يتم تعريف DefaultRegular Font و DefaultAsian Font لاستخدامهما كخطوط افتراضية. يرجى اتباع الخطوات أدناه لتحميل الخطوط من أدلة خارجية باستخدام Aspose.Slides for Python عبر .NET API:

1. إنشاء مثيل من LoadOptions.
2. ضبط DefaultRegularFont إلى الخط المطلوب. في المثال التالي، استخدمت Wingdings.
3. ضبط DefaultAsianFont إلى الخط المطلوب. استخدمت Wingdings في العينة التالية.
4. تحميل العرض باستخدام Presentation وتعيين خيارات التحميل.
5. الآن، إنشاء مصغرة الشريحة، PDF و XPS للتحقق من النتائج.

التنفيذ المذكور أعلاه موضح أدناه.
```py
import aspose.slides as slides

# استخدم خيارات التحميل لتحديد الخطوط الافتراضية العادية والآسيوية
loadOptions = slides.LoadOptions(slides.LoadFormat.AUTO)
loadOptions.default_regular_font = "Wingdings"
loadOptions.default_asian_font = "Wingdings"

# تحميل العرض التقديمي
with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as pptx:
    # إنشاء صورة مصغرة للشريحة
    with pptx.slides[0].get_image(1, 1) as img:
        img.save("output_out.png", slides.ImageFormat.PNG)

    # إنشاء ملف PDF
    pptx.save("output_out.pdf", slides.export.SaveFormat.PDF)

    # إنشاء ملف XPS
    pptx.save("output_out.xps", slides.export.SaveFormat.XPS)
```


## **الأسئلة المتكررة**

**ما الذي تؤثر به المتغيرات default_regular_font و default_asian_font بالضبط—هل هو التصدير فقط أم أيضًا المصغرات، PDF، XPS، HTML و SVG؟**

إنها تشارك في خط أنابيب التصيير لجميع المخرجات المدعومة. ويشمل ذلك مصغرات الشرائح، [PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/python-net/convert-powerpoint-to-xps/)، [raster images](/slides/ar/python-net/convert-powerpoint-to-png/)، [HTML](/slides/ar/python-net/convert-powerpoint-to-html/)، و [SVG](/slides/ar/python-net/render-a-slide-as-an-svg-image/)، لأن Aspose.Slides يستخدم نفس منطق تخطيط وحل الرموز عبر هذه الأهداف.

**هل تُطبق الخطوط الافتراضية عند قراءة وحفظ PPTX دون أي تصيير؟**

لا. الخطوط الافتراضية تهم عندما يجب قياس النص ورسمه. حفظ العرض مباشرة لا يغيّر تشغيلات الخط المخزنة أو بنية الملف. الخطوط الافتراضية تتدخل أثناء العمليات التي تصيغ أو تعيد تدفق النص.

**إذا أضفت مجلدات خطوط خاصة بي أو زودت الخطوط من الذاكرة، هل سيتم اعتبارها عند اختيار الخطوط الافتراضية؟**

نعم. [Custom font sources](/slides/ar/python-net/custom-font/) توسع كتالوج العائلات والرموز المتاحة التي يمكن للمحرك استخدامها. الخطوط الافتراضية وأي [fallback rules](/slides/ar/python-net/fallback-font/) ستحلّ ضد تلك المصادر أولاً، مما يوفر تغطية أكثر موثوقية على الخوادم وفي الحاويات.

**هل تؤثر الخطوط الافتراضية على مقاييس النص (kerning, advances) وبالتالي على فواصل السطر والالتفاف؟**

نعم. تغيير الخط يغيّر مقاييس الرموز ويمكن أن يغيّر فواصل السطر والالتفاف وترقيم الصفحات أثناء التصيير. للحفاظ على استقرار التخطيط، [embed the original fonts](/slides/ar/python-net/embedded-font/) أو اختر عائلات افتراضية واحتياطية متوافقة من الناحية المترية.

**هل هناك فائدة من ضبط الخطوط الافتراضية إذا كانت جميع الخطوط المستخدمة في العرض مدمجة؟**

غالبًا لا تكون ضرورية، لأن [embedded fonts](/slides/ar/python-net/embedded-font/) تضمن بالفعل مظهرًا ثابتًا. ما زالت الخطوط الافتراضية تساعد كشبكة أمان للأحرف غير المشمولة في الجزء المدمج أو عندما يخلط ملف نصًا مدمجًا وغير مدمج.