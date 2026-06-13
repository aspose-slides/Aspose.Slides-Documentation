---
title: एण्ड्रॉइड पर XAML में प्रस्तुतियों का निर्यात
linktitle: प्रस्तुति को XAML में
type: docs
weight: 30
url: /hi/androidjava/export-to-xaml/
keywords:
- PowerPoint निर्यात करें
- OpenDocument निर्यात करें
- प्रस्तुति निर्यात करें
- PowerPoint रूपांतरण करें
- OpenDocument रूपांतरण करें
- प्रस्तुति रूपांतरण करें
- PowerPoint से XAML
- OpenDocument से XAML
- प्रस्तुति से XAML
- PPT से XAML
- PPTX से XAML
- ODP से XAML
- PPT को XAML के रूप में सहेजें
- PPTX को XAML के रूप में सहेजें
- ODP को XAML के रूप में सहेजें
- PPT को XAML में निर्यात करें
- PPTX को XAML में निर्यात करें
- ODP को XAML में निर्यात करें
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android का उपयोग करके जावा में PowerPoint और OpenDocument स्लाइड्स को XAML में परिवर्तित करें—तेज़, Office‑मुक्त समाधान जो आपके लेआउट को अपरिवर्तित रखता है।"
---
## **अवलोकन**

यह लेख बताता है कि Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को XAML में कैसे निर्यात किया जाए। इसमें XAML का संक्षिप्त परिचय, डिफ़ॉल्ट सेटिंग्स के साथ प्रस्तुति को XAML में सहेजने का तरीका, और [XamlOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/xamloptions/) के माध्यम से निर्यात को अनुकूलित करने का प्रदर्शन शामिल है, जिसमें छिपी हुई स्लाइड्स का निर्यात भी शामिल है। लेख में फ़ॉलबैक फ़ॉन्ट्स, XAML स्टैक संगतता, और छिपी हुई स्लाइड निर्यात व्यवहार से संबंधित कुछ सामान्य प्रश्नों के उत्तर भी दिए गए हैं।

## **XAML के बारे में**

XAML एक वर्णनात्मक प्रोग्रामिंग भाषा है जो आपको एप्लिकेशन के उपयोगकर्ता इंटरफ़ेस को बनाने या लिखने की अनुमति देती है, विशेष रूप से उन एप्लिकेशनों के लिए जो WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), और Xamarin Forms का उपयोग करते हैं।  

XAML, जो एक XML‑आधारित भाषा है, Microsoft का GUI वर्णन करने वाला स्वरूप है। आप अधिकतर समय XAML फ़ाइलों पर काम करने के लिए एक डिज़ाइनर का उपयोग करेंगे, लेकिन आप अभी भी अपना GUI लिख और संपादित कर सकते हैं।

## **डिफ़ॉल्ट विकल्पों के साथ XAML में प्रस्तुतियों को निर्यात करें**

यह Java कोड दर्शाता है कि डिफ़ॉल्ट सेटिंग्स के साथ प्रस्तुति को XAML में कैसे निर्यात किया जाए:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## **कस्टम विकल्पों के साथ XAML में प्रस्तुतियों को निर्यात करें**

आप [IXamlOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IXamlOptions) इंटरफ़ेस से विकल्प चुन सकते हैं जो निर्यात प्रक्रिया को नियंत्रित करते हैं और निर्धारित करते हैं कि Aspose.Slides आपकी प्रस्तुति को XAML में कैसे निर्यात करता है।

उदाहरण के लिए, यदि आप निर्यात करते समय अपनी प्रस्तुति से छिपी हुई स्लाइड्स को शामिल करना चाहते हैं, तो आप [ExportHiddenSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) प्रॉपर्टी को true पर सेट कर सकते हैं। नीचे इसका नमूना Java कोड दिया गया है:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	XamlOptions xamlOptions = new XamlOptions();
	xamlOptions.setExportHiddenSlides(true);
	pres.save(xamlOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**यदि मूल फ़ॉन्ट मशीन पर उपलब्ध नहीं है तो मैं अनुमानित फ़ॉन्ट्स कैसे सुनिश्चित करूँ?**

[XamlOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/xamloptions/) में [a default regular font](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) सेट करें — यह मूल फ़ॉन्ट के गायब होने पर फ़ॉलबैक फ़ॉन्ट के रूप में उपयोग किया जाता है। इससे अप्रत्याशित प्रतिस्थापन से बचा जा सकता है।

**क्या निर्यात किया गया XAML केवल WPF के लिए है, या इसे अन्य XAML स्टैक्स में भी उपयोग किया जा सकता है?**

XAML एक सामान्य UI मार्कअप भाषा है जो WPF, UWP, और Xamarin.Forms में उपयोग होती है। निर्यात Microsoft XAML स्टैक्स के साथ संगतता को लक्षित करता है; विशिष्ट व्यवहार और कुछ संरचनाओं का समर्थन लक्ष्य प्लेटफ़ॉर्म पर निर्भर करता है। अपने वातावरण में मार्कअप का परीक्षण करें।

**क्या छिपी हुई स्लाइड्स समर्थित हैं, और मैं उन्हें डिफ़ॉल्ट रूप से निर्यात होने से कैसे रोकूँ?**

डिफ़ॉल्ट रूप से, छिपी हुई स्लाइड्स शामिल नहीं की जातीं। आप इसे [XamlOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/xamloptions/) में [setExportHiddenSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) द्वारा नियंत्रित कर सकते हैं — यदि आपको उनका निर्यात नहीं चाहिए तो इसे बंद रखें।