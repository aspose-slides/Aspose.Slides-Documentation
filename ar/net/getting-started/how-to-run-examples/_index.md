---
title: كيفية تشغيل الأمثلة
type: docs
weight: 130
url: /ar/net/how-to-run-examples/
keywords:
- أمثلة
- متطلبات البرنامج
- NuGet
- GitHub
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تشغيل أمثلة Aspose.Slides for .NET بسرعة: استنساخ المستودع، استعادة الحزم، ثم بناء واختبار الميزات لـ PPT و PPTX و ODP."
---

## **متطلبات البرنامج**
قبل تنزيل وتشغيل الأمثلة، يرجى التحقق والتأكد من أن إعداداتك تفي بهذه المتطلبات:

- Visual Studio 2010 أو أحدث.
- تم تثبيت NuGet Package Manager في Visual Studio. تحقق من أن أحدث نسخة من NuGet API مثبتة في Visual Studio.

للحصول على إرشادات تثبيت NuGet Package Manager، انتقل إلى هذه الصفحة: https://docs.microsoft.com/en-us/nuget/install-nuget-client-tools

1. انتقل إلى **Tools** > **Options** > **NuGet Package Manager**.

1. قم بتوسيع **NuGet Package Manager** (بالنقر المزدوج عليه) ثم اختر **Package Sources**.

1. تحقق وتأكد من اختيار معلمة nuget.org.

   يستخدم مشروع المثال ميزة استعادة الحزم التلقائية (NuGet Automatic Package Restore)، لذا تحتاج إلى اتصال إنترنت نشط.

   إذا لم يكن لديك اتصال إنترنت نشط على الجهاز الذي تنوي تشغيل الأمثلة عليه، يرجى مراجعة [Installation](https://docs.aspose.com/slides/net/installation/) وإضافة مرجع إلى Aspose.Slides.dll يدويًا في مشروع المثال.

## **تنزيل Aspose.Slides من GitHub**
جميع أمثلة Aspose.Slides لـ .NET مستضافة على [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET).

يمكنك إما استنساخ المستودع باستخدام عميل GitHub المفضل لديك أو تنزيل ملف ZIP [here](https://github.com/aspose-slides/Aspose.Slides-for-.NET/archive/master.zip).

1. إذا قمت بتنزيل ملف ZIP، يجب استخراج محتوياته إلى مجلد على جهازك.

   جميع الأمثلة مخزنة في مجلد **Examples**.

   هناك ملف حل Visual Studio للغة C#. تم إنشاء المشاريع في Visual Studio 2013، لكن ملفات الحل متوافقة مع Visual Studio 2010 SP1 وما يلحقه.

2. افتح ملف الحل في Visual Studio وابني المشروع.

   عند التشغيل الأول، يتم تنزيل التبعيات تلقائيًا عبر NuGet.

مجلد **Data** في المجلد الجذر لـ **Examples** يحتوي على ملفات الإدخال المستخدمة في أمثلة C#. يجب تنزيل مجلد **Data** إلى جانب مشروع الأمثلة.

3. افتح ملف RunExamples.cs. جميع الأمثلة تُستدعى من هنا.

4. ألغِ التعليق عن الأمثلة التي تريد تشغيلها داخل المشروع.

لا تتردد في التواصل معنا عبر منتدياتنا إذا واجهتك أي مشاكل في إعداد الأشياء أو تشغيل الأمثلة.

## **المساهمة**
يمكنك المساهمة في المشروع بإضافة مثال أو تحسينه. جميع الأمثلة ومشاريع العروض في المستودع مفتوحة المصدر، لذا يمكنك (وأشخاص آخرون) استخدامها بحرية في التطبيقات.

للمساهمة، يمكنك عمل fork للمستودع، تعديل الشيفرة المصدرية، وإنشاء طلب سحب (pull request). سنراجعة التغييرات. إذا وجدناها مفيدة، سنضيفها إلى المستودع.