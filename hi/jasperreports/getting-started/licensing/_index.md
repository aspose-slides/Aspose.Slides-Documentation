---
title: लाइसेंसिंग
type: docs
weight: 50
url: /hi/jasperreports/licensing/
---
{{% alert color="primary" %}} 

Aspose.Slides for JasperReports एक मुफ्त, असीमित समय मूल्यांकन के रूप में उपलब्ध है, जिसे आप [download page](https://downloads.aspose.com/slides/hi/jasperreport) से प्राप्त कर सकते हैं। मूल्यांकन और लाइसेंस प्राप्त संस्करण एक ही डाउनलोड हैं।

जब आप मूल्यांकन से संतुष्ट हों, तो [buy a license](https://purchase.aspose.com/buy) करें। सुनिश्चित करें कि आप सदस्यता शर्तों को समझते हैं और उनका पालन करते हैं।

लाइसेंस ऑर्डर पेज से भुगतान के बाद डाउनलोड किया जा सकता है। लाइसेंस एक स्पष्ट टेक्स्ट, डिजिटल रूप से हस्ताक्षरित XML फ़ाइल है जिसमें क्लाइंट नाम, खरीदा गया प्रोडक्ट और लाइसेंस प्रकार जैसी जानकारी होती है। लाइसेंस फ़ाइल की सामग्री को किसी भी तरह से न बदलें: ऐसा करने से लाइसेंस अमान्य हो जाएगा।

लाइसेंस को अपने कंप्यूटर पर डाउनलोड करें और उचित फ़ोल्डर (उदाहरण के लिए आपके एप्लिकेशन फ़ोल्डर या **JasperReports\lib**) में कॉपी करें।

## **Evaluation Version Limitation**
Aspose.Slides का मूल्यांकन संस्करण (बिना निर्दिष्ट लाइसेंस के) पूर्ण उत्पाद कार्यक्षमता प्रदान करता है, लेकिन (जब आप अपनी प्रस्तुतियों को सहेजते हैं) यह प्रत्येक स्लाइड के केंद्र में नीचे दिखाए गए चित्र की तरह एक मूल्यांकन वाटरमार्क जोड़ता है:

![todo:image_alt_text](evaluation_watermark.png) 

## **Applying a License**
लाइसेंस लागू करने के कई तरीके हैं, यह इस बात पर निर्भर करता है कि आप JasperReports पर काम कर रहे हैं या JasperServer पर।

### **Applying a License for JasperReports**
Aspose.Slides for Java के समान सीधे `setLicense` मेथड को कॉल करें।

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //लाइसेंस फ़ाइल को शामिल करने वाला एक स्ट्रीम ऑब्जेक्ट बनाएं
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //License क्लास को इंस्टैंसिएट करें
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

### **Applying a License on JasperServer**
`applicationContext.xml` में एक्सपोर्टर पैरामीटर सेट करें।

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```