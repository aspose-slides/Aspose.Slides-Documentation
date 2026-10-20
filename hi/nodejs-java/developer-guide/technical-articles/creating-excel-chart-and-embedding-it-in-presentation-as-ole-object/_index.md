---
title: एक्सेल चार्ट बनाएं और उन्हें प्रस्तुति में OLE ऑब्जेक्ट के रूप में एम्बेड करें
type: docs
weight: 30
url: /hi/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- एक्सेल चार्ट
- चार्ट एम्बेड करें
- OLE ऑब्जेक्ट
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Cells for Node.js via Java के साथ एक्सेल चार्ट बनाएं और उसे Aspose.Slides के साथ PowerPoint प्रस्तुति में एम्बेड करें, जिसमें चार्ट का प्रीव्यू शामिल हो।"
---
## **परिचय**

यह लेख दिखाता है कि कैसे Aspose.Cells for Node.js via Java का उपयोग करके Excel कॉलम चार्ट बनाएं और Aspose.Slides for Node.js via Java के साथ उसके वर्कबुक को PowerPoint प्रस्तुति में एम्बेड करें। एम्बेड किया गया वर्कबुक स्रोत डेटा और चार्ट दोनों को शामिल करता है। एक अलग PNG प्रीव्यू स्लाइड पर चार्ट दिखाता है इससे पहले कि OLE ऑब्जेक्ट सक्रिय हो।

परिणाम एक एम्बेडेड Excel ऑब्जेक्ट है, न कि एक मूल PowerPoint चार्ट। OLE के माध्यम से वर्कबुक को संपादित करने के लिए एक डेस्कटॉप एप्लिकेशन चाहिए जो OLE सक्रियण का समर्थन करता हो और एक संगत Excel इंस्टॉलेशन हो।

## **आवश्यकताएँ**

Node.js पैकेज `aspose.cells`, `aspose.slides.via.java`, और `java` स्थापित करें। उदाहरणों को दो CommonJS स्क्रिप्ट के रूप में अलग-अलग Node.js प्रक्रियाओं में चलाएँ: पहले `create-chart.js`, फिर `embed-chart.js`, और समान कार्य निर्देशिका का उपयोग करें। दोनों Aspose पैकेज लोड होते समय Java ब्रिज को प्रारम्भ करते हैं, इसलिए ये उदाहरण उन्हें अलग प्रक्रियाओं में रखते हैं। Microsoft Office की आवश्यकता नहीं है इन लाइब्रेरीज़ के साथ प्रस्तुति बनाने के लिए।

कोई मौजूदा वर्कबुक या छवि आवश्यक नहीं है। पहला स्क्रिप्ट `ChartWorkbook.xlsx` और `ChartPreview.png` बनाता है; दूसरा उन फ़ाइलों को पढ़ता है और `OutputChart.pptx` को वर्तमान कार्य निर्देशिका में लिखता है। मूल्यांकन मोड के बाहर चलाते समय दोनों उत्पादों के लिए लाइसेंस लागू करें।

## **एम्बेडिंग कैसे काम करता है**

1. डेटा वर्कशीट और चार्ट शीट के साथ एक वर्कबुक बनाएं।
1. चार्ट शीट को सक्रिय करें ताकि वर्कबुक चार्ट पर खुले।
1. वर्कबुक की OLE डिस्प्ले रेंज सेट करें और चार्ट को PNG में रेंडर करें।
1. वर्कबुक को XLSX के रूप में सहेजें और इसके बाइट्स को अलग Node.js प्रक्रिया में एक स्लाइड में एम्बेड करें।
1. PNG को OLE ऑब्जेक्ट का प्रीव्यू असाइन करें और प्रस्तुति को PPTX के रूप में सहेजें।

वर्कबुक डिस्प्ले रेंज और स्लाइड पर फ़्रेम की अलग-अलग भूमिकाएँ हैं। [setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) शून्य-आधारित प्रारंभ/समाप्ति पंक्तियों और स्तंभ सूचकांक लेता है। इसके बजाय [ChartCollection.add](https://reference.aspose.com/cells/nodejs/aspose.cells/chartcollection/#add) शीर्ष पंक्ति, बाएँ स्तंभ, निचली पंक्ति और दाएँ स्तंभ लेता है। इस उदाहरण में पंक्ति सूचकांक 55 और स्तंभ सूचकांक 25 को निचले-दाएँ सीमाओं के रूप में उपयोग किया गया है; ये मान लेआउट विकल्प हैं, डेटा पंक्तियों या स्तंभों की संख्या नहीं।

स्लाइड फ्रेम पॉइंट्स में मापा जाता है। उदाहरण इसे स्लाइड के भीतर फिट करता है और केंद्रित करता है जबकि PNG का आस्पेक्ट रेशियो बरकरार रखता है, बजाय प्रीव्यू को स्लाइड भरने के लिए खींचे।

## **चार्ट बनाना और एम्बेड करना**

पहले उदाहरण को `create-chart.js` के रूप में सहेजें। यह `DataSheet` को चार पंक्तियों और पाँच स्तंभों के मानों से भरता है। प्रत्येक पंक्ति एक चार्ट सीरीज़ बन जाती है। `ChartSheet` को वर्कबुक सहेजने से पहले सक्रिय शीट के रूप में चुना जाता है।

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("DataSheet");

    const values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];

    for (let row = 0; row < values.length; row++) {
        for (let column = 0; column < values[row].length; column++) {
            dataSheet.getCells().get(row, column).putValue(values[row][column]);
        }
    }

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    chartSheet.setName("ChartSheet");

    const lastChartRow = 55;
    const lastChartColumn = 25;
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
    const chart = chartSheet.getCharts().get(chartIndex);
    for (let row = 1; row <= values.length; row++) {
        chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
    }

    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

    // चार्ट प्रीव्यू को रेंडर करें और संपादन योग्य वर्कबुक को अलग से सीरियलाइज़ करें।
    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    chart.toImage("ChartPreview.png", imageOptions);
    workbook.save("ChartWorkbook.xlsx", cells.SaveFormat.XLSX);
} finally {
    workbook.dispose();
}

// सभी सिंक्रोनस कार्य पूर्ण हो गए हैं; Java ब्रिज प्रक्रिया को रोकें।
process.exit(0);
```

निम्नलिखित उदाहरण को `embed-chart.js` के रूप में सहेजें। इसे `create-chart.js` द्वारा दोनों इनपुट फ़ाइलें बनाने के बाद चलाएँ। यह OLE फ्रेम को केंद्रित करता है और प्रीव्यू छवि का आस्पेक्ट रेशियो बरकरार रखता है।

दूसरा स्क्रिप्ट सहेजे गए वर्कबुक को एम्बेड करता है और PNG को उसका प्रीव्यू के रूप में उपयोग करता है। वर्कबुक स्पष्ट रूप से XLSX के रूप में सहेजा जाता है, जो `xlsx` एक्सटेंशन से मेल खाता है जो [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleembeddeddatainfo/) को पास किया जाता है। PNG को उसके बाइट्स से सीधे लोड किया जाता है बिना किसी मध्यवर्ती बिटमैप रूपांतरण के। Java ब्रिज को छवि और वर्कबुक डेटा के लिए स्पष्ट Java बाइट ऐरे और स्लाइड फ्रेम कोऑर्डिनेट्स के लिए Java फ़्लोट मान चाहिए। इसे [getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) के माध्यम से असाइन करने से डिफ़ॉल्ट OLE प्लेसहोल्डर बदल जाता है।

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const chartImageBuffer = fs.readFileSync("ChartPreview.png");
const chartImageBytes = java.newArray("byte", Array.from(chartImageBuffer));
const workbookBuffer = fs.readFileSync("ChartWorkbook.xlsx");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const chartImage = slides.Images.fromData(chartImageBytes);
try {
    const presentation = new slides.Presentation();
    try {
        const slide = presentation.getSlides().get_Item(0);
        const slideWidth = presentation.getSlideSize().getSize().getWidth();
        const slideHeight = presentation.getSlideSize().getSize().getHeight();

        // प्रीव्यू को स्लाइड के भीतर फिट करें बिना इसके आस्पेक्ट रेशियो को बदले।
        const scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
        const frameWidth = (chartImage.getWidth() * scale);
        const frameHeight = (chartImage.getHeight() * scale);
        const frameX = ((slideWidth - frameWidth) / 2);
        const frameY = ((slideHeight - frameHeight) / 2);

        const embeddedData = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
        const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(frameX), java.newFloat(frameY), java.newFloat(frameWidth), java.newFloat(frameHeight), embeddedData);
        const previewImage = presentation.getImages().addImage(chartImage);
        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

        presentation.save("OutputChart.pptx", slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    chartImage.dispose();
}

// सभी सिंक्रोनस कार्य पूर्ण हो गए हैं; Java ब्रिज प्रक्रिया को रोकें।
process.exit(0);
```

## **अपेक्षित परिणाम**

`OutputChart.pptx` में एक स्लाइड है जिसमें एम्बेडेड Excel वर्कबुक और एक चार्ट प्रीव्यू है। वर्कबुक में मूल डेटा और चार सीरीज़ वाला कॉलम चार्ट होता है। प्रीव्यू स्लाइड पर केंद्रित है और अपने अनुपात को बरकरार रखता है।

![एम्बेडेड वर्कबुक के प्रीव्यू के रूप में दिखाया गया Excel कॉलम चार्ट](excel-chart-ole-preview.png)

यदि संगत डेस्कटॉप PowerPoint वातावरण में Excel उपलब्ध है, तो ऑब्जेक्ट को डबल-क्लिक करके एम्बेडेड वर्कबुक को सक्रिय और संपादित किया जा सकता है। सक्रियण और संपादन होस्ट एप्लिकेशन के OLE समर्थन और सुरक्षा सेटिंग्स पर निर्भर करता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**प्रिव्यू छवि की आवश्यकता क्यों है?**

एम्बेडेड वर्कबुक और उसकी स्लाइड प्रीव्यू अलग सामग्री हैं। एक चार्ट छवि प्रदान करें ताकि स्लाइड में डिफ़ॉल्ट "EMBEDDED OLE OBJECT" प्लेसहोल्डर के बजाय चार्ट दिखे। देखें [OleObjectFrame जोड़ते समय ऑब्जेक्ट प्रीव्यू समस्या](/slides/hi/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)।

**क्या कोड में वर्कबुक बदलने पर प्रीव्यू अपने आप अपडेट हो जाता है?**

प्रीव्यू को एक स्नैपशॉट मानें। जब प्रोग्रामेटिकली वर्कबुक डेटा को अपडेट किया जाता है, तो चार्ट छवि को पुनः उत्पन्न करें और प्रीव्यू को साथ ही एम्बेडेड वर्कबुक डेटा को बदलें।

**क्या मैं XLS के बजाय XLSX का उपयोग कर सकता हूँ?**

हां। वर्कबुक को XLS प्रारूप में सहेजें और एम्बेडेड डेटा एक्सटेंशन के रूप में `xls` का उपयोग करें। एक्सटेंशन वास्तविक वर्कबुक फ़ॉर्मेट से मेल खाना चाहिए; केवल एक्सटेंशन बदलने से डेटा नहीं बदलता।

**सक्रियण के बाद ऑब्जेक्ट आकार क्यों बदल सकता है?**

होस्ट एप्लिकेशन वर्कबुक को सक्रिय करने पर OLE ऑब्जेक्ट की प्रस्तुति को अपडेट कर सकता है। वर्कबुक की OLE डिस्प्ले रेंज और स्लाइड फ्रेम के आयाम दोनों महत्वपूर्ण हैं। देखें [PPTX में चार्ट रिसाइज़िंग के लिए कार्य समाधान](/slides/hi/java/working-solution-for-chart-resizing-in-pptx/)।

## **संबंधित अनुभाग**

- [PPTX में चार्ट रिसाइज़िंग के लिए कार्य समाधान](/slides/hi/java/working-solution-for-chart-resizing-in-pptx/)
- [OleObjectFrame जोड़ते समय ऑब्जेक्ट प्रीव्यू समस्या](/slides/hi/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)