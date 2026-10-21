---
title: Android पर प्रस्तुतियों में चार्ट वर्कबुक्स को प्रबंधित करें
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
description: "Aspose.Slides for Android via Java की खोज करें: PowerPoint और OpenDocument फ़ॉर्मैट में चार्ट वर्कबुक्स को सहजता से प्रबंधित करके अपनी प्रस्तुति डेटा को सुव्यवस्थित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट वर्कबुक्स के साथ काम करने के तरीकों को समझाता है। यह दिखाता है कि वर्कबुक स्ट्रीम्स के माध्यम से चार्ट डेटा को कैसे पढ़ें और लिखें, वर्कबुक कोशिकाओं को चार्ट डेटा लेबल के रूप में उपयोग करें, वर्कशीट संग्रहों तक पहुँचें, और चार्ट मानों के लिए डेटा स्रोत प्रकार को कैसे निर्दिष्ट करें।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दर्शाते हैं कि बाहरी वर्कबुक कैसे बनाएँ और असाइन करें, चार्ट से जुड़ी बाहरी वर्कबुक का पथ कैसे प्राप्त करें, और वर्कबुक उपलब्ध होने पर चार्ट डेटा को कैसे संपादित करें।

ग़ायब डेटा का प्रतिनिधित्व करने वाली वर्कबुक कोशिकाओं के लिए, खाली कोशिका और शून्य के बीच अंतर तथा उपलब्ध प्रदर्शन मोड की रेखा-चार्ट तुलना के लिए देखें [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/androidjava/chart-series/)।

## **छिपी पंक्तियों और स्तंभों से डेटा शामिल करें**

छिपी वर्कशीट पंक्तियों और स्तंभों से डेटा प्लॉट करता है या नहीं, इसको नियंत्रित करने के लिए [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) का प्रयोग करें। केवल दृश्यमान कोशिकाएँ प्लॉट करने के लिए इसे `true` सेट करें, या दृश्यमान तथा छिपी दोनों कोशिकाएँ शामिल करने के लिए `false` सेट करें। यह सेटिंग चार्ट प्लॉटिंग को नियंत्रित करती है; यह वर्कशीट पंक्तियों या स्तंभों को छिपाता या दिखाता नहीं है।

[nमूना प्रस्तुति](hidden-source-data.pptx) में पहली स्लाइड पर पहला आकार एक कॉलम चार्ट है। एंबेडेड वर्कशीट, `Sheet1`, में निम्न स्रोत रेंज `A1:C4` मौजूद है। पंक्ति 3 और स्तंभ C छिपे हुए हैं, लेकिन उनकी कोशिकाएँ अभी भी मान रखती हैं।

| वर्कशीट पंक्ति | A: माह | B: रिटेल | C: थोक (छिपा स्तंभ) |
| --- | --- | --- | --- |
| 2 | जनवरी | 10 | 30 |
| 3 (छिपी पंक्ति) | फरवरी | 40 | 60 |
| 4 | मार्च | 20 | 50 |

स्रोत कोशिकाओं तक पहुँचने के लिए [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) का उपयोग करें और उनकी छिपी स्थिति को जांचने के लिए [IChartDataCell.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) पढ़ें। यह विधि स्थिति को बदले बिना रिपोर्ट करती है। इस फ़ाइल में, B2 दृश्यमान है, B3 छिपी पंक्ति से संबंधित है, और C2 छिपे स्तंभ से संबंधित है; उदाहरण क्रमशः `false`, `true`, और `true` प्रिंट करता है।

इस उदाहरण के लिए, प्लॉटिंग सेटिंग बदलने के बाद चार्ट डेटा रीफ़्रेश करें: एंबेडेड वर्कबुक को [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) के साथ बनाए रखें और इसे [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) से पुनः लोड करें। सभी कोशिकाएँ शामिल करने पर, छिपी फ़रवरी श्रेणी को भी पुनर्स्थापित करने के लिए [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) का उपयोग करें। केवल फ़्लैग बदलना इस नमूने के कैश किए गए चार्ट डेटा और श्रेणी लेबल को रीफ़्रेश करने के लिए पर्याप्त नहीं है।

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
                // छिपी श्रेणियों सहित पूरी स्रोत रेंज को पुनर्स्थापित करें।
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

उदाहरण प्रस्तुति के दो संस्करण सहेजता है: एक केवल दृश्यमान रिटेल मानों (10 और 20) के साथ, और दूसरा सभी छह मानों के साथ। नीचे दी गई छवियाँ दो प्लॉटिंग मोड दिखाती हैं। पंक्ति 3 और स्तंभ C दोनों एंबेडेड वर्कबुक में छिपे रहते हैं।

| केवल दिखाई देने वाली कोशिकाएँ (`true`) | सभी कोशिकाएँ (`false`) |
| --- | --- |
| ![केवल दिखाई देने वाली कोशिकाएँ: जनवरी और मार्च के लिए रिटेल मान 10 और 20.](hidden_cells_True.png) | ![सभी कोशिकाएँ: जनवरी, फ़रवरी और मार्च के लिए रिटेल और थोक मान.](hidden_cells_False.png) |

एक मान वाली छिपी कोशिका खाली कोशिका से अलग होती है। [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) नियंत्रित करता है कि ग़ायब मान कैसे दिखाए जाएँ; यह छिपे स्रोत डेटा को शामिल या बाहर नहीं करता। एक उदाहरण के लिए देखें [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/androidjava/chart-series/#control-the-display-of-empty-cells)।

## **चार्ट की डेटा रेंज प्राप्त करें**

मौजूदा प्रस्तुति में वर्कबुक डेटा अपडेट करने से पहले, स्रोत रेंज की जाँच करें ताकि पता चले कि प्रत्येक चार्ट कौन सी वर्कशीट कोशिकाओं का उपयोग करता है। [IChartData.getRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getRange--) विधि वर्तमान डेटा रेंज को वर्कशीट-योग्य फ़ॉर्मूला के रूप में लौटाती है, जैसे `Sheet1!$A$1:$D$5`। यहाँ, `Sheet1` वर्कशीट का नाम है, `!` इसे कोशिका रेंज से अलग करता है, और `$A$1:$D$5` कोशिकाएँ A1 से D5 तक को दर्शाता है। डॉलर चिन्ह निरपेक्ष पंक्ति और स्तंभ संदर्भ दर्शाते हैं।

यह विधि चार्ट या उसकी वर्कबुक को बदले बिना वर्तमान रेंज पढ़ती है। यदि चार्ट डेटा स्रोत के रूप में वर्कबुक का उपयोग नहीं करता, तो यह `InvalidOperationException` फेंकती है। अधिक जानकारी के लिए देखें [ChartData API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/)।

यह उदाहरण एक प्रस्तुति खोलता है और प्रत्येक स्लाइड पर प्रत्यक्ष रूप से आकारों की जाँच करता है ताकि चार्ट मिलें। यह प्रत्येक चार्ट का नाम और स्रोत रेंज प्रिंट करता है। यदि कोई चार्ट वर्कबुक का उपयोग नहीं करता, तो यह एक संदेश प्रिंट करता है और अगले चार्ट पर आगे बढ़ता है।

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

Aspose.Slides for Android via Java [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) और [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) विधियों को प्रदान करता है जो आपको चार्ट डेटा वर्कबुक्स (Aspose.Cells के साथ संपादित) को पढ़ने और लिखने की अनुमति देती हैं। **ध्यान दें** कि चार्ट डेटा को उसी रूप में व्यवस्थित होना चाहिए या स्रोत के समान संरचना रखनी चाहिए।

यह उदाहरण एक प्रस्तुति उपयोग करता है जिसमें पहली स्लाइड पर पहला आकार एक चार्ट है। यह एंबेडेड वर्कबुक को बाइट एरे में पढ़ता है, मौजूदा श्रृंखला और श्रेणियों को साफ़ करता है, और वही वर्कबुक वापस लिखता है। परिवर्तन मेमोरी में रहते हैं; उदाहरण प्रस्तुति को सहेजता नहीं है।

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

जब आप एंबेडेड वर्कबुक को संशोधित संस्करण से बदलते हैं, तो चार्ट अपनी मूल श्रृंखला और श्रेणी संग्रहों को बनाए रखता है। यह असंगति [IChart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#validateChartLayout--) को इंडेक्स-ऑफ़-रेंज त्रुटि के साथ विफल कर सकती है। अपडेटेड वर्कबुक को चार्ट में वापस लिखने से पहले मौजूदा श्रृंखला और श्रेणियों को साफ़ करें। यह उदाहरण पहली स्लाइड पर पहला आकार एक चार्ट है। टिप्पणी दर्शाती है जहाँ वर्कबुक संपादन होगा; चलने योग्य उदाहरण मूल वर्कबुक को वापस लिखता है और मेमोरी में लेआउट को मान्य करता है।

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

कलेक्शन साफ़ करने से वर्कबुक लिखे जाने से पहले पुरानी डेटा रेफ़रेंसेज़ हटती हैं। अपडेटेड वर्कबुक के लिए आवश्यक श्रृंखला और श्रेणी मैपिंग को फिर से बनायें फिर चार्ट का उपयोग करें।

## **वर्कबुक कोशिकाओं के लिए कस्टम नंबर फ़ॉर्मेट सेट करें**

चार्ट की एंबेडेड वर्कबुक में संख्यात्मक मानों के स्वरूप को नियंत्रित करने के लिए [IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) का प्रयोग करें। उदाहरण के लिए, एक रिपोर्ट को रूपांतरण दर को चार दशमलव स्थानों के साथ प्रतिशत के रूप में और गुणांक को पाँच दशमलव स्थानों के साथ दिखाने की आवश्यकता हो सकती है। दोनों मानों को संख्यात्मक रखें ताकि वे गणनाओं और चार्ट प्लॉटिंग के लिये उपलब्ध रहें।

एक नंबर फ़ॉर्मेट केवल प्रदर्शन बदलता है, संग्रहीत मान नहीं। फ़ॉर्मेट `0.0000%` संख्या `0.125` को `12.5000%` के रूप में दिखाता है; यह संग्रहीत संख्या को `12.5` नहीं बनाता। इसी प्रकार, `0.00000` संख्या `0.1234567` को `0.12346` दिखाता है बिना संग्रहीत मान को राउंड किए। यदि कस्टम फ़ॉर्मेट खाली स्ट्रिंग (`""`) है, तो [getPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--) द्वारा लौटाया गया फ़ॉर्मेट उपयोग किया जाता है।

निम्न उदाहरण एक कॉलम चार्ट बनाता है और उसकी कोशिकाओं को [getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) के माध्यम से पहुँचता है। वर्कशीट 0 में, B2 में रूपांतरण दर और C2 में गुणांक है। दोनों कोशिकाएँ चार्ट मान प्रदान करती हैं। उदाहरण स्रोत फ़ॉर्मेट से जुड़े मान लेबल भी सक्षम करता है।

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

वर्कबुक कोशिका फ़ॉर्मेट चार्ट अक्ष या डेटा लेबल पर सीधे सेट किए गए फ़ॉर्मेट से अलग होते हैं। इस उदाहरण में, प्रत्येक लेबल अपने स्रोत कोशिका के मान को दिखाता है क्योंकि [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) `true` है, और स्रोत नंबर फ़ॉर्मेट का अनुसरण करता है क्योंकि [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) `true` है। सहेजने और प्रस्तुति को पुनः खोलने के बाद, लेबल `12.5000%` और `0.12346` दिखाते हैं, जैसा कि नीचे दिखाया गया है। वर्टिकल अक्ष अपना स्वयं का नंबर फ़ॉर्मेट उपयोग करता है, जिसे [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) द्वारा `0.00` सेट किया गया है, और [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) `false` है।

डेटा लेबल को स्वतंत्र रूप से फ़ॉर्मेट करने के लिए, उसके स्रोत‑लिंक फ़्लैग को `false` सेट करें और [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) द्वारा फ़ॉर्मेट असाइन करें। यह वर्कबुक कोशिका के फ़ॉर्मेट को नहीं बदलता। उदाहरण के लिये, स्वतंत्र लेबल फ़ॉर्मेट `0.00` पहली मान को `0.13` दिखाता है, जबकि B2 अभी भी `12.5000%` दिखाता है। सीधे लेबल फ़ॉर्मेटिंग के लिये देखें [Chart Data Labels](/slides/hi/androidjava/chart-data-label/#set-the-percentage-sign-with-chart-data-labels)।

नीचे की छवि सहेजी गई प्रस्तुति को पुनः खोलने के बाद रेंडर की गई है:

![स्रोत‑लिंक्ड लेबल दिखाते हुए कॉलम चार्ट, 12.5000% और 0.12346 तथा स्वतंत्र रूप से फ़ॉर्मेट किए गए संख्यात्मक अक्ष.](custom-cell-formats.png)

## **वर्कबुक कोशिका को चार्ट डेटा लेबल के रूप में सेट करें**

आप वर्कबुक कोशिकाओं से पाठ को चार्ट डेटा लेबल के रूप में उपयोग कर सकते हैं।

यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर एक बबल चार्ट जोड़ता है जिसमें डिफ़ॉल्ट डेटा है। यह वर्कशीट 0 में A10:A12 कोशिकाओं को पहले श्रृंखला के पहले तीन लेबल के रूप में उपयोग करता है, कोशिकाओं से लेबल सक्षम करता है, और अपडेटेड प्रस्तुति को सहेजता है।

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

## **वर्कशीट्स प्रबंधित करें**

[IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) विधि चार्ट वर्कबुक में मौजूद वर्कशीट्स तक पहुँच प्रदान करती है। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और प्रत्येक वर्कशीट का नाम कंसोल में प्रिंट करता है।

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

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक 3D कॉलम चार्ट बनाता है और दो श्रृंखला नाम विभिन्न डेटा स्रोतों से सेट करता है। पहला नाम स्ट्रिंग लिटरल है; दूसरा वर्कशीट 0 में सेल C1 से लिया गया है। [DataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/) एनीमरेशन प्रत्येक नाम के स्रोत को चुनता है। उदाहरण अपडेटेड श्रृंखला नामों के साथ प्रस्तुति को सहेजता है।

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

## **असमर्थित एंबेडेड वर्कबुक फ़ॉर्मेट का पता लगाएँ**

Aspose.Slides उन चार्ट में एंबेडेड Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट को समर्थन नहीं देता। आप [IChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/) पर [getEmbeddedWorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) विधि को [WorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/workbooktype/) एनीमरेशन के साथ उपयोग करके असमर्थित फ़ॉर्मेट का पता लगा सकते हैं और उन चार्ट को छोड़ सकते हैं। यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर आकारों की जाँच करता है, गैर‑चार्ट आकारों को छोड़ता है, और प्रत्येक चार्ट जो एक एंबेडेड .xlsb वर्कबुक रखता है, उसके लिये निदान संदेश प्रिंट करता है।

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

        // यहाँ समर्थित चार्ट वर्कबुक डेटा को पढ़ें या संशोधित करें।
    }
} finally {
    presentation.dispose();
}
```

## **बाहरी वर्कबुक**

Aspose.Slides चार्ट के लिए डेटा स्रोत के रूप में बाहरी वर्कबुक का उपयोग समर्थन करता है।

### **बाहरी वर्कबुक बनाएं**

[readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) और [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) का उपयोग करके एंबेडेड चार्ट वर्कबुक को फ़ाइल में निर्यात करें और चार्ट को उस बाहरी वर्कबुक से लिंक करें।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और उसकी वर्कबुक निर्यात करता है। यह फ़ाइल लिखना पूरा करने के बाद बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में असाइन करता है, फिर लिंक्ड प्रस्तुति को सहेजता है।

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

### **बाहरी वर्कबुक असाइन करें**

[setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) विधि का प्रयोग करके आप एक चार्ट को बाहरी वर्कबुक को उसके डेटा स्रोत के रूप में असाइन कर सकते हैं। यह विधि बाहरी वर्कबुक के पथ को अपडेट करने के लिये भी उपयोग की जा सकती है (यदि इसे स्थानांतरित किया गया हो)।

जबकि आप दूरस्थ स्थानों या संसाधनों में संग्रहीत वर्कबुक के डेटा को संपादित नहीं कर सकते, आप ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी वर्कबुक के लिए सापेक्ष पथ प्रदान किया गया है, तो यह स्वतः पूर्ण पथ में परिवर्तित हो जाता है।

यह उदाहरण एक बाहरी वर्कबुक का उपयोग करता है जिसमें वर्कशीट जिसका नाम `Sheet1` है, उसमें B1 में श्रृंखला नाम, A2:A4 में श्रेणी नाम, और B2:B4 में संख्यात्मक मान हैं। उदाहरण एक पाई चार्ट बनाता है, वर्कबुक को लिंक करता है, और [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) का उपयोग करके A1:B4 को एक श्रृंखला और तीन श्रेणियों से मैप करता है। यह लिंक्ड चार्ट के साथ प्रस्तुति को सहेजता है।

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

* जब `updateChartData` `false` हो, तो केवल वर्कबुक पथ अपडेट होता है। चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं किया जाता, इसलिए वर्कबुक अनुपलब्ध हो सकता है।
* जब `updateChartData` `true` हो, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट होता है।

निम्न उदाहरण `updateChartData` को `false` पर सेट करके एक प्लेसहोल्डर URL असाइन करता है। यह पाई चार्ट के डिफ़ॉल्ट डेटा को बरकरार रखता है और अनुपलब्ध वर्कबुक को लोड किए बिना प्रस्तुति को सहेजता है।

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

### **एक चार्ट की बाहरी डेटा स्रोत वर्कबुक पथ प्राप्त करें**

किसी चार्ट से जुड़ी वर्कबुक को पहचानने के लिये, जाँचें कि चार्ट बाहरी डेटा स्रोत का उपयोग करता है या नहीं और उसकी वर्कबुक पथ प्राप्त करें।

यह उदाहरण एक प्रस्तुति की पहली स्लाइड पर पहले आकार की जाँच करता है जो बाहरी वर्कबुक से लिंक्ड है। यदि यह एक चार्ट है जो बाहरी वर्कबुक से लिंक्ड है, तो उदाहरण [getExternalWorkbookPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) को कंसोल में प्रिंट करता है। फिर यह प्रस्तुति की एक कॉपी सहेजता है।

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

आप बाहरी वर्कबुक में डेटा को उसी तरह संपादित कर सकते हैं जैसा आप आंतरिक वर्कबुक के सामग्री में परिवर्तन करते हैं। जब कोई बाहरी वर्कबुक लोड नहीं हो पाता, तो एक अपवाद फेंका जाता है।

यह उदाहरण पहली स्लाइड पर पहला आकार एक चार्ट है और यह एक सुलभ बाहरी वर्कबुक से लिंक्ड है। यह पहली श्रृंखला के पहले डेटा पॉइंट का सेल‑बैक्ड मान 100 सेट करता है और अपडेटेड प्रस्तुति को सहेजता है। सेल मानों को संपादित करने से लिंक्ड बाहरी XLSX फ़ाइल अपडेट हो सकती है, इसलिए मूल वर्कबुक को संरक्षित रखने हेतु एक कॉपी का उपयोग करें।

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

यदि कोई चार्ट ऐसे बाहरी वर्कबुक का उपयोग करता है जो गायब या अनुपलब्ध है, तो Aspose.Slides प्रस्तुति में कैश किए गए डेटा से चार्ट वर्कबुक को पुनः निर्मित कर सकता है। पहले [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) बनाएँ, फिर [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) को कॉल करें, और खुलने से पहले [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) को `true` सेट करें।

निचे का Java उदाहरण एक चार्ट के लिए वर्कबुक डेटा पुनः प्राप्त करता है जो पहली स्लाइड पर पहला आकार है और एक अनुपलब्ध बाहरी वर्कबुक को संदर्भित करता है। यह पुनः प्राप्त डेटा को [IChart.getChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getChartData--) और [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) के माध्यम से एक्सेस करता है:

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

        // यहाँ पुनर्प्राप्त वर्कबुक डेटा को पढ़ें या संशोधित करें।
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

यदि बाहरी वर्कबुक अनुपलब्ध है और पुनर्प्राप्ति अक्षम है, तो Aspose.Slides अपवाद फेंकता है। पुनर्प्राप्ति तभी सक्षम करें जब कैश किया हुआ चार्ट डेटा एक स्वीकार्य वैकल्पिक समाधान हो, क्योंकि कैश में बाहरी वर्कबुक में किए गए बदलाव शामिल नहीं हो सकते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं यह निर्धारित कर सकता हूँ कि कोई विशेष चार्ट बाहरी या एंबेडेड वर्कबुक से लिंक्ड है?**

हाँ। एक चार्ट का [डेटा स्रोत प्रकार](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) और एक [बाहरी वर्कबुक पथ](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) होता है; यदि स्रोत बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़कर सुनिश्चित कर सकते हैं कि बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक के सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हाँ। यदि आप सापेक्ष पथ निर्दिष्ट करते हैं, तो वह स्वतः पूर्ण पथ में परिवर्तित हो जाता है। प्रस्तुति PPTX फ़ाइल में पूर्ण पथ संग्रहीत करती है, इसलिए वर्कबुक को स्थानांतरित करने पर लिंक को अपडेट करने की आवश्यकता हो सकती है।

**क्या मैं नेटवर्क संसाधनों/शेयर्स पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**

हाँ, ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से सीधे रिमोट वर्कबुक को संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग किए जा सकते हैं।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

प्रस्तुति एक [बाहरी फ़ाइल का लिंक](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) रखती है। सेल‑बैक्ड चार्ट डेटा को संपादित करने से लिंक्ड स्थानीय XLSX फ़ाइल भी अपडेट हो सकती है। यदि मूल वर्कबुक अपरिवर्तित रहना चाहिए, तो उसकी कॉपी का उपयोग करें।

**यदि बाहरी फ़ाइल पासवर्ड‑सुरक्षित है तो मुझे क्या करना चाहिए?**

Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। एक आम तरीका यह है कि पहले सुरक्षा हटाएँ या एक डिक्रिप्टेड कॉपी तैयार करें (उदाहरण के लिए, [Aspose.Cells](https://reference.aspose.com/cells/java/) का उपयोग करके) और उस कॉपी को लिंक करें।

**क्या कई चार्ट एक ही बाहरी वर्कबुक का संदर्भ दे सकते हैं?**

हाँ। प्रत्येक चार्ट अपना लिंक रखता है। यदि सभी एक ही फ़ाइल की ओर इशारा करते हैं, तो उस फ़ाइल को अपडेट करने से अगली बार डेटा लोड होने पर सभी चार्ट पर प्रभाव पड़ेगा।