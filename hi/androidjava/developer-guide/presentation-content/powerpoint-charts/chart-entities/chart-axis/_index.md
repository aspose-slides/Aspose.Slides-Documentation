---
title: Android पर प्रस्तुतियों में चार्ट अक्ष को कस्टमाइज़ करें
linktitle: चार्ट अक्ष
type: docs
url: /hi/androidjava/chart-axis/
keywords:
- चार्ट अक्ष
- ऊर्ध्वाधर अक्ष
- क्षैतिज अक्ष
- अक्ष को अनुकूलित करें
- अक्ष को संशोधित करें
- अक्ष का प्रबंधन करें
- अक्ष गुण
- अधिकतम मान
- न्यूनतम मान
- अक्ष रेखा
- तारीख स्वरूप
- अक्ष शीर्षक
- अक्ष स्थिति
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके रिपोर्ट और विज़ुअलाइज़ेशन के लिए PowerPoint प्रस्तुतियों में चार्ट अक्ष को कस्टमाइज़ करने का तरीका जानें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for Android via Java के साथ चार्ट अक्ष को अनुकूलित करने के तरीकों को समझाता है। यह गणना किए गए अक्ष मानों, चार्ट पंक्तियों और स्तंभों के बदलने, अक्ष की दृश्यता, श्रेणी लेबल और टिक‑मार्क अंतराल, तिथि श्रेणियों और स्वरूपण, शीर्षक घूर्णन, अक्ष की स्थिति, प्रदर्शन इकाइयों और लघुगणकीय स्केलिंग को शामिल करता है।

## **चार्ट में लंबवत अक्ष पर अधिकतम मान प्राप्त करें**

एक [प्रेजेंटेशन](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) बनाएं और डीफ़ॉल्ट डेटा के साथ एक एरिया चार्ट जोड़ें। गणना किए गए अक्ष मान पढ़ने से पहले [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) को कॉल करें ताकि चार्ट लेआउट अपडेटेड रहे।

अक्ष सीमाओं के लिए [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) और [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) पढ़ें, और टिक अंतराल के लिए [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) और [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) पढ़ें। [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) और [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) समय‑इकाई स्केल प्रदान करते हैं, जो तिथि अक्षों के लिए प्रासंगिक हैं। उदाहरण इन मानों को स्थानीय चर में सहेजता है और चार्ट को सहेजता है।

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

## **अक्षों के बीच डेटा बदलें**

चार्ट डेटा में श्रृंखलाओं और श्रेणियों की भूमिकाओं को बदलने के लिए [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) का उपयोग करें। प्रत्येक पूर्व श्रेणी श्रृंखला बन जाती है, और प्रत्येक पूर्व श्रृंखला श्रेणी बन जाती है। यह डेटा समूहकरण को बदलता है; यह क्षैतिज और लंबवत अक्षों का अदला‑बदला नहीं करता। उदाहरण [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) का उपयोग करके डीफ़ॉल्ट डेटा को `Sheet1!A1:D5` से बाइंड करता है, जिसमें हेडर पंक्ति और श्रेणी स्तंभ शामिल हैं, पंक्तियों और स्तंभों को बदलने से पहले। यह चार श्रृंखलाओं और तीन श्रेणियों वाले चार्ट को सहेजता है।

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

## **अक्ष की प्लॉटिंग क्रम को उल्टें**

एक श्रेणी या मान अक्ष को उल्टने के लिए [setPlotOrderReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) का उपयोग करें। उदाहरण के लिए, एक क्षैतिज बार चार्ट वर्कशीट के समान क्रम में प्रोजेक्ट चरणों को शीर्ष से नीचे दिखा सकता है: Planning, Development, Testing। अक्ष को उल्टने से प्लॉटिंग दिशा बदलती है; यह कार्यपुस्तिका डेटा को क्रमबद्ध या पुनर्व्यवस्थित नहीं करता। तुलना में, [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) श्रृंखलाओं और श्रेणियों की भूमिकाओं को बदलता है।

निम्न उदाहरण तीन चरणों और एक श्रृंखला के साथ एक क्षैतिज बार चार्ट बनाता है। यह एक प्रस्तुति को तीन स्लाइडों के साथ सहेजता है: सामान्य क्रम, उल्टी श्रेणियां, और उल्टे मान। प्रत्येक प्रति समान डेटा सेट का उपयोग करती है, और प्रत्येक प्रति पर केवल एक अक्ष उलटा होता है।

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

    // स्लाइड 2: पहले श्रेणी को शीर्ष पर प्रदर्शित करें।
    ISlide categorySlide = presentation.getSlides().addClone(slide);
    IChart categoryChart = (IChart)categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // क्षैतिज मान अक्ष को नीचे बनाए रखें।
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // स्लाइड 3: केवल क्षैतिज संख्यात्मक स्केल को उलटें।
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

अक्ष को उल्टने से लम्बवत अक्ष को प्लॉट के विपरीत पक्ष पर ले जाया जा सकता है। [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) निर्धारित करता है कि अन्य अक्ष वर्तमान में कॉन्फ़िगर किए जा रहे अक्ष को कहाँ पार करता है। स्लाइड 2 में, `CrossesType.Maximum` के साथ उल्टी श्रेणी अक्ष पर इसे कॉल करने से क्षैतिज मान अक्ष नीचे रहता है। विशिष्ट क्रॉसिंग बिंदु के लिए, [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-) का उपयोग करें। दिशा बदलते समय क्रॉसिंग सेटिंग्स जांचें, विशेष रूप से यदि चार्ट पहले से ही कस्टम क्रॉसिंग बिंदु रखता है। सामान्य प्लॉटिंग दिशा बहाल करने के लिए `setPlotOrderReversed` को `false` के साथ कॉल करें; क्रॉसिंग सेटिंग्स अलग रहती हैं।

| सामान्य क्रम (स्लाइड 1) | उल्टी श्रेणियां (स्लाइड 2) | उल्टे मान (स्लाइड 3) |
| --- | --- | --- |
| ![सामान्य श्रेणी और मान अक्ष क्रम के साथ क्षैतिज बार चार्ट](axis-order-normal.png) | ![ऊपर से नीचे प्रदर्शित श्रेणियों के साथ क्षैतिज बार चार्ट](axis-order-categories-reversed.png) | ![उल्टे मान अक्ष और दाएं शून्य के साथ क्षैतिज बार चार्ट](axis-order-values-reversed.png) |
| श्रेणियां नीचे से ऊपर चलती हैं; मान बाएँ से दाएँ बढ़ते हैं। | Planning, Development, और Testing ऊपर से नीचे चलते हैं। मान और कार्यपुस्तिका पंक्ति क्रम अपरिवर्तित हैं। | श्रेणियां अपना सामान्य क्रम बनाए रखती हैं; मान दाएँ से बाएँ बढ़ते हैं। श्रेणी अक्ष दाएँ शून्य पर क्रॉस करता है। |

## **लाइन चार्ट के लिए लंबवत अक्ष को निष्क्रिय करें**

लंबवत अक्ष को छिपाने के लिए इसे `false` के साथ [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) कॉल करें। उदाहरण एक डीफ़ॉल्ट डेटा वाले लाइन चार्ट को बनाता है और उसे लंबवत अक्ष छिपा कर सहेजता है।

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

क्षैतिज अक्ष को छिपाने के लिए इसे `false` के साथ [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) कॉल करें। उदाहरण एक डीफ़ॉल्ट डेटा वाले लाइन चार्ट को बनाता है और उसे क्षैतिज अक्ष छिपा कर सहेजता है।

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

## **चार्ट ग्रिडलाइन दिखाएँ या छिपाएँ**

किस ग्रिडलाइन को अक्ष प्रदर्शित कर रहा है, यह जांचने के लिए [getShowMajorGridLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getShowMajorGridLines--) और [getShowMinorGridLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getShowMinorGridLines--) कॉल करें। ये मेथड वर्तमान दृश्यता रिपोर्ट करते हैं। छोटे ग्रिडलाइन दिखाने के लिए, [getMinorGridLinesFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getMinorGridLinesFormat--) को कॉल करें और उसकी लाइन फिल को ठोस, दिखाई देने वाले रंग में सेट करें। उन्हें छिपाने के लिए फिल को [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/#NoFill) पर सेट करें। प्रमुख ग्रिडलाइन के लिए भी वही प्रक्रिया [getMajorGridLinesFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getMajorGridLinesFormat--) के साथ लागू होती है। फिल बदलने से अक्ष की दृश्यता और टिक‑मार्क अपरिवर्तित रहते हैं।

इस क्लस्टर्ड कॉलम चार्ट की लंबवत अक्ष प्रारम्भ में केवल प्रमुख ग्रिडलाइन दिखाती है। उदाहरण छोटे ग्रिडलाइन को गहरे नारंगी रंग में दिखाता है, फिर उन्हें फिर से छिपाकर प्रस्तुति को सहेजता है। प्रत्येक चरण पर ग्रिडलाइन दृश्यता को प्रिंट करता है।

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 30, 660, 230);
    IAxis axis = chart.getAxes().getVerticalAxis();
    System.out.printf("Initial: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    ILineFillFormat minorFill = axis.getMinorGridLinesFormat().getLine().getFillFormat();
    minorFill.setFillType(FillType.Solid);
    minorFill.getSolidFillColor().setColor(Color.rgb(255, 140, 0));
    System.out.printf("Enabled: minor=%b%n", axis.getShowMinorGridLines());

    minorFill.setFillType(FillType.NoFill);
    System.out.printf("Hidden: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    presentation.save("ChartGridlines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| छोटी ग्रिडलाइनें सक्षम | छोटी ग्रिडलाइनें छिपी |
| --- | --- |
| ![ऊर्ध्वाधर अक्ष पर प्रमुख ग्रिडलाइन के बीच नारंगी छोटी ग्रिडलाइनें](minor-gridlines-enabled.png) | ![केवल प्रमुख ग्रिडलाइनें दिखाने वाला वही स्तंभ चार्ट](minor-gridlines-hidden.png) |

## **श्रेणी अक्ष बदलें**

परिभाषित तिथि या टेक्स्ट श्रेणी अक्ष चुनने के लिए [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) का उपयोग करें। यह उदाहरण `ExistingChart.pptx` की आवश्यकता रखता है, जिसमें प्रथम स्लाइड की पहली आकृति के रूप में चार्ट है और श्रेणी कोशिकाओं में संख्यात्मक Excel तिथि मान हैं। यह क्षैतिज अक्ष को तिथि अक्ष में बदलता है। [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) को `false`, [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) को `1`, और [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) को `TimeUnitType.Months` के साथ कॉल करने से प्रमुख टिक एक‑महीने के अंतराल पर रखे जाते हैं।

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

श्रेणियों को भरने के बाद [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setCategoryAxisTypeAutomatically--) को कॉल करें, फिर चयन का निरीक्षण करने के लिए [getCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getCategoryAxisType--) पढ़ें। यह同ही चार्ट के लिए टेक्स्ट लेबल या संख्यात्मक तिथि मानों में से किसी भी एक को प्राप्त करने पर उपयोगी है। मेथड कॉल के समय प्रकार निर्धारित करता है; यह बाद में डेटा बदलावों के लिए स्थायी मोड सक्रिय नहीं करता। श्रेणियों को बदलने के बाद इसे पुनः कॉल करें।

निम्न उदाहरण टेक्स्ट श्रेणियों वाला चार्ट बनाता है और चयनित प्रकार `CategoryAxisType.Text` होने पर `true` प्रिंट करता है। फिर श्रेणी कोशिका मूल्यों को तिथियों से बदलता है और पुनः मेथड कॉल करता है, जिससे चयनित प्रकार `CategoryAxisType.Date` होने पर `true` प्रिंट होता है। तिथियां संख्यात्मक OLE Automation मानों के रूप में संग्रहीत होती हैं, जो 30 December 1899 से दिनों की संख्या के रूप में गणना की जाती हैं, न कि तिथि स्ट्रिंग के रूप में। दोनों कैलेंडर UTC का उपयोग करते हैं और तिथियां सेट करने से पहले साफ़ कर दी जाती हैं, ताकि दिवारी बचत समय और दिन के वर्तमान समय से गणना पर प्रभाव न पड़े। [setCustomNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) नियंत्रित करता है कि ये मान कैसे प्रदर्शित हों; यह टेक्स्ट को संख्यात्मक तिथियों में परिवर्तित नहीं करता। अधिक जानकारी के लिए देखें [Chart Workbook](/slides/hi/androidjava/chart-workbook/)।

इनपुट में ज्ञात है कि वह टेक्स्ट श्रेणियां या संख्यात्मक तिथियां रखता है, तो स्वचालित निर्धारण का उपयोग करें, जैसा कि इस उदाहरण में है। सामान्य संख्यात्मक लेबल, मिश्रित श्रेणियां, या खाली डेटा के लिए, स्पष्ट रूप से [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setCategoryAxisType-int-) को कॉल कर इच्छित अर्थ के अनुसार सेट करें। केवल संख्यात्मक मान यह स्थापित नहीं करते कि श्रेणियां तिथियों को दर्शाती हैं।

```java
import com.aspose.slides.*;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.TimeZone;

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
    System.out.println(axis.getCategoryAxisType() == CategoryAxisType.Text); // सही

    TimeZone timeZone = TimeZone.getTimeZone("UTC");
    Calendar baseDate = new GregorianCalendar(timeZone);
    baseDate.clear();
    baseDate.set(1899, Calendar.DECEMBER, 30);
    int[][] dates = { { 2026, Calendar.JANUARY, 1 }, { 2026, Calendar.JANUARY, 2 }, { 2026, Calendar.FEBRUARY, 1 } };

    for (int i = 0; i < dates.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0);
        Calendar date = new GregorianCalendar(timeZone);
        date.clear();
        date.set(dates[i][0], dates[i][1], dates[i][2]);
        double serialDate = (date.getTimeInMillis() - baseDate.getTimeInMillis()) / 86400000.0;
        categoryCell.setValue(serialDate);
        categoryCell.setCustomNumberFormat("yyyy-mm-dd");
    }

    axis.setCategoryAxisTypeAutomatically();
    System.out.println(axis.getCategoryAxisType() == CategoryAxisType.Date); // सही

    presentation.save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **श्रेणी अक्ष लेबल अंतराल नियंत्रित करें**

जब चार्ट में कई श्रेणियां हों, तो श्रेणियों या डेटा पॉइंट को हटाए बिना दृश्यमान अक्ष लेबलों की संख्या घटाएँ। [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) को `false` के साथ कॉल करें, फिर इच्छित श्रेणी अंतराल को [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-) को पास करें। सामान्य क्रम में टेक्स्ट श्रेणियों के लिए गिनती पहली श्रेणी से शुरू होती है:

| अंतराल | उदाहरण में प्रदर्शित लेबल |
| --- | --- |
| `1` | श्रेणी 1, श्रेणी 2, श्रेणी 3, … श्रेणी 24 |
| `2` | श्रेणी 1, श्रेणी 3, श्रेणी 5, … श्रेणी 23 |
| `3` | श्रेणी 1, श्रेणी 4, श्रेणी 7, … श्रेणी 22 |

`3` का अंतराल प्रत्येक तीसरे लेबल को दिखाता है, प्रदर्शित लेबलों के बीच दो लेबल छिपा रहता है। यह संबंधित स्तंभों को नहीं हटाता। स्वचालित अंतराल उपलब्ध स्थान के आधार पर अंतराल चुनता है; यह अनिवार्य रूप से प्रत्येक लेबल नहीं दिखाता।

टिक‑मार्क के लिए अलग नियंत्रण होते हैं। [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) को `false` सेट करें और [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) द्वारा उनका अंतराल निर्धारित करें। उदाहरण के लिए, `1` हर श्रेणी अंतराल पर टिक‑मार्क रखता है जबकि लेबल केवल प्रत्येक तीसरी श्रेणी पर दिखते हैं। दृश्यमान शैली के साथ [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) का उपयोग करें ताकि आप परिणाम देख सकें। किसी भी स्वचालित‑स्पेसिंग सेटर को फिर से `true` करने से चार्ट स्वयं वह अंतराल चुन लेता है।

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

    // स्लाइड 2: प्रत्येक तिहाई लेबल दिखाएँ, लेकिन प्रत्येक श्रेणी के लिए टिक‑मार्क रखें।
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // स्लाइड 3: चार्ट को फिर से दोनों अंतराल चुनने दें।
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**स्वचालित अंतराल (स्लाइड 1):** इस रेंडरिंग में प्रत्येक दूसरी श्रेणी लेबल दिखाया जाता है और दो पंक्तियों में रैप होता है। स्वचालित परिणाम चार्ट के आकार, फ़ॉन्ट और रेंडरर पर निर्भर कर सकता है।

![सभी 24 स्तंभों को दिखाते हुए स्वचालित श्रेणी लेबल अंतराल](category-axis-automatic.png)

**मैनुअल अंतराल (स्लाइड 2):** प्रत्येक तीसरे लेबल को एक पंक्ति में दिखाया जाता है, जबकि टिक‑मार्क प्रत्येक श्रेणी अंतराल पर बना रहता है। सभी 24 स्तंभ, लेबल के बिना वाले भी, समान मानों के साथ दृश्यमान रहते हैं। स्लाइड 3 उपरोक्त स्वचालित दिखावट को पुनर्स्थापित करता है।

![सभी 24 स्तंभों को दिखाते हुए तीन का मैनुअल श्रेणी लेबल अंतराल](category-axis-manual.png)

### **सही अक्ष और अंतराल चुनें**

यह श्रेणी‑गणना अंतराल टेक्स्ट श्रेणी अक्ष के लिए उपयोग करें, जैसे कॉलम, लाइन, एरिया या बार चार्ट का श्रेणी अक्ष। कॉलम चार्ट में यह क्षैतिज अक्ष होता है। क्षैतिज बार चार्ट में श्रेणी अक्ष लंबवत होता है, इसलिए इसे [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) द्वारा लौटाए गए अक्ष पर लागू करें। टिक‑मार्क स्पेसिंग का उपयोग उन चार्टों में श्रृंखला अक्ष पर भी किया जा सकता है जिनमें ऐसा अक्ष मौजूद हो।

मान अक्ष के संख्यात्मक स्केल को सेट करने के लिए श्रेणी लेबल अंतराल का प्रयोग न करें। मान अक्ष पर, [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) मानों के अंतर को निर्दिष्ट करता है: उदाहरण के लिये `10` का प्रमुख यूनिट 0, 10, 20 आदि पर टिक रखता है जब अक्ष शून्य से शुरू होता है। `3` का श्रेणी लेबल अंतराल केवल श्रेणी स्थितियों की गिनती करता है, उनके डेटा मानों से असंबंधित। स्कैटर और बबल चार्ट पाठ श्रेणी अक्ष की बजाय मान अक्ष का उपयोग करते हैं। तिथि अक्ष के लिए, [Change a Category Axis](#change-a-category-axis) में वर्णित समय‑आधारित प्रमुख इकाइयों और स्केल का उपयोग करें।

## **श्रेणी अक्ष मानों के लिए तिथि स्वरूप सेट करें**

यह उदाहरण डिफ़ॉल्ट चार्ट डेटा को चार वार्षिक मानों से बदलता है। तिथियां पहली कार्यपत्रिका (सूचकांक `0`) में OLE Automation क्रमांक के रूप में संग्रहीत होती हैं, जो 30 December 1899 से दिनों की संख्या के रूप में गणना की गई हैं। दोनों कैलेंडर UTC का उपयोग करते हैं और तिथियां सेट करने से पहले साफ़ कर दी जाती हैं, ताकि दिवारी बचत समय और दिन के वर्तमान समय से गणना पर प्रभाव न पड़े। [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) को `CategoryAxisType.Date` के साथ कॉल करें, फिर [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) को `false` सेट करें, और [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) को `yyyy` पास करें ताकि श्रेणी लेबल चार्ट सेल स्वरूप से स्वतंत्र रूप से चार-अंक वाले वर्षों को दिखाएँ।

```java
import com.aspose.slides.*;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.TimeZone;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    TimeZone timeZone = TimeZone.getTimeZone("UTC");
    Calendar baseDate = new GregorianCalendar(timeZone);
    baseDate.clear();
    baseDate.set(1899, Calendar.DECEMBER, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        Calendar date = new GregorianCalendar(timeZone);
        date.clear();
        date.set(2015 + i, Calendar.JANUARY, 1);
        double serialDate = (date.getTimeInMillis() - baseDate.getTimeInMillis()) / 86400000.0;
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, serialDate);
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

ऊर्ध्वाधर अक्ष पर शीर्षक को सक्षम करने के लिए इसे `true` के साथ [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) कॉल करें, शीर्षक पाठ प्रदान करें, और शीर्षक को घुमाने के लिए [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) का उपयोग करें। कोण डिग्री में मापा जाता है; यह उदाहरण मान‑अक्ष शीर्षक को 90 डिग्री घुमाकर एक कॉलम चार्ट सहेजता है।

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

## **श्रेणी या मान अक्ष पर अक्ष स्थिति सेट करें**

[setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) का उपयोग करके नियंत्रित करें कि मान अक्ष श्रेणी अक्ष के बीच या श्रेणी टिक‑मार्क पर क्रॉस करे। यह सेटिंग केवल श्रेणी अक्षों पर लागू होती है। उदाहरण इसे कॉलम चार्ट के क्षैतिज श्रेणी अक्ष पर `true` सेट करता है और परिणाम सहेजता है।

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

## **चार्ट मान अक्ष पर प्रदर्शन इकाई सेट करें**

[setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) का उपयोग करके मान अक्ष पर लेबल को स्केल करें बिना मूल डेटा बदले। जब [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) को `Millions` पर सेट किया जाता है, तो 60 000 000 मान को 60 के रूप में दिखाया जाता है। उदाहरण एक कॉलम चार्ट बनाता है और उसके ऊर्ध्वाधर अक्ष पर मिलियन प्रदर्शन इकाई लागू करता है।

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

लघुगणकीय मान अक्ष उपयोगी होता है जब सकारात्मक मान कई क्रम magnitude में फैले हों। उदाहरण के लिये, एक सेवा पाँच अवधियों में 10, 100, 1 000, 10 000 और 100 000 अनुरोध प्राप्त कर सकती है। रैखिक स्केल पर छोटे मान शून्य के निकट बहुत करीब दिखते हैं। लघुगणकीय स्केल इनके सापेक्ष वृद्धि को आसान तुलना प्रदान करता है: समान दूरी समान अनुपात दर्शाती है, न कि समान अंतर।

मान अक्ष को `true` के साथ [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-) कॉल करें और आधार चुनने के लिए [setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) का उपयोग करें। यह मौजूदा मानों के प्रदर्शित तरीके को बदलता है; यह डेटा नहीं बदलता और न ही लघुगणकीय ट्रेंडलाइन जोड़ता है। ट्रेंडलाइन डेटा में फिटेड संबंध दर्शाती है और अलग विशेषता है।

### **मान अक्ष और आधार चुनें**

लाइन या कॉलम चार्ट के लिए, मान अक्ष को [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) द्वारा प्राप्त किया जाता है। क्षैतिज बार चार्ट के लिए, इसे [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--) द्वारा प्राप्त किया जाता है। स्कैटर और बबल चार्ट में दो मान अक्ष होते हैं, इसलिए X मानों के लिए क्षैतिज अक्ष, Y मानों के लिए ऊर्ध्वाधर अक्ष या दोनों चुनें। श्रेणी अक्ष पर लघुगणकीय स्केलिंग लागू न करें।

डिफ़ॉल्ट लघुगणकीय आधार `10` है। PPTX चार्ट के लिए, `2` से `1000` तक (समावेशी) कोई भी आधार उपयोग किया जा सकता है; अंशात्मक आधार जैसे `2.5` भी समर्थित हैं। आधार `10` पर क्रमशः 10, 100, 1 000, 10 000 जैसी समान अंतरालीय शक्ति समान दूरी पर होती हैं।

### **रेखीय और लघुगणकीय स्केलिंग की तुलना करें**

निम्न उदाहरण एक लाइन चार्ट बनाता है जिसमें पाँच अनुरोध गिनती पहली स्लाइड पर रखी गई हैं, फिर उसी स्लाइड को कॉपी करके दूसरी स्लाइड पर आधार‑10 लघुगणकीय मान अक्ष को सक्षम करता है। दोनों स्लाइड एक ही डेटा रखती हैं।

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

**रेखीय स्केल (स्लाइड 1):** समान लंबवत दूरी अनुरोध गिनती में समान अंतर को दर्शाती है। सबसे बड़ा मान चार्ट को हावी कर देता है, जिससे छोटे मानों को अलग करना कठिन हो जाता है।

![रेखीय मान अक्ष पर पाँच अनुरोध गिनती दिखाने वाला PowerPoint में लाइन चार्ट](value-axis-linear.png)

**लघुगणकीय स्केल (स्लाइड 2):** समान लंबवत दूरी समान अनुपात को दर्शाती है। प्रत्येक अवधि में पिछले की तुलना में दस गुना अधिक अनुरोध होते हैं, इसलिए बिंदु आधार‑10 स्केल पर एक सीधी ऊपर की ओर रेखा बनाते हैं। अक्ष लेबल अभी भी मूल अनुरोध गिनती दिखाते हैं।

![PowerPoint में बेस‑10 लघुगणकीय मान अक्ष पर वही पाँच अनुरोध गिनती](value-axis-logarithmic.png)

### **शून्य और नकारात्मक मानों को संभालें**

लघुगणकीय स्केल केवल शुद्ध सकारात्मक मान प्रदर्शित कर सकता है। इसे सक्षम करने से पहले डेटा जांचें। यदि शून्य या नकारात्मक मान अर्थपूर्ण हैं, तो रैखिक स्केल रखें या उन्हें अलग से दिखाएँ। यदि विश्लेषण के लिए उन मानों को बाहर करना उचित है, तो विसर्जन का कारण बताएँ। उन्हें छोटे सकारात्मक संख्याओं से चुपचाप बदलना डेटा के अर्थ को बदल देता है; ऐसा न करें। लघुगणकीय अक्ष के लिए कोई भी मैन्युअल न्यूनतम या अधिकतम मान भी सकारात्मक होना चाहिए।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं एक अक्ष दूसरे अक्ष को कहाँ क्रॉस करता है, इसका मान कैसे सेट करूँ?**

क्रॉसिंग व्यवहार चुनने के लिए [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) का उपयोग करें। संख्यात्मक क्रॉसिंग मान निर्दिष्ट करने के लिए [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-) का प्रयोग करें। ये सेटिंग्स आपको अक्ष क्रॉसिंग को उचित बेसलाइन पर ले जाने देती हैं।

**मैं टिक लेबल्स को अक्ष के सापेक्ष कैसे स्थित करूँ?**

[setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) को [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/) के साथ उपयोग करें: `Low`, `High`, `NextTo` या `None`। टिक‑मार्क स्वयं को नियंत्रित करने के लिए, [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) या [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-) का उपयोग करें; ये लेबल स्थिति से अलग हैं।