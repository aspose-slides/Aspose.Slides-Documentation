---
title: "Java में XAML में प्रस्तुतियों का निर्यात"
linktitle: "प्रेजेंटेशन को XAML में"
type: docs
weight: 30
url: /hi/java/export-to-xaml/
keywords:
- "PowerPoint निर्यात"
- "OpenDocument निर्यात"
- "प्रस्तुति निर्यात"
- "PowerPoint रूपांतरण"
- "OpenDocument रूपांतरण"
- "प्रस्तुति रूपांतरण"
- "PowerPoint से XAML"
- "OpenDocument से XAML"
- "प्रस्तुति से XAML"
- "PPT से XAML"
- "PPTX से XAML"
- "ODP से XAML"
- "PPT को XAML के रूप में सहेजें"
- "PPTX को XAML के रूप में सहेजें"
- "ODP को XAML के रूप में सहेजें"
- "PPT को XAML में निर्यात करें"
- "PPTX को XAML में निर्यात करें"
- "ODP को XAML में निर्यात करें"
- Java
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके Java में PowerPoint और OpenDocument स्लाइड्स को XAML में परिवर्तित करें - तेज़, Office-मुक्त समाधान जो आपके लेआउट को बना रखता है।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को XAML में निर्यात करने की विधि समझाता है। यह XAML का संक्षिप्त परिचय देता है, डिफ़ॉल्ट सेटिंग्स के साथ प्रस्तुति को XAML में कैसे सहेजें दिखाता है, और [XamlOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/xamloptions/) के माध्यम से निर्यात को कैसे अनुकूलित किया जाए, जिसमें छिपी स्लाइड्स का निर्यात भी शामिल है। लेख कुछ सामान्य प्रश्नों के उत्तर भी देता है, जैसे फ़ॉलबैक फ़ॉन्ट, XAML स्टैक संगतता, और छिपी स्लाइड निर्यात व्यवहार।

## **XAML के बारे में**

XAML एक वर्णनात्मक प्रोग्रामिंग भाषा है जो आपको ऐप्स के लिए उपयोगकर्ता इंटरफ़ेस बनाने या लिखने की अनुमति देती है, विशेष रूप से उन ऐप्स के लिए जो WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) और Xamarin Forms का उपयोग करते हैं।

XAML, जो XML‑आधारित भाषा है, Microsoft का GUI वर्णन करने वाला रूपांतर है। आप अधिकांश समय XAML फ़ाइलों पर काम करने के लिए डिज़ाइनर का उपयोग करेंगे, लेकिन आप अपना GUI लिख और संपादित भी कर सकते हैं।

## **डिफ़ॉल्ट विकल्पों के साथ XAML में प्रस्तुतियों को निर्यात करें**

यह Java कोड दिखाता है कि डिफ़ॉल्ट सेटिंग्स के साथ प्रस्तुति को XAML में कैसे निर्यात किया जाता है:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## **कस्टम विकल्पों के साथ XAML में प्रस्तुतियों को निर्यात करें**

आप [IXamlOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IXamlOptions) इंटरफ़ेस से विकल्प चुन सकते हैं जो निर्यात प्रक्रिया को नियंत्रित करते हैं और निर्धारित करते हैं कि Aspose.Slides आपकी प्रस्तुति को XAML में कैसे निर्यात करता है।

उदाहरण के लिए, यदि आप निर्यात के दौरान अपनी प्रस्तुति की छिपी स्लाइड्स को शामिल करना चाहते हैं, तो आप [ExportHiddenSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) प्रॉपर्टी को true सेट कर सकते हैं। इस नमूना Java कोड को देखें:

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

**यदि मूल फ़ॉन्ट मशीन पर उपलब्ध नहीं है तो पूर्वानुमेय फ़ॉन्ट कैसे सुनिश्चित करें?**

[XamlOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/xamloptions/) में [डिफ़ॉल्ट नियमित फ़ॉन्ट](https://reference.aspose.com/slides/hi/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) सेट करें — यह मूल फ़ॉन्ट अनुपलब्ध होने पर फ़ॉलबैक फ़ॉन्ट के रूप में उपयोग होता है। यह अप्रत्याशित प्रतिस्थापन से बचाता है।

**क्या निर्यातित XAML केवल WPF के लिए है, या इसे अन्य XAML स्टैक्स में भी उपयोग किया जा सकता है?**

XAML एक सामान्य UI मार्कअप भाषा है जो WPF, UWP और Xamarin.Forms में उपयोग होती है। निर्यात Microsoft XAML स्टैक्स के साथ संगतता को लक्षित करता है; विशिष्ट व्यवहार और समर्थन लक्षित प्लेटफ़ॉर्म पर निर्भर करता है। अपने वातावरण में मार्कअप का परीक्षण करें।

**क्या छिपी स्लाइड्स समर्थित हैं, और उन्हें डिफ़ॉल्ट रूप से निर्यात होने से कैसे रोकें?**

डिफ़ॉल्ट रूप से, छिपी स्लाइड्स शामिल नहीं होतीं। आप इसे [setExportHiddenSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) के माध्यम से [XamlOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/xamloptions/) में नियंत्रित कर सकते हैं — यदि आपको उनका निर्यात नहीं चाहिए तो इसे निष्क्रिय रखें।