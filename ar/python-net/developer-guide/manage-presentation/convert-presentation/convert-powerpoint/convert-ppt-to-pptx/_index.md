---
title: تحويل PPT إلى PPTX في Python
linktitle: PPT إلى PPTX
type: docs
weight: 20
url: /ar/python-net/convert-ppt-to-pptx/
keywords:
- تحويل PPT
- PPT إلى PPTX
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تحويل العروض التقديمية القديمة بصيغة PPT إلى صيغة PPTX الحديثة بسرعة في Python باستخدام Aspose.Slides — دليل واضح، عينات شفرة مجانية، بدون اعتماد على Microsoft Office."
---

## **نظرة عامة**

هذه المقالة توضح طريقة تحويل عرض PowerPoint بصيغة PPT إلى صيغة PPTX باستخدام Python ومن خلال تطبيق تحويل PPT إلى PPTX على الإنترنت. الموضوع التالي مُغطى:

- تحويل PPT إلى PPTX باستخدام Python

## **Python تحويل PPT إلى PPTX**

للحصول على مثال كود Python لتحويل PPT إلى PPTX، يرجى الاطلاع على القسم أدناه، أي [تحويل PPT إلى PPTX](#convert-ppt-to-pptx). يقوم الكود ببساطة بتحميل ملف PPT وحفظه بصيغة PPTX. من خلال تحديد صيغ حفظ مختلفة، يمكنك أيضًا حفظ ملف PPT إلى العديد من الصيغ الأخرى مثل PDF و XPS و ODP و HTML وغيرها، كما هو موضح في هذه المقالات:

- [Python تحويل PPT إلى PDF](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-pdf/)
- [Python تحويل PPT إلى XPS](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)
- [Python تحويل PPT إلى HTML](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)
- [Python تحويل PPT إلى ODP](https://docs.aspose.com/slides/python-net/save-presentation/)
- [Python تحويل PPT إلى Image](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-png/)

## **حول تحويل PPT إلى PPTX**

قم بتحويل صيغة PPT القديمة إلى PPTX باستخدام Aspose.Slides API. إذا كنت بحاجة إلى تحويل آلاف العروض التقديمية من PPT إلى صيغة PPTX، فإن الحل الأفضل هو القيام بذلك برمجيًا. مع Aspose.Slides API، يمكنك إنجاز ذلك في بضع أسطر من الشيفرة فقط. تدعم الواجهة برمجة التطبيقات التوافق الكامل لتحويل عرض PPT إلى PPTX، ويمكنك القيام بما يلي:

- تحويل هياكل معقدة من القوالب، التخطيطات، والشرائح.
- تحويل عرض تقديمي يحتوي على مخططات.
- تحويل عرض تقديمي يحتوي على أشكال مجموعة، أشكال تلقائية (مثل المستطيلات والبيضات)، وأشكال ذات هندسة مخصصة.
- تحويل عرض تقديمي يحتوي على قوام وأنماط تعبئة صور للأشكال التلقائية.
- تحويل عرض تقديمي يحتوي على نواقل، إطارات نصية، وحاملات نص.

{{% alert color="primary" %}}

ألق نظرة على التطبيق [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) :

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

تم بناء هذا التطبيق بناءً على **Aspose.Slides API**، لذلك يمكنك مشاهدة مثال حي لقدرات التحويل الأساسية من PPT إلى PPTX. Aspose.Slides Conversion هو تطبيق ويب يتيح لك سحب ملف عرض بصيغة PPT وتحميله بعد تحويله إلى PPTX.

ابحث عن أمثلة أخرى حيّة [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) .

{{% /alert %}}

## **تحويل PPT إلى PPTX**

لتحويل PPT إلى PPTX، ما عليك سوى تمرير اسم الملف وصيغة الحفظ إلى طريقة [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) في فئة [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). المثال البرمجي أدناه يحول عرضًا من PPT إلى PPTX باستخدام الخيارات الافتراضية.
```python
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف PPT
pres = slides.Presentation("PPTtoPPTX.ppt")

# حفظ العرض التقديمي بصيغة PPTX
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```


اقرأ المزيد عن [**PPT vs PPTX**](/slides/ar/python-net/ppt-vs-pptx/) صيغ العروض وكيفية [**Aspose.Slides supports PPT to PPTX conversion**](/slides/ar/python-net/convert-ppt-to-pptx/).

## **الأسئلة الشائعة**

**ما الفرق بين صيغ PPT و PPTX؟**

PPT هي الصيغة الثنائية القديمة المستخدمة بواسطة Microsoft PowerPoint، بينما PPTX هي الصيغة القائمة على XML والتي تم تقديمها مع Microsoft Office 2007. ملفات PPTX توفر أداءً أفضل، حجم ملف أصغر، وتحسينًا في استعادة البيانات.

**هل يمكنني تحويل PPT إلى PPTX باستخدام Python؟**

نعم، باستخدام مكتبة Aspose.Slides for Python عبر .NET، يمكنك بسهولة تحميل ملف PPT وحفظه بصيغة PPTX ببضع أسطر من الشيفرة فقط.

**هل تدعم Aspose.Slides التحويل الجماعي لعدة ملفات PPT إلى PPTX؟**

نعم، يمكنك استخدام Aspose.Slides داخل حلقة لتحويل عدة ملفات PPT إلى PPTX برمجيًا، مما يجعله مناسبًا لسيناريوهات التحويل الجماعي.

**هل سيحافظ المحتوى والتنسيق على الشكل بعد التحويل؟**

تحافظ Aspose.Slides على دقة عالية في تحويل العروض. تُحفظ تخطيطات الشرائح، الرسوم المتحركة، الأشكال، المخططات، وعناصر التصميم الأخرى أثناء تحويل PPT إلى PPTX.

**هل يمكنني تحويل صيغ أخرى مثل PDF أو HTML من ملفات PPT؟**

نعم، تدعم Aspose.Slides تحويل ملفات PPT إلى صيغ متعددة تشمل PDF و XPS و HTML و ODP وكذلك صيغ الصور مثل PNG و JPEG.

**هل من الممكن تحويل PPT إلى PPTX دون تثبيت Microsoft PowerPoint؟**

نعم، Aspose.Slides for Python عبر .NET هي واجهة برمجة تطبيقات مستقلة ولا تتطلب تثبيت Microsoft PowerPoint أو أي برنامج طرف ثالث لإجراء التحويل.

**هل هناك أداة على الإنترنت متاحة لتحويل PPT إلى PPTX؟**

نعم، يمكنك استخدام تطبيق الويب المجاني [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/conversion/ppt-to-pptx) للقيام بالتحويل مباشرة في المتصفح دون كتابة أي كود.