---
title: "استخراج نص متقدم من العروض التقديمية في PHP"
linktitle: "استخراج النص"
type: docs
weight: 90
url: /ar/php-java/extract-text-from-presentation/
keywords:
- "استخراج النص"
- "استخراج النص من الشريحة"
- "استخراج النص من العرض التقديمي"
- "استخراج النص من PowerPoint"
- "استخراج النص من OpenDocument"
- "استخراج النص من PPT"
- "استخراج النص من PPTX"
- "استخراج النص من ODP"
- "استرجاع النص"
- "استرجاع النص من الشريحة"
- "استرجاع النص من العرض التقديمي"
- "استرجاع النص من PowerPoint"
- "استرجاع النص من OpenDocument"
- "استرجاع النص من PPT"
- "استرجاع النص من PPTX"
- "استرجاع النص من ODP"
- "PowerPoint"
- "OpenDocument"
- "العرض التقديمي"
- "PHP"
- "Aspose.Slides"
description: "استخراج النص بسرعة من عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for PHP عبر Java. اتبع دليلنا البسيط خطوة بخطوة لتوفير الوقت."
---
## **نظرة عامة**

إن استخراج النص من العروض التقديمية مهمة شائعة ولكنها أساسية للمطورين الذين يعملون مع محتوى الشرائح. سواء كنت تتعامل مع ملفات Microsoft PowerPoint بصيغة PPT أو PPTX، أو عروض OpenDocument (ODP)، فإن الوصول إلى البيانات النصية واسترجاعها قد يكون حيويًا للتحليل أو الأتمتة أو الفهرسة أو أغراض نقل المحتوى.

توفر هذه المقالة دليلًا شاملاً حول كيفية استخراج النص بكفاءة من صيغ العروض المختلفة، بما في ذلك PPT وPPTX وODP، باستخدام Aspose.Slides for PHP via Java. سوف تتعلم كيفية التنقل عبر عناصر العرض بطريقة منهجية لاسترجاع محتوى النص الذي تحتاجه بدقة.

## **استخراج النص من شريحة**

توفر Aspose.Slides for PHP via Java الفئة [SlideUtil](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideutil/). تُظهر هذه الفئة عدة طرق ثابتة محمّلة لاستخراج كل النص من عرض تقديمي أو شريحة. لاستخراج النص من شريحة في عرض تقديمي، استخدم طريقة [getAllTextBoxes](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slideutil/#getAllTextBoxes). تقبل هذه الطريقة كمعامل كائن من نوع [BaseSlide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseslide/). عند تنفيذها، تقوم الطريقة بمسح الشريحة بالكامل للعثور على النص وتعيد مصفوفة من الكائنات من نوع [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/)، مع الحفاظ على أي تنسيق للنص.

المقتطف البرمجي التالي يستخرج كل النص من الشريحة الأولى في العرض التقديمي:

{{e47326bc