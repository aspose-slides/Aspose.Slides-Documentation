---
title: PPTX में चार्ट आकार बदलने के लिए कार्यशील समाधान
type: docs
weight: 40
url: /hi/androidjava/working-solution-for-chart-resizing-in-pptx/
keywords:
- चार्ट आकार बदलना
- Excel चार्ट
- OLE ऑब्जेक्ट
- एम्बेडेड चार्ट
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ एम्बेडेड Excel OLE ऑब्जेक्ट्स का उपयोग करते समय PPTX में अप्रत्याशित चार्ट आकार बदलने को ठीक करें। चार्ट और OLE फ़्रेम के आकार को सुसंगत रखने के लिए स्थिर चार्ट आयाम सेट करें।"
---
## **अवलोकन**

Aspose घटकों का उपयोग करके PowerPoint प्रस्तुतियों में OLE ऑब्जेक्ट्स के रूप में एम्बेड किए गए Excel चार्ट्स पहली सक्रियता के बाद आकार बदल सकते हैं। इससे सक्रियता से पहले और बाद चार्ट की उपस्थिति में उल्लेखनीय अंतर उत्पन्न हो सकता है। यह लेख बताता है कि आकार बदलना क्यों होता है और स्थिर चार्ट आयामों को OLE फ्रेम से मिलाकर इसे कैसे रोका जाए।

In [प्रस्तुतियों में OLE ऑब्जेक्ट्स के रूप में Excel चार्ट बनाएं और एम्बेड करें](/slides/hi/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), we explained how to create an Excel chart with Aspose.Cells for Android via Java and embed it in a PowerPoint presentation using Aspose.Slides for Android via Java. To address the [ऑब्जेक्ट पूर्वावलोकन समस्या](/slides/hi/androidjava/object-preview-issue-when-adding-oleobjectframe/), we assigned the chart image to the chart’s OLE object frame. In the output presentation, when you double-click the OLE object frame displaying the chart image, the Excel chart is activated. Users can edit the embedded Excel workbook and then return to the slide by clicking outside the activated workbook. The size of the OLE object frame changes when the user returns to the slide, and the resizing factor varies depending on the original sizes of both the OLE object frame and the embedded Excel workbook.

## **रीसाइज़िंग का कारण**

एम्बेड किए गए Excel वर्कबुक के अपने विंडो आयाम होते हैं, जिन्हें Excel पहली सक्रियता के समय बनाए रखने की कोशिश करता है। स्लाइड पर OLE फ़्रेम के आयाम स्वतंत्र रूप से परिभाषित होते हैं। जब Excel वर्कबुक सक्रिय होती है, तो Excel और PowerPoint ऑब्जेक्ट का आकार उसके अनुपात को बनाए रखने के लिए नेगोसिएट करते हैं, जो एम्बेडिंग प्रक्रिया का हिस्सा है। वर्कबुक विंडो और OLE फ़्रेम के बीच अंतर के कारण ऑब्जेक्ट का आकार बदल सकता है।

## **कार्यशील समाधान**

चार्ट का आकार स्लाइड पर OLE फ़्रेम के साथ मिलाएँ और चार्ट आयामों को वर्कबुक विंडो से स्वतंत्र रखें। यह समाधान नई प्रस्तुति या मौजूदा टेम्पलेट दोनों के साथ काम करता है।

उदाहरण के लिए Aspose.Cells for Android via Java और Aspose.Slides for Android via Java आवश्यक है। यह सक्रिय चार्ट शीट पर एक सरल कॉलम चार्ट बनाता है और वर्कबुक को XLS प्रारूप में एम्बेड करता है। Android गतिविधि से `FixedChartSize.createPresentation(getFilesDir())` को कॉल करके आउटपुट को एप्लिकेशन की आंतरिक फ़ाइल डायरेक्टरी में सहेजा जा सकता है। OLE सक्रियता के लिए डेस्कटॉप PowerPoint और संगत Excel इंस्टॉलेशन आवश्यक है। कोई चार्ट प्रीव्यू इमेज असाइन नहीं किया गया; चार्ट तभी दिखाई देता है जब PowerPoint में OLE ऑब्जेक्ट सक्रिय किया जाता है।

उदाहरण एक नई प्रस्तुति बनाता है जिसमें 9.5 × 4‑इंच OLE फ़्रेम 0.5 इंच बाएँ किनारे से और 1 इंच ऊपर स्थित है। स्लाइड कॉर्डिनेट्स और आयाम पॉइंट्स में होते हैं (प्रति इंच 72 पॉइंट)। मौजूदा प्रस्तुति के लिए, देखें [टेम्पलेट उपयोग करें](#use-a-template)।

## **स्थिर चार्ट आकार सेट करें**

[setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) को false सेट करें जिससे चार्ट आयाम वर्कबुक विंडो से स्वतंत्र रहें। [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) के आयामों को [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) और [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-) के माध्यम से सेट करें, 96 पिक्सेल प्रति इंच का उपयोग करके पॉइंट्स को पिक्सेल में बदलें: 684 × 288 पॉइंट का फ़्रेम 912 × 384 पिक्सेल के चार्ट के बराबर है। [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) को [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/) के CUSTOM मान पर सेट करें। उदाहरण वर्कबुक को [addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) के साथ एम्बेड करता है और 9.5 × 4‑इंच OLE फ़्रेम के साथ प्रस्तुति को सहेजता है।

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
import java.io.File;

public class FixedChartSize {
    public static void createPresentation(File filesDirectory) {
        try {
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

                    // स्लाइड के निर्देशांक और आयाम पॉइंट्स में होते हैं (प्रति इंच 72 पॉइंट्स)।
                    float width = 684f; // 9.5 इंच।
                    float height = 288f; // 4 इंच।

                    chart.setSizeWithWindow(false);
                    // 96 पॉइंट्स प्रति इंच का उपयोग करके पॉइंट्स को चार्ट पिक्सेल में बदलें।
                    chart.getChartObject().setWidth((int)(width / 72f * 96f));
                    chart.getChartObject().setHeight((int)(height / 72f * 96f));
                    chart.setPrintSize(PrintSizeType.CUSTOM);

                    ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
                    workbook.save(workbookStream, FileFormatType.EXCEL_97_TO_2003);
                    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
                    slide.getShapes().addOleObjectFrame(36, 72, width, height, dataInfo);

                    File outputFile = new File(filesDirectory, "chart-fixed-size.pptx");
                    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
                } finally {
                    presentation.dispose();
                }
            } finally {
                workbook.dispose();
            }
        } catch (Exception exception) {
            System.err.println("Unable to create the presentation: " + exception.getMessage());
        }
    }
}
```

## **टेम्पलेट उपयोग करें**

साइज़िंग लॉजिक मौजूदा प्रस्तुति के लिए भी समान है। उदाहरण को अनुकूलित करने के लिए:

1. खाली प्रस्तुति बनाने की बजाय टेम्पलेट प्रस्तुति लोड करें।
1. सुनिश्चित करें कि पहली स्लाइड में कम से कम तीन शShapes हैं, फिर इंडेक्स 2 वाले शShape को प्लेसहोल्डर के रूप में उपयोग करें।
1. स्थिर मान 684 और 288 के बजाय उस शShape से फ़्रेम की चौड़ाई और ऊँचाई लें। साइज़िंग गणनाएँ अपरिवर्तित रखें।
1. स्थिर कॉर्डिनेट्स 36 और 72 के बजाय प्लेसहोल्डर की स्थिति पर OLE फ़्रेम जोड़ें।
1. प्रस्तुति सहेजने से पहले प्लेसहोल्डर को हटाएँ।

## **अक्सर पूछे जाने वाले प्रश्न**

**मेरे एम्बेड किए गए Excel चार्ट का आकार PowerPoint में सक्रिय करने के बाद क्यों बदलता है?**

यह इसलिए होता है क्योंकि Excel पहली सक्रियता पर मूल विंडो आकार को पुनर्स्थापित करने की कोशिश करता है, जबकि PowerPoint में OLE ऑब्जेक्ट फ़्रेम के अपने आयाम होते हैं। PowerPoint और Excel अनुपात को बनाए रखने के लिए आकार नेगोसिएट करते हैं, जिससे रीसाइज़िंग हो सकती है।

**मैं चार्ट और OLE फ़्रेम के आकार को कैसे संगत रखूं?**

स्थिर चार्ट आयाम सेट करें जो OLE फ़्रेम से मेल खाते हों और वर्कबुक को एम्बेड करने से पहले कस्टम चार्ट प्रिंट साइज़ का उपयोग करें। ऊपर दिया गया उदाहरण आवश्यक सेटिंग्स और इकाई रूपांतरण दिखाता है।

**क्या केवल वर्कबुक विंडो आकार मिलाना पर्याप्त है?**

केवल वर्कबुक विंडो आकार मिलाना OLE फ़्रेम के सक्रियण के बाद आकार बदलने को विश्वसनीय रूप से रोकता नहीं है। उदाहरण में दिखाए गए स्थिर चार्ट आयामों का उपयोग करें।

**क्या यह समाधान टेम्पलेट‑आधारित और नई प्रस्तुतियों दोनों के लिए काम करता है?**

हाँ। टेम्पलेट के लिए प्लेसहोल्डर के आयाम और स्थिति का उपयोग करें। नई प्रस्तुति के लिए फ़्रेम के आयाम और स्थिति सीधे निर्दिष्ट करें।

**क्या मैं इस उदाहरण को अन्य स्प्रेडशीट प्रोग्राम्स में बनाए गए चार्ट्स के साथ उपयोग कर सकता हूँ?**

यह उदाहरण Aspose.Cells के साथ बनाया गया Excel वर्कबुक उपयोग करता है। यह अन्य स्प्रेडशीट प्रोग्राम्स के सक्रियण व्यवहार को दर्शाता नहीं है।

## **संबंधित अनुभाग**

- [प्रस्तुतियों में OLE ऑब्जेक्ट्स के रूप में Excel चार्ट बनाएं और एम्बेड करें](/slides/hi/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)