---
title: نشر الخطوط لـ Aspose.Slides على لينكس وفي Docker
linktitle: نشر الخطوط
type: docs
weight: 145
url: /ar/net/deploy-fonts/
keywords:
- نشر الخطوط
- تثبيت الخطوط
- خطوط في Docker
- خطوط على لينكس
- خطوط مفقودة
- استبدال الخطوط
- خطوط مايكروسوفت الأساسية
- ttf-mscorefonts-installer
- خطوط مخصصة
- خط افتراضي
- خادم
- حاوية
- تحويل PDF
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "نشر الخطوط لـ Aspose.Slides لـ .NET على خوادم لينكس وفي حاويات Docker: تحقق من الخطوط المستبدلة، ثبّت حزم الخطوط على Debian وUbuntu وAlpine، أضف ملفات الخطوط الخاصة بك، وحدد خطًا افتراضيًا."
---
## **نظرة عامة**

Aspose.Slides يرسم النص بالخطوط المتاحة له عند تقديم عرض تقديمي، على سبيل المثال عند تحويل الشرائح إلى PDF أو إلى صور. عادةً ما يحتوي سطح مكتب Windows على الخطوط التي تستخدمها العروض التقديمية. خوادم Linux والحاويات عادةً ما تحتوي على خطوط قليلة أو لا تحتوي على أي خطوط، لذلك يرسم Aspose.Slides النص بخط بديل. الخط البديل له أشكال أحرف وعروض مختلفة، لذا قد يتم لف السطر بشكل مختلف ويتجاوز النص الشكل المحدد، ولا يتم رسم الأحرف التي يفتقر إليها الخط البديل بشكل صحيح. إذا لم يتم تثبيت أي خط على الإطلاق، ستتوقف عملية التحويل مع ظهور خطأ.

توضح هذه المقالة كيفية فحص الخطوط التي يستبدلها Aspose.Slides، وكيفية تثبيت الخطوط على Debian وUbuntu وAlpine Linux، وكيفية إضافة ملفات الخط الخاصة بك، وكيفية تعيين الخط المستخدم عندما يكون الخط مفقودًا. تُشغَّل الأمثلة في Docker على صور .NET الرسمية، كما في [تشغيل Aspose.Slides لـ .NET في Docker](/slides/ar/net/how-to-run-aspose-slides-in-docker/). أوامر الحزمة هي تعليمات Dockerfile؛ على خادم Linux، شغِّل نفس الأوامر كجذر.

بالنسبة إلى واجهة برمجة تطبيقات الخطوط نفسها، مثل تضمين الخطوط في عرض تقديمي وقواعد الاستبدال والعودة الاحتياطية، راجع [خطوط PowerPoint](/slides/ar/net/powerpoint-fonts/).

## **التحقق من الخطوط المستبدلة**

تقرير التطبيق السطري التالي يُظهر الخطوط التي يستبدلها Aspose.Slides في البيئة الحالية. أنشئ مجلدًا اسمه *FontCheck* وأضف الملفات أدناه إليه.

*FontCheck.csproj* يشار إلى [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/)، الحزمة المخصصة لـ Debian وUbuntu. كما ينسخ ملفات مجلد *fonts* الاختياري إلى مخرجات التطبيق؛ يستخدم قسم [تحميل الخطوط من مجلد التطبيق](#load-fonts-from-the-application-folder) ذلك.

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
    <None Update="fonts/**" CopyToOutputDirectory="PreserveNewest" />
  </ItemGroup>

</Project>
```

*Program.cs* يضيف مربع نص واحد لكل اسم خط إلى شريحة ويعين الخط عبر خاصية [LatinFont](https://reference.aspose.com/slides/ar/net/aspose.slides/baseportionformat/latinfont/). تأتي أسماء الخطوط من سطر الأوامر؛ بدون وسائط، يتحقق التطبيق من Calibri وArial وTimes New Roman. يطبع المجلدات التي يبحث فيها Aspose.Slides عن الخطوط ([FontsLoader.GetFontFolders](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsloader/getfontfolders/))، يرسم الشريحة إلى *output/fonts.pdf*، ويطبع الاستبدالات التي يُبلغ عنها [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/ar/net/aspose.slides/ifontsmanager/getsubstitutions/). الخطوتان الاختياريتان في البداية، تحميل مجلد *fonts* وقراءة متغير `DEFAULT_FONT`، يتم شرحهما لاحقًا في هذه المقالة.

```c#
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

// الخطوط التي سيتم فحصها: وسائط سطر الأوامر، أو ثلاثة خطوط شائعة في Office.
var fontNames = args.Length > 0 ? args : new[] { "Calibri", "Arial", "Times New Roman" };

// حمّل ملفات الخطوط من مجلد الخطوط الموجود بجوار التطبيق، إذا كان موجودًا.
var appFontFolder = Path.Combine(AppContext.BaseDirectory, "fonts");
if (Directory.Exists(appFontFolder))
{
    FontsLoader.LoadExternalFonts(new[] { appFontFolder });
}

// استخدم الخط المذكور في متغيّر البيئة DEFAULT_FONT، إذا كان مُعيَّنًا، للنص الذي يفتقد الخط.
var loadOptions = new LoadOptions();
var defaultFont = Environment.GetEnvironmentVariable("DEFAULT_FONT");
if (!string.IsNullOrEmpty(defaultFont))
{
    loadOptions.DefaultRegularFont = defaultFont;
}

var fontFolders = FontsLoader.GetFontFolders().Distinct();
Console.WriteLine($"Font folders: {string.Join(", ", fontFolders)}");

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
for (var i = 0; i < fontNames.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50 + i * 80, 600, 60);
    shape.TextFrame.Text = $"This text is set in {fontNames[i]}.";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData(fontNames[i]);
}

Directory.CreateDirectory("output");
presentation.Save(Path.Combine("output", "fonts.pdf"), SaveFormat.Pdf);

var substitutions = presentation.FontsManager.GetSubstitutions().ToList();
if (substitutions.Count == 0)
{
    Console.WriteLine("No font substitutions.");
}
else
{
    Console.WriteLine("Font substitutions:");
    foreach (var substitution in substitutions)
    {
        Console.WriteLine($"  {substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
    }
}
```

*.dockerignore* يبقي نتائج البناء المحلي خارج سياق البناء:

```text
bin/
obj/
output/
```

*Dockerfile* يبني التطبيق باستخدام صورة .NET SDK ويشغّله على صورة .NET runtime. يثبت مرحلة التشغيل `libfontconfig1`، التي تحتاجها Aspose.Slides.NET6.CrossPlatform، وخطوط DejaVu. يشرح [تشغيل Aspose.Slides لـ .NET في Docker](/slides/ar/net/how-to-run-aspose-slides-in-docker/) كل توجيه.

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY FontCheck.csproj .
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
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

بناء الصورة وتشغيل الفحص:

```bash
docker build -t font-check .
docker run --rm font-check
```

الصورة تحتوي فقط على خطوط DejaVu، لذلك يتم استبدال الخطوط الثلاثة جميعًا بـ DejaVu Sans:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

للتحقق من خطوط عروضك التقديمية الخاصة، مرّر أسمائها كوسائط، على سبيل المثال `docker run --rm font-check "Segoe UI" Consolas`. لنسخ *output/fonts.pdf* من الحاوية، استخدم الأوامر في [نسخ الإخراج إلى جهازك](/slides/ar/net/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine).

## **تثبيت الخطوط على Debian وUbuntu**

### **خطوط Microsoft الأساسية**

حزمة `ttf-mscorefonts-installer` تُحمِّل وتثبِّت خطوط Microsoft الأساسية للويب، من بينها Arial وTimes New Roman وCourier New وVerdana وGeorgia وTrebuchet MS. الخطوط مرخصة وفقًا لاتفاقية ترخيص المستخدم النهائي (EULA) الخاصة بـ Microsoft، وتثبِّت الحزمة إياها فقط بعد قبول الـ EULA. لا يمكن لبناء Docker الرد على المطالبة، لذا يرفض المُثبت الـ EULA ولا يثبِّت أي خطوط، بينما لا يزال `apt-get install` يُظهر نجاحًا. قبل تثبيت الحزمة، قَبِل الـ EULA باستخدام `debconf-set-selections`.

في *Dockerfile*، استبدل جملة `RUN` التي تثبت الحزم في مرحلة التشغيل بـ:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

بناء الصورة وتشغيل الفحص مرة أخرى باستخدام الأمرين نفسه. الآن تم تثبيت Arial وTimes New Roman:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri، الخط الافتراضي للعرض التقديمي الذي تُنشئه Aspose.Slides، ليس من الخطوط الأساسية، لذا لا يزال يُستبدَل. راجع [تعيين خط افتراضي للخطوط المفقودة](#set-a-default-font-for-missing-fonts).

في Debian، الحزمة موجودة في مكوّن المستودع `contrib`، والذي لا تُفعَّله صور Debian؛ الصور الافتراضية لـ .NET 8 و.NET 9 تستند إلى Debian 12. فعّل `contrib` في نفس التعليمة:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

الصور المستندة إلى Ubuntu لـ .NET 10 تُفعِّل بالفعل `multiverse`، المكوّن الذي يحتوي على الحزمة.

### **حزم خطوط أخرى**

Debian وUbuntu تُقدِّم أيضًا خطوطًا مرخصة بحرية، على سبيل المثال:

| الحزمة | الخطوط |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif, and Mono, with the same metrics as Arial, Times New Roman, and Courier New |
| `fonts-crosextra-carlito` | Carlito, with the same metrics as Calibri |
| `fonts-crosextra-caladea` | Caladea, with the same metrics as Cambria |

ثبتها باستخدام `apt-get install` في نفس جملة `RUN`. لا يطبق Aspose.Slides.NET6.CrossPlatform أسماء الحلفيات للخطوط في تكوين Linux: حتى مع تثبيت `fonts-liberation`، يبقى النص بـ Arial يُرسم بالخط البديل العام، وليس بـ Liberation Sans. لاستخدام خط متوافق من الناحية القياسية بديلًا عن الخط المفقود، عيّنه كـ [خط افتراضي](#set-a-default-font-for-missing-fonts) أو أضف [قاعدة استبدال خطوط](/slides/ar/net/font-substitution/).

## **إضافة ملفات الخطوط الخاصة بك**

الخطوط التي لا تُضمّنها التوزيعات، مثل خطوط مؤسستك أو خطوط أخرى مرخص لك استخدامها على الخادم، يمكن إضافتها كملفات خطوط. ضع ملفات الخطوط، على سبيل المثال ملفات *.ttf*، في مجلد اسمه *fonts* داخل مجلد *FontCheck*. تستخدم الأمثلة أدناه ملفات Carlito، وهو خط له نفس مقاييس Calibri، يمكنك تنزيله من [Google Fonts](https://fonts.google.com/specimen/Carlito).

### **تثبيت الخطوط في مجلد الخطوط النظامي**

Aspose.Slides يقرأ الخطوط في المجلدات المطبوعة على سطر `Font folders`. لتثبيت خطوطك لكل التطبيقات في الصورة، انسخها إلى */usr/local/share/fonts*، المجلد المخصَّص للخطوط المُثبتة محليًا. أضف هذا التوجيه إلى مرحلة التشغيل في *Dockerfile*، بعد جملة `RUN` التي تثبت الحزم:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

### **تحميل الخطوط من مجلد التطبيق**

بدلاً من تثبيت الخطوط في الصورة، يمكنك شحنها مع التطبيق وتحميلها باستخدام [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsloader/loadexternalfonts/). تصبح الخطوط متاحةً فقط لـ Aspose.Slides، وتُنشر مع التطبيق. *FontCheck* يفعل ذلك: *FontCheck.csproj* ينسخ مجلد *fonts* إلى مخرجات التطبيق، و*Program.cs* يمرّر ذلك المجلد إلى `LoadExternalFonts` قبل إنشاء العرض التقديمي. يصف [خط مخصص](/slides/ar/net/custom-font/) الطرق الأخرى لتوفير الخطوط، مثل تحميلها من الذاكرة.

أعد بناء الصورة، ثم تحقق من Calibri وCarlito:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

الآن يظهر مجلد التطبيق بين مجلدات الخطوط، ولم يعد Carlito يُستبدَل:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

## **تعيين خط افتراضي للخطوط المفقودة**

عند فقدان خط، يستخدم Aspose.Slides بديلًا يختاره بنفسه. لاختيار بديلك، عيِّن خاصية [DefaultRegularFont](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/defaultregularfont/) لـ [LoadOptions](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/) ومرّر الخيارات إلى مُنشئ [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/). *FontCheck* يقرأ اسم الخط من متغيّر البيئة `DEFAULT_FONT`. مع تحميل Carlito، استخدمه للخطوط المفقودة:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

الآن يُرسم Calibri باستخدام Carlito، الذي تتمتع أحرفه بنفس عرض أحرف Calibri، لذا يحتفظ النص بكسور الأسطر:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Carlito
```

الخط الافتراضي يُستبدل كل خط مفقود. لتعيين خطوط فردية، مثل استبدال Arial بـ Liberation Sans وCalibri بـ Carlito، استخدم [قواعد استبدال الخطوط](/slides/ar/net/font-substitution/). القواعد تُغيّر النتيجة المرسومة، لكن `GetSubstitutions` لا يعكسها، لذا تحقق من الخطوط في ملف الإخراج بدلًا من ذلك. للنص الآسيوي، عيّن أيضًا [DefaultAsianFont](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/defaultasianfont/); راجع [الخط الافتراضي](/slides/ar/net/default-font/).

## **تثبيت الخطوط على Alpine Linux**

في Alpine Linux، استخدم حزمة Aspose.Slides.NET؛ يدرج [التشغيل على Alpine Linux](/slides/ar/net/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) التغييرات المطلوبة للمشروع. أجرِ نفس التغييرات على *FontCheck*: استبدل مرجع الحزمة، أضف بيان `SetSwitch` إلى *Program.cs*، واستخدم مرحلة التشغيل هذه، التي تثبت أيضًا خطوط Microsoft الأساسية:

```dockerfile
FROM mcr.microsoft.com/dotnet/runtime:10.0-alpine
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk add --no-cache icu-libs libgdiplus font-dejavu msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -f
WORKDIR /app
COPY --from=build /app .
RUN mkdir output && chown $APP_UID output
USER $APP_UID
ENTRYPOINT ["dotnet", "FontCheck.dll"]
```

`update-ms-fonts` يُحمِّل ويُثبِّت نفس خطوط Microsoft الأساسية كما في حزمة Debian وUbuntu، وتطبق عليها الـ EULA بنفس الطريقة. `fc-cache` يُحدّث ذاكرة الخطوط المؤقتة.

مع Aspose.Slides.NET على Linux، تختار مكتبة تكوين الخطوط (fontconfig) البديل للخط المفقود، ولا تُظهر `GetSubstitutions` ذلك، لذا يطبع *FontCheck* `No font substitutions.` لمعرفة الخط المستخدم لاسماً، اسأل fontconfig داخل الحاوية:

```bash
docker run --rm --entrypoint fc-match font-check Arial
```

مع تثبيت خطوط Microsoft الأساسية، يُستخدم Arial لخط Arial:

```text
Arial.ttf: "Arial" "Regular"
```

بدونها، عندما تُثبِّت جملة `RUN` فقط `icu-libs libgdiplus font-dejavu`، تطبع نفس الأمر:

```text
DejaVuSans.ttf: "DejaVu Sans" "Book"
```

## **الأسئلة الشائعة**

**لماذا يبدو العرض التقديمي مختلفًا عند تحويله على الخادم؟**

الخادم لا يمتلك الخطوط التي يستخدمها العرض، لذا يرسم Aspose.Slides النص بخط بديل له أحرف بعروض مختلفة. شغّل *FontCheck* بأسماء خطوط العرض لتعرف أي الخطوط تم استبدالها، ثم ثبِّت تلك الخطوط أو حمّلها من مجلد التطبيق.

**قمت بتثبيت ttf-mscorefonts-installer، لكن لا يزال Arial يُستبدَل. لماذا؟**

لم يتم قبول الـ EULA قبل تثبيت الحزمة، لذا تخطى المُثبت الخطوط. أضف أمر `debconf-set-selections` قبل `apt-get install`، كما هو موضح في [خطوط Microsoft الأساسية](#microsoft-core-fonts)، وأعد بناء الصورة.

**هل يحتاج الحاسوب الذي يفتح ملف PDF إلى الخطوط؟**

لا. في هذه الأمثلة، يحتوي ملف PDF على الخطوط التي استُخدمت لرسم النص، لذا يظهر بصورة متساوية على أي حاسوب. الخطوط مطلوبة فقط حيث يقوم Aspose.Slides برسم العرض التقديمي.