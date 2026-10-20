---
title: PPTX में चार्ट रिसाइज़िंग के लिए कार्यात्मक समाधान
type: docs
weight: 40
url: /hi/php-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- चार्ट आकार परिवर्तन
- Excel चार्ट
- OLE ऑब्जेक्ट
- चार्ट एम्बेड करें
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ एम्बेडेड Excel OLE ऑब्जेक्ट्स का उपयोग करने पर PPTX में अप्रत्याशित चार्ट रिसाइज़िंग को सुधारें। स्थिर चार्ट आयाम सेट करें ताकि चार्ट और OLE फ्रेम के आकार निरंतर रहें।"
---
## **अवलोकन**

Aspose घटकों का उपयोग करके PowerPoint प्रस्तुति में OLE ऑब्जेक्ट के रूप में एम्बेड किए गए Excel चार्ट पहली बार सक्रिय होने के बाद आकार बदल सकते हैं। इससे सक्रियण से पहले और बाद में चार्ट के दिखावे में स्पष्ट अंतर हो सकता है। यह लेख बताता है कि आकार परिवर्तन क्यों होता है और OLE फ्रेम के साथ स्थिर चार्ट आयामों को मिलाकर इसे कैसे रोका जा सकता है।

[Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/hi/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) में हमने बताया था कि Aspose.Cells for PHP via Java से Excel चार्ट कैसे बनायें और Aspose.Slides for PHP via Java से उसे PowerPoint प्रस्तुति में OLE ऑब्जेक्ट के रूप में एम्बेड करें। [object preview issue](/slides/hi/php-java/object-preview-issue-when-adding-oleobjectframe/) को हल करने के लिए हमने चार्ट छवि को चार्ट के OLE ऑब्जेक्ट फ्रेम से जोड़ा। आउटपुट प्रस्तुति में जब आप चार्ट छवि दिखाने वाले OLE ऑब्जेक्ट फ्रेम पर डबल‑क्लिक करते हैं, तो Excel चार्ट सक्रिय हो जाता है। उपयोगकर्ता एम्बेड किए गए Excel वर्कबुक को संपादित कर सकते हैं और फिर सक्रिय वर्कबुक के बाहर क्लिक करके स्लाइड पर वापस आ सकते हैं। उपयोगकर्ता के स्लाइड पर वापस लौटने पर OLE ऑब्जेक्ट फ्रेम का आकार बदल जाता है, और पुन: आकार का मान OLE ऑब्जेक्ट फ्रेम और एम्बेड किए गए Excel वर्कबुक दोनों के मूल आकारों पर निर्भर करता है।

## **आकार बदलने का कारण**

एम्बेड किया गया Excel वर्कबुक अपनी स्वयं की विंडो आयाम रखता है, जिसे Excel पहली बार सक्रिय होने पर बनाए रखने की कोशिश करता है। स्लाइड पर OLE फ्रेम का आयाम स्वतंत्र रूप से परिभाषित होता है। जब Excel वर्कबुक सक्रिय होता है, तो Excel और PowerPoint ऑब्जेक्ट के आकार को समायोजित करने के लिए परस्पर संवाद करते हैं ताकि एम्बेडिंग प्रक्रिया के भाग के रूप में इसका अनुपात बना रहे। वर्कबुक विंडो और OLE फ्रेम के बीच अंतर के कारण ऑब्जेक्ट का आकार बदल सकता है।

## **कार्यक्षम समाधान**

चार्ट का आकार स्लाइड पर OLE फ्रेम के साथ मिलाएं और चार्ट आयामों को वर्कबुक विंडो से स्वतंत्र रखें। यह समाधान नई प्रस्तुति या मौजूदा टेम्पलेट दोनों के साथ काम करता है।

उदाहरण को Aspose.Cells for PHP via Java और Aspose.Slides for PHP via Java की आवश्यकता है। दोनों उत्पादों को समान PHP/Java Bridge इंस्टेंस के साथ कॉन्फ़िगर करें, दोनों PHP रैपर लोड करें, और दोनों Java लाइब्रेरी को ब्रिज के लिए उपलब्ध कराएँ। कोई इनपुट फाइल आवश्यक नहीं है। यह सक्रिय चार्ट शीट पर एक सरल कॉलम चार्ट बनाता है और वर्कबुक को XLS फ़ॉर्मेट में एम्बेड करता है। कोई चार्ट प्रीव्यू छवि नहीं सौंपी गई; जब PowerPoint में OLE ऑब्जेक्ट सक्रिय किया जाता है तो चार्ट दिखता है।

उदाहरण 9.5 × 4‑इंच OLE फ्रेम के साथ नई प्रस्तुति बनाता है, जिसका बायाँ किनारा से 0.5 इंच और शीर्ष से 1 इंच दूरी पर स्थित है। स्लाइड के निर्देशांक और आयाम पॉइंट में हैं (प्रति इंच 72 पॉइंट)। मौजूदा प्रस्तुति के लिए, देखें [Use a Template](#use-a-template)।

## **स्थिर चार्ट आकार निर्धारित करें**

[Chart::setSizeWithWindow](https://reference.aspose.com/cells/php/aspose.cells/chart/#sizewithwindow) को false सेट करें ताकि चार्ट आयाम वर्कबुक विंडो से स्वतंत्र रहें। [Chart::getChartObject](https://reference.aspose.com/cells/php/aspose.cells/chart/#chartobject) के आयामों को [Shape::setWidth](https://reference.aspose.com/cells/php/aspose.cells/shape/#width) और [Shape::setHeight](https://reference.aspose.com/cells/php/aspose.cells/shape/#height) के माध्यम से सेट करें, पॉइंट को 96 पिक्सेल प्रति इंच के आधार पर पिक्सेल में बदलें: 684 × 288 पॉइंट का फ्रेम 912 × 384 पिक्सेल के चार्ट के बराबर है। [Chart::setPrintSize](https://reference.aspose.com/cells/php/aspose.cells/chart/#printsize) को [PrintSizeType](https://reference.aspose.com/cells/php/aspose.cells/printsizetype/) के CUSTOM मान पर सेट करें। उदाहरण [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) से वर्कबुक को एम्बेड करता है और 9.5 × 4‑इंच OLE फ्रेम के साथ प्रस्तुति सहेजता है।

Java संख्यात्मक परिणामों को `java_values` के साथ परिवर्तित किया जाता है इससे पहले कि वे PHP सूचकांक के रूप में उपयोग हों। वर्कबुक बाइट्स को Java बाइट एरे में रखा जाता है जब उन्हें [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) को पास किया जाता है।

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\FileFormatType;
use aspose\cells\PrintSizeType;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("Data");
    $dataSheet->getCells()->get("A1")->putValue(10);
    $dataSheet->getCells()->get("A2")->putValue(20);

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, 20, 10));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    $chart->getNSeries()->add("Data!A1:A2", true);
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);

    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // स्लाइड के निर्देशांक और आयाम पॉइंट में हैं (प्रति इंच 72 पॉइंट)।
        $width = 684; // 9.5 इंच।
        $height = 288; // 4 इंच।

        $chart->setSizeWithWindow(false);
        // पॉइंट को चार्ट पिक्सेल में बदलें, 96 पिक्सेल प्रति इंच का उपयोग करके।
        $chart->getChartObject()->setWidth((int)($width / 72 * 96));
        $chart->getChartObject()->setHeight((int)($height / 72 * 96));
        $chart->setPrintSize(PrintSizeType::CUSTOM);

        $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
        $workbook->save($workbookStream, FileFormatType::EXCEL_97_TO_2003);
        $workbookBytes = $workbookStream->toByteArray();
        $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xls");
        $slide->getShapes()->addOleObjectFrame(36, 72, $width, $height, $dataInfo);

        $presentation->save("chart-fixed-size.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **टेम्पलेट का उपयोग करें**

आकार निर्धारण तर्क मौजूदा प्रस्तुति के लिए भी समान है। उदाहरण को अनुकूलित करने के लिए:

1. खाली प्रस्तुति बनाने के बजाय टेम्पलेट प्रस्तुति लोड करें।  
2. सुनिश्चित करें कि पहले स्लाइड में कम से कम तीन शैप हैं, फिर इंडेक्स 2 वाले शैप को प्लेसहोल्डर के रूप में उपयोग करें।  
3. बिना स्थिर मान 684 और 288 के, उस शैप से फ्रेम की चौड़ाई और ऊँचाई लें। आकार गणनाएँ अपरिवर्तित रखें।  
4. स्थिर निर्देशांक 36 और 72 के बजाय प्लेसहोल्डर की स्थिति पर OLE फ्रेम जोड़ें।  
5. प्रस्तुति सहेजने से पहले प्लेसहोल्डर को हटा दें।

## **अक्सर पूछे जाने वाले प्रश्न**

**मेरे एम्बेड किए गए Excel चार्ट को PowerPoint में सक्रिय करने के बाद आकार क्यों बदलता है?**  
यह इसलिए होता है क्योंकि Excel पहली बार सक्रिय होने पर मूल विंडो आकार को पुनः स्थापित करने की कोशिश करता है, जबकि PowerPoint में OLE ऑब्जेक्ट फ्रेम का अपना आयाम होता है। PowerPoint और Excel आकार को समायोजित करने के लिए बातचीत करते हैं, जिससे आयाम बदल सकते हैं।

**मैं चार्ट और OLE फ्रेम के आकार को कैसे समान रख सकता हूँ?**  
स्थिर चार्ट आयाम सेट करें जो OLE फ्रेम से मेल खाते हों और वर्कबुक एम्बेड करने से पहले कस्टम चार्ट प्रिंट आकार का उपयोग करें। ऊपर दिया गया उदाहरण आवश्यक सेटिंग्स और इकाई रूपांतरण दर्शाता है।

**क्या केवल वर्कबुक विंडो के आकार को मिलाना पर्याप्त है?**  
केवल वर्कबुक विंडो के आकार को मिलाना OLE फ्रेम के सक्रियण के बाद आकार बदलने को विश्वसनीय रूप से रोकता नहीं है। उदाहरण में दिखाए अनुसार स्थिर चार्ट आयाम उपयोग करें।

**क्या यह समाधान टेम्पलेट‑आधारित और नई प्रस्तुतियों दोनों में काम करता है?**  
हां। टेम्पलेट के लिए प्लेसहोल्डर के आयाम और स्थिति का उपयोग करें। नई प्रस्तुति के लिए फ्रेम के आयाम और स्थिति सीधे निर्दिष्ट करें।

**क्या मैं इस उदाहरण को अन्य स्प्रेडशीट प्रोग्राम में बनाए गए चार्ट के साथ उपयोग कर सकता हूँ?**  
उदाहरण Aspose.Cells से निर्मित Excel वर्कबुक का उपयोग करता है। यह अन्य स्प्रेडशीट प्रोग्राम के सक्रियण व्यवहार को दर्शाता नहीं है।

## **संबंधित अनुभाग**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/hi/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)