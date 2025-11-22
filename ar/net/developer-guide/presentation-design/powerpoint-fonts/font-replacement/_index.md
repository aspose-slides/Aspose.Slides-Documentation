---
title: استبدال الخط - PowerPoint C# API
linktitle: استبدال الخط
type: docs
weight: 60
url: /ar/net/font-replacement/
keywords: "خط, استبدال خط, عرض تقديمي PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "مع واجهة برمجة تطبيقات PowerPoint C#، يمكنك استبدال الخط صراحةً بخط آخر داخل العرض التقديمي."
---

## **استبدال الخطوط**

إذا غيرت رأيك بشأن استخدام خط ما، يمكنك استبدال ذلك الخط بخط آخر. سيتم استبدال جميع حالات الخط القديم بالخط الجديد. 

Aspose.Slides تتيح لك استبدال الخط بهذه الطريقة:

1. حمّل العرض التقديمي المناسب. 
2. حمّل الخط الذي سيتم استبداله. 
3. حمّل الخط الجديد. 
4. استبدل الخط. 
5. احفظ العرض التقديمي المعدل كملف PPTX.

يظهر هذا الكود C# استبدال الخط:
```c#
// يقوم بتحميل عرض تقديمي
// يقوم بتحميل الخط المصدر الذي سيتم استبداله
// يقوم بتحميل الخط الجديد
// يقوم باستبدال الخطوط
// يقوم بحفظ العرض التقديمي
Presentation presentation = new Presentation("Fonts.pptx");

// Loads the source font that will be replaced
IFontData sourceFont = new FontData("Arial");

// Loads the new font
IFontData destFont = new FontData("Times New Roman");

// Replaces the fonts
presentation.FontsManager.ReplaceFont(sourceFont, destFont);

// Saves the presentation
presentation.Save("UpdatedFont_out.pptx", SaveFormat.Pptx);
```


{{% alert title="Note" color="warning" %}} 
لتعيين القواعد التي تحدد ما يحدث في ظروف معينة (على سبيل المثال إذا تعذر الوصول إلى خط)، راجع [**Font Substitution**](/slides/ar/net/font-substitution/). 
{{% /alert %}}

## **الأسئلة المتكررة**

**ما الفرق بين "font replacement" و"font substitution" و"fallback fonts"?**

الاستبدال هو تحويل مقصود من عائلة إلى أخرى عبر المستند بأكمله. [Substitution](/slides/ar/net/font-substitution/) هي قاعدة مثل "إذا كان الخط غير متاح، استخدم X". [Fallback](/slides/ar/net/fallback-font/) تُطبق بشكل دقيق على الأحرف المفقودة الفردية عندما يكون الخط الأساسي مثبتًا ولكنه لا يحتوي على الأحرف المطلوبة.

**هل ينطبق الاستبدال على الشرائح الرئيسية، التخطيطات، الملاحظات، والتعليقات؟**

نعم. يؤثر الاستبدال على جميع كائنات العرض التقديمي التي تستخدم الخط الأصلي، بما في ذلك الشرائح الرئيسية والملاحظات؛ التعليقات أيضًا جزء من المستند وتُؤخذ في الاعتبار بواسطة محرك الخط.

**هل سيتغير الخط داخل كائنات OLE المدمجة (مثلاً Excel)؟**

لا. [OLE content](/slides/ar/net/manage-ole/) يتحكم فيه تطبيقه الخاص. لا يؤدي الاستبدال في العرض التقديمي إلى إعادة تنسيق بيانات OLE الداخلية؛ قد يتم عرضها كصورة أو كمحتوى قابل للتحرير خارجيًا.

**هل يمكنني استبدال خط فقط في جزء من العرض التقديمي (حسب الشرائح أو المناطق)؟**

يمكن إجراء استبدال مستهدف إذا قمت بتغيير الخط على مستوى الكائنات/النطاقات المطلوبة بدلاً من تطبيق استبدال شامل على المستند بأكمله. يبقى منطق اختيار الخط العام أثناء العرض كما هو.

**كيف يمكنني معرفة الخطوط التي يستخدمها العرض التقديمي مسبقًا؟**

استخدم [مدير الخطوط](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/): يقدم قائمة بـ [العائلات المستخدمة](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) ومعلومات حول [الاستبدالات/"unknown" الخطوط](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/)، مما يساعد على تخطيط الاستبدال.

**هل يعمل استبدال الخط عند التحويل إلى PDF/صور؟**

نعم. أثناء التصدير، تقوم Aspose.Slides بتطبيق نفس [font selection/substitution sequence](/slides/ar/net/font-selection-sequence/)، لذا سيتم احترام الاستبدال الذي تم إجراؤه مسبقًا أثناء التحويل.

**هل أحتاج إلى تثبيت الخط الهدف في النظام، أم يمكنني إرفاق مجلد خطوط؟**

ليس من الضروري التثبيت: تسمح المكتبة بـ [loading external fonts](/slides/ar/net/custom-font/) من مجلدات المستخدم للاستخدام أثناء [rendering and export](/slides/ar/net/convert-powerpoint/).

**هل سيصلح الاستبدال مشكلة "tofu" (مربعات) بدلاً من الأحرف؟**

فقط إذا كان الخط الهدف يحتوي فعليًا على الرموز المطلوبة. إذا لم يكن كذلك، [configure fallback](/slides/ar/net/fallback-font/) لتغطية الأحرف المفقودة.