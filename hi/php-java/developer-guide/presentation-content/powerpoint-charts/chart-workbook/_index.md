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
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java की खोज करें: PowerPoint और OpenDocument फ़ॉर्मैट में चार्ट वर्कबुक को सहजता से प्रबंधित करें और अपनी प्रस्तुति डेटा को सुव्यवस्थित बनाएं।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने के तरीके को समझाता है। यह बताता है कि कैसे वर्कबुक स्ट्रीम के माध्यम से चार्ट डेटा को पढ़ा और लिखा जाए, वर्कबुक सेल्स को चार्ट डेटा लेबल के रूप में उपयोग किया जाए, वर्कशीट संग्रह तक पहुँचा जाए, और चार्ट मानों के लिए डेटा स्रोत प्रकार निर्धारित किया जाए।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दिखाते हैं कि कैसे एक बाहरी वर्कबुक बनायीँ और असाइन किया जाए, चार्ट से जुड़े बाहरी वर्कबुक का पथ प्राप्त किया जाए, और जब वर्कबुक उपलब्ध हो तो चार्ट डेटा को संपादित किया जाए।

## **वर्कबुक से चार्ट डेटा पढ़ें और लिखें**
Aspose.Slides [readWorkbookStream](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/#readWorkbookStream) और [writeWorkbookStream](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/#writeWorkbookStream) मेथड्स प्रदान करता है जो आपको चार्ट डेटा वर्कबुक (जिसमें Aspose.Cells के साथ संपादित किया गया चार्ट डेटा शामिल है) को पढ़ने और लिखने की अनुमति देते हैं। **ध्यान दें** कि चार्ट डेटा को उसी तरीके से व्यवस्थित होना चाहिए या उसका ढांचा स्रोत के समान होना चाहिए।

यह PHP कोड एक नमूना ऑपरेशन दिखाता है:

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

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करें**

1. एक नई [Presentation](https://apireference.aspose.com/slides/hi/php-java/aspose.slides/presentation) क्लास बनाएं।
1. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।
1. कुछ डेटा के साथ एक बबल चार्ट जोड़ें।
1. चार्ट सीरीज़ तक पहुँचें।
1. वर्कबुक सेल को डेटा लेबल के रूप में सेट करें।
1. प्रेजेंटेशन सहेजें।

यह PHP कोड आपको वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करने का तरीका दिखाता है:

```php
  $lbl0 = "Label 0 cell value";
  $lbl1 = "Label 1 cell value";
  $lbl2 = "Label 2 cell value";
  # एक प्रेजेंटेशन क्लास का उदाहरण बनाता है जो एक प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करता है
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

## **डेटा स्रोत प्रकार निर्दिष्ट करें**

यह PHP कोड आपको डेटा स्रोत के लिए प्रकार निर्दिष्ट करने का तरीका दिखाता है:

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

## **असमर्थित एम्बेडेड वर्कबुक फ़ॉर्मैट्स का पता लगाएँ**

Aspose.Slides कुछ चार्ट्स में एम्बेड किए जा सकने वाले Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट का समर्थन नहीं करता है। आप [ChartData](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/) पर `getEmbeddedWorkbookType` मेथड को [WorkbookType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/workbooktype/) enumeration के साथ उपयोग करके असमर्थित फ़ॉर्मेट्स का पता लगा सकते हैं और उन चार्ट्स को छोड़ सकते हैं।

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
      # एंबेडेड वर्कबुक .xlsb फ़ॉर्मेट में है, जो समर्थित नहीं है।
      continue;
    }

    # यहाँ चार्ट वर्कबुक डेटा पढ़ें या संशोधित करें।
  }
} finally {
  $presentation->dispose();
}
```

## **बाहरी वर्कबुक**

Aspose.Slides चार्ट्स के डेटा स्रोत के रूप में बाहरी वर्कबुक का समर्थन करता है।

### **बाहरी वर्कबुक बनाएं**

**`readWorkbookStream`** और **`setExternalWorkbook`** मेथड्स का उपयोग करके आप नई बाहरी वर्कबुक बना सकते हैं या एक आंतरिक वर्कबुक को बाहरी बना सकते हैं।

यह PHP कोड बाहरी वर्कबुक निर्माण प्रक्रिया को दर्शाता है:

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

**`setExternalWorkbook`** मेथड का उपयोग करके आप एक चार्ट को बाहरी वर्कबुक को उसका डेटा स्रोत के रूप में असाइन कर सकते हैं। यह मेथड बाहरी वर्कबुक का पथ अपडेट करने के लिए भी उपयोग किया जा सकता है (यदि वह स्थानांतरित किया गया हो)।

हालांकि आप रिमोट लोकेशन या संसाधन में संग्रहीत वर्कबुक के डेटा को संपादित नहीं कर सकते, फिर भी आप ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी वर्कबुक के लिए सापेक्ष पथ प्रदान किया जाता है, तो वह स्वतः पूर्ण पथ में परिवर्तित हो जाता है।

यह PHP कोड आपको बाहरी वर्कबुक सेट करने का तरीका दिखाता है:

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

`ChartData` पैरामीटर (`setExternalWorkbook` मेथड के तहत) यह निर्धारित करने के लिए उपयोग किया जाता है कि एक्सेल वर्कबुक लोड किया जाएगा या नहीं। 

* जब `ChartData` मान `false` पर सेट किया जाता है, तो केवल वर्कबुक पथ अपडेट होता है—चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं होगा। यह सेटिंग तब उपयोगी होती है जब लक्ष्य वर्कबुक मौजूद नहीं है या उपलब्ध नहीं है। 
* जब `ChartData` मान `true` पर सेट किया जाता है, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट हो जाता है।

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

### **चार्ट के बाहरी डेटा स्रोत वर्कबुक पथ प्राप्त करें**

1. एक नई [Presentation](https://apireference.aspose.com/slides/hi/php-java/aspose.slides/presentation) क्लास बनाएं।
1. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।
1. चार्ट शेप के लिए एक ऑब्जेक्ट बनाएं।
1. स्रोत (`ChartDataSourceType`) प्रकार के लिए एक ऑब्जेक्ट बनाएं जो चार्ट के डेटा स्रोत को दर्शाता है।
1. स्रोत प्रकार को बाहरी वर्कबुक डेटा स्रोत प्रकार के समान रखने के आधार पर उपयुक्त शर्त निर्दिष्ट करें।

यह PHP कोड इस ऑपरेशन को दर्शाता है:

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

आप बाहरी वर्कबुक में डेटा को उसी तरह संपादित कर सकते हैं जैसे आप आंतरिक वर्कबुक की सामग्री को बदलते हैं। जब बाहरी वर्कबुक लोड नहीं की जा सकती, तो एक अपवाद फेंका जाता है।

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

## **FAQ**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशेष चार्ट बाहरी या एम्बेडेड वर्कबुक से जुड़ा है?**

हां। एक चार्ट के पास एक [डेटा स्रोत प्रकार](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/getdatasourcetype/) और एक [बाहरी वर्कबुक का पथ](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/getexternalworkbookpath/) होता है; यदि स्रोत एक बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़ सकते हैं यह सुनिश्चित करने के लिए कि बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक के सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हां। यदि आप सापेक्ष पथ निर्दिष्ट करते हैं, तो वह स्वतः एक पूर्ण पथ में परिवर्तित हो जाता है। यह प्रोजेक्ट पोर्टेबिलिटी के लिए सुविधाजनक है; हालांकि, ध्यान रखें कि प्रेजेंटेशन PPTX फ़ाइल में पूर्ण पथ संग्रहीत करेगा।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**

हां, ऐसी वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से सीधे रिमोट वर्कबुक को संपादित करना समर्थित नहीं है—इन्हें केवल स्रोत के रूप में उपयोग किया जा सकता है।

**क्या Aspose.Slides प्रेजेंटेशन सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

नहीं। प्रेजेंटेशन एक [बाहरी फ़ाइल का लिंक](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/getexternalworkbookpath/) संग्रहीत करता है और उसे डेटा पढ़ने के लिए उपयोग करता है। प्रेजेंटेशन सहेजने पर बाहरी फ़ाइल स्वयं संशोधित नहीं होती।

**यदि बाहरी फ़ाइल पासवर्ड सुरक्षा वाली है तो मुझे क्या करना चाहिए?**

Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। एक सामान्य तरीका है पहले सुरक्षा हटाना या एक डिक्रिप्टेड प्रति तैयार करना (उदाहरण के लिए, [Aspose.Cells](/cells/php-java/) का उपयोग करके) और उस प्रति से लिंक करना।

**क्या कई चार्ट एक ही बाहरी वर्कबुक को संदर्भित कर सकते हैं?**

हां। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर संकेत करते हैं, तो फ़ाइल को अपडेट करने पर अगली बार डेटा लोड होने पर प्रत्येक चार्ट में वह परिवर्तन दिखेगा।