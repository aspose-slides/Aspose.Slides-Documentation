---
title: ".NET 6 और बाद के लिए क्रॉस‑प्लैटफ़ॉर्म पैकेज"
linktitle: "क्रॉस‑प्लैटफ़ॉर्म पैकेज"
type: docs
weight: 235
url: /hi/net/net6/
keywords:
- Aspose.Slides.NET6.CrossPlatform
- क्रॉस‑प्लैटफ़ॉर्म
- .NET 6 समर्थन
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
description: "जानिए कब Aspose.Slides.NET6.CrossPlatform पैकेज का उपयोग करना है: यह क्यों मौजूद है, यह किन प्लेटफ़ॉर्म पर चलता है, और Linux पर libgdiplus के बजाय इसे क्या चाहिए।"
---
## **परिचय**

Aspose.Slides for .NET दो NuGet पैकेजों के रूप में प्रकाशित किया गया है। [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) Microsoft के System.Drawing.Common लाइब्रेरी का उपयोग करके स्लाइड बनाता है। [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) अपने स्वयं के ग्राफ़िक्स इंजन के साथ यह कार्य करता है। यह लेख समझाता है कि दूसरा पैकेज क्यों मौजूद है, यह कहाँ चलता है, लिनक्स पर इसे क्या चाहिए, और यह System.Drawing.Common के साथ एक प्रोजेक्ट में कैसे सह-अस्तित्व रखता है।

## **एक अलग पैकेज क्यों?**

.NET 6 से शुरू होकर, Microsoft ने System.Drawing.Common को **केवल Windows पर** समर्थन दिया है ([सिर्फ Windows पर](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only))। परिणामस्वरूप, Linux पर Aspose.Slides.NET को `System.Drawing.EnableUnixSupport` स्विच के साथ `libgdiplus` लाइब्रेरी की भी आवश्यकता होती है, और यदि प्रोजेक्ट System.Drawing.Common 7 या बाद का संदर्भित करता है तो यह विफल हो जाता है। [सिस्टम आवश्यकताएँ](/slides/hi/net/system-requirements/) इन शर्तों का वर्णन करती हैं।

Aspose.Slides.NET6.CrossPlatform System.Drawing.Common या `libgdiplus` का उपयोग नहीं करता। इसका ग्राफ़िक्स इंजन एक नेटिव लाइब्रेरी है जो पैकेज में प्रत्येक समर्थित प्लेटफ़ॉर्म के लिए एक बिल्ड के रूप में शामिल है। दोनों पैकेज समान Aspose.Slides नेमस्पेस और क्लासेज़ प्रदान करते हैं, इसलिए एक से दूसरे में स्विच करने से केवल पैकेज रेफ़रेंस बदलता है, आपका कोड नहीं।

| | Aspose.Slides.NET | Aspose.Slides.NET6.CrossPlatform |
|---|---|---|
| ग्राफ़िक्स | System.Drawing.Common | पैकेज में शामिल नेटिव ग्राफ़िक्स इंजन |
| लक्षित फ़्रेमवर्क | `net462`, `net6.0`, `netstandard2.0` | `net6.0` |
| Linux आवश्यकताएँ | `libgdiplus` और `System.Drawing.EnableUnixSupport` स्विच | `fontconfig` |
| Alpine Linux | समर्थित | असमर्थित |

## **समर्थित प्लेटफ़ॉर्म**

Aspose.Slides.NET6.CrossPlatform .NET 6 और बाद के संस्करणों के साथ निम्नलिखित प्लेटफ़ॉर्म पर काम करता है:

- **Windows**: x86 और x64। नेटिव लाइब्रेरी Microsoft Visual C++ runtime का उपयोग करती है; देखें [सिस्टम आवश्यकताएँ](/slides/hi/net/system-requirements/)।
- **Linux**: x64 जिसमें glibc 2.23 या बाद का संस्करण हो, और ARM64 जिसमें glibc 2.39 या बाद का संस्करण हो।
- **macOS**: x64 (Intel) और ARM64 (Apple silicon)।

यह Windows पर ARM64, Alpine Linux या अन्य musl‑आधारित वितरण, तथा पुरानी glibc (जैसे CentOS 7) वाले वितरणों पर नहीं चलता। उन सिस्टमों पर Aspose.Slides.NET का उपयोग करें।

## **Linux पर स्थापना**

Linux पर पैकेज को `fontconfig` लाइब्रेरी की आवश्यकता होती है, लेकिन `libgdiplus` की नहीं। Debian और Ubuntu पर `fontconfig` स्थापित करें और फिर पैकेज को अपने प्रोजेक्ट में जोड़ें:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

Debian और Ubuntu पर `libfontconfig1` DejaVu फ़ॉन्ट भी स्थापित करता है, जिससे टेक्स्ट अतिरिक्त फ़ॉन्ट पैकेजों के बिना रेंडर होता है। `fontconfig` के बिना, एक [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) बनाने पर `TypeInitializationException` उत्पन्न होती है, जिसकी आंतरिक `DllNotFoundException` यह रिपोर्ट करती है कि `libfontconfig.so.1` खोला नहीं जा सकता। [सिस्टम आवश्यकताएँ](/slides/hi/net/system-requirements/) में इस सेटअप की जाँच के लिए एक छोटा प्रोग्राम दिया गया है।

## **क्लाउड और कंटेनर होस्ट**

क्योंकि इसे `libgdiplus` की आवश्यकता नहीं है, Aspose.Slides.NET6.CrossPlatform उन Linux होस्ट्स पर उपयोग करने के लिए उपयुक्त है जहाँ आप `libgdiplus` स्थापित नहीं कर सकते। फिर भी इसे `fontconfig` और फ़ॉन्ट्स की जरूरत होती है, जो न्यूनतम बेस इमेज़ में नहीं हो सकते। उदाहरण के लिए, .NET 8 के लिए AWS Lambda बेस इमेज़ में न तो `fontconfig` है न ही फ़ॉन्ट्स। ऐसी कंटेनर इमेज़ में `dnf install -y fontconfig` चलाएँ, जो Noto Sans फ़ॉन्ट भी स्थापित करता है।

विशिष्ट क्लाउड प्लेटफ़ॉर्म के लिए मार्गदर्शिकाएँ देखें: [Aspose.Slides क्लाउड प्लेटफ़ॉर्म्स](/slides/hi/net/slides-on-cloud-platforms/)।

## **एक ही प्रोजेक्ट में System.Drawing.Common का उपयोग (CS0433)**

Aspose.Slides.NET6.CrossPlatform का उपयोग करने वाला प्रोजेक्ट System.Drawing.Common को भी संदर्भित कर सकता है, चाहे सीधे या किसी अन्य पैकेज के माध्यम से। Aspose.Slides का वर्तमान संस्करण `System` नेमस्पेस में कोई सार्वजनिक प्रकार नहीं उजागर करता, इसलिए दोनों लाइब्रेरीज़ में टकराव नहीं होता, और आप उसी फ़ाइल में `Aspose.Slides` और `System.Drawing` नेमस्पेस दोनों को इम्पोर्ट कर सकते हैं।

यदि कंपाइलर CS0433 त्रुटि देता है क्योंकि `Image` या `Graphics` जैसे प्रकार दोनों Aspose.Slides और System.Drawing.Common में मौजूद हैं, तो आपका प्रोजेक्ट Aspose.Slides के पुराने संस्करण का उपयोग कर रहा है। पैकेज को नवीनतम संस्करण में अपडेट करें। Aspose.Slides रेंडर की गई छवियों को [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) ऑब्जेक्ट्स के रूप में लौटाता है, जिसके बारे में जानकारी [Modern API](/slides/hi/net/modern-api/) में दी गई है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे Aspose.Slides.NET से Aspose.Slides.NET6.CrossPlatform में स्विच करने पर अपना कोड बदलना पड़ेगा?**

नहीं। दोनों पैकेज समान Aspose.Slides नेमस्पेस और क्लासेज़ प्रदान करते हैं, इसलिए आपको केवल पैकेज रेफ़रेंस बदलना है। Aspose.Slides.NET6.CrossPlatform को `System.Drawing.EnableUnixSupport` स्विच की आवश्यकता नहीं होती। प्रोजेक्ट में दोनों में से केवल एक पैकेज जोड़ें।

**क्या मैं Aspose.Slides.NET6.CrossPlatform को .NET Framework प्रोजेक्ट में उपयोग कर सकता हूँ?**

नहीं। यह पैकेज केवल .NET 6 और बाद के संस्करणों को लक्षित करता है। .NET Framework 4.6.2 और बाद के लिए, Aspose.Slides.NET का उपयोग करें।