---
title: Excel चार्ट बनाएं और उन्हें प्रस्तुतियों में OLE ऑब्जेक्ट के रूप में एम्बेड करें
type: docs
weight: 30
url: /hi/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel चार्ट
- चार्ट एम्बेड करें
- OLE ऑब्जेक्ट
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Cells for PHP via Java का उपयोग करके Excel चार्ट बनाएं और इसे Aspose.Slides for PHP via Java के साथ PowerPoint प्रस्तुति में एम्बेड करें, जिसमें चार्ट प्रीव्यू शामिल है।"
---
## **सारांश**

यह लेख दर्शाता है कि Aspose.Cells for PHP via Java के साथ Excel कॉलम चार्ट कैसे बनाएं और Aspose.Slides for PHP via Java के साथ उसके वर्कबुक को PowerPoint प्रस्तुति में एम्बेड करें। एम्बेड किया गया वर्कबुक स्रोत डेटा और चार्ट दोनों को शामिल करता है। एक अलग PNG प्रीव्यू स्लाइड पर चार्ट को OLE ऑब्जेक्ट सक्रिय होने से पहले प्रदर्शित करता है।

परिणाम एक एम्बेडेड Excel ऑब्जेक्ट है, मूल PowerPoint चार्ट नहीं। OLE के माध्यम से वर्कबुक को संपादित करने के लिए एक डेस्कटॉप एप्लिकेशन की आवश्यकता होती है जो OLE सक्रियण का समर्थन करता हो और साथ ही संगत Excel इंस्टॉलेशन हो।

## **पूर्वापेक्षाएँ**

Aspose.Cells for PHP via Java और Aspose.Slides for PHP via Java को एक ही PHP/Java Bridge इंस्टेंस के साथ कॉन्फ़िगर करें। दोनों PHP रैपर लोड करें और दोनों उत्पादों की Java लाइब्रेरीज़ को ब्रिज के लिए उपलब्ध कराएँ। इन लाइब्रेरियों के साथ प्रस्तुति बनाने के लिए Microsoft Office की आवश्यकता नहीं है।

कोई इनपुट फ़ाइल आवश्यक नहीं है: उदाहरण डेटा और चार्ट को मेमोरी में बनाता है, फिर `OutputChart.pptx` को वर्तमान कार्य निर्देशिका में लिखता है। मूल्यांकन मोड के बाहर चलाते समय दोनों उत्पादों के लिए लाइसेंस लागू करें।

## **इन्बेडिंग कैसे काम करती है**

1. डेटा वर्कशीट और एक चार्ट शीट के साथ एक वर्कबुक बनाएं।
1. चार्ट शीट को सक्रिय करें ताकि वर्कबुक चार्ट पर खुले।
1. वर्कबुक की OLE डिस्प्ले रेंज सेट करें और चार्ट को PNG में रेंडर करें।
1. वर्कबुक को मेमोरी में XLSX के रूप में सहेजें और उन बाइट्स को स्लाइड में एम्बेड करें।
1. PNG को OLE ऑब्जेक्ट के प्रीव्यू के रूप में असाइन करें और प्रस्तुति को PPTX के रूप में सहेजें।

वर्कबुक डिस्प्ले रेंज और स्लाइड पर फ्रेम की अलग-अलग भूमिकाएँ होती हैं। [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) शून्य-आधारित प्रारम्भ/समाप्ति पंक्ति और स्तम्भ इंडेक्स लेता है। [ChartCollection::add](https://reference.aspose.com/cells/php/aspose.cells/chartcollection/#add) इसके बजाय शीर्ष पंक्ति, बायां स्तम्भ, नीचे की पंक्ति, और दायाँ स्तम्भ लेता है। उदाहरण पंक्ति इंडेक्स 55 और स्तम्भ इंडेक्स 25 को निचले-दाएँ सीमा के रूप में उपयोग करता है; ये मान लेआउट विकल्प हैं, डेटा पंक्तियों या स्तम्भों की संख्या नहीं।

स्लाइड फ्रेम पॉइंट्स में मापी जाती है। उदाहरण इसे स्लाइड के भीतर फिट करता है और केंद्रित करता है जबकि PNG के अनुपात को बनाए रखता है, बजाय इसके कि प्रीव्यू को स्लाइड भरने के लिए खींचा जाए।

## **चार्ट बनाएं और एम्बेड करें**

निम्नलिखित पूर्ण उदाहरण `DataSheet` में चार पंक्तियों और पाँच स्तम्भों के मान भरता है। प्रत्येक पंक्ति एक चार्ट सीरीज़ बनती है। `ChartSheet` को वर्कबुक सहेजे जाने से पहले सक्रिय शीट के रूप में चुना जाता है।

वर्कबुक को स्पष्ट रूप से XLSX के रूप में सहेजा जाता है, जो `xlsx` एक्सटेंशन के साथ मेल खाता है जिसे [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) को पास किया गया है। Java संख्यात्मक परिणाम PHP के गणित करने से पहले `java_values` के साथ परिवर्तित किए जाते हैं, जबकि बाइनरी डेटा Java बाइट ऐरे में रहता है। PNG को उसके बाइट्स से सीधे लोड किया जाता है बिना किसी मध्यवर्ती बिटमैप रूपांतरण के। इसे [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) के माध्यम से असाइन करने से डिफ़ॉल्ट OLE प्लेसहोल्डर बदल जाता है।

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("DataSheet");
    $values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];
    foreach ($values as $row => $rowValues) {
        foreach ($rowValues as $column => $value) {
            $dataSheet->getCells()->get($row, $column)->putValue($value);
        }
    }

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartSheet->setName("ChartSheet");
    $lastChartRow = 55;
    $lastChartColumn = 25;
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, $lastChartRow, $lastChartColumn));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    for ($row = 1; $row <= count($values); $row++) {
        $chart->getNSeries()->add("DataSheet!A" . $row . ":E" . $row, false);
    }
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);
    $workbook->getWorksheets()->setOleSize(0, $lastChartRow, 0, $lastChartColumn);

    // Slides को पास करते समय PNG और XLSX को Java बाइट एरे के रूप में रखें।
    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $chartImageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $chart->toImage($chartImageStream, $imageOptions);
    $chartImageBytes = $chartImageStream->toByteArray();

    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();

    $chartImage = Images::fromData($chartImageBytes);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $slideWidth = java_values($presentation->getSlideSize()->getSize()->getWidth());
            $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
            $imageWidth = java_values($chartImage->getWidth());
            $imageHeight = java_values($chartImage->getHeight());

            // प्रीव्यू को फिट करें और केंद्रित करें जबकि इसका अनुपात बनाए रखें।
            $scale = min($slideWidth / $imageWidth, $slideHeight / $imageHeight);
            $frameWidth = $imageWidth * $scale;
            $frameHeight = $imageHeight * $scale;
            $frameX = ($slideWidth - $frameWidth) / 2;
            $frameY = ($slideHeight - $frameHeight) / 2;

            $embeddedData = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame($frameX, $frameY, $frameWidth, $frameHeight, $embeddedData);
            $previewImage = $presentation->getImages()->addImage($chartImage);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $presentation->save("OutputChart.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $chartImage->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **अपेक्षित परिणाम**

`OutputChart.pptx` में एक स्लाइड होती है जिसमें एम्बेडेड Excel वर्कबुक और चार्ट प्रीव्यू शामिल है। वर्कबुक में मूल डेटा और चार श्रृंखलाओं वाला कॉलम चार्ट होता है। प्रीव्यू स्लाइड के केंद्र में स्थित है और अपने अनुपात को बनाए रखता है।

![एम्बेडेड वर्कबुक के प्रीव्यू के रूप में प्रदर्शित Excel कॉलम चार्ट](excel-chart-ole-preview.png)

एक संगत डेस्कटॉप PowerPoint वातावरण जिसमें Excel उपलब्ध हो, ऑब्जेक्ट को डबल-क्लिक करके एम्बेडेड वर्कबुक को सक्रिय और संपादित किया जा सकता है। सक्रियकरण और संपादन होस्ट एप्लिकेशन की OLE समर्थन और सुरक्षा सेटिंग्स पर निर्भर करता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**प्रीव्यू इमेज की आवश्यकता क्यों है?**

एम्बेडेड वर्कबुक और उसका स्लाइड प्रीव्यू अलग सामग्री हैं। एक चार्ट इमेज प्रदान करें जिससे स्लाइड डिफ़ॉल्ट "EMBEDDED OLE OBJECT" प्लेसहोल्डर के बजाय चार्ट दिखाए। देखें [OleObjectFrame जोड़ते समय ऑब्जेक्ट प्रीव्यू समस्या](/slides/hi/php-java/object-preview-issue-when-adding-oleobjectframe/)।

**क्या कोड में वर्कबुक बदलने पर प्रीव्यू स्वचालित रूप से अपडेट होता है?**

प्रीव्यू को एक स्नैपशॉट मानें। जब प्रोग्रामेटिक रूप से वर्कबुक डेटा को अपडेट किया जाता है, तो चार्ट इमेज को पुनः उत्पन्न करें और प्रीव्यू के साथ-साथ एम्बेडेड वर्कबुक डेटा को भी बदल दें।

**क्या मैं XLS को XLSX के बजाय उपयोग कर सकता हूँ?**

हाँ। वर्कबुक को XLS फ़ॉर्मेट में सहेजें और एम्बेडेड डेटा एक्सटेंशन के रूप में `xls` उपयोग करें। एक्सटेंशन को वास्तविक वर्कबुक फ़ॉर्मेट से मेल खाना चाहिए; केवल एक्सटेंशन बदलने से डेटा नहीं बदलता।

**सक्रियकरण के बाद ऑब्जेक्ट आकार क्यों बदल सकता है?**

होस्ट एप्लिकेशन वर्कबुक को सक्रिय करने पर OLE ऑब्जेक्ट की प्रस्तुति को अपडेट कर सकता है। वर्कबुक की OLE डिस्प्ले रेंज और स्लाइड फ्रेम आयाम दोनों महत्वपूर्ण हैं। देखें [PPTX में चार्ट आकार बदलने के लिए कार्य समाधान](/slides/hi/java/working-solution-for-chart-resizing-in-pptx/)।

## **संबंधित अनुभाग**

- [PPTX में चार्ट आकार बदलने के लिए कार्य समाधान](/slides/hi/java/working-solution-for-chart-resizing-in-pptx/)
- [OleObjectFrame जोड़ते समय ऑब्जेक्ट प्रीव्यू समस्या](/slides/hi/php-java/object-preview-issue-when-adding-oleobjectframe/)
- [OLE ऑब्जेक्ट्स प्रबंधित करें](/slides/hi/php-java/manage-ole/)