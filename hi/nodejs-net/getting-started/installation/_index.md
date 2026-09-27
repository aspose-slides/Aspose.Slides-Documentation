---
title: स्थापना
type: docs
weight: 70
url: /hi/nodejs-net/installation/
keywords:
- Aspose.Slides डाउनलोड करें
- Aspose.Slides इंस्टॉल करें
- Aspose.Slides स्थापना
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Windows या Linux पर npm से .NET के माध्यम से Aspose.Slides for Node.js स्थापित करें: पूर्वापेक्षाएँ, edge-js ओवरराइड, एक बार की NuGet रिस्टोर, और एक प्रथम प्रोग्राम जो प्रस्तुति बनाता है।"
---
## **अवलोकन**

Aspose.Slides for Node.js via .NET npm पैकेज `aspose.slides.via.net` है। यह Aspose.Slides .NET लाइब्रेरी को Node.js के अंदर [edge-js](https://github.com/agracio/edge-js) ब्रिज के माध्यम से चलाता है, इसलिए कार्यशील इंस्टॉलेशन के लिए Node.js और .NET दोनों की आवश्यकता होती है।

यह लेख आपको एक साफ़ मशीन से एक प्रथम प्रोग्राम तक ले जाता है जो प्रस्तुति बनाता है। चार चरण हैं: edge-js ओवरराइड के साथ एक प्रोजेक्ट बनाएं, npm से पैकेज इंस्टॉल करें, पैकेज की .NET निर्भरताओं को एक बार रीस्टोर करें, और स्क्रिप्ट को प्रोजेक्ट फ़ोल्डर से चलाएँ।

## **पूर्वापेक्षाएँ**

- **Node.js 22 या 24 LTS**, x64 बिल्ड, [nodejs.org](https://nodejs.org/en/download) से।
- **.NET SDK 8 या बाद का संस्करण**, [dotnet.microsoft.com](https://dotnet.microsoft.com/download) से। केवल .NET रनटाइम पर्याप्त नहीं है: नीचे दिया गया रीस्टोर चरण SDK की आवश्यकता रखता है, और आपके स्क्रिप्ट चलाने पर ब्रिज को भी। स्थापित SDKs की जाँच के लिए `dotnet --list-sdks` चलाएँ।
- **Linux पर केवल**:
  - npm इंस्टॉलेशन के दौरान edge-js को कंपाइल करने के लिए बिल्ड टूल `python3`, `make` और `g++` आवश्यक हैं;
  - fontconfig लाइब्रेरी, जिसे Aspose.Slides नेटिव ड्रॉइंग लाइब्रेरी लोड करती है।

  Debian पर, ये पैकेज `python3`, `make`, `g++` और `libfontconfig1` हैं।

इस लेख में बताए गए चरण इन प्लेटफ़ॉर्म्स पर परीक्षण किए गए हैं:

| प्लेटफ़ॉर्म | परिणाम |
|---|---|
| Windows x64 with Node.js 22 या 24 | काम करता है। Microsoft Visual C++ Redistributable स्थापित होने पर परीक्षण किया गया। |
| Linux x64 with Node.js 22 या 24, जहाँ सिस्टम OpenSSL Node.js में निर्मित OpenSSL के समान रिलीज़ लाइन से है, जैसे Debian 13 | काम करता है। |
| Linux जहाँ दो OpenSSL संस्करण अलग हैं, जैसे Debian 12 | Node.js प्रस्तुति बनाने पर सेगमेंटेशन फॉल्ट के साथ क्रैश हो जाता है। |
| macOS | सत्यापित नहीं। |

Linux पर, शुरू करने से पहले दो संस्करणों की तुलना करें। पहला कमांड Node.js में निर्मित OpenSSL संस्करण को प्रदर्शित करता है; दूसरा सिस्टम संस्करण को। ऐसे सिस्टम का उपयोग करें जहाँ दोनों का मेजर और माइनर नंबर समान हो, उदाहरण के लिए `3.5`:

```sh
node -p process.versions.openssl
openssl version
```

यदि `openssl` कमांड नहीं मिला, तो पहले `openssl` पैकेज स्थापित करें।

## **प्रोजेक्ट बनाएं**

अपने प्रोजेक्ट के लिए एक फ़ोल्डर बनाएं, उसे इनिशियलाइज़ करें, और एक ओवरराइड जोड़ें जो npm को बताता है कि कौन सा edge-js रिलीज़ इंस्टॉल करना है:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
```

पैकेज एक पुराना edge-js रिलीज़ चाहता है जिसकी प्रीबिल्ट Windows बाइनरीज़ Node.js 20 पर समाप्त होती हैं, इसलिए ओवरराइड के बिना Windows पर पहला स्क्रिप्ट "The edge module has not been pre-compiled for node.js version" के साथ रुक जाता है। यह कमांड `overrides` सेक्शन को `package.json` में लिखता है; पैकेज इंस्टॉल करने से पहले इसे जोड़ें।

## **पैकेज इंस्टॉल करें**

npm से Aspose.Slides for Node.js via .NET इंस्टॉल करें:

```sh
npm install aspose.slides.via.net
```

इंस्टॉलेशन के दौरान, पैकेज अपनी नेटिव ड्रॉइंग लाइब्रेरीज़ (वे फ़ाइलें जिनके नाम में `aspose.slides.drawing.capi` शामिल है) को प्रोजेक्ट फ़ोल्डर में, `package.json` के बगल में कॉपी करता है।

पैकेज को [releases.aspose.com](https://releases.aspose.com/slides/hi/nodejs-net/) पर ज़िप आर्काइव के रूप में भी प्रकाशित किया गया है। यह लेख केवल npm से इंस्टॉल करने को कवर करता है।

## **.NET निर्भरताएँ रीस्टोर करें**

पैकेज में Aspose.Slides .NET असेंबलीज़ हैं, लेकिन उन असेंबलीज़ की निर्भरता वाले 20 NuGet पैकेज नहीं होते। रनटाइम पर, .NET उन्हें NuGet पैकेज कैश में खोजता है: Windows पर `%USERPROFILE%\.nuget\packages`, Linux पर `~/.nuget/packages`, या `NUGET_PACKAGES` एनवायरनमेंट वैरिएबल में सेट फ़ोल्डर। यदि वे अनुपलब्ध हों, तो पहला स्क्रिप्ट "assembly specified in the dependencies manifest was not found" के साथ रुक जाता है।

कैश भरने के लिए, प्रोजेक्ट फ़ोल्डर में `deps` नाम का फ़ोल्डर बनाएं और उसमें निम्न फ़ाइल को `deps.csproj` के रूप में सहेजें। प्रत्येक `PackageDownload` आइटम ब्रैकेट में निर्दिष्ट सटीक संस्करण के एक पैकेज को डाउनलोड करता है; कुछ भी बिल्ड नहीं होता।

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

फिर प्रोजेक्ट फ़ोल्डर से इसे रीस्टोर करें:

```sh
dotnet restore deps/deps.csproj
```

यह चरण प्रत्येक मशीन पर एक बार आवश्यक है, प्रत्येक प्रोजेक्ट पर नहीं: पैकेज NuGet कैश में रहते हैं, और उसी मशीन पर बाद के प्रोजेक्ट इन्हें उपयोग कर सकते हैं। रीस्टोर के बाद, आप `deps` फ़ोल्डर को हटा सकते हैं।

## **पहला प्रोग्राम चलाएँ**

प्रोजेक्ट फ़ोल्डर में `hello.js` नाम की फ़ाइल निम्न कोड के साथ बनाएं। यह एक प्रस्तुति बनाता है, प्रथम स्लाइड में "Hello, World!" पाठ के साथ एक आयत जोड़ता है, और परिणाम को `hello.pptx` के रूप में सहेजता है:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// एक नया प्रस्तुति एक खाली स्लाइड शामिल करता है।
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // स्थान और आकार पॉइंट्स में हैं (1/72 इंच): x, y, चौड़ाई, ऊँचाई।
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // प्रस्तुति को सपोर्ट करने वाले .NET ऑब्जेक्ट को रिलीज़ करें।
    presentation.dispose();
}
```

प्रोजेक्ट फ़ोल्डर से इसे चलाएँ:

```sh
node hello.js
```

स्क्रिप्ट `Saved hello.pptx` प्रिंट करता है। `hello.pptx` खोलें ताकि एक स्लाइड देखें जिसमें भराव वाले आयत के अंदर पाठ हो। बिना लाइसेंस के, Aspose.Slides एक मूल्यांकन वाटरमार्क भी जोड़ता है; देखें [Evaluate Aspose.Slides](/slides/hi/nodejs-net/evaluate-aspose-slides/) और [Licensing](/slides/hi/nodejs-net/licensing/)।

{{% alert color="info" title="Note" %}}
अपनी स्क्रिप्ट्स को प्रोजेक्ट फ़ोल्डर से चलाएँ, वह फ़ोल्डर जिसमें `package.json` है। `hello.pptx` जैसे रिलेटिव पाथ वर्तमान फ़ोल्डर के सापेक्ष हल होते हैं, और कुछ मशीनों पर किसी अन्य फ़ोल्डर से शुरू की गई स्क्रिप्ट प्रस्तुति नहीं बना सकती।
{{% /alert %}}

JavaScript API Aspose.Slides for .NET का प्रतिबिंब है: क्लासेस अपने .NET नाम बनाए रखते हैं, प्रॉपर्टीज़ और मेथड्स camelCase का उपयोग करते हैं (`Slides` बन जाता है `slides`, `AddAutoShape` बन जाता है `addAutoShape`), और कलेक्शन आइटम्स को `get(index)` से पढ़ा जाता है। इस पैकेज के लिए अलग API रेफ़रेंस नहीं है, इसलिए क्लास और मेंबर विवरण के लिए [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/hi/net/) का उपयोग करें, उदाहरण के लिए [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) और [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/shapecollection/addautoshape/)।

## **अक्सर पूछे जाने वाले प्रश्न**

**"The edge module has not been pre-compiled for node.js version" का क्या मतलब है?**

npm ने वह पुराना edge-js रिलीज़ स्थापित किया था जो पैकेज माँगता है। [Create a Project](#create-a-project) से ओवरराइड जोड़ें और `npm install` फिर से चलाएँ।

**"assembly specified in the dependencies manifest was not found" का क्या मतलब है?**

.NET निर्भरताएँ NuGet कैश में नहीं हैं। वही रन "edge.initializeClrFunc is not a function" भी रिपोर्ट करता है। एक बार [Restore the .NET Dependencies](#restore-the-net-dependencies) का पालन करें, फिर अपनी स्क्रिप्ट फिर चलाएँ।

**Linux पर "The edge native module is not available" का क्या मतलब है?**

`npm install` के दौरान edge-js कंपाइल नहीं हुआ था, उदाहरण के लिए क्योंकि `python3`, `make` या `g++` अनुपलब्ध था। npm इसे त्रुटि के रूप में रिपोर्ट नहीं करता। बिल्ड टूल्स इंस्टॉल करें, फिर प्रोजेक्ट फ़ोल्डर में `npm rebuild edge-js` चलाएँ।

**एक खाली "Error" के साथ प्रस्तुति बनाना क्यों विफल हो रहा है?**

Linux पर, जाँचें कि fontconfig लाइब्रेरी (`libfontconfig1` Debian पर) स्थापित है; इसके बिना नेटिव ड्रॉइंग लाइब्रेरी लोड नहीं हो पाएगी। किसी भी सिस्टम पर, यह भी सुनिश्चित करें कि आप स्क्रिप्ट को प्रोजेक्ट फ़ोल्डर से चलाएँ।

**Linux पर Node.js सेगमेंटेशन फॉल्ट के साथ क्यों क्रैश हो रहा है?**

सिस्टम OpenSSL और Node.js में निर्मित OpenSSL विभिन्न रिलीज़ लाइनों से हैं। इन्हें [Prerequisites](#prerequisites) में दिखाए अनुसार तुलना करें और ऐसा वितरण या Node.js बिल्ड उपयोग करें जहाँ वे मेल खाते हों।

**क्या मुझे प्रत्येक प्रोजेक्ट के लिए NuGet रीस्टोर दोहराना चाहिए?**

नहीं। रीस्टोर आपके यूज़र अकाउंट के लिए NuGet कैश भरता है, और उस मशीन पर हर प्रोजेक्ट वही कैश उपयोग करता है।