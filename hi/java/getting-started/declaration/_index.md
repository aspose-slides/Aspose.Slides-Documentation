---
title: सिक्योरिटी मैनेजर आवश्यकताएँ
type: docs
weight: 190
url: /hi/java/declaration/
keywords:
- सिक्योरिटी मैनेजर
- सुरक्षा नीति
- AllPermission
- अनुमतियाँ
- सैंडबॉक्स
- JDK 24
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Java 23 और उससे पहले के संस्करणों में Aspose.Slides for Java तथा उसे कॉल करने वाले कोड को कौन सी Security Manager अनुमतियों की आवश्यकता होती है, और Java 24 और बाद में किसी कॉन्फ़िगरेशन की आवश्यकता क्यों नहीं होती।"
---
## **सारांश**

Java Security Manager सुरक्षा नीति के अनुसार कोड की कार्यक्षमता को सीमित करता है। Java 17 ने इसे हटाने के लिए अप्रचलित कर दिया ([JEP 411](https://openjdk.org/jeps/411)), और Java 24 ने इसे स्थायी रूप से अक्षम कर दिया ([JEP 486](https://openjdk.org/jeps/486)). यह लेख बताता है कि जब कोई एप्लिकेशन अभी भी Security Manager के साथ चलता है तो Aspose.Slides for Java को क्या चाहिए। यदि आपका एप्लिकेशन डिफॉल्ट रूप से Security Manager को सक्षम नहीं करता है, तो कॉन्फ़िगर करने के लिए कुछ नहीं है।

## **Java 23 और इससे पहले के संस्करण**

जब Security Manager सक्षम होता है, तो सुरक्षा नीति को Aspose.Slides JAR फ़ाइल और उसे कॉल करने वाले एप्लिकेशन कोड को निम्नलिखित अनुमतियां देनी चाहिए:

- `java.util.PropertyPermission "*", "read"`: Aspose.Slides सिस्टम प्रॉपर्टीज़ पढ़ता है।
- `java.io.FilePermission "<<ALL FILES>>", "read"`: Aspose.Slides फ़ॉन्ट फ़ाइलें और अन्य फ़ाइलें पढ़ता है।
- `java.io.FilePermission "<<ALL FILES>>", "execute"`: Aspose.Slides ऑपरेटिंग‑सिस्टम प्रोग्राम शुरू करता है, उदाहरण के लिए Windows पर `reg` और Linux पर `fc-match`।
- `java.io.FilePermission` में `write` कार्रवाई उन फ़ोल्डरों के लिए जहाँ आपका एप्लिकेशन फ़ाइलें सहेजता है।

केवल JAR फ़ाइल को अनुमतियां देना पर्याप्त नहीं है: Aspose.Slides को कॉल करने वाले कोड को भी इन्हीं अनुमतियों की आवश्यकता होती है। दोनों को `java.security.AllPermission` देना भी काम करता है।

सिस्टम प्रॉपर्टीज़ पढ़ने या प्रोग्राम शुरू करने की अनुमति नहीं होने पर, Aspose.Slides पहली बार उपयोग में विफल रहता है: एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) ऑब्जेक्ट बनाते समय `ExceptionInInitializerError` फेंका जाता है। फ़ॉन्ट फ़ाइलों तक पढ़ने की पहुंच न होने पर, PDF के रूप में प्रस्तुति सहेजना "Cannot find any fonts installed on the system" त्रुटि के साथ विफल हो जाता है।

## **Java 24 और बाद के संस्करण**

Java 24 और उससे आगे Security Manager को सक्षम नहीं किया जा सकता, इसलिए देने के लिए कोई अनुमतियां नहीं होतीं। Aspose.Slides उस खाते की अनुमतियों के साथ चलता है जो आपका एप्लिकेशन चलाता है। किसी एप्लिकेशन की पहुँच को प्रतिबंधित करने के लिए, OpenJDK प्रोजेक्ट JDK के बाहर की तकनीकों की सिफ़ारिश करता है, जैसे कंटेनर, हाइपरवाइज़र और ऑपरेटिंग‑सिस्टम सैंडबॉक्सिंग सुविधाएँ। देखें [JEP 486](https://openjdk.org/jeps/486).

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं Aspose.Slides को ऐसे वातावरण में उपयोग कर सकता हूँ जहाँ एप्लिकेशन एक प्रतिबंधात्मक Security Manager नीति के तहत चलते हों?**

केवल तभी जब नीति ऊपर सूचीबद्ध अनुमतियों को zowel Aspose.Slides और उसे कॉल करने वाले कोड को देती है। इनमें सभी फ़ाइलें पढ़ना और कोई भी प्रोग्राम शुरू करना शामिल है।