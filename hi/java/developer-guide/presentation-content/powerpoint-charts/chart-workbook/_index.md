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
- वर्कबुक रिकवरी
- PowerPoint
- प्रेजेंटेशन
- Java
- Aspose.Slides
description: "Aspose.Slides for Java को खोजें: PowerPoint और OpenDocument फ़ॉर्मेट में चार्ट वर्कबुक को आसानी से प्रबंधित करके अपनी प्रस्तुति डेटा को सुव्यवस्थित करें।"
---
## **समीक्षा**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ कैसे काम किया जाए, समझाता है। यह दिखाता है कि कैसे वर्कबुक स्ट्रीम के माध्यम से चार्ट डेटा को पढ़ा और लिखा जाए, वर्कबुक कोशिकाओं को चार्ट डेटा लेबल के रूप में उपयोग किया जाए, वर्कशीट संग्रहों तक पहुंचा जाए, और चार्ट मानों के लिए डेटा स्रोत प्रकार निर्धारित किया जाए।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने को भी कवर करता है। उदाहरण दिखाते हैं कि कैसे एक बाहरी वर्कबुक बनाया और असाइन किया जाए, चार्ट से जुड़ी बाहरी वर्कबुक का पथ प्राप्त किया जाए, और वर्कबुक उपलब्ध होने पर चार्ट डेटा को संपादित किया जाए।

ग़ायब डेटा का प्रतिनिधित्व करने वाली वर्कबुक कोशिकाओं के लिए, खाली कोशिकाओं के प्रदर्शन को नियंत्रित करने वाले लेख [Control the Display of Empty Cells](/slides/hi/java/chart-series/) देखें, जहाँ खाली कोशिका और शून्य के बीच अंतर, तथा उपलब्ध प्रदर्शन मोड की रेखा-चार्ट तुलना दी गई है।

## **छिपी हुई पंक्तियों और स्तंभों से डेटा शामिल करें**

[**IChart.setPlotVisibleCellsOnly**](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) का उपयोग करके यह नियंत्रित किया जाता है कि क्या चार्ट छिपी हुई वर्कशीट पंक्तियों और स्तंभों से डेटा प्लॉट करता है। इसे `true` सेट करने पर केवल दृश्यमान कोशिकाएँ प्लॉट होंगी, या `false` सेट करने पर दृश्यमान और छिपी हुई दोनों कोशिकाएँ शामिल होंगी। यह सेटिंग चार्ट प्लॉटिंग को नियंत्रित करती है; यह वर्कशीट पंक्तियों या स्तंभों को छिपाती या प्रदर्शित नहीं करती।

[sample presentation](hidden-source-data.pptx) में पहली स्लाइड पर पहला आकार एक कॉलम चार्ट है। एंबेडेड वर्कशीट, `Sheet1`, में निम्नलिखित स्रोत रेंज `A1:C4` है। पंक्ति 3 और स्तम्भ C छिपे हुए हैं, लेकिन उनकी कोशिकाओं में अभी भी मान हैं।

| वर्कशीट पंक्ति | A: माह | B: रिटेल | C: थोक (छुपा हुआ स्तम्भ) |
| --- | --- | --- | --- |
| 2 | जनवरी | 10 | 30 |
| 3 (छुपी हुई पंक्ति) | फरवरी | 40 | 60 |
| 4 | मार्च | 20 | 50 |

स्रोत कोशिकाओं तक पहुँचने के लिए [**IChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) का प्रयोग करें और [**IChartDataCell.isHidden**](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#isHidden--) के माध्यम से उनकी छिपी हुई स्थिति जाँचें। यह विधि छिपी हुई स्थिति को बदले बिना रिपोर्ट करती है। इस फ़ाइल में, B2 दृश्यमान है, B3 छुपी हुई पंक्ति से संबंधित है, और C2 छुपे हुए स्तम्भ से संबंधित है; उदाहरण क्रमशः `false`, `true`, और `true` प्रिंट करता है।

इस उदाहरण के लिए, प्लॉटिंग सेटिंग बदलने के बाद चार्ट डेटा को रीफ़्रेश करें: एंबेडेड वर्कबुक को [**readWorkbookStream**](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) से रखें और उसे [**writeWorkbookStream**](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) से पुनः लोड करें। सभी कोशिकाओं को शामिल करते समय, छुपी हुई फरवरी श्रेणी को पुनर्स्थापित करने के लिए [**setRange**](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) भी उपयोग करें। केवल फ़्लैग बदलना इस नमूने के कैश किए गए चार्ट डेटा और श्रेणी लेबल को रीफ़्रेश करने के लिए अपर्याप्त है।

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
                // छुपी हुई श्रेणियों सहित पूर्ण स्रोत रेंज को पुनर्स्थापित करें।
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

उदाहरण दो संस्करणों में प्रस्तुति को सहेजता है: एक जिसमें केवल दृश्यमान रिटेल मान (10 और 20) हैं, और दूसरा जिसमें सभी छह मान हैं। नीचे दी गई छवियाँ दो प्लॉटिंग मोड को दर्शाती हैं। पंक्ति 3 और स्तम्भ C दोनों एंबेडेड वर्कबुक में छिपे रहते हैं।

| केवल दृश्यमान कोशिकाएँ (`true`) | सभी कोशिकाएँ (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

एक मान वाला छिपा हुआ सेल एक खाली सेल से अलग होता है। [**IChart.setDisplayBlanksAs**](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) नियंत्रित करता है कि ग़ायब मान कैसे प्रदर्शित हों; यह छिपे हुए स्रोत डेटा को शामिल या बाहर नहीं करता। एक उदाहरण के लिए [Control the Display of Empty Cells](/slides/hi/java/chart-series/#control-the-display-of-empty-cells) देखें।

## **चार्ट के डेटा रेंज को पुनः प्राप्त करें**

किसी मौजूदा प्रस्तुति में वर्कबुक डेटा अपडेट करने से पहले, स्रोत रेंज को जांचें ताकि यह पहचाना जा सके कि प्रत्येक चार्ट कौन सी वर्कशीट कोशिकाओं का उपयोग कर रहा है। [**IChartData.getRange**](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getRange--) विधि वर्तमान डेटा रेंज को वर्कशीट योग्य सूत्र के रूप में लौटाती है, जैसे `Sheet1!$A$1:$D$5`। यहाँ, `Sheet1` वर्कशीट का नाम है, `!` इसे सेल रेंज से अलग करता है, और `$A$1:$D$5` कोशिकाओं A1 से D5 (समेत) को दर्शाता है। डॉलर चिह्न निरपेक्ष पंक्ति और स्तम्भ संदर्भों को दर्शाते हैं।

यह विधि चार्ट या उसकी वर्कबुक को बदले बिना वर्तमान रेंज पढ़ती है। यदि चार्ट डेटा स्रोत के रूप में वर्कबुक नहीं उपयोग करता, तो यह `InvalidOperationException` थ्रो करता है। अधिक जानकारी के लिए [ChartData API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/) देखें।

यह उदाहरण एक प्रस्तुति खोलता है और प्रत्येक स्लाइड पर सीधे आकारों की जाँच करता है कि वे चार्ट हैं या नहीं। यह प्रत्येक चार्ट का नाम और स्रोत रेंज प्रिंट करता है। यदि कोई चार्ट वर्कबुक का उपयोग नहीं करता, तो यह एक संदेश प्रिंट करता है और अगले चार्ट पर जारी रहता है।

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

## **एक वर्कबुक से चार्ट डेटा पढ़ें और लिखें**

Aspose.Slides for Java [**readWorkbookStream**](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) और [**writeWorkbookStream**](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) विधियों को प्रदान करता है जो आपको चार्ट डेटा वर्कबुक (जिसमें Aspose.Cells के साथ संपादित चार्ट डेटा है) को पढ़ने और लिखने की अनुमति देती हैं। **ध्यान दें** कि चार्ट डेटा को उसी क्रम में व्यवस्थित होना चाहिए या स्रोत के समान संरचना होनी चाहिए।

यह उदाहरण पहली स्लाइड पर पहले आकार के रूप में एक चार्ट वाली प्रस्तुति का उपयोग करता है। यह एंबेडेड वर्कबुक को बाइट ऐरे में पढ़ता है, मौजूदा श्रृंखला और श्रेणियों को साफ़ करता है, और वही वर्कबुक वापस लिखता है। परिवर्तन मेमोरी में रहते हैं; उदाहरण प्रस्तुति को सहेजता नहीं है।

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

जब आप संशोधित वर्कबुक के साथ एंबेडेड वर्कबुक को बदलते हैं, तो चार्ट अपनी मूल श्रृंखला और श्रेणी संग्रह को बरकरार रखता है। यह असंगति [**IChart.validateChartLayout**](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#validateChartLayout--) को इंडेक्स‑आउट‑ऑफ़‑रेंज त्रुटि के साथ फ़ेल कर सकती है। अपडेटेड वर्कबुक को चार्ट में वापस लिखने से पहले मौजूदा श्रृंखला और श्रेणियों को साफ़ करें। यह उदाहरण पहली स्लाइड पर पहला आकार वाला चार्ट उपयोग करता है। टिप्पणी दर्शाती है कि जहाँ वर्कबुक संपादन होना चाहिए; कार्यशील उदाहरण मूल वर्कबुक को वापस लिखता है और मेमोरी में लेआउट को मान्य करता है।

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

संग्रहों को साफ़ करने से वर्कबुक लिखे जाने से पहले पुराने डेटा संदर्भ हट जाते हैं। अपडेटेड वर्कबुक के लिए आवश्यक किसी भी श्रृंखला और श्रेणी मैपिंग को पुनर्निर्मित करें।

## **एक वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करें**

आप वर्कबुक कोशिकाओं से पाठ को चार्ट डेटा लेबल के रूप में उपयोग कर सकते हैं।

यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर एक बबल चार्ट के साथ डिफ़ॉल्ट डेटा जोड़ता है। यह वर्कशीट 0 की कोशिकाएँ A10:A12 को पहले श्रृंखला के पहले तीन लेबल के रूप में उपयोग करता है, कोशिकाओं से लेबल सक्षम करता है, और अपडेटेड प्रस्तुति को सहेजता है।

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

## **वर्कशीट्स को प्रबंधित करें**

[**IChartDataWorkbook.getWorksheets**](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) विधि चार्ट वर्कबुक में वर्कशीट्स तक पहुँच प्रदान करती है। यह उदाहरण डिफ़ॉल्ट डेटा वाले एक पाई चार्ट बनाता है और प्रत्येक वर्कशीट का नाम कंसोल में प्रिंट करता है।

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

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक 3D कॉलम चार्ट बनाता है और दो श्रृंखला नाम विभिन्न डेटा स्रोतों का उपयोग करके सेट करता है। पहला नाम स्ट्रिंग लिटरल है; दूसरा वर्कशीट 0 के सेल C1 से लिया गया है। [**DataSourceType**](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/) एनीमरेशन प्रत्येक नाम के स्रोत को चुनता है। उदाहरण अद्यतन श्रृंखला नामों के साथ प्रस्तुति को सहेजता है।

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

Aspose.Slides उन Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट को समर्थन नहीं देता जो कुछ चार्ट में एंबेडेड हो सकते हैं। आप [**getEmbeddedWorkbookType**](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) विधि को [**IChartData**](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/) के साथ [**WorkbookType**](https://reference.aspose.com/slides/java/com.aspose.slides/workbooktype/) एनीमरेशन का उपयोग करके असमर्थित फ़ॉर्मेट का पता लगा सकते हैं और उन चार्ट को स्किप कर सकते हैं। यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर आकारों की जांच करता है, गैर‑चार्ट आकारों को छोड़ता है, और प्रत्येक .xlsb एंबेडेड वर्कबुक वाले चार्ट के लिए डायग्नोस्टिक संदेश प्रिंट करता है।

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

Aspose.Slides चार्ट के लिए बाहरी वर्कबुक को डेटा स्रोत के रूप में उपयोग करने का समर्थन करता है।

### **एक बाहरी वर्कबुक बनाएं**

[**readWorkbookStream**](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) और [**setExternalWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) का उपयोग करके एंबेडेड चार्ट वर्कबुक को फ़ाइल में एक्सपोर्ट करें और चार्ट को उस बाहरी वर्कबुक से लिंक करें।

यह उदाहरण डिफ़ॉल्ट डेटा वाले एक पाई चार्ट का निर्माण करता है और उसकी वर्कबुक को एक्सपोर्ट करता है। फ़ाइल लिखने के बाद बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में असाइन करता है, फिर लिंक्ड प्रस्तुति को सहेजता है।

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

### **एक बाहरी वर्कबुक सेट करें**

[**setExternalWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) विधि का उपयोग करके आप किसी चार्ट के लिए बाहरी वर्कबुक को उसके डेटा स्रोत के रूप में असाइन कर सकते हैं। यह विधि बाहरी वर्कबुक के पथ को अपडेट करने के लिए भी उपयोग की जा सकती है (यदि वह स्थानांतरित हो गया हो)।

हालाँकि आप रिमोट लोकेशन या रिसोर्स में संग्रहीत वर्कबुक डेटा को सीधे संपादित नहीं कर सकते, फिर भी आप ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी वर्कबुक का सापेक्ष पथ प्रदान किया जाता है, तो वह स्वतः पूर्ण पथ में बदल दिया जाता है।

यह उदाहरण एक बाहरी वर्कबुक का उपयोग करता है जहाँ वर्कशीट `Sheet1` में B1 में श्रृंखला नाम, A2:A4 में श्रेणी नाम, और B2:B4 में संख्यात्मक मान हैं। उदाहरण एक पाई चार्ट बनाता है, वर्कबुक को लिंक करता है, और [**setRange**](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) का उपयोग करके A1:B4 को एक श्रृंखला और तीन श्रेणियों से मैप करता है। यह लिंक्ड चार्ट के साथ प्रस्तुति को सहेजता है।

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

[**setExternalWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) का `updateChartData` पैरामीटर निर्धारित करता है कि वर्कबुक लोड की जाए या नहीं।

* जब `updateChartData` `false` हो, तो केवल वर्कबुक पथ अपडेट होता है। चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं होता, इसलिए वर्कबुक अनुपलब्ध भी हो सकता है।
* जब `updateChartData` `true` हो, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट होता है।

अगला उदाहरण एक प्लेसहोल्डर URL को `updateChartData` को `false` सेट करके असाइन करता है। यह पाई चार्ट के डिफ़ॉल्ट डेटा को बरकरार रखता है और अनुपलब्ध वर्कबुक को लोड किए बिना प्रस्तुति को सहेजता है।

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

### **चार्ट का बाहरी डेटा स्रोत वर्कबुक पथ प्राप्त करें**

किसी चार्ट से जुड़ी वर्कबुक की पहचान करने के लिए, जांचें कि क्या चार्ट बाहरी डेटा स्रोत उपयोग कर रहा है और उसका वर्कबुक पथ प्राप्त करें।

यह उदाहरण उस प्रस्तुति की पहली स्लाइड पर पहले आकार की जांच करता है जिसमें लिंक्ड बाहरी वर्कबुक है। यदि वह एक चार्ट है जो बाहरी वर्कबुक से लिंक है, तो उदाहरण कंसोल में [**getExternalWorkbookPath**](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) प्रिंट करता है। फिर यह प्रस्तुति की एक प्रति सहेजता है।

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

आप बाहरी वर्कबुक में डेटा को उसी तरह संपादित कर सकते हैं जैसे आप अंदरूनी वर्कबुक की सामग्री को बदलते हैं। जब कोई बाहरी वर्कबुक लोड नहीं की जा सकती, तो एक अपवाद फेंका जाता है।

यह उदाहरण पहली स्लाइड पर पहला आकार वाला चार्ट उपयोग करता है जो सुलभ बाहरी वर्कबुक से लिंक्ड है। यह पहले श्रृंखला के पहले डेटा पॉइंट के सेल‑बैक्ड मान को 100 पर सेट करता है और अपडेटेड प्रस्तुति को सहेजता है। सेल मानों को संपादित करने से लिंक्ड बाहरी XLSX फ़ाइल अपडेट हो सकती है, इसलिए मूल वर्कबुक को संरक्षित रखने हेतु एक कॉपी उपयोग करें।

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

यदि कोई चार्ट ऐसी बाहरी वर्कबुक उपयोग करता है जो खो गई या अनुपलब्ध है, तो Aspose.Slides प्रस्तुति में कैश किए गए डेटा से चार्ट वर्कबुक को पुनः निर्मित कर सकता है। [**LoadOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) बनाएं, [**LoadOptions.setSpreadsheetOptions**](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) को कॉल करें, और [**ISpreadsheetOptions.setRecoverWorkbookFromChartCache**](https://reference.aspose.com/slides/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) को `true` सेट करें, फिर प्रस्तुति खोलें।

निम्न Java उदाहरण प्रथम स्लाइड पर पहले आकार वाले चार्ट के लिए वर्कबुक डेटा को पुनर्प्राप्त करता है जो अनुपलब्ध बाहरी वर्कबुक का संदर्भ देता है। यह पुनर्प्राप्त डेटा को [**IChart.getChartData**](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getChartData--) और [**IChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) के माध्यम से पहुँचता है:

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

यदि बाहरी वर्कबुक अनुपलब्ध है और पुनर्प्राप्ति अक्षम है, तो Aspose.Slides अपवाद फेंकेगा। केवल तब पुनर्प्राप्ति सक्षम करें जब कैश्ड चार्ट डेटा का उपयोग एक स्वीकार्य विकल्प हो, क्योंकि कैश में बाहरी वर्कबुक में अंतिम अपडेट के बाद किए गए परिवर्तन नहीं हो सकते।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाहरी या एंबेडेड वर्कबुक से जुड़ा है?**

हाँ। एक चार्ट के पास [डेटा स्रोत प्रकार](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getDataSourceType--) और [बाहरी वर्कबुक का पथ](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) होते हैं; यदि स्रोत एक बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़कर सुनिश्चित कर सकते हैं कि बाहरी फ़ाइल उपयोग हो रही है।

**क्या बाहरी वर्कबुक के सापेक्ष पथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हाँ। यदि आप सापेक्ष पथ निर्दिष्ट करते हैं, तो वह स्वतः पूर्ण पथ में परिवर्तित हो जाता है। प्रस्तुति इस पूर्ण पथ को PPTX फ़ाइल में संग्रहीत करती है, इसलिए वर्कबुक को ले जाने पर लिंक को अपडेट करना पड़ सकता है।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**

हां, ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालाँकि, Aspose.Slides से सीधे रिमोट वर्कबुक को संपादित करना समर्थित नहीं है—उन्हें केवल स्रोत के रूप में उपयोग किया जा सकता है।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

प्रस्तुति एक [बाहरी फ़ाइल का लिंक](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) संग्रहीत करती है। सेल‑बैक्ड चार्ट डेटा को संपादित करने से लिंक्ड स्थानीय XLSX फ़ाइल भी अपडेट हो सकती है। मूल वर्कबुक को अपरिवर्तित रखने के लिए उसकी एक कॉपी उपयोग करें।

**यदि बाहरी फ़ाइल पासवर्ड‑सुरक्षित है तो क्या करें?**

Aspose.Slides लिंकिंग के समय पासवर्ड स्वीकार नहीं करता। एक सामान्य तरीका यह है कि पहले संरक्षण हटाया जाए या एक डिक्रिप्टेड कॉपी (उदाहरण के लिए, [Aspose.Cells](https://reference.aspose.com/cells/java/)) तैयार कर उस कॉपी को लिंक किया जाए।

**क्या कई चार्ट एक ही बाहरी वर्कबुक का संदर्भ दे सकते हैं?**

हाँ। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर इशारा करते हैं, तो उस फ़ाइल को अपडेट करने से अगली बार डेटा लोड होने पर सभी चार्ट प्रभावित होंगे।