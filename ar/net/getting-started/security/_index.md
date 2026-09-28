---
title: الأمان
type: docs
weight: 160
url: /ar/net/security/
keywords:
- أمان
- تبعيات
- مكونات الطرف الثالث
- NuGet
- فحص الثغرات
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استعراض كيفية معالجة Aspose.Slides لـ .NET للعرض التقديمي، وحزمة NuGet التي يعتمد عليها لكل إطار هدف، والمكونات الطرفية التي يتضمنها."
---
## **الأمان في Aspose.Slides**

تطبق Aspose أفضل الممارسات عند تطوير منتجاتها.

* يتم استخدام Aspose.Slides لـ .NET للتعامل مع العروض التقديمية وتحويلها إلى تنسيقات أخرى. لا تقوم بتشغيل النصوص البرمجية داخل العروض. تقوم Aspose.Slides بتحليل بنية العرض وتتيح لك كود المستخدم النهائي تعديل نموذج الكائنات بطريقة مريحة.
* تعمل Aspose.Slides كمكتبة تحلل وتفسر المستندات دون تنفيذ كود عن بُعد. جميع منتجات Aspose تعمل على أجهزتك. لا تنقل أي بيانات إلى Aspose. الاستثناء الوحيد هو [ترخيص بنظام القياس](https://purchase.aspose.com/faqs/licensing/metered): إذا استخدمته، يتم معالجة معلومات استخدام الـ API فقط.
* مكونات Aspose تعمل في نفس سياق المستخدم كالتطبيقات العادية. لذلك لا تشكل مكونات Aspose خطرًا على موارد النظام الحيوية. علاوة على ذلك، عندما يفتح مكون Aspose مستندًا، لا يتم تشغيل الماكرو تلقائيًا.
* المخاطر الكامنة أو المرتبطة بحزمة Microsoft Office لا تنطبق على مكونات Aspose، لذا فإن منتجات Aspose آمنة جدًا.

## **اعتمادات NuGet**

تعتمد Aspose.Slides لـ .NET على الحزم التي تنشرها Microsoft على NuGet. تختلف الاعتمادات بحسب الحزمة وإطار الهدف:

| الحزمة | إطار الهدف | الاعتمادات |
|---|---|---|
| Aspose.Slides.NET | `net462` | System.Text.Json |
| Aspose.Slides.NET | `net6.0` | System.Drawing.Common, System.Security.Cryptography.Xml |
| Aspose.Slides.NET | `netstandard2.0` | System.Drawing.Common, System.Security.Cryptography.Xml, System.Text.Encoding.CodePages, System.Text.Json |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | System.Security.Cryptography.Xml |

قائمة **الاعتمادات** في صفحات [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) و[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) على NuGet تُظهر الحد الأدنى لإصدار كل اعتماد لكل إصدار.

عند إضافة Aspose.Slides إلى مشروع، يقوم NuGet أيضًا باستعادة اعتمادات هذه الحزم. لسرد كل حزمة يستعيدها مشروعك، بما في ذلك الاعتمادات المتعاقبة، شغّل هذا الأمر في مجلد المشروع:

```bash
dotnet list package --include-transitive
```

للتحقق من نفس مجموعة الحزم ضد الثغرات المعروفة، شغّل:

```bash
dotnet list package --vulnerable --include-transitive
```

لطُرُق أخرى لتدقيق حزم NuGet، راجع [Auditing package dependencies for security vulnerabilities](https://learn.microsoft.com/en-us/nuget/concepts/auditing-packages).

## **مكونات الطرف الثالث**

تتضمن Aspose.Slides شفرة من مكونات مفتوحة المصدر من طرف ثالث. وهي جزء من المنتج، ليست حزم NuGet منفصلة، لذا فإن الأدوات التي تقرأ فقط اعتمادات NuGet لا تعرضها. يحتوي كلا الحزمتين على الملف *thirdpartylicenses.Aspose.Slides.for.NET.pdf*، الذي يسرد المكونات وترخيصها:

| المكون | الترخيص المذكور في الإشعار |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |
| Skia | BSD-style license |
| HarfBuzz | "Old MIT" license |
| Boost | Boost Software License 1.0 |
| Double Conversion | BSD-style license |
| ICU (International Components for Unicode) | Unicode copyright and terms of use |

## **الأسئلة الشائعة**

**ما الأنظمة المستخدمة لمراقبة الثغرات في شفرة Aspose؟**

نقوم بإجراء تحليل ثابت للشفرة لكل إصدار من Aspose.Slides. يمكننا توفير تقارير أمان تُثبت أن شفرة Aspose.Slides تتوافق مع OWASP Top 10.

**هل تستخدم Aspose.Slides حزمًا خارجية؟**

نعم. تعتمد على حزم Microsoft NuGet المذكورة في [اعتمادات NuGet](#nuget-dependencies)، وتضم المكونات الطرفية المذكورة في [مكونات الطرف الثالث](#third-party-components). أدرج كليهما في مراجعة الأمان الخاصة بك، واستخدم `dotnet list package --vulnerable --include-transitive` للتحقق من حزم NuGet التي يستعيدها مشروعك.