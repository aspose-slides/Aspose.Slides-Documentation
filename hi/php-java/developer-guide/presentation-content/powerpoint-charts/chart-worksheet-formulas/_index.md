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
- तर्कात्मक स्थिरांक
- संख्यात्मक स्थिरांक
- स्ट्रिंग स्थिरांक
- त्रुटि स्थिरांक
- अंकगणितीय ऑपरेटर
- तुलना ऑपरेटर
- A1 शैली
- R1C1 शैली
- पूर्वपरिभाषित फ़ंक्शन
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Java चार्ट वर्कशीट के माध्यम से PHP के लिए Aspose.Slides में Excel‑शैली के फ़ॉर्मूले लागू करें, मानों की पुनः‑गणना करें, और परिणामों को PowerPoint चार्ट्स में उपयोग करें।"
---
## **सारांश**

PowerPoint चार्ट आमतौर पर अपना स्रोत डेटा एम्बेडेड वर्कशीट में संग्रहीत करते हैं। Aspose.Slides for PHP via Java में आप चार्ट डेटा वर्कबुक के माध्यम से उस वर्कशीट तक पहुँच सकते हैं, इनपुट मान लिख सकते हैं, कोशिकाओं को फ़ॉर्मूले असाइन कर सकते हैं, समर्थित फ़ॉर्मूलों की गणना कर सकते हैं, और गणना किए गए कोशिकाओं को चार्ट डेटा के रूप में उपयोग कर सकते हैं।

यह लेख पूर्ण फ़ॉर्मूला वर्कफ़्लो को समझाता है: एक चार्ट बनाना, उसकी वर्कशीट को भरना, A1‑स्टाइल या R1C1‑स्टाइल फ़ॉर्मूले असाइन करना, उन्हें पुनः‑गणना करना, गणना किए गए मूल्यों को पढ़ना, उन कोशिकाओं को चार्ट श्रृंखला से जोड़ना, और प्रस्तुति को सहेजना। यह समर्थित फ़ॉर्मूला सिंटैक्स, बिल्ट‑इन फ़ंक्शन उपसमुच्चय, कैश्ड मान, असमर्थित फ़ॉर्मूलों और स्प्रेडशीट‑विशिष्ट त्रुटियों का भी वर्णन करता है।

## **चार्ट वर्कशीट और फ़ॉर्मूले**

एक चार्ट वर्कशीट में उन श्रेणियों, श्रृंखला नामों और मानों को शामिल किया जाता है जो चार्ट द्वारा उपयोग किए जाते हैं। PowerPoint में आप चार्ट डेटा एडिटर खोलकर वर्कशीट की जाँच कर सकते हैं:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

Aspose.Slides में वर्कशीट को [ChartDataWorkbook](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/) क्लास के माध्यम से एक्सपोज़ किया जाता है। A1‑स्टाइल फ़ॉर्मूलों के लिए [ChartDataCell::setFormula](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatacell/#setFormula) और R1C1‑स्टाइल फ़ॉर्मूलों के लिए [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatacell/#setR1C1Formula) का उपयोग करें। इनपुट कोशिकाओं या फ़ॉर्मूलों को बदलने के बाद, समर्थित फ़ॉर्मूलों को पुनः‑गणना करने और संबंधित कोशिका मानों को अद्यतन करने के लिए [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) को कॉल करें।

एक गणना की गई कोशिका अपना परिणाम अभी भी [ChartDataCell::getValue](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatacell/#getValue) के माध्यम से उजागर करती है। यह महत्वपूर्ण है जब आपको कोड में फ़ॉर्मूला परिणाम की जाँच करनी हो या कोशिका को चार्ट डेटा पॉइंट के रूप में उपयोग करना हो।

## **एक चार्ट बनाना और वर्कशीट फ़ॉर्मूलों की गणना करना**

निम्न उदाहरण एक एन्ड‑टू‑एन्ड वर्कफ़्लो प्रदर्शित करता है। यह एक क्लस्टर्ड कॉलम चार्ट बनाता है, नमूना डेटा साफ़ करता है, तिमाही राजस्व और खर्च मान लिखता है, फ़ॉर्मूलों के साथ लाभ की गणना करता है, परिणाम पढ़ता है, गणना की गई कोशिकाओं को चार्ट मानों के रूप में उपयोग करता है, और प्रस्तुति को सहेजता है।

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

चार्ट डेटा पॉइंट `D2:D4` को संदर्भित करते हैं, इसलिए चार्ट गणना किए गए लाभ मानों का उपयोग करता है। इस वर्कफ़्लो में कोई अलग चार्ट‑रीफ़्रेश कॉल नहीं है: पहले वर्कबुक को पुनः‑गणना करें, फिर गणना किए गए कोशिकाओं को उपयोग या सहेजें।

## **A1‑स्टाइल फ़ॉर्मूले का उपयोग करें**

A1 नोटेशन अक्षरों से कॉलम और संख्याओं से पंक्तियों को पहचानता है। [ChartDataCell::setFormula](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatacell/#setFormula) के माध्यम से A1‑स्टाइल अभिव्यक्तियों को असाइन करें।

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

सामान्य A1 संदर्भ रूपों का सारणी इस प्रकार है:

| संदर्भ | सापेक्ष | निश्चित | मिश्रित |
|---|---|---|---|
| कोशिका | `A2` | `$A$2` | `A$2`, `$A2` |
| पंक्ति | `2:2` | `$2:$2` | — |
| कॉलम | `A:A` | `$A:$A` | — |
| रेंज | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

सापेक्ष संदर्भ स्प्रेडशीट एप्लिकेशन द्वारा फ़ॉर्मूले को स्थानांतरित या कॉपी करने पर बदल सकते हैं। निश्चित संदर्भ दोनों निर्देशांक को स्थिर रखते हैं, जबकि मिश्रित संदर्भ केवल पंक्ति या कॉलम को स्थिर करते हैं।

## **R1C1‑स्टाइल फ़ॉर्मूले का उपयोग करें**

R1C1 नोटेशन पंक्तियों और कॉलम दोनों को संख्यात्मक रूप से पहचानता है। सापेक्ष संदर्भ स्क्वायर ब्रैकेट में ऑफसेट का उपयोग करते हैं। इस सिंटैक्स को [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatacell/#setR1C1Formula) के माध्यम से असाइन करें।

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

सामान्य R1C1 संदर्भ रूपों का सारणी इस प्रकार है:

| संदर्भ | सापेक्ष | निश्चित | मिश्रित |
|---|---|---|---|
| कोशिका | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| पंक्ति | `R[2]` | `R2` | — |
| कॉलम | `C[3]` | `C3` | — |
| रेंज | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

उदाहरण के लिए, कोशिका `D2` में `RC[-2]` का मतलब है उसी पंक्ति में दो कॉलम बाएँ वाली कोशिका (`B2`)।

## **फ़ॉर्मूला स्थिरांक और ऑपरेटर**

बिल्ट‑इन फ़ॉर्मूला इवैल्युएटर तर्कात्मक मान, संख्यात्मक लिटरल, स्ट्रिंग, स्प्रेडशीट त्रुटि मान, अंकगणितीय ऑपरेटर और तुलना ऑपरेटर को सपोर्ट करता है।

### **स्थिरांक और लिटरल**

| प्रकार | उदाहरण | टिप्पणी |
|---|---|---|
| तर्कात्मक | `TRUE`, `FALSE` | `A2=TRUE` जैसी तर्कात्मक अभिव्यक्तियों में सीधे उपयोग किया जा सकता है। |
| संख्यात्मक | `1`, `0.5`, `.3`, `1E-2` | सामान्य और वैज्ञानिक नोटेशन दोनों समर्थित हैं। |
| स्ट्रिंग | `"abc"`, `"2/3/2020 12:00"` | स्ट्रिंग लिटरल फ़ॉर्मूला के भीतर दोहरे उद्धरण चिह्नों में होते हैं। |
| त्रुटि परिणाम | `#DIV/0!`, `#N/A`, `#REF!` | एक वैध फ़ॉर्मूला सामान्य परिणाम के बजाय स्प्रेडशीट त्रुटि मान में मूल्यांकित हो सकता है। |

यह उदाहरण कई स्थिरांक प्रकारों का उपयोग करता है:

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

    $logicalValue = java_values($workbook->getCell(0, "B2")->getValue()); // गलत
    $numericValue = java_values($workbook->getCell(0, "C2")->getValue()); // 1.5
    $scientificValue = java_values($workbook->getCell(0, "D2")->getValue()); // 0.003
    $stringValue = java_values($workbook->getCell(0, "E2")->getValue()); // abc
    $errorValue = java_values($workbook->getCell(0, "F2")->getValue()); // #DIV/0!
} finally {
    $presentation->dispose();
}
```

### **अंकगणितीय ऑपरेटर**

| ऑपरेटर | अर्थ | उदाहरण |
|---|---|---|
| `+` | जोड़ या यूनरी प्लस | `2+3` |
| `-` | घटाना या निरपेक्ष | `2-3`, `-3` |
| `*` | गुणा | `2*3` |
| `/` | भाग | `2/3` |
| `%` | प्रतिशत | `30%` |
| `^` | घातांक | `2^3` |

मूल्यांकन क्रम स्पष्ट करने के लिए कोष्ठक उपयोग करें, उदाहरण ` (A2+B2)*C2`।

### **तुलना ऑपरेटर**

तुलना अभिव्यक्तियां तर्कात्मक मान लौटाती हैं।

| ऑपरेटर | अर्थ | उदाहरण |
|---|---|---|
| `=` | बराबर | `A2=3` |
| `<>` | बराबर नहीं | `A2<>3` |
| `>` | बड़ा | `A2>3` |
| `>=` | बड़ा या बराबर | `A2>=3` |
| `<` | छोटा | `A2<3` |
| `<=` | छोटा या बराबर | `A2<=3` |

## **समर्थित पूर्वपरिभाषित फ़ंक्शन**

Aspose.Slides चार्ट वर्कशीट के लिए बिल्ट‑इन फ़ॉर्मूला इवैल्युएटर प्रदान करता है, लेकिन यह पूर्ण Excel गणना इंजन नहीं है। दस्तावेज़ित फ़ंक्शन सेट नीचे सूचीबद्ध फ़ंक्शनों तक सीमित है। यह न मानें कि कोई भी मनमाना Excel फ़ंक्शन [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) द्वारा पुनः‑गणना किया जा सकता है।

| फ़ंक्शन | उद्देश्य या समर्थित रूप | उदाहरण |
|---|---|---|
| `ABS` | निरपेक्ष मान | `ABS(A2)` |
| `AVERAGE` | औसत | `AVERAGE(B2:B5)` |
| `CEILING` | संख्या को ऊपर की ओर निकटतम गुणक तक राउंड | `CEILING(A2,5)` |
| `CHOOSE` | सूचक द्वारा मान चयन | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | टेक्स्ट मान जोड़ना | `CONCAT(A2,B2)` |
| `CONCATENATE` | टेक्स्ट मान जोड़ना | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 तिथि प्रणाली का उपयोग करके तिथि बनाना | `DATE(2026,8,19)` |
| `DAYS` | दो तिथियों के बीच दिनों की संख्या | `DAYS(B2,A2)` |
| `FIND` | एक टेक्स्ट मान को दूसरे में खोजना | `FIND("-",A2)` |
| `FINDB` | बाइट‑ऑरिएंटेड टेक्स्ट खोज | `FINDB("a",A2)` |
| `IF` | शर्तीय परिणाम | `IF(A2>0,A2,0)` |
| `INDEX` | संदर्भ रूप | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | वेक्टर रूप | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | वेक्टर रूप | `MATCH(A2,B2:B5,0)` |
| `MAX` | अधिकतम मान | `MAX(B2:B5)` |
| `SUM` | योग | `SUM(B2:B5)` |
| `VLOOKUP` | ऊर्ध्वाधर खोज | `VLOOKUP(A2,B2:D10,3,FALSE)` |

टेबल में दिखाए गए प्रतिबंध महत्वपूर्ण हैं: `INDEX` को संदर्भ रूप में दस्तावेज़ित किया गया है, जबकि `LOOKUP` और `MATCH` को वेक्टर रूप में। `DATE` 1900 तिथि प्रणाली उपयोग करता है। यहाँ न सूचीबद्ध फ़ंक्शन को Aspose.Slides फ़ॉर्मूला इवैल्युएटर द्वारा असमर्थित माना जाना चाहिए, जब तक कि वे अलग से दस्तावेज़ित न हों।

## **पुनः‑गणना और कैश्ड मान**

स्प्रेडशीट फ़ाइलें अक्सर फ़ॉर्मूला और उसके अंतिम गणितीय मान दोनों को संग्रहीत करती हैं। Aspose.Slides प्रस्तुति लोड होने पर और संबंधित चार्ट डेटा बदल ना जाने पर [ChartDataCell::getValue](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatacell/#getValue) से कैश्ड मान पढ़ सकता है।

इनपुट कोशिकाओं या फ़ॉर्मूलों को बदलने के बाद, पुराने कैश्ड परिणाम पर निर्भर न रहें। गणना किए गए मान पढ़ने या उन पर निर्भर होने वाले चार्ट डेटा को सहेजने से पहले [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) को कॉल करें।

समर्थित उपसमुच्चय से बाहर के फ़ॉर्मूले के लिए, Aspose.Slides फ़ॉर्मूले को पार्स करने या उसकी निर्भरताओं को स्थापित करने में असमर्थ हो सकता है। यदि वर्कबुक संशोधित हुई है, तो पहले का कैश्ड मान अब भरोसेमंद नहीं माना जा सकता। ऐसी स्थिति में, असमर्थित डेटा वाली कोशिका का मान पढ़ने से [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cellunsupporteddataexception/) उठ सकता है।

यदि आपका चार्ट ऐसे Excel फ़ंक्शन पर निर्भर है जो Aspose.Slides नहीं मूल्यांकन करता, तो उन फ़ॉर्मूलों की गणना किसी ऐसे स्प्रेडशीट इंजन से करें जो उन्हें सपोर्ट करता हो और परिणामित मानों को चार्ट वर्कबुक में लिखें। असमर्थित फ़ॉर्मूलों को अनुमानित मानों से बदलें नहीं।

## **फ़ॉर्मूला त्रुटियों को संभालें**

दो प्रकार की समस्याएं अलग‑अलग पहचानने की आवश्यकता है।

एक फ़ॉर्मूला वैध हो सकता है लेकिन `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` या `#VALUE!` जैसी स्प्रेडशीट त्रुटि परिणाम दे सकता है। इस स्थिति में त्रुटि टोकन एक कोशिका परिणाम है और इसे [ChartDataCell::getValue](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatacell/#getValue) के माध्यम से लौटाया जा सकता है।

एक फ़ॉर्मूला पार्सिंग, संदर्भ, निर्भरता या समर्थित‑डेटा स्तर पर भी विफल हो सकता है। Aspose.Slides इन मामलों के लिए स्प्रेडशीट‑विशिष्ट अपवाद प्रदान करता है: [CellInvalidFormulaException](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cellcircularreferenceexception/), और [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cellunsupporteddataexception/)।

PHP via Java में, Java अपवाद `JavaException` के माध्यम से दिखाए जाते हैं। जब फ़ॉर्मूले टेम्पलेट या उपयोगकर्ता इनपुट से आते हैं, तो पुनः‑गणना और मान एक्सेस के चारों ओर इनका हैंडलिंग करें। स्टैक ट्रेस में रिपोर्ट किया गया Java अपवाद विशिष्ट स्प्रेडशीट विफलता को दर्शाता है:

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

## **व्यावहारिक सीमाएं**

चार्ट वर्कशीट में फ़ॉर्मूला समर्थन एक परिभाषित उपसमुच्चय के लिए है, न कि पूर्ण Excel संगतता के लिए। रिपोर्टिंग वर्कफ़्लो डिज़ाइन करते समय इन प्रतिबंधों को ध्यान में रखें:

- केवल दस्तावेज़ित स्थिरांक, ऑपरेटर, संदर्भ और फ़ंक्शन का उपयोग करें जब आपको Aspose.Slides से फ़ॉर्मूलों की पुनः‑गणना चाहिए।
- उन कोशिकाओं को बदलने के बाद पुनः‑गणना करें जिनपर फ़ॉर्मूले निर्भर होते हैं।
- लोडेड प्रस्तुतियों से प्राप्त कैश्ड मान स्नैपशॉट हैं, संपादन के बाद पुनः‑गणना के विकल्प नहीं।
- मौजूदा टेम्पलेट से फ़ॉर्मूले का परीक्षण करें, विशेषकर जब वे दस्तावेज़ित सूची से बाहर के फ़ंक्शन उपयोग करते हों।
- पूर्ण स्प्रेडशीट गणना इंजन की आवश्यकता वाले फ़ॉर्मूलों को बाहरी रूप से गणना करें और फिर चार्ट वर्कबुक को अपडेट करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**[ChartDataCell::setFormula](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatacell/#setFormula) और [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatacell/#setR1C1Formula) में क्या अंतर है?**

[ChartDataCell::setFormula](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatacell/#setFormula) `B2-C2` जैसी A1‑स्टाइल अभिव्यक्ति संग्रहीत करता है। [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatacell/#setR1C1Formula) `RC[-2]-RC[-1]` जैसी R1C1‑स्टाइल अभिव्यक्ति संग्रहीत करता है। वह नोटेशन चुनें जो आपके फ़ॉर्मूला जनरेशन या कॉपीिंग के तरीके से बेहतर मेल खाता हो।

**गणना के बाद मुझे स्वयं कोशिका पढ़नी चाहिए या उसके मूल्य को?**

[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/#getCell) एक [ChartDataCell](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatacell/) लौटाता है। गणना के बाद गणितीय परिणाम प्राप्त करने के लिए उस कोशिका की [ChartDataCell::getValue](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatacell/#getValue) विधि को कॉल करें।

**कब मुझे [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) को कॉल करना चाहिए?**

इनपुट मान या फ़ॉर्मूला बदलने के बाद और गणना किए गए परिणामों पर निर्भर होने से पहले [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) को कॉल करें। यह बिल्ट‑इन इवैल्युएटर द्वारा समर्थित फ़ॉर्मूलों के मान अपडेट करता है।

**क्या Aspose.Slides हर Excel फ़ंक्शन को सपोर्ट करता है?**

नहीं। बिल्ट‑इन इवैल्युएटर दस्तावेज़ित फ़ंक्शन उपसमुच्चय को ही सपोर्ट करता है। इस उपसमुच्चय से बाहर के फ़ंक्शन को सही से पुनः‑गणना मानने का अनुमान न लगाएँ। यदि पूर्ण Excel फ़ॉर्मूला संगतता चाहिए, तो उचित स्प्रेडशीट इंजन से गणना करें और अंतिम मानों को चार्ट वर्कबुक में लिखें।

**यदि लोडेड प्रस्तुति में एक असमर्थित फ़ॉर्मूला हो तो क्या होता है?**

यदि चार्ट डेटा नहीं बदला है, तो वर्कबुक में पहले से गणना किया गया कैश्ड मान रह सकता है। संबंधित डेटा बदलने के बाद वह कैश्ड मान अब वैध नहीं हो सकता। ऐसी असमर्थित फ़ॉर्मूला वाली कोशिका का मान पढ़ने से [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cellunsupporteddataexception/) उठ सकता है।

**फ़ॉर्मूला त्रुटि मान और PHP अपवाद समान हैं क्या?**

नहीं। `#DIV/0!` जैसी परिणाम एक वैध गणना द्वारा उत्पन्न स्प्रेडशीट मान है। स्प्रेडशीट प्रोसेसिंग विफलताएं जैसे [CellInvalidFormulaException](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cellinvalidformulaexception/) या [CellCircularReferenceException](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cellcircularreferenceexception/) Java अपवाद हैं जो `JavaException` के माध्यम से PHP में उपलब्ध होते हैं।

**क्या फ़ॉर्मूला कोशिका बदलने पर चार्ट स्वतः अपडेट होता है?**

चार्ट श्रृंखला वर्कबुक कोशिकाओं को संदर्भित कर सकती है। पहले वर्कबुक को पुनः‑गणना करें, फिर प्रस्तुति को सहेजें या रेंडर करें। यदि चार्ट डेटा पॉइंट गणना की गई कोशिकाओं को संदर्भित करता है, तो चार्ट उन अद्यतन मानों का उपयोग करेगा; इस वर्कफ़्लो के लिए अलग चार्ट‑रीफ़्रेश मेथड आवश्यक नहीं है।

**क्या चार्ट बाहरी Excel वर्कबुक का उपयोग कर सकते हैं?**

हाँ, चार्ट डेटा को API के माध्यम से बाहरी वर्कबुक से जुड़ने के लिये कॉन्फ़िगर किया जा सकता है। हालांकि, इस लेख में वर्णित फ़ॉर्मूला गणना वर्कफ़्लो केवल चार्ट डेटा वर्कबुक और Aspose.Slides द्वारा मूल्यांकित फ़ॉर्मूला उपसमुच्चय से संबंधित है। यह न मानें कि [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) बाहरी XLSX फ़ाइल में मनमाने फ़ॉर्मूलों की पूर्ण पुनः‑गणना प्रदान करता है।

**क्या मैं ऐसे फ़ॉर्मूले उपयोग कर सकता हूँ जो दूसरे वर्कशीट या वर्कबुक को संदर्भित करें?**

Excel‑शैली के संदर्भ चार्ट वर्कबुक में मौजूद हो सकते हैं, लेकिन फ़ॉर्मूला मूल्यांकन समर्थित पार्सर और फ़ंक्शन सेट से सीमित है। यदि क्रॉस‑शीट या बाहरी संदर्भ आवश्यक है, तो अपने लक्षित Aspose.Slides संस्करण के साथ उस फ़ॉर्मूले को सत्यापित करें। व्यापक Excel संदर्भ संगतता की आवश्यकता वाले वर्कफ़्लो के लिये, वर्कबुक को बाहरी रूप से गणना करें और हल किए गए मानों को चार्ट डेटा में लिखें।

**क्या फ़ॉर्मूला स्ट्रिंग को `=` से शुरू होना चाहिए?**

Aspose.Slides API उदाहरण अभिव्यक्तियों को `B2-C2` या `SUM(B2:B5)` जैसे बिना अग्रणी `=` के असाइन करते हैं। इस रूप को उपयोग करने से उत्पन्न फ़ॉर्मूले दस्तावेज़ित API उदाहरणों के साथ संगत रहते हैं।