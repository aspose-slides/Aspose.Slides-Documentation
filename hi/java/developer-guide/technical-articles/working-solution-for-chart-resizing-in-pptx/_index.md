---
title: PPTX में चार्ट आकार बदलने के लिए कार्यशील समाधान
type: docs
weight: 40
url: /hi/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- चार्ट आकार परिवर्तन
- Excel चार्ट
- OLE ऑब्जेक्ट
- चार्ट एम्बेड करें
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ एम्बेडेड Excel OLE ऑब्जेक्ट्स का उपयोग करते समय PPTX में अप्रत्याशित चार्ट आकार परिवर्तन को ठीक करें। चार्ट और OLE फ्रेम के आकार को सुसंगत रखने के लिए स्थिर चार्ट आयाम सेट करें।"
---
## **पृष्ठभूमि**

Excel चार्ट को OLE ऑब्जेक्ट्स के रूप में PowerPoint प्रस्तुतियों में Aspose घटकों का उपयोग करके एम्बेड करने पर पहली सक्रियता के बाद आकार बदल सकता है। इससे सक्रियता से पहले और बाद में चार्ट की उपस्थिति में एक उल्लेखनीय अंतर दिख सकता है। यह लेख बताता है कि आकार परिवर्तन क्यों होता है और कैसे OLE फ्रेम के साथ फ़िक्स्ड चार्ट आयाम मिलाकर इसे रोका जाए।

[एक्सेल चार्ट बनाएं और उन्हें OLE ऑब्जेक्ट्स के रूप में प्रस्तुतियों में एम्बेड करें](/slides/hi/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) में हमने बताया था कि Aspose.Cells for Java का उपयोग करके Excel चार्ट कैसे बनाएं और Aspose.Slides for Java का उपयोग करके उसे PowerPoint प्रस्तुति में एम्बेड करें। [ऑब्जेक्ट प्रीव्यू समस्या](/slides/hi/java/object-preview-issue-when-adding-oleobjectframe/) को हल करने के लिए हमने चार्ट छवि को चार्ट के OLE ऑब्जेक्ट फ्रेम से जोड़ा। आउटपुट प्रस्तुति में, जब आप OLE ऑब्जेक्ट फ्रेम (जिसमें चार्ट छवि दिखाई देती है) पर डबल‑क्लिक करते हैं, तो Excel चार्ट सक्रिय हो जाता है। उपयोगकर्ता एम्बेडेड Excel वर्कबुक को संपादित कर सकते हैं और फिर सक्रिय वर्कबुक के बाहर क्लिक करके स्लाइड पर वापस आ सकते हैं। उपयोगकर्ता के लौटने पर OLE ऑब्जेक्ट फ़्रेम का आकार बदल जाता है, और यह री‑साइज़िंग फ़ैक्टर OLE ऑब्जेक्ट फ़्रेम और एम्बेडेड Excel वर्कबुक के मूल आकारों पर निर्भर करता है।

## **आकार परिवर्तन का कारण**

एंबेडेड Excel वर्कबुक का अपना विंडो आयाम होता है, जिसे Excel पहली सक्रियता पर बनाए रखने की कोशिश करता है। स्लाइड पर OLE फ्रेम के अपने निर्धारित आयाम होते हैं। जब Excel वर्कबुक सक्रिय होती है, तो Excel और PowerPoint ऑब्जेक्ट के आकार को उसके अनुपात बनाए रखने के लिए वार्ता करते हैं, जो एम्बेडिंग प्रक्रिया का हिस्सा है। वर्कबुक विंडो और OLE फ्रेम के बीच के अंतर के कारण ऑब्जेक्ट का आकार बदल सकता है।

## **कार्यान्वित समाधान**

चार्ट का आकार स्लाइड पर OLE फ्रेम से मिलाएँ और चार्ट आयामों को वर्कबुक विंडो से स्वतंत्र रखें। यह समाधान नई प्रस्तुति या मौजूदा टेम्पलेट दोनों के साथ काम करता है।

उदाहरण के लिए Aspose.Cells for Java और Aspose.Slides for Java की आवश्यकता होती है। यह एक सरल कॉलम चार्ट को सक्रिय चार्ट शीट पर बनाता है और वर्कबुक को XLS फ़ॉर्मेट में एम्बेड करता है। कोई चार्ट प्रीव्यू छवि नहीं जोड़ी गई है; चार्ट PowerPoint में OLE ऑब्जेक्ट सक्रिय होने पर दिखाई देगा।

उदाहरण एक नई प्रस्तुति बनाता है जिसमें 9.5 × 4‑इंच का OLE फ्रेम बाएँ किनारे से 0.5 इंच और शीर्ष से 1 इंच की स्थिति पर रहता है। स्लाइड निर्देशांक और आयाम पॉइंट्स में होते हैं (प्रति इंच 72 पॉइंट)। मौजूदा प्रस्तुति के लिए, देखें [टेम्पलेट का उपयोग करें](#use-a-template)।

## **फ़िक्स्ड चार्ट आकार सेट करें**

[setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) को false सेट करें ताकि चार्ट आयाम वर्कबुक विंडो से स्वतंत्र रहें। [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) के आयामों को [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) और [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-) के माध्यम से सेट करें, 96 पिक्सेल प्रति इंच का उपयोग करके पॉइंट को पिक्सेल में बदलते हुए: 684 × 288 पॉइंट का फ्रेम 912 × 384 पिक्सेल के चार्ट के बराबर होता है। [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) को [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/) के CUSTOM मान पर सेट करें। उदाहरण वर्कबुक को [addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) द्वारा एम्बेड करता है और 9.5 × 4‑इंच के OLE फ्रेम के साथ प्रस्तुति को सहेजता है।

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.FileFormatType;
import com.aspose.cells.PrintSizeType;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Workbook workbook = new Workbook();
try {
    Worksheet dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("Data");
    dataSheet.getCells().get("A1").putValue(10);
    dataSheet.getCells().get("A2").putValue(20);

    int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
    Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10);
    Chart chart = chartSheet.getCharts().get(chartIndex);
    chart.getNSeries().add("Data!A1:A2", true);
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // स्लाइड के निर्देशांक और आयाम पॉइंट्स में हैं (प्रति इंच 72 पॉइंट)।
        float width = 684f; // 9.5 इंच।
        float height = 288f; // 4 इंच।

        chart.setSizeWithWindow(false);
        // पॉइंट्स को चार्ट पिक्सेल में बदलें, 96 पिक्सेल प्रति इंच का उपयोग करके।
        chart.getChartObject().setWidth((int)(width / 72f * 96f));
        chart.getChartObject().setHeight((int)(height / 72f * 96f));
        chart.setPrintSize(PrintSizeType.CUSTOM);

        ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
        workbook.save(workbookStream, FileFormatType.EXCEL_97_TO_2003);
        OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
        slide.getShapes().addOleObjectFrame(36, 72, width, height, dataInfo);

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    workbook.dispose();
}
```

## **टेम्पलेट का उपयोग करें**

आकार निर्धारण तर्क मौजूदा प्रस्तुति के लिए भी समान है। उदाहरण को अनुकूलित करने के लिए:

1. खाली प्रस्तुति बनाने के बजाय टेम्पलेट प्रस्तुति लोड करें।
1. सुनिश्चित करें कि पहली स्लाइड में कम से कम तीन शैप्स हैं, फिर इंडेक्स 2 वाले शैप को प्लेसहोल्डर के रूप में उपयोग करें।
1. स्थिर मान 684 और 288 के बजाय उस शैप से फ्रेम की चौड़ाई और ऊँचाई प्राप्त करें। आकार गणनाएँ अपरिवर्तित रखें।
1. स्थिर निर्देशांक 36 और 72 के बजाय प्लेसहोल्डर की स्थिति पर OLE फ्रेम जोड़ें।
1. प्रस्तुति सहेजने से पहले प्लेसहोल्डर को हटा दें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्यों मेरे एम्बेडेड एक्सेल चार्ट को पावरपॉइंट में सक्रिय करने के बाद आकार बदल जाता है?**

यह इसलिए होता है क्योंकि Excel पहली सक्रियता पर मूल विंडो आकार बहाल करने की कोशिश करता है, जबकि PowerPoint में OLE ऑब्जेक्ट फ्रेम का अपना आयाम होता है। PowerPoint और Excel आकार को अनुपात बनाए रखने के लिए वार्ता करते हैं, जिससे आकार परिवर्तन हो सकता है।

**मैं चार्ट और OLE फ्रेम के आकार को समान कैसे रख सकता हूं?**

फ़िक्स्ड चार्ट आयाम सेट करें जो OLE फ्रेम से मेल खाते हों और वर्कबुक एम्बेड करने से पहले कस्टम चार्ट प्रिंट आकार उपयोग करें। ऊपर दिया गया उदाहरण आवश्यक सेटिंग्स और यूनिट परिवर्तन दर्शाता है।

**क्या केवल वर्कबुक विंडो आकार मिलाना पर्याप्त है?**

केवल वर्कबुक विंडो आकार मिलाना OLE फ्रेम के सक्रियता के बाद आकार बदलने को भरोसेमंद रूप से रोक नहीं सकता। उदाहरण में दिखाए अनुसार फ़िक्स्ड चार्ट आयाम उपयोग करें।

**क्या यह समाधान टेम्पलेट‑आधारित प्रस्तुतियों और नई प्रस्तुतियों दोनों में काम करता है?**

हां। टेम्पलेट के लिए प्लेसहोल्डर के आयाम और स्थिति उपयोग करें। नई प्रस्तुति के लिए सीधे फ्रेम की आयाम और स्थिति निर्दिष्ट करें।

**क्या मैं इस उदाहरण को अन्य स्प्रेडशीट प्रोग्राम्स में बनाए गए चार्ट के साथ उपयोग कर सकता हूं?**

उदाहरण एक Excel वर्कबुक का उपयोग करता है जो Aspose.Cells द्वारा निर्मित है। यह अन्य स्प्रेडशीट प्रोग्राम्स के लिए सक्रियता व्यवहार नहीं दर्शाता।

## **संबंधित अनुभाग**

- [एक्सेल चार्ट बनाएं और उन्हें OLE ऑब्जेक्ट्स के रूप में प्रस्तुतियों में एम्बेड करें](/slides/hi/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)