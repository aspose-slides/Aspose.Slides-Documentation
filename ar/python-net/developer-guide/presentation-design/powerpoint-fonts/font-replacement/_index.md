---
title: تبسيط استبدال الخطوط في العروض التقديمية باستخدام بايثون
linktitle: استبدال الخطوط
type: docs
weight: 60
url: /ar/python-net/font-replacement/
keywords:
- خط
- استبدال الخط
- استبدال الخطوط
- تغيير الخط
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "استبدل الخطوط بسلاسة في Aspose.Slides Python عبر .NET لضمان تناسق الطباعة في عروض PowerPoint وOpenDocument."
---

## **استبدال الخطوط**

إذا غيرت رأيك بشأن استخدام خطٍ ما، يمكنك استبدال ذلك الخط بآخر. سيتم استبدال جميع حالات الخط القديم بالخط الجديد.

تتيح لك Aspose.Slides استبدال الخط بهذه الطريقة:

1. تحميل العرض التقديمي المناسب.  
2. تحميل الخط الذي سيتم استبداله.  
3. تحميل الخط الجديد.  
4. استبدال الخط.  
5. حفظ العرض التقديمي المعدل كملف PPTX.

يوضح الكود التالي بلغة Python كيفية استبدال الخطوط:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Loads a presentation
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Loads the source font that will be replaced
    sourceFont = slides.FontData("Arial")

    # Loads the new font
    destFont = slides.FontData("Times New Roman")

    # Replaces the fonts
    presentation.fonts_manager.replace_font(sourceFont, destFont)

    # Saves the presentation
    presentation.save("UpdatedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="ملاحظة" color="warning" %}} 

لتعيين قواعد تحدد ما يحدث في ظروف معينة (مثل عدم إمكانية الوصول إلى خطٍ ما)، راجع [**استبدال الخط**](/slides/ar/python-net/font-substitution/). 

{{% /alert %}}

## **الأسئلة المتكررة**

**ما الفرق بين "استبدال الخط"، "استبدال الخطوط"، و"الخطوط الاحتياطية"؟**

الاستبدال هو تحويل مقصود من عائلة خطوط إلى أخرى عبر المستند بأكمله. [الاستبدال](/slides/ar/python-net/font-substitution/) هو قاعدة من نوع "إذا كان الخط غير متوفر، استخدم X". [الخط الاحتياطي](/slides/ar/python-net/fallback-font/) يُطبق بشكل مخصص على الحروف المفقودة عندما يكون الخط الأساسي مثبتًا لكنه لا يحتوي على الأحرف المطلوبة.

**هل ينطبق الاستبدال على الشرائح الرئيسة، التخطيطات، الملاحظات، والتعليقات؟**

نعم. يؤثر الاستبدال على جميع عناصر العرض التقديمي التي تستخدم الخط الأصلي، بما في ذلك الشرائح الرئيسة والملاحظات؛ التعليقات أيضًا جزء من المستند وتُؤخذ بعين الاعتبار من قبل محرك الخطوط.

**هل سيتغير الخط داخل الكائنات المدمجة من نوع OLE (مثل Excel)؟**

لا. يتم التحكم في محتوى OLE عبر تطبيقه الخاص. الاستبدال في العرض التقديمي لا يعيد تنسيق البيانات الداخلية لـ OLE؛ قد يُعرض كصورة أو كمحتوى قابل للتحرير خارجيًا.

**هل يمكنني استبدال خط في جزء فقط من العرض (حسب الشرائح أو المناطق)؟**

يمكن تنفيذ استبدال موجه إذا قمت بتغيير الخط على مستوى الكائنات/النطاقات المطلوبة بدلاً من تطبيق استبدال عالمي على المستند بأكمله. يبقى منطق اختيار الخط أثناء العرض كما هو.

**كيف يمكنني تحديد الخطوط التي يستخدمها العرض مسبقًا؟**

استخدم [مدير الخطوط] الخاص بالعرض (https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/): فهو يقدم قائمة بـ [العائلات المستخدمة] (https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_fonts/) ومعلومات حول [الاستبدالات/الخطوط "غير المعروفة"] (https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/)، مما يساعد في تخطيط الاستبدال.

**هل يعمل استبدال الخط عند التحويل إلى PDF/صور؟**

نعم. أثناء التصدير، تطبق Aspose.Slides نفس [تسلسل اختيار/استبدال الخطوط](/slides/ar/python-net/font-selection-sequence/)، لذا سيُحترم الاستبدال الذي تم إجراؤه مسبقًا أثناء التحويل.

**هل أحتاج إلى تثبيت الخط الهدف على النظام، أم يمكنني إرفاق مجلد خطوط؟**

ليس من الضروري التثبيت: تسمح المكتبة بـ [تحميل الخطوط الخارجية](/slides/ar/python-net/custom-font/) من مجلدات المستخدم للاستخدام أثناء [العرض والتصدير](/slides/ar/python-net/convert-powerpoint/).

**هل سيُصحح الاستبدال مشكلة "التوفو" (المربعات) بدلاً من الأحرف؟**

فقط إذا كان الخط الهدف يحتوي فعليًا على الحروف المطلوبة. إذا لم يكن كذلك، قم بـ [تكوين الخط الاحتياطي](/slides/ar/python-net/fallback-font/) لتغطية الأحرف المفقودة.