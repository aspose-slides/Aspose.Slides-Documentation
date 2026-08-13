---
title: लाइसेंसिंग
type: docs
weight: 50
url: /hi/jasperreports/licensing/
---
{{% alert color="info" %}} 

Aspose.Slides for JasperReports मुफ्त अनिश्चितकालीन मूल्यांकन के रूप में [डाउनलोड पृष्ठ](https://downloads.aspose.com/slides/hi/jasperreport) से उपलब्ध है। उत्पाद का मूल्यांकन संस्करण और लाइसेंस प्राप्त संस्करण एक ही डाउनलोड हैं।

जब आप मूल्यांकन से संतुष्ट हों, तो [लाइसेंस खरीदें](https://purchase.aspose.com/buy)। सुनिश्चित करें कि आप सदस्यता शर्तों को समझते हैं और उनसे सहमत हैं।

ऑर्डर भुगतान होने के बाद लाइसेंस ऑर्डर पृष्ठ से डाउनलोड के लिए उपलब्ध होता है। लाइसेंस एक स्पष्ट पाठ, डिजिटल रूप से हस्ताक्षरित XML फ़ाइल है जिसमें क्लाइंट नाम, खरीदा गया उत्पाद और लाइंस प्रकार जैसी जानकारी होती है। लाइसेंस फ़ाइल की सामग्री को किसी भी तरह संशोधित न करें: ऐसा करने से लाइसेंस अमान्य हो जाएगा।

लाइसेंस को अपने कंप्यूटर पर डाउनलोड करें और इसे उपयुक्त फ़ोल्डर में कॉपी करें (उदाहरण के लिए आपके एप्लिकेशन फ़ोल्डर या **JasperReports\lib**)।
{{% /alert %}}

## **मूल्यांकन संस्करण सीमा**
Aspose.Slides का मूल्यांकन संस्करण (बिना निर्दिष्ट लाइसेंस के) पूर्ण उत्पाद कार्यक्षमता प्रदान करता है, लेकिन (जब आप अपनी प्रस्तुतियों को सहेजते हैं) यह प्रत्येक स्लाइड के मध्य में नीचे दिखाए गए चित्र की तरह एक मूल्यांकन वॉटरमार्क सम्मिलित करता है:

![todo:image_alt_text](evaluation_watermark.png) 

## **लाइसेंस लागू करना**
लाइसेंस लागू करने के कई तरीके हैं, यह आपके JasperReports या JasperServer पर काम करने पर निर्भर करता है।

### **JasperReports के लिए लाइसेंस लागू करना**
Aspose.Slides for Java के समान सीधे setLicense मेथड कॉल का उपयोग करें।

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //लाइसेंस फ़ाइल शामिल करने वाला स्ट्रीम ऑब्जेक्ट बनाएँ
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //License क्लास का इंस्टांस बनाएँ
    License license = new License();
	
    //स्ट्रीम ऑब्जेक्ट के माध्यम से लाइसेंस सेट करें
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

या, कोड में एक्सपोर्टर पैरामीटर सेट करें।

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **JasperServer पर लाइसेंस लागू करना**
applicationContext.xml में एक्सपोर्टर पैरामीटर सेट करें।

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```