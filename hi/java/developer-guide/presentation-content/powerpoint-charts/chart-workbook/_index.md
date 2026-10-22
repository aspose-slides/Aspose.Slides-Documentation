---
title: जावा का उपयोग करके प्रस्तुतियों में चार्ट वर्कबुक प्रबंधित करें
linktitle: चार्ट वर्कबुक
type: docs
weight: 70
url: /hi/java/chart-workbook/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java को खोजें: PowerPoint और OpenDocument फ़ॉर्मैट में चार्ट वर्कबुक को आसानी से प्रबंधित करें ताकि आपके प्रस्तुति डेटा को सुव्यवस्थित किया जा सके।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने के तरीकों को समझाता है। यह दर्शाता है कि वर्कबुक स्ट्रीम के माध्यम से चार्ट डेटा को कैसे पढ़ें और लिखें, वर्कबुक की कोशिकाओं को चार्ट डेटा लेबल के रूप में उपयोग करें, वर्कशीट संग्रहों तक पहुंचें, और चार्ट मानों के लिए डेटा स्रोत प्रकार को कैसे निर्दिष्ट करें।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दर्शाते हैं कि बाहरी वर्कबुक कैसे बनाएं और असाइन करें, चार्ट से जुड़ी बाहरी वर्कबुक का पथ कैसे प्राप्त करें, और जब वर्कबुक उपलब्ध हो तो चार्ट डेटा को कैसे संपादित करें।

खाली डेटा का प्रतिनिधित्व करने वाली वर्कबुक कोशिकाओं के लिए, एक खाली कोशिका और शून्य के बीच अंतर तथा उपलब्ध प्रदर्शन मोड की रेखा‑चार्ट तुलना के लिए देखें [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/java/chart-series/)।

## **छिपी पंक्तियों और स्तंभों से डेटा शामिल करें**

छिपी वर्कशीट पंक्तियों और स्तंभों से डेटा प्लॉट करता है या नहीं, इसे नियंत्रित करने के लिए [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) का उपयोग करें। केवल दृश्यमान कोशिकाओं को प्लॉट करने के लिए इसे `true` सेट करें, या दृश्यमान और छिपी दोनों कोशिकाओं को शामिल करने के लिए `false` सेट करें। यह सेटिंग चार्ट प्लॉटिंग को नियंत्रित करती है; यह वर्कशीट पंक्तियों या स्तंभों को छुपाने या दिखाने का कार्य नहीं करती।

[नमूना प्रस्तुति](hidden-source-data.pptx) में पहले स्लाइड की पहली आकृति के रूप में एक कॉलम चार्ट है। एम्बेडेड वर्कशीट `Sheet1` में निम्न स्रोत रेंज `A1:C4` है। पंक्ति 3 और स्तंभ C छिपे हुए हैं, लेकिन उनकी कोशिकाओं में अभी भी मान हैं।

| वर्कशीट पंक्ति | A: महीना | B: रिटेल | C: थोक (छिपा स्तंभ) |
| --- | --- | --- | --- |
| 2 | जनवरी | 10 | 30 |
| 3 (छिपी पंक्ति) | फ़रवरी | 40 | 60 |
| 4 | मार्च | 20 | 50 |

स्रोत कोशिकाओं तक पहुंचने के लिए [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) का उपयोग करें और उनकी छिपी स्थिति की जांच के लिए [IChartDataCell.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#isHidden--) पढ़ें। यह मेथड छिपी स्थिति को बदले बिना रिपोर्ट करता है। इस फ़ाइल में B2 दृश्यमान है, B3 छिपी पंक्ति से संबंधित है, और C2 छिपे स्तंभ से संबंधित है; उदाहरण क्रमशः `false`, `true`, `true` प्रिंट करता है।

इस उदाहरण के लिए, प्लॉटिंग सेटिंग बदलने के बाद चार्ट डेटा को रीफ़्रेश करें: एम्बेडेड वर्कबुक को [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) से बनाए रखें और इसे फिर से लोड करने के लिए [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) का उपयोग करें। सभी कोशिकाओं को शामिल करते समय, छिपी फ़रवरी श्रेणी को भी बहाल करने के लिए [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) का उपयोग करें। केवल फ़्लैग बदलना इस नमूने के कैश किए गए चार्ट डेटा और श्रेणी लेबल को रीफ़्रेश करने के लिए पर्याप्त नहीं है।

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

            // एंबेडेड वर्कबुक से चार्ट डेटा को रीफ़्रेश करें।
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // छिपी श्रेणियों सहित पूर्ण स्रोत रेंज को पुनर्स्थापित करें।
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

उदाहरण प्रस्तुतिकरण के दो संस्करण सहेजता है: एक जिसमें केवल दृश्यमान रिटेल मान (10 और 20) हैं, और दूसरा जिसमें सभी छह मान हैं। नीचे की छवियां दो प्लॉटिंग मोड दिखाती हैं। पंक्ति 3 और स्तंभ C दोनों एम्बेडेड वर्कबुक में छिपे ही रहते हैं।

| केवल दृश्यमान कोशिकाएँ (`true`) | सभी कोशिकाएँ (`false`) |
| --- | --- |
| ![केवल दृश्यमान कोशिकाएँ: जनवरी और मार्च के लिए रिटेल मान 10 और 20।](hidden_cells_True.png) | ![सभी कोशिकाएँ: जनवरी, फ़रवरी और मार्च के लिए रिटेल और थोक मान।](hidden_cells_False.png) |

एक मान वाले छिपी कोशिका खाली कोशिका से अलग होती है। [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) नियंत्रित करता है कि लापता मान कैसे प्रदर्शित हों; यह छिपी स्रोत डेटा को शामिल या बाहर नहीं करता। अधिक जानकारी के लिए देखें [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/java/chart-series/#control-the-display-of-empty-cells)।

## **चार्ट की डेटा रेंज प्राप्त करें**

मौजूदा प्रस्तुतीकरण में वर्कबुक डेटा को अपडेट करने से पहले, स्रोत रेंज की जाँच करें ताकि यह पहचाना जा सके कि प्रत्येक चार्ट कौन सी वर्कशीट कोशिकाएं उपयोग करता है। [IChartData.getRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getRange--) मेथड वर्तमान डेटा रेंज को वर्कशीट‑योग्य फॉर्मूला के रूप में लौटाता है, उदाहरण के लिए `Sheet1!$A$1:$D$5`। यहाँ `Sheet1` वर्कशीट का नाम है, `!` इसे सेल रेंज से अलग करता है, और `$A$1:$D$5` कोशिकाओं A1 से D5 तक को दर्शाता है, दोनों सम्मिलित। डॉलर चिन्ह निरपेक्ष पंक्ति और स्तम्भ संदर्भ दर्शाते हैं।

यह मेथड चार्ट या उसकी वर्कबुक को बदले बिना वर्तमान रेंज पढ़ता है। यदि चार्ट डेटा स्रोत के रूप में वर्कबुक का उपयोग नहीं करता है, तो यह `InvalidOperationException` फेंकेगा। अधिक जानकारी के लिए देखें [ChartData API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/)।

यह उदाहरण एक प्रस्तुतीकरण खोलता है और प्रत्येक स्लाइड पर सीधे आकृतियों को जांचता है कि उनमें चार्ट हैं या नहीं। यह प्रत्येक चार्ट का नाम और स्रोत रेंज प्रिंट करता है। यदि कोई चार्ट वर्कबुक का उपयोग नहीं करता है, तो यह एक संदेश प्रिंट करता है और अगले चार्ट पर जारी रहता है।

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

Aspose.Slides for Java [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) और [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) मेथड प्रदान करता है जो आपको चार्ट डेटा वर्कबुक (जिसमें Aspose.Cells से संपादित डेटा होता है) को पढ़ने और लिखने की अनुमति देता है। **Note** कि चार्ट डेटा को उसी प्रकार व्यवस्थित किया जाना चाहिए या स्रोत के समान संरचना होनी चाहिए।

यह उदाहरण एक प्रस्तुतीकरण का उपयोग करता है जिसमें पहले स्लाइड की पहली आकृति के रूप में एक चार्ट है। यह एम्बेडेड वर्कबुक को बाइट एरे में पढ़ता है, मौजूदा सीरीज़ और श्रेणियों को साफ़ करता है, और वही वर्कबुक वापस लिखता है। परिवर्तन मेमोरी में रहते हैं; उदाहरण प्रस्तुतीकरण को सहेजता नहीं है।

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

### **वर्कबुक संशोधन के बाद चार्ट लेआउट सत्यापित करें**

जब आप एम्बेडेड वर्कबुक को संशोधित संस्करण से बदलते हैं, तो चार्ट अपनी मूल सीरीज़ और श्रेणी संग्रहों को बनाए रखता है। यह असंगति [IChart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#validateChartLayout--) को इंडेक्स‑आउट‑ऑफ़‑रेंज त्रुटि के साथ विफल कर सकती है। अद्यतन वर्कबुक को चार्ट में लिखने से पहले मौजूदा सीरीज़ और श्रेणियों को साफ़ करें। यह उदाहरण पहले स्लाइड की पहली आकृति में स्थित चार्ट का उपयोग करता है। टिप्पणी में वह स्थान दर्शाया गया है जहाँ वर्कबुक संपादन होगा; चालित उदाहरण मूल वर्कबुक को वापस लिखता है और मेमोरी में लेआउट सत्यापित करता है।

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

        // यहाँ वर्कबुक बाइट्स को संशोधित करें, उदाहरण के लिए, Aspose.Cells का उपयोग करके।

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

संग्रहों को साफ़ करने से वर्कबुक को वापस लिखने से पहले पुरानी डेटा संदर्भ हट जाते हैं। अद्यतन वर्कबुक के लिए आवश्यक सीरीज़ और श्रेणी मैपिंग को फिर से बनाएं, फिर चार्ट का उपयोग करें।

## **वर्कबुक कोशिकाओं के लिए कस्टम नंबर फ़ॉर्मेट सेट करें**

[IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) का उपयोग करके आप यह नियंत्रित कर सकते हैं कि चार्ट की एम्बेडेड वर्कबुक में संख्यात्मक मान कैसे प्रदर्शित हों। उदाहरण के लिए, एक रिपोर्ट को परिवर्तन दर को चार दशमलव स्थानों के साथ प्रतिशत रूप में और एक गुणांक को पाँच दशमलव स्थानों के साथ प्रदर्शित करने की आवश्यकता हो सकती है। दोनों मानों को संख्यात्मक रखें ताकि वे गणनाओं और चार्ट प्लॉटिंग के लिए उपलब्ध रहें।

फ़ॉर्मेट केवल प्रदर्शन बदलता है, संग्रहीत मान नहीं। फ़ॉर्मेट `0.0000%` `0.125` को `12.5000%` के रूप में दिखाता है; यह संग्रहीत संख्या को `12.5` नहीं बदलता। इसी तरह, `0.00000` `0.1234567` को `0.12346` दिखाता है बिना संग्रहीत मान को गोल किए। यदि कस्टम फ़ॉर्मेट खाली स्ट्रिंग (`""`) है, तो [getPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--) द्वारा लौटाया गया फ़ॉर्मेट उपयोग किया जाता है।

निम्न उदाहरण एक कॉलम चार्ट बनाता है और उसकी कोशिकाओं तक [getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) के माध्यम से पहुंचता है। वर्कशीट 0 में, B2 में परिवर्तन दर और C2 में गुणांक है। दोनों कोशिकाएँ चार्ट मान देती हैं। उदाहरण स्रोत फ़ॉर्मेट से जुड़े मान लेबल्स को भी सक्षम करता है।

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

वर्कबुक कोशिका फ़ॉर्मेट्स चार्ट अक्षों या डेटा लेबल्स पर सीधे सेट किए गए फ़ॉर्मेट्स से अलग होते हैं। इस उदाहरण में, प्रत्येक लेबल अपने स्रोत कोशिका के मान को दिखाता है क्योंकि [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) `true` पर सेट है, और स्रोत नंबर फ़ॉर्मेट का अनुसरण करता है क्योंकि [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) `true` पर है। सहेजने और प्रस्तुतीकरण को फिर से खोलने के बाद, लेबल्स क्रमशः `12.5000%` और `0.12346` दिखाते हैं, जैसा कि नीचे दिखाया गया है। ऊर्ध्वाधर अक्ष अपना स्वयं का नंबर फ़ॉर्मेट उपयोग करता है, जो [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) द्वारा `0.00` सेट किया गया है, और [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) `false` पर है।

डेटा लेबल को स्वतंत्र रूप से फ़ॉर्मेट करने के लिए, उसके स्रोत‑लिंक फ़्लैग को `false` सेट करें और [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) के साथ फ़ॉर्मेट असाइन करें। यह वर्कबुक कोशिका के फ़ॉर्मेट को नहीं बदलता। उदाहरण के तौर पर, स्वतंत्र लेबल फ़ॉर्मेट `0.00` पहला मान `0.13` दिखाएगा, जबकि B2 अभी भी `12.5000%` दिखाता है। सीधे लेबल फ़ॉर्मेटिंग के लिए देखें [Chart Data Labels](/slides/hi/java/chart-data-label/#set-percentage-sign-with-chart-data-labels)।

नीचे की छवि सहेजे गए प्रस्तुतीकरण को फिर से खोलने के बाद रेंडर की गई है:

![स्रोत‑लिंक्ड लेबल्स के साथ कॉलम चार्ट जो 12.5000% और 0.12346 दिखा रहा है और एक स्वतंत्र रूप से फ़ॉर्मेटेड न्यूमेरिक अक्ष।](custom-cell-formats.png)

## **चार्ट डेटा लेबल के रूप में वर्कबुक कोशिका सेट करें**

आप वर्कबुक कोशिकाओं से पाठ का उपयोग करके चार्ट डेटा लेबल बना सकते हैं।

यह उदाहरण मौजूदा प्रस्तुतीकरण के पहले स्लाइड में एक बबल चार्ट जोड़ता है जिसमें डिफ़ॉल्ट डेटा है। यह वर्कशीट 0 में कोशिकाएँ A10:A12 को पहले सीरीज़ के पहले तीन लेबल्स के रूप में उपयोग करता है, कोशिकाओं से लेबल्स को सक्षम करता है, और अपडेटेड प्रस्तुतीकरण सहेजता है।

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

[IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) मेथड आपको चार्ट वर्कबुक में मौजूद वर्कशीट्स तक पहुंच प्रदान करता है। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और प्रत्येक वर्कशीट के नाम को कंसोल पर प्रिंट करता है।

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

सीरीज़ पॉइंट मानों को सीधे संख्यात्मक लिटरल्स के रूप में भी संग्रहीत किया जा सकता है। पूर्ण उदाहरण के लिए देखें [Set Series Values Using Numeric Literals](/slides/hi/java/chart-series/#set-series-values-using-numeric-literals) जो उन्हें सहेजता और पढ़ता है। पॉइंट मानों का स्रोत प्रकार चार्ट के आंतरिक या बाहरी वर्कबुक कॉन्फ़िगरेशन से अलग होता है; संख्यात्मक लिटरल्स का उपयोग करने से एम्बेडेड वर्कबुक स्वयं नहीं हटती।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक 3D कॉलम चार्ट बनाता है और दो सीरीज़ नाम विभिन्न डेटा स्रोतों से सेट करता है। पहला नाम स्ट्रिंग लिटरल है; दूसरा वर्कशीट 0 में कोशिका C1 से लिया गया है। [DataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/) एनेमरेशन प्रत्येक नाम के लिए स्रोत चुनता है। उदाहरण अपडेटेड सीरीज़ नामों के साथ प्रस्तुतीकरण सहेजता है।

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

## **असमर्थित एम्बेडेड वर्कबुक फ़ॉर्मेट्स का पता लगाएँ**

Aspose.Slides कुछ चार्ट्स में एम्बेडेड Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट का समर्थन नहीं करता। आप [IChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/) पर [getEmbeddedWorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) मेथड को [WorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/workbooktype/) एनेमरेशन के साथ उपयोग करके असमर्थित फ़ॉर्मेट्स का पता लगा सकते हैं और उन चार्ट्स को स्किप कर सकते हैं। यह उदाहरण मौजूदा प्रस्तुतीकरण के पहले स्लाइड की आकृतियों को जांचता है, गैर‑चार्ट आकृतियों को छोड़ता है, और प्रत्येक .xlsb एम्बेडेड वर्कबुक वाले चार्ट के लिए निदान संदेश प्रिंट करता है।

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

        // समर्थनित चार्ट वर्कबुक डेटा को यहाँ पढ़ें या संशोधित करें।
    }
} finally {
    presentation.dispose();
}
```

## **बाहरी वर्कबुक**

Aspose.Slides चार्ट्स के लिए डेटा स्रोत के रूप में बाहरी वर्कबुक का उपयोग समर्थन करता है।

### **बाहरी वर्कबुक बनाएँ**

[readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) और [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) का उपयोग करके एम्बेडेड चार्ट वर्कबुक को फ़ाइल में निर्यात करें और चार्ट को उस बाहरी वर्कबुक से लिंक करें।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और उसकी वर्कबुक निर्यात करता है। फ़ाइल लिखने को पूरी करने के बाद बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में असाइन करता है, फिर लिंक्ड प्रस्तुतीकरण सहेजता है।

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    Path workbookPath = Paths.get("externalWorkbook1.xlsx").toAbsolutePath();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        Files.write(workbookPath, workbookData);
        chart.getChartData().setExternalWorkbook(workbookPath.toString());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **बाहरी वर्कबुक सेट करें**

[setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) मेथड का उपयोग करके आप किसी चार्ट को बाहरी वर्कबुक को डेटा स्रोत के रूप में असाइन कर सकते हैं। यह मेथड बाहरी वर्कबुक के पथ को अपडेट करने के लिए भी उपयोग किया जा सकता है (यदि वह स्थानांतरित किया गया हो)।

जबकि आप रिमोट स्थानों या संसाधनों में संग्रहीत वर्कबुक के डेटा को संपादित नहीं कर सकते, आप ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में फिर भी उपयोग कर सकते हैं। यदि बाहरी वर्कबुक के लिए सापेक्ष पथ प्रदान किया गया है, तो यह स्वचालित रूप से पूर्ण पथ में परिवर्तित हो जाता है।

यह उदाहरण एक बाहरी वर्कबुक का उपयोग करता है जिसकी वर्कशीट `Sheet1` में B1 में सीरीज़ नाम, A2:A4 में श्रेणी नाम, और B2:B4 में संख्यात्मक मान हैं। उदाहरण एक पाई चार्ट बनाता है, वर्कबुक को लिंक करता है, और [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) का उपयोग करके A1:B4 को एक सीरीज़ और तीन श्रेणियों के रूप में मैप करता है। यह लिंक्ड चार्ट के साथ प्रस्तुतीकरण सहेजता है।

```java
import com.aspose.slides.*;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    String workbookPath = Paths.get("externalWorkbook.xlsx").toAbsolutePath().toString();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) का `updateChartData` पैरामीटर नियंत्रित करता है कि वर्कबुक लोड हो या नहीं।

* जब `updateChartData` `false` है, तो केवल वर्कबुक पथ अपडेट होता है। चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं होता, इसलिए वर्कबुक अनुपलब्ध भी हो सकती है।
* जब `updateChartData` `true` है, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट होता है।

निम्न उदाहरण `updateChartData` को `false` पर सेट करके एक प्लेसहोल्डर URL असाइन करता है। यह पाई चार्ट के डिफ़ॉल्ट डेटा को बरकरार रखता है और अनुपलब्ध वर्कबुक को लोड किए बिना प्रस्तुतीकरण सहेजता है।

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

### **चर्‍ट की बाहरी डेटा स्रोत वर्कबुक पथ प्राप्त करें**

किसी चार्ट से जुड़ी वर्कबुक की पहचान करने के लिए, जाँचें कि क्या चार्ट बाहरी डेटा स्रोत उपयोग करता है और उसका वर्कबुक पथ प्राप्त करें।

यह उदाहरण एक प्रस्तुतीकरण की पहली स्लाइड की पहली आकृति को जांचता है जिसमें लिंक्ड बाहरी वर्कबुक है। यदि यह बाहरी वर्कबुक से जुड़ा चार्ट है, तो यह कंसोल में [getExternalWorkbookPath](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) प्रिंट करता है। फिर प्रस्तुतीकरण की एक प्रतिलिपि सहेजता है।

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

आप बाहरी वर्कबुक के डेटा को उसी तरह संपादित कर सकते हैं जैसे आप आंतरिक वर्कबुक की सामग्री को बदलते हैं। जब कोई बाहरी वर्कबुक लोड नहीं हो पाती, तो एक अपवाद फेंका जाता है।

यह उदाहरण पहली स्लाइड की पहली आकृति में स्थित चार्ट का उपयोग करता है जो एक सुलभ बाहरी वर्कबुक से जुड़ा है। यह पहले सीरीज़ के पहले डेटा पॉइंट का सेल‑बैक्ड मान 100 सेट करता है और अपडेटेड प्रस्तुतीकरण सहेजता है। सेल मानों को संपादित करने से लिंक्ड बाहरी XLSX फ़ाइल अपडेट हो सकती है, इसलिए मूल वर्कबुक को संरक्षित रखने के लिये एक कॉपी का उपयोग करें।

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

यदि कोई चार्ट ऐसी बाहरी वर्कबुक उपयोग करता है जो गायब या अनुपलब्ध है, तो Aspose.Slides प्रस्तुतीकरण में कैश किए गए डेटा से चार्ट वर्कबुक को पुनः बना सकता है। [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) बनाएं, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) को कॉल करें, और [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) को `true` सेट करें, फिर प्रस्तुतीकरण खोलें।

निम्न Java उदाहरण पहले स्लाइड की पहली आकृति में स्थित चार्ट के लिए वर्कबुक डेटा पुनः प्राप्त करता है जो अनुपलब्ध बाहरी वर्कबुक का संदर्भ देता है। यह पुनः प्राप्त डेटा को [IChart.getChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getChartData--) और [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) के माध्यम से एक्सेस करता है:

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

        // पुनः प्राप्त वर्कबुक डेटा को यहाँ पढ़ें या संशोधित करें।
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

यदि बाहरी वर्कबुक अनुपलब्ध है और पुनः प्राप्ति अक्षम है, तो Aspose.Slides अपवाद फेंकेगा। पुनः प्राप्ति केवल तभी सक्षम करें जब कैश्ड चार्ट डेटा का उपयोग एक स्वीकार्य फॉलबैक हो, क्योंकि कैश में बाहरी वर्कबुक में किए गए परिवर्तन शामिल नहीं हो सकते।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं यह निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाहरी या एम्बेडेड वर्कबुक से लिंक्ड है?**

हां। चार्ट का एक [data source type](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getDataSourceType--) और एक [path to an external workbook](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) होता है; यदि स्रोत एक बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़कर सुनिश्चित कर सकते हैं कि बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक के सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हां। यदि आप सापेक्ष पथ निर्दिष्ट करते हैं, तो यह स्वचालित रूप से पूर्ण पथ में परिवर्तित हो जाता है। प्रस्तुतीकरण PPTX फ़ाइल में पूर्ण पथ संग्रहीत करता है, इसलिए वर्कबुक को स्थानांतरित करने पर लिंक को अपडेट करने की आवश्यकता हो सकती है।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**

हां, ऐसी वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से रिमोट वर्कबुक को सीधे संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग की जा सकती हैं।

**क्या Aspose.Slides प्रस्तुतीकरण सेव करने पर बाहरी XLSX को ओवरराइट करता है?**

प्रस्तुतीकरण एक [link to the external file](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) संग्रहीत करता है। सेल‑बैक्ड चार्ट डेटा को संपादित करने से जुड़ी स्थानीय XLSX फ़ाइल भी अपडेट हो सकती है। यदि मूल फ़ाइल को अपरिवर्तित रखना है तो वर्कबुक की एक कॉपी का उपयोग करें।

**यदि बाहरी फ़ाइल पासवर्ड‑सुरक्षित है तो मैं क्या करूँ?**

Aspose.Slides लिंकिंग के समय पासवर्ड स्वीकार नहीं करता। आम उपाय यह है कि पहले सुरक्षा हटाएँ या एक डीक्रिप्टेड कॉपी तैयार करें (उदाहरण के लिए, [Aspose.Cells](https://reference.aspose.com/cells/java/) का उपयोग करके) और उस कॉपी से लिंक करें।

**क्या कई चार्ट एक ही बाहरी वर्कबुक का संदर्भ दे सकते हैं?**

हां। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर इशारा करते हैं, तो उस फ़ाइल में परिवर्तन अगले बार डेटा लोड होने पर प्रत्येक चार्ट में परिलक्षित होगा।