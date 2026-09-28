---
title: PPT, PPTX, PDF और HTML निर्यात
type: docs
weight: 20
url: /hi/jasperreports/ppt-pptx-pdf-and-html-export/
description: "PPT, PPTX, PDF या HTML आउटपुट के लिए Aspose.Slides for JasperReports निर्यातक चुनें, इससे भरा हुआ रिपोर्ट निर्यात करें, और रिपोर्ट फ़ॉन्ट्स को प्रेज़ेंटेशन फ़ॉन्ट्स में मैप करें।"
---
## **निर्यातक**

Aspose.Slides for JasperReports JasperReports में चार निर्यातक जोड़ता है। प्रत्येक एक भरे हुए रिपोर्ट (`JasperPrint`) को लेता है और प्रत्येक रिपोर्ट पेज को निर्यात करता है: PPT और PPTX में एक स्लाइड के रूप में, PDF में एक पेज के रूप में, और एकल HTML फ़ाइल में SVG छवि के रूप में।

| आउटपुट फ़ॉर्मेट | निर्यातक वर्ग |
| :- | :- |
| PPT (PowerPoint 97–2003) | `ASPptExporter` |
| PPTX | `ASPptxExporter` |
| PDF | `ASPdfExporter` |
| HTML | `ASHtmlExporter` |

इन वर्गों को लाइब्रेरी जार के `com.aspose.slides.jasperreports` पैकेज में रखा गया है, और ये Microsoft PowerPoint का उपयोग नहीं करते हैं। रिपोर्ट और आउटपुट फ़ाइल को `setParameter` और `JRExporterParameter` के साथ निर्यातक को पास करें, जिन्हें JasperReports ने अप्रचलित (deprecated) चिह्नित किया है: निर्यातक नया `setExporterInput` और `setExporterOutput` कॉन्फ़िगरेशन स्वीकार नहीं करते।

## **रिपोर्ट को सभी चार फ़ॉर्मेट में निर्यात करें**

नीचे दिया गया प्रोग्राम [Your first export](/slides/hi/jasperreports/#your-first-export) प्रोजेक्ट पर आधारित है। यह *hello.jrxml* को एक बार संकलित करता है और भरे हुए रिपोर्ट को क्रमशः प्रत्येक निर्यातक को पास करता है। इसे उस प्रोजेक्ट में *src/main/java/ExportAllFormats.java* के रूप में सहेजें:

```java
import java.util.HashMap;

import com.aspose.slides.jasperreports.ASAbstractExporter;
import com.aspose.slides.jasperreports.ASHtmlExporter;
import com.aspose.slides.jasperreports.ASPdfExporter;
import com.aspose.slides.jasperreports.ASPptExporter;
import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRException;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class ExportAllFormats {
    public static void main(String[] args) throws Exception {
        // रिपोर्ट को एक बार संकलित और भरें।
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // प्रत्येक निर्यातक के साथ वही भरी हुई रिपोर्ट निर्यात करें।
        export(new ASPptExporter(), jasperPrint, "hello.ppt");
        export(new ASPptxExporter(), jasperPrint, "hello.pptx");
        export(new ASPdfExporter(), jasperPrint, "hello.pdf");
        export(new ASHtmlExporter(), jasperPrint, "hello.html");
    }

    private static void export(ASAbstractExporter exporter, JasperPrint jasperPrint, String outputFileName) throws JRException {
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, outputFileName);
        exporter.exportReport();
    }
}
```

प्रोजेक्ट फ़ोल्डर से इसे चलाएँ:

```bash
mvn compile exec:java "-Dexec.mainClass=ExportAllFormats"
```

यह प्रोग्राम *hello.ppt*, *hello.pptx*, *hello.pdf* और *hello.html* को प्रोजेक्ट फ़ोल्डर में सहेजता है। सहायक विधि `ASAbstractExporter` लेती है, जो चारों निर्यातकों की बेस क्लास है। बिना लाइसेंस के, प्रत्येक आउटपुट फ़ाइल में मूल्यांकन वॉटरमार्क शामिल होता है — देखें [Evaluate Aspose.Slides](/slides/hi/jasperreports/evaluate-aspose-slides/).

![लाइसेंस के बिना प्रेज़ेंटेशन में निर्यात किया गया रिपोर्ट](ppt-pptx-pdf-and-html-export_1.png)

## **फ़ॉन्ट्स को मैप करें**

PPT और PPTX निर्यातक रिपोर्ट डिज़ाइन के फ़ॉन्ट नामों को परिवर्तन किए बिना प्रेज़ेंटेशन में लिखते हैं। जब किसी टेक्स्ट एलिमेंट में कोई फ़ॉन्ट निर्दिष्ट नहीं होता, तो JasperReports अपना डिफ़ॉल्ट फ़ॉन्ट `SansSerif` उपयोग करता है, जो एक Java लॉजिकल फ़ॉन्ट नाम है, न कि स्थापित फ़ॉन्ट। ऐसे नामों को बदलने के लिए, `ASExporterParameters.PPT_FONT_MAP` पैरामीटर में रिपोर्ट फ़ॉन्ट नामों से प्रेज़ेंटेशन में इच्छित फ़ॉन्ट नामों के मानचित्र (map) को पास करें। कुंजियों को रिपोर्ट में फ़ॉन्ट नामों के बिल्कुल समान होना चाहिए, केस सहित। प्रत्येक मान वह फ़ॉन्ट होना चाहिए जो Java उस मशीन पर पाए जो निर्यात चलाती है; निर्यातक उस प्रविष्टि को अनदेखा कर देते हैं जिसका फ़ॉन्ट Java नहीं ढूँढ पाता।

यह प्रोग्राम को उसी प्रोजेक्ट में *src/main/java/MapFonts.java* के रूप में सहेजें। यह *hello.jrxml* को PPTX में निर्यात करता है, जहाँ `SansSerif` को Arial से बदला गया है:

```java
import java.util.HashMap;
import java.util.Map;

import com.aspose.slides.jasperreports.ASExporterParameters;
import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class MapFonts {
    public static void main(String[] args) throws Exception {
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // रिपोर्ट फ़ॉन्ट नाम को प्रेज़ेंटेशन में लिखने के लिए फ़ॉन्ट नाम में मानचित्रित करें।
        Map<String, String> fontMap = new HashMap<String, String>();
        fontMap.put("SansSerif", "Arial");

        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello-arial.pptx");
        exporter.setParameter(ASExporterParameters.PPT_FONT_MAP, fontMap);
        exporter.exportReport();
    }
}
```

प्रोजेक्ट फ़ोल्डर से इसे चलाएँ:

```bash
mvn compile exec:java "-Dexec.mainClass=MapFonts"
```

सहेजे गए *hello-arial.pptx* में, रिपोर्ट का टेक्स्ट `SansSerif` के बजाय Arial का उपयोग करता है। ऐसे मशीन पर जहाँ Java Arial नहीं ढूँढ पाता, जैसे कि Arial के बिना Linux सिस्टम, टेक्स्ट `SansSerif` बना रहता है। JasperReports Server पर, एक्सपोर्ट पैरामीटर बीन्स की `fontMap` प्रॉपर्टी के माध्यम से वही मानचित्र सेट करें — देखें [Integration with JasperServer](/slides/hi/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license).