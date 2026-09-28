---
title: लाइसेंसिंग
type: docs
weight: 90
url: /hi/androidjava/licensing/
keywords:
- लाइसेंस
- अस्थायी लाइसेंस
- लाइसेंस सेट करें
- लाइसेंस का उपयोग करें
- लाइसेंस सत्यापित करें
- लाइसेंस फ़ाइल
- मूल्यांकन संस्करण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java में लाइसेंस लागू करें, प्रबंधित करें और समस्याओं को हल करें। हमारे लाइसेंसिंग गाइड के साथ पूरी सुविधाओं तक बिना रुकावट पहुंच सुनिश्चित करें।"
---
## **परिचय**

Aspose.Slides को मूल्यांकन मोड में या वैध लाइसेंस के साथ उपयोग किया जा सकता है। मूल्यांकन संस्करण लाइसेंस प्राप्त संस्करण के समान कार्यक्षमता प्रदान करता है, लेकिन यह प्रत्येक प्रस्तुति की प्रत्येक स्लाइड पर एक मूल्यांकन वॉटरमार्क जोड़ता है और आपके कोड द्वारा प्रस्तुतियों से पढ़े गए पाठ को छोटा कर देता है।

यह लेख बताता है कि Aspose.Slides में लाइसेंसिंग कैसे काम करती है और लाइब्रेरी का उपयोग करने से पहले लाइसेंस कैसे लागू किया जाए। लाइसेंस को फ़ाइल, स्ट्रीम या एम्बेडेड रिसोर्स से [License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/) क्लास का उपयोग करके लोड किया जा सकता है। लेख यह भी दिखाता है कि लाइसेंस सही ढंग से लागू हुआ है या नहीं, इसे कैसे सत्यापित किया जाए।

## **Aspose.Slides का मूल्यांकन**

{{% alert color="info" title="Note" %}}
आप **Aspose.Slides for Android via Java** का मूल्यांकन संस्करण उसके [download page](https://releases.aspose.com/slides/androidjava/) से डाउनलोड कर सकते हैं। मूल्यांकन संस्करण उत्पाद के लाइसेंस प्राप्त संस्करण के समान कार्यक्षमता प्रदान करता है। मूल्यांकन पैकेज खरीदे गए पैकेज के समान है। केवल कुछ पंक्तियों का कोड जोड़कर (लाइसेंस लागू करने के लिए) मूल्यांकन संस्करण लाइसेंस प्राप्त बन जाता है।

एक बार जब आप **Aspose.Slides** के मूल्यांकन से संतुष्ट हो जाएँ, तो आप [purchase a license](https://purchase.aspose.com/pricing/slides/android-java/) कर सकते हैं। हम विभिन्न सदस्यता प्रकारों को देखने की सलाह देते हैं। यदि आपके कोई प्रश्न हैं, तो Aspose बिक्री टीम से संपर्क करें।

हर Aspose लाइसेंस के साथ एक वर्ष की मुफ्त अपग्रेड सदस्यता आती है, जिससे सदस्यता अवधि के भीतर जारी किए गए नए संस्करणों या फ़िक्सों को मुफ्त में प्राप्त किया जा सकता है। लाइसेंस प्राप्त उत्पाद (या यहाँ तक कि मूल्यांकन संस्करण) वाले उपयोगकर्ताओं को मुफ्त और असीमित तकनीकी समर्थन मिलता है।
{{% /alert %}} 

**मूल्यांकन संस्करण की सीमाएँ**

* मूल्यांकन संस्करण (बिना निर्दिष्ट लाइसेंस) पूर्ण उत्पाद कार्यक्षमता प्रदान करता है, लेकिन यह प्रत्येक प्रस्तुति की प्रत्येक स्लाइड में एक मूल्यांकन वॉटरमार्क टेक्स्ट बॉक्स जोड़ता है।
* आपका कोड जो प्रस्तुति से पढ़ता है वह प्रथम कुछ अक्षरों तक सीमित रहता है, उसके बाद मूल्यांकन सीमा के बारे में नोटिस आता है। आपका कोड जो लिखता है वह पूर्ण रूप से सहेजा जाता है।

{{% alert color="info" title="Note" %}}
सीमाएँ हटाकर Aspose.Slides को परीक्षण करने के लिए आप **30-Day Temporary License** का अनुरोध कर सकते हैं। अधिक जानकारी के लिए [How to get a Temporary License](https://purchase.aspose.com/temporary-license) पृष्ठ देखें।
{{% /alert %}}

## **Aspose.Slides में लाइसेंसिंग**

* मूल्यांकन संस्करण लाइसेंस प्राप्त बन जाता है जब आप लाइसेंस खरीदते हैं और कुछ पंक्तियों का कोड जोड़ते हैं (लाइसेंस लागू करने के लिए)।
* लाइसेंस एक साधारण टेक्स्ट XML फ़ाइल है जिसमें उत्पाद का नाम, लाइसेंस प्राप्त डेवलपर्स की संख्या, सदस्यता समाप्ति तिथि आदि विवरण होते हैं। 
* लाइसेंस फ़ाइल डिजिटल रूप से साइन की गई है, इसलिए आपको फ़ाइल में कोई भी परिवर्तन नहीं करना चाहिए। फ़ाइल की सामग्री में एक अतिरिक्त लाइन ब्रेक भी इसे अमान्य कर देगा।
* Aspose.Slides for Android via Java आमतौर पर लाइसेंस को निम्नलिखित स्थानों में खोजता है:
  * स्पष्ट निर्दिष्ट पथ
  * Aspose.Slides.jar वाले फ़ोल्डर में
* मूल्यांकन संस्करण की सीमाओं से बचने के लिए, आपको **Aspose.Slides** का उपयोग करने से पहले लाइसेंस सेट करना आवश्यक है। आपको प्रत्येक एप्लिकेशन या प्रोसेस में केवल एक बार लाइसेंस सेट करना होता है।

## **लाइसेंस लागू करना**

लाइसेंस को **फ़ाइल** या **स्ट्रीम** से लोड किया जा सकता है।

{{% alert color="info" title="Note" %}}
Aspose.Slides लाइसेंसिंग कार्यों के लिए [License](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/) क्लास प्रदान करता है।
{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}
नयी लाइसेंस केवल संस्करण 21.4 या उसके बाद के साथ ही Aspose.Slides को सक्रिय कर सकती हैं। पुरानी संस्करणों में अलग लाइसेंसिंग सिस्टम होता है और वे इन लाइसेंसों को पहचान नहीं पाएँगे।
{{% /alert %}}

### **फ़ाइल**

लाइसेंस सेट करने की सबसे आसान विधि यह है कि लाइसेंस फ़ाइल को Aspose.Slides.jar या आपके एप्लिकेशन की jar वाले फ़ोल्डर में रखें।

{{% alert color="info" title="Note" %}}
Android में, लाइब्रेरी और आपका ऐप APK में पैक होते हैं, इसलिए ऐसी कोई फ़ोल्डर नहीं है जिसमें लाइब्रेरी की JAR फ़ाइल हो, और *Aspose.Slides.Android.via.Java.lic* जैसी रिलेटिव पाथ आपके ऐप में फ़ाइल की ओर नहीं इशारा करती। लाइसेंस फ़ाइल को अपने ऐप की assets में जोड़ें और इसे स्ट्रीम से लोड करें, जैसा कि [Stream from App Assets](#stream-from-app-assets) में दिखाया गया है।
{{% /alert %}}

यह Java कोड दिखाता है कि लाइसेंस फ़ाइल कैसे सेट की जाए:

``` java
// License क्लास का उदाहरण बनाता है
com.aspose.slides.License license = new com.aspose.slides.License();

// लाइसेंस फ़ाइल पथ सेट करता है
license.setLicense("Aspose.Slides.Android.via.Java.lic");
```

{{% alert color="warning" title="Warning" %}}
यदि आप लाइसेंस फ़ाइल को किसी अलग निर्देशिका में रखते हैं, तो जब आप [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) मेथड को कॉल करते हैं, तो निर्दिष्ट पथ के अंत में फ़ाइल का नाम आपके लाइसेंस फ़ाइल के नाम के समान होना चाहिए।

उदाहरण के लिए, आप लाइसेंस फ़ाइल का नाम *Aspose.Slides.Android.via.Java.lic.xml* बदल सकते हैं। फिर, अपने कोड में, आपको फ़ाइल का पथ (जो *Aspose.Slides.Android.via.Java.lic.xml* समाप्त हो) को [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.lang.String-) मेथड को पास करना होगा।
{{% /alert %}}

### **स्ट्रीम**

आप लाइसेंस को स्ट्रीम से लोड कर सकते हैं। यह Java कोड दिखाता है कि स्ट्रीम से लाइसेंस कैसे लागू किया जाए:

``` java
// License क्लास का उदाहरण बनाता है
com.aspose.slides.License license = new com.aspose.slides.License();

// स्ट्रीम के माध्यम से लाइसेंस सेट करता है
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Android.via.Java.lic"));
```

### **ऐप Assets से स्ट्रीम**

Android ऐप में, लाइसेंस फ़ाइल को ऐप मॉड्यूल की *assets* फ़ोल्डर में रखें, यानी *app/src/main/assets*, ताकि यह APK में पैक हो जाए। फ़ाइल को [getAssets](https://developer.android.com/reference/android/content/Context#getAssets()) मेथड से खोलें और स्ट्रीम को [setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) मेथड को पास करें। कोड `Activity` के भीतर चलता है, उदाहरण के लिए उसके `onCreate` मेथड में, इससे पहले कि ऐप Aspose.Slides का उपयोग करे:

```java
import android.util.Log;
import com.aspose.slides.License;
import java.io.IOException;
import java.io.InputStream;

License license = new License();
try (InputStream licenseStream = getAssets().open("Aspose.Slides.Android.via.Java.lic")) {
    license.setLicense(licenseStream);
} catch (IOException exception) {
    Log.e("Licensing", "Cannot read the license file from the app's assets.", exception);
}
```

जिस फ़ाइल नाम को आप [open](https://developer.android.com/reference/android/content/res/AssetManager#open(java.lang.String)) मेथड को पास करते हैं, वह *assets* फ़ोल्डर के सापेक्ष होना चाहिए। यदि फ़ाइल वहाँ नहीं है, तो कोड त्रुटि को लॉग करता है, और Aspose.Slides मूल्यांकन मोड में रहता है। यह जांचने के लिए कि लाइसेंस लागू हुआ है या नहीं, देखें [Validating a License](#validating-a-license)।

## **लाइसेंस सत्यापित करना**

यह जांचने के लिए कि लाइसेंस सही ढंग से सेट हुआ है या नहीं, आप इसे वैधता जाँच सकते हैं। यह Java कोड दिखाता है कि लाइसेंस कैसे सत्यापित किया जाए:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Android.via.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **थ्रेड सुरक्षा**

{{% alert color="warning" title="Warning" %}}
[setLicense](https://reference.aspose.com/slides/androidjava/com.aspose.slides/license/#setLicense-java.io.InputStream-) मेथड थ्रेड‑सेफ़ नहीं है। यदि इस मेथड को कई थ्रेड्स से एक साथ कॉल करना पड़ता है, तो आप समस्याओं से बचने के लिए लॉक जैसी समकालिकता तकनीकें उपयोग कर सकते हैं।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मैं लाइसेंस को पूरी तरह ऑफ़लाइन (बिना इंटरनेट एक्सेस) वातावरण में लागू कर सकता हूँ?

हां। लाइसेंस वैधता स्थानीय रूप से लाइसेंस फ़ाइल का उपयोग करके की जाती है; इंटरनेट कनेक्शन की आवश्यकता नहीं है।

### एक‑वर्ष की सदस्यता समाप्त होने के बाद क्या होता है? क्या लाइब्रेरी काम करना बंद कर देगी?

नहीं। लाइसेंस स्थायी है: आप अपनी सदस्यता समाप्ति तिथि से पहले जारी किए गए संस्करणों का उपयोग जारी रख सकते हैं; केवल नई रिलीज़ को बिना नवीनीकरण के उपयोग करने का अधिकार नहीं होगा।