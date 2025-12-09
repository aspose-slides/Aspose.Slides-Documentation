---
title: لماذا لا نستخدم Open XML SDK
type: docs
weight: 50
url: /ar/net/why-not-open-xml-sdk/
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
description: "اكتشف لماذا Aspose.Slides هو الخيار الأفضل مقارنةً بـ Open XML SDK المجانية: قارن الميزات، التحويل بدون أتمتة، والدعم الواسع لـ PPT و PPTX و ODP."
---

## **ما هو Open XML SDK؟**
أحيانًا نتلقى هذا السؤال: *لماذا يجب أن نستخدم منتجات Aspose بدلاً من Open XML SDK المجانية؟* 

نجد أنه من السهل الإجابة على هذا السؤال من حيث الميزات والوظائف. 

وفقًا لـ[مكتبة MSDN](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk)، يتم تعريف Open XML SDK على النحو التالي: 

> "The Open XML SDK 2.0 simplifies the task of manipulating Open XML packages and the underlying Open XML schema elements within a package. The Open XML SDK 2.0 encapsulates many common tasks that developers perform on Open XML packages, so that you can perform complex operations with just a few lines of code. OOXML documents are essentially zipped XML files and Open XML SDK is a collection of classes that allows you to work with the content of OOXML documents in a strongly-typed way. That is instead of unzipping a file to extract XML, loading that XML into a DOM tree, and working with XML elements and attributes directly, Open XML SDK provides classes to do that."

## **ما هو Aspose.Slides؟**
Aspose.Slides هي مكتبة فئات تسمح للتطبيقات بتنفيذ مهام معالجة العروض التقديمية التالية: 

- البرمجة باستخدام نموذج كائن العرض التقديمي.

- تحويلات عالية الجودة تشمل جميع صيغ عروض PowerPoint المدعومة، بما في ذلك التحويل إلى PDF وXPS وTIFF والطباعة.

- إنشاء صور مصغرة للشرائح بصيغ معروفة مثل PNG وJPEG وBMP إلى جانب تصدير الشرائح إلى SVG.

- إنشاء عروض تقديمية من الصفر أو عن طريق دمج عناصر من مستند واحد أو عدة مستندات.

- إضافة الرسوم المتحركة، إطارات OLE، الجداول، إنشاء وإدارة المخططات.

- التحكم (التحكم الشامل) وإدارة تنسيق النص على مستويات TextFrames والفقرات والأقسام. 

لمزيد من التفاصيل حول الميزات المتاحة، يرجى زيارة صفحة [ميزات Aspose.Slides](/slides/ar/net/product-overview/).

## **مقارنة Open XML SDK مع Aspose.Slides**
|**الميزة أو فئة الميزة**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|صيغ العروض المدعومة|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|التحويل من PPT إلى PPTX |No|Yes|
|<p>البرمجة عالية المستوى باستخدام نموذج كائن مستند العرض (DOM): </p><p>- البحث والاستبدال للنصوص.</p><p>- تجميع الشرائح في العروض.</p>|No|Yes|
|برمجة مفصلة باستخدام نموذج كائن المستند؛ وصول إلى العناصر الفردية والتنسيق مثل TextHolders وTextFrames والفقرات والأقسام.|Yes|Yes|
|وصول منخفض المستوى مباشر وكامل إلى عناصر XML والسمات الأساسية مثل معرفات العلاقات، ومعرفات القوائم في مستند OOXML.|Yes|No|
|<p>العرض والطباعة:</p><p>- تصيير العروض إلى PDF، ملاحظات PDF، XPS، صور TIFF.</p><p>- تصيير الصور المصغرة للشرائح إلى PNG، JPEG، BMP، SVG وTIFF.</p><p>- تحديد دقة الصورة، الجودة، الضغط وخيارات أخرى.</p><p>- طباعة العروض باستخدام بنية الطباعة في .NET. المكوّن يحتوي على طريقة طباعة مدمجة لطباعة العروض كما هو موضح في معاينة الطباعة لبرنامج MS PowerPoint.</p>|No|Yes|
|المنصات المدعومة|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **الخلاصة**
Open XML SDK و Aspose.Slides لا يتنافسان مباشرة لأنهما يلبيان احتياجات مختلفة إلى حد كبير، ويستهدفان جماهير مختلفة. 

{{% alert color="primary" %}} 

Open XML SDK هي مكتبة فئات توفر طريقة قوية النوع للعمل مع مستندات OOXML، بينما Aspose.Slides هي مكتبة معالجة عروض تقديمية ذات فائدة كبيرة توفر دعمًا ممتازًا لجميع صيغ ملفات Microsoft PowerPoint تقريبًا. 

{{% /alert %}} 

إذا كان سير عملك عملية برمجة أساسية على مستند PPTX، فقد يكون Open XML SDK خيارًا جيدًا. مع Open XML SDK، يجب أن تكون قادرًا على تنفيذ مهام بسيطة مثل إنشاء مستند PPTX بسيط أو إزالة التعليقات، الرؤوس/التذييلات، استخراج الصور أو غيرها. بعض المهام يمكن تنفيذها باستخدام Open XML SDK ولا يمكن تنفيذها باستخدام Aspose.Slides. على سبيل المثال، إذا كنت بحاجة إلى الوصول مباشرة إلى عناصر XML وسماتها في مستند OOXML، فيجب عليك استخدام Open XML SDK. 

إذا كنت بحاجة إلى تنفيذ مهام معقدة على المستندات—مثل المهام المذكورة أدناه—فإن Aspose.Slides هو الخيار الأفضل لك. 

- عمليات تتعلق بصيغ PowerPoint القديمة (وكذلك PPTX).  
- نسخ أو استنساخ الأشكال داخل الشرائح بطريقة تجمع بين الكائنات والأنماط وعناصر التنسيق الأخرى بطريقة مناسبة.  
- استبدال النص المنسق أو غير المنسق.  
- تطبيق الرسوم المتحركة واستخدام الوصلات مع الأشكال.  
- تحويل مستند إلى PDF أو TIFF أو XPS بحيث يبدو كما لو أن Microsoft PowerPoint قام بالتحويل.  
- تطوير تطبيق .NET أو Java في بيئات سطح المكتب والويب.