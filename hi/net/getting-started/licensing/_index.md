---
title: लाइसेंसिंग
type: docs
weight: 80
url: /hi/net/licensing/
keywords:
- लाइसेंस
- अस्थायी लाइसेंस
- लाइसेंस सेट करें
- लाइसेंस उपयोग करें
- लाइसेंस सत्यापित करें
- लाइसेंस फ़ाइल
- मूल्यांकन संस्करण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में लाइसेंस लागू करें, प्रबंधित करें और समस्या निवारण करें। हमारे चरण‑बद्ध लाइसेंसिंग मार्गदर्शिका के साथ पूर्ण सुविधाओं तक निरंतर पहुँच सुनिश्चित करें।"
---
## **Overview**

Aspose.Slides को मूल्यांकन मोड में या वैध लाइसेंस के साथ उपयोग किया जा सकता है। मूल्यांकन संस्करण लाइसensed संस्करण के समान कार्यक्षमता प्रदान करता है, लेकिन यह प्रस्तुतियों को खोलने या सहेजने पर एक मूल्यांकन जलचिह्न जोड़ता है और टेक्स्ट निष्कर्षण को एक स्लाइड तक सीमित करता है।

यह लेख बताता है कि Aspose.Slides में लाइसेंसिंग कैसे काम करती है और लाइब्रेरी का उपयोग करने से पहले लाइसेंस कैसे लागू किया जाए। लाइसेंस को `License` क्लास का उपयोग करके फ़ाइल, स्ट्रीम, या एंबेडेड रिसोर्स से लोड किया जा सकता है। लेख यह भी दर्शाता है कि लाइसेंस सही ढंग से लागू हुआ है या नहीं, इसे कैसे सत्यापित करें।

## **Evaluate Aspose.Slides**

{{% alert color="info" %}} 

आप **Aspose.Slides for NET** का मूल्यांकन संस्करण [its NuGet download page](https://www.nuget.org/packages/Aspose.Slides.NET/) से डाउनलोड कर सकते हैं। मूल्यांकन संस्करण उत्पाद के लाइसensed संस्करण की समान कार्यात्मकताएँ प्रदान करता है। मूल्यांकन पैकेज खरीद के पैकेज के समान ही है। मूल्यांकन संस्करण बस कुछ कोड पंक्तियों को जोड़ने (लाइसेंस लागू करने) के बाद लाइसensed बन जाता है।

एक बार जब आप **Aspose.Slides** का मूल्यांकन कर लेते हैं, तो आप [purchase a license](https://purchase.aspose.com/buy) कर सकते हैं। हम अनुशंसा करते हैं कि आप विभिन्न सब्सक्रिप्शन प्रकारों को देखें। यदि आपके कोई प्रश्न हैं, तो Aspose बिक्री टीम से संपर्क करें।

हर Aspose लाइसेंस के साथ एक साल का सब्सक्रिप्शन मुफ्त अपग्रेड और सब्सक्रिप्शन अवधि के भीतर जारी किए गए फिक्सेस के लिए आता है। लाइसensed उत्पाद या यहाँ तक कि मूल्यांकन संस्करण वाले उपयोगकर्ताओं को मुफ्त और असीमित तकनीकी समर्थन मिलता है।

{{% /alert %}} 

**Evaluation version limitations**

* जबकि Aspose.Slides मूल्यांकन संस्करण (बिना लाइसेंस निर्दिष्ट) पूर्ण उत्पाद कार्यक्षमता प्रदान करता है, यह खोलने और सहेजने के दौरान दस्तावेज़ के शीर्ष पर एक मूल्यांकन जलचिह्न सम्मिलित करता है। 
* प्रस्तुति स्लाइड्स से टेक्स्ट निकालते समय आप केवल एक स्लाइड तक ही सीमित हैं।

{{% alert color="info" %}} 

सीमाओं के बिना Aspose.Slides का परीक्षण करने के लिए, आप **30-Day Temporary License** के लिए अनुरोध कर सकते हैं। अधिक जानकारी के लिए देखें [How to get a Temporary License](https://purchase.aspose.com/temporary-license) पृष्ठ।

{{% /alert %}}

## **Licensing in Aspose.Slides**
* एक मूल्यांकन संस्करण लाइसensed बन जाता है जब आप लाइसेंस खरीदते हैं और कुछ कोड पंक्तियों को जोड़ते हैं (लाइसेंस लागू करने के लिए)।
* लाइसेंस एक साधारण‑टेक्स्ट XML फ़ाइल है जिसमें उत्पाद का नाम, लाइसेंस प्राप्त डेवलपर्स की संख्या, सब्सक्रिप्शन समाप्ति तिथि आदि जैसी जानकारी होती है। 
* लाइसेंस फ़ाइल डिजिटल रूप से साइन की गई है, इसलिए आपको फ़ाइल में कोई परिवर्तन नहीं करना चाहिए। फ़ाइल की सामग्री में एक अतिरिक्त लाइन ब्रेक भी जोड़ने से लाइसेंस अमान्य हो जाएगा।
* Aspose.Slides for .NET आमतौर पर लाइसेंस को इन स्थानों पर खोजता है:
  * एक स्पष्ट पथ
  * घटक की DLL वाले फ़ोल्डर (Aspose.Slides में शामिल)
  * उस असेंबली का फ़ोल्डर जिसने घटक की DLL को कॉल किया (Aspose.Slides में शामिल)
  * एंट्री असेंबली का फ़ोल्डर (आपका .exe)
  * उस असेंबली में एंबेडेड रिसोर्स जो घटक की DLL को कॉल करती है (Aspose.Slides में शामिल)।
* मूल्यांकन संस्करण से जुड़ी सीमाओं से बचने के लिए, आपको Aspose.Slides का उपयोग करने से पहले लाइसेंस सेट करना होगा। आपको प्रत्येक एप्लीकेशन या प्रोसेस में केवल एक बार लाइसेंस सेट करना आवश्यक है।

{{% alert color="info" %}} 

आप [Metered Licensing](https://docs.aspose.com/slides/hi/net/metered-licensing/) देखना चाह सकते हैं।

{{% /alert %}} 


## **Apply a License**
एक लाइसेंस को **फ़ाइल**, **स्ट्रीम**, या **एंबेडेड रिसोर्स** से लोड किया जा सकता है। 

{{% alert color="info" %}}

Aspose.Slides लाइसेंसिंग ऑपरेशन्स के लिए [License](https://reference.aspose.com/slides/hi/net/aspose.slides/license) क्लास प्रदान करता है।

{{% /alert %}} 

{{% alert color="warning" %}} 

नए लाइसेंस केवल संस्करण 21.4 या बाद के Aspose.Slides के साथ सक्रिय हो सकते हैं। पुराने संस्करण एक अलग लाइसेंसिंग सिस्टम का उपयोग करते हैं और इन लाइसेंसों को पहचान नहीं पाएंगे।

{{% /alert %}}

### **File**
लाइसेंस सेट करने की सबसे आसान विधि यह है कि आप लाइसेंस फ़ाइल को घटक की DLL वाले समान फ़ोल्डर (Aspose.Slides में शामिल) में रखें और केवल फ़ाइल नाम बिना पथ के निर्दिष्ट करें।

यह C# कोड दिखाता है कि लाइसेंस फ़ाइल कैसे सेट करें:

``` csharp
// लाइसेंस क्लास का उदाहरण बनाता है 
Aspose.Slides.License license = new Aspose.Slides.License();

// लाइसेंस फ़ाइल पथ सेट करता है
license.SetLicense("Aspose.Slides.lic");
```

{{% alert color="warning" %}} 

यदि आप लाइसेंस फ़ाइल को किसी अन्य निर्देशिका में रखते हैं, तो जब आप [SetLicense](https://reference.aspose.com/slides/hi/net/aspose.slides/license/setlicense/#setlicense_1) मेथड को कॉल करते हैं, तो निर्दिष्ट स्पष्ट पथ के अंत में लाइसेंस फ़ाइल नाम आपके वास्तविक लाइसेंस फ़ाइल के समान होना चाहिए।

उदाहरण के लिए, आप लाइसेंस फ़ाइल नाम को *Aspose.Slides.lic.xml* बदल सकते हैं। फिर, अपने कोड में, आपको फ़ाइल पथ (जो *Aspose.Slides.lic.xml* पर समाप्त होता है) को [SetLicense](https://reference.aspose.com/slides/hi/net/aspose.slides/license/setlicense/#setlicense_1) मेथड में पास करना होगा।

{{% /alert %}}

### **Stream**
आप एक स्ट्रीम से लाइसेंस लोड कर सकते हैं। यह C# कोड दिखाता है कि स्ट्रीम से लाइसेंस कैसे लागू करें:

``` csharp
// लाइसेंस क्लास का उदाहरण बनाता है
Aspose.Slides.License license = new Aspose.Slides.License();

// लाइसेंस फ़ाइल को स्ट्रीम के रूप में खोलता है
using FileStream licenseStream = File.OpenRead("Aspose.Slides.lic");

// स्ट्रीम के माध्यम से लाइसेंस सेट करता है
license.SetLicense(licenseStream);
```

### **Embedded Resource**
आप लाइसेंस को अपने एप्लीकेशन के साथ पैकेज कर सकते हैं (इसे खोने से बचाने के लिए) लाइसेंस को उस असेंबली में एंबेडेड रिसोर्स के रूप में जोड़कर जो घटक की DLL को कॉल करती है (Aspose.Slides में शामिल)। 

यहाँ लाइसेंस फ़ाइल को एंबेडेड रिसोर्स के रूप में जोड़ने का तरीका है:

1. Visual Studio में, इस प्रकार लाइसेंस (.lic) फ़ाइल को प्रोजेक्ट में जोड़ें: **File** > **Add Existing Item** > **Add** पर जाएँ। 
2. **Solution Explorer** में फ़ाइल का चयन करें। 
3. **Properties** विंडो में, **Build Action** को **Embedded Resource** सेट करें। 
4. असेंबली में एंबेडेड लाइसेंस तक पहुँचने के लिए, लाइसेंस फ़ाइल को एंबेडेड रिसोर्स के रूप में प्रोजेक्ट में जोड़ें, और फिर `SetLicense` मेथड में लाइसेंस फ़ाइल नाम पास करें। 

`License` क्लास एंबेडेड रिसोर्स में लाइसेंस फ़ाइल को स्वतः ढूँढ लेता है। आपको Microsoft .NET Framework में `System.Reflection.Assembly` क्लास के `GetExecutingAssembly` और `GetManifestResourceStream` मेथड को कॉल करने की आवश्यकता नहीं है।

यह C# कोड दिखाता है कि लाइसेंस को एंबेडेड रिसोर्स के रूप में कैसे सेट करें:

``` csharp
// लाइसेंस क्लास का उदाहरण बनाता है
Aspose.Slides.License license = new Aspose.Slides.License();

// असेंबली में एंबेडेड लाइसेंस फ़ाइल नाम पास करता है
license.SetLicense("Aspose.Slides.lic");
```

## **Validate a License**

यह जांचने के लिए कि लाइसेंस सही ढंग से सेट हुआ है या नहीं, आप इसे मान्य कर सकते हैं। यह C# कोड दिखाता है कि लाइसेंस को कैसे वैलिडेट करें:

```c#
Aspose.Slides.License license = new Aspose.Slides.License();

license.SetLicense("Aspose.Slides.lic");

if (license.IsLicensed())
{
    Console.WriteLine("License is good!");
    Console.Read();
}
```

## **Thread Safety**

{{% alert title="Note" color="warning" %}} 

`license.SetLicense` मेथड थ्रेड‑सेफ नहीं है। यदि इस मेथड को कई थ्रेड्स से एक साथ कॉल करना पड़े, तो समस्याओं से बचने के लिए आप सिंक्रोनाइज़ेशन प्रिमिटिव (जैसे लॉक) का उपयोग करना चाहेंगे। 

{{% /alert %}}

## **FAQ**

### Can I apply the license in a completely offline environment (no internet access)?

Yes. License validation is performed locally using the license file; no internet connection is required.

### What happens after the one-year subscription expires? Will the library stop working?

No. The license is perpetual: you can continue using versions released before your subscription end date; you just won’t be eligible to use newer releases without renewing.