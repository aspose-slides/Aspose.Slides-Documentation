---
title: एंड्रॉयड पर प्रस्तुतियों में चार्ट वर्कबुक का प्रबंधन
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
description: "Aspose.Slides for Android via Java को खोजें: PowerPoint और OpenDocument प्रारूपों में चार्ट वर्कबुक को आसानी से प्रबंधित करें ताकि आपके प्रस्तुति डेटा को सुव्यवस्थित किया जा सके।"
---
## **समग्र रूपरेखा**

यह लेख Aspose.Slides में चार्ट वर्कबुक के साथ काम करने के तरीके को समझाता है। यह दर्शाता है कि कैसे वर्कबुक स्ट्रीम के माध्यम से चार्ट डेटा को पढ़ा और लिखा जाता है, वर्कबुक सेल्स को चार्ट डेटा लेबल के रूप में उपयोग किया जाता है, वर्कशीट संग्रहों तक पहुँच प्राप्त की जाती है, और चार्ट मानों के लिए डेटा स्रोत प्रकार निर्दिष्ट किया जाता है।

यह बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में काम करने को भी कवर करता है। उदाहरण दिखाते हैं कि कैसे एक बाहरी वर्कबुक बनाया और नियत किया जाता है, एक चार्ट से जुड़ी बाहरी वर्कबुक का पथ प्राप्त किया जाता है, और वर्कबुक उपलब्ध होने पर चार्ट डेटा को संपादित किया जाता है।

वो वर्कबुक सेल्स जो अनुपलब्ध डेटा दर्शाते हैं, उनके बारे में जानने के लिए देखें [खाली सेल्स का प्रदर्शन नियंत्रित करें](/slides/hi/androidjava/chart-series/) जहाँ एक खाली सेल और शून्य के बीच अंतर और उपलब्ध डिस्प्ले मोड के साथ एक लाइन‑चार्ट तुलना दी गई है।

## **छिपी पंक्तियों और स्तम्भों से डेटा शामिल करें**

छिपी वर्कशीट पंक्तियों और स्तम्भों से डेटा प्लॉट किया जाए या नहीं, इसे नियंत्रित करने के लिए उपयोग करें [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-)। इसे `true` पर सेट करने से केवल दृश्यमान सेल्स प्लॉट होते हैं, या `false` पर सेट करने से दृश्यमान और छिपे दोनों सेल्स शामिल होते हैं। यह सेटिंग केवल चार्ट प्लॉटिंग को नियंत्रित करती है; यह वर्कशीट पंक्तियों या स्तम्भों को छिपाती या प्रदर्शित नहीं करती।

[उदाहरण प्रस्तुति](hidden-source-data.pptx) में पहली स्लाइड पर पहला आकार एक कॉलम चार्ट है। अंतर्निहित वर्कशीट, `Sheet1`, में स्रोत रेंज `A1:C4` है। पंक्ति 3 और स्तम्भ C छिपे हुए हैं, लेकिन उनके सेल्स अभी भी मान रखते हैं।

| वर्कशीट पंक्ति | A: माह | B: खुदरा | C: थोक (छिपा स्तम्भ) |
| --- | --- | --- | --- |
| 2 | जनवरी | 10 | 30 |
| 3 (छिपी पंक्ति) | फ़रवरी | 40 | 60 |
| 4 | मार्च | 20 | 50 |

स्रोत सेल्स तक पहुँचने के लिए प्रयोग करें [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) और जाँचें [IChartDataCell.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) को ताकि उनका छिपा status पता चल सके। यह मेथड छिपे status को बदले बिना रिपोर्ट करता है। इस फ़ाइल में, B2 दृश्यमान है, B3 छिपी पंक्ति से संबंधित है, और C2 छिपे स्तम्भ से संबंधित है; उदाहरण क्रमशः `false`, `true`, और `true` प्रिंट करता है।

इस उदाहरण में, प्लॉटिंग सेटिंग बदलने के बाद चार्ट डेटा को रिफ़्रेश करें: अंतर्निहित वर्कबुक को रखें [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) से और उसे पुनः लोड करें [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) से। जब सभी सेल्स शामिल हों, तो रेंज को पुनः स्थापित करने के लिए उपयोग करें [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) जिससे छिपी फ़रवरी श्रेणी भी मिल जाए। केवल फ्लैग बदलना इस सैंपल के कैश्ड चार्ट डेटा और श्रेणी लेबल को रिफ़्रेश करने के लिये अपर्याप्त है।

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

            // एम्बेडेड वर्कबुक से चार्ट डेटा रीफ्रेश करें।
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

उदाहरण दो संस्करणों की प्रस्तुति सहेजता है: एक जिसमें केवल दृश्यमान खुदरा मान (10 और 20) हैं, और दूसरा जिसमें सभी छह मान हैं। नीचे की छवियों में दो प्लॉटिंग मोड दर्शाए गए हैं। पंक्ति 3 और स्तम्भ C दोनों अंतर्निहित वर्कबुक में छिपे रहते हैं।

| केवल दृश्यमान सेल्स (`true`) | सभी सेल्स (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

एक मान वाले छिपे हुए सेल का अंतर एक खाली सेल से होता है। [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) नियंत्रित करता है कि अनुपलब्ध मान कैसे प्रदर्शित हों; यह छिपे स्रोत डेटा को शामिल या बाहर नहीं करता। अधिक जानकारी के लिये देखें [खाली सेल्स का प्रदर्शन नियंत्रित करें](/slides/hi/androidjava/chart-series/#control-the-display-of-empty-cells)।

## **एक चार्ट की डेटा रेंज प्राप्त करें**

मौजूदा प्रस्तुति में वर्कबुक डेटा को अपडेट करने से पहले, स्रोत रेंज जांचें ताकि पता चल सके कि प्रत्येक चार्ट कौन‑से वर्कशीट सेल्स का उपयोग कर रहा है। मेथड [IChartData.getRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getRange--) वर्तमान डेटा रेंज को एक वर्कशीट‑क्वालिफ़ाइड फार्मूला के रूप में लौटाता है, जैसे `Sheet1!$A$1:$D$5`। यहाँ `Sheet1` वर्कशीट का नाम है, `!` इसे सेल रेंज से अलग करता है, और `$A$1:$D$5` A1 से D5 तक के सेल्स को दर्शाता है। डॉलर चिह्न निरपेक्ष पंक्ति और स्तम्भ संदर्भ को दिखाते हैं।

यह मेथड चार्ट या उसकी वर्कबुक को बदले बिना वर्तमान रेंज पढ़ता है। यदि चार्ट डेटा स्रोत के रूप में वर्कबुक का उपयोग नहीं करता, तो यह `InvalidOperationException` उत्पन्न करता है। अधिक जानकारी के लिये देखें [ChartData API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/)।

यह उदाहरण एक प्रस्तुति खोलता है और प्रत्येक स्लाइड पर सीधे आकारों को चार्ट के लिये जाँचता है। यह प्रत्येक चार्ट का नाम और स्रोत रेंज प्रिंट करता है। यदि कोई चार्ट वर्कबुक का उपयोग नहीं करता, तो यह एक संदेश प्रदर्शित करता है और अगले चार्ट पर चला जाता है।

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

Aspose.Slides for Android via Java [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) और [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) मेथड प्रदान करता है जिससे आप चार्ट डेटा वर्कबुक (जिसमें Aspose.Cells से संपादित चार्ट डेटा हो) को पढ़ और लिख सकते हैं। **ध्यान दें** कि चार्ट डेटा को उसी प्रकार व्यवस्थित किया जाना चाहिए या स्रोत के समान संरचना होनी चाहिए।

यह उदाहरण एक प्रस्तुति का उपयोग करता है जिसमें पहली स्लाइड पर पहला आकार एक चार्ट है। यह एम्बेडेड वर्कबुक को बाइट एरे में पढ़ता है, मौजूदा श्रृंखला और श्रेणियों को साफ़ करता है, और वही वर्कबुक वापस लिखता है। परिवर्तन मेमोरी में रहते हैं; उदाहरण प्रस्तुति को सहेजता नहीं है।

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

जब आप एक संशोधित वर्कबुक को एम्बेडेड वर्कबुक के स्थान पर रखते हैं, तो चार्ट अपनी मूल श्रृंखला और श्रेणी संग्रहों को बरकरार रखता है। यह बेमेल [IChart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#validateChartLayout--) को इंडेक्स‑आउट‑ऑफ़‑रेंज त्रुटि के साथ विफल करा सकता है। अपडेटेड वर्कबुक को चार्ट में वापस लिखने से पहले मौजूदा श्रृंखला और श्रेणियों को साफ़ करें। यह उदाहरण पहली स्लाइड पर पहला आकार चार्ट है। टिप्पणी उन स्थानों को दर्शाती है जहाँ वर्कबुक संपादन होगा; चलने योग्य उदाहरण मूल वर्कबुक को वापस लिखता है और मेमोरी में लेआउट को वैध करता है।

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

संग्रहों को साफ़ करने से बेज़ा डेटा रेफ़रेंसेज़ हट जाती हैं इससे पहले कि वर्कबुक वापस लिखी जाए। अद्यतन वर्कबुक के लिये आवश्यक कोई भी श्रृंखला और श्रेणी मैपिंग पुनः बनाएं इससे पहले कि चार्ट का उपयोग करें।

## **श्रेणी लेबल्स को कैसे संग्रहीत करें चुनें**

लेबल जोड़ने से पहले खाली श्रेणी संग्रह पर [IChartCategoryCollection.setUseCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategorycollection/#setUseCells-boolean-) को कॉल करें। वर्कशीट सेल्स का उपयोग उन लेबल्स के लिये करें जो वर्कबुक डेटा से संदर्भित हों या एक पदानुक्रम बनाते हों, जैसे वर्ष द्वारा समूहित तिमाही। साधारण स्तर के लेबल्स के लिये स्ट्रिंग लिटेरल्स उपयोग करें जिनको सेल रेफ़रेंसेज़ की आवश्यकता नहीं होती। यह सेटिंग केवल श्रेणियों पर लागू होती है। दोनों चार्ट उदाहरण में संख्यात्मक श्रृंखला मानों के लिये वर्कशीट सेल्स का उपयोग किया गया है।

उदाहरण दो कॉलम चार्ट बनाता है और प्रत्येक के लिये `Q1 Q2 Q3 Q4` के साथ संग्रह मोड प्रिंट करता है। वर्कशीट‑समर्थित लेबल्स के लिये, [IChartCategory.getAsCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategory/#getAsCell--) अंतर्निहित सेल लौटाता है और [IChartDataCell.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#getValue--) उसका लेबल देता है। लिटरल लेबल्स के लिये, सीधे स्ट्रिंग पढ़ें [IChartCategory.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategory/#getValue--) से।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    for (boolean useCells : new boolean[] {true, false}) {
        int x = useCells ? 20 : 360;
        IChart chart = shapes.addChart(ChartType.ClusteredColumn, x, 20, 320, 250);
        IChartData data = chart.getChartData();
        data.getSeries().clear();
        IChartCategoryCollection categories = data.getCategories();
        categories.clear();
        categories.setUseCells(useCells);

        IChartDataWorkbook workbook = data.getChartDataWorkbook();
        IChartDataCell seriesName = workbook.getCell(0, 0, 1, "Sales");
        IChartSeries series = data.getSeries().add(seriesName, chart.getType());
        for (int row = 1; row <= 4; row++) {
            String label = "Q" + row;
            if (useCells) {
                IChartDataCell labelCell = workbook.getCell(0, row, 0, label);
                categories.add(labelCell);
            } else {
                categories.add(label);
            }

            IChartDataCell valueCell = workbook.getCell(0, row, 1, row * 10);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        System.out.print("UseCells = " + categories.getUseCells() + ":");
        for (IChartCategory category : categories) {
            Object label = categories.getUseCells() ? category.getAsCell().getValue() : category.getValue();
            System.out.print(" " + label);
        }
        System.out.println();
    }

    presentation.save("category-labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **वर्कबुक सेल्स के लिये कस्टम नंबर फ़ॉर्मेट सेट करें**

वर्कबुक में एम्बेडेड चार्ट के लिये संख्यात्मक मान कैसे दिखें, इसे नियंत्रित करने के लिये उपयोग करें [IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-)। उदाहरण के लिये, एक रिपोर्ट को परिवर्तन दर प्रतिशत में चार दशमलव स्थानों के साथ और गुणांक पाँच दशमलव स्थानों के साथ दिखाना पड़ सकता है। दोनों मानों को संख्यात्मक रखें ताकि वे गणनाओं और चार्ट प्लॉटिंग के लिये उपलब्ध रहें।

एक नंबर फ़ॉर्मेट प्रदर्शन बदलता है, संग्रहीत मान नहीं। फ़ॉर्मेट `0.0000%` `0.125` को `12.5000%` दिखाता है; यह संग्रहीत संख्या को `12.5` नहीं बनाता। समान रूप से, `0.00000` `0.1234567` को `0.12346` दिखाता है बिना संग्रहीत मान को राउंड किए। यदि कस्टम फ़ॉर्मेट एक खाली स्ट्रिंग (`""`) है, तो [getPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--) द्वारा लौटाया फ़ॉर्मेट उपयोग किया जाता है।

निम्न उदाहरण एक कॉलम चार्ट बनाता है और उसके सेल्स को [getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) के माध्यम से पहुँचता है। वर्कशीट 0 में, B2 में परिवर्तन दर और C2 में गुणांक है। दोनों सेल्स चार्ट मान प्रदान करते हैं। उदाहरण स्रोत फ़ॉर्मेट से जुड़ी मान लेबल्स को भी सक्षम करता है।

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

वर्कबुक सेल फ़ॉर्मेट्स चार्ट अक्ष या डेटा लेबल्स पर सीधे सेट किए गए फ़ॉर्मेट्स से अलग होते हैं। इस उदाहरण में प्रत्येक लेबल अपने स्रोत सेल के मान को दिखाता है क्योंकि [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) `true` पर सेट है, और स्रोत नंबर फ़ॉर्मेट का पालन करता है क्योंकि [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) `true` पर है। प्रस्तुति को सहेजने और पुनः खोलने के बाद लेबल्स `12.5000%` और `0.12346` दिखाते हैं, जैसा कि नीचे दिखाया गया है। लंबवत अक्ष अपना स्वयं का नंबर फ़ॉर्मेट उपयोग करता है, जो [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) के द्वारा `0.00` पर सेट है, तथा [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) `false` पर है।

किसी डेटा लेबल को स्वतंत्र रूप से फ़ॉर्मेट करने के लिये, उसका स्रोत‑लिंक फ़्लैग `false` सेट करें और [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) के द्वारा फ़ॉर्मेट असाइन करें। यह वर्कबुक सेल के फ़ॉर्मेट को नहीं बदलता। उदाहरण के लिये, स्वतंत्र लेबल फ़ॉर्मेट `0.00` पहला मान `0.13` दिखाएगा, जबकि B2 अभी भी `12.5000%` दिखाता रहेगा। सीधे लेबल फ़ॉर्मेटिंग के लिये देखें [Chart Data Labels](/slides/hi/androidjava/chart-data-label/#set-the-percentage-sign-with-chart-data-labels)।

नीचे की छवि सहेजी गई प्रस्तुति को पुनः खोलने के बाद रेंडर की गई है:

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **वर्कबुक सेल को चार्ट डेटा लेबल के रूप में सेट करें**

आप वर्कबुक सेल्स के टेक्स्ट को चार्ट डेटा लेबल्स के रूप में उपयोग कर सकते हैं।

यह उदाहरण एक मौजूदा प्रस्तुति की पहली स्लाइड पर एक बबल चार्ट डिफ़ॉल्ट डेटा के साथ जोड़ता है। यह वर्कशीट 0 में सेल्स A10:A12 को पहली श्रृंखला के पहले तीन लेबल्स के लिये उपयोग करता है, सेल‑आधारित लेबल्स को सक्षम करता है, और अपडेटेड प्रस्तुति सहेजता है।

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

[IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) मेथड चार्ट वर्कबुक में वर्कशीट्स तक पहुँच प्रदान करता है। यह उदाहरण एक डिफ़ॉल्ट डेटा पाई चार्ट बनाता है और प्रत्येक वर्कशीट का नाम कंसोल पर प्रिंट करता है।

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

श्रृंखला बिंदु मान सीधे संख्यात्मक लिटेरल्स के रूप में भी संग्रहीत किए जा सकते हैं। पूर्ण उदाहरण के लिये देखें [Set Series Values Using Numeric Literals](/slides/hi/androidjava/chart-series/#set-series-values-using-numeric-literals) जहाँ उन्हें सहेजा और पढ़ा गया है। बिंदु मानों का स्रोत प्रकार चार्ट के आंतरिक या बाहरी वर्कबुक कॉन्फ़िगरेशन से अलग रहता है; संख्यात्मक लिटेरल्स का उपयोग स्वयं एम्बेडेड वर्कबुक को नहीं हटाता।

यह उदाहरण एक डिफ़ॉल्ट डेटा 3D कॉलम चार्ट बनाता है और दो श्रृंखला नामों को विभिन्न डेटा स्रोतों के साथ सेट करता है। पहला नाम स्ट्रिंग लिटेरल है; दूसरा नाम वर्कशीट 0 के सेल C1 से लिया गया है। [DataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/) एनीमरेशन प्रत्येक नाम के लिये स्रोत चुनता है। उदाहरण अपडेटेड श्रृंखला नामों के साथ प्रस्तुति सहेजता है।

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

Aspose.Slides Excel बाइनरी वर्कबुक (.xlsb) फ़ॉर्मेट को समर्थन नहीं देता जिसे कुछ चार्ट में एम्बेड किया जा सकता है। आप [getEmbeddedWorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) को [IChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/) के साथ उपयोग कर सकते हैं तथा [WorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/workbooktype/) एनीमरेशन से असमर्थित फ़ॉर्मेट का पता लगा सकते हैं और उन चार्ट को स्किप कर सकते हैं। यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर आकारों को जाँचता है, गैर‑चार्ट आकारों को स्किप करता है, और प्रत्येक .xlsb एम्बेडेड वर्कबुक वाले चार्ट के लिये डायग्नोस्टिक संदेश प्रिंट करता है।

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

        // समर्थित चार्ट वर्कबुक डेटा यहाँ पढ़ें या संशोधित करें।
    }
} finally {
    presentation.dispose();
}
```

## **बाहरी वर्कबुक**

Aspose.Slides चार्ट्स के लिये डेटा स्रोत के रूप में बाहरी वर्कबुक इस्तेमाल करने का समर्थन करता है।

### **बाहरी वर्कबुक बनाएं**

[readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) और [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) का उपयोग करके एक एम्बेडेड चार्ट वर्कबुक को फ़ाइल में निर्यात करें और चार्ट को उस बाहरी वर्कबुक से लिंक करें।

यह उदाहरण डिफ़ॉल्ट डेटा पाई चार्ट बनाता है और उसकी वर्कबुक को निर्यात करता है। फ़ाइल लिखना पूरा होने के बाद बाहरी वर्कबुक को चार्ट डेटा स्रोत के रूप में नियत करता है, फिर लिंक्ड प्रस्तुति को सहेजता है।

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

### **बाहरी वर्कबुक नियत करें**

[setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) मेथड से आप किसी चार्ट को बाहरी वर्कबुक को डेटा स्रोत के रूप में असाइन कर सकते हैं। यह मेथड बाहरी वर्कबुक के पाथ को अपडेट करने के लिये भी उपयोग किया जा सकता है (यदि वह स्थानांतरित किया गया हो)।

आप दूरस्थ स्थानों या संसाधनों में संग्रहीत वर्कबुक के डेटा को संपादित नहीं कर सकते, किन्तु ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग कर सकते हैं। यदि बाहरी वर्कबुक का सापेक्ष पाथ दिया गया है, तो वह स्वतः पूर्ण पाथ में परिवर्तित हो जाता है।

यह उदाहरण एक बाहरी वर्कबुक का उपयोग करता है जहाँ `Sheet1` में B1 में श्रृंखला नाम, A2:A4 में श्रेणी नाम, और B2:B4 में संख्यात्मक मान हैं। उदाहरण पाई चार्ट बनाता है, वर्कबुक को लिंक करता है, और [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) से A1:B4 को एक श्रृंखला और तीन श्रेणियों के रूप में मैप करता है। लिंक्ड चार्ट के साथ प्रस्तुति सहेजता है।

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

[setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) का `updateChartData` पैरामीटर तय करता है कि वर्कबुक लोड हो या नहीं।

* जब `updateChartData` `false` हो, तो केवल वर्कबुक पाथ अपडेट होता है। चार्ट डेटा लक्ष्य वर्कबुक से लोड या अपडेट नहीं होता, इसलिए वर्कबुक अनुपलब्ध भी हो सकता है।
* जब `updateChartData` `true` हो, तो चार्ट डेटा लक्ष्य वर्कबुक से अपडेट होता है।

निम्न उदाहरण एक प्लेसहोल्डर URL को `updateChartData` `false` के साथ असाइन करता है। यह पाई चार्ट के डिफ़ॉल्ट डेटा को बरकरार रखता है और अनुपलब्ध वर्कबुक को लोड किए बिना प्रस्तुति सहेजता है।

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

### **एक चार्ट की बाहरी डेटा स्रोत वर्कबुक पाथ प्राप्त करें**

किसी चार्ट से जुड़ी वर्कबुक की पहचान करने के लिये, जाँचें कि क्या चार्ट बाहरी डेटा स्रोत का उपयोग करता है और उसका वर्कबुक पाथ प्राप्त करें।

यह उदाहरण एक लिंक्ड बाहरी वर्कबुक वाली प्रस्तुति की पहली स्लाइड पर पहले आकार को जाँचता है। यदि वह बाहरी वर्कबुक से जुड़ा चार्ट है, तो यह [getExternalWorkbookPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) को कंसोल पर प्रिंट करता है। फिर प्रस्तुति की एक कॉपी सहेजता है।

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

आप बाहरी वर्कबुक के डेटा को उसी तरह संपादित कर सकते हैं जैसे आंतरिक वर्कबुक के डेटा को करते हैं। जब कोई बाहरी वर्कबुक लोड नहीं की जा सकती, तो एक अपवाद उत्पन्न होता है।

यह उदाहरण पहली स्लाइड पर पहला आकार एक चार्ट है और वह एक सुलभ बाहरी वर्कबुक से जुड़ा है। यह पहली श्रृंखला के पहले डेटा बिंदु का सेल‑आधारित मान `100` पर सेट करता है और अपडेटेड प्रस्तुति सहेजता है। सेल मानों को संपादित करने से जुड़े बाहरी XLSX फ़ाइल को अपडेट किया जा सकता है, इसलिए मूल वर्कबुक को संरक्षित रखने हेतु एक कॉपी उपयोग करें।

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

यदि कोई चार्ट बाहरी वर्कबुक का उपयोग करता है जो अनुपलब्ध है, तो Aspose.Slides प्रस्तुति में कैश किए गए डेटा से चार्ट वर्कबुक को पुनः निर्मित कर सकता है। बनाएं [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/), कॉल करें [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), और सेट करें [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) को `true` पहले प्रस्तुति खोलें।

निम्न Java उदाहरण एक चार्ट के लिये वर्कबुक डेटा पुनः प्राप्त करता है जो पहली स्लाइड पर पहला आकार है और एक अनुपलब्ध बाहरी वर्कबुक का संदर्भ देता है। पुनः प्राप्त डेटा को पहुँचें [IChart.getChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getChartData--) और [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) के माध्यम से:

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

        // पुनर्प्राप्त वर्कबुक डेटा यहाँ पढ़ें या संशोधित करें।
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

यदि बाहरी वर्कबुक उपलब्ध नहीं है और पुनर्प्राप्ति अक्षम है, तो Aspose.Slides अपवाद फेंकेगा। पुनर्प्राप्ति केवल तभी सक्षम करें जब कैश्ड चार्ट डेटा को fallback के रूप में स्वीकार्य हो, क्योंकि कैश में बाहरी वर्कबुक में किए गए बाद के परिवर्तन नहीं हो सकते।

## **बार‑बार पूछे जाने वाले प्रश्न**

**क्या मैं निर्धारित कर सकता हूं कि कोई विशिष्ट चार्ट बाहरी या एम्बेडेड वर्कबुक से जुड़ा है?**

हाँ। एक चार्ट का [data source type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) और एक [path to an external workbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) होता है; यदि स्रोत बाहरी वर्कबुक है, तो आप पूर्ण पाथ पढ़कर सुनिश्चित कर सकते हैं कि बाहरी फ़ाइल उपयोग में है।

**क्या बाहरी वर्कबुक के सापेक्ष पाथ समर्थित हैं, और वे कैसे संग्रहीत होते हैं?**

हाँ। यदि आप सापेक्ष पाथ निर्दिष्ट करते हैं, तो वह स्वतः पूर्ण पाथ में बदल जाता है। प्रस्तुति PPTX फ़ाइल में पूर्ण पाथ संग्रहीत करती है, इसलिए वर्कबुक को स्थानांतरित करने पर लिंक को अपडेट करना पड़ सकता है।

**क्या मैं नेटवर्क संसाधनों/शेयर पर स्थित वर्कबुक का उपयोग कर सकता हूं?**

हाँ, ऐसे वर्कबुक को बाहरी डेटा स्रोत के रूप में उपयोग किया जा सकता है। हालांकि, Aspose.Slides से दूरस्थ वर्कबुक को सीधे संपादित करना समर्थित नहीं है—वे केवल स्रोत के रूप में प्रयोग किए जा सकते हैं।

**क्या Aspose.Slides प्रस्तुति सहेजते समय बाहरी XLSX को अधिलेखित करता है?**

प्रस्तुति एक [link to the external file](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) संग्रहीत करती है। सेल‑आधारित चार्ट डेटा को संपादित करने से लिंक्ड स्थानीय XLSX फ़ाइल भी अपडेट हो सकती है। यदि मूल फ़ाइल अपरिवर्तित रहनी चाहिए, तो वर्कबुक की एक कॉपी उपयोग करें।

**यदि बाहरी फ़ाइल पासवर्ड‑सुरक्षित है तो क्या करना चाहिए?**

Aspose.Slides लिंक करते समय पासवर्ड स्वीकार नहीं करता। सामान्य उपाय है पहले सुरक्षा हटाना या एक डिक्रिप्टेड कॉपी तैयार करना (उदा., [Aspose.Cells](https://reference.aspose.com/cells/java/) का उपयोग करके) और उस कॉपी को लिंक करना।

**क्या कई चार्ट एक ही बाहरी वर्कबुक का संदर्भ दे सकते हैं?**

हाँ। प्रत्येक चार्ट अपनी लिंक संग्रहीत करता है। यदि सभी एक ही फ़ाइल की ओर संकेत करते हैं, तो उस फ़ाइल को अपडेट करने से अगली बार डेटा लोड होने पर सभी चार्ट में परिलक्षित होगा।