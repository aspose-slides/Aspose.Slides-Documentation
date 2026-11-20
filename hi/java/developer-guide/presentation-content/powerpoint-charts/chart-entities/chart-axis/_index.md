---
title: जावा का उपयोग करके प्रस्तुतियों में चार्ट एक्सिस को अनुकूलित करें
linktitle: चार्ट एक्सिस
type: docs
url: /hi/java/chart-axis/
keywords:
- चार्ट एक्सिस
- लंबवत एक्सिस
- क्षैतिज एक्सिस
- अक्ष को अनुकूलित करें
- अक्ष को संशोधित करें
- अक्ष का प्रबंधन करें
- अक्ष गुण
- अधिकतम मान
- न्यूनतम मान
- अक्ष रेखा
- तिथि स्वरूप
- अक्ष शीर्षक
- अक्ष स्थिति
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके रिपोर्ट और विज़ुअलाइज़ेशन के लिए PowerPoint प्रस्तुतियों में चार्ट एक्सिस को कैसे अनुकूलित करें, जानें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for Java के साथ चार्ट अक्षों को कैसे अनुकूलित करें, यह समझाता है। यह गणना किए गए अक्ष मान, चार्ट पंक्तियों और स्तंभों की अदली‑बदली, अक्ष की दृश्यता, श्रेणी लेबल और टिक‑मार्क अंतराल, तिथि श्रेणियाँ और स्वरूपण, शीर्षक का घुमाव, अक्ष की स्थिती, डिस्प्ले यूनिट्स, और लघुगणकीय स्केलिंग को कवर करता है।

## **चार्ट में लंबवत अक्ष पर अधिकतम मान प्राप्त करें**

एक [प्रेजेंटेशन](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) बनाएं और डिफ़ॉल्ट डेटा के साथ एक एरिया चार्ट जोड़ें। गणना किए गए अक्ष मान पढ़ने से पहले [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) को कॉल करें ताकि चार्ट लेआउट अद्यतित हो।

[getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) और [getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) को अक्ष सीमाओं के लिए पढ़ें, तथा [getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) और [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) को टिक अंतराल के लिए पढ़ें। [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) और [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) समय‑इकाई स्केल प्रदान करते हैं, जो तिथि अक्षों के लिए प्रासंगिक हैं। उदाहरण इन मानों को स्थानीय चरों में संग्रहीत करता है और चार्ट को सहेजता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    double majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    int majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    int minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्षों के बीच डेटा का अदला‑बदली करें**

[switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) का उपयोग करके चार्ट डेटा में श्रृंखला और श्रेणियों की भूमिकाओं को बदलें। प्रत्येक पूर्व श्रेणी एक श्रृंखला बन जाती है, और प्रत्येक पूर्व श्रृंखला एक श्रेणी बन जाती है। यह डेटा के समूह बनाने के तरीके को बदलता है; यह क्षैतिज और लंबवत अक्षों का अदला‑बदला नहीं करता। उदाहरण [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) का उपयोग करके डिफ़ॉल्ट डेटा को `Sheet1!A1:D5` से बाइंड करता है, जिसमें हेडर पंक्ति और श्रेणी स्तंभ शामिल हैं, फिर पंक्तियों और स्तंभों को स्विच करता है। यह चार श्रृंखलाओं और तीन श्रेणियों के साथ एक चार्ट सहेजता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **एक अक्ष की प्लॉट क्रम को उल्टें**

[setPlotOrderReversed](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) का उपयोग करके एक श्रेणी या मान अक्ष को उल्टा करें। उदाहरण के लिए, एक क्षैतिज बार चार्ट वर्कशीट के समान क्रम में शीर्ष से नीचे तक परियोजना चरण दिखा सकता है: योजना, विकास, परीक्षण। अक्ष को उल्टने से प्लॉट दिशा बदलती है; यह वर्कबुक डेटा को क्रमबद्ध या पुनर्व्यवस्थित नहीं करता। तुलना के लिए, [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) श्रृंखलाओं और श्रेणियों की भूमिकाओं का अदला‑बदला करता है।

निम्न उदाहरण तीन चरणों और एक श्रृंखला के साथ एक क्षैतिज बार चार्ट बनाता है। यह तीन स्लाइडों के साथ एक प्रेजेंटेशन सहेजता है: सामान्य क्रम, उल्टे श्रेणियां, और उल्टे मान। प्रत्येक प्रति समान डेटा सेट का उपयोग करती है, और प्रत्येक प्रति में केवल एक अक्ष उल्टा होता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredBar);
    String[] stages = { "Planning", "Development", "Testing" };
    int[] values = { 10, 30, 20 };
    for (int i = 0; i < stages.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // स्लाइड 2: पहला श्रेणी शीर्ष पर दिखाएँ।
    ISlide categorySlide = presentation.getSlides().addClone(slide);
    IChart categoryChart = (IChart)categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // क्षैतिज मान अक्ष को नीचे रखें।
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // स्लाइड 3: केवल क्षैतिज संख्यात्मक स्केल को उल्टें।
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

अक्ष को उल्टने से लंबवत अक्ष को प्लॉट के विपरीत पक्ष पर भी ले जाया जा सकता है। [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) नियंत्रित करता है कि कॉन्फ़िगर किए जा रहे अक्ष को दूसरी अक्ष कहाँ पार करती है। स्लाइड 2 में, उल्टे श्रेणी अक्ष पर `CrossesType.Maximum` के साथ इसे कॉल करने से क्षैतिज मान अक्ष नीचे रहता है। विशिष्ट पार बिंदु के लिए, [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-) का उपयोग करें। दिशा बदलते समय पार सेटिंग्स की जाँच करें, विशेषकर यदि चार्ट में पहले से एक कस्टम पार बिंदु है। सामान्य प्लॉटिंग दिशा को पुनः स्थापित करने के लिए `setPlotOrderReversed` को `false` के साथ कॉल करें; पार सेटिंग्स अलग होती हैं।

| सामान्य क्रम (स्लाइड 1) | उल्टे श्रेणी (स्लाइड 2) | उल्टे मान (स्लाइड 3) |
| --- | --- | --- |
| ![Horizontal bar chart with normal category and value axis order](axis-order-normal.png) | ![Horizontal bar chart with categories displayed from top to bottom](axis-order-categories-reversed.png) | ![Horizontal bar chart with a reversed value axis and zero on the right](axis-order-values-reversed.png) |
| श्रेणियाँ नीचे से ऊपर तक चलती हैं; मान बाएँ से दाएँ बढ़ते हैं। | योजना, विकास और परीक्षण ऊपर से नीचे तक चलते हैं। मान और वर्कबुक पंक्ति क्रम अपरिवर्तित रहता है। | श्रेणियाँ अपना सामान्य क्रम बनाए रखती हैं; मान दाएँ से बाएँ बढ़ते हैं। श्रेणी अक्ष दाएँ शून्य पर काटता है। |

## **लाइन चार्ट के लिए लंबवत अक्ष को निष्क्रिय करें**

लंबवत अक्ष पर `false` के साथ [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) को कॉल करके इसे छुपाएँ। उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और लंबवत अक्ष छुपा कर सहेजता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **लाइन चार्ट के लिए क्षैतिज अक्ष को निष्क्रिय करें**

क्षैतिज अक्ष पर `false` के साथ [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) को कॉल करके इसे छुपाएँ। उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और क्षैतिज अक्ष छुपा कर सहेजता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **चार्ट ग्रिडलाइन दिखाएँ या छुपाएँ**

किसी अक्ष के कौन‑से ग्रिडलाइन प्रदर्शित होते हैं, यह जांचने के लिए [getShowMajorGridLines](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getShowMajorGridLines--) और [getShowMinorGridLines](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getShowMinorGridLines--) को कॉल करें। ये विधियां वर्तमान दृश्यता रिपोर्ट करती हैं। छोटे ग्रिडलाइन दिखाने के लिए, [getMinorGridLinesFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getMinorGridLinesFormat--) का उपयोग करके उसकी लाइन फ़िल को ठोस, दृश्यमान रंग में सेट करें। उन्हें छिपाने के लिए फ़िल को [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/#NoFill) पर सेट करें। प्रमुख ग्रिडलाइन के लिए लाइन फ़िल बदलने हेतु [getMajorGridLinesFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getMajorGridLinesFormat--) का उपयोग करें। फ़िल बदलने से अक्ष की दृश्यता और टिक‑मार्क नहीं बदलते।

इस क्लस्टर्ड कॉलम चार्ट के लंबवत अक्ष में शुरू में केवल प्रमुख ग्रिडलाइन दिखते हैं। उदाहरण छोटे ग्रिडलाइन को गहरे नारंगी रंग में दिखाता है, फिर उन्हें फिर से छुपाता है और प्रेजेंटेशन सहेजता है। यह प्रत्येक चरण में ग्रिडलाइन दृश्यता को प्रिंट करता है।

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 30, 660, 230);
    IAxis axis = chart.getAxes().getVerticalAxis();
    System.out.printf("Initial: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    ILineFillFormat minorFill = axis.getMinorGridLinesFormat().getLine().getFillFormat();
    minorFill.setFillType(FillType.Solid);
    minorFill.getSolidFillColor().setColor(new Color(255, 140, 0));
    System.out.printf("Enabled: minor=%b%n", axis.getShowMinorGridLines());

    minorFill.setFillType(FillType.NoFill);
    System.out.printf("Hidden: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    presentation.save("ChartGridlines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| छोटे ग्रिडलाइन सक्रिय | छोटे ग्रिडलाइन छुपाए गये |
| --- | --- |
| ![Orange minor gridlines between the major gridlines on the vertical axis](minor-gridlines-enabled.png) | ![The same column chart with only major gridlines visible](minor-gridlines-hidden.png) |

## **श्रेणी अक्ष बदलें**

[setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) का उपयोग करके तिथि या पाठ श्रेणी अक्ष चुनें। इस उदाहरण में `ExistingChart.pptx` की आवश्यकता है, जिसमें पहले स्लाइड के पहले आकार के रूप में एक चार्ट है और श्रेणी कोशिकाएं संख्यात्मक Excel तिथि मान रखती हैं। यह क्षैतिज अक्ष को तिथि अक्ष में बदलता है। [setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) को `false`, [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) को `1`, और [setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) को `TimeUnitType.Months` पर सेट करने से प्रमुख टिक एक‑महीने के अंतराल पर रखे जाते हैं।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = (IChart) slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **डेटा से श्रेणी अक्ष प्रकार निर्धारित करें**

श्रेणियों को भरने के बाद [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setCategoryAxisTypeAutomatically--) को कॉल करें, फिर चयन का निरीक्षण करने के लिए [getCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getCategoryAxisType--) को पढ़ें। यह तब उपयोगी है जब समान चार्ट को या तो पाठ लेबल या संख्यात्मक तिथि मान मिलते हैं। यह विधि कॉल पर प्रकार निर्धारित करती है; यह बाद में डेटा परिवर्तन पर पुन: मूल्यांकन करने वाला स्थायी मोड सक्षम नहीं करती। श्रेणियों को बदलने के बाद इसे फिर से कॉल करें।

निम्न उदाहरण पाठ श्रेणियों के साथ एक चार्ट बनाता है और चयनित प्रकार `CategoryAxisType.Text` होने पर `true` प्रिंट करता है। फिर यह श्रेणी कोशिका मानों को तिथियों से बदलता है और विधि को फिर से कॉल करता है, चयनित प्रकार `CategoryAxisType.Date` होने पर `true` प्रिंट करता है। तिथियां संख्यात्मक OLE Automation मानों के रूप में संग्रहीत होती हैं, जो इन तिथियों के लिए 30 दिसंबर 1899 से बीते दिनों की संख्या के रूप में गणना की जाती हैं, न कि तिथि स्ट्रिंग के रूप में। [setCustomNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) यह नियंत्रित करता है कि उन मानों को कैसे प्रदर्शित किया जाए; यह पाठ को संख्यात्मक तिथियों में परिवर्तित नहीं करता। श्रेणी कोशिकाओं पर अधिक जानकारी के लिए देखें [Chart Workbook](/slides/hi/java/chart-workbook/)।

स्वचालित निर्धारण का उपयोग तब करें जब इनपुट में ज्ञात रूप से पाठ श्रेणियां या संख्यात्मक तिथियां हों, जैसा कि इस उदाहरण में है। सामान्य संख्यात्मक लेबल, मिश्रित श्रेणियां, या खाली डेटा के लिए, इच्छित अर्थ से मेल खाने हेतु स्पष्ट रूप से [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setCategoryAxisType-int-) को कॉल करें। केवल संख्यात्मक मान यह स्थापित नहीं करते कि श्रेणियां तिथियां दर्शाती हैं।

```java
import com.aspose.slides.*;
import java.time.LocalDate;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell seriesName = workbook.getCell(0, 0, 1, "Sales");
    IChartSeries series = chart.getChartData().getSeries().add(seriesName, chart.getType());
    String[] labels = { "First", "Second", "Third" };

    for (int i = 0; i < labels.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, labels[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, (i + 1) * 10);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisTypeAutomatically();
    System.out.println(axis.getCategoryAxisType() == CategoryAxisType.Text); // true

    LocalDate baseDate = LocalDate.of(1899, 12, 30);
    LocalDate[] dates = { LocalDate.of(2026, 1, 1), LocalDate.of(2026, 1, 2), LocalDate.of(2026, 2, 1) };

    for (int i = 0; i < dates.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0);
        categoryCell.setValue((double)(dates[i].toEpochDay() - baseDate.toEpochDay()));
        categoryCell.setCustomNumberFormat("yyyy-mm-dd");
    }

    axis.setCategoryAxisTypeAutomatically();
    System.out.println(axis.getCategoryAxisType() == CategoryAxisType.Date); // true

    presentation.save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **श्रेणी अक्ष लेबल अंतराल नियंत्रित करें**

जब चार्ट में कई श्रेणियां हों, तो श्रेणी या मान अक्ष के लेबलों की संख्या घटाकर दृश्यता बढ़ाएँ, बिना श्रेणियों या डेटा पॉइंट को हटाए। [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) को `false` सेट करें, फिर इच्छित श्रेणी अंतराल को [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-) में पास करें। सामान्य क्रम में पाठ श्रेणियों के लिए गिनती पहली श्रेणी से शुरू होती है:

| अंतराल | उदाहरण में प्रदर्शित लेबल |
| --- | --- |
| `1` | श्रेणी 1, श्रेणी 2, श्रेणी 3, ... श्रेणी 24 |
| `2` | श्रेणी 1, श्रेणी 3, श्रेणी 5, ... श्रेणी 23 |
| `3` | श्रेणी 1, श्रेणी 4, श्रेणी 7, ... श्रेणी 22 |

`3` का अंतराल हर तीसरा लेबल दिखाता है, प्रदर्शित लेबलों के बीच दो लेबल छिपे रहते हैं। यह संबंधित स्तंभों को हटाता नहीं है। स्वचालित स्पेसिंग उपलब्ध स्थान के आधार पर अंतराल चुनती है; यह जरूरी नहीं कि हर लेबल दिखाए।

टिक‑मार्क के लिए अलग नियंत्रण होते हैं। [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) को `false` सेट करें और [setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) का उपयोग करके उनका अंतराल सेट करें। उदाहरण के लिए, `1` हर श्रेणी अंतराल पर एक टिक‑मार्क रखता है जबकि लेबल केवल हर तीसरी श्रेणी पर दिखते हैं। दृश्यमान शैली के साथ [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) का उपयोग करके परिणाम देखें। किसी भी स्वचालित‑स्पेसिंग सेटर को फिर से `true` करने से चार्ट को वही अंतराल फिर से चुनने की अनुमति मिलती है।

निम्न स्वनिर्भर उदाहरण 24 श्रेणियों और एक श्रृंखला बनाता है, फिर `CategoryAxisIntervals.pptx` में तीन स्लाइड सहेजता है: स्वचालित स्पेसिंग, स्वतंत्र लेबल स्पेसिंग के साथ मैनुअल टिक‑मार्क, और पुनर्स्थापित स्वचालित स्पेसिंग। दोनों कॉपी मूल चार्ट डेटा को बरकरार रखती हैं। कोई इनपुट प्रेजेंटेशन आवश्यक नहीं। क्षैतिज लेबल टेक्स्ट घनत्व में अंतर को स्पष्ट रूप से दिखाता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn);
    for (int i = 0; i < 24; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // स्लाइड 2: हर तीसरा लेबल दिखाएँ, लेकिन प्रत्येक श्रेणी के लिए एक टिक‑मार्क रखें।
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // स्लाइड 3: चार्ट को दोनों अंतराल फिर से चुनने दें।
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**स्वचालित स्पेसिंग (स्लाइड 1):** इस रेंडरिंग में हर दूसरी श्रेणी लेबल प्रदर्शित होता है और दो पंक्तियों में लपेटा जाता है। स्वचालित परिणाम चार्ट आकार, फ़ॉन्ट और रेंडरर के आधार पर बदल सकता है।

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**मैनुअल स्पेसिंग (स्लाइड 2):** हर तीसरा लेबल एक पंक्ति में दिखाया जाता है, जबकि टिक‑मार्क प्रत्येक श्रेणी अंतराल पर बने रहते हैं। सभी 24 स्तंभ, जिसमें लेबल रहित भी शामिल हैं, समान मानों के साथ दृश्यमान रहते हैं। स्लाइड 3 स्वचालित उपस्थिति को पुनर्स्थापित करता है।

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **सही अक्ष और अंतराल चुनें**

पाठ श्रेणी अक्ष के लिए इस श्रेणी‑गणना अंतराल का उपयोग करें, जैसे कॉलम, लाइन, एरिया या बार चार्ट के श्रेणी अक्ष के लिए। कॉलम चार्ट में यह क्षैतिज अक्ष होता है। क्षैतिज बार चार्ट में श्रेणी अक्ष लंबवत होता है, इसलिए इसे [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) द्वारा लौटाए गए अक्ष पर लागू करें। टिक‑मार्क अंतराल का उपयोग उन चार्टों में श्रृंखला अक्ष पर भी किया जा सकता है जिनमें वह मौजूद हो।

श्रेणी लेबल अंतराल का उपयोग मान अक्ष की संख्यात्मक स्केल सेट करने के लिये न करें। मान अक्ष पर [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) मानों के अंतर को निर्दिष्ट करता है: उदाहरण के लिये, `10` का प्रमुख इकाई 0, 10, 20 आदि पर टिक बनाता है जब अक्ष शून्य से शुरू होता है। `3` का श्रेणी लेबल अंतराल केवल श्रेणी स्थितियों की गिनती करता है, उनके डेटा मानों से निरपेक्ष। स्कैटर और बबल चार्ट मान अक्षों का उपयोग करते हैं, न कि पाठ श्रेणी अक्ष का। तिथि अक्ष के लिए, [Change a Category Axis](#change-a-category-axis) में वर्णित समय‑आधारित प्रमुख इकाई और स्केल का उपयोग करें।

## **श्रेणी अक्ष मानों के लिए तिथि प्रारूप सेट करें**

उदाहरण डिफ़ॉल्ट चार्ट डेटा को चार वार्षिक मानों से बदलता है। तिथियां OLE Automation सीरियल नंबर के रूप में पहले कार्यपत्रक (सूचकांक `0`) में संग्रहीत हैं, जो इन तिथियों के लिए 30 दिसंबर 1899 से बीते दिनों की संख्या के रूप में गणना की गई हैं। [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) को `CategoryAxisType.Date` के साथ उपयोग करें, फिर [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) को `false` सेट करें, और `yyyy` को [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) में पास करें ताकि श्रेणी लेबल चार्ट से स्वतंत्र रूप से चार-अंकीय वर्ष दिखाएँ।

```java
import com.aspose.slides.*;
import java.time.LocalDate;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    LocalDate baseDate = LocalDate.of(1899, 12, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        LocalDate date = LocalDate.of(2015 + i, 1, 1);
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, date.toEpochDay() - baseDate.toEpochDay());
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **चार्ट अक्ष शीर्षक के लिए घूर्णन कोण सेट करें**

लंबवत अक्ष पर `true` के साथ [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) को कॉल करें, शीर्षक पाठ प्रदान करें, और [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) का उपयोग करके शीर्षक को घुमाएँ। कोण डिग्री में मापा जाता है; यह उदाहरण मान‑अक्ष शीर्षक को 90 डिग्री घुमा कर एक कॉलम चार्ट सहेजता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **श्रेणी या मान अक्ष पर अक्ष की स्थिति सेट करें**

[setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) का उपयोग करके नियंत्रित करें कि मान अक्ष श्रेणी अक्ष को श्रेणियों के बीच या श्रेणी टिक‑मार्क पर पार करे। यह सेटिंग केवल श्रेणी अक्षों पर लागू होती है। उदाहरण इसे कॉलम चार्ट के क्षैतिज श्रेणी अक्ष पर `true` सेट करता है और परिणाम सहेजता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **चार्ट मान अक्ष पर डिस्प्ले यूनिट सेट करें**

[setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) का उपयोग करके मान अक्ष के लेबल को डेटा बदले बिना स्केल करें। जब [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) को `Millions` पर सेट किया जाता है, तो 60,000,000 का मान 60 दिखाया जाता है। उदाहरण एक कॉलम चार्ट बनाता है और उसके लंबवत अक्ष पर मिलियन डिस्प्ले यूनिट लागू करता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **लघुगणकीय मान अक्ष कॉन्फ़िगर करें**

लघुगणकीय मान अक्ष तब उपयोगी होता है जब धनात्मक मान कई आदेशों में फैले हों। उदाहरण के लिये, एक सेवा पाँच अवधियों में 10, 100, 1,000, 10,000 और 100,000 अनुरोध प्राप्त कर सकती है। रैखिक स्केल पर छोटे मान शून्य के निकट साथ‑साथ दिखाई देते हैं। लघुगणकीय स्केल उनके सापेक्ष वृद्धि की तुलना को आसान बनाता है: समान दूरी समान अनुपात दर्शाती है, न कि समान अंतर।

मान अक्ष पर `true` के साथ [setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-) को कॉल करें और बेस चुनने के लिये [setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-) का उपयोग करें। यह मौजूदा मानों के प्रदर्शित होने के तरीके को बदलता है; यह डेटा नहीं बदलता या लघुगणकीय ट्रेंड लाइन नहीं जोड़ता। ट्रेंड लाइन डेटा में फ़िटेड संबंध का प्रतिनिधित्व करती है और एक अलग सुविधा है।

### **मान अक्ष और बेस चुनें**

लाइन या कॉलम चार्ट के लिये, मान अक्ष [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) द्वारा लौटाया जाता है। क्षैतिज बार चार्ट के लिये, यह [getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--) द्वारा लौटाया जाता है। स्कैटर और बबल चार्ट में दो मान अक्ष होते हैं, इसलिए X मानों के लिये क्षैतिज अक्ष, Y मानों के लिये लंबवत अक्ष, या दोनों चुनें। श्रेणी अक्ष पर लघुगणकीय स्केलिंग लागू न करें।

डिफ़ॉल्ट लघुगणकीय बेस `10` है। PPTX चार्ट के लिये, `2` से `1000` (समावेशी) तक का बेस उपयोग करें; भिन्नात्मक बेस जैसे `2.5` भी समर्थित हैं। बेस `10` के साथ क्रमिक घात जैसे 10, 100, 1,000 और 10,000 समान अंतर पर होते हैं।

### **रैखिक और लघुगणकीय स्केल की तुलना**

निम्न स्वनिर्भर उदाहरण पहले स्लाइड पर पाँच अनुरोध संख्याओं के साथ एक लाइन चार्ट बनाता है, फिर उस स्लाइड को क्लोन कर दूसरे में बेस‑10 लघुगणकीय मान अक्ष सक्षम करता है। दोनों स्लाइड समान डेटा बरकरार रखती हैं।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    double[] values = { 10, 100, 1000, 10000, 100000 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // पहली स्लाइड को रैखिक रखें और केवल कॉपी के मान-अक्ष स्केल को बदलें।
    ISlide logarithmicSlide = presentation.getSlides().addClone(slide);
    IChart logarithmicChart = (IChart)logarithmicSlide.getShapes().get_Item(0);
    IAxis valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**रैखिक स्केल (स्लाइड 1):** समान ऊर्ध्वाधर दूरी अनुरोध संख्याओं में समान अंतर दर्शाती है। सबसे बड़ा मान चार्ट को हावी कर देता है, जिससे छोटे मानों को अलग करना कठिन हो जाता है।

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**लघुगणकीय स्केल (स्लाइड 2):** समान ऊर्ध्वाधर दूरी समान अनुपात दर्शाती है। प्रत्येक अवधि में पिछले की तुलना में दस गुना अधिक अनुरोध होते हैं, इसलिए बिंदु बेस‑10 स्केल पर एक सीधी उन्नत रेखा बनाते हैं। अक्ष लेबल अभी भी मूल अनुरोध संख्याएं दिखाते हैं।

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **शून्य और नकारात्मक मानों को संभालें**

लघुगणकीय स्केल केवल पूरी तरह सकारात्मक मानों को दिखा सकता है। इसे सक्षम करने से पहले डेटा जाँचें। यदि शून्य या नकारात्मक मान अर्थपूर्ण हैं, तो रैखिक स्केल रखें या उन्हें अलग दिखाएँ। यदि विश्लेषण के लिये उन मानों को बाहर करना उचित है, तो अपवाद की व्याख्या करें। उन्हें चुपचाप छोटे सकारात्मक संख्याओं से बदलना डेटा का अर्थ बदल देता है, इसलिए न करें। लघुगणकीय अक्ष के लिये मैन्युअल रूप से सेट किया गया न्यूनतम या अधिकतम भी सकारात्मक होना चाहिए।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं किसी अक्ष को दूसरे अक्ष के साथ जहाँ कटता है, उस मान को कैसे सेट करूँ (अक्ष कटाव)?**

[setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) का उपयोग करके कटाव व्यवहार चुनें। संख्यात्मक कटाव मान निर्दिष्ट करने के लिये, [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-) का उपयोग करें। ये सेटिंग्स आपको अक्ष कटाव को उचित बेसलाइन तक ले जाने की सुविधा देती हैं।

**मैं टिक‑लेबल को अक्ष के सापेक्ष कैसे स्थित करूँ?**

[setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) को [TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/) के साथ उपयोग करें: `Low`, `High`, `NextTo`, या `None`। टिक‑मार्क स्वयं को नियंत्रित करने के लिये, [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) या [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-) का उपयोग करें; ये लेबल स्थितियों से अलग होते हैं।