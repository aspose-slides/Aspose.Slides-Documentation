---
title: वर्कशीट रिसाइज़िंग के लिए कार्य समाधान
type: docs
weight: 20
url: /hi/php-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- प्रीव्यू छवि
- छवि रिसाइज़िंग
- Excel
- वर्कशीट
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "प्रस्तुति में Excel वर्कशीट OLE रिसाइज़िंग को ठीक करें: ऑब्जेक्ट फ्रेम को संगत रखने के दो तरीके—फ्रेम या शीट को स्केल करें—PPT और PPTX फॉर्मैट्स में।"
---
{{% alert color="info" title="Note" %}}
Aspose घटकों का उपयोग करके PowerPoint प्रस्तुति में OLE वस्तुओं के रूप में एम्बेड की गई Excel वर्कशीट्स पहले सक्रिय होने के बाद अप्रत्याशित रूप से आकार बदल सकती हैं। यह व्यवहार OLE वस्तु के सक्रिय होने से पहले और बाद में एक स्पष्ट दृश्य अंतर उत्पन्न करता है। यह लेख समस्या को समझाता है और इसे हल करने के दो तरीकों का विवरण देता है।  
{{% /alert %}}

## **पृष्ठभूमि**

लेख [Manage OLE](/slides/hi/php-java/manage-ole/) में, हमने बताया कि Aspose.Slides for PHP via Java का उपयोग करके PowerPoint प्रस्तुति में OLE फ्रेम कैसे जोड़ें। [object preview issue](/slides/hi/php-java/object-preview-issue-when-adding-oleobjectframe/) को संबोधित करने के लिए, हमने चयनित वर्कशीट क्षेत्र की छवि को OLE वस्तु फ्रेम को सौंपा। आउटपुट प्रस्तुति में, जब आप वर्कशीट छवि दिखाने वाले OLE वस्तु फ्रेम पर दो बार क्लिक करते हैं, तो Excel वर्कबुक सक्रिय हो जाती है। अंतिम उपयोगकर्ता वास्तविक Excel वर्कबुक में इच्छित बदलाव कर सकते हैं और फिर सक्रिय Excel वर्कबुक के बाहर क्लिक करके स्लाइड पर लौट सकते हैं। उपयोगकर्ता के स्लाइड पर लौटने पर OLE वस्तु फ्रेम का आकार बदल जाएगा। रिसाइज़िंग फैक्टर OLE वस्तु फ्रेम और एम्बेडेड Excel वर्कबुक के आकार पर निर्भर करेगा।

## **आकार बदलने का कारण**

क्योंकि Excel वर्कबुक का अपना विंडो आकार होता है, यह पहली सक्रियता पर अपने मूल आकार को बनाए रखने का प्रयास करता है। दूसरी ओर, OLE वस्तु फ्रेम का अपना आकार होता है। Microsoft के अनुसार, जब Excel वर्कबुक सक्रिय होती है, तो Excel और PowerPoint आकार पर बातचीत करते हैं ताकि एम्बेडिंग प्रक्रिया के हिस्से के रूप में सही अनुपात बनाए रखे जा सकें। रिसाइज़िंग Excel विंडो आकार और OLE वस्तु फ्रेम के आकार और स्थिति के अंतर के आधार पर होती है।

## **कार्यान्वित समाधान**

रिसाइज़िंग प्रभाव से बचने के दो संभावित समाधान हैं।

- PowerPoint प्रस्तुति में OLE फ्रेम को चयनित पंक्तियों और स्तंभों की कुल ऊँचाई और चौड़ाई के अनुसार स्केल करें।
- OLE फ्रेम का आकार स्थिर रखें और चयनित पंक्तियों और स्तंभों को उसके भीतर फिट करने के लिए स्केल करें।

### **OLE फ्रेम आकार को स्केल करें**

यह विधि एम्बेडेड Excel वर्कशीट में चयनित पंक्तियों और स्तंभों की कुल ऊँचाई और चौड़ाई के अनुसार OLE फ्रेम का आकार सेट करती है।

उदाहरण एक मौजूदा Excel वर्कबुक को लोड करता है और शून्य-आधारित इंडेक्स का उपयोग करके उसकी पहली वर्कशीट से पहली 10 पंक्तियों और 13 स्तंभों को चुनता है। [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) प्रदर्शित रेंज को परिभाषित करता है। प्रीव्यू 96 DPI पर रेंडर किया जाता है, और उसके पिक्सेल आयामों को इंच प्रति 72 पॉइंट्स की दर से पॉइंट्स में बदला जाता है। [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) संशोधित वर्कबुक को उन आयामों वाले फ्रेम में एम्बेड करता है। प्रीव्यू को [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) के माध्यम से असाइन किया जाता है ताकि सहेजे गए प्रस्तुति में "EMBEDDED OLE OBJECT" प्लेसहोल्डर को बदला जा सके।  

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // संशोधित वर्कबुक को एम्बेड करें और जावा बाइट एरे में बाइनरी डेटा रखें।
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $frameWidth = java_values($image->getWidth()) * 72.0 / $imageResolution;
        $frameHeight = java_values($image->getHeight()) * 72.0 / $imageResolution;
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

प्रीव्यू हेल्पर चयनित रेंज को सेट करने के लिए [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) का उपयोग करता है और मार्जिन, हेडर, तथा फुटर को हटा देता है। जब [ImageOrPrintOptions::setOnlyArea](https://reference.aspose.com/cells/php/aspose.cells/imageorprintoptions/#onlyarea) सक्षम हो, तो [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage) रेंज को PNG छवि के रूप में रेंडर करता है। हेल्पर एक नया इनपुट स्ट्रीम लौटाता है जिसमें PNG छवि होती है, जिसे प्रस्तुति में उपयोग के लिए उसकी शुरुआत में स्थित किया जाता है।  

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

### **सेल रेंज आकार को स्केल करें**

यह विधि चयनित पंक्तियों की ऊँचाइयों और चयनित स्तंभों की चौड़ाइयों को कस्टम OLE फ्रेम आकार से मेल करने के लिए स्केल करती है।

उदाहरण एक मौजूदा Excel वर्कबुक को लोड करता है और शून्य-आधारित इंडेक्स का उपयोग करके उसकी पहली वर्कशीट से पहली 10 पंक्तियों और 13 स्तंभों को चुनता है। [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) प्रदर्शित रेंज को परिभाषित करता है, और नीचे दिया गया हेल्पर उस रेंज को 400 पॉइंट चौड़ी और 100 पॉइंट ऊँची फ्रेम में फिट करने के लिए स्केल करता है। संशोधित वर्कबुक को एक स्ट्रीम में सहेजने के बाद, [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) इसे निर्दिष्ट आकार पर एम्बेड करता है। 96 DPI पर रेंडर किया गया प्रीव्यू [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) के माध्यम से असाइन किया जाता है, इसलिए सहेजी गई प्रस्तुति में डिफ़ॉल्ट प्लेसहोल्डर के बजाय चयनित सेल्स दिखते हैं।  

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);
    $frameWidth = 400;
    $frameHeight = 100;
    ScaleCellRange($cellRange, $frameWidth, $frameHeight);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // संशोधित वर्कबुक को एम्बेड करें और जावा बाइट एरे में बाइनरी डेटा रखें।
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

स्केलिंग हेल्पर चयनित रेंज के लिए अलग-अलग चौड़ाई और ऊँचाई अनुपात गणना करता है, जिससे उसके स्तंभों की सापेक्ष चौड़ाई और पंक्तियों की सापेक्ष ऊँचाई बनी रहती है। यह गणना किए गए आयामों को पॉइंट्स से इंच में बदलता है और फिर उन्हें [Cells::setColumnWidthInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setcolumnwidthinch) और [Cells::setRowHeightInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setrowheightinch) के साथ लागू करता है। चयनित रेंज का चौड़ाई और ऊँचाई शून्य नहीं होना चाहिए।  

```php
use aspose\cells\CellsUnitType;

// चौड़ाई और ऊँचाई सेल रेंज के पॉइंट में अपेक्षित आयाम हैं।
function ScaleCellRange($cellRange, $width, $height) {
    $rangeWidth = java_values($cellRange->getWidth());
    $rangeHeight = java_values($cellRange->getHeight());
    $cells = $cellRange->getWorksheet()->getCells();
    $columnCount = java_values($cellRange->getColumnCount());
    $rowCount = java_values($cellRange->getRowCount());
    $firstColumn = java_values($cellRange->getFirstColumn());
    $firstRow = java_values($cellRange->getFirstRow());

    for ($i = 0; $i < $columnCount; $i++) {
        $columnIndex = $firstColumn + $i;
        $columnWidth = java_values($cells->getColumnWidth($columnIndex, false, CellsUnitType::POINT));
        $newColumnWidth = $columnWidth * $width / $rangeWidth;
        $widthInInches = $newColumnWidth / 72.0;
        $cells->setColumnWidthInch($columnIndex, $widthInInches);
    }

    for ($i = 0; $i < $rowCount; $i++) {
        $rowIndex = $firstRow + $i;
        $rowHeight = java_values($cells->getRowHeight($rowIndex, false, CellsUnitType::POINT));
        $newRowHeight = $rowHeight * $height / $rangeHeight;
        $heightInInches = $newRowHeight / 72.0;
        $cells->setRowHeightInch($rowIndex, $heightInInches);
    }
}
```

यह प्रीव्यू हेल्पर स्केल्ड रेंज को [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage) का उपयोग करके रेंडर करता है। यह [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) को उस रेंज तक सीमित करता है, मार्जिन, हेडर और फुटर को हटाता है, और एक PNG स्ट्रीम लौटाता है जो उसकी शुरुआत में स्थित होती है।  

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

## **निष्कर्ष**

{{% alert color="info" title="Note" %}}
वर्कशीट रिसाइज़िंग समस्या को ठीक करने के दो तरीके हैं। अपनी आवश्यकताओं और उपयोग केस के अनुकूल सबसे उपयुक्त तरीका चुनें। दोनों तरीके समान रूप से कार्य करते हैं, चाहे प्रस्तुतियां टेम्पलेट से बनाई गई हों या शून्य से। अतिरिक्त रूप से, इस समाधान में OLE वस्तु फ्रेम के आकार पर कोई सीमा नहीं है।  
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**जब एक एम्बेडेड Excel वर्कशीट को PowerPoint में पहली बार सक्रिय किया जाता है तो उसका आकार क्यों बदलता है?**  
यह इसलिए होता है क्योंकि Excel सक्रिय होने पर मूल विंडो आकार को बनाए रखने की कोशिश करता है, जबकि PowerPoint में OLE वस्तु फ्रेम का अपना आयाम होता है। PowerPoint और Excel आकार पर बातचीत करते हैं ताकि अनुपात सही बना रहे, जिससे रिसाइज़िंग हो सकती है।  

**क्या इस रिसाइज़िंग समस्या को पूरी तरह रोकना संभव है?**  
हाँ। OLE फ्रेम को Excel सेल रेंज आकार के अनुसार स्केल करके या सेल रेंज को वांछित OLE फ्रेम आकार में फिट करने के लिए स्केल करके आप अनचाहे रिसाइज़िंग को रोक सकते हैं।  

**मुझे कौनसी स्केलिंग विधि उपयोग करनी चाहिए, OLE फ्रेम स्केलिंग या सेल रेंज स्केलिंग?**  
यदि आप मूल Excel पंक्तियों और स्तंभों के आकार को बनाए रखना चाहते हैं तो **OLE फ्रेम स्केलिंग** चुनें। यदि आप अपनी प्रस्तुति में OLE फ्रेम के लिए एक निश्चित आकार चाहते हैं तो **सेल रेंज स्केलिंग** चुनें।  

**क्या ये समाधान टेम्पलेट पर आधारित मेरी प्रस्तुति के लिए काम करेंगे?**  
हाँ। दोनों समाधान टेम्पलेट से बनाई गई प्रस्तुतियों और शून्य से बनाई गई प्रस्तुतियों दोनों के लिए काम करते हैं।  

**इन विधियों का उपयोग करने पर OLE फ्रेम के आकार पर कोई सीमा है क्या?**  
नहीं। आप OLE वस्तु फ्रेम को किसी भी आकार का बना सकते हैं, बशर्ते आप स्केल को उचित रूप से सेट करें।  

**PowerPoint में "EMBEDDED OLE OBJECT" प्लेसहोल्डर टेक्स्ट से बचने का कोई तरीका है क्या?**  
हाँ। लक्ष्य Excel सेल रेंज का स्नैपशॉट लेकर और उसे OLE फ्रेम के प्लेसहोल्डर इमेज के रूप में सेट करके आप डिफ़ॉल्ट प्लेसहोल्डर की जगह एक कस्टम प्रीव्यू इमेज प्रदर्शित कर सकते हैं।  

## **संबंधित लेख**

[Presentation में OLE वस्तु के रूप में Excel चार्ट बनाना और एम्बेड करना](/slides/hi/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[MS PowerPoint ऐड-इन का उपयोग करके OLE ऑब्जेक्ट्स को स्वचालित रूप से अपडेट करना](/slides/hi/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)