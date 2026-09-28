---
title: सिस्टम आवश्यकताएँ
type: docs
weight: 60
url: /hi/net/system-requirements/
keywords:
- सिस्टम आवश्यकताएँ
- समर्थित प्लेटफ़ॉर्म
- लक्षित फ़्रेमवर्क
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
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "इंस्टॉल करने से पहले Aspose.Slides for .NET को क्या चाहिए, यह जांचें: प्रत्येक NuGet पैकेज द्वारा लक्षित फ्रेमवर्क, समर्थित ऑपरेटिंग सिस्टम और प्रोसेसर, तथा Linux को आवश्यक लाइब्रेरी और फ़ॉन्ट।"
---
## **परिचय**

Aspose.Slides for .NET एक स्वतंत्र लाइब्रेरी है: इसे Microsoft PowerPoint या Microsoft Office की आवश्यकता नहीं होती। यह दो NuGet पैकेजों के रूप में प्रकाशित की गई है, [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) और [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/). दोनों ही एक ही Aspose.Slides नेमस्पेस और क्लासेज़ प्रदान करते हैं; वे लक्षित फ्रेमवर्क और स्लाइड्स ड्रॉ करने के तरीके में अलग होते हैं, जिससे यह निर्धारित होता है कि वे कहाँ चलेंगे और उन्हें क्या चाहिए।

यह लेख प्रत्येक पैकेज द्वारा समर्थित .NET संस्करणों और प्लेटफ़ॉर्मों की सूची देता है, साथ ही लिनक्स को आवश्यक सिस्टम लाइब्रेरी और फ़ॉन्ट, और अंत में एक छोटा प्रोग्राम है जो आपके सेटअप की जाँच करता है। किसी प्रोजेक्ट में पैकेज जोड़ने के लिए, देखें [Installation](/slides/hi/net/installation/).

## **समर्थित .NET संस्करण**

प्रत्येक पैकेज में लक्ष्य फ़्रेमवर्क के अनुसार Aspose.Slides की एक बिल्ड शामिल होती है, और NuGet उस बिल्ड को चुनता है जो आपके प्रोजेक्ट के लक्ष्य फ़्रेमवर्क से मेल खाती है।

| पैकेज | पैकेज में लक्ष्य फ़्रेमवर्क | आपका प्रोजेक्ट लक्ष्य बना सकता है |
|---|---|---|
| Aspose.Slides.NET | `net462`, `net6.0`, `netstandard2.0` | .NET Framework 4.6.2 या बाद का; .NET 6 या बाद का, जिसमें .NET 8, .NET 9, और .NET 10 शामिल हैं |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | .NET 6 या बाद का, जिसमें .NET 8, .NET 9, और .NET 10 शामिल हैं |

`netstandard2.0` बिल्ड एक .NET Standard 2.0 क्लास लाइब्रेरी को Aspose.Slides.NET का संदर्भ देने देती है। ऐसी लाइब्रेरी का उपयोग करने वाला एप्लिकेशन वह बिल्ड चलाता है जो एप्लिकेशन के अपने लक्ष्य फ़्रेमवर्क से मेल खाती है: उदाहरण के तौर पर, एक .NET 8 एप्लिकेशन `net6.0` बिल्ड चलाता है।

## **समर्थित ऑपरेटिंग सिस्टम और प्रोसेसर**

**Aspose.Slides.NET** केवल प्रोसेसर-स्वतंत्र (AnyCPU) मैनेज्ड कोड रखता है, इसलिए यह उस .NET रनटाइम की प्रोसेसर आर्किटेक्चर पर चलता है जो इसे लोड करता है। यह स्लाइड्स को Microsoft के System.Drawing.Common लाइब्रेरी के माध्यम से ड्रॉ करता है, जिसे Microsoft [only on Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only) समर्थन देता है। लिनक्स पर, Aspose.Slides.NET को इसलिए `libgdiplus` लाइब्रेरी और एक स्टार्टअप स्विच की आवश्यकता होती है, जैसा कि [Linux](#linux) में वर्णित है। यह उन लिनक्स डिस्ट्रिब्यूशन्स पर चलता है जो `libgdiplus` प्रदान करती हैं, जैसे Debian, Ubuntu, और Alpine Linux.

**Aspose.Slides.NET6.CrossPlatform** अपनी स्वयं की ग्राफ़िक्स इंजन के साथ स्लाइड्स ड्रॉ करता है। यह इंजन एक नेटिव लाइब्रेरी है जो पैकेज प्रत्येक प्लेटफ़ॉर्म के लिए एक बिल्ड में शामिल करता है, इसलिए पैकेज केवल इन प्लेटफ़ॉर्म पर चलता है:

| ऑपरेटिंग सिस्टम | प्रोसेसर | नोट्स |
|---|---|---|
| Windows | x86, x64 | ARM64 पर Windows समर्थित नहीं है। |
| Linux | x64, ARM64 | x64 पर glibc 2.23 या बाद का और ARM64 पर glibc 2.39 या बाद का आवश्यक है। |
| macOS | x64 (Intel), ARM64 (Apple silicon) | |

**Aspose.Slides.NET6.CrossPlatform** Alpine Linux या अन्य वितरणों पर नहीं चलता जो glibc के बजाय musl पर निर्मित हैं, या उन वितरणों पर जिनमें पुराना glibc है, जैसे CentOS 7। ऐसे सिस्टम पर Aspose.Slides.NET का उपयोग करें।

विंडोज़ पर, Aspose.Slides.NET6.CrossPlatform की नेटिव लाइब्रेरी Microsoft Visual C++ रनटाइम (*MSVCP140.dll* और *VCRUNTIME140.dll*, साथ ही x64 पर *VCRUNTIME140_1.dll*) का उपयोग करती है। यदि ये फ़ाइलें लक्ष्य मशीन पर नहीं हैं, तो [Microsoft Visual C++ Redistributable](https://learn.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170) स्थापित करें।

## **लिनक्स**

दोनों पैकेजों को लिनक्स पर अतिरिक्त सिस्टम लाइब्रेरी की आवश्यकता होती है। इनके बिना, [Create Presentations](/slides/hi/net/create-presentation/) में पहला उदाहरण फ़ाइल को सहेजने के बजाय अपवाद के साथ विफल हो जाता है। नीचे दिए गए कमांड Debian और Ubuntu के लिए हैं; इन वितरणों में, प्रत्येक लाइब्रेरी `fonts-dejavu-core` के माध्यम से DejaVu फ़ॉन्ट भी लाती है, इसलिए टेक्स्ट आगे के फ़ॉन्ट पैकेजों के बिना रेंडर होता है।

### **Aspose.Slides.NET6.CrossPlatform**

पैकेज की लिनक्स लाइब्रेरी को `fontconfig` लाइब्रेरी की आवश्यकता होती है:
```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
```

इसके बिना, [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) बनाना `TypeInitializationException` के साथ विफल हो जाता है, जिसकी भीतरी `DllNotFoundException` रिपोर्ट करती है कि `libfontconfig.so.1` को नहीं खोला जा सकता।

न्यूनतम बेस इमेज में शायद `fontconfig` शामिल न हो। उदाहरण के तौर पर, .NET 8 के लिए AWS Lambda बेस इमेज में न तो `fontconfig` है और न ही कोई फ़ॉन्ट। ऐसी इमेज पर आधारित कंटेनर इमेज में, `dnf install -y fontconfig` चलाएँ, जो Noto Sans फ़ॉन्ट भी स्थापित करता है।

### **Aspose.Slides.NET**

पैकेज को लिनक्स पर दो चीज़ों की आवश्यकता होती है:

1. `libgdiplus` लाइब्रेरी:
   ```bash
   sudo apt-get update && sudo apt-get install -y libgdiplus
   ```

2. `System.Drawing.EnableUnixSupport` स्विच, जो आपके एप्लिकेशन की शुरुआत में, किसी भी Aspose.Slides कॉल से पहले सक्षम किया जाता है। शीर्ष-स्तरीय स्टेटमेंट वाले *Program.cs* में, इसे `using` निर्देशों के बाद रखें:
   ```c#
   System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
   ```

`libgdiplus` के बिना, प्रस्तुति को सहेजना `TypeInitializationException` के साथ विफल हो जाता है, जिसकी भीतरी `DllNotFoundException` रिपोर्ट करती है कि `libgdiplus` लोड नहीं किया जा सकता। स्विच के बिना, भीतरू अपवाद `PlatformNotSupportedException: System.Drawing.Common is not supported on non-Windows platforms` होता है।

{{% alert color="warning" title="Warning" %}}
स्विच केवल System.Drawing.Common 6 के साथ काम करता है, वह संस्करण जिसपर Aspose.Slides.NET निर्भर है। Microsoft ने इसे System.Drawing.Common 7 में हटा दिया। यदि आपका प्रोजेक्ट System.Drawing.Common 7 या उससे बाद का संदर्भ देता है, सीधे या किसी अन्य पैकेज के माध्यम से, तो Aspose.Slides.NET लिनक्स पर `PlatformNotSupportedException` के साथ विफल हो जाता है, भले ही `libgdiplus` स्थापित हो और स्विच सक्षम हो। ऐसे में, Aspose.Slides.NET6.CrossPlatform का उपयोग करें।
{{% /alert %}}

### **Alpine Linux**

Alpine Linux पर, ऊपर वर्णित स्विच के साथ Aspose.Slides.NET का उपयोग करें। Alpine इमेज में आमतौर पर कोई फ़ॉन्ट नहीं होते, और केवल `libgdiplus` किसी फ़ॉन्ट को स्थापित नहीं करता, इसलिए कम से कम एक फ़ॉन्ट पैकेज के साथ `libgdiplus` स्थापित करें। फ़ॉन्ट के बिना, प्रस्तुति को सहेजना इस त्रुटि के साथ विफल हो जाता है:
```text
System.ArgumentException: Font '?' cannot be found.
```

**विकल्प 1: DejaVu फ़ॉन्ट**

अनुशंसित विकल्प `ttf-dejavu` पैकेज है:
```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

वर्तमान Alpine रिलीज़ में, `ttf-dejavu` `font-dejavu` पैकेज स्थापित करता है, जो `fontconfig` और निर्भर फ़ॉन्ट टूल्स भी स्थापित करता है।

**विकल्प 2: Microsoft कोर फ़ॉन्ट**

यदि आपकी प्रस्तुतियों में Arial, Times New Roman, Courier New, या Verdana जैसे Microsoft फ़ॉन्ट का प्रयोग होता है, तो Microsoft कोर फ़ॉन्ट स्थापित करें। `update-ms-fonts` चरण इमेज निर्माण के दौरान फ़ॉन्ट डाउनलोड करता है, इसलिए निर्माण के लिए इंटरनेट एक्सेस आवश्यक होता है:
```dockerfile
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

### **वैश्विकी समर्थन**

दोनों पैकेजों को .NET ग्लोबलाईज़ेशन समर्थन चाहिए, जिसे Linux पर .NET ICU लाइब्रेरी के माध्यम से प्रदान करता है। [globalization-invariant mode](https://learn.microsoft.com/en-us/dotnet/core/runtime-config/globalization) में, एक [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) बनाना `CultureNotFoundException: Only the invariant culture is supported in globalization-invariant mode` के साथ विफल हो जाता है।

कुछ कंटेनर इमेज इस मोड को चालू करती हैं। Alpine Linux के लिए .NET रनटाइम इमेज (`runtime-deps`, `runtime`, और `aspnet`), उदाहरण के तौर पर, `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=true` सेट करती हैं और ICU शामिल नहीं करतीं। इन पर आधारित इमेज में, ICU स्थापित करें और मोड को बंद करें:
```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

साथ ही सुनिश्चित करें कि आपके प्रोजेक्ट फ़ाइल में `InvariantGlobalization` प्रॉपर्टी `true` पर सेट न हो।

## **अपना सेटअप जांचें**

यह जांचने के लिए कि पैकेज और उसकी आवश्यकताएँ सही हैं, एक प्रोग्राम चलाएँ जो प्रस्तुति को सहेजता है और स्लाइड को छवि में रेंडर करता है। सहेजना और रेंडर करना ग्राफ़िक्स लाइब्रेरी और फ़ॉन्ट्स का उपयोग करता है, जो उपर्युक्त लिनक्स आवश्यकताओं द्वारा प्रदान किए गए हैं।

एक कंसोल एप्लिकेशन बनाएँ और पैकेज को [Installation](/slides/hi/net/installation/) में वर्णित अनुसार जोड़ें, *Program.cs* की सामग्री को नीचे दिए गए कोड से बदलें, और `dotnet run` चलाएँ। यदि आप Linux पर Aspose.Slides.NET उपयोग करते हैं, तो `System.Drawing.EnableUnixSupport` स्विच स्टेटमेंट को `using` निर्देशों के बाद जोड़ें जैसा कि [Linux](#linux) में दिखाया गया है। प्रोग्राम टॉप-लेवल स्टेटमेंट्स और `using` घोषणाओं का उपयोग करता है, जिसके लिए C# 9 या बाद का आवश्यक है। .NET 6 या बाद को लक्षित करने वाले प्रोजेक्ट डिफ़ॉल्ट रूप से नया C# संस्करण उपयोग करते हैं; यदि प्रोजेक्ट .NET Framework को लक्षित करता है, तो प्रोजेक्ट फ़ाइल में `PropertyGroup` के भीतर `<LangVersion>latest</LangVersion>` जोड़ें।
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

यह प्रोग्राम पहले स्लाइड में टेक्स्ट वाला एक आयत जोड़ता है और प्रस्तुति को *hello.pptx* के रूप में [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) मेथड से सहेजता है। फिर यह स्लाइड को [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) के साथ रेंडर करता है और परिणाम को *hello.png* के रूप में [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) द्वारा [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) फ़ॉर्मेट में सहेजता है। स्केल फैक्टर 1 एक प्वाइंट पर एक पिक्सेल रेंडर करता है, इसलिए डिफ़ॉल्ट 720 × 540 प्वाइंट स्लाइड 720 × 540 पिक्सेल छवि बन जाती है, जिसमें आयत के भीतर टेक्स्ट दिखाई देता है। बिना लाइसेंस के, दोनों फ़ाइलों में मूल्यांकन वॉटरमार्क भी होता है; देखें [Licensing](/slides/hi/net/licensing/). यदि कोई आवश्यकता अनुपलब्ध है, तो प्रोग्राम [Linux](#linux) में वर्णित अपवादों में से एक के साथ रुक जाता है।

## **विकास उपकरण**

आप Aspose.Slides का उपयोग करने वाले एप्लिकेशन को किसी भी टूल के साथ बना सकते हैं जो आपके प्रोजेक्ट के लक्ष्य फ़्रेमवर्क का समर्थन करता है: Windows, Linux, और macOS पर .NET SDK और उसका `dotnet` कमांड‑लाइन इंटरफ़ेस, या Windows पर Visual Studio। [Installation](/slides/hi/net/installation/) दोनों को वर्णित करता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे परिवर्तनों और रेंडरिंग के लिए Microsoft PowerPoint स्थापित करना आवश्यक है?**

नहीं, PowerPoint आवश्यक नहीं है। Aspose.Slides एक स्वतंत्र इंजन है जो प्रस्तुतियों को [creating](/slides/hi/net/create-presentation/), संशोधित करने, [converting](/slides/hi/net/convert-presentation/), और [rendering](/slides/hi/net/convert-powerpoint-to-png/) के लिए उपयोग होता है।

**मुझे कौन सा पैकेज उपयोग करना चाहिए?**

Windows पर Aspose.Slides.NET और Linux एवं macOS पर Aspose.Slides.NET6.CrossPlatform का उपयोग करें। Alpine Linux पर, उन Linux सिस्टम पर जिनमें glibc ऊपर सूचीबद्ध संस्करणों से पुराना है, तथा उन प्रोजेक्ट्स में जो .NET Framework को लक्षित करते हैं, Aspose.Slides.NET का उपयोग करें। किसी प्रोजेक्ट में केवल इन दो पैकेजों में से एक ही जोड़ें।

**सही रेंडरिंग के लिए कौन से फ़ॉन्ट आवश्यक हैं?**

प्रस्तुति में उपयोग किए गए फ़ॉन्ट, या उपयुक्त विकल्प, ऑपरेटिंग सिस्टम में उपलब्ध होने चाहिए। Linux और macOS पर, निरंतर रेंडरिंग के लिए अपनी प्रस्तुतियों को आवश्यक फ़ॉन्ट पैकेज स्थापित करें। Alpine Linux पर, `libgdiplus` के अतिरिक्त कम से कम एक फ़ॉन्ट पैकेज स्थापित करें, जैसा कि [Alpine Linux](#alpine-linux) में बताया गया है।

**Linux पर कस्टम फ़ॉन्ट फ़ॉलबैक या गायब टेक्स्ट क्यों दिखाता है?**

यदि फ़ॉन्ट फ़ाइल में असंगत या भ्रष्ट name-table एंट्रीज़ हैं, तो Linux फ़ॉन्ट‑मॅचिंग स्टैक (FreeType/fontconfig) एक अमान्य रिकॉर्ड चुन सकता है, जिससे फ़ॉन्ट अनसुलझा रहता है। सही name-table रिकॉर्ड वाले फ़ॉन्ट संस्करण का उपयोग करने या संगत विकल्प स्थापित करने से समस्या हल हो जाती है।