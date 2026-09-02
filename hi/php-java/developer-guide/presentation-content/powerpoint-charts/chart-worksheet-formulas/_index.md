---
title: PHP में प्रस्तुतियों में चार्ट वर्कशीट फ़ॉर्मूले लागू करें
linktitle: वर्कशीट फ़ॉर्मूले
type: docs
weight: 70
url: /hi/php-java/chart-worksheet-formulas/
keywords:
- चार्ट स्प्रेडशीट
- चार्ट वर्कशीट
- चार्ट फ़ॉर्मूला
- वर्कशीट फ़ॉर्मूला
- स्प्रेडशीट फ़ॉर्मूला
- चार्ट डेटा वर्कबुक
- फ़ॉर्मूला गणना
- पसंदीदा संस्कृति
- संस्कृति‑विशिष्ट फ़ॉर्मूला
- DBCS
- लॉजिकल कॉन्स्टैंट
- संख्यात्मक कॉन्स्टैंट
- स्ट्रिंग कॉन्स्टैंट
- त्रुटि कॉन्स्टैंट
- अंकगणितीय ऑपरेटर
- तुलना ऑपरेटर
- A1 शैली
- R1C1 शैली
- पूर्वनिर्धारित फ़ंक्शन
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के चार्ट वर्कशीट्स में Excel-शैली के फ़ॉर्मूले लागू करें, मानों को पुनः गणना करें, और परिणामों को PowerPoint चार्ट्स में उपयोग करें।"
---
## **सारांश**

PowerPoint चार्ट आमतौर पर अपना स्रोत डेटा एक एम्बेडेड वर्कशीट में संग्रहीत करते हैं। Aspose.Slides for PHP via Java में आप उस वर्कशीट को चार्ट डेटा वर्कबुक के माध्यम से एक्सेस कर सकते हैं, इनपुट मान लिख सकते हैं, सेल्स को फ़ॉर्मूला असाइन कर सकते हैं, समर्थित फ़ॉर्मूला की गणना कर सकते हैं, और गणना किए गए सेल्स को चार्ट डेटा के रूप में उपयोग कर सकते हैं।

यह लेख पूर्ण फ़ॉर्मूला कार्यप्रवाह को समझाता है: एक चार्ट बनाना, उसकी वर्कशीट को भरना, A1‑स्टाइल या R1C1‑स्टाइल फ़ॉर्मूला असाइन करना, उन्हें पुनर्गणना करना, गणना किए गए मान पढ़ना, उन सेल्स को चार्ट श्रृंखला से जोड़ना, और प्रस्तुति सहेजना। इसमें समर्थित फ़ॉर्मूला सिंटैक्स, बिल्ट‑इन फ़ंक्शन उपसेट, कैश्ड मान, असमर्थित फ़ॉर्मूला, और स्प्रेडशीट‑विशिष्ट त्रुटियों का वर्णन भी है।

## **चार्ट वर्कशीट्स और फ़ॉर्मूले**

एक चार्ट वर्कशीट में उन श्रेणियों, श्रृंखला नामों, और मानों को रखता है जो चार्ट द्वारा उपयोग किए जाते हैं। PowerPoint में आप चार्ट डेटा एडिटर खोलकर वर्कशीट का निरीक्षण कर सकते हैं:

![एंबेडेड वर्कशीट खुला हुआ PowerPoint चार्ट, जिसमें श्रेणी और श्रृंखला डेटा दिखाया गया है](chart-worksheet-formulas_1.png)

Aspose.Slides में वर्कशीट को [ChartDataWorkbook](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/) क्लास के माध्यम से एक्सपोज़ किया गया है। A1‑स्टाइल फ़ॉर्मूला के लिए [ChartDataCell::setFormula](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatacell/#setFormula) और R1C1‑स्टाइल फ़ॉर्मूला के लिए [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatacell/#setR1C1Formula) का उपयोग करें। इनपुट सेल्स या फ़ॉर्मूला बदलने के बाद, समर्थित फ़ॉर्मूला को पुनर्गणना करने और संबद्ध सेल मान अपडेट करने के लिए [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) को कॉल करें।

एक गणना किया गया सेल अभी भी अपना परिणाम [ChartDataCell::getValue](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatacell/#getValue) के माध्यम से उजागर करता है। यह तब महत्वपूर्ण है जब आपको कोड में फ़ॉर्मूला परिणाम की जांच करनी हो या सेल को चार्ट डेटा पॉइंट के रूप में उपयोग करना हो।

## **एक चार्ट बनाना और वर्कशीट फ़ॉर्मूले की गणना करना**

निम्न उदाहरण एक अंत‑से‑अंत कार्यप्रवाह दर्शाता है। यह एक क्लस्टर्ड कॉलम चार्ट बनाता है, नमूना डेटा साफ़ करता है, तिमाही राजस्व और खर्च मान लिखता है, फ़ॉर्मूला से लाभ की गणना करता है, परिणाम पढ़ता है, गणना किए गए सेल्स को चार्ट मान के रूप में उपयोग करता है, और प्रस्तुति सहेजता है।

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 350);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $workbook->clear($worksheetIndex);

    $category1 = $workbook->getCell($worksheetIndex, "A2", "Q1");
    $category2 = $workbook->getCell($worksheetIndex, "A3", "Q2");
    $category3 = $workbook->getCell($worksheetIndex, "A4", "Q3");

    $workbook->getCell($worksheetIndex, "B1", "Revenue");
    $workbook->getCell($worksheetIndex, "C1", "Expenses");
    $workbook->getCell($worksheetIndex, "D1", "Profit");

    $workbook->getCell($worksheetIndex, "B2")->setValue(120.0);
    $workbook->getCell($worksheetIndex, "C2")->setValue(80.0);
    $workbook->getCell($worksheetIndex, "B3")->setValue(150.0);
    $workbook->getCell($worksheetIndex, "C3")->setValue(95.0);
    $workbook->getCell($worksheetIndex, "B4")->setValue(135.0);
    $workbook->getCell($worksheetIndex, "C4")->setValue(110.0);

    $profit1 = $workbook->getCell($worksheetIndex, "D2");
    $profit2 = $workbook->getCell($worksheetIndex, "D3");
    $profit3 = $workbook->getCell($worksheetIndex, "D4");

    $profit1->setFormula("B2-C2");
    $profit2->setFormula("B3-C3");
    $profit3->setFormula("B4-C4");

    $workbook->calculateFormulas();

    $q1Profit = java_values($profit1->getValue()); // 40
    $q2Profit = java_values($profit2->getValue()); // 55
    $q3Profit = java_values($profit3->getValue()); // 25

    echo "Q1 profit: " . $q1Profit . PHP_EOL;
    echo "Q2 profit: " . $q2Profit . PHP_EOL;
    echo "Q3 profit: " . $q3Profit . PHP_EOL;

    $chart->getChartData()->getCategories()->add($category1);
    $chart->getChartData()->getCategories()->add($category2);
    $chart->getChartData()->getCategories()->add($category3);

    $profitSeries = $chart->getChartData()->getSeries()->add($workbook->getCell($worksheetIndex, "D1"), $chart->getType());
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit1);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit2);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit3);
    $profitSeries->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("chart-formulas.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

चार्ट डेटा पॉइंट्स `D2:D4` को संदर्भित करते हैं, इसलिए चार्ट गणना किए गए लाभ मानों का उपयोग करता है। इस कार्यप्रवाह में कोई अलग चार्ट‑रीफ़्रेश कॉल नहीं है: पहले वर्कबुक को पुनर्गणना करें, फिर गणना किए गए सेल्स को उपयोग या सहेजें।

## **A1‑स्टाइल फ़ॉर्मूले उपयोग करना**

A1 नोटेशन कॉलम को अक्षरों से और पंक्तियों को संख्याओं से पहचानता है। [ChartDataCell::setFormula](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatacell/#setFormula) के माध्यम से A1‑स्टाइल अभिव्यक्तियों को असाइन करें।

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "C3")->setValue(10);
    $workbook->getCell(0, "F2")->setValue(2);
    $workbook->getCell(0, "G2")->setValue(3);
    $workbook->getCell(0, "H2")->setValue(4);

    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("C3+SUM(F2:H2)");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 19
} finally {
    $presentation->dispose();
}
```

सामान्य A1 रेफ़रेंस रूप इस प्रकार हैं:

| रेफ़रेंस | रिलेटिव | एब्सॉल्यूट | मिक्स्ड |
|---|---|---|---|
| सेल | `A2` | `$A$2` | `A$2`, `$A2` |
| पंक्ति | `2:2` | `$2:$2` | — |
| कॉलम | `A:A` | `$A:$A` | — |
| रेंज | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

रिलेटिव रेफ़रेंस स्प्रेडशीट एप्लिकेशन द्वारा फ़ॉर्मूला को ले जाएँ या कॉपी करें तो बदल सकते हैं। एब्सॉल्यूट रेफ़रेंस दोनों निर्देशांक को स्थिर रखता है, जबकि मिक्स्ड रेफ़रेंस केवल पंक्ति या कॉलम को स्थिर करता है।

## **R1C1‑स्टाइल फ़ॉर्मूले उपयोग करना**

R1C1 नोटेशन पंक्तियों और कॉलम दोनों को संख्यात्मक रूप से पहचानता है। रिलेटिव रेफ़रेंस वर्ग कोष्ठकों में ऑफसेट का उपयोग करता है। इस सिंटैक्स को [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatacell/#setR1C1Formula) के माध्यम से असाइन करें।

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "B2")->setValue(12);
    $workbook->getCell(0, "C2")->setValue(5);

    $cell = $workbook->getCell(0, "D2");
    $cell->setR1C1Formula("RC[-2]-RC[-1]");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 7
} finally {
    $presentation->dispose();
}
```

सामान्य R1C1 रेफ़रेंस रूप इस प्रकार हैं:

| रेफ़रेंस | रिलेटिव | एब्सॉल्यूट | मिक्स्ड |
|---|---|---|---|
| सेल | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| पंक्ति | `R[2]` | `R2` | — |
| कॉलम | `C[3]` | `C3` | — |
| रेंज | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

उदाहरण के लिए, सेल `D2` में `RC[-2]` का अर्थ है उसी पंक्ति में दो कॉलम बाएँ स्थित सेल (`B2`)।

## **फ़ॉर्मूला कॉन्स्टैंट्स और ऑपरेटर्स**

बिल्ट‑इन फ़ॉर्मूला इवाल्युएटर लॉजिकल मान, न्यूमेरिक लिटेरल, स्ट्रिंग, स्प्रेडशीट त्रुटि मान, अंकगणितीय ऑपरेटर और तुलना ऑपरेटर को समर्थन देता है।

### **कॉन्स्टैंट्स और लिटेरल्स**

| प्रकार | उदाहरण | नोट |
|---|---|---|
| लॉजिकल | `TRUE`, `FALSE` | सीधे लॉजिकल अभिव्यक्तियों में उपयोग किया जा सकता है जैसे `A2=TRUE`। |
| न्यूमेरिक | `1`, `0.5`, `.3`, `1E-2` | सामान्य तथा वैज्ञानिक नोटेशन समर्थित हैं। |
| स्ट्रिंग | `"abc"`, `"2/3/2020 12:00"` | फ़ॉर्मूला के भीतर डबल कोट्स में टेक्स्ट लिटेरल होते हैं। |
| एरर रिज़ल्ट | `#DIV/0!`, `#N/A`, `#REF!` | एक वैध फ़ॉर्मूला सामान्य परिणाम के बजाय स्प्रेडशीट एरर वैल्यू पर मूल्यांकन हो सकता है। |

यह उदाहरण कई कॉन्स्टैंट प्रकारों का उपयोग करता है:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "A2")->setValue(false);
    $workbook->getCell(0, "B2")->setFormula("A2=TRUE");
    $workbook->getCell(0, "C2")->setFormula("1+0.5");
    $workbook->getCell(0, "D2")->setFormula(".3*1E-2");
    $workbook->getCell(0, "E2")->setFormula("\"abc\"");
    $workbook->getCell(0, "F2")->setFormula("2/0");

    $workbook->calculateFormulas();

    $logicalValue = java_values($workbook->getCell(0, "B2")->getValue()); // false
    $numericValue = java_values($workbook->getCell(0, "C2")->getValue()); // 1.5
    $scientificValue = java_values($workbook->getCell(0, "D2")->getValue()); // 0.003
    $stringValue = java_values($workbook->getCell(0, "E2")->getValue()); // abc
    $errorValue = java_values($workbook->getCell(0, "F2")->getValue()); // #DIV/0!
} finally {
    $presentation->dispose();
}
```

### **अंकगणितीय ऑपरेटर्स**

| ऑपरेटर | अर्थ | उदाहरण |
|---|---|---|
| `+` | जोड़ या यूनरी प्लस | `2+3` |
| `-` | घटाव या नेगेशन | `2-3`, `-3` |
| `*` | गुणन | `2*3` |
| `/` | भाग | `2/3` |
| `%` | प्रतिशत | `30%` |
| `^` | घातांक | `2^3` |

मूल्यांकन क्रम को स्पष्ट करने के लिए कोष्ठक का उपयोग करें, उदाहरण ` (A2+B2)*C2`।

### **तुलना ऑपरेटर्स**

तुलना अभिव्यक्तियाँ लॉजिकल मान लौटाती हैं।

| ऑपरेटर | अर्थ | उदाहरण |
|---|---|---|
| `=` | बराबर | `A2=3` |
| `<>` | बराबर नहीं | `A2<>3` |
| `>` | बड़ा | `A2>3` |
| `>=` | बड़ा या बराबर | `A2>=3` |
| `<` | छोटा | `A2<3` |
| `<=` | छोटा या बराबर | `A2<=3` |

## **समर्थित प्री‑डिफाइंड फ़ंक्शनस**

Aspose.Slides चार्ट वर्कशीट्स के लिए एक बिल्ट‑इन फ़ॉर्मूला इवाल्युएटर शामिल करता है, लेकिन यह पूर्ण Excel गणना इंजन नहीं है। दस्तावेज़ित फ़ंक्शन सेट नीचे दिए गए फ़ंक्शन्स तक सीमित है। यह न मानें कि कोई भी मनचाहा Excel फ़ंक्शन [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) द्वारा पुनर्गणना किया जा सकता है।

| फ़ंक्शन | उद्देश्य या समर्थित रूप | उदाहरण |
|---|---|---|
| `ABS` | एब्सॉल्यूट वैल्यू | `ABS(A2)` |
| `AVERAGE` | अंकगणितीय औसत | `AVERAGE(B2:B5)` |
| `CEILING` | संख्या को ऊपर की ओर मल्टीपल तक राउंड | `CEILING(A2,5)` |
| `CHOOSE` | इंडेक्स द्वारा मान चुनना | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | टेक्स्ट मानों को जोड़ना | `CONCAT(A2,B2)` |
| `CONCATENATE` | टेक्स्ट मानों को जोड़ना | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 डेट सिस्टम का उपयोग करके डेट वैल्यू बनाना | `DATE(2026,8,19)` |
| `DAYS` | दो डेट्स के बीच दिनों की संख्या | `DAYS(B2,A2)` |
| `FIND` | एक टेक्स्ट मान को दूसरे में खोजना | `FIND("-",A2)` |
| `FINDB` | बाइट‑ओरिएंटेड टेक्स्ट सर्च | `FINDB("a",A2)` |
| `IF` | शर्तीय परिणाम | `IF(A2>0,A2,0)` |
| `INDEX` | रेफ़रेंस फ़ॉर्म | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | वेक्टर फ़ॉर्म | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | वेक्टर फ़ॉर्म | `MATCH(A2,B2:B5,0)` |
| `MAX` | अधिकतम मान | `MAX(B2:B5)` |
| `SUM` | मानों का योग | `SUM(B2:B5)` |
| `VLOOKUP` | वर्टिकल लुकअप | `VLOOKUP(A2,B2:D10,3,FALSE)` |

तालिका में दिखाए गए प्रतिबंध महत्त्वपूर्ण हैं: `INDEX` रेफ़रेंस फ़ॉर्म में दस्तावेज़ित है, जबकि `LOOKUP` और `MATCH` अपने वेक्टर फ़ॉर्म में हैं। `DATE` 1900 डेट सिस्टम का उपयोग करता है। यहाँ सूचीबद्ध न किए गए फ़ीचर्स और फ़ंक्शन्स को Aspose.Slides फ़ॉर्मूला इवाल्युएटर द्वारा असमर्थित माना जाना चाहिए, जब तक कि अलग से दस्तावेज़ित न हों।

## **प्रीफ़रड कल्चर के साथ फ़ॉर्मूला की गणना**

कुछ चार्ट वर्कबुक फ़ंक्शन्स टेक्स्ट को संस्कृति‑विशिष्ट नियमों के अनुसार इंटरप्रेट करते हैं। यह विशेष रूप से उन फ़ंक्शन्स के लिए महत्वपूर्ण है जो डबल‑बाइट कैरेक्टर सेट (DBCS) वाले भाषाओं के लिए होते हैं। ऐसी फ़ॉर्मूला को सही ढंग से गणना करने के लिए, [LoadOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/) बनाकर, [SpreadsheetOptions::setPreferredCulture](https://reference.aspose.com/slides/hi/php-java/aspose.slides/spreadsheetoptions/#setPreferredCulture) के साथ प्रीफ़रड कल्चर सेट करके, [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/loadoptions/#setSpreadsheetOptions) के माध्यम से स्प्रेडशीट विकल्प असाइन करके, और फिर प्रस्तुति लोड करें।

निम्न उदाहरण जापानी कल्चर को चुनता है, कॉन्फ़िगर किए गए लोड ऑप्शन्स के साथ प्रस्तुति खोलता है, और प्रत्येक चार्ट वर्कबुक के लिए [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) को कॉल करता है:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SpreadsheetOptions;

$japaneseCulture = new Java("java.util.Locale", "ja", "JP");

$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setPreferredCulture($japaneseCulture);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$chartClass = new JavaClass("com.aspose.slides.IChart");
$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, $chartClass)) {
                $shape->getChartData()->getChartDataWorkbook()->calculateFormulas();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

प्रीफ़रड कल्चर प्रस्तुति लोडिंग कॉन्फ़िगरेशन का हिस्सा है, इसलिए [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) इंस्टेंस बनाने से पहले इसे निर्दिष्ट करें। वर्कबुक फ़ॉर्मूला द्वारा अपेक्षित संस्कृति का उपयोग करें; उदाहरण के लिए, जापानी DBCS गणना नियमों के लिए `ja-JP` उपयोग करें।

## **पुनर्गणना और कैश्ड वैल्यूज**

स्प्रेडशीट फ़ाइलें सामान्यतः फ़ॉर्मूला और उसकी अंतिम गणना मान दोनों को संग्रहीत करती हैं। Aspose.Slides इस कारण [ChartDataCell::getValue](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatacell/#getValue) से कैश्ड वैल्यू पढ़ सकता है जब प्रस्तुति लोड की गई हो और संबंधित चार्ट डेटा बदला न गया हो।

इनपुट सेल्स या फ़ॉर्मूला बदलने के बाद, पुराने कैश्ड परिणाम पर भरोसा न करें। गणना किए गए मान पढ़ने या उन पर निर्भर करके चार्ट डेटा सहेजने से पहले [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) को कॉल करें।

समर्थित उपसेट से बाहर के फ़ॉर्मूला के लिए, Aspose.Slides फ़ॉर्मूला को पार्स नहीं कर सकता या उसकी निर्भरताएँ स्थापित नहीं कर सकता। यदि वर्कबुक बदला गया है, तो पूर्व कैश्ड मान अब विश्वसनीय नहीं रहता। ऐसी स्थिति में, असमर्थित डेटा वाले सेल के मान को पढ़ना [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cellunsupporteddataexception/) को उठा सकता है।

यदि आपका चार्ट ऐसे Excel फ़ंक्शन पर निर्भर करता है जिनको Aspose.Slides मूल्यांकित नहीं करता, तो उन फ़ॉर्मूले को किसी सपोर्टेड स्प्रेडशीट इंजन से गणना करके परिणाम को चार्ट वर्कबुक में वापस लिखें। असमर्थित फ़ॉर्मूले को अनुमानित मानों से बदलें नहीं।

## **फ़ॉर्मूला एरर को हैंडल करना**

दो प्रकार की समस्याओं को अलग-अलग पहचानना आवश्यक है।

फ़ॉर्मूला वैध हो सकता है लेकिन स्प्रेडशीट एरर परिणाम जैसे `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, या `#VALUE!` उत्पन्न कर सकता है। इस मामले में, एरर टोकन एक सेल परिणाम होता है और इसे [ChartDataCell::getValue](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatacell/#getValue) के माध्यम से प्राप्त किया जा सकता है।

फ़ॉर्मूला पार्सिंग, रेफ़रेंस, निर्भरता, या समर्थित‑डेटा स्तर पर भी फेल हो सकता है। इन मामलों के लिए Aspose.Slides स्प्रेडशीट‑विशिष्ट एक्सेप्शन प्रदान करता है: [CellInvalidFormulaException](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cellcircularreferenceexception/), और [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cellunsupporteddataexception/)।

PHP via Java में, Java एक्सेप्शन को `JavaException` के माध्यम से सतह पर लाया जाता है। जब फ़ॉर्मूले टेम्पलेट या उपयोगकर्ता इनपुट से आते हैं, तो पुनर्गणना और वैल्यू एक्सेस के दौरान इन्हें संभालें। स्टैक ट्रेस में रिपोर्ट किया गया Java एक्सेप्शन विशिष्ट स्प्रेडशीट विफलता को इंगित करता है:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("SUM(B2:B5)");

    try {
        $workbook->calculateFormulas();
        echo java_values($cell->getValue()) . PHP_EOL;
    } catch (JavaException $ex) {
        $ex->printStackTrace();
    }
} finally {
    $presentation->dispose();
}
```

## **व्यावहारिक सीमाएँ**

चार्ट वर्कशीट में फ़ॉर्मूला सपोर्ट एक परिभाषित उपसेट के लिए है, न कि पूर्ण Excel संगतता के लिये। रिपोर्टिंग कार्यप्रवाह डिजाइन करते समय इन बंधनों को ध्यान में रखें:

- जब आपको Aspose.Slides से फ़ॉर्मूला पुनर्गणना चाहिए, तो केवल दस्तावेज़ित कॉन्स्टैंट, ऑपरेटर, रेफ़रेंस और फ़ंक्शन उपयोग करें।
- उन सेल्स को बदलने के बाद पुनर्गणना करें जिनपर फ़ॉर्मूला परिणाम निर्भर करता है।
- लोड की गई प्रस्तुतियों से प्राप्त कैश्ड वैल्यू को स्नैपशॉट मानें, एडिट के बाद पुनर्गणना के विकल्प के रूप में नहीं।
- मौजूदा टेम्पलेट्स से फ़ॉर्मूला का परीक्षण करें, विशेषकर उन फ़ंक्शन्स के साथ जो दस्तावेज़ित सूची से बाहर हैं।
- यदि फ़ॉर्मूला को पूर्ण स्प्रेडशीट गणना इंजन की आवश्यकता है, तो उन्हें बाहरी रूप से गणना करें और फिर चार्ट वर्कबुक को परिणाम से अपडेट करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**[ChartDataCell::setFormula](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatacell/#setFormula) और [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatacell/#setR1C1Formula) में क्या अंतर है?**

[ChartDataCell::setFormula](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatacell/#setFormula) `B2-C2` जैसी A1‑स्टाइल अभिव्यक्ति संग्रहीत करता है। [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatacell/#setR1C1Formula) `RC[-2]-RC[-1]` जैसी R1C1‑स्टाइल अभिव्यक्ति संग्रहीत करता है। वह नोटेशन चुनें जो आपके फ़ॉर्मूला जनरेट या कॉपी करने के तरीके से अधिक मेल खाता हो।

**क्या मुझे गणना के बाद सेल स्वयं पढ़नी चाहिए या उसका वैल्यू?**

[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/#getCell) एक [ChartDataCell](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatacell/) लौटाता है। गणना किए गए परिणाम को प्राप्त करने के लिए पुनर्गणना के बाद उस सेल के [ChartDataCell::getValue](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatacell/#getValue) को कॉल करें।

**कब मुझे [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) को कॉल करना चाहिए?**

इनपुट मान या फ़ॉर्मूला बदलने के बाद और गणना किए गए परिणामों पर निर्भर करने से पहले [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) को कॉल करें। यह बिल्ट‑इन इवाल्युएटर द्वारा समर्थित फ़ॉर्मूला के मान अपडेट करता है।

**क्या Aspose.Slides हर Excel फ़ंक्शन को सपोर्ट करता है?**

नहीं। बिल्ट‑इन इवाल्युएटर दस्तावेज़ित फ़ंक्शन उपसेट को ही सपोर्ट करता है। उस उपसेट से बाहर के फ़ंक्शन को पुनर्गणना मानने की धारणा नहीं रखनी चाहिए। यदि पूर्ण Excel फ़ॉर्मूला संगतता आवश्यक है, तो उपयुक्त स्प्रेडशीट इंजन से गणना कर अंतिम मान को चार्ट वर्कबुक में लिखें।

**यदि लोड की गई प्रस्तुति में असमर्थित फ़ॉर्मूला हो तो क्या होता है?**

यदि चार्ट डेटा नहीं बदला है, तो वर्कबुक में पहले से गणना किया गया कैश्ड वैल्यू मौजूद हो सकता है। संबंधित डेटा संशोधित होने पर वह कैश्ड वैल्यू अब वैध नहीं रह सकता। जिस सेल का फ़ॉर्मूला संभाला नहीं जा सकता, उसे पढ़ने से [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cellunsupporteddataexception/) उत्पन्न हो सकता है।

**क्या फ़ॉर्मूला एरर वैल्यूज PHP एक्सेप्शन के बराबर हैं?**

नहीं। `#DIV/0!` जैसा परिणाम वैध गणना द्वारा उत्पन्न स्प्रेडशीट वैल्यू है। जैसे [CellInvalidFormulaException](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cellinvalidformulaexception/) या [CellCircularReferenceException](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cellcircularreferenceexception/) जैसी स्प्रेडशीट‑प्रोसेसिंग विफलताएँ Java एक्सेप्शन हैं जो `JavaException` के माध्यम से PHP में सतह पर आती हैं।

**क्या फ़ॉर्मूला वाले सेल बदलने पर चार्ट स्वतः अपडेट होता है?**

एक चार्ट श्रृंखला वर्कबुक सेल्स को रेफ़रेंस कर सकती है। पहले वर्कबुक को पुनर्गणना करें, फिर प्रस्तुति सहेजें या रेंडर करें। यदि चार्ट डेटा पॉइंट्स गणना किए गए सेल्स को रेफ़रेंस करते हैं, तो चार्ट उन अद्यतन सेल मानों का उपयोग करेगा; इस कार्यप्रवाह के लिए कोई अलग चार्ट‑रीफ़्रेश मेथड आवश्यक नहीं है।

**क्या चार्ट बाहरी Excel वर्कबुक का उपयोग कर सकते हैं?**

हाँ, चार्ट डेटा को चार्ट डेटा API के माध्यम से बाहरी वर्कबुक से कॉन्फ़िगर किया जा सकता है। हालांकि, इस लेख में वर्णित फ़ॉर्मूला गणना कार्यप्रवाह केवल चार्ट डेटा वर्कबुक और Aspose.Slides द्वारा मूल्यांकित फ़ॉर्मूला उपसेट से संबंधित है। यह न मानें कि [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) बाहरी XLSX फ़ाइल में मनचाहे फ़ॉर्मूला की पूर्ण पुनर्गणना प्रदान करता है।

**क्या मैं ऐसे फ़ॉर्मूला उपयोग कर सकता हूँ जो किसी अन्य वर्कशीट या वर्कबुक को रेफ़रेंस करते हों?**

Excel‑स्टाइल रेफ़रेंस चार्ट वर्कबुक में मौजूद हो सकते हैं, लेकिन फ़ॉर्मूला मूल्यांकन समर्थित पार्सर और फ़ंक्शन सेट तक सीमित है। यदि क्रॉस‑शीट या एक्सटर्नल रेफ़रेंस आवश्यक है, तो अपने लक्षित Aspose.Slides संस्करण के साथ उस फ़ॉर्मूला को सत्यापित करें। व्यापक Excel रेफ़रेंस संगतता वाली कार्यप्रवाह के लिए, वर्कबुक को बाहरी रूप से गणना करें और हल किए हुए मानों को चार्ट डेटा में लिखें।

**क्या फ़ॉर्मूला स्ट्रिंग्स को `=` से शुरू होना चाहिए?**

Aspose.Slides API उदाहरण `B2-C2` या `SUM(B2:B5)` जैसी अभिव्यक्तियों को बिना लीडिंग `=` के असाइन करते हैं। इस रूप का उपयोग करने से जेनरेट किए गए फ़ॉर्मूला API दस्तावेज़ में दिखाए गए उदाहरणों के साथ संगत रहते हैं।