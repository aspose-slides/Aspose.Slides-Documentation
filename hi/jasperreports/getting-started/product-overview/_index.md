---
title: उत्पाद अवलोकन
type: docs
weight: 10
url: /hi/jasperreports/product-overview/
---
![Aspose.Slides for JasperReports](product-overview_1.png)

## **Aspose.Slides for JasperReports में आपका स्वागत है!**

Aspose.Slides for JasperReports एक लाइब्रेरी है जो विशेष रूप से उन डेवलपर्स के लिए डिज़ाइन और विकसित की गई है जिन्हें अपने Java अनुप्रयोगों में JasperReports से Microsoft PowerPoint Presentation (PPT) और Microsoft PowerPoint Show (PPS) फ़ॉर्मैट में रिपोर्ट निर्यात करना आसान होना चाहिए। सभी रिपोर्ट सुविधाएँ उच्चतम सटीकता के साथ Microsoft PowerPoint प्रस्तुतियों में परिवर्तित की जाती हैं। Aspose.Slides for JasperReports JasperReports 5+ का समर्थन करता है।

## **उत्पाद विवरण**
JasperReports और JasperServer में Microsoft PowerPoint प्रस्तुतियों के रूप में रिपोर्ट निर्यात करने की बिल्ट‑इन क्षमता नहीं है, लेकिन Aspose.Slides for JasperReports आपको दो अतिरिक्त निर्यात फ़ॉर्मैट प्रदान करता है:

- PPT – Aspose.Slides के माध्यम से PowerPoint Presentation
- PPS – Aspose.Slides के माध्यम से PowerPoint Show
- PPTX – Aspose.Slides के माध्यम से PowerPoint Presentation
- PPSX – Aspose.Slides के माध्यम से PowerPoint Show

Aspose.Slides for JasperReports आंतरिक रूप से हमारे 100% शुद्ध Java लाइब्रेरी Aspose.Slides for Java और Aspose.Metafiles for Java का उपयोग करता है, जो सर्वर‑साइड प्रस्तुतियों और मेटाफाइल प्रोसेसिंग के लिए विश्व‑स्तरीय लाइब्रेरी हैं।

Aspose.Slides for JasperReports किसी भी रिपोर्ट को PPT या PPS फ़ॉर्मैट में निर्यात करना संभव बनाता है।

### **आउटपुट उदाहरण**
ASPptExporter क्लास ASAbstractExporter क्लास का विस्तार करती है इसलिए इसे किसी भी अन्य मानक एक्सपोर्टर की तरह ही उपयोग किया जा सकता है। यह छोटा उदाहरण सामान्य कोड और MS PowerPoint में देखी गई रिपोर्ट का स्क्रीनशॉट दिखाता है। विस्तृत उदाहरण प्रदान किए गए डेमो रिपोर्ट में पाए जा सकते हैं।

``` java
File sourceFile = new File(fileName); 
JasperPrint jasperPrint = (JasperPrint)JRLoader.loadObject(sourceFile);
File destFile = new File(sourceFile.getParent(), jasperPrint.getName() + ".ppt");
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, destFile.toString());
exporter.exportReport();
```

**JasperReports xmldatasource डेमो के साथ उत्पन्न प्रस्तुति**

![JasperReports के साथ उत्पन्न प्रस्तुति](product-overview_2.png)