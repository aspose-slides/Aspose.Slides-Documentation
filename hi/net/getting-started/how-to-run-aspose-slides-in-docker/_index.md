---
title: Docker में Aspose.Slides for .NET चलाएँ
linktitle: Docker
type: docs
weight: 140
url: /hi/net/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Docker कंटेनर
- मल्टी‑स्टेज बिल्ड
- कंटेनर इमेज
- Linux
- Ubuntu
- Alpine
- libfontconfig
- libgdiplus
- फ़ॉन्ट्स
- PDF रूपांतरण
- PowerPoint
- प्रेज़ेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Docker में Aspose.Slides for .NET कंसोल एप्लिकेशन बनाएं और चलाएँ: आधिकारिक .NET इमेजों पर एक मल्टी‑स्टेज Dockerfile, आवश्यक Linux लाइब्रेरीज़ और फ़ॉन्ट्स, तथा उत्पन्न फ़ाइलों को अपनी मशीन पर कॉपी करने का तरीका।"
---
## **सारांश**

यह लेख दिखाता है कि Aspose.Slides for .NET को Docker कंटेनर में कैसे चलाएँ। आप एक छोटा कंसोल एप्लिकेशन बनाते हैं जो टेक्स्ट बॉक्स के साथ एक प्रेजेंटेशन बनाता है और उसे PDF में बदलता है, इसे Microsoft की आधिकारिक .NET इमेजों पर मल्टी‑स्टेज Dockerfile के साथ पैकेज करता है, चलाता है, और उत्पन्न फ़ाइलों को अपनी मशीन पर कॉपी करता है। लेख में कंटेनर में Aspose.Slides को आवश्यक Linux लाइब्रेरीज़ और फ़ॉन्ट्स की सूची भी दी गई है और अंत में Alpine Linux के लिए एक वैरिएंट दिया गया है।

आपको केवल अपनी मशीन पर Docker चाहिए। .NET SDK बिल्ड इमेज में शामिल है, इसलिए आपको इसे अलग से स्थापित करने की आवश्यकता नहीं है। Docker स्थापित करने के लिए देखें [Get Docker](https://docs.docker.com/get-started/get-docker/)।

## **पैकेज और बेस इमेज चुनें**

डिफ़ॉल्ट .NET 10 कंटेनर इमेजें Ubuntu 24.04 पर आधारित हैं। इन इमेजों पर, [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) पैकेज का उपयोग करें। इसे `fontconfig` लाइब्रेरी की आवश्यकता होती है, और .NET runtime इमेज में न तो वह लाइब्रेरी है न ही कोई फ़ॉन्ट, इसलिए इस लेख का Dockerfile दोनों को इंस्टॉल करता है।

Aspose.Slides.NET6.CrossPlatform Alpine Linux पर नहीं चलता। Alpine‑आधारित इमेजों के लिए, [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) पैकेज को `libgdiplus` के साथ उपयोग करें, जैसा कि [Run on Alpine Linux](#run-on-alpine-linux) में बताया गया है। [Installation](/slides/hi/net/installation/) दो पैकेजों की तुलना करता है।

## **प्रोजेक्ट बनाएं**

*HelloSlidesDocker* नाम वाला एक फ़ोल्डर बनाएं और उसमें निम्नलिखित तीन फ़ाइलें जोड़ें।

*HelloSlidesDocker.csproj* .NET 10 के लिए एक कंसोल एप्लिकेशन, नीचे उपयोग की गई कंटेनर इमेजों का संस्करण, और Aspose.Slides.NET6.CrossPlatform रेफ़रेंस को वर्णित करता है। पैकेज संस्करण को [NuGet](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) पर सूचीबद्ध नवीनतम संस्करण पर सेट करें।

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

*Program.cs* एक [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) बनाता है, पहली स्लाइड में टेक्स्ट के साथ एक आयत जोड़ता है, और [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) मेथड से प्रेज़ेंटेशन को दो बार सहेजता है: PPTX और PDF के रूप में। दोनों फ़ाइलें कार्य निर्देशिका के अंतर्गत *output* फ़ोल्डर में जाती हैं। इसके बाद एप्लिकेशन PDF रेंडर करते समय बदलाए गए फ़ॉन्ट्स को सूचीबद्ध करता है, `IFontsManager.GetSubstitutions` का उपयोग कर, ताकि आप देख सकें कि कंटेनर में प्रेज़ेंटेशन द्वारा उपयोग किए गए फ़ॉन्ट्स मौजूद हैं या नहीं।

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

*.dockerignore* स्थानीय बिल्ड की *bin* और *obj* फ़ोल्डर तथा पिछले रन के आउटपुट को Docker बिल्ड कॉन्टेक्स्ट से बाहर रखता है, इसलिए इमेज केवल स्रोत फ़ाइलों से बनती है।

```text
bin/
obj/
output/
```

## **Dockerfile लिखें**

एक फ़ाइल *Dockerfile* उसी फ़ोल्डर में जोड़ें:

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

फ़ाइल में दो चरण होते हैं:

- **The build stage** .NET SDK इमेज से शुरू होता है। यह पहले प्रोजेक्ट फ़ाइल को कॉपी करता है और NuGet पैकेजों को रिस्टोर करता है, ताकि प्रोजेक्ट फ़ाइल न बदलने पर Docker वह लेयर पुन: उपयोग कर सके। इसके बाद सोर्स कोड कॉपी करता है और एप्लिकेशन को */app* में प्रकाशित करता है।
- **The runtime stage** छोटे .NET runtime इमेज से शुरू होता है, जिसमें कोई SDK नहीं होता, और केवल प्रकाशित एप्लिकेशन को कॉपी करता है। यह दो पैकेज स्थापित करता है:
  - `libfontconfig1`: Aspose.Slides.NET6.CrossPlatform शुरू होने पर इस लाइब्रेरी को लोड करता है। बिना इसे, एप्लिकेशन `DllNotFoundException` के साथ रुक जाता है जिसमें `libfontconfig.so.1` का उल्लेख होता है।
  - `fonts-dejavu-core`: runtime इमेज में कोई फ़ॉन्ट नहीं होते, और Aspose.Slides को टेक्स्ट ड्रॉ करने के लिए कम से कम एक फ़ॉन्ट स्थापित होना चाहिए; बिना किसी फ़ॉन्ट के, परिवर्तन `InvalidOperationException: Cannot find any fonts installed on the system.` के साथ रुक जाता है। न स्थापित फ़ॉन्ट में टेक्स्ट को एक प्रतिस्थापन फ़ॉन्ट से ड्रॉ किया जाता है। DejaVu फ़ॉन्ट का छोटा सेट टेक्स्ट रेंडर करने के लिए पर्याप्त है; उन फ़ॉन्ट्स के साथ प्रेज़ेंटेशन रेंडर करने के लिए देखें [Deploy Fonts](/slides/hi/net/deploy-fonts/)।

`--no-install-recommends` और पैकेज सूचियों को हटाने से इमेज छोटे आकार की रहती है। अंतिम पंक्तियाँ *output* फ़ोल्डर बनाती हैं, इसे आधिकारिक .NET इमेजों द्वारा परिभाषित गैर‑रूट `app` उपयोगकर्ता (जिसका यूज़र ID `APP_UID` वेरिएबल में है) को देती हैं, और एप्लिकेशन को उसी उपयोगकर्ता के रूप में चलाती हैं।

ASP.NET Core एप्लिकेशन के लिए, runtime stage को `mcr.microsoft.com/dotnet/aspnet:10.0` से शुरू करें। यह भी वही Ubuntu इमेज पर आधारित है, इसलिए वही पैकेज आवश्यक होते हैं।

## **कंटेनर बनाएं और चलाएँ**

*HelloSlidesDocker* फ़ोल्डर में टर्मिनल खोलें। इमेज बनाएं, फिर उससे एक कंटेनर चलाएँ:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

पहला बिल्ड बेस इमेज और NuGet पैकेज डाउनलोड करता है, इसलिए बाद के बिल्ड्स की तुलना में इसे अधिक समय लगता है। कंटेनर एप्लिकेशन चलाता है और रुक जाता है। यह प्रिंट करता है:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

पहली पंक्ति दिखाती है कि टेक्स्ट Calibri फ़ॉन्ट का उपयोग कर रहा है, जो नई प्रेज़ेंटेशन की डिफ़ॉल्ट फ़ॉन्ट है, और Calibri इमेज में स्थापित नहीं है, इसलिए Aspose.Slides ने टेक्स्ट को DejaVu Sans से ड्रॉ किया। PDF में टेक्स्ट वास्तविक, चयन योग्य टेक्स्ट है उस फ़ॉन्ट में। बिना लाइसेंस के, Aspose.Slides प्रत्येक स्लाइड में एक मूल्यांकन वॉटरमार्क भी जोड़ता है; देखें [Licensing](/slides/hi/net/licensing/)।

## **आउटपुट को अपनी मशीन पर कॉपी करें**

फ़ाइलें बंद किए गए कंटेनर के */app/output* फ़ोल्डर में हैं। उन्हें अपनी मशीन पर एक *output* फ़ोल्डर में कॉपी करें, फिर कंटेनर को हटा दें:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

इन दो कमांड्स का Bash, PowerShell, और Windows Command Prompt में वही व्यवहार है।

Linux पर आप अपनी मशीन के फ़ोल्डर को कंटेनर में माउंट कर सकते हैं, ताकि एप्लिकेशन सीधे वहाँ फ़ाइलें लिखे:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

`--user` विकल्प एप्लिकेशन को आपके उपयोगकर्ता और ग्रुप ID के साथ चलाता है, इसलिए यह आपके द्वारा बनाए गए फ़ोल्डर में लिख सकता है और फ़ाइलें आपका स्वामित्व रहती हैं। `--rm` कंटेनर के रुकने पर उसे हटा देता है।

## **Alpine Linux पर चलाएँ**

Alpine‑आधारित इमेज में एप्लिकेशन चलाने के लिए, Aspose.Slides.NET पैकेज पर स्विच करें और runtime stage बदलें। build stage समान रहता है।

1. *HelloSlidesDocker.csproj* में पैकेज रेफ़रेंस बदलें:

   ```xml
   <PackageReference Include="Aspose.Slides.NET" Version="26.9.0" />
   ```

2. *Program.cs* में `using` निर्देशों के बाद, पहली Aspose.Slides कॉल से पहले यह स्टेटमेंट जोड़ें। यह Linux के लिए System.Drawing सपोर्ट सक्षम करता है, जिसका उपयोग Aspose.Slides.NET करता है:

   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

3. *Dockerfile* में runtime stage (दूसरी `FROM` पंक्ति से लेकर अंत तक) को इससे बदलें:

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

Alpine stage तीन पैकेज स्थापित करता है और एक सेटिंग बदलता है:

- `libgdiplus` वह ग्राफ़िक्स लाइब्रेरी है जो Aspose.Slides.NET Linux पर उपयोग करता है।
- `font-dejavu` फ़ॉन्ट प्रदान करता है। बिना किसी फ़ॉन्ट के, परिवर्तन `System.ArgumentException: Font '?' cannot be found` के साथ रुक जाता है।
- `icu-libs` और `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false` संस्कृति डेटा प्रदान करते हैं। Alpine .NET इमेजें डिफ़ॉल्ट रूप से globalization‑invariant मोड में चलती हैं, और इस मोड में Aspose.Slides `CultureNotFoundException` के साथ रुक जाता है `en-US` के लिए।

उपर्युक्त समान कमांडों से बिल्ड, रन और आउटपुट कॉपी करें। इस इमेज पर एप्लिकेशन केवल `Saved` पंक्ति प्रिंट करता है: Linux पर Aspose.Slides.NET के साथ, fontconfig गायब फ़ॉन्ट के लिए प्रतिस्थापन चुनता है, और [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) इसे सूचीबद्ध नहीं करता। [Deploy Fonts](/slides/hi/net/deploy-fonts/) दिखाता है कि कौन सा फ़ॉन्ट इस्तेमाल हो रहा है।

## **FAQ**

**The application stops with "Unable to load shared library 'libaspose.slides.drawing.capi…'". What is missing?**

Ubuntu और Debian इमेजों पर `libfontconfig1` पैकेज गायब होता है; संदेश में `libfontconfig.so.1` को नहीं खोल पाए जाने का उल्लेख है। Alpine Linux पर यह संदेश दर्शाता है कि Aspose.Slides.NET6.CrossPlatform उपयोग में है; [Run on Alpine Linux](#run-on-alpine-linux) में बताए अनुसार Aspose.Slides.NET पर स्विच करें।

**Why is the text in the PDF in a different font than in PowerPoint?**

प्रेज़ेंटेशन द्वारा उपयोग किए गए फ़ॉन्ट इमेज में स्थापित नहीं हैं, इसलिए Aspose.Slides टेक्स्ट को एक प्रतिस्थापन फ़ॉन्ट से ड्रॉ करता है। एप्लिकेशन का आउटपुट प्रत्येक बदले गए फ़ॉन्ट को नाम देता है। फ़ॉन्ट्स को इमेज में स्थापित करने या एप्लिकेशन फ़ोल्डर से लोड करने के बारे में देखें [Deploy Fonts](/slides/hi/net/deploy-fonts/)।

**Do I need the .NET SDK on my machine?**

नहीं। build stage SDK इमेज के भीतर एप्लिकेशन को कंपाइल करता है। आपको SDK तभी चाहिए जब आप Docker के बाहर भी एप्लिकेशन बनाना और चलाना चाहते हों; देखें [Installation](/slides/hi/net/installation/).