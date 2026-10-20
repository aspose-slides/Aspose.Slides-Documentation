---
title: "Excel चार्ट बनाएं और उन्हें प्रस्तुति में OLE ऑब्जेक्ट के रूप में एम्बेड करें"
type: docs
weight: 30
url: /hi/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel चार्ट
- चार्ट एम्बेड करें
- OLE ऑब्जेक्ट
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Cells for Java के साथ एक Excel चार्ट बनाएं और Aspose.Slides के साथ PowerPoint प्रस्तुति में वर्कबुक को एम्बेड करें, जिसमें चार्ट का प्रीव्यू शामिल हो।"
---
## **अवलोकन**

यह लेख दिखाता है कि Aspose.Cells for Java के साथ एक Excel कॉलम चार्ट कैसे बनाएं और उसके वर्कबुक को Aspose.Slides for Java के साथ एक PowerPoint प्रस्तुति में एम्बेड करें। एम्बेडेड वर्कबुक में स्रोत डेटा और चार्ट दोनों शामिल होते हैं। एक अलग PNG प्रीव्यू स्लाइड पर चार्ट को दिखाता है इससे पहले कि OLE ऑब्जेक्ट सक्रिय किया जाए।

परिणाम एक एम्बेडेड Excel ऑब्जेक्ट है, न कि मूल PowerPoint चार्ट। OLE के माध्यम से वर्कबुक को संपादित करने के लिए एक डेस्कटॉप एप्लिकेशन चाहिए जो OLE सक्रियण का समर्थन करता हो और एक संगत Excel इंस्टॉलेशन हो।

## **पूर्वापेक्षाएँ**

अपने प्रोजेक्ट निर्भरताओं में Aspose.Cells for Java और Aspose.Slides for Java जोड़ें। उदाहरण को एक Java मेथड के भीतर चलाएँ। इन लाइब्रेरीज़ के साथ प्रस्तुति उत्पन्न करने के लिए Microsoft Office की आवश्यकता नहीं है।

कोई इनपुट फ़ाइल आवश्यक नहीं है: उदाहरण डेटा और चार्ट को मेमोरी में बनाता है, फिर `OutputChart.pptx` को वर्तमान कार्य निर्देशिका में लिखता है। मूल्यांकन मोड के बाहर चलाते समय दोनों उत्पादों के लिए लाइसेंस लागू करें।

## **एम्बेडिंग कैसे कार्य करता है**

1. डेटा वर्कशीट और चार्ट शीट के साथ एक वर्कबुक बनाएं।  
2. चार्ट शीट को सक्रिय करें ताकि वर्कबुक चार्ट पर खुले।  
3. वर्कबुक की OLE डिस्प्ले रेंज सेट करें और चार्ट को PNG में रेंडर करें।  
4. वर्कबुक को मेमोरी में XLSX के रूप में सहेजें और उन बाइट्स को स्लाइड में एम्बेड करें।  
5. PNG को OLE ऑब्जेक्ट का प्रीव्यू असाइन करें और प्रस्तुति को PPTX के रूप में सहेजें।  

वर्कबुक डिस्प्ले रेंज और स्लाइड पर फ्रेम की अलग-अलग भूमिकाएँ होती हैं। [setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) शून्य-आधारित प्रारम्भ/समाप्ति पंक्ति और स्तम्भ सूचकांक लेता है। [ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) इसके बजाय शीर्ष पंक्ति, बायाँ स्तम्भ, नीचे की पंक्ति और दायाँ स्तम्भ लेता है। उदाहरण पंक्ति सूचकांक 55 और स्तम्भ सूचकांक 25 को निचले‑दाएँ सीमा के रूप में उपयोग करता है; ये मान लेआउट विकल्प हैं, न कि डेटा पंक्तियों या स्तम्भों की संख्या।  

स्लाइड फ्रेम पॉइंट्स में मापा जाता है। उदाहरण इसे स्लाइड के भीतर फिट करता है और केंद्र में रखता है जबकि PNG के अनुपात को बरकरार रखता है, बजाय प्रीव्यू को स्लाइड भरने के लिए विस्तारित करने के।

## **चार्ट बनाना और एम्बेड करना**

निम्नलिखित पूर्ण उदाहरण `DataSheet` को चार पंक्तियों और पाँच स्तम्भों के मानों से भरता है। प्रत्येक पंक्ति एक चार्ट श्रृंखला बनती है। वर्कबुक को सहेजने से पहले `ChartSheet` को सक्रिय शीट के रूप में चुना जाता है।  

वर्कबुक को स्पष्ट रूप से XLSX के रूप में सहेजा जाता है, जो `xlsx` एक्सटेंशन से मेल खाता है जो [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/oleembeddeddatainfo/) को पास किया गया है। PNG को उसके बाइट्स से सीधे लोड किया जाता है बिना किसी मध्यवर्ती बिटमैप रूपांतरण के। इसे [getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) के माध्यम से असाइन करने से डिफॉल्ट OLE प्लेसहोल्डर बदल जाता है।

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import static com.aspose.cells.SaveFormat.XLSX;
import static com.aspose.slides.SaveFormat.Pptx;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.IImage;
import com.aspose.slides.Images;
import com.aspose.slides.IOleObjectFrame;
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import java.io.ByteArrayOutputStream;

try {
    Workbook workbook = new Workbook();
    try {
        Worksheet dataSheet = workbook.getWorksheets().get(0);
        dataSheet.setName("DataSheet");

        int[][] values = {
            { 67, 44, 46, 43, 24 },
            { 86, 64, 97, 29, 40 },
            { 68, 89, 78, 69, 38 },
            { 91, 48, 60, 26, 25 }
        };

        for (int row = 0; row < values.length; row++) {
            for (int column = 0; column < values[row].length; column++) {
                dataSheet.getCells().get(row, column).putValue(values[row][column]);
            }
        }

        int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
        Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
        chartSheet.setName("ChartSheet");

        int lastChartRow = 55;
        int lastChartColumn = 25;
        int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
        Chart chart = chartSheet.getCharts().get(chartIndex);
        for (int row = 1; row <= values.length; row++) {
            chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
        }

        workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
        workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

        // चार्ट प्रीव्यू रेंडर करें और संपादन योग्य वर्कबुक को अलग से सीरियलाइज़ करें।
        ImageOrPrintOptions imageOptions = new ImageOrPrintOptions();
        imageOptions.setImageType(ImageType.PNG);
        ByteArrayOutputStream chartImageStream = new ByteArrayOutputStream();
        chart.toImage(chartImageStream, imageOptions);
        byte[] chartImageBytes = chartImageStream.toByteArray();

        ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
        workbook.save(workbookStream, XLSX);
        byte[] workbookBytes = workbookStream.toByteArray();

        IImage chartImage = Images.fromData(chartImageBytes);
        try {
            Presentation presentation = new Presentation();
            try {
                ISlide slide = presentation.getSlides().get_Item(0);
                double slideWidth = presentation.getSlideSize().getSize().getWidth();
                double slideHeight = presentation.getSlideSize().getSize().getHeight();

                // स्लाइड के भीतर प्रीव्यू को फिट करें बिना उसके अनुपात को बदले।
                double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                float frameWidth = (float) (chartImage.getWidth() * scale);
                float frameHeight = (float) (chartImage.getHeight() * scale);
                float frameX = (float) ((slideWidth - frameWidth) / 2);
                float frameY = (float) ((slideHeight - frameHeight) / 2);

                OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                IPPImage previewImage = presentation.getImages().addImage(chartImage);
                oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                presentation.save("OutputChart.pptx", Pptx);
            } finally {
                presentation.dispose();
            }
        } finally {
            chartImage.dispose();
        }
    } finally {
        workbook.dispose();
    }
} catch (Exception exception) {
    System.err.println("Could not create the presentation: " + exception.getMessage());
}
```

## **अपेक्षित परिणाम**

`OutputChart.pptx` में एक स्लाइड है जिसमें एम्बेडेड Excel वर्कबुक और चार्ट का प्रीव्यू होता है। वर्कबुक में मूल डेटा और चार श्रृंखलाओं वाला कॉलम चार्ट होता है। प्रीव्यू स्लाइड के केंद्र में रहता है और अपने अनुपात को बरकरार रखता है।

![एम्बेडेड वर्कबुक के प्रीव्यू के रूप में प्रदर्शित Excel कॉलम चार्ट](excel-chart-ole-preview.png)

एक संगत डेस्कटॉप PowerPoint वातावरण में जहाँ Excel उपलब्ध है, ऑब्जेक्ट पर डबल‑क्लिक करें ताकि एम्बेडेड वर्कबुक सक्रिय हो और संपादित किया जा सके। सक्रियण और संपादन होस्ट एप्लिकेशन के OLE समर्थन और सुरक्षा सेटिंग्स पर निर्भर करता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**प्रीव्यू इमेज की आवश्यकता क्यों है?**  
एंबेडेड वर्कबुक और उसका स्लाइड प्रीव्यू अलग-अलग सामग्री हैं। एक चार्ट इमेज प्रदान करें ताकि स्लाइड डिफॉल्ट "EMBEDDED OLE OBJECT" प्लेसहोल्डर के बजाय चार्ट दिखाए। देखें [OleObjectFrame जोड़ते समय ऑब्जेक्ट प्रीव्यू समस्या](/slides/hi/java/object-preview-issue-when-adding-oleobjectframe/)।

**क्या कोड में वर्कबुक बदलने पर प्रीव्यू स्वतः अपडेट हो जाता है?**  
प्रीव्यू को एक स्नैपशॉट मानें। जब प्रोग्रामेटिक रूप से वर्कबुक डेटा अपडेट करते हैं, तो चार्ट इमेज को पुनः उत्पन्न करें और प्रीव्यू के साथ-साथ एम्बेडेड वर्कबुक डेटा को भी बदलें।

**क्या मैं XLS को XLSX के बजाय उपयोग कर सकता हूँ?**  
हां। वर्कबुक को XLS फॉर्मेट में सहेजें और एम्बेडेड डेटा एक्सटेंशन के रूप में `xls` उपयोग करें। एक्सटेंशन को वास्तविक वर्कबुक फॉर्मेट से मेल खाना चाहिए; केवल एक्सटेंशन बदलने से डेटा परिवर्तित नहीं होता।

**सक्रियण के बाद ऑब्जेक्ट का आकार क्यों बदल सकता है?**  
होस्ट एप्लिकेशन वर्कबुक को सक्रिय करने पर OLE ऑब्जेक्ट की प्रस्तुति को अपडेट कर सकता है। वर्कबुक की OLE डिस्प्ले रेंज और स्लाइड फ्रेम के आयाम दोनों महत्वपूर्ण हैं। देखें [PPTX में चार्ट रिसाइज़िंग के लिए कार्यशील समाधान](/slides/hi/java/working-solution-for-chart-resizing-in-pptx/)।

## **संबंधित अनुभाग**

- [PPTX में चार्ट रिसाइज़िंग के लिए कार्यशील समाधान](/slides/hi/java/working-solution-for-chart-resizing-in-pptx/)
- [OleObjectFrame जोड़ते समय ऑब्जेक्ट प्रीव्यू समस्या](/slides/hi/java/object-preview-issue-when-adding-oleobjectframe/)
- [PowerPoint ऐड‑इन का उपयोग करके OLE ऑब्जेक्ट को स्वचालित रूप से अपडेट करें](/slides/hi/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)