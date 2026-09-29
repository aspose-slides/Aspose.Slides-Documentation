---
title: Android पर प्रस्तुतियों में चार्ट वर्कबुक प्रबंधित करें
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
description: "Aspose.Slides for Android via Java को खोजें: PowerPoint और OpenDocument स्वरूपों में चार्ट वर्कबुक को सहजता से प्रबंधित करके अपनी प्रस्तुति डेटा को सुव्यवस्थित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने के तरीके को समझाता है। यह वर्कबुक स्ट्रीम्स के माध्यम से चार्ट डेटा को पढ़ने और लिखने, वर्कबुक सेल्स को चार्ट डेटा लेबल के रूप में उपयोग करने, वर्कशीट संग्रहों तक पहुंचने, और चार्ट मानों के लिए डेटा स्रोत प्रकार निर्दिष्ट करने को दिखाता है।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दर्शाते हैं कि बाहरी वर्कबुक कैसे बनाएं और असाइन करें, चार्ट से जुड़े बाहरी वर्कबुक का पथ कैसे प्राप्त करें, और वर्कबुक उपलब्ध होने पर चार्ट डेटा को कैसे संपादित करें।

गुम डेटा का प्रतिनिधित्व करने वाले वर्कबुक सेल्स के लिए, खाली सेल और शून्य के बीच अंतर, तथा उपलब्ध प्रदर्शन मोड की तुलना के लिए [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/androidjava/chart-series/) देखें।

## **छिपी पंक्तियों और स्तंभों से डेटा शामिल करें**

छिपी वर्कशीट पंक्तियों और स्तंभों से डेटा प्लॉट करे या न करे, यह नियंत्रित करने के लिए [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) का उपयोग करें। `true` सेट करने पर केवल दिखाई देने वाले सेल्स प्लॉट होंगे, जबकि `false` पर दिखाई देने वाले और छिपे दोनों सेल्स शामिल होंगे। यह सेटिंग केवल चार्ट प्लॉटिंग को नियंत्रित करती है; यह वर्कशीट पंक्तियों या स्तंभों को छिपाती या दिखाती नहीं है।

[hidden-source-data.pptx](hidden-source-data.pptx) डाउनलोड करें और इसे कार्य निर्देशिका में रखें। इसकी पहली स्लाइड में पहला आकार एक कॉलम चार्ट है। एंबेडेड वर्कशीट, `Sheet1`, में स्रोत सीमा `A1:C4` है। पंक्ति 3 और स्तंभ C छिपे हुए हैं, पर उनके सेल्स में अभी भी मान हैं।

| Worksheet row | A: Month | B: Retail | C: Wholesale (hidden column) |
| --- | --- | --- | --- |
| 2 | जनवरी | 10 | 30 |
| 3 (hidden row) | फरवरी | 40 | 60 |
| 4 | मार्च | 20 | 50 |

स्रोत सेल्स तक पहुंचने के लिए [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) का उपयोग करें और उनके छिपे होने की स्थिति की जांच के लिए [IChartDataCell.isHidden](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) पढ़ें। यह विधि स्थिति को बदले बिना रिपोर्ट करती है। इस फ़ाइल में, B2 दिखाई देता है, B3 छिपी पंक्ति से संबंधित है, और C2 छिपे स्तंभ से संबंधित है; उदाहरण क्रमशः `false`, `true`, और `true` प्रिंट करता है।

इस उदाहरण के लिए, प्लॉटिंग सेटिंग बदलने के बाद चार्ट डेटा को रीफ़्रेश करें: एंबेडेड वर्कबुक को [readWorkbookStream](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) से प्राप्त रखें और इसे [writeWorkbookStream](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-) से पुनः लोड करें। सभी सेल्स शामिल करने पर, छिपी फ़रवरी श्रेणी को भी पुनर्स्थापित करने के लिए [setRange](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) का प्रयोग करें। केवल फ़्लैग बदलना इस नमूने के कैश्ड चार्ट डेटा और श्रेणी लेबल को रीफ़्रेश करने के लिए पर्याप्त नहीं है।

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
                // छिपी श्रेणियों सहित पूरे स्रोत सीमा को पुनर्स्थापित करें।
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

उदाहरण `hidden_cells_true.pptx` को केवल दिखाई देने वाले रिटेल मान (10 और 20) के साथ, तथा `hidden_cells_false.pptx` को सभी छह मानों के साथ सहेजता है। नीचे की छवियां दो प्लॉटिंग मोड दिखाती हैं। पंक्ति 3 और स्तंभ C दोनों एंबेडेड वर्कबुक में अभी भी छिपे हैं।

| केवल दिखाई देने वाले सेल्स (`true`) | सभी सेल्स (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

एक मान वाला छिपा सेल खाली सेल से अलग होता है। [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) नियंत्रित करता है कि गुम मान कैसे दर्शाए जाएँ; यह छिपे स्रोत डेटा को शामिल या बहिष्कृत नहीं करता। एक उदाहरण के लिए देखें [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/androidjava/chart-series/#control-the-display-of-empty-cells)।

## **वर्कबुक से चार्ट डेटा पढ़ें और लिखें**

Aspose.Slides for Android via Java, [readWorkbookStream](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) और [writeWorkbookStream](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-) मेथड प्रदान करता है जिससे आप चार्ट डेटा वर्कबुक (Aspose.Cells के साथ संपादित) को पढ़ और लिख सकते हैं। **ध्यान दें** कि चार्ट डेटा को समान संरचना में व्यवस्थित होना चाहिए या स्रोत के समान होना चाहिए।

यह उदाहरण `chart.pptx` को खोलता है, जिसे अपनी पहली स्लाइड के पहले आकार के रूप में एक चार्ट होना चाहिए। यह एंबेडेड वर्कबुक को बाइट एरे में पढ़ता है, मौजूदा सीरीज़ और श्रेणियों को साफ़ करता है, और वही वर्कबुक वापस लिखता है। परिवर्तन मेमोरी में रहते हैं; उदाहरण प्रस्तुति को सहेजता नहीं है।

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

जब आप एंबेडेड वर्कबुक को संशोधित वर्कबुक से बदलते हैं, तो चार्ट अपने मूल सीरीज़ और श्रेणी संग्रह बनाए रखता है। यह असंगति [IChart.validateChartLayout](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichart/#validateChartLayout--) को इंडेक्स‑आउट‑ऑफ़‑रेंज त्रुटि के साथ विफल बना सकती है। अपडेटेड वर्कबुक को चार्ट में लिखने से पहले मौजूदा सीरीज़ और श्रेणियों को साफ़ करें। यह उदाहरण `chart.pptx` की आवश्यकता रखता है, जिसमें पहली स्लाइड के पहले आकार के रूप में एक चार्ट हो। टिप्पणी उन बिंदुओं को दर्शाती है जहाँ वर्कबुक संपादन होगा; चलने योग्य उदाहरण मूल वर्कबुक को वापस लिखता है और मेमोरी में लेआउट को मान्य करता है।

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

कलेक्शन को साफ़ करने से वर्कबुक लिखे जाने से पहले पुराने डेटा रेफरेंसेज़ हट जाते हैं। अपडेटेड वर्कबुक के लिए आवश्यक किसी भी सीरीज़ और श्रेणी मैपिंग को पुनः बनाएं, फिर चार्ट का उपयोग करें।

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करें**

आप वर्कबुक सेल्स के टेक्स्ट को चार्ट डेटा लेबल के रूप में उपयोग कर सकते हैं। निम्नलिखित चरण बबल चार्ट के लेबल को उसके डेटा वर्कबुक की सेल्स से लिंक करने का तरीका दिखाते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
1. शून्य‑आधारित इंडेक्स द्वारा पहली स्लाइड तक पहुंचें।
1. डिफ़ॉल्ट डेटा के साथ एक बबल चार्ट जोड़ें।
1. चार्ट सीरीज़ तक पहुंचें।
1. वर्कबुक सेल को डेटा लेबल के रूप में सेट करें।
1. प्रस्तुति को सहेजें।

यह उदाहरण `chart2.pptx` को खोलता है, जिसमें कम से कम एक स्लाइड होनी चाहिए, और डिफ़ॉल्ट डेटा के साथ एक बबल चार्ट जोड़ता है। यह वर्कशीट 0 की सेल्स A10:A12 को पहली सीरीज़ की पहली तीन लेबल्स के लिए उपयोग करता है, सेल‑बैक्ड लेबल सक्षम करता है, और परिणाम को `resultchart.pptx` में सहेजता है।

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

## **वर्कशीट प्रबंधन करें**

[IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) मेथड चार्ट वर्कबुक में वर्कशीट्स तक पहुंच प्रदान करता है। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और प्रत्येक वर्कशीट नाम को कंसोल पर प्रिंट करता है।

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

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक 3D कॉलम चार्ट बनाता है और दो सीरीज़ नाम विभिन्न डेटा स्रोतों से सेट करता है। पहला नाम स्ट्रिंग लिटरल है; दूसरा वर्कशीट 0 की सेल C1 से। [DataSourceType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/datasourcetype/) एनेमरेशन प्रत्येक नाम के स्रोत को चुनता है। परिणाम `pres.pptx` में सहेजा जाता है।

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

## **एंबेडेड वर्कबुक के असमर्थित स्वरूपों का पता लगाएँ**

Aspose.Slides कुछ चार्ट में एंबेडेड एक्सेल बाइनरी वर्कबुक (.xlsb) स्वरूप का समर्थन नहीं करता। आप [IChartData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdata/) पर [getEmbeddedWorkbookType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) मेथड को [WorkbookType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/workbooktype/) एनेमरेशन के साथ प्रयोग करके असमर्थित स्वरूपों का पता लगा सकते हैं और उन चार्ट को स्किप कर सकते हैं। यह उदाहरण `sample.pptx` की पहली स्लाइड पर आकारों को जांचता है, गैर‑चार्ट आकारों को छोड़ता है, और एंबेडेड .xlsb वर्कबुक वाले प्रत्येक चार्ट के लिए निदान संदेश प्रिंट करता है।

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

Aspose.Slides चार्ट के लिए डेटा स्रोत के रूप में बाहरी वर्कबुक का उपयोग समर्थन करता है।

### **एक बाहरी वर्कबुक बनाएं**

एक एंबेडेड चार्ट वर्कबुक को फ़ाइल में एक्सपोर्ट करने और चार्ट को उस बाहरी वर्कबुक से लिंक करने के लिए [readWorkbookStream](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) और [setExternalWorkbook](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) का उपयोग करें।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है, उसकी वर्कबुक को `externalWorkbook1.xlsx` में लिखता है, और फ़ाइल को चार्ट डेटा स्रोत असाइन करने से पहले लिखना समाप्त करता है। लिंक की गई प्रस्तुति को `externalWorkbook.pptx` में सहेजता है।

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

[setExternalWorkbook](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) मेथड का उपयोग करके आप एक चार्ट को बाहरी वर्कबुक को उसके डेटा स्रोत के रूप में असाइन कर सकते हैं। यह मेथड बाहरी वर्कबुक के पथ को अपडेट करने के लिए भी उपयोग किया जा सकता है (यदि वह स्थानांतरित किया गया हो)।

रिमोट स्थान या संसाधनों में संग्रहीत वर्कबुक के डेटा को सीधे संपादित नहीं किया जा सकता, पर उन्हें बाहरी डेटा स्रोत के रूप में इस्तेमाल किया जा सकता है। यदि बाहरी वर्कबुक के लिए सापेक्ष पथ प्रदान किया जाता है, तो वह स्वचालित रूप से पूर्ण पथ में परिवर्तित हो जाता है।

यह उदाहरण कार्य निर्देशिका में `externalWorkbook.xlsx` की आवश्यकता रखता है। उसकी वर्कशीट `Sheet1` में B1 में एक सीरीज़ नाम, A2:A4 में श्रेणी नाम, और B2:B4 में संख्यात्मक मान होने चाहिए। उदाहरण पाई चार्ट बनाता है, वर्कबुक को लिंक करता है, और [setRange](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) का उपयोग करके A1:B4 को एक सीरीज़ और तीन श्रेणियों से मैप करता है। परिणाम `Presentation_with_externalWorkbook.pptx` में सहेजा जाता है।

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

[setExternalWorkbook](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) के `updateChartData` पैरामीटर से तय होता है कि वर्कबुक लोड की जाए या नहीं।

* जब `updateChartData` `false` हो, तो केवल वर्कबुक पथ अपडेट होता है। चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं होता, इसलिए वर्कबुक अनुपलब्ध भी हो सकती है।
* जब `updateChartData` `true` हो, तो लक्ष्य वर्कबुक से चार्ट डेटा अपडेट हो जाता है।

निम्न उदाहरण `updateChartData` को `false` रखते हुए एक प्लेसहोल्डर URL असाइन करता है। यह पाई चार्ट का डिफ़ॉल्ट डेटा बनाए रखता है और अनुपलब्ध वर्कबुक को लोड किए बिना प्रस्तुति सहेजता है।

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

किसी चार्ट से जुड़ी वर्कबुक पहचानने के लिए, पहले जांचें कि क्या चार्ट बाहरी डेटा स्रोत उपयोग करता है। यदि हाँ, तो नीचे दिए चरणों से वर्कबुक पथ प्राप्त करें।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
1. शून्य‑आधारित इंडेक्स द्वारा पहली स्लाइड तक पहुंचें।
1. जांचें कि पहला आकार एक चार्ट है या नहीं।
1. चार्ट डेटा स्रोत प्रकार पढ़ें।
1. यदि स्रोत एक बाहरी वर्कबुक है, तो उसका पथ पढ़ें।

यह उदाहरण `externalWorkbook.pptx` खोलता है, जो पहले उदाहरण में बनाया गया था, और पहली स्लाइड के पहले आकार की जांच करता है। यदि वह बाहरी वर्कबुक से लिंक्ड चार्ट है, तो उदाहरण कंसोल पर [getExternalWorkbookPath](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) प्रिंट करता है। फिर वह प्रस्तुति की एक कॉपी `Result.pptx` में सहेजता है।

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

आप बाहरी वर्कबुक के डेटा को उसी तरह संपादित कर सकते हैं जैसे आप आंतरिक वर्कबुक की सामग्री बदलते हैं। जब कोई बाहरी वर्कबुक लोड नहीं हो पाती, तो अपवाद उत्पन्न होता है।

यह उदाहरण `presentation.pptx` की आवश्यकता रखता है, जिसमें पहली स्लाइड पर पहला आकार एक चार्ट होना चाहिए, और एक अभिगम्य बाहरी वर्कबुक भी हो। यह पहली सीरीज़ के पहले डेटा पॉइंट का सेल‑बैक्ड मान 100 पर सेट करता है और प्रस्तुति को `presentation_out.pptx` में सहेजता है। सेल मानों को संपादित करने से लिंक्ड बाहरी XLSX फ़ाइल अपडेट हो सकती है, इसलिए मूल वर्कबुक को सुरक्षित रखने हेतु एक कॉपी का उपयोग करें।

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

### **चार्ट कैश से वर्कबुक पुनर्प्राप्त करें**

यदि कोई चार्ट बाहरी वर्कबुक का उपयोग करता है जो अनुपलब्ध है, तो Aspose.Slides प्रस्तुति में कैश्ड डेटा से चार्ट वर्कबुक को पुनर्निर्मित कर सकता है। [LoadOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/) बनाएं, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) को कॉल करें, और [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) को `true` पर सेट करें, फिर प्रस्तुति खोलें।

निम्न Java उदाहरण `presentation.pptx` खोलता है, जिसकी पहली स्लाइड पर पहला आकार एक चार्ट होना चाहिए जो अनुपलब्ध बाहरी वर्कबुक को संदर्भित करता है, और पुनर्प्राप्त डेटा को [IChart.getChartData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichart/#getChartData--) और [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) के माध्यम से एक्सेस करता है:

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

        // यहाँ पुनः प्राप्त वर्कबुक डेटा को पढ़ें या संशोधित करें।
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

यदि बाहरी वर्कबुक अनुपलब्ध है और रिकवरी निष्क्रिय है, तो Aspose.Slides अपवाद फेंकेगा। केवल तब रिकवरी सक्षम करें जब कैश्ड चार्ट डेटा का उपयोग स्वीकार्य फॉलबैक हो, क्योंकि कैश में बाहरी वर्कबुक में किए गए बाद के परिवर्तन शामिल नहीं हो सकते।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशेष चार्ट बाहरी या एंबेडेड वर्कबुक से लिंक्ड है?**

हां। एक चार्ट के पास [डेटा स्रोत प्रकार](/slides/hi/androidjava/chartdata/#getDataSourceType--) और एक [बाहरी वर्कबुक पथ](/slides/hi/androidjava/chartdata/#getExternalWorkbookPath--) होता है; यदि स्रोत एक बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़ सकते हैं ताकि पुष्टि हो सके कि बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक के सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हां। यदि आप सापेक्ष पथ निर्दिष्ट करते हैं, तो वह स्वचालित रूप से पूर्ण पथ में बदल दिया जाता है। प्रस्तुति PPTX फ़ाइल में पूर्ण पथ संग्रहीत करती है, इसलिए वर्कबुक को स्थानांतरित करने पर लिंक को अपडेट करना पड़ सकता है।

**क्या मैं नेटवर्क संसाधनों/शेयर्स पर स्थित वर्कबुक का उपयोग कर सकता हूं?**

हां, ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से रिमोट वर्कबुक को सीधे संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग किए जा सकते हैं।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

प्रस्तुति में [बाहरी फ़ाइल का लिंक](/slides/hi/androidjava/chartdata/#getExternalWorkbookPath--) संग्रहीत होता है। सेल‑बैक्ड चार्ट डेटा को संपादित करने से लिंक्ड स्थानीय XLSX फ़ाइल भी अपडेट हो सकती है। यदि मूल फ़ाइल को अपरिवर्तित रखना है, तो वर्कबुक की एक कॉपी उपयोग करें।

**यदि बाहरी फ़ाइल पासवर्ड‑सुरक्षित है तो क्या करें?**

Aspose.Slides लिंकिंग के दौरान पासवर्ड स्वीकार नहीं करता। सामान्य तरीका यह है कि पहले सुरक्षा हटा दें या एक डिक्रिप्टेड कॉपी तैयार करें (उदाहरण के लिए, Aspose.Cells का उपयोग करके) और उस कॉपी से लिंक करें।

**क्या कई चार्ट एक ही बाहरी वर्कबुक का संदर्भ दे सकते हैं?**

हां। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर संकेत करते हैं, तो उस फ़ाइल में बदलाव प्रत्येक चार्ट में अगली बार डेटा लोड होने पर परिलक्षित होगा।