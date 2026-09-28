---
title: حزمة متعددة المنصات لـ .NET 6 والإصدارات الأحدث
linktitle: حزمة متعددة المنصات
type: docs
weight: 235
url: /ar/net/net6/
keywords:
- Aspose.Slides.NET6.CrossPlatform
- متعددة المنصات
- دعم .NET 6
- Linux
- macOS
- fontconfig
- libgdiplus
- System.Drawing.Common
- CS0433
- AWS Lambda
- .NET
- C#
- Aspose.Slides
description: "تعرف على متى تستخدم حزمة Aspose.Slides.NET6.CrossPlatform: لماذا توجد، المنصات التي تعمل عليها، وما تحتاجه على Linux بدلاً من libgdiplus."
---
## **المقدمة**

Aspose.Slides for .NET تُصدر كحزمتين NuGet. [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) يرسم الشرائح عبر مكتبة System.Drawing.Common الخاصة بمايكروسوفت. [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) يرسمها باستخدام محرك الرسومات الخاص به بدلاً من ذلك. يوضح هذا المقال سبب وجود الحزمة الثانية، وأين تُشغل، وما تحتاجه على Linux، وكيف تتعايش مع System.Drawing.Common في مشروع واحد.

## **لماذا حزمة منفصلة**

مع .NET 6، مايكروسوفت تدعم System.Drawing.Common [فقط على Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only). نتيجة لذلك، على Linux تحتاج Aspose.Slides.NET إلى مفتاح `System.Drawing.EnableUnixSupport` بالإضافة إلى مكتبة `libgdiplus`، وتفشل إذا كان المشروع ي referencias System.Drawing.Common الإصدار 7 أو لاحق. توضح [System Requirements](/slides/ar/net/system-requirements/) هذه الشروط.

Aspose.Slides.NET6.CrossPlatform لا يستخدم System.Drawing.Common ولا `libgdiplus`. محرك الرسومات الخاص به مكتبة أصلية تحتويها الحزمة في بناء واحد لكل منصة مدعومة. كلا الحزمتين توفران نفس مساحات الأسماء والفئات في Aspose.Slides، لذا التحويل من إحداهما إلى الأخرى يغير فقط مرجع الحزمة، وليس الكود.

| | Aspose.Slides.NET | Aspose.Slides.NET6.CrossPlatform |
|---|---|---|
| الرسومات | System.Drawing.Common | محرك رسومات أصلي مضمن في الحزمة |
| إطارات الهدف | `net462`, `net6.0`, `netstandard2.0` | `net6.0` |
| متطلبات Linux | `libgdiplus` و المفتاح `System.Drawing.EnableUnixSupport` | `fontconfig` |
| Alpine Linux | مدعوم | غير مدعوم |

## **المنصات المدعومة**

Aspose.Slides.NET6.CrossPlatform يعمل مع .NET 6 والإصدارات الأحدث على هذه المنصات:

- **Windows**: x86 و x64. المكتبة الأصلية تستخدم وقت تشغيل Microsoft Visual C++؛ راجع [System Requirements](/slides/ar/net/system-requirements/).
- **Linux**: x64 مع glibc 2.23 أو أحدث، و ARM64 مع glibc 2.39 أو أحدث.
- **macOS**: x64 (Intel) و ARM64 (Apple silicon).

لا يعمل على Windows بمعمارية ARM64، ولا على Alpine Linux أو توزيعات أخرى مبنية على musl بدلاً من glibc، ولا على توزيعات ذات glibc أقدم مثل CentOS 7. استخدم Aspose.Slides.NET على تلك الأنظمة.

## **التثبيت على Linux**

على Linux، تحتاج الحزمة إلى مكتبة `fontconfig`، ولكن ليس `libgdiplus`. على Debian و Ubuntu، ثبّت `fontconfig` ثم أضف الحزمة إلى مشروعك:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

على Debian و Ubuntu، `libfontconfig1` يثبّت أيضاً خطوط DejaVu، لذا يُظهر النص دون الحاجة إلى حزم خطوط إضافية. بدون `fontconfig`، فشل إنشاء [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) مع `TypeInitializationException` الذي يحتوي على `DllNotFoundException` يُشير إلى أن `libfontconfig.so.1` لا يمكن فتحه. تتضمن [System Requirements](/slides/ar/net/system-requirements/) برنامجًا قصيرًا يتحقق من الإعداد.

## **السحابة ومضيفات الحاويات**

نظرًا لعدم احتياجه `libgdiplus`، فإن Aspose.Slides.NET6.CrossPlatform هو الحزمة المناسبة على مضيفات Linux التي لا يمكن فيها تثبيت `libgdiplus`. ما يزال يحتاج إلى `fontconfig` والخطوط، والتي قد تكون مفقودة في الصور القاعدية المصغرة. على سبيل المثال، لا تحتوي صورة قاعدة AWS Lambda لـ .NET 8 على أي منهما. في صورة حاوية مبنية عليها، نفّذ `dnf install -y fontconfig`، والذي يثبّت أيضاً خطوط Noto Sans.

لإرشادات حول منصات السحابة المحددة، راجع [Aspose.Slides on Cloud Platforms](/slides/ar/net/slides-on-cloud-platforms/).

## **استخدام System.Drawing.Common في نفس المشروع (CS0433)**

يمكن لمشروع يستخدم Aspose.Slides.NET6.CrossPlatform أيضًا الإشارة إلى System.Drawing.Common، إما مباشرة أو عبر حزمة أخرى. الإصدار الحالي من Aspose.Slides لا يُظهر أي أنواع عامة في مساحات أسماء `System`، لذا لا تتصادم المكتبتان، ويمكنك استيراد مساحات الأسماء `Aspose.Slides` و `System.Drawing` في نفس الملف.

إذا أظهر المترجم الخطأ CS0433 لأن نوعًا مثل `Image` أو `Graphics` موجود في كل من Aspose.Slides و System.Drawing.Common، فمشروعك يستخدم إصدارًا أقدم من Aspose.Slides. حدّث الحزمة إلى أحدث نسخة. تُعيد Aspose.Slides الصور المرسومة ككائنات [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/)، والتي توصف في [Modern API](/slides/ar/net/modern-api/).

## **الأسئلة الشائعة**

**هل أحتاج إلى تغيير الكود عندما أتحول من Aspose.Slides.NET إلى Aspose.Slides.NET6.CrossPlatform؟**

لا. كلا الحزمتين توفران نفس مساحات الأسماء والفئات في Aspose.Slides، لذا ما عليك سوى استبدال مرجع الحزمة. Aspose.Slides.NET6.CrossPlatform لا يحتاج مفتاح `System.Drawing.EnableUnixSupport`. أضف واحدة فقط من الحزمتين إلى المشروع.

**هل يمكنني استخدام Aspose.Slides.NET6.CrossPlatform في مشروع .NET Framework؟**

لا. الحزمة تستهدف فقط .NET 6 والإصدارات الأحدث. بالنسبة إلى .NET Framework 4.6.2 وما بعده، استخدم Aspose.Slides.NET.