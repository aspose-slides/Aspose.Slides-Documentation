---
title: Android पर प्रस्तुतियों में चार्ट अक्षों को अनुकूलित करें
linktitle: चार्ट अक्ष
type: docs
url: /hi/androidjava/chart-axis/
keywords:
- चार्ट अक्ष
- लंबवत अक्ष
- क्षैतिज अक्ष
- अक्ष को अनुकूलित करें
- अक्ष को हेरफेर करें
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
- Android
- Java
- Aspose.Slides
description: "जाने कैसे Aspose.Slides for Android को Java के माध्यम से उपयोग करके रिपोर्ट और विज़ुअलाइज़ेशन के लिए PowerPoint प्रस्तुतियों में चार्ट अक्षों को अनुकूलित किया जा सकता है।"
---
## **सारांश**

यह लेख बताता है कि Aspose.Slides for Android via Java का उपयोग करके चार्ट के अक्षों को कैसे अनुकूलित किया जाए। यह गणना किए गए अक्ष मान, चार्ट की पंक्तियों और स्तम्भों को बदलना, अक्ष की दृश्यता, श्रेणी लेबल और टिक‑मार्क अंतराल, तिथि श्रेणियाँ और फ़ॉर्मेटिंग, शीर्षक घुमाव, अक्ष का स्थान, डिस्प्ले यूनिट और लघुगणकीय स्केलिंग को कवर करता है।

## **चार्ट में लंबवत अक्ष पर अधिकतम मान प्राप्त करें**

एक [प्रस्तुति](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) बनाएँ और डिफ़ॉल्ट डेटा के साथ एक एरिया चार्ट जोड़ें। गणना किए गए अक्ष मान पढ़ने से पहले चार्ट लेआउट को अपडेट रखने के लिए [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) को कॉल करें।

अक्ष सीमाओं के लिए [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) और [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) पढ़ें, और टिक अंतराल के लिए [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) और [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) पढ़ें। [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) और [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) समय‑इकाई स्केल प्रदान करते हैं, जो तिथि अक्षों के लिए प्रासंगिक है। उदाहरण इन मानों को स्थानीय चरों में संग्रहीत करता है और चार्ट को सहेजता है।

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

चार्ट डेटा में श्रृंखला और श्रेणियों की भूमिकाओं को बदलने के लिए [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) का उपयोग करें। प्रत्येक पूर्व श्रेणी एक श्रृंखला बन जाती है, और प्रत्येक पूर्व श्रृंखला एक श्रेणी बन जाती है। यह डेटा के समूह बनाने के तरीके को बदलता है; यह क्षैतिज और लंबवत अक्षों को नहीं बदलता। उदाहरण डिफ़ॉल्ट डेटा को `Sheet1!A1:D5` (हेडर पंक्ति और श्रेणी स्तम्भ सहित) से बाइंड करने के लिए [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) का उपयोग करता है, फिर पंक्तियों और स्तम्भों को बदलता है। यह चार्ट में चार श्रृंखला और तीन श्रेणियाँ सहेजता है।

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

## **लाइन चार्ट के लिए लंबवत अक्ष को अक्षम करें**

लंबवत अक्ष को छिपाने के लिए `false` के साथ [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) को कॉल करें। उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और उसे लंबवत अक्ष छिपा कर सहेजता है।

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

## **लाइन चार्ट के लिए क्षैतिज अक्ष को अक्षम करें**

क्षैतिज अक्ष को छिपाने के लिए `false` के साथ [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) को कॉल करें। उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और उसे क्षैतिज अक्ष छिपा कर सहेजता है।

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

## **श्रेणी अक्ष बदलें**

तिथि या टेक्स्ट श्रेणी अक्ष चुनने के लिए [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) का उपयोग करें। यह उदाहरण `ExistingChart.pptx` की आवश्यकता रखता है, जिसमें पहला स्लाइड पहला आकार चार्ट है और श्रेणी कोशिकाएँ संख्या‑आधारित Excel तिथि मान रखती हैं। यह क्षैतिज अक्ष को तिथि अक्ष में बदलता है। [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) को `false`, [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) को `1` और [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) को `TimeUnitType.Months` सेट करने से प्रमुख टिक एक‑माह अंतराल पर रखे जाते हैं।

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

## **श्रेणी अक्ष लेबल अंतराल नियंत्रित करें**

जब चार्ट में कई श्रेणियाँ हों, तो श्रेणियों या डेटा बिंदुओं को हटाए बिना दृश्यमान अक्ष लेबलों की संख्या घटाएँ। `[setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-)` को `false` के साथ कॉल करें, फिर वांछित श्रेणी अंतराल को `[setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-)` को पास करें। सामान्य क्रम में टेक्स्ट श्रेणियों के लिए, गिनती पहली श्रेणी से शुरू होती है:

| अंतराल | उदाहरण में प्रदर्शित लेबल |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

`3` का अंतराल प्रत्येक तीसरे लेबल को प्रदर्शित करता है, जिससे दो लेबल छुपे रहते हैं। यह संबंधित स्तम्भों को नहीं हटाता। स्वचालित स्पेसिंग उपलब्ध स्थान के आधार पर अंतराल चुनती है; यह आवश्यक नहीं कि सभी लेबल दिखाएँ।

टिक‑मार्क के लिए अलग नियंत्रण होते हैं। `[setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-)` को `false` करें और `[setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-)` का उपयोग करके उनका अंतराल सेट करें। उदाहरण के लिए, `1` प्रत्येक श्रेणी अंतराल पर टिक‑मार्क रखता है जबकि लेबल केवल प्रत्येक तीसरी श्रेणी पर दिखते हैं। `[setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-)` को एक दृश्यमान शैली के साथ सेट करें ताकि परिणाम स्पष्ट हो। स्वचालित‑स्पेसिंग सेट्टर को फिर से `true` करने से चार्ट फिर से वही अंतराल चुन लेगा।

निम्न स्व-समाहित उदाहरण 24 श्रेणियों और एक श्रृंखला बनाता है, फिर `CategoryAxisIntervals.pptx` में तीन स्लाइड सहेजता है: स्वचालित स्पेसिंग, स्वतंत्र टिक‑मार्क के साथ मैन्युअल लेबल स्पेसिंग, और पुर्नस्थापित स्वचालित स्पेसिंग। दो प्रतियाँ मूल चार्ट डेटा को बरकरार रखती हैं। कोई इनपुट प्रस्तुति आवश्यक नहीं है। क्षैतिज लेबल टेक्स्ट घनत्व के अंतर को स्पष्ट रूप से दिखाता है।

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

    // स्लाइड 2: प्रत्येक तीसरे लेबल को दिखाएँ, लेकिन प्रत्येक श्रेणी के लिये एक टिक‑मार्क रखें।
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

**स्वाचालित स्पेसिंग (स्लाइड 1):** इस रेंडरिंग में प्रत्येक दूसरी श्रेणी लेबल प्रदर्शित होता है और दो पंक्तियों में लिपटा है। स्वचालित परिणाम चार्ट आकार, फ़ॉन्ट और रेंडरर के आधार पर बदल सकता है।

![सभी 24 स्तम्भ दृश्यमान के साथ स्वाचालित श्रेणी लेबल स्पेसिंग](category-axis-automatic.png)

**मैन्युअल स्पेसिंग (स्लाइड 2):** प्रत्येक तीसरा लेबल एक पंक्ति में दिखाई देता है, जबकि टिक‑मार्क प्रत्येक श्रेणी अंतराल पर रहते हैं। सभी 24 स्तम्भ, जिनमें लेबल नहीं भी हैं, वही मानों के साथ दृश्यमान रहते हैं। स्लाइड 3 स्वाचालित दिखावट को पुनर्स्थापित करता है।

![सभी 24 स्तम्भ दृश्यमान के साथ तीन के मैन्युअल श्रेणी लेबल अंतराल](category-axis-manual.png)

### **सही अक्ष और अंतराल चुनें**

टेक्स्ट श्रेणी अक्ष के लिए इस श्रेणी‑गणना अंतराल का उपयोग करें, जैसे स्तम्भ, रेखा, एरिया या बार चार्ट का श्रेणी अक्ष। स्तम्भ चार्ट में यह क्षैतिज अक्ष होता है। क्षैतिज बार चार्ट में श्रेणी अक्ष लंबवत होता है, इसलिए इसे `[getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--)` द्वारा लौटाए गए अक्ष पर लागू करें। टिक‑मार्क अंतराल उन चार्ट्स में श्रृंखला अक्ष पर भी लागू होता है जिनमें वह मौजूद हो।

संख्या‑अक्ष पर संख्यात्मक स्केल सेट करने के लिए श्रेणी लेबल स्पेसिंग का उपयोग न करें। मान अक्ष पर, `[setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-)` मानों के अंतर को निर्धारित करता है: उदाहरण के लिये, `10` का प्रमुख इकाई 0, 10, 20 आदि पर टिक बनाता है जब अक्ष शून्य से शुरू होता है। `3` का श्रेणी लेबल अंतराल केवल श्रेणी स्थितियों को गिनता है, डेटा मानों की परवाह किए बिना। स्कैटर और बबल चार्ट मान अक्षों का उपयोग करते हैं, न कि टेक्स्ट श्रेणी अक्ष का। तिथि अक्ष के लिये, `[Change a Category Axis](#change-a-category-axis)` में वर्णित समय‑आधारित प्रमुख इकाइयाँ और स्केल उपयोग करें।

## **श्रेणी अक्ष मानों के लिए तिथि फ़ॉर्मेट सेट करें**

यह उदाहरण डिफ़ॉल्ट चार्ट डेटा को चार वार्षिक मानों से बदलता है। तिथियों को पहले कार्यपत्र (सूचकांक `0`) में OLE Automation क्रमिक संख्याओं के रूप में संग्रहीत किया जाता है, जो 30 दिसंबर 1899 से दिनों की संख्या है। दोनों कैलेंडर UTC में होते हैं और तिथियों को सेट करने से पहले साफ़ किए जाते हैं ताकि डे लाइट सेविंग और वर्तमान समय की गणना प्रभावित न हो। `[setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-)` को `CategoryAxisType.Date` के साथ, `[setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-)` को `false` और `[setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-)` को `yyyy` सेट करें ताकि श्रेणी लेबल चार अंकों का वर्ष स्वतंत्र रूप से दिखाएँ, चाहे कोशिका फ़ॉर्मेट कुछ भी हो।

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

## **चार्ट अक्ष शीर्षक के लिये घूर्णन कोण सेट करें**

लंबवत अक्ष पर `[setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-)` को `true` के साथ कॉल करें, शीर्षक पाठ प्रदान करें, और `[setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-)` का उपयोग करके शीर्षक घुमाएँ। कोण डिग्री में मापा जाता है; यह उदाहरण एक स्तम्भ चार्ट को 90 डिग्री घुमाए हुए मान‑अक्ष शीर्षक के साथ सहेजता है।

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

`[setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-)` का उपयोग करके निर्धारित करें कि मान अक्ष श्रेणी अक्ष को श्रेणियों के बीच या श्रेणी टिक‑मार्क पर पार करे। यह सेटिंग केवल श्रेणी अक्षों पर लागू होती है। उदाहरण इसे स्तम्भ चार्ट के क्षैतिज श्रेणी अक्ष पर `true` सेट करता है और परिणाम सहेजता है।

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

`[setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-)` का उपयोग करके मान अक्ष पर लेबलों को स्केल करें बिना मूल डेटा बदले। जब `[DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/)` को `Millions` सेट किया जाता है, तो 60,000,000 को 60 के रूप में दिखाया जाता है। यह उदाहरण एक स्तम्भ चार्ट बनाता है और उसके लंबवत अक्ष पर मिलियन डिस्प्ले यूनिट लागू करता है।

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

## **लघुगणकीय मान अक्ष को कॉन्फ़िगर करें**

लघुगणकीय मान अक्ष तब उपयोगी होता है जब सकारात्मक मान कई क्रमों में फैलते हों। उदाहरण के लिये, एक सेवा पाँच अवधियों में 10, 100, 1,000, 10,000 और 100,000 अनुरोध प्राप्त कर सकती है। रैखिक स्केल पर छोटे मान शून्य के निकट एक‑दूसरे के बहुत पास दिखते हैं। लघुगणकीय स्केल उनके सापेक्ष वृद्धि को तुलना करना आसान बनाता है: समान दूरी समान अनुपात दर्शाती है, न कि समान अंतर।

मान अक्ष पर `[setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-)` को `true` और बेस चुनने के लिये `[setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-)` का उपयोग करें। यह मौजूदा मानों के प्रदर्शित होने के तरीके को बदलता है; यह डेटा नहीं बदलता और न ही लघुगणकीय ट्रेंड‑लाइन जोड़ता है। ट्रेंड‑लाइन डेटा में फिटेड संबंध का प्रतिनिधित्व करती है और एक अलग सुविधा है।

### **मान अक्ष और बेस चुनें**

लाइन या स्तम्भ चार्ट के लिये, मान अक्ष `[getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--)` द्वारा लौटाया जाता है। क्षैतिज बार चार्ट पर यह `[getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--)` द्वारा मिलता है। स्कैटर और बबल चार्ट में दो मान अक्ष होते हैं, इसलिए X मानों के लिये क्षैतिज अक्ष, Y मानों के लिये लंबवत अक्ष या दोनों का चयन करें। श्रेणी अक्ष पर लघुगणकीय स्केलिंग लागू न करें।

डिफ़ॉल्ट लघुगणकीय बेस `10` है। PPTX चार्ट्स के लिये बेस `2` से `1000` तक (समावेशी) प्रयोग किया जा सकता है; अंशात्मक बेस जैसे `2.5` भी समर्थित हैं। बेस `10` पर क्रमागत घातांक 10, 100, 1,000, 10,000 समान रूप से स्थित होते हैं।

### **रैखिक और लघुगणकीय स्केल की तुलना**

निम्न स्व‑समाहित उदाहरण पहले स्लाइड पर पाँच अनुरोध गणनाओं के साथ एक लाइन चार्ट बनाता है, फिर उस स्लाइड को क्लोन करके दूसरे स्लाइड पर बेस‑10 लघुगणकीय मान अक्ष सक्षम करता है। दोनों स्लाइड समान डेटा को बरकरार रखती हैं।

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

    // पहली स्लाइड को रैखिक रखें और केवल कॉपी के मान‑अक्ष स्केल को बदलें।
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

**रैखिक स्केल (स्लाइड 1):** समान लंबवत दूरी समान अनुरोध गणनाओं के अंतर को दर्शाती है। सबसे बड़ा मान चार्ट को प्रमुख बनाता है, जिससे छोटे मानों को अलग‑अलग देखना कठिन हो जाता है।

![पावरपॉइंट में पाँच अनुरोध गणनाओं के साथ रैखिक मान अक्ष पर लाइन चार्ट](value-axis-linear.png)

**लघुगणकीय स्केल (स्लाइड 2):** समान लंबवत दूरी समान अनुपात को दर्शाती है। प्रत्येक अवधि में पिछले की तुलना में दस गुना अधिक अनुरोध होते हैं, इसलिए बिंदु बेस‑10 स्केल पर एक सीधा बढ़ता हुआ रेखा बनाते हैं। अक्ष लेबल अभी भी मूल अनुरोध गणनाओं को दिखाते हैं।

![पावरपॉइंट में बेस‑10 लघुगणकीय मान अक्ष पर समान पाँच अनुरोध गणनाएं](value-axis-logarithmic.png)

### **शून्य और नकारात्मक मानों को संभालें**

लघुगणकीय स्केल केवल शुद्ध सकारात्मक मान प्रदर्शित कर सकता है। सक्षम करने से पहले डेटा जाँचें। यदि शून्य या नकारात्मक मान अर्थपूर्ण हैं, तो रैखिक स्केल रखें या उन्हें अलग‑अलग दिखाएँ। यदि विश्लेषण के लिये उन मानों को बाहर करना उचित है, तो बहिष्कार का कारण बताएँ। उन्हें छोटे सकारात्मक संख्याओं से चुपके से बदलें नहीं, क्योंकि इससे डेटा का अर्थ बदल जाता है। लघुगणकीय अक्ष के लिये मैन्युअल रूप से सेट किया गया न्यूनतम या अधिकतम भी सकारात्मक ही होना चाहिए।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे वह मान सेट करूँ जिससे एक अक्ष दूसरे के ऊपर क्रॉस करे (अक्ष क्रॉसिंग)?**

क्रॉसिंग व्यवहार चुनने के लिये `[setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-)` का उपयोग करें। संख्यात्मक क्रॉसिंग मान निर्दिष्ट करने के लिये `[setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-)` का उपयोग करें। ये सेटिंग्स आपको अक्ष क्रॉसिंग को उपयुक्त बेसलाइन पर ले जाने की अनुमति देती हैं।

**मैं टिक‑लेबल को अक्ष के सापेक्ष कैसे स्थित करूँ?**

`[setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-)` को `[TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/)` के साथ उपयोग करें: `Low`, `High`, `NextTo` या `None`। टिक‑मार्क स्वयं को नियंत्रित करने के लिये `[setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-)` या `[setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-)` का उपयोग करें; ये लेबल पोज़िशनिंग से अलग होते हैं।