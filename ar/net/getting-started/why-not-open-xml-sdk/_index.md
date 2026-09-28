---
title: لماذا لا نستخدم Open XML SDK
type: docs
weight: 180
url: /ar/net/why-not-open-xml-sdk/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/open-xml-sdk/
keywords:
- Open XML SDK
- مقارنة
- نموذج كائن العرض التقديمي
- تحويل عالي الجودة
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "اكتشف لماذا Aspose.Slides اختيار أفضل من Open XML SDK المجاني: قارن الميزات، التحويل بدون أتمتة، والدعم الواسع لـ PPT و PPTX و ODP."
---
## **نظرة عامة**

تشرح هذه المقالة متى قد يختار المطورون Open XML SDK أو Aspose.Slides للعمل مع مستندات العروض التقديمية. وتصف Open XML SDK بأنها مكتبة لمعالجة حزم OOXML وعناصر XML الأساسية الخاصة بها، بينما تُقدم Aspose.Slides كمكتبة معالجة عروض تقديمية ذات نموذج كائن عالي المستوى وتدعم العديد من مهام PowerPoint.

تقارن المقالة بين الخيارين من حيث الصيغ المدعومة، نموذج البرمجة، العرض، دعم المنصات، وحالات الاستخدام الشائعة. كما توضح أن Open XML SDK قد يكون مناسبًا للعمليات الأساسية على PPTX أو للوصول المباشر إلى عناصر OOXML، في حين أن Aspose.Slides يكون أكثر ملاءمة للمهام المعقدة مثل التعامل مع صيغ PowerPoint المتعددة، نسخ أو استنساخ الأشكال، استبدال النص، تطبيق الرسوم المتحركة، وتحويل العروض إلى PDF أو TIFF أو XPS.

## **ما هو Open XML SDK؟**
أحيانًا نتلقى هذا السؤال: *لماذا نستخدم منتجات Aspose بدلاً من Open XML SDK المجاني؟*

نجد أن الإجابة تكون سهلة من حيث الميزات والوظائف.

وفقًا لـ [مكتبة MSDN](https://learn.microsoft.com/en-us/office/open-xml/open-xml-sdk)، يتم تعريف Open XML SDK بهذا الشكل:

> "The Open XML SDK 2.0 simplifies the task of manipulating Open XML packages and the underlying Open XML schema elements within a package. The Open XML SDK 2.0 encapsulates many common tasks that developers perform on Open XML packages, so that you can perform complex operations with just a few lines of code. OOXML documents are essentially zipped XML files and Open XML SDK is a collection of classes that allows you to work with the content of OOXML documents in a strongly-typed way. That is instead of unzipping a file to extract XML, loading that XML into a DOM tree, and working with XML elements and attributes directly, Open XML SDK provides classes to do that."

## **ما هو Aspose.Slides؟**
Aspose.Slides هي مكتبة فئوية تسمح للتطبيقات بأداء مهام معالجة العروض التقديمية التالية:

- البرمجة بنموذج كائن العرض التقديمي.
- تحويلات عالية الجودة تشمل جميع صيغ PowerPoint الشائعة المدعومة، بما في ذلك التحويل إلى PDF و XPS و TIFF.
- إنشاء صور مصغرة للشرائح بصيغ معروفة مثل PNG و JPEG و BMP بالإضافة إلى تصدير الشرائح إلى SVG.
- بناء عروض تقديمية من الصفر أو بدمج عناصر من مستند واحد أو عدة مستندات.
- إضافة الرسوم المتحركة، إطارات OLE، الجداول، وإنشاء وإدارة المخططات.
- التحكم (تحكم شامل) وإدارة تنسيق النص على مستويات TextFrames و Paragraphs و Portions.

للمزيد من التفاصيل حول الميزات المتاحة، يرجى زيارة صفحة [ميزات Aspose.Slides](/slides/ar/net/product-overview/).

## **قارن بين Open XML SDK و Aspose.Slides**
يسلط هذا الجدول الضوء على قدرات وميزات Open XML SDK مقارنةً بـ Aspose.Slides.

|**الميزة أو فئة الميزة**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|تنسيقات العروض المدعومة|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|التحويل من PPT إلى PPTX|No|Yes|
|<p>البرمجة عالية المستوى باستخدام نموذج كائن مستند العرض (DOM):</p><p>- البحث وإبدال النصوص.</p><p>- تجميع الشرائح في العروض.</p>|No|Yes|
|البرمجة التفصيلية باستخدام نموذج كائن المستند؛ الوصول إلى العناصر الفردية والتنسيق مثل TextHolders و TextFrames و Paragraphs و Portions.|Yes|Yes|
|الوصول المباشر الكامل إلى عناصر XML الأساسية والسمات مثل معرّفات العلاقات ومعرّفات القوائم في مستند OOXML.|Yes|No|
|<p>عرض العرض التقديمي:</p><p>- عرض العروض إلى PDF و PDF Notes و XPS و صور TIFF.</p><p>- عرض صور مصغرة للشرائح إلى PNG و JPEG و BMP و SVG و TIFF.</p><p>- تحديد دقة الصورة والجودة والضغط وخيارات أخرى.</p>|No|Yes|
|المنصات المدعومة|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **الخلاصة**
Open XML SDK و Aspose.Slides لا يتنافسان مباشرة لأنهما يلبيان احتياجات مختلفة جدًا، ويستهدفان جماهير مختلفة.

{{% alert color="info" title="Note" %}}

Open XML SDK هي مكتبة فئوية توفر طريقة ذات نوعية قوية للعمل مع مستندات OOXML بينما Aspose.Slides هي مكتبة معالجة عروض تقديمية مفيدة للغاية توفر دعمًا كبيرًا لمعظم صيغ ملفات Microsoft PowerPoint.

{{% /alert %}}

إذا كان سير عملك يتضمن عملية برمجة أساسية على مستند PPTX، فقد يكون Open XML SDK خيارًا جيدًا. مع Open XML SDK، يمكنك تنفيذ مهام بسيطة مثل إنشاء مستند PPTX بسيط أو إزالة التعليقات، رؤوس/تذييلات الصفحات، استخراج الصور أو غيرها. يمكن إنجاز بعض المهام باستخدام Open XML SDK ولا يمكن إنجازها باستخدام Aspose.Slides. على سبيل المثال، إذا كنت تحتاج إلى الوصول مباشرة إلى عناصر XML وسمات مستند OOXML، فيجب عليك استخدام Open XML SDK.

إذا احتجت إلى أداء مهام معقدة على المستندات — مثل المهام الواردة في القائمة أدناه — فإن Aspose.Slides هو الخيار الأنسب لك.

- عمليات تتعلق بصيغ PowerPoint القديمة (وأيضًا PPTX).
- نسخ أو استنساخ الأشكال داخل الشرائح بطريقة تجمع بين الكائنات والأنماط وعناصر التنسيق الأخرى بشكل ملائم.
- استبدال النص المنسق أو غير المنسق.
- تطبيق الرسوم المتحركة واستخدام الموصلات مع الأشكال.
- تحويل مستند إلى PDF أو TIFF أو XPS بحيث يبدو كما لو أن Microsoft PowerPoint قام بالتحويل.
- تطوير تطبيق .NET أو Java في بيئات سطح المكتب والويب معًا.