---
title: PHP का उपयोग करके प्रस्तुतियों में बबल चार्ट को अनुकूलित करें
linktitle: बबल चार्ट
type: docs
url: /hi/php-java/bubble-chart/
keywords:
- बबल चार्ट
- बबल आकार
- आकार स्केलिंग
- आकार प्रतिनिधित्व
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ PowerPoint में शक्तिशाली बबल चार्ट बनाएं और अनुकूलित करें ताकि आप अपने डेटा विज़ुअलाइज़ेशन को आसानी से सुधार सकें।"
---
## **Overview**

यह लेख Aspose.Slides में बबल चार्ट्स के साथ काम करने का तरीका दर्शाता है। यह दो विशिष्ट अनुकूलन विकल्पों को कवर करता है: `setBubbleSizeScale` मेथड के माध्यम से बबल आकार को स्केल करना और `setBubbleSizeRepresentation` मेथड के माध्यम से बबल आकार मानों के प्रतिनिधित्व को नियंत्रित करना।

उदाहरण दिखाते हैं कि बबल चार्ट कैसे बनायें, उसके आकार स्केलिंग को समायोजित करें, और बबल आकार प्रतिनिधित्व को चौड़ाई (width) का उपयोग करने के लिए बदलें। इस लेख में एक संक्षिप्त FAQ अनुभाग भी शामिल है जो “Bubble with 3-D” चार्ट प्रकार के समर्थन को स्पष्ट करता है, बताता है कि व्यावहारिक चार्ट सीमाएँ प्रदर्शन और लक्षित PowerPoint संस्करण पर निर्भर करती हैं, और समझाता है कि निर्यात (export) Aspose.Slides रेंडरिंग इंजन के माध्यम से चार्ट की उपस्थिति को बरकरार रखता है।

## **Bubble Chart Size Scaling**
Aspose.Slides for PHP via Java बबल चार्ट आकार स्केलिंग के लिए समर्थन प्रदान करता है। Aspose.Slides for PHP via Java में [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/getbubblesizescale/), [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseriesgroup/getbubblesizescale/) और [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseriesgroup/setbubblesizescale/) मेथड्स जोड़े गए हैं। नीचे एक नमूना उदाहरण दिया गया है। 

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 100, 100, 400, 300);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeScale(150);
    $pres->save("Result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Represent Data as Bubble Chart Sizes**
मेथड्स [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseriesgroup/setbubblesizerepresentation/) और [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseriesgroup/getbubblesizerepresentation/) को [ChartSeries](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseries/), [ChartSeriesGroup](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartseriesgroup/) क्लासों और संबंधित क्लासों में जोड़ा गया है। **BubbleSizeRepresentation** यह निर्धारित करता है कि बबल चार्ट में बबल आकार मानों को कैसे प्रस्तुत किया जाता है। संभावित मान हैं: [**BubbleSizeRepresentationType::Area**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/BubbleSizeRepresentationType#Area) और [**BubbleSizeRepresentationType::Width**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/BubbleSizeRepresentationType#Width)। इस प्रकार, [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/BubbleSizeRepresentationType) एन्‍यूम को बबल चार्ट आकारों के रूप में डेटा प्रस्तुत करने के संभावित तरीकों को निर्दिष्ट करने के लिए जोड़ा गया है। नीचे नमूना कोड दिया गया है।

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeRepresentation(BubbleSizeRepresentationType::Width);
    $pres->save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Is a "bubble chart with 3-D effect" supported, and how does it differ from a regular one?**

हां। एक अलग चार्ट प्रकार “Bubble with 3-D” उपलब्ध है। यह बबल्स पर 3‑D स्टाइल लागू करता है लेकिन अतिरिक्त अक्ष नहीं जोड़ता; डेटा X‑Y‑S (आकार) ही रहता है। यह प्रकार [chart type](https://reference.aspose.com/slides/hi/php-java/aspose.slides/charttype/) क्लास में उपलब्ध है।

**Is there a limit on the number of series and points in a bubble chart?**

API स्तर पर कोई सख्त सीमा नहीं है; सीमाएँ प्रदर्शन और लक्षित PowerPoint संस्करण द्वारा निर्धारित की जाती हैं। पठनीयता और रेंडरिंग गति के लिए बिंदुओं की संख्या को यथार्थपरक रखने की सलाह दी जाती है।

**How will export affect the appearance of a bubble chart (PDF, images)?**

समर्थित फ़ॉर्मैट में निर्यात करने से चार्ट की उपस्थिति बनी रहती है; रेंडरिंग Aspose.Slides इंजन द्वारा की जाती है। रास्टर/वेक्टर फ़ॉर्मैट के लिए सामान्य चार्ट‑ग्राफ़िक्स रेंडरिंग नियम लागू होते हैं (रिज़ॉल्यूशन, एंटी‑एलीयासिंग), इसलिए प्रिंटिंग के लिए पर्याप्त DPI चुनें।