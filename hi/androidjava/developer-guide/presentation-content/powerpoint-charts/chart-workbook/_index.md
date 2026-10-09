---
title: एंड्रॉइड पर प्रस्तुतियों में चार्ट वर्कबुक को प्रबंधित करें
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
- वर्कबुक पुनरुद्धार
- PowerPoint
- प्रस्तुति
- एंड्रॉइड
- जावा
- Aspose.Slides
description: "एंड्रॉइड पर जावा के माध्यम से Aspose.Slides की खोज करें: PowerPoint और OpenDocument प्रारूपों में चार्ट वर्कबुक को आसानी से प्रबंधित करके अपनी प्रस्तुति डेटा को सुव्यवस्थित करें।"
---
## **Overview**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने के तरीके को समझाता है। यह दिखाता है कि वर्कबुक स्ट्रीम के माध्यम से चार्ट डेटा को कैसे पढ़ें और लिखें, चार्ट डेटा लेबल के रूप में वर्कबुक सेल्स का उपयोग कैसे करें, वर्कशीट संग्रह तक कैसे पहुंचें, और चार्ट मानों के लिए डेटा स्रोत प्रकार को कैसे निर्दिष्ट करें।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में उपयोग करने के बारे में भी बताता है। उदाहरण दिखाते हैं कि कैसे एक बाहरी वर्कबुक बनाएं और असाइन करें, चार्ट से जुड़ी बाहरी वर्कबुक का पथ प्राप्त करें, और जब वर्कबुक उपलब्ध हो तो चार्ट डेटा को संपादित करें।

गुम डेटा का प्रतिनिधित्व करने वाले वर्कबुक सेल्स के लिए, खाली सेल और शून्य के बीच अंतर के लिए [Control the Display of Empty Cells](/slides/hi/androidjava/chart-series/) देखें, और उपलब्ध डिस्प्ले मोड की तुलना के लिए लाइन-चार्ट देखें।

## **Include Data from Hidden Rows and Columns**

छिपी हुई वर्कशीट पंक्तियों और स्तंभों से डेटा प्लॉट किया जाए या नहीं, इसे नियंत्रित करने के लिए [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) का उपयोग करें। इसे `true` पर सेट करने से केवल दृश्यमान सेल्स प्लॉट होती हैं, या `false` पर सेट करने से दृश्यमान और छिपी दोनों सेल्स शामिल होती हैं। यह सेटिंग केवल चार्ट प्लॉटिंग को नियंत्रित करती है; यह वर्कशीट पंक्तियों या स्तंभों को छिपाती या दिखाती नहीं है।

[sample presentation](hidden-source-data.pptx) में पहली स्लाइड के पहले आकार के रूप में एक कॉलम चार्ट है। एम्बेडेड वर्कशीट, `Sheet1`, में निम्न स्रोत रेंज `A1:C4` है। पंक्ति 3 और स्तंभ C छिपे हुए हैं, लेकिन उनके सेल में अभी भी मान हैं।

| Worksheet row | A: Month | B: Retail | C: Wholesale (hidden column) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (hidden row) | February | 40 | 60 |
| 4 | March | 20 | 50 |

स्रोत सेल्स तक पहुँचने के लिए [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) का उपयोग करें और उनके छिपे होने की स्थिति को जांचने के लिए [IChartDataCell.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) पढ़ें। यह विधि छिपी स्थिति को बदले बिना रिपोर्ट करती है। इस फ़ाइल में, B2 दृश्यमान है, B3 छिपी पंक्ति से संबंधित है, और C2 छिपे स्तंभ से संबंधित है; उदाहरण क्रमशः `false`, `true`, और `true` प्रिंट करता है।

इस उदाहरण के लिए, प्लॉटिंग सेटिंग बदलने के बाद चार्ट डेटा को रिफ्रेश करें: एम्बेडेड वर्कबुक को [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) के साथ रखें और उसे [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) के साथ पुनः लोड करें। सभी सेल्स को शामिल करने के लिए, छिपी फ़रवरी श्रेणी को भी पुनर्स्थापित करने हेतु [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) का उपयोग करें। केवल फ़्लैग बदलना इस नमूने के कैश्ड चार्ट डेटा और श्रेणी लेबल को रिफ्रेश करने के लिए अपर्याप्त है।

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

उदाहरण दो प्रस्तुति संस्करणों को सहेजता है: एक जिसमें केवल दृश्यमान Retail मान (10 और 20) हैं, और दूसरा जिसमें सभी छः मान हैं। नीचे की छवियों में दो प्लॉटिंग मोड दिखाए गए हैं। पंक्ति 3 और स्तंभ C दोनों एम्बेडेड वर्कबुक में छिपे रहते हैं।

| Only visible cells (`true`) | All cells (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

एक मान वाले छिपे हुए सेल का मान खाली सेल से अलग होता है। [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) नियंत्रित करता है कि गुम मान कैसे दिखाए जाएँ; यह छिपे स्रोत डेटा को शामिल या बहिष्कृत नहीं करता। उदाहरण के लिए देखें [Control the Display of Empty Cells](/slides/hi/androidjava/chart-series/#control-the-display-of-empty-cells)।

## **Retrieve a Chart's Data Range**

किसी मौजूदा प्रस्तुति में वर्कबुक डेटा को अपडेट करने से पहले, स्रोत रेंज की जाँच करें कि प्रत्येक चार्ट कौन सी वर्कशीट सेल्स का उपयोग करता है। [IChartData.getRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getRange--) विधि वर्तमान डेटा रेंज को एक वर्कशीट-योग्य फ़ॉर्मूला के रूप में लौटाती है, जैसे `Sheet1!$A$1:$D$5`। यहाँ `Sheet1` वर्कशीट का नाम है, `!` इसे सेल रेंज से अलग करता है, और `$A$1:$D$5` सेल A1 से D5 तक को दर्शाता है। डॉलर चिह्न निरपेक्ष पंक्ति और स्तंभ संदर्भ दर्शाते हैं।

यह विधि चार्ट या उसके वर्कबुक को बदले बिना वर्तमान रेंज को पढ़ती है। यदि चार्ट डेटा स्रोत के रूप में वर्कबुक का उपयोग नहीं करता, तो यह `InvalidOperationException` फेंकेगा। अधिक जानकारी के लिए देखें [ChartData API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/)।

यह उदाहरण एक प्रस्तुति खोलता है और प्रत्येक स्लाइड पर सीधे आकारों को चार्ट के लिए जांचता है। यह प्रत्येक चार्ट का नाम और स्रोत रेंज प्रिंट करता है। यदि किसी चार्ट में वर्कबुक उपयोग नहीं किया गया है, तो यह एक संदेश प्रिंट करता है और अगले चार्ट पर जारी रहता है।

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

## **Read and Write Chart Data from a Workbook**

Aspose.Slides for Android via Java [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) और [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) विधियाँ प्रदान करता है जो आपको चार्ट डेटा वर्कबुक (जो Aspose.Cells के साथ संपादित किए गए डेटा रखते हैं) को पढ़ने और लिखने की अनुमति देती हैं। **Note** कि चार्ट डेटा को उसी प्रकार व्यवस्थित किया जाना चाहिए या स्रोत के समान संरचना होनी चाहिए।

यह उदाहरण एक प्रस्तुति का उपयोग करता है जिसमें पहली स्लाइड के पहले आकार के रूप में एक चार्ट है। यह एम्बेडेड वर्कबुक को बाइट एरे में पढ़ता है, मौजूदा श्रृंखला और श्रेणियों को साफ़ करता है, और वही वर्कबुक वापस लिखता है। परिवर्तन मेमोरी में रहते हैं; उदाहरण प्रस्तुति को सहेजता नहीं है।

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

### **Validate Chart Layout After Workbook Modification**

जब आप एम्बेडेड वर्कबुक को संशोधित संस्करण से बदलते हैं, तो चार्ट अपनी मूल श्रृंखला और श्रेणी संग्रह को बरकरार रखता है। यह असंगति [IChart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#validateChartLayout--) को एक इंडेक्स-आउट-ऑफ़-रेंज त्रुटि के साथ विफल कर सकती है। अपडेटेड वर्कबुक को चार्ट में लिखने से पहले मौजूदा श्रृंखला और श्रेणियों को साफ़ करें। यह उदाहरण पहली स्लाइड पर पहले आकार के रूप में एक चार्ट का उपयोग करता है। टिप्पणी दर्शाती है कि जहाँ वर्कबुक संपादन होगा; चलाने योग्य उदाहरण मूल वर्कबुक को वापस लिखता है और मेमोरी में लेआउट को मान्य करता है।

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

संग्रहों को साफ़ करने से पुराने डेटा संदर्भ हट जाते हैं इससे पहले कि वर्कबुक वापस लिखी जाए। अपडेटेड वर्कबुक के लिए किसी भी आवश्यक श्रृंखला और श्रेणी मैपिंग को पुनः बनाएँ इससे पहले कि चार्ट का उपयोग करें।

## **Set a Workbook Cell as a Chart Data Label**

आप वर्कबुक सेल्स से टेक्स्ट को चार्ट डेटा लेबल के रूप में उपयोग कर सकते हैं।

यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर एक बबल चार्ट को डिफ़ॉल्ट डेटा के साथ जोड़ता है। यह वर्कशीट 0 में सेल्स A10:A12 का उपयोग पहले serie के पहले तीन लेबल के लिए करता है, सेल्स से लेबल सक्षम करता है, और अपडेटेड प्रस्तुति को सहेजता है।

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

## **Manage Worksheets**

[IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) विधि चार्ट वर्कबुक में वर्कशीट्स तक पहुँच प्रदान करती है। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और प्रत्येक वर्कशीट का नाम कंसोल में प्रिंट करता है।

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

## **Specify the Data Source Type**

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक 3D कॉलम चार्ट बनाता है और दो श्रृंखला नाम विभिन्न डेटा स्रोतों का उपयोग करके सेट करता है। पहला नाम स्ट्रिंग लिटरल से लिया गया है; दूसरा नाम वर्कशीट 0 में सेल C1 से लिया गया है। [DataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/) एनेमुरेशन प्रत्येक नाम के स्रोत को चुनता है। उदाहरण अपडेटेड श्रृंखला नामों के साथ प्रस्तुति को सहेजता है।

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

## **Detect Unsupported Embedded Workbook Formats**

Aspose.Slides कुछ चार्ट में एम्बेडेड Excel बाइनरी वर्कबुक (.xlsb) स्वरूप का समर्थन नहीं करता। आप [IChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/) के साथ [getEmbeddedWorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) विधि को [WorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/workbooktype/) एनेमुरेशन के साथ उपयोग करके असमर्थित स्वरूपों का पता लगा सकते हैं और उन चार्ट को छोड़ सकते हैं। यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर आकारों को जांचता है, गैर-चार्ट आकारों को छोड़ता है, और एम्बेडेड .xlsb वर्कबुक वाले प्रत्येक चार्ट के लिए एक निदान संदेश प्रिंट करता है।

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

## **External Workbook**

Aspose.Slides चार्ट के लिए डेटा स्रोत के रूप में बाहरी वर्कबुक के उपयोग का समर्थन करता है।

### **Create an External Workbook**

एक एम्बेडेड चार्ट वर्कबुक को फ़ाइल में निर्यात करने और चार्ट को उस बाहरी वर्कबुक से लिंक करने के लिए [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) और [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) का उपयोग करें।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक पाई चार्ट बनाता है और उसकी वर्कबुक को निर्यात करता है। यह फ़ाइल लिखने को पूरा करता है, फिर बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में असाइन करता है, और लिंक्ड प्रस्तुति को सहेजता है।

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

### **Set an External Workbook**

[setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) विधि का उपयोग करके आप एक बाहरी वर्कबुक को चार्ट के डेटा स्रोत के रूप में असाइन कर सकते हैं। यह विधि बाहरी वर्कबुक के पथ को अपडेट करने के लिए भी उपयोग की जा सकती है (यदि वह स्थानांतरित हो गया हो)।

जबकि आप रिमोट स्थानों या संसाधनों में संग्रहीत वर्कबुक के डेटा को संपादित नहीं कर सकते, आप फिर भी ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी वर्कबुक के लिए रिलेटिव पथ प्रदान किया जाता है, तो इसे स्वचालित रूप से पूर्ण पथ में परिवर्तित किया जाता है।

यह उदाहरण एक बाहरी वर्कबुक का उपयोग करता है जिसकी वर्कशीट `Sheet1` में B1 में श्रृंखला नाम, A2:A4 में श्रेणी नाम, और B2:B4 में संख्यात्मक मान हैं। उदाहरण एक पाई चार्ट बनाता है, वर्कबुक को लिंक करता है, और [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) का उपयोग करके A1:B4 को एक श्रृंखला और तीन श्रेणियों से मैप करता है। यह लिंक्ड चार्ट के साथ प्रस्तुति को सहेजता है।

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

[setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) के `updateChartData` पैरामीटर यह नियंत्रित करता है कि वर्कबुक लोड की जाए या नहीं।

* जब `updateChartData` `false` हो, तो केवल वर्कबुक पथ अपडेट होता है। चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं किया जाता, इसलिए वर्कबुक अनुपलब्ध हो सकती है।
* जब `updateChartData` `true` हो, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट होता है।

निम्न उदाहरण एक प्लेसहोल्डर URL को `updateChartData` `false` के साथ असाइन करता है। यह पाई चार्ट के डिफ़ॉल्ट डेटा को बरकरार रखता है और अनुपलब्ध वर्कबुक को लोड किए बिना प्रस्तुति को सहेजता है।

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

### **Get the External Data Source Workbook Path of a Chart**

किसी चार्ट से जुड़ी वर्कबुक की पहचान करने के लिए, जाँचें कि क्या चार्ट एक बाहरी डेटा स्रोत का उपयोग कर रहा है और उसके वर्कबुक पथ को प्राप्त करें।

यह उदाहरण प्रस्तुति की पहली स्लाइड पर पहले आकार को जांचता है जिसमें लिंक्ड बाहरी वर्कबुक है। यदि यह बाहरी वर्कबुक से जुड़ा चार्ट है, तो यह कंसोल में [getExternalWorkbookPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) को प्रिंट करता है। फिर यह प्रस्तुति की एक प्रति सहेजता है।

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

### **Edit Chart Data**

आप बाहरी वर्कबुक में डेटा को उसी तरह संपादित कर सकते हैं जैसे आप आंतरिक वर्कबुक की सामग्री को बदलते हैं। जब कोई बाहरी वर्कबुक लोड नहीं की जा सकती, तो एक अपवाद फेंका जाता है।

यह उदाहरण पहले आकार के रूप में पहली स्लाइड पर एक चार्ट का उपयोग करता है जो एक पहुंच योग्य बाहरी वर्कबुक से लिंक्ड है। यह पहली श्रृंखला के पहले डेटा पॉइंट का सेल‑बैक्ड मान 100 सेट करता है और अपडेटेड प्रस्तुति को सहेजता है। सेल मानों को संपादित करने से लिंक्ड बाहरी XLSX फ़ाइल अपडेट हो सकती है, इसलिए यदि आपको मूल वर्कबुक को संरक्षित रखना है तो एक कॉपी का उपयोग करें।

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

### **Recover a Workbook from the Chart Cache**

यदि कोई चार्ट ऐसी बाहरी वर्कबुक का उपयोग करता है जो अनुपलब्ध या मौजूद नहीं है, तो Aspose.Slides प्रस्तुति में कैश्ड डेटा से चार्ट वर्कबुक को पुनः बनाता है। [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) बनाएँ, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) को कॉल करें, और [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) को `true` सेट करें प्रस्तुति खोलने से पहले।

निम्न Java उदाहरण एक ऐसी चार्ट के लिए वर्कबुक डेटा को पुनः प्राप्त करता है जो पहली स्लाइड पर पहला आकार है और एक अनुपलब्ध बाहरी वर्कबुक का संदर्भ देता है। यह पुनः प्राप्त डेटा को [IChart.getChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getChartData--) और [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) के माध्यम से एक्सेस करता है:

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

यदि बाहरी वर्कबुक अनुपलब्ध है और पुनर्प्राप्ति अक्षम है, तो Aspose.Slides एक अपवाद फेंकेगा। केवल तभी पुनर्प्राप्ति सक्षम करें जब कैश्ड चार्ट डेटा का उपयोग एक स्वीकार्य बैकअप हो, क्योंकि कैश में बाहरी वर्कबुक में अंतिम प्रस्तुति अपडेट के बाद किए गए परिवर्तन नहीं हो सकते।

## **FAQ**

**क्या मैं निर्धारित कर सकता हूँ कि कोई विशिष्ट चार्ट बाहरी या एम्बेडेड वर्कबुक से लिंक्ड है?**

हां। एक चार्ट का [data source type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) और एक [path to an external workbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) होता है; यदि स्रोत एक बाहरी वर्कबुक है, तो आप पूर्ण पथ पढ़कर सुनिश्चित कर सकते हैं कि कोई बाहरी फ़ाइल उपयोग हो रही है।

**क्या बाहरी वर्कबुक के रिलेटिव पाथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हां। यदि आप एक रिलेटिव पाथ निर्दिष्ट करते हैं, तो यह स्वचालित रूप से एक एब्सोल्यूट पाथ में परिवर्तित हो जाता है। प्रस्तुति एब्सोल्यूट पाथ को PPTX फ़ाइल में संग्रहीत करती है, इसलिए वर्कबुक को स्थानांतरित करने पर लिंक को अपडेट करना पड़ सकता है।

**क्या मैं नेटवर्क संसाधनों/शेयरों पर स्थित वर्कबुक का उपयोग कर सकता हूँ?**

हां, ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से रिमोट वर्कबुक को सीधे संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में प्रयोग किए जा सकते हैं।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को ओवरराइट करता है?**

प्रस्तुति में एक [link to the external file](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) संग्रहीत होता है। सेल‑बैक्ड चार्ट डेटा को संपादित करने से लिंक्ड स्थानीय XLSX फ़ाइल भी अपडेट हो सकती है। यदि मूल फ़ाइल अपरिवर्तित रहनी चाहिए, तो वर्कबुक की एक कॉपी का उपयोग करें।

**यदि बाहरी फ़ाइल पासवर्ड‑प्रोटेक्टेड है तो मुझे क्या करना चाहिए?**

Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। एक सामान्य उपाय है कि पहले संरक्षण हटाया जाए या एक डिक्रिप्टेड कॉपी तैयार की जाए (उदाहरण के लिए, [Aspose.Cells](https://reference.aspose.com/cells/java/) का उपयोग करके) और उस कॉपी को लिंक किया जाए।

**क्या कई चार्ट एक ही बाहरी वर्कबुक का संदर्भ दे सकते हैं?**

हां। प्रत्येक चार्ट अपना लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर संकेत करते हैं, तो उस फ़ाइल को अपडेट करने से अगली बार डेटा लोड होने पर प्रत्येक चार्ट में परिवर्तन परिलक्षित होंगे।