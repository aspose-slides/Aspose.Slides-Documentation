---
title: PHP का उपयोग करके प्रस्तुतियों में चार्ट कार्यपुस्तिकाओं का प्रबंधन
linktitle: चार्ट कार्यपुस्तिका
type: docs
weight: 70
url: /hi/php-java/chart-workbook/
keywords:
- चार्ट कार्यपुस्तिका
- चार्ट डेटा
- कार्यपुस्तिका कोशिका
- डेटा लेबल
- वर्कशीट
- डेटा स्रोत
- बाहरी कार्यपुस्तिका
- बाहरी डेटा
- चार्ट कैश
- कार्यपुस्तिका पुनर्प्राप्ति
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP को Java के माध्यम से खोजें: PowerPoint और OpenDocument स्वरूपों में चार्ट कार्यपुस्तिकाओं को सहजता से प्रबंधित करें और अपने प्रेजेंटेशन डेटा को सुव्यवस्थित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट कार्यपुस्तिकाओं के साथ काम करने का तरीका समझाता है। यह कार्यपुस्तिका स्ट्रीम के माध्यम से चार्ट डेटा को पढ़ने और लिखने, कार्यपुस्तिका कोशिकाओं को चार्ट डेटा लेबल के रूप में उपयोग करने, वर्कशीट संग्रहों तक पहुँचने, और चार्ट मानों के लिए डेटा स्रोत प्रकार निर्दिष्ट करने को दर्शाता है।

यह बाहरी कार्यपुस्तिकाओं को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दिखाते हैं कि कैसे एक बाहरी कार्यपुस्तिका बनाइए और असाइन कीजिए, चार्ट से जुड़ी बाहरी कार्यपुस्तिका का पथ प्राप्त कीजिए, और जब कार्यपुस्तिका उपलब्ध हो तो चार्ट डेटा को संपादित कीजिए।

कार्यपुस्तिका कोशिकाओं जो अनुपलब्ध डेटा का प्रतिनिधित्व करती हैं, उनके बारे में देखें [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/php-java/chart-series/) जहाँ खाली कोशिका और शून्य के बीच अंतर तथा उपलब्ध प्रदर्शनी मोड के लाइन-चार्ट तुलना को समझाया गया है।

## **वर्कबुक से चार्ट डेटा पढ़ना और लिखना**
Aspose.Slides [readWorkbookStream](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/#readWorkbookStream) और [writeWorkbookStream](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/#writeWorkbookStream) मेथड प्रदान करता है जो आपको चार्ट डेटा कार्यपुस्तिकाओं (Aspose.Cells के साथ संपादित चार्ट डेटा वाली) को पढ़ने और लिखने की अनुमति देता है। **ध्यान दें** कि चार्ट डेटा को उसी तरह व्यवस्थित होना चाहिए या स्रोत के समान संरचना रखनी चाहिए।

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

### **वर्कबुक संशोधन के बाद चार्ट लेआउट सत्यापित करें**

जब आप एक एम्बेडेड कार्यपुस्तिका को संशोधित कार्यपुस्तिका से बदलते हैं, तो चार्ट अपनी मूल सीरीज और श्रेणी संग्रहों को बनाए रखता है। यह विसंगति [Chart::validateChartLayout](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/validatechartlayout/) को इंडेक्स‑आउट‑ऑफ़‑रेंज त्रुटि के साथ विफल कर सकती है। अद्यतन कार्यपुस्तिका को चार्ट में वापस लिखने से पहले मौजूदा सीरीज और श्रेणियों को साफ़ करें।

```php
// वर्कबुक स्ट्रीम को संशोधित करने के बाद (जैसे, Aspose.Cells का उपयोग करके)
$updatedWorkbook = $chartData->readWorkbookStream();

// मौजूदा डेटा संदर्भों को साफ़ करें।
$chartData->getSeries()->clear();
$chartData->getCategories()->clear();

$chartData->writeWorkbookStream($updatedWorkbook);

$chart->validateChartLayout();
```

संग्रहों को साफ़ करने से यह सुनिश्चित होता है कि चार्ट डेटा संरचना नई कार्यपुस्तिका के साथ संगत है, जिससे `validateChartLayout` बिना त्रुटियों के पूरा हो जाता है।

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करें**

1. [Presentation](https://apireference.aspose.com/slides/hi/php-java/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।  
1. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
1. कुछ डेटा के साथ एक बुलबुला चार्ट जोड़ें।  
1. चार्ट सीरीज तक पहुँचें।  
1. वर्कबुक सेल को डेटा लेबल के रूप में सेट करें।  
1. प्रेजेंटेशन को सहेजें।

यह PHP कोड दिखाता है कि कैसे वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट किया जाता है:

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है
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

## **वर्कशीट्स को प्रबंधित करें**

यह PHP कोड एक ऑपरेशन दर्शाता है जहाँ [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/#getWorksheets) मेथड का उपयोग करके वर्कशीट संग्रह तक पहुँच बनाई जाती है:

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

## **डेटा स्रोत प्रकार निर्दिष्ट करें**

यह PHP कोड दिखाता है कि डेटा स्रोत के लिए प्रकार कैसे निर्दिष्ट किया जाए:

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

## **असमर्थित एम्बेडेड कार्यपुस्तिका फ़ॉर्मैट का पता लगाएँ**

Aspose.Slides उन कुछ चार्ट्स में एम्बेडेड Excel बाइनरी कार्यपुस्तिका (.xlsb) फ़ॉर्मैट को समर्थन नहीं देता। आप [ChartData](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/) पर `getEmbeddedWorkbookType` मेथड को [WorkbookType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/workbooktype/) ए़न्यूमरेशन के साथ उपयोग करके असमर्थित फ़ॉर्मैट का पता लगा सकते हैं और उन चार्ट्स को छोड़ सकते हैं।

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
      # एम्बेडेड कार्यपुस्तिका .xlsb फ़ॉर्मेट में है, जो समर्थित नहीं है।
      continue;
    }

    # यहाँ चार्ट कार्यपुस्तिका डेटा को पढ़ें या संशोधित करें।
  }
} finally {
  $presentation->dispose();
}
```

## **बाहरी कार्यपुस्तिका**

Aspose.Slides चार्ट्स के लिए डेटा स्रोत के रूप में बाहरी कार्यपुस्तिकाओं का समर्थन करता है।

### **बाहरी कार्यपुस्तिका बनाएँ**

**`readWorkbookStream`** और **`setExternalWorkbook`** मेथड का उपयोग करके आप या तो एक नई बाहरी कार्यपुस्तिका बना सकते हैं या किसी आंतरिक कार्यपुस्तिका को बाहरी बना सकते हैं।

यह PHP कोड बाहरी कार्यपुस्तिका निर्माण प्रक्रिया दर्शाता है:

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

### **बाहरी कार्यपुस्तिका सेट करें**

**`setExternalWorkbook`** मेथड का उपयोग करके आप एक चार्ट को उसके डेटा स्रोत के रूप में एक बाहरी कार्यपुस्तिका असाइन कर सकते हैं। यह मेथड बाहरी कार्यपुस्तिका के पथ को अपडेट करने के लिए भी प्रयोग किया जा सकता है (यदि वह स्थानांतरित हो गई हो)।

हालाँकि आप दूरस्थ स्थानों या संसाधनों में संग्रहीत कार्यपुस्तिकाओं के डेटा को संपादित नहीं कर सकते, फिर भी आप उन्हें बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी कार्यपुस्तिका के लिए सापेक्ष पथ प्रदान किया जाता है, तो इसे स्वचालित रूप से पूर्ण पथ में बदल दिया जाता है।

यह PHP कोड दिखाता है कि कैसे एक बाहरी कार्यपुस्तिका सेट की जाती है:

```php
  # Presentation क्लास का एक इंस्टेंस बनाता है
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

`ChartData` पैरामीटर (`setExternalWorkbook` मेथड के अंतर्गत) यह निर्दिष्ट करने के लिए उपयोग किया जाता है कि क्या Excel कार्यपुस्तिका लोड की जाएगी।

* जब `ChartData` मान `false` पर सेट होता है, तो केवल कार्यपुस्तिका पथ अपडेट होता है—चार्ट डेटा लक्ष्य कार्यपुस्तिका से लोड या अपडेट नहीं होगा। यह सेटिंग तब उपयोगी है जब लक्ष्य कार्यपुस्तिका अस्तित्व में नहीं है या उपलब्ध नहीं है।  
* जब `ChartData` मान `true` पर सेट होता है, तो चार्ट डेटा लक्ष्य कार्यपुस्तिका से अपडेट हो जाता है।

```php
  # Presentation क्लास का एक इंस्टेंस बनाता है
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

### **चार्ट के बाहरी डेटा स्रोत कार्यपुस्तिका पथ प्राप्त करें**

1. [Presentation](https://apireference.aspose.com/slides/hi/php-java/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।  
1. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
1. चार्ट शेप के लिए एक ऑब्जेक्ट बनाएँ।  
1. स्रोत (`ChartDataSourceType`) प्रकार का ऑब्जेक्ट बनाएँ जो चार्ट के डेटा स्रोत का प्रतिनिधित्व करता है।  
1. स्रोत प्रकार को बाहरी कार्यपुस्तिका डेटा स्रोत प्रकार के समान होने के आधार पर संबंधित शर्त निर्दिष्ट करें।

यह PHP कोड ऑपरेशन को प्रदर्शित करता है:

```php
  # Presentation क्लास का एक इंस्टेंस बनाता है
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

आप बाहरी कार्यपुस्तिकाओं के डेटा को उसी तरह संपादित कर सकते हैं जैसे आप आंतरिक कार्यपुस्तिकाओं की सामग्री में बदलाव करते हैं। जब बाहरी कार्यपुस्तिका लोड नहीं की जा सकती, तो एक अपवाद (exception) फेंका जाता है।

यह PHP कोड वर्णित प्रक्रिया का कार्यान्वयन है:

```php
  # Presentation क्लास का एक इंस्टेंस बनाता है
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

### **चार्ट कैश से कार्यपुस्तिका पुनर्प्राप्त करें**

यदि कोई चार्ट बाहरी कार्यपुस्तिका का उपयोग करता है जो गायब या अनुपलब्ध है, तो Aspose.Slides प्रस्तुति में कैश किए गए डेटा से चार्ट कार्यपुस्तिका को पुनर्निर्मित कर सकता है। [LoadOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/) बनाएँ, उसे [SpreadsheetOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/spreadsheetoptions/) के साथ कॉन्फ़िगर करें, और प्रस्तुति खोलने से पहले `true` के साथ [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hi/php-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) को कॉल करें।

निम्नलिखित PHP उदाहरण एक ऐसी प्रस्तुति खोलता है जिसमें चार्ट एक अनुपलब्ध बाहरी कार्यपुस्तिका को संदर्भित करता है और पुनः प्राप्त डेटा को [Chart::getChartData](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/#getChartData) और [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/#getChartDataWorkbook) के माध्यम से एक्सेस करता है:

```php
$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

    # यहाँ पुनर्प्राप्त कार्यपुस्तिका डेटा को पढ़ें या संशोधित करें।
} finally {
    $presentation->dispose();
}
```

यदि बाहरी कार्यपुस्तिका अनुपलब्ध है और पुनर्प्राप्ति अक्षम है, तो Aspose.Slides एक अपवाद फेंकेगा। केवल तभी पुनर्प्राप्ति सक्षम करें जब कैश किए गए चार्ट डेटा का उपयोग एक स्वीकार्य वैकल्पिक उपाय हो, क्योंकि कैश में बाहरी कार्यपुस्तिका में प्रस्तुति के अंतिम अपडेट के बाद किए गए बदलाव शामिल नहीं हो सकते।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशेष चार्ट बाहरी या एम्बेडेड कार्यपुस्तिका से जुड़ा है?**

हां। एक चार्ट का एक [डेटा स्रोत प्रकार](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/getdatasourcetype/) और एक [बाहरी कार्यपुस्तिका का पथ](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/getexternalworkbookpath/) होता है; यदि स्रोत बाहरी कार्यपुस्तिका है, तो आप पूर्ण पथ पढ़कर सुनिश्चित कर सकते हैं कि कोई बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी कार्यपुस्तिकाओं के सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हां। यदि आप एक सापेक्ष पथ निर्दिष्ट करते हैं, तो उसे स्वचालित रूप से पूर्ण पथ में बदल दिया जाता है। यह परियोजना पोर्टेबिलिटी के लिए सुविधाजनक है; हालांकि, ध्यान रखें कि प्रस्तुति पूर्ण पथ को PPTX फ़ाइल में संग्रहीत करती है।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित कार्यपुस्तिकाओं का उपयोग कर सकता हूँ?**

हां, ऐसी कार्यपुस्तिकाओं को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। लेकिन Aspose.Slides से सीधे रिमोट कार्यपुस्तिकाओं को संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में इस्तेमाल की जा सकती हैं।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

नहीं। प्रस्तुति एक [बाहरी फ़ाइल के लिंक](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/getexternalworkbookpath/) को संग्रहीत करती है और डेटा पढ़ने के लिए उसका उपयोग करती है। प्रस्तुति सहेजने पर बाहरी फ़ाइल स्वयं संशोधित नहीं होती।

**अगर बाहरी फ़ाइल पासवर्ड‑सुरक्षित है तो मुझे क्या करना चाहिए?**

Aspose.Slides लिंकिंग के समय पासवर्ड स्वीकार नहीं करता। आम तौर पर पहले सुरक्षा हटाना या एक डिक्रिप्टेड कॉपी (उदाहरण के लिए, [Aspose.Cells](/cells/php-java/)) तैयार करना और उस कॉपी को लिंक करना एक समाधान है।

**क्या कई चार्ट एक ही बाहरी कार्यपुस्तिका को संदर्भित कर सकते हैं?**

हां। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर इशारा करते हैं, तो उस फ़ाइल में किया गया अपडेट अगली बार डेटा लोड होने पर सभी चार्ट्स में प्रतिबिंबित होगा।