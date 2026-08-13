---
title: إعلان
type: docs
weight: 60
url: /ar/java/declaration/
keywords:
- إعلان
- مكونات
- إذن Full Trust
- إعدادات السجل
- ملفات النظام
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعرّف على متطلبات الثقة وأذونات واستضافات Aspose.Slides for Java لتتمكن من نشر التطبيقات التي تعالج ملفات PPT و PPTX و ODP بأمان على الخوادم."
---
{{% alert color="info" %}} 

تتطلب جميع مكونات Aspose Java مجموعة أذونات Full Trust. السبب هو أن مكونات Aspose Java تحتاج إلى الوصول إلى إعدادات السجل وملفات النظام بخلاف الدليل الظاهري لبعض العمليات مثل تحليل الخطوط وما إلى ذلك. علاوةً على ذلك، تعتمد مكونات Aspose Java على فئات نظام Java الأساسية التي تتطلب أيضًا مجموعة أذونات Full Trust في كثير من الحالات. 

{{% /alert %}} 

Internet Service Providers hosting multiple applications from different companies mostly enforce Medium Trust security level: 

- OleDbPermission غير متاح. هذا يعني أنك لا يمكن استخدام موفر بيانات OLE DB المُدار في ADO.NET للوصول إلى قواعد البيانات.
- EventLogPermission غير متاح. هذا يعني أنك لا يمكن الوصول إلى سجل أحداث Windows.
- ReflectionPermission غير متاح. هذا يعني أنك لا يمكن استخدام الانعكاس.
- RegistryPermission غير متاح. هذا يعني أنك لا يمكن الوصول إلى السجل.
- WebPermission مقيد. هذا يعني أن تطبيقك يمكنه فقط التواصل مع عنوان أو نطاق عناوين تقوم بتعريفه في عنصر <trust>.
- FileIOPermission مقيد. هذا يعني أنك لا يمكن الوصول إلا إلى الملفات في هيكل الدليل الظاهري لتطبيقك.

{{% alert color="info" %}} 

نظرًا للأسباب المذكورة أعلاه، لا يمكن استخدام مكونات Aspose Java على الخوادم التي تمنح مجموعة أذونات غير Full Trust. 

{{% /alert %}}