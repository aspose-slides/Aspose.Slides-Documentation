---
title: متطلبات النظام
type: docs
weight: 60
url: /ar/net/system-requirements/
keywords:
- متطلبات النظام
- المنصات المدعومة
- أطر العمل المستهدفة
- .NET Framework
- .NET Standard
- libgdiplus
- fontconfig
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تحقق مما تحتاجه Aspose.Slides لـ .NET قبل تثبيته: الأطر التي تستهدفها كل حزمة NuGet، أنظمة التشغيل والمعالجات المدعومة، والمكتبات والخطوط التي يتطلبها Linux."
---
## **مقدمة**

Aspose.Slides for .NET هي مكتبة مستقلة: لا تحتاج إلى Microsoft PowerPoint أو Microsoft Office. تم نشرها كحزمتين على NuGet، [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) و[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/). كلاهما يقدمان مساحات الأسماء والفئات نفسها في Aspose.Slides؛ يختلفان في الإطارات المستهدفة وطريقة رسم الشرائح، مما يحدّد أين يتم تشغيلهما وما يلزم.

تُظهر هذه المقالة إصدارات .NET والمنصات التي يدعمها كل حزمة، والمكتبات والنُصُوع التي يحتاجها Linux، وتختتم ببرنامج قصير يتحقق من إعدادك. لإضافة حزمة إلى مشروع، انظر [التثبيت](/slides/ar/net/installation/).

## **الإصدارات المدعومة من .NET**

كل حزمة تحتوي على بنية واحدة من Aspose.Slides لكل إطار هدف، وتختار NuGet البنية التي تتطابق مع إطار هدف مشروعك.

| الحزمة | أطر العمل المستهدفة في الحزمة | يمكن لمشروعك استهدافه |
|---|---|---|
| Aspose.Slides.NET | `net462`, `net6.0`, `netstandard2.0` | .NET Framework 4.6.2 أو أحدث؛ .NET 6 أو أحدث، بما في ذلك .NET 8 و.NET 9 و.NET 10 |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | .NET 6 أو أحدث، بما في ذلك .NET 8 و.NET 9 و.NET 10 |

البنية `netstandard2.0` تسمح لمكتبة فئات .NET Standard 2.0 بالاستشهاد بـ Aspose.Slides.NET. التطبيق الذي يستخدم such مكتبة يُشغل البنية التي تتطابق مع إطار هدف التطبيق نفسه: مثال، تطبيق .NET 8 يُشغل البنية `net6.0`.

## **أنظمة التشغيل والمعالجات المدعومة**

**Aspose.Slides.NET** يحتوي فقط على كود مُدار غير معتمد على المعالج (AnyCPU)، لذا يعمل على معمارية المعالج الخاصة بوقت تشغيل .NET الذي يحملها. يرسم الشرائح عبر مكتبة Microsoft System.Drawing.Common، التي تدعمها Microsoft [فقط على Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only). على Linux، يحتاج Aspose.Slides.NET إلى مكتبة `libgdiplus` ومفتاح تشغيل، موضحين في [Linux](#linux). يعمل على توزيعات Linux التي تقدم `libgdiplus`، مثل Debian وUbuntu وAlpine Linux.

**Aspose.Slides.NET6.CrossPlatform** يرسم الشرائح بمحرك رسومي خاص به. المحرك هو مكتبة أصلية تحتويها الحزمة في بنية واحدة لكل منصة، لذا تعمل الحزمة فقط على هذه المنصات:

| نظام التشغيل | المعالجات | ملاحظات |
|---|---|---|
| Windows | x86, x64 | لا يدعم Windows على ARM64. |
| Linux | x64, ARM64 | يتطلب glibc 2.23 أو أحدث على x64 وglibc 2.39 أو أحدث على ARM64. |
| macOS | x64 (Intel), ARM64 (Apple silicon) |  |

Aspose.Slides.NET6.CrossPlatform لا يعمل على Alpine Linux أو توزيعات أخرى مبنية على musl بدلًا من glibc، ولا على توزيعات ذات glibc أقدم، مثل CentOS 7. استخدم Aspose.Slides.NET على تلك الأنظمة.

على Windows، تستخدم المكتبة الأصلية لـ Aspose.Slides.NET6.CrossPlatform runtime Microsoft Visual C++ (*MSVCP140.dll* و*VCRUNTIME140.dll*، بالإضافة إلى *VCRUNTIME140_1.dll* على x64). إذا كانت هذه الملفات مفقودة على الجهاز الهدف، ثبّت [Microsoft Visual C++ Redistributable](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170).

## **Linux**

كلا الحزمتين تحتاجان إلى مكتبات نظام إضافية على Linux. دونها، المثال الأول في [إنشاء عروض تقديمية](/slides/ar/net/create-presentation/) سيفشل باستثناء بدلاً من حفظ الملف. الأوامر أدناه مخصصة لـ Debian وUbuntu؛ على هذه التوزيعات، كل مكتبة تجلب أيضًا خطوط DejaVu (`fonts-dejavu-core`)، لذا يُعرض النص بدون حزم خطوط إضافية.

### **Aspose.Slides.NET6.CrossPlatform**

مكتبة Linux الخاصة بالحزمة تتطلب مكتبة `fontconfig`:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
```

بدونها، إنشاء [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) سيفشل باستثناء `TypeInitializationException` الذي يحتوي على `DllNotFoundException` يُشير إلى أن `libfontconfig.so.1` لا يمكن فتحه.

قد لا تتضمن صور الحاوية الأساسية `fontconfig`. صورة AWS Lambda الأساسية لـ .NET 8، على سبيل المثال، لا تحتوي على `fontconfig` ولا على أي خطوط. في صورة حاوية مبنية عليها، نفّذ `dnf install -y fontconfig`، والذي يثبّت أيضًا خطوط Noto Sans.

### **Aspose.Slides.NET**

الحزمة تحتاج إلى شيئين على Linux:

1. مكتبة `libgdiplus`:

   ```bash
   sudo apt-get update && sudo apt-get install -y libgdiplus
   ```

2. مفتاح `System.Drawing.EnableUnixSupport`، يُفعَّل في بداية التطبيق قبل أي استدعاء لـ Aspose.Slides. في *Program.cs* يحتوي على عبارات أعلى المستوى، ضع المفتاح بعد توجيهات `using`:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

بدون `libgdiplus`، حفظ عرض تقديمي سيفشل باستثناء `TypeInitializationException` يحتوي على `DllNotFoundException` يُشير إلى أنه لا يمكن تحميل `libgdiplus`. بدون المفتاح، يكون الاستثناء الداخلي `PlatformNotSupportedException: System.Drawing.Common is not supported on non-Windows platforms`.

{{% alert color="warning" title="Warning" %}}
المفتاح يعمل فقط مع System.Drawing.Common الإصدار 6، وهو الإصدار الذي يعتمد عليه Aspose.Slides.NET. أزالت Microsoft هذا المفتاح في System.Drawing.Common الإصدار 7. إذا كان مشروعك يستشهد بـ System.Drawing.Common الإصدار 7 أو أحدث، مباشرة أو عبر حزمة أخرى، سيفشل Aspose.Slides.NET على Linux مع `PlatformNotSupportedException` حتى مع تثبيت `libgdiplus` وتفعيل المفتاح. في هذه الحالة، استخدم Aspose.Slides.NET6.CrossPlatform.
{{% /alert %}}

### **Alpine Linux**

على Alpine Linux، استخدم Aspose.Slides.NET مع المفتاح الموصوف أعلاه. عادةً لا تحتوي صور Alpine على أي خطوط، و`libgdiplus` وحده لا يثبّت أي خطوط، لذا ثبّت `libgdiplus` مع حزمة خطوط واحدة على الأقل. بدون خطوط، حفظ عرض تقديمي سيفشل بهذا الخطأ:

```text
System.ArgumentException: Font '?' cannot be found.
```

**الخيار 1: خطوط DejaVu**

الخيار الموصى به هو حزمة `ttf-dejavu`:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

في إصدارات Alpine الحالية، تثبت `ttf-dejavu` حزمة `font-dejavu`، التي تثبت أيضًا `fontconfig` وأدوات الخطوط التي تعتمد عليها.

**الخيار 2: خطوط Microsoft الأساسية**

إذا كانت عروضك تستخدم خطوط Microsoft مثل Arial أو Times New Roman أو Courier New أو Verdana، ثبّت خطوط Microsoft الأساسية بدلاً من ذلك. خطوة `update-ms-fonts` تُنزل الخطوط أثناء بناء الصورة، لذا يحتاج البناء إلى اتصال إنترنت:

```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

### **دعم العولمة**

كلا الحزمتين يحتاجان إلى دعم عولمة .NET، والذي توفره .NET على Linux عبر مكتبات ICU. في [وضع عدم التنوّع العالمي]https://learn.microsoft.com/en-us/dotnet/core/runtime-config/globalization)، إنشاء [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) سيفشل باستثناء `CultureNotFoundException: Only the invariant culture is supported in globalization-invariant mode`.

بعض صور الحاوية تُفعّل هذا الوضع. على سبيل المثال، صور وقت تشغيل .NET لـ Alpine Linux (`runtime-deps`، `runtime`، و`aspnet`) تُعيّن `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=true` ولا تشمل ICU. في صورة مبنية عليها، ثبّت ICU وأوقف الوضع:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

تأكد أيضًا من أن ملف المشروع الخاص بك لا يضبط خاصية `InvariantGlobalization` إلى `true`.

## **تحقق من إعدادك**

للتحقق من أن الحزمة ومتطلبات تشغيلها موجودة، شغّل برنامجًا يحفظ عرضًا تقديميًا ويرسم شريحة إلى صورة. الحفظ والرسم يستخدمان مكتبة الرسوميات والخطوط، وهو ما توفره متطلبات Linux أعلاه.

أنشئ تطبيقاً كونسولياً وأضف الحزمة كما هو موضح في [التثبيت](/slides/ar/net/installation/)، استبدل محتويات *Program.cs* بالكود أدناه، وشغّل `dotnet run`. إذا استخدمت Aspose.Slides.NET على Linux، أضف عبارة المفتاح `System.Drawing.EnableUnixSupport` كما هو موضح في [Linux](#linux) بعد توجيهات `using`. يستخدم البرنامج عبارات أعلى المستوى وإعلانات `using`، والتي تحتاج إلى C# 9 أو أحدث. المشاريع التي تستهدف .NET 6 أو أحدث تستخدم نسخة C# أحدث افتراضيًا؛ في مشروع يستهدف .NET Framework، أضف `<LangVersion>latest</LangVersion>` إلى `PropertyGroup` في ملف المشروع.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);

using var image = slide.GetImage(1f, 1f);
image.Save("hello.png", ImageFormat.Png);
```

البرنامج يضيف مستطيلًا بنص إلى الشريحة الأولى ويحفظ العرض باسم *hello.pptx* باستخدام طريقة [Save](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/save/). ثم يرسم الشريحة باستخدام [GetImage](https://reference.aspose.com/slides/ar/net/aspose.slides/slide/getimage/) ويحفظ النتيجة باسم *hello.png* باستخدام [IImage.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/iimage/save/) بتنسيق [ImageFormat.Png](https://reference.aspose.com/slides/ar/net/aspose.slides/imageformat/). عوامل المقياس 1 تُولد بكسل واحد لكل نقطة، لذا تصبح الشريحة الافتراضية ذات 720 × 540 نقطة صورة 720 × 540 بكسل، مع النص مرئياً داخل المستطيل. بدون ترخيص، يحمل كلا الملفين علامة مائية تجريبية؛ راجع [الترخيص](/slides/ar/net/licensing/). إذا كان هناك متطلب مفقود، سيتوقف البرنامج بأحد الاستثناءات الموضحة في [Linux](#linux).

## **أدوات التطوير**

يمكنك بناء تطبيقات تستخدم Aspose.Slides بأي أداة تدعم إطار هدف مشروعك: .NET SDK وواجهة سطر الأوامر `dotnet` على Windows وLinux وmacOS، أو Visual Studio على Windows. يصف [التثبيت](/slides/ar/net/installation/) كلا الخيارين.

## **الأسئلة الشائعة**

**هل أحتاج إلى تثبيت Microsoft PowerPoint للتحويل والرسم؟**

لا، لا يلزم PowerPoint. Aspose.Slides هو محرك مستقل لـ [إنشاء](/slides/ar/net/create-presentation/)، تعديل، [تحويل](/slides/ar/net/convert-presentation/)، و[رسم](/slides/ar/net/convert-powerpoint-to-png/) العروض التقديمية.

**أي حزمة يجب أن أستخدم؟**

استخدم Aspose.Slides.NET على Windows وAspose.Slides.NET6.CrossPlatform على Linux وmacOS. على Alpine Linux، وعلى أنظمة Linux التي يكون glibc لديها أقدم من الإصدارات المذكورة أعلاه، وفي المشاريع التي تستهدف .NET Framework، استخدم Aspose.Slides.NET. أضف واحدة فقط من الحزمتين إلى المشروع.

**ما الخطوط المطلوبة للرسم الصحيح؟**

يجب أن تكون الخطوط المستخدمة في العرض، أو بدائل مناسبة، متاحة في نظام التشغيل. على Linux وmacOS، ثبّت حزم الخطوط التي تحتاجها عروضك للحصول على رسم متسق. على Alpine Linux، ثبّت حزمة خطوط واحدة على الأقل بالإضافة إلى `libgdiplus`، كما هو موضح في [Alpine Linux](#alpine-linux).

**لماذا يُظهر خط مخصص كبديل أو نص مفقود على Linux؟**

إذا كان ملف الخط يحتوي على سجلات جدول أسماء غير متسقة أو تالفة، قد يختار مكدس مطابقة الخطوط في Linux (FreeType/fontconfig) سجلًا غير صالح، مما يؤدي إلى عدم حل الخط. استخدم إصدار الخط مع سجلات جدول أسماء مصححة أو ثبّت بديلًا متسقًا لحل المشكلة.