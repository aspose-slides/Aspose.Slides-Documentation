---
title: تشغيل Aspose.Slides لـ .NET في دوكر
linktitle: دوكر
type: docs
weight: 140
url: /ar/net/how-to-run-aspose-slides-in-docker/
keywords:
- دوكر
- دوكرفيل
- حاوية دوكر
- بناء متعدد المراحل
- صورة الحاوية
- لينكس
- أوبونتو
- ألباين
- libfontconfig
- libgdiplus
- خطوط
- تحويل PDF
- بوربوينت
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إنشاء وتشغيل تطبيق كونسول Aspose.Slides لـ .NET داخل دوكر: Dockerfile متعدد المراحل على صور .NET الرسمية، مكتبات لينكس والخطوط المطلوبة، وكيفية نسخ الملفات المُولَّدة إلى جهازك."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تشغيل Aspose.Slides for .NET داخل حاوية Docker. تقوم بإنشاء تطبيق كونسول صغير ينشئ عرضًا تقديميًا يحتوي على مربع نص ويحولّه إلى PDF، وتعبئته باستخدام Dockerfile متعدد المراحل على صور .NET الرسمية من Microsoft، ثم تشغيله، ونسخ الملفات التي تم توليدها إلى جهازك. كما تُدرج المقالة مكتبات Linux والخطوط التي يحتاجها Aspose.Slides داخل الحاوية وتختتم بنسخة مخصصة لـ Alpine Linux.

كل ما تحتاجه هو Docker على جهازك. .NET SDK جزء من صورة البناء، لذا لا تحتاج إلى تثبيته. لتثبيت Docker، انظر [احصل على Docker](https://docs.docker.com/get-started/get-docker/).

## **اختر الحزمة وصورة الأساس**

صور الحاوية الافتراضية لـ .NET 10 تستند إلى Ubuntu 24.04. على هذه الصور، استخدم حزمة [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/). تتطلب مكتبة `fontconfig`، ولا تحتوي صورة تشغيل .NET على هذه المكتبة ولا أي خطوط، لذا يقوم Dockerfile في هذه المقالة بتثبيتهما.

لا تعمل Aspose.Slides.NET6.CrossPlatform على Alpine Linux. بالنسبة للصور المعتمدة على Alpine، استخدم حزمة [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) مع `libgdiplus`، كما هو موضح في [تشغيل على Alpine Linux](#run-on-alpine-linux). تُقارن صفحة [التثبيت](/slides/ar/net/installation/) بين الحزمتين.

## **إنشاء المشروع**

أنشئ مجلدًا باسم *HelloSlidesDocker* وأضف الملفات الثلاثة التالية إليه.

*HelloSlidesDocker.csproj* يصف تطبيق كونسول لـ .NET 10، نسخة صور الحاوية المستخدمة أدناه، ويشير إلى Aspose.Slides.NET6.CrossPlatform. عيّن نسخة الحزمة إلى أحدث نسخة مُدرجة في [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/).

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Aspose.Slides.NET6.CrossPlatform" Version="26.9.0" />
  </ItemGroup>

</Project>
```

*Program.cs* ينشئ [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)، يضيف مستطيلًا يحتوي على نص إلى الشريحة الأولى، ويحفظ العرض مرتين باستخدام طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/): كـ PPTX وكم ملف PDF. يذهب كلا الملفين إلى مجلد *output* داخل دليل العمل. ثم يقوم التطبيق بسرد الخطوط التي تم استبدالها أثناء إنشاء PDF، باستخدام [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/)، لتتمكن من معرفة ما إذا كانت الحاوية تحتوي على الخطوط التي يستخدمها العرض.

```c#
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var outputFolder = "output";
Directory.CreateDirectory(outputFolder);

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello from a Docker container!";

var pptxPath = Path.Combine(outputFolder, "hello.pptx");
var pdfPath = Path.Combine(outputFolder, "hello.pdf");
presentation.Save(pptxPath, SaveFormat.Pptx);
presentation.Save(pdfPath, SaveFormat.Pdf);

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"Font substitution: {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

Console.WriteLine($"Saved {pptxPath} and {pdfPath}");
```

*.dockerignore* يحتفظ بمجلدات *bin* و *obj* من بناء محلي، ومخرجات تشغيلات سابقة، خارج سياق بناء Docker، بحيث يتم بناء الصورة من ملفات المصدر فقط.

```text
bin/
obj/
output/
```

## **كتابة Dockerfile**

أضف ملفًا باسم *Dockerfile* إلى نفس المجلد:

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY HelloSlidesDocker.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish --no-restore -c Release -o /app

FROM mcr.microsoft.com/dotnet/runtime:10.0
RUN apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
```

يحتوي الملف على مرحلتين:

- **مرحلة البناء** تبدأ من صورة .NET SDK. تنسخ ملف المشروع وتستعيد حزم NuGet أولاً، بحيث يعيد Docker استخدام هذه الطبقة ما لم يتغير ملف المشروع. ثم تنسخ شفرة المصدر وتنشر التطبيق إلى */app*.
- **مرحلة التشغيل** تبدأ من صورة .NET runtime الأصغر، التي لا تحتوي على SDK، وتنسخ فقط التطبيق المنشور. تقوم بتثبيت حزمتين:
  - `libfontconfig1`: يقوم Aspose.Slides.NET6.CrossPlatform بتحميل هذه المكتبة عند البدء. بدونها يتوقف التطبيق بـ `DllNotFoundException` يذكر `libfontconfig.so.1`.
  - `fonts-dejavu-core`: لا تحتوي صورة التشغيل على أي خطوط، وتحتاج Aspose.Slides إلى حد أدنى من الخطوط المثبتة لرسم النص؛ بدون أي خط يتوقف التحويل بـ `InvalidOperationException: Cannot find any fonts installed on the system.` يُرسم النص بخط بديل إذا لم يُثبت الخط. خطوط DejaVu مجموعة صغيرة تجعل النص يُعرض؛ لرؤية العروض التقديمية بالخطوط المصممة لها، راجع [نشر الخطوط](/slides/ar/net/deploy-fonts/).

يؤدي `--no-install-recommends` وإزالة قوائم الحزم إلى الحفاظ على حجم الصورة صغيرًا. السطور الأخيرة تنشئ مجلد *output*، وتعطيه للمستخدم غير الجذر `app` الذي تُعرّف صور .NET الرسمية (معرف المستخدم في المتغير `APP_UID`)، وتشغل التطبيق ذلك المستخدم.

لتطبيق ASP.NET Core، ابدأ مرحلة التشغيل من `mcr.microsoft.com/dotnet/aspnet:10.0` بدلاً من ذلك. هو مبني على نفس صورة Ubuntu، لذا تحتاج نفس الحزم.

## **بناء وتشغيل الحاوية**

افتح نافذة طرفية في مجلد *HelloSlidesDocker*. قم ببناء الصورة، ثم شغّل حاوية منها:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

يحمّل البناء الأول صور الأساس وحزم NuGet، لذا يستغرق وقتًا أطول من البنايات اللاحقة. تشغّل الحاوية التطبيق وتتوقف. تطبع ما يلي:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

السطر الأول يظهر أن النص يستخدم Calibri، الخط الافتراضي للعرض التقديمي الجديد، وأن Calibri غير مثبت في الصورة، لذا رسم Aspose.Slides النص باستخدام DejaVu Sans. النص في ملف PDF هو نص قابل للتحديد فعلًا بهذا الخط. بدون ترخيص، يضيف Aspose.Slides أيضًا علامة تقييم مائية إلى كل شريحة يتم حفظها؛ راجع [الترخيص](/slides/ar/net/licensing/).

## **نسخ المخرجات إلى جهازك**

الملفات موجودة في مجلد */app/output* داخل الحاوية المتوقفة. انسخها إلى مجلد *output* على جهازك، ثم احذف الحاوية:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

هاتان الأمران يعملان بنفس الطريقة في Bash وPowerShell وWindows Command Prompt.

على Linux، يمكنك بدلاً من ذلك ربط مجلد من جهازك داخل الحاوية، بحيث يكتب التطبيق ملفاته هناك مباشرةً:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

خياري `--user` يشغّلان التطبيق بمعرفات المستخدم والمجموعة الخاصة بك، بحيث يمكنه الكتابة إلى المجلد الذي أنشأته وتكون الملفات مملوكة لك. `--rm` يحذف الحاوية عند توقفها.

## **التشغيل على Alpine Linux**

لتشغيل التطبيق في صورة معتمدة على Alpine، استبدل الحزمة بـ Aspose.Slides.NET وغيّر مرحلة التشغيل. تبقى مرحلة البناء كما هي.

1. في *HelloSlidesDocker.csproj*، استبدل مرجع الحزمة:

   ```xml
   <PackageReference Include="Aspose.Slides.NET" Version="26.9.0" />
   ```

2. في *Program.cs*، أضف هذا السطر بعد توجيهات `using`، قبل أول استدعاء لـ Aspose.Slides. يفعّل الدعم لـ System.Drawing على Linux الذي يستخدمه Aspose.Slides.NET:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

3. في *Dockerfile*، استبدل مرحلة التشغيل (كل شيء من سطر `FROM` الثاني) بـ:

   ```dockerfile
   FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
   ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
   RUN apk add --no-cache icu-libs libgdiplus font-dejavu
   WORKDIR /app
   COPY --from=build /app .
   RUN mkdir output && chown $APP_UID output
   USER $APP_UID
   ENTRYPOINT ["dotnet", "HelloSlidesDocker.dll"]
   ```

تثبت مرحلة Alpine ثلاث حزم وتغيّر إعدادًا واحدًا:

- `libgdiplus` هي مكتبة الرسوم التي يستخدمها Aspose.Slides.NET على Linux.
- `font-dejavu` تزود الخطوط. بدون أي خط، يتوقف التحويل بـ `System.ArgumentException: Font '?' cannot be found`.
- `icu-libs` و`DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false` يقدمان بيانات الثقافة. تعمل صور .NET على Alpine في وضع عدم الثبات الثقافي (globalization-invariant) بشكل افتراضي، وفي ذلك الوضع يتوقف Aspose.Slides بـ `CultureNotFoundException` للغة `en-US`.

قم ببناء التطبيق وتشغيله ونسخ المخرجات باستخدام نفس الأوامر كما هو موضح أعلاه. في هذه الصورة، يطبع التطبيق السطر `Saved` فقط: مع Aspose.Slides.NET على Linux، يختار fontconfig البديل للخط المفقود، ولا تُدرج [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) ذلك في القائمة. يوضح [نشر الخطوط](/slides/ar/net/deploy-fonts/) كيفية التحقق من الخط المستخدم.

## **الأسئلة المتكررة**

**يتوقف التطبيق بالرسالة "Unable to load shared library 'libaspose.slides.drawing.capi…'". ما المفقود؟**

على صور Ubuntu و Debian، الحزمة `libfontconfig1`؛ الرسالة تُظهر `libfontconfig.so.1` كملف لم يمكن فتحه. على Alpine Linux، تعني الرسالة أن Aspose.Slides.NET6.CrossPlatform قيد الاستخدام؛ استبدله بـ Aspose.Slides.NET كما هو موضح في [تشغيل على Alpine Linux](#run-on-alpine-linux).

**لماذا يكون النص في ملف PDF بخط مختلف عن PowerPoint؟**

الخطوط التي يستخدمها العرض التقديمي غير مثبتة في الصورة، لذا يرسم Aspose.Slides النص بخط بديل. يذكر مخرج التطبيق كل خط تم استبداله. توضح صفحة [نشر الخطوط](/slides/ar/net/deploy-fonts/) كيفية تثبيت الخطوط في الصورة أو تحميلها من مجلد التطبيق.

**هل أحتاج إلى .NET SDK على جهازي؟**

لا. مرحلة البناء تُترجم التطبيق داخل صورة SDK. تحتاج إلى SDK فقط إذا أردت بناء وتشغيل التطبيق خارج Docker؛ انظر [التثبيت](/slides/ar/net/installation/).