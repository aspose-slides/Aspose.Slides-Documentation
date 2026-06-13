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
- अक्ष को नियंत्रित करें
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
description: "Aspose.Slides for Android via Java का उपयोग करके रिपोर्ट और विज़ुअलाइज़ेशन के लिए PowerPoint प्रस्तुतियों में चार्ट अक्षों को अनुकूलित करने के तरीके जानें।"
---
## **परिचय**

यह लेख Aspose.Slides में चार्ट अक्षों को अनुकूलित करने की विधि बताता है। यह वास्तविक अक्ष मान प्राप्त करने, अक्षों के बीच डेटा अदला‑बदली करने, लाइन चार्ट के लिए लंबवत या क्षैतिज अक्ष को छिपाने, श्रेणी अक्ष का प्रकार बदलने, श्रेणी अक्ष मानों के लिए तिथि स्वरूप सेट करने, अक्ष शीर्षक को घुमाने, अक्ष की स्थिति निर्धारित करने, और मान अक्ष पर इकाई लेबल प्रदर्शित करने के तरीके दिखाता है।

## **चार्ट में लंबवत अक्ष के अधिकतम मान प्राप्त करें**

Aspose.Slides for Android via Java आपको लंबवत अक्ष पर न्यूनतम और अधिकतम मान प्राप्त करने की अनुमति देता है। इन चरणों का पालन करें:

1. [Presentation] क्लास का एक इंस्टेंस बनाएं।
2. पहली स्लाइड तक पहुँचें।
3. डिफॉल्ट डेटा के साथ एक चार्ट जोड़ें।
4. अक्ष पर वास्तविक अधिकतम मान प्राप्त करें।
5. अक्ष पर वास्तविक न्यूनतम मान प्राप्त करें।
6. अक्ष की वास्तविक मेजर यूनिट प्राप्त करें।
7. अक्ष की वास्तविक माइनर यूनिट प्राप्त करें।
8. अक्ष के वास्तविक मेजर यूनिट स्केल प्राप्त करें।
9. अक्ष के वास्तविक माइनर यूनिट स्केल प्राप्त करें।

यह सैंपल कोड—ऊपर बताए गए चरणों का कार्यान्वयन—जावा में आवश्यक मान प्राप्त करने का तरीका दर्शाता है:

```java
Presentation pres = new Presentation();
try {
	Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
	chart.validateChartLayout();

	double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
	double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

	double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
	double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();

	// प्रस्तुति को सहेजता है
	pres.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **अक्षों के बीच डेटा अदला‑बदली**

Aspose.Slides आपको अक्षों के बीच डेटा को तेज़ी से बदलने की अनुमति देता है—लंबवत अक्ष (y‑axis) पर दर्शाया गया डेटा क्षैतिज अक्ष (x‑axis) पर जाता है और इसके विपरीत।

यह जावा कोड दिखाता है कि चार्ट पर अक्षों के बीच डेटा अदला‑बदली कार्य कैसे किया जाए:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//पंक्तियों और स्तंभों को बदलता है
	// प्रस्तुति को सहेजता है
	pres.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **लाइन चार्ट के लिए लंबवत अक्ष को निष्क्रिय करें**

यह जावा कोड दिखाता है कि लाइन चार्ट के लिए लंबवत अक्ष को कैसे छिपाया जाए:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
	chart.getAxes().getVerticalAxis().setVisible(false);

	pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **लाइन चार्ट के लिए क्षैतिज अक्ष को निष्क्रिय करें**

यह कोड दिखाता है कि लाइन चार्ट के लिए क्षैतिज अक्ष को कैसे छिपाया जाए:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
	chart.getAxes().getHorizontalAxis().setVisible(false);

	pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **श्रेणी अक्ष बदलें**

**CategoryAxisType** प्रॉपर्टी का उपयोग करके आप अपनी वांछित श्रेणी अक्ष प्रकार (**date** या **text**) निर्दिष्ट कर सकते हैं। यह जावा कोड इस ऑपरेशन को प्रदर्शित करता है:

```java
Presentation presentation = new Presentation("ExistingChart.pptx");
try {
	IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
	chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
	chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
	chart.getAxes().getHorizontalAxis().setMajorUnit(1);
	chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);
	presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (presentation != null) presentation.dispose();
}
```

## **श्रेणी अक्ष मानों के लिए तिथि स्वरूप सेट करें**

Aspose.Slides for Android via Java आपको श्रेणी अक्ष मान के लिए तिथि स्वरूप सेट करने की अनुमति देता है। यह ऑपरेशन इस जावा कोड में दर्शाया गया है:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 50, 50, 450, 300);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", convertToOADate(new GregorianCalendar(2015, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", convertToOADate(new GregorianCalendar(2016, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", convertToOADate(new GregorianCalendar(2017, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", convertToOADate(new GregorianCalendar(2018, 1, 1))));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B2", 1));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B3", 2));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B4", 3));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B5", 4));
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");
	
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
public static String convertToOADate(GregorianCalendar date) throws ParseException
{
    double oaDate;
    SimpleDateFormat myFormat = new SimpleDateFormat("dd MM yyyy");
    java.util.Date baseDate = myFormat.parse("30 12 1899");
    Long days = TimeUnit.DAYS.convert(date.getTimeInMillis() - baseDate.getTime(), TimeUnit.MILLISECONDS);
    oaDate = (double) days + ((double) date.get(Calendar.HOUR_OF_DAY) / 24) + ((double) date.get(Calendar.MINUTE) / (60 * 24)) + ((double) date.get(Calendar.SECOND) / (60 * 24 * 60));
    return String.valueOf(oaDate);
}
```

## **चार्ट अक्ष शीर्षक के लिए घुमाव कोण सेट करें**

Aspose.Slides for Android via Java आपको चार्ट अक्ष शीर्षक के लिए घुमाव कोण सेट करने की अनुमति देता है। यह जावा कोड इस ऑपरेशन को दर्शाता है:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **श्रेणी या मान अक्ष पर अक्ष स्थिति सेट करें**

Aspose.Slides for Android via Java आपको श्रेणी या मान अक्ष में अक्ष की स्थिति सेट करने की अनुमति देता है। यह जावा कोड कार्य को कैसे किया जाए दर्शाता है:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **चार्ट मान अक्ष पर डिस्प्ले यूनिट लेबल सक्षम करें**

Aspose.Slides for Android via Java आपको चार्ट को इस तरह कॉन्फ़िगर करने की अनुमति देता है कि वह अपने मान अक्ष पर यूनिट लेबल दिखाए। यह जावा कोड इस ऑपरेशन को प्रदर्शित करता है:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);

    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**मैं कैसे निर्धारित करूँ कि एक अक्ष दूसरे को कहाँ पार करे (अक्ष क्रॉसिंग)?**

अक्षों में एक [क्रॉसिंग सेटिंग](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/axis/#setCrossType-int-): आप शून्य पर, अधिकतम श्रेणी/मान पर, या किसी विशिष्ट संख्यात्मक मान पर क्रॉस करने का चयन कर सकते हैं। यह X‑axis को ऊपर या नीचे शिफ्ट करने या बेसलाइन को जोर देने में उपयोगी है।

**मैं टिक लेबल्स को अक्ष के सापेक्ष कैसे स्थित करूँ (साइडबाय, बाहर, अंदर)?**

[label position](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) को "cross", "outside", या "inside" पर सेट करें। यह पठनीयता को प्रभावित करता है और विशेष रूप से छोटे चार्ट्स में स्थान बचाने में मदद करता है।