---
title: एंड्रॉइड पर प्रस्तुतियों को लिखित‑सुरक्षित करें
linktitle: लेखन सुरक्षा
type: docs
weight: 25
url: /hi/androidjava/write-protected-presentation/
keywords:
- लेखन सुरक्षा
- PowerPoint लेखन‑सुरक्षा
- संशोधन पासवर्ड
- प्रस्तुति संपादन को प्रतिबंधित करें
- लेखन सुरक्षा हटाएँ
- संशोधन पासवर्ड मान्य करें
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android के माध्यम से Java में PowerPoint PPT और PPTX प्रस्तुतियों में लिखावट‑सुरक्षा पासवर्ड सेट करना, पहचानना, मान्य करना और हटाना।"
---
## **परिचय**

एक लेखन-सुरक्षा पासवर्ड प्रस्तुति के संशोधन को प्रतिबंधित करता है लेकिन इसकी सामग्री को एन्क्रिप्ट नहीं करता है। उपयोगकर्ता पासवर्ड के बिना लेखन-सुरक्षित प्रस्तुति को लोड और देख सकते हैं। अनुप्रयोग पर निर्भर करता है, वे सामग्री को संपादित करके अलग नाम से सहेज भी सकते हैं, इसलिए लेखन सुरक्षा को गोपनीयता तंत्र के रूप में नहीं माना जाना चाहिए।

एक खोलने वाला पासवर्ड अलग उद्देश्य सेवा देता है: यह प्रस्तुति को एन्क्रिप्ट करता है और इसकी सामग्री को लोड करने के लिए आवश्यक होता है। प्रस्तुति को एन्क्रिप्ट करने या खोलने वाले पासवर्ड को मान्य करने के लिए, देखें [Password-Protect Presentations](/slides/hi/androidjava/password-protected-presentation/).

इस लेख में प्रक्रियाएँ PPT और PPTX दोनों प्रस्तुतियों पर लागू होती हैं। उदाहरण PPTX फ़ाइलों का उपयोग करते हैं; PPT में सहेजते समय, `.ppt` एक्सटेंशन और संबंधित PPT सहेजने के फ़ॉर्मेट का उपयोग करें।

## **प्रस्तुति पर लेखन-सुरक्षा सेट करें**

प्रस्तुति को संशोधित करने के लिए पासवर्ड असाइन करने हेतु [IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-) का उपयोग करें। प्रस्तुति को सहेजने से सुरक्षा सेटिंग बनी रहती है।

निम्नलिखित उदाहरण PPTX प्रस्तुति पर लेखन-सुरक्षा सेट करता है:

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

## **लेखन-सुरक्षित प्रस्तुति लोड करें**

चूंकि लेखन-सुरक्षा प्रस्तुति सामग्री को एन्क्रिप्ट नहीं करती, इसलिए प्रस्तुति को लोड करने के लिए पासवर्ड आवश्यक नहीं है। पासवर्ड केवल संरक्षित प्रस्तुति को संशोधित करने के अधिकार की पुष्टि करते समय ही प्रासंगिक है।

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

लेखन-सुरक्षा पासवर्ड को [ILoadOptions.setPassword](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) को न भेजें। यह विधि एन्क्रिप्टेड सामग्री के लिए खोलने वाला पासवर्ड स्वीकार करती है। यदि प्रस्तुति में दोनों सुरक्षा प्रकार हैं, तो लोड करने के लिए खोलने वाला पासवर्ड प्रदान करें और लेखन-सुरक्षा पासवर्ड को अलग से संभालें।

## **प्रस्तुति से लेखन-सुरक्षा हटाएँ**

लेखन-सुरक्षा प्रतिबंध को हटाने के लिए [IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iprotectionmanager/#removeWriteProtection--) का उपयोग करें, फिर प्रस्तुति को सहेजें।

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

## **जाँचें कि प्रस्तुति लेखन-सुरक्षित है या नहीं**

फ़ाइल को बिना पूर्ण [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) इंस्टेंस बनाए निरीक्षण करने के लिए, [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-) को कॉल करें और [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--) को देखें। इस विधि में [NullableBool](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/nullablebool/) उपयोग होता है और लेखन-सुरक्षा मिलने पर `NullableBool.True` लौटाती है।

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

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-) का स्ट्रीम ओवरलोड उसी जानकारी को प्रदान करता है जब प्रस्तुति को स्ट्रीम के रूप में दिया जाता है।

## **लेखन-सुरक्षा पासवर्ड को मान्य करें**

लेखन पासवर्ड को पूरी प्रस्तुति लोड किए बिना मान्य करने के लिए [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) का उपयोग करें। पहले [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--) की जाँच करें ताकि एप्लिकेशन केवल तब पासवर्ड का अनुरोध या मान्य करे जब लेखन-सुरक्षा मौजूद हो।

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

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-) केवल लेखन-सुरक्षा पासवर्ड को मान्य करता है। यह खोलने वाले पासवर्ड को मान्य नहीं करता या यह निर्धारित नहीं करता कि एन्क्रिप्टेड सामग्री लोड की जा सकती है या नहीं। इसके विपरीत, [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-) केवल खोलने वाले पासवर्ड को मान्य करता है। यदि पूर्ण प्रस्तुति पहले से लोड हो चुकी है, तो [IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-) समान लेखन-सुरक्षा जाँच को अपने सुरक्षा प्रबंधक के माध्यम से प्रदान करता है।

उत्पादन अनुप्रयोगों में, पासवर्ड को लॉग न करें या निदान संदेशों में शामिल न करें। अनावश्यक दोहराए गए मान्यकरण प्रयासों से बचें, और पासवर्ड को केवल आवश्यक समय तक मेमोरी में रखें।

{{% alert color="info" title="संबंधित देखें" %}}
- [Password-Protect Presentations](/slides/hi/androidjava/password-protected-presentation/)
- [Read-Only Presentations](/slides/hi/androidjava/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/hi/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या लेखन-सुरक्षा प्रस्तुति को एन्क्रिप्ट करती है?**

नहीं। यह संशोधन को प्रतिबंधित करता है लेकिन प्रस्तुति सामग्री को लोड और देखने के लिए उपलब्ध रखता है।

**क्या लेखन-सुरक्षा पासवर्ड को प्रस्तुति खोलने के लिए आवश्यक है?**

नहीं। केवल एक खोलने वाले पासवर्ड की आवश्यकता होती है ताकि एन्क्रिप्टेड प्रस्तुति सामग्री लोड की जा सके।

**क्या एक प्रस्तुति में खोलने वाला पासवर्ड और लेखन-सुरक्षा पासवर्ड दोनों हो सकते हैं?**

हां। लोड विकल्पों के माध्यम से खोलने वाला पासवर्ड प्रदान करके एन्क्रिप्टेड प्रस्तुति को खोलें, और जब संशोधन अधिकार की आवश्यकता हो तो लेखन-सुरक्षा पासवर्ड को अलग से मान्य करें।