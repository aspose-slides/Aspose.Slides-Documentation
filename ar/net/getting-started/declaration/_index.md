---
title: الإعلان
type: docs
weight: 110
url: /ar/net/declaration/
---

{{% alert color="primary" %}} 

تتطلب جميع مكونات Aspose .NET مجموعة إذن الثقة الكاملة لأنها تحتاج أحيانًا إلى الوصول إلى إعدادات السجل، وملفات النظام، وملفات مخزنة في مواقع أخرى (بالإضافة إلى الدليل الافتراضي) لعمليات معينة (مثل تحليل الخطوط). علاوة على ذلك، تعتمد مكونات Aspose .NET على فئات النظام الأساسية .NET، والتي تتطلب مجموعة إذن الثقة الكاملة في العديد من الحالات. 

{{% /alert %}} 

مزودو خدمة الإنترنت، الذين يستضيفون تطبيقات متعددة من شركات مختلفة، يفرضون في الغالب مستوى الأمان الثقة المتوسطة. في حالة .NET 2.0، ينطبق هذا المستوى من الأمان هذه القيود: 

- OleDbPermission غير متوفرة. هذا يعني أنك لا تستطيع استخدام مزود بيانات OLE DB المُدار ADO.NET للوصول إلى قواعد البيانات.
- EventLogPermission غير متوفرة. هذا يعني أنك لا تستطيع الوصول إلى سجل أحداث Windows.
- ReflectionPermission غير متوفرة. هذا يعني أنك لا تستطيع استخدام الانعكاس.
- RegistryPermission غير متوفرة. هذا يعني أنك لا تستطيع الوصول إلى السجل.
- WebPermission مقيد. هذا يعني أن تطبيقك يمكنه فقط التواصل مع عنوان أو نطاق من العناوين التي حددتها في عنصر <trust>.
- FileIOPermission مقيد. هذا يعني أنه يمكنك فقط الوصول إلى الملفات في تسلسل الدليل الافتراضي لتطبيقك.

{{% alert color="primary" %}} 

بسبب الأسباب المذكورة أعلاه، يمكن استخدام مكونات Aspose .NET فقط على الخوادم التي تمنح مجموعة إذن الثقة الكاملة. 

{{% /alert %}}