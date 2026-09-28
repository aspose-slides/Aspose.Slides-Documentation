---
title: "Linux और Docker में Aspose.Slides के लिये फ़ॉन्ट्स तैनात करें"
linktitle: "फ़ॉन्ट्स तैनात करें"
type: docs
weight: 145
url: /hi/net/deploy-fonts/
keywords:
  - "फ़ॉन्ट्स तैनात करें"
  - "फ़ॉन्ट्स स्थापित करें"
  - "Docker में फ़ॉन्ट्स"
  - "Linux पर फ़ॉन्ट्स"
  - "गायब फ़ॉन्ट्स"
  - "फ़ॉन्ट प्रतिस्थापन"
  - "Microsoft कोर फ़ॉन्ट्स"
  - "ttf-mscorefonts-installer"
  - "कस्टम फ़ॉन्ट्स"
  - "डिफ़ॉल्ट फ़ॉन्ट"
  - "सर्वर"
  - "कंटेनर"
  - "PDF रूपांतरण"
  - "प्रस्तुति"
  - ".NET"
  - "C#"
  - "Aspose.Slides"
description: "Linux सर्वरों और Docker कंटेनरों में Aspose.Slides for .NET के लिए फ़ॉन्ट्स तैनात करें: देखें कौन से फ़ॉन्ट्स प्रतिस्थापित होते हैं, Debian, Ubuntu और Alpine पर फ़ॉन्ट पैकेज स्थापित करें, अपने स्वयं के फ़ॉन्ट फ़ाइलें जोड़ें, और डिफ़ॉल्ट फ़ॉन्ट सेट करें।"
---
## **अवलोकन**

Aspose.Slides प्रस्तुति को रेंडर करते समय उपलब्ध फ़ॉन्ट्स के साथ टेक्स्ट को ड्रॉ करता है, उदाहरण के लिये जब यह स्लाइड्स को PDF या इमेज में परिवर्तित करता है। एक Windows डेस्कटॉप में आमतौर पर वह फ़ॉन्ट्स होते हैं जो प्रस्तुति में उपयोग होते हैं। Linux सर्वर और कंटेनर में आमतौर पर कम फ़ॉन्ट्स या बिल्कुल नहीं होते, इसलिए Aspose.Slides टेक्स्ट को एक प्रतिस्थापन फ़ॉन्ट के साथ ड्रॉ करता है। प्रतिस्थापन फ़ॉन्ट के अक्षर आकार और चौड़ाई अलग होते हैं, जिससे पंक्तियों का रैप अलग हो सकता है और टेक्स्ट अपनी आकृति से बाहर निकल सकता है, तथा जो अक्षर प्रतिस्थापन फ़ॉन्ट में नहीं होते वे सही ढंग से नहीं दिखते। यदि कोई फ़ॉन्ट स्थापित नहीं है, तो परिवर्तन त्रुटि के साथ रुक जाता है।

यह लेख दिखाता है कि Aspose.Slides किन फ़ॉन्ट्स को प्रतिस्थापित करता है, Debian, Ubuntu और Alpine Linux पर फ़ॉन्ट्स कैसे स्थापित करें, अपने स्वयं के फ़ॉन्ट फ़ाइलें कैसे जोड़ें, और जब फ़ॉन्ट अनुपलब्ध हो तो कौन सा फ़ॉन्ट उपयोग किया जाए। उदाहरण Docker में आधिकारिक .NET इमेजेज पर चलते हैं, जैसे कि [Docker में Aspose.Slides for .NET चलाएँ](/slides/hi/net/how-to-run-aspose-slides-in-docker/). पैकेज कमांड Dockerfile निर्देश हैं; Linux सर्वर पर इन्हें root के रूप में चलाएँ।

फ़ॉन्ट API स्वयं के बारे में, जैसे प्रस्तुति में फ़ॉन्ट्स को एम्बेड करना और फ़ॉलबैक व प्रतिस्थापन नियम, देखें [PowerPoint फ़ॉन्ट्स](/slides/hi/net/powerpoint-fonts/)।

## **कौन से फ़ॉन्ट्स प्रतिस्थापित होते हैं देखें**

निम्नलिखित कंसोल एप्लिकेशन वर्तमान वातावरण में Aspose.Slides द्वारा प्रतिस्थापित फ़ॉन्ट्स की रिपोर्ट करता है। *FontCheck* नामक फ़ोल्डर बनाएँ और नीचे दिए गये फ़ाइलें उसमें जोड़ें।

*FontCheck.csproj* फ़ाइल [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) को संदर्भित करती है, जो Debian और Ubuntu के लिए पैकेज है। यह वैकल्पिक *fonts* फ़ोल्डर की फ़ाइलों को एप्लिकेशन आउटपुट में कॉपी भी करता है; यह *Load Fonts from the Application Folder* अनुभाग में उपयोग होता है।

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

*Program.cs* प्रत्येक फ़ॉन्ट नाम के लिए एक टेक्स्ट बॉक्स स्लाइड पर जोड़ता है और फ़ॉन्ट को [LatinFont](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/latinfont/) प्रॉपर्टी के माध्यम से सेट करता है। फ़ॉन्ट नाम कमांड‑लाइन से आते हैं; यदि कोई आर्ग्यूमेंट नहीं दिया गया तो एप्लिकेशन Calibri, Arial और Times New Roman की जाँच करता है। यह उन फ़ोल्डरों को प्रिंट करता है जहाँ Aspose.Slides फ़ॉन्ट्स देखता है ([FontsLoader.GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/)), स्लाइड को *output/fonts.pdf* में रेंडर करता है, और [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) द्वारा रिपोर्ट किए गये प्रतिस्थापन को प्रिंट करता है। प्रारम्भ में दो वैकल्पिक चरण, *fonts* फ़ोल्डर लोड करना और `DEFAULT_FONT` वेरिएबल पढ़ना, इस लेख के आगे समझाए गये हैं।

```c#
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

// जाँचने के लिये फ़ॉन्ट्स: कमांड‑लाइन आर्ग्यूमेंट्स, या तीन सामान्य Office फ़ॉन्ट्स।
var fontNames = args.Length > 0 ? args : new[] { "Calibri", "Arial", "Times New Roman" };

// यदि मौजूद हो तो एप्लिकेशन के पास वाले fonts फ़ोल्डर से फ़ॉन्ट फ़ाइलें लोड करें।
var appFontFolder = Path.Combine(AppContext.BaseDirectory, "fonts");
if (Directory.Exists(appFontFolder))
{
    FontsLoader.LoadExternalFonts(new[] { appFontFolder });
}

// यदि सेट किया गया हो, तो DEFAULT_FONT पर्यावरण वेरिएबल में नामित फ़ॉन्ट का उपयोग उन टेक्स्ट के लिये करें जिनका फ़ॉन्ट अनुपलब्ध है।
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

*.dockerignore* स्थानीय बिल्ड परिणामों को बिल्ड कॉन्टेक्स्ट से बाहर रखता है:

```text
bin/
obj/
output/
```

*Dockerfile* .NET SDK इमेज के साथ एप्लिकेशन बनाता है और .NET रनटाइम इमेज पर चलाता है। रनटाइम चरण `libfontconfig1` स्थापित करता है, जो Aspose.Slides.NET6.CrossPlatform को आवश्यक है, तथा DejaVu फ़ॉन्ट्स। [Docker में Aspose.Slides for .NET चलाएँ](/slides/hi/net/how-to-run-aspose-slides-in-docker/) प्रत्येक निर्देश को विस्तार से बताता है।

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

इमेज बनाएँ और जाँच चलाएँ:

```bash
docker build -t font-check .
docker run --rm font-check
```

इमेज में केवल DejaVu फ़ॉन्ट्स हैं, इसलिए तीनों फ़ॉन्ट्स DejaVu Sans से बदल दिए गये:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

अपने स्वयं के प्रस्तुति फ़ॉन्ट्स की जाँच करने के लिये, उनके नाम आर्ग्यूमेंट के रूप में पास करें, उदाहरण के लिये `docker run --rm font-check "Segoe UI" Consolas`। कंटेनर से *output/fonts.pdf* निकालने के लिये, [आउटपुट को अपनी मशीन पर कॉपी करें](/slides/hi/net/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine) में दिए गये कमांड्स का उपयोग करें।

## **Debian और Ubuntu पर फ़ॉन्ट्स स्थापित करें**

### **Microsoft Core Fonts**

`ttf-mscorefonts-installer` पैकेज माइक्रोसॉफ्ट के कोर फ़ॉन्ट्स को वेब के लिये डाउनलोड और स्थापित करता है, जिनमें Arial, Times New Roman, Courier New, Verdana, Georgia, और Trebuchet MS शामिल हैं। ये फ़ॉन्ट्स माइक्रोसॉफ्ट के एंड‑यूज़र लाइसेंस एग्रीमेंट (EULA) के तहत लाइसेंसित हैं, और पैकेज केवल EULA स्वीकार करने के बाद ही इन्हें स्थापित करता है। Docker बिल्ड प्रॉम्प्ट का उत्तर नहीं दे सकता, इसलिए इंस्टॉलर EULA को अस्वीकार कर देता है और कोई फ़ॉन्ट स्थापित नहीं करता, जबकि `apt-get install` अभी भी सफलता की रिपोर्ट करता है। पैकेज स्थापित होने से **पहले** `debconf-set-selections` के साथ EULA स्वीकार करें।

*Dockerfile* में, रनटाइम चरण में पैकेज स्थापित करने वाले `RUN` निर्देश को नीचे दिए गये से बदलें:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

इमेज बनाकर वही दो कमांड्स से जाँच फिर चलाएँ। अब Arial और Times New Roman स्थापित हैं:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri, वह डिफ़ॉल्ट फ़ॉन्ट जो Aspose.Slides खुद बनाता है, कोर फ़ॉन्ट्स में नहीं है, इसलिए वह अभी भी प्रतिस्थापित रहता है। देखें [Missing फ़ॉन्ट्स के लिये डिफ़ॉल्ट फ़ॉन्ट सेट करें](#set-a-default-font-for-missing-fonts)।

Debian में, पैकेज `contrib` रिपॉज़िटरी कम्पोनेंट में है, जिसे Debian इमेजेस डिफ़ॉल्ट रूप से सक्षम नहीं करते; डिफ़ॉल्ट .NET 8 और .NET 9 इमेजेस Debian 12 पर आधारित हैं। उसी निर्देश में `contrib` को सक्षम करें:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends libfontconfig1 fonts-dejavu-core ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Ubuntu‑आधारित .NET 10 इमेजेस पहले से ही `multiverse` को सक्षम करती हैं, जो इस पैकेज को शामिल करता है।

### **अन्य फ़ॉन्ट पैकेज**

Debian और Ubuntu मुक्त लाइसेंस वाले फ़ॉन्ट्स भी पैकेज करते हैं, उदाहरण स्वरूप:

| पैकेज | फ़ॉन्ट्स |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif, और Mono, जो Arial, Times New Roman, और Courier New के समान मीट्रिक रखते हैं |
| `fonts-crosextra-carlito` | Carlito, जो Calibri के समान मीट्रिक रखता है |
| `fonts-crosextra-caladea` | Caladea, जो Cambria के समान मीट्रिक रखता है |

उन्हें उसी `RUN` निर्देश में `apt-get install` के साथ स्थापित करें। Aspose.Slides.NET6.CrossPlatform Linux फ़ॉन्ट कॉन्फ़िगरेशन के फ़ॉन्ट उपनाम लागू नहीं करता: `fonts-liberation` स्थापित होने पर भी Arial में टेक्स्ट सामान्य प्रतिस्थापन फ़ॉन्ट से ड्रॉ होता है, Liberation Sans से नहीं। एक मीट्रिक‑संगत फ़ॉन्ट को गायब फ़ॉन्ट के स्थान पर उपयोग करने के लिये, इसे [डिफ़ॉल्ट फ़ॉन्ट] (#set-a-default-font-for-missing-fonts) के रूप में सेट करें या एक [फ़ॉन्ट प्रतिस्थापन नियम](/slides/hi/net/font-substitution/) जोड़ें।

## **अपनी स्वयं की फ़ॉन्ट फ़ाइलें जोड़ें**

वितरणों द्वारा पैकेज न किए गये फ़ॉन्ट्स, जैसे कि आपके संगठन के फ़ॉन्ट्स या अन्य फ़ॉन्ट्स जिनके उपयोग का लाइसेंस आपके पास है, को फ़ॉन्ट फ़ाइलों के रूप में जोड़ा जा सकता है। फ़ॉन्ट फ़ाइलें, उदाहरण के लिये *.ttf* फ़ाइलें, को *FontCheck* फ़ोल्डर के अंदर *fonts* नामक फ़ोल्डर में रखें। नीचे के उदाहरण Carlito फ़ाइलों का उपयोग करते हैं, जो Calibri के समान मीट्रिक रखता है, आप इसे [Google Fonts](https://fonts.google.com/specimen/Carlito) से डाउनलोड कर सकते हैं।

### **सिस्टम फ़ॉन्ट फ़ोल्डर में फ़ॉन्ट्स स्थापित करें**

Aspose.Slides `Font folders` लाइन में प्रिंट किए गये फ़ोल्डरों के फ़ॉन्ट्स पढ़ता है। सभी एप्लिकेशन के लिये फ़ॉन्ट्स स्थापित करने हेतु, उन्हें */usr/local/share/fonts* में कॉपी करें, जो स्थानीय रूप से स्थापित फ़ॉन्ट्स का फ़ोल्डर है। इस निर्देश को *Dockerfile* के रनटाइम चरण में, पैकेज स्थापित करने वाले `RUN` निर्देश के बाद जोड़ें:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

### **एप्लिकेशन फ़ोल्डर से फ़ॉन्ट्स लोड करें**

फ़ॉन्ट्स को इमेज में स्थापित करने के बजाय, आप उन्हें एप्लिकेशन के साथ शिप कर सकते हैं और [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) से लोड कर सकते हैं। तब फ़ॉन्ट्स केवल Aspose.Slides के लिये उपलब्ध होते हैं और एप्लिकेशन के साथ ही वितरित होते हैं। *FontCheck* ऐसा करता है: *FontCheck.csproj* *fonts* फ़ोल्डर को एप्लिकेशन आउटपुट में कॉपी करता है, और *Program.cs* प्रस्तुति बनाने से पहले उस फ़ोल्डर को `LoadExternalFonts` को पास करता है। [कस्टम फ़ॉन्ट](/slides/hi/net/custom-font/) अन्य तरीकों का वर्णन करता है, जैसे मेमोरी से लोड करना।

इमेज को पुनः बनायें, फिर Calibri और Carlito जांचें:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

एप्लिकेशन फ़ोल्डर अब फ़ॉन्ट फ़ोल्डरों में दिखता है, और Carlito अब प्रतिस्थापित नहीं हो रहा है:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Arial
```

## **Missing फ़ॉन्ट्स के लिये डिफ़ॉल्ट फ़ॉन्ट सेट करें**

जब कोई फ़ॉन्ट अनुपलब्ध होता है, तो Aspose.Slides स्वयं एक प्रतिस्थापन चुनता है। इसे खुद चुनने के लिये, [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) की [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaultregularfont/) प्रॉपर्टी सेट करें और विकल्पों को [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) कन्स्ट्रकटर को पास करें। *FontCheck* `DEFAULT_FONT` environment वेरिएबल से फ़ॉन्ट नाम पढ़ता है। Carlito लोड होने पर, इसे अनुपलब्ध फ़ॉन्ट्स के लिये उपयोग करें:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

अब Calibri को Carlito के साथ ड्रॉ किया जाता है, जिसके अक्षर Calibri के समान चौड़ाई के होते हैं, इसलिए टेक्स्ट अपनी लाइन‑ब्रेक्स बरकरार रखता है:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, .local/share/fonts, /app/.fonts
Font substitutions:
  Calibri -> Carlito
```

डिफ़ॉल्ट फ़ॉन्ट हर अनुपलब्ध फ़ॉन्ट को बदल देता है। व्यक्तिगत फ़ॉन्ट्स को मैप करने के लिये, उदाहरण के लिये Arial को Liberation Sans और Calibri को Carlito, एक [फ़ॉन्ट प्रतिस्थापन नियम](/slides/hi/net/font-substitution/) उपयोग करें। नियम रेंडर किए गये आउटपुट को बदलते हैं, लेकिन `GetSubstitutions` उनका प्रतिबिंब नहीं दिखाता, इसलिए आउटपुट फ़ाइल में फ़ॉन्ट्स की जाँच करें। एशियाई टेक्स्ट के लिये, साथ ही [DefaultAsianFont](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaultasianfont/) सेट करें; देखें [डिफ़ॉल्ट फ़ॉन्ट](/slides/hi/net/default-font/)।

## **Alpine Linux पर फ़ॉन्ट्स स्थापित करें**

Alpine Linux पर, Aspose.Slides.NET पैकेज का उपयोग करें; [Alpine Linux पर चलाएँ](/slides/hi/net/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) प्रोजेक्ट में बदलावों की सूची देता है। वही बदलाव *FontCheck* में करें: पैकेज रेफ़रेंसेस बदलें, *Program.cs* में `SetSwitch` स्टेटमेंट जोड़ें, और इस रनटाइम चरण का उपयोग करें, जो Microsoft कोर फ़ॉन्ट्स भी स्थापित करता है:

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

`update-ms-fonts` वही Microsoft कोर फ़ॉन्ट्स डाउनलोड और स्थापित करता है जो Debian और Ubuntu पैकेज में होते हैं, और उनका EULA समान रूप से लागू होता है। `fc-cache` फ़ॉन्ट कैश को अपडेट करता है।

Linux पर Aspose.Slides.NET के साथ, फ़ॉन्ट कॉन्फ़िगरेशन लाइब्रेरी (fontconfig) गायब फ़ॉन्ट के लिये प्रतिस्थापन चुनती है, और `GetSubstitutions` इसे रिपोर्ट नहीं करता, इसलिए *FontCheck* `No font substitutions.` प्रिंट करता है। फ़ॉन्ट नाम के लिये कौन सा फ़ॉन्ट उपयोग हो रहा है, यह जानने के लिये कंटेनर में फ़ॉन्टकॉन्फ़िग को पूछें:

```bash
docker run --rm --entrypoint fc-match font-check Arial
```

Microsoft कोर फ़ॉन्ट्स स्थापित होने पर, Arial को Arial ही उपयोग किया जाता है:

```text
Arial.ttf: "Arial" "Regular"
```

यदि नहीं, और `RUN` निर्देश केवल `icu-libs libgdiplus font-dejavu` स्थापित करता है, तो वही कमांड प्रिंट करता है:

```text
DejaVuSans.ttf: "DejaVu Sans" "Book"
```

## **FAQ**

**सर्वर पर रूपांतरण के समय प्रस्तुति अलग क्यों दिखती है?**

सर्वर पर वह फ़ॉन्ट नहीं होता जो प्रस्तुति उपयोग करती है, इसलिए Aspose.Slides टेक्स्ट को एक ऐसे प्रतिस्थापन फ़ॉन्ट से ड्रॉ करता है जिसकी अक्षर चौड़ाई अलग होती है। *FontCheck* को प्रस्तुति के फ़ॉन्ट नामों के साथ चलाएँ ताकि पता चले कौन से फ़ॉन्ट्स प्रतिस्थापित हुए, फिर उन फ़ॉन्ट्स को स्थापित करें या एप्लिकेशन फ़ोल्डर से लोड करें।

**बिल्ड ने ttf-mscorefonts-installer स्थापित किया, लेकिन फिर भी Arial प्रतिस्थापित हो रहा है। क्यों?**

पैकेज स्थापित होने से पहले EULA स्वीकार नहीं किया गया था, इसलिए इंस्टॉलर ने फ़ॉन्ट्स को छोड़ दिया। `apt-get install` से पहले `debconf-set-selections` कमांड जोड़ें, जैसा कि [Microsoft Core Fonts](#microsoft-core-fonts) में दिखाया गया है, और इमेज को पुनः बनाएँ।

**क्या PDF को खोलने वाले कंप्यूटर को फ़ॉन्ट्स की जरूरत है?**

नहीं। इन उदाहरणों में PDF में वह फ़ॉन्ट्स एम्बेड होते हैं जो टेक्स्ट को ड्रॉ करने के लिये उपयोग किए गये थे, इसलिए यह किसी भी कंप्यूटर पर समान दिखता है। फ़ॉन्ट्स केवल उस स्थान पर आवश्यक हैं जहाँ Aspose.Slides प्रस्तुति को रेंडर करता है।