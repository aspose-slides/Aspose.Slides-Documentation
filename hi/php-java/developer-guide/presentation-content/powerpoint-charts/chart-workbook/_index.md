---
title: PHP का उपयोग करके प्रस्तुति में चार्ट वर्कबुक प्रबंधित करें
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
- वर्कबुक पुनरुद्धार
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Java के माध्यम से PHP के लिए Aspose.Slides की खोज करें: PowerPoint और OpenDocument स्वरूपों में आसानी से चार्ट वर्कबुक प्रबंधित करें और अपनी प्रस्तुति डेटा को सुव्यवस्थित बनायें।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ कैसे काम किया जाए, समझाता है। यह दिखाता है कि वर्कबुक स्ट्रीम के माध्यम से चार्ट डेटा को कैसे पढ़ा और लिखा जाए, वर्कबुक कोशिकाओं को चार्ट डेटा लेबल के रूप में कैसे उपयोग किया जाए, वर्कशीट संग्रह तक कैसे पहुँचा जाए, और चार्ट मानों के लिए डेटा स्रोत प्रकार कैसे निर्दिष्ट किया जाए।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दिखाते हैं कि बाहरी वर्कबुक कैसे बनायीँ और असाइन किया जाए, चार्ट से जुड़ी बाहरी वर्कबुक का पथ कैसे प्राप्त किया जाए, और जब वर्कबुक उपलब्ध हो तो चार्ट डेटा को कैसे संपादित किया जाए।

## **वर्कबुक से चार्ट डेटा पढ़ना और लिखना**

Aspose.Slides में [readWorkbookStream](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/#readWorkbookStream) और [writeWorkbookStream](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/#writeWorkbookStream) मेथड उपलब्ध हैं जो आपको चार्ट डेटा वर्कबुक (जिसमें Aspose.Cells के साथ संपादित चार्ट डेटा होता है) को पढ़ने और लिखने की अनुमति देते हैं। **ध्यान दें** कि चार्ट डेटा को उसी रूप में व्यवस्थित होना चाहिए या स्रोत के समान संरचना रखनी चाहिए।

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

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करना**

1. [Presentation](https://apireference.aspose.com/slides/hi/php-java/aspose.slides/presentation) क्लास का एक इंस्टेंस बनायें।
1. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।
1. कुछ डेटा के साथ बबल चार्ट जोड़ें।
1. चार्ट सीरीज तक पहुँचें।
1. वर्कबुक सेल को डेटा लेबल के रूप में सेट करें।
1. प्रेजेंटेशन सेव करें।

यह PHP कोड आपको वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करना दिखाता है:

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है
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

## **वर्कशीट्स को प्रबंधित करना**

यह PHP कोड एक ऑपरेशन दर्शाता है जहाँ [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/#getWorksheets) मेथड का उपयोग करके वर्कशीट संग्रह तक पहुँचा जाता है:

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

## **डेटा स्रोत प्रकार निर्दिष्ट करना**

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

## **असमर्थित एम्बेडेड वर्कबुक फॉर्मेट का पता लगाना**

Aspose.Slides कुछ चार्ट में एम्बेड किए जा सकने वाले Excel बाइनरी वर्कबुक (.xlsb) फॉर्मेट को सपोर्ट नहीं करता। आप [ChartData](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/) पर `getEmbeddedWorkbookType` मेथड को [WorkbookType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/workbooktype/) एनेमरेशन के साथ उपयोग करके असमर्थित फॉर्मेट का पता लगा सकते हैं और उन चार्ट को स्किप कर सकते हैं।

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
      # एम्बेडेड वर्कबुक .xlsb फॉर्मेट में है, जो समर्थित नहीं है।
      continue;
    }

    # यहाँ चार्ट वर्कबुक डेटा पढ़ें या संशोधित करें।
  }
} finally {
  $presentation->dispose();
}
```

## **बाहरी वर्कबुक**

Aspose.Slides चार्ट्स के डेटा स्रोत के रूप में बाहरी वर्कबुक को सपोर्ट करता है।

### **बाहरी वर्कबुक बनाना**

**`readWorkbookStream`** और **`setExternalWorkbook`** मेथड का उपयोग करके आप या तो शून्य से एक बाहरी वर्कबुक बना सकते हैं या एक आंतरिक वर्कबुक को बाहरी बना सकते हैं।

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

### **बाहरी वर्कबुक सेट करना**

**`setExternalWorkbook`** मेथड का उपयोग करके आप एक चार्ट को उसका डेटा स्रोत के रूप में एक बाहरी वर्कबुक असाइन कर सकते हैं। इस मेथड का उपयोग बाहरी वर्कबुक के पथ को अपडेट करने के लिए भी किया जा सकता है (यदि वह स्थानांतरित हो गया हो)।

हालांकि आप रिमोट लोकेशन या संसाधनों में संग्रहीत वर्कबुक डेटा को संपादित नहीं कर सकते, आप फिर भी ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी वर्कबुक के लिए रिलेटिव पाथ प्रदान किया गया है, तो वह स्वचालित रूप से पूर्ण पाथ में परिवर्तित हो जाता है।

यह PHP कोड आपको दिखाता है कि बाहरी वर्कबुक कैसे सेट किया जाए:

```php
  # Presentation क्लास का एक उदाहरण बनाता है
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

`ChartData` पैरामीटर (`setExternalWorkbook` मेथड के तहत) यह निर्धारित करने के लिए उपयोग किया जाता है कि Excel वर्कबुक लोड होगी या नहीं।

* `ChartData` का मान `false` सेट करने पर, केवल वर्कबुक पाथ अपडेट होता है—चार्ट डेटा लक्ष्य वर्कबुक से नहीं लोड या अपडेट होगा। आप इस सेटिंग का उपयोग तब कर सकते हैं जब लक्ष्य वर्कबुक मौजूद न हो या उपलब्ध न हो।
* `ChartData` का मान `true` सेट करने पर, चार्ट डेटा लक्ष्य वर्कबुक से अपडेट हो जाता है।

```php
  # Presentation क्लास का एक उदाहरण बनाता है
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

### **चार्ट की बाहरी डेटा स्रोत वर्कबुक पाथ प्राप्त करें**

1. [Presentation](https://apireference.aspose.com/slides/hi/php-java/aspose.slides/presentation) क्लास का एक इंस्टेंस बनायें।
1. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।
1. चार्ट शेप के लिए एक ऑब्जेक्ट बनायें।
1. स्रोत (`ChartDataSourceType`) प्रकार के लिए एक ऑब्जेक्ट बनायें जो चार्ट के डेटा स्रोत का प्रतिनिधित्व करता है।
1. स्रोत प्रकार को बाहरी वर्कबुक डेटा स्रोत प्रकार के समान होने के आधार पर संबंधित शर्त निर्दिष्ट करें।

यह PHP कोड ऑपरेशन दर्शाता है:

```php
  # Presentation क्लास का एक उदाहरण बनाता है
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

### **चार्ट डेटा संपादित करना**

आप बाहरी वर्कबुक में डेटा को उसी तरह संपादित कर सकते हैं जैसे आप आंतरिक वर्कबुक की सामग्री में बदलाव करते हैं। जब बाहरी वर्कबुक लोड नहीं हो पाती, तो एक अपवाद उत्पन्न होता है।

यह PHP कोड वर्णित प्रक्रिय का कार्यान्वयन है:

```php
  # Presentation क्लास का एक उदाहरण बनाता है
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

### **चार्ट कैश से वर्कबुक पुनः प्राप्त करना**

यदि कोई चार्ट ऐसी बाहरी वर्कबुक उपयोग करता है जो गायब या उपलब्ध नहीं है, तो Aspose.Slides प्रस्तुति में कैश किए गए डेटा से चार्ट वर्कबुक को पुनः निर्माण कर सकता है। प्रस्तुति खोलने से पहले [LoadOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/) बनायें, उसे [SpreadsheetOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/spreadsheetoptions/) से कॉन्फ़िगर करें, और `true` के साथ [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hi/php-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) को कॉल करें।

निम्नलिखित PHP उदाहरण एक ऐसी प्रस्तुति खोलता है जहाँ चार्ट एक अनुपलब्ध बाहरी वर्कबुक को संदर्भित करता है और पुनः प्राप्त डेटा को [Chart::getChartData](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/#getChartData) और [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/#getChartDataWorkbook) के माध्यम से एक्सेस करता है:

```php
$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

    # यहाँ पुनर्प्राप्त वर्कबुक डेटा पढ़ें या संशोधित करें।
} finally {
    $presentation->dispose();
}
```

यदि बाहरी वर्कबुक उपलब्ध नहीं है और पुनः प्राप्ति अक्षम है, तो Aspose.Slides एक अपवाद फेंकता है। पुनः प्राप्ति केवल तब सक्षम करें जब कैश किए गए चार्ट डेटा का उपयोग एक स्वीकार्य बैकअप हो, क्योंकि कैश में उस बाहरी वर्कबुक में किए गए बदलाव हो सकते हैं जो प्रस्तुति के अंतिम अपडेट के बाद हुए हों।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाहरी या एम्बेडेड वर्कबुक से जुड़ा है?**

हाँ। एक चार्ट के पास एक [डेटा स्रोत प्रकार](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/getdatasourcetype/) और एक [बाहरी वर्कबुक का पाथ](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/getexternalworkbookpath/) होता है; यदि स्रोत एक बाहरी वर्कबुक है, तो आप पूर्ण पाथ पढ़कर सुनिश्चित कर सकते हैं कि एक बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक के रिलेटिव पाथ सपोर्टेड हैं, और वे कैसे संग्रहित होते हैं?**

हाँ। यदि आप रिलेटिव पाथ निर्दिष्ट करते हैं, तो वह स्वचालित रूप से एब्सोल्यूट पाथ में बदल दिया जाता है। यह प्रोजेक्ट पोर्टेबिलिटी के लिए सुविधाजनक है; हालांकि, यह ध्यान रखें कि प्रस्तुति PPTX फ़ाइल में एब्सोल्यूट पाथ को स्टोर करेगी।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**

हाँ, ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से सीधे रिमोट वर्कबुक को संपादित करना समर्थित नहीं है—इन्हें केवल स्रोत के रूप में उपयोग किया जा सकता है।

**क्या प्रस्तुति सहेजते समय Aspose.Slides बाहरी XLSX को ओवरराइट करता है?**

नहीं। प्रस्तुति एक [बाहरी फ़ाइल के लिंक](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/getexternalworkbookpath/) को स्टोर करती है और डेटा पढ़ने के लिए इसका उपयोग करती है। प्रस्तुति सहेजते समय बाहरी फ़ाइल स्वयं नहीं बदली जाती।

**यदि बाहरी फ़ाइल पासवर्ड-संरक्षित हो तो मुझे क्या करना चाहिए?**

Aspose.Slides लिंकिंग के समय पासवर्ड स्वीकार नहीं करता। एक सामान्य तरीका यह है कि पहले से सुरक्षा हटाई जाए या एक डिक्रिप्टेड कॉपी तैयार की जाए (उदाहरण के लिए, [Aspose.Cells](/cells/php-java/) का उपयोग करके) और उस कॉपी को लिंक किया जाए।

**क्या कई चार्ट एक ही बाहरी वर्कबुक को संदर्भित कर सकते हैं?**

हाँ। प्रत्येक चार्ट अपना अपना लिंक स्टोर करता है। यदि सभी एक ही फ़ाइल को संकेत करते हैं, तो उस फ़ाइल को अपडेट करने पर अगली बार डेटा लोड होने पर प्रत्येक चार्ट में परिवर्तन परिलक्षित होगा।