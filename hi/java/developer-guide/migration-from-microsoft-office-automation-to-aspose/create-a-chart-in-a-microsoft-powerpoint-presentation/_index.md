---
title: VSTO और Aspose.Slides for Java का उपयोग करके चार्ट बनाएं
linktitle: चार्ट बनाएं
type: docs
weight: 70
url: /hi/java/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- चार्ट बनाएं
- स्थानांतरण
- VSTO
- ऑफिस स्वचालन
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "जावा में PowerPoint चार्ट निर्माण को स्वचालित करने का तरीका जानें। यह चरण-दर-चरण गाइड दिखाता है कि Aspose.Slides for Java माइक्रोसॉफ्ट.Office.Interop के मुकाबले क्यों तेज़, अधिक शक्तिशाली विकल्प है।"
---
{{% alert color="info" %}} 

चार्ट डेटा के दृश्य प्रतिनिधित्व हैं जिन्हें प्रस्तुतियों में व्यापक रूप से उपयोग किया जाता है। यह लेख Microsoft PowerPoint में प्रोग्रामेटिक रूप से चार्ट बनाने के लिए कोड दिखाता है, जिसका उपयोग [VSTO](/slides/hi/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) और [Aspose.Slides for Java](/slides/hi/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) द्वारा किया जाता है।

{{% /alert %}} 
## **चार्ट बनाना**
नीचे दिए गए कोड उदाहरण VSTO का उपयोग करके एक साधारण 3D क्लस्टर्ड कॉलम चार्ट जोड़ने की प्रक्रिया का वर्णन करते हैं। आप एक प्रस्तुति इंस्टेंस बनाते हैं, उसमें एक डिफ़ॉल्ट चार्ट जोड़ते हैं। फिर Microsoft Excel वर्कबुक का उपयोग करके चार्ट डेटा तक पहुँचते और उसे संशोधित करते हैं तथा चार्ट गुण सेट करते हैं। अंत में, प्रस्तुति को सहेजते हैं।
### **VSTO उदाहरण**
VSTO का उपयोग करके निम्नलिखित चरण किए जाते हैं:

1. Microsoft PowerPoint प्रस्तुति का एक इंस्टेंस बनाएं।  
2. प्रस्तुति में एक खाली स्लाइड जोड़ें।  
3. एक **3D clustered column** चार्ट जोड़ें और उसका अभिगमन करें।  
4. एक नया Microsoft Excel Workbook इंस्टेंस बनाएं और चार्ट डेटा लोड करें।  
5. Microsoft Excel Workbook instancefromworkbook का उपयोग करके चार्ट डेटा वर्कशीट तक पहुँचें।  
6. वर्कशीट में चार्ट रेंज सेट करें और चार्ट से series 2 और 3 को हटाएं।  
7. चार्ट डेटा वर्कशीट में चार्ट श्रेणी डेटा संशोधित करें।  
8. चार्ट डेटा वर्कशीट में chart series 1 डेटा संशोधित करें।  
9. अब, चार्ट शीर्षक तक पहुँचें और setthefontrelatedproperties सेट करें।  
10. चार्ट वैल्यू एक्सिस तक पहुँचें और major unit, minor units, max value और min values सेट करें।  
11. चार्ट डेप्थ या series axis तक पहुँचें और उसे हटाएं क्योंकि इस उदाहरण में, onlyoneserieisused है।  
12. अब, X और Y दिशा में चार्ट रोटेशन एंगल सेट करें।  
13. प्रस्तुति सहेजें।  
14. Microsoft Excel और PowerPoint के इंस्टेंस बंद करें।  

**VSTO के साथ बनाई गई आउटपुट प्रस्तुति** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **Aspose.Slides for Java उदाहरण**
Aspose.Slides for Java का उपयोग करके निम्नलिखित चरण किए जाते हैं:

1. Microsoft PowerPoint प्रस्तुति का एक इंस्टेंस बनाएं।  
2. प्रस्तुति में एक खाली स्लाइड जोड़ें।  
3. एक **3D clustered column** चार्ट जोड़ें और उसका अभिगमन करें।  
4. Microsoft Excel Workbook instancefromworkbook का उपयोग करके चार्ट डेटा वर्कशीट तक पहुँचें।  
5. अनुपयोगी series 2 और 3 को हटाएं।  
6. चार्ट कैटेगोरीज़ तक पहुँचें और लेबल संशोधित करें।  
7. Accesseries1 तक पहुँचें और series मान संशोधित करें।  
8. अब, चार्ट शीर्षक तक पहुँचें और फ़ॉन्ट गुण सेट करें।  
9. चार्ट वैल्यू एक्सिस तक पहुँचें और major unit, minor units, max value और min values सेट करें।  
10. अब, X और Y दिशा में चार्ट रोटेशन एंगल सेट करें।  
11. प्रस्तुति को PPTX प्रारूप में सहेजें।  

**Aspose.Slides के साथ बनाई गई आउटपुट प्रस्तुति** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मैं Aspose.Slides के साथ पाई, लाइन, या बार चार्ट जैसे अन्य प्रकार के चार्ट बना सकता हूँ?
हाँ। Aspose.Slides कई प्रकार के [chart types](/slides/hi/java/create-chart/) का समर्थन करता है, जिसमें पाई चार्ट, लाइन चार्ट, बार चार्ट, स्कैटर प्लॉट, बबल चार्ट और अधिक शामिल हैं। आप चार्ट जोड़ते समय इच्छित चार्ट प्रकार को [ChartType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/charttype/) क्लास का उपयोग करके निर्दिष्ट कर सकते हैं।

### क्या मैं चार्ट पर कस्टम स्टाइल या थीम लागू कर सकता हूँ?
हाँ। आप चार्ट की उपस्थिति को पूरी तरह से कस्टमाइज़ कर सकते हैं, जिसमें रंग, फ़ॉन्ट, भराव, आउटलाइन, ग्रिडलाइन और लेआउट शामिल हैं। हालांकि, PowerPoint में देखे गए Office थीम को बिल्कुल उसी तरह लागू करने के लिए व्यक्तिगत शैली को मैन्युअली सेट करना आवश्यक है।

### क्या मैं स्लाइड से अलग कर चार्ट को छवि के रूप में निर्यात कर सकता हूँ?
हाँ, Aspose.Slides आपको किसी भी Shape—जिसमें चार्ट भी शामिल हैं—को `getImage` मेथड का उपयोग करके चार्ट [shape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shape/) पर अलग छवि (जैसे PNG, JPEG) के रूप में निर्यात करने की अनुमति देता है।