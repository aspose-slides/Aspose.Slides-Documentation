---
title: जावा में प्रस्तुतियों को राइट‑प्रोटेक्ट करें
linktitle: राइट प्रोटेक्शन
type: docs
weight: 25
url: /hi/java/write-protected-presentation/
keywords:
- राइट प्रोटेक्शन
- PowerPoint में लिखने की सुरक्षा
- संशोधन के लिए पासवर्ड
- प्रस्तुति संपादन को प्रतिबंधित करें
- राइट प्रोटेक्शन हटाएँ
- संशोधन पासवर्ड को सत्यापित करें
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके PowerPoint PPT और PPTX प्रस्तुतियों में राइट‑प्रोटेक्शन पासवर्ड को सेट करना, पता लगाना, सत्यापित करना और हटाना।"
---
## **परिचय**

एक राइट‑प्रोटेक्शन पासवर्ड प्रस्तुति में संशोधन को प्रतिबंधित करता है लेकिन इसकी सामग्री को एन्क्रिप्ट नहीं करता। उपयोगकर्ता पासवर्ड के बिना भी राइट‑प्रोटेक्टेड प्रस्तुति को लोड और देख सकते हैं। एप्लिकेशन के आधार पर, वे सामग्री को संपादित कर सकते हैं और उसे अलग नाम से सहेज सकते हैं, इसलिए राइट प्रोटेक्शन को गोपनीयता तंत्र के रूप में नहीं माना जाना चाहिए।

एक ओपनिंग पासवर्ड का उद्देश्य अलग है: यह प्रस्तुति को एन्क्रिप्ट करता है और इसकी सामग्री को लोड करने के लिए आवश्यक होता है। प्रस्तुति को एन्क्रिप्ट करने या ओपनिंग पासवर्ड को मान्य करने के लिए, देखें [पासवर्ड‑सुरक्षित प्रस्तुतियां](/slides/hi/java/password-protected-presentation/)।

इस लेख में वर्णित कार्यप्रवाह PPT और PPTX दोनों प्रस्तुतियों पर लागू होते हैं। उदाहरण PPTX फ़ाइलों का उपयोग करते हैं; PPT में सहेजते समय, `.ppt` एक्सटेंशन और संबंधित PPT सहेजने प्रारूप का उपयोग करें।

## **प्रेज़ेंटेशन पर राइट प्रोटेक्शन सेट करें**

प्रेज़ेंटेशन में संशोधन के लिए पासवर्ड असाइन करने हेतु [IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-) का उपयोग करें। प्रेज़ेंटेशन को सहेजने से प्रोटेक्शन सेटिंग सुरक्षित रहती है।

निम्न उदाहरण PPTX प्रेज़ेंटेशन पर राइट प्रोटेक्शन सेट करता है:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **राइट‑प्रोटेक्टेड प्रेज़ेंटेशन लोड करें**

चूंकि राइट प्रोटेक्शन प्रस्तुति की सामग्री को एन्क्रिप्ट नहीं करता, इसलिए प्रस्तुति को लोड करने के लिए पासवर्ड आवश्यक नहीं है। पासवर्ड केवल संरक्षित प्रस्तुति में संशोधन की अनुमति को मान्य करने के समय ही प्रासंगिक होता है।

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

राइट‑प्रोटेक्शन पासवर्ड को [ILoadOptions.setPassword](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) में पास न करें। यह मेथड एन्क्रिप्टेड सामग्री के लिए ओपनिंग पासवर्ड स्वीकार करता है। यदि किसी प्रस्तुति में दोनों प्रकार की सुरक्षा हैं, तो उसे लोड करने के लिए ओपनिंग पासवर्ड प्रदान करें और राइट‑प्रोटेक्शन पासवर्ड को अलग से संभालें।

## **प्रेज़ेंटेशन से राइट प्रोटेक्शन हटाएँ**

[IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) का उपयोग करके संशोधन प्रतिबंध हटाएँ, फिर प्रेज़ेंटेशन को सहेजें।

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **जाँचें कि प्रस्तुति राइट प्रोटेक्टेड है या नहीं**

पूरी [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) इंस्टेंस बनाए बिना फ़ाइल की जांच करने के लिए, [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) को कॉल करें और [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--) को देखें। यह मेथड [NullableBool](https://reference.aspose.com/slides/hi/java/com.aspose.slides/nullablebool/) का उपयोग करता है और राइट प्रोटेक्शन मिलने पर `NullableBool.True` लौटाता है।

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() == NullableBool.True) {
    System.out.println("The presentation is write protected.");
} else {
    System.out.println("Write protection was not detected.");
}
```

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) का स्ट्रीम ओवरलोड स्ट्रीम के रूप में प्रदान की गई प्रस्तुति के लिए वही जानकारी देता है।

## **राइट‑प्रोटेक्शन पासवर्ड को मान्य करें**

पूरी प्रस्तुति लोड किए बिना संशोधन पासवर्ड को मान्य करने के लिए [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) का उपयोग करें। पहले [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/#isWriteProtected--) को जांचें ताकि एप्लिकेशन केवल तब पासवर्ड का अनुरोध या मान्य कर सके जब राइट प्रोटेक्शन मौजूद हो।

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() != NullableBool.True) {
    System.out.println("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    System.out.println("The write-protection password is correct.");
} else {
    System.out.println("The write-protection password is incorrect.");
}
```

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) केवल राइट‑प्रोटेक्शन पासवर्ड को मान्य करता है। यह ओपनिंग पासवर्ड को मान्य नहीं करता या यह निर्धारित नहीं करता कि एन्क्रिप्टेड सामग्री लोड की जा सकती है या नहीं। इसके विपरीत, [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) केवल ओपनिंग पासवर्ड को मान्य करता है। यदि पूरी प्रस्तुति पहले ही लोड हो चुकी है, तो [IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) अपने प्रोटेक्शन मैनेजर के माध्यम से समान राइट‑प्रोटेक्शन जाँच प्रदान करता है।

प्रॉडक्शन एप्लिकेशनों में पासवर्ड को लॉग न करें या डायग्नॉस्टिक संदेशों में शामिल न करें। अनावश्यक दोहराए गए मान्यकरण प्रयासों से बचें, और पासवर्ड को मेमोरी में केवल आवश्यकता तक रखें।

{{% alert color="info" title="अधिक देखें" %}}
- [पासवर्ड‑सुरक्षित प्रस्तुतियां](/slides/hi/java/password-protected-presentation/)
- [केवल‑पढ़ने योग्य प्रस्तुतियां](/slides/hi/java/read-only-presentation/)
- [PowerPoint में डिजिटल हस्ताक्षर](/slides/hi/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या राइट प्रोटेक्शन प्रस्तुति को एन्क्रिप्ट करता है?**

नहीं। यह संशोधन को प्रतिबंधित करता है लेकिन प्रस्तुति की सामग्री को लोड और देखने के लिए उपलब्ध रखता है।

**क्या प्रस्तुति खोलने के लिए राइट‑प्रोटेक्शन पासवर्ड आवश्यक है?**

नहीं। एन्क्रिप्टेड प्रस्तुति सामग्री को लोड करने के लिए केवल एक ओपनिंग पासवर्ड आवश्यक होता है।

**क्या किसी प्रस्तुति में ओपनिंग पासवर्ड और राइट‑प्रोटेक्शन पासवर्ड दोनों हो सकते हैं?**

हाँ। एन्क्रिप्टेड प्रस्तुति को खोलने के लिए लोड विकल्पों के माध्यम से ओपनिंग पासवर्ड प्रदान करें, और जब संशोधन की अनुमति चाहिए हो तो राइट‑प्रोटेक्शन पासवर्ड को अलग से मान्य करें।