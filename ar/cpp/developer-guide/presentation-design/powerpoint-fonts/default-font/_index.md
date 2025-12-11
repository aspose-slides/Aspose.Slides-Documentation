---
title: تحديد خطوط العرض الافتراضية في C++
linktitle: الخط الافتراضي
type: docs
weight: 30
url: /ar/cpp/default-font/
keywords:
- الخط الافتراضي
- الخط العادي
- الخط العادي
- الخط الآسيوي
- تصدير PDF
- تصدير XPS
- تصدير الصور
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعيين الخطوط الافتراضية في Aspose.Slides لـ C++ لضمان تحويل صحيح إلى PDF و XPS وصور لعروض PowerPoint (PPT, PPTX) و OpenDocument (ODP)."
---

## **تعيين خط افتراضي**
باستخدام Aspose.Slides for C++ يمكنك تعيين الخط الافتراضي في عروض PowerPoint. تمت إضافة طريقة جديدة [set_DefaultRegularFont()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_save_options/#a9df129ea6e65c8196e08173799a10492) إلى فئة [**SaveOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.save_options/) . تسمح هذه الطريقة بتعيين الخط الافتراضي المستخدم بدلاً من جميع الخطوط المفقودة أثناء حفظ العروض التقديمية إلى صيغ مختلفة دون إعادة تحميل العروض.

المقتطف البرمجي أدناه يوضح حفظ عرض تقديمي إلى [HTML](https://docs.fileformat.com/web/html/) و[PDF](https://docs.fileformat.com/pdf/) باستخدام خطوط افتراضية مختلفة.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetDefaultFont-SetDefaultFont.cpp" >}}

## **استخدام الخطوط الافتراضية لتصوير العرض التقديمي**
يتيح لك Aspose.Slides تعيين الخط الافتراضي عند تصوير العرض التقديمي إلى PDF أو XPS أو الصور المصغرة. تُظهر هذه المقالة كيفية تعريف DefaultRegularFont وDefaultAsianFont لاستخدامهما كخطوط افتراضية. يرجى اتباع الخطوات أدناه لتحميل الخطوط من أدلة خارجية باستخدام Aspose.Slides for C++ API:

1. إنشاء كائن من LoadOptions.  
1. تعيين DefaultRegularFont إلى الخط الذي ترغب به. في المثال التالي استخدمت Wingdings.  
1. تعيين DefaultAsianFont إلى الخط الذي ترغب به. استخدمت Wingdings في العينة التالية.  
1. تحميل العرض التقديمي باستخدام Presentation وتحديد خيارات التحميل.  
1. الآن، إنشاء الصورة المصغرة للشريحة، PDF وXPS للتحقق من النتائج.

تنفيذ ما سبق موضح أدناه.
```cpp
// استخدم خيارات التحميل لتحديد الخطوط العادية والآسيوية الافتراضية
auto loadOptions = MakeObject<LoadOptions>(LoadFormat::Auto);
loadOptions->set_DefaultRegularFont(u"Wingdings");
loadOptions->set_DefaultAsianFont(u"Wingdings");

auto pptx = MakeObject<Presentation>(u"DefaultFonts.pptx", loadOptions);

auto image = pptx->get_Slide(0)->GetImage(1, 1);
image->Save(u"DefaultFonts_out.png", ImageFormat::Png);
image->Dispose();

pptx->Save(u"DefaultFonts_out.pdf", SaveFormat::Pdf);
pptx->Save(u"DefaultFonts_out.xps", SaveFormat::Xps);

pptx->Dispose();
```


## **الأسئلة الشائعة**

**ما الذي تؤثر فيه بالضبط DefaultRegularFont وDefaultAsianFont — فقط التصدير، أم أيضًا الصور المصغرة، PDF، XPS، HTML، وSVG؟**  
إنهما يشاركان في خط أنابيب التصيّر لجميع المخرجات المدعومة. يشمل ذلك الصور المصغرة للشرائح، [PDF](/slides/ar/cpp/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/cpp/convert-powerpoint-to-xps/)، [صور نقطية](/slides/ar/cpp/convert-powerpoint-to-png/)، [HTML](/slides/ar/cpp/convert-powerpoint-to-html/)، و[SVG](/slides/ar/cpp/render-a-slide-as-an-svg-image/)، لأن Aspose.Slides يستخدم نفس منطق التخطيط وحل الحروف عبر هذه الأهداف.

**هل تُطبق الخطوط الافتراضية عند مجرد قراءة وحفظ ملف PPTX بدون أي تصيّر؟**  
لا. تتعلق الخطوط الافتراضية عندما يلزم قياس النص ورسمه. عملية فتح‑حفظ مباشرة للعرض لا تُغيّر خطوط النص المخزنة ولا بنية الملف. تُستَخدم الخطوط الافتراضية أثناء العمليات التي تُصوّر أو تُعيد تدفق النص.

**إذا أضفت مجلدات خطوط خاصة بي أوّ زودت خطوطًا من الذاكرة، هل ستؤخذ بعين الاعتبار عند اختيار الخطوط الافتراضية؟**  
نعم. [مصادر الخطوط المخصصة](/slides/ar/cpp/custom-font/) توسّع كتالوج العائلات والحروف المتاحة للمحرك. الخطوط الافتراضية وأي [قواعد احتياطية](/slides/ar/cpp/fallback-font/) ستحلّ ضد تلك المصادر أولاً، مما يوفّر تغطية أكثر موثوقية على الخوادم وفي الحاويات.

**هل تؤثر الخطوط الافتراضية على مقاييس النص (التقارب، التقدم) وبالتالي على فواصل السطر واللف؟**  
نعم. تغيير الخط يغيّر مقاييس الحروف ويمكن أن يؤثّر على فواصل السطر، اللف، والتقسيم خلال التصيّر. لضمان استقرار التخطيط، يفضّل [تضمين الخطوط الأصلية](/slides/ar/cpp/embedded-font/) أو اختيار عائلات افتراضية واحتياطية متوافقة مقاييميًا.

**هل هناك فائدة من تعيين الخطوط الافتراضية إذا كانت جميع الخطوط المستخدمة في العرض مضمَّنة؟**  
غالبًا لا تكون ضرورية، لأن [الخطوط المضمَّنة](/slides/ar/cpp/embedded-font/) تضمن مظهرًا ثابتًا بالفعل. ما زالت الخطوط الافتراضية مفيدة كشبكة أمان للأحرف غير المشمولة في المجموعة المضمَّنة أو عندما يمزج الملف بين نص مضمّن وغير مضمّن.