---
title: PHP का उपयोग करके प्रस्तुतियों में चार्ट वर्कबुक प्रबंधित करें
linktitle: चार्ट वर्कबुक
type: docs
weight: 70
url: /hi/php-java/chart-workbook/
keywords:
- चार्ट वर्कबुक
- चार्ट डेटा
- वर्कबुक सेल
- डेटा लेबल
- वर्कशीट
- डेटा स्रोत
- बाहरी वर्कबुक
- बाहरी डेटा
- चार्ट कैश
- वर्कबुक पुनर्प्राप्ति
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP को Java के माध्यम से खोजें: PowerPoint और OpenDocument फ़ॉर्मैट में चार्ट वर्कबुक को आसानी से प्रबंधित करें और अपनी प्रस्तुति डेटा को सुगम बनाएं।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने का तरीका बताता है। यह दर्शाता है कि कैसे वर्कबुक स्ट्रीम के माध्यम से चार्ट डेटा को पढ़ा और लिखा जाए, वर्कबुक सेल्स को चार्ट डेटा लेबल के रूप में उपयोग किया जाए, वर्कशीट कलेक्शन्स तक पहुंचा जाए, और चार्ट वैल्यू के लिए डेटा सोर्स टाइप निर्दिष्ट किया जाए।

यह बाहरी वर्कबुक को चार्ट डेटा सोर्स के रूप में उपयोग करने को भी शामिल करता है। उदाहरण दिखाते हैं कि कैसे एक बाहरी वर्कबुक बनाया और सौंपा जाए, चार्ट से जुड़ी बाहरी वर्कबुक का पथ प्राप्त किया जाए, और जब वर्कबुक उपलब्ध हो तो चार्ट डेटा संपादित किया जाए।

## **वर्कबुक से चार्ट डेटा पढ़ें और लिखें**
Aspose.Slides वह [readWorkbookStream](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/#readWorkbookStream) और [writeWorkbookStream](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/#writeWorkbookStream) मेथड प्रदान करता है जो आपको चार्ट डेटा वर्कबुक (Aspose.Cells के साथ संपादित किए गए चार्ट डेटा) को पढ़ने और लिखने की अनुमति देते हैं। **ध्यान दें** कि चार्ट डेटा को उसी तरीके से व्यवस्थित होना चाहिए या स्रोत के समान संरचना होनी चाहिए।

यह PHP कोड एक नमूना ऑपरेशन दर्शाता है:

```php
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $data = $chart->getChartData();
    $stream = $data->readWorkbookStream();
    $data->getSeries()->clear();
    $data->getCategories()->clear();
    $data->writeWorkbookStream($stream);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **वर्कबुक संशोधन के बाद चार्ट लेआउट को वैध करें**

जब आप एम्बेडेड वर्कबुक को संशोधित वर्कबुक से बदलते हैं, तो चार्ट अपनी मूल सीरीज़ और श्रेणी कलेक्शन्स को बनाए रखता है। यह असमानता [Chart::validateChartLayout](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/validatechartlayout/) को इंडेक्स-आउट-ऑफ-रेन्ज त्रुटि के साथ फेल कर सकती है। अद्यतन वर्कबुक को चार्ट में वापस लिखने से पहले मौजूदा सीरीज़ और श्रेणियों को साफ़ कर दें।

```php
// वर्कबुक स्ट्रीम को संशोधित करने के बाद (उदाहरण के लिए, Aspose.Cells का उपयोग करके)
$updatedWorkbook = $chartData->readWorkbookStream();

// मौजूदा डेटा संदर्भों को साफ़ करें।
$chartData->getSeries()->clear();
$chartData->getCategories()->clear();

$chartData->writeWorkbookStream($updatedWorkbook);

$chart->validateChartLayout();
```

कलेक्शन्स को साफ़ करने से यह सुनिश्चित होता है कि चार्ट डेटा संरचना नई वर्कबुक के साथ संगत है, जिससे `validateChartLayout` बिना त्रुटियों के पूरा हो जाता है।

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करें**

1. [Presentation](https://apireference.aspose.com/slides/hi/php-java/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।  
1. स्लाइड को उसके इंडेक्स के माध्यम से प्राप्त करें।  
1. कुछ डेटा के साथ एक बबल चार्ट जोड़ें।  
1. चार्ट सीरीज़ तक पहुंचें।  
1. वर्कबुक सेल को डेटा लेबल के रूप में सेट करें।  
1. प्रेजेंटेशन को सहेजें।

यह PHP कोड आपको वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करना दिखाता है:

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास को इंस्टैंसिएट करता है
  $pres = new Presentation("chart2.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $dataLabelCollection = $series->get_Item(0)->getLabels();
    $dataLabelCollection->getDefaultDataLabelFormat()->setShowLabelValueFromCell(true);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $dataLabelCollection->get_Item(0)->setValueFromCell($wb->getCell(0, "A10", $lbl0));
    $dataLabelCollection->get_Item(1)->setValueFromCell($wb->getCell(0, "A11", $lbl1));
    $dataLabelCollection->get_Item(2)->setValueFromCell($wb->getCell(0, "A12", $lbl2));
    $pres->save("resultchart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **वर्कशीट्स का प्रबंधन करें**

यह PHP कोड एक ऑपरेशन दर्शाता है जहाँ [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/#getWorksheets) मेथड का उपयोग करके वर्कशीट कलेक्शन तक पहुंचा जाता है:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 500);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    for($i = 0; $i < java_values($wb->getWorksheets()->size()) ; $i++) {
      echo($wb->getWorksheets()->get_Item($i)->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **डेटा सोर्स टाइप को निर्दिष्ट करें**

यह PHP कोड आपको डेटा सोर्स का टाइप कैसे निर्दिष्ट करें दर्शाता है:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $val = $chart->getChartData()->getSeries()->get_Item(0)->getName();
    $val->setDataSourceType(DataSourceType::StringLiterals);
    $val->setData("LiteralString");
    $val = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $val->setData($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1", "NewCell"));
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **असमर्थित एम्बेडेड वर्कबुक फॉर्मैट का पता लगाएँ**

Aspose.Slides कुछ चार्ट्स में एम्बेड किए जा सकने वाले Excel बाइनरी वर्कबुक (.xlsb) फॉर्मैट का समर्थन नहीं करता। आप [ChartData](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/) पर `getEmbeddedWorkbookType` मेथड के साथ [WorkbookType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/workbooktype/) एनेमरेशन का उपयोग करके असमर्थित फॉर्मैट का पता लगा सकते हैं और उन चार्ट्स को छोड़ सकते हैं।

```php
$presentation = new Presentation("sample.pptx");
try {
  $slide = $presentation->getSlides()->get_Item(0);
  $shapes = $slide->getShapes();

  for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
    $shape = $shapes->get_Item($shapeIndex);

    if (!java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
      continue;
    }

    $chart = $shape;
    $chartData = $chart->getChartData();

    if (java_values($chartData->getDataSourceType()) == ChartDataSourceType::InternalWorkbook &&
        java_values($chartData->getEmbeddedWorkbookType()) == WorkbookType::WorkbookBinaryMacro) {
      # एम्बेडेड वर्कबुक .xlsb फॉर्मैट में है, जो समर्थित नहीं है।
      continue;
    }

    # यहाँ चार्ट वर्कबुक डेटा को पढ़ें या संशोधित करें।
  }
} finally {
  $presentation->dispose();
}
```

## **बाहरी वर्कबुक**

Aspose.Slides चार्ट्स के लिए डेटा सोर्स के रूप में बाहरी वर्कबुक का समर्थन करता है।

### **बाहरी वर्कबुक बनाएँ**

**`readWorkbookStream`** और **`setExternalWorkbook`** मेथड्स का उपयोग करके आप या तो शून्य से एक बाहरी वर्कबुक बना सकते हैं या एक आंतरिक वर्कबुक को बाहरी बना सकते हैं।

यह PHP कोड बाहरी वर्कबुक निर्माण प्रक्रिया दर्शाता है:

```php
  $pres = new Presentation();
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $workbookPath = "externalWorkbook1.xlsx";
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600);
    $fileStream = new Java("java.io.FileOutputStream", $workbookPath);
    $Array = new java_class("java.lang.reflect.Array");
    try {
      $workbookData = $chart->getChartData()->readWorkbookStream();
      $fileStream->write($workbookData, 0, $Array->getLength($workbookData));
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
    $chart->getChartData()->setExternalWorkbook($workbookPath);
    $pres->save("externalWorkbook.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **बाहरी वर्कबुक सेट करें**

**`setExternalWorkbook`** मेथड का उपयोग करके आप किसी चार्ट को उसकी डेटा सोर्स के रूप में एक बाहरी वर्कबुक सौंप सकते हैं। यह मेथड बाहरी वर्कबुक के पथ को अपडेट करने के लिए भी उपयोग किया जा सकता है (यदि बाद वाला स्थानांतरित हो गया हो)।

हालांकि आप रिमोट लोकेशनों या रिसोर्सेज़ में संग्रहीत वर्कबुक्स का डेटा संपादित नहीं कर सकते, फिर भी आप ऐसी वर्कबुक्स को बाहरी डेटा सोर्स के रूप में उपयोग कर सकते हैं। यदि बाहरी वर्कबुक का रिलेटिव पाथ दिया गया है, तो यह स्वतः पूर्ण पाथ में परिवर्तित हो जाता है।

यह PHP कोड दिखाता है कि कैसे एक बाहरी वर्कबुक सेट किया जाए:

```php
  # Presentation क्लास का एक इंस्टैंस बनाता है
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, false);
    $chartData = $chart->getChartData();
    $chartData->setExternalWorkbook("externalWorkbook.xlsx");
    $chartData->getSeries()->add($chartData->getChartDataWorkbook()->getCell(0, "B1"), ChartType::Pie);
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B2"));
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B3"));
    $chartData->getSeries()->get_Item(0)->getDataPoints()->addDataPointForPieSeries($chartData->getChartDataWorkbook()->getCell(0, "B4"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A2"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A3"));
    $chartData->getCategories()->add($chartData->getChartDataWorkbook()->getCell(0, "A4"));
    $pres->save("Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

`ChartData` पैरामीटर (`setExternalWorkbook` मेथड के तहत) यह निर्दिष्ट करने के लिए उपयोग किया जाता है कि क्या Excel वर्कबुक लोड की जाएगी या नहीं।

* जब `ChartData` मान `false` पर सेट होता है, तो केवल वर्कबुक पथ अपडेट होता है—चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं होगा। यह सेटिंग तब उपयोगी है जब लक्ष्य वर्कबुक मौजूद नहीं है या उपलब्ध नहीं है।  
* जब `ChartData` मान `true` पर सेट होता है, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट हो जाता है।

```php
  # Presentation क्लास का एक इंस्टैंस बनाता है
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chartData = $chart->getChartData();
    $chartData->setExternalWorkbook("http://path/doesnt/exists", false);
    $pres->save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **चार्ट की बाहरी डेटा सोर्स वर्कबुक पथ प्राप्त करें**

1. [Presentation](https://apireference.aspose.com/slides/hi/php-java/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।  
1. स्लाइड को उसके इंडेक्स के माध्यम से प्राप्त करें।  
1. चार्ट शेप के लिए एक ऑब्जेक्ट बनाएं।  
1. स्रोत (`ChartDataSourceType`) टाइप के लिए एक ऑब्जेक्ट बनाएं जो चार्ट के डेटा सोर्स का प्रतिनिधित्व करता है।  
1. स्रोत टाइप के समान बाहरी वर्कबुक डेटा सोर्स टाइप होने के आधार पर संबंधित शर्त निर्दिष्ट करें।

यह PHP कोड ऑपरेशन दर्शाता है:

```php
  # Presentation क्लास का एक इंस्टैंस बनाता है
  $pres = new Presentation("chart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(1);
    $chart = $slide->getShapes()->get_Item(0);
    $sourceType = $chart->getChartData()->getDataSourceType();
    if ($sourceType == ChartDataSourceType::ExternalWorkbook) {
      $path = $chart->getChartData()->getExternalWorkbookPath();
    }
    # प्रस्तुति को सहेजता है
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **चार्ट डेटा संपादित करें**

आप बाहरी वर्कबुक्स के डेटा को उसी तरीके से संपादित कर सकते हैं जैसे आप आंतरिक वर्कबुक्स के सामग्री को बदलते हैं। जब कोई बाहरी वर्कबुक लोड नहीं की जा सकती, तो एक अपवाद फेंका जाता है।

यह PHP कोड वर्णित प्रक्रिया का कार्यान्वयन है:

```php
  # Presentation क्लास का एक इंस्टैंस बनाता है
  $pres = new Presentation("chart.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $chartData = $chart->getChartData();
    $chartData->getSeries()->get_Item(0)->getDataPoints()->get_Item(0)->getValue()->getAsCell()->setValue(100);
    $pres->save("presentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **चार्ट कैश से वर्कबुक पुनः प्राप्त करें**

यदि कोई चार्ट ऐसी बाहरी वर्कबुक का उपयोग करता है जो गायब या अनुपलब्ध है, तो Aspose.Slides प्रस्तुति में कैश किए गए डेटा से चार्ट वर्कबुक को पुनः निर्मित कर सकता है। [LoadOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/) बनाएं, उसे [SpreadsheetOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/spreadsheetoptions/) के साथ कॉन्फ़िगर करें, और प्रस्तुति खोलने से पहले `true` के साथ [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hi/php-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) को कॉल करें।

निम्नलिखित PHP उदाहरण एक प्रस्तुति खोलता है जिसका चार्ट अनुपलब्ध बाहरी वर्कबुक का संदर्भ देता है और पुनः प्राप्त डेटा को [Chart::getChartData](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/#getChartData) और [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/#getChartDataWorkbook) के माध्यम से एक्सेस करता है:

```php
$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

    # यहाँ पुनर्प्राप्त वर्कबुक डेटा को पढ़ें या संशोधित करें।
} finally {
    $presentation->dispose();
}
```

यदि बाहरी वर्कबुक अनुपलब्ध है और रिकवरी अक्षम है, तो Aspose.Slides अपवाद फेंकेगा। केवल तब रिकवरी सक्षम करें जब कैश किए गए चार्ट डेटा को फ़ॉलबैक के रूप में स्वीकार्य माना जाता है, क्योंकि कैश में बाहरी वर्कबुक में किए गए परिवर्तन शामिल नहीं हो सकते।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशेष चार्ट बाहरी या एम्बेडेड वर्कबुक से जुड़ा है?**  
हाँ। एक चार्ट का [डेटा सोर्स टाइप](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/getdatasourcetype/) और एक [बाहरी वर्कबुक का पथ](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/getexternalworkbookpath/) हो सकता है; यदि स्रोत बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़कर यह सुनिश्चित कर सकते हैं कि बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक्स के रिलेटिव पाथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**  
हाँ। यदि आप रिलेटिव पाथ निर्दिष्ट करते हैं, तो यह स्वतः पूर्ण पाथ में परिवर्तित हो जाता है। यह प्रोजेक्ट पोर्टेबिलिटी के लिए सुविधाजनक है; हालाँकि, प्रस्तुति PPTX फ़ाइल में पूर्ण पाथ संग्रहीत करेगी।

**क्या मैं नेटवर्क रिसोर्सेज़/शेयर पर स्थित वर्कबुक्स का उपयोग कर सकता हूँ?**  
हाँ, ऐसे वर्कबुक्स को बाहरी डेटा सोर्स के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से सीधे रिमोट वर्कबुक्स को संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग किए जा सकते हैं।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को ओवरराइट करता है?**  
नहीं। प्रस्तुति एक [बाहरी फ़ाइल लिंक](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/getexternalworkbookpath/) संग्रहीत करती है और डेटा पढ़ने के लिए इसका उपयोग करती है। प्रस्तुति सहेजते समय बाहरी फ़ाइल स्वयं संशोधित नहीं होती।

**यदि बाहरी फ़ाइल पासवर्ड‑सुरक्षित है तो मुझे क्या करना चाहिए?**  
Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। सामान्य तरीका यह है कि पहले सुरक्षा हटा दें या एक डिक्रिप्टेड कॉपी तैयार करें (उदाहरण के लिए, [Aspose.Cells](/cells/php-java/) का उपयोग करके) और उस कॉपी को लिंक करें।

**क्या कई चार्ट्स एक ही बाहरी वर्कबुक को संदर्भित कर सकते हैं?**  
हाँ। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर संकेत करते हैं, तो उस फ़ाइल को अपडेट करने से अगली बार डेटा लोड होने पर सभी चार्ट्स में परिवर्तन परिलक्षित होंगे।