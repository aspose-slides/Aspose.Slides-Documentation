---
title: जावा का उपयोग करके प्रस्तुतियों में चार्ट अक्षों को अनुकूलित करें
linktitle: चार्ट अक्ष
type: docs
url: /hi/java/chart-axis/
keywords:
- चार्ट अक्ष
- ऊर्ध्वाधर अक्ष
- क्षैतिज अक्ष
- अक्ष को अनुकूलित करें
- अक्ष को नियंत्रित करें
- अक्ष का प्रबंधन करें
- अक्ष गुण
- अधिकतम मान
- न्यूनतम मान
- अक्ष रेखा
- तिथि स्वरूप
- अक्ष शीर्षक
- अक्ष स्थिति
- पॉवरपॉइंट
- प्रस्तुति
- जावा
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके रिपोर्ट और विज़ुअलाइज़ेशन के लिए PowerPoint प्रस्तुतियों में चार्ट अक्षों को अनुकूलित करने के तरीकों की खोज करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for Java के साथ चार्ट अक्षों को अनुकूलित करने के तरीकों को समझाता है। इसमें गणना किए गए अक्ष मान, चार्ट पंक्तियों और स्तंभों को बदलना, अक्ष दृश्यमानता, श्रेणी लेबल और टिक‑मार्क अंतराल, तिथि श्रेणियां और स्वरूपण, शीर्षक घूर्णन, अक्ष स्थितिकरण, प्रदर्शन इकाइयाँ, और लघुगणकीय स्केलिंग शामिल हैं।

## **चार्ट में लंबवत अक्ष पर अधिकतम मान प्राप्त करना**

एक [प्रेजेंटेशन](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) बनाएं और डिफ़ॉल्ट डेटा के साथ एक एरिया चार्ट जोड़ें। गणना किए गए अक्ष मान पढ़ने से पहले [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) को कॉल करें ताकि चार्ट लेआउट अद्यतित हो।

[getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) और [getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) को अक्ष की सीमा के लिए पढ़ें, तथा [getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) और [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) को टिक अंतराल के लिए पढ़ें। [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) और [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) समय‑इकाई स्केल प्रदान करते हैं, जो तिथि अक्षों के लिए प्रासंगिक हैं। उदाहरण इन मानों को स्थानीय चर में संग्रहित करता है और चार्ट को सहेजता है।

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

## **अक्षों के बीच डेटा बदलना**

[switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) का उपयोग करके चार्ट डेटा में सीरीज़ और वर्गों की भूमिकाओं को बदलें। प्रत्येक पूर्व वर्ग एक सीरीज़ बन जाता है, और प्रत्येक पूर्व सीरीज़ एक वर्ग बन जाता है। यह डेटा के समूहबद्ध करने के तरीके को बदलता है; यह क्षैतिज और लंबवत अक्षों को नहीं बदलता। उदाहरण [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) का उपयोग करता है ताकि डिफ़ॉल्ट डेटा को `Sheet1!A1:D5` से बाँधा जा सके, जिसमें हेडर पंक्ति और वर्ग स्तंभ शामिल हैं, पंक्तियों और स्तंभों को बदलने से पहले। यह चार सीरीज़ और तीन वर्गों वाला चार्ट सहेजता है।

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

## **अक्ष की प्लॉट क्रम को उलटना**

[setPlotOrderReversed](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) का उपयोग करके वर्ग या मान अक्ष को उलटा जाए। उदाहरण के लिए, एक क्षैतिज बार चार्ट कार्य चरणों को शीर्ष से नीचे तक उसी क्रम में दिखा सकता है जैसा कि वर्कशीट में है: योजना, विकास, परीक्षण। अक्ष को उलटना प्लॉट दिशा बदलता है; यह वर्कबुक डेटा को क्रमबद्ध या पुनर्व्यवस्थित नहीं करता। तुलना के लिए, [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) सीरीज़ और वर्गों की भूमिकाओं को बदलता है।

निम्नलिखित उदाहरण तीन चरणों के साथ एक क्षैतिज बार चार्ट बनाता है और एक सीरीज़ बनाता है। यह तीन स्लाइडों के साथ एक प्रेजेंटेशन सहेजता है: सामान्य क्रम, उल्टे वर्ग, और उल्टे मान। प्रत्येक प्रतिलिपि समान डेटासेट का उपयोग करती है, और प्रत्येक में केवल एक ही अक्ष उलटा जाता है।

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

    // स्लाइड 2: पहले वर्ग को शीर्ष पर प्रदर्शित करें।
    ISlide categorySlide = presentation.getSlides().addClone(slide);
    IChart categoryChart = (IChart)categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // क्षैतिज मान अक्ष को नीचे रखें।
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

अक्ष को उलटने से परपेंडिक्युलर अक्ष को प्लॉट के विपरीत पक्ष पर ले जाया जा सकता है। [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) निर्धारित करता है कि अन्य अक्ष किस स्थान पर कॉन्फ़िगर किए जा रहे अक्ष को काटता है। स्लाइड 2 में, इसे उल्टे वर्ग अक्ष पर `CrossesType.Maximum` के साथ कॉल करने से क्षैतिज मान अक्ष नीचे बना रहता है। किसी विशिष्ट कटाव बिंदु के लिए, [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-) का उपयोग करें। दिशा बदलते समय कटाव सेटिंग्स की जाँच करें, विशेष रूप से यदि चार्ट में पहले से कस्टम कटाव बिंदु हो। सामान्य प्लॉट दिशा पुनर्स्थापित करने के लिए `setPlotOrderReversed` को `false` के साथ कॉल करें; कटाव सेटिंग्स अलग रहती हैं।

| सामान्य क्रम (स्लाइड 1) | उलटे वर्ग (स्लाइड 2) | उलटे मान (स्लाइड 3) |
| --- | --- | --- |
| ![सामान्य वर्ग और मान अक्ष क्रम वाला क्षैतिज बार चार्ट](axis-order-normal.png) | ![ऊपर से नीचे तक प्रदर्शित वर्गों वाला क्षैतिज बार चार्ट](axis-order-categories-reversed.png) | ![उल्टा मान अक्ष और दाएँ शून्य वाला क्षैतिज बार चार्ट](axis-order-values-reversed.png) |
| श्रेणियां नीचे से ऊपर तक होती हैं; मान बाएं से दाएं बढ़ते हैं। | योजनाऐं, विकास, और परीक्षण ऊपर से नीचे तक होते हैं। मान और वर्कबुक पंक्ति क्रम अपरिवर्तित रहता है। | श्रेणियां अपने सामान्य क्रम को बनाए रखती हैं; मान दाएं से बाएं बढ़ते हैं। श्रेणी अक्ष दाएँ शून्य पर काटता है। |

## **लाइन चार्ट के लिए लंबवत अक्ष को अक्षम करना**

लंबवत अक्ष को छुपाने के लिए `false` के साथ [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) को कॉल करें। उदाहरण एक लाइन चार्ट बनाता है जिसमें डिफ़ॉल्ट डेटा होता है और उसे लंबवत अक्ष अछूता रखकर सहेजता है।

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

## **लाइन चार्ट के लिए क्षैतिज अक्ष को अक्षम करना**

क्षैतिज अक्ष को छुपाने के लिए `false` के साथ [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) को कॉल करें। उदाहरण एक लाइन चार्ट बनाता है जिसमें डिफ़ॉल्ट डेटा होता है और उसे क्षैतिज अक्ष अछूता रखकर सहेजता है।

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

## **एक वर्ग अक्ष बदलें**

[setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) का उपयोग करके तिथि या टेक्स्ट वर्ग अक्ष चुनें। यह उदाहरण `ExistingChart.pptx` की आवश्यकता रखता है, जिसमें पहली स्लाइड पर पहला आकार एक चार्ट है और वर्ग कोशिकाओं में संख्यात्मक Excel तिथि मान होते हैं। यह क्षैतिज अक्ष को तिथि अक्ष में बदलता है। [setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) को `false` के साथ, [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) को `1` के साथ, और [setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) को `TimeUnitType.Months` के साथ कॉल करने से प्रमुख टिक एक महीने के अंतराल पर रखे जाते हैं।

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

## **श्रेणी अक्ष लेबल अंतराल को नियंत्रित करें**

जब चार्ट में कई वर्ग हों, तो वर्गों या डेटा बिंदुओं को हटाए बिना दिखाई देने वाले अक्ष लेबलों की संख्या घटाएँ। [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) को `false` के साथ कॉल करें, फिर वांछित वर्ग अंतराल को [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-) में पास करें। सामान्य क्रम में टेक्स्ट वर्गों के लिए गिनती पहले वर्ग से शुरू होती है:

| अंतराल | उदाहरण में दिखाए गए लेबल |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

`3` का अंतराल हर तीसरा लेबल दिखाता है, प्रदर्शित लेबलों के बीच दो लेबल छिपे रहते हैं। यह संबंधित स्तंभों को नहीं हटाता। स्वचालित स्पेसिंग उपलब्ध स्थान के आधार पर अंतराल चुनता है; यह जरूरी नहीं कि हर लेबल दिखे।

टिक‑मार्क के लिए अलग नियंत्रण हैं। [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) को `false` के साथ कॉल करें और [setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) का उपयोग करके उनका अंतराल सेट करें। उदाहरण के लिए, `1` प्रत्येक वर्ग अंतराल पर टिक‑मार्क रखता है जबकि लेबल केवल हर तीसरे वर्ग पर दिखते हैं। दृश्य शैली के साथ [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) का उपयोग करें ताकि परिणाम देखा जा सके। किसी भी स्वचालित‑स्पेसिंग सेटर को फिर से `true` करने से चार्ट को वह अंतराल पुनः चुनने देता है।

निम्नलिखित स्वनिर्भर उदाहरण 24 वर्ग और एक सीरीज़ बनाता है, फिर `CategoryAxisIntervals.pptx` में तीन स्लाइड सहेजता है: स्वचालित स्पेसिंग, स्वतंत्र टिक‑मार्क के साथ मैन्युअल लेबल स्पेसिंग, और पुनर्स्थापित स्वचालित स्पेसिंग। दोनों प्रतियों में मूल चार्ट डेटा बरकरार रहता है। इनपुट प्रेजेंटेशन की आवश्यकता नहीं है। क्षैतिज लेबल टेक्स्ट घनत्व अंतर को स्पष्ट दिखाता है।

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

    // स्लाइड 2: हर तीसरा लेबल दिखाएँ, लेकिन प्रत्येक वर्ग के लिए एक टिक‑मार्क रखें।
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

**स्वचालित स्पेसिंग (स्लाइड 1):** इस रेंडरिंग में प्रत्येक दूसरे वर्ग लेबल दिखाया जाता है और दो पंक्तियों में रैप होता है। स्वचालित परिणाम चार्ट आकार, फ़ॉन्ट और रेंडरर के अनुसार बदल सकता है।

![सभी 24 स्तंभ दृश्यमान के साथ स्वचालित वर्ग लेबल स्पेसिंग](category-axis-automatic.png)

**मैन्युअल स्पेसिंग (स्लाइड 2):** प्रत्येक तीसरा लेबल एक पंक्ति में दिखाया जाता है, जबकि टिक‑मार्क प्रत्येक वर्ग अंतराल पर बने रहते हैं। सभी 24 स्तंभ, जिनमें बिना लेबल वाले भी शामिल हैं, समान मानों के साथ दृश्यमान रहते हैं। स्लाइड 3 ऊपर दिखाए गए स्वचालित रूप को पुनर्स्थापित करता है।

![सभी 24 स्तंभ दृश्यमान के साथ तीन का मैन्युअल वर्ग लेबल अंतराल](category-axis-manual.png)

### **सही अक्ष और अंतराल चुनें**

टेक्स्ट वर्ग अक्ष के लिए यह वर्ग‑गणना अंतराल उपयोग करें, जैसे कि कॉलम, लाइन, एरिया या बार चार्ट का वर्ग अक्ष। कॉलम चार्ट में यह क्षैतिज अक्ष होता है। क्षैतिज बार चार्ट में वर्ग अक्ष लंबवत होता है, इसलिए इन सेटिंग्स को उस अक्ष पर लागू करें जो [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) द्वारा लौटाया जाता है। टिक‑मार्क स्पेसिंग उन चार्ट्स में सीरीज़ अक्ष पर भी लागू होती है जिनमें वह मौजूद हो।

मूल्य अक्ष के संख्यात्मक स्केल को सेट करने के लिए वर्ग लेबल स्पेसिंग का उपयोग न करें। मूल्य अक्ष पर, [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) मान अंतर निर्दिष्ट करता है: उदाहरण के लिए, `10` का प्रमुख इकाई 0, 10, 20 आदि पर टिक बनाता है जब अक्ष शून्य से शुरू होता है। `3` का वर्ग लेबल अंतराल केवल वर्ग स्थितियों को गिनता है, उनके डेटा मानों की परवाह किए बिना। स्कैटर और बबल चार्ट टेक्स्ट वर्ग अक्ष के बजाय मूल्य अक्ष का उपयोग करते हैं। तिथि अक्ष के लिए, [Change a Category Axis](#change-a-category-axis) में वर्णित समय‑आधारित प्रमुख इकाइयाँ और स्केल का उपयोग करें।

## **श्रेणी अक्ष मानों के लिए तिथि स्वरूप सेट करें**

उदाहरण डिफ़ॉल्ट चार्ट डेटा को चार वार्षिक मानों से बदलता है। तिथियों को पहले कार्यपत्र (सूचकांक `0`) में OLE Automation सीरियल नंबर के रूप में संग्रहीत किया जाता है, जो 30 दिसंबर 1899 से दिनों की संख्या के रूप में गणना होती है। [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) को `CategoryAxisType.Date` के साथ, [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) को `false` के साथ, और `yyyy` को [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) में पास करके वर्ग लेबल चार अंकों के वर्ष को सेल स्वरूप से स्वतंत्र रूप से प्रदर्शित करते हैं।

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

लंबवत अक्ष पर `true` के साथ [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) को कॉल करें, शीर्षक पाठ प्रदान करें, और [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) का उपयोग करके शीर्षक को घुमाएँ। कोण डिग्री में मापा जाता है; यह उदाहरण एक कॉलम चार्ट को उसके मान‑अक्ष शीर्षक को 90 डिग्री घुमाए हुए सहेजता है।

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

## **क्लास या मान अक्ष पर अक्ष स्थिति सेट करें**

[setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) का उपयोग करके नियंत्रित करें कि मान अक्ष वर्ग अक्ष को वर्गों के बीच या वर्ग टिक‑मार्क पर काटता है। यह सेटिंग वर्ग अक्षों पर लागू होती है। उदाहरण इसे कॉलम चार्ट के क्षैतिज वर्ग अक्ष पर `true` सेट करता है और परिणाम सहेजता है।

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

[setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) का उपयोग करके मान अक्ष पर लेबल को स्केल करें, बिनाअंतर्निहित डेटा बदले। जब [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) को `Millions` पर सेट किया जाता है, तो 60,000,000 को 60 के रूप में दिखाया जाता है। उदाहरण एक कॉलम चार्ट बनाता है और उसके लंबवत अक्ष पर मिलियन प्रदर्शन इकाई लागू करता है।

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

लघुगणकीय मान अक्ष तब उपयोगी होता है जब सकारात्मक मान कई क्रम की परिमाण में होते हैं। उदाहरण के लिए, एक सेवा को पाँच अवधियों में 10, 100, 1,000, 10,000, और 100,000 अनुरोध मिल सकते हैं। रैखिक स्केल पर छोटे मान शून्य के निकट बहुत साथ होते हैं। लघुगणकीय स्केल उनके सापेक्ष वृद्धि को आसान तुलना योग्य बनाता है: समान दूरी समान अनुपात को दर्शाती है न कि समान अंतर को।

[setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-) को `true` के साथ मान अक्ष पर कॉल करें और [setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-) का उपयोग करके आधार चुनें। यह मौजूदा मानों के प्रदर्शित होने के तरीके को बदलता है; यह डेटा नहीं बदलता और न ही लघुगणकीय ट्रेंड लाइन जोड़ता है। ट्रेंड लाइन डेटा में फिटेड संबंध को दर्शाती है और एक अलग सुविधा है।

### **मान अक्ष और आधार चुनें**

लाइन या कॉलम चार्ट के लिए, मान अक्ष [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) द्वारा लौटाया जाता है। क्षैतिज बार चार्ट के लिए, यह [getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--) द्वारा लौटाया जाता है। स्कैटर और बबल चार्ट में दो मान अक्ष होते हैं, इसलिए X मानों के लिए क्षैतिज अक्ष, Y मानों के लिए लंबवत अक्ष, या दोनों चुनें। वर्ग अक्ष पर लघुगणकीय स्केलिंग न लागू करें।

डिफ़ॉल्ट लघुगणकीय आधार `10` है। PPTX चार्ट्स के लिए, `2` से `1000` (समावेशी) के बीच का आधार उपयोग करें; अंशात्मक आधार जैसे `2.5` भी समर्थित हैं। आधार `10` के साथ क्रमिक शक्ति जैसे 10, 100, 1,000, 10,000 समान रूप से स्पेस्ड होते हैं।

### **रैखिक और लघुगणकीय स्केल की तुलना करें**

निम्नलिखित स्वनिर्भर उदाहरण पहले स्लाइड पर पाँच अनुरोध गिनती के साथ एक लाइन चार्ट बनाता है, फिर उस स्लाइड की प्रतिलिपि बनाता है और दूसरी स्लाइड पर आधार‑10 लघुगणकीय मान अक्ष सक्षम करता है। दोनों स्लाइड समान डेटा बरकरार रखते हैं।

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

    // पहले स्लाइड को रैखिक रखें और केवल कॉपी के मान‑अक्ष स्केल को बदलें।
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

**रैखिक स्केल (स्लाइड 1):** समान ऊर्ध्वाधर दूरी समान अनुरोध गिनती अंतर को दर्शाती है। सबसे बड़े मान चार्ट को हावी कर देते हैं, जिससे छोटे मान पहचानने में कठिन होते हैं।

![रैखिक मान अक्ष पर पाँच अनुरोध गिनती दिखाने वाला लाइन चार्ट](value-axis-linear.png)

**लघुगणकीय स्केल (स्लाइड 2):** समान ऊर्ध्वाधर दूरी समान अनुपात को दर्शाती है। प्रत्येक अवधि का अनुरोध पिछले की तुलना में दस गुना अधिक है, इसलिए बिंदु आधार‑10 स्केल पर सीधी ऊपर की ओर रेखा बनाते हैं। अक्ष लेबल अभी भी मूल अनुरोध गिनती दिखाते हैं।

![बेस‑10 लघुगणकीय मान अक्ष पर वही पाँच अनुरोध गिनती दिखाने वाला चार्ट](value-axis-logarithmic.png)

### **शून्य और नकारात्मक मानों को संभालें**

लघुगणकीय स्केल केवल शुद्ध सकारात्मक मानों को दिखा सकता है। इसे सक्षम करने से पहले डेटा की जाँच करें। यदि शून्य या नकारात्मक मान अर्थपूर्ण हैं, तो रैखिक स्केल रखें या उन्हें अलग से प्रदर्शित करें। यदि उन मानों को विश्लेषण से बाहर करना उपयुक्त है, तो बहिष्करण का कारण बताएं। उन्हें छोटे सकारात्मक संख्याओं से चुपचाप बदलना डेटा की अर्थवत्ता बदल देता है। लघुगणकीय अक्ष के लिए कोई भी मैन्युअल न्यूनतम या अधिकतम भी सकारात्मक होना चाहिए।

## **अक्सर पूछे जाने वाले प्रश्न**

**एक अक्ष को दूसरे के ऊपर कहाँ जोड़ना है (अक्ष क्रॉसिंग) सेट कैसे करें?**

[setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) का उपयोग करके क्रॉसिंग व्यवहार चुनें। संख्यात्मक क्रॉसिंग मान निर्दिष्ट करने के लिए [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-) का उपयोग करें। ये सेटिंग्स आपको अक्ष क्रॉसिंग को उचित बेसलाइन पर ले जाने देती हैं।

**टिक लेबल को अक्ष के सापेक्ष कैसे स्थित करें?**

[TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/) में `Low`, `High`, `NextTo`, या `None` में से चुनते हुए [setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) को कॉल करें। टिक‑मार्क स्वयं को नियंत्रित करने के लिए, [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) या [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-) का उपयोग करें; ये लेबल स्थिति से अलग होते हैं।