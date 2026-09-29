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
- बाह्य वर्कबुक
- बाह्य डेटा
- चार्ट कैश
- वर्कबुक पुनर्प्राप्ति
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java की खोज करें: PowerPoint और OpenDocument फ़ॉर्मेट में चार्ट वर्कबुक को आसानी से प्रबंधित करके अपनी प्रस्तुति डेटा को सरल बनाएं।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने के तरीके को समझाता है। यह दिखाता है कि वर्कबुक स्ट्रिम्स के माध्यम से चार्ट डेटा को पढ़ा और लिखा जाए, वर्कबुक कोशिकाओं को चार्ट डेटा लेबल के रूप में उपयोग किया जाए, वर्कशीट संग्रह तक पहुंचा जाए, और चार्ट मानों के लिए डेटा स्रोत प्रकार को निर्दिष्ट किया जाए।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दिखाते हैं कि बाहरी वर्कबुक कैसे बनाया और असाइन किया जाए, चार्ट से जुड़ी बाहरी वर्कबुक का पथ कैसे प्राप्त किया जाए, और वर्कबुक उपलब्ध होने पर चार्ट डेटा को कैसे संपादित किया जाए।

खाली डेटा का प्रतिनिधित्व करने वाली वर्कबुक कोशिकाओं के लिए, एक खाली कोशिका और शून्य के बीच अंतर तथा उपलब्ध प्रदर्शनी मोड की लाइन-चार्ट तुलना के लिए, [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/java/chart-series/) देखें।

## **छिपी पंक्तियों और स्तंभों से डेटा शामिल करें**

चार्ट को छिपी वर्कशीट पंक्तियों और स्तंभों से डेटा प्लॉट करना है या नहीं, इसे नियंत्रित करने के लिए [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) का उपयोग करें। इसे `true` पर सेट करने से केवल दृश्यमान कोशिकाएँ प्लॉट होंगी, और `false` पर सेट करने से दृश्यमान और छिपी दोनों कोशिकाएँ शामिल होंगी। यह सेटिंग चार्ट प्लॉटिंग को नियंत्रित करती है; यह वर्कशीट पंक्तियों या स्तंभों को छिपाती या दिखाती नहीं है।

डाउनलोड करें [hidden-source-data.pptx](hidden-source-data.pptx) और इसे कार्य निर्देशिका में रखें। इसकी पहली स्लाइड में पहले आकार के रूप में एक कॉलम चार्ट है। एम्बेडेड वर्कशीट `Sheet1` में निम्न स्रोत सीमा `A1:C4` है। पंक्ति 3 और स्तंभ C छिपे हुए हैं, लेकिन उनकी कोशिकाओं में अभी भी मान मौजूद हैं।

| वर्कशीट पंक्ति | A: महीना | B: रिटेल | C: होलसेल (छिपा स्तंभ) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (छिपी पंक्ति) | February | 40 | 60 |
| 4 | March | 20 | 50 |

सोर्स कोशिकाओं तक पहुंचने के लिए [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) का उपयोग करें और उनकी छिपी स्थिति जांचने के लिए [IChartDataCell.isHidden](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdatacell/#isHidden--) पढ़ें। यह मेथड स्थिति को बदले बिना छिपी स्थिति रिपोर्ट करता है। इस फ़ाइल में, B2 दृश्यमान है, B3 छिपी पंक्ति से संबंधित है, और C2 छिपे स्तंभ से संबंधित है; उदाहरण क्रमशः `false`, `true`, और `true` प्रिंट करता है।

इस उदाहरण के लिए, प्लॉटिंग सेटिंग बदलने के बाद चार्ट डेटा को रिफ्रेश करें: एम्बेडेड वर्कबुक को [readWorkbookStream](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdata/#readWorkbookStream--) से बनाए रखें और इसे [writeWorkbookStream](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-) से पुनः लोड करें। सभी कोशिकाओं को शामिल करने पर, पूर्ण श्रेणी को पुनर्स्थापित करने के लिए, जिसमें छिपी फ़रवरी श्रेणी भी शामिल है, [setRange](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) का भी उपयोग करें। केवल फ़्लैग बदलने से इस सैंपल के कैश्ड चार्ट डेटा और श्रेणी लेबल को रिफ्रेश करने के लिए पर्याप्त नहीं है।

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

            // एम्बेडेड वर्कबुक से चार्ट डेटा को ताज़ा करें।
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // छुपी श्रेणियों सहित पूर्ण स्रोत सीमा को पुनर्स्थापित करें।
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

यह उदाहरण `hidden_cells_true.pptx` को केवल दृश्यमान रिटेल मानों (10 और 20) के साथ सहेजता है, और `hidden_cells_false.pptx` को सभी छह मानों के साथ सहेजता है। नीचे दी गई छवियां दो प्लॉटिंग मोड का प्रदर्शन करती हैं। पंक्ति 3 और स्तंभ C दोनों एम्बेडेड वर्कबुक में छिपे हुए रहते हैं।

| केवल दृश्यमान कोशिकाएँ (`true`) | सभी कोशिकाएँ (`false`) |
| --- | --- |
| ![केवल दृश्यमान कोशिकाएँ: जनवरी और मार्च के लिए रिटेल मान 10 और 20।](hidden_cells_True.png) | ![सभी कोशिकाएँ: जनवरी, फ़रवरी और मार्च के लिए रिटेल और होलसेल मान।](hidden_cells_False.png) |

एक मान युक्त छिपी कोशिका खाली कोशिका से अलग होती है। [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) नियंत्रित करता है कि अनुपलब्ध मान कैसे प्रदर्शित हों; यह छिपे स्रोत डेटा को शामिल या बाहर नहीं करता। एक उदाहरण के लिए देखें [खाली कोशिकाओं के प्रदर्शन को नियंत्रित करें](/slides/hi/java/chart-series/#control-the-display-of-empty-cells)।

## **एक वर्कबुक से चार्ट डेटा पढ़ना और लिखना**

Aspose.Slides for Java [readWorkbookStream](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdata/#readWorkbookStream--) और [writeWorkbookStream](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-) मेथड प्रदान करता है जो आपको चार्ट डेटा वर्कबुक (जिसमें Aspose.Cells द्वारा संपादित चार्ट डेटा है) को पढ़ने और लिखने की अनुमति देते हैं। **ध्यान दें** कि चार्ट डेटा को उसी तरीके से व्यवस्थित करना होगा या स्रोत के समान संरचना होनी चाहिए।

यह उदाहरण `chart.pptx` खोलता है, जिसमें पहली स्लाइड की पहली आकृति के रूप में एक चार्ट होना चाहिए। यह एम्बेडेड वर्कबुक को बाइट एरे में पढ़ता है, मौजूदा सीरीज़ और श्रेणियों को साफ़ करता है, और वही वर्कबुक वापस लिखता है। परिवर्तन मेमोरी में रहते हैं; यह उदाहरण प्रस्तुति को सहेजता नहीं है।

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

जब आप एम्बेडेड वर्कबुक को संशोधित वर्कबुक से बदलते हैं, तो चार्ट अपनी मूल सीरीज़ और श्रेणी संग्रह को रखता है। यह असंगति [IChart.validateChartLayout](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichart/#validateChartLayout--) को इंडेक्स-आउट-ऑफ़-रेंज त्रुटि के साथ फेल करवा सकती है। अपडेटेड वर्कबुक को चार्ट में वापस लिखने से पहले मौजूदा सीरीज़ और श्रेणियों को साफ़ करें। इस उदाहरण को `chart.pptx` की आवश्यकता है, जिसमें पहली स्लाइड की पहली आकृति के रूप में एक चार्ट होना चाहिए। टिप्पणी दर्शाती है कि वर्कबुक संपादन कहाँ होगा; निष्पादन योग्य उदाहरण मूल वर्कबुक को वापस लिखता है और मेमोरी में लेआउट को सत्यापित करता है।

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

संग्रहों को साफ़ करने से वर्कबुक वापस लिखने से पहले पुराने डेटा रेफ़रेंस हट जाते हैं। चार्ट का उपयोग करने से पहले अपडेटेड वर्कबुक के लिए आवश्यक कोई भी सीरीज़ और श्रेणी मैपिंग पुनर्निर्मित करें।

## **वर्कबुक कोशिका को चार्ट डेटा लेबल के रूप में सेट करें**

आप वर्कबुक कोशिकाओं के पाठ को चार्ट डेटा लेबल के रूप में उपयोग कर सकते हैं। निम्नलिखित चरण दिखाते हैं कि बबल चार्ट में लेबल को उसके डेटा वर्कबुक की कोशिकाओं से कैसे जोड़ा जाए।

1. क्लास [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) का एक उदाहरण बनाएं।
1. शून्य-आधारित सूचकांक द्वारा पहली स्लाइड तक पहुँचें।
1. डिफ़ॉल्ट डेटा के साथ एक बबल चार्ट जोड़ें।
1. चार्ट सीरीज़ तक पहुँचें।
1. वर्कबुक कोशिका को डेटा लेबल के रूप में सेट करें।
1. प्रस्तुति को सहेजें।

यह उदाहरण `chart2.pptx` खोलता है, जिसमें कम से कम एक स्लाइड होनी चाहिए, और डिफ़ॉल्ट डेटा के साथ एक बबल चार्ट जोड़ता है। यह वर्कशीट 0 की कोशिकाओं A10:A12 का उपयोग पहली सीरीज़ के पहले तीन लेबल के लिए करता है, कोशिकाओं से लेबल सक्रिय करता है, और परिणाम को `resultchart.pptx` में सहेजता है।

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

[IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) मेथड चार्ट वर्कबुक में वर्कशीट्स तक पहुंच प्रदान करता है। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और प्रत्येक वर्कशीट का नाम कंसोल पर प्रिंट करता है।

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

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक 3D कॉलम चार्ट बनाता है और विभिन्न डेटा स्रोतों का उपयोग करके दो सीरीज़ नाम सेट करता है। पहला नाम स्ट्रिंग लिटरल से लेता है; दूसरा वर्कशीट 0 की कोशिका C1 से लेता है। [DataSourceType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/datasourcetype/) एनोमरेशन प्रत्येक नाम के स्रोत को चुनता है। परिणाम `pres.pptx` में सहेजा जाता है।

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

Aspose.Slides कुछ चार्ट में एम्बेड किए जा सकने वाले Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट का समर्थन नहीं करता। आप [IChartData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdata/) पर [getEmbeddedWorkbookType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) मेथड को [WorkbookType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/workbooktype/) एनोमरेशन के साथ उपयोग करके असमर्थित फ़ॉर्मेट का पता लगा सकते हैं और उन चार्ट को स्किप कर सकते हैं। यह उदाहरण `sample.pptx` की पहली स्लाइड पर आकृतियों की जांच करता है, गैर-चार्ट आकृतियों को स्किप करता है, और एम्बेडेड .xlsb वर्कबुक वाले प्रत्येक चार्ट के लिए निदान संदेश प्रिंट करता है।

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

## **बाह्य वर्कबुक**

Aspose.Slides चार्ट के डेटा स्रोत के रूप में बाह्य वर्कबुक का उपयोग समर्थन करता है।

### **बाह्य वर्कबुक बनाएं**

[readWorkbookStream](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdata/#readWorkbookStream--) और [setExternalWorkbook](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String--) का उपयोग करके एम्बेडेड चार्ट वर्कबुक को फ़ाइल में निर्यात करें और चार्ट को उस बाह्य वर्कबुक से लिंक करें।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है, उसकी वर्कबुक को `externalWorkbook1.xlsx` में लिखता है, और फ़ाइल को चार्ट डेटा स्रोत के रूप में असाइन करने से पहले फ़ाइल लेखन पूरा करता है। यह लिंक्ड प्रस्तुति को `externalWorkbook.pptx` में सहेजता है।

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

### **बाह्य वर्कबुक सेट करें**

[setExternalWorkbook](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) मेथड का उपयोग करके आप एक बाह्य वर्कबुक को चार्ट के डेटा स्रोत के रूप में असाइन कर सकते हैं। यह मेथड बाह्य वर्कबुक के पथ को अपडेट करने के लिए भी इस्तेमाल किया जा सकता है (यदि वह स्थानांतरित हो गया हो)।

हालाँकि आप दूरस्थ स्थानों या संसाधनों में संग्रहीत वर्कबुक के डेटा को संपादित नहीं कर सकते, आप फिर भी ऐसे वर्कबुक को बाह्य डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाह्य वर्कबुक के लिए सापेक्ष पथ प्रदान किया जाता है, तो इसे स्वतः पूर्ण पथ में परिवर्तित कर दिया जाता है।

इस उदाहरण को कार्य निर्देशिका में `externalWorkbook.xlsx` की आवश्यकता है। इसकी वर्कशीट `Sheet1` में B1 में एक सीरीज़ नाम, A2:A4 में श्रेणी नाम, और B2:B4 में संख्यात्मक मान होने चाहिए। उदाहरण एक पाई चार्ट बनाता है, वर्कबुक को लिंक करता है, और [setRange](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) का उपयोग करके A1:B4 को एक सीरीज़ और तीन श्रेणियों में मैप करता है। यह परिणाम `Presentation_with_externalWorkbook.pptx` में सहेजता है।

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

[setExternalWorkbook](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) का `updateChartData` पैरामीटर नियंत्रित करता है कि वर्कबुक लोड हो या नहीं।

* जब `updateChartData` `false` हो, तो केवल वर्कबुक पथ अपडेट होता है। चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं होता, इसलिए वर्कबुक उपलब्ध नहीं भी हो सकता है।
* जब `updateChartData` `true` हो, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट होता है।

निम्न उदाहरण एक प्लेसहोल्डर URL असाइन करता है जिसमें `updateChartData` `false` पर सेट है। यह पाई चार्ट का डिफ़ॉल्ट डेटा बनाए रखता है और अनुपलब्ध वर्कबुक को लोड किए बिना प्रस्तुति को सहेजता है।

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

### **चार्ट के बाह्य डेटा स्रोत वर्कबुक पथ को प्राप्त करें**

एक चार्ट से लिंक्ड वर्कबुक की पहचान करने के लिए, पहले जांचें कि क्या चार्ट बाह्य डेटा स्रोत का उपयोग करता है। यदि हाँ, तो आप निम्न चरणों का पालन करके वर्कबुक पथ प्राप्त कर सकते हैं।

1. क्लास [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) का एक उदाहरण बनाएं।
2. शून्य-आधारित सूचकांक द्वारा पहली स्लाइड तक पहुँचें।
3. जाँचें कि पहली आकृति एक चार्ट है।
4. चार्ट डेटा स्रोत प्रकार पढ़ें।
5. यदि स्रोत एक बाह्य वर्कबुक है, तो उसका पथ पढ़ें।

यह उदाहरण `externalWorkbook.pptx` खोलता है, जो पिछले उदाहरण में बनाया गया था, और पहली स्लाइड की पहली आकृति की जांच करता है। यदि यह एक चार्ट है जो बाह्य वर्कबुक से लिंक्ड है, तो उदाहरण कंसोल पर [getExternalWorkbookPath](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) को प्रिंट करता है। फिर यह प्रस्तुति की एक कॉपी `Result.pptx` में सहेजता है।

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

आप बाह्य वर्कबुक में डेटा को उसी तरह संपादित कर सकते हैं जैसे आप आंतरिक वर्कबुक की सामग्री में बदलाव करते हैं। जब बाह्य वर्कबुक लोड नहीं हो पाती है, तो एक अपवाद फेंका जाता है।

यह उदाहरण `presentation.pptx` की आवश्यकता रखता है, जिसमें पहली स्लाइड के पहले आकार के रूप में एक चार्ट हो और एक सुलभ बाह्य वर्कबुक हो। यह पहली सीरीज़ के पहले डेटा बिंदु की कोशिका-आधारित मान को 100 सेट करता है और प्रस्तुति को `presentation_out.pptx` में सहेजता है। कोशिका मानों को संपादित करने से लिंक्ड बाह्य XLSX फ़ाइल अपडेट हो सकती है, इसलिए यदि मूल वर्कबुक को संरक्षित रखना है तो एक कॉपी उपयोग करें।

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

यदि किसी चार्ट में उपयोग की गई बाह्य वर्कबुक अनुपलब्ध या गुम है, तो Aspose.Slides प्रस्तुति में कैश किए गए डेटा से चार्ट वर्कबुक को पुनः बना सकता है। प्रस्तुति खोलने से पहले [LoadOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/) बनाएं, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) को कॉल करें, और [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) को `true` पर सेट करें।

निम्न जावा उदाहरण `presentation.pptx` खोलता है, जिसकी पहली स्लाइड की पहली आकृति में एक चार्ट होना चाहिए जो अनुपलब्ध बाह्य वर्कबुक को संदर्भित करता है, और पुनर्प्राप्त डेटा तक [IChart.getChartData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichart/#getChartData--) और [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) के माध्यम से पहुंचता है:

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

यदि बाह्य वर्कबुक उपलब्ध नहीं है और पुनर्प्राप्ति अक्षम है, तो Aspose.Slides एक अपवाद फेंकेगा। पुनर्प्राप्ति को केवल तभी सक्षम करें जब कैश्ड चार्ट डेटा का उपयोग एक स्वीकार्य बैकअप हो, क्योंकि कैश में प्रस्तुति के अंतिम अपडेट के बाद बाह्य वर्कबुक में किए गए परिवर्तन नहीं हो सकते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं यह निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाह्य या एम्बेडेड वर्कबुक से लिंक्ड है?**

हां। एक चार्ट में एक [डेटा स्रोत प्रकार](https://reference.aspose.com/slides/hi/java/com.aspose.slides/chartdata/#getDataSourceType--) और एक [बाह्य वर्कबुक का पथ](https://reference.aspose.com/slides/hi/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) होता है; यदि स्रोत एक बाह्य वर्कबुक है, तो आप पूर्ण पथ पढ़कर सुनिश्चित कर सकते हैं कि बाह्य फ़ाइल उपयोग में है।

**क्या बाह्य वर्कबुक के सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हां। यदि आप सापेक्ष पथ निर्दिष्ट करते हैं, तो इसे स्वतः पूर्ण पथ में बदल दिया जाता है। प्रस्तुति PPTX फ़ाइल में पूर्ण पथ को संग्रहित करती है, इसलिए वर्कबुक को स्थानांतरित करने पर लिंक को अपडेट करना आवश्यक हो सकता है।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**

हां, ऐसे वर्कबुक को बाह्य डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से सीधे रिमोट वर्कबुक को संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में उपयोग किए जा सकते हैं।

**क्या Aspose.Slides प्रस्तुति सहेजने पर बाह्य XLSX को ओवरराइट करता है?**

प्रस्तुति [बाह्य फ़ाइल के लिंक](https://reference.aspose.com/slides/hi/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) को संग्रहीत करती है। कोशिका-आधारित चार्ट डेटा को संपादित करने से लिंक्ड स्थानीय XLSX फ़ाइल भी अपडेट हो सकती है। यदि मूल वर्कबुक को अपरिवर्तित रखना है, तो वर्कबुक की कॉपी उपयोग करें।

**यदि बाह्य फ़ाइल पासवर्ड-रक्षित है तो मुझे क्या करना चाहिए?**

Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। एक सामान्य तरीका यह है कि पहले से सुरक्षा हटाई जाए या एक डिक्रिप्टेड कॉपी तैयार की जाए (उदाहरण के लिए, [Aspose.Cells](https://reference.aspose.com/cells/java/) का उपयोग करके) और उस कॉपी को लिंक किया जाए।

**क्या कई चार्ट एक ही बाह्य वर्कबुक को संदर्भित कर सकते हैं?**

हां। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर संकेत करते हैं, तो उस फ़ाइल को अपडेट करने से अगली बार डेटा लोड होने पर प्रत्येक चार्ट में वह परिवर्तन प्रतिबिंबित होगा।