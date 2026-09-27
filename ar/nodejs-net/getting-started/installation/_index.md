---
title: التثبيت
type: docs
weight: 70
url: /ar/nodejs-net/installation/
keywords:
- تنزيل Aspose.Slides
- تثبيت Aspose.Slides
- تثبيت Aspose.Slides
- ويندوز
- ماك أو إس
- لينكس
- جافا سكريبت
- Node.js
description: "تثبيت Aspose.Slides لـ Node.js عبر .NET من npm على Windows أو Linux: المتطلبات السابقة، تجاوز edge-js، استعادة NuGet مرة واحدة، وأول برنامج ينشئ عرضًا تقديميًا."
---
## **نظرة عامة**

Aspose.Slides for Node.js via .NET هو حزمة npm `aspose.slides.via.net`. تقوم بتشغيل مكتبة Aspose.Slides .NET داخل Node.js عبر جسر [edge-js](https://github.com/agracio/edge-js)، لذا فإن التثبيت الناجح يتطلب كلًا من Node.js و .NET.

تأخذك هذه المقالة من جهاز نظيف إلى أول برنامج يُنشئ عرضًا تقديميًا. هناك أربع خطوات: إنشاء مشروع مع تجاوز edge-js، تثبيت الحزمة من npm، استعادة تبعيات .NET الخاصة بالحزمة مرة واحدة، وتشغيل السكريبت من مجلد المشروع.

## **المتطلبات السابقة**

- **Node.js 22 أو 24 LTS**، بنية x64، من [nodejs.org](https://nodejs.org/en/download).
- **.NET SDK 8 أو أحدث**، من [dotnet.microsoft.com](https://dotnet.microsoft.com/download). وقت تشغيل .NET وحده غير كافٍ: خطوة الاستعادة أدناه تحتاج إلى SDK، وكذلك الجسر عندما يتم تشغيل السكريبت. نفّذ `dotnet --list-sdks` للتحقق من الإصدارات المثبتة.
- **على Linux فقط**:
  - أدوات البناء `python3`، `make` و `g++`، لأن npm يُجمّع edge-js أثناء التثبيت على Linux؛
  - مكتبة fontconfig، التي تُحمّلها مكتبة الرسم الأصلية لـ Aspose.Slides.

  على Debian، هذه الحزم هي `python3`، `make`، `g++` و `libfontconfig1`.

تم اختبار الخطوات في هذه المقالة على المنصات التالية:

| المنصة | النتيجة |
|---|---|
| Windows x64 مع Node.js 22 أو 24 | يعمل. تم الاختبار مع تثبيت Microsoft Visual C++ Redistributable. |
| Linux x64 مع Node.js 22 أو 24، حيث يكون نظام OpenSSL هو نفسه الذي بُني في Node.js، مثل Debian 13 | يعمل. |
| Linux حيث تختلف نسختا OpenSSL، مثل Debian 12 | يتعطل Node.js بخطأ تقسيم عندما يتم إنشاء عرض تقديمي. |
| macOS | غير مُتحقق منه. |

على Linux، قارِن النسختين قبل البدء. الأمر الأول يطبع نسخة OpenSSL المدمجة في Node.js؛ الثاني يطبع نسخة النظام. استخدم نظامًا يبدأ بالرقمين الرئيسي والفرعي نفسه، مثل `3.5`:

```sh
node -p process.versions.openssl
openssl version
```

إذا لم يُعثر على أمر `openssl`، ثبّت حزمة `openssl` أولاً.

## **إنشاء مشروع**

أنشئ مجلدًا لمشروعك، بادر بتهيئته، وأضف تجاوزًا يُخبر npm أي نسخة من edge-js تُثبت:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
```

تطلب الحزمة نسخة قديمة من edge-js تُوقف فيها الثنائيات المسبقة البناء لـ Windows عند Node.js 20، لذا بدون التجاوز سيتوقف السكريبت الأول على Windows مع الرسالة "The edge module has not been pre-compiled for node.js version". يكتب الأمر التجاوز إلى قسم `overrides` في `package.json`؛ أضفه قبل تثبيت الحزمة.

## **تثبيت الحزمة**

ثبّت Aspose.Slides for Node.js via .NET من npm:

```sh
npm install aspose.slides.via.net
```

أثناء التثبيت، تنسخ الحزمة مكتبات الرسم الأصلية (الملفات التي تحتوي أسماؤها على `aspose.slides.drawing.capi`) إلى مجلد المشروع، بجانب `package.json`.

تُنشر الحزمة أيضًا كأرشيف ZIP على [releases.aspose.com](https://releases.aspose.com/slides/nodejs-net/). تغطي هذه المقالة التثبيت من npm فقط.

## **استعادة تبعيات .NET**

تحتوي الحزمة على تجميعات Aspose.Slides .NET، لكن ليس الـ 20 حزمة NuGet التي تعتمد عليها هذه التجميعات. في وقت التشغيل، يبحث .NET عنها في ذاكرة تخزين NuGet: `%USERPROFILE%\.nuget\packages` على Windows، `~/.nuget/packages` على Linux، أو المجلد المحدد في متغيّر البيئة `NUGET_PACKAGES`. إذا كانت مفقودة، يتوقف السكريبت الأول مع الرسالة "assembly specified in the dependencies manifest was not found".

لملء التخزين المؤقت، أنشئ مجلدًا باسم `deps` في مجلد المشروع واحفظ الملف التالي فيه باسم `deps.csproj`. كل عنصر `PackageDownload` يُنزّل حزمة بنسختها المحددة بين القوسين؛ لا يتم بناء شيء.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageDownload Include="Humanizer.Core" Version="[2.14.1]" />
    <PackageDownload Include="Microsoft.Bcl.AsyncInterfaces" Version="[6.0.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.Common" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.CSharp" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.CSharp.Workspaces" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.VisualBasic" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.VisualBasic.Workspaces" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.CodeAnalysis.Workspaces.Common" Version="[4.5.0]" />
    <PackageDownload Include="Microsoft.DotNet.InternalAbstractions" Version="[1.0.0]" />
    <PackageDownload Include="Microsoft.Extensions.DependencyModel" Version="[7.0.0]" />
    <PackageDownload Include="Newtonsoft.Json" Version="[13.0.3]" />
    <PackageDownload Include="System.Composition.AttributedModel" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Convention" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Hosting" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.Runtime" Version="[6.0.0]" />
    <PackageDownload Include="System.Composition.TypedParts" Version="[6.0.0]" />
    <PackageDownload Include="System.IO.Pipelines" Version="[6.0.3]" />
    <PackageDownload Include="System.Reflection.Metadata" Version="[6.0.1]" />
    <PackageDownload Include="System.Text.Encodings.Web" Version="[7.0.0]" />
    <PackageDownload Include="System.Text.Json" Version="[7.0.0]" />
  </ItemGroup>
</Project>
```

ثم استرجعها من مجلد المشروع:

```sh
dotnet restore deps/deps.csproj
```

تحتاج إلى هذه الخطوة مرة واحدة لكل جهاز، وليس لكل مشروع: تُبقى الحزم في ذاكرة تخزين NuGet، وتستفيد منها المشاريع اللاحقة على نفس الجهاز. بعد الاستعادة، يمكنك حذف مجلد `deps`.

## **تشغيل أول برنامج**

أنشئ ملفًا باسم `hello.js` في مجلد المشروع بالكود التالي. يُنشئ عرضًا تقديميًا، يُضيف مستطيلًا بالنص "Hello, World!" إلى الشريحة الأولى، ويحفظ النتيجة باسم `hello.pptx`:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// عرض تقديمي جديد يحتوي على شريحة فارغة واحدة.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // الموضع والحجم بوحدات النقاط (1/72 بوصة): x, y, العرض, الارتفاع.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // تحرير الكائن .NET الذي يدعم العرض التقديمي.
    presentation.dispose();
}
```

شغّله من مجلد المشروع:

```sh
node hello.js
```

يُظهر السكريبت النص `Saved hello.pptx`. افتح `hello.pptx` لترى شريحة واحدة بها مستطيل مملوء يحتوي على النص. بدون ترخيص، يُضيف Aspose.Slides أيضًا علامة مائية للتقييم؛ طالع [Evaluate Aspose.Slides](/slides/ar/nodejs-net/evaluate-aspose-slides/) و[Licensing](/slides/ar/nodejs-net/licensing/).

{{% alert color="info" title="Note" %}}
شغّل سكريبتاتك من مجلد المشروع، ذلك الذي يحتوي على `package.json`. تُحل المسارات النسبية مثل `hello.pptx` بالنسبة للمجلد الحالي، وعلى بعض الأجهزة قد لا يتمكن سكريبت بدأ من مجلد مختلف من إنشاء عرض تقديمي.
{{% /alert %}}

تُطابق واجهة برمجة JavaScript واجهة Aspose.Slides for .NET: تحتفظ الفئات بأسمائها في .NET، وتستخدم الخصائص والطرق camelCase (`Slides` تصبح `slides`، `AddAutoShape` تصبح `addAutoShape`)، وتُقرأ عناصر المجموعات عبر `get(index)`. لا توجد وثيقة API منفصلة لهذه الحزمة، لذا استخدم [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/) لتفاصيل الفئات والأعضاء، مثل [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) و[ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/).

## **الأسئلة الشائعة**

**ماذا يعني الخطأ "The edge module has not been pre-compiled for node.js version"؟**

قام npm بتثبيت نسخة edge-js القديمة التي طلبتها الحزمة. أضف التجاوز من [إنشاء مشروع](#create-a-project) وشغّل `npm install` مرة أخرى.

**ماذا يعني الخطأ "assembly specified in the dependencies manifest was not found"؟**

تبعيات .NET غير موجودة في ذاكرة تخزين NuGet. يُظهر نفس التشغيل أيضًا "edge.initializeClrFunc is not a function". اتبع [استعادة تبعيات .NET](#restore-the-net-dependencies) مرة واحدة، ثم شغّل السكريبت مرة أخرى.

**ماذا يعني الخطأ "The edge native module is not available" على Linux؟**

لم يتم تجميع edge-js أثناء `npm install`، على سبيل المثال لأن `python3` أو `make` أو `g++` كانت مفقودة. لا يُبلغ npm عن ذلك كخطأ. ثبّت أدوات البناء، ثم شغّل `npm rebuild edge-js` في مجلد المشروع.

**لماذا تفشل عملية إنشاء عرض تقديمي بخطأ فارغ "Error"؟**

على Linux، تأكد من تثبيت مكتبة fontconfig (`libfontconfig1` على Debian)؛ بدونها لا يمكن لمكتبة الرسم الأصلية التحميل. على أي نظام، تأكد أيضًا من تشغيل السكريبت من مجلد المشروع.

**لماذا يتعطل Node.js بخطأ تقسيم على Linux؟**

نظام OpenSSL الخاص بالنظام وOpenSSL المدمج في Node.js من سلاسل إصدارات مختلفة. قارنهما كما هو موضح في [المتطلبات السابقة](#prerequisites) واستخدم توزيعة أو بنية Node.js حيث تتطابق الإصدارات.

**هل أحتاج إلى تكرار استعادة NuGet لكل مشروع؟**

لا. الاستعادة تملأ ذاكرة تخزين NuGet لحساب المستخدم الخاص بك، وتستخدمها كل المشاريع على ذلك الجهاز.