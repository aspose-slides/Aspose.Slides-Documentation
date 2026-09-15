---
title: PPTX में चार्ट पुनः आकार के लिए कार्यात्मक समाधान
type: docs
weight: 40
url: /hi/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- चार्ट पुनः आकार
- Excel चार्ट
- OLE ऑब्जेक्ट
- चार्ट एम्बेड करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ एम्बेडेड Excel OLE ऑब्जेक्ट्स का उपयोग करते समय PPTX में अप्रत्याशित चार्ट पुनः आकार को ठीक करें। आकारों को स्थिर रखने के लिए दो विधियाँ कोड सहित सीखें।"
---
## **पृष्ठभूमि**

यह देखा गया है कि Aspose घटकों के माध्यम से PowerPoint प्रस्तुति में OLE ऑब्जेक्ट के रूप में एम्बेड किए गए Excel चार्ट पहली सक्रियता के बाद एक अनिर्दिष्ट स्केल पर पुन: आकारित हो जाते हैं। यह व्यवहार चार्ट की सक्रियता से पहले और बाद के स्थितियों के बीच प्रस्तुति में एक स्पष्ट दृश्य अंतर पैदा करता है। Aspose टीम ने इस समस्या की विस्तृत जांच की है और एक समाधान पाया है। यह लेख समस्या के कारणों और संबंधित समाधान का वर्णन करता है।

[पिछला लेख](/slides/hi/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) में, हमने बताया था कि Aspose.Cells for Java का उपयोग करके एक Excel चार्ट कैसे बनाएं और Aspose.Slides for Java का उपयोग करके इसे PowerPoint प्रस्तुति में एम्बेड करें। [ऑब्जेक्ट प्रीव्यू समस्या](/slides/hi/java/object-preview-issue-when-adding-oleobjectframe/) को संबोधित करने के लिए, हमने चार्ट छवि को चार्ट के OLE ऑब्जेक्ट फ्रेम को सौंपा। आउटपुट प्रस्तुति में, जब आप चार्ट छवि दिखाने वाले OLE ऑब्जेक्ट फ्रेम पर डबल-क्लिक करते हैं, तो Excel चार्ट सक्रिय हो जाता है। अंतिम उपयोगकर्ता बेसवर्कबुक में वांछित कोई भी परिवर्तन कर सकते हैं और फिर सक्रिय वर्कबुक के बाहर क्लिक करके संबंधित स्लाइड पर वापस जा सकते हैं। जब उपयोगकर्ता स्लाइड पर वापस आता है तो OLE ऑब्जेक्ट फ्रेम का आकार बदलता है, और री-साइज़िंग कारक OLE ऑब्जेक्ट फ्रेम और एम्बेडेड Excel वर्कबुक दोनों के मूल आकारों पर निर्भर करता है।

## **पुन: आकार के कारण**

चूंकि Excel वर्कबुक का अपना विंडो आकार होता है, यह पहली सक्रियता पर अपना मूल आकार बनाए रखने का प्रयास करता है। OLE ऑब्जेक्ट फ्रेम का अपना आकार होता है। Microsoft के अनुसार, जब Excel वर्कबुक सक्रिय होती है, तो Excel और PowerPoint आकार पर बातचीत करते हैं और एम्बेडिंग प्रक्रिया के भाग के रूप में सही अनुपात बनाए रखते हैं। Excel विंडो आकार और OLE ऑब्जेक्ट फ्रेम के आकार या स्थिति के बीच अंतर के आधार पर पुन: आकार होता है।

## **कार्यात्मक समाधान**

Aspose.Slides for Java का उपयोग करके PowerPoint प्रस्तुतियाँ बनाने के दो संभावित परिदृश्य हैं।

**Scenario 1:** मौजूदा टेम्पलेट के आधार पर प्रस्तुति बनाना।

**Scenario 2:** शून्य से प्रस्तुति बनाना।

यहाँ प्रदान किया गया समाधान दोनों परिदृश्यों पर लागू होता है। सभी समाधान दृष्टिकोणों का आधार समान है: **एम्बेडेड OLE ऑब्जेक्ट का विंडो आकार PowerPoint स्लाइड में OLE ऑब्जेक्ट फ्रेम के आकार के समान होना चाहिए**। अब हम इस समाधान के दो दृष्टिकोणों पर चर्चा करेंगे।

## **पहला तरीका**

इस दृष्टिकोण में, हम सीखेंगे कि एम्बेडेड Excel वर्कबुक का विंडो आकार कैसे सेट किया जाए ताकि वह PowerPoint स्लाइड में OLE ऑब्जेक्ट फ्रेम के आकार के समान हो।

**Scenario 1**

मान लीजिए हमने एक टेम्पलेट परिभाषित किया है और इसके आधार पर प्रस्तुतियों को बनाना चाहते हैं। मान लीजिए टेम्पलेट में इंडेक्स 2 पर एक आकार (shape) है जहाँ हम एक OLE फ्रेम रखना चाहते हैं जिसमें एम्बेडेड Excel वर्कबुक हो। इस परिदृश्य में, OLE ऑब्जेक्ट फ्रेम का आकार पूर्वनिर्धारित है—यह टेम्पलेट में इंडेक्स 2 के आकार के समान है। हमें केवल वर्कबुक के विंडो आकार को उस आकार के बराबर सेट करना है। निम्नलिखित कोड स्निपेट इस उद्देश्य की पूर्ति करता है:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// वर्कबुक की विंडो चौड़ाई को इंच में सेट करें (PowerPoint प्रति इंच 72 पॉइंट उपयोग करता है, इसलिए 72 से विभाजित किया गया है)।
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// वर्कबुक की विंडो ऊँचाई को इंच में सेट करें।
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// वर्कबुक को मेमोरी स्ट्रीम में सहेजें।
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// एम्बेडेड Excel डेटा के साथ एक OLE ऑब्जेक्ट फ्रेम बनाएं।
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**Scenario 2**

मान लीजिए हम शून्य से एक प्रस्तुति बनाना चाहते हैं और किसी भी आकार के OLE ऑब्जेक्ट फ्रेम को एम्बेडेड Excel वर्कबुक के साथ शामिल करना चाहते हैं। निम्नलिखित कोड स्निपेट में, हम स्लाइड पर x = 0.5 इंच और y = 1 इंच पर 4 इंच ऊँचाई और 9.5 इंच चौड़ाई वाला OLE ऑब्जेक्ट फ्रेम बनाते हैं। फिर हम Excel वर्कबुक विंडो को समान आकार—4 इंच ऊँचाई और 9.5 इंच चौड़ाई—से सेट करते हैं।

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// इच्छित ऊँचाई।
int desiredHeight = 288; // 4 इंच (4 * 72)
 
// इच्छित चौड़ाई।
int desiredWidth = 684; // 9.5 इंच (9.5 * 72)
 
// विंडो के साथ चार्ट आकार निर्धारित करें।
chart.setSizeWithWindow(true);
 
// वर्कबुक की विंडो चौड़ाई को इंच में सेट करें (PowerPoint प्रति इंच 72 पॉइंट उपयोग करता है, इसलिए 72 से विभाजित किया गया है)।
workbook.getSettings().setWindowWidthInch(desiredWidth / 72f);
 
// वर्कबुक की विंडो ऊँचाई को इंच में सेट करें।
workbook.getSettings().setWindowHeightInch(desiredHeight / 72f);
 
// वर्कबुक को मेमोरी स्ट्रीम में सहेजें।
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// एम्बेडेड Excel डेटा के साथ OLE ऑब्जेक्ट फ्रेम बनाएं।
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0.5 इंच (0.5 * 72)
    72,  // y = 1 इंच (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **दूसरा तरीका**

इस दृष्टिकोण में, हम सीखेंगे कि एम्बेडेड Excel वर्कबुक में चार्ट का आकार कैसे सेट किया जाए ताकि वह PowerPoint स्लाइड में OLE ऑब्जेक्ट फ्रेम के आकार के समान हो। यह तरीका तब उपयोगी होता है जब चार्ट का आकार पहले से ज्ञात हो और कभी नहीं बदलेगा।

**Scenario 1**

मान लीजिए हमने एक टेम्पलेट परिभाषित किया है और इसके आधार पर प्रस्तुति बनाना चाहते हैं। मान लीजिए टेम्पलेट में इंडेक्स 2 पर एक आकार है जहाँ हम एक OLE फ्रेम रखना चाहते हैं जिसमें एम्बेडेड Excel वर्कबुक होगा। इस परिदृश्य में, OLE फ्रेम का आकार पूर्वनिर्धारित है—जो टेम्पलेट में इंडेक्स 2 के आकार के समान है। हमें केवल वर्कबुक में चार्ट का आकार उस आकार के बराबर सेट करना है। निम्नलिखित कोड स्निपेट इस उद्देश्य की पूर्ति करता है:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// विंडो के बिना चार्ट आकार निर्धारित करें।
chart.setSizeWithWindow(false);
 
// चार्ट की चौड़ाई को पिक्सेल में सेट करें (Excel प्रति इंच 96 पिक्सेल उपयोग करता है, इसलिए 96 से गुणा करें)।
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// चार्ट की ऊँचाई को पिक्सेल में सेट करें।
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// चार्ट प्रिंट आकार निर्धारित करें।
chart.setPrintSize(com.aspose.cells.PrintSizeType.CUSTOM);
 
// वर्कबुक को मेमोरी स्ट्रीम में सहेजें।
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// एम्बेडेड Excel डेटा के साथ OLE ऑब्जेक्ट फ्रेम बनाएं।
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**Scenario 2**:

मान लीजिए हम शून्य से एक प्रस्तुति बनाना चाहते हैं और किसी भी आकार के OLE ऑब्जेक्ट फ्रेम को एम्बेडेड Excel वर्कबुक के साथ शामिल करना चाहते हैं। निम्नलिखित कोड स्निपेट में, हम स्लाइड पर x = 0.5 इंच और y = 1 इंच पर 4 इंच ऊँचाई और 9.5 इंच चौड़ाई वाला OLE ऑब्जेक्ट फ्रेम बनाते हैं। हम संबंधित चार्ट का आकार भी समान आयामों पर सेट करते हैं: 4 इंच ऊँचाई और 9.5 इंच चौड़ाई।

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// हमारी इच्छित ऊँचाई।
int desiredHeight = 288; // 4 इंच (4 * 72)
 
// हमारी इच्छित चौड़ाई।
int desiredWidth = 684; // 9.5 इंच (9.5 * 72)
 
// विंडो के बिना चार्ट आकार परिभाषित करें।
chart.setSizeWithWindow(false);
 
// चार्ट की चौड़ाई को पिक्सेल में सेट करें (इंच प्राप्त करने के लिए 72 से विभाजित, फिर Excel 96 पिक्सेल प्रति इंच उपयोग करता है इसलिए 96 से गुणा)।
chart.getChartObject().setWidth((int)((desiredWidth / 72f) * 96f));
 
// चार्ट की ऊँचाई को पिक्सेल में सेट करें।
chart.getChartObject().setHeight((int)((desiredHeight / 72f) * 96f));
 
// वर्कबुक को मेमोरी स्ट्रीम में सहेजें।
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// एम्बेडेड Excel डेटा के साथ OLE ऑब्जेक्ट फ्रेम बनाएं।
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0.5 इंच (0.5 * 72)
    72,  // y = 1 इंच (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **निष्कर्ष**

चार्ट पुन: आकार समस्या को ठीक करने के दो तरीके हैं। तरीका चुनना आवश्यकताओं और उपयोग केस पर निर्भर करता है। दोनों तरीके उसी तरह काम करते हैं चाहे प्रस्तुतियाँ टेम्पलेट से बनाई गई हों या शून्य से बनाई गई हों। साथ ही, इस समाधान में OLE ऑब्जेक्ट फ्रेम के आकार पर कोई सीमा नहीं है।

## **अक्सर पूछे जाने वाले प्रश्न**

### PowerPoint में सक्रिय करने के बाद मेरा एम्बेडेड Excel चार्ट आकार क्यों बदलता है?

यह इसलिए होता है क्योंकि Excel पहली बार सक्रिय होने पर मूल विंडो आकार को पुनर्स्थापित करने का प्रयास करता है, जबकि PowerPoint में OLE ऑब्जेक्ट फ्रेम का अपना आकार होता है। PowerPoint और Excel आकार पर बातचीत करते हैं ताकि अनुपात बनाए रखा जा सके, जिससे पुन: आकार हो सकता है।

### क्या इस पुन: आकार समस्या को पूरी तरह से रोकना संभव है?

हाँ। एम्बेड करने से पहले Excel वर्कबुक विंडो आकार या चार्ट आकार को OLE ऑब्जेक्ट फ्रेम के आकार के साथ मिलाकर, आप चार्ट के आकार को स्थिर रख सकते हैं।

### कौन सा तरीका चुनूँ, वर्कबुक विंडो आकार सेट करना या चार्ट आकार सेट करना?

यदि आप वर्कबुक के अनुपात को बनाए रखना चाहते हैं और बाद में संभवतः आकार बदलने की अनुमति देना चाहते हैं तो **Approach 1 (window size)** का उपयोग करें।  
यदि चार्ट के आयाम निश्चित हैं और एम्बेड करने के बाद बदलेंगे नहीं, तो **Approach 2 (chart size)** का उपयोग करें।

### क्या ये विधियाँ टेम्पलेट-आधारित प्रस्तुतियों और नई प्रस्तुतियों दोनों पर काम करेंगी?

हाँ। दोनों तरीके टेम्पलेट से बनाई गई प्रस्तुतियों और शून्य से बनाई गई प्रस्तुतियों दोनों के लिए समान रूप से काम करते हैं।

### OLE ऑब्जेक्ट फ्रेम के आकार पर कोई सीमा है क्या?

नहीं। आप OLE फ्रेम को किसी भी आकार पर सेट कर सकते हैं जब तक कि वह वर्कबुक या चार्ट आकार के अनुसार उपयुक्त रूप से स्केल हो।

### क्या मैं इन विधियों को अन्य स्प्रेडशीट प्रोग्रामों में बनाए गए चार्ट्स के साथ उपयोग कर सकता हूँ?

उदाहरण Aspose.Cells के साथ बनाए गए Excel चार्ट्स के लिए डिज़ाइन किए गए हैं, लेकिन सिद्धांत उन अन्य OLE-समर्थित स्प्रेडशीट प्रोग्रामों पर भी लागू होते हैं जो समान आकार विकल्पों का समर्थन करते हैं।

## **संबंधित अनुभाग**

- [Excel चार्ट बनाएं और उन्हें OLE ऑब्जेक्ट्स के रूप में प्रस्तुतियों में एम्बेड करें](/slides/hi/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)