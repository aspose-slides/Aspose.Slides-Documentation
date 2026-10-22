---
title: Android पर प्रस्तुतियों में चार्ट वर्कबुक को प्रबंधित करें
linktitle: चार्ट वर्कबुक
type: docs
weight: 70
url: /hi/androidjava/chart-workbook/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java को खोजें: PowerPoint और OpenDocument प्रारूपों में चार्ट वर्कबुक को सहजता से प्रबंधित करें जिससे आपकी प्रस्तुति डेटा सरल हो जाए।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ कैसे काम किया जाए, इसे समझाता है। यह दिखाता है कि वर्कबुक स्ट्रिम के माध्यम से चार्ट डेटा को कैसे पढ़ा और लिखा जाए, वर्कबुक सेल्स को चार्ट डेटा लेबल के रूप में उपयोग किया जाए, वर्कशीट संग्रहों तक कैसे पहुँचा जाए, और चार्ट मानों के लिए डेटा स्रोत प्रकार को कैसे निर्दिष्ट किया जाए।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दर्शाते हैं कि बाहरी वर्कबुक को कैसे बनाया और असाइन किया जाए, चार्ट से जुड़ी बाहरी वर्कबुक का पथ कैसे प्राप्त किया जाए, और वर्कबुक उपलब्ध होने पर चार्ट डेटा को कैसे संपादित किया जाए।

गुम डेटा का प्रतिनिधित्व करने वाले वर्कबुक सेल्स के लिए, खाली सेल और शून्य के अंतर के लिये [खाली सेल्स के प्रदर्शन को नियंत्रित करें](/slides/hi/androidjava/chart-series/) देखें, तथा उपलब्ध प्रदर्शन मोड की रेखा‑चार्ट तुलना देखें।

## **छिपी हुई पंक्तियों और स्तंभों से डेटा शामिल करें**

[ IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) का उपयोग करके नियंत्रित किया जाता है कि क्या चार्ट छिपी हुई वर्कशीट पंक्तियों और स्तंभों से डेटा प्लॉट करता है। इसे `true` पर सेट करने से केवल दृश्यमान सेल्स प्लॉट होते हैं, या `false` पर सेट करने से दृश्यमान और छिपी दोनों सेल्स शामिल होते हैं। यह सेटिंग केवल चार्ट प्लॉटिंग को नियंत्रित करती है; यह वर्कशीट पंक्तियों या स्तंभों को छिपाती या दिखाई नहीं देती बनाती।

[नमूना प्रस्तुति](hidden-source-data.pptx) में पहली स्लाइड पर पहला आकार एक कॉलम चार्ट है। एम्बेडेड वर्कशीट, `Sheet1`, में स्रोत रेंज `A1:C4` है। पंक्ति 3 और स्तंभ C छिपे हुए हैं, लेकिन उनके सेल्स में अभी भी मान हैं।

| वर्कशीट पंक्ति | A: महीना | B: रिटेल | C: थोक (छिपा स्तंभ) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (छिपी पंक्ति) | February | 40 | 60 |
| 4 | March | 20 | 50 |

स्रोत सेल्स तक पहुँचने के लिए [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) का उपयोग करें और छिपी स्थिति को जांचने के लिये [IChartDataCell.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) पढ़ें। यह विधि स्थिति को बदले बिना छिपी स्थिति को रिपोर्ट करती है। इस फ़ाइल में, B2 दृश्य है, B3 छिपी पंक्ति से संबंधित है, और C2 छिपे स्तंभ से संबंधित है; उदाहरण क्रमशः `false`, `true`, और `true` प्रिंट करता है।

इस उदाहरण में, प्लॉटिंग सेटिंग बदलने के बाद चार्ट डेटा को रीफ़्रेश करें: एम्बेडेड वर्कबुक को [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) के साथ रखें और उसे [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) के साथ पुनःलोड करें। सभी सेल्स को शामिल करने के लिये, छिपी फ़रवरी श्रेणी को पुनर्स्थापित करने हेतु [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) का उपयोग करें। केवल फ्लैग बदलना इस नमूने के कैश किए गए चार्ट डेटा और श्रेणी लेबल को रीफ़्रेश करने के लिये पर्याप्त नहीं है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hidden-source-data.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
        System.out.println("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        System.out.println("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        System.out.println("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        byte[] workbookData = chart.getChartData().readWorkbookStream();
        for (boolean visibleOnly : new boolean[] { true, false }) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // एम्बेडेड वर्कबुक से चार्ट डेटा को रिफ्रेश करें।
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // छिपी श्रेणियों सहित संपूर्ण स्रोत रेंज को पुनर्स्थापित करें।
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", SaveFormat.Pptx);
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

उदाहरण दो संस्करणों में प्रस्तुति सहेजता है: एक जिसमें केवल दृश्यमान रिटेल मान (10 और 20) हैं, और दूसरा जिसमें सभी छह मान हैं। नीचे की छवियों में दो प्लॉटिंग मोड दिखाए गए हैं। पंक्ति 3 और स्तंभ C दोनों एम्बेडेड वर्कबुक में छिपे रहते हैं।

| केवल दृश्यमान सेल्स (`true`) | सभी सेल्स (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

एक मान वाले छिपे सेल और एक खाली सेल अलग होते हैं। [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) नियंत्रित करता है कि गुम मान कैसे दिखाए जाएँ; यह छिपे स्रोत डेटा को शामिल या बाहर नहीं करता। देखें [खाली सेल्स के प्रदर्शन को नियंत्रित करें](/slides/hi/androidjava/chart-series/#control-the-display-of-empty-cells) उदाहरण के लिये।

## **चार्ट की डेटा रेंज पुनः प्राप्त करें**

मौजूदा प्रस्तुति में वर्कबुक डेटा को अपडेट करने से पहले, स्रोत रेंज की जाँच करें ताकि यह पता चल सके कि प्रत्येक चार्ट कौन से वर्कशीट सेल्स का उपयोग करता है। [IChartData.getRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getRange--) विधि वर्तमान डेटा रेंज को वर्कशीट‑योग्य फ़ॉर्मूला के रूप में लौटाती है, उदाहरण के लिये `Sheet1!$A$1:$D$5`। यहाँ, `Sheet1` वर्कशीट का नाम है, `!` इसे सेल रेंज से अलग करता है, और `$A$1:$D$5` सेल्स A1‑से‑D5 को शामिल करता है। डॉलर साइन निरपेक्ष पंक्ति और स्तंभ संदर्भ दर्शाते हैं।

यह विधि चार्ट या उसकी वर्कबुक को बदले बिना वर्तमान रेंज पढ़ती है। यदि चार्ट डेटा स्रोत के रूप में वर्कबुक का उपयोग नहीं करता, तो यह `InvalidOperationException` उठाती है। अधिक जानकारी के लिये देखें [ChartData API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/)।

यह उदाहरण एक प्रस्तुति खोलता है और प्रत्येक स्लाइड पर आकारों को सीधे जाँचता है कि वे चार्ट हैं या नहीं। यह प्रत्येक चार्ट का नाम और स्रोत रेंज प्रिंट करता है। यदि चार्ट वर्कबुक का उपयोग नहीं करता, तो वह एक संदेश प्रिंट करता है और अगले चार्ट पर जाता है।

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.InvalidOperationException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                try {
                    String range = chart.getChartData().getRange();
                    System.out.println(chart.getName() + ": " + range);
                } catch (InvalidOperationException exception) {
                    System.out.println(chart.getName() + ": The chart does not use a workbook as its data source.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **वर्कबुक से चार्ट डेटा पढ़ें और लिखें**

Aspose.Slides for Android via Java [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) और [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) विधियों को प्रदान करता है जो आपको चार्ट डेटा वर्कबुक (Aspose.Cells के साथ संपादित) पढ़ने और लिखने की अनुमति देता है। **ध्यान दें** कि चार्ट डेटा को उसी तरह व्यवस्थित किया जाना चाहिए या स्रोत के समान संरचना रखनी चाहिए।

यह उदाहरण पहली स्लाइड पर पहले आकार के रूप में एक चार्ट वाली प्रस्तुति का उपयोग करता है। यह एम्बेडेड वर्कबुक को बाइट ऐरे में पढ़ता है, मौजूदा सीरीज़ और श्रेणियों को साफ़ करता है, और वही वर्कबुक वापस लिखता है। परिवर्तन मेमोरी में रहते हैं; उदाहरण प्रस्तुति को सहेजता नहीं है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **वर्कबुक संशोधन के बाद चार्ट लेआउट को मान्य करें**

जब आप एम्बेडेड वर्कबुक को संशोधित संस्करण से बदलते हैं, तो चार्ट अपनी मूल सीरीज़ और श्रेणी संग्रहों को बनाए रखता है। यह विसंगति [IChart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#validateChartLayout--) को इंडेक्स‑आउट‑ऑफ‑रेंज त्रुटि के साथ विफल कर सकती है। अपडेटेड वर्कबुक को चार्ट में लिखने से पहले मौजूदा सीरीज़ और श्रेणियों को साफ़ करें। यह उदाहरण पहली स्लाइड पर पहले आकार के रूप में चार्ट का उपयोग करता है। टिप्पणी दर्शाती है जहाँ वर्कबुक संपादन होगा; चलने योग्य उदाहरण मूल वर्कबुक को वापस लिखता है और मेमोरी में लेआउट को मान्य करता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        // वर्कबुक बाइट्स को यहाँ संशोधित करें, उदाहरण के लिए, Aspose.Cells का उपयोग करके।

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

संग्रहों को साफ़ करने से पुरानी डेटा रेफ़रेंसेज़ हट जाती हैं, इससे पहले कि वर्कबुक को वापस लिखा जाए। अपडेटेड वर्कबुक के लिये आवश्यक सीरीज़ और श्रेणी मैपिंग को पुनः बनाएँ, फिर चार्ट का उपयोग करें।

## **वर्कबुक सेल्स के लिए कस्टम नंबर फ़ॉर्मेट सेट करें**

[IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) का उपयोग करके आप चार्ट की एम्बेडेड वर्कबुक में संख्यात्मक मानों का प्रदर्शण नियंत्रित कर सकते हैं। उदाहरण के लिये, एक रिपोर्ट को रूपांतरण दर को चार दशमलव स्थान के प्रतिशत के रूप में और एक गुणांक को पाँच दशमलव स्थान के साथ दिखाना पड़ सकता है। दोनों मानों को संख्यात्मक रखें ताकि वे गणनाओं और चार्ट प्लॉटिंग के लिये उपलब्ध रहें।

एक नंबर फ़ॉर्मेट केवल प्रदर्शन को बदलता है, संचित मान को नहीं। फ़ॉर्मेट `0.0000%` `0.125` को `12.5000%` के रूप में दिखाता है; यह संग्रहीत संख्या को `12.5` से प्रतिस्थापित नहीं करता। इसी प्रकार, `0.00000` `0.1234567` को `0.12346` के रूप में दिखाता है बिना संग्रहीत मान को गोल किए। यदि कस्टम फ़ॉर्मेट खाली स्ट्रिंग (`""`) है, तो [getPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--) द्वारा लौटाया गया फ़ॉर्मेट उपयोग किया जाता है।

निम्न उदाहरण एक कॉलम चार्ट बनाता है और उसके सेल्स को [getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) के माध्यम से एक्सेस करता है। वर्कशीट 0 में, B2 में रूपांतरण दर और C2 में गुणांक है। दोनों सेल्स चार्ट मान प्रदान करते हैं। उदाहरण स्रोत फ़ॉर्मेट से जुड़ी वैल्यू लेबल्स को भी सक्षम करता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210);
    chart.setTitle(false);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00");
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(0);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell categoryCell = workbook.getCell(0, "A2", "Sample");
    chart.getChartData().getCategories().add(categoryCell);

    IChartDataCell percentageCell = workbook.getCell(0, "B2", 0.125);
    percentageCell.setCustomNumberFormat("0.0000%");
    IChartDataCell percentageName = workbook.getCell(0, "B1", "Conversion rate");
    IChartSeries percentageSeries = chart.getChartData().getSeries().add(percentageName, chart.getType());
    percentageSeries.getDataPoints().addDataPointForBarSeries(percentageCell);

    IChartDataCell precisionCell = workbook.getCell(0, "C2", 0.1234567);
    precisionCell.setCustomNumberFormat("0.00000");
    IChartDataCell precisionName = workbook.getCell(0, "C1", "Coefficient");
    IChartSeries precisionSeries = chart.getChartData().getSeries().add(precisionName, chart.getType());
    precisionSeries.getDataPoints().addDataPointForBarSeries(precisionCell);

    for (IChartSeries series : chart.getChartData().getSeries()) {
        IDataLabelFormat labelFormat = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(true);
    }

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

वर्कबुक सेल फ़ॉर्मेट चार्ट अक्ष या डेटा लेबल्स पर सीधे सेट किए गए फ़ॉर्मेट से अलग होते हैं। इस उदाहरण में, प्रत्येक लेबल अपना स्रोत सेल का मान दिखाता है क्योंकि [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) `true` है, और स्रोत नंबर फ़ॉर्मेट से लिंक है क्योंकि [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) `true` है। प्रस्तुति को सहेजने और पुनः खोलने के बाद, लेबल्स `12.5000%` और `0.12346` दिखाते हैं, जैसा नीचे दिखाया गया है। लंबवत अक्ष अपना खुद का नंबर फ़ॉर्मेट उपयोग करता है, जिसे [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) द्वारा `0.00` के रूप में सेट किया गया है, और [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) `false` है।

डेटा लेबल को स्वतंत्र रूप से फ़ॉर्मेट करने के लिये, उसके स्रोत‑लिंक फ़्लैग को `false` सेट करें और [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) से फ़ॉर्मेट असाइन करें। यह वर्कबुक सेल के फ़ॉर्मेट को नहीं बदलता। उदाहरण के लिये, स्वतंत्र लेबल फ़ॉर्मेट `0.00` प्रथम मान को `0.13` दिखाता है, जबकि B2 अभी भी `12.5000%` दिखाता है। सीधे लेबल फ़ॉर्मेटिंग के लिये देखें [Chart Data Labels](/slides/hi/androidjava/chart-data-label/#set-the-percentage-sign-with-chart-data-labels)।

नीचे की छवि सहेजी हुई प्रस्तुति को पुनः खोलने के बाद रेंडर की गई है:

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **एक वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करें**

आप वर्कबुक सेल्स से टेक्स्ट को चार्ट डेटा लेबल के रूप में उपयोग कर सकते हैं।

यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड में एक डिफ़ॉल्ट डेटा वाले बबल चार्ट को जोड़ता है। यह वर्कशीट 0 में सेल्स A10:A12 को पहली सीरीज़ के पहले तीन लेबल्स के लिये उपयोग करता है, सेल्स से लेबल्स सक्षम करता है, और अपडेटेड प्रस्तुति को सहेजता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **वर्कशीट्स का प्रबंधन करें**

[IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) विधि चार्ट वर्कबुक में मौजूद वर्कशीट्स तक पहुँच प्रदान करती है। यह उदाहरण एक डिफ़ॉल्ट डेटा वाले पाई चार्ट को बनाता है और प्रत्येक वर्कशीट का नाम कंसोल पर प्रिंट करता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    for (int i = 0; i < workbook.getWorksheets().size(); i++) {
        System.out.println(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **डेटा स्रोत प्रकार निर्दिष्ट करें**

सीरीज़ पॉइंट मानों को सीधे संख्यात्मक लिटरल के रूप में भी संग्रहीत किया जा सकता है। पूर्ण उदाहरण के लिये देखें [Set Series Values Using Numeric Literals](/slides/hi/androidjava/chart-series/#set-series-values-using-numeric-literals) जो उन्हें सहेजता और पढ़ता है। पॉइंट मानों का स्रोत प्रकार चार्ट की आंतरिक या बाहरी वर्कबुक कॉन्फ़िगरेशन से अलग होता है; संख्यात्मक लिटरल का उपयोग करने से एम्बेडेड वर्कबुक स्वतः हटती नहीं है।

यह उदाहरण डिफ़ॉल्ट डेटा वाले एक 3D कॉलम चार्ट को बनाता है और दो सीरीज़ नामों को विभिन्न डेटा स्रोतों से सेट करता है। पहला नाम स्ट्रिंग लिटरल है; दूसरा वर्कशीट 0 में सेल C1 से है। [DataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/) एनीमरेशन प्रत्येक नाम के स्रोत को चुनता है। उदाहरण अपडेटेड सीरीज़ नामों के साथ प्रस्तुति को सहेजता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    IStringChartValue cellName = chart.getChartData().getSeries().get_Item(1).getName();
    IChartDataCell nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **असमर्थित एम्बेडेड वर्कबुक फ़ॉर्मेट का पता लगाएँ**

Aspose.Slides उन Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट को सपोर्ट नहीं करता जो कुछ चार्ट्स में एम्बेड हो सकते हैं। आप [IChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/) पर [getEmbeddedWorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) विधि को [WorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/workbooktype/) एनीमरेशन के साथ उपयोग करके असमर्थित फ़ॉर्मेट का पता लगा सकते हैं और उन चार्ट्स को छोड़ सकते हैं। यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर आकारों को जाँचता है, गैर‑चार्ट आकारों को छोड़ता है, और प्रत्येक .xlsb एम्बेडेड वर्कबुक वाले चार्ट के लिये डायग्नोस्टिक संदेश प्रिंट करता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IChartData chartData = chart.getChartData();
        boolean isInternalWorkbook = chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook;
        boolean isBinaryMacro = chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            System.out.println("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // समर्थित चार्ट वर्कबुक डेटा को यहाँ पढ़ें या संशोधित करें।
    }
} finally {
    presentation.dispose();
}
```

## **बाहरी वर्कबुक**

Aspose.Slides चार्ट्स के लिये बाहरी वर्कबुक को डेटा स्रोत के रूप में उपयोग करने का समर्थन करता है।

### **एक बाहरी वर्कबुक बनाएं**

[readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) और [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) का उपयोग करके एम्बेडेड चार्ट वर्कबुक को फ़ाइल में निर्यात करें और चार्ट को उस बाहरी वर्कबुक से लिंक करें।

यह उदाहरण डिफ़ॉल्ट डेटा वाले एक पाई चार्ट को बनाता है और उसका वर्कबुक निर्यात करता है। फ़ाइल लिखने के बाद बाहरी वर्कबुक को डेटा स्रोत के रूप में असाइन करता है, फिर लिंक्ड प्रस्तुति को सहेजता है।

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    File workbookFile = new File("externalWorkbook1.xlsx").getAbsoluteFile();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        try (FileOutputStream workbookStream = new FileOutputStream(workbookFile)) {
            workbookStream.write(workbookData);
        }
        chart.getChartData().setExternalWorkbook(workbookFile.getAbsolutePath());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **एक बाहरी वर्कबुक सेट करें**

[setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) विधि का उपयोग करके आप किसी चार्ट को बाहरी वर्कबुक को डेटा स्रोत के रूप में असाइन कर सकते हैं। यह विधि बाहरी वर्कबुक के पथ को अपडेट करने के लिये भी उपयोग की जा सकती है (यदि वह स्थानांतरित हो गया हो)।

भले ही आप रिमोट लोकेशन या संसाधनों में संग्रहीत वर्कबुक्स को संपादित न कर सकें, आप अभी भी ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी वर्कबुक के लिये सापेक्ष पथ दिया गया है, तो यह स्वतः पूर्ण पथ में परिवर्तित हो जाता है।

यह उदाहरण एक बाहरी वर्कबुक का उपयोग करता है जिसमें `Sheet1` नामक वर्कशीट में B1 में सीरीज़ नाम, A2:A4 में श्रेणी नाम, और B2:B4 में संख्यात्मक मान हैं। उदाहरण एक पाई चार्ट बनाता है, वर्कबुक को लिंक करता है, और [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) का उपयोग करके A1:B4 को एक सीरीज़ और तीन श्रेणियों से मैप करता है। फिर लिंक्ड चार्ट के साथ प्रस्तुति को सहेजता है।

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    File workbookFile = new File("externalWorkbook.xlsx");
    String workbookPath = workbookFile.getAbsolutePath();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) का `updateChartData` पैरामीटर नियंत्रित करता है कि वर्कबुक लोड हो या नहीं।

* जब `updateChartData` `false` है, केवल वर्कबुक पथ अपडेट होता है। चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं होता, इसलिए वर्कबुक उपलब्ध नहीं भी हो सकती।
* जब `updateChartData` `true` है, चार्ट डेटा लक्ष्य वर्कबुक से अपडेट होता है।

निम्न उदाहरण एक प्लेसहोल्डर URL को `updateChartData` `false` के साथ असाइन करता है। यह पाई चार्ट के डिफ़ॉल्ट डेटा को रखता है और अनुपलब्ध वर्कबुक को लोड किए बिना प्रस्तुति को सहेजता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **चार्ट के बाहरी डेटा स्रोत वर्कबुक पथ प्राप्त करें**

किसी चार्ट से जुड़ी वर्कबुक को पहचानने के लिये, जाँचें कि क्या चार्ट बाहरी डेटा स्रोत का उपयोग करता है और उसका वर्कबुक पथ प्राप्त करें।

यह उदाहरण प्रस्तुति की पहली स्लाइड में पहली आकार को जाँचता है जिसमें लिंक्ड बाहरी वर्कबुक है। यदि वह बाहरी वर्कबुक से जुड़ा चार्ट है, तो उदाहरण कंसोल पर [getExternalWorkbookPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) प्रिंट करता है। फिर प्रस्तुति की एक कॉपी सहेजता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("externalWorkbook.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        if (chartData.getDataSourceType() == ChartDataSourceType.ExternalWorkbook) {
            System.out.println(chartData.getExternalWorkbookPath());
        } else {
            System.out.println("The chart does not use an external workbook.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **चार्ट डेटा संपादित करें**

आप बाहरी वर्कबुक में डेटा को उसी तरह संपादित कर सकते हैं जैसे आंतरिक वर्कबुक में करते हैं। यदि बाहरी वर्कबुक लोड नहीं हो पाती, तो एक अपवाद उठाया जाता है।

यह उदाहरण पहली स्लाइड पर पहली आकार के रूप में एक चार्ट का उपयोग करता है और वह एक सुलभ बाहरी वर्कबुक से जुड़ा है। यह पहली सीरीज़ के पहले डेटा पॉइंट की सेल‑बैक्ड वैल्यू को 100 सेट करता है और अपडेटेड प्रस्तुति को सहेजता है। सेल मानों को संपादित करने से जुड़े बाहरी XLSX फ़ाइल को अपडेट किया जा सकता है, इसलिए मूल वर्कबुक को संरक्षित रखने के लिये एक कॉपी का प्रयोग करें।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartSeriesCollection series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            IChartDataCell valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", SaveFormat.Pptx);
            } else {
                System.out.println("The first data point is not linked to a workbook cell.");
            }
        } else {
            System.out.println("The chart has no data points to edit.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **चार्ट कैश से वर्कबुक पुनः प्राप्त करें**

यदि कोई चार्ट बाहरी वर्कबुक का उपयोग करता है जो अनुपलब्ध है, तो Aspose.Slides प्रस्तुति में कैश किए गए डेटा से चार्ट वर्कबुक को पुनर्निर्मित कर सकता है। [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) बनाएं, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) को कॉल करें, और [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) को `true` सेट करें, फिर प्रस्तुति खोलें।

निम्न Java उदाहरण पहले स्लाइड पर पहले आकार के रूप में एक चार्ट के लिये वर्कबुक डेटा को पुनर्प्राप्त करता है जो अनुपलब्ध बाहरी वर्कबुक को संदर्भित करता है। यह पुनर्प्राप्त डेटा को [IChart.getChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getChartData--) और [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) के माध्यम से एक्सेस करता है:

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // यहाँ पुनर्प्राप्त वर्कबुक डेटा पढ़ें या संशोधित करें।
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

यदि बाहरी वर्कबुक अनुपलब्ध है और पुनर्प्राप्ति अक्षम है, तो Aspose.Slides एक अपवाद फेंकेगा। केवल तभी पुनर्प्राप्ति सक्षम करें जब कैश किया गया चार्ट डेटा एक स्वीकार्य फॉलबैक हो, क्योंकि कैश में बाहरी वर्कबुक में किए गए परिवर्तन शामिल नहीं हो सकते हैं।

## **बार‑बार पूछे जाने वाले प्रश्न**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशेष चार्ट बाहरी या एम्बेडेड वर्कबुक से जुड़ा है?**

हां। चार्ट के पास एक [डेटा स्रोत प्रकार](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) और एक [बाहरी वर्कबुक का पथ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) होता है; यदि स्रोत बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़कर यह सुनिश्चित कर सकते हैं कि बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक के लिये सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हां। यदि आप सापेक्ष पथ निर्दिष्ट करते हैं, तो वह स्वतः पूर्ण पथ में परिवर्तित हो जाता है। प्रस्तुति PPTX फ़ाइल में पूर्ण पथ संग्रहीत करती है, इसलिए वर्कबुक को स्थानांतरित करने पर लिंक को अपडेट करना पड़ सकता है।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**

हां, ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से सीधे रिमोट वर्कबुक को संपादित करना समर्थित नहीं है—उनका उपयोग केवल स्रोत के रूप में किया जा सकता है।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

प्रस्तुति [बाहरी फ़ाइल के लिंक](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) को संग्रहीत करती है। सेल‑बैक्ड चार्ट डेटा को संपादित करने से लिंक्ड स्थानीय XLSX फ़ाइल भी अपडेट हो सकती है। यदि मूल वर्कबुक को अपरिवर्तित रखना है, तो उसकी एक कॉपी उपयोग करें।

**यदि बाहरी फ़ाइल पासवर्ड‑सुरक्षित है तो क्या करें?**

Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। सामान्य तरीका यह है कि पहले पासवर्ड हटाया जाए या एक डिक्रिप्टेड कॉपी तैयार की जाए (उदाहरण के लिये [Aspose.Cells](https://reference.aspose.com/cells/java/) का उपयोग करके) और उस कॉपी को लिंक किया जाए।

**क्या कई चार्ट एक ही बाहरी वर्कबुक को संदर्भित कर सकते हैं?**

हां। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल को दर्शाते हैं, तो फ़ाइल को अपडेट करने से अगली बार डेटा लोड होने पर प्रत्येक चार्ट में परिवर्तन परिलक्षित होगा।